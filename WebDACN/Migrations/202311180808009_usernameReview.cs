namespace WebDACN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernameReview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Review", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Review", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Review", "Email", c => c.String(nullable: false));
            DropColumn("dbo.tb_Review", "UserName");
        }
    }
}
