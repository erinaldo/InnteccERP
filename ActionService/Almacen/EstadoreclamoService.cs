using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEstadoreclamo()
		{
			return EstadoreclamoDao.Count();
		}

		public long CountEstadoreclamo(Expression<Func<Estadoreclamo, bool>> criteria)
		{
			return EstadoreclamoDao.Count(criteria);
		}

		public int SaveEstadoreclamo(Estadoreclamo entity)
		{
			return EstadoreclamoDao.Save(entity);
		}

		public void UpdateEstadoreclamo(Estadoreclamo entity)
		{
			EstadoreclamoDao.Update(entity);
		}

		public void DeleteEstadoreclamo(int id)
		{
			EstadoreclamoDao.Delete(id);
		}

		public List<Estadoreclamo> GetAllEstadoreclamo()
		{
			return EstadoreclamoDao.GetAll();
		}

		public List<Estadoreclamo> GetAllEstadoreclamo(Expression<Func<Estadoreclamo, bool>> criteria)
		{
			return EstadoreclamoDao.GetAll(criteria);
		}

		public List<Estadoreclamo> GetAllEstadoreclamo(string orders)
		{
			return EstadoreclamoDao.GetAll(orders);
		}

		public List<Estadoreclamo> GetAllEstadoreclamo(string conditions, string orders)
		{
			return EstadoreclamoDao.GetAll(conditions, orders);
		}

		public Estadoreclamo GetEstadoreclamo(int id)
		{
			return EstadoreclamoDao.Get(id);
		}

		public Estadoreclamo GetEstadoreclamo(Expression<Func<Estadoreclamo, bool>> criteria)
		{
			return EstadoreclamoDao.Get(criteria);
		}
	}
}
