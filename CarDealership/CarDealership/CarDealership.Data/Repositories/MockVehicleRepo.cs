using CarDealership.Models;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
    public class MockVehicleRepo : IVehicleRepo
    {
        private static List<BodyType> _bodyTypes = new List<BodyType>
        {
            new BodyType
            {
                BodyTypeName = "Two-Door Car"
            },
            new BodyType
            {
                BodyTypeName = "Four-Door Car"
            },
            new BodyType
            {
                BodyTypeName = "Sports-Utility Vehicle"
            },
            new BodyType
            {
                BodyTypeName = "Pickup"
            },
            new BodyType
            {
                BodyTypeName = "Crossover"
            }
        };

        private static List<ContactUs> _contacts = new List<ContactUs>
        {
            new ContactUs
            {
                FirstName = "Jake",
                LastName = "Ganser",
                Email = "jake.ganser@gmail.com",
                Phone = "763-242-5080",
                Message = "I would like to talk with a sales person to learn more about this vehicle",
                VinNumber = "4T3ZF13C12U459747"
            },
            new ContactUs
            {
                FirstName = "Ashley",
                LastName = "Weber",
                Email = "AWebs@gmail.com",
                Phone = "763-242-2344",
                Message = "Do you have this vehicle with leather seats?",
                VinNumber = "1FAFP53222G297529"
            }
        };

        private static List<Customer> _customers = new List<Customer>
        {
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
                    PostalCode = "55303"
                }
        };

        private static List<PurchaseType> _purchaseTypes = new List<PurchaseType>
        {
                new PurchaseType
                {
                    PurchaseTypeName = "Credit",
                },
                new PurchaseType
                {
                    PurchaseTypeName = "Finance",
                },
                new PurchaseType
                {
                    PurchaseTypeName = "Cash",
                }
        };

        private static List<Purchase> _purchases = new List<Purchase>
        {
                new Purchase
                {
                    PurchaseDate = DateTime.Parse("11/4/17"),
                    PurchasePrice = 16000M,
                    APurchaseType = new PurchaseType
                    {
                        PurchaseTypeID = 1,
                        PurchaseTypeName = "Cash"
                    },
                    VinNumber = "4T3ZF13C12U459747",
                }
        };

        private static List<Employee> _employees = new List<Employee>
        {
                new Employee
                {
                    FirstName = "Joe",
                    LastName = "Miller",
                    Email = "jmiller@guildcars.com",
                    Phone = "222-222-2222",
                    Street1 = "1234 Main Street",
                    City = "Minneapolis",
                    State = "MN",
                    PostalCode = "55121"
                }
        };

        private static List<Vehicle> _vehicles = new List<Vehicle>
        {
            new Vehicle
            {
                Color = "Meteorite Grey",
                Description = "Fancy new Mazda 3",
                Interior = "Leather",
                IsAvailable = false,
                IsFeatured = false,
                IsNew = true,
                Mileage = 520,
                CarBody = new BodyType
                {
                    BodyTypeID = 1,
                    BodyTypeName = "Car"
                },
                CarMake = new Make
                {
                    MakeID = 1,
                    MakeName = "Mazda",
                    AddedDate = DateTime.Parse("11/07/2017"),
                    AnEmployee = new Employee
                    {
                        EmployeeID = 1,
                        FirstName = "Bob",
                        LastName = "Miller",
                        Email = "bmiller@guildcars.com",
                        Phone = "123-456-7890",
                        Street1 = "12234 Main Street",
                        Street2 = "Apt 123",
                        City = "Minneapolis",
                        State = "MN",
                        PostalCode = "55121"
                    }
                },
                CarModel = new CarModel
                {
                    CarModelID = 1,
                    ModelName = "3",
                    AddedDate = DateTime.Parse("11/07/2017"),
                    AnEmployee = new Employee
                    {
                        EmployeeID = 2,
                        FirstName = "Joe",
                        LastName = "Johnson",
                        Email = "jjohnson@guildcars.com",
                        Phone = "123-456-7320",
                        Street1 = "1445 Main Street",
                        City = "Minneapolis",
                        State = "MN",
                        PostalCode = "55121"
                    }
                },
                MSRP = 20000M,
                SalePrice = 16000M,
                IsAutomatic = false,
                VinNumber = "4T3ZF13C12U459747",
                Year = 2017
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
                CarModel = new CarModel
                {
                    CarModelID = 2,
                    ModelName = "Corolla",
                },
                CarMake = new Make
                {
                    MakeID = 2,
                    MakeName = "Toyota",
                },
                MSRP = 16000M,
                SalePrice = 16000M,
                IsAutomatic = false,
                VinNumber = "1FAFP53222G297529",
                Year = 2017
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
                CarMake = new Make
                {
                    MakeID = 2,
                    MakeName = "Ford",
                },
                CarModel = new CarModel
                {
                    CarModelID = 3,
                    ModelName = "Fusion",
                },
                MSRP = 20000M,
                SalePrice = 16000M,
                IsAutomatic = false,
                VinNumber = "ZFF65THA9D0186686",
                Year = 2017
            },
            new Vehicle
            {
                VehicleID = 4,
                Color = "Electric Blue",
                Description = "this is a van here",
                Interior = "Cloth",
                IsAvailable = true,
                IsFeatured = false,
                IsNew = false,
                Mileage = 20000,
                CarMake =  new Make
                {
                    MakeID = 4,
                    MakeName = "Dodge",
                },
                CarModel = new CarModel
                {
                    CarModelID = 4,
                    ModelName = "Caravan"
                },
                MSRP = 20000M,
                SalePrice = 16000M,
                IsAutomatic = true,
                VinNumber = "4T3ZF13C12U459747",
                Year = 2017
            },
            new Vehicle
            {
                VehicleID = 5,
                Color = "Rusty",
                Description = "This is an old beat up truck",
                Interior = "Cloth",
                IsAvailable = true,
                IsFeatured = true,
                IsNew = false,
                Mileage = 150000,
                CarMake = new Make
                {
                    MakeID = 5,
                    MakeName = "Chevy",
                },
                CarModel = new CarModel
                {
                    CarModelID = 5,
                    ModelName = "Silverado"
                },
                MSRP = 50000M,
                SalePrice = 25000M,
                IsAutomatic = false,
                VinNumber = "JA4NW61S23J021156",
                Year = 2017
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
                CarMake = new Make
                {
                    MakeID = 6,
                    MakeName = "BMW"
                },
                CarModel = new CarModel
                {
                    CarModelID = 6,
                    ModelName = "550S"
                },
                MSRP = 50000M,
                SalePrice = 50000M,
                IsAutomatic = true,
                VinNumber = "1HGCR2F32DA718943",
                Year = 2017
            }
        };

        private static List<Make> _makes = new List<Make>();
        public void AddMake(Make make)
        {
            _makes.Add(make);
        }

        private static List<CarModel> _carModels = new List<CarModel>();
        public void AddModel(CarModel model)
        {
            _carModels.Add(model);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public void DeleteVehicle(int vehicleID)
        {
            _vehicles.RemoveAll(v => v.VehicleID == vehicleID);
        }

        public void EditVehicle(Vehicle vehicle)
        {
            foreach(var veh in _vehicles)
            {
                if (veh.VehicleID == vehicle.VehicleID)
                {
                    veh.CarBody = vehicle.CarBody;
                    veh.Color = vehicle.Color;
                    veh.Description = vehicle.Description;
                    veh.ImageLocation = vehicle.ImageLocation;
                    veh.Interior = vehicle.Interior;
                    veh.IsAvailable = vehicle.IsAvailable;
                    veh.IsFeatured = vehicle.IsFeatured;
                    veh.IsNew = vehicle.IsNew;
                    veh.Mileage = vehicle.Mileage;
                    veh.CarModel = vehicle.CarModel;
                    veh.MSRP = vehicle.MSRP;
                    veh.SalePrice = vehicle.SalePrice;
                    veh.Specials = vehicle.Specials;
                    veh.IsAutomatic = vehicle.IsAutomatic;
                    veh.VinNumber = vehicle.VinNumber;
                    veh.Year = vehicle.Year;
                }
            }
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicles;
        }

        public List<Vehicle> GetAvailableVehicles()
        {
            return _vehicles.Where(v => v.IsAvailable == true).ToList();
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            return _vehicles.Where(v => v.IsFeatured == true).ToList();
        }

        public List<Vehicle> GetNewVehicles()
        {
            return _vehicles.Where(v => v.IsNew == true).ToList();
        }

        public List<Vehicle> GetNumberOfVehicles(int number, int set)
        {
            return _vehicles.Skip(number * set).Take(number).ToList();
        }

        public List<Vehicle> GetPurchasedVehicles()
        {
            return _vehicles.Where(v => v.IsAvailable == false).ToList();
        }

        public List<Vehicle> GetUsedVehicles()
        {
            return _vehicles.Where(v => v.IsNew == false).ToList();
        }

        public Vehicle GetVehicleByID(int vehicleID)
        {
            Vehicle car = new Vehicle();
            car = _vehicles.Where(v => v.VehicleID == vehicleID).FirstOrDefault();
            return car;
        }

        public Vehicle GetVehicleByVin(string vinNumber)
        {
            return _vehicles.Where(v => v.VinNumber == vinNumber).FirstOrDefault();
        }

        public List<Vehicle> GetVehiclesByMake(string make)
        {
            return _vehicles.Where(v => v.CarMake.MakeName.Contains(make)).ToList();
        }

        public List<Vehicle> GetVehiclesByModel(string model)
        {
            return _vehicles.Where(v => v.CarModel.ModelName.Contains(model)).ToList();
        }

        public List<Vehicle> GetVehiclesByYear(int year)
        {
            return _vehicles.Where(v => v.Year == year).ToList();
        }
    }
}
