using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.GTI.Integrations.Domain.Factura
{
    public class FacturaRequest
    {
        /// <summary>
        /// Tipo de identificación del receptor.
        /// <para><b>Valores válidos:</b></para>
        /// <para>• <b>1</b> - Cédula física (9 dígitos): Solo números, sin cero al inicio y sin guiones.</para>
        /// <para>• <b>2</b> - Cédula jurídica (10 dígitos): Solo números, sin guiones.</para>
        /// <para>• <b>3</b> - DIMEX (11-12 dígitos): Solo números, sin guiones.</para>
        /// <para>• <b>4</b> - NITE (10 dígitos): Solo números, sin guiones.</para>
        /// <para>• <b>5</b> - Extranjero No Domiciliado (1-20 caracteres): Puede contener números y letras.</para>
        /// <para>• <b>6</b> - No Contribuyente (1-20 caracteres): Puede contener números y letras.</para>
        /// </summary>
        public int TipoIdent { get; set; }

        /// <summary>
        /// Número de identificación del receptor.
        /// </summary>
        public string Identificacion { get; set; }

        /// <summary>
        /// Nombre del receptor.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Correo electrónico del receptor.
        /// </summary>
        public string Correo { get; set; }


        /// <summary>
        /// Código del producto o servicio (CABYS).
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Códigos de producto o servicio (Código del RAMO TRON).
        /// </summary>
        public string CodigoServicio { get; set; }

        /// <summary>
        /// Cantidad de unidades del producto o servicio.
        /// </summary>
        public int Cantidad { get; set; } = 1;

        /// <summary>
        /// Precio unitario del producto o servicio.
        /// </summary>
        public double PrecioUnitario { get; set; }

        /// <summary>
        /// Impuesto del producto o servicio.
        /// </summary>
        public double Impuesto { get; set; }

        /// <summary>
        /// Precio total del producto o servicio.
        /// </summary>
        public double PrecioTotal { get; set; }

        /// <summary>
        /// Divisa en la que está hecha la factura.
        /// Campo requerido para todos los tipos de documentos.
        /// Valores válidos: 1 - Colones, 2 - US Dollar.
        /// </summary>
        public int Moneda { get; set; } = 1;

        /// <summary>
        /// Relación de equivalencia entre la divisa o tipo de moneda escogida con el colón.
        /// Indica cuántos colones se necesitan para obtener una unidad de otro tipo de moneda.
        /// Es obligatorio si se utiliza una moneda diferente a colones. Tamaño máximo: decimal (18,5).
        /// </summary>
        public double TipoCambio { get; set; }

        /// <summary>
        /// Tipo de medio de pago utilizado (1 efectivo, 2 tarjeta, 6 SINPE Móvil, 99 Otros).
        /// </summary>
        public string TipoMedioPago { get; set; } = "2";

        /// <summary>
        /// Descripción detallada del producto o servicio.
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Número de identificación del comprobante electrónico brindado por el cliente (usualmente se usa el número de recibo de TRON). 
        /// </summary>
        public string NumeroFactura { get; set; }

        /// <summary>
        /// Fecha en que se hizo el comprobante electrónico.
        /// Debe enviarse en el formato YYYY-MM-DDTHH:mm:ss.
        /// Si no se envía, se colocará la fecha del sistema de GTI durante su emisión.
        /// Campo requerido para todos los tipos de documentos.
        /// </summary>
        public DateTime FechaFactura { get; set; }
        /// <summary>
        /// Fecha del límite de pago del servicio o producto.
        /// Debe enviarse en el formato YYYY-MM-DDTHH:mm:ss.
        /// </summary>
        public DateTime FechaVencimiento { get; set; }

    }
}
