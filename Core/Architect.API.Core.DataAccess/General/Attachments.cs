using Architect.DataFactory;
using Architect.DataFactory.Enumerations;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    public sealed partial class Attachments
    {

        public static int Delete(int entityType, long entityId, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("Attachments", ExecuteMode.CommandBuilder)
                    .Filter("EntityType", DbType.Decimal, 5, entityType)
                    .Filter("EntityId", DbType.Decimal, 18, entityId)
                    .Filter("CompanyId", DbType.Decimal, 5, companyId)
                    .Execute(connection, "Research");
        }

        /// <summary>
        /// Elimina un registro en la tabla Attachments por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, IDbConnection connection = null)
        {
            return Database.Delete("Attachments", ExecuteMode.CommandBuilder)
                    .Filter("Id", DbType.Decimal, 9, id)
                    .Execute(connection, "Research");
        }


        public static List<Contracts.General.AttachmentView> RetrieveByEntity(int entityType, long entityId, int companyId, IDbConnection connection = null)
        {
            var result = new List<Contracts.General.AttachmentView>();
            Database.Select(@"SELECT Id, DocumentType, Attachments.Description, FileName, FileSize, Attachments.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Attachments.UpdateDate, 
                                    LKDT.DESCRIPTION DocumentTypeDesc 
                               FROM Attachments 
                          LEFT JOIN UserMember um ON um.UserId= Attachments.UpdateUserCode 
                          LEFT JOIN LOOKUP LKDT ON LKDT.LOOKUPID = 100 And LKDT.CODE = Attachments.DocumentType And LKDT.LANGUAGE=1 
                              WHERE EntityType=:EntityType AND EntityId=:EntityId AND Attachments.CompanyId=:CompanyId ORDER BY Id")
                        .AddParameter("EntityType", DbType.Decimal, 5, entityType)
                        .AddParameter("EntityId", DbType.Decimal, 18, entityId)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataRowMapperView(reader));
                        }));

            return result;
        }

        public static Contracts.General.AttachmentItem RetrieveById(int Id, IDbConnection connection = null)
        {
            Contracts.General.AttachmentItem result = null;
            Database.Select(@"SELECT FileName, FileContent 
                                FROM Attachments 
                               WHERE Id=:Id")
                        .AddParameter("Id", DbType.Decimal, 5, Id)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = new Contracts.General.AttachmentItem() { FileName = reader.StringValue("FileName"), Content = (byte[])reader["FileContent"] };
                            result.Type = System.IO.Path.GetExtension(result.FileName).Replace(".", "");
                        }));

            return result;
        }

        private static Contracts.General.AttachmentView DataRowMapperView(System.Data.IDataReader itemRow)
        {
            return new Contracts.General.AttachmentView()
            {
                Id = (int)Math.Round(itemRow.NumericValue("Id")),
                Description = itemRow.StringValue("Description"),
                FileName = itemRow.StringValue("FileName"),
                FileSize = (int)Math.Round(itemRow.NumericValue("FileSize")),
                UpdateUserCode = (int)Math.Round(itemRow.NumericValue("UpdateUserCode")),
                UpdateUserName = itemRow.StringValue("UpdateUserName"),
                UpdateDate = itemRow.DateTimeValue("UpdateDate"),
                DocumentType = (int)Math.Round(itemRow.NumericValue("DocumentType")),
                DocumentTypeDesc = itemRow.StringValue("DocumentTypeDesc")
            };
        }

        /// <summary>
        /// Crea un registro en la tabla Attachments.
        /// </summary>
        /// <param name="attachmentsItem">Instancia de Attachments</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int CreateCustom(Architect.API.Core.Contracts.General.Attachments attachmentsItem, IDbConnection connection = null)
        {
            if (attachmentsItem.UpdateDate.IsEmpty())
            {
                attachmentsItem.UpdateDate = DateTime.Now;
            }

            return Database.Insert(@"INSERT INTO Attachments (Id, DocumentType, Description, FileName, FileSize, FileContent, EntityType, EntityId, CompanyId, UpdateUserCode, UpdateDate)
                                                       VALUES(:Id, :DocumentType, :Description, :FileName, :FileSize, :FileContent, :EntityType, :EntityId, :CompanyId, :UpdateUserCode, :UpdateDate)")
                        .AddParameter("Id", DbType.Decimal, 9, attachmentsItem.Id)
                        .AddParameter("DocumentType", DbType.Decimal, 5, attachmentsItem.DocumentType)
                        .AddParameter("Description", DbType.AnsiString, 120, attachmentsItem.Description)
                        .AddParameter("FileName", DbType.AnsiString, 80, attachmentsItem.FileName)
                        .AddParameter("FileSize", DbType.Decimal, 9, attachmentsItem.FileSize)
                        .AddParameter("FileContent", DbType.Binary, 0, Utilities.Helpers.ByteHandler.FileToBytes(attachmentsItem.FileContent))
                        .AddParameter("EntityType", DbType.Decimal, 5, attachmentsItem.EntityType)
                        .AddParameter("EntityId", DbType.Decimal, 18, attachmentsItem.EntityId)
                        .AddParameter("CompanyId", DbType.Decimal, 5, attachmentsItem.CompanyId)
                        .AddParameter("UpdateUserCode", DbType.Decimal, 9, attachmentsItem.UpdateUserCode)
                        .AddParameter("UpdateDate", DbType.DateTime, 0, attachmentsItem.UpdateDate)
                        .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla Attachments por medio de su clave primaria.
        /// </summary>
        /// <param name="attachmentsItem">Instancia de Attachments</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int UpdateCustom(Architect.API.Core.Contracts.General.Attachments attachmentsItem, IDbConnection connection = null)
        {
            if (attachmentsItem.UpdateDate.IsEmpty())
            {
                attachmentsItem.UpdateDate = DateTime.Now;
            }
            if (attachmentsItem.FileContent.IsNotEmpty())
            {
                var contenido = Architect.Utilities.Helpers.ByteHandler.FileToBytes(attachmentsItem.FileContent);
                return Database.Update("UPDATE Attachments " +
                                          "SET CompanyId=:CompanyId, EntityType=:EntityType, EntitySubType=:EntitySubType, EntityId=:EntityId, DocumentType=:DocumentType, Description=:Description, FileName=:FileName, FileSize=:FileSize, FileContent=:FileContent, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                        "WHERE Id=:Id")
                                    .AddParameter("CompanyId", DbType.Decimal, 5, attachmentsItem.CompanyId)
                                    .AddParameter("EntityType", DbType.Decimal, 5, attachmentsItem.EntityType)
                                    .AddParameter("EntitySubType", DbType.Decimal, 5, attachmentsItem.EntitySubType)
                                    .AddParameter("EntityId", DbType.Decimal, 18, attachmentsItem.EntityId)
                                    .AddParameter("DocumentType", DbType.Decimal, 5, attachmentsItem.DocumentType)
                                    .AddParameter("Description", DbType.AnsiString, 120, attachmentsItem.Description)
                                    .AddParameter("FileName", DbType.AnsiString, 80, attachmentsItem.FileName)
                                    .AddParameter("FileSize", DbType.Decimal, 9, attachmentsItem.FileSize)
                                    .AddParameter("FileContent", DbType.Binary, 0, contenido)
                                    .AddParameter("UpdateUserCode", DbType.Decimal, 9, attachmentsItem.UpdateUserCode)
                                    .AddParameter("UpdateDate", DbType.DateTime, 0, attachmentsItem.UpdateDate)
                                    .AddParameter("Id", DbType.Decimal, 9, attachmentsItem.Id)
                                    .Execute(connection, "Research");
            }
            else
            {
                return Database.Update("UPDATE Attachments " +
                                          "SET CompanyId=:CompanyId, EntityType=:EntityType, EntitySubType=:EntitySubType, EntityId=:EntityId, DocumentType=:DocumentType, Description=:Description, FileName=:FileName, FileSize=:FileSize,  UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                        "WHERE Id=:Id")
                                    .AddParameter("CompanyId", DbType.Decimal, 5, attachmentsItem.CompanyId)
                                    .AddParameter("EntityType", DbType.Decimal, 5, attachmentsItem.EntityType)
                                    .AddParameter("EntitySubType", DbType.Decimal, 5, attachmentsItem.EntitySubType)
                                    .AddParameter("EntityId", DbType.Decimal, 18, attachmentsItem.EntityId)
                                    .AddParameter("DocumentType", DbType.Decimal, 5, attachmentsItem.DocumentType)
                                    .AddParameter("Description", DbType.AnsiString, 120, attachmentsItem.Description)
                                    .AddParameter("FileName", DbType.AnsiString, 80, attachmentsItem.FileName)
                                    .AddParameter("FileSize", DbType.Decimal, 9, attachmentsItem.FileSize)
                                    .AddParameter("UpdateUserCode", DbType.Decimal, 9, attachmentsItem.UpdateUserCode)
                                    .AddParameter("UpdateDate", DbType.DateTime, 0, attachmentsItem.UpdateDate)
                                    .AddParameter("Id", DbType.Decimal, 9, attachmentsItem.Id)
                                    .Execute(connection, "Research");
            }
        }

    }
}