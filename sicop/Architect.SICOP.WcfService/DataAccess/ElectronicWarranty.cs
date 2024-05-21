using Architect.DataFactory;
using Architect.DataFactory.Enumerations;
using Architect.Utilities.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.SICOP.WcfService.DataAccess
{
    public sealed class ElectronicWarranty
    {
        public static Contracts.ElectronicWarranty RetrieveByGuaranteeNumber(string guarantee_number)
        {
            Contracts.ElectronicWarranty result = null;
            Database.Select(
                @"SELECT ID, Guarantee_sequencenumber, Moneda, Metodo, Codigo_Proceso
                    FROM ElectronicWarranty P
                   WHERE Guarantee_number = :Guarantee_number
                     AND P.Guarantee_sequencenumber = (SELECT max(Guarantee_sequencenumber) FROM ElectronicWarranty M WHERE M.Guarantee_number = P.Guarantee_number)")
                .AddParameter("Guarantee_number", DbType.AnsiString, 14, guarantee_number)
                .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                {
                    result = new Contracts.ElectronicWarranty()
                    {
                        ID = reader.IntegerValue("ID"),
                        Guarantee_sequencenumber = reader.StringValue("Guarantee_sequencenumber"),
                        Moneda = reader.StringValue("Moneda"),
                        Metodo = reader.StringValue("Metodo"),
                        Codigo_Proceso = reader.StringValue("Codigo_Proceso")
                    };
                }));
            return result;
        }
        public static int Update(int id, string metodo, string codigo_Proceso, decimal amount, string contents, string cuenta_Cliente)
        {
            return Database.Update("ElectronicWarranty", ExecuteMode.CommandBuilder)
                    .Column("ex_amount", DbType.Double, 22, amount)
                    .Column("ex_contents", DbType.AnsiString, 200, contents)
                    .Column("ex_Cuenta_Cliente", DbType.AnsiString, 20, cuenta_Cliente)
                    .Column("ex_Metodo", DbType.AnsiString, 1, metodo)
                    .Column("ex_Codigo_Proceso", DbType.AnsiString, 16, codigo_Proceso)
                    .Column("ex_FECHA_PROCESO", DbType.DateTime, 0, DateTime.Now)
                    .Filter("ID", DbType.Decimal, 9, id)
                    .Execute(null, "Research");
        }

    }
}