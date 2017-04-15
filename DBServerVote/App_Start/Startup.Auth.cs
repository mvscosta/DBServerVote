using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;

namespace DBServerVote
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            var cookieAuth = new CookieAuthenticationOptions()
            {
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                LoginPath = new PathString("https://login.windows.net/0ead4727-699f-4850-bf36-3d1d79f1113e/wsfed"),
                CookieHttpOnly = false,
                ExpireTimeSpan = new System.TimeSpan(0, 1, 0, 0, 0),//1hora
                SlidingExpiration = true
            };
            app.UseCookieAuthentication(cookieAuth);

            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
                    TokenValidationParameters = new TokenValidationParameters {
                         ValidAudience = ConfigurationManager.AppSettings["ida:Audience"]
                    },
                });
        }
    }
}
