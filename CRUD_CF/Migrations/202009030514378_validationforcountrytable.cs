namespace CRUD_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationforcountrytable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Countries", "countryName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Countries", "countryName", c => c.String());
        }
    }
}
