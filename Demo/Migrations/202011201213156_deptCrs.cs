namespace Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deptCrs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentCourses",
                c => new
                    {
                        Department_DepartmentId = c.Int(nullable: false),
                        Course_CrsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Department_DepartmentId, t.Course_CrsId })
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CrsId, cascadeDelete: true)
                .Index(t => t.Department_DepartmentId)
                .Index(t => t.Course_CrsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepartmentCourses", "Course_CrsId", "dbo.Courses");
            DropForeignKey("dbo.DepartmentCourses", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.DepartmentCourses", new[] { "Course_CrsId" });
            DropIndex("dbo.DepartmentCourses", new[] { "Department_DepartmentId" });
            DropTable("dbo.DepartmentCourses");
        }
    }
}
