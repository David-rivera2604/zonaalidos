using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Architect.API.Core.Contracts;
using Newtonsoft.Json;
using Architect.Compliance.Integrations.Contracts;

namespace Architect.API.Tron.Business.HogarTotal.Handler
{
    static class Compliance
    {

        internal static void Apply(Contracts.Emision.HogarTotal quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            Contracts.Comun.tercero titular = (from t in quoteInfo.terceros where t.tipodetercero == 0 select t).FirstOrDefault();
            JObject jsonvalues = null;
            DateTime fechanaci = new DateTime(1900, 01, 01, 0, 00, 20);

            if (quoteInfo.kyc != null)
            {
                jsonvalues = (JObject)quoteInfo.kyc;
            }

            if (titular.DocumentNumberType != 4)
            {
                fechanaci = titular.fechadenacimiento;
            }

            int tipoIdenditificacion = titular.DocumentNumberType;
            switch (tipoIdenditificacion)
            {
                case 1: //Nacional
                    tipoIdenditificacion = 1;
                    break;
                case 2://Residente
                    tipoIdenditificacion = 3;
                    break;
                case 3://Pasaporte
                    tipoIdenditificacion = 5;
                    break;
                case 4: //Juridico
                    tipoIdenditificacion = 2;
                    break;
            }

            Architect.Compliance.Integrations.Contracts.Clientes mapInfo = new Architect.Compliance.Integrations.Contracts.Clientes()
            {
                tipoIdentificacion = tipoIdenditificacion,
                numeroIdentificacion = Util.IdentificationFormat(titular.DocumentNumberType, titular.DocumentNumber),
                nombreCliente = titular.nombre,
                primerApellido = titular.apellido1,
                segundoApellido = titular.apellido2,
                conocidoComo = String.Empty,
                razonSocial = String.Empty,
                nombreComercial = String.Empty,
                fechaUltimaActualizacion = DateTime.Now,
                descripcionCuenta = titular.nombre.CompleteFullName(titular.apellido1, titular.apellido2),
                numeroIdentificacionEntidad = Util.IdentificationFormat(titular.DocumentNumberType, titular.DocumentNumber),
                fechaNacimiento = fechanaci,
                ejecutivo = tokenInfo.AgentCode.ToString(),
                genero = "",
                estadoCivil = "",
                estado = "A",
                estadoXML = "X",
                usuarioRegistro = tokenInfo.UserId.ToString(),
                administFondosTercero = "N",
                usuario = tokenInfo.UserId,
                esApnfd = "N",
                tipoApnfd = "0",
                esCpe = "N",
                pagaImpuestos = "N",
                //faltaban
                esPep = "N",
                tipoPep = "N",
                residente = "S",
                articulo15 = "S",
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
                fechaVencimientoIdentificacion = titular.DocumentNumberType == 4 ? jsonvalues.TokenDateTimeValue("fechadecaducidadJur") : jsonvalues.TokenDateTimeValue("fechadecaducidadPer"),
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
            mapInfo.clientesUbicaciones = new List<Architect.Compliance.Integrations.Contracts.Clientesubicacione>()
            {
                new  Architect.Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 1,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = titular.numerodetelefono
                },
                new  Architect.Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 3,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = titular.correoelectronico
                },
                new  Architect.Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 4,
                    divisionTerritorial = titular.TDistrito,
                    descripcionUbicacion = String.Format("{0}, {1}, {2}, {3}. {4}.", titular.TProvinciaDesc , titular.TCantonDesc,titular.TDistritoDesc,titular.otrasenas, "Costa Rica")
                }
            };

