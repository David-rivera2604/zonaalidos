using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Pasos o estados de un proceso.
    /// </summary>
    public static partial class ProcessSpecStep
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla ProcessSpecStep.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecStep</param>
        /// <returns>Instancia de ProcessSpecStep creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStepResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecStep item)
        {
            if (item.Id.IsEmpty() || Architect.API.Core.DataAccess.General.ProcessSpecStep.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecStep.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecStep</param>
        /// <returns>Instancia de ProcessSpecStep creada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStepResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecStep item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecStep result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecStep.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Core.DataAccess.General.ProcessSpecStep.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecStep.Create(result) > 0)
                {
                    SynchronizeRoles(companyId, userId, result.Id, result.Roles);
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1301, result.Id, companyId, "Creación", string.Format("Se creó el process spec step '{0}'", result.Name), userId, result);
                    Utilities.Cache.RemoveStartWith("Steps");
                    Utilities.Cache.RemoveStartWith("SpecFlow");
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecStepResult() { ProcessSpecStep = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecStep.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de ProcessSpecStep.</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecStep> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecStep> result = Architect.API.Core.DataAccess.General.ProcessSpecStep.RetrieveAll(companyId, Architect.API.Core.DataAccess.General.ProcessSpecStep.FilterBuilderEx(filter), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.ProcessSpecStep item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla ProcessSpecStep por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecStep</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStep RetrieveById(int companyId, int id)
        {
            IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Research");

            Architect.API.Core.Contracts.General.ProcessSpecStep result = Architect.API.Core.DataAccess.General.ProcessSpecStep.RetrieveFull(id, companyId, currentConnection);

            if (result.IsNotEmpty())
            {
                result.ProcessSpecStepRoles = Core.DataAccess.General.ProcessSpecStepRole.RetrieveByStepId(id, currentConnection);
                if (result.ProcessSpecStepRoles.Count > 0)
                {
                    result.Roles = new List<Utilities.Contracts.LookUpValue>();
                    foreach (Architect.API.Core.Contracts.General.ProcessSpecStepRole item in result.ProcessSpecStepRoles)
                    {
                        result.Roles.Add(new Utilities.Contracts.LookUpValue() { Code = item.RoleId.ToString(), Description = item.RoleName });
                    }
                }

            }
            currentConnection.Close();

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecStep por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de ProcessSpecStep</param>
        /// <returns>Instancia de ProcessSpecStep actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStepResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.ProcessSpecStep item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecStep result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecStep.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecStep.Update(result) > 0)
                {
                    SynchronizeRoles(companyId, userId, result.Id, result.Roles);
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1301, item.Id, companyId, "Modificación", string.Format("Se modificó el process spec step '{0}'", result.Name), userId, result);
                    Utilities.Cache.RemoveStartWith("Steps");
                    Utilities.Cache.RemoveStartWith("SpecFlow");
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecStepResult() { ProcessSpecStep = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla ProcessSpecStep por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecStep eliminada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecStepResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessSpecStep result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecStep.Validate(companyId, new Architect.API.Core.Contracts.General.ProcessSpecStep() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.ProcessSpecStep.Retrieve(id, companyId);

                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecStep.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(1301, id, companyId, "Eliminar", string.Format("Se eliminó el process spec step '{0}'", result.Name), userId, result);
                    Utilities.Cache.RemoveStartWith("Steps");
                    Utilities.Cache.RemoveStartWith("SpecFlow");
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecStepResult() { ProcessSpecStep = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecStep que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.ProcessSpecStep.Count(Architect.API.Core.DataAccess.General.ProcessSpecStep.FilterBuilderEx(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla ProcessSpecStep.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="source">Instancia de ProcessSpecStep</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.ProcessSpecStep source, bool isnew, bool isdelete)
        {
            string group = "ProcessSpecStep";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el paso" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecStep.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La paso no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecStep.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La paso ya está registrada" });
            }
            if (!isdelete)
            {

                //FlowId:
                if (source.FlowId.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FlowId", Message = "Debe indicar el proceso" });
                }
                if (source.FlowId.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "Process", source.FlowId.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "FlowId", Message = "El valor indicado para el proceso no es valido" });
                }

                //Name:
                if (source.Name.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Name", Message = "Debe indicar el nombre" });
                }

                //Description:

                //SLATimeOut:

                //StepOrder:
                if (source.StepOrder.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "StepOrder", Message = "Debe indicar el orden" });
                }

                //ProcessStatus:
                if (source.ProcessStatus.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "ProcessStatus", source.ProcessStatus.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "ProcessStatus", Message = "El valor indicado para el estado no es valido" });
                }

                //ProcessLabel:

                //EnableComment:

                //ProgressMode:
                if (source.ProgressMode.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "ProgressMode", Message = "Debe indicar el tipo" });
                }
                if (source.ProgressMode.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "ProgressMode", source.ProgressMode.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "ProgressMode", Message = "El valor indicado para el tipo no es valido" });
                }

                //SLA:

                //MailServer:
                if (source.MailServer.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MailServer", Message = "Debe indicar el servidor de correo" });
                }
                if (source.MailServer.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "MailServer", source.MailServer.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MailServer", Message = "El valor indicado para el servidor de correo no es valido" });
                }

                //MailToContact:
                if (source.MailToContact.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "MailSendOptions", source.MailToContact.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MailToContact", Message = "El valor indicado para el contacto no es valido" });
                }

                //MailToContactCustom:

                //MailToContactTmpl:
                if (source.MailToContactTmpl.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "MailTemplate", source.MailToContactTmpl.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MailToContactTmpl", Message = "El valor indicado para el mai tmpll to contact no es valido" });
                }

                //MailToStepResponsible:
                if (source.MailToStepResponsible.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "MailSendOptions", source.MailToStepResponsible.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MailToStepResponsible", Message = "El valor indicado para el responsables no es valido" });
                }

                //MailToStepResponsibleCustom:

                //MailToStepResponsibleTmpl:
                if (source.MailToStepResponsibleTmpl.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "MailTemplate", source.MailToStepResponsibleTmpl.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MailToStepResponsibleTmpl", Message = "El valor indicado para el mail to step responsible tmpl no es valido" });
                }

                //MailForSLAExpiration:
                if (source.MailForSLAExpiration.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "MailSendOptions", source.MailForSLAExpiration.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MailForSLAExpiration", Message = "El valor indicado para el mail for sla expiration no es valido" });
                }

                //MailForSLAExpirationCustom:

                //MailForSLAExpirationTmpl:
                if (source.MailForSLAExpirationTmpl.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "MailTemplate", source.MailForSLAExpirationTmpl.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MailForSLAExpirationTmpl", Message = "El valor indicado para el mail for slae xpiration tmpl no es valido" });
                }

                //PreScript:

                //PostScript:
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="item">Instancia de ProcessSpecStep</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.ProcessSpecStep item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.FlowId.IsNotEmpty())
                item.FlowIdDesc = Core.Business.Common.LkpDescription(companyId, "Process", item.FlowId.ToString());
            if (item.ProcessStatus.IsNotEmpty())
                item.ProcessStatusDesc = Core.Business.Common.LkpDescription(companyId, "ProcessStatus", item.ProcessStatus.ToString());
            if (item.ProgressMode.IsNotEmpty())
                item.ProgressModeDesc = Core.Business.Common.LkpDescription(companyId, "ProgressMode", item.ProgressMode.ToString());
            if (item.MailServer.IsNotEmpty())
                item.MailServerDesc = Core.Business.Common.LkpDescription(companyId, "MailServer", item.MailServer.ToString());
            if (item.MailToContact.IsNotEmpty())
                item.MailToContactDesc = Core.Business.Common.LkpDescription(companyId, "MailSendOptions", item.MailToContact.ToString());
            if (item.MailToContactTmpl.IsNotEmpty())
                item.MailToContactTmplDesc = Core.Business.Common.LkpDescription(companyId, "MailTemplate", item.MailToContactTmpl.ToString());
            if (item.MailToStepResponsible.IsNotEmpty())
                item.MailToStepResponsibleDesc = Core.Business.Common.LkpDescription(companyId, "MailSendOptions", item.MailToStepResponsible.ToString());
            if (item.MailToStepResponsibleTmpl.IsNotEmpty())
                item.MailToStepResponsibleTmplDesc = Core.Business.Common.LkpDescription(companyId, "MailTemplate", item.MailToStepResponsibleTmpl.ToString());
            if (item.MailForSLAExpiration.IsNotEmpty())
                item.MailForSLAExpirationDesc = Core.Business.Common.LkpDescription(companyId, "MailSendOptions", item.MailForSLAExpiration.ToString());
            if (item.MailForSLAExpirationTmpl.IsNotEmpty())
                item.MailForSLAExpirationTmplDesc = Core.Business.Common.LkpDescription(companyId, "MailTemplate", item.MailForSLAExpirationTmpl.ToString());

        }

        private static void SynchronizeRoles(int companyId, int userId, int id, List<Utilities.Contracts.LookUpValue> currentRoles)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecStepRole> roles = Core.DataAccess.General.ProcessSpecStepRole.RetrieveByStepId(id);
            if (roles.IsEmpty())
            {
                roles = new List<Architect.API.Core.Contracts.General.ProcessSpecStepRole>();
            }
            if (currentRoles.IsNotEmpty())
            {
                //Agrega un nuevo registro o se cambia uno existente                
                Architect.API.Core.Contracts.General.ProcessSpecStepRole toAdd = null;
                foreach (Utilities.Contracts.LookUpValue newItem in currentRoles)
                {
                    toAdd = roles.Find(r => r.RoleId.ToString() == newItem.Code);

                    if (toAdd.IsEmpty())
                    {
                        toAdd = new Architect.API.Core.Contracts.General.ProcessSpecStepRole();
                        roles.Add(toAdd);
                        toAdd.Id = id;
                        toAdd.RoleId = Convert.ToInt32(newItem.Code);

                        toAdd.CompanyId = companyId;
                        toAdd.UpdateUserCode = userId;
                        toAdd.UpdateDate = DateTime.Now;

                        Core.DataAccess.General.ProcessSpecStepRole.Create(toAdd);
                    }
                }
            }

            //Elimina los registros que no venga en la lista nueva
            if (roles?.Count > 0)
            {
                foreach (Architect.API.Core.Contracts.General.ProcessSpecStepRole currentRole in roles)
                {
                    if (currentRoles.Find(r => r.Code == currentRole.RoleId.ToString()).IsEmpty())
                    {
                        Core.DataAccess.General.ProcessSpecStepRole.DeleteWithRole(id, currentRole.RoleId,  companyId);
                    }
                }
            }
        }

    }
}
