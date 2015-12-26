namespace MySchool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComboListAdded5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Users.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 100),
                        Author = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedBy = c.String(maxLength: 100),
                        ModifiedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Users.Book");
        }
    }
}
