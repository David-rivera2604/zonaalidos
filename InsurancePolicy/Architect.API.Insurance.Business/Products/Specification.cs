using Architect.API.Insurance.Contracts.Product;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace Architect.API.Insurance.Business.Products
{
    public static class Specification
    {
        //public static Architect.Insurance.Contracts.Product.ProductMaster ProductMasterByAlias(string productAlias)
        //{
        //    Architect.Insurance.Contracts.Product.ProductMaster result = null;
        //    string productDefFilename = string.Format(@"{0}\{1}.xml", ConfigurationManager.AppSettings["Product.Definition.Path"], productAlias);

        //    if (System.IO.File.Exists(productDefFilename))
        //        result = Architect.Insurance.Services.Product.Load(productDefFilename);

        //    return result;
        //}

        public static ProductDefinition DefinitionByAlias(string productAlias)
        {
            Architect.Insurance.Contracts.Product.ProductMaster product = Definition(productAlias);
            ProductDefinition result = null;

            if (product.IsNotEmpty())
            {
                result = new ProductDefinition()
                {
                    Title = product.Title,
                    SubTitle = product.SubTitle,
                    Currencies = new List<LookupSimple>(),
                    PaymentFrequencies = new List<LookupSimple>(),
                    Modules = new List<LookupModules>(),
                    AllowDigitalSign = Products.Specification.SettingBoolValue(productAlias, "Allow.DigitalSign")
                };

                result.OwnerName = SettingStringValue(productAlias, "Parent.Policy.Owner.Name");
                result.OwnerId = SettingStringValue(productAlias, "Parent.Policy.Owner.Id");

                //Se calcula la vigencia de la póliza matriz
                result.Effective = SettingDateTimeValue(productAlias, "Parent.Policy.Effective", DateTime.Today);
                //Renovación automática
                result.Effective = result.Effective.AddYears(DateTime.Today.Year - result.Effective.Year);
                //Duración 1 año
                result.Ending = result.Effective.AddYears(1);

                foreach (Architect.Insurance.Contracts.Product.CurrencyAllowed currencyAllowed in product.CurrenciesAllowed)
                {
                    result.Currencies.Add(new LookupSimple()
                    {
                        Code = currencyAllowed.CurrencyCode,
                        Description = currencyAllowed.Description
                    });
                }

                foreach (Architect.Insurance.Contracts.Product.PaymentFrequencyAllowed frequencyAllow in product.PaymentFrequenciesAllowed)
                {
                    result.PaymentFrequencies.Add(new LookupSimple()
                    {
                        Code = frequencyAllow.PaymentFrequencyCode,
                        Description = frequencyAllow.Description
                    });
                }

                LookupModules item = null;
                Architect.Insurance.Contracts.Product.Coverage fixCover = null;

                foreach (Architect.Insurance.Contracts.Product.Module moduleAllowed in product.Modules)
                {
                    item = new LookupModules()
                    {
                        Code = (short)moduleAllowed.ModuleCode,
                        Description = moduleAllowed.Description,
                        MinimumAge = moduleAllowed.Coverages.FirstOrDefault().MinimumAge,
                        MaximumAge = moduleAllowed.Coverages.FirstOrDefault().MaximumAge,
                        MinimumInsuredAmount = moduleAllowed.Coverages.FirstOrDefault().MinimumInsuredAmount,
                        MaximumInsuredAmount = moduleAllowed.Coverages.FirstOrDefault().MaximumInsuredAmount,
                        CurrencyAllowed = moduleAllowed.currencyallowed
                    };
                    result.Modules.Add(item);
                    if (product.Modules.Count == 1)
                    {
                        fixCover = Architect.Insurance.Services.Rating.FixedCoverage(moduleAllowed);
                        if (fixCover != null)
                        {
                            item.FixedInsuredAmount = fixCover.FixedInsuredAmount;
                            item.FixedPremium = fixCover.FixedPremium;
                            item.FixedMonthlyPremium = fixCover.FixedPremium / 12;
                        }
                        Architect.Insurance.Contracts.Policy.Risk rk = Business.Policy.Rating.Asegurado(productAlias, result.Currencies.First().Code, result.Modules.First().Code, result.PaymentFrequencies.First().Code, (double)fixCover.FixedInsuredAmount, DateTime.Now);

                        if (rk.IsNotEmpty())
                        {
                            item.FixedPremium = rk.Premium.AnnualPremium;
                            item.FixedMonthlyPremium = rk.Premium.BillPremium;
                        }
                    }
                }
                if (product.DataEntrySectionsAllowed.IsNotEmpty())
                {
                    result.EntryAllowed = ";";
                    result.EntryIsRequired = ";";
                    foreach (Architect.Insurance.Contracts.Product.DataEntrySection entry in product.DataEntrySectionsAllowed)
                    {
                        if (entry.Active)
                        {
                            result.EntryAllowed += $"{entry.Code};";
                            if (entry.Required)
                            {
                                result.EntryIsRequired += $"{entry.Code};";
                            }
                        }
                    }
                }

            }
            return result;
        }

        public static Architect.Insurance.Contracts.Product.ProductMaster Definition(string alias)
        {
            Architect.Insurance.Contracts.Product.ProductMaster product = null;
            string key = $"product_{alias}";

            if (ConfigurationManager.AppSettings["Working.Mode"] == "Development" || Utilities.Cache.NotExist(key))
            {
                string productDefFilename = string.Format(@"{0}\{1}.xml", ConfigurationManager.AppSettings["Product.Definition.Path"], alias);

                if (System.IO.File.Exists(productDefFilename))
                    product = Architect.Insurance.Services.Product.Load(productDefFilename);
                Utilities.Cache.SetItem(key, product);
            }
            else
            {
                product = (Architect.Insurance.Contracts.Product.ProductMaster)Utilities.Cache.GetItem(key);
            }

            return product;
        }

        public static bool EntryAllow(string alias, string entryName)
        {
            bool result = false;
            Architect.Insurance.Contracts.Product.ProductMaster product = Definition(alias);
            if (product != null && product.DataEntrySectionsAllowed != null)
            {

                foreach (Architect.Insurance.Contracts.Product.DataEntrySection entry in product.DataEntrySectionsAllowed)
                {
                    if (entry.Code.Equals(entryName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public static bool EntryIsRequired(string alias, string entryName)
        {
            bool result = false;
            Architect.Insurance.Contracts.Product.ProductMaster product = Definition(alias);
            if (product != null && product.DataEntrySectionsAllowed != null)
            {

                foreach (Architect.Insurance.Contracts.Product.DataEntrySection entry in product.DataEntrySectionsAllowed)
                {
                    if (entry.Code == entryName && entry.Required)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public static string SettingStringValue(string alias, string name, string defaultValue = "")
        {
            string result = defaultValue;
            Architect.Insurance.Contracts.Product.ProductMaster product = Definition(alias);
            if (product != null && product.Settings != null)
            {

                foreach (Architect.Insurance.Contracts.Product.Setting entry in product.Settings)
                {
                    if (entry.Name == name)
                    {
                        result = entry.Value;
                        break;
                    }
                }
            }
            return result;
        }

        public static DateTime SettingDateTimeValue(string alias, string name, DateTime? defaultValue = null)
        {
            DateTime result = defaultValue ?? DateTime.MinValue;
            Architect.Insurance.Contracts.Product.ProductMaster product = Definition(alias);
            if (product != null && product?.Settings != null)
            {

                foreach (Architect.Insurance.Contracts.Product.Setting entry in product.Settings)
                {
                    if (entry.Name == name)
                    {
                        result = DateTime.ParseExact(entry.Value, "yyyy-MM-ddTHH:mm:ss", CultureInfo.CurrentCulture);

                        break;
                    }
                }
            }
            return result;
        }

        public static bool SettingBoolValue(string alias, string name, bool defaultValue = false)
        {
            bool result = defaultValue;
            Architect.Insurance.Contracts.Product.ProductMaster product = Definition(alias);
            if (product != null && product?.Settings != null)
            {

                foreach (Architect.Insurance.Contracts.Product.Setting entry in product.Settings)
                {
                    if (entry.Name == name)
                    {
                        result = (entry.Value.ToLower() == "true" ||
                                  entry.Value.ToLower() == "verdadero" ||
                                  entry.Value.ToLower() == "yes" ||
                                  entry.Value.ToLower() == "si");
                        break;
                    }
                }
            }
            return result;
        }

        public static Int32 SettingInt32Value(string alias, string name, Int32 defaultValue = 0)
        {
            Int32 result = defaultValue;
            Architect.Insurance.Contracts.Product.ProductMaster product = Definition(alias);
            if (product != null && product?.Settings != null)
            {

                foreach (Architect.Insurance.Contracts.Product.Setting entry in product.Settings)
                {
                    if (entry.Name == name)
                    {
                        result = Convert.ToInt32(entry.Value);
                        break;
                    }
                }
            }
            return result;
        }

        public static double SettingDoubleValue(string alias, string name, double defaultValue = 0.0)
        {
            double result = defaultValue;
            Architect.Insurance.Contracts.Product.ProductMaster product = Definition(alias);
            if (product != null && product?.Settings != null)
            {

                foreach (Architect.Insurance.Contracts.Product.Setting entry in product.Settings)
                {
                    if (entry.Name == name)
                    {
                        result = Convert.ToDouble(entry.Value);
                        break;
                    }
                }
            }
            return result;
        }

    }
}
