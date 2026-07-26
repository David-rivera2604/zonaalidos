using System;
using Architect.API.Core.Contracts.Notifications;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;

namespace Architect.API.Core.Business.Notifications
{
    /// <summary>
    /// Logica de negocio del sistema de notificaciones.
    /// Titulos y mensajes se leen desde la tabla TEMPLATE via KEY.
    /// </summary>
    public static class NotificationBusiness
    {
        /// <summary>
        /// Crea y persiste una notificacion para un usuario, validando los campos requeridos.
        /// Dispara el push en tiempo real y actualiza el contador de no leidas.
        /// </summary>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario destinatario.</param>
        /// <param name="type">Tipo de notificacion (ej. PROCESS_STEP, POLICY_ISSUED).</param>
        /// <param name="title">Titulo visible de la notificacion (max 255 caracteres).</param>
        /// <param name="message">Cuerpo de la notificacion (max 2000 caracteres).</param>
        /// <param name="entityType">Tipo de entidad relacionada (0 = ninguna).</param>
        /// <param name="entityId">Identificador de la entidad relacionada.</param>
        /// <param name="category">Categoria logica; si es nula se usa "SYSTEM".</param>
        /// <param name="metadata">JSON adicional de contexto, opcional.</param>
        /// <param name="connection">Conexion de base de datos existente, opcional.</param>
        /// <returns>Resultado de la operacion con la notificacion creada o los errores de validacion.</returns>
        public static NotificationResult Send(int companyId, int userId, string type, string title, string message, int entityType = 0, long entityId = 0, string category = null, string metadata = null, IDbConnection connection = null)
        {
            var result = new NotificationResult { Errors = new List<Architect.API.Core.Contracts.General.Error>() };

            if (string.IsNullOrWhiteSpace(title))   result.Errors.Add(new Architect.API.Core.Contracts.General.Error { Key = "Title",     Message = "El titulo es requerido."   });
            if (string.IsNullOrWhiteSpace(message)) result.Errors.Add(new Architect.API.Core.Contracts.General.Error { Key = "Message",   Message = "El mensaje es requerido."  });
            if (userId <= 0)                        result.Errors.Add(new Architect.API.Core.Contracts.General.Error { Key = "UserId",    Message = "UserId invalido."           });
            if (companyId <= 0)                     result.Errors.Add(new Architect.API.Core.Contracts.General.Error { Key = "CompanyId", Message = "CompanyId invalido."        });

            if (!result.Successful) return result;

            var entity = new Architect.API.Core.Contracts.Notifications.Notification
            {
                CompanyId      = companyId,
                UserId         = userId,
                Title          = title.Length   > 255  ? title.Substring(0, 255)   : title,
                Message        = message.Length > 2000 ? message.Substring(0, 2000) : message,
                Type           = type,
                Category       = string.IsNullOrWhiteSpace(category) ? "SYSTEM" : category,
                EntityType     = entityType,
                EntityId       = entityId,
                Metadata       = metadata,
                UpdateUserCode = userId
            };

            try
            {
                Architect.API.Core.DataAccess.Notifications.Notification.Create(entity, connection);
                result.Notification = entity;
            }
            catch (Exception exCreate)
            {
                Architect.Utilities.Log.ErrorLog("NotificationBusiness.Send",
                    "Error al persistir notificacion para userId=" + userId, exCreate);
                result.Errors.Add(new Architect.API.Core.Contracts.General.Error
                {
                    Key     = "Notification",
                    Message = "Error al persistir la notificacion."
                });
                return result;
            }

            try
            {
                NotificationPush.ToUser?.Invoke(userId, entity);
                int unread = Architect.API.Core.DataAccess.Notifications.Notification.CountUnread(companyId, userId);
                NotificationPush.UnreadCount?.Invoke(userId, unread);
            }
            catch (Exception exPush)
            {
                Architect.Utilities.Log.WarningLog("NotificationBusiness.Send", "SignalR push fallido: " + exPush.Message, string.Empty, exPush);
            }

            return result;
        }

