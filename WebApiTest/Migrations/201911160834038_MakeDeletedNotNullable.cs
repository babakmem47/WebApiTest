namespace WebApiTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDeletedNotNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kalas", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kalas", "Deleted", c => c.Boolean());
        }
    }
}
