Imports System.Configuration
Imports Architect.Sugese.Domain
Imports Architect.Sugese.Utility
Imports Architect.Utilities.Extensions
Imports ClosedXML.Excel

Public Class Generate
    Private _AportesINEC As New Sugese.AportesINEC.ModeloAportesINEC

    Public Property Response As DataTable

    Public Sub New(periodo As Date)
        _AportesINEC = New Sugese.AportesINEC.ModeloAportesINEC
        _AportesINEC.Encabezado = New Sugese.AportesINEC.EncabezadoTipo() _
                With {
                    .NombreArchivo = String.Format("{0}-ModeloAportesINEC", ConfigurationManager.AppSettings("sugese.entidadaseguradora")),
                    .Fecha = Today.ToString("yyyy-MM-dd"),
                    .Periodo = periodo.ToString("yyyy-MM-dd"),
                    .Periodicidad = Sugese.AportesINEC.Periodicidad.M,
                    .Moneda = CodMoneda.Item1
                }
        _AportesINEC.Datos = New ModeloAportesINECDatos _
                With {
                    .Modelo = New Sugese.AportesINEC.ModeloAportesINECDatosModelo _
                    With {
                        .EntidadFuente = ConfigurationManager.AppSettings("sugese.codigoaseguradora")
                    }
                }
    End Sub

    Public Shared Function Execute(xlsxFileName As String, xmlFileName As String, pediodoMensual As Integer, ano As Integer) As DataTable
        Dim result As DataTable = Nothing
        With New Generate(New Date(ano, pediodoMensual, 1))
            .LoadExcelInformation(xlsxFileName)
            .FileSerialize(xmlFileName, False)
            result = .Response
        End With
        Return result
    End Function

    Public Sub LoadExcelInformation(excelFilename As String)
        Dim workbook As New XLWorkbook(excelFilename)
        Dim sheet As IXLWorksheet = Nothing
        Dim valueOld As String = String.Empty
        Dim value As String = String.Empty
        Dim witherror As Boolean = False
        Dim ramo As TipoRamo

        Dim polizasMonedaCurrent As ModeloAportesINECDatosModeloRamoAportesPolizas
        Dim polizasMonedaList As New List(Of Sugese.AportesINEC.ModeloAportesINECDatosModeloRamoAportesPolizas)

        Dim ramoAporteCurrent As Sugese.AportesINEC.ModeloAportesINECDatosModeloRamoAportes
        Dim ramoAporteList As New List(Of Sugese.AportesINEC.ModeloAportesINECDatosModeloRamoAportes)

        sheet = workbook.Worksheet("Datos")
        For RowNumber As Integer = 2 To 1000
            value = sheet.Cell(RowNumber, 1).Value
            If value.IsNotEmpty Then
                Try
                    ramo = sheet.EnumValue(Of TipoRamo)(RowNumber, "A", witherror)
                    If witherror Then
                        Helpers.XmlRespose.AddError(Response, "error", String.Format("El Ramo '{0}' no es valido.", sheet.Cell(RowNumber, "A").Value))
                    End If

                    If value <> valueOld Then
                        ramoAporteCurrent = New Sugese.AportesINEC.ModeloAportesINECDatosModeloRamoAportes() With {.id = ramo}
                        ramoAporteList.Add(ramoAporteCurrent)
                        polizasMonedaList = New List(Of Sugese.AportesINEC.ModeloAportesINECDatosModeloRamoAportesPolizas)
                    End If
                    polizasMonedaCurrent = New Sugese.AportesINEC.ModeloAportesINECDatosModeloRamoAportesPolizas()
                    polizasMonedaList.Add(polizasMonedaCurrent)

                    With polizasMonedaCurrent
                        .CodMoneda = sheet.EnumValue(Of CodMonedaInt)(RowNumber, "B", witherror)
                        If witherror Then
                            Helpers.XmlRespose.AddError(Response, "error", String.Format("La moneda '{0}' no es valida.", sheet.Cell(RowNumber, "B").Value))
                        End If
                        .PrimasDirectas = sheet.DecimalValue(RowNumber, "C", "0.00")
                        .PagarINEC = sheet.DecimalValue(RowNumber, "D", "0.00")
                    End With
                    ramoAporteCurrent.Polizas = polizasMonedaList.ToArray
                    valueOld = value
                Catch ex As Exception
                    If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                        Helpers.XmlRespose.AddError(Response, "error", String.Format("Error en '{0}'", ex.Message))
                    Else
                        Helpers.XmlRespose.AddError(Response, "error", String.Format("{1} Error en '{0}'", ex.Message, RowNumber))
                    End If
                End Try
            Else
                _AportesINEC.Datos.Modelo.RamoAportes = ramoAporteList.ToArray
                Exit For
            End If
        Next

        sheet = Nothing
        workbook = Nothing
    End Sub

    Public Sub FileSerialize(filename As String, withFormat As Boolean)
        Utilities.SerializeHandler(Of Sugese.AportesINEC.ModeloAportesINEC).SerializeToFile(_AportesINEC, filename, withFormat)

        Dim result As List(Of String) = Nothing
        result = Validate.XsdValidate("ModeloAportesINEC", filename)
        If result.Count > 0 Then
            For Each item As String In result
                Helpers.XmlRespose.AddError(Response, "error", item)
            Next
        End If

    End Sub

End Class