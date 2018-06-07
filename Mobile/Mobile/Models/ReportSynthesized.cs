using System;
using System.Collections.Generic;

namespace Mobile.Models
{
    public class ReportSynthesized
    {
        public int ReportSynthesizedId { get; set; }
        public int Status { get; set; }
public int ReportType { get; set; }
        public string Data { get; set; }
        public DateTime CreatedTime { get; set; }
        public  User User { get; set; }
        public List<Report> Reports { get; set; }
        public  Location Location { get; set; }
        public  Event Event { get; set; }
    }
}
