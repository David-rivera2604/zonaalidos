using System;
using System.Data;
using System.IO;
using System.Xml.Linq;

namespace Architect.Utilities.Extensions
{
    /// Extension methods for the DataReader type
    /// </summary>
    public static class DataReaderExtensions
    {

        public static T Field<T>(this IDataReader row, string columnName, T defaultValue)
        {
            if (row.IsNotNull(columnName))
            {
                return (T)Convert.ChangeType(row[columnName], typeof(T)) ;
            }
            else
            {
                return defaultValue;
            }
        }

        public static string FileContent(this IDataReader value, string name, string path, string filename, string extension)
        {
            string result = string.Empty;
            if (value.IsNotNull(name))
            {
                string localfilename = path;
                if (filename.IsEmpty())
                {
                    localfilename += @"\" + Guid.NewGuid().ToString();
                }
                else
                {
                    localfilename += @"\" + filename;
                }

                if (extension.StartsWith("."))
                {
                    localfilename += extension;
                }
                else
                {
                    localfilename += "." + extension;
                }

                localfilename = localfilename.Replace(@"\\", @"\");
                using (var FS = new FileStream(localfilename, FileMode.Create))
                {
                    byte[] blob = (byte[])value[name];
                    FS.Write(blob, 0, blob.Length);
                    FS.Close();
                }

                result = localfilename;
            }

            return result;
        }

        public static decimal NumericValue(this IDataReader value, string name)
        {
            return value.Field<decimal>(name, (decimal)0);
        }

        public static int IntegerValue(this IDataReader value, string name)
        {
            return value.Field<int>(name, 0);
        }

        public static Int64 Integer64Value(this IDataReader value, string name)
        {
            return value.Field<Int64>(name, 0);
        }

        public static byte ByteValue(this IDataReader value, string name)
        {
            return value.Field<byte>(name, 0);
        }
        public static byte[] ByteArrayValue(this IDataReader value, string name)
        {
            return value.Field<byte[]>(name, null);
        }

        public static double DoubleValue(this IDataReader value, string name)
        {
            return value.Field<double>(name, 0D);
        }

        public static DateTime DateTimeValue(this IDataReader value, string name)
        {
            return value.Field<DateTime>(name, DateTime.MinValue);
        }

        public static object DateTimeValueWithFormatDefault(this IDataReader value, string name, string format, object defaultValue)
        {
            var result = defaultValue;
            if (value.IsNotNull(name))
            {
                var @internal = value.DateTimeValue(name);
                if (format.IsNotEmpty())
                {
                    result = @internal.ToString(format);
                }
                else
                {
                    result = @internal;
                }
            }

            return result;
        }

        public static bool BooleanValue(this IDataReader value, string name)
        {
            return value.Field<bool>(name, false);
        }

        public static bool BooleanCharValue(this IDataReader value, string name)
        {
            return (value.StringValue(name) == "1");
        }

        public static string StringValue(this IDataReader value, string name)
        {
            return value.Field<string>(name, string.Empty).Trim();
        }

        public static Guid GuidValue(this IDataReader value, string name)
        {
            return value.Field<Guid>(name, Guid.NewGuid());
        }

        public static XDocument XmlValue(this IDataReader value, string name)
        {
            var result = new XDocument();
            if (value.IsNotNull(name))
            {
                result = XDocument.Parse(value.StringValue(name));
            }

            return result;
        }

        public static bool SwitchValue(this IDataReader value, string name)
        {
            return value.Field<bool>(name, false);
        }

        public static bool SwitchCharValue(this IDataReader value, string name)
        {
            return (value.StringValue(name) == "1");
        }


        public static bool IsNotNull(this IDataReader value, string name)
        {
            return (value[name] != null && !value.IsDBNull(value.GetOrdinal(name)));
        }
    }
}
