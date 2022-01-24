using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Ramo
{
    /// <summary>
    /// COBERTURAS DEL RAMO.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class A1002150
    {
        /// <summary>
        /// CODIGO DE COMPAÑIA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_CIA { get; set; }
        /// <summary>
        /// RAMO.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_RAMO { get; set; }
        /// <summary>
        /// MODALIDAD DE VIDA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_MODALIDAD { get; set; }
        /// <summary>
        /// SECUENCIA.
        /// </summary>
        [DataMember(), JsonProperty()] public int NUM_SECU { get; set; }
        /// <summary>
        /// COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_COB { get; set; }
        /// <summary>
        /// NOMBRE DE LA COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_COB { get; set; }
        /// <summary>
        /// MONEDA DEL CAPITAL.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_MON_CAPITAL { get; set; }
        /// <summary>
        /// EL CAPITAL SE EXPRESA EN UNIDADES.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_UNIDAD { get; set; }
        /// <summary>
        /// IMPORTE POR UNIDAD.
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 IMP_UNIDAD { get; set; }
        /// <summary>
        /// TIPO DE CAPITAL (LIBRE, LIMITE, .).
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_TIP_CAPITAL { get; set; }
        /// <summary>
        /// DE QUE COBERTURA DEPENDE.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_COB_RELACIONADA { get; set; }
        /// <summary>
        /// PORCENTAJE DE CAPITAL QUE TOMARA DE LA COBERTURA RELACIONADA.
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 PCT_PARTICIPACION { get; set; }
        /// <summary>
        /// SE PERMITE MODIFICAR EL CAPITAL INDICANDO UN PORCENTAJE SOBRE LA COBERTURA DE LA QUE DEPENDEN.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_PCT_PARTICIPACION_VARIABLE { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE DETERMINA EL CAPITAL DE LA COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_PRE_COB { get; set; }
        /// <summary>
        /// PRIMER AGRUPAMIENTO.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_AGRUP_COB_1 { get; set; }
        /// <summary>
        /// SEGUNDO AGRUPAMIENTO.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_AGRUP_COB_2 { get; set; }
        /// <summary>
        /// TERCER AGRUPAMIENTO.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_AGRUP_COB_3 { get; set; }
        /// <summary>
        /// CUARTO AGRUPAMIENTO.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_AGRUP_COB_4 { get; set; }
        /// <summary>
        /// RAMO CONTABLE.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_RAMO_CTABLE { get; set; }
        /// <summary>
        /// COEFICIENTE DEL COSTE ADMINISTRATIVO DE LA COBERTURA (PARA PROVISIONES).
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 COEF_INVENTARIO { get; set; }
        /// <summary>
        /// LA IMPRESION ES OBLIGATORIA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_IMP_OBLIGATORIA { get; set; }
        /// <summary>
        /// ES NECESARIA LA PETICION DE ACCESORIOS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_ACCESORIOS { get; set; }
        /// <summary>
        /// LLEVA FRANQUICIA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_FRANQUICIA { get; set; }
        /// <summary>
        /// LA COBERTURA ES SUSCEPTIBLE DE ESTUDIO DE SINIESTRALIDAD.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_BONI { get; set; }
        /// <summary>
        /// INDICA SI LA COBERTURA PUEDE TENER SOBREPRIMAS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_SOBRE_TASAS { get; set; }
        /// <summary>
        /// SE PAGARAN COMISIONES DE NUEVA PRODUCCION.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_COMIS_NPR { get; set; }
        /// <summary>
        /// SE PAGARAN COMISIONES DE CARTERA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_COMIS_CAR { get; set; }
        /// <summary>
        /// OBLIGATORIO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_OBLIGATORIO { get; set; }
        /// <summary>
        /// FILA INHABILITADA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_INH { get; set; }
        /// <summary>
        /// SE PERMITE MODIFICAR EL CAPITAL.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_MOD_SUMA_ASEG { get; set; }
        /// <summary>
        /// LA SUMA ASEGURADA SE AGOTA POR LOS SINIESTROS SUFRIDOS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_BAJA_SUMA_ASEG_STRO { get; set; }
        /// <summary>
        /// SE REASEGURA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_REASEGURO { get; set; }
        /// <summary>
        /// SIN USO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_FINANCIABLE { get; set; }
        /// <summary>
        /// SI SE CONTRATA ES NECESARIO INSPECCIONAR EL RIESGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_INSPEC { get; set; }
        /// <summary>
        /// AQUELLAS COBERTURAS QUE OFRECEN UN CAPITAL POR DEFECTO Y ESTE SE PUEDE MODIFICAR, EN LA RENOVACION SE VUELVE A OFRECER.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_NUEVO_CAPITAL { get; set; }
        /// <summary>
        /// FORMA DE REVALORIZACION.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_REGULARIZA { get; set; }
        /// <summary>
        /// FORMA DE REVALORIZACION.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_REGULARIZA_ESP { get; set; }
        /// <summary>
        /// PORCENTAJE DE REVALORIZACION.
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 PCT_REGULARIZA_ESP { get; set; }
        /// <summary>
        /// INDICE DE REVALORIZACION.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_INDICE { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE DETERMINA EL CAPITAL REVALORIZADO EN LA RENOVACION.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_REGULARIZA_ESP { get; set; }
        /// <summary>
        /// MONEDA EN LA QUE ESTA EXPRESADA LA TARIFA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_MON_TARIFA { get; set; }
        /// <summary>
        /// FORMA EN LA QUE CALCULARA LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_CALCULO_COB { get; set; }
        /// <summary>
        /// TANTO PORCIENTO O PORMIL QUE DETERMINARA EL CALCULO.
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 TASA_CALCULO { get; set; }
        /// <summary>
        /// IMPORTE DE LA TARIFA.
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 IMP_CALCULO { get; set; }
        /// <summary>
        /// TABLA DONDE SE ENCUENTRA LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_TABLA_CALCULO { get; set; }
        /// <summary>
        /// FORMA DEL CALCULO.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_TABLA_CALCULO { get; set; }
        /// <summary>
        /// NOMBRE DE LA COLUMNA QUE SE VA A RESCATAR DE LA TABLA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_CAMPO_TABLA_CALCULO { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE DETERMINA EL CALCULO.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_CALCULO { get; set; }
        /// <summary>
        /// TABLA DONDE SE ENCUENTRA LA CORRECCION A LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_TABLA_CORRECTORA { get; set; }
        /// <summary>
        /// NOMBRE DE LA COLUMNA QUE SE VA A RESCATAR DE LA TABLA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_CAMPO_TABLA_CORRECTORA { get; set; }
        /// <summary>
        /// FORMA DE CORREGIR LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_CALCULO_AUX { get; set; }
        /// <summary>
        /// FORMA EN QUE LA PRIMA SE ACTUALIZA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_CALCULO_AUX { get; set; }
        /// <summary>
        /// SE APLICARA UNA CORRECCION A LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_CALCULO_AUX { get; set; }
        /// <summary>
        /// FORMA EN LA QUE SE APLICARA LA PRIMA MINIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_PRIMA_MINIMA { get; set; }
        /// <summary>
        /// PRIMA MINIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public Int64 IMP_PRIMA_MINIMA { get; set; }
        /// <summary>
        /// TABLA DONDE SE ENCUENTRA LA PRIMA MINIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_TABLA_PRIMA_MINIMA { get; set; }
        /// <summary>
        /// NOMBRE DE LA COLUMNA QUE SE VA A RESCATAR DE LA TABLA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_CAMPO_TABLA_PRIMA_MINIMA { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE DETERMINA EL IMPORTE DE PRIMA MINIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_PRIMA_MINIMA { get; set; }
        /// <summary>
        /// ACCION QUE SE TOMA EN UN SUPLEMENTO, CUANDO SE AUMENTA EL CAPITAL Y NO SE CAMBIAN ATRIBUTOS QUE AFECTAN A LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_ACT_AUM_NO_MOD { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE DETERMINA LA PRIMA CUANDO EXISTE AUMENTO DE CAPITAL Y HAN CAMBIADO LOS ATRIBUTOS QUE AFECTAN A LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_AUM_NO_MOD { get; set; }
        /// <summary>
        /// ACCION QUE SE TOMA EN UN SUPLEMENTO, CUANDO SE AUMENTA EL CAPITAL Y SE CAMBIAN ATRIBUTOS QUE AFECTAN A LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_ACT_AUM_SI_MOD { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE DETERMINA LA PRIMA CUANDO EXISTE AUMENTO DE CAPITAL Y NO HAN CAMBIADO LOS ATRIBUTOS QUE AFECTAN A LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_AUM_SI_MOD { get; set; }
        /// <summary>
        /// ACCION QUE SE TOMA EN UN SUPLEMENTO, CUANDO SE DISMINUYE EL CAPITAL Y NO SE CAMBIAN ATRIBUTOS QUE AFECTAN A LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_ACT_BAJ_NO_MOD { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE DETERMINA LA PRIMA CUANDO EXISTE DISMINUCION DE CAPITAL Y NO HAN CAMBIADO LOS ATRIBUTOS QUE AFECTAN A LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_BAJ_NO_MOD { get; set; }
        /// <summary>
        /// ACCION QUE SE TOMA EN UN SUPLEMENTO, CUANDO SE DISMINUYE EL CAPITAL Y SE CAMBIAN ATRIBUTOS QUE AFECTAN A LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_ACT_BAJ_SI_MOD { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE DETERMINA LA PRIMA CUANDO EXISTE DISMINUCION DE CAPITAL Y HAN CAMBIADO LOS ATRIBUTOS QUE AFECTAN A LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_BAJ_SI_MOD { get; set; }
        /// <summary>
        /// ACCION QUE SE TOMA EN UN SUPLEMENTO, CUANDO SE MANTIENE EL CAPITAL Y NO SE CAMBIAN ATRIBUTOS QUE AFECTAN A LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_ACT_MAN_NO_MOD { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE DETERMINA LA PRIMA CUANDO MANTIENE CAPITAL Y NO HAN CAMBIADO LOS ATRIBUTOS QUE AFECTAN A LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_MAN_NO_MOD { get; set; }
        /// <summary>
        /// ACCION QUE SE TOMA EN UN SUPLEMENTO, CUANDO SE MANTIENE EL CAPITAL Y SE CAMBIAN ATRIBUTOS QUE AFECTAN A LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_ACT_MAN_SI_MOD { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE DETERMINA LA PRIMA CUANDO MANTIENE CAPITAL Y HAN CAMBIADO LOS ATRIBUTOS QUE AFECTAN A LA PRIMA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_MAN_SI_MOD { get; set; }
        /// <summary>
        /// LA PRIMA SE VALIDA POR EL SISTEMA ESTANDAR DE VALIDACION.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_VALIDACION_PRIMA { get; set; }
        /// <summary>
        /// EL CAPITAL SE VALIDA POR EL SISTEMA ESTANDAR.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_VALIDACION_SUMA_ASEG { get; set; }
        /// <summary>
        /// PROCEDIMIENTO DE VALIDACION DEL CAPITAL.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_VALIDACION { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE DETERMINA LA FRANQUICIA, LA PSOIBILIDAD D EMODIFICARLA POR PARTE DEL USUARIO Y MINIMO Y/O MAXIMO.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_PRE_FRANQUICIA { get; set; }
        /// <summary>
        /// FECHA DE VALIDEZ.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_VALIDEZ { get; set; }
        /// <summary>
        /// USUARIO QUE ACTUALIZO LA FILA.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_USR { get; set; }
        /// <summary>
        /// FECHA DE LA ULTIMA ACTUALIZACION DEL REGISTRO.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_ACTU { get; set; }
        /// <summary>
        /// PROCEDIMIENTO PARA LA VALIDACION DE LA COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_VALIDACION_PRIMA { get; set; }
    }
}

