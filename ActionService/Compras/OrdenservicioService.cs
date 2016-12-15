using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountOrdenservicio()
		{
			return OrdenservicioDao.Count();
		}

		public long CountOrdenservicio(Expression<Func<Ordenservicio, bool>> criteria)
		{
			return OrdenservicioDao.Count(criteria);
		}

		public int SaveOrdenservicio(Ordenservicio entity)
		{
			return OrdenservicioDao.Save(entity);
		}

		public void UpdateOrdenservicio(Ordenservicio entity)
		{
			OrdenservicioDao.Update(entity);
		}

		public void DeleteOrdenservicio(int id)
		{
			OrdenservicioDao.Delete(id);
		}

		public List<Ordenservicio> GetAllOrdenservicio()
		{
			return OrdenservicioDao.GetAll();
		}

		public List<Ordenservicio> GetAllOrdenservicio(Expression<Func<Ordenservicio, bool>> criteria)
		{
			return OrdenservicioDao.GetAll(criteria);
		}

		public List<Ordenservicio> GetAllOrdenservicio(string orders)
		{
			return OrdenservicioDao.GetAll(orders);
		}

		public List<Ordenservicio> GetAllOrdenservicio(string conditions, string orders)
		{
			return OrdenservicioDao.GetAll(conditions, orders);
		}

		public Ordenservicio GetOrdenservicio(int id)
		{
			return OrdenservicioDao.Get(id);
		}

		public Ordenservicio GetOrdenservicio(Expression<Func<Ordenservicio, bool>> criteria)
		{
			return OrdenservicioDao.Get(criteria);
		}
	}
}
