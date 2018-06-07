using System.Collections.Generic;

namespace Mobile.Models
{
    public class Part
    {
        public int PartNumber { get; set; }
        public string Action { get; set; }
        public string WhoAction { get; set; }
        public List<Question> ListQuestions { get; set; }
        public Part()
        {
            ListQuestions = new List<Question>();
        }
    }
}
