namespace CRUD_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pkfk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactCountries", "Contact_ID", "dbo.Contacts");
            DropForeignKey("dbo.ContactCountries", "Country_countryId", "dbo.Countries");
            DropIndex("dbo.ContactCountries", new[] { "Contact_ID" });
            DropIndex("dbo.ContactCountries", new[] { "Country_countryId" });
            DropTable("dbo.ContactCountries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ContactCountries",
                c => new
                    {
                        Contact_ID = c.Int(nullable: false),
                        Country_countryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Contact_ID, t.Country_countryId });
            
            CreateIndex("dbo.ContactCountries", "Country_countryId");
            CreateIndex("dbo.ContactCountries", "Contact_ID");
            AddForeignKey("dbo.ContactCountries", "Country_countryId", "dbo.Countries", "countryId", cascadeDelete: true);
            AddForeignKey("dbo.ContactCountries", "Contact_ID", "dbo.Contacts", "ID", cascadeDelete: true);
        }
    }
}
