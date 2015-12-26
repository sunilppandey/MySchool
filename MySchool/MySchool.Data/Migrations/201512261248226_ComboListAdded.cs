namespace MySchool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComboListAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "MstAppl.ComboList",
                c => new
                    {
                        CTComboListId = c.Byte(nullable: false),
                        ListDesc = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CTComboListId);
            
            CreateTable(
                "MstAppl.ComboListValue",
                c => new
                    {
                        CTComboListId = c.Byte(nullable: false),
                        ValueId = c.Byte(nullable: false),
                        DisplayValue = c.String(nullable: false, maxLength: 100),
                        UserAsDefault = c.Boolean(nullable: false),
                        SortOrder = c.Byte(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.CTComboListId, t.ValueId })
                .ForeignKey("MstAppl.ComboList", t => t.CTComboListId, cascadeDelete: true)
                .Index(t => t.CTComboListId);
            
            AddColumn("Users.Book", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("Users.Book", "CreatedBy", c => c.String(nullable: false));
            AddColumn("Users.Book", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("MstAppl.ComboListValue", "CTComboListId", "MstAppl.ComboList");
            DropIndex("MstAppl.ComboListValue", new[] { "CTComboListId" });
            DropColumn("Users.Book", "ModifiedBy");
            DropColumn("Users.Book", "CreatedBy");
            DropColumn("Users.Book", "IsDeleted");
            DropTable("MstAppl.ComboListValue");
            DropTable("MstAppl.ComboList");
        }
    }
}
