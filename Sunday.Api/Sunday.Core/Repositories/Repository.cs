using Sunday.Core.Entities;
using System.Data.Entity;

namespace Sunday.Core.Repositories
{
    public class Repository<TEntity> : RepositoryBase<TEntity>
        where TEntity : class, IEntity<TEntity>
    {
        public Repository(DbContext context) : base(context)
        {
        }
    }
}
