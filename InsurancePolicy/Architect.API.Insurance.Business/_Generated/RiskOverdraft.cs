using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Insurance.Business.Policy
{
    public partial class RiskOverdraft
    {
        public static Contracts.Policy.RiskOverdraft Mapper(Contracts.Policy.RiskOverdraft target, Contracts.Policy.RiskOverdraft source)
        {
            //target.Id = source.Id;
            target.StartTerm = source.StartTerm;
            target.EndTerm = source.EndTerm;
            target.Amount1 = source.Amount1;
            target.EndTermOnAmount1 = source.EndTermOnAmount1;
            target.Recast1 = source.Recast1;
            target.Amount2 = source.Amount2;
            target.EndTermOnAmount2 = source.EndTermOnAmount2;
            target.Recast2 = source.Recast2;
            target.Amount3 = source.Amount3;
            target.EndTermOnAmount3 = source.EndTermOnAmount3;
            target.Recast3 = source.Recast3;
            target.Amount4 = source.Amount4;
            target.EndTermOnAmount4 = source.EndTermOnAmount4;
            target.Recast4 = source.Recast4;
            target.Amount5 = source.Amount5;
            target.EndTermOnAmount5 = source.EndTermOnAmount5;
            target.Recast5 = source.Recast5;
            target.CompanyId= source.CompanyId;
            //target.UpdateDate = source.UpdateDate;
            //target.UpdateUserCode = source.UpdateUserCode;
            return target;
        }

        public static Contracts.Policy.RiskOverdraftView Mapper2View(Contracts.Policy.RiskOverdraft source)
        {
            Contracts.Policy.RiskOverdraftView target = new Contracts.Policy.RiskOverdraftView();
            if (source != null)
            {
                target.Id = source.Id;
                target.StartTerm = source.StartTerm;
                target.EndTerm = source.EndTerm;
                target.Amount1 = source.Amount1;
                target.EndTermOnAmount1 = source.EndTermOnAmount1;
                target.Amount2 = source.Amount2;
                target.EndTermOnAmount2 = source.EndTermOnAmount2;
                target.Amount3 = source.Amount3;
                target.EndTermOnAmount3 = source.EndTermOnAmount3;
                target.Amount4 = source.Amount4;
                target.EndTermOnAmount4 = source.EndTermOnAmount4;
                target.Amount5 = source.Amount5;
                target.EndTermOnAmount5 = source.EndTermOnAmount5;
                target.UpdateDate = source.UpdateDate;
                target.UpdateUserCode = source.UpdateUserCode;
            }
            return target;
        }
    }
}
