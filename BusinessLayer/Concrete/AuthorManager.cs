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

        public void Add(Author t)
        {
            authorDal.Insert(t);
        }

        public void Delete(Author t)
        {
            authorDal.Delete(t);
        }

        public Author GetById(int id)
        {
            return authorDal.GetByID(id);
        }

        public List<Author> GetList()
        {
            return authorDal.GetAll();
        }

        public void Update(Author t)
        {
            authorDal.Update(t);
        }
    }
}
