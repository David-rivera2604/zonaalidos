using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;

namespace Architect.API.Tron.Business
{
    internal static class Util
    {

        internal static string Convert_CoverageListToString(List<Contracts.Ramo.G2990026> coverages)
        {
            string result = string.Empty;
            foreach (Contracts.Ramo.G2990026 item in coverages)
            {
                if (result.IsNotEmpty())
                {
                    result += ",";
                }
                result += item.COD_COB;
            }
            return result;
        }

        internal static void ChangeEffectiveDate(Contracts.Presupuesto.DatoFijo quoteTron, Core.Contracts.Security.Token tokenInfo, IDbConnection currentConnection)
        {
            DateTime fecha_efec = quoteTron.fec_efec_poliza;
            DateTime fecha_vec = quoteTron.fec_vcto_poliza;

            if (tokenInfo.Roles.Contain("PolizaGrupo"))
            {
                List<Core.Contracts.General.LookupValues> values = Core.Business.Common.Lkps("MM_POLIZA_GRUPO", $"cod_ramo={quoteTron.cod_ramo}:cod_mon={quoteTron.cod_mon}", tokenInfo);
                Core.Contracts.General.LookupValues contratosMaster = values.Find(x => x.Key == "MM_POLIZA_GRUPO");
                if (contratosMaster != null)
                {
                    Core.Contracts.General.LookupValue contrato = contratosMaster.Lkp.Find(y => y.Code == quoteTron.num_contrato.ToString());
                    if (contrato != null)
                    {
                        string vcto_poliza = (string)contrato["FEC_VCTO_POLIZA"];
                        if (vcto_poliza.IsNotEmpty())
                        {
                            fecha_vec = DateTime.Parse(vcto_poliza, CultureInfo.CreateSpecificCulture("es-CR"));
                        }
                    }
                }
            }

            DataAccess.Batch.P2000030.UpdateEffectiveDate(fecha_efec, fecha_vec, quoteTron.num_poliza, currentConnection);
            DataAccess.Batch.P2000031.UpdateEffectiveDate(fecha_efec, fecha_vec, quoteTron.num_poliza, currentConnection);
        }

