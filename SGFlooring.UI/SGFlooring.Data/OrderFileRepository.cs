using SGFlooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SGFlooring.Models;
using System.IO;

namespace SGFlooring.Data
{
    public class OrderFileRepository : IOrderRepository
    {
        List<Order> allOrders = new List<Order>();
        private string _filepath;
        public OrderFileRepository(string filepath)
        {
            _filepath = filepath;
        }

        private string MakeFilePath(DateTime orderDate)
        {
            return Path.Combine(_filepath, "Orders_" + String.Format("{0:MMddyyyy}", orderDate) + ".txt");
        }

        public void Create(Order order)
        {
            bool newOrder = true;
            Order toReturn = new Order();
            if (File.Exists(MakeFilePath(order.OrderDate)))
            {
                foreach (Order o in allOrders)
                {
                    if (o.OrderNumber == order.OrderNumber)
                    {
                        allOrders.Remove(o);
                        allOrders.Add(order);
                        newOrder = false;
                        break;
                    }
                }
            }
            if (newOrder == true)
            {
                allOrders.Add(order);
            }
            CreateOrdersFile(allOrders);
        }

        public List<Order> LoadOrders(DateTime orderDate)
        {
            try
            {
                if (File.Exists(MakeFilePath(orderDate)))
                {
                    using (StreamReader sr = new StreamReader(MakeFilePath(orderDate)))
                    {
                        sr.ReadLine();
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            Order newOrder = new Order();

                            string[] columns = line.Split(',');

                            newOrder.OrderDate = orderDate;
                            newOrder.OrderNumber = int.Parse(columns[0]);
                            newOrder.CustomerName = columns[1];
                            newOrder.State = columns[2];
                            newOrder.TaxRate = decimal.Parse(columns[3]);
                            newOrder.ProductType = columns[4];
                            newOrder.Area = decimal.Parse(columns[5]);
                            newOrder.CostPerSquareFoot = decimal.Parse(columns[6]);
                            newOrder.LaborCostPerSquareFoot = decimal.Parse(columns[7]);

                            allOrders.Add(newOrder);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine($"The file: {(MakeFilePath(orderDate))} was not found.\nVerify file path is correct.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
            return allOrders;
        }


        public void RemoveSpecificOrder(DateTime orderDate, int orderNumber)
        {
            Order toReturn = new Order();
            if (File.Exists(MakeFilePath(orderDate)))
            {
                foreach (Order o in allOrders)
                {
                    if (o.OrderNumber == orderNumber && allOrders.Count == 1)
                    {
                        File.Delete(MakeFilePath(orderDate));
                        break;
                    }
                    else if (o.OrderNumber == orderNumber)
                    {
                        allOrders.Remove(o);
                        CreateOrdersFile(allOrders);
                        break;
                    }
                }
            }  
        }


        public Order SpecificOrder(DateTime orderDate, int orderNumber)
        {
            Order toReturn = new Order();
            if (File.Exists(MakeFilePath(orderDate)))
            {
                allOrders = LoadOrders(orderDate);
                foreach (Order order in allOrders)
                {
                    if (order.OrderNumber == orderNumber)
                    {
                        toReturn = order;
                        return toReturn;
                    }
                }
            }
            return toReturn;
        }

        private string CreatCsvForOrders(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}"
                    , order.OrderNumber, order.CustomerName, order.State, order.TaxRate,
                    order.ProductType, order.Area, order.CostPerSquareFoot,
                    order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost,
                    order.Tax, order.Total);
        }

        private void CreateOrdersFile(List<Order> orders)
        {
            Order order = orders.FirstOrDefault();
            if (File.Exists(MakeFilePath(order.OrderDate)))
                File.Delete(MakeFilePath(order.OrderDate));
            using (StreamWriter sr = new StreamWriter(MakeFilePath(order.OrderDate)))
            {
                sr.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot," +
                    "LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (var row in allOrders)
                {
                    sr.WriteLine(CreatCsvForOrders(row));
                }
            }
        }
    }
}

