namespace CRUD_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cratedrelationsbetweencontactandcountry : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Contacts", "countryId");
            AddForeignKey("dbo.Contacts", "countryId", "dbo.Countries", "countryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "countryId", "dbo.Countries");
            DropIndex("dbo.Contacts", new[] { "countryId" });
        }
    }
}
