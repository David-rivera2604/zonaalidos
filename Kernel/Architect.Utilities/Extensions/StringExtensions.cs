using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Architect.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for the string data type
    /// </summary>
    public static class StringExtensions
    {
        public static bool IsNumeric(this string value)
        {
            return value.All(char.IsNumber);
        }

        /// <summary>
        /// Turns a string into a properly XML Encoded string.
        /// Uses simple string replacement.
        ///
        /// Also see XmlUtils.XmlString() which uses XElement
        /// to handle additional extended characters.
        /// </summary>
        /// <param name="text">Plain text to convert to XML Encoded string</param>
        ///             <param name="isAttribute">
        ///             If true encodes single and double quotes.
        ///             When embedding element values quotes don't need to be encoded.
        ///             When embedding attributes quotes need to be encoded.
        ///             </param>
        ///             <returns>XML encoded string</returns>
        /// <exception cref="T:System.InvalidOperationException">Invalid character in XML string</exception>
        public static string XmlString(this string text, bool isAttribute = false)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            StringBuilder sb = new StringBuilder(text.Length);
            foreach (char chr in text)
            {
                if (chr == '<')
                {
                    sb.Append("&lt;");
                }
                else if (chr == '>')
                {
                    sb.Append("&gt;");
                }
                else if (chr == '&')
                {
                    sb.Append("&amp;");
                }
                else if (isAttribute && chr == '"')
                {
                    sb.Append("&quot;");
                }
                else if (isAttribute && chr == '\'')
                {
                    sb.Append("&apos;");
                }
                else if (chr == '\n')
                {
                    sb.Append(isAttribute ? "&#xA;" : "\n");
                }
                else if (chr == '\r')
                {
                    sb.Append(isAttribute ? "&#xD;" : "\r");
                }
                else if (chr == '\t')
                {
                    sb.Append(isAttribute ? "&#x9;" : "\t");
                }
                else
                {
                    if (chr < ' ')
                    {
                        throw new InvalidOperationException("Invalid character in Xml String. Chr " + Convert.ToInt16(chr).ToString() + " is illegal.");
                    }
                    sb.Append(chr);
                }
            }
            return sb.ToString();
        }

        public static bool EqualIgnoringCase(this string input, string value)
        {
            bool result = false;

            if (string.Equals(input.ToLower(), value.IsNotEmpty() ? value.ToLower() : "", StringComparison.CurrentCultureIgnoreCase))
                result = true;

            return result;
        }

        /// <summary>
        ///         '''  Extension permite el formate de un string
        ///         ''' </summary>
        ///         ''' <param name="value">The string value to check.</param>
        public static string SpecialFormater(this string value, params object[] args)
        {
            return string.Format(value, args);
        }

        /// <summary>
        /// Determines whether the specified string is null or empty.
        /// </summary>
        /// <param name="value">The string value to check.</param>
        public static bool IsEmpty(this string value)
        {
            return value == null || string.IsNullOrEmpty(value) || value.Length == 0;
        }

        /// <summary>
        /// Determines whether the specified string is not null or empty.
        /// </summary>
        /// <param name="value">The string value to check.</param>
        public static bool IsNotEmpty(this string value)
        {
            return !value.IsEmpty();
        }

        /// <summary>
        /// Checks whether the string is empty and returns a default value in case.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Either the string or the default value.</returns>
        public static string IfEmpty(this string value, string defaultValue)
        {
            if (value.IsEmpty())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        public static string Capitalize(this string value)
        {
            string result = value;

            if (result.IsNotEmpty() && result.Length > 1)
            {
                result = result.Substring(0, 1).ToUpper() + result.Substring(1).ToLower();
            }
            return result;
        }

        public static string ClosedList(this string value)
        {
            return value.ClosedList(endString: ",");
        }

        public static string ClosedList(this string value, string endString)
        {
            if (value.EndsWith(endString))
            {
                value = value.Substring(0, value.Length - endString.Length);
            }

            return value.Trim();
        }

        /// <summary>
        /// Metodo de comprescion de string, esto ose utiliza en el string de serializacion de datatable por medio de json
        /// </summary>
        /// <param name="Text">Strign a comprimir</param>
        /// <returns>String comprimido</returns>
        /// <remarks></remarks>
        public static string CompressString(this string Text)
        {
            var buffer__1 = Encoding.UTF8.GetBytes(Text);
            var memoryStream = new System.IO.MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer__1, 0, buffer__1.Length);
            }

            memoryStream.Position = 0;
            var compressedData = new byte[memoryStream.Length - 1 + 1];
            memoryStream.Read(compressedData, 0, compressedData.Length);
            var gZipBuffer = new byte[compressedData.Length + 3 + 1];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer__1.Length), 0, gZipBuffer, 0, 4);
            Debug.WriteLine("Size original:" + buffer__1.Length.ToString());
            Debug.WriteLine("Size Comopres:" + gZipBuffer.Length.ToString());
            return Convert.ToBase64String(gZipBuffer);
        }

        /// <summary>
        /// Metodo de descomprecion de string
        /// </summary>
        /// <param name="Text">String a descomprimir</param>
        /// <returns>Retorna el strign descomprimido</returns>
        /// <remarks></remarks>
        public static string DecompressString(this string Text)
        {
            var gZipBuffer = Convert.FromBase64String(Text);
            using (var memoryStream = new System.IO.MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);
                var buffer = new byte[dataLength];
                memoryStream.Position = 0;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }

        /// <summary>
        /// Deserializes a DataTable from a compressed JSON string.
        /// </summary>
        /// <param name="objectString">The compressed JSON string containing the serialized DataTable</param>
        /// <returns>Deserialized DataTable object</returns>
        public static DataTable Deserialize(this string objectString)
        {
            string descompresString = objectString.DecompressString();
            return JsonConvert.DeserializeObject<DataTable>(descompresString, new DataTableConverter());
        }

        /// <summary>
        /// Deserializes a JSON string to the specified type T.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to</typeparam>
        /// <param name="body">The JSON string to deserialize</param>
        /// <param name="settings">Optional JSON serializer settings. If null, default settings will be used.</param>
        /// <returns>Deserialized object of type T</returns>
        public static T DeserializeJSON<T>(this string body, JsonSerializerSettings settings = null)
        {
            if (settings != null)
            {
                return JsonConvert.DeserializeObject<T>(body, settings);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(body);
            }
        }

        public static string ReplaceIgnoreCase(this string originalString, string oldValue, string newValue)
        {
            if (originalString.IsEmpty())
            {
                originalString = string.Empty;
            }

            if (oldValue.IsEmpty())
            {
                oldValue = string.Empty;
            }

            if (newValue.IsEmpty())
            {
                newValue = string.Empty;
            }

            var startIndex = default(int);
            while (true)
            {
                startIndex = originalString.IndexOf(oldValue, startIndex, StringComparison.CurrentCultureIgnoreCase);
                if (startIndex == -1)
                    break;
                originalString = originalString.Substring(0, startIndex) + newValue + originalString.Substring(startIndex + oldValue.Length);
                startIndex += newValue.Length;
            }

            return originalString;
        }

        public static string TagValue(this string value, string startTag, string endTag)
        {
            string result = string.Empty;
            int startIndex = value.IndexOf(startTag, StringComparison.CurrentCultureIgnoreCase);
            int endIndex = 0;
            if (startIndex > -1)
            {
                result = value.Substring(startIndex + 1);
                endIndex = result.IndexOf(endTag, StringComparison.CurrentCultureIgnoreCase);
                if (endIndex > -1)
                {
                    if (endIndex == 0)
                    {
                        result = string.Empty;
                    }
                    else
                    {
                        result = result.Substring(0, endIndex);
                    }
                }
            }

            return result;
        }

        public static Dictionary<string, string> ToDictionary(this string value, char parameterSeparartor, char valueSeparator)
        {
            Dictionary<string, string> result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            if (value.IsNotEmpty())
            {
                foreach (string paremeter in value.Split(parameterSeparartor))
                {
                    result.Add(paremeter.Split(valueSeparator)[0], paremeter.Split(valueSeparator)[1]);
                }
            }
            return result;
        }

        public static bool Contain(this string value, string findValue)
        {
            if (value == null) return false;
            return string.Format(",{0},", value.ToLower()).Contains(string.Format(",{0},", findValue.ToLower()));
        }

        public static string OnlyNumbers(this string value)
        {
            StringBuilder output = new StringBuilder();
            for (var i = 0; i <= value.Length - 1; i++)
            {
                if (Information.IsNumeric(value[i]))
                    output.Append(value[i]);
            }
            return output.ToString();
        }

        public static string CompleteFullName(this string value, string value2, string value3 = "", string value4 = "")
        {
            string result = value.Trim();

            if (value2.IsNotEmpty())
            {
                result += " " + value2.Trim();
            }
            if (value3.IsNotEmpty())
            {
                result += " " + value3.Trim();
            }
            if (value4.IsNotEmpty())
            {
                result += " " + value4.Trim();
            }
            return result;
        }

        public static string PhoneNumberFormat(this string value)
        {
            if (value.IsNotEmpty())
            {
                value = value.Replace("-", string.Empty).Trim();
                value = value.Replace("(", string.Empty).Trim();
                value = value.Replace(")", string.Empty).Trim();
                if (value.StartsWith("506"))
                {
                    value = value.Substring(3).Trim();
                }
                value = value.Substring(0, 4) + "-" + value.Substring(4, 4);
            }

            return value;
        }

        public static string IdentificationType(this string value)
        {
            string type = "";

            switch (value)
            {
                case "1": //Cédula
                case "CNA":
                    type = "CNA";
                    break;

                case "2": //Residencia
                case "CRE":
                    type = "CRE";
                    break;

                case "3": //Pasaporte
                case "PAS":
                    type = "PAS";
                    break;

                case "4": //Cédula jurídica
                case "CJU":
                    type = "CJU";
                    break;
                    //CIN
                    //EEX
            }

            return type;
        }

        public static string DocumentNumberFormat(this string value, int documentType)
        {
            if (value.IsNotEmpty())
            {
                switch (documentType)
                {
                    case 1:
                        if (value.Length == 9)
                        {
                            value = string.Format("0{0}-{1}-{2}", value.Substring(0, 1),
                               value.Substring(1, 4),
                          value.Substring(5, 4));
                        }
                        break;

                    case 2:
                        if (value.Length == 12)
                        {
                            value = string.Format("{0}-{1}-{2}", value.Substring(0, 4),
                        value.Substring(4, 6),
                        value.Substring(10, 2));
                        }
                        break;
                }
            }

            return value;
        }

        public static string DocumentNumber(this string value, string documentType)
        {
            if (value.IsNotEmpty())
            {
                if (documentType != "3" && documentType != "PAS")
                {
                    value = value.OnlyNumbers();
                    if (value.Length > 0)
                    {
                        value = Convert.ToInt64(value).ToString();
                    }
                }
            }

            return value.Trim();
        }
    }
}