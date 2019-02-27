using System.Linq;
using Sunday.Core.Repositories.History;
using Sunday.Data.Entities;

namespace Sunday.Data.Repositories.History
{
    public class TaxRepository : HistoryRepository<Tax>
    {
        public TaxRepository() : base(new EntitiesModel())
        {
        }

        public override IQueryable<Tax> Query => base.Query.Where(x => !x.DeletedAtUtc.HasValue);
    }
}
