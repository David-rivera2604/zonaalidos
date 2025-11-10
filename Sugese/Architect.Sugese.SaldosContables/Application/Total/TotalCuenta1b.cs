using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.Sugese.SaldosContables.Domain.Application.Total
{
    internal class TotalCuenta1b
    {
        public static void Mapper(string account, Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModelo modelo, System.Nullable<decimal> value, bool specified)
        {

            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300600000.cta_10200300601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300600000.cta_10200300601000;
                current.Total10200300601000 = 0;
                if (current.cta_10200300601010 != null)
                    current.Total10200300601000 += (Decimal)current.cta_10200300601010;
                if (current.cta_10200300601020 != null)
                    current.Total10200300601000 += (Decimal)current.cta_10200300601020;
                if (current.cta_10200300601030 != null)
                    current.Total10200300601000 += (Decimal)current.cta_10200300601030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300600000.cta_10200300602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300600000.cta_10200300602000;
                current.Total10200300602000 = 0;
                if (current.cta_10200300602010 != null)
                    current.Total10200300602000 += (Decimal)current.cta_10200300602010;
                if (current.cta_10200300602020 != null)
                    current.Total10200300602000 += (Decimal)current.cta_10200300602020;
                if (current.cta_10200300602030 != null)
                    current.Total10200300602000 += (Decimal)current.cta_10200300602030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300600000.cta_10200300603000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300600000.cta_10200300603000;
                current.Total10200300603000 = 0;
                if (current.cta_10200300603010 != null)
                    current.Total10200300603000 += (Decimal)current.cta_10200300603010;
                if (current.cta_10200300603020 != null)
                    current.Total10200300603000 += (Decimal)current.cta_10200300603020;
                if (current.cta_10200300603030 != null)
                    current.Total10200300603000 += (Decimal)current.cta_10200300603030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300600000;
                current.Total10200300600000 = 0;
                if (current.cta_10200300601000 != null && current.cta_10200300601000.Total10200300601000 != 0)
                    current.Total10200300600000 += (Decimal)current.cta_10200300601000.Total10200300601000;
                if (current.cta_10200300602000 != null && current.cta_10200300602000.Total10200300602000 != 0)
                    current.Total10200300600000 += (Decimal)current.cta_10200300602000.Total10200300602000;
                if (current.cta_10200300603000 != null && current.cta_10200300603000.Total10200300603000 != 0)
                    current.Total10200300600000 += (Decimal)current.cta_10200300603000.Total10200300603000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300700000.cta_10200300701000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300700000.cta_10200300701000;
                current.Total10200300701000 = 0;
                if (current.cta_10200300701010 != null)
                    current.Total10200300701000 += (Decimal)current.cta_10200300701010;
                if (current.cta_10200300701020 != null)
                    current.Total10200300701000 += (Decimal)current.cta_10200300701020;
                if (current.cta_10200300701030 != null)
                    current.Total10200300701000 += (Decimal)current.cta_10200300701030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300700000.cta_10200300702000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300700000.cta_10200300702000;
                current.Total10200300702000 = 0;
                if (current.cta_10200300702010 != null)
                    current.Total10200300702000 += (Decimal)current.cta_10200300702010;
                if (current.cta_10200300702020 != null)
                    current.Total10200300702000 += (Decimal)current.cta_10200300702020;
                if (current.cta_10200300702030 != null)
                    current.Total10200300702000 += (Decimal)current.cta_10200300702030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300700000.cta_10200300703000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300700000.cta_10200300703000;
                current.Total10200300703000 = 0;
                if (current.cta_10200300703010 != null)
                    current.Total10200300703000 += (Decimal)current.cta_10200300703010;
                if (current.cta_10200300703020 != null)
                    current.Total10200300703000 += (Decimal)current.cta_10200300703020;
                if (current.cta_10200300703030 != null)
                    current.Total10200300703000 += (Decimal)current.cta_10200300703030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300700000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300700000;
                current.Total10200300700000 = 0;
                if (current.cta_10200300701000 != null && current.cta_10200300701000.Total10200300701000 != 0)
                    current.Total10200300700000 += (Decimal)current.cta_10200300701000.Total10200300701000;
                if (current.cta_10200300702000 != null && current.cta_10200300702000.Total10200300702000 != 0)
                    current.Total10200300700000 += (Decimal)current.cta_10200300702000.Total10200300702000;
                if (current.cta_10200300703000 != null && current.cta_10200300703000.Total10200300703000 != 0)
                    current.Total10200300700000 += (Decimal)current.cta_10200300703000.Total10200300703000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300800000.cta_10200300801000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300800000.cta_10200300801000;
                current.Total10200300801000 = 0;
                if (current.cta_10200300801010 != null)
                    current.Total10200300801000 += (Decimal)current.cta_10200300801010;
                if (current.cta_10200300801020 != null)
                    current.Total10200300801000 += (Decimal)current.cta_10200300801020;
                if (current.cta_10200300801030 != null)
                    current.Total10200300801000 += (Decimal)current.cta_10200300801030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300800000.cta_10200300802000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300800000.cta_10200300802000;
                current.Total10200300802000 = 0;
                if (current.cta_10200300802010 != null)
                    current.Total10200300802000 += (Decimal)current.cta_10200300802010;
                if (current.cta_10200300802020 != null)
                    current.Total10200300802000 += (Decimal)current.cta_10200300802020;
                if (current.cta_10200300802030 != null)
                    current.Total10200300802000 += (Decimal)current.cta_10200300802030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300800000.cta_10200300803000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300800000.cta_10200300803000;
                current.Total10200300803000 = 0;
                if (current.cta_10200300803010 != null)
                    current.Total10200300803000 += (Decimal)current.cta_10200300803010;
                if (current.cta_10200300803020 != null)
                    current.Total10200300803000 += (Decimal)current.cta_10200300803020;
                if (current.cta_10200300803030 != null)
                    current.Total10200300803000 += (Decimal)current.cta_10200300803030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300800000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300800000;
                current.Total10200300800000 = 0;
                if (current.cta_10200300801000 != null && current.cta_10200300801000.Total10200300801000 != 0)
                    current.Total10200300800000 += (Decimal)current.cta_10200300801000.Total10200300801000;
                if (current.cta_10200300802000 != null && current.cta_10200300802000.Total10200300802000 != 0)
                    current.Total10200300800000 += (Decimal)current.cta_10200300802000.Total10200300802000;
                if (current.cta_10200300803000 != null && current.cta_10200300803000.Total10200300803000 != 0)
                    current.Total10200300800000 += (Decimal)current.cta_10200300803000.Total10200300803000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300900000.cta_10200300901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300900000.cta_10200300901000;
                current.Total10200300901000 = 0;
                if (current.cta_10200300901010 != null)
                    current.Total10200300901000 += (Decimal)current.cta_10200300901010;
                if (current.cta_10200300901020 != null)
                    current.Total10200300901000 += (Decimal)current.cta_10200300901020;
                if (current.cta_10200300901030 != null)
                    current.Total10200300901000 += (Decimal)current.cta_10200300901030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300900000.cta_10200300902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300900000.cta_10200300902000;
                current.Total10200300902000 = 0;
                if (current.cta_10200300902010 != null)
                    current.Total10200300902000 += (Decimal)current.cta_10200300902010;
                if (current.cta_10200300902020 != null)
                    current.Total10200300902000 += (Decimal)current.cta_10200300902020;
                if (current.cta_10200300902030 != null)
                    current.Total10200300902000 += (Decimal)current.cta_10200300902030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300900000.cta_10200300903000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300900000.cta_10200300903000;
                current.Total10200300903000 = 0;
                if (current.cta_10200300903010 != null)
                    current.Total10200300903000 += (Decimal)current.cta_10200300903010;
                if (current.cta_10200300903020 != null)
                    current.Total10200300903000 += (Decimal)current.cta_10200300903020;
                if (current.cta_10200300903030 != null)
                    current.Total10200300903000 += (Decimal)current.cta_10200300903030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200300900000;
                current.Total10200300900000 = 0;
                if (current.cta_10200300901000 != null && current.cta_10200300901000.Total10200300901000 != 0)
                    current.Total10200300900000 += (Decimal)current.cta_10200300901000.Total10200300901000;
                if (current.cta_10200300902000 != null && current.cta_10200300902000.Total10200300902000 != 0)
                    current.Total10200300900000 += (Decimal)current.cta_10200300902000.Total10200300902000;
                if (current.cta_10200300903000 != null && current.cta_10200300903000.Total10200300903000 != 0)
                    current.Total10200300900000 += (Decimal)current.cta_10200300903000.Total10200300903000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301000000.cta_10200301001000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301000000.cta_10200301001000;
                current.Total10200301001000 = 0;
                if (current.cta_10200301001010 != null)
                    current.Total10200301001000 += (Decimal)current.cta_10200301001010;
                if (current.cta_10200301001020 != null)
                    current.Total10200301001000 += (Decimal)current.cta_10200301001020;
                if (current.cta_10200301001030 != null)
                    current.Total10200301001000 += (Decimal)current.cta_10200301001030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301000000.cta_10200301002000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301000000.cta_10200301002000;
                current.Total10200301002000 = 0;
                if (current.cta_10200301002010 != null)
                    current.Total10200301002000 += (Decimal)current.cta_10200301002010;
                if (current.cta_10200301002020 != null)
                    current.Total10200301002000 += (Decimal)current.cta_10200301002020;
                if (current.cta_10200301002030 != null)
                    current.Total10200301002000 += (Decimal)current.cta_10200301002030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301000000.cta_10200301003000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301000000.cta_10200301003000;
                current.Total10200301003000 = 0;
                if (current.cta_10200301003010 != null)
                    current.Total10200301003000 += (Decimal)current.cta_10200301003010;
                if (current.cta_10200301003020 != null)
                    current.Total10200301003000 += (Decimal)current.cta_10200301003020;
                if (current.cta_10200301003030 != null)
                    current.Total10200301003000 += (Decimal)current.cta_10200301003030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301000000;
                current.Total10200301000000 = 0;
                if (current.cta_10200301001000 != null && current.cta_10200301001000.Total10200301001000 != 0)
                    current.Total10200301000000 += (Decimal)current.cta_10200301001000.Total10200301001000;
                if (current.cta_10200301002000 != null && current.cta_10200301002000.Total10200301002000 != 0)
                    current.Total10200301000000 += (Decimal)current.cta_10200301002000.Total10200301002000;
                if (current.cta_10200301003000 != null && current.cta_10200301003000.Total10200301003000 != 0)
                    current.Total10200301000000 += (Decimal)current.cta_10200301003000.Total10200301003000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301100000.cta_10200301101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301100000.cta_10200301101000;
                current.Total10200301101000 = 0;
                if (current.cta_10200301101010 != null)
                    current.Total10200301101000 += (Decimal)current.cta_10200301101010;
                if (current.cta_10200301101020 != null)
                    current.Total10200301101000 += (Decimal)current.cta_10200301101020;
                if (current.cta_10200301101030 != null)
                    current.Total10200301101000 += (Decimal)current.cta_10200301101030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301100000.cta_10200301102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301100000.cta_10200301102000;
                current.Total10200301102000 = 0;
                if (current.cta_10200301102010 != null)
                    current.Total10200301102000 += (Decimal)current.cta_10200301102010;
                if (current.cta_10200301102020 != null)
                    current.Total10200301102000 += (Decimal)current.cta_10200301102020;
                if (current.cta_10200301102030 != null)
                    current.Total10200301102000 += (Decimal)current.cta_10200301102030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301100000.cta_10200301103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301100000.cta_10200301103000;
                current.Total10200301103000 = 0;
                if (current.cta_10200301103010 != null)
                    current.Total10200301103000 += (Decimal)current.cta_10200301103010;
                if (current.cta_10200301103020 != null)
                    current.Total10200301103000 += (Decimal)current.cta_10200301103020;
                if (current.cta_10200301103030 != null)
                    current.Total10200301103000 += (Decimal)current.cta_10200301103030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000.cta_10200301100000;
                current.Total10200301100000 = 0;
                if (current.cta_10200301101000 != null && current.cta_10200301101000.Total10200301101000 != 0)
                    current.Total10200301100000 += (Decimal)current.cta_10200301101000.Total10200301101000;
                if (current.cta_10200301102000 != null && current.cta_10200301102000.Total10200301102000 != 0)
                    current.Total10200301100000 += (Decimal)current.cta_10200301102000.Total10200301102000;
                if (current.cta_10200301103000 != null && current.cta_10200301103000.Total10200301103000 != 0)
                    current.Total10200301100000 += (Decimal)current.cta_10200301103000.Total10200301103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200300000000;
                current.Total10200300000000 = 0;
                if (current.cta_10200300100000 != null && current.cta_10200300100000.Total10200300100000 != 0)
                    current.Total10200300000000 += (Decimal)current.cta_10200300100000.Total10200300100000;
                if (current.cta_10200300200000 != null && current.cta_10200300200000.Total10200300200000 != 0)
                    current.Total10200300000000 += (Decimal)current.cta_10200300200000.Total10200300200000;
                if (current.cta_10200300300000 != null && current.cta_10200300300000.Total10200300300000 != 0)
                    current.Total10200300000000 += (Decimal)current.cta_10200300300000.Total10200300300000;
                if (current.cta_10200300400000 != null && current.cta_10200300400000.Total10200300400000 != 0)
                    current.Total10200300000000 += (Decimal)current.cta_10200300400000.Total10200300400000;
                if (current.cta_10200300500000 != null && current.cta_10200300500000.Total10200300500000 != 0)
                    current.Total10200300000000 += (Decimal)current.cta_10200300500000.Total10200300500000;
                if (current.cta_10200300600000 != null && current.cta_10200300600000.Total10200300600000 != 0)
                    current.Total10200300000000 += (Decimal)current.cta_10200300600000.Total10200300600000;
                if (current.cta_10200300700000 != null && current.cta_10200300700000.Total10200300700000 != 0)
                    current.Total10200300000000 += (Decimal)current.cta_10200300700000.Total10200300700000;
                if (current.cta_10200300800000 != null && current.cta_10200300800000.Total10200300800000 != 0)
                    current.Total10200300000000 += (Decimal)current.cta_10200300800000.Total10200300800000;
                if (current.cta_10200300900000 != null && current.cta_10200300900000.Total10200300900000 != 0)
                    current.Total10200300000000 += (Decimal)current.cta_10200300900000.Total10200300900000;
                if (current.cta_10200301000000 != null && current.cta_10200301000000.Total10200301000000 != 0)
                    current.Total10200300000000 += (Decimal)current.cta_10200301000000.Total10200301000000;
                if (current.cta_10200301100000 != null && current.cta_10200301100000.Total10200301100000 != 0)
                    current.Total10200300000000 += (Decimal)current.cta_10200301100000.Total10200301100000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400100000.cta_10200400101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400100000.cta_10200400101000;
                current.Total10200400101000 = 0;
                if (current.cta_10200400101020 != null)
                    current.Total10200400101000 += (Decimal)current.cta_10200400101020;
                if (current.cta_10200400101030 != null)
                    current.Total10200400101000 += (Decimal)current.cta_10200400101030;
                if (current.cta_10200400101040 != null)
                    current.Total10200400101000 += (Decimal)current.cta_10200400101040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400100000.cta_10200400102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400100000.cta_10200400102000;
                current.Total10200400102000 = 0;
                if (current.cta_10200400102020 != null)
                    current.Total10200400102000 += (Decimal)current.cta_10200400102020;
                if (current.cta_10200400102030 != null)
                    current.Total10200400102000 += (Decimal)current.cta_10200400102030;
                if (current.cta_10200400102040 != null)
                    current.Total10200400102000 += (Decimal)current.cta_10200400102040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400100000.cta_10200400103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400100000.cta_10200400103000;
                current.Total10200400103000 = 0;
                if (current.cta_10200400103020 != null)
                    current.Total10200400103000 += (Decimal)current.cta_10200400103020;
                if (current.cta_10200400103030 != null)
                    current.Total10200400103000 += (Decimal)current.cta_10200400103030;
                if (current.cta_10200400103040 != null)
                    current.Total10200400103000 += (Decimal)current.cta_10200400103040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400100000;
                current.Total10200400100000 = 0;
                if (current.cta_10200400101000 != null && current.cta_10200400101000.Total10200400101000 != 0)
                    current.Total10200400100000 += (Decimal)current.cta_10200400101000.Total10200400101000;
                if (current.cta_10200400102000 != null && current.cta_10200400102000.Total10200400102000 != 0)
                    current.Total10200400100000 += (Decimal)current.cta_10200400102000.Total10200400102000;
                if (current.cta_10200400103000 != null && current.cta_10200400103000.Total10200400103000 != 0)
                    current.Total10200400100000 += (Decimal)current.cta_10200400103000.Total10200400103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400200000.cta_10200400201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400200000.cta_10200400201000;
                current.Total10200400201000 = 0;
                if (current.cta_10200400201020 != null)
                    current.Total10200400201000 += (Decimal)current.cta_10200400201020;
                if (current.cta_10200400201030 != null)
                    current.Total10200400201000 += (Decimal)current.cta_10200400201030;
                if (current.cta_10200400201040 != null)
                    current.Total10200400201000 += (Decimal)current.cta_10200400201040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400200000.cta_10200400202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400200000.cta_10200400202000;
                current.Total10200400202000 = 0;
                if (current.cta_10200400202020 != null)
                    current.Total10200400202000 += (Decimal)current.cta_10200400202020;
                if (current.cta_10200400202030 != null)
                    current.Total10200400202000 += (Decimal)current.cta_10200400202030;
                if (current.cta_10200400202040 != null)
                    current.Total10200400202000 += (Decimal)current.cta_10200400202040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400200000.cta_10200400203000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400200000.cta_10200400203000;
                current.Total10200400203000 = 0;
                if (current.cta_10200400203020 != null)
                    current.Total10200400203000 += (Decimal)current.cta_10200400203020;
                if (current.cta_10200400203030 != null)
                    current.Total10200400203000 += (Decimal)current.cta_10200400203030;
                if (current.cta_10200400203040 != null)
                    current.Total10200400203000 += (Decimal)current.cta_10200400203040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000.cta_10200400200000;
                current.Total10200400200000 = 0;
                if (current.cta_10200400201000 != null && current.cta_10200400201000.Total10200400201000 != 0)
                    current.Total10200400200000 += (Decimal)current.cta_10200400201000.Total10200400201000;
                if (current.cta_10200400202000 != null && current.cta_10200400202000.Total10200400202000 != 0)
                    current.Total10200400200000 += (Decimal)current.cta_10200400202000.Total10200400202000;
                if (current.cta_10200400203000 != null && current.cta_10200400203000.Total10200400203000 != 0)
                    current.Total10200400200000 += (Decimal)current.cta_10200400203000.Total10200400203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200400000000;
                current.Total10200400000000 = 0;
                if (current.cta_10200400100000 != null && current.cta_10200400100000.Total10200400100000 != 0)
                    current.Total10200400000000 += (Decimal)current.cta_10200400100000.Total10200400100000;
                if (current.cta_10200400200000 != null && current.cta_10200400200000.Total10200400200000 != 0)
                    current.Total10200400000000 += (Decimal)current.cta_10200400200000.Total10200400200000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200500100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200500100000;
                current.Total10200500100000 = 0;
                if (current.cta_10200500101000 != null)
                    current.Total10200500100000 += (Decimal)current.cta_10200500101000;
                if (current.cta_10200500102000 != null)
                    current.Total10200500100000 += (Decimal)current.cta_10200500102000;
                if (current.cta_10200500103000 != null)
                    current.Total10200500100000 += (Decimal)current.cta_10200500103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200500200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200500200000;
                current.Total10200500200000 = 0;
                if (current.cta_10200500201000 != null)
                    current.Total10200500200000 += (Decimal)current.cta_10200500201000;
                if (current.cta_10200500202000 != null)
                    current.Total10200500200000 += (Decimal)current.cta_10200500202000;
                if (current.cta_10200500203000 != null)
                    current.Total10200500200000 += (Decimal)current.cta_10200500203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200500300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200500300000;
                current.Total10200500300000 = 0;
                if (current.cta_10200500301000 != null)
                    current.Total10200500300000 += (Decimal)current.cta_10200500301000;
                if (current.cta_10200500302000 != null)
                    current.Total10200500300000 += (Decimal)current.cta_10200500302000;
                if (current.cta_10200500303000 != null)
                    current.Total10200500300000 += (Decimal)current.cta_10200500303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200500400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200500400000;
                current.Total10200500400000 = 0;
                if (current.cta_10200500401000 != null)
                    current.Total10200500400000 += (Decimal)current.cta_10200500401000;
                if (current.cta_10200500402000 != null)
                    current.Total10200500400000 += (Decimal)current.cta_10200500402000;
                if (current.cta_10200500403000 != null)
                    current.Total10200500400000 += (Decimal)current.cta_10200500403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200501900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200501900000.cta_10200501901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200501900000.cta_10200501901000;
                current.Total10200501901000 = 0;
                if (current.cta_10200501901010 != null)
                    current.Total10200501901000 += (Decimal)current.cta_10200501901010;
                if (current.cta_10200501901020 != null)
                    current.Total10200501901000 += (Decimal)current.cta_10200501901020;
                if (current.cta_10200501901030 != null)
                    current.Total10200501901000 += (Decimal)current.cta_10200501901030;
                if (current.cta_10200501901040 != null)
                    current.Total10200501901000 += (Decimal)current.cta_10200501901040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200501900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200501900000.cta_10200501902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200501900000.cta_10200501902000;
                current.Total10200501902000 = 0;
                if (current.cta_10200501902010 != null)
                    current.Total10200501902000 += (Decimal)current.cta_10200501902010;
                if (current.cta_10200501902020 != null)
                    current.Total10200501902000 += (Decimal)current.cta_10200501902020;
                if (current.cta_10200501902030 != null)
                    current.Total10200501902000 += (Decimal)current.cta_10200501902030;
                if (current.cta_10200501902040 != null)
                    current.Total10200501902000 += (Decimal)current.cta_10200501902040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200501900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200501900000.cta_10200501903000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200501900000.cta_10200501903000;
                current.Total10200501903000 = 0;
                if (current.cta_10200501903010 != null)
                    current.Total10200501903000 += (Decimal)current.cta_10200501903010;
                if (current.cta_10200501903020 != null)
                    current.Total10200501903000 += (Decimal)current.cta_10200501903020;
                if (current.cta_10200501903030 != null)
                    current.Total10200501903000 += (Decimal)current.cta_10200501903030;
                if (current.cta_10200501903040 != null)
                    current.Total10200501903000 += (Decimal)current.cta_10200501903040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200501900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200501900000;
                current.Total10200501900000 = 0;
                if (current.cta_10200501901000 != null && current.cta_10200501901000.Total10200501901000 != 0)
                    current.Total10200501900000 += (Decimal)current.cta_10200501901000.Total10200501901000;
                if (current.cta_10200501902000 != null && current.cta_10200501902000.Total10200501902000 != 0)
                    current.Total10200501900000 += (Decimal)current.cta_10200501902000.Total10200501902000;
                if (current.cta_10200501903000 != null && current.cta_10200501903000.Total10200501903000 != 0)
                    current.Total10200501900000 += (Decimal)current.cta_10200501903000.Total10200501903000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502000000.cta_10200502001000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502000000.cta_10200502001000;
                current.Total10200502001000 = 0;
                if (current.cta_10200502001010 != null)
                    current.Total10200502001000 += (Decimal)current.cta_10200502001010;
                if (current.cta_10200502001020 != null)
                    current.Total10200502001000 += (Decimal)current.cta_10200502001020;
                if (current.cta_10200502001030 != null)
                    current.Total10200502001000 += (Decimal)current.cta_10200502001030;
                if (current.cta_10200502001040 != null)
                    current.Total10200502001000 += (Decimal)current.cta_10200502001040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502000000.cta_10200502002000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502000000.cta_10200502002000;
                current.Total10200502002000 = 0;
                if (current.cta_10200502002010 != null)
                    current.Total10200502002000 += (Decimal)current.cta_10200502002010;
                if (current.cta_10200502002020 != null)
                    current.Total10200502002000 += (Decimal)current.cta_10200502002020;
                if (current.cta_10200502002030 != null)
                    current.Total10200502002000 += (Decimal)current.cta_10200502002030;
                if (current.cta_10200502002040 != null)
                    current.Total10200502002000 += (Decimal)current.cta_10200502002040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502000000.cta_10200502003000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502000000.cta_10200502003000;
                current.Total10200502003000 = 0;
                if (current.cta_10200502003010 != null)
                    current.Total10200502003000 += (Decimal)current.cta_10200502003010;
                if (current.cta_10200502003020 != null)
                    current.Total10200502003000 += (Decimal)current.cta_10200502003020;
                if (current.cta_10200502003030 != null)
                    current.Total10200502003000 += (Decimal)current.cta_10200502003030;
                if (current.cta_10200502003040 != null)
                    current.Total10200502003000 += (Decimal)current.cta_10200502003040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502000000;
                current.Total10200502000000 = 0;
                if (current.cta_10200502001000 != null && current.cta_10200502001000.Total10200502001000 != 0)
                    current.Total10200502000000 += (Decimal)current.cta_10200502001000.Total10200502001000;
                if (current.cta_10200502002000 != null && current.cta_10200502002000.Total10200502002000 != 0)
                    current.Total10200502000000 += (Decimal)current.cta_10200502002000.Total10200502002000;
                if (current.cta_10200502003000 != null && current.cta_10200502003000.Total10200502003000 != 0)
                    current.Total10200502000000 += (Decimal)current.cta_10200502003000.Total10200502003000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502100000.cta_10200502101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502100000.cta_10200502101000;
                current.Total10200502101000 = 0;
                if (current.cta_10200502101010 != null)
                    current.Total10200502101000 += (Decimal)current.cta_10200502101010;
                if (current.cta_10200502101020 != null)
                    current.Total10200502101000 += (Decimal)current.cta_10200502101020;
                if (current.cta_10200502101030 != null)
                    current.Total10200502101000 += (Decimal)current.cta_10200502101030;
                if (current.cta_10200502101040 != null)
                    current.Total10200502101000 += (Decimal)current.cta_10200502101040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502100000.cta_10200502102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502100000.cta_10200502102000;
                current.Total10200502102000 = 0;
                if (current.cta_10200502102010 != null)
                    current.Total10200502102000 += (Decimal)current.cta_10200502102010;
                if (current.cta_10200502102020 != null)
                    current.Total10200502102000 += (Decimal)current.cta_10200502102020;
                if (current.cta_10200502102030 != null)
                    current.Total10200502102000 += (Decimal)current.cta_10200502102030;
                if (current.cta_10200502102040 != null)
                    current.Total10200502102000 += (Decimal)current.cta_10200502102040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502100000.cta_10200502103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502100000.cta_10200502103000;
                current.Total10200502103000 = 0;
                if (current.cta_10200502103010 != null)
                    current.Total10200502103000 += (Decimal)current.cta_10200502103010;
                if (current.cta_10200502103020 != null)
                    current.Total10200502103000 += (Decimal)current.cta_10200502103020;
                if (current.cta_10200502103030 != null)
                    current.Total10200502103000 += (Decimal)current.cta_10200502103030;
                if (current.cta_10200502103040 != null)
                    current.Total10200502103000 += (Decimal)current.cta_10200502103040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502100000;
                current.Total10200502100000 = 0;
                if (current.cta_10200502101000 != null && current.cta_10200502101000.Total10200502101000 != 0)
                    current.Total10200502100000 += (Decimal)current.cta_10200502101000.Total10200502101000;
                if (current.cta_10200502102000 != null && current.cta_10200502102000.Total10200502102000 != 0)
                    current.Total10200502100000 += (Decimal)current.cta_10200502102000.Total10200502102000;
                if (current.cta_10200502103000 != null && current.cta_10200502103000.Total10200502103000 != 0)
                    current.Total10200502100000 += (Decimal)current.cta_10200502103000.Total10200502103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502200000.cta_10200502201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502200000.cta_10200502201000;
                current.Total10200502201000 = 0;
                if (current.cta_10200502201010 != null)
                    current.Total10200502201000 += (Decimal)current.cta_10200502201010;
                if (current.cta_10200502201020 != null)
                    current.Total10200502201000 += (Decimal)current.cta_10200502201020;
                if (current.cta_10200502201030 != null)
                    current.Total10200502201000 += (Decimal)current.cta_10200502201030;
                if (current.cta_10200502201040 != null)
                    current.Total10200502201000 += (Decimal)current.cta_10200502201040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502200000.cta_10200502202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502200000.cta_10200502202000;
                current.Total10200502202000 = 0;
                if (current.cta_10200502202010 != null)
                    current.Total10200502202000 += (Decimal)current.cta_10200502202010;
                if (current.cta_10200502202020 != null)
                    current.Total10200502202000 += (Decimal)current.cta_10200502202020;
                if (current.cta_10200502202030 != null)
                    current.Total10200502202000 += (Decimal)current.cta_10200502202030;
                if (current.cta_10200502202040 != null)
                    current.Total10200502202000 += (Decimal)current.cta_10200502202040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502200000.cta_10200502203000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502200000.cta_10200502203000;
                current.Total10200502203000 = 0;
                if (current.cta_10200502203010 != null)
                    current.Total10200502203000 += (Decimal)current.cta_10200502203010;
                if (current.cta_10200502203020 != null)
                    current.Total10200502203000 += (Decimal)current.cta_10200502203020;
                if (current.cta_10200502203030 != null)
                    current.Total10200502203000 += (Decimal)current.cta_10200502203030;
                if (current.cta_10200502203040 != null)
                    current.Total10200502203000 += (Decimal)current.cta_10200502203040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502200000;
                current.Total10200502200000 = 0;
                if (current.cta_10200502201000 != null && current.cta_10200502201000.Total10200502201000 != 0)
                    current.Total10200502200000 += (Decimal)current.cta_10200502201000.Total10200502201000;
                if (current.cta_10200502202000 != null && current.cta_10200502202000.Total10200502202000 != 0)
                    current.Total10200502200000 += (Decimal)current.cta_10200502202000.Total10200502202000;
                if (current.cta_10200502203000 != null && current.cta_10200502203000.Total10200502203000 != 0)
                    current.Total10200502200000 += (Decimal)current.cta_10200502203000.Total10200502203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502300000.cta_10200502301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502300000.cta_10200502301000;
                current.Total10200502301000 = 0;
                if (current.cta_10200502301010 != null)
                    current.Total10200502301000 += (Decimal)current.cta_10200502301010;
                if (current.cta_10200502301020 != null)
                    current.Total10200502301000 += (Decimal)current.cta_10200502301020;
                if (current.cta_10200502301030 != null)
                    current.Total10200502301000 += (Decimal)current.cta_10200502301030;
                if (current.cta_10200502301040 != null)
                    current.Total10200502301000 += (Decimal)current.cta_10200502301040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502300000.cta_10200502302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502300000.cta_10200502302000;
                current.Total10200502302000 = 0;
                if (current.cta_10200502302010 != null)
                    current.Total10200502302000 += (Decimal)current.cta_10200502302010;
                if (current.cta_10200502302020 != null)
                    current.Total10200502302000 += (Decimal)current.cta_10200502302020;
                if (current.cta_10200502302030 != null)
                    current.Total10200502302000 += (Decimal)current.cta_10200502302030;
                if (current.cta_10200502302040 != null)
                    current.Total10200502302000 += (Decimal)current.cta_10200502302040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502300000.cta_10200502303000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502300000.cta_10200502303000;
                current.Total10200502303000 = 0;
                if (current.cta_10200502303010 != null)
                    current.Total10200502303000 += (Decimal)current.cta_10200502303010;
                if (current.cta_10200502303020 != null)
                    current.Total10200502303000 += (Decimal)current.cta_10200502303020;
                if (current.cta_10200502303030 != null)
                    current.Total10200502303000 += (Decimal)current.cta_10200502303030;
                if (current.cta_10200502303040 != null)
                    current.Total10200502303000 += (Decimal)current.cta_10200502303040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502300000;
                current.Total10200502300000 = 0;
                if (current.cta_10200502301000 != null && current.cta_10200502301000.Total10200502301000 != 0)
                    current.Total10200502300000 += (Decimal)current.cta_10200502301000.Total10200502301000;
                if (current.cta_10200502302000 != null && current.cta_10200502302000.Total10200502302000 != 0)
                    current.Total10200502300000 += (Decimal)current.cta_10200502302000.Total10200502302000;
                if (current.cta_10200502303000 != null && current.cta_10200502303000.Total10200502303000 != 0)
                    current.Total10200502300000 += (Decimal)current.cta_10200502303000.Total10200502303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502400000.cta_10200502401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502400000.cta_10200502401000;
                current.Total10200502401000 = 0;
                if (current.cta_10200502401010 != null)
                    current.Total10200502401000 += (Decimal)current.cta_10200502401010;
                if (current.cta_10200502401020 != null)
                    current.Total10200502401000 += (Decimal)current.cta_10200502401020;
                if (current.cta_10200502401030 != null)
                    current.Total10200502401000 += (Decimal)current.cta_10200502401030;
                if (current.cta_10200502401040 != null)
                    current.Total10200502401000 += (Decimal)current.cta_10200502401040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502400000.cta_10200502402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502400000.cta_10200502402000;
                current.Total10200502402000 = 0;
                if (current.cta_10200502402010 != null)
                    current.Total10200502402000 += (Decimal)current.cta_10200502402010;
                if (current.cta_10200502402020 != null)
                    current.Total10200502402000 += (Decimal)current.cta_10200502402020;
                if (current.cta_10200502402030 != null)
                    current.Total10200502402000 += (Decimal)current.cta_10200502402030;
                if (current.cta_10200502402040 != null)
                    current.Total10200502402000 += (Decimal)current.cta_10200502402040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502400000.cta_10200502403000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502400000.cta_10200502403000;
                current.Total10200502403000 = 0;
                if (current.cta_10200502403010 != null)
                    current.Total10200502403000 += (Decimal)current.cta_10200502403010;
                if (current.cta_10200502403020 != null)
                    current.Total10200502403000 += (Decimal)current.cta_10200502403020;
                if (current.cta_10200502403030 != null)
                    current.Total10200502403000 += (Decimal)current.cta_10200502403030;
                if (current.cta_10200502403040 != null)
                    current.Total10200502403000 += (Decimal)current.cta_10200502403040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502400000;
                current.Total10200502400000 = 0;
                if (current.cta_10200502401000 != null && current.cta_10200502401000.Total10200502401000 != 0)
                    current.Total10200502400000 += (Decimal)current.cta_10200502401000.Total10200502401000;
                if (current.cta_10200502402000 != null && current.cta_10200502402000.Total10200502402000 != 0)
                    current.Total10200502400000 += (Decimal)current.cta_10200502402000.Total10200502402000;
                if (current.cta_10200502403000 != null && current.cta_10200502403000.Total10200502403000 != 0)
                    current.Total10200502400000 += (Decimal)current.cta_10200502403000.Total10200502403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502700000.cta_10200502701000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502700000.cta_10200502701000;
                current.Total10200502701000 = 0;
                if (current.cta_10200502701010 != null)
                    current.Total10200502701000 += (Decimal)current.cta_10200502701010;
                if (current.cta_10200502701020 != null)
                    current.Total10200502701000 += (Decimal)current.cta_10200502701020;
                if (current.cta_10200502701030 != null)
                    current.Total10200502701000 += (Decimal)current.cta_10200502701030;
                if (current.cta_10200502701040 != null)
                    current.Total10200502701000 += (Decimal)current.cta_10200502701040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502700000.cta_10200502702000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502700000.cta_10200502702000;
                current.Total10200502702000 = 0;
                if (current.cta_10200502702010 != null)
                    current.Total10200502702000 += (Decimal)current.cta_10200502702010;
                if (current.cta_10200502702020 != null)
                    current.Total10200502702000 += (Decimal)current.cta_10200502702020;
                if (current.cta_10200502702030 != null)
                    current.Total10200502702000 += (Decimal)current.cta_10200502702030;
                if (current.cta_10200502702040 != null)
                    current.Total10200502702000 += (Decimal)current.cta_10200502702040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502700000.cta_10200502703000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502700000.cta_10200502703000;
                current.Total10200502703000 = 0;
                if (current.cta_10200502703010 != null)
                    current.Total10200502703000 += (Decimal)current.cta_10200502703010;
                if (current.cta_10200502703020 != null)
                    current.Total10200502703000 += (Decimal)current.cta_10200502703020;
                if (current.cta_10200502703030 != null)
                    current.Total10200502703000 += (Decimal)current.cta_10200502703030;
                if (current.cta_10200502703040 != null)
                    current.Total10200502703000 += (Decimal)current.cta_10200502703040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502700000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502700000;
                current.Total10200502700000 = 0;
                if (current.cta_10200502701000 != null && current.cta_10200502701000.Total10200502701000 != 0)
                    current.Total10200502700000 += (Decimal)current.cta_10200502701000.Total10200502701000;
                if (current.cta_10200502702000 != null && current.cta_10200502702000.Total10200502702000 != 0)
                    current.Total10200502700000 += (Decimal)current.cta_10200502702000.Total10200502702000;
                if (current.cta_10200502703000 != null && current.cta_10200502703000.Total10200502703000 != 0)
                    current.Total10200502700000 += (Decimal)current.cta_10200502703000.Total10200502703000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502800000.cta_10200502801000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502800000.cta_10200502801000;
                current.Total10200502801000 = 0;
                if (current.cta_10200502801010 != null)
                    current.Total10200502801000 += (Decimal)current.cta_10200502801010;
                if (current.cta_10200502801020 != null)
                    current.Total10200502801000 += (Decimal)current.cta_10200502801020;
                if (current.cta_10200502801030 != null)
                    current.Total10200502801000 += (Decimal)current.cta_10200502801030;
                if (current.cta_10200502801040 != null)
                    current.Total10200502801000 += (Decimal)current.cta_10200502801040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502800000.cta_10200502802000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502800000.cta_10200502802000;
                current.Total10200502802000 = 0;
                if (current.cta_10200502802010 != null)
                    current.Total10200502802000 += (Decimal)current.cta_10200502802010;
                if (current.cta_10200502802020 != null)
                    current.Total10200502802000 += (Decimal)current.cta_10200502802020;
                if (current.cta_10200502802030 != null)
                    current.Total10200502802000 += (Decimal)current.cta_10200502802030;
                if (current.cta_10200502802040 != null)
                    current.Total10200502802000 += (Decimal)current.cta_10200502802040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502800000.cta_10200502803000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502800000.cta_10200502803000;
                current.Total10200502803000 = 0;
                if (current.cta_10200502803010 != null)
                    current.Total10200502803000 += (Decimal)current.cta_10200502803010;
                if (current.cta_10200502803020 != null)
                    current.Total10200502803000 += (Decimal)current.cta_10200502803020;
                if (current.cta_10200502803030 != null)
                    current.Total10200502803000 += (Decimal)current.cta_10200502803030;
                if (current.cta_10200502803040 != null)
                    current.Total10200502803000 += (Decimal)current.cta_10200502803040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502800000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502800000;
                current.Total10200502800000 = 0;
                if (current.cta_10200502801000 != null && current.cta_10200502801000.Total10200502801000 != 0)
                    current.Total10200502800000 += (Decimal)current.cta_10200502801000.Total10200502801000;
                if (current.cta_10200502802000 != null && current.cta_10200502802000.Total10200502802000 != 0)
                    current.Total10200502800000 += (Decimal)current.cta_10200502802000.Total10200502802000;
                if (current.cta_10200502803000 != null && current.cta_10200502803000.Total10200502803000 != 0)
                    current.Total10200502800000 += (Decimal)current.cta_10200502803000.Total10200502803000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502900000.cta_10200502901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502900000.cta_10200502901000;
                current.Total10200502901000 = 0;
                if (current.cta_10200502901010 != null)
                    current.Total10200502901000 += (Decimal)current.cta_10200502901010;
                if (current.cta_10200502901020 != null)
                    current.Total10200502901000 += (Decimal)current.cta_10200502901020;
                if (current.cta_10200502901030 != null)
                    current.Total10200502901000 += (Decimal)current.cta_10200502901030;
                if (current.cta_10200502901040 != null)
                    current.Total10200502901000 += (Decimal)current.cta_10200502901040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502900000.cta_10200502902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502900000.cta_10200502902000;
                current.Total10200502902000 = 0;
                if (current.cta_10200502902010 != null)
                    current.Total10200502902000 += (Decimal)current.cta_10200502902010;
                if (current.cta_10200502902020 != null)
                    current.Total10200502902000 += (Decimal)current.cta_10200502902020;
                if (current.cta_10200502902030 != null)
                    current.Total10200502902000 += (Decimal)current.cta_10200502902030;
                if (current.cta_10200502902040 != null)
                    current.Total10200502902000 += (Decimal)current.cta_10200502902040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502900000.cta_10200502903000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502900000.cta_10200502903000;
                current.Total10200502903000 = 0;
                if (current.cta_10200502903010 != null)
                    current.Total10200502903000 += (Decimal)current.cta_10200502903010;
                if (current.cta_10200502903020 != null)
                    current.Total10200502903000 += (Decimal)current.cta_10200502903020;
                if (current.cta_10200502903030 != null)
                    current.Total10200502903000 += (Decimal)current.cta_10200502903030;
                if (current.cta_10200502903040 != null)
                    current.Total10200502903000 += (Decimal)current.cta_10200502903040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200502900000;
                current.Total10200502900000 = 0;
                if (current.cta_10200502901000 != null && current.cta_10200502901000.Total10200502901000 != 0)
                    current.Total10200502900000 += (Decimal)current.cta_10200502901000.Total10200502901000;
                if (current.cta_10200502902000 != null && current.cta_10200502902000.Total10200502902000 != 0)
                    current.Total10200502900000 += (Decimal)current.cta_10200502902000.Total10200502902000;
                if (current.cta_10200502903000 != null && current.cta_10200502903000.Total10200502903000 != 0)
                    current.Total10200502900000 += (Decimal)current.cta_10200502903000.Total10200502903000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503000000.cta_10200503001000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503000000.cta_10200503001000;
                current.Total10200503001000 = 0;
                if (current.cta_10200503001010 != null)
                    current.Total10200503001000 += (Decimal)current.cta_10200503001010;
                if (current.cta_10200503001020 != null)
                    current.Total10200503001000 += (Decimal)current.cta_10200503001020;
                if (current.cta_10200503001030 != null)
                    current.Total10200503001000 += (Decimal)current.cta_10200503001030;
                if (current.cta_10200503001040 != null)
                    current.Total10200503001000 += (Decimal)current.cta_10200503001040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503000000.cta_10200503002000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503000000.cta_10200503002000;
                current.Total10200503002000 = 0;
                if (current.cta_10200503002010 != null)
                    current.Total10200503002000 += (Decimal)current.cta_10200503002010;
                if (current.cta_10200503002020 != null)
                    current.Total10200503002000 += (Decimal)current.cta_10200503002020;
                if (current.cta_10200503002030 != null)
                    current.Total10200503002000 += (Decimal)current.cta_10200503002030;
                if (current.cta_10200503002040 != null)
                    current.Total10200503002000 += (Decimal)current.cta_10200503002040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503000000.cta_10200503003000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503000000.cta_10200503003000;
                current.Total10200503003000 = 0;
                if (current.cta_10200503003010 != null)
                    current.Total10200503003000 += (Decimal)current.cta_10200503003010;
                if (current.cta_10200503003020 != null)
                    current.Total10200503003000 += (Decimal)current.cta_10200503003020;
                if (current.cta_10200503003030 != null)
                    current.Total10200503003000 += (Decimal)current.cta_10200503003030;
                if (current.cta_10200503003040 != null)
                    current.Total10200503003000 += (Decimal)current.cta_10200503003040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503000000;
                current.Total10200503000000 = 0;
                if (current.cta_10200503001000 != null && current.cta_10200503001000.Total10200503001000 != 0)
                    current.Total10200503000000 += (Decimal)current.cta_10200503001000.Total10200503001000;
                if (current.cta_10200503002000 != null && current.cta_10200503002000.Total10200503002000 != 0)
                    current.Total10200503000000 += (Decimal)current.cta_10200503002000.Total10200503002000;
                if (current.cta_10200503003000 != null && current.cta_10200503003000.Total10200503003000 != 0)
                    current.Total10200503000000 += (Decimal)current.cta_10200503003000.Total10200503003000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503200000.cta_10200503201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503200000.cta_10200503201000;
                current.Total10200503201000 = 0;
                if (current.cta_10200503201010 != null)
                    current.Total10200503201000 += (Decimal)current.cta_10200503201010;
                if (current.cta_10200503201020 != null)
                    current.Total10200503201000 += (Decimal)current.cta_10200503201020;
                if (current.cta_10200503201030 != null)
                    current.Total10200503201000 += (Decimal)current.cta_10200503201030;
                if (current.cta_10200503201040 != null)
                    current.Total10200503201000 += (Decimal)current.cta_10200503201040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503200000.cta_10200503202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503200000.cta_10200503202000;
                current.Total10200503202000 = 0;
                if (current.cta_10200503202010 != null)
                    current.Total10200503202000 += (Decimal)current.cta_10200503202010;
                if (current.cta_10200503202020 != null)
                    current.Total10200503202000 += (Decimal)current.cta_10200503202020;
                if (current.cta_10200503202030 != null)
                    current.Total10200503202000 += (Decimal)current.cta_10200503202030;
                if (current.cta_10200503202040 != null)
                    current.Total10200503202000 += (Decimal)current.cta_10200503202040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503200000.cta_10200503203000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503200000.cta_10200503203000;
                current.Total10200503203000 = 0;
                if (current.cta_10200503203010 != null)
                    current.Total10200503203000 += (Decimal)current.cta_10200503203010;
                if (current.cta_10200503203020 != null)
                    current.Total10200503203000 += (Decimal)current.cta_10200503203020;
                if (current.cta_10200503203030 != null)
                    current.Total10200503203000 += (Decimal)current.cta_10200503203030;
                if (current.cta_10200503203040 != null)
                    current.Total10200503203000 += (Decimal)current.cta_10200503203040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503200000;
                current.Total10200503200000 = 0;
                if (current.cta_10200503201000 != null && current.cta_10200503201000.Total10200503201000 != 0)
                    current.Total10200503200000 += (Decimal)current.cta_10200503201000.Total10200503201000;
                if (current.cta_10200503202000 != null && current.cta_10200503202000.Total10200503202000 != 0)
                    current.Total10200503200000 += (Decimal)current.cta_10200503202000.Total10200503202000;
                if (current.cta_10200503203000 != null && current.cta_10200503203000.Total10200503203000 != 0)
                    current.Total10200503200000 += (Decimal)current.cta_10200503203000.Total10200503203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503300000.cta_10200503301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503300000.cta_10200503301000;
                current.Total10200503301000 = 0;
                if (current.cta_10200503301010 != null)
                    current.Total10200503301000 += (Decimal)current.cta_10200503301010;
                if (current.cta_10200503301020 != null)
                    current.Total10200503301000 += (Decimal)current.cta_10200503301020;
                if (current.cta_10200503301030 != null)
                    current.Total10200503301000 += (Decimal)current.cta_10200503301030;
                if (current.cta_10200503301040 != null)
                    current.Total10200503301000 += (Decimal)current.cta_10200503301040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503300000.cta_10200503302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503300000.cta_10200503302000;
                current.Total10200503302000 = 0;
                if (current.cta_10200503302010 != null)
                    current.Total10200503302000 += (Decimal)current.cta_10200503302010;
                if (current.cta_10200503302020 != null)
                    current.Total10200503302000 += (Decimal)current.cta_10200503302020;
                if (current.cta_10200503302030 != null)
                    current.Total10200503302000 += (Decimal)current.cta_10200503302030;
                if (current.cta_10200503302040 != null)
                    current.Total10200503302000 += (Decimal)current.cta_10200503302040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503300000.cta_10200503303000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503300000.cta_10200503303000;
                current.Total10200503303000 = 0;
                if (current.cta_10200503303010 != null)
                    current.Total10200503303000 += (Decimal)current.cta_10200503303010;
                if (current.cta_10200503303020 != null)
                    current.Total10200503303000 += (Decimal)current.cta_10200503303020;
                if (current.cta_10200503303030 != null)
                    current.Total10200503303000 += (Decimal)current.cta_10200503303030;
                if (current.cta_10200503303040 != null)
                    current.Total10200503303000 += (Decimal)current.cta_10200503303040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503300000;
                current.Total10200503300000 = 0;
                if (current.cta_10200503301000 != null && current.cta_10200503301000.Total10200503301000 != 0)
                    current.Total10200503300000 += (Decimal)current.cta_10200503301000.Total10200503301000;
                if (current.cta_10200503302000 != null && current.cta_10200503302000.Total10200503302000 != 0)
                    current.Total10200503300000 += (Decimal)current.cta_10200503302000.Total10200503302000;
                if (current.cta_10200503303000 != null && current.cta_10200503303000.Total10200503303000 != 0)
                    current.Total10200503300000 += (Decimal)current.cta_10200503303000.Total10200503303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503500000.cta_10200503501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503500000.cta_10200503501000;
                current.Total10200503501000 = 0;
                if (current.cta_10200503501010 != null)
                    current.Total10200503501000 += (Decimal)current.cta_10200503501010;
                if (current.cta_10200503501020 != null)
                    current.Total10200503501000 += (Decimal)current.cta_10200503501020;
                if (current.cta_10200503501030 != null)
                    current.Total10200503501000 += (Decimal)current.cta_10200503501030;
                if (current.cta_10200503501040 != null)
                    current.Total10200503501000 += (Decimal)current.cta_10200503501040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503500000.cta_10200503502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503500000.cta_10200503502000;
                current.Total10200503502000 = 0;
                if (current.cta_10200503502010 != null)
                    current.Total10200503502000 += (Decimal)current.cta_10200503502010;
                if (current.cta_10200503502020 != null)
                    current.Total10200503502000 += (Decimal)current.cta_10200503502020;
                if (current.cta_10200503502030 != null)
                    current.Total10200503502000 += (Decimal)current.cta_10200503502030;
                if (current.cta_10200503502040 != null)
                    current.Total10200503502000 += (Decimal)current.cta_10200503502040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503500000.cta_10200503503000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503500000.cta_10200503503000;
                current.Total10200503503000 = 0;
                if (current.cta_10200503503010 != null)
                    current.Total10200503503000 += (Decimal)current.cta_10200503503010;
                if (current.cta_10200503503020 != null)
                    current.Total10200503503000 += (Decimal)current.cta_10200503503020;
                if (current.cta_10200503503030 != null)
                    current.Total10200503503000 += (Decimal)current.cta_10200503503030;
                if (current.cta_10200503503040 != null)
                    current.Total10200503503000 += (Decimal)current.cta_10200503503040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000.cta_10200503500000;
                current.Total10200503500000 = 0;
                if (current.cta_10200503501000 != null && current.cta_10200503501000.Total10200503501000 != 0)
                    current.Total10200503500000 += (Decimal)current.cta_10200503501000.Total10200503501000;
                if (current.cta_10200503502000 != null && current.cta_10200503502000.Total10200503502000 != 0)
                    current.Total10200503500000 += (Decimal)current.cta_10200503502000.Total10200503502000;
                if (current.cta_10200503503000 != null && current.cta_10200503503000.Total10200503503000 != 0)
                    current.Total10200503500000 += (Decimal)current.cta_10200503503000.Total10200503503000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200500000000;
                current.Total10200500000000 = 0;
                if (current.cta_10200500100000 != null && current.cta_10200500100000.Total10200500100000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200500100000.Total10200500100000;
                if (current.cta_10200500200000 != null && current.cta_10200500200000.Total10200500200000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200500200000.Total10200500200000;
                if (current.cta_10200500300000 != null && current.cta_10200500300000.Total10200500300000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200500300000.Total10200500300000;
                if (current.cta_10200500400000 != null && current.cta_10200500400000.Total10200500400000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200500400000.Total10200500400000;
                if (current.cta_10200501900000 != null && current.cta_10200501900000.Total10200501900000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200501900000.Total10200501900000;
                if (current.cta_10200502000000 != null && current.cta_10200502000000.Total10200502000000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200502000000.Total10200502000000;
                if (current.cta_10200502100000 != null && current.cta_10200502100000.Total10200502100000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200502100000.Total10200502100000;
                if (current.cta_10200502200000 != null && current.cta_10200502200000.Total10200502200000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200502200000.Total10200502200000;
                if (current.cta_10200502300000 != null && current.cta_10200502300000.Total10200502300000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200502300000.Total10200502300000;
                if (current.cta_10200502400000 != null && current.cta_10200502400000.Total10200502400000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200502400000.Total10200502400000;
                if (current.cta_10200502700000 != null && current.cta_10200502700000.Total10200502700000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200502700000.Total10200502700000;
                if (current.cta_10200502800000 != null && current.cta_10200502800000.Total10200502800000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200502800000.Total10200502800000;
                if (current.cta_10200502900000 != null && current.cta_10200502900000.Total10200502900000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200502900000.Total10200502900000;
                if (current.cta_10200503000000 != null && current.cta_10200503000000.Total10200503000000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200503000000.Total10200503000000;
                if (current.cta_10200503200000 != null && current.cta_10200503200000.Total10200503200000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200503200000.Total10200503200000;
                if (current.cta_10200503300000 != null && current.cta_10200503300000.Total10200503300000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200503300000.Total10200503300000;
                if (current.cta_10200503500000 != null && current.cta_10200503500000.Total10200503500000 != 0)
                    current.Total10200500000000 += (Decimal)current.cta_10200503500000.Total10200503500000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600100000.cta_10200600101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600100000.cta_10200600101000;
                current.Total10200600101000 = 0;
                if (current.cta_10200600101010 != null)
                    current.Total10200600101000 += (Decimal)current.cta_10200600101010;
                if (current.cta_10200600101020 != null)
                    current.Total10200600101000 += (Decimal)current.cta_10200600101020;
                if (current.cta_10200600101030 != null)
                    current.Total10200600101000 += (Decimal)current.cta_10200600101030;
                if (current.cta_10200600101040 != null)
                    current.Total10200600101000 += (Decimal)current.cta_10200600101040;
                if (current.cta_10200600101050 != null)
                    current.Total10200600101000 += (Decimal)current.cta_10200600101050;
                if (current.cta_10200600101060 != null)
                    current.Total10200600101000 += (Decimal)current.cta_10200600101060;
                if (current.cta_10200600101070 != null)
                    current.Total10200600101000 += (Decimal)current.cta_10200600101070;
                if (current.cta_10200600101080 != null)
                    current.Total10200600101000 += (Decimal)current.cta_10200600101080;
                if (current.cta_10200600101990 != null)
                    current.Total10200600101000 += (Decimal)current.cta_10200600101990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600100000.cta_10200600102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600100000.cta_10200600102000;
                current.Total10200600102000 = 0;
                if (current.cta_10200600102010 != null)
                    current.Total10200600102000 += (Decimal)current.cta_10200600102010;
                if (current.cta_10200600102020 != null)
                    current.Total10200600102000 += (Decimal)current.cta_10200600102020;
                if (current.cta_10200600102030 != null)
                    current.Total10200600102000 += (Decimal)current.cta_10200600102030;
                if (current.cta_10200600102040 != null)
                    current.Total10200600102000 += (Decimal)current.cta_10200600102040;
                if (current.cta_10200600102050 != null)
                    current.Total10200600102000 += (Decimal)current.cta_10200600102050;
                if (current.cta_10200600102060 != null)
                    current.Total10200600102000 += (Decimal)current.cta_10200600102060;
                if (current.cta_10200600102070 != null)
                    current.Total10200600102000 += (Decimal)current.cta_10200600102070;
                if (current.cta_10200600102080 != null)
                    current.Total10200600102000 += (Decimal)current.cta_10200600102080;
                if (current.cta_10200600102990 != null)
                    current.Total10200600102000 += (Decimal)current.cta_10200600102990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600100000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600100000.cta_10200600103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600100000.cta_10200600103000;
                current.Total10200600103000 = 0;
                if (current.cta_10200600103010 != null)
                    current.Total10200600103000 += (Decimal)current.cta_10200600103010;
                if (current.cta_10200600103020 != null)
                    current.Total10200600103000 += (Decimal)current.cta_10200600103020;
                if (current.cta_10200600103030 != null)
                    current.Total10200600103000 += (Decimal)current.cta_10200600103030;
                if (current.cta_10200600103040 != null)
                    current.Total10200600103000 += (Decimal)current.cta_10200600103040;
                if (current.cta_10200600103050 != null)
                    current.Total10200600103000 += (Decimal)current.cta_10200600103050;
                if (current.cta_10200600103060 != null)
                    current.Total10200600103000 += (Decimal)current.cta_10200600103060;
                if (current.cta_10200600103070 != null)
                    current.Total10200600103000 += (Decimal)current.cta_10200600103070;
                if (current.cta_10200600103080 != null)
                    current.Total10200600103000 += (Decimal)current.cta_10200600103080;
                if (current.cta_10200600103990 != null)
                    current.Total10200600103000 += (Decimal)current.cta_10200600103990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600100000;
                current.Total10200600100000 = 0;
                if (current.cta_10200600101000 != null && current.cta_10200600101000.Total10200600101000 != 0)
                    current.Total10200600100000 += (Decimal)current.cta_10200600101000.Total10200600101000;
                if (current.cta_10200600102000 != null && current.cta_10200600102000.Total10200600102000 != 0)
                    current.Total10200600100000 += (Decimal)current.cta_10200600102000.Total10200600102000;
                if (current.cta_10200600103000 != null && current.cta_10200600103000.Total10200600103000 != 0)
                    current.Total10200600100000 += (Decimal)current.cta_10200600103000.Total10200600103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600200000.cta_10200600201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600200000.cta_10200600201000;
                current.Total10200600201000 = 0;
                if (current.cta_10200600201010 != null)
                    current.Total10200600201000 += (Decimal)current.cta_10200600201010;
                if (current.cta_10200600201020 != null)
                    current.Total10200600201000 += (Decimal)current.cta_10200600201020;
                if (current.cta_10200600201030 != null)
                    current.Total10200600201000 += (Decimal)current.cta_10200600201030;
                if (current.cta_10200600201040 != null)
                    current.Total10200600201000 += (Decimal)current.cta_10200600201040;
                if (current.cta_10200600201050 != null)
                    current.Total10200600201000 += (Decimal)current.cta_10200600201050;
                if (current.cta_10200600201060 != null)
                    current.Total10200600201000 += (Decimal)current.cta_10200600201060;
                if (current.cta_10200600201070 != null)
                    current.Total10200600201000 += (Decimal)current.cta_10200600201070;
                if (current.cta_10200600201080 != null)
                    current.Total10200600201000 += (Decimal)current.cta_10200600201080;
                if (current.cta_10200600201990 != null)
                    current.Total10200600201000 += (Decimal)current.cta_10200600201990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600200000.cta_10200600202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600200000.cta_10200600202000;
                current.Total10200600202000 = 0;
                if (current.cta_10200600202010 != null)
                    current.Total10200600202000 += (Decimal)current.cta_10200600202010;
                if (current.cta_10200600202020 != null)
                    current.Total10200600202000 += (Decimal)current.cta_10200600202020;
                if (current.cta_10200600202030 != null)
                    current.Total10200600202000 += (Decimal)current.cta_10200600202030;
                if (current.cta_10200600202040 != null)
                    current.Total10200600202000 += (Decimal)current.cta_10200600202040;
                if (current.cta_10200600202050 != null)
                    current.Total10200600202000 += (Decimal)current.cta_10200600202050;
                if (current.cta_10200600202060 != null)
                    current.Total10200600202000 += (Decimal)current.cta_10200600202060;
                if (current.cta_10200600202070 != null)
                    current.Total10200600202000 += (Decimal)current.cta_10200600202070;
                if (current.cta_10200600202080 != null)
                    current.Total10200600202000 += (Decimal)current.cta_10200600202080;
                if (current.cta_10200600202990 != null)
                    current.Total10200600202000 += (Decimal)current.cta_10200600202990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600200000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600200000.cta_10200600203000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600200000.cta_10200600203000;
                current.Total10200600203000 = 0;
                if (current.cta_10200600203010 != null)
                    current.Total10200600203000 += (Decimal)current.cta_10200600203010;
                if (current.cta_10200600203020 != null)
                    current.Total10200600203000 += (Decimal)current.cta_10200600203020;
                if (current.cta_10200600203030 != null)
                    current.Total10200600203000 += (Decimal)current.cta_10200600203030;
                if (current.cta_10200600203040 != null)
                    current.Total10200600203000 += (Decimal)current.cta_10200600203040;
                if (current.cta_10200600203050 != null)
                    current.Total10200600203000 += (Decimal)current.cta_10200600203050;
                if (current.cta_10200600203060 != null)
                    current.Total10200600203000 += (Decimal)current.cta_10200600203060;
                if (current.cta_10200600203070 != null)
                    current.Total10200600203000 += (Decimal)current.cta_10200600203070;
                if (current.cta_10200600203080 != null)
                    current.Total10200600203000 += (Decimal)current.cta_10200600203080;
                if (current.cta_10200600203990 != null)
                    current.Total10200600203000 += (Decimal)current.cta_10200600203990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600200000;
                current.Total10200600200000 = 0;
                if (current.cta_10200600201000 != null && current.cta_10200600201000.Total10200600201000 != 0)
                    current.Total10200600200000 += (Decimal)current.cta_10200600201000.Total10200600201000;
                if (current.cta_10200600202000 != null && current.cta_10200600202000.Total10200600202000 != 0)
                    current.Total10200600200000 += (Decimal)current.cta_10200600202000.Total10200600202000;
                if (current.cta_10200600203000 != null && current.cta_10200600203000.Total10200600203000 != 0)
                    current.Total10200600200000 += (Decimal)current.cta_10200600203000.Total10200600203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600300000.cta_10200600301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600300000.cta_10200600301000;
                current.Total10200600301000 = 0;
                if (current.cta_10200600301010 != null)
                    current.Total10200600301000 += (Decimal)current.cta_10200600301010;
                if (current.cta_10200600301020 != null)
                    current.Total10200600301000 += (Decimal)current.cta_10200600301020;
                if (current.cta_10200600301030 != null)
                    current.Total10200600301000 += (Decimal)current.cta_10200600301030;
                if (current.cta_10200600301040 != null)
                    current.Total10200600301000 += (Decimal)current.cta_10200600301040;
                if (current.cta_10200600301990 != null)
                    current.Total10200600301000 += (Decimal)current.cta_10200600301990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600300000.cta_10200600302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600300000.cta_10200600302000;
                current.Total10200600302000 = 0;
                if (current.cta_10200600302010 != null)
                    current.Total10200600302000 += (Decimal)current.cta_10200600302010;
                if (current.cta_10200600302020 != null)
                    current.Total10200600302000 += (Decimal)current.cta_10200600302020;
                if (current.cta_10200600302030 != null)
                    current.Total10200600302000 += (Decimal)current.cta_10200600302030;
                if (current.cta_10200600302040 != null)
                    current.Total10200600302000 += (Decimal)current.cta_10200600302040;
                if (current.cta_10200600302990 != null)
                    current.Total10200600302000 += (Decimal)current.cta_10200600302990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600300000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600300000.cta_10200600303000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600300000.cta_10200600303000;
                current.Total10200600303000 = 0;
                if (current.cta_10200600303010 != null)
                    current.Total10200600303000 += (Decimal)current.cta_10200600303010;
                if (current.cta_10200600303020 != null)
                    current.Total10200600303000 += (Decimal)current.cta_10200600303020;
                if (current.cta_10200600303030 != null)
                    current.Total10200600303000 += (Decimal)current.cta_10200600303030;
                if (current.cta_10200600303040 != null)
                    current.Total10200600303000 += (Decimal)current.cta_10200600303040;
                if (current.cta_10200600303990 != null)
                    current.Total10200600303000 += (Decimal)current.cta_10200600303990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600300000;
                current.Total10200600300000 = 0;
                if (current.cta_10200600301000 != null && current.cta_10200600301000.Total10200600301000 != 0)
                    current.Total10200600300000 += (Decimal)current.cta_10200600301000.Total10200600301000;
                if (current.cta_10200600302000 != null && current.cta_10200600302000.Total10200600302000 != 0)
                    current.Total10200600300000 += (Decimal)current.cta_10200600302000.Total10200600302000;
                if (current.cta_10200600303000 != null && current.cta_10200600303000.Total10200600303000 != 0)
                    current.Total10200600300000 += (Decimal)current.cta_10200600303000.Total10200600303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600400000.cta_10200600401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600400000.cta_10200600401000;
                current.Total10200600401000 = 0;
                if (current.cta_10200600401010 != null)
                    current.Total10200600401000 += (Decimal)current.cta_10200600401010;
                if (current.cta_10200600401020 != null)
                    current.Total10200600401000 += (Decimal)current.cta_10200600401020;
                if (current.cta_10200600401030 != null)
                    current.Total10200600401000 += (Decimal)current.cta_10200600401030;
                if (current.cta_10200600401040 != null)
                    current.Total10200600401000 += (Decimal)current.cta_10200600401040;
                if (current.cta_10200600401050 != null)
                    current.Total10200600401000 += (Decimal)current.cta_10200600401050;
                if (current.cta_10200600401060 != null)
                    current.Total10200600401000 += (Decimal)current.cta_10200600401060;
                if (current.cta_10200600401070 != null)
                    current.Total10200600401000 += (Decimal)current.cta_10200600401070;
                if (current.cta_10200600401080 != null)
                    current.Total10200600401000 += (Decimal)current.cta_10200600401080;
                if (current.cta_10200600401090 != null)
                    current.Total10200600401000 += (Decimal)current.cta_10200600401090;
                if (current.cta_10200600401100 != null)
                    current.Total10200600401000 += (Decimal)current.cta_10200600401100;
                if (current.cta_10200600401990 != null)
                    current.Total10200600401000 += (Decimal)current.cta_10200600401990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600400000.cta_10200600402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600400000.cta_10200600402000;
                current.Total10200600402000 = 0;
                if (current.cta_10200600402010 != null)
                    current.Total10200600402000 += (Decimal)current.cta_10200600402010;
                if (current.cta_10200600402020 != null)
                    current.Total10200600402000 += (Decimal)current.cta_10200600402020;
                if (current.cta_10200600402030 != null)
                    current.Total10200600402000 += (Decimal)current.cta_10200600402030;
                if (current.cta_10200600402040 != null)
                    current.Total10200600402000 += (Decimal)current.cta_10200600402040;
                if (current.cta_10200600402050 != null)
                    current.Total10200600402000 += (Decimal)current.cta_10200600402050;
                if (current.cta_10200600402060 != null)
                    current.Total10200600402000 += (Decimal)current.cta_10200600402060;
                if (current.cta_10200600402070 != null)
                    current.Total10200600402000 += (Decimal)current.cta_10200600402070;
                if (current.cta_10200600402080 != null)
                    current.Total10200600402000 += (Decimal)current.cta_10200600402080;
                if (current.cta_10200600402090 != null)
                    current.Total10200600402000 += (Decimal)current.cta_10200600402090;
                if (current.cta_10200600402100 != null)
                    current.Total10200600402000 += (Decimal)current.cta_10200600402100;
                if (current.cta_10200600402990 != null)
                    current.Total10200600402000 += (Decimal)current.cta_10200600402990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600400000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600400000.cta_10200600403000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600400000.cta_10200600403000;
                current.Total10200600403000 = 0;
                if (current.cta_10200600403010 != null)
                    current.Total10200600403000 += (Decimal)current.cta_10200600403010;
                if (current.cta_10200600403020 != null)
                    current.Total10200600403000 += (Decimal)current.cta_10200600403020;
                if (current.cta_10200600403030 != null)
                    current.Total10200600403000 += (Decimal)current.cta_10200600403030;
                if (current.cta_10200600403040 != null)
                    current.Total10200600403000 += (Decimal)current.cta_10200600403040;
                if (current.cta_10200600403050 != null)
                    current.Total10200600403000 += (Decimal)current.cta_10200600403050;
                if (current.cta_10200600403060 != null)
                    current.Total10200600403000 += (Decimal)current.cta_10200600403060;
                if (current.cta_10200600403070 != null)
                    current.Total10200600403000 += (Decimal)current.cta_10200600403070;
                if (current.cta_10200600403080 != null)
                    current.Total10200600403000 += (Decimal)current.cta_10200600403080;
                if (current.cta_10200600403090 != null)
                    current.Total10200600403000 += (Decimal)current.cta_10200600403090;
                if (current.cta_10200600403100 != null)
                    current.Total10200600403000 += (Decimal)current.cta_10200600403100;
                if (current.cta_10200600403990 != null)
                    current.Total10200600403000 += (Decimal)current.cta_10200600403990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600400000;
                current.Total10200600400000 = 0;
                if (current.cta_10200600401000 != null && current.cta_10200600401000.Total10200600401000 != 0)
                    current.Total10200600400000 += (Decimal)current.cta_10200600401000.Total10200600401000;
                if (current.cta_10200600402000 != null && current.cta_10200600402000.Total10200600402000 != 0)
                    current.Total10200600400000 += (Decimal)current.cta_10200600402000.Total10200600402000;
                if (current.cta_10200600403000 != null && current.cta_10200600403000.Total10200600403000 != 0)
                    current.Total10200600400000 += (Decimal)current.cta_10200600403000.Total10200600403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600500000.cta_10200600501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600500000.cta_10200600501000;
                current.Total10200600501000 = 0;
                if (current.cta_10200600501010 != null)
                    current.Total10200600501000 += (Decimal)current.cta_10200600501010;
                if (current.cta_10200600501020 != null)
                    current.Total10200600501000 += (Decimal)current.cta_10200600501020;
                if (current.cta_10200600501030 != null)
                    current.Total10200600501000 += (Decimal)current.cta_10200600501030;
                if (current.cta_10200600501040 != null)
                    current.Total10200600501000 += (Decimal)current.cta_10200600501040;
                if (current.cta_10200600501050 != null)
                    current.Total10200600501000 += (Decimal)current.cta_10200600501050;
                if (current.cta_10200600501060 != null)
                    current.Total10200600501000 += (Decimal)current.cta_10200600501060;
                if (current.cta_10200600501070 != null)
                    current.Total10200600501000 += (Decimal)current.cta_10200600501070;
                if (current.cta_10200600501080 != null)
                    current.Total10200600501000 += (Decimal)current.cta_10200600501080;
                if (current.cta_10200600501990 != null)
                    current.Total10200600501000 += (Decimal)current.cta_10200600501990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600500000.cta_10200600502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600500000.cta_10200600502000;
                current.Total10200600502000 = 0;
                if (current.cta_10200600502010 != null)
                    current.Total10200600502000 += (Decimal)current.cta_10200600502010;
                if (current.cta_10200600502020 != null)
                    current.Total10200600502000 += (Decimal)current.cta_10200600502020;
                if (current.cta_10200600502030 != null)
                    current.Total10200600502000 += (Decimal)current.cta_10200600502030;
                if (current.cta_10200600502040 != null)
                    current.Total10200600502000 += (Decimal)current.cta_10200600502040;
                if (current.cta_10200600502050 != null)
                    current.Total10200600502000 += (Decimal)current.cta_10200600502050;
                if (current.cta_10200600502060 != null)
                    current.Total10200600502000 += (Decimal)current.cta_10200600502060;
                if (current.cta_10200600502070 != null)
                    current.Total10200600502000 += (Decimal)current.cta_10200600502070;
                if (current.cta_10200600502080 != null)
                    current.Total10200600502000 += (Decimal)current.cta_10200600502080;
                if (current.cta_10200600502990 != null)
                    current.Total10200600502000 += (Decimal)current.cta_10200600502990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600500000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600500000.cta_10200600503000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600500000.cta_10200600503000;
                current.Total10200600503000 = 0;
                if (current.cta_10200600503010 != null)
                    current.Total10200600503000 += (Decimal)current.cta_10200600503010;
                if (current.cta_10200600503020 != null)
                    current.Total10200600503000 += (Decimal)current.cta_10200600503020;
                if (current.cta_10200600503030 != null)
                    current.Total10200600503000 += (Decimal)current.cta_10200600503030;
                if (current.cta_10200600503040 != null)
                    current.Total10200600503000 += (Decimal)current.cta_10200600503040;
                if (current.cta_10200600503050 != null)
                    current.Total10200600503000 += (Decimal)current.cta_10200600503050;
                if (current.cta_10200600503060 != null)
                    current.Total10200600503000 += (Decimal)current.cta_10200600503060;
                if (current.cta_10200600503070 != null)
                    current.Total10200600503000 += (Decimal)current.cta_10200600503070;
                if (current.cta_10200600503080 != null)
                    current.Total10200600503000 += (Decimal)current.cta_10200600503080;
                if (current.cta_10200600503990 != null)
                    current.Total10200600503000 += (Decimal)current.cta_10200600503990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600500000;
                current.Total10200600500000 = 0;
                if (current.cta_10200600501000 != null && current.cta_10200600501000.Total10200600501000 != 0)
                    current.Total10200600500000 += (Decimal)current.cta_10200600501000.Total10200600501000;
                if (current.cta_10200600502000 != null && current.cta_10200600502000.Total10200600502000 != 0)
                    current.Total10200600500000 += (Decimal)current.cta_10200600502000.Total10200600502000;
                if (current.cta_10200600503000 != null && current.cta_10200600503000.Total10200600503000 != 0)
                    current.Total10200600500000 += (Decimal)current.cta_10200600503000.Total10200600503000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600600000.cta_10200600601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600600000.cta_10200600601000;
                current.Total10200600601000 = 0;
                if (current.cta_10200600601010 != null)
                    current.Total10200600601000 += (Decimal)current.cta_10200600601010;
                if (current.cta_10200600601020 != null)
                    current.Total10200600601000 += (Decimal)current.cta_10200600601020;
                if (current.cta_10200600601030 != null)
                    current.Total10200600601000 += (Decimal)current.cta_10200600601030;
                if (current.cta_10200600601040 != null)
                    current.Total10200600601000 += (Decimal)current.cta_10200600601040;
                if (current.cta_10200600601050 != null)
                    current.Total10200600601000 += (Decimal)current.cta_10200600601050;
                if (current.cta_10200600601060 != null)
                    current.Total10200600601000 += (Decimal)current.cta_10200600601060;
                if (current.cta_10200600601070 != null)
                    current.Total10200600601000 += (Decimal)current.cta_10200600601070;
                if (current.cta_10200600601080 != null)
                    current.Total10200600601000 += (Decimal)current.cta_10200600601080;
                if (current.cta_10200600601990 != null)
                    current.Total10200600601000 += (Decimal)current.cta_10200600601990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600600000.cta_10200600602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600600000.cta_10200600602000;
                current.Total10200600602000 = 0;
                if (current.cta_10200600602010 != null)
                    current.Total10200600602000 += (Decimal)current.cta_10200600602010;
                if (current.cta_10200600602020 != null)
                    current.Total10200600602000 += (Decimal)current.cta_10200600602020;
                if (current.cta_10200600602030 != null)
                    current.Total10200600602000 += (Decimal)current.cta_10200600602030;
                if (current.cta_10200600602040 != null)
                    current.Total10200600602000 += (Decimal)current.cta_10200600602040;
                if (current.cta_10200600602050 != null)
                    current.Total10200600602000 += (Decimal)current.cta_10200600602050;
                if (current.cta_10200600602060 != null)
                    current.Total10200600602000 += (Decimal)current.cta_10200600602060;
                if (current.cta_10200600602070 != null)
                    current.Total10200600602000 += (Decimal)current.cta_10200600602070;
                if (current.cta_10200600602080 != null)
                    current.Total10200600602000 += (Decimal)current.cta_10200600602080;
                if (current.cta_10200600602990 != null)
                    current.Total10200600602000 += (Decimal)current.cta_10200600602990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600600000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600600000.cta_10200600603000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600600000.cta_10200600603000;
                current.Total10200600603000 = 0;
                if (current.cta_10200600603010 != null)
                    current.Total10200600603000 += (Decimal)current.cta_10200600603010;
                if (current.cta_10200600603020 != null)
                    current.Total10200600603000 += (Decimal)current.cta_10200600603020;
                if (current.cta_10200600603030 != null)
                    current.Total10200600603000 += (Decimal)current.cta_10200600603030;
                if (current.cta_10200600603040 != null)
                    current.Total10200600603000 += (Decimal)current.cta_10200600603040;
                if (current.cta_10200600603050 != null)
                    current.Total10200600603000 += (Decimal)current.cta_10200600603050;
                if (current.cta_10200600603060 != null)
                    current.Total10200600603000 += (Decimal)current.cta_10200600603060;
                if (current.cta_10200600603070 != null)
                    current.Total10200600603000 += (Decimal)current.cta_10200600603070;
                if (current.cta_10200600603080 != null)
                    current.Total10200600603000 += (Decimal)current.cta_10200600603080;
                if (current.cta_10200600603990 != null)
                    current.Total10200600603000 += (Decimal)current.cta_10200600603990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600600000;
                current.Total10200600600000 = 0;
                if (current.cta_10200600601000 != null && current.cta_10200600601000.Total10200600601000 != 0)
                    current.Total10200600600000 += (Decimal)current.cta_10200600601000.Total10200600601000;
                if (current.cta_10200600602000 != null && current.cta_10200600602000.Total10200600602000 != 0)
                    current.Total10200600600000 += (Decimal)current.cta_10200600602000.Total10200600602000;
                if (current.cta_10200600603000 != null && current.cta_10200600603000.Total10200600603000 != 0)
                    current.Total10200600600000 += (Decimal)current.cta_10200600603000.Total10200600603000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600700000.cta_10200600701000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600700000.cta_10200600701000;
                current.Total10200600701000 = 0;
                if (current.cta_10200600701010 != null)
                    current.Total10200600701000 += (Decimal)current.cta_10200600701010;
                if (current.cta_10200600701020 != null)
                    current.Total10200600701000 += (Decimal)current.cta_10200600701020;
                if (current.cta_10200600701030 != null)
                    current.Total10200600701000 += (Decimal)current.cta_10200600701030;
                if (current.cta_10200600701040 != null)
                    current.Total10200600701000 += (Decimal)current.cta_10200600701040;
                if (current.cta_10200600701990 != null)
                    current.Total10200600701000 += (Decimal)current.cta_10200600701990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600700000.cta_10200600702000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600700000.cta_10200600702000;
                current.Total10200600702000 = 0;
                if (current.cta_10200600702010 != null)
                    current.Total10200600702000 += (Decimal)current.cta_10200600702010;
                if (current.cta_10200600702020 != null)
                    current.Total10200600702000 += (Decimal)current.cta_10200600702020;
                if (current.cta_10200600702030 != null)
                    current.Total10200600702000 += (Decimal)current.cta_10200600702030;
                if (current.cta_10200600702040 != null)
                    current.Total10200600702000 += (Decimal)current.cta_10200600702040;
                if (current.cta_10200600702990 != null)
                    current.Total10200600702000 += (Decimal)current.cta_10200600702990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600700000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600700000.cta_10200600703000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600700000.cta_10200600703000;
                current.Total10200600703000 = 0;
                if (current.cta_10200600703010 != null)
                    current.Total10200600703000 += (Decimal)current.cta_10200600703010;
                if (current.cta_10200600703020 != null)
                    current.Total10200600703000 += (Decimal)current.cta_10200600703020;
                if (current.cta_10200600703030 != null)
                    current.Total10200600703000 += (Decimal)current.cta_10200600703030;
                if (current.cta_10200600703040 != null)
                    current.Total10200600703000 += (Decimal)current.cta_10200600703040;
                if (current.cta_10200600703990 != null)
                    current.Total10200600703000 += (Decimal)current.cta_10200600703990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600700000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600700000;
                current.Total10200600700000 = 0;
                if (current.cta_10200600701000 != null && current.cta_10200600701000.Total10200600701000 != 0)
                    current.Total10200600700000 += (Decimal)current.cta_10200600701000.Total10200600701000;
                if (current.cta_10200600702000 != null && current.cta_10200600702000.Total10200600702000 != 0)
                    current.Total10200600700000 += (Decimal)current.cta_10200600702000.Total10200600702000;
                if (current.cta_10200600703000 != null && current.cta_10200600703000.Total10200600703000 != 0)
                    current.Total10200600700000 += (Decimal)current.cta_10200600703000.Total10200600703000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600800000.cta_10200600801000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600800000.cta_10200600801000;
                current.Total10200600801000 = 0;
                if (current.cta_10200600801010 != null)
                    current.Total10200600801000 += (Decimal)current.cta_10200600801010;
                if (current.cta_10200600801020 != null)
                    current.Total10200600801000 += (Decimal)current.cta_10200600801020;
                if (current.cta_10200600801030 != null)
                    current.Total10200600801000 += (Decimal)current.cta_10200600801030;
                if (current.cta_10200600801040 != null)
                    current.Total10200600801000 += (Decimal)current.cta_10200600801040;
                if (current.cta_10200600801050 != null)
                    current.Total10200600801000 += (Decimal)current.cta_10200600801050;
                if (current.cta_10200600801060 != null)
                    current.Total10200600801000 += (Decimal)current.cta_10200600801060;
                if (current.cta_10200600801070 != null)
                    current.Total10200600801000 += (Decimal)current.cta_10200600801070;
                if (current.cta_10200600801080 != null)
                    current.Total10200600801000 += (Decimal)current.cta_10200600801080;
                if (current.cta_10200600801990 != null)
                    current.Total10200600801000 += (Decimal)current.cta_10200600801990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600800000.cta_10200600802000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600800000.cta_10200600802000;
                current.Total10200600802000 = 0;
                if (current.cta_10200600802010 != null)
                    current.Total10200600802000 += (Decimal)current.cta_10200600802010;
                if (current.cta_10200600802020 != null)
                    current.Total10200600802000 += (Decimal)current.cta_10200600802020;
                if (current.cta_10200600802030 != null)
                    current.Total10200600802000 += (Decimal)current.cta_10200600802030;
                if (current.cta_10200600802040 != null)
                    current.Total10200600802000 += (Decimal)current.cta_10200600802040;
                if (current.cta_10200600802050 != null)
                    current.Total10200600802000 += (Decimal)current.cta_10200600802050;
                if (current.cta_10200600802060 != null)
                    current.Total10200600802000 += (Decimal)current.cta_10200600802060;
                if (current.cta_10200600802070 != null)
                    current.Total10200600802000 += (Decimal)current.cta_10200600802070;
                if (current.cta_10200600802080 != null)
                    current.Total10200600802000 += (Decimal)current.cta_10200600802080;
                if (current.cta_10200600802990 != null)
                    current.Total10200600802000 += (Decimal)current.cta_10200600802990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600800000.cta_10200600803000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600800000.cta_10200600803000;
                current.Total10200600803000 = 0;
                if (current.cta_10200600803010 != null)
                    current.Total10200600803000 += (Decimal)current.cta_10200600803010;
                if (current.cta_10200600803020 != null)
                    current.Total10200600803000 += (Decimal)current.cta_10200600803020;
                if (current.cta_10200600803030 != null)
                    current.Total10200600803000 += (Decimal)current.cta_10200600803030;
                if (current.cta_10200600803040 != null)
                    current.Total10200600803000 += (Decimal)current.cta_10200600803040;
                if (current.cta_10200600803050 != null)
                    current.Total10200600803000 += (Decimal)current.cta_10200600803050;
                if (current.cta_10200600803060 != null)
                    current.Total10200600803000 += (Decimal)current.cta_10200600803060;
                if (current.cta_10200600803070 != null)
                    current.Total10200600803000 += (Decimal)current.cta_10200600803070;
                if (current.cta_10200600803080 != null)
                    current.Total10200600803000 += (Decimal)current.cta_10200600803080;
                if (current.cta_10200600803990 != null)
                    current.Total10200600803000 += (Decimal)current.cta_10200600803990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600800000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600800000;
                current.Total10200600800000 = 0;
                if (current.cta_10200600801000 != null && current.cta_10200600801000.Total10200600801000 != 0)
                    current.Total10200600800000 += (Decimal)current.cta_10200600801000.Total10200600801000;
                if (current.cta_10200600802000 != null && current.cta_10200600802000.Total10200600802000 != 0)
                    current.Total10200600800000 += (Decimal)current.cta_10200600802000.Total10200600802000;
                if (current.cta_10200600803000 != null && current.cta_10200600803000.Total10200600803000 != 0)
                    current.Total10200600800000 += (Decimal)current.cta_10200600803000.Total10200600803000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600900000.cta_10200600901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600900000.cta_10200600901000;
                current.Total10200600901000 = 0;
                if (current.cta_10200600901010 != null)
                    current.Total10200600901000 += (Decimal)current.cta_10200600901010;
                if (current.cta_10200600901020 != null)
                    current.Total10200600901000 += (Decimal)current.cta_10200600901020;
                if (current.cta_10200600901030 != null)
                    current.Total10200600901000 += (Decimal)current.cta_10200600901030;
                if (current.cta_10200600901040 != null)
                    current.Total10200600901000 += (Decimal)current.cta_10200600901040;
                if (current.cta_10200600901050 != null)
                    current.Total10200600901000 += (Decimal)current.cta_10200600901050;
                if (current.cta_10200600901060 != null)
                    current.Total10200600901000 += (Decimal)current.cta_10200600901060;
                if (current.cta_10200600901070 != null)
                    current.Total10200600901000 += (Decimal)current.cta_10200600901070;
                if (current.cta_10200600901080 != null)
                    current.Total10200600901000 += (Decimal)current.cta_10200600901080;
                if (current.cta_10200600901990 != null)
                    current.Total10200600901000 += (Decimal)current.cta_10200600901990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600900000.cta_10200600902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600900000.cta_10200600902000;
                current.Total10200600902000 = 0;
                if (current.cta_10200600902010 != null)
                    current.Total10200600902000 += (Decimal)current.cta_10200600902010;
                if (current.cta_10200600902020 != null)
                    current.Total10200600902000 += (Decimal)current.cta_10200600902020;
                if (current.cta_10200600902030 != null)
                    current.Total10200600902000 += (Decimal)current.cta_10200600902030;
                if (current.cta_10200600902040 != null)
                    current.Total10200600902000 += (Decimal)current.cta_10200600902040;
                if (current.cta_10200600902050 != null)
                    current.Total10200600902000 += (Decimal)current.cta_10200600902050;
                if (current.cta_10200600902060 != null)
                    current.Total10200600902000 += (Decimal)current.cta_10200600902060;
                if (current.cta_10200600902070 != null)
                    current.Total10200600902000 += (Decimal)current.cta_10200600902070;
                if (current.cta_10200600902080 != null)
                    current.Total10200600902000 += (Decimal)current.cta_10200600902080;
                if (current.cta_10200600902990 != null)
                    current.Total10200600902000 += (Decimal)current.cta_10200600902990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600900000.cta_10200600903000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600900000.cta_10200600903000;
                current.Total10200600903000 = 0;
                if (current.cta_10200600903010 != null)
                    current.Total10200600903000 += (Decimal)current.cta_10200600903010;
                if (current.cta_10200600903020 != null)
                    current.Total10200600903000 += (Decimal)current.cta_10200600903020;
                if (current.cta_10200600903030 != null)
                    current.Total10200600903000 += (Decimal)current.cta_10200600903030;
                if (current.cta_10200600903040 != null)
                    current.Total10200600903000 += (Decimal)current.cta_10200600903040;
                if (current.cta_10200600903050 != null)
                    current.Total10200600903000 += (Decimal)current.cta_10200600903050;
                if (current.cta_10200600903060 != null)
                    current.Total10200600903000 += (Decimal)current.cta_10200600903060;
                if (current.cta_10200600903070 != null)
                    current.Total10200600903000 += (Decimal)current.cta_10200600903070;
                if (current.cta_10200600903080 != null)
                    current.Total10200600903000 += (Decimal)current.cta_10200600903080;
                if (current.cta_10200600903990 != null)
                    current.Total10200600903000 += (Decimal)current.cta_10200600903990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200600900000;
                current.Total10200600900000 = 0;
                if (current.cta_10200600901000 != null && current.cta_10200600901000.Total10200600901000 != 0)
                    current.Total10200600900000 += (Decimal)current.cta_10200600901000.Total10200600901000;
                if (current.cta_10200600902000 != null && current.cta_10200600902000.Total10200600902000 != 0)
                    current.Total10200600900000 += (Decimal)current.cta_10200600902000.Total10200600902000;
                if (current.cta_10200600903000 != null && current.cta_10200600903000.Total10200600903000 != 0)
                    current.Total10200600900000 += (Decimal)current.cta_10200600903000.Total10200600903000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200601000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200601000000.cta_10200601001000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200601000000.cta_10200601001000;
                current.Total10200601001000 = 0;
                if (current.cta_10200601001010 != null)
                    current.Total10200601001000 += (Decimal)current.cta_10200601001010;
                if (current.cta_10200601001020 != null)
                    current.Total10200601001000 += (Decimal)current.cta_10200601001020;
                if (current.cta_10200601001030 != null)
                    current.Total10200601001000 += (Decimal)current.cta_10200601001030;
                if (current.cta_10200601001040 != null)
                    current.Total10200601001000 += (Decimal)current.cta_10200601001040;
                if (current.cta_10200601001990 != null)
                    current.Total10200601001000 += (Decimal)current.cta_10200601001990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200601000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200601000000.cta_10200601002000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200601000000.cta_10200601002000;
                current.Total10200601002000 = 0;
                if (current.cta_10200601002010 != null)
                    current.Total10200601002000 += (Decimal)current.cta_10200601002010;
                if (current.cta_10200601002020 != null)
                    current.Total10200601002000 += (Decimal)current.cta_10200601002020;
                if (current.cta_10200601002030 != null)
                    current.Total10200601002000 += (Decimal)current.cta_10200601002030;
                if (current.cta_10200601002040 != null)
                    current.Total10200601002000 += (Decimal)current.cta_10200601002040;
                if (current.cta_10200601002990 != null)
                    current.Total10200601002000 += (Decimal)current.cta_10200601002990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200601000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200601000000.cta_10200601003000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200601000000.cta_10200601003000;
                current.Total10200601003000 = 0;
                if (current.cta_10200601003010 != null)
                    current.Total10200601003000 += (Decimal)current.cta_10200601003010;
                if (current.cta_10200601003020 != null)
                    current.Total10200601003000 += (Decimal)current.cta_10200601003020;
                if (current.cta_10200601003030 != null)
                    current.Total10200601003000 += (Decimal)current.cta_10200601003030;
                if (current.cta_10200601003040 != null)
                    current.Total10200601003000 += (Decimal)current.cta_10200601003040;
                if (current.cta_10200601003990 != null)
                    current.Total10200601003000 += (Decimal)current.cta_10200601003990;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200601000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200601000000;
                current.Total10200601000000 = 0;
                if (current.cta_10200601001000 != null && current.cta_10200601001000.Total10200601001000 != 0)
                    current.Total10200601000000 += (Decimal)current.cta_10200601001000.Total10200601001000;
                if (current.cta_10200601002000 != null && current.cta_10200601002000.Total10200601002000 != 0)
                    current.Total10200601000000 += (Decimal)current.cta_10200601002000.Total10200601002000;
                if (current.cta_10200601003000 != null && current.cta_10200601003000.Total10200601003000 != 0)
                    current.Total10200601000000 += (Decimal)current.cta_10200601003000.Total10200601003000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200609900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200609900000.cta_10200609901000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200609900000.cta_10200609901000;
                current.Total10200609901000 = 0;
                if (current.cta_10200609901010 != null)
                    current.Total10200609901000 += (Decimal)current.cta_10200609901010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200609900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200609900000.cta_10200609902000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200609900000.cta_10200609902000;
                current.Total10200609902000 = 0;
                if (current.cta_10200609902010 != null)
                    current.Total10200609902000 += (Decimal)current.cta_10200609902010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200609900000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200609900000.cta_10200609903000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200609900000.cta_10200609903000;
                current.Total10200609903000 = 0;
                if (current.cta_10200609903010 != null)
                    current.Total10200609903000 += (Decimal)current.cta_10200609903010;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200609900000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000.cta_10200609900000;
                current.Total10200609900000 = 0;
                if (current.cta_10200609901000 != null && current.cta_10200609901000.Total10200609901000 != 0)
                    current.Total10200609900000 += (Decimal)current.cta_10200609901000.Total10200609901000;
                if (current.cta_10200609902000 != null && current.cta_10200609902000.Total10200609902000 != 0)
                    current.Total10200609900000 += (Decimal)current.cta_10200609902000.Total10200609902000;
                if (current.cta_10200609903000 != null && current.cta_10200609903000.Total10200609903000 != 0)
                    current.Total10200609900000 += (Decimal)current.cta_10200609903000.Total10200609903000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200600000000;
                current.Total10200600000000 = 0;
                if (current.cta_10200600100000 != null && current.cta_10200600100000.Total10200600100000 != 0)
                    current.Total10200600000000 += (Decimal)current.cta_10200600100000.Total10200600100000;
                if (current.cta_10200600200000 != null && current.cta_10200600200000.Total10200600200000 != 0)
                    current.Total10200600000000 += (Decimal)current.cta_10200600200000.Total10200600200000;
                if (current.cta_10200600300000 != null && current.cta_10200600300000.Total10200600300000 != 0)
                    current.Total10200600000000 += (Decimal)current.cta_10200600300000.Total10200600300000;
                if (current.cta_10200600400000 != null && current.cta_10200600400000.Total10200600400000 != 0)
                    current.Total10200600000000 += (Decimal)current.cta_10200600400000.Total10200600400000;
                if (current.cta_10200600500000 != null && current.cta_10200600500000.Total10200600500000 != 0)
                    current.Total10200600000000 += (Decimal)current.cta_10200600500000.Total10200600500000;
                if (current.cta_10200600600000 != null && current.cta_10200600600000.Total10200600600000 != 0)
                    current.Total10200600000000 += (Decimal)current.cta_10200600600000.Total10200600600000;
                if (current.cta_10200600700000 != null && current.cta_10200600700000.Total10200600700000 != 0)
                    current.Total10200600000000 += (Decimal)current.cta_10200600700000.Total10200600700000;
                if (current.cta_10200600800000 != null && current.cta_10200600800000.Total10200600800000 != 0)
                    current.Total10200600000000 += (Decimal)current.cta_10200600800000.Total10200600800000;
                if (current.cta_10200600900000 != null && current.cta_10200600900000.Total10200600900000 != 0)
                    current.Total10200600000000 += (Decimal)current.cta_10200600900000.Total10200600900000;
                if (current.cta_10200601000000 != null && current.cta_10200601000000.Total10200601000000 != 0)
                    current.Total10200600000000 += (Decimal)current.cta_10200601000000.Total10200601000000;
                if (current.cta_10200609900000 != null && current.cta_10200609900000.Total10200609900000 != 0)
                    current.Total10200600000000 += (Decimal)current.cta_10200609900000.Total10200609900000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000.cta_10200800100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000.cta_10200800100000;
                current.Total10200800100000 = 0;
                if (current.cta_10200800101000 != null)
                    current.Total10200800100000 += (Decimal)current.cta_10200800101000;
                if (current.cta_10200800102000 != null)
                    current.Total10200800100000 += (Decimal)current.cta_10200800102000;
                if (current.cta_10200800103000 != null)
                    current.Total10200800100000 += (Decimal)current.cta_10200800103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000.cta_10200800800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000.cta_10200800800000.cta_10200800801000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000.cta_10200800800000.cta_10200800801000;
                current.Total10200800801000 = 0;
                if (current.cta_10200800801010 != null)
                    current.Total10200800801000 += (Decimal)current.cta_10200800801010;
                if (current.cta_10200800801020 != null)
                    current.Total10200800801000 += (Decimal)current.cta_10200800801020;
                if (current.cta_10200800801030 != null)
                    current.Total10200800801000 += (Decimal)current.cta_10200800801030;
                if (current.cta_10200800801040 != null)
                    current.Total10200800801000 += (Decimal)current.cta_10200800801040;
                if (current.cta_10200800801050 != null)
                    current.Total10200800801000 += (Decimal)current.cta_10200800801050;
                if (current.cta_10200800801060 != null)
                    current.Total10200800801000 += (Decimal)current.cta_10200800801060;
                if (current.cta_10200800801080 != null)
                    current.Total10200800801000 += (Decimal)current.cta_10200800801080;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000.cta_10200800800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000.cta_10200800800000.cta_10200800802000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000.cta_10200800800000.cta_10200800802000;
                current.Total10200800802000 = 0;
                if (current.cta_10200800802010 != null)
                    current.Total10200800802000 += (Decimal)current.cta_10200800802010;
                if (current.cta_10200800802020 != null)
                    current.Total10200800802000 += (Decimal)current.cta_10200800802020;
                if (current.cta_10200800802030 != null)
                    current.Total10200800802000 += (Decimal)current.cta_10200800802030;
                if (current.cta_10200800802040 != null)
                    current.Total10200800802000 += (Decimal)current.cta_10200800802040;
                if (current.cta_10200800802050 != null)
                    current.Total10200800802000 += (Decimal)current.cta_10200800802050;
                if (current.cta_10200800802060 != null)
                    current.Total10200800802000 += (Decimal)current.cta_10200800802060;
                if (current.cta_10200800802080 != null)
                    current.Total10200800802000 += (Decimal)current.cta_10200800802080;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000.cta_10200800800000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000.cta_10200800800000.cta_10200800803000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000.cta_10200800800000.cta_10200800803000;
                current.Total10200800803000 = 0;
                if (current.cta_10200800803010 != null)
                    current.Total10200800803000 += (Decimal)current.cta_10200800803010;
                if (current.cta_10200800803020 != null)
                    current.Total10200800803000 += (Decimal)current.cta_10200800803020;
                if (current.cta_10200800803030 != null)
                    current.Total10200800803000 += (Decimal)current.cta_10200800803030;
                if (current.cta_10200800803040 != null)
                    current.Total10200800803000 += (Decimal)current.cta_10200800803040;
                if (current.cta_10200800803050 != null)
                    current.Total10200800803000 += (Decimal)current.cta_10200800803050;
                if (current.cta_10200800803060 != null)
                    current.Total10200800803000 += (Decimal)current.cta_10200800803060;
                if (current.cta_10200800803080 != null)
                    current.Total10200800803000 += (Decimal)current.cta_10200800803080;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000.cta_10200800800000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000.cta_10200800800000;
                current.Total10200800800000 = 0;
                if (current.cta_10200800801000 != null && current.cta_10200800801000.Total10200800801000 != 0)
                    current.Total10200800800000 += (Decimal)current.cta_10200800801000.Total10200800801000;
                if (current.cta_10200800802000 != null && current.cta_10200800802000.Total10200800802000 != 0)
                    current.Total10200800800000 += (Decimal)current.cta_10200800802000.Total10200800802000;
                if (current.cta_10200800803000 != null && current.cta_10200800803000.Total10200800803000 != 0)
                    current.Total10200800800000 += (Decimal)current.cta_10200800803000.Total10200800803000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200800000000;
                current.Total10200800000000 = 0;
                if (current.cta_10200800100000 != null && current.cta_10200800100000.Total10200800100000 != 0)
                    current.Total10200800000000 += (Decimal)current.cta_10200800100000.Total10200800100000;
                if (current.cta_10200800800000 != null && current.cta_10200800800000.Total10200800800000 != 0)
                    current.Total10200800000000 += (Decimal)current.cta_10200800800000.Total10200800800000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000.cta_10200900300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000.cta_10200900300000;
                current.Total10200900300000 = 0;
                if (current.cta_10200900301000 != null)
                    current.Total10200900300000 += (Decimal)current.cta_10200900301000;
                if (current.cta_10200900302000 != null)
                    current.Total10200900300000 += (Decimal)current.cta_10200900302000;
                if (current.cta_10200900303000 != null)
                    current.Total10200900300000 += (Decimal)current.cta_10200900303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000.cta_10200900400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000.cta_10200900400000;
                current.Total10200900400000 = 0;
                if (current.cta_10200900401000 != null)
                    current.Total10200900400000 += (Decimal)current.cta_10200900401000;
                if (current.cta_10200900402000 != null)
                    current.Total10200900400000 += (Decimal)current.cta_10200900402000;
                if (current.cta_10200900403000 != null)
                    current.Total10200900400000 += (Decimal)current.cta_10200900403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000.cta_10200900500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000.cta_10200900500000;
                current.Total10200900500000 = 0;
                if (current.cta_10200900501000 != null)
                    current.Total10200900500000 += (Decimal)current.cta_10200900501000;
                if (current.cta_10200900502000 != null)
                    current.Total10200900500000 += (Decimal)current.cta_10200900502000;
                if (current.cta_10200900503000 != null)
                    current.Total10200900500000 += (Decimal)current.cta_10200900503000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000.cta_10200900600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000.cta_10200900600000;
                current.Total10200900600000 = 0;
                if (current.cta_10200900601000 != null)
                    current.Total10200900600000 += (Decimal)current.cta_10200900601000;
                if (current.cta_10200900602000 != null)
                    current.Total10200900600000 += (Decimal)current.cta_10200900602000;
                if (current.cta_10200900603000 != null)
                    current.Total10200900600000 += (Decimal)current.cta_10200900603000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000.cta_10200900800000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000.cta_10200900800000;
                current.Total10200900800000 = 0;
                if (current.cta_10200900801000 != null)
                    current.Total10200900800000 += (Decimal)current.cta_10200900801000;
                if (current.cta_10200900802000 != null)
                    current.Total10200900800000 += (Decimal)current.cta_10200900802000;
                if (current.cta_10200900803000 != null)
                    current.Total10200900800000 += (Decimal)current.cta_10200900803000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null && modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000.cta_10200900000000;
                current.Total10200900000000 = 0;
                if (current.cta_10200900300000 != null && current.cta_10200900300000.Total10200900300000 != 0)
                    current.Total10200900000000 += (Decimal)current.cta_10200900300000.Total10200900300000;
                if (current.cta_10200900400000 != null && current.cta_10200900400000.Total10200900400000 != 0)
                    current.Total10200900000000 += (Decimal)current.cta_10200900400000.Total10200900400000;
                if (current.cta_10200900500000 != null && current.cta_10200900500000.Total10200900500000 != 0)
                    current.Total10200900000000 += (Decimal)current.cta_10200900500000.Total10200900500000;
                if (current.cta_10200900600000 != null && current.cta_10200900600000.Total10200900600000 != 0)
                    current.Total10200900000000 += (Decimal)current.cta_10200900600000.Total10200900600000;
                if (current.cta_10200900800000 != null && current.cta_10200900800000.Total10200900800000 != 0)
                    current.Total10200900000000 += (Decimal)current.cta_10200900800000.Total10200900800000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10200000000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10200000000000;
                current.Total10200000000000 = 0;
                if (current.cta_10200100000000 != null && current.cta_10200100000000.Total10200100000000 != 0)
                    current.Total10200000000000 += (Decimal)current.cta_10200100000000.Total10200100000000;
                if (current.cta_10200200000000 != null && current.cta_10200200000000.Total10200200000000 != 0)
                    current.Total10200000000000 += (Decimal)current.cta_10200200000000.Total10200200000000;
                if (current.cta_10200300000000 != null && current.cta_10200300000000.Total10200300000000 != 0)
                    current.Total10200000000000 += (Decimal)current.cta_10200300000000.Total10200300000000;
                if (current.cta_10200400000000 != null && current.cta_10200400000000.Total10200400000000 != 0)
                    current.Total10200000000000 += (Decimal)current.cta_10200400000000.Total10200400000000;
                if (current.cta_10200500000000 != null && current.cta_10200500000000.Total10200500000000 != 0)
                    current.Total10200000000000 += (Decimal)current.cta_10200500000000.Total10200500000000;
                if (current.cta_10200600000000 != null && current.cta_10200600000000.Total10200600000000 != 0)
                    current.Total10200000000000 += (Decimal)current.cta_10200600000000.Total10200600000000;
                if (current.cta_10200800000000 != null && current.cta_10200800000000.Total10200800000000 != 0)
                    current.Total10200000000000 += (Decimal)current.cta_10200800000000.Total10200800000000;
                if (current.cta_10200900000000 != null && current.cta_10200900000000.Total10200900000000 != 0)
                    current.Total10200000000000 += (Decimal)current.cta_10200900000000.Total10200900000000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103100000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103100000.cta_10300103101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103100000.cta_10300103101000;
                current.Total10300103101000 = 0;
                if (current.cta_10300103101010 != null)
                    current.Total10300103101000 += (Decimal)current.cta_10300103101010;
                if (current.cta_10300103101020 != null)
                    current.Total10300103101000 += (Decimal)current.cta_10300103101020;
                if (current.cta_10300103101030 != null)
                    current.Total10300103101000 += (Decimal)current.cta_10300103101030;
                if (current.cta_10300103101100 != null)
                    current.Total10300103101000 += (Decimal)current.cta_10300103101100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103100000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103100000.cta_10300103102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103100000.cta_10300103102000;
                current.Total10300103102000 = 0;
                if (current.cta_10300103102010 != null)
                    current.Total10300103102000 += (Decimal)current.cta_10300103102010;
                if (current.cta_10300103102020 != null)
                    current.Total10300103102000 += (Decimal)current.cta_10300103102020;
                if (current.cta_10300103102030 != null)
                    current.Total10300103102000 += (Decimal)current.cta_10300103102030;
                if (current.cta_10300103102100 != null)
                    current.Total10300103102000 += (Decimal)current.cta_10300103102100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103100000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103100000.cta_10300103103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103100000.cta_10300103103000;
                current.Total10300103103000 = 0;
                if (current.cta_10300103103010 != null)
                    current.Total10300103103000 += (Decimal)current.cta_10300103103010;
                if (current.cta_10300103103020 != null)
                    current.Total10300103103000 += (Decimal)current.cta_10300103103020;
                if (current.cta_10300103103030 != null)
                    current.Total10300103103000 += (Decimal)current.cta_10300103103030;
                if (current.cta_10300103103100 != null)
                    current.Total10300103103000 += (Decimal)current.cta_10300103103100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103100000;
                current.Total10300103100000 = 0;
                if (current.cta_10300103101000 != null && current.cta_10300103101000.Total10300103101000 != 0)
                    current.Total10300103100000 += (Decimal)current.cta_10300103101000.Total10300103101000;
                if (current.cta_10300103102000 != null && current.cta_10300103102000.Total10300103102000 != 0)
                    current.Total10300103100000 += (Decimal)current.cta_10300103102000.Total10300103102000;
                if (current.cta_10300103103000 != null && current.cta_10300103103000.Total10300103103000 != 0)
                    current.Total10300103100000 += (Decimal)current.cta_10300103103000.Total10300103103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103300000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103300000.cta_10300103301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103300000.cta_10300103301000;
                current.Total10300103301000 = 0;
                if (current.cta_10300103301010 != null)
                    current.Total10300103301000 += (Decimal)current.cta_10300103301010;
                if (current.cta_10300103301100 != null)
                    current.Total10300103301000 += (Decimal)current.cta_10300103301100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103300000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103300000.cta_10300103302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103300000.cta_10300103302000;
                current.Total10300103302000 = 0;
                if (current.cta_10300103302010 != null)
                    current.Total10300103302000 += (Decimal)current.cta_10300103302010;
                if (current.cta_10300103302100 != null)
                    current.Total10300103302000 += (Decimal)current.cta_10300103302100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103300000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103300000.cta_10300103303000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103300000.cta_10300103303000;
                current.Total10300103303000 = 0;
                if (current.cta_10300103303010 != null)
                    current.Total10300103303000 += (Decimal)current.cta_10300103303010;
                if (current.cta_10300103303100 != null)
                    current.Total10300103303000 += (Decimal)current.cta_10300103303100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103300000;
                current.Total10300103300000 = 0;
                if (current.cta_10300103301000 != null && current.cta_10300103301000.Total10300103301000 != 0)
                    current.Total10300103300000 += (Decimal)current.cta_10300103301000.Total10300103301000;
                if (current.cta_10300103302000 != null && current.cta_10300103302000.Total10300103302000 != 0)
                    current.Total10300103300000 += (Decimal)current.cta_10300103302000.Total10300103302000;
                if (current.cta_10300103303000 != null && current.cta_10300103303000.Total10300103303000 != 0)
                    current.Total10300103300000 += (Decimal)current.cta_10300103303000.Total10300103303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103400000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103400000.cta_10300103401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103400000.cta_10300103401000;
                current.Total10300103401000 = 0;
                if (current.cta_10300103401010 != null)
                    current.Total10300103401000 += (Decimal)current.cta_10300103401010;
                if (current.cta_10300103401100 != null)
                    current.Total10300103401000 += (Decimal)current.cta_10300103401100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103400000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103400000.cta_10300103402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103400000.cta_10300103402000;
                current.Total10300103402000 = 0;
                if (current.cta_10300103402010 != null)
                    current.Total10300103402000 += (Decimal)current.cta_10300103402010;
                if (current.cta_10300103402100 != null)
                    current.Total10300103402000 += (Decimal)current.cta_10300103402100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103400000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103400000.cta_10300103403000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103400000.cta_10300103403000;
                current.Total10300103403000 = 0;
                if (current.cta_10300103403010 != null)
                    current.Total10300103403000 += (Decimal)current.cta_10300103403010;
                if (current.cta_10300103403100 != null)
                    current.Total10300103403000 += (Decimal)current.cta_10300103403100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103400000;
                current.Total10300103400000 = 0;
                if (current.cta_10300103401000 != null && current.cta_10300103401000.Total10300103401000 != 0)
                    current.Total10300103400000 += (Decimal)current.cta_10300103401000.Total10300103401000;
                if (current.cta_10300103402000 != null && current.cta_10300103402000.Total10300103402000 != 0)
                    current.Total10300103400000 += (Decimal)current.cta_10300103402000.Total10300103402000;
                if (current.cta_10300103403000 != null && current.cta_10300103403000.Total10300103403000 != 0)
                    current.Total10300103400000 += (Decimal)current.cta_10300103403000.Total10300103403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.cta_10300103501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.cta_10300103501000;
                current.Total10300103501000 = 0;
                if (current.cta_10300103501010 != null)
                    current.Total10300103501000 += (Decimal)current.cta_10300103501010;
                if (current.cta_10300103501020 != null)
                    current.Total10300103501000 += (Decimal)current.cta_10300103501020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.cta_10300103502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.cta_10300103502000;
                current.Total10300103502000 = 0;
                if (current.cta_10300103502010 != null)
                    current.Total10300103502000 += (Decimal)current.cta_10300103502010;
                if (current.cta_10300103502020 != null)
                    current.Total10300103502000 += (Decimal)current.cta_10300103502020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.cta_10300103503000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000.cta_10300103503000;
                current.Total10300103503000 = 0;
                if (current.cta_10300103503010 != null)
                    current.Total10300103503000 += (Decimal)current.cta_10300103503010;
                if (current.cta_10300103503020 != null)
                    current.Total10300103503000 += (Decimal)current.cta_10300103503020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103500000;
                current.Total10300103500000 = 0;
                if (current.cta_10300103501000 != null && current.cta_10300103501000.Total10300103501000 != 0)
                    current.Total10300103500000 += (Decimal)current.cta_10300103501000.Total10300103501000;
                if (current.cta_10300103502000 != null && current.cta_10300103502000.Total10300103502000 != 0)
                    current.Total10300103500000 += (Decimal)current.cta_10300103502000.Total10300103502000;
                if (current.cta_10300103503000 != null && current.cta_10300103503000.Total10300103503000 != 0)
                    current.Total10300103500000 += (Decimal)current.cta_10300103503000.Total10300103503000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.cta_10300103601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.cta_10300103601000;
                current.Total10300103601000 = 0;
                if (current.cta_10300103601010 != null)
                    current.Total10300103601000 += (Decimal)current.cta_10300103601010;
                if (current.cta_10300103601020 != null)
                    current.Total10300103601000 += (Decimal)current.cta_10300103601020;
                if (current.cta_10300103601100 != null)
                    current.Total10300103601000 += (Decimal)current.cta_10300103601100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.cta_10300103602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.cta_10300103602000;
                current.Total10300103602000 = 0;
                if (current.cta_10300103602010 != null)
                    current.Total10300103602000 += (Decimal)current.cta_10300103602010;
                if (current.cta_10300103602020 != null)
                    current.Total10300103602000 += (Decimal)current.cta_10300103602020;
                if (current.cta_10300103602100 != null)
                    current.Total10300103602000 += (Decimal)current.cta_10300103602100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.cta_10300103603000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000.cta_10300103603000;
                current.Total10300103603000 = 0;
                if (current.cta_10300103603010 != null)
                    current.Total10300103603000 += (Decimal)current.cta_10300103603010;
                if (current.cta_10300103603020 != null)
                    current.Total10300103603000 += (Decimal)current.cta_10300103603020;
                if (current.cta_10300103603100 != null)
                    current.Total10300103603000 += (Decimal)current.cta_10300103603100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000.cta_10300103600000;
                current.Total10300103600000 = 0;
                if (current.cta_10300103601000 != null && current.cta_10300103601000.Total10300103601000 != 0)
                    current.Total10300103600000 += (Decimal)current.cta_10300103601000.Total10300103601000;
                if (current.cta_10300103602000 != null && current.cta_10300103602000.Total10300103602000 != 0)
                    current.Total10300103600000 += (Decimal)current.cta_10300103602000.Total10300103602000;
                if (current.cta_10300103603000 != null && current.cta_10300103603000.Total10300103603000 != 0)
                    current.Total10300103600000 += (Decimal)current.cta_10300103603000.Total10300103603000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300100000000;
                current.Total10300100000000 = 0;
                if (current.cta_10300103100000 != null && current.cta_10300103100000.Total10300103100000 != 0)
                    current.Total10300100000000 += (Decimal)current.cta_10300103100000.Total10300103100000;
                if (current.cta_10300103300000 != null && current.cta_10300103300000.Total10300103300000 != 0)
                    current.Total10300100000000 += (Decimal)current.cta_10300103300000.Total10300103300000;
                if (current.cta_10300103400000 != null && current.cta_10300103400000.Total10300103400000 != 0)
                    current.Total10300100000000 += (Decimal)current.cta_10300103400000.Total10300103400000;
                if (current.cta_10300103500000 != null && current.cta_10300103500000.Total10300103500000 != 0)
                    current.Total10300100000000 += (Decimal)current.cta_10300103500000.Total10300103500000;
                if (current.cta_10300103600000 != null && current.cta_10300103600000.Total10300103600000 != 0)
                    current.Total10300100000000 += (Decimal)current.cta_10300103600000.Total10300103600000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.cta_10300203101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.cta_10300203101000;
                current.Total10300203101000 = 0;
                if (current.cta_10300203101010 != null)
                    current.Total10300203101000 += (Decimal)current.cta_10300203101010;
                if (current.cta_10300203101020 != null)
                    current.Total10300203101000 += (Decimal)current.cta_10300203101020;
                if (current.cta_10300203101030 != null)
                    current.Total10300203101000 += (Decimal)current.cta_10300203101030;
                if (current.cta_10300203101100 != null)
                    current.Total10300203101000 += (Decimal)current.cta_10300203101100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.cta_10300203102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.cta_10300203102000;
                current.Total10300203102000 = 0;
                if (current.cta_10300203102010 != null)
                    current.Total10300203102000 += (Decimal)current.cta_10300203102010;
                if (current.cta_10300203102020 != null)
                    current.Total10300203102000 += (Decimal)current.cta_10300203102020;
                if (current.cta_10300203102030 != null)
                    current.Total10300203102000 += (Decimal)current.cta_10300203102030;
                if (current.cta_10300203102100 != null)
                    current.Total10300203102000 += (Decimal)current.cta_10300203102100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.cta_10300203103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000.cta_10300203103000;
                current.Total10300203103000 = 0;
                if (current.cta_10300203103010 != null)
                    current.Total10300203103000 += (Decimal)current.cta_10300203103010;
                if (current.cta_10300203103020 != null)
                    current.Total10300203103000 += (Decimal)current.cta_10300203103020;
                if (current.cta_10300203103030 != null)
                    current.Total10300203103000 += (Decimal)current.cta_10300203103030;
                if (current.cta_10300203103100 != null)
                    current.Total10300203103000 += (Decimal)current.cta_10300203103100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203100000;
                current.Total10300203100000 = 0;
                if (current.cta_10300203101000 != null && current.cta_10300203101000.Total10300203101000 != 0)
                    current.Total10300203100000 += (Decimal)current.cta_10300203101000.Total10300203101000;
                if (current.cta_10300203102000 != null && current.cta_10300203102000.Total10300203102000 != 0)
                    current.Total10300203100000 += (Decimal)current.cta_10300203102000.Total10300203102000;
                if (current.cta_10300203103000 != null && current.cta_10300203103000.Total10300203103000 != 0)
                    current.Total10300203100000 += (Decimal)current.cta_10300203103000.Total10300203103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.cta_10300203301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.cta_10300203301000;
                current.Total10300203301000 = 0;
                if (current.cta_10300203301010 != null)
                    current.Total10300203301000 += (Decimal)current.cta_10300203301010;
                if (current.cta_10300203301100 != null)
                    current.Total10300203301000 += (Decimal)current.cta_10300203301100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.cta_10300203302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.cta_10300203302000;
                current.Total10300203302000 = 0;
                if (current.cta_10300203302010 != null)
                    current.Total10300203302000 += (Decimal)current.cta_10300203302010;
                if (current.cta_10300203302100 != null)
                    current.Total10300203302000 += (Decimal)current.cta_10300203302100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.cta_10300203303000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000.cta_10300203303000;
                current.Total10300203303000 = 0;
                if (current.cta_10300203303010 != null)
                    current.Total10300203303000 += (Decimal)current.cta_10300203303010;
                if (current.cta_10300203303100 != null)
                    current.Total10300203303000 += (Decimal)current.cta_10300203303100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203300000;
                current.Total10300203300000 = 0;
                if (current.cta_10300203301000 != null && current.cta_10300203301000.Total10300203301000 != 0)
                    current.Total10300203300000 += (Decimal)current.cta_10300203301000.Total10300203301000;
                if (current.cta_10300203302000 != null && current.cta_10300203302000.Total10300203302000 != 0)
                    current.Total10300203300000 += (Decimal)current.cta_10300203302000.Total10300203302000;
                if (current.cta_10300203303000 != null && current.cta_10300203303000.Total10300203303000 != 0)
                    current.Total10300203300000 += (Decimal)current.cta_10300203303000.Total10300203303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.cta_10300203401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.cta_10300203401000;
                current.Total10300203401000 = 0;
                if (current.cta_10300203401010 != null)
                    current.Total10300203401000 += (Decimal)current.cta_10300203401010;
                if (current.cta_10300203401100 != null)
                    current.Total10300203401000 += (Decimal)current.cta_10300203401100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.cta_10300203402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.cta_10300203402000;
                current.Total10300203402000 = 0;
                if (current.cta_10300203402010 != null)
                    current.Total10300203402000 += (Decimal)current.cta_10300203402010;
                if (current.cta_10300203402100 != null)
                    current.Total10300203402000 += (Decimal)current.cta_10300203402100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.cta_10300203403000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000.cta_10300203403000;
                current.Total10300203403000 = 0;
                if (current.cta_10300203403010 != null)
                    current.Total10300203403000 += (Decimal)current.cta_10300203403010;
                if (current.cta_10300203403100 != null)
                    current.Total10300203403000 += (Decimal)current.cta_10300203403100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203400000;
                current.Total10300203400000 = 0;
                if (current.cta_10300203401000 != null && current.cta_10300203401000.Total10300203401000 != 0)
                    current.Total10300203400000 += (Decimal)current.cta_10300203401000.Total10300203401000;
                if (current.cta_10300203402000 != null && current.cta_10300203402000.Total10300203402000 != 0)
                    current.Total10300203400000 += (Decimal)current.cta_10300203402000.Total10300203402000;
                if (current.cta_10300203403000 != null && current.cta_10300203403000.Total10300203403000 != 0)
                    current.Total10300203400000 += (Decimal)current.cta_10300203403000.Total10300203403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.cta_10300203501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.cta_10300203501000;
                current.Total10300203501000 = 0;
                if (current.cta_10300203501010 != null)
                    current.Total10300203501000 += (Decimal)current.cta_10300203501010;
                if (current.cta_10300203501020 != null)
                    current.Total10300203501000 += (Decimal)current.cta_10300203501020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.cta_10300203502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.cta_10300203502000;
                current.Total10300203502000 = 0;
                if (current.cta_10300203502010 != null)
                    current.Total10300203502000 += (Decimal)current.cta_10300203502010;
                if (current.cta_10300203502020 != null)
                    current.Total10300203502000 += (Decimal)current.cta_10300203502020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.cta_10300203503000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000.cta_10300203503000;
                current.Total10300203503000 = 0;
                if (current.cta_10300203503010 != null)
                    current.Total10300203503000 += (Decimal)current.cta_10300203503010;
                if (current.cta_10300203503020 != null)
                    current.Total10300203503000 += (Decimal)current.cta_10300203503020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203500000;
                current.Total10300203500000 = 0;
                if (current.cta_10300203501000 != null && current.cta_10300203501000.Total10300203501000 != 0)
                    current.Total10300203500000 += (Decimal)current.cta_10300203501000.Total10300203501000;
                if (current.cta_10300203502000 != null && current.cta_10300203502000.Total10300203502000 != 0)
                    current.Total10300203500000 += (Decimal)current.cta_10300203502000.Total10300203502000;
                if (current.cta_10300203503000 != null && current.cta_10300203503000.Total10300203503000 != 0)
                    current.Total10300203500000 += (Decimal)current.cta_10300203503000.Total10300203503000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.cta_10300203601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.cta_10300203601000;
                current.Total10300203601000 = 0;
                if (current.cta_10300203601010 != null)
                    current.Total10300203601000 += (Decimal)current.cta_10300203601010;
                if (current.cta_10300203601020 != null)
                    current.Total10300203601000 += (Decimal)current.cta_10300203601020;
                if (current.cta_10300203601100 != null)
                    current.Total10300203601000 += (Decimal)current.cta_10300203601100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.cta_10300203602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.cta_10300203602000;
                current.Total10300203602000 = 0;
                if (current.cta_10300203602010 != null)
                    current.Total10300203602000 += (Decimal)current.cta_10300203602010;
                if (current.cta_10300203602020 != null)
                    current.Total10300203602000 += (Decimal)current.cta_10300203602020;
                if (current.cta_10300203602100 != null)
                    current.Total10300203602000 += (Decimal)current.cta_10300203602100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.cta_10300203603000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000.cta_10300203603000;
                current.Total10300203603000 = 0;
                if (current.cta_10300203603010 != null)
                    current.Total10300203603000 += (Decimal)current.cta_10300203603010;
                if (current.cta_10300203603020 != null)
                    current.Total10300203603000 += (Decimal)current.cta_10300203603020;
                if (current.cta_10300203603100 != null)
                    current.Total10300203603000 += (Decimal)current.cta_10300203603100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000.cta_10300203600000;
                current.Total10300203600000 = 0;
                if (current.cta_10300203601000 != null && current.cta_10300203601000.Total10300203601000 != 0)
                    current.Total10300203600000 += (Decimal)current.cta_10300203601000.Total10300203601000;
                if (current.cta_10300203602000 != null && current.cta_10300203602000.Total10300203602000 != 0)
                    current.Total10300203600000 += (Decimal)current.cta_10300203602000.Total10300203602000;
                if (current.cta_10300203603000 != null && current.cta_10300203603000.Total10300203603000 != 0)
                    current.Total10300203600000 += (Decimal)current.cta_10300203603000.Total10300203603000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300200000000;
                current.Total10300200000000 = 0;
                if (current.cta_10300203100000 != null && current.cta_10300203100000.Total10300203100000 != 0)
                    current.Total10300200000000 += (Decimal)current.cta_10300203100000.Total10300203100000;
                if (current.cta_10300203300000 != null && current.cta_10300203300000.Total10300203300000 != 0)
                    current.Total10300200000000 += (Decimal)current.cta_10300203300000.Total10300203300000;
                if (current.cta_10300203400000 != null && current.cta_10300203400000.Total10300203400000 != 0)
                    current.Total10300200000000 += (Decimal)current.cta_10300203400000.Total10300203400000;
                if (current.cta_10300203500000 != null && current.cta_10300203500000.Total10300203500000 != 0)
                    current.Total10300200000000 += (Decimal)current.cta_10300203500000.Total10300203500000;
                if (current.cta_10300203600000 != null && current.cta_10300203600000.Total10300203600000 != 0)
                    current.Total10300200000000 += (Decimal)current.cta_10300203600000.Total10300203600000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.cta_10300303101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.cta_10300303101000;
                current.Total10300303101000 = 0;
                if (current.cta_10300303101010 != null)
                    current.Total10300303101000 += (Decimal)current.cta_10300303101010;
                if (current.cta_10300303101020 != null)
                    current.Total10300303101000 += (Decimal)current.cta_10300303101020;
                if (current.cta_10300303101030 != null)
                    current.Total10300303101000 += (Decimal)current.cta_10300303101030;
                if (current.cta_10300303101100 != null)
                    current.Total10300303101000 += (Decimal)current.cta_10300303101100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.cta_10300303102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.cta_10300303102000;
                current.Total10300303102000 = 0;
                if (current.cta_10300303102010 != null)
                    current.Total10300303102000 += (Decimal)current.cta_10300303102010;
                if (current.cta_10300303102020 != null)
                    current.Total10300303102000 += (Decimal)current.cta_10300303102020;
                if (current.cta_10300303102030 != null)
                    current.Total10300303102000 += (Decimal)current.cta_10300303102030;
                if (current.cta_10300303102100 != null)
                    current.Total10300303102000 += (Decimal)current.cta_10300303102100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.cta_10300303103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000.cta_10300303103000;
                current.Total10300303103000 = 0;
                if (current.cta_10300303103010 != null)
                    current.Total10300303103000 += (Decimal)current.cta_10300303103010;
                if (current.cta_10300303103020 != null)
                    current.Total10300303103000 += (Decimal)current.cta_10300303103020;
                if (current.cta_10300303103030 != null)
                    current.Total10300303103000 += (Decimal)current.cta_10300303103030;
                if (current.cta_10300303103100 != null)
                    current.Total10300303103000 += (Decimal)current.cta_10300303103100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303100000;
                current.Total10300303100000 = 0;
                if (current.cta_10300303101000 != null && current.cta_10300303101000.Total10300303101000 != 0)
                    current.Total10300303100000 += (Decimal)current.cta_10300303101000.Total10300303101000;
                if (current.cta_10300303102000 != null && current.cta_10300303102000.Total10300303102000 != 0)
                    current.Total10300303100000 += (Decimal)current.cta_10300303102000.Total10300303102000;
                if (current.cta_10300303103000 != null && current.cta_10300303103000.Total10300303103000 != 0)
                    current.Total10300303100000 += (Decimal)current.cta_10300303103000.Total10300303103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.cta_10300303301000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.cta_10300303301000;
                current.Total10300303301000 = 0;
                if (current.cta_10300303301010 != null)
                    current.Total10300303301000 += (Decimal)current.cta_10300303301010;
                if (current.cta_10300303301100 != null)
                    current.Total10300303301000 += (Decimal)current.cta_10300303301100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.cta_10300303302000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.cta_10300303302000;
                current.Total10300303302000 = 0;
                if (current.cta_10300303302010 != null)
                    current.Total10300303302000 += (Decimal)current.cta_10300303302010;
                if (current.cta_10300303302100 != null)
                    current.Total10300303302000 += (Decimal)current.cta_10300303302100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.cta_10300303303000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000.cta_10300303303000;
                current.Total10300303303000 = 0;
                if (current.cta_10300303303010 != null)
                    current.Total10300303303000 += (Decimal)current.cta_10300303303010;
                if (current.cta_10300303303100 != null)
                    current.Total10300303303000 += (Decimal)current.cta_10300303303100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303300000;
                current.Total10300303300000 = 0;
                if (current.cta_10300303301000 != null && current.cta_10300303301000.Total10300303301000 != 0)
                    current.Total10300303300000 += (Decimal)current.cta_10300303301000.Total10300303301000;
                if (current.cta_10300303302000 != null && current.cta_10300303302000.Total10300303302000 != 0)
                    current.Total10300303300000 += (Decimal)current.cta_10300303302000.Total10300303302000;
                if (current.cta_10300303303000 != null && current.cta_10300303303000.Total10300303303000 != 0)
                    current.Total10300303300000 += (Decimal)current.cta_10300303303000.Total10300303303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.cta_10300303401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.cta_10300303401000;
                current.Total10300303401000 = 0;
                if (current.cta_10300303401010 != null)
                    current.Total10300303401000 += (Decimal)current.cta_10300303401010;
                if (current.cta_10300303401100 != null)
                    current.Total10300303401000 += (Decimal)current.cta_10300303401100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.cta_10300303402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.cta_10300303402000;
                current.Total10300303402000 = 0;
                if (current.cta_10300303402010 != null)
                    current.Total10300303402000 += (Decimal)current.cta_10300303402010;
                if (current.cta_10300303402100 != null)
                    current.Total10300303402000 += (Decimal)current.cta_10300303402100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.cta_10300303403000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000.cta_10300303403000;
                current.Total10300303403000 = 0;
                if (current.cta_10300303403010 != null)
                    current.Total10300303403000 += (Decimal)current.cta_10300303403010;
                if (current.cta_10300303403100 != null)
                    current.Total10300303403000 += (Decimal)current.cta_10300303403100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303400000;
                current.Total10300303400000 = 0;
                if (current.cta_10300303401000 != null && current.cta_10300303401000.Total10300303401000 != 0)
                    current.Total10300303400000 += (Decimal)current.cta_10300303401000.Total10300303401000;
                if (current.cta_10300303402000 != null && current.cta_10300303402000.Total10300303402000 != 0)
                    current.Total10300303400000 += (Decimal)current.cta_10300303402000.Total10300303402000;
                if (current.cta_10300303403000 != null && current.cta_10300303403000.Total10300303403000 != 0)
                    current.Total10300303400000 += (Decimal)current.cta_10300303403000.Total10300303403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.cta_10300303501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.cta_10300303501000;
                current.Total10300303501000 = 0;
                if (current.cta_10300303501010 != null)
                    current.Total10300303501000 += (Decimal)current.cta_10300303501010;
                if (current.cta_10300303501020 != null)
                    current.Total10300303501000 += (Decimal)current.cta_10300303501020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.cta_10300303502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.cta_10300303502000;
                current.Total10300303502000 = 0;
                if (current.cta_10300303502010 != null)
                    current.Total10300303502000 += (Decimal)current.cta_10300303502010;
                if (current.cta_10300303502020 != null)
                    current.Total10300303502000 += (Decimal)current.cta_10300303502020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.cta_10300303503000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000.cta_10300303503000;
                current.Total10300303503000 = 0;
                if (current.cta_10300303503010 != null)
                    current.Total10300303503000 += (Decimal)current.cta_10300303503010;
                if (current.cta_10300303503020 != null)
                    current.Total10300303503000 += (Decimal)current.cta_10300303503020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303500000;
                current.Total10300303500000 = 0;
                if (current.cta_10300303501000 != null && current.cta_10300303501000.Total10300303501000 != 0)
                    current.Total10300303500000 += (Decimal)current.cta_10300303501000.Total10300303501000;
                if (current.cta_10300303502000 != null && current.cta_10300303502000.Total10300303502000 != 0)
                    current.Total10300303500000 += (Decimal)current.cta_10300303502000.Total10300303502000;
                if (current.cta_10300303503000 != null && current.cta_10300303503000.Total10300303503000 != 0)
                    current.Total10300303500000 += (Decimal)current.cta_10300303503000.Total10300303503000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.cta_10300303601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.cta_10300303601000;
                current.Total10300303601000 = 0;
                if (current.cta_10300303601010 != null)
                    current.Total10300303601000 += (Decimal)current.cta_10300303601010;
                if (current.cta_10300303601020 != null)
                    current.Total10300303601000 += (Decimal)current.cta_10300303601020;
                if (current.cta_10300303601100 != null)
                    current.Total10300303601000 += (Decimal)current.cta_10300303601100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.cta_10300303602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.cta_10300303602000;
                current.Total10300303602000 = 0;
                if (current.cta_10300303602010 != null)
                    current.Total10300303602000 += (Decimal)current.cta_10300303602010;
                if (current.cta_10300303602020 != null)
                    current.Total10300303602000 += (Decimal)current.cta_10300303602020;
                if (current.cta_10300303602100 != null)
                    current.Total10300303602000 += (Decimal)current.cta_10300303602100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.cta_10300303603000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000.cta_10300303603000;
                current.Total10300303603000 = 0;
                if (current.cta_10300303603010 != null)
                    current.Total10300303603000 += (Decimal)current.cta_10300303603010;
                if (current.cta_10300303603020 != null)
                    current.Total10300303603000 += (Decimal)current.cta_10300303603020;
                if (current.cta_10300303603100 != null)
                    current.Total10300303603000 += (Decimal)current.cta_10300303603100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000.cta_10300303600000;
                current.Total10300303600000 = 0;
                if (current.cta_10300303601000 != null && current.cta_10300303601000.Total10300303601000 != 0)
                    current.Total10300303600000 += (Decimal)current.cta_10300303601000.Total10300303601000;
                if (current.cta_10300303602000 != null && current.cta_10300303602000.Total10300303602000 != 0)
                    current.Total10300303600000 += (Decimal)current.cta_10300303602000.Total10300303602000;
                if (current.cta_10300303603000 != null && current.cta_10300303603000.Total10300303603000 != 0)
                    current.Total10300303600000 += (Decimal)current.cta_10300303603000.Total10300303603000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300300000000;
                current.Total10300300000000 = 0;
                if (current.cta_10300303100000 != null && current.cta_10300303100000.Total10300303100000 != 0)
                    current.Total10300300000000 += (Decimal)current.cta_10300303100000.Total10300303100000;
                if (current.cta_10300303300000 != null && current.cta_10300303300000.Total10300303300000 != 0)
                    current.Total10300300000000 += (Decimal)current.cta_10300303300000.Total10300303300000;
                if (current.cta_10300303400000 != null && current.cta_10300303400000.Total10300303400000 != 0)
                    current.Total10300300000000 += (Decimal)current.cta_10300303400000.Total10300303400000;
                if (current.cta_10300303500000 != null && current.cta_10300303500000.Total10300303500000 != 0)
                    current.Total10300300000000 += (Decimal)current.cta_10300303500000.Total10300303500000;
                if (current.cta_10300303600000 != null && current.cta_10300303600000.Total10300303600000 != 0)
                    current.Total10300300000000 += (Decimal)current.cta_10300303600000.Total10300303600000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.cta_10300400100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.cta_10300400100000;
                current.Total10300400100000 = 0;
                if (current.cta_10300400101000 != null)
                    current.Total10300400100000 += (Decimal)current.cta_10300400101000;
                if (current.cta_10300400102000 != null)
                    current.Total10300400100000 += (Decimal)current.cta_10300400102000;
                if (current.cta_10300400103000 != null)
                    current.Total10300400100000 += (Decimal)current.cta_10300400103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.cta_10300400200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.cta_10300400200000;
                current.Total10300400200000 = 0;
                if (current.cta_10300400201000 != null)
                    current.Total10300400200000 += (Decimal)current.cta_10300400201000;
                if (current.cta_10300400202000 != null)
                    current.Total10300400200000 += (Decimal)current.cta_10300400202000;
                if (current.cta_10300400203000 != null)
                    current.Total10300400200000 += (Decimal)current.cta_10300400203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.cta_10300400300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000.cta_10300400300000;
                current.Total10300400300000 = 0;
                if (current.cta_10300400301000 != null)
                    current.Total10300400300000 += (Decimal)current.cta_10300400301000;
                if (current.cta_10300400302000 != null)
                    current.Total10300400300000 += (Decimal)current.cta_10300400302000;
                if (current.cta_10300400303000 != null)
                    current.Total10300400300000 += (Decimal)current.cta_10300400303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300400000000;
                current.Total10300400000000 = 0;
                if (current.cta_10300400100000 != null && current.cta_10300400100000.Total10300400100000 != 0)
                    current.Total10300400000000 += (Decimal)current.cta_10300400100000.Total10300400100000;
                if (current.cta_10300400200000 != null && current.cta_10300400200000.Total10300400200000 != 0)
                    current.Total10300400000000 += (Decimal)current.cta_10300400200000.Total10300400200000;
                if (current.cta_10300400300000 != null && current.cta_10300400300000.Total10300400300000 != 0)
                    current.Total10300400000000 += (Decimal)current.cta_10300400300000.Total10300400300000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000.cta_10300600100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000.cta_10300600100000;
                current.Total10300600100000 = 0;
                if (current.cta_10300600101000 != null)
                    current.Total10300600100000 += (Decimal)current.cta_10300600101000;
                if (current.cta_10300600102000 != null)
                    current.Total10300600100000 += (Decimal)current.cta_10300600102000;
                if (current.cta_10300600103000 != null)
                    current.Total10300600100000 += (Decimal)current.cta_10300600103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000.cta_10300600200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000.cta_10300600200000;
                current.Total10300600200000 = 0;
                if (current.cta_10300600201000 != null)
                    current.Total10300600200000 += (Decimal)current.cta_10300600201000;
                if (current.cta_10300600202000 != null)
                    current.Total10300600200000 += (Decimal)current.cta_10300600202000;
                if (current.cta_10300600203000 != null)
                    current.Total10300600200000 += (Decimal)current.cta_10300600203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300600000000;
                current.Total10300600000000 = 0;
                if (current.cta_10300600100000 != null && current.cta_10300600100000.Total10300600100000 != 0)
                    current.Total10300600000000 += (Decimal)current.cta_10300600100000.Total10300600100000;
                if (current.cta_10300600200000 != null && current.cta_10300600200000.Total10300600200000 != 0)
                    current.Total10300600000000 += (Decimal)current.cta_10300600200000.Total10300600200000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.cta_10300700200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.cta_10300700200000;
                current.Total10300700200000 = 0;
                if (current.cta_10300700201000 != null)
                    current.Total10300700200000 += (Decimal)current.cta_10300700201000;
                if (current.cta_10300700202000 != null)
                    current.Total10300700200000 += (Decimal)current.cta_10300700202000;
                if (current.cta_10300700203000 != null)
                    current.Total10300700200000 += (Decimal)current.cta_10300700203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.cta_10300700300000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.cta_10300700300000;
                current.Total10300700300000 = 0;
                if (current.cta_10300700301000 != null)
                    current.Total10300700300000 += (Decimal)current.cta_10300700301000;
                if (current.cta_10300700302000 != null)
                    current.Total10300700300000 += (Decimal)current.cta_10300700302000;
                if (current.cta_10300700303000 != null)
                    current.Total10300700300000 += (Decimal)current.cta_10300700303000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.cta_10300700400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000.cta_10300700400000;
                current.Total10300700400000 = 0;
                if (current.cta_10300700401000 != null)
                    current.Total10300700400000 += (Decimal)current.cta_10300700401000;
                if (current.cta_10300700402000 != null)
                    current.Total10300700400000 += (Decimal)current.cta_10300700402000;
                if (current.cta_10300700403000 != null)
                    current.Total10300700400000 += (Decimal)current.cta_10300700403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300700000000;
                current.Total10300700000000 = 0;
                if (current.cta_10300700200000 != null && current.cta_10300700200000.Total10300700200000 != 0)
                    current.Total10300700000000 += (Decimal)current.cta_10300700200000.Total10300700200000;
                if (current.cta_10300700300000 != null && current.cta_10300700300000.Total10300700300000 != 0)
                    current.Total10300700000000 += (Decimal)current.cta_10300700300000.Total10300700300000;
                if (current.cta_10300700400000 != null && current.cta_10300700400000.Total10300700400000 != 0)
                    current.Total10300700000000 += (Decimal)current.cta_10300700400000.Total10300700400000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.cta_10300803101000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.cta_10300803101000;
                current.Total10300803101000 = 0;
                if (current.cta_10300803101010 != null)
                    current.Total10300803101000 += (Decimal)current.cta_10300803101010;
                if (current.cta_10300803101020 != null)
                    current.Total10300803101000 += (Decimal)current.cta_10300803101020;
                if (current.cta_10300803101030 != null)
                    current.Total10300803101000 += (Decimal)current.cta_10300803101030;
                if (current.cta_10300803101100 != null)
                    current.Total10300803101000 += (Decimal)current.cta_10300803101100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.cta_10300803102000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.cta_10300803102000;
                current.Total10300803102000 = 0;
                if (current.cta_10300803102010 != null)
                    current.Total10300803102000 += (Decimal)current.cta_10300803102010;
                if (current.cta_10300803102020 != null)
                    current.Total10300803102000 += (Decimal)current.cta_10300803102020;
                if (current.cta_10300803102030 != null)
                    current.Total10300803102000 += (Decimal)current.cta_10300803102030;
                if (current.cta_10300803102100 != null)
                    current.Total10300803102000 += (Decimal)current.cta_10300803102100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.cta_10300803103000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000.cta_10300803103000;
                current.Total10300803103000 = 0;
                if (current.cta_10300803103010 != null)
                    current.Total10300803103000 += (Decimal)current.cta_10300803103010;
                if (current.cta_10300803103020 != null)
                    current.Total10300803103000 += (Decimal)current.cta_10300803103020;
                if (current.cta_10300803103030 != null)
                    current.Total10300803103000 += (Decimal)current.cta_10300803103030;
                if (current.cta_10300803103100 != null)
                    current.Total10300803103000 += (Decimal)current.cta_10300803103100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803100000;
                current.Total10300803100000 = 0;
                if (current.cta_10300803101000 != null && current.cta_10300803101000.Total10300803101000 != 0)
                    current.Total10300803100000 += (Decimal)current.cta_10300803101000.Total10300803101000;
                if (current.cta_10300803102000 != null && current.cta_10300803102000.Total10300803102000 != 0)
                    current.Total10300803100000 += (Decimal)current.cta_10300803102000.Total10300803102000;
                if (current.cta_10300803103000 != null && current.cta_10300803103000.Total10300803103000 != 0)
                    current.Total10300803100000 += (Decimal)current.cta_10300803103000.Total10300803103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.cta_10300803401000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.cta_10300803401000;
                current.Total10300803401000 = 0;
                if (current.cta_10300803401010 != null)
                    current.Total10300803401000 += (Decimal)current.cta_10300803401010;
                if (current.cta_10300803401100 != null)
                    current.Total10300803401000 += (Decimal)current.cta_10300803401100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.cta_10300803402000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.cta_10300803402000;
                current.Total10300803402000 = 0;
                if (current.cta_10300803402010 != null)
                    current.Total10300803402000 += (Decimal)current.cta_10300803402010;
                if (current.cta_10300803402100 != null)
                    current.Total10300803402000 += (Decimal)current.cta_10300803402100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.cta_10300803403000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000.cta_10300803403000;
                current.Total10300803403000 = 0;
                if (current.cta_10300803403010 != null)
                    current.Total10300803403000 += (Decimal)current.cta_10300803403010;
                if (current.cta_10300803403100 != null)
                    current.Total10300803403000 += (Decimal)current.cta_10300803403100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803400000;
                current.Total10300803400000 = 0;
                if (current.cta_10300803401000 != null && current.cta_10300803401000.Total10300803401000 != 0)
                    current.Total10300803400000 += (Decimal)current.cta_10300803401000.Total10300803401000;
                if (current.cta_10300803402000 != null && current.cta_10300803402000.Total10300803402000 != 0)
                    current.Total10300803400000 += (Decimal)current.cta_10300803402000.Total10300803402000;
                if (current.cta_10300803403000 != null && current.cta_10300803403000.Total10300803403000 != 0)
                    current.Total10300803400000 += (Decimal)current.cta_10300803403000.Total10300803403000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.cta_10300803501000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.cta_10300803501000;
                current.Total10300803501000 = 0;
                if (current.cta_10300803501010 != null)
                    current.Total10300803501000 += (Decimal)current.cta_10300803501010;
                if (current.cta_10300803501100 != null)
                    current.Total10300803501000 += (Decimal)current.cta_10300803501100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.cta_10300803502000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.cta_10300803502000;
                current.Total10300803502000 = 0;
                if (current.cta_10300803502010 != null)
                    current.Total10300803502000 += (Decimal)current.cta_10300803502010;
                if (current.cta_10300803502100 != null)
                    current.Total10300803502000 += (Decimal)current.cta_10300803502100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.cta_10300803503000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000.cta_10300803503000;
                current.Total10300803503000 = 0;
                if (current.cta_10300803503010 != null)
                    current.Total10300803503000 += (Decimal)current.cta_10300803503010;
                if (current.cta_10300803503100 != null)
                    current.Total10300803503000 += (Decimal)current.cta_10300803503100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803500000;
                current.Total10300803500000 = 0;
                if (current.cta_10300803501000 != null && current.cta_10300803501000.Total10300803501000 != 0)
                    current.Total10300803500000 += (Decimal)current.cta_10300803501000.Total10300803501000;
                if (current.cta_10300803502000 != null && current.cta_10300803502000.Total10300803502000 != 0)
                    current.Total10300803500000 += (Decimal)current.cta_10300803502000.Total10300803502000;
                if (current.cta_10300803503000 != null && current.cta_10300803503000.Total10300803503000 != 0)
                    current.Total10300803500000 += (Decimal)current.cta_10300803503000.Total10300803503000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.cta_10300803601000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.cta_10300803601000;
                current.Total10300803601000 = 0;
                if (current.cta_10300803601010 != null)
                    current.Total10300803601000 += (Decimal)current.cta_10300803601010;
                if (current.cta_10300803601020 != null)
                    current.Total10300803601000 += (Decimal)current.cta_10300803601020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.cta_10300803602000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.cta_10300803602000;
                current.Total10300803602000 = 0;
                if (current.cta_10300803602010 != null)
                    current.Total10300803602000 += (Decimal)current.cta_10300803602010;
                if (current.cta_10300803602020 != null)
                    current.Total10300803602000 += (Decimal)current.cta_10300803602020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.cta_10300803603000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000.cta_10300803603000;
                current.Total10300803603000 = 0;
                if (current.cta_10300803603010 != null)
                    current.Total10300803603000 += (Decimal)current.cta_10300803603010;
                if (current.cta_10300803603020 != null)
                    current.Total10300803603000 += (Decimal)current.cta_10300803603020;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803600000;
                current.Total10300803600000 = 0;
                if (current.cta_10300803601000 != null && current.cta_10300803601000.Total10300803601000 != 0)
                    current.Total10300803600000 += (Decimal)current.cta_10300803601000.Total10300803601000;
                if (current.cta_10300803602000 != null && current.cta_10300803602000.Total10300803602000 != 0)
                    current.Total10300803600000 += (Decimal)current.cta_10300803602000.Total10300803602000;
                if (current.cta_10300803603000 != null && current.cta_10300803603000.Total10300803603000 != 0)
                    current.Total10300803600000 += (Decimal)current.cta_10300803603000.Total10300803603000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.cta_10300803701000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.cta_10300803701000;
                current.Total10300803701000 = 0;
                if (current.cta_10300803701010 != null)
                    current.Total10300803701000 += (Decimal)current.cta_10300803701010;
                if (current.cta_10300803701020 != null)
                    current.Total10300803701000 += (Decimal)current.cta_10300803701020;
                if (current.cta_10300803701100 != null)
                    current.Total10300803701000 += (Decimal)current.cta_10300803701100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.cta_10300803702000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.cta_10300803702000;
                current.Total10300803702000 = 0;
                if (current.cta_10300803702010 != null)
                    current.Total10300803702000 += (Decimal)current.cta_10300803702010;
                if (current.cta_10300803702020 != null)
                    current.Total10300803702000 += (Decimal)current.cta_10300803702020;
                if (current.cta_10300803702100 != null)
                    current.Total10300803702000 += (Decimal)current.cta_10300803702100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.cta_10300803703000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000.cta_10300803703000;
                current.Total10300803703000 = 0;
                if (current.cta_10300803703010 != null)
                    current.Total10300803703000 += (Decimal)current.cta_10300803703010;
                if (current.cta_10300803703020 != null)
                    current.Total10300803703000 += (Decimal)current.cta_10300803703020;
                if (current.cta_10300803703100 != null)
                    current.Total10300803703000 += (Decimal)current.cta_10300803703100;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300803700000;
                current.Total10300803700000 = 0;
                if (current.cta_10300803701000 != null && current.cta_10300803701000.Total10300803701000 != 0)
                    current.Total10300803700000 += (Decimal)current.cta_10300803701000.Total10300803701000;
                if (current.cta_10300803702000 != null && current.cta_10300803702000.Total10300803702000 != 0)
                    current.Total10300803700000 += (Decimal)current.cta_10300803702000.Total10300803702000;
                if (current.cta_10300803703000 != null && current.cta_10300803703000.Total10300803703000 != 0)
                    current.Total10300803700000 += (Decimal)current.cta_10300803703000.Total10300803703000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300804100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000.cta_10300804100000;
                current.Total10300804100000 = 0;
                if (current.cta_10300804101000 != null)
                    current.Total10300804100000 += (Decimal)current.cta_10300804101000;
                if (current.cta_10300804102000 != null)
                    current.Total10300804100000 += (Decimal)current.cta_10300804102000;
                if (current.cta_10300804103000 != null)
                    current.Total10300804100000 += (Decimal)current.cta_10300804103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300800000000;
                current.Total10300800000000 = 0;
                if (current.cta_10300803100000 != null && current.cta_10300803100000.Total10300803100000 != 0)
                    current.Total10300800000000 += (Decimal)current.cta_10300803100000.Total10300803100000;
                if (current.cta_10300803400000 != null && current.cta_10300803400000.Total10300803400000 != 0)
                    current.Total10300800000000 += (Decimal)current.cta_10300803400000.Total10300803400000;
                if (current.cta_10300803500000 != null && current.cta_10300803500000.Total10300803500000 != 0)
                    current.Total10300800000000 += (Decimal)current.cta_10300803500000.Total10300803500000;
                if (current.cta_10300803600000 != null && current.cta_10300803600000.Total10300803600000 != 0)
                    current.Total10300800000000 += (Decimal)current.cta_10300803600000.Total10300803600000;
                if (current.cta_10300803700000 != null && current.cta_10300803700000.Total10300803700000 != 0)
                    current.Total10300800000000 += (Decimal)current.cta_10300803700000.Total10300803700000;
                if (current.cta_10300804100000 != null && current.cta_10300804100000.Total10300804100000 != 0)
                    current.Total10300800000000 += (Decimal)current.cta_10300804100000.Total10300804100000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900100000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900100000;
                current.Total10300900100000 = 0;
                if (current.cta_10300900101000 != null)
                    current.Total10300900100000 += (Decimal)current.cta_10300900101000;
                if (current.cta_10300900102000 != null)
                    current.Total10300900100000 += (Decimal)current.cta_10300900102000;
                if (current.cta_10300900103000 != null)
                    current.Total10300900100000 += (Decimal)current.cta_10300900103000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.cta_10300900201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.cta_10300900201000;
                current.Total10300900201000 = 0;
                if (current.cta_10300900201010 != null)
                    current.Total10300900201000 += (Decimal)current.cta_10300900201010;
                if (current.cta_10300900201020 != null)
                    current.Total10300900201000 += (Decimal)current.cta_10300900201020;
                if (current.cta_10300900201040 != null)
                    current.Total10300900201000 += (Decimal)current.cta_10300900201040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.cta_10300900202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.cta_10300900202000;
                current.Total10300900202000 = 0;
                if (current.cta_10300900202010 != null)
                    current.Total10300900202000 += (Decimal)current.cta_10300900202010;
                if (current.cta_10300900202020 != null)
                    current.Total10300900202000 += (Decimal)current.cta_10300900202020;
                if (current.cta_10300900202040 != null)
                    current.Total10300900202000 += (Decimal)current.cta_10300900202040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.cta_10300900203000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000.cta_10300900203000;
                current.Total10300900203000 = 0;
                if (current.cta_10300900203010 != null)
                    current.Total10300900203000 += (Decimal)current.cta_10300900203010;
                if (current.cta_10300900203020 != null)
                    current.Total10300900203000 += (Decimal)current.cta_10300900203020;
                if (current.cta_10300900203040 != null)
                    current.Total10300900203000 += (Decimal)current.cta_10300900203040;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300900200000;
                current.Total10300900200000 = 0;
                if (current.cta_10300900201000 != null && current.cta_10300900201000.Total10300900201000 != 0)
                    current.Total10300900200000 += (Decimal)current.cta_10300900201000.Total10300900201000;
                if (current.cta_10300900202000 != null && current.cta_10300900202000.Total10300900202000 != 0)
                    current.Total10300900200000 += (Decimal)current.cta_10300900202000.Total10300900202000;
                if (current.cta_10300900203000 != null && current.cta_10300900203000.Total10300900203000 != 0)
                    current.Total10300900200000 += (Decimal)current.cta_10300900203000.Total10300900203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300901000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300901000000;
                current.Total10300901000000 = 0;
                if (current.cta_10300901001000 != null)
                    current.Total10300901000000 += (Decimal)current.cta_10300901001000;
                if (current.cta_10300901002000 != null)
                    current.Total10300901000000 += (Decimal)current.cta_10300901002000;
                if (current.cta_10300901003000 != null)
                    current.Total10300901000000 += (Decimal)current.cta_10300901003000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.cta_10300905201000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.cta_10300905201000;
                current.Total10300905201000 = 0;
                if (current.cta_10300905201010 != null)
                    current.Total10300905201000 += (Decimal)current.cta_10300905201010;
                if (current.cta_10300905201020 != null)
                    current.Total10300905201000 += (Decimal)current.cta_10300905201020;
                if (current.cta_10300905201030 != null)
                    current.Total10300905201000 += (Decimal)current.cta_10300905201030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.cta_10300905202000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.cta_10300905202000;
                current.Total10300905202000 = 0;
                if (current.cta_10300905202010 != null)
                    current.Total10300905202000 += (Decimal)current.cta_10300905202010;
                if (current.cta_10300905202020 != null)
                    current.Total10300905202000 += (Decimal)current.cta_10300905202020;
                if (current.cta_10300905202030 != null)
                    current.Total10300905202000 += (Decimal)current.cta_10300905202030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.cta_10300905203000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000.cta_10300905203000;
                current.Total10300905203000 = 0;
                if (current.cta_10300905203010 != null)
                    current.Total10300905203000 += (Decimal)current.cta_10300905203010;
                if (current.cta_10300905203020 != null)
                    current.Total10300905203000 += (Decimal)current.cta_10300905203020;
                if (current.cta_10300905203030 != null)
                    current.Total10300905203000 += (Decimal)current.cta_10300905203030;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000.cta_10300905200000;
                current.Total10300905200000 = 0;
                if (current.cta_10300905201000 != null && current.cta_10300905201000.Total10300905201000 != 0)
                    current.Total10300905200000 += (Decimal)current.cta_10300905201000.Total10300905201000;
                if (current.cta_10300905202000 != null && current.cta_10300905202000.Total10300905202000 != 0)
                    current.Total10300905200000 += (Decimal)current.cta_10300905202000.Total10300905202000;
                if (current.cta_10300905203000 != null && current.cta_10300905203000.Total10300905203000 != 0)
                    current.Total10300905200000 += (Decimal)current.cta_10300905203000.Total10300905203000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null && modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000.cta_10300900000000;
                current.Total10300900000000 = 0;
                if (current.cta_10300900100000 != null && current.cta_10300900100000.Total10300900100000 != 0)
                    current.Total10300900000000 += (Decimal)current.cta_10300900100000.Total10300900100000;
                if (current.cta_10300900200000 != null && current.cta_10300900200000.Total10300900200000 != 0)
                    current.Total10300900000000 += (Decimal)current.cta_10300900200000.Total10300900200000;
                if (current.cta_10300901000000 != null && current.cta_10300901000000.Total10300901000000 != 0)
                    current.Total10300900000000 += (Decimal)current.cta_10300901000000.Total10300901000000;
                if (current.cta_10300905200000 != null && current.cta_10300905200000.Total10300905200000 != 0)
                    current.Total10300900000000 += (Decimal)current.cta_10300905200000.Total10300905200000;
            }
            if (modelo.cta_10000000000000 != null && modelo.cta_10000000000000.cta_10300000000000 != null)
            {
                var current = modelo.cta_10000000000000.cta_10300000000000;
                current.Total10300000000000 = 0;
                if (current.cta_10300100000000 != null && current.cta_10300100000000.Total10300100000000 != 0)
                    current.Total10300000000000 += (Decimal)current.cta_10300100000000.Total10300100000000;
                if (current.cta_10300200000000 != null && current.cta_10300200000000.Total10300200000000 != 0)
                    current.Total10300000000000 += (Decimal)current.cta_10300200000000.Total10300200000000;
                if (current.cta_10300300000000 != null && current.cta_10300300000000.Total10300300000000 != 0)
                    current.Total10300000000000 += (Decimal)current.cta_10300300000000.Total10300300000000;
                if (current.cta_10300400000000 != null && current.cta_10300400000000.Total10300400000000 != 0)
                    current.Total10300000000000 += (Decimal)current.cta_10300400000000.Total10300400000000;
                if (current.cta_10300600000000 != null && current.cta_10300600000000.Total10300600000000 != 0)
                    current.Total10300000000000 += (Decimal)current.cta_10300600000000.Total10300600000000;
                if (current.cta_10300700000000 != null && current.cta_10300700000000.Total10300700000000 != 0)
                    current.Total10300000000000 += (Decimal)current.cta_10300700000000.Total10300700000000;
                if (current.cta_10300800000000 != null && current.cta_10300800000000.Total10300800000000 != 0)
                    current.Total10300000000000 += (Decimal)current.cta_10300800000000.Total10300800000000;
                if (current.cta_10300900000000 != null && current.cta_10300900000000.Total10300900000000 != 0)
                    current.Total10300000000000 += (Decimal)current.cta_10300900000000.Total10300900000000;
            }

        }

    }
}
