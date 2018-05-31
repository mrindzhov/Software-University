namespace StoreDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSetAge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Age", c => c.Int(defaultValue:20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Age");
        }
    }
}
