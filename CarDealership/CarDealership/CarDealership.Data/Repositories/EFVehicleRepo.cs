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
        }

        public void AddMake(Make make)
        {
            context.Makes.Add(make);
        }

        public void AddModel(CarModel model)
        {
            context.CarModels.Add(model);
        }

        public void AddPurchase(Purchase purch)
        {
            var veh = context.Vehicles.Where(v => v.VinNumber == purch.VinNumber).SingleOrDefault();
            veh.IsAvailable = false;
            veh.IsFeatured = false;
            EditVehicle(veh);
            context.Purchases.Add(purch);
        }

        public void AddSpecial(Special aSpecial)
        {
            context.Specials.Add(aSpecial);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpecial(int specialID)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(int vehicleID)
        {
            throw new NotImplementedException();
        }

        public void EditSpecial(Special aSpecial)
        {
            throw new NotImplementedException();
        }

        public void EditVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAllVehicles()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAvailableVehicles()
        {
            throw new NotImplementedException();
        }

        public BodyType GetBodyByID(int bodyTypeID)
        {
            throw new NotImplementedException();
        }

        public List<BodyType> GetBodyTypes()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            throw new NotImplementedException();
        }

        public Make GetMakeByID(int makeID)
        {
            throw new NotImplementedException();
        }

        public List<Make> GetMakeItems()
        {
            throw new NotImplementedException();
        }

        public CarModel GetModelByID(int carModelID)
        {
            throw new NotImplementedException();
        }

        public List<CarModel> GetModelItems()
        {
            throw new NotImplementedException();
        }

        public List<CarModel> GetModelsByMake(int makeID)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetNumberOfVehicles(int number, int set)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetPurchasedVehicles()
        {
            throw new NotImplementedException();
        }

        public List<PurchaseType> GetPurchaseTypes()
        {
            throw new NotImplementedException();
        }

        public List<Special> GetSpecials()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleByID(int id)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleByVin(string vinNumber)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetVehiclesByMake(string make)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetVehiclesByModel(string model)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetVehiclesByYear(int year)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> QuickSearch(string Type, string SearchKey, int YearMin, int YearMax, int PriceMin, int PriceMax)
        {
            throw new NotImplementedException();
        }
    }
}
