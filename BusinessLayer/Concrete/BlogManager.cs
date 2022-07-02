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

        public List<Blog> GetBlogWith(string table, int id=0)
        {
            return _blogDal.GetBlogWith(table, id);
        }

        public List<Blog> getLastBlogs(int count) 
        {
            return _blogDal.GetAll().Take(count).ToList();
        }

        public void Add(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void Update(Blog t)
        {
            _blogDal.Update(t);
        }

        public void Delete(Blog t)
        {
            _blogDal.Delete(t);   
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetAll();
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetByID(id);
        }
    }
}
