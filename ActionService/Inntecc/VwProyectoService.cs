using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwProyecto()
		{
			return VwProyectoDao.Count();
		}

		public long CountVwProyecto(Expression<Func<VwProyecto, bool>> criteria)
		{
			return VwProyectoDao.Count(criteria);
		}

		public List<VwProyecto> GetAllVwProyecto()
		{
			return VwProyectoDao.GetAll();
		}

		public List<VwProyecto> GetAllVwProyecto(Expression<Func<VwProyecto, bool>> criteria)
		{
			return VwProyectoDao.GetAll(criteria);
		}

		public List<VwProyecto> GetAllVwProyecto(string orders)
		{
			return VwProyectoDao.GetAll(orders);
		}

		public List<VwProyecto> GetAllVwProyecto(string conditions, string orders)
		{
			return VwProyectoDao.GetAll(conditions, orders);
		}

		public VwProyecto GetVwProyecto(int id)
		{
			return VwProyectoDao.Get(id);
		}

		public VwProyecto GetVwProyecto(Expression<Func<VwProyecto, bool>> criteria)
		{
			return VwProyectoDao.Get(criteria);
		}
	}
}
