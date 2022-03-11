using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.Security
{
    /// <summary>
    /// Roles de seguridad.
    /// </summary>
    public static partial class RoleMember
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla RoleMember.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de RoleMember</param>
        /// <returns>Instancia de RoleMember creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.Security.RoleMemberResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.Security.RoleMember item)
        {
            if (item.RoleId.IsEmpty() || Architect.API.Core.DataAccess.Security.RoleMember.Count(item.RoleId, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.RoleId, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla RoleMember.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de RoleMember</param>
        /// <returns>Instancia de RoleMember creada.</returns>
        public static Architect.API.Core.Contracts.Security.RoleMemberResult Create(int companyId, int userId, Architect.API.Core.Contracts.Security.RoleMember item)
        {
            Architect.API.Core.Contracts.Security.RoleMember result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.Security.RoleMember.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.RoleId.IsEmpty())
                {
                    result.RoleId = Architect.API.Core.DataAccess.Security.RoleMember.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.Security.RoleMember.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1001, result.RoleId, companyId, "Creación", string.Format("Se creó el rol '{0}'", result.RoleName), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.Security.RoleMemberResult() { RoleMember = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla RoleMember.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de RoleMember.</returns>
        public static List<Architect.API.Core.Contracts.Security.RoleMember> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.Security.RoleMember> result = Architect.API.Core.DataAccess.Security.RoleMember.RetrieveAll(companyId, filter, beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.Security.RoleMember item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla RoleMember por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de RoleMember</returns>
        public static Architect.API.Core.Contracts.Security.RoleMember RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.Security.RoleMember result = Architect.API.Core.DataAccess.Security.RoleMember.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla RoleMember por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de RoleMember</param>
        /// <returns>Instancia de RoleMember actualizada.</returns>
        public static Architect.API.Core.Contracts.Security.RoleMemberResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.Security.RoleMember item)
        {
            Architect.API.Core.Contracts.Security.RoleMember result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.Security.RoleMember.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.RoleId = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.Security.RoleMember.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1001, item.RoleId, companyId, "Modificación", string.Format("Se modificó el rol '{0}'", result.RoleName), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.Security.RoleMemberResult() { RoleMember = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla RoleMember por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de RoleMember eliminada.</returns>
        public static Architect.API.Core.Contracts.Security.RoleMemberResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.Security.RoleMember result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.Security.RoleMember.Validate(companyId, new Architect.API.Core.Contracts.Security.RoleMember() { RoleId = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.Security.RoleMember.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.Security.RoleMember.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(1001, id, companyId, "Eliminar", string.Format("Se eliminó el rol '{0}'", result.RoleName), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.Security.RoleMemberResult() { RoleMember = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla RoleMember que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.Security.RoleMember.Count(Architect.API.Core.DataAccess.Security.RoleMember.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla RoleMember.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de RoleMember</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.Security.RoleMember source, bool isnew, bool isdelete)
        {
            string group = "RoleMember";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //RoleId:
            if ((!isnew || isdelete) && source.RoleId.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "RoleId", Message = "Debe indicar el identificador del rol" });
            }
            if ((!isnew || isdelete) && source.RoleId.IsNotEmpty() && Architect.API.Core.DataAccess.Security.RoleMember.Count(source.RoleId, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "RoleId", Message = "La identificador del rol no está registrada" });
            }
            if (isnew && source.RoleId.IsNotEmpty() && Architect.API.Core.DataAccess.Security.RoleMember.Count(source.RoleId, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "RoleId", Message = "La identificador del rol ya está registrada" });
            }
            if (!isdelete)
            {

                //RoleName:
                if (source.RoleName.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "RoleName", Message = "Debe indicar el nombre del rol" });
                }

                //Description:

                //SecurityLevel:

                //InitialNavigationCode:
                if (source.InitialNavigationCode.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "NavigacionPage", source.InitialNavigationCode.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "InitialNavigationCode", Message = "El valor indicado para el página inicial no es valido" });
                }

                //RecordStatus:
                if (source.RecordStatus.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "RecordStatus", Message = "Debe indicar el estado del registro" });
                }
                if (source.RecordStatus.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "EstadoRegistro", source.RecordStatus.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "RecordStatus", Message = "El valor indicado para el estado del registro no es valido" });
                }
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="item">Instancia de RoleMember</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.Security.RoleMember item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.InitialNavigationCode.IsNotEmpty())
                item.InitialNavigationCodeDesc = Core.Business.Common.LkpDescription(companyId, "NavigacionPage", item.InitialNavigationCode.ToString());
            if (item.RecordStatus.IsNotEmpty())
                item.RecordStatusDesc = Core.Business.Common.LkpDescription(companyId, "EstadoRegistro", item.RecordStatus.ToString());

        }

    }
}
