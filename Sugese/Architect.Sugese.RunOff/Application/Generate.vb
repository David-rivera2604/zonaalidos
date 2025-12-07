Imports System.Configuration
Imports Architect.API.Core.Business
Imports Architect.Sugese.Domain
Imports Architect.Sugese.Utility
Imports Architect.Utilities.Extensions
Imports ClosedXML.Excel
Imports SixLabors.Fonts

Public Class Generate
    Inherits Architect.Sugese.Domain.GenerateBase
    Public Sub LoadExcelInformation(excelFilename As String)
        Dim workbook As New XLWorkbook(excelFilename)
        Dim sheet As IXLWorksheet = Nothing

        'Siniestros
        sheet = workbook.Worksheet("Siniestros")
        DesglosePendInicioEjercicioPendCierrePeriodoRamo(sheet)
        DesglosePendInicioEjercicioTermCierrePeriodoRamo(sheet)
        DesgloseOcurridosPeriodoPendientesCierrePeriodoRamo(sheet)
        DesgloseOcurridosPeriodoTerminadosPeriodoRamo(sheet)
        DesglosePendientesDeclaracionRamo(sheet)

        'Sección II
        sheet = workbook.Worksheet("Sección II")
        DesglosePrimasYProvisionPrimasNoDevengadasRamo(sheet)
        DesglosePolizasPeriodoRamo(sheet)

        'Suficiencia
        sheet = workbook.Worksheet("Suficiencia")
        AnnoActual(sheet)

        'Modelo Estadistico
        sheet = workbook.Worksheet("Estadistico")
        ModeloEstadistico(sheet)

        sheet = Nothing
        workbook = Nothing
    End Sub

    Private _RunOff As New ModeloRunOff

    Public Property Response As DataTable

