namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Factures",
                c => new
                    {
                        DateAchat = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ProductId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        Prix = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.DateAchat, t.ProductId, t.ClientId })
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Cin = c.Int(nullable: false, identity: true),
                        Prenom = c.String(),
                        Nom = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Cin);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factures", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Factures", "ClientId", "dbo.Clients");
            DropIndex("dbo.Factures", new[] { "ClientId" });
            DropIndex("dbo.Factures", new[] { "ProductId" });
            DropTable("dbo.Clients");
            DropTable("dbo.Factures");
        }
    }
}
