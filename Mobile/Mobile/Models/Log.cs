using System;

namespace Mobile.Models
{
    public class Log
    {
        public int LogId { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public DateTime CreatedTime { get; set; }
        public int TypeId { get; set; }
        public  User User { get; set; }
    }
}
