using IdentityFromScratch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityFromScratch.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login(string returnUrl)
        {
            LoginModel model = new LoginModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var ctx = Request.GetOwinContext();
            var authMgr = ctx.Authentication;
            var userMgr = ctx.GetUserManager<UserManager<IdentityUser>>();

            var newUser = userMgr.Find(model.Email, model.Password);

            if (newUser != null)
            {
                var loginUser = userMgr.CreateIdentity(newUser, DefaultAuthenticationTypes.ApplicationCookie);
                authMgr.SignIn(loginUser);
            }

            if (string.IsNullOrEmpty(model.ReturnUrl) || !Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(Url.Action("Index", "Home"));
            }
            return Redirect(model.ReturnUrl);
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authMgr = ctx.Authentication;

            authMgr.SignOut("ApplicationCookie");

            return RedirectToAction("Login");
        }
    }
}