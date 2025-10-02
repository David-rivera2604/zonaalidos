using Architect.API.Tron.Contracts.Poliza;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Contracts.Variaciones
{
    public class Multirriesgo : Cotizacion.Multirriesgo, IVariacionData, IVariableDataProvider
    {



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
        public List<Ocurrencia> Ocurrencias { get; set; }
        public List<Riesgo> Riesgos { get; set; }

        public Dictionary<string, ValDatoVariable> GetVariableData()
        {
            var variableData = new Dictionary<string, ValDatoVariable>
            {
                ["COD_TIP_RGO_IDN"] = new ValDatoVariable { val_campo= this.cod_tip_rgo_idn.ToString() , tiene_ocurrencia = false},

                //2001 Cobertura de edificio
                ["IMP_EDIFICIO"] = new ValDatoVariable { val_campo= this.IMP_EDIFICIO.ToString() , tiene_ocurrencia = false},

                //2009 Cobertura de contenido
                ["IMP_MOBILIARIO"] = new ValDatoVariable { val_campo= this.IMP_MOBILIARIO.ToString(), tiene_ocurrencia = false },
                ["IMP_MERCADERIA"] = new ValDatoVariable { val_campo= this.IMP_MERCADERIA.ToString(), tiene_ocurrencia = false },
                ["IMP_BIE_TEM_DES"] = new ValDatoVariable { val_campo= this.IMP_BIE_TEM_DES.ToString(), tiene_ocurrencia = false },
                ["IMP_BIE_INT"] = new ValDatoVariable { val_campo= this.IMP_BIE_INT.ToString(), tiene_ocurrencia = false },
                ["IMP_OBJ_ESP_VAL"] = new ValDatoVariable { val_campo= this.IMP_OBJ_ESP_VAL.ToString(), tiene_ocurrencia = false },
                ["IMP_CONTENIDO"] = new ValDatoVariable { val_campo= (this.IMP_MOBILIARIO +
                                     this.IMP_MERCADERIA +
                                     this.IMP_BIE_TEM_DES +
                                     this.IMP_BIE_INT +
                                     this.IMP_OBJ_ESP_VAL).ToString(),tiene_ocurrencia = false },
                ["IMP_MAQUINARIA"] = new ValDatoVariable { val_campo= this.IMP_MAQUINARIA.ToString(), tiene_ocurrencia = false },
                ["IMP_EQUIP_ELEC"] = new ValDatoVariable { val_campo= this.IMP_EQUIP_ELEC.ToString(), tiene_ocurrencia = false },
                ["IMP_EQUIP_ELEC_M"] = new ValDatoVariable { val_campo= this.IMP_EQUIP_ELEC_M.ToString(), tiene_ocurrencia = false },
                ["MCA_EXTIN_INC"] = new ValDatoVariable { val_campo = this.MCA_EXTIN_INC == 1 ? "S" : "N", tiene_ocurrencia = false },
                ["NUM_EXTIN_INC"] = new ValDatoVariable { val_campo = this.NUM_EXTIN_INC.ToString(), tiene_ocurrencia = false },
                ["COD_TIPO_OCUP_POL"] = new ValDatoVariable { val_campo = this.cod_tip_ocup.ToString(), tiene_ocurrencia = false },

                //2007 Cobertura de Rotura domo,crist, marmol y gra
                ["IMP_DOMOS_TOTAL"] = new ValDatoVariable { val_campo= this.IMP_DOMOS_TOTAL.ToString(), tiene_ocurrencia = false },

                //2017 Cobertura de gastos por alquiler
                ["IMP_GAS_ALQ"] = new ValDatoVariable { val_campo= this.IMP_GAS_ALQ.ToString(), tiene_ocurrencia = false },

                //2018 Cobertura de perdida de rentas
                ["COB_PDR_MESES"] = new ValDatoVariable { val_campo= this.COB_PDR_MESES.ToString(), tiene_ocurrencia = false },
                ["IMP_PER_REN"] = new ValDatoVariable { val_campo= this.IMP_PER_REN.ToString(), tiene_ocurrencia = false },

                //2019 Cobertura de bienes refrigerados o congelados
                ["IMP_BIE_REF"] = new ValDatoVariable { val_campo = this.IMP_BIE_REF.ToString(), tiene_ocurrencia = false },

                //2020 Cobertura de Mercancía en tránsito
                ["IMP_MER_TRA"] = new ValDatoVariable { val_campo= this.IMP_MER_TRA.ToString(), tiene_ocurrencia = false },

                //2023 Cobertura de Interrupción de negocios
                ["COB_IDN_MESES"] = new ValDatoVariable { val_campo= this.COB_IDN_MESES.ToString(), tiene_ocurrencia = false },
                ["IMP_INT_NEG"] = new ValDatoVariable { val_campo= this.IMP_INT_NEG.ToString(), tiene_ocurrencia = false },

                };

            //2009 Cobertura de contenido

            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2002 || c.codigo == 2010), "MCA_COB_INCENDIO");

            VariacionBase.EvaluaAgregarOcurrencia(variableData, "NUM_MED_INC", "COD_TIP_MED_INC", this.cod_tip_med_inc);

            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2024 || c.codigo == 2025 || c.codigo == 2026 ||
                                                                c.codigo == 2055 || c.codigo == 2056 || c.codigo == 2057), "MCA_COB_TERR");
            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2024 || c.codigo == 2025 || c.codigo == 2026 ||
                                                                c.codigo == 2055 || c.codigo == 2056 || c.codigo == 2057), "MCA_COB_INUN");
            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2024 || c.codigo == 2025 || c.codigo == 2026 ||
                                                                c.codigo == 2055 || c.codigo == 2056 || c.codigo == 2057), "MCA_COB_DESL");
            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2004 || c.codigo == 2012), "MCA_COB_DPA");

            //2008 Cobertura de robo
            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2008), "MCA_COB_ROB ");

            VariacionBase.EvaluaAgregarOcurrencia(variableData, "NUM_MED_ROB", "COD_TIP_MED_ROB", this.cod_tip_med_rob);

            //2007 Cobertura de Rotura domo,crist, marmol y gra
            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2007), "MCA_COB_DCMG ");

            //2017 Cobertura de gastos por alquiler
            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2017), "MCA_COB_GPA ");

            //2018 Cobertura de perdida de rentas
            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2018), "MCA_COB_PDR ");

            //2019 Cobertura de bienes refrigerados o congelados
            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2019), "MCA_COB_BR ");
            VariacionBase.EvaluaAgregarOcurrencia(variableData, "NUM_TIP_BR", "COD_TIP_BR", string.Empty);
            VariacionBase.EvaluaAgregarOcurrencia(variableData, "NUM_MED_BR", "COD_TIP_MED_BR", this.cod_tip_med_rob);

            //2020 Cobertura de Mercancía en tránsito
            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2020), "MCA_COB_MET ");

            //2021 Cobertura de rotura de maquinaria
            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2021), "MCA_COB_RDM ");
            VariacionBase.EvaluaAgregarOcurrencia(variableData, "NUM_MED_RDM", "COD_TIP_MED_RDM", this.cod_tip_med_rdm);

            //2022 Cobertura de equipos electronicos
            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2022), "MCA_COB_EE ");

            //2023 Cobertura de Interrupción de negocios
            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2023), "MCA_COB_IDN ");

            //2027 Cobertura de asistencia en la empresa
            VariacionBase.EvaluaAgregarItem(variableData, NewCoverages, c => (c.codigo == 2027), "MCA_COB_AE ");


            return variableData;
        }


    }
}
