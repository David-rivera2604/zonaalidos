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
                TIP_DE_PROCESO = alta ? "N" : "A"
            };

            string json = JsonConvert.SerializeObject(sp);
            string resultjson = DataAccess.PorRamo.EM_K_ALTA_BAJA_POLIZA_WEB_MCR(json);

            Contracts.AltasBajas.Response.Poliza result = JsonConvert.DeserializeObject<Contracts.AltasBajas.Response.Poliza>(resultjson);

            return result;
        }

    }
}
