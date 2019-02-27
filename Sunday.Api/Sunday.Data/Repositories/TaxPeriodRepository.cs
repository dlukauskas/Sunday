using Sunday.Core.Repositories;
using Sunday.Data.Entities;

namespace Sunday.Data.Repositories
{
    public class TaxPeriodRepository : Repository<TaxPeriod>
    {
        public TaxPeriodRepository() : base(new EntitiesModel())
        {
        }
    }
}
