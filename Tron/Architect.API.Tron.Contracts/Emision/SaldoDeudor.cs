using Architect.API.Insurance.Contracts.Base;
using Architect.API.Insurance.Contracts.Policy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Emision
{
    /// <summary>
    /// Información de una póliza de saldo deudor.
    /// </summary>
    public class SaldoDeudor : Cotizacion.SaldoDeudor
    {
        /// <summary>
        /// No. de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string num_poliza { get; set; }

        /// <summary>
        /// Terceros
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.tercero> terceros { get; set; }

        /// <summary>
        /// Documentos requeridos
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.DocumentoRequerido> documentosrequeridos { get; set; }

        [DataMember(), JsonProperty()] public string tip_firma { get; set; } = "";
        [DataMember(), JsonProperty()] public string tip_firmaDesc { get; set; }

        [DataMember(), JsonProperty()] public string correoenvio { get; set; }

        [DataMember(), JsonProperty()] public string Modo { get; set; }

        [DataMember(), JsonProperty()] public List<Questionary> Questionary { get; set; }

    }
 
    [Serializable(), DataContract()]
    public class SaldoDeudorSolicitud : RiskView
    {

    }


    public class Questionary
    {
        [DataMember(), JsonProperty()] public int QuestionId { get; set; }
        [DataMember(), JsonProperty()] public int Confirmation { get; set; }
        [DataMember(), JsonProperty()] public string Detail { get; set; }
       
        [DataMember(), JsonProperty()] public string Summary { get; set; }
        [DataMember(), JsonProperty()] public DateTime When { get; set; }

        [DataMember(), JsonProperty()] public string Diagnosis { get; set; }

        [DataMember(), JsonProperty()] public string Doctor { get; set; }

        [DataMember(), JsonProperty()] public string Treatment { get; set; }

    }

    [Serializable(), DataContract()]
    public class RiskQuestionaryViews : RiskQuestionaryView
    {
    }

    [Serializable(), DataContract()]
    public partial class RiskQuestionViews : RiskQuestionView
    {

    }


}

