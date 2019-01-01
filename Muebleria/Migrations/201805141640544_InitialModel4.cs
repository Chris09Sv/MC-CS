namespace Muebleria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productos", "Imagen", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productos", "Imagen", c => c.Byte(nullable: false));
        }
    }
}
