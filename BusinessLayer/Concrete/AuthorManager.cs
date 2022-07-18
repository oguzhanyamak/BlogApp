using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager : Manager<Author> ,IAuthorService
    {
        IAuthorDal authorDal;

        public AuthorManager(IGenericDal<Author> genericDal) : base(genericDal)
        {
            this.authorDal = (IAuthorDal)genericDal;
        }

        public int IdCheck(string email)
        {
            return authorDal.IdCheck(email);
        }
    }
}
