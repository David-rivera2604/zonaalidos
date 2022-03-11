using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Core.Business.Security
{
    /// <summary>
    /// Roles de seguridad.
    /// </summary>
    public static partial class RoleMember
    {

        public static List<Architect.Utilities.Contracts.LookUpValue> LookUp(int companyId, int securityLevel)
        {
            List<Architect.Utilities.Contracts.LookUpValue> result = Architect.API.Core.DataAccess.Security.RoleMember.LookUp(companyId, securityLevel);

            return result;
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
