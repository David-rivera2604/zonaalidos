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

namespace aliados
{
    public class Global : HttpApplication
    {

        private IEnumerable<IDisposable> GetHangfireServers()
        {
            Hangfire.GlobalConfiguration.Configuration
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMemoryStorage();

            var options = new BackgroundJobServerOptions
            {
                SchedulePollingInterval = TimeSpan.FromMinutes(1)
            };

            yield return new BackgroundJobServer(options);
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            HangfireAspNet.Use(GetHangfireServers);

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
                       Architect.API.Core.Business.General.Process.OverDueSteps(),
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
                    () => Architect.API.Tron.Business.Backoffice.v2.Pagos.TokenizeTarjetas(),
                    Architect.Utilities.Helpers.Settings.StringValue("Payment.Silice.Tokenize.ExecutionTime"));
            }

            // Ejecución del proceso de envio al cobro de recibos con pago recurrente
            if (Architect.Utilities.Helpers.Settings.StringValue("Payment.Silice.RecurringReceipts.ExecutionTime").IsNotEmpty())
            {
                RecurringJob.AddOrUpdate("Payment.Silice.RecurringReceipts",
                    () => Architect.API.Tron.Business.Backoffice.v2.Pagos.PendientesRecurrentesAlCobro(),
                    Architect.Utilities.Helpers.Settings.StringValue("Payment.Silice.RecurringReceipts.ExecutionTime"));
            }

            // Let's also create a sample background job
            //BackgroundJob.Enqueue(() => Debug.WriteLine("Hello world from Hangfire!"));
            // BackgroundJob.Enqueue(() => test());
            //var recurringJobs = Hangfire.JobStorage.Current.GetConnection().GetRecurringJobs().ToList();

        }


    }

}