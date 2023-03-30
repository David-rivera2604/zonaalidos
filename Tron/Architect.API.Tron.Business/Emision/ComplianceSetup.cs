using Architect.Compliance.Integrations.Contracts;
using Architect.Utilities.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Tron.Business.Emision
{
    internal class ComplianceSetup
    {
        internal static void Send(Contracts.Emision.MapfreMas quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            JObject jsonvalues = null;
            Architect.Compliance.Integrations.Contracts.Clientes mapInfo;
            Contracts.Comun.tercero titular = (from t in quoteInfo.terceros where t.tipodetercero == 0 select t).FirstOrDefault();

            if (quoteInfo.kyc != null)
            {
                jsonvalues = (JObject)quoteInfo.kyc;
            }

            if (titular.DocumentNumberType == 4)
            {
                mapInfo = Juridico(quoteInfo, jsonvalues);
            }
            else
            {
                mapInfo = Persona(quoteInfo, jsonvalues);
            }
            mapInfo.ejecutivo = tokenInfo.AgentCode.ToString();
            mapInfo.usuarioRegistro = tokenInfo.UserId.ToString();
            mapInfo.usuario = tokenInfo.UserId;
            mapInfo.clientesFATCA = new List<Clientesfatca>() {
                new Clientesfatca() {
                    poseeGreenCard= "N",
                    poseeEIN= "N",
                    poseeProductos= "N",
                    contribuyenteUSA= "N",
                    domicilioExtranjero= "N",
                    poseeTelefonoExtranjero= "N"
                }
            };
            //if (quoteInfo.terceros?.Count > 0 && quoteInfo.terceros.Where(r=> r.tipodetercero== 6) != null)
            //{
            //}

            mapInfo.clientesPatrimonio = new List<Clientespatrimonio>() {
                new Clientespatrimonio()
                {
                     descripcionPatrimonio = string.Format("{0} {1} {2} {3}", quoteInfo.cod_marcaDesc, quoteInfo.cod_modeloDesc, quoteInfo.cod_sub_modeloDesc, quoteInfo.NUM_MATRICULA ),
                     moneda = quoteInfo.cod_mon,
                     montoValor = quoteInfo.IMP_VR,
                     tipoBien = 1,
                     fechaRegistro = DateTime.Now
                }
            };

            string result = Architect.Compliance.Integrations.Business.Customers.SendCustomers(mapInfo).Result;
        }

        private static Compliance.Integrations.Contracts.Clientes Persona(Contracts.Emision.MapfreMas quoteInfo, JObject jsonvalues)
        {

            Architect.Compliance.Integrations.Contracts.Clientes mapInfo = new Compliance.Integrations.Contracts.Clientes()
            {
                tipoIdentificacion = 1,
                numeroIdentificacion = jsonvalues.TokenStringValue("numerodeidentificacionPer"),
                nombreCliente = jsonvalues.TokenStringValue("nombrePer"),
                primerApellido = jsonvalues.TokenStringValue("primerapellidoPer"),
                segundoApellido = jsonvalues.TokenStringValue("segundoapellidoPer"),
                conocidoComo = String.Empty,
                razonSocial = String.Empty,
                nombreComercial = String.Empty,
                fechaUltimaActualizacion = DateTime.Now,
                descripcionCuenta = jsonvalues.TokenStringValue("nombrePer").CompleteFullName(jsonvalues.TokenStringValue("primerapellidoPer"), jsonvalues.TokenStringValue("segundoapellidoPer")),
                numeroIdentificacionEntidad = jsonvalues.TokenStringValue("numerodeidentificacionPer"),
                fechaNacimiento = jsonvalues.TokenDateTimeValue("fechadenacimientoPer"),
                estado = "A",
                estadoXML = "X",
                administFondosTercero = "N",
                esApnfd = "N",
                tipoApnfd = "0",
                esCpe = "N",
                pagaImpuestos = "N",
                //faltaban
                esPep = "N",
                tipoPep = "N",
                residente = "S",
                articulo15 = "N",
                esEmpleado = "N",
                fechaValor = DateTime.Now,
                tipoCuenta = "1",
                fechaSalida = new DateTime(1900, 1, 1),
                fechaIngreso = DateTime.Now,
                fechaRegistro = DateTime.Now,
                sectorPublico = "N",
                fechaInactividad = new DateTime(1900, 1, 1),
                fechaVinculacion = DateTime.Now,
                fechaCargaCliente = DateTime.Now,
                institucionLabora = "0",
                fechaRegistroApnfd = new DateTime(1900, 1, 1),
                lugarExpedicionIdentificacion = "Costa Rica",
                fechaVencimientoIdentificacion = jsonvalues.TokenDateTimeValue("fechadecaducidadPer"),
                fechaProximaActualizacion = new DateTime(1900, 1, 1),
                descripcionInversionInicial = String.Empty
            };


            //KYC
            //administFondosTercero
            //
            //montoIngresoMensual
            //esPep
            //tipoPep
            //articulo15
            //origenFondos
            //paisOrigen = "111111"
            //profesion
            mapInfo.clientesUbicaciones = new List<Compliance.Integrations.Contracts.Clientesubicacione>();
            if (jsonvalues.TokenStringValue("telefonoresidenciaPer").IsNotEmpty())
            {
                mapInfo.clientesUbicaciones.Add(new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 1,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = jsonvalues.TokenStringValue("telefonoresidenciaPer")
                });
            }
            if (jsonvalues.TokenStringValue("correoelectronicoPer").IsNotEmpty())
            {
                mapInfo.clientesUbicaciones.Add(new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 3,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = jsonvalues.TokenStringValue("correoelectronicoPer")
                });
            }
            if (jsonvalues.TokenStringValue("direccionexactaPer").IsNotEmpty())
            {
                mapInfo.clientesUbicaciones.Add(new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 4,
                    divisionTerritorial = jsonvalues.TokenInt32Value("cod_localidadPer"),
                    descripcionUbicacion = String.Format("{0}, {1}, {2}, {3}. {4}.", jsonvalues.TokenStringValue("cod_estadoPerDesc"), jsonvalues.TokenStringValue("cod_provPerDesc"), jsonvalues.TokenStringValue("cod_localidadPerDesc"), jsonvalues.TokenStringValue("direccionexactaPer"), jsonvalues.TokenStringValue("cod_paisPerDesc"))
                });
            }

            mapInfo.genero = jsonvalues.TokenInt32Value("sexoPer") == 1 ? "M" : "F";
            mapInfo.estadoCivil = jsonvalues.TokenStringValue("estadocivilPer");


            mapInfo.profesion = jsonvalues.TokenInt32Value("profesionPer");
            mapInfo.paisOrigen = jsonvalues.TokenInt32Value("paisdenacimientoPer");
            mapInfo.actividadEconomica = 8397;
            mapInfo.clientesNacionalidades = new[] { new Clientesnacionalidade() { nacionalidad = jsonvalues.TokenInt32Value("nacionalidadPer") } };
            string telefonocelularPer = jsonvalues.TokenStringValue("telefonocelularPer");
            if (telefonocelularPer.IsNotEmpty())
            {
                mapInfo.clientesUbicaciones.Add(new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 2,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = telefonocelularPer
                });
            }
            mapInfo.articulo15 = jsonvalues.TokenStringValue("actividadesart15Per") == "1" ? "S" : "N";
            if (jsonvalues.TokenStringValue("peprelacionPer") == "1")
            {
                mapInfo.esPep = "S";
                mapInfo.tipoPep = "R";
            }
            if (jsonvalues.TokenStringValue("pepcargoPer") == "1")
            {
                mapInfo.esPep = "S";
                mapInfo.tipoPep = "D";
            }



            mapInfo.clientesPolizas = new List<Compliance.Integrations.Contracts.Clientespoliza>()
            {
                new Compliance.Integrations.Contracts.Clientespoliza()
                {
                    numeroPoliza = quoteInfo.num_poliza,
                    descripcionPoliza = "MapfreMas",
                    fechaInicio = quoteInfo.fec_efec_poliza,
                    fechaFinalizacion = quoteInfo.fec_vcto_poliza,
                    moneda  = quoteInfo.cod_mon,
                    prima = jsonvalues.TokenDoubleValue("montoprimaPer"),
                    estado="A",
                    //faltaban
                    tipoPrima = "A",
                    tipoPoliza= "C",
                    tipoProducto = 302,
                    montoAsegurado =jsonvalues.TokenDoubleValue("montovaloraseguradoPer")
                }
            };
            //if (quoteInfo.DatosEconomicos != null)
            //{
            //    mapInfo.clientesPolizas[0].prima = (int)quoteInfo.DatosEconomicos.annualgrosspremium;
            //}
            switch (jsonvalues.TokenStringValue("formadepagodelapolizaPer"))
            {
                case "1": //Anual
                    mapInfo.clientesPolizas[0].tipoPrima = "A";
                    break;
                case "2": //Semestral
                    mapInfo.clientesPolizas[0].tipoPrima = "S";
                    break;
                case "3": //Trimestral
                    mapInfo.clientesPolizas[0].tipoPrima = "T";
                    break;
                case "4": //Mensual
                    mapInfo.clientesPolizas[0].tipoPrima = "M";
                    break;
            }


            return mapInfo;
        }

        private static Compliance.Integrations.Contracts.Clientes Juridico(Contracts.Emision.MapfreMas quoteInfo, JObject jsonvalues)
        {
            Architect.Compliance.Integrations.Contracts.Clientes mapInfo = new Compliance.Integrations.Contracts.Clientes()
            {
                tipoIdentificacion = 2,
                numeroIdentificacion = jsonvalues.TokenStringValue("numerocedulajuridicaJur"),
                nombreCliente = string.Empty,
                primerApellido = string.Empty,
                segundoApellido = string.Empty,
                conocidoComo = jsonvalues.TokenStringValue("nombrecomercialJur"),
                razonSocial = jsonvalues.TokenStringValue("razonsocialJur"),
                nombreComercial = jsonvalues.TokenStringValue("nombrecomercialJur"),
                fechaUltimaActualizacion = DateTime.Now,
                descripcionCuenta = jsonvalues.TokenStringValue("nombrecomercialJur"),
                numeroIdentificacionEntidad = jsonvalues.TokenStringValue("numerocedulajuridicaJur"),
                fechaNacimiento = jsonvalues.TokenDateTimeValue("fechadeconstitucionJur"),
                estado = "A",
                estadoXML = "X",
                administFondosTercero = "N",
                esApnfd = "N",
                tipoApnfd = "0",
                esCpe = "N",
                pagaImpuestos = "N",
                //faltaban
                esPep = "N",
                tipoPep = "N",
                residente = "S",
                articulo15 = "N",
                esEmpleado = "N",
                fechaValor = DateTime.Now,
                tipoCuenta = "1",
                fechaSalida = new DateTime(1900, 1, 1),
                fechaIngreso = DateTime.Now,
                fechaRegistro = DateTime.Now,
                sectorPublico = "N",
                fechaInactividad = new DateTime(1900, 1, 1),
                fechaVinculacion = DateTime.Now,
                fechaCargaCliente = DateTime.Now,
                institucionLabora = "0",
                fechaRegistroApnfd = new DateTime(1900, 1, 1),
                lugarExpedicionIdentificacion = "Costa Rica",
                fechaVencimientoIdentificacion = new DateTime(1900, 1, 1),
                fechaProximaActualizacion = new DateTime(1900, 1, 1),
                descripcionInversionInicial = String.Empty,
                paisOrigen = jsonvalues.TokenInt32Value("paisdeconstitucionJur"),
                genero = "X",
                estadoCivil = "X",
                actividadEconomica = 8397,
                montoIngresoMensual = jsonvalues.TokenDoubleValue("ingresomensualestimadoJur"),
                inversionInicial = jsonvalues.TokenInt32Value("montovaloraseguradoJur")
            };


            //KYC
            //administFondosTercero
            //
            //montoIngresoMensual
            //esPep
            //tipoPep
            //articulo15
            //origenFondos
            //paisOrigen = "111111"
            //profesion
            mapInfo.clientesUbicaciones = new List<Compliance.Integrations.Contracts.Clientesubicacione>();
            if (jsonvalues.TokenStringValue("telefonoJur").IsNotEmpty())
            {
                mapInfo.clientesUbicaciones.Add(new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 1,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = jsonvalues.TokenStringValue("telefonoJur")
                });
            }
            if (jsonvalues.TokenStringValue("correoelectronicoJur").IsNotEmpty())
            {
                mapInfo.clientesUbicaciones.Add(new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 3,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = jsonvalues.TokenStringValue("correoelectronicoJur")
                });
            }
            if (jsonvalues.TokenStringValue("direccionexactaJur").IsNotEmpty())
            {
                mapInfo.clientesUbicaciones.Add(new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 4,
                    divisionTerritorial = jsonvalues.TokenInt32Value("cod_localidadJur"),
                    descripcionUbicacion = String.Format("{0}, {1}, {2}, {3}. {4}.", jsonvalues.TokenStringValue("cod_estadoJurDesc"), jsonvalues.TokenStringValue("cod_provJurDesc"), jsonvalues.TokenStringValue("cod_localidadJurDesc"), jsonvalues.TokenStringValue("direccionexactaJur"), jsonvalues.TokenStringValue("cod_paisJurDesc"))
                });
            }

            Clientesrepresentante representante = new Clientesrepresentante()
            {

                tipoIdentificacionRepresentante = jsonvalues.TokenInt32Value("tipodeidentificacionJur"),
                numeroIdentificacionRepresentante = jsonvalues.TokenStringValue("numerodeidentificacionJur"),
                fechaVencimiento = jsonvalues.TokenDateTimeValue("fechadecaducidadJur"),
                nombre = jsonvalues.TokenStringValue("nombrecompletoJur"),
                segundoNombre = string.Empty,
                primerApellido = jsonvalues.TokenStringValue("primerapellidoJur"),
                segundoApellido = jsonvalues.TokenStringValue("segundoapellidoJur"),
                conocidoComo = String.Empty,
                genero = jsonvalues.TokenStringValue("sexoJur") == "1" ? "M" : "F",
                fechaNacimiento = jsonvalues.TokenDateTimeValue("fechadenacimientoJur"),
                estadoCivil = jsonvalues.TokenStringValue("estadocivilJur", "X"),
                paisOrigen = jsonvalues.TokenInt32Value("paisdenacimientoJur"),
                profesion = jsonvalues.TokenInt32Value("profesionJur"),
                actividadEconomica = 8397,
                esPep = "N",
                tipoPep = "N",
                descripcionPep = "No aplica",
                articulo15 = jsonvalues.TokenStringValue("actividadesart15Jur") == "1" ? "S" : "N",
                cargo = jsonvalues.TokenStringValue("posiciondentrodelaempresaJur", "No aplica")
            };

            representante.clientesRepresentantesUbicaciones = new List<Clientesrepresentantesubicacione>();

            if (jsonvalues.TokenStringValue("telefonoresidenciaJur").IsNotEmpty())
            {
                representante.clientesRepresentantesUbicaciones.Add(new Clientesrepresentantesubicacione()
                {
                    tipoUbicacion = 1,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = jsonvalues.TokenStringValue("telefonoresidenciaJur")
                });
            }
            if (jsonvalues.TokenStringValue("telefonocelularJur").IsNotEmpty())
            {
                representante.clientesRepresentantesUbicaciones.Add(new Clientesrepresentantesubicacione()
                {
                    tipoUbicacion = 2,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = jsonvalues.TokenStringValue("telefonocelularJur")
                });
            }
            if (jsonvalues.TokenStringValue("datosdelrepresentantelegalCorreoelectronicoJur").IsNotEmpty())
            {
                representante.clientesRepresentantesUbicaciones.Add(new Clientesrepresentantesubicacione()
                {
                    tipoUbicacion = 3,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = jsonvalues.TokenStringValue("datosdelrepresentantelegalCorreoelectronicoJur")
                });
            }
            if (jsonvalues.TokenStringValue("domiciliopermanenteDireccionexactaJur").IsNotEmpty())
            {
                representante.clientesRepresentantesUbicaciones.Add(new Clientesrepresentantesubicacione()
                {
                    tipoUbicacion = 4,
                    divisionTerritorial = jsonvalues.TokenInt32Value("domiciliopermanenteCod_localidadJur"),
                    descripcionUbicacion = String.Format("{0}, {1}, {2}, {3}. {4}.", jsonvalues.TokenStringValue("domiciliopermanenteCod_estadoJurDesc"), jsonvalues.TokenStringValue("domiciliopermanenteCod_provJurDesc"), jsonvalues.TokenStringValue("domiciliopermanenteCod_localidadJurDesc"), jsonvalues.TokenStringValue("domiciliopermanenteDireccionexactaJur"), jsonvalues.TokenStringValue("domiciliopermanenteCod_paisJurDesc"))
                });
            }



            switch (representante.estadoCivil)
            {
                case "1": //casado
                    representante.estadoCivil = "C";
                    break;
                case "2": //divorciado
                    representante.estadoCivil = "D";
                    break;
                case "3": //soltero
                    representante.estadoCivil = "S";
                    break;
                case "4": //viudo
                    representante.estadoCivil = "V";
                    break;
                case "5": //otro
                    representante.estadoCivil = "X";
                    break;
                case "7": //acompañado
                    representante.estadoCivil = "U";
                    break;
                default:
                    representante.estadoCivil = "X";
                    break;
            }
            if (jsonvalues.TokenStringValue("peprelacionJur") == "1")
            {
                representante.esPep = "S";
                representante.tipoPep = "R";
            }
            if (jsonvalues.TokenStringValue("pepcargoJur") == "1")
            {
                representante.esPep = "S";
                representante.tipoPep = "D";
            }


            mapInfo.clientesRepresentantes = new[] { representante };

            //mapInfo.articulo15 = jsonvalues.TokenStringValue("actividadesart15Jur") == "1" ? "S" : "N";
            mapInfo.articulo15 = "N";

            //if (jsonvalues.TokenStringValue("peprelacionJur") == "1")
            //{
            //    mapInfo.esPep = "S";
            //    mapInfo.tipoPep = "R";
            //}
            //if (jsonvalues.TokenStringValue("pepcargoJur") == "1")
            //{
            //    mapInfo.esPep = "S";
            //    mapInfo.tipoPep = "D";
            //}

            mapInfo.clientesPolizas = new List<Compliance.Integrations.Contracts.Clientespoliza>()
            {
                new Compliance.Integrations.Contracts.Clientespoliza()
                {
                    numeroPoliza = quoteInfo.num_poliza,
                    descripcionPoliza = "MapfreMas",
                    fechaInicio = quoteInfo.fec_efec_poliza,
                    fechaFinalizacion = quoteInfo.fec_vcto_poliza,
                    moneda  = quoteInfo.cod_mon,
                    prima = jsonvalues.TokenDoubleValue("montoprimaJur"),
                    estado="A",
                    //faltaban
                    tipoPrima = "A",
                    tipoPoliza= "C",
                    tipoProducto = 302,
                    montoAsegurado =jsonvalues.TokenDoubleValue("montovaloraseguradoJur")


                }
            };
            switch (jsonvalues.TokenStringValue("formadepagodelapolizaJur"))
            {
                case "1": //Anual
                    mapInfo.clientesPolizas[0].tipoPrima = "A";
                    break;
                case "2": //Semestral
                    mapInfo.clientesPolizas[0].tipoPrima = "S";
                    break;
                case "3": //Trimestral
                    mapInfo.clientesPolizas[0].tipoPrima = "T";
                    break;
                case "4": //Mensual
                    mapInfo.clientesPolizas[0].tipoPrima = "M";
                    break;
            }
            //if (quoteInfo.DatosEconomicos != null)
            //{
            //    mapInfo.clientesPolizas[0].prima = (int)quoteInfo.DatosEconomicos.annualgrosspremium;
            //}

            mapInfo.clientesSocios = new List<Clientessocio>();

            JArray participacionaccionaria = (JArray)jsonvalues["participacionaccionariaJur"];
            foreach (JObject item in participacionaccionaria)
            {

                mapInfo.clientesSocios.Add(new Clientessocio()
                {
                    tipoIdentificacionSocio = 1,
                    nombre = item.TokenStringValue("participacionaccionariaNombrecompletoJur"),
                    primerApellido = string.Empty,
                    numeroIdentificacionSocio = item.TokenStringValue("participacionaccionariaNumerodeidentificacionJur"),
                    participacion = item.TokenInt32Value("porcentajedeparticipacionJur"),
                    esPep = "N",
                    tipoPep = "N",
                    descripcionPep = "No aplica",
                    genero = "N",
                    articulo15 = "N",
                    estadoCivil = "X",
                    fechaNacimiento = new DateTime(1900, 1, 1)
                });

            }



            return mapInfo;
        }


        // FISICOS
        //	{"Text":"PERSONA FISICA NACIONAL","Value":"1"}
        //	{"Text":"PERSONA FISICA EXTRANJERA RESIDENTE","Value":"3"}
        //  { "Text":"PERSONA EXTRANJERA NO RESIDENTE","Value":"5"}
        //  { "Text":"No disponible","Value":"9"}
        //  { "Text":"PERSONA FISICA EXTRANJERA DIPLOMATICA","Value":"10"}
        // JURIDICO
        //{ "Text":"PERSONA JURIDICA NACIONAL","Value":"2"},
        //	{ "Text":"ENTIDAD FINANCIERA EXTRANJERA","Value":"4"},
        //	{ "Text":"PERSONA JURIDICA EXTRANJERA DOMICILIADA","Value":"6"},
        //	{ "Text":"FONDOS DE INVERSION","Value":"7"},
        //	{ "Text":"FIDEICOMISOS","Value":"8"},
        //	{ "Text":"PERSONA JURIDICA EXTRANJERA NO DOMICILIADA","Value":"11"},
        //	{ "Text":"INSTITUCION AUTONOMA","Value":"12"},
        //	{ "Text":"GOBIERNO CENTRAL","Value":"13"}
        //tipoCuenta
        //  {"Text":"Habitual","Value":"H"},
        //  {"Text":"Ocasional","Value":"O"},
        //  { "Text":"Nuevo","Value":"N"}




    }
}
