using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Architect.API.Core.Business.General;
using Architect.API.Insurance.Contracts.Bayer;
using Architect.API.Tron.DataAccess.Pagos;
using Architect.DocuSign.Integrations.Providers.Evicertia.Contracts;
using Architect.Payment.Integrations.Contracts.v2;
using Architect.Utilities.Extensions;
using Microsoft.Win32;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities.Net;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// 
    /// </summary>
    public class AltasBajasPoliza
    {

        /// <summary>
        /// Permite la creación de un sesión para realizar un pago.
        /// </summary>
        public async static Task<Contracts.AltasBajas.Response.Poliza> AltasBajas(Contracts.AltasBajas.Request.Poliza poliza, bool alta)
        {

            Contracts.AltasBajas.Request.SPCall sp = new Contracts.AltasBajas.Request.SPCall()
            {
                NUM_POLIZA_GRUPO = poliza.NUM_POLIZA_GRUPO,
                NUM_CONTRATO = poliza.NUM_CONTRATO,
                RAMO = poliza.RAMO,
                TIP_DOCUM_ASEG = poliza.COD_DOCUM_ASEGType.IdentificationType(),
                COD_DOCUM_ASEG = poliza.COD_DOCUM_ASEG.DocumentNumber(poliza.COD_DOCUM_ASEGType),
                NOM_TERCERO_ASEG = poliza.NOM_TERCERO_ASEG,
                APE_TERCERO_ASEG = poliza.APE_TERCERO_ASEG,
                MCA_SEXO_ASEG = poliza.MCA_SEXO_ASEG == "1" ? "M" : "F",
                NACIONALIDAD_ASEG = poliza.NACIONALIDAD_ASEG,
                COD_ESTADO = poliza.COD_ESTADO,
                COD_PROVINCIA = poliza.COD_PROVINCIA,
                COD_LOCALIDAD = poliza.COD_LOCALIDAD,
                DOMICILIO = poliza.DOMICILIO,
                NUM_PRESTAMO = poliza.NUM_PRESTAMO,
                IMP_SUMA_ASEG = poliza.IMP_SUMA_ASEG,
                IMP_SUM_ASEG_VC = poliza.IMP_SUM_ASEG_VC,
                IMP_PRIMA_FACT = poliza.IMP_PRIMA_FACT == 0 ? null : poliza.IMP_PRIMA_FACT,
                IMP_PRIMA_INFORMADA = poliza.IMP_PRIMA_INFORMADA,
                ID_CRED_ESTUDIANTE = poliza.ID_CRED_ESTUDIANTE,
                MCA_ASISTENCIA = poliza.MCA_ASISTENCIA,
                IMP_SUMA_MUERTE = poliza.IMP_SUMA_MUERTE,
                FEC_EFEC_SPTO = poliza.EFEC_SPTO.ToString("dd/MM/yyyy"),
                FEC_VCTO_SPTO = poliza.VCTO_SPTO.ToString("dd/MM/yyyy"),
                FEC_NAC_ASEG = poliza.NAC_ASEG.ToString("dd/MM/yyyy"),
                FEC_INI_PRESTAMO = poliza.INI_PRESTAMO.ToString("dd/MM/yyyy"),
                FEC_VCTO_PRESTAMO = poliza.VCTO_PRESTAMO.ToString("dd/MM/yyyy"),
                COD_PLAN_AP = poliza.COD_PLAN_AP,
                TIP_DE_PROCESO = alta ? "N" : "A",
                OCUPACION_ASEG = poliza.OCUPACION_ASEG,
                TLF_NUMERO_ASEG = poliza.TLF_NUMERO_ASEG,
                EMAIL_ASEG = poliza.EMAIL_ASEG,
                BENEFICIARIOS = poliza.Beneficiarios?.Select(b => new Contracts.AltasBajas.Request.SPCallBeneficiario
                {
                    TIP_DOCUM_BENEF = b.COD_DOCUM_BENEFType.IdentificationType(),
                    COD_DOCUM_BENEF = b.COD_DOCUM_BENEF.DocumentNumber(b.COD_DOCUM_BENEFType),
                    NOM_TERCERO_BENEF = b.NOM_TERCERO_BENEF,
                    NOM2_TERCERO_BENEF = b.NOM2_TERCERO_BENEF,
                    APE1_TERCERO_BENEF = b.APE1_TERCERO_BENEF,
                    APE2_TERCERO_BENEF = b.APE2_TERCERO_BENEF,
                    TIP_BENEF = 15,
                    PCT_PARTICIPACION = b.PCT_PARTICIPACION,
                    TIP_RELAC = b.TIP_RELAC,
                    MCA_SEXO_BENEF = b.MCA_SEXO_BENEF,
                    PROVINCIA_BENEF = b.PROVINCIA_BENEF,
                    LOCALIDAD_BENEF = b.LOCALIDAD_BENEF,
                    TLF_NUMERO_BENEF = b.TLF_NUMERO_BENEF,
                    EMAIL_BENEF = b.EMAIL_BENEF,
                    FEC_NAC_BENEF = b.FEC_NAC_BENEF.ToString("ddMMyyyy")
                }).ToList()
            };


            string json = JsonConvert.SerializeObject(sp);
            string resultjson = DataAccess.PorRamo.EM_K_ALTA_BAJA_POLIZA_WEB_MCR(json);

            Contracts.AltasBajas.Response.Poliza result = JsonConvert.DeserializeObject<Contracts.AltasBajas.Response.Poliza>(resultjson);

            return result;
        }

    }
}
