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
    /// <summary>
    /// Provides extension methods for serialization and deserialization operations.
    /// Supports XML, JSON, and binary serialization with generic type-safe methods.
    /// </summary>
    public static class SerializeHandler
    {
        #region XML Serialization Extensions

        /// <summary>
        /// Serializes an object to XML string.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        /// <param name="current">The object to serialize.</param>
        /// <returns>XML string representation of the object.</returns>
        public static string Serialize<T>(this T current)
        {
            string serializedObj = null;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringWriterWithEncoding writer = new StringWriterWithEncoding(Encoding.UTF8))
            {
                serializer.Serialize(writer, current);
                serializedObj = writer.ToString();
            }
            return serializedObj;
        }

        /// <summary>
        /// Serializes an object to an XML file.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        /// <param name="current">The object to serialize.</param>
        /// <param name="fullFileName">The full path of the file to create.</param>
        public static void SerializeToFile<T>(this T current, string fullFileName)
        {
            current.SerializeToFile(fullFileName, false);
        }

        /// <summary>
        /// Serializes an object to an XML file with optional formatting.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        /// <param name="current">The object to serialize.</param>
        /// <param name="fullFileName">The full path of the file to create.</param>
        /// <param name="withFormat">If <c>true</c>, formats the XML output with indentation.</param>
        public static void SerializeToFile<T>(this T current, string fullFileName, bool withFormat)
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

        /// <summary>
        /// Deserializes an XML string to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize to.</typeparam>
        /// <param name="xmlDocument">The XML string to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public static T Deserialize<T>(this string xmlDocument)
        {
            using (StringReader vlcFileStream = new StringReader(xmlDocument))
            {
                XmlSerializer vloXmlSerializer = new XmlSerializer(typeof(T));
                T metadataItem = (T)vloXmlSerializer.Deserialize(vlcFileStream);
                return metadataItem;
            }
        }

        /// <summary>
        /// Deserializes an XML file to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize to.</typeparam>
        /// <param name="fullFileName">The full path of the file to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public static T DeserializeFromFile<T>(this string fullFileName)
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

        #endregion

        #region JSON Serialization Extensions

        /// <summary>
        /// Serializes an object to JSON and saves it to a file.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        /// <param name="current">The object to serialize.</param>
        /// <param name="fullFileName">The full path of the file to create.</param>
        /// <param name="withFormat">If <c>true</c>, formats the JSON output with indentation.</param>
        /// <param name="PreserveReferences">If <c>true</c>, preserves object references.</param>
        /// <param name="IgnoreNull">If <c>true</c>, ignores null values during serialization.</param>
        public static void SerializeJSONToFile<T>(this T current, string fullFileName, bool withFormat, bool PreserveReferences = true, bool IgnoreNull = false)
        {
            JsonSerializerSettings config = new JsonSerializerSettings
            {
            };

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

        /// <summary>
        /// Serializes an object to a JSON string.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        /// <param name="current">The object to serialize.</param>
        /// <param name="withFormat">If <c>true</c>, formats the JSON output with indentation.</param>
        /// <param name="PreserveReferences">If <c>true</c>, preserves object references.</param>
        /// <param name="IgnoreNull">If <c>true</c>, ignores null values during serialization.</param>
        /// <param name="typeNameHandling">Specifies how type names are handled during serialization.</param>
        /// <returns>JSON string representation of the object.</returns>
        public static string SerializeJSON<T>(this T current, bool withFormat, bool PreserveReferences = true, bool IgnoreNull = false, TypeNameHandling typeNameHandling = TypeNameHandling.All)
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

        /// <summary>
        /// Serializes an object to a JObject.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        /// <param name="item">The object to serialize.</param>
        /// <returns>A JObject representation of the object.</returns>
        public static JObject SerializeToJObject<T>(this T item)
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

        /// <summary>
        /// Serializes an object to a JSON string with array byte support.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        /// <param name="current">The object to serialize.</param>
        /// <param name="withFormat">If <c>true</c>, formats the JSON output with indentation.</param>
        /// <returns>JSON string representation of the object.</returns>
        public static string SerializeJSONToArrayBytes<T>(this T current, bool withFormat)
        {
            return JsonConvert.SerializeObject(current, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.All
            });
        }

        /// <summary>
        /// Deserializes a JSON file to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize to.</typeparam>
        /// <param name="fullFileName">The full path of the file to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public static T DeserializeJSONFromFile<T>(this string fullFileName)
        {
            return fullFileName.DeserializeJSONFromFile<T>("");
        }

        /// <summary>
        /// Deserializes a JSON file to an object of type <typeparamref name="T"/> with specified encoding.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize to.</typeparam>
        /// <param name="fullFileName">The full path of the file to deserialize.</param>
        /// <param name="encoding">The encoding to use when reading the file. Empty string uses default encoding.</param>
        /// <returns>The deserialized object.</returns>
        public static T DeserializeJSONFromFile<T>(this string fullFileName, string encoding = "")
        {
            string body = encoding.IsEmpty() ? System.IO.File.ReadAllText(fullFileName) : System.IO.File.ReadAllText(fullFileName, System.Text.Encoding.GetEncoding(encoding));
            body = body.Replace("Gears.Commons.Entity.SSH.ServerSSH", "Gears.Commons.Entity.SSH.SFTPServer");
            body = body.Replace("Gears.Commons.Entity.SSH.FileDownloadSSH", "Gears.Commons.Entity.SSH.SFTPFileDownload");
            body = body.Replace("Gears.Commons.Entity.SSH.CommandSSH", "Gears.Commons.Entity.SSH.SSHCommand");

            T result = JsonConvert.DeserializeObject<T>(body, new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii, PreserveReferencesHandling = PreserveReferencesHandling.Objects, TypeNameHandling = TypeNameHandling.All });
            return result;
        }

        /// <summary>
        /// Deserializes a JSON array bytes string to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize to.</typeparam>
        /// <param name="body">The JSON string to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public static T DeserializeJSONArrayBytes<T>(this string body)
        {
            T result = JsonConvert.DeserializeObject<T>(body, new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii, PreserveReferencesHandling = PreserveReferencesHandling.Objects, TypeNameHandling = TypeNameHandling.All });

            return result;
        }

        /// <summary>
        /// Deserializes a JSON string to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize to.</typeparam>
        /// <param name="body">The JSON string to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public static T DeserializeJSON<T>(this string body)
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

        /// <summary>
        /// Deserializes a JSON string to a JObject.
        /// </summary>
        /// <param name="body">The JSON string to deserialize.</param>
        /// <returns>A JObject representation of the JSON string.</returns>
        public static JObject DeserializeJSONByJObject(this string body)
        {
            JObject result = JObject.Parse(body);
            return result;
        }

        #endregion

        #region Binary Serialization Extensions

        /// <summary>
        /// Deserializes a binary file to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize to.</typeparam>
        /// <param name="fullFileName">The full path of the binary file to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public static T BinaryDeserializeFromFile<T>(this string fullFileName)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream fileStreamItem = new FileStream(fullFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            T metadataItem = (T)formatter.Deserialize(fileStreamItem);

            fileStreamItem.Close();
            fileStreamItem = null;

            return metadataItem;
        }

        /// <summary>
        /// Serializes an object to a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        /// <param name="current">The object to serialize.</param>
        /// <param name="fullFileName">The full path of the file to create.</param>
        public static void BinarySerializeToFile<T>(this T current, string fullFileName)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream writer = new FileStream(fullFileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(writer, current);
            writer.Close();
        }

        #endregion

        #region Utility Extensions

        /// <summary>
        /// Determines if an object is serializable.
        /// </summary>
        /// <param name="serializableObject">The object to check.</param>
        /// <returns><c>true</c> if the object is serializable; otherwise, <c>false</c>.</returns>
        public static bool IsSerializable(this object serializableObject)
        {
            Type typeObjec = serializableObject.GetType();
            return ((typeObjec is ISerializable) || (Attribute.IsDefined(typeObjec, typeof(SerializableAttribute))));
        }

        /// <summary>
        /// Serializes an object to an XML string.
        /// </summary>
        /// <param name="serializerObject">The object to serialize.</param>
        /// <returns>XML string representation of the object, or an error message if serialization fails.</returns>
        public static string SerializarObject(this object serializerObject)
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

        /// <summary>
        /// Creates a deep clone of an object using XML serialization.
        /// </summary>
        /// <typeparam name="T">The type of object to clone.</typeparam>
        /// <param name="currentObject">The object to clone.</param>
        /// <returns>A deep copy of the object.</returns>
        public static T Clone<T>(this T currentObject)
        {
            return currentObject.Serialize().Deserialize<T>();
        }

        #endregion
    }

    /// <summary>
    /// StringWriter implementation that supports custom encoding.
    /// </summary>
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