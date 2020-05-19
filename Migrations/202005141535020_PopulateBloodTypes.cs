namespace IBlood002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBloodTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BloodTypes (BloodTypeName, Rh) VALUES ('A', 0), ('A', 1), ('B', 0), ('B', 1), ('AB', 0), ('AB', 1), ('O', 0), ('O', 1)");
        }
        
        public override void Down()
        {
        }
    }
}
