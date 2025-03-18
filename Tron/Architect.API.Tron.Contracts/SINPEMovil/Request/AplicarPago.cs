using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.SINPEMovil.Request
{
    /// <summary>
    /// Representa la solicitud para aplicar un pago recibido desde el sistema propio del cliente.
    /// </summary>
    public class AplicarPago
    {
        /// <summary>
        /// Identificación del cliente.
        /// Formato requerido: 10 dígitos separados por guiones (ej. 01-0123-0456).
        /// </summary>
        public string IdentificacionCliente { get; set; }

        /// <summary>
        /// Nombre del cliente que origina la transacción de pago a través de SINPE.
        /// </summary>
        public string NombreCliente { get; set; }

        /// <summary>
        /// Código de la moneda.
        /// Actualmente se soporta: 1 (Colones).
        /// </summary>
        public int Moneda { get; set; }

        /// <summary>
        /// Monto del pago, representado con dos decimales.
        /// </summary>
        public decimal Monto { get; set; }

        /// <summary>
        /// Fecha y hora en que se realizó el registro del pago.
        /// Formato: "yyyy-MM-dd HH:mm".
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Código de referencia único asignado por el sistema SINPE.
        /// </summary>
        public string CodReferencia { get; set; }

        /// <summary>
        /// Código de referencia único asignado por el banco.
        /// </summary>
        public string CodReferenciaBanco { get; set; }

        /// <summary>
        /// Descripción del pago recibido vía SINPE.
        /// Puede detallar un número de orden, suscriptor, etc.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Número de teléfono destino donde se realizó la transferencia.
        /// </summary>
        public string TelefonoDestino { get; set; }

        /// <summary>
        /// Lista opcional de datos adicionales (par clave-valor).
        /// </summary>
        public List<DatosAdicionales> DatosAdicionales { get; set; } = new List<DatosAdicionales>();

        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public int Estado{ get; set; }


    }

}

