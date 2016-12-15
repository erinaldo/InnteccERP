using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwModeloautorizacioncondicion()
		{
			return VwModeloautorizacioncondicionDao.Count();
		}

		public long CountVwModeloautorizacioncondicion(Expression<Func<VwModeloautorizacioncondicion, bool>> criteria)
		{
			return VwModeloautorizacioncondicionDao.Count(criteria);
		}

		public List<VwModeloautorizacioncondicion> GetAllVwModeloautorizacioncondicion()
		{
			return VwModeloautorizacioncondicionDao.GetAll();
		}

		public List<VwModeloautorizacioncondicion> GetAllVwModeloautorizacioncondicion(Expression<Func<VwModeloautorizacioncondicion, bool>> criteria)
		{
			return VwModeloautorizacioncondicionDao.GetAll(criteria);
		}

		public List<VwModeloautorizacioncondicion> GetAllVwModeloautorizacioncondicion(string orders)
		{
			return VwModeloautorizacioncondicionDao.GetAll(orders);
		}

		public List<VwModeloautorizacioncondicion> GetAllVwModeloautorizacioncondicion(string conditions, string orders)
		{
			return VwModeloautorizacioncondicionDao.GetAll(conditions, orders);
		}

		public VwModeloautorizacioncondicion GetVwModeloautorizacioncondicion(int id)
		{
			return VwModeloautorizacioncondicionDao.Get(id);
		}

		public VwModeloautorizacioncondicion GetVwModeloautorizacioncondicion(Expression<Func<VwModeloautorizacioncondicion, bool>> criteria)
		{
			return VwModeloautorizacioncondicionDao.Get(criteria);
		}
	}
}
