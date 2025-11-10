Imports Architect.Sugese.Domain

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class ModeloInversionesFinancieras

    Private encabezadoField As EncabezadoTipo

    Private datosField As ModeloInversionesFinancierasDatos

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
    Public Property Datos() As ModeloInversionesFinancierasDatos
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
Partial Public Class ModeloInversionesFinancierasDatos

    Private modeloField As ModeloInversionesFinancierasDatosModelo

    '''<remarks/>
    Public Property Modelo() As ModeloInversionesFinancierasDatosModelo
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
Partial Public Class ModeloInversionesFinancierasDatosModelo

    Private detalleInversionField() As ModeloInversionesFinancierasDatosModeloDetalleInversion

    Private entidadFuenteField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("DetalleInversion")>
    Public Property DetalleInversion() As ModeloInversionesFinancierasDatosModeloDetalleInversion()
        Get
            Return Me.detalleInversionField
        End Get
        Set
            Me.detalleInversionField = Value
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
Partial Public Class ModeloInversionesFinancierasDatosModeloDetalleInversion

    Private codReferenciaField As String

    Private codISINField As String

    Private ramoField As System.Nullable(Of TipoRamo)

    Private ramoFieldSpecified As Boolean

    Private codTituloField As CodTitulo

    Private nemoEmisorField As String

    Private nemotInstrumentoField As String

    Private fecAdquisicionField As String

    Private fecVencimientoField As String

    Private periodicidadCuponField As System.Nullable(Of PeriodicidadCupon)

    Private periodicidadCuponFieldSpecified As Boolean

    Private tasaFacialField As String

    Private tasaFacialFieldSpecified As Boolean

    Private paisEmisionField As PaisResidencia

    Private valorFacialField As Decimal

    Private costoAdquisicionField As Decimal

    Private amortizacionAcumuladaField As System.Nullable(Of Decimal)

    Private amortizacionAcumuladaFieldSpecified As Boolean

    Private valorMercadoMonedaEmisionField As System.Nullable(Of Decimal)

    Private valorMercadoMonedaEmisionFieldSpecified As Boolean

    Private valorMercadoColonesField As System.Nullable(Of Decimal)

    Private valorMercadoColonesFieldSpecified As Boolean

    Private resultadoValoracionField As System.Nullable(Of Decimal)

    Private resultadoValoracionFieldSpecified As Boolean

    Private rendimientoField As System.Nullable(Of Decimal)

    Private rendimientoFieldSpecified As Boolean

    Private valorLibrosMonedaOriginalField As System.Nullable(Of Decimal)

    Private valorLibrosMonedaOriginalFieldSpecified As Boolean

    Private valorLibrosColonesField As System.Nullable(Of Decimal)

    Private valorLibrosColonesFieldSpecified As Boolean

    Private deterioroField As System.Nullable(Of Decimal)

    Private deterioroFieldSpecified As Boolean

    Private proveedorPrecioField As System.Nullable(Of ProveedorPrecios)

    Private proveedorPrecioFieldSpecified As Boolean

    Private precioPorcentualField As System.Nullable(Of Decimal)

    Private precioPorcentualFieldSpecified As Boolean

    Private precioNominalField As System.Nullable(Of Decimal)

    Private precioNominalFieldSpecified As Boolean

    Private precioRendimientoField As System.Nullable(Of Decimal)

    Private precioRendimientoFieldSpecified As Boolean

    Private calificadoraField As System.Nullable(Of Calificadoras)

    Private calificadoraFieldSpecified As Boolean

    Private plazoCalificacionField As System.Nullable(Of PlazoCalificacion)

    Private plazoCalificacionFieldSpecified As Boolean

    Private riesgoEmisorField As String

    Private riesgoEmisorFieldSpecified As Boolean

    Private riesgoCreditoEmisionField As String

    Private riesgoCreditoEmisionFieldSpecified As Boolean

    Private codCustodioField As System.Nullable(Of CodCustodio)

    Private codCustodioFieldSpecified As Boolean

    Private numCustodiaField As String

    Private codMonedaField As CodMonedaInt

    Private codTipoValoracionField As CodigoTipoValoracion

    '''<remarks/>
    Public Property CodReferencia() As String
        Get
            Return Me.codReferenciaField
        End Get
        Set
            Me.codReferenciaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property CodISIN() As String
        Get
            Return Me.codISINField
        End Get
        Set
            Me.codISINField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property Ramo() As System.Nullable(Of TipoRamo)
        Get
            Return Me.ramoField
        End Get
        Set
            Me.ramoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property RamoSpecified() As Boolean
        Get
            Return Me.ramoFieldSpecified
        End Get
        Set
            Me.ramoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CodTitulo() As CodTitulo
        Get
            Return Me.codTituloField
        End Get
        Set
            Me.codTituloField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NemoEmisor() As String
        Get
            Return Me.nemoEmisorField
        End Get
        Set
            Me.nemoEmisorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NemotInstrumento() As String
        Get
            Return Me.nemotInstrumentoField
        End Get
        Set
            Me.nemotInstrumentoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property FecAdquisicion() As String
        Get
            Return Me.fecAdquisicionField
        End Get
        Set
            Me.fecAdquisicionField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property FecVencimiento() As String
        Get
            Return Me.fecVencimientoField
        End Get
        Set
            Me.fecVencimientoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property PeriodicidadCupon() As System.Nullable(Of PeriodicidadCupon)
        Get
            Return Me.periodicidadCuponField
        End Get
        Set
            Me.periodicidadCuponField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property PeriodicidadCuponSpecified() As Boolean
        Get
            Return Me.periodicidadCuponFieldSpecified
        End Get
        Set
            Me.periodicidadCuponFieldSpecified = Value
        End Set
    End Property

    'CUSTOM2020A
    '''<remarks/>
    '<System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property TasaFacial() As String
        Get
            Return Me.tasaFacialField
        End Get
        Set
            Me.tasaFacialField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property TasaFacialSpecified() As Boolean
        Get
            Return Me.tasaFacialFieldSpecified
        End Get
        Set
            Me.tasaFacialFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PaisEmision() As PaisResidencia
        Get
            Return Me.paisEmisionField
        End Get
        Set
            Me.paisEmisionField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ValorFacial() As Decimal
        Get
            Return Me.valorFacialField
        End Get
        Set
            Me.valorFacialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CostoAdquisicion() As Decimal
        Get
            Return Me.costoAdquisicionField
        End Get
        Set
            Me.costoAdquisicionField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AmortizacionAcumulada() As System.Nullable(Of Decimal)
        Get
            Return Me.amortizacionAcumuladaField
        End Get
        Set
            Me.amortizacionAcumuladaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property AmortizacionAcumuladaSpecified() As Boolean
        Get
            Return Me.amortizacionAcumuladaFieldSpecified
        End Get
        Set
            Me.amortizacionAcumuladaFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property ValorMercadoMonedaEmision() As System.Nullable(Of Decimal)
        Get
            Return Me.valorMercadoMonedaEmisionField
        End Get
        Set
            Me.valorMercadoMonedaEmisionField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property ValorMercadoMonedaEmisionSpecified() As Boolean
        Get
            Return Me.valorMercadoMonedaEmisionFieldSpecified
        End Get
        Set
            Me.valorMercadoMonedaEmisionFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property ValorMercadoColones() As System.Nullable(Of Decimal)
        Get
            Return Me.valorMercadoColonesField
        End Get
        Set
            Me.valorMercadoColonesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property ValorMercadoColonesSpecified() As Boolean
        Get
            Return Me.valorMercadoColonesFieldSpecified
        End Get
        Set
            Me.valorMercadoColonesFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property ResultadoValoracion() As System.Nullable(Of Decimal)
        Get
            Return Me.resultadoValoracionField
        End Get
        Set
            Me.resultadoValoracionField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property ResultadoValoracionSpecified() As Boolean
        Get
            Return Me.resultadoValoracionFieldSpecified
        End Get
        Set
            Me.resultadoValoracionFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property Rendimiento() As System.Nullable(Of Decimal)
        Get
            Return Me.rendimientoField
        End Get
        Set
            Me.rendimientoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property RendimientoSpecified() As Boolean
        Get
            Return Me.rendimientoFieldSpecified
        End Get
        Set
            Me.rendimientoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property ValorLibrosMonedaOriginal() As System.Nullable(Of Decimal)
        Get
            Return Me.valorLibrosMonedaOriginalField
        End Get
        Set
            Me.valorLibrosMonedaOriginalField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property ValorLibrosMonedaOriginalSpecified() As Boolean
        Get
            Return Me.valorLibrosMonedaOriginalFieldSpecified
        End Get
        Set
            Me.valorLibrosMonedaOriginalFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property ValorLibrosColones() As System.Nullable(Of Decimal)
        Get
            Return Me.valorLibrosColonesField
        End Get
        Set
            Me.valorLibrosColonesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property ValorLibrosColonesSpecified() As Boolean
        Get
            Return Me.valorLibrosColonesFieldSpecified
        End Get
        Set
            Me.valorLibrosColonesFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property Deterioro() As System.Nullable(Of Decimal)
        Get
            Return Me.deterioroField
        End Get
        Set
            Me.deterioroField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property DeterioroSpecified() As Boolean
        Get
            Return Me.deterioroFieldSpecified
        End Get
        Set
            Me.deterioroFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property ProveedorPrecio() As System.Nullable(Of ProveedorPrecios)
        Get
            Return Me.proveedorPrecioField
        End Get
        Set
            Me.proveedorPrecioField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property ProveedorPrecioSpecified() As Boolean
        Get
            Return Me.proveedorPrecioFieldSpecified
        End Get
        Set
            Me.proveedorPrecioFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property PrecioPorcentual() As System.Nullable(Of Decimal)
        Get
            Return Me.precioPorcentualField
        End Get
        Set
            Me.precioPorcentualField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property PrecioPorcentualSpecified() As Boolean
        Get
            Return Me.precioPorcentualFieldSpecified
        End Get
        Set
            Me.precioPorcentualFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property PrecioNominal() As System.Nullable(Of Decimal)
        Get
            Return Me.precioNominalField
        End Get
        Set
            Me.precioNominalField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property PrecioNominalSpecified() As Boolean
        Get
            Return Me.precioNominalFieldSpecified
        End Get
        Set
            Me.precioNominalFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property PrecioRendimiento() As System.Nullable(Of Decimal)
        Get
            Return Me.precioRendimientoField
        End Get
        Set
            Me.precioRendimientoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property PrecioRendimientoSpecified() As Boolean
        Get
            Return Me.precioRendimientoFieldSpecified
        End Get
        Set
            Me.precioRendimientoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property Calificadora() As System.Nullable(Of Calificadoras)
        Get
            Return Me.calificadoraField
        End Get
        Set
            Me.calificadoraField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property CalificadoraSpecified() As Boolean
        Get
            Return Me.calificadoraFieldSpecified
        End Get
        Set
            Me.calificadoraFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property PlazoCalificacion() As System.Nullable(Of PlazoCalificacion)
        Get
            Return Me.plazoCalificacionField
        End Get
        Set
            Me.plazoCalificacionField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property PlazoCalificacionSpecified() As Boolean
        Get
            Return Me.plazoCalificacionFieldSpecified
        End Get
        Set
            Me.plazoCalificacionFieldSpecified = Value
        End Set
    End Property

    'CUSTOM2020A
    '''<remarks/>
    '<System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property RiesgoEmisor() As String
        Get
            Return Me.riesgoEmisorField
        End Get
        Set
            Me.riesgoEmisorField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property RiesgoEmisorSpecified() As Boolean
        Get
            Return Me.riesgoEmisorFieldSpecified
        End Get
        Set
            Me.riesgoEmisorFieldSpecified = Value
        End Set
    End Property

    'CUSTOM2020A
    '''<remarks/>
    '<System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property RiesgoCreditoEmision() As String
        Get
            Return Me.riesgoCreditoEmisionField
        End Get
        Set
            Me.riesgoCreditoEmisionField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property RiesgoCreditoEmisionSpecified() As Boolean
        Get
            Return Me.riesgoCreditoEmisionFieldSpecified
        End Get
        Set
            Me.riesgoCreditoEmisionFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property CodCustodio() As System.Nullable(Of CodCustodio)
        Get
            Return Me.codCustodioField
        End Get
        Set
            Me.codCustodioField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property CodCustodioSpecified() As Boolean
        Get
            Return Me.codCustodioFieldSpecified
        End Get
        Set
            Me.codCustodioFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property NumCustodia() As String
        Get
            Return Me.numCustodiaField
        End Get
        Set
            Me.numCustodiaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property CodMoneda() As CodMonedaInt
        Get
            Return Me.codMonedaField
        End Get
        Set
            Me.codMonedaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property CodTipoValoracion() As CodigoTipoValoracion
        Get
            Return Me.codTipoValoracionField
        End Get
        Set
            Me.codTipoValoracionField = Value
        End Set
    End Property
End Class