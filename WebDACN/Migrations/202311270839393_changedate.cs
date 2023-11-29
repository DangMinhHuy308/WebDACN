namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tb_Coupon", "CreatedBy");
            DropColumn("dbo.tb_Coupon", "CreatedDate");
            DropColumn("dbo.tb_Coupon", "ModifiedDate");
            DropColumn("dbo.tb_Coupon", "ModifiedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Coupon", "ModifiedBy", c => c.String());
            AddColumn("dbo.tb_Coupon", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Coupon", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Coupon", "CreatedBy", c => c.String());
        }
    }
}
