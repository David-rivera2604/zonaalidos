Imports System.Configuration
Imports System.Net.Http
Imports Architect.Sugese.Domain
Imports Architect.Sugese.Utility
Imports Architect.Sugese.Utility.Helpers
Imports Architect.Utilities.Extensions
Imports ClosedXML.Excel

Public Class Generate


    Private _Patrimonio As New ModeloEstadoCambiosPatrimonioPropio

    Public Property Response As DataTable

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="periodo">Fecha correspondiente al período al cual corresponde el modelo</param>
    ''' <remarks></remarks>
    Public Sub New(periodo As Date)
        ModelInit()
        With _Patrimonio.Encabezado
            .NombreArchivo = String.Format("{0}-ModeloEstadoCambiosPatrimonioPropio", ConfigurationManager.AppSettings("sugese.entidadaseguradora"))
            .Fecha = Today.ToString("yyyy-MM-dd")
            .Periodo = periodo.ToString("yyyy-MM-dd")
            .Periodicidad = Periodicidad.T
            .Moneda = CodMoneda.Item1
        End With
        _Patrimonio.Datos.Modelo.EntidadFuente = ConfigurationManager.AppSettings("sugese.codigoaseguradora")
        Me.Response = XmlRespose.ReponseDataTable
    End Sub

    Public Sub FileSerialize(filename As String, withFormat As Boolean)
        Utilities.SerializeHandler(Of ModeloEstadoCambiosPatrimonioPropio).SerializeToFile(_Patrimonio, filename, withFormat)
        Dim result As List(Of String) = Nothing
        'Validación según el XSD enviado por la sugese
        result = Validate.XsdValidate("ModeloEstadoCambiosPatrimonioPropio", filename)
        If Response.IsNotEmpty AndAlso Response.Rows.IsNotEmpty Then
            For Each item As DataRow In Response.Rows
                result.Add(item.StringValue("message"))
            Next
        End If
        If result.Count > 0 Then

            For Each item As String In result
                XmlRespose.AddError(Response, "error", item)
            Next
        End If
    End Sub
    Private Sub ModelInit()
        _Patrimonio = New ModeloEstadoCambiosPatrimonioPropio
        With _Patrimonio
            .Encabezado = New Patrimonio.EncabezadoTipo
            .Datos = New ModeloEstadoCambiosPatrimonioPropioDatos
        End With
        With _Patrimonio.Encabezado
            .NombreArchivo = String.Empty
            .Fecha = String.Empty
            .Periodo = String.Empty
            .Periodo = String.Empty
            .Periodicidad = Periodicidad.T
            .Moneda = CodMoneda.Item1
        End With

        With _Patrimonio.Datos
            .Modelo = New ModeloEstadoCambiosPatrimonioPropioDatosModelo
        End With
        With _Patrimonio.Datos.Modelo
            .Saldo1EneAnnoAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnterior
            .SaldoCorregidoInicioAnnoAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnterior
            .Saldo31DicAnnoAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnterior
            .Saldo1EneAnnoActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActual
            .SaldoCorregidoInicioAnnoActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoActual
            .OriginadosAnnoActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActual
            .TranferenciasResultadosAnnoActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActual
            .SaldoFinalAnnoActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActual
            .EntidadFuente = String.Empty
        End With
        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoAnterior
            .DesgloseSaldoInicioAnno = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorDesgloseSaldoInicioAnno
            .CambiosPoliticasContablesEneAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCambiosPoliticasContablesEneAnterior
            .CorreccionErroresFundamentalesEneAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCorreccionErroresFundamentalesEneAnterior
            .TotalSaldo1EneAnnoAnterior = 0
        End With
        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoAnterior.DesgloseSaldoInicioAnno
            .CapSocialEneAnterior = 0
            .AportesNoCapitalizadosEneAnterior = 0
            .AjustesEneAnterior = 0
            .ReservasEneAnterior = 0
            .ResultadosPrincipioPeriodoEneAnterior = 0
        End With

        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoAnterior.CambiosPoliticasContablesEneAnterior
            .DesgloseCambiosPoliticasContablesEneAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCambiosPoliticasContablesEneAnteriorDesgloseCambiosPoliticasContablesEneAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoAnterior.CambiosPoliticasContablesEneAnterior.DesgloseCambiosPoliticasContablesEneAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoAnterior.CorreccionErroresFundamentalesEneAnterior
            .DesgloseCorreccionErroresFundamentalesEneAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCorreccionErroresFundamentalesEneAnteriorDesgloseCorreccionErroresFundamentalesEneAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoAnterior.CorreccionErroresFundamentalesEneAnterior.DesgloseCorreccionErroresFundamentalesEneAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With



        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior
            .DesgloseSaldoCorregidoInicioAnnoAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorDesgloseSaldoCorregidoInicioAnnoAnterior
            .AjustesConversionEstadosFinancierosIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesConversionEstadosFinancierosIniAnterior
            .ResultadosPeriodo1 = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorResultadosPeriodo1
            .DividendosPeriodo0 = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorDividendosPeriodo0
            .EstimacionesRiesgosActBancariaIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEstimacionesRiesgosActBancariaIniAnterior
            .ReservasLegalesOtrasEstatutariasIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorReservasLegalesOtrasEstatutariasIniAnterior
            .CompraVentaAccionesTesoreriaIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCompraVentaAccionesTesoreriaIniAnterior
            .EmisionAccionesIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEmisionAccionesIniAnterior
            .CapitalPagadoAdicionalIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCapitalPagadoAdicionalIniAnterior
            'CUSTOM2020A
            .SuperavitRevaPropiedadMobiliarioEquipoIniAnterior = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaPropiedadMobiliarioEquipoIniAnterior
            'CUSTOM2020A
            .AjustesValuacionInversionesValRazCambiosResulIntegIniAnterior = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior
            .AjustesValuacionInstrumentosRestringidosIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosRestringidosIniAnterior
            .AjustesValuacionInstrumentosCesacionPagoIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosCesacionPagoIniAnterior
            .SuperavitRevaOtrosActivos = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaOtrosActivos
            .OtrosCorregidosIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorOtrosCorregidosIniAnterior
            .TotalSaldoCorregidoInicioAnnoAnterior = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.DesgloseSaldoCorregidoInicioAnnoAnterior
            .CapSocialIniAnterior = 0
            .AportesNoCapitalizadosIniAnterior = 0
            .AjustesIniAnterior = 0
            .ReservasIniAnterior = 0
            .ResultadosPrincipioPeriodoIniAnterior = 0
        End With

        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.AjustesConversionEstadosFinancierosIniAnterior
            .DesgloseAjustesConversionEstadosFinancierosIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesConversionEstadosFinancierosIniAnteriorDesgloseAjustesConversionEstadosFinancierosIniAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.AjustesConversionEstadosFinancierosIniAnterior.DesgloseAjustesConversionEstadosFinancierosIniAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.ResultadosPeriodo1
            .DesgloseResultadosPeriodo1 = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorResultadosPeriodo1DesgloseResultadosPeriodo1
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.ResultadosPeriodo1.DesgloseResultadosPeriodo1
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.DividendosPeriodo0
            .DesgloseDividendosPeriodo0 = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorDividendosPeriodo0DesgloseDividendosPeriodo0
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.DividendosPeriodo0.DesgloseDividendosPeriodo0
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.EstimacionesRiesgosActBancariaIniAnterior
            .DesgloseEstimacionesRiesgosActBancariaIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEstimacionesRiesgosActBancariaIniAnteriorDesgloseEstimacionesRiesgosActBancariaIniAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.EstimacionesRiesgosActBancariaIniAnterior.DesgloseEstimacionesRiesgosActBancariaIniAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.ReservasLegalesOtrasEstatutariasIniAnterior
            .DesgloseReservasLegalesOtrasEstatutariasIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorReservasLegalesOtrasEstatutariasIniAnteriorDesgloseReservasLegalesOtrasEstatutariasIniAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.ReservasLegalesOtrasEstatutariasIniAnterior.DesgloseReservasLegalesOtrasEstatutariasIniAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.CompraVentaAccionesTesoreriaIniAnterior
            .DesgloseCompraVentaAccionesTesoreriaIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCompraVentaAccionesTesoreriaIniAnteriorDesgloseCompraVentaAccionesTesoreriaIniAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.CompraVentaAccionesTesoreriaIniAnterior.DesgloseCompraVentaAccionesTesoreriaIniAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.EmisionAccionesIniAnterior
            .DesgloseEmisionAccionesIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEmisionAccionesIniAnteriorDesgloseEmisionAccionesIniAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.EmisionAccionesIniAnterior.DesgloseEmisionAccionesIniAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.CapitalPagadoAdicionalIniAnterior
            .DesgloseCapitalPagadoAdicionalIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCapitalPagadoAdicionalIniAnteriorDesgloseCapitalPagadoAdicionalIniAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.CapitalPagadoAdicionalIniAnterior.DesgloseCapitalPagadoAdicionalIniAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With

        'CUSTOM2020A
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.SuperavitRevaPropiedadMobiliarioEquipoIniAnterior
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaPropiedadMobiliarioEquipoIniAnteriorDesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.SuperavitRevaPropiedadMobiliarioEquipoIniAnterior.DesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With

        'CUSTOM2020A
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.AjustesValuacionInversionesValRazCambiosResulIntegIniAnterior
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInversionesValRazCambiosResulIntegIniAnteriorDesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.AjustesValuacionInversionesValRazCambiosResulIntegIniAnterior.DesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.AjustesValuacionInstrumentosRestringidosIniAnterior
            .DesgloseAjustesValuacionInstrumentosRestringidosIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosRestringidosIniAnteriorDesgloseAjustesValuacionInstrumentosRestringidosIniAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.AjustesValuacionInstrumentosRestringidosIniAnterior.DesgloseAjustesValuacionInstrumentosRestringidosIniAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.AjustesValuacionInstrumentosCesacionPagoIniAnterior
            .DesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosCesacionPagoIniAnteriorDesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.AjustesValuacionInstrumentosCesacionPagoIniAnterior.DesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.SuperavitRevaOtrosActivos
            .DesgloseSuperavitRevaOtrosActivos = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaOtrosActivosDesgloseSuperavitRevaOtrosActivos
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.SuperavitRevaOtrosActivos.DesgloseSuperavitRevaOtrosActivos
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.OtrosCorregidosIniAnterior
            .DesgloseOtrosIniAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorOtrosCorregidosIniAnteriorDesgloseOtrosIniAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.OtrosCorregidosIniAnterior.DesgloseOtrosIniAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With



        With _Patrimonio.Datos.Modelo.Saldo31DicAnnoAnterior
            .DesgloseSaldo31DicAnnoAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorDesgloseSaldo31DicAnnoAnterior
            'CUSTOM2020A
            .AtribuidoParticipNoControlFinAnterior = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoParticipNoControlFinAnterior
            .AtribuidoControladoraFinAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoControladoraFinAnterior
            .TotalSaldo31DicAnnoAnterior = 0
        End With
        With _Patrimonio.Datos.Modelo.Saldo31DicAnnoAnterior.DesgloseSaldo31DicAnnoAnterior
            .CapSocialFinAnterior = 0
            .AportesNoCapitalizadosFinAnterior = 0
            .AjustesFinAnterior = 0
            .ReservasFinAnterior = 0
            .ResultadosPrincipioPeriodoFinAnterior = 0
        End With

        'CUSTOM2020A
        With _Patrimonio.Datos.Modelo.Saldo31DicAnnoAnterior.AtribuidoParticipNoControlFinAnterior
            .DesgloseAtribuidoParticipNoControlFinAnterior = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoParticipNoControlFinAnteriorDesgloseAtribuidoParticipNoControlFinAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.Saldo31DicAnnoAnterior.AtribuidoParticipNoControlFinAnterior.DesgloseAtribuidoParticipNoControlFinAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.Saldo31DicAnnoAnterior.AtribuidoControladoraFinAnterior
            .DesgloseAtribuidoControladoraFinAnterior = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoControladoraFinAnteriorDesgloseAtribuidoControladoraFinAnterior
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.Saldo31DicAnnoAnterior.AtribuidoControladoraFinAnterior.DesgloseAtribuidoControladoraFinAnterior
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With



        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoActual
            .DesgloseSaldo1EneAnnoActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualDesgloseSaldo1EneAnnoActual
            .CambiosPoliticasContablesEneActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCambiosPoliticasContablesEneActual
            .CorreccionErroresFundamentalesEneActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCorreccionErroresFundamentalesEneActual
            .TotalSaldo1EneAnnoActual = 0
        End With
        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoActual.DesgloseSaldo1EneAnnoActual
            .CapSocialEneActual = 0
            .AportesNoCapitalizadosEneActual = 0
            .AjustesEneActual = 0
            .ReservasEneActual = 0
            .ResultadosPrincipioPeriodoEneActual = 0
        End With

        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoActual.CambiosPoliticasContablesEneActual
            .DesgloseCambiosPoliticasContablesEneActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCambiosPoliticasContablesEneActualDesgloseCambiosPoliticasContablesEneActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoActual.CambiosPoliticasContablesEneActual.DesgloseCambiosPoliticasContablesEneActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoActual.CorreccionErroresFundamentalesEneActual
            .DesgloseCorreccionErroresFundamentalesEneActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCorreccionErroresFundamentalesEneActualDesgloseCorreccionErroresFundamentalesEneActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoActual.CorreccionErroresFundamentalesEneActual.DesgloseCorreccionErroresFundamentalesEneActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With



        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoActual
            .DesgloseSaldoCorregidoInicioAnnoActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoActualDesgloseSaldoCorregidoInicioAnnoActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoActual.DesgloseSaldoCorregidoInicioAnnoActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual
            .DesgloseOriginadosAnnoActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualDesgloseOriginadosAnnoActual
            .AjustesConversionEstadosFinancierosOrigActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesConversionEstadosFinancierosOrigActual
            'CUSTOM2020A
            .AjustesValuacionInversionesValRazCambiosResulIntegOrigActual = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegOrigActual
            .AjustesValuacionInstrumentosRestringidosOrigActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosRestringidosOrigActual
            .AjustesValuacionInstrumentosCesacionPagoOrigActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosCesacionPagoOrigActual
            .OtrosOriginadosAnnoActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualOtrosOriginadosAnnoActual
            .TotalOriginadosAnnoActual = 0
        End With
        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.DesgloseOriginadosAnnoActual
            .CapSocialOrigActual = 0
            .AportesNoCapitalizadosOrigActual = 0
            .AjustesOrigActual = 0
            .ReservasOrigActual = 0
            .ResultadosPrincipioPeriodoOrigActual = 0
        End With

        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.AjustesConversionEstadosFinancierosOrigActual
            .DesgloseAjustesConversionEstadosFinancierosOrigActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesConversionEstadosFinancierosOrigActualDesgloseAjustesConversionEstadosFinancierosOrigActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.AjustesConversionEstadosFinancierosOrigActual.DesgloseAjustesConversionEstadosFinancierosOrigActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        'CUSTOM2020A
        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.AjustesValuacionInversionesValRazCambiosResulIntegOrigActual
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegOrigActualDesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.AjustesValuacionInversionesValRazCambiosResulIntegOrigActual.DesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.AjustesValuacionInstrumentosRestringidosOrigActual
            .DesgloseAjustesValuacionInstrumentosRestringidosOrigActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosRestringidosOrigActualDesgloseAjustesValuacionInstrumentosRestringidosOrigActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.AjustesValuacionInstrumentosRestringidosOrigActual.DesgloseAjustesValuacionInstrumentosRestringidosOrigActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.AjustesValuacionInstrumentosCesacionPagoOrigActual
            .DesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosCesacionPagoOrigActualDesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.AjustesValuacionInstrumentosCesacionPagoOrigActual.DesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.OtrosOriginadosAnnoActual
            .DesgloseOtrosOrigActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualOtrosOriginadosAnnoActualDesgloseOtrosOrigActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.OtrosOriginadosAnnoActual.DesgloseOtrosOrigActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With



        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual
            .DesgloseTranferenciasResultadosAnnoActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualDesgloseTranferenciasResultadosAnnoActual
            'CUSTOM2020A
            .AjustesValuacionInversionesValRazCambiosResulIntegTransfActual = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegTransfActual
            .AjustesValuacionInstrumentosRestringidosTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosRestringidosTransfActual
            .AjustesValuacionInstrumentosCesacionPagoTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosCesacionPagoTransfActual
            .OtrosTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualOtrosTransfActual
            .GananciaPerdidaNoReconocidaPeriodo2 = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualGananciaPerdidaNoReconocidaPeriodo2
            .ResultadoPeriodo2 = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualResultadoPeriodo2
            .ReservasLegalesOtrasEstatutariasTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualReservasLegalesOtrasEstatutariasTransfActual
            .DividendosPeriodo1 = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualDividendosPeriodo1
            .EstimacionesRiesgosActBancariaTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEstimacionesRiesgosActBancariaTransfActual
            .CompraVentaAccionesTesoreriaTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCompraVentaAccionesTesoreriaTransfActual
            .EmisionAccionesTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEmisionAccionesTransfActual
            .CapitalPagadoAdicionalTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCapitalPagadoAdicionalTransfActual
            'CUSTOM2020A
            .SuperavitRevaPropiedadMobiliarioEquipoTransfActual = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoTransfActual
            .TransferenciaSuperavit = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualTransferenciaSuperavit
            'CUSTOM2020A
            .SuperavitRevaPropiedadMobiliarioEquipoNeto = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoNeto
            .TotalTranferenciasResultadosAnnoActual = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.DesgloseTranferenciasResultadosAnnoActual
            .CapSocialTransfActual = 0
            .AportesNoCapitalizadosTransfActual = 0
            .AjustesTransfActual = 0
            .ReservasTransfActual = 0
            .ResultadosPrincipioPeriodoTransfActual = 0
        End With

        'CUSTOM2020A
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.AjustesValuacionInversionesValRazCambiosResulIntegTransfActual
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegTransfActualDesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.AjustesValuacionInversionesValRazCambiosResulIntegTransfActual.DesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.AjustesValuacionInstrumentosRestringidosTransfActual
            .DesgloseAjustesValuacionInstrumentosRestringidosTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosRestringidosTransfActualDesgloseAjustesValuacionInstrumentosRestringidosTransfActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.AjustesValuacionInstrumentosRestringidosTransfActual.DesgloseAjustesValuacionInstrumentosRestringidosTransfActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.AjustesValuacionInstrumentosCesacionPagoTransfActual
            .DesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosCesacionPagoTransfActualDesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.AjustesValuacionInstrumentosCesacionPagoTransfActual.DesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.OtrosTransfActual
            .DesgloseOtrosTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualOtrosTransfActualDesgloseOtrosTransfActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.OtrosTransfActual.DesgloseOtrosTransfActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.GananciaPerdidaNoReconocidaPeriodo2
            .DesgloseGananciaPerdidaNoReconocidaPeriodo2 = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualGananciaPerdidaNoReconocidaPeriodo2DesgloseGananciaPerdidaNoReconocidaPeriodo2
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.GananciaPerdidaNoReconocidaPeriodo2.DesgloseGananciaPerdidaNoReconocidaPeriodo2
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.ResultadoPeriodo2
            .DesgloseResultadoPeriodo2 = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualResultadoPeriodo2DesgloseResultadoPeriodo2
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.ResultadoPeriodo2.DesgloseResultadoPeriodo2
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.ReservasLegalesOtrasEstatutariasTransfActual
            .DesgloseReservasLegalesOtrasEstatutariasTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualReservasLegalesOtrasEstatutariasTransfActualDesgloseReservasLegalesOtrasEstatutariasTransfActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.ReservasLegalesOtrasEstatutariasTransfActual.DesgloseReservasLegalesOtrasEstatutariasTransfActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.DividendosPeriodo1
            .DesgloseDividendosPeriodo1 = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualDividendosPeriodo1DesgloseDividendosPeriodo1
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.DividendosPeriodo1.DesgloseDividendosPeriodo1
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.EstimacionesRiesgosActBancariaTransfActual
            .DesgloseEstimacionesRiesgosActBancariaTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEstimacionesRiesgosActBancariaTransfActualDesgloseEstimacionesRiesgosActBancariaTransfActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.EstimacionesRiesgosActBancariaTransfActual.DesgloseEstimacionesRiesgosActBancariaTransfActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.CompraVentaAccionesTesoreriaTransfActual
            .DesgloseCompraVentaAccionesTesoreriaTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCompraVentaAccionesTesoreriaTransfActualDesgloseCompraVentaAccionesTesoreriaTransfActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.CompraVentaAccionesTesoreriaTransfActual.DesgloseCompraVentaAccionesTesoreriaTransfActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.EmisionAccionesTransfActual
            .DesgloseEmisionAccionesTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEmisionAccionesTransfActualDesgloseEmisionAccionesTransfActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.EmisionAccionesTransfActual.DesgloseEmisionAccionesTransfActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.CapitalPagadoAdicionalTransfActual
            .DesgloseCapitalPagadoAdicionalTransfActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCapitalPagadoAdicionalTransfActualDesgloseCapitalPagadoAdicionalTransfActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.CapitalPagadoAdicionalTransfActual.DesgloseCapitalPagadoAdicionalTransfActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With

        'CUSTOM2020A
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.SuperavitRevaPropiedadMobiliarioEquipoTransfActual
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoTransfActualDesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.SuperavitRevaPropiedadMobiliarioEquipoTransfActual.DesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.TransferenciaSuperavit
            .DesgloseTransferenciaSuperavit = New ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualTransferenciaSuperavitDesgloseTransferenciaSuperavit
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.TransferenciaSuperavit.DesgloseTransferenciaSuperavit
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With

        'CUSTOM2020A
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.SuperavitRevaPropiedadMobiliarioEquipoNeto
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoNetoDesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.SuperavitRevaPropiedadMobiliarioEquipoNeto.DesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With



        With _Patrimonio.Datos.Modelo.SaldoFinalAnnoActual
            .DesgloseSaldoFinalAnnoActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualDesgloseSaldoFinalAnnoActual
            'CUSTOM2020A
            .AtribuidoParticipNoControlFinActual = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoParticipNoControlFinActual
            .AtribuidoControladoraFinActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoControladoraFinActual
            .TotalSaldoFinalAnnoActual = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoFinalAnnoActual.DesgloseSaldoFinalAnnoActual
            .CapSocialFinActual = 0
            .AportesNoCapitalizadosFinActual = 0
            .AjustesFinActual = 0
            .ReservasFinActual = 0
            .ResultadosPrincipioPeriodoFinActual = 0
        End With

        'CUSTOM2020A
        With _Patrimonio.Datos.Modelo.SaldoFinalAnnoActual.AtribuidoParticipNoControlFinActual
            .DesgloseAtribuidoParticipNoControlFinActual = New Patrimonio.ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoParticipNoControlFinActualDesgloseAtribuidoParticipNoControlFinActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoFinalAnnoActual.AtribuidoParticipNoControlFinActual.DesgloseAtribuidoParticipNoControlFinActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With


        With _Patrimonio.Datos.Modelo.SaldoFinalAnnoActual.AtribuidoControladoraFinActual
            .DesgloseAtribuidoControladoraFinActual = New ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoControladoraFinActualDesgloseAtribuidoControladoraFinActual
            .Total = 0
        End With
        With _Patrimonio.Datos.Modelo.SaldoFinalAnnoActual.AtribuidoControladoraFinActual.DesgloseAtribuidoControladoraFinActual
            .CapSocial = 0
            .AportesNoCapitalizados = 0
            .Ajustes = 0
            .Reservas = 0
            .ResultadosPrincipioPeriodo = 0
        End With





    End Sub

    Public Sub LoadExcelInformation(excelFilename As String)
        Dim workbook As New XLWorkbook(excelFilename)
        Dim sheet As IXLWorksheet = Nothing

        sheet = workbook.Worksheet("Detalle")
        Rows_02_to_04(sheet)
        Rows_06_to_20(sheet)

        Rows_22_to_24(sheet)
        Rows_26_to_28(sheet)
        Rows_30_to_30(sheet)
        Rows_32_to_37(sheet)
        Rows_39_to_54(sheet)
        Rows_56_to_58(sheet)

        sheet = Nothing
        workbook = Nothing
    End Sub

    Private Sub Rows_02_to_04(sheet As IXLWorksheet)
        'Saldo 1 ene año anterior
        'Saldo 1 ene año anterior
        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoAnterior
            .DesgloseSaldoInicioAnno.CapSocialEneAnterior = sheet.FormatDecimalValue(2, "C", "0.00")
            .DesgloseSaldoInicioAnno.AportesNoCapitalizadosEneAnterior = sheet.FormatDecimalValue(2, "D", "0.00")
            .DesgloseSaldoInicioAnno.AjustesEneAnterior = sheet.FormatDecimalValue(2, "E", "0.00")
            .DesgloseSaldoInicioAnno.ReservasEneAnterior = sheet.FormatDecimalValue(2, "F", "0.00")
            .DesgloseSaldoInicioAnno.ResultadosPrincipioPeriodoEneAnterior = sheet.FormatDecimalValue(2, "G", "0.00")
            .TotalSaldo1EneAnnoAnterior = .DesgloseSaldoInicioAnno.CapSocialEneAnterior +
                                          .DesgloseSaldoInicioAnno.AportesNoCapitalizadosEneAnterior +
                                          .DesgloseSaldoInicioAnno.AjustesEneAnterior +
                                          .DesgloseSaldoInicioAnno.ReservasEneAnterior +
                                          .DesgloseSaldoInicioAnno.ResultadosPrincipioPeriodoEneAnterior
        End With

        'Saldo 1 ene año anterior
        'Cambios políticas contables ene anterior
        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoAnterior.CambiosPoliticasContablesEneAnterior
            .DesgloseCambiosPoliticasContablesEneAnterior.CapSocial = sheet.FormatDecimalValue(3, "C", "0.00")
            .DesgloseCambiosPoliticasContablesEneAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(3, "D", "0.00")
            .DesgloseCambiosPoliticasContablesEneAnterior.Ajustes = sheet.FormatDecimalValue(3, "E", "0.00")
            .DesgloseCambiosPoliticasContablesEneAnterior.Reservas = sheet.FormatDecimalValue(3, "F", "0.00")
            .DesgloseCambiosPoliticasContablesEneAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(3, "G", "0.00")
            .Total = .DesgloseCambiosPoliticasContablesEneAnterior.CapSocial +
                     .DesgloseCambiosPoliticasContablesEneAnterior.AportesNoCapitalizados +
                     .DesgloseCambiosPoliticasContablesEneAnterior.Ajustes +
                     .DesgloseCambiosPoliticasContablesEneAnterior.Reservas +
                     .DesgloseCambiosPoliticasContablesEneAnterior.ResultadosPrincipioPeriodo
        End With

        'Saldo 1 ene año anterior
        'Corrección errores fundamentales ene anterior
        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoAnterior.CorreccionErroresFundamentalesEneAnterior
            .DesgloseCorreccionErroresFundamentalesEneAnterior.CapSocial = sheet.FormatDecimalValue(4, "C", "0.00")
            .DesgloseCorreccionErroresFundamentalesEneAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(4, "D", "0.00")
            .DesgloseCorreccionErroresFundamentalesEneAnterior.Ajustes = sheet.FormatDecimalValue(4, "E", "0.00")
            .DesgloseCorreccionErroresFundamentalesEneAnterior.Reservas = sheet.FormatDecimalValue(4, "F", "0.00")
            .DesgloseCorreccionErroresFundamentalesEneAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(4, "G", "0.00")
            .Total = .DesgloseCorreccionErroresFundamentalesEneAnterior.CapSocial +
                     .DesgloseCorreccionErroresFundamentalesEneAnterior.AportesNoCapitalizados +
                     .DesgloseCorreccionErroresFundamentalesEneAnterior.Ajustes +
                     .DesgloseCorreccionErroresFundamentalesEneAnterior.Reservas +
                     .DesgloseCorreccionErroresFundamentalesEneAnterior.ResultadosPrincipioPeriodo
        End With

    End Sub

    Private Sub Rows_06_to_20(sheet As IXLWorksheet)
        'Saldo corregido inicio año anterior
        'Saldo corregido inicio año anterior
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior
            .DesgloseSaldoCorregidoInicioAnnoAnterior.CapSocialIniAnterior = sheet.FormatDecimalValue(6, "C", "0.00")
            .DesgloseSaldoCorregidoInicioAnnoAnterior.AportesNoCapitalizadosIniAnterior = sheet.FormatDecimalValue(6, "D", "0.00")
            .DesgloseSaldoCorregidoInicioAnnoAnterior.AjustesIniAnterior = sheet.FormatDecimalValue(6, "E", "0.00")
            .DesgloseSaldoCorregidoInicioAnnoAnterior.ReservasIniAnterior = sheet.FormatDecimalValue(6, "F", "0.00")
            .DesgloseSaldoCorregidoInicioAnnoAnterior.ResultadosPrincipioPeriodoIniAnterior = sheet.FormatDecimalValue(6, "G", "0.00")
            .TotalSaldoCorregidoInicioAnnoAnterior = .DesgloseSaldoCorregidoInicioAnnoAnterior.CapSocialIniAnterior +
                                                     .DesgloseSaldoCorregidoInicioAnnoAnterior.AportesNoCapitalizadosIniAnterior +
                                                     .DesgloseSaldoCorregidoInicioAnnoAnterior.AjustesIniAnterior +
                                                     .DesgloseSaldoCorregidoInicioAnnoAnterior.ReservasIniAnterior +
                                                     .DesgloseSaldoCorregidoInicioAnnoAnterior.ResultadosPrincipioPeriodoIniAnterior
        End With

        'Saldo corregido inicio año anterior
        'Ajustes conversión estados financieros ini anterior
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.AjustesConversionEstadosFinancierosIniAnterior
            .DesgloseAjustesConversionEstadosFinancierosIniAnterior.CapSocial = sheet.FormatDecimalValue(7, "C", "0.00")
            .DesgloseAjustesConversionEstadosFinancierosIniAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(7, "D", "0.00")
            .DesgloseAjustesConversionEstadosFinancierosIniAnterior.Ajustes = sheet.FormatDecimalValue(7, "E", "0.00")
            .DesgloseAjustesConversionEstadosFinancierosIniAnterior.Reservas = sheet.FormatDecimalValue(7, "F", "0.00")
            .DesgloseAjustesConversionEstadosFinancierosIniAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(7, "G", "0.00")
            .Total = .DesgloseAjustesConversionEstadosFinancierosIniAnterior.CapSocial +
                     .DesgloseAjustesConversionEstadosFinancierosIniAnterior.AportesNoCapitalizados +
                     .DesgloseAjustesConversionEstadosFinancierosIniAnterior.Ajustes +
                     .DesgloseAjustesConversionEstadosFinancierosIniAnterior.Reservas +
                     .DesgloseAjustesConversionEstadosFinancierosIniAnterior.ResultadosPrincipioPeriodo
        End With

        'Saldo corregido inicio año anterior
        'Resultados periodo 1
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.ResultadosPeriodo1
            .DesgloseResultadosPeriodo1.CapSocial = sheet.FormatDecimalValue(8, "C", "0.00")
            .DesgloseResultadosPeriodo1.AportesNoCapitalizados = sheet.FormatDecimalValue(8, "D", "0.00")
            .DesgloseResultadosPeriodo1.Ajustes = sheet.FormatDecimalValue(8, "E", "0.00")
            .DesgloseResultadosPeriodo1.Reservas = sheet.FormatDecimalValue(8, "F", "0.00")
            .DesgloseResultadosPeriodo1.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(8, "G", "0.00")
            .Total = .DesgloseResultadosPeriodo1.CapSocial +
                     .DesgloseResultadosPeriodo1.AportesNoCapitalizados +
                     .DesgloseResultadosPeriodo1.Ajustes +
                     .DesgloseResultadosPeriodo1.Reservas +
                     .DesgloseResultadosPeriodo1.ResultadosPrincipioPeriodo
        End With

        'Saldo corregido inicio año anterior
        'Dividendos periodo 0
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.DividendosPeriodo0
            .DesgloseDividendosPeriodo0.CapSocial = sheet.FormatDecimalValue(9, "C", "0.00")
            .DesgloseDividendosPeriodo0.AportesNoCapitalizados = sheet.FormatDecimalValue(9, "D", "0.00")
            .DesgloseDividendosPeriodo0.Ajustes = sheet.FormatDecimalValue(9, "E", "0.00")
            .DesgloseDividendosPeriodo0.Reservas = sheet.FormatDecimalValue(9, "F", "0.00")
            .DesgloseDividendosPeriodo0.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(9, "G", "0.00")
            .Total = .DesgloseDividendosPeriodo0.CapSocial +
                     .DesgloseDividendosPeriodo0.AportesNoCapitalizados +
                     .DesgloseDividendosPeriodo0.Ajustes +
                     .DesgloseDividendosPeriodo0.Reservas +
                     .DesgloseDividendosPeriodo0.ResultadosPrincipioPeriodo
        End With

        'Saldo corregido inicio año anterior
        'Estimaciones riesgos act bancaria ini anterior
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.EstimacionesRiesgosActBancariaIniAnterior
            .DesgloseEstimacionesRiesgosActBancariaIniAnterior.CapSocial = sheet.FormatDecimalValue(10, "C", "0.00")
            .DesgloseEstimacionesRiesgosActBancariaIniAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(10, "D", "0.00")
            .DesgloseEstimacionesRiesgosActBancariaIniAnterior.Ajustes = sheet.FormatDecimalValue(10, "E", "0.00")
            .DesgloseEstimacionesRiesgosActBancariaIniAnterior.Reservas = sheet.FormatDecimalValue(10, "F", "0.00")
            .DesgloseEstimacionesRiesgosActBancariaIniAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(10, "G", "0.00")
            .Total = .DesgloseEstimacionesRiesgosActBancariaIniAnterior.CapSocial +
                     .DesgloseEstimacionesRiesgosActBancariaIniAnterior.AportesNoCapitalizados +
                     .DesgloseEstimacionesRiesgosActBancariaIniAnterior.Ajustes +
                     .DesgloseEstimacionesRiesgosActBancariaIniAnterior.Reservas +
                     .DesgloseEstimacionesRiesgosActBancariaIniAnterior.ResultadosPrincipioPeriodo
        End With

        'Saldo corregido inicio año anterior
        'Reservas legales otras estatutarias ini anterior
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.ReservasLegalesOtrasEstatutariasIniAnterior
            .DesgloseReservasLegalesOtrasEstatutariasIniAnterior.CapSocial = sheet.FormatDecimalValue(11, "C", "0.00")
            .DesgloseReservasLegalesOtrasEstatutariasIniAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(11, "D", "0.00")
            .DesgloseReservasLegalesOtrasEstatutariasIniAnterior.Ajustes = sheet.FormatDecimalValue(11, "E", "0.00")
            .DesgloseReservasLegalesOtrasEstatutariasIniAnterior.Reservas = sheet.FormatDecimalValue(11, "F", "0.00")
            .DesgloseReservasLegalesOtrasEstatutariasIniAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(11, "G", "0.00")
            .Total = .DesgloseReservasLegalesOtrasEstatutariasIniAnterior.CapSocial +
                     .DesgloseReservasLegalesOtrasEstatutariasIniAnterior.AportesNoCapitalizados +
                     .DesgloseReservasLegalesOtrasEstatutariasIniAnterior.Ajustes +
                     .DesgloseReservasLegalesOtrasEstatutariasIniAnterior.Reservas +
                     .DesgloseReservasLegalesOtrasEstatutariasIniAnterior.ResultadosPrincipioPeriodo
        End With

        'Saldo corregido inicio año anterior
        'Compra venta acciones tesorería ini anterior
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.CompraVentaAccionesTesoreriaIniAnterior
            .DesgloseCompraVentaAccionesTesoreriaIniAnterior.CapSocial = sheet.FormatDecimalValue(12, "C", "0.00")
            .DesgloseCompraVentaAccionesTesoreriaIniAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(12, "D", "0.00")
            .DesgloseCompraVentaAccionesTesoreriaIniAnterior.Ajustes = sheet.FormatDecimalValue(12, "E", "0.00")
            .DesgloseCompraVentaAccionesTesoreriaIniAnterior.Reservas = sheet.FormatDecimalValue(12, "F", "0.00")
            .DesgloseCompraVentaAccionesTesoreriaIniAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(12, "G", "0.00")
            .Total = .DesgloseCompraVentaAccionesTesoreriaIniAnterior.CapSocial +
                     .DesgloseCompraVentaAccionesTesoreriaIniAnterior.AportesNoCapitalizados +
                     .DesgloseCompraVentaAccionesTesoreriaIniAnterior.Ajustes +
                     .DesgloseCompraVentaAccionesTesoreriaIniAnterior.Reservas +
                     .DesgloseCompraVentaAccionesTesoreriaIniAnterior.ResultadosPrincipioPeriodo
        End With

        'Saldo corregido inicio año anterior
        'Emisión acciones ini anterior
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.EmisionAccionesIniAnterior
            .DesgloseEmisionAccionesIniAnterior.CapSocial = sheet.FormatDecimalValue(13, "C", "0.00")
            .DesgloseEmisionAccionesIniAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(13, "D", "0.00")
            .DesgloseEmisionAccionesIniAnterior.Ajustes = sheet.FormatDecimalValue(13, "E", "0.00")
            .DesgloseEmisionAccionesIniAnterior.Reservas = sheet.FormatDecimalValue(13, "F", "0.00")
            .DesgloseEmisionAccionesIniAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(13, "G", "0.00")
            .Total = .DesgloseEmisionAccionesIniAnterior.CapSocial +
                     .DesgloseEmisionAccionesIniAnterior.AportesNoCapitalizados +
                     .DesgloseEmisionAccionesIniAnterior.Ajustes +
                     .DesgloseEmisionAccionesIniAnterior.Reservas +
                     .DesgloseEmisionAccionesIniAnterior.ResultadosPrincipioPeriodo
        End With


        'Saldo corregido inicio año anterior
        'Capital pagado adicional ini anterior
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.CapitalPagadoAdicionalIniAnterior
            .DesgloseCapitalPagadoAdicionalIniAnterior.CapSocial = sheet.FormatDecimalValue(14, "C", "0.00")
            .DesgloseCapitalPagadoAdicionalIniAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(14, "D", "0.00")
            .DesgloseCapitalPagadoAdicionalIniAnterior.Ajustes = sheet.FormatDecimalValue(14, "E", "0.00")
            .DesgloseCapitalPagadoAdicionalIniAnterior.Reservas = sheet.FormatDecimalValue(14, "F", "0.00")
            .DesgloseCapitalPagadoAdicionalIniAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(14, "G", "0.00")
            .Total = .DesgloseCapitalPagadoAdicionalIniAnterior.CapSocial +
                     .DesgloseCapitalPagadoAdicionalIniAnterior.AportesNoCapitalizados +
                     .DesgloseCapitalPagadoAdicionalIniAnterior.Ajustes +
                     .DesgloseCapitalPagadoAdicionalIniAnterior.Reservas +
                     .DesgloseCapitalPagadoAdicionalIniAnterior.ResultadosPrincipioPeriodo
        End With

        'CUSTOM2020A
        'Saldo corregido inicio año anterior
        'Superávit reva inmueble mobiliario equipo ini anterior
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.SuperavitRevaPropiedadMobiliarioEquipoIniAnterior
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior.CapSocial = sheet.FormatDecimalValue(15, "C", "0.00")
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(15, "D", "0.00")
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior.Ajustes = sheet.FormatDecimalValue(15, "E", "0.00")
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior.Reservas = sheet.FormatDecimalValue(15, "F", "0.00")
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(15, "G", "0.00")
            .Total = .DesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior.CapSocial +
                     .DesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior.AportesNoCapitalizados +
                     .DesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior.Ajustes +
                     .DesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior.Reservas +
                     .DesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior.ResultadosPrincipioPeriodo
        End With

        'CUSTOM2020A
        'Saldo corregido inicio año anterior
        'Ajustes valuación inversiones dispo venta ini anterior
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.AjustesValuacionInversionesValRazCambiosResulIntegIniAnterior
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior.CapSocial = sheet.FormatDecimalValue(16, "C", "0.00")
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(16, "D", "0.00")
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior.Ajustes = sheet.FormatDecimalValue(16, "E", "0.00")
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior.Reservas = sheet.FormatDecimalValue(16, "F", "0.00")
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(16, "G", "0.00")
            .Total = .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior.CapSocial +
                     .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior.AportesNoCapitalizados +
                     .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior.Ajustes +
                     .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior.Reservas +
                     .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior.ResultadosPrincipioPeriodo
        End With

        'Saldo corregido inicio año anterior
        'Ajustes valuación instrumentos restringidos ini anterior
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.AjustesValuacionInstrumentosRestringidosIniAnterior
            .DesgloseAjustesValuacionInstrumentosRestringidosIniAnterior.CapSocial = sheet.FormatDecimalValue(17, "C", "0.00")
            .DesgloseAjustesValuacionInstrumentosRestringidosIniAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(17, "D", "0.00")
            .DesgloseAjustesValuacionInstrumentosRestringidosIniAnterior.Ajustes = sheet.FormatDecimalValue(17, "E", "0.00")
            .DesgloseAjustesValuacionInstrumentosRestringidosIniAnterior.Reservas = sheet.FormatDecimalValue(17, "F", "0.00")
            .DesgloseAjustesValuacionInstrumentosRestringidosIniAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(17, "G", "0.00")
            .Total = .DesgloseAjustesValuacionInstrumentosRestringidosIniAnterior.CapSocial +
                     .DesgloseAjustesValuacionInstrumentosRestringidosIniAnterior.AportesNoCapitalizados +
                     .DesgloseAjustesValuacionInstrumentosRestringidosIniAnterior.Ajustes +
                     .DesgloseAjustesValuacionInstrumentosRestringidosIniAnterior.Reservas +
                     .DesgloseAjustesValuacionInstrumentosRestringidosIniAnterior.ResultadosPrincipioPeriodo
        End With

        'Saldo corregido inicio año anterior
        'Ajustes valuación instrumentos cesación pago ini anterior
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.AjustesValuacionInstrumentosCesacionPagoIniAnterior
            .DesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior.CapSocial = sheet.FormatDecimalValue(18, "C", "0.00")
            .DesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(18, "D", "0.00")
            .DesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior.Ajustes = sheet.FormatDecimalValue(18, "E", "0.00")
            .DesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior.Reservas = sheet.FormatDecimalValue(18, "F", "0.00")
            .DesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(18, "G", "0.00")
            .Total = .DesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior.CapSocial +
                     .DesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior.AportesNoCapitalizados +
                     .DesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior.Ajustes +
                     .DesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior.Reservas +
                     .DesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior.ResultadosPrincipioPeriodo
        End With

        'Saldo corregido inicio año anterior
        'Superávit reva otros activos
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.SuperavitRevaOtrosActivos
            .DesgloseSuperavitRevaOtrosActivos.CapSocial = sheet.FormatDecimalValue(19, "C", "0.00")
            .DesgloseSuperavitRevaOtrosActivos.AportesNoCapitalizados = sheet.FormatDecimalValue(19, "D", "0.00")
            .DesgloseSuperavitRevaOtrosActivos.Ajustes = sheet.FormatDecimalValue(19, "E", "0.00")
            .DesgloseSuperavitRevaOtrosActivos.Reservas = sheet.FormatDecimalValue(19, "F", "0.00")
            .DesgloseSuperavitRevaOtrosActivos.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(19, "G", "0.00")
            .Total = .DesgloseSuperavitRevaOtrosActivos.CapSocial +
                     .DesgloseSuperavitRevaOtrosActivos.AportesNoCapitalizados +
                     .DesgloseSuperavitRevaOtrosActivos.Ajustes +
                     .DesgloseSuperavitRevaOtrosActivos.Reservas +
                     .DesgloseSuperavitRevaOtrosActivos.ResultadosPrincipioPeriodo
        End With

        'Saldo corregido inicio año anterior
        'Otros corregidos ini anterior
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoAnterior.OtrosCorregidosIniAnterior
            .DesgloseOtrosIniAnterior.CapSocial = sheet.FormatDecimalValue(20, "C", "0.00")
            .DesgloseOtrosIniAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(20, "D", "0.00")
            .DesgloseOtrosIniAnterior.Ajustes = sheet.FormatDecimalValue(20, "E", "0.00")
            .DesgloseOtrosIniAnterior.Reservas = sheet.FormatDecimalValue(20, "F", "0.00")
            .DesgloseOtrosIniAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(20, "G", "0.00")
            .Total = .DesgloseOtrosIniAnterior.CapSocial +
                     .DesgloseOtrosIniAnterior.AportesNoCapitalizados +
                     .DesgloseOtrosIniAnterior.Ajustes +
                     .DesgloseOtrosIniAnterior.Reservas +
                     .DesgloseOtrosIniAnterior.ResultadosPrincipioPeriodo
        End With

    End Sub

    Private Sub Rows_22_to_24(sheet As IXLWorksheet)
        'Saldo 31 dic año anterior
        'Saldo 31 dic año anterior
        With _Patrimonio.Datos.Modelo.Saldo31DicAnnoAnterior
            .DesgloseSaldo31DicAnnoAnterior.CapSocialFinAnterior = sheet.FormatDecimalValue(22, "C", "0.00")
            .DesgloseSaldo31DicAnnoAnterior.AportesNoCapitalizadosFinAnterior = sheet.FormatDecimalValue(22, "D", "0.00")
            .DesgloseSaldo31DicAnnoAnterior.AjustesFinAnterior = sheet.FormatDecimalValue(22, "E", "0.00")
            .DesgloseSaldo31DicAnnoAnterior.ReservasFinAnterior = sheet.FormatDecimalValue(22, "F", "0.00")
            .DesgloseSaldo31DicAnnoAnterior.ResultadosPrincipioPeriodoFinAnterior = sheet.FormatDecimalValue(22, "G", "0.00")
            .TotalSaldo31DicAnnoAnterior = .DesgloseSaldo31DicAnnoAnterior.CapSocialFinAnterior +
                                           .DesgloseSaldo31DicAnnoAnterior.AportesNoCapitalizadosFinAnterior +
                                           .DesgloseSaldo31DicAnnoAnterior.AjustesFinAnterior +
                                           .DesgloseSaldo31DicAnnoAnterior.ReservasFinAnterior +
                                           .DesgloseSaldo31DicAnnoAnterior.ResultadosPrincipioPeriodoFinAnterior
        End With

        'CUSTOM2020A
        'Saldo 31 dic año anterior
        'Atribuido intereses minoritarios fin anterior
        With _Patrimonio.Datos.Modelo.Saldo31DicAnnoAnterior.AtribuidoParticipNoControlFinAnterior
            .DesgloseAtribuidoParticipNoControlFinAnterior.CapSocial = sheet.FormatDecimalValue(23, "C", "0.00")
            .DesgloseAtribuidoParticipNoControlFinAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(23, "D", "0.00")
            .DesgloseAtribuidoParticipNoControlFinAnterior.Ajustes = sheet.FormatDecimalValue(23, "E", "0.00")
            .DesgloseAtribuidoParticipNoControlFinAnterior.Reservas = sheet.FormatDecimalValue(23, "F", "0.00")
            .DesgloseAtribuidoParticipNoControlFinAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(23, "G", "0.00")
            .Total = .DesgloseAtribuidoParticipNoControlFinAnterior.CapSocial +
                     .DesgloseAtribuidoParticipNoControlFinAnterior.AportesNoCapitalizados +
                     .DesgloseAtribuidoParticipNoControlFinAnterior.Ajustes +
                     .DesgloseAtribuidoParticipNoControlFinAnterior.Reservas +
                     .DesgloseAtribuidoParticipNoControlFinAnterior.ResultadosPrincipioPeriodo
        End With

        'Saldo 31 dic año anterior
        'Atribuido controladora fin anterior
        With _Patrimonio.Datos.Modelo.Saldo31DicAnnoAnterior.AtribuidoControladoraFinAnterior
            .DesgloseAtribuidoControladoraFinAnterior.CapSocial = sheet.FormatDecimalValue(24, "C", "0.00")
            .DesgloseAtribuidoControladoraFinAnterior.AportesNoCapitalizados = sheet.FormatDecimalValue(24, "D", "0.00")
            .DesgloseAtribuidoControladoraFinAnterior.Ajustes = sheet.FormatDecimalValue(24, "E", "0.00")
            .DesgloseAtribuidoControladoraFinAnterior.Reservas = sheet.FormatDecimalValue(24, "F", "0.00")
            .DesgloseAtribuidoControladoraFinAnterior.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(24, "G", "0.00")
            .Total = .DesgloseAtribuidoControladoraFinAnterior.CapSocial +
                     .DesgloseAtribuidoControladoraFinAnterior.AportesNoCapitalizados +
                     .DesgloseAtribuidoControladoraFinAnterior.Ajustes +
                     .DesgloseAtribuidoControladoraFinAnterior.Reservas +
                     .DesgloseAtribuidoControladoraFinAnterior.ResultadosPrincipioPeriodo
        End With

    End Sub
    Private Sub Rows_26_to_28(sheet As IXLWorksheet)
        'Saldo 1 ene año actual
        'Saldo 1 ene año actual
        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoActual
            .DesgloseSaldo1EneAnnoActual.CapSocialEneActual = sheet.FormatDecimalValue(26, "C", "0.00")
            .DesgloseSaldo1EneAnnoActual.AportesNoCapitalizadosEneActual = sheet.FormatDecimalValue(26, "D", "0.00")
            .DesgloseSaldo1EneAnnoActual.AjustesEneActual = sheet.FormatDecimalValue(26, "E", "0.00")
            .DesgloseSaldo1EneAnnoActual.ReservasEneActual = sheet.FormatDecimalValue(26, "F", "0.00")
            .DesgloseSaldo1EneAnnoActual.ResultadosPrincipioPeriodoEneActual = sheet.FormatDecimalValue(26, "G", "0.00")
            .TotalSaldo1EneAnnoActual = .DesgloseSaldo1EneAnnoActual.CapSocialEneActual +
                                        .DesgloseSaldo1EneAnnoActual.AportesNoCapitalizadosEneActual +
                                        .DesgloseSaldo1EneAnnoActual.AjustesEneActual +
                                        .DesgloseSaldo1EneAnnoActual.ReservasEneActual +
                                        .DesgloseSaldo1EneAnnoActual.ResultadosPrincipioPeriodoEneActual
        End With

        'Saldo 1 ene año actual
        'Cambios políticas contables ene actual
        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoActual.CambiosPoliticasContablesEneActual
            .DesgloseCambiosPoliticasContablesEneActual.CapSocial = sheet.FormatDecimalValue(27, "C", "0.00")
            .DesgloseCambiosPoliticasContablesEneActual.AportesNoCapitalizados = sheet.FormatDecimalValue(27, "D", "0.00")
            .DesgloseCambiosPoliticasContablesEneActual.Ajustes = sheet.FormatDecimalValue(27, "E", "0.00")
            .DesgloseCambiosPoliticasContablesEneActual.Reservas = sheet.FormatDecimalValue(27, "F", "0.00")
            .DesgloseCambiosPoliticasContablesEneActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(27, "G", "0.00")
            .Total = .DesgloseCambiosPoliticasContablesEneActual.CapSocial +
                        .DesgloseCambiosPoliticasContablesEneActual.AportesNoCapitalizados +
                        .DesgloseCambiosPoliticasContablesEneActual.Ajustes +
                        .DesgloseCambiosPoliticasContablesEneActual.Reservas +
                        .DesgloseCambiosPoliticasContablesEneActual.ResultadosPrincipioPeriodo
        End With

        'Saldo 1 ene año actual
        'Corrección errores fundamentales rne actual
        With _Patrimonio.Datos.Modelo.Saldo1EneAnnoActual.CorreccionErroresFundamentalesEneActual
            .DesgloseCorreccionErroresFundamentalesEneActual.CapSocial = sheet.FormatDecimalValue(28, "C", "0.00")
            .DesgloseCorreccionErroresFundamentalesEneActual.AportesNoCapitalizados = sheet.FormatDecimalValue(28, "D", "0.00")
            .DesgloseCorreccionErroresFundamentalesEneActual.Ajustes = sheet.FormatDecimalValue(28, "E", "0.00")
            .DesgloseCorreccionErroresFundamentalesEneActual.Reservas = sheet.FormatDecimalValue(28, "F", "0.00")
            .DesgloseCorreccionErroresFundamentalesEneActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(28, "G", "0.00")
            .Total = .DesgloseCorreccionErroresFundamentalesEneActual.CapSocial +
                        .DesgloseCorreccionErroresFundamentalesEneActual.AportesNoCapitalizados +
                        .DesgloseCorreccionErroresFundamentalesEneActual.Ajustes +
                        .DesgloseCorreccionErroresFundamentalesEneActual.Reservas +
                        .DesgloseCorreccionErroresFundamentalesEneActual.ResultadosPrincipioPeriodo
        End With

    End Sub
    Private Sub Rows_30_to_30(sheet As IXLWorksheet)
        'Saldo corregido inicio año actual
        'Saldo corregido inicio año actual
        With _Patrimonio.Datos.Modelo.SaldoCorregidoInicioAnnoActual
            .DesgloseSaldoCorregidoInicioAnnoActual.CapSocial = sheet.FormatDecimalValue(30, "C", "0.00")
            .DesgloseSaldoCorregidoInicioAnnoActual.AportesNoCapitalizados = sheet.FormatDecimalValue(30, "D", "0.00")
            .DesgloseSaldoCorregidoInicioAnnoActual.Ajustes = sheet.FormatDecimalValue(30, "E", "0.00")
            .DesgloseSaldoCorregidoInicioAnnoActual.Reservas = sheet.FormatDecimalValue(30, "F", "0.00")
            .DesgloseSaldoCorregidoInicioAnnoActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(30, "G", "0.00")
            .Total = .DesgloseSaldoCorregidoInicioAnnoActual.CapSocial +
                        .DesgloseSaldoCorregidoInicioAnnoActual.AportesNoCapitalizados +
                        .DesgloseSaldoCorregidoInicioAnnoActual.Ajustes +
                        .DesgloseSaldoCorregidoInicioAnnoActual.Reservas +
                        .DesgloseSaldoCorregidoInicioAnnoActual.ResultadosPrincipioPeriodo
        End With

    End Sub
    Private Sub Rows_32_to_37(sheet As IXLWorksheet)
        'Originados año actual
        'Originados año actual
        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual
            .DesgloseOriginadosAnnoActual.CapSocialOrigActual = sheet.FormatDecimalValue(32, "C", "0.00")
            .DesgloseOriginadosAnnoActual.AportesNoCapitalizadosOrigActual = sheet.FormatDecimalValue(32, "D", "0.00")
            .DesgloseOriginadosAnnoActual.AjustesOrigActual = sheet.FormatDecimalValue(32, "E", "0.00")
            .DesgloseOriginadosAnnoActual.ReservasOrigActual = sheet.FormatDecimalValue(32, "F", "0.00")
            .DesgloseOriginadosAnnoActual.ResultadosPrincipioPeriodoOrigActual = sheet.FormatDecimalValue(32, "G", "0.00")
            .TotalOriginadosAnnoActual = .DesgloseOriginadosAnnoActual.CapSocialOrigActual +
                                            .DesgloseOriginadosAnnoActual.AportesNoCapitalizadosOrigActual +
                                            .DesgloseOriginadosAnnoActual.AjustesOrigActual +
                                            .DesgloseOriginadosAnnoActual.ReservasOrigActual +
                                            .DesgloseOriginadosAnnoActual.ResultadosPrincipioPeriodoOrigActual
        End With

        'Originados año actual
        'Ajustes conversión estados financieros orig actual
        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.AjustesConversionEstadosFinancierosOrigActual
            .DesgloseAjustesConversionEstadosFinancierosOrigActual.CapSocial = sheet.FormatDecimalValue(33, "C", "0.00")
            .DesgloseAjustesConversionEstadosFinancierosOrigActual.AportesNoCapitalizados = sheet.FormatDecimalValue(33, "D", "0.00")
            .DesgloseAjustesConversionEstadosFinancierosOrigActual.Ajustes = sheet.FormatDecimalValue(33, "E", "0.00")
            .DesgloseAjustesConversionEstadosFinancierosOrigActual.Reservas = sheet.FormatDecimalValue(33, "F", "0.00")
            .DesgloseAjustesConversionEstadosFinancierosOrigActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(33, "G", "0.00")
            .Total = .DesgloseAjustesConversionEstadosFinancierosOrigActual.CapSocial +
                        .DesgloseAjustesConversionEstadosFinancierosOrigActual.AportesNoCapitalizados +
                        .DesgloseAjustesConversionEstadosFinancierosOrigActual.Ajustes +
                        .DesgloseAjustesConversionEstadosFinancierosOrigActual.Reservas +
                        .DesgloseAjustesConversionEstadosFinancierosOrigActual.ResultadosPrincipioPeriodo
        End With

        'CUSTOM20202A
        'Originados año actual
        'Ajustes valuación inversiones dispo venta orig actual
        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.AjustesValuacionInversionesValRazCambiosResulIntegOrigActual
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual.CapSocial = sheet.FormatDecimalValue(34, "C", "0.00")
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual.AportesNoCapitalizados = sheet.FormatDecimalValue(34, "D", "0.00")
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual.Ajustes = sheet.FormatDecimalValue(34, "E", "0.00")
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual.Reservas = sheet.FormatDecimalValue(34, "F", "0.00")
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(34, "G", "0.00")
            .Total = .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual.CapSocial +
                        .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual.AportesNoCapitalizados +
                        .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual.Ajustes +
                        .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual.Reservas +
                        .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual.ResultadosPrincipioPeriodo
        End With

        'Originados año actual
        'Ajustes valuación instrumentos restringidos orig actual
        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.AjustesValuacionInstrumentosRestringidosOrigActual
            .DesgloseAjustesValuacionInstrumentosRestringidosOrigActual.CapSocial = sheet.FormatDecimalValue(35, "C", "0.00")
            .DesgloseAjustesValuacionInstrumentosRestringidosOrigActual.AportesNoCapitalizados = sheet.FormatDecimalValue(35, "D", "0.00")
            .DesgloseAjustesValuacionInstrumentosRestringidosOrigActual.Ajustes = sheet.FormatDecimalValue(35, "E", "0.00")
            .DesgloseAjustesValuacionInstrumentosRestringidosOrigActual.Reservas = sheet.FormatDecimalValue(35, "F", "0.00")
            .DesgloseAjustesValuacionInstrumentosRestringidosOrigActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(35, "G", "0.00")
            .Total = .DesgloseAjustesValuacionInstrumentosRestringidosOrigActual.CapSocial +
                        .DesgloseAjustesValuacionInstrumentosRestringidosOrigActual.AportesNoCapitalizados +
                        .DesgloseAjustesValuacionInstrumentosRestringidosOrigActual.Ajustes +
                        .DesgloseAjustesValuacionInstrumentosRestringidosOrigActual.Reservas +
                        .DesgloseAjustesValuacionInstrumentosRestringidosOrigActual.ResultadosPrincipioPeriodo
        End With

        'Originados año actual
        'Ajustes valuación instrumentos cesación pago orig actual
        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.AjustesValuacionInstrumentosCesacionPagoOrigActual
            .DesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual.CapSocial = sheet.FormatDecimalValue(36, "C", "0.00")
            .DesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual.AportesNoCapitalizados = sheet.FormatDecimalValue(36, "D", "0.00")
            .DesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual.Ajustes = sheet.FormatDecimalValue(36, "E", "0.00")
            .DesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual.Reservas = sheet.FormatDecimalValue(36, "F", "0.00")
            .DesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(36, "G", "0.00")
            .Total = .DesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual.CapSocial +
                        .DesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual.AportesNoCapitalizados +
                        .DesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual.Ajustes +
                        .DesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual.Reservas +
                        .DesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual.ResultadosPrincipioPeriodo
        End With

        'Originados año actual
        'Otros originados año actual
        With _Patrimonio.Datos.Modelo.OriginadosAnnoActual.OtrosOriginadosAnnoActual
            .DesgloseOtrosOrigActual.CapSocial = sheet.FormatDecimalValue(37, "C", "0.00")
            .DesgloseOtrosOrigActual.AportesNoCapitalizados = sheet.FormatDecimalValue(37, "D", "0.00")
            .DesgloseOtrosOrigActual.Ajustes = sheet.FormatDecimalValue(37, "E", "0.00")
            .DesgloseOtrosOrigActual.Reservas = sheet.FormatDecimalValue(37, "F", "0.00")
            .DesgloseOtrosOrigActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(37, "G", "0.00")
            .Total = .DesgloseOtrosOrigActual.CapSocial +
                        .DesgloseOtrosOrigActual.AportesNoCapitalizados +
                        .DesgloseOtrosOrigActual.Ajustes +
                        .DesgloseOtrosOrigActual.Reservas +
                        .DesgloseOtrosOrigActual.ResultadosPrincipioPeriodo
        End With

    End Sub
    Private Sub Rows_39_to_54(sheet As IXLWorksheet)
        'Transferencias resultados año actual
        'Transferencias resultados año actual
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual
            .DesgloseTranferenciasResultadosAnnoActual.CapSocialTransfActual = sheet.FormatDecimalValue(39, "C", "0.00")
            .DesgloseTranferenciasResultadosAnnoActual.AportesNoCapitalizadosTransfActual = sheet.FormatDecimalValue(39, "D", "0.00")
            .DesgloseTranferenciasResultadosAnnoActual.AjustesTransfActual = sheet.FormatDecimalValue(39, "E", "0.00")
            .DesgloseTranferenciasResultadosAnnoActual.ReservasTransfActual = sheet.FormatDecimalValue(39, "F", "0.00")
            .DesgloseTranferenciasResultadosAnnoActual.ResultadosPrincipioPeriodoTransfActual = sheet.FormatDecimalValue(39, "G", "0.00")

            .TotalTranferenciasResultadosAnnoActual = .DesgloseTranferenciasResultadosAnnoActual.CapSocialTransfActual +
                                                        .DesgloseTranferenciasResultadosAnnoActual.AportesNoCapitalizadosTransfActual +
                                                        .DesgloseTranferenciasResultadosAnnoActual.AjustesTransfActual +
                                                        .DesgloseTranferenciasResultadosAnnoActual.ReservasTransfActual +
                                                        .DesgloseTranferenciasResultadosAnnoActual.ResultadosPrincipioPeriodoTransfActual
        End With

        'CUSTOM2020A
        'Transferencias resultados año actual
        'Ajustes valuación inversiones dispo venta transf actual
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.AjustesValuacionInversionesValRazCambiosResulIntegTransfActual
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual.CapSocial = sheet.FormatDecimalValue(40, "C", "0.00")
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual.AportesNoCapitalizados = sheet.FormatDecimalValue(40, "D", "0.00")
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual.Ajustes = sheet.FormatDecimalValue(40, "E", "0.00")
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual.Reservas = sheet.FormatDecimalValue(40, "F", "0.00")
            .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(40, "G", "0.00")
            .Total = .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual.CapSocial +
                        .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual.AportesNoCapitalizados +
                        .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual.Ajustes +
                        .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual.Reservas +
                        .DesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual.ResultadosPrincipioPeriodo
        End With

        'Transferencias resultados año actual
        'Ajustes valuación instrumentos restringidos transf actual
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.AjustesValuacionInstrumentosRestringidosTransfActual
            .DesgloseAjustesValuacionInstrumentosRestringidosTransfActual.CapSocial = sheet.FormatDecimalValue(41, "C", "0.00")
            .DesgloseAjustesValuacionInstrumentosRestringidosTransfActual.AportesNoCapitalizados = sheet.FormatDecimalValue(41, "D", "0.00")
            .DesgloseAjustesValuacionInstrumentosRestringidosTransfActual.Ajustes = sheet.FormatDecimalValue(41, "E", "0.00")
            .DesgloseAjustesValuacionInstrumentosRestringidosTransfActual.Reservas = sheet.FormatDecimalValue(41, "F", "0.00")
            .DesgloseAjustesValuacionInstrumentosRestringidosTransfActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(41, "G", "0.00")
            .Total = .DesgloseAjustesValuacionInstrumentosRestringidosTransfActual.CapSocial +
                        .DesgloseAjustesValuacionInstrumentosRestringidosTransfActual.AportesNoCapitalizados +
                        .DesgloseAjustesValuacionInstrumentosRestringidosTransfActual.Ajustes +
                        .DesgloseAjustesValuacionInstrumentosRestringidosTransfActual.Reservas +
                        .DesgloseAjustesValuacionInstrumentosRestringidosTransfActual.ResultadosPrincipioPeriodo
        End With

        'Transferencias resultados año actual
        'Ajustes valuación instrumentos cesación pago transf actual
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.AjustesValuacionInstrumentosCesacionPagoTransfActual
            .DesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual.CapSocial = sheet.FormatDecimalValue(42, "C", "0.00")
            .DesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual.AportesNoCapitalizados = sheet.FormatDecimalValue(42, "D", "0.00")
            .DesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual.Ajustes = sheet.FormatDecimalValue(42, "E", "0.00")
            .DesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual.Reservas = sheet.FormatDecimalValue(42, "F", "0.00")
            .DesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(42, "G", "0.00")
            .Total = .DesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual.CapSocial +
                        .DesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual.AportesNoCapitalizados +
                        .DesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual.Ajustes +
                        .DesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual.Reservas +
                        .DesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual.ResultadosPrincipioPeriodo
        End With

        'Transferencias resultados año actual
        'Otros transf actual
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.OtrosTransfActual
            .DesgloseOtrosTransfActual.CapSocial = sheet.FormatDecimalValue(43, "C", "0.00")
            .DesgloseOtrosTransfActual.AportesNoCapitalizados = sheet.FormatDecimalValue(43, "D", "0.00")
            .DesgloseOtrosTransfActual.Ajustes = sheet.FormatDecimalValue(43, "E", "0.00")
            .DesgloseOtrosTransfActual.Reservas = sheet.FormatDecimalValue(43, "F", "0.00")
            .DesgloseOtrosTransfActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(43, "G", "0.00")
            .Total = .DesgloseOtrosTransfActual.CapSocial +
                        .DesgloseOtrosTransfActual.AportesNoCapitalizados +
                        .DesgloseOtrosTransfActual.Ajustes +
                        .DesgloseOtrosTransfActual.Reservas +
                        .DesgloseOtrosTransfActual.ResultadosPrincipioPeriodo
        End With

        'Transferencias resultados año actual
        'Ganancia perdida no reconocida periodo 2
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.GananciaPerdidaNoReconocidaPeriodo2
            .DesgloseGananciaPerdidaNoReconocidaPeriodo2.CapSocial = sheet.FormatDecimalValue(44, "C", "0.00")
            .DesgloseGananciaPerdidaNoReconocidaPeriodo2.AportesNoCapitalizados = sheet.FormatDecimalValue(44, "D", "0.00")
            .DesgloseGananciaPerdidaNoReconocidaPeriodo2.Ajustes = sheet.FormatDecimalValue(44, "E", "0.00")
            .DesgloseGananciaPerdidaNoReconocidaPeriodo2.Reservas = sheet.FormatDecimalValue(44, "F", "0.00")
            .DesgloseGananciaPerdidaNoReconocidaPeriodo2.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(44, "G", "0.00")
            .Total = .DesgloseGananciaPerdidaNoReconocidaPeriodo2.CapSocial +
                        .DesgloseGananciaPerdidaNoReconocidaPeriodo2.AportesNoCapitalizados +
                        .DesgloseGananciaPerdidaNoReconocidaPeriodo2.Ajustes +
                        .DesgloseGananciaPerdidaNoReconocidaPeriodo2.Reservas +
                        .DesgloseGananciaPerdidaNoReconocidaPeriodo2.ResultadosPrincipioPeriodo
        End With

        'Transferencias resultados año actual
        'Resultado periodo 2
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.ResultadoPeriodo2
            .DesgloseResultadoPeriodo2.CapSocial = sheet.FormatDecimalValue(45, "C", "0.00")
            .DesgloseResultadoPeriodo2.AportesNoCapitalizados = sheet.FormatDecimalValue(45, "D", "0.00")
            .DesgloseResultadoPeriodo2.Ajustes = sheet.FormatDecimalValue(45, "E", "0.00")
            .DesgloseResultadoPeriodo2.Reservas = sheet.FormatDecimalValue(45, "F", "0.00")
            .DesgloseResultadoPeriodo2.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(45, "G", "0.00")
            .Total = .DesgloseResultadoPeriodo2.CapSocial +
                        .DesgloseResultadoPeriodo2.AportesNoCapitalizados +
                        .DesgloseResultadoPeriodo2.Ajustes +
                        .DesgloseResultadoPeriodo2.Reservas +
                        .DesgloseResultadoPeriodo2.ResultadosPrincipioPeriodo
        End With

        'Transferencias resultados año actual
        'Reservas legales otras estatutarias transf actual
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.ReservasLegalesOtrasEstatutariasTransfActual
            .DesgloseReservasLegalesOtrasEstatutariasTransfActual.CapSocial = sheet.FormatDecimalValue(46, "C", "0.00")
            .DesgloseReservasLegalesOtrasEstatutariasTransfActual.AportesNoCapitalizados = sheet.FormatDecimalValue(46, "D", "0.00")
            .DesgloseReservasLegalesOtrasEstatutariasTransfActual.Ajustes = sheet.FormatDecimalValue(46, "E", "0.00")
            .DesgloseReservasLegalesOtrasEstatutariasTransfActual.Reservas = sheet.FormatDecimalValue(46, "F", "0.00")
            .DesgloseReservasLegalesOtrasEstatutariasTransfActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(46, "G", "0.00")
            .Total = .DesgloseReservasLegalesOtrasEstatutariasTransfActual.CapSocial +
                        .DesgloseReservasLegalesOtrasEstatutariasTransfActual.AportesNoCapitalizados +
                        .DesgloseReservasLegalesOtrasEstatutariasTransfActual.Ajustes +
                        .DesgloseReservasLegalesOtrasEstatutariasTransfActual.Reservas +
                        .DesgloseReservasLegalesOtrasEstatutariasTransfActual.ResultadosPrincipioPeriodo
        End With

        'Transferencias resultados año actual
        'Dividendos periodo 1
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.DividendosPeriodo1
            .DesgloseDividendosPeriodo1.CapSocial = sheet.FormatDecimalValue(47, "C", "0.00")
            .DesgloseDividendosPeriodo1.AportesNoCapitalizados = sheet.FormatDecimalValue(47, "D", "0.00")
            .DesgloseDividendosPeriodo1.Ajustes = sheet.FormatDecimalValue(47, "E", "0.00")
            .DesgloseDividendosPeriodo1.Reservas = sheet.FormatDecimalValue(47, "F", "0.00")
            .DesgloseDividendosPeriodo1.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(47, "G", "0.00")
            .Total = .DesgloseDividendosPeriodo1.CapSocial +
                        .DesgloseDividendosPeriodo1.AportesNoCapitalizados +
                        .DesgloseDividendosPeriodo1.Ajustes +
                        .DesgloseDividendosPeriodo1.Reservas +
                        .DesgloseDividendosPeriodo1.ResultadosPrincipioPeriodo
        End With

        'Transferencias resultados año actual
        'Estimaciones riesgos act bancaria transf actual
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.EstimacionesRiesgosActBancariaTransfActual
            .DesgloseEstimacionesRiesgosActBancariaTransfActual.CapSocial = sheet.FormatDecimalValue(48, "C", "0.00")
            .DesgloseEstimacionesRiesgosActBancariaTransfActual.AportesNoCapitalizados = sheet.FormatDecimalValue(48, "D", "0.00")
            .DesgloseEstimacionesRiesgosActBancariaTransfActual.Ajustes = sheet.FormatDecimalValue(48, "E", "0.00")
            .DesgloseEstimacionesRiesgosActBancariaTransfActual.Reservas = sheet.FormatDecimalValue(48, "F", "0.00")
            .DesgloseEstimacionesRiesgosActBancariaTransfActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(48, "G", "0.00")
            .Total = .DesgloseEstimacionesRiesgosActBancariaTransfActual.CapSocial +
                        .DesgloseEstimacionesRiesgosActBancariaTransfActual.AportesNoCapitalizados +
                        .DesgloseEstimacionesRiesgosActBancariaTransfActual.Ajustes +
                        .DesgloseEstimacionesRiesgosActBancariaTransfActual.Reservas +
                        .DesgloseEstimacionesRiesgosActBancariaTransfActual.ResultadosPrincipioPeriodo
        End With

        'Transferencias resultados año actual
        'Compra venta acciones tesorería transf actual
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.CompraVentaAccionesTesoreriaTransfActual
            .DesgloseCompraVentaAccionesTesoreriaTransfActual.CapSocial = sheet.FormatDecimalValue(49, "C", "0.00")
            .DesgloseCompraVentaAccionesTesoreriaTransfActual.AportesNoCapitalizados = sheet.FormatDecimalValue(49, "D", "0.00")
            .DesgloseCompraVentaAccionesTesoreriaTransfActual.Ajustes = sheet.FormatDecimalValue(49, "E", "0.00")
            .DesgloseCompraVentaAccionesTesoreriaTransfActual.Reservas = sheet.FormatDecimalValue(49, "F", "0.00")
            .DesgloseCompraVentaAccionesTesoreriaTransfActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(49, "G", "0.00")
            .Total = .DesgloseCompraVentaAccionesTesoreriaTransfActual.CapSocial +
                        .DesgloseCompraVentaAccionesTesoreriaTransfActual.AportesNoCapitalizados +
                        .DesgloseCompraVentaAccionesTesoreriaTransfActual.Ajustes +
                        .DesgloseCompraVentaAccionesTesoreriaTransfActual.Reservas +
                        .DesgloseCompraVentaAccionesTesoreriaTransfActual.ResultadosPrincipioPeriodo
        End With

        'Transferencias resultados año actual
        'Emisión acciones transf actual
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.EmisionAccionesTransfActual
            .DesgloseEmisionAccionesTransfActual.CapSocial = sheet.FormatDecimalValue(50, "C", "0.00")
            .DesgloseEmisionAccionesTransfActual.AportesNoCapitalizados = sheet.FormatDecimalValue(50, "D", "0.00")
            .DesgloseEmisionAccionesTransfActual.Ajustes = sheet.FormatDecimalValue(50, "E", "0.00")
            .DesgloseEmisionAccionesTransfActual.Reservas = sheet.FormatDecimalValue(50, "F", "0.00")
            .DesgloseEmisionAccionesTransfActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(50, "G", "0.00")
            .Total = .DesgloseEmisionAccionesTransfActual.CapSocial +
                        .DesgloseEmisionAccionesTransfActual.AportesNoCapitalizados +
                        .DesgloseEmisionAccionesTransfActual.Ajustes +
                        .DesgloseEmisionAccionesTransfActual.Reservas +
                        .DesgloseEmisionAccionesTransfActual.ResultadosPrincipioPeriodo
        End With

        'Transferencias resultados año actual
        'Capital pagado adicional transf actual
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.CapitalPagadoAdicionalTransfActual
            .DesgloseCapitalPagadoAdicionalTransfActual.CapSocial = sheet.FormatDecimalValue(51, "C", "0.00")
            .DesgloseCapitalPagadoAdicionalTransfActual.AportesNoCapitalizados = sheet.FormatDecimalValue(51, "D", "0.00")
            .DesgloseCapitalPagadoAdicionalTransfActual.Ajustes = sheet.FormatDecimalValue(51, "E", "0.00")
            .DesgloseCapitalPagadoAdicionalTransfActual.Reservas = sheet.FormatDecimalValue(51, "F", "0.00")
            .DesgloseCapitalPagadoAdicionalTransfActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(51, "G", "0.00")
            .Total = .DesgloseCapitalPagadoAdicionalTransfActual.CapSocial +
                        .DesgloseCapitalPagadoAdicionalTransfActual.AportesNoCapitalizados +
                        .DesgloseCapitalPagadoAdicionalTransfActual.Ajustes +
                        .DesgloseCapitalPagadoAdicionalTransfActual.Reservas +
                        .DesgloseCapitalPagadoAdicionalTransfActual.ResultadosPrincipioPeriodo
        End With

        'CUSTOM2020A
        'Transferencias resultados año actual
        'Superávit reva inmueble mobiliario equipo transf actual
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.SuperavitRevaPropiedadMobiliarioEquipoTransfActual
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual.CapSocial = sheet.FormatDecimalValue(52, "C", "0.00")
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual.AportesNoCapitalizados = sheet.FormatDecimalValue(52, "D", "0.00")
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual.Ajustes = sheet.FormatDecimalValue(52, "E", "0.00")
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual.Reservas = sheet.FormatDecimalValue(52, "F", "0.00")
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(52, "G", "0.00")
            .Total = .DesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual.CapSocial +
                        .DesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual.AportesNoCapitalizados +
                        .DesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual.Ajustes +
                        .DesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual.Reservas +
                        .DesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual.ResultadosPrincipioPeriodo
        End With

        'Transferencias resultados año actual
        'Transferencia superávit
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.TransferenciaSuperavit
            .DesgloseTransferenciaSuperavit.CapSocial = sheet.FormatDecimalValue(53, "C", "0.00")
            .DesgloseTransferenciaSuperavit.AportesNoCapitalizados = sheet.FormatDecimalValue(53, "D", "0.00")
            .DesgloseTransferenciaSuperavit.Ajustes = sheet.FormatDecimalValue(53, "E", "0.00")
            .DesgloseTransferenciaSuperavit.Reservas = sheet.FormatDecimalValue(53, "F", "0.00")
            .DesgloseTransferenciaSuperavit.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(53, "G", "0.00")
            .Total = .DesgloseTransferenciaSuperavit.CapSocial +
                        .DesgloseTransferenciaSuperavit.AportesNoCapitalizados +
                        .DesgloseTransferenciaSuperavit.Ajustes +
                        .DesgloseTransferenciaSuperavit.Reservas +
                        .DesgloseTransferenciaSuperavit.ResultadosPrincipioPeriodo
        End With

        'CUSTOM2020A
        'Transferencias resultados año actual
        'Superávit reva inmueble mobiliario equipo neto
        With _Patrimonio.Datos.Modelo.TranferenciasResultadosAnnoActual.SuperavitRevaPropiedadMobiliarioEquipoNeto
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto.CapSocial = sheet.FormatDecimalValue(54, "C", "0.00")
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto.AportesNoCapitalizados = sheet.FormatDecimalValue(54, "D", "0.00")
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto.Ajustes = sheet.FormatDecimalValue(54, "E", "0.00")
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto.Reservas = sheet.FormatDecimalValue(54, "F", "0.00")
            .DesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(54, "G", "0.00")
            .Total = .DesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto.CapSocial +
                     .DesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto.AportesNoCapitalizados +
                     .DesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto.Ajustes +
                     .DesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto.Reservas +
                     .DesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto.ResultadosPrincipioPeriodo
        End With

    End Sub
    Private Sub Rows_56_to_58(sheet As IXLWorksheet)
        'Saldo final año actual
        'Saldo final año actual
        With _Patrimonio.Datos.Modelo.SaldoFinalAnnoActual
            .DesgloseSaldoFinalAnnoActual.CapSocialFinActual = sheet.FormatDecimalValue(56, "C", "0.00")
            .DesgloseSaldoFinalAnnoActual.AportesNoCapitalizadosFinActual = sheet.FormatDecimalValue(56, "D", "0.00")
            .DesgloseSaldoFinalAnnoActual.AjustesFinActual = sheet.FormatDecimalValue(56, "E", "0.00")
            .DesgloseSaldoFinalAnnoActual.ReservasFinActual = sheet.FormatDecimalValue(56, "F", "0.00")
            .DesgloseSaldoFinalAnnoActual.ResultadosPrincipioPeriodoFinActual = sheet.FormatDecimalValue(56, "G", "0.00")
            .TotalSaldoFinalAnnoActual = .DesgloseSaldoFinalAnnoActual.CapSocialFinActual +
                                            .DesgloseSaldoFinalAnnoActual.AportesNoCapitalizadosFinActual +
                                            .DesgloseSaldoFinalAnnoActual.AjustesFinActual +
                                            .DesgloseSaldoFinalAnnoActual.ReservasFinActual +
                                            .DesgloseSaldoFinalAnnoActual.ResultadosPrincipioPeriodoFinActual
        End With

        'CUSTOM2020A
        'Saldo final año actual
        'Atribuido intereses minoritarios fin actual
        With _Patrimonio.Datos.Modelo.SaldoFinalAnnoActual.AtribuidoParticipNoControlFinActual
            .DesgloseAtribuidoParticipNoControlFinActual.CapSocial = sheet.FormatDecimalValue(57, "C", "0.00")
            .DesgloseAtribuidoParticipNoControlFinActual.AportesNoCapitalizados = sheet.FormatDecimalValue(57, "D", "0.00")
            .DesgloseAtribuidoParticipNoControlFinActual.Ajustes = sheet.FormatDecimalValue(57, "E", "0.00")
            .DesgloseAtribuidoParticipNoControlFinActual.Reservas = sheet.FormatDecimalValue(57, "F", "0.00")
            .DesgloseAtribuidoParticipNoControlFinActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(57, "G", "0.00")
            .Total = .DesgloseAtribuidoParticipNoControlFinActual.CapSocial +
                        .DesgloseAtribuidoParticipNoControlFinActual.AportesNoCapitalizados +
                        .DesgloseAtribuidoParticipNoControlFinActual.Ajustes +
                        .DesgloseAtribuidoParticipNoControlFinActual.Reservas +
                        .DesgloseAtribuidoParticipNoControlFinActual.ResultadosPrincipioPeriodo
        End With

        'Saldo final año actual
        'Atribuido controladora fin actual
        With _Patrimonio.Datos.Modelo.SaldoFinalAnnoActual.AtribuidoControladoraFinActual
            .DesgloseAtribuidoControladoraFinActual.CapSocial = sheet.FormatDecimalValue(58, "C", "0.00")
            .DesgloseAtribuidoControladoraFinActual.AportesNoCapitalizados = sheet.FormatDecimalValue(58, "D", "0.00")
            .DesgloseAtribuidoControladoraFinActual.Ajustes = sheet.FormatDecimalValue(58, "E", "0.00")
            .DesgloseAtribuidoControladoraFinActual.Reservas = sheet.FormatDecimalValue(58, "F", "0.00")
            .DesgloseAtribuidoControladoraFinActual.ResultadosPrincipioPeriodo = sheet.FormatDecimalValue(58, "G", "0.00")
            .Total = .DesgloseAtribuidoControladoraFinActual.CapSocial +
                    .DesgloseAtribuidoControladoraFinActual.AportesNoCapitalizados +
                    .DesgloseAtribuidoControladoraFinActual.Ajustes +
                    .DesgloseAtribuidoControladoraFinActual.Reservas +
                    .DesgloseAtribuidoControladoraFinActual.ResultadosPrincipioPeriodo
        End With

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