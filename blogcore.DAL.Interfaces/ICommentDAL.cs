using System.Collections.Generic;
using blogcore.Entities;

namespace blogcore.DAL.Interfaces
{
    public interface ICommentDAL
    {
        CommentEntity GetCommentById(int id);
        IEnumerable<CommentEntity> GetCommentsByArticleId(int articleId);
        IEnumerable<CommentEntity> GetCommentsByUserId(int userId);
        int AddComment(CommentEntity comment);
        bool ChangeComment(int id, CommentEntity comment);
        bool DeleteComment(int id);
    }
}
