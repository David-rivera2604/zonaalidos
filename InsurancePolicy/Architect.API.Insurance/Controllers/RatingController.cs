using Asp.Versioning;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace Architect.API.Insurance.Controllers
{
    /// <summary>
    /// Opciones de calculo de prima.
    /// </summary>
    [ApiVersion("1.0")]
    [Authorize]
    [RoutePrefix("api/v{version:apiVersion}/Rating")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class RatingController : ApiController
    {

        /// <summary>
        /// Realizar el calculo de coberturas y recibo, con respuesta simplificada con la prima anual y mensual calculada.
        /// </summary>
        /// <param name="productAlias">Alias del producto.</param>
        /// <param name="currency">Moneda.</param>
        /// <param name="moduleCode">Código del módulo de cobertura.</param>
        /// <param name="paymentFrequency">Frecuencia de pago de la prima.</param>
        /// <param name="insuredAmount">Monto de capital asegurado.</param>
        /// <param name="birthDate">Fecha de nacimiento del cliente.</param>
        /// <returns>Primas calculadas.</returns>
        [HttpPost]
        [Route("Asegurado")]
        public IHttpActionResult Asegurado(string productAlias, int currency, int moduleCode, int paymentFrequency, double insuredAmount, DateTime birthDate)
        {
            Architect.Insurance.Contracts.Policy.Risk rk = Business.Policy.Rating.Asegurado(productAlias, currency, moduleCode, paymentFrequency, insuredAmount, birthDate);

            return Ok(new
            {
                AnnualPremium = (double)rk.Premium.AnnualPremium,
                MonthlyPremium = (double)rk.Premium.BillPremium,
                Notify = rk.Notify
            });
        }

    }
}
