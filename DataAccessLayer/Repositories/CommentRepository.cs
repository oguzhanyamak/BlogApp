using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CommentRepository:GenericRepository<Comment>,ICommentDal
    {
        public List<Comment> GetCommentByBlog(int id)
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x => x.Blog).Where(x=> x.Blog.Id == id).ToList();
            }
        }
    }
}
