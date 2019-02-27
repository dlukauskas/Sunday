using Sunday.Core.Entities.Historyable;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Sunday.Core.Repositories.History
{
    public class HistoryRepository<TEntity> : Repository<TEntity>
        where TEntity : class, IHistoryableEntity<TEntity>, new()
    {
        public HistoryRepository(DbContext context) : base(context) { }

        public override Task<TEntity> SaveAsync(TEntity entity)
        {
            var now = DateTime.UtcNow;

            if (entity.Id == default(int))
            {
                entity.CreatedAtUtc = now;
            }

            entity.UpdatedAtUtc = now;

            return base.SaveAsync(entity);
        }

        public override async Task DeleteAsync(int id)
        {
            var entity = await Query.FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                entity.DeletedAtUtc = DateTime.UtcNow;

                await SaveAsync(entity);
            }
        }
    }
}
