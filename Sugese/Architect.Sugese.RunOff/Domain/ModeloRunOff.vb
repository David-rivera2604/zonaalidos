Imports Architect.Sugese.Domain

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class ModeloRunOff

    Private encabezadoField As ModeloRunOffEncabezado

    Private datosField As ModeloRunOffDatos

    '''<remarks/>
    Public Property Encabezado() As ModeloRunOffEncabezado
        Get
            Return Me.encabezadoField
        End Get
        Set
            Me.encabezadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Datos() As ModeloRunOffDatos
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
Partial Public Class ModeloRunOffEncabezado

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
 System.SerializableAttribute()>
Public Enum CodMoneda

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
    <System.Xml.Serialization.XmlEnumAttribute("5")>
    Item5

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("6")>
    Item6

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("7")>
    Item7

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("8")>
    Item8

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("9")>
    Item9

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("10")>
    Item10

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("11")>
    Item11

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("12")>
    Item12

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("13")>
    Item13

    '''<remarks/>
    <System.Xml.Serialization.XmlEnumAttribute("14")>
    Item14
End Enum

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatos

    Private modeloField As ModeloRunOffDatosModelo

    '''<remarks/>
    Public Property Modelo() As ModeloRunOffDatosModelo
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
Partial Public Class ModeloRunOffDatosModelo

    Private siniestrosField As ModeloRunOffDatosModeloSiniestros

    Private primasYProvisionPrimasNoDevengadasField As ModeloRunOffDatosModeloPrimasYProvisionPrimasNoDevengadas

    Private polizasPeriodoField As ModeloRunOffDatosModeloPolizasPeriodo

    Private suficienciaField As ModeloRunOffDatosModeloSuficiencia

    Private modeloEstadisticoField As ModeloRunOffDatosModeloModeloEstadistico

    Private entidadFuenteField As String

    '''<remarks/>
    Public Property Siniestros() As ModeloRunOffDatosModeloSiniestros
        Get
            Return Me.siniestrosField
        End Get
        Set
            Me.siniestrosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasYProvisionPrimasNoDevengadas() As ModeloRunOffDatosModeloPrimasYProvisionPrimasNoDevengadas
        Get
            Return Me.primasYProvisionPrimasNoDevengadasField
        End Get
        Set
            Me.primasYProvisionPrimasNoDevengadasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PolizasPeriodo() As ModeloRunOffDatosModeloPolizasPeriodo
        Get
            Return Me.polizasPeriodoField
        End Get
        Set
            Me.polizasPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Suficiencia() As ModeloRunOffDatosModeloSuficiencia
        Get
            Return Me.suficienciaField
        End Get
        Set
            Me.suficienciaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ModeloEstadistico() As ModeloRunOffDatosModeloModeloEstadistico
        Get
            Return Me.modeloEstadisticoField
        End Get
        Set
            Me.modeloEstadisticoField = Value
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
Partial Public Class ModeloRunOffDatosModeloSiniestros

    Private pendInicioEjercicioPendCierrePeriodoField As ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioPendCierrePeriodo

    Private pendInicioEjercicioTermCierrePeriodoField As ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioTermCierrePeriodo

    Private ocurridosPeriodoPendientesCierrePeriodoField As ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoPendientesCierrePeriodo

    Private ocurridosPeriodoTerminadosPeriodoField As ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoTerminadosPeriodo

    Private pendientesDeclaracionField As ModeloRunOffDatosModeloSiniestrosPendientesDeclaracion

    '''<remarks/>
    Public Property PendInicioEjercicioPendCierrePeriodo() As ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioPendCierrePeriodo
        Get
            Return Me.pendInicioEjercicioPendCierrePeriodoField
        End Get
        Set
            Me.pendInicioEjercicioPendCierrePeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PendInicioEjercicioTermCierrePeriodo() As ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioTermCierrePeriodo
        Get
            Return Me.pendInicioEjercicioTermCierrePeriodoField
        End Get
        Set
            Me.pendInicioEjercicioTermCierrePeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OcurridosPeriodoPendientesCierrePeriodo() As ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoPendientesCierrePeriodo
        Get
            Return Me.ocurridosPeriodoPendientesCierrePeriodoField
        End Get
        Set
            Me.ocurridosPeriodoPendientesCierrePeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OcurridosPeriodoTerminadosPeriodo() As ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoTerminadosPeriodo
        Get
            Return Me.ocurridosPeriodoTerminadosPeriodoField
        End Get
        Set
            Me.ocurridosPeriodoTerminadosPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PendientesDeclaracion() As ModeloRunOffDatosModeloSiniestrosPendientesDeclaracion
        Get
            Return Me.pendientesDeclaracionField
        End Get
        Set
            Me.pendientesDeclaracionField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioPendCierrePeriodo

    Private desglosePendInicioEjercicioPendCierrePeriodoRamoField() As ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioPendCierrePeriodoDesglosePendInicioEjercicioPendCierrePeriodoRamo

    Private totalNumSiniestrosField As Decimal

    Private totalImportePagadoComienzoField As Decimal

    Private totalProvisionComienzoField As Decimal

    Private totalImportePagadoPeriodoField As Decimal

    Private totalProvisionCierrePeriodoField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("DesglosePendInicioEjercicioPendCierrePeriodoRamo")>
    Public Property DesglosePendInicioEjercicioPendCierrePeriodoRamo() As ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioPendCierrePeriodoDesglosePendInicioEjercicioPendCierrePeriodoRamo()
        Get
            Return Me.desglosePendInicioEjercicioPendCierrePeriodoRamoField
        End Get
        Set
            Me.desglosePendInicioEjercicioPendCierrePeriodoRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalNumSiniestros() As Decimal
        Get
            Return Me.totalNumSiniestrosField
        End Get
        Set
            Me.totalNumSiniestrosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalImportePagadoComienzo() As Decimal
        Get
            Return Me.totalImportePagadoComienzoField
        End Get
        Set
            Me.totalImportePagadoComienzoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProvisionComienzo() As Decimal
        Get
            Return Me.totalProvisionComienzoField
        End Get
        Set
            Me.totalProvisionComienzoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalImportePagadoPeriodo() As Decimal
        Get
            Return Me.totalImportePagadoPeriodoField
        End Get
        Set
            Me.totalImportePagadoPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProvisionCierrePeriodo() As Decimal
        Get
            Return Me.totalProvisionCierrePeriodoField
        End Get
        Set
            Me.totalProvisionCierrePeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioPendCierrePeriodoDesglosePendInicioEjercicioPendCierrePeriodoRamo

    Private numSiniestrosField As Decimal

    Private importePagadoComienzoField As Decimal

    Private provisionComienzoField As Decimal

    Private importePagadoPeriodoField As Decimal

    Private provisionCierrePeriodoField As Decimal

    Private idField As TipoRamo

    '''<remarks/>
    Public Property NumSiniestros() As Decimal
        Get
            Return Me.numSiniestrosField
        End Get
        Set
            Me.numSiniestrosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ImportePagadoComienzo() As Decimal
        Get
            Return Me.importePagadoComienzoField
        End Get
        Set
            Me.importePagadoComienzoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionComienzo() As Decimal
        Get
            Return Me.provisionComienzoField
        End Get
        Set
            Me.provisionComienzoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ImportePagadoPeriodo() As Decimal
        Get
            Return Me.importePagadoPeriodoField
        End Get
        Set
            Me.importePagadoPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionCierrePeriodo() As Decimal
        Get
            Return Me.provisionCierrePeriodoField
        End Get
        Set
            Me.provisionCierrePeriodoField = Value
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


