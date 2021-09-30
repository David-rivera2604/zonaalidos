using System;
using System.Collections.Generic;
using Architect.Utilities.Extensions;

namespace Architect.API.Core.Business.Security
{
    public static partial class RoleMember
    {

        public static Architect.API.Core.Contracts.Security.RoleMember Create(int companyId, int userId, Architect.API.Core.Contracts.Security.RoleMember item)
        {
            Architect.API.Core.Contracts.Security.RoleMember result = item;
            int affectedRows = 0;

            if (result.RoleId.IsEmpty())
                result.RoleId = Architect.API.Core.DataAccess.Security.RoleMember.RetrieveLastKey() + 1;

            result.CompanyId = companyId;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;

            affectedRows = Architect.API.Core.DataAccess.Security.RoleMember.Create(result);
            if (affectedRows > 0)
            {
                MapLookups(companyId, result);
                Core.Business.General.ChangeSet.Create(1001, result.RoleId, companyId, "Creación", string.Format("Se creó el rol '{0}'", result.RoleName), userId, result);
            }
            return result;
        }

        public static List<Architect.API.Core.Contracts.Security.RoleMember> Retrieve(int companyId, string filter, string recordStatus)
        {
            List<Architect.API.Core.Contracts.Security.RoleMember> result = Architect.API.Core.DataAccess.Security.RoleMember.RetrieveAll(companyId, filter, recordStatus);

            foreach (Architect.API.Core.Contracts.Security.RoleMember item in result)
            {
                MapLookups(companyId, item);
            }

            return result;
        }

        public static List<Architect.Common.DataType.LookUpValue> LookUp(int companyId, int securityLevel)
        {
            List<Architect.Common.DataType.LookUpValue> result = Architect.API.Core.DataAccess.Security.RoleMember.LookUp(companyId,  securityLevel);

            return result;
        }

        public static Architect.API.Core.Contracts.Security.RoleMember RetrieveById(int companyId, int id)
        {
            Architect.API.Core.Contracts.Security.RoleMember result = Architect.API.Core.DataAccess.Security.RoleMember.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        public static Architect.API.Core.Contracts.Security.RoleMember Update(int companyId, int userId, int id, Architect.API.Core.Contracts.Security.RoleMember item)
        {
            Architect.API.Core.Contracts.Security.RoleMember result = item;
            int affectedRows = 0;

            result.RoleId = id;
            result.CompanyId = companyId;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;

            affectedRows = Architect.API.Core.DataAccess.Security.RoleMember.Update(result);
            if (affectedRows > 0)
            {
				MapLookups(companyId, result);
                Core.Business.General.ChangeSet.Create(1001, item.RoleId, companyId, "Modificación", string.Format("Se modificó el rol '{0}'", result.RoleName), userId, result);
			}
            return result;
        }

        public static bool Delete(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.Security.RoleMember result = Architect.API.Core.DataAccess.Security.RoleMember.Retrieve(id, companyId);
            int affectedRows = 0;
            if (result.IsNotEmpty())
            {
                affectedRows = Architect.API.Core.DataAccess.Security.RoleMember.Delete(id, companyId);
                if (affectedRows > 0)
                {
                    Core.Business.General.ChangeSet.Create(1001, id, companyId, "Eliminar", string.Format("Se eliminó el rol '{0}'", result.RoleName), userId, result);
                }
            }
            return affectedRows > 0;
        }

        public static List<Contracts.General.Error> Validate(Architect.API.Core.Contracts.Security.RoleMember source, bool isnew)
        {
            string group = "RoleMember";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //RoleId:
            if (!isnew && source.RoleId.IsEmpty())
                result.Add(new Contracts.General.Error() { Group = group, Key = "RoleId", Message = "Debe indicar el identificador del rol" });

            //RoleName:
            if (source.RoleName.IsEmpty())
                result.Add(new Contracts.General.Error() { Group = group, Key = "RoleName", Message = "Debe indicar el nombre del rol" });

            //Description:

            //SecurityLevel:

            //RecordStatus:
            if (source.RecordStatus.IsEmpty())
                result.Add(new Contracts.General.Error() { Group = group, Key = "RecordStatus", Message = "Debe indicar el estado del registro" });

            return result;
        }

        private static void MapLookups(int companyId, Architect.API.Core.Contracts.Security.RoleMember item)
        {
            if (item.IsNotEmpty())
            {
                if (item.RecordStatus.IsNotEmpty())
                    item.RecordStatusDesc = Common.Lkp("EstadoRegistro", companyId).Find(x => x.Code == item.RecordStatus.ToString()).Description;
            }
        }

        private static string Compare(Architect.API.Core.Contracts.Security.RoleMember currentItem, Architect.API.Core.Contracts.Security.RoleMember newItem, bool verbose, bool applyChange)
        {
            string result = string.Empty;
            if (currentItem.RoleId != newItem.RoleId)
            {
                if (verbose)
                    result += string.Format("{0} cambiado a {1} (valor anterior: {2})", "Indentificación", newItem.RoleId, currentItem.RoleId);
                else if (result.IsEmpty())
                    result = "1";
                if (applyChange)
                    currentItem.RoleId = newItem.RoleId;
            }
            if (currentItem.CompanyId != newItem.CompanyId)
            {
                if (verbose)
                    result += string.Format("{0} cambiado a {1} (valor anterior: {2})", "Compañia", newItem.CompanyId, currentItem.CompanyId);
                else if (result.IsEmpty())
                    result = "1";
                if (applyChange)
                    currentItem.CompanyId = newItem.CompanyId;
            }
            if (currentItem.RoleName != newItem.RoleName)
            {
                if (verbose)
                    result += string.Format("{0} cambiado a {1} (valor anterior: {2})", "Nombre del rol", newItem.RoleName, currentItem.RoleName);
                else if (result.IsEmpty())
                    result = "1";
                if (applyChange)
                    currentItem.RoleName = newItem.RoleName;
            }
            if (currentItem.Description != newItem.Description)
            {
                if (verbose)
                    result += string.Format("{0} cambiado a {1} (valor anterior: {2})", "Descripción", newItem.Description, currentItem.Description);
                else if (result.IsEmpty())
                    result = "1";
                if (applyChange)
                    currentItem.Description = newItem.Description;
            }
            if (currentItem.SecurityLevel != newItem.SecurityLevel)
            {
                if (verbose)
                    result += string.Format("{0} cambiado a {1} (valor anterior: {2})", "Nivel de seguridad", newItem.SecurityLevel, currentItem.SecurityLevel);
                else if (result.IsEmpty())
                    result = "1";
                if (applyChange)
                    currentItem.SecurityLevel = newItem.SecurityLevel;
            }
            if (currentItem.RecordStatus != newItem.RecordStatus)
            {
                if (verbose)
                    result += string.Format("{0} cambiado a {1} (valor anterior: {2})", "Estado", newItem.RecordStatus, currentItem.RecordStatus);
                else if (result.IsEmpty())
                    result = "1";
                if (applyChange)
                    currentItem.RecordStatus = newItem.RecordStatus;
            }

            return result;
        }

    }
}
