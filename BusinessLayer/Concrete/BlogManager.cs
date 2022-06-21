using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Common;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void BlogAdd(Blog blog)
        {
            _blogDal.insert(blog);
        }

        public void BlogDelete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public void BlogUpdate(Blog blog)
        {
            _blogDal.Update(blog);
        }

        public List<Blog> GetBlogWith(string table, int id=0)
        {
            return _blogDal.GetBlogWith(table, id);
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetByID(id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetAll();
        }
    }
}
