using Aliados.Monge.Domain.Poliza.Certificado;
using Aliados.Monge.Domain.Poliza.Documentos;
using Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Application.Poliza
{
    public sealed class Consulta
    {
        public static async Task<Domain.Poliza.Consulta.RespuestaConsulta> Handler(Domain.Poliza.Consulta.Solicitud solicitud, Architect.API.Core.Contracts.Security.Token tokenInfo)
        {
            Domain.Poliza.Consulta.RespuestaConsulta result;
            try
            {

                Domain.Traza.TrackRequest item = Infrastructure.Data.Traza.TrackRequest.Retrieve(solicitud.document_id, tokenInfo.CompanyId);

                if (item != null)
                {
                    result = new Domain.Poliza.Consulta.RespuestaConsulta()
                    {
                        message_status = 200,
                        message_text = "Consulta exitosa",
                        message_id = Guid.NewGuid().ToString(),
                        document_id = solicitud.document_id
                    };
                    switch (item.RequestType)
                    {
                        case "Emision":
                            result.message_body = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.Poliza.Emision.Respuesta>(item.ResponseBody).message_body;
                            break;
                        case "Documentos":
                            result.message_body = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.Poliza.Documentos.RespuestaDocumentos>(item.ResponseBody).message_body;
                            break;
                        case "Certificado":
                            result.message_body = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.Poliza.Certificado.RespuestaCertificado>(item.ResponseBody).message_body;
                            break;
                    }
                }
                else
                {
                    result = new Domain.Poliza.Consulta.RespuestaConsulta()
                    {
                        message_status = 91,
                        message_text = "El document_id no se pudo encontrar",
                        message_id = Guid.NewGuid().ToString(),
                        document_id = solicitud.document_id
                    };
                }
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog(ex);
                result = new Domain.Poliza.Consulta.RespuestaConsulta()
                {
                    message_status = 400,
                    message_text = ex.Message,
                    message_id = Guid.NewGuid().ToString(),
                    document_id = solicitud.document_id
                };
            }

            return result;
        }

    }
}
