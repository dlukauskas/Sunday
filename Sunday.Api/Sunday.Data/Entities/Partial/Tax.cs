using Sunday.Core.Entities.Historyable;
using System;
using System.Linq.Expressions;

namespace Sunday.Data.Entities
{
    public partial class Tax : IHistoryableEntity<Tax>
    {
        public Expression<Func<Tax, bool>> ExistsQuery
        {
            get
            {
                return x => x.Id == default(int) ?
                    x.TaxPeriodId == TaxPeriodId && x.MunicipalityId == MunicipalityId && x.EndDateUtc >= StartDateUtc && x.StartDateUtc < EndDateUtc :
                    x.Id != Id && x.TaxPeriodId == TaxPeriodId && x.MunicipalityId == MunicipalityId && x.EndDateUtc >= StartDateUtc && x.StartDateUtc < EndDateUtc ;
            }
        }
    }
}
