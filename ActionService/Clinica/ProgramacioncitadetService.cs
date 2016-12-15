using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountProgramacioncitadet()
		{
			return ProgramacioncitadetDao.Count();
		}

		public long CountProgramacioncitadet(Expression<Func<Programacioncitadet, bool>> criteria)
		{
			return ProgramacioncitadetDao.Count(criteria);
		}

		public int SaveProgramacioncitadet(Programacioncitadet entity)
		{
			return ProgramacioncitadetDao.Save(entity);
		}

		public void UpdateProgramacioncitadet(Programacioncitadet entity)
		{
			ProgramacioncitadetDao.Update(entity);
		}

		public void DeleteProgramacioncitadet(int id)
		{
			ProgramacioncitadetDao.Delete(id);
		}

		public List<Programacioncitadet> GetAllProgramacioncitadet()
		{
			return ProgramacioncitadetDao.GetAll();
		}

		public List<Programacioncitadet> GetAllProgramacioncitadet(Expression<Func<Programacioncitadet, bool>> criteria)
		{
			return ProgramacioncitadetDao.GetAll(criteria);
		}

		public List<Programacioncitadet> GetAllProgramacioncitadet(string orders)
		{
			return ProgramacioncitadetDao.GetAll(orders);
		}

		public List<Programacioncitadet> GetAllProgramacioncitadet(string conditions, string orders)
		{
			return ProgramacioncitadetDao.GetAll(conditions, orders);
		}

		public Programacioncitadet GetProgramacioncitadet(int id)
		{
			return ProgramacioncitadetDao.Get(id);
		}

		public Programacioncitadet GetProgramacioncitadet(Expression<Func<Programacioncitadet, bool>> criteria)
		{
			return ProgramacioncitadetDao.Get(criteria);
		}
	}
}
