using System;

namespace Architect.API.Core.Business.Notifications
{
    /// <summary>
    /// Puente desacoplado entre Business y SignalR.
    /// Business no referencia WebApp — el Hub se registra en startup via delegados.
    /// </summary>
    public static class NotificationPush
    {
        /// <summary>
        /// Registrar en SignalRStartup.cs:
        ///   NotificationPush.ToUser = (userId, n) => NotificationHub.PushToUser(userId, n);
        /// </summary>
        public static Action<int, Architect.API.Core.Contracts.Notifications.Notification> ToUser { get; set; }

        /// <summary>
        /// Registrar en SignalRStartup.cs:
        ///   NotificationPush.UnreadCount = (userId, count) => NotificationHub.PushUnreadCount(userId, count);
        /// </summary>
        public static Action<int, int> UnreadCount { get; set; }
    }
}