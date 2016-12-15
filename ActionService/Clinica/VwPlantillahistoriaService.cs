using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
	public partial class Service
	{
		public long CountVwPlantillahistoria()
		{
			return VwPlantillahistoriaDao.Count();
		}

		public long CountVwPlantillahistoria(Expression<Func<VwPlantillahistoria, bool>> criteria)
		{
			return VwPlantillahistoriaDao.Count(criteria);
		}

		public List<VwPlantillahistoria> GetAllVwPlantillahistoria()
		{
			return VwPlantillahistoriaDao.GetAll();
		}

		public List<VwPlantillahistoria> GetAllVwPlantillahistoria(Expression<Func<VwPlantillahistoria, bool>> criteria)
		{
			return VwPlantillahistoriaDao.GetAll(criteria);
		}

		public List<VwPlantillahistoria> GetAllVwPlantillahistoria(string orders)
		{
			return VwPlantillahistoriaDao.GetAll(orders);
		}

		public List<VwPlantillahistoria> GetAllVwPlantillahistoria(string conditions, string orders)
		{
			return VwPlantillahistoriaDao.GetAll(conditions, orders);
		}

		public VwPlantillahistoria GetVwPlantillahistoria(int id)
		{
			return VwPlantillahistoriaDao.Get(id);
		}

		public VwPlantillahistoria GetVwPlantillahistoria(Expression<Func<VwPlantillahistoria, bool>> criteria)
		{
			return VwPlantillahistoriaDao.Get(criteria);
		}
	}
}
