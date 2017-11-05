using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
    public class MockVehicleRepo : IVehicleRepo
    {
        private static List<Vehicle> _vehicles = new List<Vehicle>
        {
            new Vehicle
            {
                ColorID = 1,
                Description = "Fancy new Mazda 3",
                InteriorID = 2,
                IsAvailable = false,
                IsFeatured = false,
                IsNew = true,
                Mileage = 520,
                ModelID = 1,
                MSRP = 20000M,
                SalePrice = 16000M,
                Transmission = "Manual",
                VinNumber = "4T3ZF13C12U459747",
                Year = DateTime.Parse("1/1/2017")
            },
            new Vehicle
            {
                ColorID = 3,
                Description = "This is a two-door Toyota Corolla",
                InteriorID = 1,
                IsAvailable = true,
                IsFeatured = true,
                IsNew = true,
                Mileage = 300,
                ModelID = 2,
                MSRP = 16000M,
                SalePrice = 16000M,
                Transmission = "Automatic",
                VinNumber = "1FAFP53222G297529",
                Year = DateTime.Parse("1/1/2017")
            },
            new Vehicle
            {
                ColorID = 4,
                Description = "This is a car",
                InteriorID = 3,
                IsAvailable = true,
                IsFeatured = true,
                IsNew = true,
                Mileage = 520,
                ModelID = 3,
                MSRP = 20000M,
                SalePrice = 16000M,
                Transmission = "Manual",
                VinNumber = "ZFF65THA9D0186686",
                Year = DateTime.Parse("1/1/2016")
            },
            new Vehicle
            {
                ColorID = 3,
                Description = "Another fast car here",
                InteriorID = 4,
                IsAvailable = true,
                IsFeatured = false,
                IsNew = false,
                Mileage = 20000,
                ModelID = 1,
                MSRP = 20000M,
                SalePrice = 16000M,
                Transmission = "Manual",
                VinNumber = "4T3ZF13C12U459747",
                Year = DateTime.Parse("1/1/2017")
            },
            new Vehicle
            {
                ColorID = 2,
                Description = "This is an old beat up truck",
                InteriorID = 4,
                IsAvailable = true,
                IsFeatured = true,
                IsNew = false,
                Mileage = 150000,
                ModelID = 3,
                MSRP = 50000M,
                SalePrice = 25000M,
                Transmission = "Manual",
                VinNumber = "JA4NW61S23J021156",
                Year = DateTime.Parse("1/1/2006")
            },
            new Vehicle
            {
                ColorID = 5,
                Description = "This car is spectacular",
                InteriorID = 3,
                IsAvailable = true,
                IsFeatured = true,
                IsNew = true,
                Mileage = 12,
                ModelID = 3,
                MSRP = 50000M,
                SalePrice = 50000M,
                Transmission = "Automatic",
                VinNumber = "1HGCR2F32DA718943",
                Year = DateTime.Parse("1/1/2017")
            }
        };

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
                    veh.BodyTypeID = vehicle.BodyTypeID;
                    veh.ColorID = vehicle.ColorID;
                    veh.Description = vehicle.Description;
                    veh.ImageID = vehicle.ImageID;
                    veh.InteriorID = vehicle.InteriorID;
                    veh.IsAvailable = vehicle.IsAvailable;
                    veh.IsFeatured = vehicle.IsFeatured;
                    veh.IsNew = vehicle.IsNew;
                    veh.Mileage = vehicle.Mileage;
                    veh.ModelID = vehicle.ModelID;
                    veh.MSRP = vehicle.MSRP;
                    veh.SalePrice = vehicle.SalePrice;
                    veh.SpecialsID = vehicle.SpecialsID;
                    veh.Transmission = vehicle.Transmission;
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

        public List<Vehicle> GetVehiclesByMake(string make)
        {
            return _vehicles.Where(v => v.CarModel.Make.MakeName.Contains(make)).ToList();
        }

        public List<Vehicle> GetVehiclesByModel(string model)
        {
            return _vehicles.Where(v => v.CarModel.ModelName.Contains(model)).ToList();
        }

        public List<Vehicle> GetVehiclesByYear(string year)
        {
            return _vehicles.Where(v => v.Year == DateTime.Parse(year)).ToList();
        }
    }
}
