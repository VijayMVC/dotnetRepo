using DvdLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models;

namespace DvdLibrary.Data.EF
{
    public class DvdRepositoryEF : IDvdRepository
    {
        public void AddDvd(Dvd dvd)
        {
            using (var context = new DvdListEntities())
            {
                context.DVDs.Add(dvd);
                context.SaveChanges();
            }
        }

        public void DeleteDvd(int dvdId)
        {
            using (var context = new DvdListEntities())
            {
                var dvd = (from d in context.DVDs where d.DvdId == dvdId select d).FirstOrDefault();
                context.DVDs.Remove(dvd);
                context.SaveChanges();
            }
        }

        public void EditDvd(Dvd dvd)
        {
            using (var context = new DvdListEntities())
            {
                context.Entry(dvd).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Dvd> GetAllDvds()
        {    
                using (var context = new DvdListEntities())
                {
                    var dvds = from d in context.DVDs
                               select d;
                    return dvds.ToList();
                }    
        }

        public Dvd GetDvd(int dvdId)
        {
            using (var context = new DvdListEntities())
            {               
                var dvd = (from d in context.DVDs where d.DvdId == dvdId select d).FirstOrDefault();
                return dvd;              
            }
        }

        public List<Dvd> GetDvdsByDate(int year)
        {
            using (var context = new DvdListEntities())
            {
                var dvds = from d in context.DVDs
                           where d.ReleaseYear == year
                           select d;
                return dvds.ToList();
            }
        }

        public List<Dvd> GetDvdsByDirector(string directorName)
        {
            using (var context = new DvdListEntities())
            {
                var dvds = from d in context.DVDs
                           where d.Director == directorName
                           select d;
                return dvds.ToList();
            }
        }

        public List<Dvd> GetDvdsByRating(string rating)
        {
            using (var context = new DvdListEntities())
            {
                var dvds = from d in context.DVDs
                           where d.Rating == rating
                           select d;
                return dvds.ToList();
            }
        }

        public List<Dvd> GetDvdsByTitle(string dvdTitle)
        {
            using (var context = new DvdListEntities())
            {
                var dvds = from d in context.DVDs
                           where d.Title == dvdTitle
                           select d;
                return dvds.ToList();
            }
        }
    }
}
