using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Architect.API.Core.Business.Traza
{
    /// <summary>
    /// Traza de solicitudes y respuestas.
    /// </summary>
    public static partial class TrackRequest
    {


        /// <summary>
        /// Crea un registro en la tabla TrackRequest.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de TrackRequest</param>
        /// <returns>Instancia de TrackRequest creada.</returns>
        public static Core.Contracts.Traza.TrackRequest Add(int companyId, int userId, Core.Contracts.Traza.TrackRequest item)
        {
            item.CompanyId = companyId;
            item.UpdateUserCode = userId;
            item.UpdateDate = DateTime.Now;

            item.Id = Core.DataAccess.Traza.TrackRequest.Create(item);

            return item;
        }

        public static void Update(int companyId, int userId, int id, Core.Contracts.Traza.TrackRequest item)
        {
            item.Id = id;
            item.CompanyId = companyId;
            item.UpdateUserCode = userId;
            item.UpdateDate = DateTime.Now;
            Core.DataAccess.Traza.TrackRequest.Update2(item);
        }

        public static Core.Contracts.Traza.TrackSession NewSession(Core.Contracts.Security.Token tokenInfo, string requestType, object data, string documentId = "", string policyId = "", string insuredId = "", string insuredName = "")
        {
            if (string.IsNullOrEmpty(documentId))
            {
                documentId = Guid.NewGuid().ToString();
            }
            int trackingId = Traza.TrackRequest.Add(tokenInfo.CompanyId, tokenInfo.UserId,
                                     new Core.Contracts.Traza.TrackRequest()
                                     {
                                         DocumentId = documentId,
                                         RequestType = requestType,
                                         RequestBody = Newtonsoft.Json.JsonConvert.SerializeObject(data),
                                         RequestTimeStamp = DateTime.Now,
                                         PolicyId = policyId,
                                         InsuredId = insuredId,
                                         InsuredName = insuredName
                                     }).Id;

            return new Core.Contracts.Traza.TrackSession()
            {
                TrackingId = trackingId,
                DocumentId = documentId,
                ResponseStatus = 200,
                ResponseText = "Procesado",
                CompanyId = tokenInfo.CompanyId,
                UserId = tokenInfo.UserId
            };
        }

        public static void CloseSession(Core.Contracts.Traza.TrackSession session, object data)
        {
            Traza.TrackRequest.Update(session.CompanyId, session.UserId, session.TrackingId,
                          new Core.Contracts.Traza.TrackRequest()
                          {
                              MessageId = session.MessageId,
                              ResponseStatus = session.ResponseStatus,
                              ResponseText = session.ResponseText,
                              ResponseBody = Newtonsoft.Json.JsonConvert.SerializeObject(data),
                              ResponseTimeStamp = DateTime.Now
                          });
        }

        public static Architect.API.Core.Contracts.Traza.TrackRequest Retrieve(string documentId, int companyId)
        {
            return Traza.TrackRequest.Retrieve(documentId, companyId);
        }

        ///// <summary>
        ///// Crea registro o actualiza un registro en la tabla TrackRequest.
        ///// </summary>
        ///// <param name="companyId">Identificación de la compañía propietaria.</param>
        ///// <param name="userId">Identificación del usuario.</param>
        ///// <param name="item">Instancia de TrackRequest</param>
        ///// <returns>Instancia de TrackRequest creada o actualizada.</returns>
        //public static Aliados.Monge.Contracts.Traza.TrackRequestResult CreateOrUpdate(int companyId, int userId, Architect.API.Insurance.Contracts.Policy.TrackRequest item)
        //{
        //    if (item.Id.IsEmpty() || Architect.API.Insurance.DataAccess.Policy.TrackRequest.Count(item.Id, companyId) == 0)
        //    {
        //        return Create(companyId, userId, item);
        //    }
        //    else
        //    {
        //        return Update(companyId, userId, item.Id, item);
        //    }
        //}

        ///// <summary>
        ///// Crea un registro en la tabla TrackRequest.
        ///// </summary>
        ///// <param name="companyId">Identificación de la compañía propietaria.</param>
        ///// <param name="userId">Identificación del usuario.</param>
        ///// <param name="item">Instancia de TrackRequest</param>
        ///// <returns>Instancia de TrackRequest creada.</returns>
        //public static Architect.API.Insurance.Contracts.Policy.TrackRequestResult Create(int companyId, int userId, Architect.API.Insurance.Contracts.Policy.TrackRequest item)
        //{
        //    Architect.API.Insurance.Contracts.Policy.TrackRequest result = item;
        //    List<Core.Contracts.General.Error> errors = Architect.API.Insurance.Business.Policy.TrackRequest.Validate(companyId, item, true, false);

        //    if (errors.Count == 0)
        //    {
        //        if (result.Id.IsEmpty())
        //        {
        //            result.Id = Architect.API.Insurance.DataAccess.Policy.TrackRequest.RetrieveLastKey() + 1;
        //        }
        //        result.CompanyId = companyId;
        //        result.UpdateUserCode = userId;
        //        result.UpdateDate = DateTime.Now;

        //        if (Architect.API.Insurance.DataAccess.Policy.TrackRequest.Create(result) > 0)
        //        {
        //            MapLookups(companyId, result);
        //            Core.Business.General.ChangeSet.Create(2006, result.Id, companyId, "Creación", string.Format("Se creó un registro con la identificación '{0}'", result.Id), userId, result);
        //        }
        //    }
        //    return new Architect.API.Insurance.Contracts.Policy.TrackRequestResult() { TrackRequest = result, Errors = errors };
        //}

        ///// <summary>
        ///// Recupera una lista de registros en la tabla TrackRequest.
        ///// </summary>
        ///// <param name="companyId">Identificación de la compañía propietaria.</param>
        ///// <param name="filter">Filtro personalizado.</param>
        ///// <param name="beginIndex">Indice inicial para el paginado.</param>
        ///// <param name="endIndex">Indice final para el paginado.</param>
        ///// <returns>Lista de instancias de TrackRequest.</returns>
        //public static List<Architect.API.Insurance.Contracts.Policy.TrackRequest> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        //{
        //    List<Architect.API.Insurance.Contracts.Policy.TrackRequest> result = Architect.API.Insurance.DataAccess.Policy.TrackRequest.RetrieveAll(companyId, Architect.API.Insurance.DataAccess.Policy.TrackRequest.FilterBuilder(filter, false), beginIndex, endIndex);

        //    foreach (Architect.API.Insurance.Contracts.Policy.TrackRequest item in result)
        //    {
        //        MapLookups(companyId, item);
        //    }
        //    return result;
        //}

        ///// <summary>
        ///// Recupera un registro en la tabla TrackRequest por medio de su clave primaria.
        ///// </summary>
        ///// <param name="companyId">Identificación de la compañía propietaria.</param>
        ///// <param name="id">Identificación única del registro.</param>
        ///// <returns>Instancia de TrackRequest</returns>
        //public static Architect.API.Insurance.Contracts.Policy.TrackRequest RetrieveById(int companyId, int id)
        //{
        //    Architect.API.Insurance.Contracts.Policy.TrackRequest result = Architect.API.Insurance.DataAccess.Policy.TrackRequest.Retrieve(id, companyId);

        //    MapLookups(companyId, result);

        //    return result;
        //}

        ///// <summary>
        ///// Actualiza un registro en la tabla TrackRequest por medio de su clave primaria.
        ///// </summary>
        ///// <param name="companyId">Identificación de la compañía propietaria.</param>
        ///// <param name="userId">Identificación del usuario.</param>
        ///// <param name="id">Identificación única del registro.</param>
        ///// <param name="item">Instancia de TrackRequest</param>
        ///// <returns>Instancia de TrackRequest actualizada.</returns>
        //public static Architect.API.Insurance.Contracts.Policy.TrackRequestResult Update(int companyId, int userId, int id, Architect.API.Insurance.Contracts.Policy.TrackRequest item)
        //{
        //    Architect.API.Insurance.Contracts.Policy.TrackRequest result = null;
        //    List<Core.Contracts.General.Error> errors = Architect.API.Insurance.Business.Policy.TrackRequest.Validate(companyId, item, false, false);

        //    if (errors.Count == 0)
        //    {
        //        result = item;
        //        result.Id = id;
        //        result.CompanyId = companyId;
        //        result.UpdateUserCode = userId;
        //        result.UpdateDate = DateTime.Now;

        //        if (Architect.API.Insurance.DataAccess.Policy.TrackRequest.Update(result) > 0)
        //        {
        //            MapLookups(companyId, result);
        //            Core.Business.General.ChangeSet.Create(2006, item.Id, companyId, "Modificación", string.Format("Se modificó el registro con la identificación '{0}'", result.Id), userId, result);
        //        }
        //    }
        //    return new Architect.API.Insurance.Contracts.Policy.TrackRequestResult() { TrackRequest = result, Errors = errors };
        //}

        ///// <summary>
        ///// Elimina un registro en la tabla TrackRequest por medio de su clave primaria.
        ///// </summary>
        ///// <param name="companyId">Identificación de la compañía propietaria.</param>
        ///// <param name="userId">Identificación del usuario.</param>
        ///// <param name="id">Identificación única del registro.</param>
        ///// <returns>Instancia de TrackRequest eliminada.</returns>
        //public static Architect.API.Insurance.Contracts.Policy.TrackRequestResult Delete(int companyId, int userId, int id)
        //{
        //    Architect.API.Insurance.Contracts.Policy.TrackRequest result = null;
        //    List<Core.Contracts.General.Error> errors = Architect.API.Insurance.Business.Policy.TrackRequest.Validate(companyId, new Architect.API.Insurance.Contracts.Policy.TrackRequest() { Id = id }, false, true);

        //    if (errors.Count == 0)
        //    {
        //        result = Architect.API.Insurance.DataAccess.Policy.TrackRequest.Retrieve(id, companyId);
        //        if (result.IsNotEmpty() && Architect.API.Insurance.DataAccess.Policy.TrackRequest.Delete(id, companyId) > 0)
        //        {
        //            Core.Business.General.ChangeSet.Create(2006, id, companyId, "Eliminar", string.Format("Se eliminó el registro con la identificación '{0}'", result.Id), userId, result);
        //        }
        //    }
        //    return new Architect.API.Insurance.Contracts.Policy.TrackRequestResult() { TrackRequest = result, Errors = errors };
        //}

        ///// <summary>
        ///// Recupera la cantidad de registros existentes en la tabla TrackRequest que cumplen con el filtro.
        ///// </summary>
        ///// <param name="companyId">Identificación de la compañía propietaria.</param>
        ///// <param name="filter">Filtro personalizado.</param>
        ///// <returns>Cantidad de registros existentes.</returns>
        //public static int Count(int companyId, string filter)
        //{
        //    return Architect.API.Insurance.DataAccess.Policy.TrackRequest.Count(Architect.API.Insurance.DataAccess.Policy.TrackRequest.FilterBuilder(filter));
        //}

        ///// <summary>
        ///// Validaciones para los campos de la tabla TrackRequest.
        ///// </summary>
        ///// <param name="companyId">Identificación de la compañía propietaria.</param>
        ///// <param name="source">Instancia de TrackRequest</param>
        ///// <param name="isnew">Indicador de registro nuevo.</param>
        ///// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        ///// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        //public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Insurance.Contracts.Policy.TrackRequest source, bool isnew, bool isdelete)
        //{
        //    string group = "TrackRequest";
        //    List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

        //    //Id:
        //    if ((!isnew || isdelete) && source.Id.IsEmpty())
        //    {
        //        result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el identificación" });
        //    }
        //    if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Insurance.DataAccess.Policy.TrackRequest.Count(source.Id, companyId) == 0)
        //    {
        //        result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificación no está registrada" });
        //    }
        //    if (isnew && source.Id.IsNotEmpty() && Architect.API.Insurance.DataAccess.Policy.TrackRequest.Count(source.Id, companyId) > 0)
        //    {
        //        result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificación ya está registrada" });
        //    }
        //    if (!isdelete)
        //    {

        //        //DocumentId:

        //        //RequestType:

        //        //RequestBody:

        //        //RequestTimeStamp:

        //        //MessageId:

        //        //ResponseStatus:

        //        //ResponseText:

        //        //ResponseBody:

        //        //ResponseTimeStamp:
        //    }

        //    return result;
        //}

        ///// <summary>
        ///// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        ///// </summary>
        ///// <param name="companyId">Identificación de la compañía propietaria.</param>
        ///// <param name="item">Instancia de TrackRequest</param>
        //private static void MapLookups(int companyId, Architect.API.Insurance.Contracts.Policy.TrackRequest item)
        //{
        //    if (item.IsEmpty())
        //    {
        //        return;
        //    }

        //}

    }
}
