using System;
using Microsoft.Practices.Unity;
using SmartEvents.DAL.Interfaces;
using SmartEvents.DAL.Repositories;
using SmartEvents.Infrastructure.Logging;
using SmartEvents.Infrastructure.Logging.Interfaces;
using SmartEvents.Web.Controllers;

namespace SmartEvents.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // Types registration. Example: container.RegisterType<IProductRepository, ProductRepository>();
            // Controllers binding
            container.RegisterType<AccountController>(new InjectionConstructor())
                .RegisterType<ManageController>(new InjectionConstructor());

            // Repositories binding
            container.RegisterType(typeof(IBondSystemRepository<>), typeof(BondSystemRepository<>))
                .RegisterType(typeof(INetGammaRepository<>), typeof(NetGammaRepository<>))
                .RegisterType(typeof(IIndustrialRepository<>), typeof(IndustrialRepository<>));
            //.RegisterType(typeof(IRepository<>), typeof(NetGammaRepository<>), "NetGammaContext");

            // Logger registration: singleton
            container.RegisterType<ILog, EnterpriseLibraryLogger>(new ContainerControlledLifetimeManager());
        }
    }
}
