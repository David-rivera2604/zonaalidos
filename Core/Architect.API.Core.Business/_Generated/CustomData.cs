using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Roles de seguridad.
    /// </summary>
    public static partial class CustomData
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla CustomData.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de CustomData</param>
        /// <returns>Instancia de CustomData creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.CustomDataResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.CustomData item)
        {
            if (item.Id.IsEmpty() || Architect.API.Core.DataAccess.General.CustomData.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla CustomData.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de CustomData</param>
        /// <returns>Instancia de CustomData creada.</returns>
        public static Architect.API.Core.Contracts.General.CustomDataResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.CustomData item)
        {
            Architect.API.Core.Contracts.General.CustomData result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.CustomData.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Core.DataAccess.General.CustomData.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.CustomData.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.CustomDataResult() { CustomData = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla CustomData.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de CustomData.</returns>
        public static List<Architect.API.Core.Contracts.General.CustomData> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.CustomData> result = Architect.API.Core.DataAccess.General.CustomData.RetrieveAll(companyId, filter, beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.CustomData item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla CustomData por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de CustomData</returns>
        public static Architect.API.Core.Contracts.General.CustomData RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.CustomData result = Architect.API.Core.DataAccess.General.CustomData.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla CustomData por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de CustomData</param>
        /// <returns>Instancia de CustomData actualizada.</returns>
        public static Architect.API.Core.Contracts.General.CustomDataResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.CustomData item)
        {
            Architect.API.Core.Contracts.General.CustomData result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.CustomData.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.CustomData.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.CustomDataResult() { CustomData = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla CustomData por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de CustomData eliminada.</returns>
        public static Architect.API.Core.Contracts.General.CustomDataResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.CustomData result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.CustomData.Validate(companyId, new Architect.API.Core.Contracts.General.CustomData() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.CustomData.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.CustomData.Delete(id, companyId) > 0)
                {
                }
            }
            return new Architect.API.Core.Contracts.General.CustomDataResult() { CustomData = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla CustomData que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.CustomData.Count(Architect.API.Core.DataAccess.General.CustomData.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla CustomData.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de CustomData</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.CustomData source, bool isnew, bool isdelete)
        {
            string group = "CustomData";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el identificador del CustomData" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.CustomData.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificador del CustomData no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.CustomData.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificador del CustomData ya está registrada" });
            }
            if (!isdelete)
            {
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="item">Instancia de CustomData</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.CustomData item)
        {
            if (item.IsEmpty())
            {
                return;
            }

        }

    }
}
