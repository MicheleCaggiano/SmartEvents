namespace SmartEvents.Infrastructure.Logging.Interfaces
{
  public interface ILogger
  {
  }

  public interface IEnterpriseLog
  {
    void Error(string message);
    void ErrorFormat(string format, params object[] args);
    void Critical(string message);
    void CriticalFormat(string format, params object[] args);
    void Info(string message);
    void InfoFormat(string format, params object[] args);
    void Warning(string message);
    void WarningFormat(string format, params object[] args);
  }
}
