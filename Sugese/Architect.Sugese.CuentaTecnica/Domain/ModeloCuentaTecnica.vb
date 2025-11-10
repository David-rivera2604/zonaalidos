Imports Architect.Sugese.Domain

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class ModeloCuentaTecnica

    Private encabezadoField As ModeloCuentaTecnicaEncabezado

    Private datosField As ModeloCuentaTecnicaDatos

    '''<remarks/>
    Public Property Encabezado() As ModeloCuentaTecnicaEncabezado
        Get
            Return Me.encabezadoField
        End Get
        Set
            Me.encabezadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Datos() As ModeloCuentaTecnicaDatos
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
Partial Public Class ModeloCuentaTecnicaEncabezado

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
Partial Public Class ModeloCuentaTecnicaDatos

    Private modeloField As ModeloCuentaTecnicaDatosModelo

    '''<remarks/>
    Public Property Modelo() As ModeloCuentaTecnicaDatosModelo
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
Partial Public Class ModeloCuentaTecnicaDatosModelo

    Private utilidadPerdidaNetaAntesImpuestosParticipacionesField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipaciones

    Private entidadFuenteField As String

    '''<remarks/>
    Public Property UtilidadPerdidaNetaAntesImpuestosParticipaciones() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipaciones
        Get
            Return Me.utilidadPerdidaNetaAntesImpuestosParticipacionesField
        End Get
        Set
            Me.utilidadPerdidaNetaAntesImpuestosParticipacionesField = Value
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
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipaciones

    Private resultadoCuentaTecnicoFinancieraField() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera

    Private resultadoCuentaNoTecnicaField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaNoTecnica

    Private totalUtilidadPerdidaNetaAntesImpuestosParticipacionesField As Decimal

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("ResultadoCuentaTecnicoFinanciera")>
    Public Property ResultadoCuentaTecnicoFinanciera() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera()
        Get
            Return Me.resultadoCuentaTecnicoFinancieraField
        End Get
        Set
            Me.resultadoCuentaTecnicoFinancieraField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadoCuentaNoTecnica() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaNoTecnica
        Get
            Return Me.resultadoCuentaNoTecnicaField
        End Get
        Set
            Me.resultadoCuentaNoTecnicaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalUtilidadPerdidaNetaAntesImpuestosParticipaciones() As Decimal
        Get
            Return Me.totalUtilidadPerdidaNetaAntesImpuestosParticipacionesField
        End Get
        Set
            Me.totalUtilidadPerdidaNetaAntesImpuestosParticipacionesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinanciera

    Private resultadoCuentaTecnicaField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnica

    Private resultadoCuentaFinancieraField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinanciera

    Private lineasField() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLinea

    Private idRamoField As TipoRamo

    Private totalCuentaTecnicoFinancieraField As Decimal

    '''<remarks/>
    Public Property ResultadoCuentaTecnica() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnica
        Get
            Return Me.resultadoCuentaTecnicaField
        End Get
        Set
            Me.resultadoCuentaTecnicaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadoCuentaFinanciera() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinanciera
        Get
            Return Me.resultadoCuentaFinancieraField
        End Get
        Set
            Me.resultadoCuentaFinancieraField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlArrayItemAttribute("Linea", IsNullable:=False)>
    Public Property Lineas() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLinea()
        Get
            Return Me.lineasField
        End Get
        Set
            Me.lineasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property idRamo() As TipoRamo
        Get
            Return Me.idRamoField
        End Get
        Set
            Me.idRamoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalCuentaTecnicoFinanciera() As Decimal
        Get
            Return Me.totalCuentaTecnicoFinancieraField
        End Get
        Set
            Me.totalCuentaTecnicoFinancieraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnica

    Private primasImputadasNetasReaseguroField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguro

    Private siniestralidadNetaReaseguroField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguro

    Private participacionBeneficiosExtornosField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaParticipacionBeneficiosExtornos

    Private variacionOtrasProvisionesTecnicasNetasReaseguroField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguro

    Private gastosExplotacionNetosField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaGastosExplotacionNetos

    Private otrosIngresosTecnicosField As Decimal

    Private otrosGastosTecnicosField As Decimal

    Private totalCuentaTecnicaField As Decimal

    '''<remarks/>
    Public Property PrimasImputadasNetasReaseguro() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguro
        Get
            Return Me.primasImputadasNetasReaseguroField
        End Get
        Set
            Me.primasImputadasNetasReaseguroField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SiniestralidadNetaReaseguro() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguro
        Get
            Return Me.siniestralidadNetaReaseguroField
        End Get
        Set
            Me.siniestralidadNetaReaseguroField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ParticipacionBeneficiosExtornos() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaParticipacionBeneficiosExtornos
        Get
            Return Me.participacionBeneficiosExtornosField
        End Get
        Set
            Me.participacionBeneficiosExtornosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionOtrasProvisionesTecnicasNetasReaseguro() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguro
        Get
            Return Me.variacionOtrasProvisionesTecnicasNetasReaseguroField
        End Get
        Set
            Me.variacionOtrasProvisionesTecnicasNetasReaseguroField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosExplotacionNetos() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaGastosExplotacionNetos
        Get
            Return Me.gastosExplotacionNetosField
        End Get
        Set
            Me.gastosExplotacionNetosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosIngresosTecnicos() As Decimal
        Get
            Return Me.otrosIngresosTecnicosField
        End Get
        Set
            Me.otrosIngresosTecnicosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosGastosTecnicos() As Decimal
        Get
            Return Me.otrosGastosTecnicosField
        End Get
        Set
            Me.otrosGastosTecnicosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalCuentaTecnica() As Decimal
        Get
            Return Me.totalCuentaTecnicaField
        End Get
        Set
            Me.totalCuentaTecnicaField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguro

    Private ingresoPrimasField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimas

    Private primasReaseguroCedidoRetrocedidoField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroPrimasReaseguroCedidoRetrocedido

    Private variacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas

    Private variacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedidoField As Decimal

    Private totalPrimasImputadasNetasReaseguroField As Decimal

    '''<remarks/>
    Public Property IngresoPrimas() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimas
        Get
            Return Me.ingresoPrimasField
        End Get
        Set
            Me.ingresoPrimasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasReaseguroCedidoRetrocedido() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroPrimasReaseguroCedidoRetrocedido
        Get
            Return Me.primasReaseguroCedidoRetrocedidoField
        End Get
        Set
            Me.primasReaseguroCedidoRetrocedidoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas
        Get
            Return Me.variacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasField
        End Get
        Set
            Me.variacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedido() As Decimal
        Get
            Return Me.variacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedidoField
        End Get
        Set
            Me.variacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedidoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPrimasImputadasNetasReaseguro() As Decimal
        Get
            Return Me.totalPrimasImputadasNetasReaseguroField
        End Get
        Set
            Me.totalPrimasImputadasNetasReaseguroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimas

    Private desgloseIngresoPrimasField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimas

    Private totalIngresoPrimasField As Decimal

    '''<remarks/>
    Public Property DesgloseIngresoPrimas() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimas
        Get
            Return Me.desgloseIngresoPrimasField
        End Get
        Set
            Me.desgloseIngresoPrimasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalIngresoPrimas() As Decimal
        Get
            Return Me.totalIngresoPrimasField
        End Get
        Set
            Me.totalIngresoPrimasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimas

    Private seguroDirectoField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimasSeguroDirecto

    Private reaseguroAceptadoField As Decimal

    Private variacionEstimacionDeterioroPrimasVencidasField As Decimal

    '''<remarks/>
    Public Property SeguroDirecto() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimasSeguroDirecto
        Get
            Return Me.seguroDirectoField
        End Get
        Set
            Me.seguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroAceptado() As Decimal
        Get
            Return Me.reaseguroAceptadoField
        End Get
        Set
            Me.reaseguroAceptadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionEstimacionDeterioroPrimasVencidas() As Decimal
        Get
            Return Me.variacionEstimacionDeterioroPrimasVencidasField
        End Get
        Set
            Me.variacionEstimacionDeterioroPrimasVencidasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimasSeguroDirecto

    Private desgloseSeguroDirectoField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimasSeguroDirectoDesgloseSeguroDirecto

    Private totalSeguroDirectoField As Decimal

    '''<remarks/>
    Public Property DesgloseSeguroDirecto() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimasSeguroDirectoDesgloseSeguroDirecto
        Get
            Return Me.desgloseSeguroDirectoField
        End Get
        Set
            Me.desgloseSeguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSeguroDirecto() As Decimal
        Get
            Return Me.totalSeguroDirectoField
        End Get
        Set
            Me.totalSeguroDirectoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroIngresoPrimasDesgloseIngresoPrimasSeguroDirectoDesgloseSeguroDirecto

    Private primasEmitidasField As Decimal

    Private primasAnuladasExtornadasPeriodoField As Decimal

    Private primasAnuladasExtornadasPeriodosAnterioresField As Decimal

    Private variacionPrimasPolizasFlotantesField As Decimal

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
    Public Property PrimasAnuladasExtornadasPeriodo() As Decimal
        Get
            Return Me.primasAnuladasExtornadasPeriodoField
        End Get
        Set
            Me.primasAnuladasExtornadasPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasAnuladasExtornadasPeriodosAnteriores() As Decimal
        Get
            Return Me.primasAnuladasExtornadasPeriodosAnterioresField
        End Get
        Set
            Me.primasAnuladasExtornadasPeriodosAnterioresField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionPrimasPolizasFlotantes() As Decimal
        Get
            Return Me.variacionPrimasPolizasFlotantesField
        End Get
        Set
            Me.variacionPrimasPolizasFlotantesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroPrimasReaseguroCedidoRetrocedido

    Private desglosePrimasReaseguroCedidoRetrocedidoField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroPrimasReaseguroCedidoRetrocedidoDesglosePrimasReaseguroCedidoRetrocedido

    Private totalPrimasReaseguroCedidoRetrocedidoField As Decimal

    '''<remarks/>
    Public Property DesglosePrimasReaseguroCedidoRetrocedido() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroPrimasReaseguroCedidoRetrocedidoDesglosePrimasReaseguroCedidoRetrocedido
        Get
            Return Me.desglosePrimasReaseguroCedidoRetrocedidoField
        End Get
        Set
            Me.desglosePrimasReaseguroCedidoRetrocedidoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPrimasReaseguroCedidoRetrocedido() As Decimal
        Get
            Return Me.totalPrimasReaseguroCedidoRetrocedidoField
        End Get
        Set
            Me.totalPrimasReaseguroCedidoRetrocedidoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroPrimasReaseguroCedidoRetrocedidoDesglosePrimasReaseguroCedidoRetrocedido

    Private primasCedidasReaseguroProporcionalField As Decimal

    Private primasPagadasReaseguroNoProporcionalField As Decimal

    '''<remarks/>
    Public Property PrimasCedidasReaseguroProporcional() As Decimal
        Get
            Return Me.primasCedidasReaseguroProporcionalField
        End Get
        Set
            Me.primasCedidasReaseguroProporcionalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasPagadasReaseguroNoProporcional() As Decimal
        Get
            Return Me.primasPagadasReaseguroNoProporcionalField
        End Get
        Set
            Me.primasPagadasReaseguroNoProporcionalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas

    Private desgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasDesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas

    Private totalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasField As Decimal

    '''<remarks/>
    Public Property DesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasDesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas
        Get
            Return Me.desgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasField
        End Get
        Set
            Me.desgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas() As Decimal
        Get
            Return Me.totalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasField
        End Get
        Set
            Me.totalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaPrimasImputadasNetasReaseguroVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasDesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas

    Private seguroDirectoField As Decimal

    Private reaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property SeguroDirecto() As Decimal
        Get
            Return Me.seguroDirectoField
        End Get
        Set
            Me.seguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroAceptado() As Decimal
        Get
            Return Me.reaseguroAceptadoField
        End Get
        Set
            Me.reaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguro

    Private siniestrosPagadosField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroSiniestrosPagados

    Private siniestrosGastosRecuperadosPorReaseguroCedidoRetrocedidoField As Decimal

    Private variacionProvisionParaSiniestrosField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroVariacionProvisionParaSiniestros

    Private variacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedidoField As Decimal

    Private gastosImputablesSiniestrosField As Decimal

    Private totalSiniestralidadNetaReaseguroField As Decimal

    '''<remarks/>
    Public Property SiniestrosPagados() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroSiniestrosPagados
        Get
            Return Me.siniestrosPagadosField
        End Get
        Set
            Me.siniestrosPagadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SiniestrosGastosRecuperadosPorReaseguroCedidoRetrocedido() As Decimal
        Get
            Return Me.siniestrosGastosRecuperadosPorReaseguroCedidoRetrocedidoField
        End Get
        Set
            Me.siniestrosGastosRecuperadosPorReaseguroCedidoRetrocedidoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionProvisionParaSiniestros() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroVariacionProvisionParaSiniestros
        Get
            Return Me.variacionProvisionParaSiniestrosField
        End Get
        Set
            Me.variacionProvisionParaSiniestrosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedido() As Decimal
        Get
            Return Me.variacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedidoField
        End Get
        Set
            Me.variacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedidoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosImputablesSiniestros() As Decimal
        Get
            Return Me.gastosImputablesSiniestrosField
        End Get
        Set
            Me.gastosImputablesSiniestrosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSiniestralidadNetaReaseguro() As Decimal
        Get
            Return Me.totalSiniestralidadNetaReaseguroField
        End Get
        Set
            Me.totalSiniestralidadNetaReaseguroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroSiniestrosPagados

    Private desgloseSiniestrosPagadosField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroSiniestrosPagadosDesgloseSiniestrosPagados

    Private totalSiniestrosPagadosField As Decimal

    '''<remarks/>
    Public Property DesgloseSiniestrosPagados() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroSiniestrosPagadosDesgloseSiniestrosPagados
        Get
            Return Me.desgloseSiniestrosPagadosField
        End Get
        Set
            Me.desgloseSiniestrosPagadosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSiniestrosPagados() As Decimal
        Get
            Return Me.totalSiniestrosPagadosField
        End Get
        Set
            Me.totalSiniestrosPagadosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroSiniestrosPagadosDesgloseSiniestrosPagados

    Private seguroDirectoField As Decimal

    Private reaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property SeguroDirecto() As Decimal
        Get
            Return Me.seguroDirectoField
        End Get
        Set
            Me.seguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroAceptado() As Decimal
        Get
            Return Me.reaseguroAceptadoField
        End Get
        Set
            Me.reaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroVariacionProvisionParaSiniestros

    Private desgloseVariacionProvisionParaSiniestrosField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroVariacionProvisionParaSiniestrosDesgloseVariacionProvisionParaSiniestros

    Private totalVariacionProvisionParaSiniestrosField As Decimal

    '''<remarks/>
    Public Property DesgloseVariacionProvisionParaSiniestros() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroVariacionProvisionParaSiniestrosDesgloseVariacionProvisionParaSiniestros
        Get
            Return Me.desgloseVariacionProvisionParaSiniestrosField
        End Get
        Set
            Me.desgloseVariacionProvisionParaSiniestrosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalVariacionProvisionParaSiniestros() As Decimal
        Get
            Return Me.totalVariacionProvisionParaSiniestrosField
        End Get
        Set
            Me.totalVariacionProvisionParaSiniestrosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaSiniestralidadNetaReaseguroVariacionProvisionParaSiniestrosDesgloseVariacionProvisionParaSiniestros

    Private seguroDirectoField As Decimal

    Private reaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property SeguroDirecto() As Decimal
        Get
            Return Me.seguroDirectoField
        End Get
        Set
            Me.seguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroAceptado() As Decimal
        Get
            Return Me.reaseguroAceptadoField
        End Get
        Set
            Me.reaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaParticipacionBeneficiosExtornos

    Private desgloseParticipacionBeneficiosExtornosField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaParticipacionBeneficiosExtornosDesgloseParticipacionBeneficiosExtornos

    Private totalParticipacionBeneficiosExtornosField As Decimal

    '''<remarks/>
    Public Property DesgloseParticipacionBeneficiosExtornos() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaParticipacionBeneficiosExtornosDesgloseParticipacionBeneficiosExtornos
        Get
            Return Me.desgloseParticipacionBeneficiosExtornosField
        End Get
        Set
            Me.desgloseParticipacionBeneficiosExtornosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalParticipacionBeneficiosExtornos() As Decimal
        Get
            Return Me.totalParticipacionBeneficiosExtornosField
        End Get
        Set
            Me.totalParticipacionBeneficiosExtornosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaParticipacionBeneficiosExtornosDesgloseParticipacionBeneficiosExtornos

    Private prestacionesGastosParticipacionBeneficiosExtornosField As Decimal

    Private variacionProvisionParticipacionBeneficiosExtornosField As Decimal

    '''<remarks/>
    Public Property PrestacionesGastosParticipacionBeneficiosExtornos() As Decimal
        Get
            Return Me.prestacionesGastosParticipacionBeneficiosExtornosField
        End Get
        Set
            Me.prestacionesGastosParticipacionBeneficiosExtornosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionProvisionParticipacionBeneficiosExtornos() As Decimal
        Get
            Return Me.variacionProvisionParticipacionBeneficiosExtornosField
        End Get
        Set
            Me.variacionProvisionParticipacionBeneficiosExtornosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguro

    Private variacionProvisionMatematicaField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionProvisionMatematica

    Private variacionParticipacionReaseguradorProvisionMatematicaField As Decimal

    Private variacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSegurosField As Decimal

    Private variacionOtrasProvisionesTecnicasField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionOtrasProvisionesTecnicas

    Private variacionParticipacionReaseguradorOtrasProvisionesTecnicasField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionParticipacionReaseguradorOtrasProvisionesTecnicas

    Private totalVariacionOtrasProvisionesTecnicasNetasReaseguroField As Decimal

    '''<remarks/>
    Public Property VariacionProvisionMatematica() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionProvisionMatematica
        Get
            Return Me.variacionProvisionMatematicaField
        End Get
        Set
            Me.variacionProvisionMatematicaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionParticipacionReaseguradorProvisionMatematica() As Decimal
        Get
            Return Me.variacionParticipacionReaseguradorProvisionMatematicaField
        End Get
        Set
            Me.variacionParticipacionReaseguradorProvisionMatematicaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSeguros() As Decimal
        Get
            Return Me.variacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSegurosField
        End Get
        Set
            Me.variacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSegurosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionOtrasProvisionesTecnicas() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionOtrasProvisionesTecnicas
        Get
            Return Me.variacionOtrasProvisionesTecnicasField
        End Get
        Set
            Me.variacionOtrasProvisionesTecnicasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionParticipacionReaseguradorOtrasProvisionesTecnicas() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionParticipacionReaseguradorOtrasProvisionesTecnicas
        Get
            Return Me.variacionParticipacionReaseguradorOtrasProvisionesTecnicasField
        End Get
        Set
            Me.variacionParticipacionReaseguradorOtrasProvisionesTecnicasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalVariacionOtrasProvisionesTecnicasNetasReaseguro() As Decimal
        Get
            Return Me.totalVariacionOtrasProvisionesTecnicasNetasReaseguroField
        End Get
        Set
            Me.totalVariacionOtrasProvisionesTecnicasNetasReaseguroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionProvisionMatematica

    Private desgloseVariacionProvisionMatematicaField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionProvisionMatematicaDesgloseVariacionProvisionMatematica

    Private totalVariacionProvisionMatematicaField As Decimal

    '''<remarks/>
    Public Property DesgloseVariacionProvisionMatematica() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionProvisionMatematicaDesgloseVariacionProvisionMatematica
        Get
            Return Me.desgloseVariacionProvisionMatematicaField
        End Get
        Set
            Me.desgloseVariacionProvisionMatematicaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalVariacionProvisionMatematica() As Decimal
        Get
            Return Me.totalVariacionProvisionMatematicaField
        End Get
        Set
            Me.totalVariacionProvisionMatematicaField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionProvisionMatematicaDesgloseVariacionProvisionMatematica

    Private seguroDirectoField As Decimal

    Private reaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property SeguroDirecto() As Decimal
        Get
            Return Me.seguroDirectoField
        End Get
        Set
            Me.seguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroAceptado() As Decimal
        Get
            Return Me.reaseguroAceptadoField
        End Get
        Set
            Me.reaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionOtrasProvisionesTecnicas

    Private desgloseVariacionOtrasProvisionesTecnicasField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionOtrasProvisionesTecnicasDesgloseVariacionOtrasProvisionesTecnicas

    Private totalVariacionOtrasProvisionesTecnicasField As Decimal

    '''<remarks/>
    Public Property DesgloseVariacionOtrasProvisionesTecnicas() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionOtrasProvisionesTecnicasDesgloseVariacionOtrasProvisionesTecnicas
        Get
            Return Me.desgloseVariacionOtrasProvisionesTecnicasField
        End Get
        Set
            Me.desgloseVariacionOtrasProvisionesTecnicasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalVariacionOtrasProvisionesTecnicas() As Decimal
        Get
            Return Me.totalVariacionOtrasProvisionesTecnicasField
        End Get
        Set
            Me.totalVariacionOtrasProvisionesTecnicasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionOtrasProvisionesTecnicasDesgloseVariacionOtrasProvisionesTecnicas

    Private seguroDirectoField As Decimal

    Private reaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property SeguroDirecto() As Decimal
        Get
            Return Me.seguroDirectoField
        End Get
        Set
            Me.seguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroAceptado() As Decimal
        Get
            Return Me.reaseguroAceptadoField
        End Get
        Set
            Me.reaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionParticipacionReaseguradorOtrasProvisionesTecnicas

    Private desgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicasField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionParticipacionReaseguradorOtrasProvisionesTecnicasDesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas

    Private totalVariacionParticipacionReaseguradorOtrasProvisionesTecnicasField As Decimal

    '''<remarks/>
    Public Property DesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionParticipacionReaseguradorOtrasProvisionesTecnicasDesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas
        Get
            Return Me.desgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicasField
        End Get
        Set
            Me.desgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalVariacionParticipacionReaseguradorOtrasProvisionesTecnicas() As Decimal
        Get
            Return Me.totalVariacionParticipacionReaseguradorOtrasProvisionesTecnicasField
        End Get
        Set
            Me.totalVariacionParticipacionReaseguradorOtrasProvisionesTecnicasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaVariacionOtrasProvisionesTecnicasNetasReaseguroVariacionParticipacionReaseguradorOtrasProvisionesTecnicasDesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas

    Private seguroDirectoField As Decimal

    Private reaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property SeguroDirecto() As Decimal
        Get
            Return Me.seguroDirectoField
        End Get
        Set
            Me.seguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroAceptado() As Decimal
        Get
            Return Me.reaseguroAceptadoField
        End Get
        Set
            Me.reaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaGastosExplotacionNetos

    Private desgloseGastosExplotacionNetosField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaGastosExplotacionNetosDesgloseGastosExplotacionNetos

    Private totalGastosExplotacionNetosField As Decimal

    '''<remarks/>
    Public Property DesgloseGastosExplotacionNetos() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaGastosExplotacionNetosDesgloseGastosExplotacionNetos
        Get
            Return Me.desgloseGastosExplotacionNetosField
        End Get
        Set
            Me.desgloseGastosExplotacionNetosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalGastosExplotacionNetos() As Decimal
        Get
            Return Me.totalGastosExplotacionNetosField
        End Get
        Set
            Me.totalGastosExplotacionNetosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaTecnicaGastosExplotacionNetosDesgloseGastosExplotacionNetos

    Private gastosAdquisicionField As Decimal

    Private gastosAdministracionField As Decimal

    Private comisionesParticipacionesReaseguroCedidoRetrocedidoField As Decimal

    '''<remarks/>
    Public Property GastosAdquisicion() As Decimal
        Get
            Return Me.gastosAdquisicionField
        End Get
        Set
            Me.gastosAdquisicionField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosAdministracion() As Decimal
        Get
            Return Me.gastosAdministracionField
        End Get
        Set
            Me.gastosAdministracionField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ComisionesParticipacionesReaseguroCedidoRetrocedido() As Decimal
        Get
            Return Me.comisionesParticipacionesReaseguroCedidoRetrocedidoField
        End Get
        Set
            Me.comisionesParticipacionesReaseguroCedidoRetrocedidoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinanciera

    Private ingresosFinancierosField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraIngresosFinancieros

    Private gastosFinancierosField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraGastosFinancieros

    Private totalCuentaFinancieraField As Decimal

    '''<remarks/>
    Public Property IngresosFinancieros() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraIngresosFinancieros
        Get
            Return Me.ingresosFinancierosField
        End Get
        Set
            Me.ingresosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosFinancieros() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraGastosFinancieros
        Get
            Return Me.gastosFinancierosField
        End Get
        Set
            Me.gastosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalCuentaFinanciera() As Decimal
        Get
            Return Me.totalCuentaFinancieraField
        End Get
        Set
            Me.totalCuentaFinancieraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraIngresosFinancieros

    Private desgloseIngresosFinancierosField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraIngresosFinancierosDesgloseIngresosFinancieros

    Private totalIngresosFinancierosField As Decimal

    '''<remarks/>
    Public Property DesgloseIngresosFinancieros() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraIngresosFinancierosDesgloseIngresosFinancieros
        Get
            Return Me.desgloseIngresosFinancierosField
        End Get
        Set
            Me.desgloseIngresosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalIngresosFinancieros() As Decimal
        Get
            Return Me.totalIngresosFinancierosField
        End Get
        Set
            Me.totalIngresosFinancierosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraIngresosFinancierosDesgloseIngresosFinancieros

    Private ingresosFinancierosField As Decimal

    Private ingresosFinancierosTomadorAsumeRiesgoInversionField As Decimal

    '''<remarks/>
    Public Property IngresosFinancieros() As Decimal
        Get
            Return Me.ingresosFinancierosField
        End Get
        Set
            Me.ingresosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property IngresosFinancierosTomadorAsumeRiesgoInversion() As Decimal
        Get
            Return Me.ingresosFinancierosTomadorAsumeRiesgoInversionField
        End Get
        Set
            Me.ingresosFinancierosTomadorAsumeRiesgoInversionField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraGastosFinancieros

    Private desgloseGastosFinancierosField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraGastosFinancierosDesgloseGastosFinancieros

    Private totalGastosFinancierosField As Decimal

    '''<remarks/>
    Public Property DesgloseGastosFinancieros() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraGastosFinancierosDesgloseGastosFinancieros
        Get
            Return Me.desgloseGastosFinancierosField
        End Get
        Set
            Me.desgloseGastosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalGastosFinancieros() As Decimal
        Get
            Return Me.totalGastosFinancierosField
        End Get
        Set
            Me.totalGastosFinancierosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraResultadoCuentaFinancieraGastosFinancierosDesgloseGastosFinancieros

    Private gastosFinancierosField As Decimal

    Private gastosFinancierosTomadorAsumeRiesgoInversionField As Decimal

    '''<remarks/>
    Public Property GastosFinancieros() As Decimal
        Get
            Return Me.gastosFinancierosField
        End Get
        Set
            Me.gastosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosFinancierosTomadorAsumeRiesgoInversion() As Decimal
        Get
            Return Me.gastosFinancierosTomadorAsumeRiesgoInversionField
        End Get
        Set
            Me.gastosFinancierosTomadorAsumeRiesgoInversionField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLinea

    Private resultadoCuentaTecnicoFinanciera_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_ln

    Private idLineaField As Linea

    '''<remarks/>
    Public Property ResultadoCuentaTecnicoFinanciera_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_ln
        Get
            Return Me.resultadoCuentaTecnicoFinanciera_lnField
        End Get
        Set
            Me.resultadoCuentaTecnicoFinanciera_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property idLinea() As Linea
        Get
            Return Me.idLineaField
        End Get
        Set
            Me.idLineaField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_ln

    Private resultadoCuentaTecnica_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_ln

    Private resultadoCuentaFinanciera_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_ln

    Private totalCuentaTecnicoFinanciera_lnField As Decimal

    '''<remarks/>
    Public Property ResultadoCuentaTecnica_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_ln
        Get
            Return Me.resultadoCuentaTecnica_lnField
        End Get
        Set
            Me.resultadoCuentaTecnica_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadoCuentaFinanciera_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_ln
        Get
            Return Me.resultadoCuentaFinanciera_lnField
        End Get
        Set
            Me.resultadoCuentaFinanciera_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalCuentaTecnicoFinanciera_ln() As Decimal
        Get
            Return Me.totalCuentaTecnicoFinanciera_lnField
        End Get
        Set
            Me.totalCuentaTecnicoFinanciera_lnField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_ln

    Private primasImputadasNetasReaseguro_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_ln

    Private siniestralidadNetaReaseguro_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_ln

    Private participacionBeneficiosExtornos_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnParticipacionBeneficiosExtornos_ln

    Private variacionOtrasProvisionesTecnicasNetasReaseguro_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_ln

    Private gastosExplotacionNetos_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnGastosExplotacionNetos_ln

    Private otrosIngresosTecnicos_lnField As Decimal

    Private otrosGastosTecnicos_lnField As Decimal

    Private totalCuentaTecnicaField As Decimal

    '''<remarks/>
    Public Property PrimasImputadasNetasReaseguro_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_ln
        Get
            Return Me.primasImputadasNetasReaseguro_lnField
        End Get
        Set
            Me.primasImputadasNetasReaseguro_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SiniestralidadNetaReaseguro_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_ln
        Get
            Return Me.siniestralidadNetaReaseguro_lnField
        End Get
        Set
            Me.siniestralidadNetaReaseguro_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ParticipacionBeneficiosExtornos_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnParticipacionBeneficiosExtornos_ln
        Get
            Return Me.participacionBeneficiosExtornos_lnField
        End Get
        Set
            Me.participacionBeneficiosExtornos_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionOtrasProvisionesTecnicasNetasReaseguro_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_ln
        Get
            Return Me.variacionOtrasProvisionesTecnicasNetasReaseguro_lnField
        End Get
        Set
            Me.variacionOtrasProvisionesTecnicasNetasReaseguro_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosExplotacionNetos_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnGastosExplotacionNetos_ln
        Get
            Return Me.gastosExplotacionNetos_lnField
        End Get
        Set
            Me.gastosExplotacionNetos_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosIngresosTecnicos_ln() As Decimal
        Get
            Return Me.otrosIngresosTecnicos_lnField
        End Get
        Set
            Me.otrosIngresosTecnicos_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosGastosTecnicos_ln() As Decimal
        Get
            Return Me.otrosGastosTecnicos_lnField
        End Get
        Set
            Me.otrosGastosTecnicos_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalCuentaTecnica() As Decimal
        Get
            Return Me.totalCuentaTecnicaField
        End Get
        Set
            Me.totalCuentaTecnicaField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_ln

    Private ingresoPrimas_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_ln

    Private primasReaseguroCedidoRetrocedido_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnPrimasReaseguroCedidoRetrocedido_ln

    Private variacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln

    Private variacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedido_lnField As Decimal

    Private totalPrimasImputadasNetasReaseguroField As Decimal

    '''<remarks/>
    Public Property IngresoPrimas_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_ln
        Get
            Return Me.ingresoPrimas_lnField
        End Get
        Set
            Me.ingresoPrimas_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasReaseguroCedidoRetrocedido_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnPrimasReaseguroCedidoRetrocedido_ln
        Get
            Return Me.primasReaseguroCedidoRetrocedido_lnField
        End Get
        Set
            Me.primasReaseguroCedidoRetrocedido_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln
        Get
            Return Me.variacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_lnField
        End Get
        Set
            Me.variacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedido_ln() As Decimal
        Get
            Return Me.variacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedido_lnField
        End Get
        Set
            Me.variacionParticipacionReaseguradorProvisionPrimasNoDevengadasReaseguroCedidoRetrocedido_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPrimasImputadasNetasReaseguro() As Decimal
        Get
            Return Me.totalPrimasImputadasNetasReaseguroField
        End Get
        Set
            Me.totalPrimasImputadasNetasReaseguroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_ln

    Private desgloseIngresoPrimas_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_lnDesgloseIngresoPrimas_ln

    Private totalIngresoPrimasField As Decimal

    '''<remarks/>
    Public Property DesgloseIngresoPrimas_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_lnDesgloseIngresoPrimas_ln
        Get
            Return Me.desgloseIngresoPrimas_lnField
        End Get
        Set
            Me.desgloseIngresoPrimas_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalIngresoPrimas() As Decimal
        Get
            Return Me.totalIngresoPrimasField
        End Get
        Set
            Me.totalIngresoPrimasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_lnDesgloseIngresoPrimas_ln

    Private seguroDirecto_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_lnDesgloseIngresoPrimas_lnSeguroDirecto_ln

    Private reaseguroAceptadoField As Decimal

    Private variacionEstimacionDeterioroPrimasVencidasField As Decimal

    '''<remarks/>
    Public Property SeguroDirecto_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_lnDesgloseIngresoPrimas_lnSeguroDirecto_ln
        Get
            Return Me.seguroDirecto_lnField
        End Get
        Set
            Me.seguroDirecto_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroAceptado() As Decimal
        Get
            Return Me.reaseguroAceptadoField
        End Get
        Set
            Me.reaseguroAceptadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionEstimacionDeterioroPrimasVencidas() As Decimal
        Get
            Return Me.variacionEstimacionDeterioroPrimasVencidasField
        End Get
        Set
            Me.variacionEstimacionDeterioroPrimasVencidasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_lnDesgloseIngresoPrimas_lnSeguroDirecto_ln

    Private desgloseSeguroDirecto_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_lnDesgloseIngresoPrimas_lnSeguroDirecto_lnDesgloseSeguroDirecto_ln

    Private totalSeguroDirectoField As Decimal

    '''<remarks/>
    Public Property DesgloseSeguroDirecto_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_lnDesgloseIngresoPrimas_lnSeguroDirecto_lnDesgloseSeguroDirecto_ln
        Get
            Return Me.desgloseSeguroDirecto_lnField
        End Get
        Set
            Me.desgloseSeguroDirecto_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSeguroDirecto() As Decimal
        Get
            Return Me.totalSeguroDirectoField
        End Get
        Set
            Me.totalSeguroDirectoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnIngresoPrimas_lnDesgloseIngresoPrimas_lnSeguroDirecto_lnDesgloseSeguroDirecto_ln

    Private primasEmitidasField As Decimal

    Private primasAnuladasExtornadasPeriodoField As Decimal

    Private primasAnuladasExtornadasPeriodosAnterioresField As Decimal

    Private variacionPrimasPolizasFlotantesField As Decimal

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
    Public Property PrimasAnuladasExtornadasPeriodo() As Decimal
        Get
            Return Me.primasAnuladasExtornadasPeriodoField
        End Get
        Set
            Me.primasAnuladasExtornadasPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasAnuladasExtornadasPeriodosAnteriores() As Decimal
        Get
            Return Me.primasAnuladasExtornadasPeriodosAnterioresField
        End Get
        Set
            Me.primasAnuladasExtornadasPeriodosAnterioresField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionPrimasPolizasFlotantes() As Decimal
        Get
            Return Me.variacionPrimasPolizasFlotantesField
        End Get
        Set
            Me.variacionPrimasPolizasFlotantesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnPrimasReaseguroCedidoRetrocedido_ln

    Private desglosePrimasReaseguroCedidoRetrocedido_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnPrimasReaseguroCedidoRetrocedido_lnDesglosePrimasReaseguroCedidoRetrocedido_ln

    Private totalPrimasReaseguroCedidoRetrocedidoField As Decimal

    '''<remarks/>
    Public Property DesglosePrimasReaseguroCedidoRetrocedido_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnPrimasReaseguroCedidoRetrocedido_lnDesglosePrimasReaseguroCedidoRetrocedido_ln
        Get
            Return Me.desglosePrimasReaseguroCedidoRetrocedido_lnField
        End Get
        Set
            Me.desglosePrimasReaseguroCedidoRetrocedido_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPrimasReaseguroCedidoRetrocedido() As Decimal
        Get
            Return Me.totalPrimasReaseguroCedidoRetrocedidoField
        End Get
        Set
            Me.totalPrimasReaseguroCedidoRetrocedidoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnPrimasReaseguroCedidoRetrocedido_lnDesglosePrimasReaseguroCedidoRetrocedido_ln

    Private primasCedidasReaseguroProporcionalField As Decimal

    Private primasPagadasReaseguroNoProporcionalField As Decimal

    '''<remarks/>
    Public Property PrimasCedidasReaseguroProporcional() As Decimal
        Get
            Return Me.primasCedidasReaseguroProporcionalField
        End Get
        Set
            Me.primasCedidasReaseguroProporcionalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasPagadasReaseguroNoProporcional() As Decimal
        Get
            Return Me.primasPagadasReaseguroNoProporcionalField
        End Get
        Set
            Me.primasPagadasReaseguroNoProporcionalField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln

    Private desgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_lnDesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln

    Private totalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasField As Decimal

    '''<remarks/>
    Public Property DesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_lnDesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln
        Get
            Return Me.desgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_lnField
        End Get
        Set
            Me.desgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas() As Decimal
        Get
            Return Me.totalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasField
        End Get
        Set
            Me.totalVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnPrimasImputadasNetasReaseguro_lnVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_lnDesgloseVariacionProvisionPrimasNoDevengadasParaInsuficienciaPrimas_ln

    Private seguroDirectoField As Decimal

    Private reaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property SeguroDirecto() As Decimal
        Get
            Return Me.seguroDirectoField
        End Get
        Set
            Me.seguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroAceptado() As Decimal
        Get
            Return Me.reaseguroAceptadoField
        End Get
        Set
            Me.reaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_ln

    Private siniestrosPagados_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnSiniestrosPagados_ln

    Private siniestrosGastosRecuperadosPorReaseguroCedidoRetrocedido_lnField As Decimal

    Private variacionProvisionParaSiniestros_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnVariacionProvisionParaSiniestros_ln

    Private variacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedido_lnField As Decimal

    Private gastosImputablesSiniestros_lnField As Decimal

    Private totalSiniestralidadNetaReaseguroField As Decimal

    '''<remarks/>
    Public Property SiniestrosPagados_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnSiniestrosPagados_ln
        Get
            Return Me.siniestrosPagados_lnField
        End Get
        Set
            Me.siniestrosPagados_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SiniestrosGastosRecuperadosPorReaseguroCedidoRetrocedido_ln() As Decimal
        Get
            Return Me.siniestrosGastosRecuperadosPorReaseguroCedidoRetrocedido_lnField
        End Get
        Set
            Me.siniestrosGastosRecuperadosPorReaseguroCedidoRetrocedido_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionProvisionParaSiniestros_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnVariacionProvisionParaSiniestros_ln
        Get
            Return Me.variacionProvisionParaSiniestros_lnField
        End Get
        Set
            Me.variacionProvisionParaSiniestros_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedido_ln() As Decimal
        Get
            Return Me.variacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedido_lnField
        End Get
        Set
            Me.variacionParticipacionReaseguradorProvisionSiniestrosReaseguroCedidoRetrocedido_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosImputablesSiniestros_ln() As Decimal
        Get
            Return Me.gastosImputablesSiniestros_lnField
        End Get
        Set
            Me.gastosImputablesSiniestros_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSiniestralidadNetaReaseguro() As Decimal
        Get
            Return Me.totalSiniestralidadNetaReaseguroField
        End Get
        Set
            Me.totalSiniestralidadNetaReaseguroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnSiniestrosPagados_ln

    Private desgloseSiniestrosPagados_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnSiniestrosPagados_lnDesgloseSiniestrosPagados_ln

    Private totalSiniestrosPagadosField As Decimal

    '''<remarks/>
    Public Property DesgloseSiniestrosPagados_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnSiniestrosPagados_lnDesgloseSiniestrosPagados_ln
        Get
            Return Me.desgloseSiniestrosPagados_lnField
        End Get
        Set
            Me.desgloseSiniestrosPagados_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSiniestrosPagados() As Decimal
        Get
            Return Me.totalSiniestrosPagadosField
        End Get
        Set
            Me.totalSiniestrosPagadosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnSiniestrosPagados_lnDesgloseSiniestrosPagados_ln

    Private seguroDirectoField As Decimal

    Private reaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property SeguroDirecto() As Decimal
        Get
            Return Me.seguroDirectoField
        End Get
        Set
            Me.seguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroAceptado() As Decimal
        Get
            Return Me.reaseguroAceptadoField
        End Get
        Set
            Me.reaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnVariacionProvisionParaSiniestros_ln

    Private desgloseVariacionProvisionParaSiniestros_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnVariacionProvisionParaSiniestros_lnDesgloseVariacionProvisionParaSiniestros_ln

    Private totalVariacionProvisionParaSiniestrosField As Decimal

    '''<remarks/>
    Public Property DesgloseVariacionProvisionParaSiniestros_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnVariacionProvisionParaSiniestros_lnDesgloseVariacionProvisionParaSiniestros_ln
        Get
            Return Me.desgloseVariacionProvisionParaSiniestros_lnField
        End Get
        Set
            Me.desgloseVariacionProvisionParaSiniestros_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalVariacionProvisionParaSiniestros() As Decimal
        Get
            Return Me.totalVariacionProvisionParaSiniestrosField
        End Get
        Set
            Me.totalVariacionProvisionParaSiniestrosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnSiniestralidadNetaReaseguro_lnVariacionProvisionParaSiniestros_lnDesgloseVariacionProvisionParaSiniestros_ln

    Private seguroDirectoField As Decimal

    Private reaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property SeguroDirecto() As Decimal
        Get
            Return Me.seguroDirectoField
        End Get
        Set
            Me.seguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroAceptado() As Decimal
        Get
            Return Me.reaseguroAceptadoField
        End Get
        Set
            Me.reaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnParticipacionBeneficiosExtornos_ln

    Private desgloseParticipacionBeneficiosExtornos_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnParticipacionBeneficiosExtornos_lnDesgloseParticipacionBeneficiosExtornos_ln

    Private totalParticipacionBeneficiosExtornosField As Decimal

    '''<remarks/>
    Public Property DesgloseParticipacionBeneficiosExtornos_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnParticipacionBeneficiosExtornos_lnDesgloseParticipacionBeneficiosExtornos_ln
        Get
            Return Me.desgloseParticipacionBeneficiosExtornos_lnField
        End Get
        Set
            Me.desgloseParticipacionBeneficiosExtornos_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalParticipacionBeneficiosExtornos() As Decimal
        Get
            Return Me.totalParticipacionBeneficiosExtornosField
        End Get
        Set
            Me.totalParticipacionBeneficiosExtornosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnParticipacionBeneficiosExtornos_lnDesgloseParticipacionBeneficiosExtornos_ln

    Private prestacionesGastosParticipacionBeneficiosExtornosField As Decimal

    Private variacionProvisionParticipacionBeneficiosExtornosField As Decimal

    '''<remarks/>
    Public Property PrestacionesGastosParticipacionBeneficiosExtornos() As Decimal
        Get
            Return Me.prestacionesGastosParticipacionBeneficiosExtornosField
        End Get
        Set
            Me.prestacionesGastosParticipacionBeneficiosExtornosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionProvisionParticipacionBeneficiosExtornos() As Decimal
        Get
            Return Me.variacionProvisionParticipacionBeneficiosExtornosField
        End Get
        Set
            Me.variacionProvisionParticipacionBeneficiosExtornosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_ln

    Private variacionProvisionMatematica_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionProvisionMatematica_ln

    Private variacionParticipacionReaseguradorProvisionMatematica_lnField As Decimal

    Private variacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSeguros_lnField As Decimal

    Private variacionOtrasProvisionesTecnicas_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionOtrasProvisionesTecnicas_ln

    Private variacionParticipacionReaseguradorOtrasProvisionesTecnicas_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln

    Private totalVariacionOtrasProvisionesTecnicasNetasReaseguroField As Decimal

    '''<remarks/>
    Public Property VariacionProvisionMatematica_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionProvisionMatematica_ln
        Get
            Return Me.variacionProvisionMatematica_lnField
        End Get
        Set
            Me.variacionProvisionMatematica_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionParticipacionReaseguradorProvisionMatematica_ln() As Decimal
        Get
            Return Me.variacionParticipacionReaseguradorProvisionMatematica_lnField
        End Get
        Set
            Me.variacionParticipacionReaseguradorProvisionMatematica_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSeguros_ln() As Decimal
        Get
            Return Me.variacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSeguros_lnField
        End Get
        Set
            Me.variacionProvisionesSegurosVidaRiesgoInversionAsumanTomadoresSeguros_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionOtrasProvisionesTecnicas_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionOtrasProvisionesTecnicas_ln
        Get
            Return Me.variacionOtrasProvisionesTecnicas_lnField
        End Get
        Set
            Me.variacionOtrasProvisionesTecnicas_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln
        Get
            Return Me.variacionParticipacionReaseguradorOtrasProvisionesTecnicas_lnField
        End Get
        Set
            Me.variacionParticipacionReaseguradorOtrasProvisionesTecnicas_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalVariacionOtrasProvisionesTecnicasNetasReaseguro() As Decimal
        Get
            Return Me.totalVariacionOtrasProvisionesTecnicasNetasReaseguroField
        End Get
        Set
            Me.totalVariacionOtrasProvisionesTecnicasNetasReaseguroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionProvisionMatematica_ln

    Private desgloseVariacionProvisionMatematica_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionProvisionMatematica_lnDesgloseVariacionProvisionMatematica_ln

    Private totalVariacionProvisionMatematicaField As Decimal

    '''<remarks/>
    Public Property DesgloseVariacionProvisionMatematica_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionProvisionMatematica_lnDesgloseVariacionProvisionMatematica_ln
        Get
            Return Me.desgloseVariacionProvisionMatematica_lnField
        End Get
        Set
            Me.desgloseVariacionProvisionMatematica_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalVariacionProvisionMatematica() As Decimal
        Get
            Return Me.totalVariacionProvisionMatematicaField
        End Get
        Set
            Me.totalVariacionProvisionMatematicaField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionProvisionMatematica_lnDesgloseVariacionProvisionMatematica_ln

    Private seguroDirectoField As Decimal

    Private reaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property SeguroDirecto() As Decimal
        Get
            Return Me.seguroDirectoField
        End Get
        Set
            Me.seguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroAceptado() As Decimal
        Get
            Return Me.reaseguroAceptadoField
        End Get
        Set
            Me.reaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionOtrasProvisionesTecnicas_ln

    Private desgloseVariacionOtrasProvisionesTecnicas_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionOtrasProvisionesTecnicas_lnDesgloseVariacionOtrasProvisionesTecnicas_ln

    Private totalVariacionOtrasProvisionesTecnicasField As Decimal

    '''<remarks/>
    Public Property DesgloseVariacionOtrasProvisionesTecnicas_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionOtrasProvisionesTecnicas_lnDesgloseVariacionOtrasProvisionesTecnicas_ln
        Get
            Return Me.desgloseVariacionOtrasProvisionesTecnicas_lnField
        End Get
        Set
            Me.desgloseVariacionOtrasProvisionesTecnicas_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalVariacionOtrasProvisionesTecnicas() As Decimal
        Get
            Return Me.totalVariacionOtrasProvisionesTecnicasField
        End Get
        Set
            Me.totalVariacionOtrasProvisionesTecnicasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionOtrasProvisionesTecnicas_lnDesgloseVariacionOtrasProvisionesTecnicas_ln

    Private seguroDirectoField As Decimal

    Private reaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property SeguroDirecto() As Decimal
        Get
            Return Me.seguroDirectoField
        End Get
        Set
            Me.seguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroAceptado() As Decimal
        Get
            Return Me.reaseguroAceptadoField
        End Get
        Set
            Me.reaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln

    Private desgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_lnDesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln

    Private totalVariacionParticipacionReaseguradorOtrasProvisionesTecnicasField As Decimal

    '''<remarks/>
    Public Property DesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_lnDesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln
        Get
            Return Me.desgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_lnField
        End Get
        Set
            Me.desgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalVariacionParticipacionReaseguradorOtrasProvisionesTecnicas() As Decimal
        Get
            Return Me.totalVariacionParticipacionReaseguradorOtrasProvisionesTecnicasField
        End Get
        Set
            Me.totalVariacionParticipacionReaseguradorOtrasProvisionesTecnicasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnVariacionOtrasProvisionesTecnicasNetasReaseguro_lnVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_lnDesgloseVariacionParticipacionReaseguradorOtrasProvisionesTecnicas_ln

    Private seguroDirectoField As Decimal

    Private reaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property SeguroDirecto() As Decimal
        Get
            Return Me.seguroDirectoField
        End Get
        Set
            Me.seguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroAceptado() As Decimal
        Get
            Return Me.reaseguroAceptadoField
        End Get
        Set
            Me.reaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnGastosExplotacionNetos_ln

    Private desgloseGastosExplotacionNetos_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnGastosExplotacionNetos_lnDesgloseGastosExplotacionNetos_ln

    Private totalGastosExplotacionNetosField As Decimal

    '''<remarks/>
    Public Property DesgloseGastosExplotacionNetos_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnGastosExplotacionNetos_lnDesgloseGastosExplotacionNetos_ln
        Get
            Return Me.desgloseGastosExplotacionNetos_lnField
        End Get
        Set
            Me.desgloseGastosExplotacionNetos_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalGastosExplotacionNetos() As Decimal
        Get
            Return Me.totalGastosExplotacionNetosField
        End Get
        Set
            Me.totalGastosExplotacionNetosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaTecnica_lnGastosExplotacionNetos_lnDesgloseGastosExplotacionNetos_ln

    Private gastosAdquisicionField As Decimal

    Private gastosAdministracionField As Decimal

    Private comisionesParticipacionesReaseguroCedidoRetrocedidoField As Decimal

    '''<remarks/>
    Public Property GastosAdquisicion() As Decimal
        Get
            Return Me.gastosAdquisicionField
        End Get
        Set
            Me.gastosAdquisicionField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosAdministracion() As Decimal
        Get
            Return Me.gastosAdministracionField
        End Get
        Set
            Me.gastosAdministracionField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ComisionesParticipacionesReaseguroCedidoRetrocedido() As Decimal
        Get
            Return Me.comisionesParticipacionesReaseguroCedidoRetrocedidoField
        End Get
        Set
            Me.comisionesParticipacionesReaseguroCedidoRetrocedidoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_ln

    Private ingresosFinancieros_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnIngresosFinancieros_ln

    Private gastosFinancieros_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnGastosFinancieros_ln

    Private totalCuentaFinancieraField As Decimal

    '''<remarks/>
    Public Property IngresosFinancieros_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnIngresosFinancieros_ln
        Get
            Return Me.ingresosFinancieros_lnField
        End Get
        Set
            Me.ingresosFinancieros_lnField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosFinancieros_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnGastosFinancieros_ln
        Get
            Return Me.gastosFinancieros_lnField
        End Get
        Set
            Me.gastosFinancieros_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalCuentaFinanciera() As Decimal
        Get
            Return Me.totalCuentaFinancieraField
        End Get
        Set
            Me.totalCuentaFinancieraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnIngresosFinancieros_ln

    Private desgloseIngresosFinancieros_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnIngresosFinancieros_lnDesgloseIngresosFinancieros_ln

    Private totalIngresosFinancierosField As Decimal

    '''<remarks/>
    Public Property DesgloseIngresosFinancieros_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnIngresosFinancieros_lnDesgloseIngresosFinancieros_ln
        Get
            Return Me.desgloseIngresosFinancieros_lnField
        End Get
        Set
            Me.desgloseIngresosFinancieros_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalIngresosFinancieros() As Decimal
        Get
            Return Me.totalIngresosFinancierosField
        End Get
        Set
            Me.totalIngresosFinancierosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnIngresosFinancieros_lnDesgloseIngresosFinancieros_ln

    Private ingresosFinancierosField As Decimal

    Private ingresosFinancierosTomadorAsumeRiesgoInversionField As Decimal

    '''<remarks/>
    Public Property IngresosFinancieros() As Decimal
        Get
            Return Me.ingresosFinancierosField
        End Get
        Set
            Me.ingresosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property IngresosFinancierosTomadorAsumeRiesgoInversion() As Decimal
        Get
            Return Me.ingresosFinancierosTomadorAsumeRiesgoInversionField
        End Get
        Set
            Me.ingresosFinancierosTomadorAsumeRiesgoInversionField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnGastosFinancieros_ln

    Private desgloseGastosFinancieros_lnField As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnGastosFinancieros_lnDesgloseGastosFinancieros_ln

    Private totalGastosFinancierosField As Decimal

    '''<remarks/>
    Public Property DesgloseGastosFinancieros_ln() As ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnGastosFinancieros_lnDesgloseGastosFinancieros_ln
        Get
            Return Me.desgloseGastosFinancieros_lnField
        End Get
        Set
            Me.desgloseGastosFinancieros_lnField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalGastosFinancieros() As Decimal
        Get
            Return Me.totalGastosFinancierosField
        End Get
        Set
            Me.totalGastosFinancierosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaTecnicoFinancieraLineaResultadoCuentaTecnicoFinanciera_lnResultadoCuentaFinanciera_lnGastosFinancieros_lnDesgloseGastosFinancieros_ln

    Private gastosFinancierosField As Decimal

    Private gastosFinancierosTomadorAsumeRiesgoInversionField As Decimal

    '''<remarks/>
    Public Property GastosFinancieros() As Decimal
        Get
            Return Me.gastosFinancierosField
        End Get
        Set
            Me.gastosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosFinancierosTomadorAsumeRiesgoInversion() As Decimal
        Get
            Return Me.gastosFinancierosTomadorAsumeRiesgoInversionField
        End Get
        Set
            Me.gastosFinancierosTomadorAsumeRiesgoInversionField = Value
        End Set
    End Property
