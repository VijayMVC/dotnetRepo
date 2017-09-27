using SGFlooring.Models.Interfaces;
using System.Collections.Generic;
using SGFlooring.Models;
using System.IO;
using System;

namespace SGFlooring.Data
{
    public class ProductFileRepository : IProductRepository
    {
        List<Product> allProducts = new List<Product>();
        private string _filepath;

        public ProductFileRepository(string filepath)
        {
            _filepath = filepath;
            List();
        }

        public void List()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_filepath))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Product newProduct = new Product();

                        string[] columns = line.Split(',');
                        newProduct.ProductType = columns[0];
                        newProduct.CostPerSquareFoot = decimal.Parse(columns[1]);
                        newProduct.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                        allProducts.Add(newProduct);
                    }
                }
            }
            catch
            {
                Console.WriteLine($"The file: {_filepath} was not found.\nVerify file path is correct.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }
        public Order AddProductToOrder(Order order)
        {
            Order toReturn = order;
            foreach (Product p in allProducts)
            {
                if (toReturn.ProductType == p.ProductType)
                {
                    toReturn.CostPerSquareFoot = p.CostPerSquareFoot;
                    toReturn.LaborCostPerSquareFoot = p.LaborCostPerSquareFoot;
                }
            }
            return toReturn;
        }

        public List<Product> ListProducts()
        {
            return allProducts;
        }
    }
}
