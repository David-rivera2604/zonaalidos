using Architect.Utilities;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Realiza la sanitización de los archivos de entrada utilizando los números mágicos del encabezado para validar su integridad y formato.
    /// 
    /// Los formatos soportados son: XLS, XLSX, DOC, DOCX, JSON y PNG.
    /// </summary>
    public static class FileSanitizer
    {

        // Definir los encabezados para diferentes tipos de archivos
        private static readonly byte[] PdfHeader = { 0x25, 0x50, 0x44, 0x46 }; // PDF (Encabezado de archivos PDF)
        private static readonly byte[] DocxHeader = { 0x50, 0x4B, 0x03, 0x04 }; // PK (Encabezado de archivos DOCX y XLSX)
        private static readonly byte[] XlsHeader = { 0xD0, 0xCF, 0x11, 0xE0 }; // Encabezado de archivos XLS
        private static readonly byte[] XlsxHeader = { 0x50, 0x4B, 0x03, 0x04 }; // PK (Encabezado de archivos XLSX)
        private static readonly byte[] PngHeader = { 0x89, 0x50, 0x4E, 0x47 }; // PNG (Encabezado de archivos PNG)
        private static readonly byte[] JpgHeader = { 0xFF, 0xD8, 0xFF, 0xE0 }; // JPG (Encabezado de archivos JPG)

        // Diccionario para mapear tipos MIME a funciones de validación
        private static Dictionary<string, Func<HttpPostedFile, byte[], bool>> _types = new Dictionary<string, Func<HttpPostedFile, byte[], bool>>()
            {
                // Validar archivos XLSX
                { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", (file, header) =>
                    {
                        var result = false;
                        // Verificar si el encabezado coincide con el de XLSX
                        if (header.SequenceEqual(XlsxHeader))
                            result = IsValidDocxFile(file.InputStream, false); // Validar el archivo como DOCX (en este caso XLSX)
                        return result;
                    }
                },
                // Validar archivos XLS
                { "application/vnd.ms-excel",  (file, header) =>
                    {
                        var result = false;
                        // Verificar si el encabezado coincide con el de XLS
                        if (header.SequenceEqual(XlsHeader))
                           result = true; // Considerar el archivo como válido
                        return result;
                    }
                },
                // Validar archivos DOCX
                { "application/vnd.openxmlformats-officedocument.wordprocessingml.document", (file, header) =>
                    {
                        var result = false;
                        // Verificar si el encabezado coincide con el de DOCX
                        if (header.SequenceEqual(DocxHeader))
                            result = IsValidDocxFile(file.InputStream, true); // Validar el archivo como DOCX (Word)
                        return result;
                    }
                },
                // Validar archivos PDF
                { "application/pdf", (file, header) =>
                    {
                        var result = false;
                        // Verificar si el encabezado coincide con el de PDF
                        result = header.SequenceEqual(PdfHeader);
                        return result;
                    }
                },
                // Validar archivos PNG
                { "image/png", (file, header) =>
                    {
                        // Verificar si el encabezado coincide con el de PNG
                        var result = header.SequenceEqual(PngHeader);
                        return result;
                    }
                },
                // Validar archivos JPG
                { "image/jpg", (file, header) =>
                    {
                        // Verificar si el encabezado coincide con el de JPG
                        var result = header.SequenceEqual(JpgHeader);
                        return result;
                    }
                },
                // Validar archivos JSON
                { "application/json", (file, header) =>
                    {
                        var result = IsValidJsonFile(file); // Validar si el archivo contiene JSON válido
                        return result;
                    }
                }
            };

        /// <summary>
        /// Función principal para validar el formato del archivo
        /// </summary>
        /// <param name="file">El archivo a validar</param>
        /// <returns>True si el archivo es válido, de lo contrario False</returns>
        public static bool IsValidFileFormat(this HttpPostedFile file)
        {
            if (file.IsNotEmpty())
            {
                // Convertir el tipo MIME del archivo a minúsculas
                var key = file.ContentType.ToLower();
                // Verificar si el tipo MIME está soportado
                if (!_types.ContainsKey(key))
                    return false;

                // Leer los primeros 4 bytes del archivo para determinar su encabezado
                byte[] header = new byte[4];
                file.InputStream.Read(header, 0, header.Length);

                // Usar la función correspondiente para validar el archivo basado en su encabezado
                return _types[key](file, header);
            }
            else
                return false;
        }

        /// <summary>
        /// Validar archivos DOCX (o XLSX, que tienen una estructura similar)
        /// </summary>
        /// <param name="inputStream">El flujo de entrada del archivo</param>
        /// <param name="isWord">Indica si el archivo es un documento Word</param>
        /// <returns>True si el archivo es válido, de lo contrario False</returns>
        private static bool IsValidDocxFile(Stream inputStream, bool isWord)
        {
            // Definir el archivo principal a verificar (Word o Excel)
            var typeOffice = isWord ? "word/document.xml" : "xl/workbook.xml";

            // Asegurarse de que el flujo esté en el inicio
            if (inputStream.CanSeek)
            {
                inputStream.Seek(0, SeekOrigin.Begin);
            }
            else
            {
                // Si el InputStream no soporta Seek, copiar a un MemoryStream para manipularlo
                using (var memoryStream = new MemoryStream())
                {
                    inputStream.CopyTo(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    return ValidateDocxArchive(memoryStream, typeOffice); // Validar el archivo usando el MemoryStream
                }
            }

            // Validar el archivo DOCX (o XLSX) si el stream soporta Seek
            return ValidateDocxArchive(inputStream, typeOffice);
        }

        /// <summary>
        /// Validar la estructura interna de un archivo DOCX o XLSX (ZIP)
        /// </summary>
        /// <param name="stream">El flujo de entrada del archivo</param>
        /// <param name="typeOffice">El tipo de archivo a verificar (Word o Excel)</param>
        /// <returns>True si el archivo es válido, de lo contrario False</returns>
        private static bool ValidateDocxArchive(Stream stream, string typeOffice)
        {
            bool hasDocumentXml = false;
            bool hasContentTypesXml = false;
            bool hasRelsFolder = false;

            // Leer el archivo como un archivo ZIP
            using (var zipArchive = new ZipArchive(stream, ZipArchiveMode.Read, true))
            {
                foreach (var entry in zipArchive.Entries)
                {
                    // Verificar que el archivo contenga el archivo principal de Word o Excel
                    if (entry.FullName == typeOffice)
                    {
                        hasDocumentXml = true;
                    }
                    // Verificar si contiene el archivo de tipos de contenido
                    else if (entry.FullName == "[Content_Types].xml")
                    {
                        hasContentTypesXml = true;
                    }
                    // Verificar si contiene la carpeta de relaciones
                    else if (entry.FullName == "_rels/.rels")
                    {
                        hasRelsFolder = true;
                    }

                    // Si todos los archivos están presentes, podemos salir del ciclo
                    if (hasDocumentXml && hasContentTypesXml && hasRelsFolder)
                    {
                        break;
                    }
                }
            }

            // Validar que el archivo DOCX (o XLSX) tenga los archivos necesarios
            return hasDocumentXml && hasContentTypesXml && hasRelsFolder;
        }

        /// <summary>
        /// Validar si el archivo JSON tiene un formato válido
        /// </summary>
        /// <param name="file">El archivo JSON a validar</param>
        /// <returns>True si el archivo es un JSON válido, de lo contrario False</returns>
        private static bool IsValidJsonFile(HttpPostedFile file)
        {
            try
            {
                // Asegurarse de que el InputStream esté en la posición inicial
                file.InputStream.Position = 0;

                // Leer el contenido completo del archivo
                using (var stream = new StreamReader(file.InputStream))
                {
                    var jsonContent = stream.ReadToEnd();

                    // Intentar parsear el contenido como JSON
                    using (JsonDocument.Parse(jsonContent))
                    {
                        return true; // JSON válido
                    }
                }
            }
            catch (System.Text.Json.JsonException)
            {
                return false; // No es un JSON válido
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false; // Otro error
            }
        }

    }
}
