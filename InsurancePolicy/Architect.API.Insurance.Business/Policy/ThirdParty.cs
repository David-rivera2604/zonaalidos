using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Insurance.Business.Policy
{
    /// <summary>
    /// Información centralizada de terceros (personas y empresas).
    /// </summary>
    public static partial class ThirdParty
    {

        /// <summary>
        /// Recupera un registro en la tabla Policy por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de Policy</returns>
        public static Contracts.Policy.ThirdParty Retrieve(int companyId, int id)
        {
            Contracts.Policy.ThirdParty result = DataAccess.Policy.ThirdParty.Retrieve(id, companyId);
            if (result.IsNotEmpty())
            {
                MapLookups(companyId, result);
            }

            return result;
        }

    }
}
