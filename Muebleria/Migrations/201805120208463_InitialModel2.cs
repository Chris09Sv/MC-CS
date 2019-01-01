namespace Muebleria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CLientes", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.CLientes", "Direccion", c => c.String(maxLength: 255));
            AlterColumn("dbo.CLientes", "Pregunta", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CLientes", "Pregunta", c => c.Byte(nullable: false));
            AlterColumn("dbo.CLientes", "Direccion", c => c.Byte(nullable: false));
            AlterColumn("dbo.CLientes", "Name", c => c.String());
        }
    }
}
