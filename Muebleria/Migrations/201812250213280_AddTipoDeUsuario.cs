namespace Muebleria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTipoDeUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoDeUsuarios",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        SignUpFree = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CLientes", "tipoDeUsuarios_Id", c => c.Byte());
            CreateIndex("dbo.CLientes", "tipoDeUsuarios_Id");
            AddForeignKey("dbo.CLientes", "tipoDeUsuarios_Id", "dbo.TipoDeUsuarios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CLientes", "tipoDeUsuarios_Id", "dbo.TipoDeUsuarios");
            DropIndex("dbo.CLientes", new[] { "tipoDeUsuarios_Id" });
            DropColumn("dbo.CLientes", "tipoDeUsuarios_Id");
            DropTable("dbo.TipoDeUsuarios");
        }
    }
}
