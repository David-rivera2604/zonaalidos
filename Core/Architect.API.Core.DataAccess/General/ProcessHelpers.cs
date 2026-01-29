using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// 
    /// </summary>
    public static class ProcessHelpers
    {

        public static int NumberOfSteps(this List<Contracts.General.ProcessInstance> instances)
        {
            return instances.Count(i => i.StepId > 0 && i.TaskId == 0);
        }
        public static int CurrentStepNumber(this List<Contracts.General.ProcessInstance> instances, int stepId)
        {
            int count = 0;

            foreach (var instance in instances)
            {
                if (instance.StepId > 0 && instance.TaskId == 0 )
                {
                    count++;
                    if (instance.StepId == stepId)
                    {
                        //count++;
                        break;
                    }
                }
            }
            return count;
        }
        public static Contracts.General.ProcessInstance CurrentStep(this List<Contracts.General.ProcessInstance> instances)
        {
            Contracts.General.ProcessInstance step = null;

            foreach (var instance in instances)
            {
                if (instance.StepId > 0 && instance.TaskId == 0 && instance.StartDate > DateTime.MinValue)
                {
                    step = instance;
                }
            }
            return step;
        }

        public static int ProcessProgress(this List<Contracts.General.ProcessInstance> instances)
        {
            int stepReadyOrSkiped = 0;
            int count = instances.NumberOfSteps();
            Contracts.General.ProcessInstance current = instances.CurrentStep();

            foreach (var instance in instances.Where(i => i.StepId > 0 && i.TaskId == 0 ).ToList())
            {
                if (instance.StepId  == current.StepId && instance.StartDate > DateTime.MinValue)
                {
                    if (instance.FinishDate > DateTime.MinValue) {
                        stepReadyOrSkiped++;
                    }
                    break;
                }
                stepReadyOrSkiped++;
            }
            return (int)((stepReadyOrSkiped * 100.0) / count);
        }
    }
}
