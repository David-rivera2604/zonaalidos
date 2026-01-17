'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class ModeloCanales

    Private encabezadoField As ModeloCanalesEncabezado

    Private datosField As ModeloCanalesDatos

    '''<remarks/>
    Public Property Encabezado() As ModeloCanalesEncabezado
        Get
            Return Me.encabezadoField
        End Get
        Set
            Me.encabezadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Datos() As ModeloCanalesDatos
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
Partial Public Class ModeloCanalesEncabezado

    Private nombreArchivoField As String

    Private fechaField As String

    Private periodoField As String

    Private periodicidadField As Periodicidad

    Private monedaField As String

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
    <System.Xml.Serialization.XmlElementAttribute(DataType:="integer")>
    Public Property Moneda() As String
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
Partial Public Class ModeloCanalesDatos

    Private modeloField As ModeloCanalesDatosModelo

    '''<remarks/>
    Public Property Modelo() As ModeloCanalesDatosModelo
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
Partial Public Class ModeloCanalesDatosModelo

    Private polizasContratadasSegPersonalesField As ModeloCanalesDatosModeloPolizasContratadasSegPersonales

    Private polizasContratadasSegGeneralesField As ModeloCanalesDatosModeloPolizasContratadasSegGenerales

    Private primasPolizasContratadasSegPersonalesField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonales

    Private primasPolizasContratadasSegGeneralesField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGenerales

    Private polizasContratadasNuevaProduccionSegPersonalesField As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonales

    Private polizasContratadasNuevaProduccionSegGeneralesField As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGenerales

    Private primasPolizasContratadasSegPersonalesNuevaProduccionField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccion

    Private primasPolizasContratadasSegGeneralesNuevaProduccionField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccion

    Private oficinasAseguradoraNuevaProdField() As ModeloCanalesDatosModeloDetalleOficina

    Private agenSegNoVinculadosSocAgenSegField As ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSeg

    Private sociedadesCorredorasSegField As ModeloCanalesDatosModeloSociedadesCorredorasSeg

    Private seguroObligatorioAutomovilesField As ModeloCanalesDatosModeloSeguroObligatorioAutomoviles

    Private entidadFuenteField As String

    '''<remarks/>
    Public Property PolizasContratadasSegPersonales() As ModeloCanalesDatosModeloPolizasContratadasSegPersonales
        Get
            Return Me.polizasContratadasSegPersonalesField
        End Get
        Set
            Me.polizasContratadasSegPersonalesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PolizasContratadasSegGenerales() As ModeloCanalesDatosModeloPolizasContratadasSegGenerales
        Get
            Return Me.polizasContratadasSegGeneralesField
        End Get
        Set
            Me.polizasContratadasSegGeneralesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasPolizasContratadasSegPersonales() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonales
        Get
            Return Me.primasPolizasContratadasSegPersonalesField
        End Get
        Set
            Me.primasPolizasContratadasSegPersonalesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasPolizasContratadasSegGenerales() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGenerales
        Get
            Return Me.primasPolizasContratadasSegGeneralesField
        End Get
        Set
            Me.primasPolizasContratadasSegGeneralesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PolizasContratadasNuevaProduccionSegPersonales() As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonales
        Get
            Return Me.polizasContratadasNuevaProduccionSegPersonalesField
        End Get
        Set
            Me.polizasContratadasNuevaProduccionSegPersonalesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PolizasContratadasNuevaProduccionSegGenerales() As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGenerales
        Get
            Return Me.polizasContratadasNuevaProduccionSegGeneralesField
        End Get
        Set
            Me.polizasContratadasNuevaProduccionSegGeneralesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasPolizasContratadasSegPersonalesNuevaProduccion() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccion
        Get
            Return Me.primasPolizasContratadasSegPersonalesNuevaProduccionField
        End Get
        Set
            Me.primasPolizasContratadasSegPersonalesNuevaProduccionField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasPolizasContratadasSegGeneralesNuevaProduccion() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccion
        Get
            Return Me.primasPolizasContratadasSegGeneralesNuevaProduccionField
        End Get
        Set
            Me.primasPolizasContratadasSegGeneralesNuevaProduccionField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlArrayItemAttribute("DetalleOficina", IsNullable:=False)>
    Public Property OficinasAseguradoraNuevaProd() As ModeloCanalesDatosModeloDetalleOficina()
        Get
            Return Me.oficinasAseguradoraNuevaProdField
        End Get
        Set
            Me.oficinasAseguradoraNuevaProdField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AgenSegNoVinculadosSocAgenSeg() As ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSeg
        Get
            Return Me.agenSegNoVinculadosSocAgenSegField
        End Get
        Set
            Me.agenSegNoVinculadosSocAgenSegField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SociedadesCorredorasSeg() As ModeloCanalesDatosModeloSociedadesCorredorasSeg
        Get
            Return Me.sociedadesCorredorasSegField
        End Get
        Set
            Me.sociedadesCorredorasSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SeguroObligatorioAutomoviles() As ModeloCanalesDatosModeloSeguroObligatorioAutomoviles
        Get
            Return Me.seguroObligatorioAutomovilesField
        End Get
        Set
            Me.seguroObligatorioAutomovilesField = Value
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
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasSegPersonales

    Private desglosePolizasContratadasSegPersonalesField As ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonales

    Private totalPolSegPersonalesField As String

    '''<remarks/>
    Public Property DesglosePolizasContratadasSegPersonales() As ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonales
        Get
            Return Me.desglosePolizasContratadasSegPersonalesField
        End Get
        Set
            Me.desglosePolizasContratadasSegPersonalesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPolSegPersonales() As String
        Get
            Return Me.totalPolSegPersonalesField
        End Get
        Set
            Me.totalPolSegPersonalesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonales

    Private ramoPolizasContratadasSegPersonalesField() As ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonales

    Private totalAgenSegNoVinculadoExclusivoField As String

    Private totalAgenSegNoVinculadosNoExclusivoField As String

    Private totalSocAgenSegExclusivaField As String

    Private totalSocAgenSegNoExclusivaField As String

    Private totalSocCorredoraSegField As String

    Private totalOperSegAutoexpedibleExclusivoField As String

    Private totalOperSegAutoexpedibleNoExclusivoField As String

    Private totalProveTransfronterizosSegField As String

    Private totalOfiEntAseguradoraField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("RamoPolizasContratadasSegPersonales")>
    Public Property RamoPolizasContratadasSegPersonales() As ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonales()
        Get
            Return Me.ramoPolizasContratadasSegPersonalesField
        End Get
        Set
            Me.ramoPolizasContratadasSegPersonalesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadoExclusivo() As String
        Get
            Return Me.totalAgenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadosNoExclusivo() As String
        Get
            Return Me.totalAgenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegExclusiva() As String
        Get
            Return Me.totalSocAgenSegExclusivaField
        End Get
        Set
            Me.totalSocAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegNoExclusiva() As String
        Get
            Return Me.totalSocAgenSegNoExclusivaField
        End Get
        Set
            Me.totalSocAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocCorredoraSeg() As String
        Get
            Return Me.totalSocCorredoraSegField
        End Get
        Set
            Me.totalSocCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleExclusivo() As String
        Get
            Return Me.totalOperSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleNoExclusivo() As String
        Get
            Return Me.totalOperSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProveTransfronterizosSeg() As String
        Get
            Return Me.totalProveTransfronterizosSegField
        End Get
        Set
            Me.totalProveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOfiEntAseguradora() As String
        Get
            Return Me.totalOfiEntAseguradoraField
        End Get
        Set
            Me.totalOfiEntAseguradoraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonales

    Private polizasContratadasSegPersonalesPorRamoField As ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonalesPolizasContratadasSegPersonalesPorRamo

    Private idField As TipoRamoPersonales

    '''<remarks/>
    Public Property PolizasContratadasSegPersonalesPorRamo() As ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonalesPolizasContratadasSegPersonalesPorRamo
        Get
            Return Me.polizasContratadasSegPersonalesPorRamoField
        End Get
        Set
            Me.polizasContratadasSegPersonalesPorRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property id() As TipoRamoPersonales
        Get
            Return Me.idField
        End Get
        Set
            Me.idField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonalesPolizasContratadasSegPersonalesPorRamo

    Private desglosePolizasContratadasSegPersonalesPorRamoField As ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonalesPolizasContratadasSegPersonalesPorRamoDesglosePolizasContratadasSegPersonalesPorRamo

    Private totalField As String

    '''<remarks/>
    Public Property DesglosePolizasContratadasSegPersonalesPorRamo() As ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonalesPolizasContratadasSegPersonalesPorRamoDesglosePolizasContratadasSegPersonalesPorRamo
        Get
            Return Me.desglosePolizasContratadasSegPersonalesPorRamoField
        End Get
        Set
            Me.desglosePolizasContratadasSegPersonalesPorRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As String
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasSegPersonalesDesglosePolizasContratadasSegPersonalesRamoPolizasContratadasSegPersonalesPolizasContratadasSegPersonalesPorRamoDesglosePolizasContratadasSegPersonalesPorRamo

    Private agenSegNoVinculadoExclusivoField As String

    Private agenSegNoVinculadosNoExclusivoField As String

    Private socAgenSegExclusivaField As String

    Private socAgenSegNoExclusivaField As String

    Private socCorredoraSegField As String

    Private operSegAutoexpedibleExclusivoField As String

    Private operSegAutoexpedibleNoExclusivoField As String

    Private proveTransfronterizosSegField As String

    Private ofiEntAseguradoraField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadoExclusivo() As String
        Get
            Return Me.agenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadosNoExclusivo() As String
        Get
            Return Me.agenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegExclusiva() As String
        Get
            Return Me.socAgenSegExclusivaField
        End Get
        Set
            Me.socAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegNoExclusiva() As String
        Get
            Return Me.socAgenSegNoExclusivaField
        End Get
        Set
            Me.socAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocCorredoraSeg() As String
        Get
            Return Me.socCorredoraSegField
        End Get
        Set
            Me.socCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleExclusivo() As String
        Get
            Return Me.operSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleNoExclusivo() As String
        Get
            Return Me.operSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property ProveTransfronterizosSeg() As String
        Get
            Return Me.proveTransfronterizosSegField
        End Get
        Set
            Me.proveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OfiEntAseguradora() As String
        Get
            Return Me.ofiEntAseguradoraField
        End Get
        Set
            Me.ofiEntAseguradoraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute()>
