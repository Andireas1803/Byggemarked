namespace HomeDepotWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingTool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Tool_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "Tool_Id");
            AddForeignKey("dbo.Bookings", "Tool_Id", "dbo.Tools", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Tool_Id", "dbo.Tools");
            DropIndex("dbo.Bookings", new[] { "Tool_Id" });
            DropColumn("dbo.Bookings", "Tool_Id");
        }
    }
}
