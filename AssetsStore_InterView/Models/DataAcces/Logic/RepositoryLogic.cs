using AssetsStore.Models.DataAcces.Helper;
using AssetsStore_InterView.Models.DataAcces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AssetsStore.Models.DataAcces.Logic
{
    public class RepositoryLogic<T> : IRepositoryHelper<T> where T : class
    {
     
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public RepositoryLogic(AssetContext context)
        {
            _dbContext = context ?? throw new ArgumentException(nameof(context));
            _dbSet = _dbContext.Set<T>();
        }


        public bool Delete(T entity)
        {
            try
            {
                T RemovedEntity = _dbSet.Remove(entity).Entity;
                if (RemovedEntity is null)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public bool SaveChange()
        {
           if( _dbContext.SaveChanges() > 0)
                return true ;
            return false;
        }
        public bool delete(int id)
        {
            try
            {
                T RemovedEntity = _dbSet.Find(id);
                return Delete(RemovedEntity);
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        

        public T SingleOrDefault(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enableTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (!enableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
                return orderBy(query).FirstOrDefault();
            return query.FirstOrDefault();
        }


        public IEnumerable<T> GetAll()
        {
            try
            {
                return _dbSet.ToList();
            }catch (Exception e)
            {
               return Enumerable.Empty<T>(); 
            }
        }
        public IEnumerable<T> Search(Expression<Func<T, bool>> predicate = null,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
             Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
             bool enableTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (!enableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
                return orderBy(query).ToList();
            return query.ToList();
        }

        public bool update(T Entity)
        {
           T UpdatedEntity = _dbSet.Update(Entity).Entity;
            if(UpdatedEntity is null)
            {
                return false; 

            }
            return true;
        }

        public T Insert(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                return entity;
            }catch(Exception e)
            {
                return null;
            }
        }

        public bool InsertRange(IEnumerable<T> entityRange)
        {
            try
            {
                _dbSet.AddRange(entityRange);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
