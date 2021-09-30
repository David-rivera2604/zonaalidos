using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Insurance.Business.Policy
{
    public partial class RiskQuestionnaires
    {
        public static List<Contracts.Policy.RiskQuestionnaires> RetrieveByPolicyId(int policyId, int companyId)
        {
            List<Contracts.Policy.RiskQuestionnaires> result = DataAccess.Policy.RiskQuestionnaires.RetrieveByPolicyIdCompanyId(policyId, companyId);

            if (result.IsNotEmpty())
                result = (from s in result
                          orderby s.QuestionId
                          select s).ToList();

            return result;
        }

        public static List<Core.Contracts.General.Error> Validate(List<Contracts.Policy.RiskQuestionnaires> source, Contracts.Policy.Risk risk, int companyId)
        {
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();
            bool underwriting = Risk.Rule_Underwriting(risk, companyId);
            foreach (Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires item in source)
            {
                result.AddRange(RiskQuestionnaires.Validate(underwriting , item, risk, companyId));
            }

            return result;
        }

        public static List<Core.Contracts.General.Error> Validate(bool underwriting, Contracts.Policy.RiskQuestionnaires source, Contracts.Policy.Risk risk, int companyId)
        {
            string group = "Questionary";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //QuestionId
            if (underwriting && source.Confirmation.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Confirmation_{0}", source.QuestionId), Message = string.Format("Para mayores de 65 años debe responder la pregunta {0} del cuestionario médico", source.QuestionId) });

            //Diagnosis:
            if (source.QuestionId >= 1 && source.QuestionId <= 6 && source.Confirmation == 1 && source.Diagnosis.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Diagnosis_{0}", source.QuestionId), Message = string.Format("Debe indicar el diagnóstico para la pregunta {0} del cuestionario médico", source.QuestionId) });
            if (source.QuestionId == 7 && source.Confirmation == 1 && source.Diagnosis.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Diagnosis_{0}", source.QuestionId), Message = string.Format("Debe indicar un comentario para la pregunta {0} del cuestionario médico", source.QuestionId) });
            if (source.QuestionId >= 8 && source.QuestionId <= 10 && source.Confirmation == 1 && source.Diagnosis.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Diagnosis_{0}", source.QuestionId), Message = string.Format("Debe indicar el resultado para la pregunta {0} del cuestionario médico", source.QuestionId) });

            //Treatment:
            if (source.QuestionId >= 1 && source.QuestionId <= 6 && source.Confirmation == 1 && source.Treatment.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Treatment_{0}", source.QuestionId), Message = string.Format("Debe indicar el tratamiento para la pregunta {0} del cuestionario médico", source.QuestionId) });
            if (source.QuestionId >= 9 && source.QuestionId <= 10 && source.Confirmation == 1 && source.Treatment.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Treatment_{0}", source.QuestionId), Message = string.Format("Debe indicar el lugar de atención para la pregunta {0} del cuestionario médico", source.QuestionId) });

            //Doctor:
            if (((source.QuestionId >= 1 && source.QuestionId <= 6) || (source.QuestionId >= 9 && source.QuestionId <= 10)) && source.Confirmation == 1 && source.Doctor.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Doctor_{0}", source.QuestionId), Message = string.Format("Debe indicar el médico para la pregunta {0} del cuestionario médico", source.QuestionId) });
            if (((source.QuestionId == 8)) && source.Confirmation == 1 && source.Doctor.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Doctor_{0}", source.QuestionId), Message = string.Format("Debe indicar el motivo para la pregunta {0} del cuestionario médico", source.QuestionId) });

            //When:
            if (((source.QuestionId >= 1 && source.QuestionId <= 6) || (source.QuestionId >= 8 && source.QuestionId <= 10)) && source.Confirmation == 1 && source.When.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("When_{0}", source.QuestionId), Message = string.Format("Debe indicar la fecha para la pregunta {0} del cuestionario médico", source.QuestionId) });

            return result;
        }

    }
}
