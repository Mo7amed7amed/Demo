namespace Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class names : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Students", name: "DeptId", newName: "DepartmentId");
            RenameIndex(table: "dbo.Students", name: "IX_DeptId", newName: "IX_DepartmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Students", name: "IX_DepartmentId", newName: "IX_DeptId");
            RenameColumn(table: "dbo.Students", name: "DepartmentId", newName: "DeptId");
        }
    }
}
