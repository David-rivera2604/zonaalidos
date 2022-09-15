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
        /// Recupera una configuración asociada a un username.
        /// </summary>
        public static Contracts.PaymentSettings Retrieve(int userId, string currency)
        {
            Contracts.PaymentSettings result = null;
            List<Contracts.PaymentSettings> paymentSettings = Load();
            int current = currency == "CRC" ? 1 : 2;
            if (paymentSettings != null)
            {
                result = paymentSettings.Where(r => r.UserName == userId.ToString() && r.Currency == current).FirstOrDefault();
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
        public static Contracts.PaymentSettings Retrieve(int id)
        {
            Contracts.PaymentSettings result = null;
            List<Contracts.PaymentSettings> paymentSettings = Load();

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

        internal static List<Contracts.PaymentSettings> Load()
        {
            List<Contracts.PaymentSettings> result = null;

            if (Utilities.Cache.NotExist("PaymentSettings"))
            {
                result = DataAccess.PaymentSettings.RetrieveAll();
                Utilities.Cache.SetItem("PaymentSettings", result);
            }
            else
            {
                result = (List<Contracts.PaymentSettings>)Utilities.Cache.GetItem("PaymentSettings");
            }

            return result;
        }

    }
}
