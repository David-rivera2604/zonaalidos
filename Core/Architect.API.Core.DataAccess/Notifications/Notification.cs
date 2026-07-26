using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.Notifications
{
    /// <summary>
    /// Acceso a datos de la tabla Notification (schema ALIADOS).
    /// </summary>
    public sealed partial class Notification
    {
        // ── CREATE ───────────────────────────────────────────────────────────

        public static int Create(Architect.API.Core.Contracts.Notifications.Notification item, IDbConnection connection = null)
        {
            if (item.NotificationId <= 0)
                item.NotificationId = RetrieveLastKey(connection) + 1;

            return Database.Insert("INSERT INTO Notification (NotificationId, CompanyId, UserId, Title, Message, Type, Category, EntityType, EntityId, Metadata, IsRead, UpdateUserCode, UpdateDate, CreatedAt) VALUES (:NotificationId, :CompanyId, :UserId, :Title, :Message, :Type, :Category, :EntityType, :EntityId, :Metadata, 0, :UpdateUserCode, SYSTIMESTAMP, SYSTIMESTAMP)")
                .AddParameter("NotificationId", DbType.Decimal, 9, item.NotificationId)
                .AddParameter("CompanyId", DbType.Decimal, 5, item.CompanyId)
                .AddParameter("UserId", DbType.Decimal, 9, item.UserId)
                .AddParameter("Title", DbType.AnsiString, 255, item.Title)
                .AddParameter("Message", DbType.AnsiString, 2000, item.Message)
                .AddParameter("Type", DbType.AnsiString, 50, item.Type)
                .AddParameter("Category", DbType.AnsiString, 50, item.Category)
                .AddParameter("EntityType", DbType.Decimal, 5, item.EntityType)
                .AddParameter("EntityId", DbType.Decimal, 18, item.EntityId)
                .AddParameter("Metadata", DbType.AnsiString, 4000, item.Metadata)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, item.UpdateUserCode)
                .Execute(connection, "Research");
        }

        // ── MARK READ ────────────────────────────────────────────────────────

        public static int MarkAsRead(int notificationId, int companyId, int userId, IDbConnection connection = null)
        {
            return Database.Update("UPDATE Notification SET IsRead=1, ReadAt=SYSTIMESTAMP, UpdateDate=SYSTIMESTAMP WHERE NotificationId=:NotificationId AND CompanyId=:CompanyId AND UserId=:UserId AND IsRead=0")
                .AddParameter("NotificationId", DbType.Decimal, 9, notificationId)
                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                .AddParameter("UserId", DbType.Decimal, 9, userId)
                .Execute(connection, "Research");
        }

        public static int MarkAllAsRead(int companyId, int userId, IDbConnection connection = null)
        {
            return Database.Update("UPDATE Notification SET IsRead=1, ReadAt=SYSTIMESTAMP, UpdateDate=SYSTIMESTAMP WHERE CompanyId=:CompanyId AND UserId=:UserId AND IsRead=0")
                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                .AddParameter("UserId", DbType.Decimal, 9, userId)
                .Execute(connection, "Research");
        }

        // ── RETRIEVE ─────────────────────────────────────────────────────────

        public static Architect.API.Core.Contracts.Notifications.Notification Retrieve(int notificationId, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.Notifications.Notification result = null;
            Database.Select("SELECT NotificationId, CompanyId, UserId, Title, Message, Type, Category, EntityType, EntityId, Metadata, IsRead, ReadAt, UpdateUserCode, UpdateDate, CreatedAt FROM Notification WHERE NotificationId=:NotificationId AND CompanyId=:CompanyId")
                .AddParameter("NotificationId", DbType.Decimal, 9, notificationId)
                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                .Query(connection, "Research", new Action<IDataReader>(reader => { result = DataReaderToNotification(reader); }));
            return result;
        }

        public static List<Architect.API.Core.Contracts.Notifications.Notification> RetrieveByUser(int companyId, int userId, bool onlyUnread, int beginIndex, int endIndex, IDbConnection connection = null)
        {
            var result = new List<Architect.API.Core.Contracts.Notifications.Notification>();
            string unreadFilter = onlyUnread ? " AND IsRead=0" : string.Empty;
            if (beginIndex <= 0) beginIndex = 1;
            if (endIndex <= 0 || endIndex < beginIndex) endIndex = int.MaxValue;

            Database.Select("SELECT * FROM (SELECT NotificationId, CompanyId, UserId, Title, Message, Type, Category, EntityType, EntityId, Metadata, IsRead, ReadAt, UpdateUserCode, UpdateDate, CreatedAt, ROW_NUMBER() OVER (ORDER BY CreatedAt DESC) RowNumber FROM Notification WHERE CompanyId=:CompanyId AND UserId=:UserId" + unreadFilter + ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                .AddParameter("UserId", DbType.Decimal, 9, userId)
                .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                .Query(connection, "Research", new Action<IDataReader>(reader => { result.Add(DataReaderToNotification(reader)); }));
            return result;
        }

        public static int CountUnread(int companyId, int userId, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(NotificationId) FROM Notification WHERE CompanyId=:CompanyId AND UserId=:UserId AND IsRead=0")
                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                .AddParameter("UserId", DbType.Decimal, 9, userId)
                .QueryScalar<Decimal>(connection, "Research");
        }

        public static int Count(int companyId, int userId, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(NotificationId) FROM Notification WHERE CompanyId=:CompanyId AND UserId=:UserId")
                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                .AddParameter("UserId", DbType.Decimal, 9, userId)
                .QueryScalar<Decimal>(connection, "Research");
        }

        // ── DELETE ───────────────────────────────────────────────────────────

        public static int Delete(int notificationId, int companyId, int userId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM Notification WHERE NotificationId=:NotificationId AND CompanyId=:CompanyId AND UserId=:UserId")
                .AddParameter("NotificationId", DbType.Decimal, 9, notificationId)
                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                .AddParameter("UserId", DbType.Decimal, 9, userId)
                .Execute(connection, "Research");
        }

        // ── LAST KEY ─────────────────────────────────────────────────────────

        public static int RetrieveLastKey(IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT NVL(MAX(NotificationId), 0) FROM Notification")
                .QueryScalar<Decimal>(connection, "Research");
        }

        // ── READER ───────────────────────────────────────────────────────────

        public static Architect.API.Core.Contracts.Notifications.Notification DataReaderToNotification(IDataReader reader, Architect.API.Core.Contracts.Notifications.Notification item = null)
        {
            if (item == null) item = new Architect.API.Core.Contracts.Notifications.Notification();
            item.NotificationId = reader.IntegerValue("NotificationId");
            item.CompanyId      = reader.IntegerValue("CompanyId");
            item.UserId         = reader.IntegerValue("UserId");
            item.Title          = reader.StringValue("Title");
            item.Message        = reader.StringValue("Message");
            item.Type           = reader.StringValue("Type");
            item.Category       = reader.StringValue("Category");
            item.EntityType     = reader.IntegerValue("EntityType");
            item.EntityId       = reader.Integer64Value("EntityId");
            item.Metadata       = reader.StringValue("Metadata");
            item.IsRead         = reader.IntegerValue("IsRead") == 1;
            item.ReadAt         = reader.DateTimeNullableValue("ReadAt");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateDate     = reader.DateTimeValue("UpdateDate");
            item.CreatedAt      = reader.DateTimeValue("CreatedAt");
            return item;
        }
    }
}