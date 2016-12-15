using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountValorpordefecto()
		{
			return ValorpordefectoDao.Count();
		}

		public long CountValorpordefecto(Expression<Func<Valorpordefecto, bool>> criteria)
		{
			return ValorpordefectoDao.Count(criteria);
		}

		public int SaveValorpordefecto(Valorpordefecto entity)
		{
			return ValorpordefectoDao.Save(entity);
		}

		public void UpdateValorpordefecto(Valorpordefecto entity)
		{
			ValorpordefectoDao.Update(entity);
		}

		public void DeleteValorpordefecto(int id)
		{
			ValorpordefectoDao.Delete(id);
		}

		public List<Valorpordefecto> GetAllValorpordefecto()
		{
			return ValorpordefectoDao.GetAll();
		}

		public List<Valorpordefecto> GetAllValorpordefecto(Expression<Func<Valorpordefecto, bool>> criteria)
		{
			return ValorpordefectoDao.GetAll(criteria);
		}

		public List<Valorpordefecto> GetAllValorpordefecto(string orders)
		{
			return ValorpordefectoDao.GetAll(orders);
		}

		public List<Valorpordefecto> GetAllValorpordefecto(string conditions, string orders)
		{
			return ValorpordefectoDao.GetAll(conditions, orders);
		}

		public Valorpordefecto GetValorpordefecto(int id)
		{
			return ValorpordefectoDao.Get(id);
		}

		public Valorpordefecto GetValorpordefecto(Expression<Func<Valorpordefecto, bool>> criteria)
		{
			return ValorpordefectoDao.Get(criteria);
		}
	}
}
