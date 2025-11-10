using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.Sugese.SaldosContables.Domain.Application.Total
{
    internal class TotalCuenta1a
    {
        public static void Mapper(string account, Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModelo modelo, System.Nullable<decimal> value, bool specified)
        {
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100100000;
                current.Total10100100100000 = 0;
                if (current.cta_10100100101000 != null)
                    current.Total10100100100000 += (Decimal)current.cta_10100100101000;
                if (current.cta_10100100102000 != null)
                    current.Total10100100100000 += (Decimal)current.cta_10100100102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100300000;
                current.Total10100100300000 = 0;
                if (current.cta_10100100301000 != null)
                    current.Total10100100300000 += (Decimal)current.cta_10100100301000;
                if (current.cta_10100100302000 != null)
                    current.Total10100100300000 += (Decimal)current.cta_10100100302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000;
                current.Total10100100000000 = 0;
                if (current.cta_10100100100000 != null && current.cta_10100100100000.Total10100100100000 != 0)
                    current.Total10100100000000 += (Decimal)current.cta_10100100100000.Total10100100100000;
                if (current.cta_10100100300000 != null && current.cta_10100100300000.Total10100100300000 != 0)
                    current.Total10100100000000 += (Decimal)current.cta_10100100300000.Total10100100300000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000.cta_10100200100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000.cta_10100200100000;
                current.Total10100200100000 = 0;
                if (current.cta_10100200101000 != null)
                    current.Total10100200100000 += (Decimal)current.cta_10100200101000;
                if (current.cta_10100200102000 != null)
                    current.Total10100200100000 += (Decimal)current.cta_10100200102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000;
                current.Total10100200000000 = 0;
                if (current.cta_10100200100000 != null && current.cta_10100200100000.Total10100200100000 != 0)
                    current.Total10100200000000 += (Decimal)current.cta_10100200100000.Total10100200100000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300101000;
                current.Total10100300101000 = 0;
                if (current.cta_10100300101010 != null)
                    current.Total10100300101000 += (Decimal)current.cta_10100300101010;
                if (current.cta_10100300101020 != null)
                    current.Total10100300101000 += (Decimal)current.cta_10100300101020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300102000;
                current.Total10100300102000 = 0;
                if (current.cta_10100300102010 != null)
                    current.Total10100300102000 += (Decimal)current.cta_10100300102010;
                if (current.cta_10100300102020 != null)
                    current.Total10100300102000 += (Decimal)current.cta_10100300102020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000;
                current.Total10100300100000 = 0;
                if (current.cta_10100300101000 != null && current.cta_10100300101000.Total10100300101000 != 0)
                    current.Total10100300100000 += (Decimal)current.cta_10100300101000.Total10100300101000;
                if (current.cta_10100300102000 != null && current.cta_10100300102000.Total10100300102000 != 0)
                    current.Total10100300100000 += (Decimal)current.cta_10100300102000.Total10100300102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300201000;
                current.Total10100300201000 = 0;
                if (current.cta_10100300201010 != null)
                    current.Total10100300201000 += (Decimal)current.cta_10100300201010;
                if (current.cta_10100300201020 != null)
                    current.Total10100300201000 += (Decimal)current.cta_10100300201020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300202000;
                current.Total10100300202000 = 0;
                if (current.cta_10100300202010 != null)
                    current.Total10100300202000 += (Decimal)current.cta_10100300202010;
                if (current.cta_10100300202020 != null)
                    current.Total10100300202000 += (Decimal)current.cta_10100300202020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000;
                current.Total10100300200000 = 0;
                if (current.cta_10100300201000 != null && current.cta_10100300201000.Total10100300201000 != 0)
                    current.Total10100300200000 += (Decimal)current.cta_10100300201000.Total10100300201000;
                if (current.cta_10100300202000 != null && current.cta_10100300202000.Total10100300202000 != 0)
                    current.Total10100300200000 += (Decimal)current.cta_10100300202000.Total10100300202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000.cta_10100300501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000.cta_10100300501000;
                current.Total10100300501000 = 0;
                if (current.cta_10100300501990 != null)
                    current.Total10100300501000 += (Decimal)current.cta_10100300501990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000.cta_10100300502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000.cta_10100300502000;
                current.Total10100300502000 = 0;
                if (current.cta_10100300502990 != null)
                    current.Total10100300502000 += (Decimal)current.cta_10100300502990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000;
                current.Total10100300500000 = 0;
                if (current.cta_10100300501000 != null && current.cta_10100300501000.Total10100300501000 != 0)
                    current.Total10100300500000 += (Decimal)current.cta_10100300501000.Total10100300501000;
                if (current.cta_10100300502000 != null && current.cta_10100300502000.Total10100300502000 != 0)
                    current.Total10100300500000 += (Decimal)current.cta_10100300502000.Total10100300502000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300600000;
                current.Total10100300600000 = 0;
                if (current.cta_10100300601000 != null)
                    current.Total10100300600000 += (Decimal)current.cta_10100300601000;
                if (current.cta_10100300602000 != null)
                    current.Total10100300600000 += (Decimal)current.cta_10100300602000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000;
                current.Total10100300000000 = 0;
                if (current.cta_10100300100000 != null && current.cta_10100300100000.Total10100300100000 != 0)
                    current.Total10100300000000 += (Decimal)current.cta_10100300100000.Total10100300100000;
                if (current.cta_10100300200000 != null && current.cta_10100300200000.Total10100300200000 != 0)
                    current.Total10100300000000 += (Decimal)current.cta_10100300200000.Total10100300200000;
                if (current.cta_10100300500000 != null && current.cta_10100300500000.Total10100300500000 != 0)
                    current.Total10100300000000 += (Decimal)current.cta_10100300500000.Total10100300500000;
                if (current.cta_10100300600000 != null && current.cta_10100300600000.Total10100300600000 != 0)
                    current.Total10100300000000 += (Decimal)current.cta_10100300600000.Total10100300600000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400100000;
                current.Total10100400100000 = 0;
                if (current.cta_10100400101000 != null)
                    current.Total10100400100000 += (Decimal)current.cta_10100400101000;
                if (current.cta_10100400102000 != null)
                    current.Total10100400100000 += (Decimal)current.cta_10100400102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400200000;
                current.Total10100400200000 = 0;
                if (current.cta_10100400201000 != null)
                    current.Total10100400200000 += (Decimal)current.cta_10100400201000;
                if (current.cta_10100400202000 != null)
                    current.Total10100400200000 += (Decimal)current.cta_10100400202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400500000;
                current.Total10100400500000 = 0;
                if (current.cta_10100400501000 != null)
                    current.Total10100400500000 += (Decimal)current.cta_10100400501000;
                if (current.cta_10100400502000 != null)
                    current.Total10100400500000 += (Decimal)current.cta_10100400502000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400600000;
                current.Total10100400600000 = 0;
                if (current.cta_10100400601000 != null)
                    current.Total10100400600000 += (Decimal)current.cta_10100400601000;
                if (current.cta_10100400602000 != null)
                    current.Total10100400600000 += (Decimal)current.cta_10100400602000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000;
                current.Total10100400000000 = 0;
                if (current.cta_10100400100000 != null && current.cta_10100400100000.Total10100400100000 != 0)
                    current.Total10100400000000 += (Decimal)current.cta_10100400100000.Total10100400100000;
                if (current.cta_10100400200000 != null && current.cta_10100400200000.Total10100400200000 != 0)
                    current.Total10100400000000 += (Decimal)current.cta_10100400200000.Total10100400200000;
                if (current.cta_10100400500000 != null && current.cta_10100400500000.Total10100400500000 != 0)
                    current.Total10100400000000 += (Decimal)current.cta_10100400500000.Total10100400500000;
                if (current.cta_10100400600000 != null && current.cta_10100400600000.Total10100400600000 != 0)
                    current.Total10100400000000 += (Decimal)current.cta_10100400600000.Total10100400600000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500101000;
                current.Total10100500101000 = 0;
                if (current.cta_10100500101010 != null)
                    current.Total10100500101000 += (Decimal)current.cta_10100500101010;
                if (current.cta_10100500101020 != null)
                    current.Total10100500101000 += (Decimal)current.cta_10100500101020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500102000;
                current.Total10100500102000 = 0;
                if (current.cta_10100500102010 != null)
                    current.Total10100500102000 += (Decimal)current.cta_10100500102010;
                if (current.cta_10100500102020 != null)
                    current.Total10100500102000 += (Decimal)current.cta_10100500102020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000;
                current.Total10100500100000 = 0;
                if (current.cta_10100500101000 != null && current.cta_10100500101000.Total10100500101000 != 0)
                    current.Total10100500100000 += (Decimal)current.cta_10100500101000.Total10100500101000;
                if (current.cta_10100500102000 != null && current.cta_10100500102000.Total10100500102000 != 0)
                    current.Total10100500100000 += (Decimal)current.cta_10100500102000.Total10100500102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000;
                current.Total10100500000000 = 0;
                if (current.cta_10100500100000 != null && current.cta_10100500100000.Total10100500100000 != 0)
                    current.Total10100500000000 += (Decimal)current.cta_10100500100000.Total10100500100000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000.cta_10100600101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000.cta_10100600101000;
                current.Total10100600101000 = 0;
                if (current.cta_10100600101010 != null)
                    current.Total10100600101000 += (Decimal)current.cta_10100600101010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000.cta_10100600102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000.cta_10100600102000;
                current.Total10100600102000 = 0;
                if (current.cta_10100600102010 != null)
                    current.Total10100600102000 += (Decimal)current.cta_10100600102010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000;
                current.Total10100600100000 = 0;
                if (current.cta_10100600101000 != null && current.cta_10100600101000.Total10100600101000 != 0)
                    current.Total10100600100000 += (Decimal)current.cta_10100600101000.Total10100600101000;
                if (current.cta_10100600102000 != null && current.cta_10100600102000.Total10100600102000 != 0)
                    current.Total10100600100000 += (Decimal)current.cta_10100600102000.Total10100600102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000.cta_10100600201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000.cta_10100600201000;
                current.Total10100600201000 = 0;
                if (current.cta_10100600201010 != null)
                    current.Total10100600201000 += (Decimal)current.cta_10100600201010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000.cta_10100600202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000.cta_10100600202000;
                current.Total10100600202000 = 0;
                if (current.cta_10100600202010 != null)
                    current.Total10100600202000 += (Decimal)current.cta_10100600202010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000;
                current.Total10100600200000 = 0;
                if (current.cta_10100600201000 != null && current.cta_10100600201000.Total10100600201000 != 0)
                    current.Total10100600200000 += (Decimal)current.cta_10100600201000.Total10100600201000;
                if (current.cta_10100600202000 != null && current.cta_10100600202000.Total10100600202000 != 0)
                    current.Total10100600200000 += (Decimal)current.cta_10100600202000.Total10100600202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000.cta_10100600301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000.cta_10100600301000;
                current.Total10100600301000 = 0;
                if (current.cta_10100600301010 != null)
                    current.Total10100600301000 += (Decimal)current.cta_10100600301010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000.cta_10100600302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000.cta_10100600302000;
                current.Total10100600302000 = 0;
                if (current.cta_10100600302010 != null)
                    current.Total10100600302000 += (Decimal)current.cta_10100600302010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000;
                current.Total10100600300000 = 0;
                if (current.cta_10100600301000 != null && current.cta_10100600301000.Total10100600301000 != 0)
                    current.Total10100600300000 += (Decimal)current.cta_10100600301000.Total10100600301000;
                if (current.cta_10100600302000 != null && current.cta_10100600302000.Total10100600302000 != 0)
                    current.Total10100600300000 += (Decimal)current.cta_10100600302000.Total10100600302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000.cta_10100600401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000.cta_10100600401000;
                current.Total10100600401000 = 0;
                if (current.cta_10100600401010 != null)
                    current.Total10100600401000 += (Decimal)current.cta_10100600401010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000.cta_10100600402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000.cta_10100600402000;
                current.Total10100600402000 = 0;
                if (current.cta_10100600402010 != null)
                    current.Total10100600402000 += (Decimal)current.cta_10100600402010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000;
                current.Total10100600400000 = 0;
                if (current.cta_10100600401000 != null && current.cta_10100600401000.Total10100600401000 != 0)
                    current.Total10100600400000 += (Decimal)current.cta_10100600401000.Total10100600401000;
                if (current.cta_10100600402000 != null && current.cta_10100600402000.Total10100600402000 != 0)
                    current.Total10100600400000 += (Decimal)current.cta_10100600402000.Total10100600402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000.cta_10100600501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000.cta_10100600501000;
                current.Total10100600501000 = 0;
                if (current.cta_10100600501010 != null)
                    current.Total10100600501000 += (Decimal)current.cta_10100600501010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000.cta_10100600502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000.cta_10100600502000;
                current.Total10100600502000 = 0;
                if (current.cta_10100600502010 != null)
                    current.Total10100600502000 += (Decimal)current.cta_10100600502010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000;
                current.Total10100600500000 = 0;
                if (current.cta_10100600501000 != null && current.cta_10100600501000.Total10100600501000 != 0)
                    current.Total10100600500000 += (Decimal)current.cta_10100600501000.Total10100600501000;
                if (current.cta_10100600502000 != null && current.cta_10100600502000.Total10100600502000 != 0)
                    current.Total10100600500000 += (Decimal)current.cta_10100600502000.Total10100600502000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000.cta_10100600601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000.cta_10100600601000;
                current.Total10100600601000 = 0;
                if (current.cta_10100600601010 != null)
                    current.Total10100600601000 += (Decimal)current.cta_10100600601010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000.cta_10100600602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000.cta_10100600602000;
                current.Total10100600602000 = 0;
                if (current.cta_10100600602010 != null)
                    current.Total10100600602000 += (Decimal)current.cta_10100600602010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000;
                current.Total10100600600000 = 0;
                if (current.cta_10100600601000 != null && current.cta_10100600601000.Total10100600601000 != 0)
                    current.Total10100600600000 += (Decimal)current.cta_10100600601000.Total10100600601000;
                if (current.cta_10100600602000 != null && current.cta_10100600602000.Total10100600602000 != 0)
                    current.Total10100600600000 += (Decimal)current.cta_10100600602000.Total10100600602000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000.cta_10100600701000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000.cta_10100600701000;
                current.Total10100600701000 = 0;
                if (current.cta_10100600701010 != null)
                    current.Total10100600701000 += (Decimal)current.cta_10100600701010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000.cta_10100600702000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000.cta_10100600702000;
                current.Total10100600702000 = 0;
                if (current.cta_10100600702010 != null)
                    current.Total10100600702000 += (Decimal)current.cta_10100600702010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000;
                current.Total10100600700000 = 0;
                if (current.cta_10100600701000 != null && current.cta_10100600701000.Total10100600701000 != 0)
                    current.Total10100600700000 += (Decimal)current.cta_10100600701000.Total10100600701000;
                if (current.cta_10100600702000 != null && current.cta_10100600702000.Total10100600702000 != 0)
                    current.Total10100600700000 += (Decimal)current.cta_10100600702000.Total10100600702000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000.cta_10100600901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000.cta_10100600901000;
                current.Total10100600901000 = 0;
                if (current.cta_10100600901010 != null)
                    current.Total10100600901000 += (Decimal)current.cta_10100600901010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000.cta_10100600902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000.cta_10100600902000;
                current.Total10100600902000 = 0;
                if (current.cta_10100600902010 != null)
                    current.Total10100600902000 += (Decimal)current.cta_10100600902010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000;
                current.Total10100600900000 = 0;
                if (current.cta_10100600901000 != null && current.cta_10100600901000.Total10100600901000 != 0)
                    current.Total10100600900000 += (Decimal)current.cta_10100600901000.Total10100600901000;
                if (current.cta_10100600902000 != null && current.cta_10100600902000.Total10100600902000 != 0)
                    current.Total10100600900000 += (Decimal)current.cta_10100600902000.Total10100600902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000.cta_10100601001000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000.cta_10100601001000;
                current.Total10100601001000 = 0;
                if (current.cta_10100601001010 != null)
                    current.Total10100601001000 += (Decimal)current.cta_10100601001010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000.cta_10100601002000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000.cta_10100601002000;
                current.Total10100601002000 = 0;
                if (current.cta_10100601002010 != null)
                    current.Total10100601002000 += (Decimal)current.cta_10100601002010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000;
                current.Total10100601000000 = 0;
                if (current.cta_10100601001000 != null && current.cta_10100601001000.Total10100601001000 != 0)
                    current.Total10100601000000 += (Decimal)current.cta_10100601001000.Total10100601001000;
                if (current.cta_10100601002000 != null && current.cta_10100601002000.Total10100601002000 != 0)
                    current.Total10100601000000 += (Decimal)current.cta_10100601002000.Total10100601002000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000.cta_10100609901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000.cta_10100609901000;
                current.Total10100609901000 = 0;
                if (current.cta_10100609901990 != null)
                    current.Total10100609901000 += (Decimal)current.cta_10100609901990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000.cta_10100609902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000.cta_10100609902000;
                current.Total10100609902000 = 0;
                if (current.cta_10100609902990 != null)
                    current.Total10100609902000 += (Decimal)current.cta_10100609902990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000;
                current.Total10100609900000 = 0;
                if (current.cta_10100609901000 != null && current.cta_10100609901000.Total10100609901000 != 0)
                    current.Total10100609900000 += (Decimal)current.cta_10100609901000.Total10100609901000;
                if (current.cta_10100609902000 != null && current.cta_10100609902000.Total10100609902000 != 0)
                    current.Total10100609900000 += (Decimal)current.cta_10100609902000.Total10100609902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000;
                current.Total10100600000000 = 0;
                if (current.cta_10100600100000 != null && current.cta_10100600100000.Total10100600100000 != 0)
                    current.Total10100600000000 += (Decimal)current.cta_10100600100000.Total10100600100000;
                if (current.cta_10100600200000 != null && current.cta_10100600200000.Total10100600200000 != 0)
                    current.Total10100600000000 += (Decimal)current.cta_10100600200000.Total10100600200000;
                if (current.cta_10100600300000 != null && current.cta_10100600300000.Total10100600300000 != 0)
                    current.Total10100600000000 += (Decimal)current.cta_10100600300000.Total10100600300000;
                if (current.cta_10100600400000 != null && current.cta_10100600400000.Total10100600400000 != 0)
                    current.Total10100600000000 += (Decimal)current.cta_10100600400000.Total10100600400000;
                if (current.cta_10100600500000 != null && current.cta_10100600500000.Total10100600500000 != 0)
                    current.Total10100600000000 += (Decimal)current.cta_10100600500000.Total10100600500000;
                if (current.cta_10100600600000 != null && current.cta_10100600600000.Total10100600600000 != 0)
                    current.Total10100600000000 += (Decimal)current.cta_10100600600000.Total10100600600000;
                if (current.cta_10100600700000 != null && current.cta_10100600700000.Total10100600700000 != 0)
                    current.Total10100600000000 += (Decimal)current.cta_10100600700000.Total10100600700000;
                if (current.cta_10100600900000 != null && current.cta_10100600900000.Total10100600900000 != 0)
                    current.Total10100600000000 += (Decimal)current.cta_10100600900000.Total10100600900000;
                if (current.cta_10100601000000 != null && current.cta_10100601000000.Total10100601000000 != 0)
                    current.Total10100600000000 += (Decimal)current.cta_10100601000000.Total10100601000000;
                if (current.cta_10100609900000 != null && current.cta_10100609900000.Total10100609900000 != 0)
                    current.Total10100600000000 += (Decimal)current.cta_10100609900000.Total10100609900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800100000;
                current.Total10100800100000 = 0;
                if (current.cta_10100800101000 != null)
                    current.Total10100800100000 += (Decimal)current.cta_10100800101000;
                if (current.cta_10100800102000 != null)
                    current.Total10100800100000 += (Decimal)current.cta_10100800102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000;
                current.Total10100800801000 = 0;
                if (current.cta_10100800801020 != null)
                    current.Total10100800801000 += (Decimal)current.cta_10100800801020;
                if (current.cta_10100800801030 != null)
                    current.Total10100800801000 += (Decimal)current.cta_10100800801030;
                if (current.cta_10100800801040 != null)
                    current.Total10100800801000 += (Decimal)current.cta_10100800801040;
                if (current.cta_10100800801070 != null)
                    current.Total10100800801000 += (Decimal)current.cta_10100800801070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000;
                current.Total10100800802000 = 0;
                if (current.cta_10100800802020 != null)
                    current.Total10100800802000 += (Decimal)current.cta_10100800802020;
                if (current.cta_10100800802030 != null)
                    current.Total10100800802000 += (Decimal)current.cta_10100800802030;
                if (current.cta_10100800802040 != null)
                    current.Total10100800802000 += (Decimal)current.cta_10100800802040;
                if (current.cta_10100800802070 != null)
                    current.Total10100800802000 += (Decimal)current.cta_10100800802070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000;
                current.Total10100800800000 = 0;
                if (current.cta_10100800801000 != null && current.cta_10100800801000.Total10100800801000 != 0)
                    current.Total10100800800000 += (Decimal)current.cta_10100800801000.Total10100800801000;
                if (current.cta_10100800802000 != null && current.cta_10100800802000.Total10100800802000 != 0)
                    current.Total10100800800000 += (Decimal)current.cta_10100800802000.Total10100800802000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null && modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000;
                current.Total10100800000000 = 0;
                if (current.cta_10100800100000 != null && current.cta_10100800100000.Total10100800100000 != 0)
                    current.Total10100800000000 += (Decimal)current.cta_10100800100000.Total10100800100000;
                if (current.cta_10100800800000 != null && current.cta_10100800800000.Total10100800800000 != 0)
                    current.Total10100800000000 += (Decimal)current.cta_10100800800000.Total10100800800000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10100000000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10100000000000;
                current.Total10100000000000 = 0;
                if (current.cta_10100100000000 != null && current.cta_10100100000000.Total10100100000000 != 0)
                    current.Total10100000000000 += (Decimal)current.cta_10100100000000.Total10100100000000;
                if (current.cta_10100200000000 != null && current.cta_10100200000000.Total10100200000000 != 0)
                    current.Total10100000000000 += (Decimal)current.cta_10100200000000.Total10100200000000;
                if (current.cta_10100300000000 != null && current.cta_10100300000000.Total10100300000000 != 0)
                    current.Total10100000000000 += (Decimal)current.cta_10100300000000.Total10100300000000;
                if (current.cta_10100400000000 != null && current.cta_10100400000000.Total10100400000000 != 0)
                    current.Total10100000000000 += (Decimal)current.cta_10100400000000.Total10100400000000;
                if (current.cta_10100500000000 != null && current.cta_10100500000000.Total10100500000000 != 0)
                    current.Total10100000000000 += (Decimal)current.cta_10100500000000.Total10100500000000;
                if (current.cta_10100600000000 != null && current.cta_10100600000000.Total10100600000000 != 0)
                    current.Total10100000000000 += (Decimal)current.cta_10100600000000.Total10100600000000;
                if (current.cta_10100800000000 != null && current.cta_10100800000000.Total10100800000000 != 0)
                    current.Total10100000000000 += (Decimal)current.cta_10100800000000.Total10100800000000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100100000.cta_10200100101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100100000.cta_10200100101000;
                current.Total10200100101000 = 0;
                if (current.cta_10200100101010 != null)
                    current.Total10200100101000 += (Decimal)current.cta_10200100101010;
                if (current.cta_10200100101020 != null)
                    current.Total10200100101000 += (Decimal)current.cta_10200100101020;
                if (current.cta_10200100101030 != null)
                    current.Total10200100101000 += (Decimal)current.cta_10200100101030;
                if (current.cta_10200100101040 != null)
                    current.Total10200100101000 += (Decimal)current.cta_10200100101040;
                if (current.cta_10200100101050 != null)
                    current.Total10200100101000 += (Decimal)current.cta_10200100101050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100100000.cta_10200100102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100100000.cta_10200100102000;
                current.Total10200100102000 = 0;
                if (current.cta_10200100102010 != null)
                    current.Total10200100102000 += (Decimal)current.cta_10200100102010;
                if (current.cta_10200100102020 != null)
                    current.Total10200100102000 += (Decimal)current.cta_10200100102020;
                if (current.cta_10200100102030 != null)
                    current.Total10200100102000 += (Decimal)current.cta_10200100102030;
                if (current.cta_10200100102040 != null)
                    current.Total10200100102000 += (Decimal)current.cta_10200100102040;
                if (current.cta_10200100102050 != null)
                    current.Total10200100102000 += (Decimal)current.cta_10200100102050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100100000.cta_10200100103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100100000.cta_10200100103000;
                current.Total10200100103000 = 0;
                if (current.cta_10200100103010 != null)
                    current.Total10200100103000 += (Decimal)current.cta_10200100103010;
                if (current.cta_10200100103020 != null)
                    current.Total10200100103000 += (Decimal)current.cta_10200100103020;
                if (current.cta_10200100103030 != null)
                    current.Total10200100103000 += (Decimal)current.cta_10200100103030;
                if (current.cta_10200100103040 != null)
                    current.Total10200100103000 += (Decimal)current.cta_10200100103040;
                if (current.cta_10200100103050 != null)
                    current.Total10200100103000 += (Decimal)current.cta_10200100103050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100100000;
                current.Total10200100100000 = 0;
                if (current.cta_10200100101000 != null && current.cta_10200100101000.Total10200100101000 != 0)
                    current.Total10200100100000 += (Decimal)current.cta_10200100101000.Total10200100101000;
                if (current.cta_10200100102000 != null && current.cta_10200100102000.Total10200100102000 != 0)
                    current.Total10200100100000 += (Decimal)current.cta_10200100102000.Total10200100102000;
                if (current.cta_10200100103000 != null && current.cta_10200100103000.Total10200100103000 != 0)
                    current.Total10200100100000 += (Decimal)current.cta_10200100103000.Total10200100103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100200000.cta_10200100201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100200000.cta_10200100201000;
                current.Total10200100201000 = 0;
                if (current.cta_10200100201010 != null)
                    current.Total10200100201000 += (Decimal)current.cta_10200100201010;
                if (current.cta_10200100201020 != null)
                    current.Total10200100201000 += (Decimal)current.cta_10200100201020;
                if (current.cta_10200100201030 != null)
                    current.Total10200100201000 += (Decimal)current.cta_10200100201030;
                if (current.cta_10200100201040 != null)
                    current.Total10200100201000 += (Decimal)current.cta_10200100201040;
                if (current.cta_10200100201050 != null)
                    current.Total10200100201000 += (Decimal)current.cta_10200100201050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100200000.cta_10200100202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100200000.cta_10200100202000;
                current.Total10200100202000 = 0;
                if (current.cta_10200100202010 != null)
                    current.Total10200100202000 += (Decimal)current.cta_10200100202010;
                if (current.cta_10200100202020 != null)
                    current.Total10200100202000 += (Decimal)current.cta_10200100202020;
                if (current.cta_10200100202030 != null)
                    current.Total10200100202000 += (Decimal)current.cta_10200100202030;
                if (current.cta_10200100202040 != null)
                    current.Total10200100202000 += (Decimal)current.cta_10200100202040;
                if (current.cta_10200100202050 != null)
                    current.Total10200100202000 += (Decimal)current.cta_10200100202050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100200000.cta_10200100203000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100200000.cta_10200100203000;
                current.Total10200100203000 = 0;
                if (current.cta_10200100203010 != null)
                    current.Total10200100203000 += (Decimal)current.cta_10200100203010;
                if (current.cta_10200100203020 != null)
                    current.Total10200100203000 += (Decimal)current.cta_10200100203020;
                if (current.cta_10200100203030 != null)
                    current.Total10200100203000 += (Decimal)current.cta_10200100203030;
                if (current.cta_10200100203040 != null)
                    current.Total10200100203000 += (Decimal)current.cta_10200100203040;
                if (current.cta_10200100203050 != null)
                    current.Total10200100203000 += (Decimal)current.cta_10200100203050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100200000;
                current.Total10200100200000 = 0;
                if (current.cta_10200100201000 != null && current.cta_10200100201000.Total10200100201000 != 0)
                    current.Total10200100200000 += (Decimal)current.cta_10200100201000.Total10200100201000;
                if (current.cta_10200100202000 != null && current.cta_10200100202000.Total10200100202000 != 0)
                    current.Total10200100200000 += (Decimal)current.cta_10200100202000.Total10200100202000;
                if (current.cta_10200100203000 != null && current.cta_10200100203000.Total10200100203000 != 0)
                    current.Total10200100200000 += (Decimal)current.cta_10200100203000.Total10200100203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100300000.cta_10200100301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100300000.cta_10200100301000;
                current.Total10200100301000 = 0;
                if (current.cta_10200100301010 != null)
                    current.Total10200100301000 += (Decimal)current.cta_10200100301010;
                if (current.cta_10200100301020 != null)
                    current.Total10200100301000 += (Decimal)current.cta_10200100301020;
                if (current.cta_10200100301030 != null)
                    current.Total10200100301000 += (Decimal)current.cta_10200100301030;
                if (current.cta_10200100301040 != null)
                    current.Total10200100301000 += (Decimal)current.cta_10200100301040;
                if (current.cta_10200100301050 != null)
                    current.Total10200100301000 += (Decimal)current.cta_10200100301050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100300000.cta_10200100302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100300000.cta_10200100302000;
                current.Total10200100302000 = 0;
                if (current.cta_10200100302010 != null)
                    current.Total10200100302000 += (Decimal)current.cta_10200100302010;
                if (current.cta_10200100302020 != null)
                    current.Total10200100302000 += (Decimal)current.cta_10200100302020;
                if (current.cta_10200100302030 != null)
                    current.Total10200100302000 += (Decimal)current.cta_10200100302030;
                if (current.cta_10200100302040 != null)
                    current.Total10200100302000 += (Decimal)current.cta_10200100302040;
                if (current.cta_10200100302050 != null)
                    current.Total10200100302000 += (Decimal)current.cta_10200100302050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100300000.cta_10200100303000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100300000.cta_10200100303000;
                current.Total10200100303000 = 0;
                if (current.cta_10200100303010 != null)
                    current.Total10200100303000 += (Decimal)current.cta_10200100303010;
                if (current.cta_10200100303020 != null)
                    current.Total10200100303000 += (Decimal)current.cta_10200100303020;
                if (current.cta_10200100303030 != null)
                    current.Total10200100303000 += (Decimal)current.cta_10200100303030;
                if (current.cta_10200100303040 != null)
                    current.Total10200100303000 += (Decimal)current.cta_10200100303040;
                if (current.cta_10200100303050 != null)
                    current.Total10200100303000 += (Decimal)current.cta_10200100303050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100300000;
                current.Total10200100300000 = 0;
                if (current.cta_10200100301000 != null && current.cta_10200100301000.Total10200100301000 != 0)
                    current.Total10200100300000 += (Decimal)current.cta_10200100301000.Total10200100301000;
                if (current.cta_10200100302000 != null && current.cta_10200100302000.Total10200100302000 != 0)
                    current.Total10200100300000 += (Decimal)current.cta_10200100302000.Total10200100302000;
                if (current.cta_10200100303000 != null && current.cta_10200100303000.Total10200100303000 != 0)
                    current.Total10200100300000 += (Decimal)current.cta_10200100303000.Total10200100303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100400000.cta_10200100401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100400000.cta_10200100401000;
                current.Total10200100401000 = 0;
                if (current.cta_10200100401010 != null)
                    current.Total10200100401000 += (Decimal)current.cta_10200100401010;
                if (current.cta_10200100401020 != null)
                    current.Total10200100401000 += (Decimal)current.cta_10200100401020;
                if (current.cta_10200100401030 != null)
                    current.Total10200100401000 += (Decimal)current.cta_10200100401030;
                if (current.cta_10200100401040 != null)
                    current.Total10200100401000 += (Decimal)current.cta_10200100401040;
                if (current.cta_10200100401050 != null)
                    current.Total10200100401000 += (Decimal)current.cta_10200100401050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100400000.cta_10200100402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100400000.cta_10200100402000;
                current.Total10200100402000 = 0;
                if (current.cta_10200100402010 != null)
                    current.Total10200100402000 += (Decimal)current.cta_10200100402010;
                if (current.cta_10200100402020 != null)
                    current.Total10200100402000 += (Decimal)current.cta_10200100402020;
                if (current.cta_10200100402030 != null)
                    current.Total10200100402000 += (Decimal)current.cta_10200100402030;
                if (current.cta_10200100402040 != null)
                    current.Total10200100402000 += (Decimal)current.cta_10200100402040;
                if (current.cta_10200100402050 != null)
                    current.Total10200100402000 += (Decimal)current.cta_10200100402050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100400000.cta_10200100403000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100400000.cta_10200100403000;
                current.Total10200100403000 = 0;
                if (current.cta_10200100403010 != null)
                    current.Total10200100403000 += (Decimal)current.cta_10200100403010;
                if (current.cta_10200100403020 != null)
                    current.Total10200100403000 += (Decimal)current.cta_10200100403020;
                if (current.cta_10200100403030 != null)
                    current.Total10200100403000 += (Decimal)current.cta_10200100403030;
                if (current.cta_10200100403040 != null)
                    current.Total10200100403000 += (Decimal)current.cta_10200100403040;
                if (current.cta_10200100403050 != null)
                    current.Total10200100403000 += (Decimal)current.cta_10200100403050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100400000;
                current.Total10200100400000 = 0;
                if (current.cta_10200100401000 != null && current.cta_10200100401000.Total10200100401000 != 0)
                    current.Total10200100400000 += (Decimal)current.cta_10200100401000.Total10200100401000;
                if (current.cta_10200100402000 != null && current.cta_10200100402000.Total10200100402000 != 0)
                    current.Total10200100400000 += (Decimal)current.cta_10200100402000.Total10200100402000;
                if (current.cta_10200100403000 != null && current.cta_10200100403000.Total10200100403000 != 0)
                    current.Total10200100400000 += (Decimal)current.cta_10200100403000.Total10200100403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100500000.cta_10200100501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100500000.cta_10200100501000;
                current.Total10200100501000 = 0;
                if (current.cta_10200100501010 != null)
                    current.Total10200100501000 += (Decimal)current.cta_10200100501010;
                if (current.cta_10200100501020 != null)
                    current.Total10200100501000 += (Decimal)current.cta_10200100501020;
                if (current.cta_10200100501030 != null)
                    current.Total10200100501000 += (Decimal)current.cta_10200100501030;
                if (current.cta_10200100501040 != null)
                    current.Total10200100501000 += (Decimal)current.cta_10200100501040;
                if (current.cta_10200100501050 != null)
                    current.Total10200100501000 += (Decimal)current.cta_10200100501050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100500000.cta_10200100502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100500000.cta_10200100502000;
                current.Total10200100502000 = 0;
                if (current.cta_10200100502010 != null)
                    current.Total10200100502000 += (Decimal)current.cta_10200100502010;
                if (current.cta_10200100502020 != null)
                    current.Total10200100502000 += (Decimal)current.cta_10200100502020;
                if (current.cta_10200100502030 != null)
                    current.Total10200100502000 += (Decimal)current.cta_10200100502030;
                if (current.cta_10200100502040 != null)
                    current.Total10200100502000 += (Decimal)current.cta_10200100502040;
                if (current.cta_10200100502050 != null)
                    current.Total10200100502000 += (Decimal)current.cta_10200100502050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100500000.cta_10200100503000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100500000.cta_10200100503000;
                current.Total10200100503000 = 0;
                if (current.cta_10200100503010 != null)
                    current.Total10200100503000 += (Decimal)current.cta_10200100503010;
                if (current.cta_10200100503020 != null)
                    current.Total10200100503000 += (Decimal)current.cta_10200100503020;
                if (current.cta_10200100503030 != null)
                    current.Total10200100503000 += (Decimal)current.cta_10200100503030;
                if (current.cta_10200100503040 != null)
                    current.Total10200100503000 += (Decimal)current.cta_10200100503040;
                if (current.cta_10200100503050 != null)
                    current.Total10200100503000 += (Decimal)current.cta_10200100503050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100500000;
                current.Total10200100500000 = 0;
                if (current.cta_10200100501000 != null && current.cta_10200100501000.Total10200100501000 != 0)
                    current.Total10200100500000 += (Decimal)current.cta_10200100501000.Total10200100501000;
                if (current.cta_10200100502000 != null && current.cta_10200100502000.Total10200100502000 != 0)
                    current.Total10200100500000 += (Decimal)current.cta_10200100502000.Total10200100502000;
                if (current.cta_10200100503000 != null && current.cta_10200100503000.Total10200100503000 != 0)
                    current.Total10200100500000 += (Decimal)current.cta_10200100503000.Total10200100503000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100600000.cta_10200100601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100600000.cta_10200100601000;
                current.Total10200100601000 = 0;
                if (current.cta_10200100601010 != null)
                    current.Total10200100601000 += (Decimal)current.cta_10200100601010;
                if (current.cta_10200100601020 != null)
                    current.Total10200100601000 += (Decimal)current.cta_10200100601020;
                if (current.cta_10200100601030 != null)
                    current.Total10200100601000 += (Decimal)current.cta_10200100601030;
                if (current.cta_10200100601040 != null)
                    current.Total10200100601000 += (Decimal)current.cta_10200100601040;
                if (current.cta_10200100601050 != null)
                    current.Total10200100601000 += (Decimal)current.cta_10200100601050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100600000.cta_10200100602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100600000.cta_10200100602000;
                current.Total10200100602000 = 0;
                if (current.cta_10200100602010 != null)
                    current.Total10200100602000 += (Decimal)current.cta_10200100602010;
                if (current.cta_10200100602020 != null)
                    current.Total10200100602000 += (Decimal)current.cta_10200100602020;
                if (current.cta_10200100602030 != null)
                    current.Total10200100602000 += (Decimal)current.cta_10200100602030;
                if (current.cta_10200100602040 != null)
                    current.Total10200100602000 += (Decimal)current.cta_10200100602040;
                if (current.cta_10200100602050 != null)
                    current.Total10200100602000 += (Decimal)current.cta_10200100602050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100600000.cta_10200100603000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100600000.cta_10200100603000;
                current.Total10200100603000 = 0;
                if (current.cta_10200100603010 != null)
                    current.Total10200100603000 += (Decimal)current.cta_10200100603010;
                if (current.cta_10200100603020 != null)
                    current.Total10200100603000 += (Decimal)current.cta_10200100603020;
                if (current.cta_10200100603030 != null)
                    current.Total10200100603000 += (Decimal)current.cta_10200100603030;
                if (current.cta_10200100603040 != null)
                    current.Total10200100603000 += (Decimal)current.cta_10200100603040;
                if (current.cta_10200100603050 != null)
                    current.Total10200100603000 += (Decimal)current.cta_10200100603050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100600000;
                current.Total10200100600000 = 0;
                if (current.cta_10200100601000 != null && current.cta_10200100601000.Total10200100601000 != 0)
                    current.Total10200100600000 += (Decimal)current.cta_10200100601000.Total10200100601000;
                if (current.cta_10200100602000 != null && current.cta_10200100602000.Total10200100602000 != 0)
                    current.Total10200100600000 += (Decimal)current.cta_10200100602000.Total10200100602000;
                if (current.cta_10200100603000 != null && current.cta_10200100603000.Total10200100603000 != 0)
                    current.Total10200100600000 += (Decimal)current.cta_10200100603000.Total10200100603000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100700000.cta_10200100701000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100700000.cta_10200100701000;
                current.Total10200100701000 = 0;
                if (current.cta_10200100701010 != null)
                    current.Total10200100701000 += (Decimal)current.cta_10200100701010;
                if (current.cta_10200100701020 != null)
                    current.Total10200100701000 += (Decimal)current.cta_10200100701020;
                if (current.cta_10200100701030 != null)
                    current.Total10200100701000 += (Decimal)current.cta_10200100701030;
                if (current.cta_10200100701040 != null)
                    current.Total10200100701000 += (Decimal)current.cta_10200100701040;
                if (current.cta_10200100701050 != null)
                    current.Total10200100701000 += (Decimal)current.cta_10200100701050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100700000.cta_10200100702000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100700000.cta_10200100702000;
                current.Total10200100702000 = 0;
                if (current.cta_10200100702010 != null)
                    current.Total10200100702000 += (Decimal)current.cta_10200100702010;
                if (current.cta_10200100702020 != null)
                    current.Total10200100702000 += (Decimal)current.cta_10200100702020;
                if (current.cta_10200100702030 != null)
                    current.Total10200100702000 += (Decimal)current.cta_10200100702030;
                if (current.cta_10200100702040 != null)
                    current.Total10200100702000 += (Decimal)current.cta_10200100702040;
                if (current.cta_10200100702050 != null)
                    current.Total10200100702000 += (Decimal)current.cta_10200100702050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100700000.cta_10200100703000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100700000.cta_10200100703000;
                current.Total10200100703000 = 0;
                if (current.cta_10200100703010 != null)
                    current.Total10200100703000 += (Decimal)current.cta_10200100703010;
                if (current.cta_10200100703020 != null)
                    current.Total10200100703000 += (Decimal)current.cta_10200100703020;
                if (current.cta_10200100703030 != null)
                    current.Total10200100703000 += (Decimal)current.cta_10200100703030;
                if (current.cta_10200100703040 != null)
                    current.Total10200100703000 += (Decimal)current.cta_10200100703040;
                if (current.cta_10200100703050 != null)
                    current.Total10200100703000 += (Decimal)current.cta_10200100703050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100700000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100700000;
                current.Total10200100700000 = 0;
                if (current.cta_10200100701000 != null && current.cta_10200100701000.Total10200100701000 != 0)
                    current.Total10200100700000 += (Decimal)current.cta_10200100701000.Total10200100701000;
                if (current.cta_10200100702000 != null && current.cta_10200100702000.Total10200100702000 != 0)
                    current.Total10200100700000 += (Decimal)current.cta_10200100702000.Total10200100702000;
                if (current.cta_10200100703000 != null && current.cta_10200100703000.Total10200100703000 != 0)
                    current.Total10200100700000 += (Decimal)current.cta_10200100703000.Total10200100703000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100800000.cta_10200100801000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100800000.cta_10200100801000;
                current.Total10200100801000 = 0;
                if (current.cta_10200100801010 != null)
                    current.Total10200100801000 += (Decimal)current.cta_10200100801010;
                if (current.cta_10200100801020 != null)
                    current.Total10200100801000 += (Decimal)current.cta_10200100801020;
                if (current.cta_10200100801030 != null)
                    current.Total10200100801000 += (Decimal)current.cta_10200100801030;
                if (current.cta_10200100801040 != null)
                    current.Total10200100801000 += (Decimal)current.cta_10200100801040;
                if (current.cta_10200100801050 != null)
                    current.Total10200100801000 += (Decimal)current.cta_10200100801050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100800000.cta_10200100802000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100800000.cta_10200100802000;
                current.Total10200100802000 = 0;
                if (current.cta_10200100802010 != null)
                    current.Total10200100802000 += (Decimal)current.cta_10200100802010;
                if (current.cta_10200100802020 != null)
                    current.Total10200100802000 += (Decimal)current.cta_10200100802020;
                if (current.cta_10200100802030 != null)
                    current.Total10200100802000 += (Decimal)current.cta_10200100802030;
                if (current.cta_10200100802040 != null)
                    current.Total10200100802000 += (Decimal)current.cta_10200100802040;
                if (current.cta_10200100802050 != null)
                    current.Total10200100802000 += (Decimal)current.cta_10200100802050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100800000.cta_10200100803000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100800000.cta_10200100803000;
                current.Total10200100803000 = 0;
                if (current.cta_10200100803010 != null)
                    current.Total10200100803000 += (Decimal)current.cta_10200100803010;
                if (current.cta_10200100803020 != null)
                    current.Total10200100803000 += (Decimal)current.cta_10200100803020;
                if (current.cta_10200100803030 != null)
                    current.Total10200100803000 += (Decimal)current.cta_10200100803030;
                if (current.cta_10200100803040 != null)
                    current.Total10200100803000 += (Decimal)current.cta_10200100803040;
                if (current.cta_10200100803050 != null)
                    current.Total10200100803000 += (Decimal)current.cta_10200100803050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100800000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100800000;
                current.Total10200100800000 = 0;
                if (current.cta_10200100801000 != null && current.cta_10200100801000.Total10200100801000 != 0)
                    current.Total10200100800000 += (Decimal)current.cta_10200100801000.Total10200100801000;
                if (current.cta_10200100802000 != null && current.cta_10200100802000.Total10200100802000 != 0)
                    current.Total10200100800000 += (Decimal)current.cta_10200100802000.Total10200100802000;
                if (current.cta_10200100803000 != null && current.cta_10200100803000.Total10200100803000 != 0)
                    current.Total10200100800000 += (Decimal)current.cta_10200100803000.Total10200100803000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100900000.cta_10200100901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100900000.cta_10200100901000;
                current.Total10200100901000 = 0;
                if (current.cta_10200100901010 != null)
                    current.Total10200100901000 += (Decimal)current.cta_10200100901010;
                if (current.cta_10200100901020 != null)
                    current.Total10200100901000 += (Decimal)current.cta_10200100901020;
                if (current.cta_10200100901030 != null)
                    current.Total10200100901000 += (Decimal)current.cta_10200100901030;
                if (current.cta_10200100901040 != null)
                    current.Total10200100901000 += (Decimal)current.cta_10200100901040;
                if (current.cta_10200100901050 != null)
                    current.Total10200100901000 += (Decimal)current.cta_10200100901050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100900000.cta_10200100902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100900000.cta_10200100902000;
                current.Total10200100902000 = 0;
                if (current.cta_10200100902010 != null)
                    current.Total10200100902000 += (Decimal)current.cta_10200100902010;
                if (current.cta_10200100902020 != null)
                    current.Total10200100902000 += (Decimal)current.cta_10200100902020;
                if (current.cta_10200100902030 != null)
                    current.Total10200100902000 += (Decimal)current.cta_10200100902030;
                if (current.cta_10200100902040 != null)
                    current.Total10200100902000 += (Decimal)current.cta_10200100902040;
                if (current.cta_10200100902050 != null)
                    current.Total10200100902000 += (Decimal)current.cta_10200100902050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100900000.cta_10200100903000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100900000.cta_10200100903000;
                current.Total10200100903000 = 0;
                if (current.cta_10200100903010 != null)
                    current.Total10200100903000 += (Decimal)current.cta_10200100903010;
                if (current.cta_10200100903020 != null)
                    current.Total10200100903000 += (Decimal)current.cta_10200100903020;
                if (current.cta_10200100903030 != null)
                    current.Total10200100903000 += (Decimal)current.cta_10200100903030;
                if (current.cta_10200100903040 != null)
                    current.Total10200100903000 += (Decimal)current.cta_10200100903040;
                if (current.cta_10200100903050 != null)
                    current.Total10200100903000 += (Decimal)current.cta_10200100903050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200100900000;
                current.Total10200100900000 = 0;
                if (current.cta_10200100901000 != null && current.cta_10200100901000.Total10200100901000 != 0)
                    current.Total10200100900000 += (Decimal)current.cta_10200100901000.Total10200100901000;
                if (current.cta_10200100902000 != null && current.cta_10200100902000.Total10200100902000 != 0)
                    current.Total10200100900000 += (Decimal)current.cta_10200100902000.Total10200100902000;
                if (current.cta_10200100903000 != null && current.cta_10200100903000.Total10200100903000 != 0)
                    current.Total10200100900000 += (Decimal)current.cta_10200100903000.Total10200100903000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101000000.cta_10200101001000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101000000.cta_10200101001000;
                current.Total10200101001000 = 0;
                if (current.cta_10200101001010 != null)
                    current.Total10200101001000 += (Decimal)current.cta_10200101001010;
                if (current.cta_10200101001020 != null)
                    current.Total10200101001000 += (Decimal)current.cta_10200101001020;
                if (current.cta_10200101001030 != null)
                    current.Total10200101001000 += (Decimal)current.cta_10200101001030;
                if (current.cta_10200101001040 != null)
                    current.Total10200101001000 += (Decimal)current.cta_10200101001040;
                if (current.cta_10200101001050 != null)
                    current.Total10200101001000 += (Decimal)current.cta_10200101001050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101000000.cta_10200101002000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101000000.cta_10200101002000;
                current.Total10200101002000 = 0;
                if (current.cta_10200101002010 != null)
                    current.Total10200101002000 += (Decimal)current.cta_10200101002010;
                if (current.cta_10200101002020 != null)
                    current.Total10200101002000 += (Decimal)current.cta_10200101002020;
                if (current.cta_10200101002030 != null)
                    current.Total10200101002000 += (Decimal)current.cta_10200101002030;
                if (current.cta_10200101002040 != null)
                    current.Total10200101002000 += (Decimal)current.cta_10200101002040;
                if (current.cta_10200101002050 != null)
                    current.Total10200101002000 += (Decimal)current.cta_10200101002050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101000000.cta_10200101003000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101000000.cta_10200101003000;
                current.Total10200101003000 = 0;
                if (current.cta_10200101003010 != null)
                    current.Total10200101003000 += (Decimal)current.cta_10200101003010;
                if (current.cta_10200101003020 != null)
                    current.Total10200101003000 += (Decimal)current.cta_10200101003020;
                if (current.cta_10200101003030 != null)
                    current.Total10200101003000 += (Decimal)current.cta_10200101003030;
                if (current.cta_10200101003040 != null)
                    current.Total10200101003000 += (Decimal)current.cta_10200101003040;
                if (current.cta_10200101003050 != null)
                    current.Total10200101003000 += (Decimal)current.cta_10200101003050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101000000;
                current.Total10200101000000 = 0;
                if (current.cta_10200101001000 != null && current.cta_10200101001000.Total10200101001000 != 0)
                    current.Total10200101000000 += (Decimal)current.cta_10200101001000.Total10200101001000;
                if (current.cta_10200101002000 != null && current.cta_10200101002000.Total10200101002000 != 0)
                    current.Total10200101000000 += (Decimal)current.cta_10200101002000.Total10200101002000;
                if (current.cta_10200101003000 != null && current.cta_10200101003000.Total10200101003000 != 0)
                    current.Total10200101000000 += (Decimal)current.cta_10200101003000.Total10200101003000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101100000.cta_10200101101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101100000.cta_10200101101000;
                current.Total10200101101000 = 0;
                if (current.cta_10200101101010 != null)
                    current.Total10200101101000 += (Decimal)current.cta_10200101101010;
                if (current.cta_10200101101020 != null)
                    current.Total10200101101000 += (Decimal)current.cta_10200101101020;
                if (current.cta_10200101101030 != null)
                    current.Total10200101101000 += (Decimal)current.cta_10200101101030;
                if (current.cta_10200101101040 != null)
                    current.Total10200101101000 += (Decimal)current.cta_10200101101040;
                if (current.cta_10200101101050 != null)
                    current.Total10200101101000 += (Decimal)current.cta_10200101101050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101100000.cta_10200101102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101100000.cta_10200101102000;
                current.Total10200101102000 = 0;
                if (current.cta_10200101102010 != null)
                    current.Total10200101102000 += (Decimal)current.cta_10200101102010;
                if (current.cta_10200101102020 != null)
                    current.Total10200101102000 += (Decimal)current.cta_10200101102020;
                if (current.cta_10200101102030 != null)
                    current.Total10200101102000 += (Decimal)current.cta_10200101102030;
                if (current.cta_10200101102040 != null)
                    current.Total10200101102000 += (Decimal)current.cta_10200101102040;
                if (current.cta_10200101102050 != null)
                    current.Total10200101102000 += (Decimal)current.cta_10200101102050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101100000.cta_10200101103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101100000.cta_10200101103000;
                current.Total10200101103000 = 0;
                if (current.cta_10200101103010 != null)
                    current.Total10200101103000 += (Decimal)current.cta_10200101103010;
                if (current.cta_10200101103020 != null)
                    current.Total10200101103000 += (Decimal)current.cta_10200101103020;
                if (current.cta_10200101103030 != null)
                    current.Total10200101103000 += (Decimal)current.cta_10200101103030;
                if (current.cta_10200101103040 != null)
                    current.Total10200101103000 += (Decimal)current.cta_10200101103040;
                if (current.cta_10200101103050 != null)
                    current.Total10200101103000 += (Decimal)current.cta_10200101103050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200101100000;
                current.Total10200101100000 = 0;
                if (current.cta_10200101101000 != null && current.cta_10200101101000.Total10200101101000 != 0)
                    current.Total10200101100000 += (Decimal)current.cta_10200101101000.Total10200101101000;
                if (current.cta_10200101102000 != null && current.cta_10200101102000.Total10200101102000 != 0)
                    current.Total10200101100000 += (Decimal)current.cta_10200101102000.Total10200101102000;
                if (current.cta_10200101103000 != null && current.cta_10200101103000.Total10200101103000 != 0)
                    current.Total10200101100000 += (Decimal)current.cta_10200101103000.Total10200101103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200109900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200109900000.cta_10200109901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200109900000.cta_10200109901000;
                current.Total10200109901000 = 0;
                if (current.cta_10200109901010 != null)
                    current.Total10200109901000 += (Decimal)current.cta_10200109901010;
                if (current.cta_10200109901020 != null)
                    current.Total10200109901000 += (Decimal)current.cta_10200109901020;
                if (current.cta_10200109901990 != null)
                    current.Total10200109901000 += (Decimal)current.cta_10200109901990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200109900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200109900000.cta_10200109902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200109900000.cta_10200109902000;
                current.Total10200109902000 = 0;
                if (current.cta_10200109902010 != null)
                    current.Total10200109902000 += (Decimal)current.cta_10200109902010;
                if (current.cta_10200109902020 != null)
                    current.Total10200109902000 += (Decimal)current.cta_10200109902020;
                if (current.cta_10200109902990 != null)
                    current.Total10200109902000 += (Decimal)current.cta_10200109902990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200109900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200109900000.cta_10200109903000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200109900000.cta_10200109903000;
                current.Total10200109903000 = 0;
                if (current.cta_10200109903990 != null)
                    current.Total10200109903000 += (Decimal)current.cta_10200109903990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200109900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000.cta_10200109900000;
                current.Total10200109900000 = 0;
                if (current.cta_10200109901000 != null && current.cta_10200109901000.Total10200109901000 != 0)
                    current.Total10200109900000 += (Decimal)current.cta_10200109901000.Total10200109901000;
                if (current.cta_10200109902000 != null && current.cta_10200109902000.Total10200109902000 != 0)
                    current.Total10200109900000 += (Decimal)current.cta_10200109902000.Total10200109902000;
                if (current.cta_10200109903000 != null && current.cta_10200109903000.Total10200109903000 != 0)
                    current.Total10200109900000 += (Decimal)current.cta_10200109903000.Total10200109903000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200100000000;
                current.Total10200100000000 = 0;
                if (current.cta_10200100100000 != null && current.cta_10200100100000.Total10200100100000 != 0)
                    current.Total10200100000000 += (Decimal)current.cta_10200100100000.Total10200100100000;
                if (current.cta_10200100200000 != null && current.cta_10200100200000.Total10200100200000 != 0)
                    current.Total10200100000000 += (Decimal)current.cta_10200100200000.Total10200100200000;
                if (current.cta_10200100300000 != null && current.cta_10200100300000.Total10200100300000 != 0)
                    current.Total10200100000000 += (Decimal)current.cta_10200100300000.Total10200100300000;
                if (current.cta_10200100400000 != null && current.cta_10200100400000.Total10200100400000 != 0)
                    current.Total10200100000000 += (Decimal)current.cta_10200100400000.Total10200100400000;
                if (current.cta_10200100500000 != null && current.cta_10200100500000.Total10200100500000 != 0)
                    current.Total10200100000000 += (Decimal)current.cta_10200100500000.Total10200100500000;
                if (current.cta_10200100600000 != null && current.cta_10200100600000.Total10200100600000 != 0)
                    current.Total10200100000000 += (Decimal)current.cta_10200100600000.Total10200100600000;
                if (current.cta_10200100700000 != null && current.cta_10200100700000.Total10200100700000 != 0)
                    current.Total10200100000000 += (Decimal)current.cta_10200100700000.Total10200100700000;
                if (current.cta_10200100800000 != null && current.cta_10200100800000.Total10200100800000 != 0)
                    current.Total10200100000000 += (Decimal)current.cta_10200100800000.Total10200100800000;
                if (current.cta_10200100900000 != null && current.cta_10200100900000.Total10200100900000 != 0)
                    current.Total10200100000000 += (Decimal)current.cta_10200100900000.Total10200100900000;
                if (current.cta_10200101000000 != null && current.cta_10200101000000.Total10200101000000 != 0)
                    current.Total10200100000000 += (Decimal)current.cta_10200101000000.Total10200101000000;
                if (current.cta_10200101100000 != null && current.cta_10200101100000.Total10200101100000 != 0)
                    current.Total10200100000000 += (Decimal)current.cta_10200101100000.Total10200101100000;
                if (current.cta_10200109900000 != null && current.cta_10200109900000.Total10200109900000 != 0)
                    current.Total10200100000000 += (Decimal)current.cta_10200109900000.Total10200109900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200100000.cta_10200200101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200100000.cta_10200200101000;
                current.Total10200200101000 = 0;
                if (current.cta_10200200101010 != null)
                    current.Total10200200101000 += (Decimal)current.cta_10200200101010;
                if (current.cta_10200200101020 != null)
                    current.Total10200200101000 += (Decimal)current.cta_10200200101020;
                if (current.cta_10200200101030 != null)
                    current.Total10200200101000 += (Decimal)current.cta_10200200101030;
                if (current.cta_10200200101040 != null)
                    current.Total10200200101000 += (Decimal)current.cta_10200200101040;
                if (current.cta_10200200101050 != null)
                    current.Total10200200101000 += (Decimal)current.cta_10200200101050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200100000.cta_10200200102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200100000.cta_10200200102000;
                current.Total10200200102000 = 0;
                if (current.cta_10200200102010 != null)
                    current.Total10200200102000 += (Decimal)current.cta_10200200102010;
                if (current.cta_10200200102020 != null)
                    current.Total10200200102000 += (Decimal)current.cta_10200200102020;
                if (current.cta_10200200102030 != null)
                    current.Total10200200102000 += (Decimal)current.cta_10200200102030;
                if (current.cta_10200200102040 != null)
                    current.Total10200200102000 += (Decimal)current.cta_10200200102040;
                if (current.cta_10200200102050 != null)
                    current.Total10200200102000 += (Decimal)current.cta_10200200102050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200100000.cta_10200200103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200100000.cta_10200200103000;
                current.Total10200200103000 = 0;
                if (current.cta_10200200103010 != null)
                    current.Total10200200103000 += (Decimal)current.cta_10200200103010;
                if (current.cta_10200200103020 != null)
                    current.Total10200200103000 += (Decimal)current.cta_10200200103020;
                if (current.cta_10200200103030 != null)
                    current.Total10200200103000 += (Decimal)current.cta_10200200103030;
                if (current.cta_10200200103040 != null)
                    current.Total10200200103000 += (Decimal)current.cta_10200200103040;
                if (current.cta_10200200103050 != null)
                    current.Total10200200103000 += (Decimal)current.cta_10200200103050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200100000;
                current.Total10200200100000 = 0;
                if (current.cta_10200200101000 != null && current.cta_10200200101000.Total10200200101000 != 0)
                    current.Total10200200100000 += (Decimal)current.cta_10200200101000.Total10200200101000;
                if (current.cta_10200200102000 != null && current.cta_10200200102000.Total10200200102000 != 0)
                    current.Total10200200100000 += (Decimal)current.cta_10200200102000.Total10200200102000;
                if (current.cta_10200200103000 != null && current.cta_10200200103000.Total10200200103000 != 0)
                    current.Total10200200100000 += (Decimal)current.cta_10200200103000.Total10200200103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200200000.cta_10200200201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200200000.cta_10200200201000;
                current.Total10200200201000 = 0;
                if (current.cta_10200200201010 != null)
                    current.Total10200200201000 += (Decimal)current.cta_10200200201010;
                if (current.cta_10200200201020 != null)
                    current.Total10200200201000 += (Decimal)current.cta_10200200201020;
                if (current.cta_10200200201030 != null)
                    current.Total10200200201000 += (Decimal)current.cta_10200200201030;
                if (current.cta_10200200201040 != null)
                    current.Total10200200201000 += (Decimal)current.cta_10200200201040;
                if (current.cta_10200200201050 != null)
                    current.Total10200200201000 += (Decimal)current.cta_10200200201050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200200000.cta_10200200202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200200000.cta_10200200202000;
                current.Total10200200202000 = 0;
                if (current.cta_10200200202010 != null)
                    current.Total10200200202000 += (Decimal)current.cta_10200200202010;
                if (current.cta_10200200202020 != null)
                    current.Total10200200202000 += (Decimal)current.cta_10200200202020;
                if (current.cta_10200200202030 != null)
                    current.Total10200200202000 += (Decimal)current.cta_10200200202030;
                if (current.cta_10200200202040 != null)
                    current.Total10200200202000 += (Decimal)current.cta_10200200202040;
                if (current.cta_10200200202050 != null)
                    current.Total10200200202000 += (Decimal)current.cta_10200200202050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200200000.cta_10200200203000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200200000.cta_10200200203000;
                current.Total10200200203000 = 0;
                if (current.cta_10200200203010 != null)
                    current.Total10200200203000 += (Decimal)current.cta_10200200203010;
                if (current.cta_10200200203020 != null)
                    current.Total10200200203000 += (Decimal)current.cta_10200200203020;
                if (current.cta_10200200203030 != null)
                    current.Total10200200203000 += (Decimal)current.cta_10200200203030;
                if (current.cta_10200200203040 != null)
                    current.Total10200200203000 += (Decimal)current.cta_10200200203040;
                if (current.cta_10200200203050 != null)
                    current.Total10200200203000 += (Decimal)current.cta_10200200203050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200200000;
                current.Total10200200200000 = 0;
                if (current.cta_10200200201000 != null && current.cta_10200200201000.Total10200200201000 != 0)
                    current.Total10200200200000 += (Decimal)current.cta_10200200201000.Total10200200201000;
                if (current.cta_10200200202000 != null && current.cta_10200200202000.Total10200200202000 != 0)
                    current.Total10200200200000 += (Decimal)current.cta_10200200202000.Total10200200202000;
                if (current.cta_10200200203000 != null && current.cta_10200200203000.Total10200200203000 != 0)
                    current.Total10200200200000 += (Decimal)current.cta_10200200203000.Total10200200203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200300000.cta_10200200301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200300000.cta_10200200301000;
                current.Total10200200301000 = 0;
                if (current.cta_10200200301010 != null)
                    current.Total10200200301000 += (Decimal)current.cta_10200200301010;
                if (current.cta_10200200301020 != null)
                    current.Total10200200301000 += (Decimal)current.cta_10200200301020;
                if (current.cta_10200200301030 != null)
                    current.Total10200200301000 += (Decimal)current.cta_10200200301030;
                if (current.cta_10200200301040 != null)
                    current.Total10200200301000 += (Decimal)current.cta_10200200301040;
                if (current.cta_10200200301050 != null)
                    current.Total10200200301000 += (Decimal)current.cta_10200200301050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200300000.cta_10200200302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200300000.cta_10200200302000;
                current.Total10200200302000 = 0;
                if (current.cta_10200200302010 != null)
                    current.Total10200200302000 += (Decimal)current.cta_10200200302010;
                if (current.cta_10200200302020 != null)
                    current.Total10200200302000 += (Decimal)current.cta_10200200302020;
                if (current.cta_10200200302030 != null)
                    current.Total10200200302000 += (Decimal)current.cta_10200200302030;
                if (current.cta_10200200302040 != null)
                    current.Total10200200302000 += (Decimal)current.cta_10200200302040;
                if (current.cta_10200200302050 != null)
                    current.Total10200200302000 += (Decimal)current.cta_10200200302050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200300000.cta_10200200303000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200300000.cta_10200200303000;
                current.Total10200200303000 = 0;
                if (current.cta_10200200303010 != null)
                    current.Total10200200303000 += (Decimal)current.cta_10200200303010;
                if (current.cta_10200200303020 != null)
                    current.Total10200200303000 += (Decimal)current.cta_10200200303020;
                if (current.cta_10200200303030 != null)
                    current.Total10200200303000 += (Decimal)current.cta_10200200303030;
                if (current.cta_10200200303040 != null)
                    current.Total10200200303000 += (Decimal)current.cta_10200200303040;
                if (current.cta_10200200303050 != null)
                    current.Total10200200303000 += (Decimal)current.cta_10200200303050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200300000;
                current.Total10200200300000 = 0;
                if (current.cta_10200200301000 != null && current.cta_10200200301000.Total10200200301000 != 0)
                    current.Total10200200300000 += (Decimal)current.cta_10200200301000.Total10200200301000;
                if (current.cta_10200200302000 != null && current.cta_10200200302000.Total10200200302000 != 0)
                    current.Total10200200300000 += (Decimal)current.cta_10200200302000.Total10200200302000;
                if (current.cta_10200200303000 != null && current.cta_10200200303000.Total10200200303000 != 0)
                    current.Total10200200300000 += (Decimal)current.cta_10200200303000.Total10200200303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200400000.cta_10200200401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200400000.cta_10200200401000;
                current.Total10200200401000 = 0;
                if (current.cta_10200200401010 != null)
                    current.Total10200200401000 += (Decimal)current.cta_10200200401010;
                if (current.cta_10200200401020 != null)
                    current.Total10200200401000 += (Decimal)current.cta_10200200401020;
                if (current.cta_10200200401030 != null)
                    current.Total10200200401000 += (Decimal)current.cta_10200200401030;
                if (current.cta_10200200401040 != null)
                    current.Total10200200401000 += (Decimal)current.cta_10200200401040;
                if (current.cta_10200200401050 != null)
                    current.Total10200200401000 += (Decimal)current.cta_10200200401050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200400000.cta_10200200402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200400000.cta_10200200402000;
                current.Total10200200402000 = 0;
                if (current.cta_10200200402010 != null)
                    current.Total10200200402000 += (Decimal)current.cta_10200200402010;
                if (current.cta_10200200402020 != null)
                    current.Total10200200402000 += (Decimal)current.cta_10200200402020;
                if (current.cta_10200200402030 != null)
                    current.Total10200200402000 += (Decimal)current.cta_10200200402030;
                if (current.cta_10200200402040 != null)
                    current.Total10200200402000 += (Decimal)current.cta_10200200402040;
                if (current.cta_10200200402050 != null)
                    current.Total10200200402000 += (Decimal)current.cta_10200200402050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200400000.cta_10200200403000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200400000.cta_10200200403000;
                current.Total10200200403000 = 0;
                if (current.cta_10200200403010 != null)
                    current.Total10200200403000 += (Decimal)current.cta_10200200403010;
                if (current.cta_10200200403020 != null)
                    current.Total10200200403000 += (Decimal)current.cta_10200200403020;
                if (current.cta_10200200403030 != null)
                    current.Total10200200403000 += (Decimal)current.cta_10200200403030;
                if (current.cta_10200200403040 != null)
                    current.Total10200200403000 += (Decimal)current.cta_10200200403040;
                if (current.cta_10200200403050 != null)
                    current.Total10200200403000 += (Decimal)current.cta_10200200403050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200400000;
                current.Total10200200400000 = 0;
                if (current.cta_10200200401000 != null && current.cta_10200200401000.Total10200200401000 != 0)
                    current.Total10200200400000 += (Decimal)current.cta_10200200401000.Total10200200401000;
                if (current.cta_10200200402000 != null && current.cta_10200200402000.Total10200200402000 != 0)
                    current.Total10200200400000 += (Decimal)current.cta_10200200402000.Total10200200402000;
                if (current.cta_10200200403000 != null && current.cta_10200200403000.Total10200200403000 != 0)
                    current.Total10200200400000 += (Decimal)current.cta_10200200403000.Total10200200403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200500000.cta_10200200501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200500000.cta_10200200501000;
                current.Total10200200501000 = 0;
                if (current.cta_10200200501010 != null)
                    current.Total10200200501000 += (Decimal)current.cta_10200200501010;
                if (current.cta_10200200501020 != null)
                    current.Total10200200501000 += (Decimal)current.cta_10200200501020;
                if (current.cta_10200200501030 != null)
                    current.Total10200200501000 += (Decimal)current.cta_10200200501030;
                if (current.cta_10200200501040 != null)
                    current.Total10200200501000 += (Decimal)current.cta_10200200501040;
                if (current.cta_10200200501050 != null)
                    current.Total10200200501000 += (Decimal)current.cta_10200200501050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200500000.cta_10200200502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200500000.cta_10200200502000;
                current.Total10200200502000 = 0;
                if (current.cta_10200200502010 != null)
                    current.Total10200200502000 += (Decimal)current.cta_10200200502010;
                if (current.cta_10200200502020 != null)
                    current.Total10200200502000 += (Decimal)current.cta_10200200502020;
                if (current.cta_10200200502030 != null)
                    current.Total10200200502000 += (Decimal)current.cta_10200200502030;
                if (current.cta_10200200502040 != null)
                    current.Total10200200502000 += (Decimal)current.cta_10200200502040;
                if (current.cta_10200200502050 != null)
                    current.Total10200200502000 += (Decimal)current.cta_10200200502050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200500000.cta_10200200503000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200500000.cta_10200200503000;
                current.Total10200200503000 = 0;
                if (current.cta_10200200503010 != null)
                    current.Total10200200503000 += (Decimal)current.cta_10200200503010;
                if (current.cta_10200200503020 != null)
                    current.Total10200200503000 += (Decimal)current.cta_10200200503020;
                if (current.cta_10200200503030 != null)
                    current.Total10200200503000 += (Decimal)current.cta_10200200503030;
                if (current.cta_10200200503040 != null)
                    current.Total10200200503000 += (Decimal)current.cta_10200200503040;
                if (current.cta_10200200503050 != null)
                    current.Total10200200503000 += (Decimal)current.cta_10200200503050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200500000;
                current.Total10200200500000 = 0;
                if (current.cta_10200200501000 != null && current.cta_10200200501000.Total10200200501000 != 0)
                    current.Total10200200500000 += (Decimal)current.cta_10200200501000.Total10200200501000;
                if (current.cta_10200200502000 != null && current.cta_10200200502000.Total10200200502000 != 0)
                    current.Total10200200500000 += (Decimal)current.cta_10200200502000.Total10200200502000;
                if (current.cta_10200200503000 != null && current.cta_10200200503000.Total10200200503000 != 0)
                    current.Total10200200500000 += (Decimal)current.cta_10200200503000.Total10200200503000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200600000.cta_10200200601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200600000.cta_10200200601000;
                current.Total10200200601000 = 0;
                if (current.cta_10200200601010 != null)
                    current.Total10200200601000 += (Decimal)current.cta_10200200601010;
                if (current.cta_10200200601020 != null)
                    current.Total10200200601000 += (Decimal)current.cta_10200200601020;
                if (current.cta_10200200601030 != null)
                    current.Total10200200601000 += (Decimal)current.cta_10200200601030;
                if (current.cta_10200200601040 != null)
                    current.Total10200200601000 += (Decimal)current.cta_10200200601040;
                if (current.cta_10200200601060 != null)
                    current.Total10200200601000 += (Decimal)current.cta_10200200601060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200600000.cta_10200200602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200600000.cta_10200200602000;
                current.Total10200200602000 = 0;
                if (current.cta_10200200602010 != null)
                    current.Total10200200602000 += (Decimal)current.cta_10200200602010;
                if (current.cta_10200200602020 != null)
                    current.Total10200200602000 += (Decimal)current.cta_10200200602020;
                if (current.cta_10200200602030 != null)
                    current.Total10200200602000 += (Decimal)current.cta_10200200602030;
                if (current.cta_10200200602040 != null)
                    current.Total10200200602000 += (Decimal)current.cta_10200200602040;
                if (current.cta_10200200602060 != null)
                    current.Total10200200602000 += (Decimal)current.cta_10200200602060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200600000.cta_10200200603000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200600000.cta_10200200603000;
                current.Total10200200603000 = 0;
                if (current.cta_10200200603010 != null)
                    current.Total10200200603000 += (Decimal)current.cta_10200200603010;
                if (current.cta_10200200603020 != null)
                    current.Total10200200603000 += (Decimal)current.cta_10200200603020;
                if (current.cta_10200200603030 != null)
                    current.Total10200200603000 += (Decimal)current.cta_10200200603030;
                if (current.cta_10200200603040 != null)
                    current.Total10200200603000 += (Decimal)current.cta_10200200603040;
                if (current.cta_10200200603060 != null)
                    current.Total10200200603000 += (Decimal)current.cta_10200200603060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200600000;
                current.Total10200200600000 = 0;
                if (current.cta_10200200601000 != null && current.cta_10200200601000.Total10200200601000 != 0)
                    current.Total10200200600000 += (Decimal)current.cta_10200200601000.Total10200200601000;
                if (current.cta_10200200602000 != null && current.cta_10200200602000.Total10200200602000 != 0)
                    current.Total10200200600000 += (Decimal)current.cta_10200200602000.Total10200200602000;
                if (current.cta_10200200603000 != null && current.cta_10200200603000.Total10200200603000 != 0)
                    current.Total10200200600000 += (Decimal)current.cta_10200200603000.Total10200200603000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200700000.cta_10200200701000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200700000.cta_10200200701000;
                current.Total10200200701000 = 0;
                if (current.cta_10200200701010 != null)
                    current.Total10200200701000 += (Decimal)current.cta_10200200701010;
                if (current.cta_10200200701020 != null)
                    current.Total10200200701000 += (Decimal)current.cta_10200200701020;
                if (current.cta_10200200701030 != null)
                    current.Total10200200701000 += (Decimal)current.cta_10200200701030;
                if (current.cta_10200200701040 != null)
                    current.Total10200200701000 += (Decimal)current.cta_10200200701040;
                if (current.cta_10200200701050 != null)
                    current.Total10200200701000 += (Decimal)current.cta_10200200701050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200700000.cta_10200200702000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200700000.cta_10200200702000;
                current.Total10200200702000 = 0;
                if (current.cta_10200200702010 != null)
                    current.Total10200200702000 += (Decimal)current.cta_10200200702010;
                if (current.cta_10200200702020 != null)
                    current.Total10200200702000 += (Decimal)current.cta_10200200702020;
                if (current.cta_10200200702030 != null)
                    current.Total10200200702000 += (Decimal)current.cta_10200200702030;
                if (current.cta_10200200702040 != null)
                    current.Total10200200702000 += (Decimal)current.cta_10200200702040;
                if (current.cta_10200200702050 != null)
                    current.Total10200200702000 += (Decimal)current.cta_10200200702050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200700000.cta_10200200703000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200700000.cta_10200200703000;
                current.Total10200200703000 = 0;
                if (current.cta_10200200703010 != null)
                    current.Total10200200703000 += (Decimal)current.cta_10200200703010;
                if (current.cta_10200200703020 != null)
                    current.Total10200200703000 += (Decimal)current.cta_10200200703020;
                if (current.cta_10200200703030 != null)
                    current.Total10200200703000 += (Decimal)current.cta_10200200703030;
                if (current.cta_10200200703040 != null)
                    current.Total10200200703000 += (Decimal)current.cta_10200200703040;
                if (current.cta_10200200703050 != null)
                    current.Total10200200703000 += (Decimal)current.cta_10200200703050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200700000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200700000;
                current.Total10200200700000 = 0;
                if (current.cta_10200200701000 != null && current.cta_10200200701000.Total10200200701000 != 0)
                    current.Total10200200700000 += (Decimal)current.cta_10200200701000.Total10200200701000;
                if (current.cta_10200200702000 != null && current.cta_10200200702000.Total10200200702000 != 0)
                    current.Total10200200700000 += (Decimal)current.cta_10200200702000.Total10200200702000;
                if (current.cta_10200200703000 != null && current.cta_10200200703000.Total10200200703000 != 0)
                    current.Total10200200700000 += (Decimal)current.cta_10200200703000.Total10200200703000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200800000.cta_10200200801000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200800000.cta_10200200801000;
                current.Total10200200801000 = 0;
                if (current.cta_10200200801010 != null)
                    current.Total10200200801000 += (Decimal)current.cta_10200200801010;
                if (current.cta_10200200801020 != null)
                    current.Total10200200801000 += (Decimal)current.cta_10200200801020;
                if (current.cta_10200200801030 != null)
                    current.Total10200200801000 += (Decimal)current.cta_10200200801030;
                if (current.cta_10200200801040 != null)
                    current.Total10200200801000 += (Decimal)current.cta_10200200801040;
                if (current.cta_10200200801050 != null)
                    current.Total10200200801000 += (Decimal)current.cta_10200200801050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200800000.cta_10200200802000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200800000.cta_10200200802000;
                current.Total10200200802000 = 0;
                if (current.cta_10200200802010 != null)
                    current.Total10200200802000 += (Decimal)current.cta_10200200802010;
                if (current.cta_10200200802020 != null)
                    current.Total10200200802000 += (Decimal)current.cta_10200200802020;
                if (current.cta_10200200802030 != null)
                    current.Total10200200802000 += (Decimal)current.cta_10200200802030;
                if (current.cta_10200200802040 != null)
                    current.Total10200200802000 += (Decimal)current.cta_10200200802040;
                if (current.cta_10200200802050 != null)
                    current.Total10200200802000 += (Decimal)current.cta_10200200802050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200800000.cta_10200200803000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200800000.cta_10200200803000;
                current.Total10200200803000 = 0;
                if (current.cta_10200200803010 != null)
                    current.Total10200200803000 += (Decimal)current.cta_10200200803010;
                if (current.cta_10200200803020 != null)
                    current.Total10200200803000 += (Decimal)current.cta_10200200803020;
                if (current.cta_10200200803030 != null)
                    current.Total10200200803000 += (Decimal)current.cta_10200200803030;
                if (current.cta_10200200803040 != null)
                    current.Total10200200803000 += (Decimal)current.cta_10200200803040;
                if (current.cta_10200200803050 != null)
                    current.Total10200200803000 += (Decimal)current.cta_10200200803050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200800000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200800000;
                current.Total10200200800000 = 0;
                if (current.cta_10200200801000 != null && current.cta_10200200801000.Total10200200801000 != 0)
                    current.Total10200200800000 += (Decimal)current.cta_10200200801000.Total10200200801000;
                if (current.cta_10200200802000 != null && current.cta_10200200802000.Total10200200802000 != 0)
                    current.Total10200200800000 += (Decimal)current.cta_10200200802000.Total10200200802000;
                if (current.cta_10200200803000 != null && current.cta_10200200803000.Total10200200803000 != 0)
                    current.Total10200200800000 += (Decimal)current.cta_10200200803000.Total10200200803000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200900000.cta_10200200901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200900000.cta_10200200901000;
                current.Total10200200901000 = 0;
                if (current.cta_10200200901010 != null)
                    current.Total10200200901000 += (Decimal)current.cta_10200200901010;
                if (current.cta_10200200901020 != null)
                    current.Total10200200901000 += (Decimal)current.cta_10200200901020;
                if (current.cta_10200200901030 != null)
                    current.Total10200200901000 += (Decimal)current.cta_10200200901030;
                if (current.cta_10200200901040 != null)
                    current.Total10200200901000 += (Decimal)current.cta_10200200901040;
                if (current.cta_10200200901050 != null)
                    current.Total10200200901000 += (Decimal)current.cta_10200200901050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200900000.cta_10200200902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200900000.cta_10200200902000;
                current.Total10200200902000 = 0;
                if (current.cta_10200200902010 != null)
                    current.Total10200200902000 += (Decimal)current.cta_10200200902010;
                if (current.cta_10200200902020 != null)
                    current.Total10200200902000 += (Decimal)current.cta_10200200902020;
                if (current.cta_10200200902030 != null)
                    current.Total10200200902000 += (Decimal)current.cta_10200200902030;
                if (current.cta_10200200902040 != null)
                    current.Total10200200902000 += (Decimal)current.cta_10200200902040;
                if (current.cta_10200200902050 != null)
                    current.Total10200200902000 += (Decimal)current.cta_10200200902050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200900000.cta_10200200903000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200900000.cta_10200200903000;
                current.Total10200200903000 = 0;
                if (current.cta_10200200903010 != null)
                    current.Total10200200903000 += (Decimal)current.cta_10200200903010;
                if (current.cta_10200200903020 != null)
                    current.Total10200200903000 += (Decimal)current.cta_10200200903020;
                if (current.cta_10200200903030 != null)
                    current.Total10200200903000 += (Decimal)current.cta_10200200903030;
                if (current.cta_10200200903040 != null)
                    current.Total10200200903000 += (Decimal)current.cta_10200200903040;
                if (current.cta_10200200903050 != null)
                    current.Total10200200903000 += (Decimal)current.cta_10200200903050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200200900000;
                current.Total10200200900000 = 0;
                if (current.cta_10200200901000 != null && current.cta_10200200901000.Total10200200901000 != 0)
                    current.Total10200200900000 += (Decimal)current.cta_10200200901000.Total10200200901000;
                if (current.cta_10200200902000 != null && current.cta_10200200902000.Total10200200902000 != 0)
                    current.Total10200200900000 += (Decimal)current.cta_10200200902000.Total10200200902000;
                if (current.cta_10200200903000 != null && current.cta_10200200903000.Total10200200903000 != 0)
                    current.Total10200200900000 += (Decimal)current.cta_10200200903000.Total10200200903000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201000000.cta_10200201001000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201000000.cta_10200201001000;
                current.Total10200201001000 = 0;
                if (current.cta_10200201001010 != null)
                    current.Total10200201001000 += (Decimal)current.cta_10200201001010;
                if (current.cta_10200201001020 != null)
                    current.Total10200201001000 += (Decimal)current.cta_10200201001020;
                if (current.cta_10200201001030 != null)
                    current.Total10200201001000 += (Decimal)current.cta_10200201001030;
                if (current.cta_10200201001040 != null)
                    current.Total10200201001000 += (Decimal)current.cta_10200201001040;
                if (current.cta_10200201001050 != null)
                    current.Total10200201001000 += (Decimal)current.cta_10200201001050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201000000.cta_10200201002000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201000000.cta_10200201002000;
                current.Total10200201002000 = 0;
                if (current.cta_10200201002010 != null)
                    current.Total10200201002000 += (Decimal)current.cta_10200201002010;
                if (current.cta_10200201002020 != null)
                    current.Total10200201002000 += (Decimal)current.cta_10200201002020;
                if (current.cta_10200201002030 != null)
                    current.Total10200201002000 += (Decimal)current.cta_10200201002030;
                if (current.cta_10200201002040 != null)
                    current.Total10200201002000 += (Decimal)current.cta_10200201002040;
                if (current.cta_10200201002050 != null)
                    current.Total10200201002000 += (Decimal)current.cta_10200201002050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201000000.cta_10200201003000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201000000.cta_10200201003000;
                current.Total10200201003000 = 0;
                if (current.cta_10200201003010 != null)
                    current.Total10200201003000 += (Decimal)current.cta_10200201003010;
                if (current.cta_10200201003020 != null)
                    current.Total10200201003000 += (Decimal)current.cta_10200201003020;
                if (current.cta_10200201003030 != null)
                    current.Total10200201003000 += (Decimal)current.cta_10200201003030;
                if (current.cta_10200201003040 != null)
                    current.Total10200201003000 += (Decimal)current.cta_10200201003040;
                if (current.cta_10200201003050 != null)
                    current.Total10200201003000 += (Decimal)current.cta_10200201003050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201000000;
                current.Total10200201000000 = 0;
                if (current.cta_10200201001000 != null && current.cta_10200201001000.Total10200201001000 != 0)
                    current.Total10200201000000 += (Decimal)current.cta_10200201001000.Total10200201001000;
                if (current.cta_10200201002000 != null && current.cta_10200201002000.Total10200201002000 != 0)
                    current.Total10200201000000 += (Decimal)current.cta_10200201002000.Total10200201002000;
                if (current.cta_10200201003000 != null && current.cta_10200201003000.Total10200201003000 != 0)
                    current.Total10200201000000 += (Decimal)current.cta_10200201003000.Total10200201003000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201100000.cta_10200201101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201100000.cta_10200201101000;
                current.Total10200201101000 = 0;
                if (current.cta_10200201101010 != null)
                    current.Total10200201101000 += (Decimal)current.cta_10200201101010;
                if (current.cta_10200201101020 != null)
                    current.Total10200201101000 += (Decimal)current.cta_10200201101020;
                if (current.cta_10200201101030 != null)
                    current.Total10200201101000 += (Decimal)current.cta_10200201101030;
                if (current.cta_10200201101040 != null)
                    current.Total10200201101000 += (Decimal)current.cta_10200201101040;
                if (current.cta_10200201101060 != null)
                    current.Total10200201101000 += (Decimal)current.cta_10200201101060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201100000.cta_10200201102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201100000.cta_10200201102000;
                current.Total10200201102000 = 0;
                if (current.cta_10200201102010 != null)
                    current.Total10200201102000 += (Decimal)current.cta_10200201102010;
                if (current.cta_10200201102020 != null)
                    current.Total10200201102000 += (Decimal)current.cta_10200201102020;
                if (current.cta_10200201102030 != null)
                    current.Total10200201102000 += (Decimal)current.cta_10200201102030;
                if (current.cta_10200201102040 != null)
                    current.Total10200201102000 += (Decimal)current.cta_10200201102040;
                if (current.cta_10200201102060 != null)
                    current.Total10200201102000 += (Decimal)current.cta_10200201102060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201100000.cta_10200201103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201100000.cta_10200201103000;
                current.Total10200201103000 = 0;
                if (current.cta_10200201103010 != null)
                    current.Total10200201103000 += (Decimal)current.cta_10200201103010;
                if (current.cta_10200201103020 != null)
                    current.Total10200201103000 += (Decimal)current.cta_10200201103020;
                if (current.cta_10200201103030 != null)
                    current.Total10200201103000 += (Decimal)current.cta_10200201103030;
                if (current.cta_10200201103040 != null)
                    current.Total10200201103000 += (Decimal)current.cta_10200201103040;
                if (current.cta_10200201103060 != null)
                    current.Total10200201103000 += (Decimal)current.cta_10200201103060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201100000;
                current.Total10200201100000 = 0;
                if (current.cta_10200201101000 != null && current.cta_10200201101000.Total10200201101000 != 0)
                    current.Total10200201100000 += (Decimal)current.cta_10200201101000.Total10200201101000;
                if (current.cta_10200201102000 != null && current.cta_10200201102000.Total10200201102000 != 0)
                    current.Total10200201100000 += (Decimal)current.cta_10200201102000.Total10200201102000;
                if (current.cta_10200201103000 != null && current.cta_10200201103000.Total10200201103000 != 0)
                    current.Total10200201100000 += (Decimal)current.cta_10200201103000.Total10200201103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201200000.cta_10200201201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201200000.cta_10200201201000;
                current.Total10200201201000 = 0;
                if (current.cta_10200201201010 != null)
                    current.Total10200201201000 += (Decimal)current.cta_10200201201010;
                if (current.cta_10200201201020 != null)
                    current.Total10200201201000 += (Decimal)current.cta_10200201201020;
                if (current.cta_10200201201030 != null)
                    current.Total10200201201000 += (Decimal)current.cta_10200201201030;
                if (current.cta_10200201201040 != null)
                    current.Total10200201201000 += (Decimal)current.cta_10200201201040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201200000.cta_10200201202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201200000.cta_10200201202000;
                current.Total10200201202000 = 0;
                if (current.cta_10200201202010 != null)
                    current.Total10200201202000 += (Decimal)current.cta_10200201202010;
                if (current.cta_10200201202020 != null)
                    current.Total10200201202000 += (Decimal)current.cta_10200201202020;
                if (current.cta_10200201202030 != null)
                    current.Total10200201202000 += (Decimal)current.cta_10200201202030;
                if (current.cta_10200201202040 != null)
                    current.Total10200201202000 += (Decimal)current.cta_10200201202040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201200000.cta_10200201203000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201200000.cta_10200201203000;
                current.Total10200201203000 = 0;
                if (current.cta_10200201203010 != null)
                    current.Total10200201203000 += (Decimal)current.cta_10200201203010;
                if (current.cta_10200201203020 != null)
                    current.Total10200201203000 += (Decimal)current.cta_10200201203020;
                if (current.cta_10200201203030 != null)
                    current.Total10200201203000 += (Decimal)current.cta_10200201203030;
                if (current.cta_10200201203040 != null)
                    current.Total10200201203000 += (Decimal)current.cta_10200201203040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201200000;
                current.Total10200201200000 = 0;
                if (current.cta_10200201201000 != null && current.cta_10200201201000.Total10200201201000 != 0)
                    current.Total10200201200000 += (Decimal)current.cta_10200201201000.Total10200201201000;
                if (current.cta_10200201202000 != null && current.cta_10200201202000.Total10200201202000 != 0)
                    current.Total10200201200000 += (Decimal)current.cta_10200201202000.Total10200201202000;
                if (current.cta_10200201203000 != null && current.cta_10200201203000.Total10200201203000 != 0)
                    current.Total10200201200000 += (Decimal)current.cta_10200201203000.Total10200201203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201300000.cta_10200201301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201300000.cta_10200201301000;
                current.Total10200201301000 = 0;
                if (current.cta_10200201301010 != null)
                    current.Total10200201301000 += (Decimal)current.cta_10200201301010;
                if (current.cta_10200201301020 != null)
                    current.Total10200201301000 += (Decimal)current.cta_10200201301020;
                if (current.cta_10200201301050 != null)
                    current.Total10200201301000 += (Decimal)current.cta_10200201301050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201300000.cta_10200201302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201300000.cta_10200201302000;
                current.Total10200201302000 = 0;
                if (current.cta_10200201302010 != null)
                    current.Total10200201302000 += (Decimal)current.cta_10200201302010;
                if (current.cta_10200201302020 != null)
                    current.Total10200201302000 += (Decimal)current.cta_10200201302020;
                if (current.cta_10200201302050 != null)
                    current.Total10200201302000 += (Decimal)current.cta_10200201302050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201300000.cta_10200201303000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201300000.cta_10200201303000;
                current.Total10200201303000 = 0;
                if (current.cta_10200201303010 != null)
                    current.Total10200201303000 += (Decimal)current.cta_10200201303010;
                if (current.cta_10200201303020 != null)
                    current.Total10200201303000 += (Decimal)current.cta_10200201303020;
                if (current.cta_10200201303050 != null)
                    current.Total10200201303000 += (Decimal)current.cta_10200201303050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201300000;
                current.Total10200201300000 = 0;
                if (current.cta_10200201301000 != null && current.cta_10200201301000.Total10200201301000 != 0)
                    current.Total10200201300000 += (Decimal)current.cta_10200201301000.Total10200201301000;
                if (current.cta_10200201302000 != null && current.cta_10200201302000.Total10200201302000 != 0)
                    current.Total10200201300000 += (Decimal)current.cta_10200201302000.Total10200201302000;
                if (current.cta_10200201303000 != null && current.cta_10200201303000.Total10200201303000 != 0)
                    current.Total10200201300000 += (Decimal)current.cta_10200201303000.Total10200201303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201400000.cta_10200201401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201400000.cta_10200201401000;
                current.Total10200201401000 = 0;
                if (current.cta_10200201401010 != null)
                    current.Total10200201401000 += (Decimal)current.cta_10200201401010;
                if (current.cta_10200201401080 != null)
                    current.Total10200201401000 += (Decimal)current.cta_10200201401080;
                if (current.cta_10200201401090 != null)
                    current.Total10200201401000 += (Decimal)current.cta_10200201401090;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201400000.cta_10200201402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201400000.cta_10200201402000;
                current.Total10200201402000 = 0;
                if (current.cta_10200201402010 != null)
                    current.Total10200201402000 += (Decimal)current.cta_10200201402010;
                if (current.cta_10200201402080 != null)
                    current.Total10200201402000 += (Decimal)current.cta_10200201402080;
                if (current.cta_10200201402090 != null)
                    current.Total10200201402000 += (Decimal)current.cta_10200201402090;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201400000.cta_10200201403000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201400000.cta_10200201403000;
                current.Total10200201403000 = 0;
                if (current.cta_10200201403010 != null)
                    current.Total10200201403000 += (Decimal)current.cta_10200201403010;
                if (current.cta_10200201403080 != null)
                    current.Total10200201403000 += (Decimal)current.cta_10200201403080;
                if (current.cta_10200201403090 != null)
                    current.Total10200201403000 += (Decimal)current.cta_10200201403090;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201400000;
                current.Total10200201400000 = 0;
                if (current.cta_10200201401000 != null && current.cta_10200201401000.Total10200201401000 != 0)
                    current.Total10200201400000 += (Decimal)current.cta_10200201401000.Total10200201401000;
                if (current.cta_10200201402000 != null && current.cta_10200201402000.Total10200201402000 != 0)
                    current.Total10200201400000 += (Decimal)current.cta_10200201402000.Total10200201402000;
                if (current.cta_10200201403000 != null && current.cta_10200201403000.Total10200201403000 != 0)
                    current.Total10200201400000 += (Decimal)current.cta_10200201403000.Total10200201403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201500000.cta_10200201501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201500000.cta_10200201501000;
                current.Total10200201501000 = 0;
                if (current.cta_10200201501010 != null)
                    current.Total10200201501000 += (Decimal)current.cta_10200201501010;
                if (current.cta_10200201501020 != null)
                    current.Total10200201501000 += (Decimal)current.cta_10200201501020;
                if (current.cta_10200201501050 != null)
                    current.Total10200201501000 += (Decimal)current.cta_10200201501050;
                if (current.cta_10200201501060 != null)
                    current.Total10200201501000 += (Decimal)current.cta_10200201501060;
                if (current.cta_10200201501990 != null)
                    current.Total10200201501000 += (Decimal)current.cta_10200201501990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201500000.cta_10200201502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201500000.cta_10200201502000;
                current.Total10200201502000 = 0;
                if (current.cta_10200201502010 != null)
                    current.Total10200201502000 += (Decimal)current.cta_10200201502010;
                if (current.cta_10200201502020 != null)
                    current.Total10200201502000 += (Decimal)current.cta_10200201502020;
                if (current.cta_10200201502050 != null)
                    current.Total10200201502000 += (Decimal)current.cta_10200201502050;
                if (current.cta_10200201502060 != null)
                    current.Total10200201502000 += (Decimal)current.cta_10200201502060;
                if (current.cta_10200201502990 != null)
                    current.Total10200201502000 += (Decimal)current.cta_10200201502990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201500000.cta_10200201503000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201500000.cta_10200201503000;
                current.Total10200201503000 = 0;
                if (current.cta_10200201503010 != null)
                    current.Total10200201503000 += (Decimal)current.cta_10200201503010;
                if (current.cta_10200201503020 != null)
                    current.Total10200201503000 += (Decimal)current.cta_10200201503020;
                if (current.cta_10200201503050 != null)
                    current.Total10200201503000 += (Decimal)current.cta_10200201503050;
                if (current.cta_10200201503060 != null)
                    current.Total10200201503000 += (Decimal)current.cta_10200201503060;
                if (current.cta_10200201503990 != null)
                    current.Total10200201503000 += (Decimal)current.cta_10200201503990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201500000;
                current.Total10200201500000 = 0;
                if (current.cta_10200201501000 != null && current.cta_10200201501000.Total10200201501000 != 0)
                    current.Total10200201500000 += (Decimal)current.cta_10200201501000.Total10200201501000;
                if (current.cta_10200201502000 != null && current.cta_10200201502000.Total10200201502000 != 0)
                    current.Total10200201500000 += (Decimal)current.cta_10200201502000.Total10200201502000;
                if (current.cta_10200201503000 != null && current.cta_10200201503000.Total10200201503000 != 0)
                    current.Total10200201500000 += (Decimal)current.cta_10200201503000.Total10200201503000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201600000.cta_10200201601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201600000.cta_10200201601000;
                current.Total10200201601000 = 0;
                if (current.cta_10200201601010 != null)
                    current.Total10200201601000 += (Decimal)current.cta_10200201601010;
                if (current.cta_10200201601040 != null)
                    current.Total10200201601000 += (Decimal)current.cta_10200201601040;
                if (current.cta_10200201601050 != null)
                    current.Total10200201601000 += (Decimal)current.cta_10200201601050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201600000.cta_10200201602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201600000.cta_10200201602000;
                current.Total10200201602000 = 0;
                if (current.cta_10200201602010 != null)
                    current.Total10200201602000 += (Decimal)current.cta_10200201602010;
                if (current.cta_10200201602040 != null)
                    current.Total10200201602000 += (Decimal)current.cta_10200201602040;
                if (current.cta_10200201602050 != null)
                    current.Total10200201602000 += (Decimal)current.cta_10200201602050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201600000.cta_10200201603000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201600000.cta_10200201603000;
                current.Total10200201603000 = 0;
                if (current.cta_10200201603010 != null)
                    current.Total10200201603000 += (Decimal)current.cta_10200201603010;
                if (current.cta_10200201603040 != null)
                    current.Total10200201603000 += (Decimal)current.cta_10200201603040;
                if (current.cta_10200201603050 != null)
                    current.Total10200201603000 += (Decimal)current.cta_10200201603050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200201600000;
                current.Total10200201600000 = 0;
                if (current.cta_10200201601000 != null && current.cta_10200201601000.Total10200201601000 != 0)
                    current.Total10200201600000 += (Decimal)current.cta_10200201601000.Total10200201601000;
                if (current.cta_10200201602000 != null && current.cta_10200201602000.Total10200201602000 != 0)
                    current.Total10200201600000 += (Decimal)current.cta_10200201602000.Total10200201602000;
                if (current.cta_10200201603000 != null && current.cta_10200201603000.Total10200201603000 != 0)
                    current.Total10200201600000 += (Decimal)current.cta_10200201603000.Total10200201603000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205300000.cta_10200205301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205300000.cta_10200205301000;
                current.Total10200205301000 = 0;
                if (current.cta_10200205301010 != null)
                    current.Total10200205301000 += (Decimal)current.cta_10200205301010;
                if (current.cta_10200205301020 != null)
                    current.Total10200205301000 += (Decimal)current.cta_10200205301020;
                if (current.cta_10200205301030 != null)
                    current.Total10200205301000 += (Decimal)current.cta_10200205301030;
                if (current.cta_10200205301040 != null)
                    current.Total10200205301000 += (Decimal)current.cta_10200205301040;
                if (current.cta_10200205301050 != null)
                    current.Total10200205301000 += (Decimal)current.cta_10200205301050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205300000.cta_10200205302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205300000.cta_10200205302000;
                current.Total10200205302000 = 0;
                if (current.cta_10200205302010 != null)
                    current.Total10200205302000 += (Decimal)current.cta_10200205302010;
                if (current.cta_10200205302020 != null)
                    current.Total10200205302000 += (Decimal)current.cta_10200205302020;
                if (current.cta_10200205302030 != null)
                    current.Total10200205302000 += (Decimal)current.cta_10200205302030;
                if (current.cta_10200205302040 != null)
                    current.Total10200205302000 += (Decimal)current.cta_10200205302040;
                if (current.cta_10200205302050 != null)
                    current.Total10200205302000 += (Decimal)current.cta_10200205302050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205300000.cta_10200205303000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205300000.cta_10200205303000;
                current.Total10200205303000 = 0;
                if (current.cta_10200205303010 != null)
                    current.Total10200205303000 += (Decimal)current.cta_10200205303010;
                if (current.cta_10200205303020 != null)
                    current.Total10200205303000 += (Decimal)current.cta_10200205303020;
                if (current.cta_10200205303030 != null)
                    current.Total10200205303000 += (Decimal)current.cta_10200205303030;
                if (current.cta_10200205303040 != null)
                    current.Total10200205303000 += (Decimal)current.cta_10200205303040;
                if (current.cta_10200205303050 != null)
                    current.Total10200205303000 += (Decimal)current.cta_10200205303050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205300000;
                current.Total10200205300000 = 0;
                if (current.cta_10200205301000 != null && current.cta_10200205301000.Total10200205301000 != 0)
                    current.Total10200205300000 += (Decimal)current.cta_10200205301000.Total10200205301000;
                if (current.cta_10200205302000 != null && current.cta_10200205302000.Total10200205302000 != 0)
                    current.Total10200205300000 += (Decimal)current.cta_10200205302000.Total10200205302000;
                if (current.cta_10200205303000 != null && current.cta_10200205303000.Total10200205303000 != 0)
                    current.Total10200205300000 += (Decimal)current.cta_10200205303000.Total10200205303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205900000.cta_10200205901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205900000.cta_10200205901000;
                current.Total10200205901000 = 0;
                if (current.cta_10200205901010 != null)
                    current.Total10200205901000 += (Decimal)current.cta_10200205901010;
                if (current.cta_10200205901020 != null)
                    current.Total10200205901000 += (Decimal)current.cta_10200205901020;
                if (current.cta_10200205901030 != null)
                    current.Total10200205901000 += (Decimal)current.cta_10200205901030;
                if (current.cta_10200205901040 != null)
                    current.Total10200205901000 += (Decimal)current.cta_10200205901040;
                if (current.cta_10200205901050 != null)
                    current.Total10200205901000 += (Decimal)current.cta_10200205901050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205900000.cta_10200205902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205900000.cta_10200205902000;
                current.Total10200205902000 = 0;
                if (current.cta_10200205902010 != null)
                    current.Total10200205902000 += (Decimal)current.cta_10200205902010;
                if (current.cta_10200205902020 != null)
                    current.Total10200205902000 += (Decimal)current.cta_10200205902020;
                if (current.cta_10200205902030 != null)
                    current.Total10200205902000 += (Decimal)current.cta_10200205902030;
                if (current.cta_10200205902040 != null)
                    current.Total10200205902000 += (Decimal)current.cta_10200205902040;
                if (current.cta_10200205902050 != null)
                    current.Total10200205902000 += (Decimal)current.cta_10200205902050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205900000.cta_10200205903000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205900000.cta_10200205903000;
                current.Total10200205903000 = 0;
                if (current.cta_10200205903010 != null)
                    current.Total10200205903000 += (Decimal)current.cta_10200205903010;
                if (current.cta_10200205903020 != null)
                    current.Total10200205903000 += (Decimal)current.cta_10200205903020;
                if (current.cta_10200205903030 != null)
                    current.Total10200205903000 += (Decimal)current.cta_10200205903030;
                if (current.cta_10200205903040 != null)
                    current.Total10200205903000 += (Decimal)current.cta_10200205903040;
                if (current.cta_10200205903050 != null)
                    current.Total10200205903000 += (Decimal)current.cta_10200205903050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200205900000;
                current.Total10200205900000 = 0;
                if (current.cta_10200205901000 != null && current.cta_10200205901000.Total10200205901000 != 0)
                    current.Total10200205900000 += (Decimal)current.cta_10200205901000.Total10200205901000;
                if (current.cta_10200205902000 != null && current.cta_10200205902000.Total10200205902000 != 0)
                    current.Total10200205900000 += (Decimal)current.cta_10200205902000.Total10200205902000;
                if (current.cta_10200205903000 != null && current.cta_10200205903000.Total10200205903000 != 0)
                    current.Total10200205900000 += (Decimal)current.cta_10200205903000.Total10200205903000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206000000.cta_10200206001000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206000000.cta_10200206001000;
                current.Total10200206001000 = 0;
                if (current.cta_10200206001010 != null)
                    current.Total10200206001000 += (Decimal)current.cta_10200206001010;
                if (current.cta_10200206001020 != null)
                    current.Total10200206001000 += (Decimal)current.cta_10200206001020;
                if (current.cta_10200206001030 != null)
                    current.Total10200206001000 += (Decimal)current.cta_10200206001030;
                if (current.cta_10200206001040 != null)
                    current.Total10200206001000 += (Decimal)current.cta_10200206001040;
                if (current.cta_10200206001050 != null)
                    current.Total10200206001000 += (Decimal)current.cta_10200206001050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206000000.cta_10200206002000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206000000.cta_10200206002000;
                current.Total10200206002000 = 0;
                if (current.cta_10200206002010 != null)
                    current.Total10200206002000 += (Decimal)current.cta_10200206002010;
                if (current.cta_10200206002020 != null)
                    current.Total10200206002000 += (Decimal)current.cta_10200206002020;
                if (current.cta_10200206002030 != null)
                    current.Total10200206002000 += (Decimal)current.cta_10200206002030;
                if (current.cta_10200206002040 != null)
                    current.Total10200206002000 += (Decimal)current.cta_10200206002040;
                if (current.cta_10200206002050 != null)
                    current.Total10200206002000 += (Decimal)current.cta_10200206002050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206000000.cta_10200206003000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206000000.cta_10200206003000;
                current.Total10200206003000 = 0;
                if (current.cta_10200206003010 != null)
                    current.Total10200206003000 += (Decimal)current.cta_10200206003010;
                if (current.cta_10200206003020 != null)
                    current.Total10200206003000 += (Decimal)current.cta_10200206003020;
                if (current.cta_10200206003030 != null)
                    current.Total10200206003000 += (Decimal)current.cta_10200206003030;
                if (current.cta_10200206003040 != null)
                    current.Total10200206003000 += (Decimal)current.cta_10200206003040;
                if (current.cta_10200206003050 != null)
                    current.Total10200206003000 += (Decimal)current.cta_10200206003050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206000000;
                current.Total10200206000000 = 0;
                if (current.cta_10200206001000 != null && current.cta_10200206001000.Total10200206001000 != 0)
                    current.Total10200206000000 += (Decimal)current.cta_10200206001000.Total10200206001000;
                if (current.cta_10200206002000 != null && current.cta_10200206002000.Total10200206002000 != 0)
                    current.Total10200206000000 += (Decimal)current.cta_10200206002000.Total10200206002000;
                if (current.cta_10200206003000 != null && current.cta_10200206003000.Total10200206003000 != 0)
                    current.Total10200206000000 += (Decimal)current.cta_10200206003000.Total10200206003000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206100000.cta_10200206101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206100000.cta_10200206101000;
                current.Total10200206101000 = 0;
                if (current.cta_10200206101010 != null)
                    current.Total10200206101000 += (Decimal)current.cta_10200206101010;
                if (current.cta_10200206101020 != null)
                    current.Total10200206101000 += (Decimal)current.cta_10200206101020;
                if (current.cta_10200206101030 != null)
                    current.Total10200206101000 += (Decimal)current.cta_10200206101030;
                if (current.cta_10200206101040 != null)
                    current.Total10200206101000 += (Decimal)current.cta_10200206101040;
                if (current.cta_10200206101050 != null)
                    current.Total10200206101000 += (Decimal)current.cta_10200206101050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206100000.cta_10200206102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206100000.cta_10200206102000;
                current.Total10200206102000 = 0;
                if (current.cta_10200206102010 != null)
                    current.Total10200206102000 += (Decimal)current.cta_10200206102010;
                if (current.cta_10200206102020 != null)
                    current.Total10200206102000 += (Decimal)current.cta_10200206102020;
                if (current.cta_10200206102030 != null)
                    current.Total10200206102000 += (Decimal)current.cta_10200206102030;
                if (current.cta_10200206102040 != null)
                    current.Total10200206102000 += (Decimal)current.cta_10200206102040;
                if (current.cta_10200206102050 != null)
                    current.Total10200206102000 += (Decimal)current.cta_10200206102050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206100000.cta_10200206103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206100000.cta_10200206103000;
                current.Total10200206103000 = 0;
                if (current.cta_10200206103010 != null)
                    current.Total10200206103000 += (Decimal)current.cta_10200206103010;
                if (current.cta_10200206103020 != null)
                    current.Total10200206103000 += (Decimal)current.cta_10200206103020;
                if (current.cta_10200206103030 != null)
                    current.Total10200206103000 += (Decimal)current.cta_10200206103030;
                if (current.cta_10200206103040 != null)
                    current.Total10200206103000 += (Decimal)current.cta_10200206103040;
                if (current.cta_10200206103050 != null)
                    current.Total10200206103000 += (Decimal)current.cta_10200206103050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206100000;
                current.Total10200206100000 = 0;
                if (current.cta_10200206101000 != null && current.cta_10200206101000.Total10200206101000 != 0)
                    current.Total10200206100000 += (Decimal)current.cta_10200206101000.Total10200206101000;
                if (current.cta_10200206102000 != null && current.cta_10200206102000.Total10200206102000 != 0)
                    current.Total10200206100000 += (Decimal)current.cta_10200206102000.Total10200206102000;
                if (current.cta_10200206103000 != null && current.cta_10200206103000.Total10200206103000 != 0)
                    current.Total10200206100000 += (Decimal)current.cta_10200206103000.Total10200206103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206200000.cta_10200206201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206200000.cta_10200206201000;
                current.Total10200206201000 = 0;
                if (current.cta_10200206201010 != null)
                    current.Total10200206201000 += (Decimal)current.cta_10200206201010;
                if (current.cta_10200206201020 != null)
                    current.Total10200206201000 += (Decimal)current.cta_10200206201020;
                if (current.cta_10200206201030 != null)
                    current.Total10200206201000 += (Decimal)current.cta_10200206201030;
                if (current.cta_10200206201040 != null)
                    current.Total10200206201000 += (Decimal)current.cta_10200206201040;
                if (current.cta_10200206201050 != null)
                    current.Total10200206201000 += (Decimal)current.cta_10200206201050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206200000.cta_10200206202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206200000.cta_10200206202000;
                current.Total10200206202000 = 0;
                if (current.cta_10200206202010 != null)
                    current.Total10200206202000 += (Decimal)current.cta_10200206202010;
                if (current.cta_10200206202020 != null)
                    current.Total10200206202000 += (Decimal)current.cta_10200206202020;
                if (current.cta_10200206202030 != null)
                    current.Total10200206202000 += (Decimal)current.cta_10200206202030;
                if (current.cta_10200206202040 != null)
                    current.Total10200206202000 += (Decimal)current.cta_10200206202040;
                if (current.cta_10200206202050 != null)
                    current.Total10200206202000 += (Decimal)current.cta_10200206202050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206200000.cta_10200206203000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206200000.cta_10200206203000;
                current.Total10200206203000 = 0;
                if (current.cta_10200206203010 != null)
                    current.Total10200206203000 += (Decimal)current.cta_10200206203010;
                if (current.cta_10200206203020 != null)
                    current.Total10200206203000 += (Decimal)current.cta_10200206203020;
                if (current.cta_10200206203030 != null)
                    current.Total10200206203000 += (Decimal)current.cta_10200206203030;
                if (current.cta_10200206203040 != null)
                    current.Total10200206203000 += (Decimal)current.cta_10200206203040;
                if (current.cta_10200206203050 != null)
                    current.Total10200206203000 += (Decimal)current.cta_10200206203050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206200000;
                current.Total10200206200000 = 0;
                if (current.cta_10200206201000 != null && current.cta_10200206201000.Total10200206201000 != 0)
                    current.Total10200206200000 += (Decimal)current.cta_10200206201000.Total10200206201000;
                if (current.cta_10200206202000 != null && current.cta_10200206202000.Total10200206202000 != 0)
                    current.Total10200206200000 += (Decimal)current.cta_10200206202000.Total10200206202000;
                if (current.cta_10200206203000 != null && current.cta_10200206203000.Total10200206203000 != 0)
                    current.Total10200206200000 += (Decimal)current.cta_10200206203000.Total10200206203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206300000.cta_10200206301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206300000.cta_10200206301000;
                current.Total10200206301000 = 0;
                if (current.cta_10200206301010 != null)
                    current.Total10200206301000 += (Decimal)current.cta_10200206301010;
                if (current.cta_10200206301020 != null)
                    current.Total10200206301000 += (Decimal)current.cta_10200206301020;
                if (current.cta_10200206301030 != null)
                    current.Total10200206301000 += (Decimal)current.cta_10200206301030;
                if (current.cta_10200206301040 != null)
                    current.Total10200206301000 += (Decimal)current.cta_10200206301040;
                if (current.cta_10200206301050 != null)
                    current.Total10200206301000 += (Decimal)current.cta_10200206301050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206300000.cta_10200206302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206300000.cta_10200206302000;
                current.Total10200206302000 = 0;
                if (current.cta_10200206302010 != null)
                    current.Total10200206302000 += (Decimal)current.cta_10200206302010;
                if (current.cta_10200206302020 != null)
                    current.Total10200206302000 += (Decimal)current.cta_10200206302020;
                if (current.cta_10200206302030 != null)
                    current.Total10200206302000 += (Decimal)current.cta_10200206302030;
                if (current.cta_10200206302040 != null)
                    current.Total10200206302000 += (Decimal)current.cta_10200206302040;
                if (current.cta_10200206302050 != null)
                    current.Total10200206302000 += (Decimal)current.cta_10200206302050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206300000.cta_10200206303000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206300000.cta_10200206303000;
                current.Total10200206303000 = 0;
                if (current.cta_10200206303010 != null)
                    current.Total10200206303000 += (Decimal)current.cta_10200206303010;
                if (current.cta_10200206303020 != null)
                    current.Total10200206303000 += (Decimal)current.cta_10200206303020;
                if (current.cta_10200206303030 != null)
                    current.Total10200206303000 += (Decimal)current.cta_10200206303030;
                if (current.cta_10200206303040 != null)
                    current.Total10200206303000 += (Decimal)current.cta_10200206303040;
                if (current.cta_10200206303050 != null)
                    current.Total10200206303000 += (Decimal)current.cta_10200206303050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206300000;
                current.Total10200206300000 = 0;
                if (current.cta_10200206301000 != null && current.cta_10200206301000.Total10200206301000 != 0)
                    current.Total10200206300000 += (Decimal)current.cta_10200206301000.Total10200206301000;
                if (current.cta_10200206302000 != null && current.cta_10200206302000.Total10200206302000 != 0)
                    current.Total10200206300000 += (Decimal)current.cta_10200206302000.Total10200206302000;
                if (current.cta_10200206303000 != null && current.cta_10200206303000.Total10200206303000 != 0)
                    current.Total10200206300000 += (Decimal)current.cta_10200206303000.Total10200206303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206400000.cta_10200206401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206400000.cta_10200206401000;
                current.Total10200206401000 = 0;
                if (current.cta_10200206401010 != null)
                    current.Total10200206401000 += (Decimal)current.cta_10200206401010;
                if (current.cta_10200206401020 != null)
                    current.Total10200206401000 += (Decimal)current.cta_10200206401020;
                if (current.cta_10200206401030 != null)
                    current.Total10200206401000 += (Decimal)current.cta_10200206401030;
                if (current.cta_10200206401040 != null)
                    current.Total10200206401000 += (Decimal)current.cta_10200206401040;
                if (current.cta_10200206401050 != null)
                    current.Total10200206401000 += (Decimal)current.cta_10200206401050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206400000.cta_10200206402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206400000.cta_10200206402000;
                current.Total10200206402000 = 0;
                if (current.cta_10200206402010 != null)
                    current.Total10200206402000 += (Decimal)current.cta_10200206402010;
                if (current.cta_10200206402020 != null)
                    current.Total10200206402000 += (Decimal)current.cta_10200206402020;
                if (current.cta_10200206402030 != null)
                    current.Total10200206402000 += (Decimal)current.cta_10200206402030;
                if (current.cta_10200206402040 != null)
                    current.Total10200206402000 += (Decimal)current.cta_10200206402040;
                if (current.cta_10200206402050 != null)
                    current.Total10200206402000 += (Decimal)current.cta_10200206402050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206400000.cta_10200206403000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206400000.cta_10200206403000;
                current.Total10200206403000 = 0;
                if (current.cta_10200206403010 != null)
                    current.Total10200206403000 += (Decimal)current.cta_10200206403010;
                if (current.cta_10200206403020 != null)
                    current.Total10200206403000 += (Decimal)current.cta_10200206403020;
                if (current.cta_10200206403030 != null)
                    current.Total10200206403000 += (Decimal)current.cta_10200206403030;
                if (current.cta_10200206403040 != null)
                    current.Total10200206403000 += (Decimal)current.cta_10200206403040;
                if (current.cta_10200206403050 != null)
                    current.Total10200206403000 += (Decimal)current.cta_10200206403050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206400000;
                current.Total10200206400000 = 0;
                if (current.cta_10200206401000 != null && current.cta_10200206401000.Total10200206401000 != 0)
                    current.Total10200206400000 += (Decimal)current.cta_10200206401000.Total10200206401000;
                if (current.cta_10200206402000 != null && current.cta_10200206402000.Total10200206402000 != 0)
                    current.Total10200206400000 += (Decimal)current.cta_10200206402000.Total10200206402000;
                if (current.cta_10200206403000 != null && current.cta_10200206403000.Total10200206403000 != 0)
                    current.Total10200206400000 += (Decimal)current.cta_10200206403000.Total10200206403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206500000.cta_10200206501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206500000.cta_10200206501000;
                current.Total10200206501000 = 0;
                if (current.cta_10200206501010 != null)
                    current.Total10200206501000 += (Decimal)current.cta_10200206501010;
                if (current.cta_10200206501020 != null)
                    current.Total10200206501000 += (Decimal)current.cta_10200206501020;
                if (current.cta_10200206501030 != null)
                    current.Total10200206501000 += (Decimal)current.cta_10200206501030;
                if (current.cta_10200206501040 != null)
                    current.Total10200206501000 += (Decimal)current.cta_10200206501040;
                if (current.cta_10200206501050 != null)
                    current.Total10200206501000 += (Decimal)current.cta_10200206501050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206500000.cta_10200206502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206500000.cta_10200206502000;
                current.Total10200206502000 = 0;
                if (current.cta_10200206502010 != null)
                    current.Total10200206502000 += (Decimal)current.cta_10200206502010;
                if (current.cta_10200206502020 != null)
                    current.Total10200206502000 += (Decimal)current.cta_10200206502020;
                if (current.cta_10200206502030 != null)
                    current.Total10200206502000 += (Decimal)current.cta_10200206502030;
                if (current.cta_10200206502040 != null)
                    current.Total10200206502000 += (Decimal)current.cta_10200206502040;
                if (current.cta_10200206502050 != null)
                    current.Total10200206502000 += (Decimal)current.cta_10200206502050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206500000.cta_10200206503000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206500000.cta_10200206503000;
                current.Total10200206503000 = 0;
                if (current.cta_10200206503010 != null)
                    current.Total10200206503000 += (Decimal)current.cta_10200206503010;
                if (current.cta_10200206503020 != null)
                    current.Total10200206503000 += (Decimal)current.cta_10200206503020;
                if (current.cta_10200206503030 != null)
                    current.Total10200206503000 += (Decimal)current.cta_10200206503030;
                if (current.cta_10200206503040 != null)
                    current.Total10200206503000 += (Decimal)current.cta_10200206503040;
                if (current.cta_10200206503050 != null)
                    current.Total10200206503000 += (Decimal)current.cta_10200206503050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206500000;
                current.Total10200206500000 = 0;
                if (current.cta_10200206501000 != null && current.cta_10200206501000.Total10200206501000 != 0)
                    current.Total10200206500000 += (Decimal)current.cta_10200206501000.Total10200206501000;
                if (current.cta_10200206502000 != null && current.cta_10200206502000.Total10200206502000 != 0)
                    current.Total10200206500000 += (Decimal)current.cta_10200206502000.Total10200206502000;
                if (current.cta_10200206503000 != null && current.cta_10200206503000.Total10200206503000 != 0)
                    current.Total10200206500000 += (Decimal)current.cta_10200206503000.Total10200206503000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206600000.cta_10200206601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206600000.cta_10200206601000;
                current.Total10200206601000 = 0;
                if (current.cta_10200206601010 != null)
                    current.Total10200206601000 += (Decimal)current.cta_10200206601010;
                if (current.cta_10200206601020 != null)
                    current.Total10200206601000 += (Decimal)current.cta_10200206601020;
                if (current.cta_10200206601030 != null)
                    current.Total10200206601000 += (Decimal)current.cta_10200206601030;
                if (current.cta_10200206601040 != null)
                    current.Total10200206601000 += (Decimal)current.cta_10200206601040;
                if (current.cta_10200206601050 != null)
                    current.Total10200206601000 += (Decimal)current.cta_10200206601050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206600000.cta_10200206602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206600000.cta_10200206602000;
                current.Total10200206602000 = 0;
                if (current.cta_10200206602010 != null)
                    current.Total10200206602000 += (Decimal)current.cta_10200206602010;
                if (current.cta_10200206602020 != null)
                    current.Total10200206602000 += (Decimal)current.cta_10200206602020;
                if (current.cta_10200206602030 != null)
                    current.Total10200206602000 += (Decimal)current.cta_10200206602030;
                if (current.cta_10200206602040 != null)
                    current.Total10200206602000 += (Decimal)current.cta_10200206602040;
                if (current.cta_10200206602050 != null)
                    current.Total10200206602000 += (Decimal)current.cta_10200206602050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206600000.cta_10200206603000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206600000.cta_10200206603000;
                current.Total10200206603000 = 0;
                if (current.cta_10200206603010 != null)
                    current.Total10200206603000 += (Decimal)current.cta_10200206603010;
                if (current.cta_10200206603020 != null)
                    current.Total10200206603000 += (Decimal)current.cta_10200206603020;
                if (current.cta_10200206603030 != null)
                    current.Total10200206603000 += (Decimal)current.cta_10200206603030;
                if (current.cta_10200206603040 != null)
                    current.Total10200206603000 += (Decimal)current.cta_10200206603040;
                if (current.cta_10200206603050 != null)
                    current.Total10200206603000 += (Decimal)current.cta_10200206603050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206600000;
                current.Total10200206600000 = 0;
                if (current.cta_10200206601000 != null && current.cta_10200206601000.Total10200206601000 != 0)
                    current.Total10200206600000 += (Decimal)current.cta_10200206601000.Total10200206601000;
                if (current.cta_10200206602000 != null && current.cta_10200206602000.Total10200206602000 != 0)
                    current.Total10200206600000 += (Decimal)current.cta_10200206602000.Total10200206602000;
                if (current.cta_10200206603000 != null && current.cta_10200206603000.Total10200206603000 != 0)
                    current.Total10200206600000 += (Decimal)current.cta_10200206603000.Total10200206603000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206700000.cta_10200206701000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206700000.cta_10200206701000;
                current.Total10200206701000 = 0;
                if (current.cta_10200206701010 != null)
                    current.Total10200206701000 += (Decimal)current.cta_10200206701010;
                if (current.cta_10200206701020 != null)
                    current.Total10200206701000 += (Decimal)current.cta_10200206701020;
                if (current.cta_10200206701030 != null)
                    current.Total10200206701000 += (Decimal)current.cta_10200206701030;
                if (current.cta_10200206701040 != null)
                    current.Total10200206701000 += (Decimal)current.cta_10200206701040;
                if (current.cta_10200206701050 != null)
                    current.Total10200206701000 += (Decimal)current.cta_10200206701050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206700000.cta_10200206702000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206700000.cta_10200206702000;
                current.Total10200206702000 = 0;
                if (current.cta_10200206702010 != null)
                    current.Total10200206702000 += (Decimal)current.cta_10200206702010;
                if (current.cta_10200206702020 != null)
                    current.Total10200206702000 += (Decimal)current.cta_10200206702020;
                if (current.cta_10200206702030 != null)
                    current.Total10200206702000 += (Decimal)current.cta_10200206702030;
                if (current.cta_10200206702040 != null)
                    current.Total10200206702000 += (Decimal)current.cta_10200206702040;
                if (current.cta_10200206702050 != null)
                    current.Total10200206702000 += (Decimal)current.cta_10200206702050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206700000.cta_10200206703000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206700000.cta_10200206703000;
                current.Total10200206703000 = 0;
                if (current.cta_10200206703010 != null)
                    current.Total10200206703000 += (Decimal)current.cta_10200206703010;
                if (current.cta_10200206703020 != null)
                    current.Total10200206703000 += (Decimal)current.cta_10200206703020;
                if (current.cta_10200206703030 != null)
                    current.Total10200206703000 += (Decimal)current.cta_10200206703030;
                if (current.cta_10200206703040 != null)
                    current.Total10200206703000 += (Decimal)current.cta_10200206703040;
                if (current.cta_10200206703050 != null)
                    current.Total10200206703000 += (Decimal)current.cta_10200206703050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206700000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206700000;
                current.Total10200206700000 = 0;
                if (current.cta_10200206701000 != null && current.cta_10200206701000.Total10200206701000 != 0)
                    current.Total10200206700000 += (Decimal)current.cta_10200206701000.Total10200206701000;
                if (current.cta_10200206702000 != null && current.cta_10200206702000.Total10200206702000 != 0)
                    current.Total10200206700000 += (Decimal)current.cta_10200206702000.Total10200206702000;
                if (current.cta_10200206703000 != null && current.cta_10200206703000.Total10200206703000 != 0)
                    current.Total10200206700000 += (Decimal)current.cta_10200206703000.Total10200206703000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206800000.cta_10200206801000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206800000.cta_10200206801000;
                current.Total10200206801000 = 0;
                if (current.cta_10200206801010 != null)
                    current.Total10200206801000 += (Decimal)current.cta_10200206801010;
                if (current.cta_10200206801020 != null)
                    current.Total10200206801000 += (Decimal)current.cta_10200206801020;
                if (current.cta_10200206801030 != null)
                    current.Total10200206801000 += (Decimal)current.cta_10200206801030;
                if (current.cta_10200206801040 != null)
                    current.Total10200206801000 += (Decimal)current.cta_10200206801040;
                if (current.cta_10200206801050 != null)
                    current.Total10200206801000 += (Decimal)current.cta_10200206801050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206800000.cta_10200206802000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206800000.cta_10200206802000;
                current.Total10200206802000 = 0;
                if (current.cta_10200206802010 != null)
                    current.Total10200206802000 += (Decimal)current.cta_10200206802010;
                if (current.cta_10200206802020 != null)
                    current.Total10200206802000 += (Decimal)current.cta_10200206802020;
                if (current.cta_10200206802030 != null)
                    current.Total10200206802000 += (Decimal)current.cta_10200206802030;
                if (current.cta_10200206802040 != null)
                    current.Total10200206802000 += (Decimal)current.cta_10200206802040;
                if (current.cta_10200206802050 != null)
                    current.Total10200206802000 += (Decimal)current.cta_10200206802050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206800000.cta_10200206803000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206800000.cta_10200206803000;
                current.Total10200206803000 = 0;
                if (current.cta_10200206803010 != null)
                    current.Total10200206803000 += (Decimal)current.cta_10200206803010;
                if (current.cta_10200206803020 != null)
                    current.Total10200206803000 += (Decimal)current.cta_10200206803020;
                if (current.cta_10200206803030 != null)
                    current.Total10200206803000 += (Decimal)current.cta_10200206803030;
                if (current.cta_10200206803040 != null)
                    current.Total10200206803000 += (Decimal)current.cta_10200206803040;
                if (current.cta_10200206803050 != null)
                    current.Total10200206803000 += (Decimal)current.cta_10200206803050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206800000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206800000;
                current.Total10200206800000 = 0;
                if (current.cta_10200206801000 != null && current.cta_10200206801000.Total10200206801000 != 0)
                    current.Total10200206800000 += (Decimal)current.cta_10200206801000.Total10200206801000;
                if (current.cta_10200206802000 != null && current.cta_10200206802000.Total10200206802000 != 0)
                    current.Total10200206800000 += (Decimal)current.cta_10200206802000.Total10200206802000;
                if (current.cta_10200206803000 != null && current.cta_10200206803000.Total10200206803000 != 0)
                    current.Total10200206800000 += (Decimal)current.cta_10200206803000.Total10200206803000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206900000.cta_10200206901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206900000.cta_10200206901000;
                current.Total10200206901000 = 0;
                if (current.cta_10200206901010 != null)
                    current.Total10200206901000 += (Decimal)current.cta_10200206901010;
                if (current.cta_10200206901020 != null)
                    current.Total10200206901000 += (Decimal)current.cta_10200206901020;
                if (current.cta_10200206901030 != null)
                    current.Total10200206901000 += (Decimal)current.cta_10200206901030;
                if (current.cta_10200206901040 != null)
                    current.Total10200206901000 += (Decimal)current.cta_10200206901040;
                if (current.cta_10200206901050 != null)
                    current.Total10200206901000 += (Decimal)current.cta_10200206901050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206900000.cta_10200206902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206900000.cta_10200206902000;
                current.Total10200206902000 = 0;
                if (current.cta_10200206902010 != null)
                    current.Total10200206902000 += (Decimal)current.cta_10200206902010;
                if (current.cta_10200206902020 != null)
                    current.Total10200206902000 += (Decimal)current.cta_10200206902020;
                if (current.cta_10200206902030 != null)
                    current.Total10200206902000 += (Decimal)current.cta_10200206902030;
                if (current.cta_10200206902040 != null)
                    current.Total10200206902000 += (Decimal)current.cta_10200206902040;
                if (current.cta_10200206902050 != null)
                    current.Total10200206902000 += (Decimal)current.cta_10200206902050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206900000.cta_10200206903000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206900000.cta_10200206903000;
                current.Total10200206903000 = 0;
                if (current.cta_10200206903010 != null)
                    current.Total10200206903000 += (Decimal)current.cta_10200206903010;
                if (current.cta_10200206903020 != null)
                    current.Total10200206903000 += (Decimal)current.cta_10200206903020;
                if (current.cta_10200206903030 != null)
                    current.Total10200206903000 += (Decimal)current.cta_10200206903030;
                if (current.cta_10200206903040 != null)
                    current.Total10200206903000 += (Decimal)current.cta_10200206903040;
                if (current.cta_10200206903050 != null)
                    current.Total10200206903000 += (Decimal)current.cta_10200206903050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200206900000;
                current.Total10200206900000 = 0;
                if (current.cta_10200206901000 != null && current.cta_10200206901000.Total10200206901000 != 0)
                    current.Total10200206900000 += (Decimal)current.cta_10200206901000.Total10200206901000;
                if (current.cta_10200206902000 != null && current.cta_10200206902000.Total10200206902000 != 0)
                    current.Total10200206900000 += (Decimal)current.cta_10200206902000.Total10200206902000;
                if (current.cta_10200206903000 != null && current.cta_10200206903000.Total10200206903000 != 0)
                    current.Total10200206900000 += (Decimal)current.cta_10200206903000.Total10200206903000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207000000.cta_10200207001000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207000000.cta_10200207001000;
                current.Total10200207001000 = 0;
                if (current.cta_10200207001010 != null)
                    current.Total10200207001000 += (Decimal)current.cta_10200207001010;
                if (current.cta_10200207001020 != null)
                    current.Total10200207001000 += (Decimal)current.cta_10200207001020;
                if (current.cta_10200207001030 != null)
                    current.Total10200207001000 += (Decimal)current.cta_10200207001030;
                if (current.cta_10200207001040 != null)
                    current.Total10200207001000 += (Decimal)current.cta_10200207001040;
                if (current.cta_10200207001050 != null)
                    current.Total10200207001000 += (Decimal)current.cta_10200207001050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207000000.cta_10200207002000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207000000.cta_10200207002000;
                current.Total10200207002000 = 0;
                if (current.cta_10200207002010 != null)
                    current.Total10200207002000 += (Decimal)current.cta_10200207002010;
                if (current.cta_10200207002020 != null)
                    current.Total10200207002000 += (Decimal)current.cta_10200207002020;
                if (current.cta_10200207002030 != null)
                    current.Total10200207002000 += (Decimal)current.cta_10200207002030;
                if (current.cta_10200207002040 != null)
                    current.Total10200207002000 += (Decimal)current.cta_10200207002040;
                if (current.cta_10200207002050 != null)
                    current.Total10200207002000 += (Decimal)current.cta_10200207002050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207000000.cta_10200207003000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207000000.cta_10200207003000;
                current.Total10200207003000 = 0;
                if (current.cta_10200207003010 != null)
                    current.Total10200207003000 += (Decimal)current.cta_10200207003010;
                if (current.cta_10200207003020 != null)
                    current.Total10200207003000 += (Decimal)current.cta_10200207003020;
                if (current.cta_10200207003030 != null)
                    current.Total10200207003000 += (Decimal)current.cta_10200207003030;
                if (current.cta_10200207003040 != null)
                    current.Total10200207003000 += (Decimal)current.cta_10200207003040;
                if (current.cta_10200207003050 != null)
                    current.Total10200207003000 += (Decimal)current.cta_10200207003050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207000000;
                current.Total10200207000000 = 0;
                if (current.cta_10200207001000 != null && current.cta_10200207001000.Total10200207001000 != 0)
                    current.Total10200207000000 += (Decimal)current.cta_10200207001000.Total10200207001000;
                if (current.cta_10200207002000 != null && current.cta_10200207002000.Total10200207002000 != 0)
                    current.Total10200207000000 += (Decimal)current.cta_10200207002000.Total10200207002000;
                if (current.cta_10200207003000 != null && current.cta_10200207003000.Total10200207003000 != 0)
                    current.Total10200207000000 += (Decimal)current.cta_10200207003000.Total10200207003000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207100000.cta_10200207101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207100000.cta_10200207101000;
                current.Total10200207101000 = 0;
                if (current.cta_10200207101010 != null)
                    current.Total10200207101000 += (Decimal)current.cta_10200207101010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207100000.cta_10200207102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207100000.cta_10200207102000;
                current.Total10200207102000 = 0;
                if (current.cta_10200207102010 != null)
                    current.Total10200207102000 += (Decimal)current.cta_10200207102010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207100000.cta_10200207103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207100000.cta_10200207103000;
                current.Total10200207103000 = 0;
                if (current.cta_10200207103010 != null)
                    current.Total10200207103000 += (Decimal)current.cta_10200207103010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207100000;
                current.Total10200207100000 = 0;
                if (current.cta_10200207101000 != null && current.cta_10200207101000.Total10200207101000 != 0)
                    current.Total10200207100000 += (Decimal)current.cta_10200207101000.Total10200207101000;
                if (current.cta_10200207102000 != null && current.cta_10200207102000.Total10200207102000 != 0)
                    current.Total10200207100000 += (Decimal)current.cta_10200207102000.Total10200207102000;
                if (current.cta_10200207103000 != null && current.cta_10200207103000.Total10200207103000 != 0)
                    current.Total10200207100000 += (Decimal)current.cta_10200207103000.Total10200207103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207200000.cta_10200207201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207200000.cta_10200207201000;
                current.Total10200207201000 = 0;
                if (current.cta_10200207201010 != null)
                    current.Total10200207201000 += (Decimal)current.cta_10200207201010;
                if (current.cta_10200207201040 != null)
                    current.Total10200207201000 += (Decimal)current.cta_10200207201040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207200000.cta_10200207202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207200000.cta_10200207202000;
                current.Total10200207202000 = 0;
                if (current.cta_10200207202010 != null)
                    current.Total10200207202000 += (Decimal)current.cta_10200207202010;
                if (current.cta_10200207202040 != null)
                    current.Total10200207202000 += (Decimal)current.cta_10200207202040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207200000.cta_10200207203000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207200000.cta_10200207203000;
                current.Total10200207203000 = 0;
                if (current.cta_10200207203010 != null)
                    current.Total10200207203000 += (Decimal)current.cta_10200207203010;
                if (current.cta_10200207203040 != null)
                    current.Total10200207203000 += (Decimal)current.cta_10200207203040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207200000;
                current.Total10200207200000 = 0;
                if (current.cta_10200207201000 != null && current.cta_10200207201000.Total10200207201000 != 0)
                    current.Total10200207200000 += (Decimal)current.cta_10200207201000.Total10200207201000;
                if (current.cta_10200207202000 != null && current.cta_10200207202000.Total10200207202000 != 0)
                    current.Total10200207200000 += (Decimal)current.cta_10200207202000.Total10200207202000;
                if (current.cta_10200207203000 != null && current.cta_10200207203000.Total10200207203000 != 0)
                    current.Total10200207200000 += (Decimal)current.cta_10200207203000.Total10200207203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207300000.cta_10200207301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207300000.cta_10200207301000;
                current.Total10200207301000 = 0;
                if (current.cta_10200207301010 != null)
                    current.Total10200207301000 += (Decimal)current.cta_10200207301010;
                if (current.cta_10200207301040 != null)
                    current.Total10200207301000 += (Decimal)current.cta_10200207301040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207300000.cta_10200207302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207300000.cta_10200207302000;
                current.Total10200207302000 = 0;
                if (current.cta_10200207302010 != null)
                    current.Total10200207302000 += (Decimal)current.cta_10200207302010;
                if (current.cta_10200207302040 != null)
                    current.Total10200207302000 += (Decimal)current.cta_10200207302040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207300000.cta_10200207303000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207300000.cta_10200207303000;
                current.Total10200207303000 = 0;
                if (current.cta_10200207303010 != null)
                    current.Total10200207303000 += (Decimal)current.cta_10200207303010;
                if (current.cta_10200207303040 != null)
                    current.Total10200207303000 += (Decimal)current.cta_10200207303040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207300000;
                current.Total10200207300000 = 0;
                if (current.cta_10200207301000 != null && current.cta_10200207301000.Total10200207301000 != 0)
                    current.Total10200207300000 += (Decimal)current.cta_10200207301000.Total10200207301000;
                if (current.cta_10200207302000 != null && current.cta_10200207302000.Total10200207302000 != 0)
                    current.Total10200207300000 += (Decimal)current.cta_10200207302000.Total10200207302000;
                if (current.cta_10200207303000 != null && current.cta_10200207303000.Total10200207303000 != 0)
                    current.Total10200207300000 += (Decimal)current.cta_10200207303000.Total10200207303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207400000.cta_10200207401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207400000.cta_10200207401000;
                current.Total10200207401000 = 0;
                if (current.cta_10200207401010 != null)
                    current.Total10200207401000 += (Decimal)current.cta_10200207401010;
                if (current.cta_10200207401040 != null)
                    current.Total10200207401000 += (Decimal)current.cta_10200207401040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207400000.cta_10200207402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207400000.cta_10200207402000;
                current.Total10200207402000 = 0;
                if (current.cta_10200207402010 != null)
                    current.Total10200207402000 += (Decimal)current.cta_10200207402010;
                if (current.cta_10200207402040 != null)
                    current.Total10200207402000 += (Decimal)current.cta_10200207402040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207400000.cta_10200207403000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207400000.cta_10200207403000;
                current.Total10200207403000 = 0;
                if (current.cta_10200207403010 != null)
                    current.Total10200207403000 += (Decimal)current.cta_10200207403010;
                if (current.cta_10200207403040 != null)
                    current.Total10200207403000 += (Decimal)current.cta_10200207403040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207400000;
                current.Total10200207400000 = 0;
                if (current.cta_10200207401000 != null && current.cta_10200207401000.Total10200207401000 != 0)
                    current.Total10200207400000 += (Decimal)current.cta_10200207401000.Total10200207401000;
                if (current.cta_10200207402000 != null && current.cta_10200207402000.Total10200207402000 != 0)
                    current.Total10200207400000 += (Decimal)current.cta_10200207402000.Total10200207402000;
                if (current.cta_10200207403000 != null && current.cta_10200207403000.Total10200207403000 != 0)
                    current.Total10200207400000 += (Decimal)current.cta_10200207403000.Total10200207403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207500000.cta_10200207501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207500000.cta_10200207501000;
                current.Total10200207501000 = 0;
                if (current.cta_10200207501020 != null)
                    current.Total10200207501000 += (Decimal)current.cta_10200207501020;
                if (current.cta_10200207501990 != null)
                    current.Total10200207501000 += (Decimal)current.cta_10200207501990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207500000.cta_10200207502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207500000.cta_10200207502000;
                current.Total10200207502000 = 0;
                if (current.cta_10200207502020 != null)
                    current.Total10200207502000 += (Decimal)current.cta_10200207502020;
                if (current.cta_10200207502990 != null)
                    current.Total10200207502000 += (Decimal)current.cta_10200207502990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207500000.cta_10200207503000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207500000.cta_10200207503000;
                current.Total10200207503000 = 0;
                if (current.cta_10200207503020 != null)
                    current.Total10200207503000 += (Decimal)current.cta_10200207503020;
                if (current.cta_10200207503990 != null)
                    current.Total10200207503000 += (Decimal)current.cta_10200207503990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000.cta_10200207500000;
                current.Total10200207500000 = 0;
                if (current.cta_10200207501000 != null && current.cta_10200207501000.Total10200207501000 != 0)
                    current.Total10200207500000 += (Decimal)current.cta_10200207501000.Total10200207501000;
                if (current.cta_10200207502000 != null && current.cta_10200207502000.Total10200207502000 != 0)
                    current.Total10200207500000 += (Decimal)current.cta_10200207502000.Total10200207502000;
                if (current.cta_10200207503000 != null && current.cta_10200207503000.Total10200207503000 != 0)
                    current.Total10200207500000 += (Decimal)current.cta_10200207503000.Total10200207503000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200200000000;
                current.Total10200200000000 = 0;
                if (current.cta_10200200100000 != null && current.cta_10200200100000.Total10200200100000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200200100000.Total10200200100000;
                if (current.cta_10200200200000 != null && current.cta_10200200200000.Total10200200200000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200200200000.Total10200200200000;
                if (current.cta_10200200300000 != null && current.cta_10200200300000.Total10200200300000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200200300000.Total10200200300000;
                if (current.cta_10200200400000 != null && current.cta_10200200400000.Total10200200400000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200200400000.Total10200200400000;
                if (current.cta_10200200500000 != null && current.cta_10200200500000.Total10200200500000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200200500000.Total10200200500000;
                if (current.cta_10200200600000 != null && current.cta_10200200600000.Total10200200600000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200200600000.Total10200200600000;
                if (current.cta_10200200700000 != null && current.cta_10200200700000.Total10200200700000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200200700000.Total10200200700000;
                if (current.cta_10200200800000 != null && current.cta_10200200800000.Total10200200800000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200200800000.Total10200200800000;
                if (current.cta_10200200900000 != null && current.cta_10200200900000.Total10200200900000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200200900000.Total10200200900000;
                if (current.cta_10200201000000 != null && current.cta_10200201000000.Total10200201000000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200201000000.Total10200201000000;
                if (current.cta_10200201100000 != null && current.cta_10200201100000.Total10200201100000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200201100000.Total10200201100000;
                if (current.cta_10200201200000 != null && current.cta_10200201200000.Total10200201200000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200201200000.Total10200201200000;
                if (current.cta_10200201300000 != null && current.cta_10200201300000.Total10200201300000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200201300000.Total10200201300000;
                if (current.cta_10200201400000 != null && current.cta_10200201400000.Total10200201400000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200201400000.Total10200201400000;
                if (current.cta_10200201500000 != null && current.cta_10200201500000.Total10200201500000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200201500000.Total10200201500000;
                if (current.cta_10200201600000 != null && current.cta_10200201600000.Total10200201600000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200201600000.Total10200201600000;
                if (current.cta_10200205300000 != null && current.cta_10200205300000.Total10200205300000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200205300000.Total10200205300000;
                if (current.cta_10200205900000 != null && current.cta_10200205900000.Total10200205900000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200205900000.Total10200205900000;
                if (current.cta_10200206000000 != null && current.cta_10200206000000.Total10200206000000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200206000000.Total10200206000000;
                if (current.cta_10200206100000 != null && current.cta_10200206100000.Total10200206100000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200206100000.Total10200206100000;
                if (current.cta_10200206200000 != null && current.cta_10200206200000.Total10200206200000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200206200000.Total10200206200000;
                if (current.cta_10200206300000 != null && current.cta_10200206300000.Total10200206300000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200206300000.Total10200206300000;
                if (current.cta_10200206400000 != null && current.cta_10200206400000.Total10200206400000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200206400000.Total10200206400000;
                if (current.cta_10200206500000 != null && current.cta_10200206500000.Total10200206500000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200206500000.Total10200206500000;
                if (current.cta_10200206600000 != null && current.cta_10200206600000.Total10200206600000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200206600000.Total10200206600000;
                if (current.cta_10200206700000 != null && current.cta_10200206700000.Total10200206700000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200206700000.Total10200206700000;
                if (current.cta_10200206800000 != null && current.cta_10200206800000.Total10200206800000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200206800000.Total10200206800000;
                if (current.cta_10200206900000 != null && current.cta_10200206900000.Total10200206900000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200206900000.Total10200206900000;
                if (current.cta_10200207000000 != null && current.cta_10200207000000.Total10200207000000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200207000000.Total10200207000000;
                if (current.cta_10200207100000 != null && current.cta_10200207100000.Total10200207100000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200207100000.Total10200207100000;
                if (current.cta_10200207200000 != null && current.cta_10200207200000.Total10200207200000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200207200000.Total10200207200000;
                if (current.cta_10200207300000 != null && current.cta_10200207300000.Total10200207300000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200207300000.Total10200207300000;
                if (current.cta_10200207400000 != null && current.cta_10200207400000.Total10200207400000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200207400000.Total10200207400000;
                if (current.cta_10200207500000 != null && current.cta_10200207500000.Total10200207500000 != 0)
                    current.Total10200200000000 += (Decimal)current.cta_10200207500000.Total10200207500000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300100000.cta_10200300101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300100000.cta_10200300101000;
                current.Total10200300101000 = 0;
                if (current.cta_10200300101010 != null)
                    current.Total10200300101000 += (Decimal)current.cta_10200300101010;
                if (current.cta_10200300101020 != null)
                    current.Total10200300101000 += (Decimal)current.cta_10200300101020;
                if (current.cta_10200300101030 != null)
                    current.Total10200300101000 += (Decimal)current.cta_10200300101030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300100000.cta_10200300102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300100000.cta_10200300102000;
                current.Total10200300102000 = 0;
                if (current.cta_10200300102010 != null)
                    current.Total10200300102000 += (Decimal)current.cta_10200300102010;
                if (current.cta_10200300102020 != null)
                    current.Total10200300102000 += (Decimal)current.cta_10200300102020;
                if (current.cta_10200300102030 != null)
                    current.Total10200300102000 += (Decimal)current.cta_10200300102030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300100000.cta_10200300103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300100000.cta_10200300103000;
                current.Total10200300103000 = 0;
                if (current.cta_10200300103010 != null)
                    current.Total10200300103000 += (Decimal)current.cta_10200300103010;
                if (current.cta_10200300103020 != null)
                    current.Total10200300103000 += (Decimal)current.cta_10200300103020;
                if (current.cta_10200300103030 != null)
                    current.Total10200300103000 += (Decimal)current.cta_10200300103030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300100000;
                current.Total10200300100000 = 0;
                if (current.cta_10200300101000 != null && current.cta_10200300101000.Total10200300101000 != 0)
                    current.Total10200300100000 += (Decimal)current.cta_10200300101000.Total10200300101000;
                if (current.cta_10200300102000 != null && current.cta_10200300102000.Total10200300102000 != 0)
                    current.Total10200300100000 += (Decimal)current.cta_10200300102000.Total10200300102000;
                if (current.cta_10200300103000 != null && current.cta_10200300103000.Total10200300103000 != 0)
                    current.Total10200300100000 += (Decimal)current.cta_10200300103000.Total10200300103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300200000.cta_10200300201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300200000.cta_10200300201000;
                current.Total10200300201000 = 0;
                if (current.cta_10200300201010 != null)
                    current.Total10200300201000 += (Decimal)current.cta_10200300201010;
                if (current.cta_10200300201020 != null)
                    current.Total10200300201000 += (Decimal)current.cta_10200300201020;
                if (current.cta_10200300201030 != null)
                    current.Total10200300201000 += (Decimal)current.cta_10200300201030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300200000.cta_10200300202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300200000.cta_10200300202000;
                current.Total10200300202000 = 0;
                if (current.cta_10200300202010 != null)
                    current.Total10200300202000 += (Decimal)current.cta_10200300202010;
                if (current.cta_10200300202020 != null)
                    current.Total10200300202000 += (Decimal)current.cta_10200300202020;
                if (current.cta_10200300202030 != null)
                    current.Total10200300202000 += (Decimal)current.cta_10200300202030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300200000.cta_10200300203000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300200000.cta_10200300203000;
                current.Total10200300203000 = 0;
                if (current.cta_10200300203010 != null)
                    current.Total10200300203000 += (Decimal)current.cta_10200300203010;
                if (current.cta_10200300203020 != null)
                    current.Total10200300203000 += (Decimal)current.cta_10200300203020;
                if (current.cta_10200300203030 != null)
                    current.Total10200300203000 += (Decimal)current.cta_10200300203030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300200000;
                current.Total10200300200000 = 0;
                if (current.cta_10200300201000 != null && current.cta_10200300201000.Total10200300201000 != 0)
                    current.Total10200300200000 += (Decimal)current.cta_10200300201000.Total10200300201000;
                if (current.cta_10200300202000 != null && current.cta_10200300202000.Total10200300202000 != 0)
                    current.Total10200300200000 += (Decimal)current.cta_10200300202000.Total10200300202000;
                if (current.cta_10200300203000 != null && current.cta_10200300203000.Total10200300203000 != 0)
                    current.Total10200300200000 += (Decimal)current.cta_10200300203000.Total10200300203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300300000.cta_10200300301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300300000.cta_10200300301000;
                current.Total10200300301000 = 0;
                if (current.cta_10200300301010 != null)
                    current.Total10200300301000 += (Decimal)current.cta_10200300301010;
                if (current.cta_10200300301020 != null)
                    current.Total10200300301000 += (Decimal)current.cta_10200300301020;
                if (current.cta_10200300301030 != null)
                    current.Total10200300301000 += (Decimal)current.cta_10200300301030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300300000.cta_10200300302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300300000.cta_10200300302000;
                current.Total10200300302000 = 0;
                if (current.cta_10200300302010 != null)
                    current.Total10200300302000 += (Decimal)current.cta_10200300302010;
                if (current.cta_10200300302020 != null)
                    current.Total10200300302000 += (Decimal)current.cta_10200300302020;
                if (current.cta_10200300302030 != null)
                    current.Total10200300302000 += (Decimal)current.cta_10200300302030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300300000.cta_10200300303000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300300000.cta_10200300303000;
                current.Total10200300303000 = 0;
                if (current.cta_10200300303010 != null)
                    current.Total10200300303000 += (Decimal)current.cta_10200300303010;
                if (current.cta_10200300303020 != null)
                    current.Total10200300303000 += (Decimal)current.cta_10200300303020;
                if (current.cta_10200300303030 != null)
                    current.Total10200300303000 += (Decimal)current.cta_10200300303030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300300000;
                current.Total10200300300000 = 0;
                if (current.cta_10200300301000 != null && current.cta_10200300301000.Total10200300301000 != 0)
                    current.Total10200300300000 += (Decimal)current.cta_10200300301000.Total10200300301000;
                if (current.cta_10200300302000 != null && current.cta_10200300302000.Total10200300302000 != 0)
                    current.Total10200300300000 += (Decimal)current.cta_10200300302000.Total10200300302000;
                if (current.cta_10200300303000 != null && current.cta_10200300303000.Total10200300303000 != 0)
                    current.Total10200300300000 += (Decimal)current.cta_10200300303000.Total10200300303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300400000.cta_10200300401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300400000.cta_10200300401000;
                current.Total10200300401000 = 0;
                if (current.cta_10200300401010 != null)
                    current.Total10200300401000 += (Decimal)current.cta_10200300401010;
                if (current.cta_10200300401020 != null)
                    current.Total10200300401000 += (Decimal)current.cta_10200300401020;
                if (current.cta_10200300401030 != null)
                    current.Total10200300401000 += (Decimal)current.cta_10200300401030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300400000.cta_10200300402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300400000.cta_10200300402000;
                current.Total10200300402000 = 0;
                if (current.cta_10200300402010 != null)
                    current.Total10200300402000 += (Decimal)current.cta_10200300402010;
                if (current.cta_10200300402020 != null)
                    current.Total10200300402000 += (Decimal)current.cta_10200300402020;
                if (current.cta_10200300402030 != null)
                    current.Total10200300402000 += (Decimal)current.cta_10200300402030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300400000.cta_10200300403000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300400000.cta_10200300403000;
                current.Total10200300403000 = 0;
                if (current.cta_10200300403010 != null)
                    current.Total10200300403000 += (Decimal)current.cta_10200300403010;
                if (current.cta_10200300403020 != null)
                    current.Total10200300403000 += (Decimal)current.cta_10200300403020;
                if (current.cta_10200300403030 != null)
                    current.Total10200300403000 += (Decimal)current.cta_10200300403030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300400000;
                current.Total10200300400000 = 0;
                if (current.cta_10200300401000 != null && current.cta_10200300401000.Total10200300401000 != 0)
                    current.Total10200300400000 += (Decimal)current.cta_10200300401000.Total10200300401000;
                if (current.cta_10200300402000 != null && current.cta_10200300402000.Total10200300402000 != 0)
                    current.Total10200300400000 += (Decimal)current.cta_10200300402000.Total10200300402000;
                if (current.cta_10200300403000 != null && current.cta_10200300403000.Total10200300403000 != 0)
                    current.Total10200300400000 += (Decimal)current.cta_10200300403000.Total10200300403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300500000.cta_10200300501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300500000.cta_10200300501000;
                current.Total10200300501000 = 0;
                if (current.cta_10200300501010 != null)
                    current.Total10200300501000 += (Decimal)current.cta_10200300501010;
                if (current.cta_10200300501020 != null)
                    current.Total10200300501000 += (Decimal)current.cta_10200300501020;
                if (current.cta_10200300501030 != null)
                    current.Total10200300501000 += (Decimal)current.cta_10200300501030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300500000.cta_10200300502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300500000.cta_10200300502000;
                current.Total10200300502000 = 0;
                if (current.cta_10200300502010 != null)
                    current.Total10200300502000 += (Decimal)current.cta_10200300502010;
                if (current.cta_10200300502020 != null)
                    current.Total10200300502000 += (Decimal)current.cta_10200300502020;
                if (current.cta_10200300502030 != null)
                    current.Total10200300502000 += (Decimal)current.cta_10200300502030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300500000.cta_10200300503000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300500000.cta_10200300503000;
                current.Total10200300503000 = 0;
                if (current.cta_10200300503010 != null)
                    current.Total10200300503000 += (Decimal)current.cta_10200300503010;
                if (current.cta_10200300503020 != null)
                    current.Total10200300503000 += (Decimal)current.cta_10200300503020;
                if (current.cta_10200300503030 != null)
                    current.Total10200300503000 += (Decimal)current.cta_10200300503030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300500000;
                current.Total10200300500000 = 0;
                if (current.cta_10200300501000 != null && current.cta_10200300501000.Total10200300501000 != 0)
                    current.Total10200300500000 += (Decimal)current.cta_10200300501000.Total10200300501000;
                if (current.cta_10200300502000 != null && current.cta_10200300502000.Total10200300502000 != 0)
                    current.Total10200300500000 += (Decimal)current.cta_10200300502000.Total10200300502000;
                if (current.cta_10200300503000 != null && current.cta_10200300503000.Total10200300503000 != 0)
                    current.Total10200300500000 += (Decimal)current.cta_10200300503000.Total10200300503000;
            }
        }

    }
}
