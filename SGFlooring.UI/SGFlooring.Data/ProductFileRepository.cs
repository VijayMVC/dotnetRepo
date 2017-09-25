using SGFlooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;
using System.IO;

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
        public Order GetProduct(Order order)
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
