using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountSeriearticulo()
		{
			return SeriearticuloDao.Count();
		}

		public long CountSeriearticulo(Expression<Func<Seriearticulo, bool>> criteria)
		{
			return SeriearticuloDao.Count(criteria);
		}

		public int SaveSeriearticulo(Seriearticulo entity)
		{
			return SeriearticuloDao.Save(entity);
		}

		public void UpdateSeriearticulo(Seriearticulo entity)
		{
			SeriearticuloDao.Update(entity);
		}

		public void DeleteSeriearticulo(int id)
		{
			SeriearticuloDao.Delete(id);
		}

		public List<Seriearticulo> GetAllSeriearticulo()
		{
			return SeriearticuloDao.GetAll();
		}

		public List<Seriearticulo> GetAllSeriearticulo(Expression<Func<Seriearticulo, bool>> criteria)
		{
			return SeriearticuloDao.GetAll(criteria);
		}

		public List<Seriearticulo> GetAllSeriearticulo(string orders)
		{
			return SeriearticuloDao.GetAll(orders);
		}

		public List<Seriearticulo> GetAllSeriearticulo(string conditions, string orders)
		{
			return SeriearticuloDao.GetAll(conditions, orders);
		}

		public Seriearticulo GetSeriearticulo(int id)
		{
			return SeriearticuloDao.Get(id);
		}

		public Seriearticulo GetSeriearticulo(Expression<Func<Seriearticulo, bool>> criteria)
		{
			return SeriearticuloDao.Get(criteria);
		}
	}
}
