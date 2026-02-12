using Hangfire;
using Hangfire.Logging;
using Hangfire.MemoryStorage;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Utilities.Contracts
{
    public class CustomLogger : ILog
    {
        public static IEnumerable<IDisposable> GetHangfireServers()
        {
            Hangfire.GlobalConfiguration.Configuration
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMemoryStorage()
                .UseLogProvider(new Architect.Utilities.Contracts.CustomLogProvider());

            var options = new BackgroundJobServerOptions
            {
                SchedulePollingInterval = TimeSpan.FromMinutes(1)
            };
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0 });
            yield return new BackgroundJobServer(options);
        }

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
