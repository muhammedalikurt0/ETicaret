namespace iskurMVC_Eticaret.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        RoleID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleID, t.UserID })
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserRoles1",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Roles_RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Roles_RoleID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Roles_RoleID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.Roles_RoleID);
            
            DropColumn("dbo.Users", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Role", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.UserRoles", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.UserRoles1", "Roles_RoleID", "dbo.Roles");
            DropForeignKey("dbo.UserRoles1", "User_UserID", "dbo.Users");
            DropIndex("dbo.UserRoles1", new[] { "Roles_RoleID" });
            DropIndex("dbo.UserRoles1", new[] { "User_UserID" });
            DropIndex("dbo.UserRoles", new[] { "UserID" });
            DropIndex("dbo.UserRoles", new[] { "RoleID" });
            DropTable("dbo.UserRoles1");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
        }
    }
}
