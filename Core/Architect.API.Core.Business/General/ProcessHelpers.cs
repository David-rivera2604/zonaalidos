using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// 
    /// </summary>
    public static class ProcessHelpers
    {

        public static string FixData(bool apply)
        {
            StringBuilder log = new StringBuilder();
            List<Architect.API.Core.Contracts.General.ProcessCase> result = Architect.API.Core.DataAccess.General.ProcessCase.DataToFix();


            foreach (Architect.API.Core.Contracts.General.ProcessCase processCaseToFix in result)
            {
                Contracts.General.ProcessCase processCase = DataAccess.General.ProcessCase.Retrieve(processCaseToFix.Id, 100);
                List<Contracts.General.ProcessInstance> instances = DataAccess.General.ProcessInstance.RetrieveByInstanceId(processCase.InstanceId, 100);
                Contracts.General.ProcessInstance mainInstance = instances.FirstOrDefault(i => i.StepId == 0 && i.TaskId == 0);
                Contracts.General.ProcessInstance lastInstance = instances.FirstOrDefault(i => i.StepId == processCase.CurrentStepId && i.TaskId == 0);
                Contracts.General.ProcessInstance endInstance = null;


                if (lastInstance.IsEmpty())
                {
                    log.AppendLine($"A Para el caso {processCase.Id} no existe concondancia del CurrentStepId con los pasos en la instancia");
                }

                if ((processCase.Status == 3 || processCase.Status == 6) && mainInstance.FinishDate.IsEmpty())
                {
                    Contracts.General.ProcessInstance prev = instances.FirstOrDefault(i => i.ActivityId == lastInstance.PreviousActivityId);
                    log.AppendLine($"B Para el caso {processCase.Id} la instancia no esta finalizada, deberia de ser {lastInstance.StartDate} - {lastInstance.FinishDate}");

                    if (apply)
                    {
                        // Actualizamos la instancia final
                        lastInstance.FinishDate = lastInstance.StartDate;
                        lastInstance.UserId = prev.UserId;
                        DataAccess.General.ProcessInstance.Update(lastInstance, null);
                        // Actualizamos la instancia principal
                        mainInstance.UserId = lastInstance.UserId;
                        mainInstance.FinishDate = lastInstance.FinishDate;
                        DataAccess.General.ProcessInstance.Update(mainInstance, null);
                    }
                }

                if ((processCase.Status != 3 && processCase.Status != 6) && mainInstance.FinishDate.IsNotEmpty())
                {
                    if (lastInstance.Step == null)
                    {
                        lastInstance = instances.Where(i => i.StepId > 0 && i.TaskId == 0 && i.FinishDate.IsNotEmpty())
                        .OrderByDescending(i => i.FinishDate)
                        .FirstOrDefault();
                    }
                    Contracts.General.ProcessSpecStep step = Architect.API.Core.Business.General.ProcessSpecStep.RetrieveById(100, lastInstance.StepId);

                    endInstance = instances.Where(i => i.StepId > 0 && i.TaskId == 0)
                        .OrderByDescending(i => i.ActivityId)
                        .FirstOrDefault();

                    Contracts.General.ProcessSpecStep endstep = Architect.API.Core.Business.General.ProcessSpecStep.RetrieveById(100, endInstance.StepId);

                    log.AppendLine($"C el caso {processCase.Id} no esta finalizado pero la instancia si ({processCase.CurrentStepId} / {step.ProcessStatus} / {lastInstance.FinishDate} / {processCase.FlowId} / {step.Id})");

                    if (apply)
                    {
                        // Finalizar el caso
                        processCase.Status = 3;
                        DataAccess.General.ProcessCase.Update(processCase, null);
                    }
                }
            }
            return log.ToString();
        }

    }
}
