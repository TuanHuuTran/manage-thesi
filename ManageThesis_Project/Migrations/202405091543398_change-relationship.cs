namespace ManageThesis_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changerelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Communication", "ThesisId", c => c.Int());
            CreateIndex("dbo.Communication", "ThesisId");
            AddForeignKey("dbo.Communication", "ThesisId", "dbo.Thesis", "ThesisId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Communication", "ThesisId", "dbo.Thesis");
            DropIndex("dbo.Communication", new[] { "ThesisId" });
            DropColumn("dbo.Communication", "ThesisId");
        }
    }
}
