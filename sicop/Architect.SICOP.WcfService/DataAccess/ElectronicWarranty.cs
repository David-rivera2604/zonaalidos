using Architect.DataFactory;
using Architect.DataFactory.Enumerations;
using Architect.Utilities.Extensions;
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

        public static int Update(int id, string metodo, string codigo_Proceso)
        {
            return Database.Update("ElectronicWarranty", ExecuteMode.CommandBuilder)
                    .Column("Metodo", DbType.AnsiString, 1, metodo)
                    .Column("Codigo_Proceso", DbType.AnsiString, 16, codigo_Proceso)
                    .Column("FECHA_PROCESO", DbType.DateTime, 0, DateTime.Now)
                    .Filter("ID", DbType.Decimal, 9, id)
                    .Execute(null, "Research");
        }

    }
}