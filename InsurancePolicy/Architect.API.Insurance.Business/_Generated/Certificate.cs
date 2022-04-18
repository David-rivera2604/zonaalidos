using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Insurance.Business.ManualPolicies
{
    /// <summary>
    /// .
    /// </summary>
    public static partial class Certificate
    {

        /// <summary>
        /// Crea registro o actualiza un registro en la tabla Certificate.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de Certificate</param>
        /// <returns>Instancia de Certificate creada o actualizada.</returns>
        public static Architect.API.Insurance.Contracts.ManualPolicies.CertificateResult CreateOrUpdate(int companyId, int userId, Architect.API.Insurance.Contracts.ManualPolicies.Certificate item)
        {
            if (item.Id.IsEmpty() || Architect.API.Insurance.DataAccess.ManualPolicies.Certificate.Count(item.Id, companyId) == 0)
            {
                return Create(companyId, userId, item);
            }
            else
            {
                return Update(companyId, userId, item.Id, item);
            }
        }

        /// <summary>
        /// Crea un registro en la tabla Certificate.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="item">Instancia de Certificate</param>
        /// <returns>Instancia de Certificate creada.</returns>
        public static Architect.API.Insurance.Contracts.ManualPolicies.CertificateResult Create(int companyId, int userId, Architect.API.Insurance.Contracts.ManualPolicies.Certificate item)
        {
            Architect.API.Insurance.Contracts.ManualPolicies.Certificate result = item;
            List<Core.Contracts.General.Error> errors = Architect.API.Insurance.Business.ManualPolicies.Certificate.Validate(companyId, item, true, false);

            if (errors.Count == 0)
            {
                if (result.Id.IsEmpty())
                {
                    result.Id = Architect.API.Insurance.DataAccess.ManualPolicies.Certificate.RetrieveLastKey() + 1;
                }
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Insurance.DataAccess.ManualPolicies.Certificate.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(0000, result.Id, companyId, "Creación", string.Format("Se creó un registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Insurance.Contracts.ManualPolicies.CertificateResult() { Certificate = result, Errors = errors };
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Certificate.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <returns>Lista de instancias de Certificate.</returns>
        public static List<Architect.API.Insurance.Contracts.ManualPolicies.Certificate> Retrieve(int companyId, string filter, int beginIndex, int endIndex)
        {
            List<Architect.API.Insurance.Contracts.ManualPolicies.Certificate> result = Architect.API.Insurance.DataAccess.ManualPolicies.Certificate.RetrieveAll(companyId, Architect.API.Insurance.DataAccess.ManualPolicies.Certificate.FilterBuilder(filter, false), beginIndex, endIndex);

            foreach (Architect.API.Insurance.Contracts.ManualPolicies.Certificate item in result)
            {
                MapLookups(companyId, item);
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla Certificate por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de Certificate</returns>
        public static Architect.API.Insurance.Contracts.ManualPolicies.Certificate RetrieveById(int companyId, int id)
        {
            Architect.API.Insurance.Contracts.ManualPolicies.Certificate result = Architect.API.Insurance.DataAccess.ManualPolicies.Certificate.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        /// <summary>
        /// Actualiza un registro en la tabla Certificate por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="item">Instancia de Certificate</param>
        /// <returns>Instancia de Certificate actualizada.</returns>
        public static Architect.API.Insurance.Contracts.ManualPolicies.CertificateResult Update(int companyId, int userId, int id, Architect.API.Insurance.Contracts.ManualPolicies.Certificate item)
        {
            Architect.API.Insurance.Contracts.ManualPolicies.Certificate result = null;
            List<Core.Contracts.General.Error> errors = Architect.API.Insurance.Business.ManualPolicies.Certificate.Validate(companyId, item, false, false);

            if (errors.Count == 0)
            {
                result = item;
                result.Id = id;
                result.CompanyId = companyId;
                result.UpdateUserCode = userId;
                result.UpdateDate = DateTime.Now;

                if (Architect.API.Insurance.DataAccess.ManualPolicies.Certificate.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    Core.Business.General.ChangeSet.Create(0000, item.Id, companyId, "Modificación", string.Format("Se modificó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Insurance.Contracts.ManualPolicies.CertificateResult() { Certificate = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla Certificate por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="userId">Identificación del usuario.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <returns>Instancia de Certificate eliminada.</returns>
        public static Architect.API.Insurance.Contracts.ManualPolicies.CertificateResult Delete(int companyId, int userId, int id)
        {
            Architect.API.Insurance.Contracts.ManualPolicies.Certificate result = null;
            List<Core.Contracts.General.Error> errors = Architect.API.Insurance.Business.ManualPolicies.Certificate.Validate(companyId, new Architect.API.Insurance.Contracts.ManualPolicies.Certificate() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Insurance.DataAccess.ManualPolicies.Certificate.Retrieve(id, companyId);
                if (result.IsNotEmpty() && Architect.API.Insurance.DataAccess.ManualPolicies.Certificate.Delete(id, companyId) > 0)
                {
                    Core.Business.General.ChangeSet.Create(0000, id, companyId, "Eliminar", string.Format("Se eliminó el registro con la identificación '{0}'", result.Id), userId, result);
                }
            }
            return new Architect.API.Insurance.Contracts.ManualPolicies.CertificateResult() { Certificate = result, Errors = errors };
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Certificate que cumplen con el filtro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <returns>Cantidad de registros existentes.</returns>
        public static int Count(int companyId, string filter)
        {
            return Architect.API.Insurance.DataAccess.ManualPolicies.Certificate.Count(Architect.API.Insurance.DataAccess.ManualPolicies.Certificate.FilterBuilder(filter));
        }

        /// <summary>
        /// Validaciones para los campos de la tabla Certificate.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="source">Instancia de Certificate</param>
        /// <param name="isnew">Indicador de registro nuevo.</param>
        /// <param name="isdelete">Indicador que se quiere eliminar el registro.</param>
        /// <returns>Lista de errores/notificaciones resultantes de las validaciones.</returns>
        public static List<Core.Contracts.General.Error> Validate(int companyId, Architect.API.Insurance.Contracts.ManualPolicies.Certificate source, bool isnew, bool isdelete)
        {
            string group = "Certificate";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //Id:
            if ((!isnew || isdelete) && source.Id.IsEmpty())
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "Debe indicar el identificación" });
            }
            if ((!isnew || isdelete) && source.Id.IsNotEmpty() && Architect.API.Insurance.DataAccess.ManualPolicies.Certificate.Count(source.Id, companyId) == 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificación no está registrada" });
            }
            if (isnew && source.Id.IsNotEmpty() && Architect.API.Insurance.DataAccess.ManualPolicies.Certificate.Count(source.Id, companyId) > 0)
            {
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Id", Message = "La identificación ya está registrada" });
            }
            if (!isdelete)
            {

                //PolicyInternalId:

                //CertificateId:

                //IssueDate:

                //EffectiveDate:

                //EndingDate:

                //InsuredAmount:

                //FuneralExpenses:

                //CustomData:
            }

            return result;
        }

        /// <summary>
        /// Realiza la lectura de las descripciones asociadas a columnas que posean una lista de valores.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="item">Instancia de Certificate</param>
        private static void MapLookups(int companyId, Architect.API.Insurance.Contracts.ManualPolicies.Certificate item)
        {
            if (item.IsEmpty())
            {
                return;
            }

        }

    }
}