Public Enum TipoRamoPersonales

    '''<remarks/>
    P14

    '''<remarks/>
    P15

    '''<remarks/>
    P18

    '''<remarks/>
    P19

    '''<remarks/>
    P20

    '''<remarks/>
    P22

    '''<remarks/>
    'P23 según el SGS-A-0086-2021

    '''<remarks/>
    P25 'según el SGS-A-0086-2021
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasSegGenerales

    Private desglosePolizasContratadasSegGeneralesField As ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGenerales

    Private totalPolSegGeneralesField As String

    '''<remarks/>
    Public Property DesglosePolizasContratadasSegGenerales() As ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGenerales
        Get
            Return Me.desglosePolizasContratadasSegGeneralesField
        End Get
        Set
            Me.desglosePolizasContratadasSegGeneralesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPolSegGenerales() As String
        Get
            Return Me.totalPolSegGeneralesField
        End Get
        Set
            Me.totalPolSegGeneralesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGenerales

    Private ramoPolizasContratadasSegGeneralesField() As ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGenerales

    Private totalAgenSegNoVinculadoExclusivoField As String

    Private totalAgenSegNoVinculadosNoExclusivoField As String

    Private totalSocAgenSegExclusivaField As String

    Private totalSocAgenSegNoExclusivaField As String

    Private totalSocCorredoraSegField As String

    Private totalOperSegAutoexpedibleExclusivoField As String

    Private totalOperSegAutoexpedibleNoExclusivoField As String

    Private totalProveTransfronterizosSegField As String

    Private totalOfiEntAseguradoraField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("RamoPolizasContratadasSegGenerales")>
    Public Property RamoPolizasContratadasSegGenerales() As ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGenerales()
        Get
            Return Me.ramoPolizasContratadasSegGeneralesField
        End Get
        Set
            Me.ramoPolizasContratadasSegGeneralesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadoExclusivo() As String
        Get
            Return Me.totalAgenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadosNoExclusivo() As String
        Get
            Return Me.totalAgenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegExclusiva() As String
        Get
            Return Me.totalSocAgenSegExclusivaField
        End Get
        Set
            Me.totalSocAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegNoExclusiva() As String
        Get
            Return Me.totalSocAgenSegNoExclusivaField
        End Get
        Set
            Me.totalSocAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocCorredoraSeg() As String
        Get
            Return Me.totalSocCorredoraSegField
        End Get
        Set
            Me.totalSocCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleExclusivo() As String
        Get
            Return Me.totalOperSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleNoExclusivo() As String
        Get
            Return Me.totalOperSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProveTransfronterizosSeg() As String
        Get
            Return Me.totalProveTransfronterizosSegField
        End Get
        Set
            Me.totalProveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOfiEntAseguradora() As String
        Get
            Return Me.totalOfiEntAseguradoraField
        End Get
        Set
            Me.totalOfiEntAseguradoraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGenerales

    Private polizasContratadasSegGeneralesPorRamoField As ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGeneralesPolizasContratadasSegGeneralesPorRamo

    Private idField As TipoRamoGenerales

    '''<remarks/>
    Public Property PolizasContratadasSegGeneralesPorRamo() As ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGeneralesPolizasContratadasSegGeneralesPorRamo
        Get
            Return Me.polizasContratadasSegGeneralesPorRamoField
        End Get
        Set
            Me.polizasContratadasSegGeneralesPorRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property id() As TipoRamoGenerales
        Get
            Return Me.idField
        End Get
        Set
            Me.idField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGeneralesPolizasContratadasSegGeneralesPorRamo

    Private desglosePolizasContratadasSegGeneralesPorRamoField As ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGeneralesPolizasContratadasSegGeneralesPorRamoDesglosePolizasContratadasSegGeneralesPorRamo

    Private totalField As String

    '''<remarks/>
    Public Property DesglosePolizasContratadasSegGeneralesPorRamo() As ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGeneralesPolizasContratadasSegGeneralesPorRamoDesglosePolizasContratadasSegGeneralesPorRamo
        Get
            Return Me.desglosePolizasContratadasSegGeneralesPorRamoField
        End Get
        Set
            Me.desglosePolizasContratadasSegGeneralesPorRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As String
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasSegGeneralesDesglosePolizasContratadasSegGeneralesRamoPolizasContratadasSegGeneralesPolizasContratadasSegGeneralesPorRamoDesglosePolizasContratadasSegGeneralesPorRamo

    Private agenSegNoVinculadoExclusivoField As String

    Private agenSegNoVinculadosNoExclusivoField As String

    Private socAgenSegExclusivaField As String

    Private socAgenSegNoExclusivaField As String

    Private socCorredoraSegField As String

    Private operSegAutoexpedibleExclusivoField As String

    Private operSegAutoexpedibleNoExclusivoField As String

    Private proveTransfronterizosSegField As String

    Private ofiEntAseguradoraField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadoExclusivo() As String
        Get
            Return Me.agenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadosNoExclusivo() As String
        Get
            Return Me.agenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegExclusiva() As String
        Get
            Return Me.socAgenSegExclusivaField
        End Get
        Set
            Me.socAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegNoExclusiva() As String
        Get
            Return Me.socAgenSegNoExclusivaField
        End Get
        Set
            Me.socAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocCorredoraSeg() As String
        Get
            Return Me.socCorredoraSegField
        End Get
        Set
            Me.socCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleExclusivo() As String
        Get
            Return Me.operSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleNoExclusivo() As String
        Get
            Return Me.operSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property ProveTransfronterizosSeg() As String
        Get
            Return Me.proveTransfronterizosSegField
        End Get
        Set
            Me.proveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OfiEntAseguradora() As String
        Get
            Return Me.ofiEntAseguradoraField
        End Get
        Set
            Me.ofiEntAseguradoraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute()>
Public Enum TipoRamoGenerales

    '''<remarks/>
    G01

    '''<remarks/>
    G02

    '''<remarks/>
    G03

    '''<remarks/>
    G04

    '''<remarks/>
    G05

    '''<remarks/>
    G06

    '''<remarks/>
    G07

    '''<remarks/>
    G08

    '''<remarks/>
    G09

    '''<remarks/>
    G10

    '''<remarks/>
    G11

    '''<remarks/>
    G12

    '''<remarks/>
    'G13 según el SGS-A-0086-2021

    '''<remarks/>
    G17

    '''<remarks/>
    G21

    '''<remarks/>
    G24 'según el SGS-A-0086-2021
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonales

    Private desglosePrimasPolizasContratadasSegPersonalesField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonales

    Private totalPriSegPersonalesField As Decimal

    '''<remarks/>
    Public Property DesglosePrimasPolizasContratadasSegPersonales() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonales
        Get
            Return Me.desglosePrimasPolizasContratadasSegPersonalesField
        End Get
        Set
            Me.desglosePrimasPolizasContratadasSegPersonalesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPriSegPersonales() As Decimal
        Get
            Return Me.totalPriSegPersonalesField
        End Get
        Set
            Me.totalPriSegPersonalesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonales

    Private ramoPrimasPolizasContratadasSegPersonalesField() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonales

    Private totalAgenSegNoVinculadoExclusivoField As Decimal

    Private totalAgenSegNoVinculadosNoExclusivoField As Decimal

    Private totalSocAgenSegExclusivaField As Decimal

    Private totalSocAgenSegNoExclusivaField As Decimal

    Private totalSocCorredoraSegField As Decimal

    Private totalOperSegAutoexpedibleExclusivoField As Decimal

    Private totalOperSegAutoexpedibleNoExclusivoField As Decimal

    Private totalProveTransfronterizosSegField As Decimal

    Private totalOfiEntAseguradoraField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("RamoPrimasPolizasContratadasSegPersonales")>
    Public Property RamoPrimasPolizasContratadasSegPersonales() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonales()
        Get
            Return Me.ramoPrimasPolizasContratadasSegPersonalesField
        End Get
        Set
            Me.ramoPrimasPolizasContratadasSegPersonalesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadoExclusivo() As Decimal
        Get
            Return Me.totalAgenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadosNoExclusivo() As Decimal
        Get
            Return Me.totalAgenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegExclusiva() As Decimal
        Get
            Return Me.totalSocAgenSegExclusivaField
        End Get
        Set
            Me.totalSocAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegNoExclusiva() As Decimal
        Get
            Return Me.totalSocAgenSegNoExclusivaField
        End Get
        Set
            Me.totalSocAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocCorredoraSeg() As Decimal
        Get
            Return Me.totalSocCorredoraSegField
        End Get
        Set
            Me.totalSocCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleExclusivo() As Decimal
        Get
            Return Me.totalOperSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleNoExclusivo() As Decimal
        Get
            Return Me.totalOperSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProveTransfronterizosSeg() As Decimal
        Get
            Return Me.totalProveTransfronterizosSegField
        End Get
        Set
            Me.totalProveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOfiEntAseguradora() As Decimal
        Get
            Return Me.totalOfiEntAseguradoraField
        End Get
        Set
            Me.totalOfiEntAseguradoraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonales

    Private primasPolizasContratadasSegPersonalesPorRamoField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonalesPrimasPolizasContratadasSegPersonalesPorRamo

    Private idField As TipoRamoPersonales

    '''<remarks/>
    Public Property PrimasPolizasContratadasSegPersonalesPorRamo() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonalesPrimasPolizasContratadasSegPersonalesPorRamo
        Get
            Return Me.primasPolizasContratadasSegPersonalesPorRamoField
        End Get
        Set
            Me.primasPolizasContratadasSegPersonalesPorRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property id() As TipoRamoPersonales
        Get
            Return Me.idField
        End Get
        Set
            Me.idField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonalesPrimasPolizasContratadasSegPersonalesPorRamo

    Private desglosePrimasPolizasContratadasSegPersonalesPorRamoField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonalesPrimasPolizasContratadasSegPersonalesPorRamoDesglosePrimasPolizasContratadasSegPersonalesPorRamo

    Private totalField As Decimal

    <System.Xml.Serialization.XmlElementAttribute(ElementName:="DesglosePrimasPolizasContratadasSegPersonalesPorRamo", IsNullable:=False)>
    Public Property DesglosePrimasPolizasContratadasSegPersonalesPorRamo As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonalesPrimasPolizasContratadasSegPersonalesPorRamoDesglosePrimasPolizasContratadasSegPersonalesPorRamo
        Get
            Return Me.desglosePrimasPolizasContratadasSegPersonalesPorRamoField
        End Get
        Set
            Me.desglosePrimasPolizasContratadasSegPersonalesPorRamoField = Value
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
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesDesglosePrimasPolizasContratadasSegPersonalesRamoPrimasPolizasContratadasSegPersonalesPrimasPolizasContratadasSegPersonalesPorRamoDesglosePrimasPolizasContratadasSegPersonalesPorRamo

    Private agenSegNoVinculadoExclusivoField As System.Nullable(Of Decimal)

    Private agenSegNoVinculadoExclusivoFieldSpecified As Boolean

    Private agenSegNoVinculadosNoExclusivoField As System.Nullable(Of Decimal)

    Private agenSegNoVinculadosNoExclusivoFieldSpecified As Boolean

    Private socAgenSegExclusivaField As System.Nullable(Of Decimal)

    Private socAgenSegExclusivaFieldSpecified As Boolean

    Private socAgenSegNoExclusivaField As System.Nullable(Of Decimal)

    Private socAgenSegNoExclusivaFieldSpecified As Boolean

    Private socCorredoraSegField As System.Nullable(Of Decimal)

    Private socCorredoraSegFieldSpecified As Boolean

    Private operSegAutoexpedibleExclusivoField As System.Nullable(Of Decimal)

    Private operSegAutoexpedibleExclusivoFieldSpecified As Boolean

    Private operSegAutoexpedibleNoExclusivoField As System.Nullable(Of Decimal)

    Private operSegAutoexpedibleNoExclusivoFieldSpecified As Boolean

    Private proveTransfronterizosSegField As System.Nullable(Of Decimal)

    Private proveTransfronterizosSegFieldSpecified As Boolean

    Private ofiEntAseguradoraField As System.Nullable(Of Decimal)

    Private ofiEntAseguradoraFieldSpecified As Boolean

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadoExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.agenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property AgenSegNoVinculadoExclusivoSpecified() As Boolean
        Get
            Return Me.agenSegNoVinculadoExclusivoFieldSpecified
        End Get
        Set
            Me.agenSegNoVinculadoExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadosNoExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.agenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property AgenSegNoVinculadosNoExclusivoSpecified() As Boolean
        Get
            Return Me.agenSegNoVinculadosNoExclusivoFieldSpecified
        End Get
        Set
            Me.agenSegNoVinculadosNoExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegExclusiva() As System.Nullable(Of Decimal)
        Get
            Return Me.socAgenSegExclusivaField
        End Get
        Set
            Me.socAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property SocAgenSegExclusivaSpecified() As Boolean
        Get
            Return Me.socAgenSegExclusivaFieldSpecified
        End Get
        Set
            Me.socAgenSegExclusivaFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegNoExclusiva() As System.Nullable(Of Decimal)
        Get
            Return Me.socAgenSegNoExclusivaField
        End Get
        Set
            Me.socAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property SocAgenSegNoExclusivaSpecified() As Boolean
        Get
            Return Me.socAgenSegNoExclusivaFieldSpecified
        End Get
        Set
            Me.socAgenSegNoExclusivaFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocCorredoraSeg() As System.Nullable(Of Decimal)
        Get
            Return Me.socCorredoraSegField
        End Get
        Set
            Me.socCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property SocCorredoraSegSpecified() As Boolean
        Get
            Return Me.socCorredoraSegFieldSpecified
        End Get
        Set
            Me.socCorredoraSegFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.operSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property OperSegAutoexpedibleExclusivoSpecified() As Boolean
        Get
            Return Me.operSegAutoexpedibleExclusivoFieldSpecified
        End Get
        Set
            Me.operSegAutoexpedibleExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleNoExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.operSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property OperSegAutoexpedibleNoExclusivoSpecified() As Boolean
        Get
            Return Me.operSegAutoexpedibleNoExclusivoFieldSpecified
        End Get
        Set
            Me.operSegAutoexpedibleNoExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property ProveTransfronterizosSeg() As System.Nullable(Of Decimal)
        Get
            Return Me.proveTransfronterizosSegField
        End Get
        Set
            Me.proveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property ProveTransfronterizosSegSpecified() As Boolean
        Get
            Return Me.proveTransfronterizosSegFieldSpecified
        End Get
        Set
            Me.proveTransfronterizosSegFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OfiEntAseguradora() As System.Nullable(Of Decimal)
        Get
            Return Me.ofiEntAseguradoraField
        End Get
        Set
            Me.ofiEntAseguradoraField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property OfiEntAseguradoraSpecified() As Boolean
        Get
            Return Me.ofiEntAseguradoraFieldSpecified
        End Get
        Set
            Me.ofiEntAseguradoraFieldSpecified = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegGenerales

    Private desglosePrimasPolizasContratadasSegGeneralesField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGenerales

    Private totalPriSegGeneralesField As Decimal

    '''<remarks/>
    Public Property DesglosePrimasPolizasContratadasSegGenerales() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGenerales
        Get
            Return Me.desglosePrimasPolizasContratadasSegGeneralesField
        End Get
        Set
            Me.desglosePrimasPolizasContratadasSegGeneralesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPriSegGenerales() As Decimal
        Get
            Return Me.totalPriSegGeneralesField
        End Get
        Set
            Me.totalPriSegGeneralesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGenerales

    Private ramoPrimasPolizasContratadasSegGeneralesField() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGenerales

    Private totalAgenSegNoVinculadoExclusivoField As Decimal

    Private totalAgenSegNoVinculadosNoExclusivoField As Decimal

    Private totalSocAgenSegExclusivaField As Decimal

    Private totalSocAgenSegNoExclusivaField As Decimal

    Private totalSocCorredoraSegField As Decimal

    Private totalOperSegAutoexpedibleExclusivoField As Decimal

    Private totalOperSegAutoexpedibleNoExclusivoField As Decimal

    Private totalProveTransfronterizosSegField As Decimal

    Private totalOfiEntAseguradoraField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("RamoPrimasPolizasContratadasSegGenerales")>
    Public Property RamoPrimasPolizasContratadasSegGenerales() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGenerales()
        Get
            Return Me.ramoPrimasPolizasContratadasSegGeneralesField
        End Get
        Set
            Me.ramoPrimasPolizasContratadasSegGeneralesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadoExclusivo() As Decimal
        Get
            Return Me.totalAgenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadosNoExclusivo() As Decimal
        Get
            Return Me.totalAgenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegExclusiva() As Decimal
        Get
            Return Me.totalSocAgenSegExclusivaField
        End Get
        Set
            Me.totalSocAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegNoExclusiva() As Decimal
        Get
            Return Me.totalSocAgenSegNoExclusivaField
        End Get
        Set
            Me.totalSocAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocCorredoraSeg() As Decimal
        Get
            Return Me.totalSocCorredoraSegField
        End Get
        Set
            Me.totalSocCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleExclusivo() As Decimal
        Get
            Return Me.totalOperSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleNoExclusivo() As Decimal
        Get
            Return Me.totalOperSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProveTransfronterizosSeg() As Decimal
        Get
            Return Me.totalProveTransfronterizosSegField
        End Get
        Set
            Me.totalProveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOfiEntAseguradora() As Decimal
        Get
            Return Me.totalOfiEntAseguradoraField
        End Get
        Set
            Me.totalOfiEntAseguradoraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGenerales

    Private primasPolizasContratadasSegGeneralesPorRamoField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGeneralesPrimasPolizasContratadasSegGeneralesPorRamo

    Private idField As TipoRamoGenerales

    '''<remarks/>
    Public Property PrimasPolizasContratadasSegGeneralesPorRamo() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGeneralesPrimasPolizasContratadasSegGeneralesPorRamo
        Get
            Return Me.primasPolizasContratadasSegGeneralesPorRamoField
        End Get
        Set
            Me.primasPolizasContratadasSegGeneralesPorRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property id() As TipoRamoGenerales
        Get
            Return Me.idField
        End Get
        Set
            Me.idField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGeneralesPrimasPolizasContratadasSegGeneralesPorRamo

    Private desglosePrimasPolizasContratadasSegGeneralesPorRamoField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGeneralesPrimasPolizasContratadasSegGeneralesPorRamoDesglosePrimasPolizasContratadasSegGeneralesPorRamo

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesglosePrimasPolizasContratadasSegGeneralesPorRamo() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGeneralesPrimasPolizasContratadasSegGeneralesPorRamoDesglosePrimasPolizasContratadasSegGeneralesPorRamo
        Get
            Return Me.desglosePrimasPolizasContratadasSegGeneralesPorRamoField
        End Get
        Set
            Me.desglosePrimasPolizasContratadasSegGeneralesPorRamoField = Value
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
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesDesglosePrimasPolizasContratadasSegGeneralesRamoPrimasPolizasContratadasSegGeneralesPrimasPolizasContratadasSegGeneralesPorRamoDesglosePrimasPolizasContratadasSegGeneralesPorRamo

    Private agenSegNoVinculadoExclusivoField As System.Nullable(Of Decimal)

    Private agenSegNoVinculadoExclusivoFieldSpecified As Boolean

    Private agenSegNoVinculadosNoExclusivoField As System.Nullable(Of Decimal)

    Private agenSegNoVinculadosNoExclusivoFieldSpecified As Boolean

    Private socAgenSegExclusivaField As System.Nullable(Of Decimal)

    Private socAgenSegExclusivaFieldSpecified As Boolean

    Private socAgenSegNoExclusivaField As System.Nullable(Of Decimal)

    Private socAgenSegNoExclusivaFieldSpecified As Boolean

    Private socCorredoraSegField As System.Nullable(Of Decimal)

    Private socCorredoraSegFieldSpecified As Boolean

    Private operSegAutoexpedibleExclusivoField As System.Nullable(Of Decimal)

    Private operSegAutoexpedibleExclusivoFieldSpecified As Boolean

    Private operSegAutoexpedibleNoExclusivoField As System.Nullable(Of Decimal)

    Private operSegAutoexpedibleNoExclusivoFieldSpecified As Boolean

    Private proveTransfronterizosSegField As System.Nullable(Of Decimal)

    Private proveTransfronterizosSegFieldSpecified As Boolean

    Private ofiEntAseguradoraField As System.Nullable(Of Decimal)

    Private ofiEntAseguradoraFieldSpecified As Boolean

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadoExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.agenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property AgenSegNoVinculadoExclusivoSpecified() As Boolean
        Get
            Return Me.agenSegNoVinculadoExclusivoFieldSpecified
        End Get
        Set
            Me.agenSegNoVinculadoExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadosNoExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.agenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property AgenSegNoVinculadosNoExclusivoSpecified() As Boolean
        Get
            Return Me.agenSegNoVinculadosNoExclusivoFieldSpecified
        End Get
        Set
            Me.agenSegNoVinculadosNoExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegExclusiva() As System.Nullable(Of Decimal)
        Get
            Return Me.socAgenSegExclusivaField
        End Get
        Set
            Me.socAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property SocAgenSegExclusivaSpecified() As Boolean
        Get
            Return Me.socAgenSegExclusivaFieldSpecified
        End Get
        Set
            Me.socAgenSegExclusivaFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegNoExclusiva() As System.Nullable(Of Decimal)
        Get
            Return Me.socAgenSegNoExclusivaField
        End Get
        Set
            Me.socAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property SocAgenSegNoExclusivaSpecified() As Boolean
        Get
            Return Me.socAgenSegNoExclusivaFieldSpecified
        End Get
        Set
            Me.socAgenSegNoExclusivaFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocCorredoraSeg() As System.Nullable(Of Decimal)
        Get
            Return Me.socCorredoraSegField
        End Get
        Set
            Me.socCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property SocCorredoraSegSpecified() As Boolean
        Get
            Return Me.socCorredoraSegFieldSpecified
        End Get
        Set
            Me.socCorredoraSegFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.operSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property OperSegAutoexpedibleExclusivoSpecified() As Boolean
        Get
            Return Me.operSegAutoexpedibleExclusivoFieldSpecified
        End Get
        Set
            Me.operSegAutoexpedibleExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleNoExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.operSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property OperSegAutoexpedibleNoExclusivoSpecified() As Boolean
        Get
            Return Me.operSegAutoexpedibleNoExclusivoFieldSpecified
        End Get
        Set
            Me.operSegAutoexpedibleNoExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property ProveTransfronterizosSeg() As System.Nullable(Of Decimal)
        Get
            Return Me.proveTransfronterizosSegField
        End Get
        Set
            Me.proveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property ProveTransfronterizosSegSpecified() As Boolean
        Get
            Return Me.proveTransfronterizosSegFieldSpecified
        End Get
        Set
            Me.proveTransfronterizosSegFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OfiEntAseguradora() As System.Nullable(Of Decimal)
        Get
            Return Me.ofiEntAseguradoraField
        End Get
        Set
            Me.ofiEntAseguradoraField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property OfiEntAseguradoraSpecified() As Boolean
        Get
            Return Me.ofiEntAseguradoraFieldSpecified
        End Get
        Set
            Me.ofiEntAseguradoraFieldSpecified = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonales

    Private desglosePolizasContratadasNuevaProduccionSegPersonalesField As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonales

    Private totalPolSegPersonalesField As String

    '''<remarks/>
    Public Property DesglosePolizasContratadasNuevaProduccionSegPersonales() As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonales
        Get
            Return Me.desglosePolizasContratadasNuevaProduccionSegPersonalesField
        End Get
        Set
            Me.desglosePolizasContratadasNuevaProduccionSegPersonalesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPolSegPersonales() As String
        Get
            Return Me.totalPolSegPersonalesField
        End Get
        Set
            Me.totalPolSegPersonalesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonales

    Private ramoPolizasContratadasNuevaProduccionSegPersonalesField() As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonales

    Private totalAgenSegNoVinculadoExclusivoField As String

    Private totalAgenSegNoVinculadosNoExclusivoField As String

    Private totalSocAgenSegExclusivaField As String

    Private totalSocAgenSegNoExclusivaField As String

    Private totalSocCorredoraSegField As String

    Private totalOperSegAutoexpedibleExclusivoField As String

    Private totalOperSegAutoexpedibleNoExclusivoField As String

    Private totalProveTransfronterizosSegField As String

    Private totalOfiEntAseguradoraField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("RamoPolizasContratadasNuevaProduccionSegPersonales")>
    Public Property RamoPolizasContratadasNuevaProduccionSegPersonales() As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonales()
        Get
            Return Me.ramoPolizasContratadasNuevaProduccionSegPersonalesField
        End Get
        Set
            Me.ramoPolizasContratadasNuevaProduccionSegPersonalesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadoExclusivo() As String
        Get
            Return Me.totalAgenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadosNoExclusivo() As String
        Get
            Return Me.totalAgenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegExclusiva() As String
        Get
            Return Me.totalSocAgenSegExclusivaField
        End Get
        Set
            Me.totalSocAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegNoExclusiva() As String
        Get
            Return Me.totalSocAgenSegNoExclusivaField
        End Get
        Set
            Me.totalSocAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocCorredoraSeg() As String
        Get
            Return Me.totalSocCorredoraSegField
        End Get
        Set
            Me.totalSocCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleExclusivo() As String
        Get
            Return Me.totalOperSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleNoExclusivo() As String
        Get
            Return Me.totalOperSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProveTransfronterizosSeg() As String
        Get
            Return Me.totalProveTransfronterizosSegField
        End Get
        Set
            Me.totalProveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOfiEntAseguradora() As String
        Get
            Return Me.totalOfiEntAseguradoraField
        End Get
        Set
            Me.totalOfiEntAseguradoraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonales

    Private polizasContratadasNuevaProduccionSegPersonalesPorRamoField As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonalesPolizasContratadasNuevaProduccionSegPersonalesPorRamo

    Private idField As TipoRamoPersonales

    '''<remarks/>
    Public Property PolizasContratadasNuevaProduccionSegPersonalesPorRamo() As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonalesPolizasContratadasNuevaProduccionSegPersonalesPorRamo
        Get
            Return Me.polizasContratadasNuevaProduccionSegPersonalesPorRamoField
        End Get
        Set
            Me.polizasContratadasNuevaProduccionSegPersonalesPorRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property id() As TipoRamoPersonales
        Get
            Return Me.idField
        End Get
        Set
            Me.idField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonalesPolizasContratadasNuevaProduccionSegPersonalesPorRamo

    Private desglosePolizasContratadasNuevaProduccionSegPersonalesPorRamoField As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonalesPolizasContratadasNuevaProduccionSegPersonalesPorRamoDesglosePolizasContratadasNuevaProduccionSegPersonalesPorRamo

    Private totalField As String

    '''<remarks/>
    Public Property DesglosePolizasContratadasNuevaProduccionSegPersonalesPorRamo() As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonalesPolizasContratadasNuevaProduccionSegPersonalesPorRamoDesglosePolizasContratadasNuevaProduccionSegPersonalesPorRamo
        Get
            Return Me.desglosePolizasContratadasNuevaProduccionSegPersonalesPorRamoField
        End Get
        Set
            Me.desglosePolizasContratadasNuevaProduccionSegPersonalesPorRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As String
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegPersonalesDesglosePolizasContratadasNuevaProduccionSegPersonalesRamoPolizasContratadasNuevaProduccionSegPersonalesPolizasContratadasNuevaProduccionSegPersonalesPorRamoDesglosePolizasContratadasNuevaProduccionSegPersonalesPorRamo

    Private agenSegNoVinculadoExclusivoField As String

    Private agenSegNoVinculadosNoExclusivoField As String

    Private socAgenSegExclusivaField As String

    Private socAgenSegNoExclusivaField As String

    Private socCorredoraSegField As String

    Private operSegAutoexpedibleExclusivoField As String

    Private operSegAutoexpedibleNoExclusivoField As String

    Private proveTransfronterizosSegField As String

    Private ofiEntAseguradoraField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadoExclusivo() As String
        Get
            Return Me.agenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadosNoExclusivo() As String
        Get
            Return Me.agenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegExclusiva() As String
        Get
            Return Me.socAgenSegExclusivaField
        End Get
        Set
            Me.socAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegNoExclusiva() As String
        Get
            Return Me.socAgenSegNoExclusivaField
        End Get
        Set
            Me.socAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocCorredoraSeg() As String
        Get
            Return Me.socCorredoraSegField
        End Get
        Set
            Me.socCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleExclusivo() As String
        Get
            Return Me.operSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleNoExclusivo() As String
        Get
            Return Me.operSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property ProveTransfronterizosSeg() As String
        Get
            Return Me.proveTransfronterizosSegField
        End Get
        Set
            Me.proveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OfiEntAseguradora() As String
        Get
            Return Me.ofiEntAseguradoraField
        End Get
        Set
            Me.ofiEntAseguradoraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGenerales

    Private desglosePolizasContratadasNuevaProduccionSegGeneralesField As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGenerales

    Private totalPolSegGeneralesField As String

    '''<remarks/>
    Public Property DesglosePolizasContratadasNuevaProduccionSegGenerales() As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGenerales
        Get
            Return Me.desglosePolizasContratadasNuevaProduccionSegGeneralesField
        End Get
        Set
            Me.desglosePolizasContratadasNuevaProduccionSegGeneralesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPolSegGenerales() As String
        Get
            Return Me.totalPolSegGeneralesField
        End Get
        Set
            Me.totalPolSegGeneralesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGenerales

    Private ramoPolizasContratadasNuevaProduccionSegGeneralesField() As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGenerales

    Private totalAgenSegNoVinculadoExclusivoField As String

    Private totalAgenSegNoVinculadosNoExclusivoField As String

    Private totalSocAgenSegExclusivaField As String

    Private totalSocAgenSegNoExclusivaField As String

    Private totalSocCorredoraSegField As String

    Private totalOperSegAutoexpedibleExclusivoField As String

    Private totalOperSegAutoexpedibleNoExclusivoField As String

    Private totalProveTransfronterizosSegField As String

    Private totalOfiEntAseguradoraField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("RamoPolizasContratadasNuevaProduccionSegGenerales")>
    Public Property RamoPolizasContratadasNuevaProduccionSegGenerales() As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGenerales()
        Get
            Return Me.ramoPolizasContratadasNuevaProduccionSegGeneralesField
        End Get
        Set
            Me.ramoPolizasContratadasNuevaProduccionSegGeneralesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadoExclusivo() As String
        Get
            Return Me.totalAgenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadosNoExclusivo() As String
        Get
            Return Me.totalAgenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegExclusiva() As String
        Get
            Return Me.totalSocAgenSegExclusivaField
        End Get
        Set
            Me.totalSocAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegNoExclusiva() As String
        Get
            Return Me.totalSocAgenSegNoExclusivaField
        End Get
        Set
            Me.totalSocAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocCorredoraSeg() As String
        Get
            Return Me.totalSocCorredoraSegField
        End Get
        Set
            Me.totalSocCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleExclusivo() As String
        Get
            Return Me.totalOperSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleNoExclusivo() As String
        Get
            Return Me.totalOperSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProveTransfronterizosSeg() As String
        Get
            Return Me.totalProveTransfronterizosSegField
        End Get
        Set
            Me.totalProveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOfiEntAseguradora() As String
        Get
            Return Me.totalOfiEntAseguradoraField
        End Get
        Set
            Me.totalOfiEntAseguradoraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGenerales

    Private polizasContratadasNuevaProduccionSegGeneralesPorRamoField As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGeneralesPolizasContratadasNuevaProduccionSegGeneralesPorRamo

    Private idField As TipoRamoGenerales

    '''<remarks/>
    Public Property PolizasContratadasNuevaProduccionSegGeneralesPorRamo() As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGeneralesPolizasContratadasNuevaProduccionSegGeneralesPorRamo
        Get
            Return Me.polizasContratadasNuevaProduccionSegGeneralesPorRamoField
        End Get
        Set
            Me.polizasContratadasNuevaProduccionSegGeneralesPorRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property id() As TipoRamoGenerales
        Get
            Return Me.idField
        End Get
        Set
            Me.idField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGeneralesPolizasContratadasNuevaProduccionSegGeneralesPorRamo

    Private desglosePolizasContratadasNuevaProduccionSegGeneralesPorRamoField As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGeneralesPolizasContratadasNuevaProduccionSegGeneralesPorRamoDesglosePolizasContratadasNuevaProduccionSegGeneralesPorRamo

    Private totalField As String

    '''<remarks/>
    Public Property DesglosePolizasContratadasNuevaProduccionSegGeneralesPorRamo() As ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGeneralesPolizasContratadasNuevaProduccionSegGeneralesPorRamoDesglosePolizasContratadasNuevaProduccionSegGeneralesPorRamo
        Get
            Return Me.desglosePolizasContratadasNuevaProduccionSegGeneralesPorRamoField
        End Get
        Set
            Me.desglosePolizasContratadasNuevaProduccionSegGeneralesPorRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As String
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPolizasContratadasNuevaProduccionSegGeneralesDesglosePolizasContratadasNuevaProduccionSegGeneralesRamoPolizasContratadasNuevaProduccionSegGeneralesPolizasContratadasNuevaProduccionSegGeneralesPorRamoDesglosePolizasContratadasNuevaProduccionSegGeneralesPorRamo

    Private agenSegNoVinculadoExclusivoField As String

    Private agenSegNoVinculadosNoExclusivoField As String

    Private socAgenSegExclusivaField As String

    Private socAgenSegNoExclusivaField As String

    Private socCorredoraSegField As String

    Private operSegAutoexpedibleExclusivoField As String

    Private operSegAutoexpedibleNoExclusivoField As String

    Private proveTransfronterizosSegField As String

    Private ofiEntAseguradoraField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadoExclusivo() As String
        Get
            Return Me.agenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadosNoExclusivo() As String
        Get
            Return Me.agenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegExclusiva() As String
        Get
            Return Me.socAgenSegExclusivaField
        End Get
        Set
            Me.socAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegNoExclusiva() As String
        Get
            Return Me.socAgenSegNoExclusivaField
        End Get
        Set
            Me.socAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocCorredoraSeg() As String
        Get
            Return Me.socCorredoraSegField
        End Get
        Set
            Me.socCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleExclusivo() As String
        Get
            Return Me.operSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleNoExclusivo() As String
        Get
            Return Me.operSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property ProveTransfronterizosSeg() As String
        Get
            Return Me.proveTransfronterizosSegField
        End Get
        Set
            Me.proveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OfiEntAseguradora() As String
        Get
            Return Me.ofiEntAseguradoraField
        End Get
        Set
            Me.ofiEntAseguradoraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccion

    Private desglosePrimasPolizasContratadasSegPersonalesNuevaProduccionField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccion

    Private totalPriSegPersonalesField As Decimal

    '''<remarks/>
    Public Property DesglosePrimasPolizasContratadasSegPersonalesNuevaProduccion() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccion
        Get
            Return Me.desglosePrimasPolizasContratadasSegPersonalesNuevaProduccionField
        End Get
        Set
            Me.desglosePrimasPolizasContratadasSegPersonalesNuevaProduccionField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPriSegPersonales() As Decimal
        Get
            Return Me.totalPriSegPersonalesField
        End Get
        Set
            Me.totalPriSegPersonalesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccion

    Private ramoPrimasPolizasContratadasSegPersonalesNuevaProduccionField() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccion

    Private totalAgenSegNoVinculadoExclusivoField As Decimal

    Private totalAgenSegNoVinculadosNoExclusivoField As Decimal

    Private totalSocAgenSegExclusivaField As Decimal

    Private totalSocAgenSegNoExclusivaField As Decimal

    Private totalSocCorredoraSegField As Decimal

    Private totalOperSegAutoexpedibleExclusivoField As Decimal

    Private totalOperSegAutoexpedibleNoExclusivoField As Decimal

    Private totalProveTransfronterizosSegField As Decimal

    Private totalOfiEntAseguradoraField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("RamoPrimasPolizasContratadasSegPersonalesNuevaProduccion")>
    Public Property RamoPrimasPolizasContratadasSegPersonalesNuevaProduccion() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccion()
        Get
            Return Me.ramoPrimasPolizasContratadasSegPersonalesNuevaProduccionField
        End Get
        Set
            Me.ramoPrimasPolizasContratadasSegPersonalesNuevaProduccionField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadoExclusivo() As Decimal
        Get
            Return Me.totalAgenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadosNoExclusivo() As Decimal
        Get
            Return Me.totalAgenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegExclusiva() As Decimal
        Get
            Return Me.totalSocAgenSegExclusivaField
        End Get
        Set
            Me.totalSocAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegNoExclusiva() As Decimal
        Get
            Return Me.totalSocAgenSegNoExclusivaField
        End Get
        Set
            Me.totalSocAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocCorredoraSeg() As Decimal
        Get
            Return Me.totalSocCorredoraSegField
        End Get
        Set
            Me.totalSocCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleExclusivo() As Decimal
        Get
            Return Me.totalOperSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleNoExclusivo() As Decimal
        Get
            Return Me.totalOperSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProveTransfronterizosSeg() As Decimal
        Get
            Return Me.totalProveTransfronterizosSegField
        End Get
        Set
            Me.totalProveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOfiEntAseguradora() As Decimal
        Get
            Return Me.totalOfiEntAseguradoraField
        End Get
        Set
            Me.totalOfiEntAseguradoraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccion

    Private primasPolizasContratadasSegPersonalesNuevaProduccionPorRamoField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccionPrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo

    Private idField As TipoRamoPersonales

    '''<remarks/>
    Public Property PrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccionPrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo
        Get
            Return Me.primasPolizasContratadasSegPersonalesNuevaProduccionPorRamoField
        End Get
        Set
            Me.primasPolizasContratadasSegPersonalesNuevaProduccionPorRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property id() As TipoRamoPersonales
        Get
            Return Me.idField
        End Get
        Set
            Me.idField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccionPrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo

    Private desglosePrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamoField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccionPrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamoDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccionPrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamoDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo
        Get
            Return Me.desglosePrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamoField
        End Get
        Set
            Me.desglosePrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamoField = Value
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
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegPersonalesNuevaProduccionDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionRamoPrimasPolizasContratadasSegPersonalesNuevaProduccionPrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamoDesglosePrimasPolizasContratadasSegPersonalesNuevaProduccionPorRamo

    Private agenSegNoVinculadoExclusivoField As System.Nullable(Of Decimal)

    Private agenSegNoVinculadoExclusivoFieldSpecified As Boolean

    Private agenSegNoVinculadosNoExclusivoField As System.Nullable(Of Decimal)

    Private agenSegNoVinculadosNoExclusivoFieldSpecified As Boolean

    Private socAgenSegExclusivaField As System.Nullable(Of Decimal)

    Private socAgenSegExclusivaFieldSpecified As Boolean

    Private socAgenSegNoExclusivaField As System.Nullable(Of Decimal)

    Private socAgenSegNoExclusivaFieldSpecified As Boolean

    Private socCorredoraSegField As System.Nullable(Of Decimal)

    Private socCorredoraSegFieldSpecified As Boolean

    Private operSegAutoexpedibleExclusivoField As System.Nullable(Of Decimal)

    Private operSegAutoexpedibleExclusivoFieldSpecified As Boolean

    Private operSegAutoexpedibleNoExclusivoField As System.Nullable(Of Decimal)

    Private operSegAutoexpedibleNoExclusivoFieldSpecified As Boolean

    Private proveTransfronterizosSegField As System.Nullable(Of Decimal)

    Private proveTransfronterizosSegFieldSpecified As Boolean

    Private ofiEntAseguradoraField As System.Nullable(Of Decimal)

    Private ofiEntAseguradoraFieldSpecified As Boolean

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadoExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.agenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property AgenSegNoVinculadoExclusivoSpecified() As Boolean
        Get
            Return Me.agenSegNoVinculadoExclusivoFieldSpecified
        End Get
        Set
            Me.agenSegNoVinculadoExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadosNoExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.agenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property AgenSegNoVinculadosNoExclusivoSpecified() As Boolean
        Get
            Return Me.agenSegNoVinculadosNoExclusivoFieldSpecified
        End Get
        Set
            Me.agenSegNoVinculadosNoExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegExclusiva() As System.Nullable(Of Decimal)
        Get
            Return Me.socAgenSegExclusivaField
        End Get
        Set
            Me.socAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property SocAgenSegExclusivaSpecified() As Boolean
        Get
            Return Me.socAgenSegExclusivaFieldSpecified
        End Get
        Set
            Me.socAgenSegExclusivaFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegNoExclusiva() As System.Nullable(Of Decimal)
        Get
            Return Me.socAgenSegNoExclusivaField
        End Get
        Set
            Me.socAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property SocAgenSegNoExclusivaSpecified() As Boolean
        Get
            Return Me.socAgenSegNoExclusivaFieldSpecified
        End Get
        Set
            Me.socAgenSegNoExclusivaFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocCorredoraSeg() As System.Nullable(Of Decimal)
        Get
            Return Me.socCorredoraSegField
        End Get
        Set
            Me.socCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property SocCorredoraSegSpecified() As Boolean
        Get
            Return Me.socCorredoraSegFieldSpecified
        End Get
        Set
            Me.socCorredoraSegFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.operSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property OperSegAutoexpedibleExclusivoSpecified() As Boolean
        Get
            Return Me.operSegAutoexpedibleExclusivoFieldSpecified
        End Get
        Set
            Me.operSegAutoexpedibleExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleNoExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.operSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property OperSegAutoexpedibleNoExclusivoSpecified() As Boolean
        Get
            Return Me.operSegAutoexpedibleNoExclusivoFieldSpecified
        End Get
        Set
            Me.operSegAutoexpedibleNoExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property ProveTransfronterizosSeg() As System.Nullable(Of Decimal)
        Get
            Return Me.proveTransfronterizosSegField
        End Get
        Set
            Me.proveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property ProveTransfronterizosSegSpecified() As Boolean
        Get
            Return Me.proveTransfronterizosSegFieldSpecified
        End Get
        Set
            Me.proveTransfronterizosSegFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OfiEntAseguradora() As System.Nullable(Of Decimal)
        Get
            Return Me.ofiEntAseguradoraField
        End Get
        Set
            Me.ofiEntAseguradoraField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property OfiEntAseguradoraSpecified() As Boolean
        Get
            Return Me.ofiEntAseguradoraFieldSpecified
        End Get
        Set
            Me.ofiEntAseguradoraFieldSpecified = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccion

    Private desglosePrimasPolizasContratadasSegGeneralesNuevaProduccionField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccion

    Private totalPriSegGeneralesField As Decimal

    '''<remarks/>
    Public Property DesglosePrimasPolizasContratadasSegGeneralesNuevaProduccion() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccion
        Get
            Return Me.desglosePrimasPolizasContratadasSegGeneralesNuevaProduccionField
        End Get
        Set
            Me.desglosePrimasPolizasContratadasSegGeneralesNuevaProduccionField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPriSegGenerales() As Decimal
        Get
            Return Me.totalPriSegGeneralesField
        End Get
        Set
            Me.totalPriSegGeneralesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccion

    Private ramoPrimasPolizasContratadasSegGeneralesNuevaProduccionField() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccion

    Private totalAgenSegNoVinculadoExclusivoField As Decimal

    Private totalAgenSegNoVinculadosNoExclusivoField As Decimal

    Private totalSocAgenSegExclusivaField As Decimal

    Private totalSocAgenSegNoExclusivaField As Decimal

    Private totalSocCorredoraSegField As Decimal

    Private totalOperSegAutoexpedibleExclusivoField As Decimal

    Private totalOperSegAutoexpedibleNoExclusivoField As Decimal

    Private totalProveTransfronterizosSegField As Decimal

    Private totalOfiEntAseguradoraField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("RamoPrimasPolizasContratadasSegGeneralesNuevaProduccion")>
    Public Property RamoPrimasPolizasContratadasSegGeneralesNuevaProduccion() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccion()
        Get
            Return Me.ramoPrimasPolizasContratadasSegGeneralesNuevaProduccionField
        End Get
        Set
            Me.ramoPrimasPolizasContratadasSegGeneralesNuevaProduccionField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadoExclusivo() As Decimal
        Get
            Return Me.totalAgenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAgenSegNoVinculadosNoExclusivo() As Decimal
        Get
            Return Me.totalAgenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.totalAgenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegExclusiva() As Decimal
        Get
            Return Me.totalSocAgenSegExclusivaField
        End Get
        Set
            Me.totalSocAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocAgenSegNoExclusiva() As Decimal
        Get
            Return Me.totalSocAgenSegNoExclusivaField
        End Get
        Set
            Me.totalSocAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSocCorredoraSeg() As Decimal
        Get
            Return Me.totalSocCorredoraSegField
        End Get
        Set
            Me.totalSocCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleExclusivo() As Decimal
        Get
            Return Me.totalOperSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOperSegAutoexpedibleNoExclusivo() As Decimal
        Get
            Return Me.totalOperSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.totalOperSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProveTransfronterizosSeg() As Decimal
        Get
            Return Me.totalProveTransfronterizosSegField
        End Get
        Set
            Me.totalProveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOfiEntAseguradora() As Decimal
        Get
            Return Me.totalOfiEntAseguradoraField
        End Get
        Set
            Me.totalOfiEntAseguradoraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccion

    Private primasPolizasContratadasSegGeneralesNuevaProduccionPorRamoField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccionPrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo

    Private idField As TipoRamoGenerales

    '''<remarks/>
    Public Property PrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccionPrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo
        Get
            Return Me.primasPolizasContratadasSegGeneralesNuevaProduccionPorRamoField
        End Get
        Set
            Me.primasPolizasContratadasSegGeneralesNuevaProduccionPorRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property id() As TipoRamoGenerales
        Get
            Return Me.idField
        End Get
        Set
            Me.idField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccionPrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo

    Private desglosePrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamoField As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccionPrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamoDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo() As ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccionPrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamoDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo
        Get
            Return Me.desglosePrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamoField
        End Get
        Set
            Me.desglosePrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamoField = Value
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
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloPrimasPolizasContratadasSegGeneralesNuevaProduccionDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionRamoPrimasPolizasContratadasSegGeneralesNuevaProduccionPrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamoDesglosePrimasPolizasContratadasSegGeneralesNuevaProduccionPorRamo

    Private agenSegNoVinculadoExclusivoField As System.Nullable(Of Decimal)

    Private agenSegNoVinculadoExclusivoFieldSpecified As Boolean

    Private agenSegNoVinculadosNoExclusivoField As System.Nullable(Of Decimal)

    Private agenSegNoVinculadosNoExclusivoFieldSpecified As Boolean

    Private socAgenSegExclusivaField As System.Nullable(Of Decimal)

    Private socAgenSegExclusivaFieldSpecified As Boolean

    Private socAgenSegNoExclusivaField As System.Nullable(Of Decimal)

    Private socAgenSegNoExclusivaFieldSpecified As Boolean

    Private socCorredoraSegField As System.Nullable(Of Decimal)

    Private socCorredoraSegFieldSpecified As Boolean

    Private operSegAutoexpedibleExclusivoField As System.Nullable(Of Decimal)

    Private operSegAutoexpedibleExclusivoFieldSpecified As Boolean

    Private operSegAutoexpedibleNoExclusivoField As System.Nullable(Of Decimal)

    Private operSegAutoexpedibleNoExclusivoFieldSpecified As Boolean

    Private proveTransfronterizosSegField As System.Nullable(Of Decimal)

    Private proveTransfronterizosSegFieldSpecified As Boolean

    Private ofiEntAseguradoraField As System.Nullable(Of Decimal)

    Private ofiEntAseguradoraFieldSpecified As Boolean

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadoExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.agenSegNoVinculadoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property AgenSegNoVinculadoExclusivoSpecified() As Boolean
        Get
            Return Me.agenSegNoVinculadoExclusivoFieldSpecified
        End Get
        Set
            Me.agenSegNoVinculadoExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadosNoExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.agenSegNoVinculadosNoExclusivoField
        End Get
        Set
            Me.agenSegNoVinculadosNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property AgenSegNoVinculadosNoExclusivoSpecified() As Boolean
        Get
            Return Me.agenSegNoVinculadosNoExclusivoFieldSpecified
        End Get
        Set
            Me.agenSegNoVinculadosNoExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegExclusiva() As System.Nullable(Of Decimal)
        Get
            Return Me.socAgenSegExclusivaField
        End Get
        Set
            Me.socAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property SocAgenSegExclusivaSpecified() As Boolean
        Get
            Return Me.socAgenSegExclusivaFieldSpecified
        End Get
        Set
            Me.socAgenSegExclusivaFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegNoExclusiva() As System.Nullable(Of Decimal)
        Get
            Return Me.socAgenSegNoExclusivaField
        End Get
        Set
            Me.socAgenSegNoExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property SocAgenSegNoExclusivaSpecified() As Boolean
        Get
            Return Me.socAgenSegNoExclusivaFieldSpecified
        End Get
        Set
            Me.socAgenSegNoExclusivaFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocCorredoraSeg() As System.Nullable(Of Decimal)
        Get
            Return Me.socCorredoraSegField
        End Get
        Set
            Me.socCorredoraSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property SocCorredoraSegSpecified() As Boolean
        Get
            Return Me.socCorredoraSegFieldSpecified
        End Get
        Set
            Me.socCorredoraSegFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.operSegAutoexpedibleExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property OperSegAutoexpedibleExclusivoSpecified() As Boolean
        Get
            Return Me.operSegAutoexpedibleExclusivoFieldSpecified
        End Get
        Set
            Me.operSegAutoexpedibleExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OperSegAutoexpedibleNoExclusivo() As System.Nullable(Of Decimal)
        Get
            Return Me.operSegAutoexpedibleNoExclusivoField
        End Get
        Set
            Me.operSegAutoexpedibleNoExclusivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property OperSegAutoexpedibleNoExclusivoSpecified() As Boolean
        Get
            Return Me.operSegAutoexpedibleNoExclusivoFieldSpecified
        End Get
        Set
            Me.operSegAutoexpedibleNoExclusivoFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property ProveTransfronterizosSeg() As System.Nullable(Of Decimal)
        Get
            Return Me.proveTransfronterizosSegField
        End Get
        Set
            Me.proveTransfronterizosSegField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property ProveTransfronterizosSegSpecified() As Boolean
        Get
            Return Me.proveTransfronterizosSegFieldSpecified
        End Get
        Set
            Me.proveTransfronterizosSegFieldSpecified = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OfiEntAseguradora() As System.Nullable(Of Decimal)
        Get
            Return Me.ofiEntAseguradoraField
        End Get
        Set
            Me.ofiEntAseguradoraField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlIgnoreAttribute()>
    Public Property OfiEntAseguradoraSpecified() As Boolean
        Get
            Return Me.ofiEntAseguradoraFieldSpecified
        End Get
        Set
            Me.ofiEntAseguradoraFieldSpecified = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloDetalleOficina

    Private domicilioField As Canton

    Private numEmpleadosField As String

    Private primasPolizasContratadasNuevaProdField As Decimal

    '''<remarks/>
    Public Property Domicilio() As Canton
        Get
            Return Me.domicilioField
        End Get
        Set
            Me.domicilioField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumEmpleados() As String
        Get
            Return Me.numEmpleadosField
        End Get
        Set
            Me.numEmpleadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasPolizasContratadasNuevaProd() As Decimal
        Get
            Return Me.primasPolizasContratadasNuevaProdField
        End Get
        Set
            Me.primasPolizasContratadasNuevaProdField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute()>
