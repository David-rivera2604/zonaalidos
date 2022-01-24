using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Ramo
{
    /// <summary>
    /// DATOS VARIABLES DEL RAMO.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class G2000020
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
        /// COBERTURA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_COB { get; set; }
        /// <summary>
        /// AGRAVANTE/DEDUCCION.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_AGR { get; set; }
        /// <summary>
        /// FECHA DE VALIDEZ.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_VALIDEZ { get; set; }
        /// <summary>
        /// NIVEL DE PETICION.
        /// </summary>
        [DataMember(), JsonProperty()] public int TIP_NIVEL { get; set; }
        /// <summary>
        /// SECUENCIA.
        /// </summary>
        [DataMember(), JsonProperty()] public int NUM_SECU { get; set; }
        /// <summary>
        /// NOMBRE DEL DATO VARIABLE.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_CAMPO { get; set; }
        /// <summary>
        /// FILA INHABILITADA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_INH { get; set; }
        /// <summary>
        /// SE MUESTRA EN LA PANTALLA ESTANDAR.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_VISIBLE { get; set; }
        /// <summary>
        /// OBLIGATORIO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_OBLIGATORIO { get; set; }
        /// <summary>
        /// ES NECESARIO LANZAR LA VALIDACION AUNQUE NO TENGA VALOR.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_VALIDA_SI_NULL { get; set; }
        /// <summary>
        /// ESTE DATO DETERMINA LA MODALIDAD.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_MODALIDAD { get; set; }
        /// <summary>
        /// TERCERO POR EL QUE SE HA CALCULADO EL RIESGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_CALCULO { get; set; }
        /// <summary>
        /// OBLIGATORIO EN PRESUPUESTOS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_PRESUPUESTO { get; set; }
        /// <summary>
        /// SE MUESTRA EN EL PROCESO DE SINIESTROS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_SINI { get; set; }
        /// <summary>
        /// EL DATO ES UNICO. NO PUEDE EXISTIR OTRA POLZIA CON EL MISMO VALOR EN EL MISMO PERIODO DE VIGENCIA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_UNICO { get; set; }
        /// <summary>
        /// EL DATO VARIABLE FORMA PARTE DEL FORMULARIO DE INSPECCION.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_INSPEC { get; set; }
        /// <summary>
        /// A LA HORA DE ASOCIAR UNA INSPECCION A LA POLIZA, SI SE BUSCA POR ESTE DATO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_BUSCA_INSP { get; set; }
        /// <summary>
        /// LA INSPECCION SE BUSA POR EL VALOR IGUAL.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_BUSCA_POR_IGUAL_INSP { get; set; }
        /// <summary>
        /// ES NECESARIO INTRODUCIRLO CUANDO SE COPIA UN RIESGO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_SOLICITA_EN_COPIA { get; set; }
        /// <summary>
        /// EN CASO DE RECHAZO, SE ALMACENA ESTE VALOR EN UN HISTORICO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_GRABA_RECHAZO { get; set; }
        /// <summary>
        /// EL DATO, REALMENTE ES UN CAPITAL.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_SUMA_ASEG { get; set; }
        /// <summary>
        /// TIENE VALIDACIONES ESTANDAR.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_VALIDACION { get; set; }
        /// <summary>
        /// TIENE VALIDACIONES ESTANDAR A NIVEL DE COMPANIA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_VALIDACION_CIA { get; set; }
        /// <summary>
        /// USUARIO QUE ACTUALIZO LA FILA.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_USR { get; set; }
        /// <summary>
        /// FECHA DE LA ULTIMA ACTUALIZACION DEL REGISTRO.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_ACTU { get; set; }
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
        /// PROCEDIMIENTO QUE DETERMINA EL VALOR POR DEFECTO Y SI ESTE VALOR ES MODIFICACBLE POR PARTE DEL USUARIO.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_PRE_CAMPO { get; set; }
        /// <summary>
        /// VALOR POR DEFECTO.
        /// </summary>
        [DataMember(), JsonProperty()] public string VAL_DEFECTO { get; set; }
        /// <summary>
        /// TABLA DONDE SE ENCUENTRA LOS VALORES POR DEFECTO.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_TABLA_VAL_DEFECTO { get; set; }
        /// <summary>
        /// COLUMNA DONDE SE ENCUENTRA EL VALOR POR DEFECTO.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_CAMPO_TABLA_VAL_DEFECTO { get; set; }
        /// <summary>
        /// PROGRAMA QUE PROPORCIONA LA AYUDA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PGM_HELP { get; set; }
        /// <summary>
        /// TABLA DONDE SE ENCUENTRA LOS.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_TABLA_VALIDA { get; set; }
        /// <summary>
        /// VERSION DEL PROGRAMA DE AYUDA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_VERSION { get; set; }
        /// <summary>
        /// GOBAL QUE CONTIENE EL VALOR DESPUES DE ACCEDER A LA AYUD.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_GLOBAL_PGM_HELP { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE REALIZA LA VALIDACION.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_CAMPO { get; set; }
        /// <summary>
        /// OCURRENCIA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_LISTA { get; set; }
        /// <summary>
        /// PARA TRATAMIENTO DE TRANSPORTES SI ES EXCLUSIVO DE LA POLIZA MARCO DE LA APLICACION O ES VALIDO PARA LAS ANTERIORES.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_TRANSPORTES { get; set; }
        /// <summary>
        /// SECUENCIA DE BUSQUEDA EN INSPECCIONES.
        /// </summary>
        [DataMember(), JsonProperty()] public int NUM_SECU_INSP { get; set; }
    }
}

