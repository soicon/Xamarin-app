using System;

namespace Mobile.SQLiteModel
{
    public class EventLite
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
