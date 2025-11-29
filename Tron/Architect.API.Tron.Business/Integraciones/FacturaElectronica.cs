using Architect.API.Insurance.Contracts.Bayer;
using Architect.API.Tron.Contracts.Poliza;
using Architect.GTI.Integrations.Domain.Factura;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Integraciones
{
    public static class FacturaElectronica
    {

        public static void Generar(int cod_ramo, Recibo recibo, ReciboCalculado reciboCalculado, Contracts.Comun.tercero tercero)
        {
            double tipoCambio = DataAccess.A1000500.ObtenerTasaCambioMasRecientePorMoneda(recibo.cod_mon);
            string codigoCABYS = DataAccess.A5029134_MCR.ObtenerCodigoCabysPorRamo(1, cod_ramo);
            Contracts.Ramo.A1001800 ramo = DataAccess.Ramo.A1001800.Retrieve(1, cod_ramo);

            Architect.GTI.Integrations.Application.DocumentoRequestHandler.CargarDocumento(new FacturaRequest
            {
                TipoIdent = tercero.DocumentNumberType,
                Identificacion = tercero.DocumentNumber,
                Nombre = tercero.nombre.CompleteFullName(tercero.apellido1, tercero.apellido2),
                Correo = tercero.correoelectronico,
                Codigo = codigoCABYS,
                CodigoServicio = cod_ramo.ToString(),
                Cantidad = 1,
                PrecioUnitario = reciboCalculado.IMP_RECIBO,
                Moneda = recibo.cod_mon,
                TipoCambio = tipoCambio,
                TipoMedioPago = "2",
                Descripcion = $"MAPFRE: {ramo.NOM_RAMO}. POLIZA #{recibo.num_poliza}, RECIBO #{recibo.num_recibo} COMPRENDIDO EN EL PERIODO {recibo.fec_efec_recibo.ToString("dd/MM/yyyy")} - {recibo.fec_vcto_recibo.ToString("dd/MM/yyyy")}",
                NumeroFactura = recibo.num_recibo.ToString(),
                FechaFactura = recibo.fec_efec_recibo,
                FechaVencimiento = recibo.fec_vcto_recibo
            });
        }
    }
}
