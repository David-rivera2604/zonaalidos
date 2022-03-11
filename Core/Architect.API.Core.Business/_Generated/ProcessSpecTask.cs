using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Tareas vinculadas a un paso o estado de un proceso.
    /// </summary>
    public static partial class ProcessSpecTask
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla ProcessSpecTask.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecTask</param>
        /// <returns>Instancia de ProcessSpecTask creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecTaskResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecTask item)
        {
            if (item.Id.IsEmpty() || Architect.API.Core.DataAccess.General.ProcessSpecTask.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecTask.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecTask</param>
        /// <returns>Instancia de ProcessSpecTask creada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecTaskResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecTask item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecTask result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecTask.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Core.DataAccess.General.ProcessSpecTask.RetrieveLastKey() + 1;
                }
                if (result.TaskOrder.IsEmpty())
                {
                    result.TaskOrder = DataAccess.General.ProcessSpecTask.LastTaskOrderByStepId(companyId, result.StepId) + 10;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecTask.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1302, result.Id, companyId, "Creación", string.Format("Se creó el process spec task '{0}'", result.Name), userId, result);
                    Utilities.Cache.RemoveStartWith("SpecFlow");
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecTaskResult() { ProcessSpecTask = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecTask.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de ProcessSpecTask.</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecTask> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecTask> result = Architect.API.Core.DataAccess.General.ProcessSpecTask.RetrieveAll(companyId, Architect.API.Core.DataAccess.General.ProcessSpecTask.FilterBuilderEx(filter), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.ProcessSpecTask item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla ProcessSpecTask por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecTask</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecTask RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessSpecTask result = Architect.API.Core.DataAccess.General.ProcessSpecTask.RetrieveFull(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecTask por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de ProcessSpecTask</param>
        /// <returns>Instancia de ProcessSpecTask actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecTaskResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.ProcessSpecTask item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecTask result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecTask.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecTask.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1302, item.Id, companyId, "Modificación", string.Format("Se modificó el process spec task '{0}'", result.Name), userId, result);
                    Utilities.Cache.RemoveStartWith("SpecFlow");
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecTaskResult() { ProcessSpecTask = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla ProcessSpecTask por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecTask eliminada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecTaskResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessSpecTask result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecTask.Validate(companyId, new Architect.API.Core.Contracts.General.ProcessSpecTask() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.ProcessSpecTask.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecTask.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(1302, id, companyId, "Eliminar", string.Format("Se eliminó el process spec task '{0}'", result.Name), userId, result);
                    Utilities.Cache.RemoveStartWith("SpecFlow");
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecTaskResult() { ProcessSpecTask = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecTask que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.ProcessSpecTask.Count(Architect.API.Core.DataAccess.General.ProcessSpecTask.FilterBuilderEx(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla ProcessSpecTask.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de ProcessSpecTask</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.ProcessSpecTask source, bool isnew, bool isdelete)
        {
            string group = "ProcessSpecTask";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el tarea" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecTask.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La tarea no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecTask.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La tarea ya está registrada" });
            }
            if (!isdelete)
            {

                //StepId:
                if (source.StepId.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "StepId", Message = "Debe indicar el paso" });
                }
                if (source.StepId.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "Steps", source.StepId.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "StepId", Message = "El valor indicado para el paso no es valido" });
                }

                //Name:
                if (source.Name.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Name", Message = "Debe indicar el name" });
                }

                //Description:

                //SLATimeOut:

                //IsRequired:

                //IsSelected:

                //TaskOrder:

                //Type:
                if (source.Type.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Type", Message = "Debe indicar el type" });
                }
                if (source.Type.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "TaskType", source.Type.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Type", Message = "El valor indicado para el type no es valido" });
                }

                //Action:

                //SubStatus:

                //SubLabel:

                //PreScript:

                //PostScript:
            }

            if (result.Count == 0)
            {
                if (Rule_IsFinishStep(companyId, source.StepId))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "*", Message = "No se pueden asignar tareas a una etapa que tenga algunos de los siguientes estados: Finalizado, Cerrado, Aprobado o Rechazado" });
                }
            }
            return result;
        }


        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="item">Instancia de ProcessSpecTask</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.ProcessSpecTask item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.StepId.IsNotEmpty())
                item.StepIdDesc = Core.Business.Common.LkpDescription(companyId, "Steps", item.StepId.ToString());
            if (item.Type.IsNotEmpty())
                item.TypeDesc = Core.Business.Common.LkpDescription(companyId, "TaskType", item.Type.ToString());

        }

    }
}
