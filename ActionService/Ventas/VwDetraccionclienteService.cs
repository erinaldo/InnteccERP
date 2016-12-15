using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwDetraccioncliente()
		{
			return VwDetraccionclienteDao.Count();
		}

		public long CountVwDetraccioncliente(Expression<Func<VwDetraccioncliente, bool>> criteria)
		{
			return VwDetraccionclienteDao.Count(criteria);
		}

		public List<VwDetraccioncliente> GetAllVwDetraccioncliente()
		{
			return VwDetraccionclienteDao.GetAll();
		}

		public List<VwDetraccioncliente> GetAllVwDetraccioncliente(Expression<Func<VwDetraccioncliente, bool>> criteria)
		{
			return VwDetraccionclienteDao.GetAll(criteria);
		}

		public List<VwDetraccioncliente> GetAllVwDetraccioncliente(string orders)
		{
			return VwDetraccionclienteDao.GetAll(orders);
		}

		public List<VwDetraccioncliente> GetAllVwDetraccioncliente(string conditions, string orders)
		{
			return VwDetraccionclienteDao.GetAll(conditions, orders);
		}

		public VwDetraccioncliente GetVwDetraccioncliente(int id)
		{
			return VwDetraccionclienteDao.Get(id);
		}

		public VwDetraccioncliente GetVwDetraccioncliente(Expression<Func<VwDetraccioncliente, bool>> criteria)
		{
			return VwDetraccionclienteDao.Get(criteria);
		}
	}
}
