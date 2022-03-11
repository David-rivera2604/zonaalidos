using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// ProcessSpecStepRole
    /// </summary>
    public static partial class ProcessSpecStepRole
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla ProcessSpecStepRole.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecStepRole</param>
        /// <returns>Instancia de ProcessSpecStepRole creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStepRoleResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecStepRole item)
        {
            if (item.Id.IsEmpty() || Architect.API.Core.DataAccess.General.ProcessSpecStepRole.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecStepRole.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecStepRole</param>
        /// <returns>Instancia de ProcessSpecStepRole creada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStepRoleResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecStepRole item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecStepRole result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecStepRole.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Core.DataAccess.General.ProcessSpecStepRole.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecStepRole.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(0000, result.Id, companyId, "Creación", string.Format("Se creó un registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecStepRoleResult() { ProcessSpecStepRole = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecStepRole.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de ProcessSpecStepRole.</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecStepRole> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecStepRole> result = Architect.API.Core.DataAccess.General.ProcessSpecStepRole.RetrieveAll(companyId, Architect.API.Core.DataAccess.General.ProcessSpecStepRole.FilterBuilder(filter), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.ProcessSpecStepRole item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla ProcessSpecStepRole por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecStepRole</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStepRole RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessSpecStepRole result = Architect.API.Core.DataAccess.General.ProcessSpecStepRole.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecStepRole por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de ProcessSpecStepRole</param>
        /// <returns>Instancia de ProcessSpecStepRole actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStepRoleResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.ProcessSpecStepRole item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecStepRole result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecStepRole.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecStepRole.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(0000, item.Id, companyId, "Modificación", string.Format("Se modificó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecStepRoleResult() { ProcessSpecStepRole = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla ProcessSpecStepRole por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecStepRole eliminada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStepRoleResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessSpecStepRole result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecStepRole.Validate(companyId, new Architect.API.Core.Contracts.General.ProcessSpecStepRole() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.ProcessSpecStepRole.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecStepRole.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(0000, id, companyId, "Eliminar", string.Format("Se eliminó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecStepRoleResult() { ProcessSpecStepRole = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecStepRole que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.ProcessSpecStepRole.Count(Architect.API.Core.DataAccess.General.ProcessSpecStepRole.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla ProcessSpecStepRole.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de ProcessSpecStepRole</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.ProcessSpecStepRole source, bool isnew, bool isdelete)
        {
            string group = "ProcessSpecStepRole";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el paso" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecStepRole.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La paso no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecStepRole.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La paso ya está registrada" });
            }
            if (!isdelete)
            {

                //RoleId:
                if (source.RoleId.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "RoleId", Message = "Debe indicar el identificador del rol" });
                }
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="item">Instancia de ProcessSpecStepRole</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.ProcessSpecStepRole item)
        {
            if (item.IsEmpty())
            {
                return;
            }

        }

    }
}
