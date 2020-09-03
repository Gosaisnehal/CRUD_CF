namespace CRUD_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        e_mail = c.String(),
                        phoneNo = c.String(),
                        unitNo = c.Int(),
                        streetNo = c.Int(),
                        streetName = c.String(),
                        suburb = c.String(),
                        state = c.String(),
                        company = c.String(),
                        countryId = c.Int(),
                        isActionSelected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        countryId = c.Int(nullable: false, identity: true),
                        countryName = c.String(),
                    })
                .PrimaryKey(t => t.countryId);
            
            CreateTable(
                "dbo.CountryContacts",
                c => new
                    {
                        Country_countryId = c.Int(nullable: false),
                        Contact_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country_countryId, t.Contact_ID })
                .ForeignKey("dbo.Countries", t => t.Country_countryId, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.Contact_ID, cascadeDelete: true)
                .Index(t => t.Country_countryId)
                .Index(t => t.Contact_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CountryContacts", "Contact_ID", "dbo.Contacts");
            DropForeignKey("dbo.CountryContacts", "Country_countryId", "dbo.Countries");
            DropIndex("dbo.CountryContacts", new[] { "Contact_ID" });
            DropIndex("dbo.CountryContacts", new[] { "Country_countryId" });
            DropTable("dbo.CountryContacts");
            DropTable("dbo.Countries");
            DropTable("dbo.Contacts");
        }
    }
}
