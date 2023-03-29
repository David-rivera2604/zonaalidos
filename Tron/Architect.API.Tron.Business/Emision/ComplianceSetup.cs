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
                mapInfo = Persona(quoteInfo, jsonvalues, titular);
            }
            mapInfo.ejecutivo = tokenInfo.AgentCode.ToString();
            mapInfo.usuarioRegistro = tokenInfo.UserId.ToString();
            mapInfo.usuario = tokenInfo.UserId;
            string result = Architect.Compliance.Integrations.Business.Customers.SendCustomers(mapInfo).Result;
        }

        private static Compliance.Integrations.Contracts.Clientes Persona(Contracts.Emision.MapfreMas quoteInfo, JObject jsonvalues, Contracts.Comun.tercero titular)
        {

            Architect.Compliance.Integrations.Contracts.Clientes mapInfo = new Compliance.Integrations.Contracts.Clientes()
            {
                tipoIdentificacion = titular.DocumentNumberType,
                numeroIdentificacion = titular.DocumentNumber,
                nombreCliente = titular.nombre,
                primerApellido = titular.apellido1,
                segundoApellido = titular.apellido2,
                conocidoComo = String.Empty,
                razonSocial = String.Empty,
                nombreComercial = String.Empty,
                fechaUltimaActualizacion = DateTime.Now,
                descripcionCuenta = titular.nombre.CompleteFullName(titular.apellido1, titular.apellido2),
                numeroIdentificacionEntidad = titular.DocumentNumber,
                fechaNacimiento = titular.fechadenacimiento,
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
            if (titular.numerodetelefono.IsNotEmpty())
            {
                mapInfo.clientesUbicaciones.Add(new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 1,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = titular.numerodetelefono
                });
            }
            if (titular.correoelectronico.IsNotEmpty())
            {
                mapInfo.clientesUbicaciones.Add(new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 3,
                    divisionTerritorial = 99999,
                    descripcionUbicacion = titular.correoelectronico
                });
            }
            if (titular.otrasenas.IsNotEmpty())
            {
                mapInfo.clientesUbicaciones.Add(new Compliance.Integrations.Contracts.Clientesubicacione()
                {
                    tipoUbicacion = 4,
                    divisionTerritorial = titular.TDistrito,
                    descripcionUbicacion = String.Format("{0}, {1}, {2}, {3}. {4}.", titular.TProvinciaDesc, titular.TCantonDesc, titular.TDistritoDesc, titular.otrasenas, "Costa Rica")
                });
            }

            mapInfo.genero = titular.tercerosMca_sexo == 1 ? "M" : "F";
            mapInfo.estadoCivil = titular.estadoCivil;
  

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
                   // prima = (int)quoteInfo.DatosEconomicos.annualnetpremium,
                    estado="A",
                    //faltaban
                    tipoPrima = "A",
                    tipoPoliza= "C",
                    tipoProducto = 302,


                }
            };
            if (quoteInfo.DatosEconomicos != null)
            {
                mapInfo.clientesPolizas[0].prima = (int)quoteInfo.DatosEconomicos.annualgrosspremium;
            }



            return mapInfo;
        }

        private static Compliance.Integrations.Contracts.Clientes Juridico(Contracts.Emision.MapfreMas quoteInfo, JObject jsonvalues)
        {
            Architect.Compliance.Integrations.Contracts.Clientes mapInfo = new Compliance.Integrations.Contracts.Clientes()
            {
                tipoIdentificacion = jsonvalues.TokenInt32Value("tipodecedulajuridicaJur"),
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

            mapInfo.genero = "X";
            mapInfo.estadoCivil = "X";


            mapInfo.paisOrigen = jsonvalues.TokenInt32Value("paisdeconstitucionJur");
            mapInfo.actividadEconomica = 8397;

            mapInfo.articulo15 = jsonvalues.TokenStringValue("actividadesart15Jur") == "1" ? "S" : "N";
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



            mapInfo.clientesPolizas = new List<Compliance.Integrations.Contracts.Clientespoliza>()
            {
                new Compliance.Integrations.Contracts.Clientespoliza()
                {
                    numeroPoliza = quoteInfo.num_poliza,
                    descripcionPoliza = "MapfreMas",
                    fechaInicio = quoteInfo.fec_efec_poliza,
                    fechaFinalizacion = quoteInfo.fec_vcto_poliza,
                    moneda  = quoteInfo.cod_mon,
                   // prima = (int)quoteInfo.DatosEconomicos.annualnetpremium,
                    estado="A",
                    //faltaban
                    tipoPrima = "A",
                    tipoPoliza= "C",
                    tipoProducto = 302,


                }
            };
            if (quoteInfo.DatosEconomicos != null)
            {
                mapInfo.clientesPolizas[0].prima = (int)quoteInfo.DatosEconomicos.annualgrosspremium;
            }

            mapInfo.clientesSocios = new List<Clientessocio>();

            JArray participacionaccionaria = (JArray)jsonvalues["participacionaccionariaJur"];
            foreach (JObject item in participacionaccionaria)
            {

                mapInfo.clientesSocios.Add(new Clientessocio()
                {
                    tipoIdentificacionSocio=1,
                    nombre = item.TokenStringValue("participacionaccionariaNombrecompletoJur"),
                    numeroIdentificacionSocio = item.TokenStringValue("participacionaccionariaNumerodeidentificacionJur"),
                    participacion = item.TokenInt32Value("porcentajedeparticipacionJur"),
                    esPep = "N",
                    tipoPep = "N",
                    descripcionPep = "No aplica",
                    genero = "N",
                    articulo15= "N",
                    estadoCivil="X",
                    fechaNacimiento = new DateTime(1900, 1, 1)
                });

            }

            return mapInfo;
        }

    }
}
