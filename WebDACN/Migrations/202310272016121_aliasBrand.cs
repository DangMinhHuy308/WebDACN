namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aliasBrand : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Brand", "Alias", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Brand", "Alias");
        }
    }
}
