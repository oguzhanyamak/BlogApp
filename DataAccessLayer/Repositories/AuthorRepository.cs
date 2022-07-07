using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorDal
    {
        private Context _Context = new Context();
        public int IdCheck(string email)
        {
            return _Context.Authors.Where(x => x.AuthorMail == email).Select(y => y.Id).FirstOrDefault();
        }
    }
}
