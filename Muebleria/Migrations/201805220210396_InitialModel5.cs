namespace Muebleria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "Titulo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productos", "Titulo");
        }
    }
}
