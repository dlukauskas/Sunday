using Sunday.Core.Entities.Namable;
using System;
using System.Linq.Expressions;

namespace Sunday.Data.Entities
{
    public partial class TaxPeriod : INamableEntity<TaxPeriod>
    {
        public Expression<Func<TaxPeriod, bool>> ExistsQuery
        {
            get
            {
                return x => x.Id == default(int) ? x.Name.ToLower() == Name.ToLower().Trim() :
                    x.Id != Id && x.Name.ToLower() == Name.ToLower().Trim();
            }
        }
    }
}
