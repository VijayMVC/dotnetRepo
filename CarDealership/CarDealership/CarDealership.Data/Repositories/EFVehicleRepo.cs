using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using System.Data.Entity.Migrations;

namespace CarDealership.Data.Repositories
{
    class EFVehicleRepo : IVehicleRepo
    {
        CarDealershipDBContext context = new CarDealershipDBContext();

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

        public void AddVehicle(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
            context.SaveChanges();
        }

        public void DeleteVehicle(int vehicleID)
        {
            Vehicle vehicle = context.Vehicles.Find(vehicleID);
            context.Vehicles.Remove(vehicle);
            context.SaveChanges();
        }

        public void EditVehicle(Vehicle vehicle)
        {
            var change = context.Vehicles.FirstOrDefault(v => v.VinNumber == vehicle.VinNumber);
            context.Vehicles.AddOrUpdate(vehicle);
            context.SaveChanges();
        }

        public List<Vehicle> GetAllVehicles()
        {
            return context.Vehicles.OrderByDescending(v => v.MSRP).ToList();
        }

        public List<Vehicle> GetAvailableVehicles()
        {
            return context.Vehicles.Where(v => v.IsAvailable == true).ToList();
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            return context.Vehicles.Where(v => v.IsFeatured == true).ToList();
        }

        public List<Vehicle> GetNewVehicles()
        {
            return context.Vehicles.Where(v => v.IsNew == true).ToList();
        }

        public List<Vehicle> GetNumberOfVehicles(int number, int set)
        {
            var toReturn = context.Vehicles.OrderByDescending(v => v.MSRP).Where(v => v.IsAvailable == true).Skip(number * set).Take(number).ToList();
            return toReturn;
        }

        public List<Vehicle> GetPurchasedVehicles()
        {
            return context.Vehicles.Where(v => v.IsAvailable == false).ToList();
        }

        public List<Vehicle> GetUsedVehicles()
        {
            return context.Vehicles.Where(v => v.IsNew == false).ToList();
        }

        public Vehicle GetVehicleByVin(string vinNumber)
        {
            return context.Vehicles.FirstOrDefault(v => v.VinNumber == vinNumber);
        }

        public List<Vehicle> GetVehiclesByMake(string make)
        {
            return context.Vehicles.Where(v => v.CarMake.MakeName.Contains(make)).ToList();
        }

        public List<Vehicle> GetVehiclesByModel(string model)
        {
            return context.Vehicles.Where(v => v.CarModel.ModelName.Contains(model)).ToList();
        }

        public List<Vehicle> GetVehiclesByYear(int year)
        {
            return context.Vehicles.Where(v => v.Year == year).ToList();
        }
    }
}
