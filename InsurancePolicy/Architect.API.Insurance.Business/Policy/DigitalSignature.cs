using Architect.API.Core.Contracts.Security;
using Architect.API.Insurance.Contracts.Policy;
using Architect.DocuSign.Integrations.Contracts;
using Architect.Utilities.Contracts;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Architect.API.Insurance.Business.Policy
{
    /// <summary>
    /// Manejo de firma de documento para solicitudes.
    /// </summary>
    public class DigitalSignature
    {

        /// <summary>
        /// Verificar si las inclusiones pendiente por firma, ya fueron procesadas.
        /// </summary>
        public static void VerifyDocuSigned()
        {
            Utilities.Log.WarningLog("DigitalSignature.VerifyDocuSigned", "Inicio - Proceso de sondeo", "DocuSigned");
            try
            {
                foreach (string companyIdForReview in Utilities.Helpers.Settings.StringValue("DocuSign.Request.Company.Review").Split(','))
                {
                    int userId = 666;
                    int companyId = Convert.ToInt32(companyIdForReview);

                    List<LookUpValue> items = DataAccess.Policy.Risk.RetrieveByStatus(companyId, (int)Enumerations.PolicyStatus.PendingBySignature);


                    Utilities.Log.WarningLog("DigitalSignature.VerifyDocuSigned", $"  {items.Count} Documentos pendientes por firma ({companyIdForReview})", "DocuSigned");

                    foreach (LookUpValue item in items)
                    {
                        VerifySign(userId, companyId, item.Description, Convert.ToInt32(item.Code));
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("VerifyDocuSigned", "EvicertiaSigned", ex);
                throw ex;
            }
            Utilities.Log.WarningLog("DigitalSignature.VerifyDocuSigned", "Fin - Proceso de sondeo", "DocuSigned");
        }

        /// <summary>
        /// Verificar si una inclusión ya fueron procesadas por medio de su identificación de firma.
        /// </summary>
        public static string Verify(string uniqueId)
        {
            string result = string.Empty;
            Contracts.Policy.Risk risk = DataAccess.Policy.Risk.RetrieveByReference(uniqueId.Replace("-", ""));
            if (risk != null && risk.Status == (int)Enumerations.PolicyStatus.PendingBySignature)
            {
                int userId = 666;
                result = VerifySign(userId, risk.CompanyId, risk.Reference, risk.Id);
                if (!result.StartsWith("!"))
                {
                    result = System.IO.Path.GetFileName(result);
                }
            }
            return result;
        }

        /// <summary>
        /// Verificar si una inclusión ya fueron procesadas.
        /// </summary>
        public static string VerifySign(int userId, int companyId, string uniqueId, int riskId)
        {
            string result = string.Empty;
            QueryResult docuSignedInfo = DocuSign.Integrations.DocuSign.Query(uniqueId, true).GetAwaiter().GetResult();
            if (docuSignedInfo != null)
            {
                Utilities.Log.TraceLog(" VerifyDocuSigned", uniqueId + " outcome " + docuSignedInfo.outcome, "DocuSigned");
                switch (docuSignedInfo.outcome)
                {
                    case "Signed":
                        Signed(companyId, riskId);
                        foreach (DocuSign.Integrations.Contracts.affidavits affidavit in docuSignedInfo.affidavits)
                        {
                            if (affidavit.description.Equals("documento firmado", StringComparison.CurrentCultureIgnoreCase))
                            {
                                result = StorageDocumentSigned(companyId, 2000, riskId, 1, affidavit.bytes, userId);
                                break;
                            }
                        }
                        break;
                    case "None":
                        break;
                    case "Expired":
                        Expired(companyId, riskId);
                        result = "!Expired";
                        break;
                    case "Rejected":
                        Rejected(companyId, riskId);
                        result = "!Rejected";
                        break;
                }
            }
            else
            {
                Utilities.Log.TraceLog(" VerifyDocuSigned", uniqueId + " not outcome", "DocuSigned");
            }

            return result;
        }

        /// <summary>
        /// Procesa una inclusión como firmada.
        /// </summary>
        private static void Signed(int companyId, int id)
        {
            Contracts.Policy.Risk risk = Risk.RetrievePolicyByKey(id, companyId);
            risk.LineOfBusinessDesc = Core.Business.Common.LkpDescription(companyId, "LineOfBusiness", risk.LineOfBusinessCode.ToString());
            risk.Status = (int)Enumerations.PolicyStatus.InForce;
            DataAccess.Policy.Risk.Update(risk);
            Core.Business.General.ChangeSet.Create(2000, risk.Id, companyId, "Aceptada", null, risk.ExecutiveUserCode, risk);
        }

        /// <summary>
        /// Almacena el documento firmado como un adjunto.
        /// </summary>
        private static string StorageDocumentSigned(int companyId, int entityType, Int64 entityId, int documentType, string fileContent, int userId)
        {
            Byte[] pdfbytes = Convert.FromBase64String(fileContent);
            string originalFileName = "Documento firmado.pdf";
            string fileName = string.Format("{0}.pdf", Guid.NewGuid());
            string fullFileName = Path.Combine(Utilities.Helpers.Settings.StringValue("Attachments.Path"), fileName);

            File.WriteAllBytes(fullFileName, pdfbytes);

            Core.Contracts.General.Attachments attachment = new Core.Contracts.General.Attachments
            {
                EntityType = entityType,
                EntityId = entityId,
                CompanyId = companyId,
                UpdateUserCode = userId,
                DocumentType = documentType,
                Description = "Documento firmado",

                FileName = originalFileName,
                FileSize = pdfbytes.Length,
                FileContent = fullFileName
            };
            Core.Business.General.Attachment.SyncUp(attachment);
            return fullFileName;
        }

        /// <summary>
        /// Procesa una inclusión como expirada.
        /// </summary>
        private static void Expired(int companyId, int id)
        {
            Contracts.Policy.Risk risk = Risk.RetrievePolicyByKey(id, companyId);
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
            Contracts.Policy.Risk risk = Risk.RetrievePolicyByKey(id, companyId);
            risk.LineOfBusinessDesc = Core.Business.Common.LkpDescription(companyId, "LineOfBusiness", risk.LineOfBusinessCode.ToString());
            risk.Status = (int)Enumerations.PolicyStatus.RejectedBySigner;
            DataAccess.Policy.Risk.Update(risk);
            Core.Business.General.ChangeSet.Create(2000, risk.Id, companyId, "Rechazada", null, risk.ExecutiveUserCode, risk);
            Core.Business.General.Mail.SendByTemplate("Notify_RequestOnUserDeclined", companyId, risk.ExecutiveUserCode, risk.ExecutiveUserCode, risk);
        }

        /// <summary>
        /// Envía un documento para su respectiva firma digital.
        /// </summary>
        internal static Boolean Submit(Contracts.Policy.Risk item, Token tokenInfo, bool includeCallback = false)
        {
            bool result = true;
            if (item.StatusDesc == null)
            {
                item.StatusDesc = string.Empty;
            }
            Contracts.Policy.RiskView riskInfo = Risk.Mapper_Information(item, tokenInfo.CompanyId);

            string archivo = Core.Business.General.Report.Generate(tokenInfo.CompanyId, riskInfo.ProductAlias + riskInfo.Prefix, riskInfo).GetAwaiter().GetResult();

            if (!item.HasDigitalSignature)
            {
                // Se enviar documento para su firma por medio de EviCertia
                DocuSign.Integrations.Contracts.SubmitResult submit = DocuSign.Integrations.DocuSign.Submit(
                                        string.Format("{0} - Solicitud de inclusión", Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "Company", tokenInfo.CompanyId.ToString())),
                                        string.Format("{0} - Solicitud de inclusión #{1}", Core.Business.Common.LkpDescription(tokenInfo.CompanyId, "Company", tokenInfo.CompanyId.ToString()), item.Id),
                                        item.PrimaryInsured.FirstName + " " + item.PrimaryInsured.LastName,
                                        item.PrimaryInsured.PrimaryEmailAddress,
                                        archivo, "WebClick", includeCallback).GetAwaiter().GetResult();
                if (submit.UniqueId.IsNotEmpty())
                {
                    DataAccess.Policy.Risk.UpdateReference(tokenInfo.CompanyId, item.Id, submit.UniqueId);
                    item.Reference = submit.UniqueId;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                // Se enviar documento directo al empleado para su firma digital
                Core.Business.General.Mail.SendByTemplate("Notify_RequestReviewed", tokenInfo.CompanyId, tokenInfo.UserId, item.ExecutiveUserCode, item, null, new string[] { archivo });
            }
            return result;
        }

    }
}
