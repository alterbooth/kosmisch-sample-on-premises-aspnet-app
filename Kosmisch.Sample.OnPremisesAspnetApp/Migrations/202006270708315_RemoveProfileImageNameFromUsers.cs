namespace Kosmisch.Sample.OnPremisesAspnetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProfileImageNameFromUsers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "ProfileImageName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ProfileImageName", c => c.String());
        }
    }
}
