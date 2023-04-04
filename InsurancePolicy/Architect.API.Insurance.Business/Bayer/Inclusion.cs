using Architect.API.Insurance.Contracts.Policy;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Architect.API.Insurance.Business.Bayer
{
    /// <summary>
    /// Procesamiento de las solicitudes de inclusión
    /// </summary>
    public static partial class Inclusion
    {

        /// <summary>
        /// Verifica que la firma electrónica de un PDF corresponda con el número de documento de identificación del usuario responsable.
        /// </summary>
        public static bool VerifySignature(int id, string fileName, int size, string originalFileName, Core.Contracts.Security.Token tokenInfo)
        {
            string fullFileName = Path.Combine(ConfigurationManager.AppSettings["Attachments.Path"], fileName);
            bool result = false;
            string serialNumber = Architect.PDF.Integrations.Signature.SerialNumber(fullFileName);
            if (serialNumber.IsNotEmpty())
            {
                Contracts.Bayer.InclusionRequest request = Retrieve(id, tokenInfo);
                result = request.DocumentNumber.OnlyNumbers() == serialNumber.OnlyNumbers();
                if (result)
                {
                    Core.Contracts.General.Attachments attachment = new Core.Contracts.General.Attachments
                    {
                        EntityType = 2000,
                        EntityId = id,
                        CompanyId = tokenInfo.CompanyId,
                        UpdateUserCode = tokenInfo.UserId,
                        DocumentType = 4001,
                        Description = "Solicitud con firma digital",
                        FileName = originalFileName,
                        FileSize = size,
                        FileContent = fullFileName
                    };
                    Core.Business.General.Attachment.SyncUp(attachment);

                    Signed(tokenInfo.CompanyId, id);
                }
            }
            return result;
        }

        /// <summary>
        /// Verificar si las inclusiones pendiente por firma, ya fueron procesadas.
        /// </summary>
        public static void EvicertiaSigned()
        {
            try
            {
                DocuSign.Integrations.Contracts.QueryResult eviSignInf = null;

                foreach (string companyIdForReview in ConfigurationManager.AppSettings["Evicertia.Request.Company.Review"].ToString().Split(','))
                {
                    int companyId = Convert.ToInt32(companyIdForReview);
                    Utilities.Log.TraceLog("Bayer.Inclusion.EvicertiaSigned", string.Format("{0} CompanyId {1}", DateTime.Now.ToString(), companyId), "Evicertia");

                    foreach (Utilities.Contracts.LookUpValue item in DataAccess.Policy.Risk.RetrieveByStatus(companyId, 4))
                    {
                        eviSignInf = DocuSign.Integrations.DocuSign.Query(item.Description).GetAwaiter().GetResult();
                        if (eviSignInf != null)
                        {
                            Utilities.Log.TraceLog(" Bayer.Inclusion.EvicertiaSigned", item.Description + " outcome " + eviSignInf.outcome, "Evicertia");
                            switch (eviSignInf.outcome)
                            {
                                case "Signed":
                                    Signed(companyId, Convert.ToInt32(item.Code));
                                    break;
                                case "None":
                                    break;
                                case "Expired":
                                    Expired(companyId, Convert.ToInt32(item.Code));
                                    break;
                                case "Rejected":
                                    Rejected(companyId, Convert.ToInt32(item.Code));
                                    break;
                            }
                        }
                        else
                        {
                            Utilities.Log.TraceLog(" Bayer.Inclusion.EvicertiaSigned", item.Description + " not outcome", "Evicertia");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Bayer.Inclusion.EvicertiaSigned", "EvicertiaSigned", ex);
                throw ex;
            }
        }

        /// <summary>
        /// Procesa una inclusión como firmada.
        /// </summary>
        private static void Signed(int companyId, int id)
        {
            Risk risk = Policy.Risk.RetrievePolicyByKey(id, companyId);
            risk.Bayer = DataAccess.Policy.RiskBayer.Retrieve(id, companyId);
            risk.LineOfBusinessDesc = Core.Business.Common.LkpDescription(companyId, "LineOfBusiness", risk.LineOfBusinessCode.ToString());
            risk.Status = (int)Enumerations.PolicyStatus.InForce;
            DataAccess.Policy.Risk.Update(risk);
            Core.Business.General.ChangeSet.Create(2000, risk.Id, companyId, "Aceptada", null, risk.ExecutiveUserCode, risk);
            int medicalId = DataAccess.Others.Inclusiones.Create(
                                InclusionToMedical(
                                    Retrieve(risk.Id, new Core.Contracts.Security.Token() { CompanyId = companyId }), companyId), 1);
            risk.Annotation = medicalId.ToString();
            DataAccess.Policy.Risk.Update(risk);
            Core.Business.General.Mail.SendByTemplate("Notify_InclusionInMedical", companyId, risk.ExecutiveUserCode, risk.ExecutiveUserCode, risk);
        }

        /// <summary>
        /// Procesa una inclusión como expirada.
        /// </summary>
        private static void Expired(int companyId, int id)
        {
            Risk risk = Policy.Risk.RetrievePolicyByKey(id, companyId);
            risk.Bayer = DataAccess.Policy.RiskBayer.Retrieve(id, companyId);
            risk.LineOfBusinessDesc = Core.Business.Common.LkpDescription(companyId, "LineOfBusiness", risk.LineOfBusinessCode.ToString());
            risk.Status = (int)Enumerations.PolicyStatus.DeclinedDuToSignatureExpiration;
            DataAccess.Policy.Risk.Update(risk);
            Core.Business.General.ChangeSet.Create(2000, risk.Id, companyId, "Declinada por expiracíon", null, risk.ExecutiveUserCode, risk);
            Core.Business.General.Mail.SendByTemplate("Notify_RequestOnTimeOutDeclined", companyId, risk.ExecutiveUserCode, risk.ExecutiveUserCode, risk);
        }

        /// <summary>
        /// Procesa una inclusión como rechazada.
        /// </summary>
        private static void Rejected(int companyId, int id)
        {
            Risk risk = Policy.Risk.RetrievePolicyByKey(id, companyId);
            risk.Bayer = DataAccess.Policy.RiskBayer.Retrieve(id, companyId);
            risk.LineOfBusinessDesc = Core.Business.Common.LkpDescription(companyId, "LineOfBusiness", risk.LineOfBusinessCode.ToString());
            risk.Status = (int)Enumerations.PolicyStatus.RejectedBySigner;
            DataAccess.Policy.Risk.Update(risk);
            Core.Business.General.ChangeSet.Create(2000, risk.Id, companyId, "Rechazada", null, risk.ExecutiveUserCode, risk);
            Core.Business.General.Mail.SendByTemplate("Notify_RequestOnUserDeclined", companyId, risk.ExecutiveUserCode, risk.ExecutiveUserCode, risk);
        }

        /// <summary>
        /// Devuelve una lista inclusiones para un rango de identificaciones.
        /// </summary>
        public static List<Contracts.Bayer.InclusionView> View(int companyId, int idFrom, int idTo)
        {
            return DataAccess.Others.Inclusiones.RetrieveInclusionViewById(companyId, idFrom, idTo);
        }

        /// <summary>
        /// Devuelve una lista inclusiones para un rango de fecha de ingreso.
        /// </summary>
        public static List<Contracts.Bayer.InclusionView> View(int companyId, DateTime issueDateFrom, DateTime issueDateTo)
        {
            return DataAccess.Others.Inclusiones.RetrieveInclusionViewByIssueDate(companyId, issueDateFrom, issueDateTo);
        }

        /// <summary>
        /// Define valores por default o en caso de que ya exista una planilla para el usuario devuelve su respectiva información.
        /// </summary>
        public static Contracts.Bayer.InclusionRequest Setup(Core.Contracts.Security.Token tokenInfo)
        {
            int id = 0;
            Contracts.Bayer.InclusionRequest result = new Contracts.Bayer.InclusionRequest()
            {
                IssueDate = DateTime.Today
            };

            id = DataAccess.Policy.Risk.RetrieveLastIdByExecutiveUserCode(tokenInfo.CompanyId, tokenInfo.UserId);
            if (id > 0)
            {
                result = Retrieve(id, tokenInfo);

                //Architect.API.Insurance.DataAccess.Others.Inclusiones.Create(InclusionToMedical(result), 1);

            }
            else
            {
                Architect.API.Core.Contracts.Security.UserMember currentUserInfo = Core.Business.Security.UserMember.RetrieveById(tokenInfo.CompanyId, tokenInfo.UserId);
                if (currentUserInfo.IsNotEmpty())
                {
                    result.DocumentType = currentUserInfo.IdentificationType;
                    result.DocumentNumber = currentUserInfo.Identification;
                    result.FirstName = currentUserInfo.FirstName;
                    result.LastName = currentUserInfo.LastName;
                    result.BirthDate = currentUserInfo.BirthDate;
                    result.PhoneNumber = currentUserInfo.PhoneNumber;
                    result.PrimaryEmailAddress = currentUserInfo.EMail;
                }
            }

            return result;
        }

        /// <summary>
        /// Recupera la informacion de una planilla por su identificación.
        /// </summary>
        public static Contracts.Bayer.InclusionRequest Retrieve(int id, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Bayer.InclusionRequest result = null;
            Contracts.Policy.Risk risk = Policy.Risk.RetrievePolicyByKey(id, tokenInfo.CompanyId);
            if (risk.IsNotEmpty())
            {
                result = Convertions.RiskToInclusion(risk);
                result.CompanyId = tokenInfo.CompanyId;
                if (risk.PrimaryInsured.IsNotEmpty())
                {
                    result = Convertions.PrimaryInsuredToInclusion(risk, result);
                }

                result.beneficiarios = Convertions.BeneficiaryToInclusion(risk.Beneficiaries);
                result.Dependientes = Convertions.DependencyToInclusion(risk.Beneficiaries);

                Contracts.Policy.RiskBayer riskBayer = DataAccess.Policy.RiskBayer.Retrieve(id, tokenInfo.CompanyId);
                if (riskBayer.IsNotEmpty())
                {
                    result = Convertions.RiskBayerToInclusion(riskBayer, result);
                }
                if (string.Format(",{0},", tokenInfo.Roles).Contains(",Revisor,"))
                {
                    result.Mode = "Review";
                }
                result = MapLookups(tokenInfo.CompanyId, result);
            }
            return result;
        }

        /// <summary>
        /// Busca y asigna las descripciones de los campos asoiados a lista de valores.
        /// </summary>
        private static Contracts.Bayer.InclusionRequest MapLookups(int companyId, Contracts.Bayer.InclusionRequest item)
        {
            if (item.IsEmpty())
            {
                return item;
            }
            Contracts.Bayer.InclusionRequest result = item;
            if (result.ContractorName.IsNotEmpty())
                result.ContractorDesc = Core.Business.Common.LkpDescription(companyId, "BayerPolizas", result.ContractorName.ToString());
            if (result.Gender.IsNotEmpty())
                result.GenderDesc = Core.Business.Common.LkpDescription(companyId, "Gender", result.Gender.ToString());
            if (result.CountryOfNationality.IsNotEmpty())
                result.CountryOfNationalityDesc = Core.Business.Common.LkpDescription(companyId, "Pais", result.CountryOfNationality.ToString());
            if (result.CivilStatus.IsNotEmpty())
                result.CivilStatusDesc = Core.Business.Common.LkpDescription(companyId, "CivilStatus", result.CivilStatus.ToString());
            if (result.RefundBankCode.IsNotEmpty())
                result.RefundBankDesc = Core.Business.Common.LkpDescription(companyId, "CR_Bancos", result.RefundBankCode.ToString());
            if (result.Province.IsNotEmpty())
                result.ProvinceDesc = Core.Business.Common.LkpDescription(companyId, "CR_Provincia", result.Province.ToString());
            if (result.Province.IsNotEmpty() && result.Canton.IsNotEmpty())
                result.CantonDesc = Core.Business.Common.LkpDescription(companyId, "CR_Canton", result.Province, result.Canton.ToString());
            if (result.Canton.IsNotEmpty() && result.District.IsNotEmpty())
                result.DistrictDesc = Core.Business.Common.LkpDescription(companyId, "CR_Distritos", result.Canton, result.District.ToString());

            if (result.beneficiarios != null)
            {
                foreach (var bItem in result.beneficiarios)
                {
                    if (bItem.BRelationship.IsNotEmpty())
                        bItem.BRelationshipDesc = Core.Business.Common.LkpDescription(companyId, "Relationship", bItem.BRelationship.ToString());
                }
            }
            if (result.Dependientes != null)
            {
                foreach (var dItem in result.Dependientes)
                {
                    if (dItem.DRelationship.IsNotEmpty())
                        dItem.DRelationshipDesc = Core.Business.Common.LkpDescription(companyId, "DirectRelationship", dItem.DRelationship.ToString());
                }
            }

            return result;
        }

        /// <summary>
        /// Almacena o actualiza la información de una planilla.
        /// </summary>
        public static Contracts.Bayer.InclusionRequest Issue(Contracts.Bayer.InclusionRequest inclusionInfo, Core.Contracts.Security.Token tokenInfo)
        {
            inclusionInfo.Errors = Validate(inclusionInfo);
            if (inclusionInfo.Errors.Count == 0)
            {
                Contracts.Policy.Risk risk = Convertions.InclusionToRisk(inclusionInfo);
                risk.ExecutiveUserCode = tokenInfo.UserId;
                risk.BranchOffice = tokenInfo.BranchOffice;

                switch (inclusionInfo.Mode)
                {
                    case "draft":
                        risk.Status = 1;
                        break;
                    case "send":
                        risk.Status = 2;
                        break;
                    case "back":
                        risk.Comments = inclusionInfo.Message;
                        risk.Status = 1;

                        Core.Business.General.Notes.CreateOrUpdate(tokenInfo.CompanyId,
                                                                   tokenInfo.UserId,
                                                                   new Core.Contracts.General.Notes()
                                                                   {
                                                                       EntityType = 2000,
                                                                       EntityId = risk.Id,
                                                                       Note = inclusionInfo.Message,
                                                                       NoteOwnerId = tokenInfo.UserId
                                                                   });

                        break;
                    case "revised":
                        risk.Status = 4;
                        break;

                }
                risk.PrimaryInsured = Convertions.InclusionToPrimaryInsured(inclusionInfo);

                Contracts.Policy.RiskRoles newRole = null;

                if (inclusionInfo.beneficiarios != null)
                {
                    risk.Beneficiaries = new List<Contracts.Policy.RiskRoles>();
                    foreach (Contracts.Bayer.Beneficiario beneficiario in inclusionInfo.beneficiarios)
                    {
                        newRole = Convertions.InclusionToBeneficiary(beneficiario);
                        risk.Beneficiaries.Add(newRole);
                    }
                }
                if (inclusionInfo.Dependientes != null)
                {
                    if (risk.Beneficiaries == null)
                    {
                        risk.Beneficiaries = new List<Contracts.Policy.RiskRoles>();
                    }
                    foreach (Contracts.Bayer.Dependiente dependiente in inclusionInfo.Dependientes)
                    {
                        newRole = Convertions.InclusionToDependiente(dependiente);
                        risk.Beneficiaries.Add(newRole);
                    }
                }



                if (risk.Id.IsEmpty())
                    risk = Policy.Risk.CreatePolicy(risk, tokenInfo.UserId, tokenInfo.CompanyId);
                else
                    risk = Policy.Risk.UpdatePolicy(risk, tokenInfo.UserId, tokenInfo.CompanyId, string.Empty);

                risk.Bayer = Convertions.InclusionToRiskBayer(tokenInfo.CompanyId, inclusionInfo);
                risk.Bayer.Id = risk.Id;
                risk.Bayer.CompanyId = risk.CompanyId;
                risk.Bayer.UpdateUserCode = risk.UpdateUserCode;
                risk.Bayer.UpdateDate = risk.UpdateDate;
                if (risk.Id.IsNotEmpty())
                {
                    if (inclusionInfo.Id.IsEmpty())
                    {
                        DataAccess.Policy.RiskBayer.Create(risk.Bayer);
                    }
                    else
                    {
                        DataAccess.Policy.RiskBayer.Update(risk.Bayer);
                    }
                }
                inclusionInfo.Id = risk.Id;
                inclusionInfo.Status = risk.Status;
                inclusionInfo.StatusDesc = risk.StatusDesc;

                if (inclusionInfo.Errors.Count > 0)
                {
                    inclusionInfo.Message = string.Format("No se puede realizar la inclusión ya que existen {0} error(es) que ameritan su atención",
                                            inclusionInfo.Errors.Count);
                }
                else
                {
                    risk.LineOfBusinessDesc = Core.Business.Common.LkpDescription(risk.CompanyId, "LineOfBusiness", risk.LineOfBusinessCode.ToString());

                    switch (inclusionInfo.Status)
                    {
                        case 1:
                            if (inclusionInfo.Mode == "back")
                            {
                                inclusionInfo.Message = "La inclusión fue rechaza, se envió una notificación para que se proceda a su revisión";
                                Core.Business.General.Mail.SendByTemplate("Notify_RequestReject", tokenInfo.CompanyId, tokenInfo.UserId, risk.ExecutiveUserCode, risk);
                            }
                            break;
                        case 2:
                            inclusionInfo.Message = "La inclusión fue debidamente almacenada y enviada a RRHH, queda pendiente de revisión";
                            Core.Business.General.Mail.SendByTemplate("Notify_RequestOnReview", tokenInfo.CompanyId, tokenInfo.UserId, risk.ExecutiveUserCode, risk);
                            break;
                        case 4:
                            string name = inclusionInfo.FirstName + " " + inclusionInfo.LastName;
                            inclusionInfo.Message = string.Format("La inclusión fue aceptada de forma exitosa bajo el número #{0}, la misma fue enviada {1} para su firma.", inclusionInfo.Id, name);


                            string archivo = Core.Business.General.Report.GeneratePDFFile("bayer", inclusionInfo).GetAwaiter().GetResult();

                            if (!inclusionInfo.HasDigitalSignature)
                            {
                                // Se enviar documento para su firma por medio de EviCertia
                                DocuSign.Integrations.Contracts.SubmitResult submit = DocuSign.Integrations.DocuSign.Submit(
                                                    string.Format("{0} - Solicitud de inclusión", Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "Company", tokenInfo.CompanyId.ToString())),
                                                    string.Format("{0} - Solicitud de inclusión #{1}", Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "Company", tokenInfo.CompanyId.ToString()), inclusionInfo.Id),
                                                      name,
                                                      inclusionInfo.PrimaryEmailAddress,
                                                      archivo).GetAwaiter().GetResult();
                                DataAccess.Policy.Risk.UpdateReference(tokenInfo.CompanyId, inclusionInfo.Id, submit.UniqueId);
                            }
                            else
                            {
                                // Se enviar documento directo al empleado para su firma digital
                                Core.Business.General.Mail.SendByTemplate("Notify_RequestReviewed", tokenInfo.CompanyId, tokenInfo.UserId, risk.ExecutiveUserCode, risk, null, new string[] { archivo });
                            }

                            break;
                    }
                }
            }
            return inclusionInfo;
        }

        /// <summary>
        /// Valida la información de una planilla por su identificación.
        /// </summary>
        private static List<Core.Contracts.General.Error> Validate(Contracts.Bayer.InclusionRequest inclusionInfo)
        {
            const string group = "Inclusion";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();


            //DocumentNumber:
            if (inclusionInfo.DocumentNumber.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "DocumentNumber", Message = "Debe indicar la identificación" });


            if (inclusionInfo.beneficiarios == null || inclusionInfo.beneficiarios.Count == 0)
                result.Add(new Core.Contracts.General.Error() { Group = "beneficiarios", Key = "*", Message = "Debe existir al menos un beneficiario" });
            else
            {
                if (inclusionInfo.beneficiarios.Sum(e => e.BParticipationRate) != 100)
                    result.Add(new Core.Contracts.General.Error()
                    {
                        Group = "beneficiarios",
                        Key = "*",
                        Message = "total del porcentaje de participación debe ser el 100%"
                    });
            }


            return result;
        }

        /// <summary>
        /// Convierte una planilla de requerimiento a un objeto tipo inclusion de medical.
        /// </summary>
        private static Contracts.Others.Inclusiones InclusionToMedical(Contracts.Bayer.InclusionRequest inclusionInfo, int companyId)
        {
            string bayerPolicy = Core.Business.Common.LkpDescription(companyId, "BayerNumeroPoliza", inclusionInfo.MainPolicyId.ToString());
            int empresa = 0;
            if (bayerPolicy.IsNotEmpty())
            {
                empresa = DataAccess.Others.Inclusiones.RetrieveContratante(bayerPolicy);
            }

            Contracts.Others.Inclusiones result = new Contracts.Others.Inclusiones()
            {
                Id = 0,
                Empresa = empresa,
                TieneDependientes = false,
                CantidadDeDependientes = 0,
                Finalizado = true,
                CodigoDeImpresion = "",
                CantidadDeCanets = "",
                CantidadDeCertificados = "",
                FechaDeRecibido = DateTime.Today,
                FechaDeEnvioAPanama = DateTime.MinValue,
                FechaDeEnvioACorredor = inclusionInfo.ContinuityDate,
                Tramite = "Emisión nueva",
                FechaEfectiva = DateTime.MinValue,
                Clase = inclusionInfo.IsHealth,
                Nombre = inclusionInfo.FirstName,
                Apellido = inclusionInfo.LastName,
                Cedula = inclusionInfo.DocumentNumber,
                Observacines = "",
                FechaDeEnvioDeLaObservacion = DateTime.MinValue,
                FechaNacimiento = inclusionInfo.BirthDate,
                Sexo = inclusionInfo.Gender == 1 ? "Masculino" : "Femenino",
                Estatus = "",
                TipoDeIdentificacion = MedicalTipoDeIdentificacion(inclusionInfo.DocumentType),
                CorreoElectronico = inclusionInfo.PrimaryEmailAddress,
                NroCuenta = inclusionInfo.RefundBankAccount,
                Plan = 0,
                Certificado = 0,
                DeducibleConsumido = 0,
                DeducibleMaximoVitalicio = 0,
                StopLost = 0,
                EmployeeNumber = inclusionInfo.EmployeeNumber
            };

            if (inclusionInfo.beneficiarios?.Count() > 0)
            {
                foreach (Contracts.Bayer.Beneficiario beneficiario in inclusionInfo.beneficiarios)
                {
                    if (result.Extras == null)
                    {
                        result.Extras = new List<Contracts.Others.InclusionesExtra>();
                    }
                    result.Extras.Add(new Contracts.Others.InclusionesExtra()
                    {
                        Id = 0,
                        Consecutivo = 0,
                        TipoExtra = "Beneficiario",
                        IdentificacionExtra = beneficiario.BDocumentNumber,
                        NombreExtra = beneficiario.BFirstName,
                        ApellidoExtra = beneficiario.BLastName,
                        EdadExtra = beneficiario.BBirthDate.Age(),
                        ParentescoExtra = beneficiario.BRelationshipDesc,
                        FechaInclusionExtra = inclusionInfo.IssueDate,
                        FechaExclusionExtra = DateTime.MinValue,
                        ParticipacionExtra = beneficiario.BParticipationRate,
                        TipoDeIdentificacionExtra = MedicalTipoDeIdentificacion(beneficiario.BDocumentType),
                        PlanEx = 0,
                        DeducibleConsumidoEx = 0,
                        DeducibleMaximoVitalicioEx = 0,
                        StopLossEx = 0,
                        FechaNacimientoEx = beneficiario.BBirthDate
                    });
                }
            }

            if (inclusionInfo.Dependientes?.Count() > 0)
            {
                result.TieneDependientes = true;
                result.CantidadDeDependientes = inclusionInfo.Dependientes.Count;
                foreach (Contracts.Bayer.Dependiente dependiente in inclusionInfo.Dependientes)
                {
                    if (result.Extras == null)
                    {
                        result.Extras = new List<Contracts.Others.InclusionesExtra>();
                    }
                    result.Extras.Add(new Contracts.Others.InclusionesExtra()
                    {
                        Id = 0,
                        Consecutivo = 0,
                        TipoExtra = "Dependiente",
                        IdentificacionExtra = dependiente.DDocumentNumber,
                        NombreExtra = dependiente.DFirstName,
                        ApellidoExtra = dependiente.DLastName,
                        EdadExtra = dependiente.DBirthDate.Age(),
                        ParentescoExtra = dependiente.DRelationshipDesc,
                        FechaInclusionExtra = dependiente.DInclusionDate,
                        FechaExclusionExtra = DateTime.MinValue,
                        ParticipacionExtra = 0,
                        TipoDeIdentificacionExtra = MedicalTipoDeIdentificacion(dependiente.DDocumentType),
                        PlanEx = 0,
                        DeducibleConsumidoEx = 0,
                        DeducibleMaximoVitalicioEx = 0,
                        StopLossEx = 0,
                        FechaNacimientoEx = dependiente.DBirthDate
                    });
                }
            }

            return result;
        }

        /// <summary>
        /// Mapea el tipo de documento usando en aliados al equivalente en medical.
        /// </summary>
        private static string MedicalTipoDeIdentificacion(int documentType)
        {
            string result = "";
            switch (documentType)
            {
                case 1:
                    result = "Cédula";
                    break;
                case 2:
                    result = "Cédula de residencia";
                    break;
                case 3:
                    result = "Pasaporte";
                    break;
                default:
                    result = "Otro";
                    break;
            }
            return result;
        }

        public static void Delete(int companyId, int userId, int id)
        {
            int result = 0;
            result = DataAccess.Policy.RiskBayer.Delete(id, companyId);
            result = Core.Business.General.Attachment.Delete(2000, id, companyId);
            result = DataAccess.Policy.RiskOverdraft.DeleteByIdCompanyId(id, companyId);
            result = DataAccess.Policy.RiskQuestionnaires.DeleteByPolicyIdCompanyId(id, companyId);

            result = DataAccess.Policy.RiskRoles.DeleteByPolicyId(id, companyId);
            result = DataAccess.Policy.Risk.DeleteByIdCompanyId(id, companyId);
        }

    }
}
