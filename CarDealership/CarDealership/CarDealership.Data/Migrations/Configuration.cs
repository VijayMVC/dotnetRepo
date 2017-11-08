//namespace CarDealership.Data.Migrations
//{
//    using CarDealership.Models;
//    using CarDealership.Models.Tables;
//    using Microsoft.AspNet.Identity;
//    using Microsoft.AspNet.Identity.EntityFramework;
//    using System;
//    using System.Collections.Generic;
//    using System.Data.Entity;
//    using System.Data.Entity.Migrations;
//    using System.Linq;

//    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.Models.CarDealershipDBContext>
//    {
//        public Configuration()
//        {
//            AutomaticMigrationsEnabled = false;
//        }

//        protected override void Seed(CarDealership.Models.CarDealershipDBContext context)
//        {
//            var userMgr = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
//            var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

//            if (!roleMgr.RoleExists("sales"))
//            {
//                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
//                role.Name = "sales";
//                roleMgr.Create(role);
//            }

//            if (!userMgr.Users.Any(u => u.UserName == "sales"))
//            {
//                var user = new IdentityUser()
//                {
//                    UserName = "sales"
//                };
//                userMgr.Create(user, "testing123");
//            }
//            var findmanager = userMgr.FindByName("sales");
//            // create the user with the manager class
//            if (!userMgr.IsInRole(findmanager.Id, "sales"))
//            {
//                userMgr.AddToRole(findmanager.Id, "sales");
//            }

//            if (!roleMgr.RoleExists("admin"))
//            {
//                roleMgr.Create(new IdentityRole() { Name = "admin" });
//            }

//            if (!userMgr.Users.Any(u => u.UserName == "admin"))
//            {
//                var user = new IdentityUser()
//                {
//                    UserName = "admin"
//                };
//                userMgr.Create(user, "testing123");
//            }
//            var finduser = userMgr.FindByName("admin");
//            // create the user with the admin class
//            if (!userMgr.IsInRole(finduser.Id, "admin"))
//            {
//                userMgr.AddToRole(finduser.Id, "admin");
//            }

//            context.BodyTypes.AddOrUpdate(t => t.BodyTypeName,
//                new BodyType
//                {
//                    BodyTypeName = "Two-Door Car"
//                },
//                new BodyType
//                {
//                    BodyTypeName = "Four-Door Car"
//                },
//                new BodyType
//                {
//                    BodyTypeName = "Sports-Utility Vehicle"
//                },
//                new BodyType
//                {
//                    BodyTypeName = "Pickup"
//                },
//                new BodyType
//                {
//                    BodyTypeName = "Crossover"
//                }
//                );

//            context.Makes.AddOrUpdate(m => m.MakeName,
//                new Make
//                {
//                    MakeName = "Mazda",
//                    AddedDate = DateTime.Parse("11/4/2017"),
//                    EmployeeID = 1,
//                },
//                new Make
//                {
//                    MakeName = "Toyota",
//                    AddedDate = DateTime.Parse("11/4/2017"),
//                    EmployeeID = 1,
//                },
//                new Make
//                {
//                    MakeName = "Chevy",
//                    AddedDate = DateTime.Parse("11/4/2017"),
//                    EmployeeID = 1,
//                }
//                );

//            context.CarModels.AddOrUpdate(cm => cm.ModelName,
//                new CarModel
//                {
//                    ModelName = "3",
//                    MakeID = 1,
//                    AddedDate = DateTime.Parse("11/4/2017"),
//                    BodyTypeID = 2, 
//                    EmployeeID = 1
//                },
//                new CarModel
//                {
//                    ModelName = "Corolla",
//                    MakeID = 2,
//                    AddedDate = DateTime.Parse("11/4/2017"),
//                    BodyTypeID = 1,
//                    EmployeeID = 1
//                },
//                new CarModel
//                {
//                    ModelName = "Silverado",
//                    MakeID = 3,
//                    AddedDate = DateTime.Parse("11/4/2017"),
//                    BodyTypeID = 3,
//                    EmployeeID = 1
//                }
//                );

//            context.Contacts.AddOrUpdate(c => c.Email,
//                new ContactUs
//                {
//                    FirstName = "Jake",
//                    LastName = "Ganser",
//                    Email = "jake.ganser@gmail.com",
//                    Phone = "763-242-5080",
//                    Message = "I would like to talk with a sales person to learn more about this vehicle",
//                    VinNumber = "4T3ZF13C12U459747"                 
//                },
//                new ContactUs
//                {
//                    FirstName = "Ashley",
//                    LastName = "Weber",
//                    Email = "AWebs@gmail.com",
//                    Phone = "763-242-2344",
//                    Message = "Do you have this vehicle with leather seats?",
//                    VinNumber = "1FAFP53222G297529"
//                }
//                );

//            context.Customers.AddOrUpdate(c => c.Email,
//                new Customer
//                {
//                    FirstName = "Bill",
//                    LastName = "Johnson",
//                    PurchaseID = 1,
//                    Email = "bill.johnson@gmail.com",
//                    Phone = "111-111-1111",
//                    City = "Anoka",
//                    State = "MN",
//                    Street1 = "7750 149th Ave",
//                    PostalCode = "55303"
//                });

