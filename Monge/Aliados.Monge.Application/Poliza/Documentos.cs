using Aliados.Monge.Domain.Poliza.Certificado;
using Aliados.Monge.Domain.Poliza.Documentos;
using System;
using System.Threading.Tasks;

namespace Aliados.Monge.Application.Poliza
{
    public sealed class Documentos
    {

        public static async Task<Domain.Poliza.Documentos.RespuestaDocumentos> Handler(Domain.Poliza.Documentos.Documentos documentos, Architect.API.Core.Contracts.Security.Token tokenInfo)
        {
            Domain.Poliza.Documentos.RespuestaDocumentos result = new Domain.Poliza.Documentos.RespuestaDocumentos()
            {
                message_id = Guid.NewGuid().ToString(),
                document_id = documentos.document_id
            };

            Architect.API.Core.Contracts.General.Attachments attachment;

            int trackingId = Traza.TrackRequest.Add(tokenInfo.CompanyId, tokenInfo.UserId,
                                         new Domain.Traza.TrackRequest()
                                         {
                                             DocumentId = documentos.document_id,
                                             RequestType = "Documentos",
                                             RequestBody = Newtonsoft.Json.JsonConvert.SerializeObject(documentos),
                                             RequestTimeStamp = DateTime.Now
                                         }).Id;

            try
            {
                foreach (Documento documento in documentos.documentos)
                {
                    attachment = new Architect.API.Core.Contracts.General.Attachments()
                    {
                        EntityType = 3000,
                        EntityId = Int64.Parse(documentos.num_poliza),
                        EntitySubType = 0,
                        CompanyId = tokenInfo.CompanyId,
                        UpdateUserCode = tokenInfo.UserId,
                        DocumentType = documento.codigo_documento,
                        Description = "General",
                        FileName = documento.nombre_documento,
                        FileSize = Int32.Parse(documento.peso_documento),
                        FileContent = documento.documento_base64
                    };
                }

                result.message_status = 200;
                result.message_text = "Envío exitoso de documentos";
                result.message_body = new Domain.Poliza.Documentos.RespuestaDocumentosDetalle()
                {
                    cantidad_documentos_recibidos = documentos.documentos.Length
                };

            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex);
                result.message_status = 400;
                result.message_text = "Envío exitoso de documentos";

                result = new Domain.Poliza.Documentos.RespuestaDocumentos()
                {
                    message_status = 31,
                    message_text = ex.Message,
                };
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
