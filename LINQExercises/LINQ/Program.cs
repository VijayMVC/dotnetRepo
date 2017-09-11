using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13();
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise21();dont do
            //Exercise22();
            //Exercise23();
            //Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise27();
            //Exercise28();
            //Exercise29();
            //Exercise30();
            //Exercise31();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            var filter = DataLoader.LoadProducts().Where(p => p.UnitsInStock < 1);

            PrintProductInformation(filter);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            var filter = DataLoader.LoadProducts().Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            PrintProductInformation(filter);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var filter = DataLoader.LoadCustomers().Where(c => c.Region == "WA");

            PrintCustomerInformation(filter);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var Products = DataLoader.LoadProducts();
            var results = from product in Products
                          select new
                          {
                              productName = product.ProductName
                          };

            Console.WriteLine("{0, -20}",
            "Product Name\n__________________");

            foreach (var row in results)
            {
                Console.WriteLine("{0, -20}",
                row.productName);
            }
        } 

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            var products = DataLoader.LoadProducts();
            var results = from product in products
                          select new
                          {
                              ProductName = product.ProductName,
                              Category = product.Category,
                              ProductID = product.ProductID,
                              UnitPrice = product.UnitPrice * 1.25M,
                              UnitsInStock = product.UnitsInStock
                          };

            Console.WriteLine("{0, -10} {1,-35} {2,-20} {3,-10} {4,-10}",
    "Product ID", "Product Name", "Category", "Unit Price", "Stock");

            foreach (var row in results)
            {
                Console.WriteLine("{0, -10} {1,-35} {2,-20} {3,-10:c} {4,-10}",
                    row.ProductID, row.ProductName, row.Category, row.UnitPrice, row.UnitsInStock);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            var products = DataLoader.LoadProducts();
            var results = from product in products
                          select new
                          {
                              ProductName = product.ProductName.ToUpper(),
                              Category = product.Category.ToUpper(),
                          };

            Console.WriteLine("{0, -35} {1,-20}", "PRODUCT NAME", "CATEGORY");
            foreach (var row in results)
            {
                Console.WriteLine("{0, -35} {1,-20}"
                    , row.ProductName, row.Category);
            }


        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            string header = "{0, -10} {1,-35} {2,-20} {3,-10} {4,-10} {5,-5}";
            var results = from p in DataLoader.LoadProducts()
                          select new
                          {
                              ProductName = p.ProductName,
                              Category = p.Category,
                              ProductID = p.ProductID,
                              UnitPrice = p.UnitPrice,
                              UnitsInStock = p.UnitsInStock,
                              ReOrder = p.UnitsInStock < 3
                          };

            Console.WriteLine(header,
"Product ID", "Product Name", "Category", "Unit Price", "Stock", "Re Order");

            foreach (var product in results)
            {
            Console.WriteLine(header,
product.ProductID, product.ProductName, product.Category, product.UnitPrice, product.UnitsInStock, product.ReOrder);   
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            string header = "{0, -10} {1,-35} {2,-20} {3,-10:c} {4,-10} {5,-6:c}";
            var AllProducts = from p in DataLoader.LoadProducts()
                          select new
                          {
                              ProductName = p.ProductName,
                              Category = p.Category,
                              ProductID = p.ProductID,
                              UnitPrice = p.UnitPrice,
                              UnitsInStock = p.UnitsInStock,
                              StockValue = p.UnitPrice * p.UnitsInStock
                          };

            Console.WriteLine(header, "Product ID", "Product Name", "Category", "Unit Price", "Inventory", "Inventory Cost");
            foreach(var p in AllProducts)
            {
                Console.WriteLine(header, p.ProductID, p.ProductName, p.Category, p.UnitPrice, p.UnitsInStock, p.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var Nums = from number in DataLoader.NumbersA
                              where number % 2 == 0
                              select number;

            Console.WriteLine(string.Join(",",Nums));
            Console.ReadLine();
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            var cust = DataLoader.LoadCustomers().Where(c => c.Orders.Any(cl => cl.Total < 500));
            //var cust = from c in DataLoader.LoadCustomers()
            //           where c.Orders.Sum(o => o.Total) < 500
            //           select c;

            PrintCustomerInformation(cust);


        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var Nums = DataLoader.NumbersC.Where(c => c % 2 == 1).Take(3);
                      
            Console.WriteLine(string.Join(",", Nums));
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var Nums = DataLoader.NumbersB.Skip(3);

            Console.WriteLine(string.Join(",", Nums));
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            string header = "{0, -35} {1,-5}";
            var customers = from c in DataLoader.LoadCustomers()
                            where c.Region == "WA" && c.Orders != null                          
                            select new
                            {
                                c.CompanyName,
                                c.Region,
                                Order = c.Orders.Last()

                            };
            Console.WriteLine(header, "Company", "Region");
            foreach(var row in customers)
            {
                Console.WriteLine(header, row.CompanyName, row.Region);
                Console.WriteLine();
                Console.WriteLine("\tLast Order");
                Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", row.Order.OrderID, row.Order.OrderDate, row.Order.Total);
                Console.WriteLine("============================================\n");
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var numbers = from n in DataLoader.NumbersC.TakeWhile(n => n < 7) select n;
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            List<int> numbers = DataLoader.NumbersC.SkipWhile(n => n % 3 != 0).ToList();
            numbers.RemoveAt(0);
            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var prods = DataLoader.LoadProducts().OrderBy(p => p.ProductName);
            PrintProductInformation(prods);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var products = from p in DataLoader.LoadProducts()
                           orderby p.UnitsInStock descending
                           select p;

            PrintProductInformation(products);         
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            var products = from p in DataLoader.LoadProducts()
                           orderby p.Category, p.UnitPrice descending
                           select p;

            PrintProductInformation(products);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var nums = DataLoader.NumbersA.Reverse();
            foreach (var number in nums)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var prods = from products in DataLoader.LoadProducts()
                        orderby products.Category, products.ProductName
                        group products by products.Category;

            foreach(var group in prods)
            {
                Console.WriteLine(group.Key);
                foreach(var products in group)
                {
                    Console.WriteLine("\t{0}", products.ProductName);
                }
            }
                    
                
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        //skip this one!!! static void Exercise21()
        //{

        //}

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var cats = DataLoader.LoadProducts().GroupBy(c => c.Category);
            foreach (var group in cats)
            {
                Console.WriteLine(group.Key);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var prods = DataLoader.LoadProducts().TakeWhile(p => p.ProductID == 789);

            PrintProductInformation(prods);
            
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var groups = DataLoader.LoadProducts().OrderBy(p => p.UnitsInStock).GroupBy(p => p.Category);
                        
            foreach(var group in groups.Distinct())
            {
                
                foreach (var product in group.TakeWhile(p => p.UnitsInStock == 0).Take(1))
                {
                    Console.WriteLine("{0}", group.Key);
                    Console.WriteLine("at least one item out of stock\n");  
                }
            }
                


        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            var prods = DataLoader.LoadProducts().GroupBy(p => p.Category).Where(pl => pl.All(p => p.UnitsInStock > 0));
          
            foreach (var group in prods)
            {
                Console.WriteLine(group.Key);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            int i = 0;
            var nums = from n in DataLoader.NumbersA
                       where n % 2 == 1
                       select n;

            foreach (var number in nums)
            {
                i++;
            }
            Console.WriteLine(i);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var customers = from c in DataLoader.LoadCustomers()
                            select new
                            {
                                c.CustomerID,
                                OrdersTotal = c.Orders.Count()
                            };

            Console.WriteLine("{0,-20} {1,-10}", "Customer ID", "# of Orders");
            foreach(var c in customers)
            {
                Console.WriteLine("{0,-20} {1,-10}", c.CustomerID, c.OrdersTotal);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            var prods = from products in DataLoader.LoadProducts()
                        orderby products.Category
                        group products by products.Category;

            foreach (var group in prods)
            {
                Console.WriteLine(group.Key);
                Console.WriteLine(group.Key.Count() + " products");
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var groups = from g in DataLoader.LoadProducts()
                         group g by g.Category into newGroup
                         select new
                         {
                             Category = newGroup.Key,
                             TotalUnits = newGroup.Sum(g => g.UnitsInStock)
                         };

            foreach (var group in groups)
            {
                Console.WriteLine("Category: {0}", group.Category);
                Console.WriteLine("Total Units: {0}", group.TotalUnits);
                Console.WriteLine();

            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var groups = DataLoader.LoadProducts().OrderBy(p => p.UnitPrice).GroupBy(p => p.Category);

            foreach(var group in groups)
            {
                Console.WriteLine("Category: {0}", group.Key);
                Console.WriteLine();

                foreach (var product in group.Take(1))
                {
                    Console.WriteLine("Lowest Price Product: {0}", product.ProductName);
                    Console.WriteLine("Price: {0:c}", product.UnitPrice);
                    Console.WriteLine("_______________________________________________________");
                }
            };
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var groups = (from g in DataLoader.LoadProducts()                
                         group g by g.Category into newGroup
                         select new
                         {
                             Category = newGroup.Key,
                             AveragePrice = newGroup.Average(g => g.UnitPrice) 
                         }).OrderByDescending(g => g.AveragePrice).Take(3);

            
            foreach (var group in groups)
            {
                    Console.WriteLine("Category: {0}", group.Category);
                    Console.WriteLine("Average Price: {0:c}", group.AveragePrice);
                    Console.WriteLine();
            }
        }
    }
}
