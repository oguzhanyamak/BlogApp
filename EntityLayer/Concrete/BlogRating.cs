using EntityLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogRating : BaseClass
    {
        public int BlogId { get; set; }
        public int BlogTotalScore { get; set; }
        public int BlogRatingCount { get; set; }

        [NotMapped]
        public bool Status { get; set; }
    }
}
