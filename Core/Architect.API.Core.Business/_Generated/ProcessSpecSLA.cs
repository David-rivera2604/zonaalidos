using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// ProcessSpecSLA
    /// </summary>
    public static partial class ProcessSpecSLA
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla ProcessSpecSLA.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecSLA</param>
        /// <returns>Instancia de ProcessSpecSLA creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecSLAResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecSLA item)
        {
            if (item.Id.IsEmpty() || Architect.API.Core.DataAccess.General.ProcessSpecSLA.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecSLA.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de ProcessSpecSLA</param>
        /// <returns>Instancia de ProcessSpecSLA creada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecSLAResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessSpecSLA item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecSLA result = item;
            List<Core.Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecSLA.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Core.DataAccess.General.ProcessSpecSLA.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecSLA.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(0000, result.Id, companyId, "Creación", string.Format("Se creó el processspecsla '{0}'", result.Name), userId, result);

                    ProcessSpecSLALevel.Create(companyId, userId, result.Id, item.Levels);
                    Architect.Utilities.Cache.RemoveStartWith("SLA");
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecSLAResult() { ProcessSpecSLA = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecSLA.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de ProcessSpecSLA.</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessSpecSLA> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.ProcessSpecSLA> result = Architect.API.Core.DataAccess.General.ProcessSpecSLA.RetrieveAll(companyId, Architect.API.Core.DataAccess.General.ProcessSpecSLA.FilterBuilder(filter, false), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.ProcessSpecSLA item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla ProcessSpecSLA por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecSLA</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecSLA RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessSpecSLA result = Architect.API.Core.DataAccess.General.ProcessSpecSLA.Retrieve(id, companyId);

            MapLookups(companyId, result);
            if (result != null)
                result.Levels = ProcessSpecSLALevel.Retrieve(companyId, id);
            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecSLA por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de ProcessSpecSLA</param>
        /// <returns>Instancia de ProcessSpecSLA actualizada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecSLAResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.ProcessSpecSLA item)
        {
            Architect.API.Core.Contracts.General.ProcessSpecSLA result = null;
            List<Core.Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecSLA.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.ProcessSpecSLA.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(0000, item.Id, companyId, "Modificación", string.Format("Se modificó el processspecsla '{0}'", result.Name), userId, result);

                    ProcessSpecSLALevel.Update(companyId, userId, result.Id, item.Levels);
                    Architect.Utilities.Cache.RemoveStartWith("SLA");
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecSLAResult() { ProcessSpecSLA = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla ProcessSpecSLA por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de ProcessSpecSLA eliminada.</returns>
        public static Architect.API.Core.Contracts.General.ProcessSpecSLAResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessSpecSLA result = null;
            List<Core.Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessSpecSLA.Validate(companyId, new Architect.API.Core.Contracts.General.ProcessSpecSLA() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                ProcessSpecSLALevel.Delete(companyId, id);
                Architect.Utilities.Cache.RemoveStartWith("SLA");

                result = Architect.API.Core.DataAccess.General.ProcessSpecSLA.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecSLA.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(0000, id, companyId, "Eliminar", string.Format("Se eliminó el processspecsla '{0}'", result.Name), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessSpecSLAResult() { ProcessSpecSLA = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecSLA que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.ProcessSpecSLA.Count(Architect.API.Core.DataAccess.General.ProcessSpecSLA.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla ProcessSpecSLA.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de ProcessSpecSLA</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.ProcessSpecSLA source, bool isnew, bool isdelete)
        {
            string group = "ProcessSpecSLA";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el proceso" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecSLA.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La proceso no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.ProcessSpecSLA.Count(source.Id, companyId) > 0)
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
        /// <param name="item">Instancia de ProcessSpecSLA</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.ProcessSpecSLA item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.Status.IsNotEmpty())
                item.StatusDesc = Core.Business.Common.LkpDescription(companyId, "EstadoRegistro", item.Status.ToString());

        }



        /// <summary>
        /// Validaciones para los campos de la tabla ProcessSpecStep.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de ProcessSpecStep</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate22(int companyId, Architect.API.Core.Contracts.General.ProcessSpecSLALevel source, bool isnew, bool isdelete)
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



                //Description:

                //SLATimeOut:



                //SLA:



                //MailToStepResponsibleCustom:


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
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="item">Instancia de ProcessSpecStep</param>
        private static void MapLookups2(int companyId, Architect.API.Core.Contracts.General.ProcessSpecSLALevel item)
        {
            if (item.IsEmpty())
            {
                return;
            }

            if (item.MailForSLAExpiration.IsNotEmpty())
                item.MailForSLAExpirationDesc = Core.Business.Common.LkpDescription(companyId, "MailSendOptions", item.MailForSLAExpiration.ToString());
            if (item.MailForSLAExpirationTmpl.IsNotEmpty())
                item.MailForSLAExpirationTmplDesc = Core.Business.Common.LkpDescription(companyId, "MailTemplate", item.MailForSLAExpirationTmpl.ToString());

        }

    }
}
