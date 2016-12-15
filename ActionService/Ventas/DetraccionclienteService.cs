using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountDetraccioncliente()
		{
			return DetraccionclienteDao.Count();
		}

		public long CountDetraccioncliente(Expression<Func<Detraccioncliente, bool>> criteria)
		{
			return DetraccionclienteDao.Count(criteria);
		}

		public int SaveDetraccioncliente(Detraccioncliente entity)
		{
			return DetraccionclienteDao.Save(entity);
		}

		public void UpdateDetraccioncliente(Detraccioncliente entity)
		{
			DetraccionclienteDao.Update(entity);
		}

		public void DeleteDetraccioncliente(int id)
		{
			DetraccionclienteDao.Delete(id);
		}

		public List<Detraccioncliente> GetAllDetraccioncliente()
		{
			return DetraccionclienteDao.GetAll();
		}

		public List<Detraccioncliente> GetAllDetraccioncliente(Expression<Func<Detraccioncliente, bool>> criteria)
		{
			return DetraccionclienteDao.GetAll(criteria);
		}

		public List<Detraccioncliente> GetAllDetraccioncliente(string orders)
		{
			return DetraccionclienteDao.GetAll(orders);
		}

		public List<Detraccioncliente> GetAllDetraccioncliente(string conditions, string orders)
		{
			return DetraccionclienteDao.GetAll(conditions, orders);
		}

		public Detraccioncliente GetDetraccioncliente(int id)
		{
			return DetraccionclienteDao.Get(id);
		}

		public Detraccioncliente GetDetraccioncliente(Expression<Func<Detraccioncliente, bool>> criteria)
		{
			return DetraccionclienteDao.Get(criteria);
		}
	}
}
