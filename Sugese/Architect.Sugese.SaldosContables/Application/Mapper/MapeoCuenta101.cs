using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.Sugese.SaldosContables.Domain.Mapper
{
    internal class MapeoCuenta101
    {

        public static void Mapper(string account, Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModelo modelo, System.Nullable<decimal> value, bool specified)
        {

       

            switch (account)
            {


                case "10100100101000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100100000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100100000000Cta_10100100100000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100100000.cta_10100100101000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100100000.cta_10100100101000Specified = specified;
                    break;

                case "10100100102000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100100000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100100000000Cta_10100100100000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100100000.cta_10100100102000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100100000.cta_10100100102000Specified = specified;
                    break;


                case "10100100301000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100100000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100300000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100100000000Cta_10100100300000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100300000.cta_10100100301000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100300000.cta_10100100301000Specified = specified;
                    break;
                case "10100100302000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100100000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100300000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100100000000Cta_10100100300000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100300000.cta_10100100302000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100100000000.cta_10100100300000.cta_10100100302000Specified = specified;
                    break;
                case "10100200101000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100200000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000.cta_10100200100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000.cta_10100200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100200000000Cta_10100200100000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000.cta_10100200100000.cta_10100200101000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000.cta_10100200100000.cta_10100200101000Specified = specified;
                    break;
                case "10100200102000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100200000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000.cta_10100200100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000.cta_10100200100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100200000000Cta_10100200100000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000.cta_10100200100000.cta_10100200102000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100200000000.cta_10100200100000.cta_10100200102000Specified = specified;
                    break;
                case "10100300101010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300100000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300101000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300100000Cta_10100300101000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300101000.cta_10100300101010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300101000.cta_10100300101010Specified = specified;
                    break;
                case "10100300101020":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300100000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300101000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300100000Cta_10100300101000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300101000.cta_10100300101020 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300101000.cta_10100300101020Specified = specified;
                    break;
                case "10100300102010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300100000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300102000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300100000Cta_10100300102000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300102000.cta_10100300102010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300102000.cta_10100300102010Specified = specified;
                    break;
                case "10100300102020":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300100000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300102000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300100000Cta_10100300102000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300102000.cta_10100300102020 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300100000.cta_10100300102000.cta_10100300102020Specified = specified;
                    break;
                case "10100300201010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300200000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300201000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300200000Cta_10100300201000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300201000.cta_10100300201010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300201000.cta_10100300201010Specified = specified;
                    break;
                case "10100300201020":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300200000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300201000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300200000Cta_10100300201000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300201000.cta_10100300201020 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300201000.cta_10100300201020Specified = specified;
                    break;
                case "10100300202010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300200000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300202000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300200000Cta_10100300202000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300202000.cta_10100300202010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300202000.cta_10100300202010Specified = specified;
                    break;
                case "10100300202020":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300200000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300202000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300200000Cta_10100300202000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300202000.cta_10100300202020 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300200000.cta_10100300202000.cta_10100300202020Specified = specified;
                    break;
                case "10100300501990":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300500000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000.cta_10100300501000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000.cta_10100300501000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300500000Cta_10100300501000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000.cta_10100300501000.cta_10100300501990 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000.cta_10100300501000.cta_10100300501990Specified = specified;
                    break;
                case "10100300502990":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300500000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000.cta_10100300502000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000.cta_10100300502000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300500000Cta_10100300502000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000.cta_10100300502000.cta_10100300502990 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300500000.cta_10100300502000.cta_10100300502990Specified = specified;
                    break;
                case "10100300601000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300600000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300600000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300600000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300600000.cta_10100300601000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300600000.cta_10100300601000Specified = specified;
                    break;
                case "10100300602000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300600000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300600000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100300000000Cta_10100300600000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300600000.cta_10100300602000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100300000000.cta_10100300600000.cta_10100300602000Specified = specified;
                    break;
                case "10100400101000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000Cta_10100400100000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400100000.cta_10100400101000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400100000.cta_10100400101000Specified = specified;
                    break;
                case "10100400102000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000Cta_10100400100000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400100000.cta_10100400102000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400100000.cta_10100400102000Specified = specified;
                    break;
                case "10100400201000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400200000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000Cta_10100400200000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400200000.cta_10100400201000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400200000.cta_10100400201000Specified = specified;
                    break;
                case "10100400202000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400200000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000Cta_10100400200000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400200000.cta_10100400202000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400200000.cta_10100400202000Specified = specified;
                    break;
                case "10100400501000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400500000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000Cta_10100400500000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400500000.cta_10100400501000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400500000.cta_10100400501000Specified = specified;
                    break;
                case "10100400502000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400500000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000Cta_10100400500000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400500000.cta_10100400502000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400500000.cta_10100400502000Specified = specified;
                    break;
                case "10100400601000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400600000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400600000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000Cta_10100400600000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400600000.cta_10100400601000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400600000.cta_10100400601000Specified = specified;
                    break;
                case "10100400602000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400600000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400600000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100400000000Cta_10100400600000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400600000.cta_10100400602000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100400000000.cta_10100400600000.cta_10100400602000Specified = specified;
                    break;
                case "10100500101010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100500000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100500000000Cta_10100500100000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500101000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100500000000Cta_10100500100000Cta_10100500101000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500101000.cta_10100500101010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500101000.cta_10100500101010Specified = specified;
                    break;
                case "10100500101020":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100500000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100500000000Cta_10100500100000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500101000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100500000000Cta_10100500100000Cta_10100500101000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500101000.cta_10100500101020 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500101000.cta_10100500101020Specified = specified;
                    break;
                case "10100500102010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100500000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100500000000Cta_10100500100000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500102000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100500000000Cta_10100500100000Cta_10100500102000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500102000.cta_10100500102010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500102000.cta_10100500102010Specified = specified;
                    break;
                case "10100500102020":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100500000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100500000000Cta_10100500100000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500102000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100500000000Cta_10100500100000Cta_10100500102000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500102000.cta_10100500102020 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100500000000.cta_10100500100000.cta_10100500102000.cta_10100500102020Specified = specified;
                    break;
                case "10100600101010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600100000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000.cta_10100600101000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000.cta_10100600101000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600100000Cta_10100600101000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000.cta_10100600101000.cta_10100600101010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000.cta_10100600101000.cta_10100600101010Specified = specified;
                    break;
                case "10100600102010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600100000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000.cta_10100600102000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000.cta_10100600102000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600100000Cta_10100600102000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000.cta_10100600102000.cta_10100600102010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600100000.cta_10100600102000.cta_10100600102010Specified = specified;
                    break;
                case "10100600201010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600200000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000.cta_10100600201000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000.cta_10100600201000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600200000Cta_10100600201000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000.cta_10100600201000.cta_10100600201010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000.cta_10100600201000.cta_10100600201010Specified = specified;
                    break;
                case "10100600202010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600200000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000.cta_10100600202000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000.cta_10100600202000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600200000Cta_10100600202000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000.cta_10100600202000.cta_10100600202010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600200000.cta_10100600202000.cta_10100600202010Specified = specified;
                    break;
                case "10100600301010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600300000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000.cta_10100600301000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000.cta_10100600301000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600300000Cta_10100600301000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000.cta_10100600301000.cta_10100600301010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000.cta_10100600301000.cta_10100600301010Specified = specified;
                    break;
                case "10100600302010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600300000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000.cta_10100600302000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000.cta_10100600302000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600300000Cta_10100600302000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000.cta_10100600302000.cta_10100600302010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600300000.cta_10100600302000.cta_10100600302010Specified = specified;
                    break;
                case "10100600401010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600400000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000.cta_10100600401000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000.cta_10100600401000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600400000Cta_10100600401000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000.cta_10100600401000.cta_10100600401010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000.cta_10100600401000.cta_10100600401010Specified = specified;
                    break;
                case "10100600402010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600400000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000.cta_10100600402000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000.cta_10100600402000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600400000Cta_10100600402000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000.cta_10100600402000.cta_10100600402010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600400000.cta_10100600402000.cta_10100600402010Specified = specified;
                    break;
                case "10100600501010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600500000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000.cta_10100600501000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000.cta_10100600501000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600500000Cta_10100600501000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000.cta_10100600501000.cta_10100600501010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000.cta_10100600501000.cta_10100600501010Specified = specified;
                    break;
                case "10100600502010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600500000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000.cta_10100600502000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000.cta_10100600502000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600500000Cta_10100600502000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000.cta_10100600502000.cta_10100600502010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600500000.cta_10100600502000.cta_10100600502010Specified = specified;
                    break;
                case "10100600601010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600600000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000.cta_10100600601000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000.cta_10100600601000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600600000Cta_10100600601000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000.cta_10100600601000.cta_10100600601010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000.cta_10100600601000.cta_10100600601010Specified = specified;
                    break;
                case "10100600602010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600600000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000.cta_10100600602000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000.cta_10100600602000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600600000Cta_10100600602000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000.cta_10100600602000.cta_10100600602010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600600000.cta_10100600602000.cta_10100600602010Specified = specified;
                    break;
                case "10100600701010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600700000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000.cta_10100600701000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000.cta_10100600701000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600700000Cta_10100600701000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000.cta_10100600701000.cta_10100600701010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000.cta_10100600701000.cta_10100600701010Specified = specified;
                    break;
                case "10100600702010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600700000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000.cta_10100600702000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000.cta_10100600702000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600700000Cta_10100600702000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000.cta_10100600702000.cta_10100600702010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600700000.cta_10100600702000.cta_10100600702010Specified = specified;
                    break;
                case "10100600901010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600900000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000.cta_10100600901000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000.cta_10100600901000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600900000Cta_10100600901000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000.cta_10100600901000.cta_10100600901010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000.cta_10100600901000.cta_10100600901010Specified = specified;
                    break;
                case "10100600902010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600900000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000.cta_10100600902000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000.cta_10100600902000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100600900000Cta_10100600902000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000.cta_10100600902000.cta_10100600902010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100600900000.cta_10100600902000.cta_10100600902010Specified = specified;
                    break;
                case "10100601001010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100601000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000.cta_10100601001000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000.cta_10100601001000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100601000000Cta_10100601001000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000.cta_10100601001000.cta_10100601001010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000.cta_10100601001000.cta_10100601001010Specified = specified;
                    break;
                case "10100601002010":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100601000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000.cta_10100601002000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000.cta_10100601002000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100601000000Cta_10100601002000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000.cta_10100601002000.cta_10100601002010 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100601000000.cta_10100601002000.cta_10100601002010Specified = specified;
                    break;
                case "10100609901990":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100609900000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000.cta_10100609901000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000.cta_10100609901000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100609900000Cta_10100609901000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000.cta_10100609901000.cta_10100609901990 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000.cta_10100609901000.cta_10100609901990Specified = specified;
                    break;
                case "10100609902990":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100609900000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000.cta_10100609902000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000.cta_10100609902000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100600000000Cta_10100609900000Cta_10100609902000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000.cta_10100609902000.cta_10100609902990 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100600000000.cta_10100609900000.cta_10100609902000.cta_10100609902990Specified = specified;
                    break;
                case "10100800101000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800100000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800100000.cta_10100800101000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800100000.cta_10100800101000Specified = specified;
                    break;
                case "10100800102000":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800100000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800100000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800100000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800100000.cta_10100800102000 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800100000.cta_10100800102000Specified = specified;
                    break;
                case "10100800801020":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000Cta_10100800801000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000.cta_10100800801020 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000.cta_10100800801020Specified = specified;
                    break;
                case "10100800801030":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000Cta_10100800801000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000.cta_10100800801030 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000.cta_10100800801030Specified = specified;
                    break;
                case "10100800801040":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000Cta_10100800801000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000.cta_10100800801040 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000.cta_10100800801040Specified = specified;
                    break;
                case "10100800801070":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000Cta_10100800801000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000.cta_10100800801070 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800801000.cta_10100800801070Specified = specified;
                    break;
                case "10100800802020":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000Cta_10100800802000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000.cta_10100800802020 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000.cta_10100800802020Specified = specified;
                    break;
                case "10100800802030":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000Cta_10100800802000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000.cta_10100800802030 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000.cta_10100800802030Specified = specified;
                    break;
                case "10100800802040":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000Cta_10100800802000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000.cta_10100800802040 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000.cta_10100800802040Specified = specified;
                    break;
                case "10100800802070":
                    if (modelo.cta_10000000000000 == null)
                        modelo.cta_10000000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000();
                    if (modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000 == null)
                        modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000 = new Architect.Sugese.SaldosContables.Domain.ModeloSaldosContablesNIIF17DatosModeloCta_10000000000000Cta_10100000000000Cta_10100800000000Cta_10100800800000Cta_10100800802000();
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000.cta_10100800802070 = value;
                    modelo.cta_10000000000000.cta_10100000000000.cta_10100800000000.cta_10100800800000.cta_10100800802000.cta_10100800802070Specified = specified;
                    break;

            }
        }
    }
}
