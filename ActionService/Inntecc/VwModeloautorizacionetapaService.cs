using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwModeloautorizacionetapa()
		{
			return VwModeloautorizacionetapaDao.Count();
		}

		public long CountVwModeloautorizacionetapa(Expression<Func<VwModeloautorizacionetapa, bool>> criteria)
		{
			return VwModeloautorizacionetapaDao.Count(criteria);
		}

		public List<VwModeloautorizacionetapa> GetAllVwModeloautorizacionetapa()
		{
			return VwModeloautorizacionetapaDao.GetAll();
		}

		public List<VwModeloautorizacionetapa> GetAllVwModeloautorizacionetapa(Expression<Func<VwModeloautorizacionetapa, bool>> criteria)
		{
			return VwModeloautorizacionetapaDao.GetAll(criteria);
		}

		public List<VwModeloautorizacionetapa> GetAllVwModeloautorizacionetapa(string orders)
		{
			return VwModeloautorizacionetapaDao.GetAll(orders);
		}

		public List<VwModeloautorizacionetapa> GetAllVwModeloautorizacionetapa(string conditions, string orders)
		{
			return VwModeloautorizacionetapaDao.GetAll(conditions, orders);
		}

		public VwModeloautorizacionetapa GetVwModeloautorizacionetapa(int id)
		{
			return VwModeloautorizacionetapaDao.Get(id);
		}

		public VwModeloautorizacionetapa GetVwModeloautorizacionetapa(Expression<Func<VwModeloautorizacionetapa, bool>> criteria)
		{
			return VwModeloautorizacionetapaDao.Get(criteria);
		}
	}
}
