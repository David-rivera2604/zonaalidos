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

        /// <summary>
        /// Recupera una lista de registros en la tabla RiskQuestionnaires basado en el número de documento de un asegurado.
        /// </summary>
        /// <param name="documentNumber">Número de documento del asegurado.</param>
        /// <param name="questionnairyName">Nombre del cuestionario.</param>
        /// <param name="companyid">Identificación de la compañía propietaria.</param>
        /// <returns>Lista de instancias de RiskQuestionnaires.</returns>
        public static List<Contracts.Policy.RiskQuestionnaires> RetrieveByDocumentNumber(string documentNumber, string questionnairyName, int companyid)
        {
            int questionIdBegin = 0;
            int questionIdFinish = 0;

            switch (questionnairyName.ToLower())
            {
                case "salud":
                    questionIdBegin = 1;
                    questionIdFinish = 14;
                    break;
                case "covid":
                    questionIdBegin = 50;
                    questionIdFinish = 59;
                    break;
            }
            return DataAccess.Policy.RiskQuestionnaires.RetrieveByDocumentNumber(documentNumber, questionIdBegin, questionIdFinish, companyid);
        }


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

            foreach (Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires item in source)
            {
                result.AddRange(RiskQuestionnaires.Validate(item, risk, companyId));
            }

            return result;
        }

        public static List<Core.Contracts.General.Error> Validate(Contracts.Policy.RiskQuestionnaires source, Contracts.Policy.Risk risk, int companyId)
        {
            string group = "Questionary";
            string name = "cuestionario médico";
            bool skip = false;
            bool underwriting;
            int questionId = source.QuestionId; ;
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            if (source.QuestionId >= 51 && source.QuestionId <= 59)
            {
                group = "QuestionaryCovid";
                name = "cuestionario covid";
                underwriting = (Risk.Rule_UnderwritingInsuredAgeGreaterThan(risk.PrimaryInsured, 60));
                questionId = source.QuestionId;
            }
            else
            {
                underwriting = (Risk.Rule_UnderwritingInsuredAgeGreaterThan(risk.PrimaryInsured, 64));
                int[] equiv = { 0, 1, 8, 2, 12, 5, 7, 10, 3, 13, 14, 4, 6, 9, 11 };
                questionId = equiv[source.QuestionId];
            }

            if ((source.QuestionId == 6 && risk.PrimaryInsured.Gender == 1) ||
                (source.QuestionId == 9 && risk.PrimaryInsured.Gender == 1) ||
                (source.QuestionId == 10 && risk.PrimaryInsured.Gender == 2))
            {
                skip = true;
            }
            if (!skip)
            {
                //QuestionId
                if (underwriting && source.Confirmation.IsEmpty())
                    result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Confirmation_{0}", source.QuestionId), Message = string.Format("Para mayores de 65 años debe responder la pregunta {0} del {1}", source.QuestionId > 50 ? source.QuestionId - 50 : source.QuestionId, name) });

                //Diagnosis:
                if (source.Confirmation == 1 && source.Diagnosis.IsEmpty())
                {
                    if (source.QuestionId == 1 || source.QuestionId == 3 || source.QuestionId == 4 || source.QuestionId == 5 || source.QuestionId == 11)
                        result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Diagnosis_{0}", source.QuestionId), Message = string.Format("Debe indicar el diagnóstico para la pregunta {0} del cuestionario médico", questionId) });

                    if (source.QuestionId == 2 || source.QuestionId == 7 || source.QuestionId == 12 || source.QuestionId == 13)
                        result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Diagnosis_{0}", source.QuestionId), Message = string.Format("Debe ampliar su respuesta  para la pregunta {0} del cuestionario médico", questionId) });

                    if (source.QuestionId == 8 || source.QuestionId == 9 || source.QuestionId == 10)
                        result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Diagnosis_{0}", source.QuestionId), Message = string.Format("Debe indicar el resultado para la pregunta {0} del cuestionario médico", questionId) });
                }

                //Treatment:
                if (source.Confirmation == 1 && source.Treatment.IsEmpty())
                {

                    if (source.QuestionId == 1 || source.QuestionId == 3 || source.QuestionId == 4 || source.QuestionId == 5 || source.QuestionId == 11)
                        result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Treatment_{0}", source.QuestionId), Message = string.Format("Debe indicar el tratamiento para la pregunta {0} del cuestionario médico", questionId) });
                    if (source.QuestionId == 9 || source.QuestionId == 10)
                        result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Treatment_{0}", source.QuestionId), Message = string.Format("Debe indicar el lugar de atención para la pregunta {0} del cuestionario médico", questionId) });
                }

                ////Doctor:
                if (source.Confirmation == 1 && source.Doctor.IsEmpty())
                {
                    if (source.QuestionId == 1 || source.QuestionId == 3 || source.QuestionId == 4 || source.QuestionId == 5 || source.QuestionId == 9 || source.QuestionId == 10 || source.QuestionId == 11)
                        result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Doctor_{0}", source.QuestionId), Message = string.Format("Debe indicar el médico para la pregunta {0} del cuestionario médico", questionId) });

                    if (source.QuestionId == 8)
                        result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Doctor_{0}", source.QuestionId), Message = string.Format("Debe indicar el motivo para la pregunta {0} del cuestionario médico", questionId) });
                    if (source.QuestionId == 14)
                        result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Doctor_{0}", source.QuestionId), Message = string.Format("Debe indicar cuantos cigarros al día fuma para la pregunta {0} del cuestionario médico", questionId) });

                }


                ////When:
                if (source.Confirmation == 1 && source.When.IsEmpty())
                {

                    if (source.QuestionId == 1 || source.QuestionId == 3 || source.QuestionId == 4 || source.QuestionId == 5 || source.QuestionId == 8 || source.QuestionId == 9 || source.QuestionId == 10 || source.QuestionId == 11)
                        result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("When_{0}", source.QuestionId), Message = string.Format("Debe indicar la fecha para la pregunta {0} del cuestionario médico", questionId) });
                    if (source.QuestionId == 6)
                        result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("When_{0}", source.QuestionId), Message = string.Format("Debe indicar la fecha probable del alumbramiento para la pregunta {0} del cuestionario médico", questionId) });
                    if (source.QuestionId == 14)
                        result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("When_{0}", source.QuestionId), Message = string.Format("Debe indicar desde cuando para la pregunta {0} del cuestionario médico", questionId) });
                }

                //Diagnosis:
                //if (source.QuestionId >= 1 && source.QuestionId <= 6 && source.Confirmation == 1 && source.Diagnosis.IsEmpty())
                //    result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Diagnosis_{0}", questionId), Message = string.Format("Debe indicar el diagnóstico para la pregunta {0} del cuestionario médico", questionId) });
                //if (source.QuestionId == 7 && source.Confirmation == 1 && source.Diagnosis.IsEmpty())
                //    result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Diagnosis_{0}", questionId), Message = string.Format("Debe indicar un comentario para la pregunta {0} del cuestionario médico", questionId) });
                //if (source.QuestionId >= 8 && source.QuestionId <= 14 && source.Confirmation == 1 && source.Diagnosis.IsEmpty())
                //    result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Diagnosis_{0}", questionId), Message = string.Format("Debe indicar el resultado para la pregunta {0} del cuestionario médico", questionId) });

                ////Treatment:
                //if (source.QuestionId >= 1 && source.QuestionId <= 6 && source.Confirmation == 1 && source.Treatment.IsEmpty())
                //    result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Treatment_{0}", questionId), Message = string.Format("Debe indicar el tratamiento para la pregunta {0} del cuestionario médico", questionId) });
                //if (source.QuestionId >= 9 && source.QuestionId <= 14 && source.Confirmation == 1 && source.Treatment.IsEmpty())
                //    result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Treatment_{0}", questionId), Message = string.Format("Debe indicar el lugar de atención para la pregunta {0} del cuestionario médico", questionId) });

                ////Doctor:
                //if (((source.QuestionId >= 1 && source.QuestionId <= 6) || (source.QuestionId >= 9 && source.QuestionId <= 14)) && source.Confirmation == 1 && source.Doctor.IsEmpty())
                //    result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Doctor_{0}", questionId), Message = string.Format("Debe indicar el médico para la pregunta {0} del cuestionario médico", questionId) });
                //if (((source.QuestionId == 8)) && source.Confirmation == 1 && source.Doctor.IsEmpty())
                //    result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("Doctor_{0}", questionId), Message = string.Format("Debe indicar el motivo para la pregunta {0} del cuestionario médico", questionId) });

                ////When:
                //if (((source.QuestionId >= 1 && source.QuestionId <= 6) || (source.QuestionId >= 8 && source.QuestionId <= 14)) && source.Confirmation == 1 && source.When.IsEmpty())
                //    result.Add(new Core.Contracts.General.Error() { Group = group, Key = string.Format("When_{0}", questionId), Message = string.Format("Debe indicar la fecha para la pregunta {0} del cuestionario médico", questionId) });
            }
            return result;
        }

    }
}
