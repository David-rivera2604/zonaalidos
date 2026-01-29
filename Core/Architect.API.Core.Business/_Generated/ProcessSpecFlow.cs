using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Especificación de un proceso.
    /// </summary>
    public static partial class ProcessSpecFlow
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecFlow</param>
        /// <returns>Instancia de ProcessSpecFlow creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecFlowResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecFlow item)
        {
            if (item.Id.IsEmpty() || Architect.API.Core.DataAccess.General.ProcessSpecFlow.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecFlow</param>
        /// <returns>Instancia de ProcessSpecFlow creada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecFlowResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecFlow item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecFlow result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecFlow.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Core.DataAccess.General.ProcessSpecFlow.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecFlow.Create(result) > 0)
                {
                    SynchronizeRoles(companyId, userId, result.Id, result.Roles);

                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1300, result.Id, companyId, "Creación", string.Format("Se creó el process spec flow '{0}'", result.Name), userId, result);

                    Architect.Utilities.Cache.RemoveStartWith("Process");
                    Architect.Utilities.Cache.RemoveStartWith("SpecFlow");

                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecFlowResult() { ProcessSpecFlow = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de ProcessSpecFlow.</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecFlow> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecFlow> result = Architect.API.Core.DataAccess.General.ProcessSpecFlow.RetrieveAll(companyId, Architect.API.Core.DataAccess.General.ProcessSpecFlow.FilterBuilderEx(filter, false), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.ProcessSpecFlow item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecFlow</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecFlow RetrieveById(int companyId, int id)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Research");
            Architect.API.Core.Contracts.General.ProcessSpecFlow result = Architect.API.Core.DataAccess.General.ProcessSpecFlow.Retrieve(id, companyId, currentConnection);

            if (result.IsNotEmpty())
            {
                List<Architect.API.Core.Contracts.General.ProcessSpecFlowRole> internalRoles = Core.DataAccess.General.ProcessSpecFlowRole.RetrieveByStepId(id, currentConnection);
                if (internalRoles.Count > 0)
                {
                    result.Roles = new List<Architect.Utilities.Contracts.LookUpValue>();
                    foreach (Architect.API.Core.Contracts.General.ProcessSpecFlowRole item in internalRoles)
                    {
                        result.Roles.Add(new Architect.Utilities.Contracts.LookUpValue() { Code = item.RoleId.ToString(), Description = item.RoleName });
                    }
                }
            }
            currentConnection.Close();

            MapLookups(companyId, result);


            result.ReferenceCondition1 = ConditionResolve(result.ReferenceCondition1, result);
            result.ReferenceCondition2 = ConditionResolve(result.ReferenceCondition2, result);
            result.ReferenceCondition3 = ConditionResolve(result.ReferenceCondition3, result);
            result.ReferenceCondition4 = ConditionResolve(result.ReferenceCondition4, result);
            result.ReferenceCondition5 = ConditionResolve(result.ReferenceCondition5, result);
            result.ReferenceCondition6 = ConditionResolve(result.ReferenceCondition6, result);
            result.ReferenceCondition7 = ConditionResolve(result.ReferenceCondition7, result);
            result.ReferenceCondition8 = ConditionResolve(result.ReferenceCondition8, result);
            result.ReferenceCondition9 = ConditionResolve(result.ReferenceCondition9, result);
            result.ReferenceCondition10 = ConditionResolve(result.ReferenceCondition10, result);


            return result;
        }


        public static string ConditionResolve(string condition, Architect.API.Core.Contracts.General.ProcessSpecFlow processSpecFlow)
        {
            string result = condition;

            result = result.Replace("{" + processSpecFlow.ReferenceCaption1 + "}", "data.Reference1");
            result = result.Replace("{" + processSpecFlow.ReferenceCaption2 + "}", "data.Reference2");
            result = result.Replace("{" + processSpecFlow.ReferenceCaption3 + "}", "data.Reference3");
            result = result.Replace("{" + processSpecFlow.ReferenceCaption4 + "}", "data.Reference4");
            result = result.Replace("{" + processSpecFlow.ReferenceCaption5 + "}", "data.Reference5");
            result = result.Replace("{" + processSpecFlow.ReferenceCaption6 + "}", "data.Reference6");
            result = result.Replace("{" + processSpecFlow.ReferenceCaption7 + "}", "data.Reference7");
            result = result.Replace("{" + processSpecFlow.ReferenceCaption8 + "}", "data.Reference8");
            result = result.Replace("{" + processSpecFlow.ReferenceCaption9 + "}", "data.Reference9");
            result = result.Replace("{" + processSpecFlow.ReferenceCaption10 + "}", "data.Reference10");

            result = result.Replace("{Prioridad}", "data.PriorityDesc");
            result = result.Replace("{prioridad}", "data.PriorityDesc");
            result = result.Replace("{Roles incluye}", "data.roles.includes");
            result = result.Replace("{Roles no incluye}", "!data.roles.includes");
            result = result.Replace(" igual a ", " == ");
            result = result.Replace(" diferente de ", " != ");

            return result;
        }


        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de ProcessSpecFlow</param>
        /// <returns>Instancia de ProcessSpecFlow actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecFlowResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.ProcessSpecFlow item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecFlow result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecFlow.Validate(companyId, item, false, false);
            List<Contracts.General.Error> warnings = null;

            if (errors.Count == 0)
            {
                warnings = ProcessSpecFlow.ValidateEx(companyId, item);

                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecFlow.Update(result) > 0)
                {
                    SynchronizeRoles(companyId, userId, result.Id, result.Roles);

                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1300, item.Id, companyId, "Modificación", string.Format("Se modificó el process spec flow '{0}'", result.Name), userId, result);
                    Architect.Utilities.Cache.RemoveStartWith("Process");
                    Architect.Utilities.Cache.RemoveStartWith("SpecFlow");
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecFlowResult() { ProcessSpecFlow = result, Errors = errors, Warnings = warnings };
        }

        /// <summary>
        /// Elimina un registro en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecFlow eliminada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecFlowResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessSpecFlow result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecFlow.Validate(companyId, new Architect.API.Core.Contracts.General.ProcessSpecFlow() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.ProcessSpecFlow.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecFlow.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(1300, id, companyId, "Eliminar", string.Format("Se eliminó el process spec flow '{0}'", result.Name), userId, result);
                    Architect.Utilities.Cache.RemoveStartWith("Process");
                    Architect.Utilities.Cache.RemoveStartWith("SpecFlow");
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecFlowResult() { ProcessSpecFlow = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecFlow que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.ProcessSpecFlow.Count(Architect.API.Core.DataAccess.General.ProcessSpecFlow.FilterBuilderEx(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de ProcessSpecFlow</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.ProcessSpecFlow source, bool isnew, bool isdelete)
        {
            string group = "ProcessSpecFlow";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el proceso" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecFlow.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La proceso no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecFlow.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La proceso ya está registrada" });
            }
            if (!isdelete)
            {

                //Name:
                if (source.Name.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Name", Message = "Debe indicar el nombre" });
                }

                //Description:

                //Alias:

                //MailServer:
                if (source.MailServer.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MailServer", Message = "Debe indicar el servidor de correo" });
                }
                if (source.MailServer.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "MailServer", source.MailServer.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MailServer", Message = "El valor indicado para el servidor de correo no es valido" });
                }

                //ReferenceCaption1:

                //ReferenceLookupList1:

                //ReferenceCaption2:

                //ReferenceLookupList2:

                //ReferenceCaption3:

                //ReferenceLookupList3:

                //ReferenceCaption4:

                //ReferenceLookupList4:

                //ReferenceCaption5:

                //ReferenceLookupList5:

                //SLA:

                //Status:
                if (source.Status.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Status", Message = "Debe indicar el estado" });
                }
                if (source.Status.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "EstadoRegistro", source.Status.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Status", Message = "El valor indicado para el estado no es valido" });
                }
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="item">Instancia de ProcessSpecFlow</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.ProcessSpecFlow item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.MailServer.IsNotEmpty())
                item.MailServerDesc = Core.Business.Common.LkpDescription(companyId, "MailServer", item.MailServer.ToString());
            if (item.Status.IsNotEmpty())
                item.StatusDesc = Core.Business.Common.LkpDescription(companyId, "EstadoRegistro", item.Status.ToString());

        }


        public static List<Architect.Utilities.Contracts.LookUpValue> RetrieveReferencesById(int companyId, int id)
        {
            List<Architect.Utilities.Contracts.LookUpValue> fields = new List<Architect.Utilities.Contracts.LookUpValue>();
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Research");
            Architect.API.Core.Contracts.General.ProcessSpecFlow process = Architect.API.Core.DataAccess.General.ProcessSpecFlow.Retrieve(id, companyId, currentConnection);

            if (process.IsNotEmpty())
            {
                if (process.ReferenceCaption1.IsNotEmpty())
                {
                    fields.Add(new Architect.Utilities.Contracts.LookUpValue() { Code = "Reference1", Description = process.ReferenceCaption1 });
                }
                if (process.ReferenceCaption2.IsNotEmpty())
                {
                    fields.Add(new Architect.Utilities.Contracts.LookUpValue() { Code = "Reference2", Description = process.ReferenceCaption2 });
                }
                if (process.ReferenceCaption3.IsNotEmpty())
                {
                    fields.Add(new Architect.Utilities.Contracts.LookUpValue() { Code = "Reference3", Description = process.ReferenceCaption3 });
                }
                if (process.ReferenceCaption4.IsNotEmpty())
                {
                    fields.Add(new Architect.Utilities.Contracts.LookUpValue() { Code = "Reference4", Description = process.ReferenceCaption4 });
                }
                if (process.ReferenceCaption5.IsNotEmpty())
                {
                    fields.Add(new Architect.Utilities.Contracts.LookUpValue() { Code = "Reference5", Description = process.ReferenceCaption5 });
                }
                if (process.ReferenceCaption6.IsNotEmpty())
                {
                    fields.Add(new Architect.Utilities.Contracts.LookUpValue() { Code = "Reference6", Description = process.ReferenceCaption6 });
                }
                if (process.ReferenceCaption7.IsNotEmpty())
                {
                    fields.Add(new Architect.Utilities.Contracts.LookUpValue() { Code = "Reference7", Description = process.ReferenceCaption7 });
                }
                if (process.ReferenceCaption8.IsNotEmpty())
                {
                    fields.Add(new Architect.Utilities.Contracts.LookUpValue() { Code = "Reference8", Description = process.ReferenceCaption8 });
                }
                if (process.ReferenceCaption9.IsNotEmpty())
                {
                    fields.Add(new Architect.Utilities.Contracts.LookUpValue() { Code = "Reference9", Description = process.ReferenceCaption9 });
                }
                if (process.ReferenceCaption10.IsNotEmpty())
                {
                    fields.Add(new Architect.Utilities.Contracts.LookUpValue() { Code = "Reference10", Description = process.ReferenceCaption10 });
                }
            }
            currentConnection.Close();

            return fields;
        }

    }
}
