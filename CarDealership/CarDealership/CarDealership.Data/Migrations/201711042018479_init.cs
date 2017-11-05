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
                        EmployeeID = c.Int(nullable: false),
                        BodyTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarModelID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorID = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.ColorID);
            
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
                        VinNumber = c.String(),
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
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
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
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Interiors",
                c => new
                    {
                        InteriorID = c.Int(nullable: false, identity: true),
                        InteriorName = c.String(),
                    })
                .PrimaryKey(t => t.InteriorID);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        MakeID = c.Int(nullable: false, identity: true),
                        MakeName = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModelID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MakeID);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VinNumber = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchaseTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID);
            
            CreateTable(
                "dbo.PurchaseTypes",
                c => new
                    {
                        PurchaseTypeID = c.Int(nullable: false, identity: true),
                        PurchaseTypeName = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseTypeID);
            
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
                        Transmission = c.String(),
                        Year = c.DateTime(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        IsFeatured = c.Boolean(nullable: false),
                        ModelID = c.Int(nullable: false),
                        ColorID = c.Int(nullable: false),
                        InteriorID = c.Int(nullable: false),
                        BodyTypeID = c.Int(nullable: false),
                        SpecialsID = c.Int(nullable: false),
                        ImageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
            DropTable("dbo.Specials");
            DropTable("dbo.PurchaseTypes");
            DropTable("dbo.Purchases");
            DropTable("dbo.Makes");
            DropTable("dbo.Interiors");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Colors");
            DropTable("dbo.CarModels");
            DropTable("dbo.BodyTypes");
        }
    }
}
