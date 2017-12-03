using CarDealership.Data.Repositories;
using CarDealership.Models;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
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
            Vehicle vehicle = new Vehicle();
            vehicle = context.Vehicles.FirstOrDefault(v => v.VinNumber == model.AVehicle.VinNumber);
            var input = repo.GetMakeItems();
            var mod = repo.GetModelItems();
            var bodyTypes = repo.GetBodyTypes();
            model.SetMakeItems(input);
            model.SetCarModelItems(mod);
            model.SetCarTypeItems();
            model.SetBodyTypeItems(bodyTypes);
            model.SetCarTransmissionItems();
            model.SetCarInteriorItems();

            if (ModelState.IsValid)
            {
                bool errors = false;
                if (vehicle != null)
                {
                    ModelState.AddModelError("AVehicle.VinNumber", "VIN Number already exists, please re-enter");
                    errors = true;
                }
                if (model.AVehicle.Year.ToString().Length != 4 || model.AVehicle.Year < 1990 || model.AVehicle.Year > DateTime.Today.Year+1)
                {
                    ModelState.AddModelError("AVehicle.Year", "Year entered is not valid");
                    errors = true;
                }
                if (errors == true)
                {
                    return View(model);
                }

                model.AVehicle.CarModel = repo.GetModelByID(model.AVehicle.CarModel.CarModelID);
                model.AVehicle.CarMake = repo.GetMakeByName(model.AVehicle.CarMake.MakeName);
                model.AVehicle.CarBody = repo.GetBodyByID(model.AVehicle.CarBody.BodyTypeID);
                if (model.File != null)
                {
                    string pic = Path.GetFileName(model.File.FileName);
                    string path = Path.Combine(
                                           Server.MapPath("~/images"), pic);
                    // file is uploaded
                    model.File.SaveAs(path);

                    vehicle = new Vehicle
                    {
                        VehicleID = model.AVehicle.VehicleID,
                        CarBody = model.AVehicle.CarBody,
                        CarMake = model.AVehicle.CarMake,
                        CarModel = model.AVehicle.CarModel,
                        Color = model.AVehicle.Color,
                        Description = model.AVehicle.Description,
                        Interior = model.AVehicle.Interior,
                        IsAutomatic = model.AVehicle.IsAutomatic,
                        IsAvailable = model.AVehicle.IsAvailable,
                        IsFeatured = model.AVehicle.IsFeatured,
                        IsNew = model.AVehicle.IsNew,
                        Mileage = model.AVehicle.Mileage,
                        MSRP = model.AVehicle.MSRP,
                        SalePrice = model.AVehicle.SalePrice,
                        Specials = model.AVehicle.Specials,
                        VinNumber = model.AVehicle.VinNumber,
                        Year = model.AVehicle.Year,
                        ImageLocation = "images/" + Path.GetFileName(model.File.FileName),
                    };
                }
                else
                {
                    vehicle = new Vehicle
                    {
                        VehicleID = model.AVehicle.VehicleID,
                        CarBody = model.AVehicle.CarBody,
                        CarMake = model.AVehicle.CarMake,
                        CarModel = model.AVehicle.CarModel,
                        Color = model.AVehicle.Color,
                        Description = model.AVehicle.Description,
                        Interior = model.AVehicle.Interior,
                        IsAutomatic = model.AVehicle.IsAutomatic,
                        IsAvailable = model.AVehicle.IsAvailable,
                        IsFeatured = model.AVehicle.IsFeatured,
                        IsNew = model.AVehicle.IsNew,
                        Mileage = model.AVehicle.Mileage,
                        MSRP = model.AVehicle.MSRP,
                        SalePrice = model.AVehicle.SalePrice,
                        Specials = model.AVehicle.Specials,
                        VinNumber = model.AVehicle.VinNumber,
                        Year = model.AVehicle.Year
                    };
                }
                repo.AddVehicle(vehicle);
                return RedirectToAction("AdminIndex");
            }
            else
            {
                ModelState.AddModelError("AVehicle", "All fields must be complete");
                return View(model);
            }
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
            Vehicle vehicle = new Vehicle();
            vehicle = context.Vehicles.FirstOrDefault(v => v.VinNumber == model.AVehicle.VinNumber);
            var input = repo.GetMakeItems();
            var mod = repo.GetModelItems();
            var bodyTypes = repo.GetBodyTypes();
            model.SetMakeItems(input);
            model.SetCarModelItems(mod);
            model.SetCarTypeItems();
            model.SetBodyTypeItems(bodyTypes);
            model.SetCarTransmissionItems();
            model.SetCarInteriorItems();

            if (ModelState.IsValid)
            {
                bool errors = false;
                if (vehicle != null)
                {
                    ModelState.AddModelError("AVehicle.VinNumber", "VIN Number already exists, please re-enter");
                    errors = true;
                }
                if (model.AVehicle.Year.ToString().Length != 4 || model.AVehicle.Year < 1990 || model.AVehicle.Year > DateTime.Today.Year + 1)
                {
                    ModelState.AddModelError("AVehicle.Year", "Year entered is not valid");
                    errors = true;
                }
                if (errors == true)
                {
                    return View(model);
                }

                model.AVehicle.CarModel = repo.GetModelByID(model.AVehicle.CarModel.CarModelID);
                model.AVehicle.CarMake = repo.GetMakeByName(model.AVehicle.CarMake.MakeName);
                model.AVehicle.CarBody = repo.GetBodyByID(model.AVehicle.CarBody.BodyTypeID);
                if (model.File != null)
                {
                    string pic = Path.GetFileName(model.File.FileName);
                    string path = Path.Combine(
                                           Server.MapPath("~/images"), pic);
                    // file is uploaded
                    model.File.SaveAs(path);

                    vehicle = new Vehicle
                    {
                        VehicleID = model.AVehicle.VehicleID,
                        CarBody = model.AVehicle.CarBody,
                        CarMake = model.AVehicle.CarMake,
                        CarModel = model.AVehicle.CarModel,
                        Color = model.AVehicle.Color,
                        Description = model.AVehicle.Description,
                        Interior = model.AVehicle.Interior,
                        IsAutomatic = model.AVehicle.IsAutomatic,
                        IsAvailable = model.AVehicle.IsAvailable,
                        IsFeatured = model.AVehicle.IsFeatured,
                        IsNew = model.AVehicle.IsNew,
                        Mileage = model.AVehicle.Mileage,
                        MSRP = model.AVehicle.MSRP,
                        SalePrice = model.AVehicle.SalePrice,
                        Specials = model.AVehicle.Specials,
                        VinNumber = model.AVehicle.VinNumber,
                        Year = model.AVehicle.Year,
                        ImageLocation = "images/" + Path.GetFileName(model.File.FileName),
                    };
                }
                else
                {
                    vehicle = new Vehicle
                    {
                        VehicleID = model.AVehicle.VehicleID,
                        CarBody = model.AVehicle.CarBody,
                        CarMake = model.AVehicle.CarMake,
                        CarModel = model.AVehicle.CarModel,
                        Color = model.AVehicle.Color,
                        Description = model.AVehicle.Description,
                        Interior = model.AVehicle.Interior,
                        IsAutomatic = model.AVehicle.IsAutomatic,
                        IsAvailable = model.AVehicle.IsAvailable,
                        IsFeatured = model.AVehicle.IsFeatured,
                        IsNew = model.AVehicle.IsNew,
                        Mileage = model.AVehicle.Mileage,
                        MSRP = model.AVehicle.MSRP,
                        SalePrice = model.AVehicle.SalePrice,
                        Specials = model.AVehicle.Specials,
                        VinNumber = model.AVehicle.VinNumber,
                        Year = model.AVehicle.Year
                    };
                }
                repo.EditVehicle(vehicle);
                return RedirectToAction("AdminIndex");
            }
            else
            {
                ModelState.AddModelError("AVehicle", "All fields must be complete");
                return View(model);
            }
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

        [HttpGet]
        public ActionResult RemoveVehicle(int id)
        {
            repo.DeleteVehicle(id);
            return RedirectToAction("index", "Home");
        }
    }
}