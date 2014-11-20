using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FirstApp.Data.Contexts;

namespace FirstApp.Data.Repos
{
    class DbContextRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly IDbContext _context;
        protected DbSet<T> dbSet;

        public DbContextRepository(IDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public virtual T Get(object id)
        {
            return dbSet.Find(id);
        }

        public virtual async Task<T> GetAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public virtual void Insert(T entity)
        {
            if (entity != null)
                dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            Delete(dbSet.Find(id));
        }
        
        public virtual void Delete(T entity)
        {
            if (entity != null)
                dbSet.Remove(entity);
        }

        public virtual void Update(object id)
        {
            Update(dbSet.Find(id));
        }

        public virtual void Update(T entity)
        {
            if (entity != null)
            {
                dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual int Save()
        {
            return _context.SaveChanges();
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
