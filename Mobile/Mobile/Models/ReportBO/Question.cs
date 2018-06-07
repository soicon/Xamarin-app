using System.Collections.Generic;

namespace Mobile.Models.ReportBO
{
    public class Question
    {
        public int QuestionNumber { get; set; }
        public string Title { get; set; }
        public List<Answer> ListAnswer { get; set; }
    }
}
