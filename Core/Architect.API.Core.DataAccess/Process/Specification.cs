using Architect.Utilities.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Architect.API.Core.DataAccess.General.Process
{
    public static class Specification
    {

        public static Contracts.General.ProcessSpecFlow Retrieve(int flowId, int companyId)
        {
            IDbConnection currentConnection = DataFactory.Database.OpenConnection("Research");

            Contracts.General.ProcessSpecFlow result = ProcessSpecFlow.Retrieve(flowId, companyId, currentConnection);

            if (result.IsNotEmpty())
            {
                if (result.SLA.IsNotEmpty())
                {
                    result.SLALevels = ProcessSpecSLALevel.RetrieveAll(companyId, result.SLA, currentConnection);
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

            ProcessCase.Update(processInstance.First().CaseId, instanceId, current.Step.ProcessStatus, current.Step.ProcessLabel, 0, string.Empty, current.StepId, currentConnection);

            currentConnection.Close();

            return processInstance;
        }

        public static List<Contracts.General.ProcessInstance> UpdateInstance(List<Contracts.General.ProcessInstance> processInstance, Contracts.General.ProcessInstance currentTask)
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

            if (current.IsEmpty())
            {
                ProcessCase.Update(processInstance.First().CaseId, processInstance.First().InstanceId, 0, string.Empty, currentTask.Task.SubStatus, currentTask.Task.SubLabel, 0, currentConnection);
            }
            else
            {
                ProcessCase.Update(processInstance.First().CaseId, processInstance.First().InstanceId, current.Step.ProcessStatus, current.Step.ProcessLabel, currentTask.Task.SubStatus, currentTask.Task.SubLabel, current.StepId, currentConnection);
            }

            currentConnection.Close();

            return processInstance;
        }
    }
}
