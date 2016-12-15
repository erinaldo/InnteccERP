using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataObjects.Dao.Core
{
    public interface IDao<T> where T : class
    {
        long Count();
        long Count(Expression<Func<T, bool>> criteria);
        int Save(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> criteria);
        List<T> GetAll(string orders);
        List<T> GetAll(string conditions, string orders);
        T Get(int id);
        T Get(Expression<Func<T, bool>> criteria);
        string GetNextAlphanumericCorrelative();
        bool ExistsAlphanumericCorrelative(string value);
        void ExecuteNonQuery(string sqlCommand);
    }
}