using Architect.Sugese.CuentaTecnicaFinanciera.Domain;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Sugese.CuentaTecnicaFinanciera.Application
{
    internal static class CuentaNoTecnica
    {
        internal static Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaNoTecnica Builder(DataTable response, XLWorkbook workbook, int rowNumber)
        {
            IXLWorksheet sheet = workbook.Worksheet(4);
            Domain.ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaNoTecnica cuentaNoTecnica = new ModeloCuentaTecnicaFinancieraDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaNoTecnica();

            // <!--X-->
            cuentaNoTecnica.IngresosFinancieros = sheet.DecimalValue(rowNumber, "A", response);
            // <!--XI-->
            cuentaNoTecnica.GastosFinancieros = sheet.DecimalValue(rowNumber, "B", response);
            // <!--XII-->
            cuentaNoTecnica.OtrosIngresosNoTecnicos = sheet.DecimalValue(rowNumber, "C", response);
            // <!--XIII-->
            cuentaNoTecnica.OtrosGastosNoTecnicos = sheet.DecimalValue(rowNumber, "D", response);

            // <!--[D] = X - XI + XII - XIII -->
            cuentaNoTecnica.TotalCuentaNoTecnica =
                cuentaNoTecnica.IngresosFinancieros -
                cuentaNoTecnica.GastosFinancieros +
                cuentaNoTecnica.OtrosIngresosNoTecnicos -
                cuentaNoTecnica.OtrosGastosNoTecnicos;

            return cuentaNoTecnica;
        }

    }
}
