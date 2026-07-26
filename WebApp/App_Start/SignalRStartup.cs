using Architect.API.Core.Business.Notifications;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(aliados.SignalRStartup))]

namespace aliados
{
    /// <summary>
    /// Startup OWIN para SignalR.
    /// Tambien registra los delegados de NotificationPush para que Business
    /// pueda disparar SignalR sin referenciar el WebApp directamente.
    /// </summary>
    public class SignalRStartup
    {
        public void Configuration(IAppBuilder app)
        {
            // Registrar delegados — Business llama a estos sin saber del Hub
            NotificationPush.ToUser      = (userId, notification) => Hubs.NotificationHub.PushToUser(userId, notification);
            NotificationPush.UnreadCount = (userId, count)        => Hubs.NotificationHub.PushUnreadCount(userId, count);

            app.MapSignalR();
        }
    }
}