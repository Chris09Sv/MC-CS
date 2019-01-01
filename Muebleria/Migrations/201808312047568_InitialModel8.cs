namespace Muebleria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel8 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Categorias");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
