using Architect.Utilities.Extensions;

namespace Architect.API.Insurance.Business.Policy
{
    public partial class Risk
    {
        public static Contracts.Policy.Risk Mapper(Contracts.Policy.Risk target, Contracts.Policy.Risk source)
        {
            //target.Id = source.Id;
            //target.LineOfBusinessCode = source.LineOfBusinessCode;
            //target.ProductCode = source.ProductCode;
            target.PolicyId = source.PolicyId.IfEmpty(target.PolicyId);
            target.Currency = source.Currency;
            target.ModuleCode = source.ModuleCode;
            target.PaymentFrequency = source.PaymentFrequency;
            target.IssueDate = source.IssueDate;
            target.EffectiveDate = source.EffectiveDate;
            target.EndingDate = source.EndingDate;
            target.InsuredAmount = source.InsuredAmount;
            target.AnnualPremium = source.AnnualPremium;
            target.MonthlyPremium = source.MonthlyPremium;
            target.Surcharge = source.Surcharge;
            //target.Status = source.Status;
            target.Status = source.Status.IfEmpty(target.Status);
            target.CancellationDate = source.CancellationDate;
            target.ReasonForStatus = source.ReasonForStatus;
            target.CompanyId = source.CompanyId;
            target.CustomData = source.CustomData;
            target.Comments = source.Comments;
            target.Annotation = source.Annotation;
            target.InsuredAmountBase = source.InsuredAmountBase;
            target.InsuredAmountComplement = source.InsuredAmountComplement;
            //target.OwnerId = source.OwnerId;
            //target.UpdateUserCode = source.UpdateUserCode;
            //target.UpdateDate = source.UpdateDate;
            return target;
        }

        public static Contracts.Policy.RiskView Mapper2View(Contracts.Policy.Risk source)
        {
            Contracts.Policy.RiskView target = null;
            if (source != null)
            {
                target = new Contracts.Policy.RiskView();
                target.Id = source.Id;
                target.LineOfBusinessCode = source.LineOfBusinessCode;
                target.ProductCode = source.ProductCode;
                target.PolicyId = source.PolicyId;
                target.Currency = source.Currency;
                target.ModuleCode = source.ModuleCode;
                target.PaymentFrequency = source.PaymentFrequency;
                target.IssueDate = source.IssueDate;
                target.EffectiveDate = source.EffectiveDate;
                target.EndingDate = source.EndingDate;
                target.InsuredAmount = source.InsuredAmount;
                target.AnnualPremium = source.AnnualPremium;
                target.MonthlyPremium = source.MonthlyPremium;
                target.Status = source.Status;
                target.StatusDesc = source.StatusDesc.ToUpper();
                target.CancellationDate = source.CancellationDate;
                target.ReasonForStatus = source.ReasonForStatus;
                target.Comments = source.Comments.ToUpper();
                //target.CompanyId = source.CompanyId;
                //target.UpdateUserCode = source.UpdateUserCode;
                //target.UpdateDate = source.UpdateDate;
            }
            return target;
        }
    }
}
