using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Process.Business.General
{
    /// <summary>
    /// Lógica de negocio para Reassignment.
    /// </summary>
    public static partial class Reassignment
    {

        /// <summary>
        /// Crea un registro en la tabla Reassignments.
        /// </summary>
        public static Contracts.General.ReassignmentResult Create(int companyId, Core.Contracts.Security.Token tokenInfo, Contracts.General.Reassignment item)
        {
            Contracts.General.Reassignment result = item;
            List<Core.Contracts.General.Error> errors = Reassignment.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = DataAccess.General.Reassignment.RetrieveLastKey() + 1;
                }

                if (DataAccess.General.Reassignment.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1305, result.Id, companyId, "Creación",
                        string.Format("Se creó la reasignación '{0}'", result.Id), tokenInfo.UserId, result);
                }
            }

            return new Contracts.General.ReassignmentResult() { Reassignment = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Reassignments.
        /// </summary>
        public static List<Contracts.General.Reassignment> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Contracts.General.Reassignment> result = DataAccess.General.Reassignment.RetrieveAll(filter);
            foreach (Contracts.General.Reassignment item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro por su clave primaria.
        /// </summary>
        public static Contracts.General.Reassignment RetrieveById(int companyId, int id)
        {
            Contracts.General.Reassignment result = DataAccess.General.Reassignment.Retrieve(id);
            MapLookups(companyId, result);
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros por ActivityId.
        /// </summary>
        public static List<Contracts.General.Reassignment> RetrieveByActivityId(int companyId, int activityId)
        {
            List<Contracts.General.Reassignment> result = DataAccess.General.Reassignment.RetrieveByActivityId(activityId);
            foreach (Contracts.General.Reassignment item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla Reassignments.
        /// </summary>
        public static Contracts.General.ReassignmentResult Update(int companyId, int userId, int id, Contracts.General.Reassignment item)
        {
            Contracts.General.Reassignment result = null;
            List<Core.Contracts.General.Error> errors = Reassignment.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;

                if (DataAccess.General.Reassignment.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1305, result.Id, companyId, "Modificación",
                        string.Format("Se modificó la reasignación '{0}'", result.Id), userId, result);
                }
            }

            return new Contracts.General.ReassignmentResult() { Reassignment = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla Reassignments.
        /// </summary>
        public static Contracts.General.ReassignmentResult Delete(int companyId, int userId, int id)
        {
            Contracts.General.Reassignment result = null;
            List<Core.Contracts.General.Error> errors = Reassignment.Validate(companyId, new Contracts.General.Reassignment() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = DataAccess.General.Reassignment.Retrieve(id);
                if (result.IsNotEmpty() && DataAccess.General.Reassignment.Delete(id) > 0)
                {
                    Core.Business.General.ChangeSet.Create(1305, id, companyId, "Eliminar",
                        string.Format("Se eliminó la reasignación '{0}'", id), userId, result);
                }
            }

            return new Contracts.General.ReassignmentResult() { Reassignment = result, Errors = errors };
        }

        /// <summary>
        /// Persiste una lista de Reassignment. Método base reutilizable desde cualquier flujo.
        /// Asigna el Id automáticamente si viene vacío.
        /// </summary>
        /// <param name="items">Lista de reasignaciones a crear.</param>
        public static void CreateBatch(List<Contracts.General.Reassignment> items)
        {
            if (items.IsEmpty() || items.Count == 0) return;

            int lastId = DataAccess.General.Reassignment.RetrieveLastKey();
            foreach (Contracts.General.Reassignment item in items)
            {
                if (item.Id.IsEmpty())
                {
                    lastId++;
                    item.Id = lastId;
                }
                DataAccess.General.Reassignment.Create(item);
            }
        }

        /// <summary>
        /// Crea un Reassignment por cada ProcessInstance de la lista.
        /// Wrapper sobre CreateBatch para el flujo de creación de instancias.
        /// </summary>
        /// <param name="instances">Lista de instancias de proceso ya persistidas.</param>
        /// <param name="state">Estado a asignar. Por defecto Automatico.</param>
        public static void CreateFromInstances(List<Contracts.General.ProcessInstance> instances, Contracts.General.ReassignmentState state = Contracts.General.ReassignmentState.Automatico)
        {
            if (instances.IsEmpty() || instances.Count == 0) return;

            List<Contracts.General.Reassignment> items = new List<Contracts.General.Reassignment>();
            instances = instances.Where(c => c.UserAssigned != 0).ToList();
            foreach (Contracts.General.ProcessInstance instance in instances)
            {
                items.Add(new Contracts.General.Reassignment()
                {
                    ActivityId       = instance.ActivityId,
                    UserAssigned     = instance.UserAssigned,
                    UserAssignedDate = instance.UserAssignedDate,
                    State            = state
                });
            }
            CreateBatch(items);
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes.
        /// </summary>
        public static int Count(int companyId, string filter)
        {
            return DataAccess.General.Reassignment.Count(filter);
        }

        /// <summary>
        /// Validaciones para los campos de la tabla Reassignments.
        /// </summary>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Contracts.General.Reassignment source, bool isNew, bool isDelete)
        {
            string group = "Reassignment";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            // Id
            if ((!isNew || isDelete) && source.Id.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el identificador de la reasignación" });

            if ((!isNew || isDelete) && source.Id.IsNotEmpty() && DataAccess.General.Reassignment.Count($" WHERE Id = {source.Id}") == 0)
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La reasignación no está registrada" });

            if (isNew && source.Id.IsNotEmpty() && DataAccess.General.Reassignment.Count($" WHERE Id = {source.Id}") > 0)
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La reasignación ya está registrada" });

            if (!isDelete)
            {
                // ActivityId
                if (source.ActivityId.IsEmpty())
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "ActivityId", Message = "Debe indicar la actividad" });

                // UserAssigned
                if (source.UserAssigned.IsEmpty())
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "UserAssigned", Message = "Debe indicar el usuario asignado" });

                // State — validado contra LookupMaster Id:161 (ProcessState)
                if (!Enum.IsDefined(typeof(Contracts.General.ReassignmentState), source.State))
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "State", Message = "Debe indicar el estado de la reasignación" });

                if (Enum.IsDefined(typeof(Contracts.General.ReassignmentState), source.State) && !Core.Business.Common.LkpExist(companyId, "ProcessState", ((int)source.State).ToString()))
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "State", Message = "El valor indicado para el estado no es válido" });
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones de columnas con lista de valores.
        /// </summary>
        private static void MapLookups(int companyId, Contracts.General.Reassignment item)
        {
            if (item.IsEmpty()) return;

            // State — LookupMaster Id:161, Key:ProcessState
            if (Enum.IsDefined(typeof(Contracts.General.ReassignmentState), item.State))
                item.StateDesc = Core.Business.Common.LkpDescription(companyId, "ProcessState", ((int)item.State).ToString());
        }
    }
}
