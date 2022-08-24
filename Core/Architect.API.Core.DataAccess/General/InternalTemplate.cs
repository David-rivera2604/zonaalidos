using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Configuration;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    public sealed class InternalTemplate
    {
        /// <summary>
        /// Recupera una plantilla por medio de la clave de la misma para la compañía en tratamiento o para la compañía 0.
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Contracts.General.InternalTemplate Retrieve(int companyId, string key)
        {
            Contracts.General.InternalTemplate result = new Contracts.General.InternalTemplate()
            {
                Subject = "Plantilla no encontrada",
                Body = "Plantilla no encontrada"
            };

            Database.Select(@"SELECT Subject, Body, EmailTo, MasterTemplateId
                               FROM Template
                              WHERE Key=:Key AND (CompanyId=:CompanyId OR CompanyId=0) ORDER BY CompanyId DESC")
                        .AddParameter("Key", DbType.AnsiString, 40, key)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Cache(ConfigurationManager.AppSettings["Working.Mode"] != "Development")
                        .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {

                            result = new Contracts.General.InternalTemplate()
                            {
                                Subject = reader.StringValue("Subject"),
                                Body = reader.StringValue("Body"),
                                EmailTo = reader.StringValue("EmailTo"),
                                MasterTemplateId = reader.IntegerValue("MasterTemplateId")
                            };

                        }), false);

            return result;
        }

        public static Contracts.General.InternalTemplate RetrieveById(int companyId, int id)
        {
            Contracts.General.InternalTemplate result = new Contracts.General.InternalTemplate()
            {
                Subject = "Plantilla no encontrada",
                Body = "Plantilla no encontrada"
            };

            Database.Select(@"SELECT Subject, Body, EmailTo, MasterTemplateId 
                               FROM Template 
                              WHERE Id=:Id AND (CompanyId=:CompanyId OR CompanyId=0) Order by CompanyId DESC")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Cache(ConfigurationManager.AppSettings["Working.Mode"] != "Development")
                        .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = new Contracts.General.InternalTemplate()
                            {
                                Subject = reader.StringValue("Subject"),
                                Body = reader.StringValue("Body"),
                                EmailTo = reader.StringValue("EmailTo"),
                                MasterTemplateId = reader.IntegerValue("MasterTemplateId")
                            };

                        }), false);

            return result;
        }
    }
}