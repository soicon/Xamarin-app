using System.Collections.Generic;

namespace Mobile.Models
{
    public class UserList : List<User>
    {
        public string Heading { get; set; }
        public List<User> Users => this;
    }
}
