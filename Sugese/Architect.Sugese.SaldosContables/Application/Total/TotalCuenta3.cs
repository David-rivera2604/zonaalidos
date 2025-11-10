using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.Sugese.SaldosContables.Domain.Application.Total
{
    internal class TotalCuenta3
    {
        public static void Mapper(string account, Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModelo modelo, System.Nullable<decimal> value, bool specified)
        {

            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100100000;
                current.Total30100100100000 = 0;
                if (current.cta_30100100101000 != null)
                    current.Total30100100100000 += (Decimal)current.cta_30100100101000;
                if (current.cta_30100100102000 != null)
                    current.Total30100100100000 += (Decimal)current.cta_30100100102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100201000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100201000;
                current.Total30100100201000 = 0;
                if (current.cta_30100100201010 != null)
                    current.Total30100100201000 += (Decimal)current.cta_30100100201010;
                if (current.cta_30100100201020 != null)
                    current.Total30100100201000 += (Decimal)current.cta_30100100201020;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100202000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100202000;
                current.Total30100100202000 = 0;
                if (current.cta_30100100202010 != null)
                    current.Total30100100202000 += (Decimal)current.cta_30100100202010;
                if (current.cta_30100100202020 != null)
                    current.Total30100100202000 += (Decimal)current.cta_30100100202020;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000;
                current.Total30100100200000 = 0;
                if (current.cta_30100100201000 != null && current.cta_30100100201000.Total30100100201000 != 0)
                    current.Total30100100200000 += (Decimal)current.cta_30100100201000.Total30100100201000;
                if (current.cta_30100100202000 != null && current.cta_30100100202000.Total30100100202000 != 0)
                    current.Total30100100200000 += (Decimal)current.cta_30100100202000.Total30100100202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100600000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100600000;
                current.Total30100100600000 = 0;
                if (current.cta_30100100601000 != null)
                    current.Total30100100600000 += (Decimal)current.cta_30100100601000;
                if (current.cta_30100100602000 != null)
                    current.Total30100100600000 += (Decimal)current.cta_30100100602000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000;
                current.Total30100100000000 = 0;
                if (current.cta_30100100100000 != null && current.cta_30100100100000.Total30100100100000 != 0)
                    current.Total30100100000000 += (Decimal)current.cta_30100100100000.Total30100100100000;
                if (current.cta_30100100200000 != null && current.cta_30100100200000.Total30100100200000 != 0)
                    current.Total30100100000000 += (Decimal)current.cta_30100100200000.Total30100100200000;
                if (current.cta_30100100600000 != null && current.cta_30100100600000.Total30100100600000 != 0)
                    current.Total30100100000000 += (Decimal)current.cta_30100100600000.Total30100100600000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200101000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200101000;
                current.Total30100200101000 = 0;
                if (current.cta_30100200101010 != null)
                    current.Total30100200101000 += (Decimal)current.cta_30100200101010;
                if (current.cta_30100200101020 != null)
                    current.Total30100200101000 += (Decimal)current.cta_30100200101020;
                if (current.cta_30100200101030 != null)
                    current.Total30100200101000 += (Decimal)current.cta_30100200101030;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200102000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200102000;
                current.Total30100200102000 = 0;
                if (current.cta_30100200102010 != null)
                    current.Total30100200102000 += (Decimal)current.cta_30100200102010;
                if (current.cta_30100200102020 != null)
                    current.Total30100200102000 += (Decimal)current.cta_30100200102020;
                if (current.cta_30100200102030 != null)
                    current.Total30100200102000 += (Decimal)current.cta_30100200102030;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000;
                current.Total30100200100000 = 0;
                if (current.cta_30100200101000 != null && current.cta_30100200101000.Total30100200101000 != 0)
                    current.Total30100200100000 += (Decimal)current.cta_30100200101000.Total30100200101000;
                if (current.cta_30100200102000 != null && current.cta_30100200102000.Total30100200102000 != 0)
                    current.Total30100200100000 += (Decimal)current.cta_30100200102000.Total30100200102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000;
                current.Total30100200000000 = 0;
                if (current.cta_30100200100000 != null && current.cta_30100200100000.Total30100200100000 != 0)
                    current.Total30100200000000 += (Decimal)current.cta_30100200100000.Total30100200100000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300100000;
                current.Total30100300100000 = 0;
                if (current.cta_30100300101000 != null)
                    current.Total30100300100000 += (Decimal)current.cta_30100300101000;
                if (current.cta_30100300102000 != null)
                    current.Total30100300100000 += (Decimal)current.cta_30100300102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300200000;
                current.Total30100300200000 = 0;
                if (current.cta_30100300201000 != null)
                    current.Total30100300200000 += (Decimal)current.cta_30100300201000;
                if (current.cta_30100300202000 != null)
                    current.Total30100300200000 += (Decimal)current.cta_30100300202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300300000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300300000;
                current.Total30100300300000 = 0;
                if (current.cta_30100300301000 != null)
                    current.Total30100300300000 += (Decimal)current.cta_30100300301000;
                if (current.cta_30100300302000 != null)
                    current.Total30100300300000 += (Decimal)current.cta_30100300302000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300400000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300400000;
                current.Total30100300400000 = 0;
                if (current.cta_30100300401000 != null)
                    current.Total30100300400000 += (Decimal)current.cta_30100300401000;
                if (current.cta_30100300402000 != null)
                    current.Total30100300400000 += (Decimal)current.cta_30100300402000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100309900000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100309900000;
                current.Total30100309900000 = 0;
                if (current.cta_30100309901000 != null)
                    current.Total30100309900000 += (Decimal)current.cta_30100309901000;
                if (current.cta_30100309902000 != null)
                    current.Total30100309900000 += (Decimal)current.cta_30100309902000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000;
                current.Total30100300000000 = 0;
                if (current.cta_30100300100000 != null && current.cta_30100300100000.Total30100300100000 != 0)
                    current.Total30100300000000 += (Decimal)current.cta_30100300100000.Total30100300100000;
                if (current.cta_30100300200000 != null && current.cta_30100300200000.Total30100300200000 != 0)
                    current.Total30100300000000 += (Decimal)current.cta_30100300200000.Total30100300200000;
                if (current.cta_30100300300000 != null && current.cta_30100300300000.Total30100300300000 != 0)
                    current.Total30100300000000 += (Decimal)current.cta_30100300300000.Total30100300300000;
                if (current.cta_30100300400000 != null && current.cta_30100300400000.Total30100300400000 != 0)
                    current.Total30100300000000 += (Decimal)current.cta_30100300400000.Total30100300400000;
                if (current.cta_30100309900000 != null && current.cta_30100309900000.Total30100309900000 != 0)
                    current.Total30100300000000 += (Decimal)current.cta_30100309900000.Total30100309900000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400100000;
                current.Total30100400100000 = 0;
                if (current.cta_30100400101000 != null)
                    current.Total30100400100000 += (Decimal)current.cta_30100400101000;
                if (current.cta_30100400102000 != null)
                    current.Total30100400100000 += (Decimal)current.cta_30100400102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400200000;
                current.Total30100400200000 = 0;
                if (current.cta_30100400201000 != null)
                    current.Total30100400200000 += (Decimal)current.cta_30100400201000;
                if (current.cta_30100400202000 != null)
                    current.Total30100400200000 += (Decimal)current.cta_30100400202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400300000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400300000;
                current.Total30100400300000 = 0;
                if (current.cta_30100400301000 != null)
                    current.Total30100400300000 += (Decimal)current.cta_30100400301000;
                if (current.cta_30100400302000 != null)
                    current.Total30100400300000 += (Decimal)current.cta_30100400302000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400400000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400400000;
                current.Total30100400400000 = 0;
                if (current.cta_30100400401000 != null)
                    current.Total30100400400000 += (Decimal)current.cta_30100400401000;
                if (current.cta_30100400402000 != null)
                    current.Total30100400400000 += (Decimal)current.cta_30100400402000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100409900000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100409900000;
                current.Total30100409900000 = 0;
                if (current.cta_30100409901000 != null)
                    current.Total30100409900000 += (Decimal)current.cta_30100409901000;
                if (current.cta_30100409902000 != null)
                    current.Total30100409900000 += (Decimal)current.cta_30100409902000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000;
                current.Total30100400000000 = 0;
                if (current.cta_30100400100000 != null && current.cta_30100400100000.Total30100400100000 != 0)
                    current.Total30100400000000 += (Decimal)current.cta_30100400100000.Total30100400100000;
                if (current.cta_30100400200000 != null && current.cta_30100400200000.Total30100400200000 != 0)
                    current.Total30100400000000 += (Decimal)current.cta_30100400200000.Total30100400200000;
                if (current.cta_30100400300000 != null && current.cta_30100400300000.Total30100400300000 != 0)
                    current.Total30100400000000 += (Decimal)current.cta_30100400300000.Total30100400300000;
                if (current.cta_30100400400000 != null && current.cta_30100400400000.Total30100400400000 != 0)
                    current.Total30100400000000 += (Decimal)current.cta_30100400400000.Total30100400400000;
                if (current.cta_30100409900000 != null && current.cta_30100409900000.Total30100409900000 != 0)
                    current.Total30100400000000 += (Decimal)current.cta_30100409900000.Total30100409900000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500100000;
                current.Total30100500100000 = 0;
                if (current.cta_30100500101000 != null)
                    current.Total30100500100000 += (Decimal)current.cta_30100500101000;
                if (current.cta_30100500102000 != null)
                    current.Total30100500100000 += (Decimal)current.cta_30100500102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500201000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500201000;
                current.Total30100500201000 = 0;
                if (current.cta_30100500201010 != null)
                    current.Total30100500201000 += (Decimal)current.cta_30100500201010;
                if (current.cta_30100500201020 != null)
                    current.Total30100500201000 += (Decimal)current.cta_30100500201020;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500202000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500202000;
                current.Total30100500202000 = 0;
                if (current.cta_30100500202010 != null)
                    current.Total30100500202000 += (Decimal)current.cta_30100500202010;
                if (current.cta_30100500202020 != null)
                    current.Total30100500202000 += (Decimal)current.cta_30100500202020;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000;
                current.Total30100500200000 = 0;
                if (current.cta_30100500201000 != null && current.cta_30100500201000.Total30100500201000 != 0)
                    current.Total30100500200000 += (Decimal)current.cta_30100500201000.Total30100500201000;
                if (current.cta_30100500202000 != null && current.cta_30100500202000.Total30100500202000 != 0)
                    current.Total30100500200000 += (Decimal)current.cta_30100500202000.Total30100500202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100509900000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100509900000;
                current.Total30100509900000 = 0;
                if (current.cta_30100509901000 != null)
                    current.Total30100509900000 += (Decimal)current.cta_30100509901000;
                if (current.cta_30100509902000 != null)
                    current.Total30100509900000 += (Decimal)current.cta_30100509902000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000;
                current.Total30100500000000 = 0;
                if (current.cta_30100500100000 != null && current.cta_30100500100000.Total30100500100000 != 0)
                    current.Total30100500000000 += (Decimal)current.cta_30100500100000.Total30100500100000;
                if (current.cta_30100500200000 != null && current.cta_30100500200000.Total30100500200000 != 0)
                    current.Total30100500000000 += (Decimal)current.cta_30100500200000.Total30100500200000;
                if (current.cta_30100509900000 != null && current.cta_30100509900000.Total30100509900000 != 0)
                    current.Total30100500000000 += (Decimal)current.cta_30100509900000.Total30100509900000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700100000;
                current.Total30100700100000 = 0;
                if (current.cta_30100700101000 != null)
                    current.Total30100700100000 += (Decimal)current.cta_30100700101000;
                if (current.cta_30100700102000 != null)
                    current.Total30100700100000 += (Decimal)current.cta_30100700102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700200000;
                current.Total30100700200000 = 0;
                if (current.cta_30100700201000 != null)
                    current.Total30100700200000 += (Decimal)current.cta_30100700201000;
                if (current.cta_30100700202000 != null)
                    current.Total30100700200000 += (Decimal)current.cta_30100700202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null && modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000;
                current.Total30100700000000 = 0;
                if (current.cta_30100700100000 != null && current.cta_30100700100000.Total30100700100000 != 0)
                    current.Total30100700000000 += (Decimal)current.cta_30100700100000.Total30100700100000;
                if (current.cta_30100700200000 != null && current.cta_30100700200000.Total30100700200000 != 0)
                    current.Total30100700000000 += (Decimal)current.cta_30100700200000.Total30100700200000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30100000000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30100000000000;
                current.Total30100000000000 = 0;
                if (current.cta_30100100000000 != null && current.cta_30100100000000.Total30100100000000 != 0)
                    current.Total30100000000000 += (Decimal)current.cta_30100100000000.Total30100100000000;
                if (current.cta_30100200000000 != null && current.cta_30100200000000.Total30100200000000 != 0)
                    current.Total30100000000000 += (Decimal)current.cta_30100200000000.Total30100200000000;
                if (current.cta_30100300000000 != null && current.cta_30100300000000.Total30100300000000 != 0)
                    current.Total30100000000000 += (Decimal)current.cta_30100300000000.Total30100300000000;
                if (current.cta_30100400000000 != null && current.cta_30100400000000.Total30100400000000 != 0)
                    current.Total30100000000000 += (Decimal)current.cta_30100400000000.Total30100400000000;
                if (current.cta_30100500000000 != null && current.cta_30100500000000.Total30100500000000 != 0)
                    current.Total30100000000000 += (Decimal)current.cta_30100500000000.Total30100500000000;
                if (current.cta_30100700000000 != null && current.cta_30100700000000.Total30100700000000 != 0)
                    current.Total30100000000000 += (Decimal)current.cta_30100700000000.Total30100700000000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100100000;
                current.Total30200100100000 = 0;
                if (current.cta_30200100101000 != null)
                    current.Total30200100100000 += (Decimal)current.cta_30200100101000;
                if (current.cta_30200100102000 != null)
                    current.Total30200100100000 += (Decimal)current.cta_30200100102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100200000;
                current.Total30200100200000 = 0;
                if (current.cta_30200100201000 != null)
                    current.Total30200100200000 += (Decimal)current.cta_30200100201000;
                if (current.cta_30200100202000 != null)
                    current.Total30200100200000 += (Decimal)current.cta_30200100202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100300000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100300000;
                current.Total30200100300000 = 0;
                if (current.cta_30200100301000 != null)
                    current.Total30200100300000 += (Decimal)current.cta_30200100301000;
                if (current.cta_30200100302000 != null)
                    current.Total30200100300000 += (Decimal)current.cta_30200100302000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000;
                current.Total30200100000000 = 0;
                if (current.cta_30200100100000 != null && current.cta_30200100100000.Total30200100100000 != 0)
                    current.Total30200100000000 += (Decimal)current.cta_30200100100000.Total30200100100000;
                if (current.cta_30200100200000 != null && current.cta_30200100200000.Total30200100200000 != 0)
                    current.Total30200100000000 += (Decimal)current.cta_30200100200000.Total30200100200000;
                if (current.cta_30200100300000 != null && current.cta_30200100300000.Total30200100300000 != 0)
                    current.Total30200100000000 += (Decimal)current.cta_30200100300000.Total30200100300000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200101000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200101000;
                current.Total30200200101000 = 0;
                if (current.cta_30200200101010 != null)
                    current.Total30200200101000 += (Decimal)current.cta_30200200101010;
                if (current.cta_30200200101020 != null)
                    current.Total30200200101000 += (Decimal)current.cta_30200200101020;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200102000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200102000;
                current.Total30200200102000 = 0;
                if (current.cta_30200200102010 != null)
                    current.Total30200200102000 += (Decimal)current.cta_30200200102010;
                if (current.cta_30200200102020 != null)
                    current.Total30200200102000 += (Decimal)current.cta_30200200102020;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000;
                current.Total30200200100000 = 0;
                if (current.cta_30200200101000 != null && current.cta_30200200101000.Total30200200101000 != 0)
                    current.Total30200200100000 += (Decimal)current.cta_30200200101000.Total30200200101000;
                if (current.cta_30200200102000 != null && current.cta_30200200102000.Total30200200102000 != 0)
                    current.Total30200200100000 += (Decimal)current.cta_30200200102000.Total30200200102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200201000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200201000;
                current.Total30200200201000 = 0;
                if (current.cta_30200200201010 != null)
                    current.Total30200200201000 += (Decimal)current.cta_30200200201010;
                if (current.cta_30200200201020 != null)
                    current.Total30200200201000 += (Decimal)current.cta_30200200201020;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200202000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200202000;
                current.Total30200200202000 = 0;
                if (current.cta_30200200202010 != null)
                    current.Total30200200202000 += (Decimal)current.cta_30200200202010;
                if (current.cta_30200200202020 != null)
                    current.Total30200200202000 += (Decimal)current.cta_30200200202020;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000;
                current.Total30200200200000 = 0;
                if (current.cta_30200200201000 != null && current.cta_30200200201000.Total30200200201000 != 0)
                    current.Total30200200200000 += (Decimal)current.cta_30200200201000.Total30200200201000;
                if (current.cta_30200200202000 != null && current.cta_30200200202000.Total30200200202000 != 0)
                    current.Total30200200200000 += (Decimal)current.cta_30200200202000.Total30200200202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000;
                current.Total30200200000000 = 0;
                if (current.cta_30200200100000 != null && current.cta_30200200100000.Total30200200100000 != 0)
                    current.Total30200200000000 += (Decimal)current.cta_30200200100000.Total30200200100000;
                if (current.cta_30200200200000 != null && current.cta_30200200200000.Total30200200200000 != 0)
                    current.Total30200200000000 += (Decimal)current.cta_30200200200000.Total30200200200000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300100000;
                current.Total30200300100000 = 0;
                if (current.cta_30200300101000 != null)
                    current.Total30200300100000 += (Decimal)current.cta_30200300101000;
                if (current.cta_30200300102000 != null)
                    current.Total30200300100000 += (Decimal)current.cta_30200300102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300200000;
                current.Total30200300200000 = 0;
                if (current.cta_30200300201000 != null)
                    current.Total30200300200000 += (Decimal)current.cta_30200300201000;
                if (current.cta_30200300202000 != null)
                    current.Total30200300200000 += (Decimal)current.cta_30200300202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000;
                current.Total30200300000000 = 0;
                if (current.cta_30200300100000 != null && current.cta_30200300100000.Total30200300100000 != 0)
                    current.Total30200300000000 += (Decimal)current.cta_30200300100000.Total30200300100000;
                if (current.cta_30200300200000 != null && current.cta_30200300200000.Total30200300200000 != 0)
                    current.Total30200300000000 += (Decimal)current.cta_30200300200000.Total30200300200000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000.cta_30200500100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000.cta_30200500100000;
                current.Total30200500100000 = 0;
                if (current.cta_30200500101000 != null)
                    current.Total30200500100000 += (Decimal)current.cta_30200500101000;
                if (current.cta_30200500102000 != null)
                    current.Total30200500100000 += (Decimal)current.cta_30200500102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000;
                current.Total30200500000000 = 0;
                if (current.cta_30200500100000 != null && current.cta_30200500100000.Total30200500100000 != 0)
                    current.Total30200500000000 += (Decimal)current.cta_30200500100000.Total30200500100000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000.cta_30200600100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000.cta_30200600100000;
                current.Total30200600100000 = 0;
                if (current.cta_30200600101000 != null)
                    current.Total30200600100000 += (Decimal)current.cta_30200600101000;
                if (current.cta_30200600102000 != null)
                    current.Total30200600100000 += (Decimal)current.cta_30200600102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null && modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000;
                current.Total30200600000000 = 0;
                if (current.cta_30200600100000 != null && current.cta_30200600100000.Total30200600100000 != 0)
                    current.Total30200600000000 += (Decimal)current.cta_30200600100000.Total30200600100000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30200000000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30200000000000;
                current.Total30200000000000 = 0;
                if (current.cta_30200100000000 != null && current.cta_30200100000000.Total30200100000000 != 0)
                    current.Total30200000000000 += (Decimal)current.cta_30200100000000.Total30200100000000;
                if (current.cta_30200200000000 != null && current.cta_30200200000000.Total30200200000000 != 0)
                    current.Total30200000000000 += (Decimal)current.cta_30200200000000.Total30200200000000;
                if (current.cta_30200300000000 != null && current.cta_30200300000000.Total30200300000000 != 0)
                    current.Total30200000000000 += (Decimal)current.cta_30200300000000.Total30200300000000;
                if (current.cta_30200500000000 != null && current.cta_30200500000000.Total30200500000000 != 0)
                    current.Total30200000000000 += (Decimal)current.cta_30200500000000.Total30200500000000;
                if (current.cta_30200600000000 != null && current.cta_30200600000000.Total30200600000000 != 0)
                    current.Total30200000000000 += (Decimal)current.cta_30200600000000.Total30200600000000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100101000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100101000;
                current.Total30300100101000 = 0;
                if (current.cta_30300100101010 != null)
                    current.Total30300100101000 += (Decimal)current.cta_30300100101010;
                if (current.cta_30300100101020 != null)
                    current.Total30300100101000 += (Decimal)current.cta_30300100101020;
                if (current.cta_30300100101090 != null)
                    current.Total30300100101000 += (Decimal)current.cta_30300100101090;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100102000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100102000;
                current.Total30300100102000 = 0;
                if (current.cta_30300100102010 != null)
                    current.Total30300100102000 += (Decimal)current.cta_30300100102010;
                if (current.cta_30300100102020 != null)
                    current.Total30300100102000 += (Decimal)current.cta_30300100102020;
                if (current.cta_30300100102090 != null)
                    current.Total30300100102000 += (Decimal)current.cta_30300100102090;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000;
                current.Total30300100100000 = 0;
                if (current.cta_30300100101000 != null && current.cta_30300100101000.Total30300100101000 != 0)
                    current.Total30300100100000 += (Decimal)current.cta_30300100101000.Total30300100101000;
                if (current.cta_30300100102000 != null && current.cta_30300100102000.Total30300100102000 != 0)
                    current.Total30300100100000 += (Decimal)current.cta_30300100102000.Total30300100102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000;
                current.Total30300100201000 = 0;
                if (current.cta_30300100201020 != null)
                    current.Total30300100201000 += (Decimal)current.cta_30300100201020;
                if (current.cta_30300100201030 != null)
                    current.Total30300100201000 += (Decimal)current.cta_30300100201030;
                if (current.cta_30300100201110 != null)
                    current.Total30300100201000 += (Decimal)current.cta_30300100201110;
                if (current.cta_30300100201120 != null)
                    current.Total30300100201000 += (Decimal)current.cta_30300100201120;
                if (current.cta_30300100201190 != null)
                    current.Total30300100201000 += (Decimal)current.cta_30300100201190;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000;
                current.Total30300100202000 = 0;
                if (current.cta_30300100202020 != null)
                    current.Total30300100202000 += (Decimal)current.cta_30300100202020;
                if (current.cta_30300100202030 != null)
                    current.Total30300100202000 += (Decimal)current.cta_30300100202030;
                if (current.cta_30300100202110 != null)
                    current.Total30300100202000 += (Decimal)current.cta_30300100202110;
                if (current.cta_30300100202120 != null)
                    current.Total30300100202000 += (Decimal)current.cta_30300100202120;
                if (current.cta_30300100202190 != null)
                    current.Total30300100202000 += (Decimal)current.cta_30300100202190;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000;
                current.Total30300100200000 = 0;
                if (current.cta_30300100201000 != null && current.cta_30300100201000.Total30300100201000 != 0)
                    current.Total30300100200000 += (Decimal)current.cta_30300100201000.Total30300100201000;
                if (current.cta_30300100202000 != null && current.cta_30300100202000.Total30300100202000 != 0)
                    current.Total30300100200000 += (Decimal)current.cta_30300100202000.Total30300100202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000;
                current.Total30300100301000 = 0;
                if (current.cta_30300100301020 != null)
                    current.Total30300100301000 += (Decimal)current.cta_30300100301020;
                if (current.cta_30300100301030 != null)
                    current.Total30300100301000 += (Decimal)current.cta_30300100301030;
                if (current.cta_30300100301110 != null)
                    current.Total30300100301000 += (Decimal)current.cta_30300100301110;
                if (current.cta_30300100301120 != null)
                    current.Total30300100301000 += (Decimal)current.cta_30300100301120;
                if (current.cta_30300100301190 != null)
                    current.Total30300100301000 += (Decimal)current.cta_30300100301190;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000;
                current.Total30300100302000 = 0;
                if (current.cta_30300100302020 != null)
                    current.Total30300100302000 += (Decimal)current.cta_30300100302020;
                if (current.cta_30300100302030 != null)
                    current.Total30300100302000 += (Decimal)current.cta_30300100302030;
                if (current.cta_30300100302110 != null)
                    current.Total30300100302000 += (Decimal)current.cta_30300100302110;
                if (current.cta_30300100302120 != null)
                    current.Total30300100302000 += (Decimal)current.cta_30300100302120;
                if (current.cta_30300100302190 != null)
                    current.Total30300100302000 += (Decimal)current.cta_30300100302190;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000;
                current.Total30300100300000 = 0;
                if (current.cta_30300100301000 != null && current.cta_30300100301000.Total30300100301000 != 0)
                    current.Total30300100300000 += (Decimal)current.cta_30300100301000.Total30300100301000;
                if (current.cta_30300100302000 != null && current.cta_30300100302000.Total30300100302000 != 0)
                    current.Total30300100300000 += (Decimal)current.cta_30300100302000.Total30300100302000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000;
                current.Total30300100401000 = 0;
                if (current.cta_30300100401020 != null)
                    current.Total30300100401000 += (Decimal)current.cta_30300100401020;
                if (current.cta_30300100401030 != null)
                    current.Total30300100401000 += (Decimal)current.cta_30300100401030;
                if (current.cta_30300100401110 != null)
                    current.Total30300100401000 += (Decimal)current.cta_30300100401110;
                if (current.cta_30300100401120 != null)
                    current.Total30300100401000 += (Decimal)current.cta_30300100401120;
                if (current.cta_30300100401190 != null)
                    current.Total30300100401000 += (Decimal)current.cta_30300100401190;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000;
                current.Total30300100402000 = 0;
                if (current.cta_30300100402020 != null)
                    current.Total30300100402000 += (Decimal)current.cta_30300100402020;
                if (current.cta_30300100402030 != null)
                    current.Total30300100402000 += (Decimal)current.cta_30300100402030;
                if (current.cta_30300100402110 != null)
                    current.Total30300100402000 += (Decimal)current.cta_30300100402110;
                if (current.cta_30300100402120 != null)
                    current.Total30300100402000 += (Decimal)current.cta_30300100402120;
                if (current.cta_30300100402190 != null)
                    current.Total30300100402000 += (Decimal)current.cta_30300100402190;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000;
                current.Total30300100400000 = 0;
                if (current.cta_30300100401000 != null && current.cta_30300100401000.Total30300100401000 != 0)
                    current.Total30300100400000 += (Decimal)current.cta_30300100401000.Total30300100401000;
                if (current.cta_30300100402000 != null && current.cta_30300100402000.Total30300100402000 != 0)
                    current.Total30300100400000 += (Decimal)current.cta_30300100402000.Total30300100402000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000;
                current.Total30300100501000 = 0;
                if (current.cta_30300100501020 != null)
                    current.Total30300100501000 += (Decimal)current.cta_30300100501020;
                if (current.cta_30300100501030 != null)
                    current.Total30300100501000 += (Decimal)current.cta_30300100501030;
                if (current.cta_30300100501110 != null)
                    current.Total30300100501000 += (Decimal)current.cta_30300100501110;
                if (current.cta_30300100501120 != null)
                    current.Total30300100501000 += (Decimal)current.cta_30300100501120;
                if (current.cta_30300100501190 != null)
                    current.Total30300100501000 += (Decimal)current.cta_30300100501190;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000;
                current.Total30300100502000 = 0;
                if (current.cta_30300100502020 != null)
                    current.Total30300100502000 += (Decimal)current.cta_30300100502020;
                if (current.cta_30300100502030 != null)
                    current.Total30300100502000 += (Decimal)current.cta_30300100502030;
                if (current.cta_30300100502110 != null)
                    current.Total30300100502000 += (Decimal)current.cta_30300100502110;
                if (current.cta_30300100502120 != null)
                    current.Total30300100502000 += (Decimal)current.cta_30300100502120;
                if (current.cta_30300100502190 != null)
                    current.Total30300100502000 += (Decimal)current.cta_30300100502190;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000;
                current.Total30300100500000 = 0;
                if (current.cta_30300100501000 != null && current.cta_30300100501000.Total30300100501000 != 0)
                    current.Total30300100500000 += (Decimal)current.cta_30300100501000.Total30300100501000;
                if (current.cta_30300100502000 != null && current.cta_30300100502000.Total30300100502000 != 0)
                    current.Total30300100500000 += (Decimal)current.cta_30300100502000.Total30300100502000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000.cta_30300100601000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000.cta_30300100601000;
                current.Total30300100601000 = 0;
                if (current.cta_30300100601010 != null)
                    current.Total30300100601000 += (Decimal)current.cta_30300100601010;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000.cta_30300100602000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000.cta_30300100602000;
                current.Total30300100602000 = 0;
                if (current.cta_30300100602010 != null)
                    current.Total30300100602000 += (Decimal)current.cta_30300100602010;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000;
                current.Total30300100600000 = 0;
                if (current.cta_30300100601000 != null && current.cta_30300100601000.Total30300100601000 != 0)
                    current.Total30300100600000 += (Decimal)current.cta_30300100601000.Total30300100601000;
                if (current.cta_30300100602000 != null && current.cta_30300100602000.Total30300100602000 != 0)
                    current.Total30300100600000 += (Decimal)current.cta_30300100602000.Total30300100602000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000;
                current.Total30300100701000 = 0;
                if (current.cta_30300100701020 != null)
                    current.Total30300100701000 += (Decimal)current.cta_30300100701020;
                if (current.cta_30300100701030 != null)
                    current.Total30300100701000 += (Decimal)current.cta_30300100701030;
                if (current.cta_30300100701040 != null)
                    current.Total30300100701000 += (Decimal)current.cta_30300100701040;
                if (current.cta_30300100701050 != null)
                    current.Total30300100701000 += (Decimal)current.cta_30300100701050;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000;
                current.Total30300100702000 = 0;
                if (current.cta_30300100702020 != null)
                    current.Total30300100702000 += (Decimal)current.cta_30300100702020;
                if (current.cta_30300100702030 != null)
                    current.Total30300100702000 += (Decimal)current.cta_30300100702030;
                if (current.cta_30300100702040 != null)
                    current.Total30300100702000 += (Decimal)current.cta_30300100702040;
                if (current.cta_30300100702050 != null)
                    current.Total30300100702000 += (Decimal)current.cta_30300100702050;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000;
                current.Total30300100700000 = 0;
                if (current.cta_30300100701000 != null && current.cta_30300100701000.Total30300100701000 != 0)
                    current.Total30300100700000 += (Decimal)current.cta_30300100701000.Total30300100701000;
                if (current.cta_30300100702000 != null && current.cta_30300100702000.Total30300100702000 != 0)
                    current.Total30300100700000 += (Decimal)current.cta_30300100702000.Total30300100702000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100801000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100801000;
                current.Total30300100801000 = 0;
                if (current.cta_30300100801010 != null)
                    current.Total30300100801000 += (Decimal)current.cta_30300100801010;
                if (current.cta_30300100801110 != null)
                    current.Total30300100801000 += (Decimal)current.cta_30300100801110;
                if (current.cta_30300100801120 != null)
                    current.Total30300100801000 += (Decimal)current.cta_30300100801120;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100802000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100802000;
                current.Total30300100802000 = 0;
                if (current.cta_30300100802010 != null)
                    current.Total30300100802000 += (Decimal)current.cta_30300100802010;
                if (current.cta_30300100802110 != null)
                    current.Total30300100802000 += (Decimal)current.cta_30300100802110;
                if (current.cta_30300100802120 != null)
                    current.Total30300100802000 += (Decimal)current.cta_30300100802120;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000;
                current.Total30300100800000 = 0;
                if (current.cta_30300100801000 != null && current.cta_30300100801000.Total30300100801000 != 0)
                    current.Total30300100800000 += (Decimal)current.cta_30300100801000.Total30300100801000;
                if (current.cta_30300100802000 != null && current.cta_30300100802000.Total30300100802000 != 0)
                    current.Total30300100800000 += (Decimal)current.cta_30300100802000.Total30300100802000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000;
                current.Total30300100000000 = 0;
                if (current.cta_30300100100000 != null && current.cta_30300100100000.Total30300100100000 != 0)
                    current.Total30300100000000 += (Decimal)current.cta_30300100100000.Total30300100100000;
                if (current.cta_30300100200000 != null && current.cta_30300100200000.Total30300100200000 != 0)
                    current.Total30300100000000 += (Decimal)current.cta_30300100200000.Total30300100200000;
                if (current.cta_30300100300000 != null && current.cta_30300100300000.Total30300100300000 != 0)
                    current.Total30300100000000 += (Decimal)current.cta_30300100300000.Total30300100300000;
                if (current.cta_30300100400000 != null && current.cta_30300100400000.Total30300100400000 != 0)
                    current.Total30300100000000 += (Decimal)current.cta_30300100400000.Total30300100400000;
                if (current.cta_30300100500000 != null && current.cta_30300100500000.Total30300100500000 != 0)
                    current.Total30300100000000 += (Decimal)current.cta_30300100500000.Total30300100500000;
                if (current.cta_30300100600000 != null && current.cta_30300100600000.Total30300100600000 != 0)
                    current.Total30300100000000 += (Decimal)current.cta_30300100600000.Total30300100600000;
                if (current.cta_30300100700000 != null && current.cta_30300100700000.Total30300100700000 != 0)
                    current.Total30300100000000 += (Decimal)current.cta_30300100700000.Total30300100700000;
                if (current.cta_30300100800000 != null && current.cta_30300100800000.Total30300100800000 != 0)
                    current.Total30300100000000 += (Decimal)current.cta_30300100800000.Total30300100800000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200100000;
                current.Total30300200100000 = 0;
                if (current.cta_30300200101000 != null)
                    current.Total30300200100000 += (Decimal)current.cta_30300200101000;
                if (current.cta_30300200102000 != null)
                    current.Total30300200100000 += (Decimal)current.cta_30300200102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200200000;
                current.Total30300200200000 = 0;
                if (current.cta_30300200201000 != null)
                    current.Total30300200200000 += (Decimal)current.cta_30300200201000;
                if (current.cta_30300200202000 != null)
                    current.Total30300200200000 += (Decimal)current.cta_30300200202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200300000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200300000;
                current.Total30300200300000 = 0;
                if (current.cta_30300200301000 != null)
                    current.Total30300200300000 += (Decimal)current.cta_30300200301000;
                if (current.cta_30300200302000 != null)
                    current.Total30300200300000 += (Decimal)current.cta_30300200302000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000;
                current.Total30300200000000 = 0;
                if (current.cta_30300200100000 != null && current.cta_30300200100000.Total30300200100000 != 0)
                    current.Total30300200000000 += (Decimal)current.cta_30300200100000.Total30300200100000;
                if (current.cta_30300200200000 != null && current.cta_30300200200000.Total30300200200000 != 0)
                    current.Total30300200000000 += (Decimal)current.cta_30300200200000.Total30300200200000;
                if (current.cta_30300200300000 != null && current.cta_30300200300000.Total30300200300000 != 0)
                    current.Total30300200000000 += (Decimal)current.cta_30300200300000.Total30300200300000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000.cta_30300300100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000.cta_30300300100000;
                current.Total30300300100000 = 0;
                if (current.cta_30300300101000 != null)
                    current.Total30300300100000 += (Decimal)current.cta_30300300101000;
                if (current.cta_30300300102000 != null)
                    current.Total30300300100000 += (Decimal)current.cta_30300300102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000;
                current.Total30300300000000 = 0;
                if (current.cta_30300300100000 != null && current.cta_30300300100000.Total30300300100000 != 0)
                    current.Total30300300000000 += (Decimal)current.cta_30300300100000.Total30300300100000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000.cta_30300400100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000.cta_30300400100000;
                current.Total30300400100000 = 0;
                if (current.cta_30300400101000 != null)
                    current.Total30300400100000 += (Decimal)current.cta_30300400101000;
                if (current.cta_30300400102000 != null)
                    current.Total30300400100000 += (Decimal)current.cta_30300400102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000;
                current.Total30300400000000 = 0;
                if (current.cta_30300400100000 != null && current.cta_30300400100000.Total30300400100000 != 0)
                    current.Total30300400000000 += (Decimal)current.cta_30300400100000.Total30300400100000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500100000;
                current.Total30300500100000 = 0;
                if (current.cta_30300500101000 != null)
                    current.Total30300500100000 += (Decimal)current.cta_30300500101000;
                if (current.cta_30300500102000 != null)
                    current.Total30300500100000 += (Decimal)current.cta_30300500102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500200000;
                current.Total30300500200000 = 0;
                if (current.cta_30300500201000 != null)
                    current.Total30300500200000 += (Decimal)current.cta_30300500201000;
                if (current.cta_30300500202000 != null)
                    current.Total30300500200000 += (Decimal)current.cta_30300500202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500300000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500300000;
                current.Total30300500300000 = 0;
                if (current.cta_30300500301000 != null)
                    current.Total30300500300000 += (Decimal)current.cta_30300500301000;
                if (current.cta_30300500302000 != null)
                    current.Total30300500300000 += (Decimal)current.cta_30300500302000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500400000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500400000;
                current.Total30300500400000 = 0;
                if (current.cta_30300500401000 != null)
                    current.Total30300500400000 += (Decimal)current.cta_30300500401000;
                if (current.cta_30300500402000 != null)
                    current.Total30300500400000 += (Decimal)current.cta_30300500402000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null && modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000;
                current.Total30300500000000 = 0;
                if (current.cta_30300500100000 != null && current.cta_30300500100000.Total30300500100000 != 0)
                    current.Total30300500000000 += (Decimal)current.cta_30300500100000.Total30300500100000;
                if (current.cta_30300500200000 != null && current.cta_30300500200000.Total30300500200000 != 0)
                    current.Total30300500000000 += (Decimal)current.cta_30300500200000.Total30300500200000;
                if (current.cta_30300500300000 != null && current.cta_30300500300000.Total30300500300000 != 0)
                    current.Total30300500000000 += (Decimal)current.cta_30300500300000.Total30300500300000;
                if (current.cta_30300500400000 != null && current.cta_30300500400000.Total30300500400000 != 0)
                    current.Total30300500000000 += (Decimal)current.cta_30300500400000.Total30300500400000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30300000000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30300000000000;
                current.Total30300000000000 = 0;
                if (current.cta_30300100000000 != null && current.cta_30300100000000.Total30300100000000 != 0)
                    current.Total30300000000000 += (Decimal)current.cta_30300100000000.Total30300100000000;
                if (current.cta_30300200000000 != null && current.cta_30300200000000.Total30300200000000 != 0)
                    current.Total30300000000000 += (Decimal)current.cta_30300200000000.Total30300200000000;
                if (current.cta_30300300000000 != null && current.cta_30300300000000.Total30300300000000 != 0)
                    current.Total30300000000000 += (Decimal)current.cta_30300300000000.Total30300300000000;
                if (current.cta_30300400000000 != null && current.cta_30300400000000.Total30300400000000 != 0)
                    current.Total30300000000000 += (Decimal)current.cta_30300400000000.Total30300400000000;
                if (current.cta_30300500000000 != null && current.cta_30300500000000.Total30300500000000 != 0)
                    current.Total30300000000000 += (Decimal)current.cta_30300500000000.Total30300500000000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000.cta_30400100100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000.cta_30400100100000;
                current.Total30400100100000 = 0;
                if (current.cta_30400100101000 != null)
                    current.Total30400100100000 += (Decimal)current.cta_30400100101000;
                if (current.cta_30400100102000 != null)
                    current.Total30400100100000 += (Decimal)current.cta_30400100102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000;
                current.Total30400100000000 = 0;
                if (current.cta_30400100100000 != null && current.cta_30400100100000.Total30400100100000 != 0)
                    current.Total30400100000000 += (Decimal)current.cta_30400100100000.Total30400100100000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200100000;
                current.Total30400200100000 = 0;
                if (current.cta_30400200101000 != null)
                    current.Total30400200100000 += (Decimal)current.cta_30400200101000;
                if (current.cta_30400200102000 != null)
                    current.Total30400200100000 += (Decimal)current.cta_30400200102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000.cta_30400200201000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000.cta_30400200201000;
                current.Total30400200201000 = 0;
                if (current.cta_30400200201990 != null)
                    current.Total30400200201000 += (Decimal)current.cta_30400200201990;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000.cta_30400200202000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000.cta_30400200202000;
                current.Total30400200202000 = 0;
                if (current.cta_30400200202990 != null)
                    current.Total30400200202000 += (Decimal)current.cta_30400200202990;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000;
                current.Total30400200200000 = 0;
                if (current.cta_30400200201000 != null && current.cta_30400200201000.Total30400200201000 != 0)
                    current.Total30400200200000 += (Decimal)current.cta_30400200201000.Total30400200201000;
                if (current.cta_30400200202000 != null && current.cta_30400200202000.Total30400200202000 != 0)
                    current.Total30400200200000 += (Decimal)current.cta_30400200202000.Total30400200202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200300000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200300000;
                current.Total30400200300000 = 0;
                if (current.cta_30400200301000 != null)
                    current.Total30400200300000 += (Decimal)current.cta_30400200301000;
                if (current.cta_30400200302000 != null)
                    current.Total30400200300000 += (Decimal)current.cta_30400200302000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000;
                current.Total30400200000000 = 0;
                if (current.cta_30400200100000 != null && current.cta_30400200100000.Total30400200100000 != 0)
                    current.Total30400200000000 += (Decimal)current.cta_30400200100000.Total30400200100000;
                if (current.cta_30400200200000 != null && current.cta_30400200200000.Total30400200200000 != 0)
                    current.Total30400200000000 += (Decimal)current.cta_30400200200000.Total30400200200000;
                if (current.cta_30400200300000 != null && current.cta_30400200300000.Total30400200300000 != 0)
                    current.Total30400200000000 += (Decimal)current.cta_30400200300000.Total30400200300000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300100000;
                current.Total30400300100000 = 0;
                if (current.cta_30400300101000 != null)
                    current.Total30400300100000 += (Decimal)current.cta_30400300101000;
                if (current.cta_30400300102000 != null)
                    current.Total30400300100000 += (Decimal)current.cta_30400300102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300201000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300201000;
                current.Total30400300201000 = 0;
                if (current.cta_30400300201010 != null)
                    current.Total30400300201000 += (Decimal)current.cta_30400300201010;
                if (current.cta_30400300201020 != null)
                    current.Total30400300201000 += (Decimal)current.cta_30400300201020;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300202000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300202000;
                current.Total30400300202000 = 0;
                if (current.cta_30400300202010 != null)
                    current.Total30400300202000 += (Decimal)current.cta_30400300202010;
                if (current.cta_30400300202020 != null)
                    current.Total30400300202000 += (Decimal)current.cta_30400300202020;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000;
                current.Total30400300200000 = 0;
                if (current.cta_30400300201000 != null && current.cta_30400300201000.Total30400300201000 != 0)
                    current.Total30400300200000 += (Decimal)current.cta_30400300201000.Total30400300201000;
                if (current.cta_30400300202000 != null && current.cta_30400300202000.Total30400300202000 != 0)
                    current.Total30400300200000 += (Decimal)current.cta_30400300202000.Total30400300202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000;
                current.Total30400300000000 = 0;
                if (current.cta_30400300100000 != null && current.cta_30400300100000.Total30400300100000 != 0)
                    current.Total30400300000000 += (Decimal)current.cta_30400300100000.Total30400300100000;
                if (current.cta_30400300200000 != null && current.cta_30400300200000.Total30400300200000 != 0)
                    current.Total30400300000000 += (Decimal)current.cta_30400300200000.Total30400300200000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500100000;
                current.Total30400500100000 = 0;
                if (current.cta_30400500101000 != null)
                    current.Total30400500100000 += (Decimal)current.cta_30400500101000;
                if (current.cta_30400500102000 != null)
                    current.Total30400500100000 += (Decimal)current.cta_30400500102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500200000;
                current.Total30400500200000 = 0;
                if (current.cta_30400500201000 != null)
                    current.Total30400500200000 += (Decimal)current.cta_30400500201000;
                if (current.cta_30400500202000 != null)
                    current.Total30400500200000 += (Decimal)current.cta_30400500202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500300000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500300000;
                current.Total30400500300000 = 0;
                if (current.cta_30400500301000 != null)
                    current.Total30400500300000 += (Decimal)current.cta_30400500301000;
                if (current.cta_30400500302000 != null)
                    current.Total30400500300000 += (Decimal)current.cta_30400500302000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500500000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500500000;
                current.Total30400500500000 = 0;
                if (current.cta_30400500501000 != null)
                    current.Total30400500500000 += (Decimal)current.cta_30400500501000;
                if (current.cta_30400500502000 != null)
                    current.Total30400500500000 += (Decimal)current.cta_30400500502000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null && modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000;
                current.Total30400500000000 = 0;
                if (current.cta_30400500100000 != null && current.cta_30400500100000.Total30400500100000 != 0)
                    current.Total30400500000000 += (Decimal)current.cta_30400500100000.Total30400500100000;
                if (current.cta_30400500200000 != null && current.cta_30400500200000.Total30400500200000 != 0)
                    current.Total30400500000000 += (Decimal)current.cta_30400500200000.Total30400500200000;
                if (current.cta_30400500300000 != null && current.cta_30400500300000.Total30400500300000 != 0)
                    current.Total30400500000000 += (Decimal)current.cta_30400500300000.Total30400500300000;
                if (current.cta_30400500500000 != null && current.cta_30400500500000.Total30400500500000 != 0)
                    current.Total30400500000000 += (Decimal)current.cta_30400500500000.Total30400500500000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30400000000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30400000000000;
                current.Total30400000000000 = 0;
                if (current.cta_30400100000000 != null && current.cta_30400100000000.Total30400100000000 != 0)
                    current.Total30400000000000 += (Decimal)current.cta_30400100000000.Total30400100000000;
                if (current.cta_30400200000000 != null && current.cta_30400200000000.Total30400200000000 != 0)
                    current.Total30400000000000 += (Decimal)current.cta_30400200000000.Total30400200000000;
                if (current.cta_30400300000000 != null && current.cta_30400300000000.Total30400300000000 != 0)
                    current.Total30400000000000 += (Decimal)current.cta_30400300000000.Total30400300000000;
                if (current.cta_30400500000000 != null && current.cta_30400500000000.Total30400500000000 != 0)
                    current.Total30400000000000 += (Decimal)current.cta_30400500000000.Total30400500000000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30500000000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000;
                current.Total30500100101000 = 0;
                if (current.cta_30500100101010 != null)
                    current.Total30500100101000 += (Decimal)current.cta_30500100101010;
                if (current.cta_30500100101020 != null)
                    current.Total30500100101000 += (Decimal)current.cta_30500100101020;
                if (current.cta_30500100101030 != null)
                    current.Total30500100101000 += (Decimal)current.cta_30500100101030;
                if (current.cta_30500100101040 != null)
                    current.Total30500100101000 += (Decimal)current.cta_30500100101040;
                if (current.cta_30500100101050 != null)
                    current.Total30500100101000 += (Decimal)current.cta_30500100101050;
                if (current.cta_30500100101060 != null)
                    current.Total30500100101000 += (Decimal)current.cta_30500100101060;
                if (current.cta_30500100101990 != null)
                    current.Total30500100101000 += (Decimal)current.cta_30500100101990;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30500000000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000;
                current.Total30500100102000 = 0;
                if (current.cta_30500100102010 != null)
                    current.Total30500100102000 += (Decimal)current.cta_30500100102010;
                if (current.cta_30500100102020 != null)
                    current.Total30500100102000 += (Decimal)current.cta_30500100102020;
                if (current.cta_30500100102030 != null)
                    current.Total30500100102000 += (Decimal)current.cta_30500100102030;
                if (current.cta_30500100102040 != null)
                    current.Total30500100102000 += (Decimal)current.cta_30500100102040;
                if (current.cta_30500100102050 != null)
                    current.Total30500100102000 += (Decimal)current.cta_30500100102050;
                if (current.cta_30500100102060 != null)
                    current.Total30500100102000 += (Decimal)current.cta_30500100102060;
                if (current.cta_30500100102990 != null)
                    current.Total30500100102000 += (Decimal)current.cta_30500100102990;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30500000000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000;
                current.Total30500100100000 = 0;
                if (current.cta_30500100101000 != null && current.cta_30500100101000.Total30500100101000 != 0)
                    current.Total30500100100000 += (Decimal)current.cta_30500100101000.Total30500100101000;
                if (current.cta_30500100102000 != null && current.cta_30500100102000.Total30500100102000 != 0)
                    current.Total30500100100000 += (Decimal)current.cta_30500100102000.Total30500100102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30500000000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100200000;
                current.Total30500100200000 = 0;
                if (current.cta_30500100201000 != null)
                    current.Total30500100200000 += (Decimal)current.cta_30500100201000;
                if (current.cta_30500100202000 != null)
                    current.Total30500100200000 += (Decimal)current.cta_30500100202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30500000000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000;
                current.Total30500100000000 = 0;
                if (current.cta_30500100100000 != null && current.cta_30500100100000.Total30500100100000 != 0)
                    current.Total30500100000000 += (Decimal)current.cta_30500100100000.Total30500100100000;
                if (current.cta_30500100200000 != null && current.cta_30500100200000.Total30500100200000 != 0)
                    current.Total30500100000000 += (Decimal)current.cta_30500100200000.Total30500100200000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30500000000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200100000;
                current.Total30500200100000 = 0;
                if (current.cta_30500200101000 != null)
                    current.Total30500200100000 += (Decimal)current.cta_30500200101000;
                if (current.cta_30500200102000 != null)
                    current.Total30500200100000 += (Decimal)current.cta_30500200102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30500000000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200200000;
                current.Total30500200200000 = 0;
                if (current.cta_30500200201000 != null)
                    current.Total30500200200000 += (Decimal)current.cta_30500200201000;
                if (current.cta_30500200202000 != null)
                    current.Total30500200200000 += (Decimal)current.cta_30500200202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30500000000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200300000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200300000;
                current.Total30500200300000 = 0;
                if (current.cta_30500200301000 != null)
                    current.Total30500200300000 += (Decimal)current.cta_30500200301000;
                if (current.cta_30500200302000 != null)
                    current.Total30500200300000 += (Decimal)current.cta_30500200302000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30500000000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200400000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200400000;
                current.Total30500200400000 = 0;
                if (current.cta_30500200401000 != null)
                    current.Total30500200400000 += (Decimal)current.cta_30500200401000;
                if (current.cta_30500200402000 != null)
                    current.Total30500200400000 += (Decimal)current.cta_30500200402000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30500000000000 != null && modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000;
                current.Total30500200000000 = 0;
                if (current.cta_30500200100000 != null && current.cta_30500200100000.Total30500200100000 != 0)
                    current.Total30500200000000 += (Decimal)current.cta_30500200100000.Total30500200100000;
                if (current.cta_30500200200000 != null && current.cta_30500200200000.Total30500200200000 != 0)
                    current.Total30500200000000 += (Decimal)current.cta_30500200200000.Total30500200200000;
                if (current.cta_30500200300000 != null && current.cta_30500200300000.Total30500200300000 != 0)
                    current.Total30500200000000 += (Decimal)current.cta_30500200300000.Total30500200300000;
                if (current.cta_30500200400000 != null && current.cta_30500200400000.Total30500200400000 != 0)
                    current.Total30500200000000 += (Decimal)current.cta_30500200400000.Total30500200400000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30500000000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30500000000000;
                current.Total30500000000000 = 0;
                if (current.cta_30500100000000 != null && current.cta_30500100000000.Total30500100000000 != 0)
                    current.Total30500000000000 += (Decimal)current.cta_30500100000000.Total30500100000000;
                if (current.cta_30500200000000 != null && current.cta_30500200000000.Total30500200000000 != 0)
                    current.Total30500000000000 += (Decimal)current.cta_30500200000000.Total30500200000000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30600000000000 != null && modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000 != null && modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000.cta_30600100100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000.cta_30600100100000;
                current.Total30600100100000 = 0;
                if (current.cta_30600100101000 != null)
                    current.Total30600100100000 += (Decimal)current.cta_30600100101000;
                if (current.cta_30600100102000 != null)
                    current.Total30600100100000 += (Decimal)current.cta_30600100102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30600000000000 != null && modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000;
                current.Total30600100000000 = 0;
                if (current.cta_30600100100000 != null && current.cta_30600100100000.Total30600100100000 != 0)
                    current.Total30600100000000 += (Decimal)current.cta_30600100100000.Total30600100100000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30600000000000 != null && modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000 != null && modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000.cta_30600200100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000.cta_30600200100000;
                current.Total30600200100000 = 0;
                if (current.cta_30600200101000 != null)
                    current.Total30600200100000 += (Decimal)current.cta_30600200101000;
                if (current.cta_30600200102000 != null)
                    current.Total30600200100000 += (Decimal)current.cta_30600200102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30600000000000 != null && modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000;
                current.Total30600200000000 = 0;
                if (current.cta_30600200100000 != null && current.cta_30600200100000.Total30600200100000 != 0)
                    current.Total30600200000000 += (Decimal)current.cta_30600200100000.Total30600200100000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30600000000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30600000000000;
                current.Total30600000000000 = 0;
                if (current.cta_30600100000000 != null && current.cta_30600100000000.Total30600100000000 != 0)
                    current.Total30600000000000 += (Decimal)current.cta_30600100000000.Total30600100000000;
                if (current.cta_30600200000000 != null && current.cta_30600200000000.Total30600200000000 != 0)
                    current.Total30600000000000 += (Decimal)current.cta_30600200000000.Total30600200000000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30700000000000 != null && modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 != null && modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100100000;
                current.Total30700100100000 = 0;
                if (current.cta_30700100101000 != null)
                    current.Total30700100100000 += (Decimal)current.cta_30700100101000;
                if (current.cta_30700100102000 != null)
                    current.Total30700100100000 += (Decimal)current.cta_30700100102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30700000000000 != null && modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 != null && modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100200000;
                current.Total30700100200000 = 0;
                if (current.cta_30700100201000 != null)
                    current.Total30700100200000 += (Decimal)current.cta_30700100201000;
                if (current.cta_30700100202000 != null)
                    current.Total30700100200000 += (Decimal)current.cta_30700100202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30700000000000 != null && modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 != null && modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100300000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100300000;
                current.Total30700100300000 = 0;
                if (current.cta_30700100301000 != null)
                    current.Total30700100300000 += (Decimal)current.cta_30700100301000;
                if (current.cta_30700100302000 != null)
                    current.Total30700100300000 += (Decimal)current.cta_30700100302000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30700000000000 != null && modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 != null && modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100400000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100400000;
                current.Total30700100400000 = 0;
                if (current.cta_30700100401000 != null)
                    current.Total30700100400000 += (Decimal)current.cta_30700100401000;
                if (current.cta_30700100402000 != null)
                    current.Total30700100400000 += (Decimal)current.cta_30700100402000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30700000000000 != null && modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000;
                current.Total30700100000000 = 0;
                if (current.cta_30700100100000 != null && current.cta_30700100100000.Total30700100100000 != 0)
                    current.Total30700100000000 += (Decimal)current.cta_30700100100000.Total30700100100000;
                if (current.cta_30700100200000 != null && current.cta_30700100200000.Total30700100200000 != 0)
                    current.Total30700100000000 += (Decimal)current.cta_30700100200000.Total30700100200000;
                if (current.cta_30700100300000 != null && current.cta_30700100300000.Total30700100300000 != 0)
                    current.Total30700100000000 += (Decimal)current.cta_30700100300000.Total30700100300000;
                if (current.cta_30700100400000 != null && current.cta_30700100400000.Total30700100400000 != 0)
                    current.Total30700100000000 += (Decimal)current.cta_30700100400000.Total30700100400000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30700000000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30700000000000;
                current.Total30700000000000 = 0;
                if (current.cta_30700100000000 != null && current.cta_30700100000000.Total30700100000000 != 0)
                    current.Total30700000000000 += (Decimal)current.cta_30700100000000.Total30700100000000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30800000000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200100000;
                current.Total30800200100000 = 0;
                if (current.cta_30800200101000 != null)
                    current.Total30800200100000 += (Decimal)current.cta_30800200101000;
                if (current.cta_30800200102000 != null)
                    current.Total30800200100000 += (Decimal)current.cta_30800200102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30800000000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200200000;
                current.Total30800200200000 = 0;
                if (current.cta_30800200201000 != null)
                    current.Total30800200200000 += (Decimal)current.cta_30800200201000;
                if (current.cta_30800200202000 != null)
                    current.Total30800200200000 += (Decimal)current.cta_30800200202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30800000000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200300000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200300000;
                current.Total30800200300000 = 0;
                if (current.cta_30800200301000 != null)
                    current.Total30800200300000 += (Decimal)current.cta_30800200301000;
                if (current.cta_30800200302000 != null)
                    current.Total30800200300000 += (Decimal)current.cta_30800200302000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30800000000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200400000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200400000;
                current.Total30800200400000 = 0;
                if (current.cta_30800200401000 != null)
                    current.Total30800200400000 += (Decimal)current.cta_30800200401000;
                if (current.cta_30800200402000 != null)
                    current.Total30800200400000 += (Decimal)current.cta_30800200402000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30800000000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000;
                current.Total30800200000000 = 0;
                if (current.cta_30800200100000 != null && current.cta_30800200100000.Total30800200100000 != 0)
                    current.Total30800200000000 += (Decimal)current.cta_30800200100000.Total30800200100000;
                if (current.cta_30800200200000 != null && current.cta_30800200200000.Total30800200200000 != 0)
                    current.Total30800200000000 += (Decimal)current.cta_30800200200000.Total30800200200000;
                if (current.cta_30800200300000 != null && current.cta_30800200300000.Total30800200300000 != 0)
                    current.Total30800200000000 += (Decimal)current.cta_30800200300000.Total30800200300000;
                if (current.cta_30800200400000 != null && current.cta_30800200400000.Total30800200400000 != 0)
                    current.Total30800200000000 += (Decimal)current.cta_30800200400000.Total30800200400000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30800000000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300100000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300100000;
                current.Total30800300100000 = 0;
                if (current.cta_30800300101000 != null)
                    current.Total30800300100000 += (Decimal)current.cta_30800300101000;
                if (current.cta_30800300102000 != null)
                    current.Total30800300100000 += (Decimal)current.cta_30800300102000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30800000000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300200000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300200000;
                current.Total30800300200000 = 0;
                if (current.cta_30800300201000 != null)
                    current.Total30800300200000 += (Decimal)current.cta_30800300201000;
                if (current.cta_30800300202000 != null)
                    current.Total30800300200000 += (Decimal)current.cta_30800300202000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30800000000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300300000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300300000;
                current.Total30800300300000 = 0;
                if (current.cta_30800300301000 != null)
                    current.Total30800300300000 += (Decimal)current.cta_30800300301000;
                if (current.cta_30800300302000 != null)
                    current.Total30800300300000 += (Decimal)current.cta_30800300302000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30800000000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300400000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300400000;
                current.Total30800300400000 = 0;
                if (current.cta_30800300401000 != null)
                    current.Total30800300400000 += (Decimal)current.cta_30800300401000;
                if (current.cta_30800300402000 != null)
                    current.Total30800300400000 += (Decimal)current.cta_30800300402000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30800000000000 != null && modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000;
                current.Total30800300000000 = 0;
                if (current.cta_30800300100000 != null && current.cta_30800300100000.Total30800300100000 != 0)
                    current.Total30800300000000 += (Decimal)current.cta_30800300100000.Total30800300100000;
                if (current.cta_30800300200000 != null && current.cta_30800300200000.Total30800300200000 != 0)
                    current.Total30800300000000 += (Decimal)current.cta_30800300200000.Total30800300200000;
                if (current.cta_30800300300000 != null && current.cta_30800300300000.Total30800300300000 != 0)
                    current.Total30800300000000 += (Decimal)current.cta_30800300300000.Total30800300300000;
                if (current.cta_30800300400000 != null && current.cta_30800300400000.Total30800300400000 != 0)
                    current.Total30800300000000 += (Decimal)current.cta_30800300400000.Total30800300400000;
            }
            if (modelo.cta_30000000000000 != null && modelo.cta_30000000000000.cta_30800000000000 != null)
            {
                var current = modelo.cta_30000000000000.cta_30800000000000;
                current.Total30800000000000 = 0;
                if (current.cta_30800200000000 != null && current.cta_30800200000000.Total30800200000000 != 0)
                    current.Total30800000000000 += (Decimal)current.cta_30800200000000.Total30800200000000;
                if (current.cta_30800300000000 != null && current.cta_30800300000000.Total30800300000000 != 0)
                    current.Total30800000000000 += (Decimal)current.cta_30800300000000.Total30800300000000;
            }
            if (modelo.cta_30000000000000 != null)
            {
                var current = modelo.cta_30000000000000;
                current.Total30000000000000 = 0;
                if (current.cta_30100000000000 != null && current.cta_30100000000000.Total30100000000000 != 0)
                    current.Total30000000000000 += (Decimal)current.cta_30100000000000.Total30100000000000;
                if (current.cta_30200000000000 != null && current.cta_30200000000000.Total30200000000000 != 0)
                    current.Total30000000000000 += (Decimal)current.cta_30200000000000.Total30200000000000;
                if (current.cta_30300000000000 != null && current.cta_30300000000000.Total30300000000000 != 0)
                    current.Total30000000000000 += (Decimal)current.cta_30300000000000.Total30300000000000;
                if (current.cta_30400000000000 != null && current.cta_30400000000000.Total30400000000000 != 0)
                    current.Total30000000000000 += (Decimal)current.cta_30400000000000.Total30400000000000;
                if (current.cta_30500000000000 != null && current.cta_30500000000000.Total30500000000000 != 0)
                    current.Total30000000000000 += (Decimal)current.cta_30500000000000.Total30500000000000;
                if (current.cta_30600000000000 != null && current.cta_30600000000000.Total30600000000000 != 0)
                    current.Total30000000000000 += (Decimal)current.cta_30600000000000.Total30600000000000;
                if (current.cta_30700000000000 != null && current.cta_30700000000000.Total30700000000000 != 0)
                    current.Total30000000000000 += (Decimal)current.cta_30700000000000.Total30700000000000;
                if (current.cta_30800000000000 != null && current.cta_30800000000000.Total30800000000000 != 0)
                    current.Total30000000000000 += (Decimal)current.cta_30800000000000.Total30800000000000;
            }
        }

    }
}
