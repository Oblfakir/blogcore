using System.Collections.Generic;
using blogcore.BLL.Interfaces;
using blogcore.DAL.Interfaces;
using blogcore.Entities;

namespace blogcore.BLL.Implementations
{
    public class ArticleBLL: IArticleBLL
    {
        private readonly IArticleDAL _articleDal;

        public ArticleBLL(IArticleDAL articleDal)
        {
            _articleDal = articleDal;
        }

        public ArticleEntity GetArticleById(int id)
        {
            return _articleDal.GetArticleById(id);
        }

        public IEnumerable<ArticleEntity> GetAllArticles()
        {
            return _articleDal.GetAllArticles();
        }

        public IEnumerable<ArticleEntity> GetArticlesByUserId(int userId)
        {
            return _articleDal.GetArticlesByUserId(userId);
        }

        public int AddArticle(ArticleEntity article)
        {
            return _articleDal.AddArticle(article);
        }

        public bool ChangeArticle(int id, ArticleEntity article)
        {
            return _articleDal.ChangeArticle(id, article);
        }

        public bool DeleteArticle(int id)
        {
            return _articleDal.DeleteArticle(id);
        }
    }
}
