using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace aliados.Hubs
{
    /// <summary>
    /// Hub SignalR para el centro de notificaciones en tiempo real.
    /// Agrupa conexiones por usuario — soporta múltiples tabs simultáneos.
    /// Usar PushToUser() desde Business/Hangfire para enviar sin instanciar el Hub.
    /// </summary>
    [HubName("notificationHub")]
    public class NotificationHub : Hub
    {
        // Mapeo userId -> grupo de conexiones (múltiples tabs)
        private static readonly ConcurrentDictionary<string, byte> _connectedUsers
            = new ConcurrentDictionary<string, byte>();

        public override Task OnConnected()
        {
            string userId = GetUserId();
            if (!string.IsNullOrEmpty(userId))
            {
                Groups.Add(Context.ConnectionId, UserGroup(userId));
                _connectedUsers.TryAdd(userId, 0);
            }
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string userId = GetUserId();
            if (!string.IsNullOrEmpty(userId))
            {
                // No removemos del diccionario aquí porque puede tener más tabs abiertas
                Groups.Remove(Context.ConnectionId, UserGroup(userId));
            }
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string userId = GetUserId();
            if (!string.IsNullOrEmpty(userId))
                Groups.Add(Context.ConnectionId, UserGroup(userId));
            return base.OnReconnected();
        }

        // ────────────────────────────────────────── MÉTODOS ESTÁTICOS (server-side) ──

        /// <summary>
        /// Envía una notificación en tiempo real al usuario indicado.
        /// Llamar desde Business o Hangfire. No lanza excepción si el usuario no está conectado.
        /// </summary>
        public static void PushToUser(int receiverUserId, Architect.API.Core.Contracts.Notifications.Notification notification)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.Group(UserGroup(receiverUserId.ToString())).receiveNotification(new
            {
                notification.NotificationId,
                notification.Title,
                notification.Message,
                notification.Type,
                notification.Category,
                notification.EntityType,
                notification.EntityId,
                CreatedAt  = notification.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                notification.IsRead
            });
        }

        /// <summary>
        /// Actualiza el contador de no leídas en el badge del cliente.
        /// </summary>
        public static void PushUnreadCount(int receiverUserId, int count)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.Group(UserGroup(receiverUserId.ToString())).updateUnreadCount(count);
        }

        // ──────────────────────────────────────────────────────────── HELPERS ──

        private string GetUserId()
        {
            return Context.QueryString["userId"] ?? string.Empty;
        }

        private static string UserGroup(string userId)
        {
            return "notif_user_" + userId;
        }
    }
}
