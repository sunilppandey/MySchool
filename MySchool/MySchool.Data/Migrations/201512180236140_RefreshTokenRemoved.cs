namespace MySchool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefreshTokenRemoved : DbMigration
    {
        public override void Up()
        {
            DropTable("Users.RefreshToken");
        }
        
        public override void Down()
        {
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
    }
}
