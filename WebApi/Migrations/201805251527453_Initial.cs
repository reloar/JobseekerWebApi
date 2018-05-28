namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobseekers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Name = c.String(),
                        Jobdesc_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Jobdesc_Id)
                .Index(t => t.Jobdesc_Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobseekers", "Jobdesc_Id", "dbo.Jobs");
            DropIndex("dbo.Jobseekers", new[] { "Jobdesc_Id" });
            DropTable("dbo.Jobs");
            DropTable("dbo.Jobseekers");
        }
    }
}
