using Aliados.Monge.Domain.Poliza.Emision;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Application.Poliza.Ramos
{
    internal class Util
    {

        internal static string StringValue(List<Domain.Poliza.Emision.DatosVariables> datosvariables, string name, string defaultValue = "")
        {
            string result = String.Empty;
            if (datosvariables.Exists(r => r.nombre == name))
            {
                result = datosvariables.Find(r => r.nombre == name).valor;
            }
            else if (defaultValue.IsNotEmpty())
            {
                result = defaultValue;
            }
            return result;

        }
        internal static DateTime DateTimeValue(List<Domain.Poliza.Emision.DatosVariables> datosvariables, string name)
        {
            DateTime result = DateTime.MinValue;

            if (datosvariables.Exists(r => r.nombre == name))
            {
                result = Convert.ToDateTime(datosvariables.Find(r => r.nombre == name).valor);
            }

            return result;

        }
        internal static int IntegerValue(List<Domain.Poliza.Emision.DatosVariables> datosvariables, string name)
        {
            int result = 0;
            if (datosvariables.Exists(r => r.nombre == name))
            {
                result = Convert.ToInt32(datosvariables.Find(r => r.nombre == name).valor);
            }
            return result;

        }

        internal static int IntegerValue(List<Domicilio> detalleDomicilio, int nivel)
        {
            int result = Convert.ToInt32(detalleDomicilio.Find(r => r.nivel == nivel).valor);
            if (detalleDomicilio.Exists(r => r.nivel == nivel))
            {
                result = Convert.ToInt32(detalleDomicilio.Find(r => r.nivel == nivel).valor);
            }
            return result;

        }
        internal static string StringValue(List<Domicilio> detalleDomicilio, int nivel)
        {
            string result = String.Empty;
            if (detalleDomicilio.Exists(r => r.nivel == nivel))
            {
                result = detalleDomicilio.Find(r => r.nivel == nivel).valor;
            }
            return result;

        }


    }
}
