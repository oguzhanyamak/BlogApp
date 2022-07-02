using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentAdd(Comment comment)
        {
            _commentDal.Insert(comment); 
        }

        public List<Comment> GetCommentByBlog(int id)
        {
            List<Comment> comment = _commentDal.GetCommentByBlog(id);
            return comment;
        }



        public List<Comment> GetList(int id)
        {
            List<Comment> comments = _commentDal.GetAll().ToList();
            return comments;
        }


    }
}
