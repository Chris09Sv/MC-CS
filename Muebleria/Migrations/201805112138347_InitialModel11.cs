namespace Muebleria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CLientes", "imagenCliente", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CLientes", "imagenCliente");
        }
    }
}
