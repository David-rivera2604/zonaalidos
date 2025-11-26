Imports Architect.Utilities
Imports Architect.Utilities.Extensions
Imports System.Configuration
Imports ClosedXML.Excel
Imports Architect.Sugese.Utility.Helpers
Imports Architect.Sugese.Domain
Imports Architect.Sugese.Utility

Public Class Generate
    Inherits Architect.Sugese.Domain.GenerateBase

    Private _InversionesFinancieras As New InversionesFinancieras.ModeloInversionesFinancieras

    Public Property Response As DataTable

    Public Property Encabezado() As InversionesFinancieras.EncabezadoTipo
        Get
            Return _InversionesFinancieras.Encabezado
        End Get
        Set(ByVal value As InversionesFinancieras.EncabezadoTipo)
            _InversionesFinancieras.Encabezado = value
        End Set
    End Property

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="periodo">Fecha correspondiente al período al cual corresponde el modelo</param>
    ''' <remarks></remarks>
    Public Sub New(periodo As Date)
        ModelInit()
        With _InversionesFinancieras.Encabezado
            .NombreArchivo = String.Format("{0}", ConfigurationManager.AppSettings("sugese.entidadaseguradora"))
            .Fecha = Today.ToString("yyyy-MM-dd")
            .Periodo = periodo.ToString("yyyy-MM-dd")
            .Periodicidad = Periodicidad.M
            .Moneda = CodMoneda.Item1
        End With
        _InversionesFinancieras.Datos.Modelo.EntidadFuente = ConfigurationManager.AppSettings("sugese.codigoaseguradora")

        Me.Response = XmlRespose.ReponseDataTable
    End Sub

    Public Shared Function Execute(xlsxFileName As String, xmlFileName As String, pediodoMensual As Integer, ano As Integer) As DataTable
        Dim result As DataTable = Nothing
        With New Generate(New Date(ano, pediodoMensual, 1))
            .LoadExcelInformation(xlsxFileName)
            .FileSerialize(xmlFileName, True)
            result = .Response
        End With
        Return result
    End Function

    Private Sub ModelInit()
        _InversionesFinancieras = New ModeloInversionesFinancieras
        With _InversionesFinancieras
            .Encabezado = New EncabezadoTipo
            .Datos = New ModeloInversionesFinancierasDatos
        End With
        With _InversionesFinancieras.Encabezado
            .NombreArchivo = String.Empty
            .Fecha = String.Empty
            .Periodo = String.Empty
            .Periodicidad = Periodicidad.M
            .Moneda = CodMoneda.Item1
        End With

        With _InversionesFinancieras.Datos
            .Modelo = New ModeloInversionesFinancierasDatosModelo
        End With
        With _InversionesFinancieras.Datos.Modelo
            ReDim .DetalleInversion(0)
            .EntidadFuente = String.Empty
        End With
    End Sub

    Public Function AddDetalleInversion() As ModeloInversionesFinancierasDatosModeloDetalleInversion
        Dim result As New ModeloInversionesFinancierasDatosModeloDetalleInversion
        ReDim Preserve _InversionesFinancieras.Datos.Modelo.DetalleInversion(UBound(_InversionesFinancieras.Datos.Modelo.DetalleInversion) + 1)
        _InversionesFinancieras.Datos.Modelo.DetalleInversion(UBound(_InversionesFinancieras.Datos.Modelo.DetalleInversion)) = result
        With result
            .CodReferencia = String.Empty
            .CodISIN = String.Empty
            .Ramo = Nothing
            .CodTitulo = CodTitulo.DI
            .NemoEmisor = String.Empty
            .NemotInstrumento = String.Empty
            .FecAdquisicion = String.Empty
            .FecVencimiento = String.Empty
            '.PeriodicidadCupon = InversionesFinancieras.PeriodTitulo.Item0
            .TasaFacial = String.Empty
            '.PaisEmision = PaisResidencia.AND
            .ValorFacial = 0
            .CostoAdquisicion = Nothing

            .AmortizacionAcumulada = Nothing

            .ValorMercadoMonedaEmision = 0
            .ValorMercadoColones = 0
            .ResultadoValoracion = Nothing

            .Rendimiento = Nothing

            .ProveedorPrecio = ProveedorPrecios.OTROS
            .PrecioPorcentual = Nothing
            .PrecioNominal = Nothing
            .PrecioRendimiento = Nothing
            .Calificadora = Nothing
            .PlazoCalificacion = Nothing
            'CUSTOM2020A
            '.RiesgoEmisor = String.Empty
            'CUSTOM2020A
            '.RiesgoCreditoEmision = String.Empty
            .CodCustodio = Nothing
            .NumCustodia = String.Empty
            .CodMoneda = CodMonedaInt.AED
        End With

        Return result
    End Function

    Public Function AddDetalleInversionByDataRow(row As DataRow) As ModeloInversionesFinancierasDatosModeloDetalleInversion
        Dim result As ModeloInversionesFinancierasDatosModeloDetalleInversion = AddDetalleInversion()
        Dim witherror As Boolean = False
        With result
            .CodReferencia = row.StringValue("CodReferencia")
            .CodISIN = row.StringValue("CodISIN")
            witherror = False
            '.Ramo = row.EnumValue(Of InversionesFinancieras.TipoRamo)("Ramo", InversionesFinancieras.TipoRamo.SG0100, .RamoSpecified, witherror)
            If witherror Then
                XmlRespose.AddError(Response, "error", String.Format("El ramo '{0}' no es valido.", row.StringValue("Ramo")))
            End If
            witherror = False
            .CodTitulo = row.EnumValue(Of CodTitulo)("CodTitulo", CodTitulo.AC, Nothing, witherror)
            If witherror Then
                XmlRespose.AddError(Response, "error", String.Format("El CodTitulo '{0}' no es valido.", row.StringValue("CodTitulo")))
            End If
            .NemoEmisor = row.StringValue("NemoEmisor")
            .NemotInstrumento = row.StringValue("NemotInstrumento")
            .FecAdquisicion = row.DateTimeValueWithFormatDefault("FecAdquisicion", "dd/MM/yyyy", .FecAdquisicion)
            .FecVencimiento = row.DateTimeValueWithFormatDefault("FecVencimiento", "dd/MM/yyyy", .FecVencimiento)
            witherror = False
            '.PeriodicidadCupon = row.EnumValue(Of InversionesFinancieras.PeriodTitulo)("PeriodicidadCupon", InversionesFinancieras.PeriodTitulo.Item0, .PeriodicidadCuponSpecified, witherror)
            If witherror Then
                XmlRespose.AddError(Response, "error", String.Format("El PeriodicidadCupon '{0}' no es valido.", row.StringValue("PeriodicidadCupon")))
            End If
            '                .TasaFacial = row.NumericValueWithFormatDefault("TasaFacial", "0.00", .TasaFacial, .TasaFacialSpecified)
            witherror = False
            .PaisEmision = row.EnumValue(Of PaisResidencia)("PaisEmision", PaisResidencia.CRI, Nothing, witherror)
            If witherror Then
                XmlRespose.AddError(Response, "error", String.Format("El PaisEmision '{0}' no es valido.", row.StringValue("PaisEmision")))
            End If
            .ValorFacial = row.NumericValueWithFormatDefault("ValorFacial", "0.00", .ValorFacial, Nothing)
            '        .CostoAdquisicion = row.NumericValueWithFormatDefault("CostoAdquisicion", "0.00", .CostoAdquisicion, .CostoAdquisicionSpecified)

            ' .AmortizacionAcumulada = row.NumericValueWithFormatDefault("AmortizacionAcumulada", "0.00", .AmortizacionAcumulada, .AmortizacionAcumuladaSpecified)
            .ValorMercadoMonedaEmision = row.NumericValueWithFormatDefault("ValorMercadoMonedaEmision", "0.00", .ValorMercadoMonedaEmision, Nothing)
            .ValorMercadoColones = row.NumericValueWithFormatDefault("ValorMercadoColones", "0.00", .ValorMercadoColones, Nothing)
            '  .ResultadoValoracion = row.NumericValueWithFormatDefault("ResultadoValoracion", "0.00", .ResultadoValoracion, .ResultadoValoracionSpecified)
            '        .Rendimiento = row.NumericValueWithFormatDefault("Rendimiento", "0.00", .Rendimiento, .RendimientoSpecified)
            witherror = False
            '.ProveedorPrecio = row.EnumValue(Of InversionesFinancieras.ProveedorPrecios)("ProveedorPrecio", InversionesFinancieras.ProveedorPrecios.PIPCA, .ProveedorPrecioSpecified, witherror)
            If witherror Then
                XmlRespose.AddError(Response, "error", String.Format("El ProveedorPrecio '{0}' no es valido.", row.StringValue("ProveedorPrecio")))
            End If
            '.PrecioPorcentual = row.NumericValueWithFormatDefault("PrecioPorcentual", "0.00", .PrecioPorcentual, .PrecioPorcentualSpecified)
            '.PrecioNominal = row.NumericValueWithFormatDefault("PrecioNominal", "0.00", .PrecioNominal, .PrecioNominalSpecified)
            '.PrecioRendimiento = row.NumericValueWithFormatDefault("PrecioRendimiento", "0.00", .PrecioRendimiento, .PrecioRendimientoSpecified)

            witherror = False
            '                .Calificadora = row.EnumValue(Of InversionesFinancieras.Calificadoras)("Calificadora", InversionesFinancieras.Calificadoras.FI, .CalificadoraSpecified, witherror)
            If witherror Then
                XmlRespose.AddError(Response, "error", String.Format("El Calificadora '{0}' no es valido.", row.StringValue("Calificadora")))
            End If
            witherror = False
            '.PlazoCalificacion = row.EnumValue(Of InversionesFinancieras.PlazoCalificacion)("PlazoCalificacion", InversionesFinancieras.PlazoCalificacion.LP, .PlazoCalificacionSpecified, witherror)
            If witherror Then
                XmlRespose.AddError(Response, "error", String.Format("El PlazoCalificacion '{0}' no es valido.", row.StringValue("PlazoCalificacion")))
            End If
            '.RiesgoEmisor = row.StringValueWithDefault("RiesgoEmisor", Nothing, .RiesgoEmisorSpecified)
            '.RiesgoCreditoEmision = row.StringValueWithDefault("RiesgoCreditoEmision", Nothing, .RiesgoCreditoEmisionSpecified)
            witherror = False
            '.CodCustodio = row.EnumValue(Of InversionesFinancieras.CodCustodio)("CodCustodio", InversionesFinancieras.CodCustodio.CBAC, .CodCustodioSpecified, witherror)
            If witherror Then
                XmlRespose.AddError(Response, "error", String.Format("El CodCustodio '{0}' no es valido.", row.StringValue("CodCustodio")))
            End If
            .NumCustodia = row.StringValue("NumCustodia")
            witherror = False
            .CodMoneda = row.EnumValue(Of CodMonedaInt)("CodMoneda", CodMonedaInt.USD, Nothing, witherror)
            If witherror Then
                XmlRespose.AddError(Response, "error", String.Format("El CodMoneda '{0}' no es valido.", row.StringValue("CodMoneda")))
            End If
            'LOGIC RULES

            ''CodIsin [A-Za-z0-9]{5,12}
            'If .CodISIN.IndexOf("-") > -1 Then
            '    .CodISIN = .CodISIN.Replace("-", String.Empty)
            'End If

            ''se debe indicar Precio Nominal ó el Precio Porcentual del instrumento. Debe indicarse únicamente uno de los precios.
            'If .PrecioNominalSpecified AndAlso .PrecioPorcentualSpecified Then
            '    If .CodTitulo = InversionesFinancieras.CodTitulo.DI OrElse
            '        .CodTitulo = InversionesFinancieras.CodTitulo.DE Then
            '        .PrecioNominal = String.Empty
            '        .PrecioNominalSpecified = False
            '    Else
            '        .PrecioPorcentual = String.Empty
            '        .PrecioPorcentualSpecified = False
            '    End If
            'End If

            ''no deben indicarse Calificadora, PlazoCalificacion, RiesgoEmisor ni RiesgoCreditoEmision, cuando el NemoEmisor sea igual a BCCR o G.
            'If .NemoEmisor.Equals("BCCR", StringComparison.CurrentCultureIgnoreCase) OrElse
            '   .NemoEmisor.Equals("G", StringComparison.CurrentCultureIgnoreCase) Then
            '    .CalificadoraSpecified = False
            '    .Calificadora = Nothing
            '    .PlazoCalificacionSpecified = False
            '    .PlazoCalificacion = Nothing
            '    .RiesgoEmisorSpecified = False
            '    .RiesgoEmisor = String.Empty
            '    .RiesgoCreditoEmisionSpecified = False
            '    .RiesgoCreditoEmision = String.Empty
            'End If

            ''no se debe indicar el elemento ProveedorPrecio cuando el CodTitulo sea CA o FA.
            'If .CodTitulo = InversionesFinancieras.CodTitulo.CA OrElse .CodTitulo = InversionesFinancieras.CodTitulo.FA Then
            '    .ProveedorPrecioSpecified = False
            '    .ProveedorPrecio = Nothing
            'End If

            '    'la calificación del riesgo instrumento [AAA] no es válida para la calificadora [FI] y el plazo [CP]
            '    'la calificación del riesgo emisor [BB+] no es válida para la calificadora [FI] y el plazo [CP]

        End With
        Return result
    End Function

    Public Function Serialize(withFormat As Boolean) As String
        Return Utilities.SerializeHandler(Of InversionesFinancieras.ModeloInversionesFinancieras).Serialize(_InversionesFinancieras)
    End Function

    Public Sub FileSerialize(filename As String, withFormat As Boolean)
        Utilities.SerializeHandler(Of InversionesFinancieras.ModeloInversionesFinancieras).SerializeToFile(_InversionesFinancieras, filename, withFormat)

        Dim result As List(Of String) = Nothing

        'Validacion segun el XSD enviado por la sugese
        result = Validate.XsdValidate("ModeloInversionesFinancieras", filename)

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

    Public Sub LoadExcelInformation(excelFilename As String)
        Dim workbook As New XLWorkbook(excelFilename)
        Dim sheet As IXLWorksheet = workbook.Worksheet("Inversiones")
        Dim value As String = String.Empty
        Dim ref As String = String.Empty
        Dim result As ModeloInversionesFinancierasDatosModeloDetalleInversion = Nothing
        Dim withError As Boolean

        For RowNumber As Integer = 2 To 1000
            value = sheet.Cell(RowNumber, 1).Value
            If value.IsNotEmpty Then
                result = AddDetalleInversion()

                With result
                    .CodMoneda = sheet.EnumValue(Of CodMonedaInt)(RowNumber, "A", withError)
                    If withError Then
                        XmlRespose.AddError(Response, "error", String.Format("El CodMoneda '{0}' no es valido.", sheet.Cell(RowNumber, "A").Value))
                    End If

                    If sheet.StringValue(RowNumber, "B").IsEmpty Then
                        .CodTipoValoracion = CodigoTipoValoracion.CA
                    Else
                        .CodTipoValoracion = sheet.EnumValue(Of CodigoTipoValoracion)(RowNumber, "B", withError)
                        If withError Then
                            XmlRespose.AddError(Response, "error", String.Format("El CodTipoValoracion '{0}' no es valido.", sheet.Cell(RowNumber, "B").Value))
                        End If
                    End If

                    .CodReferencia = sheet.StringValue(RowNumber, "C")
                    ref = .CodReferencia
                    .CodISIN = sheet.StringValue(RowNumber, "D")

                    .Ramo = sheet.EnumValue(Of TipoRamo)(RowNumber, "E", .RamoSpecified, withError)
                    If withError Then
                        XmlRespose.AddError(Response, "error", String.Format("El ramo '{0}' no es valido.", sheet.Cell(RowNumber, "E").Value))
                    End If

                    .CodTitulo = sheet.EnumValue(Of CodTitulo)(RowNumber, "F", withError)
                    If withError Then
                        XmlRespose.AddError(Response, "error", String.Format("El CodTitulo '{0}' no es valido.", sheet.Cell(RowNumber, "F").Value))
                    End If

                    .NemoEmisor = sheet.StringValue(RowNumber, "G")
                    .NemotInstrumento = sheet.StringValue(RowNumber, "H")
                    .FecAdquisicion = sheet.FormatDateTimeValue(RowNumber, "I", "dd/MM/yyyy")
                    .FecVencimiento = sheet.FormatDateTimeValue(RowNumber, "J", "dd/MM/yyyy")

                    .PeriodicidadCupon = sheet.EnumValue(Of PeriodicidadCupon)(RowNumber, "K", .PeriodicidadCuponSpecified, withError)
                    If withError Then
                        XmlRespose.AddError(Response, "error", String.Format("El PeriodicidadCupon '{0}' no es valido.", sheet.Cell(RowNumber, "K").Value))
                    End If

                    .TasaFacial = sheet.FormatDecimalValue(RowNumber, "L", "0.00", .TasaFacialSpecified)

                    .PaisEmision = sheet.EnumValue(Of PaisResidencia)(RowNumber, "M", withError)
                    If withError Then
                        XmlRespose.AddError(Response, "error", String.Format("En el detalle de inversión con CodReferencia [{1}], El PaisEmision '{0}' no es valido.", sheet.Cell(RowNumber, "M").Value, ref))
                    End If

                    .ValorFacial = sheet.FormatDecimalValue(RowNumber, "N", "0.00")
                    .CostoAdquisicion = sheet.FormatDecimalValue(RowNumber, "O", "0.00")
                    .AmortizacionAcumulada = sheet.FormatDecimalValue(RowNumber, "P", "0.00", .AmortizacionAcumuladaSpecified)
                    .ValorMercadoMonedaEmision = sheet.FormatDecimalValue(RowNumber, "Q", "0.00", .ValorMercadoMonedaEmisionSpecified)
                    .ValorMercadoColones = sheet.FormatDecimalValue(RowNumber, "R", "0.00", .ValorMercadoColonesSpecified)
                    .ResultadoValoracion = sheet.FormatDecimalValue(RowNumber, "S", "0.00", .ResultadoValoracionSpecified)
                    .Rendimiento = sheet.FormatDecimalValue(RowNumber, "T", "0.00", .RendimientoSpecified)

                    .ValorLibrosMonedaOriginal = sheet.FormatDecimalValue(RowNumber, "U", "0.00", .ValorLibrosMonedaOriginalSpecified)
                    .ValorLibrosColones = sheet.FormatDecimalValue(RowNumber, "V", "0.00", .ValorLibrosColonesSpecified)
                    .Deterioro = sheet.FormatDecimalValue(RowNumber, "W", "0.00", .DeterioroSpecified)

                    .ProveedorPrecio = sheet.EnumValue(Of ProveedorPrecios)(RowNumber, "X", .ProveedorPrecioSpecified, withError)
                    If withError Then
                        XmlRespose.AddError(Response, "error", String.Format("El ProveedorPrecio '{0}' no es valido.", sheet.Cell(RowNumber, "X").Value))
                    End If

                    .PrecioPorcentual = sheet.FormatDecimalValue(RowNumber, "Y", "0.00", .PrecioPorcentualSpecified)
                    .PrecioNominal = sheet.FormatDecimalValue(RowNumber, "Z", "0.00", .PrecioNominalSpecified)
                    .PrecioRendimiento = sheet.FormatDecimalValue(RowNumber, "AA", "0.00", .PrecioRendimientoSpecified)

                    .Calificadora = sheet.EnumValue(Of Calificadoras)(RowNumber, "AB", .CalificadoraSpecified, withError)
                    If withError Then
                        XmlRespose.AddError(Response, "error", String.Format("El Calificadora '{0}' no es valido.", sheet.Cell(RowNumber, "AB").Value))
                    End If

                    .PlazoCalificacion = sheet.EnumValue(Of PlazoCalificacion)(RowNumber, "AC", .PlazoCalificacionSpecified, withError)
                    If withError Then
                        XmlRespose.AddError(Response, "error", String.Format("El PlazoCalificacion '{0}' no es valido.", sheet.Cell(RowNumber, "AC").Value))
                    End If

                    .RiesgoEmisor = sheet.StringValue(RowNumber, "AD", .RiesgoEmisorSpecified)
                    .RiesgoCreditoEmision = sheet.StringValue(RowNumber, "AE", .RiesgoCreditoEmisionSpecified)

                    .CodCustodio = sheet.EnumValue(Of CodCustodio)(RowNumber, "AF", .CodCustodioSpecified, withError)
                    If withError Then
                        XmlRespose.AddError(Response, "error", String.Format("El CodCustodio '{0}' no es valido.", sheet.Cell(RowNumber, "AF").Value))
                    End If

                    .NumCustodia = sheet.StringValue(RowNumber, "AG")

                    'LOGIC RULES

                    ''CodIsin [A-Za-z0-9]{5,12}
                    'If .CodISIN.IndexOf("-") > -1 Then
                    '    .CodISIN = .CodISIN.Replace("-", String.Empty)
                    'End If

                    ''se debe indicar Precio Nominal ó el Precio Porcentual del instrumento. Debe indicarse únicamente uno de los precios.
                    'If .PrecioNominalSpecified AndAlso .PrecioPorcentualSpecified Then
                    '    If .CodTitulo = InversionesFinancieras.CodTitulo.DI OrElse
                    '        .CodTitulo = InversionesFinancieras.CodTitulo.DE Then
                    '        .PrecioNominal = String.Empty
                    '        .PrecioNominalSpecified = False
                    '    Else
                    '        .PrecioPorcentual = String.Empty
                    '        .PrecioPorcentualSpecified = False
                    '    End If
                    'End If

                    ''no deben indicarse Calificadora, PlazoCalificacion, RiesgoEmisor ni RiesgoCreditoEmision, cuando el NemoEmisor sea igual a BCCR o G.
                    'If .NemoEmisor.Equals("BCCR", StringComparison.CurrentCultureIgnoreCase) OrElse
                    '   .NemoEmisor.Equals("G", StringComparison.CurrentCultureIgnoreCase) Then
                    '    .CalificadoraSpecified = False
                    '    .Calificadora = Nothing
                    '    .PlazoCalificacionSpecified = False
                    '    .PlazoCalificacion = Nothing
                    '    .RiesgoEmisorSpecified = False
                    '    .RiesgoEmisor = String.Empty
                    '    .RiesgoCreditoEmisionSpecified = False
                    '    .RiesgoCreditoEmision = String.Empty
                    'End If

                    ''no se debe indicar el elemento ProveedorPrecio cuando el CodTitulo sea CA o FA.
                    'If .CodTitulo = InversionesFinancieras.CodTitulo.CA OrElse .CodTitulo = InversionesFinancieras.CodTitulo.FA Then
                    '    .ProveedorPrecioSpecified = False
                    '    .ProveedorPrecio = Nothing
                    'End If

                    '    'la calificación del riesgo instrumento [AAA] no es válida para la calificadora [FI] y el plazo [CP]
                    '    'la calificación del riesgo emisor [BB+] no es válida para la calificadora [FI] y el plazo [CP]

                End With

            End If
        Next

        sheet = Nothing
        workbook = Nothing
    End Sub

End Class