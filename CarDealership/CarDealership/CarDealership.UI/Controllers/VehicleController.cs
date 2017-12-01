using CarDealership.Data.Repositories;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarDealership.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehicleController : ApiController
    {   
        [Route("Vehicles")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get()
        {
            var repo = VehicleRepoFactory.Create();
            return Ok(repo.GetFeaturedVehicles());
        }

        [Route("Vehicles/{Type}/{SearchKey}/{YearMin}/{YearMax}/{PriceMin}/{PriceMax}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult QuickSearch(string Type, string SearchKey, int YearMin, int YearMax, int PriceMin, int PriceMax)
        {
            var repo = VehicleRepoFactory.Create();
            return Ok(repo.QuickSearch(Type, SearchKey, YearMin, YearMax, PriceMin, PriceMax));
        }

        [Route("Vehicle/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult vehicleDetails(int id)
        {
            var repo = VehicleRepoFactory.Create();
            return Ok(repo.GetVehicleByID(id));
        }

        [Route("Vehicle/Vin/{vin}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult vehicleVin(string vin)
        {
            var repo = VehicleRepoFactory.Create();
            return Ok(repo.GetVehicleByVin(vin));
        }
    }
}