        /// <summary>
        /// Lee el titulo y cuerpo desde la tabla TEMPLATE usando <paramref name="templateKey"/>,
        /// resuelve los <paramref name="placeholders"/> con SmartFormat y llama a <see cref="Send"/>.
        /// Si SmartFormat falla, se envia el texto sin resolver.
        /// </summary>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario destinatario.</param>
        /// <param name="templateKey">Clave del template en la tabla TEMPLATE.</param>
        /// <param name="type">Tipo de notificacion.</param>
        /// <param name="placeholders">Objeto anonimo con los valores a sustituir en el template.</param>
        /// <param name="entityType">Tipo de entidad relacionada (0 = ninguna).</param>
        /// <param name="entityId">Identificador de la entidad relacionada.</param>
        /// <param name="category">Categoria logica de la notificacion.</param>
        /// <param name="metadata">JSON adicional de contexto, opcional.</param>
        /// <returns>Resultado de la operacion delegado a <see cref="Send"/>.</returns>
        private static NotificationResult SendFromTemplate(int companyId, int userId, string templateKey, string type, object placeholders, int entityType = 0, long entityId = 0, string category = null, string metadata = null)
        {
            var tmpl = Architect.API.Core.DataAccess.General.InternalTemplate.Retrieve(companyId, templateKey);

            // Resolver placeholders con SmartFormat
            string title   = tmpl.Subject;
            string message = tmpl.Body;
            try
            {
                title   = SmartFormat.Smart.Format(tmpl.Subject, placeholders);
                message = SmartFormat.Smart.Format(tmpl.Body,    placeholders);
            }
            catch (Exception exFmt)
            {
                Architect.Utilities.Log.WarningLog("NotificationBusiness.SendFromTemplate",
                    "SmartFormat fallo para template '" + templateKey + "': " + exFmt.Message);
            }

            return Send(companyId, userId, type, title, message, entityType, entityId, category, metadata);
        }

        /// <summary>
        /// Marca una notificacion especifica como leida para el usuario indicado.
        /// </summary>
        /// <param name="notificationId">Identificador de la notificacion.</param>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario propietario.</param>
        /// <returns><c>true</c> si se actualizo al menos un registro; <c>false</c> en caso contrario.</returns>
        public static bool MarkAsRead(int notificationId, int companyId, int userId)
        {
            return Architect.API.Core.DataAccess.Notifications.Notification.MarkAsRead(notificationId, companyId, userId) > 0;
        }

        /// <summary>
        /// Marca todas las notificaciones no leidas del usuario como leidas.
        /// </summary>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario.</param>
        public static void MarkAllAsRead(int companyId, int userId)
        {
            Architect.API.Core.DataAccess.Notifications.Notification.MarkAllAsRead(companyId, userId);
        }

        /// <summary>
        /// Obtiene una pagina de notificaciones del usuario con totales de conteo.
        /// Valores de paginacion fuera de rango se corrigen automaticamente (page >= 1, pageSize 1-100).
        /// </summary>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario.</param>
        /// <param name="onlyUnread">Si es <c>true</c>, retorna solo las notificaciones no leidas.</param>
        /// <param name="page">Numero de pagina solicitada (base 1).</param>
        /// <param name="pageSize">Cantidad de registros por pagina (max 100; defecto 20).</param>
        /// <returns>Resultado paginado con items, total de registros y cantidad de no leidas.</returns>
        public static NotificationPagedResult GetPaged(int companyId, int userId, bool onlyUnread, int page, int pageSize)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0 || pageSize > 100) pageSize = 20;
            int begin = ((page - 1) * pageSize) + 1;
            int end   = page * pageSize;

