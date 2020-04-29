namespace GlucosePatrol.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEventandPatientTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        TypeOfEvent = c.Int(nullable: false),
                        SubTypeOfEvent = c.Int(),
                        Value = c.Single(),
                        Unit = c.Int(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.EventId);
            
            AddColumn("dbo.Entry", "PatientId", c => c.Int(nullable: false));
            AddColumn("dbo.Entry", "Event_EventId", c => c.Int());
            CreateIndex("dbo.Entry", "PatientId");
            CreateIndex("dbo.Entry", "Event_EventId");
            AddForeignKey("dbo.Entry", "PatientId", "dbo.Patient", "PatientId", cascadeDelete: true);
            AddForeignKey("dbo.Entry", "Event_EventId", "dbo.Event", "EventId");
            DropColumn("dbo.Entry", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entry", "OwnerId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Entry", "Event_EventId", "dbo.Event");
            DropForeignKey("dbo.Entry", "PatientId", "dbo.Patient");
            DropIndex("dbo.Entry", new[] { "Event_EventId" });
            DropIndex("dbo.Entry", new[] { "PatientId" });
            DropColumn("dbo.Entry", "Event_EventId");
            DropColumn("dbo.Entry", "PatientId");
            DropTable("dbo.Event");
            DropTable("dbo.Patient");
        }
    }
}
