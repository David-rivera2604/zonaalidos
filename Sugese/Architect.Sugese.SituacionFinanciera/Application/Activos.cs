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
    internal static class Activos
    {
        internal static Domain.ModeloSituacionFinancieraDatosModeloActivo Builder(DataTable response, XLWorkbook workbook, int rowNumber)
        {
            IXLWorksheet sheet;
            Domain.ModeloSituacionFinancieraDatosModeloActivo activo = new ModeloSituacionFinancieraDatosModeloActivo();

            sheet = workbook.Worksheet(1);
            activo.Disponibilidades = Disponibilidades(response, sheet, rowNumber);
            activo.InversionesInstrumentosFinancieros = InversionesInstrumentosFinancieros(response, sheet, rowNumber);
            activo.CarteraCreditos = CarteraCreditos(response, sheet, rowNumber);
            activo.ComisionesPrimasCuentasCobrar = ComisionesPrimasCuentasCobrar(response, sheet, rowNumber, activo);

            sheet = workbook.Worksheet(2);
            activo.ActivosContratosSeguros = ActivosContratosSeguros(response, sheet, rowNumber, activo);
            activo.ActivosContratosReaseguroMantenido = ActivosContratosReaseguroMantenido(response, sheet, rowNumber, activo);
            activo.BienesMantenidosParaVenta = BienesMantenidosParaVenta(response, sheet, rowNumber, activo);
            activo.PropiedadesMobilarioEquipo = PropiedadesMobilarioEquipo(response, sheet, rowNumber, activo);
            activo.OtrosActivos = OtrosActivos(response, sheet, rowNumber, activo);
            activo.PropiedadesDeInversion = PropiedadesDeInversion(response, sheet, rowNumber, activo);
            activo.ParticipacionOtrasEmpresas = ParticipacionOtrasEmpresas(response, sheet, rowNumber, activo);

            activo.TotalActivo =
                activo.Disponibilidades.TotalDisponibilidades +
                activo.InversionesInstrumentosFinancieros.TotalInversiones +
                activo.CarteraCreditos.TotalCartera +
                activo.ComisionesPrimasCuentasCobrar.TotalComisiones +
                activo.ActivosContratosSeguros.TotalActivosContratosSeguros +
                activo.ActivosContratosReaseguroMantenido.TotalActivosContratosReaseguroMantenido +
                activo.BienesMantenidosParaVenta.TotalBienesMantenidosParaVenta +
                activo.PropiedadesMobilarioEquipo.TotalPropiedadesMobilarioEquipo +
                activo.OtrosActivos.TotalOtrosActivos +
                activo.PropiedadesDeInversion.TotalPropiedadesDeInversion +
                activo.ParticipacionOtrasEmpresas.TotalPartOtrasEmpresas;

            return activo;
        }

        private static Domain.ModeloSituacionFinancieraDatosModeloActivoDisponibilidades Disponibilidades(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            Domain.ModeloSituacionFinancieraDatosModeloActivoDisponibilidades disponibilidades = new Domain.ModeloSituacionFinancieraDatosModeloActivoDisponibilidades()
            {
                DesgloseDisponibilidades = new Domain.ModeloSituacionFinancieraDatosModeloActivoDisponibilidadesDesgloseDisponibilidades()
                {
                    Efectivo = sheet.DecimalValue(rowNumber, "A", response),
                    DepVistaEnBCCR = sheet.DecimalValue(rowNumber, "B", response),
                    DepVistaEntidadesFinancierasPais = sheet.DecimalValue(rowNumber, "C", response),
                    DepVistaEntidadesFinancierasExterior = sheet.DecimalValue(rowNumber, "D", response),
                    DocCobroInmediato = sheet.DecimalValue(rowNumber, "E", response),
                    DispRestringidas = sheet.DecimalValue(rowNumber, "F", response),
                    CtasProductosCobrar = sheet.DecimalValue(rowNumber, "G", response)
                }
            };

            disponibilidades.TotalDisponibilidades =
                disponibilidades.DesgloseDisponibilidades.Efectivo +
                disponibilidades.DesgloseDisponibilidades.DepVistaEnBCCR +
                disponibilidades.DesgloseDisponibilidades.DepVistaEntidadesFinancierasPais +
                disponibilidades.DesgloseDisponibilidades.DepVistaEntidadesFinancierasExterior +
                disponibilidades.DesgloseDisponibilidades.DocCobroInmediato +
                disponibilidades.DesgloseDisponibilidades.DispRestringidas +
                disponibilidades.DesgloseDisponibilidades.CtasProductosCobrar;
            return disponibilidades;
        }

        private static ModeloSituacionFinancieraDatosModeloActivoInversionesInstrumentosFinancieros InversionesInstrumentosFinancieros(DataTable response, IXLWorksheet sheet, int rowNumber)
        {
            ModeloSituacionFinancieraDatosModeloActivoInversionesInstrumentosFinancieros inversiones = new ModeloSituacionFinancieraDatosModeloActivoInversionesInstrumentosFinancieros()
            {
                DesgloseInversionesInstrumentosFinancieros = new ModeloSituacionFinancieraDatosModeloActivoInversionesInstrumentosFinancierosDesgloseInversionesInstrumentosFinancieros()
                {
                    CambiosResultados = sheet.DecimalValue(rowNumber, "H", response),
                    CambiosResultadoIntegral = sheet.DecimalValue(rowNumber, "I", response),
                    CostoAmortizado = sheet.DecimalValue(rowNumber, "J", response),
                    EnCesacionPagosMorososLitigios = sheet.DecimalValue(rowNumber, "K", response),
                    VencidosRestringidos = sheet.DecimalValue(rowNumber, "L", response),
                    DifPosicionDerivados = sheet.DecimalValue(rowNumber, "M", response),
                    CtasProductosCobrar = sheet.DecimalValue(rowNumber, "N", response),
                    EstimacionDeterioro = sheet.DecimalValue(rowNumber, "O", response)
                }

            };

            inversiones.TotalInversiones =
                inversiones.DesgloseInversionesInstrumentosFinancieros.CambiosResultados +
                inversiones.DesgloseInversionesInstrumentosFinancieros.CambiosResultadoIntegral +
                inversiones.DesgloseInversionesInstrumentosFinancieros.CostoAmortizado +
                inversiones.DesgloseInversionesInstrumentosFinancieros.EnCesacionPagosMorososLitigios +
                inversiones.DesgloseInversionesInstrumentosFinancieros.VencidosRestringidos +
                inversiones.DesgloseInversionesInstrumentosFinancieros.DifPosicionDerivados +
                inversiones.DesgloseInversionesInstrumentosFinancieros.CtasProductosCobrar +
                inversiones.DesgloseInversionesInstrumentosFinancieros.EstimacionDeterioro;
            return inversiones;
        }

        private static ModeloSituacionFinancieraDatosModeloActivoCarteraCreditos CarteraCreditos(DataTable response, IXLWorksheet sheet, int rowNumber)
        {

            ModeloSituacionFinancieraDatosModeloActivoCarteraCreditos cartera = new ModeloSituacionFinancieraDatosModeloActivoCarteraCreditos()
            {
                DesgloseCarteraCreditos = new ModeloSituacionFinancieraDatosModeloActivoCarteraCreditosDesgloseCarteraCreditos()
                {
                    Vigentes = sheet.DecimalValue(rowNumber, "P", response),
                    Vencidos = sheet.DecimalValue(rowNumber, "Q", response),
                    CobroJudicial = sheet.DecimalValue(rowNumber, "R", response),
                    Restringidos = sheet.DecimalValue(rowNumber, "S", response),
                    CostosDirectosIncrementales = sheet.DecimalValue(rowNumber, "T", response),
                    IngresosDiferidos = sheet.DecimalValue(rowNumber, "U", response),
                    CtasProductosPorCobrar = sheet.DecimalValue(rowNumber, "V", response),
                    EstimacionDeterioro = sheet.DecimalValue(rowNumber, "W", response)
                }

            };

            cartera.TotalCartera =
                cartera.DesgloseCarteraCreditos.Vigentes +
                cartera.DesgloseCarteraCreditos.Vencidos +
                cartera.DesgloseCarteraCreditos.CobroJudicial +
                cartera.DesgloseCarteraCreditos.Restringidos +
                cartera.DesgloseCarteraCreditos.CostosDirectosIncrementales +
                cartera.DesgloseCarteraCreditos.IngresosDiferidos +
                cartera.DesgloseCarteraCreditos.CtasProductosPorCobrar +
                cartera.DesgloseCarteraCreditos.EstimacionDeterioro;
            return cartera;
        }

        private static ModeloSituacionFinancieraDatosModeloActivoComisionesPrimasCuentasCobrar ComisionesPrimasCuentasCobrar(DataTable response, IXLWorksheet sheet, int rowNumber, ModeloSituacionFinancieraDatosModeloActivo activo)
        {
            ModeloSituacionFinancieraDatosModeloActivoComisionesPrimasCuentasCobrar comisiones = new ModeloSituacionFinancieraDatosModeloActivoComisionesPrimasCuentasCobrar()
            {
                DesgloseComisionesPrimasCuentasCobrar = new ModeloSituacionFinancieraDatosModeloActivoComisionesPrimasCuentasCobrarDesgloseComisionesPrimasCuentasCobrar()
                {
                    ComisionesCobrar = sheet.DecimalValue(rowNumber, "X", response),
                    CtasCobrarOperacionesPartesRelacionadas = sheet.DecimalValue(rowNumber, "Y", response),
                    ImpDiferidoImpCobrar = sheet.DecimalValue(rowNumber, "Z", response),
                    OtrasCtasCobrar = sheet.DecimalValue(rowNumber, "AA", response),
                    ProductosCobrarAsociadosCuentasCobrar = sheet.DecimalValue(rowNumber, "AB", response),
                    EstimacionDeterioro = sheet.DecimalValue(rowNumber, "AC", response)
                }
            };

            comisiones.TotalComisiones =
                comisiones.DesgloseComisionesPrimasCuentasCobrar.ComisionesCobrar +
                comisiones.DesgloseComisionesPrimasCuentasCobrar.CtasCobrarOperacionesPartesRelacionadas +
                comisiones.DesgloseComisionesPrimasCuentasCobrar.ImpDiferidoImpCobrar +
                comisiones.DesgloseComisionesPrimasCuentasCobrar.OtrasCtasCobrar +
                comisiones.DesgloseComisionesPrimasCuentasCobrar.ProductosCobrarAsociadosCuentasCobrar +
                comisiones.DesgloseComisionesPrimasCuentasCobrar.EstimacionDeterioro;
            return comisiones;
        }

        private static ModeloSituacionFinancieraDatosModeloActivoActivosContratosSeguros ActivosContratosSeguros(DataTable response, IXLWorksheet sheet, int rowNumber, ModeloSituacionFinancieraDatosModeloActivo activo)
        {
            ModeloSituacionFinancieraDatosModeloActivoActivosContratosSeguros activos = new ModeloSituacionFinancieraDatosModeloActivoActivosContratosSeguros()
            {
                DesgloseActivosContratosSeguros = new ModeloSituacionFinancieraDatosModeloActivoActivosContratosSegurosDesgloseActivosContratosSeguros()
                {
                    ContratosOnerosos = sheet.DecimalValue(rowNumber, "A", response),
                    ContratosNoOnerosos = sheet.DecimalValue(rowNumber, "B", response),
                    ContratosReaseguroAceptadoOnerosos = sheet.DecimalValue(rowNumber, "C", response),
                    ContratosReaseguroAceptadoNoOnerosos = sheet.DecimalValue(rowNumber, "D", response)
                }
            };

            activos.TotalActivosContratosSeguros =
                activos.DesgloseActivosContratosSeguros.ContratosOnerosos +
                activos.DesgloseActivosContratosSeguros.ContratosNoOnerosos +
                activos.DesgloseActivosContratosSeguros.ContratosReaseguroAceptadoOnerosos +
                activos.DesgloseActivosContratosSeguros.ContratosReaseguroAceptadoNoOnerosos;
            return activos;
        }

        private static ModeloSituacionFinancieraDatosModeloActivoActivosContratosReaseguroMantenido ActivosContratosReaseguroMantenido(DataTable response, IXLWorksheet sheet, int rowNumber, ModeloSituacionFinancieraDatosModeloActivo activo)
        {
            ModeloSituacionFinancieraDatosModeloActivoActivosContratosReaseguroMantenido activos = new ModeloSituacionFinancieraDatosModeloActivoActivosContratosReaseguroMantenido()
            {
                DesgloseActivosContratosReaseguroMantenido = new ModeloSituacionFinancieraDatosModeloActivoActivosContratosReaseguroMantenidoDesgloseActivosContratosReaseguroMantenido()
                {
                    ContratosReaseguroMantenido = sheet.DecimalValue(rowNumber, "E", response)
                }
            };

            activos.TotalActivosContratosReaseguroMantenido =
                activos.DesgloseActivosContratosReaseguroMantenido.ContratosReaseguroMantenido;
            return activos;
        }

        private static ModeloSituacionFinancieraDatosModeloActivoBienesMantenidosParaVenta BienesMantenidosParaVenta(DataTable response, IXLWorksheet sheet, int rowNumber, ModeloSituacionFinancieraDatosModeloActivo activo)
        {
            ModeloSituacionFinancieraDatosModeloActivoBienesMantenidosParaVenta bienes = new ModeloSituacionFinancieraDatosModeloActivoBienesMantenidosParaVenta()
            {
                DesgloseBienesMantenidosParaVenta = new ModeloSituacionFinancieraDatosModeloActivoBienesMantenidosParaVentaDesgloseBienesMantenidosParaVenta()
                {
                    AdquiridosRecuperacionCreditos = sheet.DecimalValue(rowNumber, "F", response),
                    PropiedadesMobiliarioEquipoFueraDeUso = sheet.DecimalValue(rowNumber, "G", response),
                    OtrosBienes = sheet.DecimalValue(rowNumber, "H", response),
                    ProductosCobrarAsociados = sheet.DecimalValue(rowNumber, "I", response),
                    EstimacionDeterioro = sheet.DecimalValue(rowNumber, "J", response)
                }
            };

            bienes.TotalBienesMantenidosParaVenta =
                bienes.DesgloseBienesMantenidosParaVenta.AdquiridosRecuperacionCreditos +
                bienes.DesgloseBienesMantenidosParaVenta.PropiedadesMobiliarioEquipoFueraDeUso +
                bienes.DesgloseBienesMantenidosParaVenta.OtrosBienes +
                bienes.DesgloseBienesMantenidosParaVenta.ProductosCobrarAsociados +
                bienes.DesgloseBienesMantenidosParaVenta.EstimacionDeterioro;
            return bienes;
        }

        private static ModeloSituacionFinancieraDatosModeloActivoPropiedadesMobilarioEquipo PropiedadesMobilarioEquipo(DataTable response, IXLWorksheet sheet, int rowNumber, ModeloSituacionFinancieraDatosModeloActivo activo)
        {
            ModeloSituacionFinancieraDatosModeloActivoPropiedadesMobilarioEquipo propiedades = new ModeloSituacionFinancieraDatosModeloActivoPropiedadesMobilarioEquipo()
            {
                DesglosePropiedadesMobilarioEquipo = new ModeloSituacionFinancieraDatosModeloActivoPropiedadesMobilarioEquipoDesglosePropiedadesMobilarioEquipo()
                {
                    Mobiliario = sheet.DecimalValue(rowNumber, "K", response),
                    Computacion = sheet.DecimalValue(rowNumber, "L", response),
                    Vehiculos = sheet.DecimalValue(rowNumber, "M", response),
                    PorDerechoDeUso = sheet.DecimalValue(rowNumber, "N", response),
                    Terrenos = sheet.DecimalValue(rowNumber, "O", response),
                    EdificiosInstalaciones = sheet.DecimalValue(rowNumber, "P", response),
                    OtrosActivosOperativos = sheet.DecimalValue(rowNumber, "Q", response),
                    DepreciacionAcumulada = sheet.DecimalValue(rowNumber, "R", response)
                }
            };

            propiedades.TotalPropiedadesMobilarioEquipo =
                propiedades.DesglosePropiedadesMobilarioEquipo.Mobiliario +
                propiedades.DesglosePropiedadesMobilarioEquipo.Computacion +
                propiedades.DesglosePropiedadesMobilarioEquipo.Vehiculos +
                propiedades.DesglosePropiedadesMobilarioEquipo.PorDerechoDeUso +
                propiedades.DesglosePropiedadesMobilarioEquipo.Terrenos +
                propiedades.DesglosePropiedadesMobilarioEquipo.EdificiosInstalaciones +
                propiedades.DesglosePropiedadesMobilarioEquipo.OtrosActivosOperativos +
                propiedades.DesglosePropiedadesMobilarioEquipo.DepreciacionAcumulada;
            return propiedades;
        }

        private static ModeloSituacionFinancieraDatosModeloActivoOtrosActivos OtrosActivos(DataTable response, IXLWorksheet sheet, int rowNumber, ModeloSituacionFinancieraDatosModeloActivo activo)
        {

            ModeloSituacionFinancieraDatosModeloActivoOtrosActivos data = new ModeloSituacionFinancieraDatosModeloActivoOtrosActivos()
            {
                DesgloseOtrosActivos = new ModeloSituacionFinancieraDatosModeloActivoOtrosActivosDesgloseOtrosActivos()
                {
                    GastosPagadosAnticipado = sheet.DecimalValue(rowNumber, "S", response),
                    CargosDiferidos = sheet.DecimalValue(rowNumber, "T", response),
                    BienesDiversos = sheet.DecimalValue(rowNumber, "U", response),
                    OperacionesPendientesImputacion = sheet.DecimalValue(rowNumber, "V", response),
                    CtasReciprocasInternas = sheet.DecimalValue(rowNumber, "W", response),
                    ActivosIntangibles = sheet.DecimalValue(rowNumber, "X", response),
                    OtrosActivosRestringidos = sheet.DecimalValue(rowNumber, "Y", response)
                }
            };

            data.TotalOtrosActivos =
                data.DesgloseOtrosActivos.GastosPagadosAnticipado +
                data.DesgloseOtrosActivos.CargosDiferidos +
                data.DesgloseOtrosActivos.BienesDiversos +
                data.DesgloseOtrosActivos.OperacionesPendientesImputacion +
                data.DesgloseOtrosActivos.CtasReciprocasInternas +
                data.DesgloseOtrosActivos.ActivosIntangibles +
                data.DesgloseOtrosActivos.OtrosActivosRestringidos;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloActivoPropiedadesDeInversion PropiedadesDeInversion(DataTable response, IXLWorksheet sheet, int rowNumber, ModeloSituacionFinancieraDatosModeloActivo activo)
        {
            ModeloSituacionFinancieraDatosModeloActivoPropiedadesDeInversion data = new ModeloSituacionFinancieraDatosModeloActivoPropiedadesDeInversion()
            {
                DesglosePropiedadesDeInversion = new ModeloSituacionFinancieraDatosModeloActivoPropiedadesDeInversionDesglosePropiedadesDeInversion()
                {
                    Terrenos = sheet.DecimalValue(rowNumber, "Z", response),
                    Edificios = sheet.DecimalValue(rowNumber, "AA", response)
                }
            };

            data.TotalPropiedadesDeInversion =
                data.DesglosePropiedadesDeInversion.Terrenos +
                data.DesglosePropiedadesDeInversion.Edificios;
            return data;
        }

        private static ModeloSituacionFinancieraDatosModeloActivoParticipacionOtrasEmpresas ParticipacionOtrasEmpresas(DataTable response, IXLWorksheet sheet, int rowNumber, ModeloSituacionFinancieraDatosModeloActivo activo)
        {
            ModeloSituacionFinancieraDatosModeloActivoParticipacionOtrasEmpresas data = new ModeloSituacionFinancieraDatosModeloActivoParticipacionOtrasEmpresas()
            {
                DesgloseParticipacionOtrasEmpresas = new ModeloSituacionFinancieraDatosModeloActivoParticipacionOtrasEmpresasDesgloseParticipacionOtrasEmpresas()
                {
                    DelPais = sheet.DecimalValue(rowNumber, "AB", response),
                    DelExterior = sheet.DecimalValue(rowNumber, "AC", response),
                    VehiculosPropositoEspecialPais = sheet.DecimalValue(rowNumber, "AD", response),
                    Deterioro = sheet.DecimalValue(rowNumber, "AE", response)
                }
            };

            data.TotalPartOtrasEmpresas =
                data.DesgloseParticipacionOtrasEmpresas.DelPais +
                data.DesgloseParticipacionOtrasEmpresas.DelExterior +
                data.DesgloseParticipacionOtrasEmpresas.VehiculosPropositoEspecialPais +
                data.DesgloseParticipacionOtrasEmpresas.Deterioro;
            return data;
        }

    }
}
