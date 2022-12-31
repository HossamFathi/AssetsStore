using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AssetsStore.Models.DataAcces.Helper
{
    public interface IRepositoryHelper<T> where T : class
    {
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enableTracking = true);
       T SingleOrDefault(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enableTracking = true);
        T Insert(T entity);
        bool InsertRange(IEnumerable<T>  entityRange);
        IEnumerable<T> GetAll();
        bool update(T Entity);
        bool delete(int id);
        bool SaveChange();
       
    }
}
