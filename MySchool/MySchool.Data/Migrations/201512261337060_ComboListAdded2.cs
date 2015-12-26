namespace MySchool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComboListAdded2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("MstAppl.ComboList", "CreatedBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("MstAppl.ComboList", "ModifiedBy", c => c.String(maxLength: 100));
            AlterColumn("MstAppl.ComboListValue", "CreatedBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("MstAppl.ComboListValue", "ModifiedBy", c => c.String(maxLength: 100));
            DropTable("Users.Book");
        }
        
        public override void Down()
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
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("MstAppl.ComboListValue", "ModifiedBy", c => c.String());
            AlterColumn("MstAppl.ComboListValue", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("MstAppl.ComboList", "ModifiedBy", c => c.String());
            AlterColumn("MstAppl.ComboList", "CreatedBy", c => c.String(nullable: false));
        }
    }
}
