using Architect.API.Tron.Contracts.Emision;
using Architect.API.Tron.Contracts.Especificacion;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Reglas
{

    public static class research
    {

        public static Contracts.Especificacion.Producto UpdateProducto(string ruleFile, Contracts.Especificacion.Producto def)
        {

            foreach (Architect.API.Tron.Contracts.Especificacion.Regla rule in def.Reglas)
            {
                rule.Id = null;
                if (rule.Grupo.IsEmpty())
                {
                    rule.Grupo = null;
                }

                if (rule.Descripcion == rule.Mensaje)
                {
                    rule.Descripcion = null;
                }
            }

            Utilities.SerializeHandler<Architect.API.Tron.Contracts.Especificacion.Producto>.SerializeJSONToFile(def,
                ConfigurationManager.AppSettings["Product.Definition.Path"] + @"\" + ruleFile + ".rules.json", false, false, true);

            return def;
        }

        public static Contracts.Especificacion.Producto GetProducto(string ruleFile)
        {
            Contracts.Especificacion.Producto def = Utilities.SerializeHandler<Contracts.Especificacion.Producto>.DeserializeJSONFromFile(string.Format(@"{0}\{1}.rules.json", ConfigurationManager.AppSettings["Product.Definition.Path"], ruleFile));
            int index = 1;
            foreach (Architect.API.Tron.Contracts.Especificacion.Cobertura cobertura in def.Coberturas)
            {
                cobertura.Id = index++;
                if (cobertura.Descripcion.IsEmpty())
                {
                    cobertura.Descripcion = cobertura.Condicion.Replace("{", "").Replace("}", "");
                }
            }
            foreach (Architect.API.Tron.Contracts.Especificacion.Lista lista in def.Listas)
            {
                lista.Id = index++;
                if (lista.Descripcion.IsEmpty())
                {
                    lista.Descripcion = lista.Condicion.Replace("{","").Replace("}","");
                }
            }
            foreach (Architect.API.Tron.Contracts.Especificacion.Regla rule in def.Reglas)
            {
                rule.Id = index++;
                if (rule.Descripcion.IsEmpty())
                {
                    rule.Descripcion = rule.Mensaje;
                }
            }


            return def;
        }

        public static string Apply_Listas(string ruleFile, object data, string keyword, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Especificacion.Producto def = Utilities.SerializeHandler<Contracts.Especificacion.Producto>.DeserializeJSONFromFile(string.Format(@"{0}\{1}.rules.json", ConfigurationManager.AppSettings["Product.Definition.Path"], ruleFile));
            string result = string.Empty;
            if (def.Reglas?.Count > 0)
            {
                result = Architect.API.Core.Business.General.Rule.ApplyCoverages(ruleFile, BuildListasCode(ruleFile, data, def.Listas), data, keyword, tokenInfo).Result;
            }
            if (result == null)
            {
                result = string.Empty;
            }
            return result;
        }
        internal static string BuildListasCode(string ruleFile, object data, List<Lista> listas)
        {
            string basePath = ConfigurationManager.AppSettings["Product.Definition.Path"];
            Architect.Decision.Vocabulary.Condition _rule = new Architect.Decision.Vocabulary.Condition(
                $"{basePath}\\syntax.settings.json",
                $"{basePath}\\convention.settings.json",
                $"{basePath}\\{ruleFile}.vocabulary.json");
            StringBuilder script = new StringBuilder();
            script.AppendFormat("{0} data = ({0})Data;\n", data.GetType().FullName);
            script.Append("string exclude = string.Empty;\n");

            foreach (Architect.API.Tron.Contracts.Especificacion.Lista lista in listas)
            {
                script.AppendFormat("if(keyword==\"{2}\" && {0}){{exclude=\"{1}\";}}\n", _rule.Parser(lista.Condicion), lista.Exclusion, lista.Nombre);
            }
            return script.ToString();
        }

        public static string Apply_Coberturas(string ruleFile, object data, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Especificacion.Producto def = Utilities.SerializeHandler<Contracts.Especificacion.Producto>.DeserializeJSONFromFile(string.Format(@"{0}\{1}.rules.json", ConfigurationManager.AppSettings["Product.Definition.Path"], ruleFile));
            string result = string.Empty;
            if (def.Reglas?.Count > 0)
            {
                result = Architect.API.Core.Business.General.Rule.ApplyCoverages(ruleFile, BuildCoveragesCode(ruleFile, data, def.Coberturas), data, null, tokenInfo).Result;
            }
            if (result == null)
            {
                result = string.Empty;
            }
            return result;
        }
        internal static string BuildCoveragesCode(string ruleFile, object data, List<Cobertura> Coberturas)
        {
            string basePath = ConfigurationManager.AppSettings["Product.Definition.Path"];
            Architect.Decision.Vocabulary.Condition _rule = new Architect.Decision.Vocabulary.Condition(
                $"{basePath}\\syntax.settings.json",
                $"{basePath}\\convention.settings.json",
                $"{basePath}\\{ruleFile}.vocabulary.json");
            StringBuilder script = new StringBuilder();
            script.AppendFormat("{0} data = ({0})Data;\n", data.GetType().FullName);
            script.Append("string exclude = string.Empty;\n");

            foreach (Architect.API.Tron.Contracts.Especificacion.Cobertura coverage in Coberturas)
            {
                script.AppendFormat("if({0}){{exclude=\"{1}\";}}\n", _rule.Parser(coverage.Condicion), coverage.Exclusion);
            }
            return script.ToString();
        }
        public static List<Architect.API.Core.Contracts.General.Error> Apply_Reglas(string ruleFile, object data, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Especificacion.Producto def = Utilities.SerializeHandler<Contracts.Especificacion.Producto>.DeserializeJSONFromFile(string.Format(@"{0}\{1}.rules.json", ConfigurationManager.AppSettings["Product.Definition.Path"], ruleFile));
            List<Architect.API.Core.Contracts.General.Error> errors = null;
            if (def.Reglas?.Count > 0)
            {
                errors = Architect.API.Core.Business.General.Rule.ApplyRules(ruleFile, BuildRulesCode(ruleFile, data, def.Reglas), data, tokenInfo).Result;
            }
            if (errors == null)
            {
                errors = new List<Core.Contracts.General.Error>();
            }
            return errors;
        }

        internal static string BuildRulesCode(string ruleFile, object data, List<Regla> rules)
        {
            string basePath = ConfigurationManager.AppSettings["Product.Definition.Path"];
            Architect.Decision.Vocabulary.Condition _rule = new Architect.Decision.Vocabulary.Condition(
                $"{basePath}\\syntax.settings.json", 
                $"{basePath}\\convention.settings.json", 
                $"{basePath}\\{ruleFile}.vocabulary.json");

            StringBuilder script = new StringBuilder();

            script.AppendFormat("{0} data = ({0})Data;\n", data.GetType().FullName);
            script.Append("List<Architect.API.Core.Contracts.General.Error> errors = new List<Architect.API.Core.Contracts.General.Error>();\n");

            foreach (Architect.API.Tron.Contracts.Especificacion.Regla rule in rules)
            {
                if (rule.Grupo.IsEmpty())
                {
                    rule.Grupo = ruleFile;
                }
                script.AppendFormat("if ({0}){{errors.Add(new Architect.API.Core.Contracts.General.Error() {{ Group = \"{1}\", Key = \"{2}\", Message = \"{3}\" }});}}\n", _rule.Parser(rule.Condicion), rule.Grupo, rule.Campo, rule.Mensaje);
            }
            return script.ToString();
        }

        public static List<Contracts.Comun.DocumentoRequerido> Apply_DocumentosRequeridos(string ruleFile, List<Contracts.Comun.DocumentoRequerido> documentos, int mca_cero_km, Core.Contracts.Security.Token tokenInfo)
        {
            bool allowAdd = false;
            Contracts.Comun.DocumentoRequerido newdocumento;
            Contracts.Especificacion.Producto rules = Utilities.SerializeHandler<Contracts.Especificacion.Producto>.DeserializeJSONFromFile(string.Format(@"{0}\{1}.rules.json", ConfigurationManager.AppSettings["Product.Definition.Path"], ruleFile));

            if (documentos.IsEmpty())
            {
                documentos = new List<Contracts.Comun.DocumentoRequerido>();
            }

            foreach (Contracts.Especificacion.DocumentCondicion requerido in rules.DocumentosRequeridos)
            {
                if (tokenInfo.Roles.Contain(requerido.Role))
                {
                    allowAdd = requerido.Condicion.IsEmpty();
                    if (requerido.Condicion.IsNotEmpty())
                    {
                        if (requerido.Condicion.StartsWith("MCA_CERO_KM=", StringComparison.CurrentCultureIgnoreCase))
                        {
                            allowAdd = requerido.Condicion.Substring(12).Equals(mca_cero_km.ToString(), StringComparison.CurrentCultureIgnoreCase);
                        }
                    }
                    if (allowAdd)
                    {
                        documentos = NewMethod(documentos, requerido);
                    }
                }
            }

            if (documentos.Count == 0)
            {
                Contracts.Especificacion.DocumentCondicion requerido = rules.DocumentosRequeridos.Find(x => x.Role == "_default_asegurado_fisico");
                if (requerido.IsNotEmpty())
                {
                    documentos = NewMethod(documentos, requerido);
                }
            }
            return documentos;
        }

        private static List<Contracts.Comun.DocumentoRequerido> NewMethod(List<Contracts.Comun.DocumentoRequerido> documentos, DocumentCondicion requerido)
        {
            Contracts.Comun.DocumentoRequerido newdocumento;
            foreach (Contracts.Especificacion.Documento documento in requerido.Detalles)
            {
                newdocumento = new Contracts.Comun.DocumentoRequerido()
                {
                    documentosrequeridosId = documentos.Count + 1,
                    tipo = documento.descripcion,
                    DArchivoEsperado = documento.archivo,
                    Grupo = "F"
                };
                documentos.Add(newdocumento);
            }

            return documentos;
        }

        public static List<Contracts.Comun.tercero> Apply_Terceros(string ruleFile, List<Contracts.Comun.tercero> terceros, string fuente_Tomador, Core.Contracts.Security.Token tokenInfo)
        {
            List<Contracts.Comun.tercero> result = Apply_Terceros_int(ruleFile, terceros, fuente_Tomador, tokenInfo);

            if (result?.Count > 0 && terceros?.Count > 0)
            {
                foreach (Contracts.Comun.tercero item in terceros)
                {
                    if (result.Find(x => x.tipodetercero == item.tipodetercero).IsEmpty())
                    {
                        item.tercerosId = result.Count + 1;
                        result.Add(item);
                    }
                }
            }
            else if (terceros?.Count > 0)
            {
                result = terceros;
            }
            return result;
        }

        internal static List<Contracts.Comun.tercero> Apply_Terceros_int(string ruleFile, List<Contracts.Comun.tercero> terceros, string fuente_Tomador, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Especificacion.Producto rules = Utilities.SerializeHandler<Contracts.Especificacion.Producto>.DeserializeJSONFromFile(string.Format(@"{0}\{1}.rules.json", ConfigurationManager.AppSettings["Product.Definition.Path"], ruleFile));
            Contracts.Comun.tercero newTercero;
            bool addTercero = false;
            foreach (Contracts.Especificacion.TerceroCondicion condition in rules.Terceros)
            {
                if (tokenInfo.Roles.Contain(condition.Role))
                {
                    addTercero = condition.Condicion.IsEmpty();
                    if (condition.Condicion.IsNotEmpty())
                    {
                        if (condition.Condicion.StartsWith("Fuente_Tomador=", StringComparison.CurrentCultureIgnoreCase))
                        {
                            addTercero = condition.Condicion.Substring(15).Equals(fuente_Tomador, StringComparison.CurrentCultureIgnoreCase);
                        }
                    }
                    if (addTercero)
                    {
                        foreach (Contracts.Especificacion.Tercero detail in condition.Detalles)
                        {
                            if (terceros.IsEmpty())
                            {
                                terceros = new List<Contracts.Comun.tercero>();
                            }
                            newTercero = new Contracts.Comun.tercero()
                            {
                                tercerosId = terceros.Count + 1,
                                tipodetercero = Convert.ToInt32(detail.tip_benef),
                                tipodeterceroDesc = string.Empty,
                                DocumentNumberType = Util.IdentificationTypeConvert(detail.tip_docum),
                                DocumentNumber = detail.cod_docum,
                                nombre = detail.nom_tercero,
                                apellido1 = null,
                                apellido2 = null,
                                fechadenacimiento = DateTime.MinValue,
                                tercerosMca_sexo = 0,
                                tercerosMca_sexoDesc = string.Empty,
                                estadoCivil = string.Empty,
                                estadoCivilDesc = string.Empty,
                                numerodetelefono = string.Empty,
                                correoelectronico = detail.email,
                                cod_pais = detail.cod_pais,
                                TProvincia = detail.cod_estado,
                                TProvinciaDesc = string.Empty,
                                TCanton = detail.cod_prov,
                                TCantonDesc = string.Empty,
                                TDistrito = detail.cod_localidad,
                                TDistritoDesc = string.Empty,
                                otrasenas = detail.nom_domicilio1,
                                eltomadoreselmismoasegurado = 2,
                                elaseguradoeselconductorhabitual = 0,
                                numerodeprestamo = null,
                                importedecesion = 0,
                                vencimientodecesion = DateTime.MinValue,
                                porcentajeacredor = 0,
                                parentesco = 0,
                                porcentaje = 0,
                                NoEditable = true
                            };
                            terceros.Add(newTercero);

                            newTercero.tipodeterceroDesc = tip_benef_lookup(newTercero.tipodetercero);

                            List<string> keys = new List<string> { "Provincias", "Cantones", "Distritos" };

                            string url = $"cod_pais=CRI:cod_estado={newTercero.TProvincia}:cod_prov={newTercero.TCanton}";
                            List<Core.Contracts.General.LookupValues> values = Core.Business.Common.Lkps(string.Join(",", keys), url, tokenInfo);

                            newTercero.TProvinciaDesc = values.Find(x => x.Key == "Provincias").Lkp.Find(y => y.Code == newTercero.TProvincia.ToString()).Description;
                            newTercero.TCantonDesc = values.Find(x => x.Key == "Cantones").Lkp.Find(y => y.Code == newTercero.TCanton.ToString()).Description;
                            newTercero.TDistritoDesc = values.Find(x => x.Key == "Distritos").Lkp.Find(y => y.Code == newTercero.TDistrito.ToString()).Description;
                        }
                    }

                }
            }
            return terceros;
        }

        private static string tip_benef_lookup(int tip_benef)
        {
            string type = string.Empty;

            switch (tip_benef)
            {
                case 0:
                    type = "Tomador(a)";
                    break;
                case 2:
                    type = "Asegurado(a)";
                    break;
                case 3:
                    type = "Conductor habitual";
                    break;
                case 6:
                    type = "Beneficiario(a)";
                    break;
                case 8:
                    type = "Acredor(a)";
                    break;
            }

            return type;
        }

        //internal static string ConditionParser(string ruleFile, string condition)
        //{
        //    string code = condition;

        //    code = code.Replace("{el ", "{");
        //    code = code.Replace("{El ", "{");
        //    code = code.Replace("{La ", "{");
        //    code = code.Replace("{la ", "{");
        //    code = code.Replace(" sea ", " es ");
        //    code = code.Replace(" Sea ", " es ");
        //    code = code.Replace("{No tiene", "{No hay");
        //    code = code.Replace("{no tiene", "{No hay");

        //    MatchCollection parameterMatches = Regex.Matches(code, @"{(.+?)}"); // ([^)]*)

        //    foreach (Match paremeter in parameterMatches)
        //    {
        //        switch (paremeter.Value.ToLower())
        //        {
        //            case "{moneda}":
        //                code = code.Replace(paremeter.Value, "data.cod_mon");
        //                break;
        //            case "{valor del vehículo}":
        //            case "{valor del vehiculo}":
        //                code = code.Replace(paremeter.Value, "data.IMP_VR");
        //                break;
        //            case "{marca del vehículo}":
        //            case "{marca del vehiculo}":
        //                code = code.Replace(paremeter.Value, "data.cod_marca");
        //                break;
        //            case "{año del vehículo}":
        //            case "{año del vehiculo}":
        //            case "{año de fabricación}":
        //            case "{año de fabricacion}":
        //                code = code.Replace(paremeter.Value, "data.ANIO_SUB_MODELO");
        //                break;
        //            case "{contrato}":
        //                code = code.Replace(paremeter.Value, "data.contrato");
        //                break;
        //            case "{suma asegurada de colisión y vuelco}":
        //            case "{suma asegurada de colision y vuelco}":
        //                code = code.Replace(paremeter.Value, "data.IMP_AUTO_CYV");
        //                break;
        //            case "{suma asegurada de gastos médicos}":
        //            case "{suma asegurada de gastos medicos}":
        //                code = code.Replace(paremeter.Value, "data.IMP_AUTO_CYV");
        //                break;
        //            case "{suma asegurada de riesgos adicionales}":
        //                code = code.Replace(paremeter.Value, "data.IMP_AUTO_RAD");
        //                break;
        //            case "{suma asegurada de robo}":
        //                code = code.Replace(paremeter.Value, "data.IMP_AUTO_ROB");
        //                break;
        //            case "{plan}":
        //                code = code.Replace(paremeter.Value, "data.COD_PLAN_AUTO");
        //                break;
        //            case "{tipo de producto}":
        //                code = code.Replace(paremeter.Value, "data.tipo_prod");
        //                break;
        //        }
        //    }
        //    code = code.Replace(" y ", " && ");
        //    code = code.Replace(" Y ", " && ");
        //    code = code.Replace(" o ", " || ");
        //    code = code.Replace(" O ", " || ");
        //    code = code.Replace("No sea {", "!{");
        //    code = code.Replace("no sea {", "!{");
        //    code = code.Replace("es menor a ", " < ");
        //    code = code.Replace("es mayor a ", " > ");

        //    Match oldParemeter = null;
        //    foreach (Match paremeter in parameterMatches)
        //    {
        //        switch (paremeter.Value.ToLower())
        //        {
        //            case "{básico}":
        //            case "{basico}":
        //                code = code.Replace(paremeter.Value, "31");
        //                break;
        //            case "{amplio}":
        //                code = code.Replace(paremeter.Value, "32");
        //                break;
        //            case "{plus}":
        //                code = code.Replace(paremeter.Value, "33");
        //                break;
        //            case "{oro}":
        //                code = code.Replace(paremeter.Value, "34");
        //                break;
        //            case "{plata}":
        //                code = code.Replace(paremeter.Value, "35");
        //                break;
        //            case "{trébol}":
        //            case "{trebol}":
        //                code = code.Replace(paremeter.Value, "36");
        //                break;
        //            case "{trébol rc}":
        //            case "{trebol rc}":
        //                if (oldParemeter?.Value.ToLower() == "{tipo de producto}")
        //                    code = code.Replace(paremeter.Value, "\"trebolrc\"");
        //                else
        //                    code = code.Replace(paremeter.Value, "37");
        //                break;

        //            case "{colones}":
        //            case "{colon}":
        //                code = code.Replace(paremeter.Value, "1");
        //                break;
        //            case "{dolares}":
        //            case "{dolar}":
        //            case "{dólares}":
        //            case "{dólar}":
        //                code = code.Replace(paremeter.Value, "2");
        //                break;
        //            case "{no hay coberturas seleccionadas}":
        //                code = code.Replace(paremeter.Value, "!data.coberturas.Any(r => r.seleccionado)");
        //                break;
        //            case "{hay coberturas seleccionadas}":
        //                code = code.Replace(paremeter.Value, "data.coberturas.Any(r => r.seleccionado)");
        //                break;

        //            default:
        //                if (paremeter.Value.ToLower().StartsWith("{cobertura ") && paremeter.Value.ToLower().EndsWith(" es seleccionada}"))
        //                {
        //                    code = code.Replace(paremeter.Value, string.Format("data.coberturas.Any(r => r.codigo == {0} && r.seleccionado)", paremeter.Value.Substring(11, paremeter.Value.Length - 28).Trim()));
        //                }
        //                if (paremeter.Value.ToLower().StartsWith("{rol es igual a "))
        //                {
        //                    code = code.Replace(paremeter.Value, string.Format("token.Roles.Contain(\"{0}\")", paremeter.Value.Substring(16, paremeter.Value.Length - 17)));
        //                }
        //                if (paremeter.Value.ToLower().StartsWith("{rol del usuario es igual a "))
        //                {
        //                    code = code.Replace(paremeter.Value, string.Format("token.Roles.Contain(\"{0}\")", paremeter.Value.Substring(28, paremeter.Value.Length - 29)));
        //                }
        //                if (paremeter.Value.ToLower().StartsWith("{rol no es igual a "))
        //                {
        //                    code = code.Replace(paremeter.Value, string.Format("!token.Roles.Contain(\"{0}\")", paremeter.Value.Substring(19, paremeter.Value.Length - 20)));
        //                }
        //                if (paremeter.Value.ToLower().StartsWith("{rol del usuario no es igual a "))
        //                {
        //                    code = code.Replace(paremeter.Value, string.Format("!token.Roles.Contain(\"{0}\")", paremeter.Value.Substring(31, paremeter.Value.Length - 32)));
        //                }
        //                if (paremeter.Value.ToLower().EndsWith(" año de antigüedad}") || paremeter.Value.ToLower().EndsWith(" año de antiguedad}"))
        //                {
        //                    code = code.Replace(paremeter.Value, string.Format("(DateTime.Today.Year - {0})", paremeter.Value.Substring(1, paremeter.Value.Length - 20)));
        //                }
        //                if (paremeter.Value.ToLower().EndsWith(" años de antigüedad}") || paremeter.Value.ToLower().EndsWith(" años de antiguedad}"))
        //                {
        //                    code = code.Replace(paremeter.Value, string.Format("(DateTime.Today.Year - {0})", paremeter.Value.Substring(1, paremeter.Value.Length - 21)));
        //                }
        //                break;
        //        }
        //        oldParemeter = paremeter;
        //    }
        //    code = code.Replace(" no es igual a ", " != ");
        //    code = code.Replace(" es diferente a ", " != ");
        //    code = code.Replace(" es igual a ", " == ");
        //    code = code.Replace(" es menor que ", " < ");
        //    code = code.Replace(" es menor o igual que ", " <= ");
        //    code = code.Replace(" es mayor que ", " > ");
        //    code = code.Replace(" es mayor o igual que ", " >= ");

        //    code = code.Replace(" no igual a ", " != ");
        //    code = code.Replace(" diferente a ", " != ");
        //    code = code.Replace(" igual a ", " == ");
        //    code = code.Replace(" menor que ", " < ");
        //    code = code.Replace(" menor o igual que ", " <= ");
        //    code = code.Replace(" mayor que ", " > ");
        //    code = code.Replace(" mayor o igual que ", " >= ");
        //    return code;
        //}

    }

}
