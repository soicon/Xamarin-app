using System;
using System.Collections.Generic;

namespace Mobile.Models
{
    public class News
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public DateTime CreatedTime { get; set; }
        public  User User { get; set; }
        public List<Media> Medias { get; set; }
    }
}
