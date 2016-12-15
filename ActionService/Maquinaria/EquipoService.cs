using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEquipo()
		{
			return EquipoDao.Count();
		}

		public long CountEquipo(Expression<Func<Equipo, bool>> criteria)
		{
			return EquipoDao.Count(criteria);
		}

		public int SaveEquipo(Equipo entity)
		{
			return EquipoDao.Save(entity);
		}

		public void UpdateEquipo(Equipo entity)
		{
			EquipoDao.Update(entity);
		}

		public void DeleteEquipo(int id)
		{
			EquipoDao.Delete(id);
		}

		public List<Equipo> GetAllEquipo()
		{
			return EquipoDao.GetAll();
		}

		public List<Equipo> GetAllEquipo(Expression<Func<Equipo, bool>> criteria)
		{
			return EquipoDao.GetAll(criteria);
		}

		public List<Equipo> GetAllEquipo(string orders)
		{
			return EquipoDao.GetAll(orders);
		}

		public List<Equipo> GetAllEquipo(string conditions, string orders)
		{
			return EquipoDao.GetAll(conditions, orders);
		}

		public Equipo GetEquipo(int id)
		{
			return EquipoDao.Get(id);
		}

		public Equipo GetEquipo(Expression<Func<Equipo, bool>> criteria)
		{
			return EquipoDao.Get(criteria);
		}
	}
}
