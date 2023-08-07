using Aliados.Monge.Domain.Poliza.Documentos;
using Aliados.Monge.Domain.Poliza.Emision;
using Architect.API.Tron.Business.Cotizacion;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Aliados.Monge.Application.Poliza
{
    public sealed class Emision
    {

        public static async Task<Domain.Poliza.Emision.Respuesta> Handler(Domain.Poliza.Emision.Poliza risk, Architect.API.Core.Contracts.Security.Token tokenInfo)
        {
            Domain.Poliza.Emision.Respuesta result = null;

            // Costa Rica
            if (risk?.Datos_Generales?.pais == "CR")
            {
                // Viajero
                if (risk.Datos_Generales.cod_producto.StartsWith("441-"))
                { 
                    result = Poliza.Ramos.Viajero.Handler(risk, tokenInfo).Result;
                }
                // Seguro protección de tarjetas
                if (risk.Datos_Generales.cod_producto.StartsWith("230"))
                {
                    result = Poliza.Ramos.Tarjetas.Handler(risk, tokenInfo).Result;
                }
            }

            //En caso de no se procese el request se indica que se trat de un producto no permitido
            if (result == null)
            {
                result = new Domain.Poliza.Emision.Respuesta()
                {
                    message_status = 400,
                    message_text = "País y/o producto no permitido",
                    message_id = Guid.NewGuid().ToString(),
                    document_id = risk.document_id
                };
            }
            return result;
        }

    }

}
