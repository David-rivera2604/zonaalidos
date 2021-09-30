using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Logíca relacionada con los adjuntos.
    /// </summary>
    public static class Attachment
    {
        public static Architect.API.Core.Contracts.General.AttachmentItem RetrieveById(int id)
        {
            Architect.API.Core.Contracts.General.AttachmentItem result = Core.DataAccess.General.Attachments.RetrieveById(id);

            switch (result.Type.ToLower())
            {
                case "jpg":
                    result.Type = "image/jpeg";
                    break;

                case "pdf":
                    result.Type = "application/pdf";
                    break;

                default:
                    //result.Type = "application/octet-stream";
                    result.Type = "application/" + result.Type;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Permite recuperar la lista optimizada para consulta de los adjuntos disponibles por medio del tipo de entidad y su respectiva identificación.
        /// </summary>
        /// <param name="entityType">Tipo de entidad.</param>
        /// <param name="entityId">Identificación de la entidad.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <returns>Lista optimizada para consulta de los adjuntos disponibles.</returns>
        public static List<Contracts.General.AttachmentView> RetrieveByEntity(int entityType, Int64 entityId, int companyId)
        {
            return Core.DataAccess.General.Attachments.RetrieveByEntity(entityType, entityId, companyId);
        }

        /// <summary>
        /// Permite almacenar una lista de adjuntos para un tipo de entidad y su respectiva identificación.
        /// </summary>
        /// <param name="entityType">Tipo de entidad.</param>
        /// <param name="entityId">Identificación de la entidad.</param>
        /// <param name="companyId">Identificación de lacompañia propietaria.</param>
        /// <param name="attachments">Lista de adjuntos.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <returns></returns>
        public static List<Contracts.General.AttachmentView> SyncUp(int entityType, Int64 entityId, int companyId, List<Contracts.General.AttachmentView> attachments, int userId)
        {
            foreach (Contracts.General.AttachmentView item in attachments)
            {
                Contracts.General.Attachments newItem = new Contracts.General.Attachments
                {
                    EntityType = entityType,
                    EntityId = entityId,
                    CompanyId = companyId
                };

                if (item.Id.IsEmpty())
                {
                    newItem.Id = DataAccess.General.Attachments.RetrieveLastKey() + 1;
                    newItem.UpdateUserCode = userId;
                    newItem.UpdateDate = DateTime.Now;
                    newItem.FileContent = ConfigurationManager.AppSettings["Attachments.Path"] + item.Stored;
                    DataAccess.General.Attachments.Create(Mapper(newItem, item));
                }

            }

            return attachments;
        }

        public static Contracts.General.Attachments SyncUp(Contracts.General.Attachments attachment)
        {
            attachment.UpdateDate = DateTime.Now;
            if (attachment.Id.IsEmpty())
            {
                attachment.Id = DataAccess.General.Attachments.RetrieveLastKey() + 1;
                DataAccess.General.Attachments.Create(attachment);
            }
            else
            {
                DataAccess.General.Attachments.Update(attachment);
            }
            return attachment;
        }

        public static void Delete(int id)
        {
            DataAccess.General.Attachments.Delete(id);
        }

        /// <summary>
        /// Permite el mapeo entre las propiedades de una clase de tipo adjunto.
        /// </summary>
        /// <param name="target">Clase destino.</param>
        /// <param name="source">Clase fuentes.</param>
        /// <returns>Clase resultante del mapeo.</returns>
        public static Contracts.General.Attachments Mapper(Contracts.General.Attachments target, Contracts.General.AttachmentView source)
        {
            target.DocumentType = source.DocumentType;
            target.Description = source.Description;
            target.FileName = source.FileName;
            target.FileSize = source.FileSize;
            return target;
        }

        /// <summary>
        /// Permite cambiar la entidad y su identificación a un grupo de adjuntos.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="entityType">Tipo de entidad actual.</param>
        /// <param name="entityId">Identificación de la entidad actual.</param>
        /// <param name="newEntityType">Tipo de entidad nueva.</param>
        /// <param name="newEntityId">Identificación de la entidad nueva.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <returns>Verdadero en caso de que el cambio sea aplicado de forma correcta, falso en caso contrario</returns>
        public static bool ChangeEntityId(int companyId, int entityType, Int64 entityId, int newEntityType, Int64 newEntityId, int userId)
        {
            return DataAccess.General.AttachmentEx.Update(companyId, entityType, entityId, newEntityType, newEntityId, userId) > 0;
        }


    }
}
