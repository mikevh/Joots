using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;
using Joots.Res.Api.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly:OwinStartup(typeof(Joots.Res.Api.Startup))]
namespace Joots.Res.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           

            var config = new HttpConfiguration();
            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

    }
}
