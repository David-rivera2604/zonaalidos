using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Ramo
{
    /// <summary>
    /// RAMOS.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class A1001800
    {
        /// <summary>
        /// CODIGO DE COMPAÑIA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_CIA { get; set; }
        /// <summary>
        /// SECTOR.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_SECTOR { get; set; }
        /// <summary>
        /// SUBSECTOR.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_SUBSECTOR { get; set; }
        /// <summary>
        /// RAMO.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_RAMO { get; set; }
        /// <summary>
        /// NOMBRE DEL RAMO.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_RAMO { get; set; }
        /// <summary>
        /// ABREVIATURA DEL RAMO.
        /// </summary>
        [DataMember(), JsonProperty()] public string ABR_RAMO { get; set; }
        /// <summary>
        /// TIENE CLAUSULAS ASOCIADAS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_CLAUSULA { get; set; }
        /// <summary>
        /// PUEDE INCLUIRSE TEXTO LIBRE.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_ANEXO { get; set; }
        /// <summary>
        /// CALCULO A PRORRATA O ESCALA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_PRORRATA { get; set; }
        /// <summary>
        /// SI EN EMISION EL CAMPO QUE INDICA SI SE CALCULA A PRORRATA O ESCALA ES MODIFICABLE.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_CAMBIA_PRORRATA { get; set; }
        /// <summary>
        /// SE PERMITE QUE LAS POLIZAS DEL RAMO TENGAN MAS DE UN RIESGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_RIESGOS { get; set; }
        /// <summary>
        /// SE PERMITEN EMISIONES DE MAS DE UN PERIODO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_PERIODOS { get; set; }
        /// <summary>
        /// POLIZAS MULTIPERIODO CON RECIBOS POR EL PERIODO COMPLETO O RECIBOS POR CADA UNO DE LOS PERIODOS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_RECIBO_POR_PERIODO { get; set; }
        /// <summary>
        /// UTILIZACION EN EMISION.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_EMISION { get; set; }
        /// <summary>
        /// SI PERMITE LA MODIFICACION DE LA OFICINA COMERCIAL EN LA EMISION.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_CAMBIO_NIVEL_3 { get; set; }
        /// <summary>
        /// NO SE USA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_CALCULA_FRACC_PAGO { get; set; }
        /// <summary>
        /// UN CAMBIO DE PLAN DE PAGO GENERA UN SUPLEMENTO (SM).
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_SPTO_EN_PLAN_PAGO { get; set; }
        /// <summary>
        /// SI PERMITE CAMBIAR DE PLAN DE PAGO EN SUPLEMENTOS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_CAMBIO_PLAN_PAGO { get; set; }
        /// <summary>
        /// EL RAMO TRABAJA CON CERTIFICADOS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_CERTIFICADOS { get; set; }
        /// <summary>
        /// FILA INHABILITADA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_INH { get; set; }
        /// <summary>
        /// INDICA EN CASO DE COASEGURO CEDIDO, SI SE PERMITE DEJAR LA COMISION SIN VALOR.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_COMIS_COA_EXT { get; set; }
        /// <summary>
        /// NUMERO DE DIAS PARA CALCULO, (S)/365, (N)/360.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_365_DIAS { get; set; }
        /// <summary>
        /// NO SE PUEDE EMITIR SI NO EXISTE UN PRESUPUESTO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_OBLIGA_PRESUPUESTO { get; set; }
        /// <summary>
        /// SE DEBEN AUTORIZAR LOS CONTROLES TECNICOS QUE SALTEN EN PRESUPUESTOS ANTES DE PODER EMITIR.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_AUTORIZA_PRESUPUESTO { get; set; }
        /// <summary>
        /// INDICA SI CAMBIA EL NUMERO DE POLIZA EN LA RENOVACION.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_CAMBIO_NUM_POLIZA { get; set; }
        /// <summary>
        /// CAMBIO DE NUMERO POLIZA EN APLICACIONES.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_CAMBIO_NUM_POLIZA_APLI { get; set; }
        /// <summary>
        /// SE COMPRUEBA LA EXISTENCIA DE SINIESTROS EN CASO DE REALIZAR UN SUPLEMENTO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_VAL_STRO_EN_SPTO { get; set; }
        /// <summary>
        /// LOS RECIBOS SALEN REMESADOS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_REMESA_RECIBO { get; set; }
        /// <summary>
        /// SE PERMITE LA MODIFICACION MANUAL DE RECIBOS (SI EL ROL LO PERMITE).
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_RECIBO_MANUAL { get; set; }
        /// <summary>
        /// SE PERMITE LA MODIFICACION MANUAL DE COMISIONES (SI EL ROL LO PERMITE).
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_COMIS_MANUAL { get; set; }
        /// <summary>
        /// SI LA BUSQUEDA DE INSPECCION SE HARA EN LA EMISION.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_BUSCA_INSP_EMISION { get; set; }
        /// <summary>
        /// SE PERMITE LA EMISION DE POLIZAS SIN RECIBO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_EMISION_SIN_RECIBO { get; set; }
        /// <summary>
        /// INDICA SI SE PERMITE REUTILIZAR UN PRESUPUESTO QUE YA HA SIDO TRASPASADO A POLIZA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_REUTILIZA_PRESUPUESTO { get; set; }
        /// <summary>
        /// INDICA SI SE PERMITE REUTILIZAR UNA DECLARACION QUE YA HA SIDO TRASPASADA A APLICACION.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_REUTILIZA_DECLARACION { get; set; }
        /// <summary>
        /// INDICA SI AL DAR DE BAJA UN RIESGO, EL CALCULO SERA COMO LA ANULACION DE POLIZAS (COEF_ANULACION).
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_APLICA_AT_EN_RIESGO { get; set; }
        /// <summary>
        /// TIPO DE COASEGURO PERMITIDO (0)NO COASEGURO, (1)CEDIDO, (2)ACEPTADO, (3)AMBOS.
        /// </summary>
        [DataMember(), JsonProperty()] public int TIP_COASEGURO_PERMITIDO { get; set; }
        /// <summary>
        /// SI EL RAMO PERMITE COASEGURO CEDIDO, SI LAS EMISIONES SE REALIZAN SOLO MEDIANTE CUADROS DE COASEGURO PREDEFINIDOS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_CUADRO_COASEGURO_OBL { get; set; }
        /// <summary>
        /// FORMAS PERIMITIDAS DEL CALCULO DE PRIMAS.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_PRIMAS_MANUALES { get; set; }
        /// <summary>
        /// NUMERO DE AGENTES PERMITIDOS (PRINCIPAL MAS SECUNDARIOS).
        /// </summary>
        [DataMember(), JsonProperty()] public int NUM_AGT { get; set; }
        /// <summary>
        /// NUMERO DE RIESGOS MAXIMO PARA TRANSPASO DIRECTO.
        /// </summary>
        [DataMember(), JsonProperty()] public int NUM_RIESGOS_TRASPASO_DIRECTO { get; set; }
        /// <summary>
        /// NUMERO DE RIESGOS MAXIMO PARA IMPRESION "ON LINE".
        /// </summary>
        [DataMember(), JsonProperty()] public int NUM_RIESGOS_IMPRESION { get; set; }
        /// <summary>
        /// OBJETO QUE GENERA LA DESCRIPCION DEL RIESGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_RIESGO { get; set; }
        /// <summary>
        /// MANERA DE FORMAR MODALIDADES.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_FORMACION_MODALIDAD { get; set; }
        /// <summary>
        /// USUARIO QUE ACTUALIZO LA FILA.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_USR { get; set; }
        /// <summary>
        /// FECHA DE LA ULTIMA ACTUALIZACION DEL REGISTRO.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_ACTU { get; set; }
        /// <summary>
        /// OBJETO PARA DETERMINAR SI SE BUSCA LA INSPECCION EN LA EMISION.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_BUSCA_INSP_EMISION { get; set; }
        /// <summary>
        /// TRATAMIENTO.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_TRATAMIENTO { get; set; }
        /// <summary>
        /// CODIGO DE TRATAMIENTO PARA SINIESTROS.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_TRATAMIENTO_SINI { get; set; }
        /// <summary>
        /// TRATAMIENTO CONTABLE DEL RAMO.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_TRATAMIENTO_CTABLE { get; set; }
        /// <summary>
        /// OBJETO QUE DETERMINA CUANDO SE PERMITE UNA EMISION SIN RECIBO.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_EMISION_SIN_RECIBO { get; set; }
        /// <summary>
        /// CODIGO DE PROCESO.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_PROCESO { get; set; }
        /// <summary>
        /// CODIGO DE PROCESO QUE IMPRIME UN PRESUPUESTO.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_PROCESO_P { get; set; }
        /// <summary>
        /// PROCESO QUE SE EJECUTA SI SE RECHAZA UNA POLIZA RETENIDA POR C. TECNICO.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_PROCESO_R { get; set; }
        /// <summary>
        /// CODIGO DE ESTRUCTURA PARA LA PETICION DE DATOS VARIABLES NIVEL DE POLIZA.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_EST_DV_POLIZA { get; set; }
        /// <summary>
        /// CODIGO DE ESTRUCTURA PARA LA PETICION DE DATOS VARIABLES NIVEL DE RIESGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_EST_RIESGO { get; set; }
        /// <summary>
        /// CODIGO DE ESTRUCTURA PARA LA PE TICION DE DATOS VARIABLES NIVEL DE MODALIDAD.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_EST_MODALIDAD { get; set; }
        /// <summary>
        /// CODIGO DE ESTRUCTURA PARA LA PETICION DE ACCESORIOS.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_EST_ACCESORIOS { get; set; }
        /// <summary>
        /// CODIGO DE ESTRUCTURA PARA LA PETICION DEL PLAN DE PAGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_EST_PLAN_PAGO { get; set; }
        /// <summary>
        /// CODIGO DE ESTRUCTURA PARA LA INSPECCION.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_EST_INSPEC { get; set; }
        /// <summary>
        /// OBJETO QUE RECUPERA EL COEFICIENTE DE CONSTITUCION.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_COEF_COB { get; set; }
        /// <summary>
        /// OBJETO QUE DEVUELVE LA INSPECCION QUE SE DEBE ASOCIAR AL RIESGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_BUSCA_INSP { get; set; }
        /// <summary>
        /// OBJETO QUE DETERMINA SI SE EXCLUYE LA OBLIGATORIEDAD DE LA INSPECCION PARA EL RIESGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_EXCLUYE_INSP { get; set; }
        /// <summary>
        /// TIPO DE DISTRIBUCION DE COMISIONES EN CUOTAS 1- PROPORCIONAL 2- 100% A LA PRIMERA CUOTA (FORMAS DE PAGO).
        /// </summary>
        [DataMember(), JsonProperty()] public int TIP_DST_COMIS { get; set; }
        /// <summary>
        /// OBJETO QUE DETERMINA EL TIPO DE DISTRIBUCION DE LAS COMISIONES.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_DST_COMIS { get; set; }
        /// <summary>
        /// Sin comentario.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_REMESA_RECIBO { get; set; }
        /// <summary>
        /// PERMITE MODIFICAR EL CODIGO DE ORGANIZADOR O ASESOR DEL AGENTE.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_MOD_ORG_ASE { get; set; }
        /// <summary>
        /// PERMITE MODIFICAR LA COMISION DE LA CUOTA PARA LA INTERVENCION.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_MOD_COM_CUOTA_INTERV { get; set; }
        /// <summary>
        /// PERMITE EMITIR A CUALQUIER USUARIO LAS POLIZAS RECHAZADAS/SUSPENDIDAS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_RECHAZO_SUSP_A_TODOS { get; set; }
        /// <summary>
        /// INDICA SI EL RAMO PERMITE EL RECALCULO DE COMISIONES EN LOS CAMBIOS DE AGENTE.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_RECALCULA_COMIS { get; set; }
        /// <summary>
        /// INDICA SI SE DEBE REGISTRRAR LA HORA DE EFECTO DE LAS POLIZAS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_REGISTRA_HORA { get; set; }
        /// <summary>
        /// TIPO DE REASEGURO PERMITIDO (0)SOLO SEGURO DIRECTO, (1)ACEPTADO (CONTRATO), (2)CEDIDO (FACULTATIVO), (3)AMBOS.
        /// </summary>
        [DataMember(), JsonProperty()] public int TIP_REA_PERMITIDO { get; set; }
        /// <summary>
        /// CALCULA PRIMAS DE COBERTURAS A PARTIR DE TASA MANUAL.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_TASA_MANUAL { get; set; }
        /// <summary>
        /// INDICA QUE EN LOS PROCESOS BATCH SE CALCULAN RIESGO A RIESGO LOS DESGLOSES QUE NO SON PRIMA DE TARIFA EN LUGAR DE OBTENERLOS TRAS TRATAR TODOS LOS RIESGOS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_DES_POR_RIESGO_BATCH { get; set; }
        /// <summary>
        /// PERMITE INGRESAR MÁS DE UN MOTIVO A UN SUPLEMENTO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_MOTIVOS_SPTO { get; set; }
        /// <summary>
        /// TIPO DE ACCESO POR FECHA A LOS CUADROS DE COMISIÓN.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_ACCESO_COM { get; set; }
        /// <summary>
        /// INDICA SI EL RAMO PERMITE RECHAZAR Y SUSPENDER APLICACIONES EN EL PROGRAMA DE CONTROL TECNICO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_RECHAZA_SUSPENDE_APLI { get; set; }
        /// <summary>
        /// OBJETO QUE DETERMINA SI SE GENERA SUPLEMENTO EN LOS CAMBIOS DE PLAN DE PAGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_SPTO_PLAN_PAGO { get; set; }


        /// <summary>
        /// COBERTURAS DEL RAMO.
        /// </summary>
        [DataMember(), JsonProperty()] public List<A1002150> Coberturas { get; set; }
        /// <summary>
        /// CONCEPTOS DE DESGLOSE DEL RAMO.
        /// </summary>
        [DataMember(), JsonProperty()] public List<G2000180> DesglosePorCobertura { get; set; }
        /// <summary>
        /// CONCEPTOS DE DESGLOSE.
        /// </summary>
        [DataMember(), JsonProperty()] public List<G2000170> Desgloses { get; set; }
        /// <summary>
        /// DATOS VARIABLES DEL RAMO.
        /// </summary>
        [DataMember(), JsonProperty()] public List<G2000020> DatosVariables { get; set; }
        /// <summary>
        /// DATOS VARIABLES.
        /// </summary>
        [DataMember(), JsonProperty()] public List<G2000010> DatosVariablesGenericos { get; set; }

    }
}

