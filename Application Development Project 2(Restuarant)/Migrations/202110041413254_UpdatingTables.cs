namespace Application_Development_Project_2_Restuarant_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingTables : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Drivers", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "Id", c => c.Int(nullable: false));
        }
    }
}
