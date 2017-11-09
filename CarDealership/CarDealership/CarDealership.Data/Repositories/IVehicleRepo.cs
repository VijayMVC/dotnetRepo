using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
    public interface IVehicleRepo
    {
        List<Vehicle> GetNumberOfVehicles(int number, int set);
        List<Vehicle> GetAllVehicles();
        List<Vehicle> QuickSearch(string Type, string SearchKey, int YearMin, int YearMax, int PriceMin, int PriceMax);
        List<Vehicle> GetFeaturedVehicles();
        List<Vehicle> GetPurchasedVehicles();
        List<Vehicle> GetAvailableVehicles();
        List<Vehicle> GetVehiclesByMake(string make);
        List<Vehicle> GetVehiclesByModel(string model);
        List<Vehicle> GetVehiclesByYear(int year);
        Vehicle GetVehicleByVin(string vinNumber);
        Vehicle GetVehicleByID(int id);
        void AddVehicle(Vehicle vehicle);
        void AddMake(Make make);
        void AddModel(CarModel model);
        void EditVehicle(Vehicle vehicle);
        void DeleteVehicle(int vehicleID);
    }
}
