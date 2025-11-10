using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.Sugese.SaldosContables.Domain.Mapper
{
    internal class MapeoCuenta3
    {
        public static void Mapper(string account, Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModelo modelo, System.Nullable<decimal> value, bool specified)
        {
            switch (account)
            {

                case "30100100101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000Cta_30100100100000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100100000.cta_30100100101000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100100000.cta_30100100101000Specified = specified;
                    break;
                case "30100100102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000Cta_30100100100000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100100000.cta_30100100102000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100100000.cta_30100100102000Specified = specified;
                    break;
                case "30100100201010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000Cta_30100100200000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100201000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000Cta_30100100200000Cta_30100100201000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100201000.cta_30100100201010 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100201000.cta_30100100201010Specified = specified;
                    break;
                case "30100100201020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000Cta_30100100200000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100201000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000Cta_30100100200000Cta_30100100201000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100201000.cta_30100100201020 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100201000.cta_30100100201020Specified = specified;
                    break;
                case "30100100202010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000Cta_30100100200000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100202000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000Cta_30100100200000Cta_30100100202000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100202000.cta_30100100202010 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100202000.cta_30100100202010Specified = specified;
                    break;
                case "30100100202020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000Cta_30100100200000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100202000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000Cta_30100100200000Cta_30100100202000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100202000.cta_30100100202020 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100200000.cta_30100100202000.cta_30100100202020Specified = specified;
                    break;
                case "30100100601000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100600000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100600000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000Cta_30100100600000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100600000.cta_30100100601000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100600000.cta_30100100601000Specified = specified;
                    break;
                case "30100100602000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100600000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100600000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100100000000Cta_30100100600000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100600000.cta_30100100602000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100100000000.cta_30100100600000.cta_30100100602000Specified = specified;
                    break;
                case "30100200101010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000Cta_30100200100000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200101000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000Cta_30100200100000Cta_30100200101000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200101000.cta_30100200101010 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200101000.cta_30100200101010Specified = specified;
                    break;
                case "30100200101020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000Cta_30100200100000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200101000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000Cta_30100200100000Cta_30100200101000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200101000.cta_30100200101020 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200101000.cta_30100200101020Specified = specified;
                    break;
                case "30100200101030":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000Cta_30100200100000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200101000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000Cta_30100200100000Cta_30100200101000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200101000.cta_30100200101030 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200101000.cta_30100200101030Specified = specified;
                    break;
                case "30100200102010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000Cta_30100200100000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200102000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000Cta_30100200100000Cta_30100200102000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200102000.cta_30100200102010 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200102000.cta_30100200102010Specified = specified;
                    break;
                case "30100200102020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000Cta_30100200100000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200102000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000Cta_30100200100000Cta_30100200102000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200102000.cta_30100200102020 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200102000.cta_30100200102020Specified = specified;
                    break;
                case "30100200102030":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000Cta_30100200100000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200102000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100200000000Cta_30100200100000Cta_30100200102000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200102000.cta_30100200102030 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100200000000.cta_30100200100000.cta_30100200102000.cta_30100200102030Specified = specified;
                    break;
                case "30100300101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000Cta_30100300100000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300100000.cta_30100300101000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300100000.cta_30100300101000Specified = specified;
                    break;
                case "30100300102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000Cta_30100300100000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300100000.cta_30100300102000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300100000.cta_30100300102000Specified = specified;
                    break;
                case "30100300201000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300200000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000Cta_30100300200000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300200000.cta_30100300201000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300200000.cta_30100300201000Specified = specified;
                    break;
                case "30100300202000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300200000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000Cta_30100300200000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300200000.cta_30100300202000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300200000.cta_30100300202000Specified = specified;
                    break;
                case "30100300301000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300300000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000Cta_30100300300000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300300000.cta_30100300301000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300300000.cta_30100300301000Specified = specified;
                    break;
                case "30100300302000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300300000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000Cta_30100300300000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300300000.cta_30100300302000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300300000.cta_30100300302000Specified = specified;
                    break;
                case "30100300401000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300400000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000Cta_30100300400000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300400000.cta_30100300401000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300400000.cta_30100300401000Specified = specified;
                    break;
                case "30100300402000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300400000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000Cta_30100300400000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300400000.cta_30100300402000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100300400000.cta_30100300402000Specified = specified;
                    break;
                case "30100309901000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100309900000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100309900000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000Cta_30100309900000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100309900000.cta_30100309901000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100309900000.cta_30100309901000Specified = specified;
                    break;
                case "30100309902000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100309900000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100309900000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100300000000Cta_30100309900000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100309900000.cta_30100309902000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100300000000.cta_30100309900000.cta_30100309902000Specified = specified;
                    break;
                case "30100400101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000Cta_30100400100000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400100000.cta_30100400101000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400100000.cta_30100400101000Specified = specified;
                    break;
                case "30100400102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000Cta_30100400100000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400100000.cta_30100400102000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400100000.cta_30100400102000Specified = specified;
                    break;
                case "30100400201000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400200000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000Cta_30100400200000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400200000.cta_30100400201000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400200000.cta_30100400201000Specified = specified;
                    break;
                case "30100400202000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400200000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000Cta_30100400200000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400200000.cta_30100400202000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400200000.cta_30100400202000Specified = specified;
                    break;
                case "30100400301000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400300000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000Cta_30100400300000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400300000.cta_30100400301000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400300000.cta_30100400301000Specified = specified;
                    break;
                case "30100400302000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400300000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000Cta_30100400300000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400300000.cta_30100400302000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400300000.cta_30100400302000Specified = specified;
                    break;
                case "30100400401000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400400000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000Cta_30100400400000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400400000.cta_30100400401000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400400000.cta_30100400401000Specified = specified;
                    break;
                case "30100400402000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400400000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000Cta_30100400400000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400400000.cta_30100400402000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100400400000.cta_30100400402000Specified = specified;
                    break;
                case "30100409901000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100409900000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100409900000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000Cta_30100409900000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100409900000.cta_30100409901000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100409900000.cta_30100409901000Specified = specified;
                    break;
                case "30100409902000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100409900000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100409900000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100400000000Cta_30100409900000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100409900000.cta_30100409902000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100400000000.cta_30100409900000.cta_30100409902000Specified = specified;
                    break;
                case "30100500101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000Cta_30100500100000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500100000.cta_30100500101000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500100000.cta_30100500101000Specified = specified;
                    break;
                case "30100500102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000Cta_30100500100000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500100000.cta_30100500102000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500100000.cta_30100500102000Specified = specified;
                    break;
                case "30100500201010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000Cta_30100500200000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500201000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000Cta_30100500200000Cta_30100500201000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500201000.cta_30100500201010 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500201000.cta_30100500201010Specified = specified;
                    break;
                case "30100500201020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000Cta_30100500200000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500201000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000Cta_30100500200000Cta_30100500201000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500201000.cta_30100500201020 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500201000.cta_30100500201020Specified = specified;
                    break;
                case "30100500202010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000Cta_30100500200000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500202000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000Cta_30100500200000Cta_30100500202000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500202000.cta_30100500202010 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500202000.cta_30100500202010Specified = specified;
                    break;
                case "30100500202020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000Cta_30100500200000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500202000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000Cta_30100500200000Cta_30100500202000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500202000.cta_30100500202020 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100500200000.cta_30100500202000.cta_30100500202020Specified = specified;
                    break;
                case "30100509901000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100509900000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100509900000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000Cta_30100509900000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100509900000.cta_30100509901000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100509900000.cta_30100509901000Specified = specified;
                    break;
                case "30100509902000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100509900000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100509900000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100500000000Cta_30100509900000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100509900000.cta_30100509902000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100500000000.cta_30100509900000.cta_30100509902000Specified = specified;
                    break;
                case "30100700101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100700000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100700000000Cta_30100700100000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700100000.cta_30100700101000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700100000.cta_30100700101000Specified = specified;
                    break;
                case "30100700102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100700000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700100000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100700000000Cta_30100700100000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700100000.cta_30100700102000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700100000.cta_30100700102000Specified = specified;
                    break;
                case "30100700201000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100700000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700200000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100700000000Cta_30100700200000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700200000.cta_30100700201000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700200000.cta_30100700201000Specified = specified;
                    break;
                case "30100700202000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100700000000();
                    if (modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700200000 == null)
                        modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30100000000000Cta_30100700000000Cta_30100700200000();
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700200000.cta_30100700202000 = value;
                    modelo.cta_30000000000000.cta_30100000000000.cta_30100700000000.cta_30100700200000.cta_30100700202000Specified = specified;
                    break;
                case "30200100101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200100000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100100000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200100000000Cta_30200100100000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100100000.cta_30200100101000 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100100000.cta_30200100101000Specified = specified;
                    break;
                case "30200100102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200100000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100100000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200100000000Cta_30200100100000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100100000.cta_30200100102000 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100100000.cta_30200100102000Specified = specified;
                    break;
                case "30200100201000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200100000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100200000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200100000000Cta_30200100200000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100200000.cta_30200100201000 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100200000.cta_30200100201000Specified = specified;
                    break;
                case "30200100202000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200100000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100200000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200100000000Cta_30200100200000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100200000.cta_30200100202000 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100200000.cta_30200100202000Specified = specified;
                    break;
                case "30200100301000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200100000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100300000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200100000000Cta_30200100300000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100300000.cta_30200100301000 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100300000.cta_30200100301000Specified = specified;
                    break;
                case "30200100302000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200100000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100300000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200100000000Cta_30200100300000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100300000.cta_30200100302000 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200100000000.cta_30200100300000.cta_30200100302000Specified = specified;
                    break;
                case "30200200101010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200100000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200101000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200100000Cta_30200200101000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200101000.cta_30200200101010 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200101000.cta_30200200101010Specified = specified;
                    break;
                case "30200200101020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200100000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200101000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200100000Cta_30200200101000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200101000.cta_30200200101020 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200101000.cta_30200200101020Specified = specified;
                    break;
                case "30200200102010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200100000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200102000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200100000Cta_30200200102000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200102000.cta_30200200102010 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200102000.cta_30200200102010Specified = specified;
                    break;
                case "30200200102020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200100000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200102000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200100000Cta_30200200102000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200102000.cta_30200200102020 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200100000.cta_30200200102000.cta_30200200102020Specified = specified;
                    break;
                case "30200200201010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200200000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200201000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200200000Cta_30200200201000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200201000.cta_30200200201010 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200201000.cta_30200200201010Specified = specified;
                    break;
                case "30200200201020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200200000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200201000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200200000Cta_30200200201000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200201000.cta_30200200201020 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200201000.cta_30200200201020Specified = specified;
                    break;
                case "30200200202010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200200000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200202000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200200000Cta_30200200202000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200202000.cta_30200200202010 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200202000.cta_30200200202010Specified = specified;
                    break;
                case "30200200202020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200200000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200202000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200200000000Cta_30200200200000Cta_30200200202000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200202000.cta_30200200202020 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200200000000.cta_30200200200000.cta_30200200202000.cta_30200200202020Specified = specified;
                    break;
                case "30200300101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200300000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300100000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200300000000Cta_30200300100000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300100000.cta_30200300101000 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300100000.cta_30200300101000Specified = specified;
                    break;
                case "30200300102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200300000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300100000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200300000000Cta_30200300100000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300100000.cta_30200300102000 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300100000.cta_30200300102000Specified = specified;
                    break;
                case "30200300201000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200300000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300200000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200300000000Cta_30200300200000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300200000.cta_30200300201000 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300200000.cta_30200300201000Specified = specified;
                    break;
                case "30200300202000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200300000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300200000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200300000000Cta_30200300200000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300200000.cta_30200300202000 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200300000000.cta_30200300200000.cta_30200300202000Specified = specified;
                    break;
                case "30200500101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200500000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000.cta_30200500100000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000.cta_30200500100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200500000000Cta_30200500100000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000.cta_30200500100000.cta_30200500101000 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000.cta_30200500100000.cta_30200500101000Specified = specified;
                    break;
                case "30200500102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200500000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000.cta_30200500100000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000.cta_30200500100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200500000000Cta_30200500100000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000.cta_30200500100000.cta_30200500102000 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200500000000.cta_30200500100000.cta_30200500102000Specified = specified;
                    break;
                case "30200600101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200600000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000.cta_30200600100000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000.cta_30200600100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200600000000Cta_30200600100000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000.cta_30200600100000.cta_30200600101000 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000.cta_30200600100000.cta_30200600101000Specified = specified;
                    break;
                case "30200600102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200600000000();
                    if (modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000.cta_30200600100000 == null)
                        modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000.cta_30200600100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30200000000000Cta_30200600000000Cta_30200600100000();
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000.cta_30200600100000.cta_30200600102000 = value;
                    modelo.cta_30000000000000.cta_30200000000000.cta_30200600000000.cta_30200600100000.cta_30200600102000Specified = specified;
                    break;
                case "30300100101010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100100000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100101000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100100000Cta_30300100101000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100101000.cta_30300100101010 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100101000.cta_30300100101010Specified = specified;
                    break;
                case "30300100101020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100100000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100101000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100100000Cta_30300100101000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100101000.cta_30300100101020 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100101000.cta_30300100101020Specified = specified;
                    break;
                case "30300100101090":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100100000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100101000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100100000Cta_30300100101000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100101000.cta_30300100101090 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100101000.cta_30300100101090Specified = specified;
                    break;
                case "30300100102010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100100000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100102000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100100000Cta_30300100102000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100102000.cta_30300100102010 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100102000.cta_30300100102010Specified = specified;
                    break;
                case "30300100102020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100100000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100102000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100100000Cta_30300100102000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100102000.cta_30300100102020 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100102000.cta_30300100102020Specified = specified;
                    break;
                case "30300100102090":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100100000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100102000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100100000Cta_30300100102000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100102000.cta_30300100102090 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100100000.cta_30300100102000.cta_30300100102090Specified = specified;
                    break;
                case "30300100201020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000Cta_30300100201000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000.cta_30300100201020 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000.cta_30300100201020Specified = specified;
                    break;
                case "30300100201030":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000Cta_30300100201000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000.cta_30300100201030 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000.cta_30300100201030Specified = specified;
                    break;
                case "30300100201110":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000Cta_30300100201000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000.cta_30300100201110 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000.cta_30300100201110Specified = specified;
                    break;
                case "30300100201120":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000Cta_30300100201000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000.cta_30300100201120 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000.cta_30300100201120Specified = specified;
                    break;
                case "30300100201190":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000Cta_30300100201000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000.cta_30300100201190 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100201000.cta_30300100201190Specified = specified;
                    break;
                case "30300100202020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000Cta_30300100202000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000.cta_30300100202020 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000.cta_30300100202020Specified = specified;
                    break;
                case "30300100202030":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000Cta_30300100202000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000.cta_30300100202030 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000.cta_30300100202030Specified = specified;
                    break;
                case "30300100202110":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000Cta_30300100202000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000.cta_30300100202110 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000.cta_30300100202110Specified = specified;
                    break;
                case "30300100202120":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000Cta_30300100202000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000.cta_30300100202120 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000.cta_30300100202120Specified = specified;
                    break;
                case "30300100202190":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100200000Cta_30300100202000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000.cta_30300100202190 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100200000.cta_30300100202000.cta_30300100202190Specified = specified;
                    break;
                case "30300100301020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000Cta_30300100301000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000.cta_30300100301020 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000.cta_30300100301020Specified = specified;
                    break;
                case "30300100301030":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000Cta_30300100301000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000.cta_30300100301030 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000.cta_30300100301030Specified = specified;
                    break;
                case "30300100301110":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000Cta_30300100301000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000.cta_30300100301110 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000.cta_30300100301110Specified = specified;
                    break;
                case "30300100301120":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000Cta_30300100301000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000.cta_30300100301120 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000.cta_30300100301120Specified = specified;
                    break;
                case "30300100301190":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000Cta_30300100301000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000.cta_30300100301190 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100301000.cta_30300100301190Specified = specified;
                    break;
                case "30300100302020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000Cta_30300100302000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000.cta_30300100302020 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000.cta_30300100302020Specified = specified;
                    break;
                case "30300100302030":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000Cta_30300100302000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000.cta_30300100302030 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000.cta_30300100302030Specified = specified;
                    break;
                case "30300100302110":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000Cta_30300100302000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000.cta_30300100302110 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000.cta_30300100302110Specified = specified;
                    break;
                case "30300100302120":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000Cta_30300100302000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000.cta_30300100302120 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000.cta_30300100302120Specified = specified;
                    break;
                case "30300100302190":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100300000Cta_30300100302000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000.cta_30300100302190 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100300000.cta_30300100302000.cta_30300100302190Specified = specified;
                    break;
                case "30300100401020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000Cta_30300100401000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000.cta_30300100401020 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000.cta_30300100401020Specified = specified;
                    break;
                case "30300100401030":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000Cta_30300100401000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000.cta_30300100401030 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000.cta_30300100401030Specified = specified;
                    break;
                case "30300100401110":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000Cta_30300100401000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000.cta_30300100401110 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000.cta_30300100401110Specified = specified;
                    break;
                case "30300100401120":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000Cta_30300100401000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000.cta_30300100401120 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000.cta_30300100401120Specified = specified;
                    break;
                case "30300100401190":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000Cta_30300100401000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000.cta_30300100401190 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100401000.cta_30300100401190Specified = specified;
                    break;
                case "30300100402020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000Cta_30300100402000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000.cta_30300100402020 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000.cta_30300100402020Specified = specified;
                    break;
                case "30300100402030":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000Cta_30300100402000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000.cta_30300100402030 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000.cta_30300100402030Specified = specified;
                    break;
                case "30300100402110":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000Cta_30300100402000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000.cta_30300100402110 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000.cta_30300100402110Specified = specified;
                    break;
                case "30300100402120":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000Cta_30300100402000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000.cta_30300100402120 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000.cta_30300100402120Specified = specified;
                    break;
                case "30300100402190":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100400000Cta_30300100402000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000.cta_30300100402190 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100400000.cta_30300100402000.cta_30300100402190Specified = specified;
                    break;
                case "30300100501020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000Cta_30300100501000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000.cta_30300100501020 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000.cta_30300100501020Specified = specified;
                    break;
                case "30300100501030":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000Cta_30300100501000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000.cta_30300100501030 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000.cta_30300100501030Specified = specified;
                    break;
                case "30300100501110":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000Cta_30300100501000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000.cta_30300100501110 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000.cta_30300100501110Specified = specified;
                    break;
                case "30300100501120":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000Cta_30300100501000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000.cta_30300100501120 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000.cta_30300100501120Specified = specified;
                    break;
                case "30300100501190":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000Cta_30300100501000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000.cta_30300100501190 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100501000.cta_30300100501190Specified = specified;
                    break;
                case "30300100502020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000Cta_30300100502000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000.cta_30300100502020 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000.cta_30300100502020Specified = specified;
                    break;
                case "30300100502030":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000Cta_30300100502000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000.cta_30300100502030 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000.cta_30300100502030Specified = specified;
                    break;
                case "30300100502110":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000Cta_30300100502000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000.cta_30300100502110 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000.cta_30300100502110Specified = specified;
                    break;
                case "30300100502120":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000Cta_30300100502000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000.cta_30300100502120 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000.cta_30300100502120Specified = specified;
                    break;
                case "30300100502190":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100500000Cta_30300100502000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000.cta_30300100502190 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100500000.cta_30300100502000.cta_30300100502190Specified = specified;
                    break;
                case "30300100601010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100600000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000.cta_30300100601000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000.cta_30300100601000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100600000Cta_30300100601000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000.cta_30300100601000.cta_30300100601010 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000.cta_30300100601000.cta_30300100601010Specified = specified;
                    break;
                case "30300100602010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100600000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000.cta_30300100602000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000.cta_30300100602000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100600000Cta_30300100602000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000.cta_30300100602000.cta_30300100602010 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100600000.cta_30300100602000.cta_30300100602010Specified = specified;
                    break;
                case "30300100701020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000Cta_30300100701000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000.cta_30300100701020 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000.cta_30300100701020Specified = specified;
                    break;
                case "30300100701030":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000Cta_30300100701000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000.cta_30300100701030 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000.cta_30300100701030Specified = specified;
                    break;
                case "30300100701040":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000Cta_30300100701000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000.cta_30300100701040 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000.cta_30300100701040Specified = specified;
                    break;
                case "30300100701050":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000Cta_30300100701000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000.cta_30300100701050 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100701000.cta_30300100701050Specified = specified;
                    break;
                case "30300100702020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000Cta_30300100702000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000.cta_30300100702020 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000.cta_30300100702020Specified = specified;
                    break;
                case "30300100702030":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000Cta_30300100702000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000.cta_30300100702030 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000.cta_30300100702030Specified = specified;
                    break;
                case "30300100702040":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000Cta_30300100702000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000.cta_30300100702040 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000.cta_30300100702040Specified = specified;
                    break;
                case "30300100702050":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100700000Cta_30300100702000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000.cta_30300100702050 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100700000.cta_30300100702000.cta_30300100702050Specified = specified;
                    break;
                case "30300100801010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100800000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100801000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100801000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100800000Cta_30300100801000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100801000.cta_30300100801010 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100801000.cta_30300100801010Specified = specified;
                    break;
                case "30300100801110":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100800000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100801000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100801000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100800000Cta_30300100801000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100801000.cta_30300100801110 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100801000.cta_30300100801110Specified = specified;
                    break;
                case "30300100801120":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100800000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100801000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100801000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100800000Cta_30300100801000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100801000.cta_30300100801120 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100801000.cta_30300100801120Specified = specified;
                    break;
                case "30300100802010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100800000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100802000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100802000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100800000Cta_30300100802000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100802000.cta_30300100802010 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100802000.cta_30300100802010Specified = specified;
                    break;
                case "30300100802110":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100800000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100802000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100802000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100800000Cta_30300100802000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100802000.cta_30300100802110 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100802000.cta_30300100802110Specified = specified;
                    break;
                case "30300100802120":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100800000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100802000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100802000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300100000000Cta_30300100800000Cta_30300100802000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100802000.cta_30300100802120 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300100000000.cta_30300100800000.cta_30300100802000.cta_30300100802120Specified = specified;
                    break;
                case "30300200101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300200000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200100000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300200000000Cta_30300200100000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200100000.cta_30300200101000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200100000.cta_30300200101000Specified = specified;
                    break;
                case "30300200102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300200000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200100000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300200000000Cta_30300200100000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200100000.cta_30300200102000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200100000.cta_30300200102000Specified = specified;
                    break;
                case "30300200201000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300200000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200200000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300200000000Cta_30300200200000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200200000.cta_30300200201000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200200000.cta_30300200201000Specified = specified;
                    break;
                case "30300200202000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300200000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200200000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300200000000Cta_30300200200000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200200000.cta_30300200202000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200200000.cta_30300200202000Specified = specified;
                    break;
                case "30300200301000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300200000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200300000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300200000000Cta_30300200300000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200300000.cta_30300200301000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200300000.cta_30300200301000Specified = specified;
                    break;
                case "30300200302000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300200000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200300000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300200000000Cta_30300200300000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200300000.cta_30300200302000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300200000000.cta_30300200300000.cta_30300200302000Specified = specified;
                    break;
                case "30300300101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300300000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000.cta_30300300100000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000.cta_30300300100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300300000000Cta_30300300100000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000.cta_30300300100000.cta_30300300101000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000.cta_30300300100000.cta_30300300101000Specified = specified;
                    break;
                case "30300300102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300300000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000.cta_30300300100000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000.cta_30300300100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300300000000Cta_30300300100000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000.cta_30300300100000.cta_30300300102000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300300000000.cta_30300300100000.cta_30300300102000Specified = specified;
                    break;
                case "30300400101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300400000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000.cta_30300400100000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000.cta_30300400100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300400000000Cta_30300400100000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000.cta_30300400100000.cta_30300400101000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000.cta_30300400100000.cta_30300400101000Specified = specified;
                    break;
                case "30300400102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300400000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000.cta_30300400100000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000.cta_30300400100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300400000000Cta_30300400100000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000.cta_30300400100000.cta_30300400102000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300400000000.cta_30300400100000.cta_30300400102000Specified = specified;
                    break;
                case "30300500101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500100000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000Cta_30300500100000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500100000.cta_30300500101000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500100000.cta_30300500101000Specified = specified;
                    break;
                case "30300500102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500100000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000Cta_30300500100000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500100000.cta_30300500102000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500100000.cta_30300500102000Specified = specified;
                    break;
                case "30300500201000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500200000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000Cta_30300500200000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500200000.cta_30300500201000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500200000.cta_30300500201000Specified = specified;
                    break;
                case "30300500202000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500200000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000Cta_30300500200000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500200000.cta_30300500202000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500200000.cta_30300500202000Specified = specified;
                    break;
                case "30300500301000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500300000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000Cta_30300500300000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500300000.cta_30300500301000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500300000.cta_30300500301000Specified = specified;
                    break;
                case "30300500302000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500300000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000Cta_30300500300000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500300000.cta_30300500302000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500300000.cta_30300500302000Specified = specified;
                    break;
                case "30300500401000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500400000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000Cta_30300500400000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500400000.cta_30300500401000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500400000.cta_30300500401000Specified = specified;
                    break;
                case "30300500402000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000();
                    if (modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500400000 == null)
                        modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30300000000000Cta_30300500000000Cta_30300500400000();
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500400000.cta_30300500402000 = value;
                    modelo.cta_30000000000000.cta_30300000000000.cta_30300500000000.cta_30300500400000.cta_30300500402000Specified = specified;
                    break;
                case "30400100101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400100000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000.cta_30400100100000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000.cta_30400100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400100000000Cta_30400100100000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000.cta_30400100100000.cta_30400100101000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000.cta_30400100100000.cta_30400100101000Specified = specified;
                    break;
                case "30400100102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400100000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000.cta_30400100100000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000.cta_30400100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400100000000Cta_30400100100000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000.cta_30400100100000.cta_30400100102000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400100000000.cta_30400100100000.cta_30400100102000Specified = specified;
                    break;
                case "30400200101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400200000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200100000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400200000000Cta_30400200100000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200100000.cta_30400200101000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200100000.cta_30400200101000Specified = specified;
                    break;
                case "30400200102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400200000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200100000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400200000000Cta_30400200100000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200100000.cta_30400200102000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200100000.cta_30400200102000Specified = specified;
                    break;
                case "30400200201990":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400200000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400200000000Cta_30400200200000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000.cta_30400200201000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000.cta_30400200201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400200000000Cta_30400200200000Cta_30400200201000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000.cta_30400200201000.cta_30400200201990 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000.cta_30400200201000.cta_30400200201990Specified = specified;
                    break;
                case "30400200202990":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400200000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400200000000Cta_30400200200000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000.cta_30400200202000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000.cta_30400200202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400200000000Cta_30400200200000Cta_30400200202000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000.cta_30400200202000.cta_30400200202990 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200200000.cta_30400200202000.cta_30400200202990Specified = specified;
                    break;
                case "30400200301000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400200000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200300000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400200000000Cta_30400200300000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200300000.cta_30400200301000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200300000.cta_30400200301000Specified = specified;
                    break;
                case "30400200302000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400200000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200300000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400200000000Cta_30400200300000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200300000.cta_30400200302000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400200000000.cta_30400200300000.cta_30400200302000Specified = specified;
                    break;
                case "30400300101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300100000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000Cta_30400300100000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300100000.cta_30400300101000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300100000.cta_30400300101000Specified = specified;
                    break;
                case "30400300102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300100000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000Cta_30400300100000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300100000.cta_30400300102000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300100000.cta_30400300102000Specified = specified;
                    break;
                case "30400300201010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000Cta_30400300200000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300201000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000Cta_30400300200000Cta_30400300201000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300201000.cta_30400300201010 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300201000.cta_30400300201010Specified = specified;
                    break;
                case "30400300201020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000Cta_30400300200000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300201000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000Cta_30400300200000Cta_30400300201000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300201000.cta_30400300201020 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300201000.cta_30400300201020Specified = specified;
                    break;
                case "30400300202010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000Cta_30400300200000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300202000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000Cta_30400300200000Cta_30400300202000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300202000.cta_30400300202010 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300202000.cta_30400300202010Specified = specified;
                    break;
                case "30400300202020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000Cta_30400300200000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300202000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400300000000Cta_30400300200000Cta_30400300202000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300202000.cta_30400300202020 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400300000000.cta_30400300200000.cta_30400300202000.cta_30400300202020Specified = specified;
                    break;
                case "30400500101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500100000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000Cta_30400500100000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500100000.cta_30400500101000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500100000.cta_30400500101000Specified = specified;
                    break;
                case "30400500102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500100000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000Cta_30400500100000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500100000.cta_30400500102000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500100000.cta_30400500102000Specified = specified;
                    break;
                case "30400500201000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500200000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000Cta_30400500200000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500200000.cta_30400500201000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500200000.cta_30400500201000Specified = specified;
                    break;
                case "30400500202000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500200000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000Cta_30400500200000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500200000.cta_30400500202000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500200000.cta_30400500202000Specified = specified;
                    break;
                case "30400500301000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500300000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000Cta_30400500300000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500300000.cta_30400500301000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500300000.cta_30400500301000Specified = specified;
                    break;
                case "30400500302000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500300000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000Cta_30400500300000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500300000.cta_30400500302000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500300000.cta_30400500302000Specified = specified;
                    break;
                case "30400500501000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500500000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000Cta_30400500500000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500500000.cta_30400500501000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500500000.cta_30400500501000Specified = specified;
                    break;
                case "30400500502000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000();
                    if (modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500500000 == null)
                        modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30400000000000Cta_30400500000000Cta_30400500500000();
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500500000.cta_30400500502000 = value;
                    modelo.cta_30000000000000.cta_30400000000000.cta_30400500000000.cta_30400500500000.cta_30400500502000Specified = specified;
                    break;
                case "30500100101010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000Cta_30500100101000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000.cta_30500100101010 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000.cta_30500100101010Specified = specified;
                    break;
                case "30500100101020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000Cta_30500100101000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000.cta_30500100101020 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000.cta_30500100101020Specified = specified;
                    break;
                case "30500100101030":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000Cta_30500100101000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000.cta_30500100101030 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000.cta_30500100101030Specified = specified;
                    break;
                case "30500100101040":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000Cta_30500100101000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000.cta_30500100101040 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000.cta_30500100101040Specified = specified;
                    break;
                case "30500100101050":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000Cta_30500100101000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000.cta_30500100101050 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000.cta_30500100101050Specified = specified;
                    break;
                case "30500100101060":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000Cta_30500100101000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000.cta_30500100101060 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000.cta_30500100101060Specified = specified;
                    break;
                case "30500100101990":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000Cta_30500100101000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000.cta_30500100101990 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100101000.cta_30500100101990Specified = specified;
                    break;
                case "30500100102010":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000Cta_30500100102000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000.cta_30500100102010 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000.cta_30500100102010Specified = specified;
                    break;
                case "30500100102020":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000Cta_30500100102000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000.cta_30500100102020 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000.cta_30500100102020Specified = specified;
                    break;
                case "30500100102030":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000Cta_30500100102000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000.cta_30500100102030 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000.cta_30500100102030Specified = specified;
                    break;
                case "30500100102040":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000Cta_30500100102000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000.cta_30500100102040 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000.cta_30500100102040Specified = specified;
                    break;
                case "30500100102050":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000Cta_30500100102000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000.cta_30500100102050 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000.cta_30500100102050Specified = specified;
                    break;
                case "30500100102060":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000Cta_30500100102000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000.cta_30500100102060 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000.cta_30500100102060Specified = specified;
                    break;
                case "30500100102990":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100100000Cta_30500100102000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000.cta_30500100102990 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100100000.cta_30500100102000.cta_30500100102990Specified = specified;
                    break;
                case "30500100201000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100200000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100200000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100200000.cta_30500100201000 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100200000.cta_30500100201000Specified = specified;
                    break;
                case "30500100202000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100200000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500100000000Cta_30500100200000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100200000.cta_30500100202000 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500100000000.cta_30500100200000.cta_30500100202000Specified = specified;
                    break;
                case "30500200101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000Cta_30500200100000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200100000.cta_30500200101000 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200100000.cta_30500200101000Specified = specified;
                    break;
                case "30500200102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200100000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000Cta_30500200100000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200100000.cta_30500200102000 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200100000.cta_30500200102000Specified = specified;
                    break;
                case "30500200201000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200200000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000Cta_30500200200000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200200000.cta_30500200201000 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200200000.cta_30500200201000Specified = specified;
                    break;
                case "30500200202000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200200000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000Cta_30500200200000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200200000.cta_30500200202000 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200200000.cta_30500200202000Specified = specified;
                    break;
                case "30500200301000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200300000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000Cta_30500200300000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200300000.cta_30500200301000 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200300000.cta_30500200301000Specified = specified;
                    break;
                case "30500200302000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200300000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000Cta_30500200300000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200300000.cta_30500200302000 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200300000.cta_30500200302000Specified = specified;
                    break;
                case "30500200401000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200400000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000Cta_30500200400000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200400000.cta_30500200401000 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200400000.cta_30500200401000Specified = specified;
                    break;
                case "30500200402000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000();
                    if (modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200400000 == null)
                        modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30500000000000Cta_30500200000000Cta_30500200400000();
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200400000.cta_30500200402000 = value;
                    modelo.cta_30000000000000.cta_30500000000000.cta_30500200000000.cta_30500200400000.cta_30500200402000Specified = specified;
                    break;
                case "30600100101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30600000000000 == null)
                        modelo.cta_30000000000000.cta_30600000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30600000000000();
                    if (modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000 == null)
                        modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30600000000000Cta_30600100000000();
                    if (modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000.cta_30600100100000 == null)
                        modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000.cta_30600100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30600000000000Cta_30600100000000Cta_30600100100000();
                    modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000.cta_30600100100000.cta_30600100101000 = value;
                    modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000.cta_30600100100000.cta_30600100101000Specified = specified;
                    break;
                case "30600100102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30600000000000 == null)
                        modelo.cta_30000000000000.cta_30600000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30600000000000();
                    if (modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000 == null)
                        modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30600000000000Cta_30600100000000();
                    if (modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000.cta_30600100100000 == null)
                        modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000.cta_30600100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30600000000000Cta_30600100000000Cta_30600100100000();
                    modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000.cta_30600100100000.cta_30600100102000 = value;
                    modelo.cta_30000000000000.cta_30600000000000.cta_30600100000000.cta_30600100100000.cta_30600100102000Specified = specified;
                    break;
                case "30600200101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30600000000000 == null)
                        modelo.cta_30000000000000.cta_30600000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30600000000000();
                    if (modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000 == null)
                        modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30600000000000Cta_30600200000000();
                    if (modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000.cta_30600200100000 == null)
                        modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000.cta_30600200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30600000000000Cta_30600200000000Cta_30600200100000();
                    modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000.cta_30600200100000.cta_30600200101000 = value;
                    modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000.cta_30600200100000.cta_30600200101000Specified = specified;
                    break;
                case "30600200102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30600000000000 == null)
                        modelo.cta_30000000000000.cta_30600000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30600000000000();
                    if (modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000 == null)
                        modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30600000000000Cta_30600200000000();
                    if (modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000.cta_30600200100000 == null)
                        modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000.cta_30600200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30600000000000Cta_30600200000000Cta_30600200100000();
                    modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000.cta_30600200100000.cta_30600200102000 = value;
                    modelo.cta_30000000000000.cta_30600000000000.cta_30600200000000.cta_30600200100000.cta_30600200102000Specified = specified;
                    break;
                case "30700100101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100100000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000Cta_30700100100000();
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100100000.cta_30700100101000 = value;
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100100000.cta_30700100101000Specified = specified;
                    break;
                case "30700100102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100100000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000Cta_30700100100000();
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100100000.cta_30700100102000 = value;
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100100000.cta_30700100102000Specified = specified;
                    break;
                case "30700100201000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100200000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000Cta_30700100200000();
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100200000.cta_30700100201000 = value;
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100200000.cta_30700100201000Specified = specified;
                    break;
                case "30700100202000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100200000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000Cta_30700100200000();
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100200000.cta_30700100202000 = value;
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100200000.cta_30700100202000Specified = specified;
                    break;
                case "30700100301000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100300000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000Cta_30700100300000();
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100300000.cta_30700100301000 = value;
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100300000.cta_30700100301000Specified = specified;
                    break;
                case "30700100302000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100300000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000Cta_30700100300000();
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100300000.cta_30700100302000 = value;
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100300000.cta_30700100302000Specified = specified;
                    break;
                case "30700100401000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100400000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000Cta_30700100400000();
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100400000.cta_30700100401000 = value;
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100400000.cta_30700100401000Specified = specified;
                    break;
                case "30700100402000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000();
                    if (modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100400000 == null)
                        modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30700000000000Cta_30700100000000Cta_30700100400000();
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100400000.cta_30700100402000 = value;
                    modelo.cta_30000000000000.cta_30700000000000.cta_30700100000000.cta_30700100400000.cta_30700100402000Specified = specified;
                    break;
                case "30800200101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200100000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000Cta_30800200100000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200100000.cta_30800200101000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200100000.cta_30800200101000Specified = specified;
                    break;
                case "30800200102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200100000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000Cta_30800200100000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200100000.cta_30800200102000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200100000.cta_30800200102000Specified = specified;
                    break;
                case "30800200201000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200200000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000Cta_30800200200000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200200000.cta_30800200201000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200200000.cta_30800200201000Specified = specified;
                    break;
                case "30800200202000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200200000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000Cta_30800200200000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200200000.cta_30800200202000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200200000.cta_30800200202000Specified = specified;
                    break;
                case "30800200301000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200300000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000Cta_30800200300000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200300000.cta_30800200301000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200300000.cta_30800200301000Specified = specified;
                    break;
                case "30800200302000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200300000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000Cta_30800200300000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200300000.cta_30800200302000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200300000.cta_30800200302000Specified = specified;
                    break;
                case "30800200401000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200400000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000Cta_30800200400000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200400000.cta_30800200401000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200400000.cta_30800200401000Specified = specified;
                    break;
                case "30800200402000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200400000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800200000000Cta_30800200400000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200400000.cta_30800200402000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800200000000.cta_30800200400000.cta_30800200402000Specified = specified;
                    break;
                case "30800300101000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300100000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000Cta_30800300100000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300100000.cta_30800300101000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300100000.cta_30800300101000Specified = specified;
                    break;
                case "30800300102000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300100000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000Cta_30800300100000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300100000.cta_30800300102000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300100000.cta_30800300102000Specified = specified;
                    break;
                case "30800300201000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300200000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000Cta_30800300200000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300200000.cta_30800300201000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300200000.cta_30800300201000Specified = specified;
                    break;
                case "30800300202000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300200000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000Cta_30800300200000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300200000.cta_30800300202000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300200000.cta_30800300202000Specified = specified;
                    break;
                case "30800300301000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300300000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000Cta_30800300300000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300300000.cta_30800300301000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300300000.cta_30800300301000Specified = specified;
                    break;
                case "30800300302000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300300000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000Cta_30800300300000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300300000.cta_30800300302000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300300000.cta_30800300302000Specified = specified;
                    break;
                case "30800300401000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300400000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000Cta_30800300400000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300400000.cta_30800300401000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300400000.cta_30800300401000Specified = specified;
                    break;
                case "30800300402000":
                    if (modelo.cta_30000000000000 == null)
                        modelo.cta_30000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000();
                    if (modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300400000 == null)
                        modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_30000000000000Cta_30800000000000Cta_30800300000000Cta_30800300400000();
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300400000.cta_30800300402000 = value;
                    modelo.cta_30000000000000.cta_30800000000000.cta_30800300000000.cta_30800300400000.cta_30800300402000Specified = specified;
                    break;
            }
        }
    }
}
