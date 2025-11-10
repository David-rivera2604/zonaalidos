using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using FastMember;
using Microsoft.VisualBasic.CompilerServices;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Architect.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for the object data type
    /// </summary>
    public static class ListExtensions
    {
        public static List<T> WithItems<T>(this List<T> list, List<T> items)
        {
            list.AddRange(items);
            return list;
        }

        public static DataTable ToTable<T>(this List<T> items)
        {
            var result = new DataTable();
            PropertyInfo[] properties = typeof(T).GetProperties();
            var accessor = TypeAccessor.Create(typeof(T));

            foreach (var itemProperty in properties)
                result.Columns.Add(itemProperty.Name, itemProperty.PropertyType);

            foreach (var item in items)
            {
                var row = result.NewRow();
                foreach (var itemProperty in properties)
                    row[itemProperty.Name] = accessor[item, itemProperty.Name];
                result.Rows.Add(row);
            }

            return result;
        }

        /// <summary>
        /// Defines whether a list is empty or contains elements within it/ Define si una lista es empty or no contiene elementos dentro de ella
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsEmptyAndNotContainsItems<T>(this List<T> source)
        {
            bool result = false;
            if (source == null)
            {
                return true;
            }
            if (!(source.Count != 0))
            {
                return true;
            }
            return result;
        }

        /// <summary>
        /// Creates a string separated by the character indicated property values that difinio/Crea un string separado por el carácter que se indique de  los valores de la propiedad que se difinio
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string CreateConcatenation<T>(this List<T> source, string separator, string propertyName)
        {
            string result = string.Empty;
            if (!(source == null) && source.Count != 0)
            {
                object temporalObject = source.FirstOrDefault();
                if (!(temporalObject == null))
                {
                    bool isExistProperty = temporalObject.ExistsProperty(propertyName);
                    if (isExistProperty)
                    {
                        var listaVector = new List<string>();
                        foreach (var ItemSource in source)
                            listaVector.Add(Conversions.ToString(ItemSource.GetType().GetProperty(propertyName).GetValue(ItemSource, null)));
                        if (!listaVector.IsEmptyAndNotContainsItems())
                        {
                            result = string.Join(separator, listaVector);
                        }
                    }
                }
            }
            return result;
        }
    }
}