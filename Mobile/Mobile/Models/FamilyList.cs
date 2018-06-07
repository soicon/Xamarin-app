using System.Collections.Generic;

namespace Mobile.Models
{
    public class FamilyList : List<Models.Family>
    {
        public string Heading { get; set; }
        public List<Models.Family> Users => this;
    }
}
