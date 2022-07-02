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
    public class AuthorManager : IAuthorService
    {
        IAuthorDal authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            this.authorDal = authorDal;
        }

        public void AuthorAdd(Author author)
        {
            authorDal.Insert(author);
        }

        public void AuthorUpdate(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
