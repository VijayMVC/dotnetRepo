namespace CarDealership.Data.Migrations
{
    using CarDealership.Models;
    using CarDealership.Models.Tables;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.Models.CarDealershipDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealership.Models.CarDealershipDBContext context)
        {
            var userMgr = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleMgr.RoleExists("sales"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "sales";
                roleMgr.Create(role);
            }

            if (!userMgr.Users.Any(u => u.UserName == "sales"))
            {
                var user = new IdentityUser()
                {
                    UserName = "sales"
                };
                userMgr.Create(user, "testing123");
            }
            var findmanager = userMgr.FindByName("sales");
            // create the user with the manager class
            if (!userMgr.IsInRole(findmanager.Id, "sales"))
            {
                userMgr.AddToRole(findmanager.Id, "sales");
            }

            if (!roleMgr.RoleExists("admin"))
            {
                roleMgr.Create(new IdentityRole() { Name = "admin" });
            }

            if (!userMgr.Users.Any(u => u.UserName == "admin"))
            {
                var user = new IdentityUser()
                {
                    UserName = "admin"
                };
                userMgr.Create(user, "testing123");
            }
            var finduser = userMgr.FindByName("admin");
            // create the user with the admin class
            if (!userMgr.IsInRole(finduser.Id, "admin"))
            {
                userMgr.AddToRole(finduser.Id, "admin");
            }

            context.Employees.AddOrUpdate(e => e.Email,
            new Employee
            {
                FirstName = "Joe",
                LastName = "Miller",
                EmployeeID = 1,
                Email = "jmiller@guildcars.com",
                Phone = "222-222-2222",
                Street1 = "1234 Main Street",
                City = "Minneapolis",
                State = "MN",
                PostalCode = "55121",
                Role = "Sales"
            });
            context.SaveChanges();

            context.BodyTypes.AddOrUpdate(b => b.BodyTypeName,
            new BodyType
            {
                BodyTypeID = 1,
                BodyTypeName = "Two-Door Car"
            },
            new BodyType
            {
                BodyTypeID = 2,
                BodyTypeName = "Four-Door Car"
            },
            new BodyType
            {
                BodyTypeID = 3,
                BodyTypeName = "Sports-Utility Vehicle"
            },
            new BodyType
            {
                BodyTypeID = 4,
                BodyTypeName = "Pickup"
            },
            new BodyType
            {
                BodyTypeID = 5,
                BodyTypeName = "Crossover"
            });
            context.SaveChanges();

            context.Makes.AddOrUpdate(m => m.MakeName,
            new Make
            {
                MakeID = 1,
                MakeName = "Mazda",
                AddedDate = DateTime.Parse("11/07/2017"),
                AnEmployee = context.Employees.Where(e => e.EmployeeID == 1).FirstOrDefault(),
            },
            new Make
            {
                MakeID = 2,
                MakeName = "Toyota",
                AddedDate = DateTime.Parse("11/07/2017"),
                AnEmployee = context.Employees.Where(e => e.EmployeeID == 1).FirstOrDefault(),
            },
            new Make
            {
                MakeID = 3,
                MakeName = "Chevy",
                AddedDate = DateTime.Parse("11/07/2017"),
                AnEmployee = context.Employees.Where(e => e.EmployeeID == 1).FirstOrDefault(),
            },
            new Make
            {
                MakeID = 4,
                MakeName = "BMW",
                AddedDate = DateTime.Parse("11/07/2017"),
                AnEmployee = context.Employees.Where(e => e.EmployeeID == 1).FirstOrDefault(),
            },
            new Make
            {
                MakeID = 5,
                MakeName = "Ford",
                AddedDate = DateTime.Parse("11/07/2017"),
                AnEmployee = context.Employees.Where(e => e.EmployeeID == 1).FirstOrDefault(),
            });
            context.SaveChanges();

            context.CarModels.AddOrUpdate(cm => cm.ModelName,        
            new CarModel
            {
                CarModelID = 1,
                ModelName = "3",
                AddedDate = DateTime.Parse("11/07/2017"),
                AnEmployee = context.Employees.Where(e => e.EmployeeID == 1).FirstOrDefault(),
                AMake = context.Makes.Where(e => e.MakeName == "Mazda").FirstOrDefault(),
            },
            new CarModel
            {
                CarModelID = 2,
                ModelName = "Corolla",
                AddedDate = DateTime.Parse("11/07/2017"),
                AnEmployee = context.Employees.Where(e => e.EmployeeID == 1).FirstOrDefault(),
                AMake = context.Makes.Where(e => e.MakeName == "Toyota").FirstOrDefault(),
            },
            new CarModel
            {
                CarModelID = 3,
                ModelName = "Silverado",
                AddedDate = DateTime.Parse("11/07/2017"),
                AnEmployee = context.Employees.Where(e => e.EmployeeID == 1).FirstOrDefault(),
                AMake = context.Makes.Where(e => e.MakeName == "Chevy").FirstOrDefault(),
            },
            new CarModel
            {
                CarModelID = 4,
                ModelName = "550S",
                AddedDate = DateTime.Parse("11/07/2017"),
                AnEmployee = context.Employees.Where(e => e.EmployeeID == 1).FirstOrDefault(),
                AMake = context.Makes.Where(e => e.MakeName == "BMW").FirstOrDefault(),
            },
            new CarModel
            {
                CarModelID = 5,
                ModelName = "Focus",
                AddedDate = DateTime.Parse("11/07/2017"),
                AnEmployee = context.Employees.Where(e => e.EmployeeID == 1).FirstOrDefault(),
                AMake = context.Makes.Where(e => e.MakeName == "Ford").FirstOrDefault(),
            });
            context.SaveChanges();

            context.PurchaseTypes.AddOrUpdate(p => p.PurchaseTypeName,
            new PurchaseType
            {
                PurchaseTypeID=1,
                PurchaseTypeName="Dealer Finance",
            },
            new PurchaseType
            {
                PurchaseTypeID=2,
                PurchaseTypeName="Credit",
            },
            new PurchaseType
            {
                PurchaseTypeID=3,
                PurchaseTypeName="Cash",
            });

        context.Vehicles.AddOrUpdate(v => v.Description,
            new Vehicle
            {
                VehicleID = 1,
                Color = "Meteorite Grey",
                Description = "Fancy new Mazda 3",
                Interior = "Leather",
                IsAvailable = false,
                IsFeatured = false,
                IsNew = true,
                Mileage = 520,
                CarBody = context.BodyTypes.Where(b => b.BodyTypeName == "Four-Door Car").FirstOrDefault(),
                CarMake = context.Makes.Where(m => m.MakeName == "Mazda").FirstOrDefault(),
                CarModel = context.CarModels.Where(m => m.ModelName == "3").FirstOrDefault(),
                MSRP = 20000M,
                SalePrice = 16000M,
                IsAutomatic = false,
                VinNumber = "4T3ZF13C12U459747",
                Year = 2016,
            },
            new Vehicle
            {
                VehicleID = 2,
                Color = "Red",
                Description = "This is a two-door Toyota Corolla",
                Interior = "Cloth",
                IsAvailable = true,
                IsFeatured = true,
                IsNew = true,
                Mileage = 300,
                CarModel = context.CarModels.Where(m => m.ModelName == "Corolla").FirstOrDefault(),
                CarMake = context.Makes.Where(m => m.MakeName == "Toyota").FirstOrDefault(),
                MSRP = 16000M,
                SalePrice = 16000M,
                IsAutomatic = false,
                VinNumber = "1FAFP53222G297529",
                Year = 2015,
                CarBody = context.BodyTypes.Where(b => b.BodyTypeName == "Two-Door Car").FirstOrDefault(),
            },
            new Vehicle
            {
                VehicleID = 3,
                Color = "Black",
                Description = "This is a car",
                Interior = "Leather",
                IsAvailable = true,
                IsFeatured = true,
                IsNew = true,
                Mileage = 520,
                CarMake = context.Makes.Where(m => m.MakeName == "BMW").FirstOrDefault(),
                CarModel = context.CarModels.Where(m => m.ModelName == "550S").FirstOrDefault(),
                MSRP = 20000M,
                SalePrice = 16000M,
                IsAutomatic = false,
                VinNumber = "ZFF65THA9D0186686",
                Year = 2017,
                CarBody = context.BodyTypes.Where(b => b.BodyTypeName == "Two-Door Car").FirstOrDefault(),
            },
            new Vehicle
            {
                VehicleID = 4,
                Color = "Electric Blue",
                Description = "this is car here",
                Interior = "Cloth",
                IsAvailable = true,
                IsFeatured = false,
                IsNew = false,
                Mileage = 20000,
                CarMake = context.Makes.Where(m => m.MakeName == "Ford").FirstOrDefault(),
                CarModel = context.CarModels.Where(m => m.ModelName == "Focus").FirstOrDefault(),
                MSRP = 20000M,
                SalePrice = 16000M,
                IsAutomatic = true,
                VinNumber = "4T3ZF13C12U459747",
                Year = 2017,
                CarBody = context.BodyTypes.Where(b => b.BodyTypeName == "Two-Door Car").FirstOrDefault(),
            },
            new Vehicle
            {
                VehicleID = 5,
                Color = "Black",
                Description = "This is a sweet new truck",
                Interior = "Cloth",
                IsAvailable = true,
                IsFeatured = true,
                IsNew = true,
                Mileage = 500,
                CarMake = context.Makes.Where(m => m.MakeName == "Chevy").FirstOrDefault(),
                CarModel = context.CarModels.Where(m => m.ModelName == "Silverado").FirstOrDefault(),
                MSRP = 50000M,
                SalePrice = 45000,
                IsAutomatic = false,
                VinNumber = "JA4NW61S23J021156",
                Year = 2017,
                CarBody = context.BodyTypes.Where(b => b.BodyTypeName == "Pickup").FirstOrDefault(),
            },
            new Vehicle
            {
                VehicleID = 6,
                Color = "Canary Yellow",
                Description = "This car is spectacular",
                Interior = "Leather",
                IsAvailable = true,
                IsFeatured = true,
                IsNew = true,
                Mileage = 12,
                CarMake = context.Makes.Where(m => m.MakeName == "Mazda").FirstOrDefault(),
                CarModel = context.CarModels.Where(m => m.ModelName == "3").FirstOrDefault(),
                MSRP = 50000M,
                SalePrice = 50000M,
                IsAutomatic = true,
                VinNumber = "1HGCR2F32DA718943",
                Year = 2017,
                CarBody = context.BodyTypes.Where(b => b.BodyTypeName == "Four-Door Car").FirstOrDefault(),
            });

        context.Contacts.AddOrUpdate(c => c.Email,
            new ContactUs
            {
                ContactUsID = 1,
                FirstName = "Jake",
                LastName = "Ganser",
                Email = "jake.ganser@gmail.com",
                Phone = "763-242-5080",
                Message = "I would like to talk with a sales person to learn more about this vehicle",
                Date = DateTime.Parse("11/9/2017")
            },
            new ContactUs
            {
                ContactUsID = 2,
                FirstName = "Ashley",
                LastName = "Weber",
                Email = "AWebs@gmail.com",
                Phone = "763-242-2344",
                Message = "Do you have this vehicle with leather seats?",
                Date = DateTime.Parse("11/9/2017")
            });

        context.Customers.AddOrUpdate(c => c.Email,
            new Customer
            {
                CustomerID = 1,
                FirstName = "Bill",
                LastName = "Johnson",
                Email = "bill.johnson@gmail.com",
                Phone = "111-111-1111",
                City = "Anoka",
                State = "MN",
                Street1 = "7750 149th Ave",
                PostalCode = "55303",
            });

        context.Purchases.AddOrUpdate(p => p.PurchasePrice,
            new Purchase
            {
                PurchaseID = 1,
                PurchaseDate = DateTime.Parse("11/4/17"),
                PurchasePrice = 16000M,
                APurchaseType = context.PurchaseTypes.Where(p => p.PurchaseTypeID == 1).FirstOrDefault(),
                VinNumber = "4T3ZF13C12U459747",
                ACustomer = context.Customers.Where(c => c.CustomerID ==1).FirstOrDefault(),
            });

        context.Specials.AddOrUpdate(s => s.SpecialName,
            new Special
            {
                SpecialID = 1,
                SpecialName = "Truck Month!!",
                Description = "Take $1,500 off the sales price of all new trucks in the month of November!",
                value = 1500,
                BeginDate = DateTime.Parse("11/01/2017"),
                EndDate = DateTime.Parse("11/30/2017"),
                Vehicles = context.Vehicles.Where(v => v.CarBody.BodyTypeID == 4).Where(v => v.IsNew == true).ToList()
            });
        }
    }
}
