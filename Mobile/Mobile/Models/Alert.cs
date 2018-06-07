using System;

namespace Mobile.Models
{
    public class Alert
    {
        public int AlertId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
        public  User User { get; set; }
        public  Event Event { get; set; }

    }
}
