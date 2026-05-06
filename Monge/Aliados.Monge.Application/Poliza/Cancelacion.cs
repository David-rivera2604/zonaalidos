using Aliados.Monge.Domain.Poliza.Certificado;
using Aliados.Monge.Domain.Poliza.Documentos;
using Architect.API.Tron.Business.Cotizacion;
using Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Aliados.Monge.Application.Poliza
{
    public sealed class Cancelacion
    {

        public static async Task<Domain.Poliza.Cancelacion.RespuestaCancelacion> Handler(Domain.Poliza.Cancelacion.SolicitudDeCancelacion solicitud, Architect.API.Core.Contracts.Security.Token tokenInfo)
        {
            Domain.Poliza.Cancelacion.RespuestaCancelacion result = new Domain.Poliza.Cancelacion.RespuestaCancelacion();
            int trackingId = global::Architect.API.Core.Business.Traza.TrackRequest.Add(tokenInfo.CompanyId, tokenInfo.UserId,
                             new global::Architect.API.Core.Contracts.Traza.TrackRequest()
                             {
                                 DocumentId = solicitud.document_id,
                                 RequestType = "Cancelacion",
                                 RequestBody = Newtonsoft.Json.JsonConvert.SerializeObject(solicitud),
                                 RequestTimeStamp = DateTime.Now
                             }).Id;

            try
            {
                string tronResult = Architect.API.Tron.Business.Backoffice.Poliza.Cancelacion(1, "Póliza anulada por el servicio viajero regional", solicitud.num_poliza, DateTime.Today, solicitud.descripcion_causa);

                
                if (tronResult.IsEmpty())
                {
                    result = new Domain.Poliza.Cancelacion.RespuestaCancelacion()
                    {
                        message_status = 200,
                        message_text = "Cancelación exitosa de póliza",
                        message_id = Guid.NewGuid().ToString(),
                        document_id = solicitud.document_id,
                        message_body = new Domain.Poliza.Cancelacion.RespuestaCancelacionDetalle()
                        {
                            num_poliza_cancelada = solicitud.num_poliza
                        }
                    };
                }
                else
                {
                    result = new Domain.Poliza.Cancelacion.RespuestaCancelacion()
                    {
                        message_status = 400,
                        message_text = tronResult,
                        message_id = Guid.NewGuid().ToString(),
                        document_id = solicitud.document_id
                    };
                }
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex);

                result = new Domain.Poliza.Cancelacion.RespuestaCancelacion()
                {
                    message_status = 400,
                    message_text = ex.Message,
                    message_id = Guid.NewGuid().ToString(),
                    document_id = solicitud.document_id
                };
            }

            global::Architect.API.Core.Business.Traza.TrackRequest.Update(tokenInfo.CompanyId, tokenInfo.UserId, trackingId,
              new global::Architect.API.Core.Contracts.Traza.TrackRequest()
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
