using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Architect.Insurance.Services
{
    public class Product
    {
        public static Contracts.Product.ProductMaster Load(string filename)
        {

            Contracts.Product.ProductMaster result = Architect.Utilities.SerializeHandler.DeserializeFromFile<Contracts.Product.ProductMaster>(filename);

            if (result.ClientsAllowed != null)
                result.ClientsAllowed = new List<Contracts.Product.ClientAllowed>() { new Contracts.Product.ClientAllowed() { ClientRole = 2 } };

            foreach (Contracts.Product.Module moduleItem in from r in result.Modules select r)
                if (moduleItem.Coverages != null)
                {
                    if ((from r in moduleItem.Coverages where r.Selected select r).Count() == 0)
                        foreach (Contracts.Product.Coverage coverageItem in from r in moduleItem.Coverages select r)
                            coverageItem.Selected = true;

                    if ((from r in moduleItem.Coverages where r.ClientRole == 0 select r).Count() > 0)
                        foreach (Contracts.Product.Coverage coverageItem in from r in moduleItem.Coverages where r.ClientRole == 0  select r)
                            coverageItem.ClientRole = 2;
                }
            if (result.Modules != null)
                foreach (Contracts.Product.Module moduleItem in from r in result.Modules select r)
                    if (moduleItem.Coverages != null)
                        if ((from r in moduleItem.Coverages where r.Selected select r).Count() == 0)
                            foreach (Contracts.Product.Coverage coverageItem in from r in moduleItem.Coverages select r)
                                coverageItem.Selected = true;

            if (result.BillingConcepts != null)
                foreach (Contracts.Product.BillingConcept billItem in from r in result.BillingConcepts select r)
                    if (billItem.Details != null)
                        if ((from r in billItem.Details where r.Selected select r).Count() == 0)
                            foreach (Contracts.Product.BillingDetail detailItem in from r in billItem.Details select r)
                                detailItem.Selected = true;


            return result;
        }

    }
}
