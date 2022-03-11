using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace Architect.API.Insurance.Business.Policy
{
    internal class Notify
    {
        /// <summary>
        /// Envía una notificación al usuario encargado de manejar la suscripción
        /// </summary>
        /// <param name="item">Póliza usada para el contexto del cuerpo del correo.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="currentStatus">Estatus anterior de la póliza.</param>
        internal static void InReviewStatus(Contracts.Policy.Risk item, int companyId, int userId, Enumerations.PolicyStatus currentStatus)
        {
            RiskMailBody(item, companyId);

            Core.Business.General.ChangeSet.Create(2000, item.Id, companyId, "Notificación",
                string.Format("Los usuarios del grupo '{0}' fueron notificados que la póliza queda pendiente para su revisión", ConfigurationManager.AppSettings["Mapfre.Notify.Subscription.RoleName"]), userId, item);

            API.Core.Business.General.Mail.SendByTemplate(currentStatus == Enumerations.PolicyStatus.ComplementRequest ? "Notify_Completed" : "Notify_InReviewStatus", 
                                                          companyId, userId, 0, item);
        }

        internal static void AcceptedStatus(Contracts.Policy.Risk item, int companyId, int userId, Architect.API.Core.Contracts.Security.UserMember ownerUserInfo, Architect.API.Core.Contracts.Security.UserMember currentUserInfo)
        {
            RiskMailBody(item, companyId);

            Dictionary<string, string> mailList = BuildMailList(ownerUserInfo, companyId);

            API.Core.Business.General.Mail.SendByTemplate("Notify_AcceptedStatus", companyId, userId, 0, item, mailList);

            foreach (KeyValuePair<string, string> emailToSend in mailList)
            {
                Core.Business.General.ChangeSet.Create(2000, item.Id, companyId, "Notificación", string.Format("Se notificó al usuario {0} ({1}) que la póliza fue aceptada", emailToSend.Value, emailToSend.Key), userId, item);
            }
        }

        internal static void DeclinedStatus(Contracts.Policy.Risk item, int companyId, int userId, Architect.API.Core.Contracts.Security.UserMember ownerUserInfo, Architect.API.Core.Contracts.Security.UserMember currentUserInfo)
        {
            RiskMailBody(item, companyId);

            Dictionary<string, string> mailList = BuildMailList(ownerUserInfo, companyId);

            API.Core.Business.General.Mail.SendByTemplate("Notify_DeclinedStatus", companyId, userId, 0, item, mailList);

            foreach (KeyValuePair<string, string> emailToSend in mailList)
            {
                Core.Business.General.ChangeSet.Create(2000, item.Id, companyId, "Notificación", string.Format("Se notificó al usuario {0} ({1}) que la póliza fue declinada", emailToSend.Value, emailToSend.Key), userId, item);
            }
        }

        internal static void ToBeAcceptedStatus(Contracts.Policy.Risk item, int companyId, int userId, Architect.API.Core.Contracts.Security.UserMember ownerUserInfo, Architect.API.Core.Contracts.Security.UserMember currentUserInfo)
        {
            RiskMailBody(item, companyId);

            Dictionary<string, string> mailList = BuildMailList(ownerUserInfo, companyId);
            API.Core.Business.General.Mail.SendByTemplate("Notify_ToBeAcceptedStatus", companyId, userId, 0, item, mailList);

            foreach (KeyValuePair<string, string> emailToSend in mailList)
            {
                Core.Business.General.ChangeSet.Create(2000, item.Id, companyId, "Notificación", string.Format("Se notificó al usuario {0} ({1}) que la póliza fue condicionada", emailToSend.Value, emailToSend.Key), userId, item);
            }
        }

        internal static void ComplementRequestStatus(Contracts.Policy.Risk item, int companyId, int userId, Architect.API.Core.Contracts.Security.UserMember ownerUserInfo, Architect.API.Core.Contracts.Security.UserMember currentUserInfo)
        {
            RiskMailBody(item, companyId);

            Dictionary<string, string> mailList = BuildMailList(ownerUserInfo, companyId);
            API.Core.Business.General.Mail.SendByTemplate("Notify_ComplementRequestStatus", companyId, userId, 0, item, mailList);

            foreach (KeyValuePair<string, string> emailToSend in mailList)
            {
                Core.Business.General.ChangeSet.Create(2000, item.Id, companyId, "Notificación", string.Format("Se notificó al usuario {0} ({1}) para que complemente la información de la póliza", emailToSend.Value, emailToSend.Key), userId, item);
            }
        }


        private static void RiskMailBody(Contracts.Policy.Risk item, int companyId)
        {
            List<Core.Contracts.General.LookupValue> values = Core.Business.Common.Lkp("LineOfBusiness", companyId);
            item.LineOfBusinessCodeDesc = values.Find(x => x.Code == item.LineOfBusinessCode.ToString()).Description;

            values = Core.Business.Common.Lkp("Company", companyId);
            string companyDesc = values.Find(x => x.Code == companyId.ToString()).Description;

            values = Core.Business.Common.LkpChild("ProductByLineOfBusiness", item.LineOfBusinessCode, 0, companyId);
            item.ProductCodeDesc = values.Find(x => x.Code == item.ProductCode.ToString()).Description;

            values = Core.Business.Common.LkpChild("CurrencyByProduct", item.LineOfBusinessCode, item.ProductCode, companyId);
            item.CurrencyDesc = values.Find(x => x.Code == item.Currency.ToString()).Description;

            values = Core.Business.Common.LkpChild("PaymentFrequencyByProduct", item.LineOfBusinessCode, item.ProductCode, companyId);
            item.PaymentFrequencyDesc = values.Find(x => x.Code == item.PaymentFrequency.ToString()).Description;

            values = Core.Business.Common.LkpChild("ModuleByProduct", item.LineOfBusinessCode, item.ProductCode, companyId);
            item.ModuleCodeDesc = values.Find(x => x.Code == item.ModuleCode.ToString()).Description;

            item.PrimaryInsured.AgeAtInclusion = item.PrimaryInsured.BirthDate.Age();
        }

        private static Dictionary<string, string> BuildMailList(Architect.API.Core.Contracts.Security.UserMember ownerUserInfo, int companyId)
        {
            Dictionary<string, string> result = new Dictionary<string, string>() { { ownerUserInfo.EMail, string.Format("{0} {1}", ownerUserInfo.FirstName, ownerUserInfo.LastName) } };
            string mailList = ConfigurationManager.AppSettings[string.Format("Mapfre.Notify.{0}.Response.Mail", companyId)];
            if (mailList.IsNotEmpty())
            {
                foreach (string emailToSend in mailList.Split(';'))
                {
                    if (!result.ContainsKey(emailToSend.Split('=')[0].Trim()))
                    {
                        result.Add(emailToSend.Split('=')[0].Trim(), emailToSend.Split('=')[1].Trim());
                    }
                }
            }
            return result;
        }

    }
}
