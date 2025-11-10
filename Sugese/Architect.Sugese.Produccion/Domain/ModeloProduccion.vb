Imports Architect.Sugese.Domain

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class ModeloProduccion

    Private encabezadoField As ModeloProduccionEncabezado

    Private datosField As ModeloProduccionDatos

    '''<remarks/>
    Public Property Encabezado() As ModeloProduccionEncabezado
        Get
            Return Me.encabezadoField
        End Get
        Set
            Me.encabezadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Datos() As ModeloProduccionDatos
        Get
            Return Me.datosField
        End Get
        Set
            Me.datosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloProduccionEncabezado

    Private nombreArchivoField As String

    Private fechaField As String

    Private periodoField As String

    Private periodicidadField As Periodicidad

    Private monedaField As CodMoneda

    '''<remarks/>
    Public Property NombreArchivo() As String
        Get
            Return Me.nombreArchivoField
        End Get
        Set
            Me.nombreArchivoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Fecha() As String
        Get
            Return Me.fechaField
        End Get
        Set
            Me.fechaField = Value
        End Set
    End Property

    '''<remarks/>
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
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute()>
Public Enum Periodicidad

    '''<remarks/>
    T
End Enum


'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloProduccionDatos

    Private modeloField As ModeloProduccionDatosModelo

    '''<remarks/>
    Public Property Modelo() As ModeloProduccionDatosModelo
        Get
            Return Me.modeloField
        End Get
        Set
            Me.modeloField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloProduccionDatosModelo

    Private produccionPoblacionAseguradaField As ModeloProduccionDatosModeloProduccionPoblacionAsegurada

    Private entidadFuenteField As String

    '''<remarks/>
    Public Property ProduccionPoblacionAsegurada() As ModeloProduccionDatosModeloProduccionPoblacionAsegurada
        Get
            Return Me.produccionPoblacionAseguradaField
        End Get
        Set
            Me.produccionPoblacionAseguradaField = Value
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
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloProduccionDatosModeloProduccionPoblacionAsegurada

    Private ramoField() As ModeloProduccionDatosModeloProduccionPoblacionAseguradaRamo

    Private totalPolizasEmitidasField As String

    Private totalPolizasAnuladasoCanceladasField As String

    Private totalPolizasContratadasField As String

    Private totalDistribucionPolizasField As Decimal

    Private totalPolizasVencidasField As String

    Private totalPolizasNoRenovadasField As String

    Private totalTomadorFisicasJuridicasField As String

    Private totalColectivaModalidadContributivaField As Decimal

    Private totalColectivaModalidadNoContributivaField As Decimal

    Private totalDistribucionMonedaNacionalField As Decimal

    Private totalDistribucionMonedaInternacionalField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("Ramo")>
    Public Property Ramo() As ModeloProduccionDatosModeloProduccionPoblacionAseguradaRamo()
        Get
            Return Me.ramoField
        End Get
        Set
            Me.ramoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPolizasEmitidas() As String
        Get
            Return Me.totalPolizasEmitidasField
        End Get
        Set
            Me.totalPolizasEmitidasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPolizasAnuladasoCanceladas() As String
        Get
            Return Me.totalPolizasAnuladasoCanceladasField
        End Get
        Set
            Me.totalPolizasAnuladasoCanceladasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPolizasContratadas() As String
        Get
            Return Me.totalPolizasContratadasField
        End Get
        Set
            Me.totalPolizasContratadasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalDistribucionPolizas() As Decimal
        Get
            Return Me.totalDistribucionPolizasField
        End Get
        Set
            Me.totalDistribucionPolizasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPolizasVencidas() As String
        Get
            Return Me.totalPolizasVencidasField
        End Get
        Set
            Me.totalPolizasVencidasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPolizasNoRenovadas() As String
        Get
            Return Me.totalPolizasNoRenovadasField
        End Get
        Set
            Me.totalPolizasNoRenovadasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalTomadorFisicasJuridicas() As String
        Get
            Return Me.totalTomadorFisicasJuridicasField
        End Get
        Set
            Me.totalTomadorFisicasJuridicasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalColectivaModalidadContributiva() As Decimal
        Get
            Return Me.totalColectivaModalidadContributivaField
        End Get
        Set
            Me.totalColectivaModalidadContributivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalColectivaModalidadNoContributiva() As Decimal
        Get
            Return Me.totalColectivaModalidadNoContributivaField
        End Get
        Set
            Me.totalColectivaModalidadNoContributivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalDistribucionMonedaNacional() As Decimal
        Get
            Return Me.totalDistribucionMonedaNacionalField
        End Get
        Set
            Me.totalDistribucionMonedaNacionalField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalDistribucionMonedaInternacional() As Decimal
        Get
            Return Me.totalDistribucionMonedaInternacionalField
        End Get
        Set
            Me.totalDistribucionMonedaInternacionalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloProduccionDatosModeloProduccionPoblacionAseguradaRamo

    Private polizasEmitidasField As String

    Private polizasAnuladasoCanceladasField As String

    Private polizasContratadasField As String

    Private distribucionPolizasField As Decimal

    Private polizasVencidasField As String

    Private polizasNoRenovadasField As String

    Private tomadorFisicasJuridicasField As String

    Private colectivaModalidadContributivaField As Decimal

    Private colectivaModalidadNoContributivaField As Decimal

    Private distribucionMonedaNacionalField As System.Nullable(Of Decimal)

    Private distribucionMonedaInternacionalField As System.Nullable(Of Decimal)

    Private idField As TipoRamo

    '''<remarks/>
    Public Property PolizasEmitidas() As String
        Get
            Return Me.polizasEmitidasField
        End Get
        Set
            Me.polizasEmitidasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property PolizasAnuladasoCanceladas() As String
        Get
            Return Me.polizasAnuladasoCanceladasField
        End Get
        Set
            Me.polizasAnuladasoCanceladasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PolizasContratadas() As String
        Get
            Return Me.polizasContratadasField
        End Get
        Set
            Me.polizasContratadasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DistribucionPolizas() As Decimal
        Get
            Return Me.distribucionPolizasField
        End Get
        Set
            Me.distribucionPolizasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property PolizasVencidas() As String
        Get
            Return Me.polizasVencidasField
        End Get
        Set
            Me.polizasVencidasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property PolizasNoRenovadas() As String
        Get
            Return Me.polizasNoRenovadasField
        End Get
        Set
            Me.polizasNoRenovadasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property TomadorFisicasJuridicas() As String
        Get
            Return Me.tomadorFisicasJuridicasField
        End Get
        Set
            Me.tomadorFisicasJuridicasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ColectivaModalidadContributiva() As Decimal
        Get
            Return Me.colectivaModalidadContributivaField
        End Get
        Set
            Me.colectivaModalidadContributivaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ColectivaModalidadNoContributiva() As Decimal
        Get
            Return Me.colectivaModalidadNoContributivaField
        End Get
        Set
            Me.colectivaModalidadNoContributivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property DistribucionMonedaNacional() As System.Nullable(Of Decimal)
        Get
            Return Me.distribucionMonedaNacionalField
        End Get
        Set
            Me.distribucionMonedaNacionalField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property DistribucionMonedaInternacional() As System.Nullable(Of Decimal)
        Get
            Return Me.distribucionMonedaInternacionalField
        End Get
        Set
            Me.distribucionMonedaInternacionalField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property id() As TipoRamo
        Get
            Return Me.idField
        End Get
        Set
            Me.idField = Value
        End Set
    End Property
End Class