using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.Sugese.SaldosContables.Domain.Application.Total
{
    internal class TotalCuenta2
    {
        public static void Mapper(string account, Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModelo modelo, System.Nullable<decimal> value, bool specified)
        {

            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100500000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100500000000.cta_20100500100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100500000000.cta_20100500100000;
                current.Total20100500100000 = 0;
                if (current.cta_20100500101000 != null)
                    current.Total20100500100000 += (Decimal)current.cta_20100500101000;
                if (current.cta_20100500102000 != null)
                    current.Total20100500100000 += (Decimal)current.cta_20100500102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100500000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100500000000.cta_20100500200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100500000000.cta_20100500200000;
                current.Total20100500200000 = 0;
                if (current.cta_20100500201000 != null)
                    current.Total20100500200000 += (Decimal)current.cta_20100500201000;
                if (current.cta_20100500202000 != null)
                    current.Total20100500200000 += (Decimal)current.cta_20100500202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100500000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100500000000.cta_20100500300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100500000000.cta_20100500300000;
                current.Total20100500300000 = 0;
                if (current.cta_20100500301000 != null)
                    current.Total20100500300000 += (Decimal)current.cta_20100500301000;
                if (current.cta_20100500302000 != null)
                    current.Total20100500300000 += (Decimal)current.cta_20100500302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100500000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100500000000.cta_20100500400000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100500000000.cta_20100500400000;
                current.Total20100500400000 = 0;
                if (current.cta_20100500401000 != null)
                    current.Total20100500400000 += (Decimal)current.cta_20100500401000;
                if (current.cta_20100500402000 != null)
                    current.Total20100500400000 += (Decimal)current.cta_20100500402000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100500000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100500000000;
                current.Total20100500000000 = 0;
                if (current.cta_20100500100000 != null && current.cta_20100500100000.Total20100500100000 != 0)
                    current.Total20100500000000 += (Decimal)current.cta_20100500100000.Total20100500100000;
                if (current.cta_20100500200000 != null && current.cta_20100500200000.Total20100500200000 != 0)
                    current.Total20100500000000 += (Decimal)current.cta_20100500200000.Total20100500200000;
                if (current.cta_20100500300000 != null && current.cta_20100500300000.Total20100500300000 != 0)
                    current.Total20100500000000 += (Decimal)current.cta_20100500300000.Total20100500300000;
                if (current.cta_20100500400000 != null && current.cta_20100500400000.Total20100500400000 != 0)
                    current.Total20100500000000 += (Decimal)current.cta_20100500400000.Total20100500400000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000.cta_20100800100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000.cta_20100800100000;
                current.Total20100800100000 = 0;
                if (current.cta_20100800101000 != null)
                    current.Total20100800100000 += (Decimal)current.cta_20100800101000;
                if (current.cta_20100800102000 != null)
                    current.Total20100800100000 += (Decimal)current.cta_20100800102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000.cta_20100800200000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000.cta_20100800200000.cta_20100800201000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000.cta_20100800200000.cta_20100800201000;
                current.Total20100800201000 = 0;
                if (current.cta_20100800201010 != null)
                    current.Total20100800201000 += (Decimal)current.cta_20100800201010;
                if (current.cta_20100800201020 != null)
                    current.Total20100800201000 += (Decimal)current.cta_20100800201020;
                if (current.cta_20100800201030 != null)
                    current.Total20100800201000 += (Decimal)current.cta_20100800201030;
                if (current.cta_20100800201040 != null)
                    current.Total20100800201000 += (Decimal)current.cta_20100800201040;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000.cta_20100800200000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000.cta_20100800200000.cta_20100800202000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000.cta_20100800200000.cta_20100800202000;
                current.Total20100800202000 = 0;
                if (current.cta_20100800202010 != null)
                    current.Total20100800202000 += (Decimal)current.cta_20100800202010;
                if (current.cta_20100800202020 != null)
                    current.Total20100800202000 += (Decimal)current.cta_20100800202020;
                if (current.cta_20100800202030 != null)
                    current.Total20100800202000 += (Decimal)current.cta_20100800202030;
                if (current.cta_20100800202040 != null)
                    current.Total20100800202000 += (Decimal)current.cta_20100800202040;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000.cta_20100800200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000.cta_20100800200000;
                current.Total20100800200000 = 0;
                if (current.cta_20100800201000 != null && current.cta_20100800201000.Total20100800201000 != 0)
                    current.Total20100800200000 += (Decimal)current.cta_20100800201000.Total20100800201000;
                if (current.cta_20100800202000 != null && current.cta_20100800202000.Total20100800202000 != 0)
                    current.Total20100800200000 += (Decimal)current.cta_20100800202000.Total20100800202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000.cta_20100809900000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000.cta_20100809900000;
                current.Total20100809900000 = 0;
                if (current.cta_20100809901000 != null)
                    current.Total20100809900000 += (Decimal)current.cta_20100809901000;
                if (current.cta_20100809902000 != null)
                    current.Total20100809900000 += (Decimal)current.cta_20100809902000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100800000000;
                current.Total20100800000000 = 0;
                if (current.cta_20100800100000 != null && current.cta_20100800100000.Total20100800100000 != 0)
                    current.Total20100800000000 += (Decimal)current.cta_20100800100000.Total20100800100000;
                if (current.cta_20100800200000 != null && current.cta_20100800200000.Total20100800200000 != 0)
                    current.Total20100800000000 += (Decimal)current.cta_20100800200000.Total20100800200000;
                if (current.cta_20100809900000 != null && current.cta_20100809900000.Total20100809900000 != 0)
                    current.Total20100800000000 += (Decimal)current.cta_20100809900000.Total20100809900000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100900100000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100900100000.cta_20100900101000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100900100000.cta_20100900101000;
                current.Total20100900101000 = 0;
                if (current.cta_20100900101010 != null)
                    current.Total20100900101000 += (Decimal)current.cta_20100900101010;
                if (current.cta_20100900101020 != null)
                    current.Total20100900101000 += (Decimal)current.cta_20100900101020;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100900100000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100900100000.cta_20100900102000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100900100000.cta_20100900102000;
                current.Total20100900102000 = 0;
                if (current.cta_20100900102010 != null)
                    current.Total20100900102000 += (Decimal)current.cta_20100900102010;
                if (current.cta_20100900102020 != null)
                    current.Total20100900102000 += (Decimal)current.cta_20100900102020;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100900100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100900100000;
                current.Total20100900100000 = 0;
                if (current.cta_20100900101000 != null && current.cta_20100900101000.Total20100900101000 != 0)
                    current.Total20100900100000 += (Decimal)current.cta_20100900101000.Total20100900101000;
                if (current.cta_20100900102000 != null && current.cta_20100900102000.Total20100900102000 != 0)
                    current.Total20100900100000 += (Decimal)current.cta_20100900102000.Total20100900102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100901500000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100901500000.cta_20100901501000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100901500000.cta_20100901501000;
                current.Total20100901501000 = 0;
                if (current.cta_20100901501010 != null)
                    current.Total20100901501000 += (Decimal)current.cta_20100901501010;
                if (current.cta_20100901501020 != null)
                    current.Total20100901501000 += (Decimal)current.cta_20100901501020;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100901500000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100901500000.cta_20100901502000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100901500000.cta_20100901502000;
                current.Total20100901502000 = 0;
                if (current.cta_20100901502010 != null)
                    current.Total20100901502000 += (Decimal)current.cta_20100901502010;
                if (current.cta_20100901502020 != null)
                    current.Total20100901502000 += (Decimal)current.cta_20100901502020;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100901500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000.cta_20100901500000;
                current.Total20100901500000 = 0;
                if (current.cta_20100901501000 != null && current.cta_20100901501000.Total20100901501000 != 0)
                    current.Total20100901500000 += (Decimal)current.cta_20100901501000.Total20100901501000;
                if (current.cta_20100901502000 != null && current.cta_20100901502000.Total20100901502000 != 0)
                    current.Total20100901500000 += (Decimal)current.cta_20100901502000.Total20100901502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null && modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000.cta_20100900000000;
                current.Total20100900000000 = 0;
                if (current.cta_20100900100000 != null && current.cta_20100900100000.Total20100900100000 != 0)
                    current.Total20100900000000 += (Decimal)current.cta_20100900100000.Total20100900100000;
                if (current.cta_20100901500000 != null && current.cta_20100901500000.Total20100901500000 != 0)
                    current.Total20100900000000 += (Decimal)current.cta_20100901500000.Total20100901500000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20100000000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20100000000000;
                current.Total20100000000000 = 0;
                if (current.cta_20100500000000 != null && current.cta_20100500000000.Total20100500000000 != 0)
                    current.Total20100000000000 += (Decimal)current.cta_20100500000000.Total20100500000000;
                if (current.cta_20100800000000 != null && current.cta_20100800000000.Total20100800000000 != 0)
                    current.Total20100000000000 += (Decimal)current.cta_20100800000000.Total20100800000000;
                if (current.cta_20100900000000 != null && current.cta_20100900000000.Total20100900000000 != 0)
                    current.Total20100000000000 += (Decimal)current.cta_20100900000000.Total20100900000000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000.cta_20300100500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000.cta_20300100500000;
                current.Total20300100500000 = 0;
                if (current.cta_20300100501000 != null)
                    current.Total20300100500000 += (Decimal)current.cta_20300100501000;
                if (current.cta_20300100502000 != null)
                    current.Total20300100500000 += (Decimal)current.cta_20300100502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000.cta_20300100600000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000.cta_20300100600000;
                current.Total20300100600000 = 0;
                if (current.cta_20300100601000 != null)
                    current.Total20300100600000 += (Decimal)current.cta_20300100601000;
                if (current.cta_20300100602000 != null)
                    current.Total20300100600000 += (Decimal)current.cta_20300100602000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000.cta_20300101000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000.cta_20300101000000;
                current.Total20300101000000 = 0;
                if (current.cta_20300101001000 != null)
                    current.Total20300101000000 += (Decimal)current.cta_20300101001000;
                if (current.cta_20300101002000 != null)
                    current.Total20300101000000 += (Decimal)current.cta_20300101002000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000.cta_20300101500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000.cta_20300101500000;
                current.Total20300101500000 = 0;
                if (current.cta_20300101501000 != null)
                    current.Total20300101500000 += (Decimal)current.cta_20300101501000;
                if (current.cta_20300101502000 != null)
                    current.Total20300101500000 += (Decimal)current.cta_20300101502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000.cta_20300109900000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000.cta_20300109900000;
                current.Total20300109900000 = 0;
                if (current.cta_20300109901000 != null)
                    current.Total20300109900000 += (Decimal)current.cta_20300109901000;
                if (current.cta_20300109902000 != null)
                    current.Total20300109900000 += (Decimal)current.cta_20300109902000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300100000000;
                current.Total20300100000000 = 0;
                if (current.cta_20300100500000 != null && current.cta_20300100500000.Total20300100500000 != 0)
                    current.Total20300100000000 += (Decimal)current.cta_20300100500000.Total20300100500000;
                if (current.cta_20300100600000 != null && current.cta_20300100600000.Total20300100600000 != 0)
                    current.Total20300100000000 += (Decimal)current.cta_20300100600000.Total20300100600000;
                if (current.cta_20300101000000 != null && current.cta_20300101000000.Total20300101000000 != 0)
                    current.Total20300100000000 += (Decimal)current.cta_20300101000000.Total20300101000000;
                if (current.cta_20300101500000 != null && current.cta_20300101500000.Total20300101500000 != 0)
                    current.Total20300100000000 += (Decimal)current.cta_20300101500000.Total20300101500000;
                if (current.cta_20300109900000 != null && current.cta_20300109900000.Total20300109900000 != 0)
                    current.Total20300100000000 += (Decimal)current.cta_20300109900000.Total20300109900000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201000000;
                current.Total20300201000000 = 0;
                if (current.cta_20300201001000 != null)
                    current.Total20300201000000 += (Decimal)current.cta_20300201001000;
                if (current.cta_20300201002000 != null)
                    current.Total20300201000000 += (Decimal)current.cta_20300201002000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201100000;
                current.Total20300201100000 = 0;
                if (current.cta_20300201101000 != null)
                    current.Total20300201100000 += (Decimal)current.cta_20300201101000;
                if (current.cta_20300201102000 != null)
                    current.Total20300201100000 += (Decimal)current.cta_20300201102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201200000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201200000.cta_20300201201000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201200000.cta_20300201201000;
                current.Total20300201201000 = 0;
                if (current.cta_20300201201210 != null)
                    current.Total20300201201000 += (Decimal)current.cta_20300201201210;
                if (current.cta_20300201201220 != null)
                    current.Total20300201201000 += (Decimal)current.cta_20300201201220;
                if (current.cta_20300201201230 != null)
                    current.Total20300201201000 += (Decimal)current.cta_20300201201230;
                if (current.cta_20300201201240 != null)
                    current.Total20300201201000 += (Decimal)current.cta_20300201201240;
                if (current.cta_20300201201250 != null)
                    current.Total20300201201000 += (Decimal)current.cta_20300201201250;
                if (current.cta_20300201201290 != null)
                    current.Total20300201201000 += (Decimal)current.cta_20300201201290;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201200000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201200000.cta_20300201202000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201200000.cta_20300201202000;
                current.Total20300201202000 = 0;
                if (current.cta_20300201202210 != null)
                    current.Total20300201202000 += (Decimal)current.cta_20300201202210;
                if (current.cta_20300201202220 != null)
                    current.Total20300201202000 += (Decimal)current.cta_20300201202220;
                if (current.cta_20300201202230 != null)
                    current.Total20300201202000 += (Decimal)current.cta_20300201202230;
                if (current.cta_20300201202240 != null)
                    current.Total20300201202000 += (Decimal)current.cta_20300201202240;
                if (current.cta_20300201202250 != null)
                    current.Total20300201202000 += (Decimal)current.cta_20300201202250;
                if (current.cta_20300201202290 != null)
                    current.Total20300201202000 += (Decimal)current.cta_20300201202290;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201200000;
                current.Total20300201200000 = 0;
                if (current.cta_20300201201000 != null && current.cta_20300201201000.Total20300201201000 != 0)
                    current.Total20300201200000 += (Decimal)current.cta_20300201201000.Total20300201201000;
                if (current.cta_20300201202000 != null && current.cta_20300201202000.Total20300201202000 != 0)
                    current.Total20300201200000 += (Decimal)current.cta_20300201202000.Total20300201202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201500000;
                current.Total20300201500000 = 0;
                if (current.cta_20300201501000 != null)
                    current.Total20300201500000 += (Decimal)current.cta_20300201501000;
                if (current.cta_20300201502000 != null)
                    current.Total20300201500000 += (Decimal)current.cta_20300201502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201700000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201700000;
                current.Total20300201700000 = 0;
                if (current.cta_20300201701000 != null)
                    current.Total20300201700000 += (Decimal)current.cta_20300201701000;
                if (current.cta_20300201702000 != null)
                    current.Total20300201700000 += (Decimal)current.cta_20300201702000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201800000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300201800000;
                current.Total20300201800000 = 0;
                if (current.cta_20300201801000 != null)
                    current.Total20300201800000 += (Decimal)current.cta_20300201801000;
                if (current.cta_20300201802000 != null)
                    current.Total20300201800000 += (Decimal)current.cta_20300201802000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300209900000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000.cta_20300209900000;
                current.Total20300209900000 = 0;
                if (current.cta_20300209901000 != null)
                    current.Total20300209900000 += (Decimal)current.cta_20300209901000;
                if (current.cta_20300209902000 != null)
                    current.Total20300209900000 += (Decimal)current.cta_20300209902000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300200000000;
                current.Total20300200000000 = 0;
                if (current.cta_20300201000000 != null && current.cta_20300201000000.Total20300201000000 != 0)
                    current.Total20300200000000 += (Decimal)current.cta_20300201000000.Total20300201000000;
                if (current.cta_20300201100000 != null && current.cta_20300201100000.Total20300201100000 != 0)
                    current.Total20300200000000 += (Decimal)current.cta_20300201100000.Total20300201100000;
                if (current.cta_20300201200000 != null && current.cta_20300201200000.Total20300201200000 != 0)
                    current.Total20300200000000 += (Decimal)current.cta_20300201200000.Total20300201200000;
                if (current.cta_20300201500000 != null && current.cta_20300201500000.Total20300201500000 != 0)
                    current.Total20300200000000 += (Decimal)current.cta_20300201500000.Total20300201500000;
                if (current.cta_20300201700000 != null && current.cta_20300201700000.Total20300201700000 != 0)
                    current.Total20300200000000 += (Decimal)current.cta_20300201700000.Total20300201700000;
                if (current.cta_20300201800000 != null && current.cta_20300201800000.Total20300201800000 != 0)
                    current.Total20300200000000 += (Decimal)current.cta_20300201800000.Total20300201800000;
                if (current.cta_20300209900000 != null && current.cta_20300209900000.Total20300209900000 != 0)
                    current.Total20300200000000 += (Decimal)current.cta_20300209900000.Total20300209900000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300300000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300300000000.cta_20300300100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300300000000.cta_20300300100000;
                current.Total20300300100000 = 0;
                if (current.cta_20300300101000 != null)
                    current.Total20300300100000 += (Decimal)current.cta_20300300101000;
                if (current.cta_20300300102000 != null)
                    current.Total20300300100000 += (Decimal)current.cta_20300300102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300300000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300300000000.cta_20300300200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300300000000.cta_20300300200000;
                current.Total20300300200000 = 0;
                if (current.cta_20300300201000 != null)
                    current.Total20300300200000 += (Decimal)current.cta_20300300201000;
                if (current.cta_20300300202000 != null)
                    current.Total20300300200000 += (Decimal)current.cta_20300300202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300300000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300300000000.cta_20300300300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300300000000.cta_20300300300000;
                current.Total20300300300000 = 0;
                if (current.cta_20300300301000 != null)
                    current.Total20300300300000 += (Decimal)current.cta_20300300301000;
                if (current.cta_20300300302000 != null)
                    current.Total20300300300000 += (Decimal)current.cta_20300300302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300300000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300300000000.cta_20300300400000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300300000000.cta_20300300400000;
                current.Total20300300400000 = 0;
                if (current.cta_20300300401000 != null)
                    current.Total20300300400000 += (Decimal)current.cta_20300300401000;
                if (current.cta_20300300402000 != null)
                    current.Total20300300400000 += (Decimal)current.cta_20300300402000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300300000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300300000000;
                current.Total20300300000000 = 0;
                if (current.cta_20300300100000 != null && current.cta_20300300100000.Total20300300100000 != 0)
                    current.Total20300300000000 += (Decimal)current.cta_20300300100000.Total20300300100000;
                if (current.cta_20300300200000 != null && current.cta_20300300200000.Total20300300200000 != 0)
                    current.Total20300300000000 += (Decimal)current.cta_20300300200000.Total20300300200000;
                if (current.cta_20300300300000 != null && current.cta_20300300300000.Total20300300300000 != 0)
                    current.Total20300300000000 += (Decimal)current.cta_20300300300000.Total20300300300000;
                if (current.cta_20300300400000 != null && current.cta_20300300400000.Total20300300400000 != 0)
                    current.Total20300300000000 += (Decimal)current.cta_20300300400000.Total20300300400000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300700000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300700000000.cta_20300700300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300700000000.cta_20300700300000;
                current.Total20300700300000 = 0;
                if (current.cta_20300700301000 != null)
                    current.Total20300700300000 += (Decimal)current.cta_20300700301000;
                if (current.cta_20300700302000 != null)
                    current.Total20300700300000 += (Decimal)current.cta_20300700302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300700000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300700000000.cta_20300700400000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300700000000.cta_20300700400000;
                current.Total20300700400000 = 0;
                if (current.cta_20300700401000 != null)
                    current.Total20300700400000 += (Decimal)current.cta_20300700401000;
                if (current.cta_20300700402000 != null)
                    current.Total20300700400000 += (Decimal)current.cta_20300700402000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300700000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300700000000;
                current.Total20300700000000 = 0;
                if (current.cta_20300700300000 != null && current.cta_20300700300000.Total20300700300000 != 0)
                    current.Total20300700000000 += (Decimal)current.cta_20300700300000.Total20300700300000;
                if (current.cta_20300700400000 != null && current.cta_20300700400000.Total20300700400000 != 0)
                    current.Total20300700000000 += (Decimal)current.cta_20300700400000.Total20300700400000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300800100000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300800100000.cta_20300800101000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300800100000.cta_20300800101000;
                current.Total20300800101000 = 0;
                if (current.cta_20300800101010 != null)
                    current.Total20300800101000 += (Decimal)current.cta_20300800101010;
                if (current.cta_20300800101020 != null)
                    current.Total20300800101000 += (Decimal)current.cta_20300800101020;
                if (current.cta_20300800101030 != null)
                    current.Total20300800101000 += (Decimal)current.cta_20300800101030;
                if (current.cta_20300800101040 != null)
                    current.Total20300800101000 += (Decimal)current.cta_20300800101040;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300800100000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300800100000.cta_20300800102000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300800100000.cta_20300800102000;
                current.Total20300800102000 = 0;
                if (current.cta_20300800102010 != null)
                    current.Total20300800102000 += (Decimal)current.cta_20300800102010;
                if (current.cta_20300800102020 != null)
                    current.Total20300800102000 += (Decimal)current.cta_20300800102020;
                if (current.cta_20300800102030 != null)
                    current.Total20300800102000 += (Decimal)current.cta_20300800102030;
                if (current.cta_20300800102040 != null)
                    current.Total20300800102000 += (Decimal)current.cta_20300800102040;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300800100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300800100000;
                current.Total20300800100000 = 0;
                if (current.cta_20300800101000 != null && current.cta_20300800101000.Total20300800101000 != 0)
                    current.Total20300800100000 += (Decimal)current.cta_20300800101000.Total20300800101000;
                if (current.cta_20300800102000 != null && current.cta_20300800102000.Total20300800102000 != 0)
                    current.Total20300800100000 += (Decimal)current.cta_20300800102000.Total20300800102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300801500000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300801500000.cta_20300801501000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300801500000.cta_20300801501000;
                current.Total20300801501000 = 0;
                if (current.cta_20300801501010 != null)
                    current.Total20300801501000 += (Decimal)current.cta_20300801501010;
                if (current.cta_20300801501020 != null)
                    current.Total20300801501000 += (Decimal)current.cta_20300801501020;
                if (current.cta_20300801501030 != null)
                    current.Total20300801501000 += (Decimal)current.cta_20300801501030;
                if (current.cta_20300801501040 != null)
                    current.Total20300801501000 += (Decimal)current.cta_20300801501040;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300801500000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300801500000.cta_20300801502000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300801500000.cta_20300801502000;
                current.Total20300801502000 = 0;
                if (current.cta_20300801502010 != null)
                    current.Total20300801502000 += (Decimal)current.cta_20300801502010;
                if (current.cta_20300801502020 != null)
                    current.Total20300801502000 += (Decimal)current.cta_20300801502020;
                if (current.cta_20300801502030 != null)
                    current.Total20300801502000 += (Decimal)current.cta_20300801502030;
                if (current.cta_20300801502040 != null)
                    current.Total20300801502000 += (Decimal)current.cta_20300801502040;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300801500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000.cta_20300801500000;
                current.Total20300801500000 = 0;
                if (current.cta_20300801501000 != null && current.cta_20300801501000.Total20300801501000 != 0)
                    current.Total20300801500000 += (Decimal)current.cta_20300801501000.Total20300801501000;
                if (current.cta_20300801502000 != null && current.cta_20300801502000.Total20300801502000 != 0)
                    current.Total20300801500000 += (Decimal)current.cta_20300801502000.Total20300801502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null && modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000.cta_20300800000000;
                current.Total20300800000000 = 0;
                if (current.cta_20300800100000 != null && current.cta_20300800100000.Total20300800100000 != 0)
                    current.Total20300800000000 += (Decimal)current.cta_20300800100000.Total20300800100000;
                if (current.cta_20300801500000 != null && current.cta_20300801500000.Total20300801500000 != 0)
                    current.Total20300800000000 += (Decimal)current.cta_20300801500000.Total20300801500000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20300000000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20300000000000;
                current.Total20300000000000 = 0;
                if (current.cta_20300100000000 != null && current.cta_20300100000000.Total20300100000000 != 0)
                    current.Total20300000000000 += (Decimal)current.cta_20300100000000.Total20300100000000;
                if (current.cta_20300200000000 != null && current.cta_20300200000000.Total20300200000000 != 0)
                    current.Total20300000000000 += (Decimal)current.cta_20300200000000.Total20300200000000;
                if (current.cta_20300300000000 != null && current.cta_20300300000000.Total20300300000000 != 0)
                    current.Total20300000000000 += (Decimal)current.cta_20300300000000.Total20300300000000;
                if (current.cta_20300700000000 != null && current.cta_20300700000000.Total20300700000000 != 0)
                    current.Total20300000000000 += (Decimal)current.cta_20300700000000.Total20300700000000;
                if (current.cta_20300800000000 != null && current.cta_20300800000000.Total20300800000000 != 0)
                    current.Total20300000000000 += (Decimal)current.cta_20300800000000.Total20300800000000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100100000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100100000.cta_20400100101000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100100000.cta_20400100101000;
                current.Total20400100101000 = 0;
                if (current.cta_20400100101010 != null)
                    current.Total20400100101000 += (Decimal)current.cta_20400100101010;
                if (current.cta_20400100101020 != null)
                    current.Total20400100101000 += (Decimal)current.cta_20400100101020;
                if (current.cta_20400100101030 != null)
                    current.Total20400100101000 += (Decimal)current.cta_20400100101030;
                if (current.cta_20400100101040 != null)
                    current.Total20400100101000 += (Decimal)current.cta_20400100101040;
                if (current.cta_20400100101050 != null)
                    current.Total20400100101000 += (Decimal)current.cta_20400100101050;
                if (current.cta_20400100101060 != null)
                    current.Total20400100101000 += (Decimal)current.cta_20400100101060;
                if (current.cta_20400100101070 != null)
                    current.Total20400100101000 += (Decimal)current.cta_20400100101070;
                if (current.cta_20400100101080 != null)
                    current.Total20400100101000 += (Decimal)current.cta_20400100101080;
                if (current.cta_20400100101990 != null)
                    current.Total20400100101000 += (Decimal)current.cta_20400100101990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100100000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100100000.cta_20400100102000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100100000.cta_20400100102000;
                current.Total20400100102000 = 0;
                if (current.cta_20400100102010 != null)
                    current.Total20400100102000 += (Decimal)current.cta_20400100102010;
                if (current.cta_20400100102020 != null)
                    current.Total20400100102000 += (Decimal)current.cta_20400100102020;
                if (current.cta_20400100102030 != null)
                    current.Total20400100102000 += (Decimal)current.cta_20400100102030;
                if (current.cta_20400100102040 != null)
                    current.Total20400100102000 += (Decimal)current.cta_20400100102040;
                if (current.cta_20400100102050 != null)
                    current.Total20400100102000 += (Decimal)current.cta_20400100102050;
                if (current.cta_20400100102060 != null)
                    current.Total20400100102000 += (Decimal)current.cta_20400100102060;
                if (current.cta_20400100102070 != null)
                    current.Total20400100102000 += (Decimal)current.cta_20400100102070;
                if (current.cta_20400100102080 != null)
                    current.Total20400100102000 += (Decimal)current.cta_20400100102080;
                if (current.cta_20400100102990 != null)
                    current.Total20400100102000 += (Decimal)current.cta_20400100102990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100100000;
                current.Total20400100100000 = 0;
                if (current.cta_20400100101000 != null && current.cta_20400100101000.Total20400100101000 != 0)
                    current.Total20400100100000 += (Decimal)current.cta_20400100101000.Total20400100101000;
                if (current.cta_20400100102000 != null && current.cta_20400100102000.Total20400100102000 != 0)
                    current.Total20400100100000 += (Decimal)current.cta_20400100102000.Total20400100102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100200000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100200000.cta_20400100201000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100200000.cta_20400100201000;
                current.Total20400100201000 = 0;
                if (current.cta_20400100201010 != null)
                    current.Total20400100201000 += (Decimal)current.cta_20400100201010;
                if (current.cta_20400100201020 != null)
                    current.Total20400100201000 += (Decimal)current.cta_20400100201020;
                if (current.cta_20400100201030 != null)
                    current.Total20400100201000 += (Decimal)current.cta_20400100201030;
                if (current.cta_20400100201040 != null)
                    current.Total20400100201000 += (Decimal)current.cta_20400100201040;
                if (current.cta_20400100201050 != null)
                    current.Total20400100201000 += (Decimal)current.cta_20400100201050;
                if (current.cta_20400100201060 != null)
                    current.Total20400100201000 += (Decimal)current.cta_20400100201060;
                if (current.cta_20400100201070 != null)
                    current.Total20400100201000 += (Decimal)current.cta_20400100201070;
                if (current.cta_20400100201080 != null)
                    current.Total20400100201000 += (Decimal)current.cta_20400100201080;
                if (current.cta_20400100201990 != null)
                    current.Total20400100201000 += (Decimal)current.cta_20400100201990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100200000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100200000.cta_20400100202000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100200000.cta_20400100202000;
                current.Total20400100202000 = 0;
                if (current.cta_20400100202010 != null)
                    current.Total20400100202000 += (Decimal)current.cta_20400100202010;
                if (current.cta_20400100202020 != null)
                    current.Total20400100202000 += (Decimal)current.cta_20400100202020;
                if (current.cta_20400100202030 != null)
                    current.Total20400100202000 += (Decimal)current.cta_20400100202030;
                if (current.cta_20400100202040 != null)
                    current.Total20400100202000 += (Decimal)current.cta_20400100202040;
                if (current.cta_20400100202050 != null)
                    current.Total20400100202000 += (Decimal)current.cta_20400100202050;
                if (current.cta_20400100202060 != null)
                    current.Total20400100202000 += (Decimal)current.cta_20400100202060;
                if (current.cta_20400100202070 != null)
                    current.Total20400100202000 += (Decimal)current.cta_20400100202070;
                if (current.cta_20400100202080 != null)
                    current.Total20400100202000 += (Decimal)current.cta_20400100202080;
                if (current.cta_20400100202990 != null)
                    current.Total20400100202000 += (Decimal)current.cta_20400100202990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100200000;
                current.Total20400100200000 = 0;
                if (current.cta_20400100201000 != null && current.cta_20400100201000.Total20400100201000 != 0)
                    current.Total20400100200000 += (Decimal)current.cta_20400100201000.Total20400100201000;
                if (current.cta_20400100202000 != null && current.cta_20400100202000.Total20400100202000 != 0)
                    current.Total20400100200000 += (Decimal)current.cta_20400100202000.Total20400100202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100300000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100300000.cta_20400100301000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100300000.cta_20400100301000;
                current.Total20400100301000 = 0;
                if (current.cta_20400100301010 != null)
                    current.Total20400100301000 += (Decimal)current.cta_20400100301010;
                if (current.cta_20400100301020 != null)
                    current.Total20400100301000 += (Decimal)current.cta_20400100301020;
                if (current.cta_20400100301030 != null)
                    current.Total20400100301000 += (Decimal)current.cta_20400100301030;
                if (current.cta_20400100301040 != null)
                    current.Total20400100301000 += (Decimal)current.cta_20400100301040;
                if (current.cta_20400100301990 != null)
                    current.Total20400100301000 += (Decimal)current.cta_20400100301990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100300000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100300000.cta_20400100302000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100300000.cta_20400100302000;
                current.Total20400100302000 = 0;
                if (current.cta_20400100302010 != null)
                    current.Total20400100302000 += (Decimal)current.cta_20400100302010;
                if (current.cta_20400100302020 != null)
                    current.Total20400100302000 += (Decimal)current.cta_20400100302020;
                if (current.cta_20400100302030 != null)
                    current.Total20400100302000 += (Decimal)current.cta_20400100302030;
                if (current.cta_20400100302040 != null)
                    current.Total20400100302000 += (Decimal)current.cta_20400100302040;
                if (current.cta_20400100302990 != null)
                    current.Total20400100302000 += (Decimal)current.cta_20400100302990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100300000;
                current.Total20400100300000 = 0;
                if (current.cta_20400100301000 != null && current.cta_20400100301000.Total20400100301000 != 0)
                    current.Total20400100300000 += (Decimal)current.cta_20400100301000.Total20400100301000;
                if (current.cta_20400100302000 != null && current.cta_20400100302000.Total20400100302000 != 0)
                    current.Total20400100300000 += (Decimal)current.cta_20400100302000.Total20400100302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100400000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100400000.cta_20400100401000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100400000.cta_20400100401000;
                current.Total20400100401000 = 0;
                if (current.cta_20400100401010 != null)
                    current.Total20400100401000 += (Decimal)current.cta_20400100401010;
                if (current.cta_20400100401020 != null)
                    current.Total20400100401000 += (Decimal)current.cta_20400100401020;
                if (current.cta_20400100401030 != null)
                    current.Total20400100401000 += (Decimal)current.cta_20400100401030;
                if (current.cta_20400100401040 != null)
                    current.Total20400100401000 += (Decimal)current.cta_20400100401040;
                if (current.cta_20400100401050 != null)
                    current.Total20400100401000 += (Decimal)current.cta_20400100401050;
                if (current.cta_20400100401060 != null)
                    current.Total20400100401000 += (Decimal)current.cta_20400100401060;
                if (current.cta_20400100401070 != null)
                    current.Total20400100401000 += (Decimal)current.cta_20400100401070;
                if (current.cta_20400100401080 != null)
                    current.Total20400100401000 += (Decimal)current.cta_20400100401080;
                if (current.cta_20400100401090 != null)
                    current.Total20400100401000 += (Decimal)current.cta_20400100401090;
                if (current.cta_20400100401100 != null)
                    current.Total20400100401000 += (Decimal)current.cta_20400100401100;
                if (current.cta_20400100401990 != null)
                    current.Total20400100401000 += (Decimal)current.cta_20400100401990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100400000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100400000.cta_20400100402000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100400000.cta_20400100402000;
                current.Total20400100402000 = 0;
                if (current.cta_20400100402010 != null)
                    current.Total20400100402000 += (Decimal)current.cta_20400100402010;
                if (current.cta_20400100402020 != null)
                    current.Total20400100402000 += (Decimal)current.cta_20400100402020;
                if (current.cta_20400100402030 != null)
                    current.Total20400100402000 += (Decimal)current.cta_20400100402030;
                if (current.cta_20400100402040 != null)
                    current.Total20400100402000 += (Decimal)current.cta_20400100402040;
                if (current.cta_20400100402050 != null)
                    current.Total20400100402000 += (Decimal)current.cta_20400100402050;
                if (current.cta_20400100402060 != null)
                    current.Total20400100402000 += (Decimal)current.cta_20400100402060;
                if (current.cta_20400100402070 != null)
                    current.Total20400100402000 += (Decimal)current.cta_20400100402070;
                if (current.cta_20400100402080 != null)
                    current.Total20400100402000 += (Decimal)current.cta_20400100402080;
                if (current.cta_20400100402090 != null)
                    current.Total20400100402000 += (Decimal)current.cta_20400100402090;
                if (current.cta_20400100402100 != null)
                    current.Total20400100402000 += (Decimal)current.cta_20400100402100;
                if (current.cta_20400100402990 != null)
                    current.Total20400100402000 += (Decimal)current.cta_20400100402990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100400000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100400000;
                current.Total20400100400000 = 0;
                if (current.cta_20400100401000 != null && current.cta_20400100401000.Total20400100401000 != 0)
                    current.Total20400100400000 += (Decimal)current.cta_20400100401000.Total20400100401000;
                if (current.cta_20400100402000 != null && current.cta_20400100402000.Total20400100402000 != 0)
                    current.Total20400100400000 += (Decimal)current.cta_20400100402000.Total20400100402000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100500000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100500000.cta_20400100501000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100500000.cta_20400100501000;
                current.Total20400100501000 = 0;
                if (current.cta_20400100501010 != null)
                    current.Total20400100501000 += (Decimal)current.cta_20400100501010;
                if (current.cta_20400100501020 != null)
                    current.Total20400100501000 += (Decimal)current.cta_20400100501020;
                if (current.cta_20400100501030 != null)
                    current.Total20400100501000 += (Decimal)current.cta_20400100501030;
                if (current.cta_20400100501040 != null)
                    current.Total20400100501000 += (Decimal)current.cta_20400100501040;
                if (current.cta_20400100501050 != null)
                    current.Total20400100501000 += (Decimal)current.cta_20400100501050;
                if (current.cta_20400100501060 != null)
                    current.Total20400100501000 += (Decimal)current.cta_20400100501060;
                if (current.cta_20400100501070 != null)
                    current.Total20400100501000 += (Decimal)current.cta_20400100501070;
                if (current.cta_20400100501080 != null)
                    current.Total20400100501000 += (Decimal)current.cta_20400100501080;
                if (current.cta_20400100501990 != null)
                    current.Total20400100501000 += (Decimal)current.cta_20400100501990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100500000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100500000.cta_20400100502000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100500000.cta_20400100502000;
                current.Total20400100502000 = 0;
                if (current.cta_20400100502010 != null)
                    current.Total20400100502000 += (Decimal)current.cta_20400100502010;
                if (current.cta_20400100502020 != null)
                    current.Total20400100502000 += (Decimal)current.cta_20400100502020;
                if (current.cta_20400100502030 != null)
                    current.Total20400100502000 += (Decimal)current.cta_20400100502030;
                if (current.cta_20400100502040 != null)
                    current.Total20400100502000 += (Decimal)current.cta_20400100502040;
                if (current.cta_20400100502050 != null)
                    current.Total20400100502000 += (Decimal)current.cta_20400100502050;
                if (current.cta_20400100502060 != null)
                    current.Total20400100502000 += (Decimal)current.cta_20400100502060;
                if (current.cta_20400100502070 != null)
                    current.Total20400100502000 += (Decimal)current.cta_20400100502070;
                if (current.cta_20400100502080 != null)
                    current.Total20400100502000 += (Decimal)current.cta_20400100502080;
                if (current.cta_20400100502990 != null)
                    current.Total20400100502000 += (Decimal)current.cta_20400100502990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100500000;
                current.Total20400100500000 = 0;
                if (current.cta_20400100501000 != null && current.cta_20400100501000.Total20400100501000 != 0)
                    current.Total20400100500000 += (Decimal)current.cta_20400100501000.Total20400100501000;
                if (current.cta_20400100502000 != null && current.cta_20400100502000.Total20400100502000 != 0)
                    current.Total20400100500000 += (Decimal)current.cta_20400100502000.Total20400100502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100600000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100600000.cta_20400100601000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100600000.cta_20400100601000;
                current.Total20400100601000 = 0;
                if (current.cta_20400100601010 != null)
                    current.Total20400100601000 += (Decimal)current.cta_20400100601010;
                if (current.cta_20400100601020 != null)
                    current.Total20400100601000 += (Decimal)current.cta_20400100601020;
                if (current.cta_20400100601030 != null)
                    current.Total20400100601000 += (Decimal)current.cta_20400100601030;
                if (current.cta_20400100601040 != null)
                    current.Total20400100601000 += (Decimal)current.cta_20400100601040;
                if (current.cta_20400100601050 != null)
                    current.Total20400100601000 += (Decimal)current.cta_20400100601050;
                if (current.cta_20400100601060 != null)
                    current.Total20400100601000 += (Decimal)current.cta_20400100601060;
                if (current.cta_20400100601070 != null)
                    current.Total20400100601000 += (Decimal)current.cta_20400100601070;
                if (current.cta_20400100601080 != null)
                    current.Total20400100601000 += (Decimal)current.cta_20400100601080;
                if (current.cta_20400100601990 != null)
                    current.Total20400100601000 += (Decimal)current.cta_20400100601990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100600000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100600000.cta_20400100602000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100600000.cta_20400100602000;
                current.Total20400100602000 = 0;
                if (current.cta_20400100602010 != null)
                    current.Total20400100602000 += (Decimal)current.cta_20400100602010;
                if (current.cta_20400100602020 != null)
                    current.Total20400100602000 += (Decimal)current.cta_20400100602020;
                if (current.cta_20400100602030 != null)
                    current.Total20400100602000 += (Decimal)current.cta_20400100602030;
                if (current.cta_20400100602040 != null)
                    current.Total20400100602000 += (Decimal)current.cta_20400100602040;
                if (current.cta_20400100602050 != null)
                    current.Total20400100602000 += (Decimal)current.cta_20400100602050;
                if (current.cta_20400100602060 != null)
                    current.Total20400100602000 += (Decimal)current.cta_20400100602060;
                if (current.cta_20400100602070 != null)
                    current.Total20400100602000 += (Decimal)current.cta_20400100602070;
                if (current.cta_20400100602080 != null)
                    current.Total20400100602000 += (Decimal)current.cta_20400100602080;
                if (current.cta_20400100602990 != null)
                    current.Total20400100602000 += (Decimal)current.cta_20400100602990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100600000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100600000;
                current.Total20400100600000 = 0;
                if (current.cta_20400100601000 != null && current.cta_20400100601000.Total20400100601000 != 0)
                    current.Total20400100600000 += (Decimal)current.cta_20400100601000.Total20400100601000;
                if (current.cta_20400100602000 != null && current.cta_20400100602000.Total20400100602000 != 0)
                    current.Total20400100600000 += (Decimal)current.cta_20400100602000.Total20400100602000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100700000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100700000.cta_20400100701000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100700000.cta_20400100701000;
                current.Total20400100701000 = 0;
                if (current.cta_20400100701010 != null)
                    current.Total20400100701000 += (Decimal)current.cta_20400100701010;
                if (current.cta_20400100701020 != null)
                    current.Total20400100701000 += (Decimal)current.cta_20400100701020;
                if (current.cta_20400100701030 != null)
                    current.Total20400100701000 += (Decimal)current.cta_20400100701030;
                if (current.cta_20400100701040 != null)
                    current.Total20400100701000 += (Decimal)current.cta_20400100701040;
                if (current.cta_20400100701990 != null)
                    current.Total20400100701000 += (Decimal)current.cta_20400100701990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100700000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100700000.cta_20400100702000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100700000.cta_20400100702000;
                current.Total20400100702000 = 0;
                if (current.cta_20400100702010 != null)
                    current.Total20400100702000 += (Decimal)current.cta_20400100702010;
                if (current.cta_20400100702020 != null)
                    current.Total20400100702000 += (Decimal)current.cta_20400100702020;
                if (current.cta_20400100702030 != null)
                    current.Total20400100702000 += (Decimal)current.cta_20400100702030;
                if (current.cta_20400100702040 != null)
                    current.Total20400100702000 += (Decimal)current.cta_20400100702040;
                if (current.cta_20400100702990 != null)
                    current.Total20400100702000 += (Decimal)current.cta_20400100702990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100700000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100700000;
                current.Total20400100700000 = 0;
                if (current.cta_20400100701000 != null && current.cta_20400100701000.Total20400100701000 != 0)
                    current.Total20400100700000 += (Decimal)current.cta_20400100701000.Total20400100701000;
                if (current.cta_20400100702000 != null && current.cta_20400100702000.Total20400100702000 != 0)
                    current.Total20400100700000 += (Decimal)current.cta_20400100702000.Total20400100702000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100800000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100800000.cta_20400100801000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100800000.cta_20400100801000;
                current.Total20400100801000 = 0;
                if (current.cta_20400100801010 != null)
                    current.Total20400100801000 += (Decimal)current.cta_20400100801010;
                if (current.cta_20400100801020 != null)
                    current.Total20400100801000 += (Decimal)current.cta_20400100801020;
                if (current.cta_20400100801030 != null)
                    current.Total20400100801000 += (Decimal)current.cta_20400100801030;
                if (current.cta_20400100801040 != null)
                    current.Total20400100801000 += (Decimal)current.cta_20400100801040;
                if (current.cta_20400100801050 != null)
                    current.Total20400100801000 += (Decimal)current.cta_20400100801050;
                if (current.cta_20400100801060 != null)
                    current.Total20400100801000 += (Decimal)current.cta_20400100801060;
                if (current.cta_20400100801070 != null)
                    current.Total20400100801000 += (Decimal)current.cta_20400100801070;
                if (current.cta_20400100801080 != null)
                    current.Total20400100801000 += (Decimal)current.cta_20400100801080;
                if (current.cta_20400100801990 != null)
                    current.Total20400100801000 += (Decimal)current.cta_20400100801990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100800000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100800000.cta_20400100802000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100800000.cta_20400100802000;
                current.Total20400100802000 = 0;
                if (current.cta_20400100802010 != null)
                    current.Total20400100802000 += (Decimal)current.cta_20400100802010;
                if (current.cta_20400100802020 != null)
                    current.Total20400100802000 += (Decimal)current.cta_20400100802020;
                if (current.cta_20400100802030 != null)
                    current.Total20400100802000 += (Decimal)current.cta_20400100802030;
                if (current.cta_20400100802040 != null)
                    current.Total20400100802000 += (Decimal)current.cta_20400100802040;
                if (current.cta_20400100802050 != null)
                    current.Total20400100802000 += (Decimal)current.cta_20400100802050;
                if (current.cta_20400100802060 != null)
                    current.Total20400100802000 += (Decimal)current.cta_20400100802060;
                if (current.cta_20400100802070 != null)
                    current.Total20400100802000 += (Decimal)current.cta_20400100802070;
                if (current.cta_20400100802080 != null)
                    current.Total20400100802000 += (Decimal)current.cta_20400100802080;
                if (current.cta_20400100802990 != null)
                    current.Total20400100802000 += (Decimal)current.cta_20400100802990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100800000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100800000;
                current.Total20400100800000 = 0;
                if (current.cta_20400100801000 != null && current.cta_20400100801000.Total20400100801000 != 0)
                    current.Total20400100800000 += (Decimal)current.cta_20400100801000.Total20400100801000;
                if (current.cta_20400100802000 != null && current.cta_20400100802000.Total20400100802000 != 0)
                    current.Total20400100800000 += (Decimal)current.cta_20400100802000.Total20400100802000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100900000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100900000.cta_20400100901000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100900000.cta_20400100901000;
                current.Total20400100901000 = 0;
                if (current.cta_20400100901010 != null)
                    current.Total20400100901000 += (Decimal)current.cta_20400100901010;
                if (current.cta_20400100901020 != null)
                    current.Total20400100901000 += (Decimal)current.cta_20400100901020;
                if (current.cta_20400100901030 != null)
                    current.Total20400100901000 += (Decimal)current.cta_20400100901030;
                if (current.cta_20400100901040 != null)
                    current.Total20400100901000 += (Decimal)current.cta_20400100901040;
                if (current.cta_20400100901050 != null)
                    current.Total20400100901000 += (Decimal)current.cta_20400100901050;
                if (current.cta_20400100901060 != null)
                    current.Total20400100901000 += (Decimal)current.cta_20400100901060;
                if (current.cta_20400100901070 != null)
                    current.Total20400100901000 += (Decimal)current.cta_20400100901070;
                if (current.cta_20400100901080 != null)
                    current.Total20400100901000 += (Decimal)current.cta_20400100901080;
                if (current.cta_20400100901990 != null)
                    current.Total20400100901000 += (Decimal)current.cta_20400100901990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100900000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100900000.cta_20400100902000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100900000.cta_20400100902000;
                current.Total20400100902000 = 0;
                if (current.cta_20400100902010 != null)
                    current.Total20400100902000 += (Decimal)current.cta_20400100902010;
                if (current.cta_20400100902020 != null)
                    current.Total20400100902000 += (Decimal)current.cta_20400100902020;
                if (current.cta_20400100902030 != null)
                    current.Total20400100902000 += (Decimal)current.cta_20400100902030;
                if (current.cta_20400100902040 != null)
                    current.Total20400100902000 += (Decimal)current.cta_20400100902040;
                if (current.cta_20400100902050 != null)
                    current.Total20400100902000 += (Decimal)current.cta_20400100902050;
                if (current.cta_20400100902060 != null)
                    current.Total20400100902000 += (Decimal)current.cta_20400100902060;
                if (current.cta_20400100902070 != null)
                    current.Total20400100902000 += (Decimal)current.cta_20400100902070;
                if (current.cta_20400100902080 != null)
                    current.Total20400100902000 += (Decimal)current.cta_20400100902080;
                if (current.cta_20400100902990 != null)
                    current.Total20400100902000 += (Decimal)current.cta_20400100902990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100900000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400100900000;
                current.Total20400100900000 = 0;
                if (current.cta_20400100901000 != null && current.cta_20400100901000.Total20400100901000 != 0)
                    current.Total20400100900000 += (Decimal)current.cta_20400100901000.Total20400100901000;
                if (current.cta_20400100902000 != null && current.cta_20400100902000.Total20400100902000 != 0)
                    current.Total20400100900000 += (Decimal)current.cta_20400100902000.Total20400100902000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400109900000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400109900000.cta_20400109901000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400109900000.cta_20400109901000;
                current.Total20400109901000 = 0;
                if (current.cta_20400109901010 != null)
                    current.Total20400109901000 += (Decimal)current.cta_20400109901010;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400109900000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400109900000.cta_20400109902000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400109900000.cta_20400109902000;
                current.Total20400109902000 = 0;
                if (current.cta_20400109902010 != null)
                    current.Total20400109902000 += (Decimal)current.cta_20400109902010;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400109900000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000.cta_20400109900000;
                current.Total20400109900000 = 0;
                if (current.cta_20400109901000 != null && current.cta_20400109901000.Total20400109901000 != 0)
                    current.Total20400109900000 += (Decimal)current.cta_20400109901000.Total20400109901000;
                if (current.cta_20400109902000 != null && current.cta_20400109902000.Total20400109902000 != 0)
                    current.Total20400109900000 += (Decimal)current.cta_20400109902000.Total20400109902000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400100000000;
                current.Total20400100000000 = 0;
                if (current.cta_20400100100000 != null && current.cta_20400100100000.Total20400100100000 != 0)
                    current.Total20400100000000 += (Decimal)current.cta_20400100100000.Total20400100100000;
                if (current.cta_20400100200000 != null && current.cta_20400100200000.Total20400100200000 != 0)
                    current.Total20400100000000 += (Decimal)current.cta_20400100200000.Total20400100200000;
                if (current.cta_20400100300000 != null && current.cta_20400100300000.Total20400100300000 != 0)
                    current.Total20400100000000 += (Decimal)current.cta_20400100300000.Total20400100300000;
                if (current.cta_20400100400000 != null && current.cta_20400100400000.Total20400100400000 != 0)
                    current.Total20400100000000 += (Decimal)current.cta_20400100400000.Total20400100400000;
                if (current.cta_20400100500000 != null && current.cta_20400100500000.Total20400100500000 != 0)
                    current.Total20400100000000 += (Decimal)current.cta_20400100500000.Total20400100500000;
                if (current.cta_20400100600000 != null && current.cta_20400100600000.Total20400100600000 != 0)
                    current.Total20400100000000 += (Decimal)current.cta_20400100600000.Total20400100600000;
                if (current.cta_20400100700000 != null && current.cta_20400100700000.Total20400100700000 != 0)
                    current.Total20400100000000 += (Decimal)current.cta_20400100700000.Total20400100700000;
                if (current.cta_20400100800000 != null && current.cta_20400100800000.Total20400100800000 != 0)
                    current.Total20400100000000 += (Decimal)current.cta_20400100800000.Total20400100800000;
                if (current.cta_20400100900000 != null && current.cta_20400100900000.Total20400100900000 != 0)
                    current.Total20400100000000 += (Decimal)current.cta_20400100900000.Total20400100900000;
                if (current.cta_20400109900000 != null && current.cta_20400109900000.Total20400109900000 != 0)
                    current.Total20400100000000 += (Decimal)current.cta_20400109900000.Total20400109900000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200200000;
                current.Total20400200200000 = 0;
                if (current.cta_20400200201000 != null)
                    current.Total20400200200000 += (Decimal)current.cta_20400200201000;
                if (current.cta_20400200202000 != null)
                    current.Total20400200200000 += (Decimal)current.cta_20400200202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200300000;
                current.Total20400200300000 = 0;
                if (current.cta_20400200301000 != null)
                    current.Total20400200300000 += (Decimal)current.cta_20400200301000;
                if (current.cta_20400200302000 != null)
                    current.Total20400200300000 += (Decimal)current.cta_20400200302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200400000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200400000.cta_20400200401000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200400000.cta_20400200401000;
                current.Total20400200401000 = 0;
                if (current.cta_20400200401010 != null)
                    current.Total20400200401000 += (Decimal)current.cta_20400200401010;
                if (current.cta_20400200401020 != null)
                    current.Total20400200401000 += (Decimal)current.cta_20400200401020;
                if (current.cta_20400200401090 != null)
                    current.Total20400200401000 += (Decimal)current.cta_20400200401090;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200400000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200400000.cta_20400200402000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200400000.cta_20400200402000;
                current.Total20400200402000 = 0;
                if (current.cta_20400200402010 != null)
                    current.Total20400200402000 += (Decimal)current.cta_20400200402010;
                if (current.cta_20400200402020 != null)
                    current.Total20400200402000 += (Decimal)current.cta_20400200402020;
                if (current.cta_20400200402090 != null)
                    current.Total20400200402000 += (Decimal)current.cta_20400200402090;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200400000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200400000;
                current.Total20400200400000 = 0;
                if (current.cta_20400200401000 != null && current.cta_20400200401000.Total20400200401000 != 0)
                    current.Total20400200400000 += (Decimal)current.cta_20400200401000.Total20400200401000;
                if (current.cta_20400200402000 != null && current.cta_20400200402000.Total20400200402000 != 0)
                    current.Total20400200400000 += (Decimal)current.cta_20400200402000.Total20400200402000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200500000;
                current.Total20400200500000 = 0;
                if (current.cta_20400200501000 != null)
                    current.Total20400200500000 += (Decimal)current.cta_20400200501000;
                if (current.cta_20400200502000 != null)
                    current.Total20400200500000 += (Decimal)current.cta_20400200502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200600000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200600000.cta_20400200601000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200600000.cta_20400200601000;
                current.Total20400200601000 = 0;
                if (current.cta_20400200601010 != null)
                    current.Total20400200601000 += (Decimal)current.cta_20400200601010;
                if (current.cta_20400200601020 != null)
                    current.Total20400200601000 += (Decimal)current.cta_20400200601020;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200600000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200600000.cta_20400200602000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200600000.cta_20400200602000;
                current.Total20400200602000 = 0;
                if (current.cta_20400200602010 != null)
                    current.Total20400200602000 += (Decimal)current.cta_20400200602010;
                if (current.cta_20400200602020 != null)
                    current.Total20400200602000 += (Decimal)current.cta_20400200602020;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200600000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200600000;
                current.Total20400200600000 = 0;
                if (current.cta_20400200601000 != null && current.cta_20400200601000.Total20400200601000 != 0)
                    current.Total20400200600000 += (Decimal)current.cta_20400200601000.Total20400200601000;
                if (current.cta_20400200602000 != null && current.cta_20400200602000.Total20400200602000 != 0)
                    current.Total20400200600000 += (Decimal)current.cta_20400200602000.Total20400200602000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200700000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200700000.cta_20400200701000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200700000.cta_20400200701000;
                current.Total20400200701000 = 0;
                if (current.cta_20400200701010 != null)
                    current.Total20400200701000 += (Decimal)current.cta_20400200701010;
                if (current.cta_20400200701020 != null)
                    current.Total20400200701000 += (Decimal)current.cta_20400200701020;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200700000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200700000.cta_20400200702000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200700000.cta_20400200702000;
                current.Total20400200702000 = 0;
                if (current.cta_20400200702010 != null)
                    current.Total20400200702000 += (Decimal)current.cta_20400200702010;
                if (current.cta_20400200702020 != null)
                    current.Total20400200702000 += (Decimal)current.cta_20400200702020;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200700000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200700000;
                current.Total20400200700000 = 0;
                if (current.cta_20400200701000 != null && current.cta_20400200701000.Total20400200701000 != 0)
                    current.Total20400200700000 += (Decimal)current.cta_20400200701000.Total20400200701000;
                if (current.cta_20400200702000 != null && current.cta_20400200702000.Total20400200702000 != 0)
                    current.Total20400200700000 += (Decimal)current.cta_20400200702000.Total20400200702000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200800000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200800000;
                current.Total20400200800000 = 0;
                if (current.cta_20400200801000 != null)
                    current.Total20400200800000 += (Decimal)current.cta_20400200801000;
                if (current.cta_20400200802000 != null)
                    current.Total20400200800000 += (Decimal)current.cta_20400200802000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200900000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400200900000;
                current.Total20400200900000 = 0;
                if (current.cta_20400200901000 != null)
                    current.Total20400200900000 += (Decimal)current.cta_20400200901000;
                if (current.cta_20400200902000 != null)
                    current.Total20400200900000 += (Decimal)current.cta_20400200902000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201000000;
                current.Total20400201000000 = 0;
                if (current.cta_20400201001000 != null)
                    current.Total20400201000000 += (Decimal)current.cta_20400201001000;
                if (current.cta_20400201002000 != null)
                    current.Total20400201000000 += (Decimal)current.cta_20400201002000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201100000;
                current.Total20400201100000 = 0;
                if (current.cta_20400201101000 != null)
                    current.Total20400201100000 += (Decimal)current.cta_20400201101000;
                if (current.cta_20400201102000 != null)
                    current.Total20400201100000 += (Decimal)current.cta_20400201102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201300000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201300000.cta_20400201301000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201300000.cta_20400201301000;
                current.Total20400201301000 = 0;
                if (current.cta_20400201301990 != null)
                    current.Total20400201301000 += (Decimal)current.cta_20400201301990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201300000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201300000.cta_20400201302000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201300000.cta_20400201302000;
                current.Total20400201302000 = 0;
                if (current.cta_20400201302990 != null)
                    current.Total20400201302000 += (Decimal)current.cta_20400201302990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201300000;
                current.Total20400201300000 = 0;
                if (current.cta_20400201301000 != null && current.cta_20400201301000.Total20400201301000 != 0)
                    current.Total20400201300000 += (Decimal)current.cta_20400201301000.Total20400201301000;
                if (current.cta_20400201302000 != null && current.cta_20400201302000.Total20400201302000 != 0)
                    current.Total20400201300000 += (Decimal)current.cta_20400201302000.Total20400201302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201600000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201600000.cta_20400201601000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201600000.cta_20400201601000;
                current.Total20400201601000 = 0;
                if (current.cta_20400201601010 != null)
                    current.Total20400201601000 += (Decimal)current.cta_20400201601010;
                if (current.cta_20400201601020 != null)
                    current.Total20400201601000 += (Decimal)current.cta_20400201601020;
                if (current.cta_20400201601030 != null)
                    current.Total20400201601000 += (Decimal)current.cta_20400201601030;
                if (current.cta_20400201601990 != null)
                    current.Total20400201601000 += (Decimal)current.cta_20400201601990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201600000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201600000.cta_20400201602000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201600000.cta_20400201602000;
                current.Total20400201602000 = 0;
                if (current.cta_20400201602010 != null)
                    current.Total20400201602000 += (Decimal)current.cta_20400201602010;
                if (current.cta_20400201602020 != null)
                    current.Total20400201602000 += (Decimal)current.cta_20400201602020;
                if (current.cta_20400201602030 != null)
                    current.Total20400201602000 += (Decimal)current.cta_20400201602030;
                if (current.cta_20400201602990 != null)
                    current.Total20400201602000 += (Decimal)current.cta_20400201602990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201600000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201600000;
                current.Total20400201600000 = 0;
                if (current.cta_20400201601000 != null && current.cta_20400201601000.Total20400201601000 != 0)
                    current.Total20400201600000 += (Decimal)current.cta_20400201601000.Total20400201601000;
                if (current.cta_20400201602000 != null && current.cta_20400201602000.Total20400201602000 != 0)
                    current.Total20400201600000 += (Decimal)current.cta_20400201602000.Total20400201602000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201900000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400201900000;
                current.Total20400201900000 = 0;
                if (current.cta_20400201901000 != null)
                    current.Total20400201900000 += (Decimal)current.cta_20400201901000;
                if (current.cta_20400201902000 != null)
                    current.Total20400201900000 += (Decimal)current.cta_20400201902000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202000000;
                current.Total20400202000000 = 0;
                if (current.cta_20400202001000 != null)
                    current.Total20400202000000 += (Decimal)current.cta_20400202001000;
                if (current.cta_20400202002000 != null)
                    current.Total20400202000000 += (Decimal)current.cta_20400202002000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202100000;
                current.Total20400202100000 = 0;
                if (current.cta_20400202101000 != null)
                    current.Total20400202100000 += (Decimal)current.cta_20400202101000;
                if (current.cta_20400202102000 != null)
                    current.Total20400202100000 += (Decimal)current.cta_20400202102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202200000;
                current.Total20400202200000 = 0;
                if (current.cta_20400202201000 != null)
                    current.Total20400202200000 += (Decimal)current.cta_20400202201000;
                if (current.cta_20400202202000 != null)
                    current.Total20400202200000 += (Decimal)current.cta_20400202202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202300000;
                current.Total20400202300000 = 0;
                if (current.cta_20400202301000 != null)
                    current.Total20400202300000 += (Decimal)current.cta_20400202301000;
                if (current.cta_20400202302000 != null)
                    current.Total20400202300000 += (Decimal)current.cta_20400202302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202400000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202400000;
                current.Total20400202400000 = 0;
                if (current.cta_20400202401000 != null)
                    current.Total20400202400000 += (Decimal)current.cta_20400202401000;
                if (current.cta_20400202402000 != null)
                    current.Total20400202400000 += (Decimal)current.cta_20400202402000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202500000;
                current.Total20400202500000 = 0;
                if (current.cta_20400202501000 != null)
                    current.Total20400202500000 += (Decimal)current.cta_20400202501000;
                if (current.cta_20400202502000 != null)
                    current.Total20400202500000 += (Decimal)current.cta_20400202502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202600000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202600000.cta_20400202601000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202600000.cta_20400202601000;
                current.Total20400202601000 = 0;
                if (current.cta_20400202601010 != null)
                    current.Total20400202601000 += (Decimal)current.cta_20400202601010;
                if (current.cta_20400202601020 != null)
                    current.Total20400202601000 += (Decimal)current.cta_20400202601020;
                if (current.cta_20400202601030 != null)
                    current.Total20400202601000 += (Decimal)current.cta_20400202601030;
                if (current.cta_20400202601040 != null)
                    current.Total20400202601000 += (Decimal)current.cta_20400202601040;
                if (current.cta_20400202601050 != null)
                    current.Total20400202601000 += (Decimal)current.cta_20400202601050;
                if (current.cta_20400202601990 != null)
                    current.Total20400202601000 += (Decimal)current.cta_20400202601990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202600000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202600000.cta_20400202602000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202600000.cta_20400202602000;
                current.Total20400202602000 = 0;
                if (current.cta_20400202602010 != null)
                    current.Total20400202602000 += (Decimal)current.cta_20400202602010;
                if (current.cta_20400202602020 != null)
                    current.Total20400202602000 += (Decimal)current.cta_20400202602020;
                if (current.cta_20400202602030 != null)
                    current.Total20400202602000 += (Decimal)current.cta_20400202602030;
                if (current.cta_20400202602040 != null)
                    current.Total20400202602000 += (Decimal)current.cta_20400202602040;
                if (current.cta_20400202602050 != null)
                    current.Total20400202602000 += (Decimal)current.cta_20400202602050;
                if (current.cta_20400202602990 != null)
                    current.Total20400202602000 += (Decimal)current.cta_20400202602990;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202600000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202600000;
                current.Total20400202600000 = 0;
                if (current.cta_20400202601000 != null && current.cta_20400202601000.Total20400202601000 != 0)
                    current.Total20400202600000 += (Decimal)current.cta_20400202601000.Total20400202601000;
                if (current.cta_20400202602000 != null && current.cta_20400202602000.Total20400202602000 != 0)
                    current.Total20400202600000 += (Decimal)current.cta_20400202602000.Total20400202602000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202700000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202700000;
                current.Total20400202700000 = 0;
                if (current.cta_20400202701000 != null)
                    current.Total20400202700000 += (Decimal)current.cta_20400202701000;
                if (current.cta_20400202702000 != null)
                    current.Total20400202700000 += (Decimal)current.cta_20400202702000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202800000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202800000;
                current.Total20400202800000 = 0;
                if (current.cta_20400202801000 != null)
                    current.Total20400202800000 += (Decimal)current.cta_20400202801000;
                if (current.cta_20400202802000 != null)
                    current.Total20400202800000 += (Decimal)current.cta_20400202802000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202900000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400202900000;
                current.Total20400202900000 = 0;
                if (current.cta_20400202901000 != null)
                    current.Total20400202900000 += (Decimal)current.cta_20400202901000;
                if (current.cta_20400202902000 != null)
                    current.Total20400202900000 += (Decimal)current.cta_20400202902000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203000000;
                current.Total20400203000000 = 0;
                if (current.cta_20400203001000 != null)
                    current.Total20400203000000 += (Decimal)current.cta_20400203001000;
                if (current.cta_20400203002000 != null)
                    current.Total20400203000000 += (Decimal)current.cta_20400203002000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203100000;
                current.Total20400203100000 = 0;
                if (current.cta_20400203101000 != null)
                    current.Total20400203100000 += (Decimal)current.cta_20400203101000;
                if (current.cta_20400203102000 != null)
                    current.Total20400203100000 += (Decimal)current.cta_20400203102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203200000;
                current.Total20400203200000 = 0;
                if (current.cta_20400203201000 != null)
                    current.Total20400203200000 += (Decimal)current.cta_20400203201000;
                if (current.cta_20400203202000 != null)
                    current.Total20400203200000 += (Decimal)current.cta_20400203202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203300000;
                current.Total20400203300000 = 0;
                if (current.cta_20400203301000 != null)
                    current.Total20400203300000 += (Decimal)current.cta_20400203301000;
                if (current.cta_20400203302000 != null)
                    current.Total20400203300000 += (Decimal)current.cta_20400203302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203500000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203500000.cta_20400203501000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203500000.cta_20400203501000;
                current.Total20400203501000 = 0;
                if (current.cta_20400203501010 != null)
                    current.Total20400203501000 += (Decimal)current.cta_20400203501010;
                if (current.cta_20400203501020 != null)
                    current.Total20400203501000 += (Decimal)current.cta_20400203501020;
                if (current.cta_20400203501030 != null)
                    current.Total20400203501000 += (Decimal)current.cta_20400203501030;
                if (current.cta_20400203501040 != null)
                    current.Total20400203501000 += (Decimal)current.cta_20400203501040;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203500000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203500000.cta_20400203502000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203500000.cta_20400203502000;
                current.Total20400203502000 = 0;
                if (current.cta_20400203502010 != null)
                    current.Total20400203502000 += (Decimal)current.cta_20400203502010;
                if (current.cta_20400203502020 != null)
                    current.Total20400203502000 += (Decimal)current.cta_20400203502020;
                if (current.cta_20400203502030 != null)
                    current.Total20400203502000 += (Decimal)current.cta_20400203502030;
                if (current.cta_20400203502040 != null)
                    current.Total20400203502000 += (Decimal)current.cta_20400203502040;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400203500000;
                current.Total20400203500000 = 0;
                if (current.cta_20400203501000 != null && current.cta_20400203501000.Total20400203501000 != 0)
                    current.Total20400203500000 += (Decimal)current.cta_20400203501000.Total20400203501000;
                if (current.cta_20400203502000 != null && current.cta_20400203502000.Total20400203502000 != 0)
                    current.Total20400203500000 += (Decimal)current.cta_20400203502000.Total20400203502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400204100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400204100000;
                current.Total20400204100000 = 0;
                if (current.cta_20400204101000 != null)
                    current.Total20400204100000 += (Decimal)current.cta_20400204101000;
                if (current.cta_20400204102000 != null)
                    current.Total20400204100000 += (Decimal)current.cta_20400204102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400204600000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400204600000;
                current.Total20400204600000 = 0;
                if (current.cta_20400204601000 != null)
                    current.Total20400204600000 += (Decimal)current.cta_20400204601000;
                if (current.cta_20400204602000 != null)
                    current.Total20400204600000 += (Decimal)current.cta_20400204602000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400209900000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000.cta_20400209900000;
                current.Total20400209900000 = 0;
                if (current.cta_20400209901000 != null)
                    current.Total20400209900000 += (Decimal)current.cta_20400209901000;
                if (current.cta_20400209902000 != null)
                    current.Total20400209900000 += (Decimal)current.cta_20400209902000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400200000000;
                current.Total20400200000000 = 0;
                if (current.cta_20400200200000 != null && current.cta_20400200200000.Total20400200200000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400200200000.Total20400200200000;
                if (current.cta_20400200300000 != null && current.cta_20400200300000.Total20400200300000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400200300000.Total20400200300000;
                if (current.cta_20400200400000 != null && current.cta_20400200400000.Total20400200400000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400200400000.Total20400200400000;
                if (current.cta_20400200500000 != null && current.cta_20400200500000.Total20400200500000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400200500000.Total20400200500000;
                if (current.cta_20400200600000 != null && current.cta_20400200600000.Total20400200600000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400200600000.Total20400200600000;
                if (current.cta_20400200700000 != null && current.cta_20400200700000.Total20400200700000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400200700000.Total20400200700000;
                if (current.cta_20400200800000 != null && current.cta_20400200800000.Total20400200800000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400200800000.Total20400200800000;
                if (current.cta_20400200900000 != null && current.cta_20400200900000.Total20400200900000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400200900000.Total20400200900000;
                if (current.cta_20400201000000 != null && current.cta_20400201000000.Total20400201000000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400201000000.Total20400201000000;
                if (current.cta_20400201100000 != null && current.cta_20400201100000.Total20400201100000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400201100000.Total20400201100000;
                if (current.cta_20400201300000 != null && current.cta_20400201300000.Total20400201300000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400201300000.Total20400201300000;
                if (current.cta_20400201600000 != null && current.cta_20400201600000.Total20400201600000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400201600000.Total20400201600000;
                if (current.cta_20400201900000 != null && current.cta_20400201900000.Total20400201900000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400201900000.Total20400201900000;
                if (current.cta_20400202000000 != null && current.cta_20400202000000.Total20400202000000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400202000000.Total20400202000000;
                if (current.cta_20400202100000 != null && current.cta_20400202100000.Total20400202100000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400202100000.Total20400202100000;
                if (current.cta_20400202200000 != null && current.cta_20400202200000.Total20400202200000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400202200000.Total20400202200000;
                if (current.cta_20400202300000 != null && current.cta_20400202300000.Total20400202300000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400202300000.Total20400202300000;
                if (current.cta_20400202400000 != null && current.cta_20400202400000.Total20400202400000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400202400000.Total20400202400000;
                if (current.cta_20400202500000 != null && current.cta_20400202500000.Total20400202500000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400202500000.Total20400202500000;
                if (current.cta_20400202600000 != null && current.cta_20400202600000.Total20400202600000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400202600000.Total20400202600000;
                if (current.cta_20400202700000 != null && current.cta_20400202700000.Total20400202700000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400202700000.Total20400202700000;
                if (current.cta_20400202800000 != null && current.cta_20400202800000.Total20400202800000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400202800000.Total20400202800000;
                if (current.cta_20400202900000 != null && current.cta_20400202900000.Total20400202900000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400202900000.Total20400202900000;
                if (current.cta_20400203000000 != null && current.cta_20400203000000.Total20400203000000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400203000000.Total20400203000000;
                if (current.cta_20400203100000 != null && current.cta_20400203100000.Total20400203100000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400203100000.Total20400203100000;
                if (current.cta_20400203200000 != null && current.cta_20400203200000.Total20400203200000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400203200000.Total20400203200000;
                if (current.cta_20400203300000 != null && current.cta_20400203300000.Total20400203300000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400203300000.Total20400203300000;
                if (current.cta_20400203500000 != null && current.cta_20400203500000.Total20400203500000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400203500000.Total20400203500000;
                if (current.cta_20400204100000 != null && current.cta_20400204100000.Total20400204100000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400204100000.Total20400204100000;
                if (current.cta_20400204600000 != null && current.cta_20400204600000.Total20400204600000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400204600000.Total20400204600000;
                if (current.cta_20400209900000 != null && current.cta_20400209900000.Total20400209900000 != 0)
                    current.Total20400200000000 += (Decimal)current.cta_20400209900000.Total20400209900000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400300000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400300000000.cta_20400300100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400300000000.cta_20400300100000;
                current.Total20400300100000 = 0;
                if (current.cta_20400300101000 != null)
                    current.Total20400300100000 += (Decimal)current.cta_20400300101000;
                if (current.cta_20400300102000 != null)
                    current.Total20400300100000 += (Decimal)current.cta_20400300102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400300000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400300000000.cta_20400300300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400300000000.cta_20400300300000;
                current.Total20400300300000 = 0;
                if (current.cta_20400300301000 != null)
                    current.Total20400300300000 += (Decimal)current.cta_20400300301000;
                if (current.cta_20400300302000 != null)
                    current.Total20400300300000 += (Decimal)current.cta_20400300302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400300000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400300000000.cta_20400300500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400300000000.cta_20400300500000;
                current.Total20400300500000 = 0;
                if (current.cta_20400300501000 != null)
                    current.Total20400300500000 += (Decimal)current.cta_20400300501000;
                if (current.cta_20400300502000 != null)
                    current.Total20400300500000 += (Decimal)current.cta_20400300502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400300000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400300000000.cta_20400309900000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400300000000.cta_20400309900000;
                current.Total20400309900000 = 0;
                if (current.cta_20400309901000 != null)
                    current.Total20400309900000 += (Decimal)current.cta_20400309901000;
                if (current.cta_20400309902000 != null)
                    current.Total20400309900000 += (Decimal)current.cta_20400309902000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400300000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400300000000;
                current.Total20400300000000 = 0;
                if (current.cta_20400300100000 != null && current.cta_20400300100000.Total20400300100000 != 0)
                    current.Total20400300000000 += (Decimal)current.cta_20400300100000.Total20400300100000;
                if (current.cta_20400300300000 != null && current.cta_20400300300000.Total20400300300000 != 0)
                    current.Total20400300000000 += (Decimal)current.cta_20400300300000.Total20400300300000;
                if (current.cta_20400300500000 != null && current.cta_20400300500000.Total20400300500000 != 0)
                    current.Total20400300000000 += (Decimal)current.cta_20400300500000.Total20400300500000;
                if (current.cta_20400309900000 != null && current.cta_20400309900000.Total20400309900000 != 0)
                    current.Total20400300000000 += (Decimal)current.cta_20400309900000.Total20400309900000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400600000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400600000000.cta_20400600200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400600000000.cta_20400600200000;
                current.Total20400600200000 = 0;
                if (current.cta_20400600201000 != null)
                    current.Total20400600200000 += (Decimal)current.cta_20400600201000;
                if (current.cta_20400600202000 != null)
                    current.Total20400600200000 += (Decimal)current.cta_20400600202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400600000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400600000000;
                current.Total20400600000000 = 0;
                if (current.cta_20400600200000 != null && current.cta_20400600200000.Total20400600200000 != 0)
                    current.Total20400600000000 += (Decimal)current.cta_20400600200000.Total20400600200000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400800000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400800000000.cta_20400800100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400800000000.cta_20400800100000;
                current.Total20400800100000 = 0;
                if (current.cta_20400800101000 != null)
                    current.Total20400800100000 += (Decimal)current.cta_20400800101000;
                if (current.cta_20400800102000 != null)
                    current.Total20400800100000 += (Decimal)current.cta_20400800102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400800000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400800000000.cta_20400800200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400800000000.cta_20400800200000;
                current.Total20400800200000 = 0;
                if (current.cta_20400800201000 != null)
                    current.Total20400800200000 += (Decimal)current.cta_20400800201000;
                if (current.cta_20400800202000 != null)
                    current.Total20400800200000 += (Decimal)current.cta_20400800202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400800000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400800000000.cta_20400800600000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400800000000.cta_20400800600000;
                current.Total20400800600000 = 0;
                if (current.cta_20400800601000 != null)
                    current.Total20400800600000 += (Decimal)current.cta_20400800601000;
                if (current.cta_20400800602000 != null)
                    current.Total20400800600000 += (Decimal)current.cta_20400800602000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null && modelo.cta_20000000000000.cta_20400000000000.cta_20400800000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000.cta_20400800000000;
                current.Total20400800000000 = 0;
                if (current.cta_20400800100000 != null && current.cta_20400800100000.Total20400800100000 != 0)
                    current.Total20400800000000 += (Decimal)current.cta_20400800100000.Total20400800100000;
                if (current.cta_20400800200000 != null && current.cta_20400800200000.Total20400800200000 != 0)
                    current.Total20400800000000 += (Decimal)current.cta_20400800200000.Total20400800200000;
                if (current.cta_20400800600000 != null && current.cta_20400800600000.Total20400800600000 != 0)
                    current.Total20400800000000 += (Decimal)current.cta_20400800600000.Total20400800600000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20400000000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20400000000000;
                current.Total20400000000000 = 0;
                if (current.cta_20400100000000 != null && current.cta_20400100000000.Total20400100000000 != 0)
                    current.Total20400000000000 += (Decimal)current.cta_20400100000000.Total20400100000000;
                if (current.cta_20400200000000 != null && current.cta_20400200000000.Total20400200000000 != 0)
                    current.Total20400000000000 += (Decimal)current.cta_20400200000000.Total20400200000000;
                if (current.cta_20400300000000 != null && current.cta_20400300000000.Total20400300000000 != 0)
                    current.Total20400000000000 += (Decimal)current.cta_20400300000000.Total20400300000000;
                if (current.cta_20400600000000 != null && current.cta_20400600000000.Total20400600000000 != 0)
                    current.Total20400000000000 += (Decimal)current.cta_20400600000000.Total20400600000000;
                if (current.cta_20400800000000 != null && current.cta_20400800000000.Total20400800000000 != 0)
                    current.Total20400000000000 += (Decimal)current.cta_20400800000000.Total20400800000000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100100000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100100000.cta_20500100101000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100100000.cta_20500100101000;
                current.Total20500100101000 = 0;
                if (current.cta_20500100101010 != null)
                    current.Total20500100101000 += (Decimal)current.cta_20500100101010;
                if (current.cta_20500100101020 != null)
                    current.Total20500100101000 += (Decimal)current.cta_20500100101020;
                if (current.cta_20500100101030 != null)
                    current.Total20500100101000 += (Decimal)current.cta_20500100101030;
                if (current.cta_20500100101040 != null)
                    current.Total20500100101000 += (Decimal)current.cta_20500100101040;
                if (current.cta_20500100101050 != null)
                    current.Total20500100101000 += (Decimal)current.cta_20500100101050;
                if (current.cta_20500100101060 != null)
                    current.Total20500100101000 += (Decimal)current.cta_20500100101060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100100000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100100000.cta_20500100102000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100100000.cta_20500100102000;
                current.Total20500100102000 = 0;
                if (current.cta_20500100102010 != null)
                    current.Total20500100102000 += (Decimal)current.cta_20500100102010;
                if (current.cta_20500100102020 != null)
                    current.Total20500100102000 += (Decimal)current.cta_20500100102020;
                if (current.cta_20500100102030 != null)
                    current.Total20500100102000 += (Decimal)current.cta_20500100102030;
                if (current.cta_20500100102040 != null)
                    current.Total20500100102000 += (Decimal)current.cta_20500100102040;
                if (current.cta_20500100102050 != null)
                    current.Total20500100102000 += (Decimal)current.cta_20500100102050;
                if (current.cta_20500100102060 != null)
                    current.Total20500100102000 += (Decimal)current.cta_20500100102060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100100000;
                current.Total20500100100000 = 0;
                if (current.cta_20500100101000 != null && current.cta_20500100101000.Total20500100101000 != 0)
                    current.Total20500100100000 += (Decimal)current.cta_20500100101000.Total20500100101000;
                if (current.cta_20500100102000 != null && current.cta_20500100102000.Total20500100102000 != 0)
                    current.Total20500100100000 += (Decimal)current.cta_20500100102000.Total20500100102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100200000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100200000.cta_20500100201000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100200000.cta_20500100201000;
                current.Total20500100201000 = 0;
                if (current.cta_20500100201010 != null)
                    current.Total20500100201000 += (Decimal)current.cta_20500100201010;
                if (current.cta_20500100201020 != null)
                    current.Total20500100201000 += (Decimal)current.cta_20500100201020;
                if (current.cta_20500100201030 != null)
                    current.Total20500100201000 += (Decimal)current.cta_20500100201030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100200000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100200000.cta_20500100202000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100200000.cta_20500100202000;
                current.Total20500100202000 = 0;
                if (current.cta_20500100202010 != null)
                    current.Total20500100202000 += (Decimal)current.cta_20500100202010;
                if (current.cta_20500100202020 != null)
                    current.Total20500100202000 += (Decimal)current.cta_20500100202020;
                if (current.cta_20500100202030 != null)
                    current.Total20500100202000 += (Decimal)current.cta_20500100202030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100200000;
                current.Total20500100200000 = 0;
                if (current.cta_20500100201000 != null && current.cta_20500100201000.Total20500100201000 != 0)
                    current.Total20500100200000 += (Decimal)current.cta_20500100201000.Total20500100201000;
                if (current.cta_20500100202000 != null && current.cta_20500100202000.Total20500100202000 != 0)
                    current.Total20500100200000 += (Decimal)current.cta_20500100202000.Total20500100202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100300000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100300000.cta_20500100301000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100300000.cta_20500100301000;
                current.Total20500100301000 = 0;
                if (current.cta_20500100301010 != null)
                    current.Total20500100301000 += (Decimal)current.cta_20500100301010;
                if (current.cta_20500100301020 != null)
                    current.Total20500100301000 += (Decimal)current.cta_20500100301020;
                if (current.cta_20500100301030 != null)
                    current.Total20500100301000 += (Decimal)current.cta_20500100301030;
                if (current.cta_20500100301040 != null)
                    current.Total20500100301000 += (Decimal)current.cta_20500100301040;
                if (current.cta_20500100301050 != null)
                    current.Total20500100301000 += (Decimal)current.cta_20500100301050;
                if (current.cta_20500100301060 != null)
                    current.Total20500100301000 += (Decimal)current.cta_20500100301060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100300000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100300000.cta_20500100302000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100300000.cta_20500100302000;
                current.Total20500100302000 = 0;
                if (current.cta_20500100302010 != null)
                    current.Total20500100302000 += (Decimal)current.cta_20500100302010;
                if (current.cta_20500100302020 != null)
                    current.Total20500100302000 += (Decimal)current.cta_20500100302020;
                if (current.cta_20500100302030 != null)
                    current.Total20500100302000 += (Decimal)current.cta_20500100302030;
                if (current.cta_20500100302040 != null)
                    current.Total20500100302000 += (Decimal)current.cta_20500100302040;
                if (current.cta_20500100302050 != null)
                    current.Total20500100302000 += (Decimal)current.cta_20500100302050;
                if (current.cta_20500100302060 != null)
                    current.Total20500100302000 += (Decimal)current.cta_20500100302060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100300000;
                current.Total20500100300000 = 0;
                if (current.cta_20500100301000 != null && current.cta_20500100301000.Total20500100301000 != 0)
                    current.Total20500100300000 += (Decimal)current.cta_20500100301000.Total20500100301000;
                if (current.cta_20500100302000 != null && current.cta_20500100302000.Total20500100302000 != 0)
                    current.Total20500100300000 += (Decimal)current.cta_20500100302000.Total20500100302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100400000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100400000.cta_20500100401000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100400000.cta_20500100401000;
                current.Total20500100401000 = 0;
                if (current.cta_20500100401010 != null)
                    current.Total20500100401000 += (Decimal)current.cta_20500100401010;
                if (current.cta_20500100401020 != null)
                    current.Total20500100401000 += (Decimal)current.cta_20500100401020;
                if (current.cta_20500100401030 != null)
                    current.Total20500100401000 += (Decimal)current.cta_20500100401030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100400000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100400000.cta_20500100402000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100400000.cta_20500100402000;
                current.Total20500100402000 = 0;
                if (current.cta_20500100402010 != null)
                    current.Total20500100402000 += (Decimal)current.cta_20500100402010;
                if (current.cta_20500100402020 != null)
                    current.Total20500100402000 += (Decimal)current.cta_20500100402020;
                if (current.cta_20500100402030 != null)
                    current.Total20500100402000 += (Decimal)current.cta_20500100402030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100400000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100400000;
                current.Total20500100400000 = 0;
                if (current.cta_20500100401000 != null && current.cta_20500100401000.Total20500100401000 != 0)
                    current.Total20500100400000 += (Decimal)current.cta_20500100401000.Total20500100401000;
                if (current.cta_20500100402000 != null && current.cta_20500100402000.Total20500100402000 != 0)
                    current.Total20500100400000 += (Decimal)current.cta_20500100402000.Total20500100402000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100500000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100500000.cta_20500100501000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100500000.cta_20500100501000;
                current.Total20500100501000 = 0;
                if (current.cta_20500100501010 != null)
                    current.Total20500100501000 += (Decimal)current.cta_20500100501010;
                if (current.cta_20500100501020 != null)
                    current.Total20500100501000 += (Decimal)current.cta_20500100501020;
                if (current.cta_20500100501030 != null)
                    current.Total20500100501000 += (Decimal)current.cta_20500100501030;
                if (current.cta_20500100501040 != null)
                    current.Total20500100501000 += (Decimal)current.cta_20500100501040;
                if (current.cta_20500100501050 != null)
                    current.Total20500100501000 += (Decimal)current.cta_20500100501050;
                if (current.cta_20500100501060 != null)
                    current.Total20500100501000 += (Decimal)current.cta_20500100501060;
                if (current.cta_20500100501070 != null)
                    current.Total20500100501000 += (Decimal)current.cta_20500100501070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100500000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100500000.cta_20500100502000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100500000.cta_20500100502000;
                current.Total20500100502000 = 0;
                if (current.cta_20500100502010 != null)
                    current.Total20500100502000 += (Decimal)current.cta_20500100502010;
                if (current.cta_20500100502020 != null)
                    current.Total20500100502000 += (Decimal)current.cta_20500100502020;
                if (current.cta_20500100502030 != null)
                    current.Total20500100502000 += (Decimal)current.cta_20500100502030;
                if (current.cta_20500100502040 != null)
                    current.Total20500100502000 += (Decimal)current.cta_20500100502040;
                if (current.cta_20500100502050 != null)
                    current.Total20500100502000 += (Decimal)current.cta_20500100502050;
                if (current.cta_20500100502060 != null)
                    current.Total20500100502000 += (Decimal)current.cta_20500100502060;
                if (current.cta_20500100502070 != null)
                    current.Total20500100502000 += (Decimal)current.cta_20500100502070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100500000;
                current.Total20500100500000 = 0;
                if (current.cta_20500100501000 != null && current.cta_20500100501000.Total20500100501000 != 0)
                    current.Total20500100500000 += (Decimal)current.cta_20500100501000.Total20500100501000;
                if (current.cta_20500100502000 != null && current.cta_20500100502000.Total20500100502000 != 0)
                    current.Total20500100500000 += (Decimal)current.cta_20500100502000.Total20500100502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100600000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100600000.cta_20500100601000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100600000.cta_20500100601000;
                current.Total20500100601000 = 0;
                if (current.cta_20500100601010 != null)
                    current.Total20500100601000 += (Decimal)current.cta_20500100601010;
                if (current.cta_20500100601020 != null)
                    current.Total20500100601000 += (Decimal)current.cta_20500100601020;
                if (current.cta_20500100601030 != null)
                    current.Total20500100601000 += (Decimal)current.cta_20500100601030;
                if (current.cta_20500100601040 != null)
                    current.Total20500100601000 += (Decimal)current.cta_20500100601040;
                if (current.cta_20500100601050 != null)
                    current.Total20500100601000 += (Decimal)current.cta_20500100601050;
                if (current.cta_20500100601060 != null)
                    current.Total20500100601000 += (Decimal)current.cta_20500100601060;
                if (current.cta_20500100601070 != null)
                    current.Total20500100601000 += (Decimal)current.cta_20500100601070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100600000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100600000.cta_20500100602000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100600000.cta_20500100602000;
                current.Total20500100602000 = 0;
                if (current.cta_20500100602010 != null)
                    current.Total20500100602000 += (Decimal)current.cta_20500100602010;
                if (current.cta_20500100602020 != null)
                    current.Total20500100602000 += (Decimal)current.cta_20500100602020;
                if (current.cta_20500100602030 != null)
                    current.Total20500100602000 += (Decimal)current.cta_20500100602030;
                if (current.cta_20500100602040 != null)
                    current.Total20500100602000 += (Decimal)current.cta_20500100602040;
                if (current.cta_20500100602050 != null)
                    current.Total20500100602000 += (Decimal)current.cta_20500100602050;
                if (current.cta_20500100602060 != null)
                    current.Total20500100602000 += (Decimal)current.cta_20500100602060;
                if (current.cta_20500100602070 != null)
                    current.Total20500100602000 += (Decimal)current.cta_20500100602070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100600000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000.cta_20500100600000;
                current.Total20500100600000 = 0;
                if (current.cta_20500100601000 != null && current.cta_20500100601000.Total20500100601000 != 0)
                    current.Total20500100600000 += (Decimal)current.cta_20500100601000.Total20500100601000;
                if (current.cta_20500100602000 != null && current.cta_20500100602000.Total20500100602000 != 0)
                    current.Total20500100600000 += (Decimal)current.cta_20500100602000.Total20500100602000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500100000000;
                current.Total20500100000000 = 0;
                if (current.cta_20500100100000 != null && current.cta_20500100100000.Total20500100100000 != 0)
                    current.Total20500100000000 += (Decimal)current.cta_20500100100000.Total20500100100000;
                if (current.cta_20500100200000 != null && current.cta_20500100200000.Total20500100200000 != 0)
                    current.Total20500100000000 += (Decimal)current.cta_20500100200000.Total20500100200000;
                if (current.cta_20500100300000 != null && current.cta_20500100300000.Total20500100300000 != 0)
                    current.Total20500100000000 += (Decimal)current.cta_20500100300000.Total20500100300000;
                if (current.cta_20500100400000 != null && current.cta_20500100400000.Total20500100400000 != 0)
                    current.Total20500100000000 += (Decimal)current.cta_20500100400000.Total20500100400000;
                if (current.cta_20500100500000 != null && current.cta_20500100500000.Total20500100500000 != 0)
                    current.Total20500100000000 += (Decimal)current.cta_20500100500000.Total20500100500000;
                if (current.cta_20500100600000 != null && current.cta_20500100600000.Total20500100600000 != 0)
                    current.Total20500100000000 += (Decimal)current.cta_20500100600000.Total20500100600000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200100000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200100000.cta_20500200101000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200100000.cta_20500200101000;
                current.Total20500200101000 = 0;
                if (current.cta_20500200101010 != null)
                    current.Total20500200101000 += (Decimal)current.cta_20500200101010;
                if (current.cta_20500200101020 != null)
                    current.Total20500200101000 += (Decimal)current.cta_20500200101020;
                if (current.cta_20500200101030 != null)
                    current.Total20500200101000 += (Decimal)current.cta_20500200101030;
                if (current.cta_20500200101040 != null)
                    current.Total20500200101000 += (Decimal)current.cta_20500200101040;
                if (current.cta_20500200101050 != null)
                    current.Total20500200101000 += (Decimal)current.cta_20500200101050;
                if (current.cta_20500200101060 != null)
                    current.Total20500200101000 += (Decimal)current.cta_20500200101060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200100000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200100000.cta_20500200102000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200100000.cta_20500200102000;
                current.Total20500200102000 = 0;
                if (current.cta_20500200102010 != null)
                    current.Total20500200102000 += (Decimal)current.cta_20500200102010;
                if (current.cta_20500200102020 != null)
                    current.Total20500200102000 += (Decimal)current.cta_20500200102020;
                if (current.cta_20500200102030 != null)
                    current.Total20500200102000 += (Decimal)current.cta_20500200102030;
                if (current.cta_20500200102040 != null)
                    current.Total20500200102000 += (Decimal)current.cta_20500200102040;
                if (current.cta_20500200102050 != null)
                    current.Total20500200102000 += (Decimal)current.cta_20500200102050;
                if (current.cta_20500200102060 != null)
                    current.Total20500200102000 += (Decimal)current.cta_20500200102060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200100000;
                current.Total20500200100000 = 0;
                if (current.cta_20500200101000 != null && current.cta_20500200101000.Total20500200101000 != 0)
                    current.Total20500200100000 += (Decimal)current.cta_20500200101000.Total20500200101000;
                if (current.cta_20500200102000 != null && current.cta_20500200102000.Total20500200102000 != 0)
                    current.Total20500200100000 += (Decimal)current.cta_20500200102000.Total20500200102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200200000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200200000.cta_20500200201000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200200000.cta_20500200201000;
                current.Total20500200201000 = 0;
                if (current.cta_20500200201010 != null)
                    current.Total20500200201000 += (Decimal)current.cta_20500200201010;
                if (current.cta_20500200201020 != null)
                    current.Total20500200201000 += (Decimal)current.cta_20500200201020;
                if (current.cta_20500200201030 != null)
                    current.Total20500200201000 += (Decimal)current.cta_20500200201030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200200000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200200000.cta_20500200202000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200200000.cta_20500200202000;
                current.Total20500200202000 = 0;
                if (current.cta_20500200202010 != null)
                    current.Total20500200202000 += (Decimal)current.cta_20500200202010;
                if (current.cta_20500200202020 != null)
                    current.Total20500200202000 += (Decimal)current.cta_20500200202020;
                if (current.cta_20500200202030 != null)
                    current.Total20500200202000 += (Decimal)current.cta_20500200202030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200200000;
                current.Total20500200200000 = 0;
                if (current.cta_20500200201000 != null && current.cta_20500200201000.Total20500200201000 != 0)
                    current.Total20500200200000 += (Decimal)current.cta_20500200201000.Total20500200201000;
                if (current.cta_20500200202000 != null && current.cta_20500200202000.Total20500200202000 != 0)
                    current.Total20500200200000 += (Decimal)current.cta_20500200202000.Total20500200202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200300000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200300000.cta_20500200301000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200300000.cta_20500200301000;
                current.Total20500200301000 = 0;
                if (current.cta_20500200301010 != null)
                    current.Total20500200301000 += (Decimal)current.cta_20500200301010;
                if (current.cta_20500200301020 != null)
                    current.Total20500200301000 += (Decimal)current.cta_20500200301020;
                if (current.cta_20500200301030 != null)
                    current.Total20500200301000 += (Decimal)current.cta_20500200301030;
                if (current.cta_20500200301040 != null)
                    current.Total20500200301000 += (Decimal)current.cta_20500200301040;
                if (current.cta_20500200301050 != null)
                    current.Total20500200301000 += (Decimal)current.cta_20500200301050;
                if (current.cta_20500200301060 != null)
                    current.Total20500200301000 += (Decimal)current.cta_20500200301060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200300000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200300000.cta_20500200302000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200300000.cta_20500200302000;
                current.Total20500200302000 = 0;
                if (current.cta_20500200302010 != null)
                    current.Total20500200302000 += (Decimal)current.cta_20500200302010;
                if (current.cta_20500200302020 != null)
                    current.Total20500200302000 += (Decimal)current.cta_20500200302020;
                if (current.cta_20500200302030 != null)
                    current.Total20500200302000 += (Decimal)current.cta_20500200302030;
                if (current.cta_20500200302040 != null)
                    current.Total20500200302000 += (Decimal)current.cta_20500200302040;
                if (current.cta_20500200302050 != null)
                    current.Total20500200302000 += (Decimal)current.cta_20500200302050;
                if (current.cta_20500200302060 != null)
                    current.Total20500200302000 += (Decimal)current.cta_20500200302060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200300000;
                current.Total20500200300000 = 0;
                if (current.cta_20500200301000 != null && current.cta_20500200301000.Total20500200301000 != 0)
                    current.Total20500200300000 += (Decimal)current.cta_20500200301000.Total20500200301000;
                if (current.cta_20500200302000 != null && current.cta_20500200302000.Total20500200302000 != 0)
                    current.Total20500200300000 += (Decimal)current.cta_20500200302000.Total20500200302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200400000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200400000.cta_20500200401000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200400000.cta_20500200401000;
                current.Total20500200401000 = 0;
                if (current.cta_20500200401010 != null)
                    current.Total20500200401000 += (Decimal)current.cta_20500200401010;
                if (current.cta_20500200401020 != null)
                    current.Total20500200401000 += (Decimal)current.cta_20500200401020;
                if (current.cta_20500200401030 != null)
                    current.Total20500200401000 += (Decimal)current.cta_20500200401030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200400000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200400000.cta_20500200402000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200400000.cta_20500200402000;
                current.Total20500200402000 = 0;
                if (current.cta_20500200402010 != null)
                    current.Total20500200402000 += (Decimal)current.cta_20500200402010;
                if (current.cta_20500200402020 != null)
                    current.Total20500200402000 += (Decimal)current.cta_20500200402020;
                if (current.cta_20500200402030 != null)
                    current.Total20500200402000 += (Decimal)current.cta_20500200402030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200400000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200400000;
                current.Total20500200400000 = 0;
                if (current.cta_20500200401000 != null && current.cta_20500200401000.Total20500200401000 != 0)
                    current.Total20500200400000 += (Decimal)current.cta_20500200401000.Total20500200401000;
                if (current.cta_20500200402000 != null && current.cta_20500200402000.Total20500200402000 != 0)
                    current.Total20500200400000 += (Decimal)current.cta_20500200402000.Total20500200402000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200500000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200500000.cta_20500200501000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200500000.cta_20500200501000;
                current.Total20500200501000 = 0;
                if (current.cta_20500200501010 != null)
                    current.Total20500200501000 += (Decimal)current.cta_20500200501010;
                if (current.cta_20500200501020 != null)
                    current.Total20500200501000 += (Decimal)current.cta_20500200501020;
                if (current.cta_20500200501030 != null)
                    current.Total20500200501000 += (Decimal)current.cta_20500200501030;
                if (current.cta_20500200501040 != null)
                    current.Total20500200501000 += (Decimal)current.cta_20500200501040;
                if (current.cta_20500200501050 != null)
                    current.Total20500200501000 += (Decimal)current.cta_20500200501050;
                if (current.cta_20500200501060 != null)
                    current.Total20500200501000 += (Decimal)current.cta_20500200501060;
                if (current.cta_20500200501070 != null)
                    current.Total20500200501000 += (Decimal)current.cta_20500200501070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200500000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200500000.cta_20500200502000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200500000.cta_20500200502000;
                current.Total20500200502000 = 0;
                if (current.cta_20500200502010 != null)
                    current.Total20500200502000 += (Decimal)current.cta_20500200502010;
                if (current.cta_20500200502020 != null)
                    current.Total20500200502000 += (Decimal)current.cta_20500200502020;
                if (current.cta_20500200502030 != null)
                    current.Total20500200502000 += (Decimal)current.cta_20500200502030;
                if (current.cta_20500200502040 != null)
                    current.Total20500200502000 += (Decimal)current.cta_20500200502040;
                if (current.cta_20500200502050 != null)
                    current.Total20500200502000 += (Decimal)current.cta_20500200502050;
                if (current.cta_20500200502060 != null)
                    current.Total20500200502000 += (Decimal)current.cta_20500200502060;
                if (current.cta_20500200502070 != null)
                    current.Total20500200502000 += (Decimal)current.cta_20500200502070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200500000;
                current.Total20500200500000 = 0;
                if (current.cta_20500200501000 != null && current.cta_20500200501000.Total20500200501000 != 0)
                    current.Total20500200500000 += (Decimal)current.cta_20500200501000.Total20500200501000;
                if (current.cta_20500200502000 != null && current.cta_20500200502000.Total20500200502000 != 0)
                    current.Total20500200500000 += (Decimal)current.cta_20500200502000.Total20500200502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200600000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200600000.cta_20500200601000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200600000.cta_20500200601000;
                current.Total20500200601000 = 0;
                if (current.cta_20500200601010 != null)
                    current.Total20500200601000 += (Decimal)current.cta_20500200601010;
                if (current.cta_20500200601020 != null)
                    current.Total20500200601000 += (Decimal)current.cta_20500200601020;
                if (current.cta_20500200601030 != null)
                    current.Total20500200601000 += (Decimal)current.cta_20500200601030;
                if (current.cta_20500200601040 != null)
                    current.Total20500200601000 += (Decimal)current.cta_20500200601040;
                if (current.cta_20500200601050 != null)
                    current.Total20500200601000 += (Decimal)current.cta_20500200601050;
                if (current.cta_20500200601060 != null)
                    current.Total20500200601000 += (Decimal)current.cta_20500200601060;
                if (current.cta_20500200601070 != null)
                    current.Total20500200601000 += (Decimal)current.cta_20500200601070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200600000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200600000.cta_20500200602000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200600000.cta_20500200602000;
                current.Total20500200602000 = 0;
                if (current.cta_20500200602010 != null)
                    current.Total20500200602000 += (Decimal)current.cta_20500200602010;
                if (current.cta_20500200602020 != null)
                    current.Total20500200602000 += (Decimal)current.cta_20500200602020;
                if (current.cta_20500200602030 != null)
                    current.Total20500200602000 += (Decimal)current.cta_20500200602030;
                if (current.cta_20500200602040 != null)
                    current.Total20500200602000 += (Decimal)current.cta_20500200602040;
                if (current.cta_20500200602050 != null)
                    current.Total20500200602000 += (Decimal)current.cta_20500200602050;
                if (current.cta_20500200602060 != null)
                    current.Total20500200602000 += (Decimal)current.cta_20500200602060;
                if (current.cta_20500200602070 != null)
                    current.Total20500200602000 += (Decimal)current.cta_20500200602070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200600000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000.cta_20500200600000;
                current.Total20500200600000 = 0;
                if (current.cta_20500200601000 != null && current.cta_20500200601000.Total20500200601000 != 0)
                    current.Total20500200600000 += (Decimal)current.cta_20500200601000.Total20500200601000;
                if (current.cta_20500200602000 != null && current.cta_20500200602000.Total20500200602000 != 0)
                    current.Total20500200600000 += (Decimal)current.cta_20500200602000.Total20500200602000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500200000000;
                current.Total20500200000000 = 0;
                if (current.cta_20500200100000 != null && current.cta_20500200100000.Total20500200100000 != 0)
                    current.Total20500200000000 += (Decimal)current.cta_20500200100000.Total20500200100000;
                if (current.cta_20500200200000 != null && current.cta_20500200200000.Total20500200200000 != 0)
                    current.Total20500200000000 += (Decimal)current.cta_20500200200000.Total20500200200000;
                if (current.cta_20500200300000 != null && current.cta_20500200300000.Total20500200300000 != 0)
                    current.Total20500200000000 += (Decimal)current.cta_20500200300000.Total20500200300000;
                if (current.cta_20500200400000 != null && current.cta_20500200400000.Total20500200400000 != 0)
                    current.Total20500200000000 += (Decimal)current.cta_20500200400000.Total20500200400000;
                if (current.cta_20500200500000 != null && current.cta_20500200500000.Total20500200500000 != 0)
                    current.Total20500200000000 += (Decimal)current.cta_20500200500000.Total20500200500000;
                if (current.cta_20500200600000 != null && current.cta_20500200600000.Total20500200600000 != 0)
                    current.Total20500200000000 += (Decimal)current.cta_20500200600000.Total20500200600000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300100000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300100000.cta_20500300101000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300100000.cta_20500300101000;
                current.Total20500300101000 = 0;
                if (current.cta_20500300101010 != null)
                    current.Total20500300101000 += (Decimal)current.cta_20500300101010;
                if (current.cta_20500300101020 != null)
                    current.Total20500300101000 += (Decimal)current.cta_20500300101020;
                if (current.cta_20500300101030 != null)
                    current.Total20500300101000 += (Decimal)current.cta_20500300101030;
                if (current.cta_20500300101040 != null)
                    current.Total20500300101000 += (Decimal)current.cta_20500300101040;
                if (current.cta_20500300101050 != null)
                    current.Total20500300101000 += (Decimal)current.cta_20500300101050;
                if (current.cta_20500300101060 != null)
                    current.Total20500300101000 += (Decimal)current.cta_20500300101060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300100000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300100000.cta_20500300102000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300100000.cta_20500300102000;
                current.Total20500300102000 = 0;
                if (current.cta_20500300102010 != null)
                    current.Total20500300102000 += (Decimal)current.cta_20500300102010;
                if (current.cta_20500300102020 != null)
                    current.Total20500300102000 += (Decimal)current.cta_20500300102020;
                if (current.cta_20500300102030 != null)
                    current.Total20500300102000 += (Decimal)current.cta_20500300102030;
                if (current.cta_20500300102040 != null)
                    current.Total20500300102000 += (Decimal)current.cta_20500300102040;
                if (current.cta_20500300102050 != null)
                    current.Total20500300102000 += (Decimal)current.cta_20500300102050;
                if (current.cta_20500300102060 != null)
                    current.Total20500300102000 += (Decimal)current.cta_20500300102060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300100000;
                current.Total20500300100000 = 0;
                if (current.cta_20500300101000 != null && current.cta_20500300101000.Total20500300101000 != 0)
                    current.Total20500300100000 += (Decimal)current.cta_20500300101000.Total20500300101000;
                if (current.cta_20500300102000 != null && current.cta_20500300102000.Total20500300102000 != 0)
                    current.Total20500300100000 += (Decimal)current.cta_20500300102000.Total20500300102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300200000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300200000.cta_20500300201000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300200000.cta_20500300201000;
                current.Total20500300201000 = 0;
                if (current.cta_20500300201010 != null)
                    current.Total20500300201000 += (Decimal)current.cta_20500300201010;
                if (current.cta_20500300201020 != null)
                    current.Total20500300201000 += (Decimal)current.cta_20500300201020;
                if (current.cta_20500300201030 != null)
                    current.Total20500300201000 += (Decimal)current.cta_20500300201030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300200000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300200000.cta_20500300202000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300200000.cta_20500300202000;
                current.Total20500300202000 = 0;
                if (current.cta_20500300202010 != null)
                    current.Total20500300202000 += (Decimal)current.cta_20500300202010;
                if (current.cta_20500300202020 != null)
                    current.Total20500300202000 += (Decimal)current.cta_20500300202020;
                if (current.cta_20500300202030 != null)
                    current.Total20500300202000 += (Decimal)current.cta_20500300202030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300200000;
                current.Total20500300200000 = 0;
                if (current.cta_20500300201000 != null && current.cta_20500300201000.Total20500300201000 != 0)
                    current.Total20500300200000 += (Decimal)current.cta_20500300201000.Total20500300201000;
                if (current.cta_20500300202000 != null && current.cta_20500300202000.Total20500300202000 != 0)
                    current.Total20500300200000 += (Decimal)current.cta_20500300202000.Total20500300202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300300000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300300000.cta_20500300301000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300300000.cta_20500300301000;
                current.Total20500300301000 = 0;
                if (current.cta_20500300301010 != null)
                    current.Total20500300301000 += (Decimal)current.cta_20500300301010;
                if (current.cta_20500300301020 != null)
                    current.Total20500300301000 += (Decimal)current.cta_20500300301020;
                if (current.cta_20500300301030 != null)
                    current.Total20500300301000 += (Decimal)current.cta_20500300301030;
                if (current.cta_20500300301040 != null)
                    current.Total20500300301000 += (Decimal)current.cta_20500300301040;
                if (current.cta_20500300301050 != null)
                    current.Total20500300301000 += (Decimal)current.cta_20500300301050;
                if (current.cta_20500300301060 != null)
                    current.Total20500300301000 += (Decimal)current.cta_20500300301060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300300000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300300000.cta_20500300302000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300300000.cta_20500300302000;
                current.Total20500300302000 = 0;
                if (current.cta_20500300302010 != null)
                    current.Total20500300302000 += (Decimal)current.cta_20500300302010;
                if (current.cta_20500300302020 != null)
                    current.Total20500300302000 += (Decimal)current.cta_20500300302020;
                if (current.cta_20500300302030 != null)
                    current.Total20500300302000 += (Decimal)current.cta_20500300302030;
                if (current.cta_20500300302040 != null)
                    current.Total20500300302000 += (Decimal)current.cta_20500300302040;
                if (current.cta_20500300302050 != null)
                    current.Total20500300302000 += (Decimal)current.cta_20500300302050;
                if (current.cta_20500300302060 != null)
                    current.Total20500300302000 += (Decimal)current.cta_20500300302060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300300000;
                current.Total20500300300000 = 0;
                if (current.cta_20500300301000 != null && current.cta_20500300301000.Total20500300301000 != 0)
                    current.Total20500300300000 += (Decimal)current.cta_20500300301000.Total20500300301000;
                if (current.cta_20500300302000 != null && current.cta_20500300302000.Total20500300302000 != 0)
                    current.Total20500300300000 += (Decimal)current.cta_20500300302000.Total20500300302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300400000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300400000.cta_20500300401000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300400000.cta_20500300401000;
                current.Total20500300401000 = 0;
                if (current.cta_20500300401010 != null)
                    current.Total20500300401000 += (Decimal)current.cta_20500300401010;
                if (current.cta_20500300401020 != null)
                    current.Total20500300401000 += (Decimal)current.cta_20500300401020;
                if (current.cta_20500300401030 != null)
                    current.Total20500300401000 += (Decimal)current.cta_20500300401030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300400000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300400000.cta_20500300402000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300400000.cta_20500300402000;
                current.Total20500300402000 = 0;
                if (current.cta_20500300402010 != null)
                    current.Total20500300402000 += (Decimal)current.cta_20500300402010;
                if (current.cta_20500300402020 != null)
                    current.Total20500300402000 += (Decimal)current.cta_20500300402020;
                if (current.cta_20500300402030 != null)
                    current.Total20500300402000 += (Decimal)current.cta_20500300402030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300400000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300400000;
                current.Total20500300400000 = 0;
                if (current.cta_20500300401000 != null && current.cta_20500300401000.Total20500300401000 != 0)
                    current.Total20500300400000 += (Decimal)current.cta_20500300401000.Total20500300401000;
                if (current.cta_20500300402000 != null && current.cta_20500300402000.Total20500300402000 != 0)
                    current.Total20500300400000 += (Decimal)current.cta_20500300402000.Total20500300402000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300500000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300500000.cta_20500300501000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300500000.cta_20500300501000;
                current.Total20500300501000 = 0;
                if (current.cta_20500300501010 != null)
                    current.Total20500300501000 += (Decimal)current.cta_20500300501010;
                if (current.cta_20500300501020 != null)
                    current.Total20500300501000 += (Decimal)current.cta_20500300501020;
                if (current.cta_20500300501030 != null)
                    current.Total20500300501000 += (Decimal)current.cta_20500300501030;
                if (current.cta_20500300501040 != null)
                    current.Total20500300501000 += (Decimal)current.cta_20500300501040;
                if (current.cta_20500300501050 != null)
                    current.Total20500300501000 += (Decimal)current.cta_20500300501050;
                if (current.cta_20500300501060 != null)
                    current.Total20500300501000 += (Decimal)current.cta_20500300501060;
                if (current.cta_20500300501070 != null)
                    current.Total20500300501000 += (Decimal)current.cta_20500300501070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300500000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300500000.cta_20500300502000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300500000.cta_20500300502000;
                current.Total20500300502000 = 0;
                if (current.cta_20500300502010 != null)
                    current.Total20500300502000 += (Decimal)current.cta_20500300502010;
                if (current.cta_20500300502020 != null)
                    current.Total20500300502000 += (Decimal)current.cta_20500300502020;
                if (current.cta_20500300502030 != null)
                    current.Total20500300502000 += (Decimal)current.cta_20500300502030;
                if (current.cta_20500300502040 != null)
                    current.Total20500300502000 += (Decimal)current.cta_20500300502040;
                if (current.cta_20500300502050 != null)
                    current.Total20500300502000 += (Decimal)current.cta_20500300502050;
                if (current.cta_20500300502060 != null)
                    current.Total20500300502000 += (Decimal)current.cta_20500300502060;
                if (current.cta_20500300502070 != null)
                    current.Total20500300502000 += (Decimal)current.cta_20500300502070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300500000;
                current.Total20500300500000 = 0;
                if (current.cta_20500300501000 != null && current.cta_20500300501000.Total20500300501000 != 0)
                    current.Total20500300500000 += (Decimal)current.cta_20500300501000.Total20500300501000;
                if (current.cta_20500300502000 != null && current.cta_20500300502000.Total20500300502000 != 0)
                    current.Total20500300500000 += (Decimal)current.cta_20500300502000.Total20500300502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300600000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300600000.cta_20500300601000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300600000.cta_20500300601000;
                current.Total20500300601000 = 0;
                if (current.cta_20500300601010 != null)
                    current.Total20500300601000 += (Decimal)current.cta_20500300601010;
                if (current.cta_20500300601020 != null)
                    current.Total20500300601000 += (Decimal)current.cta_20500300601020;
                if (current.cta_20500300601030 != null)
                    current.Total20500300601000 += (Decimal)current.cta_20500300601030;
                if (current.cta_20500300601040 != null)
                    current.Total20500300601000 += (Decimal)current.cta_20500300601040;
                if (current.cta_20500300601050 != null)
                    current.Total20500300601000 += (Decimal)current.cta_20500300601050;
                if (current.cta_20500300601060 != null)
                    current.Total20500300601000 += (Decimal)current.cta_20500300601060;
                if (current.cta_20500300601070 != null)
                    current.Total20500300601000 += (Decimal)current.cta_20500300601070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300600000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300600000.cta_20500300602000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300600000.cta_20500300602000;
                current.Total20500300602000 = 0;
                if (current.cta_20500300602010 != null)
                    current.Total20500300602000 += (Decimal)current.cta_20500300602010;
                if (current.cta_20500300602020 != null)
                    current.Total20500300602000 += (Decimal)current.cta_20500300602020;
                if (current.cta_20500300602030 != null)
                    current.Total20500300602000 += (Decimal)current.cta_20500300602030;
                if (current.cta_20500300602040 != null)
                    current.Total20500300602000 += (Decimal)current.cta_20500300602040;
                if (current.cta_20500300602050 != null)
                    current.Total20500300602000 += (Decimal)current.cta_20500300602050;
                if (current.cta_20500300602060 != null)
                    current.Total20500300602000 += (Decimal)current.cta_20500300602060;
                if (current.cta_20500300602070 != null)
                    current.Total20500300602000 += (Decimal)current.cta_20500300602070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300600000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000.cta_20500300600000;
                current.Total20500300600000 = 0;
                if (current.cta_20500300601000 != null && current.cta_20500300601000.Total20500300601000 != 0)
                    current.Total20500300600000 += (Decimal)current.cta_20500300601000.Total20500300601000;
                if (current.cta_20500300602000 != null && current.cta_20500300602000.Total20500300602000 != 0)
                    current.Total20500300600000 += (Decimal)current.cta_20500300602000.Total20500300602000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500300000000;
                current.Total20500300000000 = 0;
                if (current.cta_20500300100000 != null && current.cta_20500300100000.Total20500300100000 != 0)
                    current.Total20500300000000 += (Decimal)current.cta_20500300100000.Total20500300100000;
                if (current.cta_20500300200000 != null && current.cta_20500300200000.Total20500300200000 != 0)
                    current.Total20500300000000 += (Decimal)current.cta_20500300200000.Total20500300200000;
                if (current.cta_20500300300000 != null && current.cta_20500300300000.Total20500300300000 != 0)
                    current.Total20500300000000 += (Decimal)current.cta_20500300300000.Total20500300300000;
                if (current.cta_20500300400000 != null && current.cta_20500300400000.Total20500300400000 != 0)
                    current.Total20500300000000 += (Decimal)current.cta_20500300400000.Total20500300400000;
                if (current.cta_20500300500000 != null && current.cta_20500300500000.Total20500300500000 != 0)
                    current.Total20500300000000 += (Decimal)current.cta_20500300500000.Total20500300500000;
                if (current.cta_20500300600000 != null && current.cta_20500300600000.Total20500300600000 != 0)
                    current.Total20500300000000 += (Decimal)current.cta_20500300600000.Total20500300600000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400100000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400100000.cta_20500400101000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400100000.cta_20500400101000;
                current.Total20500400101000 = 0;
                if (current.cta_20500400101010 != null)
                    current.Total20500400101000 += (Decimal)current.cta_20500400101010;
                if (current.cta_20500400101020 != null)
                    current.Total20500400101000 += (Decimal)current.cta_20500400101020;
                if (current.cta_20500400101030 != null)
                    current.Total20500400101000 += (Decimal)current.cta_20500400101030;
                if (current.cta_20500400101040 != null)
                    current.Total20500400101000 += (Decimal)current.cta_20500400101040;
                if (current.cta_20500400101050 != null)
                    current.Total20500400101000 += (Decimal)current.cta_20500400101050;
                if (current.cta_20500400101060 != null)
                    current.Total20500400101000 += (Decimal)current.cta_20500400101060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400100000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400100000.cta_20500400102000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400100000.cta_20500400102000;
                current.Total20500400102000 = 0;
                if (current.cta_20500400102010 != null)
                    current.Total20500400102000 += (Decimal)current.cta_20500400102010;
                if (current.cta_20500400102020 != null)
                    current.Total20500400102000 += (Decimal)current.cta_20500400102020;
                if (current.cta_20500400102030 != null)
                    current.Total20500400102000 += (Decimal)current.cta_20500400102030;
                if (current.cta_20500400102040 != null)
                    current.Total20500400102000 += (Decimal)current.cta_20500400102040;
                if (current.cta_20500400102050 != null)
                    current.Total20500400102000 += (Decimal)current.cta_20500400102050;
                if (current.cta_20500400102060 != null)
                    current.Total20500400102000 += (Decimal)current.cta_20500400102060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400100000;
                current.Total20500400100000 = 0;
                if (current.cta_20500400101000 != null && current.cta_20500400101000.Total20500400101000 != 0)
                    current.Total20500400100000 += (Decimal)current.cta_20500400101000.Total20500400101000;
                if (current.cta_20500400102000 != null && current.cta_20500400102000.Total20500400102000 != 0)
                    current.Total20500400100000 += (Decimal)current.cta_20500400102000.Total20500400102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400200000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400200000.cta_20500400201000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400200000.cta_20500400201000;
                current.Total20500400201000 = 0;
                if (current.cta_20500400201010 != null)
                    current.Total20500400201000 += (Decimal)current.cta_20500400201010;
                if (current.cta_20500400201020 != null)
                    current.Total20500400201000 += (Decimal)current.cta_20500400201020;
                if (current.cta_20500400201030 != null)
                    current.Total20500400201000 += (Decimal)current.cta_20500400201030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400200000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400200000.cta_20500400202000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400200000.cta_20500400202000;
                current.Total20500400202000 = 0;
                if (current.cta_20500400202010 != null)
                    current.Total20500400202000 += (Decimal)current.cta_20500400202010;
                if (current.cta_20500400202020 != null)
                    current.Total20500400202000 += (Decimal)current.cta_20500400202020;
                if (current.cta_20500400202030 != null)
                    current.Total20500400202000 += (Decimal)current.cta_20500400202030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400200000;
                current.Total20500400200000 = 0;
                if (current.cta_20500400201000 != null && current.cta_20500400201000.Total20500400201000 != 0)
                    current.Total20500400200000 += (Decimal)current.cta_20500400201000.Total20500400201000;
                if (current.cta_20500400202000 != null && current.cta_20500400202000.Total20500400202000 != 0)
                    current.Total20500400200000 += (Decimal)current.cta_20500400202000.Total20500400202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400300000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400300000.cta_20500400301000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400300000.cta_20500400301000;
                current.Total20500400301000 = 0;
                if (current.cta_20500400301010 != null)
                    current.Total20500400301000 += (Decimal)current.cta_20500400301010;
                if (current.cta_20500400301020 != null)
                    current.Total20500400301000 += (Decimal)current.cta_20500400301020;
                if (current.cta_20500400301030 != null)
                    current.Total20500400301000 += (Decimal)current.cta_20500400301030;
                if (current.cta_20500400301040 != null)
                    current.Total20500400301000 += (Decimal)current.cta_20500400301040;
                if (current.cta_20500400301050 != null)
                    current.Total20500400301000 += (Decimal)current.cta_20500400301050;
                if (current.cta_20500400301060 != null)
                    current.Total20500400301000 += (Decimal)current.cta_20500400301060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400300000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400300000.cta_20500400302000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400300000.cta_20500400302000;
                current.Total20500400302000 = 0;
                if (current.cta_20500400302010 != null)
                    current.Total20500400302000 += (Decimal)current.cta_20500400302010;
                if (current.cta_20500400302020 != null)
                    current.Total20500400302000 += (Decimal)current.cta_20500400302020;
                if (current.cta_20500400302030 != null)
                    current.Total20500400302000 += (Decimal)current.cta_20500400302030;
                if (current.cta_20500400302040 != null)
                    current.Total20500400302000 += (Decimal)current.cta_20500400302040;
                if (current.cta_20500400302050 != null)
                    current.Total20500400302000 += (Decimal)current.cta_20500400302050;
                if (current.cta_20500400302060 != null)
                    current.Total20500400302000 += (Decimal)current.cta_20500400302060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400300000;
                current.Total20500400300000 = 0;
                if (current.cta_20500400301000 != null && current.cta_20500400301000.Total20500400301000 != 0)
                    current.Total20500400300000 += (Decimal)current.cta_20500400301000.Total20500400301000;
                if (current.cta_20500400302000 != null && current.cta_20500400302000.Total20500400302000 != 0)
                    current.Total20500400300000 += (Decimal)current.cta_20500400302000.Total20500400302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400400000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400400000.cta_20500400401000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400400000.cta_20500400401000;
                current.Total20500400401000 = 0;
                if (current.cta_20500400401010 != null)
                    current.Total20500400401000 += (Decimal)current.cta_20500400401010;
                if (current.cta_20500400401020 != null)
                    current.Total20500400401000 += (Decimal)current.cta_20500400401020;
                if (current.cta_20500400401030 != null)
                    current.Total20500400401000 += (Decimal)current.cta_20500400401030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400400000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400400000.cta_20500400402000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400400000.cta_20500400402000;
                current.Total20500400402000 = 0;
                if (current.cta_20500400402010 != null)
                    current.Total20500400402000 += (Decimal)current.cta_20500400402010;
                if (current.cta_20500400402020 != null)
                    current.Total20500400402000 += (Decimal)current.cta_20500400402020;
                if (current.cta_20500400402030 != null)
                    current.Total20500400402000 += (Decimal)current.cta_20500400402030;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400400000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400400000;
                current.Total20500400400000 = 0;
                if (current.cta_20500400401000 != null && current.cta_20500400401000.Total20500400401000 != 0)
                    current.Total20500400400000 += (Decimal)current.cta_20500400401000.Total20500400401000;
                if (current.cta_20500400402000 != null && current.cta_20500400402000.Total20500400402000 != 0)
                    current.Total20500400400000 += (Decimal)current.cta_20500400402000.Total20500400402000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400500000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400500000.cta_20500400501000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400500000.cta_20500400501000;
                current.Total20500400501000 = 0;
                if (current.cta_20500400501010 != null)
                    current.Total20500400501000 += (Decimal)current.cta_20500400501010;
                if (current.cta_20500400501020 != null)
                    current.Total20500400501000 += (Decimal)current.cta_20500400501020;
                if (current.cta_20500400501030 != null)
                    current.Total20500400501000 += (Decimal)current.cta_20500400501030;
                if (current.cta_20500400501040 != null)
                    current.Total20500400501000 += (Decimal)current.cta_20500400501040;
                if (current.cta_20500400501050 != null)
                    current.Total20500400501000 += (Decimal)current.cta_20500400501050;
                if (current.cta_20500400501060 != null)
                    current.Total20500400501000 += (Decimal)current.cta_20500400501060;
                if (current.cta_20500400501070 != null)
                    current.Total20500400501000 += (Decimal)current.cta_20500400501070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400500000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400500000.cta_20500400502000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400500000.cta_20500400502000;
                current.Total20500400502000 = 0;
                if (current.cta_20500400502010 != null)
                    current.Total20500400502000 += (Decimal)current.cta_20500400502010;
                if (current.cta_20500400502020 != null)
                    current.Total20500400502000 += (Decimal)current.cta_20500400502020;
                if (current.cta_20500400502030 != null)
                    current.Total20500400502000 += (Decimal)current.cta_20500400502030;
                if (current.cta_20500400502040 != null)
                    current.Total20500400502000 += (Decimal)current.cta_20500400502040;
                if (current.cta_20500400502050 != null)
                    current.Total20500400502000 += (Decimal)current.cta_20500400502050;
                if (current.cta_20500400502060 != null)
                    current.Total20500400502000 += (Decimal)current.cta_20500400502060;
                if (current.cta_20500400502070 != null)
                    current.Total20500400502000 += (Decimal)current.cta_20500400502070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400500000;
                current.Total20500400500000 = 0;
                if (current.cta_20500400501000 != null && current.cta_20500400501000.Total20500400501000 != 0)
                    current.Total20500400500000 += (Decimal)current.cta_20500400501000.Total20500400501000;
                if (current.cta_20500400502000 != null && current.cta_20500400502000.Total20500400502000 != 0)
                    current.Total20500400500000 += (Decimal)current.cta_20500400502000.Total20500400502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400600000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400600000.cta_20500400601000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400600000.cta_20500400601000;
                current.Total20500400601000 = 0;
                if (current.cta_20500400601010 != null)
                    current.Total20500400601000 += (Decimal)current.cta_20500400601010;
                if (current.cta_20500400601020 != null)
                    current.Total20500400601000 += (Decimal)current.cta_20500400601020;
                if (current.cta_20500400601030 != null)
                    current.Total20500400601000 += (Decimal)current.cta_20500400601030;
                if (current.cta_20500400601040 != null)
                    current.Total20500400601000 += (Decimal)current.cta_20500400601040;
                if (current.cta_20500400601050 != null)
                    current.Total20500400601000 += (Decimal)current.cta_20500400601050;
                if (current.cta_20500400601060 != null)
                    current.Total20500400601000 += (Decimal)current.cta_20500400601060;
                if (current.cta_20500400601070 != null)
                    current.Total20500400601000 += (Decimal)current.cta_20500400601070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400600000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400600000.cta_20500400602000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400600000.cta_20500400602000;
                current.Total20500400602000 = 0;
                if (current.cta_20500400602010 != null)
                    current.Total20500400602000 += (Decimal)current.cta_20500400602010;
                if (current.cta_20500400602020 != null)
                    current.Total20500400602000 += (Decimal)current.cta_20500400602020;
                if (current.cta_20500400602030 != null)
                    current.Total20500400602000 += (Decimal)current.cta_20500400602030;
                if (current.cta_20500400602040 != null)
                    current.Total20500400602000 += (Decimal)current.cta_20500400602040;
                if (current.cta_20500400602050 != null)
                    current.Total20500400602000 += (Decimal)current.cta_20500400602050;
                if (current.cta_20500400602060 != null)
                    current.Total20500400602000 += (Decimal)current.cta_20500400602060;
                if (current.cta_20500400602070 != null)
                    current.Total20500400602000 += (Decimal)current.cta_20500400602070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400600000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000.cta_20500400600000;
                current.Total20500400600000 = 0;
                if (current.cta_20500400601000 != null && current.cta_20500400601000.Total20500400601000 != 0)
                    current.Total20500400600000 += (Decimal)current.cta_20500400601000.Total20500400601000;
                if (current.cta_20500400602000 != null && current.cta_20500400602000.Total20500400602000 != 0)
                    current.Total20500400600000 += (Decimal)current.cta_20500400602000.Total20500400602000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500400000000;
                current.Total20500400000000 = 0;
                if (current.cta_20500400100000 != null && current.cta_20500400100000.Total20500400100000 != 0)
                    current.Total20500400000000 += (Decimal)current.cta_20500400100000.Total20500400100000;
                if (current.cta_20500400200000 != null && current.cta_20500400200000.Total20500400200000 != 0)
                    current.Total20500400000000 += (Decimal)current.cta_20500400200000.Total20500400200000;
                if (current.cta_20500400300000 != null && current.cta_20500400300000.Total20500400300000 != 0)
                    current.Total20500400000000 += (Decimal)current.cta_20500400300000.Total20500400300000;
                if (current.cta_20500400400000 != null && current.cta_20500400400000.Total20500400400000 != 0)
                    current.Total20500400000000 += (Decimal)current.cta_20500400400000.Total20500400400000;
                if (current.cta_20500400500000 != null && current.cta_20500400500000.Total20500400500000 != 0)
                    current.Total20500400000000 += (Decimal)current.cta_20500400500000.Total20500400500000;
                if (current.cta_20500400600000 != null && current.cta_20500400600000.Total20500400600000 != 0)
                    current.Total20500400000000 += (Decimal)current.cta_20500400600000.Total20500400600000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500900000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500900000000.cta_20500900100000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500900000000.cta_20500900100000.cta_20500900101000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500900000000.cta_20500900100000.cta_20500900101000;
                current.Total20500900101000 = 0;
                if (current.cta_20500900101010 != null)
                    current.Total20500900101000 += (Decimal)current.cta_20500900101010;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500900000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500900000000.cta_20500900100000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500900000000.cta_20500900100000.cta_20500900102000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500900000000.cta_20500900100000.cta_20500900102000;
                current.Total20500900102000 = 0;
                if (current.cta_20500900102010 != null)
                    current.Total20500900102000 += (Decimal)current.cta_20500900102010;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500900000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500900000000.cta_20500900100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500900000000.cta_20500900100000;
                current.Total20500900100000 = 0;
                if (current.cta_20500900101000 != null && current.cta_20500900101000.Total20500900101000 != 0)
                    current.Total20500900100000 += (Decimal)current.cta_20500900101000.Total20500900101000;
                if (current.cta_20500900102000 != null && current.cta_20500900102000.Total20500900102000 != 0)
                    current.Total20500900100000 += (Decimal)current.cta_20500900102000.Total20500900102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null && modelo.cta_20000000000000.cta_20500000000000.cta_20500900000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000.cta_20500900000000;
                current.Total20500900000000 = 0;
                if (current.cta_20500900100000 != null && current.cta_20500900100000.Total20500900100000 != 0)
                    current.Total20500900000000 += (Decimal)current.cta_20500900100000.Total20500900100000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20500000000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20500000000000;
                current.Total20500000000000 = 0;
                if (current.cta_20500100000000 != null && current.cta_20500100000000.Total20500100000000 != 0)
                    current.Total20500000000000 += (Decimal)current.cta_20500100000000.Total20500100000000;
                if (current.cta_20500200000000 != null && current.cta_20500200000000.Total20500200000000 != 0)
                    current.Total20500000000000 += (Decimal)current.cta_20500200000000.Total20500200000000;
                if (current.cta_20500300000000 != null && current.cta_20500300000000.Total20500300000000 != 0)
                    current.Total20500000000000 += (Decimal)current.cta_20500300000000.Total20500300000000;
                if (current.cta_20500400000000 != null && current.cta_20500400000000.Total20500400000000 != 0)
                    current.Total20500000000000 += (Decimal)current.cta_20500400000000.Total20500400000000;
                if (current.cta_20500900000000 != null && current.cta_20500900000000.Total20500900000000 != 0)
                    current.Total20500000000000 += (Decimal)current.cta_20500900000000.Total20500900000000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100100000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100100000.cta_20600100101000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100100000.cta_20600100101000;
                current.Total20600100101000 = 0;
                if (current.cta_20600100101010 != null)
                    current.Total20600100101000 += (Decimal)current.cta_20600100101010;
                if (current.cta_20600100101020 != null)
                    current.Total20600100101000 += (Decimal)current.cta_20600100101020;
                if (current.cta_20600100101030 != null)
                    current.Total20600100101000 += (Decimal)current.cta_20600100101030;
                if (current.cta_20600100101040 != null)
                    current.Total20600100101000 += (Decimal)current.cta_20600100101040;
                if (current.cta_20600100101050 != null)
                    current.Total20600100101000 += (Decimal)current.cta_20600100101050;
                if (current.cta_20600100101060 != null)
                    current.Total20600100101000 += (Decimal)current.cta_20600100101060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100100000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100100000.cta_20600100102000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100100000.cta_20600100102000;
                current.Total20600100102000 = 0;
                if (current.cta_20600100102010 != null)
                    current.Total20600100102000 += (Decimal)current.cta_20600100102010;
                if (current.cta_20600100102020 != null)
                    current.Total20600100102000 += (Decimal)current.cta_20600100102020;
                if (current.cta_20600100102030 != null)
                    current.Total20600100102000 += (Decimal)current.cta_20600100102030;
                if (current.cta_20600100102040 != null)
                    current.Total20600100102000 += (Decimal)current.cta_20600100102040;
                if (current.cta_20600100102050 != null)
                    current.Total20600100102000 += (Decimal)current.cta_20600100102050;
                if (current.cta_20600100102060 != null)
                    current.Total20600100102000 += (Decimal)current.cta_20600100102060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100100000;
                current.Total20600100100000 = 0;
                if (current.cta_20600100101000 != null && current.cta_20600100101000.Total20600100101000 != 0)
                    current.Total20600100100000 += (Decimal)current.cta_20600100101000.Total20600100101000;
                if (current.cta_20600100102000 != null && current.cta_20600100102000.Total20600100102000 != 0)
                    current.Total20600100100000 += (Decimal)current.cta_20600100102000.Total20600100102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100200000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100200000.cta_20600100201000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100200000.cta_20600100201000;
                current.Total20600100201000 = 0;
                if (current.cta_20600100201010 != null)
                    current.Total20600100201000 += (Decimal)current.cta_20600100201010;
                if (current.cta_20600100201020 != null)
                    current.Total20600100201000 += (Decimal)current.cta_20600100201020;
                if (current.cta_20600100201030 != null)
                    current.Total20600100201000 += (Decimal)current.cta_20600100201030;
                if (current.cta_20600100201040 != null)
                    current.Total20600100201000 += (Decimal)current.cta_20600100201040;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100200000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100200000.cta_20600100202000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100200000.cta_20600100202000;
                current.Total20600100202000 = 0;
                if (current.cta_20600100202010 != null)
                    current.Total20600100202000 += (Decimal)current.cta_20600100202010;
                if (current.cta_20600100202020 != null)
                    current.Total20600100202000 += (Decimal)current.cta_20600100202020;
                if (current.cta_20600100202030 != null)
                    current.Total20600100202000 += (Decimal)current.cta_20600100202030;
                if (current.cta_20600100202040 != null)
                    current.Total20600100202000 += (Decimal)current.cta_20600100202040;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100200000;
                current.Total20600100200000 = 0;
                if (current.cta_20600100201000 != null && current.cta_20600100201000.Total20600100201000 != 0)
                    current.Total20600100200000 += (Decimal)current.cta_20600100201000.Total20600100201000;
                if (current.cta_20600100202000 != null && current.cta_20600100202000.Total20600100202000 != 0)
                    current.Total20600100200000 += (Decimal)current.cta_20600100202000.Total20600100202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100300000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100300000.cta_20600100301000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100300000.cta_20600100301000;
                current.Total20600100301000 = 0;
                if (current.cta_20600100301010 != null)
                    current.Total20600100301000 += (Decimal)current.cta_20600100301010;
                if (current.cta_20600100301020 != null)
                    current.Total20600100301000 += (Decimal)current.cta_20600100301020;
                if (current.cta_20600100301030 != null)
                    current.Total20600100301000 += (Decimal)current.cta_20600100301030;
                if (current.cta_20600100301040 != null)
                    current.Total20600100301000 += (Decimal)current.cta_20600100301040;
                if (current.cta_20600100301050 != null)
                    current.Total20600100301000 += (Decimal)current.cta_20600100301050;
                if (current.cta_20600100301060 != null)
                    current.Total20600100301000 += (Decimal)current.cta_20600100301060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100300000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100300000.cta_20600100302000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100300000.cta_20600100302000;
                current.Total20600100302000 = 0;
                if (current.cta_20600100302010 != null)
                    current.Total20600100302000 += (Decimal)current.cta_20600100302010;
                if (current.cta_20600100302020 != null)
                    current.Total20600100302000 += (Decimal)current.cta_20600100302020;
                if (current.cta_20600100302030 != null)
                    current.Total20600100302000 += (Decimal)current.cta_20600100302030;
                if (current.cta_20600100302040 != null)
                    current.Total20600100302000 += (Decimal)current.cta_20600100302040;
                if (current.cta_20600100302050 != null)
                    current.Total20600100302000 += (Decimal)current.cta_20600100302050;
                if (current.cta_20600100302060 != null)
                    current.Total20600100302000 += (Decimal)current.cta_20600100302060;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100300000;
                current.Total20600100300000 = 0;
                if (current.cta_20600100301000 != null && current.cta_20600100301000.Total20600100301000 != 0)
                    current.Total20600100300000 += (Decimal)current.cta_20600100301000.Total20600100301000;
                if (current.cta_20600100302000 != null && current.cta_20600100302000.Total20600100302000 != 0)
                    current.Total20600100300000 += (Decimal)current.cta_20600100302000.Total20600100302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100400000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100400000.cta_20600100401000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100400000.cta_20600100401000;
                current.Total20600100401000 = 0;
                if (current.cta_20600100401010 != null)
                    current.Total20600100401000 += (Decimal)current.cta_20600100401010;
                if (current.cta_20600100401020 != null)
                    current.Total20600100401000 += (Decimal)current.cta_20600100401020;
                if (current.cta_20600100401030 != null)
                    current.Total20600100401000 += (Decimal)current.cta_20600100401030;
                if (current.cta_20600100401040 != null)
                    current.Total20600100401000 += (Decimal)current.cta_20600100401040;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100400000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100400000.cta_20600100402000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100400000.cta_20600100402000;
                current.Total20600100402000 = 0;
                if (current.cta_20600100402010 != null)
                    current.Total20600100402000 += (Decimal)current.cta_20600100402010;
                if (current.cta_20600100402020 != null)
                    current.Total20600100402000 += (Decimal)current.cta_20600100402020;
                if (current.cta_20600100402030 != null)
                    current.Total20600100402000 += (Decimal)current.cta_20600100402030;
                if (current.cta_20600100402040 != null)
                    current.Total20600100402000 += (Decimal)current.cta_20600100402040;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100400000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100400000;
                current.Total20600100400000 = 0;
                if (current.cta_20600100401000 != null && current.cta_20600100401000.Total20600100401000 != 0)
                    current.Total20600100400000 += (Decimal)current.cta_20600100401000.Total20600100401000;
                if (current.cta_20600100402000 != null && current.cta_20600100402000.Total20600100402000 != 0)
                    current.Total20600100400000 += (Decimal)current.cta_20600100402000.Total20600100402000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100500000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100500000.cta_20600100501000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100500000.cta_20600100501000;
                current.Total20600100501000 = 0;
                if (current.cta_20600100501010 != null)
                    current.Total20600100501000 += (Decimal)current.cta_20600100501010;
                if (current.cta_20600100501020 != null)
                    current.Total20600100501000 += (Decimal)current.cta_20600100501020;
                if (current.cta_20600100501030 != null)
                    current.Total20600100501000 += (Decimal)current.cta_20600100501030;
                if (current.cta_20600100501040 != null)
                    current.Total20600100501000 += (Decimal)current.cta_20600100501040;
                if (current.cta_20600100501050 != null)
                    current.Total20600100501000 += (Decimal)current.cta_20600100501050;
                if (current.cta_20600100501060 != null)
                    current.Total20600100501000 += (Decimal)current.cta_20600100501060;
                if (current.cta_20600100501070 != null)
                    current.Total20600100501000 += (Decimal)current.cta_20600100501070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100500000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100500000.cta_20600100502000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100500000.cta_20600100502000;
                current.Total20600100502000 = 0;
                if (current.cta_20600100502010 != null)
                    current.Total20600100502000 += (Decimal)current.cta_20600100502010;
                if (current.cta_20600100502020 != null)
                    current.Total20600100502000 += (Decimal)current.cta_20600100502020;
                if (current.cta_20600100502030 != null)
                    current.Total20600100502000 += (Decimal)current.cta_20600100502030;
                if (current.cta_20600100502040 != null)
                    current.Total20600100502000 += (Decimal)current.cta_20600100502040;
                if (current.cta_20600100502050 != null)
                    current.Total20600100502000 += (Decimal)current.cta_20600100502050;
                if (current.cta_20600100502060 != null)
                    current.Total20600100502000 += (Decimal)current.cta_20600100502060;
                if (current.cta_20600100502070 != null)
                    current.Total20600100502000 += (Decimal)current.cta_20600100502070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100500000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100500000;
                current.Total20600100500000 = 0;
                if (current.cta_20600100501000 != null && current.cta_20600100501000.Total20600100501000 != 0)
                    current.Total20600100500000 += (Decimal)current.cta_20600100501000.Total20600100501000;
                if (current.cta_20600100502000 != null && current.cta_20600100502000.Total20600100502000 != 0)
                    current.Total20600100500000 += (Decimal)current.cta_20600100502000.Total20600100502000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100600000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100600000.cta_20600100601000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100600000.cta_20600100601000;
                current.Total20600100601000 = 0;
                if (current.cta_20600100601010 != null)
                    current.Total20600100601000 += (Decimal)current.cta_20600100601010;
                if (current.cta_20600100601020 != null)
                    current.Total20600100601000 += (Decimal)current.cta_20600100601020;
                if (current.cta_20600100601030 != null)
                    current.Total20600100601000 += (Decimal)current.cta_20600100601030;
                if (current.cta_20600100601040 != null)
                    current.Total20600100601000 += (Decimal)current.cta_20600100601040;
                if (current.cta_20600100601050 != null)
                    current.Total20600100601000 += (Decimal)current.cta_20600100601050;
                if (current.cta_20600100601060 != null)
                    current.Total20600100601000 += (Decimal)current.cta_20600100601060;
                if (current.cta_20600100601070 != null)
                    current.Total20600100601000 += (Decimal)current.cta_20600100601070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100600000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100600000.cta_20600100602000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100600000.cta_20600100602000;
                current.Total20600100602000 = 0;
                if (current.cta_20600100602010 != null)
                    current.Total20600100602000 += (Decimal)current.cta_20600100602010;
                if (current.cta_20600100602020 != null)
                    current.Total20600100602000 += (Decimal)current.cta_20600100602020;
                if (current.cta_20600100602030 != null)
                    current.Total20600100602000 += (Decimal)current.cta_20600100602030;
                if (current.cta_20600100602040 != null)
                    current.Total20600100602000 += (Decimal)current.cta_20600100602040;
                if (current.cta_20600100602050 != null)
                    current.Total20600100602000 += (Decimal)current.cta_20600100602050;
                if (current.cta_20600100602060 != null)
                    current.Total20600100602000 += (Decimal)current.cta_20600100602060;
                if (current.cta_20600100602070 != null)
                    current.Total20600100602000 += (Decimal)current.cta_20600100602070;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100600000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000.cta_20600100600000;
                current.Total20600100600000 = 0;
                if (current.cta_20600100601000 != null && current.cta_20600100601000.Total20600100601000 != 0)
                    current.Total20600100600000 += (Decimal)current.cta_20600100601000.Total20600100601000;
                if (current.cta_20600100602000 != null && current.cta_20600100602000.Total20600100602000 != 0)
                    current.Total20600100600000 += (Decimal)current.cta_20600100602000.Total20600100602000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null && modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000.cta_20600100000000;
                current.Total20600100000000 = 0;
                if (current.cta_20600100100000 != null && current.cta_20600100100000.Total20600100100000 != 0)
                    current.Total20600100000000 += (Decimal)current.cta_20600100100000.Total20600100100000;
                if (current.cta_20600100200000 != null && current.cta_20600100200000.Total20600100200000 != 0)
                    current.Total20600100000000 += (Decimal)current.cta_20600100200000.Total20600100200000;
                if (current.cta_20600100300000 != null && current.cta_20600100300000.Total20600100300000 != 0)
                    current.Total20600100000000 += (Decimal)current.cta_20600100300000.Total20600100300000;
                if (current.cta_20600100400000 != null && current.cta_20600100400000.Total20600100400000 != 0)
                    current.Total20600100000000 += (Decimal)current.cta_20600100400000.Total20600100400000;
                if (current.cta_20600100500000 != null && current.cta_20600100500000.Total20600100500000 != 0)
                    current.Total20600100000000 += (Decimal)current.cta_20600100500000.Total20600100500000;
                if (current.cta_20600100600000 != null && current.cta_20600100600000.Total20600100600000 != 0)
                    current.Total20600100000000 += (Decimal)current.cta_20600100600000.Total20600100600000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20600000000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20600000000000;
                current.Total20600000000000 = 0;
                if (current.cta_20600100000000 != null && current.cta_20600100000000.Total20600100000000 != 0)
                    current.Total20600000000000 += (Decimal)current.cta_20600100000000.Total20600100000000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20700000000000 != null && modelo.cta_20000000000000.cta_20700000000000.cta_20700100000000 != null && modelo.cta_20000000000000.cta_20700000000000.cta_20700100000000.cta_20700100100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20700000000000.cta_20700100000000.cta_20700100100000;
                current.Total20700100100000 = 0;
                if (current.cta_20700100101000 != null)
                    current.Total20700100100000 += (Decimal)current.cta_20700100101000;
                if (current.cta_20700100102000 != null)
                    current.Total20700100100000 += (Decimal)current.cta_20700100102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20700000000000 != null && modelo.cta_20000000000000.cta_20700000000000.cta_20700100000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20700000000000.cta_20700100000000;
                current.Total20700100000000 = 0;
                if (current.cta_20700100100000 != null && current.cta_20700100100000.Total20700100100000 != 0)
                    current.Total20700100000000 += (Decimal)current.cta_20700100100000.Total20700100100000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20700000000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20700000000000;
                current.Total20700000000000 = 0;
                if (current.cta_20700100000000 != null && current.cta_20700100000000.Total20700100000000 != 0)
                    current.Total20700000000000 += (Decimal)current.cta_20700100000000.Total20700100000000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800100000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800100000000.cta_20800100200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000.cta_20800100000000.cta_20800100200000;
                current.Total20800100200000 = 0;
                if (current.cta_20800100201000 != null)
                    current.Total20800100200000 += (Decimal)current.cta_20800100201000;
                if (current.cta_20800100202000 != null)
                    current.Total20800100200000 += (Decimal)current.cta_20800100202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800100000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800100000000.cta_20800100800000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000.cta_20800100000000.cta_20800100800000;
                current.Total20800100800000 = 0;
                if (current.cta_20800100801000 != null)
                    current.Total20800100800000 += (Decimal)current.cta_20800100801000;
                if (current.cta_20800100802000 != null)
                    current.Total20800100800000 += (Decimal)current.cta_20800100802000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800100000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800100000000.cta_20800109900000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000.cta_20800100000000.cta_20800109900000;
                current.Total20800109900000 = 0;
                if (current.cta_20800109901000 != null)
                    current.Total20800109900000 += (Decimal)current.cta_20800109901000;
                if (current.cta_20800109902000 != null)
                    current.Total20800109900000 += (Decimal)current.cta_20800109902000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800100000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000.cta_20800100000000;
                current.Total20800100000000 = 0;
                if (current.cta_20800100200000 != null && current.cta_20800100200000.Total20800100200000 != 0)
                    current.Total20800100000000 += (Decimal)current.cta_20800100200000.Total20800100200000;
                if (current.cta_20800100800000 != null && current.cta_20800100800000.Total20800100800000 != 0)
                    current.Total20800100000000 += (Decimal)current.cta_20800100800000.Total20800100800000;
                if (current.cta_20800109900000 != null && current.cta_20800109900000.Total20800109900000 != 0)
                    current.Total20800100000000 += (Decimal)current.cta_20800109900000.Total20800109900000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800300000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800300000000.cta_20800300100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000.cta_20800300000000.cta_20800300100000;
                current.Total20800300100000 = 0;
                if (current.cta_20800300101000 != null)
                    current.Total20800300100000 += (Decimal)current.cta_20800300101000;
                if (current.cta_20800300102000 != null)
                    current.Total20800300100000 += (Decimal)current.cta_20800300102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800300000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800300000000.cta_20800300200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000.cta_20800300000000.cta_20800300200000;
                current.Total20800300200000 = 0;
                if (current.cta_20800300201000 != null)
                    current.Total20800300200000 += (Decimal)current.cta_20800300201000;
                if (current.cta_20800300202000 != null)
                    current.Total20800300200000 += (Decimal)current.cta_20800300202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800300000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800300000000.cta_20800309900000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000.cta_20800300000000.cta_20800309900000;
                current.Total20800309900000 = 0;
                if (current.cta_20800309901000 != null)
                    current.Total20800309900000 += (Decimal)current.cta_20800309901000;
                if (current.cta_20800309902000 != null)
                    current.Total20800309900000 += (Decimal)current.cta_20800309902000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800300000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000.cta_20800300000000;
                current.Total20800300000000 = 0;
                if (current.cta_20800300100000 != null && current.cta_20800300100000.Total20800300100000 != 0)
                    current.Total20800300000000 += (Decimal)current.cta_20800300100000.Total20800300100000;
                if (current.cta_20800300200000 != null && current.cta_20800300200000.Total20800300200000 != 0)
                    current.Total20800300000000 += (Decimal)current.cta_20800300200000.Total20800300200000;
                if (current.cta_20800309900000 != null && current.cta_20800309900000.Total20800309900000 != 0)
                    current.Total20800300000000 += (Decimal)current.cta_20800309900000.Total20800309900000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800400000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800400000000.cta_20800400100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000.cta_20800400000000.cta_20800400100000;
                current.Total20800400100000 = 0;
                if (current.cta_20800400101000 != null)
                    current.Total20800400100000 += (Decimal)current.cta_20800400101000;
                if (current.cta_20800400102000 != null)
                    current.Total20800400100000 += (Decimal)current.cta_20800400102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800400000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800400000000.cta_20800400200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000.cta_20800400000000.cta_20800400200000;
                current.Total20800400200000 = 0;
                if (current.cta_20800400201000 != null)
                    current.Total20800400200000 += (Decimal)current.cta_20800400201000;
                if (current.cta_20800400202000 != null)
                    current.Total20800400200000 += (Decimal)current.cta_20800400202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800400000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800400000000.cta_20800400400000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000.cta_20800400000000.cta_20800400400000;
                current.Total20800400400000 = 0;
                if (current.cta_20800400401000 != null)
                    current.Total20800400400000 += (Decimal)current.cta_20800400401000;
                if (current.cta_20800400402000 != null)
                    current.Total20800400400000 += (Decimal)current.cta_20800400402000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800400000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000.cta_20800400000000;
                current.Total20800400000000 = 0;
                if (current.cta_20800400100000 != null && current.cta_20800400100000.Total20800400100000 != 0)
                    current.Total20800400000000 += (Decimal)current.cta_20800400100000.Total20800400100000;
                if (current.cta_20800400200000 != null && current.cta_20800400200000.Total20800400200000 != 0)
                    current.Total20800400000000 += (Decimal)current.cta_20800400200000.Total20800400200000;
                if (current.cta_20800400400000 != null && current.cta_20800400400000.Total20800400400000 != 0)
                    current.Total20800400000000 += (Decimal)current.cta_20800400400000.Total20800400400000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800700000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800700000000.cta_20800700100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000.cta_20800700000000.cta_20800700100000;
                current.Total20800700100000 = 0;
                if (current.cta_20800700101000 != null)
                    current.Total20800700100000 += (Decimal)current.cta_20800700101000;
                if (current.cta_20800700102000 != null)
                    current.Total20800700100000 += (Decimal)current.cta_20800700102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null && modelo.cta_20000000000000.cta_20800000000000.cta_20800700000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000.cta_20800700000000;
                current.Total20800700000000 = 0;
                if (current.cta_20800700100000 != null && current.cta_20800700100000.Total20800700100000 != 0)
                    current.Total20800700000000 += (Decimal)current.cta_20800700100000.Total20800700100000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20800000000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20800000000000;
                current.Total20800000000000 = 0;
                if (current.cta_20800100000000 != null && current.cta_20800100000000.Total20800100000000 != 0)
                    current.Total20800000000000 += (Decimal)current.cta_20800100000000.Total20800100000000;
                if (current.cta_20800300000000 != null && current.cta_20800300000000.Total20800300000000 != 0)
                    current.Total20800000000000 += (Decimal)current.cta_20800300000000.Total20800300000000;
                if (current.cta_20800400000000 != null && current.cta_20800400000000.Total20800400000000 != 0)
                    current.Total20800000000000 += (Decimal)current.cta_20800400000000.Total20800400000000;
                if (current.cta_20800700000000 != null && current.cta_20800700000000.Total20800700000000 != 0)
                    current.Total20800000000000 += (Decimal)current.cta_20800700000000.Total20800700000000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20900000000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900100000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900100000000.cta_20900100100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20900000000000.cta_20900100000000.cta_20900100100000;
                current.Total20900100100000 = 0;
                if (current.cta_20900100101000 != null)
                    current.Total20900100100000 += (Decimal)current.cta_20900100101000;
                if (current.cta_20900100102000 != null)
                    current.Total20900100100000 += (Decimal)current.cta_20900100102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20900000000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900100000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900100000000.cta_20900100200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20900000000000.cta_20900100000000.cta_20900100200000;
                current.Total20900100200000 = 0;
                if (current.cta_20900100201000 != null)
                    current.Total20900100200000 += (Decimal)current.cta_20900100201000;
                if (current.cta_20900100202000 != null)
                    current.Total20900100200000 += (Decimal)current.cta_20900100202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20900000000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900100000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900100000000.cta_20900100300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20900000000000.cta_20900100000000.cta_20900100300000;
                current.Total20900100300000 = 0;
                if (current.cta_20900100301000 != null)
                    current.Total20900100300000 += (Decimal)current.cta_20900100301000;
                if (current.cta_20900100302000 != null)
                    current.Total20900100300000 += (Decimal)current.cta_20900100302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20900000000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900100000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20900000000000.cta_20900100000000;
                current.Total20900100000000 = 0;
                if (current.cta_20900100100000 != null && current.cta_20900100100000.Total20900100100000 != 0)
                    current.Total20900100000000 += (Decimal)current.cta_20900100100000.Total20900100100000;
                if (current.cta_20900100200000 != null && current.cta_20900100200000.Total20900100200000 != 0)
                    current.Total20900100000000 += (Decimal)current.cta_20900100200000.Total20900100200000;
                if (current.cta_20900100300000 != null && current.cta_20900100300000.Total20900100300000 != 0)
                    current.Total20900100000000 += (Decimal)current.cta_20900100300000.Total20900100300000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20900000000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900200000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900200000000.cta_20900200100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20900000000000.cta_20900200000000.cta_20900200100000;
                current.Total20900200100000 = 0;
                if (current.cta_20900200101000 != null)
                    current.Total20900200100000 += (Decimal)current.cta_20900200101000;
                if (current.cta_20900200102000 != null)
                    current.Total20900200100000 += (Decimal)current.cta_20900200102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20900000000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900200000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20900000000000.cta_20900200000000;
                current.Total20900200000000 = 0;
                if (current.cta_20900200100000 != null && current.cta_20900200100000.Total20900200100000 != 0)
                    current.Total20900200000000 += (Decimal)current.cta_20900200100000.Total20900200100000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20900000000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900800000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900800000000.cta_20900800100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20900000000000.cta_20900800000000.cta_20900800100000;
                current.Total20900800100000 = 0;
                if (current.cta_20900800101000 != null)
                    current.Total20900800100000 += (Decimal)current.cta_20900800101000;
                if (current.cta_20900800102000 != null)
                    current.Total20900800100000 += (Decimal)current.cta_20900800102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20900000000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900800000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900800000000.cta_20900800200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20900000000000.cta_20900800000000.cta_20900800200000;
                current.Total20900800200000 = 0;
                if (current.cta_20900800201000 != null)
                    current.Total20900800200000 += (Decimal)current.cta_20900800201000;
                if (current.cta_20900800202000 != null)
                    current.Total20900800200000 += (Decimal)current.cta_20900800202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20900000000000 != null && modelo.cta_20000000000000.cta_20900000000000.cta_20900800000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20900000000000.cta_20900800000000;
                current.Total20900800000000 = 0;
                if (current.cta_20900800100000 != null && current.cta_20900800100000.Total20900800100000 != 0)
                    current.Total20900800000000 += (Decimal)current.cta_20900800100000.Total20900800100000;
                if (current.cta_20900800200000 != null && current.cta_20900800200000.Total20900800200000 != 0)
                    current.Total20900800000000 += (Decimal)current.cta_20900800200000.Total20900800200000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_20900000000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_20900000000000;
                current.Total20900000000000 = 0;
                if (current.cta_20900100000000 != null && current.cta_20900100000000.Total20900100000000 != 0)
                    current.Total20900000000000 += (Decimal)current.cta_20900100000000.Total20900100000000;
                if (current.cta_20900200000000 != null && current.cta_20900200000000.Total20900200000000 != 0)
                    current.Total20900000000000 += (Decimal)current.cta_20900200000000.Total20900200000000;
                if (current.cta_20900800000000 != null && current.cta_20900800000000.Total20900800000000 != 0)
                    current.Total20900000000000 += (Decimal)current.cta_20900800000000.Total20900800000000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21000000000000 != null && modelo.cta_20000000000000.cta_21000000000000.cta_21000100000000 != null && modelo.cta_20000000000000.cta_21000000000000.cta_21000100000000.cta_21000100100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21000000000000.cta_21000100000000.cta_21000100100000;
                current.Total21000100100000 = 0;
                if (current.cta_21000100101000 != null)
                    current.Total21000100100000 += (Decimal)current.cta_21000100101000;
                if (current.cta_21000100102000 != null)
                    current.Total21000100100000 += (Decimal)current.cta_21000100102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21000000000000 != null && modelo.cta_20000000000000.cta_21000000000000.cta_21000100000000 != null && modelo.cta_20000000000000.cta_21000000000000.cta_21000100000000.cta_21000100200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21000000000000.cta_21000100000000.cta_21000100200000;
                current.Total21000100200000 = 0;
                if (current.cta_21000100201000 != null)
                    current.Total21000100200000 += (Decimal)current.cta_21000100201000;
                if (current.cta_21000100202000 != null)
                    current.Total21000100200000 += (Decimal)current.cta_21000100202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21000000000000 != null && modelo.cta_20000000000000.cta_21000000000000.cta_21000100000000 != null && modelo.cta_20000000000000.cta_21000000000000.cta_21000100000000.cta_21000100300000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21000000000000.cta_21000100000000.cta_21000100300000;
                current.Total21000100300000 = 0;
                if (current.cta_21000100301000 != null)
                    current.Total21000100300000 += (Decimal)current.cta_21000100301000;
                if (current.cta_21000100302000 != null)
                    current.Total21000100300000 += (Decimal)current.cta_21000100302000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21000000000000 != null && modelo.cta_20000000000000.cta_21000000000000.cta_21000100000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21000000000000.cta_21000100000000;
                current.Total21000100000000 = 0;
                if (current.cta_21000100100000 != null && current.cta_21000100100000.Total21000100100000 != 0)
                    current.Total21000100000000 += (Decimal)current.cta_21000100100000.Total21000100100000;
                if (current.cta_21000100200000 != null && current.cta_21000100200000.Total21000100200000 != 0)
                    current.Total21000100000000 += (Decimal)current.cta_21000100200000.Total21000100200000;
                if (current.cta_21000100300000 != null && current.cta_21000100300000.Total21000100300000 != 0)
                    current.Total21000100000000 += (Decimal)current.cta_21000100300000.Total21000100300000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21000000000000 != null && modelo.cta_20000000000000.cta_21000000000000.cta_21000800000000 != null && modelo.cta_20000000000000.cta_21000000000000.cta_21000800000000.cta_21000800100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21000000000000.cta_21000800000000.cta_21000800100000;
                current.Total21000800100000 = 0;
                if (current.cta_21000800101000 != null)
                    current.Total21000800100000 += (Decimal)current.cta_21000800101000;
                if (current.cta_21000800102000 != null)
                    current.Total21000800100000 += (Decimal)current.cta_21000800102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21000000000000 != null && modelo.cta_20000000000000.cta_21000000000000.cta_21000800000000 != null && modelo.cta_20000000000000.cta_21000000000000.cta_21000800000000.cta_21000800200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21000000000000.cta_21000800000000.cta_21000800200000;
                current.Total21000800200000 = 0;
                if (current.cta_21000800201000 != null)
                    current.Total21000800200000 += (Decimal)current.cta_21000800201000;
                if (current.cta_21000800202000 != null)
                    current.Total21000800200000 += (Decimal)current.cta_21000800202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21000000000000 != null && modelo.cta_20000000000000.cta_21000000000000.cta_21000800000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21000000000000.cta_21000800000000;
                current.Total21000800000000 = 0;
                if (current.cta_21000800100000 != null && current.cta_21000800100000.Total21000800100000 != 0)
                    current.Total21000800000000 += (Decimal)current.cta_21000800100000.Total21000800100000;
                if (current.cta_21000800200000 != null && current.cta_21000800200000.Total21000800200000 != 0)
                    current.Total21000800000000 += (Decimal)current.cta_21000800200000.Total21000800200000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21000000000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21000000000000;
                current.Total21000000000000 = 0;
                if (current.cta_21000100000000 != null && current.cta_21000100000000.Total21000100000000 != 0)
                    current.Total21000000000000 += (Decimal)current.cta_21000100000000.Total21000100000000;
                if (current.cta_21000800000000 != null && current.cta_21000800000000.Total21000800000000 != 0)
                    current.Total21000000000000 += (Decimal)current.cta_21000800000000.Total21000800000000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21100000000000 != null && modelo.cta_20000000000000.cta_21100000000000.cta_21100100000000 != null && modelo.cta_20000000000000.cta_21100000000000.cta_21100100000000.cta_21100100100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21100000000000.cta_21100100000000.cta_21100100100000;
                current.Total21100100100000 = 0;
                if (current.cta_21100100101000 != null)
                    current.Total21100100100000 += (Decimal)current.cta_21100100101000;
                if (current.cta_21100100102000 != null)
                    current.Total21100100100000 += (Decimal)current.cta_21100100102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21100000000000 != null && modelo.cta_20000000000000.cta_21100000000000.cta_21100100000000 != null && modelo.cta_20000000000000.cta_21100000000000.cta_21100100000000.cta_21100100200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21100000000000.cta_21100100000000.cta_21100100200000;
                current.Total21100100200000 = 0;
                if (current.cta_21100100201000 != null)
                    current.Total21100100200000 += (Decimal)current.cta_21100100201000;
                if (current.cta_21100100202000 != null)
                    current.Total21100100200000 += (Decimal)current.cta_21100100202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21100000000000 != null && modelo.cta_20000000000000.cta_21100000000000.cta_21100100000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21100000000000.cta_21100100000000;
                current.Total21100100000000 = 0;
                if (current.cta_21100100100000 != null && current.cta_21100100100000.Total21100100100000 != 0)
                    current.Total21100100000000 += (Decimal)current.cta_21100100100000.Total21100100100000;
                if (current.cta_21100100200000 != null && current.cta_21100100200000.Total21100100200000 != 0)
                    current.Total21100100000000 += (Decimal)current.cta_21100100200000.Total21100100200000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21100000000000 != null && modelo.cta_20000000000000.cta_21100000000000.cta_21100800000000 != null && modelo.cta_20000000000000.cta_21100000000000.cta_21100800000000.cta_21100800100000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21100000000000.cta_21100800000000.cta_21100800100000;
                current.Total21100800100000 = 0;
                if (current.cta_21100800101000 != null)
                    current.Total21100800100000 += (Decimal)current.cta_21100800101000;
                if (current.cta_21100800102000 != null)
                    current.Total21100800100000 += (Decimal)current.cta_21100800102000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21100000000000 != null && modelo.cta_20000000000000.cta_21100000000000.cta_21100800000000 != null && modelo.cta_20000000000000.cta_21100000000000.cta_21100800000000.cta_21100800200000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21100000000000.cta_21100800000000.cta_21100800200000;
                current.Total21100800200000 = 0;
                if (current.cta_21100800201000 != null)
                    current.Total21100800200000 += (Decimal)current.cta_21100800201000;
                if (current.cta_21100800202000 != null)
                    current.Total21100800200000 += (Decimal)current.cta_21100800202000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21100000000000 != null && modelo.cta_20000000000000.cta_21100000000000.cta_21100800000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21100000000000.cta_21100800000000;
                current.Total21100800000000 = 0;
                if (current.cta_21100800100000 != null && current.cta_21100800100000.Total21100800100000 != 0)
                    current.Total21100800000000 += (Decimal)current.cta_21100800100000.Total21100800100000;
                if (current.cta_21100800200000 != null && current.cta_21100800200000.Total21100800200000 != 0)
                    current.Total21100800000000 += (Decimal)current.cta_21100800200000.Total21100800200000;
            }
            if (modelo.cta_20000000000000 != null && modelo.cta_20000000000000.cta_21100000000000 != null)
            {
                var current = modelo.cta_20000000000000.cta_21100000000000;
                current.Total21100000000000 = 0;
                if (current.cta_21100100000000 != null && current.cta_21100100000000.Total21100100000000 != 0)
                    current.Total21100000000000 += (Decimal)current.cta_21100100000000.Total21100100000000;
                if (current.cta_21100800000000 != null && current.cta_21100800000000.Total21100800000000 != 0)
                    current.Total21100000000000 += (Decimal)current.cta_21100800000000.Total21100800000000;
            }
            if (modelo.cta_20000000000000 != null)
            {
                var current = modelo.cta_20000000000000;
                current.Total20000000000000 = 0;
                if (current.cta_20100000000000 != null && current.cta_20100000000000.Total20100000000000 != 0)
                    current.Total20000000000000 += (Decimal)current.cta_20100000000000.Total20100000000000;
                if (current.cta_20300000000000 != null && current.cta_20300000000000.Total20300000000000 != 0)
                    current.Total20000000000000 += (Decimal)current.cta_20300000000000.Total20300000000000;
                if (current.cta_20400000000000 != null && current.cta_20400000000000.Total20400000000000 != 0)
                    current.Total20000000000000 += (Decimal)current.cta_20400000000000.Total20400000000000;
                if (current.cta_20500000000000 != null && current.cta_20500000000000.Total20500000000000 != 0)
                    current.Total20000000000000 += (Decimal)current.cta_20500000000000.Total20500000000000;
                if (current.cta_20600000000000 != null && current.cta_20600000000000.Total20600000000000 != 0)
                    current.Total20000000000000 += (Decimal)current.cta_20600000000000.Total20600000000000;
                if (current.cta_20700000000000 != null && current.cta_20700000000000.Total20700000000000 != 0)
                    current.Total20000000000000 += (Decimal)current.cta_20700000000000.Total20700000000000;
                if (current.cta_20800000000000 != null && current.cta_20800000000000.Total20800000000000 != 0)
                    current.Total20000000000000 += (Decimal)current.cta_20800000000000.Total20800000000000;
                if (current.cta_20900000000000 != null && current.cta_20900000000000.Total20900000000000 != 0)
                    current.Total20000000000000 += (Decimal)current.cta_20900000000000.Total20900000000000;
                if (current.cta_21000000000000 != null && current.cta_21000000000000.Total21000000000000 != 0)
                    current.Total20000000000000 += (Decimal)current.cta_21000000000000.Total21000000000000;
                if (current.cta_21100000000000 != null && current.cta_21100000000000.Total21100000000000 != 0)
                    current.Total20000000000000 += (Decimal)current.cta_21100000000000.Total21100000000000;
            }
        }

    }
}
