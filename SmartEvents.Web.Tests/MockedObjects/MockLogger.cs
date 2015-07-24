using System;
using System.Diagnostics;
using Moq;
using SmartEvents.Infrastructure.Logging.Interfaces;

namespace SmartEvents.Web.Tests.MockedObjects
{
    public class MockLogger : IMock<ILog>
    {
        private readonly Mock<ILog> _mockLogger;

        public MockLogger()
        {
            _mockLogger = new Mock<ILog>();
            _mockLogger.Setup(x => x.Error(It.IsAny<string>())).Callback((string message) => Error(message));
            _mockLogger.Setup(x => x.Critical(It.IsAny<string>())).Callback((string message) => Critical(message));
            _mockLogger.Setup(x => x.Info(It.IsAny<string>())).Callback((string message) => Info(message));
            _mockLogger.Setup(x => x.Warning(It.IsAny<string>())).Callback((string message) => Warning(message));

            _mockLogger.Setup(x => x.ErrorFormat(It.IsAny<string>(), It.IsAny<object[]>())).Callback((string message, object[] args) => ErrorFormat(message, args));
            _mockLogger.Setup(x => x.CriticalFormat(It.IsAny<string>(), It.IsAny<object[]>())).Callback((string message, object[] args) => CriticalFormat(message, args));
            _mockLogger.Setup(x => x.InfoFormat(It.IsAny<string>(), It.IsAny<object[]>())).Callback((string message, object[] args) => InfoFormat(message, args));
            _mockLogger.Setup(x => x.WarningFormat(It.IsAny<string>(), It.IsAny<object[]>())).Callback((string message, object[] args) => WarningFormat(message, args));
        }

        public void Error(string message)
        {
            Trace.WriteLine(message);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            Trace.WriteLine(string.Format(format, args));
        }

        public void Critical(string message)
        {
            Trace.WriteLine(message);
        }

        public void CriticalFormat(string format, params object[] args)
        {
            Trace.WriteLine(string.Format(format, args));
        }

        public void Info(string message)
        {
            Trace.WriteLine(message);
        }

        public void InfoFormat(string format, params object[] args)
        {
            Trace.WriteLine(string.Format(format, args));
        }

        public void Warning(string message)
        {
            Trace.WriteLine(message);
        }

        public void WarningFormat(string format, params object[] args)
        {
            Trace.WriteLine(string.Format(format, args));
        }

        public ILog Object
        {
            get { return _mockLogger.Object; }
        }

        public MockBehavior Behavior
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool CallBase
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DefaultValue DefaultValue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
