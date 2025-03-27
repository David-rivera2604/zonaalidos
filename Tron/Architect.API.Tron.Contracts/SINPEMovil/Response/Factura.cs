using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.SINPEMovil.Response
{

    public class Factura
    {
        /// <summary>
        /// Código específico de la factura (por ejemplo, número de orden o de suscriptor).
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Identificación del cliente asociada a la factura.
        /// </summary>
        public string Identificacion { get; set; }

        /// <summary>
        /// Nombre del cliente.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del cliente.
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Número de teléfono del cliente.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Fecha de vencimiento del saldo de la factura.
        /// </summary>
        public string Vencimiento { get; set; }

        /// <summary>
        /// Saldo actual de la factura.
        /// </summary>
        public decimal Saldo { get; set; }

        /// <summary>
        /// Saldo mínimo parcial de la factura.
        /// </summary>
        public decimal SaldoMinimo { get; set; }

        /// <summary>
        /// Cantidad de facturas impagas.
        /// </summary>
        public int FacturasImpagas { get; set; }
    }

}
