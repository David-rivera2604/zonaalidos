using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Tron.Business.Backoffice
{
    /// <summary>
    /// Clase de negocio para el manejo de presupuestos
    /// </summary>
    public class Presupuestos
    {
        /// <summary>
        /// Elimina un presupuesto por medio de su identificador único.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del presupuesto.</param>
        /// <returns>Resultado de la operación de eliminación.</returns>
        public static Contracts.Presupuesto.PresupuestoResult Delete(int companyId, int userId, string id)
        {
            Contracts.Presupuesto.PresupuestoResult result = new Contracts.Presupuesto.PresupuestoResult();
            List<Core.Contracts.General.Error> errors = new List<Core.Contracts.General.Error>();

            try
            {
                // Validaciones básicas
                if (id.IsEmpty())
                {
                    errors.Add(new Core.Contracts.General.Error()
                    {
                        Group = "Presupuestos",
                        Key = "Id",
                        Message = "Debe indicar el identificador del presupuesto"
                    });
                }
                else
                {
                    result.Success = Architect.API.Tron.DataAccess.PolicyProposal.Delete(id, companyId) > 0;

                    if (result.Success)
                    {
                        // Crear registro de cambio
                        Core.Business.General.ChangeSet.Create(3000, Convert.ToInt64(id), companyId, "Eliminar", string.Format("Se eliminó el presupuesto '{0}'", id), userId, null);
                        result.Message = $"Presupuesto {id} eliminado correctamente";
                    }                
                }
            }
            catch (Exception ex)
            {
                errors.Add(new Core.Contracts.General.Error()
                {
                    Group = "Presupuestos",
                    Key = "Delete",
                    Message = ex.Message
                });
                Utilities.Log.ErrorLog(ex, "Presupuestos.Delete");
            }

            result.Errors = errors;
            return result;
        }
    }
}