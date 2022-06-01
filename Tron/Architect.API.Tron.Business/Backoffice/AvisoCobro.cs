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
        /// Consulta Recibos para incluir en aviso de cobro
        /// </summary>
        public static Contracts.AvisosDeCobro.InformacionAvisosResponse Consulta(Contracts.AvisosDeCobro.Parameters.AvisoCobroConsultaParametros item, int cod_Agt)
        {
            return DataAccess.AvisoCobro.Consulta(item, cod_Agt); 
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
