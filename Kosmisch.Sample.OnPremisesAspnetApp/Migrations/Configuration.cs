namespace Kosmisch.Sample.OnPremisesAspnetApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Kosmisch.Sample.OnPremisesAspnetApp.Data.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Kosmisch.Sample.OnPremisesAspnetApp.Data.MyContext context)
        {
        }
    }
}
