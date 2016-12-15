using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwTipolistatipocondicion()
		{
			return VwTipolistatipocondicionDao.Count();
		}

		public long CountVwTipolistatipocondicion(Expression<Func<VwTipolistatipocondicion, bool>> criteria)
		{
			return VwTipolistatipocondicionDao.Count(criteria);
		}

		public List<VwTipolistatipocondicion> GetAllVwTipolistatipocondicion()
		{
			return VwTipolistatipocondicionDao.GetAll();
		}

		public List<VwTipolistatipocondicion> GetAllVwTipolistatipocondicion(Expression<Func<VwTipolistatipocondicion, bool>> criteria)
		{
			return VwTipolistatipocondicionDao.GetAll(criteria);
		}

		public List<VwTipolistatipocondicion> GetAllVwTipolistatipocondicion(string orders)
		{
			return VwTipolistatipocondicionDao.GetAll(orders);
		}

		public List<VwTipolistatipocondicion> GetAllVwTipolistatipocondicion(string conditions, string orders)
		{
			return VwTipolistatipocondicionDao.GetAll(conditions, orders);
		}

		public VwTipolistatipocondicion GetVwTipolistatipocondicion(int id)
		{
			return VwTipolistatipocondicionDao.Get(id);
		}

		public VwTipolistatipocondicion GetVwTipolistatipocondicion(Expression<Func<VwTipolistatipocondicion, bool>> criteria)
		{
			return VwTipolistatipocondicionDao.Get(criteria);
		}
	}
}