        internal static void Ocurrencias(List<Architect.API.Tron.Contracts.Presupuesto.DatoVariable> datosVariables, int num_riesgo, string cod_campo_count, Contracts.Presupuesto.DatoFijo datosFijos, string cod_campo, string val_campo)
        {
            if (val_campo.IsNotEmpty())
            {
                datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, cod_campo_count, val_campo.Split(',').Count().ToString()));
                if (datosFijos.Ocurrencias.IsEmpty())
                {
                    datosFijos.Ocurrencias = new List<Architect.API.Tron.Contracts.Presupuesto.Ocurrencia>();
                }
                int index = 1;
                foreach (string item in val_campo.Split(','))
                {
                    datosFijos.Ocurrencias.Add(Ocurrencia(datosFijos, index, cod_campo, item));
                    index++;
                }
            }
            else
            {
                datosVariables.Add(Util.DatoVariable(datosFijos, num_riesgo, cod_campo_count, "0"));
            }
        }

        internal static Architect.API.Tron.Contracts.Presupuesto.Ocurrencia Ocurrencia(Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos, int num_ocurrencia, string cod_campo, string val_campo)
        {
            Architect.API.Tron.Contracts.Presupuesto.Ocurrencia result = new Architect.API.Tron.Contracts.Presupuesto.Ocurrencia()
            {
                cod_cia = datosFijos.cod_cia,
                num_poliza = datosFijos.num_poliza,
                num_spto = datosFijos.num_spto,
                num_apli = datosFijos.num_apli,
                num_spto_apli = datosFijos.num_spto_apli,
                num_riesgo = 1,
                num_periodo = 1,
                cod_lista = 0,
                num_ocurrencia = num_ocurrencia,
                num_secu = 31,
                cod_campo = cod_campo,
                val_campo = val_campo,
                txt_campo = "",
                mca_baja_riesgo = "N",
                mca_vigente = "S",
                mca_vigente_apli = "S",
                mca_baja_ocurrencia = "N",
                imp_ocurrencia = 0
            };

            switch (cod_campo)
            {
                case "COD_TIP_BR":
                    result.cod_lista = 206;
                    break;
                case "COD_TIP_MED_INC":
                    result.cod_lista = 200;
                    break;
                case "COD_TIP_MED_BR":
                    result.cod_lista = 201;
                    break;
                case "COD_TIP_MED_ROB":
                    result.cod_lista = 202;
                    break;
                case "COD_TIP_MED_RDM":
                    result.cod_lista = 203;
                    break;

            };

            return result;
        }

        internal static Architect.API.Tron.Contracts.Presupuesto.Cobertura Cobertura(Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos, int cod_cob, int num_riesgo = 1)
        {
            return new Architect.API.Tron.Contracts.Presupuesto.Cobertura()
            {
                cod_cia = datosFijos.cod_cia,
                num_poliza = datosFijos.num_poliza,
                num_spto = datosFijos.num_spto,
                num_apli = datosFijos.num_apli,
                num_spto_apli = datosFijos.num_spto_apli,
                num_riesgo = num_riesgo,
                num_periodo = 1,
                cod_cob = cod_cob,
                cod_ramo = datosFijos.cod_ramo,
                num_secu = 1,
                suma_aseg = 0,
                imp_prima = 0
            };
        }


        internal static Architect.API.Tron.Contracts.Presupuesto.DatoVariable DatoVariable(Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos, int num_riesgo, string cod_campo, string val_campo, int tip_nivel = 2, int num_secu = 1, string txt_campo = "")
        {
            string val_cor_campo = val_campo;

            if (val_campo.IsNotEmpty() && val_campo.Length > 10)
            {
                val_cor_campo = val_campo.Substring(0, 10);
            }
            return new Architect.API.Tron.Contracts.Presupuesto.DatoVariable()
            {
                cod_cia = datosFijos.cod_cia,
                num_poliza = datosFijos.num_poliza,
                num_spto = datosFijos.num_spto,
                num_spto_apli = datosFijos.num_spto_apli,
                num_riesgo = num_riesgo,
                num_periodo = 1,
                tip_nivel = tip_nivel,
                cod_campo = cod_campo.ToUpper(),
                val_campo = val_campo,                
                txt_campo = txt_campo,                
                val_cor_campo = val_cor_campo,
                num_secu = num_secu,
                cod_ramo = datosFijos.cod_ramo
            };
        }



        internal static List<Architect.API.Tron.Contracts.Presupuesto.Riesgo> DatosDelRiesgo(Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos, string nom_riesgo, int num_riesgo = 1)
        {
            List<Architect.API.Tron.Contracts.Presupuesto.Riesgo> riesgos = new List<Architect.API.Tron.Contracts.Presupuesto.Riesgo>();

            for (int i = 1; i <= num_riesgo; i++)
            {
                riesgos.Add(new Architect.API.Tron.Contracts.Presupuesto.Riesgo()
                {
                    cod_cia = datosFijos.cod_cia,
                    num_poliza = datosFijos.num_poliza,
                    num_spto = datosFijos.num_spto,
                    num_apli = datosFijos.num_apli,
                    num_spto_apli = datosFijos.num_spto_apli,
                    fec_efec_riesgo = datosFijos.fec_efec_poliza,
                    fec_vcto_riesgo = datosFijos.fec_vcto_poliza,
                    mca_baja_riesgo = "N",
                    mca_vigente = "S",
                    mca_exclusivo = "N",
                    num_riesgo = i,
                    nom_riesgo = nom_riesgo,
                    tip_spto = "XX",
                    cod_modalidad = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_modalidad"])
                });
            }

  
            return riesgos;
        }

        internal static List<Architect.API.Tron.Contracts.Presupuesto.Tercero> Terceros(Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos)
        {

            List<Architect.API.Tron.Contracts.Presupuesto.Tercero> terceros = new List<Architect.API.Tron.Contracts.Presupuesto.Tercero>();
            terceros.Add(Tercero(datosFijos, "CNA", "999999999", 2));


            //    If Session("IsSubAgent") Then
            //    p60s.Add(FillObjectp60(Session("tip_docum_sub_agent"), Session("cod_docum_sub_agent"), Convert.ToInt16(ConfigurationManager.AppSettings("TipBenef_SubAgente")), p30))
            //End If

            return terceros;
        }

        internal static Architect.API.Tron.Contracts.Presupuesto.Tercero Tercero(Architect.API.Tron.Contracts.Presupuesto.DatoFijo datosFijos, string tip_docum, string cod_docum, int tip_benef)
        {
            return new Architect.API.Tron.Contracts.Presupuesto.Tercero()
            {
                cod_cia = datosFijos.cod_cia,
                num_poliza = datosFijos.num_poliza,
                num_spto = datosFijos.num_spto,
                num_apli = datosFijos.num_apli,
                num_spto_apli = datosFijos.num_spto_apli,
                num_riesgo = 1,
                tip_benef = tip_benef.ToString(),
                num_secu = 1,
                tip_docum = tip_docum,
                cod_docum = cod_docum,
                mca_principal = "N",
                mca_calculo = "N",
                mca_baja = "N",
                mca_vigente = "S"
            };
        }

        internal static string IdentificationTypeConvert(int identificationType)
        {
            string type = "";

            switch (identificationType)
            {
                case 1: //Cédula
                    type = "CNA";
                    break;
                case 2: //Residencia
                    type = "CRE";
                    break;
                case 3: //Pasaporte
                    type = "PAS";
                    break;
                case 4: //Cédula jurídica
                    type = "CJU";
                    break;
                    //CIN
                    //EEX
            }

            return type;
        }

        internal static int IdentificationTypeConvert(string identificationType)
        {
            int type = 0;

            switch (identificationType)
            {
                case "CNA": //Cédula
                    type = 1;
                    break;
                case "CRE": //Residencia
                    type = 2;
                    break;
                case "PAS": //Pasaporte
                    type = 3;
                    break;
                case "CJU": //Cédula jurídica
                    type =4;
                    break;
                    //CIN
                    //EEX
            }

            return type;
        }

        internal static string IdentificationFormat(int identificationType, string documentNumber)
        {
            string result = documentNumber.OnlyNumbers();

            switch (identificationType)
            {
                case 1: //Cédula
                    result = result.Substring(1);
                    break;
                case 2: //Residencia
                    result = result.Substring(1);
                    break;
                case 3: //Pasaporte
                    result = result.Substring(1);
                    break;
                case 4: //Cédula jurídica
                    result = result;
                    break;
                    //CIN
                    //EEX
            }

            return result;
        }

    }
}
