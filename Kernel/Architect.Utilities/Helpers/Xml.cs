using System;

namespace Architect.Utilities.Helpers
{
    public static class Xml
    {
        public static Type MapXmlTypeToType(string xmlType)
        {
            xmlType = xmlType.ToLower();
            if (xmlType == "string")
            {
                return typeof(string);
            }
            if (xmlType == "integer")
            {
                return typeof(int);
            }
            if (xmlType == "long")
            {
                return typeof(long);
            }
            if (xmlType == "boolean")
            {
                return typeof(bool);
            }
            if (xmlType == "datetime")
            {
                return typeof(DateTime);
            }
            if (xmlType == "float")
            {
                return typeof(float);
            }
            if (xmlType == "decimal")
            {
                return typeof(decimal);
            }
            if (xmlType == "double")
            {
                return typeof(double);
            }
            if (xmlType == "single")
            {
                return typeof(float);
            }
            if (xmlType == "byte")
            {
                return typeof(byte);
            }
            if (xmlType == "base64binary")
            {
                return typeof(byte[]);
            }
            return null;
        }
    }
}