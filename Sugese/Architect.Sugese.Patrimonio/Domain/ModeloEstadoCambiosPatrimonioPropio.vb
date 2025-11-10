Imports Architect.Sugese.Domain

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropio

    Private encabezadoField As EncabezadoTipo

    Private datosField As ModeloEstadoCambiosPatrimonioPropioDatos

    '''<remarks/>
    Public Property Encabezado() As EncabezadoTipo
        Get
            Return Me.encabezadoField
        End Get
        Set
            Me.encabezadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Datos() As ModeloEstadoCambiosPatrimonioPropioDatos
        Get
            Return Me.datosField
        End Get
        Set
            Me.datosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code")>
Partial Public Class EncabezadoTipo

    Private nombreArchivoField As String

    Private fechaField As String

    Private periodoField As String

    Private periodicidadField As Periodicidad

    Private monedaField As CodMoneda

    Private pruebaField As System.Nullable(Of Boolean)

    Private pruebaFieldSpecified As Boolean

    '''<remarks/>
    Public Property NombreArchivo() As String
        Get
            Return Me.nombreArchivoField
        End Get
        Set
            Me.nombreArchivoField = Value
        End Set
    End Property

    'CUSTOM2020A
    '''<remarks/>
    '<System.Xml.Serialization.XmlElementAttribute(DataType:="date")>
    Public Property Fecha() As String
        Get
            Return Me.fechaField
        End Get
        Set
            Me.fechaField = Value
        End Set
    End Property

    'CUSTOM2020A
    '''<remarks/>
    '<System.Xml.Serialization.XmlElementAttribute(DataType:="date")>
    Public Property Periodo() As String
        Get
            Return Me.periodoField
        End Get
        Set
            Me.periodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Periodicidad() As Periodicidad
        Get
            Return Me.periodicidadField
        End Get
        Set
            Me.periodicidadField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Moneda() As CodMoneda
        Get
            Return Me.monedaField
        End Get
        Set
            Me.monedaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property Prueba() As System.Nullable(Of Boolean)
        Get
            Return Me.pruebaField
        End Get
        Set
            Me.pruebaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property PruebaSpecified() As Boolean
        Get
            Return Me.pruebaFieldSpecified
        End Get
        Set
            Me.pruebaFieldSpecified = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:cap:ties:ressugesetypes:v1")>
Public Enum Periodicidad

    '''<remarks/>
    M

    '''<remarks/>
    T
End Enum



