namespace Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class std_dept_rel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "Department_DepartmentId" });
            RenameColumn(table: "dbo.Students", name: "Department_DepartmentId", newName: "DeptId");
            AlterColumn("dbo.Students", "DeptId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "DeptId");
            AddForeignKey("dbo.Students", "DeptId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DeptId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DeptId" });
            AlterColumn("dbo.Students", "DeptId", c => c.Int());
            RenameColumn(table: "dbo.Students", name: "DeptId", newName: "Department_DepartmentId");
            CreateIndex("dbo.Students", "Department_DepartmentId");
            AddForeignKey("dbo.Students", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
        }
    }
}
