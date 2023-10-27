namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsNewProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "IsNewProduct", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "IsNewProduct");
        }
    }
}
