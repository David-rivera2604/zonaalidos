using Aliados.Monge.Domain.Poliza.Certificado;
using Aliados.Monge.Domain.Poliza.Documentos;
using Architect.API.Tron.Contracts.Especificacion;
using Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Application.Poliza
{
    public sealed class Certificado
    {

        public static async Task<Domain.Poliza.Certificado.RespuestaCertificado> Handler(Domain.Poliza.Certificado.Certificado certificado, Architect.API.Core.Contracts.Security.Token tokenInfo)
        {
            Domain.Poliza.Certificado.RespuestaCertificado result = new Domain.Poliza.Certificado.RespuestaCertificado()
            {
                message_id = Guid.NewGuid().ToString(),
                document_id = certificado.document_id
            };

            int trackingId = Traza.TrackRequest.Add(tokenInfo.CompanyId, tokenInfo.UserId,
                             new Domain.Traza.TrackRequest()
                             {
                                 DocumentId = certificado.document_id,
                                 RequestType = "Certificado",
                                 RequestBody = Newtonsoft.Json.JsonConvert.SerializeObject(certificado),
                                 RequestTimeStamp = DateTime.Now
                             }).Id;


            byte[] content = Architect.API.Tron.Business.Backoffice.Common.ImprimirPoliza(certificado.num_poliza);
            string contentBase64 = Convert.ToBase64String(content);

            if (true)
            {

                result.message_status = 200;
                result.message_text = "Generación exitosa de certificado";
                result.message_body = new Domain.Poliza.Certificado.RespuestaCertificadoDetalle()
                {
                    certificado = contentBase64
                };
            }
            else
            {
                result.message_status = 51;
                result.message_text = "No existe certificado para el numero de póliza";
            }

            Traza.TrackRequest.Update(tokenInfo.CompanyId, tokenInfo.UserId, trackingId,
                          new Domain.Traza.TrackRequest()
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
