using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using SmartFormat;
using SmartFormat.Core.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// .
    /// </summary>
    public static class Mail
    {
        //https://github.com/Antaris/RazorEngine
        //https://github.com/axuno/SmartFormat/wiki

        public static Dictionary<string, string> GetTemplate(string templateKey, int companyId, int userId, int ownerId, object entity)
        {
            Architect.API.Core.Contracts.Security.UserMember currentUserInfo = new Contracts.Security.UserMember();
            Architect.API.Core.Contracts.Security.UserMember ownerUserInfo = new Contracts.Security.UserMember();
            Core.Contracts.General.Tenant tenantInfo = new Contracts.General.Tenant();
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (userId != 0)
            {
                currentUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, userId);
            }
            if (ownerId != 0)
            {
                ownerUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, ownerId);
            }
            if (companyId != 0)
            {
                tenantInfo = Core.Business.General.Tenant.Information(companyId);
            }
            object context = new
            {
                Data = entity,
                Company = tenantInfo,
                CurrentUser = currentUserInfo,
                Owner = ownerUserInfo
            };
            Contracts.General.InternalTemplate tmpl = DataAccess.General.InternalTemplate.Retrieve(companyId, templateKey);
            if (tmpl.Subject == "Plantilla no encontrada")
            {
                Architect.Utilities.Log.ErrorLog("GetTemplate", $"La plantilla {templateKey} no fue encontrada");
            }
            if (tmpl.MasterTemplateId.IsNotEmpty())
            {
                Contracts.General.InternalTemplate tmplMaster = DataAccess.General.InternalTemplate.RetrieveById(companyId, tmpl.MasterTemplateId);

                tmpl.Body = tmplMaster.Body.Replace("{Content}", tmpl.Body);
            }
            result.Add("Subject", Smart.Format(CultureInfo.CreateSpecificCulture("es-ES"), tmpl.Subject, context));
            result.Add("Body", Smart.Format(CultureInfo.CreateSpecificCulture("es-ES"), tmpl.Body, context));
            return result;
        }

        public static void SendByTemplate(string mailServer, string templateKey, int companyId, int userId, object entity, Dictionary<string, string> toAddressList, string[] attachments = null)
        {
            Hangfire.BackgroundJob.Enqueue(() => EnqueueSend(mailServer, companyId, userId, 0, templateKey, toAddressList, null, null, entity, attachments));
        }

        public static void SendByTemplate(string templateKey, int companyId, object entity, Dictionary<string, string> toAddressList = null, string[] attachments = null)
        {
            Hangfire.BackgroundJob.Enqueue(() => EnqueueSend("Default", companyId, 0, 0, templateKey, toAddressList, null, null, entity, attachments));
        }

        public static void SendByTemplate(string templateKey, int companyId, int userId, int ownerId, object entity, Dictionary<string, string> toAddressList = null, string[] attachments = null)
        {
            Hangfire.BackgroundJob.Enqueue(() => EnqueueSend("Default", companyId, userId, ownerId, templateKey, toAddressList, null, null, entity, attachments));
        }

        public static void SendEmail(Dictionary<string, string> toAddressList, string subject, string body, string[] attachments = null)
        {

            Hangfire.BackgroundJob.Enqueue(() => SendAngular(toAddressList, subject, body, attachments));

        }

        public static void EnqueueSend(string mailServer, int companyId, int userId, int ownerId, string templateKey, Dictionary<string, string> toAddressList, string subject, string body, object entity, string[] attachments)
        {

            Architect.API.Core.Contracts.Security.UserMember currentUserInfo = new Contracts.Security.UserMember();
            Architect.API.Core.Contracts.Security.UserMember ownerUserInfo = new Contracts.Security.UserMember();
            Core.Contracts.General.Tenant tenantInfo = new Contracts.General.Tenant();
            string testEmail = Business.Settings.StringValue("EMail.Test");

            if (toAddressList == null)
            {
                toAddressList = new Dictionary<string, string>();
            }
            if (userId != 0)
            {
                currentUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, userId);
            }
            if (ownerId != 0)
            {
                ownerUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, ownerId);
            }
            if (companyId != 0)
            {
                tenantInfo = Core.Business.General.Tenant.Information(companyId);
            }
            object context = new
            {
                Today = DateTime.Now,
                Hoy = DateTime.Now.ToString("dd/MM/yyyy"),
                Data = entity,
                Company = tenantInfo,
                CurrentUser = currentUserInfo,
                Owner = ownerUserInfo,
                app = new { url = ConfigurationManager.AppSettings["Aliados.URL.Base"] }
            };

            if (templateKey.IsNotEmpty() && subject.IsEmpty())
            {

                Contracts.General.InternalTemplate tmpl = DataAccess.General.InternalTemplate.Retrieve(companyId, templateKey);
                if (tmpl.Subject == "Plantilla no encontrada")
                {
                    Architect.Utilities.Log.ErrorLog("SendMail", $"La plantilla {templateKey} no fue encontrada");
                }
                if (tmpl.MasterTemplateId.IsNotEmpty())
                {
                    Contracts.General.InternalTemplate tmplMaster = DataAccess.General.InternalTemplate.RetrieveById(companyId, tmpl.MasterTemplateId);

                    tmpl.Body = tmplMaster.Body.Replace("{Content}", tmpl.Body);
                }

                subject = Smart.Format(CultureInfo.CreateSpecificCulture("es-ES"), tmpl.Subject, context);
                Smart.Default.Settings.Parser.ErrorAction = ParseErrorAction.Ignore;
                body = Smart.Format(CultureInfo.CreateSpecificCulture("es-ES"), tmpl.Body, context);

                foreach (string emailToken in tmpl.EmailTo.Split(','))
                {
                    switch (emailToken)
                    {
                        case "{Owner}":
                            toAddressList.Add(ownerUserInfo.EMail, string.Format("{0} {1}", ownerUserInfo.FirstName, ownerUserInfo.LastName));
                            break;
                        case "{User}":
                            toAddressList.Add(currentUserInfo.EMail, string.Format("{0} {1}", currentUserInfo.FirstName, currentUserInfo.LastName));
                            break;
                        default:
                            if (emailToken.StartsWith("{UserRoleList.App.", StringComparison.CurrentCultureIgnoreCase))
                            {
                                string key = emailToken.Substring(18, emailToken.Length - 19).Trim();
                                string settingValue = ConfigurationManager.AppSettings[key];
                                foreach (var item in Architect.API.Core.Business.Security.UserMember.EmailListByRolename(companyId, settingValue))
                                {
                                    if (!toAddressList.ContainsKey(item.Key))
                                    {
                                        toAddressList.Add(item.Key, item.Value);
                                    }
                                }
                            }
                            else if (emailToken.StartsWith("{UserRoleList.", StringComparison.CurrentCultureIgnoreCase))
                            {
                                string rolelist = emailToken.Substring(14, emailToken.Length - 15).Trim();
                                foreach (var item in Architect.API.Core.Business.Security.UserMember.EmailListByRolename(companyId, rolelist))
                                {
                                    if (!toAddressList.ContainsKey(item.Key))
                                    {
                                        toAddressList.Add(item.Key, item.Value);
                                    }
                                }
                            }
                            else if (emailToken.IsNotEmpty())
                            {
                                if (!toAddressList.ContainsKey(emailToken))
                                {
                                    toAddressList.Add(emailToken, string.Empty);
                                }
                            }
                            break;
                    }
                }
            }
            else
            {
                subject = Smart.Format(CultureInfo.CreateSpecificCulture("es-ES"), subject, context);
                body = Smart.Format(CultureInfo.CreateSpecificCulture("es-ES"), body, context);

            }
            if (testEmail.IsNotEmpty())
            {
                subject += string.Format(" ({0}) ", testEmail);
            }
            if (mailServer == "Default")
            {
                mailServer = "EMail.";
            }
            else
            {
                mailServer = string.Format("EMail.{0}.", mailServer);
            }

            MailMessage mail = null;

            if (body.Contains("##UserSignature##") && currentUserInfo != null && currentUserInfo.EMail.IsNotEmpty())
            {
                string signatureFielName = string.Format(@"{0}Signature\{1}.jpg", ConfigurationManager.AppSettings["EMail.Path.Images"], currentUserInfo.EMail.Replace("@", "."));
                if (File.Exists(signatureFielName))
                {
                    body = body.Replace("##UserSignature##", "<img src='cid:UserSignature' />");

                    //byte[] reader = File.ReadAllBytes(@"C:\Architect\aliados\aliados\images\purdy\Asesores\igbejaranor.jpg");
                    //MemoryStream image1 = new MemoryStream(reader);
                    //LinkedResource headerImage = new LinkedResource (image1, System.Net.Mime.MediaTypeNames.Image.Jpeg);

                    LinkedResource headerImage = new LinkedResource(signatureFielName, "image/jpeg");
                    headerImage.ContentId = "UserSignature";
                    headerImage.ContentType = new ContentType("image/jpg");

                    AlternateView av = AlternateView.CreateAlternateViewFromString(body, null, System.Net.Mime.MediaTypeNames.Text.Html);

                    av.LinkedResources.Add(headerImage);

                    mail = new MailMessage
                    {
                        From = new MailAddress(ConfigurationManager.AppSettings[mailServer + "From.Address"], ConfigurationManager.AppSettings[mailServer + "From.Diplayname"]),
                        IsBodyHtml = true,
                        Subject = subject,
                        AlternateViews = { av }
                    };
                }
            }


            if (mail == null)
            {
                body = body.Replace("##UserSignature##", string.Empty);
                mail = new MailMessage
                {
                    From = new MailAddress(ConfigurationManager.AppSettings[mailServer + "From.Address"], ConfigurationManager.AppSettings[mailServer + "From.Diplayname"]),
                    IsBodyHtml = true,
                    Subject = subject,
                    Body = body
                };
            }

            int index = 0;
            foreach (KeyValuePair<string, string> entry in toAddressList)
            {
                if (index == 0)
                {
                    if (testEmail.IsNotEmpty())
                    {
                        mail.To.Add(new MailAddress(testEmail, entry.Value));
                    }
                    else
                    {
                        mail.To.Add(new MailAddress(entry.Key, entry.Value));
                    }
                }
                else
                {
                    if (testEmail.IsNotEmpty())
                    {
                        mail.Bcc.Add(new MailAddress(testEmail, entry.Value));
                    }
                    else
                    {
                        mail.Bcc.Add(new MailAddress(entry.Key, entry.Value));
                    }
                }
                Architect.Utilities.Log.WarningLog(entry.Key, subject, "Mail");
                index++;
            }

            if (attachments?.Length > 0)
            {
                System.Net.Mail.Attachment attachment = null;
                foreach (string attachmentFile in attachments)
                {
                    //using (var stream = File.Open(attachmentFile, FileMode.Open))
                    //{
                    //    mail.Attachments.Add(new System.Net.Mail.Attachment(stream, Path.GetFileName(attachmentFile)));
                    //}

                    //using (MemoryStream stream = new MemoryStream(File.ReadAllBytes(attachmentFile)))
                    //{
                    //    mail.Attachments.Add(new System.Net.Mail.Attachment(stream, Path.GetFileName(attachmentFile)));
                    //}
                    if (attachmentFile.IndexOf(';') == -1)
                    {
                        attachment = new System.Net.Mail.Attachment(attachmentFile);
                    }
                    else
                    {
                        attachment = new System.Net.Mail.Attachment(attachmentFile.Split(';')[0]);
                        attachment.Name = attachmentFile.Split(';')[1];
                    }

                    mail.Attachments.Add(attachment);
                }
            }



            SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings[mailServer + "Host"])
            {
                Port = Convert.ToInt32(ConfigurationManager.AppSettings[mailServer + "Port"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings[mailServer + "EnableSsl"])
            };
            string mailUsername = ConfigurationManager.AppSettings[mailServer + "Username"];
            if (!string.IsNullOrEmpty(mailUsername))
            {
                SmtpServer.Credentials = new System.Net.NetworkCredential(mailUsername, ConfigurationManager.AppSettings[mailServer + "Password"]);
            }

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[mailServer + "Ssl.ValidCertificate"]) && ConfigurationManager.AppSettings[mailServer + "Ssl.ValidCertificate"] == "false")
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate (Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                {
                    return true;
                };
            }

            try
            {
                SmtpServer.Send(mail);
                if (testEmail.IsNotEmpty())
                {
                    Utilities.Log.WarningLog("Context", JsonConvert.SerializeObject(context), "Mail");
                }
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.WarningLog("Fail", ex.Message, "Mail");
                Architect.Utilities.Log.ErrorLog("SendMail", $"Server setting: MailServer: {mailServer}, Host: {SmtpServer.Host}, Port: {SmtpServer.Port}, SSL: {SmtpServer.EnableSsl}, Username: {mailUsername}", ex);
            }
            mail.Dispose();
            SmtpServer.Dispose();
        }

        /// Este método es usado desde las reglas.
        public static void Send(string eMail, string subject, string body, object entity)
        {
            string subjectResult = Smart.Format(CultureInfo.CreateSpecificCulture("es-ES"), subject, entity);

            string bodyTResult = Smart.Format(CultureInfo.CreateSpecificCulture("es-ES"), body, entity);

            Send(new Dictionary<string, string>() { { eMail, string.Empty } }, subjectResult, bodyTResult);
        }

        /// Usado por la versiones iniciales para el caso de coopeservidores.
        public static void Send(Dictionary<string, string> toAddressList, string subject, string body)
        {
            string testEmail = ConfigurationManager.AppSettings["EMail.Test"];
            if (testEmail.IsNotEmpty())
            {
                subject += string.Format(" ({0}) ", testEmail);
            }
            var mail = new MailMessage
            {
                From = new MailAddress(ConfigurationManager.AppSettings["EMail.From.Address"], ConfigurationManager.AppSettings["EMail.From.Diplayname"]),
                IsBodyHtml = true,
                Subject = subject,
                Body = body
            };

            foreach (KeyValuePair<string, string> entry in toAddressList)
            {
                if (testEmail.IsNotEmpty())
                {
                    mail.To.Add(new MailAddress(testEmail, entry.Value));
                }
                else
                {
                    mail.To.Add(new MailAddress(entry.Key, entry.Value));
                }
                Architect.Utilities.Log.WarningLog(entry.Key, subject, "Mail");
            }

            SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["EMail.Host"])
            {
                Port = Convert.ToInt32(ConfigurationManager.AppSettings["EMail.Port"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EMail.EnableSsl"])
            };
            string mailUsername = ConfigurationManager.AppSettings["EMail.Username"];
            if (!string.IsNullOrEmpty(mailUsername))
            {
                SmtpServer.Credentials = new System.Net.NetworkCredential(mailUsername, ConfigurationManager.AppSettings["EMail.Password"]);
            }

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EMail.Ssl.ValidCertificate"]) && ConfigurationManager.AppSettings["EMail.Ssl.ValidCertificate"] == "false")
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate (Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                                                                                    {
                                                                                        return true;
                                                                                    };
            }

            try
            {
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.WarningLog("Fail", ex.Message, "Mail");
                Architect.Utilities.Log.ErrorLog("SendMail", string.Empty, ex);
            }

            //SmtpServer.SendMailAsync(mail).ConfigureAwait(false);
            //TODO: Mejorar, debe ser asincrono, pero cuando se hace en caso de que se envie dos email seguidos solo llega el ultimo.



        }
        public static void SendAngular(Dictionary<string, string> toAddressList, string subject, string body, string[] attachments)
        {
            string testEmail = ConfigurationManager.AppSettings["EMail.Test"];

            if (testEmail.IsNotEmpty())
            {
                subject += string.Format(" ({0}) ", testEmail);
            }
            var mail = new MailMessage
            {
                From = new MailAddress(ConfigurationManager.AppSettings["EMail.From.Address"], ConfigurationManager.AppSettings["EMail.From.Diplayname"]),
                IsBodyHtml = true,
                Subject = subject,
                Body = body
            };

            foreach (KeyValuePair<string, string> entry in toAddressList)
            {
                if (testEmail.IsNotEmpty())
                {
                    mail.To.Add(new MailAddress(testEmail, entry.Value));
                }
                else
                {
                    mail.To.Add(new MailAddress(entry.Key, entry.Value));
                }
                Architect.Utilities.Log.WarningLog(entry.Key, subject, "Mail");
            }

            if (attachments?.Length > 0)
            {
                System.Net.Mail.Attachment attachment = null;
                foreach (string attachmentFile in attachments)
                {

                    if (attachmentFile.IndexOf(';') == -1)
                    {
                        attachment = new System.Net.Mail.Attachment(attachmentFile);
                    }
                    else
                    {
                        attachment = new System.Net.Mail.Attachment(attachmentFile.Split(';')[0]);
                        attachment.Name = attachmentFile.Split(';')[1];
                    }

                    mail.Attachments.Add(attachment);
                }
            }

            SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["EMail.Host"])
            {
                Port = Convert.ToInt32(ConfigurationManager.AppSettings["EMail.Port"]),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EMail.EnableSsl"])
            };

            string mailUsername = ConfigurationManager.AppSettings["EMail.Username"];
            if (!string.IsNullOrEmpty(mailUsername))
            {
                SmtpServer.Credentials = new System.Net.NetworkCredential(mailUsername, ConfigurationManager.AppSettings["EMail.Password"]);
            }

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["EMail.Ssl.ValidCertificate"]) && ConfigurationManager.AppSettings["EMail.Ssl.ValidCertificate"] == "false")
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate (Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                {
                    return true;
                };
            }

            try
            {
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.WarningLog("Fail", ex.Message, "Mail");
                Architect.Utilities.Log.ErrorLog("SendMail", string.Empty, ex);
            }

            mail.Dispose();
            SmtpServer.Dispose();

        }

    }
}
