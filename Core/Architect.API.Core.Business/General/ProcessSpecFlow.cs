using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Especificación de un proceso.
    /// </summary>
    public static partial class ProcessSpecFlow
    {
        private const string ErrorGroup = "ProcessSpecFlow";
        private const int ProcessStatusInicio = 1;
        private const int ProcessStatusEnProgreso = 2;
        private const int ProcessStatusFinalizado = 3;
        private const int ProcessStatusIngresado = 4;
        private const int ProcessStatusEnEspera = 5;
        private const int ProcessStatusCerrado = 6;
        private const int ProcessStatusAprobado = 7;
        private const int ProcessStatusRechazado = 8;
        private const int TaskTypeNavigation = 10;
        private const int MinimumSteps = 3;

        /// <summary>
        /// Valida la estructura y configuración de un flujo de proceso.
        /// </summary>
        public static List<Core.Contracts.General.Error> ValidateEx(int companyId, Architect.API.Core.Contracts.General.ProcessSpecFlow source)
        {
            List<Core.Contracts.General.Error> errors = new List<Core.Contracts.General.Error>();

            Contracts.General.ProcessSpecFlow spec = DataAccess.General.Process.Specification.Retrieve(source.Id, companyId, 0);

            ValidateMinimumStepsCount(spec, errors);
            ValidateInitialStepExists(spec, errors);
            ValidateFinalStepExists(spec, errors);
            ValidateActiveStepsHaveTasks(spec, errors);
            
            HashSet<int> referencedStepIds = BuildReferencedStepsSet(spec);
            ValidateNonInitialStepsAreReferenced(spec, errors, referencedStepIds);
            ValidateSingleTaskStepsDoNotCreateCycles(spec, errors);

            return errors;
        }

        /// <summary>
        /// Valida que el proceso tenga al menos tres etapas.
        /// </summary>
        private static void ValidateMinimumStepsCount(Contracts.General.ProcessSpecFlow spec, List<Core.Contracts.General.Error> errors)
        {
            if (spec.ProcessSpecSteps.Count < MinimumSteps)
            {
                errors.Add(new Core.Contracts.General.Error()
                {
                    Group = ErrorGroup,
                    Key = "*",
                    Message = "El proceso debe tener por lo menos tres pasos."
                });
            }
        }

        /// <summary>
        /// Valida que exista al menos una etapa con estado inicial.
        /// </summary>
        private static void ValidateInitialStepExists(Contracts.General.ProcessSpecFlow spec, List<Core.Contracts.General.Error> errors)
        {
            bool hasInitialStep = spec.ProcessSpecSteps.Any(step => step.ProcessStatus == ProcessStatusInicio || step.ProcessStatus == ProcessStatusIngresado);
            if (!hasInitialStep)
            {
                errors.Add(new Core.Contracts.General.Error()
                {
                    Group = ErrorGroup,
                    Key = "*",
                    Message = "El proceso debe tener por lo menos una etapa con estado 'Inicio' o 'Ingresado'."
                });
            }
        }

        /// <summary>
        /// Valida que exista al menos una etapa con estado final.
        /// </summary>
        private static void ValidateFinalStepExists(Contracts.General.ProcessSpecFlow spec, List<Core.Contracts.General.Error> errors)
        {
            bool hasFinalStep = spec.ProcessSpecSteps.Any(step => 
                step.ProcessStatus == ProcessStatusFinalizado || 
                step.ProcessStatus == ProcessStatusCerrado || 
                step.ProcessStatus == ProcessStatusAprobado || 
                step.ProcessStatus == ProcessStatusRechazado);

            if (!hasFinalStep)
            {
                errors.Add(new Core.Contracts.General.Error()
                {
                    Group = ErrorGroup,
                    Key = "*",
                    Message = "El proceso debe tener por lo menos una etapa con estado 'Finalizado', 'Cerrado', 'Aprobado' o 'Rechazado'."
                });
            }
        }

        /// <summary>
        /// Valida que las etapas activas (En progreso o En espera) tengan al menos una tarea definida.
        /// </summary>
        private static void ValidateActiveStepsHaveTasks(Contracts.General.ProcessSpecFlow spec, List<Core.Contracts.General.Error> errors)
        {
            foreach (Contracts.General.ProcessSpecStep step in spec.ProcessSpecSteps)
            {
                bool isActiveStatus = step.ProcessStatus == ProcessStatusEnProgreso || step.ProcessStatus == ProcessStatusEnEspera;
                bool hasNoTasks = step.ProcessSpecTasks == null || step.ProcessSpecTasks.Count == 0;

                if (isActiveStatus && hasNoTasks)
                {
                    errors.Add(new Core.Contracts.General.Error()
                    {
                        Group = ErrorGroup,
                        Key = "*",
                        Message = string.Format("La etapa '{0}' con estado 'En progreso' o 'En espera' debe tener por lo menos una tarea definida.", step.Name)
                    });
                }
            }
        }

        /// <summary>
        /// Construye un conjunto con los identificadores de todas las etapas referenciadas por tareas de navegación.
        /// </summary>
        private static HashSet<int> BuildReferencedStepsSet(Contracts.General.ProcessSpecFlow spec)
        {
            HashSet<int> referencedStepIds = new HashSet<int>();

            foreach (Contracts.General.ProcessSpecStep step in spec.ProcessSpecSteps)
            {
                if (step.ProcessSpecTasks != null)
                {
                    foreach (Contracts.General.ProcessSpecTask task in step.ProcessSpecTasks)
                    {
                        if (task.Type == TaskTypeNavigation && task.Action != "0")
                        {
                            int targetStepId;
                            if (int.TryParse(task.Action, out targetStepId))
                            {
                                referencedStepIds.Add(targetStepId);
                            }
                        }
                    }
                }
            }

            return referencedStepIds;
        }

        /// <summary>
        /// Valida que todas las etapas no iniciales sean referenciadas por al menos una tarea.
        /// </summary>
        private static void ValidateNonInitialStepsAreReferenced(Contracts.General.ProcessSpecFlow spec, List<Core.Contracts.General.Error> errors, HashSet<int> referencedStepIds)
        {
            foreach (Contracts.General.ProcessSpecStep step in spec.ProcessSpecSteps)
            {
                bool isNonInitialStep = step.ProcessStatus != ProcessStatusInicio && step.ProcessStatus != ProcessStatusIngresado;
                bool isNotReferenced = !referencedStepIds.Contains(step.Id);

                if (isNonInitialStep && isNotReferenced)
                {
                    errors.Add(new Core.Contracts.General.Error()
                    {
                        Group = ErrorGroup,
                        Key = "*",
                        Message = string.Format("La etapa '{0}' no es llamada por ninguna tarea", step.Name)
                    });
                }
            }
        }

        /// <summary>
        /// Valida que las etapas con una sola tarea no creen ciclos infinitos al apuntar a sí mismas o a etapas anteriores.
        /// </summary>
        private static void ValidateSingleTaskStepsDoNotCreateCycles(Contracts.General.ProcessSpecFlow spec, List<Core.Contracts.General.Error> errors)
        {
            foreach (Contracts.General.ProcessSpecStep step in spec.ProcessSpecSteps)
            {
                if (step.ProcessSpecTasks != null && step.ProcessSpecTasks.Count == 1)
                {
                    Contracts.General.ProcessSpecTask task = step.ProcessSpecTasks[0];
                    if (task.Type == TaskTypeNavigation && task.Action != "0")
                    {
                        int targetStepId;
                        if (int.TryParse(task.Action, out targetStepId))
                        {
                            Contracts.General.ProcessSpecStep targetStep = spec.ProcessSpecSteps.FirstOrDefault(s => s.Id == targetStepId);
                            if (targetStep != null && targetStep.StepOrder <= step.StepOrder)
                            {
                                errors.Add(new Core.Contracts.General.Error()
                                {
                                    Group = ErrorGroup,
                                    Key = "*",
                                    Message = string.Format("La etapa '{0}' tiene solo una tarea que apunta a la misma etapa o a una etapa superior en el orden, lo que puede generar un ciclo infinito.", step.Name)
                                });
                            }
                        }
                    }
                }
            }
        }

        public static string Diagram(int companyId, int userId, int id, string diagramType)
        {
            Contracts.General.ProcessSpecFlow spec = DataAccess.General.Process.Specification.Retrieve(id, companyId, 0);
            StringBuilder result = new StringBuilder();

            switch (diagramType.ToLower())
            {
                case "sequence":
                    result.AppendLine("sequenceDiagram");
                    result.AppendLine("  autonumber");
                    foreach (Contracts.General.ProcessSpecStep step in spec.ProcessSpecSteps)
                    {
                        foreach (Contracts.General.ProcessSpecTask task in step.ProcessSpecTasks)
                        {
                            if (task.Type == 10 && task.Action != "0")
                            {
                                Contracts.General.ProcessSpecStep action = spec.ProcessSpecSteps.Where(r => r.Id == Convert.ToInt32(task.Action)).FirstOrDefault();

                                result.AppendFormat("  S{0} {1} ->> S{2} {3}:{4}", step.StepOrder, step.Name.Capitalize(), action.StepOrder, action.Name.Capitalize(), task.Name.Capitalize());

                                result.AppendLine();
                            }
                        }

                    }
                    break;
                case "flowchart":
                    result.AppendLine("flowchart TD");
                    foreach (Contracts.General.ProcessSpecStep step in spec.ProcessSpecSteps)
                    {
                        foreach (Contracts.General.ProcessSpecTask task in step.ProcessSpecTasks)
                        {
                            if (task.Type == 10 && task.Action != "0")
                            {
                                Contracts.General.ProcessSpecStep action = spec.ProcessSpecSteps.Where(r => r.Id == Convert.ToInt32(task.Action)).FirstOrDefault();

                                result.AppendFormat("  S{0}[{1}] --> |{4}| S{2}[{3}]", step.StepOrder, step.Name.Capitalize(),
                                                                                 action.StepOrder, action.Name.Capitalize(),
                                                                                 task.Name.Capitalize());

                                result.AppendLine();
                            }
                        }

                    }
                    break;
                case "statediagram":
                    Contracts.General.ProcessSpecStep first = null;
                    Contracts.General.ProcessSpecStep last = null;
                    result.AppendLine("stateDiagram-v2");
                    foreach (Contracts.General.ProcessSpecStep step in spec.ProcessSpecSteps)
                    {
                        result.AppendFormat("  S{0} : S{0} {1}", step.StepOrder, step.Name.Capitalize());
                        result.AppendLine();
                    }
                    foreach (Contracts.General.ProcessSpecStep step in spec.ProcessSpecSteps)
                    {
                        if (first == null)
                        {
                            first = step;
                            result.AppendFormat("  [*] --> S{0}", step.StepOrder, step.Name.Capitalize());
                            result.AppendLine();
                        }
                        foreach (Contracts.General.ProcessSpecTask task in step.ProcessSpecTasks)
                        {
                            if (task.Type == 10 && task.Action != "0")
                            {
                                Contracts.General.ProcessSpecStep action = spec.ProcessSpecSteps.Where(r => r.Id == Convert.ToInt32(task.Action)).FirstOrDefault();

                                result.AppendFormat("  S{0} --> S{2}:{4}", step.StepOrder, step.Name.Capitalize(),
                                                                                 action.StepOrder, action.Name.Capitalize(),
                                                                                 task.Name.Capitalize());

                                result.AppendLine();
                            }
                        }
                        last = step;
                    }
                    result.AppendFormat("  S{0} --> [*]", last.StepOrder, last.Name.Capitalize());
                    result.AppendLine();
                    break;
            }
            return result.ToString();
        }

        public static bool Import(int companyId, int userId, string stored, string fileSize, string fileName)
        {
            string fullPath = Path.Combine(HostingEnvironment.MapPath(ConfigurationManager.AppSettings["Files.Path"]), stored);

            Contracts.General.ProcessSpecFlowResult result = Duplicate(Utilities.SerializeHandler<Contracts.General.ProcessSpecFlow>.DeserializeJSONFromFile(fullPath), companyId, userId, String.Empty);
            return true;
        }
        public static string Export(int companyId, int userId, int id)
        {
            Contracts.General.ProcessSpecFlow result = DataAccess.General.Process.Specification.Retrieve(id, companyId, 0);
            return Utilities.SerializeHandler<Contracts.General.ProcessSpecFlow>.SerializeJSON(result, false, false, true, Newtonsoft.Json.TypeNameHandling.None);
        }

        /// <summary>
        /// Duplica un proceso y todas las tablas relacionadas.
        /// </summary>
        public static Contracts.General.ProcessSpecFlowResult DuplicateById(int companyId, int userId, int id)
        {
            return Duplicate(DataAccess.General.Process.Specification.Retrieve(id, companyId, 0), companyId, userId, " (copia)");
        }

        /// <summary>
        /// Duplica un proceso y todas las tablas relacionadas.
        /// </summary>
        public static Contracts.General.ProcessSpecFlowResult Duplicate(Contracts.General.ProcessSpecFlow result, int companyId, int userId, string comment)
        {
            Dictionary<int, int> mapper = new Dictionary<int, int>();
            int currentStepId;

            List<Utilities.Contracts.LookUpValue> roles = Security.RoleMember.LookUp(companyId, Int32.MaxValue);

            IDbConnection currentConnection = DataFactory.Database.OpenConnection("Research");

            result.Id = DataAccess.General.ProcessSpecFlow.RetrieveLastKey(currentConnection) + 1;
            result.Alias += comment;
            result.Name += comment;
            result.Description += comment;

            result.CompanyId = companyId;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;

            if (DataAccess.General.ProcessSpecFlow.Create(result, currentConnection) > 0)
            {
                if (result.Roles?.Count > 0)
                {
                    foreach (Architect.Utilities.Contracts.LookUpValue flowRol in result.Roles)
                    {
                        DataAccess.General.ProcessSpecFlowRole.Create(new Contracts.General.ProcessSpecFlowRole()
                        {
                            Id = result.Id,
                            CompanyId = result.CompanyId,
                            RoleId = FindRole(flowRol.Code, flowRol.Description, roles),
                            UpdateUserCode = userId,
                            UpdateDate = DateTime.Now
                        }, currentConnection);
                    }
                }
                foreach (Contracts.General.ProcessSpecStep step in result.ProcessSpecSteps)
                {
                    currentStepId = DataAccess.General.ProcessSpecStep.RetrieveLastKey(currentConnection) + 1;
                    mapper.Add(step.Id, currentStepId);
                    step.Id = currentStepId;
                    step.FlowId = result.Id;
                    step.UpdateUserCode = userId;
                    step.UpdateDate = DateTime.Now;

                    if (DataAccess.General.ProcessSpecStep.Create(step) > 0)
                    {
                        foreach (Contracts.General.ProcessSpecStepRole stepRol in step.ProcessSpecStepRoles)
                        {
                            stepRol.Id = step.Id;
                            stepRol.RoleId = FindRole(stepRol.RoleId.ToString(), stepRol.RoleName, roles);
                            stepRol.UpdateUserCode = userId;
                            stepRol.UpdateDate = DateTime.Now;
                            DataAccess.General.ProcessSpecStepRole.Create(stepRol, currentConnection);
                        }

                        foreach (Contracts.General.ProcessSpecTask task in step.ProcessSpecTasks)
                        {
                            task.Id = DataAccess.General.ProcessSpecTask.RetrieveLastKey(currentConnection) + 1;
                            task.FlowId = result.Id;
                            task.StepId = step.Id;
                            task.UpdateUserCode = userId;
                            task.UpdateDate = DateTime.Now;
                            DataAccess.General.ProcessSpecTask.Create(task, currentConnection);
                        }
                    }
                }
                foreach (Contracts.General.ProcessSpecStep step in result.ProcessSpecSteps)
                {
                    foreach (Contracts.General.ProcessSpecTask task in step.ProcessSpecTasks)
                    {
                        if (task.Type == 10 && task.Action != "0" && mapper.ContainsKey(Convert.ToInt32(task.Action)))
                        {
                            task.Action = mapper[Convert.ToInt32(task.Action)].ToString();
                            DataAccess.General.ProcessSpecTask.Update(task, currentConnection);
                        }
                    }
                }
                foreach (Contracts.General.ProcessSpecLink link in result.ProcessSpecLinks)
                {
                    link.Id = DataAccess.General.ProcessSpecLink.RetrieveLastKey(currentConnection) + 1;
                    link.FlowId = result.Id;
                    link.UpdateUserCode = userId;
                    link.UpdateDate = DateTime.Now;
                    DataAccess.General.ProcessSpecLink.Create(link, currentConnection);
                }
            }

            currentConnection.Close();
            Architect.Utilities.Cache.RemoveStartWith("Process");
            Architect.Utilities.Cache.RemoveStartWith("SpecFlow");
            return new Contracts.General.ProcessSpecFlowResult()
            {
                ProcessSpecFlow = result,
                Errors = new List<Contracts.General.Error>()
            };
        }

        private static int FindRole(string roleId, string roleName, List<Utilities.Contracts.LookUpValue> roles)
        {
            int result = Convert.ToInt32(roleId);
            Utilities.Contracts.LookUpValue item = roles.Find(r => r.Description == roleName);
            if (item != null)
            {
                result = Convert.ToInt32(item.Code);
            }
            return result;
        }

        private static void SynchronizeRoles(int companyId, int userId, int id, List<Architect.Utilities.Contracts.LookUpValue> currentRoles)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecFlowRole> roles = Core.DataAccess.General.ProcessSpecFlowRole.RetrieveByStepId(id);
            if (roles.IsEmpty())
            {
                roles = new List<Architect.API.Core.Contracts.General.ProcessSpecFlowRole>();
            }
            if (currentRoles.IsNotEmpty())
            {
                //Agrega un nuevo registro o se cambia uno existente                
                Architect.API.Core.Contracts.General.ProcessSpecFlowRole toAdd = null;
                foreach (Architect.Utilities.Contracts.LookUpValue newItem in currentRoles)
                {
                    toAdd = roles.Find(r => r.RoleId.ToString() == newItem.Code);

                    if (toAdd.IsEmpty())
                    {
                        toAdd = new Architect.API.Core.Contracts.General.ProcessSpecFlowRole();
                        roles.Add(toAdd);
                        toAdd.Id = id;
                        toAdd.RoleId = Convert.ToInt32(newItem.Code);

                        toAdd.CompanyId = companyId;
                        toAdd.UpdateUserCode = userId;
                        toAdd.UpdateDate = DateTime.Now;

                        Core.DataAccess.General.ProcessSpecFlowRole.Create(toAdd);
                    }
                }
            }

            //Elimina los registros que no venga en la lista nueva
            if (roles?.Count > 0)
            {
                foreach (Architect.API.Core.Contracts.General.ProcessSpecFlowRole currentRole in roles)
                {
                    if (currentRoles.Find(r => r.Code == currentRole.RoleId.ToString()).IsEmpty())
                    {
                        Core.DataAccess.General.ProcessSpecFlowRole.DeleteWithRole(id, currentRole.RoleId, companyId);
                    }
                }
            }
        }

    }
}
