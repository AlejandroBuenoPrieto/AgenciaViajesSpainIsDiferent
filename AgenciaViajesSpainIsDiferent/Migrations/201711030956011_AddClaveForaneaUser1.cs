namespace AgenciaViajesSpainIsDiferent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClaveForaneaUser1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vueloes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Vueloes", "UserId");
            AddForeignKey("dbo.Vueloes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vueloes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Vueloes", new[] { "UserId" });
            DropColumn("dbo.Vueloes", "UserId");
        }
    }
}
