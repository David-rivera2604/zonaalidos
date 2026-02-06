using Architect.API.Process.DataAccess.General;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Architect.API.Process.DataAccess
{
    public static class Specification
    {

        public static Contracts.General.ProcessSpecFlow Retrieve(int flowId, int companyId, int customSLA)
        {
            int currentSLA = customSLA;
            IDbConnection currentConnection = DataFactory.Database.OpenConnection("Research");

            Contracts.General.ProcessSpecFlow result = ProcessSpecFlow.Retrieve(flowId, companyId, currentConnection);

            if (result.IsNotEmpty())
            {
                List<Architect.API.Process.Contracts.General.ProcessSpecFlowRole> internalRoles = Process.DataAccess.General.ProcessSpecFlowRole.RetrieveByStepId(flowId, currentConnection);
                if (internalRoles.Count > 0)
                {
                    result.Roles = new List<Utilities.Contracts.LookUpValue>();
                    foreach (Architect.API.Process.Contracts.General.ProcessSpecFlowRole item in internalRoles)
                    {
                        result.Roles.Add(new Utilities.Contracts.LookUpValue() { Code = item.RoleId.ToString(), Description = item.RoleName });
                    }
                }

                if (currentSLA.IsEmpty() && result.SLA.IsNotEmpty())
                {
                    currentSLA = result.SLA;
                }
                if (currentSLA.IsNotEmpty())
                {
                    result.SLALevels = ProcessSpecSLALevel.RetrieveAll(companyId, currentSLA, currentConnection);
                    result.SLALevels = result.SLALevels.OrderBy(s => s.SLATimeOut).ToList();
                }
                result.ProcessSpecSteps = ProcessSpecStep.RetrieveByFlowId(companyId, flowId, currentConnection);
                if (result.ProcessSpecSteps.IsNotEmpty())
                {
                    result.ProcessSpecSteps = result.ProcessSpecSteps.OrderBy(s => s.StepOrder).ToList();
                    foreach (Contracts.General.ProcessSpecStep item in result.ProcessSpecSteps)
                    {
                        if (item.SLA.IsNotEmpty())
                        {
                            item.SLALevels = ProcessSpecSLALevel.RetrieveAll(companyId, item.SLA, currentConnection);
                            item.SLALevels = item.SLALevels.OrderBy(s => s.SLATimeOut).ToList();
                        }
                        item.ProcessSpecStepRoles = ProcessSpecStepRole.RetrieveByStepId(item.Id, currentConnection);
                        item.ProcessSpecTasks = ProcessSpecTask.RetrieveByStepId(companyId, item.Id, currentConnection);
                        item.ProcessSpecTasks = item.ProcessSpecTasks.OrderBy(s => s.TaskOrder).ToList();
                    }
                }
                result.ProcessSpecLinks = ProcessSpecLink.RetrieveByFlowId(companyId, flowId, currentConnection);
            }

            currentConnection.Close();
            return result;
        }

        public static List<Contracts.General.ProcessInstance> CreateInstance(List<Contracts.General.ProcessInstance> processInstance)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Research");
            int instanceId = ProcessInstance.RetrieveLastInstanceId(currentConnection) + 1;
            Contracts.General.ProcessInstance current = null;
            foreach (Contracts.General.ProcessInstance instance in processInstance)
            {
                instance.ActivityId = ProcessInstance.RetrieveLastKey(currentConnection) + 1;
                instance.InstanceId = instanceId;
                ProcessInstance.Create(instance, currentConnection);

                if (instance.StartDate.IsNotEmpty() && instance.FinishDate.IsEmpty() && instance.StepId > 0 && instance.TaskId == 0)
                {
                    current = instance;
                }
            }


            Contracts.General.ProcessInstance instanceMain = processInstance.First();
            //result.StartDate = instance.StartDate;
            //result.FinishDate = instance.FinishDate;
            //result.DueDate = instance.DueDate;
            //result.UserAssigned = instance.UserAssigned;
            //result.UserAssignedDate = instance.StartDate;
            //result.Progress = instances.ProcessProgress();
            //result.StepCurrent = instances.CurrentStepNumber();
            //result.StepTotal = instances.NumberOfSteps();


            ProcessCase.FirstUpdate(new Contracts.General.ProcessCase()
            {
                Id = instanceMain.CaseId,
                InstanceId = instanceId,
                Status = current.Step.ProcessStatus,
                Label = current.Step.ProcessLabel,
                SubStatus = 0,
                SubLabel = string.Empty,
                CurrentStepId = current.StepId,
                UserAssigned = current.UserAssigned,
                UserAssignedDate = current.UserAssignedDate,
                StepCurrent = 1,
                StepTotal = processInstance.NumberOfSteps(),
                StartDate = instanceMain.StartDate,
                DueDate = instanceMain.DueDate,
                Progress = 0
            }, currentConnection);


            //ProcessCase.Update(processInstance.First().CaseId, instanceId, current.Step.ProcessStatus, current.Step.ProcessLabel, 0, string.Empty, current.StepId, currentConnection);

            currentConnection.Close();

            return processInstance;
        }

        /// <summary>
        /// Se encarga de actualizar la informacion del proceso en ejecucion asi como en el caso.
        /// </summary>
        public static List<Contracts.General.ProcessInstance> UpdateInstance(List<Contracts.General.ProcessInstance> processInstance, Contracts.General.ProcessInstance currentTask, List<Contracts.General.ProcessInstance> fullInstance)
        {
            Contracts.General.ProcessInstance current = null;
            Contracts.General.ProcessInstance lastStep = null;
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Research");
            foreach (Contracts.General.ProcessInstance instance in processInstance)
            {
                ProcessInstance.Update(instance, currentConnection);
                if (instance.StartDate.IsNotEmpty() && instance.FinishDate.IsEmpty() && instance.StepId > 0 && instance.TaskId == 0)
                {
                    current = instance;
                }
                if (instance.StartDate.IsNotEmpty() && instance.FinishDate.IsNotEmpty() && instance.StepId > 0 && instance.TaskId == 0)
                {
                    lastStep = instance;
                }
            }

            if (current.IsEmpty())
            {
                current = lastStep;
            }


            Contracts.General.ProcessInstance instanceMain = processInstance.First();

            if (current.IsEmpty())
            {
                ProcessCase.Update(processInstance.First().CaseId, processInstance.First().InstanceId, 0, string.Empty, currentTask.Task.SubStatus, currentTask.Task.SubLabel, 0, currentConnection);
            }
            else
            {
                ProcessCase.ProgressUpdate(new Contracts.General.ProcessCase()
                {
                    Id = instanceMain.CaseId,
                    InstanceId = instanceMain.InstanceId,
                    Status = current.Step.ProcessStatus,
                    Label = current.Step.ProcessLabel,
                    SubStatus = currentTask.Task.SubStatus,
                    SubLabel = currentTask.Task.SubLabel,
                    CurrentStepId = current.StepId,
                    UserAssigned = current.UserAssigned,
                    UserAssignedDate = current.UserAssignedDate,
                    StepCurrent = fullInstance.CurrentStepNumber(current.StepId),
                    Progress = fullInstance.ProcessProgress(),
                    FinishDate = fullInstance.First().FinishDate
                }, currentConnection);
            }

            currentConnection.Close();

            return processInstance;
        }
    }
}
