using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwPersonacontacto()
		{
			return VwPersonacontactoDao.Count();
		}

		public long CountVwPersonacontacto(Expression<Func<VwPersonacontacto, bool>> criteria)
		{
			return VwPersonacontactoDao.Count(criteria);
		}

		public List<VwPersonacontacto> GetAllVwPersonacontacto()
		{
			return VwPersonacontactoDao.GetAll();
		}

		public List<VwPersonacontacto> GetAllVwPersonacontacto(Expression<Func<VwPersonacontacto, bool>> criteria)
		{
			return VwPersonacontactoDao.GetAll(criteria);
		}

		public List<VwPersonacontacto> GetAllVwPersonacontacto(string orders)
		{
			return VwPersonacontactoDao.GetAll(orders);
		}

		public List<VwPersonacontacto> GetAllVwPersonacontacto(string conditions, string orders)
		{
			return VwPersonacontactoDao.GetAll(conditions, orders);
		}

		public VwPersonacontacto GetVwPersonacontacto(int id)
		{
			return VwPersonacontactoDao.Get(id);
		}

		public VwPersonacontacto GetVwPersonacontacto(Expression<Func<VwPersonacontacto, bool>> criteria)
		{
			return VwPersonacontactoDao.Get(criteria);
		}
	}
}
