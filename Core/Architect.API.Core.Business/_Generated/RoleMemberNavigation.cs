using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.Security
{
    /// <summary>
    /// Navegación permitidas por rol de usuario..
    /// </summary>
    public static partial class RoleMemberNavigation
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla RoleMemberNavigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de RoleMemberNavigation</param>
        /// <returns>Instancia de RoleMemberNavigation creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.Security.RoleMemberNavigationResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.Security.RoleMemberNavigation item)
        {
            if (item.Id.IsEmpty() || Architect.API.Core.DataAccess.Security.RoleMemberNavigation.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla RoleMemberNavigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de RoleMemberNavigation</param>
        /// <returns>Instancia de RoleMemberNavigation creada.</returns>
        public static Architect.API.Core.Contracts.Security.RoleMemberNavigationResult Create(int companyId, int userId, Architect.API.Core.Contracts.Security.RoleMemberNavigation item)
        {
            Architect.API.Core.Contracts.Security.RoleMemberNavigation result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.Security.RoleMemberNavigation.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Core.DataAccess.Security.RoleMemberNavigation.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.Security.RoleMemberNavigation.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1005, result.Id, companyId, "Creación", string.Format("Se creó un registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.Security.RoleMemberNavigationResult() { RoleMemberNavigation = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla RoleMemberNavigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de RoleMemberNavigation.</returns>
        public static List<Architect.API.Core.Contracts.Security.RoleMemberNavigation> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.Security.RoleMemberNavigation> result = Architect.API.Core.DataAccess.Security.RoleMemberNavigation.RetrieveAll(companyId, Architect.API.Core.DataAccess.Security.RoleMemberNavigation.FilterBuilder(filter), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.Security.RoleMemberNavigation item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla RoleMemberNavigation por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de RoleMemberNavigation</returns>
        public static Architect.API.Core.Contracts.Security.RoleMemberNavigation RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.Security.RoleMemberNavigation result = Architect.API.Core.DataAccess.Security.RoleMemberNavigation.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla RoleMemberNavigation por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de RoleMemberNavigation</param>
        /// <returns>Instancia de RoleMemberNavigation actualizada.</returns>
        public static Architect.API.Core.Contracts.Security.RoleMemberNavigationResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.Security.RoleMemberNavigation item)
        {
            Architect.API.Core.Contracts.Security.RoleMemberNavigation result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.Security.RoleMemberNavigation.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.Security.RoleMemberNavigation.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1005, item.Id, companyId, "Modificación", string.Format("Se modificó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.Security.RoleMemberNavigationResult() { RoleMemberNavigation = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla RoleMemberNavigation por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de RoleMemberNavigation eliminada.</returns>
        public static Architect.API.Core.Contracts.Security.RoleMemberNavigationResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.Security.RoleMemberNavigation result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.Security.RoleMemberNavigation.Validate(companyId, new Architect.API.Core.Contracts.Security.RoleMemberNavigation() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.Security.RoleMemberNavigation.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.Security.RoleMemberNavigation.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(1005, id, companyId, "Eliminar", string.Format("Se eliminó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.Security.RoleMemberNavigationResult() { RoleMemberNavigation = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla RoleMemberNavigation que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.Security.RoleMemberNavigation.Count(Architect.API.Core.DataAccess.Security.RoleMemberNavigation.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla RoleMemberNavigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="source">Instancia de RoleMemberNavigation</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.Security.RoleMemberNavigation source, bool isnew, bool isdelete)
        {
            string group = "RoleMemberNavigation";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el identificación" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.Security.RoleMemberNavigation.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificación no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.Security.RoleMemberNavigation.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificación ya está registrada" });
            }

            //Code:
            if ((!isnew || isdelete) && source.Code.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Code", Message = "Debe indicar el página" });
            }
            //if ((!isnew || isdelete) && source.Code.IsNotEmpty() && Architect.API.Core.DataAccess.Security.RoleMemberNavigation.Count(source.Code, companyId) == 0)
            //{
            //    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Code", Message = "La página no está registrada" });
            //}
            //if (isnew && source.Code.IsNotEmpty() && Architect.API.Core.DataAccess.Security.RoleMemberNavigation.Count(source.Code, companyId) > 0)
            //{
            //    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Code", Message = "La página ya está registrada" });
            //}
            if (!isdelete)
            {

                //RoleId:
                if (source.RoleId.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "RoleId", Message = "Debe indicar el role" });
                }

                //Allow:

                //SecurityLevel:
                if (source.SecurityLevel.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "SecurityLevel", Message = "Debe indicar el seguridad" });
                }

                //CreateAction:

                //ReadAction:

                //UpdateAction:

                //DeleteAction:

                //ListAction:

                //PrintAction:
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="item">Instancia de RoleMemberNavigation</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.Security.RoleMemberNavigation item)
        {
            if (item.IsEmpty())
            {
                return;
            }

        }

    }
}
