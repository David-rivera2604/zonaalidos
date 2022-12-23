using Architect.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Extend.Integrations.GastosMedicos
{

    /// <summary>
    /// Consultas de asegurados en Gastos Medicos Panama y Medical CR
    /// </summary>
    public static class ConsultaAsegurado
    {

        /// <summary>
        /// Permite recuperar la información personal de un cliente por medio de su identificación.
        /// </summary>
        /// 
        /// url: https://app1.mapfre.com.pa/panama/webapi/
        /// </remarks>
        public async static Task<Architect.API.Insurance.Contracts.GastosMedicos.AseguradoGastosMedicos> PersonaPorIdentificacion(string cedula)
        {
            string token = string.Empty;
            string resultResponse = string.Empty;
            API.Insurance.Contracts.GastosMedicos.AseguradoGastosMedicos resultado = new API.Insurance.Contracts.GastosMedicos.AseguradoGastosMedicos();

            try
            {
                var responsetoken = new HttpResponseMessage();
                
                //Genera Token
                using (var httpClient_token = new HttpClient())
                {
                    httpClient_token.DefaultRequestHeaders.Add("tipo_validacion", "PASSWORD");
                    httpClient_token.BaseAddress = new Uri("https://app1.mapfre.com.pa/panama/webapi/token");
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("Username", "V1NfQ09TVEFSSUNB"),
                        new KeyValuePair<string, string>("Password", "ckw0Z3p0ZkIyZVpLU3Qycg=="),

                    });

                     responsetoken =  await httpClient_token.PostAsync(httpClient_token.BaseAddress, content);
                }

                if (responsetoken.IsSuccessStatusCode)
                {
                    resultResponse = responsetoken.Content.ReadAsStringAsync().Result;

                    if (resultResponse.IsNotEmpty())
                    {
                        JObject jsonvalues = JObject.Parse(resultResponse);

                        if (jsonvalues.SelectToken("access_token") != null)
                        {

                            token = jsonvalues.SelectToken("token_type").Value<string>() + " " + jsonvalues.SelectToken("access_token").Value<string>();
                   
                        }
                    }
                }

                //Consulta carnetDigitalInfo Panama
                var json = JsonConvert.SerializeObject(new { identificacion = cedula, pais = "506" });
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                

                HttpClient client = new HttpClient() { Timeout = new TimeSpan(0, 0, 2) };
                client.DefaultRequestHeaders.Add("Authorization", token);

                var response = await client.PostAsync("https://app1.mapfre.com.pa/panama/webapi/api/apiexterno/carnetDigitalInfo", data).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    resultResponse = response.Content.ReadAsStringAsync().Result;

                    if (resultResponse != "[]")
                    {
                        List<API.Insurance.Contracts.GastosMedicos.AseguradoGastosMedicos> resultado_list = new List<API.Insurance.Contracts.GastosMedicos.AseguradoGastosMedicos>();
                        resultado_list = JsonConvert.DeserializeObject<List<API.Insurance.Contracts.GastosMedicos.AseguradoGastosMedicos>>(resultResponse);

                        resultado = resultado_list[0];
                    }
                }

                //Sino lo encuentra en Panama, busca asegurado en Medical 

                if (resultado.nombre == null)
                { 
                    HttpClient client_medical = new HttpClient() { Timeout = new TimeSpan(0, 0, 5) };
                    var response_medical = await client.GetAsync("https://www.mapfrecr.com/apps/service.svc/REST/InformacionAsegurado?identificacionAsegurado="+ cedula +"&clave=12345678901234567890").ConfigureAwait(false);

                    if (response_medical.IsSuccessStatusCode)
                    {
                        resultResponse = response_medical.Content.ReadAsStringAsync().Result;

                        if (resultResponse.IsNotEmpty())
                        {
                            API.Insurance.Contracts.GastosMedicos.AseguradoGastosMedicosMD result_md = new API.Insurance.Contracts.GastosMedicos.AseguradoGastosMedicosMD();
                            result_md = JsonConvert.DeserializeObject <API.Insurance.Contracts.GastosMedicos.AseguradoGastosMedicosMD>(resultResponse);
                            List <API.Insurance.Contracts.GastosMedicos.Dependientes> dependientes_list  = new List<API.Insurance.Contracts.GastosMedicos.Dependientes>();
                            List<API.Insurance.Contracts.GastosMedicos.Beneficios> beneficios_list = new List<API.Insurance.Contracts.GastosMedicos.Beneficios>();


                            if (result_md.Asegurado != null)
                            {
                                resultado.nombre = result_md.Asegurado.Nombres;
                                resultado.apellido = "";
                                resultado.poliza = result_md.Asegurado.NumeroDePoliza;
                                resultado.certificado = result_md.Asegurado.NumeroDeCertificado;
                                resultado.fechaInicioVigencia = result_md.Asegurado.FechaDeEfectividad;
                                resultado.fechaFinVigencia = result_md.Asegurado.FechaFinVigencia;
                                resultado.fechaIngreso = "";
                                resultado.fechaExclusion = result_md.Asegurado.FechaExclusion;

                                if (result_md.Dependientes != null)
                                {

                                    foreach (API.Insurance.Contracts.GastosMedicos.DependientesMD dependientes_md in result_md.Dependientes)
                                    {
                                        API.Insurance.Contracts.GastosMedicos.Dependientes dependientes = new API.Insurance.Contracts.GastosMedicos.Dependientes();
                                        dependientes.identificacion = dependientes_md.Identificacion;
                                        dependientes.nombre = dependientes_md.Nombres;
                                        dependientes.fechaNacimiento = "";

                                        dependientes_list.Add(dependientes);
                                    }

                                    resultado.dependientes = dependientes_list;

                                }
                                
                                //Se llena listado de beneficios
                                  String[] beneficios = { "CONSULTA GENERAL - ESPECIALISTA: LIMITE MAXIMO HASTA ₵50.400 CO-PAGO 20%",
                                                          "URGENCIAS: CO-PAGO 25%",
                                                          "LABORATORIOS Y RAYOS X:  CO-PAGO 20%",
                                                          "MEDICAMENTOS: POR REEMBOLSO"
                                                         };

                                for (int benef = 0; benef < beneficios.Length; benef++)
                                {
                                    API.Insurance.Contracts.GastosMedicos.Beneficios beneficio = new API.Insurance.Contracts.GastosMedicos.Beneficios();
                                    beneficio.benef = beneficios[benef];
                                    
                                    beneficios_list.Add(beneficio);
                                }

                                resultado.beneficios = beneficios_list;

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Data.Add("resultResponse", resultResponse);
                Architect.Utilities.Log.ErrorLog("GastosMedicos.PersonaPorIdentificacion",
                                                         string.Format("Falla al tratar de consultar a identificación '{0}'", cedula),
                                                         ex, "integrations");
            }
            return resultado;
        }
    }
}
