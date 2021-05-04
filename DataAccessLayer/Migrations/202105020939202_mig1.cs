namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "WriterId", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "WriterId" });
            AlterColumn("dbo.Contents", "WriterId", c => c.Int());
            CreateIndex("dbo.Contents", "WriterId");
            AddForeignKey("dbo.Contents", "WriterId", "dbo.Writers", "WriterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "WriterId", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "WriterId" });
            AlterColumn("dbo.Contents", "WriterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contents", "WriterId");
            AddForeignKey("dbo.Contents", "WriterId", "dbo.Writers", "WriterId", cascadeDelete: true);
        }
    }
}
