namespace Application_Development_Project_2_Restuarant_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CusId = c.Int(nullable: false, identity: true),
                        CusName = c.String(nullable: false),
                        CusSurname = c.String(nullable: false),
                        CusEmail = c.String(nullable: false),
                        CusPhone = c.Int(nullable: false),
                        CusPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CusId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DivId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        DrivName = c.String(nullable: false),
                        DrivSurname = c.String(nullable: false),
                        DrivPhone = c.Int(nullable: false),
                        DrivEmail = c.String(nullable: false),
                        DrivPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DivId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItmId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Category = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discription = c.String(nullable: false),
                        ImagePath = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        OdetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItmId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OdetId = c.Int(nullable: false),
                        ItmId = c.Int(nullable: false),
                        OdId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UnitPriceSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantitySale = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OdetId, t.ItmId, t.OdId })
                .ForeignKey("dbo.Items", t => t.ItmId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OdId, cascadeDelete: true)
                .Index(t => t.ItmId)
                .Index(t => t.OdId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OdId = c.Int(nullable: false, identity: true),
                        OdDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.OdId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OdId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ItmId", "dbo.Items");
            DropIndex("dbo.OrderDetails", new[] { "OdId" });
            DropIndex("dbo.OrderDetails", new[] { "ItmId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Items");
            DropTable("dbo.Drivers");
            DropTable("dbo.Customers");
            DropTable("dbo.Admins");
        }
    }
}
