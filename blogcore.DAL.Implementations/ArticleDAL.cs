using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using blogcore.DAL.Interfaces;
using blogcore.Entities;

namespace blogcore.DAL.Implementations
{
    public class ArticleDAL: IArticleDAL
    {
        public ArticleEntity GetArticleById(int id)
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetArticleById"
                };

                command.Parameters.AddWithValue("@articleId", id);

                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new ArticleEntity(reader);
                }

                return null;
            }
        }

        public IEnumerable<ArticleEntity> GetAllArticles()
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetAllArticles"
                };

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new ArticleEntity(reader);
                }
            }
        }

        public IEnumerable<ArticleEntity> GetArticlesByUserId(int userId)
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "GetArticlesByUserId"
                };

                command.Parameters.AddWithValue("@articleId", userId);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new ArticleEntity(reader);
                }
            }
        }

        public int AddArticle(ArticleEntity article)
        {
            using (var connection = new MySqlConnection(AppConfig.ConnectionString))
            {
                var command = new MySqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "AddArticle"
                };

                article.SetCommandParameters(command);

                connection.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return (int) reader["id"];
                }

                return -1;
            }
        }

        public bool ChangeArticle(int id, ArticleEntity article)
        {
            throw new NotImplementedException();
        }

        public bool DeleteArticle(int id)
        {
            throw new NotImplementedException();
        }
    }
}
