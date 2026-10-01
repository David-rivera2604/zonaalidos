using Architect.API.Tron.Contracts.Masivos;
using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Masivos
{
    /// <summary>
    /// Acceso a datos para operaciones de carga masiva.
    /// </summary>
    public static class MasivosDataAccess
    {
        /// <summary>
        /// Registra un nuevo archivo de carga masiva en la base de datos.
        /// </summary>
        /// <param name="carga">Datos del archivo de carga a registrar.</param>
        /// <returns>Indicador de registro exitoso (1).</returns>
        public static int Insert(MasivoCarga carga)
        {
            using (IDbConnection currentConnection = Database.OpenConnection("Tron"))
            {
                Database.Procedure("em_k_masivos_mcr.p_insert_masivos")
                    .AddParameter("p_cod_cia", DbType.Int32, 2, carga.cod_cia)
                    .AddParameter("p_cod_ramo", DbType.Int32, 5, carga.cod_ramo)
                    .AddParameter("p_cod_estructura", DbType.String, 100, carga.cod_estructura)
                    .AddParameter("p_txt_archivo_carga", DbType.String, 255, carga.txt_archivo_carga)
                    .AddParameter("p_num_tam_archivo", DbType.Int64, 0, carga.num_tam_archivo)
                    .AddParameter("p_archivo_carga", DbType.Binary, 0, carga.archivo_carga)
                    .AddParameter("p_updateusercode", DbType.Int32, 9, carga.cod_usr)
                    .AddParameter("p_resultado", DbType.Int32, 9, 0, ParameterDirection.Output)
                    .AddParameter("p_id", DbType.Int32, 9, 0, ParameterDirection.Output)
                    .Execute(currentConnection, "Tron");
            }

            return 1;
        }

        /// <summary>
        /// Consulta los registros de carga masiva de una compañía y usuario.
        /// </summary>
        /// <param name="codCia">Código de compañía a filtrar.</param>
        /// <param name="codUsr">Código del usuario que ejecuta la consulta.</param>
        /// <returns>Lista de cargas masivas encontradas.</returns>
        public static List<MasivoCarga> Consultar(int? codCia, int codUsr)
        {
            List<MasivoCarga> result = new List<MasivoCarga>();

            using (IDbConnection currentConnection = Database.OpenConnection("Tron"))
            {
                Database.Procedure("em_k_masivos_mcr.p_lee_masivos")
                    .AddParameter("p_cod_cia", DbType.Int32, 2, codCia)
                    .AddParameter("p_updateusercode", DbType.Int32, 9, codUsr)
                    .AddParameter("rc1", DbType.RefCursor, 0, null, ParameterDirection.Output)
                    .Query(currentConnection, "Tron", new Action<IDataReader, string>((reader, key) =>
                    {
                        if (key == "rc1")
                        {
                            var item = new MasivoCarga
                            {
                                id = reader.IntegerValue("id"),
                                cod_cia = reader.IntegerValue("cod_cia"),
                                cod_ramo = reader.IntegerValue("cod_ramo"),
                                cod_estructura = reader.StringValue("cod_estructura"),
                                txt_archivo_carga = reader.StringValue("txt_archivo_carga"),
                                num_tam_archivo = reader.IntegerValue("num_tam_archivo"),
                                archivo_carga = reader["archivo_carga"] as byte[],
                                txt_archivo_val = reader.StringValue("txt_archivo_val"),
                                num_tam_archivo_val = reader.IntegerValue("num_tam_archivo_val"),
                                archivo_val = reader["archivo_val"] as byte[],
                                txt_archivo_rta = reader.StringValue("txt_archivo_rta"),
                                num_tam_archivo_rta = reader.IntegerValue("num_tam_archivo_rta"),
                                archivo_rta = reader["archivo_rta"] as byte[],
                                cod_usr = reader.IntegerValue("updateusercode"),
                                fec_actu = reader.DateTimeValue("updatedate"),
                                cod_estado = reader.IntegerValue("cod_estado"),
                                estado = reader.StringValue("estado"),
                                num_proceso_val = reader.IntegerValue("num_proceso_val"),
                                num_proceso = reader.IntegerValue("num_proceso")
                            };

                            result.Add(item);
                        }
                    }));
            }

            return result;
        }

        /// <summary>
        /// Ejecuta la validación del archivo de carga masiva indicado.
        /// </summary>
        /// <param name="id">Identificador del registro de carga a validar.</param>
        /// <param name="codUsr">Código del usuario que ejecuta la validación.</param>
        /// <returns>Número de proceso generado por la validación.</returns>
        public static int Validar(int id, int codUsr)
        {
            int numProceso = 0;

            using (IDbConnection currentConnection = Database.OpenConnection("Tron"))
            {
                List<DataFactory.Contracts.Parameter> parameters = Database.ParameterList()
                    .AddParameter("p_id", DbType.Int32, 9, id)
                    .AddParameter("p_updateusercode", DbType.Int32, 9, codUsr)
                    .AddParameter("p_num_proceso", DbType.Int32, 9, 0, ParameterDirection.Output).Parameters;

                Database.Procedure("em_k_masivos_mcr.p_validar_archivo")
                    .AddParameter(parameters)
                    .Execute(currentConnection, "Tron");

                object valor = parameters.Find(p => p.Name == "p_num_proceso").Value;
                if (valor != null && valor != DBNull.Value)
                {
                    int.TryParse(valor.ToString(), out numProceso);
                }
            }

            return numProceso;
        }

        /// <summary>
        /// Ejecuta el procesamiento del archivo de carga masiva indicado.
        /// </summary>
        /// <param name="id">Identificador del registro de carga a procesar.</param>
        /// <param name="codUsr">Código del usuario que ejecuta el procesamiento.</param>
        /// <returns>Número de proceso generado por el procesamiento.</returns>
        public static int Procesar(int id, int codUsr)
        {
            int numProceso = 0;

            using (IDbConnection currentConnection = Database.OpenConnection("Tron"))
            {
                List<DataFactory.Contracts.Parameter> parameters = Database.ParameterList()
                    .AddParameter("p_id", DbType.Int32, 9, id)
                    .AddParameter("p_updateusercode", DbType.Int32, 9, codUsr)
                    .AddParameter("p_num_proceso", DbType.Int32, 9, 0, ParameterDirection.Output).Parameters;

                Database.Procedure("em_k_masivos_mcr.p_procesar_archivo")
                    .AddParameter(parameters)
                    .Execute(currentConnection, "Tron");

                object valor = parameters.Find(p => p.Name == "p_num_proceso").Value;
                if (valor != null && valor != DBNull.Value)
                {
                    int.TryParse(valor.ToString(), out numProceso);
                }
            }

            return numProceso;
        }

        /// <summary>
        /// Actualiza el archivo de carga de un registro masivo existente.
        /// </summary>
        /// <param name="id">Identificador del registro a actualizar.</param>
        /// <param name="fileName">Nombre del nuevo archivo de carga.</param>
        /// <param name="fileBytes">Contenido binario del nuevo archivo.</param>
        /// <param name="fileSize">Tamaño del nuevo archivo en bytes.</param>
        /// <param name="codUsr">Código del usuario que ejecuta la actualización.</param>
        /// <returns>Indicador de actualización exitosa.</returns>
        public static bool UpdateArchivoCarga(int id, string fileName, byte[] fileBytes, int fileSize, int codUsr)
        {
            using (IDbConnection currentConnection = Database.OpenConnection("Tron"))
            {
                Database.Procedure("em_k_masivos_mcr.p_update_archivo_carga")
                    .AddParameter("p_id", DbType.Int32, 9, id)
                    .AddParameter("p_txt_archivo_carga", DbType.String, 255, fileName)
                    .AddParameter("p_num_tam_archivo", DbType.Int32, 9, fileSize)
                    .AddParameter("p_archivo_carga", DbType.Binary, 0, fileBytes)
                    .AddParameter("p_updateusercode", DbType.Int32, 9, codUsr)
                    .Execute(currentConnection, "Tron");
            }

            return true;
        }

        /// <summary>
        /// Ejecuta el procesamiento de un archivo de carga masiva y retorna el detalle de errores.
        /// </summary>
        /// <param name="codCia">Código de compañía.</param>
        /// <param name="codRamo">Código de ramo.</param>
        /// <param name="codEstructura">Código de estructura asociada al ramo.</param>
        /// <param name="txtArchivoCarga">Nombre del archivo de carga a procesar.</param>
        /// <returns>Resultado del procesamiento con el detalle de errores encontrados.</returns>
        public static MasivoResult Procesar(int codCia, int codRamo, string codEstructura, string txtArchivoCarga)
        {
            MasivoResult result = new MasivoResult();

            using (IDbConnection currentConnection = Database.OpenConnection("Tron"))
            {
                Database.Procedure("em_k_masivos_mcr.p_procesar_archivo")
                    .AddParameter("p_cod_cia", DbType.Int32, 2, codCia)
                    .AddParameter("p_cod_ramo", DbType.Int32, 5, codRamo)
                    .AddParameter("p_cod_estructura", DbType.String, 100, codEstructura)
                    .AddParameter("p_txt_archivo_carga", DbType.String, 255, txtArchivoCarga)
                    .AddParameter("rc1", DbType.RefCursor, 0, null, ParameterDirection.Output)
                    .Query(currentConnection, "Tron", new Action<IDataReader, string>((reader, key) =>
                    {
                        if (key == "rc1")
                        {
                            result.Detalles.Add(new Contracts.Masivos.MasivoErrorDetalle
                            {
                                num_proceso = reader.IntegerValue("num_proceso"),
                                cod_estructura = reader.StringValue("cod_estructura"),
                                num_registro = reader.IntegerValue("num_registro"),
                                tip_error = reader.StringValue("tip_error"),
                                txt_error = reader.StringValue("txt_error"),
                                txt_ruta_error = reader.StringValue("txt_ruta_error"),
                                cod_usr = reader.IntegerValue("cod_usr"),
                                fec_actu = reader.DateTimeValue("fec_actu")
                            });
                        }
                    }));
            }

            result.Exitoso = (result.Detalles.Count == 0);
            result.Mensaje = result.Exitoso
                ? "Procesamiento completado exitosamente."
                : string.Format("Se encontraron {0} error(es) durante el procesamiento.", result.Detalles.Count);

            return result;
        }
    }
}
