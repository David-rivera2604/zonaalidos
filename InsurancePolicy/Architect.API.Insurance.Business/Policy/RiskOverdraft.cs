using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Insurance.Business.Policy
{
    public partial class RiskOverdraft
    {
        public static List<Core.Contracts.General.Error> Validate(Contracts.Policy.RiskOverdraft source)
        {
            string group = "Overdraft";
            List<Core.Contracts.General.Error> result = new List<Core.Contracts.General.Error>();

            //StartTerm:
            if (source.StartTerm.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "StartTerm", Message = "Debe indicar el inicio del plazo para el préstamo" });

            //EndTerm:
            if (source.EndTerm.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "EndTerm", Message = "Debe indicar el fin del plazo para el préstamo" });
            else
                if (source.StartTerm.IsNotEmpty() && source.StartTerm >= source.EndTerm)
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "EndTerm", Message = "El fin del plazo debe posterior al inicio del mismo" });

            //AmountOn1EndTerm1:
            if (source.Amount1.IsEmpty() && source.EndTermOnAmount1.IsNotEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Amount1", Message = "Debe indicar el monto para el detalle del 1er préstamo" });
            //EndTerm1On1Amount1:
            if (source.Amount1.IsNotEmpty() && source.EndTermOnAmount1.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "EndTermOnAmount1", Message = "Debe indicar el fin del plazo para el detalle del 1er préstamo" });

            //AmountOn2EndTerm2:
            if (source.Amount2.IsEmpty() && source.EndTermOnAmount2.IsNotEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Amount2", Message = "Debe indicar el monto para el detalle del 2do préstamo" });
            //EndTermOn2Amount2:
            if (source.Amount2.IsNotEmpty() && source.EndTermOnAmount2.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "EndTermOnAmount2", Message = "Debe indicar el fin del plazo para el detalle del 2do préstamo" });

            //AmountOn3EndTerm3:
            if (source.Amount3.IsEmpty() && source.EndTermOnAmount3.IsNotEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Amount3", Message = "Debe indicar el monto para el detalle del 3er préstamo" });
            //EndTermOn3Amount3:
            if (source.Amount3.IsNotEmpty() && source.EndTermOnAmount3.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "EndTermOnAmount3", Message = "Debe indicar el fin del plazo para el detalle del 3er préstamo" });

            //AmountOn4EndTerm4:
            if (source.Amount4.IsEmpty() && source.EndTermOnAmount4.IsNotEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Amount4", Message = "Debe indicar el monto para el detalle del 4to préstamo" });
            //EndTermOn4Amount4:
            if (source.Amount4.IsNotEmpty() && source.EndTermOnAmount4.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "EndTermOnAmount4", Message = "Debe indicar el fin del plazo para el detalle del 4to préstamo" });

            //AmountOn5EndTerm5:
            if (source.Amount5.IsEmpty() && source.EndTermOnAmount5.IsNotEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "Amount5", Message = "Debe indicar el monto para el detalle del 5to préstamo" });
            //EndTermOn5Amount5:
            if (source.Amount5.IsNotEmpty() && source.EndTermOnAmount5.IsEmpty())
                result.Add(new Core.Contracts.General.Error() { Group = group, Key = "EndTermOnAmount5", Message = "Debe indicar el fin del plazo para el detalle del 5to préstamo" });

            return result;
        }

    }
}
