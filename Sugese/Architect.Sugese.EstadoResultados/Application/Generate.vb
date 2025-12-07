Imports System.Configuration
Imports System.Net.Http
Imports Architect.API.Core.Business
Imports Architect.Sugese.Domain
Imports Architect.Sugese.Utility
Imports Architect.Sugese.Utility.Helpers
Imports Architect.Utilities.Extensions
Imports ClosedXML.Excel

Public Class Generate

    Inherits Architect.Sugese.Domain.GenerateBase

    Private _EstadoResultados As New EstadoResultados.ModeloEstadoResultados

    Public Property Response As DataTable

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="periodo">Fecha correspondiente al período al cual corresponde el modelo</param>
    ''' <remarks></remarks>
    Public Sub New(periodo As Date)
        ModelInit()
        With _EstadoResultados.Encabezado
            .NombreArchivo = String.Format("{0}-ModeloEstadoResultados", "sugese.codigoaseguradora".StringValue(0, "A03"))
            .Fecha = Today.ToString("yyyy-MM-dd")
            .Periodo = periodo.ToString("yyyy-MM-dd")
            .Periodicidad = EstadoResultados.Periodicidad.T
            .Moneda = CodMoneda.Item1
        End With
        _EstadoResultados.Datos.Modelo.EntidadFuente = ConfigurationManager.AppSettings("sugese.codigoaseguradora")
        Me.Response = XmlRespose.ReponseDataTable
    End Sub

    Public Sub FileSerialize(filename As String, withFormat As Boolean)
        Dim result As List(Of String) = Nothing
        Utilities.SerializeHandler(Of ModeloEstadoResultados).SerializeToFile(_EstadoResultados, filename, withFormat)

        'Validación según el XSD enviado por la sugese
        result = Validate.XsdValidate("ModeloEstadoResultados", filename)
        If result.Count > 0 Then
            For Each item As String In result
                XmlRespose.AddError(Response, "error", item)
            Next
        End If
    End Sub

    Private Sub ModelInit()
        _EstadoResultados = New ModeloEstadoResultados
        With _EstadoResultados
            .Encabezado = New EncabezadoTipo
            .Datos = New ModeloEstadoResultadosDatos
        End With
        'With _EstadoResultados.Encabezado
        '    .NombreArchivo = String.Empty
        '    .Fecha = NONE
        '    .Periodo = NONE
        '    .Periodicidad = a
        '    .Moneda = NONE
        'End With

        With _EstadoResultados.Datos
            .Modelo = New ModeloEstadoResultadosDatosModelo
        End With
        With _EstadoResultados.Datos.Modelo
            .CuentaResultadosTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotal
            .EntidadFuente = String.Empty
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal
            .UtilidadDespuesImpuestosAntesParticipaciones = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipaciones
            .ParticipacionesLegalesUtilidad = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalParticipacionesLegalesUtilidad
            .UtilidadNetaPeriodo = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones
            .UtilidadAntesImpuestosParticipaciones = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipaciones
            .ImpuestosSobreUtilidad = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesImpuestosSobreUtilidad
            .TotalUtilidadDespuesImpuestosAntesParticipaciones = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones
            .UtilidadOperacionesSeguros = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSeguros
            .ResultadoOtrasOperaciones = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperaciones
            .TotalUtilidad = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros
            .UtilidadBrutaOperacionesSegurosCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotal
            .SubtotalResultadoFinanciero = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinanciero
            .TotalUtilidadOperSeguros = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal
            .IngresosCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotal
            .GastosCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotal
            .VariacionProvisionesTecnicas = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalVariacionProvisionesTecnicas
            .TotalUtilidadBruta = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal
            .PrimasCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalPrimasCtaTotal
            .ComisionesParticipacionesIngresosCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalComisionesParticipacionesIngresosCtaTotal
            .SiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal
            .TotalIngresos = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal.PrimasCtaTotal
            .DesglosePrimasCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalPrimasCtaTotalDesglosePrimasCtaTotal
            .Total = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal.PrimasCtaTotal.DesglosePrimasCtaTotal
            .NetasExtornosYAnulacionesSeguroDirecto = 0
            .NetasExtornosYAnulacionesReaseguroAceptado = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal.ComisionesParticipacionesIngresosCtaTotal
            .DesgloseComisionesParticipacionesIngresosCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalComisionesParticipacionesIngresosCtaTotalDesgloseComisionesParticipacionesIngresosCtaTotal
            .Total = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal.ComisionesParticipacionesIngresosCtaTotal.DesgloseComisionesParticipacionesIngresosCtaTotal
            .ComisionesParticipacionesReaseguroCedido = 0
            .ComisionesParticipacionesReaseguroRetrocedido = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal.SiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal
            .DesgloseSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotalDesgloseSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal
            .Total = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal.SiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal.DesgloseSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal
            .SiniestrosGastosRecuperadosReaseguroCedido = 0
            .SiniestrosGastosRecuperadosReaseguroRetrocedido = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal
            .GastosPorPrestaciones = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosPorPrestaciones
            .ComisionesParticipacionesGastosCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalComisionesParticipacionesGastosCtaTotal
            .GastosAdministracionTecnicos = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosAdministracionTecnicos
            .PrimasCedidasReasegurosYFianzasCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalPrimasCedidasReasegurosYFianzasCtaTotal
            .TotalGastos = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.GastosPorPrestaciones
            .DesglosePrestacionesCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosPorPrestacionesDesglosePrestacionesCtaTotal
            .Total = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.GastosPorPrestaciones.DesglosePrestacionesCtaTotal
            .SiniestrosPagadosSeguroDirecto = 0
            .SiniestrosPagadosReaseguroAceptado = 0
            .BeneficiosExtornos = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.ComisionesParticipacionesGastosCtaTotal
            .DesgloseComisionesParticipacionesGastosCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalComisionesParticipacionesGastosCtaTotalDesgloseComisionesParticipacionesGastosCtaTotal
            .Total = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.ComisionesParticipacionesGastosCtaTotal.DesgloseComisionesParticipacionesGastosCtaTotal
            .GastoComisionesSeguroDirecto = 0
            .GastoComisionesParticipacionesReaseguroAceptado = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.GastosAdministracionTecnicos
            .DesgloseGastosAdministracionTecnicos = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosAdministracionTecnicosDesgloseGastosAdministracionTecnicos
            .TotalGastosAdministracionTecnicos = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.GastosAdministracionTecnicos.DesgloseGastosAdministracionTecnicos
            .GastosPersonal = 0
            .GastosServiciosExternos = 0
            .GastosMovilidad = 0
            .GastosInfraestructura = 0
            .GastosGenerales = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.PrimasCedidasReasegurosYFianzasCtaTotal
            .DesglosePrimasCedidasReasegurosYFianzasCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalPrimasCedidasReasegurosYFianzasCtaTotalDesglosePrimasCedidasReasegurosYFianzasCtaTotal
            .Total = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.PrimasCedidasReasegurosYFianzasCtaTotal.DesglosePrimasCedidasReasegurosYFianzasCtaTotal
            .ReaseguroCedido = 0
            .ReaseguroRetrocedido = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.VariacionProvisionesTecnicas
            .IngresosAjustesCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalVariacionProvisionesTecnicasIngresosAjustesCtaTotal
            .GastosAjustesCtaTotal = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalVariacionProvisionesTecnicasGastosAjustesCtaTotal
            .TotalVariacionProvisionesTecnicas = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.VariacionProvisionesTecnicas.IngresosAjustesCtaTotal
            .AjustesProvisionesTecnicas = 0
            .Total = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.VariacionProvisionesTecnicas.GastosAjustesCtaTotal
            .AjustesProvisionesTecnicas = 0
            .Total = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.SubtotalResultadoFinanciero
            .IngresosFinancieros = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroIngresosFinancieros
            .GastosFinancieros = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroGastosFinancieros
            .TotalSubtotalResultadoFinanciero = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.SubtotalResultadoFinanciero.IngresosFinancieros
            .DesgloseIngresosFinancieros = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroIngresosFinancierosDesgloseIngresosFinancieros
            .Total = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.SubtotalResultadoFinanciero.IngresosFinancieros.DesgloseIngresosFinancieros
            .Disponibilidades = 0
            .InversionesInstrumentosFinancieros = 0
            .ProductosCarteraCreditoVigente = 0
            .ProductosCarteraCreditosVencidaEnCobroJudicial = 0
            .CtasReciprocasInternas = 0
            .GananciasPosicionInstrumentosFinancierosDerivados = 0
            .GananciasDiferencialCambiarioYUnidadesDesarrollo = 0
            .OtrosIngresos = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.SubtotalResultadoFinanciero.GastosFinancieros
            .DesgloseGastosFinancieros = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroGastosFinancierosDesgloseGastosFinancieros
            .Total = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.SubtotalResultadoFinanciero.GastosFinancieros.DesgloseGastosFinancieros
            .ObligacionesPublico = 0
            'CUSTOM2020A
            '.ObligacionesBCCR = 0
            'CUSTOM2020A
            '.ObligacionesEntidadesFinancieras = 0
            .CtasPagarDiversas = 0
            .CtasReciprocasInternas = 0
            .ObligacionesSubordinadasConvertiblesPreferentes = 0
            .PerdidasPosicionInstrumentosFinancierosDerivados = 0
            .PerdidasDiferencialCambiarioYUnidadesDesarrollo = 0
            .OtrosGastos = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones
            .IngresosRecuperacionActivosDisminucionEstimacionesProvisiones = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosRecuperacionActivosDisminucionEstimacionesProvisiones
            .IngresosOperativosDiversos = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosOperativosDiversos
            .GastosEstimacionDeterioroActivos = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosEstimacionDeterioroActivos
            .GastosOperativosDiversos = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosOperativosDiversos
            .GastosAdministracion = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosAdministracion
            .TotalResultadoOtrasOperaciones = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.IngresosRecuperacionActivosDisminucionEstimacionesProvisiones
            .DesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosRecuperacionActivosDisminucionEstimacionesProvisionesDesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones
            .Total = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.IngresosRecuperacionActivosDisminucionEstimacionesProvisiones.DesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones
            .RecuperacionActivosFinancierosLiquidados = 0
            .CarteraCreditos = 0
            .InversionesInstrumentosFinancieros = 0
            .Provisiones = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.IngresosOperativosDiversos
            .DesgloseIngresosOperativosDiversos = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosOperativosDiversosDesgloseIngresosOperativosDiversos
            .Total = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.IngresosOperativosDiversos.DesgloseIngresosOperativosDiversos
            .ComisionesServicios = 0
            'CUSTOM2020A
            '.BienesRealizables = 0
            .ParticipacionesEnCapitalOtrasEmpresas = 0
            'CUSTOM2020A
            '.CambioYArbitrajeDivisas = 0
            .OtrosPartesRelacionadas = 0
            .OtrosIngresosOperativos = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.GastosEstimacionDeterioroActivos
            .DesgloseGastosEstimacionDeterioroActivos = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosEstimacionDeterioroActivosDesgloseGastosEstimacionDeterioroActivos
            .Total = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.GastosEstimacionDeterioroActivos.DesgloseGastosEstimacionDeterioroActivos
            .CarteraCreditosCuentasComisionesCobrar = 0
            .InversionesInstrumentosFinancieros = 0
            'CUSTOM2020A
            '.InversionesPropiedades = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.GastosOperativosDiversos
            .DesgloseGastosOperativosDiversos = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosOperativosDiversosDesgloseGastosOperativosDiversos
            .Total = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.GastosOperativosDiversos.DesgloseGastosOperativosDiversos
            .ComisionesServicios = 0
            'CUSTOM2020A
            '.BienesRealizables = 0
            .ParticipacionCapitalOtrasEmpresas = 0
            'CUSTOM2020A
            '.BienesDiversos = 0
            .Provisiones = 0
            'CUSTOM2020A
            '.BonificacionesComisionesFondosPensionVoluntario = 0
            'CUSTOM2020A
            '.CambioYArbitrajeDivisas = 0
            .PartesRelacionadas = 0
            .OtrosGastosOperativos = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.GastosAdministracion
            .DesgloseGastosAdministracion = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosAdministracionDesgloseGastosAdministracion
            .TotalGastosAdministracionNoTecnico = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.GastosAdministracion.DesgloseGastosAdministracion
            .Personal = 0
            .ServiciosExternos = 0
            .MovilidadYComunicaciones = 0
            .Infraestructura = 0
            .Generales = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.ImpuestosSobreUtilidad
            .DesgloseImpuestosSobreUtilidad = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesImpuestosSobreUtilidadDesgloseImpuestosSobreUtilidad
            .Total = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.ImpuestosSobreUtilidad.DesgloseImpuestosSobreUtilidad
            .SobreRenta = 0
            .DisminucionSobreRenta = 0
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.ParticipacionesLegalesUtilidad
            .DesgloseParticipacionesLegalesUtilidad = New ModeloEstadoResultadosDatosModeloCuentaResultadosTotalParticipacionesLegalesUtilidadDesgloseParticipacionesLegalesUtilidad
            .TotalLegalesSobreUtilidad = 0
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.ParticipacionesLegalesUtilidad.DesgloseParticipacionesLegalesUtilidad
            .LegalesSobreUtilidad = 0
            .DisminucionLegalesSobreUtilidad = 0
        End With

    End Sub

    Public Sub LoadExcelInformation(excelFilename As String)
        Dim workbook As New XLWorkbook(excelFilename)
        Dim sheet As IXLWorksheet = Nothing
        Dim RowNumber As Integer = 5

        Sheet_1(workbook.Worksheet("Utilidad bruta operaciones seg"), RowNumber)
        Sheet_2(workbook.Worksheet("Ingresos y gastos I"), RowNumber)
        Sheet_3(workbook.Worksheet("Ingresos y gastos II"), RowNumber)
        Sheet_4(workbook.Worksheet("Gastos y otros"), RowNumber)
        Sheet_5(workbook.Worksheet("Resultados Integrales"), 4)

        sheet = Nothing
        workbook = Nothing
    End Sub

    Private Sub Sheet_1(sheet As IXLWorksheet, RowNumber As Integer)
        'Ingresos Cta. Total
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal.PrimasCtaTotal
            .DesglosePrimasCtaTotal.NetasExtornosYAnulacionesSeguroDirecto = sheet.FormatDecimalValue(RowNumber, "A", "0.00")
            .DesglosePrimasCtaTotal.NetasExtornosYAnulacionesReaseguroAceptado = sheet.FormatDecimalValue(RowNumber, "B", "0.00")
            .Total = .DesglosePrimasCtaTotal.NetasExtornosYAnulacionesSeguroDirecto +
                     .DesglosePrimasCtaTotal.NetasExtornosYAnulacionesReaseguroAceptado
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal.ComisionesParticipacionesIngresosCtaTotal
            .DesgloseComisionesParticipacionesIngresosCtaTotal.ComisionesParticipacionesReaseguroCedido = sheet.FormatDecimalValue(RowNumber, "C", "0.00")
            .DesgloseComisionesParticipacionesIngresosCtaTotal.ComisionesParticipacionesReaseguroRetrocedido = sheet.FormatDecimalValue(RowNumber, "D", "0.00")
            .Total = .DesgloseComisionesParticipacionesIngresosCtaTotal.ComisionesParticipacionesReaseguroCedido +
                     .DesgloseComisionesParticipacionesIngresosCtaTotal.ComisionesParticipacionesReaseguroRetrocedido
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal.SiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal
            .DesgloseSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal.SiniestrosGastosRecuperadosReaseguroCedido = sheet.FormatDecimalValue(RowNumber, "E", "0.00")
            .DesgloseSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal.SiniestrosGastosRecuperadosReaseguroRetrocedido = sheet.FormatDecimalValue(RowNumber, "F", "0.00")
            .Total = .DesgloseSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal.SiniestrosGastosRecuperadosReaseguroCedido +
                     .DesgloseSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal.SiniestrosGastosRecuperadosReaseguroRetrocedido
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal
            .TotalIngresos = _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal.PrimasCtaTotal.Total +
                             _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal.ComisionesParticipacionesIngresosCtaTotal.Total +
                             _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal.SiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal.Total
        End With

        'Gastos Cta. Total
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.GastosPorPrestaciones
            .DesglosePrestacionesCtaTotal.SiniestrosPagadosSeguroDirecto = sheet.FormatDecimalValue(RowNumber, "G", "0.00")
            .DesglosePrestacionesCtaTotal.SiniestrosPagadosReaseguroAceptado = sheet.FormatDecimalValue(RowNumber, "H", "0.00")
            .DesglosePrestacionesCtaTotal.BeneficiosExtornos = sheet.FormatDecimalValue(RowNumber, "I", "0.00")
            .Total = .DesglosePrestacionesCtaTotal.SiniestrosPagadosSeguroDirecto +
                     .DesglosePrestacionesCtaTotal.SiniestrosPagadosReaseguroAceptado +
                     .DesglosePrestacionesCtaTotal.BeneficiosExtornos
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.ComisionesParticipacionesGastosCtaTotal
            .DesgloseComisionesParticipacionesGastosCtaTotal.GastoComisionesSeguroDirecto = sheet.FormatDecimalValue(RowNumber, "J", "0.00")
            .DesgloseComisionesParticipacionesGastosCtaTotal.GastoComisionesParticipacionesReaseguroAceptado = sheet.FormatDecimalValue(RowNumber, "K", "0.00")
            .Total = .DesgloseComisionesParticipacionesGastosCtaTotal.GastoComisionesSeguroDirecto +
                     .DesgloseComisionesParticipacionesGastosCtaTotal.GastoComisionesParticipacionesReaseguroAceptado
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.GastosAdministracionTecnicos
            .DesgloseGastosAdministracionTecnicos.GastosPersonal = sheet.FormatDecimalValue(RowNumber, "L", "0.00")
            .DesgloseGastosAdministracionTecnicos.GastosServiciosExternos = sheet.FormatDecimalValue(RowNumber, "M", "0.00")
            .DesgloseGastosAdministracionTecnicos.GastosMovilidad = sheet.FormatDecimalValue(RowNumber, "N", "0.00")
            .DesgloseGastosAdministracionTecnicos.GastosInfraestructura = sheet.FormatDecimalValue(RowNumber, "O", "0.00")
            .DesgloseGastosAdministracionTecnicos.GastosGenerales = sheet.FormatDecimalValue(RowNumber, "P", "0.00")
            .TotalGastosAdministracionTecnicos = .DesgloseGastosAdministracionTecnicos.GastosPersonal +
                                                 .DesgloseGastosAdministracionTecnicos.GastosServiciosExternos +
                                                 .DesgloseGastosAdministracionTecnicos.GastosMovilidad +
                                                 .DesgloseGastosAdministracionTecnicos.GastosInfraestructura +
                                                 .DesgloseGastosAdministracionTecnicos.GastosGenerales
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.PrimasCedidasReasegurosYFianzasCtaTotal
            .DesglosePrimasCedidasReasegurosYFianzasCtaTotal.ReaseguroCedido = sheet.FormatDecimalValue(RowNumber, "Q", "0.00")
            .DesglosePrimasCedidasReasegurosYFianzasCtaTotal.ReaseguroRetrocedido = sheet.FormatDecimalValue(RowNumber, "R", "0.00")
            .Total = .DesglosePrimasCedidasReasegurosYFianzasCtaTotal.ReaseguroCedido +
                     .DesglosePrimasCedidasReasegurosYFianzasCtaTotal.ReaseguroRetrocedido
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal
            .TotalGastos = _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.GastosPorPrestaciones.Total +
                           _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.ComisionesParticipacionesGastosCtaTotal.Total +
                           _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.GastosAdministracionTecnicos.TotalGastosAdministracionTecnicos +
                           _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.PrimasCedidasReasegurosYFianzasCtaTotal.Total
        End With

        'Variación Provisiones Técnicas
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.VariacionProvisionesTecnicas.IngresosAjustesCtaTotal
            .AjustesProvisionesTecnicas = sheet.FormatDecimalValue(RowNumber, "S", "0.00")
            .Total = .AjustesProvisionesTecnicas
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.VariacionProvisionesTecnicas.GastosAjustesCtaTotal
            .AjustesProvisionesTecnicas = sheet.FormatDecimalValue(RowNumber, "T", "0.00")
            .Total = .AjustesProvisionesTecnicas
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.VariacionProvisionesTecnicas
            .TotalVariacionProvisionesTecnicas = _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.VariacionProvisionesTecnicas.IngresosAjustesCtaTotal.Total -
                                                 _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.VariacionProvisionesTecnicas.GastosAjustesCtaTotal.Total
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal
            .TotalUtilidadBruta = _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.IngresosCtaTotal.TotalIngresos +
                                  _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.VariacionProvisionesTecnicas.TotalVariacionProvisionesTecnicas -
                                  _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.GastosCtaTotal.TotalGastos
        End With
    End Sub

    Private Sub Sheet_2(sheet As IXLWorksheet, RowNumber As Integer)
        'Ingresos Financieros
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.SubtotalResultadoFinanciero.IngresosFinancieros
            .DesgloseIngresosFinancieros.Disponibilidades = sheet.FormatDecimalValue(RowNumber, "A", "0.00")
            .DesgloseIngresosFinancieros.InversionesInstrumentosFinancieros = sheet.FormatDecimalValue(RowNumber, "B", "0.00")
            .DesgloseIngresosFinancieros.ProductosCarteraCreditoVigente = sheet.FormatDecimalValue(RowNumber, "C", "0.00")
            .DesgloseIngresosFinancieros.ProductosCarteraCreditosVencidaEnCobroJudicial = sheet.FormatDecimalValue(RowNumber, "D", "0.00")
            .DesgloseIngresosFinancieros.CtasReciprocasInternas = sheet.FormatDecimalValue(RowNumber, "E", "0.00")
            .DesgloseIngresosFinancieros.GananciasPosicionInstrumentosFinancierosDerivados = sheet.FormatDecimalValue(RowNumber, "F", "0.00")
            .DesgloseIngresosFinancieros.GananciasDiferencialCambiarioYUnidadesDesarrollo = sheet.FormatDecimalValue(RowNumber, "G", "0.00")
            .DesgloseIngresosFinancieros.OtrosIngresos = sheet.FormatDecimalValue(RowNumber, "H", "0.00")
            .Total = .DesgloseIngresosFinancieros.Disponibilidades +
                     .DesgloseIngresosFinancieros.InversionesInstrumentosFinancieros +
                     .DesgloseIngresosFinancieros.ProductosCarteraCreditoVigente +
                     .DesgloseIngresosFinancieros.ProductosCarteraCreditosVencidaEnCobroJudicial +
                     .DesgloseIngresosFinancieros.CtasReciprocasInternas +
                     .DesgloseIngresosFinancieros.GananciasPosicionInstrumentosFinancierosDerivados +
                     .DesgloseIngresosFinancieros.GananciasDiferencialCambiarioYUnidadesDesarrollo +
                     .DesgloseIngresosFinancieros.OtrosIngresos
        End With

        'Gastos Financieros
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.SubtotalResultadoFinanciero.GastosFinancieros
            .DesgloseGastosFinancieros.ObligacionesPublico = sheet.FormatDecimalValue(RowNumber, "I", "0.00")
            'CUSTOM2020A
            '.DesgloseGastosFinancieros.ObligacionesBCCR = sheet.FormatDecimalValue(RowNumber, "J", "0.00")
            'CUSTOM2020A
            .DesgloseGastosFinancieros.ObligEntidadesFinancierasYNoFinancieras = sheet.FormatDecimalValue(RowNumber, "K", "0.00")
            .DesgloseGastosFinancieros.CtasPagarDiversas = sheet.FormatDecimalValue(RowNumber, "L", "0.00")
            .DesgloseGastosFinancieros.CtasReciprocasInternas = sheet.FormatDecimalValue(RowNumber, "M", "0.00")
            .DesgloseGastosFinancieros.ObligacionesSubordinadasConvertiblesPreferentes = sheet.FormatDecimalValue(RowNumber, "N", "0.00")
            .DesgloseGastosFinancieros.PerdidasPosicionInstrumentosFinancierosDerivados = sheet.FormatDecimalValue(RowNumber, "O", "0.00")
            .DesgloseGastosFinancieros.PerdidasDiferencialCambiarioYUnidadesDesarrollo = sheet.FormatDecimalValue(RowNumber, "P", "0.00")
            .DesgloseGastosFinancieros.OtrosGastos = sheet.FormatDecimalValue(RowNumber, "Q", "0.00")
            .Total = .DesgloseGastosFinancieros.ObligacionesPublico +
                     .DesgloseGastosFinancieros.ObligEntidadesFinancierasYNoFinancieras +
                     .DesgloseGastosFinancieros.CtasPagarDiversas +
                     .DesgloseGastosFinancieros.CtasReciprocasInternas +
                     .DesgloseGastosFinancieros.ObligacionesSubordinadasConvertiblesPreferentes +
                     .DesgloseGastosFinancieros.PerdidasPosicionInstrumentosFinancierosDerivados +
                     .DesgloseGastosFinancieros.PerdidasDiferencialCambiarioYUnidadesDesarrollo +
                     .DesgloseGastosFinancieros.OtrosGastos
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.SubtotalResultadoFinanciero
            .TotalSubtotalResultadoFinanciero = _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.SubtotalResultadoFinanciero.IngresosFinancieros.Total -
                                                _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.SubtotalResultadoFinanciero.GastosFinancieros.Total
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros
            .TotalUtilidadOperSeguros = _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.UtilidadBrutaOperacionesSegurosCtaTotal.TotalUtilidadBruta +
                                        _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.SubtotalResultadoFinanciero.TotalSubtotalResultadoFinanciero
        End With
    End Sub

    Private Sub Sheet_3(sheet As IXLWorksheet, RowNumber As Integer)
        'Ingresos Recuperación Activos Disminución Estimaciones Provisiones
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.IngresosRecuperacionActivosDisminucionEstimacionesProvisiones
            .DesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones.RecuperacionActivosFinancierosLiquidados = sheet.FormatDecimalValue(RowNumber, "A", "0.00")
            .DesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones.CarteraCreditos = sheet.FormatDecimalValue(RowNumber, "B", "0.00")
            .DesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones.InversionesInstrumentosFinancieros = sheet.FormatDecimalValue(RowNumber, "C", "0.00")
            .DesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones.Provisiones = sheet.FormatDecimalValue(RowNumber, "D", "0.00")
            .Total = .DesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones.RecuperacionActivosFinancierosLiquidados +
                     .DesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones.CarteraCreditos +
                     .DesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones.InversionesInstrumentosFinancieros +
                     .DesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones.Provisiones
        End With

        'Ingresos Operativos Diversos
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.IngresosOperativosDiversos
            .DesgloseIngresosOperativosDiversos.ComisionesServicios = sheet.FormatDecimalValue(RowNumber, "E", "0.00")
            'CUSTOM2020A
            .DesgloseIngresosOperativosDiversos.BienesMantenidosVenta = sheet.FormatDecimalValue(RowNumber, "F", "0.00")
            .DesgloseIngresosOperativosDiversos.ParticipacionesEnCapitalOtrasEmpresas = sheet.FormatDecimalValue(RowNumber, "G", "0.00")
            'CUSTOM2020A
            '.DesgloseIngresosOperativosDiversos.CambioYArbitrajeDivisas = sheet.FormatDecimalValue(RowNumber, "H", "0.00")
            .DesgloseIngresosOperativosDiversos.OtrosPartesRelacionadas = sheet.FormatDecimalValue(RowNumber, "I", "0.00")
            .DesgloseIngresosOperativosDiversos.OtrosIngresosOperativos = sheet.FormatDecimalValue(RowNumber, "J", "0.00")
            .Total = .DesgloseIngresosOperativosDiversos.ComisionesServicios +
                     .DesgloseIngresosOperativosDiversos.BienesMantenidosVenta +
                     .DesgloseIngresosOperativosDiversos.ParticipacionesEnCapitalOtrasEmpresas +
                     .DesgloseIngresosOperativosDiversos.OtrosPartesRelacionadas +
                     .DesgloseIngresosOperativosDiversos.OtrosIngresosOperativos
        End With

        'Gastos Estimación Deterioro Activos
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.GastosEstimacionDeterioroActivos
            .DesgloseGastosEstimacionDeterioroActivos.CarteraCreditosCuentasComisionesCobrar = sheet.FormatDecimalValue(RowNumber, "K", "0.00")
            .DesgloseGastosEstimacionDeterioroActivos.InversionesInstrumentosFinancieros = sheet.FormatDecimalValue(RowNumber, "L", "0.00")
            'CUSTOM2020A
            .DesgloseGastosEstimacionDeterioroActivos.PropiedadesInversion = sheet.FormatDecimalValue(RowNumber, "M", "0.00")
            .DesgloseGastosEstimacionDeterioroActivos.CargosBienesDiversos = sheet.FormatDecimalValue(RowNumber, "N", "0.00")
            .Total = .DesgloseGastosEstimacionDeterioroActivos.CarteraCreditosCuentasComisionesCobrar +
                     .DesgloseGastosEstimacionDeterioroActivos.InversionesInstrumentosFinancieros +
                     .DesgloseGastosEstimacionDeterioroActivos.PropiedadesInversion +
                     .DesgloseGastosEstimacionDeterioroActivos.CargosBienesDiversos
        End With

    End Sub

    Private Sub Sheet_4(sheet As IXLWorksheet, RowNumber As Integer)
        'Gastos Operativos Diversos
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.GastosOperativosDiversos
            .DesgloseGastosOperativosDiversos.ComisionesServicios = sheet.FormatDecimalValue(RowNumber, "A", "0.00")
            'CUSTOM2020A
            .DesgloseGastosOperativosDiversos.BienesMantenidosVenta = sheet.FormatDecimalValue(RowNumber, "B", "0.00")
            .DesgloseGastosOperativosDiversos.ParticipacionCapitalOtrasEmpresas = sheet.FormatDecimalValue(RowNumber, "C", "0.00")
            'CUSTOM2020A
            '.DesgloseGastosOperativosDiversos.BienesDiversos = sheet.FormatDecimalValue(RowNumber, "D", "0.00")
            .DesgloseGastosOperativosDiversos.Provisiones = sheet.FormatDecimalValue(RowNumber, "E", "0.00")
            'CUSTOM2020A
            '.DesgloseGastosOperativosDiversos.BonificacionesComisionesFondosPensionVoluntario = sheet.FormatDecimalValue(RowNumber, "F", "0.00")
            'CUSTOM2020A
            '.DesgloseGastosOperativosDiversos.CambioYArbitrajeDivisas = sheet.FormatDecimalValue(RowNumber, "G", "0.00")
            .DesgloseGastosOperativosDiversos.PartesRelacionadas = sheet.FormatDecimalValue(RowNumber, "H", "0.00")
            .DesgloseGastosOperativosDiversos.OtrosGastosOperativos = sheet.FormatDecimalValue(RowNumber, "I", "0.00")
            .Total = .DesgloseGastosOperativosDiversos.ComisionesServicios +
                     .DesgloseGastosOperativosDiversos.BienesMantenidosVenta +
                     .DesgloseGastosOperativosDiversos.ParticipacionCapitalOtrasEmpresas +
                     .DesgloseGastosOperativosDiversos.Provisiones +
                     .DesgloseGastosOperativosDiversos.PartesRelacionadas +
                     .DesgloseGastosOperativosDiversos.OtrosGastosOperativos
        End With

        'Gastos Administración
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.GastosAdministracion
            .DesgloseGastosAdministracion.Personal = sheet.FormatDecimalValue(RowNumber, "J", "0.00")
            .DesgloseGastosAdministracion.ServiciosExternos = sheet.FormatDecimalValue(RowNumber, "K", "0.00")
            .DesgloseGastosAdministracion.MovilidadYComunicaciones = sheet.FormatDecimalValue(RowNumber, "L", "0.00")
            .DesgloseGastosAdministracion.Infraestructura = sheet.FormatDecimalValue(RowNumber, "M", "0.00")
            .DesgloseGastosAdministracion.Generales = sheet.FormatDecimalValue(RowNumber, "N", "0.00")
            .TotalGastosAdministracionNoTecnico = .DesgloseGastosAdministracion.Personal +
                                                  .DesgloseGastosAdministracion.ServiciosExternos +
                                                  .DesgloseGastosAdministracion.MovilidadYComunicaciones +
                                                  .DesgloseGastosAdministracion.Infraestructura +
                                                  .DesgloseGastosAdministracion.Generales
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones
            .TotalResultadoOtrasOperaciones = _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.IngresosRecuperacionActivosDisminucionEstimacionesProvisiones.Total +
                                              _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.IngresosOperativosDiversos.Total -
                                              _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.GastosEstimacionDeterioroActivos.Total -
                                              _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.GastosOperativosDiversos.Total -
                                              _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.GastosAdministracion.TotalGastosAdministracionNoTecnico
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones
            .TotalUtilidad = _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.UtilidadOperacionesSeguros.TotalUtilidadOperSeguros +
                             _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.ResultadoOtrasOperaciones.TotalResultadoOtrasOperaciones
        End With

        'Utilidad Después Impuestos Antes Participaciones
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.ImpuestosSobreUtilidad
            .DesgloseImpuestosSobreUtilidad.SobreRenta = sheet.FormatDecimalValue(RowNumber, "O", "0.00")
            .DesgloseImpuestosSobreUtilidad.DisminucionSobreRenta = sheet.FormatDecimalValue(RowNumber, "P", "0.00")
            .Total = .DesgloseImpuestosSobreUtilidad.SobreRenta -
                     .DesgloseImpuestosSobreUtilidad.DisminucionSobreRenta
        End With
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones
            .TotalUtilidadDespuesImpuestosAntesParticipaciones = _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.UtilidadAntesImpuestosParticipaciones.TotalUtilidad -
                                                                 _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.ImpuestosSobreUtilidad.Total
        End With

        'Participaciones Legales Utilidad
        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.ParticipacionesLegalesUtilidad
            .DesgloseParticipacionesLegalesUtilidad.LegalesSobreUtilidad = sheet.FormatDecimalValue(RowNumber, "Q", "0.00")
            .DesgloseParticipacionesLegalesUtilidad.DisminucionLegalesSobreUtilidad = sheet.FormatDecimalValue(RowNumber, "R", "0.00")
            .TotalLegalesSobreUtilidad = .DesgloseParticipacionesLegalesUtilidad.LegalesSobreUtilidad -
                                         .DesgloseParticipacionesLegalesUtilidad.DisminucionLegalesSobreUtilidad
        End With

        With _EstadoResultados.Datos.Modelo.CuentaResultadosTotal
            .UtilidadNetaPeriodo = _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadDespuesImpuestosAntesParticipaciones.TotalUtilidadDespuesImpuestosAntesParticipaciones -
                                   _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.ParticipacionesLegalesUtilidad.TotalLegalesSobreUtilidad
            .NoControladoras = 0D
            .Controladora = .UtilidadNetaPeriodo
        End With
    End Sub

    Private Sub Sheet_5(sheet As IXLWorksheet, RowNumber As Integer)
        _EstadoResultados.Datos.Modelo.ResultadosIntegrales = New EstadoResultados.ModeloEstadoResultadosDatosModeloResultadosIntegrales()
        _EstadoResultados.Datos.Modelo.ResultadosIntegrales.OtrosResultadosIntegrales = New EstadoResultados.ModeloEstadoResultadosDatosModeloResultadosIntegralesOtrosResultadosIntegrales()
        _EstadoResultados.Datos.Modelo.ResultadosIntegrales.OtrosResultadosIntegrales.DesgloseOtrosResultadosIntegrales = New EstadoResultados.ModeloEstadoResultadosDatosModeloResultadosIntegralesOtrosResultadosIntegralesDesgloseOtrosResultadosIntegrales()

        With _EstadoResultados.Datos.Modelo.ResultadosIntegrales.OtrosResultadosIntegrales.DesgloseOtrosResultadosIntegrales
            .SuperavitPropInmobiliarias = sheet.FormatDecimalValue(RowNumber, "A", "0.00")
            .InvCambiosResultadoIntegral = sheet.FormatDecimalValue(RowNumber, "B", "0.00")
            .InvRespaldoReservaLiquidez = sheet.FormatDecimalValue(RowNumber, "C", "0.00")
            .InstrFinanRestringidos = sheet.FormatDecimalValue(RowNumber, "D", "0.00")
            .InstrFinanCesacionPagosMorososLitigios = sheet.FormatDecimalValue(RowNumber, "E", "0.00")
            .SuperavitOtrosActivos = sheet.FormatDecimalValue(RowNumber, "F", "0.00")
            .InstrumentosDerivados = sheet.FormatDecimalValue(RowNumber, "G", "0.00")
            .OtrosAjustes = sheet.FormatDecimalValue(RowNumber, "H", "0.00")
        End With

        With _EstadoResultados.Datos.Modelo.ResultadosIntegrales.OtrosResultadosIntegrales
            .TotalOtrosResultadosIntegrales = .DesgloseOtrosResultadosIntegrales.SuperavitPropInmobiliarias +
                                              .DesgloseOtrosResultadosIntegrales.InvCambiosResultadoIntegral +
                                              .DesgloseOtrosResultadosIntegrales.InvRespaldoReservaLiquidez +
                                              .DesgloseOtrosResultadosIntegrales.InstrFinanRestringidos +
                                              .DesgloseOtrosResultadosIntegrales.InstrFinanCesacionPagosMorososLitigios +
                                              .DesgloseOtrosResultadosIntegrales.SuperavitOtrosActivos +
                                              .DesgloseOtrosResultadosIntegrales.InstrumentosDerivados +
                                              .DesgloseOtrosResultadosIntegrales.OtrosAjustes
        End With
        _EstadoResultados.Datos.Modelo.ResultadosIntegrales.TotalDelPeriodo = _EstadoResultados.Datos.Modelo.ResultadosIntegrales.OtrosResultadosIntegrales.TotalOtrosResultadosIntegrales +
                                                                              _EstadoResultados.Datos.Modelo.CuentaResultadosTotal.UtilidadNetaPeriodo
        _EstadoResultados.Datos.Modelo.ResultadosIntegrales.NoControladoras = 0D
        _EstadoResultados.Datos.Modelo.ResultadosIntegrales.Controladora = _EstadoResultados.Datos.Modelo.ResultadosIntegrales.TotalDelPeriodo

        '     <CuentaResultadosTotal UtilidadNetaPeriodo="467173766.93" NoControladoras="0.00" Controladora="467173766.93">
        '<ResultadosIntegrales NoControladoras="0.00" Controladora="468322832.44" TotalDelPeriodo="468322832.44">
        '<OtrosResultadosIntegrales TotalOtrosResultadosIntegrales="1149065.51">

    End Sub

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