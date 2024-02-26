using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Utilities.Extensions
{
    public static class JObjectExtensions
    {

        public static string TokenStringValue(this JObject instance, string path, string defaultValue = "")
        {
            string result = defaultValue;
            JToken jvalue = instance.SelectToken(path);
            if (jvalue != null )
            {
                result = jvalue.Value<string>();
            }
            return result;
        }


        public static Int32 TokenInt32Value(this JObject instance, string path, Int32 defaultValue = 0)
        {
            Int32 result = defaultValue;
            JToken jvalue = instance.SelectToken(path);
            if (jvalue != null )
            {
                result = jvalue.Value<Int32>();
            }
            return result;
        }
        public static double TokenDoubleValue(this JObject instance, string path, double defaultValue = 0)
        {
            double result = defaultValue;
            JToken jvalue = instance.SelectToken(path);
            if (jvalue != null)
            {
                result = jvalue.Value<double>();
            }
            return result;
        }
        public static DateTime TokenDateTimeValue(this JObject instance, string path)
        {
            return TokenDateTimeValue(instance, path, DateTime.MinValue);
        }
        public static DateTime TokenDateTimeValue(this JObject instance, string path, DateTime defaultValue)
        {
            DateTime result = defaultValue;
            JToken jvalue = instance.SelectToken(path);
            if (jvalue != null )
            {
                result = jvalue.Value<DateTime>();
            }
            return result;
        }
        public static bool TokenBoolValue(this JObject instance, string path, bool defaultValue =false)
        {
            bool result = defaultValue;
            JToken jvalue = instance.SelectToken(path);
            if (jvalue != null)
            {
                result = jvalue.Value<bool>();
            }
            return result;
        }
    }
}
