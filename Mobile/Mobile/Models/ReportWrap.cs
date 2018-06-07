using System.Collections.Generic;

namespace Mobile.Models
{
    public class ReportWrap
    {
        public List<Report> Reports { get; set; }
        public List<Report> ReportsBeforeSynth { get; set; }
        public List<ReportSynthesized> ReportSynthesizeds { get; set; }
        public List<ReportSynthesized> ReportSynthesizedsApporved { get; set; }
        public List<ReportSynthesized> ReportSynthesizedsSynth { get; set; }
        public List<ReportSynthesized> ReportSynthesizedsSynthBefore { get; set; }
        public List<Report> ReportsSynth { get; set; }
        public List<Event> Events { get; set; }
        public User User { get; set; }
        //public List<SelectListItem> ListLocation { get; set; }
        public Report Report { get; set; }
        public ReportSynthesized ReportSynthesized { get; set; }
        public List<Location> ListProvince { get; set; }
        public List<Location> ListDistrict { get; set; }
        public List<Location> ListWard { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int WardId { get; set; }
    }
}
