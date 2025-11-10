using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.Sugese.SaldosContables.Domain.Mapper
{
    internal class MapeoCuenta8ext
    {
        public static void Mapper(string account, Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModelo modelo, System.Nullable<decimal> value, bool specified)
        {
            switch (account)
            {

                case "80200000000000":
                    if (modelo.cta_80000000000000 == null)
                        modelo.cta_80000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_80000000000000();
                    modelo.cta_80000000000000.cta_80200000000000 = value;
                    modelo.cta_80000000000000.cta_80200000000000Specified = specified;
                    break;
                case "80400000000000":
                    if (modelo.cta_80000000000000 == null)
                        modelo.cta_80000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_80000000000000();
                    modelo.cta_80000000000000.cta_80400000000000 = value;
                    modelo.cta_80000000000000.cta_80400000000000Specified = specified;
                    break;

            }
        }
    }
}
