using Architect.API.Core.Contracts.Security;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Insurance.Business.Policy
{
    /// <summary>
    /// Opciones para la emisión de las pólizas
    /// </summary>
    public static partial class Risk
    {
        /// <summary>
        /// Permite realizar los cambios de estado a una póliza que se encuentra en modo de suscripción.
        /// </summary>
        public static Contracts.Policy.Risk ChangeStatus(Contracts.Policy.RiskStatus item, Core.Contracts.Security.Token tokenInfo, ref string message)
        {
            int companyId = tokenInfo.CompanyId;
            int userId = tokenInfo.UserId;
            string roles = tokenInfo.Roles;
            Enumerations.PolicyStatus status = (Enumerations.PolicyStatus)item.NewStatus;
            Contracts.Policy.Risk result = Risk.RetrievePolicyByKey(item.Id, companyId);
            Enumerations.PolicyStatus currentStatus = (Enumerations.PolicyStatus)result.Status;

            switch (status)
            {
                case Enumerations.PolicyStatus.InReview:
                    result = ChangeStatusToInReview(result, status, currentStatus, item, companyId, userId, roles, ref message);
                    break;

                case Enumerations.PolicyStatus.InForce:
                    if (Products.Specification.SettingBoolValue(result.ProductAlias, "Allow.DigitalSign"))
                    {
                        DigitalSignature.Submit(result, tokenInfo, true);
                        result = ChangeStatusPendingBySignature(result, Enumerations.PolicyStatus.PendingBySignature, item, companyId, userId, ref message);
                    }
                    else
                    {
                        result = ChangeStatusInForce(result, status, currentStatus, item, companyId, userId, roles, ref message);
                    }
                    break;

                case Enumerations.PolicyStatus.Declined:
                    result = ChangeStatusDeclined(result, status, currentStatus, item, companyId, userId, roles, ref message);
                    break;

                case Enumerations.PolicyStatus.ToBeAccepted:
                    result = ChangeStatusToBeAccepted(result, status, currentStatus, item, companyId, userId, roles, ref message);
                    break;

                case Enumerations.PolicyStatus.ComplementRequest:
                    result = ChangeStatusToComplementRequest(result, status, currentStatus, item, companyId, userId, roles, ref message);
                    break;

                case Enumerations.PolicyStatus.Cancel:
                    result = ChangeStatusCancel(result, status, item, companyId, userId, ref message);
                    break;
            }

            item.NewStatusDesc = Core.Business.Common.Lkp("PolicyStatus", companyId).Find(x => x.Code == result.Status.ToString()).Description;

            return result;
        }

        /// <summary>
        /// Cancela una póliza en vigor.
        /// </summary>
        private static Contracts.Policy.Risk ChangeStatusPendingBySignature(Contracts.Policy.Risk result, Enumerations.PolicyStatus status, Contracts.Policy.RiskStatus item, int companyId, int userId, ref string message)
        {
            result.Status = (int)status;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;

            DataAccess.Policy.Risk.Update(result);

            Core.Business.General.ChangeSet.Create(2000, item.Id, companyId, "Pendiente por firma.", null, userId, item);

            message = "Póliza enviada para su firma electrónica";

            return result;
        }

        /// <summary>
        /// Condiciona una póliza en suscripción para su revisión por un suscriptor.
        /// </summary>
        /// <param name="result">Información de la póliza en suscripción.</param>
        /// <param name="status">Estado nuevo.</param>
        /// <param name="currentStatus">Estado actual.</param>
        /// <param name="item">Datos para el cambio de estado.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="roles">Lista de roles permitidos del usuario que solicita el cambio.</param>
        /// <param name="message">Descripción del cambio realizado.</param>
        /// <returns>Póliza con los cambios aplicados.</returns>
        private static Contracts.Policy.Risk ChangeStatusToInReview(Contracts.Policy.Risk result, Enumerations.PolicyStatus status, Enumerations.PolicyStatus currentStatus, Contracts.Policy.RiskStatus item, int companyId, int userId, string roles, ref string message)
        {
            if (currentStatus == Enumerations.PolicyStatus.InReview && !roles.Contains("Suscriptor"))
                throw new Exception("El usuario no posee el rol necesario para realizar esta operación");

            Architect.API.Core.Contracts.Security.UserMember ownerUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, result.UpdateUserCode);
            Architect.API.Core.Contracts.Security.UserMember currentUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, userId);

            result.Status = (int)status;
            result.UpdateDate = DateTime.Now;
            DataAccess.Policy.Risk.Update(result);
            Core.Business.General.ChangeSet.Create(2000, item.Id, companyId, "En revisión", null, userId, item);

            Notify.InReviewStatus(result, companyId, userId, currentStatus);

            message = string.Format("La póliza cambio a revisión de forma exitosa. El usuario {0} {1} ({2}) fue notificado.", ownerUserInfo.FirstName, ownerUserInfo.LastName, ownerUserInfo.EMail);

            return result;
        }

        /// <summary>
        /// Emite una póliza en suscripción.
        /// </summary>
        /// <param name="result">Información de la póliza en suscripción.</param>
        /// <param name="status">Estado nuevo.</param>
        /// <param name="currentStatus">Estado actual.</param>
        /// <param name="item">Datos para el cambio de estado.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="roles">Lista de roles permitidos del usuario que solicita el cambio.</param>
        /// <param name="message">Descripción del cambio realizado.</param>
        /// <returns>Póliza con los cambios aplicados.</returns>
        private static Contracts.Policy.Risk ChangeStatusInForce(Contracts.Policy.Risk result, Enumerations.PolicyStatus status, Enumerations.PolicyStatus currentStatus, Contracts.Policy.RiskStatus item, int companyId, int userId, string roles, ref string message)
        {
            if (currentStatus == Enumerations.PolicyStatus.InReview && !roles.Contains("Suscriptor"))
                throw new Exception("El usuario no posee el rol necesario para realizar esta operación");

            Architect.API.Core.Contracts.Security.UserMember ownerUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, result.UpdateUserCode);
            Architect.API.Core.Contracts.Security.UserMember currentUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, userId);

            result.PolicyId = DataAccess.Policy.Risk.RetrieveLastPolicyId(companyId) + 1;
            result.Status = (int)status;
            result.Comments = item.Comments;
            result.Surcharge = item.Surcharge;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;
            DataAccess.Policy.Risk.Update(result);
            Core.Business.General.ChangeSet.Create(2000, item.Id, companyId, "Aceptada", null, userId, item);

            if (currentStatus != Enumerations.PolicyStatus.ToBeAccepted)
            {
                Notify.AcceptedStatus(result, companyId, userId, ownerUserInfo, currentUserInfo);

                message = string.Format("La póliza fue emitida de forma exitosa, bajo el número #{0}. El usuario {1} {2} ({3}) fue notificado.", result.PolicyId, ownerUserInfo.FirstName, ownerUserInfo.LastName, ownerUserInfo.EMail);
            }
            else
            {
                message = string.Format("La póliza fue emitida de forma exitosa, bajo el número #{0}.", result.PolicyId);
            }

            return result;
        }

        /// <summary>
        /// Declina una póliza en suscripción.
        /// </summary>
        /// <param name="result">Información de la póliza en suscripción.</param>
        /// <param name="status">Estado nuevo.</param>
        /// <param name="currentStatus">Estado actual.</param>
        /// <param name="item">Datos para el cambio de estado.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="roles">Lista de roles permitidos del usuario que solicita el cambio.</param>
        /// <param name="message">Descripción del cambio realizado.</param>
        /// <returns>Póliza con los cambios aplicados.</returns>
        private static Contracts.Policy.Risk ChangeStatusDeclined(Contracts.Policy.Risk result, Enumerations.PolicyStatus status, Enumerations.PolicyStatus currentStatus, Contracts.Policy.RiskStatus item, int companyId, int userId, string roles, ref string message)
        {
            if (currentStatus == Enumerations.PolicyStatus.InReview && !roles.Contains("Suscriptor"))
                throw new Exception("El usuario no posee el rol necesario para realizar esta operación");

            Architect.API.Core.Contracts.Security.UserMember ownerUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, result.UpdateUserCode);
            Architect.API.Core.Contracts.Security.UserMember currentUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, userId);

            result.Comments = item.Comments;
            result.Surcharge = item.Surcharge;
            result.Status = (int)status;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;
            DataAccess.Policy.Risk.Update(result);
            Core.Business.General.ChangeSet.Create(2000, item.Id, companyId, "Declinada", null, userId, item);

            if (currentStatus != Enumerations.PolicyStatus.ToBeAccepted)
            {
                Notify.DeclinedStatus(result, companyId, userId, ownerUserInfo, currentUserInfo);

                message = string.Format("La póliza ha sido declinada de forma exitosa. El usuario {0} {1} ({2}) fue notificado.", ownerUserInfo.FirstName, ownerUserInfo.LastName, ownerUserInfo.EMail);
            }
            else
            {
                message = "La póliza ha sido declinada de forma exitosa.";
            }

            return result;
        }



        /// <summary>
        /// Condiciona una póliza en suscripción para ser aceptada.
        /// </summary>
        /// <param name="result">Información de la póliza en suscripción.</param>
        /// <param name="status">Estado nuevo.</param>
        /// <param name="currentStatus">Estado actual.</param>
        /// <param name="item">Datos para el cambio de estado.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="roles">Lista de roles permitidos del usuario que solicita el cambio.</param>
        /// <param name="message">Descripción del cambio realizado.</param>
        /// <returns>Póliza con los cambios aplicados.</returns>
        private static Contracts.Policy.Risk ChangeStatusToBeAccepted(Contracts.Policy.Risk result, Enumerations.PolicyStatus status, Enumerations.PolicyStatus currentStatus, Contracts.Policy.RiskStatus item, int companyId, int userId, string roles, ref string message)
        {
            if (currentStatus == Enumerations.PolicyStatus.InReview && !roles.Contains("Suscriptor"))
                throw new Exception("El usuario no posee el rol necesario para realizar esta operación");

            Architect.API.Core.Contracts.Security.UserMember ownerUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, result.UpdateUserCode);
            Architect.API.Core.Contracts.Security.UserMember currentUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, userId);

            result.Comments = item.Comments;
            result.Surcharge = item.Surcharge;
            result.Status = (int)status;
            //result.UpdateUserCode = userId; No se puede cambiar el usuario original ya que así queda la póliza amarrada a ese usuario
            result.UpdateDate = DateTime.Now;
            DataAccess.Policy.Risk.Update(result);
            Core.Business.General.ChangeSet.Create(2000, item.Id, companyId, "Condicionada", null, userId, item);

            Notify.ToBeAcceptedStatus(result, companyId, userId, ownerUserInfo, currentUserInfo);

            message = string.Format("La póliza ha sido condicionada de forma exitosa. El usuario {0} {1} ({2}) fue notificado.", ownerUserInfo.FirstName, ownerUserInfo.LastName, ownerUserInfo.EMail);

            return result;
        }

        /// <summary>
        /// Retorna la póliza en suscripción para que se complemente.
        /// </summary>
        /// <param name="result">Información de la póliza en suscripción.</param>
        /// <param name="status">Estado nuevo.</param>
        /// <param name="currentStatus">Estado actual.</param>
        /// <param name="item">Datos para el cambio de estado.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="roles">Lista de roles permitidos del usuario que solicita el cambio.</param>
        /// <param name="message">Descripción del cambio realizado.</param>
        /// <returns>Póliza con los cambios aplicados.</returns>
        private static Contracts.Policy.Risk ChangeStatusToComplementRequest(Contracts.Policy.Risk result, Enumerations.PolicyStatus status, Enumerations.PolicyStatus currentStatus, Contracts.Policy.RiskStatus item, int companyId, int userId, string roles, ref string message)
        {
            if (currentStatus == Enumerations.PolicyStatus.InReview && !roles.Contains("Suscriptor"))
                throw new Exception("El usuario no posee el rol necesario para realizar esta operación");

            Architect.API.Core.Contracts.Security.UserMember ownerUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, result.UpdateUserCode);
            Architect.API.Core.Contracts.Security.UserMember currentUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, userId);

            result.Comments = item.Comments;
            result.Surcharge = item.Surcharge;
            result.Status = (int)status;
            result.UpdateDate = DateTime.Now;
            DataAccess.Policy.Risk.Update(result);
            Core.Business.General.ChangeSet.Create(2000, item.Id, companyId, "Complementos solicitados", null, userId, item);

            Notify.ComplementRequestStatus(result, companyId, userId, ownerUserInfo, currentUserInfo);

            message = string.Format("La solicitud de complementos fue enviada de forma exitosa. El usuario {0} {1} ({2}) fue notificado.", ownerUserInfo.FirstName, ownerUserInfo.LastName, ownerUserInfo.EMail);

            return result;
        }

        /// <summary>
        /// Cancela una póliza en vigor.
        /// </summary>
        /// <param name="result">Información de la póliza en suscripción.</param>
        /// <param name="status">Estado nuevo.</param>
        /// <param name="item">Datos para el cambio de estado.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="message">Descripción del cambio realizado.</param>
        /// <returns>Póliza con los cambios aplicados.</returns>
        private static Contracts.Policy.Risk ChangeStatusCancel(Contracts.Policy.Risk result, Enumerations.PolicyStatus status, Contracts.Policy.RiskStatus item, int companyId, int userId, ref string message)
        {
            result.Status = (int)status;
            result.CancellationDate = item.CancellationDate;
            result.ReasonForStatus = item.ReasonForStatus;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;

            DataAccess.Policy.Risk.Update(result);

            string ReasonForStatusDesc = Core.Business.Common.Lkp("ReasonForStatus", companyId).Find(x => x.Code == result.ReasonForStatus.ToString()).Description;

            Core.Business.General.ChangeSet.Create(2000, item.Id, companyId, "Cancelada", string.Format("Causa: {0}", ReasonForStatusDesc), userId, item);

            message = "La póliza ha sido cancelada de forma exitosa.";

            return result;
        }

        //private static string ResponseToTenant_Mail(Architect.API.Core.Contracts.Security.UserMember ownerUserInfo, int companyId)
        //{
        //    string result = null;
        //    switch (companyId)
        //    {
        //        case 1: //Coopeservidores
        //            result = ConfigurationManager.AppSettings["Mapfre.Notify.Coopeservidores.Response.Mail"];
        //            break;
        //        default:
        //            result = ownerUserInfo.EMail;
        //            break;
        //    }
        //    return result;
        //}

        //private static string ResponseToTenant_Name(Architect.API.Core.Contracts.Security.UserMember ownerUserInfo, int companyId)
        //{
        //    string result = null;
        //    switch (companyId)
        //    {
        //        case 1: //Coopeservidores
        //            result = ConfigurationManager.AppSettings["Mapfre.Notify.Coopeservidores.Response.Name"];
        //            break;
        //        default:
        //            result = string.Format("{0} {1}", ownerUserInfo.FirstName, ownerUserInfo.LastName);
        //            break;
        //    }
        //    return result;
        //}

        /// <summary>
        /// Información para la impresión de una póliza.
        /// </summary>
        public static Contracts.Policy.RiskView Information(int id, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Policy.Risk risk = RetrievePolicyByKey(id, tokenInfo.CompanyId);
            Contracts.Policy.RiskView result = Mapper_Information(risk, tokenInfo.CompanyId);
            result.Behavior = Reglas.research.Apply_Comportamientos("policy", risk, tokenInfo);
            return result;
        }

        internal static Contracts.Policy.RiskView Mapper_Information(Contracts.Policy.Risk resultInternal, int companyId)
        {
            Contracts.Policy.RiskView result = null;
            List<Core.Contracts.General.LookupValue> values = null;

            if (resultInternal.IsNotEmpty())
            {
                result = Business.Policy.Risk.Mapper2View(resultInternal);
                result.PrimaryInsured = Business.Policy.RiskRoles.Mapper2View(resultInternal.PrimaryInsured);

                result.PrimaryInsured.AgeAtInclusion = result.PrimaryInsured.BirthDate.Age();

                if (result.PrimaryInsured.RetirementModality == 1)
                    result.PrimaryInsured.IsRetired = "Si";
                else
                    result.PrimaryInsured.IsRetired = "No";

                result.Overdraft = Business.Policy.RiskOverdraft.Mapper2View(resultInternal.Overdraft);

                result.Questionary = Business.Policy.RiskQuestionnaires.Mapper2View(resultInternal.Questionary);
                result.Diagnosis = Business.Policy.RiskQuestionnaires.Mapper2DiagnosisView(resultInternal.Questionary);
                result.Beneficiaries = Business.Policy.RiskRoles.Mapper2View(resultInternal.Beneficiaries, companyId);

                result.ProductAlias = Core.Business.Common.LkpChildFull("ProductByLineOfBusiness", result.LineOfBusinessCode, companyId).Find(x => x.Code == result.ProductCode).ExtendStringValue1;
                if (result.ProductAlias.IsNotEmpty())
                {
                    result.OwnerName = Products.Specification.SettingStringValue(result.ProductAlias, "Parent.Policy.Owner.Name");
                    result.OwnerId = Products.Specification.SettingStringValue(result.ProductAlias, "Parent.Policy.Owner.Id");
                }
                if (resultInternal.Subsidiary.IsNotEmpty())
                {
                    result.OwnerName = Core.Business.Common.LkpDescription(companyId, "BayerPolizas", resultInternal.Subsidiary.ToString());
                    result.OwnerId = Core.Business.Common.LkpDescription(companyId, "BayerNumeroPoliza", resultInternal.MainPolicyId);
                }
            }


            if (result.IsNotEmpty())
            {
                if (result.CancellationDate == DateTime.MinValue)
                    result.CancellationDate = null;

                if (result.LineOfBusinessCode.IsNotEmpty())
                {
                    values = Core.Business.Common.Lkp("LineOfBusiness", companyId);
                    result.LineOfBusinessDesc = values.Find(x => x.Code == result.LineOfBusinessCode.ToString()).Description.ToUpper();
                    if (result.ProductCode.IsNotEmpty())
                    {
                        values = Core.Business.Common.LkpChild("ProductByLineOfBusiness", result.LineOfBusinessCode, 0, companyId);
                        result.ProductDesc = values.Find(x => x.Code == result.ProductCode.ToString()).Description;
                        if (result.Currency.IsNotEmpty())
                        {
                            values = Core.Business.Common.LkpChild("CurrencyByProduct", result.LineOfBusinessCode, result.ProductCode, companyId);
                            result.CurrencyDesc = values.Find(x => x.Code == result.Currency.ToString()).Description.ToUpper();
                        }
                        if (result.PaymentFrequency.IsNotEmpty())
                        {
                            values = Core.Business.Common.LkpChild("PaymentFrequencyByProduct", result.LineOfBusinessCode, result.ProductCode, companyId);
                            result.PaymentFrequencyDesc = values.Find(x => x.Code == result.PaymentFrequency.ToString()).Description.ToUpper();
                        }
                        if (result.ModuleCode.IsNotEmpty())
                        {
                            values = Core.Business.Common.LkpChild("ModuleByProduct", result.LineOfBusinessCode, result.ProductCode, companyId);
                            result.ModuleDesc = values.Find(x => x.Code == result.ModuleCode.ToString()).Description.ToUpper();
                        }
                    }
                }
                //if (result.Status.IsNotEmpty())
                //{
                //    values = Core.Business.General.Lookup.Lkp("PolicyStatus");
                //    result.StatusDesc = values.Find(x => x.Code == result.Status.ToString()).Description;
                //}
                result.ReasonForStatusDesc = Core.Business.Common.LkpDescription(companyId, "ReasonForStatus", result.Status, result.ReasonForStatus.ToString());
            }
            if (result.IsNotEmpty() && result.PrimaryInsured.IsNotEmpty())
            {
                if (result.PrimaryInsured.DocumentType.IsNotEmpty())
                {
                    values = Core.Business.Common.Lkp("DocumentType", companyId);
                    result.PrimaryInsured.DocumentTypeDesc = values.Find(x => x.Code == result.PrimaryInsured.DocumentType.ToString()).Description.ToUpper();
                }
                if (result.PrimaryInsured.Gender.IsNotEmpty())
                {
                    values = Core.Business.Common.Lkp("Gender", companyId);
                    result.PrimaryInsured.GenderDesc = values.Find(x => x.Code == result.PrimaryInsured.Gender.ToString()).Description.ToUpper();
                }
                if (result.PrimaryInsured.CivilStatus.IsNotEmpty())
                {
                    values = Core.Business.Common.Lkp("CivilStatus", companyId);
                    result.PrimaryInsured.CivilStatusDesc = values.Find(x => x.Code == result.PrimaryInsured.CivilStatus.ToString()).Description.ToUpper();
                }
                if (result.PrimaryInsured.Province.IsNotEmpty())
                {
                    values = Core.Business.Common.Lkp("CR_Provincia", companyId);
                    result.PrimaryInsured.ProvinceDesc = values.Find(x => x.Code == result.PrimaryInsured.Province.ToString()).Description.ToUpper();
                }
                if (result.PrimaryInsured.Canton.IsNotEmpty())
                {
                    values = Core.Business.Common.LkpChild("CR_Canton", result.PrimaryInsured.Province, 0, companyId);
                    result.PrimaryInsured.CantonDesc = values.Find(x => x.Code == result.PrimaryInsured.Canton.ToString()).Description.ToUpper();
                }
                if (result.PrimaryInsured.District.IsNotEmpty())
                {
                    values = Core.Business.Common.LkpChild("CR_Distritos", result.PrimaryInsured.Canton, 0, companyId);
                    result.PrimaryInsured.DistrictDesc = values.Find(x => x.Code == result.PrimaryInsured.District.ToString()).Description.ToUpper();
                }
                if (result.PrimaryInsured.PhoneType.IsNotEmpty())
                {
                    values = Core.Business.Common.Lkp("PhoneType", companyId);
                    result.PrimaryInsured.PhoneTypeDesc = values.Find(x => x.Code == result.PrimaryInsured.PhoneType.ToString()).Description.ToUpper();
                }

                result.PrimaryInsured.FullAddress = string.Format("{0}, {1}, {2}, {3}", result.PrimaryInsured.ProvinceDesc, result.PrimaryInsured.CantonDesc, result.PrimaryInsured.DistrictDesc, result.PrimaryInsured.AddressDetail).Trim().ToUpper();
            }

            //Prefijo para reportes
            result.Prefix = string.Empty;
            if (result.PrimaryInsured.IsNotEmpty() && result.PrimaryInsured.BirthDate.Age() > 64)
                result.Prefix = "_mayor_que_64";
            return result;
        }

        /// <summary>
        /// Realiza la emisión de una póliza.
        /// </summary>
        /// <param name="tokenInfo">Contexto del usuario conectado.</param>
        /// <param name="item">Instancia de la póliza a emitir.</param>
        /// <param name="source">Indica si la póliza si se esta actualizando una póliza incompleta (Put) o se esta emitiendo de forma directa(Post)</param>
        /// <returns>Información de la póliza emitida.</returns>
        public static Contracts.Structure.IssuePolicyResult IssuePolicy(Core.Contracts.Security.Token tokenInfo, Contracts.Policy.Risk item, string source)
        {
            Contracts.Structure.IssuePolicyResult result = new Contracts.Structure.IssuePolicyResult();
            int orignalStatus = item.Status;

            item.Status = 1;
            item = Business.Policy.Risk.Setup(item, tokenInfo.CompanyId);
            item.BranchOffice = tokenInfo.BranchOffice;
            item.ExecutiveUserCode = tokenInfo.UserId;
            result.Errors = Business.Policy.Risk.PolicyStorage(item, orignalStatus, tokenInfo, source);

            bool digitalSignFail = result.Errors.Find(r => r.Group == "DigitalSignFail") != null;
            if (digitalSignFail || item.DraftStorage == "enabled" || (item.DraftStorage != "enabled" && result.Errors.Count == 0))
            {
                switch (source)
                {
                    case "Post":
                        item = Business.Policy.Risk.CreatePolicy(item, tokenInfo.UserId, tokenInfo.CompanyId);
                        break;

                    case "Put":
                        item = Business.Policy.Risk.UpdatePolicy(item, tokenInfo.UserId, tokenInfo.CompanyId, source);
                        break;
                }
            }

            result.Risk = item;
            return result;
        }

        public static Contracts.Structure.IssuePolicyResult ModifyPolicy(Core.Contracts.Security.Token tokenInfo, Contracts.Policy.Risk item)
        {
            Contracts.Structure.IssuePolicyResult result = new Contracts.Structure.IssuePolicyResult();
            int orignalStatus = item.Status;

            item = Business.Policy.Risk.Setup(item, tokenInfo.CompanyId);
            result.Errors = Business.Policy.Risk.PolicyStorage(item, orignalStatus, tokenInfo, "Modify");

            if (result.Errors.Count == 0)
                item = Business.Policy.Risk.UpdatePolicy(item, tokenInfo.UserId, tokenInfo.CompanyId, "Modify");

            result.Risk = item;
            return result;
        }

        public static Utilities.Contracts.LookUpValue RetrieveByDocumentNumber(int companyId, string productAlias, int recordId, int documentType, string documentNumber)
        {
            Architect.API.Core.Contracts.General.Lookup prodInfo = Core.Business.Common.LkpChildFullByExtendStringValue1("ProductByLineOfBusiness", productAlias, companyId).FirstOrDefault();
            return RetrieveByDocumentNumber(companyId, prodInfo.ParentLookupId, prodInfo.Code, recordId, documentType, documentNumber);
        }

        public static Utilities.Contracts.LookUpValue RetrieveByDocumentNumber(int companyId, int lineOfBusinessCode, int productCode, int recordId, int documentType, string documentNumber)
        {
            Utilities.Contracts.LookUpValue result = null;
            if (lineOfBusinessCode == 1 && productCode == 2)
            {
                result = Architect.API.Insurance.DataAccess.Policy.Risk.RetrieveByDocumentNumber(companyId, lineOfBusinessCode, productCode, recordId, documentType, documentNumber);
            }
            return result;
        }

        /// <summary>
        /// Lista de pólizas existen según los criterio definidos en los filtros.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Permite filtrar por póliza o por la identificación, nombre, apellido, teléfono o correo electrónico del asegurado.</param>
        /// <param name="lineOfBusiness">Opción para filtrar por ramo o linea de negocio.</param>
        /// <param name="product">Opción para filtrar por producto vinculado a un ramo.</param>
        /// <param name="status">Opción para filtrar por múltiples esta de las pólizas.</param>
        /// <returns>Lista de pólizas según los criterio definidos en el filtro.</returns>
        public static List<Contracts.Policy.PolicyView> View(int companyId, string filter, int lineOfBusiness, int product, string status)
        {
            return DataAccess.Policy.Risk.RetrieveView(companyId, filter, lineOfBusiness, product, status);
        }

        /// <summary>
        /// Información completa de una póliza.
        /// </summary>
        /// <param name="id">Identificación interna de una póliza.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <returns>Información de una póliza</returns>
        public static Contracts.Policy.Risk RetrievePolicyByKey(int id, int companyId)
        {
            Contracts.Policy.Risk result = DataAccess.Policy.Risk.RetrieveByKey(id, companyId);
            if (result.IsNotEmpty())
            {
                List<Contracts.Policy.RiskRoles> roles = DataAccess.Policy.RiskRoles.RetrieveByPolicyIdCompanyId(id, companyId);
                result.PrimaryInsured = roles.Find(r => r.Type == 2);
                result.Beneficiaries = roles.FindAll(r => r.Type != 2);

                if (result.Beneficiaries.Count > 0)
                {
                    List<Core.Contracts.General.LookupValue> values = Core.Business.Common.Lkp("Relationship", companyId);

                    foreach (Contracts.Policy.RiskRoles RItem in result.Beneficiaries)
                        RItem.RelationshipDesc = values.Find(x => x.Code == RItem.Relationship.ToString()).Description;
                }

                result.Overdraft = DataAccess.Policy.RiskOverdraft.Retrieve(id, companyId);
                result.Questionary = RiskQuestionnaires.RetrieveByPolicyId(id, companyId);
                result.StatusDesc = Core.Business.Common.Lkp("PolicyStatus", companyId).Find(x => x.Code == result.Status.ToString()).Description;

                if (result.LineOfBusinessCode.IsNotEmpty() && result.ProductCode.IsNotEmpty())
                {
                    result.ProductAlias = Core.Business.Common.LkpChildFull("ProductByLineOfBusiness", result.LineOfBusinessCode, companyId).Find(x => x.Code == result.ProductCode).ExtendStringValue1;
                }
            }
            return result;
        }

        /// <summary>
        /// Valida la información de una póliza para permitir o no su emisión.
        /// </summary>
        /// <param name="source">Datos de la póliza</param>
        /// <param name="tokenInfo">Contexto del usuario conectado.</param>
        /// <returns></returns>
        public static List<Core.Contracts.General.Error> Validate(Contracts.Policy.Risk source, Core.Contracts.Security.Token tokenInfo)
        {
            const string group = "Risk";

            List<Core.Contracts.General.Error> result = Reglas.research.Apply_Reglas("policy", source, tokenInfo);

            //LineOfBusinessCode:
            if (source.LineOfBusinessCode.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "LineOfBusinessCode", Message = "Debe indicar el ramo para la póliza" });

            //ProductCode:
            if (source.Currency.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "ProductCode", Message = "Debe indicar el producto para la póliza" });

            //Currency:
            if (source.Currency.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Currency", Message = "Debe indicar una moneda para la póliza" });

            //ModuleCode:
            if (source.ModuleCode.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "ModuleCode", Message = "Debe indicar un plan para la póliza" });

            //PaymentFrequency:
            if (source.PaymentFrequency.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "PaymentFrequency", Message = "Debe indicar una frecuencia de pago para la póliza" });

            //IssueDate:
            if (source.IssueDate.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "IssueDate", Message = "Debe indicar la fecha de alta para la póliza" });

            //EffectiveDate:
            if (source.EffectiveDate.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "EffectiveDate", Message = "Debe indicar el inicio de vigencia para la póliza" });

            //EndingDate:
            if (source.EndingDate.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "EndingDate", Message = "Debe indicar el fin de vigencia para la póliza" });

            //InsuredAmount:
            if (source.InsuredAmount.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "InsuredAmount", Message = "Debe indicar la suma asegurada para la póliza" });

            //AnnualPremium:
            if (source.InsuredAmount.IsNotEmpty() && source.AnnualPremium.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "AnnualPremium", Message = "Debe indicar la prima anual para la póliza" });

            // Se valida la información del asegurado principal.
            if (source.PrimaryInsured.IsNotEmpty())
                result.AddRange(RiskRoles.Validate(source.PrimaryInsured, "PrimaryInsured", tokenInfo.CompanyId, source));

            // Se valida la información del cuestionario
            if (source.RestrictionLevel > 1 && (Products.Specification.EntryAllow(source.ProductAlias, "Questionnaires") || Products.Specification.EntryAllow(source.ProductAlias, "Covid")))
                result.AddRange(RiskQuestionnaires.Validate(source.Questionary, source, tokenInfo.CompanyId));

            // Si esta permitida, se valida la información del préstamo.
            if (Products.Specification.EntryAllow(source.ProductAlias, "Overdraft") && source.Overdraft.IsNotEmpty())
            {
                result.AddRange(RiskOverdraft.Validate(source.Overdraft));
                if (Rule_InsuredAmountAndOverDraftAmount_Greater_MaximumInsuredAmount(source, source.Overdraft))
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "InsuredAmount", Message = "La suma asegurada más el total de los montos de préstamos, esta fuera del rango permitido según el plan" });
            }

            // Si esta permitida, se valida la información de los beneficiarios
            if (Products.Specification.EntryAllow(source.ProductAlias, "Beneficiaries"))
            {
                result.AddRange(RiskBeneficiary.Validate(source.Beneficiaries, tokenInfo.CompanyId, source));
            }

            return result;
        }

        /// <summary>
        /// Aplica las reglas de suscripción de forma automática para determina si es necesario o no hacer la revisión de la póliza.
        /// </summary>
        /// <returns>Verdadero en caso de necesitar suscripción, falso en el caso contrario</returns>
        internal static bool Rule_Underwriting(Contracts.Policy.Risk riskToBeEvaluated, Core.Contracts.Security.Token tokenInfo)
        {
            return riskToBeEvaluated.Behavior.Contains("Mode.Underwriting");
        }

        /// <summary>
        /// Verifica si la suma asegura más el total de los monto de los prestamos este en el máximo permitido según el plan
        /// </summary>
        /// <param name="risk">Información de la póliza</param>
        /// <param name="overdraft">Información del préstamo</param>
        /// <returns>Verdadero si el total sobre pasa el máximo permitido según el plan, falso en el caso contrario</returns>
        private static bool Rule_InsuredAmountAndOverDraftAmount_Greater_MaximumInsuredAmount(Contracts.Policy.Risk risk, Contracts.Policy.RiskOverdraft overdraft)
        {
            bool result = false;
            double amount = risk.InsuredAmount;

            if (!overdraft.Recast1)
            {
                amount += overdraft.Amount1;

            }
            if (!overdraft.Recast2)
            {
                amount += overdraft.Amount2;

            }
            if (!overdraft.Recast3)
            {
                amount += overdraft.Amount3;

            }
            if (!overdraft.Recast4)
            {
                amount += overdraft.Amount4;

            }
            if (!overdraft.Recast5)
            {
                amount += overdraft.Amount5;

            }

            if (amount.IsNotEmpty())
            {
                Contracts.Product.ProductDefinition product = Products.Specification.DefinitionByAlias(risk.ProductAlias);
                if (product.IsNotEmpty())
                {
                    Contracts.Product.LookupModules moduleInfo = (from r in product.Modules where r.Code == risk.ModuleCode select r).FirstOrDefault();
                    result = (moduleInfo.IsNotEmpty() && (decimal)amount > moduleInfo.MaximumInsuredAmount);
                }
            }

            return result;
        }

        private static List<Contracts.Policy.RiskRoles> SynchronizeBeneficiaries(List<Contracts.Policy.RiskRoles> currentList, List<Contracts.Policy.RiskRoles> newList, int companyId, int userId, int policyId)
        {
            Contracts.Policy.RiskRoles toAdd = null;

            if (currentList == null)
                currentList = new List<Contracts.Policy.RiskRoles>();

            //Agrega un nuevo beneficiario o cambia uno existente
            if (newList?.Count > 0)
            {
                foreach (Contracts.Policy.RiskRoles newItem in newList)
                {
                    // if (newItem.RoleId.IsNotEmpty())
                    toAdd = currentList.Find(r => r.DocumentNumber == newItem.DocumentNumber);

                    if (toAdd.IsEmpty())
                    {
                        toAdd = new Contracts.Policy.RiskRoles();
                        currentList.Add(toAdd);
                    }
                    toAdd = Business.Policy.RiskRoles.Mapper(toAdd, newItem);

                    toAdd.CompanyId = companyId;
                    toAdd.UpdateUserCode = userId;
                    toAdd.UpdateDate = DateTime.Now;

                    toAdd.PolicyId = policyId;
                    if (toAdd.Type == 0)
                    {
                        toAdd.Type = 100;
                    }
                    if (toAdd.InclusionDate.IsEmpty())
                        toAdd.InclusionDate = DateTime.Now;
                    if (toAdd.RoleId.IsEmpty())
                    {
                        toAdd.RoleId = DataAccess.Policy.RiskRoles.RetrieveLastKey() + 1;
                        DataAccess.Policy.RiskRoles.Create(toAdd);
                    }
                    else
                    {
                        DataAccess.Policy.RiskRoles.Update(toAdd);
                    }
                }
            }
            //Elimina un beneficiario existente
            if (currentList?.Count > 0 && newList?.Count > 0)
            {
                foreach (Contracts.Policy.RiskRoles curentRole in currentList)
                {
                    if (newList.Find(r => r.DocumentNumber == curentRole.DocumentNumber).IsEmpty())
                    {
                        DataAccess.Policy.RiskRoles.Delete(curentRole.RoleId, companyId);
                    }
                }
            }
            return currentList;
        }

        private static List<Core.Contracts.General.Error> PolicyStorage(Contracts.Policy.Risk item, int status, Core.Contracts.Security.Token tokenInfo, string source)
        {
            item.CompanyId = tokenInfo.CompanyId;
            item.Behavior = Reglas.research.Apply_Comportamientos("policy", item, tokenInfo);
            List<Core.Contracts.General.Error> errors = Business.Policy.Risk.Validate(item, tokenInfo);

            if (status == (int)Enumerations.PolicyStatus.InForce && errors.Count == 0 && source != "Modify")
            {
                Architect.Insurance.Contracts.Policy.Risk rk = Business.Policy.Rating.Asegurado(item.ProductAlias, item.Currency, item.ModuleCode, item.PaymentFrequency, item.InsuredAmount, item.PrimaryInsured.BirthDate);
                if (rk.Notify == null || rk.Notify.Count == 0)
                {
                    if (item.Undewriting == "enabled" && Rule_Underwriting(item, tokenInfo))
                    {
                        if (item.Id.IsEmpty())
                            item.Id = DataAccess.Policy.Risk.RetrieveLastKey() + 1;
                        item.Status = (int)Enumerations.PolicyStatus.InReview;

                        Notify.InReviewStatus(item, tokenInfo.CompanyId, tokenInfo.UserId, Enumerations.PolicyStatus.InReview);
                    }
                    else
                    {
                        item.PolicyId = DataAccess.Policy.Risk.RetrieveLastPolicyId(tokenInfo.CompanyId) + 1;
                        item.Status = status;

                        if (Products.Specification.SettingBoolValue(item.ProductAlias, "Allow.DigitalSign"))
                        {
                            item.Status = (int)Enumerations.PolicyStatus.PendingBySignature;
                            if (!DigitalSignature.Submit(item, tokenInfo, true))
                            {
                                item.Status = status;
                                errors = new List<Core.Contracts.General.Error>() {
                                    new Core.Contracts.General.Error() {
                                        Group="DigitalSignFail"
                                    } };
                            };
                        }
                    }
                }
            }

            return errors;
        }



        private static Contracts.Policy.Risk Setup(Contracts.Policy.Risk item, int companyId)
        {
            Architect.API.Core.Contracts.General.Lookup prodInfo = Core.Business.Common.LkpChildFullByExtendStringValue1("ProductByLineOfBusiness", item.ProductAlias, companyId).FirstOrDefault();

            item.LineOfBusinessCode = prodInfo.ParentLookupId;
            item.ProductCode = prodInfo.Code;
            item.PolicyId = 0;
            if (item.Status.IsEmpty())
                item.Status = 1;

            if (item.PrimaryInsured.IsNotEmpty())
            {
                item.PrimaryInsured.Type = 2;
            }

            if (item.Beneficiaries.IsNotEmpty())
            {
                foreach (Contracts.Policy.RiskRoles BItem in item.Beneficiaries)
                {
                    BItem.PolicyId = item.Id;
                    BItem.Type = 100;
                    if (BItem.InclusionDate.IsEmpty())
                        BItem.InclusionDate = DateTime.Now;
                }
            }

            if (item.Questionary.IsNotEmpty())
            {
                foreach (Contracts.Policy.RiskQuestionnaires QItem in item.Questionary)
                {
                    QItem.Type = 1;
                }
            }

            return item;
        }

        internal static Contracts.Policy.Risk CreatePolicy(Contracts.Policy.Risk item, int userId, int companyId)
        {
            if (item.Id.IsEmpty())
                item.Id = DataAccess.Policy.Risk.RetrieveLastKey() + 1;
            item.CompanyId = companyId;
            item.UpdateUserCode = userId;
            item.UpdateDate = DateTime.Now;

            DataAccess.Policy.Risk.Create(item);
            if (item.PrimaryInsured.IsNotEmpty())
            {
                item.PrimaryInsured.RoleId = DataAccess.Policy.RiskRoles.RetrieveLastKey() + 1;
                item.PrimaryInsured.Type = 2;
                item.PrimaryInsured.PolicyId = item.Id;
                item.PrimaryInsured.CompanyId = companyId;
                item.PrimaryInsured.UpdateUserCode = userId;
                item.PrimaryInsured.UpdateDate = DateTime.Now;
                DataAccess.Policy.RiskRoles.Create(item.PrimaryInsured);
            }

            //Beneficiarios
            item.Beneficiaries = SynchronizeBeneficiaries(null, item.Beneficiaries, companyId, userId, item.Id);
            //if (item.Beneficiaries.IsNotEmpty())
            //{
            //    Contracts.Policy.RiskRoles toAdd = null;
            //    foreach (Contracts.Policy.RiskRoles BItem in item.Beneficiaries)
            //    {
            //        toAdd = BItem;
            //        if (toAdd.RoleId.IsEmpty())
            //            toAdd.RoleId = DataAccess.Policy.RiskRoles.RetrieveLastKey() + 1;
            //        toAdd.CompanyId = companyId;
            //        toAdd.UpdateUserCode = userId;
            //        toAdd.UpdateDate = DateTime.Now;

            //        toAdd.PolicyId = item.Id;
            //        toAdd.Type = 100;
            //        if (toAdd.InclusionDate.IsEmpty())
            //            toAdd.InclusionDate = DateTime.Now;

            //        DataAccess.Policy.RiskRoles.Create(toAdd);
            //    }
            //}

            if (item.Questionary.IsNotEmpty())
            {
                foreach (Contracts.Policy.RiskQuestionnaires QItem in item.Questionary)
                {
                    QItem.Id = DataAccess.Policy.RiskQuestionnaires.RetrieveLastKey() + 1;
                    QItem.PolicyId = item.Id;
                    QItem.CompanyId = companyId;
                    QItem.UpdateUserCode = userId;
                    QItem.UpdateDate = DateTime.Now;
                    DataAccess.Policy.RiskQuestionnaires.Create(QItem);
                }
            }

            if (item.Overdraft.IsNotEmpty())
            {
                item.Overdraft.Id = item.Id;
                item.Overdraft.CompanyId = companyId;
                item.Overdraft.UpdateUserCode = userId;
                item.Overdraft.UpdateDate = DateTime.Now;
                DataAccess.Policy.RiskOverdraft.Create(item.Overdraft);
            }

            if (item.Attachments.IsNotEmpty())
            {
                Core.Business.General.Attachment.SyncUp(2000, item.Id, companyId, item.Attachments, userId);
            }

            item.StatusDesc = Core.Business.Common.Lkp("PolicyStatus", companyId).Find(x => x.Code == item.Status.ToString()).Description;

            if (item.Status == 1)
                Core.Business.General.ChangeSet.Create(2000, item.Id, companyId, "Borrador", "Creación", userId, item);
            else
                Core.Business.General.ChangeSet.Create(2000, item.Id, companyId, item.StatusDesc, null, userId, item);

            return item;
        }

        internal static Contracts.Policy.Risk UpdatePolicy(Contracts.Policy.Risk item, int userId, int companyId, string source)
        {
            Contracts.Policy.Risk result = Risk.RetrievePolicyByKey(item.Id, companyId);

            if (result.Status != 5)
            {
                result = Business.Policy.Risk.Mapper(result, item);
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                DataAccess.Policy.Risk.Update(result);
                if (result.PrimaryInsured.IsNotEmpty())
                {
                    result.PrimaryInsured = Business.Policy.RiskRoles.Mapper(result.PrimaryInsured, item.PrimaryInsured);
                    result.PrimaryInsured.CompanyId = companyId;
                    result.PrimaryInsured.UpdateUserCode = userId;
                    result.PrimaryInsured.UpdateDate = DateTime.Now;
                    DataAccess.Policy.RiskRoles.Update(result.PrimaryInsured);
                }

                //Beneficiarios
                result.Beneficiaries = SynchronizeBeneficiaries(result.Beneficiaries, item.Beneficiaries, companyId, userId, item.Id);

                if (result.Questionary.IsNotEmpty() && result.Questionary.Count > 0)
                {
                    int countUpd = item.Questionary.Count;
                    int countCurr = result.Questionary.Count;
                    int countMax = countUpd > countCurr ? countUpd : countCurr;
                    for (int index = 0; index < countMax; index++)
                    {
                        if (index < countCurr)
                        {
                            result.Questionary[index] = Business.Policy.RiskQuestionnaires.Mapper(result.Questionary[index], item.Questionary[index]);
                            result.Questionary[index].CompanyId = companyId;
                            result.Questionary[index].UpdateUserCode = userId;
                            result.Questionary[index].UpdateDate = DateTime.Now;
                            DataAccess.Policy.RiskQuestionnaires.Update(result.Questionary[index]);
                        }
                        else
                        {
                            item.Questionary[index].Id = DataAccess.Policy.RiskQuestionnaires.RetrieveLastKey() + 1;
                            item.Questionary[index].PolicyId = item.Id;
                            item.Questionary[index].CompanyId = companyId;
                            item.Questionary[index].UpdateUserCode = userId;
                            item.Questionary[index].UpdateDate = DateTime.Now;
                            DataAccess.Policy.RiskQuestionnaires.Create(item.Questionary[index]);
                        }
                    }
                }
                if (result.Overdraft.IsNotEmpty())
                {
                    result.Overdraft = Business.Policy.RiskOverdraft.Mapper(result.Overdraft, item.Overdraft);
                    result.Overdraft.CompanyId = companyId;
                    result.Overdraft.UpdateUserCode = userId;
                    result.Overdraft.UpdateDate = DateTime.Now;
                    DataAccess.Policy.RiskOverdraft.Update(result.Overdraft);
                }

                if (item.Attachments.IsNotEmpty())
                {
                    Core.Business.General.Attachment.SyncUp(2000, item.Id, companyId, item.Attachments, userId);
                }

                result.StatusDesc = Core.Business.Common.Lkp("PolicyStatus", companyId).Find(x => x.Code == result.Status.ToString()).Description;

                if (result.Status == 1)
                {
                    Core.Business.General.ChangeSet.Create(2000, result.Id, companyId, "Borrador", "Actualización", userId, result);
                }
                else
                {
                    if (source == "Modify")
                    {
                        Core.Business.General.ChangeSet.Create(2000, result.Id, companyId, "Modificación", "", userId, result);
                    }
                    else
                    {
                        Core.Business.General.ChangeSet.Create(2000, result.Id, companyId, result.StatusDesc, "", userId, result);
                    }
                }
            }
            else
            {
                if (item.Attachments.IsNotEmpty())
                {
                    Core.Business.General.Attachment.SyncUp(2000, item.Id, companyId, item.Attachments, userId);
                }
            }
            return result;
        }

        public static Contracts.Structure.BehaviorResult Behavior(Core.Contracts.Security.Token tokenInfo, Contracts.Policy.Risk item)
        {
            item.CompanyId = tokenInfo.CompanyId;
            item.Behavior = Reglas.research.Apply_Comportamientos("policy", item, tokenInfo);
            List<Core.Contracts.General.Error> errors = null; // Business.Policy.Risk.Validate(item, tokenInfo);
            return new Contracts.Structure.BehaviorResult() { Behavior = item.Behavior, Errors = errors };
        }

        public static Contracts.Product.ProductDefinition DefinitionByAlias(string productAlias)
        {
            Contracts.Product.ProductDefinition result = Business.Products.Specification.DefinitionByAlias(productAlias);
            result.Behavior = Reglas.research.JSCode_Comportamientos("policy");
            return result;
        }
    }
}
