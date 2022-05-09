using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.Payment.Integrations.Business
{
    /// <summary>
    /// Pagos en línea
    /// </summary>
    public static partial class OnlinePayment
    {

        /// <summary>
        /// Crea un registro en la tabla OnlinePayment.
        /// </summary>
        public static Contracts.OnlinePayment Create(int companyId, int userId, Contracts.OnlinePayment item)
        {
            Contracts.OnlinePayment result = item;
    
                if (result.Id.IsEmpty())
                {
                    result.Id = DataAccess.OnlinePayment.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

            DataAccess.OnlinePayment.Create(result);
       
            return result;
        }

        

        /// <summary>
        /// Recupera un registro en la tabla OnlinePayment por medio del campo RequestID.
        /// </summary>
        public static Contracts.OnlinePayment RetrieveByRequestID(int companyId, Int64 requestId)
        {
            return DataAccess.OnlinePayment.RetrieveByRequestID(requestId, companyId );
        }

        public static Contracts.OnlinePayment RetrieveByPolicyAndBill(int companyId, string policyId, Int64 billNumber)
        {
            return DataAccess.OnlinePayment.Retrieve(policyId, billNumber, companyId);
        }

        public static Contracts.OnlinePayment RetrieveById(int companyId, int id)
        {
            return DataAccess.OnlinePayment.Retrieve(id, companyId);
        }

        /// <summary>
        /// Actualiza un registro en la tabla OnlinePayment por medio de su clave primaria.
        /// </summary>
        public static int Update(Contracts.OnlinePayment onlinepaymentItem)
        {
            return DataAccess.OnlinePayment.Update(onlinepaymentItem);
        }

        /// <summary>
        /// Actualiza un registro en la tabla OnlinePayment por medio de su clave primaria.
        /// </summary>
        public static int UpdateNewSession(Contracts.OnlinePayment onlinepaymentItem)
        {
            return DataAccess.OnlinePayment.UpdateNewSession(onlinepaymentItem);
        }
    }
}
