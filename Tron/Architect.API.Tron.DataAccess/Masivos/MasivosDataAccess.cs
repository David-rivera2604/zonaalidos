using Architect.API.Tron.Contracts.Masivos;
using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Masivos
{
    /// <summary>
    /// Acceso a datos para operaciones de carga masiva.
    /// </summary>
    public static class MasivosDataAccess
    {
        /// <summary>
        /// Inserta un registro de carga masiva invocando el procedimiento p_insert_masivos.
        /// </summary>
        /// <param name="carga">Datos de la carga masiva.</param>
        /// <returns>True si la inserción fue exitosa.</returns>
        public static int Insert(MasivoCarga carga)
        {
            

            using (IDbConnection currentConnection = Database.OpenConnection("Tron"))
            {
                Database.Procedure("EM_MASIVOS.p_insert_masivos")
                    .AddParameter("p_cod_cia", DbType.Int32, 2, carga.cod_cia)
                    .AddParameter("p_cod_ramo", DbType.Int32, 5, carga.cod_ramo)
                    .AddParameter("p_cod_estructura", DbType.String, 100, carga.cod_estructura)
                    .AddParameter("p_txt_archivo_carga", DbType.String, 255, carga.txt_archivo_carga)
                    .AddParameter("p_num_tam_archivo", DbType.Int64, 0, carga.num_tam_archivo)
                    .AddParameter("p_archivo_carga", DbType.Binary, 0, Encoding.UTF8.GetBytes(carga.archivo_carga ?? string.Empty))
                    .AddParameter("p_updateusercode", DbType.Int32, 9, carga.cod_usr)
                    .AddParameter("p_resultado", DbType.Int32, 9, 0, ParameterDirection.Output)
                    .Execute(currentConnection, "Tron");
            }

            return 1;
        }

        /// <summary>
        /// Consulta los registros de cargas masivas por código de ramo.
        /// </summary>
        /// <param name="codRamo">Código de ramo (opcional).</param>
        /// <returns>Lista de cargas registradas.</returns>
        public static List<MasivoCarga> Consultar(int? codCia, int? codRamo, string codEstructura, string txtArchivoCarga, int codUsr)
        {
            List<MasivoCarga> result = new List<MasivoCarga>();

            using (IDbConnection currentConnection = Database.OpenConnection("Tron"))
            {
                Database.Procedure("EM_MASIVOS.p_lee_masivos")
                    .AddParameter("p_cod_cia", DbType.Int32, 2, codCia)
                    .AddParameter("p_cod_ramo", DbType.Int32, 5, codRamo)
                    .AddParameter("p_cod_estructura", DbType.String, 100, codEstructura)
                    .AddParameter("p_txt_archivo_carga", DbType.String, 255, txtArchivoCarga)
                    .AddParameter("p_updateusercode", DbType.Int32, 9, codUsr)
                    .AddParameter("rc1", DbType.RefCursor, 0, null, ParameterDirection.InputOutput)
                    .Query(currentConnection, "Tron", new Action<IDataReader, string>((reader, key) =>
                    {
                        if (key == "rc1")
                        {
                            result.Add(new MasivoCarga
                            {
                                cod_cia = reader.IntegerValue("cod_cia"),
                                cod_ramo = reader.IntegerValue("cod_ramo"),
                                cod_estructura = reader.StringValue("cod_estructura"),
                                txt_archivo_carga = reader.StringValue("txt_archivo_carga"),
                                num_tam_archivo = reader.IntegerValue("num_tam_archivo"),
                                archivo_carga = reader.StringValue("archivo_carga"),
                                cod_usr = reader.IntegerValue("updateusercode"),
                                fec_actu = reader.DateTimeValue("fec_actu"),
                                estado = reader.StringValue("estado"),
                                resultado_proceso = reader.StringValue("resultado_proceso")
                            });
                        }
                    }));
            }

            return result;
        }

        /// <summary>
        /// Ejecuta el procesamiento de una carga masiva previamente registrada.
        /// </summary>
        /// <param name="codCia">Código de compañía.</param>
        /// <param name="codRamo">Código de ramo.</param>
        /// <param name="codEstructura">Código de estructura.</param>
        /// <returns>Resultado del procesamiento.</returns>
        public static MasivoResult Procesar(int codCia, int codRamo, string codEstructura)
        {
            MasivoResult result = new MasivoResult();

            using (IDbConnection currentConnection = Database.OpenConnection("Tron"))
            {
                Database.Procedure("p_procesar_masivos")
                    .AddParameter("p_cod_cia", DbType.Int32, 2, codCia)
                    .AddParameter("p_cod_ramo", DbType.Int32, 5, codRamo)
                    .AddParameter("p_cod_estructura", DbType.String, 100, codEstructura)
                    .AddParameter("rc1", DbType.RefCursor, 0, null, ParameterDirection.Output)
                    .Query(currentConnection, "Tron", new Action<IDataReader, string>((reader, key) =>
                    {
                        if (key == "rc1")
                        {
                            string error = reader.StringValue("txt_error");
                            if (!string.IsNullOrEmpty(error))
                            {
                                result.Errores.Add(error);
                            }
                        }
                    }));
            }

            result.Exitoso = (result.Errores.Count == 0);
            result.Mensaje = result.Exitoso ? "Procesamiento completado exitosamente." : "Se encontraron errores durante el procesamiento.";

            return result;
        }
    }
}
