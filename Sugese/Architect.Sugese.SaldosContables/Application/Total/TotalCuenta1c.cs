using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.Sugese.SaldosContables.Domain.Application.Total
{
    internal class TotalCuenta1c
    {
        public static void Mapper(string account, Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModelo modelo, System.Nullable<decimal> value, bool specified)
        {
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000.cta_10400201001000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000.cta_10400201001000;
                current.Total10400201001000 = 0;
                if (current.cta_10400201001070 != null)
                    current.Total10400201001000 += (Decimal)current.cta_10400201001070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000.cta_10400201002000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000.cta_10400201002000;
                current.Total10400201002000 = 0;
                if (current.cta_10400201002070 != null)
                    current.Total10400201002000 += (Decimal)current.cta_10400201002070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400201000000;
                current.Total10400201000000 = 0;
                if (current.cta_10400201001000 != null && current.cta_10400201001000.Total10400201001000 != 0)
                    current.Total10400201000000 += (Decimal)current.cta_10400201001000.Total10400201001000;
                if (current.cta_10400201002000 != null && current.cta_10400201002000.Total10400201002000 != 0)
                    current.Total10400201000000 += (Decimal)current.cta_10400201002000.Total10400201002000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400209900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000.cta_10400209900000;
                current.Total10400209900000 = 0;
                if (current.cta_10400209901000 != null)
                    current.Total10400209900000 += (Decimal)current.cta_10400209901000;
                if (current.cta_10400209902000 != null)
                    current.Total10400209900000 += (Decimal)current.cta_10400209902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400200000000;
                current.Total10400200000000 = 0;
                if (current.cta_10400201000000 != null && current.cta_10400201000000.Total10400201000000 != 0)
                    current.Total10400200000000 += (Decimal)current.cta_10400201000000.Total10400201000000;
                if (current.cta_10400209900000 != null && current.cta_10400209900000.Total10400209900000 != 0)
                    current.Total10400200000000 += (Decimal)current.cta_10400209900000.Total10400209900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000.cta_10400600101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000.cta_10400600101000;
                current.Total10400600101000 = 0;
                if (current.cta_10400600101010 != null)
                    current.Total10400600101000 += (Decimal)current.cta_10400600101010;
                if (current.cta_10400600101020 != null)
                    current.Total10400600101000 += (Decimal)current.cta_10400600101020;
                if (current.cta_10400600101030 != null)
                    current.Total10400600101000 += (Decimal)current.cta_10400600101030;
                if (current.cta_10400600101990 != null)
                    current.Total10400600101000 += (Decimal)current.cta_10400600101990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000.cta_10400600102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000.cta_10400600102000;
                current.Total10400600102000 = 0;
                if (current.cta_10400600102010 != null)
                    current.Total10400600102000 += (Decimal)current.cta_10400600102010;
                if (current.cta_10400600102020 != null)
                    current.Total10400600102000 += (Decimal)current.cta_10400600102020;
                if (current.cta_10400600102030 != null)
                    current.Total10400600102000 += (Decimal)current.cta_10400600102030;
                if (current.cta_10400600102990 != null)
                    current.Total10400600102000 += (Decimal)current.cta_10400600102990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000.cta_10400600100000;
                current.Total10400600100000 = 0;
                if (current.cta_10400600101000 != null && current.cta_10400600101000.Total10400600101000 != 0)
                    current.Total10400600100000 += (Decimal)current.cta_10400600101000.Total10400600101000;
                if (current.cta_10400600102000 != null && current.cta_10400600102000.Total10400600102000 != 0)
                    current.Total10400600100000 += (Decimal)current.cta_10400600102000.Total10400600102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400600000000;
                current.Total10400600000000 = 0;
                if (current.cta_10400600100000 != null && current.cta_10400600100000.Total10400600100000 != 0)
                    current.Total10400600000000 += (Decimal)current.cta_10400600100000.Total10400600100000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700100000;
                current.Total10400700100000 = 0;
                if (current.cta_10400700101000 != null)
                    current.Total10400700100000 += (Decimal)current.cta_10400700101000;
                if (current.cta_10400700102000 != null)
                    current.Total10400700100000 += (Decimal)current.cta_10400700102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700200000;
                current.Total10400700200000 = 0;
                if (current.cta_10400700201000 != null)
                    current.Total10400700200000 += (Decimal)current.cta_10400700201000;
                if (current.cta_10400700202000 != null)
                    current.Total10400700200000 += (Decimal)current.cta_10400700202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000.cta_10400700301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000.cta_10400700301000;
                current.Total10400700301000 = 0;
                if (current.cta_10400700301010 != null)
                    current.Total10400700301000 += (Decimal)current.cta_10400700301010;
                if (current.cta_10400700301020 != null)
                    current.Total10400700301000 += (Decimal)current.cta_10400700301020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000.cta_10400700302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000.cta_10400700302000;
                current.Total10400700302000 = 0;
                if (current.cta_10400700302010 != null)
                    current.Total10400700302000 += (Decimal)current.cta_10400700302010;
                if (current.cta_10400700302020 != null)
                    current.Total10400700302000 += (Decimal)current.cta_10400700302020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700300000;
                current.Total10400700300000 = 0;
                if (current.cta_10400700301000 != null && current.cta_10400700301000.Total10400700301000 != 0)
                    current.Total10400700300000 += (Decimal)current.cta_10400700301000.Total10400700301000;
                if (current.cta_10400700302000 != null && current.cta_10400700302000.Total10400700302000 != 0)
                    current.Total10400700300000 += (Decimal)current.cta_10400700302000.Total10400700302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000.cta_10400700400000;
                current.Total10400700400000 = 0;
                if (current.cta_10400700401000 != null)
                    current.Total10400700400000 += (Decimal)current.cta_10400700401000;
                if (current.cta_10400700402000 != null)
                    current.Total10400700400000 += (Decimal)current.cta_10400700402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400700000000;
                current.Total10400700000000 = 0;
                if (current.cta_10400700100000 != null && current.cta_10400700100000.Total10400700100000 != 0)
                    current.Total10400700000000 += (Decimal)current.cta_10400700100000.Total10400700100000;
                if (current.cta_10400700200000 != null && current.cta_10400700200000.Total10400700200000 != 0)
                    current.Total10400700000000 += (Decimal)current.cta_10400700200000.Total10400700200000;
                if (current.cta_10400700300000 != null && current.cta_10400700300000.Total10400700300000 != 0)
                    current.Total10400700000000 += (Decimal)current.cta_10400700300000.Total10400700300000;
                if (current.cta_10400700400000 != null && current.cta_10400700400000.Total10400700400000 != 0)
                    current.Total10400700000000 += (Decimal)current.cta_10400700400000.Total10400700400000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800100000;
                current.Total10400800100000 = 0;
                if (current.cta_10400800101000 != null)
                    current.Total10400800100000 += (Decimal)current.cta_10400800101000;
                if (current.cta_10400800102000 != null)
                    current.Total10400800100000 += (Decimal)current.cta_10400800102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800200000;
                current.Total10400800200000 = 0;
                if (current.cta_10400800201000 != null)
                    current.Total10400800200000 += (Decimal)current.cta_10400800201000;
                if (current.cta_10400800202000 != null)
                    current.Total10400800200000 += (Decimal)current.cta_10400800202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800400000;
                current.Total10400800400000 = 0;
                if (current.cta_10400800401000 != null)
                    current.Total10400800400000 += (Decimal)current.cta_10400800401000;
                if (current.cta_10400800402000 != null)
                    current.Total10400800400000 += (Decimal)current.cta_10400800402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800700000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400800700000;
                current.Total10400800700000 = 0;
                if (current.cta_10400800701000 != null)
                    current.Total10400800700000 += (Decimal)current.cta_10400800701000;
                if (current.cta_10400800702000 != null)
                    current.Total10400800700000 += (Decimal)current.cta_10400800702000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000.cta_10400801001000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000.cta_10400801001000;
                current.Total10400801001000 = 0;
                if (current.cta_10400801001010 != null)
                    current.Total10400801001000 += (Decimal)current.cta_10400801001010;
                if (current.cta_10400801001990 != null)
                    current.Total10400801001000 += (Decimal)current.cta_10400801001990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000.cta_10400801002000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000.cta_10400801002000;
                current.Total10400801002000 = 0;
                if (current.cta_10400801002010 != null)
                    current.Total10400801002000 += (Decimal)current.cta_10400801002010;
                if (current.cta_10400801002990 != null)
                    current.Total10400801002000 += (Decimal)current.cta_10400801002990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801000000;
                current.Total10400801000000 = 0;
                if (current.cta_10400801001000 != null && current.cta_10400801001000.Total10400801001000 != 0)
                    current.Total10400801000000 += (Decimal)current.cta_10400801001000.Total10400801001000;
                if (current.cta_10400801002000 != null && current.cta_10400801002000.Total10400801002000 != 0)
                    current.Total10400801000000 += (Decimal)current.cta_10400801002000.Total10400801002000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400801200000;
                current.Total10400801200000 = 0;
                if (current.cta_10400801201000 != null)
                    current.Total10400801200000 += (Decimal)current.cta_10400801201000;
                if (current.cta_10400801202000 != null)
                    current.Total10400801200000 += (Decimal)current.cta_10400801202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400809900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000.cta_10400809900000;
                current.Total10400809900000 = 0;
                if (current.cta_10400809901000 != null)
                    current.Total10400809900000 += (Decimal)current.cta_10400809901000;
                if (current.cta_10400809902000 != null)
                    current.Total10400809900000 += (Decimal)current.cta_10400809902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400800000000;
                current.Total10400800000000 = 0;
                if (current.cta_10400800100000 != null && current.cta_10400800100000.Total10400800100000 != 0)
                    current.Total10400800000000 += (Decimal)current.cta_10400800100000.Total10400800100000;
                if (current.cta_10400800200000 != null && current.cta_10400800200000.Total10400800200000 != 0)
                    current.Total10400800000000 += (Decimal)current.cta_10400800200000.Total10400800200000;
                if (current.cta_10400800400000 != null && current.cta_10400800400000.Total10400800400000 != 0)
                    current.Total10400800000000 += (Decimal)current.cta_10400800400000.Total10400800400000;
                if (current.cta_10400800700000 != null && current.cta_10400800700000.Total10400800700000 != 0)
                    current.Total10400800000000 += (Decimal)current.cta_10400800700000.Total10400800700000;
                if (current.cta_10400801000000 != null && current.cta_10400801000000.Total10400801000000 != 0)
                    current.Total10400800000000 += (Decimal)current.cta_10400801000000.Total10400801000000;
                if (current.cta_10400801200000 != null && current.cta_10400801200000.Total10400801200000 != 0)
                    current.Total10400800000000 += (Decimal)current.cta_10400801200000.Total10400801200000;
                if (current.cta_10400809900000 != null && current.cta_10400809900000.Total10400809900000 != 0)
                    current.Total10400800000000 += (Decimal)current.cta_10400809900000.Total10400809900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000.cta_10400900300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000.cta_10400900300000;
                current.Total10400900300000 = 0;
                if (current.cta_10400900301000 != null)
                    current.Total10400900300000 += (Decimal)current.cta_10400900301000;
                if (current.cta_10400900302000 != null)
                    current.Total10400900300000 += (Decimal)current.cta_10400900302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000.cta_10400900400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000.cta_10400900400000;
                current.Total10400900400000 = 0;
                if (current.cta_10400900401000 != null)
                    current.Total10400900400000 += (Decimal)current.cta_10400900401000;
                if (current.cta_10400900402000 != null)
                    current.Total10400900400000 += (Decimal)current.cta_10400900402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10400900000000;
                current.Total10400900000000 = 0;
                if (current.cta_10400900300000 != null && current.cta_10400900300000.Total10400900300000 != 0)
                    current.Total10400900000000 += (Decimal)current.cta_10400900300000.Total10400900300000;
                if (current.cta_10400900400000 != null && current.cta_10400900400000.Total10400900400000 != 0)
                    current.Total10400900000000 += (Decimal)current.cta_10400900400000.Total10400900400000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000200000;
                current.Total10401000200000 = 0;
                if (current.cta_10401000201000 != null)
                    current.Total10401000200000 += (Decimal)current.cta_10401000201000;
                if (current.cta_10401000202000 != null)
                    current.Total10401000200000 += (Decimal)current.cta_10401000202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000500000;
                current.Total10401000500000 = 0;
                if (current.cta_10401000501000 != null)
                    current.Total10401000500000 += (Decimal)current.cta_10401000501000;
                if (current.cta_10401000502000 != null)
                    current.Total10401000500000 += (Decimal)current.cta_10401000502000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000700000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000700000;
                current.Total10401000700000 = 0;
                if (current.cta_10401000701000 != null)
                    current.Total10401000700000 += (Decimal)current.cta_10401000701000;
                if (current.cta_10401000702000 != null)
                    current.Total10401000700000 += (Decimal)current.cta_10401000702000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000.cta_10401000900000;
                current.Total10401000900000 = 0;
                if (current.cta_10401000901000 != null)
                    current.Total10401000900000 += (Decimal)current.cta_10401000901000;
                if (current.cta_10401000902000 != null)
                    current.Total10401000900000 += (Decimal)current.cta_10401000902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null && modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000.cta_10401000000000;
                current.Total10401000000000 = 0;
                if (current.cta_10401000200000 != null && current.cta_10401000200000.Total10401000200000 != 0)
                    current.Total10401000000000 += (Decimal)current.cta_10401000200000.Total10401000200000;
                if (current.cta_10401000500000 != null && current.cta_10401000500000.Total10401000500000 != 0)
                    current.Total10401000000000 += (Decimal)current.cta_10401000500000.Total10401000500000;
                if (current.cta_10401000700000 != null && current.cta_10401000700000.Total10401000700000 != 0)
                    current.Total10401000000000 += (Decimal)current.cta_10401000700000.Total10401000700000;
                if (current.cta_10401000900000 != null && current.cta_10401000900000.Total10401000900000 != 0)
                    current.Total10401000000000 += (Decimal)current.cta_10401000900000.Total10401000900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10400000000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10400000000000;
                current.Total10400000000000 = 0;
                if (current.cta_10400200000000 != null && current.cta_10400200000000.Total10400200000000 != 0)
                    current.Total10400000000000 += (Decimal)current.cta_10400200000000.Total10400200000000;
                if (current.cta_10400600000000 != null && current.cta_10400600000000.Total10400600000000 != 0)
                    current.Total10400000000000 += (Decimal)current.cta_10400600000000.Total10400600000000;
                if (current.cta_10400700000000 != null && current.cta_10400700000000.Total10400700000000 != 0)
                    current.Total10400000000000 += (Decimal)current.cta_10400700000000.Total10400700000000;
                if (current.cta_10400800000000 != null && current.cta_10400800000000.Total10400800000000 != 0)
                    current.Total10400000000000 += (Decimal)current.cta_10400800000000.Total10400800000000;
                if (current.cta_10400900000000 != null && current.cta_10400900000000.Total10400900000000 != 0)
                    current.Total10400000000000 += (Decimal)current.cta_10400900000000.Total10400900000000;
                if (current.cta_10401000000000 != null && current.cta_10401000000000.Total10401000000000 != 0)
                    current.Total10400000000000 += (Decimal)current.cta_10401000000000.Total10401000000000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100100000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100100000.cta_10500100101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100100000.cta_10500100101000;
                current.Total10500100101000 = 0;
                if (current.cta_10500100101010 != null)
                    current.Total10500100101000 += (Decimal)current.cta_10500100101010;
                if (current.cta_10500100101020 != null)
                    current.Total10500100101000 += (Decimal)current.cta_10500100101020;
                if (current.cta_10500100101030 != null)
                    current.Total10500100101000 += (Decimal)current.cta_10500100101030;
                if (current.cta_10500100101040 != null)
                    current.Total10500100101000 += (Decimal)current.cta_10500100101040;
                if (current.cta_10500100101050 != null)
                    current.Total10500100101000 += (Decimal)current.cta_10500100101050;
                if (current.cta_10500100101060 != null)
                    current.Total10500100101000 += (Decimal)current.cta_10500100101060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100100000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100100000.cta_10500100102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100100000.cta_10500100102000;
                current.Total10500100102000 = 0;
                if (current.cta_10500100102010 != null)
                    current.Total10500100102000 += (Decimal)current.cta_10500100102010;
                if (current.cta_10500100102020 != null)
                    current.Total10500100102000 += (Decimal)current.cta_10500100102020;
                if (current.cta_10500100102030 != null)
                    current.Total10500100102000 += (Decimal)current.cta_10500100102030;
                if (current.cta_10500100102040 != null)
                    current.Total10500100102000 += (Decimal)current.cta_10500100102040;
                if (current.cta_10500100102050 != null)
                    current.Total10500100102000 += (Decimal)current.cta_10500100102050;
                if (current.cta_10500100102060 != null)
                    current.Total10500100102000 += (Decimal)current.cta_10500100102060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100100000;
                current.Total10500100100000 = 0;
                if (current.cta_10500100101000 != null && current.cta_10500100101000.Total10500100101000 != 0)
                    current.Total10500100100000 += (Decimal)current.cta_10500100101000.Total10500100101000;
                if (current.cta_10500100102000 != null && current.cta_10500100102000.Total10500100102000 != 0)
                    current.Total10500100100000 += (Decimal)current.cta_10500100102000.Total10500100102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100200000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100200000.cta_10500100201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100200000.cta_10500100201000;
                current.Total10500100201000 = 0;
                if (current.cta_10500100201010 != null)
                    current.Total10500100201000 += (Decimal)current.cta_10500100201010;
                if (current.cta_10500100201020 != null)
                    current.Total10500100201000 += (Decimal)current.cta_10500100201020;
                if (current.cta_10500100201030 != null)
                    current.Total10500100201000 += (Decimal)current.cta_10500100201030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100200000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100200000.cta_10500100202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100200000.cta_10500100202000;
                current.Total10500100202000 = 0;
                if (current.cta_10500100202010 != null)
                    current.Total10500100202000 += (Decimal)current.cta_10500100202010;
                if (current.cta_10500100202020 != null)
                    current.Total10500100202000 += (Decimal)current.cta_10500100202020;
                if (current.cta_10500100202030 != null)
                    current.Total10500100202000 += (Decimal)current.cta_10500100202030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100200000;
                current.Total10500100200000 = 0;
                if (current.cta_10500100201000 != null && current.cta_10500100201000.Total10500100201000 != 0)
                    current.Total10500100200000 += (Decimal)current.cta_10500100201000.Total10500100201000;
                if (current.cta_10500100202000 != null && current.cta_10500100202000.Total10500100202000 != 0)
                    current.Total10500100200000 += (Decimal)current.cta_10500100202000.Total10500100202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100300000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100300000.cta_10500100301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100300000.cta_10500100301000;
                current.Total10500100301000 = 0;
                if (current.cta_10500100301010 != null)
                    current.Total10500100301000 += (Decimal)current.cta_10500100301010;
                if (current.cta_10500100301020 != null)
                    current.Total10500100301000 += (Decimal)current.cta_10500100301020;
                if (current.cta_10500100301030 != null)
                    current.Total10500100301000 += (Decimal)current.cta_10500100301030;
                if (current.cta_10500100301040 != null)
                    current.Total10500100301000 += (Decimal)current.cta_10500100301040;
                if (current.cta_10500100301050 != null)
                    current.Total10500100301000 += (Decimal)current.cta_10500100301050;
                if (current.cta_10500100301060 != null)
                    current.Total10500100301000 += (Decimal)current.cta_10500100301060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100300000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100300000.cta_10500100302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100300000.cta_10500100302000;
                current.Total10500100302000 = 0;
                if (current.cta_10500100302010 != null)
                    current.Total10500100302000 += (Decimal)current.cta_10500100302010;
                if (current.cta_10500100302020 != null)
                    current.Total10500100302000 += (Decimal)current.cta_10500100302020;
                if (current.cta_10500100302030 != null)
                    current.Total10500100302000 += (Decimal)current.cta_10500100302030;
                if (current.cta_10500100302040 != null)
                    current.Total10500100302000 += (Decimal)current.cta_10500100302040;
                if (current.cta_10500100302050 != null)
                    current.Total10500100302000 += (Decimal)current.cta_10500100302050;
                if (current.cta_10500100302060 != null)
                    current.Total10500100302000 += (Decimal)current.cta_10500100302060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100300000;
                current.Total10500100300000 = 0;
                if (current.cta_10500100301000 != null && current.cta_10500100301000.Total10500100301000 != 0)
                    current.Total10500100300000 += (Decimal)current.cta_10500100301000.Total10500100301000;
                if (current.cta_10500100302000 != null && current.cta_10500100302000.Total10500100302000 != 0)
                    current.Total10500100300000 += (Decimal)current.cta_10500100302000.Total10500100302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100400000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100400000.cta_10500100401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100400000.cta_10500100401000;
                current.Total10500100401000 = 0;
                if (current.cta_10500100401010 != null)
                    current.Total10500100401000 += (Decimal)current.cta_10500100401010;
                if (current.cta_10500100401020 != null)
                    current.Total10500100401000 += (Decimal)current.cta_10500100401020;
                if (current.cta_10500100401030 != null)
                    current.Total10500100401000 += (Decimal)current.cta_10500100401030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100400000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100400000.cta_10500100402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100400000.cta_10500100402000;
                current.Total10500100402000 = 0;
                if (current.cta_10500100402010 != null)
                    current.Total10500100402000 += (Decimal)current.cta_10500100402010;
                if (current.cta_10500100402020 != null)
                    current.Total10500100402000 += (Decimal)current.cta_10500100402020;
                if (current.cta_10500100402030 != null)
                    current.Total10500100402000 += (Decimal)current.cta_10500100402030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100400000;
                current.Total10500100400000 = 0;
                if (current.cta_10500100401000 != null && current.cta_10500100401000.Total10500100401000 != 0)
                    current.Total10500100400000 += (Decimal)current.cta_10500100401000.Total10500100401000;
                if (current.cta_10500100402000 != null && current.cta_10500100402000.Total10500100402000 != 0)
                    current.Total10500100400000 += (Decimal)current.cta_10500100402000.Total10500100402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100500000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100500000.cta_10500100501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100500000.cta_10500100501000;
                current.Total10500100501000 = 0;
                if (current.cta_10500100501010 != null)
                    current.Total10500100501000 += (Decimal)current.cta_10500100501010;
                if (current.cta_10500100501020 != null)
                    current.Total10500100501000 += (Decimal)current.cta_10500100501020;
                if (current.cta_10500100501030 != null)
                    current.Total10500100501000 += (Decimal)current.cta_10500100501030;
                if (current.cta_10500100501040 != null)
                    current.Total10500100501000 += (Decimal)current.cta_10500100501040;
                if (current.cta_10500100501050 != null)
                    current.Total10500100501000 += (Decimal)current.cta_10500100501050;
                if (current.cta_10500100501060 != null)
                    current.Total10500100501000 += (Decimal)current.cta_10500100501060;
                if (current.cta_10500100501070 != null)
                    current.Total10500100501000 += (Decimal)current.cta_10500100501070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100500000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100500000.cta_10500100502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100500000.cta_10500100502000;
                current.Total10500100502000 = 0;
                if (current.cta_10500100502010 != null)
                    current.Total10500100502000 += (Decimal)current.cta_10500100502010;
                if (current.cta_10500100502020 != null)
                    current.Total10500100502000 += (Decimal)current.cta_10500100502020;
                if (current.cta_10500100502030 != null)
                    current.Total10500100502000 += (Decimal)current.cta_10500100502030;
                if (current.cta_10500100502040 != null)
                    current.Total10500100502000 += (Decimal)current.cta_10500100502040;
                if (current.cta_10500100502050 != null)
                    current.Total10500100502000 += (Decimal)current.cta_10500100502050;
                if (current.cta_10500100502060 != null)
                    current.Total10500100502000 += (Decimal)current.cta_10500100502060;
                if (current.cta_10500100502070 != null)
                    current.Total10500100502000 += (Decimal)current.cta_10500100502070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100500000;
                current.Total10500100500000 = 0;
                if (current.cta_10500100501000 != null && current.cta_10500100501000.Total10500100501000 != 0)
                    current.Total10500100500000 += (Decimal)current.cta_10500100501000.Total10500100501000;
                if (current.cta_10500100502000 != null && current.cta_10500100502000.Total10500100502000 != 0)
                    current.Total10500100500000 += (Decimal)current.cta_10500100502000.Total10500100502000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100600000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100600000.cta_10500100601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100600000.cta_10500100601000;
                current.Total10500100601000 = 0;
                if (current.cta_10500100601010 != null)
                    current.Total10500100601000 += (Decimal)current.cta_10500100601010;
                if (current.cta_10500100601020 != null)
                    current.Total10500100601000 += (Decimal)current.cta_10500100601020;
                if (current.cta_10500100601030 != null)
                    current.Total10500100601000 += (Decimal)current.cta_10500100601030;
                if (current.cta_10500100601040 != null)
                    current.Total10500100601000 += (Decimal)current.cta_10500100601040;
                if (current.cta_10500100601050 != null)
                    current.Total10500100601000 += (Decimal)current.cta_10500100601050;
                if (current.cta_10500100601060 != null)
                    current.Total10500100601000 += (Decimal)current.cta_10500100601060;
                if (current.cta_10500100601070 != null)
                    current.Total10500100601000 += (Decimal)current.cta_10500100601070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100600000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100600000.cta_10500100602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100600000.cta_10500100602000;
                current.Total10500100602000 = 0;
                if (current.cta_10500100602010 != null)
                    current.Total10500100602000 += (Decimal)current.cta_10500100602010;
                if (current.cta_10500100602020 != null)
                    current.Total10500100602000 += (Decimal)current.cta_10500100602020;
                if (current.cta_10500100602030 != null)
                    current.Total10500100602000 += (Decimal)current.cta_10500100602030;
                if (current.cta_10500100602040 != null)
                    current.Total10500100602000 += (Decimal)current.cta_10500100602040;
                if (current.cta_10500100602050 != null)
                    current.Total10500100602000 += (Decimal)current.cta_10500100602050;
                if (current.cta_10500100602060 != null)
                    current.Total10500100602000 += (Decimal)current.cta_10500100602060;
                if (current.cta_10500100602070 != null)
                    current.Total10500100602000 += (Decimal)current.cta_10500100602070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000.cta_10500100600000;
                current.Total10500100600000 = 0;
                if (current.cta_10500100601000 != null && current.cta_10500100601000.Total10500100601000 != 0)
                    current.Total10500100600000 += (Decimal)current.cta_10500100601000.Total10500100601000;
                if (current.cta_10500100602000 != null && current.cta_10500100602000.Total10500100602000 != 0)
                    current.Total10500100600000 += (Decimal)current.cta_10500100602000.Total10500100602000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500100000000;
                current.Total10500100000000 = 0;
                if (current.cta_10500100100000 != null && current.cta_10500100100000.Total10500100100000 != 0)
                    current.Total10500100000000 += (Decimal)current.cta_10500100100000.Total10500100100000;
                if (current.cta_10500100200000 != null && current.cta_10500100200000.Total10500100200000 != 0)
                    current.Total10500100000000 += (Decimal)current.cta_10500100200000.Total10500100200000;
                if (current.cta_10500100300000 != null && current.cta_10500100300000.Total10500100300000 != 0)
                    current.Total10500100000000 += (Decimal)current.cta_10500100300000.Total10500100300000;
                if (current.cta_10500100400000 != null && current.cta_10500100400000.Total10500100400000 != 0)
                    current.Total10500100000000 += (Decimal)current.cta_10500100400000.Total10500100400000;
                if (current.cta_10500100500000 != null && current.cta_10500100500000.Total10500100500000 != 0)
                    current.Total10500100000000 += (Decimal)current.cta_10500100500000.Total10500100500000;
                if (current.cta_10500100600000 != null && current.cta_10500100600000.Total10500100600000 != 0)
                    current.Total10500100000000 += (Decimal)current.cta_10500100600000.Total10500100600000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200100000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200100000.cta_10500200101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200100000.cta_10500200101000;
                current.Total10500200101000 = 0;
                if (current.cta_10500200101010 != null)
                    current.Total10500200101000 += (Decimal)current.cta_10500200101010;
                if (current.cta_10500200101020 != null)
                    current.Total10500200101000 += (Decimal)current.cta_10500200101020;
                if (current.cta_10500200101030 != null)
                    current.Total10500200101000 += (Decimal)current.cta_10500200101030;
                if (current.cta_10500200101040 != null)
                    current.Total10500200101000 += (Decimal)current.cta_10500200101040;
                if (current.cta_10500200101050 != null)
                    current.Total10500200101000 += (Decimal)current.cta_10500200101050;
                if (current.cta_10500200101060 != null)
                    current.Total10500200101000 += (Decimal)current.cta_10500200101060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200100000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200100000.cta_10500200102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200100000.cta_10500200102000;
                current.Total10500200102000 = 0;
                if (current.cta_10500200102010 != null)
                    current.Total10500200102000 += (Decimal)current.cta_10500200102010;
                if (current.cta_10500200102020 != null)
                    current.Total10500200102000 += (Decimal)current.cta_10500200102020;
                if (current.cta_10500200102030 != null)
                    current.Total10500200102000 += (Decimal)current.cta_10500200102030;
                if (current.cta_10500200102040 != null)
                    current.Total10500200102000 += (Decimal)current.cta_10500200102040;
                if (current.cta_10500200102050 != null)
                    current.Total10500200102000 += (Decimal)current.cta_10500200102050;
                if (current.cta_10500200102060 != null)
                    current.Total10500200102000 += (Decimal)current.cta_10500200102060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200100000;
                current.Total10500200100000 = 0;
                if (current.cta_10500200101000 != null && current.cta_10500200101000.Total10500200101000 != 0)
                    current.Total10500200100000 += (Decimal)current.cta_10500200101000.Total10500200101000;
                if (current.cta_10500200102000 != null && current.cta_10500200102000.Total10500200102000 != 0)
                    current.Total10500200100000 += (Decimal)current.cta_10500200102000.Total10500200102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200200000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200200000.cta_10500200201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200200000.cta_10500200201000;
                current.Total10500200201000 = 0;
                if (current.cta_10500200201010 != null)
                    current.Total10500200201000 += (Decimal)current.cta_10500200201010;
                if (current.cta_10500200201020 != null)
                    current.Total10500200201000 += (Decimal)current.cta_10500200201020;
                if (current.cta_10500200201030 != null)
                    current.Total10500200201000 += (Decimal)current.cta_10500200201030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200200000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200200000.cta_10500200202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200200000.cta_10500200202000;
                current.Total10500200202000 = 0;
                if (current.cta_10500200202010 != null)
                    current.Total10500200202000 += (Decimal)current.cta_10500200202010;
                if (current.cta_10500200202020 != null)
                    current.Total10500200202000 += (Decimal)current.cta_10500200202020;
                if (current.cta_10500200202030 != null)
                    current.Total10500200202000 += (Decimal)current.cta_10500200202030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200200000;
                current.Total10500200200000 = 0;
                if (current.cta_10500200201000 != null && current.cta_10500200201000.Total10500200201000 != 0)
                    current.Total10500200200000 += (Decimal)current.cta_10500200201000.Total10500200201000;
                if (current.cta_10500200202000 != null && current.cta_10500200202000.Total10500200202000 != 0)
                    current.Total10500200200000 += (Decimal)current.cta_10500200202000.Total10500200202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200300000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200300000.cta_10500200301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200300000.cta_10500200301000;
                current.Total10500200301000 = 0;
                if (current.cta_10500200301010 != null)
                    current.Total10500200301000 += (Decimal)current.cta_10500200301010;
                if (current.cta_10500200301020 != null)
                    current.Total10500200301000 += (Decimal)current.cta_10500200301020;
                if (current.cta_10500200301030 != null)
                    current.Total10500200301000 += (Decimal)current.cta_10500200301030;
                if (current.cta_10500200301040 != null)
                    current.Total10500200301000 += (Decimal)current.cta_10500200301040;
                if (current.cta_10500200301050 != null)
                    current.Total10500200301000 += (Decimal)current.cta_10500200301050;
                if (current.cta_10500200301060 != null)
                    current.Total10500200301000 += (Decimal)current.cta_10500200301060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200300000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200300000.cta_10500200302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200300000.cta_10500200302000;
                current.Total10500200302000 = 0;
                if (current.cta_10500200302010 != null)
                    current.Total10500200302000 += (Decimal)current.cta_10500200302010;
                if (current.cta_10500200302020 != null)
                    current.Total10500200302000 += (Decimal)current.cta_10500200302020;
                if (current.cta_10500200302030 != null)
                    current.Total10500200302000 += (Decimal)current.cta_10500200302030;
                if (current.cta_10500200302040 != null)
                    current.Total10500200302000 += (Decimal)current.cta_10500200302040;
                if (current.cta_10500200302050 != null)
                    current.Total10500200302000 += (Decimal)current.cta_10500200302050;
                if (current.cta_10500200302060 != null)
                    current.Total10500200302000 += (Decimal)current.cta_10500200302060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200300000;
                current.Total10500200300000 = 0;
                if (current.cta_10500200301000 != null && current.cta_10500200301000.Total10500200301000 != 0)
                    current.Total10500200300000 += (Decimal)current.cta_10500200301000.Total10500200301000;
                if (current.cta_10500200302000 != null && current.cta_10500200302000.Total10500200302000 != 0)
                    current.Total10500200300000 += (Decimal)current.cta_10500200302000.Total10500200302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200400000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200400000.cta_10500200401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200400000.cta_10500200401000;
                current.Total10500200401000 = 0;
                if (current.cta_10500200401010 != null)
                    current.Total10500200401000 += (Decimal)current.cta_10500200401010;
                if (current.cta_10500200401020 != null)
                    current.Total10500200401000 += (Decimal)current.cta_10500200401020;
                if (current.cta_10500200401030 != null)
                    current.Total10500200401000 += (Decimal)current.cta_10500200401030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200400000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200400000.cta_10500200402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200400000.cta_10500200402000;
                current.Total10500200402000 = 0;
                if (current.cta_10500200402010 != null)
                    current.Total10500200402000 += (Decimal)current.cta_10500200402010;
                if (current.cta_10500200402020 != null)
                    current.Total10500200402000 += (Decimal)current.cta_10500200402020;
                if (current.cta_10500200402030 != null)
                    current.Total10500200402000 += (Decimal)current.cta_10500200402030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200400000;
                current.Total10500200400000 = 0;
                if (current.cta_10500200401000 != null && current.cta_10500200401000.Total10500200401000 != 0)
                    current.Total10500200400000 += (Decimal)current.cta_10500200401000.Total10500200401000;
                if (current.cta_10500200402000 != null && current.cta_10500200402000.Total10500200402000 != 0)
                    current.Total10500200400000 += (Decimal)current.cta_10500200402000.Total10500200402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200500000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200500000.cta_10500200501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200500000.cta_10500200501000;
                current.Total10500200501000 = 0;
                if (current.cta_10500200501010 != null)
                    current.Total10500200501000 += (Decimal)current.cta_10500200501010;
                if (current.cta_10500200501020 != null)
                    current.Total10500200501000 += (Decimal)current.cta_10500200501020;
                if (current.cta_10500200501030 != null)
                    current.Total10500200501000 += (Decimal)current.cta_10500200501030;
                if (current.cta_10500200501040 != null)
                    current.Total10500200501000 += (Decimal)current.cta_10500200501040;
                if (current.cta_10500200501050 != null)
                    current.Total10500200501000 += (Decimal)current.cta_10500200501050;
                if (current.cta_10500200501060 != null)
                    current.Total10500200501000 += (Decimal)current.cta_10500200501060;
                if (current.cta_10500200501070 != null)
                    current.Total10500200501000 += (Decimal)current.cta_10500200501070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200500000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200500000.cta_10500200502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200500000.cta_10500200502000;
                current.Total10500200502000 = 0;
                if (current.cta_10500200502010 != null)
                    current.Total10500200502000 += (Decimal)current.cta_10500200502010;
                if (current.cta_10500200502020 != null)
                    current.Total10500200502000 += (Decimal)current.cta_10500200502020;
                if (current.cta_10500200502030 != null)
                    current.Total10500200502000 += (Decimal)current.cta_10500200502030;
                if (current.cta_10500200502040 != null)
                    current.Total10500200502000 += (Decimal)current.cta_10500200502040;
                if (current.cta_10500200502050 != null)
                    current.Total10500200502000 += (Decimal)current.cta_10500200502050;
                if (current.cta_10500200502060 != null)
                    current.Total10500200502000 += (Decimal)current.cta_10500200502060;
                if (current.cta_10500200502070 != null)
                    current.Total10500200502000 += (Decimal)current.cta_10500200502070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200500000;
                current.Total10500200500000 = 0;
                if (current.cta_10500200501000 != null && current.cta_10500200501000.Total10500200501000 != 0)
                    current.Total10500200500000 += (Decimal)current.cta_10500200501000.Total10500200501000;
                if (current.cta_10500200502000 != null && current.cta_10500200502000.Total10500200502000 != 0)
                    current.Total10500200500000 += (Decimal)current.cta_10500200502000.Total10500200502000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200600000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200600000.cta_10500200601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200600000.cta_10500200601000;
                current.Total10500200601000 = 0;
                if (current.cta_10500200601010 != null)
                    current.Total10500200601000 += (Decimal)current.cta_10500200601010;
                if (current.cta_10500200601020 != null)
                    current.Total10500200601000 += (Decimal)current.cta_10500200601020;
                if (current.cta_10500200601030 != null)
                    current.Total10500200601000 += (Decimal)current.cta_10500200601030;
                if (current.cta_10500200601040 != null)
                    current.Total10500200601000 += (Decimal)current.cta_10500200601040;
                if (current.cta_10500200601050 != null)
                    current.Total10500200601000 += (Decimal)current.cta_10500200601050;
                if (current.cta_10500200601060 != null)
                    current.Total10500200601000 += (Decimal)current.cta_10500200601060;
                if (current.cta_10500200601070 != null)
                    current.Total10500200601000 += (Decimal)current.cta_10500200601070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200600000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200600000.cta_10500200602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200600000.cta_10500200602000;
                current.Total10500200602000 = 0;
                if (current.cta_10500200602010 != null)
                    current.Total10500200602000 += (Decimal)current.cta_10500200602010;
                if (current.cta_10500200602020 != null)
                    current.Total10500200602000 += (Decimal)current.cta_10500200602020;
                if (current.cta_10500200602030 != null)
                    current.Total10500200602000 += (Decimal)current.cta_10500200602030;
                if (current.cta_10500200602040 != null)
                    current.Total10500200602000 += (Decimal)current.cta_10500200602040;
                if (current.cta_10500200602050 != null)
                    current.Total10500200602000 += (Decimal)current.cta_10500200602050;
                if (current.cta_10500200602060 != null)
                    current.Total10500200602000 += (Decimal)current.cta_10500200602060;
                if (current.cta_10500200602070 != null)
                    current.Total10500200602000 += (Decimal)current.cta_10500200602070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000.cta_10500200600000;
                current.Total10500200600000 = 0;
                if (current.cta_10500200601000 != null && current.cta_10500200601000.Total10500200601000 != 0)
                    current.Total10500200600000 += (Decimal)current.cta_10500200601000.Total10500200601000;
                if (current.cta_10500200602000 != null && current.cta_10500200602000.Total10500200602000 != 0)
                    current.Total10500200600000 += (Decimal)current.cta_10500200602000.Total10500200602000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500200000000;
                current.Total10500200000000 = 0;
                if (current.cta_10500200100000 != null && current.cta_10500200100000.Total10500200100000 != 0)
                    current.Total10500200000000 += (Decimal)current.cta_10500200100000.Total10500200100000;
                if (current.cta_10500200200000 != null && current.cta_10500200200000.Total10500200200000 != 0)
                    current.Total10500200000000 += (Decimal)current.cta_10500200200000.Total10500200200000;
                if (current.cta_10500200300000 != null && current.cta_10500200300000.Total10500200300000 != 0)
                    current.Total10500200000000 += (Decimal)current.cta_10500200300000.Total10500200300000;
                if (current.cta_10500200400000 != null && current.cta_10500200400000.Total10500200400000 != 0)
                    current.Total10500200000000 += (Decimal)current.cta_10500200400000.Total10500200400000;
                if (current.cta_10500200500000 != null && current.cta_10500200500000.Total10500200500000 != 0)
                    current.Total10500200000000 += (Decimal)current.cta_10500200500000.Total10500200500000;
                if (current.cta_10500200600000 != null && current.cta_10500200600000.Total10500200600000 != 0)
                    current.Total10500200000000 += (Decimal)current.cta_10500200600000.Total10500200600000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300100000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300100000.cta_10500300101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300100000.cta_10500300101000;
                current.Total10500300101000 = 0;
                if (current.cta_10500300101010 != null)
                    current.Total10500300101000 += (Decimal)current.cta_10500300101010;
                if (current.cta_10500300101020 != null)
                    current.Total10500300101000 += (Decimal)current.cta_10500300101020;
                if (current.cta_10500300101030 != null)
                    current.Total10500300101000 += (Decimal)current.cta_10500300101030;
                if (current.cta_10500300101040 != null)
                    current.Total10500300101000 += (Decimal)current.cta_10500300101040;
                if (current.cta_10500300101050 != null)
                    current.Total10500300101000 += (Decimal)current.cta_10500300101050;
                if (current.cta_10500300101060 != null)
                    current.Total10500300101000 += (Decimal)current.cta_10500300101060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300100000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300100000.cta_10500300102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300100000.cta_10500300102000;
                current.Total10500300102000 = 0;
                if (current.cta_10500300102010 != null)
                    current.Total10500300102000 += (Decimal)current.cta_10500300102010;
                if (current.cta_10500300102020 != null)
                    current.Total10500300102000 += (Decimal)current.cta_10500300102020;
                if (current.cta_10500300102030 != null)
                    current.Total10500300102000 += (Decimal)current.cta_10500300102030;
                if (current.cta_10500300102040 != null)
                    current.Total10500300102000 += (Decimal)current.cta_10500300102040;
                if (current.cta_10500300102050 != null)
                    current.Total10500300102000 += (Decimal)current.cta_10500300102050;
                if (current.cta_10500300102060 != null)
                    current.Total10500300102000 += (Decimal)current.cta_10500300102060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300100000;
                current.Total10500300100000 = 0;
                if (current.cta_10500300101000 != null && current.cta_10500300101000.Total10500300101000 != 0)
                    current.Total10500300100000 += (Decimal)current.cta_10500300101000.Total10500300101000;
                if (current.cta_10500300102000 != null && current.cta_10500300102000.Total10500300102000 != 0)
                    current.Total10500300100000 += (Decimal)current.cta_10500300102000.Total10500300102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300200000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300200000.cta_10500300201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300200000.cta_10500300201000;
                current.Total10500300201000 = 0;
                if (current.cta_10500300201010 != null)
                    current.Total10500300201000 += (Decimal)current.cta_10500300201010;
                if (current.cta_10500300201020 != null)
                    current.Total10500300201000 += (Decimal)current.cta_10500300201020;
                if (current.cta_10500300201030 != null)
                    current.Total10500300201000 += (Decimal)current.cta_10500300201030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300200000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300200000.cta_10500300202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300200000.cta_10500300202000;
                current.Total10500300202000 = 0;
                if (current.cta_10500300202010 != null)
                    current.Total10500300202000 += (Decimal)current.cta_10500300202010;
                if (current.cta_10500300202020 != null)
                    current.Total10500300202000 += (Decimal)current.cta_10500300202020;
                if (current.cta_10500300202030 != null)
                    current.Total10500300202000 += (Decimal)current.cta_10500300202030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300200000;
                current.Total10500300200000 = 0;
                if (current.cta_10500300201000 != null && current.cta_10500300201000.Total10500300201000 != 0)
                    current.Total10500300200000 += (Decimal)current.cta_10500300201000.Total10500300201000;
                if (current.cta_10500300202000 != null && current.cta_10500300202000.Total10500300202000 != 0)
                    current.Total10500300200000 += (Decimal)current.cta_10500300202000.Total10500300202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300300000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300300000.cta_10500300301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300300000.cta_10500300301000;
                current.Total10500300301000 = 0;
                if (current.cta_10500300301010 != null)
                    current.Total10500300301000 += (Decimal)current.cta_10500300301010;
                if (current.cta_10500300301020 != null)
                    current.Total10500300301000 += (Decimal)current.cta_10500300301020;
                if (current.cta_10500300301030 != null)
                    current.Total10500300301000 += (Decimal)current.cta_10500300301030;
                if (current.cta_10500300301040 != null)
                    current.Total10500300301000 += (Decimal)current.cta_10500300301040;
                if (current.cta_10500300301050 != null)
                    current.Total10500300301000 += (Decimal)current.cta_10500300301050;
                if (current.cta_10500300301060 != null)
                    current.Total10500300301000 += (Decimal)current.cta_10500300301060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300300000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300300000.cta_10500300302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300300000.cta_10500300302000;
                current.Total10500300302000 = 0;
                if (current.cta_10500300302010 != null)
                    current.Total10500300302000 += (Decimal)current.cta_10500300302010;
                if (current.cta_10500300302020 != null)
                    current.Total10500300302000 += (Decimal)current.cta_10500300302020;
                if (current.cta_10500300302030 != null)
                    current.Total10500300302000 += (Decimal)current.cta_10500300302030;
                if (current.cta_10500300302040 != null)
                    current.Total10500300302000 += (Decimal)current.cta_10500300302040;
                if (current.cta_10500300302050 != null)
                    current.Total10500300302000 += (Decimal)current.cta_10500300302050;
                if (current.cta_10500300302060 != null)
                    current.Total10500300302000 += (Decimal)current.cta_10500300302060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300300000;
                current.Total10500300300000 = 0;
                if (current.cta_10500300301000 != null && current.cta_10500300301000.Total10500300301000 != 0)
                    current.Total10500300300000 += (Decimal)current.cta_10500300301000.Total10500300301000;
                if (current.cta_10500300302000 != null && current.cta_10500300302000.Total10500300302000 != 0)
                    current.Total10500300300000 += (Decimal)current.cta_10500300302000.Total10500300302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300400000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300400000.cta_10500300401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300400000.cta_10500300401000;
                current.Total10500300401000 = 0;
                if (current.cta_10500300401010 != null)
                    current.Total10500300401000 += (Decimal)current.cta_10500300401010;
                if (current.cta_10500300401020 != null)
                    current.Total10500300401000 += (Decimal)current.cta_10500300401020;
                if (current.cta_10500300401030 != null)
                    current.Total10500300401000 += (Decimal)current.cta_10500300401030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300400000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300400000.cta_10500300402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300400000.cta_10500300402000;
                current.Total10500300402000 = 0;
                if (current.cta_10500300402010 != null)
                    current.Total10500300402000 += (Decimal)current.cta_10500300402010;
                if (current.cta_10500300402020 != null)
                    current.Total10500300402000 += (Decimal)current.cta_10500300402020;
                if (current.cta_10500300402030 != null)
                    current.Total10500300402000 += (Decimal)current.cta_10500300402030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300400000;
                current.Total10500300400000 = 0;
                if (current.cta_10500300401000 != null && current.cta_10500300401000.Total10500300401000 != 0)
                    current.Total10500300400000 += (Decimal)current.cta_10500300401000.Total10500300401000;
                if (current.cta_10500300402000 != null && current.cta_10500300402000.Total10500300402000 != 0)
                    current.Total10500300400000 += (Decimal)current.cta_10500300402000.Total10500300402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300500000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300500000.cta_10500300501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300500000.cta_10500300501000;
                current.Total10500300501000 = 0;
                if (current.cta_10500300501010 != null)
                    current.Total10500300501000 += (Decimal)current.cta_10500300501010;
                if (current.cta_10500300501020 != null)
                    current.Total10500300501000 += (Decimal)current.cta_10500300501020;
                if (current.cta_10500300501030 != null)
                    current.Total10500300501000 += (Decimal)current.cta_10500300501030;
                if (current.cta_10500300501040 != null)
                    current.Total10500300501000 += (Decimal)current.cta_10500300501040;
                if (current.cta_10500300501050 != null)
                    current.Total10500300501000 += (Decimal)current.cta_10500300501050;
                if (current.cta_10500300501060 != null)
                    current.Total10500300501000 += (Decimal)current.cta_10500300501060;
                if (current.cta_10500300501070 != null)
                    current.Total10500300501000 += (Decimal)current.cta_10500300501070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300500000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300500000.cta_10500300502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300500000.cta_10500300502000;
                current.Total10500300502000 = 0;
                if (current.cta_10500300502010 != null)
                    current.Total10500300502000 += (Decimal)current.cta_10500300502010;
                if (current.cta_10500300502020 != null)
                    current.Total10500300502000 += (Decimal)current.cta_10500300502020;
                if (current.cta_10500300502030 != null)
                    current.Total10500300502000 += (Decimal)current.cta_10500300502030;
                if (current.cta_10500300502040 != null)
                    current.Total10500300502000 += (Decimal)current.cta_10500300502040;
                if (current.cta_10500300502050 != null)
                    current.Total10500300502000 += (Decimal)current.cta_10500300502050;
                if (current.cta_10500300502060 != null)
                    current.Total10500300502000 += (Decimal)current.cta_10500300502060;
                if (current.cta_10500300502070 != null)
                    current.Total10500300502000 += (Decimal)current.cta_10500300502070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300500000;
                current.Total10500300500000 = 0;
                if (current.cta_10500300501000 != null && current.cta_10500300501000.Total10500300501000 != 0)
                    current.Total10500300500000 += (Decimal)current.cta_10500300501000.Total10500300501000;
                if (current.cta_10500300502000 != null && current.cta_10500300502000.Total10500300502000 != 0)
                    current.Total10500300500000 += (Decimal)current.cta_10500300502000.Total10500300502000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300600000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300600000.cta_10500300601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300600000.cta_10500300601000;
                current.Total10500300601000 = 0;
                if (current.cta_10500300601010 != null)
                    current.Total10500300601000 += (Decimal)current.cta_10500300601010;
                if (current.cta_10500300601020 != null)
                    current.Total10500300601000 += (Decimal)current.cta_10500300601020;
                if (current.cta_10500300601030 != null)
                    current.Total10500300601000 += (Decimal)current.cta_10500300601030;
                if (current.cta_10500300601040 != null)
                    current.Total10500300601000 += (Decimal)current.cta_10500300601040;
                if (current.cta_10500300601050 != null)
                    current.Total10500300601000 += (Decimal)current.cta_10500300601050;
                if (current.cta_10500300601060 != null)
                    current.Total10500300601000 += (Decimal)current.cta_10500300601060;
                if (current.cta_10500300601070 != null)
                    current.Total10500300601000 += (Decimal)current.cta_10500300601070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300600000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300600000.cta_10500300602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300600000.cta_10500300602000;
                current.Total10500300602000 = 0;
                if (current.cta_10500300602010 != null)
                    current.Total10500300602000 += (Decimal)current.cta_10500300602010;
                if (current.cta_10500300602020 != null)
                    current.Total10500300602000 += (Decimal)current.cta_10500300602020;
                if (current.cta_10500300602030 != null)
                    current.Total10500300602000 += (Decimal)current.cta_10500300602030;
                if (current.cta_10500300602040 != null)
                    current.Total10500300602000 += (Decimal)current.cta_10500300602040;
                if (current.cta_10500300602050 != null)
                    current.Total10500300602000 += (Decimal)current.cta_10500300602050;
                if (current.cta_10500300602060 != null)
                    current.Total10500300602000 += (Decimal)current.cta_10500300602060;
                if (current.cta_10500300602070 != null)
                    current.Total10500300602000 += (Decimal)current.cta_10500300602070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000.cta_10500300600000;
                current.Total10500300600000 = 0;
                if (current.cta_10500300601000 != null && current.cta_10500300601000.Total10500300601000 != 0)
                    current.Total10500300600000 += (Decimal)current.cta_10500300601000.Total10500300601000;
                if (current.cta_10500300602000 != null && current.cta_10500300602000.Total10500300602000 != 0)
                    current.Total10500300600000 += (Decimal)current.cta_10500300602000.Total10500300602000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500300000000;
                current.Total10500300000000 = 0;
                if (current.cta_10500300100000 != null && current.cta_10500300100000.Total10500300100000 != 0)
                    current.Total10500300000000 += (Decimal)current.cta_10500300100000.Total10500300100000;
                if (current.cta_10500300200000 != null && current.cta_10500300200000.Total10500300200000 != 0)
                    current.Total10500300000000 += (Decimal)current.cta_10500300200000.Total10500300200000;
                if (current.cta_10500300300000 != null && current.cta_10500300300000.Total10500300300000 != 0)
                    current.Total10500300000000 += (Decimal)current.cta_10500300300000.Total10500300300000;
                if (current.cta_10500300400000 != null && current.cta_10500300400000.Total10500300400000 != 0)
                    current.Total10500300000000 += (Decimal)current.cta_10500300400000.Total10500300400000;
                if (current.cta_10500300500000 != null && current.cta_10500300500000.Total10500300500000 != 0)
                    current.Total10500300000000 += (Decimal)current.cta_10500300500000.Total10500300500000;
                if (current.cta_10500300600000 != null && current.cta_10500300600000.Total10500300600000 != 0)
                    current.Total10500300000000 += (Decimal)current.cta_10500300600000.Total10500300600000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400100000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400100000.cta_10500400101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400100000.cta_10500400101000;
                current.Total10500400101000 = 0;
                if (current.cta_10500400101010 != null)
                    current.Total10500400101000 += (Decimal)current.cta_10500400101010;
                if (current.cta_10500400101020 != null)
                    current.Total10500400101000 += (Decimal)current.cta_10500400101020;
                if (current.cta_10500400101030 != null)
                    current.Total10500400101000 += (Decimal)current.cta_10500400101030;
                if (current.cta_10500400101040 != null)
                    current.Total10500400101000 += (Decimal)current.cta_10500400101040;
                if (current.cta_10500400101050 != null)
                    current.Total10500400101000 += (Decimal)current.cta_10500400101050;
                if (current.cta_10500400101060 != null)
                    current.Total10500400101000 += (Decimal)current.cta_10500400101060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400100000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400100000.cta_10500400102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400100000.cta_10500400102000;
                current.Total10500400102000 = 0;
                if (current.cta_10500400102010 != null)
                    current.Total10500400102000 += (Decimal)current.cta_10500400102010;
                if (current.cta_10500400102020 != null)
                    current.Total10500400102000 += (Decimal)current.cta_10500400102020;
                if (current.cta_10500400102030 != null)
                    current.Total10500400102000 += (Decimal)current.cta_10500400102030;
                if (current.cta_10500400102040 != null)
                    current.Total10500400102000 += (Decimal)current.cta_10500400102040;
                if (current.cta_10500400102050 != null)
                    current.Total10500400102000 += (Decimal)current.cta_10500400102050;
                if (current.cta_10500400102060 != null)
                    current.Total10500400102000 += (Decimal)current.cta_10500400102060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400100000;
                current.Total10500400100000 = 0;
                if (current.cta_10500400101000 != null && current.cta_10500400101000.Total10500400101000 != 0)
                    current.Total10500400100000 += (Decimal)current.cta_10500400101000.Total10500400101000;
                if (current.cta_10500400102000 != null && current.cta_10500400102000.Total10500400102000 != 0)
                    current.Total10500400100000 += (Decimal)current.cta_10500400102000.Total10500400102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400200000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400200000.cta_10500400201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400200000.cta_10500400201000;
                current.Total10500400201000 = 0;
                if (current.cta_10500400201010 != null)
                    current.Total10500400201000 += (Decimal)current.cta_10500400201010;
                if (current.cta_10500400201020 != null)
                    current.Total10500400201000 += (Decimal)current.cta_10500400201020;
                if (current.cta_10500400201030 != null)
                    current.Total10500400201000 += (Decimal)current.cta_10500400201030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400200000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400200000.cta_10500400202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400200000.cta_10500400202000;
                current.Total10500400202000 = 0;
                if (current.cta_10500400202010 != null)
                    current.Total10500400202000 += (Decimal)current.cta_10500400202010;
                if (current.cta_10500400202020 != null)
                    current.Total10500400202000 += (Decimal)current.cta_10500400202020;
                if (current.cta_10500400202030 != null)
                    current.Total10500400202000 += (Decimal)current.cta_10500400202030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400200000;
                current.Total10500400200000 = 0;
                if (current.cta_10500400201000 != null && current.cta_10500400201000.Total10500400201000 != 0)
                    current.Total10500400200000 += (Decimal)current.cta_10500400201000.Total10500400201000;
                if (current.cta_10500400202000 != null && current.cta_10500400202000.Total10500400202000 != 0)
                    current.Total10500400200000 += (Decimal)current.cta_10500400202000.Total10500400202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400300000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400300000.cta_10500400301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400300000.cta_10500400301000;
                current.Total10500400301000 = 0;
                if (current.cta_10500400301010 != null)
                    current.Total10500400301000 += (Decimal)current.cta_10500400301010;
                if (current.cta_10500400301020 != null)
                    current.Total10500400301000 += (Decimal)current.cta_10500400301020;
                if (current.cta_10500400301030 != null)
                    current.Total10500400301000 += (Decimal)current.cta_10500400301030;
                if (current.cta_10500400301040 != null)
                    current.Total10500400301000 += (Decimal)current.cta_10500400301040;
                if (current.cta_10500400301050 != null)
                    current.Total10500400301000 += (Decimal)current.cta_10500400301050;
                if (current.cta_10500400301060 != null)
                    current.Total10500400301000 += (Decimal)current.cta_10500400301060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400300000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400300000.cta_10500400302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400300000.cta_10500400302000;
                current.Total10500400302000 = 0;
                if (current.cta_10500400302010 != null)
                    current.Total10500400302000 += (Decimal)current.cta_10500400302010;
                if (current.cta_10500400302020 != null)
                    current.Total10500400302000 += (Decimal)current.cta_10500400302020;
                if (current.cta_10500400302030 != null)
                    current.Total10500400302000 += (Decimal)current.cta_10500400302030;
                if (current.cta_10500400302040 != null)
                    current.Total10500400302000 += (Decimal)current.cta_10500400302040;
                if (current.cta_10500400302050 != null)
                    current.Total10500400302000 += (Decimal)current.cta_10500400302050;
                if (current.cta_10500400302060 != null)
                    current.Total10500400302000 += (Decimal)current.cta_10500400302060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400300000;
                current.Total10500400300000 = 0;
                if (current.cta_10500400301000 != null && current.cta_10500400301000.Total10500400301000 != 0)
                    current.Total10500400300000 += (Decimal)current.cta_10500400301000.Total10500400301000;
                if (current.cta_10500400302000 != null && current.cta_10500400302000.Total10500400302000 != 0)
                    current.Total10500400300000 += (Decimal)current.cta_10500400302000.Total10500400302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400400000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400400000.cta_10500400401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400400000.cta_10500400401000;
                current.Total10500400401000 = 0;
                if (current.cta_10500400401010 != null)
                    current.Total10500400401000 += (Decimal)current.cta_10500400401010;
                if (current.cta_10500400401020 != null)
                    current.Total10500400401000 += (Decimal)current.cta_10500400401020;
                if (current.cta_10500400401030 != null)
                    current.Total10500400401000 += (Decimal)current.cta_10500400401030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400400000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400400000.cta_10500400402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400400000.cta_10500400402000;
                current.Total10500400402000 = 0;
                if (current.cta_10500400402010 != null)
                    current.Total10500400402000 += (Decimal)current.cta_10500400402010;
                if (current.cta_10500400402020 != null)
                    current.Total10500400402000 += (Decimal)current.cta_10500400402020;
                if (current.cta_10500400402030 != null)
                    current.Total10500400402000 += (Decimal)current.cta_10500400402030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400400000;
                current.Total10500400400000 = 0;
                if (current.cta_10500400401000 != null && current.cta_10500400401000.Total10500400401000 != 0)
                    current.Total10500400400000 += (Decimal)current.cta_10500400401000.Total10500400401000;
                if (current.cta_10500400402000 != null && current.cta_10500400402000.Total10500400402000 != 0)
                    current.Total10500400400000 += (Decimal)current.cta_10500400402000.Total10500400402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400500000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400500000.cta_10500400501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400500000.cta_10500400501000;
                current.Total10500400501000 = 0;
                if (current.cta_10500400501010 != null)
                    current.Total10500400501000 += (Decimal)current.cta_10500400501010;
                if (current.cta_10500400501020 != null)
                    current.Total10500400501000 += (Decimal)current.cta_10500400501020;
                if (current.cta_10500400501030 != null)
                    current.Total10500400501000 += (Decimal)current.cta_10500400501030;
                if (current.cta_10500400501040 != null)
                    current.Total10500400501000 += (Decimal)current.cta_10500400501040;
                if (current.cta_10500400501050 != null)
                    current.Total10500400501000 += (Decimal)current.cta_10500400501050;
                if (current.cta_10500400501060 != null)
                    current.Total10500400501000 += (Decimal)current.cta_10500400501060;
                if (current.cta_10500400501070 != null)
                    current.Total10500400501000 += (Decimal)current.cta_10500400501070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400500000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400500000.cta_10500400502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400500000.cta_10500400502000;
                current.Total10500400502000 = 0;
                if (current.cta_10500400502010 != null)
                    current.Total10500400502000 += (Decimal)current.cta_10500400502010;
                if (current.cta_10500400502020 != null)
                    current.Total10500400502000 += (Decimal)current.cta_10500400502020;
                if (current.cta_10500400502030 != null)
                    current.Total10500400502000 += (Decimal)current.cta_10500400502030;
                if (current.cta_10500400502040 != null)
                    current.Total10500400502000 += (Decimal)current.cta_10500400502040;
                if (current.cta_10500400502050 != null)
                    current.Total10500400502000 += (Decimal)current.cta_10500400502050;
                if (current.cta_10500400502060 != null)
                    current.Total10500400502000 += (Decimal)current.cta_10500400502060;
                if (current.cta_10500400502070 != null)
                    current.Total10500400502000 += (Decimal)current.cta_10500400502070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400500000;
                current.Total10500400500000 = 0;
                if (current.cta_10500400501000 != null && current.cta_10500400501000.Total10500400501000 != 0)
                    current.Total10500400500000 += (Decimal)current.cta_10500400501000.Total10500400501000;
                if (current.cta_10500400502000 != null && current.cta_10500400502000.Total10500400502000 != 0)
                    current.Total10500400500000 += (Decimal)current.cta_10500400502000.Total10500400502000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400600000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400600000.cta_10500400601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400600000.cta_10500400601000;
                current.Total10500400601000 = 0;
                if (current.cta_10500400601010 != null)
                    current.Total10500400601000 += (Decimal)current.cta_10500400601010;
                if (current.cta_10500400601020 != null)
                    current.Total10500400601000 += (Decimal)current.cta_10500400601020;
                if (current.cta_10500400601030 != null)
                    current.Total10500400601000 += (Decimal)current.cta_10500400601030;
                if (current.cta_10500400601040 != null)
                    current.Total10500400601000 += (Decimal)current.cta_10500400601040;
                if (current.cta_10500400601050 != null)
                    current.Total10500400601000 += (Decimal)current.cta_10500400601050;
                if (current.cta_10500400601060 != null)
                    current.Total10500400601000 += (Decimal)current.cta_10500400601060;
                if (current.cta_10500400601070 != null)
                    current.Total10500400601000 += (Decimal)current.cta_10500400601070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400600000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400600000.cta_10500400602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400600000.cta_10500400602000;
                current.Total10500400602000 = 0;
                if (current.cta_10500400602010 != null)
                    current.Total10500400602000 += (Decimal)current.cta_10500400602010;
                if (current.cta_10500400602020 != null)
                    current.Total10500400602000 += (Decimal)current.cta_10500400602020;
                if (current.cta_10500400602030 != null)
                    current.Total10500400602000 += (Decimal)current.cta_10500400602030;
                if (current.cta_10500400602040 != null)
                    current.Total10500400602000 += (Decimal)current.cta_10500400602040;
                if (current.cta_10500400602050 != null)
                    current.Total10500400602000 += (Decimal)current.cta_10500400602050;
                if (current.cta_10500400602060 != null)
                    current.Total10500400602000 += (Decimal)current.cta_10500400602060;
                if (current.cta_10500400602070 != null)
                    current.Total10500400602000 += (Decimal)current.cta_10500400602070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000.cta_10500400600000;
                current.Total10500400600000 = 0;
                if (current.cta_10500400601000 != null && current.cta_10500400601000.Total10500400601000 != 0)
                    current.Total10500400600000 += (Decimal)current.cta_10500400601000.Total10500400601000;
                if (current.cta_10500400602000 != null && current.cta_10500400602000.Total10500400602000 != 0)
                    current.Total10500400600000 += (Decimal)current.cta_10500400602000.Total10500400602000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null && modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000.cta_10500400000000;
                current.Total10500400000000 = 0;
                if (current.cta_10500400100000 != null && current.cta_10500400100000.Total10500400100000 != 0)
                    current.Total10500400000000 += (Decimal)current.cta_10500400100000.Total10500400100000;
                if (current.cta_10500400200000 != null && current.cta_10500400200000.Total10500400200000 != 0)
                    current.Total10500400000000 += (Decimal)current.cta_10500400200000.Total10500400200000;
                if (current.cta_10500400300000 != null && current.cta_10500400300000.Total10500400300000 != 0)
                    current.Total10500400000000 += (Decimal)current.cta_10500400300000.Total10500400300000;
                if (current.cta_10500400400000 != null && current.cta_10500400400000.Total10500400400000 != 0)
                    current.Total10500400000000 += (Decimal)current.cta_10500400400000.Total10500400400000;
                if (current.cta_10500400500000 != null && current.cta_10500400500000.Total10500400500000 != 0)
                    current.Total10500400000000 += (Decimal)current.cta_10500400500000.Total10500400500000;
                if (current.cta_10500400600000 != null && current.cta_10500400600000.Total10500400600000 != 0)
                    current.Total10500400000000 += (Decimal)current.cta_10500400600000.Total10500400600000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10500000000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10500000000000;
                current.Total10500000000000 = 0;
                if (current.cta_10500100000000 != null && current.cta_10500100000000.Total10500100000000 != 0)
                    current.Total10500000000000 += (Decimal)current.cta_10500100000000.Total10500100000000;
                if (current.cta_10500200000000 != null && current.cta_10500200000000.Total10500200000000 != 0)
                    current.Total10500000000000 += (Decimal)current.cta_10500200000000.Total10500200000000;
                if (current.cta_10500300000000 != null && current.cta_10500300000000.Total10500300000000 != 0)
                    current.Total10500000000000 += (Decimal)current.cta_10500300000000.Total10500300000000;
                if (current.cta_10500400000000 != null && current.cta_10500400000000.Total10500400000000 != 0)
                    current.Total10500000000000 += (Decimal)current.cta_10500400000000.Total10500400000000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000.cta_10600100101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000.cta_10600100101000;
                current.Total10600100101000 = 0;
                if (current.cta_10600100101010 != null)
                    current.Total10600100101000 += (Decimal)current.cta_10600100101010;
                if (current.cta_10600100101020 != null)
                    current.Total10600100101000 += (Decimal)current.cta_10600100101020;
                if (current.cta_10600100101030 != null)
                    current.Total10600100101000 += (Decimal)current.cta_10600100101030;
                if (current.cta_10600100101040 != null)
                    current.Total10600100101000 += (Decimal)current.cta_10600100101040;
                if (current.cta_10600100101050 != null)
                    current.Total10600100101000 += (Decimal)current.cta_10600100101050;
                if (current.cta_10600100101060 != null)
                    current.Total10600100101000 += (Decimal)current.cta_10600100101060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000.cta_10600100102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000.cta_10600100102000;
                current.Total10600100102000 = 0;
                if (current.cta_10600100102010 != null)
                    current.Total10600100102000 += (Decimal)current.cta_10600100102010;
                if (current.cta_10600100102020 != null)
                    current.Total10600100102000 += (Decimal)current.cta_10600100102020;
                if (current.cta_10600100102030 != null)
                    current.Total10600100102000 += (Decimal)current.cta_10600100102030;
                if (current.cta_10600100102040 != null)
                    current.Total10600100102000 += (Decimal)current.cta_10600100102040;
                if (current.cta_10600100102050 != null)
                    current.Total10600100102000 += (Decimal)current.cta_10600100102050;
                if (current.cta_10600100102060 != null)
                    current.Total10600100102000 += (Decimal)current.cta_10600100102060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100100000;
                current.Total10600100100000 = 0;
                if (current.cta_10600100101000 != null && current.cta_10600100101000.Total10600100101000 != 0)
                    current.Total10600100100000 += (Decimal)current.cta_10600100101000.Total10600100101000;
                if (current.cta_10600100102000 != null && current.cta_10600100102000.Total10600100102000 != 0)
                    current.Total10600100100000 += (Decimal)current.cta_10600100102000.Total10600100102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100200000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100200000.cta_10600100201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100200000.cta_10600100201000;
                current.Total10600100201000 = 0;
                if (current.cta_10600100201010 != null)
                    current.Total10600100201000 += (Decimal)current.cta_10600100201010;
                if (current.cta_10600100201020 != null)
                    current.Total10600100201000 += (Decimal)current.cta_10600100201020;
                if (current.cta_10600100201030 != null)
                    current.Total10600100201000 += (Decimal)current.cta_10600100201030;
                if (current.cta_10600100201040 != null)
                    current.Total10600100201000 += (Decimal)current.cta_10600100201040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100200000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100200000.cta_10600100202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100200000.cta_10600100202000;
                current.Total10600100202000 = 0;
                if (current.cta_10600100202010 != null)
                    current.Total10600100202000 += (Decimal)current.cta_10600100202010;
                if (current.cta_10600100202020 != null)
                    current.Total10600100202000 += (Decimal)current.cta_10600100202020;
                if (current.cta_10600100202030 != null)
                    current.Total10600100202000 += (Decimal)current.cta_10600100202030;
                if (current.cta_10600100202040 != null)
                    current.Total10600100202000 += (Decimal)current.cta_10600100202040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100200000;
                current.Total10600100200000 = 0;
                if (current.cta_10600100201000 != null && current.cta_10600100201000.Total10600100201000 != 0)
                    current.Total10600100200000 += (Decimal)current.cta_10600100201000.Total10600100201000;
                if (current.cta_10600100202000 != null && current.cta_10600100202000.Total10600100202000 != 0)
                    current.Total10600100200000 += (Decimal)current.cta_10600100202000.Total10600100202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100300000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100300000.cta_10600100301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100300000.cta_10600100301000;
                current.Total10600100301000 = 0;
                if (current.cta_10600100301010 != null)
                    current.Total10600100301000 += (Decimal)current.cta_10600100301010;
                if (current.cta_10600100301020 != null)
                    current.Total10600100301000 += (Decimal)current.cta_10600100301020;
                if (current.cta_10600100301030 != null)
                    current.Total10600100301000 += (Decimal)current.cta_10600100301030;
                if (current.cta_10600100301040 != null)
                    current.Total10600100301000 += (Decimal)current.cta_10600100301040;
                if (current.cta_10600100301050 != null)
                    current.Total10600100301000 += (Decimal)current.cta_10600100301050;
                if (current.cta_10600100301060 != null)
                    current.Total10600100301000 += (Decimal)current.cta_10600100301060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100300000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100300000.cta_10600100302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100300000.cta_10600100302000;
                current.Total10600100302000 = 0;
                if (current.cta_10600100302010 != null)
                    current.Total10600100302000 += (Decimal)current.cta_10600100302010;
                if (current.cta_10600100302020 != null)
                    current.Total10600100302000 += (Decimal)current.cta_10600100302020;
                if (current.cta_10600100302030 != null)
                    current.Total10600100302000 += (Decimal)current.cta_10600100302030;
                if (current.cta_10600100302040 != null)
                    current.Total10600100302000 += (Decimal)current.cta_10600100302040;
                if (current.cta_10600100302050 != null)
                    current.Total10600100302000 += (Decimal)current.cta_10600100302050;
                if (current.cta_10600100302060 != null)
                    current.Total10600100302000 += (Decimal)current.cta_10600100302060;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100300000;
                current.Total10600100300000 = 0;
                if (current.cta_10600100301000 != null && current.cta_10600100301000.Total10600100301000 != 0)
                    current.Total10600100300000 += (Decimal)current.cta_10600100301000.Total10600100301000;
                if (current.cta_10600100302000 != null && current.cta_10600100302000.Total10600100302000 != 0)
                    current.Total10600100300000 += (Decimal)current.cta_10600100302000.Total10600100302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100400000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100400000.cta_10600100401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100400000.cta_10600100401000;
                current.Total10600100401000 = 0;
                if (current.cta_10600100401010 != null)
                    current.Total10600100401000 += (Decimal)current.cta_10600100401010;
                if (current.cta_10600100401020 != null)
                    current.Total10600100401000 += (Decimal)current.cta_10600100401020;
                if (current.cta_10600100401030 != null)
                    current.Total10600100401000 += (Decimal)current.cta_10600100401030;
                if (current.cta_10600100401040 != null)
                    current.Total10600100401000 += (Decimal)current.cta_10600100401040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100400000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100400000.cta_10600100402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100400000.cta_10600100402000;
                current.Total10600100402000 = 0;
                if (current.cta_10600100402010 != null)
                    current.Total10600100402000 += (Decimal)current.cta_10600100402010;
                if (current.cta_10600100402020 != null)
                    current.Total10600100402000 += (Decimal)current.cta_10600100402020;
                if (current.cta_10600100402030 != null)
                    current.Total10600100402000 += (Decimal)current.cta_10600100402030;
                if (current.cta_10600100402040 != null)
                    current.Total10600100402000 += (Decimal)current.cta_10600100402040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100400000;
                current.Total10600100400000 = 0;
                if (current.cta_10600100401000 != null && current.cta_10600100401000.Total10600100401000 != 0)
                    current.Total10600100400000 += (Decimal)current.cta_10600100401000.Total10600100401000;
                if (current.cta_10600100402000 != null && current.cta_10600100402000.Total10600100402000 != 0)
                    current.Total10600100400000 += (Decimal)current.cta_10600100402000.Total10600100402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100500000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100500000.cta_10600100501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100500000.cta_10600100501000;
                current.Total10600100501000 = 0;
                if (current.cta_10600100501010 != null)
                    current.Total10600100501000 += (Decimal)current.cta_10600100501010;
                if (current.cta_10600100501020 != null)
                    current.Total10600100501000 += (Decimal)current.cta_10600100501020;
                if (current.cta_10600100501030 != null)
                    current.Total10600100501000 += (Decimal)current.cta_10600100501030;
                if (current.cta_10600100501040 != null)
                    current.Total10600100501000 += (Decimal)current.cta_10600100501040;
                if (current.cta_10600100501050 != null)
                    current.Total10600100501000 += (Decimal)current.cta_10600100501050;
                if (current.cta_10600100501060 != null)
                    current.Total10600100501000 += (Decimal)current.cta_10600100501060;
                if (current.cta_10600100501070 != null)
                    current.Total10600100501000 += (Decimal)current.cta_10600100501070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100500000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100500000.cta_10600100502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100500000.cta_10600100502000;
                current.Total10600100502000 = 0;
                if (current.cta_10600100502010 != null)
                    current.Total10600100502000 += (Decimal)current.cta_10600100502010;
                if (current.cta_10600100502020 != null)
                    current.Total10600100502000 += (Decimal)current.cta_10600100502020;
                if (current.cta_10600100502030 != null)
                    current.Total10600100502000 += (Decimal)current.cta_10600100502030;
                if (current.cta_10600100502040 != null)
                    current.Total10600100502000 += (Decimal)current.cta_10600100502040;
                if (current.cta_10600100502050 != null)
                    current.Total10600100502000 += (Decimal)current.cta_10600100502050;
                if (current.cta_10600100502060 != null)
                    current.Total10600100502000 += (Decimal)current.cta_10600100502060;
                if (current.cta_10600100502070 != null)
                    current.Total10600100502000 += (Decimal)current.cta_10600100502070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100500000;
                current.Total10600100500000 = 0;
                if (current.cta_10600100501000 != null && current.cta_10600100501000.Total10600100501000 != 0)
                    current.Total10600100500000 += (Decimal)current.cta_10600100501000.Total10600100501000;
                if (current.cta_10600100502000 != null && current.cta_10600100502000.Total10600100502000 != 0)
                    current.Total10600100500000 += (Decimal)current.cta_10600100502000.Total10600100502000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100600000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100600000.cta_10600100601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100600000.cta_10600100601000;
                current.Total10600100601000 = 0;
                if (current.cta_10600100601010 != null)
                    current.Total10600100601000 += (Decimal)current.cta_10600100601010;
                if (current.cta_10600100601020 != null)
                    current.Total10600100601000 += (Decimal)current.cta_10600100601020;
                if (current.cta_10600100601030 != null)
                    current.Total10600100601000 += (Decimal)current.cta_10600100601030;
                if (current.cta_10600100601040 != null)
                    current.Total10600100601000 += (Decimal)current.cta_10600100601040;
                if (current.cta_10600100601050 != null)
                    current.Total10600100601000 += (Decimal)current.cta_10600100601050;
                if (current.cta_10600100601060 != null)
                    current.Total10600100601000 += (Decimal)current.cta_10600100601060;
                if (current.cta_10600100601070 != null)
                    current.Total10600100601000 += (Decimal)current.cta_10600100601070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100600000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100600000.cta_10600100602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100600000.cta_10600100602000;
                current.Total10600100602000 = 0;
                if (current.cta_10600100602010 != null)
                    current.Total10600100602000 += (Decimal)current.cta_10600100602010;
                if (current.cta_10600100602020 != null)
                    current.Total10600100602000 += (Decimal)current.cta_10600100602020;
                if (current.cta_10600100602030 != null)
                    current.Total10600100602000 += (Decimal)current.cta_10600100602030;
                if (current.cta_10600100602040 != null)
                    current.Total10600100602000 += (Decimal)current.cta_10600100602040;
                if (current.cta_10600100602050 != null)
                    current.Total10600100602000 += (Decimal)current.cta_10600100602050;
                if (current.cta_10600100602060 != null)
                    current.Total10600100602000 += (Decimal)current.cta_10600100602060;
                if (current.cta_10600100602070 != null)
                    current.Total10600100602000 += (Decimal)current.cta_10600100602070;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000.cta_10600100600000;
                current.Total10600100600000 = 0;
                if (current.cta_10600100601000 != null && current.cta_10600100601000.Total10600100601000 != 0)
                    current.Total10600100600000 += (Decimal)current.cta_10600100601000.Total10600100601000;
                if (current.cta_10600100602000 != null && current.cta_10600100602000.Total10600100602000 != 0)
                    current.Total10600100600000 += (Decimal)current.cta_10600100602000.Total10600100602000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null && modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000.cta_10600100000000;
                current.Total10600100000000 = 0;
                if (current.cta_10600100100000 != null && current.cta_10600100100000.Total10600100100000 != 0)
                    current.Total10600100000000 += (Decimal)current.cta_10600100100000.Total10600100100000;
                if (current.cta_10600100200000 != null && current.cta_10600100200000.Total10600100200000 != 0)
                    current.Total10600100000000 += (Decimal)current.cta_10600100200000.Total10600100200000;
                if (current.cta_10600100300000 != null && current.cta_10600100300000.Total10600100300000 != 0)
                    current.Total10600100000000 += (Decimal)current.cta_10600100300000.Total10600100300000;
                if (current.cta_10600100400000 != null && current.cta_10600100400000.Total10600100400000 != 0)
                    current.Total10600100000000 += (Decimal)current.cta_10600100400000.Total10600100400000;
                if (current.cta_10600100500000 != null && current.cta_10600100500000.Total10600100500000 != 0)
                    current.Total10600100000000 += (Decimal)current.cta_10600100500000.Total10600100500000;
                if (current.cta_10600100600000 != null && current.cta_10600100600000.Total10600100600000 != 0)
                    current.Total10600100000000 += (Decimal)current.cta_10600100600000.Total10600100600000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10600000000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10600000000000;
                current.Total10600000000000 = 0;
                if (current.cta_10600100000000 != null && current.cta_10600100000000.Total10600100000000 != 0)
                    current.Total10600000000000 += (Decimal)current.cta_10600100000000.Total10600100000000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000.cta_10700100101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000.cta_10700100101000;
                current.Total10700100101000 = 0;
                if (current.cta_10700100101010 != null)
                    current.Total10700100101000 += (Decimal)current.cta_10700100101010;
                if (current.cta_10700100101020 != null)
                    current.Total10700100101000 += (Decimal)current.cta_10700100101020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000.cta_10700100102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000.cta_10700100102000;
                current.Total10700100102000 = 0;
                if (current.cta_10700100102010 != null)
                    current.Total10700100102000 += (Decimal)current.cta_10700100102010;
                if (current.cta_10700100102020 != null)
                    current.Total10700100102000 += (Decimal)current.cta_10700100102020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100100000;
                current.Total10700100100000 = 0;
                if (current.cta_10700100101000 != null && current.cta_10700100101000.Total10700100101000 != 0)
                    current.Total10700100100000 += (Decimal)current.cta_10700100101000.Total10700100101000;
                if (current.cta_10700100102000 != null && current.cta_10700100102000.Total10700100102000 != 0)
                    current.Total10700100100000 += (Decimal)current.cta_10700100102000.Total10700100102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000.cta_10700100201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000.cta_10700100201000;
                current.Total10700100201000 = 0;
                if (current.cta_10700100201010 != null)
                    current.Total10700100201000 += (Decimal)current.cta_10700100201010;
                if (current.cta_10700100201020 != null)
                    current.Total10700100201000 += (Decimal)current.cta_10700100201020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000.cta_10700100202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000.cta_10700100202000;
                current.Total10700100202000 = 0;
                if (current.cta_10700100202010 != null)
                    current.Total10700100202000 += (Decimal)current.cta_10700100202010;
                if (current.cta_10700100202020 != null)
                    current.Total10700100202000 += (Decimal)current.cta_10700100202020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100200000;
                current.Total10700100200000 = 0;
                if (current.cta_10700100201000 != null && current.cta_10700100201000.Total10700100201000 != 0)
                    current.Total10700100200000 += (Decimal)current.cta_10700100201000.Total10700100201000;
                if (current.cta_10700100202000 != null && current.cta_10700100202000.Total10700100202000 != 0)
                    current.Total10700100200000 += (Decimal)current.cta_10700100202000.Total10700100202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000.cta_10700100301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000.cta_10700100301000;
                current.Total10700100301000 = 0;
                if (current.cta_10700100301010 != null)
                    current.Total10700100301000 += (Decimal)current.cta_10700100301010;
                if (current.cta_10700100301020 != null)
                    current.Total10700100301000 += (Decimal)current.cta_10700100301020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000.cta_10700100302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000.cta_10700100302000;
                current.Total10700100302000 = 0;
                if (current.cta_10700100302010 != null)
                    current.Total10700100302000 += (Decimal)current.cta_10700100302010;
                if (current.cta_10700100302020 != null)
                    current.Total10700100302000 += (Decimal)current.cta_10700100302020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100300000;
                current.Total10700100300000 = 0;
                if (current.cta_10700100301000 != null && current.cta_10700100301000.Total10700100301000 != 0)
                    current.Total10700100300000 += (Decimal)current.cta_10700100301000.Total10700100301000;
                if (current.cta_10700100302000 != null && current.cta_10700100302000.Total10700100302000 != 0)
                    current.Total10700100300000 += (Decimal)current.cta_10700100302000.Total10700100302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000.cta_10700100401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000.cta_10700100401000;
                current.Total10700100401000 = 0;
                if (current.cta_10700100401010 != null)
                    current.Total10700100401000 += (Decimal)current.cta_10700100401010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000.cta_10700100402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000.cta_10700100402000;
                current.Total10700100402000 = 0;
                if (current.cta_10700100402010 != null)
                    current.Total10700100402000 += (Decimal)current.cta_10700100402010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000.cta_10700100400000;
                current.Total10700100400000 = 0;
                if (current.cta_10700100401000 != null && current.cta_10700100401000.Total10700100401000 != 0)
                    current.Total10700100400000 += (Decimal)current.cta_10700100401000.Total10700100401000;
                if (current.cta_10700100402000 != null && current.cta_10700100402000.Total10700100402000 != 0)
                    current.Total10700100400000 += (Decimal)current.cta_10700100402000.Total10700100402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700100000000;
                current.Total10700100000000 = 0;
                if (current.cta_10700100100000 != null && current.cta_10700100100000.Total10700100100000 != 0)
                    current.Total10700100000000 += (Decimal)current.cta_10700100100000.Total10700100100000;
                if (current.cta_10700100200000 != null && current.cta_10700100200000.Total10700100200000 != 0)
                    current.Total10700100000000 += (Decimal)current.cta_10700100200000.Total10700100200000;
                if (current.cta_10700100300000 != null && current.cta_10700100300000.Total10700100300000 != 0)
                    current.Total10700100000000 += (Decimal)current.cta_10700100300000.Total10700100300000;
                if (current.cta_10700100400000 != null && current.cta_10700100400000.Total10700100400000 != 0)
                    current.Total10700100000000 += (Decimal)current.cta_10700100400000.Total10700100400000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000.cta_10700400100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000.cta_10700400100000;
                current.Total10700400100000 = 0;
                if (current.cta_10700400101000 != null)
                    current.Total10700400100000 += (Decimal)current.cta_10700400101000;
                if (current.cta_10700400102000 != null)
                    current.Total10700400100000 += (Decimal)current.cta_10700400102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000.cta_10700400200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000.cta_10700400200000;
                current.Total10700400200000 = 0;
                if (current.cta_10700400201000 != null)
                    current.Total10700400200000 += (Decimal)current.cta_10700400201000;
                if (current.cta_10700400202000 != null)
                    current.Total10700400200000 += (Decimal)current.cta_10700400202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700400000000;
                current.Total10700400000000 = 0;
                if (current.cta_10700400100000 != null && current.cta_10700400100000.Total10700400100000 != 0)
                    current.Total10700400000000 += (Decimal)current.cta_10700400100000.Total10700400100000;
                if (current.cta_10700400200000 != null && current.cta_10700400200000.Total10700400200000 != 0)
                    current.Total10700400000000 += (Decimal)current.cta_10700400200000.Total10700400200000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700700000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700700000000.cta_10700700100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700700000000.cta_10700700100000;
                current.Total10700700100000 = 0;
                if (current.cta_10700700101000 != null)
                    current.Total10700700100000 += (Decimal)current.cta_10700700101000;
                if (current.cta_10700700102000 != null)
                    current.Total10700700100000 += (Decimal)current.cta_10700700102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700700000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700700000000;
                current.Total10700700000000 = 0;
                if (current.cta_10700700100000 != null && current.cta_10700700100000.Total10700700100000 != 0)
                    current.Total10700700000000 += (Decimal)current.cta_10700700100000.Total10700700100000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000.cta_10700800100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000.cta_10700800100000;
                current.Total10700800100000 = 0;
                if (current.cta_10700800101000 != null)
                    current.Total10700800100000 += (Decimal)current.cta_10700800101000;
                if (current.cta_10700800102000 != null)
                    current.Total10700800100000 += (Decimal)current.cta_10700800102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000.cta_10700800200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000.cta_10700800200000;
                current.Total10700800200000 = 0;
                if (current.cta_10700800201000 != null)
                    current.Total10700800200000 += (Decimal)current.cta_10700800201000;
                if (current.cta_10700800202000 != null)
                    current.Total10700800200000 += (Decimal)current.cta_10700800202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700800000000;
                current.Total10700800000000 = 0;
                if (current.cta_10700800100000 != null && current.cta_10700800100000.Total10700800100000 != 0)
                    current.Total10700800000000 += (Decimal)current.cta_10700800100000.Total10700800100000;
                if (current.cta_10700800200000 != null && current.cta_10700800200000.Total10700800200000 != 0)
                    current.Total10700800000000 += (Decimal)current.cta_10700800200000.Total10700800200000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900100000;
                current.Total10700900100000 = 0;
                if (current.cta_10700900101000 != null)
                    current.Total10700900100000 += (Decimal)current.cta_10700900101000;
                if (current.cta_10700900102000 != null)
                    current.Total10700900100000 += (Decimal)current.cta_10700900102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900200000;
                current.Total10700900200000 = 0;
                if (current.cta_10700900201000 != null)
                    current.Total10700900200000 += (Decimal)current.cta_10700900201000;
                if (current.cta_10700900202000 != null)
                    current.Total10700900200000 += (Decimal)current.cta_10700900202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900300000;
                current.Total10700900300000 = 0;
                if (current.cta_10700900301000 != null)
                    current.Total10700900300000 += (Decimal)current.cta_10700900301000;
                if (current.cta_10700900302000 != null)
                    current.Total10700900300000 += (Decimal)current.cta_10700900302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900400000;
                current.Total10700900400000 = 0;
                if (current.cta_10700900401000 != null)
                    current.Total10700900400000 += (Decimal)current.cta_10700900401000;
                if (current.cta_10700900402000 != null)
                    current.Total10700900400000 += (Decimal)current.cta_10700900402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900800000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900800000;
                current.Total10700900800000 = 0;
                if (current.cta_10700900801000 != null)
                    current.Total10700900800000 += (Decimal)current.cta_10700900801000;
                if (current.cta_10700900802000 != null)
                    current.Total10700900800000 += (Decimal)current.cta_10700900802000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000.cta_10700900900000;
                current.Total10700900900000 = 0;
                if (current.cta_10700900901000 != null)
                    current.Total10700900900000 += (Decimal)current.cta_10700900901000;
                if (current.cta_10700900902000 != null)
                    current.Total10700900900000 += (Decimal)current.cta_10700900902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null && modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000.cta_10700900000000;
                current.Total10700900000000 = 0;
                if (current.cta_10700900100000 != null && current.cta_10700900100000.Total10700900100000 != 0)
                    current.Total10700900000000 += (Decimal)current.cta_10700900100000.Total10700900100000;
                if (current.cta_10700900200000 != null && current.cta_10700900200000.Total10700900200000 != 0)
                    current.Total10700900000000 += (Decimal)current.cta_10700900200000.Total10700900200000;
                if (current.cta_10700900300000 != null && current.cta_10700900300000.Total10700900300000 != 0)
                    current.Total10700900000000 += (Decimal)current.cta_10700900300000.Total10700900300000;
                if (current.cta_10700900400000 != null && current.cta_10700900400000.Total10700900400000 != 0)
                    current.Total10700900000000 += (Decimal)current.cta_10700900400000.Total10700900400000;
                if (current.cta_10700900800000 != null && current.cta_10700900800000.Total10700900800000 != 0)
                    current.Total10700900000000 += (Decimal)current.cta_10700900800000.Total10700900800000;
                if (current.cta_10700900900000 != null && current.cta_10700900900000.Total10700900900000 != 0)
                    current.Total10700900000000 += (Decimal)current.cta_10700900900000.Total10700900900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10700000000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10700000000000;
                current.Total10700000000000 = 0;
                if (current.cta_10700100000000 != null && current.cta_10700100000000.Total10700100000000 != 0)
                    current.Total10700000000000 += (Decimal)current.cta_10700100000000.Total10700100000000;
                if (current.cta_10700400000000 != null && current.cta_10700400000000.Total10700400000000 != 0)
                    current.Total10700000000000 += (Decimal)current.cta_10700400000000.Total10700400000000;
                if (current.cta_10700700000000 != null && current.cta_10700700000000.Total10700700000000 != 0)
                    current.Total10700000000000 += (Decimal)current.cta_10700700000000.Total10700700000000;
                if (current.cta_10700800000000 != null && current.cta_10700800000000.Total10700800000000 != 0)
                    current.Total10700000000000 += (Decimal)current.cta_10700800000000.Total10700800000000;
                if (current.cta_10700900000000 != null && current.cta_10700900000000.Total10700900000000 != 0)
                    current.Total10700000000000 += (Decimal)current.cta_10700900000000.Total10700900000000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000.cta_10800200100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000.cta_10800200100000;
                current.Total10800200100000 = 0;
                if (current.cta_10800200101000 != null)
                    current.Total10800200100000 += (Decimal)current.cta_10800200101000;
                if (current.cta_10800200102000 != null)
                    current.Total10800200100000 += (Decimal)current.cta_10800200102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000.cta_10800200300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000.cta_10800200300000;
                current.Total10800200300000 = 0;
                if (current.cta_10800200301000 != null)
                    current.Total10800200300000 += (Decimal)current.cta_10800200301000;
                if (current.cta_10800200302000 != null)
                    current.Total10800200300000 += (Decimal)current.cta_10800200302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800200000000;
                current.Total10800200000000 = 0;
                if (current.cta_10800200100000 != null && current.cta_10800200100000.Total10800200100000 != 0)
                    current.Total10800200000000 += (Decimal)current.cta_10800200100000.Total10800200100000;
                if (current.cta_10800200300000 != null && current.cta_10800200300000.Total10800200300000 != 0)
                    current.Total10800200000000 += (Decimal)current.cta_10800200300000.Total10800200300000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000.cta_10800300100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000.cta_10800300100000;
                current.Total10800300100000 = 0;
                if (current.cta_10800300101000 != null)
                    current.Total10800300100000 += (Decimal)current.cta_10800300101000;
                if (current.cta_10800300102000 != null)
                    current.Total10800300100000 += (Decimal)current.cta_10800300102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000.cta_10800300200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000.cta_10800300200000;
                current.Total10800300200000 = 0;
                if (current.cta_10800300201000 != null)
                    current.Total10800300200000 += (Decimal)current.cta_10800300201000;
                if (current.cta_10800300202000 != null)
                    current.Total10800300200000 += (Decimal)current.cta_10800300202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800300000000;
                current.Total10800300000000 = 0;
                if (current.cta_10800300100000 != null && current.cta_10800300100000.Total10800300100000 != 0)
                    current.Total10800300000000 += (Decimal)current.cta_10800300100000.Total10800300100000;
                if (current.cta_10800300200000 != null && current.cta_10800300200000.Total10800300200000 != 0)
                    current.Total10800300000000 += (Decimal)current.cta_10800300200000.Total10800300200000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000.cta_10800400100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000.cta_10800400100000;
                current.Total10800400100000 = 0;
                if (current.cta_10800400101000 != null)
                    current.Total10800400100000 += (Decimal)current.cta_10800400101000;
                if (current.cta_10800400102000 != null)
                    current.Total10800400100000 += (Decimal)current.cta_10800400102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000.cta_10800400300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000.cta_10800400300000;
                current.Total10800400300000 = 0;
                if (current.cta_10800400301000 != null)
                    current.Total10800400300000 += (Decimal)current.cta_10800400301000;
                if (current.cta_10800400302000 != null)
                    current.Total10800400300000 += (Decimal)current.cta_10800400302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800400000000;
                current.Total10800400000000 = 0;
                if (current.cta_10800400100000 != null && current.cta_10800400100000.Total10800400100000 != 0)
                    current.Total10800400000000 += (Decimal)current.cta_10800400100000.Total10800400100000;
                if (current.cta_10800400300000 != null && current.cta_10800400300000.Total10800400300000 != 0)
                    current.Total10800400000000 += (Decimal)current.cta_10800400300000.Total10800400300000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000.cta_10800502101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000.cta_10800502101000;
                current.Total10800502101000 = 0;
                if (current.cta_10800502101010 != null)
                    current.Total10800502101000 += (Decimal)current.cta_10800502101010;
                if (current.cta_10800502101020 != null)
                    current.Total10800502101000 += (Decimal)current.cta_10800502101020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000.cta_10800502102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000.cta_10800502102000;
                current.Total10800502102000 = 0;
                if (current.cta_10800502102010 != null)
                    current.Total10800502102000 += (Decimal)current.cta_10800502102010;
                if (current.cta_10800502102020 != null)
                    current.Total10800502102000 += (Decimal)current.cta_10800502102020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502100000;
                current.Total10800502100000 = 0;
                if (current.cta_10800502101000 != null && current.cta_10800502101000.Total10800502101000 != 0)
                    current.Total10800502100000 += (Decimal)current.cta_10800502101000.Total10800502101000;
                if (current.cta_10800502102000 != null && current.cta_10800502102000.Total10800502102000 != 0)
                    current.Total10800502100000 += (Decimal)current.cta_10800502102000.Total10800502102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000.cta_10800502201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000.cta_10800502201000;
                current.Total10800502201000 = 0;
                if (current.cta_10800502201010 != null)
                    current.Total10800502201000 += (Decimal)current.cta_10800502201010;
                if (current.cta_10800502201020 != null)
                    current.Total10800502201000 += (Decimal)current.cta_10800502201020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000.cta_10800502202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000.cta_10800502202000;
                current.Total10800502202000 = 0;
                if (current.cta_10800502202010 != null)
                    current.Total10800502202000 += (Decimal)current.cta_10800502202010;
                if (current.cta_10800502202020 != null)
                    current.Total10800502202000 += (Decimal)current.cta_10800502202020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502200000;
                current.Total10800502200000 = 0;
                if (current.cta_10800502201000 != null && current.cta_10800502201000.Total10800502201000 != 0)
                    current.Total10800502200000 += (Decimal)current.cta_10800502201000.Total10800502201000;
                if (current.cta_10800502202000 != null && current.cta_10800502202000.Total10800502202000 != 0)
                    current.Total10800502200000 += (Decimal)current.cta_10800502202000.Total10800502202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000.cta_10800502301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000.cta_10800502301000;
                current.Total10800502301000 = 0;
                if (current.cta_10800502301010 != null)
                    current.Total10800502301000 += (Decimal)current.cta_10800502301010;
                if (current.cta_10800502301020 != null)
                    current.Total10800502301000 += (Decimal)current.cta_10800502301020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000.cta_10800502302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000.cta_10800502302000;
                current.Total10800502302000 = 0;
                if (current.cta_10800502302010 != null)
                    current.Total10800502302000 += (Decimal)current.cta_10800502302010;
                if (current.cta_10800502302020 != null)
                    current.Total10800502302000 += (Decimal)current.cta_10800502302020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502300000;
                current.Total10800502300000 = 0;
                if (current.cta_10800502301000 != null && current.cta_10800502301000.Total10800502301000 != 0)
                    current.Total10800502300000 += (Decimal)current.cta_10800502301000.Total10800502301000;
                if (current.cta_10800502302000 != null && current.cta_10800502302000.Total10800502302000 != 0)
                    current.Total10800502300000 += (Decimal)current.cta_10800502302000.Total10800502302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000.cta_10800502401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000.cta_10800502401000;
                current.Total10800502401000 = 0;
                if (current.cta_10800502401010 != null)
                    current.Total10800502401000 += (Decimal)current.cta_10800502401010;
                if (current.cta_10800502401020 != null)
                    current.Total10800502401000 += (Decimal)current.cta_10800502401020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000.cta_10800502402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000.cta_10800502402000;
                current.Total10800502402000 = 0;
                if (current.cta_10800502402010 != null)
                    current.Total10800502402000 += (Decimal)current.cta_10800502402010;
                if (current.cta_10800502402020 != null)
                    current.Total10800502402000 += (Decimal)current.cta_10800502402020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502400000;
                current.Total10800502400000 = 0;
                if (current.cta_10800502401000 != null && current.cta_10800502401000.Total10800502401000 != 0)
                    current.Total10800502400000 += (Decimal)current.cta_10800502401000.Total10800502401000;
                if (current.cta_10800502402000 != null && current.cta_10800502402000.Total10800502402000 != 0)
                    current.Total10800502400000 += (Decimal)current.cta_10800502402000.Total10800502402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000.cta_10800502501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000.cta_10800502501000;
                current.Total10800502501000 = 0;
                if (current.cta_10800502501010 != null)
                    current.Total10800502501000 += (Decimal)current.cta_10800502501010;
                if (current.cta_10800502501020 != null)
                    current.Total10800502501000 += (Decimal)current.cta_10800502501020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000.cta_10800502502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000.cta_10800502502000;
                current.Total10800502502000 = 0;
                if (current.cta_10800502502010 != null)
                    current.Total10800502502000 += (Decimal)current.cta_10800502502010;
                if (current.cta_10800502502020 != null)
                    current.Total10800502502000 += (Decimal)current.cta_10800502502020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502500000;
                current.Total10800502500000 = 0;
                if (current.cta_10800502501000 != null && current.cta_10800502501000.Total10800502501000 != 0)
                    current.Total10800502500000 += (Decimal)current.cta_10800502501000.Total10800502501000;
                if (current.cta_10800502502000 != null && current.cta_10800502502000.Total10800502502000 != 0)
                    current.Total10800502500000 += (Decimal)current.cta_10800502502000.Total10800502502000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000.cta_10800502901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000.cta_10800502901000;
                current.Total10800502901000 = 0;
                if (current.cta_10800502901010 != null)
                    current.Total10800502901000 += (Decimal)current.cta_10800502901010;
                if (current.cta_10800502901020 != null)
                    current.Total10800502901000 += (Decimal)current.cta_10800502901020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000.cta_10800502902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000.cta_10800502902000;
                current.Total10800502902000 = 0;
                if (current.cta_10800502902010 != null)
                    current.Total10800502902000 += (Decimal)current.cta_10800502902010;
                if (current.cta_10800502902020 != null)
                    current.Total10800502902000 += (Decimal)current.cta_10800502902020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000.cta_10800502900000;
                current.Total10800502900000 = 0;
                if (current.cta_10800502901000 != null && current.cta_10800502901000.Total10800502901000 != 0)
                    current.Total10800502900000 += (Decimal)current.cta_10800502901000.Total10800502901000;
                if (current.cta_10800502902000 != null && current.cta_10800502902000.Total10800502902000 != 0)
                    current.Total10800502900000 += (Decimal)current.cta_10800502902000.Total10800502902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800500000000;
                current.Total10800500000000 = 0;
                if (current.cta_10800502100000 != null && current.cta_10800502100000.Total10800502100000 != 0)
                    current.Total10800500000000 += (Decimal)current.cta_10800502100000.Total10800502100000;
                if (current.cta_10800502200000 != null && current.cta_10800502200000.Total10800502200000 != 0)
                    current.Total10800500000000 += (Decimal)current.cta_10800502200000.Total10800502200000;
                if (current.cta_10800502300000 != null && current.cta_10800502300000.Total10800502300000 != 0)
                    current.Total10800500000000 += (Decimal)current.cta_10800502300000.Total10800502300000;
                if (current.cta_10800502400000 != null && current.cta_10800502400000.Total10800502400000 != 0)
                    current.Total10800500000000 += (Decimal)current.cta_10800502400000.Total10800502400000;
                if (current.cta_10800502500000 != null && current.cta_10800502500000.Total10800502500000 != 0)
                    current.Total10800500000000 += (Decimal)current.cta_10800502500000.Total10800502500000;
                if (current.cta_10800502900000 != null && current.cta_10800502900000.Total10800502900000 != 0)
                    current.Total10800500000000 += (Decimal)current.cta_10800502900000.Total10800502900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.cta_10800600100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.cta_10800600100000;
                current.Total10800600100000 = 0;
                if (current.cta_10800600101000 != null)
                    current.Total10800600100000 += (Decimal)current.cta_10800600101000;
                if (current.cta_10800600102000 != null)
                    current.Total10800600100000 += (Decimal)current.cta_10800600102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.cta_10800600200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.cta_10800600200000;
                current.Total10800600200000 = 0;
                if (current.cta_10800600201000 != null)
                    current.Total10800600200000 += (Decimal)current.cta_10800600201000;
                if (current.cta_10800600202000 != null)
                    current.Total10800600200000 += (Decimal)current.cta_10800600202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.cta_10800600300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000.cta_10800600300000;
                current.Total10800600300000 = 0;
                if (current.cta_10800600301000 != null)
                    current.Total10800600300000 += (Decimal)current.cta_10800600301000;
                if (current.cta_10800600302000 != null)
                    current.Total10800600300000 += (Decimal)current.cta_10800600302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800600000000;
                current.Total10800600000000 = 0;
                if (current.cta_10800600100000 != null && current.cta_10800600100000.Total10800600100000 != 0)
                    current.Total10800600000000 += (Decimal)current.cta_10800600100000.Total10800600100000;
                if (current.cta_10800600200000 != null && current.cta_10800600200000.Total10800600200000 != 0)
                    current.Total10800600000000 += (Decimal)current.cta_10800600200000.Total10800600200000;
                if (current.cta_10800600300000 != null && current.cta_10800600300000.Total10800600300000 != 0)
                    current.Total10800600000000 += (Decimal)current.cta_10800600300000.Total10800600300000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.cta_10800700100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.cta_10800700100000;
                current.Total10800700100000 = 0;
                if (current.cta_10800700101000 != null)
                    current.Total10800700100000 += (Decimal)current.cta_10800700101000;
                if (current.cta_10800700102000 != null)
                    current.Total10800700100000 += (Decimal)current.cta_10800700102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.cta_10800700200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.cta_10800700200000;
                current.Total10800700200000 = 0;
                if (current.cta_10800700201000 != null)
                    current.Total10800700200000 += (Decimal)current.cta_10800700201000;
                if (current.cta_10800700202000 != null)
                    current.Total10800700200000 += (Decimal)current.cta_10800700202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.cta_10800700300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000.cta_10800700300000;
                current.Total10800700300000 = 0;
                if (current.cta_10800700301000 != null)
                    current.Total10800700300000 += (Decimal)current.cta_10800700301000;
                if (current.cta_10800700302000 != null)
                    current.Total10800700300000 += (Decimal)current.cta_10800700302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800700000000;
                current.Total10800700000000 = 0;
                if (current.cta_10800700100000 != null && current.cta_10800700100000.Total10800700100000 != 0)
                    current.Total10800700000000 += (Decimal)current.cta_10800700100000.Total10800700100000;
                if (current.cta_10800700200000 != null && current.cta_10800700200000.Total10800700200000 != 0)
                    current.Total10800700000000 += (Decimal)current.cta_10800700200000.Total10800700200000;
                if (current.cta_10800700300000 != null && current.cta_10800700300000.Total10800700300000 != 0)
                    current.Total10800700000000 += (Decimal)current.cta_10800700300000.Total10800700300000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000.cta_10800800100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000.cta_10800800100000;
                current.Total10800800100000 = 0;
                if (current.cta_10800800101000 != null)
                    current.Total10800800100000 += (Decimal)current.cta_10800800101000;
                if (current.cta_10800800102000 != null)
                    current.Total10800800100000 += (Decimal)current.cta_10800800102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000.cta_10800800300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000.cta_10800800300000;
                current.Total10800800300000 = 0;
                if (current.cta_10800800301000 != null)
                    current.Total10800800300000 += (Decimal)current.cta_10800800301000;
                if (current.cta_10800800302000 != null)
                    current.Total10800800300000 += (Decimal)current.cta_10800800302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800800000000;
                current.Total10800800000000 = 0;
                if (current.cta_10800800100000 != null && current.cta_10800800100000.Total10800800100000 != 0)
                    current.Total10800800000000 += (Decimal)current.cta_10800800100000.Total10800800100000;
                if (current.cta_10800800300000 != null && current.cta_10800800300000.Total10800800300000 != 0)
                    current.Total10800800000000 += (Decimal)current.cta_10800800300000.Total10800800300000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900100000;
                current.Total10800900100000 = 0;
                if (current.cta_10800900101000 != null)
                    current.Total10800900100000 += (Decimal)current.cta_10800900101000;
                if (current.cta_10800900102000 != null)
                    current.Total10800900100000 += (Decimal)current.cta_10800900102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900300000;
                current.Total10800900300000 = 0;
                if (current.cta_10800900301000 != null)
                    current.Total10800900300000 += (Decimal)current.cta_10800900301000;
                if (current.cta_10800900302000 != null)
                    current.Total10800900300000 += (Decimal)current.cta_10800900302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900400000;
                current.Total10800900400000 = 0;
                if (current.cta_10800900401000 != null)
                    current.Total10800900400000 += (Decimal)current.cta_10800900401000;
                if (current.cta_10800900402000 != null)
                    current.Total10800900400000 += (Decimal)current.cta_10800900402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900800000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900800000;
                current.Total10800900800000 = 0;
                if (current.cta_10800900801000 != null)
                    current.Total10800900800000 += (Decimal)current.cta_10800900801000;
                if (current.cta_10800900802000 != null)
                    current.Total10800900800000 += (Decimal)current.cta_10800900802000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800900900000;
                current.Total10800900900000 = 0;
                if (current.cta_10800900901000 != null)
                    current.Total10800900900000 += (Decimal)current.cta_10800900901000;
                if (current.cta_10800900902000 != null)
                    current.Total10800900900000 += (Decimal)current.cta_10800900902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902100000;
                current.Total10800902100000 = 0;
                if (current.cta_10800902101000 != null)
                    current.Total10800902100000 += (Decimal)current.cta_10800902101000;
                if (current.cta_10800902102000 != null)
                    current.Total10800902100000 += (Decimal)current.cta_10800902102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902200000;
                current.Total10800902200000 = 0;
                if (current.cta_10800902201000 != null)
                    current.Total10800902200000 += (Decimal)current.cta_10800902201000;
                if (current.cta_10800902202000 != null)
                    current.Total10800902200000 += (Decimal)current.cta_10800902202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902300000;
                current.Total10800902300000 = 0;
                if (current.cta_10800902301000 != null)
                    current.Total10800902300000 += (Decimal)current.cta_10800902301000;
                if (current.cta_10800902302000 != null)
                    current.Total10800902300000 += (Decimal)current.cta_10800902302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902400000;
                current.Total10800902400000 = 0;
                if (current.cta_10800902401000 != null)
                    current.Total10800902400000 += (Decimal)current.cta_10800902401000;
                if (current.cta_10800902402000 != null)
                    current.Total10800902400000 += (Decimal)current.cta_10800902402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902500000;
                current.Total10800902500000 = 0;
                if (current.cta_10800902501000 != null)
                    current.Total10800902500000 += (Decimal)current.cta_10800902501000;
                if (current.cta_10800902502000 != null)
                    current.Total10800902500000 += (Decimal)current.cta_10800902502000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800902900000;
                current.Total10800902900000 = 0;
                if (current.cta_10800902901000 != null)
                    current.Total10800902900000 += (Decimal)current.cta_10800902901000;
                if (current.cta_10800902902000 != null)
                    current.Total10800902900000 += (Decimal)current.cta_10800902902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800903300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000.cta_10800903300000;
                current.Total10800903300000 = 0;
                if (current.cta_10800903301000 != null)
                    current.Total10800903300000 += (Decimal)current.cta_10800903301000;
                if (current.cta_10800903302000 != null)
                    current.Total10800903300000 += (Decimal)current.cta_10800903302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null && modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000.cta_10800900000000;
                current.Total10800900000000 = 0;
                if (current.cta_10800900100000 != null && current.cta_10800900100000.Total10800900100000 != 0)
                    current.Total10800900000000 += (Decimal)current.cta_10800900100000.Total10800900100000;
                if (current.cta_10800900300000 != null && current.cta_10800900300000.Total10800900300000 != 0)
                    current.Total10800900000000 += (Decimal)current.cta_10800900300000.Total10800900300000;
                if (current.cta_10800900400000 != null && current.cta_10800900400000.Total10800900400000 != 0)
                    current.Total10800900000000 += (Decimal)current.cta_10800900400000.Total10800900400000;
                if (current.cta_10800900800000 != null && current.cta_10800900800000.Total10800900800000 != 0)
                    current.Total10800900000000 += (Decimal)current.cta_10800900800000.Total10800900800000;
                if (current.cta_10800900900000 != null && current.cta_10800900900000.Total10800900900000 != 0)
                    current.Total10800900000000 += (Decimal)current.cta_10800900900000.Total10800900900000;
                if (current.cta_10800902100000 != null && current.cta_10800902100000.Total10800902100000 != 0)
                    current.Total10800900000000 += (Decimal)current.cta_10800902100000.Total10800902100000;
                if (current.cta_10800902200000 != null && current.cta_10800902200000.Total10800902200000 != 0)
                    current.Total10800900000000 += (Decimal)current.cta_10800902200000.Total10800902200000;
                if (current.cta_10800902300000 != null && current.cta_10800902300000.Total10800902300000 != 0)
                    current.Total10800900000000 += (Decimal)current.cta_10800902300000.Total10800902300000;
                if (current.cta_10800902400000 != null && current.cta_10800902400000.Total10800902400000 != 0)
                    current.Total10800900000000 += (Decimal)current.cta_10800902400000.Total10800902400000;
                if (current.cta_10800902500000 != null && current.cta_10800902500000.Total10800902500000 != 0)
                    current.Total10800900000000 += (Decimal)current.cta_10800902500000.Total10800902500000;
                if (current.cta_10800902900000 != null && current.cta_10800902900000.Total10800902900000 != 0)
                    current.Total10800900000000 += (Decimal)current.cta_10800902900000.Total10800902900000;
                if (current.cta_10800903300000 != null && current.cta_10800903300000.Total10800903300000 != 0)
                    current.Total10800900000000 += (Decimal)current.cta_10800903300000.Total10800903300000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10800000000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10800000000000;
                current.Total10800000000000 = 0;
                if (current.cta_10800200000000 != null && current.cta_10800200000000.Total10800200000000 != 0)
                    current.Total10800000000000 += (Decimal)current.cta_10800200000000.Total10800200000000;
                if (current.cta_10800300000000 != null && current.cta_10800300000000.Total10800300000000 != 0)
                    current.Total10800000000000 += (Decimal)current.cta_10800300000000.Total10800300000000;
                if (current.cta_10800400000000 != null && current.cta_10800400000000.Total10800400000000 != 0)
                    current.Total10800000000000 += (Decimal)current.cta_10800400000000.Total10800400000000;
                if (current.cta_10800500000000 != null && current.cta_10800500000000.Total10800500000000 != 0)
                    current.Total10800000000000 += (Decimal)current.cta_10800500000000.Total10800500000000;
                if (current.cta_10800600000000 != null && current.cta_10800600000000.Total10800600000000 != 0)
                    current.Total10800000000000 += (Decimal)current.cta_10800600000000.Total10800600000000;
                if (current.cta_10800700000000 != null && current.cta_10800700000000.Total10800700000000 != 0)
                    current.Total10800000000000 += (Decimal)current.cta_10800700000000.Total10800700000000;
                if (current.cta_10800800000000 != null && current.cta_10800800000000.Total10800800000000 != 0)
                    current.Total10800000000000 += (Decimal)current.cta_10800800000000.Total10800800000000;
                if (current.cta_10800900000000 != null && current.cta_10800900000000.Total10800900000000 != 0)
                    current.Total10800000000000 += (Decimal)current.cta_10800900000000.Total10800900000000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000.cta_10900100201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000.cta_10900100201000;
                current.Total10900100201000 = 0;
                if (current.cta_10900100201010 != null)
                    current.Total10900100201000 += (Decimal)current.cta_10900100201010;
                if (current.cta_10900100201990 != null)
                    current.Total10900100201000 += (Decimal)current.cta_10900100201990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000.cta_10900100202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000.cta_10900100202000;
                current.Total10900100202000 = 0;
                if (current.cta_10900100202010 != null)
                    current.Total10900100202000 += (Decimal)current.cta_10900100202010;
                if (current.cta_10900100202990 != null)
                    current.Total10900100202000 += (Decimal)current.cta_10900100202990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100200000;
                current.Total10900100200000 = 0;
                if (current.cta_10900100201000 != null && current.cta_10900100201000.Total10900100201000 != 0)
                    current.Total10900100200000 += (Decimal)current.cta_10900100201000.Total10900100201000;
                if (current.cta_10900100202000 != null && current.cta_10900100202000.Total10900100202000 != 0)
                    current.Total10900100200000 += (Decimal)current.cta_10900100202000.Total10900100202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100300000;
                current.Total10900100300000 = 0;
                if (current.cta_10900100301000 != null)
                    current.Total10900100300000 += (Decimal)current.cta_10900100301000;
                if (current.cta_10900100302000 != null)
                    current.Total10900100300000 += (Decimal)current.cta_10900100302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900100400000;
                current.Total10900100400000 = 0;
                if (current.cta_10900100401000 != null)
                    current.Total10900100400000 += (Decimal)current.cta_10900100401000;
                if (current.cta_10900100402000 != null)
                    current.Total10900100400000 += (Decimal)current.cta_10900100402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900109900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000.cta_10900109900000;
                current.Total10900109900000 = 0;
                if (current.cta_10900109901000 != null)
                    current.Total10900109900000 += (Decimal)current.cta_10900109901000;
                if (current.cta_10900109902000 != null)
                    current.Total10900109900000 += (Decimal)current.cta_10900109902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900100000000;
                current.Total10900100000000 = 0;
                if (current.cta_10900100200000 != null && current.cta_10900100200000.Total10900100200000 != 0)
                    current.Total10900100000000 += (Decimal)current.cta_10900100200000.Total10900100200000;
                if (current.cta_10900100300000 != null && current.cta_10900100300000.Total10900100300000 != 0)
                    current.Total10900100000000 += (Decimal)current.cta_10900100300000.Total10900100300000;
                if (current.cta_10900100400000 != null && current.cta_10900100400000.Total10900100400000 != 0)
                    current.Total10900100000000 += (Decimal)current.cta_10900100400000.Total10900100400000;
                if (current.cta_10900109900000 != null && current.cta_10900109900000.Total10900109900000 != 0)
                    current.Total10900100000000 += (Decimal)current.cta_10900109900000.Total10900109900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000.cta_10900200201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000.cta_10900200201000;
                current.Total10900200201000 = 0;
                if (current.cta_10900200201010 != null)
                    current.Total10900200201000 += (Decimal)current.cta_10900200201010;
                if (current.cta_10900200201020 != null)
                    current.Total10900200201000 += (Decimal)current.cta_10900200201020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000.cta_10900200202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000.cta_10900200202000;
                current.Total10900200202000 = 0;
                if (current.cta_10900200202010 != null)
                    current.Total10900200202000 += (Decimal)current.cta_10900200202010;
                if (current.cta_10900200202020 != null)
                    current.Total10900200202000 += (Decimal)current.cta_10900200202020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200200000;
                current.Total10900200200000 = 0;
                if (current.cta_10900200201000 != null && current.cta_10900200201000.Total10900200201000 != 0)
                    current.Total10900200200000 += (Decimal)current.cta_10900200201000.Total10900200201000;
                if (current.cta_10900200202000 != null && current.cta_10900200202000.Total10900200202000 != 0)
                    current.Total10900200200000 += (Decimal)current.cta_10900200202000.Total10900200202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900200300000;
                current.Total10900200300000 = 0;
                if (current.cta_10900200301000 != null)
                    current.Total10900200300000 += (Decimal)current.cta_10900200301000;
                if (current.cta_10900200302000 != null)
                    current.Total10900200300000 += (Decimal)current.cta_10900200302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000.cta_10900209901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000.cta_10900209901000;
                current.Total10900209901000 = 0;
                if (current.cta_10900209901010 != null)
                    current.Total10900209901000 += (Decimal)current.cta_10900209901010;
                if (current.cta_10900209901020 != null)
                    current.Total10900209901000 += (Decimal)current.cta_10900209901020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000.cta_10900209902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000.cta_10900209902000;
                current.Total10900209902000 = 0;
                if (current.cta_10900209902010 != null)
                    current.Total10900209902000 += (Decimal)current.cta_10900209902010;
                if (current.cta_10900209902020 != null)
                    current.Total10900209902000 += (Decimal)current.cta_10900209902020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000.cta_10900209900000;
                current.Total10900209900000 = 0;
                if (current.cta_10900209901000 != null && current.cta_10900209901000.Total10900209901000 != 0)
                    current.Total10900209900000 += (Decimal)current.cta_10900209901000.Total10900209901000;
                if (current.cta_10900209902000 != null && current.cta_10900209902000.Total10900209902000 != 0)
                    current.Total10900209900000 += (Decimal)current.cta_10900209902000.Total10900209902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900200000000;
                current.Total10900200000000 = 0;
                if (current.cta_10900200200000 != null && current.cta_10900200200000.Total10900200200000 != 0)
                    current.Total10900200000000 += (Decimal)current.cta_10900200200000.Total10900200200000;
                if (current.cta_10900200300000 != null && current.cta_10900200300000.Total10900200300000 != 0)
                    current.Total10900200000000 += (Decimal)current.cta_10900200300000.Total10900200300000;
                if (current.cta_10900209900000 != null && current.cta_10900209900000.Total10900209900000 != 0)
                    current.Total10900200000000 += (Decimal)current.cta_10900209900000.Total10900209900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300200000;
                current.Total10900300200000 = 0;
                if (current.cta_10900300201000 != null)
                    current.Total10900300200000 += (Decimal)current.cta_10900300201000;
                if (current.cta_10900300202000 != null)
                    current.Total10900300200000 += (Decimal)current.cta_10900300202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000.cta_10900300401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000.cta_10900300401000;
                current.Total10900300401000 = 0;
                if (current.cta_10900300401010 != null)
                    current.Total10900300401000 += (Decimal)current.cta_10900300401010;
                if (current.cta_10900300401020 != null)
                    current.Total10900300401000 += (Decimal)current.cta_10900300401020;
                if (current.cta_10900300401030 != null)
                    current.Total10900300401000 += (Decimal)current.cta_10900300401030;
                if (current.cta_10900300401040 != null)
                    current.Total10900300401000 += (Decimal)current.cta_10900300401040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000.cta_10900300402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000.cta_10900300402000;
                current.Total10900300402000 = 0;
                if (current.cta_10900300402010 != null)
                    current.Total10900300402000 += (Decimal)current.cta_10900300402010;
                if (current.cta_10900300402020 != null)
                    current.Total10900300402000 += (Decimal)current.cta_10900300402020;
                if (current.cta_10900300402030 != null)
                    current.Total10900300402000 += (Decimal)current.cta_10900300402030;
                if (current.cta_10900300402040 != null)
                    current.Total10900300402000 += (Decimal)current.cta_10900300402040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300400000;
                current.Total10900300400000 = 0;
                if (current.cta_10900300401000 != null && current.cta_10900300401000.Total10900300401000 != 0)
                    current.Total10900300400000 += (Decimal)current.cta_10900300401000.Total10900300401000;
                if (current.cta_10900300402000 != null && current.cta_10900300402000.Total10900300402000 != 0)
                    current.Total10900300400000 += (Decimal)current.cta_10900300402000.Total10900300402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300500000;
                current.Total10900300500000 = 0;
                if (current.cta_10900300501000 != null)
                    current.Total10900300500000 += (Decimal)current.cta_10900300501000;
                if (current.cta_10900300502000 != null)
                    current.Total10900300500000 += (Decimal)current.cta_10900300502000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000.cta_10900300601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000.cta_10900300601000;
                current.Total10900300601000 = 0;
                if (current.cta_10900300601010 != null)
                    current.Total10900300601000 += (Decimal)current.cta_10900300601010;
                if (current.cta_10900300601020 != null)
                    current.Total10900300601000 += (Decimal)current.cta_10900300601020;
                if (current.cta_10900300601030 != null)
                    current.Total10900300601000 += (Decimal)current.cta_10900300601030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000.cta_10900300602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000.cta_10900300602000;
                current.Total10900300602000 = 0;
                if (current.cta_10900300602010 != null)
                    current.Total10900300602000 += (Decimal)current.cta_10900300602010;
                if (current.cta_10900300602020 != null)
                    current.Total10900300602000 += (Decimal)current.cta_10900300602020;
                if (current.cta_10900300602030 != null)
                    current.Total10900300602000 += (Decimal)current.cta_10900300602030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300600000;
                current.Total10900300600000 = 0;
                if (current.cta_10900300601000 != null && current.cta_10900300601000.Total10900300601000 != 0)
                    current.Total10900300600000 += (Decimal)current.cta_10900300601000.Total10900300601000;
                if (current.cta_10900300602000 != null && current.cta_10900300602000.Total10900300602000 != 0)
                    current.Total10900300600000 += (Decimal)current.cta_10900300602000.Total10900300602000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000.cta_10900300701000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000.cta_10900300701000;
                current.Total10900300701000 = 0;
                if (current.cta_10900300701010 != null)
                    current.Total10900300701000 += (Decimal)current.cta_10900300701010;
                if (current.cta_10900300701020 != null)
                    current.Total10900300701000 += (Decimal)current.cta_10900300701020;
                if (current.cta_10900300701030 != null)
                    current.Total10900300701000 += (Decimal)current.cta_10900300701030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000.cta_10900300702000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000.cta_10900300702000;
                current.Total10900300702000 = 0;
                if (current.cta_10900300702010 != null)
                    current.Total10900300702000 += (Decimal)current.cta_10900300702010;
                if (current.cta_10900300702020 != null)
                    current.Total10900300702000 += (Decimal)current.cta_10900300702020;
                if (current.cta_10900300702030 != null)
                    current.Total10900300702000 += (Decimal)current.cta_10900300702030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300700000;
                current.Total10900300700000 = 0;
                if (current.cta_10900300701000 != null && current.cta_10900300701000.Total10900300701000 != 0)
                    current.Total10900300700000 += (Decimal)current.cta_10900300701000.Total10900300701000;
                if (current.cta_10900300702000 != null && current.cta_10900300702000.Total10900300702000 != 0)
                    current.Total10900300700000 += (Decimal)current.cta_10900300702000.Total10900300702000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300800000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300800000;
                current.Total10900300800000 = 0;
                if (current.cta_10900300801000 != null)
                    current.Total10900300800000 += (Decimal)current.cta_10900300801000;
                if (current.cta_10900300802000 != null)
                    current.Total10900300800000 += (Decimal)current.cta_10900300802000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900300900000;
                current.Total10900300900000 = 0;
                if (current.cta_10900300901000 != null)
                    current.Total10900300900000 += (Decimal)current.cta_10900300901000;
                if (current.cta_10900300902000 != null)
                    current.Total10900300900000 += (Decimal)current.cta_10900300902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900309900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000.cta_10900309900000;
                current.Total10900309900000 = 0;
                if (current.cta_10900309901000 != null)
                    current.Total10900309900000 += (Decimal)current.cta_10900309901000;
                if (current.cta_10900309902000 != null)
                    current.Total10900309900000 += (Decimal)current.cta_10900309902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900300000000;
                current.Total10900300000000 = 0;
                if (current.cta_10900300200000 != null && current.cta_10900300200000.Total10900300200000 != 0)
                    current.Total10900300000000 += (Decimal)current.cta_10900300200000.Total10900300200000;
                if (current.cta_10900300400000 != null && current.cta_10900300400000.Total10900300400000 != 0)
                    current.Total10900300000000 += (Decimal)current.cta_10900300400000.Total10900300400000;
                if (current.cta_10900300500000 != null && current.cta_10900300500000.Total10900300500000 != 0)
                    current.Total10900300000000 += (Decimal)current.cta_10900300500000.Total10900300500000;
                if (current.cta_10900300600000 != null && current.cta_10900300600000.Total10900300600000 != 0)
                    current.Total10900300000000 += (Decimal)current.cta_10900300600000.Total10900300600000;
                if (current.cta_10900300700000 != null && current.cta_10900300700000.Total10900300700000 != 0)
                    current.Total10900300000000 += (Decimal)current.cta_10900300700000.Total10900300700000;
                if (current.cta_10900300800000 != null && current.cta_10900300800000.Total10900300800000 != 0)
                    current.Total10900300000000 += (Decimal)current.cta_10900300800000.Total10900300800000;
                if (current.cta_10900300900000 != null && current.cta_10900300900000.Total10900300900000 != 0)
                    current.Total10900300000000 += (Decimal)current.cta_10900300900000.Total10900300900000;
                if (current.cta_10900309900000 != null && current.cta_10900309900000.Total10900309900000 != 0)
                    current.Total10900300000000 += (Decimal)current.cta_10900309900000.Total10900309900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.cta_10900400100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.cta_10900400100000;
                current.Total10900400100000 = 0;
                if (current.cta_10900400101000 != null)
                    current.Total10900400100000 += (Decimal)current.cta_10900400101000;
                if (current.cta_10900400102000 != null)
                    current.Total10900400100000 += (Decimal)current.cta_10900400102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.cta_10900400200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.cta_10900400200000;
                current.Total10900400200000 = 0;
                if (current.cta_10900400201000 != null)
                    current.Total10900400200000 += (Decimal)current.cta_10900400201000;
                if (current.cta_10900400202000 != null)
                    current.Total10900400200000 += (Decimal)current.cta_10900400202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.cta_10900409900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000.cta_10900409900000;
                current.Total10900409900000 = 0;
                if (current.cta_10900409901000 != null)
                    current.Total10900409900000 += (Decimal)current.cta_10900409901000;
                if (current.cta_10900409902000 != null)
                    current.Total10900409900000 += (Decimal)current.cta_10900409902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900400000000;
                current.Total10900400000000 = 0;
                if (current.cta_10900400100000 != null && current.cta_10900400100000.Total10900400100000 != 0)
                    current.Total10900400000000 += (Decimal)current.cta_10900400100000.Total10900400100000;
                if (current.cta_10900400200000 != null && current.cta_10900400200000.Total10900400200000 != 0)
                    current.Total10900400000000 += (Decimal)current.cta_10900400200000.Total10900400200000;
                if (current.cta_10900409900000 != null && current.cta_10900409900000.Total10900409900000 != 0)
                    current.Total10900400000000 += (Decimal)current.cta_10900409900000.Total10900409900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.cta_10900500100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.cta_10900500100000;
                current.Total10900500100000 = 0;
                if (current.cta_10900500101000 != null)
                    current.Total10900500100000 += (Decimal)current.cta_10900500101000;
                if (current.cta_10900500102000 != null)
                    current.Total10900500100000 += (Decimal)current.cta_10900500102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.cta_10900500200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.cta_10900500200000;
                current.Total10900500200000 = 0;
                if (current.cta_10900500201000 != null)
                    current.Total10900500200000 += (Decimal)current.cta_10900500201000;
                if (current.cta_10900500202000 != null)
                    current.Total10900500200000 += (Decimal)current.cta_10900500202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.cta_10900500400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000.cta_10900500400000;
                current.Total10900500400000 = 0;
                if (current.cta_10900500401000 != null)
                    current.Total10900500400000 += (Decimal)current.cta_10900500401000;
                if (current.cta_10900500402000 != null)
                    current.Total10900500400000 += (Decimal)current.cta_10900500402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900500000000;
                current.Total10900500000000 = 0;
                if (current.cta_10900500100000 != null && current.cta_10900500100000.Total10900500100000 != 0)
                    current.Total10900500000000 += (Decimal)current.cta_10900500100000.Total10900500100000;
                if (current.cta_10900500200000 != null && current.cta_10900500200000.Total10900500200000 != 0)
                    current.Total10900500000000 += (Decimal)current.cta_10900500200000.Total10900500200000;
                if (current.cta_10900500400000 != null && current.cta_10900500400000.Total10900500400000 != 0)
                    current.Total10900500000000 += (Decimal)current.cta_10900500400000.Total10900500400000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000.cta_10900600201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000.cta_10900600201000;
                current.Total10900600201000 = 0;
                if (current.cta_10900600201010 != null)
                    current.Total10900600201000 += (Decimal)current.cta_10900600201010;
                if (current.cta_10900600201030 != null)
                    current.Total10900600201000 += (Decimal)current.cta_10900600201030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000.cta_10900600202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000.cta_10900600202000;
                current.Total10900600202000 = 0;
                if (current.cta_10900600202010 != null)
                    current.Total10900600202000 += (Decimal)current.cta_10900600202010;
                if (current.cta_10900600202030 != null)
                    current.Total10900600202000 += (Decimal)current.cta_10900600202030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600200000;
                current.Total10900600200000 = 0;
                if (current.cta_10900600201000 != null && current.cta_10900600201000.Total10900600201000 != 0)
                    current.Total10900600200000 += (Decimal)current.cta_10900600201000.Total10900600201000;
                if (current.cta_10900600202000 != null && current.cta_10900600202000.Total10900600202000 != 0)
                    current.Total10900600200000 += (Decimal)current.cta_10900600202000.Total10900600202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000.cta_10900600401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000.cta_10900600401000;
                current.Total10900600401000 = 0;
                if (current.cta_10900600401010 != null)
                    current.Total10900600401000 += (Decimal)current.cta_10900600401010;
                if (current.cta_10900600401020 != null)
                    current.Total10900600401000 += (Decimal)current.cta_10900600401020;
                if (current.cta_10900600401030 != null)
                    current.Total10900600401000 += (Decimal)current.cta_10900600401030;
                if (current.cta_10900600401040 != null)
                    current.Total10900600401000 += (Decimal)current.cta_10900600401040;
                if (current.cta_10900600401050 != null)
                    current.Total10900600401000 += (Decimal)current.cta_10900600401050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000.cta_10900600402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000.cta_10900600402000;
                current.Total10900600402000 = 0;
                if (current.cta_10900600402010 != null)
                    current.Total10900600402000 += (Decimal)current.cta_10900600402010;
                if (current.cta_10900600402020 != null)
                    current.Total10900600402000 += (Decimal)current.cta_10900600402020;
                if (current.cta_10900600402030 != null)
                    current.Total10900600402000 += (Decimal)current.cta_10900600402030;
                if (current.cta_10900600402040 != null)
                    current.Total10900600402000 += (Decimal)current.cta_10900600402040;
                if (current.cta_10900600402050 != null)
                    current.Total10900600402000 += (Decimal)current.cta_10900600402050;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900600400000;
                current.Total10900600400000 = 0;
                if (current.cta_10900600401000 != null && current.cta_10900600401000.Total10900600401000 != 0)
                    current.Total10900600400000 += (Decimal)current.cta_10900600401000.Total10900600401000;
                if (current.cta_10900600402000 != null && current.cta_10900600402000.Total10900600402000 != 0)
                    current.Total10900600400000 += (Decimal)current.cta_10900600402000.Total10900600402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000.cta_10900609901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000.cta_10900609901000;
                current.Total10900609901000 = 0;
                if (current.cta_10900609901010 != null)
                    current.Total10900609901000 += (Decimal)current.cta_10900609901010;
                if (current.cta_10900609901020 != null)
                    current.Total10900609901000 += (Decimal)current.cta_10900609901020;
                if (current.cta_10900609901030 != null)
                    current.Total10900609901000 += (Decimal)current.cta_10900609901030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000.cta_10900609902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000.cta_10900609902000;
                current.Total10900609902000 = 0;
                if (current.cta_10900609902010 != null)
                    current.Total10900609902000 += (Decimal)current.cta_10900609902010;
                if (current.cta_10900609902020 != null)
                    current.Total10900609902000 += (Decimal)current.cta_10900609902020;
                if (current.cta_10900609902030 != null)
                    current.Total10900609902000 += (Decimal)current.cta_10900609902030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000.cta_10900609900000;
                current.Total10900609900000 = 0;
                if (current.cta_10900609901000 != null && current.cta_10900609901000.Total10900609901000 != 0)
                    current.Total10900609900000 += (Decimal)current.cta_10900609901000.Total10900609901000;
                if (current.cta_10900609902000 != null && current.cta_10900609902000.Total10900609902000 != 0)
                    current.Total10900609900000 += (Decimal)current.cta_10900609902000.Total10900609902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900600000000;
                current.Total10900600000000 = 0;
                if (current.cta_10900600200000 != null && current.cta_10900600200000.Total10900600200000 != 0)
                    current.Total10900600000000 += (Decimal)current.cta_10900600200000.Total10900600200000;
                if (current.cta_10900600400000 != null && current.cta_10900600400000.Total10900600400000 != 0)
                    current.Total10900600000000 += (Decimal)current.cta_10900600400000.Total10900600400000;
                if (current.cta_10900609900000 != null && current.cta_10900609900000.Total10900609900000 != 0)
                    current.Total10900600000000 += (Decimal)current.cta_10900609900000.Total10900609900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000.cta_10900700101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000.cta_10900700101000;
                current.Total10900700101000 = 0;
                if (current.cta_10900700101010 != null)
                    current.Total10900700101000 += (Decimal)current.cta_10900700101010;
                if (current.cta_10900700101020 != null)
                    current.Total10900700101000 += (Decimal)current.cta_10900700101020;
                if (current.cta_10900700101030 != null)
                    current.Total10900700101000 += (Decimal)current.cta_10900700101030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000.cta_10900700102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000.cta_10900700102000;
                current.Total10900700102000 = 0;
                if (current.cta_10900700102010 != null)
                    current.Total10900700102000 += (Decimal)current.cta_10900700102010;
                if (current.cta_10900700102020 != null)
                    current.Total10900700102000 += (Decimal)current.cta_10900700102020;
                if (current.cta_10900700102030 != null)
                    current.Total10900700102000 += (Decimal)current.cta_10900700102030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700100000;
                current.Total10900700100000 = 0;
                if (current.cta_10900700101000 != null && current.cta_10900700101000.Total10900700101000 != 0)
                    current.Total10900700100000 += (Decimal)current.cta_10900700101000.Total10900700101000;
                if (current.cta_10900700102000 != null && current.cta_10900700102000.Total10900700102000 != 0)
                    current.Total10900700100000 += (Decimal)current.cta_10900700102000.Total10900700102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700200000;
                current.Total10900700200000 = 0;
                if (current.cta_10900700201000 != null)
                    current.Total10900700200000 += (Decimal)current.cta_10900700201000;
                if (current.cta_10900700202000 != null)
                    current.Total10900700200000 += (Decimal)current.cta_10900700202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000.cta_10900700300000;
                current.Total10900700300000 = 0;
                if (current.cta_10900700301000 != null)
                    current.Total10900700300000 += (Decimal)current.cta_10900700301000;
                if (current.cta_10900700302000 != null)
                    current.Total10900700300000 += (Decimal)current.cta_10900700302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null && modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000.cta_10900700000000;
                current.Total10900700000000 = 0;
                if (current.cta_10900700100000 != null && current.cta_10900700100000.Total10900700100000 != 0)
                    current.Total10900700000000 += (Decimal)current.cta_10900700100000.Total10900700100000;
                if (current.cta_10900700200000 != null && current.cta_10900700200000.Total10900700200000 != 0)
                    current.Total10900700000000 += (Decimal)current.cta_10900700200000.Total10900700200000;
                if (current.cta_10900700300000 != null && current.cta_10900700300000.Total10900700300000 != 0)
                    current.Total10900700000000 += (Decimal)current.cta_10900700300000.Total10900700300000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10900000000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10900000000000;
                current.Total10900000000000 = 0;
                if (current.cta_10900100000000 != null && current.cta_10900100000000.Total10900100000000 != 0)
                    current.Total10900000000000 += (Decimal)current.cta_10900100000000.Total10900100000000;
                if (current.cta_10900200000000 != null && current.cta_10900200000000.Total10900200000000 != 0)
                    current.Total10900000000000 += (Decimal)current.cta_10900200000000.Total10900200000000;
                if (current.cta_10900300000000 != null && current.cta_10900300000000.Total10900300000000 != 0)
                    current.Total10900000000000 += (Decimal)current.cta_10900300000000.Total10900300000000;
                if (current.cta_10900400000000 != null && current.cta_10900400000000.Total10900400000000 != 0)
                    current.Total10900000000000 += (Decimal)current.cta_10900400000000.Total10900400000000;
                if (current.cta_10900500000000 != null && current.cta_10900500000000.Total10900500000000 != 0)
                    current.Total10900000000000 += (Decimal)current.cta_10900500000000.Total10900500000000;
                if (current.cta_10900600000000 != null && current.cta_10900600000000.Total10900600000000 != 0)
                    current.Total10900000000000 += (Decimal)current.cta_10900600000000.Total10900600000000;
                if (current.cta_10900700000000 != null && current.cta_10900700000000.Total10900700000000 != 0)
                    current.Total10900000000000 += (Decimal)current.cta_10900700000000.Total10900700000000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.cta_11000100100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.cta_11000100100000;
                current.Total11000100100000 = 0;
                if (current.cta_11000100101000 != null)
                    current.Total11000100100000 += (Decimal)current.cta_11000100101000;
                if (current.cta_11000100102000 != null)
                    current.Total11000100100000 += (Decimal)current.cta_11000100102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.cta_11000100200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.cta_11000100200000;
                current.Total11000100200000 = 0;
                if (current.cta_11000100201000 != null)
                    current.Total11000100200000 += (Decimal)current.cta_11000100201000;
                if (current.cta_11000100202000 != null)
                    current.Total11000100200000 += (Decimal)current.cta_11000100202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.cta_11000100900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000.cta_11000100900000;
                current.Total11000100900000 = 0;
                if (current.cta_11000100901000 != null)
                    current.Total11000100900000 += (Decimal)current.cta_11000100901000;
                if (current.cta_11000100902000 != null)
                    current.Total11000100900000 += (Decimal)current.cta_11000100902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000100000000;
                current.Total11000100000000 = 0;
                if (current.cta_11000100100000 != null && current.cta_11000100100000.Total11000100100000 != 0)
                    current.Total11000100000000 += (Decimal)current.cta_11000100100000.Total11000100100000;
                if (current.cta_11000100200000 != null && current.cta_11000100200000.Total11000100200000 != 0)
                    current.Total11000100000000 += (Decimal)current.cta_11000100200000.Total11000100200000;
                if (current.cta_11000100900000 != null && current.cta_11000100900000.Total11000100900000 != 0)
                    current.Total11000100000000 += (Decimal)current.cta_11000100900000.Total11000100900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200100000;
                current.Total11000200100000 = 0;
                if (current.cta_11000200101000 != null)
                    current.Total11000200100000 += (Decimal)current.cta_11000200101000;
                if (current.cta_11000200102000 != null)
                    current.Total11000200100000 += (Decimal)current.cta_11000200102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200200000;
                current.Total11000200200000 = 0;
                if (current.cta_11000200201000 != null)
                    current.Total11000200200000 += (Decimal)current.cta_11000200201000;
                if (current.cta_11000200202000 != null)
                    current.Total11000200200000 += (Decimal)current.cta_11000200202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000.cta_11000200401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000.cta_11000200401000;
                current.Total11000200401000 = 0;
                if (current.cta_11000200401020 != null)
                    current.Total11000200401000 += (Decimal)current.cta_11000200401020;
                if (current.cta_11000200401030 != null)
                    current.Total11000200401000 += (Decimal)current.cta_11000200401030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000.cta_11000200402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000.cta_11000200402000;
                current.Total11000200402000 = 0;
                if (current.cta_11000200402020 != null)
                    current.Total11000200402000 += (Decimal)current.cta_11000200402020;
                if (current.cta_11000200402030 != null)
                    current.Total11000200402000 += (Decimal)current.cta_11000200402030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200400000;
                current.Total11000200400000 = 0;
                if (current.cta_11000200401000 != null && current.cta_11000200401000.Total11000200401000 != 0)
                    current.Total11000200400000 += (Decimal)current.cta_11000200401000.Total11000200401000;
                if (current.cta_11000200402000 != null && current.cta_11000200402000.Total11000200402000 != 0)
                    current.Total11000200400000 += (Decimal)current.cta_11000200402000.Total11000200402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000.cta_11000200901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000.cta_11000200901000;
                current.Total11000200901000 = 0;
                if (current.cta_11000200901020 != null)
                    current.Total11000200901000 += (Decimal)current.cta_11000200901020;
                if (current.cta_11000200901030 != null)
                    current.Total11000200901000 += (Decimal)current.cta_11000200901030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000.cta_11000200902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000.cta_11000200902000;
                current.Total11000200902000 = 0;
                if (current.cta_11000200902020 != null)
                    current.Total11000200902000 += (Decimal)current.cta_11000200902020;
                if (current.cta_11000200902030 != null)
                    current.Total11000200902000 += (Decimal)current.cta_11000200902030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000200900000;
                current.Total11000200900000 = 0;
                if (current.cta_11000200901000 != null && current.cta_11000200901000.Total11000200901000 != 0)
                    current.Total11000200900000 += (Decimal)current.cta_11000200901000.Total11000200901000;
                if (current.cta_11000200902000 != null && current.cta_11000200902000.Total11000200902000 != 0)
                    current.Total11000200900000 += (Decimal)current.cta_11000200902000.Total11000200902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000.cta_11000201901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000.cta_11000201901000;
                current.Total11000201901000 = 0;
                if (current.cta_11000201901020 != null)
                    current.Total11000201901000 += (Decimal)current.cta_11000201901020;
                if (current.cta_11000201901030 != null)
                    current.Total11000201901000 += (Decimal)current.cta_11000201901030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000.cta_11000201902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000.cta_11000201902000;
                current.Total11000201902000 = 0;
                if (current.cta_11000201902020 != null)
                    current.Total11000201902000 += (Decimal)current.cta_11000201902020;
                if (current.cta_11000201902030 != null)
                    current.Total11000201902000 += (Decimal)current.cta_11000201902030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000.cta_11000201900000;
                current.Total11000201900000 = 0;
                if (current.cta_11000201901000 != null && current.cta_11000201901000.Total11000201901000 != 0)
                    current.Total11000201900000 += (Decimal)current.cta_11000201901000.Total11000201901000;
                if (current.cta_11000201902000 != null && current.cta_11000201902000.Total11000201902000 != 0)
                    current.Total11000201900000 += (Decimal)current.cta_11000201902000.Total11000201902000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null && modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000.cta_11000200000000;
                current.Total11000200000000 = 0;
                if (current.cta_11000200100000 != null && current.cta_11000200100000.Total11000200100000 != 0)
                    current.Total11000200000000 += (Decimal)current.cta_11000200100000.Total11000200100000;
                if (current.cta_11000200200000 != null && current.cta_11000200200000.Total11000200200000 != 0)
                    current.Total11000200000000 += (Decimal)current.cta_11000200200000.Total11000200200000;
                if (current.cta_11000200400000 != null && current.cta_11000200400000.Total11000200400000 != 0)
                    current.Total11000200000000 += (Decimal)current.cta_11000200400000.Total11000200400000;
                if (current.cta_11000200900000 != null && current.cta_11000200900000.Total11000200900000 != 0)
                    current.Total11000200000000 += (Decimal)current.cta_11000200900000.Total11000200900000;
                if (current.cta_11000201900000 != null && current.cta_11000201900000.Total11000201900000 != 0)
                    current.Total11000200000000 += (Decimal)current.cta_11000201900000.Total11000201900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11000000000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11000000000000;
                current.Total11000000000000 = 0;
                if (current.cta_11000100000000 != null && current.cta_11000100000000.Total11000100000000 != 0)
                    current.Total11000000000000 += (Decimal)current.cta_11000100000000.Total11000100000000;
                if (current.cta_11000200000000 != null && current.cta_11000200000000.Total11000200000000 != 0)
                    current.Total11000000000000 += (Decimal)current.cta_11000200000000.Total11000200000000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000.cta_11100100100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000.cta_11100100100000;
                current.Total11100100100000 = 0;
                if (current.cta_11100100101000 != null)
                    current.Total11100100100000 += (Decimal)current.cta_11100100101000;
                if (current.cta_11100100102000 != null)
                    current.Total11100100100000 += (Decimal)current.cta_11100100102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000.cta_11100100200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000.cta_11100100200000;
                current.Total11100100200000 = 0;
                if (current.cta_11100100201000 != null)
                    current.Total11100100200000 += (Decimal)current.cta_11100100201000;
                if (current.cta_11100100202000 != null)
                    current.Total11100100200000 += (Decimal)current.cta_11100100202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100100000000;
                current.Total11100100000000 = 0;
                if (current.cta_11100100100000 != null && current.cta_11100100100000.Total11100100100000 != 0)
                    current.Total11100100000000 += (Decimal)current.cta_11100100100000.Total11100100100000;
                if (current.cta_11100100200000 != null && current.cta_11100100200000.Total11100100200000 != 0)
                    current.Total11100100000000 += (Decimal)current.cta_11100100200000.Total11100100200000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000.cta_11100200100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000.cta_11100200100000;
                current.Total11100200100000 = 0;
                if (current.cta_11100200101000 != null)
                    current.Total11100200100000 += (Decimal)current.cta_11100200101000;
                if (current.cta_11100200102000 != null)
                    current.Total11100200100000 += (Decimal)current.cta_11100200102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000.cta_11100200200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000.cta_11100200200000;
                current.Total11100200200000 = 0;
                if (current.cta_11100200201000 != null)
                    current.Total11100200200000 += (Decimal)current.cta_11100200201000;
                if (current.cta_11100200202000 != null)
                    current.Total11100200200000 += (Decimal)current.cta_11100200202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100200000000;
                current.Total11100200000000 = 0;
                if (current.cta_11100200100000 != null && current.cta_11100200100000.Total11100200100000 != 0)
                    current.Total11100200000000 += (Decimal)current.cta_11100200100000.Total11100200100000;
                if (current.cta_11100200200000 != null && current.cta_11100200200000.Total11100200200000 != 0)
                    current.Total11100200000000 += (Decimal)current.cta_11100200200000.Total11100200200000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000.cta_11100300100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000.cta_11100300100000;
                current.Total11100300100000 = 0;
                if (current.cta_11100300101000 != null)
                    current.Total11100300100000 += (Decimal)current.cta_11100300101000;
                if (current.cta_11100300102000 != null)
                    current.Total11100300100000 += (Decimal)current.cta_11100300102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000.cta_11100300200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000.cta_11100300200000;
                current.Total11100300200000 = 0;
                if (current.cta_11100300201000 != null)
                    current.Total11100300200000 += (Decimal)current.cta_11100300201000;
                if (current.cta_11100300202000 != null)
                    current.Total11100300200000 += (Decimal)current.cta_11100300202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100300000000;
                current.Total11100300000000 = 0;
                if (current.cta_11100300100000 != null && current.cta_11100300100000.Total11100300100000 != 0)
                    current.Total11100300000000 += (Decimal)current.cta_11100300100000.Total11100300100000;
                if (current.cta_11100300200000 != null && current.cta_11100300200000.Total11100300200000 != 0)
                    current.Total11100300000000 += (Decimal)current.cta_11100300200000.Total11100300200000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.cta_11100400100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.cta_11100400100000;
                current.Total11100400100000 = 0;
                if (current.cta_11100400101000 != null)
                    current.Total11100400100000 += (Decimal)current.cta_11100400101000;
                if (current.cta_11100400102000 != null)
                    current.Total11100400100000 += (Decimal)current.cta_11100400102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.cta_11100400200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.cta_11100400200000;
                current.Total11100400200000 = 0;
                if (current.cta_11100400201000 != null)
                    current.Total11100400200000 += (Decimal)current.cta_11100400201000;
                if (current.cta_11100400202000 != null)
                    current.Total11100400200000 += (Decimal)current.cta_11100400202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.cta_11100400300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000.cta_11100400300000;
                current.Total11100400300000 = 0;
                if (current.cta_11100400301000 != null)
                    current.Total11100400300000 += (Decimal)current.cta_11100400301000;
                if (current.cta_11100400302000 != null)
                    current.Total11100400300000 += (Decimal)current.cta_11100400302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100400000000;
                current.Total11100400000000 = 0;
                if (current.cta_11100400100000 != null && current.cta_11100400100000.Total11100400100000 != 0)
                    current.Total11100400000000 += (Decimal)current.cta_11100400100000.Total11100400100000;
                if (current.cta_11100400200000 != null && current.cta_11100400200000.Total11100400200000 != 0)
                    current.Total11100400000000 += (Decimal)current.cta_11100400200000.Total11100400200000;
                if (current.cta_11100400300000 != null && current.cta_11100400300000.Total11100400300000 != 0)
                    current.Total11100400000000 += (Decimal)current.cta_11100400300000.Total11100400300000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900100000;
                current.Total11100900100000 = 0;
                if (current.cta_11100900101000 != null)
                    current.Total11100900100000 += (Decimal)current.cta_11100900101000;
                if (current.cta_11100900102000 != null)
                    current.Total11100900100000 += (Decimal)current.cta_11100900102000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900200000;
                current.Total11100900200000 = 0;
                if (current.cta_11100900201000 != null)
                    current.Total11100900200000 += (Decimal)current.cta_11100900201000;
                if (current.cta_11100900202000 != null)
                    current.Total11100900200000 += (Decimal)current.cta_11100900202000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900300000;
                current.Total11100900300000 = 0;
                if (current.cta_11100900301000 != null)
                    current.Total11100900300000 += (Decimal)current.cta_11100900301000;
                if (current.cta_11100900302000 != null)
                    current.Total11100900300000 += (Decimal)current.cta_11100900302000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000.cta_11100900400000;
                current.Total11100900400000 = 0;
                if (current.cta_11100900401000 != null)
                    current.Total11100900400000 += (Decimal)current.cta_11100900401000;
                if (current.cta_11100900402000 != null)
                    current.Total11100900400000 += (Decimal)current.cta_11100900402000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null && modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000.cta_11100900000000;
                current.Total11100900000000 = 0;
                if (current.cta_11100900100000 != null && current.cta_11100900100000.Total11100900100000 != 0)
                    current.Total11100900000000 += (Decimal)current.cta_11100900100000.Total11100900100000;
                if (current.cta_11100900200000 != null && current.cta_11100900200000.Total11100900200000 != 0)
                    current.Total11100900000000 += (Decimal)current.cta_11100900200000.Total11100900200000;
                if (current.cta_11100900300000 != null && current.cta_11100900300000.Total11100900300000 != 0)
                    current.Total11100900000000 += (Decimal)current.cta_11100900300000.Total11100900300000;
                if (current.cta_11100900400000 != null && current.cta_11100900400000.Total11100900400000 != 0)
                    current.Total11100900000000 += (Decimal)current.cta_11100900400000.Total11100900400000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_11100000000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_11100000000000;
                current.Total11100000000000 = 0;
                if (current.cta_11100100000000 != null && current.cta_11100100000000.Total11100100000000 != 0)
                    current.Total11100000000000 += (Decimal)current.cta_11100100000000.Total11100100000000;
                if (current.cta_11100200000000 != null && current.cta_11100200000000.Total11100200000000 != 0)
                    current.Total11100000000000 += (Decimal)current.cta_11100200000000.Total11100200000000;
                if (current.cta_11100300000000 != null && current.cta_11100300000000.Total11100300000000 != 0)
                    current.Total11100000000000 += (Decimal)current.cta_11100300000000.Total11100300000000;
                if (current.cta_11100400000000 != null && current.cta_11100400000000.Total11100400000000 != 0)
                    current.Total11100000000000 += (Decimal)current.cta_11100400000000.Total11100400000000;
                if (current.cta_11100900000000 != null && current.cta_11100900000000.Total11100900000000 != 0)
                    current.Total11100000000000 += (Decimal)current.cta_11100900000000.Total11100900000000;
            }
            if (modelo.cta_10000000000000 != null)
            {
                var current = modelo.cta_10000000000000;
                current.Total10000000000000 = 0;
                if (current.cta_10100000000000 != null && current.cta_10100000000000.Total10100000000000 != 0)
                    current.Total10000000000000 += (Decimal)current.cta_10100000000000.Total10100000000000;
                if (current.cta_10200000000000 != null && current.cta_10200000000000.Total10200000000000 != 0)
                    current.Total10000000000000 += (Decimal)current.cta_10200000000000.Total10200000000000;
                if (current.cta_10300000000000 != null && current.cta_10300000000000.Total10300000000000 != 0)
                    current.Total10000000000000 += (Decimal)current.cta_10300000000000.Total10300000000000;
                if (current.cta_10400000000000 != null && current.cta_10400000000000.Total10400000000000 != 0)
                    current.Total10000000000000 += (Decimal)current.cta_10400000000000.Total10400000000000;
                if (current.cta_10500000000000 != null && current.cta_10500000000000.Total10500000000000 != 0)
                    current.Total10000000000000 += (Decimal)current.cta_10500000000000.Total10500000000000;
                if (current.cta_10600000000000 != null && current.cta_10600000000000.Total10600000000000 != 0)
                    current.Total10000000000000 += (Decimal)current.cta_10600000000000.Total10600000000000;
                if (current.cta_10700000000000 != null && current.cta_10700000000000.Total10700000000000 != 0)
                    current.Total10000000000000 += (Decimal)current.cta_10700000000000.Total10700000000000;
                if (current.cta_10800000000000 != null && current.cta_10800000000000.Total10800000000000 != 0)
                    current.Total10000000000000 += (Decimal)current.cta_10800000000000.Total10800000000000;
                if (current.cta_10900000000000 != null && current.cta_10900000000000.Total10900000000000 != 0)
                    current.Total10000000000000 += (Decimal)current.cta_10900000000000.Total10900000000000;
                if (current.cta_11000000000000 != null && current.cta_11000000000000.Total11000000000000 != 0)
                    current.Total10000000000000 += (Decimal)current.cta_11000000000000.Total11000000000000;
                if (current.cta_11100000000000 != null && current.cta_11100000000000.Total11100000000000 != 0)
                    current.Total10000000000000 += (Decimal)current.cta_11100000000000.Total11100000000000;
            }
        }

    }
}
