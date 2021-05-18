using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Architect.Common.Helpers
{

    // Dim dcs As New DataContractSerializer(GetType(Contract.IndividualRisk))
    // Dim writer As New MemoryStream
    // Dim xdw As XmlDictionaryWriter = _
    // XmlDictionaryWriter.CreateTextWriter(writer, Encoding.UTF8)
    // dcs.WriteObject(xdw, risk)
    // writer.Flush()

    // writer.Position = 0
    // Dim xx As String = UTF8Encoding.UTF8.GetString(writer.ToArray())
    // Dim reader As New StreamReader(writer)
    // Dim str = reader.ReadToEnd()

    // 'Dim x As String = writer.Read
    // 'http://msdn.microsoft.com/en-us/library/ms731073.aspx

    public sealed class Serialize
    {
        private Serialize() : base()
        {
        }

        public static T DeserializeJSON<T>(string body)
        {
            T result;
            result = JsonConvert.DeserializeObject<T>(body, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                TypeNameHandling = TypeNameHandling.All
            });
            return result;
        }

        public static string Serialize<T>(T current)
        {
            string serializedObj;
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StringWriterWithEncoding(Encoding.UTF8))
            {
                serializer.Serialize(writer, current);
                serializedObj = writer.ToString();
                return serializedObj;
            }
        }

        public static void SerializeToFile<T>(T current, string fullFileName)
        {
            SerializeToFile(current, fullFileName, false);
        }

        public static bool IsSerializable(object serializableObject)
        {
            var typeObjec = serializableObject.GetType();
            return typeObjec is ISerializable || Attribute.IsDefined(typeObjec, typeof(SerializableAttribute));
        }

        public static string SerializarObject(object serializerObject)
        {
            var result = new StringBuilder(string.Empty);
            try
            {
                using (var writer = new StringWriter(result))
                {
                    var xs = new XmlSerializer(serializerObject.GetType());
                    xs.Serialize(writer, serializerObject);
                }
            }
            catch (Exception ex)
            {
                result.AppendLine(string.Format("This object type '{0}' can not by serialized", serializerObject.GetType()));
            }

            return result.ToString();
        }

        public static void SerializeToFile<T>(T current, string fullFileName, bool withFormat)
        {
            var xmlSerialiazerItem = new XmlSerializer(typeof(T));
            var fileStreamItem = new FileStream(fullFileName, FileMode.Create);
            var xmlTextWriterItem = new XmlTextWriter(fileStreamItem, Encoding.UTF8);
            if (withFormat)
            {
                xmlTextWriterItem.Formatting = System.Xml.Formatting.Indented;
                xmlTextWriterItem.Indentation = 2;
                xmlTextWriterItem.IndentChar = ' ';
            }

            xmlSerialiazerItem.Serialize(xmlTextWriterItem, current);
            xmlTextWriterItem.Close();
            fileStreamItem.Close();
            fileStreamItem = null;
        }

        public static T Deserialize<T>(string xmlDocument)
        {
            using (var vlcFileStream = new StringReader(xmlDocument))
            {
                var vloXmlSerializer = new XmlSerializer(typeof(T));
                T metadataItem = (T)vloXmlSerializer.Deserialize(vlcFileStream);
                return metadataItem;
            }
        }

        public static T DeserializeFromFile<T>(string fullFileName)
        {
            var xmlSerialiazerItem = new XmlSerializer(typeof(T));
            var fileStreamItem = new FileStream(fullFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            var xmlTextReaderItem = new XmlTextReader(fileStreamItem);
            T metadataItem = (T)xmlSerialiazerItem.Deserialize(xmlTextReaderItem);
            xmlTextReaderItem.Close();
            fileStreamItem.Close();
            fileStreamItem = null;
            return metadataItem;
        }

        public static T BinaryDeserializeFromFile<T>(string fullFileName)
        {
            IFormatter formatter = new BinaryFormatter();
            var fileStreamItem = new FileStream(fullFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            T metadataItem = (T)formatter.Deserialize(fileStreamItem);
            fileStreamItem.Close();
            fileStreamItem = null;
            return metadataItem;
        }

        public static void BinarySerializeToFile<T>(T current, string fullFileName)
        {
            IFormatter formatter = new BinaryFormatter();
            var writer = new FileStream(fullFileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(writer, current);
            writer.Close();
        }

        public static void DataContractSerializeToFile<T>(T current, string fullFileName)
        {
            var writer = new FileStream(fullFileName, FileMode.Create);
            var ser = new DataContractSerializer(typeof(T));
            ser.WriteObject(writer, current);
            writer.Close();
        }

        public static T DataContractDeserializeFromFile<T>(string fullFileName)
        {
            var fs = new FileStream(fullFileName, FileMode.OpenOrCreate);
            var ser = new DataContractSerializer(typeof(T));
            T metadataItem = (T)ser.ReadObject(fs);
            fs.Close();
            return metadataItem;
        }

        public static T Clone<T>(T currentObject)
        {
            return Deserialize<T>(Serialize(currentObject));
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
            get
            {
                return _encoding is null ? base.Encoding : _encoding;
            }
        }
    }
}