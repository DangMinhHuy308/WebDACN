namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetablePI : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_ProductImage", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_ProductImage", new[] { "ProductId" });
            DropTable("dbo.tb_ProductImage");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_ProductImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Image = c.String(),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.tb_ProductImage", "ProductId");
            AddForeignKey("dbo.tb_ProductImage", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
        }
    }
}
