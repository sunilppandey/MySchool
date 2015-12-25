namespace MySchool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientEntityUpdated : DbMigration
    {
        public override void Up()
        {
            DropTable("Users.Client");
        }
        
        public override void Down()
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
            
        }
    }
}
