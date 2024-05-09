using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Casos asociados a los procesos.
    /// </summary>
    public partial class ProcessCase
    {
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañia propietaria.
        /// </summary>
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Nivel de prioridad
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// Descripción para nivel de prioridad
        /// </summary>
        public string PriorityDesc { get; set; }
        /// <summary>
        /// Identificación única del registro.
        /// </summary>
        public int InstanceId { get; set; }
        public int CurrentStepId { get; set; }
        /// <summary>
        /// Campo de referencia 1.
        /// </summary>
        public string Reference1 { get; set; }
        /// <summary>
        /// Campo de referencia 2.
        /// </summary>
        public string Reference2 { get; set; }
        /// <summary>
        /// Campo de referencia 3.
        /// </summary>
        public string Reference3 { get; set; }
        /// <summary>
        /// Campo de referencia 4.
        /// </summary>
        public string Reference4 { get; set; }
        /// <summary>
        /// Campo de referencia 5.
        /// </summary>
        public string Reference5 { get; set; }
        /// <summary>
        /// Campo de referencia 6.
        /// </summary>
        public string Reference6 { get; set; }
        /// <summary>
        /// Campo de referencia 7.
        /// </summary>
        public string Reference7 { get; set; }
        /// <summary>
        /// Campo de referencia 8.
        /// </summary>
        public string Reference8 { get; set; }
        /// <summary>
        /// Campo de referencia 9.
        /// </summary>
        public string Reference9 { get; set; }
        /// <summary>
        /// Campo de referencia 10.
        /// </summary>
        public string Reference10 { get; set; }
        /// <summary>
        /// Nombre completo del contacto externo.
        /// </summary>
        public string ContactMainName { get; set; }
        /// <summary>
        /// Correo electrónico del contacto externo.
        /// </summary>
        public string ContactMainEmail { get; set; }
        /// <summary>
        /// 1 Inicio, 2 En progreso, 3 Finalizado
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Descripción para 1 inicio, 2 en progreso, 3 finalizado
        /// </summary>
        public string StatusDesc { get; set; }
        /// <summary>
        /// Etiqueta asociada al paso del proceso
        /// </summary>
        public string Label { get; set; }
        public int SubStatus { get; set; }
        public string SubLabel { get; set; }
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        public int FlowId { get; set; }
        /// <summary>
        /// Descripción para identificación única del proceso.
        /// </summary>
        public string FlowIdDesc { get; set; }
        public int UserId { get; set; }
        public string UserIdDesc { get; set; }
        public int SLA { get; set; }
        public string SLADesc { get; set; }
        /// <summary>
        /// Usuario que actualizo por última vez el registro.
        /// </summary>
        public int UpdateUserCode { get; set; }
        /// <summary>
        /// Nombre del usuario que actualizo por última vez el registro.
        /// </summary>
        public string UpdateUserName { get; set; }
        /// <summary>
        /// Fecha que se actualizo por última vez el registro.
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// ID del usuario enviando el caso.
        /// </summary>
        public int UserSend { get; set; }

        /// <summary>
        /// ID del usuario enviando el caso.
        /// </summary>
        public int TotalDays { get; set; }
    }
}

