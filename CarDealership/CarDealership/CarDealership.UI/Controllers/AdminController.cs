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
            var bodyTypes = repo.GetBodyTypes();
            var viewmodel = new VehicleVM();
            viewmodel.SetMakeItems(input);
            viewmodel.SetCarModelItems(mod);
            viewmodel.SetCarTypeItems();
            viewmodel.SetBodyTypeItems(bodyTypes);
            viewmodel.SetCarTransmissionItems();
            viewmodel.SetCarInteriorItems();
            viewmodel.AVehicle.IsNew = true;
            viewmodel.AVehicle.IsAutomatic = true;
            viewmodel.AVehicle.IsAvailable = true;
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult AddVehicle(VehicleVM model)
        {
            model.AVehicle.CarModel = repo.GetModelByID(model.AVehicle.CarModel.CarModelID);
            model.AVehicle.CarMake = repo.GetMakeByID(model.AVehicle.CarMake.MakeID);
            model.AVehicle.CarBody = repo.GetBodyByID(model.AVehicle.CarBody.BodyTypeID);
            repo.AddVehicle(model.AVehicle);
            return RedirectToAction("AdminIndex");
        }
    }
}