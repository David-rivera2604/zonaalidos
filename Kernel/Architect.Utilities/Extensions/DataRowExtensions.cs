using Microsoft.VisualBasic;
using System;
using System.Data;
using System.IO;
using System.Xml.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Architect.Utilities.Extensions
{
    /// Extension methods for the DataRow type
    /// </summary>
    public static class DataRowExtensions
    {
        public static T Field<T>(this DataRow row, string columnName, T defaultValue)
        {
            if (row.IsNotNull(columnName))
            {
                return row.Field<T>(columnName);
            }
            else
            {
                return defaultValue;
            }
        }

        public static string FileContent(this DataRow value, string name, string path, string filename, string extension)
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

        public static decimal NumericValue(this DataRow value, string name)
        {
            return value.Field<decimal>(name, 0D);
        }

        public static int IntegerValue(this DataRow value, string name)
        {
            return value.Field<int>(name, 0);
        }

        public static byte ByteValue(this DataRow value, string name)
        {
            return value.Field<byte>(name, 0);
        }

        public static byte[] ByteArrayValue(this DataRow value, string name)
        {
            return value.Field<byte[]>(name, null);
        }

        public static double DoubleValue(this DataRow value, string name)
        {
            return value.Field<double>(name, 0D);
        }

        public static DateTime DateTimeValue(this DataRow value, string name)
        {
            return value.Field<DateTime>(name, DateTime.MinValue);
        }

        public static object DateTimeValueWithFormatDefault(this DataRow value, string name, string format, object defaultValue)
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

        public static bool BooleanValue(this DataRow value, string name)
        {
            return value.Field<bool>(name, false);
        }

        public static bool BooleanCharValue(this DataRow value, string name)
        {
            return (value.StringValue(name) == "1");
        }

        public static string StringValue(this DataRow value, string name)
        {
            return value.Field<string>(name, string.Empty).Trim();
        }

        public static Guid GuidValue(this DataRow value, string name)
        {
            return value.Field<Guid>(name, Guid.NewGuid());
        }

        public static XDocument XmlValue(this DataRow value, string name)
        {
            var result = new XDocument();
            if (value.IsNotNull(name))
            {
                result = XDocument.Parse(value.StringValue(name));
            }

            return result;
        }

        public static bool SwitchValue(this DataRow value, string name)
        {
            return value.Field<bool>(name, false);
        }

        public static bool SwitchCharValue(this DataRow value, string name)
        {
            return (value.StringValue(name) == "1");
        }

        public static bool IsNotNull(this DataRow value, string name)
        {
            return (value[name] != null && !value.IsNull(name));
        }

        public static object NumericValueWithFormatDefault(this DataRow value, string name, string format, object defaultValue, ref bool specified)
        {
            var result = defaultValue;
            if (value.IsNotNull(name))
            {
                decimal @internal = value.NumericValue(name);
                if (format.IsNotEmpty())
                {
                    result = @internal.ToString(format, new System.Globalization.CultureInfo("en-US", false));
                }
                else
                {
                    result = @internal;
                }
                specified = true;
            }
            else
            {
                specified = false;
            }

            return result;
        }

        public static string StringValueWithDefault(this DataRow value, string name, object defaultValue, ref bool specified)
        {
            string result = Conversions.ToString(defaultValue);
            if (value.IsNotNull(name))
            {
                result = value.StringValue(name);
                specified = true;
            }
            else
            {
                specified = false;
            }

            return result;
        }

        public static T EnumValue<T>(this DataRow value, string name, T enumType, ref bool specified, ref bool witherror)
        {
            T result = default;

            if (value.IsNotNull(name))
            {
                try
                {
                    result = Conversions.ToGenericParameter<T>(Enum.Parse(enumType.GetType(), Conversions.ToString(value[name])));
                    specified = true;
                }
                catch (ArgumentException ex)
                {
                    result = default;
                    specified = false;
                    witherror = true;
                }
            }
            else
            {
                result = default;
                specified = false;
            }
            return result;
        }
    }
}
