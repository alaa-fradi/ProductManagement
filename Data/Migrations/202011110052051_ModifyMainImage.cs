﻿namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyMainImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageName", c => c.String());
            DropColumn("dbo.Products", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Image", c => c.String());
            DropColumn("dbo.Products", "ImageName");
        }
    }
}
