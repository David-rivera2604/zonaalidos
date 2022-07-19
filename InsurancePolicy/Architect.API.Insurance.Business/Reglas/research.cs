using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Architect.API.Insurance.Business.Reglas
{

    public static class research
    {

        public static string Apply_Comportamientos(string ruleFile, object data, Core.Contracts.Security.Token tokenInfo)
        {
            string cacheKey = $"decision.{ruleFile}.Behavior.source";
            List<Core.Contracts.General.Error> errors = null;
            string result = string.Empty;

            string script = BuildScript(cacheKey, "Behavior", Specification(ruleFile), ruleFile, data);
            if (script.IsNotEmpty())
            {
                errors = (List<Architect.API.Core.Contracts.General.Error>)Decision.Runtime.Execute(cacheKey, script, data, tokenInfo, null, null)["errors"];
            }

            if (errors != null)
            {
                foreach (Core.Contracts.General.Error error in errors)
                {
                    if (result.IsNotEmpty())
                    {
                        result += ",";
                    }
                    result += error.Key;
                }
            }
            return result;
        }

        public static string JSCode_Comportamientos(string ruleFile)
        {
            string cacheKey = $"decision.{ruleFile}.Behavior.js.source";

            return BuildScript(cacheKey, "Behavior", Specification(ruleFile), ruleFile, null, true);
        }


        public static List<Core.Contracts.General.Error> Apply_Reglas(string ruleFile, object data, Core.Contracts.Security.Token tokenInfo)
        {
            string cacheKey = $"decision.{ruleFile}.rules.source";
            List<Core.Contracts.General.Error> errors = null;

            string script = BuildScript(cacheKey, "Rules", Specification(ruleFile), ruleFile, data);
            if (script.IsNotEmpty())
            {
                errors = (List<Architect.API.Core.Contracts.General.Error>)Decision.Runtime.Execute(cacheKey, script, data, tokenInfo, null, null)["errors"];
            }

            if (errors == null)
            {
                errors = new List<Core.Contracts.General.Error>();
            }
            return errors;
        }


        internal static Core.Contracts.Especificacion.Producto Specification(string ruleFile)
        {
            return Utilities.SerializeHandler<Core.Contracts.Especificacion.Producto>.DeserializeJSONFromFile(string.Format(@"{0}\{1}.rules.json", ConfigurationManager.AppSettings["Product.Definition.Path"], ruleFile)); ;
        }


        internal static string BuildScript(string cacheKey, string key, Core.Contracts.Especificacion.Producto def, string ruleFile, object data, bool javascript = false)
        {
            string basePath = ConfigurationManager.AppSettings["Product.Definition.Path"];
            string script = string.Empty;

            if (Utilities.Helpers.Settings.StringValue("Working.Mode") != "Development" && Utilities.Cache.Exist(cacheKey))
            {
                script = ((string)Utilities.Cache.GetItem(cacheKey));
            }
            else
            {
                if (key.Equals("Rules", StringComparison.CurrentCultureIgnoreCase) && def.Reglas?.Count > 0)
                {
                    script = BuildRulesCode(data, ruleFile, def.Reglas,
                                new Decision.Vocabulary.Condition($"{basePath}\\syntax.settings.json",
                                        $"{basePath}\\convention.settings.json",
                                        $"{basePath}\\{ruleFile}.vocabulary.json"));
                }

                if (key.Equals("Behavior", StringComparison.CurrentCultureIgnoreCase) && def.Comportamientos?.Count > 0)
                {
                    if (javascript)
                    {
                        script = BuildComportamientoJavaScriptCode(def.Comportamientos,
                                    new Decision.Vocabulary.Condition($"{basePath}\\syntax.settings.json",
                                            $"{basePath}\\convention.settings.json",
                                            $"{basePath}\\{ruleFile}.vocabulary.json"));
                    }
                    else
                    {
                        script = BuildComportamientoCode(data, def.Comportamientos,
                                    new Decision.Vocabulary.Condition($"{basePath}\\syntax.settings.json",
                                            $"{basePath}\\convention.settings.json",
                                            $"{basePath}\\{ruleFile}.vocabulary.json"));
                    }
                }
                if (script.IsNotEmpty())
                {
                    Utilities.Cache.SetItem(cacheKey, script);
                }
            }

            return script;
        }


        internal static string BuildRulesCode(object data, string ruleFile, List<Core.Contracts.Especificacion.Regla> rules, Architect.Decision.Vocabulary.Condition condition)
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
                script.AppendFormat("if ({0}){{errors.Add(new Architect.API.Core.Contracts.General.Error() {{ Group = \"{1}\", Key = \"{2}\", Message = \"{3}\" }});}}\n", condition.Parser(rule.Condicion), rule.Grupo, rule.Campo, rule.Mensaje);
            }
            return script.ToString();
        }

        internal static string BuildComportamientoCode(object data, List<Core.Contracts.Especificacion.Comportamiento> behaviors, Architect.Decision.Vocabulary.Condition condition)
        {
            StringBuilder script = new StringBuilder();

            script.AppendFormat("{0} data = ({0})Data;\n", data.GetType().FullName);
            script.Append("List<Architect.API.Core.Contracts.General.Error> errors = new List<Architect.API.Core.Contracts.General.Error>();\n");

            foreach (Core.Contracts.Especificacion.Comportamiento behavior in behaviors)
            {
                script.AppendFormat("if ({0}){{errors.Add(new Architect.API.Core.Contracts.General.Error() {{ Key = \"{1}\", Message = \"{2}\" }});}}\n", condition.Parser(behavior.Condicion), behavior.Accion, behavior.Descripcion);
            }
            return script.ToString();
        }

        internal static string BuildComportamientoJavaScriptCode(List<Core.Contracts.Especificacion.Comportamiento> behaviors, Architect.Decision.Vocabulary.Condition condition)
        {
            StringBuilder script = new StringBuilder();

            script.Append("app.poliza.EvalBehavior = function () {let result = '', data=app.PolicyEdit.Data();");


            foreach (Core.Contracts.Especificacion.Comportamiento behavior in behaviors)
            {
                script.AppendFormat("if({0}){{result += ',{1}';}}\n", condition.Parser(behavior.Condicion, "JavaScript"), behavior.Accion);
            }
            script.Append("return {Behavior: result};}");
            return script.ToString();
        }

    }
}
