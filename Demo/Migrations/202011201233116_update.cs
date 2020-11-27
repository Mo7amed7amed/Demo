namespace Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DepartmentCourses", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Students", "DeptId", "dbo.Departments");
            RenameColumn(table: "dbo.DepartmentCourses", name: "Department_DepartmentId", newName: "Department_DeptId");
            RenameIndex(table: "dbo.DepartmentCourses", name: "IX_Department_DepartmentId", newName: "IX_Department_DeptId");
            DropPrimaryKey("dbo.Departments");
            DropPrimaryKey("dbo.Students");
            AddColumn("dbo.Departments", "DeptId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Departments", "DeptId");
            AddPrimaryKey("dbo.Students", "Id");
            AddForeignKey("dbo.DepartmentCourses", "Department_DeptId", "dbo.Departments", "DeptId", cascadeDelete: true);
            AddForeignKey("dbo.Students", "DeptId", "dbo.Departments", "DeptId", cascadeDelete: true);
            DropColumn("dbo.Departments", "DepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "DepartmentId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Students", "DeptId", "dbo.Departments");
            DropForeignKey("dbo.DepartmentCourses", "Department_DeptId", "dbo.Departments");
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.Departments");
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Students", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Departments", "DeptId");
            AddPrimaryKey("dbo.Students", "Id");
            AddPrimaryKey("dbo.Departments", "DepartmentId");
            RenameIndex(table: "dbo.DepartmentCourses", name: "IX_Department_DeptId", newName: "IX_Department_DepartmentId");
            RenameColumn(table: "dbo.DepartmentCourses", name: "Department_DeptId", newName: "Department_DepartmentId");
            AddForeignKey("dbo.Students", "DeptId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.DepartmentCourses", "Department_DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
    }
}
