using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public long CountTipodocentidad()
        {
            return TipodocentidadDao.Count();
        }

        public long CountTipodocentidad(Expression<Func<Tipodocentidad, bool>> criteria)
        {
            return TipodocentidadDao.Count(criteria);
        }

        public int SaveTipodocentidad(Tipodocentidad entity)
        {
            return TipodocentidadDao.Save(entity);
        }

        public void UpdateTipodocentidad(Tipodocentidad entity)
        {
            TipodocentidadDao.Update(entity);
        }

        public void DeleteTipodocentidad(int id)
        {
            TipodocentidadDao.Delete(id);
        }

        public List<Tipodocentidad> GetAllTipodocentidad()
        {
            return TipodocentidadDao.GetAll();
        }

        public List<Tipodocentidad> GetAllTipodocentidad(Expression<Func<Tipodocentidad, bool>> criteria)
        {
            return TipodocentidadDao.GetAll(criteria);
        }

        public List<Tipodocentidad> GetAllTipodocentidad(string orders)
        {
            return TipodocentidadDao.GetAll(orders);
        }

        public List<Tipodocentidad> GetAllTipodocentidad(string conditions, string orders)
        {
            return TipodocentidadDao.GetAll(conditions, orders);
        }

        public Tipodocentidad GetTipodocentidad(int id)
        {
            return TipodocentidadDao.Get(id);
        }

        public Tipodocentidad GetTipodocentidad(Expression<Func<Tipodocentidad, bool>> criteria)
        {
            return TipodocentidadDao.Get(criteria);
        }
    }
}
