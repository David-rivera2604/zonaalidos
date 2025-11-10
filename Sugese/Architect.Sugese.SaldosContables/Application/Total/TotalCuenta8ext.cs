using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.Sugese.SaldosContables.Domain.Application.Total
{
    internal class TotalCuenta8ext
    {
        public static void Mapper(string account, Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModelo modelo, System.Nullable<decimal> value, bool specified)
        {
            if (modelo.cta_80000000000000 != null)
            {
                var current = modelo.cta_80000000000000;

                if (current.cta_80200000000000 != null && current.cta_80200000000000 != 0)
                    current.Total80000000000000 -= (Decimal)current.cta_80200000000000;

                if (current.cta_80400000000000 != null && current.cta_80400000000000 != 0)
                    current.Total80000000000000 -= (Decimal)current.cta_80400000000000;
            }
        }

    }
}
