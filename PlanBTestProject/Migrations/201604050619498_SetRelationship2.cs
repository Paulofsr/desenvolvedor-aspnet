namespace PlanBTestProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetRelationship2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SkillApplicationUsers", name: "Skill_ID", newName: "UserId");
            RenameColumn(table: "dbo.SkillApplicationUsers", name: "ApplicationUser_Id", newName: "SkillId");
            RenameIndex(table: "dbo.SkillApplicationUsers", name: "IX_Skill_ID", newName: "IX_UserId");
            RenameIndex(table: "dbo.SkillApplicationUsers", name: "IX_ApplicationUser_Id", newName: "IX_SkillId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SkillApplicationUsers", name: "IX_SkillId", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.SkillApplicationUsers", name: "IX_UserId", newName: "IX_Skill_ID");
            RenameColumn(table: "dbo.SkillApplicationUsers", name: "SkillId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.SkillApplicationUsers", name: "UserId", newName: "Skill_ID");
        }
    }
}
