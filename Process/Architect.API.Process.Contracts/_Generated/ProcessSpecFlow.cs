using System;

namespace Architect.API.Process.Contracts.General
{
    /// <summary>
    /// Especificación de un proceso.
    /// </summary>
    public partial class ProcessSpecFlow
    {
        /// <summary>
        /// Identificación única del proceso.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Nombre del proceso.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Descripción del proceso.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Alieas del proceso.
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// Indica el servidor de correo usado para las notificaciones.
        /// </summary>
        public int MailServer { get; set; }
        /// <summary>
        /// Descripción para indica el servidor de correo usado para las notificaciones.
        /// </summary>
        public string MailServerDesc { get; set; }
        /// <summary>
        /// Etiqueta asociada al campo de referencia 1.
        /// </summary>
        public string ReferenceCaption1 { get; set; }
        /// <summary>
        /// Tipo de valor asociado al campo de referencia 1.
        /// </summary>
        public int ReferenceType1 { get; set; }
        /// <summary>
        /// Descripción para tipo de valor asociado al campo de referencia 1.
        /// </summary>
        public string ReferenceType1Desc { get; set; }
        /// <summary>
        /// Indicador de requerido asociado al campo de referencia 1.
        /// </summary>
        public bool ReferenceRequired1 { get; set; }
        /// <summary>
        /// Lista de valores posibles asociados al campo de referencia 1.
        /// </summary>
        public string ReferenceLookupList1 { get; set; }
        /// <summary>
        /// Condición de tratamiento asociada al campo de referencia 1.
        /// </summary>
        public string ReferenceCondition1 { get; set; }
        /// <summary>
        /// Etiqueta asociada al campo de referencia 2.
        /// </summary>
        public string ReferenceCaption2 { get; set; }
        /// <summary>
        /// Tipo de valor asociado al campo de referencia 2.
        /// </summary>
        public int ReferenceType2 { get; set; }
        /// <summary>
        /// Descripción para tipo de valor asociado al campo de referencia 2.
        /// </summary>
        public string ReferenceType2Desc { get; set; }
        /// <summary>
        /// Indicador de requerido asociado al campo de referencia 2.
        /// </summary>
        public bool ReferenceRequired2 { get; set; }
        /// <summary>
        /// Lista de valores posibles asociados al campo de referencia 2.
        /// </summary>
        public string ReferenceLookupList2 { get; set; }
        /// <summary>
        /// Condición de tratamiento asociada al campo de referencia 2.
        /// </summary>
        public string ReferenceCondition2 { get; set; }
        /// <summary>
        /// Etiqueta asociada al campo de referencia 3.
        /// </summary>
        public string ReferenceCaption3 { get; set; }
        /// <summary>
        /// Tipo de valor asociado al campo de referencia 3.
        /// </summary>
        public int ReferenceType3 { get; set; }
        /// <summary>
        /// Descripción para tipo de valor asociado al campo de referencia 3.
        /// </summary>
        public string ReferenceType3Desc { get; set; }
        /// <summary>
        /// Indicador de requerido asociado al campo de referencia 3.
        /// </summary>
        public bool ReferenceRequired3 { get; set; }
        /// <summary>
        /// Lista de valores posibles asociados al campo de referencia 3.
        /// </summary>
        public string ReferenceLookupList3 { get; set; }
        /// <summary>
        /// Condición de tratamiento asociada al campo de referencia 3.
        /// </summary>
        public string ReferenceCondition3 { get; set; }
        /// <summary>
        /// Etiqueta asociada al campo de referencia 4.
        /// </summary>
        public string ReferenceCaption4 { get; set; }
        /// <summary>
        /// Tipo de valor asociado al campo de referencia 4.
        /// </summary>
        public int ReferenceType4 { get; set; }
        /// <summary>
        /// Descripción para tipo de valor asociado al campo de referencia 4.
        /// </summary>
        public string ReferenceType4Desc { get; set; }
        /// <summary>
        /// Indicador de requerido asociado al campo de referencia 4.
        /// </summary>
        public bool ReferenceRequired4 { get; set; }
        /// <summary>
        /// Lista de valores posibles asociados al campo de referencia 4.
        /// </summary>
        public string ReferenceLookupList4 { get; set; }
        /// <summary>
        /// Condición de tratamiento asociada al campo de referencia 4.
        /// </summary>
        public string ReferenceCondition4 { get; set; }
        /// <summary>
        /// Etiqueta asociada al campo de referencia 5.
        /// </summary>
        public string ReferenceCaption5 { get; set; }
        /// <summary>
        /// Tipo de valor asociado al campo de referencia 5.
        /// </summary>
        public int ReferenceType5 { get; set; }
        /// <summary>
        /// Descripción para tipo de valor asociado al campo de referencia 5.
        /// </summary>
        public string ReferenceType5Desc { get; set; }
        /// <summary>
        /// Indicador de requerido asociado al campo de referencia 5.
        /// </summary>
        public bool ReferenceRequired5 { get; set; }
        /// <summary>
        /// Lista de valores posibles asociados al campo de referencia 5.
        /// </summary>
        public string ReferenceLookupList5 { get; set; }
        /// <summary>
        /// Condición de tratamiento asociada al campo de referencia 5.
        /// </summary>
        public string ReferenceCondition5 { get; set; }
        /// <summary>
        /// Etiqueta asociada al campo de referencia 6.
        /// </summary>
        public string ReferenceCaption6 { get; set; }
        /// <summary>
        /// Tipo de valor asociado al campo de referencia 6.
        /// </summary>
        public int ReferenceType6 { get; set; }
        /// <summary>
        /// Descripción para tipo de valor asociado al campo de referencia 6.
        /// </summary>
        public string ReferenceType6Desc { get; set; }
        /// <summary>
        /// Indicador de requerido asociado al campo de referencia 6.
        /// </summary>
        public bool ReferenceRequired6 { get; set; }
        /// <summary>
        /// Lista de valores posibles asociados al campo de referencia 6.
        /// </summary>
        public string ReferenceLookupList6 { get; set; }
        /// <summary>
        /// Condición de tratamiento asociada al campo de referencia 6.
        /// </summary>
        public string ReferenceCondition6 { get; set; }
        /// <summary>
        /// Etiqueta asociada al campo de referencia 7.
        /// </summary>
        public string ReferenceCaption7 { get; set; }
        /// <summary>
        /// Tipo de valor asociado al campo de referencia 7.
        /// </summary>
        public int ReferenceType7 { get; set; }
        /// <summary>
        /// Descripción para tipo de valor asociado al campo de referencia 7.
        /// </summary>
        public string ReferenceType7Desc { get; set; }
        /// <summary>
        /// Indicador de requerido asociado al campo de referencia 7.
        /// </summary>
        public bool ReferenceRequired7 { get; set; }
        /// <summary>
        /// Lista de valores posibles asociados al campo de referencia 8.
        /// </summary>
        public string ReferenceLookupList7 { get; set; }
        /// <summary>
        /// Condición de tratamiento asociada al campo de referencia 7.
        /// </summary>
        public string ReferenceCondition7 { get; set; }
        /// <summary>
        /// Etiqueta asociada al campo de referencia 8.
        /// </summary>
        public string ReferenceCaption8 { get; set; }
        /// <summary>
        /// Tipo de valor asociado al campo de referencia 8.
        /// </summary>
        public int ReferenceType8 { get; set; }
        /// <summary>
        /// Descripción para tipo de valor asociado al campo de referencia 8.
        /// </summary>
        public string ReferenceType8Desc { get; set; }
        /// <summary>
        /// Indicador de requerido asociado al campo de referencia 8.
        /// </summary>
        public bool ReferenceRequired8 { get; set; }
        /// <summary>
        /// Lista de valores posibles asociados al campo de referencia 8.
        /// </summary>
        public string ReferenceLookupList8 { get; set; }
        /// <summary>
        /// Condición de tratamiento asociada al campo de referencia 8.
        /// </summary>
        public string ReferenceCondition8 { get; set; }
        /// <summary>
        /// Etiqueta asociada al campo de referencia 9.
        /// </summary>
        public string ReferenceCaption9 { get; set; }
        /// <summary>
        /// Tipo de valor asociado al campo de referencia 9.
        /// </summary>
        public int ReferenceType9 { get; set; }
        /// <summary>
        /// Descripción para tipo de valor asociado al campo de referencia 9.
        /// </summary>
        public string ReferenceType9Desc { get; set; }
        /// <summary>
        /// Indicador de requerido asociado al campo de referencia 9.
        /// </summary>
        public bool ReferenceRequired9 { get; set; }
        /// <summary>
        /// Lista de valores posibles asociados al campo de referencia 9.
        /// </summary>
        public string ReferenceLookupList9 { get; set; }
        /// <summary>
        /// Condición de tratamiento asociada al campo de referencia 9.
        /// </summary>
        public string ReferenceCondition9 { get; set; }
        /// <summary>
        /// Etiqueta asociada al campo de referencia 10.
        /// </summary>
        public string ReferenceCaption10 { get; set; }
        /// <summary>
        /// Tipo de valor asociado al campo de referencia 10.
        /// </summary>
        public int ReferenceType10 { get; set; }
        /// <summary>
        /// Descripción para tipo de valor asociado al campo de referencia 10.
        /// </summary>
        public string ReferenceType10Desc { get; set; }
        /// <summary>
        /// Indicador de requerido asociado al campo de referencia 10.
        /// </summary>
        public bool ReferenceRequired10 { get; set; }
        /// <summary>
        /// Lista de valores posibles asociados al campo de referencia 10.
        /// </summary>
        public string ReferenceLookupList10 { get; set; }
        /// <summary>
        /// Condición de tratamiento asociada al campo de referencia 10.
        /// </summary>
        public string ReferenceCondition10 { get; set; }
        public int SLA { get; set; }

        /// <summary>
        /// Duración del Acuerdo de Nivel de Servicio (SLA) en horas.
        /// </summary>
        public int SLADuration { get; set; }

        /// <summary>
        /// Estado (Activo/Inactivo)
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Descripción para estado (activo/inactivo)
        /// </summary>
        public string StatusDesc { get; set; }
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


    }
}