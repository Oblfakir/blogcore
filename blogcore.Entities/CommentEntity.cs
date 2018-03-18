namespace blogcore.Entities
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}