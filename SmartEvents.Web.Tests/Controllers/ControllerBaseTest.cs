using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartEvents.Infrastructure.Logging;
using SmartEvents.Infrastructure.Logging.Interfaces;
using SmartEvents.Web.Tests.MockedObjects;

namespace SmartEvents.Web.Tests.Controllers
{
    [TestClass]
    public class ControllerBaseTest
    {
        [TestInitialize]
        public void OnInitialize()
        {
            //Re-registering types
            var container = UnityConfig.GetConfiguredContainer();
            container.RegisterType<ILogger, EnterpriseLibraryLogger>(new InjectionFactory(uc => new MockLogger().Object));
        }
    }
}
