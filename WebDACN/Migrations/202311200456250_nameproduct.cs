namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_OrderDetail", "Product_Name", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_OrderDetail", "Product_Name");
        }
    }
}
