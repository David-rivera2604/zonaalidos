using System;
using System.Collections.Generic;
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
        /// <param name="companyId">Identificación de lacompañia propietaria.</param>
        /// <returns>Lista optimizada para consulta del seguimiento de los cambios.</returns>
        public static List<Contracts.General.ChangeSetView> RetrieveByEntity(int entityType, Int64 entityId, int companyId, string filter)
        {
            return Core.DataAccess.General.ChangeSet.RetrieveByEntity(entityType, entityId, companyId, filter);
        }

        /// <summary>
        /// Crear un registro para el segguimiento de un cambio.
        /// </summary>
        /// <param name="entityType">Tipo de entidad.</param>
        /// <param name="entityId">Identificación de la entidad.</param>
        /// <param name="companyId">Identificación de lacompañia propietaria.</param>
        /// <param name="action">Acción que da origen al cambio.</param>
        /// <param name="summary">Detalle del cambio.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="entitySource">Instancia de la entidad que orginal el evento.</param>
        public static void Create(int entityType, int entityId, int companyId, string action, string summary, int userId, object entitySource)
        {
            Core.Contracts.General.ChangeSet item = new Core.Contracts.General.ChangeSet
            {
                Id = Core.DataAccess.General.ChangeSet.RetrieveLastKey() + 1,
                EntityType = entityType,
                EntityId = entityId,
                CompanyId = companyId,
                Action = action,
                Summary = summary,
                UpdateUserCode = userId,
                UpdateDate = DateTime.Now
            };
            Core.DataAccess.General.ChangeSet.Create(item);

            Task.Run(() => Rule.Runtime(companyId, userId, entityType, action, entitySource));
            //_ = Rule.Runtime(companyId, userId, entityType, action, entitySource);
        }
    }
}
