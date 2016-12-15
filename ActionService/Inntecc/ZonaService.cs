using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountZona()
		{
			return ZonaDao.Count();
		}

		public long CountZona(Expression<Func<Zona, bool>> criteria)
		{
			return ZonaDao.Count(criteria);
		}

		public int SaveZona(Zona entity)
		{
			return ZonaDao.Save(entity);
		}

		public void UpdateZona(Zona entity)
		{
			ZonaDao.Update(entity);
		}

		public void DeleteZona(int id)
		{
			ZonaDao.Delete(id);
		}

		public List<Zona> GetAllZona()
		{
			return ZonaDao.GetAll();
		}

		public List<Zona> GetAllZona(Expression<Func<Zona, bool>> criteria)
		{
			return ZonaDao.GetAll(criteria);
		}

		public List<Zona> GetAllZona(string orders)
		{
			return ZonaDao.GetAll(orders);
		}

		public List<Zona> GetAllZona(string conditions, string orders)
		{
			return ZonaDao.GetAll(conditions, orders);
		}

		public Zona GetZona(int id)
		{
			return ZonaDao.Get(id);
		}

		public Zona GetZona(Expression<Func<Zona, bool>> criteria)
		{
			return ZonaDao.Get(criteria);
		}
	}
}
