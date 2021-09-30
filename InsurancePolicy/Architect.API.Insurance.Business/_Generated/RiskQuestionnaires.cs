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
            target.Confirmation = source.Confirmation;
            if (target.Confirmation != 2)
            {
                target.Diagnosis = source.Diagnosis;
                target.Treatment = source.Treatment;
                target.Doctor = source.Doctor;
                target.When = source.When;
            }
            //target.CompanyId = source.CompanyId;
            //target.UpdateUserCode = source.UpdateUserCode;
            //target.UpdateDate = source.UpdateDate;
            return target;
        }
    }
}
