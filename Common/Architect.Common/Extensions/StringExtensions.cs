using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Architect.Common.Extensions
{

    /// <summary>
    /// Extension methods for the string data type
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// Extension permite el formate de un string
        /// </summary>
        /// <param name="value">The string value to check.</param>
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
            return Information.IsNothing(value) || string.IsNullOrEmpty(value) || value.Length == 0;
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

        public static string Filter(this string value, string RegularExpression)
        {
            return value.Filter(RegularExpression, false);
        }

        public static string Filter(this string value, string RegularExpression, bool Exclude)
        {
            string result;
            var listMatch = new List<string>();
            foreach (Match match in Regex.Matches(value, RegularExpression, RegexOptions.IgnoreCase))
            {
                foreach (var ItemMach in match.Groups)
                    listMatch.Add(Conversions.ToString(ItemMach.Value));
            }

            if (Exclude)
            {
                result = value;
                foreach (string ItemList in listMatch)
                    result = result.Replace(ItemList, string.Empty);
            }
            else
            {
                result = string.Join(string.Empty, listMatch.ToArray());
            }

            return result;
        }

        public static string OnlyNumbers(this string value)
        {
            var output = new StringBuilder();
            for (int i = 0, loopTo = value.Length - 1; i <= loopTo; i++)
            {
                if (Information.IsNumeric(value[i]))
                {
                    output.Append(value[i]);
                }
            }

            return output.ToString();
        }

        /// <summary>
        /// Método de compresión de string, esto ose utiliza en el string de serialization de datatable por medio de json
        /// </summary>
        /// <param name="Text">String a comprimir</param>
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

            memoryStream.Position = 0L;
            var compressedData = new byte[(int)(memoryStream.Length - 1L + 1)];
            memoryStream.Read(compressedData, 0, compressedData.Length);
            var gZipBuffer = new byte[compressedData.Length + 3 + 1];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer__1.Length), 0, gZipBuffer, 0, 4);
            Debug.WriteLine("Size original:" + buffer__1.Length.ToString());
            Debug.WriteLine("Size Comopres:" + gZipBuffer.Length.ToString());
            return Convert.ToBase64String(gZipBuffer);
        }

        /// <summary>
        /// Método de descompresión de string
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
                memoryStream.Position = 0L;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }

        public static DataTable Deserialize(this string objectString)
        {
            string descompresString = objectString.DecompressString();
            return JsonConvert.DeserializeObject<DataTable>(descompresString, new DataTableConverter());
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

        public static string Capitalize(this string value)
        {
            string result = value;
            if (result.IsNotEmpty())
            {
                if (result.Length > 0)
                {
                    result = result.Substring(0, 1).ToUpper() + result.Substring(1);
                }

                if (result.Length > 1)
                {
                    result = result.Substring(0, 1) + result.Substring(1).ToLower();
                }
            }

            return result;
        }
    }
}