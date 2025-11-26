Imports System.Configuration
Imports Architect.Sugese.Utility
Imports Architect.Sugese.Utility.Helpers
Imports Architect.Utilities.Extensions
Imports ClosedXML.Excel

Public Class Generate
    Inherits Architect.Sugese.Domain.GenerateBase

    Private _Polizas As New ModeloPolizas
    Public Property Response As DataTable

    ''' <summary>
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ModelInit()
        With _Polizas.Parametros
            .NombreArchivo = "ModeloPolizaRUB"
            .TipoArchivo = Sugese.Polizas.TipoArchivoType.Item0
            .TipoArchivoSpecified = True
        End With
        Me.Response = XmlRespose.ReponseDataTable
        _Polizas.Datos.Modelo.EntidadFuente = ConfigurationManager.AppSettings("sugese.codigoaseguradora")
    End Sub

    Public Shared Function Execute(xlsxFileName As String, xmlFileName As String, pediodoMensual As Integer, ano As Integer) As DataTable
        Dim result As DataTable = Nothing
        With New Generate()
            .LoadExcelInformation(xlsxFileName)
            .FileSerialize(xmlFileName, False)
            result = .Response
        End With
        Return result
    End Function

    Private Sub ModelInit()
        _Polizas = New ModeloPolizas() With {.Parametros = New ModeloPolizasParametros(),
                                                                    .Datos = New ModeloPolizasDatos()}
        With _Polizas.Parametros
            .NombreArchivo = String.Empty
        End With

        With _Polizas.Datos
            .Modelo = New ModeloPolizasDatosModelo
        End With
        With _Polizas.Datos.Modelo
            '.Poliza(0) = New ModeloPolizasDatosModeloPoliza
            .EntidadFuente = String.Empty
        End With

    End Sub

    Public Sub FileSerialize(filename As String, withFormat As Boolean)
        Dim errors As Boolean = False
        Try
            Utilities.SerializeHandler(Of Sugese.Polizas.ModeloPolizas).SerializeToFile(_Polizas, filename, withFormat)
        Catch ex As Exception
            Sugese.Utility.Helpers.XmlRespose.AddError(Response, "error", "Falla al tratar de generar el xml, debe existir algun error con los datos")
            errors = True
        End Try

        If Not errors Then
            Dim result As List(Of String) = Nothing

            'Validacion segun el XSL enviado por la sugese
            result = Validate.XslValidate("ModeloPolizas.xsl", filename)
            If result.Count > 0 Then
                For Each item As String In result
                    Sugese.Utility.Helpers.XmlRespose.AddError(Response, "error", item)
                Next

                'Else
                '    'Validacion segun el XSD enviado por la sugese
                '    result = Validate.XsdValidate("ModeloPolizas", IO.Path.GetFileNameWithoutExtension(filename))
                '    If result.Count > 0 Then
                '        For Each item As String In result
                '            Sugese.Utility.Helpers.XmlRespose.AddError(Response, "error", item)
                '        Next
                '    End If
            End If
        End If

    End Sub

    Public Shared Function AddPoliza(ByRef items As ModeloPolizasDatosModeloPoliza()) As ModeloPolizasDatosModeloPoliza
        Dim result As New ModeloPolizasDatosModeloPoliza

        If items.IsEmpty Then
            ReDim Preserve items(0)
        Else
            ReDim Preserve items(UBound(items) + 1)
        End If

        items(UBound(items)) = result
        With result
            .Tomador = New ModeloPolizasDatosModeloPolizaTomador
            '.FecSuscripcion = Date.MinValue
            '.NumPoliza = String.Empty
            '.EstadoPoliza = modelos.sugese.Generate.EstadoPoliza.Item1
            '.Asegurados(0) = New ModeloPolizasDatosModeloPolizaAsegurado
        End With
        With result.Tomador
            '.TipoIdentificacionTomador = modelos.sugese.Generate.TipoIdentificacion.Item1
            '.IdTomador = String.Empty
            '.NombreTomador = String.Empty
            '.PrimerApellidoTomador = String.Empty
            '.SegundoApellidoTomador = String.Empty
        End With
        Return result
    End Function

    Public Shared Function AddAsegurados(ByRef items As ModeloPolizasDatosModeloPolizaAsegurado()) As ModeloPolizasDatosModeloPolizaAsegurado
        Dim result As New ModeloPolizasDatosModeloPolizaAsegurado
        If items.IsEmpty Then
            ReDim Preserve items(0)
        Else
            ReDim Preserve items(UBound(items) + 1)
        End If
        items(UBound(items)) = result
        With result
            '.TipoIdentificacionAsegurado = modelos.sugese.Generate.TipoIdentificacionFisicos.Item1
            '.IdAsegurado = String.Empty
            '.NombreAsegurado = String.Empty
            '.PrimerApellidoAsegurado = String.Empty
            '.SegundoApellidoAsegurado = String.Empty
            '.FecInclusion = Date.MinValue
            '.IdentificadorDefuncion = 1
            '.TipoAccionAsegurado = modelos.sugese.Generate.TipoAccion.Item1
            .Beneficiarios = New ModeloPolizasDatosModeloPolizaAseguradoBeneficiarios
        End With
        'With result.Beneficiarios
        '    .Beneficiario(0) = New ModeloPolizasDatosModeloPolizaAseguradoBeneficiariosBeneficiario
        'End With
        Return result
    End Function

    Public Shared Function AddBeneficiario(ByRef items As ModeloPolizasDatosModeloPolizaAseguradoBeneficiariosBeneficiario()) As ModeloPolizasDatosModeloPolizaAseguradoBeneficiariosBeneficiario
        Dim result As New ModeloPolizasDatosModeloPolizaAseguradoBeneficiariosBeneficiario
        If items.IsEmpty Then
            ReDim Preserve items(0)
        Else
            ReDim Preserve items(UBound(items) + 1)
        End If
        items(UBound(items)) = result
        With result
            '.TipoDesignacion = modelos.sugese.Generate.TipodeDesignacion.Item1
            '.Descripcion = String.Empty
            '.TipoIdentificacionBeneficiario = modelos.sugese.Generate.TipoIdentificacion.Item1
            '.TipoIdentificacionBeneficiarioSpecified = False
            '.IdBeneficiario = String.Empty
            '.NombreBeneficiario = String.Empty
            '.PrimerApellidoBeneficiario = String.Empty
            '.SegundoApellidoBeneficiario = String.Empty
            '.Porcentaje = 0
            '.TipoAccionBeneficiario = modelos.sugese.Generate.TipoAccion.Item1
        End With

        Return result
    End Function

    Public Sub LoadExcelInformation(excelFilename As String)
        Dim workbook As New XLWorkbook(excelFilename)
        Dim sheet As IXLWorksheet = Nothing
        Dim value As String = String.Empty
        Dim witherror As Boolean = False

        Dim PolizaItem As ModeloPolizasDatosModeloPoliza = Nothing
        Dim AseguradoItem As ModeloPolizasDatosModeloPolizaAsegurado = Nothing
        Dim BeneficiarioItem As ModeloPolizasDatosModeloPolizaAseguradoBeneficiariosBeneficiario = Nothing
        Dim NumPolizaAnterior As String = String.Empty
        Dim IdAseguradoAnterior As String = String.Empty
        Dim subnumpoliza As String = String.Empty

        Try
            sheet = workbook.Worksheet(1)
        Catch ex As Exception
            Throw New Exception("No existe una hoja en el archivo de excel con el nombre 'Generate'", ex)

        End Try

        For RowNumber As Integer = 2 To 200000
            Trace.WriteLine(RowNumber)
            value = sheet.StringValue(RowNumber, "A")
            If value.IsNotEmpty Then
                Try
                    If value.IndexOf("-") > 0 Then

                        subnumpoliza = value.Split("-")(1)
                        value = value.Split("-")(0)
                    Else
                        subnumpoliza = String.Empty
                    End If

                    If NumPolizaAnterior <> value Then

                        PolizaItem = AddPoliza(_Polizas.Datos.Modelo.Poliza)
                        NumPolizaAnterior = value
                        IdAseguradoAnterior = String.Empty
                        With PolizaItem
                            .NumPoliza = sheet.StringValue(RowNumber, "A")
                            .TipoPoliza = sheet.EnumValue(Of TipoPoliza)(RowNumber, "B", witherror)
                            If witherror Then
                                Sugese.Utility.Helpers.XmlRespose.AddError(Response, "error", String.Format("El TipoPoliza '{0}' no es valido.", sheet.Cell(RowNumber, 2).Value))
                            End If
                            .CodProducto = sheet.StringValue(RowNumber, "E")
                            .FecSuscripcion = sheet.FormatDateTimeValue(RowNumber, "F", "yyyy-MM-dd")

                            .EstadoPoliza = sheet.EnumValue(Of EstadoPoliza)(RowNumber, "G", witherror)
                            If witherror Then
                                Sugese.Utility.Helpers.XmlRespose.AddError(Response, "error", String.Format("El EstadoPoliza '{0}' no es valido.", sheet.Cell(RowNumber, 7).Value))
                            End If
                        End With

                        With PolizaItem.Tomador
                            .TipoIdentificacionTomador = sheet.EnumValue(Of TipoIdentificacion)(RowNumber, "H", witherror)
                            If witherror Then
                                Sugese.Utility.Helpers.XmlRespose.AddError(Response, "error", String.Format("{0}:{1} El TipoIdentificacionTomador '{2}' no es valido.", RowNumber, 8, sheet.Cell(RowNumber, 8).Value))
                            End If

                            .IdTomador = sheet.StringValue(RowNumber, "I")
                            .NombreTomador = SerializeType.XMLStringEncoding(sheet.StringValue(RowNumber, "J"))
                            .PrimerApellidoTomador = SerializeType.XMLStringEncoding(sheet.StringValue(RowNumber, "K"))
                            .SegundoApellidoTomador = SerializeType.XMLStringEncoding(sheet.StringValue(RowNumber, "L"))
                        End With
                    End If

                    value = sheet.StringValue(RowNumber, "N")
                    If value.IsNotEmpty Then
                        If IdAseguradoAnterior <> value Then
                            AseguradoItem = AddAsegurados(PolizaItem.Asegurados)
                            IdAseguradoAnterior = value
                            With AseguradoItem
                                .TipoIdentificacionAsegurado = sheet.EnumValue(Of TipoIdentificacionFisicos)(RowNumber, "M", witherror)
                                If witherror Then
                                    Sugese.Utility.Helpers.XmlRespose.AddError(Response, "error", String.Format("El TipoIdentificacionAsegurado '{0}' no es valido.", sheet.Cell(RowNumber, 13).Value))
                                End If
                                .IdAsegurado = sheet.StringValue(RowNumber, "N")

                                .EstadoAseguramiento = sheet.IntegerValue(RowNumber, "O")
                                .NombreAsegurado = SerializeType.XMLStringEncoding(sheet.StringValue(RowNumber, "P"))
                                .PrimerApellidoAsegurado = SerializeType.XMLStringEncoding(sheet.StringValue(RowNumber, "Q"))
                                .SegundoApellidoAsegurado = SerializeType.XMLStringEncoding(sheet.StringValue(RowNumber, "R"))
                                If sheet.StringValue(RowNumber, "S").IsNotEmpty Then
                                    .FecInclusion = sheet.FormatDateTimeValue(RowNumber, "S", "yyyy-MM-dd")
                                End If
                                If sheet.StringValue(RowNumber, "T").IsNotEmpty Then
                                    .IdentificadorDefuncion = sheet.StringValue(RowNumber, "T")
                                Else
                                    .IdentificadorDefuncion = 1
                                End If
                                .AccionAseguramiento = sheet.StringValue(RowNumber, "U")
                                .SubNumPoliza = subnumpoliza
                            End With
                        End If
                    End If

                    If AseguradoItem.IsNotEmpty Then
                        BeneficiarioItem = AddBeneficiario(AseguradoItem.Beneficiarios.Beneficiario)
                        With BeneficiarioItem
                            .TipoDesignacion = sheet.EnumValue(Of TipodeDesignacion)(RowNumber, "V", witherror)
                            If witherror Then
                                Sugese.Utility.Helpers.XmlRespose.AddError(Response, "error", String.Format("El TipoDesignacion '{0}' no es valido.", sheet.Cell(RowNumber, 22).Value))
                            End If

                            .Descripcion = sheet.StringValue(RowNumber, "W")

                            If .TipoDesignacion = Sugese.Polizas.TipodeDesignacion.Item1 Then
                                'TODO: Mejorar para indicar si es opcional o no
                                If Not String.IsNullOrEmpty(sheet.Cell(RowNumber, "X").Value) AndAlso
                                   Not String.IsNullOrEmpty(sheet.Cell(RowNumber, "X").Value.ToString.Trim) Then
                                    .TipoIdentificacionBeneficiario = sheet.EnumValue(Of TipoIdentificacion)(RowNumber, "X", .TipoIdentificacionBeneficiarioSpecified, witherror)
                                    If witherror Then
                                        Sugese.Utility.Helpers.XmlRespose.AddError(Response, "error", String.Format("{0}:{1} El TipoIdentificacionBeneficiario '{2}' no es valido.", RowNumber, 24, sheet.Cell(RowNumber, 24).Value))
                                    End If
                                End If

                                .IdBeneficiario = sheet.StringValue(RowNumber, "Y")
                                .NombreBeneficiario = SerializeType.XMLStringEncoding(sheet.StringValue(RowNumber, "Z"))
                                .PrimerApellidoBeneficiario = SerializeType.XMLStringEncoding(sheet.StringValue(RowNumber, "AA"))
                                .SegundoApellidoBeneficiario = SerializeType.XMLStringEncoding(sheet.StringValue(RowNumber, "AB"))
                            End If
                            If .TipoDesignacion = Sugese.Polizas.TipodeDesignacion.Item2 AndAlso .Descripcion.IsEmpty() Then
                                Sugese.Utility.Helpers.XmlRespose.AddError(Response, "error", String.Format("{0}:{1} La descripción es necesaria para el tipo de designación 2 (columna X) .", RowNumber, "W"))
                            End If
                            .Porcentaje = sheet.StringValue(RowNumber, "AC", .PorcentajeSpecified)
                        End With
                    End If
                Catch ex As Exception
                    If ex.Message.StartsWith(String.Format("{0}:", RowNumber)) Then
                        Sugese.Utility.Helpers.XmlRespose.AddError(Response, "error", String.Format("Error en '{0}'", ex.Message))
                    Else
                        Sugese.Utility.Helpers.XmlRespose.AddError(Response, "error", String.Format("{1} Error en '{0}'", ex.Message, RowNumber))
                    End If
                End Try
            Else

                Exit For
            End If
        Next

        sheet = Nothing
        workbook = Nothing
    End Sub


End Class