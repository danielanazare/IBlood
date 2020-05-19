namespace IBlood002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BloodTypeIdToByte : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Donors", "BloodTypeId", "dbo.BloodTypes");
            DropIndex("dbo.Donors", new[] { "BloodTypeId" });
            DropPrimaryKey("dbo.BloodTypes");
            AlterColumn("dbo.BloodTypes", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Donors", "BloodTypeId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.BloodTypes", "Id");
            CreateIndex("dbo.Donors", "BloodTypeId");
            AddForeignKey("dbo.Donors", "BloodTypeId", "dbo.BloodTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donors", "BloodTypeId", "dbo.BloodTypes");
            DropIndex("dbo.Donors", new[] { "BloodTypeId" });
            DropPrimaryKey("dbo.BloodTypes");
            AlterColumn("dbo.Donors", "BloodTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.BloodTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.BloodTypes", "Id");
            CreateIndex("dbo.Donors", "BloodTypeId");
            AddForeignKey("dbo.Donors", "BloodTypeId", "dbo.BloodTypes", "Id", cascadeDelete: true);
        }
    }
}
