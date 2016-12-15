using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEstadopago()
		{
			return EstadopagoDao.Count();
		}

		public long CountEstadopago(Expression<Func<Estadopago, bool>> criteria)
		{
			return EstadopagoDao.Count(criteria);
		}

		public int SaveEstadopago(Estadopago entity)
		{
			return EstadopagoDao.Save(entity);
		}

		public void UpdateEstadopago(Estadopago entity)
		{
			EstadopagoDao.Update(entity);
		}

		public void DeleteEstadopago(int id)
		{
			EstadopagoDao.Delete(id);
		}

		public List<Estadopago> GetAllEstadopago()
		{
			return EstadopagoDao.GetAll();
		}

		public List<Estadopago> GetAllEstadopago(Expression<Func<Estadopago, bool>> criteria)
		{
			return EstadopagoDao.GetAll(criteria);
		}

		public List<Estadopago> GetAllEstadopago(string orders)
		{
			return EstadopagoDao.GetAll(orders);
		}

		public List<Estadopago> GetAllEstadopago(string conditions, string orders)
		{
			return EstadopagoDao.GetAll(conditions, orders);
		}

		public Estadopago GetEstadopago(int id)
		{
			return EstadopagoDao.Get(id);
		}

		public Estadopago GetEstadopago(Expression<Func<Estadopago, bool>> criteria)
		{
			return EstadopagoDao.Get(criteria);
		}
	}
}
