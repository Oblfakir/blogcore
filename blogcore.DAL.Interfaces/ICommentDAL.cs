using System.Collections.Generic;
using blogcore.Entities;

namespace blogcore.DAL.Interfaces
{
    public interface ICommentDAL
    {
        CommentEntity GetCommentById(int id);
        List<CommentEntity> GetCommentsByArticleId(int articleId);
        List<CommentEntity> GetCommentsByUserId(int userId);
        int AddComment(CommentEntity comment);
        bool ChangeComment(int id, CommentEntity comment);
        bool DeleteComment(int id);
    }
}
