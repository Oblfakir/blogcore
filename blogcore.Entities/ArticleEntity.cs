using blogcore.Entities.Extensions;
using MySql.Data.MySqlClient;

namespace blogcore.Entities
{
    public class ArticleEntity
    {
        public ArticleEntity()
        {

        }

        public ArticleEntity(MySqlDataReader reader)
        {
            Id = (int) reader["Id"];
            UserId = (int) reader["UserId"];
            ImagePath = reader.HasColumn("ImagePath") ? reader["ImagePath"].ToString() : null;
            Text = reader.HasColumn("Text") ? reader["Text"].ToString() : null;
        }

        public void SetCommandParameters(MySqlCommand command)
        {
            command.Parameters.AddWithValue("@articleText", Text);
            command.Parameters.AddWithValue("@articleUserId", UserId);
            command.Parameters.AddWithValue("@articleImagePath", ImagePath);
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public string Text { get; set; }
    }
}
