using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Architect.API.Insurance.Business.Reglas
{

    public static class research
    {

        public static List<Architect.API.Core.Contracts.General.Error> Apply_Reglas(string ruleFile, object data, Core.Contracts.Security.Token tokenInfo)
        {
            List<Core.Contracts.General.Error> errors = null;
            string filename = string.Format(@"{0}\{1}.rules.json", ConfigurationManager.AppSettings["Product.Definition.Path"], ruleFile);
            if (System.IO.File.Exists(filename))
            {
                Core.Contracts.Especificacion.Producto def = Utilities.SerializeHandler<Core.Contracts.Especificacion.Producto>.DeserializeJSONFromFile(filename);
                
                if (def.Reglas?.Count > 0)
                {
                    errors = Architect.API.Core.Business.General.Rule.ApplyRules(ruleFile, BuildRulesCode(ruleFile, data, def.Reglas), data, tokenInfo).Result;
                }
            } else
            {
                Utilities.Log.TraceLog(" Apply_Reglas", string.Format("No existe el archivo de reglas '{0}.rules.json'", ruleFile), "Architect.API.Insurance");
            }
            if (errors == null)
            {
                errors = new List<Core.Contracts.General.Error>();
            }
            return errors;
        }

        internal static string BuildRulesCode(string ruleFile, object data, List<Core.Contracts.Especificacion.Regla> rules)
        {
            StringBuilder script = new StringBuilder();

            script.AppendFormat("{0} data = ({0})Data;\n", data.GetType().FullName);
            script.Append("List<Architect.API.Core.Contracts.General.Error> errors = new List<Architect.API.Core.Contracts.General.Error>();\n");

            foreach (Core.Contracts.Especificacion.Regla rule in rules)
            {
                if (rule.Grupo.IsEmpty())
                {
                    rule.Grupo = ruleFile;
                }
                script.AppendFormat("if ({0}){{errors.Add(new Architect.API.Core.Contracts.General.Error() {{ Group = \"{1}\", Key = \"{2}\", Message = \"{3}\" }});}}\n", ConditionParser(ruleFile, rule.Condicion), rule.Grupo, rule.Campo, rule.Mensaje);
            }
            return script.ToString();
        }
        internal static string ConditionParser(string ruleFile, string condition)
        {
            string code = condition;

            code = code.Replace("{el ", "{");
            code = code.Replace("{El ", "{");
            code = code.Replace("{La ", "{");
            code = code.Replace("{la ", "{");
            code = code.Replace(" sea ", " es ");
            code = code.Replace(" Sea ", " es ");
            code = code.Replace("{No tiene", "{No hay");
            code = code.Replace("{no tiene", "{No hay");

            MatchCollection parameterMatches = Regex.Matches(code, @"{(.+?)}"); // ([^)]*)

            foreach (Match paremeter in parameterMatches)
            {
                switch (paremeter.Value.ToLower())
                {
                    case "{moneda}":
                        code = code.Replace(paremeter.Value, "data.cod_mon");
                        break;
                    case "{valor del vehículo}":
                    case "{valor del vehiculo}":
                        code = code.Replace(paremeter.Value, "data.IMP_VR");
                        break;
                    case "{marca del vehículo}":
                    case "{marca del vehiculo}":
                        code = code.Replace(paremeter.Value, "data.cod_marca");
                        break;
                    case "{año del vehículo}":
                    case "{año del vehiculo}":
                    case "{año de fabricación}":
                    case "{año de fabricacion}":
                        code = code.Replace(paremeter.Value, "data.ANIO_SUB_MODELO");
                        break;
                    case "{contrato}":
                        code = code.Replace(paremeter.Value, "data.contrato");
                        break;
                    case "{suma asegurada de colisión y vuelco}":
                    case "{suma asegurada de colision y vuelco}":
                        code = code.Replace(paremeter.Value, "data.IMP_AUTO_CYV");
                        break;
                    case "{suma asegurada de gastos médicos}":
                    case "{suma asegurada de gastos medicos}":
                        code = code.Replace(paremeter.Value, "data.IMP_AUTO_CYV");
                        break;
                    case "{suma asegurada de riesgos adicionales}":
                        code = code.Replace(paremeter.Value, "data.IMP_AUTO_RAD");
                        break;
                    case "{suma asegurada de robo}":
                        code = code.Replace(paremeter.Value, "data.IMP_AUTO_ROB");
                        break;
                    case "{plan}":
                        code = code.Replace(paremeter.Value, "data.COD_PLAN_AUTO");
                        break;
                    case "{tipo de producto}":
                        code = code.Replace(paremeter.Value, "data.tipo_prod");
                        break;
                }
            }
            code = code.Replace(" y ", " && ");
            code = code.Replace(" Y ", " && ");
            code = code.Replace(" o ", " || ");
            code = code.Replace(" O ", " || ");
            code = code.Replace("No sea {", "!{");
            code = code.Replace("no sea {", "!{");
            code = code.Replace("es menor a ", " < ");
            code = code.Replace("es mayor a ", " > ");

            Match oldParemeter = null;
            foreach (Match paremeter in parameterMatches)
            {
                switch (paremeter.Value.ToLower())
                {
                    case "{básico}":
                    case "{basico}":
                        code = code.Replace(paremeter.Value, "31");
                        break;
                    case "{amplio}":
                        code = code.Replace(paremeter.Value, "32");
                        break;
                    case "{plus}":
                        code = code.Replace(paremeter.Value, "33");
                        break;
                    case "{oro}":
                        code = code.Replace(paremeter.Value, "34");
                        break;
                    case "{plata}":
                        code = code.Replace(paremeter.Value, "35");
                        break;
                    case "{trébol}":
                    case "{trebol}":
                        code = code.Replace(paremeter.Value, "36");
                        break;
                    case "{trébol rc}":
                    case "{trebol rc}":
                        if (oldParemeter?.Value.ToLower() == "{tipo de producto}")
                            code = code.Replace(paremeter.Value, "\"trebolrc\"");
                        else
                            code = code.Replace(paremeter.Value, "37");
                        break;

                    case "{colones}":
                    case "{colon}":
                        code = code.Replace(paremeter.Value, "1");
                        break;
                    case "{dolares}":
                    case "{dolar}":
                    case "{dólares}":
                    case "{dólar}":
                        code = code.Replace(paremeter.Value, "2");
                        break;
                    case "{no hay coberturas seleccionadas}":
                        code = code.Replace(paremeter.Value, "!data.coberturas.Any(r => r.seleccionado)");
                        break;
                    case "{hay coberturas seleccionadas}":
                        code = code.Replace(paremeter.Value, "data.coberturas.Any(r => r.seleccionado)");
                        break;

                    default:
                        if (paremeter.Value.ToLower().StartsWith("{cobertura ") && paremeter.Value.ToLower().EndsWith(" es seleccionada}"))
                        {
                            code = code.Replace(paremeter.Value, string.Format("data.coberturas.Any(r => r.codigo == {0} && r.seleccionado)", paremeter.Value.Substring(11, paremeter.Value.Length - 28).Trim()));
                        }
                        if (paremeter.Value.ToLower().StartsWith("{rol es igual a "))
                        {
                            code = code.Replace(paremeter.Value, string.Format("token.Roles.Contain(\"{0}\")", paremeter.Value.Substring(16, paremeter.Value.Length - 17)));
                        }
                        if (paremeter.Value.ToLower().StartsWith("{rol del usuario es igual a "))
                        {
                            code = code.Replace(paremeter.Value, string.Format("token.Roles.Contain(\"{0}\")", paremeter.Value.Substring(28, paremeter.Value.Length - 29)));
                        }
                        if (paremeter.Value.ToLower().StartsWith("{rol no es igual a "))
                        {
                            code = code.Replace(paremeter.Value, string.Format("!token.Roles.Contain(\"{0}\")", paremeter.Value.Substring(19, paremeter.Value.Length - 20)));
                        }
                        if (paremeter.Value.ToLower().StartsWith("{rol del usuario no es igual a "))
                        {
                            code = code.Replace(paremeter.Value, string.Format("!token.Roles.Contain(\"{0}\")", paremeter.Value.Substring(31, paremeter.Value.Length - 32)));
                        }
                        if (paremeter.Value.ToLower().EndsWith(" año de antigüedad}") || paremeter.Value.ToLower().EndsWith(" año de antiguedad}"))
                        {
                            code = code.Replace(paremeter.Value, string.Format("(DateTime.Today.Year - {0})", paremeter.Value.Substring(1, paremeter.Value.Length - 20)));
                        }
                        if (paremeter.Value.ToLower().EndsWith(" años de antigüedad}") || paremeter.Value.ToLower().EndsWith(" años de antiguedad}"))
                        {
                            code = code.Replace(paremeter.Value, string.Format("(DateTime.Today.Year - {0})", paremeter.Value.Substring(1, paremeter.Value.Length - 21)));
                        }
                        break;
                }
                oldParemeter = paremeter;
            }
            code = code.Replace(" no es igual a ", " != ");
            code = code.Replace(" es diferente a ", " != ");
            code = code.Replace(" es igual a ", " == ");
            code = code.Replace(" es menor que ", " < ");
            code = code.Replace(" es menor o igual que ", " <= ");
            code = code.Replace(" es mayor que ", " > ");
            code = code.Replace(" es mayor o igual que ", " >= ");

            code = code.Replace(" no igual a ", " != ");
            code = code.Replace(" diferente a ", " != ");
            code = code.Replace(" igual a ", " == ");
            code = code.Replace(" menor que ", " < ");
            code = code.Replace(" menor o igual que ", " <= ");
            code = code.Replace(" mayor que ", " > ");
            code = code.Replace(" mayor o igual que ", " >= ");
            return code;
        }

    }
}
