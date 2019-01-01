namespace Muebleria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Productos", "CatID", c => c.Byte(nullable: false));
            DropColumn("dbo.Productos", "Categoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productos", "Categoria", c => c.String());
            DropColumn("dbo.Productos", "CatID");
            DropTable("dbo.Categorias");
        }
    }
}
