using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.Sugese.SaldosContables.Domain.Application.Total
{
    internal class TotalCuenta5
    {
        public static void Mapper(string account, Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModelo modelo, System.Nullable<decimal> value, bool specified)
        {

            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50101000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50101000000000.cta_50101000100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50101000000000.cta_50101000100000;
                current.Total50101000100000 = 0;
                if (current.cta_50101000101000 != null)
                    current.Total50101000100000 += (Decimal)current.cta_50101000101000;
                if (current.cta_50101000102000 != null)
                    current.Total50101000100000 += (Decimal)current.cta_50101000102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50101000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50101000000000.cta_50101000200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50101000000000.cta_50101000200000;
                current.Total50101000200000 = 0;
                if (current.cta_50101000201000 != null)
                    current.Total50101000200000 += (Decimal)current.cta_50101000201000;
                if (current.cta_50101000202000 != null)
                    current.Total50101000200000 += (Decimal)current.cta_50101000202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50101000000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50101000000000;
                current.Total50101000000000 = 0;
                if (current.cta_50101000100000 != null && current.cta_50101000100000.Total50101000100000 != 0)
                    current.Total50101000000000 += (Decimal)current.cta_50101000100000.Total50101000100000;
                if (current.cta_50101000200000 != null && current.cta_50101000200000.Total50101000200000 != 0)
                    current.Total50101000000000 += (Decimal)current.cta_50101000200000.Total50101000200000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50102000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50102000000000.cta_50102000100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50102000000000.cta_50102000100000;
                current.Total50102000100000 = 0;
                if (current.cta_50102000101000 != null)
                    current.Total50102000100000 += (Decimal)current.cta_50102000101000;
                if (current.cta_50102000102000 != null)
                    current.Total50102000100000 += (Decimal)current.cta_50102000102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50102000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50102000000000.cta_50102000200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50102000000000.cta_50102000200000;
                current.Total50102000200000 = 0;
                if (current.cta_50102000201000 != null)
                    current.Total50102000200000 += (Decimal)current.cta_50102000201000;
                if (current.cta_50102000202000 != null)
                    current.Total50102000200000 += (Decimal)current.cta_50102000202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50102000000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50102000000000;
                current.Total50102000000000 = 0;
                if (current.cta_50102000100000 != null && current.cta_50102000100000.Total50102000100000 != 0)
                    current.Total50102000000000 += (Decimal)current.cta_50102000100000.Total50102000100000;
                if (current.cta_50102000200000 != null && current.cta_50102000200000.Total50102000200000 != 0)
                    current.Total50102000000000 += (Decimal)current.cta_50102000200000.Total50102000200000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000.cta_50100100200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000.cta_50100100200000;
                current.Total50100100200000 = 0;
                if (current.cta_50100100201000 != null)
                    current.Total50100100200000 += (Decimal)current.cta_50100100201000;
                if (current.cta_50100100202000 != null)
                    current.Total50100100200000 += (Decimal)current.cta_50100100202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000.cta_50100100300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000.cta_50100100300000;
                current.Total50100100300000 = 0;
                if (current.cta_50100100301000 != null)
                    current.Total50100100300000 += (Decimal)current.cta_50100100301000;
                if (current.cta_50100100302000 != null)
                    current.Total50100100300000 += (Decimal)current.cta_50100100302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000.cta_50100100400000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000.cta_50100100400000;
                current.Total50100100400000 = 0;
                if (current.cta_50100100401000 != null)
                    current.Total50100100400000 += (Decimal)current.cta_50100100401000;
                if (current.cta_50100100402000 != null)
                    current.Total50100100400000 += (Decimal)current.cta_50100100402000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000.cta_50100100600000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000.cta_50100100600000;
                current.Total50100100600000 = 0;
                if (current.cta_50100100601000 != null)
                    current.Total50100100600000 += (Decimal)current.cta_50100100601000;
                if (current.cta_50100100602000 != null)
                    current.Total50100100600000 += (Decimal)current.cta_50100100602000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000.cta_50100109900000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000.cta_50100109900000;
                current.Total50100109900000 = 0;
                if (current.cta_50100109901000 != null)
                    current.Total50100109900000 += (Decimal)current.cta_50100109901000;
                if (current.cta_50100109902000 != null)
                    current.Total50100109900000 += (Decimal)current.cta_50100109902000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100100000000;
                current.Total50100100000000 = 0;
                if (current.cta_50100100200000 != null && current.cta_50100100200000.Total50100100200000 != 0)
                    current.Total50100100000000 += (Decimal)current.cta_50100100200000.Total50100100200000;
                if (current.cta_50100100300000 != null && current.cta_50100100300000.Total50100100300000 != 0)
                    current.Total50100100000000 += (Decimal)current.cta_50100100300000.Total50100100300000;
                if (current.cta_50100100400000 != null && current.cta_50100100400000.Total50100100400000 != 0)
                    current.Total50100100000000 += (Decimal)current.cta_50100100400000.Total50100100400000;
                if (current.cta_50100100600000 != null && current.cta_50100100600000.Total50100100600000 != 0)
                    current.Total50100100000000 += (Decimal)current.cta_50100100600000.Total50100100600000;
                if (current.cta_50100109900000 != null && current.cta_50100109900000.Total50100109900000 != 0)
                    current.Total50100100000000 += (Decimal)current.cta_50100109900000.Total50100109900000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200100000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200100000.cta_50100200101000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200100000.cta_50100200101000;
                current.Total50100200101000 = 0;
                if (current.cta_50100200101010 != null)
                    current.Total50100200101000 += (Decimal)current.cta_50100200101010;
                if (current.cta_50100200101020 != null)
                    current.Total50100200101000 += (Decimal)current.cta_50100200101020;
                if (current.cta_50100200101030 != null)
                    current.Total50100200101000 += (Decimal)current.cta_50100200101030;
                if (current.cta_50100200101040 != null)
                    current.Total50100200101000 += (Decimal)current.cta_50100200101040;
                if (current.cta_50100200101050 != null)
                    current.Total50100200101000 += (Decimal)current.cta_50100200101050;
                if (current.cta_50100200101060 != null)
                    current.Total50100200101000 += (Decimal)current.cta_50100200101060;
                if (current.cta_50100200101070 != null)
                    current.Total50100200101000 += (Decimal)current.cta_50100200101070;
                if (current.cta_50100200101080 != null)
                    current.Total50100200101000 += (Decimal)current.cta_50100200101080;
                if (current.cta_50100200101090 != null)
                    current.Total50100200101000 += (Decimal)current.cta_50100200101090;
                if (current.cta_50100200101100 != null)
                    current.Total50100200101000 += (Decimal)current.cta_50100200101100;
                if (current.cta_50100200101990 != null)
                    current.Total50100200101000 += (Decimal)current.cta_50100200101990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200100000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200100000.cta_50100200102000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200100000.cta_50100200102000;
                current.Total50100200102000 = 0;
                if (current.cta_50100200102010 != null)
                    current.Total50100200102000 += (Decimal)current.cta_50100200102010;
                if (current.cta_50100200102020 != null)
                    current.Total50100200102000 += (Decimal)current.cta_50100200102020;
                if (current.cta_50100200102030 != null)
                    current.Total50100200102000 += (Decimal)current.cta_50100200102030;
                if (current.cta_50100200102040 != null)
                    current.Total50100200102000 += (Decimal)current.cta_50100200102040;
                if (current.cta_50100200102050 != null)
                    current.Total50100200102000 += (Decimal)current.cta_50100200102050;
                if (current.cta_50100200102060 != null)
                    current.Total50100200102000 += (Decimal)current.cta_50100200102060;
                if (current.cta_50100200102070 != null)
                    current.Total50100200102000 += (Decimal)current.cta_50100200102070;
                if (current.cta_50100200102080 != null)
                    current.Total50100200102000 += (Decimal)current.cta_50100200102080;
                if (current.cta_50100200102090 != null)
                    current.Total50100200102000 += (Decimal)current.cta_50100200102090;
                if (current.cta_50100200102100 != null)
                    current.Total50100200102000 += (Decimal)current.cta_50100200102100;
                if (current.cta_50100200102990 != null)
                    current.Total50100200102000 += (Decimal)current.cta_50100200102990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200100000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200100000.cta_50100200103000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200100000.cta_50100200103000;
                current.Total50100200103000 = 0;
                if (current.cta_50100200103010 != null)
                    current.Total50100200103000 += (Decimal)current.cta_50100200103010;
                if (current.cta_50100200103020 != null)
                    current.Total50100200103000 += (Decimal)current.cta_50100200103020;
                if (current.cta_50100200103030 != null)
                    current.Total50100200103000 += (Decimal)current.cta_50100200103030;
                if (current.cta_50100200103040 != null)
                    current.Total50100200103000 += (Decimal)current.cta_50100200103040;
                if (current.cta_50100200103050 != null)
                    current.Total50100200103000 += (Decimal)current.cta_50100200103050;
                if (current.cta_50100200103060 != null)
                    current.Total50100200103000 += (Decimal)current.cta_50100200103060;
                if (current.cta_50100200103070 != null)
                    current.Total50100200103000 += (Decimal)current.cta_50100200103070;
                if (current.cta_50100200103080 != null)
                    current.Total50100200103000 += (Decimal)current.cta_50100200103080;
                if (current.cta_50100200103090 != null)
                    current.Total50100200103000 += (Decimal)current.cta_50100200103090;
                if (current.cta_50100200103100 != null)
                    current.Total50100200103000 += (Decimal)current.cta_50100200103100;
                if (current.cta_50100200103990 != null)
                    current.Total50100200103000 += (Decimal)current.cta_50100200103990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200100000;
                current.Total50100200100000 = 0;
                if (current.cta_50100200101000 != null && current.cta_50100200101000.Total50100200101000 != 0)
                    current.Total50100200100000 += (Decimal)current.cta_50100200101000.Total50100200101000;
                if (current.cta_50100200102000 != null && current.cta_50100200102000.Total50100200102000 != 0)
                    current.Total50100200100000 += (Decimal)current.cta_50100200102000.Total50100200102000;
                if (current.cta_50100200103000 != null && current.cta_50100200103000.Total50100200103000 != 0)
                    current.Total50100200100000 += (Decimal)current.cta_50100200103000.Total50100200103000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200200000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200200000.cta_50100200201000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200200000.cta_50100200201000;
                current.Total50100200201000 = 0;
                if (current.cta_50100200201010 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201010;
                if (current.cta_50100200201020 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201020;
                if (current.cta_50100200201030 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201030;
                if (current.cta_50100200201050 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201050;
                if (current.cta_50100200201060 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201060;
                if (current.cta_50100200201070 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201070;
                if (current.cta_50100200201080 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201080;
                if (current.cta_50100200201090 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201090;
                if (current.cta_50100200201100 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201100;
                if (current.cta_50100200201110 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201110;
                if (current.cta_50100200201120 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201120;
                if (current.cta_50100200201130 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201130;
                if (current.cta_50100200201140 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201140;
                if (current.cta_50100200201150 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201150;
                if (current.cta_50100200201510 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201510;
                if (current.cta_50100200201520 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201520;
                if (current.cta_50100200201530 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201530;
                if (current.cta_50100200201550 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201550;
                if (current.cta_50100200201560 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201560;
                if (current.cta_50100200201570 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201570;
                if (current.cta_50100200201580 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201580;
                if (current.cta_50100200201590 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201590;
                if (current.cta_50100200201600 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201600;
                if (current.cta_50100200201610 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201610;
                if (current.cta_50100200201620 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201620;
                if (current.cta_50100200201630 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201630;
                if (current.cta_50100200201640 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201640;
                if (current.cta_50100200201650 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201650;
                if (current.cta_50100200201660 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201660;
                if (current.cta_50100200201670 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201670;
                if (current.cta_50100200201700 != null)
                    current.Total50100200201000 += (Decimal)current.cta_50100200201700;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200200000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200200000.cta_50100200202000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200200000.cta_50100200202000;
                current.Total50100200202000 = 0;
                if (current.cta_50100200202010 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202010;
                if (current.cta_50100200202020 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202020;
                if (current.cta_50100200202030 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202030;
                if (current.cta_50100200202050 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202050;
                if (current.cta_50100200202060 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202060;
                if (current.cta_50100200202070 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202070;
                if (current.cta_50100200202080 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202080;
                if (current.cta_50100200202090 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202090;
                if (current.cta_50100200202100 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202100;
                if (current.cta_50100200202110 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202110;
                if (current.cta_50100200202120 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202120;
                if (current.cta_50100200202130 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202130;
                if (current.cta_50100200202140 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202140;
                if (current.cta_50100200202150 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202150;
                if (current.cta_50100200202510 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202510;
                if (current.cta_50100200202520 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202520;
                if (current.cta_50100200202530 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202530;
                if (current.cta_50100200202550 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202550;
                if (current.cta_50100200202560 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202560;
                if (current.cta_50100200202570 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202570;
                if (current.cta_50100200202580 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202580;
                if (current.cta_50100200202590 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202590;
                if (current.cta_50100200202600 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202600;
                if (current.cta_50100200202610 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202610;
                if (current.cta_50100200202620 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202620;
                if (current.cta_50100200202630 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202630;
                if (current.cta_50100200202640 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202640;
                if (current.cta_50100200202650 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202650;
                if (current.cta_50100200202660 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202660;
                if (current.cta_50100200202670 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202670;
                if (current.cta_50100200202700 != null)
                    current.Total50100200202000 += (Decimal)current.cta_50100200202700;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200200000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200200000.cta_50100200203000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200200000.cta_50100200203000;
                current.Total50100200203000 = 0;
                if (current.cta_50100200203010 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203010;
                if (current.cta_50100200203020 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203020;
                if (current.cta_50100200203030 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203030;
                if (current.cta_50100200203050 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203050;
                if (current.cta_50100200203060 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203060;
                if (current.cta_50100200203070 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203070;
                if (current.cta_50100200203080 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203080;
                if (current.cta_50100200203090 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203090;
                if (current.cta_50100200203100 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203100;
                if (current.cta_50100200203110 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203110;
                if (current.cta_50100200203120 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203120;
                if (current.cta_50100200203130 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203130;
                if (current.cta_50100200203140 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203140;
                if (current.cta_50100200203150 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203150;
                if (current.cta_50100200203510 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203510;
                if (current.cta_50100200203520 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203520;
                if (current.cta_50100200203530 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203530;
                if (current.cta_50100200203550 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203550;
                if (current.cta_50100200203560 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203560;
                if (current.cta_50100200203570 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203570;
                if (current.cta_50100200203580 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203580;
                if (current.cta_50100200203590 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203590;
                if (current.cta_50100200203600 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203600;
                if (current.cta_50100200203610 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203610;
                if (current.cta_50100200203620 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203620;
                if (current.cta_50100200203630 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203630;
                if (current.cta_50100200203640 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203640;
                if (current.cta_50100200203650 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203650;
                if (current.cta_50100200203660 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203660;
                if (current.cta_50100200203670 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203670;
                if (current.cta_50100200203700 != null)
                    current.Total50100200203000 += (Decimal)current.cta_50100200203700;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200200000;
                current.Total50100200200000 = 0;
                if (current.cta_50100200201000 != null && current.cta_50100200201000.Total50100200201000 != 0)
                    current.Total50100200200000 += (Decimal)current.cta_50100200201000.Total50100200201000;
                if (current.cta_50100200202000 != null && current.cta_50100200202000.Total50100200202000 != 0)
                    current.Total50100200200000 += (Decimal)current.cta_50100200202000.Total50100200202000;
                if (current.cta_50100200203000 != null && current.cta_50100200203000.Total50100200203000 != 0)
                    current.Total50100200200000 += (Decimal)current.cta_50100200203000.Total50100200203000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200300000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200300000.cta_50100200301000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200300000.cta_50100200301000;
                current.Total50100200301000 = 0;
                if (current.cta_50100200301010 != null)
                    current.Total50100200301000 += (Decimal)current.cta_50100200301010;
                if (current.cta_50100200301020 != null)
                    current.Total50100200301000 += (Decimal)current.cta_50100200301020;
                if (current.cta_50100200301030 != null)
                    current.Total50100200301000 += (Decimal)current.cta_50100200301030;
                if (current.cta_50100200301040 != null)
                    current.Total50100200301000 += (Decimal)current.cta_50100200301040;
                if (current.cta_50100200301050 != null)
                    current.Total50100200301000 += (Decimal)current.cta_50100200301050;
                if (current.cta_50100200301060 != null)
                    current.Total50100200301000 += (Decimal)current.cta_50100200301060;
                if (current.cta_50100200301070 != null)
                    current.Total50100200301000 += (Decimal)current.cta_50100200301070;
                if (current.cta_50100200301080 != null)
                    current.Total50100200301000 += (Decimal)current.cta_50100200301080;
                if (current.cta_50100200301090 != null)
                    current.Total50100200301000 += (Decimal)current.cta_50100200301090;
                if (current.cta_50100200301100 != null)
                    current.Total50100200301000 += (Decimal)current.cta_50100200301100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200300000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200300000.cta_50100200302000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200300000.cta_50100200302000;
                current.Total50100200302000 = 0;
                if (current.cta_50100200302010 != null)
                    current.Total50100200302000 += (Decimal)current.cta_50100200302010;
                if (current.cta_50100200302020 != null)
                    current.Total50100200302000 += (Decimal)current.cta_50100200302020;
                if (current.cta_50100200302030 != null)
                    current.Total50100200302000 += (Decimal)current.cta_50100200302030;
                if (current.cta_50100200302040 != null)
                    current.Total50100200302000 += (Decimal)current.cta_50100200302040;
                if (current.cta_50100200302050 != null)
                    current.Total50100200302000 += (Decimal)current.cta_50100200302050;
                if (current.cta_50100200302060 != null)
                    current.Total50100200302000 += (Decimal)current.cta_50100200302060;
                if (current.cta_50100200302070 != null)
                    current.Total50100200302000 += (Decimal)current.cta_50100200302070;
                if (current.cta_50100200302080 != null)
                    current.Total50100200302000 += (Decimal)current.cta_50100200302080;
                if (current.cta_50100200302090 != null)
                    current.Total50100200302000 += (Decimal)current.cta_50100200302090;
                if (current.cta_50100200302100 != null)
                    current.Total50100200302000 += (Decimal)current.cta_50100200302100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200300000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200300000.cta_50100200303000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200300000.cta_50100200303000;
                current.Total50100200303000 = 0;
                if (current.cta_50100200303010 != null)
                    current.Total50100200303000 += (Decimal)current.cta_50100200303010;
                if (current.cta_50100200303020 != null)
                    current.Total50100200303000 += (Decimal)current.cta_50100200303020;
                if (current.cta_50100200303030 != null)
                    current.Total50100200303000 += (Decimal)current.cta_50100200303030;
                if (current.cta_50100200303040 != null)
                    current.Total50100200303000 += (Decimal)current.cta_50100200303040;
                if (current.cta_50100200303050 != null)
                    current.Total50100200303000 += (Decimal)current.cta_50100200303050;
                if (current.cta_50100200303060 != null)
                    current.Total50100200303000 += (Decimal)current.cta_50100200303060;
                if (current.cta_50100200303070 != null)
                    current.Total50100200303000 += (Decimal)current.cta_50100200303070;
                if (current.cta_50100200303080 != null)
                    current.Total50100200303000 += (Decimal)current.cta_50100200303080;
                if (current.cta_50100200303090 != null)
                    current.Total50100200303000 += (Decimal)current.cta_50100200303090;
                if (current.cta_50100200303100 != null)
                    current.Total50100200303000 += (Decimal)current.cta_50100200303100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200300000;
                current.Total50100200300000 = 0;
                if (current.cta_50100200301000 != null && current.cta_50100200301000.Total50100200301000 != 0)
                    current.Total50100200300000 += (Decimal)current.cta_50100200301000.Total50100200301000;
                if (current.cta_50100200302000 != null && current.cta_50100200302000.Total50100200302000 != 0)
                    current.Total50100200300000 += (Decimal)current.cta_50100200302000.Total50100200302000;
                if (current.cta_50100200303000 != null && current.cta_50100200303000.Total50100200303000 != 0)
                    current.Total50100200300000 += (Decimal)current.cta_50100200303000.Total50100200303000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200400000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200400000.cta_50100200401000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200400000.cta_50100200401000;
                current.Total50100200401000 = 0;
                if (current.cta_50100200401010 != null)
                    current.Total50100200401000 += (Decimal)current.cta_50100200401010;
                if (current.cta_50100200401020 != null)
                    current.Total50100200401000 += (Decimal)current.cta_50100200401020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200400000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200400000.cta_50100200402000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200400000.cta_50100200402000;
                current.Total50100200402000 = 0;
                if (current.cta_50100200402010 != null)
                    current.Total50100200402000 += (Decimal)current.cta_50100200402010;
                if (current.cta_50100200402020 != null)
                    current.Total50100200402000 += (Decimal)current.cta_50100200402020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200400000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200400000.cta_50100200403000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200400000.cta_50100200403000;
                current.Total50100200403000 = 0;
                if (current.cta_50100200403010 != null)
                    current.Total50100200403000 += (Decimal)current.cta_50100200403010;
                if (current.cta_50100200403020 != null)
                    current.Total50100200403000 += (Decimal)current.cta_50100200403020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200400000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200400000;
                current.Total50100200400000 = 0;
                if (current.cta_50100200401000 != null && current.cta_50100200401000.Total50100200401000 != 0)
                    current.Total50100200400000 += (Decimal)current.cta_50100200401000.Total50100200401000;
                if (current.cta_50100200402000 != null && current.cta_50100200402000.Total50100200402000 != 0)
                    current.Total50100200400000 += (Decimal)current.cta_50100200402000.Total50100200402000;
                if (current.cta_50100200403000 != null && current.cta_50100200403000.Total50100200403000 != 0)
                    current.Total50100200400000 += (Decimal)current.cta_50100200403000.Total50100200403000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200500000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200500000.cta_50100200501000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200500000.cta_50100200501000;
                current.Total50100200501000 = 0;
                if (current.cta_50100200501040 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501040;
                if (current.cta_50100200501050 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501050;
                if (current.cta_50100200501119 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501119;
                if (current.cta_50100200501120 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501120;
                if (current.cta_50100200501121 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501121;
                if (current.cta_50100200501122 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501122;
                if (current.cta_50100200501123 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501123;
                if (current.cta_50100200501124 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501124;
                if (current.cta_50100200501127 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501127;
                if (current.cta_50100200501128 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501128;
                if (current.cta_50100200501130 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501130;
                if (current.cta_50100200501133 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501133;
                if (current.cta_50100200501135 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501135;
                if (current.cta_50100200501136 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501136;
                if (current.cta_50100200501137 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501137;
                if (current.cta_50100200501138 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501138;
                if (current.cta_50100200501198 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501198;
                if (current.cta_50100200501199 != null)
                    current.Total50100200501000 += (Decimal)current.cta_50100200501199;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200500000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200500000.cta_50100200502000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200500000.cta_50100200502000;
                current.Total50100200502000 = 0;
                if (current.cta_50100200502040 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502040;
                if (current.cta_50100200502050 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502050;
                if (current.cta_50100200502119 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502119;
                if (current.cta_50100200502120 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502120;
                if (current.cta_50100200502121 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502121;
                if (current.cta_50100200502122 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502122;
                if (current.cta_50100200502123 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502123;
                if (current.cta_50100200502124 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502124;
                if (current.cta_50100200502127 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502127;
                if (current.cta_50100200502128 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502128;
                if (current.cta_50100200502130 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502130;
                if (current.cta_50100200502133 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502133;
                if (current.cta_50100200502135 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502135;
                if (current.cta_50100200502136 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502136;
                if (current.cta_50100200502137 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502137;
                if (current.cta_50100200502138 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502138;
                if (current.cta_50100200502198 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502198;
                if (current.cta_50100200502199 != null)
                    current.Total50100200502000 += (Decimal)current.cta_50100200502199;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200500000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200500000.cta_50100200503000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200500000.cta_50100200503000;
                current.Total50100200503000 = 0;
                if (current.cta_50100200503040 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503040;
                if (current.cta_50100200503050 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503050;
                if (current.cta_50100200503119 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503119;
                if (current.cta_50100200503120 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503120;
                if (current.cta_50100200503121 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503121;
                if (current.cta_50100200503122 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503122;
                if (current.cta_50100200503123 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503123;
                if (current.cta_50100200503124 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503124;
                if (current.cta_50100200503127 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503127;
                if (current.cta_50100200503128 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503128;
                if (current.cta_50100200503130 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503130;
                if (current.cta_50100200503133 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503133;
                if (current.cta_50100200503135 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503135;
                if (current.cta_50100200503136 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503136;
                if (current.cta_50100200503137 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503137;
                if (current.cta_50100200503138 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503138;
                if (current.cta_50100200503198 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503198;
                if (current.cta_50100200503199 != null)
                    current.Total50100200503000 += (Decimal)current.cta_50100200503199;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200500000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200500000;
                current.Total50100200500000 = 0;
                if (current.cta_50100200501000 != null && current.cta_50100200501000.Total50100200501000 != 0)
                    current.Total50100200500000 += (Decimal)current.cta_50100200501000.Total50100200501000;
                if (current.cta_50100200502000 != null && current.cta_50100200502000.Total50100200502000 != 0)
                    current.Total50100200500000 += (Decimal)current.cta_50100200502000.Total50100200502000;
                if (current.cta_50100200503000 != null && current.cta_50100200503000.Total50100200503000 != 0)
                    current.Total50100200500000 += (Decimal)current.cta_50100200503000.Total50100200503000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200600000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200600000.cta_50100200601000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200600000.cta_50100200601000;
                current.Total50100200601000 = 0;
                if (current.cta_50100200601080 != null)
                    current.Total50100200601000 += (Decimal)current.cta_50100200601080;
                if (current.cta_50100200601090 != null)
                    current.Total50100200601000 += (Decimal)current.cta_50100200601090;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200600000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200600000.cta_50100200602000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200600000.cta_50100200602000;
                current.Total50100200602000 = 0;
                if (current.cta_50100200602080 != null)
                    current.Total50100200602000 += (Decimal)current.cta_50100200602080;
                if (current.cta_50100200602090 != null)
                    current.Total50100200602000 += (Decimal)current.cta_50100200602090;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200600000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200600000.cta_50100200603000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200600000.cta_50100200603000;
                current.Total50100200603000 = 0;
                if (current.cta_50100200603080 != null)
                    current.Total50100200603000 += (Decimal)current.cta_50100200603080;
                if (current.cta_50100200603090 != null)
                    current.Total50100200603000 += (Decimal)current.cta_50100200603090;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200600000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000.cta_50100200600000;
                current.Total50100200600000 = 0;
                if (current.cta_50100200601000 != null && current.cta_50100200601000.Total50100200601000 != 0)
                    current.Total50100200600000 += (Decimal)current.cta_50100200601000.Total50100200601000;
                if (current.cta_50100200602000 != null && current.cta_50100200602000.Total50100200602000 != 0)
                    current.Total50100200600000 += (Decimal)current.cta_50100200602000.Total50100200602000;
                if (current.cta_50100200603000 != null && current.cta_50100200603000.Total50100200603000 != 0)
                    current.Total50100200600000 += (Decimal)current.cta_50100200603000.Total50100200603000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100200000000;
                current.Total50100200000000 = 0;
                if (current.cta_50100200100000 != null && current.cta_50100200100000.Total50100200100000 != 0)
                    current.Total50100200000000 += (Decimal)current.cta_50100200100000.Total50100200100000;
                if (current.cta_50100200200000 != null && current.cta_50100200200000.Total50100200200000 != 0)
                    current.Total50100200000000 += (Decimal)current.cta_50100200200000.Total50100200200000;
                if (current.cta_50100200300000 != null && current.cta_50100200300000.Total50100200300000 != 0)
                    current.Total50100200000000 += (Decimal)current.cta_50100200300000.Total50100200300000;
                if (current.cta_50100200400000 != null && current.cta_50100200400000.Total50100200400000 != 0)
                    current.Total50100200000000 += (Decimal)current.cta_50100200400000.Total50100200400000;
                if (current.cta_50100200500000 != null && current.cta_50100200500000.Total50100200500000 != 0)
                    current.Total50100200000000 += (Decimal)current.cta_50100200500000.Total50100200500000;
                if (current.cta_50100200600000 != null && current.cta_50100200600000.Total50100200600000 != 0)
                    current.Total50100200000000 += (Decimal)current.cta_50100200600000.Total50100200600000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303100000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303100000.cta_50100303101000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303100000.cta_50100303101000;
                current.Total50100303101000 = 0;
                if (current.cta_50100303101010 != null)
                    current.Total50100303101000 += (Decimal)current.cta_50100303101010;
                if (current.cta_50100303101020 != null)
                    current.Total50100303101000 += (Decimal)current.cta_50100303101020;
                if (current.cta_50100303101030 != null)
                    current.Total50100303101000 += (Decimal)current.cta_50100303101030;
                if (current.cta_50100303101100 != null)
                    current.Total50100303101000 += (Decimal)current.cta_50100303101100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303100000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303100000.cta_50100303102000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303100000.cta_50100303102000;
                current.Total50100303102000 = 0;
                if (current.cta_50100303102010 != null)
                    current.Total50100303102000 += (Decimal)current.cta_50100303102010;
                if (current.cta_50100303102020 != null)
                    current.Total50100303102000 += (Decimal)current.cta_50100303102020;
                if (current.cta_50100303102030 != null)
                    current.Total50100303102000 += (Decimal)current.cta_50100303102030;
                if (current.cta_50100303102100 != null)
                    current.Total50100303102000 += (Decimal)current.cta_50100303102100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303100000;
                current.Total50100303100000 = 0;
                if (current.cta_50100303101000 != null && current.cta_50100303101000.Total50100303101000 != 0)
                    current.Total50100303100000 += (Decimal)current.cta_50100303101000.Total50100303101000;
                if (current.cta_50100303102000 != null && current.cta_50100303102000.Total50100303102000 != 0)
                    current.Total50100303100000 += (Decimal)current.cta_50100303102000.Total50100303102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303300000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303300000.cta_50100303301000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303300000.cta_50100303301000;
                current.Total50100303301000 = 0;
                if (current.cta_50100303301010 != null)
                    current.Total50100303301000 += (Decimal)current.cta_50100303301010;
                if (current.cta_50100303301100 != null)
                    current.Total50100303301000 += (Decimal)current.cta_50100303301100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303300000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303300000.cta_50100303302000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303300000.cta_50100303302000;
                current.Total50100303302000 = 0;
                if (current.cta_50100303302010 != null)
                    current.Total50100303302000 += (Decimal)current.cta_50100303302010;
                if (current.cta_50100303302100 != null)
                    current.Total50100303302000 += (Decimal)current.cta_50100303302100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303300000;
                current.Total50100303300000 = 0;
                if (current.cta_50100303301000 != null && current.cta_50100303301000.Total50100303301000 != 0)
                    current.Total50100303300000 += (Decimal)current.cta_50100303301000.Total50100303301000;
                if (current.cta_50100303302000 != null && current.cta_50100303302000.Total50100303302000 != 0)
                    current.Total50100303300000 += (Decimal)current.cta_50100303302000.Total50100303302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303400000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303400000.cta_50100303401000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303400000.cta_50100303401000;
                current.Total50100303401000 = 0;
                if (current.cta_50100303401010 != null)
                    current.Total50100303401000 += (Decimal)current.cta_50100303401010;
                if (current.cta_50100303401100 != null)
                    current.Total50100303401000 += (Decimal)current.cta_50100303401100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303400000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303400000.cta_50100303402000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303400000.cta_50100303402000;
                current.Total50100303402000 = 0;
                if (current.cta_50100303402010 != null)
                    current.Total50100303402000 += (Decimal)current.cta_50100303402010;
                if (current.cta_50100303402100 != null)
                    current.Total50100303402000 += (Decimal)current.cta_50100303402100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303400000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303400000;
                current.Total50100303400000 = 0;
                if (current.cta_50100303401000 != null && current.cta_50100303401000.Total50100303401000 != 0)
                    current.Total50100303400000 += (Decimal)current.cta_50100303401000.Total50100303401000;
                if (current.cta_50100303402000 != null && current.cta_50100303402000.Total50100303402000 != 0)
                    current.Total50100303400000 += (Decimal)current.cta_50100303402000.Total50100303402000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303500000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303500000.cta_50100303501000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303500000.cta_50100303501000;
                current.Total50100303501000 = 0;
                if (current.cta_50100303501010 != null)
                    current.Total50100303501000 += (Decimal)current.cta_50100303501010;
                if (current.cta_50100303501020 != null)
                    current.Total50100303501000 += (Decimal)current.cta_50100303501020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303500000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303500000.cta_50100303502000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303500000.cta_50100303502000;
                current.Total50100303502000 = 0;
                if (current.cta_50100303502010 != null)
                    current.Total50100303502000 += (Decimal)current.cta_50100303502010;
                if (current.cta_50100303502020 != null)
                    current.Total50100303502000 += (Decimal)current.cta_50100303502020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303500000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303500000;
                current.Total50100303500000 = 0;
                if (current.cta_50100303501000 != null && current.cta_50100303501000.Total50100303501000 != 0)
                    current.Total50100303500000 += (Decimal)current.cta_50100303501000.Total50100303501000;
                if (current.cta_50100303502000 != null && current.cta_50100303502000.Total50100303502000 != 0)
                    current.Total50100303500000 += (Decimal)current.cta_50100303502000.Total50100303502000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303600000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303600000.cta_50100303601000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303600000.cta_50100303601000;
                current.Total50100303601000 = 0;
                if (current.cta_50100303601010 != null)
                    current.Total50100303601000 += (Decimal)current.cta_50100303601010;
                if (current.cta_50100303601020 != null)
                    current.Total50100303601000 += (Decimal)current.cta_50100303601020;
                if (current.cta_50100303601100 != null)
                    current.Total50100303601000 += (Decimal)current.cta_50100303601100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303600000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303600000.cta_50100303602000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303600000.cta_50100303602000;
                current.Total50100303602000 = 0;
                if (current.cta_50100303602010 != null)
                    current.Total50100303602000 += (Decimal)current.cta_50100303602010;
                if (current.cta_50100303602020 != null)
                    current.Total50100303602000 += (Decimal)current.cta_50100303602020;
                if (current.cta_50100303602100 != null)
                    current.Total50100303602000 += (Decimal)current.cta_50100303602100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303600000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000.cta_50100303600000;
                current.Total50100303600000 = 0;
                if (current.cta_50100303601000 != null && current.cta_50100303601000.Total50100303601000 != 0)
                    current.Total50100303600000 += (Decimal)current.cta_50100303601000.Total50100303601000;
                if (current.cta_50100303602000 != null && current.cta_50100303602000.Total50100303602000 != 0)
                    current.Total50100303600000 += (Decimal)current.cta_50100303602000.Total50100303602000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100300000000;
                current.Total50100300000000 = 0;
                if (current.cta_50100303100000 != null && current.cta_50100303100000.Total50100303100000 != 0)
                    current.Total50100300000000 += (Decimal)current.cta_50100303100000.Total50100303100000;
                if (current.cta_50100303300000 != null && current.cta_50100303300000.Total50100303300000 != 0)
                    current.Total50100300000000 += (Decimal)current.cta_50100303300000.Total50100303300000;
                if (current.cta_50100303400000 != null && current.cta_50100303400000.Total50100303400000 != 0)
                    current.Total50100300000000 += (Decimal)current.cta_50100303400000.Total50100303400000;
                if (current.cta_50100303500000 != null && current.cta_50100303500000.Total50100303500000 != 0)
                    current.Total50100300000000 += (Decimal)current.cta_50100303500000.Total50100303500000;
                if (current.cta_50100303600000 != null && current.cta_50100303600000.Total50100303600000 != 0)
                    current.Total50100300000000 += (Decimal)current.cta_50100303600000.Total50100303600000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403100000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403100000.cta_50100403101000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403100000.cta_50100403101000;
                current.Total50100403101000 = 0;
                if (current.cta_50100403101010 != null)
                    current.Total50100403101000 += (Decimal)current.cta_50100403101010;
                if (current.cta_50100403101020 != null)
                    current.Total50100403101000 += (Decimal)current.cta_50100403101020;
                if (current.cta_50100403101030 != null)
                    current.Total50100403101000 += (Decimal)current.cta_50100403101030;
                if (current.cta_50100403101100 != null)
                    current.Total50100403101000 += (Decimal)current.cta_50100403101100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403100000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403100000.cta_50100403102000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403100000.cta_50100403102000;
                current.Total50100403102000 = 0;
                if (current.cta_50100403102010 != null)
                    current.Total50100403102000 += (Decimal)current.cta_50100403102010;
                if (current.cta_50100403102020 != null)
                    current.Total50100403102000 += (Decimal)current.cta_50100403102020;
                if (current.cta_50100403102030 != null)
                    current.Total50100403102000 += (Decimal)current.cta_50100403102030;
                if (current.cta_50100403102100 != null)
                    current.Total50100403102000 += (Decimal)current.cta_50100403102100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403100000;
                current.Total50100403100000 = 0;
                if (current.cta_50100403101000 != null && current.cta_50100403101000.Total50100403101000 != 0)
                    current.Total50100403100000 += (Decimal)current.cta_50100403101000.Total50100403101000;
                if (current.cta_50100403102000 != null && current.cta_50100403102000.Total50100403102000 != 0)
                    current.Total50100403100000 += (Decimal)current.cta_50100403102000.Total50100403102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403300000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403300000.cta_50100403301000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403300000.cta_50100403301000;
                current.Total50100403301000 = 0;
                if (current.cta_50100403301010 != null)
                    current.Total50100403301000 += (Decimal)current.cta_50100403301010;
                if (current.cta_50100403301100 != null)
                    current.Total50100403301000 += (Decimal)current.cta_50100403301100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403300000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403300000.cta_50100403302000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403300000.cta_50100403302000;
                current.Total50100403302000 = 0;
                if (current.cta_50100403302010 != null)
                    current.Total50100403302000 += (Decimal)current.cta_50100403302010;
                if (current.cta_50100403302100 != null)
                    current.Total50100403302000 += (Decimal)current.cta_50100403302100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403300000;
                current.Total50100403300000 = 0;
                if (current.cta_50100403301000 != null && current.cta_50100403301000.Total50100403301000 != 0)
                    current.Total50100403300000 += (Decimal)current.cta_50100403301000.Total50100403301000;
                if (current.cta_50100403302000 != null && current.cta_50100403302000.Total50100403302000 != 0)
                    current.Total50100403300000 += (Decimal)current.cta_50100403302000.Total50100403302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403400000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403400000.cta_50100403401000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403400000.cta_50100403401000;
                current.Total50100403401000 = 0;
                if (current.cta_50100403401010 != null)
                    current.Total50100403401000 += (Decimal)current.cta_50100403401010;
                if (current.cta_50100403401100 != null)
                    current.Total50100403401000 += (Decimal)current.cta_50100403401100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403400000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403400000.cta_50100403402000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403400000.cta_50100403402000;
                current.Total50100403402000 = 0;
                if (current.cta_50100403402010 != null)
                    current.Total50100403402000 += (Decimal)current.cta_50100403402010;
                if (current.cta_50100403402100 != null)
                    current.Total50100403402000 += (Decimal)current.cta_50100403402100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403400000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403400000;
                current.Total50100403400000 = 0;
                if (current.cta_50100403401000 != null && current.cta_50100403401000.Total50100403401000 != 0)
                    current.Total50100403400000 += (Decimal)current.cta_50100403401000.Total50100403401000;
                if (current.cta_50100403402000 != null && current.cta_50100403402000.Total50100403402000 != 0)
                    current.Total50100403400000 += (Decimal)current.cta_50100403402000.Total50100403402000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403500000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403500000.cta_50100403501000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403500000.cta_50100403501000;
                current.Total50100403501000 = 0;
                if (current.cta_50100403501010 != null)
                    current.Total50100403501000 += (Decimal)current.cta_50100403501010;
                if (current.cta_50100403501020 != null)
                    current.Total50100403501000 += (Decimal)current.cta_50100403501020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403500000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403500000.cta_50100403502000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403500000.cta_50100403502000;
                current.Total50100403502000 = 0;
                if (current.cta_50100403502010 != null)
                    current.Total50100403502000 += (Decimal)current.cta_50100403502010;
                if (current.cta_50100403502020 != null)
                    current.Total50100403502000 += (Decimal)current.cta_50100403502020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403500000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403500000;
                current.Total50100403500000 = 0;
                if (current.cta_50100403501000 != null && current.cta_50100403501000.Total50100403501000 != 0)
                    current.Total50100403500000 += (Decimal)current.cta_50100403501000.Total50100403501000;
                if (current.cta_50100403502000 != null && current.cta_50100403502000.Total50100403502000 != 0)
                    current.Total50100403500000 += (Decimal)current.cta_50100403502000.Total50100403502000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403600000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403600000.cta_50100403601000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403600000.cta_50100403601000;
                current.Total50100403601000 = 0;
                if (current.cta_50100403601010 != null)
                    current.Total50100403601000 += (Decimal)current.cta_50100403601010;
                if (current.cta_50100403601020 != null)
                    current.Total50100403601000 += (Decimal)current.cta_50100403601020;
                if (current.cta_50100403601100 != null)
                    current.Total50100403601000 += (Decimal)current.cta_50100403601100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403600000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403600000.cta_50100403602000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403600000.cta_50100403602000;
                current.Total50100403602000 = 0;
                if (current.cta_50100403602010 != null)
                    current.Total50100403602000 += (Decimal)current.cta_50100403602010;
                if (current.cta_50100403602020 != null)
                    current.Total50100403602000 += (Decimal)current.cta_50100403602020;
                if (current.cta_50100403602100 != null)
                    current.Total50100403602000 += (Decimal)current.cta_50100403602100;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403600000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403600000;
                current.Total50100403600000 = 0;
                if (current.cta_50100403601000 != null && current.cta_50100403601000.Total50100403601000 != 0)
                    current.Total50100403600000 += (Decimal)current.cta_50100403601000.Total50100403601000;
                if (current.cta_50100403602000 != null && current.cta_50100403602000.Total50100403602000 != 0)
                    current.Total50100403600000 += (Decimal)current.cta_50100403602000.Total50100403602000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403700000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403700000.cta_50100403701000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403700000.cta_50100403701000;
                current.Total50100403701000 = 0;
                if (current.cta_50100403701010 != null)
                    current.Total50100403701000 += (Decimal)current.cta_50100403701010;
                if (current.cta_50100403701030 != null)
                    current.Total50100403701000 += (Decimal)current.cta_50100403701030;
                if (current.cta_50100403701040 != null)
                    current.Total50100403701000 += (Decimal)current.cta_50100403701040;
                if (current.cta_50100403701050 != null)
                    current.Total50100403701000 += (Decimal)current.cta_50100403701050;
                if (current.cta_50100403701060 != null)
                    current.Total50100403701000 += (Decimal)current.cta_50100403701060;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403700000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403700000.cta_50100403702000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403700000.cta_50100403702000;
                current.Total50100403702000 = 0;
                if (current.cta_50100403702010 != null)
                    current.Total50100403702000 += (Decimal)current.cta_50100403702010;
                if (current.cta_50100403702030 != null)
                    current.Total50100403702000 += (Decimal)current.cta_50100403702030;
                if (current.cta_50100403702040 != null)
                    current.Total50100403702000 += (Decimal)current.cta_50100403702040;
                if (current.cta_50100403702050 != null)
                    current.Total50100403702000 += (Decimal)current.cta_50100403702050;
                if (current.cta_50100403702060 != null)
                    current.Total50100403702000 += (Decimal)current.cta_50100403702060;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403700000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403700000;
                current.Total50100403700000 = 0;
                if (current.cta_50100403701000 != null && current.cta_50100403701000.Total50100403701000 != 0)
                    current.Total50100403700000 += (Decimal)current.cta_50100403701000.Total50100403701000;
                if (current.cta_50100403702000 != null && current.cta_50100403702000.Total50100403702000 != 0)
                    current.Total50100403700000 += (Decimal)current.cta_50100403702000.Total50100403702000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403800000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403800000.cta_50100403801000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403800000.cta_50100403801000;
                current.Total50100403801000 = 0;
                if (current.cta_50100403801010 != null)
                    current.Total50100403801000 += (Decimal)current.cta_50100403801010;
                if (current.cta_50100403801020 != null)
                    current.Total50100403801000 += (Decimal)current.cta_50100403801020;
                if (current.cta_50100403801030 != null)
                    current.Total50100403801000 += (Decimal)current.cta_50100403801030;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403800000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403800000.cta_50100403802000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403800000.cta_50100403802000;
                current.Total50100403802000 = 0;
                if (current.cta_50100403802010 != null)
                    current.Total50100403802000 += (Decimal)current.cta_50100403802010;
                if (current.cta_50100403802020 != null)
                    current.Total50100403802000 += (Decimal)current.cta_50100403802020;
                if (current.cta_50100403802030 != null)
                    current.Total50100403802000 += (Decimal)current.cta_50100403802030;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403800000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100403800000;
                current.Total50100403800000 = 0;
                if (current.cta_50100403801000 != null && current.cta_50100403801000.Total50100403801000 != 0)
                    current.Total50100403800000 += (Decimal)current.cta_50100403801000.Total50100403801000;
                if (current.cta_50100403802000 != null && current.cta_50100403802000.Total50100403802000 != 0)
                    current.Total50100403800000 += (Decimal)current.cta_50100403802000.Total50100403802000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100404000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100404000000;
                current.Total50100404000000 = 0;
                if (current.cta_50100404001000 != null)
                    current.Total50100404000000 += (Decimal)current.cta_50100404001000;
                if (current.cta_50100404002000 != null)
                    current.Total50100404000000 += (Decimal)current.cta_50100404002000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100404900000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100404900000.cta_50100404901000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100404900000.cta_50100404901000;
                current.Total50100404901000 = 0;
                if (current.cta_50100404901080 != null)
                    current.Total50100404901000 += (Decimal)current.cta_50100404901080;
                if (current.cta_50100404901090 != null)
                    current.Total50100404901000 += (Decimal)current.cta_50100404901090;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100404900000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100404900000.cta_50100404902000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100404900000.cta_50100404902000;
                current.Total50100404902000 = 0;
                if (current.cta_50100404902080 != null)
                    current.Total50100404902000 += (Decimal)current.cta_50100404902080;
                if (current.cta_50100404902090 != null)
                    current.Total50100404902000 += (Decimal)current.cta_50100404902090;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100404900000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000.cta_50100404900000;
                current.Total50100404900000 = 0;
                if (current.cta_50100404901000 != null && current.cta_50100404901000.Total50100404901000 != 0)
                    current.Total50100404900000 += (Decimal)current.cta_50100404901000.Total50100404901000;
                if (current.cta_50100404902000 != null && current.cta_50100404902000.Total50100404902000 != 0)
                    current.Total50100404900000 += (Decimal)current.cta_50100404902000.Total50100404902000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100400000000;
                current.Total50100400000000 = 0;
                if (current.cta_50100403100000 != null && current.cta_50100403100000.Total50100403100000 != 0)
                    current.Total50100400000000 += (Decimal)current.cta_50100403100000.Total50100403100000;
                if (current.cta_50100403300000 != null && current.cta_50100403300000.Total50100403300000 != 0)
                    current.Total50100400000000 += (Decimal)current.cta_50100403300000.Total50100403300000;
                if (current.cta_50100403400000 != null && current.cta_50100403400000.Total50100403400000 != 0)
                    current.Total50100400000000 += (Decimal)current.cta_50100403400000.Total50100403400000;
                if (current.cta_50100403500000 != null && current.cta_50100403500000.Total50100403500000 != 0)
                    current.Total50100400000000 += (Decimal)current.cta_50100403500000.Total50100403500000;
                if (current.cta_50100403600000 != null && current.cta_50100403600000.Total50100403600000 != 0)
                    current.Total50100400000000 += (Decimal)current.cta_50100403600000.Total50100403600000;
                if (current.cta_50100403700000 != null && current.cta_50100403700000.Total50100403700000 != 0)
                    current.Total50100400000000 += (Decimal)current.cta_50100403700000.Total50100403700000;
                if (current.cta_50100403800000 != null && current.cta_50100403800000.Total50100403800000 != 0)
                    current.Total50100400000000 += (Decimal)current.cta_50100403800000.Total50100403800000;
                if (current.cta_50100404000000 != null && current.cta_50100404000000.Total50100404000000 != 0)
                    current.Total50100400000000 += (Decimal)current.cta_50100404000000.Total50100404000000;
                if (current.cta_50100404900000 != null && current.cta_50100404900000.Total50100404900000 != 0)
                    current.Total50100400000000 += (Decimal)current.cta_50100404900000.Total50100404900000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100500000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100500000000.cta_50100500100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100500000000.cta_50100500100000;
                current.Total50100500100000 = 0;
                if (current.cta_50100500101000 != null)
                    current.Total50100500100000 += (Decimal)current.cta_50100500101000;
                if (current.cta_50100500102000 != null)
                    current.Total50100500100000 += (Decimal)current.cta_50100500102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100500000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100500000000;
                current.Total50100500000000 = 0;
                if (current.cta_50100500100000 != null && current.cta_50100500100000.Total50100500100000 != 0)
                    current.Total50100500000000 += (Decimal)current.cta_50100500100000.Total50100500100000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700100000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700100000.cta_50100700101000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700100000.cta_50100700101000;
                current.Total50100700101000 = 0;
                if (current.cta_50100700101010 != null)
                    current.Total50100700101000 += (Decimal)current.cta_50100700101010;
                if (current.cta_50100700101020 != null)
                    current.Total50100700101000 += (Decimal)current.cta_50100700101020;
                if (current.cta_50100700101030 != null)
                    current.Total50100700101000 += (Decimal)current.cta_50100700101030;
                if (current.cta_50100700101040 != null)
                    current.Total50100700101000 += (Decimal)current.cta_50100700101040;
                if (current.cta_50100700101050 != null)
                    current.Total50100700101000 += (Decimal)current.cta_50100700101050;
                if (current.cta_50100700101060 != null)
                    current.Total50100700101000 += (Decimal)current.cta_50100700101060;
                if (current.cta_50100700101070 != null)
                    current.Total50100700101000 += (Decimal)current.cta_50100700101070;
                if (current.cta_50100700101080 != null)
                    current.Total50100700101000 += (Decimal)current.cta_50100700101080;
                if (current.cta_50100700101990 != null)
                    current.Total50100700101000 += (Decimal)current.cta_50100700101990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700100000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700100000.cta_50100700102000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700100000.cta_50100700102000;
                current.Total50100700102000 = 0;
                if (current.cta_50100700102010 != null)
                    current.Total50100700102000 += (Decimal)current.cta_50100700102010;
                if (current.cta_50100700102020 != null)
                    current.Total50100700102000 += (Decimal)current.cta_50100700102020;
                if (current.cta_50100700102030 != null)
                    current.Total50100700102000 += (Decimal)current.cta_50100700102030;
                if (current.cta_50100700102040 != null)
                    current.Total50100700102000 += (Decimal)current.cta_50100700102040;
                if (current.cta_50100700102050 != null)
                    current.Total50100700102000 += (Decimal)current.cta_50100700102050;
                if (current.cta_50100700102060 != null)
                    current.Total50100700102000 += (Decimal)current.cta_50100700102060;
                if (current.cta_50100700102070 != null)
                    current.Total50100700102000 += (Decimal)current.cta_50100700102070;
                if (current.cta_50100700102080 != null)
                    current.Total50100700102000 += (Decimal)current.cta_50100700102080;
                if (current.cta_50100700102990 != null)
                    current.Total50100700102000 += (Decimal)current.cta_50100700102990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700100000;
                current.Total50100700100000 = 0;
                if (current.cta_50100700101000 != null && current.cta_50100700101000.Total50100700101000 != 0)
                    current.Total50100700100000 += (Decimal)current.cta_50100700101000.Total50100700101000;
                if (current.cta_50100700102000 != null && current.cta_50100700102000.Total50100700102000 != 0)
                    current.Total50100700100000 += (Decimal)current.cta_50100700102000.Total50100700102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700200000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700200000.cta_50100700201000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700200000.cta_50100700201000;
                current.Total50100700201000 = 0;
                if (current.cta_50100700201010 != null)
                    current.Total50100700201000 += (Decimal)current.cta_50100700201010;
                if (current.cta_50100700201020 != null)
                    current.Total50100700201000 += (Decimal)current.cta_50100700201020;
                if (current.cta_50100700201030 != null)
                    current.Total50100700201000 += (Decimal)current.cta_50100700201030;
                if (current.cta_50100700201040 != null)
                    current.Total50100700201000 += (Decimal)current.cta_50100700201040;
                if (current.cta_50100700201050 != null)
                    current.Total50100700201000 += (Decimal)current.cta_50100700201050;
                if (current.cta_50100700201060 != null)
                    current.Total50100700201000 += (Decimal)current.cta_50100700201060;
                if (current.cta_50100700201070 != null)
                    current.Total50100700201000 += (Decimal)current.cta_50100700201070;
                if (current.cta_50100700201080 != null)
                    current.Total50100700201000 += (Decimal)current.cta_50100700201080;
                if (current.cta_50100700201990 != null)
                    current.Total50100700201000 += (Decimal)current.cta_50100700201990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700200000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700200000.cta_50100700202000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700200000.cta_50100700202000;
                current.Total50100700202000 = 0;
                if (current.cta_50100700202010 != null)
                    current.Total50100700202000 += (Decimal)current.cta_50100700202010;
                if (current.cta_50100700202020 != null)
                    current.Total50100700202000 += (Decimal)current.cta_50100700202020;
                if (current.cta_50100700202030 != null)
                    current.Total50100700202000 += (Decimal)current.cta_50100700202030;
                if (current.cta_50100700202040 != null)
                    current.Total50100700202000 += (Decimal)current.cta_50100700202040;
                if (current.cta_50100700202050 != null)
                    current.Total50100700202000 += (Decimal)current.cta_50100700202050;
                if (current.cta_50100700202060 != null)
                    current.Total50100700202000 += (Decimal)current.cta_50100700202060;
                if (current.cta_50100700202070 != null)
                    current.Total50100700202000 += (Decimal)current.cta_50100700202070;
                if (current.cta_50100700202080 != null)
                    current.Total50100700202000 += (Decimal)current.cta_50100700202080;
                if (current.cta_50100700202990 != null)
                    current.Total50100700202000 += (Decimal)current.cta_50100700202990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700200000;
                current.Total50100700200000 = 0;
                if (current.cta_50100700201000 != null && current.cta_50100700201000.Total50100700201000 != 0)
                    current.Total50100700200000 += (Decimal)current.cta_50100700201000.Total50100700201000;
                if (current.cta_50100700202000 != null && current.cta_50100700202000.Total50100700202000 != 0)
                    current.Total50100700200000 += (Decimal)current.cta_50100700202000.Total50100700202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700300000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700300000.cta_50100700301000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700300000.cta_50100700301000;
                current.Total50100700301000 = 0;
                if (current.cta_50100700301010 != null)
                    current.Total50100700301000 += (Decimal)current.cta_50100700301010;
                if (current.cta_50100700301020 != null)
                    current.Total50100700301000 += (Decimal)current.cta_50100700301020;
                if (current.cta_50100700301030 != null)
                    current.Total50100700301000 += (Decimal)current.cta_50100700301030;
                if (current.cta_50100700301040 != null)
                    current.Total50100700301000 += (Decimal)current.cta_50100700301040;
                if (current.cta_50100700301990 != null)
                    current.Total50100700301000 += (Decimal)current.cta_50100700301990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700300000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700300000.cta_50100700302000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700300000.cta_50100700302000;
                current.Total50100700302000 = 0;
                if (current.cta_50100700302010 != null)
                    current.Total50100700302000 += (Decimal)current.cta_50100700302010;
                if (current.cta_50100700302020 != null)
                    current.Total50100700302000 += (Decimal)current.cta_50100700302020;
                if (current.cta_50100700302030 != null)
                    current.Total50100700302000 += (Decimal)current.cta_50100700302030;
                if (current.cta_50100700302040 != null)
                    current.Total50100700302000 += (Decimal)current.cta_50100700302040;
                if (current.cta_50100700302990 != null)
                    current.Total50100700302000 += (Decimal)current.cta_50100700302990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700300000;
                current.Total50100700300000 = 0;
                if (current.cta_50100700301000 != null && current.cta_50100700301000.Total50100700301000 != 0)
                    current.Total50100700300000 += (Decimal)current.cta_50100700301000.Total50100700301000;
                if (current.cta_50100700302000 != null && current.cta_50100700302000.Total50100700302000 != 0)
                    current.Total50100700300000 += (Decimal)current.cta_50100700302000.Total50100700302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700400000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700400000.cta_50100700401000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700400000.cta_50100700401000;
                current.Total50100700401000 = 0;
                if (current.cta_50100700401010 != null)
                    current.Total50100700401000 += (Decimal)current.cta_50100700401010;
                if (current.cta_50100700401020 != null)
                    current.Total50100700401000 += (Decimal)current.cta_50100700401020;
                if (current.cta_50100700401030 != null)
                    current.Total50100700401000 += (Decimal)current.cta_50100700401030;
                if (current.cta_50100700401040 != null)
                    current.Total50100700401000 += (Decimal)current.cta_50100700401040;
                if (current.cta_50100700401050 != null)
                    current.Total50100700401000 += (Decimal)current.cta_50100700401050;
                if (current.cta_50100700401060 != null)
                    current.Total50100700401000 += (Decimal)current.cta_50100700401060;
                if (current.cta_50100700401070 != null)
                    current.Total50100700401000 += (Decimal)current.cta_50100700401070;
                if (current.cta_50100700401080 != null)
                    current.Total50100700401000 += (Decimal)current.cta_50100700401080;
                if (current.cta_50100700401090 != null)
                    current.Total50100700401000 += (Decimal)current.cta_50100700401090;
                if (current.cta_50100700401100 != null)
                    current.Total50100700401000 += (Decimal)current.cta_50100700401100;
                if (current.cta_50100700401990 != null)
                    current.Total50100700401000 += (Decimal)current.cta_50100700401990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700400000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700400000.cta_50100700402000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700400000.cta_50100700402000;
                current.Total50100700402000 = 0;
                if (current.cta_50100700402010 != null)
                    current.Total50100700402000 += (Decimal)current.cta_50100700402010;
                if (current.cta_50100700402020 != null)
                    current.Total50100700402000 += (Decimal)current.cta_50100700402020;
                if (current.cta_50100700402030 != null)
                    current.Total50100700402000 += (Decimal)current.cta_50100700402030;
                if (current.cta_50100700402040 != null)
                    current.Total50100700402000 += (Decimal)current.cta_50100700402040;
                if (current.cta_50100700402050 != null)
                    current.Total50100700402000 += (Decimal)current.cta_50100700402050;
                if (current.cta_50100700402060 != null)
                    current.Total50100700402000 += (Decimal)current.cta_50100700402060;
                if (current.cta_50100700402070 != null)
                    current.Total50100700402000 += (Decimal)current.cta_50100700402070;
                if (current.cta_50100700402080 != null)
                    current.Total50100700402000 += (Decimal)current.cta_50100700402080;
                if (current.cta_50100700402090 != null)
                    current.Total50100700402000 += (Decimal)current.cta_50100700402090;
                if (current.cta_50100700402100 != null)
                    current.Total50100700402000 += (Decimal)current.cta_50100700402100;
                if (current.cta_50100700402990 != null)
                    current.Total50100700402000 += (Decimal)current.cta_50100700402990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700400000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700400000;
                current.Total50100700400000 = 0;
                if (current.cta_50100700401000 != null && current.cta_50100700401000.Total50100700401000 != 0)
                    current.Total50100700400000 += (Decimal)current.cta_50100700401000.Total50100700401000;
                if (current.cta_50100700402000 != null && current.cta_50100700402000.Total50100700402000 != 0)
                    current.Total50100700400000 += (Decimal)current.cta_50100700402000.Total50100700402000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700500000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700500000.cta_50100700501000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700500000.cta_50100700501000;
                current.Total50100700501000 = 0;
                if (current.cta_50100700501010 != null)
                    current.Total50100700501000 += (Decimal)current.cta_50100700501010;
                if (current.cta_50100700501020 != null)
                    current.Total50100700501000 += (Decimal)current.cta_50100700501020;
                if (current.cta_50100700501030 != null)
                    current.Total50100700501000 += (Decimal)current.cta_50100700501030;
                if (current.cta_50100700501040 != null)
                    current.Total50100700501000 += (Decimal)current.cta_50100700501040;
                if (current.cta_50100700501050 != null)
                    current.Total50100700501000 += (Decimal)current.cta_50100700501050;
                if (current.cta_50100700501060 != null)
                    current.Total50100700501000 += (Decimal)current.cta_50100700501060;
                if (current.cta_50100700501070 != null)
                    current.Total50100700501000 += (Decimal)current.cta_50100700501070;
                if (current.cta_50100700501080 != null)
                    current.Total50100700501000 += (Decimal)current.cta_50100700501080;
                if (current.cta_50100700501990 != null)
                    current.Total50100700501000 += (Decimal)current.cta_50100700501990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700500000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700500000.cta_50100700502000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700500000.cta_50100700502000;
                current.Total50100700502000 = 0;
                if (current.cta_50100700502010 != null)
                    current.Total50100700502000 += (Decimal)current.cta_50100700502010;
                if (current.cta_50100700502020 != null)
                    current.Total50100700502000 += (Decimal)current.cta_50100700502020;
                if (current.cta_50100700502030 != null)
                    current.Total50100700502000 += (Decimal)current.cta_50100700502030;
                if (current.cta_50100700502040 != null)
                    current.Total50100700502000 += (Decimal)current.cta_50100700502040;
                if (current.cta_50100700502050 != null)
                    current.Total50100700502000 += (Decimal)current.cta_50100700502050;
                if (current.cta_50100700502060 != null)
                    current.Total50100700502000 += (Decimal)current.cta_50100700502060;
                if (current.cta_50100700502070 != null)
                    current.Total50100700502000 += (Decimal)current.cta_50100700502070;
                if (current.cta_50100700502080 != null)
                    current.Total50100700502000 += (Decimal)current.cta_50100700502080;
                if (current.cta_50100700502990 != null)
                    current.Total50100700502000 += (Decimal)current.cta_50100700502990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700500000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700500000;
                current.Total50100700500000 = 0;
                if (current.cta_50100700501000 != null && current.cta_50100700501000.Total50100700501000 != 0)
                    current.Total50100700500000 += (Decimal)current.cta_50100700501000.Total50100700501000;
                if (current.cta_50100700502000 != null && current.cta_50100700502000.Total50100700502000 != 0)
                    current.Total50100700500000 += (Decimal)current.cta_50100700502000.Total50100700502000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700600000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700600000.cta_50100700601000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700600000.cta_50100700601000;
                current.Total50100700601000 = 0;
                if (current.cta_50100700601010 != null)
                    current.Total50100700601000 += (Decimal)current.cta_50100700601010;
                if (current.cta_50100700601020 != null)
                    current.Total50100700601000 += (Decimal)current.cta_50100700601020;
                if (current.cta_50100700601030 != null)
                    current.Total50100700601000 += (Decimal)current.cta_50100700601030;
                if (current.cta_50100700601040 != null)
                    current.Total50100700601000 += (Decimal)current.cta_50100700601040;
                if (current.cta_50100700601050 != null)
                    current.Total50100700601000 += (Decimal)current.cta_50100700601050;
                if (current.cta_50100700601060 != null)
                    current.Total50100700601000 += (Decimal)current.cta_50100700601060;
                if (current.cta_50100700601070 != null)
                    current.Total50100700601000 += (Decimal)current.cta_50100700601070;
                if (current.cta_50100700601080 != null)
                    current.Total50100700601000 += (Decimal)current.cta_50100700601080;
                if (current.cta_50100700601990 != null)
                    current.Total50100700601000 += (Decimal)current.cta_50100700601990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700600000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700600000.cta_50100700602000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700600000.cta_50100700602000;
                current.Total50100700602000 = 0;
                if (current.cta_50100700602010 != null)
                    current.Total50100700602000 += (Decimal)current.cta_50100700602010;
                if (current.cta_50100700602020 != null)
                    current.Total50100700602000 += (Decimal)current.cta_50100700602020;
                if (current.cta_50100700602030 != null)
                    current.Total50100700602000 += (Decimal)current.cta_50100700602030;
                if (current.cta_50100700602040 != null)
                    current.Total50100700602000 += (Decimal)current.cta_50100700602040;
                if (current.cta_50100700602050 != null)
                    current.Total50100700602000 += (Decimal)current.cta_50100700602050;
                if (current.cta_50100700602060 != null)
                    current.Total50100700602000 += (Decimal)current.cta_50100700602060;
                if (current.cta_50100700602070 != null)
                    current.Total50100700602000 += (Decimal)current.cta_50100700602070;
                if (current.cta_50100700602080 != null)
                    current.Total50100700602000 += (Decimal)current.cta_50100700602080;
                if (current.cta_50100700602990 != null)
                    current.Total50100700602000 += (Decimal)current.cta_50100700602990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700600000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700600000;
                current.Total50100700600000 = 0;
                if (current.cta_50100700601000 != null && current.cta_50100700601000.Total50100700601000 != 0)
                    current.Total50100700600000 += (Decimal)current.cta_50100700601000.Total50100700601000;
                if (current.cta_50100700602000 != null && current.cta_50100700602000.Total50100700602000 != 0)
                    current.Total50100700600000 += (Decimal)current.cta_50100700602000.Total50100700602000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700700000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700700000.cta_50100700701000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700700000.cta_50100700701000;
                current.Total50100700701000 = 0;
                if (current.cta_50100700701010 != null)
                    current.Total50100700701000 += (Decimal)current.cta_50100700701010;
                if (current.cta_50100700701020 != null)
                    current.Total50100700701000 += (Decimal)current.cta_50100700701020;
                if (current.cta_50100700701030 != null)
                    current.Total50100700701000 += (Decimal)current.cta_50100700701030;
                if (current.cta_50100700701040 != null)
                    current.Total50100700701000 += (Decimal)current.cta_50100700701040;
                if (current.cta_50100700701990 != null)
                    current.Total50100700701000 += (Decimal)current.cta_50100700701990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700700000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700700000.cta_50100700702000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700700000.cta_50100700702000;
                current.Total50100700702000 = 0;
                if (current.cta_50100700702010 != null)
                    current.Total50100700702000 += (Decimal)current.cta_50100700702010;
                if (current.cta_50100700702020 != null)
                    current.Total50100700702000 += (Decimal)current.cta_50100700702020;
                if (current.cta_50100700702030 != null)
                    current.Total50100700702000 += (Decimal)current.cta_50100700702030;
                if (current.cta_50100700702040 != null)
                    current.Total50100700702000 += (Decimal)current.cta_50100700702040;
                if (current.cta_50100700702990 != null)
                    current.Total50100700702000 += (Decimal)current.cta_50100700702990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700700000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700700000;
                current.Total50100700700000 = 0;
                if (current.cta_50100700701000 != null && current.cta_50100700701000.Total50100700701000 != 0)
                    current.Total50100700700000 += (Decimal)current.cta_50100700701000.Total50100700701000;
                if (current.cta_50100700702000 != null && current.cta_50100700702000.Total50100700702000 != 0)
                    current.Total50100700700000 += (Decimal)current.cta_50100700702000.Total50100700702000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700800000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700800000.cta_50100700801000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700800000.cta_50100700801000;
                current.Total50100700801000 = 0;
                if (current.cta_50100700801010 != null)
                    current.Total50100700801000 += (Decimal)current.cta_50100700801010;
                if (current.cta_50100700801020 != null)
                    current.Total50100700801000 += (Decimal)current.cta_50100700801020;
                if (current.cta_50100700801030 != null)
                    current.Total50100700801000 += (Decimal)current.cta_50100700801030;
                if (current.cta_50100700801040 != null)
                    current.Total50100700801000 += (Decimal)current.cta_50100700801040;
                if (current.cta_50100700801050 != null)
                    current.Total50100700801000 += (Decimal)current.cta_50100700801050;
                if (current.cta_50100700801060 != null)
                    current.Total50100700801000 += (Decimal)current.cta_50100700801060;
                if (current.cta_50100700801070 != null)
                    current.Total50100700801000 += (Decimal)current.cta_50100700801070;
                if (current.cta_50100700801080 != null)
                    current.Total50100700801000 += (Decimal)current.cta_50100700801080;
                if (current.cta_50100700801990 != null)
                    current.Total50100700801000 += (Decimal)current.cta_50100700801990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700800000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700800000.cta_50100700802000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700800000.cta_50100700802000;
                current.Total50100700802000 = 0;
                if (current.cta_50100700802010 != null)
                    current.Total50100700802000 += (Decimal)current.cta_50100700802010;
                if (current.cta_50100700802020 != null)
                    current.Total50100700802000 += (Decimal)current.cta_50100700802020;
                if (current.cta_50100700802030 != null)
                    current.Total50100700802000 += (Decimal)current.cta_50100700802030;
                if (current.cta_50100700802040 != null)
                    current.Total50100700802000 += (Decimal)current.cta_50100700802040;
                if (current.cta_50100700802050 != null)
                    current.Total50100700802000 += (Decimal)current.cta_50100700802050;
                if (current.cta_50100700802060 != null)
                    current.Total50100700802000 += (Decimal)current.cta_50100700802060;
                if (current.cta_50100700802070 != null)
                    current.Total50100700802000 += (Decimal)current.cta_50100700802070;
                if (current.cta_50100700802080 != null)
                    current.Total50100700802000 += (Decimal)current.cta_50100700802080;
                if (current.cta_50100700802990 != null)
                    current.Total50100700802000 += (Decimal)current.cta_50100700802990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700800000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700800000;
                current.Total50100700800000 = 0;
                if (current.cta_50100700801000 != null && current.cta_50100700801000.Total50100700801000 != 0)
                    current.Total50100700800000 += (Decimal)current.cta_50100700801000.Total50100700801000;
                if (current.cta_50100700802000 != null && current.cta_50100700802000.Total50100700802000 != 0)
                    current.Total50100700800000 += (Decimal)current.cta_50100700802000.Total50100700802000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700900000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700900000.cta_50100700901000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700900000.cta_50100700901000;
                current.Total50100700901000 = 0;
                if (current.cta_50100700901010 != null)
                    current.Total50100700901000 += (Decimal)current.cta_50100700901010;
                if (current.cta_50100700901020 != null)
                    current.Total50100700901000 += (Decimal)current.cta_50100700901020;
                if (current.cta_50100700901030 != null)
                    current.Total50100700901000 += (Decimal)current.cta_50100700901030;
                if (current.cta_50100700901040 != null)
                    current.Total50100700901000 += (Decimal)current.cta_50100700901040;
                if (current.cta_50100700901050 != null)
                    current.Total50100700901000 += (Decimal)current.cta_50100700901050;
                if (current.cta_50100700901060 != null)
                    current.Total50100700901000 += (Decimal)current.cta_50100700901060;
                if (current.cta_50100700901070 != null)
                    current.Total50100700901000 += (Decimal)current.cta_50100700901070;
                if (current.cta_50100700901080 != null)
                    current.Total50100700901000 += (Decimal)current.cta_50100700901080;
                if (current.cta_50100700901990 != null)
                    current.Total50100700901000 += (Decimal)current.cta_50100700901990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700900000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700900000.cta_50100700902000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700900000.cta_50100700902000;
                current.Total50100700902000 = 0;
                if (current.cta_50100700902010 != null)
                    current.Total50100700902000 += (Decimal)current.cta_50100700902010;
                if (current.cta_50100700902020 != null)
                    current.Total50100700902000 += (Decimal)current.cta_50100700902020;
                if (current.cta_50100700902030 != null)
                    current.Total50100700902000 += (Decimal)current.cta_50100700902030;
                if (current.cta_50100700902040 != null)
                    current.Total50100700902000 += (Decimal)current.cta_50100700902040;
                if (current.cta_50100700902050 != null)
                    current.Total50100700902000 += (Decimal)current.cta_50100700902050;
                if (current.cta_50100700902060 != null)
                    current.Total50100700902000 += (Decimal)current.cta_50100700902060;
                if (current.cta_50100700902070 != null)
                    current.Total50100700902000 += (Decimal)current.cta_50100700902070;
                if (current.cta_50100700902080 != null)
                    current.Total50100700902000 += (Decimal)current.cta_50100700902080;
                if (current.cta_50100700902990 != null)
                    current.Total50100700902000 += (Decimal)current.cta_50100700902990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700900000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100700900000;
                current.Total50100700900000 = 0;
                if (current.cta_50100700901000 != null && current.cta_50100700901000.Total50100700901000 != 0)
                    current.Total50100700900000 += (Decimal)current.cta_50100700901000.Total50100700901000;
                if (current.cta_50100700902000 != null && current.cta_50100700902000.Total50100700902000 != 0)
                    current.Total50100700900000 += (Decimal)current.cta_50100700902000.Total50100700902000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100701000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100701000000.cta_50100701001000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100701000000.cta_50100701001000;
                current.Total50100701001000 = 0;
                if (current.cta_50100701001010 != null)
                    current.Total50100701001000 += (Decimal)current.cta_50100701001010;
                if (current.cta_50100701001020 != null)
                    current.Total50100701001000 += (Decimal)current.cta_50100701001020;
                if (current.cta_50100701001030 != null)
                    current.Total50100701001000 += (Decimal)current.cta_50100701001030;
                if (current.cta_50100701001040 != null)
                    current.Total50100701001000 += (Decimal)current.cta_50100701001040;
                if (current.cta_50100701001990 != null)
                    current.Total50100701001000 += (Decimal)current.cta_50100701001990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100701000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100701000000.cta_50100701002000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100701000000.cta_50100701002000;
                current.Total50100701002000 = 0;
                if (current.cta_50100701002010 != null)
                    current.Total50100701002000 += (Decimal)current.cta_50100701002010;
                if (current.cta_50100701002020 != null)
                    current.Total50100701002000 += (Decimal)current.cta_50100701002020;
                if (current.cta_50100701002030 != null)
                    current.Total50100701002000 += (Decimal)current.cta_50100701002030;
                if (current.cta_50100701002040 != null)
                    current.Total50100701002000 += (Decimal)current.cta_50100701002040;
                if (current.cta_50100701002990 != null)
                    current.Total50100701002000 += (Decimal)current.cta_50100701002990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100701000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100701000000;
                current.Total50100701000000 = 0;
                if (current.cta_50100701001000 != null && current.cta_50100701001000.Total50100701001000 != 0)
                    current.Total50100701000000 += (Decimal)current.cta_50100701001000.Total50100701001000;
                if (current.cta_50100701002000 != null && current.cta_50100701002000.Total50100701002000 != 0)
                    current.Total50100701000000 += (Decimal)current.cta_50100701002000.Total50100701002000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100709900000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100709900000.cta_50100709901000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100709900000.cta_50100709901000;
                current.Total50100709901000 = 0;
                if (current.cta_50100709901010 != null)
                    current.Total50100709901000 += (Decimal)current.cta_50100709901010;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100709900000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100709900000.cta_50100709902000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100709900000.cta_50100709902000;
                current.Total50100709902000 = 0;
                if (current.cta_50100709902010 != null)
                    current.Total50100709902000 += (Decimal)current.cta_50100709902010;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100709900000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000.cta_50100709900000;
                current.Total50100709900000 = 0;
                if (current.cta_50100709901000 != null && current.cta_50100709901000.Total50100709901000 != 0)
                    current.Total50100709900000 += (Decimal)current.cta_50100709901000.Total50100709901000;
                if (current.cta_50100709902000 != null && current.cta_50100709902000.Total50100709902000 != 0)
                    current.Total50100709900000 += (Decimal)current.cta_50100709902000.Total50100709902000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100700000000;
                current.Total50100700000000 = 0;
                if (current.cta_50100700100000 != null && current.cta_50100700100000.Total50100700100000 != 0)
                    current.Total50100700000000 += (Decimal)current.cta_50100700100000.Total50100700100000;
                if (current.cta_50100700200000 != null && current.cta_50100700200000.Total50100700200000 != 0)
                    current.Total50100700000000 += (Decimal)current.cta_50100700200000.Total50100700200000;
                if (current.cta_50100700300000 != null && current.cta_50100700300000.Total50100700300000 != 0)
                    current.Total50100700000000 += (Decimal)current.cta_50100700300000.Total50100700300000;
                if (current.cta_50100700400000 != null && current.cta_50100700400000.Total50100700400000 != 0)
                    current.Total50100700000000 += (Decimal)current.cta_50100700400000.Total50100700400000;
                if (current.cta_50100700500000 != null && current.cta_50100700500000.Total50100700500000 != 0)
                    current.Total50100700000000 += (Decimal)current.cta_50100700500000.Total50100700500000;
                if (current.cta_50100700600000 != null && current.cta_50100700600000.Total50100700600000 != 0)
                    current.Total50100700000000 += (Decimal)current.cta_50100700600000.Total50100700600000;
                if (current.cta_50100700700000 != null && current.cta_50100700700000.Total50100700700000 != 0)
                    current.Total50100700000000 += (Decimal)current.cta_50100700700000.Total50100700700000;
                if (current.cta_50100700800000 != null && current.cta_50100700800000.Total50100700800000 != 0)
                    current.Total50100700000000 += (Decimal)current.cta_50100700800000.Total50100700800000;
                if (current.cta_50100700900000 != null && current.cta_50100700900000.Total50100700900000 != 0)
                    current.Total50100700000000 += (Decimal)current.cta_50100700900000.Total50100700900000;
                if (current.cta_50100701000000 != null && current.cta_50100701000000.Total50100701000000 != 0)
                    current.Total50100700000000 += (Decimal)current.cta_50100701000000.Total50100701000000;
                if (current.cta_50100709900000 != null && current.cta_50100709900000.Total50100709900000 != 0)
                    current.Total50100700000000 += (Decimal)current.cta_50100709900000.Total50100709900000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100800300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100800300000;
                current.Total50100800300000 = 0;
                if (current.cta_50100800301000 != null)
                    current.Total50100800300000 += (Decimal)current.cta_50100800301000;
                if (current.cta_50100800302000 != null)
                    current.Total50100800300000 += (Decimal)current.cta_50100800302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100800400000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100800400000;
                current.Total50100800400000 = 0;
                if (current.cta_50100800401000 != null)
                    current.Total50100800400000 += (Decimal)current.cta_50100800401000;
                if (current.cta_50100800402000 != null)
                    current.Total50100800400000 += (Decimal)current.cta_50100800402000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100800600000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100800600000;
                current.Total50100800600000 = 0;
                if (current.cta_50100800601000 != null)
                    current.Total50100800600000 += (Decimal)current.cta_50100800601000;
                if (current.cta_50100800602000 != null)
                    current.Total50100800600000 += (Decimal)current.cta_50100800602000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100800700000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100800700000;
                current.Total50100800700000 = 0;
                if (current.cta_50100800701000 != null)
                    current.Total50100800700000 += (Decimal)current.cta_50100800701000;
                if (current.cta_50100800702000 != null)
                    current.Total50100800700000 += (Decimal)current.cta_50100800702000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100800800000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100800800000;
                current.Total50100800800000 = 0;
                if (current.cta_50100800801000 != null)
                    current.Total50100800800000 += (Decimal)current.cta_50100800801000;
                if (current.cta_50100800802000 != null)
                    current.Total50100800800000 += (Decimal)current.cta_50100800802000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100801100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100801100000;
                current.Total50100801100000 = 0;
                if (current.cta_50100801101000 != null)
                    current.Total50100801100000 += (Decimal)current.cta_50100801101000;
                if (current.cta_50100801102000 != null)
                    current.Total50100801100000 += (Decimal)current.cta_50100801102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100801200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100801200000;
                current.Total50100801200000 = 0;
                if (current.cta_50100801201000 != null)
                    current.Total50100801200000 += (Decimal)current.cta_50100801201000;
                if (current.cta_50100801202000 != null)
                    current.Total50100801200000 += (Decimal)current.cta_50100801202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100801300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100801300000;
                current.Total50100801300000 = 0;
                if (current.cta_50100801301000 != null)
                    current.Total50100801300000 += (Decimal)current.cta_50100801301000;
                if (current.cta_50100801302000 != null)
                    current.Total50100801300000 += (Decimal)current.cta_50100801302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100801400000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100801400000;
                current.Total50100801400000 = 0;
                if (current.cta_50100801401000 != null)
                    current.Total50100801400000 += (Decimal)current.cta_50100801401000;
                if (current.cta_50100801402000 != null)
                    current.Total50100801400000 += (Decimal)current.cta_50100801402000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100801700000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100801700000;
                current.Total50100801700000 = 0;
                if (current.cta_50100801701000 != null)
                    current.Total50100801700000 += (Decimal)current.cta_50100801701000;
                if (current.cta_50100801702000 != null)
                    current.Total50100801700000 += (Decimal)current.cta_50100801702000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100802300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100802300000;
                current.Total50100802300000 = 0;
                if (current.cta_50100802301000 != null)
                    current.Total50100802300000 += (Decimal)current.cta_50100802301000;
                if (current.cta_50100802302000 != null)
                    current.Total50100802300000 += (Decimal)current.cta_50100802302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100802400000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100802400000;
                current.Total50100802400000 = 0;
                if (current.cta_50100802401000 != null)
                    current.Total50100802400000 += (Decimal)current.cta_50100802401000;
                if (current.cta_50100802402000 != null)
                    current.Total50100802400000 += (Decimal)current.cta_50100802402000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100802600000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100802600000;
                current.Total50100802600000 = 0;
                if (current.cta_50100802601000 != null)
                    current.Total50100802600000 += (Decimal)current.cta_50100802601000;
                if (current.cta_50100802602000 != null)
                    current.Total50100802600000 += (Decimal)current.cta_50100802602000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100802700000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100802700000;
                current.Total50100802700000 = 0;
                if (current.cta_50100802701000 != null)
                    current.Total50100802700000 += (Decimal)current.cta_50100802701000;
                if (current.cta_50100802702000 != null)
                    current.Total50100802700000 += (Decimal)current.cta_50100802702000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100802800000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100802800000;
                current.Total50100802800000 = 0;
                if (current.cta_50100802801000 != null)
                    current.Total50100802800000 += (Decimal)current.cta_50100802801000;
                if (current.cta_50100802802000 != null)
                    current.Total50100802800000 += (Decimal)current.cta_50100802802000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100803100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100803100000;
                current.Total50100803100000 = 0;
                if (current.cta_50100803101000 != null)
                    current.Total50100803100000 += (Decimal)current.cta_50100803101000;
                if (current.cta_50100803102000 != null)
                    current.Total50100803100000 += (Decimal)current.cta_50100803102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100803200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100803200000;
                current.Total50100803200000 = 0;
                if (current.cta_50100803201000 != null)
                    current.Total50100803200000 += (Decimal)current.cta_50100803201000;
                if (current.cta_50100803202000 != null)
                    current.Total50100803200000 += (Decimal)current.cta_50100803202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100803700000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000.cta_50100803700000;
                current.Total50100803700000 = 0;
                if (current.cta_50100803701000 != null)
                    current.Total50100803700000 += (Decimal)current.cta_50100803701000;
                if (current.cta_50100803702000 != null)
                    current.Total50100803700000 += (Decimal)current.cta_50100803702000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100800000000;
                current.Total50100800000000 = 0;
                if (current.cta_50100800300000 != null && current.cta_50100800300000.Total50100800300000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100800300000.Total50100800300000;
                if (current.cta_50100800400000 != null && current.cta_50100800400000.Total50100800400000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100800400000.Total50100800400000;
                if (current.cta_50100800600000 != null && current.cta_50100800600000.Total50100800600000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100800600000.Total50100800600000;
                if (current.cta_50100800700000 != null && current.cta_50100800700000.Total50100800700000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100800700000.Total50100800700000;
                if (current.cta_50100800800000 != null && current.cta_50100800800000.Total50100800800000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100800800000.Total50100800800000;
                if (current.cta_50100801100000 != null && current.cta_50100801100000.Total50100801100000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100801100000.Total50100801100000;
                if (current.cta_50100801200000 != null && current.cta_50100801200000.Total50100801200000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100801200000.Total50100801200000;
                if (current.cta_50100801300000 != null && current.cta_50100801300000.Total50100801300000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100801300000.Total50100801300000;
                if (current.cta_50100801400000 != null && current.cta_50100801400000.Total50100801400000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100801400000.Total50100801400000;
                if (current.cta_50100801700000 != null && current.cta_50100801700000.Total50100801700000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100801700000.Total50100801700000;
                if (current.cta_50100802300000 != null && current.cta_50100802300000.Total50100802300000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100802300000.Total50100802300000;
                if (current.cta_50100802400000 != null && current.cta_50100802400000.Total50100802400000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100802400000.Total50100802400000;
                if (current.cta_50100802600000 != null && current.cta_50100802600000.Total50100802600000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100802600000.Total50100802600000;
                if (current.cta_50100802700000 != null && current.cta_50100802700000.Total50100802700000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100802700000.Total50100802700000;
                if (current.cta_50100802800000 != null && current.cta_50100802800000.Total50100802800000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100802800000.Total50100802800000;
                if (current.cta_50100803100000 != null && current.cta_50100803100000.Total50100803100000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100803100000.Total50100803100000;
                if (current.cta_50100803200000 != null && current.cta_50100803200000.Total50100803200000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100803200000.Total50100803200000;
                if (current.cta_50100803700000 != null && current.cta_50100803700000.Total50100803700000 != 0)
                    current.Total50100800000000 += (Decimal)current.cta_50100803700000.Total50100803700000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100900700000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100900700000.cta_50100900701000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100900700000.cta_50100900701000;
                current.Total50100900701000 = 0;
                if (current.cta_50100900701040 != null)
                    current.Total50100900701000 += (Decimal)current.cta_50100900701040;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100900700000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100900700000.cta_50100900702000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100900700000.cta_50100900702000;
                current.Total50100900702000 = 0;
                if (current.cta_50100900702040 != null)
                    current.Total50100900702000 += (Decimal)current.cta_50100900702040;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100900700000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100900700000;
                current.Total50100900700000 = 0;
                if (current.cta_50100900701000 != null && current.cta_50100900701000.Total50100900701000 != 0)
                    current.Total50100900700000 += (Decimal)current.cta_50100900701000.Total50100900701000;
                if (current.cta_50100900702000 != null && current.cta_50100900702000.Total50100900702000 != 0)
                    current.Total50100900700000 += (Decimal)current.cta_50100900702000.Total50100900702000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901000000;
                current.Total50100901000000 = 0;
                if (current.cta_50100901001000 != null)
                    current.Total50100901000000 += (Decimal)current.cta_50100901001000;
                if (current.cta_50100901002000 != null)
                    current.Total50100901000000 += (Decimal)current.cta_50100901002000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901100000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901100000.cta_50100901101000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901100000.cta_50100901101000;
                current.Total50100901101000 = 0;
                if (current.cta_50100901101010 != null)
                    current.Total50100901101000 += (Decimal)current.cta_50100901101010;
                if (current.cta_50100901101040 != null)
                    current.Total50100901101000 += (Decimal)current.cta_50100901101040;
                if (current.cta_50100901101050 != null)
                    current.Total50100901101000 += (Decimal)current.cta_50100901101050;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901100000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901100000.cta_50100901102000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901100000.cta_50100901102000;
                current.Total50100901102000 = 0;
                if (current.cta_50100901102010 != null)
                    current.Total50100901102000 += (Decimal)current.cta_50100901102010;
                if (current.cta_50100901102040 != null)
                    current.Total50100901102000 += (Decimal)current.cta_50100901102040;
                if (current.cta_50100901102050 != null)
                    current.Total50100901102000 += (Decimal)current.cta_50100901102050;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901100000;
                current.Total50100901100000 = 0;
                if (current.cta_50100901101000 != null && current.cta_50100901101000.Total50100901101000 != 0)
                    current.Total50100901100000 += (Decimal)current.cta_50100901101000.Total50100901101000;
                if (current.cta_50100901102000 != null && current.cta_50100901102000.Total50100901102000 != 0)
                    current.Total50100901100000 += (Decimal)current.cta_50100901102000.Total50100901102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901200000;
                current.Total50100901200000 = 0;
                if (current.cta_50100901201000 != null)
                    current.Total50100901200000 += (Decimal)current.cta_50100901201000;
                if (current.cta_50100901202000 != null)
                    current.Total50100901200000 += (Decimal)current.cta_50100901202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901300000;
                current.Total50100901300000 = 0;
                if (current.cta_50100901301000 != null)
                    current.Total50100901300000 += (Decimal)current.cta_50100901301000;
                if (current.cta_50100901302000 != null)
                    current.Total50100901300000 += (Decimal)current.cta_50100901302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901400000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901400000;
                current.Total50100901400000 = 0;
                if (current.cta_50100901401000 != null)
                    current.Total50100901400000 += (Decimal)current.cta_50100901401000;
                if (current.cta_50100901402000 != null)
                    current.Total50100901400000 += (Decimal)current.cta_50100901402000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901600000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901600000;
                current.Total50100901600000 = 0;
                if (current.cta_50100901601000 != null)
                    current.Total50100901600000 += (Decimal)current.cta_50100901601000;
                if (current.cta_50100901602000 != null)
                    current.Total50100901600000 += (Decimal)current.cta_50100901602000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901700000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901700000;
                current.Total50100901700000 = 0;
                if (current.cta_50100901701000 != null)
                    current.Total50100901700000 += (Decimal)current.cta_50100901701000;
                if (current.cta_50100901702000 != null)
                    current.Total50100901700000 += (Decimal)current.cta_50100901702000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901800000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100901800000;
                current.Total50100901800000 = 0;
                if (current.cta_50100901801000 != null)
                    current.Total50100901800000 += (Decimal)current.cta_50100901801000;
                if (current.cta_50100901802000 != null)
                    current.Total50100901800000 += (Decimal)current.cta_50100901802000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100902000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100902000000;
                current.Total50100902000000 = 0;
                if (current.cta_50100902001000 != null)
                    current.Total50100902000000 += (Decimal)current.cta_50100902001000;
                if (current.cta_50100902002000 != null)
                    current.Total50100902000000 += (Decimal)current.cta_50100902002000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100902100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100902100000;
                current.Total50100902100000 = 0;
                if (current.cta_50100902101000 != null)
                    current.Total50100902100000 += (Decimal)current.cta_50100902101000;
                if (current.cta_50100902102000 != null)
                    current.Total50100902100000 += (Decimal)current.cta_50100902102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100902200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100902200000;
                current.Total50100902200000 = 0;
                if (current.cta_50100902201000 != null)
                    current.Total50100902200000 += (Decimal)current.cta_50100902201000;
                if (current.cta_50100902202000 != null)
                    current.Total50100902200000 += (Decimal)current.cta_50100902202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100902400000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100902400000;
                current.Total50100902400000 = 0;
                if (current.cta_50100902401000 != null)
                    current.Total50100902400000 += (Decimal)current.cta_50100902401000;
                if (current.cta_50100902402000 != null)
                    current.Total50100902400000 += (Decimal)current.cta_50100902402000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100902500000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100902500000;
                current.Total50100902500000 = 0;
                if (current.cta_50100902501000 != null)
                    current.Total50100902500000 += (Decimal)current.cta_50100902501000;
                if (current.cta_50100902502000 != null)
                    current.Total50100902500000 += (Decimal)current.cta_50100902502000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100909900000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000.cta_50100909900000;
                current.Total50100909900000 = 0;
                if (current.cta_50100909901000 != null)
                    current.Total50100909900000 += (Decimal)current.cta_50100909901000;
                if (current.cta_50100909902000 != null)
                    current.Total50100909900000 += (Decimal)current.cta_50100909902000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null && modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000.cta_50100900000000;
                current.Total50100900000000 = 0;
                if (current.cta_50100900700000 != null && current.cta_50100900700000.Total50100900700000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100900700000.Total50100900700000;
                if (current.cta_50100901000000 != null && current.cta_50100901000000.Total50100901000000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100901000000.Total50100901000000;
                if (current.cta_50100901100000 != null && current.cta_50100901100000.Total50100901100000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100901100000.Total50100901100000;
                if (current.cta_50100901200000 != null && current.cta_50100901200000.Total50100901200000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100901200000.Total50100901200000;
                if (current.cta_50100901300000 != null && current.cta_50100901300000.Total50100901300000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100901300000.Total50100901300000;
                if (current.cta_50100901400000 != null && current.cta_50100901400000.Total50100901400000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100901400000.Total50100901400000;
                if (current.cta_50100901600000 != null && current.cta_50100901600000.Total50100901600000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100901600000.Total50100901600000;
                if (current.cta_50100901700000 != null && current.cta_50100901700000.Total50100901700000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100901700000.Total50100901700000;
                if (current.cta_50100901800000 != null && current.cta_50100901800000.Total50100901800000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100901800000.Total50100901800000;
                if (current.cta_50100902000000 != null && current.cta_50100902000000.Total50100902000000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100902000000.Total50100902000000;
                if (current.cta_50100902100000 != null && current.cta_50100902100000.Total50100902100000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100902100000.Total50100902100000;
                if (current.cta_50100902200000 != null && current.cta_50100902200000.Total50100902200000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100902200000.Total50100902200000;
                if (current.cta_50100902400000 != null && current.cta_50100902400000.Total50100902400000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100902400000.Total50100902400000;
                if (current.cta_50100902500000 != null && current.cta_50100902500000.Total50100902500000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100902500000.Total50100902500000;
                if (current.cta_50100909900000 != null && current.cta_50100909900000.Total50100909900000 != 0)
                    current.Total50100900000000 += (Decimal)current.cta_50100909900000.Total50100909900000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50100000000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50100000000000;
                current.Total50100000000000 = 0;
                if (current.cta_50101000000000 != null && current.cta_50101000000000.Total50101000000000 != 0)
                    current.Total50100000000000 += (Decimal)current.cta_50101000000000.Total50101000000000;
                if (current.cta_50102000000000 != null && current.cta_50102000000000.Total50102000000000 != 0)
                    current.Total50100000000000 += (Decimal)current.cta_50102000000000.Total50102000000000;
                if (current.cta_50100100000000 != null && current.cta_50100100000000.Total50100100000000 != 0)
                    current.Total50100000000000 += (Decimal)current.cta_50100100000000.Total50100100000000;
                if (current.cta_50100200000000 != null && current.cta_50100200000000.Total50100200000000 != 0)
                    current.Total50100000000000 += (Decimal)current.cta_50100200000000.Total50100200000000;
                if (current.cta_50100300000000 != null && current.cta_50100300000000.Total50100300000000 != 0)
                    current.Total50100000000000 += (Decimal)current.cta_50100300000000.Total50100300000000;
                if (current.cta_50100400000000 != null && current.cta_50100400000000.Total50100400000000 != 0)
                    current.Total50100000000000 += (Decimal)current.cta_50100400000000.Total50100400000000;
                if (current.cta_50100500000000 != null && current.cta_50100500000000.Total50100500000000 != 0)
                    current.Total50100000000000 += (Decimal)current.cta_50100500000000.Total50100500000000;
                if (current.cta_50100700000000 != null && current.cta_50100700000000.Total50100700000000 != 0)
                    current.Total50100000000000 += (Decimal)current.cta_50100700000000.Total50100700000000;
                if (current.cta_50100800000000 != null && current.cta_50100800000000.Total50100800000000 != 0)
                    current.Total50100000000000 += (Decimal)current.cta_50100800000000.Total50100800000000;
                if (current.cta_50100900000000 != null && current.cta_50100900000000.Total50100900000000 != 0)
                    current.Total50100000000000 += (Decimal)current.cta_50100900000000.Total50100900000000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100100000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100100000.cta_50200100101000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100100000.cta_50200100101000;
                current.Total50200100101000 = 0;
                if (current.cta_50200100101010 != null)
                    current.Total50200100101000 += (Decimal)current.cta_50200100101010;
                if (current.cta_50200100101020 != null)
                    current.Total50200100101000 += (Decimal)current.cta_50200100101020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100100000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100100000.cta_50200100102000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100100000.cta_50200100102000;
                current.Total50200100102000 = 0;
                if (current.cta_50200100102010 != null)
                    current.Total50200100102000 += (Decimal)current.cta_50200100102010;
                if (current.cta_50200100102020 != null)
                    current.Total50200100102000 += (Decimal)current.cta_50200100102020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100100000;
                current.Total50200100100000 = 0;
                if (current.cta_50200100101000 != null && current.cta_50200100101000.Total50200100101000 != 0)
                    current.Total50200100100000 += (Decimal)current.cta_50200100101000.Total50200100101000;
                if (current.cta_50200100102000 != null && current.cta_50200100102000.Total50200100102000 != 0)
                    current.Total50200100100000 += (Decimal)current.cta_50200100102000.Total50200100102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100200000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100200000.cta_50200100201000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100200000.cta_50200100201000;
                current.Total50200100201000 = 0;
                if (current.cta_50200100201010 != null)
                    current.Total50200100201000 += (Decimal)current.cta_50200100201010;
                if (current.cta_50200100201020 != null)
                    current.Total50200100201000 += (Decimal)current.cta_50200100201020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100200000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100200000.cta_50200100202000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100200000.cta_50200100202000;
                current.Total50200100202000 = 0;
                if (current.cta_50200100202010 != null)
                    current.Total50200100202000 += (Decimal)current.cta_50200100202010;
                if (current.cta_50200100202020 != null)
                    current.Total50200100202000 += (Decimal)current.cta_50200100202020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000.cta_50200100200000;
                current.Total50200100200000 = 0;
                if (current.cta_50200100201000 != null && current.cta_50200100201000.Total50200100201000 != 0)
                    current.Total50200100200000 += (Decimal)current.cta_50200100201000.Total50200100201000;
                if (current.cta_50200100202000 != null && current.cta_50200100202000.Total50200100202000 != 0)
                    current.Total50200100200000 += (Decimal)current.cta_50200100202000.Total50200100202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200100000000;
                current.Total50200100000000 = 0;
                if (current.cta_50200100100000 != null && current.cta_50200100100000.Total50200100100000 != 0)
                    current.Total50200100000000 += (Decimal)current.cta_50200100100000.Total50200100100000;
                if (current.cta_50200100200000 != null && current.cta_50200100200000.Total50200100200000 != 0)
                    current.Total50200100000000 += (Decimal)current.cta_50200100200000.Total50200100200000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200100000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200100000.cta_50200200101000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200100000.cta_50200200101000;
                current.Total50200200101000 = 0;
                if (current.cta_50200200101010 != null)
                    current.Total50200200101000 += (Decimal)current.cta_50200200101010;
                if (current.cta_50200200101020 != null)
                    current.Total50200200101000 += (Decimal)current.cta_50200200101020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200100000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200100000.cta_50200200102000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200100000.cta_50200200102000;
                current.Total50200200102000 = 0;
                if (current.cta_50200200102010 != null)
                    current.Total50200200102000 += (Decimal)current.cta_50200200102010;
                if (current.cta_50200200102020 != null)
                    current.Total50200200102000 += (Decimal)current.cta_50200200102020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200100000;
                current.Total50200200100000 = 0;
                if (current.cta_50200200101000 != null && current.cta_50200200101000.Total50200200101000 != 0)
                    current.Total50200200100000 += (Decimal)current.cta_50200200101000.Total50200200101000;
                if (current.cta_50200200102000 != null && current.cta_50200200102000.Total50200200102000 != 0)
                    current.Total50200200100000 += (Decimal)current.cta_50200200102000.Total50200200102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200200000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200200000.cta_50200200201000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200200000.cta_50200200201000;
                current.Total50200200201000 = 0;
                if (current.cta_50200200201010 != null)
                    current.Total50200200201000 += (Decimal)current.cta_50200200201010;
                if (current.cta_50200200201020 != null)
                    current.Total50200200201000 += (Decimal)current.cta_50200200201020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200200000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200200000.cta_50200200202000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200200000.cta_50200200202000;
                current.Total50200200202000 = 0;
                if (current.cta_50200200202010 != null)
                    current.Total50200200202000 += (Decimal)current.cta_50200200202010;
                if (current.cta_50200200202020 != null)
                    current.Total50200200202000 += (Decimal)current.cta_50200200202020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000.cta_50200200200000;
                current.Total50200200200000 = 0;
                if (current.cta_50200200201000 != null && current.cta_50200200201000.Total50200200201000 != 0)
                    current.Total50200200200000 += (Decimal)current.cta_50200200201000.Total50200200201000;
                if (current.cta_50200200202000 != null && current.cta_50200200202000.Total50200200202000 != 0)
                    current.Total50200200200000 += (Decimal)current.cta_50200200202000.Total50200200202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200200000000;
                current.Total50200200000000 = 0;
                if (current.cta_50200200100000 != null && current.cta_50200200100000.Total50200200100000 != 0)
                    current.Total50200200000000 += (Decimal)current.cta_50200200100000.Total50200200100000;
                if (current.cta_50200200200000 != null && current.cta_50200200200000.Total50200200200000 != 0)
                    current.Total50200200000000 += (Decimal)current.cta_50200200200000.Total50200200200000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300100000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300100000.cta_50200300101000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300100000.cta_50200300101000;
                current.Total50200300101000 = 0;
                if (current.cta_50200300101010 != null)
                    current.Total50200300101000 += (Decimal)current.cta_50200300101010;
                if (current.cta_50200300101020 != null)
                    current.Total50200300101000 += (Decimal)current.cta_50200300101020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300100000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300100000.cta_50200300102000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300100000.cta_50200300102000;
                current.Total50200300102000 = 0;
                if (current.cta_50200300102010 != null)
                    current.Total50200300102000 += (Decimal)current.cta_50200300102010;
                if (current.cta_50200300102020 != null)
                    current.Total50200300102000 += (Decimal)current.cta_50200300102020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300100000;
                current.Total50200300100000 = 0;
                if (current.cta_50200300101000 != null && current.cta_50200300101000.Total50200300101000 != 0)
                    current.Total50200300100000 += (Decimal)current.cta_50200300101000.Total50200300101000;
                if (current.cta_50200300102000 != null && current.cta_50200300102000.Total50200300102000 != 0)
                    current.Total50200300100000 += (Decimal)current.cta_50200300102000.Total50200300102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300200000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300200000.cta_50200300201000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300200000.cta_50200300201000;
                current.Total50200300201000 = 0;
                if (current.cta_50200300201010 != null)
                    current.Total50200300201000 += (Decimal)current.cta_50200300201010;
                if (current.cta_50200300201020 != null)
                    current.Total50200300201000 += (Decimal)current.cta_50200300201020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300200000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300200000.cta_50200300202000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300200000.cta_50200300202000;
                current.Total50200300202000 = 0;
                if (current.cta_50200300202010 != null)
                    current.Total50200300202000 += (Decimal)current.cta_50200300202010;
                if (current.cta_50200300202020 != null)
                    current.Total50200300202000 += (Decimal)current.cta_50200300202020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000.cta_50200300200000;
                current.Total50200300200000 = 0;
                if (current.cta_50200300201000 != null && current.cta_50200300201000.Total50200300201000 != 0)
                    current.Total50200300200000 += (Decimal)current.cta_50200300201000.Total50200300201000;
                if (current.cta_50200300202000 != null && current.cta_50200300202000.Total50200300202000 != 0)
                    current.Total50200300200000 += (Decimal)current.cta_50200300202000.Total50200300202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null && modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000.cta_50200300000000;
                current.Total50200300000000 = 0;
                if (current.cta_50200300100000 != null && current.cta_50200300100000.Total50200300100000 != 0)
                    current.Total50200300000000 += (Decimal)current.cta_50200300100000.Total50200300100000;
                if (current.cta_50200300200000 != null && current.cta_50200300200000.Total50200300200000 != 0)
                    current.Total50200300000000 += (Decimal)current.cta_50200300200000.Total50200300200000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50200000000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50200000000000;
                current.Total50200000000000 = 0;
                if (current.cta_50200100000000 != null && current.cta_50200100000000.Total50200100000000 != 0)
                    current.Total50200000000000 += (Decimal)current.cta_50200100000000.Total50200100000000;
                if (current.cta_50200200000000 != null && current.cta_50200200000000.Total50200200000000 != 0)
                    current.Total50200000000000 += (Decimal)current.cta_50200200000000.Total50200200000000;
                if (current.cta_50200300000000 != null && current.cta_50200300000000.Total50200300000000 != 0)
                    current.Total50200000000000 += (Decimal)current.cta_50200300000000.Total50200300000000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100100000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100100000.cta_50300100101000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100100000.cta_50300100101000;
                current.Total50300100101000 = 0;
                if (current.cta_50300100101010 != null)
                    current.Total50300100101000 += (Decimal)current.cta_50300100101010;
                if (current.cta_50300100101020 != null)
                    current.Total50300100101000 += (Decimal)current.cta_50300100101020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100100000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100100000.cta_50300100102000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100100000.cta_50300100102000;
                current.Total50300100102000 = 0;
                if (current.cta_50300100102010 != null)
                    current.Total50300100102000 += (Decimal)current.cta_50300100102010;
                if (current.cta_50300100102020 != null)
                    current.Total50300100102000 += (Decimal)current.cta_50300100102020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100100000;
                current.Total50300100100000 = 0;
                if (current.cta_50300100101000 != null && current.cta_50300100101000.Total50300100101000 != 0)
                    current.Total50300100100000 += (Decimal)current.cta_50300100101000.Total50300100101000;
                if (current.cta_50300100102000 != null && current.cta_50300100102000.Total50300100102000 != 0)
                    current.Total50300100100000 += (Decimal)current.cta_50300100102000.Total50300100102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100200000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100200000.cta_50300100201000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100200000.cta_50300100201000;
                current.Total50300100201000 = 0;
                if (current.cta_50300100201010 != null)
                    current.Total50300100201000 += (Decimal)current.cta_50300100201010;
                if (current.cta_50300100201020 != null)
                    current.Total50300100201000 += (Decimal)current.cta_50300100201020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100200000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100200000.cta_50300100202000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100200000.cta_50300100202000;
                current.Total50300100202000 = 0;
                if (current.cta_50300100202010 != null)
                    current.Total50300100202000 += (Decimal)current.cta_50300100202010;
                if (current.cta_50300100202020 != null)
                    current.Total50300100202000 += (Decimal)current.cta_50300100202020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000.cta_50300100200000;
                current.Total50300100200000 = 0;
                if (current.cta_50300100201000 != null && current.cta_50300100201000.Total50300100201000 != 0)
                    current.Total50300100200000 += (Decimal)current.cta_50300100201000.Total50300100201000;
                if (current.cta_50300100202000 != null && current.cta_50300100202000.Total50300100202000 != 0)
                    current.Total50300100200000 += (Decimal)current.cta_50300100202000.Total50300100202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300100000000;
                current.Total50300100000000 = 0;
                if (current.cta_50300100100000 != null && current.cta_50300100100000.Total50300100100000 != 0)
                    current.Total50300100000000 += (Decimal)current.cta_50300100100000.Total50300100100000;
                if (current.cta_50300100200000 != null && current.cta_50300100200000.Total50300100200000 != 0)
                    current.Total50300100000000 += (Decimal)current.cta_50300100200000.Total50300100200000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300200000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300200000000.cta_50300200100000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300200000000.cta_50300200100000.cta_50300200101000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300200000000.cta_50300200100000.cta_50300200101000;
                current.Total50300200101000 = 0;
                if (current.cta_50300200101010 != null)
                    current.Total50300200101000 += (Decimal)current.cta_50300200101010;
                if (current.cta_50300200101020 != null)
                    current.Total50300200101000 += (Decimal)current.cta_50300200101020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300200000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300200000000.cta_50300200100000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300200000000.cta_50300200100000.cta_50300200102000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300200000000.cta_50300200100000.cta_50300200102000;
                current.Total50300200102000 = 0;
                if (current.cta_50300200102010 != null)
                    current.Total50300200102000 += (Decimal)current.cta_50300200102010;
                if (current.cta_50300200102020 != null)
                    current.Total50300200102000 += (Decimal)current.cta_50300200102020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300200000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300200000000.cta_50300200100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300200000000.cta_50300200100000;
                current.Total50300200100000 = 0;
                if (current.cta_50300200101000 != null && current.cta_50300200101000.Total50300200101000 != 0)
                    current.Total50300200100000 += (Decimal)current.cta_50300200101000.Total50300200101000;
                if (current.cta_50300200102000 != null && current.cta_50300200102000.Total50300200102000 != 0)
                    current.Total50300200100000 += (Decimal)current.cta_50300200102000.Total50300200102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300200000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300200000000;
                current.Total50300200000000 = 0;
                if (current.cta_50300200100000 != null && current.cta_50300200100000.Total50300200100000 != 0)
                    current.Total50300200000000 += (Decimal)current.cta_50300200100000.Total50300200100000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300300000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300300000000.cta_50300300100000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300300000000.cta_50300300100000.cta_50300300101000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300300000000.cta_50300300100000.cta_50300300101000;
                current.Total50300300101000 = 0;
                if (current.cta_50300300101010 != null)
                    current.Total50300300101000 += (Decimal)current.cta_50300300101010;
                if (current.cta_50300300101020 != null)
                    current.Total50300300101000 += (Decimal)current.cta_50300300101020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300300000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300300000000.cta_50300300100000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300300000000.cta_50300300100000.cta_50300300102000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300300000000.cta_50300300100000.cta_50300300102000;
                current.Total50300300102000 = 0;
                if (current.cta_50300300102010 != null)
                    current.Total50300300102000 += (Decimal)current.cta_50300300102010;
                if (current.cta_50300300102020 != null)
                    current.Total50300300102000 += (Decimal)current.cta_50300300102020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300300000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300300000000.cta_50300300100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300300000000.cta_50300300100000;
                current.Total50300300100000 = 0;
                if (current.cta_50300300101000 != null && current.cta_50300300101000.Total50300300101000 != 0)
                    current.Total50300300100000 += (Decimal)current.cta_50300300101000.Total50300300101000;
                if (current.cta_50300300102000 != null && current.cta_50300300102000.Total50300300102000 != 0)
                    current.Total50300300100000 += (Decimal)current.cta_50300300102000.Total50300300102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null && modelo.cta_50000000000000.cta_50300000000000.cta_50300300000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000.cta_50300300000000;
                current.Total50300300000000 = 0;
                if (current.cta_50300300100000 != null && current.cta_50300300100000.Total50300300100000 != 0)
                    current.Total50300300000000 += (Decimal)current.cta_50300300100000.Total50300300100000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50300000000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50300000000000;
                current.Total50300000000000 = 0;
                if (current.cta_50300100000000 != null && current.cta_50300100000000.Total50300100000000 != 0)
                    current.Total50300000000000 += (Decimal)current.cta_50300100000000.Total50300100000000;
                if (current.cta_50300200000000 != null && current.cta_50300200000000.Total50300200000000 != 0)
                    current.Total50300000000000 += (Decimal)current.cta_50300200000000.Total50300200000000;
                if (current.cta_50300300000000 != null && current.cta_50300300000000.Total50300300000000 != 0)
                    current.Total50300000000000 += (Decimal)current.cta_50300300000000.Total50300300000000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500100000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500100000000.cta_50500100100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500100000000.cta_50500100100000;
                current.Total50500100100000 = 0;
                if (current.cta_50500100101000 != null)
                    current.Total50500100100000 += (Decimal)current.cta_50500100101000;
                if (current.cta_50500100102000 != null)
                    current.Total50500100100000 += (Decimal)current.cta_50500100102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500100000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500100000000.cta_50500100200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500100000000.cta_50500100200000;
                current.Total50500100200000 = 0;
                if (current.cta_50500100201000 != null)
                    current.Total50500100200000 += (Decimal)current.cta_50500100201000;
                if (current.cta_50500100202000 != null)
                    current.Total50500100200000 += (Decimal)current.cta_50500100202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500100000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500100000000.cta_50500100300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500100000000.cta_50500100300000;
                current.Total50500100300000 = 0;
                if (current.cta_50500100301000 != null)
                    current.Total50500100300000 += (Decimal)current.cta_50500100301000;
                if (current.cta_50500100302000 != null)
                    current.Total50500100300000 += (Decimal)current.cta_50500100302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500100000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500100000000;
                current.Total50500100000000 = 0;
                if (current.cta_50500100100000 != null && current.cta_50500100100000.Total50500100100000 != 0)
                    current.Total50500100000000 += (Decimal)current.cta_50500100100000.Total50500100100000;
                if (current.cta_50500100200000 != null && current.cta_50500100200000.Total50500100200000 != 0)
                    current.Total50500100000000 += (Decimal)current.cta_50500100200000.Total50500100200000;
                if (current.cta_50500100300000 != null && current.cta_50500100300000.Total50500100300000 != 0)
                    current.Total50500100000000 += (Decimal)current.cta_50500100300000.Total50500100300000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200100000;
                current.Total50500200100000 = 0;
                if (current.cta_50500200101000 != null)
                    current.Total50500200100000 += (Decimal)current.cta_50500200101000;
                if (current.cta_50500200102000 != null)
                    current.Total50500200100000 += (Decimal)current.cta_50500200102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200200000;
                current.Total50500200200000 = 0;
                if (current.cta_50500200201000 != null)
                    current.Total50500200200000 += (Decimal)current.cta_50500200201000;
                if (current.cta_50500200202000 != null)
                    current.Total50500200200000 += (Decimal)current.cta_50500200202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200300000;
                current.Total50500200300000 = 0;
                if (current.cta_50500200301000 != null)
                    current.Total50500200300000 += (Decimal)current.cta_50500200301000;
                if (current.cta_50500200302000 != null)
                    current.Total50500200300000 += (Decimal)current.cta_50500200302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200500000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200500000.cta_50500200501000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200500000.cta_50500200501000;
                current.Total50500200501000 = 0;
                if (current.cta_50500200501010 != null)
                    current.Total50500200501000 += (Decimal)current.cta_50500200501010;
                if (current.cta_50500200501020 != null)
                    current.Total50500200501000 += (Decimal)current.cta_50500200501020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200500000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200500000.cta_50500200502000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200500000.cta_50500200502000;
                current.Total50500200502000 = 0;
                if (current.cta_50500200502010 != null)
                    current.Total50500200502000 += (Decimal)current.cta_50500200502010;
                if (current.cta_50500200502020 != null)
                    current.Total50500200502000 += (Decimal)current.cta_50500200502020;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200500000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200500000;
                current.Total50500200500000 = 0;
                if (current.cta_50500200501000 != null && current.cta_50500200501000.Total50500200501000 != 0)
                    current.Total50500200500000 += (Decimal)current.cta_50500200501000.Total50500200501000;
                if (current.cta_50500200502000 != null && current.cta_50500200502000.Total50500200502000 != 0)
                    current.Total50500200500000 += (Decimal)current.cta_50500200502000.Total50500200502000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200600000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200600000.cta_50500200601000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200600000.cta_50500200601000;
                current.Total50500200601000 = 0;
                if (current.cta_50500200601010 != null)
                    current.Total50500200601000 += (Decimal)current.cta_50500200601010;
                if (current.cta_50500200601020 != null)
                    current.Total50500200601000 += (Decimal)current.cta_50500200601020;
                if (current.cta_50500200601030 != null)
                    current.Total50500200601000 += (Decimal)current.cta_50500200601030;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200600000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200600000.cta_50500200602000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200600000.cta_50500200602000;
                current.Total50500200602000 = 0;
                if (current.cta_50500200602010 != null)
                    current.Total50500200602000 += (Decimal)current.cta_50500200602010;
                if (current.cta_50500200602020 != null)
                    current.Total50500200602000 += (Decimal)current.cta_50500200602020;
                if (current.cta_50500200602030 != null)
                    current.Total50500200602000 += (Decimal)current.cta_50500200602030;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200600000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000.cta_50500200600000;
                current.Total50500200600000 = 0;
                if (current.cta_50500200601000 != null && current.cta_50500200601000.Total50500200601000 != 0)
                    current.Total50500200600000 += (Decimal)current.cta_50500200601000.Total50500200601000;
                if (current.cta_50500200602000 != null && current.cta_50500200602000.Total50500200602000 != 0)
                    current.Total50500200600000 += (Decimal)current.cta_50500200602000.Total50500200602000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500200000000;
                current.Total50500200000000 = 0;
                if (current.cta_50500200100000 != null && current.cta_50500200100000.Total50500200100000 != 0)
                    current.Total50500200000000 += (Decimal)current.cta_50500200100000.Total50500200100000;
                if (current.cta_50500200200000 != null && current.cta_50500200200000.Total50500200200000 != 0)
                    current.Total50500200000000 += (Decimal)current.cta_50500200200000.Total50500200200000;
                if (current.cta_50500200300000 != null && current.cta_50500200300000.Total50500200300000 != 0)
                    current.Total50500200000000 += (Decimal)current.cta_50500200300000.Total50500200300000;
                if (current.cta_50500200500000 != null && current.cta_50500200500000.Total50500200500000 != 0)
                    current.Total50500200000000 += (Decimal)current.cta_50500200500000.Total50500200500000;
                if (current.cta_50500200600000 != null && current.cta_50500200600000.Total50500200600000 != 0)
                    current.Total50500200000000 += (Decimal)current.cta_50500200600000.Total50500200600000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500300000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500300000000.cta_50500300100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500300000000.cta_50500300100000;
                current.Total50500300100000 = 0;
                if (current.cta_50500300101000 != null)
                    current.Total50500300100000 += (Decimal)current.cta_50500300101000;
                if (current.cta_50500300102000 != null)
                    current.Total50500300100000 += (Decimal)current.cta_50500300102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500300000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500300000000;
                current.Total50500300000000 = 0;
                if (current.cta_50500300100000 != null && current.cta_50500300100000.Total50500300100000 != 0)
                    current.Total50500300000000 += (Decimal)current.cta_50500300100000.Total50500300100000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500400000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500400000000.cta_50500400100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500400000000.cta_50500400100000;
                current.Total50500400100000 = 0;
                if (current.cta_50500400101000 != null)
                    current.Total50500400100000 += (Decimal)current.cta_50500400101000;
                if (current.cta_50500400102000 != null)
                    current.Total50500400100000 += (Decimal)current.cta_50500400102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500400000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500400000000.cta_50500400200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500400000000.cta_50500400200000;
                current.Total50500400200000 = 0;
                if (current.cta_50500400201000 != null)
                    current.Total50500400200000 += (Decimal)current.cta_50500400201000;
                if (current.cta_50500400202000 != null)
                    current.Total50500400200000 += (Decimal)current.cta_50500400202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500400000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500400000000.cta_50500400400000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500400000000.cta_50500400400000;
                current.Total50500400400000 = 0;
                if (current.cta_50500400401000 != null)
                    current.Total50500400400000 += (Decimal)current.cta_50500400401000;
                if (current.cta_50500400402000 != null)
                    current.Total50500400400000 += (Decimal)current.cta_50500400402000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500400000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500400000000.cta_50500409900000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500400000000.cta_50500409900000;
                current.Total50500409900000 = 0;
                if (current.cta_50500409901000 != null)
                    current.Total50500409900000 += (Decimal)current.cta_50500409901000;
                if (current.cta_50500409902000 != null)
                    current.Total50500409900000 += (Decimal)current.cta_50500409902000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null && modelo.cta_50000000000000.cta_50500000000000.cta_50500400000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000.cta_50500400000000;
                current.Total50500400000000 = 0;
                if (current.cta_50500400100000 != null && current.cta_50500400100000.Total50500400100000 != 0)
                    current.Total50500400000000 += (Decimal)current.cta_50500400100000.Total50500400100000;
                if (current.cta_50500400200000 != null && current.cta_50500400200000.Total50500400200000 != 0)
                    current.Total50500400000000 += (Decimal)current.cta_50500400200000.Total50500400200000;
                if (current.cta_50500400400000 != null && current.cta_50500400400000.Total50500400400000 != 0)
                    current.Total50500400000000 += (Decimal)current.cta_50500400400000.Total50500400400000;
                if (current.cta_50500409900000 != null && current.cta_50500409900000.Total50500409900000 != 0)
                    current.Total50500400000000 += (Decimal)current.cta_50500409900000.Total50500409900000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50500000000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50500000000000;
                current.Total50500000000000 = 0;
                if (current.cta_50500100000000 != null && current.cta_50500100000000.Total50500100000000 != 0)
                    current.Total50500000000000 += (Decimal)current.cta_50500100000000.Total50500100000000;
                if (current.cta_50500200000000 != null && current.cta_50500200000000.Total50500200000000 != 0)
                    current.Total50500000000000 += (Decimal)current.cta_50500200000000.Total50500200000000;
                if (current.cta_50500300000000 != null && current.cta_50500300000000.Total50500300000000 != 0)
                    current.Total50500000000000 += (Decimal)current.cta_50500300000000.Total50500300000000;
                if (current.cta_50500400000000 != null && current.cta_50500400000000.Total50500400000000 != 0)
                    current.Total50500000000000 += (Decimal)current.cta_50500400000000.Total50500400000000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000.cta_50600102000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000.cta_50600102000000;
                current.Total50600102000000 = 0;
                if (current.cta_50600102001000 != null)
                    current.Total50600102000000 += (Decimal)current.cta_50600102001000;
                if (current.cta_50600102002000 != null)
                    current.Total50600102000000 += (Decimal)current.cta_50600102002000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000.cta_50600102600000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000.cta_50600102600000.cta_50600102601000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000.cta_50600102600000.cta_50600102601000;
                current.Total50600102601000 = 0;
                if (current.cta_50600102601990 != null)
                    current.Total50600102601000 += (Decimal)current.cta_50600102601990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000.cta_50600102600000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000.cta_50600102600000.cta_50600102602000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000.cta_50600102600000.cta_50600102602000;
                current.Total50600102602000 = 0;
                if (current.cta_50600102602990 != null)
                    current.Total50600102602000 += (Decimal)current.cta_50600102602990;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000.cta_50600102600000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000.cta_50600102600000;
                current.Total50600102600000 = 0;
                if (current.cta_50600102601000 != null && current.cta_50600102601000.Total50600102601000 != 0)
                    current.Total50600102600000 += (Decimal)current.cta_50600102601000.Total50600102601000;
                if (current.cta_50600102602000 != null && current.cta_50600102602000.Total50600102602000 != 0)
                    current.Total50600102600000 += (Decimal)current.cta_50600102602000.Total50600102602000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000.cta_50600109900000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000.cta_50600109900000;
                current.Total50600109900000 = 0;
                if (current.cta_50600109901000 != null)
                    current.Total50600109900000 += (Decimal)current.cta_50600109901000;
                if (current.cta_50600109902000 != null)
                    current.Total50600109900000 += (Decimal)current.cta_50600109902000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600100000000;
                current.Total50600100000000 = 0;
                if (current.cta_50600102000000 != null && current.cta_50600102000000.Total50600102000000 != 0)
                    current.Total50600100000000 += (Decimal)current.cta_50600102000000.Total50600102000000;
                if (current.cta_50600102600000 != null && current.cta_50600102600000.Total50600102600000 != 0)
                    current.Total50600100000000 += (Decimal)current.cta_50600102600000.Total50600102600000;
                if (current.cta_50600109900000 != null && current.cta_50600109900000.Total50600109900000 != 0)
                    current.Total50600100000000 += (Decimal)current.cta_50600109900000.Total50600109900000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200100000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200100000.cta_50600200101000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200100000.cta_50600200101000;
                current.Total50600200101000 = 0;
                if (current.cta_50600200101010 != null)
                    current.Total50600200101000 += (Decimal)current.cta_50600200101010;
                if (current.cta_50600200101020 != null)
                    current.Total50600200101000 += (Decimal)current.cta_50600200101020;
                if (current.cta_50600200101030 != null)
                    current.Total50600200101000 += (Decimal)current.cta_50600200101030;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200100000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200100000.cta_50600200102000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200100000.cta_50600200102000;
                current.Total50600200102000 = 0;
                if (current.cta_50600200102010 != null)
                    current.Total50600200102000 += (Decimal)current.cta_50600200102010;
                if (current.cta_50600200102020 != null)
                    current.Total50600200102000 += (Decimal)current.cta_50600200102020;
                if (current.cta_50600200102030 != null)
                    current.Total50600200102000 += (Decimal)current.cta_50600200102030;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200100000;
                current.Total50600200100000 = 0;
                if (current.cta_50600200101000 != null && current.cta_50600200101000.Total50600200101000 != 0)
                    current.Total50600200100000 += (Decimal)current.cta_50600200101000.Total50600200101000;
                if (current.cta_50600200102000 != null && current.cta_50600200102000.Total50600200102000 != 0)
                    current.Total50600200100000 += (Decimal)current.cta_50600200102000.Total50600200102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200200000;
                current.Total50600200200000 = 0;
                if (current.cta_50600200201000 != null)
                    current.Total50600200200000 += (Decimal)current.cta_50600200201000;
                if (current.cta_50600200202000 != null)
                    current.Total50600200200000 += (Decimal)current.cta_50600200202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200300000;
                current.Total50600200300000 = 0;
                if (current.cta_50600200301000 != null)
                    current.Total50600200300000 += (Decimal)current.cta_50600200301000;
                if (current.cta_50600200302000 != null)
                    current.Total50600200300000 += (Decimal)current.cta_50600200302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200400000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200400000;
                current.Total50600200400000 = 0;
                if (current.cta_50600200401000 != null)
                    current.Total50600200400000 += (Decimal)current.cta_50600200401000;
                if (current.cta_50600200402000 != null)
                    current.Total50600200400000 += (Decimal)current.cta_50600200402000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200500000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200500000;
                current.Total50600200500000 = 0;
                if (current.cta_50600200501000 != null)
                    current.Total50600200500000 += (Decimal)current.cta_50600200501000;
                if (current.cta_50600200502000 != null)
                    current.Total50600200500000 += (Decimal)current.cta_50600200502000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200700000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200700000;
                current.Total50600200700000 = 0;
                if (current.cta_50600200701000 != null)
                    current.Total50600200700000 += (Decimal)current.cta_50600200701000;
                if (current.cta_50600200702000 != null)
                    current.Total50600200700000 += (Decimal)current.cta_50600200702000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200900000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000.cta_50600200900000;
                current.Total50600200900000 = 0;
                if (current.cta_50600200901000 != null)
                    current.Total50600200900000 += (Decimal)current.cta_50600200901000;
                if (current.cta_50600200902000 != null)
                    current.Total50600200900000 += (Decimal)current.cta_50600200902000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600200000000;
                current.Total50600200000000 = 0;
                if (current.cta_50600200100000 != null && current.cta_50600200100000.Total50600200100000 != 0)
                    current.Total50600200000000 += (Decimal)current.cta_50600200100000.Total50600200100000;
                if (current.cta_50600200200000 != null && current.cta_50600200200000.Total50600200200000 != 0)
                    current.Total50600200000000 += (Decimal)current.cta_50600200200000.Total50600200200000;
                if (current.cta_50600200300000 != null && current.cta_50600200300000.Total50600200300000 != 0)
                    current.Total50600200000000 += (Decimal)current.cta_50600200300000.Total50600200300000;
                if (current.cta_50600200400000 != null && current.cta_50600200400000.Total50600200400000 != 0)
                    current.Total50600200000000 += (Decimal)current.cta_50600200400000.Total50600200400000;
                if (current.cta_50600200500000 != null && current.cta_50600200500000.Total50600200500000 != 0)
                    current.Total50600200000000 += (Decimal)current.cta_50600200500000.Total50600200500000;
                if (current.cta_50600200700000 != null && current.cta_50600200700000.Total50600200700000 != 0)
                    current.Total50600200000000 += (Decimal)current.cta_50600200700000.Total50600200700000;
                if (current.cta_50600200900000 != null && current.cta_50600200900000.Total50600200900000 != 0)
                    current.Total50600200000000 += (Decimal)current.cta_50600200900000.Total50600200900000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600300100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600300100000;
                current.Total50600300100000 = 0;
                if (current.cta_50600300101000 != null)
                    current.Total50600300100000 += (Decimal)current.cta_50600300101000;
                if (current.cta_50600300102000 != null)
                    current.Total50600300100000 += (Decimal)current.cta_50600300102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600300200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600300200000;
                current.Total50600300200000 = 0;
                if (current.cta_50600300201000 != null)
                    current.Total50600300200000 += (Decimal)current.cta_50600300201000;
                if (current.cta_50600300202000 != null)
                    current.Total50600300200000 += (Decimal)current.cta_50600300202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600300300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600300300000;
                current.Total50600300300000 = 0;
                if (current.cta_50600300301000 != null)
                    current.Total50600300300000 += (Decimal)current.cta_50600300301000;
                if (current.cta_50600300302000 != null)
                    current.Total50600300300000 += (Decimal)current.cta_50600300302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600300400000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600300400000;
                current.Total50600300400000 = 0;
                if (current.cta_50600300401000 != null)
                    current.Total50600300400000 += (Decimal)current.cta_50600300401000;
                if (current.cta_50600300402000 != null)
                    current.Total50600300400000 += (Decimal)current.cta_50600300402000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600300500000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600300500000;
                current.Total50600300500000 = 0;
                if (current.cta_50600300501000 != null)
                    current.Total50600300500000 += (Decimal)current.cta_50600300501000;
                if (current.cta_50600300502000 != null)
                    current.Total50600300500000 += (Decimal)current.cta_50600300502000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600300600000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600300600000;
                current.Total50600300600000 = 0;
                if (current.cta_50600300601000 != null)
                    current.Total50600300600000 += (Decimal)current.cta_50600300601000;
                if (current.cta_50600300602000 != null)
                    current.Total50600300600000 += (Decimal)current.cta_50600300602000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600300800000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600300800000;
                current.Total50600300800000 = 0;
                if (current.cta_50600300801000 != null)
                    current.Total50600300800000 += (Decimal)current.cta_50600300801000;
                if (current.cta_50600300802000 != null)
                    current.Total50600300800000 += (Decimal)current.cta_50600300802000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600301900000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000.cta_50600301900000;
                current.Total50600301900000 = 0;
                if (current.cta_50600301901000 != null)
                    current.Total50600301900000 += (Decimal)current.cta_50600301901000;
                if (current.cta_50600301902000 != null)
                    current.Total50600301900000 += (Decimal)current.cta_50600301902000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600300000000;
                current.Total50600300000000 = 0;
                if (current.cta_50600300100000 != null && current.cta_50600300100000.Total50600300100000 != 0)
                    current.Total50600300000000 += (Decimal)current.cta_50600300100000.Total50600300100000;
                if (current.cta_50600300200000 != null && current.cta_50600300200000.Total50600300200000 != 0)
                    current.Total50600300000000 += (Decimal)current.cta_50600300200000.Total50600300200000;
                if (current.cta_50600300300000 != null && current.cta_50600300300000.Total50600300300000 != 0)
                    current.Total50600300000000 += (Decimal)current.cta_50600300300000.Total50600300300000;
                if (current.cta_50600300400000 != null && current.cta_50600300400000.Total50600300400000 != 0)
                    current.Total50600300000000 += (Decimal)current.cta_50600300400000.Total50600300400000;
                if (current.cta_50600300500000 != null && current.cta_50600300500000.Total50600300500000 != 0)
                    current.Total50600300000000 += (Decimal)current.cta_50600300500000.Total50600300500000;
                if (current.cta_50600300600000 != null && current.cta_50600300600000.Total50600300600000 != 0)
                    current.Total50600300000000 += (Decimal)current.cta_50600300600000.Total50600300600000;
                if (current.cta_50600300800000 != null && current.cta_50600300800000.Total50600300800000 != 0)
                    current.Total50600300000000 += (Decimal)current.cta_50600300800000.Total50600300800000;
                if (current.cta_50600301900000 != null && current.cta_50600301900000.Total50600301900000 != 0)
                    current.Total50600300000000 += (Decimal)current.cta_50600301900000.Total50600301900000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600800000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600800000000.cta_50600809900000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600800000000.cta_50600809900000;
                current.Total50600809900000 = 0;
                if (current.cta_50600809901000 != null)
                    current.Total50600809900000 += (Decimal)current.cta_50600809901000;
                if (current.cta_50600809902000 != null)
                    current.Total50600809900000 += (Decimal)current.cta_50600809902000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600800000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600800000000;
                current.Total50600800000000 = 0;
                if (current.cta_50600809900000 != null && current.cta_50600809900000.Total50600809900000 != 0)
                    current.Total50600800000000 += (Decimal)current.cta_50600809900000.Total50600809900000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600900100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600900100000;
                current.Total50600900100000 = 0;
                if (current.cta_50600900101000 != null)
                    current.Total50600900100000 += (Decimal)current.cta_50600900101000;
                if (current.cta_50600900102000 != null)
                    current.Total50600900100000 += (Decimal)current.cta_50600900102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600900300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600900300000;
                current.Total50600900300000 = 0;
                if (current.cta_50600900301000 != null)
                    current.Total50600900300000 += (Decimal)current.cta_50600900301000;
                if (current.cta_50600900302000 != null)
                    current.Total50600900300000 += (Decimal)current.cta_50600900302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600900500000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600900500000;
                current.Total50600900500000 = 0;
                if (current.cta_50600900501000 != null)
                    current.Total50600900500000 += (Decimal)current.cta_50600900501000;
                if (current.cta_50600900502000 != null)
                    current.Total50600900500000 += (Decimal)current.cta_50600900502000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600900600000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600900600000;
                current.Total50600900600000 = 0;
                if (current.cta_50600900601000 != null)
                    current.Total50600900600000 += (Decimal)current.cta_50600900601000;
                if (current.cta_50600900602000 != null)
                    current.Total50600900600000 += (Decimal)current.cta_50600900602000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600900700000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600900700000;
                current.Total50600900700000 = 0;
                if (current.cta_50600900701000 != null)
                    current.Total50600900700000 += (Decimal)current.cta_50600900701000;
                if (current.cta_50600900702000 != null)
                    current.Total50600900700000 += (Decimal)current.cta_50600900702000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600900800000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600900800000;
                current.Total50600900800000 = 0;
                if (current.cta_50600900801000 != null)
                    current.Total50600900800000 += (Decimal)current.cta_50600900801000;
                if (current.cta_50600900802000 != null)
                    current.Total50600900800000 += (Decimal)current.cta_50600900802000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600901200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600901200000;
                current.Total50600901200000 = 0;
                if (current.cta_50600901201000 != null)
                    current.Total50600901200000 += (Decimal)current.cta_50600901201000;
                if (current.cta_50600901202000 != null)
                    current.Total50600901200000 += (Decimal)current.cta_50600901202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600901300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600901300000;
                current.Total50600901300000 = 0;
                if (current.cta_50600901301000 != null)
                    current.Total50600901300000 += (Decimal)current.cta_50600901301000;
                if (current.cta_50600901302000 != null)
                    current.Total50600901300000 += (Decimal)current.cta_50600901302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600909900000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000.cta_50600909900000;
                current.Total50600909900000 = 0;
                if (current.cta_50600909901000 != null)
                    current.Total50600909900000 += (Decimal)current.cta_50600909901000;
                if (current.cta_50600909902000 != null)
                    current.Total50600909900000 += (Decimal)current.cta_50600909902000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null && modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000.cta_50600900000000;
                current.Total50600900000000 = 0;
                if (current.cta_50600900100000 != null && current.cta_50600900100000.Total50600900100000 != 0)
                    current.Total50600900000000 += (Decimal)current.cta_50600900100000.Total50600900100000;
                if (current.cta_50600900300000 != null && current.cta_50600900300000.Total50600900300000 != 0)
                    current.Total50600900000000 += (Decimal)current.cta_50600900300000.Total50600900300000;
                if (current.cta_50600900500000 != null && current.cta_50600900500000.Total50600900500000 != 0)
                    current.Total50600900000000 += (Decimal)current.cta_50600900500000.Total50600900500000;
                if (current.cta_50600900600000 != null && current.cta_50600900600000.Total50600900600000 != 0)
                    current.Total50600900000000 += (Decimal)current.cta_50600900600000.Total50600900600000;
                if (current.cta_50600900700000 != null && current.cta_50600900700000.Total50600900700000 != 0)
                    current.Total50600900000000 += (Decimal)current.cta_50600900700000.Total50600900700000;
                if (current.cta_50600900800000 != null && current.cta_50600900800000.Total50600900800000 != 0)
                    current.Total50600900000000 += (Decimal)current.cta_50600900800000.Total50600900800000;
                if (current.cta_50600901200000 != null && current.cta_50600901200000.Total50600901200000 != 0)
                    current.Total50600900000000 += (Decimal)current.cta_50600901200000.Total50600901200000;
                if (current.cta_50600901300000 != null && current.cta_50600901300000.Total50600901300000 != 0)
                    current.Total50600900000000 += (Decimal)current.cta_50600901300000.Total50600901300000;
                if (current.cta_50600909900000 != null && current.cta_50600909900000.Total50600909900000 != 0)
                    current.Total50600900000000 += (Decimal)current.cta_50600909900000.Total50600909900000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50600000000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50600000000000;
                current.Total50600000000000 = 0;
                if (current.cta_50600100000000 != null && current.cta_50600100000000.Total50600100000000 != 0)
                    current.Total50600000000000 += (Decimal)current.cta_50600100000000.Total50600100000000;
                if (current.cta_50600200000000 != null && current.cta_50600200000000.Total50600200000000 != 0)
                    current.Total50600000000000 += (Decimal)current.cta_50600200000000.Total50600200000000;
                if (current.cta_50600300000000 != null && current.cta_50600300000000.Total50600300000000 != 0)
                    current.Total50600000000000 += (Decimal)current.cta_50600300000000.Total50600300000000;
                if (current.cta_50600800000000 != null && current.cta_50600800000000.Total50600800000000 != 0)
                    current.Total50600000000000 += (Decimal)current.cta_50600800000000.Total50600800000000;
                if (current.cta_50600900000000 != null && current.cta_50600900000000.Total50600900000000 != 0)
                    current.Total50600000000000 += (Decimal)current.cta_50600900000000.Total50600900000000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50700000000000 != null && modelo.cta_50000000000000.cta_50700000000000.cta_50700100000000 != null && modelo.cta_50000000000000.cta_50700000000000.cta_50700100000000.cta_50700100800000 != null && modelo.cta_50000000000000.cta_50700000000000.cta_50700100000000.cta_50700100800000.cta_50700100801000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50700000000000.cta_50700100000000.cta_50700100800000.cta_50700100801000;
                current.Total50700100801000 = 0;
                if (current.cta_50700100801010 != null)
                    current.Total50700100801000 += (Decimal)current.cta_50700100801010;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50700000000000 != null && modelo.cta_50000000000000.cta_50700000000000.cta_50700100000000 != null && modelo.cta_50000000000000.cta_50700000000000.cta_50700100000000.cta_50700100800000 != null && modelo.cta_50000000000000.cta_50700000000000.cta_50700100000000.cta_50700100800000.cta_50700100802000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50700000000000.cta_50700100000000.cta_50700100800000.cta_50700100802000;
                current.Total50700100802000 = 0;
                if (current.cta_50700100802010 != null)
                    current.Total50700100802000 += (Decimal)current.cta_50700100802010;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50700000000000 != null && modelo.cta_50000000000000.cta_50700000000000.cta_50700100000000 != null && modelo.cta_50000000000000.cta_50700000000000.cta_50700100000000.cta_50700100800000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50700000000000.cta_50700100000000.cta_50700100800000;
                current.Total50700100800000 = 0;
                if (current.cta_50700100801000 != null && current.cta_50700100801000.Total50700100801000 != 0)
                    current.Total50700100800000 += (Decimal)current.cta_50700100801000.Total50700100801000;
                if (current.cta_50700100802000 != null && current.cta_50700100802000.Total50700100802000 != 0)
                    current.Total50700100800000 += (Decimal)current.cta_50700100802000.Total50700100802000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50700000000000 != null && modelo.cta_50000000000000.cta_50700000000000.cta_50700100000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50700000000000.cta_50700100000000;
                current.Total50700100000000 = 0;
                if (current.cta_50700100800000 != null && current.cta_50700100800000.Total50700100800000 != 0)
                    current.Total50700100000000 += (Decimal)current.cta_50700100800000.Total50700100800000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50700000000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50700000000000;
                current.Total50700000000000 = 0;
                if (current.cta_50700100000000 != null && current.cta_50700100000000.Total50700100000000 != 0)
                    current.Total50700000000000 += (Decimal)current.cta_50700100000000.Total50700100000000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50900000000000 != null && modelo.cta_50000000000000.cta_50900000000000.cta_50900100000000 != null && modelo.cta_50000000000000.cta_50900000000000.cta_50900100000000.cta_50900100100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50900000000000.cta_50900100000000.cta_50900100100000;
                current.Total50900100100000 = 0;
                if (current.cta_50900100101000 != null)
                    current.Total50900100100000 += (Decimal)current.cta_50900100101000;
                if (current.cta_50900100102000 != null)
                    current.Total50900100100000 += (Decimal)current.cta_50900100102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50900000000000 != null && modelo.cta_50000000000000.cta_50900000000000.cta_50900100000000 != null && modelo.cta_50000000000000.cta_50900000000000.cta_50900100000000.cta_50900100200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50900000000000.cta_50900100000000.cta_50900100200000;
                current.Total50900100200000 = 0;
                if (current.cta_50900100201000 != null)
                    current.Total50900100200000 += (Decimal)current.cta_50900100201000;
                if (current.cta_50900100202000 != null)
                    current.Total50900100200000 += (Decimal)current.cta_50900100202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50900000000000 != null && modelo.cta_50000000000000.cta_50900000000000.cta_50900100000000 != null && modelo.cta_50000000000000.cta_50900000000000.cta_50900100000000.cta_50900100300000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50900000000000.cta_50900100000000.cta_50900100300000;
                current.Total50900100300000 = 0;
                if (current.cta_50900100301000 != null)
                    current.Total50900100300000 += (Decimal)current.cta_50900100301000;
                if (current.cta_50900100302000 != null)
                    current.Total50900100300000 += (Decimal)current.cta_50900100302000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50900000000000 != null && modelo.cta_50000000000000.cta_50900000000000.cta_50900100000000 != null && modelo.cta_50000000000000.cta_50900000000000.cta_50900100000000.cta_50900100400000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50900000000000.cta_50900100000000.cta_50900100400000;
                current.Total50900100400000 = 0;
                if (current.cta_50900100401000 != null)
                    current.Total50900100400000 += (Decimal)current.cta_50900100401000;
                if (current.cta_50900100402000 != null)
                    current.Total50900100400000 += (Decimal)current.cta_50900100402000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50900000000000 != null && modelo.cta_50000000000000.cta_50900000000000.cta_50900100000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50900000000000.cta_50900100000000;
                current.Total50900100000000 = 0;
                if (current.cta_50900100100000 != null && current.cta_50900100100000.Total50900100100000 != 0)
                    current.Total50900100000000 += (Decimal)current.cta_50900100100000.Total50900100100000;
                if (current.cta_50900100200000 != null && current.cta_50900100200000.Total50900100200000 != 0)
                    current.Total50900100000000 += (Decimal)current.cta_50900100200000.Total50900100200000;
                if (current.cta_50900100300000 != null && current.cta_50900100300000.Total50900100300000 != 0)
                    current.Total50900100000000 += (Decimal)current.cta_50900100300000.Total50900100300000;
                if (current.cta_50900100400000 != null && current.cta_50900100400000.Total50900100400000 != 0)
                    current.Total50900100000000 += (Decimal)current.cta_50900100400000.Total50900100400000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50900000000000 != null && modelo.cta_50000000000000.cta_50900000000000.cta_50900200000000 != null && modelo.cta_50000000000000.cta_50900000000000.cta_50900200000000.cta_50900200100000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50900000000000.cta_50900200000000.cta_50900200100000;
                current.Total50900200100000 = 0;
                if (current.cta_50900200101000 != null)
                    current.Total50900200100000 += (Decimal)current.cta_50900200101000;
                if (current.cta_50900200102000 != null)
                    current.Total50900200100000 += (Decimal)current.cta_50900200102000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50900000000000 != null && modelo.cta_50000000000000.cta_50900000000000.cta_50900200000000 != null && modelo.cta_50000000000000.cta_50900000000000.cta_50900200000000.cta_50900200200000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50900000000000.cta_50900200000000.cta_50900200200000;
                current.Total50900200200000 = 0;
                if (current.cta_50900200201000 != null)
                    current.Total50900200200000 += (Decimal)current.cta_50900200201000;
                if (current.cta_50900200202000 != null)
                    current.Total50900200200000 += (Decimal)current.cta_50900200202000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50900000000000 != null && modelo.cta_50000000000000.cta_50900000000000.cta_50900200000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50900000000000.cta_50900200000000;
                current.Total50900200000000 = 0;
                if (current.cta_50900200100000 != null && current.cta_50900200100000.Total50900200100000 != 0)
                    current.Total50900200000000 += (Decimal)current.cta_50900200100000.Total50900200100000;
                if (current.cta_50900200200000 != null && current.cta_50900200200000.Total50900200200000 != 0)
                    current.Total50900200000000 += (Decimal)current.cta_50900200200000.Total50900200200000;
            }
            if (modelo.cta_50000000000000 != null && modelo.cta_50000000000000.cta_50900000000000 != null)
            {
                var current = modelo.cta_50000000000000.cta_50900000000000;
                current.Total50900000000000 = 0;
                if (current.cta_50900100000000 != null && current.cta_50900100000000.Total50900100000000 != 0)
                    current.Total50900000000000 += (Decimal)current.cta_50900100000000.Total50900100000000;
                if (current.cta_50900200000000 != null && current.cta_50900200000000.Total50900200000000 != 0)
                    current.Total50900000000000 += (Decimal)current.cta_50900200000000.Total50900200000000;
            }
            if (modelo.cta_50000000000000 != null)
            {
                var current = modelo.cta_50000000000000;
                current.Total50000000000000 = 0;
                if (current.cta_50100000000000 != null && current.cta_50100000000000.Total50100000000000 != 0)
                    current.Total50000000000000 += (Decimal)current.cta_50100000000000.Total50100000000000;
                if (current.cta_50200000000000 != null && current.cta_50200000000000.Total50200000000000 != 0)
                    current.Total50000000000000 += (Decimal)current.cta_50200000000000.Total50200000000000;
                if (current.cta_50300000000000 != null && current.cta_50300000000000.Total50300000000000 != 0)
                    current.Total50000000000000 += (Decimal)current.cta_50300000000000.Total50300000000000;
                if (current.cta_50500000000000 != null && current.cta_50500000000000.Total50500000000000 != 0)
                    current.Total50000000000000 += (Decimal)current.cta_50500000000000.Total50500000000000;
                if (current.cta_50600000000000 != null && current.cta_50600000000000.Total50600000000000 != 0)
                    current.Total50000000000000 += (Decimal)current.cta_50600000000000.Total50600000000000;
                if (current.cta_50700000000000 != null && current.cta_50700000000000.Total50700000000000 != 0)
                    current.Total50000000000000 += (Decimal)current.cta_50700000000000.Total50700000000000;
                if (current.cta_50900000000000 != null && current.cta_50900000000000.Total50900000000000 != 0)
                    current.Total50000000000000 += (Decimal)current.cta_50900000000000.Total50900000000000;
            }
        }

    }
}
