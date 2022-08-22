using Aliados.Monge.Domain.Poliza.Certificado;
using Aliados.Monge.Domain.Poliza.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Application.Poliza
{
    public sealed class PolizaHandler
    {
        public static async Task<Domain.Poliza.Emision.Respuesta> Emision(Domain.Poliza.Emision.Poliza risk)
        {
            Domain.Poliza.Emision.Respuesta result = new Domain.Poliza.Emision.Respuesta()
            {
                message_status = 200,
                message_text = "Emision Exitosa",
                message_id = "5847845734-3738473432-4784723",
                document_id = risk.Document_id,
                message_body = new Domain.Poliza.Emision.RespuestaDetalle()
                {
                    num_poliza = "4412210103630",
                    num_certificado_phx = "",
                    resumen = new Domain.Poliza.Emision.Resumen()
                    {
                        primaneta = 81.01F,
                        iVA = 1.62F,
                        recargoporfraccionamiento = 0.0F,
                        importetotal = 82.63F,
                        cuotas = 1
                    },
                    plandepago = new List<Domain.Poliza.Emision.Plandepago>()
                    {
                        new Domain.Poliza.Emision.Plandepago()
                        {
                            cuota= 0,
                            fechadesde = new DateTime(2022, 07, 11),
                            fechahasta= new DateTime(2022, 07, 27),
                            primaneta= 81.01F,
                            iVA= 1.62F,
                            recargoporfraccionamiento= 3.22F,
                            importetotal= 82.63F
                        }
                    }
                }
            };
            return result;
        }

        public static async Task<Domain.Poliza.Documentos.Respuesta> Documentos(Domain.Poliza.Documentos.Documentos documentos)
        {
            Domain.Poliza.Documentos.Respuesta result = new Domain.Poliza.Documentos.Respuesta()
            {
                message_status = 200,
                message_text = "Envio Exitoso de documentos",
                message_id = "5847845734-3738473432-47847263",
                document_id = documentos.document_id,
                message_body = new Domain.Poliza.Documentos.RespuestaDetalle()
                {
                    cantidad_documentos_recibidos = 1
                }
            };

            return result;
        }

        public static async Task<Domain.Poliza.Certificado.Respuesta> Certificado(Domain.Poliza.Certificado.Certificado certificado)
        {
            Domain.Poliza.Certificado.Respuesta result = new Domain.Poliza.Certificado.Respuesta()
            {
                message_status = 200,
                message_text = "Generacion Exitosa de Certificado",
                message_id = "5847845734-3738473432-47847263",
                document_id = certificado.document_id,
                message_body = new Domain.Poliza.Certificado.RespuestaDetalle()
                {
                    certificado = "BASE64"
                }
            };
            return result;
        }

        public static async Task<Domain.Poliza.Cancelacion.Respuesta> Cancelacion(Domain.Poliza.Cancelacion.SolicitudDeCancelacion solicitud)
        {
            Domain.Poliza.Cancelacion.Respuesta result = new Domain.Poliza.Cancelacion.Respuesta()
            {
                message_status = 200,
                message_text = "Cancelacion Exitosa de Poliza",
                message_id = "5847845734-3738473432-47847263",
                document_id = solicitud.document_id,
                message_body = new Domain.Poliza.Cancelacion.RespuestaDetalle()
                {
                    num_poliza_cancelada = "4412210103630"
                }
            };
            return result;
        }

        public static async Task<Domain.Poliza.Consulta.Respuesta> Consulta(Domain.Poliza.Consulta.Solicitud solicitud)
        {
            Domain.Poliza.Consulta.Respuesta result = new Domain.Poliza.Consulta.Respuesta()
            {
                message_status = 200,
                message_text = "Consulta Exitosa",
                message_id = "5847845734-3738473432-47847263",
                document_id = solicitud.document_id,
                message_body = new Domain.Poliza.Consulta.RespuestaDetalle()
                {
                }
            };

            return result;
        }
    }

}
