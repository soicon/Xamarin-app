using SQLite;
using System;

namespace Mobile.SQLiteModel
{
    public class UserLite
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
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
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
