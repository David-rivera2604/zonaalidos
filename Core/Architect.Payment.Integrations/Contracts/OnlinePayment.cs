using Newtonsoft.Json;
using System;

namespace Architect.Payment.Integrations.Contracts
{
    /// <summary>
    /// Pagos en línea
    /// </summary>
    public partial class OnlinePayment
    {
        /// <summary>
        /// Identificación única del pago.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identificación de la compañía propietaria.
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Tipo de documento.
        /// </summary>
        public int DocumentType { get; set; }
        /// <summary>
        /// Descripción para tipo de documento.
        /// </summary>
        public string DocumentTypeDesc { get; set; }
        /// <summary>
        /// Documento o número de identificación.
        /// </summary>
        public string DocumentNumber { get; set; }
        /// <summary>
        /// Primer nombre.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Primer apellido.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Dirección de correo electrónico (principal)
        /// </summary>
        public string PrimaryEmailAddress { get; set; }
        /// <summary>
        /// Número de teléfono del celular.
        /// </summary>
        public string PhoneNumberMobile { get; set; }

        public int AgentCode { get; set; }
        public string PolicyId { get; set; }
        public Int64 BillNumber { get; set; }
        /// <summary>
        /// Moneda.
        /// </summary>
        public int Currency { get; set; }
        /// <summary>
        /// Descripción para moneda.
        /// </summary>
        public string CurrencyDesc { get; set; }
        /// <summary>
        /// Suma asegurada complementaria.
        /// </summary>
        public double Amount { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Fecha de alta.
        /// </summary>
        public DateTime IssueDate { get; set; }
        public DateTime StatusDate { get; set; }
        public Int64 RequestID { get; set; }
        public string ProcessUrl { get; set; }
        public string ProviderStatus { get; set; }
        public string ProviderStatusDesc { get; set; }
        public string ResponseData { get; set; }

        public string Reason { get; set; }


        public string Receipt { get; set; }

        public string Authorization { get; set; }

        public int TronCode { get; set; }
        public string TronMessage { get; set; }

        /// <summary>
        /// Estado de la póliza.
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Descripción para estado de la póliza.
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

        /// <summary>
        /// Identifica la configuración de acceso usada por la sesión.
        /// </summary>
        public int SettingId { get; set; }

        public bool RecurringReceipt { get; set; }

        public string ProcessId { get; set; }

        public string Source { get; set; }

    }
}

