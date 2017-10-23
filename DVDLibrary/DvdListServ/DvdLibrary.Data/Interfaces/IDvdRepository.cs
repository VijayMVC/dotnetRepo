using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Models.Interfaces
{
    public interface IDvdRepository
    {
        //List all dvds, get a single dvd, edit a dvd, add a dvd, delete a dvd
        List<Dvd> GetAllDvds();
        List<Dvd> GetDvdsByDate(int year);
        List<Dvd> GetDvdsByDirector(string directorName);
        List<Dvd> GetDvdsByRating(string rating);
        Dvd GetDvd(int dvdId);
        List<Dvd> GetDvdsByTitle(string dvdTitle);
        void EditDvd(Dvd dvd);
        void AddDvd(Dvd dvd);
        void DeleteDvd(int dvdId);
    }
}
