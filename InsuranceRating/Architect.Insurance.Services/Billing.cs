using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Architect.Insurance.Services
{
    public class Billing
    {

        static List<Contracts.Policy.PremiumDetail> ApplyForCoverage(Contracts.Policy.Risk risk, Contracts.Product.BillingDetail billdetail, Contracts.Product.BillingDetailCondition condition, int paymentFrequencyDiv)
        {
            List<Contracts.Policy.PremiumDetail> result = new List<Contracts.Policy.PremiumDetail>();
            Contracts.Policy.PremiumDetail currentDetail = null;
            Contracts.Policy.Module modItem = null;
            Contracts.Policy.Coverage cover = null;
            decimal percentage = billdetail.Percentage;

            if (condition.Percentage != 0)
                percentage = condition.Percentage;

            modItem = (from r in risk.Modules where r.ModuleCode == condition.ModuleCode || condition.ModuleCode == 0 select r).FirstOrDefault();
            if (modItem != null)
            {
                cover = (from r in modItem.Coverages where r.CoverageCode == condition.ApplyOnCode && r.Selected select r).FirstOrDefault();
                if (cover != null)
                {
                    currentDetail = new Contracts.Policy.PremiumDetail()
                    {
                        BillingCode = billdetail.BillingConcept.BillingCode,
                        CoverageCode = 0,
                        Code = billdetail.Code,
                        Type = billdetail.Type,
                        TypeDescription = billdetail.TypeDescription,
                        InsuredAmount = 0,
                        AnnualPremium = 0,
                        Premium = 0,
                        Percentage = percentage,
                        BillingDescription = billdetail.BillingConcept.Description,
                        SourceDescription = billdetail.Description
                    };
                    result.Add(currentDetail);
                    if (percentage > 0)
                        currentDetail.AnnualPremium = cover.Premium * (percentage / 100);
                    else if (billdetail.FixedAmount > 0)
                        currentDetail.AnnualPremium = billdetail.FixedAmount;
                    currentDetail.Premium = currentDetail.AnnualPremium / paymentFrequencyDiv;
                }
            }
            return result;
        }

        static List<Contracts.Policy.PremiumDetail> ApplyForOtherBillItems(List<Contracts.Policy.PremiumDetail> premiumDetails, Contracts.Product.BillingDetail billdetail, Contracts.Product.BillingDetailCondition condition, int paymentFrequencyDiv)
        {
            List<Contracts.Policy.PremiumDetail> extraItems = new List<Contracts.Policy.PremiumDetail>();
            Contracts.Policy.PremiumDetail currentDetail = null;
            decimal percentage = billdetail.Percentage;

            if (condition.Percentage != 0)
                percentage = condition.Percentage;


            foreach (Contracts.Policy.PremiumDetail detail in from r in premiumDetails where r.BillingCode == condition.ApplyOnCode select r)
            {
                currentDetail = new Contracts.Policy.PremiumDetail()
                {
                    BillingCode = billdetail.BillingConcept.BillingCode,
                    CoverageCode = 0,
                    Code = billdetail.Code,
                    Type = billdetail.Type,
                    TypeDescription = billdetail.TypeDescription,
                    InsuredAmount = 0,
                    AnnualPremium = 0,
                    Premium = 0,
                    Percentage = percentage,
                    BillingDescription = billdetail.BillingConcept.Description,
                    SourceDescription = billdetail.Description
                };
                extraItems.Add(currentDetail);
                if (percentage > 0)
                    currentDetail.AnnualPremium = detail.AnnualPremium * (percentage / 100);
                else if (billdetail.FixedAmount > 0)
                    currentDetail.AnnualPremium = billdetail.FixedAmount;
                currentDetail.Premium = currentDetail.AnnualPremium / paymentFrequencyDiv;
            }

            return extraItems;
        }

        static List<Contracts.Policy.PremiumDetail> BillingCoverages(Contracts.Policy.Risk risk, Contracts.Product.ProductMaster product, int paymentFrequencyDiv)
        {
            List<Contracts.Policy.PremiumDetail> premiumDetails = new List<Contracts.Policy.PremiumDetail>();
            foreach (Contracts.Policy.Module modItemdef in risk.Modules)
            {
                foreach (Contracts.Policy.Coverage coverdef in modItemdef.Coverages)
                {
                    if (coverdef.Selected && coverdef.CoverageDefinition.BillingCode != 0)
                    {
                        premiumDetails.Add(new Contracts.Policy.PremiumDetail()
                        {
                            BillingCode = coverdef.CoverageDefinition.BillingCode,
                            CoverageCode = coverdef.CoverageCode,
                            Code = 0,
                            InsuredAmount = coverdef.InsuredAmount,
                            AnnualPremium = coverdef.Premium,
                            Premium = coverdef.Premium / paymentFrequencyDiv,
                            Percentage = coverdef.Rate,
                            BillingDescription = (from r in product.BillingConcepts where r.BillingCode == coverdef.CoverageDefinition.BillingCode select r.Description).FirstOrDefault(),
                            SourceDescription = coverdef.Description
                        });
                    }
                }
            }
            return premiumDetails;
        }

        static void BillingProtectionElementBehavior(List<Contracts.Policy.Protection> protections, Contracts.Product.BillingDetail billDetail, List<Contracts.Product.Protection> productProtections)
        {
            decimal percentage = 0;
            decimal fixedAmount = 0;
            Contracts.Product.Protection current = null;

            if (protections != null)
            {
                foreach (Contracts.Policy.Protection item in protections)
                {
                    current = (from r in productProtections where r.ElementCode == item.ElementCode select r).FirstOrDefault();
                    if (current != null)
                    {
                        percentage += current.Percentage;
                        fixedAmount += current.FixedAmount;
                    }
                }
                billDetail.Percentage = percentage;
                billDetail.FixedAmount = fixedAmount;

            }
        }

        static List<Contracts.Product.BillingDetail> PrepareBillItems(Contracts.Product.ProductMaster product)
        {
            List<Contracts.Product.BillingDetail> billingDetails = new List<Contracts.Product.BillingDetail>();

            foreach (Contracts.Product.BillingConcept billItem in from r in product.BillingConcepts where r.Status == 1 select r)
            {
                if (billItem.Details != null)
                    foreach (Contracts.Product.BillingDetail detailItem in from r in billItem.Details where r.Status == 1 && r.Selected select r)
                    {
                        detailItem.BillingConcept = billItem;
                        billingDetails.Add(detailItem);
                    }
            }
            return billingDetails;
        }

        public static void Calculate(Contracts.Policy.Risk risk, Contracts.Product.ProductMaster product)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            if (risk.Notify == null)
                risk.Notify = new List<Contracts.General.Notify>();




            int paymentFrequencyDiv = 1;

            switch (risk.PaymentFrequencyCode)
            {
                case 1: //Mensual
                    paymentFrequencyDiv = 12;
                    break;

                case 2: //BiMensual
                    paymentFrequencyDiv = 6;
                    break;

                case 3: //Trimestral
                    paymentFrequencyDiv = 4;
                    break;
                case 4: //Semestral
                    paymentFrequencyDiv = 2;
                    break;

                case 5: //Anual
                default:
                    paymentFrequencyDiv = 1;
                    break;
            }

            List<Contracts.Product.BillingDetail> billingDetails = PrepareBillItems(product);
            List<Contracts.Policy.PremiumDetail> premiumDetails = BillingCoverages(risk, product, paymentFrequencyDiv);

            foreach (Contracts.Product.BillingDetail item in from r in billingDetails orderby r.Order select r)
            {
                if (item.ProtectionElementBehavior && risk.Protections != null && risk.Protections.Count() > 0)
                    BillingProtectionElementBehavior(risk.Protections, item, product.Protections);

                foreach (Contracts.Product.BillingDetailCondition condItem in item.Conditions)
                {
                    switch (condItem.AppliesOn)
                    {
                        case 1: //Cobertura
                            premiumDetails.AddRange(ApplyForCoverage(risk, item, condItem, paymentFrequencyDiv));
                            break;

                        case 2: //Recargo técnico
                            premiumDetails.AddRange(ApplyForOtherBillItems( premiumDetails, item, condItem, paymentFrequencyDiv));
                            break;

                        default:
                            throw new NotImplementedException(string.Format("BillingDetailCondition.AppliesOn {0} not implement", condItem.AppliesOn));

                    }

                }
            }
            risk.Premium = new Contracts.Policy.Premium()
            {
                PremiumDetails = premiumDetails,
                AnnualPremium = premiumDetails.Sum(r => r.AnnualPremium),
                BillPremium = premiumDetails.Sum(r => r.Premium)
            };
            if (risk.Notify.Count == 0)
                risk.Notify = null;

            watch.Stop();
            risk.BillingTiming = watch.ElapsedMilliseconds;
        }

    }
}
