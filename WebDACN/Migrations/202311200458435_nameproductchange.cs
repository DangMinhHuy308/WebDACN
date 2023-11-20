namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameproductchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_OrderDetail", "Product_Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_OrderDetail", "Product_Name", c => c.Int(nullable: false));
        }
    }
}
