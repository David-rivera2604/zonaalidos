using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architect.API.Core.Business.General
{
    /// <summary>
    /// .
    /// </summary>
    public static class Rule
    {
        public static async Task Runtime(int companyId, int userId, int entityType, string action, object entitySource)
        {
            Architect.Common.Helpers.LogHandler.WarningLog(entityType.ToString(), action, "rules");

            //TODO: Es necesario optimizar estas lecturas 1
            if (DataAccess.General.Rules.CountByEntityAction(companyId, entityType, action) > 0)
            {
                string code = string.Format("{0} data = ({0})Data;", entitySource.GetType().FullName);
                //TODO: Es necesario optimizar estas lecturas 2
                List<Architect.API.Core.Contracts.General.Rules> rules = DataAccess.General.Rules.RetrieveByEntityAction(companyId, entityType, action);
                Contracts.General.RuleContext context = new Contracts.General.RuleContext() { Data = entitySource };
                foreach (Architect.API.Core.Contracts.General.Rules item in rules)
                {
                    code += item.Statement;
                }

                await CSharpScript.EvaluateAsync(code,
                    ScriptOptions.Default.WithReferences(typeof(Architect.Common.Helpers.LogHandler).Assembly,
                                                         typeof(Architect.API.Core.Business.General.Mail).Assembly,
                                                         entitySource.GetType().Assembly),
                    globals: context).ConfigureAwait(false);

                //if (entityType == 1001)
                //{
                //    string header = string.Format("{0} data = ({0})Data;", entitySource.GetType().FullName);
                //    await CSharpScript.EvaluateAsync(header + "if(data.RoleId == 4) {Architect.Common.Helpers.LogHandler.WarningLog(\"Rol de suscriptor\", \"Si\"); Architect.API.Core.Business.General.Mail.Send(\"solernelson@hotmail.com\", \"test {Description}   \", \"Is ok  {Description}\", Data);} else Architect.Common.Helpers.LogHandler.WarningLog(\"Rol de suscriptor\", \"No\");",
                //        ScriptOptions.Default.WithReferences(typeof(Architect.Common.Helpers.LogHandler).Assembly,
                //                                             typeof(Architect.API.Core.Business.General.Mail).Assembly,
                //                                             entitySource.GetType().Assembly),
                //        globals: context).ConfigureAwait(false);
                //}
            }
            //var script = CSharpScript.Create("1 + 2");
            //script.Compile();
            //var xx = script.RunAsync().Result.ReturnValue;
        }

        public static async Task<bool> Condition(string statement, object entitySource)
        {

                string code = string.Format("{0} data = ({0})Data;{1}", entitySource.GetType().FullName, statement);

                Contracts.General.RuleContext context = new Contracts.General.RuleContext() { Data = entitySource };

                bool result = (bool) await CSharpScript.EvaluateAsync(code,
                                        ScriptOptions.Default.WithReferences(typeof(Architect.Common.Helpers.LogHandler).Assembly,
                                                                             typeof(Architect.Utilities.Cache).Assembly,
                                                                              entitySource.GetType().Assembly).AddImports("Architect.Utilities.Extensions"),
                                            globals: context).ConfigureAwait(false);

            return result;
        }
    }
}
