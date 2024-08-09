using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Backoffice.Emision
{
    public class FormatoErrores
    {
        public static string FormatearError(string error)
        {
            string errorSource = error;
            List<string> patterns = new List<string>
        {
            @"MATRICULA ASEGURADA EN POLIZA \d+",
            @"ORA-\d+: en .+?, línea \d+"
        };

            List<string> descriptions = new List<string>
        {
            @"LA PLACA DEL VEHICULO SE ENCUENTRA ASEGURADA EN OTRA POLIZA",
            "Error en base de datos"
        };

            for (int i = 0; i < patterns.Count; i++)
            {
                string pattern = patterns[i];
                Match match = Regex.Match(error, pattern);

                if (match.Success)
                {

                    error = descriptions[i];
                    break;
                }
            }

            if (error == "Error en base de datos" || error.StartsWith("ORA-", StringComparison.CurrentCultureIgnoreCase)  )
            {
                try
                {
                    error = NewMethod(errorSource, @"ORA-(\d{5}): (.+)");
                    if (string.IsNullOrEmpty(error))
                    {
                        error = NewMethod(errorSource, @"TRN-(\d{5}): (.+)");
                    }
                }
                catch (Exception)
                {

                    error = "Error en base de datos";
                }

            }

            return error;
        }

        private static string NewMethod(string errorSource, string pattern)
        {
            string error;
            MatchCollection coincidencias = Regex.Matches(errorSource, pattern);
            int numerror;
            error = string.Empty;
            foreach (Match coincidencia in coincidencias)
            {
                numerror = Convert.ToInt32("0" + coincidencia.Groups[1].Value.OnlyNumbers());

                if (numerror > 20000 && numerror <= 20999)
                {
                    error = coincidencia.Groups[2].Value;
                }
            }
            error = error.Trim();
            error = error + "  ";
            error = error.Substring(0, 1).ToUpper() + error.Substring(1).ToLower();
            error = error.Replace("\n", "");
            error = error.Replace("\r", "");
            error = error.Trim();
            return error;
        }
    }
}

