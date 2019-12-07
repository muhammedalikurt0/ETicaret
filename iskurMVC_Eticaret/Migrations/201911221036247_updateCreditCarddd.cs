namespace iskurMVC_Eticaret.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCreditCarddd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditCards", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CreditCards", "UserID");
        }
    }
}
