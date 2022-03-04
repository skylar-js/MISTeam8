namespace MISTeam8.Migrations.Team8Context
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Team8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recognitions",
                c => new
                    {
                        RecognitionID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        CoreValue = c.String(),
                        DateRecongized = c.DateTime(nullable: false),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.RecognitionID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recognitions", "UserID", "dbo.Users");
            DropIndex("dbo.Recognitions", new[] { "UserID" });
            DropTable("dbo.Recognitions");
        }
    }
}
