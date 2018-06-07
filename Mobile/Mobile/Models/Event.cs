using System;
using System.Collections.Generic;

namespace Mobile.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime CreatedTime { get; set; }
        public User User { get; set; }
        public List<Report> Reports { get; set; }
        public List<Alert> Alerts { get; set; }

    }
}
