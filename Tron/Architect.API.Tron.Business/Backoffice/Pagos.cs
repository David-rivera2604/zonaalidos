using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect.Payment.Integrations;
using Architect.Utilities.Extensions;

namespace Architect.API.Tron.Business.Backoffice
{
    public class Pagos
    {
        /// <summary>
        /// Permite la creación de un sesión para realizar un pago.
        /// </summary>
        public async static Task<Payment.Integrations.Contracts.SessionInformation> CrearSesion(int companyId, int userId, string ipAddress, string userAgent, int cod_agt, string num_poliza, Int64 num_recibo)
        {
            Payment.Integrations.Contracts.SessionInformation session;
            Contracts.Vistas.Recibo recibo;
            if (num_poliza == "123" && num_recibo == 456)
            {
                recibo = new Contracts.Vistas.Recibo()
                {
                    NOM_TERCERO = "Nelson",
                    APE1_TERCERO = "Soler",
                    EMAIL = "solernelson@hotmail.com",
                    TIP_DOCUM = "2",
                    COD_DOCUM = "186200170219",
                    TLF_MOVIL = "72155569",
                    NOM_RAMO = "NUEVA PÓLIZA LÍDER",
                    COD_MON = 1,
                    IMP_RECIBO = 53909.96
                };
            }
            else
            {
                recibo = DataAccess.PorRamo.Informacion_de_un_Recibo(Utilities.Helpers.Settings.IntegerValue("Mapfre.Tron.cod_cia", 1), cod_agt, num_poliza, num_recibo);
            }

            if (recibo != null)
            {
                Payment.Integrations.Contracts.PaymentInformation payInfo = new Payment.Integrations.Contracts.PaymentInformation()
                {
                    FirstName = recibo.NOM_TERCERO,
                    LastName = recibo.APE1_TERCERO,
                    Email = recibo.EMAIL.IfEmpty(recibo.TXT_EMAIL),
                    Document = recibo.COD_DOCUM,
                    DocumentType = Convert.ToInt32(recibo.TIP_DOCUM),
                    Mobile = recibo.TLF_MOVIL.IfEmpty(recibo.TLF_NUMERO),
                    PolicyId = num_poliza,
                    BillNumber = num_recibo,
                    Description = string.Format("MAPFRE: {0} POLIZA #{1} RECIBO #{2}", recibo.NOM_RAMO, num_poliza, num_recibo),
                    Currency = recibo.COD_MON,
                    Amount = recibo.IMP_RECIBO
                };
                session = await Payment.Integrations.Payment.NewSession(companyId, userId, payInfo, ipAddress, userAgent);
            }
            else
            {
                session = new Payment.Integrations.Contracts.SessionInformation()
                {
                    Status = "FAIL",
                    Reason = "Recibo no encontrado o no esta pendiente de pago"
                };
            }
            return session;
        }
    }
}
