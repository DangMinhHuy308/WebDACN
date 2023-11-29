namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class couponcode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "CouponCode", c => c.String());
            AddColumn("dbo.tb_Order", "DiscountAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Order", "DiscountAmount");
            DropColumn("dbo.tb_Order", "CouponCode");
        }
    }
}
