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
                    .AddParameter("p_archivo_carga", DbType.Binary, 0, Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(carga.archivo_carga ?? new byte[0])))
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
        public static List<MasivoCarga> Consultar(int? codCia, int codUsr)
        {
            List<MasivoCarga> result = new List<MasivoCarga>();

            using (IDbConnection currentConnection = Database.OpenConnection("Tron"))
            {
                Database.Procedure("EM_MASIVOS.p_lee_masivos")
                    .AddParameter("p_cod_cia", DbType.Int32, 2, codCia)
                    .AddParameter("p_updateusercode", DbType.Int32, 9, codUsr)
                    .AddParameter("rc1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.Output)

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
                                archivo_carga = reader["archivo_carga"] as byte[],
                                txt_archivo_rta = reader.StringValue("txt_archivo_rta"),
                                num_tam_archivo_rta = reader.IntegerValue("num_tam_archivo_rta"),
                                archivo_rta = reader["archivo_rta"] as byte[],
                                cod_usr = reader.IntegerValue("updateusercode"),
                                fec_actu = reader.DateTimeValue("updatedate")
                            });
                        }
                    }));
            }

            return result;
        }

        /// <summary>
        /// Ejecuta el procesamiento de una carga masiva previamente registrada.
        /// Si el cursor devuelve registros indica errores por registro; si viene vacío el proceso fue exitoso.
        /// </summary>
        /// <param name="codCia">Código de compañía.</param>
        /// <param name="codRamo">Código de ramo.</param>
        /// <param name="codEstructura">Código de estructura.</param>
        /// <param name="txtArchivoCarga">Nombre del archivo cargado.</param>
        /// <returns>Resultado del procesamiento con detalle de errores por registro.</returns>
        public static MasivoResult Procesar(int codCia, int codRamo, string codEstructura, string txtArchivoCarga)
        {
            MasivoResult result = new MasivoResult();

            using (IDbConnection currentConnection = Database.OpenConnection("Tron"))
            {
                Database.Procedure("EM_MASIVOS.p_procesar_archivo")
                    .AddParameter("p_cod_cia", DbType.Int32, 2, codCia)
                    .AddParameter("p_cod_ramo", DbType.Int32, 5, codRamo)
                    .AddParameter("p_cod_estructura", DbType.String, 100, codEstructura)
                    .AddParameter("p_txt_archivo_carga", DbType.String, 255, txtArchivoCarga)
                    .AddParameter("rc1", Architect.DataFactory.Enumerations.DbType.RefCursor, 0, null, ParameterDirection.Output)
                    .Query(currentConnection, "Tron", new Action<IDataReader, string>((reader, key) =>
                    {
                        if (key == "rc1")
                        {
                            result.Detalles.Add(new Contracts.Masivos.MasivoErrorDetalle
                            {
                                num_proceso    = reader.IntegerValue("num_proceso"),
                                cod_estructura = reader.StringValue("cod_estructura"),
                                num_registro   = reader.IntegerValue("num_registro"),
                                tip_error      = reader.StringValue("tip_error"),
                                txt_error      = reader.StringValue("txt_error"),
                                txt_ruta_error = reader.StringValue("txt_ruta_error"),
                                cod_usr        = reader.IntegerValue("cod_usr"),
                                fec_actu       = reader.DateTimeValue("fec_actu")
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
