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
    public sealed class Cancelacion
    {

        public static async Task<Domain.Poliza.Cancelacion.RespuestaCancelacion> Handler(Domain.Poliza.Cancelacion.SolicitudDeCancelacion solicitud, Architect.API.Core.Contracts.Security.Token tokenInfo)
        {
            Domain.Poliza.Cancelacion.RespuestaCancelacion result;
            if (solicitud.document_id == "GMG-CR-12345")
            {
                result = new Domain.Poliza.Cancelacion.RespuestaCancelacion()
                {
                    message_status = 200,
                    message_text = "Cancelacion Exitosa de Poliza",
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
                    message_status = 71,
                    message_text = "No existe número de póliza en sistema",
                    message_id = Guid.NewGuid().ToString(),
                    document_id = solicitud.document_id
                };
            }

            return result;
        }

    }

}
