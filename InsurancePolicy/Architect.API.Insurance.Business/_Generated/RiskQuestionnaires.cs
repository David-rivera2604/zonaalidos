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
        public static Contracts.Policy.RiskQuestionnaires Mapper(Contracts.Policy.RiskQuestionnaires target, Contracts.Policy.RiskQuestionnaires source)
        {
            //target.Id = source.Id;
            //target.PolicyId = source.PolicyId;
            //target.Type = source.Type;
            //target.QuestionId = source.QuestionId;
            target.Confirmation = source.Confirmation;
            target.Diagnosis = source.Diagnosis;
            target.Treatment = source.Treatment;
            target.Doctor = source.Doctor;
            target.When = source.When;
            target.CompanyId = source.CompanyId;
            //target.UpdateUserCode = source.UpdateUserCode;
            //target.UpdateDate = source.UpdateDate;
            return target;
        }

        public static Contracts.Policy.RiskQuestionaryView Mapper2View(List<Contracts.Policy.RiskQuestionnaires> source)
        {
            Contracts.Policy.RiskQuestionaryView target = new Contracts.Policy.RiskQuestionaryView();
            foreach (Contracts.Policy.RiskQuestionnaires item in source)
            {

                switch (item.QuestionId)
                {
                    case 1:
                        target.Question1 = Mapper2View(item);
                        break;
                    case 2:
                        target.Question2 = Mapper2View(item);
                        break;
                    case 3:
                        target.Question3 = Mapper2View(item);
                        break;
                    case 4:
                        target.Question4 = Mapper2View(item);
                        break;
                    case 5:
                        target.Question5 = Mapper2View(item);
                        break;
                    case 6:
                        target.Question6 = Mapper2View(item);
                        break;
                    case 7:
                        target.Question7 = Mapper2View(item);
                        break;
                    case 8:
                        target.Question8 = Mapper2View(item);
                        break;
                    case 9:
                        target.Question9 = Mapper2View(item);
                        break;
                    case 10:
                        target.Question10 = Mapper2View(item);
                        break;
                    case 11:
                        target.Question11 = Mapper2View(item);
                        break;
                    case 12:
                        target.Question12 = Mapper2View(item);
                        break;
                    case 13:
                        target.Question13 = Mapper2View(item);
                        break;
                    case 14:
                        target.Question14 = Mapper2View(item);
                        break;


                    case 51:
                        target.Question51 = Mapper2View(item);
                        break;
                    case 52:
                        target.Question52 = Mapper2View(item);
                        break;
                    case 53:
                        target.Question53 = Mapper2View(item);
                        break;
                    case 54:
                        target.Question54 = Mapper2View(item);
                        break;
                    case 55:
                        target.Question55 = Mapper2View(item);
                        break;
                    case 56:
                        target.Question56 = Mapper2View(item);
                        break;
                    case 57:
                        target.Question57 = Mapper2View(item);
                        break;
                    case 58:
                        target.Question58 = Mapper2View(item);
                        break;
                    case 59:
                        target.Question59 = Mapper2View(item);
                        break;
                }
            }
            return target;
        }

        public static Contracts.Policy.RiskQuestionView Mapper2View(Contracts.Policy.RiskQuestionnaires source)
        {
            Contracts.Policy.RiskQuestionView target = new Contracts.Policy.RiskQuestionView();
            //target.Id = source.Id;
            //target.PolicyId = source.PolicyId;
            //target.Type = source.Type;
            //target.QuestionId = source.QuestionId;
            if (source.QuestionId == 54)
            {
                target.Detail = new Contracts.Policy.RiskQuestionDiagnosisDetailView();
            }
            target.Confirmation = source.Confirmation;
            if (target.Confirmation != 2)
            {
                target.Diagnosis = source.Diagnosis.ToUpper();
                target.Treatment = source.Treatment.ToUpper();
                target.Doctor = source.Doctor.ToUpper();
                target.When = source.When;
                if (source.QuestionId == 54 && source.Diagnosis.IsNotEmpty())
                {
                    string value = source.Diagnosis + ",false,false,false,false,false,false";
                    target.Detail.Detail1 = value.Split(',')[0] == "true";
                    target.Detail.Detail2 = value.Split(',')[1] == "true";
                    target.Detail.Detail3 = value.Split(',')[2] == "true";
                    target.Detail.Detail4 = value.Split(',')[3] == "true";
                    target.Detail.Detail5 = value.Split(',')[4] == "true";
                    target.Detail.Detail6 = value.Split(',')[5] == "true";
                }
            }
            //target.CompanyId = source.CompanyId;
            //target.UpdateUserCode = source.UpdateUserCode;
            //target.UpdateDate = source.UpdateDate;
            return target;
        }


        public static List<Contracts.Policy.RiskQuestionDiagnosisView> Mapper2DiagnosisView(List<Contracts.Policy.RiskQuestionnaires> source)
        {
            List<Contracts.Policy.RiskQuestionDiagnosisView> target = new List<Contracts.Policy.RiskQuestionDiagnosisView>();
            int[] equiv = { 0, 1, 8, 2, 12, 5, 7, 10, 3, 13, 14, 4, 6, 9, 11 };
            int questionViewId = 0;
            foreach (Contracts.Policy.RiskQuestionnaires item in source)
            {
                if (item.QuestionId >= 1 && item.QuestionId <= 14)
                {
                    questionViewId = equiv[item.QuestionId];
                    if (item.Confirmation == 1 && (questionViewId == 1 || questionViewId == 2 || questionViewId == 4 || questionViewId == 5 || questionViewId == 12))
                    {
                        target.Add(new Contracts.Policy.RiskQuestionDiagnosisView()
                        {
                            Id = questionViewId,
                            Diagnosis = item.Diagnosis.ToUpper(),
                            Treatment = item.Treatment.ToUpper(),
                            Doctor = item.Doctor.ToUpper(),
                            When = item.When
                        });
                    }
                }
            }
            return target;
        }

    }
}
