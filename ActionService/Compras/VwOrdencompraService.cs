using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public long CountVwOrdencompra()
        {
            return VwOrdencompraDao.Count();
        }

        public long CountVwOrdencompra(Expression<Func<VwOrdencompra, bool>> criteria)
        {
            return VwOrdencompraDao.Count(criteria);
        }

        public List<VwOrdencompra> GetAllVwOrdencompra()
        {
            return VwOrdencompraDao.GetAll();
        }

        public List<VwOrdencompra> GetAllVwOrdencompra(Expression<Func<VwOrdencompra, bool>> criteria)
        {
            return VwOrdencompraDao.GetAll(criteria);
        }

        public List<VwOrdencompra> GetAllVwOrdencompra(string orders)
        {
            return VwOrdencompraDao.GetAll(orders);
        }

        public List<VwOrdencompra> GetAllVwOrdencompra(string conditions, string orders)
        {
            return VwOrdencompraDao.GetAll(conditions, orders);
        }

        public VwOrdencompra GetVwOrdencompra(int id)
        {
            return VwOrdencompraDao.Get(id);
        }

        public VwOrdencompra GetVwOrdencompra(Expression<Func<VwOrdencompra, bool>> criteria)
        {
            return VwOrdencompraDao.Get(criteria);
        }
    }
}
