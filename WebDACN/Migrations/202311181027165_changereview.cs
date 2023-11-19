namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changereview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Review", "FullName", c => c.String());
            AddColumn("dbo.tb_Review", "Content", c => c.String());
            AlterColumn("dbo.tb_Review", "UserName", c => c.String());
            DropColumn("dbo.tb_Review", "Name");
            DropColumn("dbo.tb_Review", "Message");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Review", "Message", c => c.String(maxLength: 4000));
            AddColumn("dbo.tb_Review", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.tb_Review", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.tb_Review", "Content");
            DropColumn("dbo.tb_Review", "FullName");
        }
    }
}
