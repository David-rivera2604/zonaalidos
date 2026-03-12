using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Cotizacion
{
    /// <summary>
    /// Datos de cotización del producto autoexpedible funerario.
    /// </summary>
    public class Funerario : GenericQuote
    {
        /// <summary>
        /// No. de póliza.
        /// </summary>
        [DataMember(), JsonProperty()] public string num_poliza { get; set; }

        /// <summary>
        /// Terceros
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.tercero> terceros { get; set; }

        /// <summary>
        /// Código del plan. Dato variable.
        /// </summary>
        public string COD_PLAN_AP { get; set; }
        /// <summary>
        /// Nombre del plan. Dato variable.
        /// </summary>
        public string NOM_PLAN_AP { get; set; }
        

        /// <summary>
        /// Indica si es colectivo. Dato variable.
        /// </summary>
        public string MCA_COLECTIVO { get; set; }

        /// <summary>
        /// Fecha de nacimiento. Dato variable.
        /// </summary>
        public DateTime FEC_NACIMIENTO { get; set; }

        ///// <summary>
        ///// Edad actuarial. Dato variable.
        ///// </summary>
        //public int VAL_EDAD_ACTUARIAL { get; set; }

        /// <summary>
        /// Sexo. Dato variable.
        /// </summary>
        public string MCA_SEXO { get; set; }

        /// <summary>
        /// Modalidad. Dato variable.
        /// </summary>
        public int COD_MODALIDAD { get; set; }

        /// <summary>
        /// Terceros
        /// </summary>
        [DataMember(), JsonProperty()] public List<presupuesto> presupuestos { get; set; }

        /// <summary>
        /// Cantidad de dependientes.
        /// </summary>
        public int num_dependientes { get; set; }

    }

    public class presupuesto
    {

        /// <summary>
        /// Clave de acceso
        /// </summary>
        [DataMember(), JsonProperty()] public string Key { get; set; }

        /// <summary>
        /// No. de presupuesto.
        /// </summary>
        [DataMember(), JsonProperty()] public string ID { get; set; }

        /// <summary>
        /// Prima neta.
        /// </summary>
        [DataMember(), JsonProperty()] public double primaneta { get; set; }
        /// <summary>
        /// IVA.
        /// </summary>
        [DataMember(), JsonProperty()] public double iVA { get; set; }
        /// <summary>
        /// Recargo por fraccionamiento.
        /// </summary>
        [DataMember(), JsonProperty()] public double recargoporfraccionamiento { get; set; }
        /// <summary>
        /// Importe total.
        /// </summary>
        [DataMember(), JsonProperty()] public double importetotal { get; set; }
        /// <summary>
        /// Cuota.
        /// </summary>
        [DataMember(), JsonProperty()] public int cuotas { get; set; }

        /// <summary>
        /// Coberturas
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.Cobertura> coberturas { get; set; }

        /// <summary>
        /// Plan de pago
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.PlanDePago> plandepago { get; set; }

    }

}
