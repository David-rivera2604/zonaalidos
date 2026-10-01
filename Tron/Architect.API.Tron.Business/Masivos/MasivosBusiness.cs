using Architect.API.Tron.Contracts.Masivos;
using System;
using System.Collections.Generic;

namespace Architect.API.Tron.Business.Masivos
{
    /// <summary>
    /// Orquestador de procesos de carga masiva.
    /// </summary>
    public static class MasivosBusiness
    {
        public static IDictionary<int, string> EA_COTIZA = new Dictionary<int, string>
        {
            {302, "EA_EMISION_302" },
            {207, "ED_EMISION_207" },
            {202, "ED_EMISION_202" },
            {201, "ED_EMISION_201" },
        };

        /// <summary>
        /// Registra un archivo CSV como una nueva carga masiva.
        /// </summary>
        /// <param name="codRamo">Código de ramo asociado al archivo.</param>
        /// <param name="fileName">Nombre del archivo cargado.</param>
        /// <param name="fileBytes">Contenido binario del archivo.</param>
        /// <param name="fileSize">Tamaño del archivo en bytes.</param>
        /// <param name="codUsr">Código del usuario que ejecuta la carga.</param>
        /// <returns>Resultado de la operación de carga.</returns>
        public static MasivoResult Cargar(int codRamo, string fileName, byte[] fileBytes, int fileSize, int codUsr)
        {
            MasivoResult result = new MasivoResult();

            try
            {
                if (!EA_COTIZA.ContainsKey(codRamo)) throw new NotImplementedException("Codigo del ramo no existe");

                string codEstructura = EA_COTIZA[codRamo];

                MasivoCarga carga = new MasivoCarga
                {
                    cod_cia = 1,
                    cod_ramo = codRamo,
                    cod_estructura = codEstructura,
                    txt_archivo_carga = fileName,
                    num_tam_archivo = fileSize,
                    archivo_carga = fileBytes,
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
        /// Consulta las cargas masivas registradas para un usuario y compañía.
        /// </summary>
        /// <param name="codUsr">Código del usuario que ejecuta la consulta.</param>
        /// <param name="codCia">Código de compañía a filtrar (opcional).</param>
        /// <returns>Lista de cargas masivas encontradas.</returns>
        public static List<MasivoCarga> Consultar(int codUsr, int? codCia = null)
        {
            List<MasivoCarga> result = new List<MasivoCarga>();

            try
            {
                result = DataAccess.Masivos.MasivosDataAccess.Consultar(codCia, codUsr);
            }
            catch (Exception ex)
            {
                Utilities.Log.ErrorLog("Masivos.Consultar", ex.Message, "MasivosBusiness.Consultar");
            }

            return result;
        }

        /// <summary>
        /// Valida el archivo de carga masiva indicado.
        /// </summary>
        /// <param name="id">Identificador del registro de carga a validar.</param>
        /// <param name="codUsr">Código del usuario que ejecuta la validación.</param>
        /// <returns>Resultado de la validación.</returns>
        public static MasivoResult Validar(int id, int codUsr)
        {
            MasivoResult result = new MasivoResult();

            try
            {
                int numProceso = DataAccess.Masivos.MasivosDataAccess.Validar(id);
                result.Exitoso = numProceso > 0;
                result.Mensaje = result.Exitoso ? "Archivo validado correctamente." : "No fue posible validar el archivo.";
            }
            catch (Exception ex)
            {
                result.Exitoso = false;
                result.Mensaje = "Error al validar la carga masiva.";
                result.Errores.Add(ex.Message);
                Utilities.Log.ErrorLog("Masivos.Validar", ex.Message, "MasivosBusiness.Validar");
            }

            return result;
        }

        /// <summary>
        /// Procesa el archivo de carga masiva indicado por su identificador.
        /// </summary>
        /// <param name="id">Identificador del registro de carga a procesar.</param>
        /// <param name="codUsr">Código del usuario que ejecuta el procesamiento.</param>
        /// <returns>Resultado del procesamiento.</returns>
        public static MasivoResult Procesar(int id, int codUsr)
        {
            MasivoResult result = new MasivoResult();

            try
            {
                string mensaje;
                int numProceso = DataAccess.Masivos.MasivosDataAccess.Procesar(id, out mensaje);
                result.Exitoso = numProceso > 0;
                result.Mensaje = !string.IsNullOrEmpty(mensaje)
                    ? mensaje
                    : (result.Exitoso ? "Procesamiento ejecutado correctamente." : "No fue posible procesar la carga masiva.");
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

        /// <summary>
        /// Procesa una carga masiva a partir del ramo y el nombre del archivo, retornando el detalle de errores.
        /// </summary>
        /// <param name="codRamo">Código de ramo asociado al archivo.</param>
        /// <param name="fileName">Nombre del archivo de carga a procesar.</param>
        /// <returns>Resultado del procesamiento con el detalle de errores.</returns>
        public static MasivoResult Procesar(int codRamo, string fileName)
        {
            MasivoResult result = new MasivoResult();

            try
            {
                if (!EA_COTIZA.ContainsKey(codRamo)) throw new NotImplementedException("Codigo del ramo no existe");

                string codEstructura = EA_COTIZA[codRamo];
                result = DataAccess.Masivos.MasivosDataAccess.Procesar(1, codRamo, codEstructura, fileName);
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

        /// <summary>
        /// Actualiza el archivo de carga de un registro masivo existente.
        /// </summary>
        /// <param name="id">Identificador del registro a actualizar.</param>
        /// <param name="fileName">Nombre del nuevo archivo de carga.</param>
        /// <param name="fileBytes">Contenido binario del nuevo archivo.</param>
        /// <param name="fileSize">Tamaño del nuevo archivo en bytes.</param>
        /// <param name="codUsr">Código del usuario que ejecuta la actualización.</param>
        /// <returns>Resultado de la actualización.</returns>
        public static MasivoResult ActualizarArchivo(int id, string fileName, byte[] fileBytes, int fileSize, int codUsr)
        {
            MasivoResult result = new MasivoResult();

            try
            {
                bool exito = DataAccess.Masivos.MasivosDataAccess.UpdateArchivoCarga(id, fileBytes, fileSize, codUsr);
                result.Exitoso = exito;
                result.Mensaje = exito ? "Archivo actualizado correctamente." : "No se pudo actualizar el archivo.";
            }
            catch (Exception ex)
            {
                result.Exitoso = false;
                result.Mensaje = "Error al actualizar el archivo.";
                result.Errores.Add(ex.Message);
                Utilities.Log.ErrorLog("Masivos.ActualizarArchivo", ex.Message, "MasivosBusiness.ActualizarArchivo");
            }

            return result;
        }
    }
}
