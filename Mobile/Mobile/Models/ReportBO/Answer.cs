namespace Mobile.Models.ReportBO
{
    public class Answer
    {
        public string Title { get; set; }
        public string Note { get; set; }
        public bool IsCheckbox { get; set; }
        public Answer(string Title, string Note, bool IsCheckbox)
        {
            this.Title = Title;
            if (IsCheckbox)
            {
                this.Note = string.IsNullOrEmpty(Note) ? "0" : Note;
            }
            else
            {
                this.Note = Note;
            }
            this.IsCheckbox = IsCheckbox;
        }
    }
}
