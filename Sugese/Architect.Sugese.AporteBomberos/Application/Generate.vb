Imports System.Configuration
Imports Architect.Sugese.Utility.Helpers
Imports Architect.Utilities.Extensions
Imports ClosedXML.Excel
Imports Architect.Sugese.Domain

Public Class Generate
    Inherits Architect.Sugese.Domain.GenerateBase

    Private _AporteBomberos As New AporteBomberos.ModeloAporteBomberos

    Public Property Response As DataTable

    Public Property Encabezado() As AporteBomberos.ModeloAporteBomberosEncabezado
        Get
            Return _AporteBomberos.Encabezado
        End Get
        Set(ByVal value As AporteBomberos.ModeloAporteBomberosEncabezado)
            _AporteBomberos.Encabezado = value
        End Set
    End Property

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="periodo">Fecha correspondiente al período al cual corresponde el modelo</param>
    ''' <remarks></remarks>
    Public Sub New(periodo As Date)
        ModelInit()
        With _AporteBomberos.Encabezado
            .NombreArchivo = String.Format("{0}-ModeloAporteBomberos", ConfigurationManager.AppSettings("sugese.entidadaseguradora"))
            .Fecha = Today.ToString("yyyy-MM-dd")
            .Periodo = periodo.ToString("yyyy-MM-dd")
            .Periodicidad = Periodicidad.M
            .Moneda = CodMoneda.Item1
        End With
        Me.Response = XmlRespose.ReponseDataTable
        _AporteBomberos.Datos.Modelo.EntidadFuente = ConfigurationManager.AppSettings("sugese.codigoaseguradora")
        'For Each item As DataRow In rows.Rows
        '    AddRamoPolizaByDataRow(item)
        'Next
    End Sub

    Public Shared Function Execute(excelFileName As String, xmlFileName As String, pediodoMensual As Integer, ano As Integer) As DataTable
        Dim result As DataTable = Nothing
        With New Generate(New Date(ano, pediodoMensual, 1))
            .LoadExcelInformation(excelFileName)
            .FileSerialize(xmlFileName, False)
            result = .Response
        End With
        Return result
    End Function

    Private Sub ModelInit()
        _AporteBomberos = New ModeloAporteBomberos
        With _AporteBomberos
            .Encabezado = New ModeloAporteBomberosEncabezado
            .Datos = New ModeloAporteBomberosDatos
        End With
        With _AporteBomberos.Encabezado
            .NombreArchivo = String.Empty
            .Fecha = String.Empty
            .Periodo = String.Empty
            .Periodicidad = Periodicidad.M
            .Moneda = CodMoneda.Item1
        End With

        With _AporteBomberos.Datos
            .Modelo = New ModeloAporteBomberosDatosModelo
        End With
        With _AporteBomberos.Datos.Modelo
            '.RamoAporteBomberos(0) = New  ModeloAporteBomberosDatosModeloRamoAporteBomberos
            'ReDim .RamoAporteBomberos(0)
            .EntidadFuente = String.Empty
        End With

    End Sub

    Public Shared Function AddPolizas(items As ModeloAporteBomberosDatosModeloRamoAporteBomberosPolizas()) As ModeloAporteBomberosDatosModeloRamoAporteBomberosPolizas
        Dim result As New ModeloAporteBomberosDatosModeloRamoAporteBomberosPolizas
        If items.IsEmpty Then
            ReDim Preserve items(0)
        Else
            ReDim Preserve items(UBound(items) + 1)
        End If

        items(UBound(items)) = result
        With result
            .PrimasDirectas = 0
            .Pagar = 0
            .CodMoneda = CodMonedaInt.CRC
        End With

        Return result
    End Function

    Public Function AddRamoAporteBomberos() As ModeloAporteBomberosDatosModeloRamoAporteBomberos
        Dim result As New ModeloAporteBomberosDatosModeloRamoAporteBomberos
        If _AporteBomberos.Datos.Modelo.RamoAporteBomberos.IsEmpty Then
            ReDim Preserve _AporteBomberos.Datos.Modelo.RamoAporteBomberos(0)
        Else
            ReDim Preserve _AporteBomberos.Datos.Modelo.RamoAporteBomberos(UBound(_AporteBomberos.Datos.Modelo.RamoAporteBomberos) + 1)
        End If

        _AporteBomberos.Datos.Modelo.RamoAporteBomberos(UBound(_AporteBomberos.Datos.Modelo.RamoAporteBomberos)) = result
        With result
            '.Polizas(0) = New  ModeloAporteBomberosDatosModeloRamoAporteBomberosPolizas
            'ReDim .Polizas(0)
            .id = TipoRamo.G01
        End With

        Return result
    End Function

    Public Function Serialize(withFormat As Boolean) As String
        Return Utilities.SerializeHandler(Of AporteBomberos.ModeloAporteBomberos).Serialize(_AporteBomberos)
    End Function

    Public Sub FileSerialize(filename As String, withFormat As Boolean)
        Utilities.SerializeHandler(Of AporteBomberos.ModeloAporteBomberos).SerializeToFile(_AporteBomberos, filename, withFormat)
    End Sub

    Public Function AddRamoPolizaByDataRow(row As DataRow) As ModeloAporteBomberosDatosModeloRamoAporteBomberos
        Dim result As ModeloAporteBomberosDatosModeloRamoAporteBomberos = Nothing
        Dim witherror As Boolean = False
        Dim ramoId As TipoRamo = row.EnumValue(Of TipoRamo)("Ramo", TipoRamo.G01, Nothing, witherror)
        If witherror Then
            XmlRespose.AddError(Response, "error", String.Format("El ramo '{0}' no es valido.", row.StringValue("Ramo")))
        End If
        If _AporteBomberos.Datos.Modelo.RamoAporteBomberos.IsNotEmpty Then

            For Each item As ModeloAporteBomberosDatosModeloRamoAporteBomberos In _AporteBomberos.Datos.Modelo.RamoAporteBomberos
                If item.id = ramoId Then
                    result = item
                    Exit For
                End If
            Next

        End If
        If result.IsEmpty Then
            result = AddRamoAporteBomberos()
        End If
        With result
            .id = ramoId
        End With

        Dim result1 As New ModeloAporteBomberosDatosModeloRamoAporteBomberosPolizas
        If result.Polizas.IsEmpty Then
            ReDim Preserve result.Polizas(0)
        Else
            ReDim Preserve result.Polizas(UBound(result.Polizas) + 1)
        End If

        result.Polizas(UBound(result.Polizas)) = result1
        With result1
            witherror = False
            .CodMoneda = row.EnumValue(Of CodMonedaInt)("CodMoneda", CodMonedaInt.USD, Nothing, witherror)
            If witherror Then
                XmlRespose.AddError(Response, "error", String.Format("El CodMoneda '{0}' no es valido.", row.StringValue("CodMoneda")))
            End If
            .PrimasDirectas = row.NumericValueWithFormatDefault("PrimasDirectas", "0.00", .PrimasDirectas, Nothing)
            .Pagar = row.NumericValueWithFormatDefault("Pagar", "0.00", .Pagar, Nothing)
        End With

        Return result
    End Function

    Public Sub LoadExcelInformation(excelFilename As String)
        Dim workbook As New XLWorkbook(excelFilename)
        Dim sheet As IXLWorksheet = Nothing
        Dim value As String = String.Empty
        Dim trace As String = String.Empty
        Dim result As ModeloAporteBomberosDatosModeloRamoAporteBomberos = Nothing
        Dim witherror As Boolean = False
        Dim ramoId As TipoRamo

        sheet = workbook.Worksheet("Bomberos")

        For RowNumber As Integer = 2 To 1000
            trace = "Ramo (columna 1)"
            value = sheet.Cell(RowNumber, 1).Value
            If value.IsNotEmpty Then
                Try

                    result = Nothing
                    ramoId = sheet.EnumValue(Of TipoRamo)(RowNumber, 1, witherror)
                    If witherror Then
                        XmlRespose.AddError(Response, "error", String.Format("El ramo '{0}' no es valido.", sheet.Cell(RowNumber, 1).Value))
                    End If

                    If _AporteBomberos.Datos.Modelo.RamoAporteBomberos.IsNotEmpty Then

                        For Each item As ModeloAporteBomberosDatosModeloRamoAporteBomberos In _AporteBomberos.Datos.Modelo.RamoAporteBomberos
                            If item.id = ramoId Then
                                result = item
                                Exit For
                            End If
                        Next

                    End If
                    If result.IsEmpty Then
                        result = AddRamoAporteBomberos()
                    End If
                    With result
                        .id = ramoId
                    End With

                    Dim result1 As New ModeloAporteBomberosDatosModeloRamoAporteBomberosPolizas
                    If result.Polizas.IsEmpty Then
                        ReDim Preserve result.Polizas(0)
                    Else
                        ReDim Preserve result.Polizas(UBound(result.Polizas) + 1)
                    End If

                    result.Polizas(UBound(result.Polizas)) = result1
                    With result1
                        trace = "Ramo (columna 2)"
                        .CodMoneda = sheet.EnumValue(Of CodMonedaInt)(RowNumber, 2, witherror)
                        If witherror Then
                            XmlRespose.AddError(Response, "error", String.Format("El CodMoneda '{0}' no es valido.", sheet.Cell(RowNumber, 2).Value))
                        End If

                        trace = "Primas directas (columna 3)"
                        .PrimasDirectas = sheet.FormatDecimalValue(RowNumber, 3, "0.00")
                        trace = "Pagar (columna 4)"
                        .Pagar = sheet.FormatDecimalValue(RowNumber, 4, "0.00")
                    End With
                Catch ex As Exception
                    XmlRespose.AddError(Response, "error", String.Format("Error en la fila {1} tratando de obtener el valor de la columna '{2}'. ({0})", ex.Message, RowNumber, trace))
                End Try
            End If
        Next

        sheet = Nothing
        workbook = Nothing
    End Sub

End Class