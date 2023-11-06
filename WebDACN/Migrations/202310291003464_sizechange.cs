namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sizechange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Product", "SizeId", "dbo.tb_Size");
            DropIndex("dbo.tb_Product", new[] { "SizeId" });
            DropColumn("dbo.tb_Product", "SizeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Product", "SizeId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Product", "SizeId");
            AddForeignKey("dbo.tb_Product", "SizeId", "dbo.tb_Size", "Id", cascadeDelete: true);
        }
    }
}
