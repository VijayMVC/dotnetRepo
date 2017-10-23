using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DvdLibrary.Data;
using DvdLibrary.Models;
using DvdListServ.Models;
using System.Web.Http.Cors;

namespace DvdListServ.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            var repo = DvdRepositoryFactory.Create();
            return Ok(repo.GetAllDvds());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id)
        {
            var repo = DvdRepositoryFactory.Create();
            Dvd dvd = repo.GetDvd(id);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(AddDvdRequest request)
        {
            var repo = DvdRepositoryFactory.Create();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dvd dvd = new Dvd()
            {
                Title = request.Title,
                Director = request.Director,
                ReleaseYear = request.ReleaseYear,
                Rating = request.Rating,
                Notes = request.Notes
            };

            repo.AddDvd(dvd);
            return Created($"dvd/get/{dvd.DvdId}", dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Update(UpdateDvdRequest request)
        {
            var repo = DvdRepositoryFactory.Create();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dvd dvd = repo.GetDvd(request.DvdId);

            if (dvd == null)
            {
                return NotFound();
            }

            dvd.Title = request.Title;
            dvd.Director = request.Director;
            dvd.ReleaseYear = request.ReleaseYear;
            dvd.Rating = request.Rating;
            dvd.Notes = request.Notes;

            repo.EditDvd(dvd);
            return Ok(dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int id)
        {
            var repo = DvdRepositoryFactory.Create();
            Dvd movie = repo.GetDvd(id);

            if (movie == null)
            {
                return NotFound();
            }

            repo.DeleteDvd(id);
            return Ok();
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsByTitle(string title)
        {
            var repo = DvdRepositoryFactory.Create();
            List<Dvd> dvds = repo.GetDvdsByTitle(title);
            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvds);
            }
        }

        [Route("dvds/year/{year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsByDate(int year)
        {
            var repo = DvdRepositoryFactory.Create();
            List<Dvd> dvds = repo.GetDvdsByDate(year);
            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvds);
            }
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsByDirector(string director)
        {
            var repo = DvdRepositoryFactory.Create();
            List<Dvd> dvds = repo.GetDvdsByDirector(director);
            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvds);
            }
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsByRating(string rating)
        {
            var repo = DvdRepositoryFactory.Create();
            List<Dvd> dvds = repo.GetDvdsByRating(rating);
            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvds);
            }
        }
    }
}