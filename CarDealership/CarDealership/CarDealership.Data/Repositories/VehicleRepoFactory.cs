using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
    public static class VehicleRepoFactory
    {
        public static IVehicleRepo Create()
        {
            string mode = ConfigurationManager.AppSettings["Dealership"].ToString();

            switch(mode)
            {
                case "EF":
                    return new EFVehicleRepo();
                case "Mock":
                    return new MockVehicleRepo();
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
