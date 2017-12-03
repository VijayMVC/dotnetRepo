using CarDealership.Models;
using CarDealership.Models.Tables;
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
        List<PurchaseType> GetPurchaseTypes();
        List<Vehicle> GetAvailableVehicles();
        List<Vehicle> GetVehiclesByMake(string make);
        List<Vehicle> GetVehiclesByModel(string model);
        List<BodyType> GetBodyTypes();
        List<Vehicle> GetVehiclesByYear(int year);
        List<Special> GetSpecials();
        List<Make> GetMakeItems();
        List<CarModel> GetModelItems();
        Vehicle GetVehicleByVin(string vinNumber);
        Vehicle GetVehicleByID(int id);
        void AddVehicle(Vehicle vehicle);
        void AddMake(Make make);
        void AddModel(CarModel model);
        void AddPurchase(Purchase purch);
        void AddSpecial(Special aSpecial);
        void EditVehicle(Vehicle vehicle);
        void EditSpecial(Special aSpecial);
        void DeleteVehicle(int vehicleID);
        void DeleteSpecial(int specialID);
        CarModel GetModelByID(int carModelID);
        void AddContact(ContactUs contact);
        Make GetMakeByID(int makeID);
        BodyType GetBodyByID(int bodyTypeID);
        List<Employee> GetUsers();
        Make GetMakeByName(string makeName);
        void AddEmployee(Employee emp);
        void EditEmployee(Employee emp);
        List<CarModel> GetModelsByMake(string make);
        Employee GetEmployeeByID(int empID);
    }
}
