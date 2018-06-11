namespace AgenciaViajesSpainIsDiferent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClaveForaneaUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coches", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Coches", "UserId");
            AddForeignKey("dbo.Coches", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coches", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Coches", new[] { "UserId" });
            DropColumn("dbo.Coches", "UserId");
        }
    }
}
