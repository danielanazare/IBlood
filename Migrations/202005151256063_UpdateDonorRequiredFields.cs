namespace IBlood002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDonorRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "Email", c => c.String(maxLength: 255));
            AlterColumn("dbo.Donors", "Phone", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donors", "Phone", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Donors", "Email", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
