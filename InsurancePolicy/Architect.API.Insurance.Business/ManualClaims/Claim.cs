using Architect.Utilities.Extensions;

namespace Architect.API.Insurance.Business.ManualClaims
{
    /// <summary>
    /// .
    /// </summary>
    public static partial class Claim
    {

        /// <summary>
        /// Recupera un siniestro por medio de su identificación única o su identificación de siniestro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="claimId">Identificación del siniestro.</param>
        /// <param name="include">Indica que información incluir, opciones posibles Roles y DocumentRequests</param>
        /// <returns>Instancia de Claim</returns>
        public static Contracts.ManualClaims.Claim Retrieve(int companyId, int id, string claimId = "", string include = "")
        {
            Contracts.ManualClaims.Claim result;

            if (id != 0)
            {
                result = DataAccess.ManualClaims.Claim.Retrieve(id, companyId);
            }
            else
            {
                result = DataAccess.ManualClaims.Claim.RetrieveByClaimId(claimId, companyId);
            }


            if (result.IsNotEmpty())
            {
                MapLookups(companyId, result);
                if (include == "*" || include.Contain("Roles"))
                {
                    result.Roles = DataAccess.ManualClaims.ClaimRole.RetrieveByClaimId(companyId, result.Id);
                }
                if (include == "*" || include.Contain("DocumentRequests"))
                {
                    result.DocumentRequests = DataAccess.ManualClaims.ClaimDocumentRequest.RetrieveByClaimId(companyId, result.Id);
                }
            }
            return result;
        }



    }
}
