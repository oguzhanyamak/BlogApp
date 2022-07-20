using EntityLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category : BaseClass
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public ICollection<Blog> Blogs { get; set; }

    }
}
