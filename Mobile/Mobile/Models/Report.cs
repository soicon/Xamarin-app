using System;

namespace Mobile.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public int Status { get; set; }
        public int ReportType { get; set; }
        public string Data { get; set; }
        public DateTime CreatedTime { get; set; }
        public User User { get; set; }
        public ReportSynthesized ReportSynthesized { get; set; }
        public Location Location { get; set; }
        public Event Event { get; set; }

    }
}
