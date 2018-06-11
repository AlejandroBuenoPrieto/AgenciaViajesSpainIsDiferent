namespace AgenciaViajesSpainIsDiferent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateExcursiones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Excursiones",
                c => new
                    {
                        ExcursionId = c.Int(nullable: false, identity: true),
                        nombreExcursion = c.String(),
                        ciudad = c.String(),
                        tipo = c.String(),
                    })
                .PrimaryKey(t => t.ExcursionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Excursiones");
        }
    }
}
