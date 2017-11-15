using CarDealership.Data.Repositories;
using CarDealership.Models;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IVehicleRepo repo = VehicleRepoFactory.Create();
        CarDealershipDBContext context = new CarDealershipDBContext();

        // GET: Admin
        public ActionResult AdminIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            var input = repo.GetMakeItems();
            var mod = repo.GetModelItems();
            var viewmodel = new VehicleVM();
            viewmodel.SetMakeItems(input);
            viewmodel.SetCarModelItems(mod);
            return View(viewmodel);
        }
    }
}