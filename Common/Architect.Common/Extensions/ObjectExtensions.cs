using System;
using Microsoft.VisualBasic;

namespace Architect.Common.Extensions
{

    /// <summary>
    /// Extension methods for the object data type
    /// </summary>
    public static class ObjectExtensions
    {

        /// <summary>
        /// Este método permite realizar una clonación completa por medio de memberwiseclone
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T CloneObject<T>(this T source) where T : class
        {
            if (source is null)
            {
                return null;
            }

            var inst = source.GetType().GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (inst is object)
            {
                T result = (T)inst.Invoke(source, null);
                CloneObjectBase(source, result);
                return result;
            }
            else
            {
                return null;
            }
        }

        private static void CloneObjectBase<T>(T source, T result) where T : class
        {
            foreach (System.Reflection.PropertyInfo itemPropertyes in source.GetType().GetProperties())
            {
                if (IsNotCoreType(itemPropertyes.PropertyType))
                {
                    var instanceObjectFromBase = GetPropValue(source, itemPropertyes.Name);
                    var inntanceObjectCloned = CloneInternal(instanceObjectFromBase);
                    if (result.IsNotEmpty())
                    {
                        var propertyResult = result.GetType().GetProperty(itemPropertyes.Name);
                        if (propertyResult.IsNotEmpty())
                        {
                            propertyResult.SetValue(result, Convert.ChangeType(inntanceObjectCloned, propertyResult.PropertyType), null);
                        }
                    }

                    CloneObjectBase(instanceObjectFromBase, inntanceObjectCloned);
                }
            }
        }

        private static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        private static T CloneInternal<T>(T source) where T : class
        {
            if (source is null)
            {
                return null;
            }

            var inst = source.GetType().GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (inst is object)
            {
                T result = (T)inst.Invoke(source, null);
                return result;
            }
            else
            {
                return null;
            }
        }

        public static bool IsNotCoreType(Type type)
        {
            return type != typeof(object) && Type.GetTypeCode(type) == TypeCode.Object;
        }

        public static bool IsEmpty(this object value)
        {
            return Information.IsNothing(value);
        }

        public static bool IsNotEmpty(this object value)
        {
            return !Information.IsNothing(value);
        }

        /// <summary>
        /// Checks whether the property in the object/ Verifica si existe la propiedad en el objeto
        /// </summary>
        /// <param name="srcObject"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool ExistsProperty(this object srcObject, string propertyName)
        {
            if (srcObject is null)
            {
                throw new ArgumentNullException("srcObject");
            }

            if (propertyName is null || (propertyName ?? "") == (string.Empty ?? "") || propertyName.Length == 0)
            {
                throw new ArgumentException("Property name cannot be empty or null.");
            }

            var propInfoSrcObj = srcObject.GetType().GetProperty(propertyName);
            return propInfoSrcObj is object;
        }

        public static Type GetTypeProperty(this object srcObject, string propertyName)
        {
            if (srcObject is null)
            {
                throw new ArgumentNullException("srcObject");
            }

            if (propertyName is null || (propertyName ?? "") == (string.Empty ?? "") || propertyName.Length == 0)
            {
                throw new ArgumentException("Property name cannot be empty or null.");
            }

            var propInfoSrcObj = srcObject.GetType().GetProperty(propertyName);
            return propInfoSrcObj.PropertyType;
        }
    }
}