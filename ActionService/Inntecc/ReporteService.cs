using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountReporte()
		{
			return ReporteDao.Count();
		}

		public long CountReporte(Expression<Func<Reporte, bool>> criteria)
		{
			return ReporteDao.Count(criteria);
		}

		public int SaveReporte(Reporte entity)
		{
			return ReporteDao.Save(entity);
		}

		public void UpdateReporte(Reporte entity)
		{
			ReporteDao.Update(entity);
		}

		public void DeleteReporte(int id)
		{
			ReporteDao.Delete(id);
		}

		public List<Reporte> GetAllReporte()
		{
			return ReporteDao.GetAll();
		}

		public List<Reporte> GetAllReporte(Expression<Func<Reporte, bool>> criteria)
		{
			return ReporteDao.GetAll(criteria);
		}

		public List<Reporte> GetAllReporte(string orders)
		{
			return ReporteDao.GetAll(orders);
		}

		public List<Reporte> GetAllReporte(string conditions, string orders)
		{
			return ReporteDao.GetAll(conditions, orders);
		}

		public Reporte GetReporte(int id)
		{
			return ReporteDao.Get(id);
		}

		public Reporte GetReporte(Expression<Func<Reporte, bool>> criteria)
		{
			return ReporteDao.Get(criteria);
		}
	}
}
