using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartEvents.Infrastructure.Logging;
using SmartEvents.Infrastructure.Logging.Interfaces;

namespace SmartEvents.Infrastructure.Tests.Logging
{
    [TestClass]
    public class LoggingTests
    {
        public ILogger Log { get; private set; }

        [TestInitialize]
        public void Initialize()
        {
            Log = new EnterpriseLibraryLogger();
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            Log = null;
        }

        [TestMethod]
        public void LogInfo()
        {
            Log.Info("Test message");
        }
    }
}
