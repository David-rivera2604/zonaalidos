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
        public static string FormatearError(string Error)
        {
           
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
                Match match = Regex.Match(Error, pattern);

                if (match.Success)
                {

                    Error = descriptions[i];
                    break; 
                }
            }

            return Error;
        }

    }
}

