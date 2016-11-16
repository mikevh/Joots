using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Joots.Auth.Web.Startup))]
namespace Joots.Auth.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
