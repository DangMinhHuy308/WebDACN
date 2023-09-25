namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coupon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Coupon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Code = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tb_Order", "CouponId", c => c.Int());
            CreateIndex("dbo.tb_Order", "CouponId");
            AddForeignKey("dbo.tb_Order", "CouponId", "dbo.tb_Coupon", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Order", "CouponId", "dbo.tb_Coupon");
            DropIndex("dbo.tb_Order", new[] { "CouponId" });
            DropColumn("dbo.tb_Order", "CouponId");
            DropTable("dbo.tb_Coupon");
        }
    }
}
