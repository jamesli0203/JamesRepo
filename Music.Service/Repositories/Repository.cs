using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Music.Service.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> DbSet;
        private DbContext context;
        public Repository(DbContext dataContext)
        {
            DbSet = dataContext.Set<T>();
            context = dataContext;
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Save()
        {
           
            context.SaveChanges();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
    }
}
