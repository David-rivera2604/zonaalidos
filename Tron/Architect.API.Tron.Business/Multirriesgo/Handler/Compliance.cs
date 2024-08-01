using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Architect.API.Core.Contracts;
using Newtonsoft.Json;
using Architect.Compliance.Integrations.Contracts;

namespace Architect.API.Tron.Business.Multirriesgo.Handler
{
    static class Compliance
    {

        internal static string Apply(Contracts.Emision.Multirriesgo quoteInfo, Core.Contracts.Security.Token tokenInfo)
        {
            JObject jsonvalues = null;
            Contracts.Comun.tercero titular = (from t in quoteInfo.terceros where t.tipodetercero == 0 select t).FirstOrDefault();
            DateTime fechanaci = new DateTime(1900, 01, 01, 0, 00, 20);

            if (quoteInfo.kyc != null)
            {
                jsonvalues = (JObject)quoteInfo.kyc;
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

            string numidenti = Util.IdentificationFormat(titular.DocumentNumberType, titular.DocumentNumber);

            //if (titular.DocumentNumberType == 1)
            //{
            //    numidenti = numidenti.Remove(0, 1);
            //    numidenti = numidenti.Replace("-", string.Empty);
            //}

            if (titular.DocumentNumberType != 4)
            {
                fechanaci = titular.fechadenacimiento;
            }

            Architect.Compliance.Integrations.Contracts.Clientes mapInfo = new Architect.Compliance.Integrations.Contracts.Clientes()
            {


                tipoIdentificacion = tipoIdenditificacion,
                numeroIdentificacion = numidenti,
                nombreCliente = titular.nombre,
                primerApellido = titular.apellido1,
                segundoApellido = titular.apellido2,
                conocidoComo = String.Empty,
                razonSocial = String.Empty,
                nombreComercial = String.Empty,
                descripcionCuenta = titular.nombre.CompleteFullName(titular.apellido1, titular.apellido2),
                numeroIdentificacionEntidad = numidenti,
                fechaVencimientoIdentificacion = titular.DocumentNumberType == 4 ? jsonvalues.TokenDateTimeValue("fechadecaducidadJur") : jsonvalues.TokenDateTimeValue("fechadecaducidadPer"), //new DateTime(1900, 1, 1),
                lugarExpedicionIdentificacion = "Costa Rica",
                fechaUltimaActualizacion = DateTime.Now,
                fechaNacimiento = fechanaci,
                ejecutivo = tokenInfo.AgentCode.ToString(),
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
                new Architect.Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 1,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = titular.numerodetelefono
                },
                new Architect.Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 3,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = titular.correoelectronico
                },
                new Architect.Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 4,
                    divisionTerritorial = titular.TDistrito,
                    descripcionUbicacion = String.Format("{0}, {1}, {2}, {3}. {4}.", titular.TProvinciaDesc , titular.TCantonDesc,titular.TDistritoDesc,titular.otrasenas, "Costa Rica")
                }
            };

            Clientesfatca FATCA = new Clientesfatca()
            {
                poseeGreenCard = "N",
                poseeEIN = "N",
                contribuyenteUSA = "N",
                domicilioExtranjero = "N",
                paisDomicilio = 188,
                poseeTelefonoExtranjero = "N",
                poseeProductos = "N"
            };

            Clientestransaccione Transacciones = new Clientestransaccione()
            {
                monto = quoteInfo.IMP_BIE_INT + quoteInfo.IMP_BIE_TEM_DES +
                quoteInfo.IMP_DOMOS_TOTAL + quoteInfo.IMP_EDIFICIO + quoteInfo.IMP_EQUIP_ELEC +
                quoteInfo.IMP_EQUIP_ELEC_M + quoteInfo.IMP_GAS_ALQ + quoteInfo.IMP_INT_NEG +
                quoteInfo.IMP_MAQUINARIA + quoteInfo.IMP_MERCADERIA + quoteInfo.IMP_MER_TRA +
                quoteInfo.IMP_MOBILIARIO + quoteInfo.IMP_OBJ_ESP_VAL + quoteInfo.IMP_PER_REN,
                frecuencia = "N"

            };

            Clientesingreso Ingresos = new Clientesingreso()
            {
                sustentoOtraPersonas = "N",
                origenRecursos = 3,
            };

            Clientesotrosatributo OtrosAtributos = new Clientesotrosatributo()
            {
                atributo = 1,
                descripcionAtributo = "0"
            };

            Clientespatrimonio Patrimonio = new Clientespatrimonio()
            {
                descripcionPatrimonio = "Edificio",
                tipoBien = 1,
                moneda = quoteInfo.cod_mon,
                montoValor = 0,
                fechaRegistro = DateTime.Now
            };

