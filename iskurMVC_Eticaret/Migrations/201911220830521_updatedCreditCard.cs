namespace iskurMVC_Eticaret.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedCreditCard : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreditCards", "CustomerFullName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CreditCards", "CustomerFullName", c => c.Int(nullable: false));
        }
    }
}
