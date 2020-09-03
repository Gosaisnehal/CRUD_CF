namespace CRUD_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryListSP : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Contact_Insert",
                p => new
                    {
                        firstName = p.String(),
                        lastName = p.String(),
                        e_mail = p.String(),
                        phoneNo = p.String(),
                        unitNo = p.Int(),
                        streetNo = p.Int(),
                        streetName = p.String(),
                        suburb = p.String(),
                        state = p.String(),
                        company = p.String(),
                        countryId = p.Int(),
                        isActionSelected = p.Boolean(),
                    },
                body:
                    @"INSERT [dbo].[Contacts]([firstName], [lastName], [e_mail], [phoneNo], [unitNo], [streetNo], [streetName], [suburb], [state], [company], [countryId], [isActionSelected])
                      VALUES (@firstName, @lastName, @e_mail, @phoneNo, @unitNo, @streetNo, @streetName, @suburb, @state, @company, @countryId, @isActionSelected)
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [dbo].[Contacts]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [dbo].[Contacts] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            );

            CreateStoredProcedure(
                "dbo.CountryList",
                p => new
                {
                    countryID = p.Int()
                }, 
                body: 
                    @"SELECT Countries.countryName
                    from Contacts
                    LEFT OUTER JOIN Countries
                    on Contacts.countryId = Countries.countryId"


                );
            CreateStoredProcedure(
                "dbo.Contact_Update",
                p => new
                    {
                        ID = p.Int(),
                        firstName = p.String(),
                        lastName = p.String(),
                        e_mail = p.String(),
                        phoneNo = p.String(),
                        unitNo = p.Int(),
                        streetNo = p.Int(),
                        streetName = p.String(),
                        suburb = p.String(),
                        state = p.String(),
                        company = p.String(),
                        countryId = p.Int(),
                        isActionSelected = p.Boolean(),
                    },
                body:
                    @"UPDATE [dbo].[Contacts]
                      SET [firstName] = @firstName, [lastName] = @lastName, [e_mail] = @e_mail, [phoneNo] = @phoneNo, [unitNo] = @unitNo, [streetNo] = @streetNo, [streetName] = @streetName, [suburb] = @suburb, [state] = @state, [company] = @company, [countryId] = @countryId, [isActionSelected] = @isActionSelected
                      WHERE ([ID] = @ID)"
            );
            
            CreateStoredProcedure(
                "dbo.Contact_Delete",
                p => new
                    {
                        ID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Contacts]
                      WHERE ([ID] = @ID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Contact_Delete");
            DropStoredProcedure("dbo.CountryList");
            DropStoredProcedure("dbo.Contact_Update");
            DropStoredProcedure("dbo.Contact_Insert");
        }
    }
}
