namespace ManageThesis_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_point : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Point",
                c => new
                    {
                        PointId = c.Int(nullable: false, identity: true),
                        Scores = c.Single(nullable: false),
                        Result = c.String(),
                        ThesisId = c.Int(),
                    })
                .PrimaryKey(t => t.PointId)
                .ForeignKey("dbo.Thesis", t => t.ThesisId)
                .Index(t => t.ThesisId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Point", "ThesisId", "dbo.Thesis");
            DropIndex("dbo.Point", new[] { "ThesisId" });
            DropTable("dbo.Point");
        }
    }
}
