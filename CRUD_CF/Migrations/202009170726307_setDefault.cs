namespace CRUD_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setDefault : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Countries", "setDefault", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Countries", "setDefault");
        }
    }
}
