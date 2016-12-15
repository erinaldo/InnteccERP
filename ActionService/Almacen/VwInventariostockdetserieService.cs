using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwInventariostockdetserie()
		{
			return VwInventariostockdetserieDao.Count();
		}

		public long CountVwInventariostockdetserie(Expression<Func<VwInventariostockdetserie, bool>> criteria)
		{
			return VwInventariostockdetserieDao.Count(criteria);
		}

		public List<VwInventariostockdetserie> GetAllVwInventariostockdetserie()
		{
			return VwInventariostockdetserieDao.GetAll();
		}

		public List<VwInventariostockdetserie> GetAllVwInventariostockdetserie(Expression<Func<VwInventariostockdetserie, bool>> criteria)
		{
			return VwInventariostockdetserieDao.GetAll(criteria);
		}

		public List<VwInventariostockdetserie> GetAllVwInventariostockdetserie(string orders)
		{
			return VwInventariostockdetserieDao.GetAll(orders);
		}

		public List<VwInventariostockdetserie> GetAllVwInventariostockdetserie(string conditions, string orders)
		{
			return VwInventariostockdetserieDao.GetAll(conditions, orders);
		}

		public VwInventariostockdetserie GetVwInventariostockdetserie(int id)
		{
			return VwInventariostockdetserieDao.Get(id);
		}

		public VwInventariostockdetserie GetVwInventariostockdetserie(Expression<Func<VwInventariostockdetserie, bool>> criteria)
		{
			return VwInventariostockdetserieDao.Get(criteria);
		}
	}
}
