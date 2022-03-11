using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Plantillas de comunicación.
    /// </summary>
    public static partial class Template
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla Template.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de Template</param>
        /// <returns>Instancia de Template creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.TemplateResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.Template item)
        {
            if (item.Id.IsEmpty() || Architect.API.Core.DataAccess.General.Template.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla Template.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de Template</param>
        /// <returns>Instancia de Template creada.</returns>
        public static Architect.API.Core.Contracts.General.TemplateResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.Template item)
        {
            Architect.API.Core.Contracts.General.Template result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Template.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Core.DataAccess.General.Template.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.Template.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1205, result.Id, companyId, "Creación", string.Format("Se creó el plantilla '{0}'", result.Description), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.TemplateResult() { Template = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Template.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de Template.</returns>
        public static List<Architect.API.Core.Contracts.General.Template> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.Template> result = Architect.API.Core.DataAccess.General.Template.RetrieveAll(companyId, Architect.API.Core.DataAccess.General.Template.FilterBuilder(filter), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.Template item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla Template por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de Template</returns>
        public static Architect.API.Core.Contracts.General.Template RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.Template result = Architect.API.Core.DataAccess.General.Template.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla Template por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de Template</param>
        /// <returns>Instancia de Template actualizada.</returns>
        public static Architect.API.Core.Contracts.General.TemplateResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.Template item)
        {
            Architect.API.Core.Contracts.General.Template result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Template.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.Template.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1205, item.Id, companyId, "Modificación", string.Format("Se modificó el plantilla '{0}'", result.Description), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.TemplateResult() { Template = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla Template por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de Template eliminada.</returns>
        public static Architect.API.Core.Contracts.General.TemplateResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.Template result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Template.Validate(companyId, new Architect.API.Core.Contracts.General.Template() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.Template.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.Template.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(1205, id, companyId, "Eliminar", string.Format("Se eliminó el plantilla '{0}'", result.Description), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.TemplateResult() { Template = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Template que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.Template.Count(Architect.API.Core.DataAccess.General.Template.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla Template.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de Template</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.Template source, bool isnew, bool isdelete)
        {
            string group = "Template";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el identificación" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.Template.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificación no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.Template.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificación ya está registrada" });
            }
            if (!isdelete)
            {

                //Key:

                //Description:

                //EmailTo:

                //Subject:
                if (source.Subject.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Subject", Message = "Debe indicar el asunto" });
                }

                //Body:
                if (source.Body.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Body", Message = "Debe indicar el body" });
                }

                //MasterTemplateId:
                if (source.MasterTemplateId.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "MailTemplate", source.MasterTemplateId.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "MasterTemplateId", Message = "El valor indicado para el master template id no es valido" });
                }
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="item">Instancia de Template</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.Template item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.MasterTemplateId.IsNotEmpty())
                item.MasterTemplateIdDesc = Core.Business.Common.LkpDescription(companyId, "MailTemplate", item.MasterTemplateId.ToString());

        }

    }
}
