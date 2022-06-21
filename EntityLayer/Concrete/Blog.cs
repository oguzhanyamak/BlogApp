using EntityLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog : BaseClass
    {

        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime CreateDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
