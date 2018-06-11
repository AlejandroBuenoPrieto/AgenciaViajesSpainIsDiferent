namespace AgenciaViajesSpainIsDiferent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClaveForaneaUser3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hotels", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Hotels", "UserId");
            AddForeignKey("dbo.Hotels", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hotels", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Hotels", new[] { "UserId" });
            DropColumn("dbo.Hotels", "UserId");
        }
    }
}
