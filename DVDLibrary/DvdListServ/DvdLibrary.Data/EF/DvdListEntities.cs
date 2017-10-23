using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.EF
{
    public class DvdListEntities : DbContext
    {
        public DvdListEntities()
            : base("DvdListServ")
        {
        }

        public DbSet<Dvd> DVDs { get; set; }
    }
}
