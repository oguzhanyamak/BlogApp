using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Common;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetBlogWith(string table, int Id = 0)
        {
            using(var c = new Context()){

                switch (table)
                {
                    case "Author" when (Id == 0):
                        return c.Blogs.Include(s => s.Author).ToList();
                    case "Author" when (Id != 0):
                        return c.Blogs.Include(s => s.Author).Where(x => x.Id == Id).ToList();
                    case "Category" when (Id == 0):
                        return c.Blogs.Include(s => s.Category).ToList();
                    case "Category" when (Id != 0):
                        return c.Blogs.Include(s => s.Category).Where(x => x.Id == Id).ToList();
                    case "Comment" when (Id != 0):
                        return c.Blogs.Include(s => s.Comments).Where(x => x.Id == Id).ToList();
                    case "Comment" when (Id == 0):
                        return c.Blogs.Include(s => s.Comments).ToList();
                }
            }
            return new() { };
        }
    }
}


