using AutoMapper;
using Sunday.Api.Controllers.Base.Details;
using Sunday.Core.Entities;
using Sunday.Core.Repositories;
using Sunday.Models.Details;
using Sunday.Models.Listing;
using Sunday.Models.Listing.ListingItem;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sunday.Api.Controllers.Base.Listing
{
    public abstract class ListingApiControllerBase<TListingItem, TListingModel, TDetailsModel, TEntity, TRepository> :
        DetailsApiControllerBase<TDetailsModel, TEntity, TRepository>
            where TListingItem : ListingItemBase, new()
            where TListingModel : ListingModelBase<TListingItem>, new()
            where TDetailsModel : DetailsModelBase, new()
            where TEntity : class, IEntity<TEntity>
            where TRepository : RepositoryBase<TEntity>, new()
    {
        public ListingApiControllerBase() : base(new TRepository())
        {
        }

        [HttpGet]
        public virtual async Task<IHttpActionResult> GetAll()
        {
            var model = new TListingModel();

            var entities = await Repository.GetAllAsync();

            if (entities != null && entities.Any())
            {
                model.Items = Mapper.Map<List<TListingItem>>(entities);

                return Ok(model);
            }

            return NotFound();
        }
    }
}