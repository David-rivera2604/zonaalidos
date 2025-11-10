Imports Architect.Sugese.Domain

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
Partial Public Class ModeloBalanceGeneral

    Private encabezadoField As EncabezadoTipo

    Private datosField As ModeloBalanceGeneralDatos

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
    Public Property Datos() As ModeloBalanceGeneralDatos
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
Partial Public Class ModeloBalanceGeneralDatos

    Private modeloField As ModeloBalanceGeneralDatosModelo

    '''<remarks/>
    Public Property Modelo() As ModeloBalanceGeneralDatosModelo
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
Partial Public Class ModeloBalanceGeneralDatosModelo

    Private activoField As ModeloBalanceGeneralDatosModeloActivo

    Private pasivoField As ModeloBalanceGeneralDatosModeloPasivo

    Private patrimonioField As ModeloBalanceGeneralDatosModeloPatrimonio

    Private pasivoMasPatrimonioField As ModeloBalanceGeneralDatosModeloPasivoMasPatrimonio

    Private entidadFuenteField As String

    '''<remarks/>
    Public Property Activo() As ModeloBalanceGeneralDatosModeloActivo
        Get
            Return Me.activoField
        End Get
        Set
            Me.activoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Pasivo() As ModeloBalanceGeneralDatosModeloPasivo
        Get
            Return Me.pasivoField
        End Get
        Set
            Me.pasivoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Patrimonio() As ModeloBalanceGeneralDatosModeloPatrimonio
        Get
            Return Me.patrimonioField
        End Get
        Set
            Me.patrimonioField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PasivoMasPatrimonio() As ModeloBalanceGeneralDatosModeloPasivoMasPatrimonio
        Get
            Return Me.pasivoMasPatrimonioField
        End Get
        Set
            Me.pasivoMasPatrimonioField = Value
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
Partial Public Class ModeloBalanceGeneralDatosModeloActivo

    Private disponibilidadesField As ModeloBalanceGeneralDatosModeloActivoDisponibilidades

    Private inversionesInstrumentosFinancierosField As ModeloBalanceGeneralDatosModeloActivoInversionesInstrumentosFinancieros

    Private carteraCreditosField As ModeloBalanceGeneralDatosModeloActivoCarteraCreditos

    Private comisionesPrimasCuentasCobrarField As ModeloBalanceGeneralDatosModeloActivoComisionesPrimasCuentasCobrar

    Private cuentasAcreedorasDeudorasOperacionesCoaseguroActivoField As ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesCoaseguroActivo

    Private cuentasAcreedorasDeudorasOperacionesReaseguroActivoField As ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesReaseguroActivo

    Private participacionReaseguroProvisionesTecnicasField As ModeloBalanceGeneralDatosModeloActivoParticipacionReaseguroProvisionesTecnicas

    Private bienesMantenidosParaVentaField As ModeloBalanceGeneralDatosModeloActivoBienesMantenidosParaVenta

    Private propiedadesMobilarioEquipoField As ModeloBalanceGeneralDatosModeloActivoPropiedadesMobilarioEquipo

    Private otrosActivosField As ModeloBalanceGeneralDatosModeloActivoOtrosActivos

    Private propiedadesDeInversionField As ModeloBalanceGeneralDatosModeloActivoPropiedadesDeInversion

    Private participacionOtrasEmpresasField As ModeloBalanceGeneralDatosModeloActivoParticipacionOtrasEmpresas

    Private totalActivoField As Decimal

    '''<remarks/>
    Public Property Disponibilidades() As ModeloBalanceGeneralDatosModeloActivoDisponibilidades
        Get
            Return Me.disponibilidadesField
        End Get
        Set
            Me.disponibilidadesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property InversionesInstrumentosFinancieros() As ModeloBalanceGeneralDatosModeloActivoInversionesInstrumentosFinancieros
        Get
            Return Me.inversionesInstrumentosFinancierosField
        End Get
        Set
            Me.inversionesInstrumentosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CarteraCreditos() As ModeloBalanceGeneralDatosModeloActivoCarteraCreditos
        Get
            Return Me.carteraCreditosField
        End Get
        Set
            Me.carteraCreditosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ComisionesPrimasCuentasCobrar() As ModeloBalanceGeneralDatosModeloActivoComisionesPrimasCuentasCobrar
        Get
            Return Me.comisionesPrimasCuentasCobrarField
        End Get
        Set
            Me.comisionesPrimasCuentasCobrarField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CuentasAcreedorasDeudorasOperacionesCoaseguroActivo() As ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesCoaseguroActivo
        Get
            Return Me.cuentasAcreedorasDeudorasOperacionesCoaseguroActivoField
        End Get
        Set
            Me.cuentasAcreedorasDeudorasOperacionesCoaseguroActivoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CuentasAcreedorasDeudorasOperacionesReaseguroActivo() As ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesReaseguroActivo
        Get
            Return Me.cuentasAcreedorasDeudorasOperacionesReaseguroActivoField
        End Get
        Set
            Me.cuentasAcreedorasDeudorasOperacionesReaseguroActivoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ParticipacionReaseguroProvisionesTecnicas() As ModeloBalanceGeneralDatosModeloActivoParticipacionReaseguroProvisionesTecnicas
        Get
            Return Me.participacionReaseguroProvisionesTecnicasField
        End Get
        Set
            Me.participacionReaseguroProvisionesTecnicasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property BienesMantenidosParaVenta() As ModeloBalanceGeneralDatosModeloActivoBienesMantenidosParaVenta
        Get
            Return Me.bienesMantenidosParaVentaField
        End Get
        Set
            Me.bienesMantenidosParaVentaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PropiedadesMobilarioEquipo() As ModeloBalanceGeneralDatosModeloActivoPropiedadesMobilarioEquipo
        Get
            Return Me.propiedadesMobilarioEquipoField
        End Get
        Set
            Me.propiedadesMobilarioEquipoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosActivos() As ModeloBalanceGeneralDatosModeloActivoOtrosActivos
        Get
            Return Me.otrosActivosField
        End Get
        Set
            Me.otrosActivosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PropiedadesDeInversion() As ModeloBalanceGeneralDatosModeloActivoPropiedadesDeInversion
        Get
            Return Me.propiedadesDeInversionField
        End Get
        Set
            Me.propiedadesDeInversionField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ParticipacionOtrasEmpresas() As ModeloBalanceGeneralDatosModeloActivoParticipacionOtrasEmpresas
        Get
            Return Me.participacionOtrasEmpresasField
        End Get
        Set
            Me.participacionOtrasEmpresasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalActivo() As Decimal
        Get
            Return Me.totalActivoField
        End Get
        Set
            Me.totalActivoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoDisponibilidades

    Private desgloseDisponibilidadesField As ModeloBalanceGeneralDatosModeloActivoDisponibilidadesDesgloseDisponibilidades

    Private totalDisponibilidadesField As Decimal

    '''<remarks/>
    Public Property DesgloseDisponibilidades() As ModeloBalanceGeneralDatosModeloActivoDisponibilidadesDesgloseDisponibilidades
        Get
            Return Me.desgloseDisponibilidadesField
        End Get
        Set
            Me.desgloseDisponibilidadesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalDisponibilidades() As Decimal
        Get
            Return Me.totalDisponibilidadesField
        End Get
        Set
            Me.totalDisponibilidadesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoDisponibilidadesDesgloseDisponibilidades

    Private efectivoField As Decimal

    Private depVistaEnBCCRField As Decimal

    Private depVistaEntidadesFinancierasPaisField As Decimal

    Private depVistaEntidadesFinancierasExteriorField As Decimal

    Private docCobroInmediatoField As Decimal

    Private dispRestringidasField As Decimal

    Private ctasProductosCobrarField As Decimal

    '''<remarks/>
    Public Property Efectivo() As Decimal
        Get
            Return Me.efectivoField
        End Get
        Set
            Me.efectivoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DepVistaEnBCCR() As Decimal
        Get
            Return Me.depVistaEnBCCRField
        End Get
        Set
            Me.depVistaEnBCCRField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DepVistaEntidadesFinancierasPais() As Decimal
        Get
            Return Me.depVistaEntidadesFinancierasPaisField
        End Get
        Set
            Me.depVistaEntidadesFinancierasPaisField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DepVistaEntidadesFinancierasExterior() As Decimal
        Get
            Return Me.depVistaEntidadesFinancierasExteriorField
        End Get
        Set
            Me.depVistaEntidadesFinancierasExteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DocCobroInmediato() As Decimal
        Get
            Return Me.docCobroInmediatoField
        End Get
        Set
            Me.docCobroInmediatoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DispRestringidas() As Decimal
        Get
            Return Me.dispRestringidasField
        End Get
        Set
            Me.dispRestringidasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CtasProductosCobrar() As Decimal
        Get
            Return Me.ctasProductosCobrarField
        End Get
        Set
            Me.ctasProductosCobrarField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoInversionesInstrumentosFinancieros

    Private desgloseInversionesInstrumentosFinancierosField As ModeloBalanceGeneralDatosModeloActivoInversionesInstrumentosFinancierosDesgloseInversionesInstrumentosFinancieros

    Private totalInversionesField As Decimal

    '''<remarks/>
    Public Property DesgloseInversionesInstrumentosFinancieros() As ModeloBalanceGeneralDatosModeloActivoInversionesInstrumentosFinancierosDesgloseInversionesInstrumentosFinancieros
        Get
            Return Me.desgloseInversionesInstrumentosFinancierosField
        End Get
        Set
            Me.desgloseInversionesInstrumentosFinancierosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalInversiones() As Decimal
        Get
            Return Me.totalInversionesField
        End Get
        Set
            Me.totalInversionesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoInversionesInstrumentosFinancierosDesgloseInversionesInstrumentosFinancieros

    Private cambiosResultadosField As Decimal

    Private cambiosResultadoIntegralField As Decimal

    Private costoAmortizadoField As Decimal

    Private enCesacionPagosMorososLitigiosField As Decimal

    Private vencidosRestringidosField As Decimal

    Private difPosicionDerivadosField As Decimal

    Private ctasProductosCobrarField As Decimal

    Private estimacionDeterioroField As Decimal

    '''<remarks/>
    Public Property CambiosResultados() As Decimal
        Get
            Return Me.cambiosResultadosField
        End Get
        Set
            Me.cambiosResultadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CambiosResultadoIntegral() As Decimal
        Get
            Return Me.cambiosResultadoIntegralField
        End Get
        Set
            Me.cambiosResultadoIntegralField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CostoAmortizado() As Decimal
        Get
            Return Me.costoAmortizadoField
        End Get
        Set
            Me.costoAmortizadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EnCesacionPagosMorososLitigios() As Decimal
        Get
            Return Me.enCesacionPagosMorososLitigiosField
        End Get
        Set
            Me.enCesacionPagosMorososLitigiosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VencidosRestringidos() As Decimal
        Get
            Return Me.vencidosRestringidosField
        End Get
        Set
            Me.vencidosRestringidosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DifPosicionDerivados() As Decimal
        Get
            Return Me.difPosicionDerivadosField
        End Get
        Set
            Me.difPosicionDerivadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CtasProductosCobrar() As Decimal
        Get
            Return Me.ctasProductosCobrarField
        End Get
        Set
            Me.ctasProductosCobrarField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EstimacionDeterioro() As Decimal
        Get
            Return Me.estimacionDeterioroField
        End Get
        Set
            Me.estimacionDeterioroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoCarteraCreditos

    Private desgloseCarteraCreditosField As ModeloBalanceGeneralDatosModeloActivoCarteraCreditosDesgloseCarteraCreditos

    Private totalCarteraField As Decimal

    '''<remarks/>
    Public Property DesgloseCarteraCreditos() As ModeloBalanceGeneralDatosModeloActivoCarteraCreditosDesgloseCarteraCreditos
        Get
            Return Me.desgloseCarteraCreditosField
        End Get
        Set
            Me.desgloseCarteraCreditosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalCartera() As Decimal
        Get
            Return Me.totalCarteraField
        End Get
        Set
            Me.totalCarteraField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoCarteraCreditosDesgloseCarteraCreditos

    Private vigentesField As Decimal

    Private vencidosField As Decimal

    Private cobroJudicialField As Decimal

    Private restringidosField As Decimal

    Private costosDirectosIncrementalesField As Decimal

    Private ingresosDiferidosField As Decimal

    Private ctasProductosPorCobrarField As Decimal

    Private estimacionDeterioroField As Decimal

    '''<remarks/>
    Public Property Vigentes() As Decimal
        Get
            Return Me.vigentesField
        End Get
        Set
            Me.vigentesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Vencidos() As Decimal
        Get
            Return Me.vencidosField
        End Get
        Set
            Me.vencidosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CobroJudicial() As Decimal
        Get
            Return Me.cobroJudicialField
        End Get
        Set
            Me.cobroJudicialField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Restringidos() As Decimal
        Get
            Return Me.restringidosField
        End Get
        Set
            Me.restringidosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CostosDirectosIncrementales() As Decimal
        Get
            Return Me.costosDirectosIncrementalesField
        End Get
        Set
            Me.costosDirectosIncrementalesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property IngresosDiferidos() As Decimal
        Get
            Return Me.ingresosDiferidosField
        End Get
        Set
            Me.ingresosDiferidosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CtasProductosPorCobrar() As Decimal
        Get
            Return Me.ctasProductosPorCobrarField
        End Get
        Set
            Me.ctasProductosPorCobrarField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EstimacionDeterioro() As Decimal
        Get
            Return Me.estimacionDeterioroField
        End Get
        Set
            Me.estimacionDeterioroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoComisionesPrimasCuentasCobrar

    Private desgloseComisionesPrimasCuentasCobrarField As ModeloBalanceGeneralDatosModeloActivoComisionesPrimasCuentasCobrarDesgloseComisionesPrimasCuentasCobrar

    Private totalComisionesField As Decimal

    '''<remarks/>
    Public Property DesgloseComisionesPrimasCuentasCobrar() As ModeloBalanceGeneralDatosModeloActivoComisionesPrimasCuentasCobrarDesgloseComisionesPrimasCuentasCobrar
        Get
            Return Me.desgloseComisionesPrimasCuentasCobrarField
        End Get
        Set
            Me.desgloseComisionesPrimasCuentasCobrarField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalComisiones() As Decimal
        Get
            Return Me.totalComisionesField
        End Get
        Set
            Me.totalComisionesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoComisionesPrimasCuentasCobrarDesgloseComisionesPrimasCuentasCobrar

    Private comisionesCobrarField As Decimal

    Private primasCobrarField As Decimal

    Private primasVencidasField As Decimal

    Private ctasCobrarOperacionesPartesRelacionadasField As Decimal

    Private impDiferidoImpCobrarField As Decimal

    Private otrasCtasCobrarField As Decimal

    Private productosCobrarAsociadosCuentasCobrarField As Decimal

    Private estimacionDeterioroField As Decimal

    '''<remarks/>
    Public Property ComisionesCobrar() As Decimal
        Get
            Return Me.comisionesCobrarField
        End Get
        Set
            Me.comisionesCobrarField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasCobrar() As Decimal
        Get
            Return Me.primasCobrarField
        End Get
        Set
            Me.primasCobrarField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrimasVencidas() As Decimal
        Get
            Return Me.primasVencidasField
        End Get
        Set
            Me.primasVencidasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CtasCobrarOperacionesPartesRelacionadas() As Decimal
        Get
            Return Me.ctasCobrarOperacionesPartesRelacionadasField
        End Get
        Set
            Me.ctasCobrarOperacionesPartesRelacionadasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ImpDiferidoImpCobrar() As Decimal
        Get
            Return Me.impDiferidoImpCobrarField
        End Get
        Set
            Me.impDiferidoImpCobrarField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrasCtasCobrar() As Decimal
        Get
            Return Me.otrasCtasCobrarField
        End Get
        Set
            Me.otrasCtasCobrarField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProductosCobrarAsociadosCuentasCobrar() As Decimal
        Get
            Return Me.productosCobrarAsociadosCuentasCobrarField
        End Get
        Set
            Me.productosCobrarAsociadosCuentasCobrarField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EstimacionDeterioro() As Decimal
        Get
            Return Me.estimacionDeterioroField
        End Get
        Set
            Me.estimacionDeterioroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesCoaseguroActivo

    Private desgloseCuentasAcreedorasDeudorasOperacionesCoaseguroActivoField As ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesCoaseguroActivoDesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroActivo

    Private totalCuentasAcreedorasDeudorasOperacionesCoaseguroActivoField As Decimal

    '''<remarks/>
    Public Property DesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroActivo() As ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesCoaseguroActivoDesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroActivo
        Get
            Return Me.desgloseCuentasAcreedorasDeudorasOperacionesCoaseguroActivoField
        End Get
        Set
            Me.desgloseCuentasAcreedorasDeudorasOperacionesCoaseguroActivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalCuentasAcreedorasDeudorasOperacionesCoaseguroActivo() As Decimal
        Get
            Return Me.totalCuentasAcreedorasDeudorasOperacionesCoaseguroActivoField
        End Get
        Set
            Me.totalCuentasAcreedorasDeudorasOperacionesCoaseguroActivoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesCoaseguroActivoDesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroActivo

    Private cuentasCorrientesOperacionesCoaseguroActivoField As Decimal

    '''<remarks/>
    Public Property CuentasCorrientesOperacionesCoaseguroActivo() As Decimal
        Get
            Return Me.cuentasCorrientesOperacionesCoaseguroActivoField
        End Get
        Set
            Me.cuentasCorrientesOperacionesCoaseguroActivoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesReaseguroActivo

    Private desgloseCuentasAcreedorasDeudorasOperacionesReaseguroActivoField As ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesReaseguroActivoDesgloseCuentasAcreedorasDeudorasOperacionesReaseguroActivo

    Private totalCuentasAcreedorasDeudorasOperacionesReaseguroActivoField As Decimal

    '''<remarks/>
    Public Property DesgloseCuentasAcreedorasDeudorasOperacionesReaseguroActivo() As ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesReaseguroActivoDesgloseCuentasAcreedorasDeudorasOperacionesReaseguroActivo
        Get
            Return Me.desgloseCuentasAcreedorasDeudorasOperacionesReaseguroActivoField
        End Get
        Set
            Me.desgloseCuentasAcreedorasDeudorasOperacionesReaseguroActivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalCuentasAcreedorasDeudorasOperacionesReaseguroActivo() As Decimal
        Get
            Return Me.totalCuentasAcreedorasDeudorasOperacionesReaseguroActivoField
        End Get
        Set
            Me.totalCuentasAcreedorasDeudorasOperacionesReaseguroActivoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoCuentasAcreedorasDeudorasOperacionesReaseguroActivoDesgloseCuentasAcreedorasDeudorasOperacionesReaseguroActivo

    Private cuentasAcreedorasDeudorasReaseguroCedidoRetrocedidoField As Decimal

    Private cuentasAcreedorasDeudorasReaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property CuentasAcreedorasDeudorasReaseguroCedidoRetrocedido() As Decimal
        Get
            Return Me.cuentasAcreedorasDeudorasReaseguroCedidoRetrocedidoField
        End Get
        Set
            Me.cuentasAcreedorasDeudorasReaseguroCedidoRetrocedidoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CuentasAcreedorasDeudorasReaseguroAceptado() As Decimal
        Get
            Return Me.cuentasAcreedorasDeudorasReaseguroAceptadoField
        End Get
        Set
            Me.cuentasAcreedorasDeudorasReaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoParticipacionReaseguroProvisionesTecnicas

    Private desgloseParticipacionReaseguroProvisionesTecnicasField As ModeloBalanceGeneralDatosModeloActivoParticipacionReaseguroProvisionesTecnicasDesgloseParticipacionReaseguroProvisionesTecnicas

    Private totalParticipacionField As Decimal

    '''<remarks/>
    Public Property DesgloseParticipacionReaseguroProvisionesTecnicas() As ModeloBalanceGeneralDatosModeloActivoParticipacionReaseguroProvisionesTecnicasDesgloseParticipacionReaseguroProvisionesTecnicas
        Get
            Return Me.desgloseParticipacionReaseguroProvisionesTecnicasField
        End Get
        Set
            Me.desgloseParticipacionReaseguroProvisionesTecnicasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalParticipacion() As Decimal
        Get
            Return Me.totalParticipacionField
        End Get
        Set
            Me.totalParticipacionField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoParticipacionReaseguroProvisionesTecnicasDesgloseParticipacionReaseguroProvisionesTecnicas

    Private provisionPrimasNoDevengadasField As Decimal

    Private provisionMatematicaField As Decimal

    Private provisionSiniestrosField As Decimal

    Private otrasProvisionesTecnicasField As Decimal

    '''<remarks/>
    Public Property ProvisionPrimasNoDevengadas() As Decimal
        Get
            Return Me.provisionPrimasNoDevengadasField
        End Get
        Set
            Me.provisionPrimasNoDevengadasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionMatematica() As Decimal
        Get
            Return Me.provisionMatematicaField
        End Get
        Set
            Me.provisionMatematicaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionSiniestros() As Decimal
        Get
            Return Me.provisionSiniestrosField
        End Get
        Set
            Me.provisionSiniestrosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrasProvisionesTecnicas() As Decimal
        Get
            Return Me.otrasProvisionesTecnicasField
        End Get
        Set
            Me.otrasProvisionesTecnicasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoBienesMantenidosParaVenta

    Private desgloseBienesMantenidosParaVentaField As ModeloBalanceGeneralDatosModeloActivoBienesMantenidosParaVentaDesgloseBienesMantenidosParaVenta

    Private totalBienesMantenidosParaVentaField As Decimal

    '''<remarks/>
    Public Property DesgloseBienesMantenidosParaVenta() As ModeloBalanceGeneralDatosModeloActivoBienesMantenidosParaVentaDesgloseBienesMantenidosParaVenta
        Get
            Return Me.desgloseBienesMantenidosParaVentaField
        End Get
        Set
            Me.desgloseBienesMantenidosParaVentaField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalBienesMantenidosParaVenta() As Decimal
        Get
            Return Me.totalBienesMantenidosParaVentaField
        End Get
        Set
            Me.totalBienesMantenidosParaVentaField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoBienesMantenidosParaVentaDesgloseBienesMantenidosParaVenta

    Private adquiridosRecuperacionCreditosField As Decimal

    Private propiedadesMobiliarioEquipoFueraDeUsoField As Decimal

    Private otrosBienesField As Decimal

    Private productosCobrarAsociadosField As Decimal

    Private estimacionDeterioroField As Decimal

    '''<remarks/>
    Public Property AdquiridosRecuperacionCreditos() As Decimal
        Get
            Return Me.adquiridosRecuperacionCreditosField
        End Get
        Set
            Me.adquiridosRecuperacionCreditosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PropiedadesMobiliarioEquipoFueraDeUso() As Decimal
        Get
            Return Me.propiedadesMobiliarioEquipoFueraDeUsoField
        End Get
        Set
            Me.propiedadesMobiliarioEquipoFueraDeUsoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosBienes() As Decimal
        Get
            Return Me.otrosBienesField
        End Get
        Set
            Me.otrosBienesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProductosCobrarAsociados() As Decimal
        Get
            Return Me.productosCobrarAsociadosField
        End Get
        Set
            Me.productosCobrarAsociadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EstimacionDeterioro() As Decimal
        Get
            Return Me.estimacionDeterioroField
        End Get
        Set
            Me.estimacionDeterioroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoPropiedadesMobilarioEquipo

    Private desglosePropiedadesMobilarioEquipoField As ModeloBalanceGeneralDatosModeloActivoPropiedadesMobilarioEquipoDesglosePropiedadesMobilarioEquipo

    Private totalPropiedadesMobilarioEquipoField As Decimal

    '''<remarks/>
    Public Property DesglosePropiedadesMobilarioEquipo() As ModeloBalanceGeneralDatosModeloActivoPropiedadesMobilarioEquipoDesglosePropiedadesMobilarioEquipo
        Get
            Return Me.desglosePropiedadesMobilarioEquipoField
        End Get
        Set
            Me.desglosePropiedadesMobilarioEquipoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPropiedadesMobilarioEquipo() As Decimal
        Get
            Return Me.totalPropiedadesMobilarioEquipoField
        End Get
        Set
            Me.totalPropiedadesMobilarioEquipoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoPropiedadesMobilarioEquipoDesglosePropiedadesMobilarioEquipo

    Private mobiliarioField As Decimal

    Private computacionField As Decimal

    Private vehiculosField As Decimal

    Private porDerechoDeUsoField As Decimal

    Private terrenosField As Decimal

    Private edificiosInstalacionesField As Decimal

    Private otrosActivosOperativosField As Decimal

    Private depreciacionAcumuladaField As Decimal

    '''<remarks/>
    Public Property Mobiliario() As Decimal
        Get
            Return Me.mobiliarioField
        End Get
        Set
            Me.mobiliarioField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Computacion() As Decimal
        Get
            Return Me.computacionField
        End Get
        Set
            Me.computacionField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Vehiculos() As Decimal
        Get
            Return Me.vehiculosField
        End Get
        Set
            Me.vehiculosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PorDerechoDeUso() As Decimal
        Get
            Return Me.porDerechoDeUsoField
        End Get
        Set
            Me.porDerechoDeUsoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Terrenos() As Decimal
        Get
            Return Me.terrenosField
        End Get
        Set
            Me.terrenosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EdificiosInstalaciones() As Decimal
        Get
            Return Me.edificiosInstalacionesField
        End Get
        Set
            Me.edificiosInstalacionesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosActivosOperativos() As Decimal
        Get
            Return Me.otrosActivosOperativosField
        End Get
        Set
            Me.otrosActivosOperativosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DepreciacionAcumulada() As Decimal
        Get
            Return Me.depreciacionAcumuladaField
        End Get
        Set
            Me.depreciacionAcumuladaField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoOtrosActivos

    Private desgloseOtrosActivosField As ModeloBalanceGeneralDatosModeloActivoOtrosActivosDesgloseOtrosActivos

    Private totalOtrosActivosField As Decimal

    '''<remarks/>
    Public Property DesgloseOtrosActivos() As ModeloBalanceGeneralDatosModeloActivoOtrosActivosDesgloseOtrosActivos
        Get
            Return Me.desgloseOtrosActivosField
        End Get
        Set
            Me.desgloseOtrosActivosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOtrosActivos() As Decimal
        Get
            Return Me.totalOtrosActivosField
        End Get
        Set
            Me.totalOtrosActivosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoOtrosActivosDesgloseOtrosActivos

    Private gastosPagadosAnticipadoField As Decimal

    Private cargosDiferidosField As Decimal

    Private bienesDiversosField As Decimal

    Private operacionesPendientesImputacionField As Decimal

    Private ctasReciprocasInternasField As Decimal

    Private activosIntangiblesField As Decimal

    Private otrosActivosRestringidosField As Decimal

    Private estimacionPrimasPolizasFlotantesField As Decimal

    Private comisionEstimacionPrimasPolizasFlotantesField As Decimal

    Private depositosConstituidosReaseguroField As Decimal

    '''<remarks/>
    Public Property GastosPagadosAnticipado() As Decimal
        Get
            Return Me.gastosPagadosAnticipadoField
        End Get
        Set
            Me.gastosPagadosAnticipadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CargosDiferidos() As Decimal
        Get
            Return Me.cargosDiferidosField
        End Get
        Set
            Me.cargosDiferidosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property BienesDiversos() As Decimal
        Get
            Return Me.bienesDiversosField
        End Get
        Set
            Me.bienesDiversosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OperacionesPendientesImputacion() As Decimal
        Get
            Return Me.operacionesPendientesImputacionField
        End Get
        Set
            Me.operacionesPendientesImputacionField = Value
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
    Public Property ActivosIntangibles() As Decimal
        Get
            Return Me.activosIntangiblesField
        End Get
        Set
            Me.activosIntangiblesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosActivosRestringidos() As Decimal
        Get
            Return Me.otrosActivosRestringidosField
        End Get
        Set
            Me.otrosActivosRestringidosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EstimacionPrimasPolizasFlotantes() As Decimal
        Get
            Return Me.estimacionPrimasPolizasFlotantesField
        End Get
        Set
            Me.estimacionPrimasPolizasFlotantesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ComisionEstimacionPrimasPolizasFlotantes() As Decimal
        Get
            Return Me.comisionEstimacionPrimasPolizasFlotantesField
        End Get
        Set
            Me.comisionEstimacionPrimasPolizasFlotantesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DepositosConstituidosReaseguro() As Decimal
        Get
            Return Me.depositosConstituidosReaseguroField
        End Get
        Set
            Me.depositosConstituidosReaseguroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoPropiedadesDeInversion

    Private desglosePropiedadesDeInversionField As ModeloBalanceGeneralDatosModeloActivoPropiedadesDeInversionDesglosePropiedadesDeInversion

    Private totalPropiedadesDeInversionField As Decimal

    '''<remarks/>
    Public Property DesglosePropiedadesDeInversion() As ModeloBalanceGeneralDatosModeloActivoPropiedadesDeInversionDesglosePropiedadesDeInversion
        Get
            Return Me.desglosePropiedadesDeInversionField
        End Get
        Set
            Me.desglosePropiedadesDeInversionField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPropiedadesDeInversion() As Decimal
        Get
            Return Me.totalPropiedadesDeInversionField
        End Get
        Set
            Me.totalPropiedadesDeInversionField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoPropiedadesDeInversionDesglosePropiedadesDeInversion

    Private terrenosField As Decimal

    Private edificiosField As Decimal

    '''<remarks/>
    Public Property Terrenos() As Decimal
        Get
            Return Me.terrenosField
        End Get
        Set
            Me.terrenosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Edificios() As Decimal
        Get
            Return Me.edificiosField
        End Get
        Set
            Me.edificiosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoParticipacionOtrasEmpresas

    Private desgloseParticipacionOtrasEmpresasField As ModeloBalanceGeneralDatosModeloActivoParticipacionOtrasEmpresasDesgloseParticipacionOtrasEmpresas

    Private totalPartOtrasEmpresasField As Decimal

    '''<remarks/>
    Public Property DesgloseParticipacionOtrasEmpresas() As ModeloBalanceGeneralDatosModeloActivoParticipacionOtrasEmpresasDesgloseParticipacionOtrasEmpresas
        Get
            Return Me.desgloseParticipacionOtrasEmpresasField
        End Get
        Set
            Me.desgloseParticipacionOtrasEmpresasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPartOtrasEmpresas() As Decimal
        Get
            Return Me.totalPartOtrasEmpresasField
        End Get
        Set
            Me.totalPartOtrasEmpresasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloActivoParticipacionOtrasEmpresasDesgloseParticipacionOtrasEmpresas

    Private delPaisField As Decimal

    Private delExteriorField As Decimal

    Private minimoDeFuncionamientoOPCField As Decimal

    Private vehiculosPropositoEspecialPaisField As Decimal

    Private deterioroField As Decimal

    '''<remarks/>
    Public Property DelPais() As Decimal
        Get
            Return Me.delPaisField
        End Get
        Set
            Me.delPaisField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DelExterior() As Decimal
        Get
            Return Me.delExteriorField
        End Get
        Set
            Me.delExteriorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property MinimoDeFuncionamientoOPC() As Decimal
        Get
            Return Me.minimoDeFuncionamientoOPCField
        End Get
        Set
            Me.minimoDeFuncionamientoOPCField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property VehiculosPropositoEspecialPais() As Decimal
        Get
            Return Me.vehiculosPropositoEspecialPaisField
        End Get
        Set
            Me.vehiculosPropositoEspecialPaisField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Deterioro() As Decimal
        Get
            Return Me.deterioroField
        End Get
        Set
            Me.deterioroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivo

    Private obligacionesPublicoField As ModeloBalanceGeneralDatosModeloPasivoObligacionesPublico

    Private obligacionesEntidadesField As ModeloBalanceGeneralDatosModeloPasivoObligacionesEntidades

    Private cuentasPorPagarYProvisionesField As ModeloBalanceGeneralDatosModeloPasivoCuentasPorPagarYProvisiones

    Private provisionesTecnicasField As ModeloBalanceGeneralDatosModeloPasivoProvisionesTecnicas

    Private cuentasAcreedorasDeudorasOperacionesReaseguroPasivoField As ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesReaseguroPasivo

    Private cuentasAcreedorasDeudorasOperacionesCoaseguroPasivoField As ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo

    Private aseguradosAgentesIntermediariosField As ModeloBalanceGeneralDatosModeloPasivoAseguradosAgentesIntermediarios

    Private otrosPasivosField As ModeloBalanceGeneralDatosModeloPasivoOtrosPasivos

    Private obligacionesSubordinadasField As ModeloBalanceGeneralDatosModeloPasivoObligacionesSubordinadas

    Private obligacionesConvertiblesEnCapitalField As ModeloBalanceGeneralDatosModeloPasivoObligacionesConvertiblesEnCapital

    Private obligacionesPreferentesField As ModeloBalanceGeneralDatosModeloPasivoObligacionesPreferentes

    Private totalPasivoField As Decimal

    '''<remarks/>
    Public Property ObligacionesPublico() As ModeloBalanceGeneralDatosModeloPasivoObligacionesPublico
        Get
            Return Me.obligacionesPublicoField
        End Get
        Set
            Me.obligacionesPublicoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ObligacionesEntidades() As ModeloBalanceGeneralDatosModeloPasivoObligacionesEntidades
        Get
            Return Me.obligacionesEntidadesField
        End Get
        Set
            Me.obligacionesEntidadesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CuentasPorPagarYProvisiones() As ModeloBalanceGeneralDatosModeloPasivoCuentasPorPagarYProvisiones
        Get
            Return Me.cuentasPorPagarYProvisionesField
        End Get
        Set
            Me.cuentasPorPagarYProvisionesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionesTecnicas() As ModeloBalanceGeneralDatosModeloPasivoProvisionesTecnicas
        Get
            Return Me.provisionesTecnicasField
        End Get
        Set
            Me.provisionesTecnicasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CuentasAcreedorasDeudorasOperacionesReaseguroPasivo() As ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesReaseguroPasivo
        Get
            Return Me.cuentasAcreedorasDeudorasOperacionesReaseguroPasivoField
        End Get
        Set
            Me.cuentasAcreedorasDeudorasOperacionesReaseguroPasivoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CuentasAcreedorasDeudorasOperacionesCoaseguroPasivo() As ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo
        Get
            Return Me.cuentasAcreedorasDeudorasOperacionesCoaseguroPasivoField
        End Get
        Set
            Me.cuentasAcreedorasDeudorasOperacionesCoaseguroPasivoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AseguradosAgentesIntermediarios() As ModeloBalanceGeneralDatosModeloPasivoAseguradosAgentesIntermediarios
        Get
            Return Me.aseguradosAgentesIntermediariosField
        End Get
        Set
            Me.aseguradosAgentesIntermediariosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrosPasivos() As ModeloBalanceGeneralDatosModeloPasivoOtrosPasivos
        Get
            Return Me.otrosPasivosField
        End Get
        Set
            Me.otrosPasivosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ObligacionesSubordinadas() As ModeloBalanceGeneralDatosModeloPasivoObligacionesSubordinadas
        Get
            Return Me.obligacionesSubordinadasField
        End Get
        Set
            Me.obligacionesSubordinadasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ObligacionesConvertiblesEnCapital() As ModeloBalanceGeneralDatosModeloPasivoObligacionesConvertiblesEnCapital
        Get
            Return Me.obligacionesConvertiblesEnCapitalField
        End Get
        Set
            Me.obligacionesConvertiblesEnCapitalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ObligacionesPreferentes() As ModeloBalanceGeneralDatosModeloPasivoObligacionesPreferentes
        Get
            Return Me.obligacionesPreferentesField
        End Get
        Set
            Me.obligacionesPreferentesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPasivo() As Decimal
        Get
            Return Me.totalPasivoField
        End Get
        Set
            Me.totalPasivoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoObligacionesPublico

    Private desgloseObligacionesPublicoField As ModeloBalanceGeneralDatosModeloPasivoObligacionesPublicoDesgloseObligacionesPublico

    Private totalOblPublicoField As Decimal

    '''<remarks/>
    Public Property DesgloseObligacionesPublico() As ModeloBalanceGeneralDatosModeloPasivoObligacionesPublicoDesgloseObligacionesPublico
        Get
            Return Me.desgloseObligacionesPublicoField
        End Get
        Set
            Me.desgloseObligacionesPublicoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOblPublico() As Decimal
        Get
            Return Me.totalOblPublicoField
        End Get
        Set
            Me.totalOblPublicoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoObligacionesPublicoDesgloseObligacionesPublico

    Private reportoPactoTripartitoPrestamoValoresField As Decimal

    Private obligacionesPlazoField As Decimal

    Private cargosPorPagarField As Decimal

    '''<remarks/>
    Public Property ReportoPactoTripartitoPrestamoValores() As Decimal
        Get
            Return Me.reportoPactoTripartitoPrestamoValoresField
        End Get
        Set
            Me.reportoPactoTripartitoPrestamoValoresField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ObligacionesPlazo() As Decimal
        Get
            Return Me.obligacionesPlazoField
        End Get
        Set
            Me.obligacionesPlazoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CargosPorPagar() As Decimal
        Get
            Return Me.cargosPorPagarField
        End Get
        Set
            Me.cargosPorPagarField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoObligacionesEntidades

    Private desgloseObligacionesEntidadesField As ModeloBalanceGeneralDatosModeloPasivoObligacionesEntidadesDesgloseObligacionesEntidades

    Private totalOblEntidadesField As Decimal

    '''<remarks/>
    Public Property DesgloseObligacionesEntidades() As ModeloBalanceGeneralDatosModeloPasivoObligacionesEntidadesDesgloseObligacionesEntidades
        Get
            Return Me.desgloseObligacionesEntidadesField
        End Get
        Set
            Me.desgloseObligacionesEntidadesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOblEntidades() As Decimal
        Get
            Return Me.totalOblEntidadesField
        End Get
        Set
            Me.totalOblEntidadesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoObligacionesEntidadesDesgloseObligacionesEntidades

    Private vistaField As Decimal

    Private aPlazoField As Decimal

    Private entidadesNoFinancierasField As Decimal

    Private gastosDifCarteraPropiaField As Decimal

    Private cargosPorPagarField As Decimal

    '''<remarks/>
    Public Property Vista() As Decimal
        Get
            Return Me.vistaField
        End Get
        Set
            Me.vistaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property APlazo() As Decimal
        Get
            Return Me.aPlazoField
        End Get
        Set
            Me.aPlazoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EntidadesNoFinancieras() As Decimal
        Get
            Return Me.entidadesNoFinancierasField
        End Get
        Set
            Me.entidadesNoFinancierasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property GastosDifCarteraPropia() As Decimal
        Get
            Return Me.gastosDifCarteraPropiaField
        End Get
        Set
            Me.gastosDifCarteraPropiaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CargosPorPagar() As Decimal
        Get
            Return Me.cargosPorPagarField
        End Get
        Set
            Me.cargosPorPagarField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoCuentasPorPagarYProvisiones

    Private desgloseCuentasPorPagarYProvisionesField As ModeloBalanceGeneralDatosModeloPasivoCuentasPorPagarYProvisionesDesgloseCuentasPorPagarYProvisiones

    Private totalCuentasPagarProvField As Decimal

    '''<remarks/>
    Public Property DesgloseCuentasPorPagarYProvisiones() As ModeloBalanceGeneralDatosModeloPasivoCuentasPorPagarYProvisionesDesgloseCuentasPorPagarYProvisiones
        Get
            Return Me.desgloseCuentasPorPagarYProvisionesField
        End Get
        Set
            Me.desgloseCuentasPorPagarYProvisionesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalCuentasPagarProv() As Decimal
        Get
            Return Me.totalCuentasPagarProvField
        End Get
        Set
            Me.totalCuentasPagarProvField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoCuentasPorPagarYProvisionesDesgloseCuentasPorPagarYProvisiones

    Private difPosicionDerivadosField As Decimal

    Private ctasComisionesPorPagarDiversasField As Decimal

    Private provisionesField As Decimal

    Private rentaDiferidoField As Decimal

    Private cargosPagarDiversosField As Decimal

    Private otrasCuentasPorCobrarField As Decimal

    '''<remarks/>
    Public Property DifPosicionDerivados() As Decimal
        Get
            Return Me.difPosicionDerivadosField
        End Get
        Set
            Me.difPosicionDerivadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CtasComisionesPorPagarDiversas() As Decimal
        Get
            Return Me.ctasComisionesPorPagarDiversasField
        End Get
        Set
            Me.ctasComisionesPorPagarDiversasField = Value
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
    Public Property RentaDiferido() As Decimal
        Get
            Return Me.rentaDiferidoField
        End Get
        Set
            Me.rentaDiferidoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CargosPagarDiversos() As Decimal
        Get
            Return Me.cargosPagarDiversosField
        End Get
        Set
            Me.cargosPagarDiversosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrasCuentasPorCobrar() As Decimal
        Get
            Return Me.otrasCuentasPorCobrarField
        End Get
        Set
            Me.otrasCuentasPorCobrarField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoProvisionesTecnicas

    Private desgloseProvisionesTecnicasField As ModeloBalanceGeneralDatosModeloPasivoProvisionesTecnicasDesgloseProvisionesTecnicas

    Private totalProvTecnicasField As Decimal

    '''<remarks/>
    Public Property DesgloseProvisionesTecnicas() As ModeloBalanceGeneralDatosModeloPasivoProvisionesTecnicasDesgloseProvisionesTecnicas
        Get
            Return Me.desgloseProvisionesTecnicasField
        End Get
        Set
            Me.desgloseProvisionesTecnicasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalProvTecnicas() As Decimal
        Get
            Return Me.totalProvTecnicasField
        End Get
        Set
            Me.totalProvTecnicasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoProvisionesTecnicasDesgloseProvisionesTecnicas

    Private provisionesPrimasNoDevengadasField As Decimal

    Private provisionesInsuficienciaPrimasField As Decimal

    Private matematicasField As Decimal

    Private provisionSiniestrosReportadosField As Decimal

    Private provisionOYNRField As Decimal

    Private provisionParticipacionEnBeneficiosYExtornosField As Decimal

    Private provisionSegurosVidaRiesgoInversionAsumeTomadorField As Decimal

    Private otrasProvisionesTecnicasField As Decimal

    Private riesgosCatastroficosField As Decimal

    '''<remarks/>
    Public Property ProvisionesPrimasNoDevengadas() As Decimal
        Get
            Return Me.provisionesPrimasNoDevengadasField
        End Get
        Set
            Me.provisionesPrimasNoDevengadasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionesInsuficienciaPrimas() As Decimal
        Get
            Return Me.provisionesInsuficienciaPrimasField
        End Get
        Set
            Me.provisionesInsuficienciaPrimasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Matematicas() As Decimal
        Get
            Return Me.matematicasField
        End Get
        Set
            Me.matematicasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionSiniestrosReportados() As Decimal
        Get
            Return Me.provisionSiniestrosReportadosField
        End Get
        Set
            Me.provisionSiniestrosReportadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionOYNR() As Decimal
        Get
            Return Me.provisionOYNRField
        End Get
        Set
            Me.provisionOYNRField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionParticipacionEnBeneficiosYExtornos() As Decimal
        Get
            Return Me.provisionParticipacionEnBeneficiosYExtornosField
        End Get
        Set
            Me.provisionParticipacionEnBeneficiosYExtornosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ProvisionSegurosVidaRiesgoInversionAsumeTomador() As Decimal
        Get
            Return Me.provisionSegurosVidaRiesgoInversionAsumeTomadorField
        End Get
        Set
            Me.provisionSegurosVidaRiesgoInversionAsumeTomadorField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrasProvisionesTecnicas() As Decimal
        Get
            Return Me.otrasProvisionesTecnicasField
        End Get
        Set
            Me.otrasProvisionesTecnicasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property RiesgosCatastroficos() As Decimal
        Get
            Return Me.riesgosCatastroficosField
        End Get
        Set
            Me.riesgosCatastroficosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesReaseguroPasivo

    Private desgloseCuentasAcreedorasDeudorasOperacionesReaseguroPasivoField As ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesReaseguroPasivoDesgloseCuentasAcreedorasDeudorasOperacionesReaseguroPasivo

    Private totalCuentasAcreedorasDeudorasOperacionesReaseguroPasivoField As Decimal

    '''<remarks/>
    Public Property DesgloseCuentasAcreedorasDeudorasOperacionesReaseguroPasivo() As ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesReaseguroPasivoDesgloseCuentasAcreedorasDeudorasOperacionesReaseguroPasivo
        Get
            Return Me.desgloseCuentasAcreedorasDeudorasOperacionesReaseguroPasivoField
        End Get
        Set
            Me.desgloseCuentasAcreedorasDeudorasOperacionesReaseguroPasivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalCuentasAcreedorasDeudorasOperacionesReaseguroPasivo() As Decimal
        Get
            Return Me.totalCuentasAcreedorasDeudorasOperacionesReaseguroPasivoField
        End Get
        Set
            Me.totalCuentasAcreedorasDeudorasOperacionesReaseguroPasivoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesReaseguroPasivoDesgloseCuentasAcreedorasDeudorasOperacionesReaseguroPasivo

    Private cuentasAcreedorasDeudorasReaseguroCedidoRetrocedidoField As Decimal

    Private cuentasAcreedorasDeudorasReaseguroAceptadoField As Decimal

    '''<remarks/>
    Public Property CuentasAcreedorasDeudorasReaseguroCedidoRetrocedido() As Decimal
        Get
            Return Me.cuentasAcreedorasDeudorasReaseguroCedidoRetrocedidoField
        End Get
        Set
            Me.cuentasAcreedorasDeudorasReaseguroCedidoRetrocedidoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CuentasAcreedorasDeudorasReaseguroAceptado() As Decimal
        Get
            Return Me.cuentasAcreedorasDeudorasReaseguroAceptadoField
        End Get
        Set
            Me.cuentasAcreedorasDeudorasReaseguroAceptadoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo

    Private desgloseCuentasAcreedorasDeudorasOperacionesCoaseguroPasivoField As ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesCoaseguroPasivoDesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo

    Private totalCuentasAcreedorasDeudorasOperacionesCoaseguroPasivoField As Decimal

    '''<remarks/>
    Public Property DesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo() As ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesCoaseguroPasivoDesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo
        Get
            Return Me.desgloseCuentasAcreedorasDeudorasOperacionesCoaseguroPasivoField
        End Get
        Set
            Me.desgloseCuentasAcreedorasDeudorasOperacionesCoaseguroPasivoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo() As Decimal
        Get
            Return Me.totalCuentasAcreedorasDeudorasOperacionesCoaseguroPasivoField
        End Get
        Set
            Me.totalCuentasAcreedorasDeudorasOperacionesCoaseguroPasivoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoCuentasAcreedorasDeudorasOperacionesCoaseguroPasivoDesgloseCuentasAcreedorasDeudorasOperacionesCoaseguroPasivo

    Private cuentaCorrienteOperacionesCoaseguroField As Decimal

    '''<remarks/>
    Public Property CuentaCorrienteOperacionesCoaseguro() As Decimal
        Get
            Return Me.cuentaCorrienteOperacionesCoaseguroField
        End Get
        Set
            Me.cuentaCorrienteOperacionesCoaseguroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoAseguradosAgentesIntermediarios

    Private desgloseAseguradosAgentesIntermediariosField As ModeloBalanceGeneralDatosModeloPasivoAseguradosAgentesIntermediariosDesgloseAseguradosAgentesIntermediarios

    Private totalAseguradosField As Decimal

    '''<remarks/>
    Public Property DesgloseAseguradosAgentesIntermediarios() As ModeloBalanceGeneralDatosModeloPasivoAseguradosAgentesIntermediariosDesgloseAseguradosAgentesIntermediarios
        Get
            Return Me.desgloseAseguradosAgentesIntermediariosField
        End Get
        Set
            Me.desgloseAseguradosAgentesIntermediariosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAsegurados() As Decimal
        Get
            Return Me.totalAseguradosField
        End Get
        Set
            Me.totalAseguradosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoAseguradosAgentesIntermediariosDesgloseAseguradosAgentesIntermediarios

    Private aseguradosField As Decimal

    Private agentesEIntermediariosField As Decimal

    '''<remarks/>
    Public Property Asegurados() As Decimal
        Get
            Return Me.aseguradosField
        End Get
        Set
            Me.aseguradosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AgentesEIntermediarios() As Decimal
        Get
            Return Me.agentesEIntermediariosField
        End Get
        Set
            Me.agentesEIntermediariosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoOtrosPasivos

    Private desgloseOtrosPasivosField As ModeloBalanceGeneralDatosModeloPasivoOtrosPasivosDesgloseOtrosPasivos

    Private totalOtrosPasivosField As Decimal

    '''<remarks/>
    Public Property DesgloseOtrosPasivos() As ModeloBalanceGeneralDatosModeloPasivoOtrosPasivosDesgloseOtrosPasivos
        Get
            Return Me.desgloseOtrosPasivosField
        End Get
        Set
            Me.desgloseOtrosPasivosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOtrosPasivos() As Decimal
        Get
            Return Me.totalOtrosPasivosField
        End Get
        Set
            Me.totalOtrosPasivosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoOtrosPasivosDesgloseOtrosPasivos

    Private ingresosDiferidosField As Decimal

    Private operacionesPendientesImputacionField As Decimal

    Private ctasReciprocasInternasField As Decimal

    Private pasivoPagosValorRazonableInstrumentosPatrimonioField As Decimal

    Private estimacionPrimasPolizasAbiertasoFlotantesField As Decimal

    Private comisionPrimasPolizasAbiertasoFlotantesField As Decimal

    Private depositosRecibidosReaseguroField As Decimal

    '''<remarks/>
    Public Property IngresosDiferidos() As Decimal
        Get
            Return Me.ingresosDiferidosField
        End Get
        Set
            Me.ingresosDiferidosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OperacionesPendientesImputacion() As Decimal
        Get
            Return Me.operacionesPendientesImputacionField
        End Get
        Set
            Me.operacionesPendientesImputacionField = Value
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
    Public Property PasivoPagosValorRazonableInstrumentosPatrimonio() As Decimal
        Get
            Return Me.pasivoPagosValorRazonableInstrumentosPatrimonioField
        End Get
        Set
            Me.pasivoPagosValorRazonableInstrumentosPatrimonioField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EstimacionPrimasPolizasAbiertasoFlotantes() As Decimal
        Get
            Return Me.estimacionPrimasPolizasAbiertasoFlotantesField
        End Get
        Set
            Me.estimacionPrimasPolizasAbiertasoFlotantesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ComisionPrimasPolizasAbiertasoFlotantes() As Decimal
        Get
            Return Me.comisionPrimasPolizasAbiertasoFlotantesField
        End Get
        Set
            Me.comisionPrimasPolizasAbiertasoFlotantesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DepositosRecibidosReaseguro() As Decimal
        Get
            Return Me.depositosRecibidosReaseguroField
        End Get
        Set
            Me.depositosRecibidosReaseguroField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoObligacionesSubordinadas

    Private desgloseObligacionesSubordinadasField As ModeloBalanceGeneralDatosModeloPasivoObligacionesSubordinadasDesgloseObligacionesSubordinadas

    Private totalOblSubordinadasField As Decimal

    '''<remarks/>
    Public Property DesgloseObligacionesSubordinadas() As ModeloBalanceGeneralDatosModeloPasivoObligacionesSubordinadasDesgloseObligacionesSubordinadas
        Get
            Return Me.desgloseObligacionesSubordinadasField
        End Get
        Set
            Me.desgloseObligacionesSubordinadasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOblSubordinadas() As Decimal
        Get
            Return Me.totalOblSubordinadasField
        End Get
        Set
            Me.totalOblSubordinadasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoObligacionesSubordinadasDesgloseObligacionesSubordinadas

    Private obligacionesSubordinadasField As Decimal

    Private prestamosSubordinadosField As Decimal

    Private cargosPagarField As Decimal

    '''<remarks/>
    Public Property ObligacionesSubordinadas() As Decimal
        Get
            Return Me.obligacionesSubordinadasField
        End Get
        Set
            Me.obligacionesSubordinadasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PrestamosSubordinados() As Decimal
        Get
            Return Me.prestamosSubordinadosField
        End Get
        Set
            Me.prestamosSubordinadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CargosPagar() As Decimal
        Get
            Return Me.cargosPagarField
        End Get
        Set
            Me.cargosPagarField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoObligacionesConvertiblesEnCapital

    Private desgloseObligacionesConvertiblesEnCapitalField As ModeloBalanceGeneralDatosModeloPasivoObligacionesConvertiblesEnCapitalDesgloseObligacionesConvertiblesEnCapital

    Private totalOblConvertiblesField As Decimal

    '''<remarks/>
    Public Property DesgloseObligacionesConvertiblesEnCapital() As ModeloBalanceGeneralDatosModeloPasivoObligacionesConvertiblesEnCapitalDesgloseObligacionesConvertiblesEnCapital
        Get
            Return Me.desgloseObligacionesConvertiblesEnCapitalField
        End Get
        Set
            Me.desgloseObligacionesConvertiblesEnCapitalField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOblConvertibles() As Decimal
        Get
            Return Me.totalOblConvertiblesField
        End Get
        Set
            Me.totalOblConvertiblesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoObligacionesConvertiblesEnCapitalDesgloseObligacionesConvertiblesEnCapital

    Private obligacionesConvertiblesEnCapitalField As Decimal

    Private cargosPagarField As Decimal

    '''<remarks/>
    Public Property ObligacionesConvertiblesEnCapital() As Decimal
        Get
            Return Me.obligacionesConvertiblesEnCapitalField
        End Get
        Set
            Me.obligacionesConvertiblesEnCapitalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CargosPagar() As Decimal
        Get
            Return Me.cargosPagarField
        End Get
        Set
            Me.cargosPagarField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoObligacionesPreferentes

    Private desgloseObligacionesPreferentesField As ModeloBalanceGeneralDatosModeloPasivoObligacionesPreferentesDesgloseObligacionesPreferentes

    Private totalOblPreferentesField As Decimal

    '''<remarks/>
    Public Property DesgloseObligacionesPreferentes() As ModeloBalanceGeneralDatosModeloPasivoObligacionesPreferentesDesgloseObligacionesPreferentes
        Get
            Return Me.desgloseObligacionesPreferentesField
        End Get
        Set
            Me.desgloseObligacionesPreferentesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalOblPreferentes() As Decimal
        Get
            Return Me.totalOblPreferentesField
        End Get
        Set
            Me.totalOblPreferentesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoObligacionesPreferentesDesgloseObligacionesPreferentes

    Private obligacionesPreferentesField As Decimal

    Private cargosPagarField As Decimal

    '''<remarks/>
    Public Property ObligacionesPreferentes() As Decimal
        Get
            Return Me.obligacionesPreferentesField
        End Get
        Set
            Me.obligacionesPreferentesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CargosPagar() As Decimal
        Get
            Return Me.cargosPagarField
        End Get
        Set
            Me.cargosPagarField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonio

    Private capitalSocialCapitalMinimoFuncionamientoField As ModeloBalanceGeneralDatosModeloPatrimonioCapitalSocialCapitalMinimoFuncionamiento

    Private aportesPatrimonialesNoCapitalizadosField As ModeloBalanceGeneralDatosModeloPatrimonioAportesPatrimonialesNoCapitalizados

    Private ajustesPatrimonioResultadoIntegralField As ModeloBalanceGeneralDatosModeloPatrimonioAjustesPatrimonioResultadoIntegral

    Private reservasField As ModeloBalanceGeneralDatosModeloPatrimonioReservas

    Private resultadosAcumuladosEjerciciosAnterioresField As ModeloBalanceGeneralDatosModeloPatrimonioResultadosAcumuladosEjerciciosAnteriores

    Private resultadosPeriodoField As ModeloBalanceGeneralDatosModeloPatrimonioResultadosPeriodo

    Private participacionesNoControladasField As ModeloBalanceGeneralDatosModeloPatrimonioParticipacionesNoControladas

    Private patrimonioEnFondoOReservasEspecialesField As ModeloBalanceGeneralDatosModeloPatrimonioPatrimonioEnFondoOReservasEspeciales

    Private totalPatrimonioField As Decimal

    '''<remarks/>
    Public Property CapitalSocialCapitalMinimoFuncionamiento() As ModeloBalanceGeneralDatosModeloPatrimonioCapitalSocialCapitalMinimoFuncionamiento
        Get
            Return Me.capitalSocialCapitalMinimoFuncionamientoField
        End Get
        Set
            Me.capitalSocialCapitalMinimoFuncionamientoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AportesPatrimonialesNoCapitalizados() As ModeloBalanceGeneralDatosModeloPatrimonioAportesPatrimonialesNoCapitalizados
        Get
            Return Me.aportesPatrimonialesNoCapitalizadosField
        End Get
        Set
            Me.aportesPatrimonialesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AjustesPatrimonioResultadoIntegral() As ModeloBalanceGeneralDatosModeloPatrimonioAjustesPatrimonioResultadoIntegral
        Get
            Return Me.ajustesPatrimonioResultadoIntegralField
        End Get
        Set
            Me.ajustesPatrimonioResultadoIntegralField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Reservas() As ModeloBalanceGeneralDatosModeloPatrimonioReservas
        Get
            Return Me.reservasField
        End Get
        Set
            Me.reservasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosAcumuladosEjerciciosAnteriores() As ModeloBalanceGeneralDatosModeloPatrimonioResultadosAcumuladosEjerciciosAnteriores
        Get
            Return Me.resultadosAcumuladosEjerciciosAnterioresField
        End Get
        Set
            Me.resultadosAcumuladosEjerciciosAnterioresField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ResultadosPeriodo() As ModeloBalanceGeneralDatosModeloPatrimonioResultadosPeriodo
        Get
            Return Me.resultadosPeriodoField
        End Get
        Set
            Me.resultadosPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ParticipacionesNoControladas() As ModeloBalanceGeneralDatosModeloPatrimonioParticipacionesNoControladas
        Get
            Return Me.participacionesNoControladasField
        End Get
        Set
            Me.participacionesNoControladasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PatrimonioEnFondoOReservasEspeciales() As ModeloBalanceGeneralDatosModeloPatrimonioPatrimonioEnFondoOReservasEspeciales
        Get
            Return Me.patrimonioEnFondoOReservasEspecialesField
        End Get
        Set
            Me.patrimonioEnFondoOReservasEspecialesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPatrimonio() As Decimal
        Get
            Return Me.totalPatrimonioField
        End Get
        Set
            Me.totalPatrimonioField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioCapitalSocialCapitalMinimoFuncionamiento

    Private desgloseCapitalSocialCapitalMinimoFuncionamientoField As ModeloBalanceGeneralDatosModeloPatrimonioCapitalSocialCapitalMinimoFuncionamientoDesgloseCapitalSocialCapitalMinimoFuncionamiento

    Private totalCapSocialField As Decimal

    '''<remarks/>
    Public Property DesgloseCapitalSocialCapitalMinimoFuncionamiento() As ModeloBalanceGeneralDatosModeloPatrimonioCapitalSocialCapitalMinimoFuncionamientoDesgloseCapitalSocialCapitalMinimoFuncionamiento
        Get
            Return Me.desgloseCapitalSocialCapitalMinimoFuncionamientoField
        End Get
        Set
            Me.desgloseCapitalSocialCapitalMinimoFuncionamientoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalCapSocial() As Decimal
        Get
            Return Me.totalCapSocialField
        End Get
        Set
            Me.totalCapSocialField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioCapitalSocialCapitalMinimoFuncionamientoDesgloseCapitalSocialCapitalMinimoFuncionamiento

    Private pagadoField As Decimal

    Private donadoField As Decimal

    Private suscritoNoIntegradoField As Decimal

    Private suscripcionesCapitalPorIntegrarField As Decimal

    Private accionesTesoreriaField As Decimal

    Private capitalAsignadoSucursalesField As Decimal

    '''<remarks/>
    Public Property Pagado() As Decimal
        Get
            Return Me.pagadoField
        End Get
        Set
            Me.pagadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Donado() As Decimal
        Get
            Return Me.donadoField
        End Get
        Set
            Me.donadoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SuscritoNoIntegrado() As Decimal
        Get
            Return Me.suscritoNoIntegradoField
        End Get
        Set
            Me.suscritoNoIntegradoField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SuscripcionesCapitalPorIntegrar() As Decimal
        Get
            Return Me.suscripcionesCapitalPorIntegrarField
        End Get
        Set
            Me.suscripcionesCapitalPorIntegrarField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AccionesTesoreria() As Decimal
        Get
            Return Me.accionesTesoreriaField
        End Get
        Set
            Me.accionesTesoreriaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CapitalAsignadoSucursales() As Decimal
        Get
            Return Me.capitalAsignadoSucursalesField
        End Get
        Set
            Me.capitalAsignadoSucursalesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioAportesPatrimonialesNoCapitalizados

    Private desgloseAportesPatrimonialesNoCapitalizadosField As ModeloBalanceGeneralDatosModeloPatrimonioAportesPatrimonialesNoCapitalizadosDesgloseAportesPatrimonialesNoCapitalizados

    Private totalApoPatrimonialesField As Decimal

    '''<remarks/>
    Public Property DesgloseAportesPatrimonialesNoCapitalizados() As ModeloBalanceGeneralDatosModeloPatrimonioAportesPatrimonialesNoCapitalizadosDesgloseAportesPatrimonialesNoCapitalizados
        Get
            Return Me.desgloseAportesPatrimonialesNoCapitalizadosField
        End Get
        Set
            Me.desgloseAportesPatrimonialesNoCapitalizadosField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalApoPatrimoniales() As Decimal
        Get
            Return Me.totalApoPatrimonialesField
        End Get
        Set
            Me.totalApoPatrimonialesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioAportesPatrimonialesNoCapitalizadosDesgloseAportesPatrimonialesNoCapitalizados

    Private capitalPagadoAdicionalField As Decimal

    Private paraIncrementosCapitalField As Decimal

    Private apotMantCapMinObliEntAsegYReasegRevalUDPendCalificarField As Decimal

    Private apotMantCapMinObliEntAsegYReasegRevalUDPendCalificarSucursalesField As Decimal

    '''<remarks/>
    Public Property CapitalPagadoAdicional() As Decimal
        Get
            Return Me.capitalPagadoAdicionalField
        End Get
        Set
            Me.capitalPagadoAdicionalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ParaIncrementosCapital() As Decimal
        Get
            Return Me.paraIncrementosCapitalField
        End Get
        Set
            Me.paraIncrementosCapitalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ApotMantCapMinObliEntAsegYReasegRevalUDPendCalificar() As Decimal
        Get
            Return Me.apotMantCapMinObliEntAsegYReasegRevalUDPendCalificarField
        End Get
        Set
            Me.apotMantCapMinObliEntAsegYReasegRevalUDPendCalificarField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ApotMantCapMinObliEntAsegYReasegRevalUDPendCalificarSucursales() As Decimal
        Get
            Return Me.apotMantCapMinObliEntAsegYReasegRevalUDPendCalificarSucursalesField
        End Get
        Set
            Me.apotMantCapMinObliEntAsegYReasegRevalUDPendCalificarSucursalesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioAjustesPatrimonioResultadoIntegral

    Private desgloseAjustesPatrimonioResultadoIntegralField As ModeloBalanceGeneralDatosModeloPatrimonioAjustesPatrimonioResultadoIntegralDesgloseAjustesPatrimonioResultadoIntegral

    Private totalAjustesPatrimonioResultadoIntegralField As Decimal

    '''<remarks/>
    Public Property DesgloseAjustesPatrimonioResultadoIntegral() As ModeloBalanceGeneralDatosModeloPatrimonioAjustesPatrimonioResultadoIntegralDesgloseAjustesPatrimonioResultadoIntegral
        Get
            Return Me.desgloseAjustesPatrimonioResultadoIntegralField
        End Get
        Set
            Me.desgloseAjustesPatrimonioResultadoIntegralField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalAjustesPatrimonioResultadoIntegral() As Decimal
        Get
            Return Me.totalAjustesPatrimonioResultadoIntegralField
        End Get
        Set
            Me.totalAjustesPatrimonioResultadoIntegralField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioAjustesPatrimonioResultadoIntegralDesgloseAjustesPatrimonioResultadoIntegral

    Private alValorActivosField As Decimal

    Private valoracionParticipacionesOtrasEmpresasField As Decimal

    Private conversionEstadosFinancierosField As Decimal

    '''<remarks/>
    Public Property AlValorActivos() As Decimal
        Get
            Return Me.alValorActivosField
        End Get
        Set
            Me.alValorActivosField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ValoracionParticipacionesOtrasEmpresas() As Decimal
        Get
            Return Me.valoracionParticipacionesOtrasEmpresasField
        End Get
        Set
            Me.valoracionParticipacionesOtrasEmpresasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ConversionEstadosFinancieros() As Decimal
        Get
            Return Me.conversionEstadosFinancierosField
        End Get
        Set
            Me.conversionEstadosFinancierosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioReservas

    Private desgloseReservasField As ModeloBalanceGeneralDatosModeloPatrimonioReservasDesgloseReservas

    Private totalReservasField As Decimal

    '''<remarks/>
    Public Property DesgloseReservas() As ModeloBalanceGeneralDatosModeloPatrimonioReservasDesgloseReservas
        Get
            Return Me.desgloseReservasField
        End Get
        Set
            Me.desgloseReservasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalReservas() As Decimal
        Get
            Return Me.totalReservasField
        End Get
        Set
            Me.totalReservasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioReservasDesgloseReservas

    Private legalField As Decimal

    Private otrasObligatoriasField As Decimal

    Private voluntariasField As Decimal

    Private reservaNiveladoraAcumuladaField As Decimal

    Private reservasRegulatoriasField As Decimal

    '''<remarks/>
    Public Property Legal() As Decimal
        Get
            Return Me.legalField
        End Get
        Set
            Me.legalField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property OtrasObligatorias() As Decimal
        Get
            Return Me.otrasObligatoriasField
        End Get
        Set
            Me.otrasObligatoriasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Voluntarias() As Decimal
        Get
            Return Me.voluntariasField
        End Get
        Set
            Me.voluntariasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReservaNiveladoraAcumulada() As Decimal
        Get
            Return Me.reservaNiveladoraAcumuladaField
        End Get
        Set
            Me.reservaNiveladoraAcumuladaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReservasRegulatorias() As Decimal
        Get
            Return Me.reservasRegulatoriasField
        End Get
        Set
            Me.reservasRegulatoriasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioResultadosAcumuladosEjerciciosAnteriores

    Private desgloseResultadosAcumuladosEjerciciosAnterioresField As ModeloBalanceGeneralDatosModeloPatrimonioResultadosAcumuladosEjerciciosAnterioresDesgloseResultadosAcumuladosEjerciciosAnteriores

    Private totalResAcumuladosField As Decimal

    '''<remarks/>
    Public Property DesgloseResultadosAcumuladosEjerciciosAnteriores() As ModeloBalanceGeneralDatosModeloPatrimonioResultadosAcumuladosEjerciciosAnterioresDesgloseResultadosAcumuladosEjerciciosAnteriores
        Get
            Return Me.desgloseResultadosAcumuladosEjerciciosAnterioresField
        End Get
        Set
            Me.desgloseResultadosAcumuladosEjerciciosAnterioresField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalResAcumulados() As Decimal
        Get
            Return Me.totalResAcumuladosField
        End Get
        Set
            Me.totalResAcumuladosField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioResultadosAcumuladosEjerciciosAnterioresDesgloseResultadosAcumuladosEjerciciosAnteriores

    Private utilidadesAcumuladasField As Decimal

    Private perdidasAcumuladasField As Decimal

    '''<remarks/>
    Public Property UtilidadesAcumuladas() As Decimal
        Get
            Return Me.utilidadesAcumuladasField
        End Get
        Set
            Me.utilidadesAcumuladasField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PerdidasAcumuladas() As Decimal
        Get
            Return Me.perdidasAcumuladasField
        End Get
        Set
            Me.perdidasAcumuladasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioResultadosPeriodo

    Private desgloseResultadosPeriodoField As ModeloBalanceGeneralDatosModeloPatrimonioResultadosPeriodoDesgloseResultadosPeriodo

    Private totalResPeriodoField As Decimal

    '''<remarks/>
    Public Property DesgloseResultadosPeriodo() As ModeloBalanceGeneralDatosModeloPatrimonioResultadosPeriodoDesgloseResultadosPeriodo
        Get
            Return Me.desgloseResultadosPeriodoField
        End Get
        Set
            Me.desgloseResultadosPeriodoField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalResPeriodo() As Decimal
        Get
            Return Me.totalResPeriodoField
        End Get
        Set
            Me.totalResPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioResultadosPeriodoDesgloseResultadosPeriodo

    Private utilidadNetaField As Decimal

    Private perdidaNetaField As Decimal

    Private reservaNiveladoraPeriodoField As Decimal

    '''<remarks/>
    Public Property UtilidadNeta() As Decimal
        Get
            Return Me.utilidadNetaField
        End Get
        Set
            Me.utilidadNetaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PerdidaNeta() As Decimal
        Get
            Return Me.perdidaNetaField
        End Get
        Set
            Me.perdidaNetaField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReservaNiveladoraPeriodo() As Decimal
        Get
            Return Me.reservaNiveladoraPeriodoField
        End Get
        Set
            Me.reservaNiveladoraPeriodoField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioParticipacionesNoControladas

    Private desgloseParticipacionesNoControladasField As ModeloBalanceGeneralDatosModeloPatrimonioParticipacionesNoControladasDesgloseParticipacionesNoControladas

    Private totalParticipacionesNoControladasField As Decimal

    '''<remarks/>
    Public Property DesgloseParticipacionesNoControladas() As ModeloBalanceGeneralDatosModeloPatrimonioParticipacionesNoControladasDesgloseParticipacionesNoControladas
        Get
            Return Me.desgloseParticipacionesNoControladasField
        End Get
        Set
            Me.desgloseParticipacionesNoControladasField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalParticipacionesNoControladas() As Decimal
        Get
            Return Me.totalParticipacionesNoControladasField
        End Get
        Set
            Me.totalParticipacionesNoControladasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioParticipacionesNoControladasDesgloseParticipacionesNoControladas

    Private participacionesNoControladasField As Decimal

    '''<remarks/>
    Public Property ParticipacionesNoControladas() As Decimal
        Get
            Return Me.participacionesNoControladasField
        End Get
        Set
            Me.participacionesNoControladasField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioPatrimonioEnFondoOReservasEspeciales

    Private desglosePatrimonioEnFondoOReservasEspecialesField As ModeloBalanceGeneralDatosModeloPatrimonioPatrimonioEnFondoOReservasEspecialesDesglosePatrimonioEnFondoOReservasEspeciales

    Private totalPatrimonioEnFondoOReservasEspecialesField As Decimal

    '''<remarks/>
    Public Property DesglosePatrimonioEnFondoOReservasEspeciales() As ModeloBalanceGeneralDatosModeloPatrimonioPatrimonioEnFondoOReservasEspecialesDesglosePatrimonioEnFondoOReservasEspeciales
        Get
            Return Me.desglosePatrimonioEnFondoOReservasEspecialesField
        End Get
        Set
            Me.desglosePatrimonioEnFondoOReservasEspecialesField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlAttributeAttribute()>
    Public Property TotalPatrimonioEnFondoOReservasEspeciales() As Decimal
        Get
            Return Me.totalPatrimonioEnFondoOReservasEspecialesField
        End Get
        Set
            Me.totalPatrimonioEnFondoOReservasEspecialesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPatrimonioPatrimonioEnFondoOReservasEspecialesDesglosePatrimonioEnFondoOReservasEspeciales

    Private fondosEspecialesField As Decimal

    Private reservasEspecialesField As Decimal

    '''<remarks/>
    Public Property FondosEspeciales() As Decimal
        Get
            Return Me.fondosEspecialesField
        End Get
        Set
            Me.fondosEspecialesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property ReservasEspeciales() As Decimal
        Get
            Return Me.reservasEspecialesField
        End Get
        Set
            Me.reservasEspecialesField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0"),
 System.SerializableAttribute(),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class ModeloBalanceGeneralDatosModeloPasivoMasPatrimonio

    Private totalPasivoMasPatrimonioField As Decimal

    '''<remarks/>
    Public Property TotalPasivoMasPatrimonio() As Decimal
        Get
            Return Me.totalPasivoMasPatrimonioField
        End Get
        Set
            Me.totalPasivoMasPatrimonioField = Value
        End Set
    End Property
End Class
