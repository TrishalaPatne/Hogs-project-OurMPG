using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OurMPG.Startup))]
namespace OurMPG
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
