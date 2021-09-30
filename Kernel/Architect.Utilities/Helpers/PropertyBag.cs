using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Architect.Utilities.Helpers
{
    /// <summary>
    /// Creates a serializable string/object dictionary that is XML serializable
    /// Encodes keys as element names and values as simple values with a type
    /// attribute that contains an XML type name. Complex names encode the type
    /// name with type='___namespace.classname' format followed by a standard xml
    /// serialized format. The latter serialization can be slow so it's not recommended
    /// to pass complex types if performance is critical.
    /// </summary>
    // Token: 0x0200000B RID: 11
    [XmlRoot("properties")]
    public class PropertyBag : PropertyBag<object>
    {
        /// <summary>
        /// Creates an instance of a propertybag from an Xml string
        /// </summary>
        /// <param name="xml">Serialize</param>
        /// <returns></returns>
        // Token: 0x0600005F RID: 95 RVA: 0x00003734 File Offset: 0x00001934
        public new static PropertyBag CreateFromXml(string xml)
        {
            PropertyBag bag = new PropertyBag();
            //bag.FromXml(xml);
            return bag;
        }
    }

    /// <summary>
    /// Creates a serializable string for generic types that is XML serializable.
    ///
    /// Encodes keys as element names and values as simple values with a type
    /// attribute that contains an XML type name. Complex names encode the type
    /// name with type='___namespace.classname' format followed by a standard xml
    /// serialized format. The latter serialization can be slow so it's not recommended
    /// to pass complex types if performance is critical.
    /// </summary>
    /// <typeparam name="TValue">Must be a reference type. For value types use type object</typeparam>
    // Token: 0x0200000C RID: 12
    [XmlRoot("properties")]
    public class PropertyBag<TValue> : Dictionary<string, TValue>, IXmlSerializable
    {
        /// <summary>
        /// Not implemented - this means no schema information is passed
        /// so this won't work with ASMX/WCF services.
        /// </summary>
        /// <returns></returns>
        // Token: 0x06000061 RID: 97 RVA: 0x00003758 File Offset: 0x00001958
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Serializes the dictionary to XML. Keys are
        /// serialized to element names and values as
        /// element values. An xml type attribute is embedded
        /// for each serialized element - a .NET type
        /// element is embedded for each complex type and
        /// prefixed with three underscores.
        /// </summary>
        /// <param name="writer"></param>
        // Token: 0x06000062 RID: 98 RVA: 0x0000375C File Offset: 0x0000195C
        public void WriteXml(XmlWriter writer)
        {
            foreach (string key in base.Keys)
            {
                TValue value = base[key];
                Type type = null;
                if (value != null)
                {
                    type = value.GetType();
                }
                writer.WriteStartElement("item");
                writer.WriteStartElement("key");
                writer.WriteString(key);
                writer.WriteEndElement();
                writer.WriteStartElement("value");
                string xmlType =(new Assembly()).MapTypeToXmlType(type);
                bool isCustom = false;
                if (value == null)
                {
                    writer.WriteAttributeString("type", "nil");
                }
                else if (!string.IsNullOrEmpty(xmlType))
                {
                    if (xmlType != "string")
                    {
                        writer.WriteStartAttribute("type");
                        writer.WriteString(xmlType);
                        writer.WriteEndAttribute();
                    }
                }
                else
                {
                    isCustom = true;
                    xmlType = "___" + value.GetType().FullName;
                    writer.WriteStartAttribute("type");
                    writer.WriteString(xmlType);
                    writer.WriteEndAttribute();
                }
                if (!isCustom)
                {
                    if (value != null)
                    {
                        writer.WriteValue(value);
                    }
                }
                else
                {
                    XmlSerializer ser = new XmlSerializer(value.GetType());
                    ser.Serialize(writer, value);
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }

        /// <summary>
        /// Reads the custom serialized format
        /// </summary>
        /// <param name="reader"></param>
        // Token: 0x06000063 RID: 99 RVA: 0x000038E4 File Offset: 0x00001AE4
        public void ReadXml(XmlReader reader)
        {
            base.Clear();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "key")
                {
                    string xmlType = null;
                    string name = reader.ReadElementContentAsString();
                    reader.ReadToNextSibling("value");
                    if (reader.MoveToNextAttribute())
                    {
                        xmlType = reader.Value;
                    }
                    if (string.IsNullOrEmpty(xmlType))
                    {
                        xmlType = "string";
                    }
                    reader.MoveToContent();
                    string strval = string.Empty;
                    TValue value;
                    if (xmlType == "nil")
                    {
                        value = default(TValue);
                    }
                    else if (xmlType.StartsWith("___"))
                    {
                        while (reader.Read() && reader.NodeType != XmlNodeType.Element)
                        {
                        }
                        Type type = (new Assembly()).GetTypeFromName(xmlType.Substring(3));
                        XmlSerializer ser = new XmlSerializer(type);
                        value = (TValue)((object)ser.Deserialize(reader));
                    }
                    else
                    {
                        value = (TValue)((object)reader.ReadElementContentAs(Xml.MapXmlTypeToType(xmlType), null));
                    }
                    base.Add(name, value);
                }
            }
        }


        ///// <summary>
        ///// Serializes this dictionary to an XML string
        ///// </summary>
        ///// <returns>XML String or Null if it fails</returns>
        //// Token: 0x06000064 RID: 100 RVA: 0x000039E0 File Offset: 0x00001BE0
        //public string ToXml()
        //{
        //    string xml = null;
        //    SerializationUtils.SerializeObject(this, out xml);
        //    return xml;
        //}

        ///// <summary>
        ///// Deserializes from an XML string
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns>true or false</returns>
        //// Token: 0x06000065 RID: 101 RVA: 0x000039FC File Offset: 0x00001BFC
        //public bool FromXml(string xml)
        //{
        //    base.Clear();
        //    if (string.IsNullOrEmpty(xml))
        //    {
        //        return true;
        //    }
        //    PropertyBag<TValue> result = SerializationUtils.DeSerializeObject(xml, base.GetType()) as PropertyBag<TValue>;
        //    if (result != null)
        //    {
        //        using (Dictionary<string, TValue>.Enumerator enumerator = result.GetEnumerator())
        //        {
        //            while (enumerator.MoveNext())
        //            {
        //                KeyValuePair<string, TValue> item = enumerator.Current;
        //                base.Add(item.Key, item.Value);
        //            }
        //            return true;
        //        }
        //        return false;
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Creates an instance of a propertybag from an Xml string
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //// Token: 0x06000066 RID: 102 RVA: 0x00003A80 File Offset: 0x00001C80
        //public static PropertyBag<TValue> CreateFromXml(string xml)
        //{
        //    PropertyBag<TValue> bag = new PropertyBag<TValue>();
        //    bag.FromXml(xml);
        //    return bag;
        //}
    }
}
