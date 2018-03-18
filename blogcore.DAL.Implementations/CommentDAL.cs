using System.Collections.Generic;
using blogcore.DAL.Interfaces;
using blogcore.Entities;

namespace blogcore.DAL.Implementations
{
    public class CommentDAL: ICommentDAL
    {
        public CommentEntity GetCommentById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<CommentEntity> GetCommentsByArticleId(int articleId)
        {
            throw new System.NotImplementedException();
        }

        public List<CommentEntity> GetCommentsByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public int AddComment(CommentEntity comment)
        {
            throw new System.NotImplementedException();
        }

        public bool ChangeComment(int id, CommentEntity comment)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteComment(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
