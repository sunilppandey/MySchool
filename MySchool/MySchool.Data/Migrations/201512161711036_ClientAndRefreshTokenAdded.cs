namespace MySchool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientAndRefreshTokenAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Users.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Secret = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        ApplicationType = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RefreshTokenLifeTime = c.Int(nullable: false),
                        AllowedOrigin = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Users.RefreshToken",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false, maxLength: 50),
                        ClientId = c.String(nullable: false, maxLength: 50),
                        IssuedUtc = c.DateTime(nullable: false),
                        ExpiresUtc = c.DateTime(nullable: false),
                        ProtectedTicket = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Users.RefreshToken");
            DropTable("Users.Client");
        }
    }
}
