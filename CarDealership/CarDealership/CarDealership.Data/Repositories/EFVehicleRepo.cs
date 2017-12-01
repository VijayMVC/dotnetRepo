using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using System.Data.Entity.Migrations;
using CarDealership.Models.Tables;

namespace CarDealership.Data.Repositories
{
    class EFVehicleRepo : IVehicleRepo
    {
        CarDealershipDBContext context = new CarDealershipDBContext();

        public void AddContact(ContactUs contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
        }

        public void AddEmployee(Employee emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
        }

        public void AddMake(Make make)
        {
            context.Makes.Add(make);
            context.SaveChanges();
        }

        public void AddModel(CarModel model)
        {
            context.CarModels.Add(model);
            context.SaveChanges();
        }

        public void AddPurchase(Purchase purch)
        {
            var veh = context.Vehicles.Where(v => v.VinNumber == purch.VinNumber).SingleOrDefault();
            veh.IsAvailable = false;
            veh.IsFeatured = false;
            EditVehicle(veh);
            context.Purchases.Add(purch);
            context.SaveChanges();
        }

        public void AddSpecial(Special aSpecial)
        {
            context.Specials.Add(aSpecial);
            context.SaveChanges();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
            context.SaveChanges();
        }

        public void DeleteSpecial(int specialID)
        {
            context.Specials.Remove(context.Specials.Where(s => s.SpecialID == specialID).SingleOrDefault());
            context.SaveChanges();
        }

        public void DeleteVehicle(int vehicleID)
        {
            context.Vehicles.Remove(context.Vehicles.Where(v => v.VehicleID == vehicleID).SingleOrDefault());
            context.SaveChanges();
        }

        public void EditSpecial(Special aSpecial)
        {
            var change = context.Specials.FirstOrDefault(s => s.SpecialID == aSpecial.SpecialID);
            change.ImageLocation = aSpecial.ImageLocation;
            change.SpecialName = aSpecial.SpecialName;
            change.value = aSpecial.value;
            change.Vehicles = aSpecial.Vehicles;
            change.Description = aSpecial.Description;
            change.BeginDate = aSpecial.BeginDate;
            change.EndDate = aSpecial.EndDate;
            context.SaveChanges();
        }

        public void EditVehicle(Vehicle vehicle)
        {
            var change = context.Vehicles.FirstOrDefault(v => v.VehicleID == vehicle.VehicleID);
            change.CarBody = vehicle.CarBody;
            change.CarMake = vehicle.CarMake;
            change.CarModel = vehicle.CarModel;
            change.Color = vehicle.Color;
            change.Description = vehicle.Description;
            change.ImageLocation = vehicle.ImageLocation;
            change.Interior = vehicle.Interior;
            change.IsAutomatic = vehicle.IsAutomatic;
            change.IsAvailable = vehicle.IsAvailable;
            change.IsFeatured = vehicle.IsFeatured;
            change.IsNew = vehicle.IsNew;
            change.Mileage = vehicle.Mileage;
            change.MSRP = vehicle.MSRP;
            change.SalePrice = vehicle.SalePrice;
            change.Specials = vehicle.Specials;
            change.VinNumber = vehicle.VinNumber;
            change.Year = vehicle.Year;
            context.SaveChanges();
        }

        public List<Vehicle> GetAllVehicles()
        {
            return context.Vehicles.ToList();
        }

        public List<Vehicle> GetAvailableVehicles()
        {
            return context.Vehicles.Where(v => v.IsAvailable == true).ToList();
        }

        public BodyType GetBodyByID(int bodyTypeID)
        {
            return context.BodyTypes.FirstOrDefault(b => b.BodyTypeID == bodyTypeID);
        }

        public List<BodyType> GetBodyTypes()
        {
            return context.BodyTypes.ToList();
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            return context.Vehicles.Where(v => v.IsFeatured == true).ToList();
        }

        public Make GetMakeByID(int makeID)
        {
            return context.Makes.FirstOrDefault(m => m.MakeID == makeID);
        }

        public List<Make> GetMakeItems()
        {
            return context.Makes.ToList();
        }

        public CarModel GetModelByID(int carModelID)
        {
            return context.CarModels.FirstOrDefault(c => c.CarModelID == carModelID);
        }

        public List<CarModel> GetModelItems()
        {
            return context.CarModels.ToList();
        }

        public List<CarModel> GetModelsByMake(int makeID)
        {
            return context.CarModels.Where(c => c.AMake.MakeID == makeID).ToList();
        }

