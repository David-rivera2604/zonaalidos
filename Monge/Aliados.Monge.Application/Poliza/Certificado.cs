using Aliados.Monge.Domain.Poliza.Certificado;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Aliados.Monge.Application.Poliza
{
    public sealed class Certificado
    {

        public static async Task<RespuestaCertificado> Handler(Domain.Poliza.Certificado.Certificado certificado, Architect.API.Core.Contracts.Security.Token tokenInfo)
        {
            RespuestaCertificado result;

            int trackingId = Architect.API.Tron.Business.Traza.TrackRequest.Add(tokenInfo.CompanyId, tokenInfo.UserId,
                             new Architect.API.Tron.Contracts.Traza.TrackRequest()
                             {
                                 DocumentId = certificado.document_id,
                                 RequestType = "Certificado",
                                 RequestBody = Newtonsoft.Json.JsonConvert.SerializeObject(certificado),
                                 RequestTimeStamp = DateTime.Now
                             }).Id;

            try
            {
                Architect.API.Tron.Contracts.Poliza.DatoFijo poliza = Architect.API.Tron.Business.Backoffice.Poliza.Leer(1, certificado.num_poliza, false);



                if (poliza != null)
                {


                    result = new RespuestaCertificado()
                    {
                        message_status = 200,
                        message_text = "Generación exitosa de certificado",
                        message_body = new RespuestaCertificadoDetalle()
                        {
                            certificados = new List<Domain.Poliza.Certificado.Documento>()
                        },
                        message_id = Guid.NewGuid().ToString(),
                        document_id = certificado.document_id
                    };
                   
                    for (int num_riesgo = 1; num_riesgo <= poliza.num_riesgos; num_riesgo++)
                    {
                        byte[] content = Architect.API.Tron.Business.Backoffice.Common.ImprimirPoliza(certificado.num_poliza, num_riesgo);
                        result.message_body.certificados.Add(new Domain.Poliza.Certificado.Documento()
                        {
                            numeroderiesgo = num_riesgo,
                            certificado = Convert.ToBase64String(content)
                        });
                    }
                }
                else
                {
                    result = new RespuestaCertificado()
                    {
                        message_status = 51,
                        message_text = "No existe certificado para el numero de póliza",
                        message_id = Guid.NewGuid().ToString(),
                        document_id = certificado.document_id
                    };
                }
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex);
                result = new Domain.Poliza.Certificado.RespuestaCertificado()
                {
                    message_status = 400,
                    message_text = ex.Message,
                    message_id = Guid.NewGuid().ToString(),
                    document_id = certificado.document_id
                };
            }


            Architect.API.Tron.Business.Traza.TrackRequest.Update(tokenInfo.CompanyId, tokenInfo.UserId, trackingId,
                          new Architect.API.Tron.Contracts.Traza.TrackRequest()
                          {
                              MessageId = result.message_id,
                              ResponseStatus = result.message_status,
                              ResponseText = result.message_text,
                              ResponseBody = Newtonsoft.Json.JsonConvert.SerializeObject(result),
                              ResponseTimeStamp = DateTime.Now
                          });

            return result;
        }

    }

}
