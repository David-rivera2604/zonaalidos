using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// Visualizaciones de datos en forma de widget, reportes, dashboard.
    /// </summary>
    public static partial class Visualizations
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla Visualizations.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de Visualizations</param>
        /// <returns>Instancia de Visualizations creada o actualizada.</returns>
        public static Architect.API.Core.Contracts.General.VisualizationsResult CreateOrUpdate(int companyId, int userId, Architect.API.Core.Contracts.General.Visualizations item)
        {
            if (item.Id.IsEmpty() || Architect.API.Core.DataAccess.General.Visualizations.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla Visualizations.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de Visualizations</param>
        /// <returns>Instancia de Visualizations creada.</returns>
        public static Architect.API.Core.Contracts.General.VisualizationsResult Create(int companyId, int userId, Architect.API.Core.Contracts.General.Visualizations item)
        {
            Architect.API.Core.Contracts.General.Visualizations result = item;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Visualizations.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Core.DataAccess.General.Visualizations.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.Visualizations.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1207, result.Id, companyId, "Creación", string.Format("Se creó el visualizations '{0}'", result.Caption), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.VisualizationsResult() { Visualizations = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Visualizations.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de Visualizations.</returns>
        public static List<Architect.API.Core.Contracts.General.Visualizations> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Core.Contracts.General.Visualizations> result = Architect.API.Core.DataAccess.General.Visualizations.RetrieveAll(companyId, Architect.API.Core.DataAccess.General.Visualizations.FilterBuilder(filter), beginIndex, endIndex);

            foreach (Architect.API.Core.Contracts.General.Visualizations item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla Visualizations por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de Visualizations</returns>
        public static Architect.API.Core.Contracts.General.Visualizations RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.General.Visualizations result = Architect.API.Core.DataAccess.General.Visualizations.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla Visualizations por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de Visualizations</param>
        /// <returns>Instancia de Visualizations actualizada.</returns>
        public static Architect.API.Core.Contracts.General.VisualizationsResult Update(int companyId, int userId, int id, Architect.API.Core.Contracts.General.Visualizations item)
        {
            Architect.API.Core.Contracts.General.Visualizations result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Visualizations.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Core.DataAccess.General.Visualizations.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(1207, item.Id, companyId, "Modificación", string.Format("Se modificó el visualizations '{0}'", result.Caption), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.VisualizationsResult() { Visualizations = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla Visualizations por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de Visualizations eliminada.</returns>
        public static Architect.API.Core.Contracts.General.VisualizationsResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.Visualizations result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.Visualizations.Validate(companyId, new Architect.API.Core.Contracts.General.Visualizations() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.Visualizations.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Core.DataAccess.General.Visualizations.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(1207, id, companyId, "Eliminar", string.Format("Se eliminó el visualizations '{0}'", result.Caption), userId, result);
                }
            }
            return new Architect.API.Core.Contracts.General.VisualizationsResult() { Visualizations = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Visualizations que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Core.DataAccess.General.Visualizations.Count(Architect.API.Core.DataAccess.General.Visualizations.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla Visualizations.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de Visualizations</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Core.Contracts.General.Visualizations source, bool isnew, bool isdelete)
        {
            string group = "Visualizations";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el identificación" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.Visualizations.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificación no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Core.DataAccess.General.Visualizations.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificación ya está registrada" });
            }

            //Sequence:
            if ((!isnew || isdelete) && source.Sequence.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Sequence", Message = "Debe indicar el secuencia" });
            }
            if ((!isnew || isdelete) && source.Sequence.IsNotEmpty() && Architect.API.Core.DataAccess.General.Visualizations.Count(source.Sequence, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Sequence", Message = "La secuencia no está registrada" });
            }
            if (isnew && source.Sequence.IsNotEmpty() && Architect.API.Core.DataAccess.General.Visualizations.Count(source.Sequence, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Sequence", Message = "La secuencia ya está registrada" });
            }
            if (!isdelete)
            {

                //EntityType:
                if (source.EntityType.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "EntityType", source.EntityType.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "EntityType", Message = "El valor indicado para el tipo de entidad no es valido" });
                }

                //Type:
                if (source.Type.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "VisualizationType", source.Type.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Type", Message = "El valor indicado para el type no es valido" });
                }

                //Caption:

                //Description:

                //StatementType:
                if (source.StatementType.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "StatementType", source.StatementType.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "StatementType", Message = "El valor indicado para el tipo de comando no es valido" });
                }

                //Statement:

                //Specification:

                //Icon:

                //IconClass:

                //ValueFormat:

                //ConnectionName:

                //RecordStatus:
                if (source.RecordStatus.IsEmpty())
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "RecordStatus", Message = "Debe indicar el estado del registro" });
                }
                if (source.RecordStatus.IsNotEmpty() && !Core.Business.Common.LkpExist(companyId, "EstadoRegistro", source.RecordStatus.ToString()))
                {
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = "RecordStatus", Message = "El valor indicado para el estado del registro no es valido" });
                }
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="item">Instancia de Visualizations</param>
        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.Visualizations item)
        {
            if (item.IsEmpty())
            {
                return;
            }
            if (item.EntityType.IsNotEmpty())
                item.EntityTypeDesc = Core.Business.Common.LkpDescription(companyId, "EntityType", item.EntityType.ToString());
            if (item.Type.IsNotEmpty())
                item.TypeDesc = Core.Business.Common.LkpDescription(companyId, "VisualizationType", item.Type.ToString());
            if (item.StatementType.IsNotEmpty())
                item.StatementTypeDesc = Core.Business.Common.LkpDescription(companyId, "StatementType", item.StatementType.ToString());
            if (item.RecordStatus.IsNotEmpty())
                item.RecordStatusDesc = Core.Business.Common.LkpDescription(companyId, "EstadoRegistro", item.RecordStatus.ToString());

        }

    }
}
