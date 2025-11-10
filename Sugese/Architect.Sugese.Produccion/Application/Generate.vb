Imports System.Configuration
Imports Architect.Sugese.Domain
Imports Architect.Sugese.Utility.Helpers
Imports Architect.Utilities.Extensions
Imports ClosedXML.Excel

Public Class Generate

    Private _Produccion As New Produccion.ModeloProduccion

    Public Property Response As DataTable

#Region "Builder"

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="periodo">Fecha correspondiente al período al cual corresponde el modelo</param>
    ''' <param name="periodicidad">Corresponde a la periodicidad del modelo</param>
    ''' <remarks></remarks>
    Public Sub New(periodo As Date, periodicidad As Produccion.Periodicidad)
        ModelInit()
        With _Produccion.Encabezado
            .NombreArchivo = String.Format("{0}-ModeloProduccion", ConfigurationManager.AppSettings("sugese.entidadaseguradora"))
            .Fecha = Today.ToString("yyyy-MM-dd")
            .Periodo = periodo.ToString("yyyy-MM-dd")
            .Periodicidad = periodicidad
            .Moneda = CodMoneda.Item1
        End With
        _Produccion.Datos.Modelo.EntidadFuente = ConfigurationManager.AppSettings("sugese.codigoaseguradora")
        Response = New DataTable
    End Sub

    Public Function Serialize(withFormat As Boolean) As String
        Return Utilities.SerializeHandler(Of Produccion.ModeloProduccion).Serialize(_Produccion, withFormat)
    End Function

    Private Sub ModelInit()
        _Produccion = New ModeloProduccion
        With _Produccion
            .Encabezado = New ModeloProduccionEncabezado
            .Datos = New ModeloProduccionDatos
        End With
        With _Produccion.Encabezado
            .NombreArchivo = String.Empty
            .Fecha = String.Empty
            .Periodo = String.Empty
            .Periodicidad = Periodicidad.T
            .Moneda = CodMoneda.Item1
        End With

        With _Produccion.Datos
            .Modelo = New ModeloProduccionDatosModelo
        End With
        With _Produccion.Datos.Modelo
            .ProduccionPoblacionAsegurada = New ModeloProduccionDatosModeloProduccionPoblacionAsegurada
            .EntidadFuente = String.Empty
        End With
        With _Produccion.Datos.Modelo.ProduccionPoblacionAsegurada
            '.Ramo(0) = New ModeloProduccionDatosModeloProduccionPoblacionAseguradaRamo
            .TotalPolizasEmitidas = String.Empty
            .TotalPolizasAnuladasoCanceladas = String.Empty
            .TotalPolizasContratadas = String.Empty
            .TotalDistribucionPolizas = 0
            .TotalPolizasVencidas = String.Empty
            .TotalPolizasNoRenovadas = String.Empty
            .TotalTomadorFisicasJuridicas = String.Empty
            .TotalColectivaModalidadContributiva = 0
            .TotalColectivaModalidadNoContributiva = 0
            .TotalDistribucionMonedaNacional = 0
            .TotalDistribucionMonedaInternacional = 0
        End With

    End Sub

    Public Shared Function AddRamo(items As ModeloProduccionDatosModeloProduccionPoblacionAseguradaRamo()) As ModeloProduccionDatosModeloProduccionPoblacionAseguradaRamo
        Dim result As New ModeloProduccionDatosModeloProduccionPoblacionAseguradaRamo
        ReDim Preserve items(UBound(items) + 1)
        items(UBound(items)) = result
        With result
            .PolizasEmitidas = String.Empty
            .PolizasAnuladasoCanceladas = String.Empty
            .PolizasContratadas = String.Empty
            .DistribucionPolizas = 0
            .PolizasVencidas = String.Empty
            .PolizasNoRenovadas = String.Empty
            .TomadorFisicasJuridicas = String.Empty
            .ColectivaModalidadContributiva = 0
            .ColectivaModalidadNoContributiva = 0
            .DistribucionMonedaNacional = New System.Nullable(Of System.Decimal)
            .DistribucionMonedaInternacional = New System.Nullable(Of System.Decimal)
            .id = TipoRamo.G01
        End With

        Return result
    End Function

    Public Sub FileSerialize(filename As String, withFormat As Boolean)
        Utilities.SerializeHandler(Of Produccion.ModeloProduccion).SerializeToFile(_Produccion, filename, withFormat)

    End Sub

