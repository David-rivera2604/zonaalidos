Imports System.Configuration
Imports System.Net.Http
Imports Architect.Sugese.Domain
Imports Architect.Sugese.Utility
Imports Architect.Sugese.Utility.Helpers
Imports Architect.Utilities.Extensions
Imports ClosedXML.Excel

Public Class Generate


    Private _BalanceGeneral As New ModeloBalanceGeneral

    Public Property Response As DataTable

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="periodo">Fecha correspondiente al período al cual corresponde el modelo</param>
    ''' <remarks></remarks>
    Public Sub New(periodo As Date)
        ModelInit()
        With _BalanceGeneral.Encabezado
            .NombreArchivo = String.Format("{0}-ModeloBalanceGeneral", ConfigurationManager.AppSettings("sugese.entidadaseguradora"))
            .Fecha = Today.ToString("yyyy-MM-dd")
            .Periodo = periodo.ToString("yyyy-MM-dd")
            .Periodicidad = BalanceGeneral.Periodicidad.T
            .Moneda = CodMoneda.Item1
        End With
        _BalanceGeneral.Datos.Modelo.EntidadFuente = ConfigurationManager.AppSettings("sugese.codigoaseguradora")
        Me.Response = XmlRespose.ReponseDataTable
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

    Public Sub FileSerialize(filename As String, withFormat As Boolean)
        Utilities.SerializeHandler(Of ModeloBalanceGeneral).SerializeToFile(_BalanceGeneral, filename, withFormat)


        Dim result As List(Of String) = Nothing


        'Validación según el XSD enviado por la sugese

        result = Validate.XsdValidate("ModeloBalanceGeneral", filename)
        If result.Count > 0 Then
            For Each item As String In result
                XmlRespose.AddError(Response, "error", item)
            Next
        End If


    End Sub

    Private Sub ModelInit()
        _BalanceGeneral = New ModeloBalanceGeneral
        With _BalanceGeneral
            .Encabezado = New BalanceGeneral.EncabezadoTipo
            .Datos = New ModeloBalanceGeneralDatos
        End With
        With _BalanceGeneral.Encabezado
            .NombreArchivo = String.Empty
            .Fecha = String.Empty
            .Periodo = String.Empty
            .Periodicidad = Periodicidad.T
            .Moneda = CodMoneda.Item1
        End With

        With _BalanceGeneral.Datos
            .Modelo = New ModeloBalanceGeneralDatosModelo
        End With
        With _BalanceGeneral.Datos.Modelo
            .Activo = New ModeloBalanceGeneralDatosModeloActivo
            .Pasivo = New ModeloBalanceGeneralDatosModeloPasivo
            .Patrimonio = New ModeloBalanceGeneralDatosModeloPatrimonio
            .PasivoMasPatrimonio = New ModeloBalanceGeneralDatosModeloPasivoMasPatrimonio
            .EntidadFuente = String.Empty
        End With
        With _BalanceGeneral.Datos.Modelo.Activo
            .Disponibilidades = New ModeloBalanceGeneralDatosModeloActivoDisponibilidades
            .InversionesInstrumentosFinancieros = New ModeloBalanceGeneralDatosModeloActivoInversionesInstrumentosFinancieros
            .CarteraCreditos = New ModeloBalanceGeneralDatosModeloActivoCarteraCreditos
            .ComisionesPrimasCuentasCobrar = New ModeloBalanceGeneralDatosModeloActivoComisionesPrimasCuentasCobrar
            .CuentasAcreedorasDeudorasOperacionesCoaseguroActivo = New ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesCoaseguroActivo
            .CuentasAcreedorasDeudorasOperacionesReaseguroActivo = New ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesReaseguroActivo
            .ParticipacionReaseguroProvisionesTecnicas = New ModeloBalanceGeneralDatosModeloActivoParticipacionReaseguroProvisionesTecnicas
            .BienesMantenidosParaVenta = New BalanceGeneral.ModeloBalanceGeneralDatosModeloActivoBienesMantenidosParaVenta
            .PropiedadesMobilarioEquipo = New BalanceGeneral.ModeloBalanceGeneralDatosModeloActivoPropiedadesMobilarioEquipo
            .OtrosActivos = New ModeloBalanceGeneralDatosModeloActivoOtrosActivos
            .PropiedadesDeInversion = New BalanceGeneral.ModeloBalanceGeneralDatosModeloActivoPropiedadesDeInversion
            .ParticipacionOtrasEmpresas = New ModeloBalanceGeneralDatosModeloActivoParticipacionOtrasEmpresas
            .TotalActivo = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Activo.Disponibilidades
            .DesgloseDisponibilidades = New ModeloBalanceGeneralDatosModeloActivoDisponibilidadesDesgloseDisponibilidades
            .TotalDisponibilidades = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Activo.Disponibilidades.DesgloseDisponibilidades
            .Efectivo = 0
            .DepVistaEnBCCR = 0
            .DepVistaEntidadesFinancierasPais = 0
            .DepVistaEntidadesFinancierasExterior = 0
            .DocCobroInmediato = 0
            .DispRestringidas = 0
            .CtasProductosCobrar = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Activo.InversionesInstrumentosFinancieros
            .DesgloseInversionesInstrumentosFinancieros = New ModeloBalanceGeneralDatosModeloActivoInversionesInstrumentosFinancierosDesgloseInversionesInstrumentosFinancieros
            .TotalInversiones = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Activo.InversionesInstrumentosFinancieros.DesgloseInversionesInstrumentosFinancieros
            'CUSTOM2020A
            .CambiosResultados = 0
            'CUSTOM2020A
            .CambiosResultadoIntegral = 0
            'CUSTOM2020A
            .CostoAmortizado = 0
            .EnCesacionPagosMorososLitigios = 0
            .VencidosRestringidos = 0
            .DifPosicionDerivados = 0
            .CtasProductosCobrar = 0
            .EstimacionDeterioro = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Activo.CarteraCreditos
            .DesgloseCarteraCreditos = New ModeloBalanceGeneralDatosModeloActivoCarteraCreditosDesgloseCarteraCreditos
            .TotalCartera = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Activo.CarteraCreditos.DesgloseCarteraCreditos
            .Vigentes = 0
            .Vencidos = 0
            .CobroJudicial = 0
            .Restringidos = 0
            .CtasProductosPorCobrar = 0
            .EstimacionDeterioro = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Activo.ComisionesPrimasCuentasCobrar
            .DesgloseComisionesPrimasCuentasCobrar = New ModeloBalanceGeneralDatosModeloActivoComisionesPrimasCuentasCobrarDesgloseComisionesPrimasCuentasCobrar
            .TotalComisiones = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Activo.ComisionesPrimasCuentasCobrar.DesgloseComisionesPrimasCuentasCobrar
            .ComisionesCobrar = 0
            .PrimasCobrar = 0
            .PrimasVencidas = 0
            .CtasCobrarOperacionesPartesRelacionadas = 0
            .ImpDiferidoImpCobrar = 0
            .OtrasCtasCobrar = 0
            .ProductosCobrarAsociadosCuentasCobrar = 0
            .EstimacionDeterioro = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Activo.CuentasAcreedorasDeudorasOperacionesCoaseguroActivo
            .DesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroActivo = New ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesCoaseguroActivoDesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroActivo
            .TotalCuentasAcreedorasDeudorasOperacionesCoaseguroActivo = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Activo.CuentasAcreedorasDeudorasOperacionesCoaseguroActivo.DesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroActivo
            .CuentasCorrientesOperacionesCoaseguroActivo = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Activo.CuentasAcreedorasDeudorasOperacionesReaseguroActivo
            .DesgloseCuentasAcreedorasDeudorasOperacionesReaseguroActivo = New ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesReaseguroActivoDesgloseCuentasAcreedorasDeudorasOperacionesReaseguroActivo
            .TotalCuentasAcreedorasDeudorasOperacionesReaseguroActivo = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Activo.CuentasAcreedorasDeudorasOperacionesReaseguroActivo.DesgloseCuentasAcreedorasDeudorasOperacionesReaseguroActivo
            .CuentasAcreedorasDeudorasReaseguroCedidoRetrocedido = 0
            .CuentasAcreedorasDeudorasReaseguroAceptado = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Activo.ParticipacionReaseguroProvisionesTecnicas
            .DesgloseParticipacionReaseguroProvisionesTecnicas = New ModeloBalanceGeneralDatosModeloActivoParticipacionReaseguroProvisionesTecnicasDesgloseParticipacionReaseguroProvisionesTecnicas
            .TotalParticipacion = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Activo.ParticipacionReaseguroProvisionesTecnicas.DesgloseParticipacionReaseguroProvisionesTecnicas
            .ProvisionPrimasNoDevengadas = 0
            .ProvisionMatematica = 0
            .ProvisionSiniestros = 0
            .OtrasProvisionesTecnicas = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Activo.BienesMantenidosParaVenta
            .DesgloseBienesMantenidosParaVenta = New BalanceGeneral.ModeloBalanceGeneralDatosModeloActivoBienesMantenidosParaVentaDesgloseBienesMantenidosParaVenta
            .TotalBienesMantenidosParaVenta = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Activo.BienesMantenidosParaVenta.DesgloseBienesMantenidosParaVenta
            .AdquiridosRecuperacionCreditos = 0
            .PropiedadesMobiliarioEquipoFueraDeUso = 0
            .OtrosBienes = 0
            .ProductosCobrarAsociados = 0
            .EstimacionDeterioro = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Activo.PropiedadesMobilarioEquipo
            .DesglosePropiedadesMobilarioEquipo = New BalanceGeneral.ModeloBalanceGeneralDatosModeloActivoPropiedadesMobilarioEquipoDesglosePropiedadesMobilarioEquipo
            .TotalPropiedadesMobilarioEquipo = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Activo.PropiedadesMobilarioEquipo.DesglosePropiedadesMobilarioEquipo
            .Mobiliario = 0
            .Computacion = 0
            .Vehiculos = 0
            .PorDerechoDeUso = 0
            .Terrenos = 0
            .EdificiosInstalaciones = 0
            .OtrosActivosOperativos = 0
            .DepreciacionAcumulada = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Activo.OtrosActivos
            .DesgloseOtrosActivos = New ModeloBalanceGeneralDatosModeloActivoOtrosActivosDesgloseOtrosActivos
            .TotalOtrosActivos = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Activo.OtrosActivos.DesgloseOtrosActivos
            .GastosPagadosAnticipado = 0
            .CargosDiferidos = 0
            .BienesDiversos = 0
            .OperacionesPendientesImputacion = 0
            .CtasReciprocasInternas = 0
            .ActivosIntangibles = 0
            .OtrosActivosRestringidos = 0
            .EstimacionPrimasPolizasFlotantes = 0
            .ComisionEstimacionPrimasPolizasFlotantes = 0
            .DepositosConstituidosReaseguro = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Activo.PropiedadesDeInversion
            .DesglosePropiedadesDeInversion = New BalanceGeneral.ModeloBalanceGeneralDatosModeloActivoPropiedadesDeInversionDesglosePropiedadesDeInversion
            .TotalPropiedadesDeInversion = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Activo.PropiedadesDeInversion.DesglosePropiedadesDeInversion
            .Terrenos = 0
            .Edificios = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Activo.ParticipacionOtrasEmpresas
            .DesgloseParticipacionOtrasEmpresas = New ModeloBalanceGeneralDatosModeloActivoParticipacionOtrasEmpresasDesgloseParticipacionOtrasEmpresas
            .TotalPartOtrasEmpresas = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Activo.ParticipacionOtrasEmpresas.DesgloseParticipacionOtrasEmpresas
            .DelPais = 0
            .DelExterior = 0
            .MinimoDeFuncionamientoOPC = 0
            .VehiculosPropositoEspecialPais = 0
            .Deterioro = 0
        End With



        With _BalanceGeneral.Datos.Modelo.Pasivo
            .ObligacionesPublico = New ModeloBalanceGeneralDatosModeloPasivoObligacionesPublico
            'CUSTOM2020A
            '.ObligacionesBCCR = New ModeloBalanceGeneralDatosModeloPasivoObligacionesBCCR
            .ObligacionesEntidades = New ModeloBalanceGeneralDatosModeloPasivoObligacionesEntidades
            .CuentasPorPagarYProvisiones = New ModeloBalanceGeneralDatosModeloPasivoCuentasPorPagarYProvisiones
            .ProvisionesTecnicas = New ModeloBalanceGeneralDatosModeloPasivoProvisionesTecnicas
            .CuentasAcreedorasDeudorasOperacionesReaseguroPasivo = New ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesReaseguroPasivo
            .CuentasAcreedorasDeudorasOperacionesCoaseguroPasivo = New ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo
            .AseguradosAgentesIntermediarios = New ModeloBalanceGeneralDatosModeloPasivoAseguradosAgentesIntermediarios
            .OtrosPasivos = New ModeloBalanceGeneralDatosModeloPasivoOtrosPasivos
            .ObligacionesSubordinadas = New ModeloBalanceGeneralDatosModeloPasivoObligacionesSubordinadas
            .ObligacionesConvertiblesEnCapital = New ModeloBalanceGeneralDatosModeloPasivoObligacionesConvertiblesEnCapital
            .ObligacionesPreferentes = New ModeloBalanceGeneralDatosModeloPasivoObligacionesPreferentes
            .TotalPasivo = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesPublico
            .DesgloseObligacionesPublico = New ModeloBalanceGeneralDatosModeloPasivoObligacionesPublicoDesgloseObligacionesPublico
            .TotalOblPublico = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesPublico.DesgloseObligacionesPublico
            .ReportoPactoTripartitoPrestamoValores = 0
            .ObligacionesPlazo = 0
            .CargosPorPagar = 0
        End With

        'CUSTOM2020A
        'With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesBCCR
        '    .DesgloseObligacionesBCCR = New ModeloBalanceGeneralDatosModeloPasivoObligacionesBCCRDesgloseObligacionesBCCR
        '    .TotalOblBCCR = 0
        'End With
        'With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesBCCR.DesgloseObligacionesBCCR
        '    .VistaBCCR = 0
        '    .Plazo = 0
        '    .CargosPagar = 0
        'End With


        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesEntidades
            .DesgloseObligacionesEntidades = New ModeloBalanceGeneralDatosModeloPasivoObligacionesEntidadesDesgloseObligacionesEntidades
            .TotalOblEntidades = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesEntidades.DesgloseObligacionesEntidades
            .Vista = 0
            .APlazo = 0
            .EntidadesNoFinancieras = 0
            .CargosPorPagar = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Pasivo.CuentasPorPagarYProvisiones
            .DesgloseCuentasPorPagarYProvisiones = New ModeloBalanceGeneralDatosModeloPasivoCuentasPorPagarYProvisionesDesgloseCuentasPorPagarYProvisiones
            .TotalCuentasPagarProv = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Pasivo.CuentasPorPagarYProvisiones.DesgloseCuentasPorPagarYProvisiones
            .DifPosicionDerivados = 0
            .CtasComisionesPorPagarDiversas = 0
            .Provisiones = 0
            .RentaDiferido = 0
            .CargosPagarDiversos = 0
            .OtrasCuentasPorCobrar = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Pasivo.ProvisionesTecnicas
            .DesgloseProvisionesTecnicas = New ModeloBalanceGeneralDatosModeloPasivoProvisionesTecnicasDesgloseProvisionesTecnicas
            .TotalProvTecnicas = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Pasivo.ProvisionesTecnicas.DesgloseProvisionesTecnicas
            .ProvisionesPrimasNoDevengadas = 0
            .ProvisionesInsuficienciaPrimas = 0
            .Matematicas = 0
            .ProvisionSiniestrosReportados = 0
            .ProvisionOYNR = 0
            .ProvisionParticipacionEnBeneficiosYExtornos = 0
            .ProvisionSegurosVidaRiesgoInversionAsumeTomador = 0
            .OtrasProvisionesTecnicas = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Pasivo.CuentasAcreedorasDeudorasOperacionesReaseguroPasivo
            .DesgloseCuentasAcreedorasDeudorasOperacionesReaseguroPasivo = New ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesReaseguroPasivoDesgloseCuentasAcreedorasDeudorasOperacionesReaseguroPasivo
            .TotalCuentasAcreedorasDeudorasOperacionesReaseguroPasivo = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Pasivo.CuentasAcreedorasDeudorasOperacionesReaseguroPasivo.DesgloseCuentasAcreedorasDeudorasOperacionesReaseguroPasivo
            .CuentasAcreedorasDeudorasReaseguroCedidoRetrocedido = 0
            .CuentasAcreedorasDeudorasReaseguroAceptado = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Pasivo.CuentasAcreedorasDeudorasOperacionesCoaseguroPasivo
            .DesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo = New ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesCoaseguroPasivoDesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo
            .TotalCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Pasivo.CuentasAcreedorasDeudorasOperacionesCoaseguroPasivo.DesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo
            .CuentaCorrienteOperacionesCoaseguro = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Pasivo.AseguradosAgentesIntermediarios
            .DesgloseAseguradosAgentesIntermediarios = New ModeloBalanceGeneralDatosModeloPasivoAseguradosAgentesIntermediariosDesgloseAseguradosAgentesIntermediarios
            .TotalAsegurados = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Pasivo.AseguradosAgentesIntermediarios.DesgloseAseguradosAgentesIntermediarios
            .Asegurados = 0
            .AgentesEIntermediarios = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Pasivo.OtrosPasivos
            .DesgloseOtrosPasivos = New ModeloBalanceGeneralDatosModeloPasivoOtrosPasivosDesgloseOtrosPasivos
            .TotalOtrosPasivos = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Pasivo.OtrosPasivos.DesgloseOtrosPasivos
            .IngresosDiferidos = 0
            .OperacionesPendientesImputacion = 0
            .CtasReciprocasInternas = 0
            .PasivoPagosValorRazonableInstrumentosPatrimonio = 0
            .EstimacionPrimasPolizasAbiertasoFlotantes = 0
            .ComisionPrimasPolizasAbiertasoFlotantes = 0
            .DepositosRecibidosReaseguro = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesSubordinadas
            .DesgloseObligacionesSubordinadas = New ModeloBalanceGeneralDatosModeloPasivoObligacionesSubordinadasDesgloseObligacionesSubordinadas
            .TotalOblSubordinadas = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesSubordinadas.DesgloseObligacionesSubordinadas
            .ObligacionesSubordinadas = 0
            .CargosPagar = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesConvertiblesEnCapital
            .DesgloseObligacionesConvertiblesEnCapital = New ModeloBalanceGeneralDatosModeloPasivoObligacionesConvertiblesEnCapitalDesgloseObligacionesConvertiblesEnCapital
            .TotalOblConvertibles = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesConvertiblesEnCapital.DesgloseObligacionesConvertiblesEnCapital
            .ObligacionesConvertiblesEnCapital = 0
            .CargosPagar = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesPreferentes
            .DesgloseObligacionesPreferentes = New ModeloBalanceGeneralDatosModeloPasivoObligacionesPreferentesDesgloseObligacionesPreferentes
            .TotalOblPreferentes = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesPreferentes.DesgloseObligacionesPreferentes
            .ObligacionesPreferentes = 0
            .CargosPagar = 0
        End With



        With _BalanceGeneral.Datos.Modelo.Patrimonio
            .CapitalSocialCapitalMinimoFuncionamiento = New ModeloBalanceGeneralDatosModeloPatrimonioCapitalSocialCapitalMinimoFuncionamiento
            .AportesPatrimonialesNoCapitalizados = New ModeloBalanceGeneralDatosModeloPatrimonioAportesPatrimonialesNoCapitalizados
            'CUSTOM2010A
            .AjustesPatrimonioResultadoIntegral = New BalanceGeneral.ModeloBalanceGeneralDatosModeloPatrimonioAjustesPatrimonioResultadoIntegral
            'CUSTOM2010A
            .Reservas = New BalanceGeneral.ModeloBalanceGeneralDatosModeloPatrimonioReservas
            .ResultadosAcumuladosEjerciciosAnteriores = New ModeloBalanceGeneralDatosModeloPatrimonioResultadosAcumuladosEjerciciosAnteriores
            .ResultadosPeriodo = New ModeloBalanceGeneralDatosModeloPatrimonioResultadosPeriodo
            'CUSTOM2010A
            .ParticipacionesNoControladas = New BalanceGeneral.ModeloBalanceGeneralDatosModeloPatrimonioParticipacionesNoControladas
            'CUSTOM2010A
            .PatrimonioEnFondoOReservasEspeciales = New BalanceGeneral.ModeloBalanceGeneralDatosModeloPatrimonioPatrimonioEnFondoOReservasEspeciales
            .TotalPatrimonio = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Patrimonio.CapitalSocialCapitalMinimoFuncionamiento
            .DesgloseCapitalSocialCapitalMinimoFuncionamiento = New ModeloBalanceGeneralDatosModeloPatrimonioCapitalSocialCapitalMinimoFuncionamientoDesgloseCapitalSocialCapitalMinimoFuncionamiento
            .TotalCapSocial = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Patrimonio.CapitalSocialCapitalMinimoFuncionamiento.DesgloseCapitalSocialCapitalMinimoFuncionamiento
            .Pagado = 0
            .Donado = 0
            .SuscritoNoIntegrado = 0
            .SuscripcionesCapitalPorIntegrar = 0
            .AccionesTesoreria = 0
            'CUSTOM2010A
            '.CapitalMunimoFuncionamientoOperadorasPensionesComplementarias = 0
            .CapitalAsignadoSucursales = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Patrimonio.AportesPatrimonialesNoCapitalizados
            .DesgloseAportesPatrimonialesNoCapitalizados = New ModeloBalanceGeneralDatosModeloPatrimonioAportesPatrimonialesNoCapitalizadosDesgloseAportesPatrimonialesNoCapitalizados
            .TotalApoPatrimoniales = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Patrimonio.AportesPatrimonialesNoCapitalizados.DesgloseAportesPatrimonialesNoCapitalizados
            .CapitalPagadoAdicional = 0
            .ParaIncrementosCapital = 0
            'CUSTOM2010A
            '.DonacionesYOtrasContribuciones = 0
            'CUSTOM2010A
            '.AportesExcCapMinFunOperPenComp = 0
            .ApotMantCapMinObliEntAsegYReasegRevalUDPendCalificar = 0
            .ApotMantCapMinObliEntAsegYReasegRevalUDPendCalificarSucursales = 0
        End With

        'CUSTOM2010A
        With _BalanceGeneral.Datos.Modelo.Patrimonio.AjustesPatrimonioResultadoIntegral
            .DesgloseAjustesPatrimonioResultadoIntegral = New BalanceGeneral.ModeloBalanceGeneralDatosModeloPatrimonioAjustesPatrimonioResultadoIntegralDesgloseAjustesPatrimonioResultadoIntegral
            .TotalAjustesPatrimonioResultadoIntegral = 0
        End With
        'CUSTOM2010A
        With _BalanceGeneral.Datos.Modelo.Patrimonio.AjustesPatrimonioResultadoIntegral.DesgloseAjustesPatrimonioResultadoIntegral
            .AlValorActivos = 0
            .ValoracionParticipacionesOtrasEmpresas = 0
            .ConversionEstadosFinancieros = 0
        End With

        'CUSTOM2010A
        With _BalanceGeneral.Datos.Modelo.Patrimonio.Reservas
            .DesgloseReservas = New BalanceGeneral.ModeloBalanceGeneralDatosModeloPatrimonioReservasDesgloseReservas
            .TotalReservas = 0
        End With
        'CUSTOM2010A
        With _BalanceGeneral.Datos.Modelo.Patrimonio.Reservas.DesgloseReservas
            .Legal = 0
            .OtrasObligatorias = 0
            .Voluntarias = 0
            .ReservaNiveladoraAcumulada = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Patrimonio.ResultadosAcumuladosEjerciciosAnteriores
            .DesgloseResultadosAcumuladosEjerciciosAnteriores = New ModeloBalanceGeneralDatosModeloPatrimonioResultadosAcumuladosEjerciciosAnterioresDesgloseResultadosAcumuladosEjerciciosAnteriores
            .TotalResAcumulados = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Patrimonio.ResultadosAcumuladosEjerciciosAnteriores.DesgloseResultadosAcumuladosEjerciciosAnteriores
            .UtilidadesAcumuladas = 0
            .PerdidasAcumuladas = 0
        End With


        With _BalanceGeneral.Datos.Modelo.Patrimonio.ResultadosPeriodo
            .DesgloseResultadosPeriodo = New ModeloBalanceGeneralDatosModeloPatrimonioResultadosPeriodoDesgloseResultadosPeriodo
            .TotalResPeriodo = 0
        End With
        With _BalanceGeneral.Datos.Modelo.Patrimonio.ResultadosPeriodo.DesgloseResultadosPeriodo
            .UtilidadNeta = 0
            .PerdidaNeta = 0
            .ReservaNiveladoraPeriodo = 0
        End With

        'CUSTOM2010A
        With _BalanceGeneral.Datos.Modelo.Patrimonio.ParticipacionesNoControladas
            .DesgloseParticipacionesNoControladas = New BalanceGeneral.ModeloBalanceGeneralDatosModeloPatrimonioParticipacionesNoControladasDesgloseParticipacionesNoControladas
            .TotalParticipacionesNoControladas = 0
        End With
        'CUSTOM2010A
        With _BalanceGeneral.Datos.Modelo.Patrimonio.ParticipacionesNoControladas.DesgloseParticipacionesNoControladas
            .ParticipacionesNoControladas = 0
        End With

        'CUSTOM2010A
        With _BalanceGeneral.Datos.Modelo.Patrimonio.PatrimonioEnFondoOReservasEspeciales
            .DesglosePatrimonioEnFondoOReservasEspeciales = New BalanceGeneral.ModeloBalanceGeneralDatosModeloPatrimonioPatrimonioEnFondoOReservasEspecialesDesglosePatrimonioEnFondoOReservasEspeciales
            .TotalPatrimonioEnFondoOReservasEspeciales = 0
        End With
        'CUSTOM2010A
        With _BalanceGeneral.Datos.Modelo.Patrimonio.PatrimonioEnFondoOReservasEspeciales.DesglosePatrimonioEnFondoOReservasEspeciales
            .FondosEspeciales = 0
            .ReservasEspeciales = 0
        End With



        With _BalanceGeneral.Datos.Modelo.PasivoMasPatrimonio
            .TotalPasivoMasPatrimonio = 0
        End With



    End Sub

    Public Sub LoadExcelInformation(excelFilename As String)
        Dim workbook As New XLWorkbook(excelFilename)
        Dim sheet As IXLWorksheet = Nothing
        Dim RowNumber As Integer = 4

        Sheet_1(workbook.Worksheet("Activo I"), RowNumber)
        Sheet_2(workbook.Worksheet("Activo II"), RowNumber)
        Sheet_3(workbook.Worksheet("Activo III"), RowNumber)
        Sheet_4(workbook.Worksheet("Pasivo I"), RowNumber)
        Sheet_5(workbook.Worksheet("Pasivo II"), RowNumber)
        Sheet_6(workbook.Worksheet("Pasivo III"), RowNumber)
        Sheet_7(workbook.Worksheet("Patrimonio I"), RowNumber)
        Sheet_8(workbook.Worksheet("Patrimonio II"), RowNumber)

        sheet = Nothing
        workbook = Nothing
    End Sub
    Private Sub Sheet_1(sheet As IXLWorksheet, RowNumber As Integer)
        'Disponibilidades
        With _BalanceGeneral.Datos.Modelo.Activo.Disponibilidades
            .DesgloseDisponibilidades.Efectivo = sheet.FormatDecimalValue(RowNumber, "A", "0.00")
            .DesgloseDisponibilidades.DepVistaEnBCCR = sheet.FormatDecimalValue(RowNumber, "B", "0.00")
            .DesgloseDisponibilidades.DepVistaEntidadesFinancierasPais = sheet.FormatDecimalValue(RowNumber, "C", "0.00")
            .DesgloseDisponibilidades.DepVistaEntidadesFinancierasExterior = sheet.FormatDecimalValue(RowNumber, "D", "0.00")
            .DesgloseDisponibilidades.DocCobroInmediato = sheet.FormatDecimalValue(RowNumber, "E", "0.00")
            .DesgloseDisponibilidades.DispRestringidas = sheet.FormatDecimalValue(RowNumber, "F", "0.00")
            .DesgloseDisponibilidades.CtasProductosCobrar = sheet.FormatDecimalValue(RowNumber, "G", "0.00")

            .TotalDisponibilidades = .DesgloseDisponibilidades.Efectivo +
                                     .DesgloseDisponibilidades.DepVistaEnBCCR +
                                     .DesgloseDisponibilidades.DepVistaEntidadesFinancierasPais +
                                     .DesgloseDisponibilidades.DepVistaEntidadesFinancierasExterior +
                                     .DesgloseDisponibilidades.DocCobroInmediato +
                                     .DesgloseDisponibilidades.DispRestringidas +
                                     .DesgloseDisponibilidades.CtasProductosCobrar
        End With

        'Inversiones Instrumentos Financieros
        With _BalanceGeneral.Datos.Modelo.Activo.InversionesInstrumentosFinancieros
            'CUSTOM2020A
            .DesgloseInversionesInstrumentosFinancieros.CambiosResultados = sheet.FormatDecimalValue(RowNumber, "H", "0.00")
            'CUSTOM2020A
            .DesgloseInversionesInstrumentosFinancieros.CambiosResultadoIntegral = sheet.FormatDecimalValue(RowNumber, "I", "0.00")
            'CUSTOM2020A
            .DesgloseInversionesInstrumentosFinancieros.CostoAmortizado = sheet.FormatDecimalValue(RowNumber, "J", "0.00")
            .DesgloseInversionesInstrumentosFinancieros.EnCesacionPagosMorososLitigios = sheet.FormatDecimalValue(RowNumber, "K", "0.00")
            .DesgloseInversionesInstrumentosFinancieros.VencidosRestringidos = sheet.FormatDecimalValue(RowNumber, "L", "0.00")
            .DesgloseInversionesInstrumentosFinancieros.DifPosicionDerivados = sheet.FormatDecimalValue(RowNumber, "M", "0.00")
            .DesgloseInversionesInstrumentosFinancieros.CtasProductosCobrar = sheet.FormatDecimalValue(RowNumber, "N", "0.00")
            .DesgloseInversionesInstrumentosFinancieros.EstimacionDeterioro = sheet.FormatDecimalValue(RowNumber, "O", "0.00")
            .TotalInversiones = .DesgloseInversionesInstrumentosFinancieros.CambiosResultados +
                                .DesgloseInversionesInstrumentosFinancieros.CambiosResultadoIntegral +
                                .DesgloseInversionesInstrumentosFinancieros.CostoAmortizado +
                                .DesgloseInversionesInstrumentosFinancieros.EnCesacionPagosMorososLitigios +
                                .DesgloseInversionesInstrumentosFinancieros.VencidosRestringidos +
                                .DesgloseInversionesInstrumentosFinancieros.DifPosicionDerivados +
                                .DesgloseInversionesInstrumentosFinancieros.CtasProductosCobrar +
                                .DesgloseInversionesInstrumentosFinancieros.EstimacionDeterioro
        End With

        'Cartera Créditos
        With _BalanceGeneral.Datos.Modelo.Activo.CarteraCreditos
            .DesgloseCarteraCreditos.Vigentes = sheet.FormatDecimalValue(RowNumber, "P", "0.00")
            .DesgloseCarteraCreditos.Vencidos = sheet.FormatDecimalValue(RowNumber, "Q", "0.00")
            .DesgloseCarteraCreditos.CobroJudicial = sheet.FormatDecimalValue(RowNumber, "R", "0.00")
            .DesgloseCarteraCreditos.Restringidos = sheet.FormatDecimalValue(RowNumber, "S", "0.00")
            .DesgloseCarteraCreditos.CtasProductosPorCobrar = sheet.FormatDecimalValue(RowNumber, "T", "0.00")
            .DesgloseCarteraCreditos.EstimacionDeterioro = sheet.FormatDecimalValue(RowNumber, "U", "0.00")
            'CUSTOM2020A
            .DesgloseCarteraCreditos.CostosDirectosIncrementales = sheet.FormatDecimalValue(RowNumber, "V", "0.00")
            .DesgloseCarteraCreditos.IngresosDiferidos = sheet.FormatDecimalValue(RowNumber, "W", "0.00")

            .TotalCartera = .DesgloseCarteraCreditos.Vigentes +
                            .DesgloseCarteraCreditos.Vencidos +
                            .DesgloseCarteraCreditos.CobroJudicial +
                            .DesgloseCarteraCreditos.Restringidos +
                            .DesgloseCarteraCreditos.CtasProductosPorCobrar +
                            .DesgloseCarteraCreditos.EstimacionDeterioro +
                            .DesgloseCarteraCreditos.CostosDirectosIncrementales +
                            .DesgloseCarteraCreditos.IngresosDiferidos
        End With


    End Sub
    Private Sub Sheet_2(sheet As IXLWorksheet, RowNumber As Integer)
        'Comisiones Primas Cuentas Cobrar
        With _BalanceGeneral.Datos.Modelo.Activo.ComisionesPrimasCuentasCobrar
            .DesgloseComisionesPrimasCuentasCobrar.ComisionesCobrar = sheet.FormatDecimalValue(RowNumber, "A", "0.00")
            .DesgloseComisionesPrimasCuentasCobrar.PrimasCobrar = sheet.FormatDecimalValue(RowNumber, "B", "0.00")
            .DesgloseComisionesPrimasCuentasCobrar.PrimasVencidas = sheet.FormatDecimalValue(RowNumber, "C", "0.00")
            'CUSTOM2020A
            '.DesgloseComisionesPrimasCuentasCobrar.CtasCobrarOperacionesBursatiles = sheet.FormatDecimalValue(RowNumber, "D", "0.00")
            .DesgloseComisionesPrimasCuentasCobrar.CtasCobrarOperacionesPartesRelacionadas = sheet.FormatDecimalValue(RowNumber, "E", "0.00")
            'CUSTOM2020A
            .DesgloseComisionesPrimasCuentasCobrar.ImpDiferidoImpCobrar = sheet.FormatDecimalValue(RowNumber, "F", "0.00")
            .DesgloseComisionesPrimasCuentasCobrar.OtrasCtasCobrar = sheet.FormatDecimalValue(RowNumber, "G", "0.00")
            .DesgloseComisionesPrimasCuentasCobrar.ProductosCobrarAsociadosCuentasCobrar = sheet.FormatDecimalValue(RowNumber, "H", "0.00")
            .DesgloseComisionesPrimasCuentasCobrar.EstimacionDeterioro = sheet.FormatDecimalValue(RowNumber, "I", "0.00")
            .TotalComisiones = .DesgloseComisionesPrimasCuentasCobrar.ComisionesCobrar +
                               .DesgloseComisionesPrimasCuentasCobrar.PrimasCobrar +
                               .DesgloseComisionesPrimasCuentasCobrar.PrimasVencidas +
                               .DesgloseComisionesPrimasCuentasCobrar.CtasCobrarOperacionesPartesRelacionadas +
                               .DesgloseComisionesPrimasCuentasCobrar.ImpDiferidoImpCobrar +
                               .DesgloseComisionesPrimasCuentasCobrar.OtrasCtasCobrar +
                               .DesgloseComisionesPrimasCuentasCobrar.ProductosCobrarAsociadosCuentasCobrar +
                               .DesgloseComisionesPrimasCuentasCobrar.EstimacionDeterioro
        End With

        'Cuentas Acreedoras Deudoras Operaciones Coaseguro Activo
        With _BalanceGeneral.Datos.Modelo.Activo.CuentasAcreedorasDeudorasOperacionesCoaseguroActivo
            .DesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroActivo.CuentasCorrientesOperacionesCoaseguroActivo = sheet.FormatDecimalValue(RowNumber, "J", "0.00")
            .TotalCuentasAcreedorasDeudorasOperacionesCoaseguroActivo = .DesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroActivo.CuentasCorrientesOperacionesCoaseguroActivo
        End With

        'Cuentas Acreedoras Deudoras Operaciones Reaseguro Activo
        With _BalanceGeneral.Datos.Modelo.Activo.CuentasAcreedorasDeudorasOperacionesReaseguroActivo
            .DesgloseCuentasAcreedorasDeudorasOperacionesReaseguroActivo.CuentasAcreedorasDeudorasReaseguroCedidoRetrocedido = sheet.FormatDecimalValue(RowNumber, "K", "0.00")
            .DesgloseCuentasAcreedorasDeudorasOperacionesReaseguroActivo.CuentasAcreedorasDeudorasReaseguroAceptado = sheet.FormatDecimalValue(RowNumber, "L", "0.00")
            .TotalCuentasAcreedorasDeudorasOperacionesReaseguroActivo = .DesgloseCuentasAcreedorasDeudorasOperacionesReaseguroActivo.CuentasAcreedorasDeudorasReaseguroCedidoRetrocedido +
                                                                        .DesgloseCuentasAcreedorasDeudorasOperacionesReaseguroActivo.CuentasAcreedorasDeudorasReaseguroAceptado
        End With

        'Participación Reaseguro Provisiones Técnicas
        With _BalanceGeneral.Datos.Modelo.Activo.ParticipacionReaseguroProvisionesTecnicas
            .DesgloseParticipacionReaseguroProvisionesTecnicas.ProvisionPrimasNoDevengadas = sheet.FormatDecimalValue(RowNumber, "M", "0.00")
            .DesgloseParticipacionReaseguroProvisionesTecnicas.ProvisionMatematica = sheet.FormatDecimalValue(RowNumber, "N", "0.00")
            .DesgloseParticipacionReaseguroProvisionesTecnicas.ProvisionSiniestros = sheet.FormatDecimalValue(RowNumber, "O", "0.00")
            .DesgloseParticipacionReaseguroProvisionesTecnicas.OtrasProvisionesTecnicas = sheet.FormatDecimalValue(RowNumber, "P", "0.00")
            .TotalParticipacion = .DesgloseParticipacionReaseguroProvisionesTecnicas.ProvisionPrimasNoDevengadas +
                                  .DesgloseParticipacionReaseguroProvisionesTecnicas.ProvisionMatematica +
                                  .DesgloseParticipacionReaseguroProvisionesTecnicas.ProvisionSiniestros +
                                  .DesgloseParticipacionReaseguroProvisionesTecnicas.OtrasProvisionesTecnicas
        End With

        'CUSTOM2020A
        'Bienes Realizables
        With _BalanceGeneral.Datos.Modelo.Activo.BienesMantenidosParaVenta
            .DesgloseBienesMantenidosParaVenta.AdquiridosRecuperacionCreditos = sheet.FormatDecimalValue(RowNumber, "Q", "0.00")
            .DesgloseBienesMantenidosParaVenta.PropiedadesMobiliarioEquipoFueraDeUso = sheet.FormatDecimalValue(RowNumber, "R", "0.00")
            .DesgloseBienesMantenidosParaVenta.OtrosBienes = sheet.FormatDecimalValue(RowNumber, "S", "0.00")
            .DesgloseBienesMantenidosParaVenta.ProductosCobrarAsociados = sheet.FormatDecimalValue(RowNumber, "T", "0.00")
            .DesgloseBienesMantenidosParaVenta.EstimacionDeterioro = sheet.FormatDecimalValue(RowNumber, "U", "0.00")
            .TotalBienesMantenidosParaVenta = .DesgloseBienesMantenidosParaVenta.AdquiridosRecuperacionCreditos +
                                              .DesgloseBienesMantenidosParaVenta.PropiedadesMobiliarioEquipoFueraDeUso +
                                              .DesgloseBienesMantenidosParaVenta.OtrosBienes +
                                              .DesgloseBienesMantenidosParaVenta.ProductosCobrarAsociados +
                                              .DesgloseBienesMantenidosParaVenta.EstimacionDeterioro
        End With

    End Sub
    Private Sub Sheet_3(sheet As IXLWorksheet, RowNumber As Integer)
        'CUSTOM2020A
        'Bienes Muebles Inmuebles
        With _BalanceGeneral.Datos.Modelo.Activo.PropiedadesMobilarioEquipo
            .DesglosePropiedadesMobilarioEquipo.Mobiliario = sheet.FormatDecimalValue(RowNumber, "A", "0.00")
            .DesglosePropiedadesMobilarioEquipo.Computacion = sheet.FormatDecimalValue(RowNumber, "B", "0.00")
            .DesglosePropiedadesMobilarioEquipo.Vehiculos = sheet.FormatDecimalValue(RowNumber, "C", "0.00")
            .DesglosePropiedadesMobilarioEquipo.PorDerechoDeUso = sheet.FormatDecimalValue(RowNumber, "D", "0.00")
            .DesglosePropiedadesMobilarioEquipo.Terrenos = sheet.FormatDecimalValue(RowNumber, "E", "0.00")
            .DesglosePropiedadesMobilarioEquipo.EdificiosInstalaciones = sheet.FormatDecimalValue(RowNumber, "F", "0.00")
            .DesglosePropiedadesMobilarioEquipo.DepreciacionAcumulada = sheet.FormatDecimalValue(RowNumber, "G", "0.00")
            .TotalPropiedadesMobilarioEquipo = .DesglosePropiedadesMobilarioEquipo.Mobiliario +
                                             .DesglosePropiedadesMobilarioEquipo.Computacion +
                                             .DesglosePropiedadesMobilarioEquipo.Vehiculos +
                                             .DesglosePropiedadesMobilarioEquipo.PorDerechoDeUso +
                                             .DesglosePropiedadesMobilarioEquipo.Terrenos +
                                             .DesglosePropiedadesMobilarioEquipo.EdificiosInstalaciones +
                                             .DesglosePropiedadesMobilarioEquipo.DepreciacionAcumulada
        End With

        'Otros Activos
        With _BalanceGeneral.Datos.Modelo.Activo.OtrosActivos
            .DesgloseOtrosActivos.GastosPagadosAnticipado = sheet.FormatDecimalValue(RowNumber, "H", "0.00")
            .DesgloseOtrosActivos.CargosDiferidos = sheet.FormatDecimalValue(RowNumber, "I", "0.00")
            .DesgloseOtrosActivos.BienesDiversos = sheet.FormatDecimalValue(RowNumber, "J", "0.00")
            .DesgloseOtrosActivos.OperacionesPendientesImputacion = sheet.FormatDecimalValue(RowNumber, "K", "0.00")
            .DesgloseOtrosActivos.CtasReciprocasInternas = sheet.FormatDecimalValue(RowNumber, "L", "0.00")
            .DesgloseOtrosActivos.ActivosIntangibles = sheet.FormatDecimalValue(RowNumber, "M", "0.00")
            .DesgloseOtrosActivos.OtrosActivosRestringidos = sheet.FormatDecimalValue(RowNumber, "N", "0.00")
            .DesgloseOtrosActivos.EstimacionPrimasPolizasFlotantes = sheet.FormatDecimalValue(RowNumber, "O", "0.00")
            .DesgloseOtrosActivos.ComisionEstimacionPrimasPolizasFlotantes = sheet.FormatDecimalValue(RowNumber, "P", "0.00")
            .DesgloseOtrosActivos.DepositosConstituidosReaseguro = sheet.FormatDecimalValue(RowNumber, "Q", "0.00")
            .TotalOtrosActivos = .DesgloseOtrosActivos.GastosPagadosAnticipado +
                                 .DesgloseOtrosActivos.CargosDiferidos +
                                 .DesgloseOtrosActivos.BienesDiversos +
                                 .DesgloseOtrosActivos.OperacionesPendientesImputacion +
                                 .DesgloseOtrosActivos.CtasReciprocasInternas +
                                 .DesgloseOtrosActivos.ActivosIntangibles +
                                 .DesgloseOtrosActivos.OtrosActivosRestringidos +
                                 .DesgloseOtrosActivos.EstimacionPrimasPolizasFlotantes +
                                 .DesgloseOtrosActivos.ComisionEstimacionPrimasPolizasFlotantes +
                                 .DesgloseOtrosActivos.DepositosConstituidosReaseguro
        End With

        'CUSTOM2020A
        'Inversiones En Propiedades
        With _BalanceGeneral.Datos.Modelo.Activo.PropiedadesDeInversion
            .DesglosePropiedadesDeInversion.Terrenos = sheet.FormatDecimalValue(RowNumber, "R", "0.00")
            .DesglosePropiedadesDeInversion.Edificios = sheet.FormatDecimalValue(RowNumber, "S", "0.00")
            .TotalPropiedadesDeInversion = .DesglosePropiedadesDeInversion.Terrenos +
                                           .DesglosePropiedadesDeInversion.Edificios
        End With

        'Participación Otras Empresas
        With _BalanceGeneral.Datos.Modelo.Activo.ParticipacionOtrasEmpresas
            .DesgloseParticipacionOtrasEmpresas.DelPais = sheet.FormatDecimalValue(RowNumber, "T", "0.00")
            .DesgloseParticipacionOtrasEmpresas.DelExterior = sheet.FormatDecimalValue(RowNumber, "U", "0.00")
            .DesgloseParticipacionOtrasEmpresas.MinimoDeFuncionamientoOPC = sheet.FormatDecimalValue(RowNumber, "V", "0.00")
            .DesgloseParticipacionOtrasEmpresas.VehiculosPropositoEspecialPais = sheet.FormatDecimalValue(RowNumber, "W", "0.00")
            'CUSTOM2020A
            '.DesgloseParticipacionOtrasEmpresas.VehiculosPropositoEspecialExterior = sheet.FormatDecimalValue(RowNumber, "X", "0.00")
            .DesgloseParticipacionOtrasEmpresas.Deterioro = sheet.FormatDecimalValue(RowNumber, "Y", "0.00")
            .TotalPartOtrasEmpresas = .DesgloseParticipacionOtrasEmpresas.DelPais +
                                      .DesgloseParticipacionOtrasEmpresas.DelExterior +
                                      .DesgloseParticipacionOtrasEmpresas.MinimoDeFuncionamientoOPC +
                                      .DesgloseParticipacionOtrasEmpresas.VehiculosPropositoEspecialPais +
                                      .DesgloseParticipacionOtrasEmpresas.Deterioro
        End With

        With _BalanceGeneral.Datos.Modelo.Activo
            .TotalActivo = _BalanceGeneral.Datos.Modelo.Activo.Disponibilidades.TotalDisponibilidades +
                           _BalanceGeneral.Datos.Modelo.Activo.InversionesInstrumentosFinancieros.TotalInversiones +
                           _BalanceGeneral.Datos.Modelo.Activo.CarteraCreditos.TotalCartera +
                           _BalanceGeneral.Datos.Modelo.Activo.ComisionesPrimasCuentasCobrar.TotalComisiones +
                           _BalanceGeneral.Datos.Modelo.Activo.CuentasAcreedorasDeudorasOperacionesCoaseguroActivo.TotalCuentasAcreedorasDeudorasOperacionesCoaseguroActivo +
                           _BalanceGeneral.Datos.Modelo.Activo.CuentasAcreedorasDeudorasOperacionesReaseguroActivo.TotalCuentasAcreedorasDeudorasOperacionesReaseguroActivo +
                           _BalanceGeneral.Datos.Modelo.Activo.ParticipacionReaseguroProvisionesTecnicas.TotalParticipacion +
                           _BalanceGeneral.Datos.Modelo.Activo.BienesMantenidosParaVenta.TotalBienesMantenidosParaVenta +
                           _BalanceGeneral.Datos.Modelo.Activo.PropiedadesMobilarioEquipo.TotalPropiedadesMobilarioEquipo +
                           _BalanceGeneral.Datos.Modelo.Activo.OtrosActivos.TotalOtrosActivos +
                           _BalanceGeneral.Datos.Modelo.Activo.PropiedadesDeInversion.TotalPropiedadesDeInversion +
                           _BalanceGeneral.Datos.Modelo.Activo.ParticipacionOtrasEmpresas.TotalPartOtrasEmpresas
        End With
    End Sub
    Private Sub Sheet_4(sheet As IXLWorksheet, RowNumber As Integer)
        'Obligaciones Publico
        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesPublico
            'CUSTOM2020A
            '.DesgloseObligacionesPublico.CaptacionesVista = sheet.FormatDecimalValue(RowNumber, "A", "0.00")
            '.DesgloseObligacionesPublico.ObligacionesVista = sheet.FormatDecimalValue(RowNumber, "B", "0.00")
            '.DesgloseObligacionesPublico.CaptacionesPlazo = sheet.FormatDecimalValue(RowNumber, "C", "0.00")
            '.DesgloseObligacionesPublico.PorAceptaciones = sheet.FormatDecimalValue(RowNumber, "D", "0.00")
            .DesgloseObligacionesPublico.ReportoPactoTripartitoPrestamoValores = sheet.FormatDecimalValue(RowNumber, "E", "0.00")
            .DesgloseObligacionesPublico.ObligacionesPlazo = sheet.FormatDecimalValue(RowNumber, "F", "0.00")
            .DesgloseObligacionesPublico.CargosPorPagar = sheet.FormatDecimalValue(RowNumber, "G", "0.00")
            .TotalOblPublico = .DesgloseObligacionesPublico.ReportoPactoTripartitoPrestamoValores +
                               .DesgloseObligacionesPublico.ObligacionesPlazo +
                               .DesgloseObligacionesPublico.CargosPorPagar
        End With

        'CUSTOM2020A
        'Obligaciones BCCR
        'With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesBCCR
        '    .DesgloseObligacionesBCCR.VistaBCCR = sheet.FormatDecimalValue(RowNumber, "H", "0.00")
        '    .DesgloseObligacionesBCCR.Plazo = sheet.FormatDecimalValue(RowNumber, "I", "0.00")
        '    .DesgloseObligacionesBCCR.CargosPagar = sheet.FormatDecimalValue(RowNumber, "J", "0.00")
        '    .TotalOblBCCR = .DesgloseObligacionesBCCR.VistaBCCR +
        '                    .DesgloseObligacionesBCCR.Plazo +
        '                    .DesgloseObligacionesBCCR.CargosPagar
        'End With

        'Obligaciones Entidades
        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesEntidades
            .DesgloseObligacionesEntidades.Vista = sheet.FormatDecimalValue(RowNumber, "K", "0.00")
            .DesgloseObligacionesEntidades.APlazo = sheet.FormatDecimalValue(RowNumber, "L", "0.00")
            .DesgloseObligacionesEntidades.EntidadesNoFinancieras = sheet.FormatDecimalValue(RowNumber, "M", "0.00")
            'CUSTOM2020A
            .DesgloseObligacionesEntidades.GastosDifCarteraPropia = sheet.FormatDecimalValue(RowNumber, "N", "0.00")
            .DesgloseObligacionesEntidades.CargosPorPagar = sheet.FormatDecimalValue(RowNumber, "O", "0.00")
            .TotalOblEntidades = .DesgloseObligacionesEntidades.Vista +
                                 .DesgloseObligacionesEntidades.APlazo +
                                 .DesgloseObligacionesEntidades.EntidadesNoFinancieras +
                                 .DesgloseObligacionesEntidades.GastosDifCarteraPropia +
                                 .DesgloseObligacionesEntidades.CargosPorPagar
        End With

        'Cuentas Por Pagar Y Provisiones
        With _BalanceGeneral.Datos.Modelo.Pasivo.CuentasPorPagarYProvisiones
            .DesgloseCuentasPorPagarYProvisiones.DifPosicionDerivados = sheet.FormatDecimalValue(RowNumber, "P", "0.00")
            .DesgloseCuentasPorPagarYProvisiones.CtasComisionesPorPagarDiversas = sheet.FormatDecimalValue(RowNumber, "Q", "0.00")
            .DesgloseCuentasPorPagarYProvisiones.Provisiones = sheet.FormatDecimalValue(RowNumber, "R", "0.00")
            'CUSTOM2020A
            '.DesgloseCuentasPorPagarYProvisiones.CtasPagarServiciosBursatiles = sheet.FormatDecimalValue(RowNumber, "S", "0.00")
            '.DesgloseCuentasPorPagarYProvisiones.BonificacionesPensiones = sheet.FormatDecimalValue(RowNumber, "T", "0.00")
            .DesgloseCuentasPorPagarYProvisiones.RentaDiferido = sheet.FormatDecimalValue(RowNumber, "U", "0.00")
            .DesgloseCuentasPorPagarYProvisiones.CargosPagarDiversos = sheet.FormatDecimalValue(RowNumber, "V", "0.00")
            .DesgloseCuentasPorPagarYProvisiones.OtrasCuentasPorCobrar = sheet.FormatDecimalValue(RowNumber, "W", "0.00")
            .TotalCuentasPagarProv = .DesgloseCuentasPorPagarYProvisiones.DifPosicionDerivados +
                                     .DesgloseCuentasPorPagarYProvisiones.CtasComisionesPorPagarDiversas +
                                     .DesgloseCuentasPorPagarYProvisiones.Provisiones +
                                     .DesgloseCuentasPorPagarYProvisiones.RentaDiferido +
                                     .DesgloseCuentasPorPagarYProvisiones.CargosPagarDiversos +
                                     .DesgloseCuentasPorPagarYProvisiones.OtrasCuentasPorCobrar
        End With


    End Sub
    Private Sub Sheet_5(sheet As IXLWorksheet, RowNumber As Integer)
        'Provisiones Técnicas
        With _BalanceGeneral.Datos.Modelo.Pasivo.ProvisionesTecnicas
            .DesgloseProvisionesTecnicas.ProvisionesPrimasNoDevengadas = sheet.FormatDecimalValue(RowNumber, "A", "0.00")
            .DesgloseProvisionesTecnicas.ProvisionesInsuficienciaPrimas = sheet.FormatDecimalValue(RowNumber, "B", "0.00")
            .DesgloseProvisionesTecnicas.Matematicas = sheet.FormatDecimalValue(RowNumber, "C", "0.00")
            .DesgloseProvisionesTecnicas.ProvisionSiniestrosReportados = sheet.FormatDecimalValue(RowNumber, "D", "0.00")
            .DesgloseProvisionesTecnicas.ProvisionOYNR = sheet.FormatDecimalValue(RowNumber, "E", "0.00")
            .DesgloseProvisionesTecnicas.ProvisionParticipacionEnBeneficiosYExtornos = sheet.FormatDecimalValue(RowNumber, "F", "0.00")
            .DesgloseProvisionesTecnicas.ProvisionSegurosVidaRiesgoInversionAsumeTomador = sheet.FormatDecimalValue(RowNumber, "G", "0.00")
            .DesgloseProvisionesTecnicas.OtrasProvisionesTecnicas = sheet.FormatDecimalValue(RowNumber, "H", "0.00")
            .DesgloseProvisionesTecnicas.RiesgosCatastroficos = sheet.FormatDecimalValue(RowNumber, "I", "0.00")
            .TotalProvTecnicas = .DesgloseProvisionesTecnicas.ProvisionesPrimasNoDevengadas +
                                 .DesgloseProvisionesTecnicas.ProvisionesInsuficienciaPrimas +
                                 .DesgloseProvisionesTecnicas.Matematicas +
                                 .DesgloseProvisionesTecnicas.ProvisionSiniestrosReportados +
                                 .DesgloseProvisionesTecnicas.ProvisionOYNR +
                                 .DesgloseProvisionesTecnicas.ProvisionParticipacionEnBeneficiosYExtornos +
                                 .DesgloseProvisionesTecnicas.ProvisionSegurosVidaRiesgoInversionAsumeTomador +
                                 .DesgloseProvisionesTecnicas.OtrasProvisionesTecnicas +
                                 .DesgloseProvisionesTecnicas.RiesgosCatastroficos
        End With

        'Cuentas Acreedoras Deudoras Operaciones Reaseguro Pasivo
        With _BalanceGeneral.Datos.Modelo.Pasivo.CuentasAcreedorasDeudorasOperacionesReaseguroPasivo
            .DesgloseCuentasAcreedorasDeudorasOperacionesReaseguroPasivo.CuentasAcreedorasDeudorasReaseguroCedidoRetrocedido = sheet.FormatDecimalValue(RowNumber, "J", "0.00")
            .DesgloseCuentasAcreedorasDeudorasOperacionesReaseguroPasivo.CuentasAcreedorasDeudorasReaseguroAceptado = sheet.FormatDecimalValue(RowNumber, "K", "0.00")
            .TotalCuentasAcreedorasDeudorasOperacionesReaseguroPasivo = .DesgloseCuentasAcreedorasDeudorasOperacionesReaseguroPasivo.CuentasAcreedorasDeudorasReaseguroCedidoRetrocedido +
                                                                        .DesgloseCuentasAcreedorasDeudorasOperacionesReaseguroPasivo.CuentasAcreedorasDeudorasReaseguroAceptado
        End With

        'Cuentas Acreedoras Deudoras Operaciones Coaseguro Pasivo
        With _BalanceGeneral.Datos.Modelo.Pasivo.CuentasAcreedorasDeudorasOperacionesCoaseguroPasivo
            .DesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo.CuentaCorrienteOperacionesCoaseguro = sheet.FormatDecimalValue(RowNumber, "L", "0.00")
            .TotalCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo = .DesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo.CuentaCorrienteOperacionesCoaseguro
        End With

        'Asegurados Agentes Intermediarios
        With _BalanceGeneral.Datos.Modelo.Pasivo.AseguradosAgentesIntermediarios
            .DesgloseAseguradosAgentesIntermediarios.Asegurados = sheet.FormatDecimalValue(RowNumber, "M", "0.00")
            .DesgloseAseguradosAgentesIntermediarios.AgentesEIntermediarios = sheet.FormatDecimalValue(RowNumber, "N", "0.00")
            .TotalAsegurados = .DesgloseAseguradosAgentesIntermediarios.Asegurados +
                               .DesgloseAseguradosAgentesIntermediarios.AgentesEIntermediarios
        End With

        'Otros Pasivos
        With _BalanceGeneral.Datos.Modelo.Pasivo.OtrosPasivos
            .DesgloseOtrosPasivos.IngresosDiferidos = sheet.FormatDecimalValue(RowNumber, "O", "0.00")
            'CUSTOM2020A
            '.DesgloseOtrosPasivos.EstimacionDeterioroCreditosContingentes = sheet.FormatDecimalValue(RowNumber, "P", "0.00")
            .DesgloseOtrosPasivos.OperacionesPendientesImputacion = sheet.FormatDecimalValue(RowNumber, "Q", "0.00")
            .DesgloseOtrosPasivos.CtasReciprocasInternas = sheet.FormatDecimalValue(RowNumber, "R", "0.00")
            .DesgloseOtrosPasivos.PasivoPagosValorRazonableInstrumentosPatrimonio = sheet.FormatDecimalValue(RowNumber, "S", "0.00")
            .DesgloseOtrosPasivos.EstimacionPrimasPolizasAbiertasoFlotantes = sheet.FormatDecimalValue(RowNumber, "T", "0.00")
            .DesgloseOtrosPasivos.ComisionPrimasPolizasAbiertasoFlotantes = sheet.FormatDecimalValue(RowNumber, "U", "0.00")
            .DesgloseOtrosPasivos.DepositosRecibidosReaseguro = sheet.FormatDecimalValue(RowNumber, "V", "0.00")
            .TotalOtrosPasivos = .DesgloseOtrosPasivos.IngresosDiferidos +
                                 .DesgloseOtrosPasivos.OperacionesPendientesImputacion +
                                 .DesgloseOtrosPasivos.CtasReciprocasInternas +
                                 .DesgloseOtrosPasivos.PasivoPagosValorRazonableInstrumentosPatrimonio +
                                 .DesgloseOtrosPasivos.EstimacionPrimasPolizasAbiertasoFlotantes +
                                 .DesgloseOtrosPasivos.ComisionPrimasPolizasAbiertasoFlotantes +
                                 .DesgloseOtrosPasivos.DepositosRecibidosReaseguro
        End With
    End Sub
    Private Sub Sheet_6(sheet As IXLWorksheet, RowNumber As Integer)
        'Obligaciones Subordinadas
        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesSubordinadas
            .DesgloseObligacionesSubordinadas.ObligacionesSubordinadas = sheet.FormatDecimalValue(RowNumber, "A", "0.00")
            .DesgloseObligacionesSubordinadas.PrestamosSubordinados = sheet.FormatDecimalValue(RowNumber, "B", "0.00")
            .DesgloseObligacionesSubordinadas.CargosPagar = sheet.FormatDecimalValue(RowNumber, "C", "0.00")
            .TotalOblSubordinadas = .DesgloseObligacionesSubordinadas.ObligacionesSubordinadas +
                                    .DesgloseObligacionesSubordinadas.PrestamosSubordinados +
                                    .DesgloseObligacionesSubordinadas.CargosPagar
        End With

        'Obligaciones Convertibles En Capital
        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesConvertiblesEnCapital
            .DesgloseObligacionesConvertiblesEnCapital.ObligacionesConvertiblesEnCapital = sheet.FormatDecimalValue(RowNumber, "D", "0.00")
            .DesgloseObligacionesConvertiblesEnCapital.CargosPagar = sheet.FormatDecimalValue(RowNumber, "E", "0.00")
            .TotalOblConvertibles = .DesgloseObligacionesConvertiblesEnCapital.ObligacionesConvertiblesEnCapital +
                                    .DesgloseObligacionesConvertiblesEnCapital.CargosPagar
        End With

        'Obligaciones Preferentes
        With _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesPreferentes
            .DesgloseObligacionesPreferentes.ObligacionesPreferentes = sheet.FormatDecimalValue(RowNumber, "F", "0.00")
            .DesgloseObligacionesPreferentes.CargosPagar = sheet.FormatDecimalValue(RowNumber, "G", "0.00")
            .TotalOblPreferentes = .DesgloseObligacionesPreferentes.ObligacionesPreferentes +
                                   .DesgloseObligacionesPreferentes.CargosPagar
        End With

        With _BalanceGeneral.Datos.Modelo.Pasivo
            .TotalPasivo = _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesPublico.TotalOblPublico +
                           _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesEntidades.TotalOblEntidades +
                           _BalanceGeneral.Datos.Modelo.Pasivo.CuentasPorPagarYProvisiones.TotalCuentasPagarProv +
                           _BalanceGeneral.Datos.Modelo.Pasivo.ProvisionesTecnicas.TotalProvTecnicas +
                           _BalanceGeneral.Datos.Modelo.Pasivo.CuentasAcreedorasDeudorasOperacionesReaseguroPasivo.TotalCuentasAcreedorasDeudorasOperacionesReaseguroPasivo +
                           _BalanceGeneral.Datos.Modelo.Pasivo.CuentasAcreedorasDeudorasOperacionesCoaseguroPasivo.TotalCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo +
                           _BalanceGeneral.Datos.Modelo.Pasivo.AseguradosAgentesIntermediarios.TotalAsegurados +
                           _BalanceGeneral.Datos.Modelo.Pasivo.OtrosPasivos.TotalOtrosPasivos +
                           _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesSubordinadas.TotalOblSubordinadas +
                           _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesConvertiblesEnCapital.TotalOblConvertibles +
                           _BalanceGeneral.Datos.Modelo.Pasivo.ObligacionesPreferentes.TotalOblPreferentes

        End With

    End Sub
    Private Sub Sheet_7(sheet As IXLWorksheet, RowNumber As Integer)
        'Capital Social Capital Mínimo Funcionamiento
        With _BalanceGeneral.Datos.Modelo.Patrimonio.CapitalSocialCapitalMinimoFuncionamiento
            .DesgloseCapitalSocialCapitalMinimoFuncionamiento.Pagado = sheet.FormatDecimalValue(RowNumber, "A", "0.00")
            .DesgloseCapitalSocialCapitalMinimoFuncionamiento.Donado = sheet.FormatDecimalValue(RowNumber, "B", "0.00")
            .DesgloseCapitalSocialCapitalMinimoFuncionamiento.SuscritoNoIntegrado = sheet.FormatDecimalValue(RowNumber, "C", "0.00")
            .DesgloseCapitalSocialCapitalMinimoFuncionamiento.SuscripcionesCapitalPorIntegrar = sheet.FormatDecimalValue(RowNumber, "D", "0.00")
            .DesgloseCapitalSocialCapitalMinimoFuncionamiento.AccionesTesoreria = sheet.FormatDecimalValue(RowNumber, "E", "0.00")
            'CUSTOM2020A
            '.DesgloseCapitalSocialCapitalMinimoFuncionamiento.CapitalMunimoFuncionamientoOperadorasPensionesComplementarias = sheet.FormatDecimalValue(RowNumber, "F", "0.00")
            .DesgloseCapitalSocialCapitalMinimoFuncionamiento.CapitalAsignadoSucursales = sheet.FormatDecimalValue(RowNumber, "G", "0.00")
            .TotalCapSocial = .DesgloseCapitalSocialCapitalMinimoFuncionamiento.Pagado +
                              .DesgloseCapitalSocialCapitalMinimoFuncionamiento.Donado +
                              .DesgloseCapitalSocialCapitalMinimoFuncionamiento.SuscritoNoIntegrado +
                              .DesgloseCapitalSocialCapitalMinimoFuncionamiento.SuscripcionesCapitalPorIntegrar +
                              .DesgloseCapitalSocialCapitalMinimoFuncionamiento.AccionesTesoreria +
                              .DesgloseCapitalSocialCapitalMinimoFuncionamiento.CapitalAsignadoSucursales
        End With

        'Aportes Patrimoniales No Capitalizados
        With _BalanceGeneral.Datos.Modelo.Patrimonio.AportesPatrimonialesNoCapitalizados
            .DesgloseAportesPatrimonialesNoCapitalizados.CapitalPagadoAdicional = sheet.FormatDecimalValue(RowNumber, "H", "0.00")
            .DesgloseAportesPatrimonialesNoCapitalizados.ParaIncrementosCapital = sheet.FormatDecimalValue(RowNumber, "I", "0.00")
            'CUSTOM2020A
            '.DesgloseAportesPatrimonialesNoCapitalizados.DonacionesYOtrasContribuciones = sheet.FormatDecimalValue(RowNumber, "J", "0.00")
            '.DesgloseAportesPatrimonialesNoCapitalizados.AportesExcCapMinFunOperPenComp = sheet.FormatDecimalValue(RowNumber, "K", "0.00")
            .DesgloseAportesPatrimonialesNoCapitalizados.ApotMantCapMinObliEntAsegYReasegRevalUDPendCalificar = sheet.FormatDecimalValue(RowNumber, "L", "0.00")
            .DesgloseAportesPatrimonialesNoCapitalizados.ApotMantCapMinObliEntAsegYReasegRevalUDPendCalificarSucursales = sheet.FormatDecimalValue(RowNumber, "M", "0.00")
            .TotalApoPatrimoniales = .DesgloseAportesPatrimonialesNoCapitalizados.CapitalPagadoAdicional +
                                     .DesgloseAportesPatrimonialesNoCapitalizados.ParaIncrementosCapital +
                                     .DesgloseAportesPatrimonialesNoCapitalizados.ApotMantCapMinObliEntAsegYReasegRevalUDPendCalificar +
                                     .DesgloseAportesPatrimonialesNoCapitalizados.ApotMantCapMinObliEntAsegYReasegRevalUDPendCalificarSucursales
        End With

        'CUSTOM2020A
        'Ajustes Al Patrimonio
        With _BalanceGeneral.Datos.Modelo.Patrimonio.AjustesPatrimonioResultadoIntegral
            .DesgloseAjustesPatrimonioResultadoIntegral.AlValorActivos = sheet.FormatDecimalValue(RowNumber, "N", "0.00")
            .DesgloseAjustesPatrimonioResultadoIntegral.ValoracionParticipacionesOtrasEmpresas = sheet.FormatDecimalValue(RowNumber, "O", "0.00")
            .DesgloseAjustesPatrimonioResultadoIntegral.ConversionEstadosFinancieros = sheet.FormatDecimalValue(RowNumber, "P", "0.00")
            .TotalAjustesPatrimonioResultadoIntegral = .DesgloseAjustesPatrimonioResultadoIntegral.AlValorActivos +
                                                      .DesgloseAjustesPatrimonioResultadoIntegral.ValoracionParticipacionesOtrasEmpresas +
                                                      .DesgloseAjustesPatrimonioResultadoIntegral.ConversionEstadosFinancieros
        End With


    End Sub
    Private Sub Sheet_8(sheet As IXLWorksheet, RowNumber As Integer)

        'CUSTOM2020A
        'Reservas Patrimoniales
        With _BalanceGeneral.Datos.Modelo.Patrimonio.Reservas
            .DesgloseReservas.Legal = sheet.FormatDecimalValue(RowNumber, "A", "0.00")
            .DesgloseReservas.OtrasObligatorias = sheet.FormatDecimalValue(RowNumber, "B", "0.00")
            .DesgloseReservas.Voluntarias = sheet.FormatDecimalValue(RowNumber, "C", "0.00")
            .DesgloseReservas.ReservaNiveladoraAcumulada = sheet.FormatDecimalValue(RowNumber, "D", "0.00")
            .DesgloseReservas.ReservasRegulatorias = sheet.FormatDecimalValue(RowNumber, "E", "0.00")
            .TotalReservas = .DesgloseReservas.Legal +
                                     .DesgloseReservas.OtrasObligatorias +
                                     .DesgloseReservas.Voluntarias +
                                     .DesgloseReservas.ReservaNiveladoraAcumulada +
                                     .DesgloseReservas.ReservasRegulatorias
        End With

        'Resultados Acumulados Ejercicios Anteriores
        With _BalanceGeneral.Datos.Modelo.Patrimonio.ResultadosAcumuladosEjerciciosAnteriores
            .DesgloseResultadosAcumuladosEjerciciosAnteriores.UtilidadesAcumuladas = sheet.FormatDecimalValue(RowNumber, "F", "0.00")
            .DesgloseResultadosAcumuladosEjerciciosAnteriores.PerdidasAcumuladas = sheet.FormatDecimalValue(RowNumber, "G", "0.00")
            .TotalResAcumulados = .DesgloseResultadosAcumuladosEjerciciosAnteriores.UtilidadesAcumuladas +
                                  .DesgloseResultadosAcumuladosEjerciciosAnteriores.PerdidasAcumuladas
        End With

        'Resultados Periodo
        With _BalanceGeneral.Datos.Modelo.Patrimonio.ResultadosPeriodo
            .DesgloseResultadosPeriodo.UtilidadNeta = sheet.FormatDecimalValue(RowNumber, "H", "0.00")
            .DesgloseResultadosPeriodo.PerdidaNeta = sheet.FormatDecimalValue(RowNumber, "I", "0.00")
            .DesgloseResultadosPeriodo.ReservaNiveladoraPeriodo = sheet.FormatDecimalValue(RowNumber, "J", "0.00")
            .TotalResPeriodo = .DesgloseResultadosPeriodo.UtilidadNeta +
                               .DesgloseResultadosPeriodo.PerdidaNeta +
                               .DesgloseResultadosPeriodo.ReservaNiveladoraPeriodo
        End With

        'CUSTOM2020A
        'Interés Minoritario
        With _BalanceGeneral.Datos.Modelo.Patrimonio.ParticipacionesNoControladas
            .DesgloseParticipacionesNoControladas.ParticipacionesNoControladas = sheet.FormatDecimalValue(RowNumber, "K", "0.00")
            .TotalParticipacionesNoControladas = .DesgloseParticipacionesNoControladas.ParticipacionesNoControladas
        End With

        'Patrimonio Fondo Financiamiento Desarrollo
        With _BalanceGeneral.Datos.Modelo.Patrimonio.PatrimonioEnFondoOReservasEspeciales
            .DesglosePatrimonioEnFondoOReservasEspeciales.FondosEspeciales = sheet.FormatDecimalValue(RowNumber, "L", "0.00")
            .DesglosePatrimonioEnFondoOReservasEspeciales.ReservasEspeciales = sheet.FormatDecimalValue(RowNumber, "M", "0.00")
            .TotalPatrimonioEnFondoOReservasEspeciales = .DesglosePatrimonioEnFondoOReservasEspeciales.FondosEspeciales +
                                                         .DesglosePatrimonioEnFondoOReservasEspeciales.ReservasEspeciales
        End With

        With _BalanceGeneral.Datos.Modelo.Patrimonio
            .TotalPatrimonio = _BalanceGeneral.Datos.Modelo.Patrimonio.CapitalSocialCapitalMinimoFuncionamiento.TotalCapSocial +
                               _BalanceGeneral.Datos.Modelo.Patrimonio.AportesPatrimonialesNoCapitalizados.TotalApoPatrimoniales +
                               _BalanceGeneral.Datos.Modelo.Patrimonio.AjustesPatrimonioResultadoIntegral.TotalAjustesPatrimonioResultadoIntegral +
                               _BalanceGeneral.Datos.Modelo.Patrimonio.Reservas.TotalReservas +
                               _BalanceGeneral.Datos.Modelo.Patrimonio.ResultadosAcumuladosEjerciciosAnteriores.TotalResAcumulados +
                               _BalanceGeneral.Datos.Modelo.Patrimonio.ResultadosPeriodo.TotalResPeriodo +
                               _BalanceGeneral.Datos.Modelo.Patrimonio.ParticipacionesNoControladas.TotalParticipacionesNoControladas +
                               _BalanceGeneral.Datos.Modelo.Patrimonio.PatrimonioEnFondoOReservasEspeciales.TotalPatrimonioEnFondoOReservasEspeciales

        End With

        With _BalanceGeneral.Datos.Modelo.PasivoMasPatrimonio
            .TotalPasivoMasPatrimonio = _BalanceGeneral.Datos.Modelo.Pasivo.TotalPasivo +
                                        _BalanceGeneral.Datos.Modelo.Patrimonio.TotalPatrimonio
        End With

    End Sub


End Class