Public Enum Canton

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("101")>
    Item101 = 101

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("102")>
    Item102 = 102

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("103")>
    Item103 = 103

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("104")>
    Item104 = 104

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("105")>
    Item105 = 105

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("106")>
    Item106 = 106

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("107")>
    Item107 = 107

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("108")>
    Item108 = 108

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("109")>
    Item109 = 109

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("110")>
    Item110 = 110

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("111")>
    Item111 = 111

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("112")>
    Item112 = 112

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("113")>
    Item113 = 113

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("114")>
    Item114 = 114

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("115")>
    Item115 = 115

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("116")>
    Item116 = 116

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("117")>
    Item117 = 117

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("118")>
    Item118 = 118

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("119")>
    Item119 = 119

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("120")>
    Item120 = 120

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("201")>
    Item201 = 201

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("202")>
    Item202 = 202

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("203")>
    Item203 = 203

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("204")>
    Item204 = 204

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("205")>
    Item205 = 20

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("206")>
    Item206 = 206

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("207")>
    Item207 = 207

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("208")>
    Item208 = 208

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("209")>
    Item209 = 209

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("210")>
    Item210 = 210

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("211")>
    Item211 = 211

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("212")>
    Item212 = 212

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("213")>
    Item213 = 213

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("214")>
    Item214 = 214

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("215")>
    Item215 = 215

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("301")>
    Item301 = 301

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("302")>
    Item302 = 302

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("303")>
    Item303 = 303

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("304")>
    Item304 = 304

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("305")>
    Item305 = 305

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("306")>
    Item306 = 306

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("307")>
    Item307 = 307

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("308")>
    Item308 = 308

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("401")>
    Item401 = 401

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("402")>
    Item402 = 402

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("403")>
    Item403 = 403

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("404")>
    Item404 = 404

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("405")>
    Item405 = 405

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("406")>
    Item406 = 406

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("407")>
    Item407 = 407

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("408")>
    Item408 = 408

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("409")>
    Item409 = 409

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("410")>
    Item410 = 410

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("501")>
    Item501 = 501

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("502")>
    Item502 = 502

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("503")>
    Item503 = 503

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("504")>
    Item504 = 504

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("505")>
    Item505 = 505

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("506")>
    Item506 = 506

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("507")>
    Item507 = 507

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("508")>
    Item508 = 508

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("509")>
    Item509 = 509

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("510")>
    Item510 = 510

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("511")>
    Item511 = 511

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("601")>
    Item601 = 601

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("602")>
    Item602 = 602

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("603")>
    Item603 = 603

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("604")>
    Item604 = 604

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("605")>
    Item605 = 605

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("606")>
    Item606 = 606

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("607")>
    Item607 = 607

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("608")>
    Item608 = 608

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("609")>
    Item609 = 609

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("610")>
    Item610 = 610

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("611")>
    Item611 = 611

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("701")>
    Item701 = 701

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("702")>
    Item702 = 702

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("703")>
    Item703 = 703

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("704")>
    Item704 = 704

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("705")>
    Item705 = 705

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("706")>
    Item706 = 706
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSeg

    Private numContratosAgenciasCierreAnnoField As ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumContratosAgenciasCierreAnno

    Private numAgenSocAportaronDuranteAnnoField As ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumAgenSocAportaronDuranteAnno

    '''<remarks/>
    Public Property NumContratosAgenciasCierreAnno() As ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumContratosAgenciasCierreAnno
        Get
            Return Me.numContratosAgenciasCierreAnnoField
        End Get
        Set
            Me.numContratosAgenciasCierreAnnoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumAgenSocAportaronDuranteAnno() As ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumAgenSocAportaronDuranteAnno
        Get
            Return Me.numAgenSocAportaronDuranteAnnoField
        End Get
        Set
            Me.numAgenSocAportaronDuranteAnnoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumContratosAgenciasCierreAnno

    Private desgloseNumContratosAgenciasCierreAnnoField As ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumContratosAgenciasCierreAnnoDesgloseNumContratosAgenciasCierreAnno

    Private totalField As String

    '''<remarks/>
    Public Property DesgloseNumContratosAgenciasCierreAnno() As ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumContratosAgenciasCierreAnnoDesgloseNumContratosAgenciasCierreAnno
        Get
            Return Me.desgloseNumContratosAgenciasCierreAnnoField
        End Get
        Set
            Me.desgloseNumContratosAgenciasCierreAnnoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As String
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumContratosAgenciasCierreAnnoDesgloseNumContratosAgenciasCierreAnno

    Private agenSegNoVinculadosExclusivosField As String

    Private agenSegNoVinculadosNoExclusivosField As String

    Private socAgenSegExclusivaField As String

    Private socAgenSegNoExclusivaField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadosExclusivos() As String
        Get
            Return Me.agenSegNoVinculadosExclusivosField
        End Get
        Set
            Me.agenSegNoVinculadosExclusivosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadosNoExclusivos() As String
        Get
            Return Me.agenSegNoVinculadosNoExclusivosField
        End Get
        Set
            Me.agenSegNoVinculadosNoExclusivosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegExclusiva() As String
        Get
            Return Me.socAgenSegExclusivaField
        End Get
        Set
            Me.socAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegNoExclusiva() As String
        Get
            Return Me.socAgenSegNoExclusivaField
        End Get
        Set
            Me.socAgenSegNoExclusivaField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumAgenSocAportaronDuranteAnno

    Private desgloseNumAgenSocAportaronDuranteAnnoField As ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumAgenSocAportaronDuranteAnnoDesgloseNumAgenSocAportaronDuranteAnno

    Private totalField As String

    '''<remarks/>
    Public Property DesgloseNumAgenSocAportaronDuranteAnno() As ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumAgenSocAportaronDuranteAnnoDesgloseNumAgenSocAportaronDuranteAnno
        Get
            Return Me.desgloseNumAgenSocAportaronDuranteAnnoField
        End Get
        Set
            Me.desgloseNumAgenSocAportaronDuranteAnnoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Total() As String
        Get
            Return Me.totalField
        End Get
        Set
            Me.totalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloAgenSegNoVinculadosSocAgenSegNumAgenSocAportaronDuranteAnnoDesgloseNumAgenSocAportaronDuranteAnno

    Private agenSegNoVinculadosExclusivosField As String

    Private agenSegNoVinculadosNoExclusivosField As String

    Private socAgenSegExclusivaField As String

    Private socAgenSegNoExclusivaField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadosExclusivos() As String
        Get
            Return Me.agenSegNoVinculadosExclusivosField
        End Get
        Set
            Me.agenSegNoVinculadosExclusivosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property AgenSegNoVinculadosNoExclusivos() As String
        Get
            Return Me.agenSegNoVinculadosNoExclusivosField
        End Get
        Set
            Me.agenSegNoVinculadosNoExclusivosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegExclusiva() As String
        Get
            Return Me.socAgenSegExclusivaField
        End Get
        Set
            Me.socAgenSegExclusivaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property SocAgenSegNoExclusiva() As String
        Get
            Return Me.socAgenSegNoExclusivaField
        End Get
        Set
            Me.socAgenSegNoExclusivaField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloSociedadesCorredorasSeg

    Private detalleSocCorredoraField() As ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredora

    Private numSociedadesIncorporadasField As String

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("DetalleSocCorredora")>
    Public Property DetalleSocCorredora() As ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredora()
        Get
            Return Me.detalleSocCorredoraField
        End Get
        Set
            Me.detalleSocCorredoraField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property NumSociedadesIncorporadas() As String
        Get
            Return Me.numSociedadesIncorporadasField
        End Get
        Set
            Me.numSociedadesIncorporadasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredora

    Private denominacionSocField As String

    Private codAutorizacionField As Corredora

    Private detalleSegurosGeneralesPorRamoField As ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosGeneralesPorRamo

    Private detalleSegurosPersonalesPorRamoField As ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosPersonalesPorRamo


    '''<remarks/>
    Public Property DenominacionSoc() As String
        Get
            Return Me.denominacionSocField
        End Get
        Set
            Me.denominacionSocField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CodAutorizacion() As Corredora
        Get
            Return Me.codAutorizacionField
        End Get
        Set
            Me.codAutorizacionField = Value
        End Set
    End Property

    '''<remarks/>
    '<System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property DetalleSegurosGeneralesPorRamo() As ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosGeneralesPorRamo
        Get
            Return Me.detalleSegurosGeneralesPorRamoField
        End Get
        Set
            Me.detalleSegurosGeneralesPorRamoField = Value
        End Set
    End Property

    '''<remarks/>
    '<System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property DetalleSegurosPersonalesPorRamo() As ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosPersonalesPorRamo
        Get
            Return Me.detalleSegurosPersonalesPorRamoField
        End Get
        Set
            Me.detalleSegurosPersonalesPorRamoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute()>
