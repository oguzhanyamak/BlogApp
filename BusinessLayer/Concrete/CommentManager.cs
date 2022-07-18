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
    public class CommentManager : Manager<Comment>,ICommentService
    {
        private ICommentDal _commentDal;

        public CommentManager(IGenericDal<Comment> genericDal) : base(genericDal)
        {
            _commentDal = (ICommentDal)genericDal;
        }
    }
}
