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
        public ActionResult AddUser(Employee m)
        {
            CarDealershipDBContext context = new CarDealershipDBContext();
            var repo = VehicleRepoFactory.Create();

            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));

            if (!userMgr.Users.Any(u => u.UserName == m.UserName))
            {
                var newUser = new AppUser()
                {
                    UserName = m.UserName,
                    Email = m.Email
                };
                userMgr.Create(newUser, m.Password);
                context.SaveChanges();
                userMgr.AddToRole(newUser.Id, m.Role);
                repo.AddEmployee(m);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var repo = VehicleRepoFactory.Create();
            var emp = repo.GetEmployeeByID(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult EditUser(Employee emp)
        {
            CarDealershipDBContext context = new CarDealershipDBContext();
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var repo = VehicleRepoFactory.Create();

            var user = userMgr.FindByName(emp.OldUserName);
            {
                user.UserName = emp.UserName;
                user.Email = emp.Email;
            };
            userMgr.Update(user);
            userMgr.ChangePassword(user.Id, emp.OldPassword, emp.Password);

            repo.EditEmployee(emp);
            return RedirectToAction("Users", "admin");
        }

        public ActionResult Makes()
        {
            var model = repo.GetMakeItems();
            return View(model);
        }

        public ActionResult AddMake()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMake(Make m)
        {
            m.AddedDate = DateTime.Today.Date;
            m.AddedBy = User.Identity.Name;
            var repo = VehicleRepoFactory.Create();
            repo.AddMake(m);

            return RedirectToAction("Makes", "admin");
        }

        public ActionResult Models()
        {
            var model = repo.GetModelItems();
            return View(model);
        }

        public ActionResult AddModel()
        {
            var makes = repo.GetMakeItems();
            var viewmodel = new AddModelVM();
            viewmodel.SetMakeItems(makes);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult AddModel(AddModelVM m)
        {
            m.CModel.AddedDate = DateTime.Today;
            m.CModel.AddedBy = User.Identity.Name;
            repo.AddModel(m.CModel);

            return RedirectToAction("Models", "admin");
        }
    }
}