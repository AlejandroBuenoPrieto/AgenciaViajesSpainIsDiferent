namespace AgenciaViajesSpainIsDiferent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClaveForaneaUser6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cruceroes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cruceroes", "UserId");
            AddForeignKey("dbo.Cruceroes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cruceroes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Cruceroes", new[] { "UserId" });
            DropColumn("dbo.Cruceroes", "UserId");
        }
    }
}
