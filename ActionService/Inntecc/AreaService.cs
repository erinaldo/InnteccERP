using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountArea()
		{
			return AreaDao.Count();
		}

		public long CountArea(Expression<Func<Area, bool>> criteria)
		{
			return AreaDao.Count(criteria);
		}

		public int SaveArea(Area entity)
		{
			return AreaDao.Save(entity);
		}

		public void UpdateArea(Area entity)
		{
			AreaDao.Update(entity);
		}

		public void DeleteArea(int id)
		{
			AreaDao.Delete(id);
		}

		public List<Area> GetAllArea()
		{
			return AreaDao.GetAll();
		}

		public List<Area> GetAllArea(Expression<Func<Area, bool>> criteria)
		{
			return AreaDao.GetAll(criteria);
		}

		public List<Area> GetAllArea(string orders)
		{
			return AreaDao.GetAll(orders);
		}

		public List<Area> GetAllArea(string conditions, string orders)
		{
			return AreaDao.GetAll(conditions, orders);
		}

		public Area GetArea(int id)
		{
			return AreaDao.Get(id);
		}

		public Area GetArea(Expression<Func<Area, bool>> criteria)
		{
			return AreaDao.Get(criteria);
		}
	}
}