            if (titular.DocumentNumberType == 4)
            {
                var removeLine = titular.DocumentNumber.Replace("-", string.Empty);
                mapInfo.numeroIdentificacion = removeLine;

                mapInfo.razonSocial = titular.nombre;
                mapInfo.nombreComercial = titular.nombre;
                mapInfo.nombreCliente = string.Empty;
                mapInfo.primerApellido = string.Empty;
                mapInfo.segundoApellido = string.Empty;
                mapInfo.genero = "X";
                mapInfo.estadoCivil = "X";

                if (jsonvalues != null)
                {
                    mapInfo.paisOrigen = jsonvalues.TokenInt32Value("paisdeconstitucionJur");
                    mapInfo.actividadEconomica = jsonvalues.TokenInt32Value("actividadEconomica");

                    mapInfo.articulo15 = jsonvalues.TokenStringValue("actividadesart15") == "1" ? "S" : "N";
                    if (jsonvalues.TokenStringValue("peprelacion") == "1")
                    {
                        mapInfo.esPep = "S";
                        mapInfo.tipoPep = "R";
                    }
                    if (jsonvalues.TokenStringValue("pepcargo") == "1")
                    {
                        mapInfo.esPep = "S";
                        mapInfo.tipoPep = "D";
                    }

                    Clientesfatca FATCA = new Clientesfatca()
                    {
                        poseeGreenCard = jsonvalues.TokenStringValue("greencard") == "1" ? "S" : "N",
                        numeroTIN = jsonvalues.TokenStringValue("numeroTIN"),
                        detalleDomicilio = jsonvalues.TokenStringValue("otrassenasFATCA"),
                        poseeEIN = jsonvalues.TokenStringValue("identificacionEIN") == "1" ? "S" : "N",
                        contribuyenteUSA = jsonvalues.TokenStringValue("contribuyenteUSA") == "1" ? "S" : "N",
                        domicilioExtranjero = jsonvalues.TokenStringValue("domicilioExtranjero") == "1" ? "S" : "N",
                        paisDomicilio = jsonvalues.TokenInt32Value("paisDomicilio"),
                        poseeTelefonoExtranjero = jsonvalues.TokenStringValue("poseeTelefonoExtranjero") == "1" ? "S" : "N",
                        telefonoExtranjero = jsonvalues.TokenStringValue("numeroExt"),
                        poseeProductos = "N"
                    };
                    mapInfo.clientesFATCA = new List<Clientesfatca>() { FATCA };


                    Clientesrepresentante representantesLegales = new Clientesrepresentante()
                    {
                        nombre = titular.nombre,
                        tipoIdentificacionRepresentante = tipoIdenditificacion,
                        numeroIdentificacionRepresentante = Util.IdentificationFormat(titular.DocumentNumberType, mapInfo.numeroIdentificacion),
                        segundoNombre = string.Empty,
                        cargo = jsonvalues.TokenStringValue("posiciondentrodelaempresaJur"),
                        estadoCivil = jsonvalues.TokenStringValue("estadocivilJur", "X"),
                        conocidoComo = jsonvalues.TokenStringValue("nombreJur"),
                        primerApellido = jsonvalues.TokenStringValue("primerapellidoJur"),
                        segundoApellido = jsonvalues.TokenStringValue("segundoapellidoJur"),
                        genero = jsonvalues.TokenStringValue("sexoJur") == "1" ? "M" : "F",
                        fechaNacimiento = jsonvalues.TokenDateTimeValue("fechadenacimientoJur"),
                        paisOrigen = jsonvalues.TokenInt32Value("nacionalidadJur"),
                        profesion = jsonvalues.TokenInt32Value("profesionJur"),
                        actividadEconomica = jsonvalues.TokenInt32Value("actividadEconomicaRep"),
                        fechaVencimiento = mapInfo.fechaVencimientoIdentificacion,
                        esPep = mapInfo.esPep,
                        tipoPep = mapInfo.tipoPep,
                        descripcionPep = "No aplica",
                        articulo15 = mapInfo.articulo15
                    };
                    switch (representantesLegales.estadoCivil)
                    {
                        case "1": //casado
                            representantesLegales.estadoCivil = "C";
                            break;
                        case "2": //divorciado
                            representantesLegales.estadoCivil = "D";
                            break;
                        case "3": //soltero
                            representantesLegales.estadoCivil = "S";
                            break;
                        case "4": //viudo
                            representantesLegales.estadoCivil = "V";
                            break;
                        case "5": //otro
                            representantesLegales.estadoCivil = "X";
                            break;
                        case "7": //acompañado
                            representantesLegales.estadoCivil = "U";
                            break;
                        default:
                            representantesLegales.estadoCivil = "X";
                            break;
                    }

                    mapInfo.clientesRepresentantes = new[] { representantesLegales };

                    Clientestransaccione transaccionalidadCliente = new Clientestransaccione()
                    {
                        monto = quoteInfo.sAEdificio,
                        montoIngresoMensual = jsonvalues.TokenInt32Value("ingresomensualestimado"),
                        inversionInicial = jsonvalues.TokenStringValue("formadepagodelapoliza"),
                        frecuencia = jsonvalues.TokenStringValue("periodicidad")

                    };
                    switch (transaccionalidadCliente.frecuencia)
                    {
                        case "4":
                            transaccionalidadCliente.frecuencia = "M";
                            break;

                        default:
                            transaccionalidadCliente.frecuencia = "N";
                            break;

                    }
                    switch (transaccionalidadCliente.inversionInicial)
                    {
                        case "1":
                            transaccionalidadCliente.inversionInicial = "E";
                            break;
                        case "2":
                            transaccionalidadCliente.inversionInicial = "C";
                            break;

                        case "3":
                            transaccionalidadCliente.inversionInicial = "D";
                            break;

                        case "4":
                            transaccionalidadCliente.inversionInicial = "T";
                            break;

                        default:
                            transaccionalidadCliente.inversionInicial = "T";
                            break;
                    }
                    mapInfo.clientesTransacciones = new[] { transaccionalidadCliente };

                    KycJuridico deserializedKyc = JsonConvert.DeserializeObject<KycJuridico>(JsonConvert.SerializeObject(jsonvalues));
                    List<Participador_Accionario> participacionAccionaria = deserializedKyc.participacionaccionariaJur;
                    List<Clientessocio> sociosList = new List<Clientessocio>();

                    foreach (dynamic recorrerPA in participacionAccionaria)
                    {
                        Clientessocio socios = new Clientessocio()
                        {
                            tipoIdentificacionSocio = recorrerPA.participacionaccionariaTipodeidentificacionJur,
                            numeroIdentificacionSocio = recorrerPA.participacionaccionariaNumerodeidentificacionJur,
                            nombre = recorrerPA.participacionaccionariaNombrecompletoJur,
                            primerApellido = string.Empty,
                            segundoApellido = string.Empty,
                            conocidoComo = string.Empty,
                            participacion = recorrerPA.porcentajedeparticipacionJur,
                            genero = recorrerPA.participacionaccionariaSexoJur == 1 ? "M" : "F",
                            fechaNacimiento = recorrerPA.participacionaccionariaFechadenacimientoJur,
                            estadoCivil = recorrerPA.participacionaccionariaEstadocivilJur.ToString(),
                            paisOrigen = recorrerPA.participacionaccionariaPaisdenacimientoJur,
                            profesion = recorrerPA.participacionaccionariaProfesionJur,
                            actividadEconomica = mapInfo.actividadEconomica, //ARREGLAR
                            esPep = mapInfo.esPep,
                            tipoPep = mapInfo.tipoPep,
                            descripcionPep = "No aplica",
                            articulo15 = mapInfo.articulo15
                        };

                        switch (socios.estadoCivil)
                        {
                            case "1": //casado
                                socios.estadoCivil = "C";
                                break;
                            case "2": //divorciado
                                socios.estadoCivil = "D";
                                break;
                            case "3": //soltero
                                socios.estadoCivil = "S";
                                break;
                            case "4": //viudo
                                socios.estadoCivil = "V";
                                break;
                            case "5": //otro
                                socios.estadoCivil = "X";
                                break;
                            case "7": //acompañado
                                socios.estadoCivil = "U";
                                break;
                            default:
                                socios.estadoCivil = "X";
                                break;
                        }

                        sociosList.Add(socios);

                    }
                    mapInfo.clientesSocios = sociosList;




                    Clientesotrosatributo otrosAtributos = new Clientesotrosatributo()
                    {
                        atributo = jsonvalues.TokenInt32Value("atributocanaldeingreso"),
                        descripcionAtributo = jsonvalues.TokenStringValue("valorcanalingresoDesc")
                    };

                    mapInfo.clientesOtrosAtributos = new[] { otrosAtributos };


                    Clientespatrimonio clientespatrimonio = new Clientespatrimonio()
                    {
                        descripcionPatrimonio = "SEGURO HOGAR TOTAL",
                        tipoBien = 1,
                        moneda = quoteInfo.moneda,
                        montoValor = quoteInfo.sAEdificio,
                        fechaRegistro = mapInfo.fechaRegistro,
                    };
                    mapInfo.clientesPatrimonio = new List<Clientespatrimonio>() { clientespatrimonio };



                }
            }
            else
            {
                //if (titular.DocumentNumberType == 1)
                //{
                //    var removeLine = titular.DocumentNumber.Replace("-", string.Empty);
                //    var numberChanged = removeLine.Remove(0, 1);
                //    mapInfo.numeroIdentificacion = numberChanged;
                //}

                mapInfo.numeroIdentificacion = Util.IdentificationFormat(titular.DocumentNumberType, titular.DocumentNumber);

                mapInfo.genero = titular.tercerosMca_sexo == 1 ? "M" : "F";
                mapInfo.estadoCivil = titular.estadoCivil;
                if (jsonvalues != null)
                {

                    mapInfo.profesion = jsonvalues.TokenInt32Value("profesionPer");
                    mapInfo.paisOrigen = jsonvalues.TokenInt32Value("paisdenacimientoPer");
                    mapInfo.actividadEconomica = 1;
                    mapInfo.clientesNacionalidades = new[] { new Clientesnacionalidade() { nacionalidad = jsonvalues.TokenInt32Value("nacionalidadPer") } };
                    string telefonocelularPer = jsonvalues.TokenStringValue("telefonocelularPer");
                    if (telefonocelularPer.IsNotEmpty())
                    {
                        mapInfo.clientesUbicaciones.Add(new Architect.Compliance.Integrations.Contracts.Clientesubicacione()
                        {
                            tipoUbicacion = 2,
                            divisionTerritorial = 99999,
                            descripcionUbicacion = telefonocelularPer
                        });
                    }

                    mapInfo.articulo15 = jsonvalues.TokenStringValue("actividadesart15") == "1" ? "S" : "N";
                    if (jsonvalues.TokenStringValue("peprelacion") == "1")
                    {
                        mapInfo.esPep = "S";
                        mapInfo.tipoPep = "R";
                    }
                    if (jsonvalues.TokenStringValue("pepcargo") == "1")
                    {
                        mapInfo.esPep = "S";
                        mapInfo.tipoPep = "D";
                    }

                    Clientesfatca FATCA = new Clientesfatca()
                    {
                        poseeGreenCard = jsonvalues.TokenStringValue("greencard") == "1" ? "S" : "N",
                        numeroTIN = jsonvalues.TokenStringValue("numeroTIN"),
                        detalleDomicilio = jsonvalues.TokenStringValue("otrassenasFATCA"),
                        poseeEIN = jsonvalues.TokenStringValue("identificacionEIN") == "1" ? "S" : "N",
                        contribuyenteUSA = jsonvalues.TokenStringValue("contribuyenteUSA") == "1" ? "S" : "N",
                        domicilioExtranjero = jsonvalues.TokenStringValue("domicilioExtranjero") == "1" ? "S" : "N",
                        paisDomicilio = jsonvalues.TokenInt32Value("paisDomicilio"),
                        poseeTelefonoExtranjero = jsonvalues.TokenStringValue("poseeTelefonoExtranjero") == "1" ? "S" : "N",
                        telefonoExtranjero = jsonvalues.TokenStringValue("numeroExt"),
                        poseeProductos = "N"
                    };
                    mapInfo.clientesFATCA = new List<Clientesfatca> { FATCA };

                    Clientesrelacione personasRelacionadas = new Clientesrelacione()
                    {
                        nombre = titular.nombre,
                        tipoIdentificacionRelacion = tipoIdenditificacion,
                        numeroIdentificacionRelacion = Util.IdentificationFormat(titular.DocumentNumberType, mapInfo.numeroIdentificacion),
                        fechaVencimientoIdentificacion = mapInfo.fechaVencimientoIdentificacion,
                        segundoNombre = string.Empty,
                        titular = titular.tipodetercero == 1 ? "S" : "N",
                        cargo = jsonvalues.TokenStringValue("cargoempresaPer"),
                        descripcionPep = "No aplica",
                        tipoTitularidad = titular.tipodetercero == 1 ? "O" : "X",
                        estadoCivil = jsonvalues.TokenStringValue("estadocivilPer", "X"),
                        conocidoComo = jsonvalues.TokenStringValue("nombrePer"),
                        primerApellido = jsonvalues.TokenStringValue("primerapellidoPer"),
                        segundoApellido = jsonvalues.TokenStringValue("segundoapellidoPer"),
                        beneficiario = titular.tipodetercero == 1 ? "S" : "N",
                        genero = mapInfo.genero,
                        fechaNacimiento = jsonvalues.TokenDateTimeValue("fechadenacimientoPer"),
                        paisOrigen = mapInfo.paisOrigen,
                        profesion = jsonvalues.TokenInt32Value("profesionPer"),
                        actividadEconomica = mapInfo.actividadEconomica,
                        esPep = mapInfo.esPep,
                        tipoPep = mapInfo.tipoPep,
                        articulo15 = mapInfo.articulo15,
                        fechaInscripcionCargo = new DateTime(1900, 1, 1),
                        fechaFinalizacionCargo = new DateTime(1900, 1, 1),
                    };

                    switch (personasRelacionadas.estadoCivil)
                    {
                        case "1": //casado
                            personasRelacionadas.estadoCivil = "C";
                            break;
                        case "2": //divorciado
                            personasRelacionadas.estadoCivil = "D";
                            break;
                        case "3": //soltero
                            personasRelacionadas.estadoCivil = "S";
                            break;
                        case "4": //viudo
                            personasRelacionadas.estadoCivil = "V";
                            break;
                        case "5": //otro
                            personasRelacionadas.estadoCivil = "X";
                            break;
                        case "7": //acompañado
                            personasRelacionadas.estadoCivil = "U";
                            break;
                        default:
                            personasRelacionadas.estadoCivil = "X";
                            break;
                    }

                    mapInfo.clientesRelaciones = new[] { personasRelacionadas };



                    Clientesrepresentante beneficiarios = new Clientesrepresentante()
                    {
                        tipoIdentificacionRepresentante = tipoIdenditificacion,
                        numeroIdentificacionRepresentante = Util.IdentificationFormat(titular.DocumentNumberType, titular.DocumentNumber),
                        nombre = titular.nombre,
                        fechaVencimiento = mapInfo.fechaVencimientoIdentificacion,
                        segundoNombre = string.Empty,
                        primerApellido = jsonvalues.TokenStringValue("primerapellidoPer"),
                        segundoApellido = jsonvalues.TokenStringValue("segundoapellidoPer"),
                        conocidoComo = String.Empty,
                        genero = jsonvalues.TokenStringValue("sexoPer") == "1" ? "M" : "F",
                        fechaNacimiento = titular.fechadenacimiento,
                        estadoCivil = jsonvalues.TokenStringValue("estadocivilPer", "X"),
                        paisOrigen = jsonvalues.TokenInt32Value("paisdenacimientoPer"),
                        profesion = jsonvalues.TokenInt32Value("profesionPer"),
                        actividadEconomica = jsonvalues.TokenInt32Value("actividaddelclientenaturalezadelnegocioPer"),
                        esPep = mapInfo.esPep,
                        tipoPep = mapInfo.tipoPep,
                        descripcionPep = "No aplica",
                        articulo15 = mapInfo.articulo15,
                        cargo = jsonvalues.TokenStringValue("posiciondentrodelaempresaPer", "No aplica")
                    };

                    switch (beneficiarios.estadoCivil)
                    {
                        case "1": //casado
                            beneficiarios.estadoCivil = "C";
                            break;
                        case "2": //divorciado
                            beneficiarios.estadoCivil = "D";
                            break;
                        case "3": //soltero
                            beneficiarios.estadoCivil = "S";
                            break;
                        case "4": //viudo
                            beneficiarios.estadoCivil = "V";
                            break;
                        case "5": //otro
                            beneficiarios.estadoCivil = "X";
                            break;
                        case "7": //acompañado
                            beneficiarios.estadoCivil = "U";
                            break;
                        default:
                            beneficiarios.estadoCivil = "X";
                            break;
                    }
                    if (jsonvalues.TokenStringValue("peprelacion") == "1")
                    {
                        beneficiarios.esPep = "S";
                        beneficiarios.tipoPep = "R";
                    }
                    if (jsonvalues.TokenStringValue("pepcargo") == "1")
                    {
                        beneficiarios.esPep = "S";
                        beneficiarios.tipoPep = "D";
                    }
                    mapInfo.clientesRepresentantes = new[] { beneficiarios };



                    Clientestransaccione transaccionalidadCliente = new Clientestransaccione()
                    {
                        monto = quoteInfo.sAEdificio,
                        montoIngresoMensual = jsonvalues.TokenInt32Value("ingresomensualestimado"),
                        inversionInicial = jsonvalues.TokenStringValue("formadepagodelapoliza"),
                        frecuencia = jsonvalues.TokenStringValue("periodicidad")

                    };
                    switch (transaccionalidadCliente.frecuencia)
                    {
                        case "4":
                            transaccionalidadCliente.frecuencia = "M";
                            break;

                        default:
                            transaccionalidadCliente.frecuencia = "N";
                            break;

                    }
                    switch (transaccionalidadCliente.inversionInicial)
                    {
                        case "1":
                            transaccionalidadCliente.inversionInicial = "E";
                            break;
                        case "2":
                            transaccionalidadCliente.inversionInicial = "C";
                            break;

                        case "3":
                            transaccionalidadCliente.inversionInicial = "D";
                            break;

                        case "4":
                            transaccionalidadCliente.inversionInicial = "T";
                            break;

                        default:
                            transaccionalidadCliente.inversionInicial = "T";
                            break;
                    }
                    mapInfo.clientesTransacciones = new[] { transaccionalidadCliente };


                    Clientesingreso transaccionalidadIngresos = new Clientesingreso()
                    {
                        actividadEconomica = mapInfo.actividadEconomica,
                        cargo = jsonvalues.TokenStringValue("cargoempresaPer"),
                        telefonoDirecto = jsonvalues.TokenStringValue("telefonocelularPer"),
                        telefonoCentral = jsonvalues.TokenStringValue("telefonoresidenciaPer"),
                        origenRecursos = jsonvalues.TokenInt32Value("correspondenciaOrigendelosfondosPer"),
                        sustentoOtraPersonas = "S",
                        moneda = quoteInfo.moneda,
                        monto = jsonvalues.TokenInt32Value("ingresomensualestimado"),
                        direccion = jsonvalues.TokenStringValue("domiciliocomercialCod_paisDesc") + "-" + " " + jsonvalues.TokenStringValue("domiciliocomercialCod_estadoDesc") + "-" + " " + jsonvalues.TokenStringValue("domiciliocomercialCod_provDesc") + "-" + " " + jsonvalues.TokenStringValue("domiciliocomercialCod_localidadDesc")
                    };
                    mapInfo.clientesIngresos = new[] { transaccionalidadIngresos };


                    Clientesotrosatributo otrosAtributos = new Clientesotrosatributo()
                    {
                        atributo = jsonvalues.TokenInt32Value("atributocanaldeingreso"),
                        descripcionAtributo = jsonvalues.TokenStringValue("valorcanalingreso").ToString()
                    };

                    mapInfo.clientesOtrosAtributos = new[] { otrosAtributos };


                    Clientespatrimonio clientespatrimonio = new Clientespatrimonio()
                    {
                        descripcionPatrimonio = "SEGURO HOGAR TOTAL",
                        tipoBien = 1,
                        moneda = quoteInfo.moneda,
                        montoValor = quoteInfo.sAEdificio,
                        fechaRegistro = mapInfo.fechaRegistro,
                    };
                    mapInfo.clientesPatrimonio = new List<Clientespatrimonio>() { clientespatrimonio };
                }
            }

