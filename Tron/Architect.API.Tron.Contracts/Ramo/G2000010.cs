using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Ramo
{
    /// <summary>
    /// DATOS VARIABLES.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class G2000010
    {
        /// <summary>
        /// CODIGO DE COMPAÑIA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_CIA { get; set; }
        /// <summary>
        /// NOMBRE DEL DATO VARIABLE.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_CAMPO { get; set; }
        /// <summary>
        /// MODULO DE LA ETIQUETA (COD_MODULO + COD_TEXTO = ETIQUETA).
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_MODULO { get; set; }
        /// <summary>
        /// IDENTIFICADOR DE LA ETIQUETA (COD_MODULO + COD_TEXTO = ETIQUETA).
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_TEXTO { get; set; }
        /// <summary>
        /// DESCRIPCION.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_CAMPO { get; set; }
        /// <summary>
        /// TIPO DE DATO QUE PERMITE ALMACENAR (NUMEROS, LETRAS, FECHAS).
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_CAMPO { get; set; }
        /// <summary>
        /// LONGITUD MAXIMA QUE ACEPTA.
        /// </summary>
        [DataMember(), JsonProperty()] public int LNG_CAMPO { get; set; }
        /// <summary>
        /// AREA A LA QUE PERTENECE (EMISION, STROS, .).
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_SISTEMA { get; set; }
        /// <summary>
        /// FILA INHABILITADA.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_INH { get; set; }
        /// <summary>
        /// SE MUESTRA EN EL PROCESO DE SINIESTROS.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_SINI { get; set; }
        /// <summary>
        /// OBLIGATORIO.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_OBLIGATORIO { get; set; }
        /// <summary>
        /// TIENE VALIDACIONES ESTANDAR.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_VALIDACION { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE DETERMINA EL VALOR POR DEFECTO Y SI ESTE VALOR ES MODIFICACBLE POR PARTE DEL USUARIO.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_PRE_CAMPO { get; set; }
        /// <summary>
        /// PROCEDIMIENTO QUE REALIZA LA VALIDACION.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PRG_CAMPO { get; set; }
        /// <summary>
        /// VALOR POR DEFECTO.
        /// </summary>
        [DataMember(), JsonProperty()] public string VAL_DEFECTO { get; set; }
        /// <summary>
        /// PROGRAMA QUE PROPORCIONA LA AYUDA.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_PGM_HELP { get; set; }
        /// <summary>
        /// VERSION DEL PROGRAMA DE AYUDA.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_VERSION { get; set; }
        /// <summary>
        /// GOBAL QUE CONTIENE EL VALOR DESPUES DE ACCEDER A LA AYUD.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_GLOBAL_PGM_HELP { get; set; }
        /// <summary>
        /// TABLA DONDE SE ENCUENTRA LOS.
        /// </summary>
        [DataMember(), JsonProperty()] public string NOM_TABLA_VALIDA { get; set; }
        /// <summary>
        /// USUARIO QUE ACTUALIZO LA FILA.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_USR { get; set; }
        /// <summary>
        /// FECHA DE LA ULTIMA ACTUALIZACION DEL REGISTRO.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_ACTU { get; set; }
    }
}

