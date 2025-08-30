using Architect.API.Tron.Contracts.Cotizacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Variaciones
{
    public class HogarTotal : Quote, IVariacionData, IVariableDataProvider
    {
        /// <summary>
        /// Moneda.
        /// </summary>
        [DataMember(), JsonProperty()] public int cod_mon { get; set; }
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
        /// <summary>
        /// Inicio de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime fec_efec_poliza { get; set; }
        /// <summary>
        /// Fin de vigencia.
        /// </summary>
        [DataMember(), JsonProperty()] public DateTime fec_vcto_poliza { get; set; }

        public int cod_cia { get; set; }
        public string num_poliza { get; set; }
        public int num_spto { get; set; }
        public string MCA_FEC_EFEC_SYS { get; set; }
        public List<Receipt> Recibos { get; set; }
        public string Mca_Autoriza_CT { get; set; }
        public List<CoberturaVariacion> AvailableCoverages { get; set; }
        public List<CoberturaVariacion> NewCoverages { get; set; } = new List<CoberturaVariacion>();
        public List<g1010031> SumAseguradaRamo { get; set; }
        public List<Receipt> plandepagoresumen { get; set; }
        public List<Comun.tercero> terceros { get; set; }
        public DateTime fec_efec_cancel { get; set; }
        public string txt_motivo { get; set; }
        public DateTime? fec_efec { get; set; }

        public Dictionary<string, string> GetVariableData()
        {
            var variableData = new Dictionary<string, string>
            {
                ["IMP_EDIFICIO"] = this.sAEdificio.ToString(),
                ["IMP_MOBILIARIO"] = this.sAMobiliario.ToString(),
                ["IMP_OBJ_VALIOSO"] = this.sAObjetosvaliosos.ToString(),
                ["IMP_DOMOS_TOTAL"] = this.sADomocristalmarmolgranito.ToString(),
                ["IMP_GAS_ALQ"] = this.sAGastosalquiler.ToString(),
                ["IMP_PER_REN"] = this.sAPerdidaderentas.ToString(),
                ["IMP_SA_RC"] = this.sARespcivil.ToString()
            };

            EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2002 || c.codigo == 2010), "MCA_COB_INCENDIO");
            EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2024 || c.codigo == 2025 || c.codigo == 2026 || c.codigo == 2055 || c.codigo == 2056 || c.codigo == 2057), "MCA_COB_NC");
            EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2004 || c.codigo == 2012), "MCA_COB_DPA");
            EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2007), "MCA_COB_DCMG");
            EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2014), "MCA_COB_ROB");
            EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2017), "MCA_COB_GPA");
            EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2018), "MCA_COB_PDR");
            EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2034), "MCA_RESP_CIVIL");

            return variableData;
        }

        private void EvaluaAgregarItem<T>(
            Dictionary<string, string> diccionario,
            IEnumerable<T> lista,            
            Func<T, bool> condicion,
            string nuevaClave)
            where T: class
        {
            var filtrados = lista.Where(condicion).ToList();

            if (filtrados.Any())
            {
                var prop = typeof(T).GetProperty("mcaSeleccion");
                if(prop != null)
                {
                    var valores = filtrados.Select(x => prop.GetValue(x)?.ToString()).ToList();

                    string nuevoValor = string.Empty;

                    if (valores.Any(v => v == "*"))
                        nuevoValor = "S";
                    else if (valores.All(v => v == "X"))
                        nuevoValor = "N";
                    else
                        return;

                    if (!diccionario.ContainsKey(nuevaClave))
                    {
                        diccionario.Add(nuevaClave, nuevoValor);
                    }
                }
            }
        }
    }
}
