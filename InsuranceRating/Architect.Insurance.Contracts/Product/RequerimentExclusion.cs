using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Architect.Insurance.Contracts.Product
{
    ///Note:Quizas se bueno disponibilizar las descripcion de TypeCondition(TABLE73), SourceType y TargetType (TABLE72)



    /// <summary>
    /// Requisitos y exclusiones.
    /// </summary>
    /// <remarks>VT.TAB_REQEXC</remarks>
    public class RequerimentExclusion
    {
        /// <summary>
        /// Tipo de relación de requisito/exclusión.
        /// </summary>
        /// <remarks>VT.TAB_REQEXC.NRELREQEXC</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("typecondition")]
        [DefaultValue(0)]
        public Int16 TypeCondition { get; set; }

        /// <summary>
        /// Código del tipo de componente. 
        /// </summary>
        /// <remarks>VT.TAB_REQEXC.NREQEXC1</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("sourcetype")]
        [DefaultValue(0)]
        public Int16 SourceType { get; set; }

        /// <summary>
        /// Rol del cliente asociado a la cobertura a relacionar. 
        /// </summary>
        /// <remarks>VT.TAB_REQEXC.NROLE1</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("sourceroleofthecoverage")]
        [DefaultValue(0)]
        public Int32 SourceRoleOfTheCoverage { get; set; }

        /// <summary>
        /// Código del primer elemento en la relación de requisito o exclusión. 
        /// </summary>
        /// <remarks>VT.TAB_REQEXC.NCODE1</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("sourcecode")]
        [DefaultValue(0)]
        public Int32 SourceCode { get; set; }

        /// <summary>
        /// Código del tipo de componente.
        /// </summary>
        /// <remarks>VT.TAB_REQEXC.NREQEXC2</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("targettype")]
        [DefaultValue(0)]
        public Int16 TargetType { get; set; }

        /// <summary>
        /// Rol del cliente asociado a la cobertura a relacionar.
        /// </summary>
        /// <remarks>VT.TAB_REQEXC.NROLE2</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("targetroleofthecoverage")]
        [DefaultValue(0)]
        public Int32 TargetRoleOfTheCoverage { get; set; }

        /// <summary>
        /// Código del segundo elemento en la relación de requisito o exclusión. 
        /// </summary>
        /// <remarks>VT.TAB_REQEXC.NCODE2</remarks>
        [DataMember(EmitDefaultValue = false)]
        [XmlAttribute("targetcode")]
        [DefaultValue(0)]
        public Int32 TargetCode { get; set; }

    }
}
