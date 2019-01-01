namespace Muebleria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticulos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articulos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Descripcion = c.String(),
                        stock = c.Int(nullable: false),
                        Imagen = c.Binary(),
                        CategoriaId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articulos", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Articulos", new[] { "CategoriaId" });
            DropTable("dbo.Articulos");
        }
    }
}
