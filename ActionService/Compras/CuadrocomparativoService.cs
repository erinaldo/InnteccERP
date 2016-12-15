using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCuadrocomparativo()
		{
			return CuadrocomparativoDao.Count();
		}

		public long CountCuadrocomparativo(Expression<Func<Cuadrocomparativo, bool>> criteria)
		{
			return CuadrocomparativoDao.Count(criteria);
		}

		public int SaveCuadrocomparativo(Cuadrocomparativo entity)
		{
			return CuadrocomparativoDao.Save(entity);
		}

		public void UpdateCuadrocomparativo(Cuadrocomparativo entity)
		{
			CuadrocomparativoDao.Update(entity);
		}

		public void DeleteCuadrocomparativo(int id)
		{
			CuadrocomparativoDao.Delete(id);
		}

		public List<Cuadrocomparativo> GetAllCuadrocomparativo()
		{
			return CuadrocomparativoDao.GetAll();
		}

		public List<Cuadrocomparativo> GetAllCuadrocomparativo(Expression<Func<Cuadrocomparativo, bool>> criteria)
		{
			return CuadrocomparativoDao.GetAll(criteria);
		}

		public List<Cuadrocomparativo> GetAllCuadrocomparativo(string orders)
		{
			return CuadrocomparativoDao.GetAll(orders);
		}

		public List<Cuadrocomparativo> GetAllCuadrocomparativo(string conditions, string orders)
		{
			return CuadrocomparativoDao.GetAll(conditions, orders);
		}

		public Cuadrocomparativo GetCuadrocomparativo(int id)
		{
			return CuadrocomparativoDao.Get(id);
		}

		public Cuadrocomparativo GetCuadrocomparativo(Expression<Func<Cuadrocomparativo, bool>> criteria)
		{
			return CuadrocomparativoDao.Get(criteria);
		}
	}
}
