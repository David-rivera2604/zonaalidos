using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Pasos o estados de un proceso.
    /// </summary>
    [Serializable(), DataContract()]
    public partial class ProcessSpecStep
    {
        /// <summary>
        /// Identificación única del paso.
        /// </summary>
        [DataMember(), JsonProperty()] public int Id { get; set; }
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public int FlowId { get; set; }
        /// <summary>
        /// Descripción para identificación única del proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public string FlowIdDesc { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        [DataMember(), JsonProperty()] public int CompanyId { get; set; }
        /// <summary>
        /// Nombre del paso o estado.
        /// </summary>
        [DataMember(), JsonProperty()] public string Name { get; set; }
        /// <summary>
        /// Descripción del paso o estado.
        /// </summary>
        [DataMember(), JsonProperty()] public string Description { get; set; }
        ///// <summary>
        ///// Define el tiempo maximo en minutos para que el paso o estado se de por procesado.
        ///// </summary>
        //[DataMember(), JsonProperty()] public int SLATimeOut { get; set; }
        /// <summary>
        /// Orden en que se procesan los pasos para un proceso.
        /// </summary>
        [DataMember(), JsonProperty()] public int StepOrder { get; set; }
        /// <summary>
        /// 1 Inicio, 2 En progreso, 3 Finalizado
        /// </summary>
        [DataMember(), JsonProperty()] public int ProcessStatus { get; set; }
        /// <summary>
        /// Descripción para 1 inicio, 2 en progreso, 3 finalizado
        /// </summary>
        [DataMember(), JsonProperty()] public string ProcessStatusDesc { get; set; }
        /// <summary>
        /// Etiqueta asociada al paso del proceso
        /// </summary>
        [DataMember(), JsonProperty()] public string ProcessLabel { get; set; }
        [DataMember(), JsonProperty()] public bool EnableComment { get; set; }
        /// <summary>
        /// Tipo de progreso.
        /// </summary>
        [DataMember(), JsonProperty()] public int ProgressMode { get; set; }
        /// <summary>
        /// Descripción para tipo de progreso.
        /// </summary>
        [DataMember(), JsonProperty()] public string ProgressModeDesc { get; set; }
        [DataMember(), JsonProperty()] public int SLA { get; set; }

        /// <summary>
        /// Define la duración del SLO en minutos.
        /// </summary>
        [DataMember(), JsonProperty()]
        public int SLODuration { get; set; }

        [DataMember(), JsonProperty()] public int MailServer { get; set; }
        [DataMember(), JsonProperty()] public string MailServerDesc { get; set; }
        /// <summary>
        /// Enviar notificacion por correo al contacto
        /// </summary>
        [DataMember(), JsonProperty()] public int MailToContact { get; set; }
        /// <summary>
        /// Descripción para enviar notificacion por correo al contacto
        /// </summary>
        [DataMember(), JsonProperty()] public string MailToContactDesc { get; set; }
        /// <summary>
        /// Enviar notificacion por correo al contacto
        /// </summary>
        [DataMember(), JsonProperty()] public string MailToContactCustom { get; set; }
        [DataMember(), JsonProperty()] public int MailToContactTmpl { get; set; }
        [DataMember(), JsonProperty()] public string MailToContactTmplDesc { get; set; }
        /// <summary>
        /// Enviar notificacion por correo a los usuarios de los roles responsables
        /// </summary>
        [DataMember(), JsonProperty()] public int MailToStepResponsible { get; set; }
        /// <summary>
        /// Descripción para enviar notificacion por correo a los usuarios de los roles responsables
        /// </summary>
        [DataMember(), JsonProperty()] public string MailToStepResponsibleDesc { get; set; }
        /// <summary>
        /// Enviar notificacion por correo a los usuarios de los roles responsables
        /// </summary>
        [DataMember(), JsonProperty()] public string MailToStepResponsibleCustom { get; set; }
        [DataMember(), JsonProperty()] public int MailToStepResponsibleTmpl { get; set; }
        [DataMember(), JsonProperty()] public string MailToStepResponsibleTmplDesc { get; set; }
        //[DataMember(), JsonProperty()] public int MailForSLAExpiration { get; set; }
        //[DataMember(), JsonProperty()] public string MailForSLAExpirationDesc { get; set; }
        //[DataMember(), JsonProperty()] public string MailForSLAExpirationCustom { get; set; }
        //[DataMember(), JsonProperty()] public int MailForSLAExpirationTmpl { get; set; }
        //[DataMember(), JsonProperty()] public string MailForSLAExpirationTmplDesc { get; set; }
        /// <summary>
        /// Establece un script que es ejecutado al activarse el paso (Script).
        /// </summary>
        [DataMember(), JsonProperty()] public string PreScript { get; set; }
        /// <summary>
        /// Establece un script que es ejecutado al darse por procesado el paso (Script).
        /// </summary>
        [DataMember(), JsonProperty()] public string PostScript { get; set; }
        /// <summary>
        /// Usuario que actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public int UpdateUserCode { get; set; }
        /// <summary>
        /// Nombre del usuario que actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public string UpdateUserName { get; set; }
        /// <summary>
        /// Fecha que se actualizo por última vez el registro.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime UpdateDate { get; set; }

        [DataMember(), JsonProperty()] public string RoleNames { get; set; }


        [DataMember(), JsonProperty()] public string References { get; set; }

    }
}

