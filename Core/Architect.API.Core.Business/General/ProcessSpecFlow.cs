using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Especificación de un proceso.
    /// </summary>
    public static partial class ProcessSpecFlow
    {

        /// <summary>
        /// Duplica un proceso y todas las tablas relacionadas.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecFlow</returns>
        public static Contracts.General.ProcessSpecFlowResult DuplicateById(int companyId, int userId, int id)
        {
            Dictionary<int, int> mapper = new Dictionary<int, int>();
            int currentStepId;
            Contracts.General.ProcessSpecFlow result = DataAccess.General.Process.Specification.Retrieve(id, companyId);

            IDbConnection currentConnection = DataFactory.Database.OpenConnection("Research");

            result.Id = DataAccess.General.ProcessSpecFlow.RetrieveLastKey(currentConnection) + 1;
            result.Alias += "2";
            result.Name += " (copia)";
            result.Description += " (copia)";

            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;

            if (DataAccess.General.ProcessSpecFlow.Create(result, currentConnection) > 0)
            {
                if (result.Roles?.Count > 0)
                {
                    foreach (Utilities.Contracts.LookUpValue flowRol in result.Roles)
                    {
                        DataAccess.General.ProcessSpecFlowRole.Create(new Contracts.General.ProcessSpecFlowRole()
                        {
                            Id = result.Id,
                            CompanyId = result.CompanyId,
                            RoleId = Convert.ToInt32(flowRol.Code),
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
                        if (task.Type == 10)
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
            Utilities.Cache.RemoveStartWith("Process");
            Utilities.Cache.RemoveStartWith("SpecFlow");
            return new Contracts.General.ProcessSpecFlowResult()
            {
                ProcessSpecFlow = result,
                Errors = new List<Contracts.General.Error>()
            };
        }

        private static void SynchronizeRoles(int companyId, int userId, int id, List<Utilities.Contracts.LookUpValue> currentRoles)
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
                foreach (Utilities.Contracts.LookUpValue newItem in currentRoles)
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