End Class



'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloCuentaTecnicaDatosModeloUtilidadPerdidaNetaAntesImpuestosParticipacionesResultadoCuentaNoTecnica

    Private ingresosFinancierosField As Decimal

    Private gastosFinancierosField As Decimal

    Private otrosIngresosNoTecnicosField As Decimal

    Private otrosGastosNoTecnicosField As Decimal

    Private totalCuentaNoTecnicaField As Decimal

    '''<remarks/>
    Public Property IngresosFinancieros() As Decimal
        Get
            Return Me.ingresosFinancierosField
        End Get
        Set
            Me.ingresosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosFinancieros() As Decimal
        Get
            Return Me.gastosFinancierosField
        End Get
        Set
            Me.gastosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosIngresosNoTecnicos() As Decimal
        Get
            Return Me.otrosIngresosNoTecnicosField
        End Get
        Set
            Me.otrosIngresosNoTecnicosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosGastosNoTecnicos() As Decimal
        Get
            Return Me.otrosGastosNoTecnicosField
        End Get
        Set
            Me.otrosGastosNoTecnicosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalCuentaNoTecnica() As Decimal
        Get
            Return Me.totalCuentaNoTecnicaField
        End Get
        Set
            Me.totalCuentaNoTecnicaField = Value
        End Set
    End Property
End Class