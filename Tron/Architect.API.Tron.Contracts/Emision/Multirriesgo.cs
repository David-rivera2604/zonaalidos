using Architect.API.Core.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Architect.API.Tron.Contracts.Emision
{
    public class Multirriesgo : Cotizacion.Multirriesgo
    {
        /// <summary>
        /// No. de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string num_poliza { get; set; }

        /// <summary>
        /// Año de construcción.
        /// </summary>
        [DataMember(), JsonProperty()] public int anodeconstruccion { get; set; }

        /// <summary>
        /// Terceros.
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.tercero> terceros { get; set; }
        /// <summary>
        /// Documentos requeridos.
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.DocumentoRequerido> documentosrequeridos { get; set; }


        [DataMember(), JsonProperty()] public string tip_firma { get; set; } = "";
        [DataMember(), JsonProperty()] public string tip_firmaDesc { get; set; }

        [DataMember(), JsonProperty()] public string correoenvio { get; set; }
        [DataMember(), JsonProperty()] public string Modo { get; set; }

        [DataMember(), JsonProperty()] public string Fuente_Tomador { get; set; } = "SCOTIABANK";

        [DataMember(), JsonProperty()] public EconomicData DatosEconomicos { get; set; }
        [DataMember(), JsonProperty()] public string kyctipo { get; set; }
        [DataMember(), JsonProperty()] public object kyc { get; set; }
        [DataMember(), JsonProperty()] public object datosvariables { get; set; }
        /// <summary>
        /// Conozca a su cliente
        /// </summary>
        [DataMember(), JsonProperty()] public Comun.ConoceTuCliente ConoceTuCliente { get; set; }
    }
    public class MultirriesgoSolicitud : Multirriesgo
    {
        [DataMember(), JsonProperty()] public Contracts.Comun.tercero titular { get; set; }
        [DataMember(), JsonProperty()] public Contracts.Comun.tercero asegurado { get; set; }
        [DataMember(), JsonProperty()] public Contracts.Comun.tercero acredor { get; set; }

        [DataMember(), JsonProperty()] public string mainrole { get; set; }

    }

    public class MultirriesgoTerceros : Comun.tercero
    {


        /// <summary>
        /// Sexo.
        /// </summary>
        [DataMember(), JsonProperty()] public int mca_sexo { get; set; }

        /// <summary>
        /// País.
        /// </summary>
        [DataMember(), JsonProperty()] public string tercerosCod_pais { get; set; }



    }

}
