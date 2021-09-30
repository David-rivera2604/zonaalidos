using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{
    /// <summary>
    /// Coberturas.
    /// </summary>
    /// <remarks>VT.GEN_COVER,VT.TAB_COVROL,VT.LIFE_COVER</remarks>
    public class Coverage
    {
        /// <summary>
        /// Código de la cobertura.
        /// </summary>
        /// <remarks>VT.GEN_COVER.NCOVER,VT.TAB_COVROL.NCOVER</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("coveragecode")]
        [DefaultValue(0)]
        public Int32 CoverageCode { get; set; }

        /// <summary>
        /// Figura con la que actúa el cliente en la póliza.
        /// </summary>
        /// <remarks>VT.TAB_COVROL.NROLE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("clientrole")]
        [DefaultValue(0)]
        public Int32 ClientRole { get; set; }

        /// <summary>
        /// Descripción de la cobertura.
        /// </summary>
        /// <remarks>VT.TAB_GENCOV.SDESCRIPT,VT.TAB_LIFCOV.SDESCRIPT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("description")]
        [DefaultValue("")]
        public string Description { get; set; }

        /// <summary>
        /// Descripción abreviada o alias de la cobertura.
        /// </summary>
        /// <remarks>VT.TAB_GENCOV.SSHORT_DES,VT.TAB_LIFCOV.SSHORT_DES</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("alias")]
        [DefaultValue("")]
        public string Alias { get; set; }

        /// <summary>
        /// Indicador de seleccionado por defecto.
        /// </summary>
        /// <remarks>VT.GEN_COVER.SDEFAULTI,VT.TAB_COVROL.SDEFAULTI</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("selected")]
        [DefaultValue(false)]
        public bool Selected { get; set; }

        /// <summary>
        /// Indicador de que la cobertura es requerida.
        /// </summary>
        /// <remarks>VT.GEN_COVER.SREQUIRE,VT.TAB_COVROL.SREQUIRED</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("required")]
        [DefaultValue(false)]
        public bool Required { get; set; }

        /// <summary>
        /// Código de moneda.
        /// </summary>
        /// <remarks>VT.GEN_COVER.NCURRENCY,VT.LIFE_COVER.NCURRENCY</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("currencycode")]
        [DefaultValue(0)]
        public Int16 CurrencyCode { get; set; }

        /// <summary>
        /// Tipo de cálculo de capital.
        /// </summary>
        /// <remarks>VT.TAB_COVROL.SCACALTYP</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("insuredamountcalculationtype")]
        [DefaultValue(0)]
        public Int16 InsuredAmountCalculationType { get; set; }

        /// <summary>
        /// Descripción del tipo de cálculo de capital.
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("insuredamountcalculationtypedescription")]
        [DefaultValue("")]
        public string InsuredAmountCalculationTypeDescription { get; set; }

        /// <summary>
        /// Rutina de cálculo del capital de la cobertura.
        /// </summary>
        /// <remarks>VT.GEN_COVER.SROUCAPIT,VT.TAB_COVROL.SROUPRCAL</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("routineforcalculationofinsuredAmount")]
        [DefaultValue("")]
        public string RoutineForCalculationOfInsuredAmount { get; set; }

        /// <summary>
        /// Monto fijo de capital.
        /// </summary>
        /// <remarks>VT.GEN_COVER.NCACALFIX,VT.TAB_COVROL.NCACALFIX</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("fixedinsuredamount")]
        [DefaultValue(0)]
        public decimal FixedInsuredAmount { get; set; }

        /// <summary>
        /// Porcentaje a aplicar sobre el capital de otra cobertura para obtener el capital de la propia.
        /// </summary>
        /// <remarks>VT.GEN_COVER.NCACALPER,VT.TAB_COVROL.NCAPBASPE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("percentageonothercoverage")]
        [DefaultValue(0)]
        public decimal PercentageOnOtherCoverage { get; set; }

        /// <summary>
        /// Código de la cobertura sobre la que se aplica el porcentaje para obtener el capital de la cobertura.
        /// </summary>
        /// <remarks>VT.GEN_COVER.NCACALCOV,VT.TAB_COVROL.NCACALCOV</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("basecoverageforinsuredamount")]
        [DefaultValue(0)]
        public Int32 BaseCoverageForInsuredAmount { get; set; }

        /// <summary>
        /// Monto mínimo de capital asegurado.
        /// </summary>
        /// <remarks>VT.GEN_COVER.NCACALMIN,VT.TAB_COVROL.NCAPMINIM</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("minimuminsuredamount")]
        [DefaultValue(0)]
        public decimal MinimumInsuredAmount { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("premiumcalculationtype")]
        [DefaultValue(0)]
        public Int16 PremiumCalculationType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>VT.NONE</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("premiumcalculationtypedescription")]
        [DefaultValue("")]
        public string PremiumCalculationTypeDescription { get; set; }

        /// <summary>
        /// Rutina de cálculo y/o validación de la prima de la cobertura.
        /// </summary>
        /// <remarks>VT.GEN_COVER.SROUPREMI,VT.TAB_COVROL.SROUPREMI</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("routineforcalculationofpremium")]
        [DefaultValue("")]
        public string RoutineForCalculationOfPremium { get; set; }

        /// <summary>
        /// Tasa fija para el cálculo de la prima de la cobertura.
        /// </summary>
        /// <remarks>VT.GEN_COVER.NPREMIRAT,VT.TAB_COVROL.NPREMIRAT</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("fixedrate")]
        [DefaultValue(0)]
        public decimal FixedRate { get; set; }

        /// <summary>
        /// Monto de prima fija o monto a agregar a la prima.
        /// </summary>
        /// <remarks>VT.GEN_COVER.NPREMIFIX,VT.TAB_COVROL.NPREMIFIX</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("fixedpremium")]
        [DefaultValue(0)]
        public decimal FixedPremium { get; set; }

        /// <summary>
        /// Código de la cobertura que contiene la prima de esta cobertura.
        /// </summary>
        /// <remarks>VT.TAB_COVROL.NCOVER_IN</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("coveragecodecontainspremium")]
        [DefaultValue(0)]
        public Int32 CoverageCodeContainsPremium { get; set; }

        /// <summary>
        /// Monto mínimo de prima anual de la cobertura.
        /// </summary>
        /// <remarks>VT.GEN_COVER.NPREMIMIN,VT.TAB_COVROL.NPREMIMIN</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("minimumpremium")]
        [DefaultValue(0)]
        public decimal MinimumPremium { get; set; }

        /// <summary>
        /// Monto máximo de prima anual de la cobertura.
        /// </summary>
        /// <remarks>VT.GEN_COVER.NPREMIMIN,VT.TAB_COVROL.NPREMIMIN</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("maximumpremium")]
        [DefaultValue(0)]
        public decimal MaximumPremium { get; set; }

        /// <summary>
        /// Concepto de facturación.
        /// </summary>
        /// <remarks>VT.GEN_COVER.NBILL_ITEM,VT.LIFE_COVER.NBILL_ITEM</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("billingcode")]
        [DefaultValue(0)]
        public Int32 BillingCode { get; set; }

        /// <summary>
        /// Estado del registro.
        /// </summary>
        /// <remarks>VT.GEN_COVER.SSTATREGT,VT.TAB_COVROL.SSTATREGT</remarks>
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
        /// Constructor por 'default'.
        /// </summary>
        public Coverage()
        {
            Status = 1;
        }

        /// <summary>
        /// Monto máximo de capital asegurado
        /// </summary>
        /// <remarks>VT.TAB_COVROL.NCAPMAXIM</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("maximuminsuredamount")]
        [DefaultValue(0)]
        public decimal MaximumInsuredAmount { get; set; }

        /// <summary>
        /// Edad máxima de contratación.
        /// </summary>
        /// <remarks>VT.TAB_COVROL.NAGEMAXINSF,VT.TAB_COVROL.NAGEMAXINSM</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("maximumage")]
        [DefaultValue(0)]
        public Int32 MaximumAge { get; set; }

        /// <summary>
        /// Edad mínima de contratación.
        /// </summary>
        /// <remarks>VT.TAB_COVROL.NAGEMININSF,VT.TAB_COVROL.NAGEMININSM</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("minimumage")]
        [DefaultValue(0)]
        public Int32 MinimumAge { get; set; }

        /// <summary>
        /// Indica que es cobertura base.
        /// </summary>
        /// <remarks>VT.GEN_COVER.XXX</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("isbase")]
        [DefaultValue(false)]
        public bool IsBase { get; set; }
    }
}
