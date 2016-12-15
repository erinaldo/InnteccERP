using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public List<VwUbigeo> GetAllVwUbigeo()
        {
            return VwUbigeoDao.GetAll();
        }

        public List<VwUbigeo> GetAllVwUbigeo(Expression<Func<VwUbigeo, bool>> criteria)
        {
            return VwUbigeoDao.GetAll(criteria);
        }

        public List<VwUbigeo> GetAllVwUbigeo(string orders)
        {
            return VwUbigeoDao.GetAll(orders);
        }

        public List<VwUbigeo> GetAllVwUbigeo(string conditions, string orders)
        {
            return VwUbigeoDao.GetAll(conditions, orders);
        }

        public VwUbigeo GetVwUbigeo(int id)
        {
            return VwUbigeoDao.Get(id);
        }

        public VwUbigeo GetVwUbigeo(Expression<Func<VwUbigeo, bool>> criteria)
        {
            return VwUbigeoDao.Get(criteria);
        }
    }
}