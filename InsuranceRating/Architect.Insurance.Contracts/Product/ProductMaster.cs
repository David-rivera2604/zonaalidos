using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{
    /// <summary>
    /// Característica de un producto. Este contrato representa la tabla principal o raíz para la definición de un producto.
    /// </summary>
    /// <remarks>VT.PRODMASTER</remarks>
    public class ProductMaster
    {
        /// <summary>
        /// Código del ramo comercial.
        /// </summary>
        /// <remarks>VT.PRODMASTER.NBRANCH</remarks>
        [DataMember(EmitDefaultValue =false)]
        [XmlAttribute("lineofbusiness")]
        [DefaultValue(0)]
        public Int32 LineOfBusiness { get; set; }

        /// <summary>
        /// Código del producto.
        /// </summary>
        /// <remarks>VT.PRODMASTER.NPRODUCT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("productcode")]
        [DefaultValue(0)]
        public Int32 ProductCode { get; set; }

        /// <summary>
        /// Descripción del producto.
        /// </summary>
        /// <remarks>VT.PRODMASTER.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// Descripción abreviada o alias del producto.
        /// </summary>
        /// <remarks>VT.PRODMASTER.SSHORT_DES</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("alias")]
        [DefaultValue("")]
        public string Alias { get; set; }

        /// <summary>
        /// Frecuencia de pago de la prima.
        /// </summary>
        /// <remarks>VT.PRODUCT.NPAYFREQ</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("defaultpaymentfrequency")]
        [DefaultValue(0)]
        public Int16 DefaultPaymentFrequency { get; set; }

        /// <summary>
        /// Vía de pago
        /// </summary>
        /// <remarks>VT.PRODUCT.NWAY_PAY</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("defaultpaymentmethod")]
        [DefaultValue(0)]
        public Int16 DefaultPaymentMethod  { get; set; }

        /// <summary>
        /// Estado del registro.
        /// </summary>
        /// <remarks>VT.PRODUCT.SSTATREGT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("status")]
        [DefaultValue(1)]
        public Int16 Status { get; set; }

        /// <summary>
        /// Descripción del estado del registro.
        /// </summary>
        /// <remarks>VT.TABLE26.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("statusdescription")]
        [DefaultValue("")]
        public string StatusDescription { get; set; }

        /// <summary>
        /// Clientes permitidos.
        /// </summary>
        /// <remarks>VT.CLIALLOPRO</remarks>
        public List<ClientAllowed> ClientsAllowed { get; set; }

        /// <summary>
        /// Monedas permitidas.
        /// </summary>
        /// <remarks>VT.CUR_ALLOW</remarks>
        public List<CurrencyAllowed> CurrenciesAllowed { get; set; }

        /// <summary>
        /// Módulos.
        /// </summary>
        /// <remarks>VT.TAB_MODUL</remarks>
        public List<Module> Modules { get; set; }

        /// <summary>
        /// Frecuencias de pago permitidas y recargo por fraccionamiento del pago.
        /// </summary>
        /// <remarks>VT.PAY_FRACTI</remarks>
        public List<PaymentFrequencyAllowed> PaymentFrequenciesAllowed { get; set; }

        /// <summary>
        /// Vías de pago permitidas.
        /// </summary>
        /// <remarks>VT.WAY_PAY_PROD</remarks>
        public List<PaymentMethodAllowed> PaymentMethodsAllowed { get; set; }

        /// <summary>
        /// Conceptos de facturación.
        /// </summary>
        /// <remarks>VT.TAB_BILL_I</remarks>
        public List<BillingConcept> BillingConcepts { get; set; }

        /// <summary>
        /// Elementos de protección.
        /// </summary>
        /// <remarks>VT.TAB_PROTEC</remarks>
        public List<Protection> Protections { get; set; }

        /// <summary>
        /// Requisitos y exclusiones.
        /// </summary>
        /// <remarks>VT.TAB_REQEXC</remarks>
        public List<RequerimentExclusion> RequerimentExclusions { get; set; }

        /// <summary>
        /// ...funcionalidad pendiente de ser detallada...
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        public List<SmartEntity> SmartEntities { get; set; }

        /// <summary>
        /// Titulo principal a nivel de la pantalla.
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("title")]
        [DefaultValue("")]
        public string Title { get; set; }

        /// <summary>
        /// Titulo complementario a nivel de la pantalla.
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("subtitle")]
        [DefaultValue("")]
        public string SubTitle { get; set; }


        /// <summary>
        /// Secuencia de ventanas para el tratamiento de póliza.
        /// </summary>
        /// <remarks>VT.SEQUEN_POL</remarks>
        public List<DataEntrySection> DataEntrySectionsAllowed { get; set; }

        /// <summary>
        /// Constructor por 'default'.
        /// </summary>
        public ProductMaster()
        {
            Status = 1;
        }

        /// <summary>
        /// Variables especificas para un producto.
        /// </summary>
        public List<Setting> Settings { get; set; }

        //public List<Underwriting.Rule> Underwriting { get; set; }
    }
}
