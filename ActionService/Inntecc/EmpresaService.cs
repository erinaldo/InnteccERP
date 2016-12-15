using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
	{
		public long CountEmpresa()
		{
			return EmpresaDao.Count();
		}

		public long CountEmpresa(Expression<Func<Empresa, bool>> criteria)
		{
			return EmpresaDao.Count(criteria);
		}

		public int SaveEmpresa(Empresa entity)
		{
			return EmpresaDao.Save(entity);
		}

		public void UpdateEmpresa(Empresa entity)
		{
			EmpresaDao.Update(entity);
		}

		public void DeleteEmpresa(int id)
		{
			EmpresaDao.Delete(id);
		}

		public List<Empresa> GetAllEmpresa()
		{
			return EmpresaDao.GetAll();
		}

		public List<Empresa> GetAllEmpresa(Expression<Func<Empresa, bool>> criteria)
		{
			return EmpresaDao.GetAll(criteria);
		}

		public List<Empresa> GetAllEmpresa(string orders)
		{
			return EmpresaDao.GetAll(orders);
		}

		public List<Empresa> GetAllEmpresa(string conditions, string orders)
		{
			return EmpresaDao.GetAll(conditions, orders);
		}

		public Empresa GetEmpresa(int id)
		{
			return EmpresaDao.Get(id);
		}

		public Empresa GetEmpresa(Expression<Func<Empresa, bool>> criteria)
		{
			return EmpresaDao.Get(criteria);
		}
	}
}
