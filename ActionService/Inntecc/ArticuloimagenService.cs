using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountArticuloimagen()
		{
			return ArticuloimagenDao.Count();
		}

		public long CountArticuloimagen(Expression<Func<Articuloimagen, bool>> criteria)
		{
			return ArticuloimagenDao.Count(criteria);
		}

		public int SaveArticuloimagen(Articuloimagen entity)
		{
			return ArticuloimagenDao.Save(entity);
		}

		public void UpdateArticuloimagen(Articuloimagen entity)
		{
			ArticuloimagenDao.Update(entity);
		}

		public void DeleteArticuloimagen(int id)
		{
			ArticuloimagenDao.Delete(id);
		}

		public List<Articuloimagen> GetAllArticuloimagen()
		{
			return ArticuloimagenDao.GetAll();
		}

		public List<Articuloimagen> GetAllArticuloimagen(Expression<Func<Articuloimagen, bool>> criteria)
		{
			return ArticuloimagenDao.GetAll(criteria);
		}

		public List<Articuloimagen> GetAllArticuloimagen(string orders)
		{
			return ArticuloimagenDao.GetAll(orders);
		}

		public List<Articuloimagen> GetAllArticuloimagen(string conditions, string orders)
		{
			return ArticuloimagenDao.GetAll(conditions, orders);
		}

		public Articuloimagen GetArticuloimagen(int id)
		{
			return ArticuloimagenDao.Get(id);
		}

		public Articuloimagen GetArticuloimagen(Expression<Func<Articuloimagen, bool>> criteria)
		{
			return ArticuloimagenDao.Get(criteria);
		}
	}
}
