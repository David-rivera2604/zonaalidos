using System;
using System.Collections.Generic;

namespace Architect.API.Insurance.Business.Policy
{
    public partial class RiskBeneficiary
    {
        public static List<Core.Contracts.General.Error> Validate(List<Architect.API.Insurance.Contracts.Policy.RiskRoles> source,
                                                                  int companyId,
                                                                  Contracts.Policy.Risk risk)
        {
            string group = "beneficiary";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();
            List<Architect.API.Insurance.Contracts.Policy.RiskRoles> Beneficiaries = null;
            if (source != null)
                Beneficiaries = source.FindAll(r => r.Type == 100);
            else
                Beneficiaries = new List<Contracts.Policy.RiskRoles>();

            // Generales
            if (Beneficiaries.Count == 0)
            {
                if (Products.Specification.EntryIsRequired(risk.ProductAlias, "Beneficiaries"))
                {
                    result.Add(new Core.Contracts.General.Error()
                    { Group = group, Key = "*", Message = "Debe existir al menos un beneficiario" });
                }
            }
            else
            {
                foreach (Architect.API.Insurance.Contracts.Policy.RiskRoles item in source)
                {
                    result.AddRange(RiskRoles.Validate(item, group, companyId, risk));
                }
                if (!Rule_100_Percent(source))
                    result.Add(new Core.Contracts.General.Error()
                    {
                        Group = group,
                        Key = "*",
                        Message = "La suma del porcentaje de todos los beneficiarios debe ser 100"
                    });
            }
            return result;
        }

        /// <summary>
        /// Regla: Verifica que el total del porcentaje de participación de todos los beneficiario se 100%
        /// </summary>
        /// <param name="source">Lista con todos los beneficiarios.</param>
        /// <returns>Verdadero si es 100, false en caso contrario</returns>
        private static Boolean Rule_100_Percent(List<Architect.API.Insurance.Contracts.Policy.RiskRoles> source)
        {
            int total = 0;

            foreach (Architect.API.Insurance.Contracts.Policy.RiskRoles item in source)
            {
                total += item.ParticipationRate;
            }
            return (total == 100);
        }
    }
}
