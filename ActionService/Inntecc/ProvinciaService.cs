using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public long CountProvincia()
        {
            return ProvinciaDao.Count();
        }

        public long CountProvincia(Expression<Func<Provincia, bool>> criteria)
        {
            return ProvinciaDao.Count(criteria);
        }

        public int SaveProvincia(Provincia entity)
        {
            return ProvinciaDao.Save(entity);
        }

        public void UpdateProvincia(Provincia entity)
        {
            ProvinciaDao.Update(entity);
        }

        public void DeleteProvincia(int id)
        {
            ProvinciaDao.Delete(id);
        }

        public List<Provincia> GetAllProvincia()
        {
            return ProvinciaDao.GetAll();
        }

        public List<Provincia> GetAllProvincia(Expression<Func<Provincia, bool>> criteria)
        {
            return ProvinciaDao.GetAll(criteria);
        }

        public List<Provincia> GetAllProvincia(string orders)
        {
            return ProvinciaDao.GetAll(orders);
        }

        public List<Provincia> GetAllProvincia(string conditions, string orders)
        {
            return ProvinciaDao.GetAll(conditions, orders);
        }

        public Provincia GetProvincia(int id)
        {
            return ProvinciaDao.Get(id);
        }

        public Provincia GetProvincia(Expression<Func<Provincia, bool>> criteria)
        {
            return ProvinciaDao.Get(criteria);
        }
    }
}
