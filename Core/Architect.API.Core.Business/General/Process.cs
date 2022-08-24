using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Lógica relacionada con el seguimiento de cambios.
    /// </summary>
    public static class Process
    {

        public static void OverDueSteps()
        {
            int EveryTime = Convert.ToInt16(ConfigurationManager.AppSettings["Process.Mail.Responsible.Notify.OverDue.EveryTime"]);
            DateTime now = DateTime.Now;
            bool notify = false;
            Contracts.General.ProcessSpecSLALevel sla = null;
            try
            {
                foreach (Contracts.General.ProcessInstance item in DataAccess.General.ProcessInstance.RetrieveOverDueSteps(now))
                {
                    Contracts.General.ProcessSpecFlow spec = Specification(item.FlowId, item.CompanyId, item.SLA);
                    if (spec != null)
                    {
                        item.Step = spec.ProcessSpecSteps.Where(i => i.Id == item.StepId).FirstOrDefault();
                        if (item.Step != null)
                        {
                            sla = item.Step.SLALevels.Last();
                        }
                        else
                        {
                            sla = spec.SLALevels.Last();
                        }

                        notify = true;
                        if (item.LastOverDueNotify.IsNotEmpty())
                        {
                            notify = (item.LastOverDueNotify.AddHours(EveryTime) <= now);
                        }
                        if (notify && sla.IsNotEmpty())
                        {
                            DataAccess.General.ProcessInstance.Update(item.ActivityId, now);
                            Notify(item.CaseId,
                                sla.MailForSLAExpiration, sla.MailForSLAExpirationCustom, sla.MailForSLAExpirationTmpl, item.Step.MailServer,
                                spec.MailServer, item.Step, null, item.CompanyId, 0, "Process.Mail.Responsible.Notify.OverDue.Template");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Architect.Utilities.Log.ErrorLog("Process", "OverDueSteps", ex);
                throw ex;
            }
        }

        /// <summary>
        /// Recupera la especificación de un proceso.
        /// </summary>
        public static Contracts.General.ProcessSpecFlow Specification(int flowId, int companyId, int customSLA)
        {
            Contracts.General.ProcessSpecFlow result = null;
            string key = string.Format("SpecFlow.{0}.{1}", flowId, customSLA);
            if (Architect.Utilities.Cache.NotExist(key))
            {
                result = DataAccess.General.Process.Specification.Retrieve(flowId, companyId, customSLA);
                if (result != null)
                {
                    Architect.Utilities.Cache.SetItem(key, result);
                }
            }
            else
            {
                result = (Contracts.General.ProcessSpecFlow)Architect.Utilities.Cache.GetItem(key);
            }
            return result;
        }

        /// <summary>
        /// Recupera una instancia de un proceso y en caso de no existir crea una nueva previamente.
        /// </summary>
        /// <param name="newInstance">Información de la instancia.</param>
        /// <param name="token">Información del usuario conectando.</param>
        /// <returns>Instancia de un proceso.</returns>
        public static Contracts.General.InstanceInformation CreateAutomaticInstance(Contracts.General.CreateProcessInstance newInstance, Core.Contracts.Security.Token token)
        {
            Contracts.General.InstanceInformation result = null;
            if (Architect.API.Core.DataAccess.General.ProcessInstance.CountByEntity(newInstance.EntityType, newInstance.EntityId, token.CompanyId) == 0)
            {
                Contracts.General.ProcessInstance instance = CreateInstance(newInstance, token.UserId, token.CompanyId);
                result = CurrentByInstance(instance.InstanceId, 3, token);
            }
            else
            {
                result = CurrentByEntity(newInstance.EntityType, newInstance.EntityId, 3, token);
            }
            return result;
        }

        public static Contracts.General.ProcessInstance CreateInstance(Contracts.General.CreateProcessInstance newInstance, int userId, int companyId, int caseId = 0)
        {
            Contracts.General.ProcessSpecFlow spec = Specification(newInstance.FlowId, companyId, newInstance.SLA);
            List<Contracts.General.ProcessInstance> instance = new List<Contracts.General.ProcessInstance>();
            Contracts.General.ProcessInstance currentStep = null;
            DateTime current = DateTime.Now;
            bool firstTask = true;

            if (caseId == 0)
            {
                Contracts.General.ProcessCase caseInstance = General.ProcessCase.CreateRaw(companyId, userId, new Contracts.General.ProcessCase()
                {
                    Title = newInstance.Title,
                    Reference1 = newInstance.Reference1,
                    Reference2 = newInstance.Reference2,
                    Reference3 = newInstance.Reference3,
                    Reference4 = newInstance.Reference4,
                    ContactMainEmail = newInstance.ContactEmail,
                    ContactMainName = newInstance.ContactName,
                    Status = spec.ProcessSpecSteps.First().ProcessStatus,
                    Label = spec.ProcessSpecSteps.First().ProcessLabel,
                    FlowId = newInstance.FlowId,
                    SLA = newInstance.SLA
                });
                caseId = caseInstance.Id;
            }
            instance.Add(new Contracts.General.ProcessInstance()
            {
                CompanyId = companyId,
                CaseId = caseId,
                EntityType = newInstance.EntityType,
                EntityId = newInstance.EntityId,
                FlowId = newInstance.FlowId,
                Created = current,
                StartDate = current,
                UpdateUserCode = userId,
                UpdateDate = DateTime.Now
            });
            if (spec.SLALevels?.Count > 0)
            {
                instance[0].EarlyDueDate = current.AddHours(spec.SLALevels.First().SLATimeOut);
                instance[0].DueDate = current.AddHours(spec.SLALevels.Last().SLATimeOut);
            }

            foreach (Contracts.General.ProcessSpecStep stepSource in spec.ProcessSpecSteps)
            {
                instance.Add(new Contracts.General.ProcessInstance()
                {
                    CompanyId = companyId,
                    CaseId = caseId,
                    EntityType = newInstance.EntityType,
                    EntityId = newInstance.EntityId,
                    FlowId = newInstance.FlowId,
                    StepId = stepSource.Id,
                    Created = current,
                    UpdateUserCode = userId,
                    Step = stepSource,
                    StepName = stepSource.Name,
                    UpdateDate = DateTime.Now
                });

                if (firstTask)
                {
                    instance[instance.Count - 1].StartDate = current;
                    if (stepSource.SLALevels?.Count > 0)
                    {
                        instance[instance.Count - 1].EarlyDueDate = current.AddHours(stepSource.SLALevels.First().SLATimeOut);
                        instance[instance.Count - 1].DueDate = current.AddHours(stepSource.SLALevels.Last().SLATimeOut);
                    }
                    currentStep = instance[instance.Count - 1];
                }

                if (stepSource.ProcessSpecTasks.IsNotEmpty())
                {
                    foreach (Contracts.General.ProcessSpecTask taskSource in stepSource.ProcessSpecTasks)
                    {
                        instance.Add(new Contracts.General.ProcessInstance()
                        {
                            CompanyId = companyId,
                            CaseId = caseId,
                            EntityType = newInstance.EntityType,
                            EntityId = newInstance.EntityId,
                            FlowId = newInstance.FlowId,
                            StepId = stepSource.Id,
                            TaskId = taskSource.Id,
                            Created = current,
                            UpdateUserCode = userId,
                            Task = taskSource,
                            Step = stepSource,
                            TaskDesc = taskSource.Name,
                            UpdateDate = DateTime.Now
                        });
                        if (firstTask)
                        {
                            instance[instance.Count - 1].StartDate = current;
                            if (taskSource.SLATimeOut > 0)
                            {
                                instance[instance.Count - 1].DueDate = current.AddHours(taskSource.SLATimeOut);
                            }
                        }
                    }
                }
                if (firstTask)
                {
                    firstTask = false;
                }
            }

            List<Contracts.General.ProcessInstance> instanceCreated = DataAccess.General.Process.Specification.CreateInstance(instance);

            Notify_ContactProcess_Progress(caseId, currentStep, spec.MailServer, companyId, userId, true, null);
            Notify_ResponsibleProcess_Progress(caseId, currentStep, spec.MailServer, companyId, userId);


            return instanceCreated.First();
        }

        public static Contracts.General.InstanceInformation CurrentByEntity(int entityType, long entityId, int level, Core.Contracts.Security.Token tokenInfo)
        {
            return CurrentStep(InstanceRuntime(entityType, entityId, tokenInfo.CompanyId), level, tokenInfo);
        }

        public static Contracts.General.InstanceInformation CurrentByInstance(int instanceId, int level, Core.Contracts.Security.Token tokenInfo)
        {
            return CurrentStep(InstanceRuntime(instanceId, tokenInfo.CompanyId), level, tokenInfo);
        }

        public static Contracts.General.ProcessInstance TaskCompletedByEntity(int entityType, long entityId, Contracts.General.TaskChecked checkedInformation, int userId, int companyId)
        {
            return TaskCompleted(InstanceRuntime(entityType, entityId, companyId), checkedInformation, userId);
        }

        public static Contracts.General.ProcessInstance TaskCompletedByInstance(int instanceId, Contracts.General.TaskChecked checkedInformation, int userId, int companyId)
        {
            return TaskCompleted(InstanceRuntime(instanceId, companyId), checkedInformation, userId);
        }

        public static bool InstanceByEntityExist(int entityType, long entityId, int companyId)
        {
            return Architect.API.Core.DataAccess.General.ProcessInstance.CountByEntity(entityType, entityId, companyId) > 0;
        }

        private static Contracts.General.InstanceInformation CurrentStep(List<Contracts.General.ProcessInstance> instance, int level, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.General.InstanceInformation result = null;
            int stepCount = instance.Count(i => i.StepId > 0 && i.TaskId == 0);
            int stepReady = 1;

            if (instance == null)
            {
                return result;
            }
            result = new Contracts.General.InstanceInformation()
            {
                InstanceId = instance.First().InstanceId,
                CaseId = instance.First().CaseId,
                Tasks = new List<Contracts.General.TaskInformation>()
            };

            result.Steps = new List<Contracts.General.StepInformation>();
            List<Contracts.General.ProcessInstance> steps = null;
            Contracts.General.StepInformation s = null;
            switch (level)
            {
                case 1:
                    steps = instance.Where(i => i.StepId > 0 && i.TaskId == 0 && i.StartDate > DateTime.MinValue && i.FinishDate == DateTime.MinValue).ToList();
                    break;
                case 2:
                    steps = instance.Where(i => i.StepId > 0 && i.TaskId == 0 && i.StartDate > DateTime.MinValue).ToList();
                    break;
                case 3:
                    steps = instance.Where(i => i.StepId > 0 && i.TaskId == 0).ToList();
                    break;
            }

            foreach (Contracts.General.ProcessInstance step in steps)
            {
                s = new Contracts.General.StepInformation()
                {
                    ActivityId = step.ActivityId,
                    StepId = step.StepId,
                    Name = step.Step.Name,
                    Description = step.Step.Description,
                    UserId = step.UserId,
                    UserName = step.UserName,
                    Comments = step.Comments,
                    Status = step.Step.ProcessStatus,
                    Label = step.Step.ProcessLabel,
                    Wait = "on",
                    ProgressMode = step.Step.ProgressMode
                };
                if (step.StartDate.IsNotEmpty())
                {
                    s.StartDate = step.StartDate;
                }
                if (step.DueDate.IsNotEmpty())
                {
                    s.DueDate = step.DueDate;
                }
                if (step.FinishDate.IsNotEmpty())
                {
                    s.FinishDate = step.FinishDate;
                    s.Wait = "";
                    stepReady++;
                }

                if (step.FinishDate.IsNotEmpty() && s.Label.IsEmpty())
                {
                    if (s.Status > 0 && s.Status <= 10)
                    {
                        s.Label = "Iniciado";
                    }
                    else if (s.Status == 0 || (s.Status > 10 && s.Status < 90))
                    {
                        s.Status = 11;
                        s.Label = "En progreso";
                    }
                    else
                    {
                        s.Label = "Finalizado";
                    }
                    result.Status = s.Status;
                    result.Label = s.Label;
                }
                result.Steps.Add(s);
            }

            Contracts.General.ProcessInstance curentStep = instance.FirstOrDefault(i => i.StepId > 0 && i.TaskId == 0 && i.StartDate > DateTime.MinValue && i.FinishDate == DateTime.MinValue);
            bool showTasks = true;
            int lastActivityId = int.MaxValue;

            if (curentStep != null)
            {
                lastActivityId = curentStep.ActivityId;
                result.ActivityId = lastActivityId;
            }
            foreach (Contracts.General.StepInformation step in result.Steps.Where(i => i.ActivityId < lastActivityId && i.StartDate == null))
            {
                step.Wait = string.Empty;
                stepReady++;
            }

            result.Progress = stepCount <= stepReady ? 100 : 100 / stepCount * stepReady;


            if (curentStep?.Step?.ProcessSpecStepRoles?.Count > 0)
            {
                showTasks = false;
                foreach (Contracts.General.ProcessSpecStepRole stepRole in curentStep?.Step?.ProcessSpecStepRoles)
                {
                    if (string.Format(",{0},", tokenInfo.Roles).Contains(string.Format(",{0},", stepRole.RoleName)))
                    {
                        showTasks = true;
                        break;
                    }
                }

            }

            if (curentStep != null && showTasks)
            {
                Contracts.General.TaskInformation t = null;
                foreach (Contracts.General.ProcessInstance task in instance.Where(i => i.StepId == curentStep.StepId && i.TaskId > 0))
                {
                    t = new Contracts.General.TaskInformation()
                    {
                        ActivityId = task.ActivityId,
                        TaskId = task.TaskId,
                        Name = task.Task.Name,
                        Description = task.Task.Description,
                        Type = task.Task.Type,
                        Action = task.Task.Action
                    };
                    if (task.DueDate.IsNotEmpty())
                    {
                        t.DueDate = task.DueDate;
                    }
                    if (task.FinishDate.IsNotEmpty())
                    {
                        t.FinishDate = task.FinishDate;
                    }
                    if (t.Type == 10)
                    {
                        foreach (Contracts.General.ProcessInstance step in steps)
                        {
                            if (step.StepId == Convert.ToInt32(t.Action))
                            {
                                t.NotifyToContact = step.Step.MailToContact;
                                break;
                            }
                        }
                    }
                    result.Tasks.Add(t);
                }
            }
            return result;
        }

        private static List<Contracts.General.ProcessInstance> InstanceRuntime(int entityType, long entityId, int companyId)
        {
            List<Contracts.General.ProcessInstance> instance = Architect.API.Core.DataAccess.General.ProcessInstance.RetrieveByEntity(entityType, entityId, companyId);
            if (instance == null || instance.Count == 0)
            {
                Architect.Utilities.Log.ErrorLog("InstanceRuntime", "no existe la instancia");
                throw new Exception("no existe la instancia");
            }
            return InstanceComplement(instance.OrderBy(s => s.ActivityId).ToList(), companyId);
        }

        private static List<Contracts.General.ProcessInstance> InstanceRuntime(int instanceId, int companyId)
        {
            List<Contracts.General.ProcessInstance> instance = Architect.API.Core.DataAccess.General.ProcessInstance.RetrieveByInstanceId(instanceId, companyId);
            if (instance == null || instance.Count == 0)
            {
                Architect.Utilities.Log.ErrorLog("InstanceRuntime", "no existe la instancia");
                throw new Exception("no existe la instancia");

            }
            return InstanceComplement(instance, companyId);
        }

        private static List<Contracts.General.ProcessInstance> InstanceComplement(List<Contracts.General.ProcessInstance> instance, int companyId)
        {

            Contracts.General.ProcessSpecFlow spec = Specification(instance.First().FlowId, companyId, instance.First().SLA);
            if (spec == null)
            {
                Architect.Utilities.Log.ErrorLog("InstanceComplement", "El proceso fue eliminado");
                throw new Exception("El proceso fue eliminado");
            }
            foreach (Contracts.General.ProcessSpecStep stepSource in spec.ProcessSpecSteps)
            {
                // instance.Find(i => i.StepId == stepSource.Id).Step = stepSource;; FALLO
                foreach (Contracts.General.ProcessInstance item in instance)
                {
                    if (item.StepId == stepSource.Id)
                    {
                        item.Step = stepSource;
                    }
                }
                if (stepSource.ProcessSpecTasks.IsNotEmpty())
                {
                    foreach (Contracts.General.ProcessSpecTask taskSource in stepSource.ProcessSpecTasks)
                    {
                        // instance.Find(i => i.TaskId == taskSource.Id).Task = taskSource; FALLO
                        foreach (Contracts.General.ProcessInstance item in instance)
                        {
                            if (item.TaskId == taskSource.Id)
                            {
                                item.Task = taskSource;
                            }
                        }
                    }
                }
            }
            foreach (Contracts.General.ProcessInstance stepSource in instance)
            {
                if (stepSource.StepId > 0 && stepSource.TaskId == 0)
                {
                    stepSource.StepName = stepSource.Step.Name;
                }
                if (stepSource.TaskId > 0)
                {
                    stepSource.TaskDesc = stepSource.Task.Name;
                }
            }
            return instance;
        }

        private static Contracts.General.ProcessInstance GetNextStep(List<Contracts.General.ProcessInstance> instance, int stepId)
        {
            Contracts.General.ProcessInstance result = null;
            bool currentFinded = false;
            foreach (Contracts.General.ProcessInstance step in instance.Where(i => i.StepId > 0 && i.TaskId == 0))
            {
                if (!currentFinded && step.StepId == stepId)
                {
                    currentFinded = true;
                }
                if (currentFinded && step.StepId != stepId)
                {
                    result = step;
                    break;
                }
            }
            return result;
        }

        private static Contracts.General.ProcessInstance TaskCompleted(List<Contracts.General.ProcessInstance> instance, Contracts.General.TaskChecked checkedInformation, int userId)
        {
            Contracts.General.ProcessInstance currentTask = instance.First(i => i.ActivityId == checkedInformation.ActivityId);
            Contracts.General.ProcessInstance currentStep = instance.First(i => i.StepId == currentTask.StepId && i.TaskId == 0);
            Contracts.General.ProcessInstance currentFlow = instance.First(i => i.FlowId == currentTask.FlowId && i.StepId == 0 && i.TaskId == 0);
            Contracts.General.ProcessInstance nextStep = null;
            DateTime current = DateTime.Now;
            List<Contracts.General.ProcessInstance> toUpdate = new List<Contracts.General.ProcessInstance>();

            if (currentStep.Step.ProgressMode == 1)
            {
                currentTask.FinishDate = current;
            }
            else
            {
                //Permite marcar o desmarcar la opción
                if (currentTask.FinishDate.IsEmpty())
                {
                    currentTask.FinishDate = current;
                }
                else
                {
                    currentTask.FinishDate = DateTime.MinValue;
                }
            }
            currentTask.UserId = userId;
            currentTask.Comments = checkedInformation.Comment;
            currentTask.UpdateUserCode = userId;
            currentTask.UpdateDate = DateTime.Now;
            toUpdate.Add(currentTask);
            if (currentStep.Step.ProgressMode == 1)
            {
                foreach (Contracts.General.ProcessInstance ignoreTask in instance.Where(i => i.StepId == currentTask.StepId && i.TaskId > 0 && i.TaskId != currentTask.TaskId))
                {
                    ignoreTask.StartDate = DateTime.MinValue;
                    ignoreTask.UpdateUserCode = userId;
                    ignoreTask.UpdateDate = DateTime.Now;
                    toUpdate.Add(ignoreTask);
                }
                currentStep.FinishDate = current;
                currentStep.UserId = userId;
                //currentStep.Comments = checkedInformation.Comment;
                currentStep.UpdateUserCode = userId;
                currentStep.UpdateDate = DateTime.Now;
                toUpdate.Add(currentStep);
            }
            if (currentStep.Step.ProgressMode == 2 && currentTask.FinishDate.IsNotEmpty())
            {
                if (!instance.Any(i => i.StepId == currentTask.StepId && i.TaskId > 0 && i.FinishDate == DateTime.MinValue))
                {
                    currentStep.FinishDate = current;
                    currentStep.UserId = userId;
                    //currentStep.Comments = checkedInformation.Comment;
                    currentStep.UpdateUserCode = userId;
                    currentStep.UpdateDate = DateTime.Now;
                    toUpdate.Add(currentStep);


                    nextStep = GetNextStep(instance, currentStep.StepId);
                    if (nextStep.IsNotEmpty())
                    {
                        nextStep.StartDate = current;
                        if (nextStep.Step?.SLALevels?.Count > 0)
                        {
                            nextStep.EarlyDueDate = current.AddHours(nextStep.Step.SLALevels.First().SLATimeOut);
                            nextStep.DueDate = current.AddHours(nextStep.Step.SLALevels.Last().SLATimeOut);
                        }
                        nextStep.UpdateUserCode = userId;
                        nextStep.PreviousActivityId = currentTask.ActivityId;
                        nextStep.Comments = checkedInformation.Comment;
                        nextStep.UpdateDate = DateTime.Now;
                        toUpdate.Add(nextStep);

                        foreach (Contracts.General.ProcessInstance nextSubTask in instance.Where(i => i.StepId == nextStep.StepId && i.TaskId > 0))
                        {
                            nextSubTask.StartDate = current;
                            if (nextSubTask.Task.SLATimeOut > 0)
                            {
                                nextSubTask.DueDate = current.AddHours(nextSubTask.Task.SLATimeOut);
                            }
                            nextSubTask.UpdateUserCode = userId;
                            nextSubTask.PreviousActivityId = currentTask.ActivityId;
                            nextSubTask.UpdateDate = DateTime.Now;
                            toUpdate.Add(nextSubTask);
                        }
                    }
                }
            }
            if (currentStep.Step.ProgressMode == 1)
            {
                switch (currentTask.Task.Type)
                {
                    case 10:
                        nextStep = instance.First(i => i.StepId == Convert.ToInt32(currentTask.Task.Action));
                        nextStep.StartDate = current;
                        if (nextStep.Step?.SLALevels?.Count > 0)
                        {
                            nextStep.EarlyDueDate = current.AddHours(nextStep.Step.SLALevels.First().SLATimeOut);
                            nextStep.DueDate = current.AddHours(nextStep.Step.SLALevels.Last().SLATimeOut);
                        }
                        nextStep.UpdateUserCode = userId;
                        nextStep.PreviousActivityId = currentTask.ActivityId;
                        nextStep.Comments = checkedInformation.Comment;
                        nextStep.UpdateDate = DateTime.Now;
                        toUpdate.Add(nextStep);
                        foreach (Contracts.General.ProcessInstance nextSubTask in instance.Where(i => i.StepId == nextStep.StepId && i.TaskId > 0))
                        {
                            nextSubTask.StartDate = current;
                            if (nextSubTask.Task.SLATimeOut > 0)
                            {
                                nextSubTask.DueDate = current.AddHours(nextSubTask.Task.SLATimeOut);
                            }
                            nextSubTask.UpdateUserCode = userId;
                            nextSubTask.PreviousActivityId = currentTask.ActivityId;
                            nextSubTask.UpdateDate = DateTime.Now;
                            toUpdate.Add(nextSubTask);
                        }
                        break;

                }
            }
            // 3=Finalizado, 6= Cerrado, 7=Aprobado, 8=Rechazado, 90=?
            if (nextStep?.Step?.ProcessStatus == 3 ||
                nextStep?.Step?.ProcessStatus == 6 ||
                nextStep?.Step?.ProcessStatus == 7 ||
                nextStep?.Step?.ProcessStatus == 8 ||
                nextStep?.Step?.ProcessStatus == 90)
            {
                nextStep.FinishDate = current;
                nextStep.UserId = userId;
                nextStep.UpdateUserCode = userId;

                currentFlow.FinishDate = current;
                currentFlow.UserId = userId;
                currentFlow.UpdateUserCode = userId;
                currentFlow.UpdateDate = DateTime.Now;
                toUpdate.Add(currentFlow);
            }
            DataAccess.General.Process.Specification.UpdateInstance(toUpdate, currentTask);

            Contracts.General.ProcessSpecFlow spec = Specification(currentFlow.FlowId, currentFlow.CompanyId, currentFlow.SLA);
            List<string> attachments = new List<string>();

            if (checkedInformation.Attachments.IsNotEmpty())
            {
                foreach (Contracts.General.Attachment attachment in checkedInformation.Attachments)
                {
                    attachments.Add(Path.Combine(ConfigurationManager.AppSettings["Attachments.Path"], attachment.StoredFileName) + ";" + attachment.FileName);
                }
            }
            if (currentStep.Step.ProgressMode == 1)
            {
                Notify_ContactProcess_Progress(currentFlow.CaseId, nextStep, spec.MailServer, currentFlow.CompanyId, userId, checkedInformation.Notify, attachments.ToArray());
                Notify_ResponsibleProcess_Progress(currentFlow.CaseId, nextStep, spec.MailServer, currentFlow.CompanyId, userId);
            }
            if (currentStep.Step.ProgressMode == 2)
            {
                if (nextStep.IsNotEmpty())
                {
                    Notify_ContactProcess_Progress(currentFlow.CaseId, nextStep, spec.MailServer, currentFlow.CompanyId, userId, checkedInformation.Notify, attachments.ToArray());
                    Notify_ResponsibleProcess_Progress(currentFlow.CaseId, nextStep, spec.MailServer, currentFlow.CompanyId, userId);
                }
                else
                {
                    nextStep = currentStep;
                }

            }
            return nextStep;
        }

        private static void Notify_ContactProcess_Progress(int caseId, Contracts.General.ProcessInstance step, int mailServer, int companyId, int userId, bool notify, string[] attachments)
        {
            Dictionary<string, string> mailFullList = new Dictionary<string, string>();
            Contracts.General.ProcessCase procCase = null;
            string mailList = string.Empty;
            string mailAddress = string.Empty;

            if (step.Step.MailToContact == 1) //Si
            {
                mailList += "{contact}";
            }
            else if (step.Step.MailToContact == 3 && notify)
            {
                if (mailList != string.Empty)
                {
                    mailList += ",";
                }
                mailList += step.Step.MailToContactCustom;
            }

            foreach (string entry in mailList.Split(','))
            {
                mailAddress = string.Empty;
                if (entry.Equals("{contact}", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (procCase == null)
                    {
                        procCase = Business.General.ProcessCase.RetrieveById(companyId, caseId);
                    }
                    if (procCase?.ContactMainEmail != string.Empty)
                    {
                        mailAddress = procCase.ContactMainEmail;
                    }
                }
                if (entry.Equals("{user}", StringComparison.CurrentCultureIgnoreCase))
                {
                    Architect.API.Core.Contracts.Security.UserMember currentUserInfo = Architect.API.Core.Business.Security.UserMember.RetrieveById(companyId, userId);
                    if (currentUserInfo?.EMail != string.Empty)
                    {
                        mailAddress = currentUserInfo.EMail;
                    }
                }

                if (mailAddress.IsNotEmpty() && !mailFullList.ContainsKey(mailAddress))
                {
                    mailFullList.Add(mailAddress, string.Empty);
                }
            }

            if (mailFullList.Count > 0)
            {
                string mailTemplate = ConfigurationManager.AppSettings["Process.Mail.Contact.Notify.Template"];
                if (step.Step.MailToContactTmpl != 1)
                {
                    mailTemplate = Common.LkpDescription(companyId, "MailTemplateKey", step.Step.MailToContactTmpl.ToString());
                }
                if (step.Step.MailServer != 1)
                {
                    mailServer = step.Step.MailServer;
                }
                if (procCase == null)
                {
                    procCase = Business.General.ProcessCase.RetrieveById(companyId, caseId);
                }

                Mail.SendByTemplate(Common.LkpDescription(companyId, "MailServer", mailServer.ToString()), mailTemplate, companyId, userId, new { Case = procCase, Next = step }, mailFullList, attachments);
            }
        }

        private static void Notify_ResponsibleProcess_Progress(int caseId, Contracts.General.ProcessInstance step, int mailServer, int companyId, int userId, string mailTemplateSetting = "Process.Mail.Responsible.Notify.Template")
        {
            Dictionary<string, string> mailFullList = new Dictionary<string, string>();
            Contracts.General.ProcessCase procCase = null;

            if (step.Step.MailToStepResponsible == 1 || step.Step.MailToStepResponsible == 3)
            {
                string templList = step.Step.MailToStepResponsibleCustom;
                if (templList.IndexOf("{Roles}", StringComparison.CurrentCultureIgnoreCase) > -1 && step.Step.ProcessSpecStepRoles?.Count > 0)
                {
                    foreach (Contracts.General.ProcessSpecStepRole stepRole in step.Step.ProcessSpecStepRoles)
                    {
                        foreach (KeyValuePair<string, string> entry in Security.UserMember.EmailListByRolename(companyId, stepRole.RoleName))
                        {
                            if (!mailFullList.ContainsKey(entry.Key))
                            {
                                mailFullList.Add(entry.Key, entry.Value);
                            }
                        }
                    }
                    templList = templList.Replace("{Roles", string.Empty);
                }
                foreach (string entry in templList.Split(','))
                {
                    if (entry.IsNotEmpty() && !mailFullList.ContainsKey(entry))
                    {
                        mailFullList.Add(entry, string.Empty);
                    }
                }
            }

            if (mailFullList.Count > 0)
            {
                string mailTemplate = ConfigurationManager.AppSettings[mailTemplateSetting];
                if (step.Step.MailToStepResponsibleTmpl != 1)
                {
                    mailTemplate = Common.LkpDescription(companyId, "MailTemplateKey", step.Step.MailToStepResponsibleTmpl.ToString());
                }
                if (step.Step.MailServer != 1)
                {
                    mailServer = step.Step.MailServer;
                }
                if (procCase == null)
                {
                    procCase = ProcessCase.RetrieveById(companyId, caseId);
                }
                Mail.SendByTemplate(Common.LkpDescription(companyId, "MailServer", mailServer.ToString()), mailTemplate, companyId, userId, new { Case = procCase, Next = step }, mailFullList);
            }
        }

        private static void Notify(int caseId, int responsible, string custom, int mailTmpl, int customMailServer, int mailServer, object entity, List<Contracts.General.LookupValue> roles, int companyId, int userId, string mailTemplateSetting = "Process.Mail.Responsible.Notify.Template")
        {
            Dictionary<string, string> mailFullList = new Dictionary<string, string>();
            Contracts.General.ProcessCase procCase = null;

            if (responsible == 1 || responsible == 3)
            {
                string templList = custom;
                if (templList.IndexOf("{Roles}", StringComparison.CurrentCultureIgnoreCase) > -1 && roles?.Count > 0)
                {
                    foreach (Contracts.General.LookupValue stepRole in roles)
                    {
                        foreach (KeyValuePair<string, string> entry in Security.UserMember.EmailListByRolename(companyId, stepRole.Description))
                        {
                            if (!mailFullList.ContainsKey(entry.Key))
                            {
                                mailFullList.Add(entry.Key, entry.Value);
                            }
                        }
                    }
                    templList = templList.Replace("{Roles", string.Empty);
                }
                foreach (string entry in templList.Split(','))
                {
                    if (entry.IsNotEmpty() && !mailFullList.ContainsKey(entry))
                    {
                        mailFullList.Add(entry, string.Empty);
                    }
                }
            }

            if (mailFullList.Count > 0)
            {
                string mailTemplate = ConfigurationManager.AppSettings[mailTemplateSetting];
                if (mailTmpl != 1)
                {
                    mailTemplate = Common.LkpDescription(companyId, "MailTemplateKey", mailTmpl.ToString());
                }
                if (customMailServer != 1)
                {
                    mailServer = customMailServer;
                }
                if (procCase == null)
                {
                    procCase = ProcessCase.RetrieveById(companyId, caseId);
                }
                Mail.SendByTemplate(Common.LkpDescription(companyId, "MailServer", mailServer.ToString()), mailTemplate, companyId, userId, new { Case = procCase, Next = entity }, mailFullList);
            }
        }

        public static void CaseComplement(int caseId, Contracts.General.CaseComplement caseComplement, Core.Contracts.Security.Token token)
        {
            ProcessCaseComplement.CreateOrUpdate(token.CompanyId, token.UserId, caseId,
                new Contracts.General.ProcessCaseComplement()
                {
                    Fee = caseComplement.Fee,
                    Compensation = caseComplement.Compensation,
                    Deductible = caseComplement.Deductible,
                    SpareParts = caseComplement.SpareParts,
                    ManPower = caseComplement.ManPower,
                    Workshop = caseComplement.Workshop,
                    ManPowerInvoice = caseComplement.ManPowerInvoice,
                    SparePartsInvoice = caseComplement.SparePartsInvoice,
                    SettlementDate = caseComplement.SettlementDate,
                    AppointmentDate = caseComplement.AppointmentDate,
                    AppointmentTime = caseComplement.AppointmentTime,
                    AssignedAdvisor = caseComplement.AssignedAdvisor,
                    ReportDate = caseComplement.ReportDate,
                    RepairManPower = caseComplement.RepairManPower,
                    RepairSpareParts = caseComplement.RepairSpareParts,
                    RepairTotalAmount = caseComplement.RepairTotalAmount,
                    SetSpaFee = caseComplement.SetSpaFee,
                    SetSpaCompensation = caseComplement.SetSpaCompensation,
                    SetSpaDeductible = caseComplement.SetSpaDeductible,
                    SetSpaSpareParts = caseComplement.SetSpaSpareParts,
                    SetSpaManPower = caseComplement.SetSpaManPower,
                    SetSpaManPowerInvoice = caseComplement.SetSpaManPowerInvoice,
                    SetSpaSparePartsInvoice = caseComplement.SetSpaSparePartsInvoice,
                    SetSpaSettlementDate = caseComplement.SetSpaSettlementDate
                });
        }

        public static Contracts.General.CaseComplement CaseComplement(int caseId, Core.Contracts.Security.Token token)
        {
            Contracts.General.CaseComplement result = null;
            Contracts.General.ProcessCaseComplement info = ProcessCaseComplement.RetrieveById(caseId, token.CompanyId);
            if (info != null)
            {
                result = new Contracts.General.CaseComplement()
                {
                    Fee = info.Fee,
                    Compensation = info.Compensation,
                    Deductible = info.Deductible,
                    SpareParts = info.SpareParts,
                    ManPower = info.ManPower,
                    Workshop = info.Workshop,
                    WorkshopDesc = info.WorkshopDesc,
                    ManPowerInvoice = info.ManPowerInvoice,
                    SparePartsInvoice = info.SparePartsInvoice,
                    SettlementDate = info.SettlementDate,
                    AppointmentDate = info.AppointmentDate,
                    AppointmentTime = info.AppointmentTime,
                    AssignedAdvisor = info.AssignedAdvisor,
                    ReportDate = info.ReportDate,
                    RepairManPower = info.RepairManPower,
                    RepairSpareParts = info.RepairSpareParts,
                    RepairTotalAmount = info.RepairTotalAmount,
                    SetSpaFee = info.SetSpaFee,
                    SetSpaCompensation = info.SetSpaCompensation,
                    SetSpaDeductible = info.SetSpaDeductible,
                    SetSpaSpareParts = info.SetSpaSpareParts,
                    SetSpaManPower = info.SetSpaManPower,
                    SetSpaManPowerInvoice = info.SetSpaManPowerInvoice,
                    SetSpaSparePartsInvoice = info.SetSpaSparePartsInvoice,
                    SetSpaSettlementDate = info.SetSpaSettlementDate
                };
            }
            return result;
        }

    }
}
