namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IconProductCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_ProductCategory", "Icon", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_ProductCategory", "Icon");
        }
    }
}
