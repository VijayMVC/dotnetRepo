using CarDealership.Data.Repositories;
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
    public class SpecialsController : ApiController
    {
        [Route("Specials")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            var repo = VehicleRepoFactory.Create();
            return Ok(repo.GetSpecials());
        }
    }
}