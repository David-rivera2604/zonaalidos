using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Lista de valores disponibles.
    /// </summary>
    public static partial class Lookup
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla Lookup.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de Lookup</param>
        /// <returns>Instancia de Lookup creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.LookupResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.Lookup item)
        {
            if (item.LookupId.IsEmpty() || Architect.API.Core.DataAccess.General.Lookup.Count(item.LookupId, companyId, 0, 0, 0, 0, 0) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.LookupId, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla Lookup.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de Lookup</param>
        /// <returns>Instancia de Lookup creada.</returns>
        public static Architect.API.Core.Contracts.General.LookupResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.Lookup item)
        {
            Architect.API.Core.Contracts.General.Lookup result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Lookup.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.LookupId.IsEmpty())
                {
                    result.LookupId = Architect.API.Core.DataAccess.General.Lookup.RetrieveLastKey(0, 0, 0, 0, 0) + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.Lookup.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1021, result.LookupId, companyId, "Creación", string.Format("Se creó el lookup '{0}'", result.Description), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.LookupResult() { Lookup = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Lookup.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de Lookup.</returns>
        public static List<Architect.API.Core.Contracts.General.Lookup> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.Lookup> result = Architect.API.Core.DataAccess.General.Lookup.RetrieveAll(companyId, Architect.API.Core.DataAccess.General.Lookup.FilterBuilder(filter), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.Lookup item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de Lookup</returns>
        public static Architect.API.Core.Contracts.General.Lookup RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.Lookup result = Architect.API.Core.DataAccess.General.Lookup.Retrieve(id, companyId, 0, 0, 0, 0, 0);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de Lookup</param>
        /// <returns>Instancia de Lookup actualizada.</returns>
        public static Architect.API.Core.Contracts.General.LookupResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.Lookup item)
        {
            Architect.API.Core.Contracts.General.Lookup result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Lookup.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.LookupId = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.Lookup.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1021, item.LookupId, companyId, "Modificación", string.Format("Se modificó el lookup '{0}'", result.Description), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.LookupResult() { Lookup = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de Lookup eliminada.</returns>
        public static Architect.API.Core.Contracts.General.LookupResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.Lookup result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Lookup.Validate(companyId, new Architect.API.Core.Contracts.General.Lookup() { LookupId = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.Lookup.Retrieve(id, companyId, 0, 0, 0, 0, 0);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.Lookup.Delete(id, companyId, 0, 0, 0, 0, 0) > 0)
                {
                    Core.Business.General.ChangeSet.Create(1021, id, companyId, "Eliminar", string.Format("Se eliminó el lookup '{0}'", result.Description), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.LookupResult() { Lookup = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Lookup que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.Lookup.Count(Architect.API.Core.DataAccess.General.Lookup.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla Lookup.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de Lookup</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.Lookup source, bool isnew, bool isdelete)
        {
            string group = "Lookup";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //LookupId:
            if ((!isnew || isdelete) && source.LookupId.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "LookupId", Message = "Debe indicar el lookup id" });
            }
            if ((!isnew || isdelete) && source.LookupId.IsNotEmpty() && Architect.API.Core.DataAccess.General.Lookup.Count(source.LookupId, companyId, 0, 0, 0, 0, 0) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "LookupId", Message = "La lookup id no está registrada" });
            }
            if (isnew && source.LookupId.IsNotEmpty() && Architect.API.Core.DataAccess.General.Lookup.Count(source.LookupId, companyId,0,0,0,0,0) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "LookupId", Message = "La lookup id ya está registrada" });
            }
            if (!isdelete)
            {

                //Language:
                if (source.Language.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Language", Message = "Debe indicar el lenguaje" });
                }
                if (source.Language.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "Lenguaje", source.Language.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Language", Message = "El valor indicado para el lenguaje no es valido" });
                }

                //ParentLookupId:
                if (source.ParentLookupId.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "ParentLookupId", Message = "Debe indicar el parent lookup id" });
                }

                //SubParentLookupId:
                if (source.SubParentLookupId.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "SubParentLookupId", Message = "Debe indicar el sub parent lookup id" });
                }

                //Code:
                if (source.Code.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Code", Message = "Debe indicar el código" });
                }

                //Description:
                if (source.Description.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Description", Message = "Debe indicar el descripción" });
                }

                //QueryOrder:

                //HomologousCode:

                //ExtendNumberValue1:

                //ExtendNumberValue2:

                //ExtendStringValue1:

                //ExtendStringValue2:

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
        /// <param name="item">Instancia de Lookup</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.Lookup item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.Language.IsNotEmpty())
                item.LanguageDesc = Core.Business.Common.LkpDescription(companyId, "Lenguaje", item.Language.ToString());
            if (item.RecordStatus.IsNotEmpty())
                item.RecordStatusDesc = Core.Business.Common.LkpDescription(companyId, "EstadoRegistro", item.RecordStatus.ToString());

        }

    }
}