            if (quoteInfo.coberturas != null)
            {
                foreach (Contracts.Comun.Cobertura cobertura in quoteInfo.coberturas)
                {
                    if (cobertura.nombre == "EDIFICIO")
                    {
                        Patrimonio.montoValor = (int)cobertura.capital;
                    }
                }
            }



            if (jsonvalues != null)
            {

                mapInfo.actividadEconomica = jsonvalues.TokenInt32Value("actividadEconomica");
                mapInfo.articulo15 = jsonvalues.TokenStringValue("actividadesart15") == "1" ? "S" : "N";
                //------FACTA General------\\
                FATCA.poseeGreenCard = jsonvalues.TokenStringValue("greencard") == "1" ? "S" : "N";
                FATCA.numeroTIN = jsonvalues.TokenStringValue("numeroTIN");
                FATCA.poseeEIN = jsonvalues.TokenStringValue("identificacionEIN") == "1" ? "S" : "N";
                FATCA.contribuyenteUSA = jsonvalues.TokenStringValue("contribuyenteUSA") == "1" ? "S" : "N";
                FATCA.domicilioExtranjero = jsonvalues.TokenStringValue("domicilioExtranjero") == "1" ? "S" : "N";
                FATCA.paisDomicilio = jsonvalues.TokenInt32Value("paisDomicilio");
                FATCA.detalleDomicilio = jsonvalues.TokenStringValue("otrassenasFATCA");
                FATCA.poseeTelefonoExtranjero = jsonvalues.TokenStringValue("poseeTelefonoExtranjero") == "1" ? "S" : "N";
                FATCA.telefonoExtranjero = jsonvalues.TokenStringValue("numeroExt");

                //------PEPs General------\\
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

                //------Transaccionalidad General------\\

                switch (jsonvalues.TokenInt32Value("formadepagodelapoliza"))
                {
                    case 1: //Efectivo
                        Transacciones.inversionInicial = "E";
                        break;
                    case 2: //Cheque
                        Transacciones.inversionInicial = "C";
                        break;
                    case 3: //Deposito
                        Transacciones.inversionInicial = "D";
                        break;
                    case 4: //Transferencia
                        Transacciones.inversionInicial = "T";
                        break;
                }

                Transacciones.frecuencia = quoteInfo.cod_fracc_pago == 12 ? "M" : "N";
                Transacciones.montoIngresoMensual = jsonvalues.TokenInt32Value("ingresomensualestimado");

                //-----Ingresos General-----\\
                Ingresos.direccion = jsonvalues.TokenStringValue("domiciliocomercialCod_paisDesc") + " " +
                       jsonvalues.TokenStringValue("domiciliocomercialCod_estadoDesc") + " " +
                       jsonvalues.TokenStringValue("domiciliocomercialCod_provDesc") + " " +
                       jsonvalues.TokenStringValue("domiciliocomercialCod_localidadDesc");
                Ingresos.actividadEconomica = jsonvalues.TokenInt32Value("actividadEconomica");
                Ingresos.monto = jsonvalues.TokenInt32Value("ingresomensualestimado");
                Ingresos.justificacionOrigenRecursos = jsonvalues.TokenStringValue("correspondenciaOrigendelosfondos");
                Ingresos.moneda = quoteInfo.cod_mon;
                //------Otros atributos General------\\
                OtrosAtributos.descripcionAtributo = jsonvalues.TokenStringValue("valorcanalingreso");
            }



