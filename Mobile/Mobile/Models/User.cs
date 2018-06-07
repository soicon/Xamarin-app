using System;
using System.Collections.Generic;

namespace Mobile.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string BloodType { get; set; }
        public string DesktopPhone { get; set; }
        public string CellPhone { get; set; }
        public string Gender { get; set; }
        public string ObjectId { get; set; }
        public string SecretCode { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public DateTime? GPSCreateTime { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public DateTime? CreatedTime { get; set; }
        public  Location Location { get; set; }
        public List<Log> Logs { get; set; }
        public List<Report> Reports { get; set; }
        public List<ReportSynthesized> ReportSynthesized { get; set; }
        public List<Event> Events { get; set; }
        public List<News> News { get; set; }
        public List<Alert> Alerts { get; set; }
        public List<Family> Families { get; set; }


    }
}
