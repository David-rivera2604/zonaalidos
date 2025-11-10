using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.Sugese.SaldosContables.Domain.Application.Total
{
    internal class TotalCuenta4
    {
        public static void Mapper(string account, Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModelo modelo, System.Nullable<decimal> value, bool specified)
        {

            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40101000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40101000000000.cta_40101000100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40101000000000.cta_40101000100000;
                current.Total40101000100000 = 0;
                if (current.cta_40101000101000 != null)
                    current.Total40101000100000 += (Decimal)current.cta_40101000101000;
                if (current.cta_40101000102000 != null)
                    current.Total40101000100000 += (Decimal)current.cta_40101000102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40101000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40101000000000.cta_40101000200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40101000000000.cta_40101000200000;
                current.Total40101000200000 = 0;
                if (current.cta_40101000201000 != null)
                    current.Total40101000200000 += (Decimal)current.cta_40101000201000;
                if (current.cta_40101000202000 != null)
                    current.Total40101000200000 += (Decimal)current.cta_40101000202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40101000000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40101000000000;
                current.Total40101000000000 = 0;
                if (current.cta_40101000100000 != null && current.cta_40101000100000.Total40101000100000 != 0)
                    current.Total40101000000000 += (Decimal)current.cta_40101000100000.Total40101000100000;
                if (current.cta_40101000200000 != null && current.cta_40101000200000.Total40101000200000 != 0)
                    current.Total40101000000000 += (Decimal)current.cta_40101000200000.Total40101000200000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40102000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40102000000000.cta_40102000100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40102000000000.cta_40102000100000;
                current.Total40102000100000 = 0;
                if (current.cta_40102000101000 != null)
                    current.Total40102000100000 += (Decimal)current.cta_40102000101000;
                if (current.cta_40102000102000 != null)
                    current.Total40102000100000 += (Decimal)current.cta_40102000102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40102000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40102000000000.cta_40102000200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40102000000000.cta_40102000200000;
                current.Total40102000200000 = 0;
                if (current.cta_40102000201000 != null)
                    current.Total40102000200000 += (Decimal)current.cta_40102000201000;
                if (current.cta_40102000202000 != null)
                    current.Total40102000200000 += (Decimal)current.cta_40102000202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40102000000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40102000000000;
                current.Total40102000000000 = 0;
                if (current.cta_40102000100000 != null && current.cta_40102000100000.Total40102000100000 != 0)
                    current.Total40102000000000 += (Decimal)current.cta_40102000100000.Total40102000100000;
                if (current.cta_40102000200000 != null && current.cta_40102000200000.Total40102000200000 != 0)
                    current.Total40102000000000 += (Decimal)current.cta_40102000200000.Total40102000200000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100100000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100100000000.cta_40100100800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100100000000.cta_40100100800000;
                current.Total40100100800000 = 0;
                if (current.cta_40100100801000 != null)
                    current.Total40100100800000 += (Decimal)current.cta_40100100801000;
                if (current.cta_40100100802000 != null)
                    current.Total40100100800000 += (Decimal)current.cta_40100100802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100100000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100100000000;
                current.Total40100100000000 = 0;
                if (current.cta_40100100800000 != null && current.cta_40100100800000.Total40100100800000 != 0)
                    current.Total40100100000000 += (Decimal)current.cta_40100100800000.Total40100100800000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300100000;
                current.Total40100300100000 = 0;
                if (current.cta_40100300101000 != null)
                    current.Total40100300100000 += (Decimal)current.cta_40100300101000;
                if (current.cta_40100300102000 != null)
                    current.Total40100300100000 += (Decimal)current.cta_40100300102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300200000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300200000.cta_40100300201000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300200000.cta_40100300201000;
                current.Total40100300201000 = 0;
                if (current.cta_40100300201010 != null)
                    current.Total40100300201000 += (Decimal)current.cta_40100300201010;
                if (current.cta_40100300201020 != null)
                    current.Total40100300201000 += (Decimal)current.cta_40100300201020;
                if (current.cta_40100300201100 != null)
                    current.Total40100300201000 += (Decimal)current.cta_40100300201100;
                if (current.cta_40100300201110 != null)
                    current.Total40100300201000 += (Decimal)current.cta_40100300201110;
                if (current.cta_40100300201120 != null)
                    current.Total40100300201000 += (Decimal)current.cta_40100300201120;
                if (current.cta_40100300201150 != null)
                    current.Total40100300201000 += (Decimal)current.cta_40100300201150;
                if (current.cta_40100300201170 != null)
                    current.Total40100300201000 += (Decimal)current.cta_40100300201170;
                if (current.cta_40100300201180 != null)
                    current.Total40100300201000 += (Decimal)current.cta_40100300201180;
                if (current.cta_40100300201990 != null)
                    current.Total40100300201000 += (Decimal)current.cta_40100300201990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300200000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300200000.cta_40100300202000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300200000.cta_40100300202000;
                current.Total40100300202000 = 0;
                if (current.cta_40100300202010 != null)
                    current.Total40100300202000 += (Decimal)current.cta_40100300202010;
                if (current.cta_40100300202020 != null)
                    current.Total40100300202000 += (Decimal)current.cta_40100300202020;
                if (current.cta_40100300202100 != null)
                    current.Total40100300202000 += (Decimal)current.cta_40100300202100;
                if (current.cta_40100300202110 != null)
                    current.Total40100300202000 += (Decimal)current.cta_40100300202110;
                if (current.cta_40100300202120 != null)
                    current.Total40100300202000 += (Decimal)current.cta_40100300202120;
                if (current.cta_40100300202150 != null)
                    current.Total40100300202000 += (Decimal)current.cta_40100300202150;
                if (current.cta_40100300202170 != null)
                    current.Total40100300202000 += (Decimal)current.cta_40100300202170;
                if (current.cta_40100300202180 != null)
                    current.Total40100300202000 += (Decimal)current.cta_40100300202180;
                if (current.cta_40100300202990 != null)
                    current.Total40100300202000 += (Decimal)current.cta_40100300202990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300200000;
                current.Total40100300200000 = 0;
                if (current.cta_40100300201000 != null && current.cta_40100300201000.Total40100300201000 != 0)
                    current.Total40100300200000 += (Decimal)current.cta_40100300201000.Total40100300201000;
                if (current.cta_40100300202000 != null && current.cta_40100300202000.Total40100300202000 != 0)
                    current.Total40100300200000 += (Decimal)current.cta_40100300202000.Total40100300202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300300000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300300000.cta_40100300301000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300300000.cta_40100300301000;
                current.Total40100300301000 = 0;
                if (current.cta_40100300301010 != null)
                    current.Total40100300301000 += (Decimal)current.cta_40100300301010;
                if (current.cta_40100300301020 != null)
                    current.Total40100300301000 += (Decimal)current.cta_40100300301020;
                if (current.cta_40100300301030 != null)
                    current.Total40100300301000 += (Decimal)current.cta_40100300301030;
                if (current.cta_40100300301040 != null)
                    current.Total40100300301000 += (Decimal)current.cta_40100300301040;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300300000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300300000.cta_40100300302000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300300000.cta_40100300302000;
                current.Total40100300302000 = 0;
                if (current.cta_40100300302010 != null)
                    current.Total40100300302000 += (Decimal)current.cta_40100300302010;
                if (current.cta_40100300302020 != null)
                    current.Total40100300302000 += (Decimal)current.cta_40100300302020;
                if (current.cta_40100300302030 != null)
                    current.Total40100300302000 += (Decimal)current.cta_40100300302030;
                if (current.cta_40100300302040 != null)
                    current.Total40100300302000 += (Decimal)current.cta_40100300302040;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000.cta_40100300300000;
                current.Total40100300300000 = 0;
                if (current.cta_40100300301000 != null && current.cta_40100300301000.Total40100300301000 != 0)
                    current.Total40100300300000 += (Decimal)current.cta_40100300301000.Total40100300301000;
                if (current.cta_40100300302000 != null && current.cta_40100300302000.Total40100300302000 != 0)
                    current.Total40100300300000 += (Decimal)current.cta_40100300302000.Total40100300302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100300000000;
                current.Total40100300000000 = 0;
                if (current.cta_40100300100000 != null && current.cta_40100300100000.Total40100300100000 != 0)
                    current.Total40100300000000 += (Decimal)current.cta_40100300100000.Total40100300100000;
                if (current.cta_40100300200000 != null && current.cta_40100300200000.Total40100300200000 != 0)
                    current.Total40100300000000 += (Decimal)current.cta_40100300200000.Total40100300200000;
                if (current.cta_40100300300000 != null && current.cta_40100300300000.Total40100300300000 != 0)
                    current.Total40100300000000 += (Decimal)current.cta_40100300300000.Total40100300300000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000.cta_40100400200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000.cta_40100400200000;
                current.Total40100400200000 = 0;
                if (current.cta_40100400201000 != null)
                    current.Total40100400200000 += (Decimal)current.cta_40100400201000;
                if (current.cta_40100400202000 != null)
                    current.Total40100400200000 += (Decimal)current.cta_40100400202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000.cta_40100400400000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000.cta_40100400400000.cta_40100400401000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000.cta_40100400400000.cta_40100400401000;
                current.Total40100400401000 = 0;
                if (current.cta_40100400401010 != null)
                    current.Total40100400401000 += (Decimal)current.cta_40100400401010;
                if (current.cta_40100400401030 != null)
                    current.Total40100400401000 += (Decimal)current.cta_40100400401030;
                if (current.cta_40100400401040 != null)
                    current.Total40100400401000 += (Decimal)current.cta_40100400401040;
                if (current.cta_40100400401990 != null)
                    current.Total40100400401000 += (Decimal)current.cta_40100400401990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000.cta_40100400400000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000.cta_40100400400000.cta_40100400402000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000.cta_40100400400000.cta_40100400402000;
                current.Total40100400402000 = 0;
                if (current.cta_40100400402010 != null)
                    current.Total40100400402000 += (Decimal)current.cta_40100400402010;
                if (current.cta_40100400402030 != null)
                    current.Total40100400402000 += (Decimal)current.cta_40100400402030;
                if (current.cta_40100400402040 != null)
                    current.Total40100400402000 += (Decimal)current.cta_40100400402040;
                if (current.cta_40100400402990 != null)
                    current.Total40100400402000 += (Decimal)current.cta_40100400402990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000.cta_40100400400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000.cta_40100400400000;
                current.Total40100400400000 = 0;
                if (current.cta_40100400401000 != null && current.cta_40100400401000.Total40100400401000 != 0)
                    current.Total40100400400000 += (Decimal)current.cta_40100400401000.Total40100400401000;
                if (current.cta_40100400402000 != null && current.cta_40100400402000.Total40100400402000 != 0)
                    current.Total40100400400000 += (Decimal)current.cta_40100400402000.Total40100400402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100400000000;
                current.Total40100400000000 = 0;
                if (current.cta_40100400200000 != null && current.cta_40100400200000.Total40100400200000 != 0)
                    current.Total40100400000000 += (Decimal)current.cta_40100400200000.Total40100400200000;
                if (current.cta_40100400400000 != null && current.cta_40100400400000.Total40100400400000 != 0)
                    current.Total40100400000000 += (Decimal)current.cta_40100400400000.Total40100400400000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100500000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100500000000.cta_40100500100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100500000000.cta_40100500100000;
                current.Total40100500100000 = 0;
                if (current.cta_40100500101000 != null)
                    current.Total40100500100000 += (Decimal)current.cta_40100500101000;
                if (current.cta_40100500102000 != null)
                    current.Total40100500100000 += (Decimal)current.cta_40100500102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100500000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100500000000;
                current.Total40100500000000 = 0;
                if (current.cta_40100500100000 != null && current.cta_40100500100000.Total40100500100000 != 0)
                    current.Total40100500000000 += (Decimal)current.cta_40100500100000.Total40100500100000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100600000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100600000000.cta_40100600100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100600000000.cta_40100600100000;
                current.Total40100600100000 = 0;
                if (current.cta_40100600101000 != null)
                    current.Total40100600100000 += (Decimal)current.cta_40100600101000;
                if (current.cta_40100600102000 != null)
                    current.Total40100600100000 += (Decimal)current.cta_40100600102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100600000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100600000000.cta_40100600200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100600000000.cta_40100600200000;
                current.Total40100600200000 = 0;
                if (current.cta_40100600201000 != null)
                    current.Total40100600200000 += (Decimal)current.cta_40100600201000;
                if (current.cta_40100600202000 != null)
                    current.Total40100600200000 += (Decimal)current.cta_40100600202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100600000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100600000000.cta_40100600300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100600000000.cta_40100600300000;
                current.Total40100600300000 = 0;
                if (current.cta_40100600301000 != null)
                    current.Total40100600300000 += (Decimal)current.cta_40100600301000;
                if (current.cta_40100600302000 != null)
                    current.Total40100600300000 += (Decimal)current.cta_40100600302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100600000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100600000000.cta_40100600900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100600000000.cta_40100600900000;
                current.Total40100600900000 = 0;
                if (current.cta_40100600901000 != null)
                    current.Total40100600900000 += (Decimal)current.cta_40100600901000;
                if (current.cta_40100600902000 != null)
                    current.Total40100600900000 += (Decimal)current.cta_40100600902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100600000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100600000000;
                current.Total40100600000000 = 0;
                if (current.cta_40100600100000 != null && current.cta_40100600100000.Total40100600100000 != 0)
                    current.Total40100600000000 += (Decimal)current.cta_40100600100000.Total40100600100000;
                if (current.cta_40100600200000 != null && current.cta_40100600200000.Total40100600200000 != 0)
                    current.Total40100600000000 += (Decimal)current.cta_40100600200000.Total40100600200000;
                if (current.cta_40100600300000 != null && current.cta_40100600300000.Total40100600300000 != 0)
                    current.Total40100600000000 += (Decimal)current.cta_40100600300000.Total40100600300000;
                if (current.cta_40100600900000 != null && current.cta_40100600900000.Total40100600900000 != 0)
                    current.Total40100600000000 += (Decimal)current.cta_40100600900000.Total40100600900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700100000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700100000.cta_40100700101000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700100000.cta_40100700101000;
                current.Total40100700101000 = 0;
                if (current.cta_40100700101010 != null)
                    current.Total40100700101000 += (Decimal)current.cta_40100700101010;
                if (current.cta_40100700101020 != null)
                    current.Total40100700101000 += (Decimal)current.cta_40100700101020;
                if (current.cta_40100700101030 != null)
                    current.Total40100700101000 += (Decimal)current.cta_40100700101030;
                if (current.cta_40100700101040 != null)
                    current.Total40100700101000 += (Decimal)current.cta_40100700101040;
                if (current.cta_40100700101050 != null)
                    current.Total40100700101000 += (Decimal)current.cta_40100700101050;
                if (current.cta_40100700101060 != null)
                    current.Total40100700101000 += (Decimal)current.cta_40100700101060;
                if (current.cta_40100700101070 != null)
                    current.Total40100700101000 += (Decimal)current.cta_40100700101070;
                if (current.cta_40100700101080 != null)
                    current.Total40100700101000 += (Decimal)current.cta_40100700101080;
                if (current.cta_40100700101990 != null)
                    current.Total40100700101000 += (Decimal)current.cta_40100700101990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700100000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700100000.cta_40100700102000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700100000.cta_40100700102000;
                current.Total40100700102000 = 0;
                if (current.cta_40100700102010 != null)
                    current.Total40100700102000 += (Decimal)current.cta_40100700102010;
                if (current.cta_40100700102020 != null)
                    current.Total40100700102000 += (Decimal)current.cta_40100700102020;
                if (current.cta_40100700102030 != null)
                    current.Total40100700102000 += (Decimal)current.cta_40100700102030;
                if (current.cta_40100700102040 != null)
                    current.Total40100700102000 += (Decimal)current.cta_40100700102040;
                if (current.cta_40100700102050 != null)
                    current.Total40100700102000 += (Decimal)current.cta_40100700102050;
                if (current.cta_40100700102060 != null)
                    current.Total40100700102000 += (Decimal)current.cta_40100700102060;
                if (current.cta_40100700102070 != null)
                    current.Total40100700102000 += (Decimal)current.cta_40100700102070;
                if (current.cta_40100700102080 != null)
                    current.Total40100700102000 += (Decimal)current.cta_40100700102080;
                if (current.cta_40100700102990 != null)
                    current.Total40100700102000 += (Decimal)current.cta_40100700102990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700100000;
                current.Total40100700100000 = 0;
                if (current.cta_40100700101000 != null && current.cta_40100700101000.Total40100700101000 != 0)
                    current.Total40100700100000 += (Decimal)current.cta_40100700101000.Total40100700101000;
                if (current.cta_40100700102000 != null && current.cta_40100700102000.Total40100700102000 != 0)
                    current.Total40100700100000 += (Decimal)current.cta_40100700102000.Total40100700102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700200000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700200000.cta_40100700201000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700200000.cta_40100700201000;
                current.Total40100700201000 = 0;
                if (current.cta_40100700201010 != null)
                    current.Total40100700201000 += (Decimal)current.cta_40100700201010;
                if (current.cta_40100700201020 != null)
                    current.Total40100700201000 += (Decimal)current.cta_40100700201020;
                if (current.cta_40100700201030 != null)
                    current.Total40100700201000 += (Decimal)current.cta_40100700201030;
                if (current.cta_40100700201040 != null)
                    current.Total40100700201000 += (Decimal)current.cta_40100700201040;
                if (current.cta_40100700201050 != null)
                    current.Total40100700201000 += (Decimal)current.cta_40100700201050;
                if (current.cta_40100700201060 != null)
                    current.Total40100700201000 += (Decimal)current.cta_40100700201060;
                if (current.cta_40100700201070 != null)
                    current.Total40100700201000 += (Decimal)current.cta_40100700201070;
                if (current.cta_40100700201080 != null)
                    current.Total40100700201000 += (Decimal)current.cta_40100700201080;
                if (current.cta_40100700201990 != null)
                    current.Total40100700201000 += (Decimal)current.cta_40100700201990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700200000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700200000.cta_40100700202000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700200000.cta_40100700202000;
                current.Total40100700202000 = 0;
                if (current.cta_40100700202010 != null)
                    current.Total40100700202000 += (Decimal)current.cta_40100700202010;
                if (current.cta_40100700202020 != null)
                    current.Total40100700202000 += (Decimal)current.cta_40100700202020;
                if (current.cta_40100700202030 != null)
                    current.Total40100700202000 += (Decimal)current.cta_40100700202030;
                if (current.cta_40100700202040 != null)
                    current.Total40100700202000 += (Decimal)current.cta_40100700202040;
                if (current.cta_40100700202050 != null)
                    current.Total40100700202000 += (Decimal)current.cta_40100700202050;
                if (current.cta_40100700202060 != null)
                    current.Total40100700202000 += (Decimal)current.cta_40100700202060;
                if (current.cta_40100700202070 != null)
                    current.Total40100700202000 += (Decimal)current.cta_40100700202070;
                if (current.cta_40100700202080 != null)
                    current.Total40100700202000 += (Decimal)current.cta_40100700202080;
                if (current.cta_40100700202990 != null)
                    current.Total40100700202000 += (Decimal)current.cta_40100700202990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700200000;
                current.Total40100700200000 = 0;
                if (current.cta_40100700201000 != null && current.cta_40100700201000.Total40100700201000 != 0)
                    current.Total40100700200000 += (Decimal)current.cta_40100700201000.Total40100700201000;
                if (current.cta_40100700202000 != null && current.cta_40100700202000.Total40100700202000 != 0)
                    current.Total40100700200000 += (Decimal)current.cta_40100700202000.Total40100700202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700300000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700300000.cta_40100700301000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700300000.cta_40100700301000;
                current.Total40100700301000 = 0;
                if (current.cta_40100700301010 != null)
                    current.Total40100700301000 += (Decimal)current.cta_40100700301010;
                if (current.cta_40100700301020 != null)
                    current.Total40100700301000 += (Decimal)current.cta_40100700301020;
                if (current.cta_40100700301030 != null)
                    current.Total40100700301000 += (Decimal)current.cta_40100700301030;
                if (current.cta_40100700301040 != null)
                    current.Total40100700301000 += (Decimal)current.cta_40100700301040;
                if (current.cta_40100700301990 != null)
                    current.Total40100700301000 += (Decimal)current.cta_40100700301990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700300000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700300000.cta_40100700302000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700300000.cta_40100700302000;
                current.Total40100700302000 = 0;
                if (current.cta_40100700302010 != null)
                    current.Total40100700302000 += (Decimal)current.cta_40100700302010;
                if (current.cta_40100700302020 != null)
                    current.Total40100700302000 += (Decimal)current.cta_40100700302020;
                if (current.cta_40100700302030 != null)
                    current.Total40100700302000 += (Decimal)current.cta_40100700302030;
                if (current.cta_40100700302040 != null)
                    current.Total40100700302000 += (Decimal)current.cta_40100700302040;
                if (current.cta_40100700302990 != null)
                    current.Total40100700302000 += (Decimal)current.cta_40100700302990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700300000;
                current.Total40100700300000 = 0;
                if (current.cta_40100700301000 != null && current.cta_40100700301000.Total40100700301000 != 0)
                    current.Total40100700300000 += (Decimal)current.cta_40100700301000.Total40100700301000;
                if (current.cta_40100700302000 != null && current.cta_40100700302000.Total40100700302000 != 0)
                    current.Total40100700300000 += (Decimal)current.cta_40100700302000.Total40100700302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700400000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700400000.cta_40100700401000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700400000.cta_40100700401000;
                current.Total40100700401000 = 0;
                if (current.cta_40100700401010 != null)
                    current.Total40100700401000 += (Decimal)current.cta_40100700401010;
                if (current.cta_40100700401020 != null)
                    current.Total40100700401000 += (Decimal)current.cta_40100700401020;
                if (current.cta_40100700401030 != null)
                    current.Total40100700401000 += (Decimal)current.cta_40100700401030;
                if (current.cta_40100700401040 != null)
                    current.Total40100700401000 += (Decimal)current.cta_40100700401040;
                if (current.cta_40100700401050 != null)
                    current.Total40100700401000 += (Decimal)current.cta_40100700401050;
                if (current.cta_40100700401060 != null)
                    current.Total40100700401000 += (Decimal)current.cta_40100700401060;
                if (current.cta_40100700401070 != null)
                    current.Total40100700401000 += (Decimal)current.cta_40100700401070;
                if (current.cta_40100700401080 != null)
                    current.Total40100700401000 += (Decimal)current.cta_40100700401080;
                if (current.cta_40100700401090 != null)
                    current.Total40100700401000 += (Decimal)current.cta_40100700401090;
                if (current.cta_40100700401100 != null)
                    current.Total40100700401000 += (Decimal)current.cta_40100700401100;
                if (current.cta_40100700401990 != null)
                    current.Total40100700401000 += (Decimal)current.cta_40100700401990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700400000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700400000.cta_40100700402000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700400000.cta_40100700402000;
                current.Total40100700402000 = 0;
                if (current.cta_40100700402010 != null)
                    current.Total40100700402000 += (Decimal)current.cta_40100700402010;
                if (current.cta_40100700402020 != null)
                    current.Total40100700402000 += (Decimal)current.cta_40100700402020;
                if (current.cta_40100700402030 != null)
                    current.Total40100700402000 += (Decimal)current.cta_40100700402030;
                if (current.cta_40100700402040 != null)
                    current.Total40100700402000 += (Decimal)current.cta_40100700402040;
                if (current.cta_40100700402050 != null)
                    current.Total40100700402000 += (Decimal)current.cta_40100700402050;
                if (current.cta_40100700402060 != null)
                    current.Total40100700402000 += (Decimal)current.cta_40100700402060;
                if (current.cta_40100700402070 != null)
                    current.Total40100700402000 += (Decimal)current.cta_40100700402070;
                if (current.cta_40100700402080 != null)
                    current.Total40100700402000 += (Decimal)current.cta_40100700402080;
                if (current.cta_40100700402090 != null)
                    current.Total40100700402000 += (Decimal)current.cta_40100700402090;
                if (current.cta_40100700402100 != null)
                    current.Total40100700402000 += (Decimal)current.cta_40100700402100;
                if (current.cta_40100700402990 != null)
                    current.Total40100700402000 += (Decimal)current.cta_40100700402990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700400000;
                current.Total40100700400000 = 0;
                if (current.cta_40100700401000 != null && current.cta_40100700401000.Total40100700401000 != 0)
                    current.Total40100700400000 += (Decimal)current.cta_40100700401000.Total40100700401000;
                if (current.cta_40100700402000 != null && current.cta_40100700402000.Total40100700402000 != 0)
                    current.Total40100700400000 += (Decimal)current.cta_40100700402000.Total40100700402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700500000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700500000.cta_40100700501000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700500000.cta_40100700501000;
                current.Total40100700501000 = 0;
                if (current.cta_40100700501010 != null)
                    current.Total40100700501000 += (Decimal)current.cta_40100700501010;
                if (current.cta_40100700501020 != null)
                    current.Total40100700501000 += (Decimal)current.cta_40100700501020;
                if (current.cta_40100700501030 != null)
                    current.Total40100700501000 += (Decimal)current.cta_40100700501030;
                if (current.cta_40100700501040 != null)
                    current.Total40100700501000 += (Decimal)current.cta_40100700501040;
                if (current.cta_40100700501050 != null)
                    current.Total40100700501000 += (Decimal)current.cta_40100700501050;
                if (current.cta_40100700501060 != null)
                    current.Total40100700501000 += (Decimal)current.cta_40100700501060;
                if (current.cta_40100700501070 != null)
                    current.Total40100700501000 += (Decimal)current.cta_40100700501070;
                if (current.cta_40100700501080 != null)
                    current.Total40100700501000 += (Decimal)current.cta_40100700501080;
                if (current.cta_40100700501990 != null)
                    current.Total40100700501000 += (Decimal)current.cta_40100700501990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700500000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700500000.cta_40100700502000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700500000.cta_40100700502000;
                current.Total40100700502000 = 0;
                if (current.cta_40100700502010 != null)
                    current.Total40100700502000 += (Decimal)current.cta_40100700502010;
                if (current.cta_40100700502020 != null)
                    current.Total40100700502000 += (Decimal)current.cta_40100700502020;
                if (current.cta_40100700502030 != null)
                    current.Total40100700502000 += (Decimal)current.cta_40100700502030;
                if (current.cta_40100700502040 != null)
                    current.Total40100700502000 += (Decimal)current.cta_40100700502040;
                if (current.cta_40100700502050 != null)
                    current.Total40100700502000 += (Decimal)current.cta_40100700502050;
                if (current.cta_40100700502060 != null)
                    current.Total40100700502000 += (Decimal)current.cta_40100700502060;
                if (current.cta_40100700502070 != null)
                    current.Total40100700502000 += (Decimal)current.cta_40100700502070;
                if (current.cta_40100700502080 != null)
                    current.Total40100700502000 += (Decimal)current.cta_40100700502080;
                if (current.cta_40100700502990 != null)
                    current.Total40100700502000 += (Decimal)current.cta_40100700502990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700500000;
                current.Total40100700500000 = 0;
                if (current.cta_40100700501000 != null && current.cta_40100700501000.Total40100700501000 != 0)
                    current.Total40100700500000 += (Decimal)current.cta_40100700501000.Total40100700501000;
                if (current.cta_40100700502000 != null && current.cta_40100700502000.Total40100700502000 != 0)
                    current.Total40100700500000 += (Decimal)current.cta_40100700502000.Total40100700502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700600000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700600000.cta_40100700601000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700600000.cta_40100700601000;
                current.Total40100700601000 = 0;
                if (current.cta_40100700601010 != null)
                    current.Total40100700601000 += (Decimal)current.cta_40100700601010;
                if (current.cta_40100700601020 != null)
                    current.Total40100700601000 += (Decimal)current.cta_40100700601020;
                if (current.cta_40100700601030 != null)
                    current.Total40100700601000 += (Decimal)current.cta_40100700601030;
                if (current.cta_40100700601040 != null)
                    current.Total40100700601000 += (Decimal)current.cta_40100700601040;
                if (current.cta_40100700601050 != null)
                    current.Total40100700601000 += (Decimal)current.cta_40100700601050;
                if (current.cta_40100700601060 != null)
                    current.Total40100700601000 += (Decimal)current.cta_40100700601060;
                if (current.cta_40100700601070 != null)
                    current.Total40100700601000 += (Decimal)current.cta_40100700601070;
                if (current.cta_40100700601080 != null)
                    current.Total40100700601000 += (Decimal)current.cta_40100700601080;
                if (current.cta_40100700601990 != null)
                    current.Total40100700601000 += (Decimal)current.cta_40100700601990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700600000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700600000.cta_40100700602000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700600000.cta_40100700602000;
                current.Total40100700602000 = 0;
                if (current.cta_40100700602010 != null)
                    current.Total40100700602000 += (Decimal)current.cta_40100700602010;
                if (current.cta_40100700602020 != null)
                    current.Total40100700602000 += (Decimal)current.cta_40100700602020;
                if (current.cta_40100700602030 != null)
                    current.Total40100700602000 += (Decimal)current.cta_40100700602030;
                if (current.cta_40100700602040 != null)
                    current.Total40100700602000 += (Decimal)current.cta_40100700602040;
                if (current.cta_40100700602050 != null)
                    current.Total40100700602000 += (Decimal)current.cta_40100700602050;
                if (current.cta_40100700602060 != null)
                    current.Total40100700602000 += (Decimal)current.cta_40100700602060;
                if (current.cta_40100700602070 != null)
                    current.Total40100700602000 += (Decimal)current.cta_40100700602070;
                if (current.cta_40100700602080 != null)
                    current.Total40100700602000 += (Decimal)current.cta_40100700602080;
                if (current.cta_40100700602990 != null)
                    current.Total40100700602000 += (Decimal)current.cta_40100700602990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700600000;
                current.Total40100700600000 = 0;
                if (current.cta_40100700601000 != null && current.cta_40100700601000.Total40100700601000 != 0)
                    current.Total40100700600000 += (Decimal)current.cta_40100700601000.Total40100700601000;
                if (current.cta_40100700602000 != null && current.cta_40100700602000.Total40100700602000 != 0)
                    current.Total40100700600000 += (Decimal)current.cta_40100700602000.Total40100700602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700700000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700700000.cta_40100700701000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700700000.cta_40100700701000;
                current.Total40100700701000 = 0;
                if (current.cta_40100700701010 != null)
                    current.Total40100700701000 += (Decimal)current.cta_40100700701010;
                if (current.cta_40100700701020 != null)
                    current.Total40100700701000 += (Decimal)current.cta_40100700701020;
                if (current.cta_40100700701030 != null)
                    current.Total40100700701000 += (Decimal)current.cta_40100700701030;
                if (current.cta_40100700701040 != null)
                    current.Total40100700701000 += (Decimal)current.cta_40100700701040;
                if (current.cta_40100700701990 != null)
                    current.Total40100700701000 += (Decimal)current.cta_40100700701990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700700000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700700000.cta_40100700702000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700700000.cta_40100700702000;
                current.Total40100700702000 = 0;
                if (current.cta_40100700702010 != null)
                    current.Total40100700702000 += (Decimal)current.cta_40100700702010;
                if (current.cta_40100700702020 != null)
                    current.Total40100700702000 += (Decimal)current.cta_40100700702020;
                if (current.cta_40100700702030 != null)
                    current.Total40100700702000 += (Decimal)current.cta_40100700702030;
                if (current.cta_40100700702040 != null)
                    current.Total40100700702000 += (Decimal)current.cta_40100700702040;
                if (current.cta_40100700702990 != null)
                    current.Total40100700702000 += (Decimal)current.cta_40100700702990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700700000;
                current.Total40100700700000 = 0;
                if (current.cta_40100700701000 != null && current.cta_40100700701000.Total40100700701000 != 0)
                    current.Total40100700700000 += (Decimal)current.cta_40100700701000.Total40100700701000;
                if (current.cta_40100700702000 != null && current.cta_40100700702000.Total40100700702000 != 0)
                    current.Total40100700700000 += (Decimal)current.cta_40100700702000.Total40100700702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700800000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700800000.cta_40100700801000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700800000.cta_40100700801000;
                current.Total40100700801000 = 0;
                if (current.cta_40100700801010 != null)
                    current.Total40100700801000 += (Decimal)current.cta_40100700801010;
                if (current.cta_40100700801020 != null)
                    current.Total40100700801000 += (Decimal)current.cta_40100700801020;
                if (current.cta_40100700801030 != null)
                    current.Total40100700801000 += (Decimal)current.cta_40100700801030;
                if (current.cta_40100700801040 != null)
                    current.Total40100700801000 += (Decimal)current.cta_40100700801040;
                if (current.cta_40100700801050 != null)
                    current.Total40100700801000 += (Decimal)current.cta_40100700801050;
                if (current.cta_40100700801060 != null)
                    current.Total40100700801000 += (Decimal)current.cta_40100700801060;
                if (current.cta_40100700801070 != null)
                    current.Total40100700801000 += (Decimal)current.cta_40100700801070;
                if (current.cta_40100700801080 != null)
                    current.Total40100700801000 += (Decimal)current.cta_40100700801080;
                if (current.cta_40100700801990 != null)
                    current.Total40100700801000 += (Decimal)current.cta_40100700801990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700800000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700800000.cta_40100700802000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700800000.cta_40100700802000;
                current.Total40100700802000 = 0;
                if (current.cta_40100700802010 != null)
                    current.Total40100700802000 += (Decimal)current.cta_40100700802010;
                if (current.cta_40100700802020 != null)
                    current.Total40100700802000 += (Decimal)current.cta_40100700802020;
                if (current.cta_40100700802030 != null)
                    current.Total40100700802000 += (Decimal)current.cta_40100700802030;
                if (current.cta_40100700802040 != null)
                    current.Total40100700802000 += (Decimal)current.cta_40100700802040;
                if (current.cta_40100700802050 != null)
                    current.Total40100700802000 += (Decimal)current.cta_40100700802050;
                if (current.cta_40100700802060 != null)
                    current.Total40100700802000 += (Decimal)current.cta_40100700802060;
                if (current.cta_40100700802070 != null)
                    current.Total40100700802000 += (Decimal)current.cta_40100700802070;
                if (current.cta_40100700802080 != null)
                    current.Total40100700802000 += (Decimal)current.cta_40100700802080;
                if (current.cta_40100700802990 != null)
                    current.Total40100700802000 += (Decimal)current.cta_40100700802990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700800000;
                current.Total40100700800000 = 0;
                if (current.cta_40100700801000 != null && current.cta_40100700801000.Total40100700801000 != 0)
                    current.Total40100700800000 += (Decimal)current.cta_40100700801000.Total40100700801000;
                if (current.cta_40100700802000 != null && current.cta_40100700802000.Total40100700802000 != 0)
                    current.Total40100700800000 += (Decimal)current.cta_40100700802000.Total40100700802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700900000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700900000.cta_40100700901000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700900000.cta_40100700901000;
                current.Total40100700901000 = 0;
                if (current.cta_40100700901010 != null)
                    current.Total40100700901000 += (Decimal)current.cta_40100700901010;
                if (current.cta_40100700901020 != null)
                    current.Total40100700901000 += (Decimal)current.cta_40100700901020;
                if (current.cta_40100700901030 != null)
                    current.Total40100700901000 += (Decimal)current.cta_40100700901030;
                if (current.cta_40100700901040 != null)
                    current.Total40100700901000 += (Decimal)current.cta_40100700901040;
                if (current.cta_40100700901050 != null)
                    current.Total40100700901000 += (Decimal)current.cta_40100700901050;
                if (current.cta_40100700901060 != null)
                    current.Total40100700901000 += (Decimal)current.cta_40100700901060;
                if (current.cta_40100700901070 != null)
                    current.Total40100700901000 += (Decimal)current.cta_40100700901070;
                if (current.cta_40100700901080 != null)
                    current.Total40100700901000 += (Decimal)current.cta_40100700901080;
                if (current.cta_40100700901990 != null)
                    current.Total40100700901000 += (Decimal)current.cta_40100700901990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700900000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700900000.cta_40100700902000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700900000.cta_40100700902000;
                current.Total40100700902000 = 0;
                if (current.cta_40100700902010 != null)
                    current.Total40100700902000 += (Decimal)current.cta_40100700902010;
                if (current.cta_40100700902020 != null)
                    current.Total40100700902000 += (Decimal)current.cta_40100700902020;
                if (current.cta_40100700902030 != null)
                    current.Total40100700902000 += (Decimal)current.cta_40100700902030;
                if (current.cta_40100700902040 != null)
                    current.Total40100700902000 += (Decimal)current.cta_40100700902040;
                if (current.cta_40100700902050 != null)
                    current.Total40100700902000 += (Decimal)current.cta_40100700902050;
                if (current.cta_40100700902060 != null)
                    current.Total40100700902000 += (Decimal)current.cta_40100700902060;
                if (current.cta_40100700902070 != null)
                    current.Total40100700902000 += (Decimal)current.cta_40100700902070;
                if (current.cta_40100700902080 != null)
                    current.Total40100700902000 += (Decimal)current.cta_40100700902080;
                if (current.cta_40100700902990 != null)
                    current.Total40100700902000 += (Decimal)current.cta_40100700902990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100700900000;
                current.Total40100700900000 = 0;
                if (current.cta_40100700901000 != null && current.cta_40100700901000.Total40100700901000 != 0)
                    current.Total40100700900000 += (Decimal)current.cta_40100700901000.Total40100700901000;
                if (current.cta_40100700902000 != null && current.cta_40100700902000.Total40100700902000 != 0)
                    current.Total40100700900000 += (Decimal)current.cta_40100700902000.Total40100700902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100701000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100701000000.cta_40100701001000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100701000000.cta_40100701001000;
                current.Total40100701001000 = 0;
                if (current.cta_40100701001010 != null)
                    current.Total40100701001000 += (Decimal)current.cta_40100701001010;
                if (current.cta_40100701001020 != null)
                    current.Total40100701001000 += (Decimal)current.cta_40100701001020;
                if (current.cta_40100701001030 != null)
                    current.Total40100701001000 += (Decimal)current.cta_40100701001030;
                if (current.cta_40100701001040 != null)
                    current.Total40100701001000 += (Decimal)current.cta_40100701001040;
                if (current.cta_40100701001990 != null)
                    current.Total40100701001000 += (Decimal)current.cta_40100701001990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100701000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100701000000.cta_40100701002000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100701000000.cta_40100701002000;
                current.Total40100701002000 = 0;
                if (current.cta_40100701002010 != null)
                    current.Total40100701002000 += (Decimal)current.cta_40100701002010;
                if (current.cta_40100701002020 != null)
                    current.Total40100701002000 += (Decimal)current.cta_40100701002020;
                if (current.cta_40100701002030 != null)
                    current.Total40100701002000 += (Decimal)current.cta_40100701002030;
                if (current.cta_40100701002040 != null)
                    current.Total40100701002000 += (Decimal)current.cta_40100701002040;
                if (current.cta_40100701002990 != null)
                    current.Total40100701002000 += (Decimal)current.cta_40100701002990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100701000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100701000000;
                current.Total40100701000000 = 0;
                if (current.cta_40100701001000 != null && current.cta_40100701001000.Total40100701001000 != 0)
                    current.Total40100701000000 += (Decimal)current.cta_40100701001000.Total40100701001000;
                if (current.cta_40100701002000 != null && current.cta_40100701002000.Total40100701002000 != 0)
                    current.Total40100701000000 += (Decimal)current.cta_40100701002000.Total40100701002000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100709900000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100709900000.cta_40100709901000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100709900000.cta_40100709901000;
                current.Total40100709901000 = 0;
                if (current.cta_40100709901010 != null)
                    current.Total40100709901000 += (Decimal)current.cta_40100709901010;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100709900000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100709900000.cta_40100709902000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100709900000.cta_40100709902000;
                current.Total40100709902000 = 0;
                if (current.cta_40100709902010 != null)
                    current.Total40100709902000 += (Decimal)current.cta_40100709902010;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100709900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000.cta_40100709900000;
                current.Total40100709900000 = 0;
                if (current.cta_40100709901000 != null && current.cta_40100709901000.Total40100709901000 != 0)
                    current.Total40100709900000 += (Decimal)current.cta_40100709901000.Total40100709901000;
                if (current.cta_40100709902000 != null && current.cta_40100709902000.Total40100709902000 != 0)
                    current.Total40100709900000 += (Decimal)current.cta_40100709902000.Total40100709902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100700000000;
                current.Total40100700000000 = 0;
                if (current.cta_40100700100000 != null && current.cta_40100700100000.Total40100700100000 != 0)
                    current.Total40100700000000 += (Decimal)current.cta_40100700100000.Total40100700100000;
                if (current.cta_40100700200000 != null && current.cta_40100700200000.Total40100700200000 != 0)
                    current.Total40100700000000 += (Decimal)current.cta_40100700200000.Total40100700200000;
                if (current.cta_40100700300000 != null && current.cta_40100700300000.Total40100700300000 != 0)
                    current.Total40100700000000 += (Decimal)current.cta_40100700300000.Total40100700300000;
                if (current.cta_40100700400000 != null && current.cta_40100700400000.Total40100700400000 != 0)
                    current.Total40100700000000 += (Decimal)current.cta_40100700400000.Total40100700400000;
                if (current.cta_40100700500000 != null && current.cta_40100700500000.Total40100700500000 != 0)
                    current.Total40100700000000 += (Decimal)current.cta_40100700500000.Total40100700500000;
                if (current.cta_40100700600000 != null && current.cta_40100700600000.Total40100700600000 != 0)
                    current.Total40100700000000 += (Decimal)current.cta_40100700600000.Total40100700600000;
                if (current.cta_40100700700000 != null && current.cta_40100700700000.Total40100700700000 != 0)
                    current.Total40100700000000 += (Decimal)current.cta_40100700700000.Total40100700700000;
                if (current.cta_40100700800000 != null && current.cta_40100700800000.Total40100700800000 != 0)
                    current.Total40100700000000 += (Decimal)current.cta_40100700800000.Total40100700800000;
                if (current.cta_40100700900000 != null && current.cta_40100700900000.Total40100700900000 != 0)
                    current.Total40100700000000 += (Decimal)current.cta_40100700900000.Total40100700900000;
                if (current.cta_40100701000000 != null && current.cta_40100701000000.Total40100701000000 != 0)
                    current.Total40100700000000 += (Decimal)current.cta_40100701000000.Total40100701000000;
                if (current.cta_40100709900000 != null && current.cta_40100709900000.Total40100709900000 != 0)
                    current.Total40100700000000 += (Decimal)current.cta_40100709900000.Total40100709900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100800100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100800100000;
                current.Total40100800100000 = 0;
                if (current.cta_40100800101000 != null)
                    current.Total40100800100000 += (Decimal)current.cta_40100800101000;
                if (current.cta_40100800102000 != null)
                    current.Total40100800100000 += (Decimal)current.cta_40100800102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100800300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100800300000;
                current.Total40100800300000 = 0;
                if (current.cta_40100800301000 != null)
                    current.Total40100800300000 += (Decimal)current.cta_40100800301000;
                if (current.cta_40100800302000 != null)
                    current.Total40100800300000 += (Decimal)current.cta_40100800302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100800400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100800400000;
                current.Total40100800400000 = 0;
                if (current.cta_40100800401000 != null)
                    current.Total40100800400000 += (Decimal)current.cta_40100800401000;
                if (current.cta_40100800402000 != null)
                    current.Total40100800400000 += (Decimal)current.cta_40100800402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100800600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100800600000;
                current.Total40100800600000 = 0;
                if (current.cta_40100800601000 != null)
                    current.Total40100800600000 += (Decimal)current.cta_40100800601000;
                if (current.cta_40100800602000 != null)
                    current.Total40100800600000 += (Decimal)current.cta_40100800602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100800700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100800700000;
                current.Total40100800700000 = 0;
                if (current.cta_40100800701000 != null)
                    current.Total40100800700000 += (Decimal)current.cta_40100800701000;
                if (current.cta_40100800702000 != null)
                    current.Total40100800700000 += (Decimal)current.cta_40100800702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100800800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100800800000;
                current.Total40100800800000 = 0;
                if (current.cta_40100800801000 != null)
                    current.Total40100800800000 += (Decimal)current.cta_40100800801000;
                if (current.cta_40100800802000 != null)
                    current.Total40100800800000 += (Decimal)current.cta_40100800802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100801100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100801100000;
                current.Total40100801100000 = 0;
                if (current.cta_40100801101000 != null)
                    current.Total40100801100000 += (Decimal)current.cta_40100801101000;
                if (current.cta_40100801102000 != null)
                    current.Total40100801100000 += (Decimal)current.cta_40100801102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100801200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100801200000;
                current.Total40100801200000 = 0;
                if (current.cta_40100801201000 != null)
                    current.Total40100801200000 += (Decimal)current.cta_40100801201000;
                if (current.cta_40100801202000 != null)
                    current.Total40100801200000 += (Decimal)current.cta_40100801202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100801300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100801300000;
                current.Total40100801300000 = 0;
                if (current.cta_40100801301000 != null)
                    current.Total40100801300000 += (Decimal)current.cta_40100801301000;
                if (current.cta_40100801302000 != null)
                    current.Total40100801300000 += (Decimal)current.cta_40100801302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100801400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100801400000;
                current.Total40100801400000 = 0;
                if (current.cta_40100801401000 != null)
                    current.Total40100801400000 += (Decimal)current.cta_40100801401000;
                if (current.cta_40100801402000 != null)
                    current.Total40100801400000 += (Decimal)current.cta_40100801402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100801700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100801700000;
                current.Total40100801700000 = 0;
                if (current.cta_40100801701000 != null)
                    current.Total40100801700000 += (Decimal)current.cta_40100801701000;
                if (current.cta_40100801702000 != null)
                    current.Total40100801700000 += (Decimal)current.cta_40100801702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100802100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100802100000;
                current.Total40100802100000 = 0;
                if (current.cta_40100802101000 != null)
                    current.Total40100802100000 += (Decimal)current.cta_40100802101000;
                if (current.cta_40100802102000 != null)
                    current.Total40100802100000 += (Decimal)current.cta_40100802102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100802300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100802300000;
                current.Total40100802300000 = 0;
                if (current.cta_40100802301000 != null)
                    current.Total40100802300000 += (Decimal)current.cta_40100802301000;
                if (current.cta_40100802302000 != null)
                    current.Total40100802300000 += (Decimal)current.cta_40100802302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100802400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100802400000;
                current.Total40100802400000 = 0;
                if (current.cta_40100802401000 != null)
                    current.Total40100802400000 += (Decimal)current.cta_40100802401000;
                if (current.cta_40100802402000 != null)
                    current.Total40100802400000 += (Decimal)current.cta_40100802402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100802600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100802600000;
                current.Total40100802600000 = 0;
                if (current.cta_40100802601000 != null)
                    current.Total40100802600000 += (Decimal)current.cta_40100802601000;
                if (current.cta_40100802602000 != null)
                    current.Total40100802600000 += (Decimal)current.cta_40100802602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100802700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100802700000;
                current.Total40100802700000 = 0;
                if (current.cta_40100802701000 != null)
                    current.Total40100802700000 += (Decimal)current.cta_40100802701000;
                if (current.cta_40100802702000 != null)
                    current.Total40100802700000 += (Decimal)current.cta_40100802702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100802800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100802800000;
                current.Total40100802800000 = 0;
                if (current.cta_40100802801000 != null)
                    current.Total40100802800000 += (Decimal)current.cta_40100802801000;
                if (current.cta_40100802802000 != null)
                    current.Total40100802800000 += (Decimal)current.cta_40100802802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100803100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100803100000;
                current.Total40100803100000 = 0;
                if (current.cta_40100803101000 != null)
                    current.Total40100803100000 += (Decimal)current.cta_40100803101000;
                if (current.cta_40100803102000 != null)
                    current.Total40100803100000 += (Decimal)current.cta_40100803102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100803200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100803200000;
                current.Total40100803200000 = 0;
                if (current.cta_40100803201000 != null)
                    current.Total40100803200000 += (Decimal)current.cta_40100803201000;
                if (current.cta_40100803202000 != null)
                    current.Total40100803200000 += (Decimal)current.cta_40100803202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100803300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100803300000;
                current.Total40100803300000 = 0;
                if (current.cta_40100803301000 != null)
                    current.Total40100803300000 += (Decimal)current.cta_40100803301000;
                if (current.cta_40100803302000 != null)
                    current.Total40100803300000 += (Decimal)current.cta_40100803302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100803400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100803400000;
                current.Total40100803400000 = 0;
                if (current.cta_40100803401000 != null)
                    current.Total40100803400000 += (Decimal)current.cta_40100803401000;
                if (current.cta_40100803402000 != null)
                    current.Total40100803400000 += (Decimal)current.cta_40100803402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100803700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000.cta_40100803700000;
                current.Total40100803700000 = 0;
                if (current.cta_40100803701000 != null)
                    current.Total40100803700000 += (Decimal)current.cta_40100803701000;
                if (current.cta_40100803702000 != null)
                    current.Total40100803700000 += (Decimal)current.cta_40100803702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100800000000;
                current.Total40100800000000 = 0;
                if (current.cta_40100800100000 != null && current.cta_40100800100000.Total40100800100000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100800100000.Total40100800100000;
                if (current.cta_40100800300000 != null && current.cta_40100800300000.Total40100800300000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100800300000.Total40100800300000;
                if (current.cta_40100800400000 != null && current.cta_40100800400000.Total40100800400000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100800400000.Total40100800400000;
                if (current.cta_40100800600000 != null && current.cta_40100800600000.Total40100800600000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100800600000.Total40100800600000;
                if (current.cta_40100800700000 != null && current.cta_40100800700000.Total40100800700000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100800700000.Total40100800700000;
                if (current.cta_40100800800000 != null && current.cta_40100800800000.Total40100800800000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100800800000.Total40100800800000;
                if (current.cta_40100801100000 != null && current.cta_40100801100000.Total40100801100000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100801100000.Total40100801100000;
                if (current.cta_40100801200000 != null && current.cta_40100801200000.Total40100801200000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100801200000.Total40100801200000;
                if (current.cta_40100801300000 != null && current.cta_40100801300000.Total40100801300000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100801300000.Total40100801300000;
                if (current.cta_40100801400000 != null && current.cta_40100801400000.Total40100801400000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100801400000.Total40100801400000;
                if (current.cta_40100801700000 != null && current.cta_40100801700000.Total40100801700000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100801700000.Total40100801700000;
                if (current.cta_40100802100000 != null && current.cta_40100802100000.Total40100802100000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100802100000.Total40100802100000;
                if (current.cta_40100802300000 != null && current.cta_40100802300000.Total40100802300000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100802300000.Total40100802300000;
                if (current.cta_40100802400000 != null && current.cta_40100802400000.Total40100802400000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100802400000.Total40100802400000;
                if (current.cta_40100802600000 != null && current.cta_40100802600000.Total40100802600000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100802600000.Total40100802600000;
                if (current.cta_40100802700000 != null && current.cta_40100802700000.Total40100802700000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100802700000.Total40100802700000;
                if (current.cta_40100802800000 != null && current.cta_40100802800000.Total40100802800000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100802800000.Total40100802800000;
                if (current.cta_40100803100000 != null && current.cta_40100803100000.Total40100803100000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100803100000.Total40100803100000;
                if (current.cta_40100803200000 != null && current.cta_40100803200000.Total40100803200000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100803200000.Total40100803200000;
                if (current.cta_40100803300000 != null && current.cta_40100803300000.Total40100803300000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100803300000.Total40100803300000;
                if (current.cta_40100803400000 != null && current.cta_40100803400000.Total40100803400000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100803400000.Total40100803400000;
                if (current.cta_40100803700000 != null && current.cta_40100803700000.Total40100803700000 != 0)
                    current.Total40100800000000 += (Decimal)current.cta_40100803700000.Total40100803700000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100900700000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100900700000.cta_40100900701000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100900700000.cta_40100900701000;
                current.Total40100900701000 = 0;
                if (current.cta_40100900701040 != null)
                    current.Total40100900701000 += (Decimal)current.cta_40100900701040;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100900700000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100900700000.cta_40100900702000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100900700000.cta_40100900702000;
                current.Total40100900702000 = 0;
                if (current.cta_40100900702040 != null)
                    current.Total40100900702000 += (Decimal)current.cta_40100900702040;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100900700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100900700000;
                current.Total40100900700000 = 0;
                if (current.cta_40100900701000 != null && current.cta_40100900701000.Total40100900701000 != 0)
                    current.Total40100900700000 += (Decimal)current.cta_40100900701000.Total40100900701000;
                if (current.cta_40100900702000 != null && current.cta_40100900702000.Total40100900702000 != 0)
                    current.Total40100900700000 += (Decimal)current.cta_40100900702000.Total40100900702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100900800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100900800000;
                current.Total40100900800000 = 0;
                if (current.cta_40100900801000 != null)
                    current.Total40100900800000 += (Decimal)current.cta_40100900801000;
                if (current.cta_40100900802000 != null)
                    current.Total40100900800000 += (Decimal)current.cta_40100900802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901000000;
                current.Total40100901000000 = 0;
                if (current.cta_40100901001000 != null)
                    current.Total40100901000000 += (Decimal)current.cta_40100901001000;
                if (current.cta_40100901002000 != null)
                    current.Total40100901000000 += (Decimal)current.cta_40100901002000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901100000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901100000.cta_40100901101000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901100000.cta_40100901101000;
                current.Total40100901101000 = 0;
                if (current.cta_40100901101010 != null)
                    current.Total40100901101000 += (Decimal)current.cta_40100901101010;
                if (current.cta_40100901101040 != null)
                    current.Total40100901101000 += (Decimal)current.cta_40100901101040;
                if (current.cta_40100901101050 != null)
                    current.Total40100901101000 += (Decimal)current.cta_40100901101050;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901100000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901100000.cta_40100901102000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901100000.cta_40100901102000;
                current.Total40100901102000 = 0;
                if (current.cta_40100901102010 != null)
                    current.Total40100901102000 += (Decimal)current.cta_40100901102010;
                if (current.cta_40100901102040 != null)
                    current.Total40100901102000 += (Decimal)current.cta_40100901102040;
                if (current.cta_40100901102050 != null)
                    current.Total40100901102000 += (Decimal)current.cta_40100901102050;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901100000;
                current.Total40100901100000 = 0;
                if (current.cta_40100901101000 != null && current.cta_40100901101000.Total40100901101000 != 0)
                    current.Total40100901100000 += (Decimal)current.cta_40100901101000.Total40100901101000;
                if (current.cta_40100901102000 != null && current.cta_40100901102000.Total40100901102000 != 0)
                    current.Total40100901100000 += (Decimal)current.cta_40100901102000.Total40100901102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901200000;
                current.Total40100901200000 = 0;
                if (current.cta_40100901201000 != null)
                    current.Total40100901200000 += (Decimal)current.cta_40100901201000;
                if (current.cta_40100901202000 != null)
                    current.Total40100901200000 += (Decimal)current.cta_40100901202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901300000;
                current.Total40100901300000 = 0;
                if (current.cta_40100901301000 != null)
                    current.Total40100901300000 += (Decimal)current.cta_40100901301000;
                if (current.cta_40100901302000 != null)
                    current.Total40100901300000 += (Decimal)current.cta_40100901302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901400000;
                current.Total40100901400000 = 0;
                if (current.cta_40100901401000 != null)
                    current.Total40100901400000 += (Decimal)current.cta_40100901401000;
                if (current.cta_40100901402000 != null)
                    current.Total40100901400000 += (Decimal)current.cta_40100901402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901700000;
                current.Total40100901700000 = 0;
                if (current.cta_40100901701000 != null)
                    current.Total40100901700000 += (Decimal)current.cta_40100901701000;
                if (current.cta_40100901702000 != null)
                    current.Total40100901700000 += (Decimal)current.cta_40100901702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100901800000;
                current.Total40100901800000 = 0;
                if (current.cta_40100901801000 != null)
                    current.Total40100901800000 += (Decimal)current.cta_40100901801000;
                if (current.cta_40100901802000 != null)
                    current.Total40100901800000 += (Decimal)current.cta_40100901802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100902000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100902000000;
                current.Total40100902000000 = 0;
                if (current.cta_40100902001000 != null)
                    current.Total40100902000000 += (Decimal)current.cta_40100902001000;
                if (current.cta_40100902002000 != null)
                    current.Total40100902000000 += (Decimal)current.cta_40100902002000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100902100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100902100000;
                current.Total40100902100000 = 0;
                if (current.cta_40100902101000 != null)
                    current.Total40100902100000 += (Decimal)current.cta_40100902101000;
                if (current.cta_40100902102000 != null)
                    current.Total40100902100000 += (Decimal)current.cta_40100902102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100902200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100902200000;
                current.Total40100902200000 = 0;
                if (current.cta_40100902201000 != null)
                    current.Total40100902200000 += (Decimal)current.cta_40100902201000;
                if (current.cta_40100902202000 != null)
                    current.Total40100902200000 += (Decimal)current.cta_40100902202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100902300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100902300000;
                current.Total40100902300000 = 0;
                if (current.cta_40100902301000 != null)
                    current.Total40100902300000 += (Decimal)current.cta_40100902301000;
                if (current.cta_40100902302000 != null)
                    current.Total40100902300000 += (Decimal)current.cta_40100902302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100902500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100902500000;
                current.Total40100902500000 = 0;
                if (current.cta_40100902501000 != null)
                    current.Total40100902500000 += (Decimal)current.cta_40100902501000;
                if (current.cta_40100902502000 != null)
                    current.Total40100902500000 += (Decimal)current.cta_40100902502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100909900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000.cta_40100909900000;
                current.Total40100909900000 = 0;
                if (current.cta_40100909901000 != null)
                    current.Total40100909900000 += (Decimal)current.cta_40100909901000;
                if (current.cta_40100909902000 != null)
                    current.Total40100909900000 += (Decimal)current.cta_40100909902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null && modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000.cta_40100900000000;
                current.Total40100900000000 = 0;
                if (current.cta_40100900700000 != null && current.cta_40100900700000.Total40100900700000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100900700000.Total40100900700000;
                if (current.cta_40100900800000 != null && current.cta_40100900800000.Total40100900800000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100900800000.Total40100900800000;
                if (current.cta_40100901000000 != null && current.cta_40100901000000.Total40100901000000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100901000000.Total40100901000000;
                if (current.cta_40100901100000 != null && current.cta_40100901100000.Total40100901100000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100901100000.Total40100901100000;
                if (current.cta_40100901200000 != null && current.cta_40100901200000.Total40100901200000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100901200000.Total40100901200000;
                if (current.cta_40100901300000 != null && current.cta_40100901300000.Total40100901300000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100901300000.Total40100901300000;
                if (current.cta_40100901400000 != null && current.cta_40100901400000.Total40100901400000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100901400000.Total40100901400000;
                if (current.cta_40100901700000 != null && current.cta_40100901700000.Total40100901700000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100901700000.Total40100901700000;
                if (current.cta_40100901800000 != null && current.cta_40100901800000.Total40100901800000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100901800000.Total40100901800000;
                if (current.cta_40100902000000 != null && current.cta_40100902000000.Total40100902000000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100902000000.Total40100902000000;
                if (current.cta_40100902100000 != null && current.cta_40100902100000.Total40100902100000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100902100000.Total40100902100000;
                if (current.cta_40100902200000 != null && current.cta_40100902200000.Total40100902200000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100902200000.Total40100902200000;
                if (current.cta_40100902300000 != null && current.cta_40100902300000.Total40100902300000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100902300000.Total40100902300000;
                if (current.cta_40100902500000 != null && current.cta_40100902500000.Total40100902500000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100902500000.Total40100902500000;
                if (current.cta_40100909900000 != null && current.cta_40100909900000.Total40100909900000 != 0)
                    current.Total40100900000000 += (Decimal)current.cta_40100909900000.Total40100909900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40100000000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40100000000000;
                current.Total40100000000000 = 0;
                if (current.cta_40101000000000 != null && current.cta_40101000000000.Total40101000000000 != 0)
                    current.Total40100000000000 += (Decimal)current.cta_40101000000000.Total40101000000000;
                if (current.cta_40102000000000 != null && current.cta_40102000000000.Total40102000000000 != 0)
                    current.Total40100000000000 += (Decimal)current.cta_40102000000000.Total40102000000000;
                if (current.cta_40100100000000 != null && current.cta_40100100000000.Total40100100000000 != 0)
                    current.Total40100000000000 += (Decimal)current.cta_40100100000000.Total40100100000000;
                if (current.cta_40100300000000 != null && current.cta_40100300000000.Total40100300000000 != 0)
                    current.Total40100000000000 += (Decimal)current.cta_40100300000000.Total40100300000000;
                if (current.cta_40100400000000 != null && current.cta_40100400000000.Total40100400000000 != 0)
                    current.Total40100000000000 += (Decimal)current.cta_40100400000000.Total40100400000000;
                if (current.cta_40100500000000 != null && current.cta_40100500000000.Total40100500000000 != 0)
                    current.Total40100000000000 += (Decimal)current.cta_40100500000000.Total40100500000000;
                if (current.cta_40100600000000 != null && current.cta_40100600000000.Total40100600000000 != 0)
                    current.Total40100000000000 += (Decimal)current.cta_40100600000000.Total40100600000000;
                if (current.cta_40100700000000 != null && current.cta_40100700000000.Total40100700000000 != 0)
                    current.Total40100000000000 += (Decimal)current.cta_40100700000000.Total40100700000000;
                if (current.cta_40100800000000 != null && current.cta_40100800000000.Total40100800000000 != 0)
                    current.Total40100000000000 += (Decimal)current.cta_40100800000000.Total40100800000000;
                if (current.cta_40100900000000 != null && current.cta_40100900000000.Total40100900000000 != 0)
                    current.Total40100000000000 += (Decimal)current.cta_40100900000000.Total40100900000000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100100000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100100000.cta_40200100101000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100100000.cta_40200100101000;
                current.Total40200100101000 = 0;
                if (current.cta_40200100101010 != null)
                    current.Total40200100101000 += (Decimal)current.cta_40200100101010;
                if (current.cta_40200100101020 != null)
                    current.Total40200100101000 += (Decimal)current.cta_40200100101020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100100000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100100000.cta_40200100102000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100100000.cta_40200100102000;
                current.Total40200100102000 = 0;
                if (current.cta_40200100102010 != null)
                    current.Total40200100102000 += (Decimal)current.cta_40200100102010;
                if (current.cta_40200100102020 != null)
                    current.Total40200100102000 += (Decimal)current.cta_40200100102020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100100000;
                current.Total40200100100000 = 0;
                if (current.cta_40200100101000 != null && current.cta_40200100101000.Total40200100101000 != 0)
                    current.Total40200100100000 += (Decimal)current.cta_40200100101000.Total40200100101000;
                if (current.cta_40200100102000 != null && current.cta_40200100102000.Total40200100102000 != 0)
                    current.Total40200100100000 += (Decimal)current.cta_40200100102000.Total40200100102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100200000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100200000.cta_40200100201000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100200000.cta_40200100201000;
                current.Total40200100201000 = 0;
                if (current.cta_40200100201010 != null)
                    current.Total40200100201000 += (Decimal)current.cta_40200100201010;
                if (current.cta_40200100201020 != null)
                    current.Total40200100201000 += (Decimal)current.cta_40200100201020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100200000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100200000.cta_40200100202000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100200000.cta_40200100202000;
                current.Total40200100202000 = 0;
                if (current.cta_40200100202010 != null)
                    current.Total40200100202000 += (Decimal)current.cta_40200100202010;
                if (current.cta_40200100202020 != null)
                    current.Total40200100202000 += (Decimal)current.cta_40200100202020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100200000;
                current.Total40200100200000 = 0;
                if (current.cta_40200100201000 != null && current.cta_40200100201000.Total40200100201000 != 0)
                    current.Total40200100200000 += (Decimal)current.cta_40200100201000.Total40200100201000;
                if (current.cta_40200100202000 != null && current.cta_40200100202000.Total40200100202000 != 0)
                    current.Total40200100200000 += (Decimal)current.cta_40200100202000.Total40200100202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100300000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100300000.cta_40200100301000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100300000.cta_40200100301000;
                current.Total40200100301000 = 0;
                if (current.cta_40200100301010 != null)
                    current.Total40200100301000 += (Decimal)current.cta_40200100301010;
                if (current.cta_40200100301020 != null)
                    current.Total40200100301000 += (Decimal)current.cta_40200100301020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100300000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100300000.cta_40200100302000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100300000.cta_40200100302000;
                current.Total40200100302000 = 0;
                if (current.cta_40200100302010 != null)
                    current.Total40200100302000 += (Decimal)current.cta_40200100302010;
                if (current.cta_40200100302020 != null)
                    current.Total40200100302000 += (Decimal)current.cta_40200100302020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000.cta_40200100300000;
                current.Total40200100300000 = 0;
                if (current.cta_40200100301000 != null && current.cta_40200100301000.Total40200100301000 != 0)
                    current.Total40200100300000 += (Decimal)current.cta_40200100301000.Total40200100301000;
                if (current.cta_40200100302000 != null && current.cta_40200100302000.Total40200100302000 != 0)
                    current.Total40200100300000 += (Decimal)current.cta_40200100302000.Total40200100302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200100000000;
                current.Total40200100000000 = 0;
                if (current.cta_40200100100000 != null && current.cta_40200100100000.Total40200100100000 != 0)
                    current.Total40200100000000 += (Decimal)current.cta_40200100100000.Total40200100100000;
                if (current.cta_40200100200000 != null && current.cta_40200100200000.Total40200100200000 != 0)
                    current.Total40200100000000 += (Decimal)current.cta_40200100200000.Total40200100200000;
                if (current.cta_40200100300000 != null && current.cta_40200100300000.Total40200100300000 != 0)
                    current.Total40200100000000 += (Decimal)current.cta_40200100300000.Total40200100300000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200100000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200100000.cta_40200200101000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200100000.cta_40200200101000;
                current.Total40200200101000 = 0;
                if (current.cta_40200200101010 != null)
                    current.Total40200200101000 += (Decimal)current.cta_40200200101010;
                if (current.cta_40200200101020 != null)
                    current.Total40200200101000 += (Decimal)current.cta_40200200101020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200100000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200100000.cta_40200200102000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200100000.cta_40200200102000;
                current.Total40200200102000 = 0;
                if (current.cta_40200200102010 != null)
                    current.Total40200200102000 += (Decimal)current.cta_40200200102010;
                if (current.cta_40200200102020 != null)
                    current.Total40200200102000 += (Decimal)current.cta_40200200102020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200100000;
                current.Total40200200100000 = 0;
                if (current.cta_40200200101000 != null && current.cta_40200200101000.Total40200200101000 != 0)
                    current.Total40200200100000 += (Decimal)current.cta_40200200101000.Total40200200101000;
                if (current.cta_40200200102000 != null && current.cta_40200200102000.Total40200200102000 != 0)
                    current.Total40200200100000 += (Decimal)current.cta_40200200102000.Total40200200102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200200000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200200000.cta_40200200201000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200200000.cta_40200200201000;
                current.Total40200200201000 = 0;
                if (current.cta_40200200201010 != null)
                    current.Total40200200201000 += (Decimal)current.cta_40200200201010;
                if (current.cta_40200200201020 != null)
                    current.Total40200200201000 += (Decimal)current.cta_40200200201020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200200000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200200000.cta_40200200202000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200200000.cta_40200200202000;
                current.Total40200200202000 = 0;
                if (current.cta_40200200202010 != null)
                    current.Total40200200202000 += (Decimal)current.cta_40200200202010;
                if (current.cta_40200200202020 != null)
                    current.Total40200200202000 += (Decimal)current.cta_40200200202020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000.cta_40200200200000;
                current.Total40200200200000 = 0;
                if (current.cta_40200200201000 != null && current.cta_40200200201000.Total40200200201000 != 0)
                    current.Total40200200200000 += (Decimal)current.cta_40200200201000.Total40200200201000;
                if (current.cta_40200200202000 != null && current.cta_40200200202000.Total40200200202000 != 0)
                    current.Total40200200200000 += (Decimal)current.cta_40200200202000.Total40200200202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200200000000;
                current.Total40200200000000 = 0;
                if (current.cta_40200200100000 != null && current.cta_40200200100000.Total40200200100000 != 0)
                    current.Total40200200000000 += (Decimal)current.cta_40200200100000.Total40200200100000;
                if (current.cta_40200200200000 != null && current.cta_40200200200000.Total40200200200000 != 0)
                    current.Total40200200000000 += (Decimal)current.cta_40200200200000.Total40200200200000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300100000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300100000.cta_40200300101000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300100000.cta_40200300101000;
                current.Total40200300101000 = 0;
                if (current.cta_40200300101010 != null)
                    current.Total40200300101000 += (Decimal)current.cta_40200300101010;
                if (current.cta_40200300101020 != null)
                    current.Total40200300101000 += (Decimal)current.cta_40200300101020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300100000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300100000.cta_40200300102000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300100000.cta_40200300102000;
                current.Total40200300102000 = 0;
                if (current.cta_40200300102010 != null)
                    current.Total40200300102000 += (Decimal)current.cta_40200300102010;
                if (current.cta_40200300102020 != null)
                    current.Total40200300102000 += (Decimal)current.cta_40200300102020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300100000;
                current.Total40200300100000 = 0;
                if (current.cta_40200300101000 != null && current.cta_40200300101000.Total40200300101000 != 0)
                    current.Total40200300100000 += (Decimal)current.cta_40200300101000.Total40200300101000;
                if (current.cta_40200300102000 != null && current.cta_40200300102000.Total40200300102000 != 0)
                    current.Total40200300100000 += (Decimal)current.cta_40200300102000.Total40200300102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300200000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300200000.cta_40200300201000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300200000.cta_40200300201000;
                current.Total40200300201000 = 0;
                if (current.cta_40200300201010 != null)
                    current.Total40200300201000 += (Decimal)current.cta_40200300201010;
                if (current.cta_40200300201020 != null)
                    current.Total40200300201000 += (Decimal)current.cta_40200300201020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300200000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300200000.cta_40200300202000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300200000.cta_40200300202000;
                current.Total40200300202000 = 0;
                if (current.cta_40200300202010 != null)
                    current.Total40200300202000 += (Decimal)current.cta_40200300202010;
                if (current.cta_40200300202020 != null)
                    current.Total40200300202000 += (Decimal)current.cta_40200300202020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000.cta_40200300200000;
                current.Total40200300200000 = 0;
                if (current.cta_40200300201000 != null && current.cta_40200300201000.Total40200300201000 != 0)
                    current.Total40200300200000 += (Decimal)current.cta_40200300201000.Total40200300201000;
                if (current.cta_40200300202000 != null && current.cta_40200300202000.Total40200300202000 != 0)
                    current.Total40200300200000 += (Decimal)current.cta_40200300202000.Total40200300202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200300000000;
                current.Total40200300000000 = 0;
                if (current.cta_40200300100000 != null && current.cta_40200300100000.Total40200300100000 != 0)
                    current.Total40200300000000 += (Decimal)current.cta_40200300100000.Total40200300100000;
                if (current.cta_40200300200000 != null && current.cta_40200300200000.Total40200300200000 != 0)
                    current.Total40200300000000 += (Decimal)current.cta_40200300200000.Total40200300200000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200400000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200400000000.cta_40200400100000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200400000000.cta_40200400100000.cta_40200400101000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200400000000.cta_40200400100000.cta_40200400101000;
                current.Total40200400101000 = 0;
                if (current.cta_40200400101010 != null)
                    current.Total40200400101000 += (Decimal)current.cta_40200400101010;
                if (current.cta_40200400101020 != null)
                    current.Total40200400101000 += (Decimal)current.cta_40200400101020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200400000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200400000000.cta_40200400100000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200400000000.cta_40200400100000.cta_40200400102000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200400000000.cta_40200400100000.cta_40200400102000;
                current.Total40200400102000 = 0;
                if (current.cta_40200400102010 != null)
                    current.Total40200400102000 += (Decimal)current.cta_40200400102010;
                if (current.cta_40200400102020 != null)
                    current.Total40200400102000 += (Decimal)current.cta_40200400102020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200400000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200400000000.cta_40200400100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200400000000.cta_40200400100000;
                current.Total40200400100000 = 0;
                if (current.cta_40200400101000 != null && current.cta_40200400101000.Total40200400101000 != 0)
                    current.Total40200400100000 += (Decimal)current.cta_40200400101000.Total40200400101000;
                if (current.cta_40200400102000 != null && current.cta_40200400102000.Total40200400102000 != 0)
                    current.Total40200400100000 += (Decimal)current.cta_40200400102000.Total40200400102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null && modelo.cta_40000000000000.cta_40200000000000.cta_40200400000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000.cta_40200400000000;
                current.Total40200400000000 = 0;
                if (current.cta_40200400100000 != null && current.cta_40200400100000.Total40200400100000 != 0)
                    current.Total40200400000000 += (Decimal)current.cta_40200400100000.Total40200400100000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40200000000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40200000000000;
                current.Total40200000000000 = 0;
                if (current.cta_40200100000000 != null && current.cta_40200100000000.Total40200100000000 != 0)
                    current.Total40200000000000 += (Decimal)current.cta_40200100000000.Total40200100000000;
                if (current.cta_40200200000000 != null && current.cta_40200200000000.Total40200200000000 != 0)
                    current.Total40200000000000 += (Decimal)current.cta_40200200000000.Total40200200000000;
                if (current.cta_40200300000000 != null && current.cta_40200300000000.Total40200300000000 != 0)
                    current.Total40200000000000 += (Decimal)current.cta_40200300000000.Total40200300000000;
                if (current.cta_40200400000000 != null && current.cta_40200400000000.Total40200400000000 != 0)
                    current.Total40200000000000 += (Decimal)current.cta_40200400000000.Total40200400000000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100100000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100100000.cta_40300100101000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100100000.cta_40300100101000;
                current.Total40300100101000 = 0;
                if (current.cta_40300100101010 != null)
                    current.Total40300100101000 += (Decimal)current.cta_40300100101010;
                if (current.cta_40300100101020 != null)
                    current.Total40300100101000 += (Decimal)current.cta_40300100101020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100100000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100100000.cta_40300100102000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100100000.cta_40300100102000;
                current.Total40300100102000 = 0;
                if (current.cta_40300100102010 != null)
                    current.Total40300100102000 += (Decimal)current.cta_40300100102010;
                if (current.cta_40300100102020 != null)
                    current.Total40300100102000 += (Decimal)current.cta_40300100102020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100100000;
                current.Total40300100100000 = 0;
                if (current.cta_40300100101000 != null && current.cta_40300100101000.Total40300100101000 != 0)
                    current.Total40300100100000 += (Decimal)current.cta_40300100101000.Total40300100101000;
                if (current.cta_40300100102000 != null && current.cta_40300100102000.Total40300100102000 != 0)
                    current.Total40300100100000 += (Decimal)current.cta_40300100102000.Total40300100102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100200000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100200000.cta_40300100201000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100200000.cta_40300100201000;
                current.Total40300100201000 = 0;
                if (current.cta_40300100201010 != null)
                    current.Total40300100201000 += (Decimal)current.cta_40300100201010;
                if (current.cta_40300100201020 != null)
                    current.Total40300100201000 += (Decimal)current.cta_40300100201020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100200000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100200000.cta_40300100202000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100200000.cta_40300100202000;
                current.Total40300100202000 = 0;
                if (current.cta_40300100202010 != null)
                    current.Total40300100202000 += (Decimal)current.cta_40300100202010;
                if (current.cta_40300100202020 != null)
                    current.Total40300100202000 += (Decimal)current.cta_40300100202020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000.cta_40300100200000;
                current.Total40300100200000 = 0;
                if (current.cta_40300100201000 != null && current.cta_40300100201000.Total40300100201000 != 0)
                    current.Total40300100200000 += (Decimal)current.cta_40300100201000.Total40300100201000;
                if (current.cta_40300100202000 != null && current.cta_40300100202000.Total40300100202000 != 0)
                    current.Total40300100200000 += (Decimal)current.cta_40300100202000.Total40300100202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300100000000;
                current.Total40300100000000 = 0;
                if (current.cta_40300100100000 != null && current.cta_40300100100000.Total40300100100000 != 0)
                    current.Total40300100000000 += (Decimal)current.cta_40300100100000.Total40300100100000;
                if (current.cta_40300100200000 != null && current.cta_40300100200000.Total40300100200000 != 0)
                    current.Total40300100000000 += (Decimal)current.cta_40300100200000.Total40300100200000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200100000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200100000.cta_40300200101000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200100000.cta_40300200101000;
                current.Total40300200101000 = 0;
                if (current.cta_40300200101010 != null)
                    current.Total40300200101000 += (Decimal)current.cta_40300200101010;
                if (current.cta_40300200101020 != null)
                    current.Total40300200101000 += (Decimal)current.cta_40300200101020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200100000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200100000.cta_40300200102000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200100000.cta_40300200102000;
                current.Total40300200102000 = 0;
                if (current.cta_40300200102010 != null)
                    current.Total40300200102000 += (Decimal)current.cta_40300200102010;
                if (current.cta_40300200102020 != null)
                    current.Total40300200102000 += (Decimal)current.cta_40300200102020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200100000;
                current.Total40300200100000 = 0;
                if (current.cta_40300200101000 != null && current.cta_40300200101000.Total40300200101000 != 0)
                    current.Total40300200100000 += (Decimal)current.cta_40300200101000.Total40300200101000;
                if (current.cta_40300200102000 != null && current.cta_40300200102000.Total40300200102000 != 0)
                    current.Total40300200100000 += (Decimal)current.cta_40300200102000.Total40300200102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200200000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200200000.cta_40300200201000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200200000.cta_40300200201000;
                current.Total40300200201000 = 0;
                if (current.cta_40300200201010 != null)
                    current.Total40300200201000 += (Decimal)current.cta_40300200201010;
                if (current.cta_40300200201020 != null)
                    current.Total40300200201000 += (Decimal)current.cta_40300200201020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200200000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200200000.cta_40300200202000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200200000.cta_40300200202000;
                current.Total40300200202000 = 0;
                if (current.cta_40300200202010 != null)
                    current.Total40300200202000 += (Decimal)current.cta_40300200202010;
                if (current.cta_40300200202020 != null)
                    current.Total40300200202000 += (Decimal)current.cta_40300200202020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000.cta_40300200200000;
                current.Total40300200200000 = 0;
                if (current.cta_40300200201000 != null && current.cta_40300200201000.Total40300200201000 != 0)
                    current.Total40300200200000 += (Decimal)current.cta_40300200201000.Total40300200201000;
                if (current.cta_40300200202000 != null && current.cta_40300200202000.Total40300200202000 != 0)
                    current.Total40300200200000 += (Decimal)current.cta_40300200202000.Total40300200202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300200000000;
                current.Total40300200000000 = 0;
                if (current.cta_40300200100000 != null && current.cta_40300200100000.Total40300200100000 != 0)
                    current.Total40300200000000 += (Decimal)current.cta_40300200100000.Total40300200100000;
                if (current.cta_40300200200000 != null && current.cta_40300200200000.Total40300200200000 != 0)
                    current.Total40300200000000 += (Decimal)current.cta_40300200200000.Total40300200200000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300300000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300300000000.cta_40300300100000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300300000000.cta_40300300100000.cta_40300300101000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300300000000.cta_40300300100000.cta_40300300101000;
                current.Total40300300101000 = 0;
                if (current.cta_40300300101010 != null)
                    current.Total40300300101000 += (Decimal)current.cta_40300300101010;
                if (current.cta_40300300101020 != null)
                    current.Total40300300101000 += (Decimal)current.cta_40300300101020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300300000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300300000000.cta_40300300100000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300300000000.cta_40300300100000.cta_40300300102000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300300000000.cta_40300300100000.cta_40300300102000;
                current.Total40300300102000 = 0;
                if (current.cta_40300300102010 != null)
                    current.Total40300300102000 += (Decimal)current.cta_40300300102010;
                if (current.cta_40300300102020 != null)
                    current.Total40300300102000 += (Decimal)current.cta_40300300102020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300300000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300300000000.cta_40300300100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300300000000.cta_40300300100000;
                current.Total40300300100000 = 0;
                if (current.cta_40300300101000 != null && current.cta_40300300101000.Total40300300101000 != 0)
                    current.Total40300300100000 += (Decimal)current.cta_40300300101000.Total40300300101000;
                if (current.cta_40300300102000 != null && current.cta_40300300102000.Total40300300102000 != 0)
                    current.Total40300300100000 += (Decimal)current.cta_40300300102000.Total40300300102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300300000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300300000000;
                current.Total40300300000000 = 0;
                if (current.cta_40300300100000 != null && current.cta_40300300100000.Total40300300100000 != 0)
                    current.Total40300300000000 += (Decimal)current.cta_40300300100000.Total40300300100000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300400000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300400000000.cta_40300400100000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300400000000.cta_40300400100000.cta_40300400101000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300400000000.cta_40300400100000.cta_40300400101000;
                current.Total40300400101000 = 0;
                if (current.cta_40300400101010 != null)
                    current.Total40300400101000 += (Decimal)current.cta_40300400101010;
                if (current.cta_40300400101020 != null)
                    current.Total40300400101000 += (Decimal)current.cta_40300400101020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300400000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300400000000.cta_40300400100000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300400000000.cta_40300400100000.cta_40300400102000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300400000000.cta_40300400100000.cta_40300400102000;
                current.Total40300400102000 = 0;
                if (current.cta_40300400102010 != null)
                    current.Total40300400102000 += (Decimal)current.cta_40300400102010;
                if (current.cta_40300400102020 != null)
                    current.Total40300400102000 += (Decimal)current.cta_40300400102020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300400000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300400000000.cta_40300400100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300400000000.cta_40300400100000;
                current.Total40300400100000 = 0;
                if (current.cta_40300400101000 != null && current.cta_40300400101000.Total40300400101000 != 0)
                    current.Total40300400100000 += (Decimal)current.cta_40300400101000.Total40300400101000;
                if (current.cta_40300400102000 != null && current.cta_40300400102000.Total40300400102000 != 0)
                    current.Total40300400100000 += (Decimal)current.cta_40300400102000.Total40300400102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300400000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300400000000;
                current.Total40300400000000 = 0;
                if (current.cta_40300400100000 != null && current.cta_40300400100000.Total40300400100000 != 0)
                    current.Total40300400000000 += (Decimal)current.cta_40300400100000.Total40300400100000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300500000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300500000000.cta_40300500100000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300500000000.cta_40300500100000.cta_40300500101000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300500000000.cta_40300500100000.cta_40300500101000;
                current.Total40300500101000 = 0;
                if (current.cta_40300500101010 != null)
                    current.Total40300500101000 += (Decimal)current.cta_40300500101010;
                if (current.cta_40300500101020 != null)
                    current.Total40300500101000 += (Decimal)current.cta_40300500101020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300500000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300500000000.cta_40300500100000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300500000000.cta_40300500100000.cta_40300500102000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300500000000.cta_40300500100000.cta_40300500102000;
                current.Total40300500102000 = 0;
                if (current.cta_40300500102010 != null)
                    current.Total40300500102000 += (Decimal)current.cta_40300500102010;
                if (current.cta_40300500102020 != null)
                    current.Total40300500102000 += (Decimal)current.cta_40300500102020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300500000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300500000000.cta_40300500100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300500000000.cta_40300500100000;
                current.Total40300500100000 = 0;
                if (current.cta_40300500101000 != null && current.cta_40300500101000.Total40300500101000 != 0)
                    current.Total40300500100000 += (Decimal)current.cta_40300500101000.Total40300500101000;
                if (current.cta_40300500102000 != null && current.cta_40300500102000.Total40300500102000 != 0)
                    current.Total40300500100000 += (Decimal)current.cta_40300500102000.Total40300500102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null && modelo.cta_40000000000000.cta_40300000000000.cta_40300500000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000.cta_40300500000000;
                current.Total40300500000000 = 0;
                if (current.cta_40300500100000 != null && current.cta_40300500100000.Total40300500100000 != 0)
                    current.Total40300500000000 += (Decimal)current.cta_40300500100000.Total40300500100000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40300000000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40300000000000;
                current.Total40300000000000 = 0;
                if (current.cta_40300100000000 != null && current.cta_40300100000000.Total40300100000000 != 0)
                    current.Total40300000000000 += (Decimal)current.cta_40300100000000.Total40300100000000;
                if (current.cta_40300200000000 != null && current.cta_40300200000000.Total40300200000000 != 0)
                    current.Total40300000000000 += (Decimal)current.cta_40300200000000.Total40300200000000;
                if (current.cta_40300300000000 != null && current.cta_40300300000000.Total40300300000000 != 0)
                    current.Total40300000000000 += (Decimal)current.cta_40300300000000.Total40300300000000;
                if (current.cta_40300400000000 != null && current.cta_40300400000000.Total40300400000000 != 0)
                    current.Total40300000000000 += (Decimal)current.cta_40300400000000.Total40300400000000;
                if (current.cta_40300500000000 != null && current.cta_40300500000000.Total40300500000000 != 0)
                    current.Total40300000000000 += (Decimal)current.cta_40300500000000.Total40300500000000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100100000;
                current.Total40500100100000 = 0;
                if (current.cta_40500100101000 != null)
                    current.Total40500100100000 += (Decimal)current.cta_40500100101000;
                if (current.cta_40500100102000 != null)
                    current.Total40500100100000 += (Decimal)current.cta_40500100102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100200000;
                current.Total40500100200000 = 0;
                if (current.cta_40500100201000 != null)
                    current.Total40500100200000 += (Decimal)current.cta_40500100201000;
                if (current.cta_40500100202000 != null)
                    current.Total40500100200000 += (Decimal)current.cta_40500100202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100300000;
                current.Total40500100300000 = 0;
                if (current.cta_40500100301000 != null)
                    current.Total40500100300000 += (Decimal)current.cta_40500100301000;
                if (current.cta_40500100302000 != null)
                    current.Total40500100300000 += (Decimal)current.cta_40500100302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100500000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100500000.cta_40500100501000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100500000.cta_40500100501000;
                current.Total40500100501000 = 0;
                if (current.cta_40500100501010 != null)
                    current.Total40500100501000 += (Decimal)current.cta_40500100501010;
                if (current.cta_40500100501020 != null)
                    current.Total40500100501000 += (Decimal)current.cta_40500100501020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100500000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100500000.cta_40500100502000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100500000.cta_40500100502000;
                current.Total40500100502000 = 0;
                if (current.cta_40500100502010 != null)
                    current.Total40500100502000 += (Decimal)current.cta_40500100502010;
                if (current.cta_40500100502020 != null)
                    current.Total40500100502000 += (Decimal)current.cta_40500100502020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100500000;
                current.Total40500100500000 = 0;
                if (current.cta_40500100501000 != null && current.cta_40500100501000.Total40500100501000 != 0)
                    current.Total40500100500000 += (Decimal)current.cta_40500100501000.Total40500100501000;
                if (current.cta_40500100502000 != null && current.cta_40500100502000.Total40500100502000 != 0)
                    current.Total40500100500000 += (Decimal)current.cta_40500100502000.Total40500100502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100600000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100600000.cta_40500100601000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100600000.cta_40500100601000;
                current.Total40500100601000 = 0;
                if (current.cta_40500100601010 != null)
                    current.Total40500100601000 += (Decimal)current.cta_40500100601010;
                if (current.cta_40500100601020 != null)
                    current.Total40500100601000 += (Decimal)current.cta_40500100601020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100600000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100600000.cta_40500100602000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100600000.cta_40500100602000;
                current.Total40500100602000 = 0;
                if (current.cta_40500100602010 != null)
                    current.Total40500100602000 += (Decimal)current.cta_40500100602010;
                if (current.cta_40500100602020 != null)
                    current.Total40500100602000 += (Decimal)current.cta_40500100602020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000.cta_40500100600000;
                current.Total40500100600000 = 0;
                if (current.cta_40500100601000 != null && current.cta_40500100601000.Total40500100601000 != 0)
                    current.Total40500100600000 += (Decimal)current.cta_40500100601000.Total40500100601000;
                if (current.cta_40500100602000 != null && current.cta_40500100602000.Total40500100602000 != 0)
                    current.Total40500100600000 += (Decimal)current.cta_40500100602000.Total40500100602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500100000000;
                current.Total40500100000000 = 0;
                if (current.cta_40500100100000 != null && current.cta_40500100100000.Total40500100100000 != 0)
                    current.Total40500100000000 += (Decimal)current.cta_40500100100000.Total40500100100000;
                if (current.cta_40500100200000 != null && current.cta_40500100200000.Total40500100200000 != 0)
                    current.Total40500100000000 += (Decimal)current.cta_40500100200000.Total40500100200000;
                if (current.cta_40500100300000 != null && current.cta_40500100300000.Total40500100300000 != 0)
                    current.Total40500100000000 += (Decimal)current.cta_40500100300000.Total40500100300000;
                if (current.cta_40500100500000 != null && current.cta_40500100500000.Total40500100500000 != 0)
                    current.Total40500100000000 += (Decimal)current.cta_40500100500000.Total40500100500000;
                if (current.cta_40500100600000 != null && current.cta_40500100600000.Total40500100600000 != 0)
                    current.Total40500100000000 += (Decimal)current.cta_40500100600000.Total40500100600000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000.cta_40500200200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000.cta_40500200200000;
                current.Total40500200200000 = 0;
                if (current.cta_40500200201000 != null)
                    current.Total40500200200000 += (Decimal)current.cta_40500200201000;
                if (current.cta_40500200202000 != null)
                    current.Total40500200200000 += (Decimal)current.cta_40500200202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000.cta_40500200300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000.cta_40500200300000;
                current.Total40500200300000 = 0;
                if (current.cta_40500200301000 != null)
                    current.Total40500200300000 += (Decimal)current.cta_40500200301000;
                if (current.cta_40500200302000 != null)
                    current.Total40500200300000 += (Decimal)current.cta_40500200302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000.cta_40500200400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000.cta_40500200400000;
                current.Total40500200400000 = 0;
                if (current.cta_40500200401000 != null)
                    current.Total40500200400000 += (Decimal)current.cta_40500200401000;
                if (current.cta_40500200402000 != null)
                    current.Total40500200400000 += (Decimal)current.cta_40500200402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000.cta_40500200500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000.cta_40500200500000;
                current.Total40500200500000 = 0;
                if (current.cta_40500200501000 != null)
                    current.Total40500200500000 += (Decimal)current.cta_40500200501000;
                if (current.cta_40500200502000 != null)
                    current.Total40500200500000 += (Decimal)current.cta_40500200502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000.cta_40500200600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000.cta_40500200600000;
                current.Total40500200600000 = 0;
                if (current.cta_40500200601000 != null)
                    current.Total40500200600000 += (Decimal)current.cta_40500200601000;
                if (current.cta_40500200602000 != null)
                    current.Total40500200600000 += (Decimal)current.cta_40500200602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500200000000;
                current.Total40500200000000 = 0;
                if (current.cta_40500200200000 != null && current.cta_40500200200000.Total40500200200000 != 0)
                    current.Total40500200000000 += (Decimal)current.cta_40500200200000.Total40500200200000;
                if (current.cta_40500200300000 != null && current.cta_40500200300000.Total40500200300000 != 0)
                    current.Total40500200000000 += (Decimal)current.cta_40500200300000.Total40500200300000;
                if (current.cta_40500200400000 != null && current.cta_40500200400000.Total40500200400000 != 0)
                    current.Total40500200000000 += (Decimal)current.cta_40500200400000.Total40500200400000;
                if (current.cta_40500200500000 != null && current.cta_40500200500000.Total40500200500000 != 0)
                    current.Total40500200000000 += (Decimal)current.cta_40500200500000.Total40500200500000;
                if (current.cta_40500200600000 != null && current.cta_40500200600000.Total40500200600000 != 0)
                    current.Total40500200000000 += (Decimal)current.cta_40500200600000.Total40500200600000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500300000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500300000000.cta_40500300100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500300000000.cta_40500300100000;
                current.Total40500300100000 = 0;
                if (current.cta_40500300101000 != null)
                    current.Total40500300100000 += (Decimal)current.cta_40500300101000;
                if (current.cta_40500300102000 != null)
                    current.Total40500300100000 += (Decimal)current.cta_40500300102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500300000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500300000000;
                current.Total40500300000000 = 0;
                if (current.cta_40500300100000 != null && current.cta_40500300100000.Total40500300100000 != 0)
                    current.Total40500300000000 += (Decimal)current.cta_40500300100000.Total40500300100000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400100000;
                current.Total40500400100000 = 0;
                if (current.cta_40500400101000 != null)
                    current.Total40500400100000 += (Decimal)current.cta_40500400101000;
                if (current.cta_40500400102000 != null)
                    current.Total40500400100000 += (Decimal)current.cta_40500400102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400200000;
                current.Total40500400200000 = 0;
                if (current.cta_40500400201000 != null)
                    current.Total40500400200000 += (Decimal)current.cta_40500400201000;
                if (current.cta_40500400202000 != null)
                    current.Total40500400200000 += (Decimal)current.cta_40500400202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400300000;
                current.Total40500400300000 = 0;
                if (current.cta_40500400301000 != null)
                    current.Total40500400300000 += (Decimal)current.cta_40500400301000;
                if (current.cta_40500400302000 != null)
                    current.Total40500400300000 += (Decimal)current.cta_40500400302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400400000;
                current.Total40500400400000 = 0;
                if (current.cta_40500400401000 != null)
                    current.Total40500400400000 += (Decimal)current.cta_40500400401000;
                if (current.cta_40500400402000 != null)
                    current.Total40500400400000 += (Decimal)current.cta_40500400402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400500000;
                current.Total40500400500000 = 0;
                if (current.cta_40500400501000 != null)
                    current.Total40500400500000 += (Decimal)current.cta_40500400501000;
                if (current.cta_40500400502000 != null)
                    current.Total40500400500000 += (Decimal)current.cta_40500400502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400600000;
                current.Total40500400600000 = 0;
                if (current.cta_40500400601000 != null)
                    current.Total40500400600000 += (Decimal)current.cta_40500400601000;
                if (current.cta_40500400602000 != null)
                    current.Total40500400600000 += (Decimal)current.cta_40500400602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400700000;
                current.Total40500400700000 = 0;
                if (current.cta_40500400701000 != null)
                    current.Total40500400700000 += (Decimal)current.cta_40500400701000;
                if (current.cta_40500400702000 != null)
                    current.Total40500400700000 += (Decimal)current.cta_40500400702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500400800000;
                current.Total40500400800000 = 0;
                if (current.cta_40500400801000 != null)
                    current.Total40500400800000 += (Decimal)current.cta_40500400801000;
                if (current.cta_40500400802000 != null)
                    current.Total40500400800000 += (Decimal)current.cta_40500400802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500401000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500401000000;
                current.Total40500401000000 = 0;
                if (current.cta_40500401001000 != null)
                    current.Total40500401000000 += (Decimal)current.cta_40500401001000;
                if (current.cta_40500401002000 != null)
                    current.Total40500401000000 += (Decimal)current.cta_40500401002000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500401100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500401100000;
                current.Total40500401100000 = 0;
                if (current.cta_40500401101000 != null)
                    current.Total40500401100000 += (Decimal)current.cta_40500401101000;
                if (current.cta_40500401102000 != null)
                    current.Total40500401100000 += (Decimal)current.cta_40500401102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500401200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500401200000;
                current.Total40500401200000 = 0;
                if (current.cta_40500401201000 != null)
                    current.Total40500401200000 += (Decimal)current.cta_40500401201000;
                if (current.cta_40500401202000 != null)
                    current.Total40500401200000 += (Decimal)current.cta_40500401202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500401300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500401300000;
                current.Total40500401300000 = 0;
                if (current.cta_40500401301000 != null)
                    current.Total40500401300000 += (Decimal)current.cta_40500401301000;
                if (current.cta_40500401302000 != null)
                    current.Total40500401300000 += (Decimal)current.cta_40500401302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500409900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000.cta_40500409900000;
                current.Total40500409900000 = 0;
                if (current.cta_40500409901000 != null)
                    current.Total40500409900000 += (Decimal)current.cta_40500409901000;
                if (current.cta_40500409902000 != null)
                    current.Total40500409900000 += (Decimal)current.cta_40500409902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null && modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000.cta_40500400000000;
                current.Total40500400000000 = 0;
                if (current.cta_40500400100000 != null && current.cta_40500400100000.Total40500400100000 != 0)
                    current.Total40500400000000 += (Decimal)current.cta_40500400100000.Total40500400100000;
                if (current.cta_40500400200000 != null && current.cta_40500400200000.Total40500400200000 != 0)
                    current.Total40500400000000 += (Decimal)current.cta_40500400200000.Total40500400200000;
                if (current.cta_40500400300000 != null && current.cta_40500400300000.Total40500400300000 != 0)
                    current.Total40500400000000 += (Decimal)current.cta_40500400300000.Total40500400300000;
                if (current.cta_40500400400000 != null && current.cta_40500400400000.Total40500400400000 != 0)
                    current.Total40500400000000 += (Decimal)current.cta_40500400400000.Total40500400400000;
                if (current.cta_40500400500000 != null && current.cta_40500400500000.Total40500400500000 != 0)
                    current.Total40500400000000 += (Decimal)current.cta_40500400500000.Total40500400500000;
                if (current.cta_40500400600000 != null && current.cta_40500400600000.Total40500400600000 != 0)
                    current.Total40500400000000 += (Decimal)current.cta_40500400600000.Total40500400600000;
                if (current.cta_40500400700000 != null && current.cta_40500400700000.Total40500400700000 != 0)
                    current.Total40500400000000 += (Decimal)current.cta_40500400700000.Total40500400700000;
                if (current.cta_40500400800000 != null && current.cta_40500400800000.Total40500400800000 != 0)
                    current.Total40500400000000 += (Decimal)current.cta_40500400800000.Total40500400800000;
                if (current.cta_40500401000000 != null && current.cta_40500401000000.Total40500401000000 != 0)
                    current.Total40500400000000 += (Decimal)current.cta_40500401000000.Total40500401000000;
                if (current.cta_40500401100000 != null && current.cta_40500401100000.Total40500401100000 != 0)
                    current.Total40500400000000 += (Decimal)current.cta_40500401100000.Total40500401100000;
                if (current.cta_40500401200000 != null && current.cta_40500401200000.Total40500401200000 != 0)
                    current.Total40500400000000 += (Decimal)current.cta_40500401200000.Total40500401200000;
                if (current.cta_40500401300000 != null && current.cta_40500401300000.Total40500401300000 != 0)
                    current.Total40500400000000 += (Decimal)current.cta_40500401300000.Total40500401300000;
                if (current.cta_40500409900000 != null && current.cta_40500409900000.Total40500409900000 != 0)
                    current.Total40500400000000 += (Decimal)current.cta_40500409900000.Total40500409900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40500000000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40500000000000;
                current.Total40500000000000 = 0;
                if (current.cta_40500100000000 != null && current.cta_40500100000000.Total40500100000000 != 0)
                    current.Total40500000000000 += (Decimal)current.cta_40500100000000.Total40500100000000;
                if (current.cta_40500200000000 != null && current.cta_40500200000000.Total40500200000000 != 0)
                    current.Total40500000000000 += (Decimal)current.cta_40500200000000.Total40500200000000;
                if (current.cta_40500300000000 != null && current.cta_40500300000000.Total40500300000000 != 0)
                    current.Total40500000000000 += (Decimal)current.cta_40500300000000.Total40500300000000;
                if (current.cta_40500400000000 != null && current.cta_40500400000000.Total40500400000000 != 0)
                    current.Total40500000000000 += (Decimal)current.cta_40500400000000.Total40500400000000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100100000;
                current.Total40600100100000 = 0;
                if (current.cta_40600100101000 != null)
                    current.Total40600100100000 += (Decimal)current.cta_40600100101000;
                if (current.cta_40600100102000 != null)
                    current.Total40600100100000 += (Decimal)current.cta_40600100102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100200000;
                current.Total40600100200000 = 0;
                if (current.cta_40600100201000 != null)
                    current.Total40600100200000 += (Decimal)current.cta_40600100201000;
                if (current.cta_40600100202000 != null)
                    current.Total40600100200000 += (Decimal)current.cta_40600100202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100300000;
                current.Total40600100300000 = 0;
                if (current.cta_40600100301000 != null)
                    current.Total40600100300000 += (Decimal)current.cta_40600100301000;
                if (current.cta_40600100302000 != null)
                    current.Total40600100300000 += (Decimal)current.cta_40600100302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100400000;
                current.Total40600100400000 = 0;
                if (current.cta_40600100401000 != null)
                    current.Total40600100400000 += (Decimal)current.cta_40600100401000;
                if (current.cta_40600100402000 != null)
                    current.Total40600100400000 += (Decimal)current.cta_40600100402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100500000;
                current.Total40600100500000 = 0;
                if (current.cta_40600100501000 != null)
                    current.Total40600100500000 += (Decimal)current.cta_40600100501000;
                if (current.cta_40600100502000 != null)
                    current.Total40600100500000 += (Decimal)current.cta_40600100502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100600000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100600000.cta_40600100601000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100600000.cta_40600100601000;
                current.Total40600100601000 = 0;
                if (current.cta_40600100601010 != null)
                    current.Total40600100601000 += (Decimal)current.cta_40600100601010;
                if (current.cta_40600100601020 != null)
                    current.Total40600100601000 += (Decimal)current.cta_40600100601020;
                if (current.cta_40600100601030 != null)
                    current.Total40600100601000 += (Decimal)current.cta_40600100601030;
                if (current.cta_40600100601040 != null)
                    current.Total40600100601000 += (Decimal)current.cta_40600100601040;
                if (current.cta_40600100601050 != null)
                    current.Total40600100601000 += (Decimal)current.cta_40600100601050;
                if (current.cta_40600100601990 != null)
                    current.Total40600100601000 += (Decimal)current.cta_40600100601990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100600000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100600000.cta_40600100602000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100600000.cta_40600100602000;
                current.Total40600100602000 = 0;
                if (current.cta_40600100602010 != null)
                    current.Total40600100602000 += (Decimal)current.cta_40600100602010;
                if (current.cta_40600100602020 != null)
                    current.Total40600100602000 += (Decimal)current.cta_40600100602020;
                if (current.cta_40600100602030 != null)
                    current.Total40600100602000 += (Decimal)current.cta_40600100602030;
                if (current.cta_40600100602040 != null)
                    current.Total40600100602000 += (Decimal)current.cta_40600100602040;
                if (current.cta_40600100602050 != null)
                    current.Total40600100602000 += (Decimal)current.cta_40600100602050;
                if (current.cta_40600100602990 != null)
                    current.Total40600100602000 += (Decimal)current.cta_40600100602990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100600000;
                current.Total40600100600000 = 0;
                if (current.cta_40600100601000 != null && current.cta_40600100601000.Total40600100601000 != 0)
                    current.Total40600100600000 += (Decimal)current.cta_40600100601000.Total40600100601000;
                if (current.cta_40600100602000 != null && current.cta_40600100602000.Total40600100602000 != 0)
                    current.Total40600100600000 += (Decimal)current.cta_40600100602000.Total40600100602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100800000;
                current.Total40600100800000 = 0;
                if (current.cta_40600100801000 != null)
                    current.Total40600100800000 += (Decimal)current.cta_40600100801000;
                if (current.cta_40600100802000 != null)
                    current.Total40600100800000 += (Decimal)current.cta_40600100802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100900000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100900000.cta_40600100901000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100900000.cta_40600100901000;
                current.Total40600100901000 = 0;
                if (current.cta_40600100901010 != null)
                    current.Total40600100901000 += (Decimal)current.cta_40600100901010;
                if (current.cta_40600100901020 != null)
                    current.Total40600100901000 += (Decimal)current.cta_40600100901020;
                if (current.cta_40600100901030 != null)
                    current.Total40600100901000 += (Decimal)current.cta_40600100901030;
                if (current.cta_40600100901040 != null)
                    current.Total40600100901000 += (Decimal)current.cta_40600100901040;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100900000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100900000.cta_40600100902000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100900000.cta_40600100902000;
                current.Total40600100902000 = 0;
                if (current.cta_40600100902010 != null)
                    current.Total40600100902000 += (Decimal)current.cta_40600100902010;
                if (current.cta_40600100902020 != null)
                    current.Total40600100902000 += (Decimal)current.cta_40600100902020;
                if (current.cta_40600100902030 != null)
                    current.Total40600100902000 += (Decimal)current.cta_40600100902030;
                if (current.cta_40600100902040 != null)
                    current.Total40600100902000 += (Decimal)current.cta_40600100902040;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600100900000;
                current.Total40600100900000 = 0;
                if (current.cta_40600100901000 != null && current.cta_40600100901000.Total40600100901000 != 0)
                    current.Total40600100900000 += (Decimal)current.cta_40600100901000.Total40600100901000;
                if (current.cta_40600100902000 != null && current.cta_40600100902000.Total40600100902000 != 0)
                    current.Total40600100900000 += (Decimal)current.cta_40600100902000.Total40600100902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600101100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600101100000;
                current.Total40600101100000 = 0;
                if (current.cta_40600101101000 != null)
                    current.Total40600101100000 += (Decimal)current.cta_40600101101000;
                if (current.cta_40600101102000 != null)
                    current.Total40600101100000 += (Decimal)current.cta_40600101102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600101200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600101200000;
                current.Total40600101200000 = 0;
                if (current.cta_40600101201000 != null)
                    current.Total40600101200000 += (Decimal)current.cta_40600101201000;
                if (current.cta_40600101202000 != null)
                    current.Total40600101200000 += (Decimal)current.cta_40600101202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600101400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600101400000;
                current.Total40600101400000 = 0;
                if (current.cta_40600101401000 != null)
                    current.Total40600101400000 += (Decimal)current.cta_40600101401000;
                if (current.cta_40600101402000 != null)
                    current.Total40600101400000 += (Decimal)current.cta_40600101402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600101600000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600101600000.cta_40600101601000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600101600000.cta_40600101601000;
                current.Total40600101601000 = 0;
                if (current.cta_40600101601010 != null)
                    current.Total40600101601000 += (Decimal)current.cta_40600101601010;
                if (current.cta_40600101601020 != null)
                    current.Total40600101601000 += (Decimal)current.cta_40600101601020;
                if (current.cta_40600101601030 != null)
                    current.Total40600101601000 += (Decimal)current.cta_40600101601030;
                if (current.cta_40600101601040 != null)
                    current.Total40600101601000 += (Decimal)current.cta_40600101601040;
                if (current.cta_40600101601050 != null)
                    current.Total40600101601000 += (Decimal)current.cta_40600101601050;
                if (current.cta_40600101601060 != null)
                    current.Total40600101601000 += (Decimal)current.cta_40600101601060;
                if (current.cta_40600101601070 != null)
                    current.Total40600101601000 += (Decimal)current.cta_40600101601070;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600101600000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600101600000.cta_40600101602000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600101600000.cta_40600101602000;
                current.Total40600101602000 = 0;
                if (current.cta_40600101602010 != null)
                    current.Total40600101602000 += (Decimal)current.cta_40600101602010;
                if (current.cta_40600101602020 != null)
                    current.Total40600101602000 += (Decimal)current.cta_40600101602020;
                if (current.cta_40600101602030 != null)
                    current.Total40600101602000 += (Decimal)current.cta_40600101602030;
                if (current.cta_40600101602040 != null)
                    current.Total40600101602000 += (Decimal)current.cta_40600101602040;
                if (current.cta_40600101602050 != null)
                    current.Total40600101602000 += (Decimal)current.cta_40600101602050;
                if (current.cta_40600101602060 != null)
                    current.Total40600101602000 += (Decimal)current.cta_40600101602060;
                if (current.cta_40600101602070 != null)
                    current.Total40600101602000 += (Decimal)current.cta_40600101602070;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600101600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600101600000;
                current.Total40600101600000 = 0;
                if (current.cta_40600101601000 != null && current.cta_40600101601000.Total40600101601000 != 0)
                    current.Total40600101600000 += (Decimal)current.cta_40600101601000.Total40600101601000;
                if (current.cta_40600101602000 != null && current.cta_40600101602000.Total40600101602000 != 0)
                    current.Total40600101600000 += (Decimal)current.cta_40600101602000.Total40600101602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600104100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600104100000;
                current.Total40600104100000 = 0;
                if (current.cta_40600104101000 != null)
                    current.Total40600104100000 += (Decimal)current.cta_40600104101000;
                if (current.cta_40600104102000 != null)
                    current.Total40600104100000 += (Decimal)current.cta_40600104102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600109900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000.cta_40600109900000;
                current.Total40600109900000 = 0;
                if (current.cta_40600109901000 != null)
                    current.Total40600109900000 += (Decimal)current.cta_40600109901000;
                if (current.cta_40600109902000 != null)
                    current.Total40600109900000 += (Decimal)current.cta_40600109902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600100000000;
                current.Total40600100000000 = 0;
                if (current.cta_40600100100000 != null && current.cta_40600100100000.Total40600100100000 != 0)
                    current.Total40600100000000 += (Decimal)current.cta_40600100100000.Total40600100100000;
                if (current.cta_40600100200000 != null && current.cta_40600100200000.Total40600100200000 != 0)
                    current.Total40600100000000 += (Decimal)current.cta_40600100200000.Total40600100200000;
                if (current.cta_40600100300000 != null && current.cta_40600100300000.Total40600100300000 != 0)
                    current.Total40600100000000 += (Decimal)current.cta_40600100300000.Total40600100300000;
                if (current.cta_40600100400000 != null && current.cta_40600100400000.Total40600100400000 != 0)
                    current.Total40600100000000 += (Decimal)current.cta_40600100400000.Total40600100400000;
                if (current.cta_40600100500000 != null && current.cta_40600100500000.Total40600100500000 != 0)
                    current.Total40600100000000 += (Decimal)current.cta_40600100500000.Total40600100500000;
                if (current.cta_40600100600000 != null && current.cta_40600100600000.Total40600100600000 != 0)
                    current.Total40600100000000 += (Decimal)current.cta_40600100600000.Total40600100600000;
                if (current.cta_40600100800000 != null && current.cta_40600100800000.Total40600100800000 != 0)
                    current.Total40600100000000 += (Decimal)current.cta_40600100800000.Total40600100800000;
                if (current.cta_40600100900000 != null && current.cta_40600100900000.Total40600100900000 != 0)
                    current.Total40600100000000 += (Decimal)current.cta_40600100900000.Total40600100900000;
                if (current.cta_40600101100000 != null && current.cta_40600101100000.Total40600101100000 != 0)
                    current.Total40600100000000 += (Decimal)current.cta_40600101100000.Total40600101100000;
                if (current.cta_40600101200000 != null && current.cta_40600101200000.Total40600101200000 != 0)
                    current.Total40600100000000 += (Decimal)current.cta_40600101200000.Total40600101200000;
                if (current.cta_40600101400000 != null && current.cta_40600101400000.Total40600101400000 != 0)
                    current.Total40600100000000 += (Decimal)current.cta_40600101400000.Total40600101400000;
                if (current.cta_40600101600000 != null && current.cta_40600101600000.Total40600101600000 != 0)
                    current.Total40600100000000 += (Decimal)current.cta_40600101600000.Total40600101600000;
                if (current.cta_40600104100000 != null && current.cta_40600104100000.Total40600104100000 != 0)
                    current.Total40600100000000 += (Decimal)current.cta_40600104100000.Total40600104100000;
                if (current.cta_40600109900000 != null && current.cta_40600109900000.Total40600109900000 != 0)
                    current.Total40600100000000 += (Decimal)current.cta_40600109900000.Total40600109900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200100000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200100000.cta_40600200101000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200100000.cta_40600200101000;
                current.Total40600200101000 = 0;
                if (current.cta_40600200101010 != null)
                    current.Total40600200101000 += (Decimal)current.cta_40600200101010;
                if (current.cta_40600200101020 != null)
                    current.Total40600200101000 += (Decimal)current.cta_40600200101020;
                if (current.cta_40600200101030 != null)
                    current.Total40600200101000 += (Decimal)current.cta_40600200101030;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200100000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200100000.cta_40600200102000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200100000.cta_40600200102000;
                current.Total40600200102000 = 0;
                if (current.cta_40600200102010 != null)
                    current.Total40600200102000 += (Decimal)current.cta_40600200102010;
                if (current.cta_40600200102020 != null)
                    current.Total40600200102000 += (Decimal)current.cta_40600200102020;
                if (current.cta_40600200102030 != null)
                    current.Total40600200102000 += (Decimal)current.cta_40600200102030;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200100000;
                current.Total40600200100000 = 0;
                if (current.cta_40600200101000 != null && current.cta_40600200101000.Total40600200101000 != 0)
                    current.Total40600200100000 += (Decimal)current.cta_40600200101000.Total40600200101000;
                if (current.cta_40600200102000 != null && current.cta_40600200102000.Total40600200102000 != 0)
                    current.Total40600200100000 += (Decimal)current.cta_40600200102000.Total40600200102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200500000;
                current.Total40600200500000 = 0;
                if (current.cta_40600200501000 != null)
                    current.Total40600200500000 += (Decimal)current.cta_40600200501000;
                if (current.cta_40600200502000 != null)
                    current.Total40600200500000 += (Decimal)current.cta_40600200502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200600000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200600000.cta_40600200601000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200600000.cta_40600200601000;
                current.Total40600200601000 = 0;
                if (current.cta_40600200601010 != null)
                    current.Total40600200601000 += (Decimal)current.cta_40600200601010;
                if (current.cta_40600200601020 != null)
                    current.Total40600200601000 += (Decimal)current.cta_40600200601020;
                if (current.cta_40600200601030 != null)
                    current.Total40600200601000 += (Decimal)current.cta_40600200601030;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200600000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200600000.cta_40600200602000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200600000.cta_40600200602000;
                current.Total40600200602000 = 0;
                if (current.cta_40600200602010 != null)
                    current.Total40600200602000 += (Decimal)current.cta_40600200602010;
                if (current.cta_40600200602020 != null)
                    current.Total40600200602000 += (Decimal)current.cta_40600200602020;
                if (current.cta_40600200602030 != null)
                    current.Total40600200602000 += (Decimal)current.cta_40600200602030;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200600000;
                current.Total40600200600000 = 0;
                if (current.cta_40600200601000 != null && current.cta_40600200601000.Total40600200601000 != 0)
                    current.Total40600200600000 += (Decimal)current.cta_40600200601000.Total40600200601000;
                if (current.cta_40600200602000 != null && current.cta_40600200602000.Total40600200602000 != 0)
                    current.Total40600200600000 += (Decimal)current.cta_40600200602000.Total40600200602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200700000;
                current.Total40600200700000 = 0;
                if (current.cta_40600200701000 != null)
                    current.Total40600200700000 += (Decimal)current.cta_40600200701000;
                if (current.cta_40600200702000 != null)
                    current.Total40600200700000 += (Decimal)current.cta_40600200702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200800000;
                current.Total40600200800000 = 0;
                if (current.cta_40600200801000 != null)
                    current.Total40600200800000 += (Decimal)current.cta_40600200801000;
                if (current.cta_40600200802000 != null)
                    current.Total40600200800000 += (Decimal)current.cta_40600200802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600200900000;
                current.Total40600200900000 = 0;
                if (current.cta_40600200901000 != null)
                    current.Total40600200900000 += (Decimal)current.cta_40600200901000;
                if (current.cta_40600200902000 != null)
                    current.Total40600200900000 += (Decimal)current.cta_40600200902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600201000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600201000000;
                current.Total40600201000000 = 0;
                if (current.cta_40600201001000 != null)
                    current.Total40600201000000 += (Decimal)current.cta_40600201001000;
                if (current.cta_40600201002000 != null)
                    current.Total40600201000000 += (Decimal)current.cta_40600201002000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600201100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600201100000;
                current.Total40600201100000 = 0;
                if (current.cta_40600201101000 != null)
                    current.Total40600201100000 += (Decimal)current.cta_40600201101000;
                if (current.cta_40600201102000 != null)
                    current.Total40600201100000 += (Decimal)current.cta_40600201102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600209900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000.cta_40600209900000;
                current.Total40600209900000 = 0;
                if (current.cta_40600209901000 != null)
                    current.Total40600209900000 += (Decimal)current.cta_40600209901000;
                if (current.cta_40600209902000 != null)
                    current.Total40600209900000 += (Decimal)current.cta_40600209902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600200000000;
                current.Total40600200000000 = 0;
                if (current.cta_40600200100000 != null && current.cta_40600200100000.Total40600200100000 != 0)
                    current.Total40600200000000 += (Decimal)current.cta_40600200100000.Total40600200100000;
                if (current.cta_40600200500000 != null && current.cta_40600200500000.Total40600200500000 != 0)
                    current.Total40600200000000 += (Decimal)current.cta_40600200500000.Total40600200500000;
                if (current.cta_40600200600000 != null && current.cta_40600200600000.Total40600200600000 != 0)
                    current.Total40600200000000 += (Decimal)current.cta_40600200600000.Total40600200600000;
                if (current.cta_40600200700000 != null && current.cta_40600200700000.Total40600200700000 != 0)
                    current.Total40600200000000 += (Decimal)current.cta_40600200700000.Total40600200700000;
                if (current.cta_40600200800000 != null && current.cta_40600200800000.Total40600200800000 != 0)
                    current.Total40600200000000 += (Decimal)current.cta_40600200800000.Total40600200800000;
                if (current.cta_40600200900000 != null && current.cta_40600200900000.Total40600200900000 != 0)
                    current.Total40600200000000 += (Decimal)current.cta_40600200900000.Total40600200900000;
                if (current.cta_40600201000000 != null && current.cta_40600201000000.Total40600201000000 != 0)
                    current.Total40600200000000 += (Decimal)current.cta_40600201000000.Total40600201000000;
                if (current.cta_40600201100000 != null && current.cta_40600201100000.Total40600201100000 != 0)
                    current.Total40600200000000 += (Decimal)current.cta_40600201100000.Total40600201100000;
                if (current.cta_40600209900000 != null && current.cta_40600209900000.Total40600209900000 != 0)
                    current.Total40600200000000 += (Decimal)current.cta_40600209900000.Total40600209900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000.cta_40600300100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000.cta_40600300100000;
                current.Total40600300100000 = 0;
                if (current.cta_40600300101000 != null)
                    current.Total40600300100000 += (Decimal)current.cta_40600300101000;
                if (current.cta_40600300102000 != null)
                    current.Total40600300100000 += (Decimal)current.cta_40600300102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000.cta_40600300200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000.cta_40600300200000;
                current.Total40600300200000 = 0;
                if (current.cta_40600300201000 != null)
                    current.Total40600300200000 += (Decimal)current.cta_40600300201000;
                if (current.cta_40600300202000 != null)
                    current.Total40600300200000 += (Decimal)current.cta_40600300202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000.cta_40600300300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000.cta_40600300300000;
                current.Total40600300300000 = 0;
                if (current.cta_40600300301000 != null)
                    current.Total40600300300000 += (Decimal)current.cta_40600300301000;
                if (current.cta_40600300302000 != null)
                    current.Total40600300300000 += (Decimal)current.cta_40600300302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000.cta_40600300400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000.cta_40600300400000;
                current.Total40600300400000 = 0;
                if (current.cta_40600300401000 != null)
                    current.Total40600300400000 += (Decimal)current.cta_40600300401000;
                if (current.cta_40600300402000 != null)
                    current.Total40600300400000 += (Decimal)current.cta_40600300402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000.cta_40600300600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000.cta_40600300600000;
                current.Total40600300600000 = 0;
                if (current.cta_40600300601000 != null)
                    current.Total40600300600000 += (Decimal)current.cta_40600300601000;
                if (current.cta_40600300602000 != null)
                    current.Total40600300600000 += (Decimal)current.cta_40600300602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000.cta_40600300800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000.cta_40600300800000;
                current.Total40600300800000 = 0;
                if (current.cta_40600300801000 != null)
                    current.Total40600300800000 += (Decimal)current.cta_40600300801000;
                if (current.cta_40600300802000 != null)
                    current.Total40600300800000 += (Decimal)current.cta_40600300802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000.cta_40600301000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000.cta_40600301000000;
                current.Total40600301000000 = 0;
                if (current.cta_40600301001000 != null)
                    current.Total40600301000000 += (Decimal)current.cta_40600301001000;
                if (current.cta_40600301002000 != null)
                    current.Total40600301000000 += (Decimal)current.cta_40600301002000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600300000000;
                current.Total40600300000000 = 0;
                if (current.cta_40600300100000 != null && current.cta_40600300100000.Total40600300100000 != 0)
                    current.Total40600300000000 += (Decimal)current.cta_40600300100000.Total40600300100000;
                if (current.cta_40600300200000 != null && current.cta_40600300200000.Total40600300200000 != 0)
                    current.Total40600300000000 += (Decimal)current.cta_40600300200000.Total40600300200000;
                if (current.cta_40600300300000 != null && current.cta_40600300300000.Total40600300300000 != 0)
                    current.Total40600300000000 += (Decimal)current.cta_40600300300000.Total40600300300000;
                if (current.cta_40600300400000 != null && current.cta_40600300400000.Total40600300400000 != 0)
                    current.Total40600300000000 += (Decimal)current.cta_40600300400000.Total40600300400000;
                if (current.cta_40600300600000 != null && current.cta_40600300600000.Total40600300600000 != 0)
                    current.Total40600300000000 += (Decimal)current.cta_40600300600000.Total40600300600000;
                if (current.cta_40600300800000 != null && current.cta_40600300800000.Total40600300800000 != 0)
                    current.Total40600300000000 += (Decimal)current.cta_40600300800000.Total40600300800000;
                if (current.cta_40600301000000 != null && current.cta_40600301000000.Total40600301000000 != 0)
                    current.Total40600300000000 += (Decimal)current.cta_40600301000000.Total40600301000000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600500000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600500000000.cta_40600500100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600500000000.cta_40600500100000;
                current.Total40600500100000 = 0;
                if (current.cta_40600500101000 != null)
                    current.Total40600500100000 += (Decimal)current.cta_40600500101000;
                if (current.cta_40600500102000 != null)
                    current.Total40600500100000 += (Decimal)current.cta_40600500102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600500000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600500000000.cta_40600500200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600500000000.cta_40600500200000;
                current.Total40600500200000 = 0;
                if (current.cta_40600500201000 != null)
                    current.Total40600500200000 += (Decimal)current.cta_40600500201000;
                if (current.cta_40600500202000 != null)
                    current.Total40600500200000 += (Decimal)current.cta_40600500202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600500000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600500000000.cta_40600500400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600500000000.cta_40600500400000;
                current.Total40600500400000 = 0;
                if (current.cta_40600500401000 != null)
                    current.Total40600500400000 += (Decimal)current.cta_40600500401000;
                if (current.cta_40600500402000 != null)
                    current.Total40600500400000 += (Decimal)current.cta_40600500402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600500000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600500000000.cta_40600509900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600500000000.cta_40600509900000;
                current.Total40600509900000 = 0;
                if (current.cta_40600509901000 != null)
                    current.Total40600509900000 += (Decimal)current.cta_40600509901000;
                if (current.cta_40600509902000 != null)
                    current.Total40600509900000 += (Decimal)current.cta_40600509902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600500000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600500000000;
                current.Total40600500000000 = 0;
                if (current.cta_40600500100000 != null && current.cta_40600500100000.Total40600500100000 != 0)
                    current.Total40600500000000 += (Decimal)current.cta_40600500100000.Total40600500100000;
                if (current.cta_40600500200000 != null && current.cta_40600500200000.Total40600500200000 != 0)
                    current.Total40600500000000 += (Decimal)current.cta_40600500200000.Total40600500200000;
                if (current.cta_40600500400000 != null && current.cta_40600500400000.Total40600500400000 != 0)
                    current.Total40600500000000 += (Decimal)current.cta_40600500400000.Total40600500400000;
                if (current.cta_40600509900000 != null && current.cta_40600509900000.Total40600509900000 != 0)
                    current.Total40600500000000 += (Decimal)current.cta_40600509900000.Total40600509900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600800000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600800000000.cta_40600809900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600800000000.cta_40600809900000;
                current.Total40600809900000 = 0;
                if (current.cta_40600809901000 != null)
                    current.Total40600809900000 += (Decimal)current.cta_40600809901000;
                if (current.cta_40600809902000 != null)
                    current.Total40600809900000 += (Decimal)current.cta_40600809902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600800000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600800000000;
                current.Total40600800000000 = 0;
                if (current.cta_40600809900000 != null && current.cta_40600809900000.Total40600809900000 != 0)
                    current.Total40600800000000 += (Decimal)current.cta_40600809900000.Total40600809900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600900100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600900100000;
                current.Total40600900100000 = 0;
                if (current.cta_40600900101000 != null)
                    current.Total40600900100000 += (Decimal)current.cta_40600900101000;
                if (current.cta_40600900102000 != null)
                    current.Total40600900100000 += (Decimal)current.cta_40600900102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600900200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600900200000;
                current.Total40600900200000 = 0;
                if (current.cta_40600900201000 != null)
                    current.Total40600900200000 += (Decimal)current.cta_40600900201000;
                if (current.cta_40600900202000 != null)
                    current.Total40600900200000 += (Decimal)current.cta_40600900202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600900300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600900300000;
                current.Total40600900300000 = 0;
                if (current.cta_40600900301000 != null)
                    current.Total40600900300000 += (Decimal)current.cta_40600900301000;
                if (current.cta_40600900302000 != null)
                    current.Total40600900300000 += (Decimal)current.cta_40600900302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600900400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600900400000;
                current.Total40600900400000 = 0;
                if (current.cta_40600900401000 != null)
                    current.Total40600900400000 += (Decimal)current.cta_40600900401000;
                if (current.cta_40600900402000 != null)
                    current.Total40600900400000 += (Decimal)current.cta_40600900402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600900600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600900600000;
                current.Total40600900600000 = 0;
                if (current.cta_40600900601000 != null)
                    current.Total40600900600000 += (Decimal)current.cta_40600900601000;
                if (current.cta_40600900602000 != null)
                    current.Total40600900600000 += (Decimal)current.cta_40600900602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600900700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600900700000;
                current.Total40600900700000 = 0;
                if (current.cta_40600900701000 != null)
                    current.Total40600900700000 += (Decimal)current.cta_40600900701000;
                if (current.cta_40600900702000 != null)
                    current.Total40600900700000 += (Decimal)current.cta_40600900702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600900900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600900900000;
                current.Total40600900900000 = 0;
                if (current.cta_40600900901000 != null)
                    current.Total40600900900000 += (Decimal)current.cta_40600900901000;
                if (current.cta_40600900902000 != null)
                    current.Total40600900900000 += (Decimal)current.cta_40600900902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901000000;
                current.Total40600901000000 = 0;
                if (current.cta_40600901001000 != null)
                    current.Total40600901000000 += (Decimal)current.cta_40600901001000;
                if (current.cta_40600901002000 != null)
                    current.Total40600901000000 += (Decimal)current.cta_40600901002000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901100000;
                current.Total40600901100000 = 0;
                if (current.cta_40600901101000 != null)
                    current.Total40600901100000 += (Decimal)current.cta_40600901101000;
                if (current.cta_40600901102000 != null)
                    current.Total40600901100000 += (Decimal)current.cta_40600901102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901200000;
                current.Total40600901200000 = 0;
                if (current.cta_40600901201000 != null)
                    current.Total40600901200000 += (Decimal)current.cta_40600901201000;
                if (current.cta_40600901202000 != null)
                    current.Total40600901200000 += (Decimal)current.cta_40600901202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901300000;
                current.Total40600901300000 = 0;
                if (current.cta_40600901301000 != null)
                    current.Total40600901300000 += (Decimal)current.cta_40600901301000;
                if (current.cta_40600901302000 != null)
                    current.Total40600901300000 += (Decimal)current.cta_40600901302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901400000;
                current.Total40600901400000 = 0;
                if (current.cta_40600901401000 != null)
                    current.Total40600901400000 += (Decimal)current.cta_40600901401000;
                if (current.cta_40600901402000 != null)
                    current.Total40600901400000 += (Decimal)current.cta_40600901402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901500000;
                current.Total40600901500000 = 0;
                if (current.cta_40600901501000 != null)
                    current.Total40600901500000 += (Decimal)current.cta_40600901501000;
                if (current.cta_40600901502000 != null)
                    current.Total40600901500000 += (Decimal)current.cta_40600901502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901600000;
                current.Total40600901600000 = 0;
                if (current.cta_40600901601000 != null)
                    current.Total40600901600000 += (Decimal)current.cta_40600901601000;
                if (current.cta_40600901602000 != null)
                    current.Total40600901600000 += (Decimal)current.cta_40600901602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901700000;
                current.Total40600901700000 = 0;
                if (current.cta_40600901701000 != null)
                    current.Total40600901700000 += (Decimal)current.cta_40600901701000;
                if (current.cta_40600901702000 != null)
                    current.Total40600901700000 += (Decimal)current.cta_40600901702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901800000;
                current.Total40600901800000 = 0;
                if (current.cta_40600901801000 != null)
                    current.Total40600901800000 += (Decimal)current.cta_40600901801000;
                if (current.cta_40600901802000 != null)
                    current.Total40600901800000 += (Decimal)current.cta_40600901802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600901900000;
                current.Total40600901900000 = 0;
                if (current.cta_40600901901000 != null)
                    current.Total40600901900000 += (Decimal)current.cta_40600901901000;
                if (current.cta_40600901902000 != null)
                    current.Total40600901900000 += (Decimal)current.cta_40600901902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902000000.cta_40600902001000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902000000.cta_40600902001000;
                current.Total40600902001000 = 0;
                if (current.cta_40600902001010 != null)
                    current.Total40600902001000 += (Decimal)current.cta_40600902001010;
                if (current.cta_40600902001020 != null)
                    current.Total40600902001000 += (Decimal)current.cta_40600902001020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902000000.cta_40600902002000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902000000.cta_40600902002000;
                current.Total40600902002000 = 0;
                if (current.cta_40600902002010 != null)
                    current.Total40600902002000 += (Decimal)current.cta_40600902002010;
                if (current.cta_40600902002020 != null)
                    current.Total40600902002000 += (Decimal)current.cta_40600902002020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902000000;
                current.Total40600902000000 = 0;
                if (current.cta_40600902001000 != null && current.cta_40600902001000.Total40600902001000 != 0)
                    current.Total40600902000000 += (Decimal)current.cta_40600902001000.Total40600902001000;
                if (current.cta_40600902002000 != null && current.cta_40600902002000.Total40600902002000 != 0)
                    current.Total40600902000000 += (Decimal)current.cta_40600902002000.Total40600902002000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902300000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902300000.cta_40600902301000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902300000.cta_40600902301000;
                current.Total40600902301000 = 0;
                if (current.cta_40600902301010 != null)
                    current.Total40600902301000 += (Decimal)current.cta_40600902301010;
                if (current.cta_40600902301020 != null)
                    current.Total40600902301000 += (Decimal)current.cta_40600902301020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902300000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902300000.cta_40600902302000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902300000.cta_40600902302000;
                current.Total40600902302000 = 0;
                if (current.cta_40600902302010 != null)
                    current.Total40600902302000 += (Decimal)current.cta_40600902302010;
                if (current.cta_40600902302020 != null)
                    current.Total40600902302000 += (Decimal)current.cta_40600902302020;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902300000;
                current.Total40600902300000 = 0;
                if (current.cta_40600902301000 != null && current.cta_40600902301000.Total40600902301000 != 0)
                    current.Total40600902300000 += (Decimal)current.cta_40600902301000.Total40600902301000;
                if (current.cta_40600902302000 != null && current.cta_40600902302000.Total40600902302000 != 0)
                    current.Total40600902300000 += (Decimal)current.cta_40600902302000.Total40600902302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600902500000;
                current.Total40600902500000 = 0;
                if (current.cta_40600902501000 != null)
                    current.Total40600902500000 += (Decimal)current.cta_40600902501000;
                if (current.cta_40600902502000 != null)
                    current.Total40600902500000 += (Decimal)current.cta_40600902502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600909900000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600909900000.cta_40600909901000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600909900000.cta_40600909901000;
                current.Total40600909901000 = 0;
                if (current.cta_40600909901030 != null)
                    current.Total40600909901000 += (Decimal)current.cta_40600909901030;
                if (current.cta_40600909901990 != null)
                    current.Total40600909901000 += (Decimal)current.cta_40600909901990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600909900000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600909900000.cta_40600909902000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600909900000.cta_40600909902000;
                current.Total40600909902000 = 0;
                if (current.cta_40600909902030 != null)
                    current.Total40600909902000 += (Decimal)current.cta_40600909902030;
                if (current.cta_40600909902990 != null)
                    current.Total40600909902000 += (Decimal)current.cta_40600909902990;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600909900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000.cta_40600909900000;
                current.Total40600909900000 = 0;
                if (current.cta_40600909901000 != null && current.cta_40600909901000.Total40600909901000 != 0)
                    current.Total40600909900000 += (Decimal)current.cta_40600909901000.Total40600909901000;
                if (current.cta_40600909902000 != null && current.cta_40600909902000.Total40600909902000 != 0)
                    current.Total40600909900000 += (Decimal)current.cta_40600909902000.Total40600909902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null && modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000.cta_40600900000000;
                current.Total40600900000000 = 0;
                if (current.cta_40600900100000 != null && current.cta_40600900100000.Total40600900100000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600900100000.Total40600900100000;
                if (current.cta_40600900200000 != null && current.cta_40600900200000.Total40600900200000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600900200000.Total40600900200000;
                if (current.cta_40600900300000 != null && current.cta_40600900300000.Total40600900300000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600900300000.Total40600900300000;
                if (current.cta_40600900400000 != null && current.cta_40600900400000.Total40600900400000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600900400000.Total40600900400000;
                if (current.cta_40600900600000 != null && current.cta_40600900600000.Total40600900600000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600900600000.Total40600900600000;
                if (current.cta_40600900700000 != null && current.cta_40600900700000.Total40600900700000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600900700000.Total40600900700000;
                if (current.cta_40600900900000 != null && current.cta_40600900900000.Total40600900900000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600900900000.Total40600900900000;
                if (current.cta_40600901000000 != null && current.cta_40600901000000.Total40600901000000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600901000000.Total40600901000000;
                if (current.cta_40600901100000 != null && current.cta_40600901100000.Total40600901100000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600901100000.Total40600901100000;
                if (current.cta_40600901200000 != null && current.cta_40600901200000.Total40600901200000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600901200000.Total40600901200000;
                if (current.cta_40600901300000 != null && current.cta_40600901300000.Total40600901300000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600901300000.Total40600901300000;
                if (current.cta_40600901400000 != null && current.cta_40600901400000.Total40600901400000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600901400000.Total40600901400000;
                if (current.cta_40600901500000 != null && current.cta_40600901500000.Total40600901500000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600901500000.Total40600901500000;
                if (current.cta_40600901600000 != null && current.cta_40600901600000.Total40600901600000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600901600000.Total40600901600000;
                if (current.cta_40600901700000 != null && current.cta_40600901700000.Total40600901700000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600901700000.Total40600901700000;
                if (current.cta_40600901800000 != null && current.cta_40600901800000.Total40600901800000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600901800000.Total40600901800000;
                if (current.cta_40600901900000 != null && current.cta_40600901900000.Total40600901900000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600901900000.Total40600901900000;
                if (current.cta_40600902000000 != null && current.cta_40600902000000.Total40600902000000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600902000000.Total40600902000000;
                if (current.cta_40600902300000 != null && current.cta_40600902300000.Total40600902300000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600902300000.Total40600902300000;
                if (current.cta_40600902500000 != null && current.cta_40600902500000.Total40600902500000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600902500000.Total40600902500000;
                if (current.cta_40600909900000 != null && current.cta_40600909900000.Total40600909900000 != 0)
                    current.Total40600900000000 += (Decimal)current.cta_40600909900000.Total40600909900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40600000000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40600000000000;
                current.Total40600000000000 = 0;
                if (current.cta_40600100000000 != null && current.cta_40600100000000.Total40600100000000 != 0)
                    current.Total40600000000000 += (Decimal)current.cta_40600100000000.Total40600100000000;
                if (current.cta_40600200000000 != null && current.cta_40600200000000.Total40600200000000 != 0)
                    current.Total40600000000000 += (Decimal)current.cta_40600200000000.Total40600200000000;
                if (current.cta_40600300000000 != null && current.cta_40600300000000.Total40600300000000 != 0)
                    current.Total40600000000000 += (Decimal)current.cta_40600300000000.Total40600300000000;
                if (current.cta_40600500000000 != null && current.cta_40600500000000.Total40600500000000 != 0)
                    current.Total40600000000000 += (Decimal)current.cta_40600500000000.Total40600500000000;
                if (current.cta_40600800000000 != null && current.cta_40600800000000.Total40600800000000 != 0)
                    current.Total40600000000000 += (Decimal)current.cta_40600800000000.Total40600800000000;
                if (current.cta_40600900000000 != null && current.cta_40600900000000.Total40600900000000 != 0)
                    current.Total40600000000000 += (Decimal)current.cta_40600900000000.Total40600900000000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100100000;
                current.Total40700100100000 = 0;
                if (current.cta_40700100101000 != null)
                    current.Total40700100100000 += (Decimal)current.cta_40700100101000;
                if (current.cta_40700100102000 != null)
                    current.Total40700100100000 += (Decimal)current.cta_40700100102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100200000;
                current.Total40700100200000 = 0;
                if (current.cta_40700100201000 != null)
                    current.Total40700100200000 += (Decimal)current.cta_40700100201000;
                if (current.cta_40700100202000 != null)
                    current.Total40700100200000 += (Decimal)current.cta_40700100202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100300000;
                current.Total40700100300000 = 0;
                if (current.cta_40700100301000 != null)
                    current.Total40700100300000 += (Decimal)current.cta_40700100301000;
                if (current.cta_40700100302000 != null)
                    current.Total40700100300000 += (Decimal)current.cta_40700100302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100400000;
                current.Total40700100400000 = 0;
                if (current.cta_40700100401000 != null)
                    current.Total40700100400000 += (Decimal)current.cta_40700100401000;
                if (current.cta_40700100402000 != null)
                    current.Total40700100400000 += (Decimal)current.cta_40700100402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100500000;
                current.Total40700100500000 = 0;
                if (current.cta_40700100501000 != null)
                    current.Total40700100500000 += (Decimal)current.cta_40700100501000;
                if (current.cta_40700100502000 != null)
                    current.Total40700100500000 += (Decimal)current.cta_40700100502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100600000;
                current.Total40700100600000 = 0;
                if (current.cta_40700100601000 != null)
                    current.Total40700100600000 += (Decimal)current.cta_40700100601000;
                if (current.cta_40700100602000 != null)
                    current.Total40700100600000 += (Decimal)current.cta_40700100602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100700000;
                current.Total40700100700000 = 0;
                if (current.cta_40700100701000 != null)
                    current.Total40700100700000 += (Decimal)current.cta_40700100701000;
                if (current.cta_40700100702000 != null)
                    current.Total40700100700000 += (Decimal)current.cta_40700100702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100800000;
                current.Total40700100800000 = 0;
                if (current.cta_40700100801000 != null)
                    current.Total40700100800000 += (Decimal)current.cta_40700100801000;
                if (current.cta_40700100802000 != null)
                    current.Total40700100800000 += (Decimal)current.cta_40700100802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700100900000;
                current.Total40700100900000 = 0;
                if (current.cta_40700100901000 != null)
                    current.Total40700100900000 += (Decimal)current.cta_40700100901000;
                if (current.cta_40700100902000 != null)
                    current.Total40700100900000 += (Decimal)current.cta_40700100902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101000000;
                current.Total40700101000000 = 0;
                if (current.cta_40700101001000 != null)
                    current.Total40700101000000 += (Decimal)current.cta_40700101001000;
                if (current.cta_40700101002000 != null)
                    current.Total40700101000000 += (Decimal)current.cta_40700101002000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101100000;
                current.Total40700101100000 = 0;
                if (current.cta_40700101101000 != null)
                    current.Total40700101100000 += (Decimal)current.cta_40700101101000;
                if (current.cta_40700101102000 != null)
                    current.Total40700101100000 += (Decimal)current.cta_40700101102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101200000;
                current.Total40700101200000 = 0;
                if (current.cta_40700101201000 != null)
                    current.Total40700101200000 += (Decimal)current.cta_40700101201000;
                if (current.cta_40700101202000 != null)
                    current.Total40700101200000 += (Decimal)current.cta_40700101202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101300000;
                current.Total40700101300000 = 0;
                if (current.cta_40700101301000 != null)
                    current.Total40700101300000 += (Decimal)current.cta_40700101301000;
                if (current.cta_40700101302000 != null)
                    current.Total40700101300000 += (Decimal)current.cta_40700101302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101400000;
                current.Total40700101400000 = 0;
                if (current.cta_40700101401000 != null)
                    current.Total40700101400000 += (Decimal)current.cta_40700101401000;
                if (current.cta_40700101402000 != null)
                    current.Total40700101400000 += (Decimal)current.cta_40700101402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101500000;
                current.Total40700101500000 = 0;
                if (current.cta_40700101501000 != null)
                    current.Total40700101500000 += (Decimal)current.cta_40700101501000;
                if (current.cta_40700101502000 != null)
                    current.Total40700101500000 += (Decimal)current.cta_40700101502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101600000;
                current.Total40700101600000 = 0;
                if (current.cta_40700101601000 != null)
                    current.Total40700101600000 += (Decimal)current.cta_40700101601000;
                if (current.cta_40700101602000 != null)
                    current.Total40700101600000 += (Decimal)current.cta_40700101602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101700000;
                current.Total40700101700000 = 0;
                if (current.cta_40700101701000 != null)
                    current.Total40700101700000 += (Decimal)current.cta_40700101701000;
                if (current.cta_40700101702000 != null)
                    current.Total40700101700000 += (Decimal)current.cta_40700101702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101800000;
                current.Total40700101800000 = 0;
                if (current.cta_40700101801000 != null)
                    current.Total40700101800000 += (Decimal)current.cta_40700101801000;
                if (current.cta_40700101802000 != null)
                    current.Total40700101800000 += (Decimal)current.cta_40700101802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700101900000;
                current.Total40700101900000 = 0;
                if (current.cta_40700101901000 != null)
                    current.Total40700101900000 += (Decimal)current.cta_40700101901000;
                if (current.cta_40700101902000 != null)
                    current.Total40700101900000 += (Decimal)current.cta_40700101902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700102200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700102200000;
                current.Total40700102200000 = 0;
                if (current.cta_40700102201000 != null)
                    current.Total40700102200000 += (Decimal)current.cta_40700102201000;
                if (current.cta_40700102202000 != null)
                    current.Total40700102200000 += (Decimal)current.cta_40700102202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700102400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700102400000;
                current.Total40700102400000 = 0;
                if (current.cta_40700102401000 != null)
                    current.Total40700102400000 += (Decimal)current.cta_40700102401000;
                if (current.cta_40700102402000 != null)
                    current.Total40700102400000 += (Decimal)current.cta_40700102402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700109900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000.cta_40700109900000;
                current.Total40700109900000 = 0;
                if (current.cta_40700109901000 != null)
                    current.Total40700109900000 += (Decimal)current.cta_40700109901000;
                if (current.cta_40700109902000 != null)
                    current.Total40700109900000 += (Decimal)current.cta_40700109902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700100000000;
                current.Total40700100000000 = 0;
                if (current.cta_40700100100000 != null && current.cta_40700100100000.Total40700100100000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700100100000.Total40700100100000;
                if (current.cta_40700100200000 != null && current.cta_40700100200000.Total40700100200000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700100200000.Total40700100200000;
                if (current.cta_40700100300000 != null && current.cta_40700100300000.Total40700100300000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700100300000.Total40700100300000;
                if (current.cta_40700100400000 != null && current.cta_40700100400000.Total40700100400000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700100400000.Total40700100400000;
                if (current.cta_40700100500000 != null && current.cta_40700100500000.Total40700100500000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700100500000.Total40700100500000;
                if (current.cta_40700100600000 != null && current.cta_40700100600000.Total40700100600000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700100600000.Total40700100600000;
                if (current.cta_40700100700000 != null && current.cta_40700100700000.Total40700100700000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700100700000.Total40700100700000;
                if (current.cta_40700100800000 != null && current.cta_40700100800000.Total40700100800000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700100800000.Total40700100800000;
                if (current.cta_40700100900000 != null && current.cta_40700100900000.Total40700100900000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700100900000.Total40700100900000;
                if (current.cta_40700101000000 != null && current.cta_40700101000000.Total40700101000000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700101000000.Total40700101000000;
                if (current.cta_40700101100000 != null && current.cta_40700101100000.Total40700101100000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700101100000.Total40700101100000;
                if (current.cta_40700101200000 != null && current.cta_40700101200000.Total40700101200000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700101200000.Total40700101200000;
                if (current.cta_40700101300000 != null && current.cta_40700101300000.Total40700101300000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700101300000.Total40700101300000;
                if (current.cta_40700101400000 != null && current.cta_40700101400000.Total40700101400000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700101400000.Total40700101400000;
                if (current.cta_40700101500000 != null && current.cta_40700101500000.Total40700101500000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700101500000.Total40700101500000;
                if (current.cta_40700101600000 != null && current.cta_40700101600000.Total40700101600000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700101600000.Total40700101600000;
                if (current.cta_40700101700000 != null && current.cta_40700101700000.Total40700101700000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700101700000.Total40700101700000;
                if (current.cta_40700101800000 != null && current.cta_40700101800000.Total40700101800000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700101800000.Total40700101800000;
                if (current.cta_40700101900000 != null && current.cta_40700101900000.Total40700101900000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700101900000.Total40700101900000;
                if (current.cta_40700102200000 != null && current.cta_40700102200000.Total40700102200000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700102200000.Total40700102200000;
                if (current.cta_40700102400000 != null && current.cta_40700102400000.Total40700102400000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700102400000.Total40700102400000;
                if (current.cta_40700109900000 != null && current.cta_40700109900000.Total40700109900000 != 0)
                    current.Total40700100000000 += (Decimal)current.cta_40700109900000.Total40700109900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200100000;
                current.Total40700200100000 = 0;
                if (current.cta_40700200101000 != null)
                    current.Total40700200100000 += (Decimal)current.cta_40700200101000;
                if (current.cta_40700200102000 != null)
                    current.Total40700200100000 += (Decimal)current.cta_40700200102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200200000;
                current.Total40700200200000 = 0;
                if (current.cta_40700200201000 != null)
                    current.Total40700200200000 += (Decimal)current.cta_40700200201000;
                if (current.cta_40700200202000 != null)
                    current.Total40700200200000 += (Decimal)current.cta_40700200202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200300000;
                current.Total40700200300000 = 0;
                if (current.cta_40700200301000 != null)
                    current.Total40700200300000 += (Decimal)current.cta_40700200301000;
                if (current.cta_40700200302000 != null)
                    current.Total40700200300000 += (Decimal)current.cta_40700200302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200400000;
                current.Total40700200400000 = 0;
                if (current.cta_40700200401000 != null)
                    current.Total40700200400000 += (Decimal)current.cta_40700200401000;
                if (current.cta_40700200402000 != null)
                    current.Total40700200400000 += (Decimal)current.cta_40700200402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200500000;
                current.Total40700200500000 = 0;
                if (current.cta_40700200501000 != null)
                    current.Total40700200500000 += (Decimal)current.cta_40700200501000;
                if (current.cta_40700200502000 != null)
                    current.Total40700200500000 += (Decimal)current.cta_40700200502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200600000;
                current.Total40700200600000 = 0;
                if (current.cta_40700200601000 != null)
                    current.Total40700200600000 += (Decimal)current.cta_40700200601000;
                if (current.cta_40700200602000 != null)
                    current.Total40700200600000 += (Decimal)current.cta_40700200602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200700000;
                current.Total40700200700000 = 0;
                if (current.cta_40700200701000 != null)
                    current.Total40700200700000 += (Decimal)current.cta_40700200701000;
                if (current.cta_40700200702000 != null)
                    current.Total40700200700000 += (Decimal)current.cta_40700200702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200800000;
                current.Total40700200800000 = 0;
                if (current.cta_40700200801000 != null)
                    current.Total40700200800000 += (Decimal)current.cta_40700200801000;
                if (current.cta_40700200802000 != null)
                    current.Total40700200800000 += (Decimal)current.cta_40700200802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700200900000;
                current.Total40700200900000 = 0;
                if (current.cta_40700200901000 != null)
                    current.Total40700200900000 += (Decimal)current.cta_40700200901000;
                if (current.cta_40700200902000 != null)
                    current.Total40700200900000 += (Decimal)current.cta_40700200902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700201000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700201000000;
                current.Total40700201000000 = 0;
                if (current.cta_40700201001000 != null)
                    current.Total40700201000000 += (Decimal)current.cta_40700201001000;
                if (current.cta_40700201002000 != null)
                    current.Total40700201000000 += (Decimal)current.cta_40700201002000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700201100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700201100000;
                current.Total40700201100000 = 0;
                if (current.cta_40700201101000 != null)
                    current.Total40700201100000 += (Decimal)current.cta_40700201101000;
                if (current.cta_40700201102000 != null)
                    current.Total40700201100000 += (Decimal)current.cta_40700201102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700201200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700201200000;
                current.Total40700201200000 = 0;
                if (current.cta_40700201201000 != null)
                    current.Total40700201200000 += (Decimal)current.cta_40700201201000;
                if (current.cta_40700201202000 != null)
                    current.Total40700201200000 += (Decimal)current.cta_40700201202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700201300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700201300000;
                current.Total40700201300000 = 0;
                if (current.cta_40700201301000 != null)
                    current.Total40700201300000 += (Decimal)current.cta_40700201301000;
                if (current.cta_40700201302000 != null)
                    current.Total40700201300000 += (Decimal)current.cta_40700201302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700209900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000.cta_40700209900000;
                current.Total40700209900000 = 0;
                if (current.cta_40700209901000 != null)
                    current.Total40700209900000 += (Decimal)current.cta_40700209901000;
                if (current.cta_40700209902000 != null)
                    current.Total40700209900000 += (Decimal)current.cta_40700209902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700200000000;
                current.Total40700200000000 = 0;
                if (current.cta_40700200100000 != null && current.cta_40700200100000.Total40700200100000 != 0)
                    current.Total40700200000000 += (Decimal)current.cta_40700200100000.Total40700200100000;
                if (current.cta_40700200200000 != null && current.cta_40700200200000.Total40700200200000 != 0)
                    current.Total40700200000000 += (Decimal)current.cta_40700200200000.Total40700200200000;
                if (current.cta_40700200300000 != null && current.cta_40700200300000.Total40700200300000 != 0)
                    current.Total40700200000000 += (Decimal)current.cta_40700200300000.Total40700200300000;
                if (current.cta_40700200400000 != null && current.cta_40700200400000.Total40700200400000 != 0)
                    current.Total40700200000000 += (Decimal)current.cta_40700200400000.Total40700200400000;
                if (current.cta_40700200500000 != null && current.cta_40700200500000.Total40700200500000 != 0)
                    current.Total40700200000000 += (Decimal)current.cta_40700200500000.Total40700200500000;
                if (current.cta_40700200600000 != null && current.cta_40700200600000.Total40700200600000 != 0)
                    current.Total40700200000000 += (Decimal)current.cta_40700200600000.Total40700200600000;
                if (current.cta_40700200700000 != null && current.cta_40700200700000.Total40700200700000 != 0)
                    current.Total40700200000000 += (Decimal)current.cta_40700200700000.Total40700200700000;
                if (current.cta_40700200800000 != null && current.cta_40700200800000.Total40700200800000 != 0)
                    current.Total40700200000000 += (Decimal)current.cta_40700200800000.Total40700200800000;
                if (current.cta_40700200900000 != null && current.cta_40700200900000.Total40700200900000 != 0)
                    current.Total40700200000000 += (Decimal)current.cta_40700200900000.Total40700200900000;
                if (current.cta_40700201000000 != null && current.cta_40700201000000.Total40700201000000 != 0)
                    current.Total40700200000000 += (Decimal)current.cta_40700201000000.Total40700201000000;
                if (current.cta_40700201100000 != null && current.cta_40700201100000.Total40700201100000 != 0)
                    current.Total40700200000000 += (Decimal)current.cta_40700201100000.Total40700201100000;
                if (current.cta_40700201200000 != null && current.cta_40700201200000.Total40700201200000 != 0)
                    current.Total40700200000000 += (Decimal)current.cta_40700201200000.Total40700201200000;
                if (current.cta_40700201300000 != null && current.cta_40700201300000.Total40700201300000 != 0)
                    current.Total40700200000000 += (Decimal)current.cta_40700201300000.Total40700201300000;
                if (current.cta_40700209900000 != null && current.cta_40700209900000.Total40700209900000 != 0)
                    current.Total40700200000000 += (Decimal)current.cta_40700209900000.Total40700209900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700300100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700300100000;
                current.Total40700300100000 = 0;
                if (current.cta_40700300101000 != null)
                    current.Total40700300100000 += (Decimal)current.cta_40700300101000;
                if (current.cta_40700300102000 != null)
                    current.Total40700300100000 += (Decimal)current.cta_40700300102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700300200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700300200000;
                current.Total40700300200000 = 0;
                if (current.cta_40700300201000 != null)
                    current.Total40700300200000 += (Decimal)current.cta_40700300201000;
                if (current.cta_40700300202000 != null)
                    current.Total40700300200000 += (Decimal)current.cta_40700300202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700300300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700300300000;
                current.Total40700300300000 = 0;
                if (current.cta_40700300301000 != null)
                    current.Total40700300300000 += (Decimal)current.cta_40700300301000;
                if (current.cta_40700300302000 != null)
                    current.Total40700300300000 += (Decimal)current.cta_40700300302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700300400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700300400000;
                current.Total40700300400000 = 0;
                if (current.cta_40700300401000 != null)
                    current.Total40700300400000 += (Decimal)current.cta_40700300401000;
                if (current.cta_40700300402000 != null)
                    current.Total40700300400000 += (Decimal)current.cta_40700300402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700300500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700300500000;
                current.Total40700300500000 = 0;
                if (current.cta_40700300501000 != null)
                    current.Total40700300500000 += (Decimal)current.cta_40700300501000;
                if (current.cta_40700300502000 != null)
                    current.Total40700300500000 += (Decimal)current.cta_40700300502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700300600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700300600000;
                current.Total40700300600000 = 0;
                if (current.cta_40700300601000 != null)
                    current.Total40700300600000 += (Decimal)current.cta_40700300601000;
                if (current.cta_40700300602000 != null)
                    current.Total40700300600000 += (Decimal)current.cta_40700300602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700300700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700300700000;
                current.Total40700300700000 = 0;
                if (current.cta_40700300701000 != null)
                    current.Total40700300700000 += (Decimal)current.cta_40700300701000;
                if (current.cta_40700300702000 != null)
                    current.Total40700300700000 += (Decimal)current.cta_40700300702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700309900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000.cta_40700309900000;
                current.Total40700309900000 = 0;
                if (current.cta_40700309901000 != null)
                    current.Total40700309900000 += (Decimal)current.cta_40700309901000;
                if (current.cta_40700309902000 != null)
                    current.Total40700309900000 += (Decimal)current.cta_40700309902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700300000000;
                current.Total40700300000000 = 0;
                if (current.cta_40700300100000 != null && current.cta_40700300100000.Total40700300100000 != 0)
                    current.Total40700300000000 += (Decimal)current.cta_40700300100000.Total40700300100000;
                if (current.cta_40700300200000 != null && current.cta_40700300200000.Total40700300200000 != 0)
                    current.Total40700300000000 += (Decimal)current.cta_40700300200000.Total40700300200000;
                if (current.cta_40700300300000 != null && current.cta_40700300300000.Total40700300300000 != 0)
                    current.Total40700300000000 += (Decimal)current.cta_40700300300000.Total40700300300000;
                if (current.cta_40700300400000 != null && current.cta_40700300400000.Total40700300400000 != 0)
                    current.Total40700300000000 += (Decimal)current.cta_40700300400000.Total40700300400000;
                if (current.cta_40700300500000 != null && current.cta_40700300500000.Total40700300500000 != 0)
                    current.Total40700300000000 += (Decimal)current.cta_40700300500000.Total40700300500000;
                if (current.cta_40700300600000 != null && current.cta_40700300600000.Total40700300600000 != 0)
                    current.Total40700300000000 += (Decimal)current.cta_40700300600000.Total40700300600000;
                if (current.cta_40700300700000 != null && current.cta_40700300700000.Total40700300700000 != 0)
                    current.Total40700300000000 += (Decimal)current.cta_40700300700000.Total40700300700000;
                if (current.cta_40700309900000 != null && current.cta_40700309900000.Total40700309900000 != 0)
                    current.Total40700300000000 += (Decimal)current.cta_40700309900000.Total40700309900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400100000;
                current.Total40700400100000 = 0;
                if (current.cta_40700400101000 != null)
                    current.Total40700400100000 += (Decimal)current.cta_40700400101000;
                if (current.cta_40700400102000 != null)
                    current.Total40700400100000 += (Decimal)current.cta_40700400102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400300000;
                current.Total40700400300000 = 0;
                if (current.cta_40700400301000 != null)
                    current.Total40700400300000 += (Decimal)current.cta_40700400301000;
                if (current.cta_40700400302000 != null)
                    current.Total40700400300000 += (Decimal)current.cta_40700400302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400400000;
                current.Total40700400400000 = 0;
                if (current.cta_40700400401000 != null)
                    current.Total40700400400000 += (Decimal)current.cta_40700400401000;
                if (current.cta_40700400402000 != null)
                    current.Total40700400400000 += (Decimal)current.cta_40700400402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400500000;
                current.Total40700400500000 = 0;
                if (current.cta_40700400501000 != null)
                    current.Total40700400500000 += (Decimal)current.cta_40700400501000;
                if (current.cta_40700400502000 != null)
                    current.Total40700400500000 += (Decimal)current.cta_40700400502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400600000;
                current.Total40700400600000 = 0;
                if (current.cta_40700400601000 != null)
                    current.Total40700400600000 += (Decimal)current.cta_40700400601000;
                if (current.cta_40700400602000 != null)
                    current.Total40700400600000 += (Decimal)current.cta_40700400602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400700000;
                current.Total40700400700000 = 0;
                if (current.cta_40700400701000 != null)
                    current.Total40700400700000 += (Decimal)current.cta_40700400701000;
                if (current.cta_40700400702000 != null)
                    current.Total40700400700000 += (Decimal)current.cta_40700400702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400800000;
                current.Total40700400800000 = 0;
                if (current.cta_40700400801000 != null)
                    current.Total40700400800000 += (Decimal)current.cta_40700400801000;
                if (current.cta_40700400802000 != null)
                    current.Total40700400800000 += (Decimal)current.cta_40700400802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700400900000;
                current.Total40700400900000 = 0;
                if (current.cta_40700400901000 != null)
                    current.Total40700400900000 += (Decimal)current.cta_40700400901000;
                if (current.cta_40700400902000 != null)
                    current.Total40700400900000 += (Decimal)current.cta_40700400902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700401000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700401000000;
                current.Total40700401000000 = 0;
                if (current.cta_40700401001000 != null)
                    current.Total40700401000000 += (Decimal)current.cta_40700401001000;
                if (current.cta_40700401002000 != null)
                    current.Total40700401000000 += (Decimal)current.cta_40700401002000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700409900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000.cta_40700409900000;
                current.Total40700409900000 = 0;
                if (current.cta_40700409901000 != null)
                    current.Total40700409900000 += (Decimal)current.cta_40700409901000;
                if (current.cta_40700409902000 != null)
                    current.Total40700409900000 += (Decimal)current.cta_40700409902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700400000000;
                current.Total40700400000000 = 0;
                if (current.cta_40700400100000 != null && current.cta_40700400100000.Total40700400100000 != 0)
                    current.Total40700400000000 += (Decimal)current.cta_40700400100000.Total40700400100000;
                if (current.cta_40700400300000 != null && current.cta_40700400300000.Total40700400300000 != 0)
                    current.Total40700400000000 += (Decimal)current.cta_40700400300000.Total40700400300000;
                if (current.cta_40700400400000 != null && current.cta_40700400400000.Total40700400400000 != 0)
                    current.Total40700400000000 += (Decimal)current.cta_40700400400000.Total40700400400000;
                if (current.cta_40700400500000 != null && current.cta_40700400500000.Total40700400500000 != 0)
                    current.Total40700400000000 += (Decimal)current.cta_40700400500000.Total40700400500000;
                if (current.cta_40700400600000 != null && current.cta_40700400600000.Total40700400600000 != 0)
                    current.Total40700400000000 += (Decimal)current.cta_40700400600000.Total40700400600000;
                if (current.cta_40700400700000 != null && current.cta_40700400700000.Total40700400700000 != 0)
                    current.Total40700400000000 += (Decimal)current.cta_40700400700000.Total40700400700000;
                if (current.cta_40700400800000 != null && current.cta_40700400800000.Total40700400800000 != 0)
                    current.Total40700400000000 += (Decimal)current.cta_40700400800000.Total40700400800000;
                if (current.cta_40700400900000 != null && current.cta_40700400900000.Total40700400900000 != 0)
                    current.Total40700400000000 += (Decimal)current.cta_40700400900000.Total40700400900000;
                if (current.cta_40700401000000 != null && current.cta_40700401000000.Total40700401000000 != 0)
                    current.Total40700400000000 += (Decimal)current.cta_40700401000000.Total40700401000000;
                if (current.cta_40700409900000 != null && current.cta_40700409900000.Total40700409900000 != 0)
                    current.Total40700400000000 += (Decimal)current.cta_40700409900000.Total40700409900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700500300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700500300000;
                current.Total40700500300000 = 0;
                if (current.cta_40700500301000 != null)
                    current.Total40700500300000 += (Decimal)current.cta_40700500301000;
                if (current.cta_40700500302000 != null)
                    current.Total40700500300000 += (Decimal)current.cta_40700500302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700500400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700500400000;
                current.Total40700500400000 = 0;
                if (current.cta_40700500401000 != null)
                    current.Total40700500400000 += (Decimal)current.cta_40700500401000;
                if (current.cta_40700500402000 != null)
                    current.Total40700500400000 += (Decimal)current.cta_40700500402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700500500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700500500000;
                current.Total40700500500000 = 0;
                if (current.cta_40700500501000 != null)
                    current.Total40700500500000 += (Decimal)current.cta_40700500501000;
                if (current.cta_40700500502000 != null)
                    current.Total40700500500000 += (Decimal)current.cta_40700500502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700500600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700500600000;
                current.Total40700500600000 = 0;
                if (current.cta_40700500601000 != null)
                    current.Total40700500600000 += (Decimal)current.cta_40700500601000;
                if (current.cta_40700500602000 != null)
                    current.Total40700500600000 += (Decimal)current.cta_40700500602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700500700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700500700000;
                current.Total40700500700000 = 0;
                if (current.cta_40700500701000 != null)
                    current.Total40700500700000 += (Decimal)current.cta_40700500701000;
                if (current.cta_40700500702000 != null)
                    current.Total40700500700000 += (Decimal)current.cta_40700500702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700500800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700500800000;
                current.Total40700500800000 = 0;
                if (current.cta_40700500801000 != null)
                    current.Total40700500800000 += (Decimal)current.cta_40700500801000;
                if (current.cta_40700500802000 != null)
                    current.Total40700500800000 += (Decimal)current.cta_40700500802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700500900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700500900000;
                current.Total40700500900000 = 0;
                if (current.cta_40700500901000 != null)
                    current.Total40700500900000 += (Decimal)current.cta_40700500901000;
                if (current.cta_40700500902000 != null)
                    current.Total40700500900000 += (Decimal)current.cta_40700500902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501000000;
                current.Total40700501000000 = 0;
                if (current.cta_40700501001000 != null)
                    current.Total40700501000000 += (Decimal)current.cta_40700501001000;
                if (current.cta_40700501002000 != null)
                    current.Total40700501000000 += (Decimal)current.cta_40700501002000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501100000;
                current.Total40700501100000 = 0;
                if (current.cta_40700501101000 != null)
                    current.Total40700501100000 += (Decimal)current.cta_40700501101000;
                if (current.cta_40700501102000 != null)
                    current.Total40700501100000 += (Decimal)current.cta_40700501102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501200000;
                current.Total40700501200000 = 0;
                if (current.cta_40700501201000 != null)
                    current.Total40700501200000 += (Decimal)current.cta_40700501201000;
                if (current.cta_40700501202000 != null)
                    current.Total40700501200000 += (Decimal)current.cta_40700501202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501300000;
                current.Total40700501300000 = 0;
                if (current.cta_40700501301000 != null)
                    current.Total40700501300000 += (Decimal)current.cta_40700501301000;
                if (current.cta_40700501302000 != null)
                    current.Total40700501300000 += (Decimal)current.cta_40700501302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501400000;
                current.Total40700501400000 = 0;
                if (current.cta_40700501401000 != null)
                    current.Total40700501400000 += (Decimal)current.cta_40700501401000;
                if (current.cta_40700501402000 != null)
                    current.Total40700501400000 += (Decimal)current.cta_40700501402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501500000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501500000;
                current.Total40700501500000 = 0;
                if (current.cta_40700501501000 != null)
                    current.Total40700501500000 += (Decimal)current.cta_40700501501000;
                if (current.cta_40700501502000 != null)
                    current.Total40700501500000 += (Decimal)current.cta_40700501502000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501600000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501600000;
                current.Total40700501600000 = 0;
                if (current.cta_40700501601000 != null)
                    current.Total40700501600000 += (Decimal)current.cta_40700501601000;
                if (current.cta_40700501602000 != null)
                    current.Total40700501600000 += (Decimal)current.cta_40700501602000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501700000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501700000;
                current.Total40700501700000 = 0;
                if (current.cta_40700501701000 != null)
                    current.Total40700501700000 += (Decimal)current.cta_40700501701000;
                if (current.cta_40700501702000 != null)
                    current.Total40700501700000 += (Decimal)current.cta_40700501702000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501800000;
                current.Total40700501800000 = 0;
                if (current.cta_40700501801000 != null)
                    current.Total40700501800000 += (Decimal)current.cta_40700501801000;
                if (current.cta_40700501802000 != null)
                    current.Total40700501800000 += (Decimal)current.cta_40700501802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700501900000;
                current.Total40700501900000 = 0;
                if (current.cta_40700501901000 != null)
                    current.Total40700501900000 += (Decimal)current.cta_40700501901000;
                if (current.cta_40700501902000 != null)
                    current.Total40700501900000 += (Decimal)current.cta_40700501902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700509900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000.cta_40700509900000;
                current.Total40700509900000 = 0;
                if (current.cta_40700509901000 != null)
                    current.Total40700509900000 += (Decimal)current.cta_40700509901000;
                if (current.cta_40700509902000 != null)
                    current.Total40700509900000 += (Decimal)current.cta_40700509902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null && modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000.cta_40700500000000;
                current.Total40700500000000 = 0;
                if (current.cta_40700500300000 != null && current.cta_40700500300000.Total40700500300000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700500300000.Total40700500300000;
                if (current.cta_40700500400000 != null && current.cta_40700500400000.Total40700500400000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700500400000.Total40700500400000;
                if (current.cta_40700500500000 != null && current.cta_40700500500000.Total40700500500000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700500500000.Total40700500500000;
                if (current.cta_40700500600000 != null && current.cta_40700500600000.Total40700500600000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700500600000.Total40700500600000;
                if (current.cta_40700500700000 != null && current.cta_40700500700000.Total40700500700000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700500700000.Total40700500700000;
                if (current.cta_40700500800000 != null && current.cta_40700500800000.Total40700500800000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700500800000.Total40700500800000;
                if (current.cta_40700500900000 != null && current.cta_40700500900000.Total40700500900000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700500900000.Total40700500900000;
                if (current.cta_40700501000000 != null && current.cta_40700501000000.Total40700501000000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700501000000.Total40700501000000;
                if (current.cta_40700501100000 != null && current.cta_40700501100000.Total40700501100000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700501100000.Total40700501100000;
                if (current.cta_40700501200000 != null && current.cta_40700501200000.Total40700501200000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700501200000.Total40700501200000;
                if (current.cta_40700501300000 != null && current.cta_40700501300000.Total40700501300000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700501300000.Total40700501300000;
                if (current.cta_40700501400000 != null && current.cta_40700501400000.Total40700501400000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700501400000.Total40700501400000;
                if (current.cta_40700501500000 != null && current.cta_40700501500000.Total40700501500000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700501500000.Total40700501500000;
                if (current.cta_40700501600000 != null && current.cta_40700501600000.Total40700501600000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700501600000.Total40700501600000;
                if (current.cta_40700501700000 != null && current.cta_40700501700000.Total40700501700000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700501700000.Total40700501700000;
                if (current.cta_40700501800000 != null && current.cta_40700501800000.Total40700501800000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700501800000.Total40700501800000;
                if (current.cta_40700501900000 != null && current.cta_40700501900000.Total40700501900000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700501900000.Total40700501900000;
                if (current.cta_40700509900000 != null && current.cta_40700509900000.Total40700509900000 != 0)
                    current.Total40700500000000 += (Decimal)current.cta_40700509900000.Total40700509900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40700000000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40700000000000;
                current.Total40700000000000 = 0;
                if (current.cta_40700100000000 != null && current.cta_40700100000000.Total40700100000000 != 0)
                    current.Total40700000000000 += (Decimal)current.cta_40700100000000.Total40700100000000;
                if (current.cta_40700200000000 != null && current.cta_40700200000000.Total40700200000000 != 0)
                    current.Total40700000000000 += (Decimal)current.cta_40700200000000.Total40700200000000;
                if (current.cta_40700300000000 != null && current.cta_40700300000000.Total40700300000000 != 0)
                    current.Total40700000000000 += (Decimal)current.cta_40700300000000.Total40700300000000;
                if (current.cta_40700400000000 != null && current.cta_40700400000000.Total40700400000000 != 0)
                    current.Total40700000000000 += (Decimal)current.cta_40700400000000.Total40700400000000;
                if (current.cta_40700500000000 != null && current.cta_40700500000000.Total40700500000000 != 0)
                    current.Total40700000000000 += (Decimal)current.cta_40700500000000.Total40700500000000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40800000000000 != null && modelo.cta_40000000000000.cta_40800000000000.cta_40800100000000 != null && modelo.cta_40000000000000.cta_40800000000000.cta_40800100000000.cta_40800100800000 != null && modelo.cta_40000000000000.cta_40800000000000.cta_40800100000000.cta_40800100800000.cta_40800100801000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40800000000000.cta_40800100000000.cta_40800100800000.cta_40800100801000;
                current.Total40800100801000 = 0;
                if (current.cta_40800100801010 != null)
                    current.Total40800100801000 += (Decimal)current.cta_40800100801010;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40800000000000 != null && modelo.cta_40000000000000.cta_40800000000000.cta_40800100000000 != null && modelo.cta_40000000000000.cta_40800000000000.cta_40800100000000.cta_40800100800000 != null && modelo.cta_40000000000000.cta_40800000000000.cta_40800100000000.cta_40800100800000.cta_40800100802000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40800000000000.cta_40800100000000.cta_40800100800000.cta_40800100802000;
                current.Total40800100802000 = 0;
                if (current.cta_40800100802010 != null)
                    current.Total40800100802000 += (Decimal)current.cta_40800100802010;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40800000000000 != null && modelo.cta_40000000000000.cta_40800000000000.cta_40800100000000 != null && modelo.cta_40000000000000.cta_40800000000000.cta_40800100000000.cta_40800100800000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40800000000000.cta_40800100000000.cta_40800100800000;
                current.Total40800100800000 = 0;
                if (current.cta_40800100801000 != null && current.cta_40800100801000.Total40800100801000 != 0)
                    current.Total40800100800000 += (Decimal)current.cta_40800100801000.Total40800100801000;
                if (current.cta_40800100802000 != null && current.cta_40800100802000.Total40800100802000 != 0)
                    current.Total40800100800000 += (Decimal)current.cta_40800100802000.Total40800100802000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40800000000000 != null && modelo.cta_40000000000000.cta_40800000000000.cta_40800100000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40800000000000.cta_40800100000000;
                current.Total40800100000000 = 0;
                if (current.cta_40800100800000 != null && current.cta_40800100800000.Total40800100800000 != 0)
                    current.Total40800100000000 += (Decimal)current.cta_40800100800000.Total40800100800000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40800000000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40800000000000;
                current.Total40800000000000 = 0;
                if (current.cta_40800100000000 != null && current.cta_40800100000000.Total40800100000000 != 0)
                    current.Total40800000000000 += (Decimal)current.cta_40800100000000.Total40800100000000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40900000000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900100000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900100000000.cta_40900100100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40900000000000.cta_40900100000000.cta_40900100100000;
                current.Total40900100100000 = 0;
                if (current.cta_40900100101000 != null)
                    current.Total40900100100000 += (Decimal)current.cta_40900100101000;
                if (current.cta_40900100102000 != null)
                    current.Total40900100100000 += (Decimal)current.cta_40900100102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40900000000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900100000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900100000000.cta_40900100200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40900000000000.cta_40900100000000.cta_40900100200000;
                current.Total40900100200000 = 0;
                if (current.cta_40900100201000 != null)
                    current.Total40900100200000 += (Decimal)current.cta_40900100201000;
                if (current.cta_40900100202000 != null)
                    current.Total40900100200000 += (Decimal)current.cta_40900100202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40900000000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900100000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900100000000.cta_40900100300000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40900000000000.cta_40900100000000.cta_40900100300000;
                current.Total40900100300000 = 0;
                if (current.cta_40900100301000 != null)
                    current.Total40900100300000 += (Decimal)current.cta_40900100301000;
                if (current.cta_40900100302000 != null)
                    current.Total40900100300000 += (Decimal)current.cta_40900100302000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40900000000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900100000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40900000000000.cta_40900100000000;
                current.Total40900100000000 = 0;
                if (current.cta_40900100100000 != null && current.cta_40900100100000.Total40900100100000 != 0)
                    current.Total40900100000000 += (Decimal)current.cta_40900100100000.Total40900100100000;
                if (current.cta_40900100200000 != null && current.cta_40900100200000.Total40900100200000 != 0)
                    current.Total40900100000000 += (Decimal)current.cta_40900100200000.Total40900100200000;
                if (current.cta_40900100300000 != null && current.cta_40900100300000.Total40900100300000 != 0)
                    current.Total40900100000000 += (Decimal)current.cta_40900100300000.Total40900100300000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40900000000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000.cta_40900200400000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000.cta_40900200400000;
                current.Total40900200400000 = 0;
                if (current.cta_40900200401000 != null)
                    current.Total40900200400000 += (Decimal)current.cta_40900200401000;
                if (current.cta_40900200402000 != null)
                    current.Total40900200400000 += (Decimal)current.cta_40900200402000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40900000000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000.cta_40900200900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000.cta_40900200900000;
                current.Total40900200900000 = 0;
                if (current.cta_40900200901000 != null)
                    current.Total40900200900000 += (Decimal)current.cta_40900200901000;
                if (current.cta_40900200902000 != null)
                    current.Total40900200900000 += (Decimal)current.cta_40900200902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40900000000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000.cta_40900201000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000.cta_40900201000000;
                current.Total40900201000000 = 0;
                if (current.cta_40900201001000 != null)
                    current.Total40900201000000 += (Decimal)current.cta_40900201001000;
                if (current.cta_40900201002000 != null)
                    current.Total40900201000000 += (Decimal)current.cta_40900201002000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40900000000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000.cta_40900201100000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000.cta_40900201100000;
                current.Total40900201100000 = 0;
                if (current.cta_40900201101000 != null)
                    current.Total40900201100000 += (Decimal)current.cta_40900201101000;
                if (current.cta_40900201102000 != null)
                    current.Total40900201100000 += (Decimal)current.cta_40900201102000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40900000000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000.cta_40900201200000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000.cta_40900201200000;
                current.Total40900201200000 = 0;
                if (current.cta_40900201201000 != null)
                    current.Total40900201200000 += (Decimal)current.cta_40900201201000;
                if (current.cta_40900201202000 != null)
                    current.Total40900201200000 += (Decimal)current.cta_40900201202000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40900000000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000.cta_40900209900000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000.cta_40900209900000;
                current.Total40900209900000 = 0;
                if (current.cta_40900209901000 != null)
                    current.Total40900209900000 += (Decimal)current.cta_40900209901000;
                if (current.cta_40900209902000 != null)
                    current.Total40900209900000 += (Decimal)current.cta_40900209902000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40900000000000 != null && modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40900000000000.cta_40900200000000;
                current.Total40900200000000 = 0;
                if (current.cta_40900200400000 != null && current.cta_40900200400000.Total40900200400000 != 0)
                    current.Total40900200000000 += (Decimal)current.cta_40900200400000.Total40900200400000;
                if (current.cta_40900200900000 != null && current.cta_40900200900000.Total40900200900000 != 0)
                    current.Total40900200000000 += (Decimal)current.cta_40900200900000.Total40900200900000;
                if (current.cta_40900201000000 != null && current.cta_40900201000000.Total40900201000000 != 0)
                    current.Total40900200000000 += (Decimal)current.cta_40900201000000.Total40900201000000;
                if (current.cta_40900201100000 != null && current.cta_40900201100000.Total40900201100000 != 0)
                    current.Total40900200000000 += (Decimal)current.cta_40900201100000.Total40900201100000;
                if (current.cta_40900201200000 != null && current.cta_40900201200000.Total40900201200000 != 0)
                    current.Total40900200000000 += (Decimal)current.cta_40900201200000.Total40900201200000;
                if (current.cta_40900209900000 != null && current.cta_40900209900000.Total40900209900000 != 0)
                    current.Total40900200000000 += (Decimal)current.cta_40900209900000.Total40900209900000;
            }
            if (modelo.cta_40000000000000 != null && modelo.cta_40000000000000.cta_40900000000000 != null)
            {
                var current = modelo.cta_40000000000000.cta_40900000000000;
                current.Total40900000000000 = 0;
                if (current.cta_40900100000000 != null && current.cta_40900100000000.Total40900100000000 != 0)
                    current.Total40900000000000 += (Decimal)current.cta_40900100000000.Total40900100000000;
                if (current.cta_40900200000000 != null && current.cta_40900200000000.Total40900200000000 != 0)
                    current.Total40900000000000 += (Decimal)current.cta_40900200000000.Total40900200000000;
            }
            if (modelo.cta_40000000000000 != null)
            {
                var current = modelo.cta_40000000000000;
                current.Total40000000000000 = 0;
                if (current.cta_40100000000000 != null && current.cta_40100000000000.Total40100000000000 != 0)
                    current.Total40000000000000 += (Decimal)current.cta_40100000000000.Total40100000000000;
                if (current.cta_40200000000000 != null && current.cta_40200000000000.Total40200000000000 != 0)
                    current.Total40000000000000 += (Decimal)current.cta_40200000000000.Total40200000000000;
                if (current.cta_40300000000000 != null && current.cta_40300000000000.Total40300000000000 != 0)
                    current.Total40000000000000 += (Decimal)current.cta_40300000000000.Total40300000000000;
                if (current.cta_40500000000000 != null && current.cta_40500000000000.Total40500000000000 != 0)
                    current.Total40000000000000 += (Decimal)current.cta_40500000000000.Total40500000000000;
                if (current.cta_40600000000000 != null && current.cta_40600000000000.Total40600000000000 != 0)
                    current.Total40000000000000 += (Decimal)current.cta_40600000000000.Total40600000000000;
                if (current.cta_40700000000000 != null && current.cta_40700000000000.Total40700000000000 != 0)
                    current.Total40000000000000 += (Decimal)current.cta_40700000000000.Total40700000000000;
                if (current.cta_40800000000000 != null && current.cta_40800000000000.Total40800000000000 != 0)
                    current.Total40000000000000 += (Decimal)current.cta_40800000000000.Total40800000000000;
                if (current.cta_40900000000000 != null && current.cta_40900000000000.Total40900000000000 != 0)
                    current.Total40000000000000 += (Decimal)current.cta_40900000000000.Total40900000000000;
            }
        }

    }
}
