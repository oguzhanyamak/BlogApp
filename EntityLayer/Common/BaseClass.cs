using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Common
{
    public class BaseClass
    {
        public int Id { get; set; }
        virtual public bool Status { get; set; }
    }
}
