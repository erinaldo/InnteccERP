using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountVwUsuario()
		{
			return VwUsuarioDao.Count();
		}

		public long CountVwUsuario(Expression<Func<VwUsuario, bool>> criteria)
		{
			return VwUsuarioDao.Count(criteria);
		}

		public List<VwUsuario> GetAllVwUsuario()
		{
			return VwUsuarioDao.GetAll();
		}

		public List<VwUsuario> GetAllVwUsuario(Expression<Func<VwUsuario, bool>> criteria)
		{
			return VwUsuarioDao.GetAll(criteria);
		}

		public List<VwUsuario> GetAllVwUsuario(string orders)
		{
			return VwUsuarioDao.GetAll(orders);
		}

		public List<VwUsuario> GetAllVwUsuario(string conditions, string orders)
		{
			return VwUsuarioDao.GetAll(conditions, orders);
		}

		public VwUsuario GetVwUsuario(int id)
		{
			return VwUsuarioDao.Get(id);
		}

		public VwUsuario GetVwUsuario(Expression<Func<VwUsuario, bool>> criteria)
		{
			return VwUsuarioDao.Get(criteria);
		}
	}
}
