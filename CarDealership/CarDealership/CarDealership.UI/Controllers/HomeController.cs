using CarDealership.Data.Repositories;
using CarDealership.Models;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        [HttpGet]
        public ActionResult NewInventory()
        {
            ViewBag.Title = "New Inventory";
            return View();
        }

        [HttpGet]
        public ActionResult UsedInventory()
        {
            ViewBag.Title = "Used Inventory";
            return View();
        }

        [HttpGet]
        public ActionResult ContactUs()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(ContactUs ct)
        {
            var repo = VehicleRepoFactory.Create();
            var context = new CarDealershipDBContext();

            if (ModelState.IsValid)
            {
                ContactUs contact = new ContactUs
                {
                    ContactUsID = ct.ContactUsID,
                    Email = ct.Email,
                    FirstName = ct.FirstName,
                    LastName = ct.LastName,
                    Message = ct.Message,
                    Phone = ct.Phone,
                    Date = DateTime.Now
                };
                repo.AddContact(contact);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(ct);
            }
        }

        [HttpGet]
        public ActionResult Specials()
        {
            ViewBag.Title = "Specials";
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginVM();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            // attempt to load the user with this password
            var user = userManager.Find(model.UserName, model.Password);

            // user will be null if the password or user name is bad
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
            else
            {
                // successful login, set up their cookies and send them on their way
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = true }, identity);

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index");
            }
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