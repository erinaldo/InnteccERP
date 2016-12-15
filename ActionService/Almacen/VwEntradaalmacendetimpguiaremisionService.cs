using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwEntradaalmacendetimpguiaremision()
		{
			return VwEntradaalmacendetimpguiaremisionDao.Count();
		}

		public long CountVwEntradaalmacendetimpguiaremision(Expression<Func<VwEntradaalmacendetimpguiaremision, bool>> criteria)
		{
			return VwEntradaalmacendetimpguiaremisionDao.Count(criteria);
		}

		public List<VwEntradaalmacendetimpguiaremision> GetAllVwEntradaalmacendetimpguiaremision()
		{
			return VwEntradaalmacendetimpguiaremisionDao.GetAll();
		}

		public List<VwEntradaalmacendetimpguiaremision> GetAllVwEntradaalmacendetimpguiaremision(Expression<Func<VwEntradaalmacendetimpguiaremision, bool>> criteria)
		{
			return VwEntradaalmacendetimpguiaremisionDao.GetAll(criteria);
		}

		public List<VwEntradaalmacendetimpguiaremision> GetAllVwEntradaalmacendetimpguiaremision(string orders)
		{
			return VwEntradaalmacendetimpguiaremisionDao.GetAll(orders);
		}

		public List<VwEntradaalmacendetimpguiaremision> GetAllVwEntradaalmacendetimpguiaremision(string conditions, string orders)
		{
			return VwEntradaalmacendetimpguiaremisionDao.GetAll(conditions, orders);
		}

		public VwEntradaalmacendetimpguiaremision GetVwEntradaalmacendetimpguiaremision(int id)
		{
			return VwEntradaalmacendetimpguiaremisionDao.Get(id);
		}

		public VwEntradaalmacendetimpguiaremision GetVwEntradaalmacendetimpguiaremision(Expression<Func<VwEntradaalmacendetimpguiaremision, bool>> criteria)
		{
			return VwEntradaalmacendetimpguiaremisionDao.Get(criteria);
		}
	}
}
