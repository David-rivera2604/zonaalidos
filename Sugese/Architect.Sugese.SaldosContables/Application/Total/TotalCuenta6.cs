using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.Sugese.SaldosContables.Domain.Application.Total
{
    internal class TotalCuenta6
    {
        public static void Mapper(string account, Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModelo modelo, System.Nullable<decimal> value, bool specified)
        {

            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100200000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100200000.cta_60100100201000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100200000.cta_60100100201000;
                current.Total60100100201000 = 0;
                if (current.cta_60100100201010 != null)
                    current.Total60100100201000 += (Decimal)current.cta_60100100201010;
                if (current.cta_60100100201020 != null)
                    current.Total60100100201000 += (Decimal)current.cta_60100100201020;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100200000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100200000.cta_60100100202000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100200000.cta_60100100202000;
                current.Total60100100202000 = 0;
                if (current.cta_60100100202010 != null)
                    current.Total60100100202000 += (Decimal)current.cta_60100100202010;
                if (current.cta_60100100202020 != null)
                    current.Total60100100202000 += (Decimal)current.cta_60100100202020;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100200000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100200000;
                current.Total60100100200000 = 0;
                if (current.cta_60100100201000 != null && current.cta_60100100201000.Total60100100201000 != 0)
                    current.Total60100100200000 += (Decimal)current.cta_60100100201000.Total60100100201000;
                if (current.cta_60100100202000 != null && current.cta_60100100202000.Total60100100202000 != 0)
                    current.Total60100100200000 += (Decimal)current.cta_60100100202000.Total60100100202000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100300000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100300000.cta_60100100301000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100300000.cta_60100100301000;
                current.Total60100100301000 = 0;
                if (current.cta_60100100301010 != null)
                    current.Total60100100301000 += (Decimal)current.cta_60100100301010;
                if (current.cta_60100100301020 != null)
                    current.Total60100100301000 += (Decimal)current.cta_60100100301020;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100300000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100300000.cta_60100100302000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100300000.cta_60100100302000;
                current.Total60100100302000 = 0;
                if (current.cta_60100100302010 != null)
                    current.Total60100100302000 += (Decimal)current.cta_60100100302010;
                if (current.cta_60100100302020 != null)
                    current.Total60100100302000 += (Decimal)current.cta_60100100302020;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100300000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100300000;
                current.Total60100100300000 = 0;
                if (current.cta_60100100301000 != null && current.cta_60100100301000.Total60100100301000 != 0)
                    current.Total60100100300000 += (Decimal)current.cta_60100100301000.Total60100100301000;
                if (current.cta_60100100302000 != null && current.cta_60100100302000.Total60100100302000 != 0)
                    current.Total60100100300000 += (Decimal)current.cta_60100100302000.Total60100100302000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100400000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100400000.cta_60100100401000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100400000.cta_60100100401000;
                current.Total60100100401000 = 0;
                if (current.cta_60100100401010 != null)
                    current.Total60100100401000 += (Decimal)current.cta_60100100401010;
                if (current.cta_60100100401020 != null)
                    current.Total60100100401000 += (Decimal)current.cta_60100100401020;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100400000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100400000.cta_60100100402000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100400000.cta_60100100402000;
                current.Total60100100402000 = 0;
                if (current.cta_60100100402010 != null)
                    current.Total60100100402000 += (Decimal)current.cta_60100100402010;
                if (current.cta_60100100402020 != null)
                    current.Total60100100402000 += (Decimal)current.cta_60100100402020;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100400000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000.cta_60100100400000;
                current.Total60100100400000 = 0;
                if (current.cta_60100100401000 != null && current.cta_60100100401000.Total60100100401000 != 0)
                    current.Total60100100400000 += (Decimal)current.cta_60100100401000.Total60100100401000;
                if (current.cta_60100100402000 != null && current.cta_60100100402000.Total60100100402000 != 0)
                    current.Total60100100400000 += (Decimal)current.cta_60100100402000.Total60100100402000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100100000000;
                current.Total60100100000000 = 0;
                if (current.cta_60100100200000 != null && current.cta_60100100200000.Total60100100200000 != 0)
                    current.Total60100100000000 += (Decimal)current.cta_60100100200000.Total60100100200000;
                if (current.cta_60100100300000 != null && current.cta_60100100300000.Total60100100300000 != 0)
                    current.Total60100100000000 += (Decimal)current.cta_60100100300000.Total60100100300000;
                if (current.cta_60100100400000 != null && current.cta_60100100400000.Total60100100400000 != 0)
                    current.Total60100100000000 += (Decimal)current.cta_60100100400000.Total60100100400000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100700000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100700000000.cta_60100700300000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100700000000.cta_60100700300000;
                current.Total60100700300000 = 0;
                if (current.cta_60100700301000 != null)
                    current.Total60100700300000 += (Decimal)current.cta_60100700301000;
                if (current.cta_60100700302000 != null)
                    current.Total60100700300000 += (Decimal)current.cta_60100700302000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100700000000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100700000000;
                current.Total60100700000000 = 0;
                if (current.cta_60100700300000 != null && current.cta_60100700300000.Total60100700300000 != 0)
                    current.Total60100700000000 += (Decimal)current.cta_60100700300000.Total60100700300000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100900000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100900000000.cta_60100900100000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100900000000.cta_60100900100000;
                current.Total60100900100000 = 0;
                if (current.cta_60100900101000 != null)
                    current.Total60100900100000 += (Decimal)current.cta_60100900101000;
                if (current.cta_60100900102000 != null)
                    current.Total60100900100000 += (Decimal)current.cta_60100900102000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100900000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100900000000.cta_60100900200000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100900000000.cta_60100900200000;
                current.Total60100900200000 = 0;
                if (current.cta_60100900201000 != null)
                    current.Total60100900200000 += (Decimal)current.cta_60100900201000;
                if (current.cta_60100900202000 != null)
                    current.Total60100900200000 += (Decimal)current.cta_60100900202000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null && modelo.cta_60000000000000.cta_60100000000000.cta_60100900000000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000.cta_60100900000000;
                current.Total60100900000000 = 0;
                if (current.cta_60100900100000 != null && current.cta_60100900100000.Total60100900100000 != 0)
                    current.Total60100900000000 += (Decimal)current.cta_60100900100000.Total60100900100000;
                if (current.cta_60100900200000 != null && current.cta_60100900200000.Total60100900200000 != 0)
                    current.Total60100900000000 += (Decimal)current.cta_60100900200000.Total60100900200000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60100000000000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60100000000000;
                current.Total60100000000000 = 0;
                if (current.cta_60100100000000 != null && current.cta_60100100000000.Total60100100000000 != 0)
                    current.Total60100000000000 += (Decimal)current.cta_60100100000000.Total60100100000000;
                if (current.cta_60100700000000 != null && current.cta_60100700000000.Total60100700000000 != 0)
                    current.Total60100000000000 += (Decimal)current.cta_60100700000000.Total60100700000000;
                if (current.cta_60100900000000 != null && current.cta_60100900000000.Total60100900000000 != 0)
                    current.Total60100000000000 += (Decimal)current.cta_60100900000000.Total60100900000000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100200000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100200000.cta_60200100201000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100200000.cta_60200100201000;
                current.Total60200100201000 = 0;
                if (current.cta_60200100201010 != null)
                    current.Total60200100201000 += (Decimal)current.cta_60200100201010;
                if (current.cta_60200100201020 != null)
                    current.Total60200100201000 += (Decimal)current.cta_60200100201020;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100200000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100200000.cta_60200100202000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100200000.cta_60200100202000;
                current.Total60200100202000 = 0;
                if (current.cta_60200100202010 != null)
                    current.Total60200100202000 += (Decimal)current.cta_60200100202010;
                if (current.cta_60200100202020 != null)
                    current.Total60200100202000 += (Decimal)current.cta_60200100202020;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100200000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100200000;
                current.Total60200100200000 = 0;
                if (current.cta_60200100201000 != null && current.cta_60200100201000.Total60200100201000 != 0)
                    current.Total60200100200000 += (Decimal)current.cta_60200100201000.Total60200100201000;
                if (current.cta_60200100202000 != null && current.cta_60200100202000.Total60200100202000 != 0)
                    current.Total60200100200000 += (Decimal)current.cta_60200100202000.Total60200100202000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100300000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100300000.cta_60200100301000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100300000.cta_60200100301000;
                current.Total60200100301000 = 0;
                if (current.cta_60200100301010 != null)
                    current.Total60200100301000 += (Decimal)current.cta_60200100301010;
                if (current.cta_60200100301020 != null)
                    current.Total60200100301000 += (Decimal)current.cta_60200100301020;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100300000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100300000.cta_60200100302000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100300000.cta_60200100302000;
                current.Total60200100302000 = 0;
                if (current.cta_60200100302010 != null)
                    current.Total60200100302000 += (Decimal)current.cta_60200100302010;
                if (current.cta_60200100302020 != null)
                    current.Total60200100302000 += (Decimal)current.cta_60200100302020;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100300000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100300000;
                current.Total60200100300000 = 0;
                if (current.cta_60200100301000 != null && current.cta_60200100301000.Total60200100301000 != 0)
                    current.Total60200100300000 += (Decimal)current.cta_60200100301000.Total60200100301000;
                if (current.cta_60200100302000 != null && current.cta_60200100302000.Total60200100302000 != 0)
                    current.Total60200100300000 += (Decimal)current.cta_60200100302000.Total60200100302000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100400000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100400000.cta_60200100401000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100400000.cta_60200100401000;
                current.Total60200100401000 = 0;
                if (current.cta_60200100401010 != null)
                    current.Total60200100401000 += (Decimal)current.cta_60200100401010;
                if (current.cta_60200100401020 != null)
                    current.Total60200100401000 += (Decimal)current.cta_60200100401020;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100400000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100400000.cta_60200100402000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100400000.cta_60200100402000;
                current.Total60200100402000 = 0;
                if (current.cta_60200100402010 != null)
                    current.Total60200100402000 += (Decimal)current.cta_60200100402010;
                if (current.cta_60200100402020 != null)
                    current.Total60200100402000 += (Decimal)current.cta_60200100402020;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100400000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000.cta_60200100400000;
                current.Total60200100400000 = 0;
                if (current.cta_60200100401000 != null && current.cta_60200100401000.Total60200100401000 != 0)
                    current.Total60200100400000 += (Decimal)current.cta_60200100401000.Total60200100401000;
                if (current.cta_60200100402000 != null && current.cta_60200100402000.Total60200100402000 != 0)
                    current.Total60200100400000 += (Decimal)current.cta_60200100402000.Total60200100402000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200100000000;
                current.Total60200100000000 = 0;
                if (current.cta_60200100200000 != null && current.cta_60200100200000.Total60200100200000 != 0)
                    current.Total60200100000000 += (Decimal)current.cta_60200100200000.Total60200100200000;
                if (current.cta_60200100300000 != null && current.cta_60200100300000.Total60200100300000 != 0)
                    current.Total60200100000000 += (Decimal)current.cta_60200100300000.Total60200100300000;
                if (current.cta_60200100400000 != null && current.cta_60200100400000.Total60200100400000 != 0)
                    current.Total60200100000000 += (Decimal)current.cta_60200100400000.Total60200100400000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200700000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200700000000.cta_60200700100000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200700000000.cta_60200700100000;
                current.Total60200700100000 = 0;
                if (current.cta_60200700101000 != null)
                    current.Total60200700100000 += (Decimal)current.cta_60200700101000;
                if (current.cta_60200700102000 != null)
                    current.Total60200700100000 += (Decimal)current.cta_60200700102000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200700000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200700000000.cta_60200700200000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200700000000.cta_60200700200000;
                current.Total60200700200000 = 0;
                if (current.cta_60200700201000 != null)
                    current.Total60200700200000 += (Decimal)current.cta_60200700201000;
                if (current.cta_60200700202000 != null)
                    current.Total60200700200000 += (Decimal)current.cta_60200700202000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200700000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200700000000.cta_60200700300000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200700000000.cta_60200700300000;
                current.Total60200700300000 = 0;
                if (current.cta_60200700301000 != null)
                    current.Total60200700300000 += (Decimal)current.cta_60200700301000;
                if (current.cta_60200700302000 != null)
                    current.Total60200700300000 += (Decimal)current.cta_60200700302000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200700000000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200700000000;
                current.Total60200700000000 = 0;
                if (current.cta_60200700100000 != null && current.cta_60200700100000.Total60200700100000 != 0)
                    current.Total60200700000000 += (Decimal)current.cta_60200700100000.Total60200700100000;
                if (current.cta_60200700200000 != null && current.cta_60200700200000.Total60200700200000 != 0)
                    current.Total60200700000000 += (Decimal)current.cta_60200700200000.Total60200700200000;
                if (current.cta_60200700300000 != null && current.cta_60200700300000.Total60200700300000 != 0)
                    current.Total60200700000000 += (Decimal)current.cta_60200700300000.Total60200700300000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200900000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200900000000.cta_60200900100000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200900000000.cta_60200900100000;
                current.Total60200900100000 = 0;
                if (current.cta_60200900101000 != null)
                    current.Total60200900100000 += (Decimal)current.cta_60200900101000;
                if (current.cta_60200900102000 != null)
                    current.Total60200900100000 += (Decimal)current.cta_60200900102000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200900000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200900000000.cta_60200900200000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200900000000.cta_60200900200000;
                current.Total60200900200000 = 0;
                if (current.cta_60200900201000 != null)
                    current.Total60200900200000 += (Decimal)current.cta_60200900201000;
                if (current.cta_60200900202000 != null)
                    current.Total60200900200000 += (Decimal)current.cta_60200900202000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null && modelo.cta_60000000000000.cta_60200000000000.cta_60200900000000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000.cta_60200900000000;
                current.Total60200900000000 = 0;
                if (current.cta_60200900100000 != null && current.cta_60200900100000.Total60200900100000 != 0)
                    current.Total60200900000000 += (Decimal)current.cta_60200900100000.Total60200900100000;
                if (current.cta_60200900200000 != null && current.cta_60200900200000.Total60200900200000 != 0)
                    current.Total60200900000000 += (Decimal)current.cta_60200900200000.Total60200900200000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60200000000000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60200000000000;
                current.Total60200000000000 = 0;
                if (current.cta_60200100000000 != null && current.cta_60200100000000.Total60200100000000 != 0)
                    current.Total60200000000000 += (Decimal)current.cta_60200100000000.Total60200100000000;
                if (current.cta_60200700000000 != null && current.cta_60200700000000.Total60200700000000 != 0)
                    current.Total60200000000000 += (Decimal)current.cta_60200700000000.Total60200700000000;
                if (current.cta_60200900000000 != null && current.cta_60200900000000.Total60200900000000 != 0)
                    current.Total60200000000000 += (Decimal)current.cta_60200900000000.Total60200900000000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100100000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100100000.cta_60300100101000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100100000.cta_60300100101000;
                current.Total60300100101000 = 0;
                if (current.cta_60300100101010 != null)
                    current.Total60300100101000 += (Decimal)current.cta_60300100101010;
                if (current.cta_60300100101020 != null)
                    current.Total60300100101000 += (Decimal)current.cta_60300100101020;
                if (current.cta_60300100101030 != null)
                    current.Total60300100101000 += (Decimal)current.cta_60300100101030;
                if (current.cta_60300100101040 != null)
                    current.Total60300100101000 += (Decimal)current.cta_60300100101040;
                if (current.cta_60300100101050 != null)
                    current.Total60300100101000 += (Decimal)current.cta_60300100101050;
                if (current.cta_60300100101060 != null)
                    current.Total60300100101000 += (Decimal)current.cta_60300100101060;
                if (current.cta_60300100101070 != null)
                    current.Total60300100101000 += (Decimal)current.cta_60300100101070;
                if (current.cta_60300100101080 != null)
                    current.Total60300100101000 += (Decimal)current.cta_60300100101080;
                if (current.cta_60300100101990 != null)
                    current.Total60300100101000 += (Decimal)current.cta_60300100101990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100100000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100100000.cta_60300100102000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100100000.cta_60300100102000;
                current.Total60300100102000 = 0;
                if (current.cta_60300100102010 != null)
                    current.Total60300100102000 += (Decimal)current.cta_60300100102010;
                if (current.cta_60300100102020 != null)
                    current.Total60300100102000 += (Decimal)current.cta_60300100102020;
                if (current.cta_60300100102030 != null)
                    current.Total60300100102000 += (Decimal)current.cta_60300100102030;
                if (current.cta_60300100102040 != null)
                    current.Total60300100102000 += (Decimal)current.cta_60300100102040;
                if (current.cta_60300100102050 != null)
                    current.Total60300100102000 += (Decimal)current.cta_60300100102050;
                if (current.cta_60300100102060 != null)
                    current.Total60300100102000 += (Decimal)current.cta_60300100102060;
                if (current.cta_60300100102070 != null)
                    current.Total60300100102000 += (Decimal)current.cta_60300100102070;
                if (current.cta_60300100102080 != null)
                    current.Total60300100102000 += (Decimal)current.cta_60300100102080;
                if (current.cta_60300100102990 != null)
                    current.Total60300100102000 += (Decimal)current.cta_60300100102990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100100000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100100000;
                current.Total60300100100000 = 0;
                if (current.cta_60300100101000 != null && current.cta_60300100101000.Total60300100101000 != 0)
                    current.Total60300100100000 += (Decimal)current.cta_60300100101000.Total60300100101000;
                if (current.cta_60300100102000 != null && current.cta_60300100102000.Total60300100102000 != 0)
                    current.Total60300100100000 += (Decimal)current.cta_60300100102000.Total60300100102000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100200000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100200000.cta_60300100201000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100200000.cta_60300100201000;
                current.Total60300100201000 = 0;
                if (current.cta_60300100201010 != null)
                    current.Total60300100201000 += (Decimal)current.cta_60300100201010;
                if (current.cta_60300100201020 != null)
                    current.Total60300100201000 += (Decimal)current.cta_60300100201020;
                if (current.cta_60300100201030 != null)
                    current.Total60300100201000 += (Decimal)current.cta_60300100201030;
                if (current.cta_60300100201040 != null)
                    current.Total60300100201000 += (Decimal)current.cta_60300100201040;
                if (current.cta_60300100201050 != null)
                    current.Total60300100201000 += (Decimal)current.cta_60300100201050;
                if (current.cta_60300100201060 != null)
                    current.Total60300100201000 += (Decimal)current.cta_60300100201060;
                if (current.cta_60300100201070 != null)
                    current.Total60300100201000 += (Decimal)current.cta_60300100201070;
                if (current.cta_60300100201080 != null)
                    current.Total60300100201000 += (Decimal)current.cta_60300100201080;
                if (current.cta_60300100201990 != null)
                    current.Total60300100201000 += (Decimal)current.cta_60300100201990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100200000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100200000.cta_60300100202000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100200000.cta_60300100202000;
                current.Total60300100202000 = 0;
                if (current.cta_60300100202010 != null)
                    current.Total60300100202000 += (Decimal)current.cta_60300100202010;
                if (current.cta_60300100202020 != null)
                    current.Total60300100202000 += (Decimal)current.cta_60300100202020;
                if (current.cta_60300100202030 != null)
                    current.Total60300100202000 += (Decimal)current.cta_60300100202030;
                if (current.cta_60300100202040 != null)
                    current.Total60300100202000 += (Decimal)current.cta_60300100202040;
                if (current.cta_60300100202050 != null)
                    current.Total60300100202000 += (Decimal)current.cta_60300100202050;
                if (current.cta_60300100202060 != null)
                    current.Total60300100202000 += (Decimal)current.cta_60300100202060;
                if (current.cta_60300100202070 != null)
                    current.Total60300100202000 += (Decimal)current.cta_60300100202070;
                if (current.cta_60300100202080 != null)
                    current.Total60300100202000 += (Decimal)current.cta_60300100202080;
                if (current.cta_60300100202990 != null)
                    current.Total60300100202000 += (Decimal)current.cta_60300100202990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100200000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100200000;
                current.Total60300100200000 = 0;
                if (current.cta_60300100201000 != null && current.cta_60300100201000.Total60300100201000 != 0)
                    current.Total60300100200000 += (Decimal)current.cta_60300100201000.Total60300100201000;
                if (current.cta_60300100202000 != null && current.cta_60300100202000.Total60300100202000 != 0)
                    current.Total60300100200000 += (Decimal)current.cta_60300100202000.Total60300100202000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100300000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100300000.cta_60300100301000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100300000.cta_60300100301000;
                current.Total60300100301000 = 0;
                if (current.cta_60300100301010 != null)
                    current.Total60300100301000 += (Decimal)current.cta_60300100301010;
                if (current.cta_60300100301020 != null)
                    current.Total60300100301000 += (Decimal)current.cta_60300100301020;
                if (current.cta_60300100301030 != null)
                    current.Total60300100301000 += (Decimal)current.cta_60300100301030;
                if (current.cta_60300100301040 != null)
                    current.Total60300100301000 += (Decimal)current.cta_60300100301040;
                if (current.cta_60300100301990 != null)
                    current.Total60300100301000 += (Decimal)current.cta_60300100301990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100300000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100300000.cta_60300100302000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100300000.cta_60300100302000;
                current.Total60300100302000 = 0;
                if (current.cta_60300100302010 != null)
                    current.Total60300100302000 += (Decimal)current.cta_60300100302010;
                if (current.cta_60300100302020 != null)
                    current.Total60300100302000 += (Decimal)current.cta_60300100302020;
                if (current.cta_60300100302030 != null)
                    current.Total60300100302000 += (Decimal)current.cta_60300100302030;
                if (current.cta_60300100302040 != null)
                    current.Total60300100302000 += (Decimal)current.cta_60300100302040;
                if (current.cta_60300100302990 != null)
                    current.Total60300100302000 += (Decimal)current.cta_60300100302990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100300000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100300000;
                current.Total60300100300000 = 0;
                if (current.cta_60300100301000 != null && current.cta_60300100301000.Total60300100301000 != 0)
                    current.Total60300100300000 += (Decimal)current.cta_60300100301000.Total60300100301000;
                if (current.cta_60300100302000 != null && current.cta_60300100302000.Total60300100302000 != 0)
                    current.Total60300100300000 += (Decimal)current.cta_60300100302000.Total60300100302000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100400000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100400000.cta_60300100401000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100400000.cta_60300100401000;
                current.Total60300100401000 = 0;
                if (current.cta_60300100401010 != null)
                    current.Total60300100401000 += (Decimal)current.cta_60300100401010;
                if (current.cta_60300100401020 != null)
                    current.Total60300100401000 += (Decimal)current.cta_60300100401020;
                if (current.cta_60300100401030 != null)
                    current.Total60300100401000 += (Decimal)current.cta_60300100401030;
                if (current.cta_60300100401040 != null)
                    current.Total60300100401000 += (Decimal)current.cta_60300100401040;
                if (current.cta_60300100401990 != null)
                    current.Total60300100401000 += (Decimal)current.cta_60300100401990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100400000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100400000.cta_60300100402000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100400000.cta_60300100402000;
                current.Total60300100402000 = 0;
                if (current.cta_60300100402010 != null)
                    current.Total60300100402000 += (Decimal)current.cta_60300100402010;
                if (current.cta_60300100402020 != null)
                    current.Total60300100402000 += (Decimal)current.cta_60300100402020;
                if (current.cta_60300100402030 != null)
                    current.Total60300100402000 += (Decimal)current.cta_60300100402030;
                if (current.cta_60300100402040 != null)
                    current.Total60300100402000 += (Decimal)current.cta_60300100402040;
                if (current.cta_60300100402990 != null)
                    current.Total60300100402000 += (Decimal)current.cta_60300100402990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100400000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100400000;
                current.Total60300100400000 = 0;
                if (current.cta_60300100401000 != null && current.cta_60300100401000.Total60300100401000 != 0)
                    current.Total60300100400000 += (Decimal)current.cta_60300100401000.Total60300100401000;
                if (current.cta_60300100402000 != null && current.cta_60300100402000.Total60300100402000 != 0)
                    current.Total60300100400000 += (Decimal)current.cta_60300100402000.Total60300100402000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100500000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100500000.cta_60300100501000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100500000.cta_60300100501000;
                current.Total60300100501000 = 0;
                if (current.cta_60300100501010 != null)
                    current.Total60300100501000 += (Decimal)current.cta_60300100501010;
                if (current.cta_60300100501020 != null)
                    current.Total60300100501000 += (Decimal)current.cta_60300100501020;
                if (current.cta_60300100501030 != null)
                    current.Total60300100501000 += (Decimal)current.cta_60300100501030;
                if (current.cta_60300100501040 != null)
                    current.Total60300100501000 += (Decimal)current.cta_60300100501040;
                if (current.cta_60300100501050 != null)
                    current.Total60300100501000 += (Decimal)current.cta_60300100501050;
                if (current.cta_60300100501060 != null)
                    current.Total60300100501000 += (Decimal)current.cta_60300100501060;
                if (current.cta_60300100501070 != null)
                    current.Total60300100501000 += (Decimal)current.cta_60300100501070;
                if (current.cta_60300100501080 != null)
                    current.Total60300100501000 += (Decimal)current.cta_60300100501080;
                if (current.cta_60300100501990 != null)
                    current.Total60300100501000 += (Decimal)current.cta_60300100501990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100500000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100500000.cta_60300100502000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100500000.cta_60300100502000;
                current.Total60300100502000 = 0;
                if (current.cta_60300100502010 != null)
                    current.Total60300100502000 += (Decimal)current.cta_60300100502010;
                if (current.cta_60300100502020 != null)
                    current.Total60300100502000 += (Decimal)current.cta_60300100502020;
                if (current.cta_60300100502030 != null)
                    current.Total60300100502000 += (Decimal)current.cta_60300100502030;
                if (current.cta_60300100502040 != null)
                    current.Total60300100502000 += (Decimal)current.cta_60300100502040;
                if (current.cta_60300100502050 != null)
                    current.Total60300100502000 += (Decimal)current.cta_60300100502050;
                if (current.cta_60300100502060 != null)
                    current.Total60300100502000 += (Decimal)current.cta_60300100502060;
                if (current.cta_60300100502070 != null)
                    current.Total60300100502000 += (Decimal)current.cta_60300100502070;
                if (current.cta_60300100502080 != null)
                    current.Total60300100502000 += (Decimal)current.cta_60300100502080;
                if (current.cta_60300100502990 != null)
                    current.Total60300100502000 += (Decimal)current.cta_60300100502990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100500000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100500000;
                current.Total60300100500000 = 0;
                if (current.cta_60300100501000 != null && current.cta_60300100501000.Total60300100501000 != 0)
                    current.Total60300100500000 += (Decimal)current.cta_60300100501000.Total60300100501000;
                if (current.cta_60300100502000 != null && current.cta_60300100502000.Total60300100502000 != 0)
                    current.Total60300100500000 += (Decimal)current.cta_60300100502000.Total60300100502000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100600000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100600000.cta_60300100601000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100600000.cta_60300100601000;
                current.Total60300100601000 = 0;
                if (current.cta_60300100601010 != null)
                    current.Total60300100601000 += (Decimal)current.cta_60300100601010;
                if (current.cta_60300100601020 != null)
                    current.Total60300100601000 += (Decimal)current.cta_60300100601020;
                if (current.cta_60300100601030 != null)
                    current.Total60300100601000 += (Decimal)current.cta_60300100601030;
                if (current.cta_60300100601040 != null)
                    current.Total60300100601000 += (Decimal)current.cta_60300100601040;
                if (current.cta_60300100601050 != null)
                    current.Total60300100601000 += (Decimal)current.cta_60300100601050;
                if (current.cta_60300100601060 != null)
                    current.Total60300100601000 += (Decimal)current.cta_60300100601060;
                if (current.cta_60300100601070 != null)
                    current.Total60300100601000 += (Decimal)current.cta_60300100601070;
                if (current.cta_60300100601080 != null)
                    current.Total60300100601000 += (Decimal)current.cta_60300100601080;
                if (current.cta_60300100601990 != null)
                    current.Total60300100601000 += (Decimal)current.cta_60300100601990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100600000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100600000.cta_60300100602000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100600000.cta_60300100602000;
                current.Total60300100602000 = 0;
                if (current.cta_60300100602010 != null)
                    current.Total60300100602000 += (Decimal)current.cta_60300100602010;
                if (current.cta_60300100602020 != null)
                    current.Total60300100602000 += (Decimal)current.cta_60300100602020;
                if (current.cta_60300100602030 != null)
                    current.Total60300100602000 += (Decimal)current.cta_60300100602030;
                if (current.cta_60300100602040 != null)
                    current.Total60300100602000 += (Decimal)current.cta_60300100602040;
                if (current.cta_60300100602050 != null)
                    current.Total60300100602000 += (Decimal)current.cta_60300100602050;
                if (current.cta_60300100602060 != null)
                    current.Total60300100602000 += (Decimal)current.cta_60300100602060;
                if (current.cta_60300100602070 != null)
                    current.Total60300100602000 += (Decimal)current.cta_60300100602070;
                if (current.cta_60300100602080 != null)
                    current.Total60300100602000 += (Decimal)current.cta_60300100602080;
                if (current.cta_60300100602990 != null)
                    current.Total60300100602000 += (Decimal)current.cta_60300100602990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100600000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100600000;
                current.Total60300100600000 = 0;
                if (current.cta_60300100601000 != null && current.cta_60300100601000.Total60300100601000 != 0)
                    current.Total60300100600000 += (Decimal)current.cta_60300100601000.Total60300100601000;
                if (current.cta_60300100602000 != null && current.cta_60300100602000.Total60300100602000 != 0)
                    current.Total60300100600000 += (Decimal)current.cta_60300100602000.Total60300100602000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100700000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100700000.cta_60300100701000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100700000.cta_60300100701000;
                current.Total60300100701000 = 0;
                if (current.cta_60300100701010 != null)
                    current.Total60300100701000 += (Decimal)current.cta_60300100701010;
                if (current.cta_60300100701020 != null)
                    current.Total60300100701000 += (Decimal)current.cta_60300100701020;
                if (current.cta_60300100701030 != null)
                    current.Total60300100701000 += (Decimal)current.cta_60300100701030;
                if (current.cta_60300100701040 != null)
                    current.Total60300100701000 += (Decimal)current.cta_60300100701040;
                if (current.cta_60300100701990 != null)
                    current.Total60300100701000 += (Decimal)current.cta_60300100701990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100700000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100700000.cta_60300100702000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100700000.cta_60300100702000;
                current.Total60300100702000 = 0;
                if (current.cta_60300100702010 != null)
                    current.Total60300100702000 += (Decimal)current.cta_60300100702010;
                if (current.cta_60300100702020 != null)
                    current.Total60300100702000 += (Decimal)current.cta_60300100702020;
                if (current.cta_60300100702030 != null)
                    current.Total60300100702000 += (Decimal)current.cta_60300100702030;
                if (current.cta_60300100702040 != null)
                    current.Total60300100702000 += (Decimal)current.cta_60300100702040;
                if (current.cta_60300100702990 != null)
                    current.Total60300100702000 += (Decimal)current.cta_60300100702990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100700000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100700000;
                current.Total60300100700000 = 0;
                if (current.cta_60300100701000 != null && current.cta_60300100701000.Total60300100701000 != 0)
                    current.Total60300100700000 += (Decimal)current.cta_60300100701000.Total60300100701000;
                if (current.cta_60300100702000 != null && current.cta_60300100702000.Total60300100702000 != 0)
                    current.Total60300100700000 += (Decimal)current.cta_60300100702000.Total60300100702000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100800000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100800000.cta_60300100801000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100800000.cta_60300100801000;
                current.Total60300100801000 = 0;
                if (current.cta_60300100801010 != null)
                    current.Total60300100801000 += (Decimal)current.cta_60300100801010;
                if (current.cta_60300100801020 != null)
                    current.Total60300100801000 += (Decimal)current.cta_60300100801020;
                if (current.cta_60300100801030 != null)
                    current.Total60300100801000 += (Decimal)current.cta_60300100801030;
                if (current.cta_60300100801040 != null)
                    current.Total60300100801000 += (Decimal)current.cta_60300100801040;
                if (current.cta_60300100801990 != null)
                    current.Total60300100801000 += (Decimal)current.cta_60300100801990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100800000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100800000.cta_60300100802000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100800000.cta_60300100802000;
                current.Total60300100802000 = 0;
                if (current.cta_60300100802010 != null)
                    current.Total60300100802000 += (Decimal)current.cta_60300100802010;
                if (current.cta_60300100802020 != null)
                    current.Total60300100802000 += (Decimal)current.cta_60300100802020;
                if (current.cta_60300100802030 != null)
                    current.Total60300100802000 += (Decimal)current.cta_60300100802030;
                if (current.cta_60300100802040 != null)
                    current.Total60300100802000 += (Decimal)current.cta_60300100802040;
                if (current.cta_60300100802990 != null)
                    current.Total60300100802000 += (Decimal)current.cta_60300100802990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100800000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100800000;
                current.Total60300100800000 = 0;
                if (current.cta_60300100801000 != null && current.cta_60300100801000.Total60300100801000 != 0)
                    current.Total60300100800000 += (Decimal)current.cta_60300100801000.Total60300100801000;
                if (current.cta_60300100802000 != null && current.cta_60300100802000.Total60300100802000 != 0)
                    current.Total60300100800000 += (Decimal)current.cta_60300100802000.Total60300100802000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100900000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100900000.cta_60300100901000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100900000.cta_60300100901000;
                current.Total60300100901000 = 0;
                if (current.cta_60300100901010 != null)
                    current.Total60300100901000 += (Decimal)current.cta_60300100901010;
                if (current.cta_60300100901020 != null)
                    current.Total60300100901000 += (Decimal)current.cta_60300100901020;
                if (current.cta_60300100901030 != null)
                    current.Total60300100901000 += (Decimal)current.cta_60300100901030;
                if (current.cta_60300100901040 != null)
                    current.Total60300100901000 += (Decimal)current.cta_60300100901040;
                if (current.cta_60300100901050 != null)
                    current.Total60300100901000 += (Decimal)current.cta_60300100901050;
                if (current.cta_60300100901060 != null)
                    current.Total60300100901000 += (Decimal)current.cta_60300100901060;
                if (current.cta_60300100901070 != null)
                    current.Total60300100901000 += (Decimal)current.cta_60300100901070;
                if (current.cta_60300100901080 != null)
                    current.Total60300100901000 += (Decimal)current.cta_60300100901080;
                if (current.cta_60300100901990 != null)
                    current.Total60300100901000 += (Decimal)current.cta_60300100901990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100900000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100900000.cta_60300100902000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100900000.cta_60300100902000;
                current.Total60300100902000 = 0;
                if (current.cta_60300100902010 != null)
                    current.Total60300100902000 += (Decimal)current.cta_60300100902010;
                if (current.cta_60300100902020 != null)
                    current.Total60300100902000 += (Decimal)current.cta_60300100902020;
                if (current.cta_60300100902030 != null)
                    current.Total60300100902000 += (Decimal)current.cta_60300100902030;
                if (current.cta_60300100902040 != null)
                    current.Total60300100902000 += (Decimal)current.cta_60300100902040;
                if (current.cta_60300100902050 != null)
                    current.Total60300100902000 += (Decimal)current.cta_60300100902050;
                if (current.cta_60300100902060 != null)
                    current.Total60300100902000 += (Decimal)current.cta_60300100902060;
                if (current.cta_60300100902070 != null)
                    current.Total60300100902000 += (Decimal)current.cta_60300100902070;
                if (current.cta_60300100902080 != null)
                    current.Total60300100902000 += (Decimal)current.cta_60300100902080;
                if (current.cta_60300100902990 != null)
                    current.Total60300100902000 += (Decimal)current.cta_60300100902990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100900000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300100900000;
                current.Total60300100900000 = 0;
                if (current.cta_60300100901000 != null && current.cta_60300100901000.Total60300100901000 != 0)
                    current.Total60300100900000 += (Decimal)current.cta_60300100901000.Total60300100901000;
                if (current.cta_60300100902000 != null && current.cta_60300100902000.Total60300100902000 != 0)
                    current.Total60300100900000 += (Decimal)current.cta_60300100902000.Total60300100902000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101000000.cta_60300101001000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101000000.cta_60300101001000;
                current.Total60300101001000 = 0;
                if (current.cta_60300101001010 != null)
                    current.Total60300101001000 += (Decimal)current.cta_60300101001010;
                if (current.cta_60300101001020 != null)
                    current.Total60300101001000 += (Decimal)current.cta_60300101001020;
                if (current.cta_60300101001030 != null)
                    current.Total60300101001000 += (Decimal)current.cta_60300101001030;
                if (current.cta_60300101001040 != null)
                    current.Total60300101001000 += (Decimal)current.cta_60300101001040;
                if (current.cta_60300101001050 != null)
                    current.Total60300101001000 += (Decimal)current.cta_60300101001050;
                if (current.cta_60300101001060 != null)
                    current.Total60300101001000 += (Decimal)current.cta_60300101001060;
                if (current.cta_60300101001070 != null)
                    current.Total60300101001000 += (Decimal)current.cta_60300101001070;
                if (current.cta_60300101001080 != null)
                    current.Total60300101001000 += (Decimal)current.cta_60300101001080;
                if (current.cta_60300101001990 != null)
                    current.Total60300101001000 += (Decimal)current.cta_60300101001990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101000000.cta_60300101002000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101000000.cta_60300101002000;
                current.Total60300101002000 = 0;
                if (current.cta_60300101002010 != null)
                    current.Total60300101002000 += (Decimal)current.cta_60300101002010;
                if (current.cta_60300101002020 != null)
                    current.Total60300101002000 += (Decimal)current.cta_60300101002020;
                if (current.cta_60300101002030 != null)
                    current.Total60300101002000 += (Decimal)current.cta_60300101002030;
                if (current.cta_60300101002040 != null)
                    current.Total60300101002000 += (Decimal)current.cta_60300101002040;
                if (current.cta_60300101002050 != null)
                    current.Total60300101002000 += (Decimal)current.cta_60300101002050;
                if (current.cta_60300101002060 != null)
                    current.Total60300101002000 += (Decimal)current.cta_60300101002060;
                if (current.cta_60300101002070 != null)
                    current.Total60300101002000 += (Decimal)current.cta_60300101002070;
                if (current.cta_60300101002080 != null)
                    current.Total60300101002000 += (Decimal)current.cta_60300101002080;
                if (current.cta_60300101002990 != null)
                    current.Total60300101002000 += (Decimal)current.cta_60300101002990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101000000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101000000;
                current.Total60300101000000 = 0;
                if (current.cta_60300101001000 != null && current.cta_60300101001000.Total60300101001000 != 0)
                    current.Total60300101000000 += (Decimal)current.cta_60300101001000.Total60300101001000;
                if (current.cta_60300101002000 != null && current.cta_60300101002000.Total60300101002000 != 0)
                    current.Total60300101000000 += (Decimal)current.cta_60300101002000.Total60300101002000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101100000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101100000.cta_60300101101000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101100000.cta_60300101101000;
                current.Total60300101101000 = 0;
                if (current.cta_60300101101010 != null)
                    current.Total60300101101000 += (Decimal)current.cta_60300101101010;
                if (current.cta_60300101101020 != null)
                    current.Total60300101101000 += (Decimal)current.cta_60300101101020;
                if (current.cta_60300101101030 != null)
                    current.Total60300101101000 += (Decimal)current.cta_60300101101030;
                if (current.cta_60300101101040 != null)
                    current.Total60300101101000 += (Decimal)current.cta_60300101101040;
                if (current.cta_60300101101990 != null)
                    current.Total60300101101000 += (Decimal)current.cta_60300101101990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101100000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101100000.cta_60300101102000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101100000.cta_60300101102000;
                current.Total60300101102000 = 0;
                if (current.cta_60300101102010 != null)
                    current.Total60300101102000 += (Decimal)current.cta_60300101102010;
                if (current.cta_60300101102020 != null)
                    current.Total60300101102000 += (Decimal)current.cta_60300101102020;
                if (current.cta_60300101102030 != null)
                    current.Total60300101102000 += (Decimal)current.cta_60300101102030;
                if (current.cta_60300101102040 != null)
                    current.Total60300101102000 += (Decimal)current.cta_60300101102040;
                if (current.cta_60300101102990 != null)
                    current.Total60300101102000 += (Decimal)current.cta_60300101102990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101100000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101100000;
                current.Total60300101100000 = 0;
                if (current.cta_60300101101000 != null && current.cta_60300101101000.Total60300101101000 != 0)
                    current.Total60300101100000 += (Decimal)current.cta_60300101101000.Total60300101101000;
                if (current.cta_60300101102000 != null && current.cta_60300101102000.Total60300101102000 != 0)
                    current.Total60300101100000 += (Decimal)current.cta_60300101102000.Total60300101102000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101200000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101200000.cta_60300101201000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101200000.cta_60300101201000;
                current.Total60300101201000 = 0;
                if (current.cta_60300101201010 != null)
                    current.Total60300101201000 += (Decimal)current.cta_60300101201010;
                if (current.cta_60300101201020 != null)
                    current.Total60300101201000 += (Decimal)current.cta_60300101201020;
                if (current.cta_60300101201030 != null)
                    current.Total60300101201000 += (Decimal)current.cta_60300101201030;
                if (current.cta_60300101201040 != null)
                    current.Total60300101201000 += (Decimal)current.cta_60300101201040;
                if (current.cta_60300101201990 != null)
                    current.Total60300101201000 += (Decimal)current.cta_60300101201990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101200000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101200000.cta_60300101202000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101200000.cta_60300101202000;
                current.Total60300101202000 = 0;
                if (current.cta_60300101202010 != null)
                    current.Total60300101202000 += (Decimal)current.cta_60300101202010;
                if (current.cta_60300101202020 != null)
                    current.Total60300101202000 += (Decimal)current.cta_60300101202020;
                if (current.cta_60300101202030 != null)
                    current.Total60300101202000 += (Decimal)current.cta_60300101202030;
                if (current.cta_60300101202040 != null)
                    current.Total60300101202000 += (Decimal)current.cta_60300101202040;
                if (current.cta_60300101202990 != null)
                    current.Total60300101202000 += (Decimal)current.cta_60300101202990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101200000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300101200000;
                current.Total60300101200000 = 0;
                if (current.cta_60300101201000 != null && current.cta_60300101201000.Total60300101201000 != 0)
                    current.Total60300101200000 += (Decimal)current.cta_60300101201000.Total60300101201000;
                if (current.cta_60300101202000 != null && current.cta_60300101202000.Total60300101202000 != 0)
                    current.Total60300101200000 += (Decimal)current.cta_60300101202000.Total60300101202000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300109900000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000.cta_60300109900000;
                current.Total60300109900000 = 0;
                if (current.cta_60300109901000 != null)
                    current.Total60300109900000 += (Decimal)current.cta_60300109901000;
                if (current.cta_60300109902000 != null)
                    current.Total60300109900000 += (Decimal)current.cta_60300109902000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null && modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000.cta_60300100000000;
                current.Total60300100000000 = 0;
                if (current.cta_60300100100000 != null && current.cta_60300100100000.Total60300100100000 != 0)
                    current.Total60300100000000 += (Decimal)current.cta_60300100100000.Total60300100100000;
                if (current.cta_60300100200000 != null && current.cta_60300100200000.Total60300100200000 != 0)
                    current.Total60300100000000 += (Decimal)current.cta_60300100200000.Total60300100200000;
                if (current.cta_60300100300000 != null && current.cta_60300100300000.Total60300100300000 != 0)
                    current.Total60300100000000 += (Decimal)current.cta_60300100300000.Total60300100300000;
                if (current.cta_60300100400000 != null && current.cta_60300100400000.Total60300100400000 != 0)
                    current.Total60300100000000 += (Decimal)current.cta_60300100400000.Total60300100400000;
                if (current.cta_60300100500000 != null && current.cta_60300100500000.Total60300100500000 != 0)
                    current.Total60300100000000 += (Decimal)current.cta_60300100500000.Total60300100500000;
                if (current.cta_60300100600000 != null && current.cta_60300100600000.Total60300100600000 != 0)
                    current.Total60300100000000 += (Decimal)current.cta_60300100600000.Total60300100600000;
                if (current.cta_60300100700000 != null && current.cta_60300100700000.Total60300100700000 != 0)
                    current.Total60300100000000 += (Decimal)current.cta_60300100700000.Total60300100700000;
                if (current.cta_60300100800000 != null && current.cta_60300100800000.Total60300100800000 != 0)
                    current.Total60300100000000 += (Decimal)current.cta_60300100800000.Total60300100800000;
                if (current.cta_60300100900000 != null && current.cta_60300100900000.Total60300100900000 != 0)
                    current.Total60300100000000 += (Decimal)current.cta_60300100900000.Total60300100900000;
                if (current.cta_60300101000000 != null && current.cta_60300101000000.Total60300101000000 != 0)
                    current.Total60300100000000 += (Decimal)current.cta_60300101000000.Total60300101000000;
                if (current.cta_60300101100000 != null && current.cta_60300101100000.Total60300101100000 != 0)
                    current.Total60300100000000 += (Decimal)current.cta_60300101100000.Total60300101100000;
                if (current.cta_60300101200000 != null && current.cta_60300101200000.Total60300101200000 != 0)
                    current.Total60300100000000 += (Decimal)current.cta_60300101200000.Total60300101200000;
                if (current.cta_60300109900000 != null && current.cta_60300109900000.Total60300109900000 != 0)
                    current.Total60300100000000 += (Decimal)current.cta_60300109900000.Total60300109900000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60300000000000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60300000000000;
                current.Total60300000000000 = 0;
                if (current.cta_60300100000000 != null && current.cta_60300100000000.Total60300100000000 != 0)
                    current.Total60300000000000 += (Decimal)current.cta_60300100000000.Total60300100000000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100100000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100100000.cta_60400100101000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100100000.cta_60400100101000;
                current.Total60400100101000 = 0;
                if (current.cta_60400100101010 != null)
                    current.Total60400100101000 += (Decimal)current.cta_60400100101010;
                if (current.cta_60400100101020 != null)
                    current.Total60400100101000 += (Decimal)current.cta_60400100101020;
                if (current.cta_60400100101030 != null)
                    current.Total60400100101000 += (Decimal)current.cta_60400100101030;
                if (current.cta_60400100101040 != null)
                    current.Total60400100101000 += (Decimal)current.cta_60400100101040;
                if (current.cta_60400100101050 != null)
                    current.Total60400100101000 += (Decimal)current.cta_60400100101050;
                if (current.cta_60400100101060 != null)
                    current.Total60400100101000 += (Decimal)current.cta_60400100101060;
                if (current.cta_60400100101070 != null)
                    current.Total60400100101000 += (Decimal)current.cta_60400100101070;
                if (current.cta_60400100101080 != null)
                    current.Total60400100101000 += (Decimal)current.cta_60400100101080;
                if (current.cta_60400100101990 != null)
                    current.Total60400100101000 += (Decimal)current.cta_60400100101990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100100000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100100000.cta_60400100102000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100100000.cta_60400100102000;
                current.Total60400100102000 = 0;
                if (current.cta_60400100102010 != null)
                    current.Total60400100102000 += (Decimal)current.cta_60400100102010;
                if (current.cta_60400100102020 != null)
                    current.Total60400100102000 += (Decimal)current.cta_60400100102020;
                if (current.cta_60400100102030 != null)
                    current.Total60400100102000 += (Decimal)current.cta_60400100102030;
                if (current.cta_60400100102040 != null)
                    current.Total60400100102000 += (Decimal)current.cta_60400100102040;
                if (current.cta_60400100102050 != null)
                    current.Total60400100102000 += (Decimal)current.cta_60400100102050;
                if (current.cta_60400100102060 != null)
                    current.Total60400100102000 += (Decimal)current.cta_60400100102060;
                if (current.cta_60400100102070 != null)
                    current.Total60400100102000 += (Decimal)current.cta_60400100102070;
                if (current.cta_60400100102080 != null)
                    current.Total60400100102000 += (Decimal)current.cta_60400100102080;
                if (current.cta_60400100102990 != null)
                    current.Total60400100102000 += (Decimal)current.cta_60400100102990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100100000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100100000;
                current.Total60400100100000 = 0;
                if (current.cta_60400100101000 != null && current.cta_60400100101000.Total60400100101000 != 0)
                    current.Total60400100100000 += (Decimal)current.cta_60400100101000.Total60400100101000;
                if (current.cta_60400100102000 != null && current.cta_60400100102000.Total60400100102000 != 0)
                    current.Total60400100100000 += (Decimal)current.cta_60400100102000.Total60400100102000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100200000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100200000.cta_60400100201000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100200000.cta_60400100201000;
                current.Total60400100201000 = 0;
                if (current.cta_60400100201010 != null)
                    current.Total60400100201000 += (Decimal)current.cta_60400100201010;
                if (current.cta_60400100201020 != null)
                    current.Total60400100201000 += (Decimal)current.cta_60400100201020;
                if (current.cta_60400100201030 != null)
                    current.Total60400100201000 += (Decimal)current.cta_60400100201030;
                if (current.cta_60400100201040 != null)
                    current.Total60400100201000 += (Decimal)current.cta_60400100201040;
                if (current.cta_60400100201050 != null)
                    current.Total60400100201000 += (Decimal)current.cta_60400100201050;
                if (current.cta_60400100201060 != null)
                    current.Total60400100201000 += (Decimal)current.cta_60400100201060;
                if (current.cta_60400100201070 != null)
                    current.Total60400100201000 += (Decimal)current.cta_60400100201070;
                if (current.cta_60400100201080 != null)
                    current.Total60400100201000 += (Decimal)current.cta_60400100201080;
                if (current.cta_60400100201990 != null)
                    current.Total60400100201000 += (Decimal)current.cta_60400100201990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100200000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100200000.cta_60400100202000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100200000.cta_60400100202000;
                current.Total60400100202000 = 0;
                if (current.cta_60400100202010 != null)
                    current.Total60400100202000 += (Decimal)current.cta_60400100202010;
                if (current.cta_60400100202020 != null)
                    current.Total60400100202000 += (Decimal)current.cta_60400100202020;
                if (current.cta_60400100202030 != null)
                    current.Total60400100202000 += (Decimal)current.cta_60400100202030;
                if (current.cta_60400100202040 != null)
                    current.Total60400100202000 += (Decimal)current.cta_60400100202040;
                if (current.cta_60400100202050 != null)
                    current.Total60400100202000 += (Decimal)current.cta_60400100202050;
                if (current.cta_60400100202060 != null)
                    current.Total60400100202000 += (Decimal)current.cta_60400100202060;
                if (current.cta_60400100202070 != null)
                    current.Total60400100202000 += (Decimal)current.cta_60400100202070;
                if (current.cta_60400100202080 != null)
                    current.Total60400100202000 += (Decimal)current.cta_60400100202080;
                if (current.cta_60400100202990 != null)
                    current.Total60400100202000 += (Decimal)current.cta_60400100202990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100200000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100200000;
                current.Total60400100200000 = 0;
                if (current.cta_60400100201000 != null && current.cta_60400100201000.Total60400100201000 != 0)
                    current.Total60400100200000 += (Decimal)current.cta_60400100201000.Total60400100201000;
                if (current.cta_60400100202000 != null && current.cta_60400100202000.Total60400100202000 != 0)
                    current.Total60400100200000 += (Decimal)current.cta_60400100202000.Total60400100202000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100300000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100300000.cta_60400100301000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100300000.cta_60400100301000;
                current.Total60400100301000 = 0;
                if (current.cta_60400100301010 != null)
                    current.Total60400100301000 += (Decimal)current.cta_60400100301010;
                if (current.cta_60400100301020 != null)
                    current.Total60400100301000 += (Decimal)current.cta_60400100301020;
                if (current.cta_60400100301030 != null)
                    current.Total60400100301000 += (Decimal)current.cta_60400100301030;
                if (current.cta_60400100301040 != null)
                    current.Total60400100301000 += (Decimal)current.cta_60400100301040;
                if (current.cta_60400100301990 != null)
                    current.Total60400100301000 += (Decimal)current.cta_60400100301990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100300000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100300000.cta_60400100302000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100300000.cta_60400100302000;
                current.Total60400100302000 = 0;
                if (current.cta_60400100302010 != null)
                    current.Total60400100302000 += (Decimal)current.cta_60400100302010;
                if (current.cta_60400100302020 != null)
                    current.Total60400100302000 += (Decimal)current.cta_60400100302020;
                if (current.cta_60400100302030 != null)
                    current.Total60400100302000 += (Decimal)current.cta_60400100302030;
                if (current.cta_60400100302040 != null)
                    current.Total60400100302000 += (Decimal)current.cta_60400100302040;
                if (current.cta_60400100302990 != null)
                    current.Total60400100302000 += (Decimal)current.cta_60400100302990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100300000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100300000;
                current.Total60400100300000 = 0;
                if (current.cta_60400100301000 != null && current.cta_60400100301000.Total60400100301000 != 0)
                    current.Total60400100300000 += (Decimal)current.cta_60400100301000.Total60400100301000;
                if (current.cta_60400100302000 != null && current.cta_60400100302000.Total60400100302000 != 0)
                    current.Total60400100300000 += (Decimal)current.cta_60400100302000.Total60400100302000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100400000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100400000.cta_60400100401000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100400000.cta_60400100401000;
                current.Total60400100401000 = 0;
                if (current.cta_60400100401010 != null)
                    current.Total60400100401000 += (Decimal)current.cta_60400100401010;
                if (current.cta_60400100401020 != null)
                    current.Total60400100401000 += (Decimal)current.cta_60400100401020;
                if (current.cta_60400100401030 != null)
                    current.Total60400100401000 += (Decimal)current.cta_60400100401030;
                if (current.cta_60400100401040 != null)
                    current.Total60400100401000 += (Decimal)current.cta_60400100401040;
                if (current.cta_60400100401990 != null)
                    current.Total60400100401000 += (Decimal)current.cta_60400100401990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100400000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100400000.cta_60400100402000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100400000.cta_60400100402000;
                current.Total60400100402000 = 0;
                if (current.cta_60400100402010 != null)
                    current.Total60400100402000 += (Decimal)current.cta_60400100402010;
                if (current.cta_60400100402020 != null)
                    current.Total60400100402000 += (Decimal)current.cta_60400100402020;
                if (current.cta_60400100402030 != null)
                    current.Total60400100402000 += (Decimal)current.cta_60400100402030;
                if (current.cta_60400100402040 != null)
                    current.Total60400100402000 += (Decimal)current.cta_60400100402040;
                if (current.cta_60400100402990 != null)
                    current.Total60400100402000 += (Decimal)current.cta_60400100402990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100400000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100400000;
                current.Total60400100400000 = 0;
                if (current.cta_60400100401000 != null && current.cta_60400100401000.Total60400100401000 != 0)
                    current.Total60400100400000 += (Decimal)current.cta_60400100401000.Total60400100401000;
                if (current.cta_60400100402000 != null && current.cta_60400100402000.Total60400100402000 != 0)
                    current.Total60400100400000 += (Decimal)current.cta_60400100402000.Total60400100402000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100500000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100500000.cta_60400100501000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100500000.cta_60400100501000;
                current.Total60400100501000 = 0;
                if (current.cta_60400100501010 != null)
                    current.Total60400100501000 += (Decimal)current.cta_60400100501010;
                if (current.cta_60400100501020 != null)
                    current.Total60400100501000 += (Decimal)current.cta_60400100501020;
                if (current.cta_60400100501030 != null)
                    current.Total60400100501000 += (Decimal)current.cta_60400100501030;
                if (current.cta_60400100501040 != null)
                    current.Total60400100501000 += (Decimal)current.cta_60400100501040;
                if (current.cta_60400100501050 != null)
                    current.Total60400100501000 += (Decimal)current.cta_60400100501050;
                if (current.cta_60400100501060 != null)
                    current.Total60400100501000 += (Decimal)current.cta_60400100501060;
                if (current.cta_60400100501070 != null)
                    current.Total60400100501000 += (Decimal)current.cta_60400100501070;
                if (current.cta_60400100501080 != null)
                    current.Total60400100501000 += (Decimal)current.cta_60400100501080;
                if (current.cta_60400100501990 != null)
                    current.Total60400100501000 += (Decimal)current.cta_60400100501990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100500000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100500000.cta_60400100502000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100500000.cta_60400100502000;
                current.Total60400100502000 = 0;
                if (current.cta_60400100502010 != null)
                    current.Total60400100502000 += (Decimal)current.cta_60400100502010;
                if (current.cta_60400100502020 != null)
                    current.Total60400100502000 += (Decimal)current.cta_60400100502020;
                if (current.cta_60400100502030 != null)
                    current.Total60400100502000 += (Decimal)current.cta_60400100502030;
                if (current.cta_60400100502040 != null)
                    current.Total60400100502000 += (Decimal)current.cta_60400100502040;
                if (current.cta_60400100502050 != null)
                    current.Total60400100502000 += (Decimal)current.cta_60400100502050;
                if (current.cta_60400100502060 != null)
                    current.Total60400100502000 += (Decimal)current.cta_60400100502060;
                if (current.cta_60400100502070 != null)
                    current.Total60400100502000 += (Decimal)current.cta_60400100502070;
                if (current.cta_60400100502080 != null)
                    current.Total60400100502000 += (Decimal)current.cta_60400100502080;
                if (current.cta_60400100502990 != null)
                    current.Total60400100502000 += (Decimal)current.cta_60400100502990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100500000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100500000;
                current.Total60400100500000 = 0;
                if (current.cta_60400100501000 != null && current.cta_60400100501000.Total60400100501000 != 0)
                    current.Total60400100500000 += (Decimal)current.cta_60400100501000.Total60400100501000;
                if (current.cta_60400100502000 != null && current.cta_60400100502000.Total60400100502000 != 0)
                    current.Total60400100500000 += (Decimal)current.cta_60400100502000.Total60400100502000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100600000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100600000.cta_60400100601000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100600000.cta_60400100601000;
                current.Total60400100601000 = 0;
                if (current.cta_60400100601010 != null)
                    current.Total60400100601000 += (Decimal)current.cta_60400100601010;
                if (current.cta_60400100601020 != null)
                    current.Total60400100601000 += (Decimal)current.cta_60400100601020;
                if (current.cta_60400100601030 != null)
                    current.Total60400100601000 += (Decimal)current.cta_60400100601030;
                if (current.cta_60400100601040 != null)
                    current.Total60400100601000 += (Decimal)current.cta_60400100601040;
                if (current.cta_60400100601050 != null)
                    current.Total60400100601000 += (Decimal)current.cta_60400100601050;
                if (current.cta_60400100601060 != null)
                    current.Total60400100601000 += (Decimal)current.cta_60400100601060;
                if (current.cta_60400100601070 != null)
                    current.Total60400100601000 += (Decimal)current.cta_60400100601070;
                if (current.cta_60400100601080 != null)
                    current.Total60400100601000 += (Decimal)current.cta_60400100601080;
                if (current.cta_60400100601990 != null)
                    current.Total60400100601000 += (Decimal)current.cta_60400100601990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100600000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100600000.cta_60400100602000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100600000.cta_60400100602000;
                current.Total60400100602000 = 0;
                if (current.cta_60400100602010 != null)
                    current.Total60400100602000 += (Decimal)current.cta_60400100602010;
                if (current.cta_60400100602020 != null)
                    current.Total60400100602000 += (Decimal)current.cta_60400100602020;
                if (current.cta_60400100602030 != null)
                    current.Total60400100602000 += (Decimal)current.cta_60400100602030;
                if (current.cta_60400100602040 != null)
                    current.Total60400100602000 += (Decimal)current.cta_60400100602040;
                if (current.cta_60400100602050 != null)
                    current.Total60400100602000 += (Decimal)current.cta_60400100602050;
                if (current.cta_60400100602060 != null)
                    current.Total60400100602000 += (Decimal)current.cta_60400100602060;
                if (current.cta_60400100602070 != null)
                    current.Total60400100602000 += (Decimal)current.cta_60400100602070;
                if (current.cta_60400100602080 != null)
                    current.Total60400100602000 += (Decimal)current.cta_60400100602080;
                if (current.cta_60400100602990 != null)
                    current.Total60400100602000 += (Decimal)current.cta_60400100602990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100600000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100600000;
                current.Total60400100600000 = 0;
                if (current.cta_60400100601000 != null && current.cta_60400100601000.Total60400100601000 != 0)
                    current.Total60400100600000 += (Decimal)current.cta_60400100601000.Total60400100601000;
                if (current.cta_60400100602000 != null && current.cta_60400100602000.Total60400100602000 != 0)
                    current.Total60400100600000 += (Decimal)current.cta_60400100602000.Total60400100602000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100700000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100700000.cta_60400100701000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100700000.cta_60400100701000;
                current.Total60400100701000 = 0;
                if (current.cta_60400100701010 != null)
                    current.Total60400100701000 += (Decimal)current.cta_60400100701010;
                if (current.cta_60400100701020 != null)
                    current.Total60400100701000 += (Decimal)current.cta_60400100701020;
                if (current.cta_60400100701030 != null)
                    current.Total60400100701000 += (Decimal)current.cta_60400100701030;
                if (current.cta_60400100701040 != null)
                    current.Total60400100701000 += (Decimal)current.cta_60400100701040;
                if (current.cta_60400100701990 != null)
                    current.Total60400100701000 += (Decimal)current.cta_60400100701990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100700000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100700000.cta_60400100702000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100700000.cta_60400100702000;
                current.Total60400100702000 = 0;
                if (current.cta_60400100702010 != null)
                    current.Total60400100702000 += (Decimal)current.cta_60400100702010;
                if (current.cta_60400100702020 != null)
                    current.Total60400100702000 += (Decimal)current.cta_60400100702020;
                if (current.cta_60400100702030 != null)
                    current.Total60400100702000 += (Decimal)current.cta_60400100702030;
                if (current.cta_60400100702040 != null)
                    current.Total60400100702000 += (Decimal)current.cta_60400100702040;
                if (current.cta_60400100702990 != null)
                    current.Total60400100702000 += (Decimal)current.cta_60400100702990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100700000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100700000;
                current.Total60400100700000 = 0;
                if (current.cta_60400100701000 != null && current.cta_60400100701000.Total60400100701000 != 0)
                    current.Total60400100700000 += (Decimal)current.cta_60400100701000.Total60400100701000;
                if (current.cta_60400100702000 != null && current.cta_60400100702000.Total60400100702000 != 0)
                    current.Total60400100700000 += (Decimal)current.cta_60400100702000.Total60400100702000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100800000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100800000.cta_60400100801000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100800000.cta_60400100801000;
                current.Total60400100801000 = 0;
                if (current.cta_60400100801010 != null)
                    current.Total60400100801000 += (Decimal)current.cta_60400100801010;
                if (current.cta_60400100801020 != null)
                    current.Total60400100801000 += (Decimal)current.cta_60400100801020;
                if (current.cta_60400100801030 != null)
                    current.Total60400100801000 += (Decimal)current.cta_60400100801030;
                if (current.cta_60400100801040 != null)
                    current.Total60400100801000 += (Decimal)current.cta_60400100801040;
                if (current.cta_60400100801990 != null)
                    current.Total60400100801000 += (Decimal)current.cta_60400100801990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100800000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100800000.cta_60400100802000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100800000.cta_60400100802000;
                current.Total60400100802000 = 0;
                if (current.cta_60400100802010 != null)
                    current.Total60400100802000 += (Decimal)current.cta_60400100802010;
                if (current.cta_60400100802020 != null)
                    current.Total60400100802000 += (Decimal)current.cta_60400100802020;
                if (current.cta_60400100802030 != null)
                    current.Total60400100802000 += (Decimal)current.cta_60400100802030;
                if (current.cta_60400100802040 != null)
                    current.Total60400100802000 += (Decimal)current.cta_60400100802040;
                if (current.cta_60400100802990 != null)
                    current.Total60400100802000 += (Decimal)current.cta_60400100802990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100800000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100800000;
                current.Total60400100800000 = 0;
                if (current.cta_60400100801000 != null && current.cta_60400100801000.Total60400100801000 != 0)
                    current.Total60400100800000 += (Decimal)current.cta_60400100801000.Total60400100801000;
                if (current.cta_60400100802000 != null && current.cta_60400100802000.Total60400100802000 != 0)
                    current.Total60400100800000 += (Decimal)current.cta_60400100802000.Total60400100802000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100900000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100900000.cta_60400100901000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100900000.cta_60400100901000;
                current.Total60400100901000 = 0;
                if (current.cta_60400100901010 != null)
                    current.Total60400100901000 += (Decimal)current.cta_60400100901010;
                if (current.cta_60400100901020 != null)
                    current.Total60400100901000 += (Decimal)current.cta_60400100901020;
                if (current.cta_60400100901030 != null)
                    current.Total60400100901000 += (Decimal)current.cta_60400100901030;
                if (current.cta_60400100901040 != null)
                    current.Total60400100901000 += (Decimal)current.cta_60400100901040;
                if (current.cta_60400100901050 != null)
                    current.Total60400100901000 += (Decimal)current.cta_60400100901050;
                if (current.cta_60400100901060 != null)
                    current.Total60400100901000 += (Decimal)current.cta_60400100901060;
                if (current.cta_60400100901070 != null)
                    current.Total60400100901000 += (Decimal)current.cta_60400100901070;
                if (current.cta_60400100901080 != null)
                    current.Total60400100901000 += (Decimal)current.cta_60400100901080;
                if (current.cta_60400100901990 != null)
                    current.Total60400100901000 += (Decimal)current.cta_60400100901990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100900000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100900000.cta_60400100902000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100900000.cta_60400100902000;
                current.Total60400100902000 = 0;
                if (current.cta_60400100902010 != null)
                    current.Total60400100902000 += (Decimal)current.cta_60400100902010;
                if (current.cta_60400100902020 != null)
                    current.Total60400100902000 += (Decimal)current.cta_60400100902020;
                if (current.cta_60400100902030 != null)
                    current.Total60400100902000 += (Decimal)current.cta_60400100902030;
                if (current.cta_60400100902040 != null)
                    current.Total60400100902000 += (Decimal)current.cta_60400100902040;
                if (current.cta_60400100902050 != null)
                    current.Total60400100902000 += (Decimal)current.cta_60400100902050;
                if (current.cta_60400100902060 != null)
                    current.Total60400100902000 += (Decimal)current.cta_60400100902060;
                if (current.cta_60400100902070 != null)
                    current.Total60400100902000 += (Decimal)current.cta_60400100902070;
                if (current.cta_60400100902080 != null)
                    current.Total60400100902000 += (Decimal)current.cta_60400100902080;
                if (current.cta_60400100902990 != null)
                    current.Total60400100902000 += (Decimal)current.cta_60400100902990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100900000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400100900000;
                current.Total60400100900000 = 0;
                if (current.cta_60400100901000 != null && current.cta_60400100901000.Total60400100901000 != 0)
                    current.Total60400100900000 += (Decimal)current.cta_60400100901000.Total60400100901000;
                if (current.cta_60400100902000 != null && current.cta_60400100902000.Total60400100902000 != 0)
                    current.Total60400100900000 += (Decimal)current.cta_60400100902000.Total60400100902000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101000000.cta_60400101001000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101000000.cta_60400101001000;
                current.Total60400101001000 = 0;
                if (current.cta_60400101001010 != null)
                    current.Total60400101001000 += (Decimal)current.cta_60400101001010;
                if (current.cta_60400101001020 != null)
                    current.Total60400101001000 += (Decimal)current.cta_60400101001020;
                if (current.cta_60400101001030 != null)
                    current.Total60400101001000 += (Decimal)current.cta_60400101001030;
                if (current.cta_60400101001040 != null)
                    current.Total60400101001000 += (Decimal)current.cta_60400101001040;
                if (current.cta_60400101001050 != null)
                    current.Total60400101001000 += (Decimal)current.cta_60400101001050;
                if (current.cta_60400101001060 != null)
                    current.Total60400101001000 += (Decimal)current.cta_60400101001060;
                if (current.cta_60400101001070 != null)
                    current.Total60400101001000 += (Decimal)current.cta_60400101001070;
                if (current.cta_60400101001080 != null)
                    current.Total60400101001000 += (Decimal)current.cta_60400101001080;
                if (current.cta_60400101001990 != null)
                    current.Total60400101001000 += (Decimal)current.cta_60400101001990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101000000.cta_60400101002000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101000000.cta_60400101002000;
                current.Total60400101002000 = 0;
                if (current.cta_60400101002010 != null)
                    current.Total60400101002000 += (Decimal)current.cta_60400101002010;
                if (current.cta_60400101002020 != null)
                    current.Total60400101002000 += (Decimal)current.cta_60400101002020;
                if (current.cta_60400101002030 != null)
                    current.Total60400101002000 += (Decimal)current.cta_60400101002030;
                if (current.cta_60400101002040 != null)
                    current.Total60400101002000 += (Decimal)current.cta_60400101002040;
                if (current.cta_60400101002050 != null)
                    current.Total60400101002000 += (Decimal)current.cta_60400101002050;
                if (current.cta_60400101002060 != null)
                    current.Total60400101002000 += (Decimal)current.cta_60400101002060;
                if (current.cta_60400101002070 != null)
                    current.Total60400101002000 += (Decimal)current.cta_60400101002070;
                if (current.cta_60400101002080 != null)
                    current.Total60400101002000 += (Decimal)current.cta_60400101002080;
                if (current.cta_60400101002990 != null)
                    current.Total60400101002000 += (Decimal)current.cta_60400101002990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101000000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101000000;
                current.Total60400101000000 = 0;
                if (current.cta_60400101001000 != null && current.cta_60400101001000.Total60400101001000 != 0)
                    current.Total60400101000000 += (Decimal)current.cta_60400101001000.Total60400101001000;
                if (current.cta_60400101002000 != null && current.cta_60400101002000.Total60400101002000 != 0)
                    current.Total60400101000000 += (Decimal)current.cta_60400101002000.Total60400101002000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101100000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101100000.cta_60400101101000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101100000.cta_60400101101000;
                current.Total60400101101000 = 0;
                if (current.cta_60400101101010 != null)
                    current.Total60400101101000 += (Decimal)current.cta_60400101101010;
                if (current.cta_60400101101020 != null)
                    current.Total60400101101000 += (Decimal)current.cta_60400101101020;
                if (current.cta_60400101101030 != null)
                    current.Total60400101101000 += (Decimal)current.cta_60400101101030;
                if (current.cta_60400101101040 != null)
                    current.Total60400101101000 += (Decimal)current.cta_60400101101040;
                if (current.cta_60400101101990 != null)
                    current.Total60400101101000 += (Decimal)current.cta_60400101101990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101100000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101100000.cta_60400101102000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101100000.cta_60400101102000;
                current.Total60400101102000 = 0;
                if (current.cta_60400101102010 != null)
                    current.Total60400101102000 += (Decimal)current.cta_60400101102010;
                if (current.cta_60400101102020 != null)
                    current.Total60400101102000 += (Decimal)current.cta_60400101102020;
                if (current.cta_60400101102030 != null)
                    current.Total60400101102000 += (Decimal)current.cta_60400101102030;
                if (current.cta_60400101102040 != null)
                    current.Total60400101102000 += (Decimal)current.cta_60400101102040;
                if (current.cta_60400101102990 != null)
                    current.Total60400101102000 += (Decimal)current.cta_60400101102990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101100000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101100000;
                current.Total60400101100000 = 0;
                if (current.cta_60400101101000 != null && current.cta_60400101101000.Total60400101101000 != 0)
                    current.Total60400101100000 += (Decimal)current.cta_60400101101000.Total60400101101000;
                if (current.cta_60400101102000 != null && current.cta_60400101102000.Total60400101102000 != 0)
                    current.Total60400101100000 += (Decimal)current.cta_60400101102000.Total60400101102000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101200000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101200000.cta_60400101201000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101200000.cta_60400101201000;
                current.Total60400101201000 = 0;
                if (current.cta_60400101201010 != null)
                    current.Total60400101201000 += (Decimal)current.cta_60400101201010;
                if (current.cta_60400101201020 != null)
                    current.Total60400101201000 += (Decimal)current.cta_60400101201020;
                if (current.cta_60400101201030 != null)
                    current.Total60400101201000 += (Decimal)current.cta_60400101201030;
                if (current.cta_60400101201040 != null)
                    current.Total60400101201000 += (Decimal)current.cta_60400101201040;
                if (current.cta_60400101201990 != null)
                    current.Total60400101201000 += (Decimal)current.cta_60400101201990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101200000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101200000.cta_60400101202000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101200000.cta_60400101202000;
                current.Total60400101202000 = 0;
                if (current.cta_60400101202010 != null)
                    current.Total60400101202000 += (Decimal)current.cta_60400101202010;
                if (current.cta_60400101202020 != null)
                    current.Total60400101202000 += (Decimal)current.cta_60400101202020;
                if (current.cta_60400101202030 != null)
                    current.Total60400101202000 += (Decimal)current.cta_60400101202030;
                if (current.cta_60400101202040 != null)
                    current.Total60400101202000 += (Decimal)current.cta_60400101202040;
                if (current.cta_60400101202990 != null)
                    current.Total60400101202000 += (Decimal)current.cta_60400101202990;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101200000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400101200000;
                current.Total60400101200000 = 0;
                if (current.cta_60400101201000 != null && current.cta_60400101201000.Total60400101201000 != 0)
                    current.Total60400101200000 += (Decimal)current.cta_60400101201000.Total60400101201000;
                if (current.cta_60400101202000 != null && current.cta_60400101202000.Total60400101202000 != 0)
                    current.Total60400101200000 += (Decimal)current.cta_60400101202000.Total60400101202000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400109900000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000.cta_60400109900000;
                current.Total60400109900000 = 0;
                if (current.cta_60400109901000 != null)
                    current.Total60400109900000 += (Decimal)current.cta_60400109901000;
                if (current.cta_60400109902000 != null)
                    current.Total60400109900000 += (Decimal)current.cta_60400109902000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null && modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000.cta_60400100000000;
                current.Total60400100000000 = 0;
                if (current.cta_60400100100000 != null && current.cta_60400100100000.Total60400100100000 != 0)
                    current.Total60400100000000 += (Decimal)current.cta_60400100100000.Total60400100100000;
                if (current.cta_60400100200000 != null && current.cta_60400100200000.Total60400100200000 != 0)
                    current.Total60400100000000 += (Decimal)current.cta_60400100200000.Total60400100200000;
                if (current.cta_60400100300000 != null && current.cta_60400100300000.Total60400100300000 != 0)
                    current.Total60400100000000 += (Decimal)current.cta_60400100300000.Total60400100300000;
                if (current.cta_60400100400000 != null && current.cta_60400100400000.Total60400100400000 != 0)
                    current.Total60400100000000 += (Decimal)current.cta_60400100400000.Total60400100400000;
                if (current.cta_60400100500000 != null && current.cta_60400100500000.Total60400100500000 != 0)
                    current.Total60400100000000 += (Decimal)current.cta_60400100500000.Total60400100500000;
                if (current.cta_60400100600000 != null && current.cta_60400100600000.Total60400100600000 != 0)
                    current.Total60400100000000 += (Decimal)current.cta_60400100600000.Total60400100600000;
                if (current.cta_60400100700000 != null && current.cta_60400100700000.Total60400100700000 != 0)
                    current.Total60400100000000 += (Decimal)current.cta_60400100700000.Total60400100700000;
                if (current.cta_60400100800000 != null && current.cta_60400100800000.Total60400100800000 != 0)
                    current.Total60400100000000 += (Decimal)current.cta_60400100800000.Total60400100800000;
                if (current.cta_60400100900000 != null && current.cta_60400100900000.Total60400100900000 != 0)
                    current.Total60400100000000 += (Decimal)current.cta_60400100900000.Total60400100900000;
                if (current.cta_60400101000000 != null && current.cta_60400101000000.Total60400101000000 != 0)
                    current.Total60400100000000 += (Decimal)current.cta_60400101000000.Total60400101000000;
                if (current.cta_60400101100000 != null && current.cta_60400101100000.Total60400101100000 != 0)
                    current.Total60400100000000 += (Decimal)current.cta_60400101100000.Total60400101100000;
                if (current.cta_60400101200000 != null && current.cta_60400101200000.Total60400101200000 != 0)
                    current.Total60400100000000 += (Decimal)current.cta_60400101200000.Total60400101200000;
                if (current.cta_60400109900000 != null && current.cta_60400109900000.Total60400109900000 != 0)
                    current.Total60400100000000 += (Decimal)current.cta_60400109900000.Total60400109900000;
            }
            if (modelo.cta_60000000000000 != null && modelo.cta_60000000000000.cta_60400000000000 != null)
            {
                var current = modelo.cta_60000000000000.cta_60400000000000;
                current.Total60400000000000 = 0;
                if (current.cta_60400100000000 != null && current.cta_60400100000000.Total60400100000000 != 0)
                    current.Total60400000000000 += (Decimal)current.cta_60400100000000.Total60400100000000;
            }
            if (modelo.cta_60000000000000 != null)
            {
                var current = modelo.cta_60000000000000;
                current.Total60000000000000 = 0;
                if (current.cta_60100000000000 != null && current.cta_60100000000000.Total60100000000000 != 0)
                    current.Total60000000000000 += (Decimal)current.cta_60100000000000.Total60100000000000;
                if (current.cta_60200000000000 != null && current.cta_60200000000000.Total60200000000000 != 0)
                    current.Total60000000000000 += (Decimal)current.cta_60200000000000.Total60200000000000;
                if (current.cta_60300000000000 != null && current.cta_60300000000000.Total60300000000000 != 0)
                    current.Total60000000000000 += (Decimal)current.cta_60300000000000.Total60300000000000;
                if (current.cta_60400000000000 != null && current.cta_60400000000000.Total60400000000000 != 0)
                    current.Total60000000000000 += (Decimal)current.cta_60400000000000.Total60400000000000;
            }
        }

    }
}
