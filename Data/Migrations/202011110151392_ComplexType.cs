namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "labadresse_StreetAddress", c => c.String());
            AddColumn("dbo.Products", "labadresse_City", c => c.String());
            DropColumn("dbo.Products", "City");
            DropColumn("dbo.Products", "StreetAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "StreetAddress", c => c.String());
            AddColumn("dbo.Products", "City", c => c.String());
            DropColumn("dbo.Products", "labadresse_City");
            DropColumn("dbo.Products", "labadresse_StreetAddress");
        }
    }
}
