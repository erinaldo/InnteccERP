using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountSocionegentidadfinanciera()
		{
			return SocionegentidadfinancieraDao.Count();
		}

		public long CountSocionegentidadfinanciera(Expression<Func<Socionegentidadfinanciera, bool>> criteria)
		{
			return SocionegentidadfinancieraDao.Count(criteria);
		}

		public int SaveSocionegentidadfinanciera(Socionegentidadfinanciera entity)
		{
			return SocionegentidadfinancieraDao.Save(entity);
		}

		public void UpdateSocionegentidadfinanciera(Socionegentidadfinanciera entity)
		{
			SocionegentidadfinancieraDao.Update(entity);
		}

		public void DeleteSocionegentidadfinanciera(int id)
		{
			SocionegentidadfinancieraDao.Delete(id);
		}

		public List<Socionegentidadfinanciera> GetAllSocionegentidadfinanciera()
		{
			return SocionegentidadfinancieraDao.GetAll();
		}

		public List<Socionegentidadfinanciera> GetAllSocionegentidadfinanciera(Expression<Func<Socionegentidadfinanciera, bool>> criteria)
		{
			return SocionegentidadfinancieraDao.GetAll(criteria);
		}

		public List<Socionegentidadfinanciera> GetAllSocionegentidadfinanciera(string orders)
		{
			return SocionegentidadfinancieraDao.GetAll(orders);
		}

		public List<Socionegentidadfinanciera> GetAllSocionegentidadfinanciera(string conditions, string orders)
		{
			return SocionegentidadfinancieraDao.GetAll(conditions, orders);
		}

		public Socionegentidadfinanciera GetSocionegentidadfinanciera(int id)
		{
			return SocionegentidadfinancieraDao.Get(id);
		}

		public Socionegentidadfinanciera GetSocionegentidadfinanciera(Expression<Func<Socionegentidadfinanciera, bool>> criteria)
		{
			return SocionegentidadfinancieraDao.Get(criteria);
		}
	}
}
