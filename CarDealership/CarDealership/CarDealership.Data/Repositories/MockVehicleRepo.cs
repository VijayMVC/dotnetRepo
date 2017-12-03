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
                    PostalCode = "55121",
                    Role = "Sales"
                }
        };

        private static List<BodyType> _bodyTypes = new List<BodyType>
        {
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
            }
        };

        private static List<Make> _makes = new List<Make>
        {
            new Make
            {
                MakeID = 1,
                MakeName = "Mazda",
                AddedDate = DateTime.Parse("11/07/2017"),
                AddedBy = "admin"
            },
            new Make
            {
                MakeID = 2,
                MakeName = "Toyota",
                AddedDate = DateTime.Parse("11/07/2017"),
                AddedBy = "admin"
            },
            new Make
            {
                MakeID = 3,
                MakeName = "Chevy",
                AddedDate = DateTime.Parse("11/07/2017"),
                AddedBy = "admin"
            },
            new Make
            {
                MakeID = 4,
                MakeName = "BMW",
                AddedDate = DateTime.Parse("11/07/2017"),
                AddedBy = "admin"
            },
            new Make
            {
                MakeID = 5,
                MakeName = "Ford",
                AddedDate = DateTime.Parse("11/07/2017"),
                AddedBy = "admin"
            },
        };
        private static List<CarModel> _carModels = new List<CarModel>
        {
            new CarModel
            {
                CarModelID = 1,
                ModelName = "3",
                AddedDate = DateTime.Parse("11/07/2017"),
                AddedBy = "Admin",
                Make = "Mazda",
            },
            new CarModel
            {
                CarModelID = 2,
                ModelName = "Corolla",
                AddedDate = DateTime.Parse("11/07/2017"),
                AddedBy = "Admin",
                Make = "Toyota",
                
            },
            new CarModel
            {
                CarModelID = 3,
                ModelName = "Silverado",
                AddedDate = DateTime.Parse("11/07/2017"),
                AddedBy = "Admin",
                Make = "Chevy",
            },
            new CarModel
            {
                CarModelID = 4,
                ModelName = "550S",
                AddedDate = DateTime.Parse("11/07/2017"),
                AddedBy = "Admin",
                Make = "BMW",
            },
            new CarModel
            {
                CarModelID = 5,
                ModelName = "Focus",
                AddedDate = DateTime.Parse("11/07/2017"),
                AddedBy = "Admin",
                Make = "Ford",
                
            },
        };

        private static List<PurchaseType> _purchaseTypes = new List<PurchaseType>
        {
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
            }
        };

        private static List<Vehicle> _vehicles = new List<Vehicle>
        {
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
                CarBody = _bodyTypes[1],
                CarMake = _makes[0],
                CarModel = _carModels[0],
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
                CarModel = _carModels[1],
                CarMake = _makes[1],
                MSRP = 16000M,
                SalePrice = 16000M,
                IsAutomatic = false,
                VinNumber = "1FAFP53222G297529",
                Year = 2015,
                CarBody = _bodyTypes[0]
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
                CarMake = _makes[4],
                CarModel = _carModels[4],
                MSRP = 20000M,
                SalePrice = 16000M,
                IsAutomatic = false,
                VinNumber = "ZFF65THA9D0186686",
                Year = 2017,
                CarBody = _bodyTypes[1],
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
                CarMake =  _makes[3],
                CarModel = _carModels[3],
                MSRP = 20000M,
                SalePrice = 16000M,
                IsAutomatic = true,
                VinNumber = "4T3ZF13C12U459747",
                Year = 2017,
                CarBody = _bodyTypes[0]
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
                CarMake = _makes[2],
                CarModel = _carModels[2],
                MSRP = 50000M,
                SalePrice = 45000,
                IsAutomatic = false,
                VinNumber = "JA4NW61S23J021156",
                Year = 2017,
                CarBody = _bodyTypes[3]
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
                CarMake = _makes[0],
                CarModel = _carModels[0],
                MSRP = 50000M,
                SalePrice = 50000M,
                IsAutomatic = true,
                VinNumber = "1HGCR2F32DA718943",
                Year = 2017,
                CarBody = _bodyTypes[0],
            }
        };

        private static List<ContactUs> _contacts = new List<ContactUs>
        {
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
                    PostalCode = "55303",
                }
        };

        private static List<Purchase> _purchases = new List<Purchase>
        {
                new Purchase
                {
                    PurchaseID = 1,
                    PurchaseDate = DateTime.Parse("11/4/17"),
                    PurchasePrice = 16000M,
                    APurchaseType = _purchaseTypes[0],
                    VinNumber = "4T3ZF13C12U459747",
                    ACustomer = _customers[0]
                }
        };

        private static List<Special> _specials = new List<Special>
        {
            new Special
            {
                SpecialID = 1,
                SpecialName = "Truck Month!!",
                Description = "Take $1,500 off the sales price of all new trucks in the month of November!",
                value = 1500,
                BeginDate = DateTime.Parse("11/01/2017"),
                EndDate = DateTime.Parse("11/30/2017"),
                Vehicles = _vehicles.Where(v => v.CarBody.BodyTypeID == 4).Where(v => v.IsNew == true).ToList(),
            }
        };

        public MockVehicleRepo()
        {
        }

        public void AddContact(ContactUs contact)
        {
            _contacts.Add(contact);
        }

        public void AddEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public void AddMake(Make make)
        {
            _makes.Add(make);
        }

        public void AddModel(CarModel model)
        {
            _carModels.Add(model);
        }

        public void AddPurchase(Purchase purch)
        {
            Vehicle veh = new Vehicle();
            veh = _vehicles.Where(v => v.VinNumber == purch.VinNumber).SingleOrDefault();
            veh.IsAvailable = false;
            veh.IsFeatured = false;
            EditVehicle(veh);
            purch.APurchaseType = _purchaseTypes.Where(p => p.PurchaseTypeID == purch.PurchaseID).SingleOrDefault();
            _purchases.Add(purch);
        }

        public void AddSpecial(Special aSpecial)
        {
            _specials.Add(aSpecial);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public void DeleteSpecial(int specialID)
        {
            _specials.RemoveAll(s => s.SpecialID == specialID);
        }

        public void DeleteVehicle(int vehicleID)
        {
            _vehicles.RemoveAll(v => v.VehicleID == vehicleID);
        }

        public void EditEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public void EditSpecial(Special aSpecial)
        {
            foreach(var spec in _specials)
            {
                if (spec.SpecialID == aSpecial.SpecialID)
                {
                    spec.SpecialName = aSpecial.SpecialName;
                    spec.value = aSpecial.value;
                    spec.Vehicles = aSpecial.Vehicles;
                    spec.Description = aSpecial.Description;
                    spec.BeginDate = aSpecial.BeginDate;
                    spec.EndDate = aSpecial.EndDate;
                    spec.ImageLocation = aSpecial.ImageLocation;
                }
            }
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

        public BodyType GetBodyByID(int bodyTypeID)
        {
            BodyType toReturn = new BodyType();

            toReturn = _bodyTypes.Where(b => b.BodyTypeID == bodyTypeID).SingleOrDefault();

            return toReturn;
        }

        public List<BodyType> GetBodyTypes()
        {
            return _bodyTypes;
        }

        public Employee GetEmployeeByID(int empID)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            return _vehicles.Where(v => v.IsFeatured == true).ToList();
        }

        public Make GetMakeByID(int makeID)
        {
            Make toReturn = new Make();

            toReturn = _makes.Where(b => b.MakeID == makeID).SingleOrDefault();

            return toReturn;
        }

        public Make GetMakeByName(string makeName)
        {
            throw new NotImplementedException();
        }

        public List<Make> GetMakeItems()
        {
            return _makes;
        }

        public CarModel GetModelByID(int carModelID)
        {
            CarModel toReturn = new CarModel();

            toReturn = _carModels.Where(b => b.CarModelID == carModelID).SingleOrDefault();

            return toReturn;
        }

        public List<CarModel> GetModelItems()
        {
            return _carModels;
        }

        public List<CarModel> GetModelsByMake(string make)
        {
            throw new NotImplementedException();
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

        public List<Special> GetSpecials()
        {
            return _specials;
        }

        public List<Vehicle> GetUsedVehicles()
        {
            return _vehicles.Where(v => v.IsNew == false).ToList();
        }

        public List<Employee> GetUsers()
        {
            return _employees;
        }

        public Vehicle GetVehicleByID(int vehicleID)
        {
            Vehicle car = new Vehicle();
            car = _vehicles.Where(v => v.VehicleID == vehicleID).FirstOrDefault();
            return car;
        }

        public Vehicle GetVehicleByVin(string vinNumber)
        {
            return _vehicles.Where(v => v.VinNumber == vinNumber.ToUpper()).FirstOrDefault();
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

        public List<Vehicle> QuickSearch(string Type, string SearchKey, int YearMin, int YearMax, int PriceMin, int PriceMax)
        {
            List<Vehicle> toReturn = new List<Vehicle>();
            List<Vehicle> vehicles = new List<Vehicle>();
            if (Type == "New")
            {
                vehicles = (_vehicles.Where(v => v.IsNew == true).ToList());
                foreach(var veh in vehicles)
                    if (veh.CarMake.MakeName.Contains(SearchKey) || veh.CarModel.ModelName.Contains(SearchKey) || veh.Year.ToString() == SearchKey 
                        && veh.Year >= YearMin && veh.Year <= YearMax && veh.SalePrice >= PriceMin && veh.SalePrice <= PriceMax)
                    {
                        toReturn.Add(veh);
                    }
            }
            else if (Type == "Used")
            {
                vehicles = (_vehicles.Where(v => v.IsNew == false).ToList());
                foreach (var veh in vehicles)
                    if (veh.CarMake.MakeName.Contains(SearchKey) || veh.CarModel.ModelName.Contains(SearchKey) || veh.Year.ToString() == SearchKey
                        && veh.Year >= YearMin && veh.Year <= YearMax && veh.SalePrice >= PriceMin && veh.SalePrice <= PriceMax)
                    {
                        toReturn.Add(veh);
                    }
            }
            else if (Type == "All")
            {
                vehicles = (_vehicles.Where(v => v.IsAvailable == true).ToList());
                foreach (var veh in vehicles)
                    if (veh.CarMake.MakeName.Contains(SearchKey) || veh.CarModel.ModelName.Contains(SearchKey) || veh.Year.ToString() == SearchKey
                        && veh.Year >= YearMin && veh.Year <= YearMax && veh.SalePrice >= PriceMin && veh.SalePrice <= PriceMax)
                    {
                        toReturn.Add(veh);
                    }
            }
            return toReturn;
        }

        List<PurchaseType> IVehicleRepo.GetPurchaseTypes()
        {
            return _purchaseTypes;
        }
    }
}
