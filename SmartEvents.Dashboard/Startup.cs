using Microsoft.Owin;
using Owin;
using SmartEvents.Dashboard;

[assembly: OwinStartup(typeof(Startup))]
namespace SmartEvents.Dashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
