using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.Storage;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using Architect.Utilities.Extensions;
using System.Linq;
using Hangfire.Logging;

namespace aliados
{
    public class Global : HttpApplication
    {

        private IEnumerable<IDisposable> GetHangfireServers()
        {
            Hangfire.GlobalConfiguration.Configuration
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMemoryStorage()
                .UseLogProvider(new CustomLogProvider());

            var options = new BackgroundJobServerOptions
            {
                SchedulePollingInterval = TimeSpan.FromMinutes(1)
            };
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0 });
            yield return new BackgroundJobServer(options);
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            // Registrar delegados SignalR. owin:AutomaticAppStartup=false por eso va aqui.
            Architect.API.Core.Business.Notifications.NotificationPush.ToUser      = (userId, notification) => aliados.Hubs.NotificationHub.PushToUser(userId, notification);
            Architect.API.Core.Business.Notifications.NotificationPush.UnreadCount = (userId, count)        => aliados.Hubs.NotificationHub.PushUnreadCount(userId, count);
            AreaRegistration.RegisterAllAreas();

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            HangfireAspNet.Use(GetHangfireServers);

            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time");
            var fechaCentroamerica = TimeZoneInfo.ConvertTime(DateTime.UtcNow, timeZone);

            if (!Architect.Utilities.Helpers.Settings.StringValue("Working.Mode", "Development").Equals("Development", StringComparison.CurrentCultureIgnoreCase))
            {


                // Se calendariza la revisión de solicitudes de inclusión por parte de Bayer.
                int interval = Convert.ToInt32(ConfigurationManager.AppSettings["Evicertia.Interval.Review"]);
                if (interval > 0)
                {
                    RecurringJob.AddOrUpdate("Inclusion.EvicertiaSigned", () =>
                        Architect.API.Insurance.Business.Bayer.Inclusion.EvicertiaSigned(),
                        Cron.MinuteInterval(interval));
                    RecurringJob.AddOrUpdate("MapfreMas.EvicertiaSigned", () =>
                        Architect.API.Tron.Business.Emision.MapfreMas.EvicertiaSigned(),
                        Cron.MinuteInterval(interval));
                }


                int processReviewEveryTime = Convert.ToInt32(ConfigurationManager.AppSettings["Process.Review.EveryTime"]);
                if (processReviewEveryTime > 0)
                {
                    RecurringJob.AddOrUpdate("OverDueSteps", () =>
                           Architect.API.Process.Business.General.Process.OverDueSteps(),
                           Cron.MinuteInterval(processReviewEveryTime));
                }

                //Monitor de transacciones de pago pendientes
                if (Architect.Utilities.Helpers.Settings.StringValue("Payment.Placetopay.Sonda.ExecutionTime").IsNotEmpty())
                {

                    RecurringJob.AddOrUpdate("Payment.Sonda",
                        () => Architect.API.Tron.Business.Backoffice.Pagos.Monitor(),
                        Architect.Utilities.Helpers.Settings.StringValue("Payment.Placetopay.Sonda.ExecutionTime"));
                }

                // Architect.API.Insurance.Business.Policy.DigitalSignature.VerifyDocuSigned();
                int docuSignInterval = Convert.ToInt32(ConfigurationManager.AppSettings["DocuSign.Interval.Review"]);
                if (docuSignInterval > 0)
                {
                    RecurringJob.AddOrUpdate("VerifyDocuSigned", () =>
                        Architect.API.Insurance.Business.Policy.DigitalSignature.VerifyDocuSigned(),
                        Cron.MinuteInterval(docuSignInterval));
                }

                // Ejecución del proceso de tokenización de tarjetas de crédito
                if (Architect.Utilities.Helpers.Settings.StringValue("Payment.Silice.Tokenize.ExecutionTime").IsNotEmpty())
                {
                    RecurringJob.AddOrUpdate("Payment.Silice.TokenizeTarjetas",
                        () => Architect.API.Tron.Business.Backoffice.v2.Pagos.TokenizeTarjetas(string.Empty),
                        Architect.Utilities.Helpers.Settings.StringValue("Payment.Silice.Tokenize.ExecutionTime"));
                }

                // Ejecución del proceso de envio al cobro de recibos con pago recurrente
                if (Architect.Utilities.Helpers.Settings.StringValue("Payment.Silice.RecurringReceipts.ExecutionTime").IsNotEmpty())
                {
                    RecurringJob.AddOrUpdate("Payment.Silice.RecurringReceipts",
                        () => Architect.API.Tron.Business.Backoffice.v2.Pagos.PendientesRecurrentesAlCobro(fechaCentroamerica, null),
                        Architect.Utilities.Helpers.Settings.StringValue("Payment.Silice.RecurringReceipts.ExecutionTime"));
                }


                // Permite el monitoreo díario de recibos pagados para polizas de viajeros.
                if (Architect.Utilities.Helpers.Settings.StringValue("Viajero.MonitorRecibosCobrado.ExecutionTime").IsNotEmpty())
                {
                    RecurringJob.AddOrUpdate("Viajero.MonitorRecibosCobrado",
                        () => Architect.API.Tron.Business.Emision.Viajero.MonitorRecibosCobrado(DateTime.Today),
                        Architect.Utilities.Helpers.Settings.StringValue("Viajero.MonitorRecibosCobrado.ExecutionTime"));
                }

                // Despachador de Jobs programados definidos en la tabla BO_SCHEDULED_JOB.
                // Por defecto se ejecuta cada hora; puede sobreescribirse con el setting
                // 'ScheduledJobs.Dispatcher.ExecutionTime' (cron).
                {
                    string scheduledJobsCron = Architect.Utilities.Helpers.Settings.StringValue("ScheduledJobs.Dispatcher.ExecutionTime");
                    if (string.IsNullOrWhiteSpace(scheduledJobsCron))
                    {
                        scheduledJobsCron = Cron.Hourly();
                    }
                    RecurringJob.AddOrUpdate("ScheduledJobs.Dispatcher",
                        () => Architect.API.Core.Business.General.ScheduledJobs.ExecuteDue(),
                        scheduledJobsCron);
                }

                // Let's also create a sample background job
                //BackgroundJob.Enqueue(() => Debug.WriteLine("Hello world from Hangfire!"));
                // BackgroundJob.Enqueue(() => test());
                //var recurringJobs = Hangfire.JobStorage.Current.GetConnection().GetRecurringJobs().ToList();                
            }

        }


    }

    public class CustomLogger : ILog
    {
        public string Name { get; set; }

        public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception = null)
        {
            if (messageFunc == null)
            {
                // Before calling a method with an actual message, LogLib first probes
                // whether the corresponding log level is enabled by passing a `null`
                // messageFunc instance.
                return logLevel > LogLevel.Info;
            }

            // Writing a message somewhere, make sure you also include the exception parameter,
            // because it usually contain valuable information, but it can be `null` for regular
            // messages.
            Architect.Utilities.Log.ErrorLog("CustomLogger", String.Format("{0}: {1} {2} {3}", logLevel, Name, messageFunc(), exception), exception);

            // Telling LibLog the message was successfully logged.
            return true;
        }
    }

    public class CustomLogProvider : ILogProvider
    {
        public ILog GetLogger(string name)
        {
            // Logger name usually contains the full name of a type that uses it,
            // e.g. "Hangfire.Server.RecurringJobScheduler". It's used to know the
            // context of this or that message and for filtering purposes.
            return new CustomLogger { Name = name };
        }
    }
}
