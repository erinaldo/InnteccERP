using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCierrecaja()
		{
			return CierrecajaDao.Count();
		}

		public long CountCierrecaja(Expression<Func<Cierrecaja, bool>> criteria)
		{
			return CierrecajaDao.Count(criteria);
		}

		public int SaveCierrecaja(Cierrecaja entity)
		{
			return CierrecajaDao.Save(entity);
		}

		public void UpdateCierrecaja(Cierrecaja entity)
		{
			CierrecajaDao.Update(entity);
		}

		public void DeleteCierrecaja(int id)
		{
			CierrecajaDao.Delete(id);
		}

		public List<Cierrecaja> GetAllCierrecaja()
		{
			return CierrecajaDao.GetAll();
		}

		public List<Cierrecaja> GetAllCierrecaja(Expression<Func<Cierrecaja, bool>> criteria)
		{
			return CierrecajaDao.GetAll(criteria);
		}

		public List<Cierrecaja> GetAllCierrecaja(string orders)
		{
			return CierrecajaDao.GetAll(orders);
		}

		public List<Cierrecaja> GetAllCierrecaja(string conditions, string orders)
		{
			return CierrecajaDao.GetAll(conditions, orders);
		}

		public Cierrecaja GetCierrecaja(int id)
		{
			return CierrecajaDao.Get(id);
		}

		public Cierrecaja GetCierrecaja(Expression<Func<Cierrecaja, bool>> criteria)
		{
			return CierrecajaDao.Get(criteria);
		}
	}
}
