using Microsoft.Owin;
using Owin;
using SmartEvents.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace SmartEvents.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
