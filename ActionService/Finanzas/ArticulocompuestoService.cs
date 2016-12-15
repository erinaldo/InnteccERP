using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountArticulocompuesto()
		{
			return ArticulocompuestoDao.Count();
		}

		public long CountArticulocompuesto(Expression<Func<Articulocompuesto, bool>> criteria)
		{
			return ArticulocompuestoDao.Count(criteria);
		}

		public int SaveArticulocompuesto(Articulocompuesto entity)
		{
			return ArticulocompuestoDao.Save(entity);
		}

		public void UpdateArticulocompuesto(Articulocompuesto entity)
		{
			ArticulocompuestoDao.Update(entity);
		}

		public void DeleteArticulocompuesto(int id)
		{
			ArticulocompuestoDao.Delete(id);
		}

		public List<Articulocompuesto> GetAllArticulocompuesto()
		{
			return ArticulocompuestoDao.GetAll();
		}

		public List<Articulocompuesto> GetAllArticulocompuesto(Expression<Func<Articulocompuesto, bool>> criteria)
		{
			return ArticulocompuestoDao.GetAll(criteria);
		}

		public List<Articulocompuesto> GetAllArticulocompuesto(string orders)
		{
			return ArticulocompuestoDao.GetAll(orders);
		}

		public List<Articulocompuesto> GetAllArticulocompuesto(string conditions, string orders)
		{
			return ArticulocompuestoDao.GetAll(conditions, orders);
		}

		public Articulocompuesto GetArticulocompuesto(int id)
		{
			return ArticulocompuestoDao.Get(id);
		}

		public Articulocompuesto GetArticulocompuesto(Expression<Func<Articulocompuesto, bool>> criteria)
		{
			return ArticulocompuestoDao.Get(criteria);
		}
	}
}
