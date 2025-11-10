using Architect.DataFactory;
using Architect.Sugese.Validadores.Domain;
using Architect.Utilities.Extensions;
using ClosedXML.Excel;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Architect.Sugese.Validadores.Application
{
    public static class Inspection
    {
        #region Private Field

        private static List<MetadataReference> _refs = new List<MetadataReference> {
                    MetadataReference.CreateFromFile(typeof(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException).GetTypeInfo().Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(System.Runtime.CompilerServices.DynamicAttribute).GetTypeInfo().Assembly.Location) ,
                    MetadataReference.CreateFromFile(typeof(Architect.Sugese.Validadores.Domain.Account ).GetTypeInfo().Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(HttpClient).GetTypeInfo().Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(CultureInfo).GetTypeInfo().Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(Architect.Sugese.Validadores.Domain.Message).GetTypeInfo().Assembly.Location ),
                    MetadataReference.CreateFromFile(typeof(Architect.Utilities.Extensions.StringExtensions).GetTypeInfo().Assembly.Location )};

        private static List<string> _imports = new List<string>() {
                                                                      "System",
                                                                      "System.Collections.Generic",
                                                                      "Architect.Sugese.Validadores",
                                                                      "System.Globalization",
                                                                      "Architect.Sugese.Validadores.Domain" ,
                                                                      "Architect.Common.Extensions"
                                                                  };

        #endregion Private Field

        public static void Create(string file)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(System.IO.File.ReadAllText(file));

            JObject root = JObject.Parse(JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.Indented));
            string nameProperty = root.Properties().Skip(1).FirstOrDefault().Name;
            root = root[nameProperty]["Datos"]["Modelo"] as JObject;
            var items = root.Properties().Where(r => !r.Name.StartsWith("@")).Select(p => p).ToList();

            List<Account> records = new List<Account>();

            foreach (var item in items)
            {
                records.AddRange(ModelProcess(item.Name, (JObject)item.Value));
            }

            records = records.Select((elemento, index) => new Account
            {
                Id = index + 1,
                Name = elemento.Name,
                Amount = elemento.Amount
            }).ToList();

            Database.Delete("DELETE FROM ACCOUNT")
                    .Query("Research");

            Database.Bulk("Research", "ACCOUNT", records.ToTable());
        }

        private static List<Account> ModelProcess(string key, JObject root)
        {
            List<Account> result = new List<Account>();
            key = key.Replace("cta_", "").Trim();
            var pathKey = $"@Total{key}";
            if (root.ContainsKey(pathKey))
            {
                result.Add(new Account() { Name = key, Amount = root[pathKey].Value<decimal>() });
                var items = root.Properties().Where(r => !r.Name.StartsWith("@Total")).Select(p => p).ToList();
                foreach (var item in items)
                {
                    var keyInternal = item.Name;
                    if (item.Value.Type == JTokenType.String)
                    {
                        result.Add(new Account() { Name = item.Name.Replace("cta_", "").Trim(), Amount = root[item.Name].Value<decimal>() });
                    }
                    else
                        result.AddRange(ModelProcess(keyInternal, (JObject)item.Value));
                }
            }
            return result;
        }

        public static string ToSheetName(this string target)
        {
            return target.Split(':')[0];
        }

        public static string ToCell(this string target)
        {
            var value = string.Concat(target.Split(':')[1]
           .Select((c, i) => new { Character = c, Index = i })
           .TakeWhile(x => !(target.Split(':')[1][x.Index] == '#' && target.Split(':')[1].ElementAtOrDefault(x.Index + 1) == '#'))
           .Select(x => x.Character));
            return value;
        }

        public static bool IsAppend(this string target)
        {
            return target.ToLower().Contains("##ADD".ToLower());
        }

        public static void DefultValues(string fileExcel, Dictionary<string, double> items, List<Domain.Inspection> validations)
        {
            var workbook = new XLWorkbook(fileExcel);
            foreach (var item in validations.Where(c => c.Target.IsNotEmpty()).ToList())
            {
                var worksheet = workbook.Worksheet(item.Target.ToSheetName());
                var cell = worksheet.Cell(item.Target.ToCell());
                if (!item.Target.IsAppend())
                {
                    cell.Value = item.Left.Value(items);
                    cell.CreateComment().AddText($"Cuenta catalogo:{item.Left.Names()}");
                }
                //else
                //{
                //    cell.Comment.AddText($"Cuentas del catalogo:{item.Left.Names()} con valor {item.Left.Value(catalog)}");
                //}

                //worksheet.Columns().AdjustToContents();
            }

            workbook.Save();
        }

        public static GlobalsValidationResult ValidationModel(string fileModel, Dictionary<string, double> items, List<Domain.Inspection> validations)
        {
            GlobalsValidationResult result = new GlobalsValidationResult() { Successfully = false };
            result = Check(validations.Code(PathsOfModel(fileModel)), items, Model(fileModel));
            return result;
        }

        public static dynamic Model(string fileModel)
        {
            XmlDocument xmlDoc = new XmlDocument();
            var body = System.IO.File.ReadAllText(fileModel);

            string pattern = @"<(\w+)\s+xsi:nil=""true""\s*/>";
            body = Regex.Replace(body, pattern, @"<$1>0</$1>");

            xmlDoc.LoadXml(body);
            var root = (JObject.Parse(JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.Indented)));
            root = (JObject)root.Properties().ElementAt(1).Value;
            root = root["Datos"]["Modelo"].Value<JObject>();
            RemoveAtPrefix(root);
            return root.ToString().DeserializeJSON<ExpandoObject>();
        }

        public static void PathsByXMLSave(string fileModel)
        {
            var fileName = System.IO.Path.GetFileName(fileModel);
            System.IO.File.WriteAllText(fileModel.Replace(fileName, "path.txt"), string.Join(Environment.NewLine, PathsOfModel(fileModel)));
        }

        public static List<string> PathsOfModel(string fileModel)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(System.IO.File.ReadAllText(fileModel));
            var root = (JObject.Parse(JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.Indented)));
            root = (JObject)root.Properties().ElementAt(1).Value;
            root = root["Datos"]["Modelo"].Value<JObject>();
            Inspection.RemoveAtPrefix(root);
            return Print(root).Select(c => $"model.{c}").ToList();
        }

        public static GlobalsValidationResult Check(string code, Dictionary<string, double> catalogs, dynamic model)
        {
            GlobalsValidationResult result = null;
            if (code.IsNotEmpty())
            {
                try
                {
                    var scriptOptions = ScriptOptions.Default.AddReferences(_refs).WithImports(_imports);
                    var script = CSharpScript.Create(code, scriptOptions, typeof(GlobalsValidationResult));
                    result = new GlobalsValidationResult { catalog = catalogs, model = model };
                    var resultScript = script.RunAsync(result).Result;
                }
                catch (Exception ex)
                {
                    result.Successfully = false;
                }
            }
            return result;
        }

        public static string Convert(this string left)
        {
            var items = Regex.Split(left.ToLower().Replace("cta_", ""), @"[\+\-\*/]");
            return String.Join(",", items);
            return left.ToLower().Replace("cta_", "");
        }

        public static double Value(this string left, Dictionary<string, double> catalog)
        {
            var expression = left;
            var itemExpression = Regex.Split(left.ToLower(), @"[\+\-\*/]").Select(c => c.Trim()).ToList();
            foreach (string item in itemExpression)
            {
                if (item.ToLower().StartsWith("cta"))
                    expression = expression.Replace(item, $" catalog[\"{item.Replace("cta_", "")}\"]");
            }
            expression = "Value = " + expression;
            var context = new GlobalsValidationResult { catalog = catalog };
            try
            {
                var scriptOptions = ScriptOptions.Default.AddReferences(_refs).WithImports(_imports);
                var script = CSharpScript.Create(expression, scriptOptions, typeof(GlobalsValidationResult));

                var resultScript = script.RunAsync(context).Result;
            }
            catch (Exception ex)
            {
                context.Successfully = false;
            }

            return context.Value;
        }

        public static string Names(this string left)
        {
            var items = Regex.Split(left.ToLower().Replace("cta_", ""), @"[\+\-\*/]");
            return String.Join(",", items);
        }

        public static void RemoveAtPrefix(JToken token)
        {
            if (token.Type == JTokenType.Object)
            {
                List<JProperty> properties = token.Children<JProperty>().ToList();
                foreach (JProperty prop in properties)
                {
                    if (prop.Name.StartsWith("@"))
                    {
                        var newProp = new JProperty(prop.Name.Substring(1), prop.Value);
                        prop.Replace(newProp);
                    }
                    RemoveAtPrefix(prop.Value);
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (JToken child in token.Children())
                {
                    RemoveAtPrefix(child);
                }
            }
        }

        public static void ReplaceNilValues(JObject obj, string defaultValue)
        {
            foreach (var property in obj.Properties().ToList())
            {
                if (property.Value.Type == JTokenType.Object)
                {
                    ReplaceNilValues((JObject)property.Value, defaultValue);
                }
                else if (property.Value.Type == JTokenType.Array)
                {
                    foreach (var item in (JArray)property.Value)
                    {
                        if (item.Type == JTokenType.Object)
                        {
                            ReplaceNilValues((JObject)item, defaultValue);
                        }
                        else if (item.Type == JTokenType.Null)
                        {
                            item.Replace(defaultValue);
                        }
                    }
                }
                else if (property.Value.Type == JTokenType.Null)
                {
                    property.Value = defaultValue;
                }
            }
        }

        public static List<string> Print(JToken token, string path = "")
        {
            List<string> result = new List<string>();

            if (token.Type == JTokenType.Property)
            {
                var property = (JProperty)token;
                string currentPath = string.IsNullOrEmpty(path) ? property.Name : $"{path}.{property.Name}";

                if (property.Value.Type != JTokenType.Object && property.Value.Type != JTokenType.Array)
                {
                    result.Add(currentPath);
                }
                else if (property.Value.Type == JTokenType.Array)
                {
                    for (int i = 0; i < property.Value.Count(); i++)
                    {
                        result.AddRange(Print(property.Value[i], $"{currentPath}[{i}]"));
                    }
                }
                else
                {
                    foreach (var child in property.Value.Children())
                    {
                        result.AddRange(Print(child, currentPath));
                    }
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                for (int i = 0; i < token.Count(); i++)
                {
                    result.AddRange(Print(token[i], $"{path}[{i}]"));
                }
            }
            else if (token.Type == JTokenType.Object)
            {
                foreach (var child in token.Children())
                {
                    result.AddRange(Print(child, path));
                }
            }
            else
            {
                result.Add(path);
            }

            return result;
        }

        public static string Code(this List<Domain.Inspection> items, List<string> pathsOfModel)
        {
            StringBuilder body = new StringBuilder();

            body.AppendLine(items.Fields());
            body.AppendLine(items.FieldsSet(pathsOfModel));
            body.AppendLine(items.Conditions());

            body.AppendLine("Successfully = Messages.Count == 0;");
            return body.ToString();
        }

        public static string NameLeft(this Domain.Inspection item)
        {
            return $"ValidationLeft{item.Id}";
        }

        public static string NameRight(this Domain.Inspection item)
        {
            return $"ValidationRight{item.Id}";
        }

        public static string Conditions(this List<Domain.Inspection> items)
        {
            StringBuilder result = new StringBuilder();
            items.ForEach(c => result.AppendLine(c.Condition()));
            return result.ToString();
        }

        public static string Condition(this Domain.Inspection item)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"if({item.NameLeft()} != {item.NameRight()} )");
            result.AppendLine($@"    Messages.Add(new Message {{ Value =&{item.Message}&.Formater({item.NameLeft()}.ToString(), {item.NameRight()}.ToString(), ""{item.Left}"" ,""{item.Right}""  ), Id = {item.Id}, Left = ValidationLeft{item.Id}, Right = ValidationRight{item.Id} }} );".Replace("#", "{").Replace("&", "\""));
            return result.ToString();
        }

        public static string Fields(this List<Domain.Inspection> items)
        {
            StringBuilder result = new StringBuilder();
            items.ForEach(c => result.AppendLine(c.Field()));
            return result.ToString();
        }

        public static string Field(this Domain.Inspection item)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"double {item.NameLeft()} = 0;");
            result.AppendLine($"double {item.NameRight()} = 0;");
            return result.ToString();
        }

        public static string FieldsSet(this List<Domain.Inspection> items, List<string> pathsOfModel)
        {
            StringBuilder result = new StringBuilder();
            items.ForEach(c => result.AppendLine(c.FieldSet(pathsOfModel)));
            return result.ToString();
        }

        public static string FieldSet(this Domain.Inspection item, List<string> pathsOfModel)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{item.NameLeft()} = {item.ValueLeft(pathsOfModel)};");
            result.AppendLine($"{item.NameRight()} = {item.ValueRight(pathsOfModel)};");
            return result.ToString();
        }

        public static string ValueLeft(this Domain.Inspection item, List<string> pathsOfModel)
        {
            StringBuilder result = new StringBuilder();
            result.Append(item.Left.Value(pathsOfModel));
            return result.ToString();
        }

        public static string ValueRight(this Domain.Inspection item, List<string> pathsOfModel)
        {
            StringBuilder result = new StringBuilder();
            result.Append(item.Right.Value(pathsOfModel));
            return result.ToString();
        }

        public static string Value(this string value, List<string> pathsOfModel)
        {
            var result = value;
            var itemExpression = Regex.Split(value, @"[\+\-\*/]").Select(c => c.Trim().Replace("(", "").Replace(")", "")).ToList();
            foreach (string item in itemExpression)
            {
                var itemValue = Regex.Match(item, @"sum\[(\w+)\]");
                if (itemValue.Success)
                {
                    var valueAdd = "";
                    if (pathsOfModel.Any(c => c.EndsWith(itemValue.Groups[1].Value)))
                        valueAdd = string.Join("+", pathsOfModel.Where(c => c.EndsWith(itemValue.Groups[1].Value)).ToList().Select(r => $"Double.Parse({r}, CultureInfo.InvariantCulture)").ToList());

                    result = result.Replace(item, $"Math.Round ({valueAdd}, {ConfigurationManager.AppSettings["Inspection.Round"]}, MidpointRounding.AwayFromZero)");
                }
                else if (item.ToLower().StartsWith("cta"))
                    result = result.Replace(item, $" catalog[\"{item.Replace("cta_", "")}\"]");
                else
                    result = result.Replace(item, $"double.Parse( {item}, NumberStyles.Float, CultureInfo.InvariantCulture)");
            }
            return result;
        }

        #region Accces data

        public static Dictionary<string, double> Load()
        {
            System.Collections.Concurrent.ConcurrentDictionary<string, double> result = new System.Collections.Concurrent.ConcurrentDictionary<string, double>();

            Database.Select("SELECT * FROM ACCOUNT")
                        .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.TryAdd(reader.StringValue("NAME"), (double)reader.NumericValue("AMOUNT"));
                        }));

            return result.ToDictionary(p => p.Key, p => p.Value);
        }

        public static List<Domain.Inspection> Defaults(string model)
        {
            List<Domain.Inspection> result = new List<Domain.Inspection>();

            Database.Select($@"SELECT i.* FROM Inspection i
                                INNER JOIN MODEL m ON i.MODELID = m.ID
                                        WHERE m.NAME = '{model}' AND i.ENABLE = 1  AND  i.TARGET IS NOT NULL")
                       .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                       {
                           result.Add(new Domain.Inspection
                           {
                               Id = reader.IntegerValue("ID"),
                               Left = reader.StringValue("LEFT"),
                               Tag = reader.StringValue("TAG"),
                               Target = reader.StringValue("TARGET")
                           });
                       }));

            return result;
        }

        public static List<Domain.Inspection> Validation(string model)
        {
            List<Domain.Inspection> result = new List<Domain.Inspection>();


            Database.Select($@"SELECT i.* FROM Inspection i
                                                INNER JOIN MODEL m ON i.MODELID = m.ID
                                                     WHERE m.NAME = '{model}' AND i.ENABLE = 1 ")
                    .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                    {
                        result.Add(new Domain.Inspection
                        {
                            Id = reader.IntegerValue("ID"),
                            Left = reader.StringValue("LEFT"),
                            Right = reader.StringValue("RIGHT"),
                            Tag = reader.StringValue("TAG"),
                            Target = reader.StringValue("TARGET"),
                            Message = reader.StringValue("MESSAGE")
                        });
                    })); 

            return result;
        }

        #endregion Accces data
    }
}