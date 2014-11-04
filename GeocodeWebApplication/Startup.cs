using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeocodeWebApplication.Startup))]
namespace GeocodeWebApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
