namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "MyCategory");
            RenameTable(name: "dbo.ProviderProducts", newName: "Providing");
            DropIndex("dbo.Products", new[] { "categories_categoryId" });
            RenameColumn(table: "dbo.Products", name: "categories_categoryId", newName: "categoryId");
            RenameColumn(table: "dbo.Providing", name: "Provider_Id", newName: "Provider");
            RenameColumn(table: "dbo.Providing", name: "Product_ProductID", newName: "Product");
            RenameIndex(table: "dbo.Providing", name: "IX_Product_ProductID", newName: "IX_Product");
            RenameIndex(table: "dbo.Providing", name: "IX_Provider_Id", newName: "IX_Provider");
            DropPrimaryKey("dbo.Providing");
            AddColumn("dbo.Products", "IsBiological", c => c.Int());
            AlterColumn("dbo.MyCategory", "name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 200));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "labadresse_StreetAddress", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "categoryId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Providing", new[] { "Product", "Provider" });
            CreateIndex("dbo.Products", "categoryId");
            DropColumn("dbo.Products", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropIndex("dbo.Products", new[] { "categoryId" });
            DropPrimaryKey("dbo.Providing");
            AlterColumn("dbo.Products", "categoryId", c => c.Int());
            AlterColumn("dbo.Products", "labadresse_StreetAddress", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.MyCategory", "name", c => c.String());
            DropColumn("dbo.Products", "IsBiological");
            AddPrimaryKey("dbo.Providing", new[] { "Provider_Id", "Product_ProductID" });
            RenameIndex(table: "dbo.Providing", name: "IX_Provider", newName: "IX_Provider_Id");
            RenameIndex(table: "dbo.Providing", name: "IX_Product", newName: "IX_Product_ProductID");
            RenameColumn(table: "dbo.Providing", name: "Product", newName: "Product_ProductID");
            RenameColumn(table: "dbo.Providing", name: "Provider", newName: "Provider_Id");
            RenameColumn(table: "dbo.Products", name: "categoryId", newName: "categories_categoryId");
            CreateIndex("dbo.Products", "categories_categoryId");
            RenameTable(name: "dbo.Providing", newName: "ProviderProducts");
            RenameTable(name: "dbo.MyCategory", newName: "Categories");
        }
    }
}
