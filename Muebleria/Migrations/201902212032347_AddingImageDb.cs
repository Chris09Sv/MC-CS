namespace Muebleria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingImageDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Img = c.Byte(nullable: false),
                        Descripcion = c.String(),
                        ArtId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Articulos", t => t.ArtId_Id)
                .Index(t => t.ArtId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Media", "ArtId_Id", "dbo.Articulos");
            DropIndex("dbo.Media", new[] { "ArtId_Id" });
            DropTable("dbo.Media");
        }
    }
}
