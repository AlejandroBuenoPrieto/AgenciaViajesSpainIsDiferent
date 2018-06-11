namespace AgenciaViajesSpainIsDiferent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClaveForaneaUser4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campings", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Campings", "UserId");
            AddForeignKey("dbo.Campings", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Campings", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Campings", new[] { "UserId" });
            DropColumn("dbo.Campings", "UserId");
        }
    }
}
