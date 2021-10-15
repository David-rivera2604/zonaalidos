using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Architect.API.Tron.Business.Emision
{
    public static class Multirriesgo
    {

        public static Architect.API.Tron.Contracts.Emision.Multirriesgo Setup(string presupuesto)
        {
            Architect.API.Tron.Contracts.Emision.Multirriesgo result = null;
            string key = string.Format("multirriesgo.{0}", presupuesto);

            if (Architect.Utilities.Cache.Exist(key))
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Architect.API.Tron.Contracts.Emision.Multirriesgo>(Architect.Utilities.Cache.GetItem(key).ToString());
                result.documentosrequeridos = new List<Contracts.Comun.DocumentoRequerido>
                {
                    new Contracts.Comun.DocumentoRequerido() { documentosrequeridosId=1, tipo = "Copia de la cédula de identidad", DArchivoEsperado="CEDULA.docx", Grupo="F"  },
                    new Contracts.Comun.DocumentoRequerido() { documentosrequeridosId=2, tipo = "Comprobante de entrega de condiciones generales" , DArchivoEsperado="CONDICIONES.pdf", Grupo="F" },
                    new Contracts.Comun.DocumentoRequerido() { documentosrequeridosId=3, tipo = "Consentimiento para uso de datos personales", DArchivoEsperado="CONSENTIMIENTO.pdf" , Grupo="F" },
                    new Contracts.Comun.DocumentoRequerido() { documentosrequeridosId=4, tipo = "Formato de validación de domicilio", DArchivoEsperado="DOMICILIO.pdf" , Grupo="F" },
                    new Contracts.Comun.DocumentoRequerido() { documentosrequeridosId=5, tipo = "Conozca a su cliente (KYC)", DArchivoEsperado="KYC.pdf", Grupo="F"  },
                    new Contracts.Comun.DocumentoRequerido() { documentosrequeridosId=6, tipo = "Solicitud de seguro firmada", DArchivoEsperado="SOLICITUD.pdf", Grupo="F"  },

                    new Contracts.Comun.DocumentoRequerido() { documentosrequeridosId=7, tipo = "Represéntate legal", DArchivoEsperado="REPRESENTANTE LEGAL.docx", Grupo="J" },
                    new Contracts.Comun.DocumentoRequerido() { documentosrequeridosId=8, tipo = "Participación accionaria", DArchivoEsperado="PARTICIPACION ACCIONARIA.docx", Grupo="J" },
                    new Contracts.Comun.DocumentoRequerido() { documentosrequeridosId=9, tipo = "Certificado de participación", DArchivoEsperado="CERTIFICADO PARTICIPACION.docx", Grupo="J" }
                };
            }
            return result;
        }

        public static Contracts.Emision.Multirriesgo Issue(Contracts.Emision.Multirriesgo quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {

            Architect.API.Tron.Contracts.Presupuesto.DatoFijo result = MultirriesgoConvertTo.Tron(quoteInfo);
            
            Architect.API.Tron.Contracts.Poliza.DatoFijo result2 = Backoffice.Emision.Generico.Emitir(result, tokenInfo);

            Contracts.Emision.Multirriesgo resultQuoteInfo = MultirriesgoConvertFrom.Quote(quoteInfo, result2);

            if (resultQuoteInfo.num_poliza.IsNotEmpty())
            {
                Core.Business.General.ChangeSet.Create(3000, Convert.ToInt32(resultQuoteInfo.num_poliza.Substring(4)), tokenInfo.CompanyId, "Emisión Multirriesgo", "Póliza #" + resultQuoteInfo.num_poliza, tokenInfo.UserId, resultQuoteInfo);

                //Se cambian los adjuntos creados al número de presupuesto al número de póliza generado
                Core.Business.General.Attachment.ChangeEntityId(tokenInfo.CompanyId, 3000, Convert.ToInt64(resultQuoteInfo.presupuesto), 3000, Convert.ToInt64(resultQuoteInfo.num_poliza), tokenInfo.UserId);
            }

            return resultQuoteInfo;
        }
    }
}
