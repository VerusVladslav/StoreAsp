namespace StoreAsp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sec : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAdditionalnfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAdditionalnfoes", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserAdditionalnfoes", new[] { "Id" });
            DropTable("dbo.UserAdditionalnfoes");
        }
    }
}
