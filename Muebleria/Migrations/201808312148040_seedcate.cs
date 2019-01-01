namespace Muebleria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedcate : DbMigration
    {
        public override void Up()
        {


            Sql(@"INSERT INTO [dbo].[Categorias] ([Id], [Descripcion]) VALUES (1, N'Muebles')
INSERT INTO [dbo].[Categorias] ([Id], [Descripcion]) VALUES (2, N'Electrodomesticos')
");
        }

        public override void Down()
        {
        }
    }
}
