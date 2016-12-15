using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCuadrocomparativoprv()
		{
			return CuadrocomparativoprvDao.Count();
		}

		public long CountCuadrocomparativoprv(Expression<Func<Cuadrocomparativoprv, bool>> criteria)
		{
			return CuadrocomparativoprvDao.Count(criteria);
		}

		public int SaveCuadrocomparativoprv(Cuadrocomparativoprv entity)
		{
			return CuadrocomparativoprvDao.Save(entity);
		}

		public void UpdateCuadrocomparativoprv(Cuadrocomparativoprv entity)
		{
			CuadrocomparativoprvDao.Update(entity);
		}

		public void DeleteCuadrocomparativoprv(int id)
		{
			CuadrocomparativoprvDao.Delete(id);
		}

		public List<Cuadrocomparativoprv> GetAllCuadrocomparativoprv()
		{
			return CuadrocomparativoprvDao.GetAll();
		}

		public List<Cuadrocomparativoprv> GetAllCuadrocomparativoprv(Expression<Func<Cuadrocomparativoprv, bool>> criteria)
		{
			return CuadrocomparativoprvDao.GetAll(criteria);
		}

		public List<Cuadrocomparativoprv> GetAllCuadrocomparativoprv(string orders)
		{
			return CuadrocomparativoprvDao.GetAll(orders);
		}

		public List<Cuadrocomparativoprv> GetAllCuadrocomparativoprv(string conditions, string orders)
		{
			return CuadrocomparativoprvDao.GetAll(conditions, orders);
		}

		public Cuadrocomparativoprv GetCuadrocomparativoprv(int id)
		{
			return CuadrocomparativoprvDao.Get(id);
		}

		public Cuadrocomparativoprv GetCuadrocomparativoprv(Expression<Func<Cuadrocomparativoprv, bool>> criteria)
		{
			return CuadrocomparativoprvDao.Get(criteria);
		}
	}
}
