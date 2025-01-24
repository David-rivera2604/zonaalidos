using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Emision
{
    public class HogarTotal : Cotizacion.HogarTotal

    {
        /// <summary>
        /// No. de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string num_poliza { get; set; }


        /// <summary>
        /// Correo principal.
        /// </summary>
        [DataMember(), JsonProperty()] public string correoprincipal { get; set; }
        /// <summary>
        /// Correo copia 1.
        /// </summary>
        [DataMember(), JsonProperty()] public string correocopia1 { get; set; }
        /// <summary>
        /// Correo copia 2.
        /// </summary>
        [DataMember(), JsonProperty()] public string correocopia2 { get; set; }

        /// <summary>
        /// Terceros
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.tercero> terceros { get; set; }

        /// <summary>
        /// Propiedad
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.propiedad> propiedad { get; set; }

        /// <summary>
        /// Documentos requeridos
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.DocumentoRequerido> documentosrequeridos { get; set; }
        [DataMember(), JsonProperty()] public string Fuente_Tomador { get; set; } = "SCOTIABANK";
        [DataMember(), JsonProperty()] public string Modo { get; set; }

        [DataMember(), JsonProperty()] public EconomicData DatosEconomicos { get; set; }

        [DataMember(), JsonProperty()] public string tip_firma { get; set; } = "";
        [DataMember(), JsonProperty()] public string tip_firmaDesc { get; set; }

        [DataMember(), JsonProperty()] public string correoenvio { get; set; }

        [DataMember(), JsonProperty()] public object kyc { get; set; }

        /// <summary>
        /// Conozca a su cliente
        /// </summary>
        [DataMember(), JsonProperty()] public Comun.ConoceTuCliente ConoceTuCliente { get; set; }

        /// <summary>
        ///  Se usa para los casos donde se quiera almacenar el nombre de la persona que emite en txt_motivo_spto
        /// </summary>
        [DataMember(), JsonProperty()] public string user_txt_motivo_spto { get; set; }

    }

    public class HogarTotalSolicitud : HogarTotal
    {
        [DataMember(), JsonProperty()] public Contracts.Comun.tercero titular { get; set; }
        [DataMember(), JsonProperty()] public Contracts.Comun.tercero asegurado { get; set; }
        [DataMember(), JsonProperty()] public Contracts.Comun.tercero acredor { get; set; }
        [DataMember(), JsonProperty()] public string mainrole { get; set; }
    }



}