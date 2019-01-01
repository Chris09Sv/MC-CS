namespace Muebleria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriatoProducto : DbMigration
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
            
            AddColumn("dbo.Productos", "CategoriaId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Productos", "CategoriaId");
            AddForeignKey("dbo.Productos", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Productos", new[] { "CategoriaId" });
            DropColumn("dbo.Productos", "CategoriaId");
            DropTable("dbo.Categorias");
        }
    }
}
