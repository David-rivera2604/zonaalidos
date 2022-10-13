using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Cotizacion
{
    /// <summary>
    /// Información de una cotización de saldo deudor.
    /// </summary>
    public class SaldoDeudor : GenericQuote
    {
        /// <summary>
        /// Fecha de nacimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_NACIMIENTO { get; set; }
        /// <summary>
        /// Sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_SEXO { get; set; }
        /// <summary>
        /// Modalidad de riesgo.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_MODALIDAD_RIESGO { get; set; }
        [DataMember(), JsonProperty()] public string NOM_MODALIDAD_RIESGO { get; set; }
        /// <summary>
        /// ¿Es un negocio migrado?.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_NEGOCIO_MIGRADO { get; set; }
        /// <summary>
        /// Compañía original.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_CIA_ORI { get; set; }
        /// <summary>
        /// Fecha de emisión original.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_EMISION_ORI { get; set; }
        /// <summary>
        /// Monto original del préstamo.
        /// </summary>
        [DataMember(), JsonProperty()] public double IMP_MONTO_ORI { get; set; }
        /// <summary>
        /// Saldo actual.
        /// </summary>
        [DataMember(), JsonProperty()] public double IMP_SLD_ACTUAL { get; set; }
        /// <summary>
        /// Número de préstamo.
        /// </summary>
        [DataMember(), JsonProperty()] public string NUM_PRESTAMO { get; set; }
        /// <summary>
        /// Tipo de negocio.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_NEGOCIO { get; set; }
        [DataMember(), JsonProperty()] public string NOM_TIP_NEGOCIO { get; set; }
        /// <summary>
        /// Prima informada.
        /// </summary>
        [DataMember(), JsonProperty()] public double IMP_PRIMA_INFORMADA { get; set; }
        /// <summary>
        /// Importe gastos de emisión.
        /// </summary>
        [DataMember(), JsonProperty()] public double IMP_GASTOS_EMISION { get; set; }
        /// <summary>
        /// % Descuento/recargo comercial.
        /// </summary>
        [DataMember(), JsonProperty()] public int PCT_DTO_COMERCIAL { get; set; }
        /// <summary>
        /// % Porcentaje descuento técnico.
        /// </summary>
        [DataMember(), JsonProperty()] public int PCT_DCTO_TECNICO { get; set; }
        /// <summary>
        /// Fecha primer financiamiento.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_PRIM_FINAN { get; set; }
        /// <summary>
        /// Fecha vencimiento Prestamo.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_VCTO_PRESTAMO { get; set; }

        /// <summary>
        /// Peso.
        /// </summary>
        [DataMember(), JsonProperty()] public double NUM_PESO { get; set; }

        /// <summary>
        /// Altura en centimetros.
        /// </summary>
        [DataMember(), JsonProperty()] public double NUM_ESTATURA_CM { get; set; }

        /// <summary>
        /// Indice de masa muscular.
        /// </summary>
        [DataMember(), JsonProperty()] public double NUM_IMC { get; set; }

        /// <summary>
        /// Enfermedades excluidas.
        /// </summary>
        [DataMember(), JsonProperty()] public List<enfermedadesexcluidas> enfermedadesexcluidas { get; set; }

        /// % Cuadro de Comision
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_CUADRO_COMI { get; set; }
    }

    /// <summary>
    /// Enfermedades excluidas.
    /// </summary>
    public class enfermedadesexcluidas
    {

        /// <summary>
        /// Id.
        /// </summary>
        [DataMember(), JsonProperty()] public int enfermedadesexcluidasId { get; set; }
        /// <summary>
        /// Enfermedades.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_ENF_EXC { get; set; }
        [DataMember(), JsonProperty()] public string NOM_ENF_EXC { get; set; }
        /// <summary>
        /// Observaciones.
        /// </summary>
        [DataMember(), JsonProperty()] public string TXT_OBS_ENF_EXC { get; set; }
        /// <summary>
        /// Tipo exclusión.
        /// </summary>
        [DataMember(), JsonProperty()] public string COD_TIP_EXC { get; set; }
        [DataMember(), JsonProperty()] public string NOM_TIP_EXC { get; set; }
        /// <summary>
        /// Fecha inicio de exclusión.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_INI_EXC { get; set; }
        /// <summary>
        /// Fecha fin de exclusión.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_FIN_EXC { get; set; }


    }
}
