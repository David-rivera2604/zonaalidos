using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using Hangfire;
using Hangfire.MemoryStorage;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using Architect.Utilities.Extensions;

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

            // Let's also create a sample background job
            //BackgroundJob.Enqueue(() => Debug.WriteLine("Hello world from Hangfire!"));
            // BackgroundJob.Enqueue(() => test());

            // Se calendariza la revisión de solicitudes de inclusión por parte de Bayer.
            int interval = Convert.ToInt32(ConfigurationManager.AppSettings["Evicertia.Interval.Review"]);
            if (interval > 0)
            {
                RecurringJob.AddOrUpdate(() =>
                    Architect.API.Insurance.Business.Bayer.Inclusion.EvicertiaSigned(),
                    Cron.MinuteInterval(interval));
                RecurringJob.AddOrUpdate(() =>
                    Architect.API.Tron.Business.Emision.MapfreMas.EvicertiaSigned(),
                    Cron.MinuteInterval(interval));
            }

            //int agentCode = Convert.ToInt32(ConfigurationManager.AppSettings["Purdy.Service.AgentCode"]);
            //if (agentCode > 0)
            //    RecurringJob.AddOrUpdate(() =>
            //        Architect.API.Tron.Business.Siniestro.Purdy.PurdyServiceRequests(agentCode), Cron.Daily(1));
            int processReviewEveryTime = Convert.ToInt32(ConfigurationManager.AppSettings["Process.Review.EveryTime"]);
            if (processReviewEveryTime > 0)
            {
                RecurringJob.AddOrUpdate(() =>
                       Architect.API.Core.Business.General.Process.OverDueSteps(),
                       Cron.MinuteInterval(processReviewEveryTime));
            }

            //Monitor de transacciones de pago pendientes
            if (Architect.Utilities.Helpers.Settings.StringValue("Payment.Placetopay.Sonda.ExecutionTime").IsNotEmpty())
            {
                
                RecurringJob.AddOrUpdate("Payment.Sonda", 
                    () => Architect.API.Tron.Business.Backoffice.Pagos.Monitor(),
                    Architect.Utilities.Helpers.Settings.StringValue("Payment.Placetopay.Sonda.ExecutionTime"), TimeZoneInfo.Local);
            }

           // Architect.API.Insurance.Business.Policy.DigitalSignature.VerifyDocuSigned();
            int docuSignInterval = Convert.ToInt32(ConfigurationManager.AppSettings["DocuSign.Interval.Review"]);
            if (docuSignInterval > 0)
            {
                RecurringJob.AddOrUpdate(() =>
                    Architect.API.Insurance.Business.Policy.DigitalSignature.VerifyDocuSigned(),
                    Cron.MinuteInterval(interval));
            }

        }


    }

}