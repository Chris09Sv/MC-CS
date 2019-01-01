namespace Muebleria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "Categoria", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productos", "Categoria");
        }
    }
}
