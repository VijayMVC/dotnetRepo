using CarDealership.Data.Repositories;
using CarDealership.Models;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "sales, admin")]
    public class SalesController : Controller
    {
        IVehicleRepo repo = VehicleRepoFactory.Create();
        CarDealershipDBContext context = new CarDealershipDBContext();

        public ActionResult SalesIndex()
        {
            var input = repo.GetPurchaseTypes();
            var viewmodel = new PurchaseVM();
            viewmodel.SetPurchaseTypeItems(input);
            return View(viewmodel);  
        }

        [HttpPost]
        public ActionResult SalesIndex(PurchaseVM model)
        {
            model.Purchase.PurchaseDate = DateTime.Now;
            repo.AddPurchase(model.Purchase);
            return RedirectToAction("SalesIndex");
        }
    }
}