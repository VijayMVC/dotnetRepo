using DvdLibrary.Data;
using DvdLibrary.Data.ADO;
using DvdLibrary.Data.Repositories;
using DvdLibrary.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Tests.IntegrationTests
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        public void init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DvdListServ"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();        
            }
        }
        [Test]
        public void CanLoadDvds()
        {
            var repo = DvdRepositoryFactory.Create();

            var dvds = repo.GetAllDvds();

            Assert.AreEqual(3, dvds.Count);
            Assert.AreEqual("Office Space", dvds[0].Title);
            Assert.AreEqual("Director A", dvds[0].Director);
            Assert.AreEqual("R", dvds[0].Rating);
            Assert.AreEqual(1999, dvds[0].ReleaseYear);
            Assert.AreEqual("funny movie", dvds[0].Notes);
        }

        [Test]
        public void CanLoadDvdById()
        {
            var repo = DvdRepositoryFactory.Create();
            var dvd = repo.GetDvd(1);

            Assert.IsNotNull(dvd);
            Assert.AreEqual(1, dvd.DvdId);
            Assert.AreEqual("Office Space", dvd.Title);
            Assert.AreEqual("Director A", dvd.Director);
            Assert.AreEqual("R", dvd.Rating);
            Assert.AreEqual(1999, dvd.ReleaseYear);
            Assert.AreEqual("funny movie", dvd.Notes);
        }

        [Test]
        public void CanLoadDvdsByTitle()
        {
            var repo = DvdRepositoryFactory.Create();

            var dvds = repo.GetDvdsByTitle("Office Space");

            Assert.AreEqual(1, dvds.Count);
            Assert.AreEqual("Office Space", dvds[0].Title);
            Assert.AreEqual("Director A", dvds[0].Director);
            Assert.AreEqual("R", dvds[0].Rating);
            Assert.AreEqual(1999, dvds[0].ReleaseYear);
            Assert.AreEqual("funny movie", dvds[0].Notes);
        }

        [Test]
        public void NotFoundDvdReturnsNull()
        {
            var repo = DvdRepositoryFactory.Create();
            var dvd = repo.GetDvd(1000000000);

            Assert.IsNull(dvd);
        }

        [Test]
        public void CanAddDvd()
        {
            var repo = DvdRepositoryFactory.Create();
            Dvd dvdToAdd = new Dvd();

            dvdToAdd.Title = "Grand Budapest Hotel";
            dvdToAdd.Director = "Director B";
            dvdToAdd.Rating = "R";
            dvdToAdd.ReleaseYear = 2005;
            dvdToAdd.Notes = "funny movie";

            repo.AddDvd(dvdToAdd);

            Assert.AreEqual(4, dvdToAdd.DvdId);
        }

        [Test]
        public void CanEditDvd()
        {
            var repo = DvdRepositoryFactory.Create();
            Dvd dvdToAdd = new Dvd();

            dvdToAdd.Title = "Grand Budapest Hotel";
            dvdToAdd.Director = "Director B";
            dvdToAdd.Rating = "R";
            dvdToAdd.ReleaseYear = 2005;
            dvdToAdd.Notes = "funny movie";

            repo.AddDvd(dvdToAdd);

            dvdToAdd.Title = "Pulp Fiction";
            dvdToAdd.Director = "Quentin Tarantino";
            dvdToAdd.ReleaseYear = 1998;
            dvdToAdd.Notes = "classic movie";

            repo.EditDvd(dvdToAdd);
            var updatedDvd = repo.GetDvd(4);

            Assert.AreEqual("Pulp Fiction", updatedDvd.Title);
            Assert.AreEqual("Quentin Tarantino", updatedDvd.Director);
            Assert.AreEqual("R", updatedDvd.Rating);
            Assert.AreEqual(1998, updatedDvd.ReleaseYear);
            Assert.AreEqual("classic movie", updatedDvd.Notes);
        }

        [Test]
        public void CanDeleteDvd()
        {
            var repo = DvdRepositoryFactory.Create();
            Dvd dvdToAdd = new Dvd();

            dvdToAdd.Title = "Grand Budapest Hotel";
            dvdToAdd.Director = "Director B";
            dvdToAdd.Rating = "R";
            dvdToAdd.ReleaseYear = 2005;
            dvdToAdd.Notes = "funny movie";

            repo.AddDvd(dvdToAdd);

            var loaded = repo.GetDvd(4);

            Assert.IsNotNull(loaded);

            repo.DeleteDvd(4);
            loaded = repo.GetDvd(4);

            Assert.IsNull(loaded);
        }

        [Test]
        public void CanLoadDvdsByYear()
        {
            var repo = DvdRepositoryFactory.Create();

            var dvds = repo.GetDvdsByDate(1999);

            Assert.AreEqual(2, dvds.Count);
        }

        [Test]
        public void CanLoadDvdsByDirector()
        {
            var repo = DvdRepositoryFactory.Create();

            var dvds = repo.GetDvdsByDirector("Director A");

            Assert.AreEqual(2, dvds.Count);
        }

        [Test]
        public void CanLoadDvdsByRating()
        {
            var repo = DvdRepositoryFactory.Create();

            var dvds = repo.GetDvdsByRating("R");

            Assert.AreEqual(2, dvds.Count);
        }
    }
}
