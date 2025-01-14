using System;

namespace Architect.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for the object data type
    /// </summary>
    public static class IntExtensions
    {
        public static bool IsEmpty(this int value)
        {
            return (value == 0);
        }

        public static bool IsNotEmpty(this int value)
        {
            return (value != 0);
        }

        public static int IfEmpty(this int value, int defaultValue)
        {
            if(value.IsEmpty())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        public static string DocumentType(this int value)
        {
            string type = value.ToString();

            switch (value)
            {
                case 1: //Cédula
                    type = "CNA";
                    break;

                case 2: //Residencia
                    type = "CRE";
                    break;

                case 4: //Cédula jurídica
                    type = "CJU";
                    break;

                case 3: //Pasaporte
                    type = "PAS";
                    break;

                    //DIDI
            }

            return type;

            
        }

    }
}