'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatos

    Private modeloField As ModeloEstadoCambiosPatrimonioPropioDatosModelo

    '''<remarks/>
    Public Property Modelo() As ModeloEstadoCambiosPatrimonioPropioDatosModelo
        Get
            Return Me.modeloField
        End Get
        Set
            Me.modeloField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModelo

    Private saldo1EneAnnoAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnterior

    Private saldoCorregidoInicioAnnoAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnterior

    Private saldo31DicAnnoAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnterior

    Private saldo1EneAnnoActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActual

    Private saldoCorregidoInicioAnnoActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoActual

    Private originadosAnnoActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActual

    Private tranferenciasResultadosAnnoActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActual

    Private saldoFinalAnnoActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActual

    Private entidadFuenteField As String

    '''<remarks/>
    Public Property Saldo1EneAnnoAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnterior
        Get
            Return Me.saldo1EneAnnoAnteriorField
        End Get
        Set
            Me.saldo1EneAnnoAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SaldoCorregidoInicioAnnoAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnterior
        Get
            Return Me.saldoCorregidoInicioAnnoAnteriorField
        End Get
        Set
            Me.saldoCorregidoInicioAnnoAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Saldo31DicAnnoAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnterior
        Get
            Return Me.saldo31DicAnnoAnteriorField
        End Get
        Set
            Me.saldo31DicAnnoAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Saldo1EneAnnoActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActual
        Get
            Return Me.saldo1EneAnnoActualField
        End Get
        Set
            Me.saldo1EneAnnoActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SaldoCorregidoInicioAnnoActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoActual
        Get
            Return Me.saldoCorregidoInicioAnnoActualField
        End Get
        Set
            Me.saldoCorregidoInicioAnnoActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OriginadosAnnoActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActual
        Get
            Return Me.originadosAnnoActualField
        End Get
        Set
            Me.originadosAnnoActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property TranferenciasResultadosAnnoActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActual
        Get
            Return Me.tranferenciasResultadosAnnoActualField
        End Get
        Set
            Me.tranferenciasResultadosAnnoActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SaldoFinalAnnoActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActual
        Get
            Return Me.saldoFinalAnnoActualField
        End Get
        Set
            Me.saldoFinalAnnoActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property EntidadFuente() As String
        Get
            Return Me.entidadFuenteField
        End Get
        Set
            Me.entidadFuenteField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnterior

    Private desgloseSaldoInicioAnnoField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorDesgloseSaldoInicioAnno

    Private cambiosPoliticasContablesEneAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCambiosPoliticasContablesEneAnterior

    Private correccionErroresFundamentalesEneAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCorreccionErroresFundamentalesEneAnterior

    Private totalSaldo1EneAnnoAnteriorField As Decimal

    '''<remarks/>
    Public Property DesgloseSaldoInicioAnno() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorDesgloseSaldoInicioAnno
        Get
            Return Me.desgloseSaldoInicioAnnoField
        End Get
        Set
            Me.desgloseSaldoInicioAnnoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CambiosPoliticasContablesEneAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCambiosPoliticasContablesEneAnterior
        Get
            Return Me.cambiosPoliticasContablesEneAnteriorField
        End Get
        Set
            Me.cambiosPoliticasContablesEneAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CorreccionErroresFundamentalesEneAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCorreccionErroresFundamentalesEneAnterior
        Get
            Return Me.correccionErroresFundamentalesEneAnteriorField
        End Get
        Set
            Me.correccionErroresFundamentalesEneAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSaldo1EneAnnoAnterior() As Decimal
        Get
            Return Me.totalSaldo1EneAnnoAnteriorField
        End Get
        Set
            Me.totalSaldo1EneAnnoAnteriorField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorDesgloseSaldoInicioAnno

    Private capSocialEneAnteriorField As Decimal

    Private aportesNoCapitalizadosEneAnteriorField As Decimal

    Private ajustesEneAnteriorField As Decimal

    Private reservasEneAnteriorField As Decimal

    Private resultadosPrincipioPeriodoEneAnteriorField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property CapSocialEneAnterior() As Decimal
        Get
            Return Me.capSocialEneAnteriorField
        End Get
        Set
            Me.capSocialEneAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property AportesNoCapitalizadosEneAnterior() As Decimal
        Get
            Return Me.aportesNoCapitalizadosEneAnteriorField
        End Get
        Set
            Me.aportesNoCapitalizadosEneAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property AjustesEneAnterior() As Decimal
        Get
            Return Me.ajustesEneAnteriorField
        End Get
        Set
            Me.ajustesEneAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ReservasEneAnterior() As Decimal
        Get
            Return Me.reservasEneAnteriorField
        End Get
        Set
            Me.reservasEneAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ResultadosPrincipioPeriodoEneAnterior() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoEneAnteriorField
        End Get
        Set
            Me.resultadosPrincipioPeriodoEneAnteriorField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCambiosPoliticasContablesEneAnterior

    Private desgloseCambiosPoliticasContablesEneAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCambiosPoliticasContablesEneAnteriorDesgloseCambiosPoliticasContablesEneAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseCambiosPoliticasContablesEneAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCambiosPoliticasContablesEneAnteriorDesgloseCambiosPoliticasContablesEneAnterior
        Get
            Return Me.desgloseCambiosPoliticasContablesEneAnteriorField
        End Get
        Set
            Me.desgloseCambiosPoliticasContablesEneAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCambiosPoliticasContablesEneAnteriorDesgloseCambiosPoliticasContablesEneAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCorreccionErroresFundamentalesEneAnterior

    Private desgloseCorreccionErroresFundamentalesEneAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCorreccionErroresFundamentalesEneAnteriorDesgloseCorreccionErroresFundamentalesEneAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseCorreccionErroresFundamentalesEneAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCorreccionErroresFundamentalesEneAnteriorDesgloseCorreccionErroresFundamentalesEneAnterior
        Get
            Return Me.desgloseCorreccionErroresFundamentalesEneAnteriorField
        End Get
        Set
            Me.desgloseCorreccionErroresFundamentalesEneAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoAnteriorCorreccionErroresFundamentalesEneAnteriorDesgloseCorreccionErroresFundamentalesEneAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnterior

    Private desgloseSaldoCorregidoInicioAnnoAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorDesgloseSaldoCorregidoInicioAnnoAnterior

    Private ajustesConversionEstadosFinancierosIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesConversionEstadosFinancierosIniAnterior

    Private resultadosPeriodo1Field As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorResultadosPeriodo1

    Private dividendosPeriodo0Field As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorDividendosPeriodo0

    Private estimacionesRiesgosActBancariaIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEstimacionesRiesgosActBancariaIniAnterior

    Private reservasLegalesOtrasEstatutariasIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorReservasLegalesOtrasEstatutariasIniAnterior

    Private compraVentaAccionesTesoreriaIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCompraVentaAccionesTesoreriaIniAnterior

    Private emisionAccionesIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEmisionAccionesIniAnterior

    Private capitalPagadoAdicionalIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCapitalPagadoAdicionalIniAnterior

    Private superavitRevaPropiedadMobiliarioEquipoIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaPropiedadMobiliarioEquipoIniAnterior

    Private ajustesValuacionInversionesValRazCambiosResulIntegIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior

    Private ajustesValuacionInstrumentosRestringidosIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosRestringidosIniAnterior

    Private ajustesValuacionInstrumentosCesacionPagoIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosCesacionPagoIniAnterior

    Private superavitRevaOtrosActivosField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaOtrosActivos

    Private otrosCorregidosIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorOtrosCorregidosIniAnterior

    Private totalSaldoCorregidoInicioAnnoAnteriorField As Decimal

    '''<remarks/>
    Public Property DesgloseSaldoCorregidoInicioAnnoAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorDesgloseSaldoCorregidoInicioAnnoAnterior
        Get
            Return Me.desgloseSaldoCorregidoInicioAnnoAnteriorField
        End Get
        Set
            Me.desgloseSaldoCorregidoInicioAnnoAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AjustesConversionEstadosFinancierosIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesConversionEstadosFinancierosIniAnterior
        Get
            Return Me.ajustesConversionEstadosFinancierosIniAnteriorField
        End Get
        Set
            Me.ajustesConversionEstadosFinancierosIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPeriodo1() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorResultadosPeriodo1
        Get
            Return Me.resultadosPeriodo1Field
        End Get
        Set
            Me.resultadosPeriodo1Field = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DividendosPeriodo0() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorDividendosPeriodo0
        Get
            Return Me.dividendosPeriodo0Field
        End Get
        Set
            Me.dividendosPeriodo0Field = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EstimacionesRiesgosActBancariaIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEstimacionesRiesgosActBancariaIniAnterior
        Get
            Return Me.estimacionesRiesgosActBancariaIniAnteriorField
        End Get
        Set
            Me.estimacionesRiesgosActBancariaIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReservasLegalesOtrasEstatutariasIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorReservasLegalesOtrasEstatutariasIniAnterior
        Get
            Return Me.reservasLegalesOtrasEstatutariasIniAnteriorField
        End Get
        Set
            Me.reservasLegalesOtrasEstatutariasIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CompraVentaAccionesTesoreriaIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCompraVentaAccionesTesoreriaIniAnterior
        Get
            Return Me.compraVentaAccionesTesoreriaIniAnteriorField
        End Get
        Set
            Me.compraVentaAccionesTesoreriaIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EmisionAccionesIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEmisionAccionesIniAnterior
        Get
            Return Me.emisionAccionesIniAnteriorField
        End Get
        Set
            Me.emisionAccionesIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CapitalPagadoAdicionalIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCapitalPagadoAdicionalIniAnterior
        Get
            Return Me.capitalPagadoAdicionalIniAnteriorField
        End Get
        Set
            Me.capitalPagadoAdicionalIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SuperavitRevaPropiedadMobiliarioEquipoIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaPropiedadMobiliarioEquipoIniAnterior
        Get
            Return Me.superavitRevaPropiedadMobiliarioEquipoIniAnteriorField
        End Get
        Set
            Me.superavitRevaPropiedadMobiliarioEquipoIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AjustesValuacionInversionesValRazCambiosResulIntegIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior
        Get
            Return Me.ajustesValuacionInversionesValRazCambiosResulIntegIniAnteriorField
        End Get
        Set
            Me.ajustesValuacionInversionesValRazCambiosResulIntegIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AjustesValuacionInstrumentosRestringidosIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosRestringidosIniAnterior
        Get
            Return Me.ajustesValuacionInstrumentosRestringidosIniAnteriorField
        End Get
        Set
            Me.ajustesValuacionInstrumentosRestringidosIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AjustesValuacionInstrumentosCesacionPagoIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosCesacionPagoIniAnterior
        Get
            Return Me.ajustesValuacionInstrumentosCesacionPagoIniAnteriorField
        End Get
        Set
            Me.ajustesValuacionInstrumentosCesacionPagoIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SuperavitRevaOtrosActivos() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaOtrosActivos
        Get
            Return Me.superavitRevaOtrosActivosField
        End Get
        Set
            Me.superavitRevaOtrosActivosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosCorregidosIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorOtrosCorregidosIniAnterior
        Get
            Return Me.otrosCorregidosIniAnteriorField
        End Get
        Set
            Me.otrosCorregidosIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSaldoCorregidoInicioAnnoAnterior() As Decimal
        Get
            Return Me.totalSaldoCorregidoInicioAnnoAnteriorField
        End Get
        Set
            Me.totalSaldoCorregidoInicioAnnoAnteriorField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorDesgloseSaldoCorregidoInicioAnnoAnterior

    Private capSocialIniAnteriorField As Decimal

    Private aportesNoCapitalizadosIniAnteriorField As Decimal

    Private ajustesIniAnteriorField As Decimal

    Private reservasIniAnteriorField As Decimal

    Private resultadosPrincipioPeriodoIniAnteriorField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property CapSocialIniAnterior() As Decimal
        Get
            Return Me.capSocialIniAnteriorField
        End Get
        Set
            Me.capSocialIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property AportesNoCapitalizadosIniAnterior() As Decimal
        Get
            Return Me.aportesNoCapitalizadosIniAnteriorField
        End Get
        Set
            Me.aportesNoCapitalizadosIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property AjustesIniAnterior() As Decimal
        Get
            Return Me.ajustesIniAnteriorField
        End Get
        Set
            Me.ajustesIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ReservasIniAnterior() As Decimal
        Get
            Return Me.reservasIniAnteriorField
        End Get
        Set
            Me.reservasIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ResultadosPrincipioPeriodoIniAnterior() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoIniAnteriorField
        End Get
        Set
            Me.resultadosPrincipioPeriodoIniAnteriorField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesConversionEstadosFinancierosIniAnterior

    Private desgloseAjustesConversionEstadosFinancierosIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesConversionEstadosFinancierosIniAnteriorDesgloseAjustesConversionEstadosFinancierosIniAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAjustesConversionEstadosFinancierosIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesConversionEstadosFinancierosIniAnteriorDesgloseAjustesConversionEstadosFinancierosIniAnterior
        Get
            Return Me.desgloseAjustesConversionEstadosFinancierosIniAnteriorField
        End Get
        Set
            Me.desgloseAjustesConversionEstadosFinancierosIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesConversionEstadosFinancierosIniAnteriorDesgloseAjustesConversionEstadosFinancierosIniAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorResultadosPeriodo1

    Private desgloseResultadosPeriodo1Field As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorResultadosPeriodo1DesgloseResultadosPeriodo1

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseResultadosPeriodo1() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorResultadosPeriodo1DesgloseResultadosPeriodo1
        Get
            Return Me.desgloseResultadosPeriodo1Field
        End Get
        Set
            Me.desgloseResultadosPeriodo1Field = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorResultadosPeriodo1DesgloseResultadosPeriodo1

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorDividendosPeriodo0

    Private desgloseDividendosPeriodo0Field As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorDividendosPeriodo0DesgloseDividendosPeriodo0

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseDividendosPeriodo0() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorDividendosPeriodo0DesgloseDividendosPeriodo0
        Get
            Return Me.desgloseDividendosPeriodo0Field
        End Get
        Set
            Me.desgloseDividendosPeriodo0Field = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorDividendosPeriodo0DesgloseDividendosPeriodo0

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEstimacionesRiesgosActBancariaIniAnterior

    Private desgloseEstimacionesRiesgosActBancariaIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEstimacionesRiesgosActBancariaIniAnteriorDesgloseEstimacionesRiesgosActBancariaIniAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseEstimacionesRiesgosActBancariaIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEstimacionesRiesgosActBancariaIniAnteriorDesgloseEstimacionesRiesgosActBancariaIniAnterior
        Get
            Return Me.desgloseEstimacionesRiesgosActBancariaIniAnteriorField
        End Get
        Set
            Me.desgloseEstimacionesRiesgosActBancariaIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEstimacionesRiesgosActBancariaIniAnteriorDesgloseEstimacionesRiesgosActBancariaIniAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorReservasLegalesOtrasEstatutariasIniAnterior

    Private desgloseReservasLegalesOtrasEstatutariasIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorReservasLegalesOtrasEstatutariasIniAnteriorDesgloseReservasLegalesOtrasEstatutariasIniAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseReservasLegalesOtrasEstatutariasIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorReservasLegalesOtrasEstatutariasIniAnteriorDesgloseReservasLegalesOtrasEstatutariasIniAnterior
        Get
            Return Me.desgloseReservasLegalesOtrasEstatutariasIniAnteriorField
        End Get
        Set
            Me.desgloseReservasLegalesOtrasEstatutariasIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorReservasLegalesOtrasEstatutariasIniAnteriorDesgloseReservasLegalesOtrasEstatutariasIniAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCompraVentaAccionesTesoreriaIniAnterior

    Private desgloseCompraVentaAccionesTesoreriaIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCompraVentaAccionesTesoreriaIniAnteriorDesgloseCompraVentaAccionesTesoreriaIniAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseCompraVentaAccionesTesoreriaIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCompraVentaAccionesTesoreriaIniAnteriorDesgloseCompraVentaAccionesTesoreriaIniAnterior
        Get
            Return Me.desgloseCompraVentaAccionesTesoreriaIniAnteriorField
        End Get
        Set
            Me.desgloseCompraVentaAccionesTesoreriaIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCompraVentaAccionesTesoreriaIniAnteriorDesgloseCompraVentaAccionesTesoreriaIniAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEmisionAccionesIniAnterior

    Private desgloseEmisionAccionesIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEmisionAccionesIniAnteriorDesgloseEmisionAccionesIniAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseEmisionAccionesIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEmisionAccionesIniAnteriorDesgloseEmisionAccionesIniAnterior
        Get
            Return Me.desgloseEmisionAccionesIniAnteriorField
        End Get
        Set
            Me.desgloseEmisionAccionesIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorEmisionAccionesIniAnteriorDesgloseEmisionAccionesIniAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCapitalPagadoAdicionalIniAnterior

    Private desgloseCapitalPagadoAdicionalIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCapitalPagadoAdicionalIniAnteriorDesgloseCapitalPagadoAdicionalIniAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseCapitalPagadoAdicionalIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCapitalPagadoAdicionalIniAnteriorDesgloseCapitalPagadoAdicionalIniAnterior
        Get
            Return Me.desgloseCapitalPagadoAdicionalIniAnteriorField
        End Get
        Set
            Me.desgloseCapitalPagadoAdicionalIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorCapitalPagadoAdicionalIniAnteriorDesgloseCapitalPagadoAdicionalIniAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaPropiedadMobiliarioEquipoIniAnterior

    Private desgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaPropiedadMobiliarioEquipoIniAnteriorDesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaPropiedadMobiliarioEquipoIniAnteriorDesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior
        Get
            Return Me.desgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnteriorField
        End Get
        Set
            Me.desgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaPropiedadMobiliarioEquipoIniAnteriorDesgloseSuperavitRevaPropiedadMobiliarioEquipoIniAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior

    Private desgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInversionesValRazCambiosResulIntegIniAnteriorDesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInversionesValRazCambiosResulIntegIniAnteriorDesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior
        Get
            Return Me.desgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnteriorField
        End Get
        Set
            Me.desgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInversionesValRazCambiosResulIntegIniAnteriorDesgloseAjustesValuacionInversionesValRazCambiosResulIntegIniAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosRestringidosIniAnterior

    Private desgloseAjustesValuacionInstrumentosRestringidosIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosRestringidosIniAnteriorDesgloseAjustesValuacionInstrumentosRestringidosIniAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAjustesValuacionInstrumentosRestringidosIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosRestringidosIniAnteriorDesgloseAjustesValuacionInstrumentosRestringidosIniAnterior
        Get
            Return Me.desgloseAjustesValuacionInstrumentosRestringidosIniAnteriorField
        End Get
        Set
            Me.desgloseAjustesValuacionInstrumentosRestringidosIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosRestringidosIniAnteriorDesgloseAjustesValuacionInstrumentosRestringidosIniAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosCesacionPagoIniAnterior

    Private desgloseAjustesValuacionInstrumentosCesacionPagoIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosCesacionPagoIniAnteriorDesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosCesacionPagoIniAnteriorDesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior
        Get
            Return Me.desgloseAjustesValuacionInstrumentosCesacionPagoIniAnteriorField
        End Get
        Set
            Me.desgloseAjustesValuacionInstrumentosCesacionPagoIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorAjustesValuacionInstrumentosCesacionPagoIniAnteriorDesgloseAjustesValuacionInstrumentosCesacionPagoIniAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaOtrosActivos

    Private desgloseSuperavitRevaOtrosActivosField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaOtrosActivosDesgloseSuperavitRevaOtrosActivos

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseSuperavitRevaOtrosActivos() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaOtrosActivosDesgloseSuperavitRevaOtrosActivos
        Get
            Return Me.desgloseSuperavitRevaOtrosActivosField
        End Get
        Set
            Me.desgloseSuperavitRevaOtrosActivosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorSuperavitRevaOtrosActivosDesgloseSuperavitRevaOtrosActivos

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorOtrosCorregidosIniAnterior

    Private desgloseOtrosIniAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorOtrosCorregidosIniAnteriorDesgloseOtrosIniAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseOtrosIniAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorOtrosCorregidosIniAnteriorDesgloseOtrosIniAnterior
        Get
            Return Me.desgloseOtrosIniAnteriorField
        End Get
        Set
            Me.desgloseOtrosIniAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoAnteriorOtrosCorregidosIniAnteriorDesgloseOtrosIniAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnterior

    Private desgloseSaldo31DicAnnoAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorDesgloseSaldo31DicAnnoAnterior

    Private atribuidoParticipNoControlFinAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoParticipNoControlFinAnterior

    Private atribuidoControladoraFinAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoControladoraFinAnterior

    Private totalSaldo31DicAnnoAnteriorField As Decimal

    '''<remarks/>
    Public Property DesgloseSaldo31DicAnnoAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorDesgloseSaldo31DicAnnoAnterior
        Get
            Return Me.desgloseSaldo31DicAnnoAnteriorField
        End Get
        Set
            Me.desgloseSaldo31DicAnnoAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AtribuidoParticipNoControlFinAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoParticipNoControlFinAnterior
        Get
            Return Me.atribuidoParticipNoControlFinAnteriorField
        End Get
        Set
            Me.atribuidoParticipNoControlFinAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AtribuidoControladoraFinAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoControladoraFinAnterior
        Get
            Return Me.atribuidoControladoraFinAnteriorField
        End Get
        Set
            Me.atribuidoControladoraFinAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSaldo31DicAnnoAnterior() As Decimal
        Get
            Return Me.totalSaldo31DicAnnoAnteriorField
        End Get
        Set
            Me.totalSaldo31DicAnnoAnteriorField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorDesgloseSaldo31DicAnnoAnterior

    Private capSocialFinAnteriorField As Decimal

    Private aportesNoCapitalizadosFinAnteriorField As Decimal

    Private ajustesFinAnteriorField As Decimal

    Private reservasFinAnteriorField As Decimal

    Private resultadosPrincipioPeriodoFinAnteriorField As Decimal

    '''<remarks/>
    Public Property CapSocialFinAnterior() As Decimal
        Get
            Return Me.capSocialFinAnteriorField
        End Get
        Set
            Me.capSocialFinAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizadosFinAnterior() As Decimal
        Get
            Return Me.aportesNoCapitalizadosFinAnteriorField
        End Get
        Set
            Me.aportesNoCapitalizadosFinAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AjustesFinAnterior() As Decimal
        Get
            Return Me.ajustesFinAnteriorField
        End Get
        Set
            Me.ajustesFinAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReservasFinAnterior() As Decimal
        Get
            Return Me.reservasFinAnteriorField
        End Get
        Set
            Me.reservasFinAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodoFinAnterior() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoFinAnteriorField
        End Get
        Set
            Me.resultadosPrincipioPeriodoFinAnteriorField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoParticipNoControlFinAnterior

    Private desgloseAtribuidoParticipNoControlFinAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoParticipNoControlFinAnteriorDesgloseAtribuidoParticipNoControlFinAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAtribuidoParticipNoControlFinAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoParticipNoControlFinAnteriorDesgloseAtribuidoParticipNoControlFinAnterior
        Get
            Return Me.desgloseAtribuidoParticipNoControlFinAnteriorField
        End Get
        Set
            Me.desgloseAtribuidoParticipNoControlFinAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoParticipNoControlFinAnteriorDesgloseAtribuidoParticipNoControlFinAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoControladoraFinAnterior

    Private desgloseAtribuidoControladoraFinAnteriorField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoControladoraFinAnteriorDesgloseAtribuidoControladoraFinAnterior

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAtribuidoControladoraFinAnterior() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoControladoraFinAnteriorDesgloseAtribuidoControladoraFinAnterior
        Get
            Return Me.desgloseAtribuidoControladoraFinAnteriorField
        End Get
        Set
            Me.desgloseAtribuidoControladoraFinAnteriorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo31DicAnnoAnteriorAtribuidoControladoraFinAnteriorDesgloseAtribuidoControladoraFinAnterior

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActual

    Private desgloseSaldo1EneAnnoActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualDesgloseSaldo1EneAnnoActual

    Private cambiosPoliticasContablesEneActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCambiosPoliticasContablesEneActual

    Private correccionErroresFundamentalesEneActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCorreccionErroresFundamentalesEneActual

    Private totalSaldo1EneAnnoActualField As Decimal

    '''<remarks/>
    Public Property DesgloseSaldo1EneAnnoActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualDesgloseSaldo1EneAnnoActual
        Get
            Return Me.desgloseSaldo1EneAnnoActualField
        End Get
        Set
            Me.desgloseSaldo1EneAnnoActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CambiosPoliticasContablesEneActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCambiosPoliticasContablesEneActual
        Get
            Return Me.cambiosPoliticasContablesEneActualField
        End Get
        Set
            Me.cambiosPoliticasContablesEneActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CorreccionErroresFundamentalesEneActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCorreccionErroresFundamentalesEneActual
        Get
            Return Me.correccionErroresFundamentalesEneActualField
        End Get
        Set
            Me.correccionErroresFundamentalesEneActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSaldo1EneAnnoActual() As Decimal
        Get
            Return Me.totalSaldo1EneAnnoActualField
        End Get
        Set
            Me.totalSaldo1EneAnnoActualField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualDesgloseSaldo1EneAnnoActual

    Private capSocialEneActualField As Decimal

    Private aportesNoCapitalizadosEneActualField As Decimal

    Private ajustesEneActualField As Decimal

    Private reservasEneActualField As Decimal

    Private resultadosPrincipioPeriodoEneActualField As Decimal

    '''<remarks/>
    Public Property CapSocialEneActual() As Decimal
        Get
            Return Me.capSocialEneActualField
        End Get
        Set
            Me.capSocialEneActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizadosEneActual() As Decimal
        Get
            Return Me.aportesNoCapitalizadosEneActualField
        End Get
        Set
            Me.aportesNoCapitalizadosEneActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AjustesEneActual() As Decimal
        Get
            Return Me.ajustesEneActualField
        End Get
        Set
            Me.ajustesEneActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReservasEneActual() As Decimal
        Get
            Return Me.reservasEneActualField
        End Get
        Set
            Me.reservasEneActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodoEneActual() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoEneActualField
        End Get
        Set
            Me.resultadosPrincipioPeriodoEneActualField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCambiosPoliticasContablesEneActual

    Private desgloseCambiosPoliticasContablesEneActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCambiosPoliticasContablesEneActualDesgloseCambiosPoliticasContablesEneActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseCambiosPoliticasContablesEneActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCambiosPoliticasContablesEneActualDesgloseCambiosPoliticasContablesEneActual
        Get
            Return Me.desgloseCambiosPoliticasContablesEneActualField
        End Get
        Set
            Me.desgloseCambiosPoliticasContablesEneActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCambiosPoliticasContablesEneActualDesgloseCambiosPoliticasContablesEneActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCorreccionErroresFundamentalesEneActual

    Private desgloseCorreccionErroresFundamentalesEneActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCorreccionErroresFundamentalesEneActualDesgloseCorreccionErroresFundamentalesEneActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseCorreccionErroresFundamentalesEneActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCorreccionErroresFundamentalesEneActualDesgloseCorreccionErroresFundamentalesEneActual
        Get
            Return Me.desgloseCorreccionErroresFundamentalesEneActualField
        End Get
        Set
            Me.desgloseCorreccionErroresFundamentalesEneActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldo1EneAnnoActualCorreccionErroresFundamentalesEneActualDesgloseCorreccionErroresFundamentalesEneActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoActual

    Private desgloseSaldoCorregidoInicioAnnoActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoActualDesgloseSaldoCorregidoInicioAnnoActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseSaldoCorregidoInicioAnnoActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoActualDesgloseSaldoCorregidoInicioAnnoActual
        Get
            Return Me.desgloseSaldoCorregidoInicioAnnoActualField
        End Get
        Set
            Me.desgloseSaldoCorregidoInicioAnnoActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoCorregidoInicioAnnoActualDesgloseSaldoCorregidoInicioAnnoActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActual

    Private desgloseOriginadosAnnoActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualDesgloseOriginadosAnnoActual

    Private ajustesConversionEstadosFinancierosOrigActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesConversionEstadosFinancierosOrigActual

    Private ajustesValuacionInversionesValRazCambiosResulIntegOrigActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegOrigActual

    Private ajustesValuacionInstrumentosRestringidosOrigActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosRestringidosOrigActual

    Private ajustesValuacionInstrumentosCesacionPagoOrigActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosCesacionPagoOrigActual

    Private otrosOriginadosAnnoActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualOtrosOriginadosAnnoActual

    Private totalOriginadosAnnoActualField As Decimal

    '''<remarks/>
    Public Property DesgloseOriginadosAnnoActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualDesgloseOriginadosAnnoActual
        Get
            Return Me.desgloseOriginadosAnnoActualField
        End Get
        Set
            Me.desgloseOriginadosAnnoActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AjustesConversionEstadosFinancierosOrigActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesConversionEstadosFinancierosOrigActual
        Get
            Return Me.ajustesConversionEstadosFinancierosOrigActualField
        End Get
        Set
            Me.ajustesConversionEstadosFinancierosOrigActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AjustesValuacionInversionesValRazCambiosResulIntegOrigActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegOrigActual
        Get
            Return Me.ajustesValuacionInversionesValRazCambiosResulIntegOrigActualField
        End Get
        Set
            Me.ajustesValuacionInversionesValRazCambiosResulIntegOrigActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AjustesValuacionInstrumentosRestringidosOrigActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosRestringidosOrigActual
        Get
            Return Me.ajustesValuacionInstrumentosRestringidosOrigActualField
        End Get
        Set
            Me.ajustesValuacionInstrumentosRestringidosOrigActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AjustesValuacionInstrumentosCesacionPagoOrigActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosCesacionPagoOrigActual
        Get
            Return Me.ajustesValuacionInstrumentosCesacionPagoOrigActualField
        End Get
        Set
            Me.ajustesValuacionInstrumentosCesacionPagoOrigActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosOriginadosAnnoActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualOtrosOriginadosAnnoActual
        Get
            Return Me.otrosOriginadosAnnoActualField
        End Get
        Set
            Me.otrosOriginadosAnnoActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOriginadosAnnoActual() As Decimal
        Get
            Return Me.totalOriginadosAnnoActualField
        End Get
        Set
            Me.totalOriginadosAnnoActualField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualDesgloseOriginadosAnnoActual

    Private capSocialOrigActualField As Decimal

    Private aportesNoCapitalizadosOrigActualField As Decimal

    Private ajustesOrigActualField As Decimal

    Private reservasOrigActualField As Decimal

    Private resultadosPrincipioPeriodoOrigActualField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property CapSocialOrigActual() As Decimal
        Get
            Return Me.capSocialOrigActualField
        End Get
        Set
            Me.capSocialOrigActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property AportesNoCapitalizadosOrigActual() As Decimal
        Get
            Return Me.aportesNoCapitalizadosOrigActualField
        End Get
        Set
            Me.aportesNoCapitalizadosOrigActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property AjustesOrigActual() As Decimal
        Get
            Return Me.ajustesOrigActualField
        End Get
        Set
            Me.ajustesOrigActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ReservasOrigActual() As Decimal
        Get
            Return Me.reservasOrigActualField
        End Get
        Set
            Me.reservasOrigActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ResultadosPrincipioPeriodoOrigActual() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoOrigActualField
        End Get
        Set
            Me.resultadosPrincipioPeriodoOrigActualField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesConversionEstadosFinancierosOrigActual

    Private desgloseAjustesConversionEstadosFinancierosOrigActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesConversionEstadosFinancierosOrigActualDesgloseAjustesConversionEstadosFinancierosOrigActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAjustesConversionEstadosFinancierosOrigActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesConversionEstadosFinancierosOrigActualDesgloseAjustesConversionEstadosFinancierosOrigActual
        Get
            Return Me.desgloseAjustesConversionEstadosFinancierosOrigActualField
        End Get
        Set
            Me.desgloseAjustesConversionEstadosFinancierosOrigActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesConversionEstadosFinancierosOrigActualDesgloseAjustesConversionEstadosFinancierosOrigActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegOrigActual

    Private desgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegOrigActualDesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegOrigActualDesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual
        Get
            Return Me.desgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActualField
        End Get
        Set
            Me.desgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegOrigActualDesgloseAjustesValuacionInversionesValRazCambiosResulIntegOrigActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosRestringidosOrigActual

    Private desgloseAjustesValuacionInstrumentosRestringidosOrigActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosRestringidosOrigActualDesgloseAjustesValuacionInstrumentosRestringidosOrigActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAjustesValuacionInstrumentosRestringidosOrigActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosRestringidosOrigActualDesgloseAjustesValuacionInstrumentosRestringidosOrigActual
        Get
            Return Me.desgloseAjustesValuacionInstrumentosRestringidosOrigActualField
        End Get
        Set
            Me.desgloseAjustesValuacionInstrumentosRestringidosOrigActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosRestringidosOrigActualDesgloseAjustesValuacionInstrumentosRestringidosOrigActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosCesacionPagoOrigActual

    Private desgloseAjustesValuacionInstrumentosCesacionPagoOrigActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosCesacionPagoOrigActualDesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosCesacionPagoOrigActualDesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual
        Get
            Return Me.desgloseAjustesValuacionInstrumentosCesacionPagoOrigActualField
        End Get
        Set
            Me.desgloseAjustesValuacionInstrumentosCesacionPagoOrigActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualAjustesValuacionInstrumentosCesacionPagoOrigActualDesgloseAjustesValuacionInstrumentosCesacionPagoOrigActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualOtrosOriginadosAnnoActual

    Private desgloseOtrosOrigActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualOtrosOriginadosAnnoActualDesgloseOtrosOrigActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseOtrosOrigActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualOtrosOriginadosAnnoActualDesgloseOtrosOrigActual
        Get
            Return Me.desgloseOtrosOrigActualField
        End Get
        Set
            Me.desgloseOtrosOrigActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloOriginadosAnnoActualOtrosOriginadosAnnoActualDesgloseOtrosOrigActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActual

    Private desgloseTranferenciasResultadosAnnoActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualDesgloseTranferenciasResultadosAnnoActual

    Private ajustesValuacionInversionesValRazCambiosResulIntegTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegTransfActual

    Private ajustesValuacionInstrumentosRestringidosTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosRestringidosTransfActual

    Private ajustesValuacionInstrumentosCesacionPagoTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosCesacionPagoTransfActual

    Private otrosTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualOtrosTransfActual

    Private gananciaPerdidaNoReconocidaPeriodo2Field As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualGananciaPerdidaNoReconocidaPeriodo2

    Private resultadoPeriodo2Field As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualResultadoPeriodo2

    Private reservasLegalesOtrasEstatutariasTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualReservasLegalesOtrasEstatutariasTransfActual

    Private dividendosPeriodo1Field As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualDividendosPeriodo1

    Private estimacionesRiesgosActBancariaTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEstimacionesRiesgosActBancariaTransfActual

    Private compraVentaAccionesTesoreriaTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCompraVentaAccionesTesoreriaTransfActual

    Private emisionAccionesTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEmisionAccionesTransfActual

    Private capitalPagadoAdicionalTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCapitalPagadoAdicionalTransfActual

    Private superavitRevaPropiedadMobiliarioEquipoTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoTransfActual

    Private transferenciaSuperavitField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualTransferenciaSuperavit

    Private superavitRevaPropiedadMobiliarioEquipoNetoField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoNeto

    Private totalTranferenciasResultadosAnnoActualField As Decimal

    '''<remarks/>
    Public Property DesgloseTranferenciasResultadosAnnoActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualDesgloseTranferenciasResultadosAnnoActual
        Get
            Return Me.desgloseTranferenciasResultadosAnnoActualField
        End Get
        Set
            Me.desgloseTranferenciasResultadosAnnoActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AjustesValuacionInversionesValRazCambiosResulIntegTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegTransfActual
        Get
            Return Me.ajustesValuacionInversionesValRazCambiosResulIntegTransfActualField
        End Get
        Set
            Me.ajustesValuacionInversionesValRazCambiosResulIntegTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AjustesValuacionInstrumentosRestringidosTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosRestringidosTransfActual
        Get
            Return Me.ajustesValuacionInstrumentosRestringidosTransfActualField
        End Get
        Set
            Me.ajustesValuacionInstrumentosRestringidosTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AjustesValuacionInstrumentosCesacionPagoTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosCesacionPagoTransfActual
        Get
            Return Me.ajustesValuacionInstrumentosCesacionPagoTransfActualField
        End Get
        Set
            Me.ajustesValuacionInstrumentosCesacionPagoTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualOtrosTransfActual
        Get
            Return Me.otrosTransfActualField
        End Get
        Set
            Me.otrosTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GananciaPerdidaNoReconocidaPeriodo2() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualGananciaPerdidaNoReconocidaPeriodo2
        Get
            Return Me.gananciaPerdidaNoReconocidaPeriodo2Field
        End Get
        Set
            Me.gananciaPerdidaNoReconocidaPeriodo2Field = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadoPeriodo2() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualResultadoPeriodo2
        Get
            Return Me.resultadoPeriodo2Field
        End Get
        Set
            Me.resultadoPeriodo2Field = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReservasLegalesOtrasEstatutariasTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualReservasLegalesOtrasEstatutariasTransfActual
        Get
            Return Me.reservasLegalesOtrasEstatutariasTransfActualField
        End Get
        Set
            Me.reservasLegalesOtrasEstatutariasTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DividendosPeriodo1() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualDividendosPeriodo1
        Get
            Return Me.dividendosPeriodo1Field
        End Get
        Set
            Me.dividendosPeriodo1Field = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EstimacionesRiesgosActBancariaTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEstimacionesRiesgosActBancariaTransfActual
        Get
            Return Me.estimacionesRiesgosActBancariaTransfActualField
        End Get
        Set
            Me.estimacionesRiesgosActBancariaTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CompraVentaAccionesTesoreriaTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCompraVentaAccionesTesoreriaTransfActual
        Get
            Return Me.compraVentaAccionesTesoreriaTransfActualField
        End Get
        Set
            Me.compraVentaAccionesTesoreriaTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EmisionAccionesTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEmisionAccionesTransfActual
        Get
            Return Me.emisionAccionesTransfActualField
        End Get
        Set
            Me.emisionAccionesTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CapitalPagadoAdicionalTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCapitalPagadoAdicionalTransfActual
        Get
            Return Me.capitalPagadoAdicionalTransfActualField
        End Get
        Set
            Me.capitalPagadoAdicionalTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SuperavitRevaPropiedadMobiliarioEquipoTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoTransfActual
        Get
            Return Me.superavitRevaPropiedadMobiliarioEquipoTransfActualField
        End Get
        Set
            Me.superavitRevaPropiedadMobiliarioEquipoTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property TransferenciaSuperavit() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualTransferenciaSuperavit
        Get
            Return Me.transferenciaSuperavitField
        End Get
        Set
            Me.transferenciaSuperavitField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SuperavitRevaPropiedadMobiliarioEquipoNeto() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoNeto
        Get
            Return Me.superavitRevaPropiedadMobiliarioEquipoNetoField
        End Get
        Set
            Me.superavitRevaPropiedadMobiliarioEquipoNetoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalTranferenciasResultadosAnnoActual() As Decimal
        Get
            Return Me.totalTranferenciasResultadosAnnoActualField
        End Get
        Set
            Me.totalTranferenciasResultadosAnnoActualField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualDesgloseTranferenciasResultadosAnnoActual

    Private capSocialTransfActualField As Decimal

    Private aportesNoCapitalizadosTransfActualField As Decimal

    Private ajustesTransfActualField As Decimal

    Private reservasTransfActualField As Decimal

    Private resultadosPrincipioPeriodoTransfActualField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property CapSocialTransfActual() As Decimal
        Get
            Return Me.capSocialTransfActualField
        End Get
        Set
            Me.capSocialTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property AportesNoCapitalizadosTransfActual() As Decimal
        Get
            Return Me.aportesNoCapitalizadosTransfActualField
        End Get
        Set
            Me.aportesNoCapitalizadosTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property AjustesTransfActual() As Decimal
        Get
            Return Me.ajustesTransfActualField
        End Get
        Set
            Me.ajustesTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ReservasTransfActual() As Decimal
        Get
            Return Me.reservasTransfActualField
        End Get
        Set
            Me.reservasTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ResultadosPrincipioPeriodoTransfActual() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoTransfActualField
        End Get
        Set
            Me.resultadosPrincipioPeriodoTransfActualField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegTransfActual

    Private desgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegTransfActualDesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegTransfActualDesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual
        Get
            Return Me.desgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActualField
        End Get
        Set
            Me.desgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInversionesValRazCambiosResulIntegTransfActualDesgloseAjustesValuacionInversionesValRazCambiosResulIntegTransfActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosRestringidosTransfActual

    Private desgloseAjustesValuacionInstrumentosRestringidosTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosRestringidosTransfActualDesgloseAjustesValuacionInstrumentosRestringidosTransfActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAjustesValuacionInstrumentosRestringidosTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosRestringidosTransfActualDesgloseAjustesValuacionInstrumentosRestringidosTransfActual
        Get
            Return Me.desgloseAjustesValuacionInstrumentosRestringidosTransfActualField
        End Get
        Set
            Me.desgloseAjustesValuacionInstrumentosRestringidosTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosRestringidosTransfActualDesgloseAjustesValuacionInstrumentosRestringidosTransfActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosCesacionPagoTransfActual

    Private desgloseAjustesValuacionInstrumentosCesacionPagoTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosCesacionPagoTransfActualDesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosCesacionPagoTransfActualDesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual
        Get
            Return Me.desgloseAjustesValuacionInstrumentosCesacionPagoTransfActualField
        End Get
        Set
            Me.desgloseAjustesValuacionInstrumentosCesacionPagoTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualAjustesValuacionInstrumentosCesacionPagoTransfActualDesgloseAjustesValuacionInstrumentosCesacionPagoTransfActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualOtrosTransfActual

    Private desgloseOtrosTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualOtrosTransfActualDesgloseOtrosTransfActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseOtrosTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualOtrosTransfActualDesgloseOtrosTransfActual
        Get
            Return Me.desgloseOtrosTransfActualField
        End Get
        Set
            Me.desgloseOtrosTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualOtrosTransfActualDesgloseOtrosTransfActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualGananciaPerdidaNoReconocidaPeriodo2

    Private desgloseGananciaPerdidaNoReconocidaPeriodo2Field As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualGananciaPerdidaNoReconocidaPeriodo2DesgloseGananciaPerdidaNoReconocidaPeriodo2

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseGananciaPerdidaNoReconocidaPeriodo2() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualGananciaPerdidaNoReconocidaPeriodo2DesgloseGananciaPerdidaNoReconocidaPeriodo2
        Get
            Return Me.desgloseGananciaPerdidaNoReconocidaPeriodo2Field
        End Get
        Set
            Me.desgloseGananciaPerdidaNoReconocidaPeriodo2Field = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualGananciaPerdidaNoReconocidaPeriodo2DesgloseGananciaPerdidaNoReconocidaPeriodo2

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualResultadoPeriodo2

    Private desgloseResultadoPeriodo2Field As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualResultadoPeriodo2DesgloseResultadoPeriodo2

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseResultadoPeriodo2() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualResultadoPeriodo2DesgloseResultadoPeriodo2
        Get
            Return Me.desgloseResultadoPeriodo2Field
        End Get
        Set
            Me.desgloseResultadoPeriodo2Field = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualResultadoPeriodo2DesgloseResultadoPeriodo2

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualReservasLegalesOtrasEstatutariasTransfActual

    Private desgloseReservasLegalesOtrasEstatutariasTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualReservasLegalesOtrasEstatutariasTransfActualDesgloseReservasLegalesOtrasEstatutariasTransfActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseReservasLegalesOtrasEstatutariasTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualReservasLegalesOtrasEstatutariasTransfActualDesgloseReservasLegalesOtrasEstatutariasTransfActual
        Get
            Return Me.desgloseReservasLegalesOtrasEstatutariasTransfActualField
        End Get
        Set
            Me.desgloseReservasLegalesOtrasEstatutariasTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualReservasLegalesOtrasEstatutariasTransfActualDesgloseReservasLegalesOtrasEstatutariasTransfActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualDividendosPeriodo1

    Private desgloseDividendosPeriodo1Field As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualDividendosPeriodo1DesgloseDividendosPeriodo1

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseDividendosPeriodo1() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualDividendosPeriodo1DesgloseDividendosPeriodo1
        Get
            Return Me.desgloseDividendosPeriodo1Field
        End Get
        Set
            Me.desgloseDividendosPeriodo1Field = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualDividendosPeriodo1DesgloseDividendosPeriodo1

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEstimacionesRiesgosActBancariaTransfActual

    Private desgloseEstimacionesRiesgosActBancariaTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEstimacionesRiesgosActBancariaTransfActualDesgloseEstimacionesRiesgosActBancariaTransfActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseEstimacionesRiesgosActBancariaTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEstimacionesRiesgosActBancariaTransfActualDesgloseEstimacionesRiesgosActBancariaTransfActual
        Get
            Return Me.desgloseEstimacionesRiesgosActBancariaTransfActualField
        End Get
        Set
            Me.desgloseEstimacionesRiesgosActBancariaTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEstimacionesRiesgosActBancariaTransfActualDesgloseEstimacionesRiesgosActBancariaTransfActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCompraVentaAccionesTesoreriaTransfActual

    Private desgloseCompraVentaAccionesTesoreriaTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCompraVentaAccionesTesoreriaTransfActualDesgloseCompraVentaAccionesTesoreriaTransfActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseCompraVentaAccionesTesoreriaTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCompraVentaAccionesTesoreriaTransfActualDesgloseCompraVentaAccionesTesoreriaTransfActual
        Get
            Return Me.desgloseCompraVentaAccionesTesoreriaTransfActualField
        End Get
        Set
            Me.desgloseCompraVentaAccionesTesoreriaTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCompraVentaAccionesTesoreriaTransfActualDesgloseCompraVentaAccionesTesoreriaTransfActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEmisionAccionesTransfActual

    Private desgloseEmisionAccionesTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEmisionAccionesTransfActualDesgloseEmisionAccionesTransfActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseEmisionAccionesTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEmisionAccionesTransfActualDesgloseEmisionAccionesTransfActual
        Get
            Return Me.desgloseEmisionAccionesTransfActualField
        End Get
        Set
            Me.desgloseEmisionAccionesTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualEmisionAccionesTransfActualDesgloseEmisionAccionesTransfActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCapitalPagadoAdicionalTransfActual

    Private desgloseCapitalPagadoAdicionalTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCapitalPagadoAdicionalTransfActualDesgloseCapitalPagadoAdicionalTransfActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseCapitalPagadoAdicionalTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCapitalPagadoAdicionalTransfActualDesgloseCapitalPagadoAdicionalTransfActual
        Get
            Return Me.desgloseCapitalPagadoAdicionalTransfActualField
        End Get
        Set
            Me.desgloseCapitalPagadoAdicionalTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualCapitalPagadoAdicionalTransfActualDesgloseCapitalPagadoAdicionalTransfActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoTransfActual

    Private desgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoTransfActualDesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoTransfActualDesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual
        Get
            Return Me.desgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActualField
        End Get
        Set
            Me.desgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoTransfActualDesgloseSuperavitRevaPropiedadMobiliarioEquipoTransfActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualTransferenciaSuperavit

    Private desgloseTransferenciaSuperavitField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualTransferenciaSuperavitDesgloseTransferenciaSuperavit

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseTransferenciaSuperavit() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualTransferenciaSuperavitDesgloseTransferenciaSuperavit
        Get
            Return Me.desgloseTransferenciaSuperavitField
        End Get
        Set
            Me.desgloseTransferenciaSuperavitField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualTransferenciaSuperavitDesgloseTransferenciaSuperavit

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoNeto

    Private desgloseSuperavitRevaPropiedadMobiliarioEquipoNetoField As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoNetoDesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto() As ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoNetoDesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto
        Get
            Return Me.desgloseSuperavitRevaPropiedadMobiliarioEquipoNetoField
        End Get
        Set
            Me.desgloseSuperavitRevaPropiedadMobiliarioEquipoNetoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloTranferenciasResultadosAnnoActualSuperavitRevaPropiedadMobiliarioEquipoNetoDesgloseSuperavitRevaPropiedadMobiliarioEquipoNeto

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActual

    Private desgloseSaldoFinalAnnoActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualDesgloseSaldoFinalAnnoActual

    Private atribuidoParticipNoControlFinActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoParticipNoControlFinActual

    Private atribuidoControladoraFinActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoControladoraFinActual

    Private totalSaldoFinalAnnoActualField As Decimal

    '''<remarks/>
    Public Property DesgloseSaldoFinalAnnoActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualDesgloseSaldoFinalAnnoActual
        Get
            Return Me.desgloseSaldoFinalAnnoActualField
        End Get
        Set
            Me.desgloseSaldoFinalAnnoActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AtribuidoParticipNoControlFinActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoParticipNoControlFinActual
        Get
            Return Me.atribuidoParticipNoControlFinActualField
        End Get
        Set
            Me.atribuidoParticipNoControlFinActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AtribuidoControladoraFinActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoControladoraFinActual
        Get
            Return Me.atribuidoControladoraFinActualField
        End Get
        Set
            Me.atribuidoControladoraFinActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSaldoFinalAnnoActual() As Decimal
        Get
            Return Me.totalSaldoFinalAnnoActualField
        End Get
        Set
            Me.totalSaldoFinalAnnoActualField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualDesgloseSaldoFinalAnnoActual

    Private capSocialFinActualField As Decimal

    Private aportesNoCapitalizadosFinActualField As Decimal

    Private ajustesFinActualField As Decimal

    Private reservasFinActualField As Decimal

    Private resultadosPrincipioPeriodoFinActualField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property CapSocialFinActual() As Decimal
        Get
            Return Me.capSocialFinActualField
        End Get
        Set
            Me.capSocialFinActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property AportesNoCapitalizadosFinActual() As Decimal
        Get
            Return Me.aportesNoCapitalizadosFinActualField
        End Get
        Set
            Me.aportesNoCapitalizadosFinActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property AjustesFinActual() As Decimal
        Get
            Return Me.ajustesFinActualField
        End Get
        Set
            Me.ajustesFinActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ReservasFinActual() As Decimal
        Get
            Return Me.reservasFinActualField
        End Get
        Set
            Me.reservasFinActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property ResultadosPrincipioPeriodoFinActual() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoFinActualField
        End Get
        Set
            Me.resultadosPrincipioPeriodoFinActualField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoParticipNoControlFinActual

    Private desgloseAtribuidoParticipNoControlFinActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoParticipNoControlFinActualDesgloseAtribuidoParticipNoControlFinActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAtribuidoParticipNoControlFinActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoParticipNoControlFinActualDesgloseAtribuidoParticipNoControlFinActual
        Get
            Return Me.desgloseAtribuidoParticipNoControlFinActualField
        End Get
        Set
            Me.desgloseAtribuidoParticipNoControlFinActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoParticipNoControlFinActualDesgloseAtribuidoParticipNoControlFinActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoControladoraFinActual

    Private desgloseAtribuidoControladoraFinActualField As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoControladoraFinActualDesgloseAtribuidoControladoraFinActual

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseAtribuidoControladoraFinActual() As ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoControladoraFinActualDesgloseAtribuidoControladoraFinActual
        Get
            Return Me.desgloseAtribuidoControladoraFinActualField
        End Get
        Set
            Me.desgloseAtribuidoControladoraFinActualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As Decimal
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoCambiosPatrimonioPropioDatosModeloSaldoFinalAnnoActualAtribuidoControladoraFinActualDesgloseAtribuidoControladoraFinActual

    Private capSocialField As Decimal

    Private aportesNoCapitalizadosField As Decimal

    Private ajustesField As Decimal

    Private reservasField As Decimal

    Private resultadosPrincipioPeriodoField As Decimal

    '''<remarks/>
    Public Property CapSocial() As Decimal
        Get
            Return Me.capSocialField
        End Get
        Set
            Me.capSocialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesNoCapitalizados() As Decimal
        Get
            Return Me.aportesNoCapitalizadosField
        End Get
        Set
            Me.aportesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Ajustes() As Decimal
        Get
            Return Me.ajustesField
        End Get
        Set
            Me.ajustesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As Decimal
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPrincipioPeriodo() As Decimal
        Get
            Return Me.resultadosPrincipioPeriodoField
        End Get
        Set
            Me.resultadosPrincipioPeriodoField = Value
        End Set
    End Property
End Class