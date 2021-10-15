using Architect.API.Tron.Contracts.Emision;
using Architect.API.Tron.Contracts.Especificacion;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Reglas
{

    public static class research
    {

        public static List<Contracts.Comun.DocumentoRequerido> Apply_DocumentosRequeridos(string ruleFile, List<Contracts.Comun.DocumentoRequerido> documentos, int mca_cero_km, Core.Contracts.Security.Token tokenInfo)
        {
            bool allowAdd = false;
            Contracts.Comun.DocumentoRequerido newdocumento;
            Contracts.Especificacion.Producto rules = Utilities.SerializeHandler<Contracts.Especificacion.Producto>.DeserializeJSONFromFile(string.Format(@"{0}\{1}.json", ConfigurationManager.AppSettings["Product.Definition.Path"], ruleFile));

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

            if(documentos.Count == 0 )
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

        internal static List<Contracts.Comun.tercero> Apply_Terceros_int(string ruleFile,  List<Contracts.Comun.tercero> terceros, string fuente_Tomador, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Especificacion.Producto rules = Utilities.SerializeHandler<Contracts.Especificacion.Producto>.DeserializeJSONFromFile(string.Format(@"{0}\{1}.json", ConfigurationManager.AppSettings["Product.Definition.Path"], ruleFile));
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

        public static void MapfreMasBuild()
        {
            Architect.API.Tron.Contracts.Especificacion.Producto producto = new Contracts.Especificacion.Producto();

            producto.Terceros = new List<Contracts.Especificacion.TerceroCondicion>();

            producto = Davivienda_Prendarios(producto);
            producto = Davivienda_Leasing(producto);

            producto = Purdy_CAFSA(producto);
            producto = Purdy_PURDY(producto);
            producto = Purdy_SCOTIABANK(producto);

            producto.DocumentosRequeridos = new List<Contracts.Especificacion.DocumentCondicion>();
            producto = DocumentosRequeridos_Default_F(producto);
            producto = DocumentosRequeridos_Default_J(producto);
            producto = DocumentosRequeridos_Davivienda_Prendarios(producto);
            producto = DocumentosRequeridos_Purdy(producto);


            Utilities.SerializeHandler<Architect.API.Tron.Contracts.Especificacion.Producto>.SerializeToFile(producto,
                ConfigurationManager.AppSettings["Path.Logs"] + @"\producto.xml", true);

            //Utilities.SerializeHandler<Architect.API.Tron.Contracts.Especificacion.Producto>.SerializeJSONToFile(producto, 
            //    ConfigurationManager.AppSettings["Path.Logs"] + @"\producto.json", true, false, false);
            //string xx = Newtonsoft.Json.JsonConvert.SerializeObject(producto);
        }

        private static Architect.API.Tron.Contracts.Especificacion.Producto DocumentosRequeridos_Purdy(Architect.API.Tron.Contracts.Especificacion.Producto producto)
        {
            Contracts.Especificacion.DocumentCondicion doc = new Contracts.Especificacion.DocumentCondicion()
            {
                Role = "Purdy",
            };
            doc.Detalles = new List<Contracts.Especificacion.Documento>();

            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Formulario de inspección",
                archivo = "inspección.pdf",
                requerido = true
            });
            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Fotos o facturas",
                archivo = "fotos.pdf,facturas.pdf",
                requerido = true
            });
            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Solicitud de inscripción",
                archivo = "inscripción.pdf",
                requerido = true
            });

            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Fatura proforma",
                archivo = "proforma.pdf",
                requerido = true
            });
            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Solicitud de seguro firmada",
                archivo = "SolicitudFirmada.pdf",
                requerido = true
            });

            producto.DocumentosRequeridos.Add(doc);
            return producto;
        }

        private static Architect.API.Tron.Contracts.Especificacion.Producto DocumentosRequeridos_Default_F(Architect.API.Tron.Contracts.Especificacion.Producto producto)
        {
            Contracts.Especificacion.DocumentCondicion doc = new Contracts.Especificacion.DocumentCondicion()
            {
                Role = "default",
                Condicion = "F"
            };
            doc.Detalles = new List<Contracts.Especificacion.Documento>();

            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Copia de la cédula de identidad",
                archivo = "CEDULA.docx",
                requerido = true
            });
            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Comprobante de entrega de condiciones generales",
                archivo = "CONDICIONES.pdf",
                requerido = true
            });
            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Consentimiento para uso de datos personales",
                archivo = "CONSENTIMIENTO.pdf",
                requerido = true
            });

            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Formato de validación de domicilio",
                archivo = "DOMICILIO.pdf",
                requerido = true
            });
            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Conozca a su cliente (KYC)",
                archivo = "KYC.pdf",
                requerido = true
            });
            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Solicitud de seguro firmada",
                archivo = "SOLICITUD.pdf",
                requerido = true
            });
            producto.DocumentosRequeridos.Add(doc);
            return producto;
        }

        private static Architect.API.Tron.Contracts.Especificacion.Producto DocumentosRequeridos_Default_J(Architect.API.Tron.Contracts.Especificacion.Producto producto)
        {
            Contracts.Especificacion.DocumentCondicion doc = new Contracts.Especificacion.DocumentCondicion()
            {
                Role = "default",
                Condicion = "J"
            };
            doc.Detalles = new List<Contracts.Especificacion.Documento>();

            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Represéntate legal",
                archivo = "REPRESENTANTE LEGAL.docx",
                requerido = true
            });
            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Participación accionaria",
                archivo = "PARTICIPACION ACCIONARIA.docx",
                requerido = true
            });
            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Certificado de participación",
                archivo = "CERTIFICADO PARTICIPACION.docx",
                requerido = true
            });
            producto.DocumentosRequeridos.Add(doc);
            return producto;
        }

        private static Architect.API.Tron.Contracts.Especificacion.Producto DocumentosRequeridos_Davivienda_Prendarios(Architect.API.Tron.Contracts.Especificacion.Producto producto)
        {
            Contracts.Especificacion.DocumentCondicion doc = new Contracts.Especificacion.DocumentCondicion()
            {
                Role = "Davivienda_Prendarios"
            };
            doc.Detalles = new List<Contracts.Especificacion.Documento>();

            doc.Detalles.Add(new Contracts.Especificacion.Documento()
            {
                descripcion = "Documentación digitalizada",
                archivo = "Documentos.docx",
                requerido = true
            });
            producto.DocumentosRequeridos.Add(doc);
            return producto;
        }

        private static Architect.API.Tron.Contracts.Especificacion.Producto Davivienda_Prendarios(Architect.API.Tron.Contracts.Especificacion.Producto producto)
        {

            Contracts.Especificacion.TerceroCondicion Davivienda_PrendariosTercero =
                new Contracts.Especificacion.TerceroCondicion()
                {
                    Role = "Davivienda_Prendarios"
                };

            Davivienda_PrendariosTercero.Detalles = new List<Contracts.Especificacion.Tercero>() { };
            Contracts.Especificacion.Tercero titular = new Contracts.Especificacion.Tercero()
            {
                tip_benef = "0",
                tip_docum = "CJU",
                cod_docum = "3101046008",
                nom_tercero = "BANCO DAVIVIENDA (COSTA RICA) SOCIEDAD ANONIMA",
                email = "IRIAKNA.HERNANDEZ@DAVIVIENDA.CR",
                cod_pais = "CRI",
                cod_estado = 1,
                cod_prov = 101,
                cod_localidad = 10101,
                nom_domicilio1 = "SAN JOSE"
            };

            Davivienda_PrendariosTercero.Detalles.Add(titular);

            producto.Terceros.Add(Davivienda_PrendariosTercero);
            return producto;
        }

        private static Architect.API.Tron.Contracts.Especificacion.Producto Davivienda_Leasing(Architect.API.Tron.Contracts.Especificacion.Producto producto)
        {

            Contracts.Especificacion.TerceroCondicion Davivienda_PrendariosTercero =
                new Contracts.Especificacion.TerceroCondicion()
                {
                    Role = "Davivienda_Leasing"
                };

            Davivienda_PrendariosTercero.Detalles = new List<Contracts.Especificacion.Tercero>() { };
            Contracts.Especificacion.Tercero titular = new Contracts.Especificacion.Tercero()
            {
                tip_benef = "0",
                tip_docum = "CJU",
                cod_docum = "3101692430",
                nom_tercero = "DAVIVIENDA LEASING (COSTA RICA) S.A.",
                email = "LEASING_SEGUROS@DAVIVIENDA.CR",
                cod_pais = "CRI",
                cod_estado = 1,
                cod_prov = 102,
                cod_localidad = 10203,
                nom_domicilio1 = "125 SUR MULTIPLAZA ESCAZÚ, EDIFICIO MERIDIANO, PISO 9",
                tlf_numero = "2588-9477"
            };
            Davivienda_PrendariosTercero.Detalles.Add(titular);

            Contracts.Especificacion.Tercero asegurado = new Contracts.Especificacion.Tercero()
            {
                tip_benef = "2",
                tip_docum = "CJU",
                cod_docum = "3101692430",
                nom_tercero = "DAVIVIENDA LEASING (COSTA RICA) S.A.",
                email = "LEASING_SEGUROS@DAVIVIENDA.CR",
                cod_pais = "CRI",
                cod_estado = 1,
                cod_prov = 102,
                cod_localidad = 10203,
                nom_domicilio1 = "125 SUR MULTIPLAZA ESCAZÚ, EDIFICIO MERIDIANO, PISO 9",
                tlf_numero = "2588-9477"
            };
            Davivienda_PrendariosTercero.Detalles.Add(asegurado);

            producto.Terceros.Add(Davivienda_PrendariosTercero);
            return producto;
        }

        private static Architect.API.Tron.Contracts.Especificacion.Producto Purdy_CAFSA(Architect.API.Tron.Contracts.Especificacion.Producto producto)
        {

            Contracts.Especificacion.TerceroCondicion Davivienda_PrendariosTercero =
                new Contracts.Especificacion.TerceroCondicion()
                {
                    Role = "Purdy",
                    Condicion = "CAFSA"
                };

            Davivienda_PrendariosTercero.Detalles = new List<Contracts.Especificacion.Tercero>() { };
            Contracts.Especificacion.Tercero titular = new Contracts.Especificacion.Tercero()
            {
                tip_benef = "0",
                tip_docum = "CJU",
                cod_docum = "3101052431",
                nom_tercero = "FINANCIERA CAFSA",
                email = "INFO@CAFSA.FI.CR",
                cod_pais = "CRI",
                cod_estado = 1,
                cod_prov = 101,
                cod_localidad = 10102,
                nom_domicilio1 = "DETRAS DE PURDY MOTOR EN PASEO COLON",
                tlf_numero = "2884-1000"
            };

            Davivienda_PrendariosTercero.Detalles.Add(titular);

            producto.Terceros.Add(Davivienda_PrendariosTercero);
            return producto;
        }

        private static Architect.API.Tron.Contracts.Especificacion.Producto Purdy_PURDY(Architect.API.Tron.Contracts.Especificacion.Producto producto)
        {

            Contracts.Especificacion.TerceroCondicion Davivienda_PrendariosTercero =
                new Contracts.Especificacion.TerceroCondicion()
                {
                    Role = "Purdy",
                    Condicion = "PURDY"
                };

            Davivienda_PrendariosTercero.Detalles = new List<Contracts.Especificacion.Tercero>() { };
            Contracts.Especificacion.Tercero titular = new Contracts.Especificacion.Tercero()
            {
                tip_benef = "0",
                tip_docum = "CJU",
                cod_docum = "3101005744",
                nom_tercero = "PURDY MOTOR SOCIEDAD ANONIMA",
                cod_pais = "CRI",
                cod_estado = 1,
                cod_prov = 101,
                cod_localidad = 10102,
                nom_domicilio1 = "EDIFICIO PURDY MOTOR PASEO COLON"
            };

            Davivienda_PrendariosTercero.Detalles.Add(titular);

            producto.Terceros.Add(Davivienda_PrendariosTercero);
            return producto;
        }

        private static Architect.API.Tron.Contracts.Especificacion.Producto Purdy_SCOTIABANK(Architect.API.Tron.Contracts.Especificacion.Producto producto)
        {

            Contracts.Especificacion.TerceroCondicion Davivienda_PrendariosTercero =
                new Contracts.Especificacion.TerceroCondicion()
                {
                    Role = "Purdy",
                    Condicion = "SCOTIABANK"
                };

            Davivienda_PrendariosTercero.Detalles = new List<Contracts.Especificacion.Tercero>() { };
            Contracts.Especificacion.Tercero titular = new Contracts.Especificacion.Tercero()
            {
                tip_benef = "0",
                tip_docum = "CJU",
                cod_docum = "3101046536",
                nom_tercero = "SCOTIABANK DE COSTA RICA SOCIEDAD ANONIMA",
                email = "Marianela.arias@scotiabank.com",
                cod_pais = "CRI",
                cod_estado = 1,
                cod_prov = 101,
                cod_localidad = 10108,
                nom_domicilio1 = "FINAL AVENIDA LAS AMERICAS, COSTADO N ESTADIO NACIONAL",
                tlf_numero = "2210-4000"
            };

            Davivienda_PrendariosTercero.Detalles.Add(titular);

            producto.Terceros.Add(Davivienda_PrendariosTercero);
            return producto;
        }

    }
}
