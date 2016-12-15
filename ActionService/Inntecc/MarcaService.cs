using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountMarca()
		{
			return MarcaDao.Count();
		}

		public long CountMarca(Expression<Func<Marca, bool>> criteria)
		{
			return MarcaDao.Count(criteria);
		}

		public int SaveMarca(Marca entity)
		{
			return MarcaDao.Save(entity);
		}

		public void UpdateMarca(Marca entity)
		{
			MarcaDao.Update(entity);
		}

		public void DeleteMarca(int id)
		{
			MarcaDao.Delete(id);
		}

		public List<Marca> GetAllMarca()
		{
			return MarcaDao.GetAll();
		}

		public List<Marca> GetAllMarca(Expression<Func<Marca, bool>> criteria)
		{
			return MarcaDao.GetAll(criteria);
		}

		public List<Marca> GetAllMarca(string orders)
		{
			return MarcaDao.GetAll(orders);
		}

		public List<Marca> GetAllMarca(string conditions, string orders)
		{
			return MarcaDao.GetAll(conditions, orders);
		}

		public Marca GetMarca(int id)
		{
			return MarcaDao.Get(id);
		}

		public Marca GetMarca(Expression<Func<Marca, bool>> criteria)
		{
			return MarcaDao.Get(criteria);
		}
	}
}
