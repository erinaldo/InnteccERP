using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountDiaferiado()
		{
			return DiaferiadoDao.Count();
		}

		public long CountDiaferiado(Expression<Func<Diaferiado, bool>> criteria)
		{
			return DiaferiadoDao.Count(criteria);
		}

		public int SaveDiaferiado(Diaferiado entity)
		{
			return DiaferiadoDao.Save(entity);
		}

		public void UpdateDiaferiado(Diaferiado entity)
		{
			DiaferiadoDao.Update(entity);
		}

		public void DeleteDiaferiado(int id)
		{
			DiaferiadoDao.Delete(id);
		}

		public List<Diaferiado> GetAllDiaferiado()
		{
			return DiaferiadoDao.GetAll();
		}

		public List<Diaferiado> GetAllDiaferiado(Expression<Func<Diaferiado, bool>> criteria)
		{
			return DiaferiadoDao.GetAll(criteria);
		}

		public List<Diaferiado> GetAllDiaferiado(string orders)
		{
			return DiaferiadoDao.GetAll(orders);
		}

		public List<Diaferiado> GetAllDiaferiado(string conditions, string orders)
		{
			return DiaferiadoDao.GetAll(conditions, orders);
		}

		public Diaferiado GetDiaferiado(int id)
		{
			return DiaferiadoDao.Get(id);
		}

		public Diaferiado GetDiaferiado(Expression<Func<Diaferiado, bool>> criteria)
		{
			return DiaferiadoDao.Get(criteria);
		}
	}
}
