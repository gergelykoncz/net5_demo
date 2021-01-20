using EFDemo1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EFDemo1.Services
{
    public class BaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;


        public BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected DbSet<T> Set
        {
            get
            {
                return dbContext.Set<T>();
            }
        }

        public virtual IEnumerable<T> GetAllItems()
        {
            return Set.ToList();
        }

        public virtual IEnumerable<T> GetByCriteria(Expression<Func<T, bool>> criteria)
        {
            return Set.Where(criteria);
        }

        public virtual T GetByKey(object key)
        {
            return Set.Find(key);
        }

        public virtual T Update(T entity)
        {
            Set.Update(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public virtual T Insert(T entity)
        {
            Set.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public virtual void Remove(T entity)
        {
            Set.Remove(entity);
            dbContext.SaveChanges();
        }

    }
}
