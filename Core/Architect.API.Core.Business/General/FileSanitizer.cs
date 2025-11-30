using Architect.Utilities;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Web;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Realiza la validación de archivos usando números mágicos (headers) y estructura interna.
    /// </summary>
    public static class FileSanitizer
    {
        // Encabezados (Magic Numbers)
        private static readonly byte[] PdfHeader = { 0x25, 0x50, 0x44, 0x46 }; // %PDF

        private static readonly byte[] ZipHeader = { 0x50, 0x4B, 0x03, 0x04 }; // ZIP (DOCX, XLSX, PPTX)
        private static readonly byte[] XlsHeader = { 0xD0, 0xCF, 0x11, 0xE0 }; // XLS (OLE)
        private static readonly byte[] PngHeader = { 0x89, 0x50, 0x4E, 0x47 }; // PNG
        private static readonly byte[] XmlHeader = { 0x3C, 0x3F, 0x78, 0x6D };

        // JPG puede tener distintos headers
        private static readonly byte[] JpgHeader1 = { 0xFF, 0xD8, 0xFF, 0xE0 }; // EXIF

        private static readonly byte[] JpgHeader2 = { 0xFF, 0xD8, 0xFF, 0xE1 }; // APP1 Canon
        private static readonly byte[] JpgHeader3 = { 0xFF, 0xD8, 0xFF, 0xE8 }; // SPIFF

        // Tipos MIME soportados y sus validadores
        private static Dictionary<string, Func<HttpPostedFile, byte[], bool>> _types =
            new Dictionary<string, Func<HttpPostedFile, byte[], bool>>()
        {
            // XLSX
            { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", (file, header) =>
                header.SequenceEqual(ZipHeader) && IsValidDocxFile(file.InputStream, false)
            },

            // XLS
            { "application/vnd.ms-excel", (file, header) =>
                header.SequenceEqual(XlsHeader)
            },

            // DOCX
            { "application/vnd.openxmlformats-officedocument.wordprocessingml.document", (file, header) =>
                header.SequenceEqual(ZipHeader) && IsValidDocxFile(file.InputStream, true)
            },

            // PDF
            { "application/pdf", (file, header) =>
                header.SequenceEqual(PdfHeader)
            },

            // PNG
            { "image/png", (file, header) =>
                header.SequenceEqual(PngHeader)
            },

            // JPG
            { "image/jpeg", (file, header) =>
                header.SequenceEqual(JpgHeader1) ||
                header.SequenceEqual(JpgHeader2) ||
                header.SequenceEqual(JpgHeader3)
            },

            // JSON
            { "application/json", (file, header) =>
                IsValidJsonFile(file)
            },
            { "text/xml", (file, header) =>
                header.SequenceEqual(XmlHeader) &&     IsValidXmlFile(file)
            }
        };

        private static bool IsValidXmlFile(HttpPostedFile file)
        {
            try
            {
                file.InputStream.Position = 0;
                var xml = new System.Xml.XmlDocument();
                xml.Load(file.InputStream);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Valida el tipo de archivo mediante su cabecera y estructura interna.
        /// </summary>
        public static bool IsValidFileFormat(this HttpPostedFile file)
        {
            if (file.IsNotEmpty())
            {
                var key = file.ContentType.ToLower();

                if (!_types.ContainsKey(key))
                    return false;

                // Leer primeros 4 bytes
                byte[] header = new byte[4];
                file.InputStream.Read(header, 0, header.Length);

                // Reset stream
                if (file.InputStream.CanSeek)
                    file.InputStream.Position = 0;

                return _types[key](file, header);
            }

            return false;
        }

        /// <summary>
        /// Validar archivos DOCX / XLSX (ZIP) verificando archivos internos.
        /// </summary>
        private static bool IsValidDocxFile(Stream inputStream, bool isWord)
        {
            string requiredMainFile = isWord ? "word/document.xml" : "xl/workbook.xml";

            if (inputStream.CanSeek)
                inputStream.Seek(0, SeekOrigin.Begin);
            else
            {
                var ms = new MemoryStream();
                inputStream.CopyTo(ms);
                inputStream = ms;
                inputStream.Seek(0, SeekOrigin.Begin);
            }

            return ValidateDocxArchive(inputStream, requiredMainFile);
        }

        /// <summary>
        /// Valida contenido ZIP para DOCX / XLSX.
        /// </summary>
        private static bool ValidateDocxArchive(Stream stream, string typeOffice)
        {
            bool hasDocumentXml = false;
            bool hasContentTypesXml = false;
            bool hasRelsFolder = false;

            using (var zip = new ZipArchive(stream, ZipArchiveMode.Read, true))
            {
                foreach (var entry in zip.Entries)
                {
                    string name = entry.FullName.ToLower();

                    if (name == typeOffice.ToLower())
                        hasDocumentXml = true;
                    else if (name == "[content_types].xml")
                        hasContentTypesXml = true;
                    else if (name == "_rels/.rels")
                        hasRelsFolder = true;

                    if (hasDocumentXml && hasContentTypesXml && hasRelsFolder)
                        break;
                }
            }
            return hasDocumentXml && hasContentTypesXml && hasRelsFolder;
        }

        /// <summary>
        /// Valida que el archivo JSON sea correcto.
        /// </summary>
        private static bool IsValidJsonFile(HttpPostedFile file)
        {
            try
            {
                file.InputStream.Position = 0;

                using (var reader = new StreamReader(file.InputStream))
                {
                    string json = reader.ReadToEnd();
                    JsonDocument.Parse(json);
                    return true;
                }
            }
            catch (JsonException)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Valida tamaño máximo y mínimo de archivo.
        /// </summary>
        public static bool IsValidFileSize(this HttpPostedFile file)
        {
            if (file.IsNotEmpty())
            {
                string contentType = file.ContentType.ToLower();
                int size = file.ContentLength;

                if ((contentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                    || contentType == "application/pdf")
                    && size < 13312) return false;

                if (contentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                    && size < 9216) return false;

                if (size >= 31457280) return false; // 30MB

                return true;
            }
            return false;
        }
    }
}