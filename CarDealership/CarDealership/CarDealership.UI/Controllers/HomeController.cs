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
    }
}