'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioTermCierrePeriodo

    Private desglosePendInicioEjercicioTermCierrePeriodoRamoField() As ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioTermCierrePeriodoDesglosePendInicioEjercicioTermCierrePeriodoRamo

    Private totalNumSiniestrosConPagoField As Decimal

    Private totalNumSiniestrosSinPagoField As Decimal

    Private totalImportePagadoComienzoField As Decimal

    Private totalProvisionComienzoField As Decimal

    Private totalImportePagadoPeriodoField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("DesglosePendInicioEjercicioTermCierrePeriodoRamo")>
    Public Property DesglosePendInicioEjercicioTermCierrePeriodoRamo() As ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioTermCierrePeriodoDesglosePendInicioEjercicioTermCierrePeriodoRamo()
        Get
            Return Me.desglosePendInicioEjercicioTermCierrePeriodoRamoField
        End Get
        Set
            Me.desglosePendInicioEjercicioTermCierrePeriodoRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalNumSiniestrosConPago() As Decimal
        Get
            Return Me.totalNumSiniestrosConPagoField
        End Get
        Set
            Me.totalNumSiniestrosConPagoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalNumSiniestrosSinPago() As Decimal
        Get
            Return Me.totalNumSiniestrosSinPagoField
        End Get
        Set
            Me.totalNumSiniestrosSinPagoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalImportePagadoComienzo() As Decimal
        Get
            Return Me.totalImportePagadoComienzoField
        End Get
        Set
            Me.totalImportePagadoComienzoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProvisionComienzo() As Decimal
        Get
            Return Me.totalProvisionComienzoField
        End Get
        Set
            Me.totalProvisionComienzoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalImportePagadoPeriodo() As Decimal
        Get
            Return Me.totalImportePagadoPeriodoField
        End Get
        Set
            Me.totalImportePagadoPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSiniestrosPendInicioEjercicioTermCierrePeriodoDesglosePendInicioEjercicioTermCierrePeriodoRamo

    Private numSiniestrosConPagoField As Decimal

    Private numSiniestrosSinPagoField As Decimal

    Private importePagadoComienzoField As Decimal

    Private provisionComienzoField As Decimal

    Private importePagadoPeriodoField As Decimal

    Private idField As TipoRamo

    '''<remarks/>
    Public Property NumSiniestrosConPago() As Decimal
        Get
            Return Me.numSiniestrosConPagoField
        End Get
        Set
            Me.numSiniestrosConPagoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosSinPago() As Decimal
        Get
            Return Me.numSiniestrosSinPagoField
        End Get
        Set
            Me.numSiniestrosSinPagoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ImportePagadoComienzo() As Decimal
        Get
            Return Me.importePagadoComienzoField
        End Get
        Set
            Me.importePagadoComienzoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionComienzo() As Decimal
        Get
            Return Me.provisionComienzoField
        End Get
        Set
            Me.provisionComienzoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ImportePagadoPeriodo() As Decimal
        Get
            Return Me.importePagadoPeriodoField
        End Get
        Set
            Me.importePagadoPeriodoField = Value
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

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoPendientesCierrePeriodo

    Private desgloseOcurridosPeriodoPendientesCierrePeriodoRamoField() As ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoPendientesCierrePeriodoDesgloseOcurridosPeriodoPendientesCierrePeriodoRamo

    Private totalNumSiniestrosField As Decimal

    Private totalImportePagadoField As Decimal

    Private totalProvisionCierreField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("DesgloseOcurridosPeriodoPendientesCierrePeriodoRamo")>
    Public Property DesgloseOcurridosPeriodoPendientesCierrePeriodoRamo() As ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoPendientesCierrePeriodoDesgloseOcurridosPeriodoPendientesCierrePeriodoRamo()
        Get
            Return Me.desgloseOcurridosPeriodoPendientesCierrePeriodoRamoField
        End Get
        Set
            Me.desgloseOcurridosPeriodoPendientesCierrePeriodoRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalNumSiniestros() As Decimal
        Get
            Return Me.totalNumSiniestrosField
        End Get
        Set
            Me.totalNumSiniestrosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalImportePagado() As Decimal
        Get
            Return Me.totalImportePagadoField
        End Get
        Set
            Me.totalImportePagadoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProvisionCierre() As Decimal
        Get
            Return Me.totalProvisionCierreField
        End Get
        Set
            Me.totalProvisionCierreField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoPendientesCierrePeriodoDesgloseOcurridosPeriodoPendientesCierrePeriodoRamo

    Private numSiniestrosField As Decimal

    Private importePagadoField As Decimal

    Private provisionCierreField As Decimal

    Private idField As TipoRamo

    '''<remarks/>
    Public Property NumSiniestros() As Decimal
        Get
            Return Me.numSiniestrosField
        End Get
        Set
            Me.numSiniestrosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ImportePagado() As Decimal
        Get
            Return Me.importePagadoField
        End Get
        Set
            Me.importePagadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionCierre() As Decimal
        Get
            Return Me.provisionCierreField
        End Get
        Set
            Me.provisionCierreField = Value
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

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoTerminadosPeriodo

    Private desgloseOcurridosPeriodoTerminadosPeriodoRamoField() As ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoTerminadosPeriodoDesgloseOcurridosPeriodoTerminadosPeriodoRamo

    Private totalNumSiniestrosConPagoField As Decimal

    Private totalNumSiniestrosSinPagoField As Decimal

    Private totalImportePagadoField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("DesgloseOcurridosPeriodoTerminadosPeriodoRamo")>
    Public Property DesgloseOcurridosPeriodoTerminadosPeriodoRamo() As ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoTerminadosPeriodoDesgloseOcurridosPeriodoTerminadosPeriodoRamo()
        Get
            Return Me.desgloseOcurridosPeriodoTerminadosPeriodoRamoField
        End Get
        Set
            Me.desgloseOcurridosPeriodoTerminadosPeriodoRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalNumSiniestrosConPago() As Decimal
        Get
            Return Me.totalNumSiniestrosConPagoField
        End Get
        Set
            Me.totalNumSiniestrosConPagoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalNumSiniestrosSinPago() As Decimal
        Get
            Return Me.totalNumSiniestrosSinPagoField
        End Get
        Set
            Me.totalNumSiniestrosSinPagoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalImportePagado() As Decimal
        Get
            Return Me.totalImportePagadoField
        End Get
        Set
            Me.totalImportePagadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSiniestrosOcurridosPeriodoTerminadosPeriodoDesgloseOcurridosPeriodoTerminadosPeriodoRamo

    Private numSiniestrosConPagoField As Decimal

    Private numSiniestrosSinPagoField As Decimal

    Private importePagadoField As Decimal

    Private idField As TipoRamo

    '''<remarks/>
    Public Property NumSiniestrosConPago() As Decimal
        Get
            Return Me.numSiniestrosConPagoField
        End Get
        Set
            Me.numSiniestrosConPagoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosSinPago() As Decimal
        Get
            Return Me.numSiniestrosSinPagoField
        End Get
        Set
            Me.numSiniestrosSinPagoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ImportePagado() As Decimal
        Get
            Return Me.importePagadoField
        End Get
        Set
            Me.importePagadoField = Value
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

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSiniestrosPendientesDeclaracion

    Private desglosePendientesDeclaracionRamoField() As ModeloRunOffDatosModeloSiniestrosPendientesDeclaracionDesglosePendientesDeclaracionRamo

    Private totalProvisionOYNRComienzoPeriodoField As Decimal

    Private totalProvisionOYNRResidualCierreField As Decimal

    Private totalProvisionOYNRCierrePeriodoField As Decimal

    Private totalPendCierreNumSiniestrosField As Decimal

    Private totalPendCierreImportePagadoPeriodoField As Decimal

    Private totalPendCierreProvisionCierreField As Decimal

    Private totalTermPeriodoNumSiniestrosConPagoField As Decimal

    Private totalTermPeriodoNumSiniestrosSinPagoField As Decimal

    Private totalTermPeriodoImportePagadoField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("DesglosePendientesDeclaracionRamo")>
    Public Property DesglosePendientesDeclaracionRamo() As ModeloRunOffDatosModeloSiniestrosPendientesDeclaracionDesglosePendientesDeclaracionRamo()
        Get
            Return Me.desglosePendientesDeclaracionRamoField
        End Get
        Set
            Me.desglosePendientesDeclaracionRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProvisionOYNRComienzoPeriodo() As Decimal
        Get
            Return Me.totalProvisionOYNRComienzoPeriodoField
        End Get
        Set
            Me.totalProvisionOYNRComienzoPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProvisionOYNRResidualCierre() As Decimal
        Get
            Return Me.totalProvisionOYNRResidualCierreField
        End Get
        Set
            Me.totalProvisionOYNRResidualCierreField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProvisionOYNRCierrePeriodo() As Decimal
        Get
            Return Me.totalProvisionOYNRCierrePeriodoField
        End Get
        Set
            Me.totalProvisionOYNRCierrePeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPendCierreNumSiniestros() As Decimal
        Get
            Return Me.totalPendCierreNumSiniestrosField
        End Get
        Set
            Me.totalPendCierreNumSiniestrosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPendCierreImportePagadoPeriodo() As Decimal
        Get
            Return Me.totalPendCierreImportePagadoPeriodoField
        End Get
        Set
            Me.totalPendCierreImportePagadoPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPendCierreProvisionCierre() As Decimal
        Get
            Return Me.totalPendCierreProvisionCierreField
        End Get
        Set
            Me.totalPendCierreProvisionCierreField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalTermPeriodoNumSiniestrosConPago() As Decimal
        Get
            Return Me.totalTermPeriodoNumSiniestrosConPagoField
        End Get
        Set
            Me.totalTermPeriodoNumSiniestrosConPagoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalTermPeriodoNumSiniestrosSinPago() As Decimal
        Get
            Return Me.totalTermPeriodoNumSiniestrosSinPagoField
        End Get
        Set
            Me.totalTermPeriodoNumSiniestrosSinPagoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalTermPeriodoImportePagado() As Decimal
        Get
            Return Me.totalTermPeriodoImportePagadoField
        End Get
        Set
            Me.totalTermPeriodoImportePagadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSiniestrosPendientesDeclaracionDesglosePendientesDeclaracionRamo

    Private provisionOYNRComienzoEjercicioField As Decimal

    Private provisionOYNRResidualCierreField As Decimal

    Private provisionOYNRCierrePeriodoField As Decimal

    Private pendCierreNumSiniestrosField As Decimal

    Private pendCierreImportePagadoPeriodoField As Decimal

    Private pendCierreProvisionCierreField As Decimal

    Private termPeriodoNumSiniestrosConPagoField As Decimal

    Private termPeriodoNumSiniestrosSinPagoField As Decimal

    Private termPeriodoImportePagadoField As Decimal

    Private idField As TipoRamo

    '''<remarks/>
    Public Property ProvisionOYNRComienzoEjercicio() As Decimal
        Get
            Return Me.provisionOYNRComienzoEjercicioField
        End Get
        Set
            Me.provisionOYNRComienzoEjercicioField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionOYNRResidualCierre() As Decimal
        Get
            Return Me.provisionOYNRResidualCierreField
        End Get
        Set
            Me.provisionOYNRResidualCierreField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionOYNRCierrePeriodo() As Decimal
        Get
            Return Me.provisionOYNRCierrePeriodoField
        End Get
        Set
            Me.provisionOYNRCierrePeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PendCierreNumSiniestros() As Decimal
        Get
            Return Me.pendCierreNumSiniestrosField
        End Get
        Set
            Me.pendCierreNumSiniestrosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PendCierreImportePagadoPeriodo() As Decimal
        Get
            Return Me.pendCierreImportePagadoPeriodoField
        End Get
        Set
            Me.pendCierreImportePagadoPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PendCierreProvisionCierre() As Decimal
        Get
            Return Me.pendCierreProvisionCierreField
        End Get
        Set
            Me.pendCierreProvisionCierreField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property TermPeriodoNumSiniestrosConPago() As Decimal
        Get
            Return Me.termPeriodoNumSiniestrosConPagoField
        End Get
        Set
            Me.termPeriodoNumSiniestrosConPagoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property TermPeriodoNumSiniestrosSinPago() As Decimal
        Get
            Return Me.termPeriodoNumSiniestrosSinPagoField
        End Get
        Set
            Me.termPeriodoNumSiniestrosSinPagoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property TermPeriodoImportePagado() As Decimal
        Get
            Return Me.termPeriodoImportePagadoField
        End Get
        Set
            Me.termPeriodoImportePagadoField = Value
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

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloPrimasYProvisionPrimasNoDevengadas

    Private desglosePrimasYProvisionPrimasNoDevengadasRamoField() As ModeloRunOffDatosModeloPrimasYProvisionPrimasNoDevengadasDesglosePrimasYProvisionPrimasNoDevengadasRamo

    Private totalPrimasEmitidasField As Decimal

    Private totalPrimasAnuladasField As Decimal

    Private totalPrimasNoRenovadasField As Decimal

    Private totalProvisionComienzoField As Decimal

    Private totalProvisionCierreField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("DesglosePrimasYProvisionPrimasNoDevengadasRamo")>
    Public Property DesglosePrimasYProvisionPrimasNoDevengadasRamo() As ModeloRunOffDatosModeloPrimasYProvisionPrimasNoDevengadasDesglosePrimasYProvisionPrimasNoDevengadasRamo()
        Get
            Return Me.desglosePrimasYProvisionPrimasNoDevengadasRamoField
        End Get
        Set
            Me.desglosePrimasYProvisionPrimasNoDevengadasRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPrimasEmitidas() As Decimal
        Get
            Return Me.totalPrimasEmitidasField
        End Get
        Set
            Me.totalPrimasEmitidasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPrimasAnuladas() As Decimal
        Get
            Return Me.totalPrimasAnuladasField
        End Get
        Set
            Me.totalPrimasAnuladasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPrimasNoRenovadas() As Decimal
        Get
            Return Me.totalPrimasNoRenovadasField
        End Get
        Set
            Me.totalPrimasNoRenovadasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProvisionComienzo() As Decimal
        Get
            Return Me.totalProvisionComienzoField
        End Get
        Set
            Me.totalProvisionComienzoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProvisionCierre() As Decimal
        Get
            Return Me.totalProvisionCierreField
        End Get
        Set
            Me.totalProvisionCierreField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloPrimasYProvisionPrimasNoDevengadasDesglosePrimasYProvisionPrimasNoDevengadasRamo

    Private primasEmitidasField As Decimal

    Private primasAnuladasField As Decimal

    Private primasNoRenovadasField As Decimal

    Private provisionComienzoField As Decimal

    Private provisionCierreField As Decimal

    Private idField As TipoRamo

    '''<remarks/>
    Public Property PrimasEmitidas() As Decimal
        Get
            Return Me.primasEmitidasField
        End Get
        Set
            Me.primasEmitidasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasAnuladas() As Decimal
        Get
            Return Me.primasAnuladasField
        End Get
        Set
            Me.primasAnuladasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasNoRenovadas() As Decimal
        Get
            Return Me.primasNoRenovadasField
        End Get
        Set
            Me.primasNoRenovadasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionComienzo() As Decimal
        Get
            Return Me.provisionComienzoField
        End Get
        Set
            Me.provisionComienzoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionCierre() As Decimal
        Get
            Return Me.provisionCierreField
        End Get
        Set
            Me.provisionCierreField = Value
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

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloPolizasPeriodo

    Private desglosePolizasPeriodoRamoField() As ModeloRunOffDatosModeloPolizasPeriodoDesglosePolizasPeriodoRamo

    Private totalExistentesInicioField As Decimal

    Private totalEmitidasPeriodoField As Decimal

    Private totalAnuladasPeriodoField As Decimal

    Private totalNoRenovadasPeriodoField As Decimal

    Private totalExistentesCierreField As Decimal

    Private totalVencidasPeriodoField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("DesglosePolizasPeriodoRamo")>
    Public Property DesglosePolizasPeriodoRamo() As ModeloRunOffDatosModeloPolizasPeriodoDesglosePolizasPeriodoRamo()
        Get
            Return Me.desglosePolizasPeriodoRamoField
        End Get
        Set
            Me.desglosePolizasPeriodoRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalExistentesInicio() As Decimal
        Get
            Return Me.totalExistentesInicioField
        End Get
        Set
            Me.totalExistentesInicioField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalEmitidasPeriodo() As Decimal
        Get
            Return Me.totalEmitidasPeriodoField
        End Get
        Set
            Me.totalEmitidasPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAnuladasPeriodo() As Decimal
        Get
            Return Me.totalAnuladasPeriodoField
        End Get
        Set
            Me.totalAnuladasPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalNoRenovadasPeriodo() As Decimal
        Get
            Return Me.totalNoRenovadasPeriodoField
        End Get
        Set
            Me.totalNoRenovadasPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalExistentesCierre() As Decimal
        Get
            Return Me.totalExistentesCierreField
        End Get
        Set
            Me.totalExistentesCierreField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalVencidasPeriodo() As Decimal
        Get
            Return Me.totalVencidasPeriodoField
        End Get
        Set
            Me.totalVencidasPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloPolizasPeriodoDesglosePolizasPeriodoRamo

    Private existentesInicioField As Decimal

    Private emitidasPeriodoField As Decimal

    Private anuladasPeriodoField As Decimal

    Private noRenovadasPeriodoField As Decimal

    Private existentesCierreField As Decimal

    Private vencidasPeriodoField As Decimal

    Private idField As TipoRamo

    '''<remarks/>
    Public Property ExistentesInicio() As Decimal
        Get
            Return Me.existentesInicioField
        End Get
        Set
            Me.existentesInicioField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EmitidasPeriodo() As Decimal
        Get
            Return Me.emitidasPeriodoField
        End Get
        Set
            Me.emitidasPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AnuladasPeriodo() As Decimal
        Get
            Return Me.anuladasPeriodoField
        End Get
        Set
            Me.anuladasPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NoRenovadasPeriodo() As Decimal
        Get
            Return Me.noRenovadasPeriodoField
        End Get
        Set
            Me.noRenovadasPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ExistentesCierre() As Decimal
        Get
            Return Me.existentesCierreField
        End Get
        Set
            Me.existentesCierreField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VencidasPeriodo() As Decimal
        Get
            Return Me.vencidasPeriodoField
        End Get
        Set
            Me.vencidasPeriodoField = Value
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

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSuficiencia

    Private annoActualField As ModeloRunOffDatosModeloSuficienciaAnnoActual

    Private annoActualMenosUnoField As ModeloRunOffDatosModeloSuficienciaAnnoActualMenosUno

    Private annoActualMenosDosField As ModeloRunOffDatosModeloSuficienciaAnnoActualMenosDos

    Private annoActualMenosTresField As ModeloRunOffDatosModeloSuficienciaAnnoActualMenosTres

    Private annoActualMenosCuatroField As ModeloRunOffDatosModeloSuficienciaAnnoActualMenosCuatro

    Private annoActualMenosCincoField As ModeloRunOffDatosModeloSuficienciaAnnoActualMenosCinco

    '''<remarks/>
    Public Property AnnoActual() As ModeloRunOffDatosModeloSuficienciaAnnoActual
        Get
            Return Me.annoActualField
        End Get
        Set
            Me.annoActualField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AnnoActualMenosUno() As ModeloRunOffDatosModeloSuficienciaAnnoActualMenosUno
        Get
            Return Me.annoActualMenosUnoField
        End Get
        Set
            Me.annoActualMenosUnoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AnnoActualMenosDos() As ModeloRunOffDatosModeloSuficienciaAnnoActualMenosDos
        Get
            Return Me.annoActualMenosDosField
        End Get
        Set
            Me.annoActualMenosDosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AnnoActualMenosTres() As ModeloRunOffDatosModeloSuficienciaAnnoActualMenosTres
        Get
            Return Me.annoActualMenosTresField
        End Get
        Set
            Me.annoActualMenosTresField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AnnoActualMenosCuatro() As ModeloRunOffDatosModeloSuficienciaAnnoActualMenosCuatro
        Get
            Return Me.annoActualMenosCuatroField
        End Get
        Set
            Me.annoActualMenosCuatroField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AnnoActualMenosCinco() As ModeloRunOffDatosModeloSuficienciaAnnoActualMenosCinco
        Get
            Return Me.annoActualMenosCincoField
        End Get
        Set
            Me.annoActualMenosCincoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSuficienciaAnnoActual

    Private annoField As String

    Private importePagadoField As Decimal

    Private provisionFinalPeriodoField As Decimal

    Private recobrosEfectuadosField As Decimal

    Private numSiniestrosReportadosField As Decimal

    Private numSiniestrosReabiertosField As Decimal

    Private numSiniestrosPendientesField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="positiveInteger")>
    Public Property Anno() As String
        Get
            Return Me.annoField
        End Get
        Set
            Me.annoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ImportePagado() As Decimal
        Get
            Return Me.importePagadoField
        End Get
        Set
            Me.importePagadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionFinalPeriodo() As Decimal
        Get
            Return Me.provisionFinalPeriodoField
        End Get
        Set
            Me.provisionFinalPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property RecobrosEfectuados() As Decimal
        Get
            Return Me.recobrosEfectuadosField
        End Get
        Set
            Me.recobrosEfectuadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosReportados() As Decimal
        Get
            Return Me.numSiniestrosReportadosField
        End Get
        Set
            Me.numSiniestrosReportadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosReabiertos() As Decimal
        Get
            Return Me.numSiniestrosReabiertosField
        End Get
        Set
            Me.numSiniestrosReabiertosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosPendientes() As Decimal
        Get
            Return Me.numSiniestrosPendientesField
        End Get
        Set
            Me.numSiniestrosPendientesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSuficienciaAnnoActualMenosUno

    Private annoField As String

    Private importePagadoField As Decimal

    Private provisionFinalPeriodoField As Decimal

    Private recobrosEfectuadosField As Decimal

    Private numSiniestrosReportadosField As Decimal

    Private numSiniestrosReabiertosField As Decimal

    Private numSiniestrosPendientesField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="positiveInteger")>
    Public Property Anno() As String
        Get
            Return Me.annoField
        End Get
        Set
            Me.annoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ImportePagado() As Decimal
        Get
            Return Me.importePagadoField
        End Get
        Set
            Me.importePagadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionFinalPeriodo() As Decimal
        Get
            Return Me.provisionFinalPeriodoField
        End Get
        Set
            Me.provisionFinalPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property RecobrosEfectuados() As Decimal
        Get
            Return Me.recobrosEfectuadosField
        End Get
        Set
            Me.recobrosEfectuadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosReportados() As Decimal
        Get
            Return Me.numSiniestrosReportadosField
        End Get
        Set
            Me.numSiniestrosReportadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosReabiertos() As Decimal
        Get
            Return Me.numSiniestrosReabiertosField
        End Get
        Set
            Me.numSiniestrosReabiertosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosPendientes() As Decimal
        Get
            Return Me.numSiniestrosPendientesField
        End Get
        Set
            Me.numSiniestrosPendientesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSuficienciaAnnoActualMenosDos

    Private annoField As String

    Private importePagadoField As Decimal

    Private provisionFinalPeriodoField As Decimal

    Private recobrosEfectuadosField As Decimal

    Private numSiniestrosReportadosField As Decimal

    Private numSiniestrosReabiertosField As Decimal

    Private numSiniestrosPendientesField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="positiveInteger")>
    Public Property Anno() As String
        Get
            Return Me.annoField
        End Get
        Set
            Me.annoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ImportePagado() As Decimal
        Get
            Return Me.importePagadoField
        End Get
        Set
            Me.importePagadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionFinalPeriodo() As Decimal
        Get
            Return Me.provisionFinalPeriodoField
        End Get
        Set
            Me.provisionFinalPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property RecobrosEfectuados() As Decimal
        Get
            Return Me.recobrosEfectuadosField
        End Get
        Set
            Me.recobrosEfectuadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosReportados() As Decimal
        Get
            Return Me.numSiniestrosReportadosField
        End Get
        Set
            Me.numSiniestrosReportadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosReabiertos() As Decimal
        Get
            Return Me.numSiniestrosReabiertosField
        End Get
        Set
            Me.numSiniestrosReabiertosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosPendientes() As Decimal
        Get
            Return Me.numSiniestrosPendientesField
        End Get
        Set
            Me.numSiniestrosPendientesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSuficienciaAnnoActualMenosTres

    Private annoField As String

    Private importePagadoField As Decimal

    Private provisionFinalPeriodoField As Decimal

    Private recobrosEfectuadosField As Decimal

    Private numSiniestrosReportadosField As Decimal

    Private numSiniestrosReabiertosField As Decimal

    Private numSiniestrosPendientesField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="positiveInteger")>
    Public Property Anno() As String
        Get
            Return Me.annoField
        End Get
        Set
            Me.annoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ImportePagado() As Decimal
        Get
            Return Me.importePagadoField
        End Get
        Set
            Me.importePagadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionFinalPeriodo() As Decimal
        Get
            Return Me.provisionFinalPeriodoField
        End Get
        Set
            Me.provisionFinalPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property RecobrosEfectuados() As Decimal
        Get
            Return Me.recobrosEfectuadosField
        End Get
        Set
            Me.recobrosEfectuadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosReportados() As Decimal
        Get
            Return Me.numSiniestrosReportadosField
        End Get
        Set
            Me.numSiniestrosReportadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosReabiertos() As Decimal
        Get
            Return Me.numSiniestrosReabiertosField
        End Get
        Set
            Me.numSiniestrosReabiertosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosPendientes() As Decimal
        Get
            Return Me.numSiniestrosPendientesField
        End Get
        Set
            Me.numSiniestrosPendientesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSuficienciaAnnoActualMenosCuatro

    Private annoField As String

    Private importePagadoField As Decimal

    Private provisionFinalPeriodoField As Decimal

    Private recobrosEfectuadosField As Decimal

    Private numSiniestrosReportadosField As Decimal

    Private numSiniestrosReabiertosField As Decimal

    Private numSiniestrosPendientesField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="positiveInteger")>
    Public Property Anno() As String
        Get
            Return Me.annoField
        End Get
        Set
            Me.annoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ImportePagado() As Decimal
        Get
            Return Me.importePagadoField
        End Get
        Set
            Me.importePagadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionFinalPeriodo() As Decimal
        Get
            Return Me.provisionFinalPeriodoField
        End Get
        Set
            Me.provisionFinalPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property RecobrosEfectuados() As Decimal
        Get
            Return Me.recobrosEfectuadosField
        End Get
        Set
            Me.recobrosEfectuadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosReportados() As Decimal
        Get
            Return Me.numSiniestrosReportadosField
        End Get
        Set
            Me.numSiniestrosReportadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosReabiertos() As Decimal
        Get
            Return Me.numSiniestrosReabiertosField
        End Get
        Set
            Me.numSiniestrosReabiertosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosPendientes() As Decimal
        Get
            Return Me.numSiniestrosPendientesField
        End Get
        Set
            Me.numSiniestrosPendientesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloSuficienciaAnnoActualMenosCinco

    Private annoField As String

    Private importePagadoField As Decimal

    Private provisionFinalPeriodoField As Decimal

    Private recobrosEfectuadosField As Decimal

    Private numSiniestrosReportadosField As Decimal

    Private numSiniestrosReabiertosField As Decimal

    Private numSiniestrosPendientesField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="positiveInteger")>
    Public Property Anno() As String
        Get
            Return Me.annoField
        End Get
        Set
            Me.annoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ImportePagado() As Decimal
        Get
            Return Me.importePagadoField
        End Get
        Set
            Me.importePagadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionFinalPeriodo() As Decimal
        Get
            Return Me.provisionFinalPeriodoField
        End Get
        Set
            Me.provisionFinalPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property RecobrosEfectuados() As Decimal
        Get
            Return Me.recobrosEfectuadosField
        End Get
        Set
            Me.recobrosEfectuadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosReportados() As Decimal
        Get
            Return Me.numSiniestrosReportadosField
        End Get
        Set
            Me.numSiniestrosReportadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosReabiertos() As Decimal
        Get
            Return Me.numSiniestrosReabiertosField
        End Get
        Set
            Me.numSiniestrosReabiertosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NumSiniestrosPendientes() As Decimal
        Get
            Return Me.numSiniestrosPendientesField
        End Get
        Set
            Me.numSiniestrosPendientesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloModeloEstadistico

    Private desgloseModeloEstadisticoPorRamoField() As ModeloRunOffDatosModeloModeloEstadisticoDesgloseModeloEstadisticoPorRamo

    Private totalAjusteModeloEstadisticoField As Decimal

    Private totalProvisionSiniestrosReportadosAlCierreField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("DesgloseModeloEstadisticoPorRamo")>
    Public Property DesgloseModeloEstadisticoPorRamo() As ModeloRunOffDatosModeloModeloEstadisticoDesgloseModeloEstadisticoPorRamo()
        Get
            Return Me.desgloseModeloEstadisticoPorRamoField
        End Get
        Set
            Me.desgloseModeloEstadisticoPorRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAjusteModeloEstadistico() As Decimal
        Get
            Return Me.totalAjusteModeloEstadisticoField
        End Get
        Set
            Me.totalAjusteModeloEstadisticoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProvisionSiniestrosReportadosAlCierre() As Decimal
        Get
            Return Me.totalProvisionSiniestrosReportadosAlCierreField
        End Get
        Set
            Me.totalProvisionSiniestrosReportadosAlCierreField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloRunOffDatosModeloModeloEstadisticoDesgloseModeloEstadisticoPorRamo

    Private ajusteModeloEstadisticoField As Decimal

    Private provisionSiniestrosReportadosAlCierreField As Decimal

    Private idField As TipoRamo

    '''<remarks/>
    Public Property AjusteModeloEstadistico() As Decimal
        Get
            Return Me.ajusteModeloEstadisticoField
        End Get
        Set
            Me.ajusteModeloEstadisticoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionSiniestrosReportadosAlCierre() As Decimal
        Get
            Return Me.provisionSiniestrosReportadosAlCierreField
        End Get
        Set
            Me.provisionSiniestrosReportadosAlCierreField = Value
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