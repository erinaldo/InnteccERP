using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{       
        /*
        
        #region Sucursal service
        
        long CountSucursal();
        long CountSucursal(Expression<Func<Sucursal, bool>> criteria);
        int SaveSucursal(Sucursal entity);
        void UpdateSucursal(Sucursal entity);
        void DeleteSucursal(int id);
        List<Sucursal> GetAllSucursal();
        List<Sucursal> GetAllSucursal(Expression<Func<Sucursal, bool>> criteria);
        List<Sucursal> GetAllSucursal(string orders);
        List<Sucursal> GetAllSucursal(string conditions, string orders);
        Sucursal GetSucursal(int id);
        Sucursal GetSucursal(Expression<Func<Sucursal, bool>> criteria);  
        
        #endregion
        
        */

    public partial class Service
    {
        public long CountSucursal()
        {
            return SucursalDao.Count();
        }

        public long CountSucursal(Expression<Func<Sucursal, bool>> criteria)
        {
            return SucursalDao.Count(criteria);
        }

        public int SaveSucursal(Sucursal entity)
        {
            return SucursalDao.Save(entity);
        }

        public void UpdateSucursal(Sucursal entity)
        {
            SucursalDao.Update(entity);
        }

        public void DeleteSucursal(int id)
        {
            SucursalDao.Delete(id);
        }

        public List<Sucursal> GetAllSucursal()
        {
            return SucursalDao.GetAll();
        }

        public List<Sucursal> GetAllSucursal(Expression<Func<Sucursal, bool>> criteria)
        {
            return SucursalDao.GetAll(criteria);
        }

        public List<Sucursal> GetAllSucursal(string orders)
        {
            return SucursalDao.GetAll(orders);
        }

        public List<Sucursal> GetAllSucursal(string conditions, string orders)
        {
            return SucursalDao.GetAll(conditions, orders);
        }

        public Sucursal GetSucursal(int id)
        {
            return SucursalDao.Get(id);
        }

        public Sucursal GetSucursal(Expression<Func<Sucursal, bool>> criteria)
        {
            return SucursalDao.Get(criteria);
        }
    }
}
