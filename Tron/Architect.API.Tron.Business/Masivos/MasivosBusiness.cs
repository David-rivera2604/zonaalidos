using Architect.API.Tron.Contracts.Masivos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architect.API.Tron.Business.Masivos
{
    /// <summary>
    /// Orquestador de procesos de carga masiva.
    /// </summary>
    public static class MasivosBusiness
    {

        public static IDictionary<int, string> EA_COTIZA = new Dictionary<int, string>
        {
            {302,"EA_EMISION_302" },
            {207,"ED_EMISION_207" },
            {202,"ED_EMISION_201" },
            {201,"ED_EMISION_202" },
        };
        /// <summary>
        /// Registra una carga masiva de archivo CSV.
        /// </summary>
        /// <param name="codRamo">Código del ramo seleccionado.</param>
        /// <param name="fileName">Nombre del archivo CSV.</param>
        /// <param name="fileBytes">Contenido binario del archivo.</param>
        /// <param name="fileSize">Tamaño del archivo en bytes.</param>
        /// <param name="codUsr">Código del usuario que realiza la carga.</param>
        /// <returns>Resultado de la operación de carga.</returns>
        public static MasivoResult Cargar(int codRamo, string fileName, byte[] fileBytes, int fileSize, int codUsr)
        {
            MasivoResult result = new MasivoResult();

            try
            {
                if (!EA_COTIZA.ContainsKey(codRamo)) throw new NotImplementedException("Codigo del ramo no existe");
                
                string codEstructura = EA_COTIZA[codRamo];

                string contenidoCsv = Encoding.UTF8.GetString(fileBytes);

                MasivoCarga carga = new MasivoCarga
                {
                    cod_cia = 1,
                    cod_ramo = codRamo,
                    cod_estructura = codEstructura,
                    txt_archivo_carga = fileName,
                    num_tam_archivo = fileSize,
                    archivo_carga = contenidoCsv,
                    cod_usr = codUsr
                };

                int resultado = DataAccess.Masivos.MasivosDataAccess.Insert(carga);

                if (resultado > 0)
                {
                    result.Exitoso = true;
                    result.Mensaje = "Archivo cargado exitosamente.";
                }
                else
                {
                    result.Exitoso = false;
                    result.Mensaje = "No se pudo registrar la carga del archivo. Resultado: " + resultado;
                }
            }
            catch (Exception ex)
            {
                result.Exitoso = false;
                result.Mensaje = "Error al cargar el archivo.";
                result.Errores.Add(ex.Message);
                Utilities.Log.ErrorLog("Masivos.Cargar", ex.Message, "MasivosBusiness.Cargar");
            }

            return result;
        }

        /// <summary>
        /// Consulta las cargas masivas registradas, opcionalmente filtradas por código de ramo.
        /// </summary>
        /// <param name="codRamo">Código del ramo (opcional).</param>
        /// <returns>Lista de cargas registradas.</returns>
        public static List<MasivoCarga> Consultar(int? codRamo)
        {
            List<MasivoCarga> result = new List<MasivoCarga>();

            try
            {
                result = DataAccess.Masivos.MasivosDataAccess.Consultar(codRamo);
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Masivos.Consultar", ex.Message, "MasivosBusiness.Consultar");
            }

            return result;
        }

        /// <summary>
        /// Ejecuta el procesamiento de una carga masiva.
        /// </summary>
        /// <param name="codRamo">Código del ramo.</param>
        /// <param name="fileName">Nombre del archivo a procesar.</param>
        /// <returns>Resultado del procesamiento.</returns>
        public static MasivoResult Procesar(int codRamo, string fileName)
        {
            MasivoResult result = new MasivoResult();

            try
            {
                string codEstructura = string.Format("EA_COTIZA:{0}", codRamo);

                result = DataAccess.Masivos.MasivosDataAccess.Procesar(1, codRamo, codEstructura);
            }
            catch (Exception ex)
            {
                result.Exitoso = false;
                result.Mensaje = "Error al procesar la carga masiva.";
                result.Errores.Add(ex.Message);
                Utilities.Log.ErrorLog("Masivos.Procesar", ex.Message, "MasivosBusiness.Procesar");
            }

            return result;
        }


    }
}
