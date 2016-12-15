using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public List<VwPersona> GetAllVwPersona()
        {
            return VwPersonaDao.GetAll();
        }

        public List<VwPersona> GetAllVwPersona(Expression<Func<VwPersona, bool>> criteria)
        {
            return VwPersonaDao.GetAll(criteria);
        }

        public List<VwPersona> GetAllVwPersona(string orders)
        {
            return VwPersonaDao.GetAll(orders);
        }

        public List<VwPersona> GetAllVwPersona(string conditions, string orders)
        {
            return VwPersonaDao.GetAll(conditions, orders);
        }

        public VwPersona GetVwPersona(int id)
        {
            return VwPersonaDao.Get(id);
        }

        public VwPersona GetVwPersona(Expression<Func<VwPersona, bool>> criteria)
        {
            return VwPersonaDao.Get(criteria);
        }
    }
}