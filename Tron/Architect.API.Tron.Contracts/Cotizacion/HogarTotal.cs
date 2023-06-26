using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Architect.API.Tron.Contracts.Cotizacion
{
    public class HogarTotal : Quote
    {
        /// <summary>
        /// Moneda.
        /// </summary>
        [DataMember(), JsonProperty()] public int moneda { get; set; }
        [DataMember(), JsonProperty()] public string monedaDesc { get; set; }
        /// <summary>
        /// Fraccionamiento de pago.
        /// </summary>
        [DataMember(), JsonProperty()] public int fraccionamientodepago { get; set; }
        /// <summary>
        /// Inicio de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime iniciodevigencia { get; set; }
        /// <summary>
        /// Fin de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime findevigencia { get; set; }
        /// <summary>
        /// País.
        /// </summary>
        [DataMember(), JsonProperty()] public string pais { get; set; }
        [DataMember(), JsonProperty()] public string paisDesc { get; set; }
        /// <summary>
        /// Provincia.
        /// </summary>
        [DataMember(), JsonProperty()] public int provincia { get; set; }
        [DataMember(), JsonProperty()] public string provinciaDesc { get; set; }
        /// <summary>
        /// Cantón.
        /// </summary>
        [DataMember(), JsonProperty()] public int canton { get; set; }
        [DataMember(), JsonProperty()] public string cantonDesc { get; set; }
        /// <summary>
        /// Distrito.
        /// </summary>
        [DataMember(), JsonProperty()] public int distrito { get; set; }
        [DataMember(), JsonProperty()] public string distritoDesc { get; set; }
        /// <summary>
        /// Ocupación del riesgo.
        /// </summary>
        [DataMember(), JsonProperty()] public int ocupaciondelriesgo { get; set; }
        [DataMember(), JsonProperty()] public string ocupaciondelriesgoDesc { get; set; }
        /// <summary>
        /// Tipo de suscripción.
        /// </summary>
        [DataMember(), JsonProperty()] public int tipodesuscripcion { get; set; }
        [DataMember(), JsonProperty()] public string tipodesuscripcionDesc { get; set; }
        /// <summary>
        /// Número de pisos edificación.
        /// </summary>
        [DataMember(), JsonProperty()] public int numerodepisosedificacion { get; set; }
        [DataMember(), JsonProperty()] public string numerodepisosedificacionDesc { get; set; }
        /// <summary>
        /// Tipo de estruc. de la edificación.
        /// </summary>
        [DataMember(), JsonProperty()] public int tipodeestrucdelaedificacion { get; set; }
        [DataMember(), JsonProperty()] public string tipodeestrucdelaedificacionDesc { get; set; }
        /// <summary>
        /// Meses a amparar por perd. rentas.
        /// </summary>
        [DataMember(), JsonProperty()] public int mesesaampararporperdrentas { get; set; }
        /// <summary>
        /// Medidas de seguridad.
        /// </summary>
        [DataMember(), JsonProperty()] public string medidasdeseguridad { get; set; }
        [DataMember(), JsonProperty()] public string medidasdeseguridadDesc { get; set; }
        /// <summary>
        /// Descuento.
        /// </summary>
        [DataMember(), JsonProperty()] public int descuento { get; set; }
        [DataMember(), JsonProperty()] public string descuentoDesc { get; set; }
        /// <summary>
        /// S.A. Edificio.
        /// </summary>
        [DataMember(), JsonProperty()] public int sAEdificio { get; set; }
        /// <summary>
        /// S.A. Objetos valiosos.
        /// </summary>
        [DataMember(), JsonProperty()] public int sAObjetosvaliosos { get; set; }
        /// <summary>
        /// S.A. Domo, cristal, mármol, granito.
        /// </summary>
        [DataMember(), JsonProperty()] public int sADomocristalmarmolgranito { get; set; }
        /// <summary>
        /// S.A. Gastos alquiler.
        /// </summary>
        [DataMember(), JsonProperty()] public int sAGastosalquiler { get; set; }
        /// <summary>
        /// S.A. Pérdida de rentas.
        /// </summary>
        [DataMember(), JsonProperty()] public int sAPerdidaderentas { get; set; }
        /// <summary>
        /// S.A. Responsabilidad civil
        /// </summary>
        [DataMember(), JsonProperty()] public int sARespcivil { get; set; }
        /// <summary>
        /// S.A. Mobiliario.
        /// </summary>
        [DataMember(), JsonProperty()] public int sAMobiliario { get; set; }
        /// <summary>
        /// Coberturas
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.Cobertura> coberturas { get; set; }
        /// <summary>
        /// Plan de pago
        /// </summary>
        [DataMember(), JsonProperty()] public List<Comun.PlanDePago> plandepago { get; set; }

        [DataMember(), JsonProperty()] public int contrato { get; set; }
        [DataMember(), JsonProperty()] public int subcontrato { get; set; }
        [DataMember(), JsonProperty()] public string polizagrupo { get; set; }
        [DataMember(), JsonProperty()] public int cod_fracc_pago { get; set; }

    }

}
