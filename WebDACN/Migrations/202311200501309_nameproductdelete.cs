namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameproductdelete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_OrderDetail", "Product_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_OrderDetail", "Product_Name", c => c.String());
        }
    }
}
