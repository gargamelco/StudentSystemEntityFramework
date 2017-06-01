using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SSEF.Gateway.Startup))]
namespace SSEF.Gateway
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
