using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Emision
{
    internal static class SaldoDeudorConvert
    {

        internal static Contracts.Presupuesto.DatoFijo ToTron(Contracts.Emision.SaldoDeudor quoteInfo, int branch, int agentCode, string userName)
        {
            Contracts.Presupuesto.DatoFijo datosFijos = Util.DatosFijos(quoteInfo, branch, agentCode, userName, Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.SaldoDeudor.cod_sector", 1));

            datosFijos.num_poliza = quoteInfo.presupuesto;

            //FALTAN
            //Terceros(quoteInfo, datosFijos);
            //datosFijos.DatosVariables = DatosVariable(quoteInfo, datosFijos);

            return datosFijos;
        }

        internal static Contracts.Emision.SaldoDeudor FromTron(Contracts.Emision.SaldoDeudor quoteInfo, Contracts.Poliza.DatoFijo tronQuoteInfo)
        {
            //FALTAN
            return quoteInfo;
        }
    }
}
