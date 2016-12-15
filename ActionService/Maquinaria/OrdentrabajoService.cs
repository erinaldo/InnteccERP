using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountOrdentrabajo()
		{
			return OrdentrabajoDao.Count();
		}

		public long CountOrdentrabajo(Expression<Func<Ordentrabajo, bool>> criteria)
		{
			return OrdentrabajoDao.Count(criteria);
		}

		public int SaveOrdentrabajo(Ordentrabajo entity)
		{
			return OrdentrabajoDao.Save(entity);
		}

		public void UpdateOrdentrabajo(Ordentrabajo entity)
		{
			OrdentrabajoDao.Update(entity);
		}

		public void DeleteOrdentrabajo(int id)
		{
			OrdentrabajoDao.Delete(id);
		}

		public List<Ordentrabajo> GetAllOrdentrabajo()
		{
			return OrdentrabajoDao.GetAll();
		}

		public List<Ordentrabajo> GetAllOrdentrabajo(Expression<Func<Ordentrabajo, bool>> criteria)
		{
			return OrdentrabajoDao.GetAll(criteria);
		}

		public List<Ordentrabajo> GetAllOrdentrabajo(string orders)
		{
			return OrdentrabajoDao.GetAll(orders);
		}

		public List<Ordentrabajo> GetAllOrdentrabajo(string conditions, string orders)
		{
			return OrdentrabajoDao.GetAll(conditions, orders);
		}

		public Ordentrabajo GetOrdentrabajo(int id)
		{
			return OrdentrabajoDao.Get(id);
		}

		public Ordentrabajo GetOrdentrabajo(Expression<Func<Ordentrabajo, bool>> criteria)
		{
			return OrdentrabajoDao.Get(criteria);
		}
	}
}
