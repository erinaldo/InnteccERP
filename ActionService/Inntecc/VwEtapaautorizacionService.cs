using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwEtapaautorizacion()
		{
			return VwEtapaautorizacionDao.Count();
		}

		public long CountVwEtapaautorizacion(Expression<Func<VwEtapaautorizacion, bool>> criteria)
		{
			return VwEtapaautorizacionDao.Count(criteria);
		}

		public List<VwEtapaautorizacion> GetAllVwEtapaautorizacion()
		{
			return VwEtapaautorizacionDao.GetAll();
		}

		public List<VwEtapaautorizacion> GetAllVwEtapaautorizacion(Expression<Func<VwEtapaautorizacion, bool>> criteria)
		{
			return VwEtapaautorizacionDao.GetAll(criteria);
		}

		public List<VwEtapaautorizacion> GetAllVwEtapaautorizacion(string orders)
		{
			return VwEtapaautorizacionDao.GetAll(orders);
		}

		public List<VwEtapaautorizacion> GetAllVwEtapaautorizacion(string conditions, string orders)
		{
			return VwEtapaautorizacionDao.GetAll(conditions, orders);
		}

		public VwEtapaautorizacion GetVwEtapaautorizacion(int id)
		{
			return VwEtapaautorizacionDao.Get(id);
		}

		public VwEtapaautorizacion GetVwEtapaautorizacion(Expression<Func<VwEtapaautorizacion, bool>> criteria)
		{
			return VwEtapaautorizacionDao.Get(criteria);
		}
	}
}
