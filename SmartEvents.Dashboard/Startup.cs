using Microsoft.Owin;
using Owin;
using TangOrganizer.Dashboard;

[assembly: OwinStartup(typeof(Startup))]
namespace TangOrganizer.Dashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
