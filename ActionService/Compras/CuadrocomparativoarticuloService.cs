using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountCuadrocomparativoarticulo()
		{
			return CuadrocomparativoarticuloDao.Count();
		}

		public long CountCuadrocomparativoarticulo(Expression<Func<Cuadrocomparativoarticulo, bool>> criteria)
		{
			return CuadrocomparativoarticuloDao.Count(criteria);
		}

		public int SaveCuadrocomparativoarticulo(Cuadrocomparativoarticulo entity)
		{
			return CuadrocomparativoarticuloDao.Save(entity);
		}

		public void UpdateCuadrocomparativoarticulo(Cuadrocomparativoarticulo entity)
		{
			CuadrocomparativoarticuloDao.Update(entity);
		}

		public void DeleteCuadrocomparativoarticulo(int id)
		{
			CuadrocomparativoarticuloDao.Delete(id);
		}

		public List<Cuadrocomparativoarticulo> GetAllCuadrocomparativoarticulo()
		{
			return CuadrocomparativoarticuloDao.GetAll();
		}

		public List<Cuadrocomparativoarticulo> GetAllCuadrocomparativoarticulo(Expression<Func<Cuadrocomparativoarticulo, bool>> criteria)
		{
			return CuadrocomparativoarticuloDao.GetAll(criteria);
		}

		public List<Cuadrocomparativoarticulo> GetAllCuadrocomparativoarticulo(string orders)
		{
			return CuadrocomparativoarticuloDao.GetAll(orders);
		}

		public List<Cuadrocomparativoarticulo> GetAllCuadrocomparativoarticulo(string conditions, string orders)
		{
			return CuadrocomparativoarticuloDao.GetAll(conditions, orders);
		}

		public Cuadrocomparativoarticulo GetCuadrocomparativoarticulo(int id)
		{
			return CuadrocomparativoarticuloDao.Get(id);
		}

		public Cuadrocomparativoarticulo GetCuadrocomparativoarticulo(Expression<Func<Cuadrocomparativoarticulo, bool>> criteria)
		{
			return CuadrocomparativoarticuloDao.Get(criteria);
		}
	}
}
