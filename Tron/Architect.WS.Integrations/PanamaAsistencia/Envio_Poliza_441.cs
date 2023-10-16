using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Architect.WS.Integrations.wsWarranty4;

namespace Architect.WS.Integrations.PanamaAsistencia
{
    public static class Envio_Poliza_441
    {
        //Autenticacion
        public static string login(string user, string pass)
        {
            string xml_result;
            string token;

            try
            {
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.Login login = new API.Tron.Contracts.Integraciones.PanamaAsistencia.Login();

                login.user = user;
                login.pass = EncSHA512(pass);
                login.country = 45;
                login.remote_addr = "";

                wsWarranty4SoapClient ws = new wsWarranty4SoapClient();
                ws.Open();
                var result = ws.login(login.user, login.pass, login.country, login.remote_addr);
                ws.Abort();

                xml_result = result.Rows[0]["description"].ToString();

                //lectura del xml de resultado 
                if (xml_result.Contains("token"))
                {
                    xml_result = result.Rows[0]["description"].ToString();
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(xml_result);
                    XmlNodeList elemlist = xml.GetElementsByTagName("token");
                    token = elemlist[0].InnerXml;

                }
                else
                {
                    token = xml_result;
                }

                return token;
            }
            catch (Exception ex)
            {
                return token = ex.Message;  //throw new FaultException(ex.Message);
            }

        }

        private static string EncSHA512(string StrValue)
        {
            string PwdClient = string.Empty;
            PwdClient = StrValue.PadRight(30, '\0');
            return GenerateSHA512String(PwdClient);

        }


        private static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        //Envio de la Poliza
        

