Imports System.Configuration
Imports Architect.Sugese.Utility
Imports Architect.Sugese.Utility.Helpers
Imports Architect.Utilities.Extensions
Imports ClosedXML.Excel

Public Class Generate

    Private _Canales As New Canales.ModeloCanales

    Public Property Response As DataTable

#Region "Builder"

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="periodo">Fecha correspondiente al período al cual corresponde el modelo</param>
    ''' <param name="periodicidad">Corresponde a la periodicidad del modelo</param>
    ''' <remarks></remarks>
    Public Sub New(periodo As Date, periodicidad As Canales.Periodicidad)
        ModelInit()
        With _Canales.Encabezado
            .NombreArchivo = String.Format("{0}-ModeloCanales", ConfigurationManager.AppSettings("sugese.entidadaseguradora"))
            .Fecha = Today.ToString("yyyy-MM-dd")
            .Periodo = periodo.ToString("yyyy-MM-dd")
            .Periodicidad = periodicidad
            .Moneda = 1 'String.Empty
        End With
        _Canales.Datos.Modelo.EntidadFuente = ConfigurationManager.AppSettings("sugese.codigoaseguradora")
        Me.Response = XmlRespose.ReponseDataTable
    End Sub

    Private Sub ModelInit()
        _Canales = New ModeloCanales
        With _Canales
            .Encabezado = New ModeloCanalesEncabezado
            .Datos = New ModeloCanalesDatos
        End With
        With _Canales.Encabezado
            .NombreArchivo = String.Empty
            .Fecha = String.Empty
            .Periodo = String.Empty
            .Periodicidad = Periodicidad.T
            .Moneda = String.Empty
        End With

        With _Canales.Datos
            .Modelo = New ModeloCanalesDatosModelo
        End With
        With _Canales.Datos.Modelo
            .PolizasContratadasSegPersonales = New ModeloCanalesDatosModeloPolizasContratadasSegPersonales
            .PolizasContratadasSegGenerales = New ModeloCanalesDatosModeloPolizasContratadasSegGenerales
            .PrimasPolizasContratadasSegPersonales = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonales
            .PrimasPolizasContratadasSegGenerales = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGenerales
            .PolizasContratadasNuevaProduccionSegPersonales = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonales
            .PolizasContratadasNuevaProduccionSegGenerales = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGenerales
            .PrimasPolizasContratadasSegPersonalesNuevaProduccion = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccion
            .PrimasPolizasContratadasSegGeneralesNuevaProduccion = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccion
            '.OficinasAseguradoraNuevaProd(0) = New ModeloCanalesDatosModeloDetalleOficina
            .AgenSegNoVinculadosSocAgenSeg = New ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSeg
            .SociedadesCorredorasSeg = New ModeloCanalesDatosModeloSociedadesCorredorasSeg
            .SeguroObligatorioAutomoviles = New ModeloCanalesDatosModeloSeguroObligatorioAutomoviles
            .EntidadFuente = String.Empty
        End With
        With _Canales.Datos.Modelo.PolizasContratadasSegPersonales
            .DesglosePolizasContratadasSegPersonales = New ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonales
            .TotalPolSegPersonales = String.Empty
        End With
        With _Canales.Datos.Modelo.PolizasContratadasSegPersonales.DesglosePolizasContratadasSegPersonales
            '.RamoPolizasContratadasSegPersonales(0) = New ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonales
            .TotalAgenSegNoVinculadoExclusivo = String.Empty
            .TotalAgenSegNoVinculadosNoExclusivo = String.Empty
            .TotalSocAgenSegExclusiva = String.Empty
            .TotalSocAgenSegNoExclusiva = String.Empty
            .TotalSocCorredoraSeg = String.Empty
            .TotalOperSegAutoexpedibleExclusivo = String.Empty
            .TotalOperSegAutoexpedibleNoExclusivo = String.Empty
            .TotalProveTransfronterizosSeg = String.Empty
            .TotalOfiEntAseguradora = String.Empty
        End With

        With _Canales.Datos.Modelo.PolizasContratadasSegGenerales
            .DesglosePolizasContratadasSegGenerales = New ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGenerales
            .TotalPolSegGenerales = String.Empty
        End With
        With _Canales.Datos.Modelo.PolizasContratadasSegGenerales.DesglosePolizasContratadasSegGenerales
            '.RamoPolizasContratadasSegGenerales(0) = New ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGenerales
            .TotalAgenSegNoVinculadoExclusivo = String.Empty
            .TotalAgenSegNoVinculadosNoExclusivo = String.Empty
            .TotalSocAgenSegExclusiva = String.Empty
            .TotalSocAgenSegNoExclusiva = String.Empty
            .TotalSocCorredoraSeg = String.Empty
            .TotalOperSegAutoexpedibleExclusivo = String.Empty
            .TotalOperSegAutoexpedibleNoExclusivo = String.Empty
            .TotalProveTransfronterizosSeg = String.Empty
            .TotalOfiEntAseguradora = String.Empty
        End With

        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonales
            .DesglosePrimasPolizasContratadasSegPersonales = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonales
            .TotalPriSegPersonales = 0
        End With
        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonales.DesglosePrimasPolizasContratadasSegPersonales
            '.RamoPrimasPolizasContratadasSegPersonales(0) = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonales
            .TotalAgenSegNoVinculadoExclusivo = 0
            .TotalAgenSegNoVinculadosNoExclusivo = 0
            .TotalSocAgenSegExclusiva = 0
            .TotalSocAgenSegNoExclusiva = 0
            .TotalSocCorredoraSeg = 0
            .TotalOperSegAutoexpedibleExclusivo = 0
            .TotalOperSegAutoexpedibleNoExclusivo = 0
            .TotalProveTransfronterizosSeg = 0
            .TotalOfiEntAseguradora = 0
        End With

        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegGenerales
            .DesglosePrimasPolizasContratadasSegGenerales = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGenerales
            .TotalPriSegGenerales = 0
        End With
        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegGenerales.DesglosePrimasPolizasContratadasSegGenerales
            '.RamoPrimasPolizasContratadasSegGenerales(0) = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGenerales
            .TotalAgenSegNoVinculadoExclusivo = 0
            .TotalAgenSegNoVinculadosNoExclusivo = 0
            .TotalSocAgenSegExclusiva = 0
            .TotalSocAgenSegNoExclusiva = 0
            .TotalSocCorredoraSeg = 0
            .TotalOperSegAutoexpedibleExclusivo = 0
            .TotalOperSegAutoexpedibleNoExclusivo = 0
            .TotalProveTransfronterizosSeg = 0
            .TotalOfiEntAseguradora = 0
        End With

        With _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegPersonales
            .DesglosePolizasContratadasNuevaProduccionSegPersonales = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonales
            .TotalPolSegPersonales = String.Empty
        End With
        With _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegPersonales.DesglosePolizasContratadasNuevaProduccionSegPersonales
            '.RamoPolizasContratadasNuevaProduccionSegPersonales(0) = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonales
            .TotalAgenSegNoVinculadoExclusivo = String.Empty
            .TotalAgenSegNoVinculadosNoExclusivo = String.Empty
            .TotalSocAgenSegExclusiva = String.Empty
            .TotalSocAgenSegNoExclusiva = String.Empty
            .TotalSocCorredoraSeg = String.Empty
            .TotalOperSegAutoexpedibleExclusivo = String.Empty
            .TotalOperSegAutoexpedibleNoExclusivo = String.Empty
            .TotalProveTransfronterizosSeg = String.Empty
            .TotalOfiEntAseguradora = String.Empty
        End With

        With _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegGenerales
            .DesglosePolizasContratadasNuevaProduccionSegGenerales = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGenerales
            .TotalPolSegGenerales = String.Empty
        End With
        With _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegGenerales.DesglosePolizasContratadasNuevaProduccionSegGenerales
            '.RamoPolizasContratadasNuevaProduccionSegGenerales(0) = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGenerales
            .TotalAgenSegNoVinculadoExclusivo = String.Empty
            .TotalAgenSegNoVinculadosNoExclusivo = String.Empty
            .TotalSocAgenSegExclusiva = String.Empty
            .TotalSocAgenSegNoExclusiva = String.Empty
            .TotalSocCorredoraSeg = String.Empty
            .TotalOperSegAutoexpedibleExclusivo = String.Empty
            .TotalOperSegAutoexpedibleNoExclusivo = String.Empty
            .TotalProveTransfronterizosSeg = String.Empty
            .TotalOfiEntAseguradora = String.Empty
        End With

        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonalesNuevaProduccion
            .DesglosePrimasPolizasContratadasSegPersonalesNuevaProduccion = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccion
            .TotalPriSegPersonales = 0
        End With
        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonalesNuevaProduccion.DesglosePrimasPolizasContratadasSegPersonalesNuevaProduccion
            '.RamoPrimasPolizasContratadasSegPersonalesNuevaProduccion(0) = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccion
            .TotalAgenSegNoVinculadoExclusivo = 0
            .TotalAgenSegNoVinculadosNoExclusivo = 0
            .TotalSocAgenSegExclusiva = 0
            .TotalSocAgenSegNoExclusiva = 0
            .TotalSocCorredoraSeg = 0
            .TotalOperSegAutoexpedibleExclusivo = 0
            .TotalOperSegAutoexpedibleNoExclusivo = 0
            .TotalProveTransfronterizosSeg = 0
            .TotalOfiEntAseguradora = 0
        End With

        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegGeneralesNuevaProduccion
            .DesglosePrimasPolizasContratadasSegGeneralesNuevaProduccion = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccion
            .TotalPriSegGenerales = 0
        End With
        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegGeneralesNuevaProduccion.DesglosePrimasPolizasContratadasSegGeneralesNuevaProduccion
            '.RamoPrimasPolizasContratadasSegGeneralesNuevaProduccion(0) = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccion
            .TotalAgenSegNoVinculadoExclusivo = 0
            .TotalAgenSegNoVinculadosNoExclusivo = 0
            .TotalSocAgenSegExclusiva = 0
            .TotalSocAgenSegNoExclusiva = 0
            .TotalSocCorredoraSeg = 0
            .TotalOperSegAutoexpedibleExclusivo = 0
            .TotalOperSegAutoexpedibleNoExclusivo = 0
            .TotalProveTransfronterizosSeg = 0
            .TotalOfiEntAseguradora = 0
        End With

        With _Canales.Datos.Modelo.AgenSegNoVinculadosSocAgenSeg
            .NumContratosAgenciasCierreAnno = New ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumContratosAgenciasCierreAnno
            .NumAgenSocAportaronDuranteAnno = New ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumAgenSocAportaronDuranteAnno
        End With
        With _Canales.Datos.Modelo.AgenSegNoVinculadosSocAgenSeg.NumContratosAgenciasCierreAnno
            .DesgloseNumContratosAgenciasCierreAnno = New ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumContratosAgenciasCierreAnnoDesgloseNumContratosAgenciasCierreAnno
            .Total = String.Empty
        End With
        With _Canales.Datos.Modelo.AgenSegNoVinculadosSocAgenSeg.NumContratosAgenciasCierreAnno.DesgloseNumContratosAgenciasCierreAnno
            .AgenSegNoVinculadosExclusivos = String.Empty
            .AgenSegNoVinculadosNoExclusivos = String.Empty
            .SocAgenSegExclusiva = String.Empty
            .SocAgenSegNoExclusiva = String.Empty
        End With

        With _Canales.Datos.Modelo.AgenSegNoVinculadosSocAgenSeg.NumAgenSocAportaronDuranteAnno
            .DesgloseNumAgenSocAportaronDuranteAnno = New ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumAgenSocAportaronDuranteAnnoDesgloseNumAgenSocAportaronDuranteAnno
            .Total = String.Empty
        End With
        With _Canales.Datos.Modelo.AgenSegNoVinculadosSocAgenSeg.NumAgenSocAportaronDuranteAnno.DesgloseNumAgenSocAportaronDuranteAnno
            .AgenSegNoVinculadosExclusivos = String.Empty
            .AgenSegNoVinculadosNoExclusivos = String.Empty
            .SocAgenSegExclusiva = String.Empty
            .SocAgenSegNoExclusiva = String.Empty
        End With

        With _Canales.Datos.Modelo.SociedadesCorredorasSeg
            '.DetalleSocCorredora(0) = New ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredora
            .NumSociedadesIncorporadas = String.Empty
        End With

        With _Canales.Datos.Modelo.SeguroObligatorioAutomoviles
            .PolizasPagadas = New ModeloCanalesDatosModeloSeguroObligatorioAutomovilesPolizasPagadas
            .MontoPrima = New ModeloCanalesDatosModeloSeguroObligatorioAutomovilesMontoPrima
        End With
        With _Canales.Datos.Modelo.SeguroObligatorioAutomoviles.PolizasPagadas
            .BancosPublicos = New System.Nullable(Of System.Decimal)
            .BancosPrivados = New System.Nullable(Of System.Decimal)
            .Cooperativas = New System.Nullable(Of System.Decimal)
            .OtrasPersonasFisicas = New System.Nullable(Of System.Decimal)
            .OtrasPersonasJuridicas = New System.Nullable(Of System.Decimal)
        End With

        With _Canales.Datos.Modelo.SeguroObligatorioAutomoviles.MontoPrima
            .BancosPublicos = New System.Nullable(Of System.Decimal)
            .BancosPrivados = New System.Nullable(Of System.Decimal)
            .Cooperativas = New System.Nullable(Of System.Decimal)
            .OtrasPersonasFisicas = New System.Nullable(Of System.Decimal)
            .OtrasPersonasJuridicas = New System.Nullable(Of System.Decimal)
        End With

    End Sub

    Public Shared Function AddRamoPolizasContratadasSegPersonales(items As ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonales()) As ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonales
        Dim result As New ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonales
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .PolizasContratadasSegPersonalesPorRamo = New ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonalesPolizasContratadasSegPersonalesPorRamo
            .id = TipoRamoPersonales.P14
        End With
        With result.PolizasContratadasSegPersonalesPorRamo
            .DesglosePolizasContratadasSegPersonalesPorRamo = New ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonalesPolizasContratadasSegPersonalesPorRamoDesglosePolizasContratadasSegPersonalesPorRamo
            .Total = String.Empty
        End With
        With result.PolizasContratadasSegPersonalesPorRamo.DesglosePolizasContratadasSegPersonalesPorRamo
            .AgenSegNoVinculadoExclusivo = String.Empty
            .AgenSegNoVinculadosNoExclusivo = String.Empty
            .SocAgenSegExclusiva = String.Empty
            .SocAgenSegNoExclusiva = String.Empty
            .SocCorredoraSeg = String.Empty
            .OperSegAutoexpedibleExclusivo = String.Empty
            .OperSegAutoexpedibleNoExclusivo = String.Empty
            .ProveTransfronterizosSeg = String.Empty
            .OfiEntAseguradora = String.Empty
        End With

        Return result
    End Function

    Public Shared Function AddRamoPolizasContratadasSegGenerales(items As ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGenerales()) As ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGenerales
        Dim result As New ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGenerales
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .PolizasContratadasSegGeneralesPorRamo = New ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGeneralesPolizasContratadasSegGeneralesPorRamo
            .id = TipoRamoGenerales.G01
        End With
        With result.PolizasContratadasSegGeneralesPorRamo
            .DesglosePolizasContratadasSegGeneralesPorRamo = New ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGeneralesPolizasContratadasSegGeneralesPorRamoDesglosePolizasContratadasSegGeneralesPorRamo
            .Total = String.Empty
        End With
        With result.PolizasContratadasSegGeneralesPorRamo.DesglosePolizasContratadasSegGeneralesPorRamo
            .AgenSegNoVinculadoExclusivo = String.Empty
            .AgenSegNoVinculadosNoExclusivo = String.Empty
            .SocAgenSegExclusiva = String.Empty
            .SocAgenSegNoExclusiva = String.Empty
            .SocCorredoraSeg = String.Empty
            .OperSegAutoexpedibleExclusivo = String.Empty
            .OperSegAutoexpedibleNoExclusivo = String.Empty
            .ProveTransfronterizosSeg = String.Empty
            .OfiEntAseguradora = String.Empty
        End With

        Return result
    End Function

    Public Shared Function AddRamoPrimasPolizasContratadasSegPersonales(items As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonales()) As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonales
        Dim result As New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonales
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .PrimasPolizasContratadasSegPersonalesPorRamo = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonalesPrimasPolizasContratadasSegPersonalesPorRamo
            .id = TipoRamoPersonales.P14
        End With
        With result.PrimasPolizasContratadasSegPersonalesPorRamo
            .DesglosePrimasPolizasContratadasSegPersonalesPorRamo = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonalesPrimasPolizasContratadasSegPersonalesPorRamoDesglosePrimasPolizasContratadasSegPersonalesPorRamo
            .Total = 0
        End With
        With result.PrimasPolizasContratadasSegPersonalesPorRamo.DesglosePrimasPolizasContratadasSegPersonalesPorRamo
            .AgenSegNoVinculadoExclusivo = 0
            .AgenSegNoVinculadosNoExclusivo = 0
            .SocAgenSegExclusiva = 0
            .SocAgenSegNoExclusiva = 0
            .SocCorredoraSeg = 0
            .OperSegAutoexpedibleExclusivo = 0
            .OperSegAutoexpedibleNoExclusivo = 0
            .ProveTransfronterizosSeg = 0
            .OfiEntAseguradora = 0
        End With

        Return result
    End Function

    Public Shared Function AddRamoPrimasPolizasContratadasSegGenerales(items As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGenerales()) As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGenerales
        Dim result As New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGenerales
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .PrimasPolizasContratadasSegGeneralesPorRamo = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGeneralesPrimasPolizasContratadasSegGeneralesPorRamo
            .id = TipoRamoGenerales.G01
        End With
        With result.PrimasPolizasContratadasSegGeneralesPorRamo
            .DesglosePrimasPolizasContratadasSegGeneralesPorRamo = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGeneralesPrimasPolizasContratadasSegGeneralesPorRamoDesglosePrimasPolizasContratadasSegGeneralesPorRamo
            .Total = 0
        End With
        With result.PrimasPolizasContratadasSegGeneralesPorRamo.DesglosePrimasPolizasContratadasSegGeneralesPorRamo
            .AgenSegNoVinculadoExclusivo = 0
            .AgenSegNoVinculadosNoExclusivo = 0
            .SocAgenSegExclusiva = 0
            .SocAgenSegNoExclusiva = 0
            .SocCorredoraSeg = 0
            .OperSegAutoexpedibleExclusivo = 0
            .OperSegAutoexpedibleNoExclusivo = 0
            .ProveTransfronterizosSeg = 0
            .OfiEntAseguradora = 0
        End With

        Return result
    End Function

    Public Shared Function AddRamoPolizasContratadasNuevaProduccionSegPersonales(items As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonales()) As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonales
        Dim result As New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonales
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .PolizasContratadasNuevaProduccionSegPersonalesPorRamo = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonalesPolizasContratadasNuevaProduccionSegPersonalesPorRamo
            .id = TipoRamoPersonales.P14
        End With
        With result.PolizasContratadasNuevaProduccionSegPersonalesPorRamo
            .DesglosePolizasContratadasNuevaProduccionSegPersonalesPorRamo = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonalesPolizasContratadasNuevaProduccionSegPersonalesPorRamoDesglosePolizasContratadasNuevaProduccionSegPersonalesPorRamo
            .Total = String.Empty
        End With
        With result.PolizasContratadasNuevaProduccionSegPersonalesPorRamo.DesglosePolizasContratadasNuevaProduccionSegPersonalesPorRamo
            .AgenSegNoVinculadoExclusivo = String.Empty
            .AgenSegNoVinculadosNoExclusivo = String.Empty
            .SocAgenSegExclusiva = String.Empty
            .SocAgenSegNoExclusiva = String.Empty
            .SocCorredoraSeg = String.Empty
            .OperSegAutoexpedibleExclusivo = String.Empty
            .OperSegAutoexpedibleNoExclusivo = String.Empty
            .ProveTransfronterizosSeg = String.Empty
            .OfiEntAseguradora = String.Empty
        End With

        Return result
    End Function

    Public Shared Function AddRamoPolizasContratadasNuevaProduccionSegGenerales(items As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGenerales()) As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGenerales
        Dim result As New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGenerales
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .PolizasContratadasNuevaProduccionSegGeneralesPorRamo = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGeneralesPolizasContratadasNuevaProduccionSegGeneralesPorRamo
            .id = TipoRamoGenerales.G01
        End With
        With result.PolizasContratadasNuevaProduccionSegGeneralesPorRamo
            .DesglosePolizasContratadasNuevaProduccionSegGeneralesPorRamo = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGeneralesPolizasContratadasNuevaProduccionSegGeneralesPorRamoDesglosePolizasContratadasNuevaProduccionSegGeneralesPorRamo
            .Total = String.Empty
        End With
        With result.PolizasContratadasNuevaProduccionSegGeneralesPorRamo.DesglosePolizasContratadasNuevaProduccionSegGeneralesPorRamo
            .AgenSegNoVinculadoExclusivo = String.Empty
            .AgenSegNoVinculadosNoExclusivo = String.Empty
            .SocAgenSegExclusiva = String.Empty
            .SocAgenSegNoExclusiva = String.Empty
            .SocCorredoraSeg = String.Empty
            .OperSegAutoexpedibleExclusivo = String.Empty
            .OperSegAutoexpedibleNoExclusivo = String.Empty
            .ProveTransfronterizosSeg = String.Empty
            .OfiEntAseguradora = String.Empty
        End With

        Return result
    End Function

    Public Shared Function AddRamoPrimasPolizasContratadasSegPersonalesNuevaProduccion(items As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccion()) As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccion
        Dim result As New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccion
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .PrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccionPrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo
            .id = TipoRamoPersonales.P14
        End With
        With result.PrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo
            .DesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccionPrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamoDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo
            .Total = 0
        End With
        With result.PrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo.DesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo
            .AgenSegNoVinculadoExclusivo = 0
            .AgenSegNoVinculadosNoExclusivo = 0
            .SocAgenSegExclusiva = 0
            .SocAgenSegNoExclusiva = 0
            .SocCorredoraSeg = 0
            .OperSegAutoexpedibleExclusivo = 0
            .OperSegAutoexpedibleNoExclusivo = 0
            .ProveTransfronterizosSeg = 0
            .OfiEntAseguradora = 0
        End With

        Return result
    End Function

    Public Shared Function AddRamoPrimasPolizasContratadasSegGeneralesNuevaProduccion(items As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccion()) As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccion
        Dim result As New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccion
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .PrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccionPrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo
            .id = TipoRamoGenerales.G01
        End With
        With result.PrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo
            .DesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccionPrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamoDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo
            .Total = 0
        End With
        With result.PrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo.DesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo
            .AgenSegNoVinculadoExclusivo = 0
            .AgenSegNoVinculadosNoExclusivo = 0
            .SocAgenSegExclusiva = 0
            .SocAgenSegNoExclusiva = 0
            .SocCorredoraSeg = 0
            .OperSegAutoexpedibleExclusivo = 0
            .OperSegAutoexpedibleNoExclusivo = 0
            .ProveTransfronterizosSeg = 0
            .OfiEntAseguradora = 0
        End With

        Return result
    End Function

    Public Shared Function AddOficinasAseguradoraNuevaProd(items As ModeloCanalesDatosModeloDetalleOficina()) As ModeloCanalesDatosModeloDetalleOficina
        Dim result As New ModeloCanalesDatosModeloDetalleOficina
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .Domicilio = Canton.Item101
            .NumEmpleados = String.Empty
            .PrimasPolizasContratadasNuevaProd = 0
        End With

        Return result
    End Function

    Public Shared Function AddDetalleSocCorredora(items As ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredora()) As ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredora
        Dim result As New ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredora
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .DenominacionSoc = String.Empty
            .CodAutorizacion = String.Empty
        End With

        Return result
    End Function

    Public Function Serialize(withFormat As Boolean) As String
        Return Utilities.SerializeHandler(Of Canales.ModeloCanales).Serialize(_Canales, withFormat)
    End Function

    Public Sub FileSerialize(filename As String, withFormat As Boolean)
        Utilities.SerializeHandler(Of Canales.ModeloCanales).SerializeToFile(_Canales, filename, withFormat)

        Dim result As List(Of String) = Nothing
        result = Validate.XsdValidate("ModeloCanales", filename)
        If result.Count > 0 Then
            For Each item As String In result
                XmlRespose.AddError(Response, "error", item)
            Next
        End If

    End Sub

    Private Shared Function MontoDecimal(value As Decimal) As String
        Return value.ToString("0.00", New System.Globalization.CultureInfo("en-US", False))
    End Function

    Private Shared Function MontoDecimalOptionalFormat(value As Object, defvalue As Object) As String
        If IsNothing(value) OrElse String.IsNullOrEmpty(value) Then
            If IsNothing(defvalue) OrElse String.IsNullOrEmpty(defvalue) Then
                Return Nothing
            Else
                Return Convert.ToDecimal(defvalue).ToString("0.00", New System.Globalization.CultureInfo("en-US", False))
            End If
        Else
            Return Convert.ToDecimal(value).ToString("0.00", New System.Globalization.CultureInfo("en-US", False))
        End If
    End Function

    Private Shared Function MontoEnteroOptionalFormat(value As Object) As String
        If IsNothing(value) OrElse String.IsNullOrEmpty(value) Then
            Return Nothing
        Else
            Return Convert.ToDecimal(value).ToString("0", New System.Globalization.CultureInfo("en-US", False))
        End If
    End Function

    Private Shared Function MontoOptionalFormat(value As Object) As String
        If IsNothing(value) OrElse String.IsNullOrEmpty(value) Then
            Return Nothing
        Else
            Return MontoFormat(value)
        End If
    End Function

    Private Shared Function MontoFormat(value As Decimal) As String
        If Convert.ToInt64(value) = value Then
            Return value.ToString("0", New System.Globalization.CultureInfo("en-US", False))
        Else
            Return value.ToString("0.00", New System.Globalization.CultureInfo("en-US", False))
        End If
    End Function

