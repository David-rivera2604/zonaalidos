Option Strict Off
Option Explicit On

Imports System.Xml.Serialization
Imports Architect.Sugese.Domain

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
     System.SerializableAttribute(),
     System.Diagnostics.DebuggerStepThroughAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class ModeloAporteBomberos

    Private encabezadoField As ModeloAporteBomberosEncabezado

    Private datosField As ModeloAporteBomberosDatos

    '''<remarks/>
    Public Property Encabezado() As ModeloAporteBomberosEncabezado
        Get
            Return Me.encabezadoField
        End Get
        Set
            Me.encabezadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Datos() As ModeloAporteBomberosDatos
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
Partial Public Class ModeloAporteBomberosEncabezado

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
    M

End Enum


'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
     System.SerializableAttribute(),
     System.Diagnostics.DebuggerStepThroughAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloAporteBomberosDatos

    Private modeloField As ModeloAporteBomberosDatosModelo

    '''<remarks/>
    Public Property Modelo() As ModeloAporteBomberosDatosModelo
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
Partial Public Class ModeloAporteBomberosDatosModelo

    Private ramoAporteBomberosField() As ModeloAporteBomberosDatosModeloRamoAporteBomberos

    Private entidadFuenteField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("RamoAporteBomberos")>
    Public Property RamoAporteBomberos() As ModeloAporteBomberosDatosModeloRamoAporteBomberos()
        Get
            Return Me.ramoAporteBomberosField
        End Get
        Set
            Me.ramoAporteBomberosField = Value
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
Partial Public Class ModeloAporteBomberosDatosModeloRamoAporteBomberos

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("Polizas")>
    Public Property Polizas() As ModeloAporteBomberosDatosModeloRamoAporteBomberosPolizas()

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property id() As TipoRamo

End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
     System.SerializableAttribute(),
     System.Diagnostics.DebuggerStepThroughAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloAporteBomberosDatosModeloRamoAporteBomberosPolizas

    Private primasDirectasField As Decimal

    Private pagarField As Decimal

    Private codMonedaField As CodMonedaInt

    '''<remarks/>
    Public Property PrimasDirectas() As Decimal
        Get
            Return Me.primasDirectasField
        End Get
        Set
            Me.primasDirectasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Pagar() As Decimal
        Get
            Return Me.pagarField
        End Get
        Set
            Me.pagarField = Value
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

End Class

