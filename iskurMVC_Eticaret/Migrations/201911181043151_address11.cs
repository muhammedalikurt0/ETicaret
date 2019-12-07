namespace iskurMVC_Eticaret.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class address11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles1", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserRoles1", "Roles_RoleID", "dbo.Roles");
            DropIndex("dbo.UserRoles1", new[] { "User_UserID" });
            DropIndex("dbo.UserRoles1", new[] { "Roles_RoleID" });
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        AddresName = c.String(maxLength: 25),
                        _Address = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);

            DropTable("dbo.UserRoles1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles1",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Roles_RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Roles_RoleID });
            
            DropForeignKey("dbo.Addresses", "UserID", "dbo.Users");
            DropIndex("dbo.Addresses", new[] { "UserID" });
            DropTable("dbo.Addresses");
            CreateIndex("dbo.UserRoles1", "Roles_RoleID");
            CreateIndex("dbo.UserRoles1", "User_UserID");
            AddForeignKey("dbo.UserRoles1", "Roles_RoleID", "dbo.Roles", "RoleID", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles1", "User_UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
