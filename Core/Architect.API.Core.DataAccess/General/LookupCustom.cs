using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    public sealed partial class LookupCustom
    {
        /// <summary>
        /// Recupera una lista de registros en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <returns>Lista de instancias de Lookup</returns>
        public static List<Contracts.General.Lookup> RetrieveLpkExtendStringValue1(int lookupId, int language, string extendStringValue1, int companyId, IDbConnection connection = null)
        {
            var result = new List<Contracts.General.Lookup>();
            Database.Select(@"SELECT Code, Description, ParentLookupId, ExtendStringValue1
                                FROM Lookup
                               WHERE LookupId=:LookupId AND CompanyId=:CompanyId AND Language=:Language AND ExtendStringValue1=:ExtendStringValue1 AND RecordStatus=1
                            ORDER BY QueryOrder, Description")
                        .AddParameter("LookupId", DbType.Decimal, 9, lookupId)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter("Language", DbType.Decimal, 5, language)
                        .AddParameter("ExtendStringValue1", DbType.AnsiString, 30, extendStringValue1)
                        .Cache()
                       .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                       {
                           result.Add(new Contracts.General.Lookup()
                           {
                               Code = (int)Math.Round(reader.NumericValue("Code")),
                               Description = reader.StringValue("Description"),
                               ParentLookupId = (int)Math.Round(reader.NumericValue("ParentLookupId")),
                               ExtendStringValue1 = reader.StringValue("ExtendStringValue1")
                           });
                       }));

            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <returns>Lista de instancias de Lookup</returns>
        public static List<Contracts.General.Lookup> RetrieveLpkByCodeFull(int lookupId, int language, int parentLookupId, int companyId, IDbConnection connection = null)
        {
            var result = new List<Contracts.General.Lookup>();
            Database.Select(@"SELECT Code, Description, ExtendStringValue1
                                FROM Lookup
                               WHERE LookupId=:LookupId AND CompanyId=:CompanyId AND Language=:Language AND ParentLookupId=:ParentLookupId AND RecordStatus=1
                            ORDER BY QueryOrder, Description")
                        .AddParameter("LookupId", DbType.Decimal, 9, lookupId)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter("Language", DbType.Decimal, 5, language)
                        .AddParameter("ParentLookupId", DbType.Decimal, 9, parentLookupId)
                        .Cache()
                       .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                       {
                           result.Add(new Contracts.General.Lookup()
                           {
                               Code = reader.IntegerValue("Code"),
                               Description = reader.StringValue("Description"),
                               ExtendStringValue1 = reader.StringValue("ExtendStringValue1")
                           });
                       }));

            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <returns>Lista de instancias de Lookup</returns>
        public static Contracts.General.LookupValue RetrieveLpkByDescription(int lookupId, int language, string description, int companyId, IDbConnection connection = null)
        {
            Contracts.General.LookupValue result = null;
            Database.Select(@"SELECT Code, Description FROM Lookup
                               WHERE LookupId=:LookupId AND CompanyId=:CompanyId AND Language=:Language AND RecordStatus=1 AND LOWER(Description)=:Description
                            ORDER BY QueryOrder, Description")
                        .AddParameter("LookupId", DbType.Decimal, 9, lookupId)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter("Language", DbType.Decimal, 5, language)
                        .AddParameter("Description", DbType.AnsiString, 255, description.ToLower())
                        .Cache()
                       .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                       {
                           result = new Contracts.General.LookupValue()
                           {
                               Code = reader.NumericValue("Code").ToString(),
                               Description = reader.StringValue("Description")
                           };
                       }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <returns>Lista de instancias de Lookup</returns>
        public static Contracts.General.LookupValue RetrieveLpkByHomologousCode(int lookupId, int language, string homologousCode, int companyId, IDbConnection connection = null)
        {
            Contracts.General.LookupValue result = null;
            Database.Select(@"SELECT Code, Description
                                FROM Lookup
                               WHERE LookupId=:LookupId AND CompanyId=:CompanyId AND Language=:Language AND RecordStatus=1 AND HomologousCode=:HomologousCode
                            ORDER BY QueryOrder, Description")
                        .AddParameter("LookupId", DbType.Decimal, 9, lookupId)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter("Language", DbType.Decimal, 5, language)
                        .AddParameter("HomologousCode", DbType.AnsiString, 12, homologousCode)
                        .Cache()
                       .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                       {
                           result = new Contracts.General.LookupValue()
                           {
                               Code = reader.NumericValue("Code").ToString(),
                               Description = reader.StringValue("Description")
                           };
                       }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <returns>Lista de instancias de Lookup</returns>
        public static List<Contracts.General.LookupValue> RetrieveByLookupMasterKey(int lookupId, int language, int companyId, IDbConnection connection = null)
        {
            var result = new List<Contracts.General.LookupValue>();

            string key = string.Format("Lookup.{0}.{1}.{2}", lookupId, language, companyId);
            if (Architect.Utilities.Cache.NotExist(key))
            {
                Database.Select(@"SELECT Code, Description
                               FROM Lookup
                              WHERE LookupId=:LookupId AND CompanyId=:CompanyId AND Language=:Language AND RecordStatus=1
                           ORDER BY QueryOrder, Description")
                       .AddParameter("LookupId", DbType.Decimal, 9, lookupId)
                       .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                       .AddParameter("Language", DbType.Decimal, 5, language)
                      //.Cache()
                      .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                      {
                          result.Add(new Contracts.General.LookupValue()
                          {
                              Code = reader.StringValue("Code").Trim(),
                              Description = reader.StringValue("Description")
                          });
                      }));

                Architect.Utilities.Cache.SetItem(key, result);
            }
            else
            {
                result = (List<Contracts.General.LookupValue>)Architect.Utilities.Cache.GetItem(key);
            }

            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <returns>Lista de instancias de Lookup</returns>
        public static List<Contracts.General.LookupValue> RetrieveByLookupMasterKey(int lookupId, int language, int parentLookupId, int companyId, IDbConnection connection = null)
        {
            var result = new List<Contracts.General.LookupValue>();
            Database.Select(@"SELECT Code, Description
                                FROM Lookup
                               WHERE LookupId=:LookupId AND CompanyId=:CompanyId AND Language=:Language AND ParentLookupId=:ParentLookupId AND RecordStatus=1
                            ORDER BY QueryOrder, Description")
                      .AddParameter("LookupId", DbType.Decimal, 9, lookupId)
                      .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                      .AddParameter("Language", DbType.Decimal, 5, language)
                      .AddParameter("ParentLookupId", DbType.Decimal, 9, parentLookupId)
                      .Cache()
                      .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                      {
                          result.Add(new Contracts.General.LookupValue()
                          {
                              Code = reader.StringValue("Code").Trim(),
                              Description = reader.StringValue("Description")
                          });
                      }));

            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla Lookup por medio de su clave primaria.
        /// </summary>
        /// <returns>Lista de instancias de Lookup</returns>
        public static List<Contracts.General.LookupValue> RetrieveByLookupMasterKey(int lookupId, int language, int parentLookupId, int extendNumberValue1, int companyId, IDbConnection connection = null)
        {
            var result = new List<Contracts.General.LookupValue>();
            Database.Select(@"SELECT Code, Description
                               FROM Lookup
                             WHERE LookupId=:LookupId AND CompanyId=:CompanyId AND Language=:Language AND ParentLookupId=:ParentLookupId AND SubParentLookupId=:SubParentLookupId AND RecordStatus=1
                         ORDER BY QueryOrder, Description")
                        .AddParameter("LookupId", DbType.Decimal, 9, lookupId)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter("Language", DbType.Decimal, 5, language)
                        .AddParameter("ParentLookupId", DbType.Decimal, 9, parentLookupId)
                        .AddParameter("SubParentLookupId", DbType.Decimal, 9, extendNumberValue1)
                      .Cache()
                      .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                      {
                          result.Add(new Contracts.General.LookupValue()
                          {
                              Code = reader.StringValue("Code").Trim(),
                              Description = reader.StringValue("Description")
                          });
                      }));

            return result;
        }
    }
}