namespace GlucosePatrol.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parsingEnums : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Patient", "WeightInPounds", c => c.Single(nullable: false));
            AddColumn("dbo.Patient", "HeightInInches", c => c.Int(nullable: false));
            AddColumn("dbo.Patient", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patient", "Gender");
            DropColumn("dbo.Patient", "HeightInInches");
            DropColumn("dbo.Patient", "WeightInPounds");
            DropColumn("dbo.Patient", "DateOfBirth");
        }
    }
}
