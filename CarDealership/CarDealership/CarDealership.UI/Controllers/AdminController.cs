using CarDealership.Data.Repositories;
using CarDealership.Models;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            var viewmodel = new VehicleVM();
            viewmodel.AVehicle = repo.GetVehicleByID(id);
            var input = repo.GetMakeItems();
            var mod = repo.GetModelItems();
            var bodyTypes = repo.GetBodyTypes();
            viewmodel.SetMakeItems(input);
            viewmodel.SetCarModelItems(mod);
            viewmodel.SetCarTypeItems();
            viewmodel.SetBodyTypeItems(bodyTypes);
            viewmodel.SetCarTransmissionItems();
            viewmodel.SetCarInteriorItems();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult EditVehicle(VehicleVM model)
        {
            model.AVehicle.CarModel = repo.GetModelByID(model.AVehicle.CarModel.CarModelID);
            model.AVehicle.CarMake = repo.GetMakeByID(model.AVehicle.CarMake.MakeID);
            model.AVehicle.CarBody = repo.GetBodyByID(model.AVehicle.CarBody.BodyTypeID);
            repo.EditVehicle(model.AVehicle);
            return RedirectToAction("AdminIndex");
        }

        [HttpGet]
        public ActionResult Users()
        {
            var model = repo.GetUsers();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(Employee emp)
        {
                CarDealership.Models.CarDealershipDBContext context = new CarDealershipDBContext();

                var userMgr = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
                var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!userMgr.Users.Any(u => u.UserName == emp.UserName))
                {
                    var user = new IdentityUser()
                    {
                        UserName = emp.UserName
                    };
                    userMgr.Create(user, emp.Password);
                }
                var findmanager = userMgr.FindByName(emp.UserName);
                // create the user with the Sales class
                if (!userMgr.IsInRole(findmanager.Id, "sales"))
                {
                    userMgr.AddToRole(findmanager.Id, "sales");
                }

                if (!userMgr.IsInRole(findmanager.Id, "admin"))
                {
                    userMgr.AddToRole(findmanager.Id, "admin");
                }
                
                return RedirectToAction("Index", "Home");
        }

    }
}