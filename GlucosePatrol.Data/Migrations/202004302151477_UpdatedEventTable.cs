namespace GlucosePatrol.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEventTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "PatientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Event", "PatientId");
            AddForeignKey("dbo.Event", "PatientId", "dbo.Patient", "PatientId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "PatientId", "dbo.Patient");
            DropIndex("dbo.Event", new[] { "PatientId" });
            DropColumn("dbo.Event", "PatientId");
        }
    }
}
