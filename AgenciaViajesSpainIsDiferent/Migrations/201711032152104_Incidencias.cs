namespace AgenciaViajesSpainIsDiferent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Incidencias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Incidencias",
                c => new
                    {
                        idIncidencia = c.Int(nullable: false, identity: true),
                        recurso = c.String(),
                        compañia = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.idIncidencia);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Incidencias");
        }
    }
}
