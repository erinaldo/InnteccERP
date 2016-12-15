using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountProgramacioncita()
		{
			return ProgramacioncitaDao.Count();
		}

		public long CountProgramacioncita(Expression<Func<Programacioncita, bool>> criteria)
		{
			return ProgramacioncitaDao.Count(criteria);
		}

		public int SaveProgramacioncita(Programacioncita entity)
		{
			return ProgramacioncitaDao.Save(entity);
		}

		public void UpdateProgramacioncita(Programacioncita entity)
		{
			ProgramacioncitaDao.Update(entity);
		}

		public void DeleteProgramacioncita(int id)
		{
			ProgramacioncitaDao.Delete(id);
		}

		public List<Programacioncita> GetAllProgramacioncita()
		{
			return ProgramacioncitaDao.GetAll();
		}

		public List<Programacioncita> GetAllProgramacioncita(Expression<Func<Programacioncita, bool>> criteria)
		{
			return ProgramacioncitaDao.GetAll(criteria);
		}

		public List<Programacioncita> GetAllProgramacioncita(string orders)
		{
			return ProgramacioncitaDao.GetAll(orders);
		}

		public List<Programacioncita> GetAllProgramacioncita(string conditions, string orders)
		{
			return ProgramacioncitaDao.GetAll(conditions, orders);
		}

		public Programacioncita GetProgramacioncita(int id)
		{
			return ProgramacioncitaDao.Get(id);
		}

		public Programacioncita GetProgramacioncita(Expression<Func<Programacioncita, bool>> criteria)
		{
			return ProgramacioncitaDao.Get(criteria);
		}
	}
}
