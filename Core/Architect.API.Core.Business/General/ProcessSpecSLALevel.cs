using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// .
    /// </summary>
    public static partial class ProcessSpecSLALevel
    {
        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecSLALevel.
        /// </summary>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecSLALevel> Retrieve(int companyId, int slaId )
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecSLALevel> result = Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.RetrieveAll(companyId, slaId);

            foreach (Architect.API.Core.Contracts.General.ProcessSpecSLALevel item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Crea un grupo de registros en la tabla ProcessSpecSLALevel.
        /// </summary>
        public static void Create(int companyId, int userId, int slaId, List< Architect.API.Core.Contracts.General.ProcessSpecSLALevel> levels)
        {
            if (levels != null)
            {
                int last = Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.RetrieveLastKey()+1;
                foreach (Architect.API.Core.Contracts.General.ProcessSpecSLALevel level in levels)
                {
                    level.Id = last++;
                    level.SLAId = slaId;
                    level.CompanyId = companyId;
                    level.UpdateUserCode = userId;
                    level.UpdateDate = DateTime.Now;
                }
                Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.Create(levels);
            }
        }

        /// <summary>
        /// Actualiza un grupo de registros en la tabla ProcessSpecSLALevel.
        /// </summary>
        public static void Update(int companyId, int userId, int slaId, List<Architect.API.Core.Contracts.General.ProcessSpecSLALevel> levels)
        {
            Delete(companyId, slaId);
            if (levels != null)
            {
                Create(companyId, userId, slaId, levels);
            }
        }

        /// <summary>
        /// Elimina un registro en la tabla ProcessSpecSLALevel por medio de su clave primaria.
        /// </summary>
        public static void Delete(int companyId, int slaId)
        {
            Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.DeleteBySLAId(slaId, companyId);
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="item">Instancia de ProcessSpecSLALevel</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.ProcessSpecSLALevel item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.MailForSLAExpiration.IsNotEmpty())
                item.MailForSLAExpirationDesc = Core.Business.Common.LkpDescription(companyId, "MailSendOptions", item.MailForSLAExpiration.ToString());
            if (item.MailForSLAExpirationTmpl.IsNotEmpty())
                item.MailForSLAExpirationTmplDesc = Core.Business.Common.LkpDescription(companyId, "MailTemplate", item.MailForSLAExpirationTmpl.ToString());

        }

    }
}
