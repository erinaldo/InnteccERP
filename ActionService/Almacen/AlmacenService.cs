using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountAlmacen()
		{
			return AlmacenDao.Count();
		}

		public long CountAlmacen(Expression<Func<Almacen, bool>> criteria)
		{
			return AlmacenDao.Count(criteria);
		}

		public int SaveAlmacen(Almacen entity)
		{
			return AlmacenDao.Save(entity);
		}

		public void UpdateAlmacen(Almacen entity)
		{
			AlmacenDao.Update(entity);
		}

		public void DeleteAlmacen(int id)
		{
			AlmacenDao.Delete(id);
		}

		public List<Almacen> GetAllAlmacen()
		{
			return AlmacenDao.GetAll();
		}

		public List<Almacen> GetAllAlmacen(Expression<Func<Almacen, bool>> criteria)
		{
			return AlmacenDao.GetAll(criteria);
		}

		public List<Almacen> GetAllAlmacen(string orders)
		{
			return AlmacenDao.GetAll(orders);
		}

		public List<Almacen> GetAllAlmacen(string conditions, string orders)
		{
			return AlmacenDao.GetAll(conditions, orders);
		}

		public Almacen GetAlmacen(int id)
		{
			return AlmacenDao.Get(id);
		}

		public Almacen GetAlmacen(Expression<Func<Almacen, bool>> criteria)
		{
			return AlmacenDao.Get(criteria);
		}
	}
}
