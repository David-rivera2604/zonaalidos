Imports Architect.Sugese.Domain

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class ModeloEstadoResultados

    Private encabezadoField As EncabezadoTipo

    Private datosField As ModeloEstadoResultadosDatos

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
    Public Property Datos() As ModeloEstadoResultadosDatos
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

    'CUSTOM2010A
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

    'CUSTOM2010A
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
Partial Public Class ModeloEstadoResultadosDatos

    Private modeloField As ModeloEstadoResultadosDatosModelo

    '''<remarks/>
    Public Property Modelo() As ModeloEstadoResultadosDatosModelo
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
Partial Public Class ModeloEstadoResultadosDatosModelo

    Private cuentaResultadosTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotal

    Private resultadosIntegralesField As ModeloEstadoResultadosDatosModeloResultadosIntegrales

    Private entidadFuenteField As String

    '''<remarks/>
    Public Property CuentaResultadosTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotal
        Get
            Return Me.cuentaResultadosTotalField
        End Get
        Set
            Me.cuentaResultadosTotalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosIntegrales() As ModeloEstadoResultadosDatosModeloResultadosIntegrales
        Get
            Return Me.resultadosIntegralesField
        End Get
        Set
            Me.resultadosIntegralesField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotal

    Private utilidadDespuesImpuestosAntesParticipacionesField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipaciones

    Private participacionesLegalesUtilidadField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalParticipacionesLegalesUtilidad

    Private utilidadNetaPeriodoField As Decimal

    Private noControladorasField As Decimal

    Private controladoraField As Decimal

    '''<remarks/>
    Public Property UtilidadDespuesImpuestosAntesParticipaciones() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipaciones
        Get
            Return Me.utilidadDespuesImpuestosAntesParticipacionesField
        End Get
        Set
            Me.utilidadDespuesImpuestosAntesParticipacionesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ParticipacionesLegalesUtilidad() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalParticipacionesLegalesUtilidad
        Get
            Return Me.participacionesLegalesUtilidadField
        End Get
        Set
            Me.participacionesLegalesUtilidadField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property UtilidadNetaPeriodo() As Decimal
        Get
            Return Me.utilidadNetaPeriodoField
        End Get
        Set
            Me.utilidadNetaPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property NoControladoras() As Decimal
        Get
            Return Me.noControladorasField
        End Get
        Set
            Me.noControladorasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Controladora() As Decimal
        Get
            Return Me.controladoraField
        End Get
        Set
            Me.controladoraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipaciones

    Private utilidadAntesImpuestosParticipacionesField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipaciones

    Private impuestosSobreUtilidadField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesImpuestosSobreUtilidad

    Private totalUtilidadDespuesImpuestosAntesParticipacionesField As Decimal

    '''<remarks/>
    Public Property UtilidadAntesImpuestosParticipaciones() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipaciones
        Get
            Return Me.utilidadAntesImpuestosParticipacionesField
        End Get
        Set
            Me.utilidadAntesImpuestosParticipacionesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ImpuestosSobreUtilidad() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesImpuestosSobreUtilidad
        Get
            Return Me.impuestosSobreUtilidadField
        End Get
        Set
            Me.impuestosSobreUtilidadField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalUtilidadDespuesImpuestosAntesParticipaciones() As Decimal
        Get
            Return Me.totalUtilidadDespuesImpuestosAntesParticipacionesField
        End Get
        Set
            Me.totalUtilidadDespuesImpuestosAntesParticipacionesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipaciones

    Private utilidadOperacionesSegurosField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSeguros

    Private resultadoOtrasOperacionesField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperaciones

    Private totalUtilidadField As Decimal

    '''<remarks/>
    Public Property UtilidadOperacionesSeguros() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSeguros
        Get
            Return Me.utilidadOperacionesSegurosField
        End Get
        Set
            Me.utilidadOperacionesSegurosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadoOtrasOperaciones() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperaciones
        Get
            Return Me.resultadoOtrasOperacionesField
        End Get
        Set
            Me.resultadoOtrasOperacionesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalUtilidad() As Decimal
        Get
            Return Me.totalUtilidadField
        End Get
        Set
            Me.totalUtilidadField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSeguros

    Private utilidadBrutaOperacionesSegurosCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotal

    Private subtotalResultadoFinancieroField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinanciero

    Private totalUtilidadOperSegurosField As Decimal

    '''<remarks/>
    Public Property UtilidadBrutaOperacionesSegurosCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotal
        Get
            Return Me.utilidadBrutaOperacionesSegurosCtaTotalField
        End Get
        Set
            Me.utilidadBrutaOperacionesSegurosCtaTotalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SubtotalResultadoFinanciero() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinanciero
        Get
            Return Me.subtotalResultadoFinancieroField
        End Get
        Set
            Me.subtotalResultadoFinancieroField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalUtilidadOperSeguros() As Decimal
        Get
            Return Me.totalUtilidadOperSegurosField
        End Get
        Set
            Me.totalUtilidadOperSegurosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotal

    Private ingresosCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotal

    Private gastosCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotal

    Private variacionProvisionesTecnicasField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalVariacionProvisionesTecnicas

    Private totalUtilidadBrutaField As Decimal

    '''<remarks/>
    Public Property IngresosCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotal
        Get
            Return Me.ingresosCtaTotalField
        End Get
        Set
            Me.ingresosCtaTotalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotal
        Get
            Return Me.gastosCtaTotalField
        End Get
        Set
            Me.gastosCtaTotalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VariacionProvisionesTecnicas() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalVariacionProvisionesTecnicas
        Get
            Return Me.variacionProvisionesTecnicasField
        End Get
        Set
            Me.variacionProvisionesTecnicasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalUtilidadBruta() As Decimal
        Get
            Return Me.totalUtilidadBrutaField
        End Get
        Set
            Me.totalUtilidadBrutaField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotal

    Private primasCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalPrimasCtaTotal

    Private comisionesParticipacionesIngresosCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalComisionesParticipacionesIngresosCtaTotal

    Private siniestrosGastosReaseguroCedidoRetrocedidoCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal

    Private totalIngresosField As Decimal

    '''<remarks/>
    Public Property PrimasCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalPrimasCtaTotal
        Get
            Return Me.primasCtaTotalField
        End Get
        Set
            Me.primasCtaTotalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ComisionesParticipacionesIngresosCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalComisionesParticipacionesIngresosCtaTotal
        Get
            Return Me.comisionesParticipacionesIngresosCtaTotalField
        End Get
        Set
            Me.comisionesParticipacionesIngresosCtaTotalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal
        Get
            Return Me.siniestrosGastosReaseguroCedidoRetrocedidoCtaTotalField
        End Get
        Set
            Me.siniestrosGastosReaseguroCedidoRetrocedidoCtaTotalField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalIngresos() As Decimal
        Get
            Return Me.totalIngresosField
        End Get
        Set
            Me.totalIngresosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalPrimasCtaTotal

    Private desglosePrimasCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalPrimasCtaTotalDesglosePrimasCtaTotal

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesglosePrimasCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalPrimasCtaTotalDesglosePrimasCtaTotal
        Get
            Return Me.desglosePrimasCtaTotalField
        End Get
        Set
            Me.desglosePrimasCtaTotalField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalPrimasCtaTotalDesglosePrimasCtaTotal

    Private netasExtornosYAnulacionesSeguroDirectoField As Decimal

    Private netasExtornosYAnulacionesReaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property NetasExtornosYAnulacionesSeguroDirecto() As Decimal
        Get
            Return Me.netasExtornosYAnulacionesSeguroDirectoField
        End Get
        Set
            Me.netasExtornosYAnulacionesSeguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property NetasExtornosYAnulacionesReaseguroAceptado() As Decimal
        Get
            Return Me.netasExtornosYAnulacionesReaseguroAceptadoField
        End Get
        Set
            Me.netasExtornosYAnulacionesReaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalComisionesParticipacionesIngresosCtaTotal

    Private desgloseComisionesParticipacionesIngresosCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalComisionesParticipacionesIngresosCtaTotalDesgloseComisionesParticipacionesIngresosCtaTotal

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseComisionesParticipacionesIngresosCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalComisionesParticipacionesIngresosCtaTotalDesgloseComisionesParticipacionesIngresosCtaTotal
        Get
            Return Me.desgloseComisionesParticipacionesIngresosCtaTotalField
        End Get
        Set
            Me.desgloseComisionesParticipacionesIngresosCtaTotalField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalComisionesParticipacionesIngresosCtaTotalDesgloseComisionesParticipacionesIngresosCtaTotal

    Private comisionesParticipacionesReaseguroCedidoField As Decimal

    Private comisionesParticipacionesReaseguroRetrocedidoField As Decimal

    '''<remarks/>
    Public Property ComisionesParticipacionesReaseguroCedido() As Decimal
        Get
            Return Me.comisionesParticipacionesReaseguroCedidoField
        End Get
        Set
            Me.comisionesParticipacionesReaseguroCedidoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ComisionesParticipacionesReaseguroRetrocedido() As Decimal
        Get
            Return Me.comisionesParticipacionesReaseguroRetrocedidoField
        End Get
        Set
            Me.comisionesParticipacionesReaseguroRetrocedidoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal

    Private desgloseSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotalDesgloseSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotalDesgloseSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal
        Get
            Return Me.desgloseSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotalField
        End Get
        Set
            Me.desgloseSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotalField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalIngresosCtaTotalSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotalDesgloseSiniestrosGastosReaseguroCedidoRetrocedidoCtaTotal

    Private siniestrosGastosRecuperadosReaseguroCedidoField As Decimal

    Private siniestrosGastosRecuperadosReaseguroRetrocedidoField As Decimal

    '''<remarks/>
    Public Property SiniestrosGastosRecuperadosReaseguroCedido() As Decimal
        Get
            Return Me.siniestrosGastosRecuperadosReaseguroCedidoField
        End Get
        Set
            Me.siniestrosGastosRecuperadosReaseguroCedidoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SiniestrosGastosRecuperadosReaseguroRetrocedido() As Decimal
        Get
            Return Me.siniestrosGastosRecuperadosReaseguroRetrocedidoField
        End Get
        Set
            Me.siniestrosGastosRecuperadosReaseguroRetrocedidoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotal

    Private gastosPorPrestacionesField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosPorPrestaciones

    Private comisionesParticipacionesGastosCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalComisionesParticipacionesGastosCtaTotal

    Private gastosAdministracionTecnicosField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosAdministracionTecnicos

    Private primasCedidasReasegurosYFianzasCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalPrimasCedidasReasegurosYFianzasCtaTotal

    Private totalGastosField As Decimal

    '''<remarks/>
    Public Property GastosPorPrestaciones() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosPorPrestaciones
        Get
            Return Me.gastosPorPrestacionesField
        End Get
        Set
            Me.gastosPorPrestacionesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ComisionesParticipacionesGastosCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalComisionesParticipacionesGastosCtaTotal
        Get
            Return Me.comisionesParticipacionesGastosCtaTotalField
        End Get
        Set
            Me.comisionesParticipacionesGastosCtaTotalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosAdministracionTecnicos() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosAdministracionTecnicos
        Get
            Return Me.gastosAdministracionTecnicosField
        End Get
        Set
            Me.gastosAdministracionTecnicosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasCedidasReasegurosYFianzasCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalPrimasCedidasReasegurosYFianzasCtaTotal
        Get
            Return Me.primasCedidasReasegurosYFianzasCtaTotalField
        End Get
        Set
            Me.primasCedidasReasegurosYFianzasCtaTotalField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalGastos() As Decimal
        Get
            Return Me.totalGastosField
        End Get
        Set
            Me.totalGastosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosPorPrestaciones

    Private desglosePrestacionesCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosPorPrestacionesDesglosePrestacionesCtaTotal

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesglosePrestacionesCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosPorPrestacionesDesglosePrestacionesCtaTotal
        Get
            Return Me.desglosePrestacionesCtaTotalField
        End Get
        Set
            Me.desglosePrestacionesCtaTotalField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosPorPrestacionesDesglosePrestacionesCtaTotal

    Private siniestrosPagadosSeguroDirectoField As Decimal

    Private siniestrosPagadosReaseguroAceptadoField As Decimal

    Private beneficiosExtornosField As Decimal

    '''<remarks/>
    Public Property SiniestrosPagadosSeguroDirecto() As Decimal
        Get
            Return Me.siniestrosPagadosSeguroDirectoField
        End Get
        Set
            Me.siniestrosPagadosSeguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SiniestrosPagadosReaseguroAceptado() As Decimal
        Get
            Return Me.siniestrosPagadosReaseguroAceptadoField
        End Get
        Set
            Me.siniestrosPagadosReaseguroAceptadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property BeneficiosExtornos() As Decimal
        Get
            Return Me.beneficiosExtornosField
        End Get
        Set
            Me.beneficiosExtornosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalComisionesParticipacionesGastosCtaTotal

    Private desgloseComisionesParticipacionesGastosCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalComisionesParticipacionesGastosCtaTotalDesgloseComisionesParticipacionesGastosCtaTotal

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseComisionesParticipacionesGastosCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalComisionesParticipacionesGastosCtaTotalDesgloseComisionesParticipacionesGastosCtaTotal
        Get
            Return Me.desgloseComisionesParticipacionesGastosCtaTotalField
        End Get
        Set
            Me.desgloseComisionesParticipacionesGastosCtaTotalField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalComisionesParticipacionesGastosCtaTotalDesgloseComisionesParticipacionesGastosCtaTotal

    Private gastoComisionesSeguroDirectoField As Decimal

    Private gastoComisionesParticipacionesReaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property GastoComisionesSeguroDirecto() As Decimal
        Get
            Return Me.gastoComisionesSeguroDirectoField
        End Get
        Set
            Me.gastoComisionesSeguroDirectoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastoComisionesParticipacionesReaseguroAceptado() As Decimal
        Get
            Return Me.gastoComisionesParticipacionesReaseguroAceptadoField
        End Get
        Set
            Me.gastoComisionesParticipacionesReaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosAdministracionTecnicos

    Private desgloseGastosAdministracionTecnicosField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosAdministracionTecnicosDesgloseGastosAdministracionTecnicos

    Private totalGastosAdministracionTecnicosField As Decimal

    '''<remarks/>
    Public Property DesgloseGastosAdministracionTecnicos() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosAdministracionTecnicosDesgloseGastosAdministracionTecnicos
        Get
            Return Me.desgloseGastosAdministracionTecnicosField
        End Get
        Set
            Me.desgloseGastosAdministracionTecnicosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalGastosAdministracionTecnicos() As Decimal
        Get
            Return Me.totalGastosAdministracionTecnicosField
        End Get
        Set
            Me.totalGastosAdministracionTecnicosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalGastosAdministracionTecnicosDesgloseGastosAdministracionTecnicos

    Private gastosPersonalField As Decimal

    Private gastosServiciosExternosField As Decimal

    Private gastosMovilidadField As Decimal

    Private gastosInfraestructuraField As Decimal

    Private gastosGeneralesField As Decimal

    '''<remarks/>
    Public Property GastosPersonal() As Decimal
        Get
            Return Me.gastosPersonalField
        End Get
        Set
            Me.gastosPersonalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosServiciosExternos() As Decimal
        Get
            Return Me.gastosServiciosExternosField
        End Get
        Set
            Me.gastosServiciosExternosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosMovilidad() As Decimal
        Get
            Return Me.gastosMovilidadField
        End Get
        Set
            Me.gastosMovilidadField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosInfraestructura() As Decimal
        Get
            Return Me.gastosInfraestructuraField
        End Get
        Set
            Me.gastosInfraestructuraField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosGenerales() As Decimal
        Get
            Return Me.gastosGeneralesField
        End Get
        Set
            Me.gastosGeneralesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalPrimasCedidasReasegurosYFianzasCtaTotal

    Private desglosePrimasCedidasReasegurosYFianzasCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalPrimasCedidasReasegurosYFianzasCtaTotalDesglosePrimasCedidasReasegurosYFianzasCtaTotal

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesglosePrimasCedidasReasegurosYFianzasCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalPrimasCedidasReasegurosYFianzasCtaTotalDesglosePrimasCedidasReasegurosYFianzasCtaTotal
        Get
            Return Me.desglosePrimasCedidasReasegurosYFianzasCtaTotalField
        End Get
        Set
            Me.desglosePrimasCedidasReasegurosYFianzasCtaTotalField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalGastosCtaTotalPrimasCedidasReasegurosYFianzasCtaTotalDesglosePrimasCedidasReasegurosYFianzasCtaTotal

    Private reaseguroCedidoField As Decimal

    Private reaseguroRetrocedidoField As Decimal

    '''<remarks/>
    Public Property ReaseguroCedido() As Decimal
        Get
            Return Me.reaseguroCedidoField
        End Get
        Set
            Me.reaseguroCedidoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReaseguroRetrocedido() As Decimal
        Get
            Return Me.reaseguroRetrocedidoField
        End Get
        Set
            Me.reaseguroRetrocedidoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalVariacionProvisionesTecnicas

    Private ingresosAjustesCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalVariacionProvisionesTecnicasIngresosAjustesCtaTotal

    Private gastosAjustesCtaTotalField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalVariacionProvisionesTecnicasGastosAjustesCtaTotal

    Private totalVariacionProvisionesTecnicasField As Decimal

    '''<remarks/>
    Public Property IngresosAjustesCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalVariacionProvisionesTecnicasIngresosAjustesCtaTotal
        Get
            Return Me.ingresosAjustesCtaTotalField
        End Get
        Set
            Me.ingresosAjustesCtaTotalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosAjustesCtaTotal() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalVariacionProvisionesTecnicasGastosAjustesCtaTotal
        Get
            Return Me.gastosAjustesCtaTotalField
        End Get
        Set
            Me.gastosAjustesCtaTotalField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalVariacionProvisionesTecnicas() As Decimal
        Get
            Return Me.totalVariacionProvisionesTecnicasField
        End Get
        Set
            Me.totalVariacionProvisionesTecnicasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalVariacionProvisionesTecnicasIngresosAjustesCtaTotal

    Private ajustesProvisionesTecnicasField As Decimal

    Private totalField As Decimal

    '''<remarks/>
    Public Property AjustesProvisionesTecnicas() As Decimal
        Get
            Return Me.ajustesProvisionesTecnicasField
        End Get
        Set
            Me.ajustesProvisionesTecnicasField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosUtilidadBrutaOperacionesSegurosCtaTotalVariacionProvisionesTecnicasGastosAjustesCtaTotal

    Private ajustesProvisionesTecnicasField As Decimal

    Private totalField As Decimal

    '''<remarks/>
    Public Property AjustesProvisionesTecnicas() As Decimal
        Get
            Return Me.ajustesProvisionesTecnicasField
        End Get
        Set
            Me.ajustesProvisionesTecnicasField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinanciero

    Private ingresosFinancierosField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroIngresosFinancieros

    Private gastosFinancierosField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroGastosFinancieros

    Private totalSubtotalResultadoFinancieroField As Decimal

    '''<remarks/>
    Public Property IngresosFinancieros() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroIngresosFinancieros
        Get
            Return Me.ingresosFinancierosField
        End Get
        Set
            Me.ingresosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosFinancieros() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroGastosFinancieros
        Get
            Return Me.gastosFinancierosField
        End Get
        Set
            Me.gastosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalSubtotalResultadoFinanciero() As Decimal
        Get
            Return Me.totalSubtotalResultadoFinancieroField
        End Get
        Set
            Me.totalSubtotalResultadoFinancieroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroIngresosFinancieros

    Private desgloseIngresosFinancierosField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroIngresosFinancierosDesgloseIngresosFinancieros

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseIngresosFinancieros() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroIngresosFinancierosDesgloseIngresosFinancieros
        Get
            Return Me.desgloseIngresosFinancierosField
        End Get
        Set
            Me.desgloseIngresosFinancierosField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroIngresosFinancierosDesgloseIngresosFinancieros

    Private disponibilidadesField As Decimal

    Private inversionesInstrumentosFinancierosField As Decimal

    Private productosCarteraCreditoVigenteField As Decimal

    Private productosCarteraCreditosVencidaEnCobroJudicialField As Decimal

    Private ctasReciprocasInternasField As Decimal

    Private gananciasPosicionInstrumentosFinancierosDerivadosField As Decimal

    Private gananciasDiferencialCambiarioYUnidadesDesarrolloField As Decimal

    Private otrosIngresosField As Decimal

    '''<remarks/>
    Public Property Disponibilidades() As Decimal
        Get
            Return Me.disponibilidadesField
        End Get
        Set
            Me.disponibilidadesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property InversionesInstrumentosFinancieros() As Decimal
        Get
            Return Me.inversionesInstrumentosFinancierosField
        End Get
        Set
            Me.inversionesInstrumentosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProductosCarteraCreditoVigente() As Decimal
        Get
            Return Me.productosCarteraCreditoVigenteField
        End Get
        Set
            Me.productosCarteraCreditoVigenteField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProductosCarteraCreditosVencidaEnCobroJudicial() As Decimal
        Get
            Return Me.productosCarteraCreditosVencidaEnCobroJudicialField
        End Get
        Set
            Me.productosCarteraCreditosVencidaEnCobroJudicialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CtasReciprocasInternas() As Decimal
        Get
            Return Me.ctasReciprocasInternasField
        End Get
        Set
            Me.ctasReciprocasInternasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GananciasPosicionInstrumentosFinancierosDerivados() As Decimal
        Get
            Return Me.gananciasPosicionInstrumentosFinancierosDerivadosField
        End Get
        Set
            Me.gananciasPosicionInstrumentosFinancierosDerivadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GananciasDiferencialCambiarioYUnidadesDesarrollo() As Decimal
        Get
            Return Me.gananciasDiferencialCambiarioYUnidadesDesarrolloField
        End Get
        Set
            Me.gananciasDiferencialCambiarioYUnidadesDesarrolloField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosIngresos() As Decimal
        Get
            Return Me.otrosIngresosField
        End Get
        Set
            Me.otrosIngresosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroGastosFinancieros

    Private desgloseGastosFinancierosField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroGastosFinancierosDesgloseGastosFinancieros

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseGastosFinancieros() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroGastosFinancierosDesgloseGastosFinancieros
        Get
            Return Me.desgloseGastosFinancierosField
        End Get
        Set
            Me.desgloseGastosFinancierosField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesUtilidadOperacionesSegurosSubtotalResultadoFinancieroGastosFinancierosDesgloseGastosFinancieros

    Private obligacionesPublicoField As Decimal

    Private obligEntidadesFinancierasYNoFinancierasField As Decimal

    Private ctasPagarDiversasField As Decimal

    Private ctasReciprocasInternasField As Decimal

    Private obligacionesSubordinadasConvertiblesPreferentesField As Decimal

    Private perdidasPosicionInstrumentosFinancierosDerivadosField As Decimal

    Private perdidasDiferencialCambiarioYUnidadesDesarrolloField As Decimal

    Private otrosGastosField As Decimal

    '''<remarks/>
    Public Property ObligacionesPublico() As Decimal
        Get
            Return Me.obligacionesPublicoField
        End Get
        Set
            Me.obligacionesPublicoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ObligEntidadesFinancierasYNoFinancieras() As Decimal
        Get
            Return Me.obligEntidadesFinancierasYNoFinancierasField
        End Get
        Set
            Me.obligEntidadesFinancierasYNoFinancierasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CtasPagarDiversas() As Decimal
        Get
            Return Me.ctasPagarDiversasField
        End Get
        Set
            Me.ctasPagarDiversasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CtasReciprocasInternas() As Decimal
        Get
            Return Me.ctasReciprocasInternasField
        End Get
        Set
            Me.ctasReciprocasInternasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ObligacionesSubordinadasConvertiblesPreferentes() As Decimal
        Get
            Return Me.obligacionesSubordinadasConvertiblesPreferentesField
        End Get
        Set
            Me.obligacionesSubordinadasConvertiblesPreferentesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PerdidasPosicionInstrumentosFinancierosDerivados() As Decimal
        Get
            Return Me.perdidasPosicionInstrumentosFinancierosDerivadosField
        End Get
        Set
            Me.perdidasPosicionInstrumentosFinancierosDerivadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PerdidasDiferencialCambiarioYUnidadesDesarrollo() As Decimal
        Get
            Return Me.perdidasDiferencialCambiarioYUnidadesDesarrolloField
        End Get
        Set
            Me.perdidasDiferencialCambiarioYUnidadesDesarrolloField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosGastos() As Decimal
        Get
            Return Me.otrosGastosField
        End Get
        Set
            Me.otrosGastosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperaciones

    Private ingresosRecuperacionActivosDisminucionEstimacionesProvisionesField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosRecuperacionActivosDisminucionEstimacionesProvisiones

    Private ingresosOperativosDiversosField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosOperativosDiversos

    Private gastosEstimacionDeterioroActivosField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosEstimacionDeterioroActivos

    Private gastosOperativosDiversosField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosOperativosDiversos

    Private gastosAdministracionField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosAdministracion

    Private totalResultadoOtrasOperacionesField As Decimal

    '''<remarks/>
    Public Property IngresosRecuperacionActivosDisminucionEstimacionesProvisiones() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosRecuperacionActivosDisminucionEstimacionesProvisiones
        Get
            Return Me.ingresosRecuperacionActivosDisminucionEstimacionesProvisionesField
        End Get
        Set
            Me.ingresosRecuperacionActivosDisminucionEstimacionesProvisionesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property IngresosOperativosDiversos() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosOperativosDiversos
        Get
            Return Me.ingresosOperativosDiversosField
        End Get
        Set
            Me.ingresosOperativosDiversosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosEstimacionDeterioroActivos() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosEstimacionDeterioroActivos
        Get
            Return Me.gastosEstimacionDeterioroActivosField
        End Get
        Set
            Me.gastosEstimacionDeterioroActivosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosOperativosDiversos() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosOperativosDiversos
        Get
            Return Me.gastosOperativosDiversosField
        End Get
        Set
            Me.gastosOperativosDiversosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosAdministracion() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosAdministracion
        Get
            Return Me.gastosAdministracionField
        End Get
        Set
            Me.gastosAdministracionField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalResultadoOtrasOperaciones() As Decimal
        Get
            Return Me.totalResultadoOtrasOperacionesField
        End Get
        Set
            Me.totalResultadoOtrasOperacionesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosRecuperacionActivosDisminucionEstimacionesProvisiones

    Private desgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisionesField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosRecuperacionActivosDisminucionEstimacionesProvisionesDesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosRecuperacionActivosDisminucionEstimacionesProvisionesDesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones
        Get
            Return Me.desgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisionesField
        End Get
        Set
            Me.desgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisionesField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosRecuperacionActivosDisminucionEstimacionesProvisionesDesgloseIngresosRecuperacionActivosDisminucionEstimacionesProvisiones

    Private recuperacionActivosFinancierosLiquidadosField As Decimal

    Private carteraCreditosField As Decimal

    Private inversionesInstrumentosFinancierosField As Decimal

    Private provisionesField As Decimal

    '''<remarks/>
    Public Property RecuperacionActivosFinancierosLiquidados() As Decimal
        Get
            Return Me.recuperacionActivosFinancierosLiquidadosField
        End Get
        Set
            Me.recuperacionActivosFinancierosLiquidadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CarteraCreditos() As Decimal
        Get
            Return Me.carteraCreditosField
        End Get
        Set
            Me.carteraCreditosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property InversionesInstrumentosFinancieros() As Decimal
        Get
            Return Me.inversionesInstrumentosFinancierosField
        End Get
        Set
            Me.inversionesInstrumentosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Provisiones() As Decimal
        Get
            Return Me.provisionesField
        End Get
        Set
            Me.provisionesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosOperativosDiversos

    Private desgloseIngresosOperativosDiversosField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosOperativosDiversosDesgloseIngresosOperativosDiversos

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseIngresosOperativosDiversos() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosOperativosDiversosDesgloseIngresosOperativosDiversos
        Get
            Return Me.desgloseIngresosOperativosDiversosField
        End Get
        Set
            Me.desgloseIngresosOperativosDiversosField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesIngresosOperativosDiversosDesgloseIngresosOperativosDiversos

    Private comisionesServiciosField As Decimal

    Private bienesMantenidosVentaField As Decimal

    Private participacionesEnCapitalOtrasEmpresasField As Decimal

    Private otrosPartesRelacionadasField As Decimal

    Private otrosIngresosOperativosField As Decimal

    '''<remarks/>
    Public Property ComisionesServicios() As Decimal
        Get
            Return Me.comisionesServiciosField
        End Get
        Set
            Me.comisionesServiciosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property BienesMantenidosVenta() As Decimal
        Get
            Return Me.bienesMantenidosVentaField
        End Get
        Set
            Me.bienesMantenidosVentaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ParticipacionesEnCapitalOtrasEmpresas() As Decimal
        Get
            Return Me.participacionesEnCapitalOtrasEmpresasField
        End Get
        Set
            Me.participacionesEnCapitalOtrasEmpresasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosPartesRelacionadas() As Decimal
        Get
            Return Me.otrosPartesRelacionadasField
        End Get
        Set
            Me.otrosPartesRelacionadasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosIngresosOperativos() As Decimal
        Get
            Return Me.otrosIngresosOperativosField
        End Get
        Set
            Me.otrosIngresosOperativosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosEstimacionDeterioroActivos

    Private desgloseGastosEstimacionDeterioroActivosField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosEstimacionDeterioroActivosDesgloseGastosEstimacionDeterioroActivos

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseGastosEstimacionDeterioroActivos() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosEstimacionDeterioroActivosDesgloseGastosEstimacionDeterioroActivos
        Get
            Return Me.desgloseGastosEstimacionDeterioroActivosField
        End Get
        Set
            Me.desgloseGastosEstimacionDeterioroActivosField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosEstimacionDeterioroActivosDesgloseGastosEstimacionDeterioroActivos

    Private carteraCreditosCuentasComisionesCobrarField As Decimal

    Private inversionesInstrumentosFinancierosField As Decimal

    Private propiedadesInversionField As Decimal

    Private cargosBienesDiversosField As Decimal

    '''<remarks/>
    Public Property CarteraCreditosCuentasComisionesCobrar() As Decimal
        Get
            Return Me.carteraCreditosCuentasComisionesCobrarField
        End Get
        Set
            Me.carteraCreditosCuentasComisionesCobrarField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property InversionesInstrumentosFinancieros() As Decimal
        Get
            Return Me.inversionesInstrumentosFinancierosField
        End Get
        Set
            Me.inversionesInstrumentosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PropiedadesInversion() As Decimal
        Get
            Return Me.propiedadesInversionField
        End Get
        Set
            Me.propiedadesInversionField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CargosBienesDiversos() As Decimal
        Get
            Return Me.cargosBienesDiversosField
        End Get
        Set
            Me.cargosBienesDiversosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosOperativosDiversos

    Private desgloseGastosOperativosDiversosField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosOperativosDiversosDesgloseGastosOperativosDiversos

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseGastosOperativosDiversos() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosOperativosDiversosDesgloseGastosOperativosDiversos
        Get
            Return Me.desgloseGastosOperativosDiversosField
        End Get
        Set
            Me.desgloseGastosOperativosDiversosField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosOperativosDiversosDesgloseGastosOperativosDiversos

    Private comisionesServiciosField As Decimal

    Private bienesMantenidosVentaField As Decimal

    Private participacionCapitalOtrasEmpresasField As Decimal

    Private provisionesField As Decimal

    Private partesRelacionadasField As Decimal

    Private otrosGastosOperativosField As Decimal

    '''<remarks/>
    Public Property ComisionesServicios() As Decimal
        Get
            Return Me.comisionesServiciosField
        End Get
        Set
            Me.comisionesServiciosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property BienesMantenidosVenta() As Decimal
        Get
            Return Me.bienesMantenidosVentaField
        End Get
        Set
            Me.bienesMantenidosVentaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ParticipacionCapitalOtrasEmpresas() As Decimal
        Get
            Return Me.participacionCapitalOtrasEmpresasField
        End Get
        Set
            Me.participacionCapitalOtrasEmpresasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Provisiones() As Decimal
        Get
            Return Me.provisionesField
        End Get
        Set
            Me.provisionesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PartesRelacionadas() As Decimal
        Get
            Return Me.partesRelacionadasField
        End Get
        Set
            Me.partesRelacionadasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosGastosOperativos() As Decimal
        Get
            Return Me.otrosGastosOperativosField
        End Get
        Set
            Me.otrosGastosOperativosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosAdministracion

    Private desgloseGastosAdministracionField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosAdministracionDesgloseGastosAdministracion

    Private totalGastosAdministracionNoTecnicoField As Decimal

    '''<remarks/>
    Public Property DesgloseGastosAdministracion() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosAdministracionDesgloseGastosAdministracion
        Get
            Return Me.desgloseGastosAdministracionField
        End Get
        Set
            Me.desgloseGastosAdministracionField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalGastosAdministracionNoTecnico() As Decimal
        Get
            Return Me.totalGastosAdministracionNoTecnicoField
        End Get
        Set
            Me.totalGastosAdministracionNoTecnicoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesUtilidadAntesImpuestosParticipacionesResultadoOtrasOperacionesGastosAdministracionDesgloseGastosAdministracion

    Private personalField As Decimal

    Private serviciosExternosField As Decimal

    Private movilidadYComunicacionesField As Decimal

    Private infraestructuraField As Decimal

    Private generalesField As Decimal

    '''<remarks/>
    Public Property Personal() As Decimal
        Get
            Return Me.personalField
        End Get
        Set
            Me.personalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ServiciosExternos() As Decimal
        Get
            Return Me.serviciosExternosField
        End Get
        Set
            Me.serviciosExternosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property MovilidadYComunicaciones() As Decimal
        Get
            Return Me.movilidadYComunicacionesField
        End Get
        Set
            Me.movilidadYComunicacionesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Infraestructura() As Decimal
        Get
            Return Me.infraestructuraField
        End Get
        Set
            Me.infraestructuraField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Generales() As Decimal
        Get
            Return Me.generalesField
        End Get
        Set
            Me.generalesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesImpuestosSobreUtilidad

    Private desgloseImpuestosSobreUtilidadField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesImpuestosSobreUtilidadDesgloseImpuestosSobreUtilidad

    Private totalField As Decimal

    '''<remarks/>
    Public Property DesgloseImpuestosSobreUtilidad() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesImpuestosSobreUtilidadDesgloseImpuestosSobreUtilidad
        Get
            Return Me.desgloseImpuestosSobreUtilidadField
        End Get
        Set
            Me.desgloseImpuestosSobreUtilidadField = Value
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
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalUtilidadDespuesImpuestosAntesParticipacionesImpuestosSobreUtilidadDesgloseImpuestosSobreUtilidad

    Private sobreRentaField As Decimal

    Private disminucionSobreRentaField As Decimal

    '''<remarks/>
    Public Property SobreRenta() As Decimal
        Get
            Return Me.sobreRentaField
        End Get
        Set
            Me.sobreRentaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DisminucionSobreRenta() As Decimal
        Get
            Return Me.disminucionSobreRentaField
        End Get
        Set
            Me.disminucionSobreRentaField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalParticipacionesLegalesUtilidad

    Private desgloseParticipacionesLegalesUtilidadField As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalParticipacionesLegalesUtilidadDesgloseParticipacionesLegalesUtilidad

    Private totalLegalesSobreUtilidadField As Decimal

    '''<remarks/>
    Public Property DesgloseParticipacionesLegalesUtilidad() As ModeloEstadoResultadosDatosModeloCuentaResultadosTotalParticipacionesLegalesUtilidadDesgloseParticipacionesLegalesUtilidad
        Get
            Return Me.desgloseParticipacionesLegalesUtilidadField
        End Get
        Set
            Me.desgloseParticipacionesLegalesUtilidadField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalLegalesSobreUtilidad() As Decimal
        Get
            Return Me.totalLegalesSobreUtilidadField
        End Get
        Set
            Me.totalLegalesSobreUtilidadField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloCuentaResultadosTotalParticipacionesLegalesUtilidadDesgloseParticipacionesLegalesUtilidad

    Private legalesSobreUtilidadField As Decimal

    Private disminucionLegalesSobreUtilidadField As Decimal

    '''<remarks/>
    Public Property LegalesSobreUtilidad() As Decimal
        Get
            Return Me.legalesSobreUtilidadField
        End Get
        Set
            Me.legalesSobreUtilidadField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DisminucionLegalesSobreUtilidad() As Decimal
        Get
            Return Me.disminucionLegalesSobreUtilidadField
        End Get
        Set
            Me.disminucionLegalesSobreUtilidadField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloResultadosIntegrales

    Private otrosResultadosIntegralesField As ModeloEstadoResultadosDatosModeloResultadosIntegralesOtrosResultadosIntegrales

    Private totalDelPeriodoField As Decimal

    Private noControladorasField As Decimal

    Private controladoraField As Decimal

    '''<remarks/>
    Public Property OtrosResultadosIntegrales() As ModeloEstadoResultadosDatosModeloResultadosIntegralesOtrosResultadosIntegrales
        Get
            Return Me.otrosResultadosIntegralesField
        End Get
        Set
            Me.otrosResultadosIntegralesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalDelPeriodo() As Decimal
        Get
            Return Me.totalDelPeriodoField
        End Get
        Set
            Me.totalDelPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property NoControladoras() As Decimal
        Get
            Return Me.noControladorasField
        End Get
        Set
            Me.noControladorasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property Controladora() As Decimal
        Get
            Return Me.controladoraField
        End Get
        Set
            Me.controladoraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloResultadosIntegralesOtrosResultadosIntegrales

    Private desgloseOtrosResultadosIntegralesField As ModeloEstadoResultadosDatosModeloResultadosIntegralesOtrosResultadosIntegralesDesgloseOtrosResultadosIntegrales

    Private totalOtrosResultadosIntegralesField As Decimal

    '''<remarks/>
    Public Property DesgloseOtrosResultadosIntegrales() As ModeloEstadoResultadosDatosModeloResultadosIntegralesOtrosResultadosIntegralesDesgloseOtrosResultadosIntegrales
        Get
            Return Me.desgloseOtrosResultadosIntegralesField
        End Get
        Set
            Me.desgloseOtrosResultadosIntegralesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOtrosResultadosIntegrales() As Decimal
        Get
            Return Me.totalOtrosResultadosIntegralesField
        End Get
        Set
            Me.totalOtrosResultadosIntegralesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloEstadoResultadosDatosModeloResultadosIntegralesOtrosResultadosIntegralesDesgloseOtrosResultadosIntegrales

    Private superavitPropInmobiliariasField As Decimal

    Private invCambiosResultadoIntegralField As Decimal

    Private invRespaldoReservaLiquidezField As Decimal

    Private instrFinanRestringidosField As Decimal

    Private instrFinanCesacionPagosMorososLitigiosField As Decimal

    Private superavitOtrosActivosField As Decimal

    Private instrumentosDerivadosField As Decimal

    Private otrosAjustesField As Decimal

    '''<remarks/>
    Public Property SuperavitPropInmobiliarias() As Decimal
        Get
            Return Me.superavitPropInmobiliariasField
        End Get
        Set
            Me.superavitPropInmobiliariasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property InvCambiosResultadoIntegral() As Decimal
        Get
            Return Me.invCambiosResultadoIntegralField
        End Get
        Set
            Me.invCambiosResultadoIntegralField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property InvRespaldoReservaLiquidez() As Decimal
        Get
            Return Me.invRespaldoReservaLiquidezField
        End Get
        Set
            Me.invRespaldoReservaLiquidezField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property InstrFinanRestringidos() As Decimal
        Get
            Return Me.instrFinanRestringidosField
        End Get
        Set
            Me.instrFinanRestringidosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property InstrFinanCesacionPagosMorososLitigios() As Decimal
        Get
            Return Me.instrFinanCesacionPagosMorososLitigiosField
        End Get
        Set
            Me.instrFinanCesacionPagosMorososLitigiosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SuperavitOtrosActivos() As Decimal
        Get
            Return Me.superavitOtrosActivosField
        End Get
        Set
            Me.superavitOtrosActivosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property InstrumentosDerivados() As Decimal
        Get
            Return Me.instrumentosDerivadosField
        End Get
        Set
            Me.instrumentosDerivadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosAjustes() As Decimal
        Get
            Return Me.otrosAjustesField
        End Get
        Set
            Me.otrosAjustesField = Value
        End Set
    End Property
End Class