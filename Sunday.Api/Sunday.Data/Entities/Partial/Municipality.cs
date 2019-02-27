using Sunday.Core.Entities.Namable;
using System;
using System.Linq.Expressions;

namespace Sunday.Data.Entities
{
    public partial class Municipality : INamableEntity<Municipality>
    {
        public Expression<Func<Municipality, bool>> ExistsQuery
        {
            get
            {
                return x => x.Id == default(int) ? x.Name.ToLower() == Name.ToLower().Trim() :
                    x.Id != Id && x.Name.ToLower() == Name.ToLower().Trim();
            }
        }
    }
}
