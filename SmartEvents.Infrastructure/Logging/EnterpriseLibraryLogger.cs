using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SmartEvents.Infrastructure.Logging.Interfaces;

namespace SmartEvents.Infrastructure.Logging
{
  /// <summary>
  /// Singleton class for application logger
  /// </summary>
  public class Log : ILogger
  {
    private static readonly Log _instance = new Log();

    #region Singleton constructor

    public Log()
    {
      IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
      var logWriterFactory = new LogWriterFactory(configurationSource);
      var databaseProviderFactory = new DatabaseProviderFactory();
      databaseProviderFactory.Create("SmartEventsContext");
      DatabaseFactory.SetDatabaseProviderFactory(databaseProviderFactory);
      Logger.SetLogWriter(logWriterFactory.Create());
      WriteMessage("Logger enabled", TraceEventType.Information);
    }

    #endregion Singleton constructor

    public static void Error(string message)
    {
      WriteMessage(message, TraceEventType.Error);
    }

    public static void ErrorFormat(string message, params object[] args)
    {
      Error(string.Format(message, args));
    }

    public static void Critical(string message)
    {
      WriteMessage(message, TraceEventType.Critical);
    }

    public static void CriticalFormat(string message, params object[] args)
    {
      Critical(string.Format(message, args));
    }

    public static void Info(string message)
    {
      WriteMessage(message, TraceEventType.Information);
    }

    public static void InfoFormat(string message, params object[] args)
    {
      Info(string.Format(message, args));
    }

    public static void Warning(string message)
    {
      WriteMessage(message, TraceEventType.Warning);
    }

    public static void WarningFormat(string message, params object[] args)
    {
      Warning(string.Format(message, args));
    }

    private static void WriteMessage(string message, TraceEventType severity, int priority = 100)
    {
      if (Logger.IsLoggingEnabled())
      {
        Logger.Write(new LogEntry { Message = message, Severity = severity, Priority = priority });
      }
    }
  }
}
