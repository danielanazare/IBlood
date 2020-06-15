namespace IBlood002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthDateNotNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donors", "BirthDate", c => c.DateTime());
        }
    }
}
