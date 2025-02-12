using Aliados.Monge.Domain.Poliza.Certificado;
using Aliados.Monge.Domain.Poliza.Documentos;
using Architect.API.Tron.Contracts.Especificacion;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Aliados.Monge.Application.Poliza
{
    public sealed class Documentos
    {

        public static async Task<Domain.Poliza.Documentos.RespuestaDocumentos> Handler(Domain.Poliza.Documentos.Documentos documentos, Architect.API.Core.Contracts.Security.Token tokenInfo)
        {
            Domain.Poliza.Documentos.RespuestaDocumentos result;

            Architect.API.Core.Contracts.General.Attachments attachment;

            int trackingId = Architect.API.Tron.Business.Traza.TrackRequest.Add(tokenInfo.CompanyId, tokenInfo.UserId,
                                         new Architect.API.Tron.Contracts.Traza.TrackRequest()
                                         {
                                             DocumentId = documentos.document_id,
                                             RequestType = "Documentos",
                                             RequestBody = Newtonsoft.Json.JsonConvert.SerializeObject(documentos),
                                             RequestTimeStamp = DateTime.Now
                                         }).Id;

            try
            {


                foreach (Domain.Poliza.Documentos.Documento documento in documentos.documentos)
                {
                    byte[] bytes = Convert.FromBase64String(documento.documento_base64);
                    string filename = string.Format("{0}{1}", Architect.Utilities.Helpers.Settings.StringValue("Attachments.Path"), documento.nombre_documento);
                    using (var stream = new FileStream(filename, FileMode.Create))
                    {
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Flush();
                    }

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
                        FileContent = filename
                    };
                    Architect.API.Core.Business.General.Attachment.SyncUp(attachment);
                }

                result = new Domain.Poliza.Documentos.RespuestaDocumentos()
                {
                    message_status = 200,
                    message_text = "Envío exitoso de documentos",
                    message_id = Guid.NewGuid().ToString(),
                    document_id = documentos.document_id,
                    message_body = new Domain.Poliza.Documentos.RespuestaDocumentosDetalle()
                    {
                        cantidad_documentos_recibidos = documentos.documentos.Length
                    }
                };

            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex);
                result = new Domain.Poliza.Documentos.RespuestaDocumentos()
                {
                    message_status = 400,
                    message_text = ex.Message,
                    message_id = Guid.NewGuid().ToString(),
                    document_id = documentos.document_id
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
