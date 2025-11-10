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
    internal static class Patrimonio
    {
        internal static Domain.ModeloSituacionFinancieraDatosModeloPatrimonio Builder(DataTable response, XLWorkbook workbook, int rowNumber)
        {
            IXLWorksheet sheet;
            Domain.ModeloSituacionFinancieraDatosModeloPatrimonio patrimonio = new Domain.ModeloSituacionFinancieraDatosModeloPatrimonio();

            sheet = workbook.Worksheet(4);
            patrimonio.CapitalSocialCapitalMinimoFuncionamiento = CapitalSocialCapitalMinimoFuncionamiento(response, sheet, rowNumber, patrimonio);
            patrimonio.AportesPatrimonialesNoCapitalizados = AportesPatrimonialesNoCapitalizados(response, sheet, rowNumber, patrimonio);
            patrimonio.AjustesPatrimonioResultadoIntegral = AjustesPatrimonioResultadoIntegral(response, sheet, rowNumber, patrimonio);
            patrimonio.Reservas = Reservas(response, sheet, rowNumber, patrimonio);
            patrimonio.ResultadosAcumuladosEjerciciosAnteriores = ResultadosAcumuladosEjerciciosAnteriores(response, sheet, rowNumber, patrimonio);
            patrimonio.ResultadosPeriodo = ResultadosPeriodo(response, sheet, rowNumber, patrimonio);
            patrimonio.ParticipacionesNoControladas = ParticipacionesNoControladas(response, sheet, rowNumber, patrimonio);
            patrimonio.PatrimonioEnFondoOReservasEspeciales = PatrimonioEnFondoOReservasEspeciales(response, sheet, rowNumber, patrimonio);

            patrimonio.TotalPatrimonio =
                patrimonio.CapitalSocialCapitalMinimoFuncionamiento.TotalCapSocial +
                patrimonio.AportesPatrimonialesNoCapitalizados.TotalApoPatrimoniales +
                patrimonio.AjustesPatrimonioResultadoIntegral.TotalAjustesPatrimonioResultadoIntegral +
                patrimonio.Reservas.TotalReservas +
                patrimonio.ResultadosAcumuladosEjerciciosAnteriores.TotalResAcumulados +
                patrimonio.ResultadosPeriodo.TotalResPeriodo +
                patrimonio.ParticipacionesNoControladas.TotalParticipacionesNoControladas +
                patrimonio.PatrimonioEnFondoOReservasEspeciales.TotalPatrimonioEnFondoOReservasEspeciales;

            return patrimonio;
        }

        private static ModeloSituacionFinancieraDatosModeloPatrimonioCapitalSocialCapitalMinimoFuncionamiento CapitalSocialCapitalMinimoFuncionamiento(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPatrimonio patrimonio)
        {
            ModeloSituacionFinancieraDatosModeloPatrimonioCapitalSocialCapitalMinimoFuncionamiento data = new ModeloSituacionFinancieraDatosModeloPatrimonioCapitalSocialCapitalMinimoFuncionamiento()
            {
                DesgloseCapitalSocialCapitalMinimoFuncionamiento = new ModeloSituacionFinancieraDatosModeloPatrimonioCapitalSocialCapitalMinimoFuncionamientoDesgloseCapitalSocialCapitalMinimoFuncionamiento()
                {
                    Pagado = sheet.DecimalValue(rowNumber, "A", response),
                    Donado = sheet.DecimalValue(rowNumber, "B", response),
                    SuscritoNoIntegrado = sheet.DecimalValue(rowNumber, "C", response),
                    SuscripcionesCapitalPorIntegrar = sheet.DecimalValue(rowNumber, "D", response),
                    AccionesTesoreria = sheet.DecimalValue(rowNumber, "E", response),
                    CapitalAsignadoSucursales = sheet.DecimalValue(rowNumber, "F", response)
                }
            };

            data.TotalCapSocial =
                data.DesgloseCapitalSocialCapitalMinimoFuncionamiento.Pagado +
                data.DesgloseCapitalSocialCapitalMinimoFuncionamiento.Donado +
                data.DesgloseCapitalSocialCapitalMinimoFuncionamiento.SuscritoNoIntegrado +
                data.DesgloseCapitalSocialCapitalMinimoFuncionamiento.SuscripcionesCapitalPorIntegrar +
                data.DesgloseCapitalSocialCapitalMinimoFuncionamiento.AccionesTesoreria +
                data.DesgloseCapitalSocialCapitalMinimoFuncionamiento.CapitalAsignadoSucursales;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPatrimonioAportesPatrimonialesNoCapitalizados AportesPatrimonialesNoCapitalizados(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPatrimonio patrimonio)
        {
            ModeloSituacionFinancieraDatosModeloPatrimonioAportesPatrimonialesNoCapitalizados data = new ModeloSituacionFinancieraDatosModeloPatrimonioAportesPatrimonialesNoCapitalizados()
            {
                DesgloseAportesPatrimonialesNoCapitalizados = new ModeloSituacionFinancieraDatosModeloPatrimonioAportesPatrimonialesNoCapitalizadosDesgloseAportesPatrimonialesNoCapitalizados()
                {
                    CapitalPagadoAdicional = sheet.DecimalValue(rowNumber, "G", response),
                    ParaIncrementosCapital = sheet.DecimalValue(rowNumber, "H", response),
                    DonacionesYotrasContribucionesNoCapitalizables = sheet.DecimalValue(rowNumber, "I", response),
                    ApotMantCapMinObliEntAsegYReasegRevalUDPendCalificar = sheet.DecimalValue(rowNumber, "J", response),
                    ApotMantCapMinObliEntAsegYReasegRevalUDPendCalificarSucursales = sheet.DecimalValue(rowNumber, "K", response)
                }
            };

            data.TotalApoPatrimoniales =
                data.DesgloseAportesPatrimonialesNoCapitalizados.CapitalPagadoAdicional +
                data.DesgloseAportesPatrimonialesNoCapitalizados.ParaIncrementosCapital +
                data.DesgloseAportesPatrimonialesNoCapitalizados.DonacionesYotrasContribucionesNoCapitalizables +
                data.DesgloseAportesPatrimonialesNoCapitalizados.ApotMantCapMinObliEntAsegYReasegRevalUDPendCalificar +
                data.DesgloseAportesPatrimonialesNoCapitalizados.ApotMantCapMinObliEntAsegYReasegRevalUDPendCalificarSucursales;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPatrimonioAjustesPatrimonioResultadoIntegral AjustesPatrimonioResultadoIntegral(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPatrimonio patrimonio)
        {
            ModeloSituacionFinancieraDatosModeloPatrimonioAjustesPatrimonioResultadoIntegral data = new ModeloSituacionFinancieraDatosModeloPatrimonioAjustesPatrimonioResultadoIntegral()
            {
                DesgloseAjustesPatrimonioResultadoIntegral = new ModeloSituacionFinancieraDatosModeloPatrimonioAjustesPatrimonioResultadoIntegralDesgloseAjustesPatrimonioResultadoIntegral()
                {
                    AlValorActivos = sheet.DecimalValue(rowNumber, "L", response),
                    ValoracionParticipacionesOtrasEmpresas = sheet.DecimalValue(rowNumber, "M", response),
                    ConversionEstadosFinancieros = sheet.DecimalValue(rowNumber, "N", response),
                    AjusteValuacionPasivos = sheet.DecimalValue(rowNumber, "O", response),
                    AjusteValuacionContratosSeguros = sheet.DecimalValue(rowNumber, "P", response)
                }
            };

            data.TotalAjustesPatrimonioResultadoIntegral =
                data.DesgloseAjustesPatrimonioResultadoIntegral.AlValorActivos +
                data.DesgloseAjustesPatrimonioResultadoIntegral.ValoracionParticipacionesOtrasEmpresas +
                data.DesgloseAjustesPatrimonioResultadoIntegral.ConversionEstadosFinancieros +
                data.DesgloseAjustesPatrimonioResultadoIntegral.AjusteValuacionPasivos +
                data.DesgloseAjustesPatrimonioResultadoIntegral.AjusteValuacionContratosSeguros;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPatrimonioReservas Reservas(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPatrimonio patrimonio)
        {
            ModeloSituacionFinancieraDatosModeloPatrimonioReservas data = new ModeloSituacionFinancieraDatosModeloPatrimonioReservas()
            {
                DesgloseReservas = new ModeloSituacionFinancieraDatosModeloPatrimonioReservasDesgloseReservas()
                {
                    Legal = sheet.DecimalValue(rowNumber, "Q", response),
                    OtrasObligatorias = sheet.DecimalValue(rowNumber, "R", response),
                    Voluntarias = sheet.DecimalValue(rowNumber, "S", response),
                    ReservasRegulatorias = sheet.DecimalValue(rowNumber, "T", response)
                }
            };

            data.TotalReservas =
                    data.DesgloseReservas.Legal +
                    data.DesgloseReservas.OtrasObligatorias +
                    data.DesgloseReservas.Voluntarias +
                    data.DesgloseReservas.ReservasRegulatorias;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPatrimonioResultadosAcumuladosEjerciciosAnteriores ResultadosAcumuladosEjerciciosAnteriores(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPatrimonio patrimonio)
        {
            ModeloSituacionFinancieraDatosModeloPatrimonioResultadosAcumuladosEjerciciosAnteriores data = new ModeloSituacionFinancieraDatosModeloPatrimonioResultadosAcumuladosEjerciciosAnteriores()
            {
                DesgloseResultadosAcumuladosEjerciciosAnteriores = new ModeloSituacionFinancieraDatosModeloPatrimonioResultadosAcumuladosEjerciciosAnterioresDesgloseResultadosAcumuladosEjerciciosAnteriores()
                {
                    UtilidadesAcumuladas = sheet.DecimalValue(rowNumber, "U", response),
                    PerdidasAcumuladas = sheet.DecimalValue(rowNumber, "V", response)
                }
            };

            data.TotalResAcumulados =
                    data.DesgloseResultadosAcumuladosEjerciciosAnteriores.UtilidadesAcumuladas +
                    data.DesgloseResultadosAcumuladosEjerciciosAnteriores.PerdidasAcumuladas;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPatrimonioResultadosPeriodo ResultadosPeriodo(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPatrimonio patrimonio)
        {
            ModeloSituacionFinancieraDatosModeloPatrimonioResultadosPeriodo data = new ModeloSituacionFinancieraDatosModeloPatrimonioResultadosPeriodo()
            {
                DesgloseResultadosPeriodo = new ModeloSituacionFinancieraDatosModeloPatrimonioResultadosPeriodoDesgloseResultadosPeriodo()
                {
                    UtilidadNeta = sheet.DecimalValue(rowNumber, "W", response),
                    PerdidaNeta = sheet.DecimalValue(rowNumber, "X", response)
                }
            };

            data.TotalResPeriodo =
                    data.DesgloseResultadosPeriodo.UtilidadNeta +
                    data.DesgloseResultadosPeriodo.PerdidaNeta;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPatrimonioParticipacionesNoControladas ParticipacionesNoControladas(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPatrimonio patrimonio)
        {
            ModeloSituacionFinancieraDatosModeloPatrimonioParticipacionesNoControladas data = new ModeloSituacionFinancieraDatosModeloPatrimonioParticipacionesNoControladas()
            {
                DesgloseParticipacionesNoControladas = new ModeloSituacionFinancieraDatosModeloPatrimonioParticipacionesNoControladasDesgloseParticipacionesNoControladas()
                {
                    ParticipacionesNoControladas = sheet.DecimalValue(rowNumber, "Y", response)
                }
            };

            data.TotalParticipacionesNoControladas =
                    data.DesgloseParticipacionesNoControladas.ParticipacionesNoControladas;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloPatrimonioPatrimonioEnFondoOReservasEspeciales PatrimonioEnFondoOReservasEspeciales(DataTable response, IXLWorksheet sheet, int rowNumber, Domain.ModeloSituacionFinancieraDatosModeloPatrimonio patrimonio)
        {
            ModeloSituacionFinancieraDatosModeloPatrimonioPatrimonioEnFondoOReservasEspeciales data = new ModeloSituacionFinancieraDatosModeloPatrimonioPatrimonioEnFondoOReservasEspeciales()
            {
                DesglosePatrimonioEnFondoOReservasEspeciales = new ModeloSituacionFinancieraDatosModeloPatrimonioPatrimonioEnFondoOReservasEspecialesDesglosePatrimonioEnFondoOReservasEspeciales()
                {
                    FondosEspeciales = sheet.DecimalValue(rowNumber, "Z", response),
                    ReservasEspeciales = sheet.DecimalValue(rowNumber, "AA", response)
                }
            };

            data.TotalPatrimonioEnFondoOReservasEspeciales =
                    data.DesglosePatrimonioEnFondoOReservasEspeciales.FondosEspeciales +
                    data.DesglosePatrimonioEnFondoOReservasEspeciales.ReservasEspeciales;
            return data;
        }

    }
}
