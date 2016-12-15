using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
        public long CountVwTipocp()
        {
            return VwTipocpDao.Count();
        }
		public List<VwTipocp> GetAllVwTipocp()
		{
			return VwTipocpDao.GetAll();
		}

		public List<VwTipocp> GetAllVwTipocp(Expression<Func<VwTipocp, bool>> criteria)
		{
			return VwTipocpDao.GetAll(criteria);
		}

		public List<VwTipocp> GetAllVwTipocp(string orders)
		{
			return VwTipocpDao.GetAll(orders);
		}

		public List<VwTipocp> GetAllVwTipocp(string conditions, string orders)
		{
			return VwTipocpDao.GetAll(conditions, orders);
		}

		public VwTipocp GetVwTipocp(int id)
		{
			return VwTipocpDao.Get(id);
		}

		public VwTipocp GetVwTipocp(Expression<Func<VwTipocp, bool>> criteria)
		{
			return VwTipocpDao.Get(criteria);
		}
	}
}
