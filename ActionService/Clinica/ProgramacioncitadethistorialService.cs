using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountProgramacioncitadethistorial()
		{
			return ProgramacioncitadethistorialDao.Count();
		}

		public long CountProgramacioncitadethistorial(Expression<Func<Programacioncitadethistorial, bool>> criteria)
		{
			return ProgramacioncitadethistorialDao.Count(criteria);
		}

		public int SaveProgramacioncitadethistorial(Programacioncitadethistorial entity)
		{
			return ProgramacioncitadethistorialDao.Save(entity);
		}

		public void UpdateProgramacioncitadethistorial(Programacioncitadethistorial entity)
		{
			ProgramacioncitadethistorialDao.Update(entity);
		}

		public void DeleteProgramacioncitadethistorial(int id)
		{
			ProgramacioncitadethistorialDao.Delete(id);
		}

		public List<Programacioncitadethistorial> GetAllProgramacioncitadethistorial()
		{
			return ProgramacioncitadethistorialDao.GetAll();
		}

		public List<Programacioncitadethistorial> GetAllProgramacioncitadethistorial(Expression<Func<Programacioncitadethistorial, bool>> criteria)
		{
			return ProgramacioncitadethistorialDao.GetAll(criteria);
		}

		public List<Programacioncitadethistorial> GetAllProgramacioncitadethistorial(string orders)
		{
			return ProgramacioncitadethistorialDao.GetAll(orders);
		}

		public List<Programacioncitadethistorial> GetAllProgramacioncitadethistorial(string conditions, string orders)
		{
			return ProgramacioncitadethistorialDao.GetAll(conditions, orders);
		}

		public Programacioncitadethistorial GetProgramacioncitadethistorial(int id)
		{
			return ProgramacioncitadethistorialDao.Get(id);
		}

		public Programacioncitadethistorial GetProgramacioncitadethistorial(Expression<Func<Programacioncitadethistorial, bool>> criteria)
		{
			return ProgramacioncitadethistorialDao.Get(criteria);
		}
	}
}
