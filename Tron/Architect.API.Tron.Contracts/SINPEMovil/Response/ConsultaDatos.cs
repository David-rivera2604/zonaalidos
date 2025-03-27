using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.SINPEMovil.Response
{

    public class ConsultaDatos
    {
        /// <summary>
        /// Mensaje de respuesta del servicio (por ejemplo: "Consulta realizada correctamente.").
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Código que identifica el resultado de la consulta.
        /// 0: Consulta realizada correctamente.
        /// 1: Consulta no encontrada.
        /// 99: Error en el proceso.
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Cantidad de facturas encontradas.
        /// </summary>
        public int CantidadFacturas { get; set; }

        /// <summary>
        /// Lista de facturas asociadas a la consulta.
        /// </summary>
        public List<Factura> Facturas { get; set; }
    }
}
