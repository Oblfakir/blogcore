namespace blogcore.Web.ViewModels
{
    public class ArticleViewModel
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public string Text { get; set; }
    }
}
