using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

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

            App.CreatePerOwinContext(()=>new ScratchDbContext());

            App.CreatePerOwinContext<UserManager<IdentityUser>>((options,context) => 
            new UserManager<IdentityUser>(new UserStore<IdentityUser>(context.Get<ScratchDbContext>())));

            App.CreatePerOwinContext<RoleManager<IdentityRole>>((options, context) =>
            new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context.Get <ScratchDbContext>())));
        }            
    }
}