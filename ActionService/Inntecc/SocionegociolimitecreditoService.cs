using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountSocionegociolimitecredito()
		{
			return SocionegociolimitecreditoDao.Count();
		}

		public long CountSocionegociolimitecredito(Expression<Func<Socionegociolimitecredito, bool>> criteria)
		{
			return SocionegociolimitecreditoDao.Count(criteria);
		}

		public int SaveSocionegociolimitecredito(Socionegociolimitecredito entity)
		{
			return SocionegociolimitecreditoDao.Save(entity);
		}

		public void UpdateSocionegociolimitecredito(Socionegociolimitecredito entity)
		{
			SocionegociolimitecreditoDao.Update(entity);
		}

		public void DeleteSocionegociolimitecredito(int id)
		{
			SocionegociolimitecreditoDao.Delete(id);
		}

		public List<Socionegociolimitecredito> GetAllSocionegociolimitecredito()
		{
			return SocionegociolimitecreditoDao.GetAll();
		}

		public List<Socionegociolimitecredito> GetAllSocionegociolimitecredito(Expression<Func<Socionegociolimitecredito, bool>> criteria)
		{
			return SocionegociolimitecreditoDao.GetAll(criteria);
		}

		public List<Socionegociolimitecredito> GetAllSocionegociolimitecredito(string orders)
		{
			return SocionegociolimitecreditoDao.GetAll(orders);
		}

		public List<Socionegociolimitecredito> GetAllSocionegociolimitecredito(string conditions, string orders)
		{
			return SocionegociolimitecreditoDao.GetAll(conditions, orders);
		}

		public Socionegociolimitecredito GetSocionegociolimitecredito(int id)
		{
			return SocionegociolimitecreditoDao.Get(id);
		}

		public Socionegociolimitecredito GetSocionegociolimitecredito(Expression<Func<Socionegociolimitecredito, bool>> criteria)
		{
			return SocionegociolimitecreditoDao.Get(criteria);
		}
	}
}
