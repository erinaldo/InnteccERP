using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountPlantillahistoria()
		{
			return PlantillahistoriaDao.Count();
		}

		public long CountPlantillahistoria(Expression<Func<Plantillahistoria, bool>> criteria)
		{
			return PlantillahistoriaDao.Count(criteria);
		}

		public int SavePlantillahistoria(Plantillahistoria entity)
		{
			return PlantillahistoriaDao.Save(entity);
		}

		public void UpdatePlantillahistoria(Plantillahistoria entity)
		{
			PlantillahistoriaDao.Update(entity);
		}

		public void DeletePlantillahistoria(int id)
		{
			PlantillahistoriaDao.Delete(id);
		}

		public List<Plantillahistoria> GetAllPlantillahistoria()
		{
			return PlantillahistoriaDao.GetAll();
		}

		public List<Plantillahistoria> GetAllPlantillahistoria(Expression<Func<Plantillahistoria, bool>> criteria)
		{
			return PlantillahistoriaDao.GetAll(criteria);
		}

		public List<Plantillahistoria> GetAllPlantillahistoria(string orders)
		{
			return PlantillahistoriaDao.GetAll(orders);
		}

		public List<Plantillahistoria> GetAllPlantillahistoria(string conditions, string orders)
		{
			return PlantillahistoriaDao.GetAll(conditions, orders);
		}

		public Plantillahistoria GetPlantillahistoria(int id)
		{
			return PlantillahistoriaDao.Get(id);
		}

		public Plantillahistoria GetPlantillahistoria(Expression<Func<Plantillahistoria, bool>> criteria)
		{
			return PlantillahistoriaDao.Get(criteria);
		}
	}
}
