using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public long CountVwOrdencompradet()
        {
            return VwOrdencompradetDao.Count();
        }

        public long CountVwOrdencompradet(Expression<Func<VwOrdencompradet, bool>> criteria)
        {
            return VwOrdencompradetDao.Count(criteria);
        }

        public List<VwOrdencompradet> GetAllVwOrdencompradet()
        {
            return VwOrdencompradetDao.GetAll();
        }

        public List<VwOrdencompradet> GetAllVwOrdencompradet(Expression<Func<VwOrdencompradet, bool>> criteria)
        {
            return VwOrdencompradetDao.GetAll(criteria);
        }

        public List<VwOrdencompradet> GetAllVwOrdencompradet(string orders)
        {
            return VwOrdencompradetDao.GetAll(orders);
        }

        public List<VwOrdencompradet> GetAllVwOrdencompradet(string conditions, string orders)
        {
            return VwOrdencompradetDao.GetAll(conditions, orders);
        }

        public VwOrdencompradet GetVwOrdencompradet(int id)
        {
            return VwOrdencompradetDao.Get(id);
        }

        public VwOrdencompradet GetVwOrdencompradet(Expression<Func<VwOrdencompradet, bool>> criteria)
        {
            return VwOrdencompradetDao.Get(criteria);
        }
    }
}