#Region "Builder"

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="periodo">Fecha correspondiente al período al cual corresponde el modelo</param>
    ''' <param name="periodicidad">Corresponde a la periodicidad del modelo</param>
    ''' <remarks></remarks>
    Public Sub New(periodo As Date, periodicidad As RunOff.Periodicidad)
        ModelInit()
        With _RunOff.Encabezado
            .NombreArchivo = String.Format("{0}-ModeloRunOff", "sugese.codigoaseguradora".StringValue(0, "A03"))
            .Fecha = Today.ToString("yyyy-MM-dd")
            .Periodo = periodo.ToString("yyyy-MM-dd")
            .Periodicidad = periodicidad
            .Moneda = RunOff.CodMoneda.Item1
        End With
        _RunOff.Datos.Modelo.EntidadFuente = ConfigurationManager.AppSettings("sugese.codigoaseguradora")
        Me.Response = Helpers.XmlRespose.ReponseDataTable
    End Sub

    Public Function Serialize(withFormat As Boolean) As String
        Return Utilities.SerializeHandler(Of RunOff.ModeloRunOff).Serialize(_RunOff)
    End Function

    Public Sub FileSerialize(filename As String, withFormat As Boolean)
        Utilities.SerializeHandler(Of RunOff.ModeloRunOff).SerializeToFile(_RunOff, filename, withFormat)

        Dim result As List(Of String) = Nothing
        'Validación según el XSD enviado por la sugese
        result = Validate.XsdValidate("ModeloRunOff", filename)
        If Response.IsNotEmpty AndAlso Response.Rows.IsNotEmpty Then
            For Each item As DataRow In Response.Rows
                result.Add(item.StringValue("message"))
            Next
        End If
        If result.Count > 0 Then

            Utilities.SerializeHandler(Of List(Of String)).SerializeToFile(result, IO.Path.GetDirectoryName(filename) & "\" & IO.Path.GetFileNameWithoutExtension(filename) & ".error.xml", True)

            For Each item As String In result
                Helpers.XmlRespose.AddError(Response, "error", item)
            Next
        End If
    End Sub

    Private Sub ModelInit()
        _RunOff = New ModeloRunOff
        With _RunOff
            .Encabezado = New ModeloRunOffEncabezado
            .Datos = New ModeloRunOffDatos
        End With
        With _RunOff.Encabezado
            .NombreArchivo = String.Empty
            .Fecha = String.Empty
            .Periodo = String.Empty
            .Periodicidad = Periodicidad.T
            .Moneda = CodMoneda.Item1
        End With

        With _RunOff.Datos
            .Modelo = New ModeloRunOffDatosModelo
        End With
        With _RunOff.Datos.Modelo
            .Siniestros = New ModeloRunOffDatosModeloSiniestros
            .PrimasYProvisionPrimasNoDevengadas = New ModeloRunOffDatosModeloPrimasYProvisionPrimasNoDevengadas
            .PolizasPeriodo = New ModeloRunOffDatosModeloPolizasPeriodo
            .Suficiencia = New ModeloRunOffDatosModeloSuficiencia
            .EntidadFuente = String.Empty
        End With
        With _RunOff.Datos.Modelo.Siniestros
            .PendInicioEjercicioPendCierrePeriodo = New ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioPendCierrePeriodo
            .PendInicioEjercicioTermCierrePeriodo = New ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioTermCierrePeriodo
            .OcurridosPeriodoPendientesCierrePeriodo = New ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoPendientesCierrePeriodo
            .OcurridosPeriodoTerminadosPeriodo = New ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoTerminadosPeriodo
            .PendientesDeclaracion = New ModeloRunOffDatosModeloSiniestrosPendientesDeclaracion
        End With
        With _RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioPendCierrePeriodo
            '.DesglosePendInicioEjercicioPendCierrePeriodoRamo(0) = New ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioPendCierrePeriodoDesglosePendInicioEjercicioPendCierrePeriodoRamo
            .TotalNumSiniestros = 0
            .TotalImportePagadoComienzo = 0
            .TotalProvisionComienzo = 0
            .TotalImportePagadoPeriodo = 0
            .TotalProvisionCierrePeriodo = 0
        End With

        With _RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioTermCierrePeriodo
            '.DesglosePendInicioEjercicioTermCierrePeriodoRamo(0) = New ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioTermCierrePeriodoDesglosePendInicioEjercicioTermCierrePeriodoRamo
            .TotalNumSiniestrosConPago = 0
            .TotalNumSiniestrosSinPago = 0
            .TotalImportePagadoComienzo = 0
            .TotalProvisionComienzo = 0
            .TotalImportePagadoPeriodo = 0
        End With

        With _RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoPendientesCierrePeriodo
            '.DesgloseOcurridosPeriodoPendientesCierrePeriodoRamo(0) = New ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoPendientesCierrePeriodoDesgloseOcurridosPeriodoPendientesCierrePeriodoRamo
            .TotalNumSiniestros = 0
            .TotalImportePagado = 0
            .TotalProvisionCierre = 0
        End With

        With _RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoTerminadosPeriodo
            '.DesgloseOcurridosPeriodoTerminadosPeriodoRamo(0) = New ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoTerminadosPeriodoDesgloseOcurridosPeriodoTerminadosPeriodoRamo
            .TotalNumSiniestrosConPago = 0
            .TotalNumSiniestrosSinPago = 0
            .TotalImportePagado = 0
        End With

        With _RunOff.Datos.Modelo.Siniestros.PendientesDeclaracion
            '.DesglosePendientesDeclaracionRamo(0) = New ModeloRunOffDatosModeloSiniestrosPendientesDeclaracionDesglosePendientesDeclaracionRamo
            .TotalProvisionOYNRComienzoPeriodo = 0
            .TotalProvisionOYNRResidualCierre = 0
            .TotalProvisionOYNRCierrePeriodo = 0
            .TotalPendCierreNumSiniestros = 0
            .TotalPendCierreImportePagadoPeriodo = 0
            .TotalPendCierreProvisionCierre = 0
            .TotalTermPeriodoNumSiniestrosConPago = 0
            .TotalTermPeriodoNumSiniestrosSinPago = 0
            .TotalTermPeriodoImportePagado = 0
        End With

        With _RunOff.Datos.Modelo.PrimasYProvisionPrimasNoDevengadas
            '.DesglosePrimasYProvisionPrimasNoDevengadasRamo(0) = New ModeloRunOffDatosModeloPrimasYProvisionPrimasNoDevengadasDesglosePrimasYProvisionPrimasNoDevengadasRamo
            .TotalPrimasEmitidas = 0
            .TotalPrimasAnuladas = 0
            .TotalPrimasNoRenovadas = 0
            .TotalProvisionComienzo = 0
            .TotalProvisionCierre = 0
        End With

        With _RunOff.Datos.Modelo.PolizasPeriodo
            '.DesglosePolizasPeriodoRamo(0) = New ModeloRunOffDatosModeloPolizasPeriodoDesglosePolizasPeriodoRamo
            .TotalExistentesInicio = 0
            .TotalEmitidasPeriodo = 0
            .TotalAnuladasPeriodo = 0
            .TotalNoRenovadasPeriodo = 0
            .TotalExistentesCierre = 0
            .TotalVencidasPeriodo = 0
        End With

        With _RunOff.Datos.Modelo.Suficiencia
            .AnnoActual = New ModeloRunOffDatosModeloSuficienciaAnnoActual
            .AnnoActualMenosUno = New ModeloRunOffDatosModeloSuficienciaAnnoActualMenosUno
            .AnnoActualMenosDos = New ModeloRunOffDatosModeloSuficienciaAnnoActualMenosDos
            .AnnoActualMenosTres = New ModeloRunOffDatosModeloSuficienciaAnnoActualMenosTres
            .AnnoActualMenosCuatro = New ModeloRunOffDatosModeloSuficienciaAnnoActualMenosCuatro
            .AnnoActualMenosCinco = New ModeloRunOffDatosModeloSuficienciaAnnoActualMenosCinco
        End With
        With _RunOff.Datos.Modelo.Suficiencia.AnnoActual
            .Anno = String.Empty
            .ImportePagado = 0
            .ProvisionFinalPeriodo = 0
            .RecobrosEfectuados = 0
            .NumSiniestrosReportados = 0
            .NumSiniestrosReabiertos = 0
            .NumSiniestrosPendientes = 0
        End With

        With _RunOff.Datos.Modelo.Suficiencia.AnnoActualMenosUno
            .Anno = String.Empty
            .ImportePagado = 0
            .ProvisionFinalPeriodo = 0
            .RecobrosEfectuados = 0
            .NumSiniestrosReportados = 0
            .NumSiniestrosReabiertos = 0
            .NumSiniestrosPendientes = 0
        End With

        With _RunOff.Datos.Modelo.Suficiencia.AnnoActualMenosDos
            .Anno = String.Empty
            .ImportePagado = 0
            .ProvisionFinalPeriodo = 0
            .RecobrosEfectuados = 0
            .NumSiniestrosReportados = 0
            .NumSiniestrosReabiertos = 0
            .NumSiniestrosPendientes = 0
        End With

        With _RunOff.Datos.Modelo.Suficiencia.AnnoActualMenosTres
            .Anno = String.Empty
            .ImportePagado = 0
            .ProvisionFinalPeriodo = 0
            .RecobrosEfectuados = 0
            .NumSiniestrosReportados = 0
            .NumSiniestrosReabiertos = 0
            .NumSiniestrosPendientes = 0
        End With

        With _RunOff.Datos.Modelo.Suficiencia.AnnoActualMenosCuatro
            .Anno = String.Empty
            .ImportePagado = 0
            .ProvisionFinalPeriodo = 0
            .RecobrosEfectuados = 0
            .NumSiniestrosReportados = 0
            .NumSiniestrosReabiertos = 0
            .NumSiniestrosPendientes = 0
        End With

        With _RunOff.Datos.Modelo.Suficiencia.AnnoActualMenosCinco
            .Anno = String.Empty
            .ImportePagado = 0
            .ProvisionFinalPeriodo = 0
            .RecobrosEfectuados = 0
            .NumSiniestrosReportados = 0
            .NumSiniestrosReabiertos = 0
            .NumSiniestrosPendientes = 0
        End With

    End Sub

    Public Shared Function AddDesglosePendInicioEjercicioPendCierrePeriodoRamo(items As ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioPendCierrePeriodoDesglosePendInicioEjercicioPendCierrePeriodoRamo()) As ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioPendCierrePeriodoDesglosePendInicioEjercicioPendCierrePeriodoRamo
        Dim result As New ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioPendCierrePeriodoDesglosePendInicioEjercicioPendCierrePeriodoRamo
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .NumSiniestros = 0
            .ImportePagadoComienzo = 0
            .ProvisionComienzo = 0
            .ImportePagadoPeriodo = 0
            .ProvisionCierrePeriodo = 0
            .id = TipoRamo.G01
        End With

        Return result
    End Function

    Public Shared Function AddDesglosePendInicioEjercicioTermCierrePeriodoRamo(items As ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioTermCierrePeriodoDesglosePendInicioEjercicioTermCierrePeriodoRamo()) As ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioTermCierrePeriodoDesglosePendInicioEjercicioTermCierrePeriodoRamo
        Dim result As New ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioTermCierrePeriodoDesglosePendInicioEjercicioTermCierrePeriodoRamo
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .NumSiniestrosConPago = 0
            .NumSiniestrosSinPago = 0
            .ImportePagadoComienzo = 0
            .ProvisionComienzo = 0
            .ImportePagadoPeriodo = 0
            .id = TipoRamo.G01
        End With

        Return result
    End Function

    Public Shared Function AddDesgloseOcurridosPeriodoPendientesCierrePeriodoRamo(items As ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoPendientesCierrePeriodoDesgloseOcurridosPeriodoPendientesCierrePeriodoRamo()) As ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoPendientesCierrePeriodoDesgloseOcurridosPeriodoPendientesCierrePeriodoRamo
        Dim result As New ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoPendientesCierrePeriodoDesgloseOcurridosPeriodoPendientesCierrePeriodoRamo
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .NumSiniestros = 0
            .ImportePagado = 0
            .ProvisionCierre = 0
            .id = TipoRamo.G01
        End With

        Return result
    End Function

    Public Shared Function AddDesgloseOcurridosPeriodoTerminadosPeriodoRamo(items As ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoTerminadosPeriodoDesgloseOcurridosPeriodoTerminadosPeriodoRamo()) As ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoTerminadosPeriodoDesgloseOcurridosPeriodoTerminadosPeriodoRamo
        Dim result As New ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoTerminadosPeriodoDesgloseOcurridosPeriodoTerminadosPeriodoRamo
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .NumSiniestrosConPago = 0
            .NumSiniestrosSinPago = 0
            .ImportePagado = 0
            .id = TipoRamo.G01
        End With

        Return result
    End Function

    Public Shared Function AddDesglosePendientesDeclaracionRamo(items As ModeloRunOffDatosModeloSiniestrosPendientesDeclaracionDesglosePendientesDeclaracionRamo()) As ModeloRunOffDatosModeloSiniestrosPendientesDeclaracionDesglosePendientesDeclaracionRamo
        Dim result As New ModeloRunOffDatosModeloSiniestrosPendientesDeclaracionDesglosePendientesDeclaracionRamo
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .ProvisionOYNRComienzoEjercicio = 0
            .ProvisionOYNRResidualCierre = 0
            .ProvisionOYNRCierrePeriodo = 0
            .PendCierreNumSiniestros = 0
            .PendCierreImportePagadoPeriodo = 0
            .PendCierreProvisionCierre = 0
            .TermPeriodoNumSiniestrosConPago = 0
            .TermPeriodoNumSiniestrosSinPago = 0
            .TermPeriodoImportePagado = 0
            .id = TipoRamo.G01
        End With

        Return result
    End Function

    Public Shared Function AddDesglosePrimasYProvisionPrimasNoDevengadasRamo(items As ModeloRunOffDatosModeloPrimasYProvisionPrimasNoDevengadasDesglosePrimasYProvisionPrimasNoDevengadasRamo()) As ModeloRunOffDatosModeloPrimasYProvisionPrimasNoDevengadasDesglosePrimasYProvisionPrimasNoDevengadasRamo
        Dim result As New ModeloRunOffDatosModeloPrimasYProvisionPrimasNoDevengadasDesglosePrimasYProvisionPrimasNoDevengadasRamo
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .PrimasEmitidas = 0
            .PrimasAnuladas = 0
            .PrimasNoRenovadas = 0
            .ProvisionComienzo = 0
            .ProvisionCierre = 0
            .id = TipoRamo.G01
        End With

        Return result
    End Function

    Public Shared Function AddDesglosePolizasPeriodoRamo(items As ModeloRunOffDatosModeloPolizasPeriodoDesglosePolizasPeriodoRamo()) As ModeloRunOffDatosModeloPolizasPeriodoDesglosePolizasPeriodoRamo
        Dim result As New ModeloRunOffDatosModeloPolizasPeriodoDesglosePolizasPeriodoRamo
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .ExistentesInicio = 0
            .EmitidasPeriodo = 0
            .AnuladasPeriodo = 0
            .NoRenovadasPeriodo = 0
            .ExistentesCierre = 0
            .VencidasPeriodo = 0
            .id = TipoRamo.G01
        End With

        Return result
    End Function

#End Region

#Region "Siniestros"

    Private Sub DesglosePendInicioEjercicioPendCierrePeriodoRamo(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioPendCierrePeriodoDesglosePendInicioEjercicioPendCierrePeriodoRamo
        Dim TotalNumSiniestros As Decimal = 0
        Dim TotalImportePagadoComienzo As Decimal = 0
        Dim TotalProvisionComienzo As Decimal = 0
        Dim TotalImportePagadoPeriodo As Decimal = 0
        Dim TotalProvisionCierrePeriodo As Decimal = 0

        For RowNumber As Integer = 3 To 1000
            value = sheet.Cell(RowNumber, 1).Value
            If value.IsNotEmpty Then
                item = New ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioPendCierrePeriodoDesglosePendInicioEjercicioPendCierrePeriodoRamo
                If _RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioPendCierrePeriodo.DesglosePendInicioEjercicioPendCierrePeriodoRamo.IsEmpty Then
                    ReDim Preserve _RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioPendCierrePeriodo.DesglosePendInicioEjercicioPendCierrePeriodoRamo(0)
                Else
                    ReDim Preserve _RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioPendCierrePeriodo.DesglosePendInicioEjercicioPendCierrePeriodoRamo(UBound(_RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioPendCierrePeriodo.DesglosePendInicioEjercicioPendCierrePeriodoRamo) + 1)
                End If
                _RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioPendCierrePeriodo.DesglosePendInicioEjercicioPendCierrePeriodoRamo(UBound(_RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioPendCierrePeriodo.DesglosePendInicioEjercicioPendCierrePeriodoRamo)) = item
                With item
                    Try
                        .id = [Enum].Parse(GetType(TipoRamo), value)
                    Catch ex As Exception
                        .id = TipoRamo.G01
                    End Try

                    .NumSiniestros = sheet.DecimalValue(RowNumber, 2, "0.00")
                    .ImportePagadoComienzo = sheet.DecimalValue(RowNumber, 3, "0.00")
                    .ProvisionComienzo = sheet.DecimalValue(RowNumber, 4, "0.00")
                    .ImportePagadoPeriodo = sheet.DecimalValue(RowNumber, 5, "0.00")
                    .ProvisionCierrePeriodo = sheet.DecimalValue(RowNumber, 6, "0.00")

                End With
                TotalNumSiniestros += sheet.DecimalValue(RowNumber, 2, "0.00")
                TotalImportePagadoComienzo += sheet.DecimalValue(RowNumber, 3, "0.00")
                TotalProvisionComienzo += sheet.DecimalValue(RowNumber, 4, "0.00")
                TotalImportePagadoPeriodo += sheet.DecimalValue(RowNumber, 5, "0.00")
                TotalProvisionCierrePeriodo += sheet.DecimalValue(RowNumber, 6, "0.00")
            Else
                Exit For
            End If
        Next
        With _RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioPendCierrePeriodo
            .TotalNumSiniestros = TotalNumSiniestros.ToDecimalAmount()
            .TotalImportePagadoComienzo = TotalImportePagadoComienzo.ToDecimalAmount()
            .TotalProvisionComienzo = TotalProvisionComienzo.ToDecimalAmount()
            .TotalImportePagadoPeriodo = TotalImportePagadoPeriodo.ToDecimalAmount()
            .TotalProvisionCierrePeriodo = TotalProvisionCierrePeriodo.ToDecimalAmount()
        End With
    End Sub

    Private Sub DesglosePendInicioEjercicioTermCierrePeriodoRamo(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioTermCierrePeriodoDesglosePendInicioEjercicioTermCierrePeriodoRamo
        Dim TotalNumSiniestrosConPago As Decimal = 0
        Dim TotalNumSiniestrosSinPago As Decimal = 0
        Dim TotalImportePagadoComienzo As Decimal = 0
        Dim TotalProvisionComienzo As Decimal = 0
        Dim TotalImportePagadoPeriodo As Decimal = 0

        For RowNumber As Integer = 3 To 1000
            value = sheet.Cell(RowNumber, 8).Value
            If value.IsNotEmpty Then
                item = New ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioTermCierrePeriodoDesglosePendInicioEjercicioTermCierrePeriodoRamo
                If _RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioTermCierrePeriodo.DesglosePendInicioEjercicioTermCierrePeriodoRamo.IsEmpty Then

                    ReDim Preserve _RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioTermCierrePeriodo.DesglosePendInicioEjercicioTermCierrePeriodoRamo(0)
                Else
                    ReDim Preserve _RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioTermCierrePeriodo.DesglosePendInicioEjercicioTermCierrePeriodoRamo(UBound(_RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioTermCierrePeriodo.DesglosePendInicioEjercicioTermCierrePeriodoRamo) + 1)
                End If
                _RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioTermCierrePeriodo.DesglosePendInicioEjercicioTermCierrePeriodoRamo(UBound(_RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioTermCierrePeriodo.DesglosePendInicioEjercicioTermCierrePeriodoRamo)) = item
                With item
                    .id = [Enum].Parse(GetType(TipoRamo), value)

                    .NumSiniestrosConPago = sheet.DecimalValue(RowNumber, 9, "0.00")
                    .NumSiniestrosSinPago = sheet.DecimalValue(RowNumber, 10, "0.00")
                    .ImportePagadoComienzo = sheet.DecimalValue(RowNumber, 11, "0.00")
                    .ProvisionComienzo = sheet.DecimalValue(RowNumber, 12, "0.00")
                    .ImportePagadoPeriodo = sheet.DecimalValue(RowNumber, 13, "0.00")
                End With
                TotalNumSiniestrosConPago += sheet.DecimalValue(RowNumber, 9, "0.00")
                TotalNumSiniestrosSinPago += sheet.DecimalValue(RowNumber, 10, "0.00")
                TotalImportePagadoComienzo += sheet.DecimalValue(RowNumber, 11, "0.00")
                TotalProvisionComienzo += sheet.DecimalValue(RowNumber, 12, "0.00")
                TotalImportePagadoPeriodo += sheet.DecimalValue(RowNumber, 13, "0.00")
            Else
                Exit For
            End If
        Next
        With _RunOff.Datos.Modelo.Siniestros.PendInicioEjercicioTermCierrePeriodo
            .TotalNumSiniestrosConPago = TotalNumSiniestrosConPago.ToDecimalAmount()
            .TotalNumSiniestrosSinPago = TotalNumSiniestrosSinPago.ToDecimalAmount()
            .TotalImportePagadoComienzo = TotalImportePagadoComienzo.ToDecimalAmount()
            .TotalProvisionComienzo = TotalProvisionComienzo.ToDecimalAmount()
            .TotalImportePagadoPeriodo = TotalImportePagadoPeriodo.ToDecimalAmount()
        End With
    End Sub

    Private Sub DesgloseOcurridosPeriodoPendientesCierrePeriodoRamo(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoPendientesCierrePeriodoDesgloseOcurridosPeriodoPendientesCierrePeriodoRamo
        Dim TotalNumSiniestros As Decimal = 0
        Dim TotalImportePagado As Decimal = 0
        Dim TotalProvisionCierre As Decimal = 0

        For RowNumber As Integer = 3 To 1000
            value = sheet.Cell(RowNumber, 15).Value
            If value.IsNotEmpty Then
                item = New ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoPendientesCierrePeriodoDesgloseOcurridosPeriodoPendientesCierrePeriodoRamo
                If _RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoPendientesCierrePeriodo.DesgloseOcurridosPeriodoPendientesCierrePeriodoRamo.IsEmpty Then

                    ReDim Preserve _RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoPendientesCierrePeriodo.DesgloseOcurridosPeriodoPendientesCierrePeriodoRamo(0)
                Else
                    ReDim Preserve _RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoPendientesCierrePeriodo.DesgloseOcurridosPeriodoPendientesCierrePeriodoRamo(UBound(_RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoPendientesCierrePeriodo.DesgloseOcurridosPeriodoPendientesCierrePeriodoRamo) + 1)
                End If
                _RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoPendientesCierrePeriodo.DesgloseOcurridosPeriodoPendientesCierrePeriodoRamo(UBound(_RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoPendientesCierrePeriodo.DesgloseOcurridosPeriodoPendientesCierrePeriodoRamo)) = item
                With item
                    .id = [Enum].Parse(GetType(TipoRamo), value)
                    .NumSiniestros = sheet.DecimalValue(RowNumber, 16, "0.00")
                    .ImportePagado = sheet.DecimalValue(RowNumber, 17, "0.00")
                    .ProvisionCierre = sheet.DecimalValue(RowNumber, 18, "0.00")
                End With

                TotalNumSiniestros += sheet.DecimalValue(RowNumber, 16, "0.00")
                TotalImportePagado += sheet.DecimalValue(RowNumber, 17, "0.00")
                TotalProvisionCierre += sheet.DecimalValue(RowNumber, 18, "0.00")
            Else
                Exit For
            End If
        Next
        With _RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoPendientesCierrePeriodo
            .TotalNumSiniestros = TotalNumSiniestros.ToDecimalAmount()
            .TotalImportePagado = TotalImportePagado.ToDecimalAmount()
            .TotalProvisionCierre = TotalProvisionCierre.ToDecimalAmount()
        End With
    End Sub

    Private Sub DesgloseOcurridosPeriodoTerminadosPeriodoRamo(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoTerminadosPeriodoDesgloseOcurridosPeriodoTerminadosPeriodoRamo
        Dim TotalNumSiniestrosConPago As Decimal = 0
        Dim TotalNumSiniestrosSinPago As Decimal = 0
        Dim TotalImportePagado As Decimal = 0

        For RowNumber As Integer = 3 To 1000
            value = sheet.Cell(RowNumber, 20).Value
            If value.IsNotEmpty Then
                item = New ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoTerminadosPeriodoDesgloseOcurridosPeriodoTerminadosPeriodoRamo
                If _RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoTerminadosPeriodo.DesgloseOcurridosPeriodoTerminadosPeriodoRamo.IsEmpty Then

                    ReDim Preserve _RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoTerminadosPeriodo.DesgloseOcurridosPeriodoTerminadosPeriodoRamo(0)
                Else
                    ReDim Preserve _RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoTerminadosPeriodo.DesgloseOcurridosPeriodoTerminadosPeriodoRamo(UBound(_RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoTerminadosPeriodo.DesgloseOcurridosPeriodoTerminadosPeriodoRamo) + 1)
                End If
                _RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoTerminadosPeriodo.DesgloseOcurridosPeriodoTerminadosPeriodoRamo(UBound(_RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoTerminadosPeriodo.DesgloseOcurridosPeriodoTerminadosPeriodoRamo)) = item
                With item
                    .id = [Enum].Parse(GetType(TipoRamo), value)
                    .NumSiniestrosConPago = sheet.DecimalValue(RowNumber, 21, "0.00")
                    .NumSiniestrosSinPago = sheet.DecimalValue(RowNumber, 22, "0.00")
                    .ImportePagado = sheet.DecimalValue(RowNumber, 23, "0.00")
                End With

                TotalNumSiniestrosConPago += sheet.DecimalValue(RowNumber, 21, "0.00")
                TotalNumSiniestrosSinPago += sheet.DecimalValue(RowNumber, 22, "0.00")
                TotalImportePagado += sheet.DecimalValue(RowNumber, 23, "0.00")
            Else
                Exit For
            End If
        Next
        With _RunOff.Datos.Modelo.Siniestros.OcurridosPeriodoTerminadosPeriodo
            .TotalNumSiniestrosConPago = TotalNumSiniestrosConPago.ToDecimalAmount()
            .TotalNumSiniestrosSinPago = TotalNumSiniestrosSinPago.ToDecimalAmount()
            .TotalImportePagado = TotalImportePagado.ToDecimalAmount()
        End With
    End Sub

    Private Sub DesglosePendientesDeclaracionRamo(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloRunOffDatosModeloSiniestrosPendientesDeclaracionDesglosePendientesDeclaracionRamo
        Dim TotalProvisionOYNRComienzoPeriodo As Decimal = 0
        Dim TotalProvisionOYNRResidualCierre As Decimal = 0
        Dim TotalProvisionOYNRCierrePeriodo As Decimal = 0
        Dim TotalPendCierreNumSiniestros As Decimal = 0
        Dim TotalPendCierreImportePagadoPeriodo As Decimal = 0
        Dim TotalPendCierreProvisionCierre As Decimal = 0
        Dim TotalTermPeriodoNumSiniestrosConPago As Decimal = 0
        Dim TotalTermPeriodoNumSiniestrosSinPago As Decimal = 0
        Dim TotalTermPeriodoImportePagado As Decimal = 0
        Dim amount As Decimal = 0

        For RowNumber As Integer = 3 To 1000
            value = sheet.Cell(RowNumber, 25).Value
            If value.IsNotEmpty Then
                item = New ModeloRunOffDatosModeloSiniestrosPendientesDeclaracionDesglosePendientesDeclaracionRamo
                If _RunOff.Datos.Modelo.Siniestros.PendientesDeclaracion.DesglosePendientesDeclaracionRamo.IsEmpty Then

                    ReDim Preserve _RunOff.Datos.Modelo.Siniestros.PendientesDeclaracion.DesglosePendientesDeclaracionRamo(0)
                Else
                    ReDim Preserve _RunOff.Datos.Modelo.Siniestros.PendientesDeclaracion.DesglosePendientesDeclaracionRamo(UBound(_RunOff.Datos.Modelo.Siniestros.PendientesDeclaracion.DesglosePendientesDeclaracionRamo) + 1)
                End If
                _RunOff.Datos.Modelo.Siniestros.PendientesDeclaracion.DesglosePendientesDeclaracionRamo(UBound(_RunOff.Datos.Modelo.Siniestros.PendientesDeclaracion.DesglosePendientesDeclaracionRamo)) = item
                With item
                    .id = [Enum].Parse(GetType(TipoRamo), value)
                    .ProvisionOYNRComienzoEjercicio = sheet.DecimalValue(RowNumber, 26, "0.00")
                    .ProvisionOYNRResidualCierre = sheet.DecimalValue(RowNumber, 27, "0.00")
                    .ProvisionOYNRCierrePeriodo = sheet.DecimalValue(RowNumber, 28, "0.00")
                    .PendCierreNumSiniestros = sheet.DecimalValue(RowNumber, 29, "0.00")
                    .PendCierreImportePagadoPeriodo = sheet.DecimalValue(RowNumber, 30, "0.00")
                    .PendCierreProvisionCierre = sheet.DecimalValue(RowNumber, 31, "0.00")
                    .TermPeriodoNumSiniestrosConPago = sheet.DecimalValue(RowNumber, 32, "0.00")
                    .TermPeriodoNumSiniestrosSinPago = sheet.DecimalValue(RowNumber, 33, "0.00")
                    .TermPeriodoImportePagado = sheet.DecimalValue(RowNumber, 34, "0.00")
                End With

                'ProvisionOYNRComienzoEjercicio
                'PendCierreImportePagadoPeriodo
                'PendCierreProvisionCierre
                'TermPeriodoImportePagado

                amount = sheet.DecimalValue(RowNumber, 26, "0.00") -
                         sheet.DecimalValue(RowNumber, 30, "0.00") -
                         sheet.DecimalValue(RowNumber, 31, "0.00") -
                         sheet.DecimalValue(RowNumber, 34, "0.00")
                If amount < 0 Then
                    amount = 0
                End If
                '1) Provisión de Siniestros Ocurridos y No Reportados (OYNR) Residual al Cierre del Periodo por Ramo:   debe ser igual a la Provisión de Siniestros (OYNR) al Comienzo del periodo  (-) Importe Pagado en el Periodo de los Siniestros Pendientes al Cierre por Ramo (-) Provisión para Siniestros Reportados al Cierre del Periodo por Ramo (-) Importe Pagado en el Periodo de los Siniestros Terminados al Cierre del Periodo por Ramo.  En caso de que el resultado sea ≤ 0, se debe indicar un valor de cero “0”.
                If sheet.DecimalValue(RowNumber, 27, "0.00") <> amount Then
                    Helpers.XmlRespose.AddError(Response, "error", String.Format("Provisión de Siniestros Ocurridos y No Reportados (OYNR) Residual al Cierre del Periodo por Ramo:   debe ser igual a la Provisión de Siniestros (OYNR) al Comienzo del periodo  (-) Importe Pagado en el Periodo de los Siniestros Pendientes al Cierre por Ramo (-) Provisión para Siniestros Reportados al Cierre del Periodo por Ramo (-) Importe Pagado en el Periodo de los Siniestros Terminados al Cierre del Periodo por Ramo.", value))
                End If

                TotalProvisionOYNRComienzoPeriodo += sheet.DecimalValue(RowNumber, 26, "0.00")
                TotalProvisionOYNRResidualCierre += sheet.DecimalValue(RowNumber, 27, "0.00")
                TotalProvisionOYNRCierrePeriodo += sheet.DecimalValue(RowNumber, 28, "0.00")
                TotalPendCierreNumSiniestros += sheet.DecimalValue(RowNumber, 29, "0.00")
                TotalPendCierreImportePagadoPeriodo += sheet.DecimalValue(RowNumber, 30, "0.00")
                TotalPendCierreProvisionCierre += sheet.DecimalValue(RowNumber, 31, "0.00")
                TotalTermPeriodoNumSiniestrosConPago += sheet.DecimalValue(RowNumber, 32, "0.00")
                TotalTermPeriodoNumSiniestrosSinPago += sheet.DecimalValue(RowNumber, 33, "0.00")
                TotalTermPeriodoImportePagado += sheet.DecimalValue(RowNumber, 34, "0.00")
            Else
                Exit For
            End If
        Next
        With _RunOff.Datos.Modelo.Siniestros.PendientesDeclaracion
            .TotalProvisionOYNRComienzoPeriodo = TotalProvisionOYNRComienzoPeriodo.ToDecimalAmount()
            .TotalProvisionOYNRResidualCierre = TotalProvisionOYNRResidualCierre.ToDecimalAmount()
            .TotalProvisionOYNRCierrePeriodo = TotalProvisionOYNRCierrePeriodo.ToDecimalAmount()
            .TotalPendCierreNumSiniestros = TotalPendCierreNumSiniestros.ToDecimalAmount()
            .TotalPendCierreImportePagadoPeriodo = TotalPendCierreImportePagadoPeriodo.ToDecimalAmount()
            .TotalPendCierreProvisionCierre = TotalPendCierreProvisionCierre.ToDecimalAmount()
            .TotalTermPeriodoNumSiniestrosConPago = TotalTermPeriodoNumSiniestrosConPago.ToDecimalAmount()
            .TotalTermPeriodoNumSiniestrosSinPago = TotalTermPeriodoNumSiniestrosSinPago.ToDecimalAmount()
            .TotalTermPeriodoImportePagado = TotalTermPeriodoImportePagado.ToDecimalAmount()
        End With
    End Sub

#End Region

#Region "Sección II"

    Private Sub DesglosePrimasYProvisionPrimasNoDevengadasRamo(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloRunOffDatosModeloPrimasYProvisionPrimasNoDevengadasDesglosePrimasYProvisionPrimasNoDevengadasRamo
        Dim TotalPrimasDevengadas As Decimal = 0
        Dim TotalPrimasAnuladas As Decimal = 0
        Dim TotalPrimasNoRenovadas As Decimal = 0
        Dim TotalProvisionComienzo As Decimal = 0
        Dim TotalProvisionCierre As Decimal = 0

        For RowNumber As Integer = 3 To 1000
            value = sheet.Cell(RowNumber, 1).Value
            If value.IsNotEmpty Then
                item = New ModeloRunOffDatosModeloPrimasYProvisionPrimasNoDevengadasDesglosePrimasYProvisionPrimasNoDevengadasRamo
                If _RunOff.Datos.Modelo.PrimasYProvisionPrimasNoDevengadas.DesglosePrimasYProvisionPrimasNoDevengadasRamo.IsEmpty Then

                    ReDim Preserve _RunOff.Datos.Modelo.PrimasYProvisionPrimasNoDevengadas.DesglosePrimasYProvisionPrimasNoDevengadasRamo(0)
                Else
                    ReDim Preserve _RunOff.Datos.Modelo.PrimasYProvisionPrimasNoDevengadas.DesglosePrimasYProvisionPrimasNoDevengadasRamo(UBound(_RunOff.Datos.Modelo.PrimasYProvisionPrimasNoDevengadas.DesglosePrimasYProvisionPrimasNoDevengadasRamo) + 1)
                End If
                _RunOff.Datos.Modelo.PrimasYProvisionPrimasNoDevengadas.DesglosePrimasYProvisionPrimasNoDevengadasRamo(UBound(_RunOff.Datos.Modelo.PrimasYProvisionPrimasNoDevengadas.DesglosePrimasYProvisionPrimasNoDevengadasRamo)) = item
                With item
                    .id = [Enum].Parse(GetType(TipoRamo), value)
                    .PrimasEmitidas = sheet.DecimalValue(RowNumber, 2, "0.00")
                    .PrimasAnuladas = sheet.DecimalValue(RowNumber, 3, "0.00")
                    .PrimasNoRenovadas = sheet.DecimalValue(RowNumber, 4, "0.00")
                    .ProvisionComienzo = sheet.DecimalValue(RowNumber, 5, "0.00")
                    .ProvisionCierre = sheet.DecimalValue(RowNumber, 6, "0.00")
                End With
                TotalPrimasDevengadas += sheet.DecimalValue(RowNumber, 2, "0.00")
                TotalPrimasAnuladas += sheet.DecimalValue(RowNumber, 3, "0.00")
                TotalPrimasNoRenovadas += sheet.DecimalValue(RowNumber, 4, "0.00")
                TotalProvisionComienzo += sheet.DecimalValue(RowNumber, 5, "0.00")
                TotalProvisionCierre += sheet.DecimalValue(RowNumber, 6, "0.00")
            Else
                Exit For
            End If
        Next
        With _RunOff.Datos.Modelo.PrimasYProvisionPrimasNoDevengadas
            .TotalPrimasEmitidas = TotalPrimasDevengadas.ToDecimalAmount()
            .TotalPrimasAnuladas = TotalPrimasAnuladas.ToDecimalAmount()
            .TotalPrimasNoRenovadas = TotalPrimasNoRenovadas.ToDecimalAmount()
            .TotalProvisionComienzo = TotalProvisionComienzo.ToDecimalAmount()
            .TotalProvisionCierre = TotalProvisionCierre.ToDecimalAmount()
        End With
    End Sub

    Private Sub DesglosePolizasPeriodoRamo(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As New ModeloRunOffDatosModeloPolizasPeriodoDesglosePolizasPeriodoRamo
        Dim TotalExistentesInicio As Decimal = 0
        Dim TotalEmitidasPeriodo As Decimal = 0
        Dim TotalAnuladasPeriodo As Decimal = 0
        Dim TotalNoRenovadasPeriodo As Decimal = 0
        Dim TotalExistentesCierre As Decimal = 0
        Dim TotalVencidasPeriodo As Decimal = 0
        Dim monto As Decimal = 0

        For RowNumber As Integer = 3 To 1000
            value = sheet.Cell(RowNumber, 8).Value
            If value.IsNotEmpty Then
                item = New ModeloRunOffDatosModeloPolizasPeriodoDesglosePolizasPeriodoRamo
                If _RunOff.Datos.Modelo.PolizasPeriodo.DesglosePolizasPeriodoRamo.IsEmpty Then

                    ReDim Preserve _RunOff.Datos.Modelo.PolizasPeriodo.DesglosePolizasPeriodoRamo(0)
                Else
                    ReDim Preserve _RunOff.Datos.Modelo.PolizasPeriodo.DesglosePolizasPeriodoRamo(UBound(_RunOff.Datos.Modelo.PolizasPeriodo.DesglosePolizasPeriodoRamo) + 1)
                End If
                _RunOff.Datos.Modelo.PolizasPeriodo.DesglosePolizasPeriodoRamo(UBound(_RunOff.Datos.Modelo.PolizasPeriodo.DesglosePolizasPeriodoRamo)) = item
                With item
                    .id = [Enum].Parse(GetType(TipoRamo), value)
                    'Se cambio el formato de 0.00 a 0
                    .ExistentesInicio = sheet.DecimalValue(RowNumber, 9, "0")
                    .EmitidasPeriodo = sheet.DecimalValue(RowNumber, 10, "0")
                    .AnuladasPeriodo = sheet.DecimalValue(RowNumber, 11, "0")
                    .NoRenovadasPeriodo = sheet.DecimalValue(RowNumber, 12, "0")
                    .ExistentesCierre = sheet.DecimalValue(RowNumber, 13, "0")
                    .VencidasPeriodo = sheet.DecimalValue(RowNumber, 14, "0")
                End With

                monto = (sheet.DecimalValue(RowNumber, 9, "0.00") +
                         sheet.DecimalValue(RowNumber, 10, "0.00")) -
                        sheet.DecimalValue(RowNumber, 12, "0.00") -
                        sheet.DecimalValue(RowNumber, 11, "0.00") -
                        sheet.DecimalValue(RowNumber, 14, "0.00")

                '2)	Pólizas del Periodo Existentes al Cierre Total (Cuadro 5): debe ser igual a las Pólizas Existentes al Inicio (+) Pólizas Emitidas en el Periodo (-) Pólizas no Renovadas del Periodo (-) Pólizas Anuladas en el Periodo (-) Pólizas Vencidas en el Periodo.
                If sheet.DecimalValue(RowNumber, 13, "0.00") <> monto Then
                    Helpers.XmlRespose.AddError(Response, "error", String.Format("Pólizas del Periodo Existentes al Cierre Total (Cuadro 5): debe ser igual a las Pólizas Existentes al Inicio (+) Pólizas Emitidas en el Periodo (-) Pólizas no Renovadas del Periodo (-) Pólizas Anuladas en el Periodo (-) Pólizas Vencidas en el Periodo.", value))
                End If

                TotalExistentesInicio += sheet.DecimalValue(RowNumber, 9, "0.00")
                TotalEmitidasPeriodo += sheet.DecimalValue(RowNumber, 10, "0.00")
                TotalAnuladasPeriodo += sheet.DecimalValue(RowNumber, 11, "0.00")
                TotalNoRenovadasPeriodo += sheet.DecimalValue(RowNumber, 12, "0.00")
                TotalExistentesCierre += sheet.DecimalValue(RowNumber, 13, "0.00")
                TotalVencidasPeriodo += sheet.DecimalValue(RowNumber, 14, "0.00")
            Else
                Exit For
            End If
        Next
        With _RunOff.Datos.Modelo.PolizasPeriodo
            'Se cambio el formato de 0.00 a 0
            .TotalExistentesInicio = TotalExistentesInicio.ToDecimalAmount("0")
            .TotalEmitidasPeriodo = TotalEmitidasPeriodo.ToDecimalAmount("0")
            .TotalAnuladasPeriodo = TotalAnuladasPeriodo.ToDecimalAmount("0")
            .TotalNoRenovadasPeriodo = TotalNoRenovadasPeriodo.ToDecimalAmount("0")
            .TotalExistentesCierre = TotalExistentesCierre.ToDecimalAmount("0")
            .TotalVencidasPeriodo = TotalVencidasPeriodo.ToDecimalAmount("0")
        End With
    End Sub

#End Region

#Region "Suficiencia"

    Private Sub AnnoActual(sheet As IXLWorksheet)
        Dim value As String = String.Empty

        For RowNumber As Integer = 2 To 7
            value = sheet.Cell(RowNumber, 2).Value
            If value.IsNotEmpty Then

                Select Case RowNumber
                    Case 2 'Anno Actual
                        With _RunOff.Datos.Modelo.Suficiencia.AnnoActual
                            .Anno = sheet.Cell(RowNumber, 2).Value
                            .ImportePagado = sheet.DecimalValue(RowNumber, 3, "0.00")
                            .ProvisionFinalPeriodo = sheet.DecimalValue(RowNumber, 4, "0.00")
                            .RecobrosEfectuados = sheet.DecimalValue(RowNumber, 5, "0.00")
                            .NumSiniestrosReportados = sheet.DecimalValue(RowNumber, 6, "0.00")
                            .NumSiniestrosReabiertos = sheet.DecimalValue(RowNumber, 7, "0.00")
                            .NumSiniestrosPendientes = sheet.DecimalValue(RowNumber, 8, "0.00")
                        End With
                    Case 3 'Anno Actual Menos Uno
                        With _RunOff.Datos.Modelo.Suficiencia.AnnoActualMenosUno
                            .Anno = sheet.Cell(RowNumber, 2).Value
                            .ImportePagado = sheet.DecimalValue(RowNumber, 3, "0.00")
                            .ProvisionFinalPeriodo = sheet.DecimalValue(RowNumber, 4, "0.00")
                            .RecobrosEfectuados = sheet.DecimalValue(RowNumber, 5, "0.00")
                            .NumSiniestrosReportados = sheet.DecimalValue(RowNumber, 6, "0.00")
                            .NumSiniestrosReabiertos = sheet.DecimalValue(RowNumber, 7, "0.00")
                            .NumSiniestrosPendientes = sheet.DecimalValue(RowNumber, 8, "0.00")
                        End With
                    Case 4 'Anno Actual Menos Dos
                        With _RunOff.Datos.Modelo.Suficiencia.AnnoActualMenosDos
                            .Anno = sheet.Cell(RowNumber, 2).Value
                            .ImportePagado = sheet.DecimalValue(RowNumber, 3, "0.00")
                            .ProvisionFinalPeriodo = sheet.DecimalValue(RowNumber, 4, "0.00")
                            .RecobrosEfectuados = sheet.DecimalValue(RowNumber, 5, "0.00")
                            .NumSiniestrosReportados = sheet.DecimalValue(RowNumber, 6, "0.00")
                            .NumSiniestrosReabiertos = sheet.DecimalValue(RowNumber, 7, "0.00")
                            .NumSiniestrosPendientes = sheet.DecimalValue(RowNumber, 8, "0.00")
                        End With
                    Case 5 'Anno Actual Menos Tres
                        With _RunOff.Datos.Modelo.Suficiencia.AnnoActualMenosTres
                            .Anno = sheet.Cell(RowNumber, 2).Value
                            .ImportePagado = sheet.DecimalValue(RowNumber, 3, "0.00")
                            .ProvisionFinalPeriodo = sheet.DecimalValue(RowNumber, 4, "0.00")
                            .RecobrosEfectuados = sheet.DecimalValue(RowNumber, 5, "0.00")
                            .NumSiniestrosReportados = sheet.DecimalValue(RowNumber, 6, "0.00")
                            .NumSiniestrosReabiertos = sheet.DecimalValue(RowNumber, 7, "0.00")
                            .NumSiniestrosPendientes = sheet.DecimalValue(RowNumber, 8, "0.00")
                        End With
                    Case 6 'Anno Actual Menos Cuatro
                        With _RunOff.Datos.Modelo.Suficiencia.AnnoActualMenosCuatro
                            .Anno = sheet.Cell(RowNumber, 2).Value
                            .ImportePagado = sheet.DecimalValue(RowNumber, 3, "0.00")
                            .ProvisionFinalPeriodo = sheet.DecimalValue(RowNumber, 4, "0.00")
                            .RecobrosEfectuados = sheet.DecimalValue(RowNumber, 5, "0.00")
                            .NumSiniestrosReportados = sheet.DecimalValue(RowNumber, 6, "0.00")
                            .NumSiniestrosReabiertos = sheet.DecimalValue(RowNumber, 7, "0.00")
                            .NumSiniestrosPendientes = sheet.DecimalValue(RowNumber, 8, "0.00")
                        End With
                    Case 7 'Anno Actual Menos Cinco
                        With _RunOff.Datos.Modelo.Suficiencia.AnnoActualMenosCinco
                            .Anno = sheet.Cell(RowNumber, 2).Value
                            .ImportePagado = sheet.DecimalValue(RowNumber, 3, "0.00")
                            .ProvisionFinalPeriodo = sheet.DecimalValue(RowNumber, 4, "0.00")
                            .RecobrosEfectuados = sheet.DecimalValue(RowNumber, 5, "0.00")
                            .NumSiniestrosReportados = sheet.DecimalValue(RowNumber, 6, "0.00")
                            .NumSiniestrosReabiertos = sheet.DecimalValue(RowNumber, 7, "0.00")
                            .NumSiniestrosPendientes = sheet.DecimalValue(RowNumber, 8, "0.00")
                        End With
                End Select
            End If
        Next
    End Sub

#End Region

    Private Sub ModeloEstadistico(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As New ModeloRunOffDatosModeloModeloEstadisticoDesgloseModeloEstadisticoPorRamo
        Dim TotalAjusteModeloEstadistico As Decimal = 0
        Dim TotalProvisionSiniestrosReportadosAlCierre As Decimal = 0

        For RowNumber As Integer = 3 To 1000
            value = sheet.Cell(RowNumber, 1).Value
            If value.IsNotEmpty Then

                item = New ModeloRunOffDatosModeloModeloEstadisticoDesgloseModeloEstadisticoPorRamo
                If _RunOff.Datos.Modelo.ModeloEstadistico.IsEmpty Then
                    _RunOff.Datos.Modelo.ModeloEstadistico = New RunOff.ModeloRunOffDatosModeloModeloEstadistico
                End If
                If _RunOff.Datos.Modelo.ModeloEstadistico.DesgloseModeloEstadisticoPorRamo.IsEmpty Then

                    ReDim Preserve _RunOff.Datos.Modelo.ModeloEstadistico.DesgloseModeloEstadisticoPorRamo(0)
                Else
                    ReDim Preserve _RunOff.Datos.Modelo.ModeloEstadistico.DesgloseModeloEstadisticoPorRamo(UBound(_RunOff.Datos.Modelo.ModeloEstadistico.DesgloseModeloEstadisticoPorRamo) + 1)
                End If
                _RunOff.Datos.Modelo.ModeloEstadistico.DesgloseModeloEstadisticoPorRamo(UBound(_RunOff.Datos.Modelo.ModeloEstadistico.DesgloseModeloEstadisticoPorRamo)) = item
                With item
                    .id = [Enum].Parse(GetType(TipoRamo), value)
                    .AjusteModeloEstadistico = sheet.DecimalValue(RowNumber, 2, "0.00")
                    .ProvisionSiniestrosReportadosAlCierre = sheet.DecimalValue(RowNumber, 3, "0.00")
                End With

                TotalAjusteModeloEstadistico += sheet.DecimalValue(RowNumber, 2, "0.00")
                TotalProvisionSiniestrosReportadosAlCierre += sheet.DecimalValue(RowNumber, 3, "0.00")
            Else
                Exit For
            End If
        Next
        With _RunOff.Datos.Modelo.ModeloEstadistico
            .TotalAjusteModeloEstadistico = TotalAjusteModeloEstadistico.ToDecimalAmount()
            .TotalProvisionSiniestrosReportadosAlCierre = TotalProvisionSiniestrosReportadosAlCierre.ToDecimalAmount()
        End With
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
End Class
