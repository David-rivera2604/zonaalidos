using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Payment.Integrations.Business
{
    /// <summary>
    /// Configuración de pagos.
    /// </summary>
    public static partial class PaymentSettings
    {
        /// <summary>
        /// Recupera una configuración asociada a un userId.
        /// </summary>
        public static Contracts.PaymentSettings Retrieve(int companyId, int userId, string currency)
        {
            Contracts.PaymentSettings result = null;
            List<Contracts.PaymentSettings> paymentSettings = Load(companyId);
            int current = currency == "CRC" ? 1 : 2;
            if (paymentSettings != null)
            {
                result = paymentSettings.Where(r => r.UserId == userId && r.Currency == current).FirstOrDefault();
            }
            if (result == null)
            {
                result = new Contracts.PaymentSettings();
            }
            return result;
        }

        /// <summary>
        /// Recupera una configuración asociada a un id.
        /// </summary>
        public static Contracts.PaymentSettings Retrieve(int companyId, int id)
        {
            Contracts.PaymentSettings result = null;
            List<Contracts.PaymentSettings> paymentSettings = Load(companyId);

            if (paymentSettings != null)
            {
                result = paymentSettings.Where(r => r.Id == id).FirstOrDefault();
            }
            if (result == null)
            {
                result = new Contracts.PaymentSettings();
            }
            return result;
        }

        internal static List<Contracts.PaymentSettings> Load(int companyId)
        {
            string key = string.Format("PaymentSettings.{0}", companyId);
            List<Contracts.PaymentSettings> result = null;

            if (Utilities.Cache.NotExist(key))
            {
                result = DataAccess.PaymentSettings.RetrieveAll(companyId);
                Utilities.Cache.SetItem(key, result);
            }
            else
            {
                result = (List<Contracts.PaymentSettings>)Utilities.Cache.GetItem(key);
            }

            return result;
        }

    }
}
