namespace iskurMVC_Eticaret.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Phone", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "Phone");
        }
    }
}
