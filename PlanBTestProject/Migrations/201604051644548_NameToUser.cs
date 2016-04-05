namespace PlanBTestProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
