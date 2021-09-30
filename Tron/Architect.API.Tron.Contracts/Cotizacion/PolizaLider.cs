using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Cotizacion
{
    public class PolizaLider : Quote
    {

        /// <summary>
        /// Moneda.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_mon { get; set; }
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
        [DataMember(), JsonProperty()] public int COD_PLAN_AUTO { get; set; }
        /// <summary>
        /// Marca.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_MARCA { get; set; }
        /// <summary>
        /// Modelo.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_MODELO { get; set; }
        /// <summary>
        /// % de descuento familiar.
        /// </summary>
        [DataMember(), JsonProperty()] public int PCT_DCTO_AUTO_PAR { get; set; }
        /// <summary>
        /// Clase del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_TIP_VEHI { get; set; }
        /// <summary>
        /// Uso del vehículo.
        /// </summary>
        [DataMember(), JsonProperty()] public int COD_USO_VEHI { get; set; }
        /// <summary>
        /// Año de fabricación.
        /// </summary>
        [DataMember(), JsonProperty()] public int ANIO_SUB_MODELO { get; set; }
        /// <summary>
        /// Tipo de valoración.
        /// </summary>
        [DataMember(), JsonProperty()] public string MCA_VR { get; set; }
        /// <summary>
        /// ¿Es cliente nuevo?.
        /// </summary>
        [DataMember(), JsonProperty()] public int MCA_DESC_CLIENTE_NUEVO { get; set; }
        /// <summary>
        /// ¿Es cero km?.
        /// </summary>
        [DataMember(), JsonProperty()] public int MCA_CERO_KM { get; set; }
        /// <summary>
        /// ¿Tiene GPS?.
        /// </summary>
        [DataMember(), JsonProperty()] public int MCA_AUTO_GPS { get; set; }
        /// <summary>
        /// ¿Tiene póliza "Hogar Total"?.
        /// </summary>
        [DataMember(), JsonProperty()] public int mca_HogarTotal { get; set; }
        /// <summary>
        /// ¿Tiene GPS con convenio?.
        /// </summary>
        [DataMember(), JsonProperty()] public int MCA_AUTO_GPS_CMS { get; set; }
        /// <summary>
        /// Responsabilidad civil.
        /// </summary>
        [DataMember(), JsonProperty()] public int Resp_civilSA { get; set; }
        /// <summary>
        /// Gastos médicos de ocupantes.
        /// </summary>
        [DataMember(), JsonProperty()] public int Gast_medicSA { get; set; }
        /// <summary>
        /// Accidentes al conductor.
        /// </summary>
        [DataMember(), JsonProperty()] public int Acc_ConducSA { get; set; }
        /// <summary>
        /// Valor del vehículo asegurado.
        /// </summary>
        [DataMember(), JsonProperty()] public int Valor_VehiSA { get; set; }
        /// <summary>
        /// Equipo especial.
        /// </summary>
        [DataMember(), JsonProperty()] public int Equi_EspeSA { get; set; }
        /// <summary>
        /// Rotura de Cristales.
        /// </summary>
        [DataMember(), JsonProperty()] public int IMP_AUTO_CRI { get; set; }
        /// <summary>
        /// @Control.Caption@.
        /// </summary>
        [DataMember(), JsonProperty()] public List<PolizaLiderCoberturas> coberturas { get; set; }
        /// <summary>
        /// @Control.Caption@.
        /// </summary>
        [DataMember(), JsonProperty()] public List<PolizaLiderPlandepago> plandepago { get; set; }


    }
    public class PolizaLiderCoberturas
    {

        /// <summary>
        /// Seleccionada.
        /// </summary>
        [DataMember(), JsonProperty()] public bool seleccionado { get; set; }

        /// <summary>
        /// Requerida.
        /// </summary>
        [DataMember(), JsonProperty()] public bool requerida { get; set; }

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
        [DataMember(), JsonProperty()] public string decucible { get; set; }
        /// <summary>
        /// Error.
        /// </summary>
        [DataMember(), JsonProperty()] public string error { get; set; }


    }
    public class PolizaLiderPlandepago
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
        /// Recardo por fraccionamiento.
        /// </summary>
        [DataMember(), JsonProperty()] public double recardoporfraccionamiento { get; set; }
        /// <summary>
        /// Importe total.
        /// </summary>
        [DataMember(), JsonProperty()] public double importetotal { get; set; }


    }

}
