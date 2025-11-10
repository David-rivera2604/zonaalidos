using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.Sugese.SaldosContables.Domain.Application.Total
{
    internal class TotalCuenta8
    {
        public static void Mapper(string account, Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModelo modelo, System.Nullable<decimal> value, bool specified)
        {

            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100500000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100500000.cta_80100100501000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100500000.cta_80100100501000;
                current.Total80100100501000 = 0;
                if (current.cta_80100100501010 != null)
                    current.Total80100100501000 += (Decimal)current.cta_80100100501010;
                if (current.cta_80100100501020 != null)
                    current.Total80100100501000 += (Decimal)current.cta_80100100501020;
                if (current.cta_80100100501030 != null)
                    current.Total80100100501000 += (Decimal)current.cta_80100100501030;
                if (current.cta_80100100501040 != null)
                    current.Total80100100501000 += (Decimal)current.cta_80100100501040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100500000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100500000.cta_80100100502000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100500000.cta_80100100502000;
                current.Total80100100502000 = 0;
                if (current.cta_80100100502010 != null)
                    current.Total80100100502000 += (Decimal)current.cta_80100100502010;
                if (current.cta_80100100502020 != null)
                    current.Total80100100502000 += (Decimal)current.cta_80100100502020;
                if (current.cta_80100100502030 != null)
                    current.Total80100100502000 += (Decimal)current.cta_80100100502030;
                if (current.cta_80100100502040 != null)
                    current.Total80100100502000 += (Decimal)current.cta_80100100502040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100500000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100500000;
                current.Total80100100500000 = 0;
                if (current.cta_80100100501000 != null && current.cta_80100100501000.Total80100100501000 != 0)
                    current.Total80100100500000 += (Decimal)current.cta_80100100501000.Total80100100501000;
                if (current.cta_80100100502000 != null && current.cta_80100100502000.Total80100100502000 != 0)
                    current.Total80100100500000 += (Decimal)current.cta_80100100502000.Total80100100502000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100600000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100600000.cta_80100100601000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100600000.cta_80100100601000;
                current.Total80100100601000 = 0;
                if (current.cta_80100100601010 != null)
                    current.Total80100100601000 += (Decimal)current.cta_80100100601010;
                if (current.cta_80100100601020 != null)
                    current.Total80100100601000 += (Decimal)current.cta_80100100601020;
                if (current.cta_80100100601030 != null)
                    current.Total80100100601000 += (Decimal)current.cta_80100100601030;
                if (current.cta_80100100601040 != null)
                    current.Total80100100601000 += (Decimal)current.cta_80100100601040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100600000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100600000.cta_80100100602000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100600000.cta_80100100602000;
                current.Total80100100602000 = 0;
                if (current.cta_80100100602010 != null)
                    current.Total80100100602000 += (Decimal)current.cta_80100100602010;
                if (current.cta_80100100602020 != null)
                    current.Total80100100602000 += (Decimal)current.cta_80100100602020;
                if (current.cta_80100100602030 != null)
                    current.Total80100100602000 += (Decimal)current.cta_80100100602030;
                if (current.cta_80100100602040 != null)
                    current.Total80100100602000 += (Decimal)current.cta_80100100602040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100600000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100600000;
                current.Total80100100600000 = 0;
                if (current.cta_80100100601000 != null && current.cta_80100100601000.Total80100100601000 != 0)
                    current.Total80100100600000 += (Decimal)current.cta_80100100601000.Total80100100601000;
                if (current.cta_80100100602000 != null && current.cta_80100100602000.Total80100100602000 != 0)
                    current.Total80100100600000 += (Decimal)current.cta_80100100602000.Total80100100602000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100700000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100700000.cta_80100100701000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100700000.cta_80100100701000;
                current.Total80100100701000 = 0;
                if (current.cta_80100100701010 != null)
                    current.Total80100100701000 += (Decimal)current.cta_80100100701010;
                if (current.cta_80100100701020 != null)
                    current.Total80100100701000 += (Decimal)current.cta_80100100701020;
                if (current.cta_80100100701030 != null)
                    current.Total80100100701000 += (Decimal)current.cta_80100100701030;
                if (current.cta_80100100701040 != null)
                    current.Total80100100701000 += (Decimal)current.cta_80100100701040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100700000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100700000.cta_80100100702000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100700000.cta_80100100702000;
                current.Total80100100702000 = 0;
                if (current.cta_80100100702010 != null)
                    current.Total80100100702000 += (Decimal)current.cta_80100100702010;
                if (current.cta_80100100702020 != null)
                    current.Total80100100702000 += (Decimal)current.cta_80100100702020;
                if (current.cta_80100100702030 != null)
                    current.Total80100100702000 += (Decimal)current.cta_80100100702030;
                if (current.cta_80100100702040 != null)
                    current.Total80100100702000 += (Decimal)current.cta_80100100702040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100700000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100700000;
                current.Total80100100700000 = 0;
                if (current.cta_80100100701000 != null && current.cta_80100100701000.Total80100100701000 != 0)
                    current.Total80100100700000 += (Decimal)current.cta_80100100701000.Total80100100701000;
                if (current.cta_80100100702000 != null && current.cta_80100100702000.Total80100100702000 != 0)
                    current.Total80100100700000 += (Decimal)current.cta_80100100702000.Total80100100702000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100800000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100800000.cta_80100100801000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100800000.cta_80100100801000;
                current.Total80100100801000 = 0;
                if (current.cta_80100100801010 != null)
                    current.Total80100100801000 += (Decimal)current.cta_80100100801010;
                if (current.cta_80100100801020 != null)
                    current.Total80100100801000 += (Decimal)current.cta_80100100801020;
                if (current.cta_80100100801030 != null)
                    current.Total80100100801000 += (Decimal)current.cta_80100100801030;
                if (current.cta_80100100801040 != null)
                    current.Total80100100801000 += (Decimal)current.cta_80100100801040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100800000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100800000.cta_80100100802000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100800000.cta_80100100802000;
                current.Total80100100802000 = 0;
                if (current.cta_80100100802010 != null)
                    current.Total80100100802000 += (Decimal)current.cta_80100100802010;
                if (current.cta_80100100802020 != null)
                    current.Total80100100802000 += (Decimal)current.cta_80100100802020;
                if (current.cta_80100100802030 != null)
                    current.Total80100100802000 += (Decimal)current.cta_80100100802030;
                if (current.cta_80100100802040 != null)
                    current.Total80100100802000 += (Decimal)current.cta_80100100802040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100800000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100800000;
                current.Total80100100800000 = 0;
                if (current.cta_80100100801000 != null && current.cta_80100100801000.Total80100100801000 != 0)
                    current.Total80100100800000 += (Decimal)current.cta_80100100801000.Total80100100801000;
                if (current.cta_80100100802000 != null && current.cta_80100100802000.Total80100100802000 != 0)
                    current.Total80100100800000 += (Decimal)current.cta_80100100802000.Total80100100802000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100900000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100900000.cta_80100100901000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100900000.cta_80100100901000;
                current.Total80100100901000 = 0;
                if (current.cta_80100100901010 != null)
                    current.Total80100100901000 += (Decimal)current.cta_80100100901010;
                if (current.cta_80100100901020 != null)
                    current.Total80100100901000 += (Decimal)current.cta_80100100901020;
                if (current.cta_80100100901030 != null)
                    current.Total80100100901000 += (Decimal)current.cta_80100100901030;
                if (current.cta_80100100901040 != null)
                    current.Total80100100901000 += (Decimal)current.cta_80100100901040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100900000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100900000.cta_80100100902000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100900000.cta_80100100902000;
                current.Total80100100902000 = 0;
                if (current.cta_80100100902010 != null)
                    current.Total80100100902000 += (Decimal)current.cta_80100100902010;
                if (current.cta_80100100902020 != null)
                    current.Total80100100902000 += (Decimal)current.cta_80100100902020;
                if (current.cta_80100100902030 != null)
                    current.Total80100100902000 += (Decimal)current.cta_80100100902030;
                if (current.cta_80100100902040 != null)
                    current.Total80100100902000 += (Decimal)current.cta_80100100902040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100900000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100100900000;
                current.Total80100100900000 = 0;
                if (current.cta_80100100901000 != null && current.cta_80100100901000.Total80100100901000 != 0)
                    current.Total80100100900000 += (Decimal)current.cta_80100100901000.Total80100100901000;
                if (current.cta_80100100902000 != null && current.cta_80100100902000.Total80100100902000 != 0)
                    current.Total80100100900000 += (Decimal)current.cta_80100100902000.Total80100100902000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101000000.cta_80100101001000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101000000.cta_80100101001000;
                current.Total80100101001000 = 0;
                if (current.cta_80100101001010 != null)
                    current.Total80100101001000 += (Decimal)current.cta_80100101001010;
                if (current.cta_80100101001020 != null)
                    current.Total80100101001000 += (Decimal)current.cta_80100101001020;
                if (current.cta_80100101001030 != null)
                    current.Total80100101001000 += (Decimal)current.cta_80100101001030;
                if (current.cta_80100101001040 != null)
                    current.Total80100101001000 += (Decimal)current.cta_80100101001040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101000000.cta_80100101002000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101000000.cta_80100101002000;
                current.Total80100101002000 = 0;
                if (current.cta_80100101002010 != null)
                    current.Total80100101002000 += (Decimal)current.cta_80100101002010;
                if (current.cta_80100101002020 != null)
                    current.Total80100101002000 += (Decimal)current.cta_80100101002020;
                if (current.cta_80100101002030 != null)
                    current.Total80100101002000 += (Decimal)current.cta_80100101002030;
                if (current.cta_80100101002040 != null)
                    current.Total80100101002000 += (Decimal)current.cta_80100101002040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101000000;
                current.Total80100101000000 = 0;
                if (current.cta_80100101001000 != null && current.cta_80100101001000.Total80100101001000 != 0)
                    current.Total80100101000000 += (Decimal)current.cta_80100101001000.Total80100101001000;
                if (current.cta_80100101002000 != null && current.cta_80100101002000.Total80100101002000 != 0)
                    current.Total80100101000000 += (Decimal)current.cta_80100101002000.Total80100101002000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101100000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101100000.cta_80100101101000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101100000.cta_80100101101000;
                current.Total80100101101000 = 0;
                if (current.cta_80100101101010 != null)
                    current.Total80100101101000 += (Decimal)current.cta_80100101101010;
                if (current.cta_80100101101020 != null)
                    current.Total80100101101000 += (Decimal)current.cta_80100101101020;
                if (current.cta_80100101101030 != null)
                    current.Total80100101101000 += (Decimal)current.cta_80100101101030;
                if (current.cta_80100101101040 != null)
                    current.Total80100101101000 += (Decimal)current.cta_80100101101040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101100000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101100000.cta_80100101102000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101100000.cta_80100101102000;
                current.Total80100101102000 = 0;
                if (current.cta_80100101102010 != null)
                    current.Total80100101102000 += (Decimal)current.cta_80100101102010;
                if (current.cta_80100101102020 != null)
                    current.Total80100101102000 += (Decimal)current.cta_80100101102020;
                if (current.cta_80100101102030 != null)
                    current.Total80100101102000 += (Decimal)current.cta_80100101102030;
                if (current.cta_80100101102040 != null)
                    current.Total80100101102000 += (Decimal)current.cta_80100101102040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101100000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101100000;
                current.Total80100101100000 = 0;
                if (current.cta_80100101101000 != null && current.cta_80100101101000.Total80100101101000 != 0)
                    current.Total80100101100000 += (Decimal)current.cta_80100101101000.Total80100101101000;
                if (current.cta_80100101102000 != null && current.cta_80100101102000.Total80100101102000 != 0)
                    current.Total80100101100000 += (Decimal)current.cta_80100101102000.Total80100101102000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101200000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101200000.cta_80100101201000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101200000.cta_80100101201000;
                current.Total80100101201000 = 0;
                if (current.cta_80100101201010 != null)
                    current.Total80100101201000 += (Decimal)current.cta_80100101201010;
                if (current.cta_80100101201020 != null)
                    current.Total80100101201000 += (Decimal)current.cta_80100101201020;
                if (current.cta_80100101201030 != null)
                    current.Total80100101201000 += (Decimal)current.cta_80100101201030;
                if (current.cta_80100101201040 != null)
                    current.Total80100101201000 += (Decimal)current.cta_80100101201040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101200000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101200000.cta_80100101202000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101200000.cta_80100101202000;
                current.Total80100101202000 = 0;
                if (current.cta_80100101202010 != null)
                    current.Total80100101202000 += (Decimal)current.cta_80100101202010;
                if (current.cta_80100101202020 != null)
                    current.Total80100101202000 += (Decimal)current.cta_80100101202020;
                if (current.cta_80100101202030 != null)
                    current.Total80100101202000 += (Decimal)current.cta_80100101202030;
                if (current.cta_80100101202040 != null)
                    current.Total80100101202000 += (Decimal)current.cta_80100101202040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101200000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000.cta_80100101200000;
                current.Total80100101200000 = 0;
                if (current.cta_80100101201000 != null && current.cta_80100101201000.Total80100101201000 != 0)
                    current.Total80100101200000 += (Decimal)current.cta_80100101201000.Total80100101201000;
                if (current.cta_80100101202000 != null && current.cta_80100101202000.Total80100101202000 != 0)
                    current.Total80100101200000 += (Decimal)current.cta_80100101202000.Total80100101202000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100100000000;
                current.Total80100100000000 = 0;
                if (current.cta_80100100500000 != null && current.cta_80100100500000.Total80100100500000 != 0)
                    current.Total80100100000000 += (Decimal)current.cta_80100100500000.Total80100100500000;
                if (current.cta_80100100600000 != null && current.cta_80100100600000.Total80100100600000 != 0)
                    current.Total80100100000000 += (Decimal)current.cta_80100100600000.Total80100100600000;
                if (current.cta_80100100700000 != null && current.cta_80100100700000.Total80100100700000 != 0)
                    current.Total80100100000000 += (Decimal)current.cta_80100100700000.Total80100100700000;
                if (current.cta_80100100800000 != null && current.cta_80100100800000.Total80100100800000 != 0)
                    current.Total80100100000000 += (Decimal)current.cta_80100100800000.Total80100100800000;
                if (current.cta_80100100900000 != null && current.cta_80100100900000.Total80100100900000 != 0)
                    current.Total80100100000000 += (Decimal)current.cta_80100100900000.Total80100100900000;
                if (current.cta_80100101000000 != null && current.cta_80100101000000.Total80100101000000 != 0)
                    current.Total80100100000000 += (Decimal)current.cta_80100101000000.Total80100101000000;
                if (current.cta_80100101100000 != null && current.cta_80100101100000.Total80100101100000 != 0)
                    current.Total80100100000000 += (Decimal)current.cta_80100101100000.Total80100101100000;
                if (current.cta_80100101200000 != null && current.cta_80100101200000.Total80100101200000 != 0)
                    current.Total80100100000000 += (Decimal)current.cta_80100101200000.Total80100101200000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100200000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100200000000.cta_80100200100000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100200000000.cta_80100200100000;
                current.Total80100200100000 = 0;
                if (current.cta_80100200101000 != null)
                    current.Total80100200100000 += (Decimal)current.cta_80100200101000;
                if (current.cta_80100200102000 != null)
                    current.Total80100200100000 += (Decimal)current.cta_80100200102000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100200000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100200000000.cta_80100200200000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100200000000.cta_80100200200000;
                current.Total80100200200000 = 0;
                if (current.cta_80100200201000 != null)
                    current.Total80100200200000 += (Decimal)current.cta_80100200201000;
                if (current.cta_80100200202000 != null)
                    current.Total80100200200000 += (Decimal)current.cta_80100200202000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100200000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100200000000.cta_80100200300000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100200000000.cta_80100200300000;
                current.Total80100200300000 = 0;
                if (current.cta_80100200301000 != null)
                    current.Total80100200300000 += (Decimal)current.cta_80100200301000;
                if (current.cta_80100200302000 != null)
                    current.Total80100200300000 += (Decimal)current.cta_80100200302000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100200000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100200000000.cta_80100209900000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100200000000.cta_80100209900000;
                current.Total80100209900000 = 0;
                if (current.cta_80100209901000 != null)
                    current.Total80100209900000 += (Decimal)current.cta_80100209901000;
                if (current.cta_80100209902000 != null)
                    current.Total80100209900000 += (Decimal)current.cta_80100209902000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100200000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100200000000;
                current.Total80100200000000 = 0;
                if (current.cta_80100200100000 != null && current.cta_80100200100000.Total80100200100000 != 0)
                    current.Total80100200000000 += (Decimal)current.cta_80100200100000.Total80100200100000;
                if (current.cta_80100200200000 != null && current.cta_80100200200000.Total80100200200000 != 0)
                    current.Total80100200000000 += (Decimal)current.cta_80100200200000.Total80100200200000;
                if (current.cta_80100200300000 != null && current.cta_80100200300000.Total80100200300000 != 0)
                    current.Total80100200000000 += (Decimal)current.cta_80100200300000.Total80100200300000;
                if (current.cta_80100209900000 != null && current.cta_80100209900000.Total80100209900000 != 0)
                    current.Total80100200000000 += (Decimal)current.cta_80100209900000.Total80100209900000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000.cta_80100300100000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000.cta_80100300100000;
                current.Total80100300100000 = 0;
                if (current.cta_80100300101000 != null)
                    current.Total80100300100000 += (Decimal)current.cta_80100300101000;
                if (current.cta_80100300102000 != null)
                    current.Total80100300100000 += (Decimal)current.cta_80100300102000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000.cta_80100300200000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000.cta_80100300200000;
                current.Total80100300200000 = 0;
                if (current.cta_80100300201000 != null)
                    current.Total80100300200000 += (Decimal)current.cta_80100300201000;
                if (current.cta_80100300202000 != null)
                    current.Total80100300200000 += (Decimal)current.cta_80100300202000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000.cta_80100300300000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000.cta_80100300300000;
                current.Total80100300300000 = 0;
                if (current.cta_80100300301000 != null)
                    current.Total80100300300000 += (Decimal)current.cta_80100300301000;
                if (current.cta_80100300302000 != null)
                    current.Total80100300300000 += (Decimal)current.cta_80100300302000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000.cta_80100300400000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000.cta_80100300400000;
                current.Total80100300400000 = 0;
                if (current.cta_80100300401000 != null)
                    current.Total80100300400000 += (Decimal)current.cta_80100300401000;
                if (current.cta_80100300402000 != null)
                    current.Total80100300400000 += (Decimal)current.cta_80100300402000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000.cta_80100300500000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000.cta_80100300500000;
                current.Total80100300500000 = 0;
                if (current.cta_80100300501000 != null)
                    current.Total80100300500000 += (Decimal)current.cta_80100300501000;
                if (current.cta_80100300502000 != null)
                    current.Total80100300500000 += (Decimal)current.cta_80100300502000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000.cta_80100309900000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000.cta_80100309900000;
                current.Total80100309900000 = 0;
                if (current.cta_80100309901000 != null)
                    current.Total80100309900000 += (Decimal)current.cta_80100309901000;
                if (current.cta_80100309902000 != null)
                    current.Total80100309900000 += (Decimal)current.cta_80100309902000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100300000000;
                current.Total80100300000000 = 0;
                if (current.cta_80100300100000 != null && current.cta_80100300100000.Total80100300100000 != 0)
                    current.Total80100300000000 += (Decimal)current.cta_80100300100000.Total80100300100000;
                if (current.cta_80100300200000 != null && current.cta_80100300200000.Total80100300200000 != 0)
                    current.Total80100300000000 += (Decimal)current.cta_80100300200000.Total80100300200000;
                if (current.cta_80100300300000 != null && current.cta_80100300300000.Total80100300300000 != 0)
                    current.Total80100300000000 += (Decimal)current.cta_80100300300000.Total80100300300000;
                if (current.cta_80100300400000 != null && current.cta_80100300400000.Total80100300400000 != 0)
                    current.Total80100300000000 += (Decimal)current.cta_80100300400000.Total80100300400000;
                if (current.cta_80100300500000 != null && current.cta_80100300500000.Total80100300500000 != 0)
                    current.Total80100300000000 += (Decimal)current.cta_80100300500000.Total80100300500000;
                if (current.cta_80100309900000 != null && current.cta_80100309900000.Total80100309900000 != 0)
                    current.Total80100300000000 += (Decimal)current.cta_80100309900000.Total80100309900000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100500000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100500000000.cta_80100500200000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100500000000.cta_80100500200000;
                current.Total80100500200000 = 0;
                if (current.cta_80100500201000 != null)
                    current.Total80100500200000 += (Decimal)current.cta_80100500201000;
                if (current.cta_80100500202000 != null)
                    current.Total80100500200000 += (Decimal)current.cta_80100500202000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100500000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100500000000.cta_80100500300000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100500000000.cta_80100500300000;
                current.Total80100500300000 = 0;
                if (current.cta_80100500301000 != null)
                    current.Total80100500300000 += (Decimal)current.cta_80100500301000;
                if (current.cta_80100500302000 != null)
                    current.Total80100500300000 += (Decimal)current.cta_80100500302000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100500000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100500000000.cta_80100500400000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100500000000.cta_80100500400000;
                current.Total80100500400000 = 0;
                if (current.cta_80100500401000 != null)
                    current.Total80100500400000 += (Decimal)current.cta_80100500401000;
                if (current.cta_80100500402000 != null)
                    current.Total80100500400000 += (Decimal)current.cta_80100500402000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100500000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100500000000;
                current.Total80100500000000 = 0;
                if (current.cta_80100500200000 != null && current.cta_80100500200000.Total80100500200000 != 0)
                    current.Total80100500000000 += (Decimal)current.cta_80100500200000.Total80100500200000;
                if (current.cta_80100500300000 != null && current.cta_80100500300000.Total80100500300000 != 0)
                    current.Total80100500000000 += (Decimal)current.cta_80100500300000.Total80100500300000;
                if (current.cta_80100500400000 != null && current.cta_80100500400000.Total80100500400000 != 0)
                    current.Total80100500000000 += (Decimal)current.cta_80100500400000.Total80100500400000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100600000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100600000000.cta_80100600200000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100600000000.cta_80100600200000;
                current.Total80100600200000 = 0;
                if (current.cta_80100600201000 != null)
                    current.Total80100600200000 += (Decimal)current.cta_80100600201000;
                if (current.cta_80100600202000 != null)
                    current.Total80100600200000 += (Decimal)current.cta_80100600202000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100600000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100600000000.cta_80100600300000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100600000000.cta_80100600300000;
                current.Total80100600300000 = 0;
                if (current.cta_80100600301000 != null)
                    current.Total80100600300000 += (Decimal)current.cta_80100600301000;
                if (current.cta_80100600302000 != null)
                    current.Total80100600300000 += (Decimal)current.cta_80100600302000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100600000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100600000000;
                current.Total80100600000000 = 0;
                if (current.cta_80100600200000 != null && current.cta_80100600200000.Total80100600200000 != 0)
                    current.Total80100600000000 += (Decimal)current.cta_80100600200000.Total80100600200000;
                if (current.cta_80100600300000 != null && current.cta_80100600300000.Total80100600300000 != 0)
                    current.Total80100600000000 += (Decimal)current.cta_80100600300000.Total80100600300000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100700000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100700000000.cta_80100700100000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100700000000.cta_80100700100000;
                current.Total80100700100000 = 0;
                if (current.cta_80100700101000 != null)
                    current.Total80100700100000 += (Decimal)current.cta_80100700101000;
                if (current.cta_80100700102000 != null)
                    current.Total80100700100000 += (Decimal)current.cta_80100700102000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100700000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100700000000.cta_80100700200000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100700000000.cta_80100700200000;
                current.Total80100700200000 = 0;
                if (current.cta_80100700201000 != null)
                    current.Total80100700200000 += (Decimal)current.cta_80100700201000;
                if (current.cta_80100700202000 != null)
                    current.Total80100700200000 += (Decimal)current.cta_80100700202000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100700000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100700000000;
                current.Total80100700000000 = 0;
                if (current.cta_80100700100000 != null && current.cta_80100700100000.Total80100700100000 != 0)
                    current.Total80100700000000 += (Decimal)current.cta_80100700100000.Total80100700100000;
                if (current.cta_80100700200000 != null && current.cta_80100700200000.Total80100700200000 != 0)
                    current.Total80100700000000 += (Decimal)current.cta_80100700200000.Total80100700200000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900100000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900100000.cta_80100900101000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900100000.cta_80100900101000;
                current.Total80100900101000 = 0;
                if (current.cta_80100900101010 != null)
                    current.Total80100900101000 += (Decimal)current.cta_80100900101010;
                if (current.cta_80100900101020 != null)
                    current.Total80100900101000 += (Decimal)current.cta_80100900101020;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900100000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900100000.cta_80100900102000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900100000.cta_80100900102000;
                current.Total80100900102000 = 0;
                if (current.cta_80100900102010 != null)
                    current.Total80100900102000 += (Decimal)current.cta_80100900102010;
                if (current.cta_80100900102020 != null)
                    current.Total80100900102000 += (Decimal)current.cta_80100900102020;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900100000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900100000;
                current.Total80100900100000 = 0;
                if (current.cta_80100900101000 != null && current.cta_80100900101000.Total80100900101000 != 0)
                    current.Total80100900100000 += (Decimal)current.cta_80100900101000.Total80100900101000;
                if (current.cta_80100900102000 != null && current.cta_80100900102000.Total80100900102000 != 0)
                    current.Total80100900100000 += (Decimal)current.cta_80100900102000.Total80100900102000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900200000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900200000.cta_80100900201000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900200000.cta_80100900201000;
                current.Total80100900201000 = 0;
                if (current.cta_80100900201010 != null)
                    current.Total80100900201000 += (Decimal)current.cta_80100900201010;
                if (current.cta_80100900201020 != null)
                    current.Total80100900201000 += (Decimal)current.cta_80100900201020;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900200000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900200000.cta_80100900202000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900200000.cta_80100900202000;
                current.Total80100900202000 = 0;
                if (current.cta_80100900202010 != null)
                    current.Total80100900202000 += (Decimal)current.cta_80100900202010;
                if (current.cta_80100900202020 != null)
                    current.Total80100900202000 += (Decimal)current.cta_80100900202020;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900200000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900200000;
                current.Total80100900200000 = 0;
                if (current.cta_80100900201000 != null && current.cta_80100900201000.Total80100900201000 != 0)
                    current.Total80100900200000 += (Decimal)current.cta_80100900201000.Total80100900201000;
                if (current.cta_80100900202000 != null && current.cta_80100900202000.Total80100900202000 != 0)
                    current.Total80100900200000 += (Decimal)current.cta_80100900202000.Total80100900202000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900300000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900300000.cta_80100900301000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900300000.cta_80100900301000;
                current.Total80100900301000 = 0;
                if (current.cta_80100900301010 != null)
                    current.Total80100900301000 += (Decimal)current.cta_80100900301010;
                if (current.cta_80100900301020 != null)
                    current.Total80100900301000 += (Decimal)current.cta_80100900301020;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900300000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900300000.cta_80100900302000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900300000.cta_80100900302000;
                current.Total80100900302000 = 0;
                if (current.cta_80100900302010 != null)
                    current.Total80100900302000 += (Decimal)current.cta_80100900302010;
                if (current.cta_80100900302020 != null)
                    current.Total80100900302000 += (Decimal)current.cta_80100900302020;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900300000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900300000;
                current.Total80100900300000 = 0;
                if (current.cta_80100900301000 != null && current.cta_80100900301000.Total80100900301000 != 0)
                    current.Total80100900300000 += (Decimal)current.cta_80100900301000.Total80100900301000;
                if (current.cta_80100900302000 != null && current.cta_80100900302000.Total80100900302000 != 0)
                    current.Total80100900300000 += (Decimal)current.cta_80100900302000.Total80100900302000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900400000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900400000.cta_80100900401000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900400000.cta_80100900401000;
                current.Total80100900401000 = 0;
                if (current.cta_80100900401010 != null)
                    current.Total80100900401000 += (Decimal)current.cta_80100900401010;
                if (current.cta_80100900401020 != null)
                    current.Total80100900401000 += (Decimal)current.cta_80100900401020;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900400000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900400000.cta_80100900402000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900400000.cta_80100900402000;
                current.Total80100900402000 = 0;
                if (current.cta_80100900402010 != null)
                    current.Total80100900402000 += (Decimal)current.cta_80100900402010;
                if (current.cta_80100900402020 != null)
                    current.Total80100900402000 += (Decimal)current.cta_80100900402020;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900400000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900400000;
                current.Total80100900400000 = 0;
                if (current.cta_80100900401000 != null && current.cta_80100900401000.Total80100900401000 != 0)
                    current.Total80100900400000 += (Decimal)current.cta_80100900401000.Total80100900401000;
                if (current.cta_80100900402000 != null && current.cta_80100900402000.Total80100900402000 != 0)
                    current.Total80100900400000 += (Decimal)current.cta_80100900402000.Total80100900402000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900500000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900500000.cta_80100900501000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900500000.cta_80100900501000;
                current.Total80100900501000 = 0;
                if (current.cta_80100900501010 != null)
                    current.Total80100900501000 += (Decimal)current.cta_80100900501010;
                if (current.cta_80100900501020 != null)
                    current.Total80100900501000 += (Decimal)current.cta_80100900501020;
                if (current.cta_80100900501030 != null)
                    current.Total80100900501000 += (Decimal)current.cta_80100900501030;
                if (current.cta_80100900501040 != null)
                    current.Total80100900501000 += (Decimal)current.cta_80100900501040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900500000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900500000.cta_80100900502000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900500000.cta_80100900502000;
                current.Total80100900502000 = 0;
                if (current.cta_80100900502010 != null)
                    current.Total80100900502000 += (Decimal)current.cta_80100900502010;
                if (current.cta_80100900502020 != null)
                    current.Total80100900502000 += (Decimal)current.cta_80100900502020;
                if (current.cta_80100900502030 != null)
                    current.Total80100900502000 += (Decimal)current.cta_80100900502030;
                if (current.cta_80100900502040 != null)
                    current.Total80100900502000 += (Decimal)current.cta_80100900502040;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900500000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900500000;
                current.Total80100900500000 = 0;
                if (current.cta_80100900501000 != null && current.cta_80100900501000.Total80100900501000 != 0)
                    current.Total80100900500000 += (Decimal)current.cta_80100900501000.Total80100900501000;
                if (current.cta_80100900502000 != null && current.cta_80100900502000.Total80100900502000 != 0)
                    current.Total80100900500000 += (Decimal)current.cta_80100900502000.Total80100900502000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900600000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900600000.cta_80100900601000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900600000.cta_80100900601000;
                current.Total80100900601000 = 0;
                if (current.cta_80100900601010 != null)
                    current.Total80100900601000 += (Decimal)current.cta_80100900601010;
                if (current.cta_80100900601020 != null)
                    current.Total80100900601000 += (Decimal)current.cta_80100900601020;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900600000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900600000.cta_80100900602000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900600000.cta_80100900602000;
                current.Total80100900602000 = 0;
                if (current.cta_80100900602010 != null)
                    current.Total80100900602000 += (Decimal)current.cta_80100900602010;
                if (current.cta_80100900602020 != null)
                    current.Total80100900602000 += (Decimal)current.cta_80100900602020;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900600000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000.cta_80100900600000;
                current.Total80100900600000 = 0;
                if (current.cta_80100900601000 != null && current.cta_80100900601000.Total80100900601000 != 0)
                    current.Total80100900600000 += (Decimal)current.cta_80100900601000.Total80100900601000;
                if (current.cta_80100900602000 != null && current.cta_80100900602000.Total80100900602000 != 0)
                    current.Total80100900600000 += (Decimal)current.cta_80100900602000.Total80100900602000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80100900000000;
                current.Total80100900000000 = 0;
                if (current.cta_80100900100000 != null && current.cta_80100900100000.Total80100900100000 != 0)
                    current.Total80100900000000 += (Decimal)current.cta_80100900100000.Total80100900100000;
                if (current.cta_80100900200000 != null && current.cta_80100900200000.Total80100900200000 != 0)
                    current.Total80100900000000 += (Decimal)current.cta_80100900200000.Total80100900200000;
                if (current.cta_80100900300000 != null && current.cta_80100900300000.Total80100900300000 != 0)
                    current.Total80100900000000 += (Decimal)current.cta_80100900300000.Total80100900300000;
                if (current.cta_80100900400000 != null && current.cta_80100900400000.Total80100900400000 != 0)
                    current.Total80100900000000 += (Decimal)current.cta_80100900400000.Total80100900400000;
                if (current.cta_80100900500000 != null && current.cta_80100900500000.Total80100900500000 != 0)
                    current.Total80100900000000 += (Decimal)current.cta_80100900500000.Total80100900500000;
                if (current.cta_80100900600000 != null && current.cta_80100900600000.Total80100900600000 != 0)
                    current.Total80100900000000 += (Decimal)current.cta_80100900600000.Total80100900600000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101000300000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101000300000;
                current.Total80101000300000 = 0;
                if (current.cta_80101000301000 != null)
                    current.Total80101000300000 += (Decimal)current.cta_80101000301000;
                if (current.cta_80101000302000 != null)
                    current.Total80101000300000 += (Decimal)current.cta_80101000302000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101000400000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101000400000;
                current.Total80101000400000 = 0;
                if (current.cta_80101000401000 != null)
                    current.Total80101000400000 += (Decimal)current.cta_80101000401000;
                if (current.cta_80101000402000 != null)
                    current.Total80101000400000 += (Decimal)current.cta_80101000402000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101000500000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101000500000.cta_80101000501000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101000500000.cta_80101000501000;
                current.Total80101000501000 = 0;
                if (current.cta_80101000501010 != null)
                    current.Total80101000501000 += (Decimal)current.cta_80101000501010;
                if (current.cta_80101000501020 != null)
                    current.Total80101000501000 += (Decimal)current.cta_80101000501020;
                if (current.cta_80101000501030 != null)
                    current.Total80101000501000 += (Decimal)current.cta_80101000501030;
                if (current.cta_80101000501040 != null)
                    current.Total80101000501000 += (Decimal)current.cta_80101000501040;
                if (current.cta_80101000501050 != null)
                    current.Total80101000501000 += (Decimal)current.cta_80101000501050;
                if (current.cta_80101000501060 != null)
                    current.Total80101000501000 += (Decimal)current.cta_80101000501060;
                if (current.cta_80101000501150 != null)
                    current.Total80101000501000 += (Decimal)current.cta_80101000501150;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101000500000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101000500000.cta_80101000502000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101000500000.cta_80101000502000;
                current.Total80101000502000 = 0;
                if (current.cta_80101000502010 != null)
                    current.Total80101000502000 += (Decimal)current.cta_80101000502010;
                if (current.cta_80101000502020 != null)
                    current.Total80101000502000 += (Decimal)current.cta_80101000502020;
                if (current.cta_80101000502030 != null)
                    current.Total80101000502000 += (Decimal)current.cta_80101000502030;
                if (current.cta_80101000502040 != null)
                    current.Total80101000502000 += (Decimal)current.cta_80101000502040;
                if (current.cta_80101000502050 != null)
                    current.Total80101000502000 += (Decimal)current.cta_80101000502050;
                if (current.cta_80101000502060 != null)
                    current.Total80101000502000 += (Decimal)current.cta_80101000502060;
                if (current.cta_80101000502150 != null)
                    current.Total80101000502000 += (Decimal)current.cta_80101000502150;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101000500000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101000500000;
                current.Total80101000500000 = 0;
                if (current.cta_80101000501000 != null && current.cta_80101000501000.Total80101000501000 != 0)
                    current.Total80101000500000 += (Decimal)current.cta_80101000501000.Total80101000501000;
                if (current.cta_80101000502000 != null && current.cta_80101000502000.Total80101000502000 != 0)
                    current.Total80101000500000 += (Decimal)current.cta_80101000502000.Total80101000502000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101000800000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101000800000;
                current.Total80101000800000 = 0;
                if (current.cta_80101000801000 != null)
                    current.Total80101000800000 += (Decimal)current.cta_80101000801000;
                if (current.cta_80101000802000 != null)
                    current.Total80101000800000 += (Decimal)current.cta_80101000802000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001000000;
                current.Total80101001000000 = 0;
                if (current.cta_80101001001000 != null)
                    current.Total80101001000000 += (Decimal)current.cta_80101001001000;
                if (current.cta_80101001002000 != null)
                    current.Total80101001000000 += (Decimal)current.cta_80101001002000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001100000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001100000.cta_80101001101000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001100000.cta_80101001101000;
                current.Total80101001101000 = 0;
                if (current.cta_80101001101010 != null)
                    current.Total80101001101000 += (Decimal)current.cta_80101001101010;
                if (current.cta_80101001101020 != null)
                    current.Total80101001101000 += (Decimal)current.cta_80101001101020;
                if (current.cta_80101001101030 != null)
                    current.Total80101001101000 += (Decimal)current.cta_80101001101030;
                if (current.cta_80101001101040 != null)
                    current.Total80101001101000 += (Decimal)current.cta_80101001101040;
                if (current.cta_80101001101050 != null)
                    current.Total80101001101000 += (Decimal)current.cta_80101001101050;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001100000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001100000.cta_80101001102000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001100000.cta_80101001102000;
                current.Total80101001102000 = 0;
                if (current.cta_80101001102010 != null)
                    current.Total80101001102000 += (Decimal)current.cta_80101001102010;
                if (current.cta_80101001102020 != null)
                    current.Total80101001102000 += (Decimal)current.cta_80101001102020;
                if (current.cta_80101001102030 != null)
                    current.Total80101001102000 += (Decimal)current.cta_80101001102030;
                if (current.cta_80101001102040 != null)
                    current.Total80101001102000 += (Decimal)current.cta_80101001102040;
                if (current.cta_80101001102050 != null)
                    current.Total80101001102000 += (Decimal)current.cta_80101001102050;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001100000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001100000;
                current.Total80101001100000 = 0;
                if (current.cta_80101001101000 != null && current.cta_80101001101000.Total80101001101000 != 0)
                    current.Total80101001100000 += (Decimal)current.cta_80101001101000.Total80101001101000;
                if (current.cta_80101001102000 != null && current.cta_80101001102000.Total80101001102000 != 0)
                    current.Total80101001100000 += (Decimal)current.cta_80101001102000.Total80101001102000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001400000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001400000.cta_80101001401000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001400000.cta_80101001401000;
                current.Total80101001401000 = 0;
                if (current.cta_80101001401010 != null)
                    current.Total80101001401000 += (Decimal)current.cta_80101001401010;
                if (current.cta_80101001401020 != null)
                    current.Total80101001401000 += (Decimal)current.cta_80101001401020;
                if (current.cta_80101001401040 != null)
                    current.Total80101001401000 += (Decimal)current.cta_80101001401040;
                if (current.cta_80101001401050 != null)
                    current.Total80101001401000 += (Decimal)current.cta_80101001401050;
                if (current.cta_80101001401990 != null)
                    current.Total80101001401000 += (Decimal)current.cta_80101001401990;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001400000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001400000.cta_80101001402000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001400000.cta_80101001402000;
                current.Total80101001402000 = 0;
                if (current.cta_80101001402010 != null)
                    current.Total80101001402000 += (Decimal)current.cta_80101001402010;
                if (current.cta_80101001402020 != null)
                    current.Total80101001402000 += (Decimal)current.cta_80101001402020;
                if (current.cta_80101001402040 != null)
                    current.Total80101001402000 += (Decimal)current.cta_80101001402040;
                if (current.cta_80101001402050 != null)
                    current.Total80101001402000 += (Decimal)current.cta_80101001402050;
                if (current.cta_80101001402990 != null)
                    current.Total80101001402000 += (Decimal)current.cta_80101001402990;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001400000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001400000;
                current.Total80101001400000 = 0;
                if (current.cta_80101001401000 != null && current.cta_80101001401000.Total80101001401000 != 0)
                    current.Total80101001400000 += (Decimal)current.cta_80101001401000.Total80101001401000;
                if (current.cta_80101001402000 != null && current.cta_80101001402000.Total80101001402000 != 0)
                    current.Total80101001400000 += (Decimal)current.cta_80101001402000.Total80101001402000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001500000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001500000.cta_80101001501000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001500000.cta_80101001501000;
                current.Total80101001501000 = 0;
                if (current.cta_80101001501010 != null)
                    current.Total80101001501000 += (Decimal)current.cta_80101001501010;
                if (current.cta_80101001501020 != null)
                    current.Total80101001501000 += (Decimal)current.cta_80101001501020;
                if (current.cta_80101001501030 != null)
                    current.Total80101001501000 += (Decimal)current.cta_80101001501030;
                if (current.cta_80101001501040 != null)
                    current.Total80101001501000 += (Decimal)current.cta_80101001501040;
                if (current.cta_80101001501990 != null)
                    current.Total80101001501000 += (Decimal)current.cta_80101001501990;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001500000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001500000.cta_80101001502000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001500000.cta_80101001502000;
                current.Total80101001502000 = 0;
                if (current.cta_80101001502010 != null)
                    current.Total80101001502000 += (Decimal)current.cta_80101001502010;
                if (current.cta_80101001502020 != null)
                    current.Total80101001502000 += (Decimal)current.cta_80101001502020;
                if (current.cta_80101001502030 != null)
                    current.Total80101001502000 += (Decimal)current.cta_80101001502030;
                if (current.cta_80101001502040 != null)
                    current.Total80101001502000 += (Decimal)current.cta_80101001502040;
                if (current.cta_80101001502990 != null)
                    current.Total80101001502000 += (Decimal)current.cta_80101001502990;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001500000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101001500000;
                current.Total80101001500000 = 0;
                if (current.cta_80101001501000 != null && current.cta_80101001501000.Total80101001501000 != 0)
                    current.Total80101001500000 += (Decimal)current.cta_80101001501000.Total80101001501000;
                if (current.cta_80101001502000 != null && current.cta_80101001502000.Total80101001502000 != 0)
                    current.Total80101001500000 += (Decimal)current.cta_80101001502000.Total80101001502000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101002000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101002000000.cta_80101002001000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101002000000.cta_80101002001000;
                current.Total80101002001000 = 0;
                if (current.cta_80101002001010 != null)
                    current.Total80101002001000 += (Decimal)current.cta_80101002001010;
                if (current.cta_80101002001030 != null)
                    current.Total80101002001000 += (Decimal)current.cta_80101002001030;
                if (current.cta_80101002001040 != null)
                    current.Total80101002001000 += (Decimal)current.cta_80101002001040;
                if (current.cta_80101002001990 != null)
                    current.Total80101002001000 += (Decimal)current.cta_80101002001990;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101002000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101002000000.cta_80101002002000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101002000000.cta_80101002002000;
                current.Total80101002002000 = 0;
                if (current.cta_80101002002010 != null)
                    current.Total80101002002000 += (Decimal)current.cta_80101002002010;
                if (current.cta_80101002002030 != null)
                    current.Total80101002002000 += (Decimal)current.cta_80101002002030;
                if (current.cta_80101002002040 != null)
                    current.Total80101002002000 += (Decimal)current.cta_80101002002040;
                if (current.cta_80101002002990 != null)
                    current.Total80101002002000 += (Decimal)current.cta_80101002002990;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101002000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101002000000;
                current.Total80101002000000 = 0;
                if (current.cta_80101002001000 != null && current.cta_80101002001000.Total80101002001000 != 0)
                    current.Total80101002000000 += (Decimal)current.cta_80101002001000.Total80101002001000;
                if (current.cta_80101002002000 != null && current.cta_80101002002000.Total80101002002000 != 0)
                    current.Total80101002000000 += (Decimal)current.cta_80101002002000.Total80101002002000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101003000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101003000000.cta_80101003001000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101003000000.cta_80101003001000;
                current.Total80101003001000 = 0;
                if (current.cta_80101003001010 != null)
                    current.Total80101003001000 += (Decimal)current.cta_80101003001010;
                if (current.cta_80101003001020 != null)
                    current.Total80101003001000 += (Decimal)current.cta_80101003001020;
                if (current.cta_80101003001030 != null)
                    current.Total80101003001000 += (Decimal)current.cta_80101003001030;
                if (current.cta_80101003001990 != null)
                    current.Total80101003001000 += (Decimal)current.cta_80101003001990;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101003000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101003000000.cta_80101003002000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101003000000.cta_80101003002000;
                current.Total80101003002000 = 0;
                if (current.cta_80101003002010 != null)
                    current.Total80101003002000 += (Decimal)current.cta_80101003002010;
                if (current.cta_80101003002020 != null)
                    current.Total80101003002000 += (Decimal)current.cta_80101003002020;
                if (current.cta_80101003002030 != null)
                    current.Total80101003002000 += (Decimal)current.cta_80101003002030;
                if (current.cta_80101003002990 != null)
                    current.Total80101003002000 += (Decimal)current.cta_80101003002990;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101003000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101003000000;
                current.Total80101003000000 = 0;
                if (current.cta_80101003001000 != null && current.cta_80101003001000.Total80101003001000 != 0)
                    current.Total80101003000000 += (Decimal)current.cta_80101003001000.Total80101003001000;
                if (current.cta_80101003002000 != null && current.cta_80101003002000.Total80101003002000 != 0)
                    current.Total80101003000000 += (Decimal)current.cta_80101003002000.Total80101003002000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101005000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101005000000.cta_80101005001000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101005000000.cta_80101005001000;
                current.Total80101005001000 = 0;
                if (current.cta_80101005001010 != null)
                    current.Total80101005001000 += (Decimal)current.cta_80101005001010;
                if (current.cta_80101005001020 != null)
                    current.Total80101005001000 += (Decimal)current.cta_80101005001020;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101005000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101005000000.cta_80101005002000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101005000000.cta_80101005002000;
                current.Total80101005002000 = 0;
                if (current.cta_80101005002010 != null)
                    current.Total80101005002000 += (Decimal)current.cta_80101005002010;
                if (current.cta_80101005002020 != null)
                    current.Total80101005002000 += (Decimal)current.cta_80101005002020;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101005000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101005000000;
                current.Total80101005000000 = 0;
                if (current.cta_80101005001000 != null && current.cta_80101005001000.Total80101005001000 != 0)
                    current.Total80101005000000 += (Decimal)current.cta_80101005001000.Total80101005001000;
                if (current.cta_80101005002000 != null && current.cta_80101005002000.Total80101005002000 != 0)
                    current.Total80101005000000 += (Decimal)current.cta_80101005002000.Total80101005002000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101009900000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000.cta_80101009900000;
                current.Total80101009900000 = 0;
                if (current.cta_80101009901000 != null)
                    current.Total80101009900000 += (Decimal)current.cta_80101009901000;
                if (current.cta_80101009902000 != null)
                    current.Total80101009900000 += (Decimal)current.cta_80101009902000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null && modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000.cta_80101000000000;
                current.Total80101000000000 = 0;
                if (current.cta_80101000300000 != null && current.cta_80101000300000.Total80101000300000 != 0)
                    current.Total80101000000000 += (Decimal)current.cta_80101000300000.Total80101000300000;
                if (current.cta_80101000400000 != null && current.cta_80101000400000.Total80101000400000 != 0)
                    current.Total80101000000000 += (Decimal)current.cta_80101000400000.Total80101000400000;
                if (current.cta_80101000500000 != null && current.cta_80101000500000.Total80101000500000 != 0)
                    current.Total80101000000000 += (Decimal)current.cta_80101000500000.Total80101000500000;
                if (current.cta_80101000800000 != null && current.cta_80101000800000.Total80101000800000 != 0)
                    current.Total80101000000000 += (Decimal)current.cta_80101000800000.Total80101000800000;
                if (current.cta_80101001000000 != null && current.cta_80101001000000.Total80101001000000 != 0)
                    current.Total80101000000000 += (Decimal)current.cta_80101001000000.Total80101001000000;
                if (current.cta_80101001100000 != null && current.cta_80101001100000.Total80101001100000 != 0)
                    current.Total80101000000000 += (Decimal)current.cta_80101001100000.Total80101001100000;
                if (current.cta_80101001400000 != null && current.cta_80101001400000.Total80101001400000 != 0)
                    current.Total80101000000000 += (Decimal)current.cta_80101001400000.Total80101001400000;
                if (current.cta_80101001500000 != null && current.cta_80101001500000.Total80101001500000 != 0)
                    current.Total80101000000000 += (Decimal)current.cta_80101001500000.Total80101001500000;
                if (current.cta_80101002000000 != null && current.cta_80101002000000.Total80101002000000 != 0)
                    current.Total80101000000000 += (Decimal)current.cta_80101002000000.Total80101002000000;
                if (current.cta_80101003000000 != null && current.cta_80101003000000.Total80101003000000 != 0)
                    current.Total80101000000000 += (Decimal)current.cta_80101003000000.Total80101003000000;
                if (current.cta_80101005000000 != null && current.cta_80101005000000.Total80101005000000 != 0)
                    current.Total80101000000000 += (Decimal)current.cta_80101005000000.Total80101005000000;
                if (current.cta_80101009900000 != null && current.cta_80101009900000.Total80101009900000 != 0)
                    current.Total80101000000000 += (Decimal)current.cta_80101009900000.Total80101009900000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80100000000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80100000000000;
                current.Total80100000000000 = 0;
                if (current.cta_80100100000000 != null && current.cta_80100100000000.Total80100100000000 != 0)
                    current.Total80100000000000 += (Decimal)current.cta_80100100000000.Total80100100000000;
                if (current.cta_80100200000000 != null && current.cta_80100200000000.Total80100200000000 != 0)
                    current.Total80100000000000 += (Decimal)current.cta_80100200000000.Total80100200000000;
                if (current.cta_80100300000000 != null && current.cta_80100300000000.Total80100300000000 != 0)
                    current.Total80100000000000 += (Decimal)current.cta_80100300000000.Total80100300000000;
                if (current.cta_80100500000000 != null && current.cta_80100500000000.Total80100500000000 != 0)
                    current.Total80100000000000 += (Decimal)current.cta_80100500000000.Total80100500000000;
                if (current.cta_80100600000000 != null && current.cta_80100600000000.Total80100600000000 != 0)
                    current.Total80100000000000 += (Decimal)current.cta_80100600000000.Total80100600000000;
                if (current.cta_80100700000000 != null && current.cta_80100700000000.Total80100700000000 != 0)
                    current.Total80100000000000 += (Decimal)current.cta_80100700000000.Total80100700000000;
                if (current.cta_80100900000000 != null && current.cta_80100900000000.Total80100900000000 != 0)
                    current.Total80100000000000 += (Decimal)current.cta_80100900000000.Total80100900000000;
                if (current.cta_80101000000000 != null && current.cta_80101000000000.Total80101000000000 != 0)
                    current.Total80100000000000 += (Decimal)current.cta_80101000000000.Total80101000000000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80300000000000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300100000000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300100000000.cta_80300100200000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300100000000.cta_80300100200000.cta_80300100201000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80300000000000.cta_80300100000000.cta_80300100200000.cta_80300100201000;
                current.Total80300100201000 = 0;
                if (current.cta_80300100201010 != null)
                    current.Total80300100201000 += (Decimal)current.cta_80300100201010;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80300000000000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300100000000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300100000000.cta_80300100200000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300100000000.cta_80300100200000.cta_80300100202000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80300000000000.cta_80300100000000.cta_80300100200000.cta_80300100202000;
                current.Total80300100202000 = 0;
                if (current.cta_80300100202010 != null)
                    current.Total80300100202000 += (Decimal)current.cta_80300100202010;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80300000000000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300100000000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300100000000.cta_80300100200000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80300000000000.cta_80300100000000.cta_80300100200000;
                current.Total80300100200000 = 0;
                if (current.cta_80300100201000 != null && current.cta_80300100201000.Total80300100201000 != 0)
                    current.Total80300100200000 += (Decimal)current.cta_80300100201000.Total80300100201000;
                if (current.cta_80300100202000 != null && current.cta_80300100202000.Total80300100202000 != 0)
                    current.Total80300100200000 += (Decimal)current.cta_80300100202000.Total80300100202000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80300000000000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300100000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80300000000000.cta_80300100000000;
                current.Total80300100000000 = 0;
                if (current.cta_80300100200000 != null && current.cta_80300100200000.Total80300100200000 != 0)
                    current.Total80300100000000 += (Decimal)current.cta_80300100200000.Total80300100200000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80300000000000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300200000000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300200000000.cta_80300200100000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300200000000.cta_80300200100000.cta_80300200101000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80300000000000.cta_80300200000000.cta_80300200100000.cta_80300200101000;
                current.Total80300200101000 = 0;
                if (current.cta_80300200101050 != null)
                    current.Total80300200101000 += (Decimal)current.cta_80300200101050;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80300000000000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300200000000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300200000000.cta_80300200100000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80300000000000.cta_80300200000000.cta_80300200100000;
                current.Total80300200100000 = 0;
                if (current.cta_80300200101000 != null && current.cta_80300200101000.Total80300200101000 != 0)
                    current.Total80300200100000 += (Decimal)current.cta_80300200101000.Total80300200101000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80300000000000 != null && modelo.cta_80000000000000.cta_80300000000000.cta_80300200000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80300000000000.cta_80300200000000;
                current.Total80300200000000 = 0;
                if (current.cta_80300200100000 != null && current.cta_80300200100000.Total80300200100000 != 0)
                    current.Total80300200000000 += (Decimal)current.cta_80300200100000.Total80300200100000;
            }
            if (modelo.cta_80000000000000 != null && modelo.cta_80000000000000.cta_80300000000000 != null)
            {
                var current = modelo.cta_80000000000000.cta_80300000000000;
                current.Total80300000000000 = 0;
                if (current.cta_80300100000000 != null && current.cta_80300100000000.Total80300100000000 != 0)
                    current.Total80300000000000 += (Decimal)current.cta_80300100000000.Total80300100000000;
                if (current.cta_80300200000000 != null && current.cta_80300200000000.Total80300200000000 != 0)
                    current.Total80300000000000 += (Decimal)current.cta_80300200000000.Total80300200000000;
            }
            if (modelo.cta_80000000000000 != null)
            {
                var current = modelo.cta_80000000000000;
                current.Total80000000000000 = 0;
                if (current.cta_80100000000000 != null && current.cta_80100000000000.Total80100000000000 != 0)
                    current.Total80000000000000 += (Decimal)current.cta_80100000000000.Total80100000000000;
                if (current.cta_80300000000000 != null && current.cta_80300000000000.Total80300000000000 != 0)
                    current.Total80000000000000 += (Decimal)current.cta_80300000000000.Total80300000000000;
            }
        }

    }
}
