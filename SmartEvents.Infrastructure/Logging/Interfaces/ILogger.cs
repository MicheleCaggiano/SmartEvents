namespace SmartEvents.Infrastructure.Logging.Interfaces
{
    public interface ILogger
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
