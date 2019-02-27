using Sunday.Core.Repositories;
using Sunday.Data.Entities;

namespace Sunday.Data.Repositories
{
    public class MunicipalityRepository : Repository<Municipality>
    {
        public MunicipalityRepository() : base(new EntitiesModel())
        {
        }
    }
}
