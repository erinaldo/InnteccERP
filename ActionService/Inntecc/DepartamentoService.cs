using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{
    public partial class Service
    {
        public long CountDepartamento()
        {
            return DepartamentoDao.Count();
        }

        public long CountDepartamento(Expression<Func<Departamento, bool>> criteria)
        {
            return DepartamentoDao.Count(criteria);
        }

        public int SaveDepartamento(Departamento entity)
        {
            return DepartamentoDao.Save(entity);
        }

        public void UpdateDepartamento(Departamento entity)
        {
            DepartamentoDao.Update(entity);
        }

        public void DeleteDepartamento(int id)
        {
            DepartamentoDao.Delete(id);
        }

        public List<Departamento> GetAllDepartamento()
        {
            return DepartamentoDao.GetAll();
        }

        public List<Departamento> GetAllDepartamento(Expression<Func<Departamento, bool>> criteria)
        {
            return DepartamentoDao.GetAll(criteria);
        }

        public List<Departamento> GetAllDepartamento(string orders)
        {
            return DepartamentoDao.GetAll(orders);
        }

        public List<Departamento> GetAllDepartamento(string conditions, string orders)
        {
            return DepartamentoDao.GetAll(conditions, orders);
        }

        public Departamento GetDepartamento(int id)
        {
            return DepartamentoDao.Get(id);
        }

        public Departamento GetDepartamento(Expression<Func<Departamento, bool>> criteria)
        {
            return DepartamentoDao.Get(criteria);
        }
    }
}
