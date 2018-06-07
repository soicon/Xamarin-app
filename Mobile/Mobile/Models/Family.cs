using System;

namespace Mobile.Models
{
    public class Family
    {
        public int FamilyId { get; set; }
        public string Name { get; set; }
        public string Risk { get; set; }
        public DateTime CreatedTime { get; set; }
        public Location Location { get; set; }
        public User User { get; set; }

    }
}
