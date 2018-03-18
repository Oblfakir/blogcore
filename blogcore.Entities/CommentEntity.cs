using MySql.Data.MySqlClient;

namespace blogcore.Entities
{
    public class CommentEntity
    {
        public CommentEntity()
        {

        }

        public CommentEntity(MySqlDataReader reader)
        {
            Id = (int)reader["Id"];
            ArticleId = (int)reader["ArticleId"];
            UserId = (int)reader["UserId"];
            Text = reader["Text"].ToString();
        }

        public void SetCommandParameters(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@commentArticleId", ArticleId);
            command.Parameters.AddWithValue("@commentUserId", UserId);
            command.Parameters.AddWithValue("@commentText", Text);
        }

        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}