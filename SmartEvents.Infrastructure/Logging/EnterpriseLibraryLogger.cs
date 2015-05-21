using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SmartEvents.Infrastructure.Logging.Interfaces;

namespace SmartEvents.Infrastructure.Logging
{
    public class EnterpriseLibraryLogger : ILogger
    {
        public EnterpriseLibraryLogger()
        {
            IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
            var logWriterFactory = new LogWriterFactory(configurationSource);
            var databaseProviderFactory = new DatabaseProviderFactory();
            databaseProviderFactory.Create("BondSystemContext");
            DatabaseFactory.SetDatabaseProviderFactory(databaseProviderFactory);
            Logger.SetLogWriter(logWriterFactory.Create());
            WriteMessage("Logger enabled", TraceEventType.Information);
        }

        public void Error(string message)
        {
            WriteMessage(message, TraceEventType.Error);
        }

        public void ErrorFormat(string message, params object[] args)
        {
            Error(string.Format(message, args));
        }

        public void Critical(string message)
        {
            WriteMessage(message, TraceEventType.Critical);
        }

        public void CriticalFormat(string message, params object[] args)
        {
            Critical(string.Format(message, args));
        }

        public void Info(string message)
        {
            WriteMessage(message, TraceEventType.Information);
        }

        public void InfoFormat(string message, params object[] args)
        {
            Info(string.Format(message, args));
        }

        public void Warning(string message)
        {
            WriteMessage(message, TraceEventType.Warning);
        }

        public void WarningFormat(string message, params object[] args)
        {
            Warning(string.Format(message, args));
        }

        private void WriteMessage(string message, TraceEventType severity, int priority = 100)
        {
            if (Logger.IsLoggingEnabled())
            {
                Logger.Write(new LogEntry { Message = message, Severity = severity, Priority = priority });
            }
        }
    }
}
