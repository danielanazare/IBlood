namespace IBlood002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedToNewsletterToDonor1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donors", "Weight", c => c.Double(nullable: false));
            AddColumn("dbo.Donors", "Height", c => c.Double(nullable: false));
            AddColumn("dbo.Donors", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Donors", "IsSubscribedToNewsletter");
            DropColumn("dbo.Donors", "Height");
            DropColumn("dbo.Donors", "Weight");
        }
    }
}
