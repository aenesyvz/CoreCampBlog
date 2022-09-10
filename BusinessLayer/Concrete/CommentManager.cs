using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public void Add(Comment entity)
        {
            _commentDal.Add(entity);
        }

        public void Delete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll();
        }

        public Comment GetById(int id)
        {
            return _commentDal.GetById(c=>c.CommentId == id);
        }

        public List<Comment> GetListByBlogId(int id)
        {
            return _commentDal.GetAll(c => c.BlogId == id);
        }

        public void Update(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}
