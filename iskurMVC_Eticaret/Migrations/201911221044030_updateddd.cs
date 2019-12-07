namespace iskurMVC_Eticaret.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CreditCards", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditCards", "UserID", c => c.Int(nullable: false));
        }
    }
}