#End Region

    Public Sub LoadExcelInformation(excelFilename As String)
        Dim workbook As New XLWorkbook(excelFilename)
        Dim sheet As IXLWorksheet = Nothing

        'Parte I
        sheet = workbook.Worksheet("Parte I")

        PolizasContratadasSegPersonales(sheet)
        PolizasContratadasSegGenerales(sheet)
        PrimasPolizasContratadasSegPersonales(sheet)
        PrimasPolizasContratadasSegGenerales(sheet)

        PolizasContratadasNuevaProduccionSegPersonales(sheet)
        PolizasContratadasNuevaProduccionSegGenerales(sheet)
        PrimasPolizasContratadasSegPersonalesNuevaProduccion(sheet)
        PrimasPolizasContratadasSegGeneralesNuevaProduccion(sheet)

        'Parte II
        sheet = workbook.Worksheet("Parte II")

        OficinasAseguradoraNuevaProd(sheet)
        NumContratosAgenciasCierreAnno(sheet)
        NumAgenSocAportaronDuranteAnno(sheet)
        SociedadesCorredorasSeg(sheet)
        PolizasPagadas(sheet)
        MontoPrima(sheet)

        sheet = Nothing
        workbook = Nothing
    End Sub

#Region "Parte I"

    Private Sub PolizasContratadasSegPersonales(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonalesPolizasContratadasSegPersonalesPorRamoDesglosePolizasContratadasSegPersonalesPorRamo
        Dim preitem As ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonales
        Dim TotalAgenSegNoVinculadoExclusivo As Decimal = 0
        Dim TotalAgenSegNoVinculadosNoExclusivo As Decimal = 0
        Dim TotalSocAgenSegExclusiva As Decimal = 0
        Dim TotalSocAgenSegNoExclusiva As Decimal = 0
        Dim TotalSocCorredoraSeg As Decimal = 0
        Dim TotalOperSegAutoexpedibleExclusivo As Decimal = 0
        Dim TotalOperSegAutoexpedibleNoExclusivo As Decimal = 0
        Dim TotalProveTransfronterizosSeg As Decimal = 0
        Dim TotalOfiEntAseguradora As Decimal = 0
        Dim Total As Decimal = 0

        For RowNumber As Integer = 2 To 1000
            Try
                value = sheet.Cell(RowNumber, 1).Value
                If value.IsNotEmpty AndAlso value.Equals("Polizas Contratadas Seg Personales", StringComparison.CurrentCultureIgnoreCase) Then
                    item = New ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonalesPolizasContratadasSegPersonalesPorRamoDesglosePolizasContratadasSegPersonalesPorRamo
                    If _Canales.Datos.Modelo.PolizasContratadasSegPersonales.DesglosePolizasContratadasSegPersonales.RamoPolizasContratadasSegPersonales.IsEmpty Then
                        ReDim Preserve _Canales.Datos.Modelo.PolizasContratadasSegPersonales.DesglosePolizasContratadasSegPersonales.RamoPolizasContratadasSegPersonales(0)
                    Else
                        ReDim Preserve _Canales.Datos.Modelo.PolizasContratadasSegPersonales.DesglosePolizasContratadasSegPersonales.RamoPolizasContratadasSegPersonales(UBound(_Canales.Datos.Modelo.PolizasContratadasSegPersonales.DesglosePolizasContratadasSegPersonales.RamoPolizasContratadasSegPersonales) + 1)
                    End If
                    preitem = New ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonales
                    preitem.PolizasContratadasSegPersonalesPorRamo = New ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonalesPolizasContratadasSegPersonalesPorRamo
                    preitem.PolizasContratadasSegPersonalesPorRamo.DesglosePolizasContratadasSegPersonalesPorRamo = item
                    _Canales.Datos.Modelo.PolizasContratadasSegPersonales.DesglosePolizasContratadasSegPersonales.RamoPolizasContratadasSegPersonales(UBound(_Canales.Datos.Modelo.PolizasContratadasSegPersonales.DesglosePolizasContratadasSegPersonales.RamoPolizasContratadasSegPersonales)) = preitem

                    Try
                        preitem.id = [Enum].Parse(GetType(TipoRamoPersonales), sheet.Cell(RowNumber, 2).Value)
                    Catch ex As Exception
                        preitem.id = Canales.TipoRamoPersonales.P14
                    End Try
                    With item
                        .AgenSegNoVinculadoExclusivo = sheet.FormatDecimalValue(RowNumber, "C", "0")
                        .AgenSegNoVinculadosNoExclusivo = sheet.FormatDecimalValue(RowNumber, "D", "0")
                        .SocAgenSegExclusiva = sheet.FormatDecimalValue(RowNumber, "E", "0")
                        .SocAgenSegNoExclusiva = sheet.FormatDecimalValue(RowNumber, "F", "0")
                        .SocCorredoraSeg = sheet.FormatDecimalValue(RowNumber, "G", "0")
                        .OperSegAutoexpedibleExclusivo = sheet.FormatDecimalValue(RowNumber, "H", "0")
                        .OperSegAutoexpedibleNoExclusivo = sheet.FormatDecimalValue(RowNumber, "L", "0")
                        .ProveTransfronterizosSeg = sheet.FormatDecimalValue(RowNumber, "J", "0")
                        .OfiEntAseguradora = sheet.FormatDecimalValue(RowNumber, "K", "0")
                    End With
                    Total += sheet.DecimalValue(RowNumber, "C", "0") +
                                sheet.DecimalValue(RowNumber, "D", "0") +
                                sheet.DecimalValue(RowNumber, "E", "0") +
                                sheet.DecimalValue(RowNumber, "F", "0") +
                                sheet.DecimalValue(RowNumber, "G", "0") +
                                sheet.DecimalValue(RowNumber, "H", "0") +
                                sheet.DecimalValue(RowNumber, "I", "0") +
                                sheet.DecimalValue(RowNumber, "J", "0") +
                                sheet.DecimalValue(RowNumber, "K", "0")
                    TotalAgenSegNoVinculadoExclusivo += sheet.DecimalValue(RowNumber, 3, "0")
                    TotalAgenSegNoVinculadosNoExclusivo += sheet.DecimalValue(RowNumber, 4, "0")
                    TotalSocAgenSegExclusiva += sheet.DecimalValue(RowNumber, 5, "0")
                    TotalSocAgenSegNoExclusiva += sheet.DecimalValue(RowNumber, 6, "0")
                    TotalSocCorredoraSeg += sheet.DecimalValue(RowNumber, 7, "0")
                    TotalOperSegAutoexpedibleExclusivo += sheet.DecimalValue(RowNumber, 8, "0")
                    TotalOperSegAutoexpedibleNoExclusivo += sheet.DecimalValue(RowNumber, 9, "0")
                    TotalProveTransfronterizosSeg += sheet.DecimalValue(RowNumber, 10, "0")
                    TotalOfiEntAseguradora += sheet.DecimalValue(RowNumber, 11, "0")
                    With preitem.PolizasContratadasSegPersonalesPorRamo
                        .Total = MontoFormat(sheet.DecimalValue(RowNumber, 3, "0") +
                                sheet.DecimalValue(RowNumber, 4, "0") +
                                sheet.DecimalValue(RowNumber, 5, "0") +
                                sheet.DecimalValue(RowNumber, 6, "0") +
                                sheet.DecimalValue(RowNumber, 7, "0") +
                                sheet.DecimalValue(RowNumber, 8, "0") +
                                sheet.DecimalValue(RowNumber, 9, "0") +
                                sheet.DecimalValue(RowNumber, 10, "0") +
                                sheet.DecimalValue(RowNumber, 11, "0"))
                    End With
                ElseIf value.IsEmpty Then
                    Exit For
                End If
            Catch ex As Exception
                If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                    XmlRespose.AddError(Response, "error", String.Format("PolizasContratadasSegPersonales Error en '{0}'", ex.Message))
                Else
                    XmlRespose.AddError(Response, "error", String.Format("PolizasContratadasSegPersonales {1} Error en '{0}'", ex.Message, RowNumber))
                End If
            End Try
        Next
        With _Canales.Datos.Modelo.PolizasContratadasSegPersonales
            .TotalPolSegPersonales = Total
        End With
        With _Canales.Datos.Modelo.PolizasContratadasSegPersonales.DesglosePolizasContratadasSegPersonales
            .TotalAgenSegNoVinculadoExclusivo = MontoFormat(TotalAgenSegNoVinculadoExclusivo)
            .TotalAgenSegNoVinculadosNoExclusivo = MontoFormat(TotalAgenSegNoVinculadosNoExclusivo)
            .TotalSocAgenSegExclusiva = MontoFormat(TotalSocAgenSegExclusiva)
            .TotalSocAgenSegNoExclusiva = MontoFormat(TotalSocAgenSegNoExclusiva)
            .TotalSocCorredoraSeg = MontoFormat(TotalSocCorredoraSeg)
            .TotalOperSegAutoexpedibleExclusivo = MontoFormat(TotalOperSegAutoexpedibleExclusivo)
            .TotalOperSegAutoexpedibleNoExclusivo = MontoFormat(TotalOperSegAutoexpedibleNoExclusivo)
            .TotalProveTransfronterizosSeg = MontoFormat(TotalProveTransfronterizosSeg)
            .TotalOfiEntAseguradora = MontoFormat(TotalOfiEntAseguradora)
        End With
    End Sub

    Private Sub PolizasContratadasSegGenerales(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGeneralesPolizasContratadasSegGeneralesPorRamoDesglosePolizasContratadasSegGeneralesPorRamo
        Dim preitem As ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGenerales
        Dim TotalAgenSegNoVinculadoExclusivo As Decimal = 0
        Dim TotalAgenSegNoVinculadosNoExclusivo As Decimal = 0
        Dim TotalSocAgenSegExclusiva As Decimal = 0
        Dim TotalSocAgenSegNoExclusiva As Decimal = 0
        Dim TotalSocCorredoraSeg As Decimal = 0
        Dim TotalOperSegAutoexpedibleExclusivo As Decimal = 0
        Dim TotalOperSegAutoexpedibleNoExclusivo As Decimal = 0
        Dim TotalProveTransfronterizosSeg As Decimal = 0
        Dim TotalOfiEntAseguradora As Decimal = 0
        Dim Total As Decimal = 0

        For RowNumber As Integer = 2 To 1000
            Try
                value = sheet.Cell(RowNumber, 1).Value
                If value.IsNotEmpty AndAlso value.Equals("Polizas Contratadas Seg Generales", StringComparison.CurrentCultureIgnoreCase) Then
                    item = New ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGeneralesPolizasContratadasSegGeneralesPorRamoDesglosePolizasContratadasSegGeneralesPorRamo
                    If _Canales.Datos.Modelo.PolizasContratadasSegGenerales.DesglosePolizasContratadasSegGenerales.RamoPolizasContratadasSegGenerales.IsEmpty Then
                        ReDim Preserve _Canales.Datos.Modelo.PolizasContratadasSegGenerales.DesglosePolizasContratadasSegGenerales.RamoPolizasContratadasSegGenerales(0)
                    Else
                        ReDim Preserve _Canales.Datos.Modelo.PolizasContratadasSegGenerales.DesglosePolizasContratadasSegGenerales.RamoPolizasContratadasSegGenerales(UBound(_Canales.Datos.Modelo.PolizasContratadasSegGenerales.DesglosePolizasContratadasSegGenerales.RamoPolizasContratadasSegGenerales) + 1)
                    End If
                    preitem = New ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGenerales
                    preitem.PolizasContratadasSegGeneralesPorRamo = New ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGeneralesPolizasContratadasSegGeneralesPorRamo
                    preitem.PolizasContratadasSegGeneralesPorRamo.DesglosePolizasContratadasSegGeneralesPorRamo = item
                    _Canales.Datos.Modelo.PolizasContratadasSegGenerales.DesglosePolizasContratadasSegGenerales.RamoPolizasContratadasSegGenerales(UBound(_Canales.Datos.Modelo.PolizasContratadasSegGenerales.DesglosePolizasContratadasSegGenerales.RamoPolizasContratadasSegGenerales)) = preitem

                    Try
                        preitem.id = [Enum].Parse(GetType(TipoRamoGenerales), sheet.Cell(RowNumber, 2).Value)
                    Catch ex As Exception
                        preitem.id = Canales.TipoRamoGenerales.G01
                    End Try
                    With item
                        .AgenSegNoVinculadoExclusivo = sheet.FormatDecimalValue(RowNumber, "C", "0")
                        .AgenSegNoVinculadosNoExclusivo = sheet.FormatDecimalValue(RowNumber, "D", "0")
                        .SocAgenSegExclusiva = sheet.FormatDecimalValue(RowNumber, "E", "0")
                        .SocAgenSegNoExclusiva = sheet.FormatDecimalValue(RowNumber, "F", "0")
                        .SocCorredoraSeg = sheet.FormatDecimalValue(RowNumber, "G", "0")
                        .OperSegAutoexpedibleExclusivo = sheet.FormatDecimalValue(RowNumber, "H", "0")
                        .OperSegAutoexpedibleNoExclusivo = sheet.FormatDecimalValue(RowNumber, "L", "0")
                        .ProveTransfronterizosSeg = sheet.FormatDecimalValue(RowNumber, "J", "0")
                        .OfiEntAseguradora = sheet.FormatDecimalValue(RowNumber, "K", "0")
                    End With
                    Total += sheet.DecimalValue(RowNumber, "C", "0") +
                                sheet.DecimalValue(RowNumber, "D", "0") +
                                sheet.DecimalValue(RowNumber, "E", "0") +
                                sheet.DecimalValue(RowNumber, "F", "0") +
                                sheet.DecimalValue(RowNumber, "G", "0") +
                                sheet.DecimalValue(RowNumber, "H", "0") +
                                sheet.DecimalValue(RowNumber, "I", "0") +
                                sheet.DecimalValue(RowNumber, "J", "0") +
                                sheet.DecimalValue(RowNumber, "K", "0")
                    TotalAgenSegNoVinculadoExclusivo += sheet.DecimalValue(RowNumber, 3, "0")
                    TotalAgenSegNoVinculadosNoExclusivo += sheet.DecimalValue(RowNumber, 4, "0")
                    TotalSocAgenSegExclusiva += sheet.DecimalValue(RowNumber, 5, "0")
                    TotalSocAgenSegNoExclusiva += sheet.DecimalValue(RowNumber, 6, "0")
                    TotalSocCorredoraSeg += sheet.DecimalValue(RowNumber, 7, "0")
                    TotalOperSegAutoexpedibleExclusivo += sheet.DecimalValue(RowNumber, 8, "0")
                    TotalOperSegAutoexpedibleNoExclusivo += sheet.DecimalValue(RowNumber, 9, "0")
                    TotalProveTransfronterizosSeg += sheet.DecimalValue(RowNumber, 10, "0")
                    TotalOfiEntAseguradora += sheet.DecimalValue(RowNumber, 11, "0")
                    With preitem.PolizasContratadasSegGeneralesPorRamo
                        .Total = MontoFormat(sheet.DecimalValue(RowNumber, 3, "0") +
                                sheet.DecimalValue(RowNumber, 4, "0") +
                                sheet.DecimalValue(RowNumber, 5, "0") +
                                sheet.DecimalValue(RowNumber, 6, "0") +
                                sheet.DecimalValue(RowNumber, 7, "0") +
                                sheet.DecimalValue(RowNumber, 8, "0") +
                                sheet.DecimalValue(RowNumber, 9, "0") +
                                sheet.DecimalValue(RowNumber, 10, "0") +
                                sheet.DecimalValue(RowNumber, 11, "0"))
                    End With
                ElseIf value.IsEmpty Then
                    Exit For
                End If
            Catch ex As Exception
                If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                    XmlRespose.AddError(Response, "error", String.Format("PolizasContratadasSegGenerales Error en '{0}'", ex.Message))
                Else
                    XmlRespose.AddError(Response, "error", String.Format("PolizasContratadasSegGenerales {1} Error en '{0}'", ex.Message, RowNumber))
                End If
            End Try
        Next
        With _Canales.Datos.Modelo.PolizasContratadasSegGenerales
            .TotalPolSegGenerales = Total
        End With
        With _Canales.Datos.Modelo.PolizasContratadasSegGenerales.DesglosePolizasContratadasSegGenerales
            .TotalAgenSegNoVinculadoExclusivo = MontoFormat(TotalAgenSegNoVinculadoExclusivo)
            .TotalAgenSegNoVinculadosNoExclusivo = MontoFormat(TotalAgenSegNoVinculadosNoExclusivo)
            .TotalSocAgenSegExclusiva = MontoFormat(TotalSocAgenSegExclusiva)
            .TotalSocAgenSegNoExclusiva = MontoFormat(TotalSocAgenSegNoExclusiva)
            .TotalSocCorredoraSeg = MontoFormat(TotalSocCorredoraSeg)
            .TotalOperSegAutoexpedibleExclusivo = MontoFormat(TotalOperSegAutoexpedibleExclusivo)
            .TotalOperSegAutoexpedibleNoExclusivo = MontoFormat(TotalOperSegAutoexpedibleNoExclusivo)
            .TotalProveTransfronterizosSeg = MontoFormat(TotalProveTransfronterizosSeg)
            .TotalOfiEntAseguradora = MontoFormat(TotalOfiEntAseguradora)
        End With
    End Sub

    Private Sub PrimasPolizasContratadasSegPersonales(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        ' Dim item As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonalesPrimasPolizasContratadasSegPersonalesPorRamoDesglosePrimasPolizasContratadasSegPersonalesPorRamo
        Dim preitem As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonales
        Dim TotalAgenSegNoVinculadoExclusivo As Decimal = 0
        Dim TotalAgenSegNoVinculadosNoExclusivo As Decimal = 0
        Dim TotalSocAgenSegExclusiva As Decimal = 0
        Dim TotalSocAgenSegNoExclusiva As Decimal = 0
        Dim TotalSocCorredoraSeg As Decimal = 0
        Dim TotalOperSegAutoexpedibleExclusivo As Decimal = 0
        Dim TotalOperSegAutoexpedibleNoExclusivo As Decimal = 0
        Dim TotalProveTransfronterizosSeg As Decimal = 0
        Dim TotalOfiEntAseguradora As Decimal = 0
        Dim Total As Decimal = 0

        For RowNumber As Integer = 2 To 1000
            Try
                value = sheet.Cell(RowNumber, 1).Value
                If value.IsNotEmpty AndAlso value.Equals("Primas Polizas Contratadas Seg Personales", StringComparison.CurrentCultureIgnoreCase) Then
                    '  item = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonalesPrimasPolizasContratadasSegPersonalesPorRamoDesglosePrimasPolizasContratadasSegPersonalesPorRamo
                    If _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonales.DesglosePrimasPolizasContratadasSegPersonales.RamoPrimasPolizasContratadasSegPersonales.IsEmpty Then
                        ReDim Preserve _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonales.DesglosePrimasPolizasContratadasSegPersonales.RamoPrimasPolizasContratadasSegPersonales(0)
                    Else
                        ReDim Preserve _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonales.DesglosePrimasPolizasContratadasSegPersonales.RamoPrimasPolizasContratadasSegPersonales(UBound(_Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonales.DesglosePrimasPolizasContratadasSegPersonales.RamoPrimasPolizasContratadasSegPersonales) + 1)
                    End If
                    preitem = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonales
                    preitem.PrimasPolizasContratadasSegPersonalesPorRamo = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonalesPrimasPolizasContratadasSegPersonalesPorRamo
                    preitem.PrimasPolizasContratadasSegPersonalesPorRamo.DesglosePrimasPolizasContratadasSegPersonalesPorRamo = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonalesPrimasPolizasContratadasSegPersonalesPorRamoDesglosePrimasPolizasContratadasSegPersonalesPorRamo
                    _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonales.DesglosePrimasPolizasContratadasSegPersonales.RamoPrimasPolizasContratadasSegPersonales(UBound(_Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonales.DesglosePrimasPolizasContratadasSegPersonales.RamoPrimasPolizasContratadasSegPersonales)) = preitem

                    Try
                        preitem.id = [Enum].Parse(GetType(TipoRamoPersonales), sheet.Cell(RowNumber, 2).Value)
                    Catch ex As Exception
                        preitem.id = Canales.TipoRamoPersonales.P14
                    End Try
                    With preitem.PrimasPolizasContratadasSegPersonalesPorRamo.DesglosePrimasPolizasContratadasSegPersonalesPorRamo
                        .AgenSegNoVinculadoExclusivo = sheet.DecimalValue(RowNumber, 3, "0.00")
                        .AgenSegNoVinculadosNoExclusivo = sheet.DecimalValue(RowNumber, 4, "0.00")
                        .SocAgenSegExclusiva = sheet.DecimalValue(RowNumber, 5, "0.00")
                        .SocAgenSegNoExclusiva = sheet.DecimalValue(RowNumber, 6, "0.00")
                        .SocCorredoraSeg = sheet.DecimalValue(RowNumber, 7, "0.00")
                        .OperSegAutoexpedibleExclusivo = sheet.DecimalValue(RowNumber, 8, "0.00")
                        .OperSegAutoexpedibleNoExclusivo = sheet.DecimalValue(RowNumber, 9, "0.00")
                        .ProveTransfronterizosSeg = sheet.DecimalValue(RowNumber, 10, "0.00")
                        .OfiEntAseguradora = sheet.DecimalValue(RowNumber, 11, "0.00")

                        .AgenSegNoVinculadoExclusivoSpecified = True
                        .AgenSegNoVinculadosNoExclusivoSpecified = True
                        .SocAgenSegExclusivaSpecified = True
                        .SocAgenSegNoExclusivaSpecified = True
                        .SocCorredoraSegSpecified = True
                        .OperSegAutoexpedibleExclusivoSpecified = True
                        .OperSegAutoexpedibleNoExclusivoSpecified = True
                        .ProveTransfronterizosSegSpecified = True
                        .OfiEntAseguradoraSpecified = True
                    End With
                    Total += sheet.DecimalValue(RowNumber, 3, "0.00") +
                             sheet.DecimalValue(RowNumber, 4, "0.00") +
                             sheet.DecimalValue(RowNumber, 5, "0.00") +
                             sheet.DecimalValue(RowNumber, 6, "0.00") +
                             sheet.DecimalValue(RowNumber, 7, "0.00") +
                             sheet.DecimalValue(RowNumber, 8, "0.00") +
                             sheet.DecimalValue(RowNumber, 9, "0.00") +
                             sheet.DecimalValue(RowNumber, 10, "0.00") +
                             sheet.DecimalValue(RowNumber, 11, "0.00")
                    TotalAgenSegNoVinculadoExclusivo += sheet.DecimalValue(RowNumber, 3, "0.00")
                    TotalAgenSegNoVinculadosNoExclusivo += sheet.DecimalValue(RowNumber, 4, "0.00")
                    TotalSocAgenSegExclusiva += sheet.DecimalValue(RowNumber, 5, "0.00")
                    TotalSocAgenSegNoExclusiva += sheet.DecimalValue(RowNumber, 6, "0.00")
                    TotalSocCorredoraSeg += sheet.DecimalValue(RowNumber, 7, "0.00")
                    TotalOperSegAutoexpedibleExclusivo += sheet.DecimalValue(RowNumber, 8, "0.00")
                    TotalOperSegAutoexpedibleNoExclusivo += sheet.DecimalValue(RowNumber, 9, "0.00")
                    TotalProveTransfronterizosSeg += sheet.DecimalValue(RowNumber, 10, "0.00")
                    TotalOfiEntAseguradora += sheet.DecimalValue(RowNumber, 11, "0.00")
                    With preitem.PrimasPolizasContratadasSegPersonalesPorRamo
                        .Total = MontoDecimal(sheet.DecimalValue(RowNumber, 3, "0.00") +
                                 sheet.DecimalValue(RowNumber, 4, "0.00") +
                                 sheet.DecimalValue(RowNumber, 5, "0.00") +
                                 sheet.DecimalValue(RowNumber, 6, "0.00") +
                                 sheet.DecimalValue(RowNumber, 7, "0.00") +
                                 sheet.DecimalValue(RowNumber, 8, "0.00") +
                                 sheet.DecimalValue(RowNumber, 9, "0.00") +
                                 sheet.DecimalValue(RowNumber, 10, "0.00") +
                                 sheet.DecimalValue(RowNumber, 11, "0.00"))
                    End With
                ElseIf value.IsEmpty Then
                    Exit For
                End If
            Catch ex As Exception
                If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                    XmlRespose.AddError(Response, "error", String.Format("PrimasPolizasContratadasSegPersonales Error en '{0}'", ex.Message))
                Else
                    XmlRespose.AddError(Response, "error", String.Format("PrimasPolizasContratadasSegPersonales {1} Error en '{0}'", ex.Message, RowNumber))
                End If
            End Try
        Next
        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonales
            .TotalPriSegPersonales = MontoDecimal(Total)
        End With
        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonales.DesglosePrimasPolizasContratadasSegPersonales
            .TotalAgenSegNoVinculadoExclusivo = MontoDecimalOptionalFormat(TotalAgenSegNoVinculadoExclusivo, 0)
            .TotalAgenSegNoVinculadosNoExclusivo = MontoDecimalOptionalFormat(TotalAgenSegNoVinculadosNoExclusivo, 0)
            .TotalSocAgenSegExclusiva = MontoDecimalOptionalFormat(TotalSocAgenSegExclusiva, 0)
            .TotalSocAgenSegNoExclusiva = MontoDecimalOptionalFormat(TotalSocAgenSegNoExclusiva, 0)
            .TotalSocCorredoraSeg = MontoDecimalOptionalFormat(TotalSocCorredoraSeg, 0)
            .TotalOperSegAutoexpedibleExclusivo = MontoDecimalOptionalFormat(TotalOperSegAutoexpedibleExclusivo, 0)
            .TotalOperSegAutoexpedibleNoExclusivo = MontoDecimalOptionalFormat(TotalOperSegAutoexpedibleNoExclusivo, 0)
            .TotalProveTransfronterizosSeg = MontoDecimalOptionalFormat(TotalProveTransfronterizosSeg, 0)
            .TotalOfiEntAseguradora = MontoDecimalOptionalFormat(TotalOfiEntAseguradora, 0)
        End With
    End Sub

    Private Sub PrimasPolizasContratadasSegGenerales(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGeneralesPrimasPolizasContratadasSegGeneralesPorRamoDesglosePrimasPolizasContratadasSegGeneralesPorRamo
        Dim preitem As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGenerales
        Dim TotalAgenSegNoVinculadoExclusivo As Decimal = 0
        Dim TotalAgenSegNoVinculadosNoExclusivo As Decimal = 0
        Dim TotalSocAgenSegExclusiva As Decimal = 0
        Dim TotalSocAgenSegNoExclusiva As Decimal = 0
        Dim TotalSocCorredoraSeg As Decimal = 0
        Dim TotalOperSegAutoexpedibleExclusivo As Decimal = 0
        Dim TotalOperSegAutoexpedibleNoExclusivo As Decimal = 0
        Dim TotalProveTransfronterizosSeg As Decimal = 0
        Dim TotalOfiEntAseguradora As Decimal = 0
        Dim Total As Decimal = 0

        For RowNumber As Integer = 2 To 1000
            Try
                value = sheet.Cell(RowNumber, 1).Value
                If value.IsNotEmpty AndAlso value.Equals("Primas Polizas Contratadas Seg Generales", StringComparison.CurrentCultureIgnoreCase) Then
                    item = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGeneralesPrimasPolizasContratadasSegGeneralesPorRamoDesglosePrimasPolizasContratadasSegGeneralesPorRamo
                    If _Canales.Datos.Modelo.PrimasPolizasContratadasSegGenerales.DesglosePrimasPolizasContratadasSegGenerales.RamoPrimasPolizasContratadasSegGenerales.IsEmpty Then
                        ReDim Preserve _Canales.Datos.Modelo.PrimasPolizasContratadasSegGenerales.DesglosePrimasPolizasContratadasSegGenerales.RamoPrimasPolizasContratadasSegGenerales(0)
                    Else
                        ReDim Preserve _Canales.Datos.Modelo.PrimasPolizasContratadasSegGenerales.DesglosePrimasPolizasContratadasSegGenerales.RamoPrimasPolizasContratadasSegGenerales(UBound(_Canales.Datos.Modelo.PrimasPolizasContratadasSegGenerales.DesglosePrimasPolizasContratadasSegGenerales.RamoPrimasPolizasContratadasSegGenerales) + 1)
                    End If
                    preitem = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGenerales
                    preitem.PrimasPolizasContratadasSegGeneralesPorRamo = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGeneralesPrimasPolizasContratadasSegGeneralesPorRamo
                    preitem.PrimasPolizasContratadasSegGeneralesPorRamo.DesglosePrimasPolizasContratadasSegGeneralesPorRamo = item
                    _Canales.Datos.Modelo.PrimasPolizasContratadasSegGenerales.DesglosePrimasPolizasContratadasSegGenerales.RamoPrimasPolizasContratadasSegGenerales(UBound(_Canales.Datos.Modelo.PrimasPolizasContratadasSegGenerales.DesglosePrimasPolizasContratadasSegGenerales.RamoPrimasPolizasContratadasSegGenerales)) = preitem

                    Try
                        preitem.id = [Enum].Parse(GetType(TipoRamoGenerales), sheet.Cell(RowNumber, 2).Value)
                    Catch ex As Exception
                        preitem.id = Canales.TipoRamoGenerales.G01
                    End Try
                    With item
                        .AgenSegNoVinculadoExclusivo = sheet.DecimalValue(RowNumber, 3, "0.00")
                        .AgenSegNoVinculadosNoExclusivo = sheet.DecimalValue(RowNumber, 4, "0.00")
                        .SocAgenSegExclusiva = sheet.DecimalValue(RowNumber, 5, "0.00")
                        .SocAgenSegNoExclusiva = sheet.DecimalValue(RowNumber, 6, "0.00")
                        .SocCorredoraSeg = sheet.DecimalValue(RowNumber, 7, "0.00")
                        .OperSegAutoexpedibleExclusivo = sheet.DecimalValue(RowNumber, 8, "0.00")
                        .OperSegAutoexpedibleNoExclusivo = sheet.DecimalValue(RowNumber, 9, "0.00")
                        .ProveTransfronterizosSeg = sheet.DecimalValue(RowNumber, 10, "0.00")
                        .OfiEntAseguradora = sheet.DecimalValue(RowNumber, 11, "0.00")

                        .AgenSegNoVinculadoExclusivoSpecified = True
                        .AgenSegNoVinculadosNoExclusivoSpecified = True
                        .SocAgenSegExclusivaSpecified = True
                        .SocAgenSegNoExclusivaSpecified = True
                        .SocCorredoraSegSpecified = True
                        .OperSegAutoexpedibleExclusivoSpecified = True
                        .OperSegAutoexpedibleNoExclusivoSpecified = True
                        .ProveTransfronterizosSegSpecified = True
                        .OfiEntAseguradoraSpecified = True
                    End With
                    Total += sheet.DecimalValue(RowNumber, 3, "0.00") +
                                sheet.DecimalValue(RowNumber, 4, "0.00") +
                                sheet.DecimalValue(RowNumber, 5, "0.00") +
                                sheet.DecimalValue(RowNumber, 6, "0.00") +
                                sheet.DecimalValue(RowNumber, 7, "0.00") +
                                sheet.DecimalValue(RowNumber, 8, "0.00") +
                                sheet.DecimalValue(RowNumber, 9, "0.00") +
                                sheet.DecimalValue(RowNumber, 10, "0.00") +
                                sheet.DecimalValue(RowNumber, 11, "0.00")
                    TotalAgenSegNoVinculadoExclusivo += sheet.DecimalValue(RowNumber, 3, "0.00")
                    TotalAgenSegNoVinculadosNoExclusivo += sheet.DecimalValue(RowNumber, 4, "0.00")
                    TotalSocAgenSegExclusiva += sheet.DecimalValue(RowNumber, 5, "0.00")
                    TotalSocAgenSegNoExclusiva += sheet.DecimalValue(RowNumber, 6, "0.00")
                    TotalSocCorredoraSeg += sheet.DecimalValue(RowNumber, 7, "0.00")
                    TotalOperSegAutoexpedibleExclusivo += sheet.DecimalValue(RowNumber, 8, "0.00")
                    TotalOperSegAutoexpedibleNoExclusivo += sheet.DecimalValue(RowNumber, 9, "0.00")
                    TotalProveTransfronterizosSeg += sheet.DecimalValue(RowNumber, 10, "0.00")
                    TotalOfiEntAseguradora += sheet.DecimalValue(RowNumber, 11, "0.00")
                    With preitem.PrimasPolizasContratadasSegGeneralesPorRamo
                        .Total = sheet.DecimalValue(RowNumber, 3, "0.00") +
                                sheet.DecimalValue(RowNumber, 4, "0.00") +
                                sheet.DecimalValue(RowNumber, 5, "0.00") +
                                sheet.DecimalValue(RowNumber, 6, "0.00") +
                                sheet.DecimalValue(RowNumber, 7, "0.00") +
                                sheet.DecimalValue(RowNumber, 8, "0.00") +
                                sheet.DecimalValue(RowNumber, 9, "0.00") +
                                sheet.DecimalValue(RowNumber, 10, "0.00") +
                                sheet.DecimalValue(RowNumber, 11, "0.00")
                    End With

                ElseIf value.IsEmpty Then
                    Exit For
                End If
            Catch ex As Exception
                If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                    XmlRespose.AddError(Response, "error", String.Format("PrimasPolizasContratadasSegGenerales Error en '{0}'", ex.Message))
                Else
                    XmlRespose.AddError(Response, "error", String.Format("PrimasPolizasContratadasSegGenerales {1} Error en '{0}'", ex.Message, RowNumber))
                End If
            End Try
        Next
        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegGenerales
            .TotalPriSegGenerales = MontoDecimal(Total)
        End With
        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegGenerales.DesglosePrimasPolizasContratadasSegGenerales
            .TotalAgenSegNoVinculadoExclusivo = MontoDecimal(TotalAgenSegNoVinculadoExclusivo)
            .TotalAgenSegNoVinculadosNoExclusivo = MontoDecimal(TotalAgenSegNoVinculadosNoExclusivo)
            .TotalSocAgenSegExclusiva = MontoDecimal(TotalSocAgenSegExclusiva)
            .TotalSocAgenSegNoExclusiva = MontoDecimal(TotalSocAgenSegNoExclusiva)
            .TotalSocCorredoraSeg = MontoDecimal(TotalSocCorredoraSeg)
            .TotalOperSegAutoexpedibleExclusivo = MontoDecimal(TotalOperSegAutoexpedibleExclusivo)
            .TotalOperSegAutoexpedibleNoExclusivo = MontoDecimal(TotalOperSegAutoexpedibleNoExclusivo)
            .TotalProveTransfronterizosSeg = MontoDecimal(TotalProveTransfronterizosSeg)
            .TotalOfiEntAseguradora = MontoDecimal(TotalOfiEntAseguradora)
        End With
    End Sub

    Private Sub PolizasContratadasNuevaProduccionSegPersonales(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonalesPolizasContratadasNuevaProduccionSegPersonalesPorRamoDesglosePolizasContratadasNuevaProduccionSegPersonalesPorRamo
        Dim preitem As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonales
        Dim TotalAgenSegNoVinculadoExclusivo As Decimal = 0
        Dim TotalAgenSegNoVinculadosNoExclusivo As Decimal = 0
        Dim TotalSocAgenSegExclusiva As Decimal = 0
        Dim TotalSocAgenSegNoExclusiva As Decimal = 0
        Dim TotalSocCorredoraSeg As Decimal = 0
        Dim TotalOperSegAutoexpedibleExclusivo As Decimal = 0
        Dim TotalOperSegAutoexpedibleNoExclusivo As Decimal = 0
        Dim TotalProveTransfronterizosSeg As Decimal = 0
        Dim TotalOfiEntAseguradora As Decimal = 0
        Dim Total As Decimal = 0

        For RowNumber As Integer = 2 To 1000
            Try
                value = sheet.Cell(RowNumber, 1).Value
                If value.IsNotEmpty AndAlso value.Equals("Polizas Contratadas Nueva Produccion Seg Personales", StringComparison.CurrentCultureIgnoreCase) Then
                    item = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonalesPolizasContratadasNuevaProduccionSegPersonalesPorRamoDesglosePolizasContratadasNuevaProduccionSegPersonalesPorRamo
                    If _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegPersonales.DesglosePolizasContratadasNuevaProduccionSegPersonales.RamoPolizasContratadasNuevaProduccionSegPersonales.IsEmpty Then
                        ReDim Preserve _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegPersonales.DesglosePolizasContratadasNuevaProduccionSegPersonales.RamoPolizasContratadasNuevaProduccionSegPersonales(0)
                    Else
                        ReDim Preserve _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegPersonales.DesglosePolizasContratadasNuevaProduccionSegPersonales.RamoPolizasContratadasNuevaProduccionSegPersonales(UBound(_Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegPersonales.DesglosePolizasContratadasNuevaProduccionSegPersonales.RamoPolizasContratadasNuevaProduccionSegPersonales) + 1)
                    End If
                    preitem = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonales
                    preitem.PolizasContratadasNuevaProduccionSegPersonalesPorRamo = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonalesPolizasContratadasNuevaProduccionSegPersonalesPorRamo
                    preitem.PolizasContratadasNuevaProduccionSegPersonalesPorRamo.DesglosePolizasContratadasNuevaProduccionSegPersonalesPorRamo = item
                    _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegPersonales.DesglosePolizasContratadasNuevaProduccionSegPersonales.RamoPolizasContratadasNuevaProduccionSegPersonales(UBound(_Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegPersonales.DesglosePolizasContratadasNuevaProduccionSegPersonales.RamoPolizasContratadasNuevaProduccionSegPersonales)) = preitem

                    Try
                        preitem.id = [Enum].Parse(GetType(TipoRamoPersonales), sheet.Cell(RowNumber, 2).Value)
                    Catch ex As Exception
                        preitem.id = Canales.TipoRamoPersonales.P14
                    End Try
                    With item
                        .AgenSegNoVinculadoExclusivo = sheet.DecimalValue(RowNumber, 3, "0")
                        .AgenSegNoVinculadosNoExclusivo = sheet.DecimalValue(RowNumber, 4, "0")
                        .SocAgenSegExclusiva = sheet.DecimalValue(RowNumber, 5, "0")
                        .SocAgenSegNoExclusiva = sheet.DecimalValue(RowNumber, 6, "0")
                        .SocCorredoraSeg = sheet.DecimalValue(RowNumber, 7, "0")
                        .OperSegAutoexpedibleExclusivo = sheet.DecimalValue(RowNumber, 8, "0")
                        .OperSegAutoexpedibleNoExclusivo = sheet.DecimalValue(RowNumber, 9, "0")
                        .ProveTransfronterizosSeg = sheet.DecimalValue(RowNumber, 10, "0")
                        .OfiEntAseguradora = sheet.DecimalValue(RowNumber, 11, "0")
                    End With
                    Total += sheet.DecimalValue(RowNumber, 3, "0") +
                                sheet.DecimalValue(RowNumber, 4, "0") +
                                sheet.DecimalValue(RowNumber, 5, "0") +
                                sheet.DecimalValue(RowNumber, 6, "0") +
                                sheet.DecimalValue(RowNumber, 7, "0") +
                                sheet.DecimalValue(RowNumber, 8, "0") +
                                sheet.DecimalValue(RowNumber, 9, "0") +
                                sheet.DecimalValue(RowNumber, 10, "0") +
                                sheet.DecimalValue(RowNumber, 11, "0")
                    TotalAgenSegNoVinculadoExclusivo += sheet.DecimalValue(RowNumber, 3, "0")
                    TotalAgenSegNoVinculadosNoExclusivo += sheet.DecimalValue(RowNumber, 4, "0")
                    TotalSocAgenSegExclusiva += sheet.DecimalValue(RowNumber, 5, "0")
                    TotalSocAgenSegNoExclusiva += sheet.DecimalValue(RowNumber, 6, "0")
                    TotalSocCorredoraSeg += sheet.DecimalValue(RowNumber, 7, "0")
                    TotalOperSegAutoexpedibleExclusivo += sheet.DecimalValue(RowNumber, 8, "0")
                    TotalOperSegAutoexpedibleNoExclusivo += sheet.DecimalValue(RowNumber, 9, "0")
                    TotalProveTransfronterizosSeg += sheet.DecimalValue(RowNumber, 10, "0")
                    TotalOfiEntAseguradora += sheet.DecimalValue(RowNumber, 11, "0")
                    With preitem.PolizasContratadasNuevaProduccionSegPersonalesPorRamo
                        .Total = sheet.DecimalValue(RowNumber, 3, "0") +
                                sheet.DecimalValue(RowNumber, 4, "0") +
                                sheet.DecimalValue(RowNumber, 5, "0") +
                                sheet.DecimalValue(RowNumber, 6, "0") +
                                sheet.DecimalValue(RowNumber, 7, "0") +
                                sheet.DecimalValue(RowNumber, 8, "0") +
                                sheet.DecimalValue(RowNumber, 9, "0") +
                                sheet.DecimalValue(RowNumber, 10, "0") +
                                sheet.DecimalValue(RowNumber, 11, "0")
                    End With
                ElseIf value.IsEmpty Then
                    Exit For
                End If
            Catch ex As Exception
                If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                    XmlRespose.AddError(Response, "error", String.Format("PolizasContratadasNuevaProduccionSegPersonales Error en '{0}'", ex.Message))
                Else
                    XmlRespose.AddError(Response, "error", String.Format("PolizasContratadasNuevaProduccionSegPersonales {1} Error en '{0}'", ex.Message, RowNumber))
                End If
            End Try
        Next
        If Total = 0 Then
            _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegPersonales = Nothing
        Else
            With _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegPersonales
                .TotalPolSegPersonales = Total
            End With
            With _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegPersonales.DesglosePolizasContratadasNuevaProduccionSegPersonales
                .TotalAgenSegNoVinculadoExclusivo = MontoFormat(TotalAgenSegNoVinculadoExclusivo)
                .TotalAgenSegNoVinculadosNoExclusivo = MontoFormat(TotalAgenSegNoVinculadosNoExclusivo)
                .TotalSocAgenSegExclusiva = MontoFormat(TotalSocAgenSegExclusiva)
                .TotalSocAgenSegNoExclusiva = MontoFormat(TotalSocAgenSegNoExclusiva)
                .TotalSocCorredoraSeg = MontoFormat(TotalSocCorredoraSeg)
                .TotalOperSegAutoexpedibleExclusivo = MontoFormat(TotalOperSegAutoexpedibleExclusivo)
                .TotalOperSegAutoexpedibleNoExclusivo = MontoFormat(TotalOperSegAutoexpedibleNoExclusivo)
                .TotalProveTransfronterizosSeg = MontoFormat(TotalProveTransfronterizosSeg)
                .TotalOfiEntAseguradora = MontoFormat(TotalOfiEntAseguradora)
            End With
        End If

    End Sub

    Private Sub PolizasContratadasNuevaProduccionSegGenerales(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGeneralesPolizasContratadasNuevaProduccionSegGeneralesPorRamoDesglosePolizasContratadasNuevaProduccionSegGeneralesPorRamo
        Dim preitem As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGenerales
        Dim TotalAgenSegNoVinculadoExclusivo As Decimal = 0
        Dim TotalAgenSegNoVinculadosNoExclusivo As Decimal = 0
        Dim TotalSocAgenSegExclusiva As Decimal = 0
        Dim TotalSocAgenSegNoExclusiva As Decimal = 0
        Dim TotalSocCorredoraSeg As Decimal = 0
        Dim TotalOperSegAutoexpedibleExclusivo As Decimal = 0
        Dim TotalOperSegAutoexpedibleNoExclusivo As Decimal = 0
        Dim TotalProveTransfronterizosSeg As Decimal = 0
        Dim TotalOfiEntAseguradora As Decimal = 0
        Dim Total As Decimal = 0

        For RowNumber As Integer = 2 To 1000
            Try
                value = sheet.Cell(RowNumber, 1).Value
                If value.IsNotEmpty AndAlso value.Equals("Polizas Contratadas Nueva Produccion Seg Generales", StringComparison.CurrentCultureIgnoreCase) Then
                    item = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGeneralesPolizasContratadasNuevaProduccionSegGeneralesPorRamoDesglosePolizasContratadasNuevaProduccionSegGeneralesPorRamo
                    If _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegGenerales.DesglosePolizasContratadasNuevaProduccionSegGenerales.RamoPolizasContratadasNuevaProduccionSegGenerales.IsEmpty Then
                        ReDim Preserve _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegGenerales.DesglosePolizasContratadasNuevaProduccionSegGenerales.RamoPolizasContratadasNuevaProduccionSegGenerales(0)
                    Else
                        ReDim Preserve _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegGenerales.DesglosePolizasContratadasNuevaProduccionSegGenerales.RamoPolizasContratadasNuevaProduccionSegGenerales(UBound(_Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegGenerales.DesglosePolizasContratadasNuevaProduccionSegGenerales.RamoPolizasContratadasNuevaProduccionSegGenerales) + 1)
                    End If
                    preitem = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGenerales
                    preitem.PolizasContratadasNuevaProduccionSegGeneralesPorRamo = New ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGeneralesPolizasContratadasNuevaProduccionSegGeneralesPorRamo
                    preitem.PolizasContratadasNuevaProduccionSegGeneralesPorRamo.DesglosePolizasContratadasNuevaProduccionSegGeneralesPorRamo = item
                    _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegGenerales.DesglosePolizasContratadasNuevaProduccionSegGenerales.RamoPolizasContratadasNuevaProduccionSegGenerales(UBound(_Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegGenerales.DesglosePolizasContratadasNuevaProduccionSegGenerales.RamoPolizasContratadasNuevaProduccionSegGenerales)) = preitem

                    Try
                        preitem.id = [Enum].Parse(GetType(TipoRamoGenerales), sheet.Cell(RowNumber, 2).Value)
                    Catch ex As Exception
                        preitem.id = Canales.TipoRamoGenerales.G01
                    End Try
                    With item
                        .AgenSegNoVinculadoExclusivo = sheet.DecimalValue(RowNumber, 3, "0")
                        .AgenSegNoVinculadosNoExclusivo = sheet.DecimalValue(RowNumber, 4, "0")
                        .SocAgenSegExclusiva = sheet.DecimalValue(RowNumber, 5, "0")
                        .SocAgenSegNoExclusiva = sheet.DecimalValue(RowNumber, 6, "0")
                        .SocCorredoraSeg = sheet.DecimalValue(RowNumber, 7, "0")
                        .OperSegAutoexpedibleExclusivo = sheet.DecimalValue(RowNumber, 8, "0")
                        .OperSegAutoexpedibleNoExclusivo = sheet.DecimalValue(RowNumber, 9, "0")
                        .ProveTransfronterizosSeg = sheet.DecimalValue(RowNumber, 10, "0")
                        .OfiEntAseguradora = sheet.DecimalValue(RowNumber, 11, "0")
                    End With
                    Total += sheet.DecimalValue(RowNumber, 3, "0") +
                                sheet.DecimalValue(RowNumber, 4, "0") +
                                sheet.DecimalValue(RowNumber, 5, "0") +
                                sheet.DecimalValue(RowNumber, 6, "0") +
                                sheet.DecimalValue(RowNumber, 7, "0") +
                                sheet.DecimalValue(RowNumber, 8, "0") +
                                sheet.DecimalValue(RowNumber, 9, "0") +
                                sheet.DecimalValue(RowNumber, 10, "0") +
                                sheet.DecimalValue(RowNumber, 11, "0")
                    TotalAgenSegNoVinculadoExclusivo += sheet.DecimalValue(RowNumber, 3, "0")
                    TotalAgenSegNoVinculadosNoExclusivo += sheet.DecimalValue(RowNumber, 4, "0")
                    TotalSocAgenSegExclusiva += sheet.DecimalValue(RowNumber, 5, "0")
                    TotalSocAgenSegNoExclusiva += sheet.DecimalValue(RowNumber, 6, "0")
                    TotalSocCorredoraSeg += sheet.DecimalValue(RowNumber, 7, "0")
                    TotalOperSegAutoexpedibleExclusivo += sheet.DecimalValue(RowNumber, 8, "0")
                    TotalOperSegAutoexpedibleNoExclusivo += sheet.DecimalValue(RowNumber, 9, "0")
                    TotalProveTransfronterizosSeg += sheet.DecimalValue(RowNumber, 10, "0")
                    TotalOfiEntAseguradora += sheet.DecimalValue(RowNumber, 11, "0")
                    With preitem.PolizasContratadasNuevaProduccionSegGeneralesPorRamo
                        .Total = sheet.DecimalValue(RowNumber, 3, "0") +
                                sheet.DecimalValue(RowNumber, 4, "0") +
                                sheet.DecimalValue(RowNumber, 5, "0") +
                                sheet.DecimalValue(RowNumber, 6, "0") +
                                sheet.DecimalValue(RowNumber, 7, "0") +
                                sheet.DecimalValue(RowNumber, 8, "0") +
                                sheet.DecimalValue(RowNumber, 9, "0") +
                                sheet.DecimalValue(RowNumber, 10, "0") +
                                sheet.DecimalValue(RowNumber, 11, "0")
                    End With
                ElseIf value.IsEmpty Then
                    Exit For
                End If
            Catch ex As Exception
                If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                    XmlRespose.AddError(Response, "error", String.Format("PolizasContratadasNuevaProduccionSegGenerales Error en '{0}'", ex.Message))
                Else
                    XmlRespose.AddError(Response, "error", String.Format("PolizasContratadasNuevaProduccionSegGenerales {1} Error en '{0}'", ex.Message, RowNumber))
                End If
            End Try
        Next
        If Total = 0 Then
            _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegGenerales = Nothing
        Else
            With _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegGenerales
                .TotalPolSegGenerales = Total
            End With
            With _Canales.Datos.Modelo.PolizasContratadasNuevaProduccionSegGenerales.DesglosePolizasContratadasNuevaProduccionSegGenerales
                .TotalAgenSegNoVinculadoExclusivo = MontoFormat(TotalAgenSegNoVinculadoExclusivo)
                .TotalAgenSegNoVinculadosNoExclusivo = MontoFormat(TotalAgenSegNoVinculadosNoExclusivo)
                .TotalSocAgenSegExclusiva = MontoFormat(TotalSocAgenSegExclusiva)
                .TotalSocAgenSegNoExclusiva = MontoFormat(TotalSocAgenSegNoExclusiva)
                .TotalSocCorredoraSeg = MontoFormat(TotalSocCorredoraSeg)
                .TotalOperSegAutoexpedibleExclusivo = MontoFormat(TotalOperSegAutoexpedibleExclusivo)
                .TotalOperSegAutoexpedibleNoExclusivo = MontoFormat(TotalOperSegAutoexpedibleNoExclusivo)
                .TotalProveTransfronterizosSeg = MontoFormat(TotalProveTransfronterizosSeg)
                .TotalOfiEntAseguradora = MontoFormat(TotalOfiEntAseguradora)
            End With
        End If

    End Sub

    Private Sub PrimasPolizasContratadasSegPersonalesNuevaProduccion(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccionPrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamoDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo
        Dim preitem As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccion
        Dim TotalAgenSegNoVinculadoExclusivo As Decimal = 0
        Dim TotalAgenSegNoVinculadosNoExclusivo As Decimal = 0
        Dim TotalSocAgenSegExclusiva As Decimal = 0
        Dim TotalSocAgenSegNoExclusiva As Decimal = 0
        Dim TotalSocCorredoraSeg As Decimal = 0
        Dim TotalOperSegAutoexpedibleExclusivo As Decimal = 0
        Dim TotalOperSegAutoexpedibleNoExclusivo As Decimal = 0
        Dim TotalProveTransfronterizosSeg As Decimal = 0
        Dim TotalOfiEntAseguradora As Decimal = 0
        Dim Total As Decimal = 0

        For RowNumber As Integer = 2 To 1000
            Try
                value = sheet.Cell(RowNumber, 1).Value
                If value.IsNotEmpty AndAlso value.Equals("Primas Polizas Contratadas Seg Personales Nueva Produccion", StringComparison.CurrentCultureIgnoreCase) Then
                    item = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccionPrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamoDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo
                    If _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonalesNuevaProduccion.DesglosePrimasPolizasContratadasSegPersonalesNuevaProduccion.RamoPrimasPolizasContratadasSegPersonalesNuevaProduccion.IsEmpty Then
                        ReDim Preserve _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonalesNuevaProduccion.DesglosePrimasPolizasContratadasSegPersonalesNuevaProduccion.RamoPrimasPolizasContratadasSegPersonalesNuevaProduccion(0)
                    Else
                        ReDim Preserve _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonalesNuevaProduccion.DesglosePrimasPolizasContratadasSegPersonalesNuevaProduccion.RamoPrimasPolizasContratadasSegPersonalesNuevaProduccion(UBound(_Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonalesNuevaProduccion.DesglosePrimasPolizasContratadasSegPersonalesNuevaProduccion.RamoPrimasPolizasContratadasSegPersonalesNuevaProduccion) + 1)
                    End If
                    preitem = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccion
                    preitem.PrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccionPrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo
                    preitem.PrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo.DesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo = item
                    _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonalesNuevaProduccion.DesglosePrimasPolizasContratadasSegPersonalesNuevaProduccion.RamoPrimasPolizasContratadasSegPersonalesNuevaProduccion(UBound(_Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonalesNuevaProduccion.DesglosePrimasPolizasContratadasSegPersonalesNuevaProduccion.RamoPrimasPolizasContratadasSegPersonalesNuevaProduccion)) = preitem

                    Try
                        preitem.id = [Enum].Parse(GetType(TipoRamoPersonales), sheet.Cell(RowNumber, 2).Value)
                    Catch ex As Exception
                        preitem.id = Canales.TipoRamoPersonales.P14
                    End Try
                    With item
                        .AgenSegNoVinculadoExclusivo = sheet.DecimalValue(RowNumber, 3, "0.00")
                        .AgenSegNoVinculadosNoExclusivo = sheet.DecimalValue(RowNumber, 4, "0.00")
                        .SocAgenSegExclusiva = sheet.DecimalValue(RowNumber, 5, "0.00")
                        .SocAgenSegNoExclusiva = sheet.DecimalValue(RowNumber, 6, "0.00")
                        .SocCorredoraSeg = sheet.DecimalValue(RowNumber, 7, "0.00")
                        .OperSegAutoexpedibleExclusivo = sheet.DecimalValue(RowNumber, 8, "0.00")
                        .OperSegAutoexpedibleNoExclusivo = sheet.DecimalValue(RowNumber, 9, "0.00")
                        .ProveTransfronterizosSeg = sheet.DecimalValue(RowNumber, 10, "0.00")
                        .OfiEntAseguradora = sheet.DecimalValue(RowNumber, 11, "0.00")

                        .AgenSegNoVinculadoExclusivoSpecified = True
                        .AgenSegNoVinculadosNoExclusivoSpecified = True
                        .SocAgenSegExclusivaSpecified = True
                        .SocAgenSegNoExclusivaSpecified = True
                        .SocCorredoraSegSpecified = True
                        .OperSegAutoexpedibleExclusivoSpecified = True
                        .OperSegAutoexpedibleNoExclusivoSpecified = True
                        .ProveTransfronterizosSegSpecified = True
                        .OfiEntAseguradoraSpecified = True
                    End With
                    Total += sheet.DecimalValue(RowNumber, 3, "0.00") +
                                sheet.DecimalValue(RowNumber, 4, "0.00") +
                                sheet.DecimalValue(RowNumber, 5, "0.00") +
                                sheet.DecimalValue(RowNumber, 6, "0.00") +
                                sheet.DecimalValue(RowNumber, 7, "0.00") +
                                sheet.DecimalValue(RowNumber, 8, "0.00") +
                                sheet.DecimalValue(RowNumber, 9, "0.00") +
                                sheet.DecimalValue(RowNumber, 10, "0.00") +
                                sheet.DecimalValue(RowNumber, 11, "0.00")
                    TotalAgenSegNoVinculadoExclusivo += sheet.DecimalValue(RowNumber, 3, "0.00")
                    TotalAgenSegNoVinculadosNoExclusivo += sheet.DecimalValue(RowNumber, 4, "0.00")
                    TotalSocAgenSegExclusiva += sheet.DecimalValue(RowNumber, 5, "0.00")
                    TotalSocAgenSegNoExclusiva += sheet.DecimalValue(RowNumber, 6, "0.00")
                    TotalSocCorredoraSeg += sheet.DecimalValue(RowNumber, 7, "0.00")
                    TotalOperSegAutoexpedibleExclusivo += sheet.DecimalValue(RowNumber, 8, "0.00")
                    TotalOperSegAutoexpedibleNoExclusivo += sheet.DecimalValue(RowNumber, 9, "0.00")
                    TotalProveTransfronterizosSeg += sheet.DecimalValue(RowNumber, 10, "0.00")
                    TotalOfiEntAseguradora += sheet.DecimalValue(RowNumber, 11, "0.00")
                    With preitem.PrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo
                        .Total = sheet.DecimalValue(RowNumber, 3, "0.00") +
                                sheet.DecimalValue(RowNumber, 4, "0.00") +
                                sheet.DecimalValue(RowNumber, 5, "0.00") +
                                sheet.DecimalValue(RowNumber, 6, "0.00") +
                                sheet.DecimalValue(RowNumber, 7, "0.00") +
                                sheet.DecimalValue(RowNumber, 8, "0.00") +
                                sheet.DecimalValue(RowNumber, 9, "0.00") +
                                sheet.DecimalValue(RowNumber, 10, "0.00") +
                                sheet.DecimalValue(RowNumber, 11, "0.00")
                    End With
                ElseIf value.IsEmpty Then
                    Exit For
                End If
            Catch ex As Exception
                If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                    XmlRespose.AddError(Response, "error", String.Format("PrimasPolizasContratadasSegPersonalesNuevaProduccion Error en '{0}'", ex.Message))
                Else
                    XmlRespose.AddError(Response, "error", String.Format("PrimasPolizasContratadasSegPersonalesNuevaProduccion {1} Error en '{0}'", ex.Message, RowNumber))
                End If
            End Try
        Next
        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonalesNuevaProduccion
            .TotalPriSegPersonales = MontoDecimal(Total)
        End With
        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegPersonalesNuevaProduccion.DesglosePrimasPolizasContratadasSegPersonalesNuevaProduccion
            .TotalAgenSegNoVinculadoExclusivo = MontoDecimal(TotalAgenSegNoVinculadoExclusivo)
            .TotalAgenSegNoVinculadosNoExclusivo = MontoDecimal(TotalAgenSegNoVinculadosNoExclusivo)
            .TotalSocAgenSegExclusiva = MontoDecimal(TotalSocAgenSegExclusiva)
            .TotalSocAgenSegNoExclusiva = MontoDecimal(TotalSocAgenSegNoExclusiva)
            .TotalSocCorredoraSeg = MontoDecimal(TotalSocCorredoraSeg)
            .TotalOperSegAutoexpedibleExclusivo = MontoDecimal(TotalOperSegAutoexpedibleExclusivo)
            .TotalOperSegAutoexpedibleNoExclusivo = MontoDecimal(TotalOperSegAutoexpedibleNoExclusivo)
            .TotalProveTransfronterizosSeg = MontoDecimal(TotalProveTransfronterizosSeg)
            .TotalOfiEntAseguradora = MontoDecimal(TotalOfiEntAseguradora)
        End With
    End Sub

    Private Sub PrimasPolizasContratadasSegGeneralesNuevaProduccion(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccionPrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamoDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo
        Dim preitem As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccion
        Dim TotalAgenSegNoVinculadoExclusivo As Decimal = 0
        Dim TotalAgenSegNoVinculadosNoExclusivo As Decimal = 0
        Dim TotalSocAgenSegExclusiva As Decimal = 0
        Dim TotalSocAgenSegNoExclusiva As Decimal = 0
        Dim TotalSocCorredoraSeg As Decimal = 0
        Dim TotalOperSegAutoexpedibleExclusivo As Decimal = 0
        Dim TotalOperSegAutoexpedibleNoExclusivo As Decimal = 0
        Dim TotalProveTransfronterizosSeg As Decimal = 0
        Dim TotalOfiEntAseguradora As Decimal = 0
        Dim Total As Decimal = 0

        For RowNumber As Integer = 2 To 1000
            Try
                value = sheet.Cell(RowNumber, 1).Value
                If value.IsNotEmpty AndAlso value.Equals("Primas Polizas Contratadas Seg Generales Nueva Produccion", StringComparison.CurrentCultureIgnoreCase) Then
                    item = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccionPrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamoDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo
                    If _Canales.Datos.Modelo.PrimasPolizasContratadasSegGeneralesNuevaProduccion.DesglosePrimasPolizasContratadasSegGeneralesNuevaProduccion.RamoPrimasPolizasContratadasSegGeneralesNuevaProduccion.IsEmpty Then
                        ReDim Preserve _Canales.Datos.Modelo.PrimasPolizasContratadasSegGeneralesNuevaProduccion.DesglosePrimasPolizasContratadasSegGeneralesNuevaProduccion.RamoPrimasPolizasContratadasSegGeneralesNuevaProduccion(0)
                    Else
                        ReDim Preserve _Canales.Datos.Modelo.PrimasPolizasContratadasSegGeneralesNuevaProduccion.DesglosePrimasPolizasContratadasSegGeneralesNuevaProduccion.RamoPrimasPolizasContratadasSegGeneralesNuevaProduccion(UBound(_Canales.Datos.Modelo.PrimasPolizasContratadasSegGeneralesNuevaProduccion.DesglosePrimasPolizasContratadasSegGeneralesNuevaProduccion.RamoPrimasPolizasContratadasSegGeneralesNuevaProduccion) + 1)
                    End If
                    preitem = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccion
                    preitem.PrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo = New ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccionPrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo
                    preitem.PrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo.DesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo = item
                    _Canales.Datos.Modelo.PrimasPolizasContratadasSegGeneralesNuevaProduccion.DesglosePrimasPolizasContratadasSegGeneralesNuevaProduccion.RamoPrimasPolizasContratadasSegGeneralesNuevaProduccion(UBound(_Canales.Datos.Modelo.PrimasPolizasContratadasSegGeneralesNuevaProduccion.DesglosePrimasPolizasContratadasSegGeneralesNuevaProduccion.RamoPrimasPolizasContratadasSegGeneralesNuevaProduccion)) = preitem

                    Try
                        preitem.id = [Enum].Parse(GetType(TipoRamoGenerales), sheet.Cell(RowNumber, 2).Value)
                    Catch ex As Exception
                        preitem.id = Canales.TipoRamoGenerales.G01
                    End Try
                    With item
                        .AgenSegNoVinculadoExclusivo = sheet.DecimalValue(RowNumber, 3, "0.00")
                        .AgenSegNoVinculadosNoExclusivo = sheet.DecimalValue(RowNumber, 4, "0.00")
                        .SocAgenSegExclusiva = sheet.DecimalValue(RowNumber, 5, "0.00")
                        .SocAgenSegNoExclusiva = sheet.DecimalValue(RowNumber, 6, "0.00")
                        .SocCorredoraSeg = sheet.DecimalValue(RowNumber, 7, "0.00")
                        .OperSegAutoexpedibleExclusivo = sheet.DecimalValue(RowNumber, 8, "0.00")
                        .OperSegAutoexpedibleNoExclusivo = sheet.DecimalValue(RowNumber, 9, "0.00")
                        .ProveTransfronterizosSeg = sheet.DecimalValue(RowNumber, 10, "0.00")
                        .OfiEntAseguradora = sheet.DecimalValue(RowNumber, 11, "0.00")

                        .AgenSegNoVinculadoExclusivoSpecified = True
                        .AgenSegNoVinculadosNoExclusivoSpecified = True
                        .SocAgenSegExclusivaSpecified = True
                        .SocAgenSegNoExclusivaSpecified = True
                        .SocCorredoraSegSpecified = True
                        .OperSegAutoexpedibleExclusivoSpecified = True
                        .OperSegAutoexpedibleNoExclusivoSpecified = True
                        .ProveTransfronterizosSegSpecified = True
                        .OfiEntAseguradoraSpecified = True
                    End With
                    'Total += sheet.DecimalValue(RowNumber, 3, "0.00") +
                    '            sheet.DecimalValue(RowNumber, 4, "0.00") +
                    '            sheet.DecimalValue(RowNumber, 5, "0.00") +
                    '            sheet.DecimalValue(RowNumber, 6, "0.00") +
                    '            sheet.DecimalValue(RowNumber, 7, "0.00") +
                    '            sheet.DecimalValue(RowNumber, 8, "0.00") +
                    '            sheet.DecimalValue(RowNumber, 9, "0.00") +
                    '            sheet.DecimalValue(RowNumber, 10, "0.00") +
                    '            sheet.DecimalValue(RowNumber, 11, "0.00")

                    Total += sheet.DecimalValue(RowNumber, 3, "0.00") +
                             sheet.DecimalValue(RowNumber, 4, "0.00") +
                             sheet.DecimalValue(RowNumber, 5, "0.00") +
                             sheet.DecimalValue(RowNumber, 6, "0.00") +
                             sheet.DecimalValue(RowNumber, 7, "0.00") +
                             sheet.DecimalValue(RowNumber, 8, "0.00") +
                             sheet.DecimalValue(RowNumber, 9, "0.00") +
                             sheet.DecimalValue(RowNumber, 10, "0.00") +
                             sheet.DecimalValue(RowNumber, 11, "0.00")

                    TotalAgenSegNoVinculadoExclusivo += sheet.DecimalValue(RowNumber, 3, "0.00")
                    TotalAgenSegNoVinculadosNoExclusivo += sheet.DecimalValue(RowNumber, 4, "0.00")
                    TotalSocAgenSegExclusiva += sheet.DecimalValue(RowNumber, 5, "0.00")
                    TotalSocAgenSegNoExclusiva += sheet.DecimalValue(RowNumber, 6, "0.00")
                    TotalSocCorredoraSeg += sheet.DecimalValue(RowNumber, 7, "0.00")
                    TotalOperSegAutoexpedibleExclusivo += sheet.DecimalValue(RowNumber, 8, "0.00")
                    TotalOperSegAutoexpedibleNoExclusivo += sheet.DecimalValue(RowNumber, 9, "0.00")
                    TotalProveTransfronterizosSeg += sheet.DecimalValue(RowNumber, 10, "0.00")
                    TotalOfiEntAseguradora += sheet.DecimalValue(RowNumber, 11, "0.00")
                    With preitem.PrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo
                        .Total = MontoDecimal(sheet.DecimalValue(RowNumber, 3, "0.00") +
                                 sheet.DecimalValue(RowNumber, 4, "0.00") +
                                 sheet.DecimalValue(RowNumber, 5, "0.00") +
                                 sheet.DecimalValue(RowNumber, 6, "0.00") +
                                 sheet.DecimalValue(RowNumber, 7, "0.00") +
                                 sheet.DecimalValue(RowNumber, 8, "0.00") +
                                 sheet.DecimalValue(RowNumber, 9, "0.00") +
                                 sheet.DecimalValue(RowNumber, 10, "0.00") +
                                 sheet.DecimalValue(RowNumber, 11, "0.00"))

                    End With
                ElseIf value.IsEmpty Then
                    Exit For
                End If
            Catch ex As Exception
                If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                    XmlRespose.AddError(Response, "error", String.Format("PrimasPolizasContratadasSegGeneralesNuevaProduccion Error en '{0}'", ex.Message))
                Else
                    XmlRespose.AddError(Response, "error", String.Format("PrimasPolizasContratadasSegGeneralesNuevaProduccion {1} Error en '{0}'", ex.Message, RowNumber))
                End If
            End Try
        Next
        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegGeneralesNuevaProduccion
            .TotalPriSegGenerales = MontoDecimal(Total)
        End With
        With _Canales.Datos.Modelo.PrimasPolizasContratadasSegGeneralesNuevaProduccion.DesglosePrimasPolizasContratadasSegGeneralesNuevaProduccion
            .TotalAgenSegNoVinculadoExclusivo = MontoDecimal(TotalAgenSegNoVinculadoExclusivo)
            .TotalAgenSegNoVinculadosNoExclusivo = MontoDecimal(TotalAgenSegNoVinculadosNoExclusivo)
            .TotalSocAgenSegExclusiva = MontoDecimal(TotalSocAgenSegExclusiva)
            .TotalSocAgenSegNoExclusiva = MontoDecimal(TotalSocAgenSegNoExclusiva)
            .TotalSocCorredoraSeg = MontoDecimal(TotalSocCorredoraSeg)
            .TotalOperSegAutoexpedibleExclusivo = MontoDecimal(TotalOperSegAutoexpedibleExclusivo)
            .TotalOperSegAutoexpedibleNoExclusivo = MontoDecimal(TotalOperSegAutoexpedibleNoExclusivo)
            .TotalProveTransfronterizosSeg = MontoDecimal(TotalProveTransfronterizosSeg)
            .TotalOfiEntAseguradora = MontoDecimal(TotalOfiEntAseguradora)
        End With
    End Sub

#End Region

#Region "Parte II"

    Private Sub OficinasAseguradoraNuevaProd(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloCanalesDatosModeloDetalleOficina

        For RowNumber As Integer = 3 To 1000
            Try

                value = sheet.Cell(RowNumber, 1).Value
                If value.IsNotEmpty Then
                    item = New ModeloCanalesDatosModeloDetalleOficina
                    If _Canales.Datos.Modelo.OficinasAseguradoraNuevaProd.IsEmpty Then
                        ReDim Preserve _Canales.Datos.Modelo.OficinasAseguradoraNuevaProd(0)
                    Else
                        ReDim Preserve _Canales.Datos.Modelo.OficinasAseguradoraNuevaProd(UBound(_Canales.Datos.Modelo.OficinasAseguradoraNuevaProd) + 1)
                    End If

                    _Canales.Datos.Modelo.OficinasAseguradoraNuevaProd(UBound(_Canales.Datos.Modelo.OficinasAseguradoraNuevaProd)) = item

                    With item
                        Try
                            .Domicilio = [Enum].Parse(GetType(Canton), sheet.Cell(RowNumber, 1).Value)
                        Catch ex As Exception
                            .Domicilio = Canales.Canton.Item101
                        End Try
                        .NumEmpleados = MontoFormat(sheet.Cell(RowNumber, 2).Value)
                        .PrimasPolizasContratadasNuevaProd = MontoFormat(sheet.Cell(RowNumber, 3).Value)
                    End With
                ElseIf value.IsEmpty Then
                    Exit For
                End If
            Catch ex As Exception
                If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                    XmlRespose.AddError(Response, "error", String.Format("OficinasAseguradoraNuevaProd Error en '{0}'", ex.Message))
                Else
                    XmlRespose.AddError(Response, "error", String.Format("OficinasAseguradoraNuevaProd {1} Error en '{0}'", ex.Message, RowNumber))
                End If
            End Try
        Next
    End Sub

    Private Sub NumContratosAgenciasCierreAnno(sheet As IXLWorksheet)
        Dim value As String = String.Empty

        For RowNumber As Integer = 3 To 3
            Try

                value = sheet.Cell(RowNumber, 6).Value
                If value.IsNotEmpty Then
                    With _Canales.Datos.Modelo.AgenSegNoVinculadosSocAgenSeg.NumContratosAgenciasCierreAnno.DesgloseNumContratosAgenciasCierreAnno
                        .AgenSegNoVinculadosExclusivos = MontoFormat(sheet.Cell(RowNumber, 6).Value)
                        .AgenSegNoVinculadosNoExclusivos = MontoFormat(sheet.Cell(RowNumber, 7).Value)
                        .SocAgenSegExclusiva = MontoFormat(sheet.Cell(RowNumber, 8).Value)
                        .SocAgenSegNoExclusiva = MontoFormat(sheet.Cell(RowNumber, 9).Value)
                    End With
                    _Canales.Datos.Modelo.AgenSegNoVinculadosSocAgenSeg.NumContratosAgenciasCierreAnno.Total = sheet.Cell(RowNumber, 6).Value.ToString() +
                                                                                                               sheet.Cell(RowNumber, 7).Value.ToString() +
                                                                                                               sheet.Cell(RowNumber, 8).Value.ToString() +
                                                                                                               sheet.Cell(RowNumber, 9).Value.ToString()
                End If
            Catch ex As Exception
                If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                    XmlRespose.AddError(Response, "error", String.Format("NumContratosAgenciasCierreAnno Error en '{0}'", ex.Message))
                Else
                    XmlRespose.AddError(Response, "error", String.Format("NumContratosAgenciasCierreAnno {1} Error en '{0}'", ex.Message, RowNumber))
                End If
            End Try
        Next
    End Sub

    Private Sub NumAgenSocAportaronDuranteAnno(sheet As IXLWorksheet)
        Dim value As String = String.Empty

        For RowNumber As Integer = 4 To 4
            Try
                value = sheet.Cell(RowNumber, 6).Value
                If value.IsNotEmpty Then
                    With _Canales.Datos.Modelo.AgenSegNoVinculadosSocAgenSeg.NumAgenSocAportaronDuranteAnno.DesgloseNumAgenSocAportaronDuranteAnno
                        .AgenSegNoVinculadosExclusivos = MontoFormat(sheet.Cell(RowNumber, 6).Value)
                        .AgenSegNoVinculadosNoExclusivos = MontoFormat(sheet.Cell(RowNumber, 7).Value)
                        .SocAgenSegExclusiva = MontoFormat(sheet.Cell(RowNumber, 8).Value)
                        .SocAgenSegNoExclusiva = MontoFormat(sheet.Cell(RowNumber, 9).Value)
                    End With
                    _Canales.Datos.Modelo.AgenSegNoVinculadosSocAgenSeg.NumAgenSocAportaronDuranteAnno.Total = sheet.Cell(RowNumber, 6).Value.ToString() +
                                                                                                               sheet.Cell(RowNumber, 7).Value.ToString() +
                                                                                                               sheet.Cell(RowNumber, 8).Value.ToString() +
                                                                                                               sheet.Cell(RowNumber, 9).Value.ToString()
                End If
            Catch ex As Exception
                If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                    XmlRespose.AddError(Response, "error", String.Format("NumAgenSocAportaronDuranteAnno Error en '{0}'", ex.Message))
                Else
                    XmlRespose.AddError(Response, "error", String.Format("NumAgenSocAportaronDuranteAnno {1} Error en '{0}'", ex.Message, RowNumber))
                End If
            End Try
        Next
    End Sub

    Private Sub SociedadesCorredorasSeg(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim oldVvalue As String = String.Empty
        Dim item As ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredora
        Dim witherror As Boolean = False
        Dim id As String = String.Empty

        For RowNumber As Integer = 3 To 1000
            Try

                value = sheet.StringValue(RowNumber, "K")
                If value.IsNotEmpty Then
                    If value <> oldVvalue Then
                        item = New ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredora
                        If _Canales.Datos.Modelo.SociedadesCorredorasSeg.DetalleSocCorredora.IsEmpty Then
                            ReDim Preserve _Canales.Datos.Modelo.SociedadesCorredorasSeg.DetalleSocCorredora(0)
                        Else
                            ReDim Preserve _Canales.Datos.Modelo.SociedadesCorredorasSeg.DetalleSocCorredora(UBound(_Canales.Datos.Modelo.SociedadesCorredorasSeg.DetalleSocCorredora) + 1)
                        End If

                        _Canales.Datos.Modelo.SociedadesCorredorasSeg.DetalleSocCorredora(UBound(_Canales.Datos.Modelo.SociedadesCorredorasSeg.DetalleSocCorredora)) = item

                        With item
                            .DenominacionSoc = sheet.StringValue(RowNumber, "K")

                            .CodAutorizacion = sheet.EnumValue(Of Corredora)(RowNumber, "L", witherror)
                            If witherror Then
                                XmlRespose.AddError(Response, "error", String.Format("El CodAutorizacion '{0}' no es valido.", sheet.Cell(RowNumber, "L").Value))
                            End If
                        End With
                        _Canales.Datos.Modelo.SociedadesCorredorasSeg.NumSociedadesIncorporadas = UBound(_Canales.Datos.Modelo.SociedadesCorredorasSeg.DetalleSocCorredora) + 1
                        oldVvalue = value
                    End If
                    id = sheet.StringValue(RowNumber, "M")

                    If id <> "P14" AndAlso id <> "P15" AndAlso id <> "P18" AndAlso id <> "P19" AndAlso id <> "P20" AndAlso id <> "P22" AndAlso id <> "P23" Then
                        'Seguros Generales
                        If item.DetalleSegurosGeneralesPorRamo.IsEmpty Then
                            item.DetalleSegurosGeneralesPorRamo = New Canales.ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosGeneralesPorRamo()
                        End If
                        If item.DetalleSegurosGeneralesPorRamo.RamoSegurosGenerales.IsEmpty Then
                            ReDim Preserve item.DetalleSegurosGeneralesPorRamo.RamoSegurosGenerales(0)
                        Else
                            ReDim Preserve item.DetalleSegurosGeneralesPorRamo.RamoSegurosGenerales(UBound(item.DetalleSegurosGeneralesPorRamo.RamoSegurosGenerales) + 1)
                        End If
                        Dim NSG As New Canales.ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosGeneralesPorRamoRamoSegurosGenerales
                        item.DetalleSegurosGeneralesPorRamo.RamoSegurosGenerales(UBound(item.DetalleSegurosGeneralesPorRamo.RamoSegurosGenerales)) = NSG
                        With NSG
                            .id = sheet.EnumValue(Of TipoRamoGenerales)(RowNumber, "M", witherror)
                            If witherror Then
                                XmlRespose.AddError(Response, "error", String.Format("El TipoRamoGenerales para id '{0}' no es valido.", sheet.Cell(RowNumber, "M").Value))
                            End If
                            .MontoPrimasColocadas = sheet.DecimalValue(RowNumber, "N", "0.00")
                        End With
                        item.DetalleSegurosGeneralesPorRamo.TotalMontoPrimasColocadas += NSG.MontoPrimasColocadas
                    Else
                        'Seguros Personales
                        If item.DetalleSegurosPersonalesPorRamo.IsEmpty Then
                            item.DetalleSegurosPersonalesPorRamo = New Canales.ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosPersonalesPorRamo()
                        End If
                        If item.DetalleSegurosPersonalesPorRamo.RamoSegurosPersonales.IsEmpty Then
                            ReDim Preserve item.DetalleSegurosPersonalesPorRamo.RamoSegurosPersonales(0)
                        Else
                            ReDim Preserve item.DetalleSegurosPersonalesPorRamo.RamoSegurosPersonales(UBound(item.DetalleSegurosPersonalesPorRamo.RamoSegurosPersonales) + 1)
                        End If
                        Dim NSP As New Canales.ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosPersonalesPorRamoRamoSegurosPersonales
                        item.DetalleSegurosPersonalesPorRamo.RamoSegurosPersonales(UBound(item.DetalleSegurosPersonalesPorRamo.RamoSegurosPersonales)) = NSP
                        With NSP
                            .id = sheet.EnumValue(Of TipoRamoPersonales)(RowNumber, "M", witherror)
                            If witherror Then
                                XmlRespose.AddError(Response, "error", String.Format("El TipoRamoPersonales para id '{0}' no es valido.", sheet.Cell(RowNumber, "M").Value))
                            End If
                            .MontoPrimasColocadas = sheet.DecimalValue(RowNumber, "N", "0.00")
                        End With
                        item.DetalleSegurosPersonalesPorRamo.TotalMontoPrimasColocadas += NSP.MontoPrimasColocadas
                    End If
                Else
                    Exit For
                End If
            Catch ex As Exception
                If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                    XmlRespose.AddError(Response, "error", String.Format("SociedadesCorredorasSeg Error en '{0}'", ex.Message))
                Else
                    XmlRespose.AddError(Response, "error", String.Format("SociedadesCorredorasSeg {1} Error en '{0}'", ex.Message, RowNumber))
                End If
            End Try
        Next
    End Sub

    Private Sub PolizasPagadas(sheet As IXLWorksheet)
        Dim value As String = String.Empty

        For RowNumber As Integer = 3 To 3
            Try
                value = sheet.Cell(RowNumber, 15).Value
                If value.IsNotEmpty Then
                    With _Canales.Datos.Modelo.SeguroObligatorioAutomoviles.PolizasPagadas
                        .BancosPublicos = sheet.DecimalValue(RowNumber, "Q", "0") 'MontoEnteroOptionalFormat(sheet.Cell(RowNumber, 15).Value)
                        .BancosPrivados = sheet.DecimalValue(RowNumber, "R", "0") 'MontoEnteroOptionalFormat(sheet.Cell(RowNumber, 16).Value)
                        .Cooperativas = sheet.DecimalValue(RowNumber, "S", "0") 'MontoEnteroOptionalFormat(sheet.Cell(RowNumber, 17).Value)
                        .OtrasPersonasFisicas = sheet.DecimalValue(RowNumber, "T", "0") 'MontoEnteroOptionalFormat(sheet.Cell(RowNumber, 18).Value)
                        .OtrasPersonasJuridicas = sheet.DecimalValue(RowNumber, "U", "0") 'MontoEnteroOptionalFormat(sheet.Cell(RowNumber, 19).Value)
                        .OficinasEntidad = sheet.DecimalValue(RowNumber, "V", "0") 'MontoEnteroOptionalFormat(sheet.Cell(RowNumber, 20).Value)
                    End With
                End If
            Catch ex As Exception
                If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                    XmlRespose.AddError(Response, "error", String.Format("PolizasPagadas Error en '{0}'", ex.Message))
                Else
                    XmlRespose.AddError(Response, "error", String.Format("PolizasPagadas {1} Error en '{0}'", ex.Message, RowNumber))
                End If
            End Try
        Next
    End Sub

    Private Sub MontoPrima(sheet As IXLWorksheet)
        Dim value As String = String.Empty

        For RowNumber As Integer = 4 To 4
            Try
                value = sheet.Cell(RowNumber, 15).Value
                If value.IsNotEmpty Then
                    With _Canales.Datos.Modelo.SeguroObligatorioAutomoviles.MontoPrima
                        .BancosPublicos = sheet.DecimalValue(RowNumber, "Q", "0") 'MontoDecimalOptionalFormat(sheet.Cell(RowNumber, 15).Value, 0)
                        .BancosPrivados = sheet.DecimalValue(RowNumber, "R", "0") 'MontoDecimalOptionalFormat(sheet.Cell(RowNumber, 16).Value, 0)
                        .Cooperativas = sheet.DecimalValue(RowNumber, "S", "0") 'MontoDecimalOptionalFormat(sheet.Cell(RowNumber, 17).Value, 0)
                        .OtrasPersonasFisicas = sheet.DecimalValue(RowNumber, "T", "0") 'MontoDecimalOptionalFormat(sheet.Cell(RowNumber, 18).Value, 0)
                        .OtrasPersonasJuridicas = sheet.DecimalValue(RowNumber, "U", "0") 'MontoDecimalOptionalFormat(sheet.Cell(RowNumber, 19).Value, 0)
                        .OficinasEntidad = sheet.DecimalValue(RowNumber, "V", "0") 'MontoDecimalOptionalFormat(sheet.Cell(RowNumber, 20).Value, 0)
                    End With
                End If
            Catch ex As Exception
                If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                    XmlRespose.AddError(Response, "error", String.Format("MontoPrima Error en '{0}'", ex.Message))
                Else
                    XmlRespose.AddError(Response, "error", String.Format("MontoPrima {1} Error en '{0}'", ex.Message, RowNumber))
                End If
            End Try
        Next
    End Sub

    Public Shared Function Execute(xlsxFileName As String, xmlFileName As String, pediodoTrimestral As Integer, ano As Integer) As DataTable
        Dim result As DataTable = Nothing
        With New Generate(New Date(ano, pediodoTrimestral * 3, 1).LastDayOfMonth, Periodicidad.T)
            .LoadExcelInformation(xlsxFileName)
            .FileSerialize(xmlFileName, False)
            result = .Response
        End With
        Return result
    End Function

#End Region

End Class