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
                foreach (Contracts.General.ProcessSpecStep step in result.ProcessSpecSteps)
                {
                    step.Id = DataAccess.General.ProcessSpecStep.RetrieveLastKey(currentConnection) + 1;
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
            return new Contracts.General.ProcessSpecFlowResult()
            {
                ProcessSpecFlow = result,
                Errors = new List<Contracts.General.Error>()
            };
        }
    }
}
