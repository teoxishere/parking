using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace parking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var cookieOptions = new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/Auth/Login")
            };

            app.UseCookieAuthentication(cookieOptions);


            app.SetDefaultSignInAsAuthenticationType(cookieOptions.AuthenticationType);

            app.UseGoogleAuthentication(ConfigurationManager.AppSettings["GoogleClientId"], 
                ConfigurationManager.AppSettings["GoogleClientSecret"]);
        }
    }
}