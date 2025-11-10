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



'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:cap:ties:invsugesetypes:v1")>
Public Enum CodTitulo

    '''<remarks/>
    DI

    '''<remarks/>
    DE

    '''<remarks/>
    FI

    '''<remarks/>
    FA

    '''<remarks/>
    AC

    '''<remarks/>
    NE

    '''<remarks/>
    IC

    '''<remarks/>
    RE
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:cap:ties:invsugesetypes:v1")>
Public Enum PeriodicidadCupon

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("0")>
    Item0

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")>
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")>
    Item2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("3")>
    Item3

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("4")>
    Item4

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("6")>
    Item6

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("12")>
    Item12
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:cap:ties:isosugesetypes:v1")>
Public Enum PaisResidencia

    '''<remarks/>
    [AND]

    '''<remarks/>
    ARE

    '''<remarks/>
    AFG

    '''<remarks/>
    ATG

    '''<remarks/>
    AIA

    '''<remarks/>
    ALB

    '''<remarks/>
    ARM

    '''<remarks/>
    ANT

    '''<remarks/>
    AGO

    '''<remarks/>
    ATA

    '''<remarks/>
    ARG

    '''<remarks/>
    ASM

    '''<remarks/>
    AUT

    '''<remarks/>
    AUS

    '''<remarks/>
    ABW

    '''<remarks/>
    ALA

    '''<remarks/>
    AZE

    '''<remarks/>
    BIH

    '''<remarks/>
    BRB

    '''<remarks/>
    BGD

    '''<remarks/>
    BEL

    '''<remarks/>
    BFA

    '''<remarks/>
    BGR

    '''<remarks/>
    BHR

    '''<remarks/>
    BDI

    '''<remarks/>
    BEN

    '''<remarks/>
    BLM

    '''<remarks/>
    BMU

    '''<remarks/>
    BRN

    '''<remarks/>
    BOL

    '''<remarks/>
    BRA

    '''<remarks/>
    BHS

    '''<remarks/>
    BTN

    '''<remarks/>
    BVT

    '''<remarks/>
    BWA

    '''<remarks/>
    BLR

    '''<remarks/>
    BLZ

    '''<remarks/>
    CAN

    '''<remarks/>
    CCK

    '''<remarks/>
    CAF

    '''<remarks/>
    COG

    '''<remarks/>
    CHE

    '''<remarks/>
    CIV

    '''<remarks/>
    COK

    '''<remarks/>
    CHL

    '''<remarks/>
    CMR

    '''<remarks/>
    CHN

    '''<remarks/>
    COL

    '''<remarks/>
    CRI

    '''<remarks/>
    CUB

    '''<remarks/>
    CPV

    '''<remarks/>
    CXR

    '''<remarks/>
    CYP

    '''<remarks/>
    CZE

    '''<remarks/>
    DEU

    '''<remarks/>
    DJI

    '''<remarks/>
    DNK

    '''<remarks/>
    DMA

    '''<remarks/>
    DOM

    '''<remarks/>
    DZA

    '''<remarks/>
    ECU

    '''<remarks/>
    EST

    '''<remarks/>
    EGY

    '''<remarks/>
    ESH

    '''<remarks/>
    ERI

    '''<remarks/>
    ESP

    '''<remarks/>
    ETH

    '''<remarks/>
    FIN

    '''<remarks/>
    FJI

    '''<remarks/>
    KLK

    '''<remarks/>
    FSM

    '''<remarks/>
    FRO

    '''<remarks/>
    FRA

    '''<remarks/>
    GAB

    '''<remarks/>
    GBR

    '''<remarks/>
    GRD

    '''<remarks/>
    GEO

    '''<remarks/>
    GUF

    '''<remarks/>
    GGY

    '''<remarks/>
    GHA

    '''<remarks/>
    GIB

    '''<remarks/>
    GRL

    '''<remarks/>
    GMB

    '''<remarks/>
    GIN

    '''<remarks/>
    GLP

    '''<remarks/>
    GNQ

    '''<remarks/>
    GRC

    '''<remarks/>
    SGS

    '''<remarks/>
    GTM

    '''<remarks/>
    GUM

    '''<remarks/>
    GNB

    '''<remarks/>
    GUY

    '''<remarks/>
    HKG

    '''<remarks/>
    HMD

    '''<remarks/>
    HND

    '''<remarks/>
    HRV

    '''<remarks/>
    HTI

    '''<remarks/>
    HUN

    '''<remarks/>
    IDN

    '''<remarks/>
    IRL

    '''<remarks/>
    ISR

    '''<remarks/>
    IMN

    '''<remarks/>
    IND

    '''<remarks/>
    IOT

    '''<remarks/>
    IRQ

    '''<remarks/>
    IRN

    '''<remarks/>
    ISL

    '''<remarks/>
    ITA

    '''<remarks/>
    JEY

    '''<remarks/>
    JAM

    '''<remarks/>
    JOR

    '''<remarks/>
    JPN

    '''<remarks/>
    KEN

    '''<remarks/>
    KGZ

    '''<remarks/>
    KHM

    '''<remarks/>
    KIR

    '''<remarks/>
    COM

    '''<remarks/>
    KNA

    '''<remarks/>
    PRK

    '''<remarks/>
    KOR

    '''<remarks/>
    KWT

    '''<remarks/>
    CYM

    '''<remarks/>
    KAZ

    '''<remarks/>
    LAO

    '''<remarks/>
    LBN

    '''<remarks/>
    LCA

    '''<remarks/>
    LIE

    '''<remarks/>
    LKA

    '''<remarks/>
    LBR

    '''<remarks/>
    LSO

    '''<remarks/>
    LTU

    '''<remarks/>
    LUX

    '''<remarks/>
    LVA

    '''<remarks/>
    LBY

    '''<remarks/>
    MAR

    '''<remarks/>
    MCO

    '''<remarks/>
    MDA

    '''<remarks/>
    MNE

    '''<remarks/>
    MDG

    '''<remarks/>
    MHL

    '''<remarks/>
    MKD

    '''<remarks/>
    MLI

    '''<remarks/>
    MMR

    '''<remarks/>
    MNG

    '''<remarks/>
    MAC

    '''<remarks/>
    MTQ

    '''<remarks/>
    MRT

    '''<remarks/>
    MSR

    '''<remarks/>
    MLT

    '''<remarks/>
    MUS

    '''<remarks/>
    MDV

    '''<remarks/>
    MWI

    '''<remarks/>
    MEX

    '''<remarks/>
    MYS

    '''<remarks/>
    MOZ

    '''<remarks/>
    NAM

    '''<remarks/>
    NCL

    '''<remarks/>
    NER

    '''<remarks/>
    NFK

    '''<remarks/>
    NGA

    '''<remarks/>
    NIC

    '''<remarks/>
    NLD

    '''<remarks/>
    NOR

    '''<remarks/>
    NPL

    '''<remarks/>
    NRU

    '''<remarks/>
    NIU

    '''<remarks/>
    NZL

    '''<remarks/>
    OMN

    '''<remarks/>
    PAN

    '''<remarks/>
    PER

    '''<remarks/>
    PYF

    '''<remarks/>
    PNG

    '''<remarks/>
    PHL

    '''<remarks/>
    PAK

    '''<remarks/>
    POL

    '''<remarks/>
    SPM

    '''<remarks/>
    PCN

    '''<remarks/>
    PRI

    '''<remarks/>
    PSE

    '''<remarks/>
    PRT

    '''<remarks/>
    PLW

    '''<remarks/>
    PRY

    '''<remarks/>
    QAT

    '''<remarks/>
    REU

    '''<remarks/>
    ROU

    '''<remarks/>
    SRB

    '''<remarks/>
    RUS

    '''<remarks/>
    RWA

    '''<remarks/>
    SAU

    '''<remarks/>
    SLB

    '''<remarks/>
    SYC

    '''<remarks/>
    SDN

    '''<remarks/>
    SWE

    '''<remarks/>
    SGP

    '''<remarks/>
    SHN

    '''<remarks/>
    SVN

    '''<remarks/>
    SJM

    '''<remarks/>
    SVK

    '''<remarks/>
    SLE

    '''<remarks/>
    SMR

    '''<remarks/>
    SEN

    '''<remarks/>
    SOM

    '''<remarks/>
    SUR

    '''<remarks/>
    STP

    '''<remarks/>
    SLV

    '''<remarks/>
    SYR

    '''<remarks/>
    SWZ

    '''<remarks/>
    TCA

    '''<remarks/>
    TCD

    '''<remarks/>
    ATF

    '''<remarks/>
    TGO

    '''<remarks/>
    THA

    '''<remarks/>
    TZA

    '''<remarks/>
    TJK

    '''<remarks/>
    TKL

    '''<remarks/>
    TLS

    '''<remarks/>
    TKM

    '''<remarks/>
    TUN

    '''<remarks/>
    TON

    '''<remarks/>
    TUR

    '''<remarks/>
    TTO

    '''<remarks/>
    TUV

    '''<remarks/>
    TWN

    '''<remarks/>
    UKR

    '''<remarks/>
    UGA

    '''<remarks/>
    USA

    '''<remarks/>
    URY

    '''<remarks/>
    UZB

    '''<remarks/>
    VAT

    '''<remarks/>
    VCT

    '''<remarks/>
    VEN

    '''<remarks/>
    VGB

    '''<remarks/>
    VIR

    '''<remarks/>
    VNM

    '''<remarks/>
    VUT

    '''<remarks/>
    WLF

    '''<remarks/>
    WSM

    '''<remarks/>
    YEM

    '''<remarks/>
    MYT

    '''<remarks/>
    ZAF
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:cap:ties:invsugesetypes:v1")>
Public Enum ProveedorPrecios

    '''<remarks/>
    PIPCA

    '''<remarks/>
    LATIN

    '''<remarks/>
    VALMER

    '''<remarks/>
    BLOOMB

    '''<remarks/>
    OTROS
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:cap:ties:invsugesetypes:v1")>
Public Enum Calificadoras

    '''<remarks/>
    SP

    '''<remarks/>
    MO

    '''<remarks/>
    FI

    '''<remarks/>
    FN

    '''<remarks/>
    FA

    '''<remarks/>
    FF

    '''<remarks/>
    FV

    '''<remarks/>
    FL

    '''<remarks/>
    FM

    '''<remarks/>
    CF

    '''<remarks/>
    CR

    '''<remarks/>
    CA

    '''<remarks/>
    FU

    '''<remarks/>
    PA

    '''<remarks/>
    PP

    '''<remarks/>
    PE

    '''<remarks/>
    OT
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:cap:ties:invsugesetypes:v1")>
Public Enum PlazoCalificacion

    '''<remarks/>
    CP

    '''<remarks/>
    LP
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:cap:ties:invsugesetypes:v1")>
Public Enum Calificaciones

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("1")>
    Item1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2")>
    Item2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2+")>
    Item21

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("2-")>
    Item22

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("3")>
    Item3

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("3+")>
    Item31

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("3-")>
    Item32

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("4")>
    Item4

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("4+")>
    Item41

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("4-")>
    Item42

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("5")>
    Item5

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("5+")>
    Item51

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("5-")>
    Item52

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("6")>
    Item6

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("7")>
    Item7

    '''<remarks/>
    A

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("A+")>
    A1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("A-")>
    A2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("A1")>
    A11

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("A1+")>
    A12

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("A2")>
    A21

    '''<remarks/>
    A3

    '''<remarks/>
    AA

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("AA+")>
    AA1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("AA-")>
    AA2

    '''<remarks/>
    AAA

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("AAA+")>
    AAA1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("AAA-")>
    AAA2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("Aa1")>
    Aa1Sp

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("Aa2")>
    Aa2Sp

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("Aa3")>
    Aa3Sp

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("Aaa")>
    AaaSp

    '''<remarks/>
    B

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("B+")>
    B1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("B-")>
    B2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("B1")>
    B11

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("B2")>
    B21

    '''<remarks/>
    B3

    '''<remarks/>
    BB

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("BB+")>
    BB1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("BB-")>
    BB2

    '''<remarks/>
    BBB

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("BBB+")>
    BBB1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("BBB-")>
    BBB2

    '''<remarks/>
    Ba1

    '''<remarks/>
    Ba2

    '''<remarks/>
    Ba3

    '''<remarks/>
    Baa1

    '''<remarks/>
    Baa2

    '''<remarks/>
    Baa3

    '''<remarks/>
    C

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("C+")>
    C1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("C-")>
    C2

    '''<remarks/>
    CC

    '''<remarks/>
    CCC

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("CCC+")>
    CCC1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("CCC-")>
    CCC2

    '''<remarks/>
    Ca1

    '''<remarks/>
    Ca2

    '''<remarks/>
    Ca3

    '''<remarks/>
    Caa1

    '''<remarks/>
    Caa2

    '''<remarks/>
    Caa3

    '''<remarks/>
    D

    '''<remarks/>
    DD

    '''<remarks/>
    DDD

    '''<remarks/>
    DP

    '''<remarks/>
    E

    '''<remarks/>
    F1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("F1+")>
    F11

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("F1-")>
    F12

    '''<remarks/>
    F2

    '''<remarks/>
    F3

    '''<remarks/>
    FII1

    '''<remarks/>
    FII2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("FII2+")>
    FII21

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("FII2-")>
    FII22

    '''<remarks/>
    FII3

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("FII3+")>
    FII31

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("FII3-")>
    FII32

    '''<remarks/>
    FII4

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("FII4+")>
    FII41

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("FII4-")>
    FII42

    '''<remarks/>
    FII5

    '''<remarks/>
    FII6

    '''<remarks/>
    I

    '''<remarks/>
    II

    '''<remarks/>
    III

    '''<remarks/>
    IV

    '''<remarks/>
    N1

    '''<remarks/>
    N2

    '''<remarks/>
    N3

    '''<remarks/>
    N4

    '''<remarks/>
    N5

    '''<remarks/>
    P1

    '''<remarks/>
    P2

    '''<remarks/>
    P3

    '''<remarks/>
    RD

    '''<remarks/>
    S

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRA+1")>
    SCRA1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRA+2")>
    SCRA2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRA+3")>
    SCRA3

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRA+4")>
    SCRA4

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRA-1")>
    SCRA11

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRA-2")>
    SCRA21

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRA-3")>
    SCRA31

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRA-4")>
    SCRA41

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRA1")>
    SCRA12

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRA2")>
    SCRA22

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRA3")>
    SCRA32

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRA4")>
    SCRA42

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRAA+1")>
    SCRAA1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRAA+2")>
    SCRAA2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRAA+3")>
    SCRAA3

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRAA+4")>
    SCRAA4

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRAA-1")>
    SCRAA11

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRAA-2")>
    SCRAA21

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRAA-3")>
    SCRAA31

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRAA-4")>
    SCRAA41

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRAA1")>
    SCRAA12

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRAA2")>
    SCRAA22

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRAA3")>
    SCRAA32

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRAA4")>
    SCRAA42

    '''<remarks/>
    SCRAAA1

    '''<remarks/>
    SCRAAA2

    '''<remarks/>
    SCRAAA3

    '''<remarks/>
    SCRAAA4

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRB+1")>
    SCRB1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRB+2")>
    SCRB2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRB+3")>
    SCRB3

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRB+4")>
    SCRB4

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRB-1")>
    SCRB11

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRB-2")>
    SCRB21

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRB-3")>
    SCRB31

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRB-4")>
    SCRB41

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRB1")>
    SCRB12

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRB2")>
    SCRB22

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRB3")>
    SCRB32

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRB4")>
    SCRB42

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBB+1")>
    SCRBB1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBB+2")>
    SCRBB2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBB+3")>
    SCRBB3

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBB+4")>
    SCRBB4

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBB-1")>
    SCRBB11

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBB-2")>
    SCRBB21

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBB-3")>
    SCRBB31

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBB-4")>
    SCRBB41

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBB1")>
    SCRBB12

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBB2")>
    SCRBB22

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBB3")>
    SCRBB32

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBB4")>
    SCRBB42

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBBB+1")>
    SCRBBB1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBBB+2")>
    SCRBBB2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBBB+3")>
    SCRBBB3

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBBB+4")>
    SCRBBB4

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBBB-1")>
    SCRBBB11

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBBB-2")>
    SCRBBB21

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBBB-3")>
    SCRBBB31

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBBB-4")>
    SCRBBB41

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBBB1")>
    SCRBBB12

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBBB2")>
    SCRBBB22

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBBB3")>
    SCRBBB32

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRBBB4")>
    SCRBBB42

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRC+1")>
    SCRC1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRC+2")>
    SCRC2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRC+3")>
    SCRC3

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRC+4")>
    SCRC4

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRC-1")>
    SCRC11

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRC-2")>
    SCRC21

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRC-3")>
    SCRC31

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRC-4")>
    SCRC41

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRC1")>
    SCRC12

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRC2")>
    SCRC22

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRC3")>
    SCRC32

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("SCRC4")>
    SCRC42

    '''<remarks/>
    SCRD

    '''<remarks/>
    V

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("a")>
    aonly

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("a+")>
    aonly1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("a-")>
    aonly2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("aa")>
    aonlyaonly

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("aa+")>
    aonlyaonly1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("aa-")>
    aonlyaonly2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("aaa")>
    aonlyaonlyaonly

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("b")>
    bonly

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("b+")>
    bonly1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("b-")>
    bonly2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("bb")>
    bonlybonly

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("bb+")>
    bonlybonly1

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("bb-")>
    bonlybonly2

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("bbb")>
    bbbonly

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("bbb+")>
    bbb1only

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("bbb-")>
    bbb2only
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:cap:ties:invsugesetypes:v1")>
Public Enum CodCustodio

    '''<remarks/>
    CBAC

    '''<remarks/>
    CBCT

    '''<remarks/>
    CBCR

    '''<remarks/>
    CDAVI

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("CIMP ")>
    CIMP

    '''<remarks/>
    CLAF

    '''<remarks/>
    CBNCR

    '''<remarks/>
    CPOP

    '''<remarks/>
    CSCOT

    '''<remarks/>
    COTROS
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:cap:ties:invsugesetypes:v1")>
Public Enum CodigoTipoValoracion

    '''<remarks/>
    CA

    '''<remarks/>
    RE

    '''<remarks/>
    RI
End Enum