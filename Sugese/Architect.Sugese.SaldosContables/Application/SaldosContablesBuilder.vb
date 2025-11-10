Imports System.Configuration
Imports Architect.Sugese.Domain
Imports Architect.Sugese.Utility
Imports Architect.Utilities.Extensions
Imports ClosedXML.Excel

Public Class SaldosContablesBuilder

    Private _SaldosContables As New ModeloSaldosContables

    Private sheetName As String

    Public Property Response As DataTable

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="periodo">Fecha correspondiente al período al cual corresponde el modelo</param>
    ''' <remarks></remarks>
    Public Sub New(periodo As Date)
        ModelInit()
        With _SaldosContables.Encabezado
            .NombreArchivo = String.Format("{0}-ModeloSaldosContables", ConfigurationManager.AppSettings("sugese.entidadaseguradora"))
            .Fecha = Today.ToString("yyyy-MM-dd")
            .Periodo = periodo.ToString("yyyy-MM-dd")
            .Periodicidad = Periodicidad.M
            .Moneda = CodMoneda.Item1
        End With
        Me.Response = Helpers.XmlRespose.ReponseDataTable
        _SaldosContables.Datos.Modelo = New Sugese.SaldosContables.ModeloSaldosContablesDatosModelo

        _SaldosContables.Datos.Modelo.EntidadFuente = ConfigurationManager.AppSettings("sugese.codigoaseguradora")

    End Sub

    Private Sub ModelInit()
        _SaldosContables = New ModeloSaldosContables
        With _SaldosContables
            .Encabezado = New Sugese.SaldosContables.EncabezadoTipo
            .Datos = New ModeloSaldosContablesDatos
        End With
        With _SaldosContables.Encabezado
            .NombreArchivo = String.Empty
            .Fecha = String.Empty
            .Periodo = String.Empty
            .Periodicidad = Periodicidad.M
            .Moneda = CodMoneda.Item1
        End With


    End Sub


    Public Sub LoadExcelInformation(excelFilename As String)
        Dim workbook As New XLWorkbook(excelFilename)
        Dim sheet As IXLWorksheet = Nothing
        Dim value As String
        Utilities.Log.WarningLog("SaldosCon", "Open")
        Try
            sheet = workbook.Worksheet(1) '("Saldos")
        Catch ex As Exception
            Throw New Exception("No existe una hoja en el archivo de excel con el nombre 'Saldos'", ex)
        End Try

        Try
            For RowNumber As Integer = 2 To 10000
                value = sheet.Cell(RowNumber, 1).Value
                If value.IsNotEmpty Then
                    Select Case value.Substring(0, 1)
                        Case "1"
                            Saldos1.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                            Saldos1a.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                            Saldos1b.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                            Saldos1c.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                            Saldos1d.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                        Case "2"
                            Saldos2.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                        Case "3"
                            Saldos3.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                        Case "4"
                            Saldos4.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                            Saldos4a.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                            Saldos4b.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                                'Saldos4c.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                        Case "5"
                            Saldos5.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                            Saldos5a.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                                'Saldos5b.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                        Case "6"
                            Saldos6.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                            'Case "7"
                            '    'Saldos7.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                        Case "8"
                            Saldos8.Mapper(value, RowNumber, sheet, _SaldosContables, Response, "Saldos")
                        Case Else
                            Utilities.Log.WarningLog("SaldosCon", value)
                    End Select
                Else
                    Exit For
                End If
            Next

            Total1.Mapper(_SaldosContables)
            Total1a.Mapper(_SaldosContables)
            Total1b.Mapper(_SaldosContables)
            'Total1c.Mapper(_SaldosContables)
            Total2.Mapper(_SaldosContables)
            Total3.Mapper(_SaldosContables)
            Total4.Mapper(_SaldosContables)
            Total4a.Mapper(_SaldosContables)
            'Total4b.Mapper(_SaldosContables)
            'Total4c.Mapper(_SaldosContables)
            Total5.Mapper(_SaldosContables)
            Total5a.Mapper(_SaldosContables)
            Total6.Mapper(_SaldosContables)
            'Total7.Mapper(_SaldosContables)
            Total8.Mapper(_SaldosContables)

            InternalValidator(sheet, _SaldosContables)
        Catch ex As Exception
            Utilities.Log.WarningLog("SaldosCon", "error " & ex.Message)
            Throw ex
        End Try



        Utilities.Log.WarningLog("SaldosCon", "fin")
        sheet = Nothing
        workbook = Nothing
    End Sub


    Private Sub InternalValidator(sheet As IXLWorksheet, saldos As ModeloSaldosContables)
        Dim value As String
        Dim numericValue As Decimal
        Dim currentRow As DataRow
        For RowNumber As Integer = 2 To 10000
            value = sheet.Cell(RowNumber, 1).Value
            If value.IsNotEmpty Then
                numericValue = sheet.FormatDecimalValue(RowNumber, "B", "0.00", Response, sheetName)
                Select Case value
                    Case "10000000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_10000000000000.Total10000000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 10000000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_10000000000000.Total10000000000000, numericValue - saldos.Datos.Modelo.cta_10000000000000.Total10000000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "10100000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_10000000000000.cta_10100000000000.Total10100000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 10100000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_10000000000000.cta_10100000000000.Total10100000000000, numericValue - saldos.Datos.Modelo.cta_10000000000000.cta_10100000000000.Total10100000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "10200000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_10000000000000.cta_10200000000000.Total10200000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 10200000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_10000000000000.cta_10200000000000.Total10200000000000, numericValue - saldos.Datos.Modelo.cta_10000000000000.cta_10200000000000.Total10200000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "10300000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_10000000000000.cta_10300000000000.Total10300000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 10300000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_10000000000000.cta_10300000000000.Total10300000000000, numericValue - saldos.Datos.Modelo.cta_10000000000000.cta_10300000000000.Total10300000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "10400000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_10000000000000.cta_10400000000000.Total10400000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 10400000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_10000000000000.cta_10400000000000.Total10400000000000, numericValue - saldos.Datos.Modelo.cta_10000000000000.cta_10400000000000.Total10400000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "10500000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_10000000000000.cta_10500000000000.Total10500000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 10500000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_10000000000000.cta_10500000000000.Total10500000000000, numericValue - saldos.Datos.Modelo.cta_10000000000000.cta_10500000000000.Total10500000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "10600000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_10000000000000.cta_10600000000000.Total10600000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 10600000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_10000000000000.cta_10600000000000.Total10600000000000, numericValue - saldos.Datos.Modelo.cta_10000000000000.cta_10600000000000.Total10600000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "10700000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_10000000000000.cta_10700000000000.Total10700000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 10700000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_10000000000000.cta_10700000000000.Total10700000000000, numericValue - saldos.Datos.Modelo.cta_10000000000000.cta_10700000000000.Total10700000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "10800000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_10000000000000.cta_10800000000000.Total10800000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 10800000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_10000000000000.cta_10800000000000.Total10800000000000, numericValue - saldos.Datos.Modelo.cta_10000000000000.cta_10800000000000.Total10800000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "10900000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_10000000000000.cta_10900000000000.Total10900000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 10900000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_10000000000000.cta_10900000000000.Total10900000000000, numericValue - saldos.Datos.Modelo.cta_10000000000000.cta_10900000000000.Total10900000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "11000000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_10000000000000.cta_11000000000000.Total11000000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 11000000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_10000000000000.cta_11000000000000.Total11000000000000, numericValue - saldos.Datos.Modelo.cta_10000000000000.cta_11000000000000.Total11000000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "11100000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_10000000000000.cta_11100000000000.Total11100000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 11100000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_10000000000000.cta_11100000000000.Total11100000000000, numericValue - saldos.Datos.Modelo.cta_10000000000000.cta_11100000000000.Total11100000000000)
                            Response.Rows.Add(currentRow)
                        End If



                    Case "20000000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_20000000000000.Total20000000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 20000000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_20000000000000.Total20000000000000, numericValue - saldos.Datos.Modelo.cta_20000000000000.Total20000000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "20100000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_20000000000000.cta_20100000000000.Total20100000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 20100000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_20000000000000.cta_20100000000000.Total20100000000000, numericValue - saldos.Datos.Modelo.cta_20000000000000.cta_20100000000000.Total20100000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "20300000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_20000000000000.cta_20300000000000.Total20300000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 20300000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_20000000000000.cta_20300000000000.Total20300000000000, numericValue - saldos.Datos.Modelo.cta_20000000000000.cta_20300000000000.Total20300000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "20400000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_20000000000000.cta_20400000000000.Total20400000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 20400000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_20000000000000.cta_20400000000000.Total20400000000000, numericValue - saldos.Datos.Modelo.cta_20000000000000.cta_20400000000000.Total20400000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "20500000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_20000000000000.cta_20500000000000.Total20500000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 20500000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_20000000000000.cta_20500000000000.Total20500000000000, numericValue - saldos.Datos.Modelo.cta_20000000000000.cta_20500000000000.Total20500000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "20600000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_20000000000000.cta_20600000000000.Total20600000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 20600000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_20000000000000.cta_20600000000000.Total20600000000000, numericValue - saldos.Datos.Modelo.cta_20000000000000.cta_20600000000000.Total20600000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "20700000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_20000000000000.cta_20700000000000.Total20700000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 20700000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_20000000000000.cta_20700000000000.Total20700000000000, numericValue - saldos.Datos.Modelo.cta_20000000000000.cta_20700000000000.Total20700000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "20800000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_20000000000000.cta_20800000000000.Total20800000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 20800000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_20000000000000.cta_20800000000000.Total20800000000000, numericValue - saldos.Datos.Modelo.cta_20000000000000.cta_20800000000000.Total20800000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "20900000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_20000000000000.cta_20900000000000.Total20900000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 20900000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_20000000000000.cta_20900000000000.Total20900000000000, numericValue - saldos.Datos.Modelo.cta_20000000000000.cta_20900000000000.Total20900000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "21000000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_20000000000000.cta_21000000000000.Total21000000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 21000000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_20000000000000.cta_21000000000000.Total21000000000000, numericValue - saldos.Datos.Modelo.cta_20000000000000.cta_21000000000000.Total21000000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "21100000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_20000000000000.cta_21100000000000.Total21100000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 21100000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_20000000000000.cta_21100000000000.Total21100000000000, numericValue - saldos.Datos.Modelo.cta_20000000000000.cta_21100000000000.Total21100000000000)
                            Response.Rows.Add(currentRow)
                        End If


                    Case "30000000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_30000000000000.Total30000000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 30000000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_30000000000000.Total30000000000000, numericValue - saldos.Datos.Modelo.cta_30000000000000.Total30000000000000)
                            Response.Rows.Add(currentRow)
                        End If


                    Case "40000000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_40000000000000.Total40000000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 40000000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_40000000000000.Total40000000000000, numericValue - saldos.Datos.Modelo.cta_40000000000000.Total40000000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "40100000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_40000000000000.cta_40100000000000.Total40100000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 40100000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_40000000000000.cta_40100000000000.Total40100000000000, numericValue - saldos.Datos.Modelo.cta_40000000000000.cta_40100000000000.Total40100000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "40200000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_40000000000000.cta_40200000000000.Total40200000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 40200000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_40000000000000.cta_40200000000000.Total40200000000000, numericValue - saldos.Datos.Modelo.cta_40000000000000.cta_40200000000000.Total40200000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "40300000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_40000000000000.cta_40300000000000.Total40300000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 40300000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_40000000000000.cta_40300000000000.Total40300000000000, numericValue - saldos.Datos.Modelo.cta_40000000000000.cta_40300000000000.Total40300000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "40400000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_40000000000000.cta_40400000000000.Total40400000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 40400000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_40000000000000.cta_40400000000000.Total40400000000000, numericValue - saldos.Datos.Modelo.cta_40000000000000.cta_40400000000000.Total40400000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "40500000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_40000000000000.cta_40500000000000.Total40500000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 40500000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_40000000000000.cta_40500000000000.Total40500000000000, numericValue - saldos.Datos.Modelo.cta_40000000000000.cta_40500000000000.Total40500000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "40600000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_40000000000000.cta_40600000000000.Total40600000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 40600000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_40000000000000.cta_40600000000000.Total40600000000000, numericValue - saldos.Datos.Modelo.cta_40000000000000.cta_40600000000000.Total40600000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "40700000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_40000000000000.cta_40700000000000.Total40700000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 40700000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_40000000000000.cta_40700000000000.Total40700000000000, numericValue - saldos.Datos.Modelo.cta_40000000000000.cta_40700000000000.Total40700000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "40800000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_40000000000000.cta_40800000000000.Total40800000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 40800000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_40000000000000.cta_40800000000000.Total40800000000000, numericValue - saldos.Datos.Modelo.cta_40000000000000.cta_40800000000000.Total40800000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "40900000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_40000000000000.cta_40900000000000.Total40900000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 40900000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_40000000000000.cta_40900000000000.Total40900000000000, numericValue - saldos.Datos.Modelo.cta_40000000000000.cta_40900000000000.Total40900000000000)
                            Response.Rows.Add(currentRow)
                        End If





                    Case "50000000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_50000000000000.Total50000000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 50000000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_50000000000000.Total50000000000000, numericValue - saldos.Datos.Modelo.cta_50000000000000.Total50000000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "60000000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_60000000000000.Total60000000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 60000000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_60000000000000.Total60000000000000, numericValue - saldos.Datos.Modelo.cta_60000000000000.Total60000000000000)
                            Response.Rows.Add(currentRow)
                        End If
                    Case "80000000000000"
                        If numericValue <> saldos.Datos.Modelo.cta_80000000000000.Total80000000000000 Then
                            currentRow = Response.NewRow()
                            currentRow("tipo") = "Advertencia"
                            currentRow("message") = String.Format("Diferencia en el total de la cuenta 80000000000000, en excel {0} en el xml {1} ({2})", numericValue, saldos.Datos.Modelo.cta_80000000000000.Total80000000000000, numericValue - saldos.Datos.Modelo.cta_80000000000000.Total80000000000000)
                            Response.Rows.Add(currentRow)
                        End If
                End Select
            End If
        Next
    End Sub

    Public Sub FileSerialize(filename As String, withFormat As Boolean)
        Utilities.SerializeHandler(Of ModeloSaldosContables).SerializeToFile(_SaldosContables, filename, withFormat)



        Dim result As List(Of String) = Nothing
        'Validación según el XSD enviado por la sugese
        result = Validate.XsdValidate("ModeloSaldosContables", filename)

        If result.Count > 0 Then
            For Each item As String In result
                Helpers.XmlRespose.AddError(Response, "error", item)
            Next
        End If


        'Dim result2 As List(Of String) = Nothing

        'result2 = Validate.XslValidate("XSL Saldos Contables.xslt", filename)
        'If result2.Count > 0 Then
        '    For Each item As String In result2
        '        Helpers.XmlRespose.AddError(Response, "error", item)
        '    Next
        'End If

    End Sub

End Class

