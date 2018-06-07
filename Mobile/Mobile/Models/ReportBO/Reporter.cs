using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models.ReportBO
{
    public class Reporter
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public int Province { get; set; }
        public int District { get; set; }
        public int Commune { get; set; }
    }
}
