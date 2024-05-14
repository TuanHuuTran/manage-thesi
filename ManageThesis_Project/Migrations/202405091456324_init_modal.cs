namespace ManageThesis_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_modal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Communication",
                c => new
                    {
                        CommunicationId = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        StudentId = c.Int(),
                        TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.CommunicationId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                        StudentCode = c.String(),
                        ThesisId = c.Int(),
                        GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Group", t => t.GroupId)
                .ForeignKey("dbo.Thesis", t => t.ThesisId)
                .Index(t => t.ThesisId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        StudentSlot = c.Int(nullable: false),
                        ThesisId = c.Int(),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.Thesis", t => t.ThesisId)
                .Index(t => t.ThesisId);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        Status = c.String(),
                        Start_Date = c.DateTime(nullable: false),
                        End_Date = c.DateTime(nullable: false),
                        TaskPoint = c.Int(),
                        ThesisId = c.Int(),
                        GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Group", t => t.GroupId)
                .ForeignKey("dbo.Thesis", t => t.ThesisId)
                .Index(t => t.ThesisId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Thesis",
                c => new
                    {
                        ThesisId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        Gener = c.String(),
                        Teachnology = c.String(nullable: false, maxLength: 100),
                        Requirement = c.String(),
                        NumberofStudent = c.Int(nullable: false),
                        TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.ThesisId)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Communication", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Communication", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Thesis", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Task", "ThesisId", "dbo.Thesis");
            DropForeignKey("dbo.Student", "ThesisId", "dbo.Thesis");
            DropForeignKey("dbo.Group", "ThesisId", "dbo.Thesis");
            DropForeignKey("dbo.Task", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Student", "GroupId", "dbo.Group");
            DropIndex("dbo.Thesis", new[] { "TeacherId" });
            DropIndex("dbo.Task", new[] { "GroupId" });
            DropIndex("dbo.Task", new[] { "ThesisId" });
            DropIndex("dbo.Group", new[] { "ThesisId" });
            DropIndex("dbo.Student", new[] { "GroupId" });
            DropIndex("dbo.Student", new[] { "ThesisId" });
            DropIndex("dbo.Communication", new[] { "TeacherId" });
            DropIndex("dbo.Communication", new[] { "StudentId" });
            DropTable("dbo.Teacher");
            DropTable("dbo.Thesis");
            DropTable("dbo.Task");
            DropTable("dbo.Group");
            DropTable("dbo.Student");
            DropTable("dbo.Communication");
        }
    }
}
