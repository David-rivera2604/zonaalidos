using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.SINPEMovil.Request
{

    // Clases para el servicio "Consulta de Datos"
    public class ConsultaDatos
    {
        ///// <summary>
        ///// Identificador (se envía en el query string de la URL).
        ///// Puede ser la identificación del cliente o el código digitado por el usuario.
        ///// </summary>
        //public string Id { get; set; }

        /// <summary>
        /// Identificación del cliente (10 dígitos con guiones).
        /// </summary>
        public string IdentificacionCliente { get; set; }

        /// <summary>
        /// Nombre del cliente.
        /// </summary>
        public string NombreCliente { get; set; }

        /// <summary>
        /// Código de la moneda (1 para Colones).
        /// </summary>
        public int Moneda { get; set; }

        /// <summary>
        /// Monto del pago.
        /// </summary>
        public decimal Monto { get; set; }

        /// <summary>
        /// Fecha y hora en que se registró el pago (formato "yyyy-MM-dd HH:mm").
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Código de referencia de la transacción en SINPE.
        /// </summary>
        public string CodReferencia { get; set; }

        /// <summary>
        /// Código de referencia asignado por el banco.
        /// </summary>
        public string CodReferenciaBanco { get; set; }

        /// <summary>
        /// Descripción del SINPE (por ejemplo, número de orden o suscriptor).
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Número de teléfono de origen (del cliente que genera la transacción).
        /// </summary>
        public string TelefonoOrigen { get; set; }

        /// <summary>
        /// Número de teléfono destino donde se envió el pago.
        /// </summary>
        public string TelefonoDestino { get; set; }
    }

}
