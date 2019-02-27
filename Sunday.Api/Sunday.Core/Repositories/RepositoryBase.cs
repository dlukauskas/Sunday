using Sunday.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sunday.Core.Repositories
{
    public abstract class RepositoryBase<TEntity> : IDisposable
        where TEntity : class, IEntity<TEntity>
    {
        private readonly DbContext db;

        public RepositoryBase(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            db = context;
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return Query.ToListAsync();
        }
        public virtual Task<TEntity> GetAsync(int id)
        {
            return Query.FirstOrDefaultAsync(x => x.Id == id);
        }
        public virtual async Task<TEntity> SaveAsync(TEntity entity)
        {
            if (entity.Id == default(int))
            {
                db.Entry(entity).State = EntityState.Added;
            }
            else
            {
                db.Entry(entity).State = EntityState.Modified;
            }

            await db.SaveChangesAsync();

            return entity;
        }
        public virtual async Task DeleteAsync(int id)
        {
            var entity = await Query.FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                db.Entry(entity).State = EntityState.Deleted;

                await db.SaveChangesAsync();
            }
        }
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> query)
        {
            return await Query
                .Where(query)
                .AnyAsync();
        }

        public virtual IQueryable<TEntity> Query
        {
            get
            {
                return db.Set<TEntity>();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.db != null)
            {
                this.db.Dispose();
            }
        }
    }
}
