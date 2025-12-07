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

        public static bool Generar(int companyId, int cod_ramo, string num_poliza, int cod_mon, ReciboCalculado reciboCalculado, Contracts.Comun.tercero tercero)
        {
            double tipoCambio = DataAccess.A1000500.ObtenerTasaCambioMasRecientePorMoneda(cod_mon);
            string codigoCABYS = DataAccess.A5029134_MCR.ObtenerCodigoCabysPorRamo(1, cod_ramo);
            Contracts.Ramo.A1001800 ramo = DataAccess.Ramo.A1001800.Retrieve(1, cod_ramo);

            GTI.Integrations.Domain.CargarDocumento.DocumentoResponse response = GTI.Integrations.Application.DocumentoRequestHandler.CargarDocumento(companyId, new FacturaRequest
            {
                TipoIdent = tercero.DocumentNumberType,
                Identificacion = tercero.DocumentNumber.DocumentNumber(tercero.DocumentNumberType.ToString()),
                Nombre = tercero.nombre.CompleteFullName(tercero.apellido1, tercero.apellido2),
                Correo = tercero.correoelectronico,
                Codigo = codigoCABYS,
                CodigoServicio = cod_ramo.ToString(),
                Cantidad = 1,
                PrecioUnitario = reciboCalculado.IMP_NETA,
                Impuesto = reciboCalculado.IMP_IMPTOS,
                PrecioTotal = reciboCalculado.IMP_RECIBO,
                Moneda = cod_mon,
                TipoCambio = tipoCambio,
                TipoMedioPago = "2",
                Descripcion = $"MAPFRE: {ramo.NOM_RAMO}. POLIZA #{num_poliza}, RECIBO #{reciboCalculado.NUM_RECIBO} COMPRENDIDO EN EL PERIODO {reciboCalculado.FEC_EFEC_RECIBO.ToString("dd/MM/yyyy")} - {reciboCalculado.FEC_VCTO_RECIBO.ToString("dd/MM/yyyy")}",
                NumeroFactura = reciboCalculado.NUM_RECIBO.ToString(),
                FechaFactura = reciboCalculado.FEC_EFEC_RECIBO,
                FechaVencimiento = reciboCalculado.FEC_VCTO_RECIBO
            });

            return response?.Respuestas?.FirstOrDefault()?.Codigo == 0;
        }
    }
}
