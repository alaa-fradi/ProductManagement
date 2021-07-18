namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoryId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.categoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        DateProd = c.DateTime(nullable: false),
                        Description = c.String(),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Image = c.String(),
                        Herbs = c.String(),
                        City = c.String(),
                        LabName = c.String(),
                        StreetAddress = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        categories_categoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.categories_categoryId)
                .Index(t => t.categories_categoryId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConfirmPassword = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Email = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        password = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProviderProducts",
                c => new
                    {
                        Provider_Id = c.Int(nullable: false),
                        Product_ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider_Id, t.Product_ProductID })
                .ForeignKey("dbo.Providers", t => t.Provider_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductID, cascadeDelete: true)
                .Index(t => t.Provider_Id)
                .Index(t => t.Product_ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProviderProducts", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.ProviderProducts", "Provider_Id", "dbo.Providers");
            DropForeignKey("dbo.Products", "categories_categoryId", "dbo.Categories");
            DropIndex("dbo.ProviderProducts", new[] { "Product_ProductID" });
            DropIndex("dbo.ProviderProducts", new[] { "Provider_Id" });
            DropIndex("dbo.Products", new[] { "categories_categoryId" });
            DropTable("dbo.ProviderProducts");
            DropTable("dbo.Providers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
