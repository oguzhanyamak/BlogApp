using EntityLayer.Common;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IService<Blog>
    {
        List<Blog> GetBlogWith(string table,int id);
        
    }
}
