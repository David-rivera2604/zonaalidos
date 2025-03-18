using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Architect.API.Tron.Contracts.SINPEMovil.Response;
using Microsoft.Web.Http;

namespace Architect.API.Tron.Controllers
{
    /// <summary>
    /// Controlador para la vinculación asistida de SINPE Móvil Empresarial.
    /// </summary>
    [ApiVersion("1.0")]    
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/SINPEMovil")]
    public class SINPEMovilController : ApiController
    {
        /// <summary>
        /// Aplica un pago recibido.
        /// </summary>
        /// <param name="request">Datos del pago a aplicar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpPost]
        [Route("AplicarPago")]
        [AllowAnonymous]
        [ResponseType(typeof(Contracts.SINPEMovil.Response.AplicarPago))]
        public async Task<IHttpActionResult> AplicarPago([FromBody] Contracts.SINPEMovil.Request.AplicarPago request)
        {
            if (request == null)
            {
                return BadRequest("El request no puede ser nulo.");
            }

            var response = await Business.Backoffice.SINPEMovil.Create(request);    

            return Ok(response);
        }

        /// <summary>
        /// Consulta los datos de una transacción.
        /// </summary>
        /// <param name="id">Identificador de la transacción.</param>
        /// <param name="request">Datos de la consulta.</param>
        /// <returns>Resultado de la consulta.</returns>
        [HttpGet]
        [Route("ConsultaDatos")]
        public IHttpActionResult ConsultaDatos([FromUri] string id) //, [FromBody] Contracts.SINPEMovil.Request.ConsultaDatos request)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("El id no puede ser nulo o vacío.");
            }

            //Página de confirmación: El Id siempre será el
            //código digitado por el usuario que haría
            //referencia al código especifico de la aplicación
            //cliente, por ejemplo: Número de suscriptor,
            //número de orden o número de factura, número de
            //afiliada.

            //if (request == null)
            //{
            //    return BadRequest("El request no puede ser nulo.");
            //}

            // Aquí se implementaría la lógica para obtener la información solicitada,
            // por ejemplo consultando una base de datos o un servicio externo.

            // Ejemplo: Se simula una respuesta exitosa con una factura.
            var response = new Contracts.SINPEMovil.Response.ConsultaDatos
            {
                Codigo = 0,
                Mensaje = "Consulta realizada correctamente.",
                CantidadFacturas = 1,
                Facturas = new List<Contracts.SINPEMovil.Response.Factura>
                {
                    new Contracts.SINPEMovil.Response.Factura
                    {
                        Codigo = "123456789",
                        Identificacion = "3-0777-0999",
                        Nombre = "Kattya",
                        Apellido = "Rivera Soto",
                        Telefono = "88889999",
                        Vencimiento = "01/12/2020",
                        Saldo = 15500.00M,
                        SaldoMinimo = 5000.00M,
                        FacturasImpagas = 0
                    }
                }
            };

            return Ok(response);
        }
    }
}
