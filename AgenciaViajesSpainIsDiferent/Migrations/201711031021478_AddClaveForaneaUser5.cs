namespace AgenciaViajesSpainIsDiferent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClaveForaneaUser5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Casarurals", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Casarurals", "UserId");
            AddForeignKey("dbo.Casarurals", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Casarurals", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Casarurals", new[] { "UserId" });
            DropColumn("dbo.Casarurals", "UserId");
        }
    }
}
