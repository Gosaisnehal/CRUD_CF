namespace CRUD_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validations : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CountryContacts", newName: "ContactCountries");
            DropPrimaryKey("dbo.ContactCountries");
            AlterColumn("dbo.Contacts", "firstName", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "lastName", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "e_mail", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "phoneNo", c => c.String(nullable: false));
            AddPrimaryKey("dbo.ContactCountries", new[] { "Contact_ID", "Country_countryId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ContactCountries");
            AlterColumn("dbo.Contacts", "phoneNo", c => c.String());
            AlterColumn("dbo.Contacts", "e_mail", c => c.String());
            AlterColumn("dbo.Contacts", "lastName", c => c.String());
            AlterColumn("dbo.Contacts", "firstName", c => c.String());
            AddPrimaryKey("dbo.ContactCountries", new[] { "Country_countryId", "Contact_ID" });
            RenameTable(name: "dbo.ContactCountries", newName: "CountryContacts");
        }
    }
}
