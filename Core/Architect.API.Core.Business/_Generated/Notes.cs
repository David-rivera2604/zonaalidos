using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Notas.
    /// </summary>
    public static partial class Notes
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla Notes.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de Notes</param>
        /// <returns>Instancia de Notes creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.NotesResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.Notes item)
        {
            if (item.Id.IsEmpty() || Architect.API.Core.DataAccess.General.Notes.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla Notes.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de Notes</param>
        /// <returns>Instancia de Notes creada.</returns>
        public static Architect.API.Core.Contracts.General.NotesResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.Notes item)
        {
            Architect.API.Core.Contracts.General.Notes result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Notes.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Core.DataAccess.General.Notes.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.Notes.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    //Core.Business.General.ChangeSet.Create(1004, result.Id, companyId, "Creación", string.Format("Se creó un registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.NotesResult() { Notes = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Notes.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de Notes.</returns>
        public static List<Architect.API.Core.Contracts.General.Notes> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.Notes> result = Architect.API.Core.DataAccess.General.Notes.RetrieveAll(companyId, Architect.API.Core.DataAccess.General.Notes.FilterBuilder(filter), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.Notes item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla Notes por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de Notes</returns>
        public static Architect.API.Core.Contracts.General.Notes RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.Notes result = Architect.API.Core.DataAccess.General.Notes.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla Notes por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de Notes</param>
        /// <returns>Instancia de Notes actualizada.</returns>
        public static Architect.API.Core.Contracts.General.NotesResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.Notes item)
        {
            Architect.API.Core.Contracts.General.Notes result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Notes.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.Notes.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    //Core.Business.General.ChangeSet.Create(1004, item.Id, companyId, "Modificación", string.Format("Se modificó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.NotesResult() { Notes = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla Notes por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de Notes eliminada.</returns>
        public static Architect.API.Core.Contracts.General.NotesResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.Notes result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Notes.Validate(companyId, new Architect.API.Core.Contracts.General.Notes() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.Notes.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.Notes.Delete(id, companyId) > 0)
                {
                    //Core.Business.General.ChangeSet.Create(1004, id, companyId, "Eliminar", string.Format("Se eliminó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.NotesResult() { Notes = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Notes que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.Notes.Count(Architect.API.Core.DataAccess.General.Notes.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla Notes.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="source">Instancia de Notes</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.Notes source, bool isnew, bool isdelete)
        {
            string group = "Notes";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el identificación" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.Notes.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificación no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.Notes.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificación ya está registrada" });
            }
            if (!isdelete)
            {

                //EntityType:
                if (source.EntityType.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "EntityType", source.EntityType.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "EntityType", Message = "El valor indicado para el tipo de entidad no es valido" });
                }

                //EntityId:

                //Note:

                //Private:

                //NoteOwnerId:

                //ParentSequence:
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="item">Instancia de Notes</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.Notes item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.EntityType.IsNotEmpty())
                item.EntityTypeDesc = Core.Business.Common.LkpDescription(companyId, "EntityType", item.EntityType.ToString());

        }

    }
}
