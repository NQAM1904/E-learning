using System;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using DACS.Models;

[assembly: OwinStartup(typeof(DACS.Startup))]

namespace DACS
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                //The Path For generating the Toekn
                TokenEndpointPath = new PathString("/token"),
                //Token sẽ hết hạn sau 01 năm
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(365),
                //MyAuthorizationServerProvider class will validate the user credentials
                Provider = new AuthorizationLogin()
            };
            //Token Generations
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
