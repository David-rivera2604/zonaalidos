using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// .
    /// </summary>
    public static partial class PaymentSettings
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla PaymentSettings.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de PaymentSettings</param>
        /// <returns>Instancia de PaymentSettings creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.PaymentSettingsResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.PaymentSettings item)
        {
            if (item.Id.IsEmpty() || Architect.API.Core.DataAccess.General.PaymentSettings.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla PaymentSettings.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de PaymentSettings</param>
        /// <returns>Instancia de PaymentSettings creada.</returns>
        public static Architect.API.Core.Contracts.General.PaymentSettingsResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.PaymentSettings item)
        {
            Architect.API.Core.Contracts.General.PaymentSettings result = item;
            List<Core.Contracts.General.Error> errors = Architect.API.Core.Business.General.PaymentSettings.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Core.DataAccess.General.PaymentSettings.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.PaymentSettings.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1004, result.Id, companyId, "Creación", string.Format("Se creó un registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.PaymentSettingsResult() { PaymentSettings = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla PaymentSettings.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de PaymentSettings.</returns>
        public static List<Architect.API.Core.Contracts.General.PaymentSettings> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.PaymentSettings> result = Architect.API.Core.DataAccess.General.PaymentSettings.RetrieveAll(companyId, Architect.API.Core.DataAccess.General.PaymentSettings.FilterBuilder(filter, false), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.PaymentSettings item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla PaymentSettings por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de PaymentSettings</returns>
        public static Architect.API.Core.Contracts.General.PaymentSettings RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.PaymentSettings result = Architect.API.Core.DataAccess.General.PaymentSettings.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla PaymentSettings por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de PaymentSettings</param>
        /// <returns>Instancia de PaymentSettings actualizada.</returns>
        public static Architect.API.Core.Contracts.General.PaymentSettingsResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.PaymentSettings item)
        {
            Architect.API.Core.Contracts.General.PaymentSettings result = null;
            List<Core.Contracts.General.Error> errors = Architect.API.Core.Business.General.PaymentSettings.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.PaymentSettings.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1004, item.Id, companyId, "Modificación", string.Format("Se modificó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.PaymentSettingsResult() { PaymentSettings = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla PaymentSettings por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de PaymentSettings eliminada.</returns>
        public static Architect.API.Core.Contracts.General.PaymentSettingsResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.PaymentSettings result = null;
            List<Core.Contracts.General.Error> errors = Architect.API.Core.Business.General.PaymentSettings.Validate(companyId, new Architect.API.Core.Contracts.General.PaymentSettings() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.PaymentSettings.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.PaymentSettings.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(1004, id, companyId, "Eliminar", string.Format("Se eliminó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.PaymentSettingsResult() { PaymentSettings = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla PaymentSettings que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.PaymentSettings.Count(Architect.API.Core.DataAccess.General.PaymentSettings.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla PaymentSettings.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de PaymentSettings</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.PaymentSettings source, bool isnew, bool isdelete)
        {
            string group = "PaymentSettings";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el id" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.PaymentSettings.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La id no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.PaymentSettings.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La id ya está registrada" });
            }
            if (!isdelete)
            {

                //UserId:
                if (source.UserId.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "UserId", Message = "Debe indicar el usuario" });
                }
                if (source.UserId.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "Users", source.UserId.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "UserId", Message = "El valor indicado para el usuario no es valido" });
                }

                //Currency:
                if (source.Currency.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Currency", Message = "Debe indicar el moneda" });
                }
                if (source.Currency.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "Currencies", source.Currency.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Currency", Message = "El valor indicado para el moneda no es valido" });
                }

                //ClientId:
                if (source.ClientId.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "ClientId", Message = "Debe indicar el client id" });
                }

                //SecretKey:
                if (source.SecretKey.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "SecretKey", Message = "Debe indicar el secret key" });
                }
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="item">Instancia de PaymentSettings</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.PaymentSettings item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.UserId.IsNotEmpty())
                item.UserIdDesc = Core.Business.Common.LkpDescription(companyId, "Users", item.UserId.ToString());
            if (item.Currency.IsNotEmpty())
                item.CurrencyDesc = Core.Business.Common.LkpDescription(companyId, "Currencies", item.Currency.ToString());

        }

    }
}
