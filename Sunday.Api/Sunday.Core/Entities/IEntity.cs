using System;
using System.Linq.Expressions;

namespace Sunday.Core.Entities
{
    public interface IEntity<T>
        where T : class
    {
        int Id { get; set; }

        Expression<Func<T, bool>> ExistsQuery { get; }
    }
}
