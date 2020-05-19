namespace IBlood002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CenterAddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Centers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Centers", new[] { "AddressId" });
            AddColumn("dbo.Centers", "Address", c => c.String(maxLength: 2000));
            AddColumn("dbo.Centers", "Website", c => c.String(maxLength: 255));
            AddColumn("dbo.Centers", "PhoneNumber", c => c.String(maxLength: 15));
            DropColumn("dbo.Centers", "AddressId");
            DropTable("dbo.Addresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(maxLength: 255),
                        County = c.String(maxLength: 255),
                        FullAddress = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Centers", "AddressId", c => c.Int(nullable: false));
            DropColumn("dbo.Centers", "PhoneNumber");
            DropColumn("dbo.Centers", "Website");
            DropColumn("dbo.Centers", "Address");
            CreateIndex("dbo.Centers", "AddressId");
            AddForeignKey("dbo.Centers", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
