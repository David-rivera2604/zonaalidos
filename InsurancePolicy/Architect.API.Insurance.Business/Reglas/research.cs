using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Architect.API.Insurance.Business.Reglas
{

    public static class research
    {

        public static List<Architect.API.Core.Contracts.General.Error> Apply_Reglas(string ruleFile, object data, Core.Contracts.Security.Token tokenInfo)
        {
            string key = $"{ruleFile}.reglas";
            string cacheKey = $"decision.{ruleFile}.reglas.source";
            string script = string.Empty;
            List<Core.Contracts.General.Error> errors = null;

            if (Utilities.Cache.Exist(cacheKey))
            {
                script = ((string)Utilities.Cache.GetItem(cacheKey));
            }
            else
            {
                Core.Contracts.Especificacion.Producto def = Utilities.SerializeHandler<Core.Contracts.Especificacion.Producto>.DeserializeJSONFromFile(string.Format(@"{0}\{1}.rules.json", ConfigurationManager.AppSettings["Product.Definition.Path"], ruleFile));

                if (def.Reglas?.Count > 0)
                {
                    script = BuildRulesCode(ruleFile, data, def.Reglas);
                    Utilities.Cache.SetItem(cacheKey, script);
                }
            }
            if (script.IsNotEmpty())
            {
                errors = (List<Architect.API.Core.Contracts.General.Error>)Decision.Runtime.Execute(key, script, data, tokenInfo, null, null)["error"];
            }

            if (errors == null)
            {
                errors = new List<Core.Contracts.General.Error>();
            }
            return errors;
        }

        internal static string BuildRulesCode(string ruleFile, object data, List<Core.Contracts.Especificacion.Regla> rules)
        {
            string basePath = ConfigurationManager.AppSettings["Product.Definition.Path"];
            Architect.Decision.Vocabulary.Condition _rule = new Decision.Vocabulary.Condition(
                $"{basePath}\\syntax.settings.json",
                $"{basePath}\\convention.settings.json",
                $"{basePath}\\{ruleFile}.vocabulary.json");

            StringBuilder script = new StringBuilder();

            script.AppendFormat("{0} data = ({0})Data;\n", data.GetType().FullName);
            script.Append("List<Architect.API.Core.Contracts.General.Error> errors = new List<Architect.API.Core.Contracts.General.Error>();\n");

            foreach (Core.Contracts.Especificacion.Regla rule in rules)
            {
                if (rule.Grupo.IsEmpty())
                {
                    rule.Grupo = ruleFile;
                }
                script.AppendFormat("if ({0}){{errors.Add(new Architect.API.Core.Contracts.General.Error() {{ Group = \"{1}\", Key = \"{2}\", Message = \"{3}\" }});}}\n", _rule.Parser(rule.Condicion), rule.Grupo, rule.Campo, rule.Mensaje);
            }
            return script.ToString();
        }
    }
}