//            context.Employees.AddOrUpdate(e => e.Email,
//                new Employee
//                {
//                    FirstName = "Joe",
//                    LastName = "Miller",
//                    Email = "jmiller@guildcars.com",
//                    Phone = "222-222-2222",
//                    Street1 = "1234 Main Street",
//                    City = "Minneapolis",
//                    State = "MN",
//                    PostalCode = "55121"
//                }
//                );

//            context.PurchaseTypes.AddOrUpdate(pt => pt.PurchaseTypeName,
//                new PurchaseType
//                {
//                    PurchaseTypeName = "Credit",
//                },
//                new PurchaseType
//                {
//                    PurchaseTypeName = "Finance",
//                },
//                new PurchaseType
//                {
//                    PurchaseTypeName = "Cash",
//                }
//                );

//            context.Purchases.AddOrUpdate(p => p.PurchaseID,
//                new Purchase
//                {
//                    PurchaseDate = DateTime.Parse("11/4/17"),
//                    PurchasePrice = 16000M,
//                    PurchaseTypeID = 1,
//                    VinNumber = "4T3ZF13C12U459747",
//                }
//                );

//            context.Specials.AddOrUpdate(sp => sp.SpecialName,
//                new Special
//                {
//                    SpecialName = "Happy New Year - $1000 Off",
//                    Description = "Get $1000 off purchase price of any new vehicle!",
//                    value = 1000,
//                    BeginDate = DateTime.Parse("1/1/18"),
//                    EndDate = DateTime.Parse("2/28/18")
//                }
//                );

//            context.Vehicles.AddOrUpdate(v => v.VinNumber,
//                new Vehicle
//                {
//                    VehicleID = 1,
//                    Color = "Meteorite Grey",
//                    Description = "Fancy new Mazda 3",
//                    Interior = "Leather",
//                    IsAvailable = false,
//                    IsFeatured = false,
//                    IsNew = true,
//                    Mileage = 520,
//                    CarModel = new CarModel
//                    {
//                        CarModelID = 1,
//                        ModelName = "3",      
//                    },
//                    CarMake = new Make
//                    {
//                        MakeID = 1,
//                        MakeName = "Mazda"
//                    },
//                    CarBody = new BodyType
//                    {
//                        BodyTypeID = 1,
//                        BodyTypeName = "Car"
//                    },
//                    MSRP = 20000M,
//                    SalePrice = 16000M,
//                    IsAutomatic = false,
//                    VinNumber = "4T3ZF13C12U459747",
//                    Year = 2017
//                },
//                new Vehicle
//                {
//                    Color = "Red",
//                    Description = "This is a two-door Toyota Corolla",
//                    Interior = "Cloth",
//                    IsAvailable = true,
//                    IsFeatured = true,
//                    IsNew = true,
//                    Mileage = 300,
//                    ModelID = 2,
//                    MSRP = 16000M,
//                    SalePrice = 16000M,
//                    IsAutomatic = true,
//                    VinNumber = "1FAFP53222G297529",
//                    Year = 2017
//                },
//                new Vehicle
//                {
//                    Color = "Electric Blue",
//                    Description = "This is a car",
//                    Interior = "Cloth",
//                    IsAvailable = true,
//                    IsFeatured = true,
//                    IsNew = true,
//                    Mileage = 520,
//                    ModelID = 3,
//                    MSRP = 20000M,
//                    SalePrice = 16000M,
//                    IsAutomatic = false,
//                    VinNumber = "ZFF65THA9D0186686",
//                    Year = 2016
//                },
//                new Vehicle
//                {
//                    Color = "Green",
//                    Description = "Another fast car here",
//                    Interior = "Leather",
//                    IsAvailable = true,
//                    IsFeatured = false,
//                    IsNew = false,
//                    Mileage = 20000,
//                    ModelID = 1,
//                    MSRP = 20000M,
//                    SalePrice = 16000M,
//                    IsAutomatic = false,
//                    VinNumber = "4T3ZF13C12U423456",
//                    Year = 2017
//                },
//                new Vehicle
//                {
//                    Color = "Rust",
//                    Description = "This is an old beat up truck",
//                    Interior = "Cloth",
//                    IsAvailable = true,
//                    IsFeatured = true,
//                    IsNew = false,
//                    Mileage = 150000,
//                    ModelID = 3,
//                    MSRP = 50000M,
//                    SalePrice = 25000M,
//                    IsAutomatic = false,
//                    VinNumber = "JA4NW61S23J021156",
//                    Year = 2006
//                },
//                new Vehicle
//                {
//                    Color = "Matte Black",
//                    Description = "This car is spectacular",
//                    Interior = "Leather",
//                    IsAvailable = true,
//                    IsFeatured = true,
//                    IsNew = true,
//                    Mileage = 12,
//                    ModelID = 3,
//                    MSRP = 50000M,
//                    SalePrice = 50000M,
//                    IsAutomatic = true,
//                    VinNumber = "1HGCR2F32DA718943",
//                    Year = 2017
//                }
//                );
//        }
//    }
//}
