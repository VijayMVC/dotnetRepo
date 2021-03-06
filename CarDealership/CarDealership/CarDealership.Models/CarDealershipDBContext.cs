﻿using CarDealership.Models.Tables;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class CarDealershipDBContext : IdentityDbContext<AppUser>
    {
        public CarDealershipDBContext() : base("CarDealership2")
        {

        }

        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<ContactUs> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseType> PurchaseTypes { get; set; }
        public DbSet<Special> Specials { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
