using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountHistoriaarchivo()
		{
			return HistoriaarchivoDao.Count();
		}

		public long CountHistoriaarchivo(Expression<Func<Historiaarchivo, bool>> criteria)
		{
			return HistoriaarchivoDao.Count(criteria);
		}

		public int SaveHistoriaarchivo(Historiaarchivo entity)
		{
			return HistoriaarchivoDao.Save(entity);
		}

		public void UpdateHistoriaarchivo(Historiaarchivo entity)
		{
			HistoriaarchivoDao.Update(entity);
		}

		public void DeleteHistoriaarchivo(int id)
		{
			HistoriaarchivoDao.Delete(id);
		}

		public List<Historiaarchivo> GetAllHistoriaarchivo()
		{
			return HistoriaarchivoDao.GetAll();
		}

		public List<Historiaarchivo> GetAllHistoriaarchivo(Expression<Func<Historiaarchivo, bool>> criteria)
		{
			return HistoriaarchivoDao.GetAll(criteria);
		}

		public List<Historiaarchivo> GetAllHistoriaarchivo(string orders)
		{
			return HistoriaarchivoDao.GetAll(orders);
		}

		public List<Historiaarchivo> GetAllHistoriaarchivo(string conditions, string orders)
		{
			return HistoriaarchivoDao.GetAll(conditions, orders);
		}

		public Historiaarchivo GetHistoriaarchivo(int id)
		{
			return HistoriaarchivoDao.Get(id);
		}

		public Historiaarchivo GetHistoriaarchivo(Expression<Func<Historiaarchivo, bool>> criteria)
		{
			return HistoriaarchivoDao.Get(criteria);
		}
	}
}
