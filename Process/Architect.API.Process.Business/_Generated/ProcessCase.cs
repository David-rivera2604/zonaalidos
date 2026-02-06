using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Architect.API.Process.Business.General
{
    /// <summary>
    /// ProcessCase
    /// </summary>
    public static partial class ProcessCase
    {

        /// <summary>
        /// Crea un registro en la tabla ProcessCase.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessCase</param>
        /// <returns>Instancia de ProcessCase creada.</returns>
        public static Architect.API.Process.Contracts.General.ProcessCaseResult Create(int companyId, Core.Contracts.Security.Token tokenInfo, Architect.API.Process.Contracts.General.ProcessCase item)
        {
            Contracts.General.ProcessCase result = item;
            List<Core.Contracts.General.Error> errors = ProcessCase.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = DataAccess.General.ProcessCase.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = tokenInfo.UserId;
                result.UpdateDate = DateTime.Now;
                result.StartDate = DateTime.Now;

                if (Architect.API.Process.DataAccess.General.ProcessCase.Create(result) > 0)
                {

                    if (result.Attachments.IsNotEmpty() && result.Attachments.Count > 0)
                    {
                        foreach (Core.Contracts.General.Attachments attachment in result.Attachments)
                        {
                            attachment.EntityType = 1304;
                            attachment.EntityId = result.Id;
                            Architect.API.Core.Business.General.Attachment.SyncUpBase(attachment, companyId, tokenInfo.UserId);
                        }
                    }

                    MapLookups(companyId, result);
                    Architect.API.Core.Business.General.ChangeSet.Create(1304, result.Id, companyId, "Creación", string.Format("Se creó el processcase '{0}'", result.Title), tokenInfo.UserId, result);

                    List<Contracts.General.ProcessInstance> instances = Process.CreateInstance(
                        new Contracts.General.CreateProcessInstance()
                        {
                            FlowId = result.FlowId,
                            Title = result.Title,
                            ContactName = result.ContactMainName,
                            ContactEmail = result.ContactMainEmail,
                            Description = result.Description,
                            Reference1 = result.Reference1,
                            Reference2 = result.Reference2,
                            Reference3 = result.Reference3,
                            Reference4 = result.Reference4,
                            EntityType = 1304,
                            EntityId = result.Id,
                            SLA = result.SLA
                        }, tokenInfo.UserId, companyId, result.Id);
                }
            }
            return new Contracts.General.ProcessCaseResult() { ProcessCase = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessCase.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de ProcessCase.</returns>
        public static List<Architect.API.Process.Contracts.General.ProcessCase> Retrieve(int companyId, string filter, int beginIndex, int endIndex, int agentCodeActual = 0)
        {
            string currentFilter = string.Empty;
            if (filter == "CaseAliados")
            {
                currentFilter = " AND pc.CustomNumericKey = " + agentCodeActual.ToString();

                if (companyId == 2 || companyId == 12)
                {
                    companyId = 100;
                }
            }
            List<Architect.API.Process.Contracts.General.ProcessCase> result = Architect.API.Process.DataAccess.General.ProcessCase.RetrieveAll(companyId, currentFilter, beginIndex, endIndex);

            foreach (Architect.API.Process.Contracts.General.ProcessCase item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla ProcessCase por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessCase</returns>
        public static Architect.API.Process.Contracts.General.ProcessCase RetrieveById(int companyId, int id)
        {
            Architect.API.Process.Contracts.General.ProcessCase result = Architect.API.Process.DataAccess.General.ProcessCase.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessCase por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de ProcessCase</param>
        /// <returns>Instancia de ProcessCase actualizada.</returns>
        public static Architect.API.Process.Contracts.General.ProcessCaseResult Update(int companyId, int userId, int id, Architect.API.Process.Contracts.General.ProcessCase item)
        {
            Architect.API.Process.Contracts.General.ProcessCase result = null;
            List<Core.Contracts.General.Error> errors = Architect.API.Process.Business.General.ProcessCase.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Process.DataAccess.General.ProcessCase.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1304, item.Id, companyId, "Modificación", string.Format("Se modificó el processcase '{0}'", result.Title), userId, result);
                }
            }
            return new Architect.API.Process.Contracts.General.ProcessCaseResult() { ProcessCase = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla ProcessCase por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessCase eliminada.</returns>
        public static Architect.API.Process.Contracts.General.ProcessCaseResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Process.Contracts.General.ProcessCase result = null;
            List<Core.Contracts.General.Error> errors = Architect.API.Process.Business.General.ProcessCase.Validate(companyId, new Architect.API.Process.Contracts.General.ProcessCase() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Process.DataAccess.General.ProcessCase.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Process.DataAccess.General.ProcessCase.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(1304, id, companyId, "Eliminar", string.Format("Se eliminó el processcase '{0}'", result.Title), userId, result);
                }
            }
            return new Architect.API.Process.Contracts.General.ProcessCaseResult() { ProcessCase = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessCase que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Process.DataAccess.General.ProcessCase.Count(Architect.API.Process.DataAccess.General.ProcessCase.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla ProcessCase.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de ProcessCase</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Process.Contracts.General.ProcessCase source, bool isnew, bool isdelete)
        {
            string group = "ProcessCase";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el proceso" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Process.DataAccess.General.ProcessCase.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La proceso no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Process.DataAccess.General.ProcessCase.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La proceso ya está registrada" });
            }

            //InstanceId:
            //if ((!isnew || isdelete) && source.InstanceId.IsEmpty())
            //{
            //    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "InstanceId", Message = "Debe indicar el identificación" });
            //}
            if ((!isnew || isdelete) && source.InstanceId.IsNotEmpty() && Architect.API.Process.DataAccess.General.ProcessCase.Count(source.InstanceId, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "InstanceId", Message = "La identificación no está registrada" });
            }
            if (isnew && source.InstanceId.IsNotEmpty() && Architect.API.Process.DataAccess.General.ProcessCase.Count(source.InstanceId, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "InstanceId", Message = "La identificación ya está registrada" });
            }
            if (!isdelete)
            {

                //Title:

                //Description:

                //Priority:
                if (source.Priority.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "CasePriority", source.Priority.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Priority", Message = "El valor indicado para el prioridad no es valido" });
                }

                //CurrentStepId:

                //Reference1:

                //Reference2:

                //Reference3:

                //Reference4:

                //Reference5:

                //ContactMainName:

                //ContactMainEmail:

                //Status:
                if (source.Status.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "ProcessStatus", source.Status.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Status", Message = "El valor indicado para el estado no es valido" });
                }

                //Label:

                //SubStatus:

                //SubLabel:

                //FlowId:
                if (source.FlowId.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FlowId", Message = "Debe indicar el proceso" });
                }
                if (source.FlowId.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "Process", source.FlowId.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FlowId", Message = "El valor indicado para el proceso no es valido" });
                }

                //UserId:
                if (source.UserId.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "Users", source.UserId.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "UserId", Message = "El valor indicado para el usuario no es valido" });
                }
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="item">Instancia de ProcessCase</param>
        private static void MapLookups(int companyId, Architect.API.Process.Contracts.General.ProcessCase item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.Priority.IsNotEmpty())
                item.PriorityDesc = Core.Business.Common.LkpDescription(companyId, "CasePriority", item.Priority.ToString());
            if (item.Status.IsNotEmpty())
                item.StatusDesc = Core.Business.Common.LkpDescription(companyId, "ProcessStatus", item.Status.ToString());
            if (item.FlowId.IsNotEmpty())
                item.FlowIdDesc = Core.Business.Common.LkpDescription(companyId, "Process", item.FlowId.ToString());
            if (item.UserId.IsNotEmpty())
                item.UserIdDesc = Core.Business.Common.LkpDescription(companyId, "Users", item.UserId.ToString());
            if (item.SLA.IsNotEmpty())
                item.SLADesc = Core.Business.Common.LkpDescription(companyId, "SLA", item.SLA.ToString());

        }

    }


}
