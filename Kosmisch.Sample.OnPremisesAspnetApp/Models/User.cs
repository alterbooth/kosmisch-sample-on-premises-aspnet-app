using System;

namespace Kosmisch.Sample.OnPremisesAspnetApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string ProfileImageName { get; set; }
    }
}