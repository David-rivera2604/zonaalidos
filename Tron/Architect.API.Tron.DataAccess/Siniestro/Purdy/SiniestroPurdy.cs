using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Tron.DataAccess.Siniestro.Purdy
{
    /// <summary>
    /// Información detalle de un siniestro procesado por Purdy
    /// </summary>
    public sealed partial class SiniestroPurdy
    {

        /// <summary>
        /// Crea un registro en la tabla SiniestroPurdy.
        /// </summary>
        /// <param name="siniestropurdyItem">Instancia de SiniestroPurdy</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Contracts.Siniestro.Purdy.SiniestroPurdy siniestropurdyItem, IDbConnection connection = null)
        {

            return Database.Insert("INSERT INTO SiniestroPurdy (NUM_SINI, NUM_EXP, NUM_POLIZA, TIP_EXP, MONTO_MANO_OBRA, MONTO_REPUESTOS, MONTO_TOTAL, MONTO_OTRO_RUBROS, MONTO_DEDUCIBLE, MONTO_RECUPERADO, FECHA_ULTIMO_PAGO, FECHA_RECUPERACION, TIP_EST_EXP) " +
                                                 "VALUES(:NUM_SINI, :NUM_EXP, :NUM_POLIZA, :TIP_EXP, :MONTO_MANO_OBRA, :MONTO_REPUESTOS, :MONTO_TOTAL, :MONTO_OTRO_RUBROS, :MONTO_DEDUCIBLE, :MONTO_RECUPERADO, :FECHA_ULTIMO_PAGO, :FECHA_RECUPERACION, :TIP_EST_EXP)")
                            .AddParameter("NUM_SINI", DbType.Decimal, 15, siniestropurdyItem.NUM_SINI)
                            .AddParameter("NUM_EXP", DbType.Decimal, 5, siniestropurdyItem.NUM_EXP)
                            .AddParameter("NUM_POLIZA", DbType.AnsiString, 13, siniestropurdyItem.NUM_POLIZA)
                            .AddParameter("TIP_EXP", DbType.Decimal, 5, siniestropurdyItem.TIP_EXP)
                            .AddParameter("MONTO_MANO_OBRA", DbType.Decimal, 18, siniestropurdyItem.MONTO_MANO_OBRA)
                            .AddParameter("MONTO_REPUESTOS", DbType.Decimal, 18, siniestropurdyItem.MONTO_REPUESTOS)
                            .AddParameter("MONTO_TOTAL", DbType.Decimal, 18, siniestropurdyItem.MONTO_TOTAL)
                            .AddParameter("MONTO_OTRO_RUBROS", DbType.Decimal, 18, siniestropurdyItem.MONTO_OTRO_RUBROS)
                            .AddParameter("MONTO_DEDUCIBLE", DbType.Decimal, 18, siniestropurdyItem.MONTO_DEDUCIBLE)
                            .AddParameter("MONTO_RECUPERADO", DbType.Decimal, 18, siniestropurdyItem.MONTO_RECUPERADO)
                            .AddParameter("FECHA_ULTIMO_PAGO", DbType.DateTime, 9, siniestropurdyItem.FECHA_ULTIMO_PAGO)
                            .AddParameter("FECHA_RECUPERACION", DbType.DateTime, 9, siniestropurdyItem.FECHA_RECUPERACION)
                            .AddParameter("TIP_EST_EXP", DbType.Decimal, 5, siniestropurdyItem.TIP_EST_EXP)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla SiniestroPurdy.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="siniestropurdyItems">Lista de instancia de SiniestroPurdy</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Contracts.Siniestro.Purdy.SiniestroPurdy> siniestropurdyItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Contracts.Siniestro.Purdy.SiniestroPurdy item in siniestropurdyItems)
            {
                result.Add(Create(item, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla SiniestroPurdy por medio de su clave primaria.
        /// </summary>
        /// <param name="num_sini">Número de siniestro.</param>
        /// <param name="num_exp">Número de expediente.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de SiniestroPurdy</returns>
        public static Contracts.Siniestro.Purdy.SiniestroPurdy Retrieve(Int64 num_sini, int num_exp, IDbConnection connection = null)
        {
            Contracts.Siniestro.Purdy.SiniestroPurdy result = null;
            Database.Select("SELECT NUM_SINI, NUM_EXP, NUM_POLIZA, TIP_EXP, MONTO_MANO_OBRA, MONTO_REPUESTOS, MONTO_TOTAL, MONTO_OTRO_RUBROS, MONTO_DEDUCIBLE, MONTO_RECUPERADO, FECHA_ULTIMO_PAGO, FECHA_RECUPERACION, TIP_EST_EXP " +
                              "FROM SiniestroPurdy " +
                             "WHERE NUM_SINI=:NUM_SINI AND NUM_EXP=:NUM_EXP")
                        .AddParameter("NUM_SINI", DbType.Decimal, 15, num_sini)
                        .AddParameter("NUM_EXP", DbType.Decimal, 5, num_exp)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToSiniestroPurdy(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla SiniestroPurdy.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de SiniestroPurdy</returns>
        public static List<Contracts.Siniestro.Purdy.SiniestroPurdy> RetrieveAll(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Contracts.Siniestro.Purdy.SiniestroPurdy> result = new List<Contracts.Siniestro.Purdy.SiniestroPurdy>();
            Database.Select("SELECT NUM_SINI, NUM_EXP, NUM_POLIZA, TIP_EXP, MONTO_MANO_OBRA, MONTO_REPUESTOS, MONTO_TOTAL, MONTO_OTRO_RUBROS, MONTO_DEDUCIBLE, MONTO_RECUPERADO, FECHA_ULTIMO_PAGO, FECHA_RECUPERACION, TIP_EST_EXP " +
                              "FROM SiniestroPurdy" + filter)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToSiniestroPurdy(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla SiniestroPurdy.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de SiniestroPurdy</returns>
        public static List<Contracts.Siniestro.Purdy.SiniestroPurdy> RetrieveAll(string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Contracts.Siniestro.Purdy.SiniestroPurdy> result = new List<Contracts.Siniestro.Purdy.SiniestroPurdy>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT NUM_SINI, NUM_EXP, NUM_POLIZA, TIP_EXP, MONTO_MANO_OBRA, MONTO_REPUESTOS, MONTO_TOTAL, MONTO_OTRO_RUBROS, MONTO_DEDUCIBLE, MONTO_RECUPERADO, FECHA_ULTIMO_PAGO, FECHA_RECUPERACION, TIP_EST_EXP " +
                                   ", ROW_NUMBER() OVER (ORDER BY SiniestroPurdy.NUM_SINI DESC) RowNumber " +
                              "FROM SiniestroPurdy" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToSiniestroPurdy(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Genera complemento de la consulta para habilitar el filtro por columnas establecidas.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros.</param>
        /// <param name="includeWhere">Indica que el complemento debe incluir el WHERE del comando.</param>
        /// <returns>Complemento de la consulta</returns>
        public static string FilterBuilder(string filter, bool includeWhere = true)
        {
            string result = string.Empty;


            return result;
        }


        /// <summary>
        /// Actualiza un registro en la tabla SiniestroPurdy por medio de su clave primaria.
        /// </summary>
        /// <param name="siniestropurdyItem">Instancia de SiniestroPurdy</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Contracts.Siniestro.Purdy.SiniestroPurdy siniestropurdyItem, IDbConnection connection = null)
        {

            return Database.Update("UPDATE SiniestroPurdy " +
                                      "SET NUM_POLIZA=:NUM_POLIZA, TIP_EXP=:TIP_EXP, MONTO_MANO_OBRA=:MONTO_MANO_OBRA, MONTO_REPUESTOS=:MONTO_REPUESTOS, MONTO_TOTAL=:MONTO_TOTAL, MONTO_OTRO_RUBROS=:MONTO_OTRO_RUBROS, MONTO_DEDUCIBLE=:MONTO_DEDUCIBLE, MONTO_RECUPERADO=:MONTO_RECUPERADO, FECHA_ULTIMO_PAGO=:FECHA_ULTIMO_PAGO, FECHA_RECUPERACION=:FECHA_RECUPERACION, TIP_EST_EXP=:TIP_EST_EXP " +
                                    "WHERE NUM_SINI=:NUM_SINI AND NUM_EXP=:NUM_EXP")
                                .AddParameter("NUM_POLIZA", DbType.AnsiString, 13, siniestropurdyItem.NUM_POLIZA)
                                .AddParameter("TIP_EXP", DbType.Decimal, 5, siniestropurdyItem.TIP_EXP)
                                .AddParameter("MONTO_MANO_OBRA", DbType.Decimal, 18, siniestropurdyItem.MONTO_MANO_OBRA)
                                .AddParameter("MONTO_REPUESTOS", DbType.Decimal, 18, siniestropurdyItem.MONTO_REPUESTOS)
                                .AddParameter("MONTO_TOTAL", DbType.Decimal, 18, siniestropurdyItem.MONTO_TOTAL)
                                .AddParameter("MONTO_OTRO_RUBROS", DbType.Decimal, 18, siniestropurdyItem.MONTO_OTRO_RUBROS)
                                .AddParameter("MONTO_DEDUCIBLE", DbType.Decimal, 18, siniestropurdyItem.MONTO_DEDUCIBLE)
                                .AddParameter("MONTO_RECUPERADO", DbType.Decimal, 18, siniestropurdyItem.MONTO_RECUPERADO)
                                .AddParameter("FECHA_ULTIMO_PAGO", DbType.DateTime, 9, siniestropurdyItem.FECHA_ULTIMO_PAGO)
                                .AddParameter("FECHA_RECUPERACION", DbType.DateTime, 9, siniestropurdyItem.FECHA_RECUPERACION)
                                .AddParameter("TIP_EST_EXP", DbType.Decimal, 5, siniestropurdyItem.TIP_EST_EXP)
                                .AddParameter("NUM_SINI", DbType.Decimal, 15, siniestropurdyItem.NUM_SINI)
                                .AddParameter("NUM_EXP", DbType.Decimal, 5, siniestropurdyItem.NUM_EXP)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla SiniestroPurdy por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="siniestropurdyItems">Lista de instancia de SiniestroPurdy</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Contracts.Siniestro.Purdy.SiniestroPurdy> siniestropurdyItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Contracts.Siniestro.Purdy.SiniestroPurdy item in siniestropurdyItems)
            {
                result.Add(Update(item, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Elimina un registro en la tabla SiniestroPurdy por medio de su clave primaria.
        /// </summary>
        /// <param name="num_sini">Número de siniestro.</param>
        /// <param name="num_exp">Número de expediente.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(Int64 num_sini, int num_exp, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM SiniestroPurdy " +
                                    "WHERE NUM_SINI=:NUM_SINI AND NUM_EXP=:NUM_EXP")
                                .AddParameter("NUM_SINI", DbType.Decimal, 15, num_sini)
                                .AddParameter("NUM_EXP", DbType.Decimal, 5, num_exp)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla SiniestroPurdy por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="baseList">Lista de clave primaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<Contracts.Siniestro.Purdy.SiniestroPurdyBase> baseList, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Contracts.Siniestro.Purdy.SiniestroPurdyBase item in baseList)
            {
                result.Add(Delete(item.NUM_SINI, item.NUM_EXP, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla SiniestroPurdy por medio de su clave primaria.
        /// </summary>
        /// <param name="num_sini">Número de siniestro.</param>
        /// <param name="num_exp">Número de expediente.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(Int64 num_sini, int num_exp, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(*) " +
                                          "FROM SiniestroPurdy " +
                                         "WHERE NUM_SINI=:NUM_SINI AND NUM_EXP=:NUM_EXP")
                               .AddParameter("NUM_SINI", DbType.Decimal, 15, num_sini)
                               .AddParameter("NUM_EXP", DbType.Decimal, 5, num_exp)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla SiniestroPurdy que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(*) " +
                                          "FROM SiniestroPurdy " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'SiniestroPurdy'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Contracts.Siniestro.Purdy.SiniestroPurdy DataReaderToSiniestroPurdy(System.Data.IDataReader reader, Contracts.Siniestro.Purdy.SiniestroPurdy item = null)
        {
            if (item == null)
            {
                item = new Contracts.Siniestro.Purdy.SiniestroPurdy();
            }
            item.NUM_SINI = reader.Integer64Value("NUM_SINI");
            item.NUM_EXP = reader.IntegerValue("NUM_EXP");
            item.NUM_POLIZA = reader.StringValue("NUM_POLIZA");
            item.TIP_EXP = reader.IntegerValue("TIP_EXP");
            item.MONTO_MANO_OBRA = reader.DoubleValue("MONTO_MANO_OBRA");
            item.MONTO_REPUESTOS = reader.DoubleValue("MONTO_REPUESTOS");
            item.MONTO_TOTAL = reader.DoubleValue("MONTO_TOTAL");
            item.MONTO_OTRO_RUBROS = reader.DoubleValue("MONTO_OTRO_RUBROS");
            item.MONTO_DEDUCIBLE = reader.DoubleValue("MONTO_DEDUCIBLE");
            item.MONTO_RECUPERADO = reader.DoubleValue("MONTO_RECUPERADO");
            item.FECHA_ULTIMO_PAGO = reader.DateTimeValue("FECHA_ULTIMO_PAGO");
            item.FECHA_RECUPERACION = reader.DateTimeValue("FECHA_RECUPERACION");
            item.TIP_EST_EXP = reader.IntegerValue("TIP_EST_EXP");
            return item;
        }

    }

}

