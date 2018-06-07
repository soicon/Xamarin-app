using System;

namespace Mobile.Models
{
    public class Media
    {
        public int MediaId { get; set; }
        public string Adress { get; set; }
        public string Type { get; set; }
        public DateTime CreatedTime { get; set; }
        public  News News { get; set; }
    }
}
