using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public long CountAccesoform()
        {
            return AccesoformDao.Count();
        }

        public long CountAccesoform(Expression<Func<Accesoform, bool>> criteria)
        {
            return AccesoformDao.Count(criteria);
        }

        public int SaveAccesoform(Accesoform entity)
        {
            return AccesoformDao.Save(entity);
        }

        public void UpdateAccesoform(Accesoform entity)
        {
            AccesoformDao.Update(entity);
        }

        public void DeleteAccesoform(int id)
        {
            AccesoformDao.Delete(id);
        }

        public List<Accesoform> GetAllAccesoform()
        {
            return AccesoformDao.GetAll();
        }

        public List<Accesoform> GetAllAccesoform(Expression<Func<Accesoform, bool>> criteria)
        {
            return AccesoformDao.GetAll(criteria);
        }

        public List<Accesoform> GetAllAccesoform(string orders)
        {
            return AccesoformDao.GetAll(orders);
        }

        public List<Accesoform> GetAllAccesoform(string conditions, string orders)
        {
            return AccesoformDao.GetAll(conditions, orders);
        }

        public Accesoform GetAccesoform(int id)
        {
            return AccesoformDao.Get(id);
        }

        public Accesoform GetAccesoform(Expression<Func<Accesoform, bool>> criteria)
        {
            return AccesoformDao.Get(criteria);
        }
    }
}
