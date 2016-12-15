using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwProgramacioncitadethistorial()
		{
			return VwProgramacioncitadethistorialDao.Count();
		}

		public long CountVwProgramacioncitadethistorial(Expression<Func<VwProgramacioncitadethistorial, bool>> criteria)
		{
			return VwProgramacioncitadethistorialDao.Count(criteria);
		}

		public List<VwProgramacioncitadethistorial> GetAllVwProgramacioncitadethistorial()
		{
			return VwProgramacioncitadethistorialDao.GetAll();
		}

		public List<VwProgramacioncitadethistorial> GetAllVwProgramacioncitadethistorial(Expression<Func<VwProgramacioncitadethistorial, bool>> criteria)
		{
			return VwProgramacioncitadethistorialDao.GetAll(criteria);
		}

		public List<VwProgramacioncitadethistorial> GetAllVwProgramacioncitadethistorial(string orders)
		{
			return VwProgramacioncitadethistorialDao.GetAll(orders);
		}

		public List<VwProgramacioncitadethistorial> GetAllVwProgramacioncitadethistorial(string conditions, string orders)
		{
			return VwProgramacioncitadethistorialDao.GetAll(conditions, orders);
		}

		public VwProgramacioncitadethistorial GetVwProgramacioncitadethistorial(int id)
		{
			return VwProgramacioncitadethistorialDao.Get(id);
		}

		public VwProgramacioncitadethistorial GetVwProgramacioncitadethistorial(Expression<Func<VwProgramacioncitadethistorial, bool>> criteria)
		{
			return VwProgramacioncitadethistorialDao.Get(criteria);
		}
	}
}
