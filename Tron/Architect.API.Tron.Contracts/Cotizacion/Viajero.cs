using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Cotizacion
{
    public class Viajero : Quote
    {

        /// <summary>
        /// Moneda.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_mon { get; set; }
        [DataMember(), JsonProperty()] public string cod_mon_desc { get; set; }
        /// <summary>
        /// Fraccionamiento de pago.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_fracc_pago { get; set; }
        /// <summary>
        /// Inicio de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime fec_efec_poliza { get; set; }
        /// <summary>
        /// Fin de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime fec_vcto_poliza { get; set; }
        /// <summary>
        /// Plan.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_PLAN { get; set; }
        [DataMember(), JsonProperty()] public string TIP_PLAN_DESC { get; set; }
        /// <summary>
        /// Tipo de viaje.
        /// </summary>
        [DataMember(), JsonProperty()] public string TIP_VIAJE { get; set; }
        [DataMember(), JsonProperty()] public string TIP_VIAJE_DESC { get; set; }
        /// <summary>
        /// Fecha de inicio del viaje.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_VIAJE { get; set; }
        /// <summary>
        /// Lugar de destino.
        /// </summary>
        [DataMember(), JsonProperty()] public string DES_DESTINO { get; set; }
        /// <summary>
        /// Fecha de nacimiento.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime FEC_NACIMIENTO { get; set; }
        /// <summary>
        /// Modalidad.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_MODALIDAD { get; set; }
        [DataMember(), JsonProperty()] public string COD_MODALIDAD_DES { get; set; }
        /// <summary>
        /// @Control.Caption@.
        /// </summary>
        [DataMember(), JsonProperty()] public List<Viajerocoberturas> coberturas { get; set; }
        /// <summary>
        /// @Control.Caption@.
        /// </summary>
        [DataMember(), JsonProperty()] public List<Viajeroplandepago> plandepago { get; set; }


    }
    public class Viajerocoberturas
    {

        /// <summary>
        /// Selecionada.
        /// </summary>
        [DataMember(), JsonProperty()] public bool seleccionado { get; set; }
        /// <summary>
        /// Código.
        /// </summary>
        [DataMember(), JsonProperty()] public int codigo { get; set; }
        /// <summary>
        /// Nombre.
        /// </summary>
        [DataMember(), JsonProperty()] public string nombre { get; set; }
        /// <summary>
        /// Capital.
        /// </summary>
        [DataMember(), JsonProperty()] public double capital { get; set; }
        /// <summary>
        /// Prima total.
        /// </summary>
        [DataMember(), JsonProperty()] public double primatotal { get; set; }
        /// <summary>
        /// Deducible.
        /// </summary>
        [DataMember(), JsonProperty()] public string deducible { get; set; }
        /// <summary>
        /// Error.
        /// </summary>
        [DataMember(), JsonProperty()] public string error { get; set; }

    }
    public class Viajeroplandepago
    {

        /// <summary>
        /// Cuota.
        /// </summary>
        [DataMember(), JsonProperty()] public int cuota { get; set; }
        /// <summary>
        /// Fecha desde.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime fechadesde { get; set; }
        /// <summary>
        /// Fecha hasta.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime fechahasta { get; set; }
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


    }

}