            if (titular.DocumentNumberType == 4)
            {
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
                    mapInfo.fechaVencimientoIdentificacion = titular.DocumentNumberType == 4 ? jsonvalues.TokenDateTimeValue("fechadecaducidadJur") : jsonvalues.TokenDateTimeValue("fechadecaducidadPer");
                    Clientesrepresentante representante = new Clientesrepresentante()
                    {

                        tipoIdentificacionRepresentante = jsonvalues.TokenInt32Value("tipodeidentificacionJur"),
                        numeroIdentificacionRepresentante = jsonvalues.TokenStringValue("numerodeidentificacionJur"),
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
                        actividadEconomica = jsonvalues.TokenInt32Value("actividadEconomicaRep"),
                        esPep = "N",
                        tipoPep = "N",
                        descripcionPep = "No aplica",
                        articulo15 = jsonvalues.TokenStringValue("actividadesart15") == "1" ? "S" : "N",
                        cargo = jsonvalues.TokenStringValue("posiciondentrodelaempresaJur", "No aplica"),
                        fechaVencimiento = jsonvalues.TokenDateTimeValue("fechadecaducidadJur")
                    };

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

                    if (jsonvalues.TokenStringValue("peprelacion") == "1")
                    {
                        representante.esPep = "S";
                        representante.tipoPep = "R";
                    }
                    if (jsonvalues.TokenStringValue("pepcargo") == "1")
                    {
                        representante.esPep = "S";
                        representante.tipoPep = "D";
                    }

                    mapInfo.clientesRepresentantes = new[] { representante };


                    //-----Ingresos Juridico-----\\
                    Ingresos.nombreEmpresa = jsonvalues.TokenStringValue("nombrecomercialJur");
                    Ingresos.telefonoCentral = jsonvalues.TokenStringValue("telefonoJur");

                    KycJuridico deserializedKyc = JsonConvert.DeserializeObject<KycJuridico>(JsonConvert.SerializeObject(jsonvalues));
                    List<Participador_Accionario> participacionAccionaria = deserializedKyc.participacionaccionariaJur;
                    List<Clientessocio> sociosList = new List<Clientessocio>();
                    foreach (Participador_Accionario accionario in participacionAccionaria)
                    {
                        Clientessocio socios = new Clientessocio()
                        {
                            tipoIdentificacionSocio = accionario.participacionaccionariaTipodeidentificacionJur,
                            numeroIdentificacionSocio = accionario.participacionaccionariaNumerodeidentificacionJur,
                            nombre = accionario.participacionaccionariaNombrecompletoJur,
                            primerApellido = string.Empty,
                            segundoApellido = string.Empty,
                            conocidoComo = string.Empty,
                            participacion = accionario.porcentajedeparticipacionJur,
                            genero = accionario.participacionaccionariaSexoJur == 1 ? "M" : "F",
                            fechaNacimiento = accionario.participacionaccionariaFechadenacimientoJur,
                            estadoCivil = accionario.participacionaccionariaEstadocivilJur.ToString(),
                            paisOrigen = accionario.participacionaccionariaPaisdenacimientoJur,
                            profesion = accionario.participacionaccionariaProfesionJur,
                            actividadEconomica = accionario.participacionaccionariaAct_Economica, //ARREGLAR
                            esPep = "N",
                            tipoPep = "N",
                            descripcionPep = "No aplica",
                            articulo15 = accionario.participacionaccionariaArt15Jur == 1 ? "S" : "N",
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
                        if (accionario.participacionaccionariaPepCargoJur == 1)
                        {
                            representante.esPep = "S";
                            representante.tipoPep = "R";
                        }
                        if (accionario.participacionaccionariaPepRelacionJur == 1)
                        {
                            representante.esPep = "S";
                            representante.tipoPep = "D";
                        }

                        sociosList.Add(socios);
                    }

                    mapInfo.clientesSocios = sociosList;
                }

            }
            else
            {
                mapInfo.genero = titular.tercerosMca_sexo == 1 ? "M" : "F";
                mapInfo.estadoCivil = titular.estadoCivil;

                if (jsonvalues != null)
                {

                    mapInfo.profesion = jsonvalues.TokenInt32Value("profesionPer");
                    mapInfo.paisOrigen = jsonvalues.TokenInt32Value("paisdenacimientoPer");
                    mapInfo.fechaVencimientoIdentificacion = titular.DocumentNumberType == 4 ? jsonvalues.TokenDateTimeValue("fechadecaducidadJur") : jsonvalues.TokenDateTimeValue("fechadecaducidadPer");

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



                    //-----Ingresos Persona-----\\
                    Ingresos.nombreEmpresa = jsonvalues.TokenStringValue("nombreempresaPer");
                    Ingresos.cargo = jsonvalues.TokenStringValue("cargoempresaPer");
                    Ingresos.telefonoCentral = jsonvalues.TokenStringValue("telefonoempresaPer");

                }
            }


            mapInfo.clientesFATCA = new List<Clientesfatca>() { FATCA };
            mapInfo.clientesTransacciones = new[] { Transacciones };
            mapInfo.clientesIngresos = new[] { Ingresos };
            mapInfo.clientesPolizas = new List<Architect.Compliance.Integrations.Contracts.Clientespoliza>()
            {
                new Architect.Compliance.Integrations.Contracts.Clientespoliza()
                {
                    numeroPoliza = quoteInfo.num_poliza,
                    descripcionPoliza = "Multirriesgo",
                    fechaInicio = quoteInfo.fec_efec_poliza,
                    fechaFinalizacion = quoteInfo.fec_vcto_poliza,
                    moneda  = quoteInfo.cod_mon,
                   // prima = (int)quoteInfo.DatosEconomicos.annualnetpremium,
                    estado="A",
                    //faltaban
                    tipoPrima = "A",
                    tipoPoliza= "C",
                    tipoProducto = quoteInfo.cod_ramo
                }
            };
            mapInfo.clientesOtrosAtributos = new[] { OtrosAtributos };
            mapInfo.clientesPatrimonio = new List<Clientespatrimonio> { Patrimonio };
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
            return result;
        }

    }
}
