using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;

namespace IdentityFromScratch.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder App)
        {
            App.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });
        }            
    }
}