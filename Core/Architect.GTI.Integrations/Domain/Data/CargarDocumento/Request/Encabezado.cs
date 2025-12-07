using System;

namespace Architect.GTI.Integrations.Domain.CargarDocumento.Request
{
    /// <summary>
    /// Encabezado del documento electrónico con información general de la transacción.
    /// </summary>
    public class Encabezado
    {
        /// <summary>
        /// Código de actividad económica a la cual corresponde el comprobante electrónico.
        /// En caso de contar con más de una, debe ingresar el código de la actividad principal.
        /// Campo requerido para todos los tipos de documentos. Tamaño máximo: 6 caracteres.
        /// </summary>
        public string CodigoActividad { get; set; }

        /// <summary>
        /// Indicador de impuesto sobre la renta.
        /// </summary>
        public int ImpRenta { get; set; }

        /// <summary>
        /// Nombre comercial que se visualizará en el PDF.
        /// Tamaño máximo: 80 caracteres.
        /// </summary>
        public string NombComercial { get; set; }

        /// <summary>
        /// Cantidad de decimales para emitir el comprobante electrónico.
        /// Permite indicar una cantidad diferente a la configurada en la cuenta.
        /// Tamaño máximo: 1 dígito.
        /// </summary>
        public int CantDeci { get; set; }

        /// <summary>
        /// Tipo de documento electrónico que se desea generar.
        /// Campo requerido para todos los tipos de documentos. Tamaño máximo: 2 dígitos.
        /// Ver notas de documentación para valores válidos.
        /// </summary>
        public int TipoDoc { get; set; }

        /// <summary>
        /// Identificación de la circunstancia en la que se realizó y se envió la factura al sistema de facturación.
        /// Campo requerido para todos los tipos de documentos. Tamaño máximo: 1 dígito.
        /// Ver notas de documentación para valores válidos.
        /// </summary>
        public int SituacionEnvio { get; set; }

        /// <summary>
        /// Número que identifica la sucursal de la empresa.
        /// Campo requerido para todos los tipos de documentos. Tamaño máximo: 3 dígitos.
        /// </summary>
        public int Sucursal { get; set; }

        /// <summary>
        /// Número que identifica la terminal de la sucursal de la empresa.
        /// Campo requerido para todos los tipos de documentos. Tamaño máximo: 5 dígitos.
        /// </summary>
        public int Terminal { get; set; }

        /// <summary>
        /// Divisa en la que está hecha la factura.
        /// Campo requerido para todos los tipos de documentos.
        /// Valores válidos: 1 - Colones, 2 - US Dollar.
        /// </summary>
        public int Moneda { get; set; }

        /// <summary>
        /// Relación de equivalencia entre la divisa o tipo de moneda escogida con el colón.
        /// Indica cuántos colones se necesitan para obtener una unidad de otro tipo de moneda.
        /// Es obligatorio si se utiliza una moneda diferente a colones. Tamaño máximo: decimal (18,5).
        /// </summary>
        public double TipoCambio { get; set; }

        /// <summary>
        /// Medios de pago utilizados en la transacción comercial.
        /// Pueden enviarse varios medios de pago por documento, máximo 4.
        /// Este campo solo aplica para notas de crédito y notas de débito de facturas realizadas en versión 4.3.
        /// Tamaño máximo: 2 bytes por elemento.
        /// </summary>
        public Mediopago[] MedioPagos { get; set; }

        /// <summary>
        /// Tipo o forma de venta utilizada para realizar la transacción comercial.
        /// Campo requerido para todos los tipos de documentos. Tamaño máximo: 2 dígitos.
        /// Ver notas de documentación para valores válidos.
        /// </summary>
        public int CondicionVenta { get; set; }

        /// <summary>
        /// Número de identificación del comprobante electrónico brindado por el cliente.
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
        /// Número interno que identifica una compra de producto o servicio.
        /// Tamaño máximo: 20 caracteres.
        /// </summary>
        public string NumOrdenCompra { get; set; }

        /// <summary>
        /// Fecha del límite de pago del servicio o producto.
        /// Debe enviarse en el formato YYYY-MM-DDTHH:mm:ss.
        /// </summary>
        public DateTime FechaVencimiento { get; set; }

        /// <summary>
        /// Información del receptor del documento electrónico.
        /// </summary>
        public Receptor receptor { get; set; }
    }
}
