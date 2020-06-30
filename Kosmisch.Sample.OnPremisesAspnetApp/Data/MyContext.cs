using System.Data.Entity;

namespace Kosmisch.Sample.OnPremisesAspnetApp.Data
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=MyContext")
        {
        }

        public System.Data.Entity.DbSet<Kosmisch.Sample.OnPremisesAspnetApp.Models.User> Users { get; set; }
    }
}
