namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameproductadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_OrderDetail", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_OrderDetail", "Title");
        }
    }
}