            mapInfo.clientesPolizas = new List<Architect.Compliance.Integrations.Contracts.Clientespoliza>()
            {
                new  Architect.Compliance.Integrations.Contracts.Clientespoliza()
                {
                    numeroPoliza = quoteInfo.num_poliza,
                    descripcionPoliza = "HogarTotal",
                    fechaInicio = quoteInfo.iniciodevigencia,
                    fechaFinalizacion = quoteInfo.findevigencia,
                    moneda  = quoteInfo.moneda,
                   // prima = (int)quoteInfo.DatosEconomicos.annualnetpremium,
                    estado = "A",
                    //faltaban
                    tipoPrima = "A",
                    tipoPoliza= "C",
                    tipoProducto = 201,
                }
            };
            if (quoteInfo.DatosEconomicos != null)
            {
                mapInfo.clientesPolizas[0].prima = (int)quoteInfo.DatosEconomicos.annualgrosspremium;
            }

            if (titular.DocumentNumberType != 4)
            {
                mapInfo.clientesNacionalidades = null;
                mapInfo.clientesFATCA = null;
                mapInfo.clientesIngresos = null;
                mapInfo.clientesFondosTerceros = null;
                mapInfo.clientesPatrimonio = null;
                mapInfo.clientesFuncionesPEP = null;
                mapInfo.clientesTransacciones = null;
                mapInfo.clientesOtrosAtributos = null;
                mapInfo.clientesSocios = null;
                mapInfo.clientesRelaciones = null;
                mapInfo.clientesNacionalidades = null;
            }

            string result = Architect.Compliance.Integrations.Business.Customers.SendCustomers(mapInfo).Result;
        }


    }
}
