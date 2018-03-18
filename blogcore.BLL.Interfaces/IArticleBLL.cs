using System.Collections.Generic;
using blogcore.Entities;

namespace blogcore.BLL.Interfaces
{
    public interface IArticleBLL
    {
        ArticleEntity GetArticleById(int id);
        IEnumerable<ArticleEntity> GetAllArticles();
        IEnumerable<ArticleEntity> GetArticlesByUserId(int userId);
        int AddArticle(ArticleEntity article);
        bool ChangeArticle(int id, ArticleEntity article);
        bool DeleteArticle(int id);
    }
}
