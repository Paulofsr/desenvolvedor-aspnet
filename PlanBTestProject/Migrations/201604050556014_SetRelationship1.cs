namespace PlanBTestProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetRelationship1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Skill_ID", "dbo.Skills");
            DropIndex("dbo.AspNetUsers", new[] { "Skill_ID" });
            CreateTable(
                "dbo.SkillApplicationUsers",
                c => new
                    {
                        Skill_ID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Skill_ID, t.ApplicationUser_Id })
                .ForeignKey("dbo.Skills", t => t.Skill_ID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Skill_ID)
                .Index(t => t.ApplicationUser_Id);
            
            DropColumn("dbo.AspNetUsers", "Skill_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Skill_ID", c => c.Int());
            DropForeignKey("dbo.SkillApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SkillApplicationUsers", "Skill_ID", "dbo.Skills");
            DropIndex("dbo.SkillApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SkillApplicationUsers", new[] { "Skill_ID" });
            DropTable("dbo.SkillApplicationUsers");
            CreateIndex("dbo.AspNetUsers", "Skill_ID");
            AddForeignKey("dbo.AspNetUsers", "Skill_ID", "dbo.Skills", "ID");
        }
    }
}
