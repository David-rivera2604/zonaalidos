Imports System.Configuration
Imports Architect.Sugese.Domain
Imports Architect.Sugese.Utility
Imports Architect.Utilities.Extensions
Imports ClosedXML.Excel

Public Class Generate
    Inherits Architect.Sugese.Domain.GenerateBase

    Private validateRamo(33) As Decimal
    Private validateLinea(33) As Decimal

    Private _CuentaTecnica As New ModeloCuentaTecnica

    Public Property Response As DataTable

    Private ramoActual As TipoRamo
    Private lineaActual As Linea

    Private sheetName As String

    Public Property Encabezado() As ModeloCuentaTecnicaEncabezado
        Get
            Return _CuentaTecnica.Encabezado
        End Get
        Set(ByVal value As ModeloCuentaTecnicaEncabezado)
            _CuentaTecnica.Encabezado = value
        End Set
    End Property

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="periodo">Fecha correspondiente al período al cual corresponde el modelo</param>
    ''' <remarks></remarks>
    Public Sub New(periodo As Date)
        ModelInit()
        With _CuentaTecnica.Encabezado
            .NombreArchivo = String.Format("{0}-ModeloCuentaTecnica", ConfigurationManager.AppSettings("sugese.entidadaseguradora"))
            .Fecha = Today.ToString("yyyy-MM-dd")
            .Periodo = periodo.ToString("yyyy-MM-dd")
            .Periodicidad = Periodicidad.T
            .Moneda = CodMoneda.Item1
        End With
        Me.Response = Helpers.XmlRespose.ReponseDataTable
        _CuentaTecnica.Datos.Modelo.EntidadFuente = ConfigurationManager.AppSettings("sugese.codigoaseguradora")
    End Sub

    Private Sub ModelInit()
        _CuentaTecnica = New ModeloCuentaTecnica
        With _CuentaTecnica
            .Encabezado = New ModeloCuentaTecnicaEncabezado
            .Datos = New ModeloCuentaTecnicaDatos
        End With
        With _CuentaTecnica.Encabezado
            .NombreArchivo = String.Empty
            .Fecha = String.Empty
            .Periodo = String.Empty
            .Periodicidad = Periodicidad.T
            .Moneda = CodMoneda.Item1
        End With

        With _CuentaTecnica.Datos
            .Modelo = New ModeloCuentaTecnicaDatosModelo
        End With
        With _CuentaTecnica.Datos.Modelo
            .UtilidadPerdidaNetaAntesImpuestosParticipaciones = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipaciones
            .EntidadFuente = String.Empty
        End With
        With _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones
            '.ResultadoCuentaTecnicoFinanciera(0) = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera
            .ResultadoCuentaNoTecnica = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaNoTecnica
            .TotalUtilidadPerdidaNetaAntesImpuestosParticipaciones = 0
        End With
        With _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaNoTecnica
            .IngresosFinancieros = "0.00"
            .GastosFinancieros = "0.00"
            .OtrosIngresosNoTecnicos = "0.00"
            .OtrosGastosNoTecnicos = "0.00"
            .TotalCuentaNoTecnica = "0.00"
        End With
    End Sub

    Public Shared Function AddLineaCuentaTecnica() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_ln
        Dim result As New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_ln

        With result
            .PrimasImputadasNetasReaseguro_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_ln
            .SiniestralidadNetaReaseguro_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_ln
            .ParticipacionBeneficiosExtornos_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnParticipacionBeneficiosExtornos_ln
            .VariacionOtrasProvisionesTecnicasNetasReaseguro_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_ln
            .GastosExplotacionNetos_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnGastosExplotacionNetos_ln
            .OtrosIngresosTecnicos_ln = 0
            .OtrosGastosTecnicos_ln = 0
            .TotalCuentaTecnica = 0
        End With
        With result.PrimasImputadasNetasReaseguro_ln
            .IngresoPrimas_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_ln
            .PrimasReaseguroCedidoRetrocedido_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnPrimasReaseguroCedidoRetrocedido_ln
            .VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln
            .VariacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedido_ln = 0
            .TotalPrimasImputadasNetasReaseguro = 0
        End With
        With result.PrimasImputadasNetasReaseguro_ln.IngresoPrimas_ln
            .DesgloseIngresoPrimas_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_lnDesgloseIngresoPrimas_ln
            .TotalIngresoPrimas = 0
        End With
        With result.PrimasImputadasNetasReaseguro_ln.PrimasReaseguroCedidoRetrocedido_ln
            .DesglosePrimasReaseguroCedidoRetrocedido_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnPrimasReaseguroCedidoRetrocedido_lnDesglosePrimasReaseguroCedidoRetrocedido_ln With {.PrimasCedidasReaseguroProporcional = 0, .PrimasPagadasReaseguroNoProporcional = 0}
            .TotalPrimasReaseguroCedidoRetrocedido = 0
        End With
        With result.PrimasImputadasNetasReaseguro_ln.IngresoPrimas_ln.DesgloseIngresoPrimas_ln
            .SeguroDirecto_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_lnDesgloseIngresoPrimas_lnSeguroDirecto_ln
            .ReaseguroAceptado = 0
            .VariacionEstimacionDeterioroPrimasVencidas = 0
        End With
        With result.PrimasImputadasNetasReaseguro_ln.IngresoPrimas_ln.DesgloseIngresoPrimas_ln.SeguroDirecto_ln
            .DesgloseSeguroDirecto_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_lnDesgloseIngresoPrimas_lnSeguroDirecto_lnDesgloseSeguroDirecto_ln With {.PrimasAnuladasExtornadasPeriodo = 0, .PrimasAnuladasExtornadasPeriodosAnteriores = 0, .PrimasEmitidas = 0, .VariacionPrimasPolizasFlotantes = 0}
            .TotalSeguroDirecto = 0
        End With

        With result.PrimasImputadasNetasReaseguro_ln.VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln
            .DesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_lnDesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln
            .TotalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas = 0
        End With
        With result.PrimasImputadasNetasReaseguro_ln.VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln.DesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln
            .SeguroDirecto = 0
            .ReaseguroAceptado = 0
        End With

        With result.SiniestralidadNetaReaseguro_ln
            .SiniestrosPagados_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnSiniestrosPagados_ln
            .SiniestrosGastosRecuperadosPorReaseguroCedidoRetrocedido_ln = 0
            .VariacionProvisionParaSiniestros_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnVariacionProvisionParaSiniestros_ln
            .VariacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedido_ln = 0
            .GastosImputablesSiniestros_ln = 0
            .TotalSiniestralidadNetaReaseguro = 0
        End With
        With result.SiniestralidadNetaReaseguro_ln.SiniestrosPagados_ln
            .DesgloseSiniestrosPagados_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnSiniestrosPagados_lnDesgloseSiniestrosPagados_ln
            .TotalSiniestrosPagados = 0
        End With
        With result.SiniestralidadNetaReaseguro_ln.SiniestrosPagados_ln.DesgloseSiniestrosPagados_ln
            .SeguroDirecto = 0
            .ReaseguroAceptado = 0
        End With

        With result.SiniestralidadNetaReaseguro_ln.VariacionProvisionParaSiniestros_ln
            .DesgloseVariacionProvisionParaSiniestros_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnVariacionProvisionParaSiniestros_lnDesgloseVariacionProvisionParaSiniestros_ln
            .TotalVariacionProvisionParaSiniestros = 0
        End With
        With result.SiniestralidadNetaReaseguro_ln.VariacionProvisionParaSiniestros_ln.DesgloseVariacionProvisionParaSiniestros_ln
            .SeguroDirecto = 0
            .ReaseguroAceptado = 0
        End With

        With result.ParticipacionBeneficiosExtornos_ln
            .DesgloseParticipacionBeneficiosExtornos_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnParticipacionBeneficiosExtornos_lnDesgloseParticipacionBeneficiosExtornos_ln
            .TotalParticipacionBeneficiosExtornos = 0
        End With
        With result.ParticipacionBeneficiosExtornos_ln.DesgloseParticipacionBeneficiosExtornos_ln
            .PrestacionesGastosParticipacionBeneficiosExtornos = 0
            .VariacionProvisionParticipacionBeneficiosExtornos = 0
        End With

        With result.VariacionOtrasProvisionesTecnicasNetasReaseguro_ln
            .VariacionProvisionMatematica_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionProvisionMatematica_ln
            .VariacionParticipacionReaseguradorProvisionMatematica_ln = 0
            .VariacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSeguros_ln = 0
            .VariacionOtrasProvisionesTecnicas_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionOtrasProvisionesTecnicas_ln
            .VariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln
            .TotalVariacionOtrasProvisionesTecnicasNetasReaseguro = 0
        End With
        With result.VariacionOtrasProvisionesTecnicasNetasReaseguro_ln.VariacionProvisionMatematica_ln
            .DesgloseVariacionProvisionMatematica_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionProvisionMatematica_lnDesgloseVariacionProvisionMatematica_ln
            .TotalVariacionProvisionMatematica = 0
        End With
        With result.VariacionOtrasProvisionesTecnicasNetasReaseguro_ln.VariacionProvisionMatematica_ln.DesgloseVariacionProvisionMatematica_ln
            .SeguroDirecto = 0
            .ReaseguroAceptado = 0
        End With

        With result.VariacionOtrasProvisionesTecnicasNetasReaseguro_ln.VariacionOtrasProvisionesTecnicas_ln
            .DesgloseVariacionOtrasProvisionesTecnicas_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionOtrasProvisionesTecnicas_lnDesgloseVariacionOtrasProvisionesTecnicas_ln
            .TotalVariacionOtrasProvisionesTecnicas = 0
        End With
        With result.VariacionOtrasProvisionesTecnicasNetasReaseguro_ln.VariacionOtrasProvisionesTecnicas_ln.DesgloseVariacionOtrasProvisionesTecnicas_ln
            .SeguroDirecto = 0
            .ReaseguroAceptado = 0
        End With

        With result.VariacionOtrasProvisionesTecnicasNetasReaseguro_ln.VariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln
            .DesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_lnDesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln
            .TotalVariacionParticipacionReaseguradorOtrasProvisionesTecnicas = 0
        End With
        With result.VariacionOtrasProvisionesTecnicasNetasReaseguro_ln.VariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln.DesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln
            .SeguroDirecto = 0
            .ReaseguroAceptado = 0
        End With

        With result.GastosExplotacionNetos_ln
            .DesgloseGastosExplotacionNetos_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnGastosExplotacionNetos_lnDesgloseGastosExplotacionNetos_ln
            .TotalGastosExplotacionNetos = 0
        End With
        With result.GastosExplotacionNetos_ln.DesgloseGastosExplotacionNetos_ln
            .GastosAdquisicion = 0
            .GastosAdministracion = 0
            .ComisionesParticipacionesReaseguroCedidoRetrocedido = 0
        End With

        Return result
    End Function

    Public Shared Function AddLineaCuentaTecnicoFinanciera() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_ln
        Dim result As New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_ln
        'ReDim Preserve items(UBound(items) + 1)
        'items(UBound(items)) = result
        'With result
        '    .ResultadoCuentaTecnicoFinanciera = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera
        '    .idLinea = Linea.G0668
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera
        '    .ResultadoCuentaTecnica = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnica
        '    .ResultadoCuentaFinanciera = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaFinanciera
        '    .TotalCuentaTecnicoFinanciera_ln = 0
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica
        '    .PrimasImputadasNetasReaseguro = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguro
        '    .SiniestralidadNetaReaseguro = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguro
        '    .ParticipacionBeneficiosExtornos = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaParticipacionBeneficiosExtornos
        '    .VariacionOtrasProvisionesTecnicasNetasReaseguro = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguro
        '    .GastosExplotacionNetos = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaGastosExplotacionNetos
        '    .OtrosIngresosTecnicos_ln = 0
        '    .OtrosGastosTecnicos_ln = 0
        '    .TotalCuentaTecnica = 0
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro
        '    .IngresoPrimas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimas
        '    .PrimasReaseguroCedidoRetrocedido_ln = 0
        '    .VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas
        '    .VariacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedido_ln = 0
        '    .TotalPrimasImputadasNetasReaseguro = 0
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.IngresoPrimas
        '    .DesgloseIngresoPrimas_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimas_ln
        '    .TotalIngresoPrimas = 0
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.IngresoPrimas.DesgloseIngresoPrimas_ln
        '    .SeguroDirecto = 0
        '    .ReaseguroAceptado = 0
        '    .VariacionEstimacionDeterioroPrimasVencidas = 0
        'End With

        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas
        '    .DesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasDesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln
        '    .TotalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas = 0
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas.DesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln
        '    .SeguroDirecto = 0
        '    .ReaseguroAceptado = 0
        'End With

        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro
        '    .SiniestrosPagados = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroSiniestrosPagados
        '    .SiniestrosGastosRecuperadosPorReaseguroCedidoRetrocedido_ln = 0
        '    .VariacionProvisionParaSiniestros = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroVariacionProvisionParaSiniestros
        '    .VariacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedido_ln = 0
        '    .GastosImputablesSiniestros_ln = 0
        '    .TotalSiniestralidadNetaReaseguro = 0
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro.SiniestrosPagados
        '    .DesgloseSiniestrosPagados_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroSiniestrosPagadosDesgloseSiniestrosPagados_ln
        '    .TotalSiniestrosPagados = 0
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro.SiniestrosPagados.DesgloseSiniestrosPagados_ln
        '    .SeguroDirecto = 0
        '    .ReaseguroAceptado = 0
        'End With

        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro.VariacionProvisionParaSiniestros
        '    .DesgloseVariacionProvisionParaSiniestros_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroVariacionProvisionParaSiniestrosDesgloseVariacionProvisionParaSiniestros_ln
        '    .TotalVariacionProvisionParaSiniestros = 0
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro.VariacionProvisionParaSiniestros.DesgloseVariacionProvisionParaSiniestros_ln
        '    .SeguroDirecto = 0
        '    .ReaseguroAceptado = 0
        'End With

        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.ParticipacionBeneficiosExtornos
        '    .DesgloseParticipacionBeneficiosExtornos_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaParticipacionBeneficiosExtornosDesgloseParticipacionBeneficiosExtornos_ln
        '    .TotalParticipacionBeneficiosExtornos = 0
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.ParticipacionBeneficiosExtornos.DesgloseParticipacionBeneficiosExtornos_ln
        '    .PrestacionesGastosParticipacionBeneficiosExtornos = 0
        '    .VariacionProvisionParticipacionBeneficiosExtornos = 0
        'End With

        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro
        '    .VariacionProvisionMatematica = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionProvisionMatematica
        '    .VariacionParticipacionReaseguradorProvisionMatematica_ln = 0
        '    .VariacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSeguros_ln = 0
        '    .VariacionOtrasProvisionesTecnicas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionOtrasProvisionesTecnicas
        '    .VariacionParticipacionReaseguradorOtrasProvisionesTecnicas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionParticipacionReaseguradorOtrasProvisionesTecnicas
        '    .TotalVariacionOtrasProvisionesTecnicasNetasReaseguro = 0
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionProvisionMatematica
        '    .DesgloseVariacionProvisionMatematica_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionProvisionMatematicaDesgloseVariacionProvisionMatematica_ln
        '    .TotalVariacionProvisionMatematica = 0
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionProvisionMatematica.DesgloseVariacionProvisionMatematica_ln
        '    .SeguroDirecto = 0
        '    .ReaseguroAceptado = 0
        'End With

        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionOtrasProvisionesTecnicas
        '    .DesgloseVariacionOtrasProvisionesTecnicas_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionOtrasProvisionesTecnicasDesgloseVariacionOtrasProvisionesTecnicas_ln
        '    .TotalVariacionOtrasProvisionesTecnicas = 0
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionOtrasProvisionesTecnicas.DesgloseVariacionOtrasProvisionesTecnicas_ln
        '    .SeguroDirecto = 0
        '    .ReaseguroAceptado = 0
        'End With

        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionParticipacionReaseguradorOtrasProvisionesTecnicas
        '    .DesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionParticipacionReaseguradorOtrasProvisionesTecnicasDesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln
        '    .TotalVariacionParticipacionReaseguradorOtrasProvisionesTecnicas = 0
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionParticipacionReaseguradorOtrasProvisionesTecnicas.DesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln
        '    .SeguroDirecto = 0
        '    .ReaseguroAceptado = 0
        'End With

        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.GastosExplotacionNetos
        '    .DesgloseGastosExplotacionNetos_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaGastosExplotacionNetosDesgloseGastosExplotacionNetos_ln
        '    .TotalGastosExplotacionNetos = 0
        'End With
        'With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.GastosExplotacionNetos.DesgloseGastosExplotacionNetos_ln
        '    .GastosAdquisicion = 0
        '    .GastosAdministracion = 0
        '    .ComisionesParticipacionesReaseguroCedidoRetrocedido = 0
        'End With

        With result
            .IngresosFinancieros_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnIngresosFinancieros_ln
            .GastosFinancieros_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnGastosFinancieros_ln
            .TotalCuentaFinanciera = 0
        End With
        With result.IngresosFinancieros_ln
            .DesgloseIngresosFinancieros_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnIngresosFinancieros_lnDesgloseIngresosFinancieros_ln
            .TotalIngresosFinancieros = 0
        End With

        With result.GastosFinancieros_ln
            .DesgloseGastosFinancieros_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnGastosFinancieros_lnDesgloseGastosFinancieros_ln
            .TotalGastosFinancieros = 0
        End With
        With result.GastosFinancieros_ln.DesgloseGastosFinancieros_ln
            .GastosFinancieros = 0
            .GastosFinancierosTomadorAsumeRiesgoInversion = 0
        End With

        Return result
    End Function

    Public Shared Function AddResultadoCuentaTecnicoFinanciera(items As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera()) As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera
        Dim result As New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .ResultadoCuentaTecnica = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnica
            .ResultadoCuentaFinanciera = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinanciera
            .Lineas(0) = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLinea
            .idRamo = TipoRamo.G01
            .TotalCuentaTecnicoFinanciera = 0
        End With
        With result.ResultadoCuentaTecnica
            .PrimasImputadasNetasReaseguro = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguro
            .SiniestralidadNetaReaseguro = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguro
            .ParticipacionBeneficiosExtornos = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaParticipacionBeneficiosExtornos
            .VariacionOtrasProvisionesTecnicasNetasReaseguro = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguro
            .GastosExplotacionNetos = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaGastosExplotacionNetos
            .OtrosIngresosTecnicos = 0
            .OtrosGastosTecnicos = 0
            .TotalCuentaTecnica = 0
        End With
        With result.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro
            .IngresoPrimas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimas
            .PrimasReaseguroCedidoRetrocedido = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroPrimasReaseguroCedidoRetrocedido
            .VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas
            .VariacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedido = 0
            .TotalPrimasImputadasNetasReaseguro = 0
        End With
        With result.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.IngresoPrimas
            .DesgloseIngresoPrimas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimas
            .TotalIngresoPrimas = 0
        End With
        With result.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.PrimasReaseguroCedidoRetrocedido
            .DesglosePrimasReaseguroCedidoRetrocedido = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroPrimasReaseguroCedidoRetrocedidoDesglosePrimasReaseguroCedidoRetrocedido With {.PrimasCedidasReaseguroProporcional = 0, .PrimasPagadasReaseguroNoProporcional = 0}
            .TotalPrimasReaseguroCedidoRetrocedido = 0
        End With
        With result.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.IngresoPrimas.DesgloseIngresoPrimas
            .SeguroDirecto = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimasSeguroDirecto
            .ReaseguroAceptado = 0
            .VariacionEstimacionDeterioroPrimasVencidas = 0
        End With
        With result.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.IngresoPrimas.DesgloseIngresoPrimas.SeguroDirecto
            .DesgloseSeguroDirecto = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimasSeguroDirectoDesgloseSeguroDirecto With {.PrimasAnuladasExtornadasPeriodo = 0, .PrimasAnuladasExtornadasPeriodosAnteriores = 0, .PrimasEmitidas = 0, .VariacionPrimasPolizasFlotantes = 0}
            .TotalSeguroDirecto = 0
        End With

        With result.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas
            .DesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasDesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas
            .TotalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas = 0
        End With
        With result.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas.DesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas
            .SeguroDirecto = 0
            .ReaseguroAceptado = 0
        End With

        With result.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro
            .SiniestrosPagados = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroSiniestrosPagados
            .SiniestrosGastosRecuperadosPorReaseguroCedidoRetrocedido = 0
            .VariacionProvisionParaSiniestros = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroVariacionProvisionParaSiniestros
            .VariacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedido = 0
            .GastosImputablesSiniestros = 0
            .TotalSiniestralidadNetaReaseguro = 0
        End With
        With result.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro.SiniestrosPagados
            .DesgloseSiniestrosPagados = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroSiniestrosPagadosDesgloseSiniestrosPagados
            .TotalSiniestrosPagados = 0
        End With
        With result.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro.SiniestrosPagados.DesgloseSiniestrosPagados
            .SeguroDirecto = 0
            .ReaseguroAceptado = 0
        End With

        With result.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro.VariacionProvisionParaSiniestros
            .DesgloseVariacionProvisionParaSiniestros = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroVariacionProvisionParaSiniestrosDesgloseVariacionProvisionParaSiniestros
            .TotalVariacionProvisionParaSiniestros = 0
        End With
        With result.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro.VariacionProvisionParaSiniestros.DesgloseVariacionProvisionParaSiniestros
            .SeguroDirecto = 0
            .ReaseguroAceptado = 0
        End With

        With result.ResultadoCuentaTecnica.ParticipacionBeneficiosExtornos
            .DesgloseParticipacionBeneficiosExtornos = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaParticipacionBeneficiosExtornosDesgloseParticipacionBeneficiosExtornos
            .TotalParticipacionBeneficiosExtornos = 0
        End With
        With result.ResultadoCuentaTecnica.ParticipacionBeneficiosExtornos.DesgloseParticipacionBeneficiosExtornos
            .PrestacionesGastosParticipacionBeneficiosExtornos = 0
            .VariacionProvisionParticipacionBeneficiosExtornos = 0
        End With

        With result.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro
            .VariacionProvisionMatematica = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionProvisionMatematica
            .VariacionParticipacionReaseguradorProvisionMatematica = 0
            .VariacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSeguros = 0
            .VariacionOtrasProvisionesTecnicas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionOtrasProvisionesTecnicas
            .VariacionParticipacionReaseguradorOtrasProvisionesTecnicas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionParticipacionReaseguradorOtrasProvisionesTecnicas
            .TotalVariacionOtrasProvisionesTecnicasNetasReaseguro = 0
        End With
        With result.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionProvisionMatematica
            .DesgloseVariacionProvisionMatematica = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionProvisionMatematicaDesgloseVariacionProvisionMatematica
            .TotalVariacionProvisionMatematica = 0
        End With
        With result.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionProvisionMatematica.DesgloseVariacionProvisionMatematica
            .SeguroDirecto = 0
            .ReaseguroAceptado = 0
        End With

        With result.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionOtrasProvisionesTecnicas
            .DesgloseVariacionOtrasProvisionesTecnicas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionOtrasProvisionesTecnicasDesgloseVariacionOtrasProvisionesTecnicas
            .TotalVariacionOtrasProvisionesTecnicas = 0
        End With
        With result.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionOtrasProvisionesTecnicas.DesgloseVariacionOtrasProvisionesTecnicas
            .SeguroDirecto = 0
            .ReaseguroAceptado = 0
        End With

        With result.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionParticipacionReaseguradorOtrasProvisionesTecnicas
            .DesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionParticipacionReaseguradorOtrasProvisionesTecnicasDesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas
            .TotalVariacionParticipacionReaseguradorOtrasProvisionesTecnicas = 0
        End With
        With result.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionParticipacionReaseguradorOtrasProvisionesTecnicas.DesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas
            .SeguroDirecto = 0
            .ReaseguroAceptado = 0
        End With

        With result.ResultadoCuentaTecnica.GastosExplotacionNetos
            .DesgloseGastosExplotacionNetos = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaGastosExplotacionNetosDesgloseGastosExplotacionNetos
            .TotalGastosExplotacionNetos = 0
        End With
        With result.ResultadoCuentaTecnica.GastosExplotacionNetos.DesgloseGastosExplotacionNetos
            .GastosAdquisicion = 0
            .GastosAdministracion = 0
            .ComisionesParticipacionesReaseguroCedidoRetrocedido = 0
        End With

        With result.ResultadoCuentaFinanciera
            .IngresosFinancieros = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraIngresosFinancieros
            .GastosFinancieros = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraGastosFinancieros
            .TotalCuentaFinanciera = 0
        End With
        With result.ResultadoCuentaFinanciera.IngresosFinancieros
            .DesgloseIngresosFinancieros = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraIngresosFinancierosDesgloseIngresosFinancieros
            .TotalIngresosFinancieros = 0
        End With
        With result.ResultadoCuentaFinanciera.IngresosFinancieros.DesgloseIngresosFinancieros
            .IngresosFinancieros = 0
            .IngresosFinancierosTomadorAsumeRiesgoInversion = 0
        End With

        With result.ResultadoCuentaFinanciera.GastosFinancieros
            .DesgloseGastosFinancieros = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraGastosFinancierosDesgloseGastosFinancieros
            .TotalGastosFinancieros = 0
        End With
        With result.ResultadoCuentaFinanciera.GastosFinancieros.DesgloseGastosFinancieros
            .GastosFinancieros = 0
            .GastosFinancierosTomadorAsumeRiesgoInversion = 0
        End With

        Return result
    End Function

    'Private Sub ModelInit2()
    '    With _CuentaTecnica

    '    End With
    '    With _CuentaTecnica.Encabezado
    '        .NombreArchivo = sheet.StringValue(RowNumber, 1)
    '        .Fecha = sheet.StringValue(RowNumber, 1)
    '        .Periodo = sheet.StringValue(RowNumber, 1)
    '        .Periodicidad = sheet.EnumValue(Of Periodicidad)(RowNumber, 1, witherror)
    '        If witherror Then
    '            Helpers.XmlRespose.AddError(Response, "error", String.Format("El Periodicidad '{0}' no es valido.", sheet.Cell(RowNumber, 1).Value))
    '        End If

    '        .Moneda = sheet.EnumValue(Of CodMoneda)(RowNumber, 1, witherror)
    '        If witherror Then
    '            Helpers.XmlRespose.AddError(Response, "error", String.Format("El Moneda '{0}' no es valido.", sheet.Cell(RowNumber, 1).Value))
    '        End If

    '    End With

    '    With _CuentaTecnica.Datos

    '    End With
    '    With _CuentaTecnica.Datos.Modelo

    '        .EntidadFuente = sheet.StringValue(RowNumber, 1)
    '    End With
    '    With _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones

    '        .TotalUtilidadPerdidaNetaAntesImpuestosParticipaciones = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    'End Sub

    'Public Shared Function AddLineas2(items As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLinea()) As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLinea
    '    With result

    '        .idLinea = sheet.EnumValue(Of Linea)(RowNumber, 1, witherror)
    '        If witherror Then
    '            Helpers.XmlRespose.AddError(Response, "error", String.Format("El idLinea '{0}' no es valido.", sheet.Cell(RowNumber, 1).Value))
    '        End If

    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera

    '        .TotalCuentaTecnicoFinanciera_ln = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica

    '        .OtrosIngresosTecnicos_ln = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .OtrosGastosTecnicos_ln = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .TotalCuentaTecnica = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro

    '        .PrimasReaseguroCedidoRetrocedido_ln = sheet.FormatDecimalValue(RowNumber, 1, "0.00")

    '        .VariacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedido_ln = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .TotalPrimasImputadasNetasReaseguro = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.IngresoPrimas

    '        .TotalIngresoPrimas = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.IngresoPrimas.DesgloseIngresoPrimas_ln
    '        .SeguroDirecto = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .ReaseguroAceptado = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .VariacionEstimacionDeterioroPrimasVencidas = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro

    '        .SiniestrosGastosRecuperadosPorReaseguroCedidoRetrocedido_ln = sheet.FormatDecimalValue(RowNumber, 1, "0.00")

    '        .VariacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedido_ln = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .GastosImputablesSiniestros_ln = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .TotalSiniestralidadNetaReaseguro = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro.SiniestrosPagados

    '        .TotalSiniestrosPagados = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro.SiniestrosPagados.DesgloseSiniestrosPagados_ln
    '        .SeguroDirecto = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .ReaseguroAceptado = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro.VariacionProvisionParaSiniestros

    '        .TotalVariacionProvisionParaSiniestros = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro.VariacionProvisionParaSiniestros.DesgloseVariacionProvisionParaSiniestros_ln
    '        .SeguroDirecto = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .ReaseguroAceptado = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.ParticipacionBeneficiosExtornos

    '        .TotalParticipacionBeneficiosExtornos = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.ParticipacionBeneficiosExtornos.DesgloseParticipacionBeneficiosExtornos_ln
    '        .PrestacionesGastosParticipacionBeneficiosExtornos = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .VariacionProvisionParticipacionBeneficiosExtornos = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro

    '        .VariacionParticipacionReaseguradorProvisionMatematica_ln = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .VariacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSeguros_ln = sheet.FormatDecimalValue(RowNumber, 1, "0.00")

    '        .TotalVariacionOtrasProvisionesTecnicasNetasReaseguro = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionProvisionMatematica

    '        .TotalVariacionProvisionMatematica = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionProvisionMatematica.DesgloseVariacionProvisionMatematica_ln
    '        .SeguroDirecto = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .ReaseguroAceptado = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionOtrasProvisionesTecnicas

    '        .TotalVariacionOtrasProvisionesTecnicas = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionOtrasProvisionesTecnicas.DesgloseVariacionOtrasProvisionesTecnicas_ln
    '        .SeguroDirecto = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .ReaseguroAceptado = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionParticipacionReaseguradorOtrasProvisionesTecnicas

    '        .TotalVariacionParticipacionReaseguradorOtrasProvisionesTecnicas = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.VariacionOtrasProvisionesTecnicasNetasReaseguro.VariacionParticipacionReaseguradorOtrasProvisionesTecnicas.DesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln
    '        .SeguroDirecto = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .ReaseguroAceptado = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.GastosExplotacionNetos

    '        .TotalGastosExplotacionNetos = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaTecnica.GastosExplotacionNetos.DesgloseGastosExplotacionNetos_ln
    '        .GastosAdquisicion = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .GastosAdministracion = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .ComisionesParticipacionesReaseguroCedidoRetrocedido = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaFinanciera

    '        .TotalCuentaFinanciera = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaFinanciera.IngresosFinancieros

    '        .TotalIngresosFinancieros = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnicoFinanciera.ResultadoCuentaFinanciera.IngresosFinancieros.DesgloseIngresosFinancieros_ln
    '        .IngresosFinancieros = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .IngresosFinancierosTomadorAsumeRiesgoInversion = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    'End Function

    'Public Shared Function AddResultadoCuentaTecnicoFinanciera2(items As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera()) As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera
    '    With result

    '        .idRamo = sheet.EnumValue(Of TipoRamo)(RowNumber, 1, witherror)
    '        If witherror Then
    '            Helpers.XmlRespose.AddError(Response, "error", String.Format("El idRamo '{0}' no es valido.", sheet.Cell(RowNumber, 1).Value))
    '        End If

    '        .TotalCuentaTecnicoFinanciera = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    '    With result.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.IngresoPrimas

    '        .TotalIngresoPrimas = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    '    With result.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas

    '        .TotalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro.VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas.DesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas
    '        .SeguroDirecto = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .ReaseguroAceptado = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    '    With result.ResultadoCuentaTecnica.SiniestralidadNetaReaseguro

    '        .SiniestrosGastosRecuperadosPorReaseguroCedidoRetrocedido = sheet.FormatDecimalValue(RowNumber, 1, "0.00")

    '
    '    End With

    '    With result.ResultadoCuentaFinanciera

    '        .TotalCuentaFinanciera = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    '    With result.ResultadoCuentaFinanciera.GastosFinancieros

    '        .TotalGastosFinancieros = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With
    '    With result.ResultadoCuentaFinanciera.GastosFinancieros.DesgloseGastosFinancieros
    '        .GastosFinancieros = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '        .GastosFinancierosTomadorAsumeRiesgoInversion = sheet.FormatDecimalValue(RowNumber, 1, "0.00")
    '    End With

    'End Function

    Public Sub LoadExcelInformation(excelFilename As String)
        Dim workbook As New XLWorkbook(excelFilename)
        Dim sheet As IXLWorksheet = Nothing
        Dim value As String = String.Empty
        Dim witherror As Boolean = False
        Dim index As Integer = 0
        Dim lineaIndex As Integer = 0

        For RowNumber As Integer = 0 To 33
            validateRamo(RowNumber) = 0
            validateLinea(RowNumber) = 0
        Next

        'Resultado Cuenta Técnica
        sheetName = "Resultado Cuenta Técnica"
        sheet = workbook.Worksheet(sheetName)
        For RowNumber As Integer = 5 To 5000
            value = sheet.Cell(RowNumber, 1).Value
            If value.IsNotEmpty Then
                ramoActual = sheet.EnumValue(Of TipoRamo)(RowNumber, "A", witherror)
                If witherror Then
                    Helpers.XmlRespose.AddError(Response, "error", String.Format("El idRamo '{0}' no es valido.", sheet.Cell(RowNumber, "A").Value))
                End If

                index = ProcessResultadoCuentaTecnicoFinanciera()

                Try
                    _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(index).ResultadoCuentaTecnica = ResultadoCuentaTecnica(sheet, RowNumber, witherror)
                    With _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(index)
                        .idRamo = ramoActual
                        '<!--[C] = A + B-->
                        .TotalCuentaTecnicoFinanciera = (.TotalCuentaTecnicoFinanciera +
                                                          _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(index).ResultadoCuentaTecnica.TotalCuentaTecnica).ToDecimalAmount()
                    End With
                Catch ex As Exception
                    Helpers.XmlRespose.AddError(Response, "error", String.Format("Error en 'Resultado Cuenta Técnica' {0}", ex.Message))
                End Try
            Else
                Exit For
            End If
        Next

        'Líneas Cuenta Técnica
        sheetName = "Líneas Cuenta Técnica"
        sheet = workbook.Worksheet(sheetName)
        For RowNumber As Integer = 5 To 5000
            value = sheet.Cell(RowNumber, "A").Value
            If value.IsNotEmpty Then
                ramoActual = sheet.EnumValue(Of TipoRamo)(RowNumber, "A", witherror)
                If witherror Then
                    Helpers.XmlRespose.AddError(Response, "error", String.Format("El idRamo '{0}' no es valido.", sheet.Cell(RowNumber, "A").Value))
                End If
                lineaActual = sheet.EnumValue(Of Linea)(RowNumber, "B", witherror)
                If witherror Then
                    Helpers.XmlRespose.AddError(Response, "error", String.Format("El idLinea '{0}' no es valido.", sheet.Cell(RowNumber, "B").Value))
                End If
                index = ProcessResultadoCuentaTecnicoFinanciera()
                lineaIndex = ProcessResultadoLineaCuentaTecnicoFinanciera(index)
                Try
                    _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(index).Lineas(lineaIndex).ResultadoCuentaTecnicoFinanciera_ln.ResultadoCuentaTecnica_ln = LineasCuentaTecnica(sheet, RowNumber, witherror)
                    With _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(index).Lineas(lineaIndex).ResultadoCuentaTecnicoFinanciera_ln
                        .TotalCuentaTecnicoFinanciera_ln = (.TotalCuentaTecnicoFinanciera_ln +
                                                                               .ResultadoCuentaTecnica_ln.TotalCuentaTecnica).ToDecimalAmount()
                    End With
                Catch ex As Exception
                    Helpers.XmlRespose.AddError(Response, "error", String.Format("Error en 'Líneas Cuenta Técnica' {0}", ex.Message))
                End Try
            Else
                Exit For
            End If
        Next

        For RowNumber As Integer = 0 To 33
            If validateRamo(RowNumber) <> validateLinea(RowNumber) Then
                Helpers.XmlRespose.AddError(Response, "error", String.Format("Existe diferencia en la lineas de incendio ({2} {0}/{3} {1})", validateRamo(RowNumber), validateLinea(RowNumber), RowtoColumn(RowNumber), RowtoColumn(RowNumber + 1)))
            End If
        Next

        'Resultado Cuenta Financiera
        sheetName = "Resultado Cuenta Financiera"
        sheet = workbook.Worksheet(sheetName)
        For RowNumber As Integer = 3 To 5000
            value = sheet.Cell(RowNumber, 1).Value
            If value.IsNotEmpty Then
                ramoActual = sheet.EnumValue(Of TipoRamo)(RowNumber, "A", witherror)
                If witherror Then
                    Helpers.XmlRespose.AddError(Response, "error", String.Format("El idRamo '{0}' no es valido.", sheet.Cell(RowNumber, 1).Value))
                End If
                index = ProcessResultadoCuentaTecnicoFinanciera()
                Try
                    _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(index).ResultadoCuentaFinanciera = ResultadoCuentaFinanciera(sheet, RowNumber, witherror)
                    With _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(index)
                        .idRamo = ramoActual
                        .TotalCuentaTecnicoFinanciera = (.TotalCuentaTecnicoFinanciera + _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(index).ResultadoCuentaFinanciera.TotalCuentaFinanciera).ToDecimalAmount()
                    End With
                Catch ex As Exception
                    Helpers.XmlRespose.AddError(Response, "error", String.Format("Error en 'Resultado Cuenta Financiera' {0}", ex.Message))
                End Try
            Else
                Exit For
            End If
        Next

        'Líneas Cuenta Financiera
        sheetName = "Líneas Cuenta Financiera"
        sheet = workbook.Worksheet(sheetName)
        For RowNumber As Integer = 4 To 5000
            value = sheet.Cell(RowNumber, 1).Value
            If value.IsNotEmpty Then
                ramoActual = sheet.EnumValue(Of TipoRamo)(RowNumber, "A", witherror)
                If witherror Then
                    Helpers.XmlRespose.AddError(Response, "error", String.Format("El idRamo '{0}' no es valido.", sheet.Cell(RowNumber, "A").Value))
                End If
                lineaActual = sheet.EnumValue(Of Linea)(RowNumber, "B", witherror)
                If witherror Then
                    Helpers.XmlRespose.AddError(Response, "error", String.Format("El idLinea '{0}' no es valido.", sheet.Cell(RowNumber, "B").Value))
                End If
                index = ProcessResultadoCuentaTecnicoFinanciera()
                lineaIndex = ProcessResultadoLineaCuentaTecnicoFinanciera(index)

                Try
                    _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(index).Lineas(lineaIndex).ResultadoCuentaTecnicoFinanciera_ln.ResultadoCuentaFinanciera_ln = LineasCuentaFinanciera(sheet, RowNumber, witherror)
                    With _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(index).Lineas(lineaIndex).ResultadoCuentaTecnicoFinanciera_ln
                        .TotalCuentaTecnicoFinanciera_ln = (.TotalCuentaTecnicoFinanciera_ln +
                                                                               .ResultadoCuentaFinanciera_ln.TotalCuentaFinanciera).ToDecimalAmount()
                    End With
                Catch ex As Exception
                    Helpers.XmlRespose.AddError(Response, "error", String.Format("Error en 'Líneas Cuenta Financiera' {0}", ex.Message))
                End Try
            Else
                Exit For
            End If
        Next

        'Cuenta No Técnica
        sheetName = "Cuenta No Técnica"
        sheet = workbook.Worksheet(sheetName)
        For RowNumber As Integer = 2 To 2
            value = sheet.Cell(RowNumber, 1).Value
            If value.IsNotEmpty Then
                Try
                    _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaNoTecnica = CuentaNoTecnica(sheet, RowNumber)
                Catch ex As Exception
                    Helpers.XmlRespose.AddError(Response, "error", String.Format("Error en 'Cuenta No Técnica' {0}", ex.Message))
                End Try
            Else
                Exit For
            End If
        Next

        'Totalización final
        For i As Integer = 0 To _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera.Length - 1
            _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.TotalUtilidadPerdidaNetaAntesImpuestosParticipaciones =
                 (Convert.ToDecimal(_CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.TotalUtilidadPerdidaNetaAntesImpuestosParticipaciones) +
                                   Convert.ToDecimal(_CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(i).TotalCuentaTecnicoFinanciera)).ToDecimalAmount()
        Next
        _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.TotalUtilidadPerdidaNetaAntesImpuestosParticipaciones =
                (Convert.ToDecimal(_CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.TotalUtilidadPerdidaNetaAntesImpuestosParticipaciones) +
                                Convert.ToDecimal(_CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaNoTecnica.TotalCuentaNoTecnica)).ToDecimalAmount()

        sheet = Nothing
        workbook = Nothing
    End Sub

    Private Function ResultadoCuentaTecnica(sheet As IXLWorksheet, rowNumber As Integer, witherror As Boolean) As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnica
        Dim item As New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnica

        With item
            .PrimasImputadasNetasReaseguro = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguro
            .SiniestralidadNetaReaseguro = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguro
            .ParticipacionBeneficiosExtornos = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaParticipacionBeneficiosExtornos
            .VariacionOtrasProvisionesTecnicasNetasReaseguro = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguro
            .GastosExplotacionNetos = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaGastosExplotacionNetos
        End With
        With item.PrimasImputadasNetasReaseguro
            .IngresoPrimas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimas
            .VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas
        End With
        With item.PrimasImputadasNetasReaseguro.IngresoPrimas
            .DesgloseIngresoPrimas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimas
        End With
        With item.PrimasImputadasNetasReaseguro.VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas
            .DesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasDesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas
        End With
        With item.SiniestralidadNetaReaseguro
            .SiniestrosPagados = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroSiniestrosPagados
            .SiniestrosPagados.DesgloseSiniestrosPagados = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroSiniestrosPagadosDesgloseSiniestrosPagados
            .VariacionProvisionParaSiniestros = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroVariacionProvisionParaSiniestros
            .VariacionProvisionParaSiniestros.DesgloseVariacionProvisionParaSiniestros = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroVariacionProvisionParaSiniestrosDesgloseVariacionProvisionParaSiniestros
        End With
        With item.ParticipacionBeneficiosExtornos
            .DesgloseParticipacionBeneficiosExtornos = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaParticipacionBeneficiosExtornosDesgloseParticipacionBeneficiosExtornos
        End With
        With item.VariacionOtrasProvisionesTecnicasNetasReaseguro
            .VariacionProvisionMatematica = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionProvisionMatematica
            .VariacionProvisionMatematica.DesgloseVariacionProvisionMatematica = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionProvisionMatematicaDesgloseVariacionProvisionMatematica
            .VariacionOtrasProvisionesTecnicas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionOtrasProvisionesTecnicas
            .VariacionOtrasProvisionesTecnicas.DesgloseVariacionOtrasProvisionesTecnicas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionOtrasProvisionesTecnicasDesgloseVariacionOtrasProvisionesTecnicas
            .VariacionParticipacionReaseguradorOtrasProvisionesTecnicas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionParticipacionReaseguradorOtrasProvisionesTecnicas
            .VariacionParticipacionReaseguradorOtrasProvisionesTecnicas.DesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionParticipacionReaseguradorOtrasProvisionesTecnicasDesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas
        End With
        With item.GastosExplotacionNetos
            .DesgloseGastosExplotacionNetos = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaGastosExplotacionNetosDesgloseGastosExplotacionNetos
        End With

        'A
        With item.PrimasImputadasNetasReaseguro
            With .IngresoPrimas
                With .DesgloseIngresoPrimas
                    'XXX .SeguroDirecto = sheet.FormatDecimalValue(rowNumber, "B", "0.00")
                    .SeguroDirecto = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimasSeguroDirecto
                    .SeguroDirecto.DesgloseSeguroDirecto = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimasSeguroDirectoDesgloseSeguroDirecto
                    .SeguroDirecto.DesgloseSeguroDirecto.PrimasEmitidas = sheet.FormatDecimalValue(rowNumber, "B", "0.00")
                    .SeguroDirecto.DesgloseSeguroDirecto.PrimasAnuladasExtornadasPeriodo = sheet.FormatDecimalValue(rowNumber, "C", "0.00")
                    .SeguroDirecto.DesgloseSeguroDirecto.PrimasAnuladasExtornadasPeriodosAnteriores = sheet.FormatDecimalValue(rowNumber, "D", "0.00")
                    .SeguroDirecto.DesgloseSeguroDirecto.VariacionPrimasPolizasFlotantes = sheet.FormatDecimalValue(rowNumber, "E", "0.00")
                    .SeguroDirecto.TotalSeguroDirecto = (sheet.DecimalValue(rowNumber, "B", "0.00") -
                                                         sheet.DecimalValue(rowNumber, "C", "0.00") -
                                                         sheet.DecimalValue(rowNumber, "D", "0.00") +
                                                         sheet.DecimalValue(rowNumber, "E", "0.00")).ToDecimalAmount()

                    .ReaseguroAceptado = sheet.FormatDecimalValue(rowNumber, "F", "0.00")
                    .VariacionEstimacionDeterioroPrimasVencidas = sheet.FormatDecimalValue(rowNumber, "G", "0.00")
                End With
                '<!--[1] = 1.1 + 1.2 - 1.3-->
                .TotalIngresoPrimas = (.DesgloseIngresoPrimas.SeguroDirecto.TotalSeguroDirecto +
                                        sheet.DecimalValue(rowNumber, "F", "0.00") -
                                        sheet.DecimalValue(rowNumber, "G", "0.00")).ToDecimalAmount()

            End With
            '<!--2-->
            'XXX .PrimasReaseguroCedidoRetrocedido = sheet.FormatDecimalValue(rowNumber, "E", "0.00")
            .PrimasReaseguroCedidoRetrocedido = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroPrimasReaseguroCedidoRetrocedido
            .PrimasReaseguroCedidoRetrocedido.DesglosePrimasReaseguroCedidoRetrocedido = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroPrimasReaseguroCedidoRetrocedidoDesglosePrimasReaseguroCedidoRetrocedido
            .PrimasReaseguroCedidoRetrocedido.DesglosePrimasReaseguroCedidoRetrocedido.PrimasCedidasReaseguroProporcional = sheet.FormatDecimalValue(rowNumber, "H", "0.00")
            .PrimasReaseguroCedidoRetrocedido.DesglosePrimasReaseguroCedidoRetrocedido.PrimasPagadasReaseguroNoProporcional = sheet.FormatDecimalValue(rowNumber, "I", "0.00")
            .PrimasReaseguroCedidoRetrocedido.TotalPrimasReaseguroCedidoRetrocedido = (sheet.DecimalValue(rowNumber, "H", "0.00") +
                                                                                       sheet.DecimalValue(rowNumber, "I", "0.00")).ToDecimalAmount()

            With .VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas
                With .DesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas
                    .SeguroDirecto = sheet.FormatDecimalValue(rowNumber, "J", "0.00")
                    .ReaseguroAceptado = sheet.FormatDecimalValue(rowNumber, "K", "0.00")
                End With
                '<!--[3] = 3.1 + 3.2-->
                .TotalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas = (sheet.DecimalValue(rowNumber, "J", "0.00") +
                                                                                     sheet.DecimalValue(rowNumber, "K", "0.00")).ToDecimalAmount()
            End With
            '<!--4-->
            .VariacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedido = sheet.FormatDecimalValue(rowNumber, "L", "0.00")
            '<!--[I] = 1 - 2 - 3 + 4-->
            .TotalPrimasImputadasNetasReaseguro = (.IngresoPrimas.TotalIngresoPrimas -
                                                   .PrimasReaseguroCedidoRetrocedido.TotalPrimasReaseguroCedidoRetrocedido -
                                                   .VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas.TotalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas +
                                                   .VariacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedido).ToDecimalAmount()
        End With
        'B
        With item.SiniestralidadNetaReaseguro
            With .SiniestrosPagados
                With .DesgloseSiniestrosPagados
                    .SeguroDirecto = sheet.FormatDecimalValue(rowNumber, "M", "0.00", Response, sheetName)
                    .ReaseguroAceptado = sheet.FormatDecimalValue(rowNumber, "N", "0.00", Response, sheetName)
                End With
                '<!--[1] = 1.1 + 1.2-->
                .TotalSiniestrosPagados = (sheet.DecimalValue(rowNumber, "M", "0.00") +
                                           sheet.DecimalValue(rowNumber, "N", "0.00")).ToDecimalAmount()
            End With
            '<!--2-->
            .SiniestrosGastosRecuperadosPorReaseguroCedidoRetrocedido = sheet.FormatDecimalValueOnlyPositive(rowNumber, "O", "0.00", Response, sheetName)
            With .VariacionProvisionParaSiniestros
                With .DesgloseVariacionProvisionParaSiniestros
                    .SeguroDirecto = sheet.FormatDecimalValue(rowNumber, "P", "0.00")
                    .ReaseguroAceptado = sheet.FormatDecimalValue(rowNumber, "Q", "0.00")
                End With
                '<!--[3] = 3.1 + 3.2-->
                .TotalVariacionProvisionParaSiniestros = (sheet.DecimalValue(rowNumber, "P", "0.00") +
                                                          sheet.DecimalValue(rowNumber, "Q", "0.00")).ToDecimalAmount()
            End With
            '<!--4-->
            .VariacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedido = sheet.FormatDecimalValue(rowNumber, "R", "0.00")
            '<!--5-->
            .GastosImputablesSiniestros = sheet.FormatDecimalValue(rowNumber, "S", "0.00")
            '<!--[II] = 1 - 2 + 3 - 4 + 5-->
            .TotalSiniestralidadNetaReaseguro = (.SiniestrosPagados.TotalSiniestrosPagados -
                                                 .SiniestrosGastosRecuperadosPorReaseguroCedidoRetrocedido +
                                                 .VariacionProvisionParaSiniestros.TotalVariacionProvisionParaSiniestros -
                                                 .VariacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedido +
                                                 .GastosImputablesSiniestros).ToDecimalAmount()
        End With

        With item.ParticipacionBeneficiosExtornos
            With .DesgloseParticipacionBeneficiosExtornos
                .PrestacionesGastosParticipacionBeneficiosExtornos = sheet.FormatDecimalValue(rowNumber, "T", "0.00")
                .VariacionProvisionParticipacionBeneficiosExtornos = sheet.FormatDecimalValue(rowNumber, "U", "0.00")
            End With
            '<!--[III] = 1 + 2-->
            .TotalParticipacionBeneficiosExtornos = (sheet.DecimalValue(rowNumber, "T", "0.00") +
                                                     sheet.DecimalValue(rowNumber, "U", "0.00")).ToDecimalAmount()
        End With
        'C
        With item.VariacionOtrasProvisionesTecnicasNetasReaseguro
            With .VariacionProvisionMatematica
                With .DesgloseVariacionProvisionMatematica
                    .SeguroDirecto = sheet.FormatDecimalValue(rowNumber, "V", "0.00")
                    .ReaseguroAceptado = sheet.FormatDecimalValue(rowNumber, "W", "0.00")
                End With
                '<!--[1] = 1.1 + 1.2-->
                .TotalVariacionProvisionMatematica = (sheet.DecimalValue(rowNumber, "V", "0.00") +
                                                      sheet.DecimalValue(rowNumber, "W", "0.00")).ToDecimalAmount()
            End With
            '<!--2-->
            .VariacionParticipacionReaseguradorProvisionMatematica = sheet.FormatDecimalValue(rowNumber, "X", "0.00")
            '<!--3-->
            .VariacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSeguros = sheet.FormatDecimalValue(rowNumber, "Y", "0.00")
            With .VariacionOtrasProvisionesTecnicas
                With .DesgloseVariacionOtrasProvisionesTecnicas
                    .SeguroDirecto = sheet.FormatDecimalValue(rowNumber, "Z", "0.00")
                    .ReaseguroAceptado = sheet.FormatDecimalValue(rowNumber, "AA", "0.00")
                End With
                ' <!--[4] = 4.1 + 4.2 -->
                .TotalVariacionOtrasProvisionesTecnicas = (sheet.DecimalValue(rowNumber, "Z", "0.00") +
                                                           sheet.DecimalValue(rowNumber, "AA", "0.00")).ToDecimalAmount()
            End With
            With .VariacionParticipacionReaseguradorOtrasProvisionesTecnicas
                With .DesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas
                    .SeguroDirecto = sheet.FormatDecimalValue(rowNumber, "AB", "0.00")
                    .ReaseguroAceptado = sheet.FormatDecimalValue(rowNumber, "AC", "0.00")
                End With
                '<!--[5] = 5.1 + 5.2-->
                .TotalVariacionParticipacionReaseguradorOtrasProvisionesTecnicas = (sheet.DecimalValue(rowNumber, "AB", "0.00") +
                                                                                    sheet.DecimalValue(rowNumber, "AC", "0.00")).ToDecimalAmount()
            End With
            '<!--[IV] = 1 - 2 + 3 + 4 - 5-->
            .TotalVariacionOtrasProvisionesTecnicasNetasReaseguro = (.VariacionProvisionMatematica.TotalVariacionProvisionMatematica -
                                                                     .VariacionParticipacionReaseguradorProvisionMatematica +
                                                                     .VariacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSeguros +
                                                                     .VariacionOtrasProvisionesTecnicas.TotalVariacionOtrasProvisionesTecnicas -
                                                                     .VariacionParticipacionReaseguradorOtrasProvisionesTecnicas.TotalVariacionParticipacionReaseguradorOtrasProvisionesTecnicas).ToDecimalAmount()
        End With
        'D
        With item.GastosExplotacionNetos
            With .DesgloseGastosExplotacionNetos
                .GastosAdquisicion = sheet.FormatDecimalValue(rowNumber, "AD", "0.00", Response, sheetName)
                .GastosAdministracion = sheet.FormatDecimalValue(rowNumber, "AE", "0.00", Response, sheetName)
                .ComisionesParticipacionesReaseguroCedidoRetrocedido = sheet.FormatDecimalValue(rowNumber, "AF", "0.00", Response, sheetName)
            End With
            '<!--[V] = 1 + 2 - 3-->
            .TotalGastosExplotacionNetos = (sheet.DecimalValue(rowNumber, "AD", "0.00") +
                                            sheet.DecimalValue(rowNumber, "AE", "0.00") -
                                            sheet.DecimalValue(rowNumber, "AF", "0.00")).ToDecimalAmount()
        End With
        'E
        With item
            '<!--VI-->
            .OtrosIngresosTecnicos = sheet.FormatDecimalValue(rowNumber, "AG", "0.00")
            '<!--VII-->
            .OtrosGastosTecnicos = sheet.FormatDecimalValue(rowNumber, "AH", "0.00")
            '<!--[A] = I-II-III-IV-V+VI-VII-->
            '.TotalCuentaTecnica = helper.MontoDecimal(.PrimasImputadasNetasReaseguro.TotalPrimasImputadasNetasReaseguro -
            '                                           .SiniestralidadNetaReaseguro.TotalSiniestralidadNetaReaseguro -
            '                                           .ParticipacionBeneficiosExtornos.TotalParticipacionBeneficiosExtornos -
            '                                           .VariacionOtrasProvisionesTecnicasNetasReaseguro.TotalVariacionOtrasProvisionesTecnicasNetasReaseguro +
            '                                           .GastosExplotacionNetos.TotalGastosExplotacionNetos +
            '                                           .OtrosIngresosTecnicos -
            '                                           .OtrosGastosTecnicos)
            .TotalCuentaTecnica = ((.PrimasImputadasNetasReaseguro.TotalPrimasImputadasNetasReaseguro +
                                    .OtrosIngresosTecnicos) -
                                    .SiniestralidadNetaReaseguro.TotalSiniestralidadNetaReaseguro -
                                    .ParticipacionBeneficiosExtornos.TotalParticipacionBeneficiosExtornos -
                                    .VariacionOtrasProvisionesTecnicasNetasReaseguro.TotalVariacionOtrasProvisionesTecnicasNetasReaseguro -
                                    .GastosExplotacionNetos.TotalGastosExplotacionNetos -
                                    .OtrosGastosTecnicos).ToDecimalAmount()
        End With

        If ramoActual = TipoRamo.G06 Then
            validateRamo(0) = sheet.DecimalValue(rowNumber, "B", "0.00")
            validateRamo(1) = sheet.DecimalValue(rowNumber, "C", "0.00")
            validateRamo(2) = sheet.DecimalValue(rowNumber, "D", "0.00")
            validateRamo(3) = sheet.DecimalValue(rowNumber, "E", "0.00")
            validateRamo(4) = sheet.DecimalValue(rowNumber, "F", "0.00")
            validateRamo(5) = sheet.DecimalValue(rowNumber, "G", "0.00")
            validateRamo(6) = sheet.DecimalValue(rowNumber, "H", "0.00")
            validateRamo(7) = sheet.DecimalValue(rowNumber, "I", "0.00")
            validateRamo(8) = sheet.DecimalValue(rowNumber, "J", "0.00")
            validateRamo(9) = sheet.DecimalValue(rowNumber, "K", "0.00")
            validateRamo(10) = sheet.DecimalValue(rowNumber, "L", "0.00")
            validateRamo(11) = sheet.DecimalValue(rowNumber, "M", "0.00")
            validateRamo(12) = sheet.DecimalValue(rowNumber, "N", "0.00")
            validateRamo(13) = sheet.DecimalValue(rowNumber, "O", "0.00")
            validateRamo(14) = sheet.DecimalValue(rowNumber, "P", "0.00")
            validateRamo(15) = sheet.DecimalValue(rowNumber, "Q", "0.00")
            validateRamo(16) = sheet.DecimalValue(rowNumber, "R", "0.00")
            validateRamo(17) = sheet.DecimalValue(rowNumber, "S", "0.00")
            validateRamo(18) = sheet.DecimalValue(rowNumber, "T", "0.00")
            validateRamo(19) = sheet.DecimalValue(rowNumber, "U", "0.00")
            validateRamo(20) = sheet.DecimalValue(rowNumber, "V", "0.00")
            validateRamo(21) = sheet.DecimalValue(rowNumber, "W", "0.00")
            validateRamo(22) = sheet.DecimalValue(rowNumber, "X", "0.00")
            validateRamo(23) = sheet.DecimalValue(rowNumber, "Y", "0.00")
            validateRamo(24) = sheet.DecimalValue(rowNumber, "Z", "0.00")
            validateRamo(25) = sheet.DecimalValue(rowNumber, "AA", "0.00")
            validateRamo(26) = sheet.DecimalValue(rowNumber, "AB", "0.00")
            validateRamo(27) = sheet.DecimalValue(rowNumber, "AC", "0.00")
            validateRamo(28) = sheet.DecimalValue(rowNumber, "AD", "0.00")

            validateRamo(29) = sheet.DecimalValue(rowNumber, "AE", "0.00")
            validateRamo(30) = sheet.DecimalValue(rowNumber, "AF", "0.00")
            validateRamo(31) = sheet.DecimalValue(rowNumber, "AG", "0.00")
            validateRamo(32) = sheet.DecimalValue(rowNumber, "AH", "0.00")
        End If

        Return item
    End Function

    Private Function ResultadoCuentaFinanciera(sheet As IXLWorksheet, rowNumber As Integer, witherror As Boolean) As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinanciera
        'Dim item As New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinancieraResultadoCuentaFinanciera
        Dim item As New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinanciera

        With item
            .IngresosFinancieros = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraIngresosFinancieros
            .IngresosFinancieros.DesgloseIngresosFinancieros = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraIngresosFinancierosDesgloseIngresosFinancieros
            .GastosFinancieros = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraGastosFinancieros
            .GastosFinancieros.DesgloseGastosFinancieros = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraGastosFinancierosDesgloseGastosFinancieros
        End With

        With item.IngresosFinancieros

            With .DesgloseIngresosFinancieros
                .IngresosFinancieros = sheet.FormatDecimalValue(rowNumber, "B", "0.00")
                .IngresosFinancierosTomadorAsumeRiesgoInversion = sheet.FormatDecimalValue(rowNumber, "C", "0.00")
            End With
            '<!--[VIII] = 1 + 2-->
            .TotalIngresosFinancieros = (sheet.DecimalValue(rowNumber, "B", "0.00") +
                                         sheet.DecimalValue(rowNumber, "C", "0.00")).ToDecimalAmount()
        End With
        With item.GastosFinancieros
            With .DesgloseGastosFinancieros
                .GastosFinancieros = sheet.FormatDecimalValue(rowNumber, "D", "0.00")
                .GastosFinancierosTomadorAsumeRiesgoInversion = sheet.FormatDecimalValue(rowNumber, "E", "0.00")
            End With
            '<!--[IX] = 1 + 2-->
            .TotalGastosFinancieros = (sheet.DecimalValue(rowNumber, "D", "0.00") +
                                       sheet.DecimalValue(rowNumber, "E", "0.00")).ToDecimalAmount()
        End With
        '<!--[B] = VIII - IX-->
        item.TotalCuentaFinanciera = (item.IngresosFinancieros.TotalIngresosFinancieros -
                                      item.GastosFinancieros.TotalGastosFinancieros).ToDecimalAmount()
        Return item
    End Function

    Private Function LineasCuentaTecnica(sheet As IXLWorksheet, rowNumber As Integer, witherror As Boolean) As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_ln
        Dim item As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_ln = AddLineaCuentaTecnica()

        'A
        With item.PrimasImputadasNetasReaseguro_ln
            With .IngresoPrimas_ln
                With .DesgloseIngresoPrimas_ln
                    'XXX .SeguroDirecto = sheet.FormatDecimalValue(rowNumber, "C", "0.00", Response, sheetName)

                    .SeguroDirecto_ln.DesgloseSeguroDirecto_ln.PrimasEmitidas = sheet.FormatDecimalValue(rowNumber, "C", "0.00", Response, sheetName)
                    .SeguroDirecto_ln.DesgloseSeguroDirecto_ln.PrimasAnuladasExtornadasPeriodo = sheet.FormatDecimalValue(rowNumber, "D", "0.00", Response, sheetName)
                    .SeguroDirecto_ln.DesgloseSeguroDirecto_ln.PrimasAnuladasExtornadasPeriodosAnteriores = sheet.FormatDecimalValue(rowNumber, "E", "0.00", Response, sheetName)
                    .SeguroDirecto_ln.DesgloseSeguroDirecto_ln.VariacionPrimasPolizasFlotantes = sheet.FormatDecimalValue(rowNumber, "F", "0.00", Response, sheetName)
                    .SeguroDirecto_ln.TotalSeguroDirecto = (sheet.DecimalValue(rowNumber, "C", "0.00") -
                                                                               sheet.DecimalValue(rowNumber, "D", "0.00") -
                                                                               sheet.DecimalValue(rowNumber, "E", "0.00") +
                                                                               sheet.DecimalValue(rowNumber, "F", "0.00")).ToDecimalAmount()

                    .ReaseguroAceptado = sheet.FormatDecimalValue(rowNumber, "G", "0.00", Response, sheetName)
                    .VariacionEstimacionDeterioroPrimasVencidas = sheet.FormatDecimalValue(rowNumber, "H", "0.00")
                End With
                '<!--[1] = 1.1 + 1.2 - 1.3-->
                .TotalIngresoPrimas = (.DesgloseIngresoPrimas_ln.SeguroDirecto_ln.TotalSeguroDirecto +
                                                          sheet.DecimalValue(rowNumber, "G", "0.00") -
                                                          sheet.DecimalValue(rowNumber, "H", "0.00")).ToDecimalAmount()
            End With
            '<!--2-->
            'XXX .PrimasReaseguroCedidoRetrocedido_ln = sheet.FormatDecimalValue(rowNumber, "F", "0.00", Response, sheetName)
            .PrimasReaseguroCedidoRetrocedido_ln.DesglosePrimasReaseguroCedidoRetrocedido_ln.PrimasCedidasReaseguroProporcional = sheet.FormatDecimalValue(rowNumber, "I", "0.00", Response, sheetName)
            .PrimasReaseguroCedidoRetrocedido_ln.DesglosePrimasReaseguroCedidoRetrocedido_ln.PrimasPagadasReaseguroNoProporcional = sheet.FormatDecimalValue(rowNumber, "J", "0.00", Response, sheetName)
            .PrimasReaseguroCedidoRetrocedido_ln.TotalPrimasReaseguroCedidoRetrocedido = (sheet.DecimalValue(rowNumber, "I", "0.00") +
                                                                                                          sheet.DecimalValue(rowNumber, "J", "0.00")).ToDecimalAmount()
            With .VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln
                With .DesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln
                    .SeguroDirecto = sheet.FormatDecimalValue(rowNumber, "K", "0.00")
                    .ReaseguroAceptado = sheet.FormatDecimalValue(rowNumber, "L", "0.00")
                End With
                '<!--[3] = 3.1 + 3.2-->
                .TotalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas = (sheet.DecimalValue(rowNumber, "K", "0.00") +
                                                                                                        sheet.DecimalValue(rowNumber, "L", "0.00")).ToDecimalAmount()
            End With
            '<!--4-->
            .VariacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedido_ln = sheet.FormatDecimalValue(rowNumber, "M", "0.00")
            '<!--[I] = 1 - 2 - 3 + 4-->
            .TotalPrimasImputadasNetasReaseguro = (.IngresoPrimas_ln.TotalIngresoPrimas -
                                                   .PrimasReaseguroCedidoRetrocedido_ln.TotalPrimasReaseguroCedidoRetrocedido -
                                                   .VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln.TotalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas +
                                                   .VariacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedido_ln).ToDecimalAmount()
        End With
        'B
        With item.SiniestralidadNetaReaseguro_ln
            With .SiniestrosPagados_ln
                With .DesgloseSiniestrosPagados_ln
                    .SeguroDirecto = sheet.FormatDecimalValue(rowNumber, "N", "0.00", Response, sheetName)
                    .ReaseguroAceptado = sheet.FormatDecimalValue(rowNumber, "O", "0.00", Response, sheetName)
                End With
                '<!--[1] = 1.1 + 1.2-->
                .TotalSiniestrosPagados = (sheet.DecimalValue(rowNumber, "N", "0.00") +
                                                              sheet.DecimalValue(rowNumber, "O", "0.00")).ToDecimalAmount()
            End With
            '<!--2-->
            .SiniestrosGastosRecuperadosPorReaseguroCedidoRetrocedido_ln = sheet.FormatDecimalValue(rowNumber, "P", "0.00", Response, sheetName)
            With .VariacionProvisionParaSiniestros_ln
                With .DesgloseVariacionProvisionParaSiniestros_ln
                    .SeguroDirecto = sheet.FormatDecimalValue(rowNumber, "Q", "0.00")
                    .ReaseguroAceptado = sheet.FormatDecimalValue(rowNumber, "R", "0.00")
                End With
                '<!--[3] = 3.1 + 3.2-->
                .TotalVariacionProvisionParaSiniestros = (sheet.DecimalValue(rowNumber, "Q", "0.00") +
                                                                             sheet.DecimalValue(rowNumber, "R", "0.00")).ToDecimalAmount()
            End With
            '<!--4-->
            .VariacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedido_ln = sheet.FormatDecimalValue(rowNumber, "S", "0.00")
            '<!--5-->
            .GastosImputablesSiniestros_ln = sheet.FormatDecimalValue(rowNumber, "T", "0.00")
            '<!--[II] = 1 - 2 + 3 - 4 + 5-->
            .TotalSiniestralidadNetaReaseguro = (.SiniestrosPagados_ln.TotalSiniestrosPagados -
                                                 .SiniestrosGastosRecuperadosPorReaseguroCedidoRetrocedido_ln +
                                                 .VariacionProvisionParaSiniestros_ln.TotalVariacionProvisionParaSiniestros -
                                                 .VariacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedido_ln +
                                                 .GastosImputablesSiniestros_ln).ToDecimalAmount()
        End With
        With item.ParticipacionBeneficiosExtornos_ln
            With .DesgloseParticipacionBeneficiosExtornos_ln
                .PrestacionesGastosParticipacionBeneficiosExtornos = sheet.FormatDecimalValue(rowNumber, "U", "0.00")
                .VariacionProvisionParticipacionBeneficiosExtornos = sheet.FormatDecimalValue(rowNumber, "V", "0.00")
            End With
            '<!--[III] = 1 + 2-->
            .TotalParticipacionBeneficiosExtornos = (sheet.DecimalValue(rowNumber, "U", "0.00") +
                                                     sheet.DecimalValue(rowNumber, "V", "0.00")).ToDecimalAmount()
        End With
        'C
        With item.VariacionOtrasProvisionesTecnicasNetasReaseguro_ln
            With .VariacionProvisionMatematica_ln
                With .DesgloseVariacionProvisionMatematica_ln
                    .SeguroDirecto = sheet.FormatDecimalValue(rowNumber, "W", "0.00")
                    .ReaseguroAceptado = sheet.FormatDecimalValue(rowNumber, "X", "0.00")
                End With
                '<!--[1] = 1.1 + 1.2-->
                .TotalVariacionProvisionMatematica = (sheet.DecimalValue(rowNumber, "W", "0.00") +
                                                                         sheet.DecimalValue(rowNumber, "X", "0.00")).ToDecimalAmount()
            End With
            '<!--2-->
            .VariacionParticipacionReaseguradorProvisionMatematica_ln = sheet.FormatDecimalValue(rowNumber, "Y", "0.00")
            '<!--3-->
            .VariacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSeguros_ln = sheet.FormatDecimalValue(rowNumber, "Z", "0.00")
            With .VariacionOtrasProvisionesTecnicas_ln
                With .DesgloseVariacionOtrasProvisionesTecnicas_ln
                    .SeguroDirecto = sheet.FormatDecimalValue(rowNumber, "AA", "0.00")
                    .ReaseguroAceptado = sheet.FormatDecimalValue(rowNumber, "AB", "0.00")
                End With
                ' <!--[4] = 4.1 + 4.2 -->
                .TotalVariacionOtrasProvisionesTecnicas = (sheet.DecimalValue(rowNumber, "AA", "0.00") +
                                                                              sheet.DecimalValue(rowNumber, "AB", "0.00")).ToDecimalAmount()
            End With
            With .VariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln
                With .DesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln
                    .SeguroDirecto = sheet.FormatDecimalValue(rowNumber, "AC", "0.00")
                    .ReaseguroAceptado = sheet.FormatDecimalValue(rowNumber, "AD", "0.00")
                End With
                '<!--[5] = 5.1 + 5.2-->
                .TotalVariacionParticipacionReaseguradorOtrasProvisionesTecnicas = (sheet.DecimalValue(rowNumber, "AC", "0.00") +
                                                                                                       sheet.DecimalValue(rowNumber, "AD", "0.00")).ToDecimalAmount()
            End With
            '<!--[IV] = 1 - 2 + 3 + 4 - 5-->
            .TotalVariacionOtrasProvisionesTecnicasNetasReaseguro = (.VariacionProvisionMatematica_ln.TotalVariacionProvisionMatematica -
                                                                                        .VariacionParticipacionReaseguradorProvisionMatematica_ln +
                                                                                        .VariacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSeguros_ln +
                                                                                        .VariacionOtrasProvisionesTecnicas_ln.TotalVariacionOtrasProvisionesTecnicas -
                                                                                        .VariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln.TotalVariacionParticipacionReaseguradorOtrasProvisionesTecnicas).ToDecimalAmount()
        End With
        'D
        With item.GastosExplotacionNetos_ln
            With .DesgloseGastosExplotacionNetos_ln
                .GastosAdquisicion = sheet.FormatDecimalValue(rowNumber, "AE", "0.00", Response, sheetName)
                .GastosAdministracion = sheet.FormatDecimalValue(rowNumber, "AF", "0.00", Response, sheetName)
                .ComisionesParticipacionesReaseguroCedidoRetrocedido = sheet.FormatDecimalValue(rowNumber, "AG", "0.00", Response, sheetName)
            End With
            '<!--[V] = 1 + 2 - 3-->
            .TotalGastosExplotacionNetos = (sheet.DecimalValue(rowNumber, "AE", "0.00") +
                                                               sheet.DecimalValue(rowNumber, "AF", "0.00") -
                                                               sheet.DecimalValue(rowNumber, "AG", "0.00")).ToDecimalAmount()
        End With
        'E
        With item
            '<!--VI-->
            .OtrosIngresosTecnicos_ln = sheet.FormatDecimalValue(rowNumber, "AH", "0.00")
            '<!--VII-->
            .OtrosGastosTecnicos_ln = sheet.FormatDecimalValue(rowNumber, "AI", "0.00")
            '<!--[A] = I-II-III-IV-V+VI-VII-->
            '.TotalCuentaTecnica = (.PrimasImputadasNetasReaseguro.TotalPrimasImputadasNetasReaseguro -
            '                                          .SiniestralidadNetaReaseguro.TotalSiniestralidadNetaReaseguro -
            '                                          .ParticipacionBeneficiosExtornos.TotalParticipacionBeneficiosExtornos -
            '                                          .VariacionOtrasProvisionesTecnicasNetasReaseguro.TotalVariacionOtrasProvisionesTecnicasNetasReaseguro +
            '                                          .GastosExplotacionNetos.TotalGastosExplotacionNetos +
            '                                          .OtrosIngresosTecnicos_ln -
            '                                          .OtrosGastosTecnicos_ln).ToDecimalAmount()
            .TotalCuentaTecnica = ((.PrimasImputadasNetasReaseguro_ln.TotalPrimasImputadasNetasReaseguro +
                                    .OtrosIngresosTecnicos_ln) -
                                    .SiniestralidadNetaReaseguro_ln.TotalSiniestralidadNetaReaseguro -
                                    .ParticipacionBeneficiosExtornos_ln.TotalParticipacionBeneficiosExtornos -
                                    .VariacionOtrasProvisionesTecnicasNetasReaseguro_ln.TotalVariacionOtrasProvisionesTecnicasNetasReaseguro -
                                    .GastosExplotacionNetos_ln.TotalGastosExplotacionNetos -
                                    .OtrosGastosTecnicos_ln).ToDecimalAmount()
        End With

        If lineaActual = Linea.G0668 OrElse
           lineaActual = Linea.G0669 OrElse
           lineaActual = Linea.G0670 OrElse
           lineaActual = Linea.G0671 Then
            validateLinea(0) += sheet.DecimalValue(rowNumber, "C", "0.00")
            validateLinea(1) += sheet.DecimalValue(rowNumber, "D", "0.00")
            validateLinea(2) += sheet.DecimalValue(rowNumber, "E", "0.00")
            validateLinea(3) += sheet.DecimalValue(rowNumber, "F", "0.00")
            validateLinea(4) += sheet.DecimalValue(rowNumber, "G", "0.00")
            validateLinea(5) += sheet.DecimalValue(rowNumber, "H", "0.00")
            validateLinea(6) += sheet.DecimalValue(rowNumber, "I", "0.00")
            validateLinea(7) += sheet.DecimalValue(rowNumber, "J", "0.00")
            validateLinea(8) += sheet.DecimalValue(rowNumber, "K", "0.00")
            validateLinea(9) += sheet.DecimalValue(rowNumber, "L", "0.00")
            validateLinea(10) += sheet.DecimalValue(rowNumber, "M", "0.00")
            validateLinea(11) += sheet.DecimalValue(rowNumber, "N", "0.00")
            validateLinea(12) += sheet.DecimalValue(rowNumber, "O", "0.00")
            validateLinea(13) += sheet.DecimalValue(rowNumber, "P", "0.00")
            validateLinea(14) += sheet.DecimalValue(rowNumber, "Q", "0.00")
            validateLinea(15) += sheet.DecimalValue(rowNumber, "R", "0.00")
            validateLinea(16) += sheet.DecimalValue(rowNumber, "S", "0.00")
            validateLinea(17) += sheet.DecimalValue(rowNumber, "T", "0.00")
            validateLinea(18) += sheet.DecimalValue(rowNumber, "U", "0.00")
            validateLinea(19) += sheet.DecimalValue(rowNumber, "V", "0.00")
            validateLinea(20) += sheet.DecimalValue(rowNumber, "W", "0.00")
            validateLinea(21) += sheet.DecimalValue(rowNumber, "X", "0.00")
            validateLinea(22) += sheet.DecimalValue(rowNumber, "Y", "0.00")
            validateLinea(23) += sheet.DecimalValue(rowNumber, "Z", "0.00")
            validateLinea(24) += sheet.DecimalValue(rowNumber, "AA", "0.00")
            validateLinea(25) += sheet.DecimalValue(rowNumber, "AB", "0.00")
            validateLinea(26) += sheet.DecimalValue(rowNumber, "AC", "0.00")
            validateLinea(27) += sheet.DecimalValue(rowNumber, "AD", "0.00")
            validateLinea(28) += sheet.DecimalValue(rowNumber, "AE", "0.00")

            validateLinea(29) += sheet.DecimalValue(rowNumber, "AF", "0.00")
            validateLinea(30) += sheet.DecimalValue(rowNumber, "AG", "0.00")
            validateLinea(31) += sheet.DecimalValue(rowNumber, "AH", "0.00")
            validateLinea(32) += sheet.DecimalValue(rowNumber, "AI", "0.00")
        End If

        Return item
    End Function

    Private Function LineasCuentaFinanciera(sheet As IXLWorksheet, rowNumber As Integer, witherror As Boolean) As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_ln
        Dim item As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_ln = AddLineaCuentaTecnicoFinanciera()

        With item.IngresosFinancieros_ln
            With .DesgloseIngresosFinancieros_ln
                .IngresosFinancieros = sheet.FormatDecimalValue(rowNumber, "C", "0.00")
                .IngresosFinancierosTomadorAsumeRiesgoInversion = sheet.FormatDecimalValue(rowNumber, "D", "0.00")
            End With
            '<!--[VIII] = 1 + 2-->
            .TotalIngresosFinancieros = (sheet.DecimalValue(rowNumber, "C", "0.00") +
                                                            sheet.DecimalValue(rowNumber, "D", "0.00")).ToDecimalAmount()
        End With
        With item.GastosFinancieros_ln
            With .DesgloseGastosFinancieros_ln
                .GastosFinancieros = sheet.FormatDecimalValue(rowNumber, "E", "0.00")
                .GastosFinancierosTomadorAsumeRiesgoInversion = sheet.FormatDecimalValue(rowNumber, "F", "0.00")
            End With
            '<!--[IX] = 1 + 2-->
            .TotalGastosFinancieros = (sheet.DecimalValue(rowNumber, "E", "0.00") +
                                                          sheet.DecimalValue(rowNumber, "F", "0.00")).ToDecimalAmount()
        End With
        '<!--[B] = VIII - IX-->
        item.TotalCuentaFinanciera = (item.IngresosFinancieros_ln.TotalIngresosFinancieros -
                                                         item.GastosFinancieros_ln.TotalGastosFinancieros).ToDecimalAmount()
        Return item
    End Function

    Private Function CuentaNoTecnica(sheet As IXLWorksheet, rowNumber As Integer) As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaNoTecnica
        Dim item As New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaNoTecnica

        With item
            ' <!--X-->
            .IngresosFinancieros = sheet.FormatDecimalValue(rowNumber, "A", "0.00")
            '<!--XI-->
            .GastosFinancieros = sheet.FormatDecimalValue(rowNumber, "B", "0.00")
            '<!--XII-->
            .OtrosIngresosNoTecnicos = sheet.FormatDecimalValue(rowNumber, "C", "0.00")
            '<!--XIII-->
            .OtrosGastosNoTecnicos = sheet.FormatDecimalValue(rowNumber, "D", "0.00")

            ' <!--[D] = X - XI + XII - XIII -->
            .TotalCuentaNoTecnica = (.IngresosFinancieros -
                                                        .GastosFinancieros +
                                                        .OtrosIngresosNoTecnicos -
                                                        .OtrosGastosNoTecnicos).ToDecimalAmount()
        End With
        Return item
    End Function

    Public Sub FileSerialize(filename As String, withFormat As Boolean)
        Utilities.SerializeHandler(Of ModeloCuentaTecnica).SerializeToFile(_CuentaTecnica, filename, withFormat)

        Dim result As List(Of String) = Nothing

        'Validacion segun el XSD enviado por la sugese
        result = Validate.XsdValidate("ModeloCuentaTecnica", filename)

        If Response.IsNotEmpty AndAlso Response.Rows.IsNotEmpty Then
            For Each item As DataRow In Response.Rows
                result.Add(item.StringValue("message"))
            Next
        End If
        If result.Count > 0 Then
            For Each item As String In result
                Helpers.XmlRespose.AddError(Response, "error", item)
            Next
        End If

    End Sub

    Private Function ProcessResultadoCuentaTecnicoFinanciera() As Integer
        Dim index As Integer = -1
        If _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera.IsNotEmpty Then
            For i As Integer = 0 To _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera.Length - 1
                If _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(i).idRamo = ramoActual Then
                    index = i
                    Exit For
                End If
            Next
        End If

        If index = -1 Then
            If _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera.IsEmpty Then
                ReDim Preserve _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(0)
                index = 0
            Else
                index = UBound(_CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera) + 1
                ReDim Preserve _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(index)
            End If

            _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(index) = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera
            With _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(index)
                .ResultadoCuentaTecnica = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnica
                .ResultadoCuentaFinanciera = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinanciera
                .idRamo = ramoActual
                .TotalCuentaTecnicoFinanciera = 0
                .ResultadoCuentaTecnica.PrimasImputadasNetasReaseguro = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguro
            End With
        End If

        Return index
    End Function

    Private Function ProcessResultadoLineaCuentaTecnicoFinanciera(indexRamo As Integer) As Integer
        Dim index As Integer = -1
        If _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(indexRamo).Lineas.IsNotEmpty Then
            For i As Integer = 0 To _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(indexRamo).Lineas.Length - 1
                If _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(indexRamo).Lineas(i).idLinea = lineaActual Then
                    index = i
                    Exit For
                End If
            Next
        End If

        If index = -1 Then
            If _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(indexRamo).Lineas.IsEmpty Then
                ReDim Preserve _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(indexRamo).Lineas(0)
                index = 0
            Else
                index = UBound(_CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(indexRamo).Lineas) + 1
                ReDim Preserve _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(indexRamo).Lineas(index)
            End If

            _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(indexRamo).Lineas(index) = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLinea
            With _CuentaTecnica.Datos.Modelo.UtilidadPerdidaNetaAntesImpuestosParticipaciones.ResultadoCuentaTecnicoFinanciera(indexRamo).Lineas(index)
                .ResultadoCuentaTecnicoFinanciera_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_ln
                .idLinea = lineaActual

                .ResultadoCuentaTecnicoFinanciera_ln.ResultadoCuentaTecnica_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_ln
                .ResultadoCuentaTecnicoFinanciera_ln.ResultadoCuentaFinanciera_ln = New ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_ln
                .ResultadoCuentaTecnicoFinanciera_ln.TotalCuentaTecnicoFinanciera_ln = 0

            End With
        End If

        Return index
    End Function

    Private Shared Function RowtoColumn(rowIndex As Integer) As String
        Dim result As String = String.Empty

        Select Case rowIndex
            Case 0
                result = "B"
            Case 1
                result = "C"
            Case 2
                result = "D"
            Case 3
                result = "E"
            Case 4
                result = "F"
            Case 5
                result = "G"
            Case 6
                result = "H"
            Case 7
                result = "I"
            Case 8
                result = "J"
            Case 9
                result = "K"
            Case 10
                result = "L"
            Case 11
                result = "M"

            Case 12
                result = "N"
            Case 13
                result = "O"
            Case 14
                result = "P"
            Case 15
                result = "Q"
            Case 16
                result = "R"
            Case 17
                result = "S"
            Case 18
                result = "T"
            Case 19
                result = "U"
            Case 20
                result = "V"

            Case 21
                result = "W"
            Case 22
                result = "X"
            Case 23
                result = "Y"
            Case 24
                result = "Z"
            Case 25
                result = "AA"
            Case 26
                result = "AB"
            Case 27
                result = "AC"
            Case 28
                result = "AD"
            Case 29
                result = "AE"
            Case 30
                result = "AF"
            Case 31
                result = "AG"
            Case 32
                result = "AH"

        End Select

        Return result
    End Function

    Public Shared Function Execute(xlsxFileName As String, xmlFileName As String, pediodoTrimestral As Integer, ano As Integer) As DataTable
        Dim result As DataTable = Nothing
        With New Generate(New Date(ano, pediodoTrimestral * 3, 1).LastDayOfMonth)
            .LoadExcelInformation(xlsxFileName)
            .FileSerialize(xmlFileName, False)
            result = .Response
        End With
        Return result
    End Function
End Class