        public static string envio_XML(string token, Architect.API.Tron.Contracts.Emision.Viajero quoteInfo,  Architect.API.Tron.Contracts.Emision.Viajero resultQuoteInfo, string dealer)
        {
            string xml = "";
            string resultado = "";
            string xml_result;

          try { 

            //Numero de Dias
            TimeSpan difFechas = quoteInfo.fec_vcto_poliza - quoteInfo.fec_efec_poliza;
            int dias = difFechas.Days + 1;

            //PolicyData
            Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.PolicyData policyData = new Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.PolicyData()
            {

                ContratoReplicadoV2 = "0",
                TxtPrecioBrutoTotal = "",
                TxtNpoliza = "AUTO",
                TipoPagador = "", // Cuando es mismo tomador asegurado 1 , cuando son diferentes 0
                TxtFhInicio = quoteInfo.fec_efec_poliza.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                TxtFhFin = quoteInfo.fec_vcto_poliza.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                TxtProducto = "",
                TxtDivisaProducto = "",
                IdRegProducto = "",
                TxtComentario = "",
                IdRegFranquicia = "-1",
                IdRegDivisaProducto = "-1",
                IdRegRegion = "-1",
                TxtFHExpiracion = quoteInfo.fec_vcto_poliza.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                IdRegProductoComisionVariable = "",
                TxtCodDealer = dealer,//"DL0001S", //Ligado al usuario en este caso se tiene monge por default
                TxtFhCambioDivisa = "",
                TxtCodPromocion = "",
                TxtSufijo = "PTRI",
                TxtDuracion = Convert.ToString(dias)
            };

            string cedula_tomador="";
            string cedula_asegurado="";

            //Se recorre la lista de terceros para tomar cedula de tomador y asegurado
            foreach (Architect.API.Tron.Contracts.Comun.tercero terceros in quoteInfo.terceros)
            {
               //tomador
                if (terceros.tipodetercero == 0)
                {
                    cedula_tomador = terceros.DocumentNumber;
                }
                //asegurado
                if (terceros.tipodetercero == 2)
                {
                    cedula_asegurado = terceros.DocumentNumber;
                }
            }
            // Se valida si son iguales y se asigna el valor de 
            if (cedula_tomador == cedula_asegurado)
            {
                policyData.TipoPagador = "1";
            }
            else
            {
                policyData.TipoPagador = "0";
            }

            //Codigo de Producto
            switch (quoteInfo.COD_MODALIDAD)
            {
                case 44110: // BRONCE
                    if (quoteInfo.TIP_PLAN == "F")                              // FAMILIAR
                    {
                        policyData.TxtProducto = "PTRI21CR2100000000020BF";
                        policyData.IdRegProducto = "1071";

                        if (quoteInfo.TIP_VIAJE == "N") // Nacional
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020N";
                            policyData.IdRegProducto = "1127";
                        }
                    }
                    else                                                        // INDIVIDUAL - TERCERO
                    {
                        if (quoteInfo.TIP_VIAJE == "R") //Receptivo
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020BR";
                            policyData.IdRegProducto = "1114";
                        }
                        else if (quoteInfo.TIP_VIAJE == "E") // Estudio
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020BE";
                            policyData.IdRegProducto = "1108";
                        }
                        else if (quoteInfo.TIP_VIAJE == "P")  // Placer -
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020B";
                            policyData.IdRegProducto = "1065";
                        }
                        else   // Nacional
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020N";
                            policyData.IdRegProducto = "1127";
                        }

                    }
                   
                break;
                case 44111: //BRONCE PLUS
                    if (quoteInfo.TIP_PLAN == "F")                              // FAMILIAR
                    {
                        policyData.TxtProducto = "PTRI21CR2100000000020BPF";
                        policyData.IdRegProducto = "1070";

                        if (quoteInfo.TIP_VIAJE == "N") // Nacional
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020N";
                            policyData.IdRegProducto = "1127";
                        }
                    }
                    else                                                        // INDIVIDUAL - TERCERO
                    {
                        if (quoteInfo.TIP_VIAJE == "R") //Receptivo
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020BPR";
                            policyData.IdRegProducto = "1113";
                        }
                        else if (quoteInfo.TIP_VIAJE == "E") // Estudio
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020BPE";
                            policyData.IdRegProducto = "1107";
                        }
                        else if (quoteInfo.TIP_VIAJE == "P")  // Placer 
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020BP";
                            policyData.IdRegProducto = "1064";
                        }
                        else // Nacional
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020N";
                            policyData.IdRegProducto = "1127";
                        }

                    }
                    break;
                case 44112: // SILVER PLUS
                    if (quoteInfo.TIP_PLAN == "F")                              // FAMILIAR
                    {
                        policyData.TxtProducto = "PTRI21CR2100000000020SPF";
                        policyData.IdRegProducto = "1069";

                        if (quoteInfo.TIP_VIAJE == "N") // Nacional
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020N";
                            policyData.IdRegProducto = "1127";
                        }
                    }
                    else                                                        // INDIVIDUAL - TERCERO
                    {
                        if (quoteInfo.TIP_VIAJE == "R") //Receptivo
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020SPR";
                            policyData.IdRegProducto = "1112";
                        }
                        else if (quoteInfo.TIP_VIAJE == "E") // Estudio
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020SPE";
                            policyData.IdRegProducto = "1106";
                        }
                        else if (quoteInfo.TIP_VIAJE == "P")  // Placer 
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020SP";
                            policyData.IdRegProducto = "1063";
                        }
                        else // Nacional
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020N";
                            policyData.IdRegProducto = "1127";
                        }

                    }
                    break;
                case 44113: // GOLD pLUS
                    if (quoteInfo.TIP_PLAN == "F")                              // FAMILIAR
                    {
                        policyData.TxtProducto = "PTRI21CR2100000000020GPF";
                        policyData.IdRegProducto = "1068";

                        if (quoteInfo.TIP_VIAJE == "N") // Nacional
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020N";
                            policyData.IdRegProducto = "1127";
                        }
                    }
                    else                                                        // INDIVIDUAL - TERCERO
                    {
                        if (quoteInfo.TIP_VIAJE == "R") //Receptivo
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020GPR";
                            policyData.IdRegProducto = "1111";
                        }
                        else if (quoteInfo.TIP_VIAJE == "E") // Estudio
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020GPE";
                            policyData.IdRegProducto = "1105";
                        }
                        else if (quoteInfo.TIP_VIAJE == "P")  // Placer 
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020GP";
                            policyData.IdRegProducto = "1062";
                        }
                        else // Nacional
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020N";
                            policyData.IdRegProducto = "1127";
                        }

                    }
                    break;
                case 44114: // PLATINUM PLUS
                    if (quoteInfo.TIP_PLAN == "F")                              // FAMILIAR
                    {
                        policyData.TxtProducto = "PTRI21CR2100000000020PPF";
                        policyData.IdRegProducto = "1067";

                        if (quoteInfo.TIP_VIAJE == "N") // Nacional
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020N";
                            policyData.IdRegProducto = "1127";
                        }
                    }
                    else                                                        // INDIVIDUAL - TERCERO
                    {
                        if (quoteInfo.TIP_VIAJE == "R") //Receptivo
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020PPR";
                            policyData.IdRegProducto = "1110";
                        }
                        else if (quoteInfo.TIP_VIAJE == "E") // Estudio
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020PPE";
                            policyData.IdRegProducto = "1104";
                        }
                        else if (quoteInfo.TIP_VIAJE == "P")  // Placer 
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020PP";
                            policyData.IdRegProducto = "1061";
                        }
                        else // Nacional
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020N";
                            policyData.IdRegProducto = "1127";
                        }

                    }
                    break;
                case 44115: // PREMIUM
                    if (quoteInfo.TIP_PLAN == "F")                              // FAMILIAR
                    {
                        policyData.TxtProducto = "PTRI21CR2100000000020PF";
                        policyData.IdRegProducto = "1066";

                        if (quoteInfo.TIP_VIAJE == "N") // Nacional
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020N";
                            policyData.IdRegProducto = "1127";
                        }
                    }
                    else                                                        // INDIVIDUAL - TERCERO
                    {
                        if (quoteInfo.TIP_VIAJE == "R") //Receptivo
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020PR";
                            policyData.IdRegProducto = "1109";
                        }
                        else if (quoteInfo.TIP_VIAJE == "E") // Estudio
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020PE";
                            policyData.IdRegProducto = "1103";
                        }
                        else if (quoteInfo.TIP_VIAJE == "P")  // Placer 
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020P";
                            policyData.IdRegProducto = "1048";
                        }
                        else // Nacional
                        {
                            policyData.TxtProducto = "PTRI21CR2100000000020N";
                            policyData.IdRegProducto = "1127";
                        }

                    }
                    break;
           
            }

            //RiskData
            Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.RiskData riskData = new Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.RiskData()
            {
                CMBDESTINOSV = "2",
                txtPaisDestino = ConverTOIso2_Pais(quoteInfo.DES_DESTINO),
                txtAttribute1 = "",//beneficiario
                txtAttribute2 = "",//beneficiario
                txtAttribute3 = "",//beneficiario
                txtCodigoFipe = "",//cedula
                txtNotaFiscal = "",//cedula
                txtDetalleVehiculo = "",//cedula
                txtAttribute014 = "",//porcentaje
                txtAttribute015 = "",//porcentaje
                txtAttribute016 = "",//porcentaje
                txtAttribute010 = "",//Parentezco
                txtAttribute011 = "",//Parentezco
                txtAttribute012 = "",//Parentezco
            };

            //Se recorre la lista de terceros para tomar los beneficiarios
            int cant_benef = 0;
            foreach (Architect.API.Tron.Contracts.Comun.tercero terceros in quoteInfo.terceros)
            {
                if (terceros.tipodetercero == 6)
                {
                    cant_benef++;

                    switch (cant_benef)
                    {
                        case 1:
                            riskData.txtAttribute1 = terceros.nombre + " " + terceros.apellido1 +" "+ terceros.apellido2;
                            riskData.txtCodigoFipe = terceros.DocumentNumber;
                            riskData.txtAttribute014 =  Convert.ToString(terceros.porcentaje);
                            riskData.txtAttribute010 = Convert.ToString(terceros.parentescoDesc);
                        break;
                        case 2:
                            riskData.txtAttribute2 = terceros.nombre + " " + terceros.apellido1 + " " + terceros.apellido2;
                            riskData.txtNotaFiscal = terceros.DocumentNumber;
                            riskData.txtAttribute015 = Convert.ToString(terceros.porcentaje);
                            riskData.txtAttribute011 = Convert.ToString(terceros.parentescoDesc);
                            break;
                        case 3:
                            riskData.txtAttribute3 = terceros.nombre + " " + terceros.apellido1 + " " + terceros.apellido2;
                            riskData.txtDetalleVehiculo = terceros.DocumentNumber;
                            riskData.txtAttribute016 = Convert.ToString(terceros.porcentaje);
                            riskData.txtAttribute012 = Convert.ToString(terceros.parentescoDesc);
                            break;

                    }
                }
            }

            // InsuredData
            List<Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.InsuredData > list_insured_data = new List<Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.InsuredData>();
            
            foreach ( Architect.API.Tron.Contracts.Comun.tercero terceros in quoteInfo.terceros)
            {
                Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.InsuredData insuredData = new Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.InsuredData();

                if (terceros.tipodetercero == 2 || (terceros.tipodetercero == 0 && terceros.eltomadoreselmismoasegurado == 1))
                {
                    //Edad 
                    DateTime nacimiento = terceros.fechadenacimiento; //Fecha de nacimiento
                    int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;

                    insuredData.TxtNmAsegurado = terceros.nombre;
                    insuredData.TxtApeAsegurado = terceros.apellido1 + " " + terceros.apellido2;
                    insuredData.TxtIdFiscal = terceros.DocumentNumber.Replace("-","").Substring(1);
                    insuredData.TxtEmail = terceros.correoelectronico;
                    insuredData.TxtFhNacimiento = terceros.fechadenacimiento.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    insuredData.TXTEDADSV = Convert.ToString(edad);
                    insuredData.TxtDirAsegurado = terceros.otrasenas;
                    insuredData.TxtMovil = terceros.numerodetelefono;
                    insuredData.TxtNmPersonaContacto = terceros.nombre + " " + terceros.apellido1 + " " + terceros.apellido2;
                    insuredData.TxtTlfMovilPersonaContacto = terceros.numerodetelefono;

                    switch (terceros.DocumentNumberType)

                    {
                        case 1: //Cedula nacional
                            insuredData.CmbTipoCIF = "2";
                            break;
                        case 2: //Residencia
                            insuredData.CmbTipoCIF = "3";
                            break;
                        case 3: //Pasaporte
                            insuredData.CmbTipoCIF = "1";
                            break;
                    }

                    list_insured_data.Add(insuredData);
                }
            }
            

            // CoberturaLimites
            Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.CoberturaLimites coberturaLimites = new Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.CoberturaLimites()
            {
                chk_AC7_21_10_852 = "",
                chk_AC7_21_10_851 = "",
                chk_AB8_21_10_980 = "",
                chk_AB8_21_10_921 = "",
                chk_AB8_21_10_714 = "",
                chk_AB8_21_10_701 = "",
                chk_AB8_21_10_697 = "",
                chk_AC0_21_10_915 = "",
                chk_AC0_21_10_700 = "",
                chk_AC8_21_10_847 = "",
                chk_AC8_21_10_846 = "",
                chk_AC1_21_10_890 = "",
                chk_AC1_21_10_883 = "",
                chk_AC1_21_10_707 = "",
                chk_AC6_21_10_856 = "",
                chk_AC6_21_10_712 = "",
                chk_AC3_21_10_711 = "",
                chk_AC2_21_10_710 = "",
                chk_AB9_21_10_979 = "",
                chk_AB9_21_10_695 = "",
                chk_AB9_21_10_694 = "",
                chk_AC4_21_10_699 = "",
            };

            // CoberData
            Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.CoberData coberData = new Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.CoberData()
            {
                chk_AC7_21_10 = "1",
                chk_AB8_21_10 = "1",
                chk_AC0_21_10 = "1",
                chk_AC8_21_10 = "1",
                chk_AC1_21_10 = "1",
                chk_AC6_21_10 = "1",
                chk_AC3_21_10 = "1",
                chk_AC2_21_10 = "1",
                chk_AB9_21_10 = "1",
                chk_AC4_21_10 = "1",
                CoberturaLimites = coberturaLimites
            };

            //TomadorData
            Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.TomadorData TomadorData = new Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.TomadorData();

            foreach (Architect.API.Tron.Contracts.Comun.tercero terceros in quoteInfo.terceros)
            {
                Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.TomadorData tomador_data = new Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.TomadorData();

                if (terceros.tipodetercero == 0 || (terceros.tipodetercero == 2 && terceros.elaseguradoeselmismotomador == 1))
                {
                    tomador_data.TxtNmAsegurado_policyHolder = terceros.nombre;
                    tomador_data.TxtApeAsegurado_policyHolder = terceros.apellido1 + " " + terceros.apellido2;
                    tomador_data.TxtIdFiscal_policyHolder = terceros.DocumentNumber.Replace("-", "").Substring(1);

                    switch (terceros.DocumentNumberType)

                    {
                        case 1: //Cedula nacional
                            tomador_data.CmbTipoCIF_policyHolder = "2";
                            break;
                        case 2: //Residencia
                            tomador_data.CmbTipoCIF_policyHolder = "3";
                            break;
                        case 3: //Pasaporte
                            tomador_data.CmbTipoCIF_policyHolder = "1";
                            break;
                    }

                    TomadorData = tomador_data;
                }
            }

                    //Parameters
                    Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.Parameters parameters = new Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.Parameters()
            {
                OrigenRecepcion = "1",
                NoAceptaOfertasCom = "0",
                PermitirEnvioPublicidad = "-1",
                PermitirVentaDistancia = "-1",
                PermitirEstudioMercado = "-1",
                AdjuntarCondiciones = "1",
                InfoValidada = "1",
                Action = "A",
                EstadoContrato = "1",
                PosicionTomador = "1",
                PosAsegEliminados = "",
                DivisaCobro = "0",
            };

            //Root
            Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.Root root = new Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.Root();

            root.PolicyData = policyData;
            root.RiskData = riskData;
            root.InsuredData = list_insured_data;
            root.CoberData = coberData;
            root.EcasData = "";
            root.TomadorData = TomadorData;
            root.Parameters = parameters;

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(root.GetType());

            using (var stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(root.GetType());
                serializer.Serialize(stringwriter, root);
                xml = stringwriter.ToString();
            }

            //Llamado a Web Service Panama
            wsWarranty4SoapClient ws = new wsWarranty4SoapClient();
            ws.Open();
            var respuesta = ws.issuing(token, xml);
            ws.Abort();

            //lectura del xml de resultado 
            resultado = respuesta.Rows[0]["description"].ToString();

            if (resultado.Contains("<file>"))
            {
                int charPos = resultado.IndexOf("<file>") + 6;
                resultado = resultado.Substring(charPos);          
                resultado = resultado.Replace("</file>",string.Empty);
            }

                return resultado;
          }

            catch (Exception ex)
            {
                return resultado = ex.Message;  //throw new FaultException(ex.Message);
            }
        }

        private static string ConverTOIso2_Pais(string isoAlpha3Code)
        {
            // Crear un diccionario que mapee códigos alfa-3 a alfa-2
            Dictionary<string, string> isoAlpha3ToAlpha2 = new Dictionary<string, string>
        {
            {"AFG", "AF"},
            {"ALA", "AX"},
            {"ALB", "AL"},
            {"DZA", "DZ"},
            {"ASM", "AS"},
            {"AND", "AD"},
            {"AGO", "AO"},
            {"AIA", "AI"},
            {"ATA", "AQ"},
            {"ATG", "AG"},
            {"ARG", "AR"},
            {"ARM", "AM"},
            {"ABW", "AW"},
            {"AUS", "AU"},
            {"AUT", "AT"},
            {"AZE", "AZ"},
            {"BHS", "BS"},
            {"BHR", "BH"},
            {"BGD", "BD"},
            {"BRB", "BB"},
            {"BLR", "BY"},
            {"BEL", "BE"},
            {"BLZ", "BZ"},
            {"BEN", "BJ"},
            {"BMU", "BM"},
            {"BTN", "BT"},
            {"BOL", "BO"},
            {"BIH", "BA"},
            {"BWA", "BW"},
            {"BVT", "BV"},
            {"BRA", "BR"},
            {"IOT", "IO"},
            {"BRN", "BN"},
            {"BGR", "BG"},
            {"BFA", "BF"},
            {"BDI", "BI"},
            {"KHM", "KH"},
            {"CMR", "CM"},
            {"CAN", "CA"},
            {"CPV", "CV"},
            {"CYM", "KY"},
            {"CAF", "CF"},
            {"TCD", "TD"},
            {"CHL", "CL"},
            {"CHN", "CN"},
            {"CXR", "CX"},
            {"CCK", "CC"},
            {"COL", "CO"},
            {"COM", "KM"},
            {"COG", "CG"},
            {"COD", "CD"},
            {"COK", "CK"},
            {"CRI", "CR"},
            {"CIV", "CI"},
            {"HRV", "HR"},
            {"CUB", "CU"},
            {"CYP", "CY"},
            {"CZE", "CZ"},
            {"DNK", "DK"},
            {"DJI", "DJ"},
            {"DMA", "DM"},
            {"DOM", "DO"},
            {"ECU", "EC"},
            {"EGY", "EG"},
            {"SLV", "SV"},
            {"GNQ", "GQ"},
            {"ERI", "ER"},
            {"EST", "EE"},
            {"ETH", "ET"},
            {"FLK", "FK"},
            {"FRO", "FO"},
            {"FJI", "FJ"},
            {"FIN", "FI"},
            {"FRA", "FR"},
            {"GUF", "GF"},
            {"PYF", "PF"},
            {"ATF", "TF"},
            {"GAB", "GA"},
            {"GMB", "GM"},
            {"GEO", "GE"},
            {"DEU", "DE"},
            {"GHA", "GH"},
            {"GIB", "GI"},
            {"GRC", "GR"},
            {"GRL", "GL"},
            {"GRD", "GD"},
            {"GLP", "GP"},
            {"GUM", "GU"},
            {"GTM", "GT"},
            {"GGY", "GG"},
            {"GIN", "GN"},
            {"GNB", "GW"},
            {"GUY", "GY"},
            {"HTI", "HT"},
            {"HMD", "HM"},
            {"VAT", "VA"},
            {"HND", "HN"},
            {"HKG", "HK"},
            {"HUN", "HU"},
            {"ISL", "IS"},
            {"IND", "IN"},
            {"IDN", "ID"},
            {"IRN", "IR"},
            {"IRQ", "IQ"},
            {"IRL", "IE"},
            {"IMN", "IM"},
            {"ISR", "IL"},
            {"ITA", "IT"},
            {"JAM", "JM"},
            {"JPN", "JP"},
            {"JEY", "JE"},
            {"JOR", "JO"},
            {"KAZ", "KZ"},
            {"KEN", "KE"},
            {"KIR", "KI"},
            {"PRK", "KP"},
            {"KOR", "KR"},
            {"KWT", "KW"},
            {"KGZ", "KG"},
            {"LAO", "LA"},
            {"LVA", "LV"},
            {"LBN", "LB"},
            {"LSO", "LS"},
            {"LBR", "LR"},
            {"LBY", "LY"},
            {"LIE", "LI"},
            {"LTU", "LT"},
            {"LUX", "LU"},
            {"MAC", "MO"},
            {"MKD", "MK"},
            {"MDG", "MG"},
            {"MWI", "MW"},
            {"MYS", "MY"},
            {"MDV", "MV"},
            {"MLI", "ML"},
            {"MLT", "MT"},
            {"MHL", "MH"},
            {"MTQ", "MQ"},
            {"MRT", "MR"},
            {"MUS", "MU"},
            {"MYT", "YT"},
            {"MEX", "MX"},
            {"FSM", "FM"},
            {"MDA", "MD"},
            {"MCO", "MC"},
            {"MNG", "MN"},
            {"MNE", "ME"},
            {"MSR", "MS"},
            {"MAR", "MA"},
            {"MOZ", "MZ"},
            {"MMR", "MM"},
            {"NAM", "NA"},
            {"NRU", "NR"},
            {"NPL", "NP"},
            {"NLD", "NL"},
            {"ANT", "AN"},
            {"NCL", "NC"},
            {"NZL", "NZ"},
            {"NIC", "NI"},
            {"NER", "NE"},
            {"NGA", "NG"},
            {"NIU", "NU"},
            {"NFK", "NF"},
            {"MNP", "MP"},
            {"NOR", "NO"},
            {"OMN", "OM"},
            {"PAK", "PK"},
            {"PLW", "PW"},
            {"PSE", "PS"},
            {"PAN", "PA"},
            {"PNG", "PG"},
            {"PRY", "PY"},
            {"PER", "PE"},
            {"PHL", "PH"},
            {"PCN", "PN"},
            {"POL", "PL"},
            {"PRT", "PT"},
            {"PRI", "PR"},
            {"QAT", "QA"},
            {"REU", "RE"},
            {"ROU", "RO"},
            {"RUS", "RU"},
            {"RWA", "RW"},
            {"SHN", "SH"},
            {"KNA", "KN"},
            {"LCA", "LC"},
            {"SPM", "PM"},
            {"VCT", "VC"},
            {"WSM", "WS"},
            {"SMR", "SM"},
            {"STP", "ST"},
            {"SAU", "SA"},
            {"SEN", "SN"},
            {"SRB", "RS"},
            {"SYC", "SC"},
            {"SLE", "SL"},
            {"SGP", "SG"},
            {"SVK", "SK"},
            {"SVN", "SI"},
            {"SLB", "SB"},
            {"SOM", "SO"},
            {"ZAF", "ZA"},
            {"SGS", "GS"},
            {"SSD", "SS"},
            {"ESP", "ES"},
            {"LKA", "LK"},
            {"SDN", "SD"},
            {"SUR", "SR"},
            {"SJM", "SJ"},
            {"SWZ", "SZ"},
            {"SWE", "SE"},
            {"CHE", "CH"},
            {"SYR", "SY"},
            {"TWN", "TW"},
            {"TJK", "TJ"},
            {"TZA", "TZ"},
            {"THA", "TH"},
            {"TLS", "TL"},
            {"TGO", "TG"},
            {"TKL", "TK"},
            {"TON", "TO"},
            {"TTO", "TT"},
            {"TUN", "TN"},
            {"TUR", "TR"},
            {"TKM", "TM"},
            {"TCA", "TC"},
            {"TUV", "TV"},
            {"UGA", "UG"},
            {"UKR", "UA"},
            {"ARE", "AE"},
            {"GBR", "GB"},
            {"USA", "US"},
            {"UMI", "UM"},
            {"URY", "UY"},
            {"UZB", "UZ"},
            {"VUT", "VU"},
            {"VEN", "VE"},
            {"VNM", "VN"},
            {"VGB", "VG"},
            {"VIR", "VI"},
            {"WLF", "WF"},
            {"ESH", "EH"},
            {"YEM", "YE"},
            {"ZMB", "ZM"},
            {"ZWE", "ZW"},
        };
            // Realiza la conversión
            if (isoAlpha3ToAlpha2.ContainsKey(isoAlpha3Code))
            {
                string isoAlpha2Code = isoAlpha3ToAlpha2[isoAlpha3Code];
                return isoAlpha2Code;
            }
            else
            {
                return isoAlpha3Code;
            }
        }
    
}
}
