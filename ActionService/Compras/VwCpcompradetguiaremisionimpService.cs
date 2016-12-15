using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwCpcompradetguiaremisionimp()
		{
			return VwCpcompradetguiaremisionimpDao.Count();
		}

		public long CountVwCpcompradetguiaremisionimp(Expression<Func<VwCpcompradetguiaremisionimp, bool>> criteria)
		{
			return VwCpcompradetguiaremisionimpDao.Count(criteria);
		}

		public List<VwCpcompradetguiaremisionimp> GetAllVwCpcompradetguiaremisionimp()
		{
			return VwCpcompradetguiaremisionimpDao.GetAll();
		}

		public List<VwCpcompradetguiaremisionimp> GetAllVwCpcompradetguiaremisionimp(Expression<Func<VwCpcompradetguiaremisionimp, bool>> criteria)
		{
			return VwCpcompradetguiaremisionimpDao.GetAll(criteria);
		}

		public List<VwCpcompradetguiaremisionimp> GetAllVwCpcompradetguiaremisionimp(string orders)
		{
			return VwCpcompradetguiaremisionimpDao.GetAll(orders);
		}

		public List<VwCpcompradetguiaremisionimp> GetAllVwCpcompradetguiaremisionimp(string conditions, string orders)
		{
			return VwCpcompradetguiaremisionimpDao.GetAll(conditions, orders);
		}

		public VwCpcompradetguiaremisionimp GetVwCpcompradetguiaremisionimp(int id)
		{
			return VwCpcompradetguiaremisionimpDao.Get(id);
		}

		public VwCpcompradetguiaremisionimp GetVwCpcompradetguiaremisionimp(Expression<Func<VwCpcompradetguiaremisionimp, bool>> criteria)
		{
			return VwCpcompradetguiaremisionimpDao.Get(criteria);
		}
	}
}
