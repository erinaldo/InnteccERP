using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwProgramacioncitadet()
		{
			return VwProgramacioncitadetDao.Count();
		}

		public long CountVwProgramacioncitadet(Expression<Func<VwProgramacioncitadet, bool>> criteria)
		{
			return VwProgramacioncitadetDao.Count(criteria);
		}

		public List<VwProgramacioncitadet> GetAllVwProgramacioncitadet()
		{
			return VwProgramacioncitadetDao.GetAll();
		}

		public List<VwProgramacioncitadet> GetAllVwProgramacioncitadet(Expression<Func<VwProgramacioncitadet, bool>> criteria)
		{
			return VwProgramacioncitadetDao.GetAll(criteria);
		}

		public List<VwProgramacioncitadet> GetAllVwProgramacioncitadet(string orders)
		{
			return VwProgramacioncitadetDao.GetAll(orders);
		}

		public List<VwProgramacioncitadet> GetAllVwProgramacioncitadet(string conditions, string orders)
		{
			return VwProgramacioncitadetDao.GetAll(conditions, orders);
		}

		public VwProgramacioncitadet GetVwProgramacioncitadet(int id)
		{
			return VwProgramacioncitadetDao.Get(id);
		}

		public VwProgramacioncitadet GetVwProgramacioncitadet(Expression<Func<VwProgramacioncitadet, bool>> criteria)
		{
			return VwProgramacioncitadetDao.Get(criteria);
		}
	}
}
