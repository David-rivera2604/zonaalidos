using Architect.Sugese.SituacionFinanciera.Domain;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Sugese.SituacionFinanciera.Application
{
    internal static class Pasivos
    {
        internal static Domain.ModeloSituacionFinancieraDatosModeloPasivo Builder(DataTable response, XLWorkbook workbook, int rowNumber)
        {
            IXLWorksheet sheet;
            Domain.ModeloSituacionFinancieraDatosModeloPasivo pasivo = new Domain.ModeloSituacionFinancieraDatosModeloPasivo();

            sheet = workbook.Worksheet(3);
            pasivo.ObligacionesPublico = ObligacionesPublico(response, sheet, rowNumber, pasivo);
            pasivo.ObligacionesEntidades = ObligacionesEntidades(response, sheet, rowNumber, pasivo);
            pasivo.CuentasPorPagarYProvisiones = CuentasPorPagarYProvisiones(response, sheet, rowNumber, pasivo);
            pasivo.ObligacionesContratosSeguros = ObligacionesContratosSeguros(response, sheet, rowNumber, pasivo);
            pasivo.ObligacionesContratosReaseguroMantenido = ObligacionesContratosReaseguroMantenido(response, sheet, rowNumber, pasivo);
            pasivo.ObligacionesSegurosContratosInversion = ObligacionesSegurosContratosInversion(response, sheet, rowNumber, pasivo);
            pasivo.OtrosPasivos = OtrosPasivos(response, sheet, rowNumber, pasivo);
            pasivo.ObligacionesSubordinadas = ObligacionesSubordinadas(response, sheet, rowNumber, pasivo);
            pasivo.ObligacionesConvertiblesEnCapital = ObligacionesConvertiblesEnCapital(response, sheet, rowNumber, pasivo);
            pasivo.ObligacionesPreferentes = ObligacionesPreferentes(response, sheet, rowNumber, pasivo);

            pasivo.TotalPasivo =
                pasivo.ObligacionesPublico.TotalOblPublico +
                pasivo.ObligacionesEntidades.TotalOblEntidades  +
                pasivo.CuentasPorPagarYProvisiones.TotalCuentasPagarProv  +
                pasivo.ObligacionesContratosSeguros.TotalObligacionesContratosSeguros +
                pasivo.ObligacionesContratosReaseguroMantenido.TotalObligacionesContratosReaseguroMantenido +
                pasivo.ObligacionesSegurosContratosInversion.TotalObligacionesSegurosContratosInversion +
                pasivo.OtrosPasivos.TotalOtrosPasivos +
                pasivo.ObligacionesSubordinadas.TotalOblSubordinadas +
                pasivo.ObligacionesConvertiblesEnCapital.TotalOblConvertibles +
                pasivo.ObligacionesPreferentes.TotalOblPreferentes;

            return pasivo;
        }

        private static ModeloSituacionFinancieraDatosModeloPasivoObligacionesPublico ObligacionesPublico(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPasivo pasivo)
        {
            ModeloSituacionFinancieraDatosModeloPasivoObligacionesPublico data = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesPublico()
            {
                DesgloseObligacionesPublico = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesPublicoDesgloseObligacionesPublico()
                {
                    ReportoPactoTripartitoPrestamoValores = sheet.DecimalValue(rowNumber, "A", response),
                    ObligacionesPlazo = sheet.DecimalValue(rowNumber, "B", response),
                    CargosPorPagar = sheet.DecimalValue(rowNumber, "C", response)
                }
            };

            data.TotalOblPublico =
                data.DesgloseObligacionesPublico.ReportoPactoTripartitoPrestamoValores +
                data.DesgloseObligacionesPublico.ObligacionesPlazo +
                data.DesgloseObligacionesPublico.CargosPorPagar;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPasivoObligacionesEntidades ObligacionesEntidades(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPasivo pasivo)
        {
            ModeloSituacionFinancieraDatosModeloPasivoObligacionesEntidades data = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesEntidades()
            {
                DesgloseObligacionesEntidades = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesEntidadesDesgloseObligacionesEntidades()
                {
                    Vista = sheet.DecimalValue(rowNumber, "D", response),
                    APlazo = sheet.DecimalValue(rowNumber, "E", response),
                    EntidadesNoFinancieras = sheet.DecimalValue(rowNumber, "F", response),
                    GastosDifCarteraPropia = sheet.DecimalValue(rowNumber, "G", response),
                    CargosPorPagar = sheet.DecimalValue(rowNumber, "H", response)
                }
            };

            data.TotalOblEntidades =
                data.DesgloseObligacionesEntidades.Vista +
                data.DesgloseObligacionesEntidades.APlazo +
                data.DesgloseObligacionesEntidades.EntidadesNoFinancieras +
                data.DesgloseObligacionesEntidades.GastosDifCarteraPropia +
                data.DesgloseObligacionesEntidades.CargosPorPagar;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPasivoCuentasPorPagarYProvisiones CuentasPorPagarYProvisiones(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPasivo pasivo)
        {
            ModeloSituacionFinancieraDatosModeloPasivoCuentasPorPagarYProvisiones data = new ModeloSituacionFinancieraDatosModeloPasivoCuentasPorPagarYProvisiones()
            {
                DesgloseCuentasPorPagarYProvisiones = new ModeloSituacionFinancieraDatosModeloPasivoCuentasPorPagarYProvisionesDesgloseCuentasPorPagarYProvisiones()
                {
                    DifPosicionDerivados = sheet.DecimalValue(rowNumber, "I", response),
                    CtasComisionesPorPagarDiversas = sheet.DecimalValue(rowNumber, "J", response),
                    Provisiones = sheet.DecimalValue(rowNumber, "K", response),
                    RentaDiferido = sheet.DecimalValue(rowNumber, "L", response),
                    CargosPagarDiversos = sheet.DecimalValue(rowNumber, "M", response)
                }
            };

            data.TotalCuentasPagarProv =
                data.DesgloseCuentasPorPagarYProvisiones.DifPosicionDerivados +
                data.DesgloseCuentasPorPagarYProvisiones.CtasComisionesPorPagarDiversas +
                data.DesgloseCuentasPorPagarYProvisiones.Provisiones +
                data.DesgloseCuentasPorPagarYProvisiones.RentaDiferido +
                data.DesgloseCuentasPorPagarYProvisiones.CargosPagarDiversos;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPasivoObligacionesContratosSeguros ObligacionesContratosSeguros(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPasivo pasivo)
        {
            ModeloSituacionFinancieraDatosModeloPasivoObligacionesContratosSeguros data = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesContratosSeguros()
            {
                DesgloseObligacionesContratosSeguros = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesContratosSegurosDesgloseObligacionesContratosSeguros()
                {
                    ContratosOnerosos = sheet.DecimalValue(rowNumber, "N", response),
                    ContratosNoOnerosos = sheet.DecimalValue(rowNumber, "O", response),
                    ContratosReaseguroAceptadoOnerosos = sheet.DecimalValue(rowNumber, "P", response),
                    ContratosReaseguroAceptadoNoOnerosos = sheet.DecimalValue(rowNumber, "Q", response),
                    RiesgosCatastroficos = sheet.DecimalValue(rowNumber, "R", response)
                }
            };

            data.TotalObligacionesContratosSeguros =
                    data.DesgloseObligacionesContratosSeguros.ContratosOnerosos +
                    data.DesgloseObligacionesContratosSeguros.ContratosNoOnerosos +
                    data.DesgloseObligacionesContratosSeguros.ContratosReaseguroAceptadoOnerosos +
                    data.DesgloseObligacionesContratosSeguros.ContratosReaseguroAceptadoNoOnerosos +
                    data.DesgloseObligacionesContratosSeguros.RiesgosCatastroficos;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPasivoObligacionesContratosReaseguroMantenido ObligacionesContratosReaseguroMantenido(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPasivo pasivo)
        {
            ModeloSituacionFinancieraDatosModeloPasivoObligacionesContratosReaseguroMantenido data = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesContratosReaseguroMantenido()
            {
                DesgloseContratosReaseguroMantenido = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesContratosReaseguroMantenidoDesgloseContratosReaseguroMantenido()
                {
                    ContratosReaseguroMantenido = sheet.DecimalValue(rowNumber, "S", response)
                }
            };

            data.TotalObligacionesContratosReaseguroMantenido =
                    data.DesgloseContratosReaseguroMantenido.ContratosReaseguroMantenido;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPasivoObligacionesSegurosContratosInversion ObligacionesSegurosContratosInversion(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPasivo pasivo)
        {
            ModeloSituacionFinancieraDatosModeloPasivoObligacionesSegurosContratosInversion data = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesSegurosContratosInversion()
            {
                DesgloseObligacionesSegurosContratosInversion = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesSegurosContratosInversionDesgloseObligacionesSegurosContratosInversion()
                {
                    ObligacionesSegurosContratosInversion = sheet.DecimalValue(rowNumber, "T", response)
                }
            };

            data.TotalObligacionesSegurosContratosInversion =
                    data.DesgloseObligacionesSegurosContratosInversion.ObligacionesSegurosContratosInversion;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPasivoOtrosPasivos OtrosPasivos(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPasivo pasivo)
        {
            ModeloSituacionFinancieraDatosModeloPasivoOtrosPasivos data = new ModeloSituacionFinancieraDatosModeloPasivoOtrosPasivos()
            {
                DesgloseOtrosPasivos = new ModeloSituacionFinancieraDatosModeloPasivoOtrosPasivosDesgloseOtrosPasivos()
                {
                    IngresosDiferidos = sheet.DecimalValue(rowNumber, "U", response),
                    OperacionesPendientesImputacion = sheet.DecimalValue(rowNumber, "V", response),
                    CtasReciprocasInternas = sheet.DecimalValue(rowNumber, "W", response),
                    PasivoPagosValorRazonableInstrumentosPatrimonio = sheet.DecimalValue(rowNumber, "X", response)
                }
            };

            data.TotalOtrosPasivos =
                    data.DesgloseOtrosPasivos.IngresosDiferidos +
                    data.DesgloseOtrosPasivos.OperacionesPendientesImputacion +
                    data.DesgloseOtrosPasivos.CtasReciprocasInternas +
                    data.DesgloseOtrosPasivos.PasivoPagosValorRazonableInstrumentosPatrimonio;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPasivoObligacionesSubordinadas ObligacionesSubordinadas(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPasivo pasivo)
        {
            ModeloSituacionFinancieraDatosModeloPasivoObligacionesSubordinadas data = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesSubordinadas()
            {
                DesgloseObligacionesSubordinadas = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesSubordinadasDesgloseObligacionesSubordinadas()
                {
                    ObligacionesSubordinadas = sheet.DecimalValue(rowNumber, "Y", response),
                    PrestamosSubordinados = sheet.DecimalValue(rowNumber, "Z", response),
                    CargosPagar = sheet.DecimalValue(rowNumber, "AA", response)
                }
            };

            data.TotalOblSubordinadas =
                    data.DesgloseObligacionesSubordinadas.ObligacionesSubordinadas +
                    data.DesgloseObligacionesSubordinadas.PrestamosSubordinados +
                    data.DesgloseObligacionesSubordinadas.CargosPagar;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPasivoObligacionesConvertiblesEnCapital ObligacionesConvertiblesEnCapital(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPasivo pasivo)
        {
            ModeloSituacionFinancieraDatosModeloPasivoObligacionesConvertiblesEnCapital data = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesConvertiblesEnCapital()
            {
                DesgloseObligacionesConvertiblesEnCapital = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesConvertiblesEnCapitalDesgloseObligacionesConvertiblesEnCapital()
                {
                    ObligacionesConvertiblesEnCapital = sheet.DecimalValue(rowNumber, "AB", response),
                    CargosPagar = sheet.DecimalValue(rowNumber, "AC", response)
                }
            };

            data.TotalOblConvertibles =
                    data.DesgloseObligacionesConvertiblesEnCapital.ObligacionesConvertiblesEnCapital +
                    data.DesgloseObligacionesConvertiblesEnCapital.CargosPagar;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPasivoObligacionesPreferentes ObligacionesPreferentes(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPasivo pasivo)
        {
            ModeloSituacionFinancieraDatosModeloPasivoObligacionesPreferentes data = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesPreferentes()
            {
                DesgloseObligacionesPreferentes = new ModeloSituacionFinancieraDatosModeloPasivoObligacionesPreferentesDesgloseObligacionesPreferentes()
                {
                    ObligacionesPreferentes = sheet.DecimalValue(rowNumber, "AD", response),
                    CargosPagar = sheet.DecimalValue(rowNumber, "AE", response)
                }
            };

            data.TotalOblPreferentes =
                    data.DesgloseObligacionesPreferentes.ObligacionesPreferentes +
                    data.DesgloseObligacionesPreferentes.CargosPagar;
            return data;
        }

    }
}
