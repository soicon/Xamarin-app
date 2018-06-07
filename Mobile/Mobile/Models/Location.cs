using System;
using System.Collections.Generic;

namespace Mobile.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ParentCode { get; set; }
        public int Type { get; set; }
        public List<User> Users { get; set; }
        public List<Family> Families { get; set; }
        public List<Report> Reports { get; set; }
        public List<ReportSynthesized> ReportSynthesized { get; set; }

    }
}
