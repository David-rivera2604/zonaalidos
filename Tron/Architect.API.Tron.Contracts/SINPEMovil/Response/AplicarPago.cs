using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.SINPEMovil.Response
{

    public class AplicarPago
    {
        /// <summary>
        /// Mensaje de respuesta del servicio (por ejemplo: "Pago realizado exitosamente.").
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Código que identifica el resultado del proceso.
        /// 0: Pago realizado exitosamente.
        /// 1: Pago no registrado.
        /// 2: Pago parcial.
        /// 98: Registrado pero no procesado.
        /// 99: Error en el proceso.
        /// </summary>
        public int Codigo { get; set; }
    }

}