Public Enum Corredora

    '''<remarks/>
    SC09101

    '''<remarks/>
    SC09102

    '''<remarks/>
    SC10103

    '''<remarks/>
    SC10104

    '''<remarks/>
    SC10105

    '''<remarks/>
    SC10106

    '''<remarks/>
    SC11107

    '''<remarks/>
    SC11108

    '''<remarks/>
    SC11109

    '''<remarks/>
    SC11110

    '''<remarks/>
    SC11111

    '''<remarks/>
    SC12112

    '''<remarks/>
    SC12113

    '''<remarks/>
    SC12114

    '''<remarks/>
    SC12115

    '''<remarks/>
    SC12116

    '''<remarks/>
    SC13117

    ''' <summary>
    '''  CSS CORREDORES DE SEGUROS S.A.
    ''' </summary>
    SC13118

    '''<remarks/>
    SC14119

    '''<remarks/>
    SC14120

    '''<remarks/>
    SC15121

    '''<remarks/>
    SC16122

    '''<remarks/>
    SC16123

    '''<remarks/>
    SC16124

    '''<remarks/>
    SC16125

    '''<remarks/>
    SC16126

    '''<remarks/>
    SC17127

    '''<remarks/>
    SC17128

    SC18129
    SC18130
    SC18131
    SC19132
    SC20133
    ''' <summary>
    ''' PURDY CORREDORA SEGUROS S.A 
    ''' </summary>
    SC21134
    SC21135
    ''' <summary>
    '''  SOCIEDAD CORREDORA DE SEGUROS UNISEGUROS
    ''' </summary>
    SC22136
    ''' <summary>
    '''  DESYFIN CORREDORA DE SEGUROS S.A.
    ''' </summary>
    SC23137
    ''' <summary>
    '''  MONGE CORREDORA DE SEGUOS S.A.
    ''' </summary>
    SC23138
    SC25139
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloSeguroObligatorioAutomoviles

    Private polizasPagadasField As ModeloCanalesDatosModeloSeguroObligatorioAutomovilesPolizasPagadas

    Private montoPrimaField As ModeloCanalesDatosModeloSeguroObligatorioAutomovilesMontoPrima

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property PolizasPagadas() As ModeloCanalesDatosModeloSeguroObligatorioAutomovilesPolizasPagadas
        Get
            Return Me.polizasPagadasField
        End Get
        Set
            Me.polizasPagadasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property MontoPrima() As ModeloCanalesDatosModeloSeguroObligatorioAutomovilesMontoPrima
        Get
            Return Me.montoPrimaField
        End Get
        Set
            Me.montoPrimaField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloSeguroObligatorioAutomovilesPolizasPagadas

    Private bancosPublicosField As System.Nullable(Of Decimal)

    Private bancosPrivadosField As System.Nullable(Of Decimal)

    Private cooperativasField As System.Nullable(Of Decimal)

    Private otrasPersonasFisicasField As System.Nullable(Of Decimal)

    Private otrasPersonasJuridicasField As System.Nullable(Of Decimal)

    Private oficinasEntidadField As System.Nullable(Of Decimal)

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property BancosPublicos() As System.Nullable(Of Decimal)
        Get
            Return Me.bancosPublicosField
        End Get
        Set
            Me.bancosPublicosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property BancosPrivados() As System.Nullable(Of Decimal)
        Get
            Return Me.bancosPrivadosField
        End Get
        Set
            Me.bancosPrivadosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property Cooperativas() As System.Nullable(Of Decimal)
        Get
            Return Me.cooperativasField
        End Get
        Set
            Me.cooperativasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OtrasPersonasFisicas() As System.Nullable(Of Decimal)
        Get
            Return Me.otrasPersonasFisicasField
        End Get
        Set
            Me.otrasPersonasFisicasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OtrasPersonasJuridicas() As System.Nullable(Of Decimal)
        Get
            Return Me.otrasPersonasJuridicasField
        End Get
        Set
            Me.otrasPersonasJuridicasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OficinasEntidad() As System.Nullable(Of Decimal)
        Get
            Return Me.oficinasEntidadField
        End Get
        Set
            Me.oficinasEntidadField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloSeguroObligatorioAutomovilesMontoPrima

    Private bancosPublicosField As System.Nullable(Of Decimal)

    Private bancosPrivadosField As System.Nullable(Of Decimal)

    Private cooperativasField As System.Nullable(Of Decimal)

    Private otrasPersonasFisicasField As System.Nullable(Of Decimal)

    Private otrasPersonasJuridicasField As System.Nullable(Of Decimal)

    Private oficinasEntidadField As System.Nullable(Of Decimal)

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property BancosPublicos() As System.Nullable(Of Decimal)
        Get
            Return Me.bancosPublicosField
        End Get
        Set
            Me.bancosPublicosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property BancosPrivados() As System.Nullable(Of Decimal)
        Get
            Return Me.bancosPrivadosField
        End Get
        Set
            Me.bancosPrivadosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property Cooperativas() As System.Nullable(Of Decimal)
        Get
            Return Me.cooperativasField
        End Get
        Set
            Me.cooperativasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OtrasPersonasFisicas() As System.Nullable(Of Decimal)
        Get
            Return Me.otrasPersonasFisicasField
        End Get
        Set
            Me.otrasPersonasFisicasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OtrasPersonasJuridicas() As System.Nullable(Of Decimal)
        Get
            Return Me.otrasPersonasJuridicasField
        End Get
        Set
            Me.otrasPersonasJuridicasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(IsNullable:=True)>
    Public Property OficinasEntidad() As System.Nullable(Of Decimal)
        Get
            Return Me.oficinasEntidadField
        End Get
        Set
            Me.oficinasEntidadField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosGeneralesPorRamo

    Private ramoSegurosGeneralesField() As ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosGeneralesPorRamoRamoSegurosGenerales

    Private totalMontoPrimasColocadasField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("RamoSegurosGenerales")>
    Public Property RamoSegurosGenerales() As ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosGeneralesPorRamoRamoSegurosGenerales()
        Get
            Return Me.ramoSegurosGeneralesField
        End Get
        Set
            Me.ramoSegurosGeneralesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalMontoPrimasColocadas() As Decimal
        Get
            Return Me.totalMontoPrimasColocadasField
        End Get
        Set
            Me.totalMontoPrimasColocadasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosGeneralesPorRamoRamoSegurosGenerales

    Private montoPrimasColocadasField As Decimal

    Private idField As TipoRamoGenerales

    '''<remarks/>
    Public Property MontoPrimasColocadas() As Decimal
        Get
            Return Me.montoPrimasColocadasField
        End Get
        Set
            Me.montoPrimasColocadasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property id() As TipoRamoGenerales
        Get
            Return Me.idField
        End Get
        Set
            Me.idField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosPersonalesPorRamo

    Private ramoSegurosPersonalesField() As ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosPersonalesPorRamoRamoSegurosPersonales

    Private totalMontoPrimasColocadasField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("RamoSegurosPersonales")>
    Public Property RamoSegurosPersonales() As ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosPersonalesPorRamoRamoSegurosPersonales()
        Get
            Return Me.ramoSegurosPersonalesField
        End Get
        Set
            Me.ramoSegurosPersonalesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalMontoPrimasColocadas() As Decimal
        Get
            Return Me.totalMontoPrimasColocadasField
        End Get
        Set
            Me.totalMontoPrimasColocadasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCanalesDatosModeloSociedadesCorredorasSegDetalleSocCorredoraDetalleSegurosPersonalesPorRamoRamoSegurosPersonales

    Private montoPrimasColocadasField As Decimal

    Private idField As TipoRamoPersonales

    '''<remarks/>
    Public Property MontoPrimasColocadas() As Decimal
        Get
            Return Me.montoPrimasColocadasField
        End Get
        Set
            Me.montoPrimasColocadasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property id() As TipoRamoPersonales
        Get
            Return Me.idField
        End Get
        Set
            Me.idField = Value
        End Set
    End Property
End Class