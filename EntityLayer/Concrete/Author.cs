using EntityLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Author : BaseClass
    {
        public string AuthorName { get; set; }
        public string AuthorAbout { get; set; }
        public string AuthorMail { get; set; }
        public string AuthorPassword { get; set; }
        [NotMapped]
        public string AuthorRePassword { get; set; }
        public string AuthorImage { get; set; }
        public ICollection<Blog>? Blogs { get; set; }
    }
}
