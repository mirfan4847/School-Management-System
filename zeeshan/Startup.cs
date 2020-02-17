using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(zeeshan.Startup))]
namespace zeeshan
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
