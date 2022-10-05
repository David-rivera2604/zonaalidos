using Aliados.Monge.Domain.Poliza.Certificado;
using Aliados.Monge.Domain.Poliza.Documentos;
using Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia;
using Architect.Utilities.Extensions;
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

            string tronResult = Architect.API.Tron.Business.Backoffice.Poliza.Cancelacion(1, "Póliza anulada por el servicio viajero regional", solicitud.num_poliza, DateTime.Today, solicitud.descripcion_causa);

            Domain.Poliza.Cancelacion.RespuestaCancelacion result;
            if (tronResult.IsEmpty())
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
                    message_status = 400,
                    message_text = tronResult,
                    message_id = Guid.NewGuid().ToString(),
                    document_id = solicitud.document_id
                };
            }

            return result;
        }

    }

}
