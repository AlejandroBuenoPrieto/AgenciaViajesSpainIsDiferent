namespace AgenciaViajesSpainIsDiferent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campings",
                c => new
                    {
                        idCamping = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        calle = c.String(),
                        provincia = c.String(),
                        numerocalle = c.String(),
                        codigopostal = c.Int(nullable: false),
                        descripcion = c.String(),
                        piscina = c.String(),
                        numeroplazas = c.Int(nullable: false),
                        numerobungalows = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCamping);
            
            CreateTable(
                "dbo.Casarurals",
                c => new
                    {
                        idCasa = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        calle = c.String(),
                        provincia = c.String(),
                        numerocalle = c.String(),
                        codigopostal = c.Int(nullable: false),
                        descripcion = c.String(),
                        piscina = c.String(),
                        actividades = c.String(),
                    })
                .PrimaryKey(t => t.idCasa);
            
            CreateTable(
                "dbo.Coches",
                c => new
                    {
                        idCoche = c.Int(nullable: false, identity: true),
                        seguro = c.String(),
                        sillaniños = c.String(),
                        opcionsilla = c.Int(nullable: false),
                        compañia = c.String(),
                        calle = c.String(),
                        provincia = c.String(),
                        numerocalle = c.String(),
                        codigopostal = c.Int(nullable: false),
                        numerocoches = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCoche);
            
            CreateTable(
                "dbo.Cruceroes",
                c => new
                    {
                        idCrucero = c.Int(nullable: false, identity: true),
                        tipobarco = c.String(),
                        compañia = c.String(),
                        origen = c.String(),
                        destino = c.String(),
                        numeroplazas = c.Int(nullable: false),
                        descripcion = c.String(),
                        duracion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCrucero);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        idHotel = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        calle = c.String(),
                        provincia = c.String(),
                        numerocalle = c.String(),
                        codigopostal = c.Int(nullable: false),
                        descripcion = c.String(),
                        parking = c.String(),
                        numeroestrellas = c.Int(nullable: false),
                        numerohabitaciones = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idHotel);
            
            CreateTable(
                "dbo.Vueloes",
                c => new
                    {
                        idVuelo = c.Int(nullable: false, identity: true),
                        lowcost = c.String(),
                        compañia = c.String(),
                        origen = c.String(),
                        destino = c.String(),
                        numeroplazas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idVuelo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vueloes");
            DropTable("dbo.Hotels");
            DropTable("dbo.Cruceroes");
            DropTable("dbo.Coches");
            DropTable("dbo.Casarurals");
            DropTable("dbo.Campings");
        }
    }
}
