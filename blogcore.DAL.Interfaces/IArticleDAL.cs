﻿using System.Collections.Generic;
using blogcore.Entities;

namespace blogcore.DAL.Interfaces
{
    public interface IArticleDAL
    {
        ArticleEntity GetArticleById(int id);
        IEnumerable<ArticleEntity> GetAllArticles();
        IEnumerable<ArticleEntity> GetArticlesByUserId(int userId);
        int AddArticle(ArticleEntity article);
        bool ChangeArticle(int id, ArticleEntity article);
        bool DeleteArticle(int id);
    }
}
