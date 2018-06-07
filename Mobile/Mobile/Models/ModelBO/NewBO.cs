namespace Mobile.Models.ModelBO
{
    public class NewBO : News
    {
        public string OriginalContent { get; set; }
        public string Time { get; set; }
        public News ToModel()
        {
            News news = new News();
            news.Content = Content;
            news.CreatedTime = CreatedTime;
            news.Medias = Medias;
            news.NewsId = NewsId;
            news.Status = Status;
            news.Title = Title;
            news.User = User;
            return news;
        }
    }
}
