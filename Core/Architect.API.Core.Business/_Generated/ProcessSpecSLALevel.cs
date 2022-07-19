using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// ProcessSpecSLALevel
    /// </summary>
    public static partial class ProcessSpecSLALevel
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla ProcessSpecSLALevel.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecSLALevel</param>
        /// <returns>Instancia de ProcessSpecSLALevel creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecSLALevelResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecSLALevel item)
        {
            if (item.Id.IsEmpty() || Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecSLALevel.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecSLALevel</param>
        /// <returns>Instancia de ProcessSpecSLALevel creada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecSLALevelResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecSLALevel item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecSLALevel result = item;
            List<Core.Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecSLALevel.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(0000, result.Id, companyId, "Creación", string.Format("Se creó un registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecSLALevelResult() { ProcessSpecSLALevel = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecSLALevel.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de ProcessSpecSLALevel.</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecSLALevel> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecSLALevel> result = Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.RetrieveAll(companyId, Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.FilterBuilder(filter, false), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.ProcessSpecSLALevel item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla ProcessSpecSLALevel por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecSLALevel</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecSLALevel RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessSpecSLALevel result = Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecSLALevel por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de ProcessSpecSLALevel</param>
        /// <returns>Instancia de ProcessSpecSLALevel actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecSLALevelResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.ProcessSpecSLALevel item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecSLALevel result = null;
            List<Core.Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecSLALevel.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(0000, item.Id, companyId, "Modificación", string.Format("Se modificó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecSLALevelResult() { ProcessSpecSLALevel = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla ProcessSpecSLALevel por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecSLALevel eliminada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecSLALevelResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessSpecSLALevel result = null;
            List<Core.Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecSLALevel.Validate(companyId, new Architect.API.Core.Contracts.General.ProcessSpecSLALevel() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(0000, id, companyId, "Eliminar", string.Format("Se eliminó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecSLALevelResult() { ProcessSpecSLALevel = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecSLALevel que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.Count(Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla ProcessSpecSLALevel.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de ProcessSpecSLALevel</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.ProcessSpecSLALevel source, bool isnew, bool isdelete)
        {
            string group = "ProcessSpecSLALevel";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el proceso" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La proceso no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecSLALevel.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La proceso ya está registrada" });
            }
            if (!isdelete)
            {

                //SLAId:

                //SLATimeOut:

                //SLATimeMode:

                //MailForSLAExpiration:
                if (source.MailForSLAExpiration.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "MailSendOptions", source.MailForSLAExpiration.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MailForSLAExpiration", Message = "El valor indicado para el mail for sla expiration no es valido" });
                }

                //MailForSLAExpirationCustom:

                //MailForSLAExpirationTmpl:
                if (source.MailForSLAExpirationTmpl.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "MailTemplate", source.MailForSLAExpirationTmpl.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MailForSLAExpirationTmpl", Message = "El valor indicado para el mail for slae xpiration tmpl no es valido" });
                }
            }

            return result;
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
