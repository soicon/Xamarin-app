using SQLite;
using System;

namespace Mobile.SQLiteModel
{
    public class ReportLite
    {
        [PrimaryKey, AutoIncrement]
        public int ReportId { get; set; }
        public int Status { get; set; }
        public int ReportType { get; set; }
        public string Data { get; set; }
        public DateTime CreatedTime { get; set; }
        public string UserId { get; set; }
        public int LocationId { get; set; }
        public int EventId { get; set; }
    }
}
