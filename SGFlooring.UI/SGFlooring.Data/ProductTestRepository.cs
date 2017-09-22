using SGFlooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data
{
    public class ProductTestRepository : IProductRepository
    {
        private static Product p1 = new Product
        {
            ProductType = "Carpet",
            CostPerSquareFoot = 2.25M,
            LaborCostPerSquareFoot = 2.10M
        };
        private static Product p2 = new Product
        {
            ProductType = "Laminate",
            CostPerSquareFoot = 1.75M,
            LaborCostPerSquareFoot = 2.10M
        };
        private static Product p3 = new Product
        {
            ProductType = "Tile",
            CostPerSquareFoot = 3.50M,
            LaborCostPerSquareFoot = 4.15M
        };
        private static Product p4 = new Product
        {
            ProductType = "Wood",
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M
        };

        private static List<Product> _allProducts = new List<Product>()
        {p1,p2,p3,p4};


        public Product GetProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> ListProducts()
        {
            return _allProducts;
        }
    }
}
