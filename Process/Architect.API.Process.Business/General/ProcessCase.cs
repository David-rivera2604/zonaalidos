using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Process.Business.General
{
    public static partial class ProcessCase
    {
        /// <summary>
        /// Asigna o reasigna un usuario a la etapa activa de un caso.
        /// <list type="bullet">
        ///   <item>Actualiza <c>PROCESSCASE.USERASSIGNED</c> y <c>USERASSIGNEDDATE</c>.</item>
        ///   <item>Actualiza <c>PROCESSINSTANCE.USERASSIGNED</c> por <c>ACTIVITYID</c>.</item>
        ///   <item>Inserta en <c>Reassignment</c> como historial:
        ///     <c>State = Caso (2)</c> si es primera asignacion;
        ///     <c>State = Reasignacion (3)</c> si ya habia un usuario asignado.
        ///   </item>
        /// </list>
        /// Al finalizar dispara la notificacion en tiempo real al usuario asignado,
        /// siempre que sea distinto del usuario que ejecuta la accion.
        /// </summary>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="tokenInfo">Token de seguridad del usuario que realiza la operacion.</param>
        /// <param name="caseId">Identificador del caso a asignar.</param>
        /// <param name="userAssigned">Identificador del usuario que recibira el caso.</param>
        /// <returns>Resultado con el caso actualizado o la lista de errores de validacion.</returns>
        public static Contracts.General.ProcessCaseResult Assign(int companyId, Core.Contracts.Security.Token tokenInfo, int caseId, int userAssigned)
        {
            string group = "ProcessCase";
            List<Core.Contracts.General.Error> errors = new List<Core.Contracts.General.Error>();

            if (caseId.IsEmpty())
                errors.Add(new Core.Contracts.General.Error() { Group = group, Key = "CaseId", Message = "Debe indicar el caso" });

            if (userAssigned.IsEmpty())
                errors.Add(new Core.Contracts.General.Error() { Group = group, Key = "UserAssigned", Message = "Debe indicar el usuario a asignar" });

            if (errors.Count > 0)
                return new Contracts.General.ProcessCaseResult() { ProcessCase = null, Errors = errors };

            // 1. Recuperar el caso
            Contracts.General.ProcessCase processCase = DataAccess.General.ProcessCase.Retrieve(caseId, companyId);
            if (processCase.IsEmpty())
            {
                errors.Add(new Core.Contracts.General.Error() { Group = group, Key = "CaseId", Message = "El caso no existe" });
                return new Contracts.General.ProcessCaseResult() { ProcessCase = null, Errors = errors };
            }

            DateTime now = DateTime.Now;

            // 2. Actualizar PROCESSCASE.USERASSIGNED y fecha
            processCase.UserAssigned = userAssigned;
            processCase.UserAssignedDate = now;
            processCase.CompanyId = companyId;
            processCase.UpdateUserCode = tokenInfo.UserId;
            processCase.UpdateDate = now;
            DataAccess.General.ProcessCase.Update(processCase);

            // 3. Obtener actividades activas del caso
            //    (STEPID > 0, TASKID = 0, STARTDATE poblada, FINISHDATE vacia)
            List<Contracts.General.ProcessInstance> activeInstances =
                DataAccess.General.ProcessInstance
                    .RetrieveByInstanceId(processCase.InstanceId, companyId)
                    .Where(i => i.StepId > 0
                             && i.TaskId == 0
                             && i.StartDate != default(DateTime)
                             && i.FinishDate == default(DateTime))
                    .ToList();

            List<Contracts.General.Reassignment> reassignments = new List<Contracts.General.Reassignment>();
            bool isReassignment = false;

            foreach (Contracts.General.ProcessInstance instance in activeInstances)
            {
                // 4. Determinar si es asignacion nueva o reasignacion
                bool hadPreviousUser = instance.UserAssigned > 0;
                if (hadPreviousUser) isReassignment = true;

                Contracts.General.ReassignmentState state = hadPreviousUser
                    ? Contracts.General.ReassignmentState.Reasignacion  // ya tenia usuario asignado
                    : Contracts.General.ReassignmentState.Caso;          // primera asignacion desde un caso

                // 5. Actualizar USERASSIGNED y USERASSIGNEDDATE por ACTIVITYID
                DataAccess.General.ProcessInstance.UpdateUserAssigned(
                    instance.ActivityId,
                    userAssigned,
                    now);

                // 6. Siempre insertar en Reassignment como historial
                reassignments.Add(new Contracts.General.Reassignment()
                {
                    ActivityId = instance.ActivityId,
                    UserAssigned = userAssigned,
                    UserAssignedDate = now,
                    State = state
                });
            }

            // 7. Persistir historial de Reassignment
            if (reassignments.Count > 0)
                Reassignment.CreateBatch(reassignments);

            // 8. Registrar en ChangeSet con descripcion segun tipo
            Core.Business.General.ChangeSet.Create(
                1304, caseId, companyId,
                isReassignment ? "Reasignacion" : "Asignacion",
                isReassignment
                    ? string.Format("El caso '{0}' fue reasignado al usuario {1} por el supervisor {2}", processCase.Title, userAssigned, tokenInfo.UserId)
                    : string.Format("El caso '{0}' fue asignado al usuario {1} por el supervisor {2}", processCase.Title, userAssigned, tokenInfo.UserId),
                tokenInfo.UserId,
                processCase);

            try
            {
                string caseTitle = string.IsNullOrWhiteSpace(processCase.Title) ? string.Format("Proceso #{0}", caseId) : processCase.Title;
                Architect.Utilities.Log.TraceLog("Notification", string.Format("Notif: companyId={0} userAssigned={1} tokenUserId={2} caseId={3} title={4}", companyId, userAssigned, tokenInfo.UserId, caseId, caseTitle));
                if (userAssigned > 0 && userAssigned != tokenInfo.UserId)
                {
                    if (isReassignment)
                        Architect.API.Core.Business.Notifications.NotificationBusiness.NotifyProcessReassign(companyId, userAssigned, caseId, caseTitle);
                    else
                        Architect.API.Core.Business.Notifications.NotificationBusiness.NotifyProcessAssign(companyId, userAssigned, caseId, caseTitle);
                }
            }
            catch (System.Exception exNotif) { Architect.Utilities.Log.ErrorLog("Notification", "Error: " + exNotif.Message, exNotif); }

            MapLookups(companyId, processCase);

            return new Contracts.General.ProcessCaseResult() { ProcessCase = processCase, Errors = errors };
        }

        /// <summary>
        /// Elimina de forma completa un caso y todas sus instancias asociadas.
        /// Valida la existencia del registro antes de proceder; si la validacion falla,
        /// retorna los errores sin ejecutar ninguna operacion de borrado.
        /// Registra la accion en el ChangeSet como auditoria.
        /// </summary>
        /// <param name="companyId">Identificador de la empresa.</param>
        /// <param name="userId">Identificador del usuario que ejecuta la eliminacion.</param>
        /// <param name="id">Identificador del caso a eliminar.</param>
        /// <returns>Resultado con el caso eliminado o la lista de errores de validacion.</returns>
        public static Architect.API.Process.Contracts.General.ProcessCaseResult DeleteFull(int companyId, int userId, int id)
        {
            Architect.API.Process.Contracts.General.ProcessCase result = null;
            List<Core.Contracts.General.Error> errors = Architect.API.Process.Business.General.ProcessCase.Validate(companyId, new Architect.API.Process.Contracts.General.ProcessCase() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Process.DataAccess.General.ProcessCase.Retrieve(id, companyId);
                if (result.IsNotEmpty())
                {
                    Architect.API.Process.DataAccess.General.ProcessInstance.DeleteByCaseId(id, companyId);
                    if (Architect.API.Process.DataAccess.General.ProcessCase.Delete(id, companyId) > 0)
                    {
                        Core.Business.General.ChangeSet.Create(1304, id, companyId, "Eliminar", string.Format("Se eliminó el processcase '{0}'", result.Title), userId, result);
                    }
                }
            }
            return new Architect.API.Process.Contracts.General.ProcessCaseResult() { ProcessCase = result, Errors = errors };
        }

        /// <summary>
        /// Persiste un caso directamente en la base de datos sin pasar por el flujo de validacion
        /// ni el motor de proceso. Util para migraciones, seeds o integraciones externas.
        /// Si el <c>Id</c> del item esta vacio, se autogenera tomando el ultimo ID + 1.
        /// </summary>
        /// <param name="companyId">Identificador de la empresa propietaria del caso.</param>
        /// <param name="userId">Identificador del usuario que registra el caso.</param>
        /// <param name="item">Datos del caso a insertar.</param>
        /// <returns>El caso tal como quedo persistido, con <c>Id</c>, <c>CompanyId</c> y metadatos de auditoria asignados.</returns>
        public static Architect.API.Process.Contracts.General.ProcessCase CreateRaw(int companyId, int userId, Architect.API.Process.Contracts.General.ProcessCase item)
        {
            Architect.API.Process.Contracts.General.ProcessCase result = item;

            if (result.Id.IsEmpty())
                result.Id = Architect.API.Process.DataAccess.General.ProcessCase.RetrieveLastKey() + 1;

            result.CompanyId = companyId;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;

            Architect.API.Process.DataAccess.General.ProcessCase.Create(result);

            return result;
        }
    }
}
