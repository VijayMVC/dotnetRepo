using CarDealership.Data.Repositories;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    public class VehicleController : ApiController
    {
        IVehicleRepo repo = VehicleRepoFactory.Create();
        [Route("Featured")]
        public List<Vehicle> Get()
        {
            List<Vehicle> toReturn = repo.GetFeaturedVehicles();
            return toReturn;
        }
    }
}
