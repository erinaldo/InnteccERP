using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountTipolistatipocondicion()
		{
			return TipolistatipocondicionDao.Count();
		}

		public long CountTipolistatipocondicion(Expression<Func<Tipolistatipocondicion, bool>> criteria)
		{
			return TipolistatipocondicionDao.Count(criteria);
		}

		public int SaveTipolistatipocondicion(Tipolistatipocondicion entity)
		{
			return TipolistatipocondicionDao.Save(entity);
		}

		public void UpdateTipolistatipocondicion(Tipolistatipocondicion entity)
		{
			TipolistatipocondicionDao.Update(entity);
		}

		public void DeleteTipolistatipocondicion(int id)
		{
			TipolistatipocondicionDao.Delete(id);
		}

		public List<Tipolistatipocondicion> GetAllTipolistatipocondicion()
		{
			return TipolistatipocondicionDao.GetAll();
		}

		public List<Tipolistatipocondicion> GetAllTipolistatipocondicion(Expression<Func<Tipolistatipocondicion, bool>> criteria)
		{
			return TipolistatipocondicionDao.GetAll(criteria);
		}

		public List<Tipolistatipocondicion> GetAllTipolistatipocondicion(string orders)
		{
			return TipolistatipocondicionDao.GetAll(orders);
		}

		public List<Tipolistatipocondicion> GetAllTipolistatipocondicion(string conditions, string orders)
		{
			return TipolistatipocondicionDao.GetAll(conditions, orders);
		}

		public Tipolistatipocondicion GetTipolistatipocondicion(int id)
		{
			return TipolistatipocondicionDao.Get(id);
		}

		public Tipolistatipocondicion GetTipolistatipocondicion(Expression<Func<Tipolistatipocondicion, bool>> criteria)
		{
			return TipolistatipocondicionDao.Get(criteria);
		}
	}
}
