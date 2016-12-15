using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwModeloautorizacioninfo()
		{
			return VwModeloautorizacioninfoDao.Count();
		}

		public long CountVwModeloautorizacioninfo(Expression<Func<VwModeloautorizacioninfo, bool>> criteria)
		{
			return VwModeloautorizacioninfoDao.Count(criteria);
		}

		public List<VwModeloautorizacioninfo> GetAllVwModeloautorizacioninfo()
		{
			return VwModeloautorizacioninfoDao.GetAll();
		}

		public List<VwModeloautorizacioninfo> GetAllVwModeloautorizacioninfo(Expression<Func<VwModeloautorizacioninfo, bool>> criteria)
		{
			return VwModeloautorizacioninfoDao.GetAll(criteria);
		}

		public List<VwModeloautorizacioninfo> GetAllVwModeloautorizacioninfo(string orders)
		{
			return VwModeloautorizacioninfoDao.GetAll(orders);
		}

		public List<VwModeloautorizacioninfo> GetAllVwModeloautorizacioninfo(string conditions, string orders)
		{
			return VwModeloautorizacioninfoDao.GetAll(conditions, orders);
		}

		public VwModeloautorizacioninfo GetVwModeloautorizacioninfo(int id)
		{
			return VwModeloautorizacioninfoDao.Get(id);
		}

		public VwModeloautorizacioninfo GetVwModeloautorizacioninfo(Expression<Func<VwModeloautorizacioninfo, bool>> criteria)
		{
			return VwModeloautorizacioninfoDao.Get(criteria);
		}
	}
}
