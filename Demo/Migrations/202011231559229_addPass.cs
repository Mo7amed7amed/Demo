namespace Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Password", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Password");
            DropColumn("dbo.Students", "UserName");
        }
    }
}
