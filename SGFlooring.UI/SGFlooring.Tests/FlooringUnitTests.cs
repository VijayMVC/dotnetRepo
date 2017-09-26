using NUnit.Framework;
using SGFlooring.BLL;
using SGFlooring.Models.Responses;
using System;
using SGFlooring.Models;
using System.IO;

namespace SGFlooring.Tests
{
    [TestFixture]
    public class FlooringUnitTests
    {
        public string filepath = @"C:\Repos\dotnet-jake-ganser\SGFlooring.UI\SGFlooring.Data\SampleData\MockOrders\Orders_01012018.txt";
        [Test]
        public void CanLookupOrders()//tests ability get order data from mock file repo and return the list of orders
        {
            DateTime date = new DateTime(2013, 06, 01);
            OrderManager manager = OrderManagerFactory.Create();
            OrderLookupResponse response = manager.LookupOrders(date);

            Assert.IsNotNull(response.ListOfOrders);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(3, response.ListOfOrders.Count);

            Order check = response.ListOfOrders[2];

            Assert.AreEqual(3,check.OrderNumber);
            Assert.AreEqual("Jake", check.CustomerName);
            Assert.AreEqual("OH", check.State);
            Assert.AreEqual(6.25M, check.TaxRate);
            Assert.AreEqual("Tile", check.ProductType);
            Assert.AreEqual(700, check.Area);
            Assert.AreEqual(3.50M, check.CostPerSquareFoot);
            Assert.AreEqual(4.15M, check.LaborCostPerSquareFoot);
            Assert.AreEqual(2450, check.MaterialCost);
            Assert.AreEqual(2905, check.LaborCost);
            Assert.AreEqual(334.687500, check.Tax);
            Assert.AreEqual(5689.687500, check.Total);
        }

        [Test]
        public void CanAddOrderToFile()
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            OrderManager manager = OrderManagerFactory.Create();
            Order newOrder = new Order();

            DateTime date = new DateTime(2018, 01, 01);
            newOrder.OrderDate = date;
            newOrder.CustomerName = "Bill Johnson";
            newOrder.State = "PA";
            newOrder.ProductType = "Wood";
            newOrder.Area = 300;

            manager.AddProductToOrder(newOrder);
            manager.AddStateToOrder(newOrder);

            manager.SaveOrder(newOrder);
            
            OrderLookupResponse response = manager.LookupOrders(newOrder.OrderDate);

            Assert.AreEqual(2, response.ListOfOrders.Count);
        }

        [Test]
        public void CanEditOrderFromFile()
        {
            OrderManager manager = OrderManagerFactory.Create();
            DateTime date = new DateTime(2018, 01, 01);
            Order editedOrder = manager.GetSpecificOrder(date, 1);

            OrderLookupResponse response = manager.LookupOrders(date);

            Order check = response.ListOfOrders[1];

            Assert.AreEqual(1, check.OrderNumber);
            Assert.AreEqual("Bill Johnson", check.CustomerName);
            Assert.AreEqual("PA", check.State);
            Assert.AreEqual(6.75M, check.TaxRate);
            Assert.AreEqual("Wood", check.ProductType);
            Assert.AreEqual(300, check.Area);
            Assert.AreEqual(5.15M, check.CostPerSquareFoot);
            Assert.AreEqual(4.75M, check.LaborCostPerSquareFoot);
            Assert.AreEqual(1545, check.MaterialCost);
            Assert.AreEqual(1425, check.LaborCost);
            Assert.AreEqual(200.475m, check.Tax);
            Assert.AreEqual(3170.475m, check.Total);

            editedOrder.OrderDate = date;
            editedOrder.CustomerName = "Jake";
            editedOrder.State = "PA";
            editedOrder.Area = 350;

            manager.AddProductToOrder(editedOrder);
            manager.AddStateToOrder(editedOrder);

            manager.SaveEditedOrder(editedOrder);
            response = manager.LookupOrders(editedOrder.OrderDate);

            Order check2 = response.ListOfOrders[1];

            Assert.AreEqual(1, check2.OrderNumber);
            Assert.AreEqual("Jake", check2.CustomerName);
            Assert.AreEqual("PA", check2.State);
            Assert.AreEqual(6.75M, check2.TaxRate);
            Assert.AreEqual("Wood", check2.ProductType);
            Assert.AreEqual(350, check2.Area);
            Assert.AreEqual(5.15M, check2.CostPerSquareFoot);
            Assert.AreEqual(4.75M, check2.LaborCostPerSquareFoot);
            Assert.AreEqual(1802.5, check2.MaterialCost);
            Assert.AreEqual(1662.5, check2.LaborCost);
            Assert.AreEqual(233.8875, check2.Tax);
            Assert.AreEqual(3698.8875, check2.Total);
        }

        [Test]
        public void CanRemoveOrderFromFile()
        {
            OrderManager manager = OrderManagerFactory.Create();
            DateTime date = new DateTime(2018, 01, 01);

            OrderLookupResponse response = manager.LookupOrders(date);

            Assert.AreEqual(2, response.ListOfOrders.Count);

            manager.RemoveOrder(date, 1);

            Assert.AreEqual(1, response.ListOfOrders.Count);
        }
    }
}
