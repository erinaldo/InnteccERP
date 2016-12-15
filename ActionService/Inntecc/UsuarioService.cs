using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BusinessObjects.Entities;

namespace ActionService
{       
        /*
        
        #region Usuario service
        
        long CountUsuario();
        long CountUsuario(Expression<Func<Usuario, bool>> criteria);
        int SaveUsuario(Usuario entity);
        void UpdateUsuario(Usuario entity);
        void DeleteUsuario(int id);
        List<Usuario> GetAllUsuario();
        List<Usuario> GetAllUsuario(Expression<Func<Usuario, bool>> criteria);
        List<Usuario> GetAllUsuario(string orders);
        List<Usuario> GetAllUsuario(string conditions, string orders);
        Usuario GetUsuario(int id);
        Usuario GetUsuario(Expression<Func<Usuario, bool>> criteria);  
        
        #endregion
        
        */

    public partial class Service
    {
        public long CountUsuario()
        {
            return UsuarioDao.Count();
        }

        public long CountUsuario(Expression<Func<Usuario, bool>> criteria)
        {
            return UsuarioDao.Count(criteria);
        }

        public int SaveUsuario(Usuario entity)
        {
            return UsuarioDao.Save(entity);
        }

        public void UpdateUsuario(Usuario entity)
        {
            UsuarioDao.Update(entity);
        }

        public void DeleteUsuario(int id)
        {
            UsuarioDao.Delete(id);
        }

        public List<Usuario> GetAllUsuario()
        {
            return UsuarioDao.GetAll();
        }

        public List<Usuario> GetAllUsuario(Expression<Func<Usuario, bool>> criteria)
        {
            return UsuarioDao.GetAll(criteria);
        }

        public List<Usuario> GetAllUsuario(string orders)
        {
            return UsuarioDao.GetAll(orders);
        }

        public List<Usuario> GetAllUsuario(string conditions, string orders)
        {
            return UsuarioDao.GetAll(conditions, orders);
        }

        public Usuario GetUsuario(int id)
        {
            return UsuarioDao.Get(id);
        }

        public Usuario GetUsuario(Expression<Func<Usuario, bool>> criteria)
        {
            return UsuarioDao.Get(criteria);
        }
    }
}
