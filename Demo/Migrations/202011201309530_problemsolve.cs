namespace Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class problemsolve : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Capacity", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Email", c => c.Int(nullable: false));
            DropColumn("dbo.Departments", "Capacity");
        }
    }
}
