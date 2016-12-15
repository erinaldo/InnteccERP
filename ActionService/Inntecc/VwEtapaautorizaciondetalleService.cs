using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwEtapaautorizaciondetalle()
		{
			return VwEtapaautorizaciondetalleDao.Count();
		}

		public long CountVwEtapaautorizaciondetalle(Expression<Func<VwEtapaautorizaciondetalle, bool>> criteria)
		{
			return VwEtapaautorizaciondetalleDao.Count(criteria);
		}

		public List<VwEtapaautorizaciondetalle> GetAllVwEtapaautorizaciondetalle()
		{
			return VwEtapaautorizaciondetalleDao.GetAll();
		}

		public List<VwEtapaautorizaciondetalle> GetAllVwEtapaautorizaciondetalle(Expression<Func<VwEtapaautorizaciondetalle, bool>> criteria)
		{
			return VwEtapaautorizaciondetalleDao.GetAll(criteria);
		}

		public List<VwEtapaautorizaciondetalle> GetAllVwEtapaautorizaciondetalle(string orders)
		{
			return VwEtapaautorizaciondetalleDao.GetAll(orders);
		}

		public List<VwEtapaautorizaciondetalle> GetAllVwEtapaautorizaciondetalle(string conditions, string orders)
		{
			return VwEtapaautorizaciondetalleDao.GetAll(conditions, orders);
		}

		public VwEtapaautorizaciondetalle GetVwEtapaautorizaciondetalle(int id)
		{
			return VwEtapaautorizaciondetalleDao.Get(id);
		}

		public VwEtapaautorizaciondetalle GetVwEtapaautorizaciondetalle(Expression<Func<VwEtapaautorizaciondetalle, bool>> criteria)
		{
			return VwEtapaautorizaciondetalleDao.Get(criteria);
		}
	}
}
