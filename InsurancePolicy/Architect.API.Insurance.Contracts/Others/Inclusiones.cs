using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Insurance.Contracts.Others
{
    [Serializable(), DataContract()]
    public partial class Inclusiones
    {
        /// <summary>
        /// ..
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        [DataMember(), JsonProperty()] public int Empresa { get; set; }
        [DataMember(), JsonProperty()] public bool TieneDependientes { get; set; }
        [DataMember(), JsonProperty()] public int CantidadDeDependientes { get; set; }
        [DataMember(), JsonProperty()] public bool Finalizado { get; set; }
        [DataMember(), JsonProperty()] public string CodigoDeImpresion { get; set; }
        [DataMember(), JsonProperty()] public string CantidadDeCanets { get; set; }
        [DataMember(), JsonProperty()] public string CantidadDeCertificados { get; set; }
        [DataMember(), JsonProperty()] public DateTime FechaDeRecibido { get; set; }
        [DataMember(), JsonProperty()] public DateTime FechaDeEnvioAPanama { get; set; }
        [DataMember(), JsonProperty()] public DateTime FechaDeEnvioACorredor { get; set; }
        [DataMember(), JsonProperty()] public string Tramite { get; set; }
        [DataMember(), JsonProperty()] public DateTime FechaEfectiva { get; set; }
        [DataMember(), JsonProperty()] public string Clase { get; set; }
        [DataMember(), JsonProperty()] public string Nombre { get; set; }
        [DataMember(), JsonProperty()] public string Apellido { get; set; }
        [DataMember(), JsonProperty()] public string Cedula { get; set; }
        [DataMember(), JsonProperty()] public string Observacines { get; set; }
        [DataMember(), JsonProperty()] public DateTime FechaDeEnvioDeLaObservacion { get; set; }
        [DataMember(), JsonProperty()] public DateTime FechaNacimiento { get; set; }
        [DataMember(), JsonProperty()] public string Sexo { get; set; }
        [DataMember(), JsonProperty()] public string Estatus { get; set; }
        [DataMember(), JsonProperty()] public string TipoDeIdentificacion { get; set; }
        [DataMember(), JsonProperty()] public string CorreoElectronico { get; set; }
        [DataMember(), JsonProperty()] public string NroCuenta { get; set; }
        [DataMember(), JsonProperty()] public int Plan { get; set; }
        [DataMember(), JsonProperty()] public int Certificado { get; set; }
        [DataMember(), JsonProperty()] public double DeducibleConsumido { get; set; }
        [DataMember(), JsonProperty()] public double DeducibleMaximoVitalicio { get; set; }
        [DataMember(), JsonProperty()] public double StopLost { get; set; }
        [DataMember(), JsonProperty()] public string EmployeeNumber { get; set; }


        [DataMember(), JsonProperty()] public List<InclusionesExtra> Extras { get; set; }
    }

    /// <summary>
    /// InclusionesExtra
    /// </summary>
    [Serializable(), DataContract()]
    public partial class InclusionesExtra
    {
        [DataMember(), JsonProperty()] public int Id { get; set; }
        [DataMember(), JsonProperty()] public int Consecutivo { get; set; }
        [DataMember(), JsonProperty()] public string TipoExtra { get; set; }
        [DataMember(), JsonProperty()] public string IdentificacionExtra { get; set; }
        [DataMember(), JsonProperty()] public string NombreExtra { get; set; }
        [DataMember(), JsonProperty()] public string ApellidoExtra { get; set; }
        [DataMember(), JsonProperty()] public int EdadExtra { get; set; }
        [DataMember(), JsonProperty()] public string ParentescoExtra { get; set; }
        [DataMember(), JsonProperty()] public DateTime FechaInclusionExtra { get; set; }
        [DataMember(), JsonProperty()] public DateTime FechaExclusionExtra { get; set; }
        [DataMember(), JsonProperty()] public int ParticipacionExtra { get; set; }
        [DataMember(), JsonProperty()] public string TipoDeIdentificacionExtra { get; set; }
        [DataMember(), JsonProperty()] public int PlanEx { get; set; }
        [DataMember(), JsonProperty()] public double DeducibleConsumidoEx { get; set; }
        [DataMember(), JsonProperty()] public double DeducibleMaximoVitalicioEx { get; set; }
        [DataMember(), JsonProperty()] public double StopLossEx { get; set; }
        [DataMember(), JsonProperty()] public DateTime FechaNacimientoEx { get; set; }
    }

}

