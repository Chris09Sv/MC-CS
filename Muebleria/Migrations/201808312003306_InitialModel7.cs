namespace Muebleria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Productos", "Titulo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productos", "Titulo", c => c.String());
        }
    }
}
