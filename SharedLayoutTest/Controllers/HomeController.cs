using SharedLayoutTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharedLayoutTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TipModel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TipModel model)
        {
            model.Symbol = "$";
            return View(model);
        }
    }
}