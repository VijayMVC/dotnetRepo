using NewTipCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewTipCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
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
        public ActionResult CalculationReturn(decimal Bill, decimal TipPercent)
        {
            var model = new TipModel();
            decimal tipPercent = new decimal();
            decimal.TryParse(Request.Form["TipPercent"],out tipPercent);
            model.Bill = decimal.Parse(Request.Form["Bill"]);
            model.Tip = tipPercent * Bill;
            model.Total = model.Bill + model.Tip;

            return View("CalculationReturn", model);
        }
    }
}