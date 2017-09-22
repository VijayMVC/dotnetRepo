using NUnit.Framework;
using SGFlooring.BLL;
using SGFlooring.Models;
using SGFlooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Tests
{
    [TestFixture]
    public class TestDataTests
    {
        [Test]
        public void CanLoadOrderTestData()
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderLookupResponse response = manager.LookupOrders("");

            Assert.IsNotNull(response.ListOfOrders);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(3, response.ListOfOrders.Count);
        }
    }
}
