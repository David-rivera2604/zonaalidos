using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.API.Tron.Business.Ramo
{
    public class Configuracion
    {

        /// <summary>
        /// Recupera un registro en la tabla A1001800 por medio del código del ramo.
        /// </summary>
        /// <param name="cod_ramo">Ramo.</param>
        /// <returns>Instancia de A1001800</returns>
        public static Contracts.Ramo.A1001800 Retrieve(int cod_ramo)
        {
            string key = $"tron.ramo.{cod_ramo}";
            Contracts.Ramo.A1001800 ramo = null;
            if (Utilities.Cache.Exist(key))
            {
                ramo = Newtonsoft.Json.JsonConvert.DeserializeObject<Contracts.Ramo.A1001800>((string)Utilities.Cache.GetItem(key));
            }
            else
            {
                int companyId = Int32.Parse(ConfigurationManager.AppSettings["Mapfre.Tron.cod_cia"]);
                int cod_modalidad = Convert.ToInt32(ConfigurationManager.AppSettings["Mapfre.Tron.cod_modalidad"]);
                using (IDbConnection currentConnection = Architect.DataFactory.Database.OpenConnection("Tron"))
                {
                    ramo = DataAccess.Ramo.A1001800.Retrieve(companyId, cod_ramo, currentConnection);

                    if (ramo != null)
                    {
                        ramo.Coberturas = DataAccess.Ramo.A1002150.Retrieve(companyId, cod_ramo, cod_modalidad, currentConnection);
                        ramo.DesglosePorCobertura = DataAccess.Ramo.G2000180.Retrieve(companyId, cod_ramo, cod_modalidad, currentConnection);
                        ramo.Desgloses = DataAccess.Ramo.G2000170.Retrieve(companyId, cod_ramo, cod_modalidad, currentConnection);
                        ramo.DatosVariables = DataAccess.Ramo.G2000020.Retrieve(companyId, cod_ramo, currentConnection);
                        ramo.DatosVariablesGenericos = DataAccess.Ramo.G2000010.Retrieve(companyId, cod_ramo, currentConnection);

                        List<Contracts.Ramo.G2000020> datoList = new List<Contracts.Ramo.G2000020>();
                        foreach (Contracts.Ramo.G2000020 item in ramo.DatosVariables.OrderByDescending(r=> r.FEC_VALIDEZ))
                        {
                            if (!datoList.Any(r => r.COD_CAMPO == item.COD_CAMPO ))
                            {
                                datoList.Add(item);
                            } else
                            {

                            }
                        }
                        ramo.DatosVariables = datoList;


                        List<Contracts.Ramo.A1002150> coverList = new List<Contracts.Ramo.A1002150>();
                        foreach (Contracts.Ramo.A1002150 item in ramo.Coberturas.OrderByDescending(r => r.FEC_VALIDEZ))
                        {
                            if (!coverList.Any(r => r.COD_COB == item.COD_COB))
                            {
                                coverList.Add(item);
                            }
                        }
                        ramo.Coberturas = coverList;
                    }

                    currentConnection.Close();
                }
                if (ramo != null)
                {

                    //Utilities.SerializeHandler<Contracts.Ramo.A1001800>.SerializeJSONToFile(ramo, string.Format($"c:\temp\tron.ramo.{cod_ramo}.json"), true, false, false);
                    //Utilities.SerializeHandler<Contracts.Ramo.A1001800>.SerializeToFile(ramo, string.Format($"c:\temp\tron.ramo.{cod_ramo}.xml"));

                    Utilities.Cache.SetItem(key, Newtonsoft.Json.JsonConvert.SerializeObject(ramo));
                }
            }
            return ramo;
        }

    }
}
