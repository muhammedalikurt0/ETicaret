namespace iskurMVC_Eticaret.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditCards : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CardID = c.Int(nullable: false, identity: true),
                        CardTitle = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IBAN = c.String(),
                        CVC = c.Int(nullable: false),
                        CustomerFullName = c.Int(nullable: false),
                        Valid = c.String(),
                    })
                .PrimaryKey(t => t.CardID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CreditCards");
        }
    }
}
