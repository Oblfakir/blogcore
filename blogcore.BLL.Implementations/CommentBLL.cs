using System.Collections.Generic;
using blogcore.DAL.Interfaces;
using blogcore.Entities;

namespace blogcore.BLL.Implementations
{
    public class CommentBLL: ICommentBLL
    {
        private readonly ICommentDAL _commentDal;

        public CommentBLL(ICommentDAL commentDal)
        {
            _commentDal = commentDal;
        }

        public CommentEntity GetCommentById(int id)
        {
            return _commentDal.GetCommentById(id);
        }

        public List<CommentEntity> GetCommentsByArticleId(int articleId)
        {
            return _commentDal.GetCommentsByArticleId(articleId);
        }

        public List<CommentEntity> GetCommentsByUserId(int userId)
        {
            return _commentDal.GetCommentsByUserId(userId);
        }

        public int AddComment(CommentEntity comment)
        {
            return _commentDal.AddComment(comment);
        }

        public bool ChangeComment(int id, CommentEntity comment)
        {
            return _commentDal.ChangeComment(id, comment);
        }

        public bool DeleteComment(int id)
        {
            return _commentDal.DeleteComment(id);
        }
    }
}