#End Region

    Public Sub LoadExcelInformation(excelFilename As String)

        Dim workbook As New XLWorkbook(excelFilename)
        Dim sheet As IXLWorksheet = Nothing

        'Producción Población Asegurada
        sheet = workbook.Worksheet("Producción Población Asegurada")
        ProduccionPoblacionAsegurada(sheet)

        sheet = Nothing
        workbook = Nothing
    End Sub

    Private Sub ProduccionPoblacionAsegurada(sheet As IXLWorksheet)
        Dim value As String = String.Empty
        Dim item As ModeloProduccionDatosModeloProduccionPoblacionAseguradaRamo
        Dim PolizasEmitidas As Integer = 0
        Dim TotalPolizasEmitidas As Integer = 0
        Dim PolizasAnuladasoCanceladas As Integer = 0
        Dim TotalPolizasAnuladasoCanceladas As Integer = 0
        Dim PolizasContratadas As Integer = 0
        Dim TotalPolizasContratadas As Integer = 0
        Dim TotalDistribucionPolizas As Decimal = 0
        Dim TotalPolizasVencidas As Integer = 0
        Dim PolizasNoRenovadas As Integer = 0
        Dim TotalPolizasNoRenovadas As Integer = 0
        Dim TotalTomadorFisicasJuridicas As Integer = 0
        Dim TotalColectivaModalidadContributiva As Decimal = 0
        Dim TotalColectivaModalidadNoContributiva As Decimal = 0
        Dim TotalDistribucionMonedaNacional As Decimal = 0
        Dim TotalDistribucionMonedaInternacional As Decimal = 0

        For RowNumber As Integer = 2 To 1000
            value = sheet.Cell(RowNumber, 1).Value
            If value.IsNotEmpty Then
                item = New ModeloProduccionDatosModeloProduccionPoblacionAseguradaRamo
                If _Produccion.Datos.Modelo.ProduccionPoblacionAsegurada.Ramo.IsEmpty Then
                    ReDim Preserve _Produccion.Datos.Modelo.ProduccionPoblacionAsegurada.Ramo(0)
                Else
                    ReDim Preserve _Produccion.Datos.Modelo.ProduccionPoblacionAsegurada.Ramo(UBound(_Produccion.Datos.Modelo.ProduccionPoblacionAsegurada.Ramo) + 1)
                End If

                _Produccion.Datos.Modelo.ProduccionPoblacionAsegurada.Ramo(UBound(_Produccion.Datos.Modelo.ProduccionPoblacionAsegurada.Ramo)) = item
                With item
                    Try
                        .id = [Enum].Parse(GetType(TipoRamo), value)
                    Catch ex As Exception
                        .id = TipoRamo.G01
                        XmlRespose.AddError(Response, "error", String.Format("El ramo '{0}' no es valido.", value))
                    End Try

                    .PolizasEmitidas = Decimal.Parse(sheet.Cell(RowNumber, 2).Value).ToWholeAmount()
                    .PolizasAnuladasoCanceladas = Decimal.Parse(sheet.Cell(RowNumber, 3).Value).ToWholeAmount()
                    .PolizasContratadas = Decimal.Parse(sheet.Cell(RowNumber, 4).Value).ToWholeAmount()
                    .DistribucionPolizas = Decimal.Parse(sheet.Cell(RowNumber, 5).Value).ToWholeAmount()
                    .PolizasVencidas = Decimal.Parse(sheet.Cell(RowNumber, 6).Value).ToWholeAmount()
                    .PolizasNoRenovadas = Decimal.Parse(sheet.Cell(RowNumber, 7).Value).ToWholeAmount()
                    .TomadorFisicasJuridicas = Decimal.Parse(sheet.Cell(RowNumber, 8).Value).ToWholeAmount()
                    .ColectivaModalidadContributiva = Decimal.Parse(sheet.Cell(RowNumber, 9).Value).ToWholeAmount()
                    .ColectivaModalidadNoContributiva = Decimal.Parse(sheet.Cell(RowNumber, 10).Value).ToWholeAmount()
                    .DistribucionMonedaNacional = Decimal.Parse(sheet.Cell(RowNumber, 11).Value).ToWholeAmount()
                    .DistribucionMonedaInternacional = Decimal.Parse(sheet.Cell(RowNumber, 12).Value).ToWholeAmount()
                End With
                PolizasEmitidas = sheet.Cell(RowNumber, 2).Value
                TotalPolizasEmitidas += PolizasEmitidas
                PolizasAnuladasoCanceladas = sheet.Cell(RowNumber, 3).Value
                TotalPolizasAnuladasoCanceladas += PolizasAnuladasoCanceladas
                PolizasContratadas = sheet.Cell(RowNumber, 4).Value
                TotalPolizasContratadas += PolizasContratadas
                TotalDistribucionPolizas += sheet.Cell(RowNumber, 5).Value
                TotalPolizasVencidas += Integer.Parse(sheet.Cell(RowNumber, 6).Value)
                PolizasNoRenovadas = sheet.Cell(RowNumber, 7).Value
                TotalPolizasNoRenovadas += PolizasNoRenovadas
                TotalTomadorFisicasJuridicas += Integer.Parse(sheet.Cell(RowNumber, 8).Value)
                TotalColectivaModalidadContributiva += sheet.Cell(RowNumber, 9).Value
                TotalColectivaModalidadNoContributiva += sheet.Cell(RowNumber, 10).Value
                TotalDistribucionMonedaNacional += sheet.Cell(RowNumber, 11).Value
                TotalDistribucionMonedaInternacional += sheet.Cell(RowNumber, 12).Value

                '2)	Pólizas Contratadas por Ramo:  debe ser igual a las Pólizas Emitidas por Ramo (-) Pólizas Anuladas o Canceladas por Ramo (-) Pólizas no Renovadas por Ramo.
                If PolizasContratadas <> (PolizasEmitidas - PolizasAnuladasoCanceladas - PolizasNoRenovadas) Then
                    XmlRespose.AddError(Response, "error", String.Format("Pólizas Contratadas por Ramo:  debe ser igual a las Pólizas Emitidas por Ramo (-) Pólizas Anuladas o Canceladas por Ramo (-) Pólizas no Renovadas por Ramo.", value))
                End If
            ElseIf value.IsEmpty Then
                Exit For
            End If
        Next
        With _Produccion.Datos.Modelo.ProduccionPoblacionAsegurada
            .TotalPolizasEmitidas = Decimal.Parse(TotalPolizasEmitidas).ToWholeAmount()
            .TotalPolizasAnuladasoCanceladas = Decimal.Parse(TotalPolizasAnuladasoCanceladas).ToWholeAmount()
            .TotalPolizasContratadas = Decimal.Parse(TotalPolizasContratadas).ToWholeAmount()
            .TotalDistribucionPolizas = Decimal.Parse(TotalDistribucionPolizas).ToWholeAmount()
            .TotalPolizasVencidas = Decimal.Parse(TotalPolizasVencidas).ToWholeAmount()
            .TotalPolizasNoRenovadas = Decimal.Parse(TotalPolizasNoRenovadas).ToWholeAmount()
            .TotalTomadorFisicasJuridicas = Decimal.Parse(TotalTomadorFisicasJuridicas).ToWholeAmount()
            .TotalColectivaModalidadContributiva = Decimal.Parse(TotalColectivaModalidadContributiva).ToWholeAmount()
            .TotalColectivaModalidadNoContributiva = Decimal.Parse(TotalColectivaModalidadNoContributiva).ToWholeAmount()
            .TotalDistribucionMonedaNacional = Decimal.Parse(TotalDistribucionMonedaNacional).ToWholeAmount()
            .TotalDistribucionMonedaInternacional = Decimal.Parse(TotalDistribucionMonedaInternacional).ToWholeAmount()
        End With

        '1)	Pólizas Contratadas Total:  debe ser igual a las Pólizas Emitidas (-) Pólizas Anuladas o Canceladas (-) Pólizas no Renovadas.
        If TotalPolizasContratadas <> (TotalPolizasEmitidas - TotalPolizasAnuladasoCanceladas - TotalPolizasNoRenovadas) Then
            XmlRespose.AddError(Response, "error", String.Format("Pólizas Contratadas Total:  debe ser igual a las Pólizas Emitidas (-) Pólizas Anuladas o Canceladas (-) Pólizas no Renovadas.", value))
        End If

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