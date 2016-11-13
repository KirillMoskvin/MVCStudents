namespace MVCStudents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectStudents",
                c => new
                    {
                        Subject_SubjectId = c.Int(nullable: false),
                        Student_StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_SubjectId, t.Student_StudentId })
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .Index(t => t.Subject_SubjectId)
                .Index(t => t.Student_StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectStudents", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.SubjectStudents", "Subject_SubjectId", "dbo.Subjects");
            DropIndex("dbo.SubjectStudents", new[] { "Student_StudentId" });
            DropIndex("dbo.SubjectStudents", new[] { "Subject_SubjectId" });
            DropTable("dbo.SubjectStudents");
        }
    }
}
