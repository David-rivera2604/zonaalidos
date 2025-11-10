using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Architect.Utilities.Extensions;
using Microsoft.VisualBasic;


namespace Architect.Sugese.Utility
{
    public sealed class SerializeType
    {
        private SerializeType() : base()
        {
        }

        //public static string Serialize<T>(T current, bool withFormat)
        //{
        //    var memoryStream = new MemoryStream();
        //    var xmlSerialiazerItem = new XmlSerializer(typeof(T));
        //    var xmlTextWriterItem = new XmlTextWriter(memoryStream, new UTF8Encoding(false, true));

        //    if (withFormat)
        //    {
        //        xmlTextWriterItem.Formatting = Formatting.Indented;
        //        xmlTextWriterItem.Indentation = 2;
        //        xmlTextWriterItem.IndentChar = ' ';
        //    }
        //    xmlSerialiazerItem.Serialize(xmlTextWriterItem, current);
        //    string result = Encoding.UTF8.GetString(memoryStream.ToArray());
        //    xmlTextWriterItem.Close();

        //    // Dim memoryStream As New MemoryStream()
        //    // Dim xs As XmlSerializer = New XmlSerializer(GetType(T))
        //    // Dim xmlTextWriter As XmlTextWriter = New XmlTextWriter(memoryStream, Encoding.UTF8)
        //    // With xmlTextWriter
        //    // .Formatting = Formatting.Indented
        //    // .Indentation = 2
        //    // .IndentChar = " "
        //    // End With

        //    // xs.Serialize(xmlTextWriter, current)

        //    // Dim serializedObj As String
        //    // Dim serializer As New XmlSerializer(GetType(T))
        //    // Using writer As New StringWriter(CultureInfo.InvariantCulture)
        //    // serializer.Serialize(writer, current)
        //    // serializedObj = writer.ToString()
        //    // Return serializedObj
        //    // End Using
        //    return result;
        //}

        //public static void SerializeToFile<T>(T current, string fullFileName, bool withFormat)
        //{
        //    var xmlSerialiazerItem = new XmlSerializer(typeof(T));
        //    var fileStreamItem = new FileStream(fullFileName, FileMode.Create);
        //    var utf8WithoutBOM = new UTF8Encoding(false);
        //    var xmlTextWriterItem = new XmlTextWriter(fileStreamItem, utf8WithoutBOM);

        //    if (withFormat)
        //    {
        //        xmlTextWriterItem.Formatting = Formatting.Indented;
        //        xmlTextWriterItem.Indentation = 2;
        //        xmlTextWriterItem.IndentChar = ' ';
        //    }
        //    xmlSerialiazerItem.Serialize(xmlTextWriterItem, current);
        //    xmlTextWriterItem.Close();
        //    fileStreamItem.Close();
        //    fileStreamItem = null;
        //}

        public static string XMLStringEncoding(string value)
        {
            // Security.SecurityElement.Escape(

            // Regex reg = New Regex("[^a-zA-Z0-9 ]");
            // String textoSinAcentos = reg.Replace(textoNormalizado, "");

            // Return System.Web.HttpUtility.HtmlEncode(value)

            // Dim reg As RegularExpressions.Regex

            // 'transformación UNICODE
            // Dim textoNormalizado As String = value.Normalize(NormalizationForm.FormD)

            // 'coincide todo lo que no sean letras y números ascii o espacio
            // 'y lo reemplazamos por una cadena vacía.

            // reg = New RegularExpressions.Regex("[^a-zA-Z0-9 ]")

            // Return reg.Replace(textoNormalizado, "")

            if (value.IsNotEmpty())
            {
                string[] ConAcento = new string[] { "á", "é", "í", "ó", "ú", "Á", "É", "Í", "Ó", "Ú", "ñ", "Ñ" };
                string[] SinAcento = new string[] { "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "n", "N" };

                for (int i = 0, loopTo = ConAcento.Length - 1; i <= loopTo; i++)
                    value = Strings.Replace(value, ConAcento[i], SinAcento[i]);
            }

            return value;
        }
    }
}