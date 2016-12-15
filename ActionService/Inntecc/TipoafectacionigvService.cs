using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipoafectacionigv()
		{
			return TipoafectacionigvDao.Count();
		}

		public long CountTipoafectacionigv(Expression<Func<Tipoafectacionigv, bool>> criteria)
		{
			return TipoafectacionigvDao.Count(criteria);
		}

		public int SaveTipoafectacionigv(Tipoafectacionigv entity)
		{
			return TipoafectacionigvDao.Save(entity);
		}

		public void UpdateTipoafectacionigv(Tipoafectacionigv entity)
		{
			TipoafectacionigvDao.Update(entity);
		}

		public void DeleteTipoafectacionigv(int id)
		{
			TipoafectacionigvDao.Delete(id);
		}

		public List<Tipoafectacionigv> GetAllTipoafectacionigv()
		{
			return TipoafectacionigvDao.GetAll();
		}

		public List<Tipoafectacionigv> GetAllTipoafectacionigv(Expression<Func<Tipoafectacionigv, bool>> criteria)
		{
			return TipoafectacionigvDao.GetAll(criteria);
		}

		public List<Tipoafectacionigv> GetAllTipoafectacionigv(string orders)
		{
			return TipoafectacionigvDao.GetAll(orders);
		}

		public List<Tipoafectacionigv> GetAllTipoafectacionigv(string conditions, string orders)
		{
			return TipoafectacionigvDao.GetAll(conditions, orders);
		}

		public Tipoafectacionigv GetTipoafectacionigv(int id)
		{
			return TipoafectacionigvDao.Get(id);
		}

		public Tipoafectacionigv GetTipoafectacionigv(Expression<Func<Tipoafectacionigv, bool>> criteria)
		{
			return TipoafectacionigvDao.Get(criteria);
		}
	}
}
