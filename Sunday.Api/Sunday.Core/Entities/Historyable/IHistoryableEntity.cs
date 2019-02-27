using System;

namespace Sunday.Core.Entities.Historyable
{
    public interface IHistoryableEntity<T> : IEntity<T>
        where T : class
    {
        DateTime CreatedAtUtc { get; set; }
        DateTime UpdatedAtUtc { get; set; }
        DateTime? DeletedAtUtc { get; set; }
    }
}
