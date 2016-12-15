using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwProgramacioncita()
		{
			return VwProgramacioncitaDao.Count();
		}

		public long CountVwProgramacioncita(Expression<Func<VwProgramacioncita, bool>> criteria)
		{
			return VwProgramacioncitaDao.Count(criteria);
		}

		public List<VwProgramacioncita> GetAllVwProgramacioncita()
		{
			return VwProgramacioncitaDao.GetAll();
		}

		public List<VwProgramacioncita> GetAllVwProgramacioncita(Expression<Func<VwProgramacioncita, bool>> criteria)
		{
			return VwProgramacioncitaDao.GetAll(criteria);
		}

		public List<VwProgramacioncita> GetAllVwProgramacioncita(string orders)
		{
			return VwProgramacioncitaDao.GetAll(orders);
		}

		public List<VwProgramacioncita> GetAllVwProgramacioncita(string conditions, string orders)
		{
			return VwProgramacioncitaDao.GetAll(conditions, orders);
		}

		public VwProgramacioncita GetVwProgramacioncita(int id)
		{
			return VwProgramacioncitaDao.Get(id);
		}

		public VwProgramacioncita GetVwProgramacioncita(Expression<Func<VwProgramacioncita, bool>> criteria)
		{
			return VwProgramacioncitaDao.Get(criteria);
		}
	}
}
