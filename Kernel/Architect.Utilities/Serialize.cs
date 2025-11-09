using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Architect.Utilities
{
    public static class SerializeHandler<T>
    {
        public static string Serialize(T current)
        {
            return Serialize(current, false);
        }

        public static string Serialize(T current, bool withFormat)
        {
            string serializedObj = null;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringWriterWithEncoding writer = new StringWriterWithEncoding(Encoding.UTF8))
            {
                if (withFormat)
                {
                    XmlWriterSettings settings = new XmlWriterSettings
                    {
                        Indent = true,
                        IndentChars = "  ",
                        Encoding = Encoding.UTF8
                    };
                    using (XmlWriter xmlWriter = XmlWriter.Create(writer, settings))
                    {
                        serializer.Serialize(xmlWriter, current);
                    }
                }
                else
                {
                    serializer.Serialize(writer, current);
                }
                serializedObj = writer.ToString();
            }
            return serializedObj;
        }

        public static void SerializeToFile(T current, string fullFileName)
        {
            SerializeToFile(current, fullFileName, false);
        }

        public static void SerializeJSONToFile(T current, string fullFileName, bool withFormat, bool PreserveReferences = true, bool IgnoreNull = false)
        {
            JsonSerializerSettings config = new JsonSerializerSettings
            {
            };

            //TypeNameHandling = TypeNameHandling.All,
            //    StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            if (IgnoreNull)
            {
                config.NullValueHandling = NullValueHandling.Ignore;
            }
            if (PreserveReferences)
            {
                config.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                config.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }
            config.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            string body = JsonConvert.SerializeObject(current, Newtonsoft.Json.Formatting.Indented, config);
            System.IO.File.WriteAllText(fullFileName, body, Encoding.UTF8);
        }

        public static string SerializeJSON(T current, bool withFormat, bool PreserveReferences = true, bool IgnoreNull = false, TypeNameHandling typeNameHandling = TypeNameHandling.All)
        {
            var config = new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                TypeNameHandling = TypeNameHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            if (IgnoreNull)
            {
                config.NullValueHandling = NullValueHandling.Ignore;
            }

            var varIdented = Newtonsoft.Json.Formatting.Indented;
            if (!withFormat)
            {
                config.Formatting = Newtonsoft.Json.Formatting.None;
                varIdented = Newtonsoft.Json.Formatting.None;
            }
            else
            {
                varIdented = Newtonsoft.Json.Formatting.Indented;
            }

            if (typeNameHandling != TypeNameHandling.All)
            {
                config.TypeNameHandling = typeNameHandling;
                config.PreserveReferencesHandling = PreserveReferencesHandling.None;
            }

            return JsonConvert.SerializeObject(current, varIdented, config);
        }

        public static JObject SerializeToJObject(T item)
        {
            JObject data = JObject.FromObject(item,
                                               new JsonSerializer
                                               {
                                                   PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                                                   ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                                   StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                                                   TypeNameHandling = TypeNameHandling.All
                                               });
            return data;
        }

        public static string SerializeJSONToArrayBytes(T current, bool withFormat)
        {
            return JsonConvert.SerializeObject(current, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public static T DeserializeJSONFromFile(string fullFileName)
        {
            return DeserializeJSONFromFile(fullFileName, "");
        }

        public static T DeserializeJSONFromFile(string fullFileName, string encoding = "")
        {
            string body = encoding.IsEmpty() ? System.IO.File.ReadAllText(fullFileName) : System.IO.File.ReadAllText(fullFileName, System.Text.Encoding.GetEncoding(encoding));
            body = body.Replace("Gears.Commons.Entity.SSH.ServerSSH", "Gears.Commons.Entity.SSH.SFTPServer");
            body = body.Replace("Gears.Commons.Entity.SSH.FileDownloadSSH", "Gears.Commons.Entity.SSH.SFTPFileDownload");
            body = body.Replace("Gears.Commons.Entity.SSH.CommandSSH", "Gears.Commons.Entity.SSH.SSHCommand");

            T result = JsonConvert.DeserializeObject<T>(body, new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii, PreserveReferencesHandling = PreserveReferencesHandling.Objects, TypeNameHandling = TypeNameHandling.All });
            return result;
        }

        public static T DeserializeJSONArrayBytes(string body)
        {
            T result = JsonConvert.DeserializeObject<T>(body, new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii, PreserveReferencesHandling = PreserveReferencesHandling.Objects, TypeNameHandling = TypeNameHandling.All });

            return result;
        }

        public static T DeserializeJSON(string body)
        {
            body = body.Replace("CubeCode.AppFactory.Entity.Entities.UI.Tab", "CubeCode.AppFactory.Entity.Entities.UI.Layout.Tab");
            T result = JsonConvert.DeserializeObject<T>(body, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                TypeNameHandling = TypeNameHandling.All,
                Error = (sender, ErrorEventArgs) =>
                {
                    var rrrr = sender;
                    var rm = ErrorEventArgs;
                }
            });

            return result;
        }

        public static JObject DeserializeJSONByJObject(string body)
        {
            JObject result = JObject.Parse(body);
            return result;
        }

        public static void SerializeToFile(T current, string fullFileName, bool withFormat)
        {
            XmlSerializer xmlSerialiazerItem = new XmlSerializer(typeof(T));
            FileStream fileStreamItem = new FileStream(fullFileName, FileMode.Create);
            XmlTextWriter xmlTextWriterItem = new XmlTextWriter(fileStreamItem, Encoding.UTF8);

            if (withFormat)
            {
                var _with1 = xmlTextWriterItem;
                _with1.Formatting = System.Xml.Formatting.Indented;
                _with1.Indentation = 2;
                _with1.IndentChar = ' ';
            }
            xmlSerialiazerItem.Serialize(xmlTextWriterItem, current);
            xmlTextWriterItem.Close();
            fileStreamItem.Close();
            fileStreamItem = null;
        }

        public static bool IsSerializable(object serializableObject)
        {
            Type typeObjec = serializableObject.GetType();
            return ((typeObjec is ISerializable) || (Attribute.IsDefined(typeObjec, typeof(SerializableAttribute))));
        }

        public static string SerializarObject(object serializerObject)
        {
            StringBuilder result = new StringBuilder(string.Empty);
            try
            {
                using (StringWriter writer = new StringWriter(result))
                {
                    XmlSerializer xs = new XmlSerializer(serializerObject.GetType());
                    xs.Serialize(writer, serializerObject);
                }
            }
            catch (Exception ex)
            {
                result.AppendLine(string.Format("This object type '{0}' can not by serialized. {1}", serializerObject.GetType(), ex.Message));
            }
            return result.ToString();
        }

        public static T Deserialize(string xmlDocument)
        {
            using (StringReader vlcFileStream = new StringReader(xmlDocument))
            {
                XmlSerializer vloXmlSerializer = new XmlSerializer(typeof(T));
                T metadataItem = (T)vloXmlSerializer.Deserialize(vlcFileStream);
                return metadataItem;
            }
        }

        public static T DeserializeFromFile(string fullFileName)
        {
            XmlSerializer xmlSerialiazerItem = new XmlSerializer(typeof(T));
            FileStream fileStreamItem = new FileStream(fullFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlTextReader xmlTextReaderItem = new XmlTextReader(fileStreamItem);
            T metadataItem = (T)xmlSerialiazerItem.Deserialize(xmlTextReaderItem);

            xmlTextReaderItem.Close();
            fileStreamItem.Close();
            fileStreamItem = null;

            return metadataItem;
        }

        public static T BinaryDeserializeFromFile(string fullFileName)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream fileStreamItem = new FileStream(fullFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            T metadataItem = (T)formatter.Deserialize(fileStreamItem);

            fileStreamItem.Close();
            fileStreamItem = null;

            return metadataItem;
        }

        public static void BinarySerializeToFile(T current, string fullFileName)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream writer = new FileStream(fullFileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(writer, current);
            writer.Close();
        }

        public static T Clone(T currentObject)
        {
            return Deserialize(Serialize(currentObject));
        }
    }

    internal class StringWriterWithEncoding : StringWriter
    {
        private readonly Encoding _encoding;

        public StringWriterWithEncoding()
        {
        }

        public StringWriterWithEncoding(IFormatProvider formatProvider) : base(formatProvider)
        {
        }

        public StringWriterWithEncoding(StringBuilder sb) : base(sb)
        {
        }

        public StringWriterWithEncoding(StringBuilder sb, IFormatProvider formatProvider) : base(sb, formatProvider)
        {
        }

        public StringWriterWithEncoding(Encoding encoding)
        {
            _encoding = encoding;
        }

        public StringWriterWithEncoding(IFormatProvider formatProvider, Encoding encoding) : base(formatProvider)
        {
            _encoding = encoding;
        }

        public StringWriterWithEncoding(StringBuilder sb, Encoding encoding) : base(sb)
        {
            _encoding = encoding;
        }

        public StringWriterWithEncoding(StringBuilder sb, IFormatProvider formatProvider, Encoding encoding) : base(sb, formatProvider)
        {
            _encoding = encoding;
        }

        public override Encoding Encoding
        {
            get { return (_encoding == null) ? base.Encoding : _encoding; }
        }
    }
}