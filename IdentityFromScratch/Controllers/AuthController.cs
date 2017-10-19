using IdentityFromScratch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;

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

            if (model.Email == "jake@sg.com" && model.Password == "password")
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,"Bob"),
                    new Claim(ClaimTypes.Email,"jake@sg.com"),
                    new Claim(ClaimTypes.Country,"USA")
                },
                "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authMgr = ctx.Authentication;

                authMgr.SignIn(identity);

                if (string.IsNullOrEmpty(model.ReturnUrl) || !Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(Url.Action("Index", "Home"));
                }
                return Redirect(model.ReturnUrl);
            }
            return View(model);
        }
    }
}