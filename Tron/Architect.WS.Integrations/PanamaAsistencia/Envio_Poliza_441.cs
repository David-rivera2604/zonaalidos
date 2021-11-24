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

                //lectura del xml de resultado 
                xml_result = result.Rows[0]["description"].ToString();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xml_result);
                XmlNodeList elemlist = xml.GetElementsByTagName("token");
                token = elemlist[0].InnerXml;

                return token;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
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
        

        public static string envio_XML(string token, Architect.API.Tron.Contracts.Emision.Viajero quoteInfo,  Architect.API.Tron.Contracts.Emision.Viajero resultQuoteInfo)
        {
            string xml = "";
            string resultado = "";

            //Numero de Dias
            TimeSpan difFechas = quoteInfo.fec_vcto_poliza - quoteInfo.fec_efec_poliza;
            int dias = difFechas.Days;

            //PolicyData
            Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.PolicyData policyData = new Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.PolicyData()
            {

                ContratoReplicadoV2 = "0",
                TxtPrecioBrutoTotal = "",
                TxtNpoliza = "AUTO",
                TipoPagador = "", // Cuando es mismo tomador asegurado 1 , cuando son diferentes 0
                TxtFhInicio = quoteInfo.fec_efec_poliza.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                TxtFhFin = quoteInfo.fec_vcto_poliza.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                TxtProducto = "PTRI21CR2100000000020P",
                TxtDivisaProducto = "",
                IdRegProducto = "1048",
                TxtComentario = "",
                IdRegFranquicia = "-1",
                IdRegDivisaProducto = "-1",
                IdRegRegion = "-1",
                TxtFHExpiracion = "02/12/2021",
                IdRegProductoComisionVariable = "",
                TxtCodDealer = "DL0001S", //Ligado al usuario en este caso se tiene monge por default
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

            //RiskData
            Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.RiskData riskData = new Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.RiskData()
            {
                CMBDESTINOSV = "2",
                txtPaisDestino = quoteInfo.DES_DESTINO,
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

            // InsuredData
            List<Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.InsuredData > list_insured_data = new List<Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.InsuredData>();
            
            foreach ( Architect.API.Tron.Contracts.Comun.tercero terceros in quoteInfo.terceros)
            {
                Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.InsuredData insuredData = new Architect.API.Tron.Contracts.Integraciones.PanamaAsistencia.InsuredData();

                if (terceros.tipodetercero != 0)
                {
                    //Edad 
                    DateTime nacimiento = terceros.fechadenacimiento; //Fecha de nacimiento
                    int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;

                    insuredData.TxtNmAsegurado = terceros.nombre;
                    insuredData.TxtApeAsegurado = terceros.apellido1 + " " + terceros.apellido2;
                    insuredData.TxtIdFiscal = terceros.DocumentNumber.Replace("-","").Substring(1);
                    insuredData.TxtEmail = terceros.correoelectronico;
                    insuredData.TxtFhNacimiento = terceros.fechadenacimiento.ToString("yyyy-mm-dd", CultureInfo.InvariantCulture);
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

                if (terceros.tipodetercero == 0)
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
 
            return resultado;
        }
      

    }
}
