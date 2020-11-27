namespace Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropPrimaryKey("dbo.Students");
            AddColumn("dbo.Students", "stdId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Students", "stdId");
            AddForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students", "stdId", cascadeDelete: true);
            DropColumn("dbo.Students", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropPrimaryKey("dbo.Students");
            DropColumn("dbo.Students", "stdId");
            AddPrimaryKey("dbo.Students", "Id");
            AddForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
