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

        public static JObject FindDiff(this JToken Current, JToken Model)
        {
            var diff = new JObject();
            if (JToken.DeepEquals(Current, Model)) return diff;

            switch (Current.Type)
            {
                case JTokenType.Object:
                    {
                        var current = Current as JObject;
                        var model = Model as JObject;
                        var addedKeys = current.Properties().Select(c => c.Name).Except(model.Properties().Select(c => c.Name));
                        var removedKeys = model.Properties().Select(c => c.Name).Except(current.Properties().Select(c => c.Name));
                        var unchangedKeys = current.Properties().Where(c => JToken.DeepEquals(c.Value, Model[c.Name])).Select(c => c.Name);
                        foreach (var k in addedKeys)
                        {
                            diff[k] = new JObject
                            {
                                ["+"] = Current[k]
                            };
                        }
                        foreach (var k in removedKeys)
                        {
                            diff[k] = new JObject
                            {
                                ["-"] = Model[k]
                            };
                        }
                        var potentiallyModifiedKeys = current.Properties().Select(c => c.Name).Except(addedKeys).Except(unchangedKeys);
                        foreach (var k in potentiallyModifiedKeys)
                        {
                            var foundDiff = FindDiff(current[k], model[k]);
                            if (foundDiff.HasValues) diff[k] = foundDiff;
                        }
                    }
                    break;
                case JTokenType.Array:
                    {
                        var current = Current as JArray;
                        var model = Model as JArray;
                        var plus = new JArray(current.Except(model, new JTokenEqualityComparer()));
                        var minus = new JArray(model.Except(current, new JTokenEqualityComparer()));
                        if (plus.HasValues) diff["+"] = plus;
                        if (minus.HasValues) diff["-"] = minus;
                    }
                    break;
                default:
                    diff["+"] = Current;
                    diff["-"] = Model;
                    break;
            }

            return diff;
        }
    }
}
