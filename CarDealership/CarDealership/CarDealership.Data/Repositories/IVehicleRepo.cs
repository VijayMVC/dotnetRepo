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
        List<Vehicle> GetNewVehicles();
        List<Vehicle> GetUsedVehicles();
        List<Vehicle> GetFeaturedVehicles();
        List<Vehicle> GetPurchasedVehicles();
        List<Vehicle> GetAvailableVehicles();
        List<Vehicle> GetVehiclesByMake(string make);
        List<Vehicle> GetVehiclesByModel(string model);
        List<Vehicle> GetVehiclesByYear(string year);
        Vehicle GetVehicleByID(int vehicleID);
        void AddVehicle(Vehicle vehicle);
        void EditVehicle(Vehicle vehicle);
        void DeleteVehicle(int vehicleID);
    }
}
