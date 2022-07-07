using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Manager<T> : IService<T> where T :BaseClass
    {
        IGenericDal<T> _genericDal;

        public Manager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public void Add(T t)
        {
            _genericDal.Insert(t);
        }

        public void Delete(T t)
        {
            _genericDal.Delete(t);
        }

        public T GetById(int id)
        {
            return _genericDal.GetByID(id);
        }

        public List<T> GetList()
        {
            return _genericDal.GetAll();
        }

        public void Update(T t)
        {
            _genericDal.Update(t);
        }
    }
}
