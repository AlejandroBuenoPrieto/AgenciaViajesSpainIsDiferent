namespace AgenciaViajesSpainIsDiferent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClaveForaneaUser2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trens", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Trens", "UserId");
            AddForeignKey("dbo.Trens", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trens", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Trens", new[] { "UserId" });
            DropColumn("dbo.Trens", "UserId");
        }
    }
}
