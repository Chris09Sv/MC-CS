namespace Muebleria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCategoria : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Productos", "CatID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productos", "CatID", c => c.Byte(nullable: false));
        }
    }
}
