using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// .
    /// </summary>
    public static partial class ProcessSpecLink
    {
        /// <summary>
        /// Crea registro o actualiza un registro en la tabla ProcessSpecLink.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecLink</param>
        /// <returns>Instancia de ProcessSpecLink creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecLinkResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecLink item)
        {
            if (item.Id.IsEmpty() || Architect.API.Core.DataAccess.General.ProcessSpecLink.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecLink.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecLink</param>
        /// <returns>Instancia de ProcessSpecLink creada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecLinkResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecLink item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecLink result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecLink.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Core.DataAccess.General.ProcessSpecLink.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecLink.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(0000, result.Id, companyId, "Creación", string.Format("Se creó el processspeclink '{0}'", result.Name), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecLinkResult() { ProcessSpecLink = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecLink.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de ProcessSpecLink.</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecLink> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecLink> result = Architect.API.Core.DataAccess.General.ProcessSpecLink.RetrieveAll(companyId, Architect.API.Core.DataAccess.General.ProcessSpecLink.FilterBuilderFull(filter, false), beginIndex, endIndex);
            result = result.OrderBy(c => c.Type).ThenBy(person => person.LinkOrder).ToList();
            foreach (Architect.API.Core.Contracts.General.ProcessSpecLink item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla ProcessSpecLink por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecLink</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecLink RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessSpecLink result = Architect.API.Core.DataAccess.General.ProcessSpecLink.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecLink por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de ProcessSpecLink</param>
        /// <returns>Instancia de ProcessSpecLink actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecLinkResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.ProcessSpecLink item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecLink result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecLink.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecLink.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(0000, item.Id, companyId, "Modificación", string.Format("Se modificó el processspeclink '{0}'", result.Name), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecLinkResult() { ProcessSpecLink = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla ProcessSpecLink por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecLink eliminada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecLinkResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessSpecLink result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecLink.Validate(companyId, new Architect.API.Core.Contracts.General.ProcessSpecLink() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.ProcessSpecLink.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecLink.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(0000, id, companyId, "Eliminar", string.Format("Se eliminó el processspeclink '{0}'", result.Name), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecLinkResult() { ProcessSpecLink = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecLink que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.ProcessSpecLink.Count(Architect.API.Core.DataAccess.General.ProcessSpecLink.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla ProcessSpecLink.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="source">Instancia de ProcessSpecLink</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.ProcessSpecLink source, bool isnew, bool isdelete)
        {
            string group = "ProcessSpecLink";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el id" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecLink.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La id no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecLink.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La id ya está registrada" });
            }
            if (!isdelete)
            {
                //FlowId:
                if (source.FlowId.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FlowId", Message = "Debe indicar el proceso" });
                }
                if (source.FlowId.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "Process", source.FlowId.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FlowId", Message = "El valor indicado para el proceso no es valido" });
                }

                //Name:
                if (source.Name.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Name", Message = "Debe indicar el nombre" });
                }

                //Description:

                //Icon:

                //Type:
                if (source.Type.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Type", Message = "Debe indicar el tipo" });
                }
                if (source.Type.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "LinkType", source.Type.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Type", Message = "El valor indicado para el tipo no es valido" });
                }

                //LinkOrder:

                //URL:
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="item">Instancia de ProcessSpecLink</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.ProcessSpecLink item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.FlowId.IsNotEmpty())
                item.FlowIdDesc = Core.Business.Common.LkpDescription(companyId, "Process", item.FlowId.ToString());
            if (item.Type.IsNotEmpty())
                item.TypeDesc = Core.Business.Common.LkpDescription(companyId, "LinkType", item.Type.ToString());
        }
    }
}