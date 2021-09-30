using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Maestro de lista de valores disponibles.
    /// </summary>
    public static partial class LookupMaster
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla LookupMaster.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de LookupMaster</param>
        /// <returns>Instancia de LookupMaster creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.LookupMasterResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.LookupMaster item)
        {
            if (item.LookupId.IsEmpty() || Architect.API.Core.DataAccess.General.LookupMaster.Count(item.LookupId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.LookupId, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla LookupMaster.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de LookupMaster</param>
        /// <returns>Instancia de LookupMaster creada.</returns>
        public static Architect.API.Core.Contracts.General.LookupMasterResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.LookupMaster item)
        {
            Architect.API.Core.Contracts.General.LookupMaster result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.LookupMaster.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.LookupId.IsEmpty())
                {
                    result.LookupId = Architect.API.Core.DataAccess.General.LookupMaster.RetrieveLastKey() + 1;
                }
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.LookupMaster.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1020, result.LookupId, companyId, "Creación", string.Format("Se creó el lookup master '{0}'", result.Description), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.LookupMasterResult() { LookupMaster = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla LookupMaster.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de LookupMaster.</returns>
        public static List<Architect.API.Core.Contracts.General.LookupMaster> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.LookupMaster> result = Architect.API.Core.DataAccess.General.LookupMaster.RetrieveAll( Architect.API.Core.DataAccess.General.LookupMaster.FilterBuilder(filter), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.LookupMaster item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla LookupMaster por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de LookupMaster</returns>
        public static Architect.API.Core.Contracts.General.LookupMaster RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.LookupMaster result = Architect.API.Core.DataAccess.General.LookupMaster.Retrieve(id);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla LookupMaster por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de LookupMaster</param>
        /// <returns>Instancia de LookupMaster actualizada.</returns>
        public static Architect.API.Core.Contracts.General.LookupMasterResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.LookupMaster item)
        {
            Architect.API.Core.Contracts.General.LookupMaster result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.LookupMaster.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.LookupId = id;
           
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.LookupMaster.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1020, item.LookupId, companyId, "Modificación", string.Format("Se modificó el lookup master '{0}'", result.Description), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.LookupMasterResult() { LookupMaster = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla LookupMaster por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de LookupMaster eliminada.</returns>
        public static Architect.API.Core.Contracts.General.LookupMasterResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.LookupMaster result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.LookupMaster.Validate(companyId, new Architect.API.Core.Contracts.General.LookupMaster() { LookupId = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.LookupMaster.Retrieve(id);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.LookupMaster.Delete(id) > 0)
                {
                    Core.Business.General.ChangeSet.Create(1020, id, companyId, "Eliminar", string.Format("Se eliminó el lookup master '{0}'", result.Description), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.LookupMasterResult() { LookupMaster = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla LookupMaster que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.LookupMaster.Count(Architect.API.Core.DataAccess.General.LookupMaster.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla LookupMaster.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="source">Instancia de LookupMaster</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.LookupMaster source, bool isnew, bool isdelete)
        {
            string group = "LookupMaster";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //LookupId:
            if ((!isnew || isdelete) && source.LookupId.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "LookupId", Message = "Debe indicar el identificación" });
            }
            if ((!isnew || isdelete) && source.LookupId.IsNotEmpty() && Architect.API.Core.DataAccess.General.LookupMaster.Count(source.LookupId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "LookupId", Message = "La identificación no está registrada" });
            }
            if (isnew && source.LookupId.IsNotEmpty() && Architect.API.Core.DataAccess.General.LookupMaster.Count(source.LookupId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "LookupId", Message = "La identificación ya está registrada" });
            }
            if (!isdelete)
            {

                //Type:
                if (source.Type.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Type", Message = "Debe indicar el tipo" });
                }
                if (source.Type.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "LookupType", source.Type.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Type", Message = "El valor indicado para el tipo no es valido" });
                }

                //Description:
                if (source.Description.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Description", Message = "Debe indicar el descripción" });
                }

                //Key:
                if (source.Key.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Key", Message = "Debe indicar el clave" });
                }
                if (source.Key.IsNotEmpty() && Architect.API.Core.DataAccess.General.LookupMaster.CountByKey(source.LookupId, source.Key) > 0)
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Key", Message = "La clave ya está registrada" });
                }

                //Tenant:

                //Statement:

                //IsCached:

                //ConnectionName:

                //IncludeByRole:

                //ExcludeByRole:

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
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="item">Instancia de LookupMaster</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.LookupMaster item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.Type.IsNotEmpty())
                item.TypeDesc = Core.Business.Common.LkpDescription(companyId, "LookupType", item.Type.ToString());
            if (item.RecordStatus.IsNotEmpty())
                item.RecordStatusDesc = Core.Business.Common.LkpDescription(companyId, "EstadoRegistro", item.RecordStatus.ToString());

        }

    }
}
