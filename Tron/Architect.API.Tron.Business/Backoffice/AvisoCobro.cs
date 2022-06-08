using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Avisos de cobro asociados a los recibos
    /// </summary>
    public class AvisoCobro
    {
        /// <summary>
        /// Modifica un aviso de cobro para exluir recibos del mismo
        /// </summary>
        public static bool Modifica(Contracts.AvisosDeCobro.Parameters.AvisoCobroModificaParametros item)
        {
            return DataAccess.AvisoCobro.Modifica(item.Num_Aviso, item.Lista_Recibos);
        }

        /// <summary>
        /// Consulta Recibos para incluir en aviso de cobro
        /// </summary>
        public static List<Contracts.AvisosDeCobro.ReciboRespose> ConsultaRecibos(Contracts.AvisosDeCobro.Parameters.RecibosParametros item, int cod_Agt)
        {
            if (item.Num_Contrato == 0)
            {
                item.Num_Contrato = int.MinValue;
            }
            return DataAccess.AvisoCobro.ConsultaRecibos(item, cod_Agt);
        }

        /// <summary>
        /// Genera Aviso de Cobro
        /// </summary>
        public static List<Contracts.AvisosDeCobro.AvisoResponse> Generar(Contracts.AvisosDeCobro.Parameters.AvisoCobroGenerarParametros item, int cod_Agt)
        {
            return DataAccess.AvisoCobro.Generar(item, cod_Agt);
        }

        /// <summary>
        /// Elimina un aviso de cobro en base a número del aviso
        /// </summary>
        public static bool Elimina(string numAviso)
        {
            return DataAccess.AvisoCobro.Delete(numAviso);
        }
    }
}
