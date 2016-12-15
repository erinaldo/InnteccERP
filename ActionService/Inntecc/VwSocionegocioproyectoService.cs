using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwSocionegocioproyecto()
		{
			return VwSocionegocioproyectoDao.Count();
		}

		public long CountVwSocionegocioproyecto(Expression<Func<VwSocionegocioproyecto, bool>> criteria)
		{
			return VwSocionegocioproyectoDao.Count(criteria);
		}

		public List<VwSocionegocioproyecto> GetAllVwSocionegocioproyecto()
		{
			return VwSocionegocioproyectoDao.GetAll();
		}

		public List<VwSocionegocioproyecto> GetAllVwSocionegocioproyecto(Expression<Func<VwSocionegocioproyecto, bool>> criteria)
		{
			return VwSocionegocioproyectoDao.GetAll(criteria);
		}

		public List<VwSocionegocioproyecto> GetAllVwSocionegocioproyecto(string orders)
		{
			return VwSocionegocioproyectoDao.GetAll(orders);
		}

		public List<VwSocionegocioproyecto> GetAllVwSocionegocioproyecto(string conditions, string orders)
		{
			return VwSocionegocioproyectoDao.GetAll(conditions, orders);
		}

		public VwSocionegocioproyecto GetVwSocionegocioproyecto(int id)
		{
			return VwSocionegocioproyectoDao.Get(id);
		}

		public VwSocionegocioproyecto GetVwSocionegocioproyecto(Expression<Func<VwSocionegocioproyecto, bool>> criteria)
		{
			return VwSocionegocioproyectoDao.Get(criteria);
		}
	}
}
