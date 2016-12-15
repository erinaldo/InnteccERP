using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public long CountDistrito()
        {
            return DistritoDao.Count();
        }

        public long CountDistrito(Expression<Func<Distrito, bool>> criteria)
        {
            return DistritoDao.Count(criteria);
        }

        public int SaveDistrito(Distrito entity)
        {
            return DistritoDao.Save(entity);
        }

        public void UpdateDistrito(Distrito entity)
        {
            DistritoDao.Update(entity);
        }

        public void DeleteDistrito(int id)
        {
            DistritoDao.Delete(id);
        }

        public List<Distrito> GetAllDistrito()
        {
            return DistritoDao.GetAll();
        }

        public List<Distrito> GetAllDistrito(Expression<Func<Distrito, bool>> criteria)
        {
            return DistritoDao.GetAll(criteria);
        }

        public List<Distrito> GetAllDistrito(string orders)
        {
            return DistritoDao.GetAll(orders);
        }

        public List<Distrito> GetAllDistrito(string conditions, string orders)
        {
            return DistritoDao.GetAll(conditions, orders);
        }

        public Distrito GetDistrito(int id)
        {
            return DistritoDao.Get(id);
        }

        public Distrito GetDistrito(Expression<Func<Distrito, bool>> criteria)
        {
            return DistritoDao.Get(criteria);
        }
    }
}
