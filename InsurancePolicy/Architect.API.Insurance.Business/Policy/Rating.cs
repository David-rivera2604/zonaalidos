using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Insurance.Business.Policy
{
    public static class Rating
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
        /// <returns>Detalle de coberturas y recibos calculados.</returns>
        public static Architect.Insurance.Contracts.Policy.Risk Asegurado(string productAlias, int currency, int moduleCode, int paymentFrequency, double insuredAmount, DateTime birthDate)
        {
            Architect.Insurance.Contracts.Policy.Risk rk = new Architect.Insurance.Contracts.Policy.Risk()
            {
                PaymentFrequencyCode = (Int16)paymentFrequency,
                Currencies = new List<Architect.Insurance.Contracts.Policy.Currency>()
                { new Architect.Insurance.Contracts.Policy.Currency()
                    {
                         CurrencyCode = (short)currency
                    }
                },
                Roles = new List<Architect.Insurance.Contracts.Policy.Role>()
                { new Architect.Insurance.Contracts.Policy.Role()
                        { ClientRole = 2, BirthDate = birthDate}
                },
                Modules = new List<Architect.Insurance.Contracts.Policy.Module>()
                { new Architect.Insurance.Contracts.Policy.Module()
                    {
                        ModuleCode = moduleCode
                    }
                },
                ParticularData = new Architect.Insurance.Contracts.Policy.ParticularData()
                {
                    Life = new Architect.Insurance.Contracts.Policy.Life()
                    {
                        InsuredAmount = (decimal)insuredAmount
                    }
                }
            };

            Architect.Insurance.Contracts.Product.ProductMaster product = Products.Specification.Definition(productAlias);

            if (product.IsNotEmpty())
            {
                Architect.Insurance.Services.Rating.Calculate(rk, product);
                Architect.Insurance.Services.Billing.Calculate(rk, product);
            }
            return rk;
        }

    }
}
