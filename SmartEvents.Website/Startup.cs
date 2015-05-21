using Microsoft.Owin;
using Owin;
using SmartEvents.Website;

[assembly: OwinStartup(typeof(Startup))]
namespace SmartEvents.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
