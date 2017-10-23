using DvdLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models;

namespace DvdLibrary.Data.Repositories
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> _dvds;
        static DvdRepositoryMock()
        {
            _dvds = new List<Dvd>();
            {
                _dvds.Add(new Dvd { DvdId = 1, Title = "Fight Club", Rating = "R", ReleaseYear = 1999, Director = "a director", Notes = "great movie" });
                _dvds.Add(new Dvd { DvdId = 2, Title = "Snatch", Rating = "R", ReleaseYear = 1999, Director = "same director", Notes = "another great movie" });
                _dvds.Add(new Dvd { DvdId = 3, Title = "Office Space", Rating = "R", ReleaseYear = 1999, Director = "andanother director", Notes = "funny great movie" });
                _dvds.Add(new Dvd { DvdId = 4, Title = "Waynes World", Rating = "G", ReleaseYear = 2001, Director = "andanother director", Notes = "funny great movie" });
                _dvds.Add(new Dvd { DvdId = 5, Title = "Star Wars", Rating = "PG", ReleaseYear = 2000, Director = "same director", Notes = "funny great movie" });
                _dvds.Add(new Dvd { DvdId = 6, Title = "The Big Lebowski", Rating = "R", ReleaseYear = 1999, Director = "andanother director", Notes = "funny great movie" });
            }
        }
        public void AddDvd(Dvd dvd)
        {
            dvd.DvdId = _dvds.Max(m => m.DvdId) + 1;
            _dvds.Add(dvd);
        }

        public void DeleteDvd(int dvdId)
        {
            _dvds.RemoveAll(m => m.DvdId == dvdId);
        }

        public void EditDvd(Dvd dvd)
        {
            var found = _dvds.FirstOrDefault(m => m.DvdId == dvd.DvdId);

            if (found != null)
                found = dvd;
        }

        public List<Dvd> GetAllDvds()
        {
            return _dvds;
        }

        public Dvd GetDvd(int dvdId)
        {
            return _dvds.FirstOrDefault(m => m.DvdId == dvdId);
        }

        public List<Dvd> GetDvdsByTitle(string dvdTitle)
        {
            List<Dvd> toReturn = new List<Dvd>();
            foreach (Dvd a in _dvds)
            {
                if (a.Title == dvdTitle)
                {
                    toReturn.Add(a);
                }
            }
            return toReturn;
        }

        public List<Dvd> GetDvdsByDate(int year)
        {
            List<Dvd> toReturn = new List<Dvd>();
            foreach (Dvd a in _dvds)
            {
                if (a.ReleaseYear == year)
                {
                    toReturn.Add(a);
                }
            }
            return toReturn;
        }

        public List<Dvd> GetDvdsByDirector(string directorName)
        {
            List<Dvd> toReturn = new List<Dvd>();
            foreach (Dvd a in _dvds)
            {
                if (a.Director == directorName)
                {
                    toReturn.Add(a);
                }
            }
            return toReturn;
        }

        public List<Dvd> GetDvdsByRating(string rating)
        {
            List<Dvd> toReturn = new List<Dvd>();
            foreach (Dvd a in _dvds)
            {
                if (a.Rating == rating)
                {
                    toReturn.Add(a);
                }
            }
            return toReturn;
        }
    }
}
