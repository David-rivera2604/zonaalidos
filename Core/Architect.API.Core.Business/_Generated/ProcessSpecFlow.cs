using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Especificación de un proceso.
    /// </summary>
    public static partial class ProcessSpecFlow
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecFlow</param>
        /// <returns>Instancia de ProcessSpecFlow creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecFlowResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecFlow item)
        {
            if (item.Id.IsEmpty() || Architect.API.Core.DataAccess.General.ProcessSpecFlow.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecFlow</param>
        /// <returns>Instancia de ProcessSpecFlow creada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecFlowResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecFlow item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecFlow result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecFlow.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Core.DataAccess.General.ProcessSpecFlow.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecFlow.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1300, result.Id, companyId, "Creación", string.Format("Se creó el process spec flow '{0}'", result.Name), userId, result);

                    Utilities.Cache.RemoveStartWith("Process");
                    Utilities.Cache.RemoveStartWith("SpecFlow");
                    
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecFlowResult() { ProcessSpecFlow = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de ProcessSpecFlow.</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecFlow> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecFlow> result = Architect.API.Core.DataAccess.General.ProcessSpecFlow.RetrieveAll(companyId, Architect.API.Core.DataAccess.General.ProcessSpecFlow.FilterBuilderEx(filter, false), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.ProcessSpecFlow item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecFlow</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecFlow RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessSpecFlow result = Architect.API.Core.DataAccess.General.ProcessSpecFlow.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de ProcessSpecFlow</param>
        /// <returns>Instancia de ProcessSpecFlow actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecFlowResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.ProcessSpecFlow item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecFlow result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecFlow.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecFlow.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1300, item.Id, companyId, "Modificación", string.Format("Se modificó el process spec flow '{0}'", result.Name), userId, result);
                    Utilities.Cache.RemoveStartWith("Process");
                    Utilities.Cache.RemoveStartWith("SpecFlow");
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecFlowResult() { ProcessSpecFlow = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecFlow eliminada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecFlowResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessSpecFlow result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecFlow.Validate(companyId, new Architect.API.Core.Contracts.General.ProcessSpecFlow() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.ProcessSpecFlow.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecFlow.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(1300, id, companyId, "Eliminar", string.Format("Se eliminó el process spec flow '{0}'", result.Name), userId, result);
                    Utilities.Cache.RemoveStartWith("Process");
                    Utilities.Cache.RemoveStartWith("SpecFlow");
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecFlowResult() { ProcessSpecFlow = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecFlow que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.ProcessSpecFlow.Count(Architect.API.Core.DataAccess.General.ProcessSpecFlow.FilterBuilderEx(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="source">Instancia de ProcessSpecFlow</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.ProcessSpecFlow source, bool isnew, bool isdelete)
        {
            string group = "ProcessSpecFlow";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el proceso" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecFlow.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La proceso no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecFlow.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La proceso ya está registrada" });
            }
            if (!isdelete)
            {

                //Name:
                if (source.Name.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Name", Message = "Debe indicar el nombre" });
                }

                //Description:

                //Alias:

                //MailServer:
                if (source.MailServer.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MailServer", Message = "Debe indicar el servidor de correo" });
                }
                if (source.MailServer.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "MailServer", source.MailServer.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MailServer", Message = "El valor indicado para el servidor de correo no es valido" });
                }

                //ReferenceCaption1:

                //ReferenceCaption2:

                //ReferenceCaption3:

                //ReferenceCaption4:

                //ReferenceCaption5:

                //Status:
                if (source.Status.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Status", Message = "Debe indicar el estado" });
                }
                if (source.Status.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "EstadoRegistro", source.Status.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Status", Message = "El valor indicado para el estado no es valido" });
                }
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="item">Instancia de ProcessSpecFlow</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.ProcessSpecFlow item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.MailServer.IsNotEmpty())
                item.MailServerDesc = Core.Business.Common.LkpDescription(companyId, "MailServer", item.MailServer.ToString());
            if (item.Status.IsNotEmpty())
                item.StatusDesc = Core.Business.Common.LkpDescription(companyId, "EstadoRegistro", item.Status.ToString());

        }

    }
}
