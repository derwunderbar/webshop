namespace WebShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddOrderAndCustomerTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.Int(nullable: false),
                    Title = c.String(nullable: false),
                    FirstName = c.String(nullable: false),
                    LastName = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    City = c.String(nullable: false),
                    Address = c.String(nullable: false),
                    HouseNumber = c.String(nullable: false),
                    ZipCode = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);
            AddForeignKey("dbo.Customers", "UserId", "dbo.UserProfile", "UserId");

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.Int(nullable: false),
                    CustomerId = c.Int(nullable: false),
                    SubTotal = c.Decimal(nullable: false),
                    Vat = c.Decimal(nullable: false),
                    Total = c.Decimal(nullable: false),
                    Created = c.DateTime(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    Closed = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);
            AddForeignKey("dbo.Orders", "UserId", "dbo.UserProfile", "UserId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id");

            CreateTable(
                "dbo.OrderLines",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    OrderId = c.Int(nullable: false),
                    ArticleId = c.Int(nullable: false),
                    Price = c.Decimal(nullable: false),
                    Count = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);
            AddForeignKey("dbo.OrderLines", "OrderId", "dbo.Orders", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderLines", "OrderId", "dbo.Orders", "Id");
            DropTable("dbo.OrderLines");

            DropForeignKey("dbo.Orders", "UserId", "dbo.UserProfile", "UserId");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id");
            DropTable("dbo.Orders");

            DropForeignKey("dbo.Customers", "UserId", "dbo.UserProfile", "UserId");
            DropTable("dbo.Customers");
        }
    }
}