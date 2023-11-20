namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletewishlist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Wishlist", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_Wishlist", new[] { "ProductId" });
            DropTable("dbo.tb_Wishlist");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_Wishlist",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.tb_Wishlist", "ProductId");
            AddForeignKey("dbo.tb_Wishlist", "ProductId", "dbo.tb_Product", "Id", cascadeDelete: true);
        }
    }
}
