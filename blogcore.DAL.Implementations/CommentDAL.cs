using System.Collections.Generic;
using System.Data;
using blogcore.DAL.Interfaces;
using blogcore.Entities;
using MySql.Data.MySqlClient;

namespace blogcore.DAL.Implementations
{
    public class CommentDAL : ICommentDAL
    {
        public CommentEntity GetCommentById(int id)
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetCommentById"
                };

                command.Parameters.AddWithValue("@commentId", id);

                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new CommentEntity(reader);
                }

                return null;
            }
        }

        public IEnumerable<CommentEntity> GetCommentsByArticleId(int articleId)
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetCommentsByArticleId"
                };

                command.Parameters.AddWithValue("@commentArticleId", articleId);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new CommentEntity(reader);
                }
            }
        }

        public IEnumerable<CommentEntity> GetCommentsByUserId(int userId)
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetCommentsByUserId"
                };

                command.Parameters.AddWithValue("@commentUserId", userId);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new CommentEntity(reader);
                }
            }
        }

        public int AddComment(CommentEntity comment)
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "AddComment"
                };

                comment.SetCommandParameters(command);

                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return int.Parse(reader["id"].ToString());
                }

                return -1;
            }
        }

        public bool ChangeComment(int id, CommentEntity comment)
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "ChangeComment"
                };

                command.Parameters.AddWithValue("@commentId", id);
                comment.SetCommandParameters(command);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteComment(int id)
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DeleteComment"
                };

                command.Parameters.AddWithValue("@commentId", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
