using Architect.DataFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Logíca relacionada con el seguimiento de cambios.
    /// </summary>
    public static class ChangeSet
    {

        /// <summary>
        /// Permite recuperar la lista optimizada para consulta del seguimiento de los cambios disponibles por medio del tipo de entidad y su respectiva identificación.
        /// </summary>
        /// <param name="entityType">Tipo de entidad.</param>
        /// <param name="entityId">Identificación de la entidad.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <returns>Lista optimizada para consulta del seguimiento de los cambios.</returns>
        public static List<Contracts.General.ChangeSetView> RetrieveByEntity(int entityType, Int64 entityId, int companyId, string filter)
        {
            return Core.DataAccess.General.ChangeSet.RetrieveByEntity(entityType, entityId, companyId, filter);
        }

        /// <summary>
        /// Crear un registro para el seguimiento de un cambio.
        /// </summary>
        /// <param name="entityType">Tipo de entidad.</param>
        /// <param name="entityId">Identificación de la entidad.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="action">Acción que da origen al cambio.</param>
        /// <param name="summary">Detalle del cambio.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="entitySource">Instancia de la entidad que original el evento.</param>
        public static void Create(int entityType, Int64 entityId, int companyId, string action, string summary, int userId, object entitySource)
        {

            Core.Contracts.General.ChangeSet item = new Core.Contracts.General.ChangeSet
            {
                EntityType = entityType,
                EntityId = entityId,
                CompanyId = companyId,
                Action = action,
                Summary = summary,
                UpdateUserCode = userId,
                UpdateDate = DateTime.Now
            };
            item.Id = Core.DataAccess.General.ChangeSet.Create(item);

            Task.Run(() => Rule.Runtime(companyId, userId, entityType, action, entitySource));
            //_ = Rule.Runtime(companyId, userId, entityType, action, entitySource);
        }


        /// <summary>
        /// Crear un registro para el seguimiento de un cambio.
        /// </summary>
        /// <param name="entityType">Tipo de entidad.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="action">Acción que da origen al cambio.</param>
        /// <param name="summary">Detalle del cambio.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="entitySource">Instancia de la entidad que original el evento.</param>
        public static Int64 Create(int entityType, int companyId, string action, string summary, int userId, object entitySource)
        {
            Int64 processId = Architect.API.Core.DataAccess.General.ChangeSet.RetrieveLastEntityId(2007, companyId) + 1;

            summary = summary.Replace("%ProcessId%", processId.ToString());
            Core.Contracts.General.ChangeSet item = new Core.Contracts.General.ChangeSet
            {
                Id = Core.DataAccess.General.ChangeSet.RetrieveLastKey() + 1,
                EntityType = entityType,
                EntityId = processId,
                CompanyId = companyId,
                Action = action,
                Summary = summary,
                UpdateUserCode = userId,
                UpdateDate = DateTime.Now
            };
            Core.DataAccess.General.ChangeSet.Create(item);

            Task.Run(() => Rule.Runtime(companyId, userId, entityType, action, entitySource));
            //_ = Rule.Runtime(companyId, userId, entityType, action, entitySource);
            return processId;
        }

    }
}
