using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwGrupousuarioitem()
		{
			return VwGrupousuarioitemDao.Count();
		}

		public long CountVwGrupousuarioitem(Expression<Func<VwGrupousuarioitem, bool>> criteria)
		{
			return VwGrupousuarioitemDao.Count(criteria);
		}

		public List<VwGrupousuarioitem> GetAllVwGrupousuarioitem()
		{
			return VwGrupousuarioitemDao.GetAll();
		}

		public List<VwGrupousuarioitem> GetAllVwGrupousuarioitem(Expression<Func<VwGrupousuarioitem, bool>> criteria)
		{
			return VwGrupousuarioitemDao.GetAll(criteria);
		}

		public List<VwGrupousuarioitem> GetAllVwGrupousuarioitem(string orders)
		{
			return VwGrupousuarioitemDao.GetAll(orders);
		}

		public List<VwGrupousuarioitem> GetAllVwGrupousuarioitem(string conditions, string orders)
		{
			return VwGrupousuarioitemDao.GetAll(conditions, orders);
		}

		public VwGrupousuarioitem GetVwGrupousuarioitem(int id)
		{
			return VwGrupousuarioitemDao.Get(id);
		}

		public VwGrupousuarioitem GetVwGrupousuarioitem(Expression<Func<VwGrupousuarioitem, bool>> criteria)
		{
			return VwGrupousuarioitemDao.Get(criteria);
		}
	}
}
