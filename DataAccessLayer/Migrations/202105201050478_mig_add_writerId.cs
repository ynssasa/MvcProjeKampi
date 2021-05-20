namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_writerId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Headings", "Writer_WriterId", "dbo.Writers");
            DropIndex("dbo.Headings", new[] { "Writer_WriterId" });
            RenameColumn(table: "dbo.Headings", name: "Writer_WriterId", newName: "WriterId");
            AlterColumn("dbo.Headings", "WriterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Headings", "WriterId");
            AddForeignKey("dbo.Headings", "WriterId", "dbo.Writers", "WriterId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Headings", "WriterId", "dbo.Writers");
            DropIndex("dbo.Headings", new[] { "WriterId" });
            AlterColumn("dbo.Headings", "WriterId", c => c.Int());
            RenameColumn(table: "dbo.Headings", name: "WriterId", newName: "Writer_WriterId");
            CreateIndex("dbo.Headings", "Writer_WriterId");
            AddForeignKey("dbo.Headings", "Writer_WriterId", "dbo.Writers", "WriterId");
        }
    }
}