            return new NotificationPagedResult
            {
                Items       = Architect.API.Core.DataAccess.Notifications.Notification.RetrieveByUser(companyId, userId, onlyUnread, begin, end),
                TotalCount  = Architect.API.Core.DataAccess.Notifications.Notification.Count(companyId, userId),
                UnreadCount = Architect.API.Core.DataAccess.Notifications.Notification.CountUnread(companyId, userId),
                Page        = page,
                PageSize    = pageSize
            };
        }

        /// <summary>
        /// Retorna la cantidad de notificaciones no leidas del usuario.
        /// </summary>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario.</param>
        /// <returns>Numero de notificaciones pendientes de lectura.</returns>
        public static int GetUnreadCount(int companyId, int userId)
        {
            return Architect.API.Core.DataAccess.Notifications.Notification.CountUnread(companyId, userId);
        }

        /// <summary>
        /// Elimina una notificacion del usuario. La operacion es logica o fisica segun la implementacion del repositorio.
        /// </summary>
        /// <param name="notificationId">Identificador de la notificacion a eliminar.</param>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario propietario.</param>
        /// <returns><c>true</c> si se elimino al menos un registro; <c>false</c> en caso contrario.</returns>
        public static bool Delete(int notificationId, int companyId, int userId)
        {
            return Architect.API.Core.DataAccess.Notifications.Notification.Delete(notificationId, companyId, userId) > 0;
        }

        /// <summary>
        /// Notifica al usuario que un caso de proceso le fue reasignado.
        /// </summary>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario destinatario.</param>
        /// <param name="caseId">Identificador del caso reasignado.</param>
        /// <param name="caseTitle">Titulo descriptivo del caso.</param>
        public static void NotifyProcessReassign(int companyId, int userId, int caseId, string caseTitle)
        {
            string meta = JsonConvert.SerializeObject(new { caseId, caseTitle });
            SendFromTemplate(companyId, userId, "Notify_ProcessReassign", "PROCESS_REASSIGN",
                new { caseId, caseTitle },
                entityType: 1, entityId: caseId, category: "PROCESS", metadata: meta);
        }

        /// <summary>
        /// Notifica al usuario que un paso de proceso le fue asignado.
        /// </summary>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario destinatario.</param>
        /// <param name="caseId">Identificador del caso.</param>
        /// <param name="caseTitle">Titulo descriptivo del caso.</param>
        public static void NotifyProcessAssign(int companyId, int userId, int caseId, string caseTitle)
        {
            string meta = JsonConvert.SerializeObject(new { caseId, caseTitle });
            SendFromTemplate(companyId, userId, "Notify_ProcessAssign", "PROCESS_STEP",
                new { caseId, caseTitle },
                entityType: 1, entityId: caseId, category: "PROCESS", metadata: meta);
        }

        /// <summary>
        /// Notifica al usuario que un paso de proceso esta vencido.
        /// </summary>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario responsable.</param>
        /// <param name="caseId">Identificador del caso vencido.</param>
        /// <param name="caseTitle">Titulo descriptivo del caso.</param>
        /// <param name="stepName">Nombre del paso que supero el plazo.</param>
        public static void NotifyProcessOverdue(int companyId, int userId, int caseId, string caseTitle, string stepName)
        {
            SendFromTemplate(companyId, userId, "Notify_ProcessOverdue", "PROCESS_OVERDUE",
                new { caseId, caseTitle, stepName },
                entityType: 1, entityId: caseId, category: "PROCESS");
        }

        /// <summary>
        /// Notifica al usuario que una poliza fue emitida exitosamente.
        /// </summary>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario destinatario.</param>
        /// <param name="policyId">Identificador de la poliza emitida.</param>
        /// <param name="policyNumber">Numero de poliza legible.</param>
        public static void NotifyPolicyIssued(int companyId, int userId, long policyId, string policyNumber)
        {
            SendFromTemplate(companyId, userId, "Notify_PolicyIssued", "POLICY_ISSUED",
                new { policyId, policyNumber },
                entityType: 2, entityId: policyId, category: "INSURANCE");
        }

        /// <summary>
        /// Notifica al usuario que un pago fallo durante su procesamiento.
        /// </summary>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario afectado.</param>
        /// <param name="receiptId">Identificador del recibo de pago fallido.</param>
        /// <param name="reason">Descripcion del motivo del fallo.</param>
        public static void NotifyPaymentFailed(int companyId, int userId, long receiptId, string reason)
        {
            SendFromTemplate(companyId, userId, "Notify_PaymentFailed", "PAYMENT_FAILED",
                new { receiptId, reason },
                entityType: 3, entityId: receiptId, category: "PAYMENT");
        }

        /// <summary>
        /// Notifica al usuario que un documento fue firmado via DocuSign.
        /// </summary>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario notificado.</param>
        /// <param name="policyId">Identificador de la poliza asociada al documento.</param>
        /// <param name="policyNumber">Numero de poliza legible.</param>
        public static void NotifyDocuSignSigned(int companyId, int userId, long policyId, string policyNumber)
        {
            SendFromTemplate(companyId, userId, "Notify_DocuSignSigned", "DOCUSIGN_SIGNED",
                new { policyId, policyNumber },
                entityType: 4, entityId: policyId, category: "DOCUSIGN");
        }

        /// <summary>
        /// Notifica al usuario que una inclusion fue firmada via Evicertia.
        /// </summary>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario notificado.</param>
        /// <param name="inclusionId">Identificador de la inclusion firmada.</param>
        public static void NotifyEvicertiaSigned(int companyId, int userId, long inclusionId)
        {
            SendFromTemplate(companyId, userId, "Notify_EvicertiaSigned", "EVICERTIA_SIGNED",
                new { inclusionId },
                entityType: 4, entityId: inclusionId, category: "EVICERTIA");
        }
    }
}
