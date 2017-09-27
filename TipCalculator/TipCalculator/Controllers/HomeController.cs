using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipCalculator.Models;

namespace TipCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Path1(decimal bill, decimal tip)
        {
            var model = new TipModel();

            model.Bill = bill;
            model.Tip = tip * bill;
            model.Total = model.Bill + model.Tip;

            return View(model);
        }

        [HttpGet]
        public ActionResult Tip(TipModel t)
        {
            return View(t);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form1(decimal bill, decimal tip)
        {
            var model = new TipModel();

            model.Bill = bill;
            model.Tip = tip;

            return View(model);
        }

        [HttpPost]
        public ActionResult Form1(TipModel t)
        {
            return View(t);
        }
    }
}