        public List<Vehicle> GetNumberOfVehicles(int number, int set)
        {
            return context.Vehicles.OrderByDescending(v => v.SalePrice).Where(v => v.IsAvailable == true).Skip(number * set).Take(number).ToList();
        }

        public List<Vehicle> GetPurchasedVehicles()
        {
            return context.Vehicles.Where(v => v.IsAvailable == false).ToList();
        }

        public List<PurchaseType> GetPurchaseTypes()
        {
            return context.PurchaseTypes.ToList();
        }

        public List<Special> GetSpecials()
        {
            return context.Specials.ToList();
        }

        public List<Employee> GetUsers()
        {
            return context.Employees.ToList();
        }

        public Vehicle GetVehicleByID(int id)
        {
            return context.Vehicles.FirstOrDefault(v => v.VehicleID == id);
        }

        public Vehicle GetVehicleByVin(string vinNumber)
        {
            return context.Vehicles.FirstOrDefault(v => v.VinNumber == vinNumber);
        }

        public List<Vehicle> GetVehiclesByMake(string make)
        {
            return context.Vehicles.OrderByDescending(v => v.SalePrice).Where(v => v.CarMake.MakeName.ToLower() == make.ToLower()).ToList();
        }

        public List<Vehicle> GetVehiclesByModel(string model)
        {
            return context.Vehicles.OrderByDescending(v => v.SalePrice).Where(v => v.CarModel.ModelName.ToLower() == model.ToLower()).ToList();
        }

        public List<Vehicle> GetVehiclesByYear(int year)
        {
            return context.Vehicles.OrderByDescending(v => v.SalePrice).Where(v => v.Year == year).ToList();
        }

        public List<Vehicle> QuickSearch(string Type, string SearchKey, int YearMin, int YearMax, int PriceMin, int PriceMax)
        {
            if (Type == "New")
            {
                if (SearchKey == "null")
                {
                    return context.Vehicles.OrderByDescending(v => v.SalePrice).Where(v => v.IsNew == true).Where(v => v.Year >= YearMin)
                        .Where(v => v.Year <= YearMax).Where(v => v.SalePrice >= PriceMin).Where(v => v.SalePrice <= PriceMax).ToList();
                }
                else
                {
                    return context.Vehicles.OrderByDescending(v => v.SalePrice).Where(v => v.CarMake.MakeName.Contains(SearchKey) || v.CarModel.ModelName.Contains(SearchKey) || v.Year.ToString() == SearchKey).Where(v => v.IsNew == true).Where(v => v.Year >= YearMin)
                        .Where(v => v.Year <= YearMax).Where(v => v.SalePrice >= PriceMin).Where(v => v.SalePrice <= PriceMax).ToList();
                }
            }
            else if (Type == "Used")
            {
                if (SearchKey == "null")
                {
                    return context.Vehicles.OrderByDescending(v => v.SalePrice).Where(v => v.IsNew == false).Where(v => v.Year >= YearMin)
                        .Where(v => v.Year <= YearMax).Where(v => v.SalePrice >= PriceMin).Where(v => v.SalePrice <= PriceMax).ToList();
                }
                else
                {
                    return context.Vehicles.OrderByDescending(v => v.SalePrice).Where(v => v.CarMake.MakeName.Contains(SearchKey) || v.CarModel.ModelName.Contains(SearchKey) || v.Year.ToString() == SearchKey).Where(v => v.IsNew == false).Where(v => v.Year >= YearMin)
                        .Where(v => v.Year <= YearMax).Where(v => v.SalePrice >= PriceMin).Where(v => v.SalePrice <= PriceMax).ToList();
                }
            }
            else
            {
                if (SearchKey == "null")
                {
                    return context.Vehicles.OrderByDescending(v => v.SalePrice).Where(v => v.Year >= YearMin)
                        .Where(v => v.Year <= YearMax).Where(v => v.SalePrice >= PriceMin).Where(v => v.SalePrice <= PriceMax).ToList();
                }
                else
                {
                    return context.Vehicles.OrderByDescending(v => v.SalePrice).Where(v => v.CarMake.MakeName.Contains(SearchKey) || v.CarModel.ModelName.Contains(SearchKey) || v.Year.ToString() == SearchKey).Where(v => v.Year >= YearMin)
                        .Where(v => v.Year <= YearMax).Where(v => v.SalePrice >= PriceMin).Where(v => v.SalePrice <= PriceMax).ToList();
                }
            }
        }
    }
}
