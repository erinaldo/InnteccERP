using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwAccesoform()
		{
			return VwAccesoformDao.Count();
		}

		public long CountVwAccesoform(Expression<Func<VwAccesoform, bool>> criteria)
		{
			return VwAccesoformDao.Count(criteria);
		}

		public List<VwAccesoform> GetAllVwAccesoform()
		{
			return VwAccesoformDao.GetAll();
		}

		public List<VwAccesoform> GetAllVwAccesoform(Expression<Func<VwAccesoform, bool>> criteria)
		{
			return VwAccesoformDao.GetAll(criteria);
		}

		public List<VwAccesoform> GetAllVwAccesoform(string orders)
		{
			return VwAccesoformDao.GetAll(orders);
		}

		public List<VwAccesoform> GetAllVwAccesoform(string conditions, string orders)
		{
			return VwAccesoformDao.GetAll(conditions, orders);
		}

		public VwAccesoform GetVwAccesoform(int id)
		{
			return VwAccesoformDao.Get(id);
		}

		public VwAccesoform GetVwAccesoform(Expression<Func<VwAccesoform, bool>> criteria)
		{
			return VwAccesoformDao.Get(criteria);
		}
	}
}
