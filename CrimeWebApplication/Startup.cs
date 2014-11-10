using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrimeWebApplication.Startup))]
namespace CrimeWebApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
