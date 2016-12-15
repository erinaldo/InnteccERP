using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwSocionegociolimitecredito()
		{
			return VwSocionegociolimitecreditoDao.Count();
		}

		public long CountVwSocionegociolimitecredito(Expression<Func<VwSocionegociolimitecredito, bool>> criteria)
		{
			return VwSocionegociolimitecreditoDao.Count(criteria);
		}

		public List<VwSocionegociolimitecredito> GetAllVwSocionegociolimitecredito()
		{
			return VwSocionegociolimitecreditoDao.GetAll();
		}

		public List<VwSocionegociolimitecredito> GetAllVwSocionegociolimitecredito(Expression<Func<VwSocionegociolimitecredito, bool>> criteria)
		{
			return VwSocionegociolimitecreditoDao.GetAll(criteria);
		}

		public List<VwSocionegociolimitecredito> GetAllVwSocionegociolimitecredito(string orders)
		{
			return VwSocionegociolimitecreditoDao.GetAll(orders);
		}

		public List<VwSocionegociolimitecredito> GetAllVwSocionegociolimitecredito(string conditions, string orders)
		{
			return VwSocionegociolimitecreditoDao.GetAll(conditions, orders);
		}

		public VwSocionegociolimitecredito GetVwSocionegociolimitecredito(int id)
		{
			return VwSocionegociolimitecreditoDao.Get(id);
		}

		public VwSocionegociolimitecredito GetVwSocionegociolimitecredito(Expression<Func<VwSocionegociolimitecredito, bool>> criteria)
		{
			return VwSocionegociolimitecreditoDao.Get(criteria);
		}
	}
}
