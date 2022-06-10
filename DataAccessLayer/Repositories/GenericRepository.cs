using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private Context _Context = new Context();
        public void Delete(T t)
        {
            _Context.Remove(t);
            _Context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _Context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return _Context.Find<T>(id);
        }

        public void insert(T t)
        {
            _Context.Add(t);
            _Context.SaveChanges();
        }

        public void Update(T t)
        {
            _Context.Update(t);
            _Context.SaveChanges();
        }
    }
}
