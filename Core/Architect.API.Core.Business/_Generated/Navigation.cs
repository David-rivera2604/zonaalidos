using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Navegación disponible.
    /// </summary>
    public static partial class Navigation
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla Navigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de Navigation</param>
        /// <returns>Instancia de Navigation creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.NavigationResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.Navigation item)
        {
            if (item.NavigationId.IsEmpty() || Architect.API.Core.DataAccess.General.Navigation.Count(item.NavigationId, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.NavigationId, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla Navigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de Navigation</param>
        /// <returns>Instancia de Navigation creada.</returns>
        public static Architect.API.Core.Contracts.General.NavigationResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.Navigation item)
        {
            Architect.API.Core.Contracts.General.Navigation result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Navigation.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.NavigationId.IsEmpty())
                {
                    result.NavigationId = Architect.API.Core.DataAccess.General.Navigation.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.Navigation.Create(result) > 0)
                {
                    SynchronizeRoles(companyId, userId, result.Code, result.Roles);

                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1004, result.NavigationId, companyId, "Creación", string.Format("Se creó el navegación '{0}'", result.Title), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.NavigationResult() { Navigation = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Navigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de Navigation.</returns>
        public static List<Architect.API.Core.Contracts.General.Navigation> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.Navigation> result = Architect.API.Core.DataAccess.General.Navigation.RetrieveCustom(companyId, Architect.API.Core.DataAccess.General.Navigation.FilterBuilder(filter), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.Navigation item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla Navigation por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de Navigation</returns>
        public static Architect.API.Core.Contracts.General.Navigation RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.Navigation result = Architect.API.Core.DataAccess.General.Navigation.Retrieve(id, companyId);

            if(result.IsNotEmpty())
            {
                result.Roles = DataAccess.Security.RoleMemberNavigation.RetrieveLookUpByCode(companyId, result.Code);
            }
            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla Navigation por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de Navigation</param>
        /// <returns>Instancia de Navigation actualizada.</returns>
        public static Architect.API.Core.Contracts.General.NavigationResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.Navigation item)
        {
            Architect.API.Core.Contracts.General.Navigation result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Navigation.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.NavigationId = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.Navigation.Update(result) > 0)
                {
                    SynchronizeRoles(companyId, userId, result.Code, result.Roles);
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1004, item.NavigationId, companyId, "Modificación", string.Format("Se modificó el navegación '{0}'", result.Title), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.NavigationResult() { Navigation = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla Navigation por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de Navigation eliminada.</returns>
        public static Architect.API.Core.Contracts.General.NavigationResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.Navigation result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Navigation.Validate(companyId, new Architect.API.Core.Contracts.General.Navigation() { NavigationId = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.Navigation.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.Navigation.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(1004, id, companyId, "Eliminar", string.Format("Se eliminó el navegación '{0}'", result.Title), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.NavigationResult() { Navigation = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Navigation que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.Navigation.Count(Architect.API.Core.DataAccess.General.Navigation.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla Navigation.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de Navigation</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.Navigation source, bool isnew, bool isdelete)
        {
            string group = "Navigation";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //NavigationId:
            if ((!isnew || isdelete) && source.NavigationId.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "NavigationId", Message = "Debe indicar el identificación" });
            }
            if ((!isnew || isdelete) && source.NavigationId.IsNotEmpty() && Architect.API.Core.DataAccess.General.Navigation.Count(source.NavigationId, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "NavigationId", Message = "La identificación no está registrada" });
            }
            if (isnew && source.NavigationId.IsNotEmpty() && Architect.API.Core.DataAccess.General.Navigation.Count(source.NavigationId, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "NavigationId", Message = "La identificación ya está registrada" });
            }
            if (!isdelete)
            {

                //ParentCode:
                if (source.ParentCode.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "NavigacionMenu", source.ParentCode.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "ParentCode", Message = "El valor indicado para el menú no es valido" });
                }

                //Code:
                if (source.Code.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Code", Message = "Debe indicar el código" });
                }

                //Type:
                if (source.Type.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "NavigationType", source.Type.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Type", Message = "El valor indicado para el tipo no es valido" });
                }

                //Title:
                if (source.Title.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Title", Message = "Debe indicar el título" });
                }

                //Description:

                //MenuTitle:

                //URLPath:
                if (source.URLPath.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "URLPath", Message = "Debe indicar el ruta" });
                }

                //URLHelp:

                //SmallImage:

                //BigImage:

                //Sequence:
                if (source.Sequence.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Sequence", Message = "Debe indicar el orden" });
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
        /// <param name="item">Instancia de Navigation</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.Navigation item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.ParentCode.IsNotEmpty())
                item.ParentCodeDesc = Core.Business.Common.LkpDescription(companyId, "NavigacionMenu", item.ParentCode.ToString());
            if (item.Type.IsNotEmpty())
                item.TypeDesc = Core.Business.Common.LkpDescription(companyId, "NavigationType", item.Type.ToString());
            if (item.RecordStatus.IsNotEmpty())
                item.RecordStatusDesc = Core.Business.Common.LkpDescription(companyId, "EstadoRegistro", item.RecordStatus.ToString());

        }


        private static void SynchronizeRoles(int companyId, int userId, string code, List<Utilities.Contracts.LookUpValue> currentRoles)
        {
            List<Contracts.Security.RoleMemberNavigation> roleNavigation = Architect.API.Core.DataAccess.Security.RoleMemberNavigation.RetrieveByCode(companyId, code);
            if (roleNavigation.IsEmpty())
            {
                roleNavigation = new List<Contracts.Security.RoleMemberNavigation>();
            }
            if (currentRoles.IsNotEmpty())
            {
                //Agrega un nuevo registro o se cambia uno existente                
                Contracts.Security.RoleMemberNavigation toAdd = null;
                foreach (Utilities.Contracts.LookUpValue newItem in currentRoles)
                {
                    toAdd = roleNavigation.Find(r => r.RoleId.ToString() == newItem.Code);

                    if (toAdd.IsEmpty())
                    {
                        toAdd = new Contracts.Security.RoleMemberNavigation();
                        toAdd.Id = Architect.API.Core.DataAccess.Security.RoleMemberNavigation.RetrieveLastKey() + 1;
                        roleNavigation.Add(toAdd);
                        toAdd.Code = code;
                        toAdd.RoleId = Convert.ToInt32(newItem.Code);

                        toAdd.CompanyId = companyId;
                        toAdd.UpdateUserCode = userId;
                        toAdd.UpdateDate = DateTime.Now;

                        Architect.API.Core.DataAccess.Security.RoleMemberNavigation.Create(toAdd);
                    }
                }
            }

            //Elimina los registros que no venga en la lista nueva
            if (roleNavigation?.Count > 0)
            {
                foreach (Contracts.Security.RoleMemberNavigation currentRole in roleNavigation)
                {
                    if (currentRoles.Find(r => r.Code == currentRole.RoleId.ToString()).IsEmpty())
                    {
                        Architect.API.Core.DataAccess.Security.RoleMemberNavigation.Delete(currentRole.Id, companyId);
                    }
                }
            }
        }

    }
}
