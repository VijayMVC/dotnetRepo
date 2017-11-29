namespace CarDealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyTypes",
                c => new
                    {
                        BodyTypeID = c.Int(nullable: false, identity: true),
                        BodyTypeName = c.String(),
                    })
                .PrimaryKey(t => t.BodyTypeID);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        CarModelID = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        AMake_MakeID = c.Int(),
                        AnEmployee_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.CarModelID)
                .ForeignKey("dbo.Makes", t => t.AMake_MakeID)
                .ForeignKey("dbo.Employees", t => t.AnEmployee_EmployeeID)
                .Index(t => t.AMake_MakeID)
                .Index(t => t.AnEmployee_EmployeeID);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        MakeID = c.Int(nullable: false, identity: true),
                        MakeName = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        AnEmployee_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.MakeID)
                .ForeignKey("dbo.Employees", t => t.AnEmployee_EmployeeID)
                .Index(t => t.AnEmployee_EmployeeID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Role = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        ContactUsID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactUsID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VinNumber = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        ACustomer_CustomerID = c.Int(),
                        APurchaseType_PurchaseTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseID)
                .ForeignKey("dbo.Customers", t => t.ACustomer_CustomerID)
                .ForeignKey("dbo.PurchaseTypes", t => t.APurchaseType_PurchaseTypeID)
                .Index(t => t.ACustomer_CustomerID)
                .Index(t => t.APurchaseType_PurchaseTypeID);
            
            CreateTable(
                "dbo.PurchaseTypes",
                c => new
                    {
                        PurchaseTypeID = c.Int(nullable: false, identity: true),
                        PurchaseTypeName = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseTypeID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Specials",
                c => new
                    {
                        SpecialID = c.Int(nullable: false, identity: true),
                        SpecialName = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        value = c.Int(nullable: false),
                        Description = c.String(),
                        ImageLocation = c.String(),
                    })
                .PrimaryKey(t => t.SpecialID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        VinNumber = c.String(),
                        Mileage = c.Int(nullable: false),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MSRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        IsAutomatic = c.Boolean(nullable: false),
                        Year = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        IsFeatured = c.Boolean(nullable: false),
                        Color = c.String(),
                        Interior = c.String(),
                        ImageLocation = c.String(),
                        CarBody_BodyTypeID = c.Int(),
                        CarMake_MakeID = c.Int(),
                        CarModel_CarModelID = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleID)
                .ForeignKey("dbo.BodyTypes", t => t.CarBody_BodyTypeID)
                .ForeignKey("dbo.Makes", t => t.CarMake_MakeID)
                .ForeignKey("dbo.CarModels", t => t.CarModel_CarModelID)
                .Index(t => t.CarBody_BodyTypeID)
                .Index(t => t.CarMake_MakeID)
                .Index(t => t.CarModel_CarModelID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VehicleSpecials",
                c => new
                    {
                        Vehicle_VehicleID = c.Int(nullable: false),
                        Special_SpecialID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vehicle_VehicleID, t.Special_SpecialID })
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_VehicleID, cascadeDelete: true)
                .ForeignKey("dbo.Specials", t => t.Special_SpecialID, cascadeDelete: true)
                .Index(t => t.Vehicle_VehicleID)
                .Index(t => t.Special_SpecialID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.VehicleSpecials", "Special_SpecialID", "dbo.Specials");
            DropForeignKey("dbo.VehicleSpecials", "Vehicle_VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "CarModel_CarModelID", "dbo.CarModels");
            DropForeignKey("dbo.Vehicles", "CarMake_MakeID", "dbo.Makes");
            DropForeignKey("dbo.Vehicles", "CarBody_BodyTypeID", "dbo.BodyTypes");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Purchases", "APurchaseType_PurchaseTypeID", "dbo.PurchaseTypes");
            DropForeignKey("dbo.Purchases", "ACustomer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.CarModels", "AnEmployee_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.CarModels", "AMake_MakeID", "dbo.Makes");
            DropForeignKey("dbo.Makes", "AnEmployee_EmployeeID", "dbo.Employees");
            DropIndex("dbo.VehicleSpecials", new[] { "Special_SpecialID" });
            DropIndex("dbo.VehicleSpecials", new[] { "Vehicle_VehicleID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Vehicles", new[] { "CarModel_CarModelID" });
            DropIndex("dbo.Vehicles", new[] { "CarMake_MakeID" });
            DropIndex("dbo.Vehicles", new[] { "CarBody_BodyTypeID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Purchases", new[] { "APurchaseType_PurchaseTypeID" });
            DropIndex("dbo.Purchases", new[] { "ACustomer_CustomerID" });
            DropIndex("dbo.Makes", new[] { "AnEmployee_EmployeeID" });
            DropIndex("dbo.CarModels", new[] { "AnEmployee_EmployeeID" });
            DropIndex("dbo.CarModels", new[] { "AMake_MakeID" });
            DropTable("dbo.VehicleSpecials");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Specials");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PurchaseTypes");
            DropTable("dbo.Purchases");
            DropTable("dbo.Customers");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Employees");
            DropTable("dbo.Makes");
            DropTable("dbo.CarModels");
            DropTable("dbo.BodyTypes");
        }
    }
}
