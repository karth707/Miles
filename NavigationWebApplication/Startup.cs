using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NavigationWebApplication.Startup))]
namespace NavigationWebApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
