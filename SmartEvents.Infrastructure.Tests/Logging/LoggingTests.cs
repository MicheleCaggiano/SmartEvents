using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartEvents.Infrastructure.Logging;

namespace SmartEvents.Infrastructure.Tests.Logging
{
    [TestClass]
    public class LoggingTests
    {
        [TestMethod]
        public void LogInfo()
        {
            Log.Info("Test message");
        }
    }
}
