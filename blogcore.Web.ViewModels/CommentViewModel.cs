namespace blogcore.Web.ViewModels
{
    public class CommentViewModel
    {
        public int? Id { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}
